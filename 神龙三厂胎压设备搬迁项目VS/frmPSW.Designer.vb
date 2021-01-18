<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmPSW
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
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	'注意: 以下过程是 Windows 窗体设计器所必需的
	'可以使用 Windows 窗体设计器来修改它。
	'不要使用代码编辑器修改它。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPSW))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.WindowsXPC1 = New AxWinXPC_Engine.AxWindowsXPC
		Me.Command2 = New System.Windows.Forms.Button
		Me.Command1 = New System.Windows.Forms.Button
		Me.Text1 = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.White
		Me.Text = "管理密码验证"
		Me.ClientSize = New System.Drawing.Size(312, 120)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.Icon = CType(resources.GetObject("frmPSW.Icon"), System.Drawing.Icon)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
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
		Me.Name = "frmPSW"
		WindowsXPC1.OcxState = CType(resources.GetObject("WindowsXPC1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.WindowsXPC1.Location = New System.Drawing.Point(256, 56)
		Me.WindowsXPC1.Name = "WindowsXPC1"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "取消"
		Me.Command2.Size = New System.Drawing.Size(73, 25)
		Me.Command2.Location = New System.Drawing.Point(160, 80)
		Me.Command2.TabIndex = 3
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "确定"
		Me.Command1.Size = New System.Drawing.Size(73, 25)
		Me.Command1.Location = New System.Drawing.Point(72, 80)
		Me.Command1.TabIndex = 2
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.Text1.AutoSize = False
		Me.Text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.Text1.Size = New System.Drawing.Size(161, 25)
		Me.Text1.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.Text1.Location = New System.Drawing.Point(72, 40)
		Me.Text1.PasswordChar = ChrW(42)
		Me.Text1.TabIndex = 1
		Me.Text1.AcceptsReturn = True
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
		Me.Label1.Text = "请输入管理密码："
		Me.Label1.Size = New System.Drawing.Size(113, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 16)
		Me.Label1.TabIndex = 0
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(WindowsXPC1)
		Me.Controls.Add(Command2)
		Me.Controls.Add(Command1)
		Me.Controls.Add(Text1)
		Me.Controls.Add(Label1)
		CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class