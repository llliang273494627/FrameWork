Option Strict Off
Option Explicit On
Friend Class frmDateZone
	Inherits System.Windows.Forms.Form
	'******************************************************************************
	'** �ļ�����frmDateZone.frm
	'** ��  Ȩ��CopyRight (c) 2008-2010 �人��������ϵͳ���޹�˾
	'** �����ˣ�yangshuai
	'** ��  �䣺shuaigoplay@live.cn
	'** ��  �ڣ�2009-2-27
	'** �޸��ˣ�
	'** ��  �ڣ�
	'** ��  ����ʱ��ѡ��Ի���
	'** ��  ����1.0
	'******************************************************************************
	
	'******************************************************************************
	'** �� �� ����cmdCancel
	'** ��    �룺
	'** ��    ����
	'** ����������ȡ����ť�¼���Ӧ
	'** ȫ�ֱ�����
	'** ��    �ߣ�yangshuai
	'** ��    �䣺shuaigoplay@live.cn
	'** ��    �ڣ�2009-2-27
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	
	'******************************************************************************
	'** �� �� ����cmdSaveAs_Click
	'** ��    �룺
	'** ��    ����
	'** ����������������ť�¼���Ӧ
	'** ȫ�ֱ�����
	'** ��    �ߣ�yangshuai
	'** ��    �䣺shuaigoplay@live.cn
	'** ��    �ڣ�2009-2-27
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
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
		
		'sqlText = "select ""VIN"",""VIS"",""ID020"" as ""��ǰ��ID"",""Mdl020"" as ""��ǰ��ģʽ"",""Pre020"" as ""��ǰ��ѹ��"",""Temp020"" as ""��ǰ���¶�"",""Battery020"" as ""��ǰ�ֵ��"",""AcSpeed020"" as ""��ǰ�ּ��ٶ�"" ,""ID021"" as ""�Һ���ID"",""Mdl021"" as ""�Һ���ģʽ"",""Pre021"" as ""�Һ���ѹ��"",""Temp021"" as ""�Һ����¶�"",""Battery021"" as ""�Һ��ֵ��"",""AcSpeed021"" as ""�Һ��ּ��ٶ�"" ,""ID022"" as ""��ǰ��ID"",""Mdl022"" as ""��ǰ��ģʽ"",""Pre022"" as ""��ǰ��ѹ��"",""Temp022"" as ""��ǰ���¶�"",""Battery022"" as ""��ǰ�ֵ��"",""AcSpeed022"" as ""��ǰ�ּ��ٶ�"" ,""ID023"" as ""�����ID"" ,""Mdl023"" as ""�����ģʽ"",""Pre023"" as ""�����ѹ��"",""Temp023"" as ""������¶�"",""Battery023"" as ""����ֵ��"",""AcSpeed023"" as ""����ּ��ٶ�"" ,""TestTime"" as ""����ʱ��"",""WriteInTime"" as ""д��ʱ��"" from " _
		'& " ""T_Result"" where   ""TestTime"">='" & lowDate & "' and ""TestTime""<='" & highDate & "'"
		'UPGRADE_WARNING: δ�ܽ������� highDate ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		'UPGRADE_WARNING: δ�ܽ������� lowDate ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		sqlText = "select ""ID"", ""VIN"" as ""VID"",""VIS"",""CarType"" as ""����"",""ID020"" as ""��ǰ��ID"",""ID021"" as ""�Һ���ID"",""ID022"" as ""��ǰ��ID"",""ID023"" as ""�����ID"" ,""TestTime"" as ""����ʱ��"",""TestState"" as ""״̬��15�ϸ�""  from " & " ""T_Result"" where   ""TestTime"">='" & lowDate & "' and ""TestTime""<='" & highDate & "'"
		
		'��ϵ�����ѯ��䣬���õ�������
		
		exportExcel(sqlText)
		
		
	End Sub
	
	
	
	'******************************************************************************
	'** �� �� ����Form_Load
	'** ��    �룺
	'** ��    ����
	'** �����������������ʱ����Ӧ
	'** ȫ�ֱ�����
	'** ��    �ߣ�yangshuai
	'** ��    �䣺shuaigoplay@live.cn
	'** ��    �ڣ�2009-2-27
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	Private Sub frmDateZone_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'�ؼ����XP��
		WindowsXPC1.InitSubClassing()
		
		'����ؼ�����
		dtpLow.value = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -7, Today)
		dtpHigh.value = Today
		
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
	End Sub
End Class