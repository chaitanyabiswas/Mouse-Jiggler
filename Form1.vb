Imports System.Threading
Imports System.Timers
Imports Microsoft.VisualBasic.Devices
Imports Timer = System.Timers.Timer
Imports System.Diagnostics
Imports System.ComponentModel

Public Class MouseForm
    Public MouseOn As Boolean = False
    Private Declare Function SetCursorPos Lib "user32" (ByVal x As Long, ByVal y As Long) As Long
    Private Declare Function SetThreadExecutionState Lib "kernel32" (ByVal esFlags As UInteger) As UInteger

    ' Execution state flags
    Private Const ES_CONTINUOUS As UInteger = &H80000000UI
    Private Const ES_SYSTEM_REQUIRED As UInteger = &H1UI
    Private Const ES_DISPLAY_REQUIRED As UInteger = &H2UI

    Public TimeLabelValue As Integer
    Private Sub EnbCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles EnbCheckBox.CheckedChanged
        If EnbCheckBox.Checked Then
            TimeTrackBar.Enabled = True
            TimeLabel.Enabled = True
            TimeLabelValue = (TimeTrackBar.Value + 1) * 6
            ' Prevent system from sleeping
            SetThreadExecutionState(ES_CONTINUOUS Or ES_SYSTEM_REQUIRED Or ES_DISPLAY_REQUIRED)
            ' Only start the BackgroundWorker if it's not already running
            If Not BWOne.IsBusy Then
                Call BWOne.RunWorkerAsync()
            End If

        Else
            TimeTrackBar.Enabled = False
            TimeLabel.Enabled = False
            ' Allow system to sleep again
            SetThreadExecutionState(ES_CONTINUOUS)
            ' If the worker is running, request cancellation so it can stop promptly
            If BWOne.IsBusy AndAlso BWOne.WorkerSupportsCancellation Then
                BWOne.CancelAsync()
            End If

        End If
    End Sub

    Private Sub MouseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TimeLabelValue = (TimeTrackBar.Value + 1) * 6
        EnbCheckBox.Checked = False
        TimeTrackBar.Enabled = False
        NotifyIcon1.Visible = False
        ' Enable cancellation support so we can stop the background worker on demand
        BWOne.WorkerSupportsCancellation = True

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
        Do While EnbCheckBox.Checked AndAlso Not BWOne.CancellationPending
            Threading.Thread.Sleep(TimeLabelValue * 1000)

            ' If cancellation was requested while sleeping, exit early
            If BWOne.CancellationPending Then Exit Do

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
        ' Reset execution state to allow system to sleep
        SetThreadExecutionState(ES_CONTINUOUS)
        ' If the worker is running, request cancellation before disposing
        If BWOne IsNot Nothing Then
            If BWOne.IsBusy AndAlso BWOne.WorkerSupportsCancellation Then
                BWOne.CancelAsync()
            End If
            BWOne.Dispose()
        End If
    End Sub
End Class
