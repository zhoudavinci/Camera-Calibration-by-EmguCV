using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;

namespace Camera_Calibration_EmguCV
{
    public partial class Form1 : Form
    {
        private delegate void SetTextCallback (Control control, string text);    //delegate declaration

        #region declaring global variables
        private MCvPoint3D32f[][] object_corner;                                //points in world coordinate
        private PointF[][] corner_count;                                        //points in image coordinate

        private IntrinsicCameraParameters intrinsicParam = new IntrinsicCameraParameters(5);        //camera intrinsic       
        private ExtrinsicCameraParameters[] extrinsicParams;                                        //camera extrinsic
        private Matrix<float> mapx = new Matrix<float>(height, width);                      //mapping matrix
        private Matrix<float> mapy = new Matrix<float>(height, width);
        private MCvTermCriteria criteria=new MCvTermCriteria (100,1e-5);

        private Capture capture1;
        private const int width = 640;      //camera resolution
        private const int height = 480;
        private Size imageSize = new Size(width, height);
        private Size patternSize;           //corner pattern
        private int nPoints;                //number of corners
        private int nImage;                 //number of images which use to calibrate
        private float square;               //the actual size of square (mm)
        private bool captureInProcess;      //the process sign of camera
        private bool isCalibrating;         //the sign of calibrating
        private bool isCalibrated;          //the sign of calibrated
        Image<Bgr, byte> imageFrame1;
        Image<Gray, byte> grayFrame1;
        private bool isCorners;             //the var is ture when there is corners file in local

        Thread newThread;                   //thread of calibrating
        #endregion

        public Form1()
        {
            InitializeComponent();
            controlsInit();
        }

        private void controlsInit()
        {
            Corners_Nx.Text = "12";
            Corners_Ny.Text = "8";
            Square_Size.Text = "20";
            Image_Count.Text = "20";
            radio_camera.Checked = true;

            isCalibrating = false;
            isCalibrated = false;
            captureInProcess = false;
            isCorners = false;

            Start_Calibrate.Enabled = false;
            Exit_Calibrate.Enabled = false;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            imageFrame1 = capture1.QueryFrame();
            grayFrame1 = imageFrame1.Convert<Gray, byte>();
            if (!isCalibrating)
            {
                pictureBox1.Image = grayFrame1.ToBitmap();
            }
            if (isCalibrated)
            {
                CvInvoke.cvRemap(grayFrame1.Ptr, grayFrame1.Ptr, mapx, mapy, (int)WARP.CV_WARP_FILL_OUTLIERS, new MCvScalar(0));
                pictureBox1.Image = grayFrame1.ToBitmap();
            }
        }

        /// <summary>
        /// camera Start and Stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            #region if capture is not created, create it now
            if (null == capture1)
            {
                try
                {
                    capture1 = new Capture(0);
                    capture1.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, width);
                    capture1.SetCaptureProperty(CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, height);
                }
                catch(NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            #endregion

            if (null != capture1)
            {
                if (captureInProcess)
                {
                    button1.Text = "Start";
                    Application.Idle -= ProcessFrame;
                    Start_Calibrate.Enabled = false;
                    Exit_Calibrate.Enabled = false;
                }
                else
                {
                    button1.Text = "Stop";
                    Application.Idle += ProcessFrame;
                    Start_Calibrate.Enabled = true;
                    Exit_Calibrate.Enabled = true;
                }
                captureInProcess = !captureInProcess;
            }
        }

        /// <summary>
        /// Release sourse
        /// </summary>
        private void ReleaseData()
        {
            if (null != capture1)
            {
                capture1.Dispose();
            }
        }

        /// <summary>
        /// Initialize arrays
        /// </summary>
        public void cameraInitialize()
        {
            object_corner = new MCvPoint3D32f[nImage][];
            corner_count = new PointF[nImage][];
            extrinsicParams = new ExtrinsicCameraParameters[nImage];

            for (int i = 0; i < nImage; i++)
            {
                object_corner[i] = new MCvPoint3D32f[nPoints];
                corner_count[i] = new PointF[nPoints];
            }
        }

