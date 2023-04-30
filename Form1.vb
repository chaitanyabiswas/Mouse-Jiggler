Imports System.Threading
Imports System.Timers
Imports Microsoft.VisualBasic.Devices
Imports Timer = System.Timers.Timer
Imports System.Diagnostics
Imports System.ComponentModel

Public Class MouseForm
    Public MouseOn As Boolean = False
    Private Declare Function SetCursorPos Lib "user32" (ByVal x As Long, ByVal y As Long) As Long

    Public TimeLabelValue As Integer
    Private Sub EnbCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles EnbCheckBox.CheckedChanged

        If EnbCheckBox.Checked Then
            TimeTrackBar.Enabled = True
            TimeLabel.Enabled = True
            TimeLabelValue = (TimeTrackBar.Value + 1) * 6
            Call BWOne.RunWorkerAsync()
            'Dim newThrade As New Thread(New ThreadStart(AddressOf MonuseJuggling))
            'newThrade.Start()
        Else
            TimeTrackBar.Enabled = False
            TimeLabel.Enabled = False

        End If
    End Sub

    Private Sub MouseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TimeLabelValue = (TimeTrackBar.Value + 1) * 6
        EnbCheckBox.Checked = False
        TimeTrackBar.Enabled = False
        NotifyIcon1.Visible = False

    End Sub

    Private Sub TimeTrackBar_Scroll(sender As Object, e As EventArgs) Handles TimeTrackBar.Scroll
        Dim Textvalue As String
        TimeLabelValue = (TimeTrackBar.Value + 1) * 6
        Textvalue = IIf(TimeLabelValue = 60, "1 Minute", TimeLabelValue & " Second")
        TimeLabel.Text = Textvalue
    End Sub

    Private Sub MonuseJuggling()
        Dim x As Long
        Dim y As Long

        ' Get current cursor position
        Do While EnbCheckBox.Checked
            Threading.Thread.Sleep(TimeLabelValue * 1000)


            x = MousePosition.X
            y = MousePosition.Y

            ' Move cursor 1 pixels to the right
            x += 1

            ' Set new cursor position
            SetCursorPos(x, y)
            Threading.Thread.Sleep(50)
            x -= 1
            SetCursorPos(x, y)

        Loop

    End Sub

    Private Sub BWOne_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWOne.DoWork
        Call MonuseJuggling()
    End Sub


    Private Sub MouseForm_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            Me.Hide()
            NotifyIcon1.ShowBalloonTip(60, "Mouse", "Running in background", ToolTipIcon.Info)
        End If
    End Sub


    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        NotifyIcon1.Visible = False
        Me.Show()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub MouseForm_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        BWOne.Dispose()
    End Sub
End Class
