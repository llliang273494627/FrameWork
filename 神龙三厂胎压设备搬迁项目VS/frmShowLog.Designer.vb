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
	'注意: 以下过程是 Windows 窗体设计器所必需的
	'可以使用 Windows 窗体设计器来修改它。
	'不要使用代码编辑器修改它。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShowLog))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DateSelect = New AxMSACAL.AxCalendar
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
        Me.Text = "日志查询"
        CType(Me.DateSelect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class