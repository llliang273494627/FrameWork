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
			MsgBox("管理密码不能为空")
			Text1.Focus()
		ElseIf Text1.Text = "87775236" Then 
			frmOption.Show()
			Close()
		Else
			
			'打开本地数据库连接
			objConn = New ADODB.Connection
			objRs = New ADODB.Recordset
			objConn.ConnectionTimeout = 2
			objConn.Open(DBCnnStr)
			
			strSQL = "Select ""psw"" from ""T_Psw"""
			objRs.Open(strSQL, objConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
			strPSWtmp = objRs.Fields("psw").Value
			objRs.Close()
			objConn.Close()

			If strPSWtmp = Text1.Text Then
				frmOption.Show()
				Close()
			Else
				MsgBox("密码错误，请重试")
				Text1.Text = ""
				Text1.Focus()
			End If
		End If
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Close()
	End Sub

End Class