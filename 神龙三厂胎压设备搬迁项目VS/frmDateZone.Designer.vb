<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDateZone
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
	Public WithEvents WindowsXPC1 As AxWinXPC_Engine.AxWindowsXPC
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdSaveAs As System.Windows.Forms.Button
	Public WithEvents dtpLow As AxMSComCtl2.AxDTPicker
	Public WithEvents dtpHigh As AxMSComCtl2.AxDTPicker
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'注意: 以下过程是 Windows 窗体设计器所必需的
	'可以使用 Windows 窗体设计器来修改它。
	'不要使用代码编辑器修改它。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDateZone))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.WindowsXPC1 = New AxWinXPC_Engine.AxWindowsXPC
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdSaveAs = New System.Windows.Forms.Button
		Me.dtpLow = New AxMSComCtl2.AxDTPicker
		Me.dtpHigh = New AxMSComCtl2.AxDTPicker
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtpLow, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dtpHigh, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.White
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "选择导出时间"
		Me.ClientSize = New System.Drawing.Size(312, 185)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.Icon = CType(resources.GetObject("frmDateZone.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmDateZone"
		WindowsXPC1.OcxState = CType(resources.GetObject("WindowsXPC1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.WindowsXPC1.Location = New System.Drawing.Point(40, 144)
		Me.WindowsXPC1.Name = "WindowsXPC1"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "取消"
		Me.cmdCancel.Size = New System.Drawing.Size(61, 21)
		Me.cmdCancel.Location = New System.Drawing.Point(112, 130)
		Me.cmdCancel.TabIndex = 6
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdSaveAs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSaveAs.Text = "导出"
		Me.cmdSaveAs.Size = New System.Drawing.Size(61, 21)
		Me.cmdSaveAs.Location = New System.Drawing.Point(200, 130)
		Me.cmdSaveAs.TabIndex = 4
		Me.cmdSaveAs.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSaveAs.CausesValidation = True
		Me.cmdSaveAs.Enabled = True
		Me.cmdSaveAs.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSaveAs.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSaveAs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSaveAs.TabStop = True
		Me.cmdSaveAs.Name = "cmdSaveAs"
		dtpLow.OcxState = CType(resources.GetObject("dtpLow.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dtpLow.Size = New System.Drawing.Size(151, 21)
		Me.dtpLow.Location = New System.Drawing.Point(112, 56)
		Me.dtpLow.TabIndex = 0
		Me.dtpLow.Name = "dtpLow"
		dtpHigh.OcxState = CType(resources.GetObject("dtpHigh.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dtpHigh.Size = New System.Drawing.Size(151, 21)
		Me.dtpHigh.Location = New System.Drawing.Point(112, 92)
		Me.dtpHigh.TabIndex = 1
		Me.dtpHigh.Name = "dtpHigh"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label3.BackColor = System.Drawing.Color.White
		Me.Label3.Text = "选择导出的起止日期"
		Me.Label3.Font = New System.Drawing.Font("楷体_GB2312", 15.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.Blue
		Me.Label3.Size = New System.Drawing.Size(309, 29)
		Me.Label3.Location = New System.Drawing.Point(0, 6)
		Me.Label3.TabIndex = 5
		Me.Label3.Enabled = True
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.Label2.Text = "止日期"
		Me.Label2.Font = New System.Drawing.Font("楷体_GB2312", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.Blue
		Me.Label2.Size = New System.Drawing.Size(61, 19)
		Me.Label2.Location = New System.Drawing.Point(36, 96)
		Me.Label2.TabIndex = 3
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
		Me.Label1.Text = "起日期"
		Me.Label1.Font = New System.Drawing.Font("楷体_GB2312", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.Blue
		Me.Label1.Size = New System.Drawing.Size(59, 19)
		Me.Label1.Location = New System.Drawing.Point(36, 58)
		Me.Label1.TabIndex = 2
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.Enabled = True
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(WindowsXPC1)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(cmdSaveAs)
		Me.Controls.Add(dtpLow)
		Me.Controls.Add(dtpHigh)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		CType(Me.dtpHigh, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dtpLow, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class