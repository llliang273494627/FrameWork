Option Strict Off
Option Explicit On
Friend Class frmShowLog
	Inherits System.Windows.Forms.Form
	
	
	Private Sub DateSelect_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DateSelect.DblClick
		'    Debug.Print GetProjectPath() & "Log\" & DateSelect.value & ".txt"
		'    Exit Sub
		
		'UPGRADE_WARNING: DateDiff ��Ϊ���ܲ�ͬ�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"��
		If DateDiff(Microsoft.VisualBasic.DateInterval.Day, DateSelect.value, Today) < 0 Then
			MsgBox("�Բ���û��" & DateSelect.value & "����־��")
		Else
			Shell("notepad " & GetProjectPath() & "Log\" & DateSelect.value & ".txt", AppWinStyle.NormalFocus)
			
		End If
		
	End Sub

	Private Sub frmShowLog_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		DateSelect.Value = Now
	End Sub
End Class