<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MouseForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(MouseForm))
        EnbCheckBox = New CheckBox()
        TimeTrackBar = New TrackBar()
        TimeLabel = New Label()
        BWOne = New ComponentModel.BackgroundWorker()
        NotifyIcon1 = New NotifyIcon(components)
        CType(TimeTrackBar, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' EnbCheckBox
        ' 
        resources.ApplyResources(EnbCheckBox, "EnbCheckBox")
        EnbCheckBox.Name = "EnbCheckBox"
        EnbCheckBox.UseVisualStyleBackColor = True
        ' 
        ' TimeTrackBar
        ' 
        TimeTrackBar.LargeChange = 1
        resources.ApplyResources(TimeTrackBar, "TimeTrackBar")
        TimeTrackBar.Maximum = 9
        TimeTrackBar.Name = "TimeTrackBar"
        ' 
        ' TimeLabel
        ' 
        resources.ApplyResources(TimeLabel, "TimeLabel")
        TimeLabel.Name = "TimeLabel"
        ' 
        ' BWOne
        ' 
        ' 
        ' NotifyIcon1
        ' 
        resources.ApplyResources(NotifyIcon1, "NotifyIcon1")
        ' 
        ' MouseForm
        ' 
        resources.ApplyResources(Me, "$this")
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(TimeLabel)
        Controls.Add(TimeTrackBar)
        Controls.Add(EnbCheckBox)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "MouseForm"
        CType(TimeTrackBar, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents EnbCheckBox As CheckBox
    Friend WithEvents TimeTrackBar As TrackBar
    Friend WithEvents TimeLabel As Label
    Friend WithEvents BWOne As System.ComponentModel.BackgroundWorker
    Friend WithEvents NotifyIcon1 As NotifyIcon
End Class
