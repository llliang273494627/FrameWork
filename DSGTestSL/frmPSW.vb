Option Strict Off
Option Explicit On
Friend Class frmPSW
	Inherits System.Windows.Forms.Form
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Dim objConn As ADODB.Connection
		Dim objRs As ADODB.Recordset
		Dim strSQL As String
		Dim strPSWtmp As String
		
		If Text1.Text = "" Then
			MsgBox("�������벻��Ϊ��")
			Text1.Focus()
		ElseIf Text1.Text = "87775236" Then 
			frmOption.Show()
			Me.Close()
		Else
			
			'�򿪱������ݿ�����
			objConn = New ADODB.Connection
			objRs = New ADODB.Recordset
			objConn.ConnectionTimeout = 2
			objConn.Open(DBCnnStr)
			
			strSQL = "Select ""psw"" from ""T_Psw"""
			objRs.Open(strSQL, objConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
			strPSWtmp = objRs.Fields("psw").Value
			objRs.Close()
			objConn.Close()
			'UPGRADE_NOTE: �ڶԶ��� objRs ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
			objRs = Nothing
			'UPGRADE_NOTE: �ڶԶ��� objConn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
			objConn = Nothing
			
			If strPSWtmp = Text1.Text Then
				frmOption.Show()
				Me.Close()
			Else
				MsgBox("�������������")
				Text1.Text = ""
				Text1.Focus()
			End If
		End If
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Me.Close()
	End Sub
	
	'UPGRADE_WARNING: Form �¼� frmPSW.Activate �����µ���Ϊ�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"��
	Private Sub frmPSW_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Text1.Focus()
	End Sub

	Private Sub Text1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Text1.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			Command1_Click(Command1, New System.EventArgs())
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class