        /// <summary>
        /// points in world coordinate
        /// </summary>
        /// <param name="corners3D">coordinate value</param>
        /// <param name="chessBoardSize">size of chessboard</param>
        /// <param name="nImages">number of images</param>
        /// <param name="squareSize">actual size of square</param>
        private void objectCorners3D(MCvPoint3D32f[][] corners3D, Size chessBoardSize, int nImages, float squareSize)
        {
            int currentImage, currentRow, currentCol;
            for (currentImage = 0; currentImage < nImages; currentImage++)
            {
                for (currentRow = 0; currentRow < chessBoardSize.Height; currentRow++)
                {
                    for (currentCol = 0; currentCol < chessBoardSize.Width; currentCol++)
                    {
                        int nPoint = currentRow * chessBoardSize.Width + currentCol;
                        corners3D[currentImage][nPoint].x = (float)currentCol * squareSize;
                        corners3D[currentImage][nPoint].y = (float)currentRow * squareSize;
                        corners3D[currentImage][nPoint].z = (float)0.0f;
                    }
                }
            }
        }

        /// <summary>
        /// corners detection
        /// </summary>
        /// <param name="chessboardImage">chessboard image</param>
        /// <param name="cornersDetected">corners value in image coordinate</param>
        /// <returns>
        /// return true if success
        /// </returns>
        private bool findCorners(ref Image<Gray, byte> chessboardImage, out PointF[] cornersDetected)
        {
            cornersDetected = new PointF[nPoints];

            cornersDetected = CameraCalibration.FindChessboardCorners(chessboardImage, patternSize,
                            CALIB_CB_TYPE.ADAPTIVE_THRESH | CALIB_CB_TYPE.NORMALIZE_IMAGE);//////////////

            if (null == cornersDetected)
            {
                return false;
            }
            else
            {
                CvInvoke.cvFindCornerSubPix(chessboardImage, cornersDetected, nPoints,
                    new Size(5, 5), new Size(-1, -1), criteria);
                CameraCalibration.DrawChessboardCorners(chessboardImage, patternSize, cornersDetected);
                return true;
            }
        }

        /// <summary>
        /// single camera calibration
        /// </summary>
        /// <param name="objectPoints">corners value in world coordinate</param>
        /// <param name="imagePoints">corners value in image coordinate</param>
        /// <param name="imageSize">image size</param>
        /// <param name="intrinsicParam">camera intrinsic</param>
        /// <param name="extrinsicParams">camera extrinsic</param>
        /// <returns>reprojection error</returns>
        private double singleCameraCalibration(MCvPoint3D32f[][] objectPoints,
                                                PointF[][] imagePoints,
                                                Size imageSize,
                                                IntrinsicCameraParameters intrinsicParam,
                                                ExtrinsicCameraParameters[] extrinsicParams
                                            )
        {
            return (CameraCalibration.CalibrateCamera(objectPoints, imagePoints, imageSize, intrinsicParam,
                CALIB_TYPE.CV_CALIB_FIX_K3, criteria, out extrinsicParams));
        }

        /// <summary>
        /// negative image for observation
        /// </summary>
        /// <param name="bitmap">original image</param>
        /// <returns>negative image</returns>
        private Bitmap snap(Bitmap bitmap)
        {
            Bitmap bmp = new Bitmap(bitmap);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                 bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = bmpData.Stride * bitmap.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
            for (int i = 0; i < bytes; i += 4)
            {
                rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = (byte)(255 - rgbValues[i]);
            }
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            bmp.UnlockBits(bmpData);
            return bmp;
        }

