<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmHistory
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
	'ע��: ���¹����� Windows ����������������
	'����ʹ�� Windows ������������޸�����
	'��Ҫʹ�ô���༭���޸�����
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistory))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.Combo1 = New System.Windows.Forms.ComboBox()
        Me.Command3 = New System.Windows.Forms.Button()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.MSFlexGrid1 = New AxMSFlexGridLib.AxMSFlexGrid()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.WindowsXPC1 = New AxWinXPC_Engine.AxWindowsXPC()
        Me.Command4 = New System.Windows.Forms.Button()
        Me.dtpHigh = New AxMSComCtl2.AxDTPicker()
        Me.dtpLow = New AxMSComCtl2.AxDTPicker()
        Me.txtVIN = New System.Windows.Forms.TextBox()
        Me.lab_rate = New System.Windows.Forms.Label()
        Me.lal_ok_num = New System.Windows.Forms.Label()
        Me.lbl_test_num = New System.Windows.Forms.Label()
        Me.lbl_Rate = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Frame3.SuspendLayout()
        Me.Frame2.SuspendLayout()
        CType(Me.MSFlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame1.SuspendLayout()
        CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpHigh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpLow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.Color.White
        Me.Frame3.Controls.Add(Me.Combo1)
        Me.Frame3.Controls.Add(Me.Command3)
        Me.Frame3.Controls.Add(Me.Command2)
        Me.Frame3.Controls.Add(Me.Label5)
        Me.Frame3.Controls.Add(Me.Label4)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.Location = New System.Drawing.Point(688, 176)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(97, 375)
        Me.Frame3.TabIndex = 2
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "����  "
        '
        'Combo1
        '
        Me.Combo1.BackColor = System.Drawing.SystemColors.Window
        Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Combo1.Location = New System.Drawing.Point(328, 56)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Combo1.Size = New System.Drawing.Size(59, 20)
        Me.Combo1.TabIndex = 14
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(8, 280)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(79, 29)
        Me.Command3.TabIndex = 11
        Me.Command3.Text = "ȡ    ��"
        Me.Command3.UseVisualStyleBackColor = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(8, 216)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(79, 29)
        Me.Command2.TabIndex = 9
        Me.Command2.Text = "��    ��"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label5.Location = New System.Drawing.Point(0, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(97, 29)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "��һҳ"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label4.Location = New System.Drawing.Point(8, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(89, 29)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "��һҳ"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.Color.White
        Me.Frame2.Controls.Add(Me.MSFlexGrid1)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(6, 172)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(675, 377)
        Me.Frame2.TabIndex = 1
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "�����ʾ    "
        '
        'MSFlexGrid1
        '
        Me.MSFlexGrid1.Location = New System.Drawing.Point(8, 16)
        Me.MSFlexGrid1.Name = "MSFlexGrid1"
        Me.MSFlexGrid1.OcxState = CType(resources.GetObject("MSFlexGrid1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.MSFlexGrid1.Size = New System.Drawing.Size(661, 357)
        Me.MSFlexGrid1.TabIndex = 10
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.White
        Me.Frame1.Controls.Add(Me.WindowsXPC1)
        Me.Frame1.Controls.Add(Me.Command4)
        Me.Frame1.Controls.Add(Me.dtpHigh)
        Me.Frame1.Controls.Add(Me.dtpLow)
        Me.Frame1.Controls.Add(Me.txtVIN)
        Me.Frame1.Controls.Add(Me.lab_rate)
        Me.Frame1.Controls.Add(Me.lal_ok_num)
        Me.Frame1.Controls.Add(Me.lbl_test_num)
        Me.Frame1.Controls.Add(Me.lbl_Rate)
        Me.Frame1.Controls.Add(Me.Label7)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(4, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(781, 157)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "����ѡ��    "
        '
        'WindowsXPC1
        '
        Me.WindowsXPC1.Enabled = True
        Me.WindowsXPC1.Location = New System.Drawing.Point(592, 40)
        Me.WindowsXPC1.Name = "WindowsXPC1"
        Me.WindowsXPC1.OcxState = CType(resources.GetObject("WindowsXPC1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.WindowsXPC1.Size = New System.Drawing.Size(249, 41)
        Me.WindowsXPC1.TabIndex = 0
        '
        'Command4
        '
        Me.Command4.BackColor = System.Drawing.SystemColors.Control
        Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command4.Location = New System.Drawing.Point(644, 86)
        Me.Command4.Name = "Command4"
        Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command4.Size = New System.Drawing.Size(81, 25)
        Me.Command4.TabIndex = 15
        Me.Command4.Text = "��ѯ"
        Me.Command4.UseVisualStyleBackColor = False
        '
        'dtpHigh
        '
        Me.dtpHigh.Location = New System.Drawing.Point(400, 64)
        Me.dtpHigh.Name = "dtpHigh"
        Me.dtpHigh.OcxState = CType(resources.GetObject("dtpHigh.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dtpHigh.Size = New System.Drawing.Size(127, 25)
        Me.dtpHigh.TabIndex = 8
        '
        'dtpLow
        '
        Me.dtpLow.Location = New System.Drawing.Point(152, 64)
        Me.dtpLow.Name = "dtpLow"
        Me.dtpLow.OcxState = CType(resources.GetObject("dtpLow.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dtpLow.Size = New System.Drawing.Size(125, 25)
        Me.dtpLow.TabIndex = 7
        '
        'txtVIN
        '
        Me.txtVIN.AcceptsReturn = True
        Me.txtVIN.BackColor = System.Drawing.SystemColors.Window
        Me.txtVIN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVIN.Font = New System.Drawing.Font("����", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtVIN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVIN.Location = New System.Drawing.Point(160, 24)
        Me.txtVIN.MaxLength = 17
        Me.txtVIN.Name = "txtVIN"
        Me.txtVIN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVIN.Size = New System.Drawing.Size(369, 27)
        Me.txtVIN.TabIndex = 4
        '
        'lab_rate
        '
        Me.lab_rate.BackColor = System.Drawing.Color.White
        Me.lab_rate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lab_rate.Font = New System.Drawing.Font("����", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lab_rate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lab_rate.Location = New System.Drawing.Point(480, 120)
        Me.lab_rate.Name = "lab_rate"
        Me.lab_rate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lab_rate.Size = New System.Drawing.Size(97, 25)
        Me.lab_rate.TabIndex = 21
        Me.lab_rate.Text = "Label11"
        '
        'lal_ok_num
        '
        Me.lal_ok_num.BackColor = System.Drawing.Color.White
        Me.lal_ok_num.Cursor = System.Windows.Forms.Cursors.Default
        Me.lal_ok_num.Font = New System.Drawing.Font("����", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lal_ok_num.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lal_ok_num.Location = New System.Drawing.Point(312, 120)
        Me.lal_ok_num.Name = "lal_ok_num"
        Me.lal_ok_num.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lal_ok_num.Size = New System.Drawing.Size(89, 17)
        Me.lal_ok_num.TabIndex = 20
        Me.lal_ok_num.Text = "Label10"
        '
        'lbl_test_num
        '
        Me.lbl_test_num.BackColor = System.Drawing.Color.White
        Me.lbl_test_num.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_test_num.Font = New System.Drawing.Font("����", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbl_test_num.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_test_num.Location = New System.Drawing.Point(112, 120)
        Me.lbl_test_num.Name = "lbl_test_num"
        Me.lbl_test_num.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_test_num.Size = New System.Drawing.Size(89, 17)
        Me.lbl_test_num.TabIndex = 19
        Me.lbl_test_num.Text = "Label9"
        '
        'lbl_Rate
        '
        Me.lbl_Rate.BackColor = System.Drawing.Color.White
        Me.lbl_Rate.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_Rate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Rate.Location = New System.Drawing.Point(424, 120)
        Me.lbl_Rate.Name = "lbl_Rate"
        Me.lbl_Rate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbl_Rate.Size = New System.Drawing.Size(113, 17)
        Me.lbl_Rate.TabIndex = 18
        Me.lbl_Rate.Text = "�ϸ��ʣ�"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(208, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(105, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "�ϸ�������̨����"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(113, 25)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "����������̨����"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("����", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(40, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(109, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "��ʼ����"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("����", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(290, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(103, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "��ֹ����"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("����", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(106, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(45, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "VID"
        '
        'frmHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHistory"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "��ʾ��ʷ��¼"
        Me.Frame3.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        CType(Me.MSFlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame1.ResumeLayout(False)
        CType(Me.WindowsXPC1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpHigh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpLow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class