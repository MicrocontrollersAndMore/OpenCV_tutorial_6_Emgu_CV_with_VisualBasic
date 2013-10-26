Option Strict

Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports Emgu.CV.Structure
Imports Emgu.CV.UI

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Public Class Form1

' member variables ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Dim capWebcam As Capture
Dim blnCapturingInProcess As Boolean = False
Dim imgOriginal As Image(Of Bgr, Byte)
Dim imgProcessed As Image(Of Gray, Byte)

' constructor '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Sub New()
	InitializeComponent
End Sub

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Private Sub Form1_Load( sender As System.Object,  e As System.EventArgs) Handles MyBase.Load
	Try
		capWebcam = New Capture()							'associate the capture object to the default webcam
	Catch ex As Exception										'catch error if unsuccessful
		txtXYRadius.Text = ex.Message					'show error message in text box
		Return																'and bail
	End Try

	AddHandler Application.Idle, New EventHandler(AddressOf Me.ProcessFrameAndUpdateGUI)		'add process image function to the application's list of tasks
	blnCapturingInProcess = True
End Sub

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Private Sub Form1_FormClosed( sender As System.Object,  e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
	If(Not capWebcam Is Nothing) Then
		capWebcam.Dispose()
	End If
End Sub

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Sub ProcessFrameAndUpdateGUI(sender As Object, arg As EventArgs)
	imgOriginal = capWebcam.QueryFrame()								'get next frame from the webcam
	If(imgOriginal Is Nothing)													'if we did not get a frame
		Return																						'bail
	End If
																		'min filter value (if color is greater than or equal to this)
																												'max filter value (if color is less than or equal to this)
	imgProcessed = imgOriginal.InRange(New Bgr(0, 0, 175), New Bgr(100, 100, 256))

	imgProcessed = imgProcessed.SmoothGaussian(9)					'we call SmoothGaussian with only one param, the x and y size of the filter window

																											'Canny threshold
																																		 'accumulator threshold
																																									 'size of image / this param = "accumulator resolution"
																																											'min distance in pixels between the centers of the detected circles
																																																							 'min radius of detected circle
																																																									 'max radius of detected circle
																																																												'get circles from the first channel
	Dim circles As CircleF() = imgProcessed.HoughCircles(New Gray(100), New Gray(50), 2, imgProcessed.Height / 4, 10, 400)(0)

	For Each CircleF In circles
		If(txtXYRadius.Text <> "") Then										'if we are not on the first line in the text box
			txtXYRadius.AppendText(Environment.NewLine)			'then insert a new line char
		End If
													 'x position of center point of circle
																																													'y position of center point of circle
																																																																						 'radius of circle
		txtXYRadius.AppendText("ball position x =" + CircleF.Center.X.ToString().PadLeft(4) + ", y =" + CircleF.Center.Y.ToString().PadLeft(4) + ", radius =" + CircleF.Radius.ToString("###.000").PadLeft(7))
		txtXYRadius.ScrollToCaret()

						'Draw a small green circle at the center of the detected object. To do this, we will call the OpenCV 1.x function, this is necessary
						'b/c we are drawing a circle of radius 3, even though the size of the detected circle will be much bigger.
						'The CvInvoke object can be used to make OpenCV 1.x function calls
										 'draw on the original image
																	'center point of circle
																																														 'radius of circle in pixels
																																																'draw pure green
																																																													'thickness of circle in pixels, -1 indicates to fill the circle
																																																															'use AA to smooth the pixels
																																																																							 'no shift
		CvInvoke.cvCircle(imgOriginal, New Point(CInt(CircleF.Center.X), CInt(CircleF.Center.Y)), 3, New MCvScalar(0, 255, 0), -1, LINE_TYPE.CV_AA, 0)

		'draw a red circle around the detected object
										'current circle we are on in For Each loop
														 'draw pure red
																								 'thickness of circle in pixles
		imgOriginal.Draw(CircleF, New Bgr(Color.Red), 3)
	Next
	
	ibOriginal.Image = imgOriginal
	ibProcessed.Image = imgProcessed
	
End Sub

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Private Sub btnPauseOrResume_Click( sender As System.Object,  e As System.EventArgs) Handles btnPauseOrResume.Click
	If(blnCapturingInProcess = True) Then																								'if we are currently processing an image, user just choose pause, so . . .
		RemoveHandler Application.Idle, New EventHandler(AddressOf Me.ProcessFrameAndUpdateGUI)		'remove the process image function from the application's list of tasks
		blnCapturingInProcess = False																															'update flag variable
		btnPauseOrResume.Text = "resume"																													'update button text
	Else																																								'else if we are not currently processing an image, user just choose resume, so . . .
		AddHandler Application.Idle, New EventHandler(AddressOf Me.ProcessFrameAndUpdateGUI)			'add the process image function to the application's list of tasks
		blnCapturingInProcess = True																															'update flag variable
		btnPauseOrResume.Text = "pause"																														'new button will offer pause option
	End If
End Sub

End Class
