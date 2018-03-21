'-----------------------------------------------------------------------------------------------------------------------------------------------
'
'	This program is free software; you can redistribute it and/or
'	modify it under the terms of the GNU General Public License
'	as published by the Free Software Foundation; either version 2
'	of the License, or (at your option) any later version.
'
'	This program is distributed in the hope that it will be useful,
'	but WITHOUT ANY WARRANTY; without even the implied warranty of
'	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'	GNU General Public License for more details.
'
'	You should have received a copy of the GNU General Public License
'	along with this program; if not, write to the Free Software Foundation,
'	Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
'
'	Name :
'				Zzz...
'	Author :
'				▄▄▄▄▄▄▄  ▄ ▄▄ ▄▄▄▄▄▄▄
'				█ ▄▄▄ █ ██ ▀▄ █ ▄▄▄ █
'				█ ███ █ ▄▀ ▀▄ █ ███ █
'				█▄▄▄▄▄█ █ ▄▀█ █▄▄▄▄▄█
'				▄▄ ▄  ▄▄▀██▀▀ ▄▄▄ ▄▄
'				 ▀█▄█▄▄▄█▀▀ ▄▄▀█ █▄▀█
'				 █ █▀▄▄▄▀██▀▄ █▄▄█ ▀█
'				▄▄▄▄▄▄▄ █▄█▀ ▄ ██ ▄█
'				█ ▄▄▄ █  █▀█▀ ▄▀▀  ▄▀
'				█ ███ █ ▀▄  ▄▀▀▄▄▀█▀█
'				█▄▄▄▄▄█ ███▀▄▀ ▀██ ▄
'
'-----------------------------------------------------------------------------------------------------------------------------------------------

'Dependencies :
' - Microsoft.WindowsAPICodePack.dll
' - Microsoft.WindowsAPICodePack.Shell.dll
Imports Microsoft.WindowsAPICodePack.Taskbar

