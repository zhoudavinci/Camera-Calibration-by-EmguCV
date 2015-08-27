namespace Camera_Calibration_EmguCV
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radio_local = new System.Windows.Forms.RadioButton();
            this.radio_camera = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.Image_Count = new System.Windows.Forms.TextBox();
            this.Square_Size = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Corners_Ny = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Corners_Nx = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Start_Calibrate = new System.Windows.Forms.Button();
            this.Exit_Calibrate = new System.Windows.Forms.Button();
            this.Rectify = new System.Windows.Forms.Button();
            this.Read_Corners = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(0, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 130);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intrinisic Params";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(148, 95);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(60, 21);
            this.textBox9.TabIndex = 35;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(36, 95);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(60, 21);
            this.textBox8.TabIndex = 34;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(158, 68);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(50, 21);
            this.textBox7.TabIndex = 33;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(99, 68);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(50, 21);
            this.textBox6.TabIndex = 32;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(36, 68);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(50, 21);
            this.textBox5.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "p:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "k:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 29;
            this.label4.Text = "cy:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(36, 41);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(60, 21);
            this.textBox3.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "cx:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(148, 41);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(60, 21);
            this.textBox4.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "fy:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(148, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(60, 21);
            this.textBox2.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "fx:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(36, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 21);
            this.textBox1.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.Image_Count);
            this.groupBox2.Controls.Add(this.Square_Size);
            this.groupBox2.Controls.Add(this.textBox12);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(232, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 130);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ChessBoard Params";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radio_local);
            this.groupBox4.Controls.Add(this.radio_camera);
            this.groupBox4.Location = new System.Drawing.Point(6, 95);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(156, 34);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Source";
            // 
            // radio_local
            // 
            this.radio_local.AutoSize = true;
            this.radio_local.Location = new System.Drawing.Point(88, 12);
            this.radio_local.Name = "radio_local";
            this.radio_local.Size = new System.Drawing.Size(53, 16);
            this.radio_local.TabIndex = 0;
            this.radio_local.TabStop = true;
            this.radio_local.Text = "local";
            this.radio_local.UseVisualStyleBackColor = true;
            // 
            // radio_camera
            // 
            this.radio_camera.AutoSize = true;
            this.radio_camera.Location = new System.Drawing.Point(16, 12);
            this.radio_camera.Name = "radio_camera";
            this.radio_camera.Size = new System.Drawing.Size(59, 16);
            this.radio_camera.TabIndex = 0;
            this.radio_camera.TabStop = true;
            this.radio_camera.Text = "camera";
            this.radio_camera.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "Images:";
            // 
            // Image_Count
            // 
            this.Image_Count.Location = new System.Drawing.Point(90, 76);
            this.Image_Count.Name = "Image_Count";
            this.Image_Count.Size = new System.Drawing.Size(40, 21);
            this.Image_Count.TabIndex = 2;
            // 
            // Square_Size
            // 
            this.Square_Size.Location = new System.Drawing.Point(90, 52);
            this.Square_Size.Name = "Square_Size";
            this.Square_Size.Size = new System.Drawing.Size(40, 21);
            this.Square_Size.TabIndex = 2;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(90, 54);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(40, 21);
            this.textBox12.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "Square Size:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Corners_Ny);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.Corners_Nx);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(6, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(157, 37);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Number of Corners";
            // 
            // Corners_Ny
            // 
            this.Corners_Ny.Location = new System.Drawing.Point(111, 14);
            this.Corners_Ny.Name = "Corners_Ny";
            this.Corners_Ny.Size = new System.Drawing.Size(40, 21);
            this.Corners_Ny.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ny:";
            // 
            // Corners_Nx
            // 
            this.Corners_Nx.Location = new System.Drawing.Point(35, 14);
            this.Corners_Nx.Name = "Corners_Nx";
            this.Corners_Nx.Size = new System.Drawing.Size(40, 21);
            this.Corners_Nx.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nx:";
            // 
            // Start_Calibrate
            // 
            this.Start_Calibrate.Location = new System.Drawing.Point(326, 90);
            this.Start_Calibrate.Name = "Start_Calibrate";
            this.Start_Calibrate.Size = new System.Drawing.Size(75, 35);
            this.Start_Calibrate.TabIndex = 7;
            this.Start_Calibrate.Text = "Start Calibrate";
            this.Start_Calibrate.UseVisualStyleBackColor = true;
            this.Start_Calibrate.Click += new System.EventHandler(this.Start_Calibrate_Click);
            // 
            // Exit_Calibrate
            // 
            this.Exit_Calibrate.Location = new System.Drawing.Point(326, 134);
            this.Exit_Calibrate.Name = "Exit_Calibrate";
            this.Exit_Calibrate.Size = new System.Drawing.Size(75, 35);
            this.Exit_Calibrate.TabIndex = 8;
            this.Exit_Calibrate.Text = "Exit Calibrate";
            this.Exit_Calibrate.UseVisualStyleBackColor = true;
            this.Exit_Calibrate.Click += new System.EventHandler(this.Exit_Calibrate_Click);
            // 
            // Rectify
            // 
            this.Rectify.Location = new System.Drawing.Point(326, 178);
            this.Rectify.Name = "Rectify";
            this.Rectify.Size = new System.Drawing.Size(75, 30);
            this.Rectify.TabIndex = 9;
            this.Rectify.Text = "Rectify";
            this.Rectify.UseVisualStyleBackColor = true;
            this.Rectify.Click += new System.EventHandler(this.Rectify_Click);
            // 
            // Read_Corners
            // 
            this.Read_Corners.Location = new System.Drawing.Point(326, 46);
            this.Read_Corners.Name = "Read_Corners";
            this.Read_Corners.Size = new System.Drawing.Size(75, 35);
            this.Read_Corners.TabIndex = 10;
            this.Read_Corners.Text = "Read Corners";
            this.Read_Corners.UseVisualStyleBackColor = true;
            this.Read_Corners.Click += new System.EventHandler(this.Read_Corners_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(326, 217);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 30);
            this.Exit.TabIndex = 11;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 379);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Read_Corners);
            this.Controls.Add(this.Rectify);
            this.Controls.Add(this.Exit_Calibrate);
            this.Controls.Add(this.Start_Calibrate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camera Calibration";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radio_local;
        private System.Windows.Forms.RadioButton radio_camera;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Image_Count;
        private System.Windows.Forms.TextBox Square_Size;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Corners_Ny;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Corners_Nx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Start_Calibrate;
        private System.Windows.Forms.Button Exit_Calibrate;
        private System.Windows.Forms.Button Rectify;
        private System.Windows.Forms.Button Read_Corners;
        private System.Windows.Forms.Button Exit;
    }
}

