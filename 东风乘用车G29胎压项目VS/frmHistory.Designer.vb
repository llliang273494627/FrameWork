<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmHistory
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
	Public WithEvents Combo1 As System.Windows.Forms.ComboBox
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents MSFlexGrid1 As AxMSFlexGridLib.AxMSFlexGrid
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents WindowsXPC1 As AxWinXPC_Engine.AxWindowsXPC
	Public WithEvents Command4 As System.Windows.Forms.Button
	Public WithEvents dtpHigh As AxMSComCtl2.AxDTPicker
	Public WithEvents dtpLow As AxMSComCtl2.AxDTPicker
	Public WithEvents txtVIN As System.Windows.Forms.TextBox
	Public WithEvents lab_rate As System.Windows.Forms.Label
	Public WithEvents lal_ok_num As System.Windows.Forms.Label
	Public WithEvents lbl_test_num As System.Windows.Forms.Label
	Public WithEvents lbl_Rate As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	'注意: 以下过程是 Windows 窗体设计器所必需的
	'可以使用 Windows 窗体设计器来修改它。
	'不要使用代码编辑器修改它。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHistory))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Frame3 = New System.Windows.Forms.GroupBox
		Me.Combo1 = New System.Windows.Forms.ComboBox
		Me.Command3 = New System.Windows.Forms.Button
		Me.Command2 = New System.Windows.Forms.Button
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Frame2 = New System.Windows.Forms.GroupBox
		Me.MSFlexGrid1 = New AxMSFlexGridLib.AxMSFlexGrid
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.WindowsXPC1 = New AxWinXPC_Engine.AxWindowsXPC
		Me.Command4 = New System.Windows.Forms.Button
		Me.dtpHigh = New AxMSComCtl2.AxDTPicker
		Me.dtpLow = New AxMSComCtl2.AxDTPicker
		Me.txtVIN = New System.Windows.Forms.TextBox
		Me.lab_rate = New System.Windows.Forms.Label
		Me.lal_ok_num = New System.Windows.Forms.Label
		Me.lbl_test_num = New System.Windows.Forms.Label
		Me.lbl_Rate = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Frame3.SuspendLayout()
		Me.Frame2.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.MSFlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtpHigh, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtpLow, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.White
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "显示历史记录"
		Me.ClientSize = New System.Drawing.Size(792, 566)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.Icon = CType(resources.GetObject("frmHistory.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmHistory"
		Me.Frame3.BackColor = System.Drawing.Color.White
		Me.Frame3.Text = "功能  "
		Me.Frame3.Size = New System.Drawing.Size(97, 375)
		Me.Frame3.Location = New System.Drawing.Point(688, 176)
		Me.Frame3.TabIndex = 2
		Me.Frame3.Enabled = True
		Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame3.Visible = True
		Me.Frame3.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame3.Name = "Frame3"
		Me.Combo1.Size = New System.Drawing.Size(59, 20)
		Me.Combo1.Location = New System.Drawing.Point(328, 56)
		Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Combo1.TabIndex = 14
		Me.Combo1.BackColor = System.Drawing.SystemColors.Window
		Me.Combo1.CausesValidation = True
		Me.Combo1.Enabled = True
		Me.Combo1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Combo1.IntegralHeight = True
		Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Combo1.Sorted = False
		Me.Combo1.TabStop = True
		Me.Combo1.Visible = True
		Me.Combo1.Name = "Combo1"
		Me.Command3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command3.Text = "取    消"
		Me.Command3.Size = New System.Drawing.Size(79, 29)
		Me.Command3.Location = New System.Drawing.Point(8, 280)
		Me.Command3.TabIndex = 11
		Me.Command3.BackColor = System.Drawing.SystemColors.Control
		Me.Command3.CausesValidation = True
		Me.Command3.Enabled = True
		Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command3.TabStop = True
		Me.Command3.Name = "Command3"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "导    出"
		Me.Command2.Size = New System.Drawing.Size(79, 29)
		Me.Command2.Location = New System.Drawing.Point(8, 216)
		Me.Command2.TabIndex = 9
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label5.BackColor = System.Drawing.Color.White
		Me.Label5.Text = "上一页"
		Me.Label5.ForeColor = System.Drawing.SystemColors.Highlight
		Me.Label5.Size = New System.Drawing.Size(97, 29)
		Me.Label5.Location = New System.Drawing.Point(0, 64)
		Me.Label5.TabIndex = 13
		Me.Label5.Enabled = True
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label4.BackColor = System.Drawing.Color.White
		Me.Label4.Text = "下一页"
		Me.Label4.ForeColor = System.Drawing.SystemColors.Highlight
		Me.Label4.Size = New System.Drawing.Size(89, 29)
		Me.Label4.Location = New System.Drawing.Point(8, 128)
		Me.Label4.TabIndex = 12
		Me.Label4.Enabled = True
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Frame2.BackColor = System.Drawing.Color.White
		Me.Frame2.Text = "结果显示    "
		Me.Frame2.Size = New System.Drawing.Size(675, 377)
		Me.Frame2.Location = New System.Drawing.Point(6, 172)
		Me.Frame2.TabIndex = 1
		Me.Frame2.Enabled = True
		Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Visible = True
		Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame2.Name = "Frame2"
		MSFlexGrid1.OcxState = CType(resources.GetObject("MSFlexGrid1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.MSFlexGrid1.Size = New System.Drawing.Size(661, 357)
		Me.MSFlexGrid1.Location = New System.Drawing.Point(8, 16)
		Me.MSFlexGrid1.TabIndex = 10
		Me.MSFlexGrid1.Name = "MSFlexGrid1"
		Me.Frame1.BackColor = System.Drawing.Color.White
		Me.Frame1.Text = "条件选择    "
		Me.Frame1.Size = New System.Drawing.Size(781, 157)
		Me.Frame1.Location = New System.Drawing.Point(4, 8)
		Me.Frame1.TabIndex = 0
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		WindowsXPC1.OcxState = CType(resources.GetObject("WindowsXPC1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.WindowsXPC1.Location = New System.Drawing.Point(592, 40)
		Me.WindowsXPC1.Name = "WindowsXPC1"
		Me.Command4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command4.Text = "查询"
		Me.Command4.Size = New System.Drawing.Size(81, 25)
		Me.Command4.Location = New System.Drawing.Point(644, 86)
		Me.Command4.TabIndex = 15
		Me.Command4.BackColor = System.Drawing.SystemColors.Control
		Me.Command4.CausesValidation = True
		Me.Command4.Enabled = True
		Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command4.TabStop = True
		Me.Command4.Name = "Command4"
		dtpHigh.OcxState = CType(resources.GetObject("dtpHigh.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dtpHigh.Size = New System.Drawing.Size(127, 25)
		Me.dtpHigh.Location = New System.Drawing.Point(400, 64)
		Me.dtpHigh.TabIndex = 8
		Me.dtpHigh.Name = "dtpHigh"
		dtpLow.OcxState = CType(resources.GetObject("dtpLow.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dtpLow.Size = New System.Drawing.Size(125, 25)
		Me.dtpLow.Location = New System.Drawing.Point(152, 64)
		Me.dtpLow.TabIndex = 7
		Me.dtpLow.Name = "dtpLow"
		Me.txtVIN.AutoSize = False
		Me.txtVIN.Font = New System.Drawing.Font("宋体", 18!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.txtVIN.Size = New System.Drawing.Size(369, 27)
		Me.txtVIN.Location = New System.Drawing.Point(160, 24)
		Me.txtVIN.Maxlength = 17
		Me.txtVIN.TabIndex = 4
		Me.txtVIN.AcceptsReturn = True
		Me.txtVIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtVIN.BackColor = System.Drawing.SystemColors.Window
		Me.txtVIN.CausesValidation = True
		Me.txtVIN.Enabled = True
		Me.txtVIN.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtVIN.HideSelection = True
		Me.txtVIN.ReadOnly = False
		Me.txtVIN.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtVIN.MultiLine = False
		Me.txtVIN.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtVIN.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtVIN.TabStop = True
		Me.txtVIN.Visible = True
		Me.txtVIN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtVIN.Name = "txtVIN"
		Me.lab_rate.BackColor = System.Drawing.Color.White
		Me.lab_rate.Text = "Label11"
		Me.lab_rate.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lab_rate.ForeColor = System.Drawing.Color.FromARGB(0, 128, 0)
		Me.lab_rate.Size = New System.Drawing.Size(97, 25)
		Me.lab_rate.Location = New System.Drawing.Point(480, 120)
		Me.lab_rate.TabIndex = 21
		Me.lab_rate.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lab_rate.Enabled = True
		Me.lab_rate.Cursor = System.Windows.Forms.Cursors.Default
		Me.lab_rate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lab_rate.UseMnemonic = True
		Me.lab_rate.Visible = True
		Me.lab_rate.AutoSize = False
		Me.lab_rate.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lab_rate.Name = "lab_rate"
		Me.lal_ok_num.BackColor = System.Drawing.Color.White
		Me.lal_ok_num.Text = "Label10"
		Me.lal_ok_num.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lal_ok_num.ForeColor = System.Drawing.Color.FromARGB(0, 128, 0)
		Me.lal_ok_num.Size = New System.Drawing.Size(89, 17)
		Me.lal_ok_num.Location = New System.Drawing.Point(312, 120)
		Me.lal_ok_num.TabIndex = 20
		Me.lal_ok_num.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lal_ok_num.Enabled = True
		Me.lal_ok_num.Cursor = System.Windows.Forms.Cursors.Default
		Me.lal_ok_num.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lal_ok_num.UseMnemonic = True
		Me.lal_ok_num.Visible = True
		Me.lal_ok_num.AutoSize = False
		Me.lal_ok_num.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lal_ok_num.Name = "lal_ok_num"
		Me.lbl_test_num.BackColor = System.Drawing.Color.White
		Me.lbl_test_num.Text = "Label9"
		Me.lbl_test_num.Font = New System.Drawing.Font("宋体", 14.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.lbl_test_num.ForeColor = System.Drawing.Color.FromARGB(0, 128, 0)
		Me.lbl_test_num.Size = New System.Drawing.Size(89, 17)
		Me.lbl_test_num.Location = New System.Drawing.Point(112, 120)
		Me.lbl_test_num.TabIndex = 19
		Me.lbl_test_num.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbl_test_num.Enabled = True
		Me.lbl_test_num.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbl_test_num.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbl_test_num.UseMnemonic = True
		Me.lbl_test_num.Visible = True
		Me.lbl_test_num.AutoSize = False
		Me.lbl_test_num.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbl_test_num.Name = "lbl_test_num"
		Me.lbl_Rate.BackColor = System.Drawing.Color.White
		Me.lbl_Rate.Text = "合格率："
		Me.lbl_Rate.Size = New System.Drawing.Size(113, 17)
		Me.lbl_Rate.Location = New System.Drawing.Point(424, 120)
		Me.lbl_Rate.TabIndex = 18
		Me.lbl_Rate.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbl_Rate.Enabled = True
		Me.lbl_Rate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbl_Rate.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbl_Rate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbl_Rate.UseMnemonic = True
		Me.lbl_Rate.Visible = True
		Me.lbl_Rate.AutoSize = False
		Me.lbl_Rate.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbl_Rate.Name = "lbl_Rate"
		Me.Label7.BackColor = System.Drawing.Color.White
		Me.Label7.Text = "合格数量（台）："
		Me.Label7.Size = New System.Drawing.Size(105, 17)
		Me.Label7.Location = New System.Drawing.Point(208, 120)
		Me.Label7.TabIndex = 17
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
		Me.Label6.BackColor = System.Drawing.Color.White
		Me.Label6.Text = "测试数量（台）："
		Me.Label6.Size = New System.Drawing.Size(113, 25)
		Me.Label6.Location = New System.Drawing.Point(8, 120)
		Me.Label6.TabIndex = 16
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label3.BackColor = System.Drawing.Color.White
		Me.Label3.Text = "起始日期"
		Me.Label3.Font = New System.Drawing.Font("宋体", 18!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.Blue
		Me.Label3.Size = New System.Drawing.Size(109, 23)
		Me.Label3.Location = New System.Drawing.Point(40, 64)
		Me.Label3.TabIndex = 6
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.Enabled = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.BackColor = System.Drawing.Color.White
		Me.Label2.Text = "截止日期"
		Me.Label2.Font = New System.Drawing.Font("宋体", 18!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.Blue
		Me.Label2.Size = New System.Drawing.Size(103, 23)
		Me.Label2.Location = New System.Drawing.Point(290, 64)
		Me.Label2.TabIndex = 5
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.BackColor = System.Drawing.Color.White
		Me.Label1.Text = "VID"
		Me.Label1.Font = New System.Drawing.Font("宋体", 18!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.Blue
		Me.Label1.Size = New System.Drawing.Size(45, 23)
		Me.Label1.Location = New System.Drawing.Point(106, 24)
		Me.Label1.TabIndex = 3
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(Frame3)
		Me.Controls.Add(Frame2)
		Me.Controls.Add(Frame1)
		Me.Frame3.Controls.Add(Combo1)
		Me.Frame3.Controls.Add(Command3)
		Me.Frame3.Controls.Add(Command2)
		Me.Frame3.Controls.Add(Label5)
		Me.Frame3.Controls.Add(Label4)
		Me.Frame2.Controls.Add(MSFlexGrid1)
		Me.Frame1.Controls.Add(WindowsXPC1)
		Me.Frame1.Controls.Add(Command4)
		Me.Frame1.Controls.Add(dtpHigh)
		Me.Frame1.Controls.Add(dtpLow)
		Me.Frame1.Controls.Add(txtVIN)
		Me.Frame1.Controls.Add(lab_rate)
		Me.Frame1.Controls.Add(lal_ok_num)
		Me.Frame1.Controls.Add(lbl_test_num)
		Me.Frame1.Controls.Add(lbl_Rate)
		Me.Frame1.Controls.Add(Label7)
		Me.Frame1.Controls.Add(Label6)
		Me.Frame1.Controls.Add(Label3)
		Me.Frame1.Controls.Add(Label2)
		Me.Frame1.Controls.Add(Label1)
		CType(Me.dtpLow, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dtpHigh, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.MSFlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame3.ResumeLayout(False)
		Me.Frame2.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class