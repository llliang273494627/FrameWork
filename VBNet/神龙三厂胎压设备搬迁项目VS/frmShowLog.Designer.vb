<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmShowLog
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
	Public WithEvents DateSelect As AxMSACAL.AxCalendar
	Public WithEvents WindowsXPC1 As AxWinXPC_Engine.AxWindowsXPC
	Public WithEvents DateSelect11 As System.Windows.Forms.Panel
	'注意: 以下过程是 Windows 窗体设计器所必需的
	'可以使用 Windows 窗体设计器来修改它。
	'不要使用代码编辑器修改它。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmShowLog))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.DateSelect11 = New System.Windows.Forms.Panel
		Me.DateSelect = New AxMSACAL.AxCalendar
		Me.WindowsXPC1 = New AxWinXPC_Engine.AxWindowsXPC
		Me.DateSelect11.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.DateSelect, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "日志查询"
		Me.ClientSize = New System.Drawing.Size(304, 198)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.Icon = CType(resources.GetObject("frmShowLog.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmShowLog"
		Me.DateSelect11.Size = New System.Drawing.Size(304, 197)
		Me.DateSelect11.Location = New System.Drawing.Point(0, 0)
		Me.DateSelect11.TabIndex = 0
		Me.DateSelect11.Dock = System.Windows.Forms.DockStyle.None
		Me.DateSelect11.BackColor = System.Drawing.SystemColors.Control
		Me.DateSelect11.CausesValidation = True
		Me.DateSelect11.Enabled = True
		Me.DateSelect11.ForeColor = System.Drawing.SystemColors.ControlText
		Me.DateSelect11.Cursor = System.Windows.Forms.Cursors.Default
		Me.DateSelect11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DateSelect11.TabStop = True
		Me.DateSelect11.Visible = True
		Me.DateSelect11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.DateSelect11.Name = "DateSelect11"
		DateSelect.OcxState = CType(resources.GetObject("DateSelect.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DateSelect.Size = New System.Drawing.Size(297, 193)
		Me.DateSelect.Location = New System.Drawing.Point(0, 0)
		Me.DateSelect.TabIndex = 1
		Me.DateSelect.Name = "DateSelect"
		WindowsXPC1.OcxState = CType(resources.GetObject("WindowsXPC1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.WindowsXPC1.Location = New System.Drawing.Point(224, 88)
		Me.WindowsXPC1.Name = "WindowsXPC1"
		Me.Controls.Add(DateSelect11)
		Me.DateSelect11.Controls.Add(DateSelect)
		Me.DateSelect11.Controls.Add(WindowsXPC1)
		CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DateSelect, System.ComponentModel.ISupportInitialize).EndInit()
		Me.DateSelect11.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class