<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmShowLog
#Region "Windows ������������ɵĴ��� "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'�˵����� Windows ���������������ġ�
		InitializeComponent()
	End Sub
	'Form ��д Dispose������������б���
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
    Public WithEvents DateSelect As AxMSACAL.AxCalendar
    'ע��: ���¹����� Windows ����������������
    '����ʹ�� Windows ������������޸�����
    '��Ҫʹ�ô���༭���޸�����
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShowLog))
        Me.DateSelect = New AxMSACAL.AxCalendar()
        CType(Me.DateSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateSelect
        '
        Me.DateSelect.Enabled = True
        Me.DateSelect.Location = New System.Drawing.Point(3, 1)
        Me.DateSelect.Name = "DateSelect"
        Me.DateSelect.OcxState = CType(resources.GetObject("DateSelect.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DateSelect.Size = New System.Drawing.Size(296, 197)
        Me.DateSelect.TabIndex = 0
        '
        'frmShowLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(304, 198)
        Me.Controls.Add(Me.DateSelect)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmShowLog"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "��־��ѯ"
        CType(Me.DateSelect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class