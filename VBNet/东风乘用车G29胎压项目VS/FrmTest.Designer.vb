<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class FrmTest
#Region "Windows ������������ɵĴ��� "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'�˵����� Windows ���������������ġ�
		InitializeComponent()
	End Sub
	'Form ��д Dispose������������б�
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Windows ����������������
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	'ע��: ���¹����� Windows ����������������
	'����ʹ�� Windows ������������޸�����
	'��Ҫʹ�ô���༭���޸�����
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrmTest))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Timer1 = New System.Windows.Forms.Timer(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.Text = "Form1"
		Me.ClientSize = New System.Drawing.Size(169, 121)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
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
		Me.Name = "FrmTest"
		Me.Timer1.Interval = 100
		Me.Timer1.Enabled = True
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class