Public Class MainForm

    'Keyboard events simulation
    Private Declare Sub keybd_event Lib "user32" (ByVal K As Byte, ByVal Bsc As Byte, ByVal WParam As Integer, ByVal LParam As Integer)
    'Retrieves a handle to an icon from the specified executable file, DLL, or icon file
    Private Declare Function ExtractIcon Lib "shell32.dll" Alias "ExtractIconExA" (ByVal lpszFile As String, ByVal nIconIndex As Int32, ByRef phiconLarge As IntPtr, ByRef phiconSmall As IntPtr, ByVal nIcons As Int32) As Int32

    'Public variables
    Public dtEnd As DateTime
    Public dtStart As DateTime
    Public estimateTimer As New Timer
    Public countdownTimer As New Timer
    Public menuShow As New ToolStripMenuItem
    Public menuExit As New ToolStripMenuItem
    Public menuAbout As New ToolStripMenuItem

    'Main Form loading event
    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Form title : application name + version
        Me.Text = My.Application.Info.AssemblyName & " - v" & My.Application.Info.Version.ToString

        'Add 3 ToolStripMenuItems to the ContextMenuStrip :
        ' - Show
        ' - About
        ' - Exit
        menuShow.Text = "Show"
        menuExit.Text = "Exit"
        menuAbout.Text = "About"
        'Icons extracted from imageres.dll
        Dim icoLarge As IntPtr
        Dim icoSmall As IntPtr
        Dim sFile As String = ("%SystemRoot%\system32\imageres.dll")
        Call ExtractIcon(sFile, 95, icoLarge, icoSmall, 1)
        menuShow.Image = Icon.FromHandle(icoSmall).ToBitmap
        Call ExtractIcon(sFile, 84, icoLarge, icoSmall, 1)
        menuExit.Image = Icon.FromHandle(icoSmall).ToBitmap
        Call ExtractIcon(sFile, 76, icoLarge, icoSmall, 1)
        menuAbout.Image = Icon.FromHandle(icoSmall).ToBitmap
        contextMenuStripMain.Items.Add(menuShow)
        contextMenuStripMain.Items.Add(New ToolStripSeparator())
        contextMenuStripMain.Items.Add(menuAbout)
        contextMenuStripMain.Items.Add(New ToolStripSeparator())
        contextMenuStripMain.Items.Add(menuExit)
        'Show main Form on click event for "Show" menu item
        AddHandler menuShow.Click, AddressOf showApp
        'Close main Form on click event for "Exit" menu item
        AddHandler menuExit.Click, AddressOf Me.Close
        'Show "About" Form on click event for "About" menu item
        AddHandler menuAbout.Click, AddressOf cbAbout_Click

        'Add ContextMenuStrip to the NotifyIcon
        notifyIconMain.ContextMenuStrip = contextMenuStripMain

        'Countdown timer
        countdownTimer.Interval = 500
        AddHandler countdownTimer.Tick, AddressOf countdownOperation

        'Update the estimated date/time with a timer
        estimateTimer.Interval = 1000
        AddHandler estimateTimer.Tick, AddressOf computeEstimatedDate
        estimateTimer.Start()
    End Sub

    'When using days, hours, minutes or seconds NumericUpDown :
    ' - modify the TrackBar position
    ' - update the estimated date/time
    Private Sub computeEstimatedDate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudDay.ValueChanged, nudHour.ValueChanged, nudMinute.ValueChanged, nudSecond.ValueChanged
        'If the countdown timer is not running
        If estimateTimer.Enabled Then
            Me.Text = My.Application.Info.AssemblyName & " - " & DateTime.Now.AddSeconds(nudSecond.Value + (nudMinute.Value * 60) + (nudHour.Value * 60 * 60) + (nudDay.Value * 24 * 60 * 60)).ToString("dd/MM/yyyy\, HH\:mm\:ss")
        End If
        'If the TrackBar control is not focused, we can modify it
        If Not trackBarSeconds Is Me.ActiveControl Then
            Dim iSeconds = nudSecond.Value + nudMinute.Value * 60 + nudHour.Value * 3600
            If iSeconds <= trackBarSeconds.Maximum Then
                trackBarSeconds.Value = CInt(iSeconds)
            Else
                trackBarSeconds.Value = trackBarSeconds.Maximum
            End If
        End If
    End Sub

    'When using the TrackBar control, update days, hours, minutes or seconds NumericUpDowns
    Private Sub TrackBarSeconds_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackBarSeconds.Scroll
        nudHour.Value = trackBarSeconds.Value \ 3600
        nudMinute.Value = (CLng(trackBarSeconds.Value) - (CLng(nudHour.Value) * 3600)) \ 60
        nudSecond.Value = (trackBarSeconds.Value - (nudHour.Value * 3600) - (nudMinute.Value * 60))
    End Sub

    'If "Stop" button is clicked :
    ' - stop countdown timer
    ' - unlock main Form controls
    ' - update the estimated date/time with a timer
    ' - remove the estimated date/time from the NotifyIcon hover text
    Private Sub cbStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbStop.Click
        countdownTimer.Stop()
        Call unlockUI()
        estimateTimer.Start()
        notifyIconMain.Text = My.Application.Info.ProductName
    End Sub

    'If "?" button is clicked, show the "About" Form
    Private Sub cbAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAbout.Click
        ABOUT.Show()
    End Sub

    'If "Start" button is clicked :
    ' - don't update the estimated date/time anymore
    ' - lock main Form controls
    ' - start countdown timer
    Private Sub cbStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbStart.Click
        'Get days, hours, minutes and seconds from NumericUpDowns
        Dim lDays As Long = CLng(nudDay.Value)
        Dim lHours As Long = CLng(nudHour.Value)
        Dim lMinutes As Long = CLng(nudMinute.Value)
        Dim lSeconds As Long = CLng(nudSecond.Value)

        'Now
        dtStart = DateTime.Now
        'Now + time from NumericUpDowns
        dtEnd = dtStart.AddSeconds(lSeconds + (lMinutes * 60) + (lHours * 60 * 60) + (lDays * 24 * 60 * 60))

        'Don't update the estimated date/time anymore
        estimateTimer.Stop()

        'Lock main Form controls
        Try
            Call lockUI()
        Catch ex As Exception
            'Check for WindowsAPICodePack .dll files :
            ' - Microsoft.WindowsAPICodePack.dll
            ' - Microsoft.WindowsAPICodePack.Shell.dll
            MsgBox("Can't find WindowsAPICodePack libraries !", vbCritical, "Missing .dll files")
            Exit Sub
        End Try

        'Update the estimated date/time in :
        ' - main Form
        ' - NotifyIcon hover text
        Me.Text = My.Application.Info.AssemblyName & " - " & dtEnd.ToString("dd/MM/yyyy\, HH\:mm\:ss")
        notifyIconMain.Text = My.Application.Info.ProductName & vbNewLine & dtEnd.ToString("dd/MM/yyyy\, HH\:mm\:ss")

        'Start countdown timer
        countdownTimer.Start()
    End Sub

    'When countdown timer is running
    Private Sub countdownOperation()
        'Until time has passed
        Dim diffTime As System.TimeSpan
        diffTime = dtEnd.Subtract(DateTime.Now)
        If (diffTime.TotalMilliseconds) > 500 Then
            'Keep computer awake
            If cbLock.Checked Then
                'Press `Ctrl` key
                keybd_event(&HA3, &H45S, &H1S Or 0, 0)
                'Release `Ctrl` key
                keybd_event(&HA3, &H45S, &H1S Or &H2S, 0)
            End If
            'Update NumericUpDowns
            nudDay.Value = diffTime.Days
            nudHour.Value = diffTime.Hours
            nudMinute.Value = diffTime.Minutes
            nudSecond.Value = diffTime.Seconds
            'Update ProgressBar and TaskBar completion
            Dim iPercentage = 100 - 100 * diffTime.TotalMilliseconds / dtEnd.Subtract(dtStart).TotalMilliseconds
            If iPercentage <= 100 Then
                progressBarCompletion.Value = CInt(iPercentage)
                TaskbarManager.Instance.SetProgressValue(CInt(iPercentage), 100)
            End If
        Else
            'Reset NumericUpDowns
            nudSecond.Value = 0
            'Stop countdown timer
            countdownTimer.Stop()
            'Unlock main Form controls
            Call unlockUI()
            'Shutdown, reboot, log off or hibernate computer
            If rbShutdown.Checked Then
                Call shutdown()
                notifyIconMain.BalloonTipText = "Click here to cancel computer " & rbShutdown.Text.ToLower & "."
            ElseIf rbReboot.Checked Then
                Call reboot()
                notifyIconMain.BalloonTipText = "Click here to cancel computer " & rbReboot.Text.ToLower & "."
            ElseIf rbLogOff.Checked Then
                Call logOff()
            ElseIf rbSleep.Checked Then
                Call hibernate()
            End If
            'Update the estimated date/time with a timer
            estimateTimer.Start()
            'Abort system shutdown if notification from NotifyIcon is clicked
            If rbShutdown.Checked Or rbReboot.Checked Then
                notifyIconMain.BalloonTipIcon = ToolTipIcon.Warning
                notifyIconMain.BalloonTipTitle = My.Application.Info.ProductName
                notifyIconMain.ShowBalloonTip(1000)
            End If
        End If
    End Sub

    'Lock main Form controls
    Private Sub lockUI()
        progressBarCompletion.Value = 0
        TaskbarManager.Instance.SetProgressValue(0, 100)
        nudDay.Enabled = False
        nudHour.Enabled = False
        nudMinute.Enabled = False
        nudSecond.Enabled = False
        trackBarSeconds.Enabled = False
        cbStart.Enabled = False
        cbStop.Enabled = True
    End Sub

    'Unlock main Form controls
    Private Sub unlockUI()
        progressBarCompletion.Value = 100
        TaskbarManager.Instance.SetProgressValue(100, 100)
        nudDay.Enabled = True
        nudHour.Enabled = True
        nudMinute.Enabled = True
        nudSecond.Enabled = True
        trackBarSeconds.Enabled = True
        cbStart.Enabled = True
        cbStop.Enabled = False
    End Sub

    'When main Form is minimized, hide it and show a notification popup
    Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            notifyIconMain.BalloonTipIcon = ToolTipIcon.Info
            notifyIconMain.BalloonTipTitle = My.Application.Info.ProductName
            notifyIconMain.BalloonTipText = "Minimized to the notification area"
            notifyIconMain.ShowBalloonTip(250)
            'If "About" Form is visible, hide it
            ABOUT.Hide()
        End If
    End Sub

    'When NotifyIcon is clicked, hide or show main Form
    Private Sub NotifyIconMain_MouseUpk(ByVal sender As Object, ByVal e As MouseEventArgs) Handles notifyIconMain.MouseUp
        'Only when left-clicked
        'Right click is for ContextMenuStrip
        If (e.Button = MouseButtons.Left) Then
            If Me.Visible Then
                Me.Hide()
                ABOUT.Hide()
            Else
                Call showApp()
            End If
        End If
    End Sub

    Private Sub showApp()
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        'Hotfix for `Me.BringToFront`
        Me.TopMost = True
        Me.TopMost = False
    End Sub

    'When main Form is closed, destroy its NotifyIcon
    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call exitApp()
    End Sub

    Private Sub exitApp()
        notifyIconMain.Visible = False
        notifyIconMain.Icon = Nothing
        notifyIconMain.Dispose()
    End Sub

    'When notification from NotifyIcon is clicked, abort shutdown / reboot or show main Form
    Private Sub notifyIconMain_BalloonTipClicked(ByVal sender As Object, ByVal e As EventArgs) Handles notifyIconMain.BalloonTipClicked
        If (notifyIconMain.BalloonTipIcon = ToolTipIcon.Warning) Then
            Call cancelShutdown()
        Else
            Call showApp()
        End If
    End Sub

    'RadioButtons that can be unchecked, like CheckBoxes
    Private Sub rb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbReboot.Click, rbLogOff.Click, rbShutdown.Click, rbSleep.Click
        If CBool(sender.Checked) Then
            sender.Checked = False
        Else
            sender.Checked = True
            If Not rbShutdown Is sender Then
                rbShutdown.Checked = False
            End If
            If Not rbReboot Is sender Then
                rbReboot.Checked = False
            End If
            If Not rbLogOff Is sender Then
                rbLogOff.Checked = False
            End If
            If Not rbSleep Is sender Then
                rbSleep.Checked = False
            End If
        End If
    End Sub

End Class

'If application is already running when started, show main Form
Namespace My
    Partial Friend Class MyApplication
        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            MainForm.Show()
            MainForm.WindowState = FormWindowState.Normal
            MainForm.ShowInTaskbar = True
            'Hotfix for `Me.BringToFront`
            MainForm.TopMost = True
            MainForm.TopMost = False
        End Sub
    End Class
End Namespace
