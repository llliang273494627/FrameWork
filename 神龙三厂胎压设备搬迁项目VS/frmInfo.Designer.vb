<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmInfo
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
    Public WithEvents Picture4 As System.Windows.Forms.PictureBox
    Public WithEvents Picture10 As System.Windows.Forms.PictureBox
	Public WithEvents PicInd As System.Windows.Forms.PictureBox
	Public WithEvents PicNet As System.Windows.Forms.PictureBox
	Public WithEvents Picture9 As System.Windows.Forms.PictureBox
	Public WithEvents Picture8 As System.Windows.Forms.PictureBox
	Public WithEvents Picture7 As System.Windows.Forms.PictureBox
	Public WithEvents Picture6 As System.Windows.Forms.PictureBox
	Public WithEvents picRF As System.Windows.Forms.PictureBox
	Public WithEvents txtRF As System.Windows.Forms.TextBox
	Public WithEvents picRR As System.Windows.Forms.PictureBox
	Public WithEvents txtRR As System.Windows.Forms.TextBox
	Public WithEvents picLF As System.Windows.Forms.PictureBox
	Public WithEvents txtLF As System.Windows.Forms.TextBox
	Public WithEvents picLR As System.Windows.Forms.PictureBox
	Public WithEvents txtLR As System.Windows.Forms.TextBox
	Public WithEvents txtInfo As System.Windows.Forms.TextBox
	Public WithEvents ListInput As System.Windows.Forms.ListBox
	Public WithEvents ListOutput As System.Windows.Forms.ListBox
	Public WithEvents WindowsXPC1 As AxWinXPC_Engine.AxWindowsXPC
	Public WithEvents Label33 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents lbRFTemp As System.Windows.Forms.Label
	Public WithEvents lbRFPre As System.Windows.Forms.Label
	Public WithEvents lbRFMdl As System.Windows.Forms.Label
	Public WithEvents lbRFBattery As System.Windows.Forms.Label
	Public WithEvents lbRFAcSpeed As System.Windows.Forms.Label
	Public WithEvents lbRRAcSpeed As System.Windows.Forms.Label
	Public WithEvents lbRRBattery As System.Windows.Forms.Label
	Public WithEvents lbRRMdl As System.Windows.Forms.Label
	Public WithEvents lbRRPre As System.Windows.Forms.Label
	Public WithEvents lbRRTemp As System.Windows.Forms.Label
	Public WithEvents lbLFAcSpeed As System.Windows.Forms.Label
	Public WithEvents lbLFBattery As System.Windows.Forms.Label
	Public WithEvents lbLFMdl As System.Windows.Forms.Label
	Public WithEvents lbLFPre As System.Windows.Forms.Label
	Public WithEvents lbLFTemp As System.Windows.Forms.Label
	Public WithEvents Label39 As System.Windows.Forms.Label
	Public WithEvents lbLRTemp As System.Windows.Forms.Label
	Public WithEvents lbLRPre As System.Windows.Forms.Label
	Public WithEvents lbLRMdl As System.Windows.Forms.Label
	Public WithEvents lbLRBattery As System.Windows.Forms.Label
	Public WithEvents lbLRAcSpeed As System.Windows.Forms.Label
	Public WithEvents Label32 As System.Windows.Forms.Label
	Public WithEvents Label31 As System.Windows.Forms.Label
	Public WithEvents Label30 As System.Windows.Forms.Label
	Public WithEvents Label29 As System.Windows.Forms.Label
	Public WithEvents Label28 As System.Windows.Forms.Label
	Public WithEvents Label27 As System.Windows.Forms.Label
	Public WithEvents Label26 As System.Windows.Forms.Label
	Public WithEvents Label25 As System.Windows.Forms.Label
	Public WithEvents Label24 As System.Windows.Forms.Label
	Public WithEvents Label23 As System.Windows.Forms.Label
	Public WithEvents Label22 As System.Windows.Forms.Label
	Public WithEvents Label21 As System.Windows.Forms.Label
	Public WithEvents Label20 As System.Windows.Forms.Label
	Public WithEvents Label19 As System.Windows.Forms.Label
	Public WithEvents Label18 As System.Windows.Forms.Label
	Public WithEvents Label17 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents labNow As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents labVin As System.Windows.Forms.Label
	Public WithEvents labNext As System.Windows.Forms.Label
	'注意: 以下过程是 Windows 窗体设计器所必需的
	'可以使用 Windows 窗体设计器来修改它。
	'不要使用代码编辑器修改它。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfo))
        Me.Picture4 = New System.Windows.Forms.PictureBox()
        Me.Picture10 = New System.Windows.Forms.PictureBox()
        Me.PicInd = New System.Windows.Forms.PictureBox()
        Me.PicNet = New System.Windows.Forms.PictureBox()
        Me.Picture9 = New System.Windows.Forms.PictureBox()
        Me.Picture8 = New System.Windows.Forms.PictureBox()
        Me.Picture7 = New System.Windows.Forms.PictureBox()
        Me.Picture6 = New System.Windows.Forms.PictureBox()
        Me.picRF = New System.Windows.Forms.PictureBox()
        Me.txtRF = New System.Windows.Forms.TextBox()
        Me.picRR = New System.Windows.Forms.PictureBox()
        Me.txtRR = New System.Windows.Forms.TextBox()
        Me.picLF = New System.Windows.Forms.PictureBox()
        Me.txtLF = New System.Windows.Forms.TextBox()
        Me.picLR = New System.Windows.Forms.PictureBox()
        Me.txtLR = New System.Windows.Forms.TextBox()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.ListInput = New System.Windows.Forms.ListBox()
        Me.ListOutput = New System.Windows.Forms.ListBox()
        Me.WindowsXPC1 = New AxWinXPC_Engine.AxWindowsXPC()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbRFTemp = New System.Windows.Forms.Label()
        Me.lbRFPre = New System.Windows.Forms.Label()
        Me.lbRFMdl = New System.Windows.Forms.Label()
        Me.lbRFBattery = New System.Windows.Forms.Label()
        Me.lbRFAcSpeed = New System.Windows.Forms.Label()
        Me.lbRRAcSpeed = New System.Windows.Forms.Label()
        Me.lbRRBattery = New System.Windows.Forms.Label()
        Me.lbRRMdl = New System.Windows.Forms.Label()
        Me.lbRRPre = New System.Windows.Forms.Label()
        Me.lbRRTemp = New System.Windows.Forms.Label()
        Me.lbLFAcSpeed = New System.Windows.Forms.Label()
        Me.lbLFBattery = New System.Windows.Forms.Label()
        Me.lbLFMdl = New System.Windows.Forms.Label()
        Me.lbLFPre = New System.Windows.Forms.Label()
        Me.lbLFTemp = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.lbLRTemp = New System.Windows.Forms.Label()
        Me.lbLRPre = New System.Windows.Forms.Label()
        Me.lbLRMdl = New System.Windows.Forms.Label()
        Me.lbLRBattery = New System.Windows.Forms.Label()
        Me.lbLRAcSpeed = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.labNow = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.labVin = New System.Windows.Forms.Label()
        Me.labNext = New System.Windows.Forms.Label()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.Picture4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicInd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicNet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Picture4
        '
        Me.Picture4.BackColor = System.Drawing.SystemColors.Window
        Me.Picture4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture4.Image = CType(resources.GetObject("Picture4.Image"), System.Drawing.Image)
        Me.Picture4.Location = New System.Drawing.Point(7, 0)
        Me.Picture4.Name = "Picture4"
        Me.Picture4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture4.Size = New System.Drawing.Size(299, 30)
        Me.Picture4.TabIndex = 75
        Me.Picture4.TabStop = False
        '
        'Picture10
        '
        Me.Picture10.BackColor = System.Drawing.SystemColors.Window
        Me.Picture10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture10.Image = CType(resources.GetObject("Picture10.Image"), System.Drawing.Image)
        Me.Picture10.Location = New System.Drawing.Point(10, 736)
        Me.Picture10.Name = "Picture10"
        Me.Picture10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture10.Size = New System.Drawing.Size(43, 28)
        Me.Picture10.TabIndex = 74
        Me.Picture10.TabStop = False
        '
        'PicInd
        '
        Me.PicInd.BackColor = System.Drawing.SystemColors.Window
        Me.PicInd.Cursor = System.Windows.Forms.Cursors.Default
        Me.PicInd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PicInd.Image = CType(resources.GetObject("PicInd.Image"), System.Drawing.Image)
        Me.PicInd.Location = New System.Drawing.Point(120, 694)
        Me.PicInd.Name = "PicInd"
        Me.PicInd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PicInd.Size = New System.Drawing.Size(28, 28)
        Me.PicInd.TabIndex = 25
        Me.PicInd.TabStop = False
        '
        'PicNet
        '
        Me.PicNet.BackColor = System.Drawing.SystemColors.Window
        Me.PicNet.Cursor = System.Windows.Forms.Cursors.Default
        Me.PicNet.ForeColor = System.Drawing.SystemColors.WindowText
        Me.PicNet.Image = CType(resources.GetObject("PicNet.Image"), System.Drawing.Image)
        Me.PicNet.Location = New System.Drawing.Point(264, 694)
        Me.PicNet.Name = "PicNet"
        Me.PicNet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PicNet.Size = New System.Drawing.Size(28, 28)
        Me.PicNet.TabIndex = 24
        Me.PicNet.TabStop = False
        '
        'Picture9
        '
        Me.Picture9.BackColor = System.Drawing.SystemColors.Window
        Me.Picture9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture9.Image = CType(resources.GetObject("Picture9.Image"), System.Drawing.Image)
        Me.Picture9.Location = New System.Drawing.Point(592, 694)
        Me.Picture9.Name = "Picture9"
        Me.Picture9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture9.Size = New System.Drawing.Size(28, 28)
        Me.Picture9.TabIndex = 23
        Me.Picture9.TabStop = False
        '
        'Picture8
        '
        Me.Picture8.BackColor = System.Drawing.SystemColors.Window
        Me.Picture8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture8.Image = CType(resources.GetObject("Picture8.Image"), System.Drawing.Image)
        Me.Picture8.Location = New System.Drawing.Point(968, 694)
        Me.Picture8.Name = "Picture8"
        Me.Picture8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture8.Size = New System.Drawing.Size(28, 28)
        Me.Picture8.TabIndex = 22
        Me.Picture8.TabStop = False
        '
        'Picture7
        '
        Me.Picture7.BackColor = System.Drawing.SystemColors.Window
        Me.Picture7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture7.Image = CType(resources.GetObject("Picture7.Image"), System.Drawing.Image)
        Me.Picture7.Location = New System.Drawing.Point(800, 694)
        Me.Picture7.Name = "Picture7"
        Me.Picture7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture7.Size = New System.Drawing.Size(28, 28)
        Me.Picture7.TabIndex = 21
        Me.Picture7.TabStop = False
        '
        'Picture6
        '
        Me.Picture6.BackColor = System.Drawing.SystemColors.Window
        Me.Picture6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture6.Image = CType(resources.GetObject("Picture6.Image"), System.Drawing.Image)
        Me.Picture6.Location = New System.Drawing.Point(424, 694)
        Me.Picture6.Name = "Picture6"
        Me.Picture6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture6.Size = New System.Drawing.Size(28, 28)
        Me.Picture6.TabIndex = 20
        Me.Picture6.TabStop = False
        '
        'picRF
        '
        Me.picRF.BackColor = System.Drawing.SystemColors.Window
        Me.picRF.Cursor = System.Windows.Forms.Cursors.Default
        Me.picRF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picRF.Image = CType(resources.GetObject("picRF.Image"), System.Drawing.Image)
        Me.picRF.Location = New System.Drawing.Point(1016, 588)
        Me.picRF.Name = "picRF"
        Me.picRF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picRF.Size = New System.Drawing.Size(28, 28)
        Me.picRF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRF.TabIndex = 18
        Me.picRF.TabStop = False
        '
        'txtRF
        '
        Me.txtRF.AcceptsReturn = True
        Me.txtRF.BackColor = System.Drawing.SystemColors.Window
        Me.txtRF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRF.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRF.Font = New System.Drawing.Font("宋体", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtRF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRF.Location = New System.Drawing.Point(1097, 588)
        Me.txtRF.MaxLength = 0
        Me.txtRF.Name = "txtRF"
        Me.txtRF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRF.Size = New System.Drawing.Size(139, 31)
        Me.txtRF.TabIndex = 17
        '
        'picRR
        '
        Me.picRR.BackColor = System.Drawing.SystemColors.Window
        Me.picRR.Cursor = System.Windows.Forms.Cursors.Default
        Me.picRR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picRR.Image = CType(resources.GetObject("picRR.Image"), System.Drawing.Image)
        Me.picRR.Location = New System.Drawing.Point(522, 588)
        Me.picRR.Name = "picRR"
        Me.picRR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picRR.Size = New System.Drawing.Size(28, 28)
        Me.picRR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRR.TabIndex = 15
        Me.picRR.TabStop = False
        '
        'txtRR
        '
        Me.txtRR.AcceptsReturn = True
        Me.txtRR.BackColor = System.Drawing.SystemColors.Window
        Me.txtRR.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRR.Font = New System.Drawing.Font("宋体", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtRR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRR.Location = New System.Drawing.Point(602, 588)
        Me.txtRR.MaxLength = 0
        Me.txtRR.Name = "txtRR"
        Me.txtRR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRR.Size = New System.Drawing.Size(139, 31)
        Me.txtRR.TabIndex = 14
        '
        'picLF
        '
        Me.picLF.BackColor = System.Drawing.SystemColors.Window
        Me.picLF.Cursor = System.Windows.Forms.Cursors.Default
        Me.picLF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picLF.Image = CType(resources.GetObject("picLF.Image"), System.Drawing.Image)
        Me.picLF.Location = New System.Drawing.Point(1018, 262)
        Me.picLF.Name = "picLF"
        Me.picLF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picLF.Size = New System.Drawing.Size(28, 28)
        Me.picLF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLF.TabIndex = 12
        Me.picLF.TabStop = False
        '
        'txtLF
        '
        Me.txtLF.AcceptsReturn = True
        Me.txtLF.BackColor = System.Drawing.SystemColors.Window
        Me.txtLF.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLF.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLF.Font = New System.Drawing.Font("宋体", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtLF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLF.Location = New System.Drawing.Point(1103, 262)
        Me.txtLF.MaxLength = 0
        Me.txtLF.Name = "txtLF"
        Me.txtLF.ReadOnly = True
        Me.txtLF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLF.Size = New System.Drawing.Size(133, 31)
        Me.txtLF.TabIndex = 11
        '
        'picLR
        '
        Me.picLR.BackColor = System.Drawing.SystemColors.Window
        Me.picLR.Cursor = System.Windows.Forms.Cursors.Default
        Me.picLR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.picLR.Image = CType(resources.GetObject("picLR.Image"), System.Drawing.Image)
        Me.picLR.Location = New System.Drawing.Point(524, 262)
        Me.picLR.Name = "picLR"
        Me.picLR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picLR.Size = New System.Drawing.Size(28, 28)
        Me.picLR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLR.TabIndex = 9
        Me.picLR.TabStop = False
        '
        'txtLR
        '
        Me.txtLR.AcceptsReturn = True
        Me.txtLR.BackColor = System.Drawing.SystemColors.Window
        Me.txtLR.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLR.Font = New System.Drawing.Font("宋体", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtLR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLR.Location = New System.Drawing.Point(610, 262)
        Me.txtLR.MaxLength = 0
        Me.txtLR.Name = "txtLR"
        Me.txtLR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLR.Size = New System.Drawing.Size(131, 31)
        Me.txtLR.TabIndex = 8
        '
        'txtInfo
        '
        Me.txtInfo.AcceptsReturn = True
        Me.txtInfo.BackColor = System.Drawing.SystemColors.Window
        Me.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInfo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInfo.Font = New System.Drawing.Font("宋体", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfo.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtInfo.Location = New System.Drawing.Point(28, 148)
        Me.txtInfo.MaxLength = 0
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ReadOnly = True
        Me.txtInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInfo.Size = New System.Drawing.Size(1231, 73)
        Me.txtInfo.TabIndex = 7
        Me.txtInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ListInput
        '
        Me.ListInput.BackColor = System.Drawing.SystemColors.Window
        Me.ListInput.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListInput.Font = New System.Drawing.Font("黑体", 33.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListInput.ForeColor = System.Drawing.Color.Blue
        Me.ListInput.ItemHeight = 45
        Me.ListInput.Location = New System.Drawing.Point(264, 294)
        Me.ListInput.Name = "ListInput"
        Me.ListInput.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListInput.Size = New System.Drawing.Size(211, 364)
        Me.ListInput.TabIndex = 1
        '
        'ListOutput
        '
        Me.ListOutput.BackColor = System.Drawing.SystemColors.Window
        Me.ListOutput.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListOutput.Font = New System.Drawing.Font("黑体", 33.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ListOutput.ForeColor = System.Drawing.Color.Blue
        Me.ListOutput.ItemHeight = 45
        Me.ListOutput.Location = New System.Drawing.Point(24, 294)
        Me.ListOutput.Name = "ListOutput"
        Me.ListOutput.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListOutput.Size = New System.Drawing.Size(212, 364)
        Me.ListOutput.TabIndex = 0
        '
        'WindowsXPC1
        '
        Me.WindowsXPC1.Enabled = True
        Me.WindowsXPC1.Location = New System.Drawing.Point(608, 1520)
        Me.WindowsXPC1.Name = "WindowsXPC1"
        Me.WindowsXPC1.OcxState = CType(resources.GetObject("WindowsXPC1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.WindowsXPC1.Size = New System.Drawing.Size(249, 41)
        Me.WindowsXPC1.TabIndex = 76
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label33.Font = New System.Drawing.Font("新宋体", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(58, 740)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label33.Size = New System.Drawing.Size(94, 21)
        Me.Label33.TabIndex = 73
        Me.Label33.Text = "华信数据"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(730, 742)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(525, 17)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "武汉市洪山区珞瑜东路佳园路光谷国际A座2318室    电话：027-87775236"
        '
        'lbRFTemp
        '
        Me.lbRFTemp.BackColor = System.Drawing.Color.Transparent
        Me.lbRFTemp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRFTemp.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRFTemp.ForeColor = System.Drawing.Color.Blue
        Me.lbRFTemp.Location = New System.Drawing.Point(1208, 622)
        Me.lbRFTemp.Name = "lbRFTemp"
        Me.lbRFTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRFTemp.Size = New System.Drawing.Size(35, 16)
        Me.lbRFTemp.TabIndex = 71
        Me.lbRFTemp.Text = "123"
        Me.lbRFTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRFPre
        '
        Me.lbRFPre.BackColor = System.Drawing.Color.Transparent
        Me.lbRFPre.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRFPre.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRFPre.ForeColor = System.Drawing.Color.Blue
        Me.lbRFPre.Location = New System.Drawing.Point(1127, 622)
        Me.lbRFPre.Name = "lbRFPre"
        Me.lbRFPre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRFPre.Size = New System.Drawing.Size(35, 16)
        Me.lbRFPre.TabIndex = 70
        Me.lbRFPre.Text = "123"
        Me.lbRFPre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRFMdl
        '
        Me.lbRFMdl.BackColor = System.Drawing.Color.Transparent
        Me.lbRFMdl.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRFMdl.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRFMdl.ForeColor = System.Drawing.Color.Blue
        Me.lbRFMdl.Location = New System.Drawing.Point(1050, 622)
        Me.lbRFMdl.Name = "lbRFMdl"
        Me.lbRFMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRFMdl.Size = New System.Drawing.Size(35, 16)
        Me.lbRFMdl.TabIndex = 69
        Me.lbRFMdl.Text = "123"
        Me.lbRFMdl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRFBattery
        '
        Me.lbRFBattery.BackColor = System.Drawing.Color.Transparent
        Me.lbRFBattery.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRFBattery.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRFBattery.ForeColor = System.Drawing.Color.Blue
        Me.lbRFBattery.Location = New System.Drawing.Point(1050, 638)
        Me.lbRFBattery.Name = "lbRFBattery"
        Me.lbRFBattery.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRFBattery.Size = New System.Drawing.Size(35, 16)
        Me.lbRFBattery.TabIndex = 68
        Me.lbRFBattery.Text = "123"
        Me.lbRFBattery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRFAcSpeed
        '
        Me.lbRFAcSpeed.BackColor = System.Drawing.Color.Transparent
        Me.lbRFAcSpeed.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRFAcSpeed.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRFAcSpeed.ForeColor = System.Drawing.Color.Blue
        Me.lbRFAcSpeed.Location = New System.Drawing.Point(1140, 638)
        Me.lbRFAcSpeed.Name = "lbRFAcSpeed"
        Me.lbRFAcSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRFAcSpeed.Size = New System.Drawing.Size(35, 16)
        Me.lbRFAcSpeed.TabIndex = 67
        Me.lbRFAcSpeed.Text = "123"
        Me.lbRFAcSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRRAcSpeed
        '
        Me.lbRRAcSpeed.BackColor = System.Drawing.Color.Transparent
        Me.lbRRAcSpeed.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRRAcSpeed.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRRAcSpeed.ForeColor = System.Drawing.Color.Blue
        Me.lbRRAcSpeed.Location = New System.Drawing.Point(649, 638)
        Me.lbRRAcSpeed.Name = "lbRRAcSpeed"
        Me.lbRRAcSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRRAcSpeed.Size = New System.Drawing.Size(35, 16)
        Me.lbRRAcSpeed.TabIndex = 66
        Me.lbRRAcSpeed.Text = "123"
        Me.lbRRAcSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRRBattery
        '
        Me.lbRRBattery.BackColor = System.Drawing.Color.Transparent
        Me.lbRRBattery.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRRBattery.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRRBattery.ForeColor = System.Drawing.Color.Blue
        Me.lbRRBattery.Location = New System.Drawing.Point(560, 638)
        Me.lbRRBattery.Name = "lbRRBattery"
        Me.lbRRBattery.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRRBattery.Size = New System.Drawing.Size(35, 16)
        Me.lbRRBattery.TabIndex = 65
        Me.lbRRBattery.Text = "123"
        Me.lbRRBattery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRRMdl
        '
        Me.lbRRMdl.BackColor = System.Drawing.Color.Transparent
        Me.lbRRMdl.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRRMdl.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRRMdl.ForeColor = System.Drawing.Color.Blue
        Me.lbRRMdl.Location = New System.Drawing.Point(560, 622)
        Me.lbRRMdl.Name = "lbRRMdl"
        Me.lbRRMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRRMdl.Size = New System.Drawing.Size(35, 16)
        Me.lbRRMdl.TabIndex = 64
        Me.lbRRMdl.Text = "123"
        Me.lbRRMdl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRRPre
        '
        Me.lbRRPre.BackColor = System.Drawing.Color.Transparent
        Me.lbRRPre.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRRPre.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRRPre.ForeColor = System.Drawing.Color.Blue
        Me.lbRRPre.Location = New System.Drawing.Point(634, 622)
        Me.lbRRPre.Name = "lbRRPre"
        Me.lbRRPre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRRPre.Size = New System.Drawing.Size(35, 16)
        Me.lbRRPre.TabIndex = 63
        Me.lbRRPre.Text = "123"
        Me.lbRRPre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRRTemp
        '
        Me.lbRRTemp.BackColor = System.Drawing.Color.Transparent
        Me.lbRRTemp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbRRTemp.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbRRTemp.ForeColor = System.Drawing.Color.Blue
        Me.lbRRTemp.Location = New System.Drawing.Point(722, 622)
        Me.lbRRTemp.Name = "lbRRTemp"
        Me.lbRRTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbRRTemp.Size = New System.Drawing.Size(35, 16)
        Me.lbRRTemp.TabIndex = 62
        Me.lbRRTemp.Text = "123"
        Me.lbRRTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLFAcSpeed
        '
        Me.lbLFAcSpeed.BackColor = System.Drawing.Color.Transparent
        Me.lbLFAcSpeed.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLFAcSpeed.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLFAcSpeed.ForeColor = System.Drawing.Color.Blue
        Me.lbLFAcSpeed.Location = New System.Drawing.Point(1140, 312)
        Me.lbLFAcSpeed.Name = "lbLFAcSpeed"
        Me.lbLFAcSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLFAcSpeed.Size = New System.Drawing.Size(35, 16)
        Me.lbLFAcSpeed.TabIndex = 61
        Me.lbLFAcSpeed.Text = "123"
        Me.lbLFAcSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLFBattery
        '
        Me.lbLFBattery.BackColor = System.Drawing.Color.Transparent
        Me.lbLFBattery.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLFBattery.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLFBattery.ForeColor = System.Drawing.Color.Blue
        Me.lbLFBattery.Location = New System.Drawing.Point(1050, 312)
        Me.lbLFBattery.Name = "lbLFBattery"
        Me.lbLFBattery.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLFBattery.Size = New System.Drawing.Size(35, 16)
        Me.lbLFBattery.TabIndex = 60
        Me.lbLFBattery.Text = "123"
        Me.lbLFBattery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLFMdl
        '
        Me.lbLFMdl.BackColor = System.Drawing.Color.Transparent
        Me.lbLFMdl.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLFMdl.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLFMdl.ForeColor = System.Drawing.Color.Blue
        Me.lbLFMdl.Location = New System.Drawing.Point(1050, 296)
        Me.lbLFMdl.Name = "lbLFMdl"
        Me.lbLFMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLFMdl.Size = New System.Drawing.Size(35, 16)
        Me.lbLFMdl.TabIndex = 59
        Me.lbLFMdl.Text = "123"
        Me.lbLFMdl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLFPre
        '
        Me.lbLFPre.BackColor = System.Drawing.Color.Transparent
        Me.lbLFPre.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLFPre.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLFPre.ForeColor = System.Drawing.Color.Blue
        Me.lbLFPre.Location = New System.Drawing.Point(1127, 296)
        Me.lbLFPre.Name = "lbLFPre"
        Me.lbLFPre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLFPre.Size = New System.Drawing.Size(35, 16)
        Me.lbLFPre.TabIndex = 58
        Me.lbLFPre.Text = "123"
        Me.lbLFPre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLFTemp
        '
        Me.lbLFTemp.BackColor = System.Drawing.Color.Transparent
        Me.lbLFTemp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLFTemp.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLFTemp.ForeColor = System.Drawing.Color.Blue
        Me.lbLFTemp.Location = New System.Drawing.Point(1208, 296)
        Me.lbLFTemp.Name = "lbLFTemp"
        Me.lbLFTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLFTemp.Size = New System.Drawing.Size(35, 16)
        Me.lbLFTemp.TabIndex = 57
        Me.lbLFTemp.Text = "123"
        Me.lbLFTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(522, 296)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(45, 16)
        Me.Label39.TabIndex = 56
        Me.Label39.Text = "模式:"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLRTemp
        '
        Me.lbLRTemp.BackColor = System.Drawing.Color.Transparent
        Me.lbLRTemp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLRTemp.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLRTemp.ForeColor = System.Drawing.Color.Blue
        Me.lbLRTemp.Location = New System.Drawing.Point(716, 296)
        Me.lbLRTemp.Name = "lbLRTemp"
        Me.lbLRTemp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLRTemp.Size = New System.Drawing.Size(35, 16)
        Me.lbLRTemp.TabIndex = 55
        Me.lbLRTemp.Text = "123"
        Me.lbLRTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLRPre
        '
        Me.lbLRPre.BackColor = System.Drawing.Color.Transparent
        Me.lbLRPre.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLRPre.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLRPre.ForeColor = System.Drawing.Color.Blue
        Me.lbLRPre.Location = New System.Drawing.Point(635, 296)
        Me.lbLRPre.Name = "lbLRPre"
        Me.lbLRPre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLRPre.Size = New System.Drawing.Size(35, 16)
        Me.lbLRPre.TabIndex = 54
        Me.lbLRPre.Text = "123"
        Me.lbLRPre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLRMdl
        '
        Me.lbLRMdl.BackColor = System.Drawing.Color.Transparent
        Me.lbLRMdl.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLRMdl.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLRMdl.ForeColor = System.Drawing.Color.Blue
        Me.lbLRMdl.Location = New System.Drawing.Point(562, 296)
        Me.lbLRMdl.Name = "lbLRMdl"
        Me.lbLRMdl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLRMdl.Size = New System.Drawing.Size(35, 16)
        Me.lbLRMdl.TabIndex = 53
        Me.lbLRMdl.Text = "123"
        Me.lbLRMdl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLRBattery
        '
        Me.lbLRBattery.BackColor = System.Drawing.Color.Transparent
        Me.lbLRBattery.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLRBattery.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLRBattery.ForeColor = System.Drawing.Color.Blue
        Me.lbLRBattery.Location = New System.Drawing.Point(561, 312)
        Me.lbLRBattery.Name = "lbLRBattery"
        Me.lbLRBattery.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLRBattery.Size = New System.Drawing.Size(35, 16)
        Me.lbLRBattery.TabIndex = 52
        Me.lbLRBattery.Text = "123"
        Me.lbLRBattery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLRAcSpeed
        '
        Me.lbLRAcSpeed.BackColor = System.Drawing.Color.Transparent
        Me.lbLRAcSpeed.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbLRAcSpeed.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLRAcSpeed.ForeColor = System.Drawing.Color.Blue
        Me.lbLRAcSpeed.Location = New System.Drawing.Point(649, 312)
        Me.lbLRAcSpeed.Name = "lbLRAcSpeed"
        Me.lbLRAcSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbLRAcSpeed.Size = New System.Drawing.Size(35, 16)
        Me.lbLRAcSpeed.TabIndex = 51
        Me.lbLRAcSpeed.Text = "123"
        Me.lbLRAcSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(1014, 622)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(45, 16)
        Me.Label32.TabIndex = 50
        Me.Label32.Text = "模式:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(1089, 622)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(45, 16)
        Me.Label31.TabIndex = 49
        Me.Label31.Text = "压力:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(1170, 622)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(45, 16)
        Me.Label30.TabIndex = 48
        Me.Label30.Text = "温度:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(1088, 638)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(80, 16)
        Me.Label29.TabIndex = 47
        Me.Label29.Text = "加速度："
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(1014, 638)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(45, 16)
        Me.Label28.TabIndex = 46
        Me.Label28.Text = "电池:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(522, 622)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(45, 16)
        Me.Label27.TabIndex = 45
        Me.Label27.Text = "模式:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(596, 622)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(45, 16)
        Me.Label26.TabIndex = 44
        Me.Label26.Text = "压力:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(684, 622)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(45, 16)
        Me.Label25.TabIndex = 43
        Me.Label25.Text = "温度:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(595, 638)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(80, 16)
        Me.Label24.TabIndex = 42
        Me.Label24.Text = "加速度："
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(522, 638)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(45, 16)
        Me.Label23.TabIndex = 41
        Me.Label23.Text = "电池:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(1012, 296)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(45, 16)
        Me.Label22.TabIndex = 40
        Me.Label22.Text = "模式:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(1087, 296)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(45, 16)
        Me.Label21.TabIndex = 39
        Me.Label21.Text = "压力:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(1170, 296)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(45, 16)
        Me.Label20.TabIndex = 38
        Me.Label20.Text = "温度:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(1086, 312)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(80, 16)
        Me.Label19.TabIndex = 37
        Me.Label19.Text = "加速度："
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(1012, 312)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(45, 16)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "电池:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(597, 296)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(45, 16)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "压力:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(678, 296)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(45, 16)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "温度:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(597, 312)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "加速度："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("黑体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(522, 312)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "电池:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labNow
        '
        Me.labNow.BackColor = System.Drawing.Color.Green
        Me.labNow.Cursor = System.Windows.Forms.Cursors.Default
        Me.labNow.Font = New System.Drawing.Font("黑体", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.labNow.ForeColor = System.Drawing.Color.Blue
        Me.labNow.Location = New System.Drawing.Point(632, 358)
        Me.labNow.Name = "labNow"
        Me.labNow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labNow.Size = New System.Drawing.Size(447, 87)
        Me.labNow.TabIndex = 2
        Me.labNow.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label16.Location = New System.Drawing.Point(153, 699)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(89, 24)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "网络连接"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label15.Location = New System.Drawing.Point(297, 699)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(105, 25)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "本地数据库"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label11.Location = New System.Drawing.Point(625, 699)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(145, 24)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "数据库硬盘容量"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label12.Location = New System.Drawing.Point(1001, 699)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(105, 25)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "右侧控制器"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label13.Location = New System.Drawing.Point(833, 699)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(105, 25)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "左侧控制器"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label14.Location = New System.Drawing.Point(459, 699)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(105, 25)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "SPPV数据库"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("黑体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label10.Location = New System.Drawing.Point(1047, 589)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(49, 31)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "右前"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("黑体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label9.Location = New System.Drawing.Point(550, 589)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(49, 31)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "右后"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("黑体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label8.Location = New System.Drawing.Point(1049, 264)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(49, 31)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "左前"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("黑体", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label7.Location = New System.Drawing.Point(556, 264)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(49, 31)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "左后"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("宋体", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(272, 240)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(201, 27)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "排产队列"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("宋体", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(32, 240)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(200, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "扫描队列"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labVin
        '
        Me.labVin.BackColor = System.Drawing.Color.Transparent
        Me.labVin.Cursor = System.Windows.Forms.Cursors.Default
        Me.labVin.Font = New System.Drawing.Font("宋体", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labVin.ForeColor = System.Drawing.Color.White
        Me.labVin.Location = New System.Drawing.Point(0, 32)
        Me.labVin.Name = "labVin"
        Me.labVin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labVin.Size = New System.Drawing.Size(1210, 91)
        Me.labVin.TabIndex = 4
        Me.labVin.Text = "胎压检测初始化系统"
        Me.labVin.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'labNext
        '
        Me.labNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.labNext.Cursor = System.Windows.Forms.Cursors.Default
        Me.labNext.Font = New System.Drawing.Font("黑体", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.labNext.ForeColor = System.Drawing.Color.Blue
        Me.labNext.Location = New System.Drawing.Point(632, 448)
        Me.labNext.Name = "labNext"
        Me.labNext.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labNext.Size = New System.Drawing.Size(449, 89)
        Me.labNext.TabIndex = 3
        Me.labNext.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        'frmInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1280, 768)
        Me.Controls.Add(Me.Picture4)
        Me.Controls.Add(Me.Picture10)
        Me.Controls.Add(Me.PicInd)
        Me.Controls.Add(Me.PicNet)
        Me.Controls.Add(Me.Picture9)
        Me.Controls.Add(Me.Picture8)
        Me.Controls.Add(Me.Picture7)
        Me.Controls.Add(Me.Picture6)
        Me.Controls.Add(Me.picRF)
        Me.Controls.Add(Me.txtRF)
        Me.Controls.Add(Me.picRR)
        Me.Controls.Add(Me.txtRR)
        Me.Controls.Add(Me.picLF)
        Me.Controls.Add(Me.txtLF)
        Me.Controls.Add(Me.picLR)
        Me.Controls.Add(Me.txtLR)
        Me.Controls.Add(Me.txtInfo)
        Me.Controls.Add(Me.ListInput)
        Me.Controls.Add(Me.ListOutput)
        Me.Controls.Add(Me.WindowsXPC1)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbRFTemp)
        Me.Controls.Add(Me.lbRFPre)
        Me.Controls.Add(Me.lbRFMdl)
        Me.Controls.Add(Me.lbRFBattery)
        Me.Controls.Add(Me.lbRFAcSpeed)
        Me.Controls.Add(Me.lbRRAcSpeed)
        Me.Controls.Add(Me.lbRRBattery)
        Me.Controls.Add(Me.lbRRMdl)
        Me.Controls.Add(Me.lbRRPre)
        Me.Controls.Add(Me.lbRRTemp)
        Me.Controls.Add(Me.lbLFAcSpeed)
        Me.Controls.Add(Me.lbLFBattery)
        Me.Controls.Add(Me.lbLFMdl)
        Me.Controls.Add(Me.lbLFPre)
        Me.Controls.Add(Me.lbLFTemp)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.lbLRTemp)
        Me.Controls.Add(Me.lbLRPre)
        Me.Controls.Add(Me.lbLRMdl)
        Me.Controls.Add(Me.lbLRBattery)
        Me.Controls.Add(Me.lbLRAcSpeed)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.labNow)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.labVin)
        Me.Controls.Add(Me.labNext)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmInfo"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        CType(Me.Picture4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicInd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicNet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
#End Region 
End Class