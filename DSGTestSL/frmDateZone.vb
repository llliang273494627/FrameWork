Option Strict Off
Option Explicit On
Friend Class frmDateZone
	Inherits System.Windows.Forms.Form

	'ȡ����ť�¼���Ӧ
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub

	'������ť�¼���Ӧ
	Private Sub cmdSaveAs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSaveAs.Click
		Dim sqlText As String
		Dim lowDate As Object
		Dim highDate As Object
		
		'UPGRADE_WARNING: δ�ܽ������� lowDate ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		lowDate = CDate(Me.dtpLow.value)
		'UPGRADE_WARNING: δ�ܽ������� highDate ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		highDate = CDate(Me.dtpHigh.value)
		
		'UPGRADE_WARNING: δ�ܽ������� highDate ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		'UPGRADE_WARNING: δ�ܽ������� lowDate ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		If lowDate > highDate Then
			MsgBox(" ")
			Exit Sub
		End If
		
		'UPGRADE_WARNING: δ�ܽ������� highDate ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		'UPGRADE_WARNING: δ�ܽ������� lowDate ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		sqlText = "select ""VIN"",""VIS"",""ID020"" as ""��ǰ��ID"",""Mdl020"" as ""��ǰ��ģʽ"",""Pre020"" as ""��ǰ��ѹ��"",""Temp020"" as ""��ǰ���¶�"",""Battery020"" as ""��ǰ�ֵ��"",""AcSpeed020"" as ""��ǰ�ּ��ٶ�"" ,""ID021"" as ""�Һ���ID"",""Mdl021"" as ""�Һ���ģʽ"",""Pre021"" as ""�Һ���ѹ��"",""Temp021"" as ""�Һ����¶�"",""Battery021"" as ""�Һ��ֵ��"",""AcSpeed021"" as ""�Һ��ּ��ٶ�"" ,""ID022"" as ""��ǰ��ID"",""Mdl022"" as ""��ǰ��ģʽ"",""Pre022"" as ""��ǰ��ѹ��"",""Temp022"" as ""��ǰ���¶�"",""Battery022"" as ""��ǰ�ֵ��"",""AcSpeed022"" as ""��ǰ�ּ��ٶ�"" ,""ID023"" as ""�����ID"" ,""Mdl023"" as ""�����ģʽ"",""Pre023"" as ""�����ѹ��"",""Temp023"" as ""������¶�"",""Battery023"" as ""����ֵ��"",""AcSpeed023"" as ""����ּ��ٶ�"" ,""TestTime"" as ""����ʱ��"",""WriteInTime"" as ""д��ʱ��"" from " & " ""T_Result"" where   ""TestTime"">='" & lowDate & "' and ""TestTime""<='" & highDate & "'"

		'��ϵ�����ѯ��䣬���õ�������

		exportExcel(sqlText)
	End Sub

	'�������ʱ����Ӧ
	Private Sub frmDateZone_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'����ؼ�����
		dtpLow.Value = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -7, Today)
		dtpHigh.Value = Today
	End Sub
End Class