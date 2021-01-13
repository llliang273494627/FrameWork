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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOption))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SSTab1 = New System.Windows.Forms.TabControl()
        Me._SSTab1_TabPage0 = New System.Windows.Forms.TabPage()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.ComboRun = New System.Windows.Forms.ComboBox()
        Me.MSFlexGrid1 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.txtValueRun = New System.Windows.Forms.TextBox()
        Me.txtDescriptionRun = New System.Windows.Forms.TextBox()
        Me.txtKeyRun = New System.Windows.Forms.TextBox()
        Me.txtGroupRun = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me._SSTab1_TabPage1 = New System.Windows.Forms.TabPage()
        Me.Frame4 = New System.Windows.Forms.GroupBox()
        Me.Frame6 = New System.Windows.Forms.GroupBox()
        Me.txtGroupCtrl = New System.Windows.Forms.TextBox()
        Me.txtKeyCtrl = New System.Windows.Forms.TextBox()
        Me.txtDescriptionCtrl = New System.Windows.Forms.TextBox()
        Me.txtValueCtrl = New System.Windows.Forms.TextBox()
        Me.Command4 = New System.Windows.Forms.Button()
        Me.Command3 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Frame5 = New System.Windows.Forms.GroupBox()
        Me.ComboCtrl = New System.Windows.Forms.ComboBox()
        Me.MSFlexGrid2 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.Label6 = New System.Windows.Forms.Label()
        Me._SSTab1_TabPage2 = New System.Windows.Forms.TabPage()
        Me.Frame7 = New System.Windows.Forms.GroupBox()
        Me.Frame17 = New System.Windows.Forms.GroupBox()
        Me.cmdMdlSave = New System.Windows.Forms.Button()
        Me.txtMdl = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Frame10 = New System.Windows.Forms.GroupBox()
        Me.cmdPreSave = New System.Windows.Forms.Button()
        Me.txtPreMax = New System.Windows.Forms.TextBox()
        Me.txtPreMin = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Frame12 = New System.Windows.Forms.GroupBox()
        Me.cmdAcSpeedSave = New System.Windows.Forms.Button()
        Me.txtAcSpeedMax = New System.Windows.Forms.TextBox()
        Me.txtAcSpeedMin = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Frame11 = New System.Windows.Forms.GroupBox()
        Me.txtTempMin = New System.Windows.Forms.TextBox()
        Me.txtTempMax = New System.Windows.Forms.TextBox()
        Me.cmdTempSave = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Frame9 = New System.Windows.Forms.GroupBox()
        Me.chkOnlyScanVINCode = New System.Windows.Forms.CheckBox()
        Me.chkAllQueue = New System.Windows.Forms.CheckBox()
        Me.Command10 = New System.Windows.Forms.Button()
        Me.Command5 = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Frame8 = New System.Windows.Forms.GroupBox()
        Me.WindowsXPC1 = New AxWinXPC_Engine.AxWindowsXPC()
        Me.Text2 = New System.Windows.Forms.TextBox()
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.Command6 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me._SSTab1_TabPage3 = New System.Windows.Forms.TabPage()
        Me.Frame13 = New System.Windows.Forms.GroupBox()
        Me.Frame18 = New System.Windows.Forms.GroupBox()
        Me.chkOnlyPrintNGWriteResult = New System.Windows.Forms.CheckBox()
        Me.chkPrintNGFlow = New System.Windows.Forms.CheckBox()
        Me.Command7 = New System.Windows.Forms.Button()
        Me.txtVIN = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Frame15 = New System.Windows.Forms.GroupBox()
        Me.btMTOCModi = New System.Windows.Forms.Button()
        Me.txtMTOCLen = New System.Windows.Forms.TextBox()
        Me.txtMtocStartIndex = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Frame14 = New System.Windows.Forms.GroupBox()
        Me.Frame16 = New System.Windows.Forms.GroupBox()
        Me.btTPMSCancle = New System.Windows.Forms.Button()
        Me.btTPMSDel = New System.Windows.Forms.Button()
        Me.btTPMSModi = New System.Windows.Forms.Button()
        Me.txtTPMSCode = New System.Windows.Forms.TextBox()
        Me.txtTPMSID = New System.Windows.Forms.TextBox()
        Me.btTPMSAdd = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.MSFlexGrid3 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.SSTab1.SuspendLayout()
        Me._SSTab1_TabPage0.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Frame3.SuspendLayout()
        CType(Me.MSFlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame2.SuspendLayout()
        Me._SSTab1_TabPage1.SuspendLayout()
        Me.Frame4.SuspendLayout()
        Me.Frame6.SuspendLayout()
        Me.Frame5.SuspendLayout()
        CType(Me.MSFlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._SSTab1_TabPage2.SuspendLayout()
        Me.Frame7.SuspendLayout()
        Me.Frame17.SuspendLayout()
        Me.Frame10.SuspendLayout()
        Me.Frame12.SuspendLayout()
        Me.Frame11.SuspendLayout()
        Me.Frame9.SuspendLayout()
        Me.Frame8.SuspendLayout()
        CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me._SSTab1_TabPage3.SuspendLayout()
        Me.Frame13.SuspendLayout()
        Me.Frame18.SuspendLayout()
        Me.Frame15.SuspendLayout()
        Me.Frame14.SuspendLayout()
        Me.Frame16.SuspendLayout()
        CType(Me.MSFlexGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SSTab1
        '
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage0)
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage1)
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage2)
        Me.SSTab1.Controls.Add(Me._SSTab1_TabPage3)
        Me.SSTab1.ItemSize = New System.Drawing.Size(42, 18)
        Me.SSTab1.Location = New System.Drawing.Point(0, 0)
        Me.SSTab1.Name = "SSTab1"
        Me.SSTab1.SelectedIndex = 2
        Me.SSTab1.Size = New System.Drawing.Size(619, 425)
        Me.SSTab1.TabIndex = 0
        '
        '_SSTab1_TabPage0
        '
        Me._SSTab1_TabPage0.Controls.Add(Me.Frame1)
        Me._SSTab1_TabPage0.Location = New System.Drawing.Point(4, 22)
        Me._SSTab1_TabPage0.Name = "_SSTab1_TabPage0"
        Me._SSTab1_TabPage0.Size = New System.Drawing.Size(611, 399)
        Me._SSTab1_TabPage0.TabIndex = 0
        Me._SSTab1_TabPage0.Text = "运行参数"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.White
        Me.Frame1.Controls.Add(Me.Frame3)
        Me.Frame1.Controls.Add(Me.Frame2)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(4, 24)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(609, 397)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.Color.White
        Me.Frame3.Controls.Add(Me.ComboRun)
        Me.Frame3.Controls.Add(Me.MSFlexGrid1)
        Me.Frame3.Controls.Add(Me.Label5)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(6, 18)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(367, 373)
        Me.Frame3.TabIndex = 13
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "参数列表    "
        '
        'ComboRun
        '
        Me.ComboRun.BackColor = System.Drawing.SystemColors.Window
        Me.ComboRun.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboRun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboRun.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboRun.Location = New System.Drawing.Point(110, 18)
        Me.ComboRun.Name = "ComboRun"
        Me.ComboRun.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComboRun.Size = New System.Drawing.Size(171, 20)
        Me.ComboRun.TabIndex = 15
        '
        'MSFlexGrid1
        '
        Me.MSFlexGrid1.Location = New System.Drawing.Point(4, 50)
        Me.MSFlexGrid1.Name = "MSFlexGrid1"
        Me.MSFlexGrid1.OcxState = CType(resources.GetObject("MSFlexGrid1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.MSFlexGrid1.Size = New System.Drawing.Size(355, 315)
        Me.MSFlexGrid1.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(82, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(55, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "组："
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.Color.White
        Me.Frame2.Controls.Add(Me.Command2)
        Me.Frame2.Controls.Add(Me.Command1)
        Me.Frame2.Controls.Add(Me.txtValueRun)
        Me.Frame2.Controls.Add(Me.txtDescriptionRun)
        Me.Frame2.Controls.Add(Me.txtKeyRun)
        Me.Frame2.Controls.Add(Me.txtGroupRun)
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Controls.Add(Me.Label2)
        Me.Frame2.Controls.Add(Me.Label1)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(380, 18)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(223, 373)
        Me.Frame2.TabIndex = 2
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "修改  "
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(136, 290)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(73, 25)
        Me.Command2.TabIndex = 12
        Me.Command2.Text = "修改"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(30, 290)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(73, 25)
        Me.Command1.TabIndex = 11
        Me.Command1.Text = "取消"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'txtValueRun
        '
        Me.txtValueRun.AcceptsReturn = True
        Me.txtValueRun.BackColor = System.Drawing.SystemColors.Window
        Me.txtValueRun.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValueRun.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValueRun.Location = New System.Drawing.Point(68, 220)
        Me.txtValueRun.MaxLength = 0
        Me.txtValueRun.Name = "txtValueRun"
        Me.txtValueRun.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValueRun.Size = New System.Drawing.Size(139, 21)
        Me.txtValueRun.TabIndex = 10
        '
        'txtDescriptionRun
        '
        Me.txtDescriptionRun.AcceptsReturn = True
        Me.txtDescriptionRun.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescriptionRun.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescriptionRun.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDescriptionRun.Location = New System.Drawing.Point(68, 138)
        Me.txtDescriptionRun.MaxLength = 0
        Me.txtDescriptionRun.Name = "txtDescriptionRun"
        Me.txtDescriptionRun.ReadOnly = True
        Me.txtDescriptionRun.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDescriptionRun.Size = New System.Drawing.Size(139, 51)
        Me.txtDescriptionRun.TabIndex = 8
        '
        'txtKeyRun
        '
        Me.txtKeyRun.AcceptsReturn = True
        Me.txtKeyRun.BackColor = System.Drawing.SystemColors.Window
        Me.txtKeyRun.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtKeyRun.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtKeyRun.Location = New System.Drawing.Point(68, 92)
        Me.txtKeyRun.MaxLength = 0
        Me.txtKeyRun.Name = "txtKeyRun"
        Me.txtKeyRun.ReadOnly = True
        Me.txtKeyRun.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtKeyRun.Size = New System.Drawing.Size(139, 21)
        Me.txtKeyRun.TabIndex = 6
        '
        'txtGroupRun
        '
        Me.txtGroupRun.AcceptsReturn = True
        Me.txtGroupRun.BackColor = System.Drawing.SystemColors.Window
        Me.txtGroupRun.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGroupRun.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGroupRun.Location = New System.Drawing.Point(68, 46)
        Me.txtGroupRun.MaxLength = 0
        Me.txtGroupRun.Name = "txtGroupRun"
        Me.txtGroupRun.ReadOnly = True
        Me.txtGroupRun.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGroupRun.Size = New System.Drawing.Size(139, 21)
        Me.txtGroupRun.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(44, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "值："
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(32, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(49, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "描述："
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(20, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(49, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "关键字："
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(44, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "组："
        '
        '_SSTab1_TabPage1
        '
        Me._SSTab1_TabPage1.Controls.Add(Me.Frame4)
        Me._SSTab1_TabPage1.Location = New System.Drawing.Point(4, 22)
        Me._SSTab1_TabPage1.Name = "_SSTab1_TabPage1"
        Me._SSTab1_TabPage1.Size = New System.Drawing.Size(611, 399)
        Me._SSTab1_TabPage1.TabIndex = 1
        Me._SSTab1_TabPage1.Text = "控制参数"
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.Color.White
        Me.Frame4.Controls.Add(Me.Frame6)
        Me.Frame4.Controls.Add(Me.Frame5)
        Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame4.Location = New System.Drawing.Point(4, 24)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(609, 397)
        Me.Frame4.TabIndex = 17
        Me.Frame4.TabStop = False
        '
        'Frame6
        '
        Me.Frame6.BackColor = System.Drawing.Color.White
        Me.Frame6.Controls.Add(Me.txtGroupCtrl)
        Me.Frame6.Controls.Add(Me.txtKeyCtrl)
        Me.Frame6.Controls.Add(Me.txtDescriptionCtrl)
        Me.Frame6.Controls.Add(Me.txtValueCtrl)
        Me.Frame6.Controls.Add(Me.Command4)
        Me.Frame6.Controls.Add(Me.Command3)
        Me.Frame6.Controls.Add(Me.Label10)
        Me.Frame6.Controls.Add(Me.Label9)
        Me.Frame6.Controls.Add(Me.Label8)
        Me.Frame6.Controls.Add(Me.Label7)
        Me.Frame6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame6.Location = New System.Drawing.Point(380, 18)
        Me.Frame6.Name = "Frame6"
        Me.Frame6.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame6.Size = New System.Drawing.Size(223, 373)
        Me.Frame6.TabIndex = 22
        Me.Frame6.TabStop = False
        Me.Frame6.Text = "修改  "
        '
        'txtGroupCtrl
        '
        Me.txtGroupCtrl.AcceptsReturn = True
        Me.txtGroupCtrl.BackColor = System.Drawing.SystemColors.Window
        Me.txtGroupCtrl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGroupCtrl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGroupCtrl.Location = New System.Drawing.Point(70, 46)
        Me.txtGroupCtrl.MaxLength = 0
        Me.txtGroupCtrl.Name = "txtGroupCtrl"
        Me.txtGroupCtrl.ReadOnly = True
        Me.txtGroupCtrl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGroupCtrl.Size = New System.Drawing.Size(139, 21)
        Me.txtGroupCtrl.TabIndex = 28
        '
        'txtKeyCtrl
        '
        Me.txtKeyCtrl.AcceptsReturn = True
        Me.txtKeyCtrl.BackColor = System.Drawing.SystemColors.Window
        Me.txtKeyCtrl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtKeyCtrl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtKeyCtrl.Location = New System.Drawing.Point(70, 94)
        Me.txtKeyCtrl.MaxLength = 0
        Me.txtKeyCtrl.Name = "txtKeyCtrl"
        Me.txtKeyCtrl.ReadOnly = True
        Me.txtKeyCtrl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtKeyCtrl.Size = New System.Drawing.Size(139, 21)
        Me.txtKeyCtrl.TabIndex = 27
        '
        'txtDescriptionCtrl
        '
        Me.txtDescriptionCtrl.AcceptsReturn = True
        Me.txtDescriptionCtrl.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescriptionCtrl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescriptionCtrl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDescriptionCtrl.Location = New System.Drawing.Point(70, 138)
        Me.txtDescriptionCtrl.MaxLength = 0
        Me.txtDescriptionCtrl.Name = "txtDescriptionCtrl"
        Me.txtDescriptionCtrl.ReadOnly = True
        Me.txtDescriptionCtrl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDescriptionCtrl.Size = New System.Drawing.Size(139, 51)
        Me.txtDescriptionCtrl.TabIndex = 26
        '
        'txtValueCtrl
        '
        Me.txtValueCtrl.AcceptsReturn = True
        Me.txtValueCtrl.BackColor = System.Drawing.SystemColors.Window
        Me.txtValueCtrl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValueCtrl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValueCtrl.Location = New System.Drawing.Point(70, 214)
        Me.txtValueCtrl.MaxLength = 0
        Me.txtValueCtrl.Name = "txtValueCtrl"
        Me.txtValueCtrl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValueCtrl.Size = New System.Drawing.Size(139, 21)
        Me.txtValueCtrl.TabIndex = 25
        '
        'Command4
        '
        Me.Command4.BackColor = System.Drawing.SystemColors.Control
        Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command4.Location = New System.Drawing.Point(30, 294)
        Me.Command4.Name = "Command4"
        Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command4.Size = New System.Drawing.Size(73, 25)
        Me.Command4.TabIndex = 24
        Me.Command4.Text = "取消"
        Me.Command4.UseVisualStyleBackColor = False
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(136, 294)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(73, 25)
        Me.Command3.TabIndex = 23
        Me.Command3.Text = "修改"
        Me.Command3.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(44, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(41, 15)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "组："
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(20, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(51, 17)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "关键字："
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(32, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(39, 17)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "描述："
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(44, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(49, 17)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "值："
        '
        'Frame5
        '
        Me.Frame5.BackColor = System.Drawing.Color.White
        Me.Frame5.Controls.Add(Me.ComboCtrl)
        Me.Frame5.Controls.Add(Me.MSFlexGrid2)
        Me.Frame5.Controls.Add(Me.Label6)
        Me.Frame5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame5.Location = New System.Drawing.Point(6, 18)
        Me.Frame5.Name = "Frame5"
        Me.Frame5.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame5.Size = New System.Drawing.Size(367, 373)
        Me.Frame5.TabIndex = 18
        Me.Frame5.TabStop = False
        Me.Frame5.Text = "参数列表    "
        '
        'ComboCtrl
        '
        Me.ComboCtrl.BackColor = System.Drawing.SystemColors.Window
        Me.ComboCtrl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboCtrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCtrl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboCtrl.Location = New System.Drawing.Point(110, 18)
        Me.ComboCtrl.Name = "ComboCtrl"
        Me.ComboCtrl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComboCtrl.Size = New System.Drawing.Size(167, 20)
        Me.ComboCtrl.TabIndex = 19
        '
        'MSFlexGrid2
        '
        Me.MSFlexGrid2.Location = New System.Drawing.Point(4, 50)
        Me.MSFlexGrid2.Name = "MSFlexGrid2"
        Me.MSFlexGrid2.OcxState = CType(resources.GetObject("MSFlexGrid2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.MSFlexGrid2.Size = New System.Drawing.Size(357, 315)
        Me.MSFlexGrid2.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(84, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(55, 17)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "组："
        '
        '_SSTab1_TabPage2
        '
        Me._SSTab1_TabPage2.Controls.Add(Me.Frame7)
        Me._SSTab1_TabPage2.Location = New System.Drawing.Point(4, 22)
        Me._SSTab1_TabPage2.Name = "_SSTab1_TabPage2"
        Me._SSTab1_TabPage2.Size = New System.Drawing.Size(611, 399)
        Me._SSTab1_TabPage2.TabIndex = 2
        Me._SSTab1_TabPage2.Text = "手工维护"
        '
        'Frame7
        '
        Me.Frame7.BackColor = System.Drawing.Color.White
        Me.Frame7.Controls.Add(Me.Frame17)
        Me.Frame7.Controls.Add(Me.Frame10)
        Me.Frame7.Controls.Add(Me.Frame12)
        Me.Frame7.Controls.Add(Me.Frame11)
        Me.Frame7.Controls.Add(Me.Frame9)
        Me.Frame7.Controls.Add(Me.Frame8)
        Me.Frame7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame7.Location = New System.Drawing.Point(6, 24)
        Me.Frame7.Name = "Frame7"
        Me.Frame7.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame7.Size = New System.Drawing.Size(605, 395)
        Me.Frame7.TabIndex = 33
        Me.Frame7.TabStop = False
        '
        'Frame17
        '
        Me.Frame17.BackColor = System.Drawing.Color.White
        Me.Frame17.Controls.Add(Me.cmdMdlSave)
        Me.Frame17.Controls.Add(Me.txtMdl)
        Me.Frame17.Controls.Add(Me.Label29)
        Me.Frame17.Controls.Add(Me.Label28)
        Me.Frame17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame17.Location = New System.Drawing.Point(10, 154)
        Me.Frame17.Name = "Frame17"
        Me.Frame17.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame17.Size = New System.Drawing.Size(575, 53)
        Me.Frame17.TabIndex = 86
        Me.Frame17.TabStop = False
        Me.Frame17.Text = "传感器模式设定         "
        '
        'cmdMdlSave
        '
        Me.cmdMdlSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMdlSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdMdlSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMdlSave.Location = New System.Drawing.Point(386, 20)
        Me.cmdMdlSave.Name = "cmdMdlSave"
        Me.cmdMdlSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMdlSave.Size = New System.Drawing.Size(95, 23)
        Me.cmdMdlSave.TabIndex = 88
        Me.cmdMdlSave.Text = "保存"
        Me.cmdMdlSave.UseVisualStyleBackColor = False
        '
        'txtMdl
        '
        Me.txtMdl.AcceptsReturn = True
        Me.txtMdl.BackColor = System.Drawing.SystemColors.Window
        Me.txtMdl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMdl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMdl.Location = New System.Drawing.Point(76, 22)
        Me.txtMdl.MaxLength = 0
        Me.txtMdl.Name = "txtMdl"
        Me.txtMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMdl.Size = New System.Drawing.Size(239, 21)
        Me.txtMdl.TabIndex = 87
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.White
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(26, 26)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(59, 15)
        Me.Label29.TabIndex = 90
        Me.Label29.Text = "模  式："
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.White
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(316, 26)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(61, 15)
        Me.Label28.TabIndex = 89
        Me.Label28.Text = "(逗号分隔)"
        '
        'Frame10
        '
        Me.Frame10.BackColor = System.Drawing.Color.White
        Me.Frame10.Controls.Add(Me.cmdPreSave)
        Me.Frame10.Controls.Add(Me.txtPreMax)
        Me.Frame10.Controls.Add(Me.txtPreMin)
        Me.Frame10.Controls.Add(Me.Label16)
        Me.Frame10.Controls.Add(Me.Label13)
        Me.Frame10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame10.Location = New System.Drawing.Point(10, 216)
        Me.Frame10.Name = "Frame10"
        Me.Frame10.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame10.Size = New System.Drawing.Size(575, 51)
        Me.Frame10.TabIndex = 39
        Me.Frame10.TabStop = False
        Me.Frame10.Text = "传感器压力值范围设定            "
        '
        'cmdPreSave
        '
        Me.cmdPreSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPreSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPreSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPreSave.Location = New System.Drawing.Point(386, 18)
        Me.cmdPreSave.Name = "cmdPreSave"
        Me.cmdPreSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPreSave.Size = New System.Drawing.Size(95, 23)
        Me.cmdPreSave.TabIndex = 44
        Me.cmdPreSave.Text = "保存"
        Me.cmdPreSave.UseVisualStyleBackColor = False
        '
        'txtPreMax
        '
        Me.txtPreMax.AcceptsReturn = True
        Me.txtPreMax.BackColor = System.Drawing.SystemColors.Window
        Me.txtPreMax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPreMax.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPreMax.Location = New System.Drawing.Point(272, 20)
        Me.txtPreMax.MaxLength = 0
        Me.txtPreMax.Name = "txtPreMax"
        Me.txtPreMax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPreMax.Size = New System.Drawing.Size(101, 21)
        Me.txtPreMax.TabIndex = 43
        '
        'txtPreMin
        '
        Me.txtPreMin.AcceptsReturn = True
        Me.txtPreMin.BackColor = System.Drawing.SystemColors.Window
        Me.txtPreMin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPreMin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPreMin.Location = New System.Drawing.Point(76, 20)
        Me.txtPreMin.MaxLength = 0
        Me.txtPreMin.Name = "txtPreMin"
        Me.txtPreMin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPreMin.Size = New System.Drawing.Size(101, 21)
        Me.txtPreMin.TabIndex = 41
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.White
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(222, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(59, 15)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "最大值："
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(26, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(59, 15)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "最小值："
        '
        'Frame12
        '
        Me.Frame12.BackColor = System.Drawing.Color.White
        Me.Frame12.Controls.Add(Me.cmdAcSpeedSave)
        Me.Frame12.Controls.Add(Me.txtAcSpeedMax)
        Me.Frame12.Controls.Add(Me.txtAcSpeedMin)
        Me.Frame12.Controls.Add(Me.Label18)
        Me.Frame12.Controls.Add(Me.Label17)
        Me.Frame12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame12.Location = New System.Drawing.Point(12, 336)
        Me.Frame12.Name = "Frame12"
        Me.Frame12.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame12.Size = New System.Drawing.Size(573, 51)
        Me.Frame12.TabIndex = 51
        Me.Frame12.TabStop = False
        Me.Frame12.Text = "传感器加速度值范围设定            "
        '
        'cmdAcSpeedSave
        '
        Me.cmdAcSpeedSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAcSpeedSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAcSpeedSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAcSpeedSave.Location = New System.Drawing.Point(386, 16)
        Me.cmdAcSpeedSave.Name = "cmdAcSpeedSave"
        Me.cmdAcSpeedSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAcSpeedSave.Size = New System.Drawing.Size(95, 23)
        Me.cmdAcSpeedSave.TabIndex = 54
        Me.cmdAcSpeedSave.Text = "保存"
        Me.cmdAcSpeedSave.UseVisualStyleBackColor = False
        '
        'txtAcSpeedMax
        '
        Me.txtAcSpeedMax.AcceptsReturn = True
        Me.txtAcSpeedMax.BackColor = System.Drawing.SystemColors.Window
        Me.txtAcSpeedMax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAcSpeedMax.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAcSpeedMax.Location = New System.Drawing.Point(272, 18)
        Me.txtAcSpeedMax.MaxLength = 0
        Me.txtAcSpeedMax.Name = "txtAcSpeedMax"
        Me.txtAcSpeedMax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAcSpeedMax.Size = New System.Drawing.Size(101, 21)
        Me.txtAcSpeedMax.TabIndex = 53
        '
        'txtAcSpeedMin
        '
        Me.txtAcSpeedMin.AcceptsReturn = True
        Me.txtAcSpeedMin.BackColor = System.Drawing.SystemColors.Window
        Me.txtAcSpeedMin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAcSpeedMin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAcSpeedMin.Location = New System.Drawing.Point(74, 18)
        Me.txtAcSpeedMin.MaxLength = 0
        Me.txtAcSpeedMin.Name = "txtAcSpeedMin"
        Me.txtAcSpeedMin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAcSpeedMin.Size = New System.Drawing.Size(101, 21)
        Me.txtAcSpeedMin.TabIndex = 52
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(220, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(59, 15)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "最大值："
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.White
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(26, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(59, 15)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "最小值："
        '
        'Frame11
        '
        Me.Frame11.BackColor = System.Drawing.Color.White
        Me.Frame11.Controls.Add(Me.txtTempMin)
        Me.Frame11.Controls.Add(Me.txtTempMax)
        Me.Frame11.Controls.Add(Me.cmdTempSave)
        Me.Frame11.Controls.Add(Me.Label15)
        Me.Frame11.Controls.Add(Me.Label14)
        Me.Frame11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame11.Location = New System.Drawing.Point(12, 276)
        Me.Frame11.Name = "Frame11"
        Me.Frame11.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame11.Size = New System.Drawing.Size(573, 51)
        Me.Frame11.TabIndex = 45
        Me.Frame11.TabStop = False
        Me.Frame11.Text = "传感器温度值范围设定            "
        '
        'txtTempMin
        '
        Me.txtTempMin.AcceptsReturn = True
        Me.txtTempMin.BackColor = System.Drawing.SystemColors.Window
        Me.txtTempMin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTempMin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTempMin.Location = New System.Drawing.Point(74, 20)
        Me.txtTempMin.MaxLength = 0
        Me.txtTempMin.Name = "txtTempMin"
        Me.txtTempMin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTempMin.Size = New System.Drawing.Size(101, 21)
        Me.txtTempMin.TabIndex = 48
        '
        'txtTempMax
        '
        Me.txtTempMax.AcceptsReturn = True
        Me.txtTempMax.BackColor = System.Drawing.SystemColors.Window
        Me.txtTempMax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTempMax.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTempMax.Location = New System.Drawing.Point(272, 20)
        Me.txtTempMax.MaxLength = 0
        Me.txtTempMax.Name = "txtTempMax"
        Me.txtTempMax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTempMax.Size = New System.Drawing.Size(101, 21)
        Me.txtTempMax.TabIndex = 47
        '
        'cmdTempSave
        '
        Me.cmdTempSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdTempSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdTempSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdTempSave.Location = New System.Drawing.Point(384, 18)
        Me.cmdTempSave.Name = "cmdTempSave"
        Me.cmdTempSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdTempSave.Size = New System.Drawing.Size(95, 23)
        Me.cmdTempSave.TabIndex = 46
        Me.cmdTempSave.Text = "保存"
        Me.cmdTempSave.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(26, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(59, 15)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "最小值："
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.White
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(220, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(59, 15)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "最大值："
        '
        'Frame9
        '
        Me.Frame9.BackColor = System.Drawing.Color.White
        Me.Frame9.Controls.Add(Me.chkOnlyScanVINCode)
        Me.Frame9.Controls.Add(Me.chkAllQueue)
        Me.Frame9.Controls.Add(Me.Command10)
        Me.Frame9.Controls.Add(Me.Command5)
        Me.Frame9.Controls.Add(Me.Label27)
        Me.Frame9.Controls.Add(Me.Label25)
        Me.Frame9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame9.Location = New System.Drawing.Point(14, 12)
        Me.Frame9.Name = "Frame9"
        Me.Frame9.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame9.Size = New System.Drawing.Size(571, 51)
        Me.Frame9.TabIndex = 38
        Me.Frame9.TabStop = False
        Me.Frame9.Text = "排产队列检验模式    "
        '
        'chkOnlyScanVINCode
        '
        Me.chkOnlyScanVINCode.BackColor = System.Drawing.Color.White
        Me.chkOnlyScanVINCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkOnlyScanVINCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkOnlyScanVINCode.Location = New System.Drawing.Point(362, 12)
        Me.chkOnlyScanVINCode.Name = "chkOnlyScanVINCode"
        Me.chkOnlyScanVINCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkOnlyScanVINCode.Size = New System.Drawing.Size(13, 23)
        Me.chkOnlyScanVINCode.TabIndex = 84
        Me.chkOnlyScanVINCode.Text = "Check1"
        Me.chkOnlyScanVINCode.UseVisualStyleBackColor = False
        Me.chkOnlyScanVINCode.Visible = False
        '
        'chkAllQueue
        '
        Me.chkAllQueue.BackColor = System.Drawing.Color.White
        Me.chkAllQueue.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAllQueue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAllQueue.Location = New System.Drawing.Point(22, 20)
        Me.chkAllQueue.Name = "chkAllQueue"
        Me.chkAllQueue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAllQueue.Size = New System.Drawing.Size(13, 23)
        Me.chkAllQueue.TabIndex = 82
        Me.chkAllQueue.Text = "Check1"
        Me.chkAllQueue.UseVisualStyleBackColor = False
        '
        'Command10
        '
        Me.Command10.BackColor = System.Drawing.SystemColors.Control
        Me.Command10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command10.Location = New System.Drawing.Point(334, 10)
        Me.Command10.Name = "Command10"
        Me.Command10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command10.Size = New System.Drawing.Size(19, 27)
        Me.Command10.TabIndex = 80
        Me.Command10.Text = "查看排产队列数据"
        Me.Command10.UseVisualStyleBackColor = False
        Me.Command10.Visible = False
        '
        'Command5
        '
        Me.Command5.BackColor = System.Drawing.SystemColors.Control
        Me.Command5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command5.Location = New System.Drawing.Point(300, 10)
        Me.Command5.Name = "Command5"
        Me.Command5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command5.Size = New System.Drawing.Size(27, 27)
        Me.Command5.TabIndex = 79
        Me.Command5.Text = "手动下载排产队列数据"
        Me.Command5.UseVisualStyleBackColor = False
        Me.Command5.Visible = False
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(380, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(171, 15)
        Me.Label27.TabIndex = 85
        Me.Label27.Text = "仅扫描VIN码，从MES取MTOC码"
        Me.Label27.Visible = False
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(40, 24)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(120, 18)
        Me.Label25.TabIndex = 81
        Me.Label25.Text = "校验排产队列信息"
        '
        'Frame8
        '
        Me.Frame8.BackColor = System.Drawing.Color.White
        Me.Frame8.Controls.Add(Me.WindowsXPC1)
        Me.Frame8.Controls.Add(Me.Text2)
        Me.Frame8.Controls.Add(Me.Text1)
        Me.Frame8.Controls.Add(Me.Command6)
        Me.Frame8.Controls.Add(Me.Label11)
        Me.Frame8.Controls.Add(Me.Label12)
        Me.Frame8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame8.Location = New System.Drawing.Point(12, 68)
        Me.Frame8.Name = "Frame8"
        Me.Frame8.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame8.Size = New System.Drawing.Size(573, 79)
        Me.Frame8.TabIndex = 34
        Me.Frame8.TabStop = False
        Me.Frame8.Text = "修改管理密码      "
        '
        'WindowsXPC1
        '
        Me.WindowsXPC1.Enabled = True
        Me.WindowsXPC1.Location = New System.Drawing.Point(488, 24)
        Me.WindowsXPC1.Name = "WindowsXPC1"
        Me.WindowsXPC1.OcxState = CType(resources.GetObject("WindowsXPC1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.WindowsXPC1.Size = New System.Drawing.Size(249, 41)
        Me.WindowsXPC1.TabIndex = 0
        '
        'Text2
        '
        Me.Text2.AcceptsReturn = True
        Me.Text2.BackColor = System.Drawing.SystemColors.Window
        Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Text2.Location = New System.Drawing.Point(152, 44)
        Me.Text2.MaxLength = 0
        Me.Text2.Name = "Text2"
        Me.Text2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text2.Size = New System.Drawing.Size(137, 21)
        Me.Text2.TabIndex = 58
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Text1.Location = New System.Drawing.Point(152, 16)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(137, 21)
        Me.Text1.TabIndex = 57
        '
        'Command6
        '
        Me.Command6.BackColor = System.Drawing.SystemColors.Control
        Me.Command6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command6.Location = New System.Drawing.Point(300, 42)
        Me.Command6.Name = "Command6"
        Me.Command6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command6.Size = New System.Drawing.Size(97, 25)
        Me.Command6.TabIndex = 35
        Me.Command6.Text = "保存新密码"
        Me.Command6.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(40, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(120, 18)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "请输入新密码："
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(40, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(120, 18)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "请再次输入新密码："
        '
        '_SSTab1_TabPage3
        '
        Me._SSTab1_TabPage3.Controls.Add(Me.Frame13)
        Me._SSTab1_TabPage3.Location = New System.Drawing.Point(4, 22)
        Me._SSTab1_TabPage3.Name = "_SSTab1_TabPage3"
        Me._SSTab1_TabPage3.Size = New System.Drawing.Size(611, 399)
        Me._SSTab1_TabPage3.TabIndex = 3
        Me._SSTab1_TabPage3.Text = "TPMS特征码设置"
        '
        'Frame13
        '
        Me.Frame13.BackColor = System.Drawing.Color.White
        Me.Frame13.Controls.Add(Me.Frame18)
        Me.Frame13.Controls.Add(Me.Frame15)
        Me.Frame13.Controls.Add(Me.Frame14)
        Me.Frame13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame13.Location = New System.Drawing.Point(4, 24)
        Me.Frame13.Name = "Frame13"
        Me.Frame13.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame13.Size = New System.Drawing.Size(607, 395)
        Me.Frame13.TabIndex = 59
        Me.Frame13.TabStop = False
        '
        'Frame18
        '
        Me.Frame18.BackColor = System.Drawing.Color.White
        Me.Frame18.Controls.Add(Me.chkOnlyPrintNGWriteResult)
        Me.Frame18.Controls.Add(Me.chkPrintNGFlow)
        Me.Frame18.Controls.Add(Me.Command7)
        Me.Frame18.Controls.Add(Me.txtVIN)
        Me.Frame18.Controls.Add(Me.Label31)
        Me.Frame18.Controls.Add(Me.Label32)
        Me.Frame18.Controls.Add(Me.Label30)
        Me.Frame18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame18.Location = New System.Drawing.Point(6, 338)
        Me.Frame18.Name = "Frame18"
        Me.Frame18.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame18.Size = New System.Drawing.Size(593, 51)
        Me.Frame18.TabIndex = 91
        Me.Frame18.TabStop = False
        Me.Frame18.Text = "诊断结果打印设置"
        '
        'chkOnlyPrintNGWriteResult
        '
        Me.chkOnlyPrintNGWriteResult.BackColor = System.Drawing.Color.White
        Me.chkOnlyPrintNGWriteResult.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkOnlyPrintNGWriteResult.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkOnlyPrintNGWriteResult.Location = New System.Drawing.Point(134, 18)
        Me.chkOnlyPrintNGWriteResult.Name = "chkOnlyPrintNGWriteResult"
        Me.chkOnlyPrintNGWriteResult.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkOnlyPrintNGWriteResult.Size = New System.Drawing.Size(13, 23)
        Me.chkOnlyPrintNGWriteResult.TabIndex = 95
        Me.chkOnlyPrintNGWriteResult.Text = "chkPrintNGResult"
        Me.chkOnlyPrintNGWriteResult.UseVisualStyleBackColor = False
        '
        'chkPrintNGFlow
        '
        Me.chkPrintNGFlow.BackColor = System.Drawing.Color.White
        Me.chkPrintNGFlow.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPrintNGFlow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPrintNGFlow.Location = New System.Drawing.Point(288, 18)
        Me.chkPrintNGFlow.Name = "chkPrintNGFlow"
        Me.chkPrintNGFlow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPrintNGFlow.Size = New System.Drawing.Size(13, 23)
        Me.chkPrintNGFlow.TabIndex = 94
        Me.chkPrintNGFlow.Text = "checkNGFlow"
        Me.chkPrintNGFlow.UseVisualStyleBackColor = False
        '
        'Command7
        '
        Me.Command7.BackColor = System.Drawing.SystemColors.Control
        Me.Command7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command7.Location = New System.Drawing.Point(492, 18)
        Me.Command7.Name = "Command7"
        Me.Command7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command7.Size = New System.Drawing.Size(87, 25)
        Me.Command7.TabIndex = 93
        Me.Command7.Text = "手动打印"
        Me.Command7.UseVisualStyleBackColor = False
        '
        'txtVIN
        '
        Me.txtVIN.AcceptsReturn = True
        Me.txtVIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtVIN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVIN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVIN.Location = New System.Drawing.Point(352, 20)
        Me.txtVIN.MaxLength = 0
        Me.txtVIN.Name = "txtVIN"
        Me.txtVIN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVIN.Size = New System.Drawing.Size(135, 21)
        Me.txtVIN.TabIndex = 92
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.White
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(12, 24)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(121, 15)
        Me.Label31.TabIndex = 98
        Me.Label31.Text = "仅打印NG的诊断结果："
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.White
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(320, 24)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(29, 15)
        Me.Label32.TabIndex = 97
        Me.Label32.Text = "VIN："
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.White
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(168, 24)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(121, 15)
        Me.Label30.TabIndex = 96
        Me.Label30.Text = "仅打印NG的诊断流程："
        '
        'Frame15
        '
        Me.Frame15.BackColor = System.Drawing.Color.White
        Me.Frame15.Controls.Add(Me.btMTOCModi)
        Me.Frame15.Controls.Add(Me.txtMTOCLen)
        Me.Frame15.Controls.Add(Me.txtMtocStartIndex)
        Me.Frame15.Controls.Add(Me.Label24)
        Me.Frame15.Controls.Add(Me.Label23)
        Me.Frame15.Controls.Add(Me.Label22)
        Me.Frame15.Controls.Add(Me.Label21)
        Me.Frame15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame15.Location = New System.Drawing.Point(6, 224)
        Me.Frame15.Name = "Frame15"
        Me.Frame15.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame15.Size = New System.Drawing.Size(593, 109)
        Me.Frame15.TabIndex = 61
        Me.Frame15.TabStop = False
        Me.Frame15.Text = "起始位设置      "
        '
        'btMTOCModi
        '
        Me.btMTOCModi.BackColor = System.Drawing.SystemColors.Control
        Me.btMTOCModi.Cursor = System.Windows.Forms.Cursors.Default
        Me.btMTOCModi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btMTOCModi.Location = New System.Drawing.Point(14, 74)
        Me.btMTOCModi.Name = "btMTOCModi"
        Me.btMTOCModi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btMTOCModi.Size = New System.Drawing.Size(101, 25)
        Me.btMTOCModi.TabIndex = 77
        Me.btMTOCModi.Text = "修改"
        Me.btMTOCModi.UseVisualStyleBackColor = False
        '
        'txtMTOCLen
        '
        Me.txtMTOCLen.AcceptsReturn = True
        Me.txtMTOCLen.BackColor = System.Drawing.SystemColors.Window
        Me.txtMTOCLen.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMTOCLen.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMTOCLen.Location = New System.Drawing.Point(78, 48)
        Me.txtMTOCLen.MaxLength = 0
        Me.txtMTOCLen.Name = "txtMTOCLen"
        Me.txtMTOCLen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMTOCLen.Size = New System.Drawing.Size(113, 21)
        Me.txtMTOCLen.TabIndex = 74
        '
        'txtMtocStartIndex
        '
        Me.txtMtocStartIndex.AcceptsReturn = True
        Me.txtMtocStartIndex.BackColor = System.Drawing.SystemColors.Window
        Me.txtMtocStartIndex.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMtocStartIndex.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMtocStartIndex.Location = New System.Drawing.Point(78, 20)
        Me.txtMtocStartIndex.MaxLength = 0
        Me.txtMtocStartIndex.Name = "txtMtocStartIndex"
        Me.txtMtocStartIndex.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMtocStartIndex.Size = New System.Drawing.Size(113, 21)
        Me.txtMtocStartIndex.TabIndex = 72
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.White
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(204, 50)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(377, 15)
        Me.Label24.TabIndex = 76
        Me.Label24.Text = "备注：MTOC码为BF1B-FM6-00-B1-V，特征位长为3，则特征码为FM6；"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.White
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(204, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(377, 15)
        Me.Label23.TabIndex = 75
        Me.Label23.Text = "备注：MTOC码为BF1B-FM6-00-B1-V，起始位为6，则从第二个F开始；"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.White
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(16, 50)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(61, 15)
        Me.Label22.TabIndex = 73
        Me.Label22.Text = "特征码长："
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.White
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(16, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(61, 15)
        Me.Label21.TabIndex = 71
        Me.Label21.Text = "起始位置："
        '
        'Frame14
        '
        Me.Frame14.BackColor = System.Drawing.Color.White
        Me.Frame14.Controls.Add(Me.Frame16)
        Me.Frame14.Controls.Add(Me.MSFlexGrid3)
        Me.Frame14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame14.Location = New System.Drawing.Point(4, 12)
        Me.Frame14.Name = "Frame14"
        Me.Frame14.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame14.Size = New System.Drawing.Size(595, 207)
        Me.Frame14.TabIndex = 60
        Me.Frame14.TabStop = False
        Me.Frame14.Text = "特征码列表      "
        '
        'Frame16
        '
        Me.Frame16.BackColor = System.Drawing.Color.White
        Me.Frame16.Controls.Add(Me.btTPMSCancle)
        Me.Frame16.Controls.Add(Me.btTPMSDel)
        Me.Frame16.Controls.Add(Me.btTPMSModi)
        Me.Frame16.Controls.Add(Me.txtTPMSCode)
        Me.Frame16.Controls.Add(Me.txtTPMSID)
        Me.Frame16.Controls.Add(Me.btTPMSAdd)
        Me.Frame16.Controls.Add(Me.Label20)
        Me.Frame16.Controls.Add(Me.Label19)
        Me.Frame16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame16.Location = New System.Drawing.Point(322, 16)
        Me.Frame16.Name = "Frame16"
        Me.Frame16.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame16.Size = New System.Drawing.Size(261, 173)
        Me.Frame16.TabIndex = 63
        Me.Frame16.TabStop = False
        '
        'btTPMSCancle
        '
        Me.btTPMSCancle.BackColor = System.Drawing.SystemColors.Control
        Me.btTPMSCancle.Cursor = System.Windows.Forms.Cursors.Default
        Me.btTPMSCancle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btTPMSCancle.Location = New System.Drawing.Point(148, 122)
        Me.btTPMSCancle.Name = "btTPMSCancle"
        Me.btTPMSCancle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btTPMSCancle.Size = New System.Drawing.Size(73, 25)
        Me.btTPMSCancle.TabIndex = 78
        Me.btTPMSCancle.Text = "取消"
        Me.btTPMSCancle.UseVisualStyleBackColor = False
        '
        'btTPMSDel
        '
        Me.btTPMSDel.BackColor = System.Drawing.SystemColors.Control
        Me.btTPMSDel.Cursor = System.Windows.Forms.Cursors.Default
        Me.btTPMSDel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btTPMSDel.Location = New System.Drawing.Point(28, 122)
        Me.btTPMSDel.Name = "btTPMSDel"
        Me.btTPMSDel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btTPMSDel.Size = New System.Drawing.Size(73, 25)
        Me.btTPMSDel.TabIndex = 70
        Me.btTPMSDel.Text = "删除"
        Me.btTPMSDel.UseVisualStyleBackColor = False
        '
        'btTPMSModi
        '
        Me.btTPMSModi.BackColor = System.Drawing.SystemColors.Control
        Me.btTPMSModi.Cursor = System.Windows.Forms.Cursors.Default
        Me.btTPMSModi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btTPMSModi.Location = New System.Drawing.Point(146, 82)
        Me.btTPMSModi.Name = "btTPMSModi"
        Me.btTPMSModi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btTPMSModi.Size = New System.Drawing.Size(73, 25)
        Me.btTPMSModi.TabIndex = 69
        Me.btTPMSModi.Text = "修改"
        Me.btTPMSModi.UseVisualStyleBackColor = False
        '
        'txtTPMSCode
        '
        Me.txtTPMSCode.AcceptsReturn = True
        Me.txtTPMSCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtTPMSCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTPMSCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTPMSCode.Location = New System.Drawing.Point(82, 48)
        Me.txtTPMSCode.MaxLength = 0
        Me.txtTPMSCode.Name = "txtTPMSCode"
        Me.txtTPMSCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTPMSCode.Size = New System.Drawing.Size(149, 21)
        Me.txtTPMSCode.TabIndex = 67
        '
        'txtTPMSID
        '
        Me.txtTPMSID.AcceptsReturn = True
        Me.txtTPMSID.BackColor = System.Drawing.SystemColors.Window
        Me.txtTPMSID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTPMSID.Enabled = False
        Me.txtTPMSID.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTPMSID.Location = New System.Drawing.Point(82, 18)
        Me.txtTPMSID.MaxLength = 0
        Me.txtTPMSID.Name = "txtTPMSID"
        Me.txtTPMSID.ReadOnly = True
        Me.txtTPMSID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTPMSID.Size = New System.Drawing.Size(149, 21)
        Me.txtTPMSID.TabIndex = 65
        '
        'btTPMSAdd
        '
        Me.btTPMSAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btTPMSAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.btTPMSAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btTPMSAdd.Location = New System.Drawing.Point(28, 82)
        Me.btTPMSAdd.Name = "btTPMSAdd"
        Me.btTPMSAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btTPMSAdd.Size = New System.Drawing.Size(73, 25)
        Me.btTPMSAdd.TabIndex = 64
        Me.btTPMSAdd.Text = "新增"
        Me.btTPMSAdd.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.White
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(20, 50)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(49, 15)
        Me.Label20.TabIndex = 68
        Me.Label20.Text = "特征码："
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.White
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(20, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(49, 15)
        Me.Label19.TabIndex = 66
        Me.Label19.Text = "编    号："
        '
        'MSFlexGrid3
        '
        Me.MSFlexGrid3.Location = New System.Drawing.Point(14, 24)
        Me.MSFlexGrid3.Name = "MSFlexGrid3"
        Me.MSFlexGrid3.OcxState = CType(resources.GetObject("MSFlexGrid3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.MSFlexGrid3.Size = New System.Drawing.Size(297, 167)
        Me.MSFlexGrid3.TabIndex = 62
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(428, 74)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(120, 18)
        Me.Label26.TabIndex = 83
        Me.Label26.Text = "校验排产队列信息"
        '
        'frmOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(622, 430)
        Me.Controls.Add(Me.SSTab1)
        Me.Controls.Add(Me.Label26)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(265, 199)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOption"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "系统配置"
        Me.SSTab1.ResumeLayout(False)
        Me._SSTab1_TabPage0.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        CType(Me.MSFlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame2.ResumeLayout(False)
        Me._SSTab1_TabPage1.ResumeLayout(False)
        Me.Frame4.ResumeLayout(False)
        Me.Frame6.ResumeLayout(False)
        Me.Frame5.ResumeLayout(False)
        CType(Me.MSFlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me._SSTab1_TabPage2.ResumeLayout(False)
        Me.Frame7.ResumeLayout(False)
        Me.Frame17.ResumeLayout(False)
        Me.Frame10.ResumeLayout(False)
        Me.Frame12.ResumeLayout(False)
        Me.Frame11.ResumeLayout(False)
        Me.Frame9.ResumeLayout(False)
        Me.Frame8.ResumeLayout(False)
        CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).EndInit()
        Me._SSTab1_TabPage3.ResumeLayout(False)
        Me.Frame13.ResumeLayout(False)
        Me.Frame18.ResumeLayout(False)
        Me.Frame15.ResumeLayout(False)
        Me.Frame14.ResumeLayout(False)
        Me.Frame16.ResumeLayout(False)
        CType(Me.MSFlexGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class