<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Form1
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
    Public WithEvents MSComm1 As AxMSCommLib.AxMSComm
	'ע��: ���¹����� Windows ����������������
	'����ʹ�� Windows ������������޸�����
	'��Ҫʹ�ô���༭���޸�����
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MSComm1 = New AxMSCommLib.AxMSComm
        CType(Me.MSComm1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MSComm1
        '
        Me.MSComm1.Enabled = True
        Me.MSComm1.Location = New System.Drawing.Point(136, 88)
        Me.MSComm1.Name = "MSComm1"
        Me.MSComm1.OcxState = CType(resources.GetObject("MSComm1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.MSComm1.Size = New System.Drawing.Size(38, 38)
        Me.MSComm1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(312, 206)
        Me.Controls.Add(Me.MSComm1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(515, 356)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        CType(Me.MSComm1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class