        /// <summary>
        /// save corner file include objectPoints and imagePoints
        /// </summary>
        private void saveCorners()
        {
            //One xml file, for objectCorners in world coordinate,
            //and detected corners for chessboard coordinate.

            XmlDocument doc = new XmlDocument();
            XmlNode decl = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            doc.AppendChild(decl);

            XmlElement root = doc.CreateElement("", "Corners_Storage", "");
            doc.AppendChild(root);
            for (int i = 0; i < nImage; i++)
            {
                string image = "image" + (i + 1).ToString();
                XmlElement imageIndex = doc.CreateElement("", image, "");
                for (int n = 0; n < nPoints; n++)
                {
                    int point = i * nPoints + n;
                    string node = "node" + (point + 1).ToString();
                    XmlElement nodeIndex = doc.CreateElement("", node, "");
                    XmlElement data_1 = doc.CreateElement("data");
                    XmlElement data_2 = doc.CreateElement("data");
                    XmlElement data_3 = doc.CreateElement("data");
                    XmlElement data_4 = doc.CreateElement("data");
                    XmlElement data_5 = doc.CreateElement("data");

                    XmlText data1 = doc.CreateTextNode(Convert.ToString(object_corner[i][n].x));
                    XmlText data2 = doc.CreateTextNode(Convert.ToString(object_corner[i][n].y));
                    XmlText data3 = doc.CreateTextNode(Convert.ToString(object_corner[i][n].z));
                    XmlText data4 = doc.CreateTextNode(Convert.ToString(corner_count[i][n].X));
                    XmlText data5 = doc.CreateTextNode(Convert.ToString(corner_count[i][n].Y));

                    nodeIndex.AppendChild(data_1);
                    nodeIndex.AppendChild(data_2);
                    nodeIndex.AppendChild(data_3);
                    nodeIndex.AppendChild(data_4);
                    nodeIndex.AppendChild(data_5);
                    data_1.AppendChild(data1);
                    data_2.AppendChild(data2);
                    data_3.AppendChild(data3);
                    data_4.AppendChild(data4);
                    data_5.AppendChild(data5);
                    imageIndex.InsertAfter(nodeIndex, imageIndex.LastChild);
                }
                root.InsertAfter(imageIndex, root.LastChild);
            }

            try
            {
                doc.Save("DataCorners.xml");
                MessageBox.Show("Save Corners successful.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        /// <summary>
        /// save camera intrinsic
        /// </summary>
        private void saveIntrinsic()
        {
            XmlDocument doc = new XmlDocument();
            XmlWriterSettings xmlSetting = new XmlWriterSettings();
            xmlSetting.Encoding = new UTF8Encoding(false);
            xmlSetting.Indent = true;
            XmlWriter writer;

            writer = XmlWriter.Create("Intrinsic.xml", xmlSetting);
            writer.WriteStartElement("opencv_storage");
            writer.WriteStartElement("matrix_left");
            writer.WriteStartAttribute("type_id");
            writer.WriteValue("opencv-matrix");
            writer.WriteEndAttribute();
            for (int i = 0; i < intrinsicParam.IntrinsicMatrix.Width * intrinsicParam.IntrinsicMatrix.Height; i++)
            {
                writer.WriteStartElement("data");
                writer.WriteValue(intrinsicParam.IntrinsicMatrix[i/3, i%3]);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            //intrinsicParam.IntrinsicMatrix.WriteXml(writer);
            //writer.WriteEndElement();
            writer.Flush();
            //writer.WriteStartElement("Distoration");
            //intrinsicParam.DistortionCoeffs.WriteXml(writer);
            //writer.WriteEndElement();
            writer.WriteStartElement("distortion_left");
            writer.WriteStartAttribute("type_id");
            writer.WriteValue("opencv-matrix");
            writer.WriteEndAttribute();
            for (int i = 0; i < intrinsicParam.DistortionCoeffs.Rows; i++)
            {
                writer.WriteStartElement("data");
                writer.WriteValue(intrinsicParam.DistortionCoeffs[i, 0]);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Flush();

            doc.Save(writer);
            writer.Close();

            MessageBox.Show("Save Intrinsic successful.");
        }

        /// <summary>
        /// camera calibrate
        /// </summary>
        /// <param name="camera"></param>
        public IntrinsicCameraParameters cameraCalibration()
        {
            string text = this.Text;
            if (!isCorners)
            {
                cameraInitialize();

                objectCorners3D(object_corner, patternSize, nImage, square);

                int nCount = 0;
                int nFrame = 0;
                while (nCount < nImage)
                {
                    if (!radio_camera.Checked)
                    {
                        string filename = "left" + (nCount + 1).ToString() + ".bmp";
                        grayFrame1 = new Image<Gray, byte>(filename);
                    }
                    pictureBox1.Image = grayFrame1.ToBitmap();

                    if (findCorners(ref grayFrame1, out corner_count[nCount]))
                    {
                        if (nFrame++ > 5)
                        {
                            nCount++;
                            nFrame = 0;
                        }
                        if (nCount > 0 && nFrame < 1)
                        {
                            pictureBox1.Image = snap(grayFrame1.ToBitmap());
                            SetText(this, nCount.ToString() + "th image");
                            Thread.Sleep(1000);
                        }
                    }
                }

                SetText(this, text);
                saveCorners();
            }
            
            double reprojection_error = singleCameraCalibration(object_corner, corner_count, imageSize, intrinsicParam, extrinsicParams);

            MessageBox.Show("reprojection error: " + reprojection_error.ToString() + "\n" + "Camera Calibrated.");

            CvInvoke.cvInitUndistortMap(intrinsicParam.IntrinsicMatrix, intrinsicParam.DistortionCoeffs, mapx, mapy);

            saveIntrinsic();

            return intrinsicParam;
        }

        /// <summary>
        /// valid the control value which initialize camera param
        /// </summary>
        /// <returns>
        /// return false if invalid
        /// </returns>
        private bool validControls()
        {
            if ("" == Corners_Nx.Text || "" == Corners_Ny.Text ||
                "" == Square_Size.Text || "" == Image_Count.Text)
                return false;
            else
                return true;
        }

        /// <summary>
        /// start new thread for calibrate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Calibrate_Click(object sender, EventArgs e)
        {
            newThread = new System.Threading.Thread(new System.Threading.ThreadStart(this.startCalibrate));
            newThread.Priority = ThreadPriority.Normal;
            newThread.IsBackground = false;
            newThread.Start();
        }


        private void startCalibrate()
        {
            if (validControls())
            {
                patternSize = new Size(Convert.ToInt16(Corners_Nx.Text), Convert.ToInt16(Corners_Ny.Text));
                nPoints = patternSize.Height * patternSize.Width;
                nImage = Convert.ToInt16(Image_Count.Text);
                square = (float)Convert.ToDouble(Square_Size.Text);

                isCalibrating = true;

                intrinsicParam = cameraCalibration();

                SetText(textBox1, intrinsicParam.IntrinsicMatrix[0, 0].ToString());
                SetText(textBox2, intrinsicParam.IntrinsicMatrix[1, 1].ToString());
                SetText(textBox3, intrinsicParam.IntrinsicMatrix[0, 2].ToString());
                SetText(textBox4, intrinsicParam.IntrinsicMatrix[1, 2].ToString());

                SetText(textBox5, intrinsicParam.DistortionCoeffs[0, 0].ToString());
                SetText(textBox6, intrinsicParam.DistortionCoeffs[1, 0].ToString());
                SetText(textBox7, intrinsicParam.DistortionCoeffs[4, 0].ToString());
                SetText(textBox8, intrinsicParam.DistortionCoeffs[2, 0].ToString());
                SetText(textBox9, intrinsicParam.DistortionCoeffs[3, 0].ToString());

                isCalibrating = false;
            }
            else
                MessageBox.Show("Please Input ChessBoard Params");
        }

        /// <summary>
        /// set value of textBox.Text, using control in different threads needs InvokeRequired attribute
        /// </summary>
        /// <param name="textBox">textBox name</param>
        /// <param name="text">string which will set in textBox</param>
        private void SetText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] {control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        /// <summary>
        /// exit calibrate and abort thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Calibrate_Click(object sender, EventArgs e)
        {
            isCalibrated = false;
            isCalibrating = false;
            if (null != newThread)
            {
                MessageBox.Show("Exit Calibrate");
                newThread.Abort();
            }
        }

        /// <summary>
        /// exit program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, EventArgs e)
        {
            if (null != newThread)
            {
                newThread.Abort();
            }
            Application.Exit();
        }

        /// <summary>
        /// read corners if there is a corner file in local
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Read_Corners_Click(object sender, EventArgs e)
        {
            if (validControls())
            {
                patternSize = new Size(Convert.ToInt16(Corners_Nx.Text), Convert.ToInt16(Corners_Ny.Text));
                nPoints = patternSize.Height * patternSize.Width;
                nImage = Convert.ToInt16(Image_Count.Text);
                square = (float)Convert.ToDouble(Square_Size.Text);

                cameraInitialize();

                XmlDocument doc = new XmlDocument();
                XmlReader reader;
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                reader = XmlReader.Create("DataCorners.xml", settings);
                doc.Load(reader);
                XmlNode xmlNode = doc.SelectSingleNode("Corners_Storage");
                if (null == xmlNode)
                {
                    MessageBox.Show("Load Corners Error.");
                    return;
                }
                else
                {
                    XmlNodeList imageList = xmlNode.ChildNodes;
                    int i = 0;
                    foreach (XmlNode imageIndex in imageList)
                    {
                        XmlNodeList nodeList = imageIndex.ChildNodes;
                        int j = 0;
                        foreach (XmlNode data in nodeList)
                        {
                            object_corner[i][j].x = Convert.ToSingle(data.ChildNodes[0].InnerText);
                            object_corner[i][j].y = Convert.ToSingle(data.ChildNodes[1].InnerText);
                            object_corner[i][j].z = Convert.ToSingle(data.ChildNodes[2].InnerText);
                            corner_count[i][j].X = Convert.ToSingle(data.ChildNodes[3].InnerText);
                            corner_count[i][j].Y = Convert.ToSingle(data.ChildNodes[4].InnerText);

                            j++;
                        }
                        i++;
                    }
                    MessageBox.Show("Load Corners successful.");
                }
                reader.Close();

                isCorners = true;

                Start_Calibrate.Enabled = true;
                Exit_Calibrate.Enabled = true;
            }
            else
                MessageBox.Show("Please Input ChessBoard Params");
        }

        /// <summary>
        /// mapping matrix
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rectify_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            XmlReader reader;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.xml|*.xml";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                string str = dlg.FileName.Trim();
                reader = XmlReader.Create(str, settings);
                doc.Load(reader);
            }
            else
                return;

            //root node
            XmlNode xmlNode = doc.SelectSingleNode("opencv_storage");
            //chile node
            XmlNodeList xmlList = xmlNode.ChildNodes;
            foreach (XmlNode xmlnode in xmlList)
            {
                XmlNodeList xn = xmlnode.ChildNodes;
                //intrinsic and distortion param
                if ("matrix_left" == xmlnode.Name)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        intrinsicParam.IntrinsicMatrix[i / 3, i % 3] = Convert.ToDouble(xn.Item(i).InnerText);
                    }
                }
                else if ("distortion_left" == xmlnode.Name)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        intrinsicParam.DistortionCoeffs[i, 0] = Convert.ToDouble(xn.Item(i).InnerText);
                    }
                }
            }

            CvInvoke.cvInitUndistortMap(intrinsicParam.IntrinsicMatrix, intrinsicParam.DistortionCoeffs,
                mapx, mapy);

            isCalibrating = true;
            isCalibrated = true;

            SetText(textBox1, intrinsicParam.IntrinsicMatrix[0, 0].ToString());
            SetText(textBox2, intrinsicParam.IntrinsicMatrix[1, 1].ToString());
            SetText(textBox3, intrinsicParam.IntrinsicMatrix[0, 2].ToString());
            SetText(textBox4, intrinsicParam.IntrinsicMatrix[1, 2].ToString());

            SetText(textBox5, intrinsicParam.DistortionCoeffs[0, 0].ToString());
            SetText(textBox6, intrinsicParam.DistortionCoeffs[1, 0].ToString());
            SetText(textBox7, intrinsicParam.DistortionCoeffs[4, 0].ToString());
            SetText(textBox8, intrinsicParam.DistortionCoeffs[2, 0].ToString());
            SetText(textBox9, intrinsicParam.DistortionCoeffs[3, 0].ToString());
        }
    }
}

