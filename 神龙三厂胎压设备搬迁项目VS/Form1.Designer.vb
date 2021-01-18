<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Form1
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
	Public WithEvents MSComm1 As AxMSCommLib.AxMSComm
	'注意: 以下过程是 Windows 窗体设计器所必需的
	'可以使用 Windows 窗体设计器来修改它。
	'不要使用代码编辑器修改它。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.MSComm1 = New AxMSCommLib.AxMSComm
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.MSComm1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Form1"
		Me.ClientSize = New System.Drawing.Size(312, 206)
		Me.Location = New System.Drawing.Point(515, 356)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
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
		Me.Name = "Form1"
		MSComm1.OcxState = CType(resources.GetObject("MSComm1.OcxState"), System.Windows.Forms.AxHost.State)
		Me.MSComm1.Location = New System.Drawing.Point(136, 88)
		Me.MSComm1.Name = "MSComm1"
		Me.Controls.Add(MSComm1)
		CType(Me.MSComm1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class