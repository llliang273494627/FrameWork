<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDateZone
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
	Public WithEvents WindowsXPC1 As AxWinXPC_Engine.AxWindowsXPC
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdSaveAs As System.Windows.Forms.Button
	Public WithEvents dtpLow As AxMSComCtl2.AxDTPicker
	Public WithEvents dtpHigh As AxMSComCtl2.AxDTPicker
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'ע��: ���¹����� Windows ����������������
	'����ʹ�� Windows ������������޸�����
	'��Ҫʹ�ô���༭���޸�����
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDateZone))
        Me.WindowsXPC1 = New AxWinXPC_Engine.AxWindowsXPC()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSaveAs = New System.Windows.Forms.Button()
        Me.dtpLow = New AxMSComCtl2.AxDTPicker()
        Me.dtpHigh = New AxMSComCtl2.AxDTPicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpLow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpHigh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WindowsXPC1
        '
        Me.WindowsXPC1.Enabled = True
        Me.WindowsXPC1.Location = New System.Drawing.Point(40, 144)
        Me.WindowsXPC1.Name = "WindowsXPC1"
        Me.WindowsXPC1.OcxState = CType(resources.GetObject("WindowsXPC1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.WindowsXPC1.Size = New System.Drawing.Size(249, 41)
        Me.WindowsXPC1.TabIndex = 0
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(112, 130)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(61, 21)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "ȡ��"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdSaveAs
        '
        Me.cmdSaveAs.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSaveAs.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSaveAs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSaveAs.Location = New System.Drawing.Point(200, 130)
        Me.cmdSaveAs.Name = "cmdSaveAs"
        Me.cmdSaveAs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSaveAs.Size = New System.Drawing.Size(61, 21)
        Me.cmdSaveAs.TabIndex = 4
        Me.cmdSaveAs.Text = "����"
        Me.cmdSaveAs.UseVisualStyleBackColor = False
        '
        'dtpLow
        '
        Me.dtpLow.Location = New System.Drawing.Point(112, 56)
        Me.dtpLow.Name = "dtpLow"
        Me.dtpLow.OcxState = CType(resources.GetObject("dtpLow.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dtpLow.Size = New System.Drawing.Size(151, 21)
        Me.dtpLow.TabIndex = 0
        '
        'dtpHigh
        '
        Me.dtpHigh.Location = New System.Drawing.Point(112, 92)
        Me.dtpHigh.Name = "dtpHigh"
        Me.dtpHigh.OcxState = CType(resources.GetObject("dtpHigh.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dtpHigh.Size = New System.Drawing.Size(151, 21)
        Me.dtpHigh.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(0, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(309, 29)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "ѡ�񵼳�����ֹ����"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(36, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(61, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ֹ����"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(36, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(59, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "������"
        '
        'frmDateZone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(312, 185)
        Me.Controls.Add(Me.WindowsXPC1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSaveAs)
        Me.Controls.Add(Me.dtpLow)
        Me.Controls.Add(Me.dtpHigh)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDateZone"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ѡ�񵼳�ʱ��"
        CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpLow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpHigh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class