<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmOption
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
	Public WithEvents ComboRun As System.Windows.Forms.ComboBox
	Public WithEvents MSFlexGrid1 As AxMSFlexGridLib.AxMSFlexGrid
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents txtValueRun As System.Windows.Forms.TextBox
	Public WithEvents txtDescriptionRun As System.Windows.Forms.TextBox
	Public WithEvents txtKeyRun As System.Windows.Forms.TextBox
	Public WithEvents txtGroupRun As System.Windows.Forms.TextBox
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents _SSTab1_TabPage0 As System.Windows.Forms.TabPage
	Public WithEvents txtGroupCtrl As System.Windows.Forms.TextBox
	Public WithEvents txtKeyCtrl As System.Windows.Forms.TextBox
	Public WithEvents txtDescriptionCtrl As System.Windows.Forms.TextBox
	Public WithEvents txtValueCtrl As System.Windows.Forms.TextBox
	Public WithEvents Command4 As System.Windows.Forms.Button
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Frame6 As System.Windows.Forms.GroupBox
	Public WithEvents ComboCtrl As System.Windows.Forms.ComboBox
	Public WithEvents MSFlexGrid2 As AxMSFlexGridLib.AxMSFlexGrid
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Frame5 As System.Windows.Forms.GroupBox
	Public WithEvents Frame4 As System.Windows.Forms.GroupBox
	Public WithEvents _SSTab1_TabPage1 As System.Windows.Forms.TabPage
	Public WithEvents cmdMdlSave As System.Windows.Forms.Button
	Public WithEvents txtMdl As System.Windows.Forms.TextBox
	Public WithEvents Label29 As System.Windows.Forms.Label
	Public WithEvents Label28 As System.Windows.Forms.Label
	Public WithEvents Frame17 As System.Windows.Forms.GroupBox
	Public WithEvents cmdPreSave As System.Windows.Forms.Button
	Public WithEvents txtPreMax As System.Windows.Forms.TextBox
	Public WithEvents txtPreMin As System.Windows.Forms.TextBox
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Frame10 As System.Windows.Forms.GroupBox
	Public WithEvents cmdAcSpeedSave As System.Windows.Forms.Button
	Public WithEvents txtAcSpeedMax As System.Windows.Forms.TextBox
	Public WithEvents txtAcSpeedMin As System.Windows.Forms.TextBox
	Public WithEvents Label18 As System.Windows.Forms.Label
	Public WithEvents Label17 As System.Windows.Forms.Label
	Public WithEvents Frame12 As System.Windows.Forms.GroupBox
	Public WithEvents txtTempMin As System.Windows.Forms.TextBox
	Public WithEvents txtTempMax As System.Windows.Forms.TextBox
	Public WithEvents cmdTempSave As System.Windows.Forms.Button
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Frame11 As System.Windows.Forms.GroupBox
	Public WithEvents chkOnlyScanVINCode As System.Windows.Forms.CheckBox
	Public WithEvents chkAllQueue As System.Windows.Forms.CheckBox
	Public WithEvents Command10 As System.Windows.Forms.Button
	Public WithEvents Command5 As System.Windows.Forms.Button
	Public WithEvents Label27 As System.Windows.Forms.Label
	Public WithEvents Label25 As System.Windows.Forms.Label
	Public WithEvents Frame9 As System.Windows.Forms.GroupBox
	Public WithEvents WindowsXPC1 As AxWinXPC_Engine.AxWindowsXPC
	Public WithEvents Text2 As System.Windows.Forms.TextBox
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents Command6 As System.Windows.Forms.Button
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Frame8 As System.Windows.Forms.GroupBox
	Public WithEvents Frame7 As System.Windows.Forms.GroupBox
	Public WithEvents _SSTab1_TabPage2 As System.Windows.Forms.TabPage
	Public WithEvents chkOnlyPrintNGWriteResult As System.Windows.Forms.CheckBox
	Public WithEvents chkPrintNGFlow As System.Windows.Forms.CheckBox
	Public WithEvents Command7 As System.Windows.Forms.Button
	Public WithEvents txtVIN As System.Windows.Forms.TextBox
	Public WithEvents Label31 As System.Windows.Forms.Label
	Public WithEvents Label32 As System.Windows.Forms.Label
	Public WithEvents Label30 As System.Windows.Forms.Label
	Public WithEvents Frame18 As System.Windows.Forms.GroupBox
	Public WithEvents btMTOCModi As System.Windows.Forms.Button
	Public WithEvents txtMTOCLen As System.Windows.Forms.TextBox
	Public WithEvents txtMtocStartIndex As System.Windows.Forms.TextBox
	Public WithEvents Label24 As System.Windows.Forms.Label
	Public WithEvents Label23 As System.Windows.Forms.Label
	Public WithEvents Label22 As System.Windows.Forms.Label
	Public WithEvents Label21 As System.Windows.Forms.Label
	Public WithEvents Frame15 As System.Windows.Forms.GroupBox
	Public WithEvents btTPMSCancle As System.Windows.Forms.Button
	Public WithEvents btTPMSDel As System.Windows.Forms.Button
	Public WithEvents btTPMSModi As System.Windows.Forms.Button
	Public WithEvents txtTPMSCode As System.Windows.Forms.TextBox
	Public WithEvents txtTPMSID As System.Windows.Forms.TextBox
	Public WithEvents btTPMSAdd As System.Windows.Forms.Button
	Public WithEvents Label20 As System.Windows.Forms.Label
	Public WithEvents Label19 As System.Windows.Forms.Label
	Public WithEvents Frame16 As System.Windows.Forms.GroupBox
	Public WithEvents MSFlexGrid3 As AxMSFlexGridLib.AxMSFlexGrid
	Public WithEvents Frame14 As System.Windows.Forms.GroupBox
	Public WithEvents Frame13 As System.Windows.Forms.GroupBox
	Public WithEvents _SSTab1_TabPage3 As System.Windows.Forms.TabPage
	Public WithEvents SSTab1 As System.Windows.Forms.TabControl
	Public WithEvents Label26 As System.Windows.Forms.Label
	'注意: 以下过程是 Windows 窗体设计器所必需的
	'可以使用 Windows 窗体设计器来修改它。
	'不要使用代码编辑器修改它。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmOption))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.SSTab1 = New System.Windows.Forms.TabControl
		Me._SSTab1_TabPage0 = New System.Windows.Forms.TabPage
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.Frame3 = New System.Windows.Forms.GroupBox
		Me.ComboRun = New System.Windows.Forms.ComboBox
		Me.MSFlexGrid1 = New AxMSFlexGridLib.AxMSFlexGrid
		Me.Label5 = New System.Windows.Forms.Label
		Me.Frame2 = New System.Windows.Forms.GroupBox
		Me.Command2 = New System.Windows.Forms.Button
		Me.Command1 = New System.Windows.Forms.Button
		Me.txtValueRun = New System.Windows.Forms.TextBox
		Me.txtDescriptionRun = New System.Windows.Forms.TextBox
		Me.txtKeyRun = New System.Windows.Forms.TextBox
		Me.txtGroupRun = New System.Windows.Forms.TextBox
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me._SSTab1_TabPage1 = New System.Windows.Forms.TabPage
		Me.Frame4 = New System.Windows.Forms.GroupBox
		Me.Frame6 = New System.Windows.Forms.GroupBox
		Me.txtGroupCtrl = New System.Windows.Forms.TextBox
		Me.txtKeyCtrl = New System.Windows.Forms.TextBox
		Me.txtDescriptionCtrl = New System.Windows.Forms.TextBox
		Me.txtValueCtrl = New System.Windows.Forms.TextBox
		Me.Command4 = New System.Windows.Forms.Button
		Me.Command3 = New System.Windows.Forms.Button
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Frame5 = New System.Windows.Forms.GroupBox
		Me.ComboCtrl = New System.Windows.Forms.ComboBox
		Me.MSFlexGrid2 = New AxMSFlexGridLib.AxMSFlexGrid
		Me.Label6 = New System.Windows.Forms.Label
		Me._SSTab1_TabPage2 = New System.Windows.Forms.TabPage
		Me.Frame7 = New System.Windows.Forms.GroupBox
		Me.Frame17 = New System.Windows.Forms.GroupBox
		Me.cmdMdlSave = New System.Windows.Forms.Button
		Me.txtMdl = New System.Windows.Forms.TextBox
		Me.Label29 = New System.Windows.Forms.Label
		Me.Label28 = New System.Windows.Forms.Label
		Me.Frame10 = New System.Windows.Forms.GroupBox
		Me.cmdPreSave = New System.Windows.Forms.Button
		Me.txtPreMax = New System.Windows.Forms.TextBox
		Me.txtPreMin = New System.Windows.Forms.TextBox
		Me.Label16 = New System.Windows.Forms.Label
		Me.Label13 = New System.Windows.Forms.Label
		Me.Frame12 = New System.Windows.Forms.GroupBox
		Me.cmdAcSpeedSave = New System.Windows.Forms.Button
		Me.txtAcSpeedMax = New System.Windows.Forms.TextBox
		Me.txtAcSpeedMin = New System.Windows.Forms.TextBox
		Me.Label18 = New System.Windows.Forms.Label
		Me.Label17 = New System.Windows.Forms.Label
		Me.Frame11 = New System.Windows.Forms.GroupBox
		Me.txtTempMin = New System.Windows.Forms.TextBox
		Me.txtTempMax = New System.Windows.Forms.TextBox
		Me.cmdTempSave = New System.Windows.Forms.Button
		Me.Label15 = New System.Windows.Forms.Label
		Me.Label14 = New System.Windows.Forms.Label
		Me.Frame9 = New System.Windows.Forms.GroupBox
		Me.chkOnlyScanVINCode = New System.Windows.Forms.CheckBox
		Me.chkAllQueue = New System.Windows.Forms.CheckBox
		Me.Command10 = New System.Windows.Forms.Button
		Me.Command5 = New System.Windows.Forms.Button
		Me.Label27 = New System.Windows.Forms.Label
		Me.Label25 = New System.Windows.Forms.Label
		Me.Frame8 = New System.Windows.Forms.GroupBox
		Me.WindowsXPC1 = New AxWinXPC_Engine.AxWindowsXPC
		Me.Text2 = New System.Windows.Forms.TextBox
		Me.Text1 = New System.Windows.Forms.TextBox
		Me.Command6 = New System.Windows.Forms.Button
		Me.Label11 = New System.Windows.Forms.Label
		Me.Label12 = New System.Windows.Forms.Label
		Me._SSTab1_TabPage3 = New System.Windows.Forms.TabPage
		Me.Frame13 = New System.Windows.Forms.GroupBox
		Me.Frame18 = New System.Windows.Forms.GroupBox
		Me.chkOnlyPrintNGWriteResult = New System.Windows.Forms.CheckBox
		Me.chkPrintNGFlow = New System.Windows.Forms.CheckBox
		Me.Command7 = New System.Windows.Forms.Button
		Me.txtVIN = New System.Windows.Forms.TextBox
		Me.Label31 = New System.Windows.Forms.Label
		Me.Label32 = New System.Windows.Forms.Label
		Me.Label30 = New System.Windows.Forms.Label
		Me.Frame15 = New System.Windows.Forms.GroupBox
		Me.btMTOCModi = New System.Windows.Forms.Button
		Me.txtMTOCLen = New System.Windows.Forms.TextBox
		Me.txtMtocStartIndex = New System.Windows.Forms.TextBox
		Me.Label24 = New System.Windows.Forms.Label
		Me.Label23 = New System.Windows.Forms.Label
		Me.Label22 = New System.Windows.Forms.Label
		Me.Label21 = New System.Windows.Forms.Label
		Me.Frame14 = New System.Windows.Forms.GroupBox
		Me.Frame16 = New System.Windows.Forms.GroupBox
		Me.btTPMSCancle = New System.Windows.Forms.Button
		Me.btTPMSDel = New System.Windows.Forms.Button
		Me.btTPMSModi = New System.Windows.Forms.Button
		Me.txtTPMSCode = New System.Windows.Forms.TextBox
		Me.txtTPMSID = New System.Windows.Forms.TextBox
		Me.btTPMSAdd = New System.Windows.Forms.Button
		Me.Label20 = New System.Windows.Forms.Label
		Me.Label19 = New System.Windows.Forms.Label
		Me.MSFlexGrid3 = New AxMSFlexGridLib.AxMSFlexGrid
		Me.Label26 = New System.Windows.Forms.Label
		Me.SSTab1.SuspendLayout()
		Me._SSTab1_TabPage0.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.Frame3.SuspendLayout()
		Me.Frame2.SuspendLayout()
		Me._SSTab1_TabPage1.SuspendLayout()
		Me.Frame4.SuspendLayout()
		Me.Frame6.SuspendLayout()
		Me.Frame5.SuspendLayout()
		Me._SSTab1_TabPage2.SuspendLayout()
		Me.Frame7.SuspendLayout()
		Me.Frame17.SuspendLayout()
		Me.Frame10.SuspendLayout()
		Me.Frame12.SuspendLayout()
		Me.Frame11.SuspendLayout()
		Me.Frame9.SuspendLayout()
		Me.Frame8.SuspendLayout()
		Me._SSTab1_TabPage3.SuspendLayout()
		Me.Frame13.SuspendLayout()
		Me.Frame18.SuspendLayout()
		Me.Frame15.SuspendLayout()
		Me.Frame14.SuspendLayout()
		Me.Frame16.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.MSFlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.MSFlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.MSFlexGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.BackColor = System.Drawing.Color.White
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "系统配置"
		Me.ClientSize = New System.Drawing.Size(622, 430)
		Me.Location = New System.Drawing.Point(265, 199)
		Me.Icon = CType(resources.GetObject("frmOption.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmOption"
		Me.SSTab1.Size = New System.Drawing.Size(619, 425)
		Me.SSTab1.Location = New System.Drawing.Point(0, 0)
		Me.SSTab1.TabIndex = 0
		Me.SSTab1.SelectedIndex = 2
		Me.SSTab1.ItemSize = New System.Drawing.Size(42, 18)
		Me.SSTab1.BackColor = System.Drawing.Color.White
		Me.SSTab1.Name = "SSTab1"
		Me._SSTab1_TabPage0.Text = "运行参数"
		Me.Frame1.BackColor = System.Drawing.Color.White
		Me.Frame1.Size = New System.Drawing.Size(609, 397)
		Me.Frame1.Location = New System.Drawing.Point(4, 24)
		Me.Frame1.TabIndex = 1
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me.Frame3.BackColor = System.Drawing.Color.White
		Me.Frame3.Text = "参数列表    "
		Me.Frame3.Size = New System.Drawing.Size(367, 373)
		Me.Frame3.Location = New System.Drawing.Point(6, 18)
		Me.Frame3.TabIndex = 13
		Me.Frame3.Enabled = True
		Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame3.Visible = True
		Me.Frame3.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame3.Name = "Frame3"
		Me.ComboRun.Size = New System.Drawing.Size(171, 21)
		Me.ComboRun.Location = New System.Drawing.Point(110, 18)
		Me.ComboRun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ComboRun.TabIndex = 15
		Me.ComboRun.BackColor = System.Drawing.SystemColors.Window
		Me.ComboRun.CausesValidation = True
		Me.ComboRun.Enabled = True
		Me.ComboRun.ForeColor = System.Drawing.SystemColors.WindowText
		Me.ComboRun.IntegralHeight = True
		Me.ComboRun.Cursor = System.Windows.Forms.Cursors.Default
		Me.ComboRun.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ComboRun.Sorted = False
		Me.ComboRun.TabStop = True
		Me.ComboRun.Visible = True
		Me.ComboRun.Name = "ComboRun"
		MSFlexGrid1.OcxState = CType(resources.GetObject("MSFlexGrid1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.MSFlexGrid1.Size = New System.Drawing.Size(355, 315)
		Me.MSFlexGrid1.Location = New System.Drawing.Point(4, 50)
		Me.MSFlexGrid1.TabIndex = 14
		Me.MSFlexGrid1.Name = "MSFlexGrid1"
		Me.Label5.BackColor = System.Drawing.Color.White
		Me.Label5.Text = "组："
		Me.Label5.ForeColor = System.Drawing.Color.Black
		Me.Label5.Size = New System.Drawing.Size(55, 17)
		Me.Label5.Location = New System.Drawing.Point(82, 22)
		Me.Label5.TabIndex = 16
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.Enabled = True
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Frame2.BackColor = System.Drawing.Color.White
		Me.Frame2.Text = "修改  "
		Me.Frame2.Size = New System.Drawing.Size(223, 373)
		Me.Frame2.Location = New System.Drawing.Point(380, 18)
		Me.Frame2.TabIndex = 2
		Me.Frame2.Enabled = True
		Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Visible = True
		Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame2.Name = "Frame2"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "修改"
		Me.Command2.Size = New System.Drawing.Size(73, 25)
		Me.Command2.Location = New System.Drawing.Point(136, 290)
		Me.Command2.TabIndex = 12
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "取消"
		Me.Command1.Size = New System.Drawing.Size(73, 25)
		Me.Command1.Location = New System.Drawing.Point(30, 290)
		Me.Command1.TabIndex = 11
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.txtValueRun.AutoSize = False
		Me.txtValueRun.Size = New System.Drawing.Size(139, 21)
		Me.txtValueRun.Location = New System.Drawing.Point(68, 220)
		Me.txtValueRun.TabIndex = 10
		Me.txtValueRun.AcceptsReturn = True
		Me.txtValueRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtValueRun.BackColor = System.Drawing.SystemColors.Window
		Me.txtValueRun.CausesValidation = True
		Me.txtValueRun.Enabled = True
		Me.txtValueRun.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtValueRun.HideSelection = True
		Me.txtValueRun.ReadOnly = False
		Me.txtValueRun.Maxlength = 0
		Me.txtValueRun.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtValueRun.MultiLine = False
		Me.txtValueRun.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtValueRun.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtValueRun.TabStop = True
		Me.txtValueRun.Visible = True
		Me.txtValueRun.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtValueRun.Name = "txtValueRun"
		Me.txtDescriptionRun.AutoSize = False
		Me.txtDescriptionRun.Size = New System.Drawing.Size(139, 51)
		Me.txtDescriptionRun.Location = New System.Drawing.Point(68, 138)
		Me.txtDescriptionRun.ReadOnly = True
		Me.txtDescriptionRun.TabIndex = 8
		Me.txtDescriptionRun.AcceptsReturn = True
		Me.txtDescriptionRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDescriptionRun.BackColor = System.Drawing.SystemColors.Window
		Me.txtDescriptionRun.CausesValidation = True
		Me.txtDescriptionRun.Enabled = True
		Me.txtDescriptionRun.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDescriptionRun.HideSelection = True
		Me.txtDescriptionRun.Maxlength = 0
		Me.txtDescriptionRun.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDescriptionRun.MultiLine = False
		Me.txtDescriptionRun.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDescriptionRun.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDescriptionRun.TabStop = True
		Me.txtDescriptionRun.Visible = True
		Me.txtDescriptionRun.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDescriptionRun.Name = "txtDescriptionRun"
		Me.txtKeyRun.AutoSize = False
		Me.txtKeyRun.Size = New System.Drawing.Size(139, 21)
		Me.txtKeyRun.Location = New System.Drawing.Point(68, 92)
		Me.txtKeyRun.ReadOnly = True
		Me.txtKeyRun.TabIndex = 6
		Me.txtKeyRun.AcceptsReturn = True
		Me.txtKeyRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtKeyRun.BackColor = System.Drawing.SystemColors.Window
		Me.txtKeyRun.CausesValidation = True
		Me.txtKeyRun.Enabled = True
		Me.txtKeyRun.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtKeyRun.HideSelection = True
		Me.txtKeyRun.Maxlength = 0
		Me.txtKeyRun.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtKeyRun.MultiLine = False
		Me.txtKeyRun.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtKeyRun.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtKeyRun.TabStop = True
		Me.txtKeyRun.Visible = True
		Me.txtKeyRun.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtKeyRun.Name = "txtKeyRun"
		Me.txtGroupRun.AutoSize = False
		Me.txtGroupRun.Size = New System.Drawing.Size(139, 21)
		Me.txtGroupRun.Location = New System.Drawing.Point(68, 46)
		Me.txtGroupRun.ReadOnly = True
		Me.txtGroupRun.TabIndex = 4
		Me.txtGroupRun.AcceptsReturn = True
		Me.txtGroupRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtGroupRun.BackColor = System.Drawing.SystemColors.Window
		Me.txtGroupRun.CausesValidation = True
		Me.txtGroupRun.Enabled = True
		Me.txtGroupRun.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtGroupRun.HideSelection = True
		Me.txtGroupRun.Maxlength = 0
		Me.txtGroupRun.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtGroupRun.MultiLine = False
		Me.txtGroupRun.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtGroupRun.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtGroupRun.TabStop = True
		Me.txtGroupRun.Visible = True
		Me.txtGroupRun.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtGroupRun.Name = "txtGroupRun"
		Me.Label4.BackColor = System.Drawing.Color.White
		Me.Label4.Text = "值："
		Me.Label4.Size = New System.Drawing.Size(49, 17)
		Me.Label4.Location = New System.Drawing.Point(44, 224)
		Me.Label4.TabIndex = 9
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.BackColor = System.Drawing.Color.White
		Me.Label3.Text = "描述："
		Me.Label3.Size = New System.Drawing.Size(49, 17)
		Me.Label3.Location = New System.Drawing.Point(32, 144)
		Me.Label3.TabIndex = 7
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.BackColor = System.Drawing.Color.White
		Me.Label2.Text = "关键字："
		Me.Label2.Size = New System.Drawing.Size(49, 17)
		Me.Label2.Location = New System.Drawing.Point(20, 96)
		Me.Label2.TabIndex = 5
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.BackColor = System.Drawing.Color.White
		Me.Label1.Text = "组："
		Me.Label1.Size = New System.Drawing.Size(49, 15)
		Me.Label1.Location = New System.Drawing.Point(44, 50)
		Me.Label1.TabIndex = 3
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me._SSTab1_TabPage1.Text = "控制参数"
		Me.Frame4.BackColor = System.Drawing.Color.White
		Me.Frame4.Size = New System.Drawing.Size(609, 397)
		Me.Frame4.Location = New System.Drawing.Point(4, 24)
		Me.Frame4.TabIndex = 17
		Me.Frame4.Enabled = True
		Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame4.Visible = True
		Me.Frame4.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame4.Name = "Frame4"
		Me.Frame6.BackColor = System.Drawing.Color.White
		Me.Frame6.Text = "修改  "
		Me.Frame6.Size = New System.Drawing.Size(223, 373)
		Me.Frame6.Location = New System.Drawing.Point(380, 18)
		Me.Frame6.TabIndex = 22
		Me.Frame6.Enabled = True
		Me.Frame6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame6.Visible = True
		Me.Frame6.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame6.Name = "Frame6"
		Me.txtGroupCtrl.AutoSize = False
		Me.txtGroupCtrl.Size = New System.Drawing.Size(139, 21)
		Me.txtGroupCtrl.Location = New System.Drawing.Point(70, 46)
		Me.txtGroupCtrl.ReadOnly = True
		Me.txtGroupCtrl.TabIndex = 28
		Me.txtGroupCtrl.AcceptsReturn = True
		Me.txtGroupCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtGroupCtrl.BackColor = System.Drawing.SystemColors.Window
		Me.txtGroupCtrl.CausesValidation = True
		Me.txtGroupCtrl.Enabled = True
		Me.txtGroupCtrl.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtGroupCtrl.HideSelection = True
		Me.txtGroupCtrl.Maxlength = 0
		Me.txtGroupCtrl.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtGroupCtrl.MultiLine = False
		Me.txtGroupCtrl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtGroupCtrl.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtGroupCtrl.TabStop = True
		Me.txtGroupCtrl.Visible = True
		Me.txtGroupCtrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtGroupCtrl.Name = "txtGroupCtrl"
		Me.txtKeyCtrl.AutoSize = False
		Me.txtKeyCtrl.Size = New System.Drawing.Size(139, 21)
		Me.txtKeyCtrl.Location = New System.Drawing.Point(70, 94)
		Me.txtKeyCtrl.ReadOnly = True
		Me.txtKeyCtrl.TabIndex = 27
		Me.txtKeyCtrl.AcceptsReturn = True
		Me.txtKeyCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtKeyCtrl.BackColor = System.Drawing.SystemColors.Window
		Me.txtKeyCtrl.CausesValidation = True
		Me.txtKeyCtrl.Enabled = True
		Me.txtKeyCtrl.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtKeyCtrl.HideSelection = True
		Me.txtKeyCtrl.Maxlength = 0
		Me.txtKeyCtrl.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtKeyCtrl.MultiLine = False
		Me.txtKeyCtrl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtKeyCtrl.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtKeyCtrl.TabStop = True
		Me.txtKeyCtrl.Visible = True
		Me.txtKeyCtrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtKeyCtrl.Name = "txtKeyCtrl"
		Me.txtDescriptionCtrl.AutoSize = False
		Me.txtDescriptionCtrl.Size = New System.Drawing.Size(139, 51)
		Me.txtDescriptionCtrl.Location = New System.Drawing.Point(70, 138)
		Me.txtDescriptionCtrl.ReadOnly = True
		Me.txtDescriptionCtrl.TabIndex = 26
		Me.txtDescriptionCtrl.AcceptsReturn = True
		Me.txtDescriptionCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtDescriptionCtrl.BackColor = System.Drawing.SystemColors.Window
		Me.txtDescriptionCtrl.CausesValidation = True
		Me.txtDescriptionCtrl.Enabled = True
		Me.txtDescriptionCtrl.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtDescriptionCtrl.HideSelection = True
		Me.txtDescriptionCtrl.Maxlength = 0
		Me.txtDescriptionCtrl.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtDescriptionCtrl.MultiLine = False
		Me.txtDescriptionCtrl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtDescriptionCtrl.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtDescriptionCtrl.TabStop = True
		Me.txtDescriptionCtrl.Visible = True
		Me.txtDescriptionCtrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtDescriptionCtrl.Name = "txtDescriptionCtrl"
		Me.txtValueCtrl.AutoSize = False
		Me.txtValueCtrl.Size = New System.Drawing.Size(139, 21)
		Me.txtValueCtrl.Location = New System.Drawing.Point(70, 214)
		Me.txtValueCtrl.TabIndex = 25
		Me.txtValueCtrl.AcceptsReturn = True
		Me.txtValueCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtValueCtrl.BackColor = System.Drawing.SystemColors.Window
		Me.txtValueCtrl.CausesValidation = True
		Me.txtValueCtrl.Enabled = True
		Me.txtValueCtrl.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtValueCtrl.HideSelection = True
		Me.txtValueCtrl.ReadOnly = False
		Me.txtValueCtrl.Maxlength = 0
		Me.txtValueCtrl.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtValueCtrl.MultiLine = False
		Me.txtValueCtrl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtValueCtrl.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtValueCtrl.TabStop = True
		Me.txtValueCtrl.Visible = True
		Me.txtValueCtrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtValueCtrl.Name = "txtValueCtrl"
		Me.Command4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command4.Text = "取消"
		Me.Command4.Size = New System.Drawing.Size(73, 25)
		Me.Command4.Location = New System.Drawing.Point(30, 294)
		Me.Command4.TabIndex = 24
		Me.Command4.BackColor = System.Drawing.SystemColors.Control
		Me.Command4.CausesValidation = True
		Me.Command4.Enabled = True
		Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command4.TabStop = True
		Me.Command4.Name = "Command4"
		Me.Command3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command3.Text = "修改"
		Me.Command3.Size = New System.Drawing.Size(73, 25)
		Me.Command3.Location = New System.Drawing.Point(136, 294)
		Me.Command3.TabIndex = 23
		Me.Command3.BackColor = System.Drawing.SystemColors.Control
		Me.Command3.CausesValidation = True
		Me.Command3.Enabled = True
		Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command3.TabStop = True
		Me.Command3.Name = "Command3"
		Me.Label10.BackColor = System.Drawing.Color.White
		Me.Label10.Text = "组："
		Me.Label10.Size = New System.Drawing.Size(41, 15)
		Me.Label10.Location = New System.Drawing.Point(44, 48)
		Me.Label10.TabIndex = 32
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label10.Enabled = True
		Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label10.UseMnemonic = True
		Me.Label10.Visible = True
		Me.Label10.AutoSize = False
		Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label10.Name = "Label10"
		Me.Label9.BackColor = System.Drawing.Color.White
		Me.Label9.Text = "关键字："
		Me.Label9.Size = New System.Drawing.Size(51, 17)
		Me.Label9.Location = New System.Drawing.Point(20, 96)
		Me.Label9.TabIndex = 31
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label9.Enabled = True
		Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label9.UseMnemonic = True
		Me.Label9.Visible = True
		Me.Label9.AutoSize = False
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label9.Name = "Label9"
		Me.Label8.BackColor = System.Drawing.Color.White
		Me.Label8.Text = "描述："
		Me.Label8.Size = New System.Drawing.Size(39, 17)
		Me.Label8.Location = New System.Drawing.Point(32, 152)
		Me.Label8.TabIndex = 30
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label8.Enabled = True
		Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = False
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label7.BackColor = System.Drawing.Color.White
		Me.Label7.Text = "值："
		Me.Label7.Size = New System.Drawing.Size(49, 17)
		Me.Label7.Location = New System.Drawing.Point(44, 216)
		Me.Label7.TabIndex = 29
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.Enabled = True
		Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Frame5.BackColor = System.Drawing.Color.White
		Me.Frame5.Text = "参数列表    "
		Me.Frame5.Size = New System.Drawing.Size(367, 373)
		Me.Frame5.Location = New System.Drawing.Point(6, 18)
		Me.Frame5.TabIndex = 18
		Me.Frame5.Enabled = True
		Me.Frame5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame5.Visible = True
		Me.Frame5.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame5.Name = "Frame5"
		Me.ComboCtrl.Size = New System.Drawing.Size(167, 21)
		Me.ComboCtrl.Location = New System.Drawing.Point(110, 18)
		Me.ComboCtrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ComboCtrl.TabIndex = 19
		Me.ComboCtrl.BackColor = System.Drawing.SystemColors.Window
		Me.ComboCtrl.CausesValidation = True
		Me.ComboCtrl.Enabled = True
		Me.ComboCtrl.ForeColor = System.Drawing.SystemColors.WindowText
		Me.ComboCtrl.IntegralHeight = True
		Me.ComboCtrl.Cursor = System.Windows.Forms.Cursors.Default
		Me.ComboCtrl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ComboCtrl.Sorted = False
		Me.ComboCtrl.TabStop = True
		Me.ComboCtrl.Visible = True
		Me.ComboCtrl.Name = "ComboCtrl"
		MSFlexGrid2.OcxState = CType(resources.GetObject("MSFlexGrid2.OcxState"), System.Windows.Forms.AxHost.State)
		Me.MSFlexGrid2.Size = New System.Drawing.Size(357, 315)
		Me.MSFlexGrid2.Location = New System.Drawing.Point(4, 50)
		Me.MSFlexGrid2.TabIndex = 20
		Me.MSFlexGrid2.Name = "MSFlexGrid2"
		Me.Label6.BackColor = System.Drawing.Color.White
		Me.Label6.Text = "组："
		Me.Label6.ForeColor = System.Drawing.Color.Black
		Me.Label6.Size = New System.Drawing.Size(55, 17)
		Me.Label6.Location = New System.Drawing.Point(84, 22)
		Me.Label6.TabIndex = 21
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.Enabled = True
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me._SSTab1_TabPage2.Text = "手工维护"
		Me.Frame7.BackColor = System.Drawing.Color.White
		Me.Frame7.Size = New System.Drawing.Size(605, 395)
		Me.Frame7.Location = New System.Drawing.Point(6, 24)
		Me.Frame7.TabIndex = 33
		Me.Frame7.Enabled = True
		Me.Frame7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame7.Visible = True
		Me.Frame7.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame7.Name = "Frame7"
		Me.Frame17.BackColor = System.Drawing.Color.White
		Me.Frame17.Text = "传感器模式设定         "
		Me.Frame17.Size = New System.Drawing.Size(575, 53)
		Me.Frame17.Location = New System.Drawing.Point(10, 154)
		Me.Frame17.TabIndex = 86
		Me.Frame17.Enabled = True
		Me.Frame17.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame17.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame17.Visible = True
		Me.Frame17.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame17.Name = "Frame17"
		Me.cmdMdlSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdMdlSave.Text = "保存"
		Me.cmdMdlSave.Size = New System.Drawing.Size(95, 23)
		Me.cmdMdlSave.Location = New System.Drawing.Point(386, 20)
		Me.cmdMdlSave.TabIndex = 88
		Me.cmdMdlSave.BackColor = System.Drawing.SystemColors.Control
		Me.cmdMdlSave.CausesValidation = True
		Me.cmdMdlSave.Enabled = True
		Me.cmdMdlSave.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdMdlSave.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdMdlSave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdMdlSave.TabStop = True
		Me.cmdMdlSave.Name = "cmdMdlSave"
		Me.txtMdl.AutoSize = False
		Me.txtMdl.Size = New System.Drawing.Size(239, 21)
		Me.txtMdl.Location = New System.Drawing.Point(76, 22)
		Me.txtMdl.TabIndex = 87
		Me.txtMdl.AcceptsReturn = True
		Me.txtMdl.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMdl.BackColor = System.Drawing.SystemColors.Window
		Me.txtMdl.CausesValidation = True
		Me.txtMdl.Enabled = True
		Me.txtMdl.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMdl.HideSelection = True
		Me.txtMdl.ReadOnly = False
		Me.txtMdl.Maxlength = 0
		Me.txtMdl.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMdl.MultiLine = False
		Me.txtMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMdl.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMdl.TabStop = True
		Me.txtMdl.Visible = True
		Me.txtMdl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMdl.Name = "txtMdl"
		Me.Label29.BackColor = System.Drawing.Color.White
		Me.Label29.Text = "模  式："
		Me.Label29.Size = New System.Drawing.Size(59, 15)
		Me.Label29.Location = New System.Drawing.Point(26, 26)
		Me.Label29.TabIndex = 90
		Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label29.Enabled = True
		Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label29.UseMnemonic = True
		Me.Label29.Visible = True
		Me.Label29.AutoSize = False
		Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label29.Name = "Label29"
		Me.Label28.BackColor = System.Drawing.Color.White
		Me.Label28.Text = "(逗号分隔)"
		Me.Label28.Size = New System.Drawing.Size(61, 15)
		Me.Label28.Location = New System.Drawing.Point(316, 26)
		Me.Label28.TabIndex = 89
		Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label28.Enabled = True
		Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label28.UseMnemonic = True
		Me.Label28.Visible = True
		Me.Label28.AutoSize = False
		Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label28.Name = "Label28"
		Me.Frame10.BackColor = System.Drawing.Color.White
		Me.Frame10.Text = "传感器压力值范围设定            "
		Me.Frame10.Size = New System.Drawing.Size(575, 51)
		Me.Frame10.Location = New System.Drawing.Point(10, 216)
		Me.Frame10.TabIndex = 39
		Me.Frame10.Enabled = True
		Me.Frame10.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame10.Visible = True
		Me.Frame10.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame10.Name = "Frame10"
		Me.cmdPreSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdPreSave.Text = "保存"
		Me.cmdPreSave.Size = New System.Drawing.Size(95, 23)
		Me.cmdPreSave.Location = New System.Drawing.Point(386, 18)
		Me.cmdPreSave.TabIndex = 44
		Me.cmdPreSave.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPreSave.CausesValidation = True
		Me.cmdPreSave.Enabled = True
		Me.cmdPreSave.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPreSave.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPreSave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPreSave.TabStop = True
		Me.cmdPreSave.Name = "cmdPreSave"
		Me.txtPreMax.AutoSize = False
		Me.txtPreMax.Size = New System.Drawing.Size(101, 21)
		Me.txtPreMax.Location = New System.Drawing.Point(272, 20)
		Me.txtPreMax.TabIndex = 43
		Me.txtPreMax.AcceptsReturn = True
		Me.txtPreMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPreMax.BackColor = System.Drawing.SystemColors.Window
		Me.txtPreMax.CausesValidation = True
		Me.txtPreMax.Enabled = True
		Me.txtPreMax.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPreMax.HideSelection = True
		Me.txtPreMax.ReadOnly = False
		Me.txtPreMax.Maxlength = 0
		Me.txtPreMax.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPreMax.MultiLine = False
		Me.txtPreMax.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPreMax.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPreMax.TabStop = True
		Me.txtPreMax.Visible = True
		Me.txtPreMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPreMax.Name = "txtPreMax"
		Me.txtPreMin.AutoSize = False
		Me.txtPreMin.Size = New System.Drawing.Size(101, 21)
		Me.txtPreMin.Location = New System.Drawing.Point(76, 20)
		Me.txtPreMin.TabIndex = 41
		Me.txtPreMin.AcceptsReturn = True
		Me.txtPreMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPreMin.BackColor = System.Drawing.SystemColors.Window
		Me.txtPreMin.CausesValidation = True
		Me.txtPreMin.Enabled = True
		Me.txtPreMin.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPreMin.HideSelection = True
		Me.txtPreMin.ReadOnly = False
		Me.txtPreMin.Maxlength = 0
		Me.txtPreMin.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPreMin.MultiLine = False
		Me.txtPreMin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPreMin.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPreMin.TabStop = True
		Me.txtPreMin.Visible = True
		Me.txtPreMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPreMin.Name = "txtPreMin"
		Me.Label16.BackColor = System.Drawing.Color.White
		Me.Label16.Text = "最大值："
		Me.Label16.Size = New System.Drawing.Size(59, 15)
		Me.Label16.Location = New System.Drawing.Point(222, 24)
		Me.Label16.TabIndex = 42
		Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label16.Enabled = True
		Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label16.UseMnemonic = True
		Me.Label16.Visible = True
		Me.Label16.AutoSize = False
		Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label16.Name = "Label16"
		Me.Label13.BackColor = System.Drawing.Color.White
		Me.Label13.Text = "最小值："
		Me.Label13.Size = New System.Drawing.Size(59, 15)
		Me.Label13.Location = New System.Drawing.Point(26, 24)
		Me.Label13.TabIndex = 40
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label13.Enabled = True
		Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label13.UseMnemonic = True
		Me.Label13.Visible = True
		Me.Label13.AutoSize = False
		Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label13.Name = "Label13"
		Me.Frame12.BackColor = System.Drawing.Color.White
		Me.Frame12.Text = "传感器加速度值范围设定            "
		Me.Frame12.Size = New System.Drawing.Size(573, 51)
		Me.Frame12.Location = New System.Drawing.Point(12, 336)
		Me.Frame12.TabIndex = 51
		Me.Frame12.Enabled = True
		Me.Frame12.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame12.Visible = True
		Me.Frame12.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame12.Name = "Frame12"
		Me.cmdAcSpeedSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAcSpeedSave.Text = "保存"
		Me.cmdAcSpeedSave.Size = New System.Drawing.Size(95, 23)
		Me.cmdAcSpeedSave.Location = New System.Drawing.Point(386, 16)
		Me.cmdAcSpeedSave.TabIndex = 54
		Me.cmdAcSpeedSave.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAcSpeedSave.CausesValidation = True
		Me.cmdAcSpeedSave.Enabled = True
		Me.cmdAcSpeedSave.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAcSpeedSave.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAcSpeedSave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAcSpeedSave.TabStop = True
		Me.cmdAcSpeedSave.Name = "cmdAcSpeedSave"
		Me.txtAcSpeedMax.AutoSize = False
		Me.txtAcSpeedMax.Size = New System.Drawing.Size(101, 21)
		Me.txtAcSpeedMax.Location = New System.Drawing.Point(272, 18)
		Me.txtAcSpeedMax.TabIndex = 53
		Me.txtAcSpeedMax.AcceptsReturn = True
		Me.txtAcSpeedMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAcSpeedMax.BackColor = System.Drawing.SystemColors.Window
		Me.txtAcSpeedMax.CausesValidation = True
		Me.txtAcSpeedMax.Enabled = True
		Me.txtAcSpeedMax.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAcSpeedMax.HideSelection = True
		Me.txtAcSpeedMax.ReadOnly = False
		Me.txtAcSpeedMax.Maxlength = 0
		Me.txtAcSpeedMax.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAcSpeedMax.MultiLine = False
		Me.txtAcSpeedMax.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAcSpeedMax.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAcSpeedMax.TabStop = True
		Me.txtAcSpeedMax.Visible = True
		Me.txtAcSpeedMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAcSpeedMax.Name = "txtAcSpeedMax"
		Me.txtAcSpeedMin.AutoSize = False
		Me.txtAcSpeedMin.Size = New System.Drawing.Size(101, 21)
		Me.txtAcSpeedMin.Location = New System.Drawing.Point(74, 18)
		Me.txtAcSpeedMin.TabIndex = 52
		Me.txtAcSpeedMin.AcceptsReturn = True
		Me.txtAcSpeedMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAcSpeedMin.BackColor = System.Drawing.SystemColors.Window
		Me.txtAcSpeedMin.CausesValidation = True
		Me.txtAcSpeedMin.Enabled = True
		Me.txtAcSpeedMin.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAcSpeedMin.HideSelection = True
		Me.txtAcSpeedMin.ReadOnly = False
		Me.txtAcSpeedMin.Maxlength = 0
		Me.txtAcSpeedMin.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAcSpeedMin.MultiLine = False
		Me.txtAcSpeedMin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAcSpeedMin.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAcSpeedMin.TabStop = True
		Me.txtAcSpeedMin.Visible = True
		Me.txtAcSpeedMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAcSpeedMin.Name = "txtAcSpeedMin"
		Me.Label18.BackColor = System.Drawing.Color.White
		Me.Label18.Text = "最大值："
		Me.Label18.Size = New System.Drawing.Size(59, 15)
		Me.Label18.Location = New System.Drawing.Point(220, 22)
		Me.Label18.TabIndex = 56
		Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label18.Enabled = True
		Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label18.UseMnemonic = True
		Me.Label18.Visible = True
		Me.Label18.AutoSize = False
		Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label18.Name = "Label18"
		Me.Label17.BackColor = System.Drawing.Color.White
		Me.Label17.Text = "最小值："
		Me.Label17.Size = New System.Drawing.Size(59, 15)
		Me.Label17.Location = New System.Drawing.Point(26, 22)
		Me.Label17.TabIndex = 55
		Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label17.Enabled = True
		Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label17.UseMnemonic = True
		Me.Label17.Visible = True
		Me.Label17.AutoSize = False
		Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label17.Name = "Label17"
		Me.Frame11.BackColor = System.Drawing.Color.White
		Me.Frame11.Text = "传感器温度值范围设定            "
		Me.Frame11.Size = New System.Drawing.Size(573, 51)
		Me.Frame11.Location = New System.Drawing.Point(12, 276)
		Me.Frame11.TabIndex = 45
		Me.Frame11.Enabled = True
		Me.Frame11.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame11.Visible = True
		Me.Frame11.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame11.Name = "Frame11"
		Me.txtTempMin.AutoSize = False
		Me.txtTempMin.Size = New System.Drawing.Size(101, 21)
		Me.txtTempMin.Location = New System.Drawing.Point(74, 20)
		Me.txtTempMin.TabIndex = 48
		Me.txtTempMin.AcceptsReturn = True
		Me.txtTempMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTempMin.BackColor = System.Drawing.SystemColors.Window
		Me.txtTempMin.CausesValidation = True
		Me.txtTempMin.Enabled = True
		Me.txtTempMin.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTempMin.HideSelection = True
		Me.txtTempMin.ReadOnly = False
		Me.txtTempMin.Maxlength = 0
		Me.txtTempMin.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTempMin.MultiLine = False
		Me.txtTempMin.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTempMin.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTempMin.TabStop = True
		Me.txtTempMin.Visible = True
		Me.txtTempMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTempMin.Name = "txtTempMin"
		Me.txtTempMax.AutoSize = False
		Me.txtTempMax.Size = New System.Drawing.Size(101, 21)
		Me.txtTempMax.Location = New System.Drawing.Point(272, 20)
		Me.txtTempMax.TabIndex = 47
		Me.txtTempMax.AcceptsReturn = True
		Me.txtTempMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTempMax.BackColor = System.Drawing.SystemColors.Window
		Me.txtTempMax.CausesValidation = True
		Me.txtTempMax.Enabled = True
		Me.txtTempMax.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTempMax.HideSelection = True
		Me.txtTempMax.ReadOnly = False
		Me.txtTempMax.Maxlength = 0
		Me.txtTempMax.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTempMax.MultiLine = False
		Me.txtTempMax.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTempMax.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTempMax.TabStop = True
		Me.txtTempMax.Visible = True
		Me.txtTempMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTempMax.Name = "txtTempMax"
		Me.cmdTempSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdTempSave.Text = "保存"
		Me.cmdTempSave.Size = New System.Drawing.Size(95, 23)
		Me.cmdTempSave.Location = New System.Drawing.Point(384, 18)
		Me.cmdTempSave.TabIndex = 46
		Me.cmdTempSave.BackColor = System.Drawing.SystemColors.Control
		Me.cmdTempSave.CausesValidation = True
		Me.cmdTempSave.Enabled = True
		Me.cmdTempSave.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdTempSave.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdTempSave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdTempSave.TabStop = True
		Me.cmdTempSave.Name = "cmdTempSave"
		Me.Label15.BackColor = System.Drawing.Color.White
		Me.Label15.Text = "最小值："
		Me.Label15.Size = New System.Drawing.Size(59, 15)
		Me.Label15.Location = New System.Drawing.Point(26, 24)
		Me.Label15.TabIndex = 50
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label15.Enabled = True
		Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label15.UseMnemonic = True
		Me.Label15.Visible = True
		Me.Label15.AutoSize = False
		Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label15.Name = "Label15"
		Me.Label14.BackColor = System.Drawing.Color.White
		Me.Label14.Text = "最大值："
		Me.Label14.Size = New System.Drawing.Size(59, 15)
		Me.Label14.Location = New System.Drawing.Point(220, 24)
		Me.Label14.TabIndex = 49
		Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label14.Enabled = True
		Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label14.UseMnemonic = True
		Me.Label14.Visible = True
		Me.Label14.AutoSize = False
		Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label14.Name = "Label14"
		Me.Frame9.BackColor = System.Drawing.Color.White
		Me.Frame9.Text = "排产队列检验模式    "
		Me.Frame9.Size = New System.Drawing.Size(571, 51)
		Me.Frame9.Location = New System.Drawing.Point(14, 12)
		Me.Frame9.TabIndex = 38
		Me.Frame9.Enabled = True
		Me.Frame9.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame9.Visible = True
		Me.Frame9.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame9.Name = "Frame9"
		Me.chkOnlyScanVINCode.BackColor = System.Drawing.Color.White
		Me.chkOnlyScanVINCode.Text = "Check1"
		Me.chkOnlyScanVINCode.Size = New System.Drawing.Size(13, 23)
		Me.chkOnlyScanVINCode.Location = New System.Drawing.Point(362, 12)
		Me.chkOnlyScanVINCode.TabIndex = 84
		Me.chkOnlyScanVINCode.Visible = False
		Me.chkOnlyScanVINCode.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkOnlyScanVINCode.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkOnlyScanVINCode.CausesValidation = True
		Me.chkOnlyScanVINCode.Enabled = True
		Me.chkOnlyScanVINCode.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkOnlyScanVINCode.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkOnlyScanVINCode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkOnlyScanVINCode.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkOnlyScanVINCode.TabStop = True
		Me.chkOnlyScanVINCode.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkOnlyScanVINCode.Name = "chkOnlyScanVINCode"
		Me.chkAllQueue.BackColor = System.Drawing.Color.White
		Me.chkAllQueue.Text = "Check1"
		Me.chkAllQueue.Size = New System.Drawing.Size(13, 23)
		Me.chkAllQueue.Location = New System.Drawing.Point(22, 20)
		Me.chkAllQueue.TabIndex = 82
		Me.chkAllQueue.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkAllQueue.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkAllQueue.CausesValidation = True
		Me.chkAllQueue.Enabled = True
		Me.chkAllQueue.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkAllQueue.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkAllQueue.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkAllQueue.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkAllQueue.TabStop = True
		Me.chkAllQueue.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkAllQueue.Visible = True
		Me.chkAllQueue.Name = "chkAllQueue"
		Me.Command10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command10.Text = "查看排产队列数据"
		Me.Command10.Size = New System.Drawing.Size(19, 27)
		Me.Command10.Location = New System.Drawing.Point(334, 10)
		Me.Command10.TabIndex = 80
		Me.Command10.Visible = False
		Me.Command10.BackColor = System.Drawing.SystemColors.Control
		Me.Command10.CausesValidation = True
		Me.Command10.Enabled = True
		Me.Command10.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command10.TabStop = True
		Me.Command10.Name = "Command10"
		Me.Command5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command5.Text = "手动下载排产队列数据"
		Me.Command5.Size = New System.Drawing.Size(27, 27)
		Me.Command5.Location = New System.Drawing.Point(300, 10)
		Me.Command5.TabIndex = 79
		Me.Command5.Visible = False
		Me.Command5.BackColor = System.Drawing.SystemColors.Control
		Me.Command5.CausesValidation = True
		Me.Command5.Enabled = True
		Me.Command5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command5.TabStop = True
		Me.Command5.Name = "Command5"
		Me.Label27.Text = "仅扫描VIN码，从MES取MTOC码"
		Me.Label27.Size = New System.Drawing.Size(171, 15)
		Me.Label27.Location = New System.Drawing.Point(380, 16)
		Me.Label27.TabIndex = 85
		Me.Label27.Visible = False
		Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label27.BackColor = System.Drawing.Color.Transparent
		Me.Label27.Enabled = True
		Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label27.UseMnemonic = True
		Me.Label27.AutoSize = False
		Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label27.Name = "Label27"
		Me.Label25.Text = "校验排产队列信息"
		Me.Label25.Size = New System.Drawing.Size(120, 18)
		Me.Label25.Location = New System.Drawing.Point(40, 24)
		Me.Label25.TabIndex = 81
		Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label25.BackColor = System.Drawing.Color.Transparent
		Me.Label25.Enabled = True
		Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label25.UseMnemonic = True
		Me.Label25.Visible = True
		Me.Label25.AutoSize = False
		Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label25.Name = "Label25"
		Me.Frame8.BackColor = System.Drawing.Color.White
		Me.Frame8.Text = "修改管理密码      "
		Me.Frame8.Size = New System.Drawing.Size(573, 79)
		Me.Frame8.Location = New System.Drawing.Point(12, 68)
		Me.Frame8.TabIndex = 34
		Me.Frame8.Enabled = True
		Me.Frame8.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame8.Visible = True
		Me.Frame8.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame8.Name = "Frame8"
		WindowsXPC1.OcxState = CType(resources.GetObject("WindowsXPC1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.WindowsXPC1.Location = New System.Drawing.Point(488, 24)
		Me.WindowsXPC1.Name = "WindowsXPC1"
		Me.Text2.AutoSize = False
		Me.Text2.Size = New System.Drawing.Size(137, 21)
		Me.Text2.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.Text2.Location = New System.Drawing.Point(152, 44)
		Me.Text2.PasswordChar = ChrW(42)
		Me.Text2.TabIndex = 58
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
		Me.Text2.Visible = True
		Me.Text2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Text2.Name = "Text2"
		Me.Text1.AutoSize = False
		Me.Text1.Size = New System.Drawing.Size(137, 21)
		Me.Text1.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.Text1.Location = New System.Drawing.Point(152, 16)
		Me.Text1.PasswordChar = ChrW(42)
		Me.Text1.TabIndex = 57
		Me.Text1.AcceptsReturn = True
		Me.Text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.Text1.BackColor = System.Drawing.SystemColors.Window
		Me.Text1.CausesValidation = True
		Me.Text1.Enabled = True
		Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Text1.HideSelection = True
		Me.Text1.ReadOnly = False
		Me.Text1.Maxlength = 0
		Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text1.MultiLine = False
		Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.Text1.TabStop = True
		Me.Text1.Visible = True
		Me.Text1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Text1.Name = "Text1"
		Me.Command6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command6.Text = "保存新密码"
		Me.Command6.Size = New System.Drawing.Size(97, 25)
		Me.Command6.Location = New System.Drawing.Point(300, 42)
		Me.Command6.TabIndex = 35
		Me.Command6.BackColor = System.Drawing.SystemColors.Control
		Me.Command6.CausesValidation = True
		Me.Command6.Enabled = True
		Me.Command6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command6.TabStop = True
		Me.Command6.Name = "Command6"
		Me.Label11.Text = "请输入新密码："
		Me.Label11.Size = New System.Drawing.Size(120, 18)
		Me.Label11.Location = New System.Drawing.Point(40, 20)
		Me.Label11.TabIndex = 37
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label11.BackColor = System.Drawing.Color.Transparent
		Me.Label11.Enabled = True
		Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label11.UseMnemonic = True
		Me.Label11.Visible = True
		Me.Label11.AutoSize = False
		Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label11.Name = "Label11"
		Me.Label12.Text = "请再次输入新密码："
		Me.Label12.Size = New System.Drawing.Size(120, 18)
		Me.Label12.Location = New System.Drawing.Point(40, 49)
		Me.Label12.TabIndex = 36
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label12.BackColor = System.Drawing.Color.Transparent
		Me.Label12.Enabled = True
		Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label12.UseMnemonic = True
		Me.Label12.Visible = True
		Me.Label12.AutoSize = False
		Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label12.Name = "Label12"
		Me._SSTab1_TabPage3.Text = "TPMS特征码设置"
		Me.Frame13.BackColor = System.Drawing.Color.White
		Me.Frame13.Size = New System.Drawing.Size(607, 395)
		Me.Frame13.Location = New System.Drawing.Point(4, 24)
		Me.Frame13.TabIndex = 59
		Me.Frame13.Enabled = True
		Me.Frame13.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame13.Visible = True
		Me.Frame13.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame13.Name = "Frame13"
		Me.Frame18.BackColor = System.Drawing.Color.White
		Me.Frame18.Text = "诊断结果打印设置"
		Me.Frame18.Size = New System.Drawing.Size(593, 51)
		Me.Frame18.Location = New System.Drawing.Point(6, 338)
		Me.Frame18.TabIndex = 91
		Me.Frame18.Enabled = True
		Me.Frame18.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame18.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame18.Visible = True
		Me.Frame18.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame18.Name = "Frame18"
		Me.chkOnlyPrintNGWriteResult.BackColor = System.Drawing.Color.White
		Me.chkOnlyPrintNGWriteResult.Text = "chkPrintNGResult"
		Me.chkOnlyPrintNGWriteResult.Size = New System.Drawing.Size(13, 23)
		Me.chkOnlyPrintNGWriteResult.Location = New System.Drawing.Point(134, 18)
		Me.chkOnlyPrintNGWriteResult.TabIndex = 95
		Me.chkOnlyPrintNGWriteResult.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkOnlyPrintNGWriteResult.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkOnlyPrintNGWriteResult.CausesValidation = True
		Me.chkOnlyPrintNGWriteResult.Enabled = True
		Me.chkOnlyPrintNGWriteResult.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkOnlyPrintNGWriteResult.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkOnlyPrintNGWriteResult.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkOnlyPrintNGWriteResult.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkOnlyPrintNGWriteResult.TabStop = True
		Me.chkOnlyPrintNGWriteResult.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkOnlyPrintNGWriteResult.Visible = True
		Me.chkOnlyPrintNGWriteResult.Name = "chkOnlyPrintNGWriteResult"
		Me.chkPrintNGFlow.BackColor = System.Drawing.Color.White
		Me.chkPrintNGFlow.Text = "checkNGFlow"
		Me.chkPrintNGFlow.Size = New System.Drawing.Size(13, 23)
		Me.chkPrintNGFlow.Location = New System.Drawing.Point(288, 18)
		Me.chkPrintNGFlow.TabIndex = 94
		Me.chkPrintNGFlow.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkPrintNGFlow.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.chkPrintNGFlow.CausesValidation = True
		Me.chkPrintNGFlow.Enabled = True
		Me.chkPrintNGFlow.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkPrintNGFlow.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkPrintNGFlow.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkPrintNGFlow.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkPrintNGFlow.TabStop = True
		Me.chkPrintNGFlow.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkPrintNGFlow.Visible = True
		Me.chkPrintNGFlow.Name = "chkPrintNGFlow"
		Me.Command7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command7.Text = "手动打印"
		Me.Command7.Size = New System.Drawing.Size(87, 25)
		Me.Command7.Location = New System.Drawing.Point(492, 18)
		Me.Command7.TabIndex = 93
		Me.Command7.BackColor = System.Drawing.SystemColors.Control
		Me.Command7.CausesValidation = True
		Me.Command7.Enabled = True
		Me.Command7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command7.TabStop = True
		Me.Command7.Name = "Command7"
		Me.txtVIN.AutoSize = False
		Me.txtVIN.Size = New System.Drawing.Size(135, 21)
		Me.txtVIN.Location = New System.Drawing.Point(352, 20)
		Me.txtVIN.TabIndex = 92
		Me.txtVIN.AcceptsReturn = True
		Me.txtVIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtVIN.BackColor = System.Drawing.SystemColors.Window
		Me.txtVIN.CausesValidation = True
		Me.txtVIN.Enabled = True
		Me.txtVIN.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtVIN.HideSelection = True
		Me.txtVIN.ReadOnly = False
		Me.txtVIN.Maxlength = 0
		Me.txtVIN.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtVIN.MultiLine = False
		Me.txtVIN.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtVIN.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtVIN.TabStop = True
		Me.txtVIN.Visible = True
		Me.txtVIN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtVIN.Name = "txtVIN"
		Me.Label31.BackColor = System.Drawing.Color.White
		Me.Label31.Text = "仅打印NG的诊断结果："
		Me.Label31.Size = New System.Drawing.Size(121, 15)
		Me.Label31.Location = New System.Drawing.Point(12, 24)
		Me.Label31.TabIndex = 98
		Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label31.Enabled = True
		Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label31.UseMnemonic = True
		Me.Label31.Visible = True
		Me.Label31.AutoSize = False
		Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label31.Name = "Label31"
		Me.Label32.BackColor = System.Drawing.Color.White
		Me.Label32.Text = "VIN："
		Me.Label32.Size = New System.Drawing.Size(29, 15)
		Me.Label32.Location = New System.Drawing.Point(320, 24)
		Me.Label32.TabIndex = 97
		Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label32.Enabled = True
		Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label32.UseMnemonic = True
		Me.Label32.Visible = True
		Me.Label32.AutoSize = False
		Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label32.Name = "Label32"
		Me.Label30.BackColor = System.Drawing.Color.White
		Me.Label30.Text = "仅打印NG的诊断流程："
		Me.Label30.Size = New System.Drawing.Size(121, 15)
		Me.Label30.Location = New System.Drawing.Point(168, 24)
		Me.Label30.TabIndex = 96
		Me.Label30.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label30.Enabled = True
		Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label30.UseMnemonic = True
		Me.Label30.Visible = True
		Me.Label30.AutoSize = False
		Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label30.Name = "Label30"
		Me.Frame15.BackColor = System.Drawing.Color.White
		Me.Frame15.Text = "起始位设置      "
		Me.Frame15.Size = New System.Drawing.Size(593, 109)
		Me.Frame15.Location = New System.Drawing.Point(6, 224)
		Me.Frame15.TabIndex = 61
		Me.Frame15.Enabled = True
		Me.Frame15.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame15.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame15.Visible = True
		Me.Frame15.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame15.Name = "Frame15"
		Me.btMTOCModi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btMTOCModi.Text = "修改"
		Me.btMTOCModi.Size = New System.Drawing.Size(101, 25)
		Me.btMTOCModi.Location = New System.Drawing.Point(14, 74)
		Me.btMTOCModi.TabIndex = 77
		Me.btMTOCModi.BackColor = System.Drawing.SystemColors.Control
		Me.btMTOCModi.CausesValidation = True
		Me.btMTOCModi.Enabled = True
		Me.btMTOCModi.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btMTOCModi.Cursor = System.Windows.Forms.Cursors.Default
		Me.btMTOCModi.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btMTOCModi.TabStop = True
		Me.btMTOCModi.Name = "btMTOCModi"
		Me.txtMTOCLen.AutoSize = False
		Me.txtMTOCLen.Size = New System.Drawing.Size(113, 21)
		Me.txtMTOCLen.Location = New System.Drawing.Point(78, 48)
		Me.txtMTOCLen.TabIndex = 74
		Me.txtMTOCLen.AcceptsReturn = True
		Me.txtMTOCLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMTOCLen.BackColor = System.Drawing.SystemColors.Window
		Me.txtMTOCLen.CausesValidation = True
		Me.txtMTOCLen.Enabled = True
		Me.txtMTOCLen.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMTOCLen.HideSelection = True
		Me.txtMTOCLen.ReadOnly = False
		Me.txtMTOCLen.Maxlength = 0
		Me.txtMTOCLen.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMTOCLen.MultiLine = False
		Me.txtMTOCLen.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMTOCLen.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMTOCLen.TabStop = True
		Me.txtMTOCLen.Visible = True
		Me.txtMTOCLen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMTOCLen.Name = "txtMTOCLen"
		Me.txtMtocStartIndex.AutoSize = False
		Me.txtMtocStartIndex.Size = New System.Drawing.Size(113, 21)
		Me.txtMtocStartIndex.Location = New System.Drawing.Point(78, 20)
		Me.txtMtocStartIndex.TabIndex = 72
		Me.txtMtocStartIndex.AcceptsReturn = True
		Me.txtMtocStartIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMtocStartIndex.BackColor = System.Drawing.SystemColors.Window
		Me.txtMtocStartIndex.CausesValidation = True
		Me.txtMtocStartIndex.Enabled = True
		Me.txtMtocStartIndex.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMtocStartIndex.HideSelection = True
		Me.txtMtocStartIndex.ReadOnly = False
		Me.txtMtocStartIndex.Maxlength = 0
		Me.txtMtocStartIndex.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMtocStartIndex.MultiLine = False
		Me.txtMtocStartIndex.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMtocStartIndex.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMtocStartIndex.TabStop = True
		Me.txtMtocStartIndex.Visible = True
		Me.txtMtocStartIndex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMtocStartIndex.Name = "txtMtocStartIndex"
		Me.Label24.BackColor = System.Drawing.Color.White
		Me.Label24.Text = "备注：MTOC码为BF1B-FM6-00-B1-V，特征位长为3，则特征码为FM6；"
		Me.Label24.Size = New System.Drawing.Size(377, 15)
		Me.Label24.Location = New System.Drawing.Point(204, 50)
		Me.Label24.TabIndex = 76
		Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label24.Enabled = True
		Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label24.UseMnemonic = True
		Me.Label24.Visible = True
		Me.Label24.AutoSize = False
		Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label24.Name = "Label24"
		Me.Label23.BackColor = System.Drawing.Color.White
		Me.Label23.Text = "备注：MTOC码为BF1B-FM6-00-B1-V，起始位为6，则从第二个F开始；"
		Me.Label23.Size = New System.Drawing.Size(377, 15)
		Me.Label23.Location = New System.Drawing.Point(204, 24)
		Me.Label23.TabIndex = 75
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
		Me.Label22.BackColor = System.Drawing.Color.White
		Me.Label22.Text = "特征码长："
		Me.Label22.Size = New System.Drawing.Size(61, 15)
		Me.Label22.Location = New System.Drawing.Point(16, 50)
		Me.Label22.TabIndex = 73
		Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label22.Enabled = True
		Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label22.UseMnemonic = True
		Me.Label22.Visible = True
		Me.Label22.AutoSize = False
		Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label22.Name = "Label22"
		Me.Label21.BackColor = System.Drawing.Color.White
		Me.Label21.Text = "起始位置："
		Me.Label21.Size = New System.Drawing.Size(61, 15)
		Me.Label21.Location = New System.Drawing.Point(16, 24)
		Me.Label21.TabIndex = 71
		Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label21.Enabled = True
		Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label21.UseMnemonic = True
		Me.Label21.Visible = True
		Me.Label21.AutoSize = False
		Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label21.Name = "Label21"
		Me.Frame14.BackColor = System.Drawing.Color.White
		Me.Frame14.Text = "特征码列表      "
		Me.Frame14.Size = New System.Drawing.Size(595, 207)
		Me.Frame14.Location = New System.Drawing.Point(4, 12)
		Me.Frame14.TabIndex = 60
		Me.Frame14.Enabled = True
		Me.Frame14.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame14.Visible = True
		Me.Frame14.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame14.Name = "Frame14"
		Me.Frame16.BackColor = System.Drawing.Color.White
		Me.Frame16.Size = New System.Drawing.Size(261, 173)
		Me.Frame16.Location = New System.Drawing.Point(322, 16)
		Me.Frame16.TabIndex = 63
		Me.Frame16.Enabled = True
		Me.Frame16.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame16.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame16.Visible = True
		Me.Frame16.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame16.Name = "Frame16"
		Me.btTPMSCancle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btTPMSCancle.Text = "取消"
		Me.btTPMSCancle.Size = New System.Drawing.Size(73, 25)
		Me.btTPMSCancle.Location = New System.Drawing.Point(148, 122)
		Me.btTPMSCancle.TabIndex = 78
		Me.btTPMSCancle.BackColor = System.Drawing.SystemColors.Control
		Me.btTPMSCancle.CausesValidation = True
		Me.btTPMSCancle.Enabled = True
		Me.btTPMSCancle.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btTPMSCancle.Cursor = System.Windows.Forms.Cursors.Default
		Me.btTPMSCancle.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btTPMSCancle.TabStop = True
		Me.btTPMSCancle.Name = "btTPMSCancle"
		Me.btTPMSDel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btTPMSDel.Text = "删除"
		Me.btTPMSDel.Size = New System.Drawing.Size(73, 25)
		Me.btTPMSDel.Location = New System.Drawing.Point(28, 122)
		Me.btTPMSDel.TabIndex = 70
		Me.btTPMSDel.BackColor = System.Drawing.SystemColors.Control
		Me.btTPMSDel.CausesValidation = True
		Me.btTPMSDel.Enabled = True
		Me.btTPMSDel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btTPMSDel.Cursor = System.Windows.Forms.Cursors.Default
		Me.btTPMSDel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btTPMSDel.TabStop = True
		Me.btTPMSDel.Name = "btTPMSDel"
		Me.btTPMSModi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btTPMSModi.Text = "修改"
		Me.btTPMSModi.Size = New System.Drawing.Size(73, 25)
		Me.btTPMSModi.Location = New System.Drawing.Point(146, 82)
		Me.btTPMSModi.TabIndex = 69
		Me.btTPMSModi.BackColor = System.Drawing.SystemColors.Control
		Me.btTPMSModi.CausesValidation = True
		Me.btTPMSModi.Enabled = True
		Me.btTPMSModi.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btTPMSModi.Cursor = System.Windows.Forms.Cursors.Default
		Me.btTPMSModi.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btTPMSModi.TabStop = True
		Me.btTPMSModi.Name = "btTPMSModi"
		Me.txtTPMSCode.AutoSize = False
		Me.txtTPMSCode.Size = New System.Drawing.Size(149, 21)
		Me.txtTPMSCode.Location = New System.Drawing.Point(82, 48)
		Me.txtTPMSCode.TabIndex = 67
		Me.txtTPMSCode.AcceptsReturn = True
		Me.txtTPMSCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTPMSCode.BackColor = System.Drawing.SystemColors.Window
		Me.txtTPMSCode.CausesValidation = True
		Me.txtTPMSCode.Enabled = True
		Me.txtTPMSCode.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTPMSCode.HideSelection = True
		Me.txtTPMSCode.ReadOnly = False
		Me.txtTPMSCode.Maxlength = 0
		Me.txtTPMSCode.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTPMSCode.MultiLine = False
		Me.txtTPMSCode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTPMSCode.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTPMSCode.TabStop = True
		Me.txtTPMSCode.Visible = True
		Me.txtTPMSCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTPMSCode.Name = "txtTPMSCode"
		Me.txtTPMSID.AutoSize = False
		Me.txtTPMSID.Enabled = False
		Me.txtTPMSID.Size = New System.Drawing.Size(149, 21)
		Me.txtTPMSID.Location = New System.Drawing.Point(82, 18)
		Me.txtTPMSID.ReadOnly = True
		Me.txtTPMSID.TabIndex = 65
		Me.txtTPMSID.AcceptsReturn = True
		Me.txtTPMSID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtTPMSID.BackColor = System.Drawing.SystemColors.Window
		Me.txtTPMSID.CausesValidation = True
		Me.txtTPMSID.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtTPMSID.HideSelection = True
		Me.txtTPMSID.Maxlength = 0
		Me.txtTPMSID.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtTPMSID.MultiLine = False
		Me.txtTPMSID.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtTPMSID.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtTPMSID.TabStop = True
		Me.txtTPMSID.Visible = True
		Me.txtTPMSID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtTPMSID.Name = "txtTPMSID"
		Me.btTPMSAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btTPMSAdd.Text = "新增"
		Me.btTPMSAdd.Size = New System.Drawing.Size(73, 25)
		Me.btTPMSAdd.Location = New System.Drawing.Point(28, 82)
		Me.btTPMSAdd.TabIndex = 64
		Me.btTPMSAdd.BackColor = System.Drawing.SystemColors.Control
		Me.btTPMSAdd.CausesValidation = True
		Me.btTPMSAdd.Enabled = True
		Me.btTPMSAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btTPMSAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.btTPMSAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btTPMSAdd.TabStop = True
		Me.btTPMSAdd.Name = "btTPMSAdd"
		Me.Label20.BackColor = System.Drawing.Color.White
		Me.Label20.Text = "特征码："
		Me.Label20.Size = New System.Drawing.Size(49, 15)
		Me.Label20.Location = New System.Drawing.Point(20, 50)
		Me.Label20.TabIndex = 68
		Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label20.Enabled = True
		Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label20.UseMnemonic = True
		Me.Label20.Visible = True
		Me.Label20.AutoSize = False
		Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label20.Name = "Label20"
		Me.Label19.BackColor = System.Drawing.Color.White
		Me.Label19.Text = "编    号："
		Me.Label19.Size = New System.Drawing.Size(49, 15)
		Me.Label19.Location = New System.Drawing.Point(20, 20)
		Me.Label19.TabIndex = 66
		Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label19.Enabled = True
		Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label19.UseMnemonic = True
		Me.Label19.Visible = True
		Me.Label19.AutoSize = False
		Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label19.Name = "Label19"
		MSFlexGrid3.OcxState = CType(resources.GetObject("MSFlexGrid3.OcxState"), System.Windows.Forms.AxHost.State)
		Me.MSFlexGrid3.Size = New System.Drawing.Size(297, 167)
		Me.MSFlexGrid3.Location = New System.Drawing.Point(14, 24)
		Me.MSFlexGrid3.TabIndex = 62
		Me.MSFlexGrid3.Name = "MSFlexGrid3"
		Me.Label26.Text = "校验排产队列信息"
		Me.Label26.Size = New System.Drawing.Size(120, 18)
		Me.Label26.Location = New System.Drawing.Point(428, 74)
		Me.Label26.TabIndex = 83
		Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label26.BackColor = System.Drawing.Color.Transparent
		Me.Label26.Enabled = True
		Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label26.UseMnemonic = True
		Me.Label26.Visible = True
		Me.Label26.AutoSize = False
		Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label26.Name = "Label26"
		Me.Controls.Add(SSTab1)
		Me.Controls.Add(Label26)
		Me.SSTab1.Controls.Add(_SSTab1_TabPage0)
		Me.SSTab1.Controls.Add(_SSTab1_TabPage1)
		Me.SSTab1.Controls.Add(_SSTab1_TabPage2)
		Me.SSTab1.Controls.Add(_SSTab1_TabPage3)
		Me._SSTab1_TabPage0.Controls.Add(Frame1)
		Me.Frame1.Controls.Add(Frame3)
		Me.Frame1.Controls.Add(Frame2)
		Me.Frame3.Controls.Add(ComboRun)
		Me.Frame3.Controls.Add(MSFlexGrid1)
		Me.Frame3.Controls.Add(Label5)
		Me.Frame2.Controls.Add(Command2)
		Me.Frame2.Controls.Add(Command1)
		Me.Frame2.Controls.Add(txtValueRun)
		Me.Frame2.Controls.Add(txtDescriptionRun)
		Me.Frame2.Controls.Add(txtKeyRun)
		Me.Frame2.Controls.Add(txtGroupRun)
		Me.Frame2.Controls.Add(Label4)
		Me.Frame2.Controls.Add(Label3)
		Me.Frame2.Controls.Add(Label2)
		Me.Frame2.Controls.Add(Label1)
		Me._SSTab1_TabPage1.Controls.Add(Frame4)
		Me.Frame4.Controls.Add(Frame6)
		Me.Frame4.Controls.Add(Frame5)
		Me.Frame6.Controls.Add(txtGroupCtrl)
		Me.Frame6.Controls.Add(txtKeyCtrl)
		Me.Frame6.Controls.Add(txtDescriptionCtrl)
		Me.Frame6.Controls.Add(txtValueCtrl)
		Me.Frame6.Controls.Add(Command4)
		Me.Frame6.Controls.Add(Command3)
		Me.Frame6.Controls.Add(Label10)
		Me.Frame6.Controls.Add(Label9)
		Me.Frame6.Controls.Add(Label8)
		Me.Frame6.Controls.Add(Label7)
		Me.Frame5.Controls.Add(ComboCtrl)
		Me.Frame5.Controls.Add(MSFlexGrid2)
		Me.Frame5.Controls.Add(Label6)
		Me._SSTab1_TabPage2.Controls.Add(Frame7)
		Me.Frame7.Controls.Add(Frame17)
		Me.Frame7.Controls.Add(Frame10)
		Me.Frame7.Controls.Add(Frame12)
		Me.Frame7.Controls.Add(Frame11)
		Me.Frame7.Controls.Add(Frame9)
		Me.Frame7.Controls.Add(Frame8)
		Me.Frame17.Controls.Add(cmdMdlSave)
		Me.Frame17.Controls.Add(txtMdl)
		Me.Frame17.Controls.Add(Label29)
		Me.Frame17.Controls.Add(Label28)
		Me.Frame10.Controls.Add(cmdPreSave)
		Me.Frame10.Controls.Add(txtPreMax)
		Me.Frame10.Controls.Add(txtPreMin)
		Me.Frame10.Controls.Add(Label16)
		Me.Frame10.Controls.Add(Label13)
		Me.Frame12.Controls.Add(cmdAcSpeedSave)
		Me.Frame12.Controls.Add(txtAcSpeedMax)
		Me.Frame12.Controls.Add(txtAcSpeedMin)
		Me.Frame12.Controls.Add(Label18)
		Me.Frame12.Controls.Add(Label17)
		Me.Frame11.Controls.Add(txtTempMin)
		Me.Frame11.Controls.Add(txtTempMax)
		Me.Frame11.Controls.Add(cmdTempSave)
		Me.Frame11.Controls.Add(Label15)
		Me.Frame11.Controls.Add(Label14)
		Me.Frame9.Controls.Add(chkOnlyScanVINCode)
		Me.Frame9.Controls.Add(chkAllQueue)
		Me.Frame9.Controls.Add(Command10)
		Me.Frame9.Controls.Add(Command5)
		Me.Frame9.Controls.Add(Label27)
		Me.Frame9.Controls.Add(Label25)
		Me.Frame8.Controls.Add(WindowsXPC1)
		Me.Frame8.Controls.Add(Text2)
		Me.Frame8.Controls.Add(Text1)
		Me.Frame8.Controls.Add(Command6)
		Me.Frame8.Controls.Add(Label11)
		Me.Frame8.Controls.Add(Label12)
		Me._SSTab1_TabPage3.Controls.Add(Frame13)
		Me.Frame13.Controls.Add(Frame18)
		Me.Frame13.Controls.Add(Frame15)
		Me.Frame13.Controls.Add(Frame14)
		Me.Frame18.Controls.Add(chkOnlyPrintNGWriteResult)
		Me.Frame18.Controls.Add(chkPrintNGFlow)
		Me.Frame18.Controls.Add(Command7)
		Me.Frame18.Controls.Add(txtVIN)
		Me.Frame18.Controls.Add(Label31)
		Me.Frame18.Controls.Add(Label32)
		Me.Frame18.Controls.Add(Label30)
		Me.Frame15.Controls.Add(btMTOCModi)
		Me.Frame15.Controls.Add(txtMTOCLen)
		Me.Frame15.Controls.Add(txtMtocStartIndex)
		Me.Frame15.Controls.Add(Label24)
		Me.Frame15.Controls.Add(Label23)
		Me.Frame15.Controls.Add(Label22)
		Me.Frame15.Controls.Add(Label21)
		Me.Frame14.Controls.Add(Frame16)
		Me.Frame14.Controls.Add(MSFlexGrid3)
		Me.Frame16.Controls.Add(btTPMSCancle)
		Me.Frame16.Controls.Add(btTPMSDel)
		Me.Frame16.Controls.Add(btTPMSModi)
		Me.Frame16.Controls.Add(txtTPMSCode)
		Me.Frame16.Controls.Add(txtTPMSID)
		Me.Frame16.Controls.Add(btTPMSAdd)
		Me.Frame16.Controls.Add(Label20)
		Me.Frame16.Controls.Add(Label19)
		CType(Me.MSFlexGrid3, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.MSFlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.MSFlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SSTab1.ResumeLayout(False)
		Me._SSTab1_TabPage0.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me.Frame3.ResumeLayout(False)
		Me.Frame2.ResumeLayout(False)
		Me._SSTab1_TabPage1.ResumeLayout(False)
		Me.Frame4.ResumeLayout(False)
		Me.Frame6.ResumeLayout(False)
		Me.Frame5.ResumeLayout(False)
		Me._SSTab1_TabPage2.ResumeLayout(False)
		Me.Frame7.ResumeLayout(False)
		Me.Frame17.ResumeLayout(False)
		Me.Frame10.ResumeLayout(False)
		Me.Frame12.ResumeLayout(False)
		Me.Frame11.ResumeLayout(False)
		Me.Frame9.ResumeLayout(False)
		Me.Frame8.ResumeLayout(False)
		Me._SSTab1_TabPage3.ResumeLayout(False)
		Me.Frame13.ResumeLayout(False)
		Me.Frame18.ResumeLayout(False)
		Me.Frame15.ResumeLayout(False)
		Me.Frame14.ResumeLayout(False)
		Me.Frame16.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class