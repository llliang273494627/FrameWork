<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmMain
#Region "Windows 窗体设计器生成的代码 "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'此调用是 Windows 窗体设计器所必需的。
		InitializeComponent()
	End Sub
	'Form 重写 Dispose，以清理组件列表。
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Windows 窗体设计器所必需的
	Private components As System.ComponentModel.IContainer
    Public WithEvents Command12 As System.Windows.Forms.Button
    Public WithEvents Command7 As System.Windows.Forms.Button
	Public WithEvents Command4 As System.Windows.Forms.Button
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Picture10 As System.Windows.Forms.PictureBox
	Public WithEvents Timer_PrintError As System.Windows.Forms.Timer
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents Timer_DataSync As System.Windows.Forms.Timer
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents Command6 As System.Windows.Forms.Button
	Public WithEvents Command5 As System.Windows.Forms.Button
	Public WithEvents Command11 As System.Windows.Forms.Button
	Public WithEvents Command10 As System.Windows.Forms.Button
	Public WithEvents Command9 As System.Windows.Forms.Button
	Public WithEvents Command8 As System.Windows.Forms.Button
	Public WithEvents txtInputVIN As System.Windows.Forms.TextBox
	Public WithEvents Command14 As System.Windows.Forms.Button
	Public WithEvents Command17 As System.Windows.Forms.Button
	Public WithEvents Text2 As System.Windows.Forms.TextBox
	Public WithEvents List1 As System.Windows.Forms.ListBox
	Public WithEvents txtVin As System.Windows.Forms.TextBox
	Public WithEvents Timer_StatusQuery As System.Windows.Forms.Timer
	Public WithEvents ListMsg As System.Windows.Forms.ListBox
	Public WithEvents txtRF As System.Windows.Forms.TextBox
	Public WithEvents picRF As System.Windows.Forms.PictureBox
	Public WithEvents txtRR As System.Windows.Forms.TextBox
	Public WithEvents picRR As System.Windows.Forms.PictureBox
	Public WithEvents txtLF As System.Windows.Forms.TextBox
	Public WithEvents picLF As System.Windows.Forms.PictureBox
	Public WithEvents txtLR As System.Windows.Forms.TextBox
	Public WithEvents picLR As System.Windows.Forms.PictureBox
	Public WithEvents Picture8 As System.Windows.Forms.PictureBox
	Public WithEvents Picture7 As System.Windows.Forms.PictureBox
	Public WithEvents Picture9 As System.Windows.Forms.PictureBox
	Public WithEvents Picture6 As System.Windows.Forms.PictureBox
	Public WithEvents PicNet As System.Windows.Forms.PictureBox
	Public WithEvents PicInd As System.Windows.Forms.PictureBox
	Public WithEvents picCommandReset As System.Windows.Forms.PictureBox
	Public WithEvents picCommandConifg As System.Windows.Forms.PictureBox
	Public WithEvents picCommandOut As System.Windows.Forms.PictureBox
	Public WithEvents picCommandLog As System.Windows.Forms.PictureBox
	Public WithEvents picCommandHis As System.Windows.Forms.PictureBox
	Public WithEvents Picture1 As System.Windows.Forms.PictureBox
	Public WithEvents picExit As System.Windows.Forms.PictureBox
	Public WithEvents Picture4 As System.Windows.Forms.PictureBox
	Public WithEvents MSComVIN As AxMSCommLib.AxMSComm
	Public WithEvents MSCommBT As AxMSCommLib.AxMSComm
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents lbRFAcSpeed As System.Windows.Forms.Label
	Public WithEvents lbRFBattery As System.Windows.Forms.Label
	Public WithEvents lbRFMdl As System.Windows.Forms.Label
	Public WithEvents lbRFPre As System.Windows.Forms.Label
	Public WithEvents lbRFTemp As System.Windows.Forms.Label
	Public WithEvents lbRRTemp As System.Windows.Forms.Label
	Public WithEvents lbRRPre As System.Windows.Forms.Label
	Public WithEvents lbRRMdl As System.Windows.Forms.Label
	Public WithEvents lbRRBattery As System.Windows.Forms.Label
	Public WithEvents lbRRAcSpeed As System.Windows.Forms.Label
	Public WithEvents lbLFTemp As System.Windows.Forms.Label
	Public WithEvents lbLFPre As System.Windows.Forms.Label
	Public WithEvents lbLFMdl As System.Windows.Forms.Label
	Public WithEvents lbLFBattery As System.Windows.Forms.Label
	Public WithEvents lbLFAcSpeed As System.Windows.Forms.Label
	Public WithEvents Label39 As System.Windows.Forms.Label
	Public WithEvents lbLRAcSpeed As System.Windows.Forms.Label
	Public WithEvents lbLRBattery As System.Windows.Forms.Label
	Public WithEvents lbLRMdl As System.Windows.Forms.Label
	Public WithEvents lbLRPre As System.Windows.Forms.Label
	Public WithEvents lbLRTemp As System.Windows.Forms.Label
	Public WithEvents Label33 As System.Windows.Forms.Label
	Public WithEvents Label32 As System.Windows.Forms.Label
	Public WithEvents Label31 As System.Windows.Forms.Label
	Public WithEvents Label30 As System.Windows.Forms.Label
	Public WithEvents Label29 As System.Windows.Forms.Label
	Public WithEvents Label28 As System.Windows.Forms.Label
	Public WithEvents Label27 As System.Windows.Forms.Label
	Public WithEvents Label26 As System.Windows.Forms.Label
	Public WithEvents Label25 As System.Windows.Forms.Label
	Public WithEvents Label24 As System.Windows.Forms.Label
	Public WithEvents Label22 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents lblStatus As System.Windows.Forms.Label
	Public WithEvents Label17 As System.Windows.Forms.Label
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label23 As System.Windows.Forms.Label
	Public WithEvents Label21 As System.Windows.Forms.Label
	Public WithEvents Label20 As System.Windows.Forms.Label
	Public WithEvents Label19 As System.Windows.Forms.Label
	Public WithEvents Label18 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	'注意: 以下过程是 Windows 窗体设计器所必需的
	'可以使用 Windows 窗体设计器来修改它。
	'不要使用代码编辑器修改它。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.Command12 = New System.Windows.Forms.Button()
        Me.Command7 = New System.Windows.Forms.Button()
        Me.Command4 = New System.Windows.Forms.Button()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Picture10 = New System.Windows.Forms.PictureBox()
        Me.Timer_PrintError = New System.Windows.Forms.Timer(Me.components)
        Me.Command1 = New System.Windows.Forms.Button()
        Me.Timer_DataSync = New System.Windows.Forms.Timer(Me.components)
        Me.Command3 = New System.Windows.Forms.Button()
        Me.Command6 = New System.Windows.Forms.Button()
        Me.Command5 = New System.Windows.Forms.Button()
        Me.Command11 = New System.Windows.Forms.Button()
        Me.Command10 = New System.Windows.Forms.Button()
        Me.Command9 = New System.Windows.Forms.Button()
        Me.Command8 = New System.Windows.Forms.Button()
        Me.txtInputVIN = New System.Windows.Forms.TextBox()
        Me.Command14 = New System.Windows.Forms.Button()
        Me.Command17 = New System.Windows.Forms.Button()
        Me.Text2 = New System.Windows.Forms.TextBox()
        Me.List1 = New System.Windows.Forms.ListBox()
        Me.txtVin = New System.Windows.Forms.TextBox()
        Me.Timer_StatusQuery = New System.Windows.Forms.Timer(Me.components)
        Me.ListMsg = New System.Windows.Forms.ListBox()
        Me.txtRF = New System.Windows.Forms.TextBox()
        Me.picRF = New System.Windows.Forms.PictureBox()
        Me.txtRR = New System.Windows.Forms.TextBox()
        Me.picRR = New System.Windows.Forms.PictureBox()
        Me.txtLF = New System.Windows.Forms.TextBox()
        Me.picLF = New System.Windows.Forms.PictureBox()
        Me.txtLR = New System.Windows.Forms.TextBox()
        Me.picLR = New System.Windows.Forms.PictureBox()
        Me.Picture8 = New System.Windows.Forms.PictureBox()
        Me.Picture7 = New System.Windows.Forms.PictureBox()
        Me.Picture9 = New System.Windows.Forms.PictureBox()
        Me.Picture6 = New System.Windows.Forms.PictureBox()
        Me.PicNet = New System.Windows.Forms.PictureBox()
        Me.PicInd = New System.Windows.Forms.PictureBox()
        Me.picCommandReset = New System.Windows.Forms.PictureBox()
        Me.picCommandConifg = New System.Windows.Forms.PictureBox()
        Me.picCommandOut = New System.Windows.Forms.PictureBox()
        Me.picCommandLog = New System.Windows.Forms.PictureBox()
        Me.picCommandHis = New System.Windows.Forms.PictureBox()
        Me.Picture1 = New System.Windows.Forms.PictureBox()
        Me.picExit = New System.Windows.Forms.PictureBox()
        Me.Picture4 = New System.Windows.Forms.PictureBox()
        Me.MSComVIN = New AxMSCommLib.AxMSComm()
        Me.MSCommBT = New AxMSCommLib.AxMSComm()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbRFAcSpeed = New System.Windows.Forms.Label()
        Me.lbRFBattery = New System.Windows.Forms.Label()
        Me.lbRFMdl = New System.Windows.Forms.Label()
        Me.lbRFPre = New System.Windows.Forms.Label()
        Me.lbRFTemp = New System.Windows.Forms.Label()
        Me.lbRRTemp = New System.Windows.Forms.Label()
        Me.lbRRPre = New System.Windows.Forms.Label()
        Me.lbRRMdl = New System.Windows.Forms.Label()
        Me.lbRRBattery = New System.Windows.Forms.Label()
        Me.lbRRAcSpeed = New System.Windows.Forms.Label()
        Me.lbLFTemp = New System.Windows.Forms.Label()
        Me.lbLFPre = New System.Windows.Forms.Label()
        Me.lbLFMdl = New System.Windows.Forms.Label()
        Me.lbLFBattery = New System.Windows.Forms.Label()
        Me.lbLFAcSpeed = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.lbLRAcSpeed = New System.Windows.Forms.Label()
        Me.lbLRBattery = New System.Windows.Forms.Label()
        Me.lbLRMdl = New System.Windows.Forms.Label()
        Me.lbLRPre = New System.Windows.Forms.Label()
        Me.lbLRTemp = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.Picture10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicNet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicInd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCommandReset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCommandConifg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCommandOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCommandLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCommandHis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MSComVIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MSCommBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Command12
        '
        Me.Command12.BackColor = System.Drawing.SystemColors.Control
        Me.Command12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command12.Location = New System.Drawing.Point(484, 304)
        Me.Command12.Name = "Command12"
        Me.Command12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command12.Size = New System.Drawing.Size(169, 45)
        Me.Command12.TabIndex = 96
        Me.Command12.Text = "十六进制转数字"
        Me.Command12.UseVisualStyleBackColor = False
        Me.Command12.Visible = False
        '
        'Command7
        '
        Me.Command7.BackColor = System.Drawing.SystemColors.Control
        Me.Command7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command7.Location = New System.Drawing.Point(656, 496)
        Me.Command7.Name = "Command7"
        Me.Command7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command7.Size = New System.Drawing.Size(81, 33)
        Me.Command7.TabIndex = 95
        Me.Command7.Text = "Command7"
        Me.Command7.UseVisualStyleBackColor = False
        Me.Command7.Visible = False
        '
        'Command4
        '
        Me.Command4.BackColor = System.Drawing.SystemColors.Control
        Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command4.Location = New System.Drawing.Point(544, 496)
        Me.Command4.Name = "Command4"
        Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command4.Size = New System.Drawing.Size(89, 33)
        Me.Command4.TabIndex = 94
        Me.Command4.Text = "DoEvents"
        Me.Command4.UseVisualStyleBackColor = False
        Me.Command4.Visible = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(220, 280)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(93, 27)
        Me.Command2.TabIndex = 93
        Me.Command2.Text = "车辆进入工位"
        Me.Command2.UseVisualStyleBackColor = False
        Me.Command2.Visible = False
        '
        'Picture10
        '
        Me.Picture10.BackColor = System.Drawing.SystemColors.Window
        Me.Picture10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture10.Image = CType(resources.GetObject("Picture10.Image"), System.Drawing.Image)
        Me.Picture10.Location = New System.Drawing.Point(24, 736)
        Me.Picture10.Name = "Picture10"
        Me.Picture10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture10.Size = New System.Drawing.Size(43, 28)
        Me.Picture10.TabIndex = 92
        Me.Picture10.TabStop = False
        '
        'Timer_PrintError
        '
        Me.Timer_PrintError.Interval = 1
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(116, 662)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(103, 29)
        Me.Command1.TabIndex = 90
        Me.Command1.Text = "解析VT520数据"
        Me.Command1.UseVisualStyleBackColor = False
        Me.Command1.Visible = False
        '
        'Timer_DataSync
        '
        Me.Timer_DataSync.Interval = 1000
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(220, 240)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(93, 27)
        Me.Command3.TabIndex = 49
        Me.Command3.Text = "系统锁定开关"
        Me.Command3.UseVisualStyleBackColor = False
        Me.Command3.Visible = False
        '
        'Command6
        '
        Me.Command6.BackColor = System.Drawing.SystemColors.Control
        Me.Command6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command6.Location = New System.Drawing.Point(116, 626)
        Me.Command6.Name = "Command6"
        Me.Command6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command6.Size = New System.Drawing.Size(106, 31)
        Me.Command6.TabIndex = 48
        Me.Command6.Text = "传动解锁"
        Me.Command6.UseVisualStyleBackColor = False
        Me.Command6.Visible = False
        '
        'Command5
        '
        Me.Command5.BackColor = System.Drawing.SystemColors.Control
        Me.Command5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command5.Location = New System.Drawing.Point(4, 661)
        Me.Command5.Name = "Command5"
        Me.Command5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command5.Size = New System.Drawing.Size(106, 31)
        Me.Command5.TabIndex = 47
        Me.Command5.Text = "条码解锁"
        Me.Command5.UseVisualStyleBackColor = False
        Me.Command5.Visible = False
        '
        'Command11
        '
        Me.Command11.BackColor = System.Drawing.SystemColors.Control
        Me.Command11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command11.Location = New System.Drawing.Point(220, 408)
        Me.Command11.Name = "Command11"
        Me.Command11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command11.Size = New System.Drawing.Size(93, 27)
        Me.Command11.TabIndex = 46
        Me.Command11.Text = "左后轮"
        Me.Command11.UseVisualStyleBackColor = False
        Me.Command11.Visible = False
        '
        'Command10
        '
        Me.Command10.BackColor = System.Drawing.SystemColors.Control
        Me.Command10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command10.Location = New System.Drawing.Point(220, 376)
        Me.Command10.Name = "Command10"
        Me.Command10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command10.Size = New System.Drawing.Size(93, 27)
        Me.Command10.TabIndex = 45
        Me.Command10.Text = "右后轮"
        Me.Command10.UseVisualStyleBackColor = False
        Me.Command10.Visible = False
        '
        'Command9
        '
        Me.Command9.BackColor = System.Drawing.SystemColors.Control
        Me.Command9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command9.Location = New System.Drawing.Point(220, 344)
        Me.Command9.Name = "Command9"
        Me.Command9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command9.Size = New System.Drawing.Size(93, 27)
        Me.Command9.TabIndex = 44
        Me.Command9.Text = "左前轮"
        Me.Command9.UseVisualStyleBackColor = False
        Me.Command9.Visible = False
        '
        'Command8
        '
        Me.Command8.BackColor = System.Drawing.SystemColors.Control
        Me.Command8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command8.Location = New System.Drawing.Point(220, 312)
        Me.Command8.Name = "Command8"
        Me.Command8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command8.Size = New System.Drawing.Size(93, 27)
        Me.Command8.TabIndex = 43
        Me.Command8.Text = "右前轮"
        Me.Command8.UseVisualStyleBackColor = False
        Me.Command8.Visible = False
        '
        'txtInputVIN
        '
        Me.txtInputVIN.AcceptsReturn = True
        Me.txtInputVIN.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtInputVIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInputVIN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInputVIN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtInputVIN.Location = New System.Drawing.Point(0, 76)
        Me.txtInputVIN.MaxLength = 0
        Me.txtInputVIN.Name = "txtInputVIN"
        Me.txtInputVIN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInputVIN.Size = New System.Drawing.Size(223, 21)
        Me.txtInputVIN.TabIndex = 42
        Me.txtInputVIN.Text = "手工录入VIN，回车确认"
        Me.txtInputVIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Command14
        '
        Me.Command14.BackColor = System.Drawing.SystemColors.Control
        Me.Command14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command14.Location = New System.Drawing.Point(522, 182)
        Me.Command14.Name = "Command14"
        Me.Command14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command14.Size = New System.Drawing.Size(201, 33)
        Me.Command14.TabIndex = 41
        Me.Command14.Text = "测试完成"
        Me.Command14.UseVisualStyleBackColor = False
        Me.Command14.Visible = False
        '
        'Command17
        '
        Me.Command17.BackColor = System.Drawing.SystemColors.Control
        Me.Command17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command17.Location = New System.Drawing.Point(522, 146)
        Me.Command17.Name = "Command17"
        Me.Command17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command17.Size = New System.Drawing.Size(201, 33)
        Me.Command17.TabIndex = 40
        Me.Command17.Text = "扫描胎压码"
        Me.Command17.UseVisualStyleBackColor = False
        Me.Command17.Visible = False
        '
        'Text2
        '
        Me.Text2.AcceptsReturn = True
        Me.Text2.BackColor = System.Drawing.SystemColors.Window
        Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text2.Location = New System.Drawing.Point(520, 116)
        Me.Text2.MaxLength = 0
        Me.Text2.Name = "Text2"
        Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text2.Size = New System.Drawing.Size(201, 21)
        Me.Text2.TabIndex = 39
        Me.Text2.Text = "LMGDK1G87B1S00037"
        Me.Text2.Visible = False
        '
        'List1
        '
        Me.List1.BackColor = System.Drawing.SystemColors.Window
        Me.List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List1.ItemHeight = 12
        Me.List1.Location = New System.Drawing.Point(848, 256)
        Me.List1.Name = "List1"
        Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List1.Size = New System.Drawing.Size(145, 184)
        Me.List1.TabIndex = 38
        Me.List1.Visible = False
        '
        'txtVin
        '
        Me.txtVin.AcceptsReturn = True
        Me.txtVin.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.txtVin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVin.Font = New System.Drawing.Font("宋体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVin.ForeColor = System.Drawing.Color.White
        Me.txtVin.Location = New System.Drawing.Point(229, 76)
        Me.txtVin.MaxLength = 17
        Me.txtVin.Name = "txtVin"
        Me.txtVin.ReadOnly = True
        Me.txtVin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVin.Size = New System.Drawing.Size(792, 34)
        Me.txtVin.TabIndex = 37
        Me.txtVin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Timer_StatusQuery
        '
        Me.Timer_StatusQuery.Enabled = True
        Me.Timer_StatusQuery.Interval = 1000
        '
        'ListMsg
        '
        Me.ListMsg.BackColor = System.Drawing.SystemColors.Window
        Me.ListMsg.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListMsg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ListMsg.ItemHeight = 12
        Me.ListMsg.Location = New System.Drawing.Point(260, 610)
        Me.ListMsg.Name = "ListMsg"
        Me.ListMsg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListMsg.Size = New System.Drawing.Size(737, 100)
        Me.ListMsg.TabIndex = 29
        '
        'txtRF
        '
        Me.txtRF.AcceptsReturn = True
        Me.txtRF.BackColor = System.Drawing.SystemColors.Window
        Me.txtRF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRF.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRF.Font = New System.Drawing.Font("宋体", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtRF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRF.Location = New System.Drawing.Point(826, 494)
        Me.txtRF.MaxLength = 0
        Me.txtRF.Name = "txtRF"
        Me.txtRF.ReadOnly = True
        Me.txtRF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRF.Size = New System.Drawing.Size(149, 31)
        Me.txtRF.TabIndex = 26
        '
        'picRF
        '
        Me.picRF.BackColor = System.Drawing.SystemColors.Window
        Me.picRF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picRF.Cursor = System.Windows.Forms.Cursors.Default
        Me.picRF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picRF.Image = CType(resources.GetObject("picRF.Image"), System.Drawing.Image)
        Me.picRF.Location = New System.Drawing.Point(764, 494)
        Me.picRF.Name = "picRF"
        Me.picRF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picRF.Size = New System.Drawing.Size(28, 28)
        Me.picRF.TabIndex = 25
        Me.picRF.TabStop = False
        '
        'txtRR
        '
        Me.txtRR.AcceptsReturn = True
        Me.txtRR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRR.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRR.Font = New System.Drawing.Font("宋体", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtRR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRR.Location = New System.Drawing.Point(336, 494)
        Me.txtRR.MaxLength = 0
        Me.txtRR.Name = "txtRR"
        Me.txtRR.ReadOnly = True
        Me.txtRR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRR.Size = New System.Drawing.Size(149, 31)
        Me.txtRR.TabIndex = 23
        '
        'picRR
        '
        Me.picRR.BackColor = System.Drawing.SystemColors.Window
        Me.picRR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picRR.Cursor = System.Windows.Forms.Cursors.Default
        Me.picRR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picRR.Image = CType(resources.GetObject("picRR.Image"), System.Drawing.Image)
        Me.picRR.Location = New System.Drawing.Point(274, 494)
        Me.picRR.Name = "picRR"
        Me.picRR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picRR.Size = New System.Drawing.Size(28, 28)
        Me.picRR.TabIndex = 22
        Me.picRR.TabStop = False
        '
        'txtLF
        '
        Me.txtLF.AcceptsReturn = True
        Me.txtLF.BackColor = System.Drawing.SystemColors.Window
        Me.txtLF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLF.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLF.Font = New System.Drawing.Font("宋体", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtLF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLF.Location = New System.Drawing.Point(824, 156)
        Me.txtLF.MaxLength = 0
        Me.txtLF.Name = "txtLF"
        Me.txtLF.ReadOnly = True
        Me.txtLF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLF.Size = New System.Drawing.Size(149, 31)
        Me.txtLF.TabIndex = 20
        '
        'picLF
        '
        Me.picLF.BackColor = System.Drawing.SystemColors.Window
        Me.picLF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picLF.Cursor = System.Windows.Forms.Cursors.Default
        Me.picLF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picLF.Image = CType(resources.GetObject("picLF.Image"), System.Drawing.Image)
        Me.picLF.Location = New System.Drawing.Point(766, 156)
        Me.picLF.Name = "picLF"
        Me.picLF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picLF.Size = New System.Drawing.Size(28, 28)
        Me.picLF.TabIndex = 19
        Me.picLF.TabStop = False
        '
        'txtLR
        '
        Me.txtLR.AcceptsReturn = True
        Me.txtLR.BackColor = System.Drawing.SystemColors.Window
        Me.txtLR.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLR.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtLR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLR.Location = New System.Drawing.Point(332, 156)
        Me.txtLR.MaxLength = 0
        Me.txtLR.Name = "txtLR"
        Me.txtLR.ReadOnly = True
        Me.txtLR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLR.Size = New System.Drawing.Size(149, 28)
        Me.txtLR.TabIndex = 17
        '
        'picLR
        '
        Me.picLR.BackColor = System.Drawing.SystemColors.Window
        Me.picLR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picLR.Cursor = System.Windows.Forms.Cursors.Default
        Me.picLR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picLR.Image = CType(resources.GetObject("picLR.Image"), System.Drawing.Image)
        Me.picLR.Location = New System.Drawing.Point(274, 156)
        Me.picLR.Name = "picLR"
        Me.picLR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picLR.Size = New System.Drawing.Size(28, 28)
        Me.picLR.TabIndex = 16
        Me.picLR.TabStop = False
        '
        'Picture8
        '
        Me.Picture8.BackColor = System.Drawing.SystemColors.Window
        Me.Picture8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture8.Image = CType(resources.GetObject("Picture8.Image"), System.Drawing.Image)
        Me.Picture8.Location = New System.Drawing.Point(38, 568)
        Me.Picture8.Name = "Picture8"
        Me.Picture8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture8.Size = New System.Drawing.Size(28, 28)
        Me.Picture8.TabIndex = 15
        Me.Picture8.TabStop = False
        '
        'Picture7
        '
        Me.Picture7.BackColor = System.Drawing.SystemColors.Window
        Me.Picture7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture7.Image = CType(resources.GetObject("Picture7.Image"), System.Drawing.Image)
        Me.Picture7.Location = New System.Drawing.Point(38, 498)
        Me.Picture7.Name = "Picture7"
        Me.Picture7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture7.Size = New System.Drawing.Size(28, 28)
        Me.Picture7.TabIndex = 14
        Me.Picture7.TabStop = False
        '
        'Picture9
        '
        Me.Picture9.BackColor = System.Drawing.SystemColors.Window
        Me.Picture9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture9.Image = CType(resources.GetObject("Picture9.Image"), System.Drawing.Image)
        Me.Picture9.Location = New System.Drawing.Point(38, 420)
        Me.Picture9.Name = "Picture9"
        Me.Picture9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture9.Size = New System.Drawing.Size(28, 28)
        Me.Picture9.TabIndex = 13
        Me.Picture9.TabStop = False
        '
        'Picture6
        '
        Me.Picture6.BackColor = System.Drawing.SystemColors.Window
        Me.Picture6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture6.Image = CType(resources.GetObject("Picture6.Image"), System.Drawing.Image)
        Me.Picture6.Location = New System.Drawing.Point(38, 338)
        Me.Picture6.Name = "Picture6"
        Me.Picture6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture6.Size = New System.Drawing.Size(28, 28)
        Me.Picture6.TabIndex = 12
        Me.Picture6.TabStop = False
        '
        'PicNet
        '
        Me.PicNet.BackColor = System.Drawing.SystemColors.Window
        Me.PicNet.Cursor = System.Windows.Forms.Cursors.Default
        Me.PicNet.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PicNet.Image = CType(resources.GetObject("PicNet.Image"), System.Drawing.Image)
        Me.PicNet.Location = New System.Drawing.Point(38, 258)
        Me.PicNet.Name = "PicNet"
        Me.PicNet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PicNet.Size = New System.Drawing.Size(28, 28)
        Me.PicNet.TabIndex = 11
        Me.PicNet.TabStop = False
        '
        'PicInd
        '
        Me.PicInd.BackColor = System.Drawing.SystemColors.Window
        Me.PicInd.Cursor = System.Windows.Forms.Cursors.Default
        Me.PicInd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PicInd.Image = CType(resources.GetObject("PicInd.Image"), System.Drawing.Image)
        Me.PicInd.Location = New System.Drawing.Point(38, 184)
        Me.PicInd.Name = "PicInd"
        Me.PicInd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PicInd.Size = New System.Drawing.Size(28, 28)
        Me.PicInd.TabIndex = 10
        Me.PicInd.TabStop = False
        '
        'picCommandReset
        '
        Me.picCommandReset.BackColor = System.Drawing.SystemColors.Window
        Me.picCommandReset.Cursor = System.Windows.Forms.Cursors.Default
        Me.picCommandReset.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picCommandReset.Image = CType(resources.GetObject("picCommandReset.Image"), System.Drawing.Image)
        Me.picCommandReset.Location = New System.Drawing.Point(638, 33)
        Me.picCommandReset.Name = "picCommandReset"
        Me.picCommandReset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picCommandReset.Size = New System.Drawing.Size(105, 39)
        Me.picCommandReset.TabIndex = 7
        Me.picCommandReset.TabStop = False
        '
        'picCommandConifg
        '
        Me.picCommandConifg.BackColor = System.Drawing.SystemColors.Window
        Me.picCommandConifg.Cursor = System.Windows.Forms.Cursors.Default
        Me.picCommandConifg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picCommandConifg.Image = CType(resources.GetObject("picCommandConifg.Image"), System.Drawing.Image)
        Me.picCommandConifg.Location = New System.Drawing.Point(534, 33)
        Me.picCommandConifg.Name = "picCommandConifg"
        Me.picCommandConifg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picCommandConifg.Size = New System.Drawing.Size(104, 39)
        Me.picCommandConifg.TabIndex = 6
        Me.picCommandConifg.TabStop = False
        '
        'picCommandOut
        '
        Me.picCommandOut.BackColor = System.Drawing.SystemColors.Window
        Me.picCommandOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.picCommandOut.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picCommandOut.Image = CType(resources.GetObject("picCommandOut.Image"), System.Drawing.Image)
        Me.picCommandOut.Location = New System.Drawing.Point(430, 33)
        Me.picCommandOut.Name = "picCommandOut"
        Me.picCommandOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picCommandOut.Size = New System.Drawing.Size(105, 39)
        Me.picCommandOut.TabIndex = 5
        Me.picCommandOut.TabStop = False
        '
        'picCommandLog
        '
        Me.picCommandLog.BackColor = System.Drawing.SystemColors.Window
        Me.picCommandLog.Cursor = System.Windows.Forms.Cursors.Default
        Me.picCommandLog.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picCommandLog.Image = CType(resources.GetObject("picCommandLog.Image"), System.Drawing.Image)
        Me.picCommandLog.Location = New System.Drawing.Point(326, 33)
        Me.picCommandLog.Name = "picCommandLog"
        Me.picCommandLog.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picCommandLog.Size = New System.Drawing.Size(105, 39)
        Me.picCommandLog.TabIndex = 4
        Me.picCommandLog.TabStop = False
        '
        'picCommandHis
        '
        Me.picCommandHis.BackColor = System.Drawing.SystemColors.Window
        Me.picCommandHis.Cursor = System.Windows.Forms.Cursors.Default
        Me.picCommandHis.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picCommandHis.Image = CType(resources.GetObject("picCommandHis.Image"), System.Drawing.Image)
        Me.picCommandHis.Location = New System.Drawing.Point(221, 33)
        Me.picCommandHis.Name = "picCommandHis"
        Me.picCommandHis.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picCommandHis.Size = New System.Drawing.Size(105, 39)
        Me.picCommandHis.TabIndex = 3
        Me.picCommandHis.TabStop = False
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Window
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture1.Image = CType(resources.GetObject("Picture1.Image"), System.Drawing.Image)
        Me.Picture1.Location = New System.Drawing.Point(950, 0)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(33, 24)
        Me.Picture1.TabIndex = 2
        Me.Picture1.TabStop = False
        '
        'picExit
        '
        Me.picExit.BackColor = System.Drawing.SystemColors.Window
        Me.picExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.picExit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picExit.Image = CType(resources.GetObject("picExit.Image"), System.Drawing.Image)
        Me.picExit.Location = New System.Drawing.Point(983, 0)
        Me.picExit.Name = "picExit"
        Me.picExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picExit.Size = New System.Drawing.Size(33, 24)
        Me.picExit.TabIndex = 1
        Me.picExit.TabStop = False
        '
        'Picture4
        '
        Me.Picture4.BackColor = System.Drawing.SystemColors.Window
        Me.Picture4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture4.Image = CType(resources.GetObject("Picture4.Image"), System.Drawing.Image)
        Me.Picture4.Location = New System.Drawing.Point(0, 2)
        Me.Picture4.Name = "Picture4"
        Me.Picture4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture4.Size = New System.Drawing.Size(299, 30)
        Me.Picture4.TabIndex = 0
        Me.Picture4.TabStop = False
        '
        'MSComVIN
        '
        Me.MSComVIN.Enabled = True
        Me.MSComVIN.Location = New System.Drawing.Point(156, 124)
        Me.MSComVIN.Name = "MSComVIN"
        Me.MSComVIN.OcxState = CType(resources.GetObject("MSComVIN.OcxState"), System.Windows.Forms.AxHost.State)
        Me.MSComVIN.Size = New System.Drawing.Size(38, 38)
        Me.MSComVIN.TabIndex = 97
        '
        'MSCommBT
        '
        Me.MSCommBT.Enabled = True
        Me.MSCommBT.Location = New System.Drawing.Point(200, 124)
        Me.MSCommBT.Name = "MSCommBT"
        Me.MSCommBT.OcxState = CType(resources.GetObject("MSCommBT.OcxState"), System.Windows.Forms.AxHost.State)
        Me.MSCommBT.Size = New System.Drawing.Size(38, 38)
        Me.MSCommBT.TabIndex = 98
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("新宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(72, 740)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(94, 21)
        Me.Label15.TabIndex = 91
        Me.Label15.Text = "华信数据"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbRFAcSpeed
        '
        Me.lbRFAcSpeed.BackColor = System.Drawing.Color.Transparent
        Me.lbRFAcSpeed.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRFAcSpeed.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRFAcSpeed.ForeColor = System.Drawing.Color.Blue
        Me.lbRFAcSpeed.Location = New System.Drawing.Point(890, 543)
        Me.lbRFAcSpeed.Name = "lbRFAcSpeed"
        Me.lbRFAcSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRFAcSpeed.Size = New System.Drawing.Size(32, 16)
        Me.lbRFAcSpeed.TabIndex = 89
        Me.lbRFAcSpeed.Text = "123"
        '
        'lbRFBattery
        '
        Me.lbRFBattery.BackColor = System.Drawing.Color.Transparent
        Me.lbRFBattery.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRFBattery.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRFBattery.ForeColor = System.Drawing.Color.Blue
        Me.lbRFBattery.Location = New System.Drawing.Point(798, 543)
        Me.lbRFBattery.Name = "lbRFBattery"
        Me.lbRFBattery.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRFBattery.Size = New System.Drawing.Size(32, 16)
        Me.lbRFBattery.TabIndex = 88
        Me.lbRFBattery.Text = "123"
        '
        'lbRFMdl
        '
        Me.lbRFMdl.BackColor = System.Drawing.Color.Transparent
        Me.lbRFMdl.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRFMdl.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRFMdl.ForeColor = System.Drawing.Color.Blue
        Me.lbRFMdl.Location = New System.Drawing.Point(798, 527)
        Me.lbRFMdl.Name = "lbRFMdl"
        Me.lbRFMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRFMdl.Size = New System.Drawing.Size(32, 16)
        Me.lbRFMdl.TabIndex = 87
        Me.lbRFMdl.Text = "123"
        '
        'lbRFPre
        '
        Me.lbRFPre.BackColor = System.Drawing.Color.Transparent
        Me.lbRFPre.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRFPre.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRFPre.ForeColor = System.Drawing.Color.Blue
        Me.lbRFPre.Location = New System.Drawing.Point(876, 528)
        Me.lbRFPre.Name = "lbRFPre"
        Me.lbRFPre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRFPre.Size = New System.Drawing.Size(32, 16)
        Me.lbRFPre.TabIndex = 86
        Me.lbRFPre.Text = "123"
        '
        'lbRFTemp
        '
        Me.lbRFTemp.BackColor = System.Drawing.Color.Transparent
        Me.lbRFTemp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRFTemp.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRFTemp.ForeColor = System.Drawing.Color.Blue
        Me.lbRFTemp.Location = New System.Drawing.Point(950, 527)
        Me.lbRFTemp.Name = "lbRFTemp"
        Me.lbRFTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRFTemp.Size = New System.Drawing.Size(32, 16)
        Me.lbRFTemp.TabIndex = 85
        Me.lbRFTemp.Text = "123"
        '
        'lbRRTemp
        '
        Me.lbRRTemp.BackColor = System.Drawing.Color.Transparent
        Me.lbRRTemp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRRTemp.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRRTemp.ForeColor = System.Drawing.Color.Blue
        Me.lbRRTemp.Location = New System.Drawing.Point(460, 526)
        Me.lbRRTemp.Name = "lbRRTemp"
        Me.lbRRTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRRTemp.Size = New System.Drawing.Size(32, 16)
        Me.lbRRTemp.TabIndex = 84
        Me.lbRRTemp.Text = "123"
        '
        'lbRRPre
        '
        Me.lbRRPre.BackColor = System.Drawing.Color.Transparent
        Me.lbRRPre.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRRPre.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRRPre.ForeColor = System.Drawing.Color.Blue
        Me.lbRRPre.Location = New System.Drawing.Point(390, 525)
        Me.lbRRPre.Name = "lbRRPre"
        Me.lbRRPre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRRPre.Size = New System.Drawing.Size(32, 16)
        Me.lbRRPre.TabIndex = 83
        Me.lbRRPre.Text = "123"
        '
        'lbRRMdl
        '
        Me.lbRRMdl.BackColor = System.Drawing.Color.Transparent
        Me.lbRRMdl.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRRMdl.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRRMdl.ForeColor = System.Drawing.Color.Blue
        Me.lbRRMdl.Location = New System.Drawing.Point(314, 526)
        Me.lbRRMdl.Name = "lbRRMdl"
        Me.lbRRMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRRMdl.Size = New System.Drawing.Size(32, 16)
        Me.lbRRMdl.TabIndex = 82
        Me.lbRRMdl.Text = "123"
        Me.lbRRMdl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRRBattery
        '
        Me.lbRRBattery.BackColor = System.Drawing.Color.Transparent
        Me.lbRRBattery.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRRBattery.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRRBattery.ForeColor = System.Drawing.Color.Blue
        Me.lbRRBattery.Location = New System.Drawing.Point(314, 542)
        Me.lbRRBattery.Name = "lbRRBattery"
        Me.lbRRBattery.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRRBattery.Size = New System.Drawing.Size(32, 16)
        Me.lbRRBattery.TabIndex = 81
        Me.lbRRBattery.Text = "123"
        Me.lbRRBattery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRRAcSpeed
        '
        Me.lbRRAcSpeed.BackColor = System.Drawing.Color.Transparent
        Me.lbRRAcSpeed.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRRAcSpeed.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRRAcSpeed.ForeColor = System.Drawing.Color.Blue
        Me.lbRRAcSpeed.Location = New System.Drawing.Point(404, 542)
        Me.lbRRAcSpeed.Name = "lbRRAcSpeed"
        Me.lbRRAcSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRRAcSpeed.Size = New System.Drawing.Size(32, 16)
        Me.lbRRAcSpeed.TabIndex = 80
        Me.lbRRAcSpeed.Text = "123"
        '
        'lbLFTemp
        '
        Me.lbLFTemp.BackColor = System.Drawing.Color.Transparent
        Me.lbLFTemp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLFTemp.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLFTemp.ForeColor = System.Drawing.Color.Blue
        Me.lbLFTemp.Location = New System.Drawing.Point(952, 186)
        Me.lbLFTemp.Name = "lbLFTemp"
        Me.lbLFTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLFTemp.Size = New System.Drawing.Size(32, 16)
        Me.lbLFTemp.TabIndex = 79
        Me.lbLFTemp.Text = "123"
        '
        'lbLFPre
        '
        Me.lbLFPre.BackColor = System.Drawing.Color.Transparent
        Me.lbLFPre.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLFPre.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLFPre.ForeColor = System.Drawing.Color.Blue
        Me.lbLFPre.Location = New System.Drawing.Point(876, 187)
        Me.lbLFPre.Name = "lbLFPre"
        Me.lbLFPre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLFPre.Size = New System.Drawing.Size(32, 16)
        Me.lbLFPre.TabIndex = 78
        Me.lbLFPre.Text = "123"
        '
        'lbLFMdl
        '
        Me.lbLFMdl.BackColor = System.Drawing.Color.Transparent
        Me.lbLFMdl.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLFMdl.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLFMdl.ForeColor = System.Drawing.Color.Blue
        Me.lbLFMdl.Location = New System.Drawing.Point(800, 187)
        Me.lbLFMdl.Name = "lbLFMdl"
        Me.lbLFMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLFMdl.Size = New System.Drawing.Size(32, 16)
        Me.lbLFMdl.TabIndex = 77
        Me.lbLFMdl.Text = "123"
        '
        'lbLFBattery
        '
        Me.lbLFBattery.BackColor = System.Drawing.Color.Transparent
        Me.lbLFBattery.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLFBattery.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLFBattery.ForeColor = System.Drawing.Color.Blue
        Me.lbLFBattery.Location = New System.Drawing.Point(800, 203)
        Me.lbLFBattery.Name = "lbLFBattery"
        Me.lbLFBattery.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLFBattery.Size = New System.Drawing.Size(32, 16)
        Me.lbLFBattery.TabIndex = 76
        Me.lbLFBattery.Text = "123"
        '
        'lbLFAcSpeed
        '
        Me.lbLFAcSpeed.BackColor = System.Drawing.Color.Transparent
        Me.lbLFAcSpeed.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLFAcSpeed.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLFAcSpeed.ForeColor = System.Drawing.Color.Blue
        Me.lbLFAcSpeed.Location = New System.Drawing.Point(890, 204)
        Me.lbLFAcSpeed.Name = "lbLFAcSpeed"
        Me.lbLFAcSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLFAcSpeed.Size = New System.Drawing.Size(32, 16)
        Me.lbLFAcSpeed.TabIndex = 75
        Me.lbLFAcSpeed.Text = "123"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(272, 186)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(45, 16)
        Me.Label39.TabIndex = 74
        Me.Label39.Text = "模式:"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLRAcSpeed
        '
        Me.lbLRAcSpeed.BackColor = System.Drawing.Color.Transparent
        Me.lbLRAcSpeed.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLRAcSpeed.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLRAcSpeed.ForeColor = System.Drawing.Color.Blue
        Me.lbLRAcSpeed.Location = New System.Drawing.Point(406, 203)
        Me.lbLRAcSpeed.Name = "lbLRAcSpeed"
        Me.lbLRAcSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLRAcSpeed.Size = New System.Drawing.Size(32, 16)
        Me.lbLRAcSpeed.TabIndex = 73
        Me.lbLRAcSpeed.Text = "123"
        '
        'lbLRBattery
        '
        Me.lbLRBattery.BackColor = System.Drawing.Color.Transparent
        Me.lbLRBattery.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLRBattery.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLRBattery.ForeColor = System.Drawing.Color.Blue
        Me.lbLRBattery.Location = New System.Drawing.Point(314, 203)
        Me.lbLRBattery.Name = "lbLRBattery"
        Me.lbLRBattery.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLRBattery.Size = New System.Drawing.Size(32, 16)
        Me.lbLRBattery.TabIndex = 72
        Me.lbLRBattery.Text = "123"
        Me.lbLRBattery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLRMdl
        '
        Me.lbLRMdl.BackColor = System.Drawing.Color.Transparent
        Me.lbLRMdl.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLRMdl.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLRMdl.ForeColor = System.Drawing.Color.Blue
        Me.lbLRMdl.Location = New System.Drawing.Point(314, 186)
        Me.lbLRMdl.Name = "lbLRMdl"
        Me.lbLRMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLRMdl.Size = New System.Drawing.Size(32, 16)
        Me.lbLRMdl.TabIndex = 71
        Me.lbLRMdl.Text = "123"
        Me.lbLRMdl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLRPre
        '
        Me.lbLRPre.BackColor = System.Drawing.Color.Transparent
        Me.lbLRPre.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLRPre.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLRPre.ForeColor = System.Drawing.Color.Blue
        Me.lbLRPre.Location = New System.Drawing.Point(392, 186)
        Me.lbLRPre.Name = "lbLRPre"
        Me.lbLRPre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLRPre.Size = New System.Drawing.Size(32, 16)
        Me.lbLRPre.TabIndex = 70
        Me.lbLRPre.Text = "123"
        '
        'lbLRTemp
        '
        Me.lbLRTemp.BackColor = System.Drawing.Color.Transparent
        Me.lbLRTemp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLRTemp.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLRTemp.ForeColor = System.Drawing.Color.Blue
        Me.lbLRTemp.Location = New System.Drawing.Point(462, 186)
        Me.lbLRTemp.Name = "lbLRTemp"
        Me.lbLRTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLRTemp.Size = New System.Drawing.Size(32, 16)
        Me.lbLRTemp.TabIndex = 69
        Me.lbLRTemp.Text = "123"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label33.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(760, 527)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label33.Size = New System.Drawing.Size(45, 16)
        Me.Label33.TabIndex = 68
        Me.Label33.Text = "模式:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(838, 528)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(45, 16)
        Me.Label32.TabIndex = 67
        Me.Label32.Text = "压力:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(912, 527)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(80, 21)
        Me.Label31.TabIndex = 66
        Me.Label31.Text = "温度:"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(838, 543)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(80, 16)
        Me.Label30.TabIndex = 65
        Me.Label30.Text = "加速度:"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(760, 543)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(80, 21)
        Me.Label29.TabIndex = 64
        Me.Label29.Text = "电池:"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(270, 526)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(45, 16)
        Me.Label28.TabIndex = 63
        Me.Label28.Text = "模式:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(352, 525)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(45, 16)
        Me.Label27.TabIndex = 62
        Me.Label27.Text = "压力:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(422, 526)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(45, 16)
        Me.Label26.TabIndex = 61
        Me.Label26.Text = "温度:"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(352, 542)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(80, 16)
        Me.Label25.TabIndex = 60
        Me.Label25.Text = "加速度:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(270, 542)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(45, 16)
        Me.Label24.TabIndex = 59
        Me.Label24.Text = "电池:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(762, 187)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(45, 16)
        Me.Label22.TabIndex = 58
        Me.Label22.Text = "模式:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(838, 187)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(45, 16)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "压力:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(912, 187)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(80, 21)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "温度:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(838, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "加速度:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(762, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(80, 21)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "电池:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(272, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "电池:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(352, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "加速度:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(422, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "温度:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(352, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "压力:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStatus.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.Location = New System.Drawing.Point(48, 600)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStatus.Size = New System.Drawing.Size(169, 20)
        Me.lblStatus.TabIndex = 36
        Me.lblStatus.Text = "网络连接状态异常"
        Me.lblStatus.Visible = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(71, 573)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(105, 25)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "右侧控制器"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(71, 503)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(105, 25)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "左侧控制器"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(71, 425)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(145, 24)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "数据库硬盘容量"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(71, 342)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(105, 25)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "SPPV数据库"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(71, 263)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(105, 25)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "本地数据库"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(71, 189)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(89, 24)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "网络连接"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(470, 742)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(525, 17)
        Me.Label23.TabIndex = 28
        Me.Label23.Text = "武汉市洪山区珞瑜东路佳园路光谷国际A座2318室    电话：027-87775236"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label21.Location = New System.Drawing.Point(801, 464)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(168, 29)
        Me.Label21.TabIndex = 27
        Me.Label21.Text = "右前轮"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label20.Location = New System.Drawing.Point(300, 464)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(168, 29)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "右后轮"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label19.Location = New System.Drawing.Point(799, 126)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(168, 29)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "左前轮"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label18.Location = New System.Drawing.Point(300, 126)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(168, 29)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "左后轮"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(14, 132)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(145, 25)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "状态监视:"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(16, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(187, 25)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "胎压初始化系统"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "Green.jpg")
        Me.ImageList.Images.SetKeyName(1, "Green.jpg")
        Me.ImageList.Images.SetKeyName(2, "Green1.jpg")
        Me.ImageList.Images.SetKeyName(3, "Red.jpg")
        Me.ImageList.Images.SetKeyName(4, "Red1.jpg")
        Me.ImageList.Images.SetKeyName(5, "Blue.jpg")
        Me.ImageList.Images.SetKeyName(6, "Blue1.jpg")
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.Command12)
        Me.Controls.Add(Me.Command7)
        Me.Controls.Add(Me.Command4)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Picture10)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Command6)
        Me.Controls.Add(Me.Command5)
        Me.Controls.Add(Me.Command11)
        Me.Controls.Add(Me.Command10)
        Me.Controls.Add(Me.Command9)
        Me.Controls.Add(Me.Command8)
        Me.Controls.Add(Me.txtInputVIN)
        Me.Controls.Add(Me.Command14)
        Me.Controls.Add(Me.Command17)
        Me.Controls.Add(Me.Text2)
        Me.Controls.Add(Me.List1)
        Me.Controls.Add(Me.txtVin)
        Me.Controls.Add(Me.ListMsg)
        Me.Controls.Add(Me.txtRF)
        Me.Controls.Add(Me.picRF)
        Me.Controls.Add(Me.txtRR)
        Me.Controls.Add(Me.picRR)
        Me.Controls.Add(Me.txtLF)
        Me.Controls.Add(Me.picLF)
        Me.Controls.Add(Me.txtLR)
        Me.Controls.Add(Me.picLR)
        Me.Controls.Add(Me.Picture8)
        Me.Controls.Add(Me.Picture7)
        Me.Controls.Add(Me.Picture9)
        Me.Controls.Add(Me.Picture6)
        Me.Controls.Add(Me.PicNet)
        Me.Controls.Add(Me.PicInd)
        Me.Controls.Add(Me.picCommandReset)
        Me.Controls.Add(Me.picCommandConifg)
        Me.Controls.Add(Me.picCommandOut)
        Me.Controls.Add(Me.picCommandLog)
        Me.Controls.Add(Me.picCommandHis)
        Me.Controls.Add(Me.Picture1)
        Me.Controls.Add(Me.picExit)
        Me.Controls.Add(Me.Picture4)
        Me.Controls.Add(Me.MSComVIN)
        Me.Controls.Add(Me.MSCommBT)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lbRFAcSpeed)
        Me.Controls.Add(Me.lbRFBattery)
        Me.Controls.Add(Me.lbRFMdl)
        Me.Controls.Add(Me.lbRFPre)
        Me.Controls.Add(Me.lbRFTemp)
        Me.Controls.Add(Me.lbRRTemp)
        Me.Controls.Add(Me.lbRRPre)
        Me.Controls.Add(Me.lbRRMdl)
        Me.Controls.Add(Me.lbRRBattery)
        Me.Controls.Add(Me.lbRRAcSpeed)
        Me.Controls.Add(Me.lbLFTemp)
        Me.Controls.Add(Me.lbLFPre)
        Me.Controls.Add(Me.lbLFMdl)
        Me.Controls.Add(Me.lbLFBattery)
        Me.Controls.Add(Me.lbLFAcSpeed)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.lbLRAcSpeed)
        Me.Controls.Add(Me.lbLRBattery)
        Me.Controls.Add(Me.lbLRMdl)
        Me.Controls.Add(Me.lbLRPre)
        Me.Controls.Add(Me.lbLRTemp)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label10)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(123, 98)
        Me.Name = "FrmMain"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "胎压检测初始化系统"
        CType(Me.Picture10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicNet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicInd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCommandReset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCommandConifg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCommandOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCommandLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCommandHis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MSComVIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MSCommBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
#End Region 
End Class