# Camera-Calibration-by-EmguCV
This repository deals camera calibration by EmguCV on C# platform.

Before calibrating, chess-board parameters should be set, such as the number of corners, the actual size of square and the number of images which used to calibrating.

If there is a corner file with correct format in local, please move it to the Debug direction. Then click Read Corners button, so corners information can be read.

If calibraing on-line, click button Start ---> Start Calibrate, the program has some bugs in detecting corners, which the images captured have some sluggish.

After acquring intrinsic parameters, the button Rectify can realize rectification function.
