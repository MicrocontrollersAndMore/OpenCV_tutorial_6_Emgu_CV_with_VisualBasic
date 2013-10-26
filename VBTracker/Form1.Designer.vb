<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.ibOriginal = New Emgu.CV.UI.ImageBox()
		Me.ibProcessed = New Emgu.CV.UI.ImageBox()
		Me.btnPauseOrResume = New System.Windows.Forms.Button()
		Me.txtXYRadius = New System.Windows.Forms.TextBox()
		CType(Me.ibOriginal,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.ibProcessed,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'ibOriginal
		'
		Me.ibOriginal.Location = New System.Drawing.Point(0, 0)
		Me.ibOriginal.Name = "ibOriginal"
		Me.ibOriginal.Size = New System.Drawing.Size(640, 480)
		Me.ibOriginal.TabIndex = 2
		Me.ibOriginal.TabStop = false
		'
		'ibProcessed
		'
		Me.ibProcessed.Location = New System.Drawing.Point(644, 0)
		Me.ibProcessed.Name = "ibProcessed"
		Me.ibProcessed.Size = New System.Drawing.Size(640, 480)
		Me.ibProcessed.TabIndex = 2
		Me.ibProcessed.TabStop = false
		'
		'btnPauseOrResume
		'
		Me.btnPauseOrResume.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.btnPauseOrResume.Location = New System.Drawing.Point(100, 496)
		Me.btnPauseOrResume.Name = "btnPauseOrResume"
		Me.btnPauseOrResume.Size = New System.Drawing.Size(132, 40)
		Me.btnPauseOrResume.TabIndex = 3
		Me.btnPauseOrResume.Text = "pause"
		Me.btnPauseOrResume.UseVisualStyleBackColor = true
		'
		'txtXYRadius
		'
		Me.txtXYRadius.Font = New System.Drawing.Font("Courier New", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.txtXYRadius.Location = New System.Drawing.Point(292, 484)
		Me.txtXYRadius.Multiline = true
		Me.txtXYRadius.Name = "txtXYRadius"
		Me.txtXYRadius.ReadOnly = true
		Me.txtXYRadius.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtXYRadius.Size = New System.Drawing.Size(992, 224)
		Me.txtXYRadius.TabIndex = 4
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1286, 709)
		Me.Controls.Add(Me.txtXYRadius)
		Me.Controls.Add(Me.btnPauseOrResume)
		Me.Controls.Add(Me.ibProcessed)
		Me.Controls.Add(Me.ibOriginal)
		Me.Name = "Form1"
		Me.Text = "Form1"
		CType(Me.ibOriginal,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.ibProcessed,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
    Friend WithEvents ibOriginal As Emgu.CV.UI.ImageBox
    Friend WithEvents ibProcessed As Emgu.CV.UI.ImageBox
    Friend WithEvents btnPauseOrResume As System.Windows.Forms.Button
    Friend WithEvents txtXYRadius As System.Windows.Forms.TextBox

End Class
