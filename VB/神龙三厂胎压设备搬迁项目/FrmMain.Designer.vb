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
	Public ToolTip1 As System.Windows.Forms.ToolTip
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
	Public WithEvents ImageList1 As AxComctlLib.AxImageList
	Public WithEvents ImageList As AxComctlLib.AxImageList
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
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmMain))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command12 = New System.Windows.Forms.Button
		Me.Command7 = New System.Windows.Forms.Button
		Me.Command4 = New System.Windows.Forms.Button
		Me.Command2 = New System.Windows.Forms.Button
		Me.Picture10 = New System.Windows.Forms.PictureBox
		Me.Timer_PrintError = New System.Windows.Forms.Timer(components)
		Me.Command1 = New System.Windows.Forms.Button
		Me.Timer_DataSync = New System.Windows.Forms.Timer(components)
		Me.Command3 = New System.Windows.Forms.Button
		Me.Command6 = New System.Windows.Forms.Button
		Me.Command5 = New System.Windows.Forms.Button
		Me.Command11 = New System.Windows.Forms.Button
		Me.Command10 = New System.Windows.Forms.Button
		Me.Command9 = New System.Windows.Forms.Button
		Me.Command8 = New System.Windows.Forms.Button
		Me.txtInputVIN = New System.Windows.Forms.TextBox
		Me.Command14 = New System.Windows.Forms.Button
		Me.Command17 = New System.Windows.Forms.Button
		Me.Text2 = New System.Windows.Forms.TextBox
		Me.List1 = New System.Windows.Forms.ListBox
		Me.txtVin = New System.Windows.Forms.TextBox
		Me.Timer_StatusQuery = New System.Windows.Forms.Timer(components)
		Me.ListMsg = New System.Windows.Forms.ListBox
		Me.txtRF = New System.Windows.Forms.TextBox
		Me.picRF = New System.Windows.Forms.PictureBox
		Me.txtRR = New System.Windows.Forms.TextBox
		Me.picRR = New System.Windows.Forms.PictureBox
		Me.txtLF = New System.Windows.Forms.TextBox
		Me.picLF = New System.Windows.Forms.PictureBox
		Me.txtLR = New System.Windows.Forms.TextBox
		Me.picLR = New System.Windows.Forms.PictureBox
		Me.Picture8 = New System.Windows.Forms.PictureBox
		Me.Picture7 = New System.Windows.Forms.PictureBox
		Me.Picture9 = New System.Windows.Forms.PictureBox
		Me.Picture6 = New System.Windows.Forms.PictureBox
		Me.PicNet = New System.Windows.Forms.PictureBox
		Me.PicInd = New System.Windows.Forms.PictureBox
		Me.picCommandReset = New System.Windows.Forms.PictureBox
		Me.picCommandConifg = New System.Windows.Forms.PictureBox
		Me.picCommandOut = New System.Windows.Forms.PictureBox
		Me.picCommandLog = New System.Windows.Forms.PictureBox
		Me.picCommandHis = New System.Windows.Forms.PictureBox
		Me.Picture1 = New System.Windows.Forms.PictureBox
		Me.picExit = New System.Windows.Forms.PictureBox
		Me.Picture4 = New System.Windows.Forms.PictureBox
		Me.MSComVIN = New AxMSCommLib.AxMSComm
		Me.MSCommBT = New AxMSCommLib.AxMSComm
		Me.Label15 = New System.Windows.Forms.Label
		Me.lbRFAcSpeed = New System.Windows.Forms.Label
		Me.lbRFBattery = New System.Windows.Forms.Label
		Me.lbRFMdl = New System.Windows.Forms.Label
		Me.lbRFPre = New System.Windows.Forms.Label
		Me.lbRFTemp = New System.Windows.Forms.Label
		Me.lbRRTemp = New System.Windows.Forms.Label
		Me.lbRRPre = New System.Windows.Forms.Label
		Me.lbRRMdl = New System.Windows.Forms.Label
		Me.lbRRBattery = New System.Windows.Forms.Label
		Me.lbRRAcSpeed = New System.Windows.Forms.Label
		Me.lbLFTemp = New System.Windows.Forms.Label
		Me.lbLFPre = New System.Windows.Forms.Label
		Me.lbLFMdl = New System.Windows.Forms.Label
		Me.lbLFBattery = New System.Windows.Forms.Label
		Me.lbLFAcSpeed = New System.Windows.Forms.Label
		Me.Label39 = New System.Windows.Forms.Label
		Me.lbLRAcSpeed = New System.Windows.Forms.Label
		Me.lbLRBattery = New System.Windows.Forms.Label
		Me.lbLRMdl = New System.Windows.Forms.Label
		Me.lbLRPre = New System.Windows.Forms.Label
		Me.lbLRTemp = New System.Windows.Forms.Label
		Me.Label33 = New System.Windows.Forms.Label
		Me.Label32 = New System.Windows.Forms.Label
		Me.Label31 = New System.Windows.Forms.Label
		Me.Label30 = New System.Windows.Forms.Label
		Me.Label29 = New System.Windows.Forms.Label
		Me.Label28 = New System.Windows.Forms.Label
		Me.Label27 = New System.Windows.Forms.Label
		Me.Label26 = New System.Windows.Forms.Label
		Me.Label25 = New System.Windows.Forms.Label
		Me.Label24 = New System.Windows.Forms.Label
		Me.Label22 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.ImageList1 = New AxComctlLib.AxImageList
		Me.ImageList = New AxComctlLib.AxImageList
		Me.lblStatus = New System.Windows.Forms.Label
		Me.Label17 = New System.Windows.Forms.Label
		Me.Label16 = New System.Windows.Forms.Label
		Me.Label13 = New System.Windows.Forms.Label
		Me.Label12 = New System.Windows.Forms.Label
		Me.Label11 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label23 = New System.Windows.Forms.Label
		Me.Label21 = New System.Windows.Forms.Label
		Me.Label20 = New System.Windows.Forms.Label
		Me.Label19 = New System.Windows.Forms.Label
		Me.Label18 = New System.Windows.Forms.Label
		Me.Label14 = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.MSComVIN, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.MSCommBT, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ImageList1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ImageList, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.SystemColors.Window
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Text = "胎压检测初始化系统"
		Me.ClientSize = New System.Drawing.Size(1024, 768)
		Me.Location = New System.Drawing.Point(123, 98)
		Me.Icon = CType(resources.GetObject("FrmMain.Icon"), System.Drawing.Icon)
		Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
		Me.BackgroundImage = CType(resources.GetObject("FrmMain.BackgroundImage"), System.Drawing.Image)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "FrmMain"
		Me.Command12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command12.Text = "十六进制转数字"
		Me.Command12.Size = New System.Drawing.Size(169, 45)
		Me.Command12.Location = New System.Drawing.Point(484, 304)
		Me.Command12.TabIndex = 96
		Me.Command12.Visible = False
		Me.Command12.BackColor = System.Drawing.SystemColors.Control
		Me.Command12.CausesValidation = True
		Me.Command12.Enabled = True
		Me.Command12.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command12.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command12.TabStop = True
		Me.Command12.Name = "Command12"
		Me.Command7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command7.Text = "Command7"
		Me.Command7.Size = New System.Drawing.Size(81, 33)
		Me.Command7.Location = New System.Drawing.Point(656, 496)
		Me.Command7.TabIndex = 95
		Me.Command7.Visible = False
		Me.Command7.BackColor = System.Drawing.SystemColors.Control
		Me.Command7.CausesValidation = True
		Me.Command7.Enabled = True
		Me.Command7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command7.TabStop = True
		Me.Command7.Name = "Command7"
		Me.Command4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command4.Text = "DoEvents"
		Me.Command4.Size = New System.Drawing.Size(89, 33)
		Me.Command4.Location = New System.Drawing.Point(544, 496)
		Me.Command4.TabIndex = 94
		Me.Command4.Visible = False
		Me.Command4.BackColor = System.Drawing.SystemColors.Control
		Me.Command4.CausesValidation = True
		Me.Command4.Enabled = True
		Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command4.TabStop = True
		Me.Command4.Name = "Command4"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "车辆进入工位"
		Me.Command2.Size = New System.Drawing.Size(93, 27)
		Me.Command2.Location = New System.Drawing.Point(220, 280)
		Me.Command2.TabIndex = 93
		Me.Command2.Visible = False
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Picture10.BackColor = System.Drawing.SystemColors.Window
		Me.Picture10.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Picture10.Size = New System.Drawing.Size(43, 28)
		Me.Picture10.Location = New System.Drawing.Point(24, 736)
		Me.Picture10.Image = CType(resources.GetObject("Picture10.Image"), System.Drawing.Image)
		Me.Picture10.TabIndex = 92
		Me.Picture10.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture10.CausesValidation = True
		Me.Picture10.Enabled = True
		Me.Picture10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture10.TabStop = True
		Me.Picture10.Visible = True
		Me.Picture10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Picture10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Picture10.Name = "Picture10"
		Me.Timer_PrintError.Enabled = False
		Me.Timer_PrintError.Interval = 1
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "解析VT520数据"
		Me.Command1.Size = New System.Drawing.Size(103, 29)
		Me.Command1.Location = New System.Drawing.Point(116, 662)
		Me.Command1.TabIndex = 90
		Me.Command1.Visible = False
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.Timer_DataSync.Enabled = False
		Me.Timer_DataSync.Interval = 1000
		Me.Command3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command3.Text = "系统锁定开关"
		Me.Command3.Size = New System.Drawing.Size(93, 27)
		Me.Command3.Location = New System.Drawing.Point(220, 240)
		Me.Command3.TabIndex = 49
		Me.Command3.Visible = False
		Me.Command3.BackColor = System.Drawing.SystemColors.Control
		Me.Command3.CausesValidation = True
		Me.Command3.Enabled = True
		Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command3.TabStop = True
		Me.Command3.Name = "Command3"
		Me.Command6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command6.Text = "传动解锁"
		Me.Command6.Size = New System.Drawing.Size(106, 31)
		Me.Command6.Location = New System.Drawing.Point(116, 626)
		Me.Command6.TabIndex = 48
		Me.Command6.Visible = False
		Me.Command6.BackColor = System.Drawing.SystemColors.Control
		Me.Command6.CausesValidation = True
		Me.Command6.Enabled = True
		Me.Command6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command6.TabStop = True
		Me.Command6.Name = "Command6"
		Me.Command5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command5.Text = "条码解锁"
		Me.Command5.Size = New System.Drawing.Size(106, 31)
		Me.Command5.Location = New System.Drawing.Point(4, 661)
		Me.Command5.TabIndex = 47
		Me.Command5.Visible = False
		Me.Command5.BackColor = System.Drawing.SystemColors.Control
		Me.Command5.CausesValidation = True
		Me.Command5.Enabled = True
		Me.Command5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command5.TabStop = True
		Me.Command5.Name = "Command5"
		Me.Command11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command11.Text = "左后轮"
		Me.Command11.Size = New System.Drawing.Size(93, 27)
		Me.Command11.Location = New System.Drawing.Point(220, 408)
		Me.Command11.TabIndex = 46
		Me.Command11.Visible = False
		Me.Command11.BackColor = System.Drawing.SystemColors.Control
		Me.Command11.CausesValidation = True
		Me.Command11.Enabled = True
		Me.Command11.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command11.TabStop = True
		Me.Command11.Name = "Command11"
		Me.Command10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command10.Text = "右后轮"
		Me.Command10.Size = New System.Drawing.Size(93, 27)
		Me.Command10.Location = New System.Drawing.Point(220, 376)
		Me.Command10.TabIndex = 45
		Me.Command10.Visible = False
		Me.Command10.BackColor = System.Drawing.SystemColors.Control
		Me.Command10.CausesValidation = True
		Me.Command10.Enabled = True
		Me.Command10.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command10.TabStop = True
		Me.Command10.Name = "Command10"
		Me.Command9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command9.Text = "左前轮"
		Me.Command9.Size = New System.Drawing.Size(93, 27)
		Me.Command9.Location = New System.Drawing.Point(220, 344)
		Me.Command9.TabIndex = 44
		Me.Command9.Visible = False
		Me.Command9.BackColor = System.Drawing.SystemColors.Control
		Me.Command9.CausesValidation = True
		Me.Command9.Enabled = True
		Me.Command9.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command9.TabStop = True
		Me.Command9.Name = "Command9"
		Me.Command8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command8.Text = "右前轮"
		Me.Command8.Size = New System.Drawing.Size(93, 27)
		Me.Command8.Location = New System.Drawing.Point(220, 312)
		Me.Command8.TabIndex = 43
		Me.Command8.Visible = False
		Me.Command8.BackColor = System.Drawing.SystemColors.Control
		Me.Command8.CausesValidation = True
		Me.Command8.Enabled = True
		Me.Command8.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command8.TabStop = True
		Me.Command8.Name = "Command8"
		Me.txtInputVIN.AutoSize = False
		Me.txtInputVIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtInputVIN.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.txtInputVIN.ForeColor = System.Drawing.Color.FromARGB(64, 64, 64)
		Me.txtInputVIN.Size = New System.Drawing.Size(223, 29)
		Me.txtInputVIN.Location = New System.Drawing.Point(0, 76)
		Me.txtInputVIN.TabIndex = 42
		Me.txtInputVIN.Text = "手工录入VIN，回车确认"
		Me.txtInputVIN.AcceptsReturn = True
		Me.txtInputVIN.CausesValidation = True
		Me.txtInputVIN.Enabled = True
		Me.txtInputVIN.HideSelection = True
		Me.txtInputVIN.ReadOnly = False
		Me.txtInputVIN.Maxlength = 0
		Me.txtInputVIN.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtInputVIN.MultiLine = False
		Me.txtInputVIN.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtInputVIN.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtInputVIN.TabStop = True
		Me.txtInputVIN.Visible = True
		Me.txtInputVIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtInputVIN.Name = "txtInputVIN"
		Me.Command14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command14.Text = "测试完成"
		Me.Command14.Size = New System.Drawing.Size(201, 33)
		Me.Command14.Location = New System.Drawing.Point(522, 182)
		Me.Command14.TabIndex = 41
		Me.Command14.Visible = False
		Me.Command14.BackColor = System.Drawing.SystemColors.Control
		Me.Command14.CausesValidation = True
		Me.Command14.Enabled = True
		Me.Command14.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command14.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command14.TabStop = True
		Me.Command14.Name = "Command14"
		Me.Command17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command17.Text = "扫描胎压码"
		Me.Command17.Size = New System.Drawing.Size(201, 33)
		Me.Command17.Location = New System.Drawing.Point(522, 146)
		Me.Command17.TabIndex = 40
		Me.Command17.Visible = False
		Me.Command17.BackColor = System.Drawing.SystemColors.Control
		Me.Command17.CausesValidation = True
		Me.Command17.Enabled = True
		Me.Command17.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command17.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command17.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command17.TabStop = True
		Me.Command17.Name = "Command17"
		Me.Text2.AutoSize = False
		Me.Text2.Size = New System.Drawing.Size(201, 25)
		Me.Text2.Location = New System.Drawing.Point(520, 116)
		Me.Text2.TabIndex = 39
		Me.Text2.Text = "LMGDK1G87B1S00037"
		Me.Text2.Visible = False
		Me.Text2.AcceptsReturn = True
		Me.Text2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.Text2.BackColor = System.Drawing.SystemColors.Window
		Me.Text2.CausesValidation = True
		Me.Text2.Enabled = True
		Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Text2.HideSelection = True
		Me.Text2.ReadOnly = False
		Me.Text2.Maxlength = 0
		Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text2.MultiLine = False
		Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.Text2.TabStop = True
		Me.Text2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Text2.Name = "Text2"
		Me.List1.Size = New System.Drawing.Size(145, 187)
		Me.List1.Location = New System.Drawing.Point(848, 256)
		Me.List1.TabIndex = 38
		Me.List1.Visible = False
		Me.List1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.List1.BackColor = System.Drawing.SystemColors.Window
		Me.List1.CausesValidation = True
		Me.List1.Enabled = True
		Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.List1.IntegralHeight = True
		Me.List1.Cursor = System.Windows.Forms.Cursors.Default
		Me.List1.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.List1.Sorted = False
		Me.List1.TabStop = True
		Me.List1.MultiColumn = False
		Me.List1.Name = "List1"
		Me.txtVin.AutoSize = False
		Me.txtVin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.txtVin.BackColor = System.Drawing.Color.FromARGB(8, 60, 123)
		Me.txtVin.Font = New System.Drawing.Font("宋体", 21.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtVin.ForeColor = System.Drawing.Color.White
		Me.txtVin.Size = New System.Drawing.Size(849, 30)
		Me.txtVin.Location = New System.Drawing.Point(172, 76)
		Me.txtVin.ReadOnly = True
		Me.txtVin.Maxlength = 17
		Me.txtVin.TabIndex = 37
		Me.txtVin.AcceptsReturn = True
		Me.txtVin.CausesValidation = True
		Me.txtVin.Enabled = True
		Me.txtVin.HideSelection = True
		Me.txtVin.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtVin.MultiLine = False
		Me.txtVin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtVin.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtVin.TabStop = True
		Me.txtVin.Visible = True
		Me.txtVin.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtVin.Name = "txtVin"
		Me.Timer_StatusQuery.Interval = 1000
		Me.Timer_StatusQuery.Enabled = True
		Me.ListMsg.Size = New System.Drawing.Size(737, 103)
		Me.ListMsg.Location = New System.Drawing.Point(260, 610)
		Me.ListMsg.TabIndex = 29
		Me.ListMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.ListMsg.BackColor = System.Drawing.SystemColors.Window
		Me.ListMsg.CausesValidation = True
		Me.ListMsg.Enabled = True
		Me.ListMsg.ForeColor = System.Drawing.SystemColors.WindowText
		Me.ListMsg.IntegralHeight = True
		Me.ListMsg.Cursor = System.Windows.Forms.Cursors.Default
		Me.ListMsg.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.ListMsg.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ListMsg.Sorted = False
		Me.ListMsg.TabStop = True
		Me.ListMsg.Visible = True
		Me.ListMsg.MultiColumn = False
		Me.ListMsg.Name = "ListMsg"
		Me.txtRF.AutoSize = False
		Me.txtRF.Font = New System.Drawing.Font("宋体", 20.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.txtRF.Size = New System.Drawing.Size(149, 27)
		Me.txtRF.Location = New System.Drawing.Point(826, 494)
		Me.txtRF.ReadOnly = True
		Me.txtRF.TabIndex = 26
		Me.txtRF.AcceptsReturn = True
		Me.txtRF.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtRF.BackColor = System.Drawing.SystemColors.Window
		Me.txtRF.CausesValidation = True
		Me.txtRF.Enabled = True
		Me.txtRF.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtRF.HideSelection = True
		Me.txtRF.Maxlength = 0
		Me.txtRF.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtRF.MultiLine = False
		Me.txtRF.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtRF.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtRF.TabStop = True
		Me.txtRF.Visible = True
		Me.txtRF.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtRF.Name = "txtRF"
		Me.picRF.BackColor = System.Drawing.SystemColors.Window
		Me.picRF.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picRF.Size = New System.Drawing.Size(28, 28)
		Me.picRF.Location = New System.Drawing.Point(764, 494)
		Me.picRF.Image = CType(resources.GetObject("picRF.Image"), System.Drawing.Image)
		Me.picRF.TabIndex = 25
		Me.picRF.Dock = System.Windows.Forms.DockStyle.None
		Me.picRF.CausesValidation = True
		Me.picRF.Enabled = True
		Me.picRF.Cursor = System.Windows.Forms.Cursors.Default
		Me.picRF.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picRF.TabStop = True
		Me.picRF.Visible = True
		Me.picRF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picRF.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picRF.Name = "picRF"
		Me.txtRR.AutoSize = False
		Me.txtRR.Font = New System.Drawing.Font("宋体", 20.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.txtRR.Size = New System.Drawing.Size(149, 27)
		Me.txtRR.Location = New System.Drawing.Point(336, 494)
		Me.txtRR.ReadOnly = True
		Me.txtRR.TabIndex = 23
		Me.txtRR.AcceptsReturn = True
		Me.txtRR.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtRR.BackColor = System.Drawing.SystemColors.Window
		Me.txtRR.CausesValidation = True
		Me.txtRR.Enabled = True
		Me.txtRR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtRR.HideSelection = True
		Me.txtRR.Maxlength = 0
		Me.txtRR.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtRR.MultiLine = False
		Me.txtRR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtRR.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtRR.TabStop = True
		Me.txtRR.Visible = True
		Me.txtRR.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtRR.Name = "txtRR"
		Me.picRR.BackColor = System.Drawing.SystemColors.Window
		Me.picRR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picRR.Size = New System.Drawing.Size(28, 28)
		Me.picRR.Location = New System.Drawing.Point(274, 494)
		Me.picRR.Image = CType(resources.GetObject("picRR.Image"), System.Drawing.Image)
		Me.picRR.TabIndex = 22
		Me.picRR.Dock = System.Windows.Forms.DockStyle.None
		Me.picRR.CausesValidation = True
		Me.picRR.Enabled = True
		Me.picRR.Cursor = System.Windows.Forms.Cursors.Default
		Me.picRR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picRR.TabStop = True
		Me.picRR.Visible = True
		Me.picRR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picRR.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picRR.Name = "picRR"
		Me.txtLF.AutoSize = False
		Me.txtLF.Font = New System.Drawing.Font("宋体", 20.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.txtLF.Size = New System.Drawing.Size(149, 27)
		Me.txtLF.Location = New System.Drawing.Point(824, 156)
		Me.txtLF.ReadOnly = True
		Me.txtLF.TabIndex = 20
		Me.txtLF.AcceptsReturn = True
		Me.txtLF.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtLF.BackColor = System.Drawing.SystemColors.Window
		Me.txtLF.CausesValidation = True
		Me.txtLF.Enabled = True
		Me.txtLF.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtLF.HideSelection = True
		Me.txtLF.Maxlength = 0
		Me.txtLF.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtLF.MultiLine = False
		Me.txtLF.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtLF.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtLF.TabStop = True
		Me.txtLF.Visible = True
		Me.txtLF.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtLF.Name = "txtLF"
		Me.picLF.BackColor = System.Drawing.SystemColors.Window
		Me.picLF.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picLF.Size = New System.Drawing.Size(28, 28)
		Me.picLF.Location = New System.Drawing.Point(766, 156)
		Me.picLF.Image = CType(resources.GetObject("picLF.Image"), System.Drawing.Image)
		Me.picLF.TabIndex = 19
		Me.picLF.Dock = System.Windows.Forms.DockStyle.None
		Me.picLF.CausesValidation = True
		Me.picLF.Enabled = True
		Me.picLF.Cursor = System.Windows.Forms.Cursors.Default
		Me.picLF.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picLF.TabStop = True
		Me.picLF.Visible = True
		Me.picLF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picLF.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picLF.Name = "picLF"
		Me.txtLR.AutoSize = False
		Me.txtLR.Font = New System.Drawing.Font("宋体", 18!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.txtLR.Size = New System.Drawing.Size(149, 27)
		Me.txtLR.Location = New System.Drawing.Point(332, 156)
		Me.txtLR.ReadOnly = True
		Me.txtLR.TabIndex = 17
		Me.txtLR.AcceptsReturn = True
		Me.txtLR.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtLR.BackColor = System.Drawing.SystemColors.Window
		Me.txtLR.CausesValidation = True
		Me.txtLR.Enabled = True
		Me.txtLR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtLR.HideSelection = True
		Me.txtLR.Maxlength = 0
		Me.txtLR.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtLR.MultiLine = False
		Me.txtLR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtLR.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtLR.TabStop = True
		Me.txtLR.Visible = True
		Me.txtLR.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtLR.Name = "txtLR"
		Me.picLR.BackColor = System.Drawing.SystemColors.Window
		Me.picLR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picLR.Size = New System.Drawing.Size(28, 28)
		Me.picLR.Location = New System.Drawing.Point(274, 156)
		Me.picLR.Image = CType(resources.GetObject("picLR.Image"), System.Drawing.Image)
		Me.picLR.TabIndex = 16
		Me.picLR.Dock = System.Windows.Forms.DockStyle.None
		Me.picLR.CausesValidation = True
		Me.picLR.Enabled = True
		Me.picLR.Cursor = System.Windows.Forms.Cursors.Default
		Me.picLR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picLR.TabStop = True
		Me.picLR.Visible = True
		Me.picLR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picLR.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picLR.Name = "picLR"
		Me.Picture8.BackColor = System.Drawing.SystemColors.Window
		Me.Picture8.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Picture8.Size = New System.Drawing.Size(28, 28)
		Me.Picture8.Location = New System.Drawing.Point(38, 568)
		Me.Picture8.Image = CType(resources.GetObject("Picture8.Image"), System.Drawing.Image)
		Me.Picture8.TabIndex = 15
		Me.Picture8.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture8.CausesValidation = True
		Me.Picture8.Enabled = True
		Me.Picture8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture8.TabStop = True
		Me.Picture8.Visible = True
		Me.Picture8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Picture8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Picture8.Name = "Picture8"
		Me.Picture7.BackColor = System.Drawing.SystemColors.Window
		Me.Picture7.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Picture7.Size = New System.Drawing.Size(28, 28)
		Me.Picture7.Location = New System.Drawing.Point(38, 498)
		Me.Picture7.Image = CType(resources.GetObject("Picture7.Image"), System.Drawing.Image)
		Me.Picture7.TabIndex = 14
		Me.Picture7.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture7.CausesValidation = True
		Me.Picture7.Enabled = True
		Me.Picture7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture7.TabStop = True
		Me.Picture7.Visible = True
		Me.Picture7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Picture7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Picture7.Name = "Picture7"
		Me.Picture9.BackColor = System.Drawing.SystemColors.Window
		Me.Picture9.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Picture9.Size = New System.Drawing.Size(28, 28)
		Me.Picture9.Location = New System.Drawing.Point(38, 420)
		Me.Picture9.Image = CType(resources.GetObject("Picture9.Image"), System.Drawing.Image)
		Me.Picture9.TabIndex = 13
		Me.Picture9.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture9.CausesValidation = True
		Me.Picture9.Enabled = True
		Me.Picture9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture9.TabStop = True
		Me.Picture9.Visible = True
		Me.Picture9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Picture9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Picture9.Name = "Picture9"
		Me.Picture6.BackColor = System.Drawing.SystemColors.Window
		Me.Picture6.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Picture6.Size = New System.Drawing.Size(28, 28)
		Me.Picture6.Location = New System.Drawing.Point(38, 338)
		Me.Picture6.Image = CType(resources.GetObject("Picture6.Image"), System.Drawing.Image)
		Me.Picture6.TabIndex = 12
		Me.Picture6.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture6.CausesValidation = True
		Me.Picture6.Enabled = True
		Me.Picture6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture6.TabStop = True
		Me.Picture6.Visible = True
		Me.Picture6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Picture6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Picture6.Name = "Picture6"
		Me.PicNet.BackColor = System.Drawing.SystemColors.Window
		Me.PicNet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.PicNet.Size = New System.Drawing.Size(28, 28)
		Me.PicNet.Location = New System.Drawing.Point(38, 258)
		Me.PicNet.Image = CType(resources.GetObject("PicNet.Image"), System.Drawing.Image)
		Me.PicNet.TabIndex = 11
		Me.PicNet.Dock = System.Windows.Forms.DockStyle.None
		Me.PicNet.CausesValidation = True
		Me.PicNet.Enabled = True
		Me.PicNet.Cursor = System.Windows.Forms.Cursors.Default
		Me.PicNet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.PicNet.TabStop = True
		Me.PicNet.Visible = True
		Me.PicNet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.PicNet.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.PicNet.Name = "PicNet"
		Me.PicInd.BackColor = System.Drawing.SystemColors.Window
		Me.PicInd.ForeColor = System.Drawing.SystemColors.WindowText
		Me.PicInd.Size = New System.Drawing.Size(28, 28)
		Me.PicInd.Location = New System.Drawing.Point(38, 184)
		Me.PicInd.Image = CType(resources.GetObject("PicInd.Image"), System.Drawing.Image)
		Me.PicInd.TabIndex = 10
		Me.PicInd.Dock = System.Windows.Forms.DockStyle.None
		Me.PicInd.CausesValidation = True
		Me.PicInd.Enabled = True
		Me.PicInd.Cursor = System.Windows.Forms.Cursors.Default
		Me.PicInd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.PicInd.TabStop = True
		Me.PicInd.Visible = True
		Me.PicInd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.PicInd.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.PicInd.Name = "PicInd"
		Me.picCommandReset.BackColor = System.Drawing.SystemColors.Window
		Me.picCommandReset.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picCommandReset.Size = New System.Drawing.Size(105, 39)
		Me.picCommandReset.Location = New System.Drawing.Point(638, 33)
		Me.picCommandReset.Image = CType(resources.GetObject("picCommandReset.Image"), System.Drawing.Image)
		Me.picCommandReset.TabIndex = 7
		Me.picCommandReset.Dock = System.Windows.Forms.DockStyle.None
		Me.picCommandReset.CausesValidation = True
		Me.picCommandReset.Enabled = True
		Me.picCommandReset.Cursor = System.Windows.Forms.Cursors.Default
		Me.picCommandReset.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picCommandReset.TabStop = True
		Me.picCommandReset.Visible = True
		Me.picCommandReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picCommandReset.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picCommandReset.Name = "picCommandReset"
		Me.picCommandConifg.BackColor = System.Drawing.SystemColors.Window
		Me.picCommandConifg.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picCommandConifg.Size = New System.Drawing.Size(104, 39)
		Me.picCommandConifg.Location = New System.Drawing.Point(534, 33)
		Me.picCommandConifg.Image = CType(resources.GetObject("picCommandConifg.Image"), System.Drawing.Image)
		Me.picCommandConifg.TabIndex = 6
		Me.picCommandConifg.Dock = System.Windows.Forms.DockStyle.None
		Me.picCommandConifg.CausesValidation = True
		Me.picCommandConifg.Enabled = True
		Me.picCommandConifg.Cursor = System.Windows.Forms.Cursors.Default
		Me.picCommandConifg.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picCommandConifg.TabStop = True
		Me.picCommandConifg.Visible = True
		Me.picCommandConifg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picCommandConifg.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picCommandConifg.Name = "picCommandConifg"
		Me.picCommandOut.BackColor = System.Drawing.SystemColors.Window
		Me.picCommandOut.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picCommandOut.Size = New System.Drawing.Size(105, 39)
		Me.picCommandOut.Location = New System.Drawing.Point(430, 33)
		Me.picCommandOut.Image = CType(resources.GetObject("picCommandOut.Image"), System.Drawing.Image)
		Me.picCommandOut.TabIndex = 5
		Me.picCommandOut.Dock = System.Windows.Forms.DockStyle.None
		Me.picCommandOut.CausesValidation = True
		Me.picCommandOut.Enabled = True
		Me.picCommandOut.Cursor = System.Windows.Forms.Cursors.Default
		Me.picCommandOut.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picCommandOut.TabStop = True
		Me.picCommandOut.Visible = True
		Me.picCommandOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picCommandOut.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picCommandOut.Name = "picCommandOut"
		Me.picCommandLog.BackColor = System.Drawing.SystemColors.Window
		Me.picCommandLog.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picCommandLog.Size = New System.Drawing.Size(105, 39)
		Me.picCommandLog.Location = New System.Drawing.Point(326, 33)
		Me.picCommandLog.Image = CType(resources.GetObject("picCommandLog.Image"), System.Drawing.Image)
		Me.picCommandLog.TabIndex = 4
		Me.picCommandLog.Dock = System.Windows.Forms.DockStyle.None
		Me.picCommandLog.CausesValidation = True
		Me.picCommandLog.Enabled = True
		Me.picCommandLog.Cursor = System.Windows.Forms.Cursors.Default
		Me.picCommandLog.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picCommandLog.TabStop = True
		Me.picCommandLog.Visible = True
		Me.picCommandLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picCommandLog.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picCommandLog.Name = "picCommandLog"
		Me.picCommandHis.BackColor = System.Drawing.SystemColors.Window
		Me.picCommandHis.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picCommandHis.Size = New System.Drawing.Size(105, 39)
		Me.picCommandHis.Location = New System.Drawing.Point(221, 33)
		Me.picCommandHis.Image = CType(resources.GetObject("picCommandHis.Image"), System.Drawing.Image)
		Me.picCommandHis.TabIndex = 3
		Me.picCommandHis.Dock = System.Windows.Forms.DockStyle.None
		Me.picCommandHis.CausesValidation = True
		Me.picCommandHis.Enabled = True
		Me.picCommandHis.Cursor = System.Windows.Forms.Cursors.Default
		Me.picCommandHis.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picCommandHis.TabStop = True
		Me.picCommandHis.Visible = True
		Me.picCommandHis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picCommandHis.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picCommandHis.Name = "picCommandHis"
		Me.Picture1.BackColor = System.Drawing.SystemColors.Window
		Me.Picture1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Picture1.Size = New System.Drawing.Size(33, 24)
		Me.Picture1.Location = New System.Drawing.Point(950, 0)
		Me.Picture1.Image = CType(resources.GetObject("Picture1.Image"), System.Drawing.Image)
		Me.Picture1.TabIndex = 2
		Me.Picture1.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture1.CausesValidation = True
		Me.Picture1.Enabled = True
		Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture1.TabStop = True
		Me.Picture1.Visible = True
		Me.Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Picture1.Name = "Picture1"
		Me.picExit.BackColor = System.Drawing.SystemColors.Window
		Me.picExit.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picExit.Size = New System.Drawing.Size(33, 24)
		Me.picExit.Location = New System.Drawing.Point(983, 0)
		Me.picExit.Image = CType(resources.GetObject("picExit.Image"), System.Drawing.Image)
		Me.picExit.TabIndex = 1
		Me.picExit.Dock = System.Windows.Forms.DockStyle.None
		Me.picExit.CausesValidation = True
		Me.picExit.Enabled = True
		Me.picExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.picExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picExit.TabStop = True
		Me.picExit.Visible = True
		Me.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.picExit.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picExit.Name = "picExit"
		Me.Picture4.BackColor = System.Drawing.SystemColors.Window
		Me.Picture4.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Picture4.Size = New System.Drawing.Size(299, 30)
		Me.Picture4.Location = New System.Drawing.Point(0, 2)
		Me.Picture4.Image = CType(resources.GetObject("Picture4.Image"), System.Drawing.Image)
		Me.Picture4.TabIndex = 0
		Me.Picture4.Dock = System.Windows.Forms.DockStyle.None
		Me.Picture4.CausesValidation = True
		Me.Picture4.Enabled = True
		Me.Picture4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture4.TabStop = True
		Me.Picture4.Visible = True
		Me.Picture4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Picture4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Picture4.Name = "Picture4"
		MSComVIN.OcxState = CType(resources.GetObject("MSComVIN.OcxState"), System.Windows.Forms.AxHost.State)
		Me.MSComVIN.Location = New System.Drawing.Point(156, 124)
		Me.MSComVIN.Name = "MSComVIN"
		MSCommBT.OcxState = CType(resources.GetObject("MSCommBT.OcxState"), System.Windows.Forms.AxHost.State)
		Me.MSCommBT.Location = New System.Drawing.Point(200, 124)
		Me.MSCommBT.Name = "MSCommBT"
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label15.BackColor = System.Drawing.Color.Transparent
		Me.Label15.Text = "华信数据"
		Me.Label15.Font = New System.Drawing.Font("新宋体", 15.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label15.ForeColor = System.Drawing.Color.FromARGB(64, 64, 64)
		Me.Label15.Size = New System.Drawing.Size(94, 21)
		Me.Label15.Location = New System.Drawing.Point(72, 740)
		Me.Label15.TabIndex = 91
		Me.Label15.Enabled = True
		Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label15.UseMnemonic = True
		Me.Label15.Visible = True
		Me.Label15.AutoSize = False
		Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label15.Name = "Label15"
		Me.lbRFAcSpeed.Text = "123"
		Me.lbRFAcSpeed.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbRFAcSpeed.ForeColor = System.Drawing.Color.Blue
		Me.lbRFAcSpeed.Size = New System.Drawing.Size(94, 21)
		Me.lbRFAcSpeed.Location = New System.Drawing.Point(874, 542)
		Me.lbRFAcSpeed.TabIndex = 89
		Me.lbRFAcSpeed.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbRFAcSpeed.BackColor = System.Drawing.Color.Transparent
		Me.lbRFAcSpeed.Enabled = True
		Me.lbRFAcSpeed.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbRFAcSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbRFAcSpeed.UseMnemonic = True
		Me.lbRFAcSpeed.Visible = True
		Me.lbRFAcSpeed.AutoSize = False
		Me.lbRFAcSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbRFAcSpeed.Name = "lbRFAcSpeed"
		Me.lbRFBattery.Text = "123"
		Me.lbRFBattery.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbRFBattery.ForeColor = System.Drawing.Color.Blue
		Me.lbRFBattery.Size = New System.Drawing.Size(34, 21)
		Me.lbRFBattery.Location = New System.Drawing.Point(798, 542)
		Me.lbRFBattery.TabIndex = 88
		Me.lbRFBattery.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbRFBattery.BackColor = System.Drawing.Color.Transparent
		Me.lbRFBattery.Enabled = True
		Me.lbRFBattery.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbRFBattery.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbRFBattery.UseMnemonic = True
		Me.lbRFBattery.Visible = True
		Me.lbRFBattery.AutoSize = False
		Me.lbRFBattery.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbRFBattery.Name = "lbRFBattery"
		Me.lbRFMdl.Text = "123"
		Me.lbRFMdl.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbRFMdl.ForeColor = System.Drawing.Color.Blue
		Me.lbRFMdl.Size = New System.Drawing.Size(36, 21)
		Me.lbRFMdl.Location = New System.Drawing.Point(798, 526)
		Me.lbRFMdl.TabIndex = 87
		Me.lbRFMdl.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbRFMdl.BackColor = System.Drawing.Color.Transparent
		Me.lbRFMdl.Enabled = True
		Me.lbRFMdl.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbRFMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbRFMdl.UseMnemonic = True
		Me.lbRFMdl.Visible = True
		Me.lbRFMdl.AutoSize = False
		Me.lbRFMdl.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbRFMdl.Name = "lbRFMdl"
		Me.lbRFPre.Text = "123"
		Me.lbRFPre.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbRFPre.ForeColor = System.Drawing.Color.Blue
		Me.lbRFPre.Size = New System.Drawing.Size(62, 21)
		Me.lbRFPre.Location = New System.Drawing.Point(860, 526)
		Me.lbRFPre.TabIndex = 86
		Me.lbRFPre.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbRFPre.BackColor = System.Drawing.Color.Transparent
		Me.lbRFPre.Enabled = True
		Me.lbRFPre.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbRFPre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbRFPre.UseMnemonic = True
		Me.lbRFPre.Visible = True
		Me.lbRFPre.AutoSize = False
		Me.lbRFPre.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbRFPre.Name = "lbRFPre"
		Me.lbRFTemp.Text = "123"
		Me.lbRFTemp.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbRFTemp.ForeColor = System.Drawing.Color.Blue
		Me.lbRFTemp.Size = New System.Drawing.Size(62, 21)
		Me.lbRFTemp.Location = New System.Drawing.Point(950, 526)
		Me.lbRFTemp.TabIndex = 85
		Me.lbRFTemp.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbRFTemp.BackColor = System.Drawing.Color.Transparent
		Me.lbRFTemp.Enabled = True
		Me.lbRFTemp.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbRFTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbRFTemp.UseMnemonic = True
		Me.lbRFTemp.Visible = True
		Me.lbRFTemp.AutoSize = False
		Me.lbRFTemp.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbRFTemp.Name = "lbRFTemp"
		Me.lbRRTemp.Text = "123"
		Me.lbRRTemp.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbRRTemp.ForeColor = System.Drawing.Color.Blue
		Me.lbRRTemp.Size = New System.Drawing.Size(62, 21)
		Me.lbRRTemp.Location = New System.Drawing.Point(460, 524)
		Me.lbRRTemp.TabIndex = 84
		Me.lbRRTemp.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbRRTemp.BackColor = System.Drawing.Color.Transparent
		Me.lbRRTemp.Enabled = True
		Me.lbRRTemp.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbRRTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbRRTemp.UseMnemonic = True
		Me.lbRRTemp.Visible = True
		Me.lbRRTemp.AutoSize = False
		Me.lbRRTemp.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbRRTemp.Name = "lbRRTemp"
		Me.lbRRPre.Text = "123"
		Me.lbRRPre.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbRRPre.ForeColor = System.Drawing.Color.Blue
		Me.lbRRPre.Size = New System.Drawing.Size(62, 21)
		Me.lbRRPre.Location = New System.Drawing.Point(370, 524)
		Me.lbRRPre.TabIndex = 83
		Me.lbRRPre.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbRRPre.BackColor = System.Drawing.Color.Transparent
		Me.lbRRPre.Enabled = True
		Me.lbRRPre.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbRRPre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbRRPre.UseMnemonic = True
		Me.lbRRPre.Visible = True
		Me.lbRRPre.AutoSize = False
		Me.lbRRPre.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbRRPre.Name = "lbRRPre"
		Me.lbRRMdl.Text = "123"
		Me.lbRRMdl.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbRRMdl.ForeColor = System.Drawing.Color.Blue
		Me.lbRRMdl.Size = New System.Drawing.Size(36, 21)
		Me.lbRRMdl.Location = New System.Drawing.Point(306, 524)
		Me.lbRRMdl.TabIndex = 82
		Me.lbRRMdl.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbRRMdl.BackColor = System.Drawing.Color.Transparent
		Me.lbRRMdl.Enabled = True
		Me.lbRRMdl.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbRRMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbRRMdl.UseMnemonic = True
		Me.lbRRMdl.Visible = True
		Me.lbRRMdl.AutoSize = False
		Me.lbRRMdl.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbRRMdl.Name = "lbRRMdl"
		Me.lbRRBattery.Text = "123"
		Me.lbRRBattery.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbRRBattery.ForeColor = System.Drawing.Color.Blue
		Me.lbRRBattery.Size = New System.Drawing.Size(34, 21)
		Me.lbRRBattery.Location = New System.Drawing.Point(306, 540)
		Me.lbRRBattery.TabIndex = 81
		Me.lbRRBattery.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbRRBattery.BackColor = System.Drawing.Color.Transparent
		Me.lbRRBattery.Enabled = True
		Me.lbRRBattery.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbRRBattery.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbRRBattery.UseMnemonic = True
		Me.lbRRBattery.Visible = True
		Me.lbRRBattery.AutoSize = False
		Me.lbRRBattery.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbRRBattery.Name = "lbRRBattery"
		Me.lbRRAcSpeed.Text = "123"
		Me.lbRRAcSpeed.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbRRAcSpeed.ForeColor = System.Drawing.Color.Blue
		Me.lbRRAcSpeed.Size = New System.Drawing.Size(94, 21)
		Me.lbRRAcSpeed.Location = New System.Drawing.Point(384, 540)
		Me.lbRRAcSpeed.TabIndex = 80
		Me.lbRRAcSpeed.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbRRAcSpeed.BackColor = System.Drawing.Color.Transparent
		Me.lbRRAcSpeed.Enabled = True
		Me.lbRRAcSpeed.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbRRAcSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbRRAcSpeed.UseMnemonic = True
		Me.lbRRAcSpeed.Visible = True
		Me.lbRRAcSpeed.AutoSize = False
		Me.lbRRAcSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbRRAcSpeed.Name = "lbRRAcSpeed"
		Me.lbLFTemp.Text = "123"
		Me.lbLFTemp.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbLFTemp.ForeColor = System.Drawing.Color.Blue
		Me.lbLFTemp.Size = New System.Drawing.Size(62, 21)
		Me.lbLFTemp.Location = New System.Drawing.Point(952, 186)
		Me.lbLFTemp.TabIndex = 79
		Me.lbLFTemp.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbLFTemp.BackColor = System.Drawing.Color.Transparent
		Me.lbLFTemp.Enabled = True
		Me.lbLFTemp.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbLFTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbLFTemp.UseMnemonic = True
		Me.lbLFTemp.Visible = True
		Me.lbLFTemp.AutoSize = False
		Me.lbLFTemp.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbLFTemp.Name = "lbLFTemp"
		Me.lbLFPre.Text = "123"
		Me.lbLFPre.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbLFPre.ForeColor = System.Drawing.Color.Blue
		Me.lbLFPre.Size = New System.Drawing.Size(62, 21)
		Me.lbLFPre.Location = New System.Drawing.Point(862, 186)
		Me.lbLFPre.TabIndex = 78
		Me.lbLFPre.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbLFPre.BackColor = System.Drawing.Color.Transparent
		Me.lbLFPre.Enabled = True
		Me.lbLFPre.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbLFPre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbLFPre.UseMnemonic = True
		Me.lbLFPre.Visible = True
		Me.lbLFPre.AutoSize = False
		Me.lbLFPre.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbLFPre.Name = "lbLFPre"
		Me.lbLFMdl.Text = "123"
		Me.lbLFMdl.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbLFMdl.ForeColor = System.Drawing.Color.Blue
		Me.lbLFMdl.Size = New System.Drawing.Size(36, 21)
		Me.lbLFMdl.Location = New System.Drawing.Point(800, 186)
		Me.lbLFMdl.TabIndex = 77
		Me.lbLFMdl.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbLFMdl.BackColor = System.Drawing.Color.Transparent
		Me.lbLFMdl.Enabled = True
		Me.lbLFMdl.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbLFMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbLFMdl.UseMnemonic = True
		Me.lbLFMdl.Visible = True
		Me.lbLFMdl.AutoSize = False
		Me.lbLFMdl.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbLFMdl.Name = "lbLFMdl"
		Me.lbLFBattery.Text = "123"
		Me.lbLFBattery.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbLFBattery.ForeColor = System.Drawing.Color.Blue
		Me.lbLFBattery.Size = New System.Drawing.Size(34, 21)
		Me.lbLFBattery.Location = New System.Drawing.Point(800, 202)
		Me.lbLFBattery.TabIndex = 76
		Me.lbLFBattery.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbLFBattery.BackColor = System.Drawing.Color.Transparent
		Me.lbLFBattery.Enabled = True
		Me.lbLFBattery.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbLFBattery.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbLFBattery.UseMnemonic = True
		Me.lbLFBattery.Visible = True
		Me.lbLFBattery.AutoSize = False
		Me.lbLFBattery.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbLFBattery.Name = "lbLFBattery"
		Me.lbLFAcSpeed.Text = "123"
		Me.lbLFAcSpeed.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbLFAcSpeed.ForeColor = System.Drawing.Color.Blue
		Me.lbLFAcSpeed.Size = New System.Drawing.Size(94, 21)
		Me.lbLFAcSpeed.Location = New System.Drawing.Point(876, 202)
		Me.lbLFAcSpeed.TabIndex = 75
		Me.lbLFAcSpeed.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbLFAcSpeed.BackColor = System.Drawing.Color.Transparent
		Me.lbLFAcSpeed.Enabled = True
		Me.lbLFAcSpeed.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbLFAcSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbLFAcSpeed.UseMnemonic = True
		Me.lbLFAcSpeed.Visible = True
		Me.lbLFAcSpeed.AutoSize = False
		Me.lbLFAcSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbLFAcSpeed.Name = "lbLFAcSpeed"
		Me.Label39.Text = "模式："
		Me.Label39.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label39.ForeColor = System.Drawing.Color.Black
		Me.Label39.Size = New System.Drawing.Size(48, 21)
		Me.Label39.Location = New System.Drawing.Point(272, 186)
		Me.Label39.TabIndex = 74
		Me.Label39.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label39.BackColor = System.Drawing.Color.Transparent
		Me.Label39.Enabled = True
		Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label39.UseMnemonic = True
		Me.Label39.Visible = True
		Me.Label39.AutoSize = False
		Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label39.Name = "Label39"
		Me.lbLRAcSpeed.Text = "123"
		Me.lbLRAcSpeed.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbLRAcSpeed.ForeColor = System.Drawing.Color.Blue
		Me.lbLRAcSpeed.Size = New System.Drawing.Size(94, 21)
		Me.lbLRAcSpeed.Location = New System.Drawing.Point(386, 202)
		Me.lbLRAcSpeed.TabIndex = 73
		Me.lbLRAcSpeed.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbLRAcSpeed.BackColor = System.Drawing.Color.Transparent
		Me.lbLRAcSpeed.Enabled = True
		Me.lbLRAcSpeed.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbLRAcSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbLRAcSpeed.UseMnemonic = True
		Me.lbLRAcSpeed.Visible = True
		Me.lbLRAcSpeed.AutoSize = False
		Me.lbLRAcSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbLRAcSpeed.Name = "lbLRAcSpeed"
		Me.lbLRBattery.Text = "123"
		Me.lbLRBattery.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbLRBattery.ForeColor = System.Drawing.Color.Blue
		Me.lbLRBattery.Size = New System.Drawing.Size(34, 21)
		Me.lbLRBattery.Location = New System.Drawing.Point(310, 202)
		Me.lbLRBattery.TabIndex = 72
		Me.lbLRBattery.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbLRBattery.BackColor = System.Drawing.Color.Transparent
		Me.lbLRBattery.Enabled = True
		Me.lbLRBattery.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbLRBattery.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbLRBattery.UseMnemonic = True
		Me.lbLRBattery.Visible = True
		Me.lbLRBattery.AutoSize = False
		Me.lbLRBattery.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbLRBattery.Name = "lbLRBattery"
		Me.lbLRMdl.Text = "123"
		Me.lbLRMdl.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbLRMdl.ForeColor = System.Drawing.Color.Blue
		Me.lbLRMdl.Size = New System.Drawing.Size(36, 21)
		Me.lbLRMdl.Location = New System.Drawing.Point(310, 186)
		Me.lbLRMdl.TabIndex = 71
		Me.lbLRMdl.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbLRMdl.BackColor = System.Drawing.Color.Transparent
		Me.lbLRMdl.Enabled = True
		Me.lbLRMdl.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbLRMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbLRMdl.UseMnemonic = True
		Me.lbLRMdl.Visible = True
		Me.lbLRMdl.AutoSize = False
		Me.lbLRMdl.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbLRMdl.Name = "lbLRMdl"
		Me.lbLRPre.Text = "123"
		Me.lbLRPre.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbLRPre.ForeColor = System.Drawing.Color.Blue
		Me.lbLRPre.Size = New System.Drawing.Size(62, 21)
		Me.lbLRPre.Location = New System.Drawing.Point(372, 186)
		Me.lbLRPre.TabIndex = 70
		Me.lbLRPre.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbLRPre.BackColor = System.Drawing.Color.Transparent
		Me.lbLRPre.Enabled = True
		Me.lbLRPre.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbLRPre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbLRPre.UseMnemonic = True
		Me.lbLRPre.Visible = True
		Me.lbLRPre.AutoSize = False
		Me.lbLRPre.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbLRPre.Name = "lbLRPre"
		Me.lbLRTemp.Text = "123"
		Me.lbLRTemp.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbLRTemp.ForeColor = System.Drawing.Color.Blue
		Me.lbLRTemp.Size = New System.Drawing.Size(62, 21)
		Me.lbLRTemp.Location = New System.Drawing.Point(462, 186)
		Me.lbLRTemp.TabIndex = 69
		Me.lbLRTemp.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbLRTemp.BackColor = System.Drawing.Color.Transparent
		Me.lbLRTemp.Enabled = True
		Me.lbLRTemp.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbLRTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbLRTemp.UseMnemonic = True
		Me.lbLRTemp.Visible = True
		Me.lbLRTemp.AutoSize = False
		Me.lbLRTemp.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbLRTemp.Name = "lbLRTemp"
		Me.Label33.Text = "模式："
		Me.Label33.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label33.ForeColor = System.Drawing.Color.Black
		Me.Label33.Size = New System.Drawing.Size(76, 21)
		Me.Label33.Location = New System.Drawing.Point(760, 526)
		Me.Label33.TabIndex = 68
		Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label33.BackColor = System.Drawing.Color.Transparent
		Me.Label33.Enabled = True
		Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label33.UseMnemonic = True
		Me.Label33.Visible = True
		Me.Label33.AutoSize = False
		Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label33.Name = "Label33"
		Me.Label32.Text = "压力："
		Me.Label32.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label32.ForeColor = System.Drawing.Color.Black
		Me.Label32.Size = New System.Drawing.Size(80, 21)
		Me.Label32.Location = New System.Drawing.Point(822, 526)
		Me.Label32.TabIndex = 67
		Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label32.BackColor = System.Drawing.Color.Transparent
		Me.Label32.Enabled = True
		Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label32.UseMnemonic = True
		Me.Label32.Visible = True
		Me.Label32.AutoSize = False
		Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label32.Name = "Label32"
		Me.Label31.Text = "温度："
		Me.Label31.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label31.ForeColor = System.Drawing.Color.Black
		Me.Label31.Size = New System.Drawing.Size(80, 21)
		Me.Label31.Location = New System.Drawing.Point(912, 526)
		Me.Label31.TabIndex = 66
		Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label31.BackColor = System.Drawing.Color.Transparent
		Me.Label31.Enabled = True
		Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label31.UseMnemonic = True
		Me.Label31.Visible = True
		Me.Label31.AutoSize = False
		Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label31.Name = "Label31"
		Me.Label30.Text = "加速度："
		Me.Label30.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label30.ForeColor = System.Drawing.Color.Black
		Me.Label30.Size = New System.Drawing.Size(80, 21)
		Me.Label30.Location = New System.Drawing.Point(822, 542)
		Me.Label30.TabIndex = 65
		Me.Label30.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label30.BackColor = System.Drawing.Color.Transparent
		Me.Label30.Enabled = True
		Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label30.UseMnemonic = True
		Me.Label30.Visible = True
		Me.Label30.AutoSize = False
		Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label30.Name = "Label30"
		Me.Label29.Text = "电池："
		Me.Label29.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label29.ForeColor = System.Drawing.Color.Black
		Me.Label29.Size = New System.Drawing.Size(80, 21)
		Me.Label29.Location = New System.Drawing.Point(760, 542)
		Me.Label29.TabIndex = 64
		Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label29.BackColor = System.Drawing.Color.Transparent
		Me.Label29.Enabled = True
		Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label29.UseMnemonic = True
		Me.Label29.Visible = True
		Me.Label29.AutoSize = False
		Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label29.Name = "Label29"
		Me.Label28.Text = "模式："
		Me.Label28.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label28.ForeColor = System.Drawing.Color.Black
		Me.Label28.Size = New System.Drawing.Size(76, 21)
		Me.Label28.Location = New System.Drawing.Point(270, 524)
		Me.Label28.TabIndex = 63
		Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label28.BackColor = System.Drawing.Color.Transparent
		Me.Label28.Enabled = True
		Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label28.UseMnemonic = True
		Me.Label28.Visible = True
		Me.Label28.AutoSize = False
		Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label28.Name = "Label28"
		Me.Label27.Text = "压力："
		Me.Label27.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label27.ForeColor = System.Drawing.Color.Black
		Me.Label27.Size = New System.Drawing.Size(80, 21)
		Me.Label27.Location = New System.Drawing.Point(332, 524)
		Me.Label27.TabIndex = 62
		Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label27.BackColor = System.Drawing.Color.Transparent
		Me.Label27.Enabled = True
		Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label27.UseMnemonic = True
		Me.Label27.Visible = True
		Me.Label27.AutoSize = False
		Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label27.Name = "Label27"
		Me.Label26.Text = "温度："
		Me.Label26.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label26.ForeColor = System.Drawing.Color.Black
		Me.Label26.Size = New System.Drawing.Size(80, 21)
		Me.Label26.Location = New System.Drawing.Point(422, 524)
		Me.Label26.TabIndex = 61
		Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label26.BackColor = System.Drawing.Color.Transparent
		Me.Label26.Enabled = True
		Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label26.UseMnemonic = True
		Me.Label26.Visible = True
		Me.Label26.AutoSize = False
		Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label26.Name = "Label26"
		Me.Label25.Text = "加速度："
		Me.Label25.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label25.ForeColor = System.Drawing.Color.Black
		Me.Label25.Size = New System.Drawing.Size(80, 21)
		Me.Label25.Location = New System.Drawing.Point(332, 540)
		Me.Label25.TabIndex = 60
		Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label25.BackColor = System.Drawing.Color.Transparent
		Me.Label25.Enabled = True
		Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label25.UseMnemonic = True
		Me.Label25.Visible = True
		Me.Label25.AutoSize = False
		Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label25.Name = "Label25"
		Me.Label24.Text = "电池："
		Me.Label24.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label24.ForeColor = System.Drawing.Color.Black
		Me.Label24.Size = New System.Drawing.Size(80, 21)
		Me.Label24.Location = New System.Drawing.Point(270, 540)
		Me.Label24.TabIndex = 59
		Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label24.BackColor = System.Drawing.Color.Transparent
		Me.Label24.Enabled = True
		Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label24.UseMnemonic = True
		Me.Label24.Visible = True
		Me.Label24.AutoSize = False
		Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label24.Name = "Label24"
		Me.Label22.Text = "模式："
		Me.Label22.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label22.ForeColor = System.Drawing.Color.Black
		Me.Label22.Size = New System.Drawing.Size(76, 21)
		Me.Label22.Location = New System.Drawing.Point(762, 186)
		Me.Label22.TabIndex = 58
		Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label22.BackColor = System.Drawing.Color.Transparent
		Me.Label22.Enabled = True
		Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label22.UseMnemonic = True
		Me.Label22.Visible = True
		Me.Label22.AutoSize = False
		Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label22.Name = "Label22"
		Me.Label9.Text = "压力："
		Me.Label9.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label9.ForeColor = System.Drawing.Color.Black
		Me.Label9.Size = New System.Drawing.Size(80, 21)
		Me.Label9.Location = New System.Drawing.Point(824, 186)
		Me.Label9.TabIndex = 57
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label9.BackColor = System.Drawing.Color.Transparent
		Me.Label9.Enabled = True
		Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label9.UseMnemonic = True
		Me.Label9.Visible = True
		Me.Label9.AutoSize = False
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label9.Name = "Label9"
		Me.Label8.Text = "温度："
		Me.Label8.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label8.ForeColor = System.Drawing.Color.Black
		Me.Label8.Size = New System.Drawing.Size(80, 21)
		Me.Label8.Location = New System.Drawing.Point(912, 186)
		Me.Label8.TabIndex = 56
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label8.BackColor = System.Drawing.Color.Transparent
		Me.Label8.Enabled = True
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = False
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label6.Text = "加速度："
		Me.Label6.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label6.ForeColor = System.Drawing.Color.Black
		Me.Label6.Size = New System.Drawing.Size(80, 21)
		Me.Label6.Location = New System.Drawing.Point(824, 202)
		Me.Label6.TabIndex = 55
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Enabled = True
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label5.Text = "电池："
		Me.Label5.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label5.ForeColor = System.Drawing.Color.Black
		Me.Label5.Size = New System.Drawing.Size(80, 21)
		Me.Label5.Location = New System.Drawing.Point(762, 202)
		Me.Label5.TabIndex = 54
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.Color.Transparent
		Me.Label5.Enabled = True
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "电池："
		Me.Label4.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label4.ForeColor = System.Drawing.Color.Black
		Me.Label4.Size = New System.Drawing.Size(80, 21)
		Me.Label4.Location = New System.Drawing.Point(272, 202)
		Me.Label4.TabIndex = 53
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Enabled = True
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "加速度："
		Me.Label3.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.Black
		Me.Label3.Size = New System.Drawing.Size(80, 21)
		Me.Label3.Location = New System.Drawing.Point(332, 202)
		Me.Label3.TabIndex = 52
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "温度："
		Me.Label2.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.Black
		Me.Label2.Size = New System.Drawing.Size(46, 21)
		Me.Label2.Location = New System.Drawing.Point(422, 186)
		Me.Label2.TabIndex = 51
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "压力："
		Me.Label1.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.Black
		Me.Label1.Size = New System.Drawing.Size(80, 21)
		Me.Label1.Location = New System.Drawing.Point(332, 186)
		Me.Label1.TabIndex = 50
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		ImageList1.OcxState = CType(resources.GetObject("ImageList1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.ImageList1.Location = New System.Drawing.Point(160, 165)
		Me.ImageList1.Name = "ImageList1"
		ImageList.OcxState = CType(resources.GetObject("ImageList.OcxState"), System.Windows.Forms.AxHost.State)
		Me.ImageList.Location = New System.Drawing.Point(160, 210)
		Me.ImageList.Name = "ImageList"
		Me.lblStatus.Text = "网络连接状态异常"
		Me.lblStatus.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lblStatus.ForeColor = System.Drawing.Color.Red
		Me.lblStatus.Size = New System.Drawing.Size(169, 20)
		Me.lblStatus.Location = New System.Drawing.Point(48, 600)
		Me.lblStatus.TabIndex = 36
		Me.lblStatus.Visible = False
		Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblStatus.BackColor = System.Drawing.Color.Transparent
		Me.lblStatus.Enabled = True
		Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblStatus.UseMnemonic = True
		Me.lblStatus.AutoSize = False
		Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblStatus.Name = "lblStatus"
		Me.Label17.Text = "右侧控制器"
		Me.Label17.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label17.ForeColor = System.Drawing.Color.FromARGB(78, 78, 78)
		Me.Label17.Size = New System.Drawing.Size(105, 25)
		Me.Label17.Location = New System.Drawing.Point(71, 573)
		Me.Label17.TabIndex = 35
		Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label17.BackColor = System.Drawing.Color.Transparent
		Me.Label17.Enabled = True
		Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label17.UseMnemonic = True
		Me.Label17.Visible = True
		Me.Label17.AutoSize = False
		Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label17.Name = "Label17"
		Me.Label16.Text = "左侧控制器"
		Me.Label16.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label16.ForeColor = System.Drawing.Color.FromARGB(78, 78, 78)
		Me.Label16.Size = New System.Drawing.Size(105, 25)
		Me.Label16.Location = New System.Drawing.Point(71, 503)
		Me.Label16.TabIndex = 34
		Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label16.BackColor = System.Drawing.Color.Transparent
		Me.Label16.Enabled = True
		Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label16.UseMnemonic = True
		Me.Label16.Visible = True
		Me.Label16.AutoSize = False
		Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label16.Name = "Label16"
		Me.Label13.Text = "数据库硬盘容量"
		Me.Label13.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label13.ForeColor = System.Drawing.Color.FromARGB(78, 78, 78)
		Me.Label13.Size = New System.Drawing.Size(145, 24)
		Me.Label13.Location = New System.Drawing.Point(71, 425)
		Me.Label13.TabIndex = 33
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label13.BackColor = System.Drawing.Color.Transparent
		Me.Label13.Enabled = True
		Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label13.UseMnemonic = True
		Me.Label13.Visible = True
		Me.Label13.AutoSize = False
		Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label13.Name = "Label13"
		Me.Label12.Text = "SPPV数据库"
		Me.Label12.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label12.ForeColor = System.Drawing.Color.FromARGB(78, 78, 78)
		Me.Label12.Size = New System.Drawing.Size(105, 25)
		Me.Label12.Location = New System.Drawing.Point(71, 342)
		Me.Label12.TabIndex = 32
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label12.BackColor = System.Drawing.Color.Transparent
		Me.Label12.Enabled = True
		Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label12.UseMnemonic = True
		Me.Label12.Visible = True
		Me.Label12.AutoSize = False
		Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label12.Name = "Label12"
		Me.Label11.Text = "本地数据库"
		Me.Label11.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label11.ForeColor = System.Drawing.Color.FromARGB(78, 78, 78)
		Me.Label11.Size = New System.Drawing.Size(105, 25)
		Me.Label11.Location = New System.Drawing.Point(71, 263)
		Me.Label11.TabIndex = 31
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label11.BackColor = System.Drawing.Color.Transparent
		Me.Label11.Enabled = True
		Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label11.UseMnemonic = True
		Me.Label11.Visible = True
		Me.Label11.AutoSize = False
		Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label11.Name = "Label11"
		Me.Label7.Text = "网络连接"
		Me.Label7.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label7.ForeColor = System.Drawing.Color.FromARGB(78, 78, 78)
		Me.Label7.Size = New System.Drawing.Size(89, 24)
		Me.Label7.Location = New System.Drawing.Point(71, 189)
		Me.Label7.TabIndex = 30
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.BackColor = System.Drawing.Color.Transparent
		Me.Label7.Enabled = True
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label23.BackColor = System.Drawing.Color.Transparent
		Me.Label23.Text = "武汉市洪山区珞瑜东路佳园路光谷国际A座2318室    电话：027-87775236"
		Me.Label23.Font = New System.Drawing.Font("宋体", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label23.Size = New System.Drawing.Size(525, 17)
		Me.Label23.Location = New System.Drawing.Point(470, 742)
		Me.Label23.TabIndex = 28
		Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label23.Enabled = True
		Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label23.UseMnemonic = True
		Me.Label23.Visible = True
		Me.Label23.AutoSize = False
		Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label23.Name = "Label23"
		Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label21.Text = "右前轮"
		Me.Label21.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label21.ForeColor = System.Drawing.SystemColors.Highlight
		Me.Label21.Size = New System.Drawing.Size(168, 29)
		Me.Label21.Location = New System.Drawing.Point(801, 464)
		Me.Label21.TabIndex = 27
		Me.Label21.BackColor = System.Drawing.Color.Transparent
		Me.Label21.Enabled = True
		Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label21.UseMnemonic = True
		Me.Label21.Visible = True
		Me.Label21.AutoSize = False
		Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label21.Name = "Label21"
		Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label20.Text = "右后轮"
		Me.Label20.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label20.ForeColor = System.Drawing.SystemColors.Highlight
		Me.Label20.Size = New System.Drawing.Size(168, 29)
		Me.Label20.Location = New System.Drawing.Point(300, 464)
		Me.Label20.TabIndex = 24
		Me.Label20.BackColor = System.Drawing.Color.Transparent
		Me.Label20.Enabled = True
		Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label20.UseMnemonic = True
		Me.Label20.Visible = True
		Me.Label20.AutoSize = False
		Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label20.Name = "Label20"
		Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label19.Text = "左前轮"
		Me.Label19.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label19.ForeColor = System.Drawing.SystemColors.Highlight
		Me.Label19.Size = New System.Drawing.Size(168, 29)
		Me.Label19.Location = New System.Drawing.Point(799, 126)
		Me.Label19.TabIndex = 21
		Me.Label19.BackColor = System.Drawing.Color.Transparent
		Me.Label19.Enabled = True
		Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label19.UseMnemonic = True
		Me.Label19.Visible = True
		Me.Label19.AutoSize = False
		Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label19.Name = "Label19"
		Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label18.Text = "左后轮"
		Me.Label18.Font = New System.Drawing.Font("黑体", 21.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label18.ForeColor = System.Drawing.SystemColors.Highlight
		Me.Label18.Size = New System.Drawing.Size(168, 29)
		Me.Label18.Location = New System.Drawing.Point(300, 126)
		Me.Label18.TabIndex = 18
		Me.Label18.BackColor = System.Drawing.Color.Transparent
		Me.Label18.Enabled = True
		Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label18.UseMnemonic = True
		Me.Label18.Visible = True
		Me.Label18.AutoSize = False
		Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label18.Name = "Label18"
		Me.Label14.Text = "状态监视:"
		Me.Label14.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label14.ForeColor = System.Drawing.Color.FromARGB(64, 64, 64)
		Me.Label14.Size = New System.Drawing.Size(145, 25)
		Me.Label14.Location = New System.Drawing.Point(14, 132)
		Me.Label14.TabIndex = 9
		Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label14.BackColor = System.Drawing.Color.Transparent
		Me.Label14.Enabled = True
		Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label14.UseMnemonic = True
		Me.Label14.Visible = True
		Me.Label14.AutoSize = False
		Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label14.Name = "Label14"
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label10.Text = "胎压初始化系统"
		Me.Label10.Font = New System.Drawing.Font("宋体", 15!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label10.ForeColor = System.Drawing.Color.White
		Me.Label10.Size = New System.Drawing.Size(187, 25)
		Me.Label10.Location = New System.Drawing.Point(16, 44)
		Me.Label10.TabIndex = 8
		Me.Label10.BackColor = System.Drawing.Color.Transparent
		Me.Label10.Enabled = True
		Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label10.UseMnemonic = True
		Me.Label10.Visible = True
		Me.Label10.AutoSize = False
		Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label10.Name = "Label10"
		Me.Controls.Add(Command12)
		Me.Controls.Add(Command7)
		Me.Controls.Add(Command4)
		Me.Controls.Add(Command2)
		Me.Controls.Add(Picture10)
		Me.Controls.Add(Command1)
		Me.Controls.Add(Command3)
		Me.Controls.Add(Command6)
		Me.Controls.Add(Command5)
		Me.Controls.Add(Command11)
		Me.Controls.Add(Command10)
		Me.Controls.Add(Command9)
		Me.Controls.Add(Command8)
		Me.Controls.Add(txtInputVIN)
		Me.Controls.Add(Command14)
		Me.Controls.Add(Command17)
		Me.Controls.Add(Text2)
		Me.Controls.Add(List1)
		Me.Controls.Add(txtVin)
		Me.Controls.Add(ListMsg)
		Me.Controls.Add(txtRF)
		Me.Controls.Add(picRF)
		Me.Controls.Add(txtRR)
		Me.Controls.Add(picRR)
		Me.Controls.Add(txtLF)
		Me.Controls.Add(picLF)
		Me.Controls.Add(txtLR)
		Me.Controls.Add(picLR)
		Me.Controls.Add(Picture8)
		Me.Controls.Add(Picture7)
		Me.Controls.Add(Picture9)
		Me.Controls.Add(Picture6)
		Me.Controls.Add(PicNet)
		Me.Controls.Add(PicInd)
		Me.Controls.Add(picCommandReset)
		Me.Controls.Add(picCommandConifg)
		Me.Controls.Add(picCommandOut)
		Me.Controls.Add(picCommandLog)
		Me.Controls.Add(picCommandHis)
		Me.Controls.Add(Picture1)
		Me.Controls.Add(picExit)
		Me.Controls.Add(Picture4)
		Me.Controls.Add(MSComVIN)
		Me.Controls.Add(MSCommBT)
		Me.Controls.Add(Label15)
		Me.Controls.Add(lbRFAcSpeed)
		Me.Controls.Add(lbRFBattery)
		Me.Controls.Add(lbRFMdl)
		Me.Controls.Add(lbRFPre)
		Me.Controls.Add(lbRFTemp)
		Me.Controls.Add(lbRRTemp)
		Me.Controls.Add(lbRRPre)
		Me.Controls.Add(lbRRMdl)
		Me.Controls.Add(lbRRBattery)
		Me.Controls.Add(lbRRAcSpeed)
		Me.Controls.Add(lbLFTemp)
		Me.Controls.Add(lbLFPre)
		Me.Controls.Add(lbLFMdl)
		Me.Controls.Add(lbLFBattery)
		Me.Controls.Add(lbLFAcSpeed)
		Me.Controls.Add(Label39)
		Me.Controls.Add(lbLRAcSpeed)
		Me.Controls.Add(lbLRBattery)
		Me.Controls.Add(lbLRMdl)
		Me.Controls.Add(lbLRPre)
		Me.Controls.Add(lbLRTemp)
		Me.Controls.Add(Label33)
		Me.Controls.Add(Label32)
		Me.Controls.Add(Label31)
		Me.Controls.Add(Label30)
		Me.Controls.Add(Label29)
		Me.Controls.Add(Label28)
		Me.Controls.Add(Label27)
		Me.Controls.Add(Label26)
		Me.Controls.Add(Label25)
		Me.Controls.Add(Label24)
		Me.Controls.Add(Label22)
		Me.Controls.Add(Label9)
		Me.Controls.Add(Label8)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(ImageList1)
		Me.Controls.Add(ImageList)
		Me.Controls.Add(lblStatus)
		Me.Controls.Add(Label17)
		Me.Controls.Add(Label16)
		Me.Controls.Add(Label13)
		Me.Controls.Add(Label12)
		Me.Controls.Add(Label11)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label23)
		Me.Controls.Add(Label21)
		Me.Controls.Add(Label20)
		Me.Controls.Add(Label19)
		Me.Controls.Add(Label18)
		Me.Controls.Add(Label14)
		Me.Controls.Add(Label10)
		CType(Me.ImageList, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ImageList1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.MSCommBT, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.MSComVIN, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class