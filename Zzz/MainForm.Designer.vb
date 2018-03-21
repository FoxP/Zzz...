<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.nudHour = New System.Windows.Forms.NumericUpDown()
        Me.nudMinute = New System.Windows.Forms.NumericUpDown()
        Me.nudDay = New System.Windows.Forms.NumericUpDown()
        Me.lbDay = New System.Windows.Forms.Label()
        Me.lbHour = New System.Windows.Forms.Label()
        Me.lbMinute = New System.Windows.Forms.Label()
        Me.cbStart = New System.Windows.Forms.Button()
        Me.cbStop = New System.Windows.Forms.Button()
        Me.progressBarCompletion = New System.Windows.Forms.ProgressBar()
        Me.lbSecond = New System.Windows.Forms.Label()
        Me.nudSecond = New System.Windows.Forms.NumericUpDown()
        Me.cbLock = New System.Windows.Forms.CheckBox()
        Me.rbShutdown = New System.Windows.Forms.RadioButton()
        Me.rbSleep = New System.Windows.Forms.RadioButton()
        Me.rbLogOff = New System.Windows.Forms.RadioButton()
        Me.rbReboot = New System.Windows.Forms.RadioButton()
        Me.trackBarSeconds = New System.Windows.Forms.TrackBar()
        Me.cbAbout = New System.Windows.Forms.Button()
        Me.notifyIconMain = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.contextMenuStripMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        CType(Me.nudHour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSecond, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackBarSeconds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nudHour
        '
        Me.nudHour.Location = New System.Drawing.Point(160, 31)
        Me.nudHour.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.nudHour.Name = "nudHour"
        Me.nudHour.Size = New System.Drawing.Size(50, 20)
        Me.nudHour.TabIndex = 5
        Me.nudHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudMinute
        '
        Me.nudMinute.Location = New System.Drawing.Point(279, 31)
        Me.nudMinute.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudMinute.Name = "nudMinute"
        Me.nudMinute.Size = New System.Drawing.Size(50, 20)
        Me.nudMinute.TabIndex = 7
        Me.nudMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nudDay
        '
        Me.nudDay.Location = New System.Drawing.Point(53, 31)
        Me.nudDay.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.nudDay.Name = "nudDay"
        Me.nudDay.Size = New System.Drawing.Size(50, 20)
        Me.nudDay.TabIndex = 3
        Me.nudDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbDay
        '
        Me.lbDay.AutoSize = True
        Me.lbDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDay.Location = New System.Drawing.Point(7, 32)
        Me.lbDay.Name = "lbDay"
        Me.lbDay.Size = New System.Drawing.Size(40, 15)
        Me.lbDay.TabIndex = 2
        Me.lbDay.Text = "Days :"
        '
        'lbHour
        '
        Me.lbHour.AutoSize = True
        Me.lbHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHour.Location = New System.Drawing.Point(109, 32)
        Me.lbHour.Name = "lbHour"
        Me.lbHour.Size = New System.Drawing.Size(46, 15)
        Me.lbHour.TabIndex = 4
        Me.lbHour.Text = "Hours :"
        '
        'lbMinute
        '
        Me.lbMinute.AutoSize = True
        Me.lbMinute.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMinute.Location = New System.Drawing.Point(216, 31)
        Me.lbMinute.Name = "lbMinute"
        Me.lbMinute.Size = New System.Drawing.Size(57, 15)
        Me.lbMinute.TabIndex = 6
        Me.lbMinute.Text = "Minutes :"
        '
        'cbStart
        '
        Me.cbStart.Location = New System.Drawing.Point(9, 80)
        Me.cbStart.Name = "cbStart"
        Me.cbStart.Size = New System.Drawing.Size(200, 23)
        Me.cbStart.TabIndex = 15
        Me.cbStart.Text = "Start"
        Me.cbStart.UseVisualStyleBackColor = True
        '
        'cbStop
        '
        Me.cbStop.Enabled = False
        Me.cbStop.Location = New System.Drawing.Point(218, 80)
        Me.cbStop.Name = "cbStop"
        Me.cbStop.Size = New System.Drawing.Size(200, 23)
        Me.cbStop.TabIndex = 16
        Me.cbStop.Text = "Stop"
        Me.cbStop.UseVisualStyleBackColor = True
        '
        'progressBarCompletion
        '
        Me.progressBarCompletion.Location = New System.Drawing.Point(-1, 110)
        Me.progressBarCompletion.MarqueeAnimationSpeed = 10
        Me.progressBarCompletion.Name = "progressBarCompletion"
        Me.progressBarCompletion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.progressBarCompletion.Size = New System.Drawing.Size(462, 10)
        Me.progressBarCompletion.Step = 1
        Me.progressBarCompletion.TabIndex = 18
        '
        'lbSecond
        '
        Me.lbSecond.AutoSize = True
        Me.lbSecond.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSecond.Location = New System.Drawing.Point(334, 31)
        Me.lbSecond.Name = "lbSecond"
        Me.lbSecond.Size = New System.Drawing.Size(61, 15)
        Me.lbSecond.TabIndex = 8
        Me.lbSecond.Text = "Seconds :"
        '
        'nudSecond
        '
        Me.nudSecond.Location = New System.Drawing.Point(400, 31)
        Me.nudSecond.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudSecond.Name = "nudSecond"
        Me.nudSecond.Size = New System.Drawing.Size(50, 20)
        Me.nudSecond.TabIndex = 9
        Me.nudSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbLock
        '
        Me.cbLock.AutoSize = True
        Me.cbLock.Location = New System.Drawing.Point(10, 59)
        Me.cbLock.Name = "cbLock"
        Me.cbLock.Size = New System.Drawing.Size(121, 17)
        Me.cbLock.TabIndex = 10
        Me.cbLock.Text = "Prevent screen lock"
        Me.cbLock.UseVisualStyleBackColor = True
        '
        'rbShutdown
        '
        Me.rbShutdown.AutoCheck = False
        Me.rbShutdown.AutoSize = True
        Me.rbShutdown.Location = New System.Drawing.Point(152, 58)
        Me.rbShutdown.Name = "rbShutdown"
        Me.rbShutdown.Size = New System.Drawing.Size(73, 17)
        Me.rbShutdown.TabIndex = 11
        Me.rbShutdown.TabStop = True
        Me.rbShutdown.Text = "Shutdown"
        Me.rbShutdown.UseVisualStyleBackColor = True
        '
        'rbSleep
        '
        Me.rbSleep.AutoCheck = False
        Me.rbSleep.AutoSize = True
        Me.rbSleep.Location = New System.Drawing.Point(247, 58)
        Me.rbSleep.Name = "rbSleep"
        Me.rbSleep.Size = New System.Drawing.Size(52, 17)
        Me.rbSleep.TabIndex = 12
        Me.rbSleep.TabStop = True
        Me.rbSleep.Text = "Sleep"
        Me.rbSleep.UseVisualStyleBackColor = True
        '
        'rbLogOff
        '
        Me.rbLogOff.AutoCheck = False
        Me.rbLogOff.AutoSize = True
        Me.rbLogOff.Location = New System.Drawing.Point(320, 58)
        Me.rbLogOff.Name = "rbLogOff"
        Me.rbLogOff.Size = New System.Drawing.Size(58, 17)
        Me.rbLogOff.TabIndex = 13
        Me.rbLogOff.TabStop = True
        Me.rbLogOff.Text = "Log off"
        Me.rbLogOff.UseVisualStyleBackColor = True
        '
        'rbReboot
        '
        Me.rbReboot.AutoCheck = False
        Me.rbReboot.AutoSize = True
        Me.rbReboot.Location = New System.Drawing.Point(397, 58)
        Me.rbReboot.Name = "rbReboot"
        Me.rbReboot.Size = New System.Drawing.Size(60, 17)
        Me.rbReboot.TabIndex = 14
        Me.rbReboot.TabStop = True
        Me.rbReboot.Text = "Reboot"
        Me.rbReboot.UseVisualStyleBackColor = True
        '
        'trackBarSeconds
        '
        Me.trackBarSeconds.LargeChange = 3600
        Me.trackBarSeconds.Location = New System.Drawing.Point(2, 4)
        Me.trackBarSeconds.Maximum = 86400
        Me.trackBarSeconds.Name = "trackBarSeconds"
        Me.trackBarSeconds.Size = New System.Drawing.Size(456, 45)
        Me.trackBarSeconds.SmallChange = 1800
        Me.trackBarSeconds.TabIndex = 1
        Me.trackBarSeconds.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'cbAbout
        '
        Me.cbAbout.Location = New System.Drawing.Point(427, 80)
        Me.cbAbout.Name = "cbAbout"
        Me.cbAbout.Size = New System.Drawing.Size(24, 23)
        Me.cbAbout.TabIndex = 17
        Me.cbAbout.Text = "?"
        Me.cbAbout.UseVisualStyleBackColor = True
        '
        'notifyIconMain
        '
        Me.notifyIconMain.Icon = CType(resources.GetObject("notifyIconMain.Icon"), System.Drawing.Icon)
        Me.notifyIconMain.Text = "Zzz..."
        Me.notifyIconMain.Visible = True
        '
        'contextMenuStripMain
        '
        Me.contextMenuStripMain.Name = "ContextMenuStrip1"
        Me.contextMenuStripMain.Size = New System.Drawing.Size(61, 4)
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(460, 119)
        Me.Controls.Add(Me.cbAbout)
        Me.Controls.Add(Me.progressBarCompletion)
        Me.Controls.Add(Me.rbReboot)
        Me.Controls.Add(Me.rbLogOff)
        Me.Controls.Add(Me.rbSleep)
        Me.Controls.Add(Me.rbShutdown)
        Me.Controls.Add(Me.cbLock)
        Me.Controls.Add(Me.lbSecond)
        Me.Controls.Add(Me.nudSecond)
        Me.Controls.Add(Me.cbStop)
        Me.Controls.Add(Me.cbStart)
        Me.Controls.Add(Me.lbMinute)
        Me.Controls.Add(Me.lbHour)
        Me.Controls.Add(Me.lbDay)
        Me.Controls.Add(Me.nudDay)
        Me.Controls.Add(Me.nudMinute)
        Me.Controls.Add(Me.nudHour)
        Me.Controls.Add(Me.trackBarSeconds)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Zzz..."
        CType(Me.nudHour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSecond, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackBarSeconds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nudHour As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMinute As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudDay As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbDay As System.Windows.Forms.Label
    Friend WithEvents lbHour As System.Windows.Forms.Label
    Friend WithEvents lbMinute As System.Windows.Forms.Label
    Friend WithEvents cbStart As System.Windows.Forms.Button
    Friend WithEvents cbStop As System.Windows.Forms.Button
    Friend WithEvents progressBarCompletion As System.Windows.Forms.ProgressBar
    Friend WithEvents lbSecond As System.Windows.Forms.Label
    Friend WithEvents nudSecond As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbLock As System.Windows.Forms.CheckBox
    Friend WithEvents rbShutdown As System.Windows.Forms.RadioButton
    Friend WithEvents rbSleep As System.Windows.Forms.RadioButton
    Friend WithEvents rbLogOff As System.Windows.Forms.RadioButton
    Friend WithEvents rbReboot As System.Windows.Forms.RadioButton
    Friend WithEvents trackBarSeconds As System.Windows.Forms.TrackBar
    Friend WithEvents cbAbout As System.Windows.Forms.Button
    Friend WithEvents notifyIconMain As System.Windows.Forms.NotifyIcon
    Friend WithEvents contextMenuStripMain As System.Windows.Forms.ContextMenuStrip

End Class
