Option Strict Off
Option Explicit On
Friend Class frmHistory
	Inherits System.Windows.Forms.Form
	Dim ofy As CFY
	Dim SelectMember As String
	Dim nowPage As Integer
	Dim rs As ADODB.Recordset
	
	
	
	'UPGRADE_WARNING: ��ʼ������ʱ���ܼ����¼� Combo1.SelectedIndexChanged�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"��
	Private Sub Combo1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo1.SelectedIndexChanged
		Dim SqlStr As String
		nowPage = CInt(Me.Combo1.Text)
		ofy.PageNum = nowPage
		ofy.getRecordSet(rs)
		SqlStr = ofy.SelectSqlStr
		showDataInMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, """T_Result""", SqlStr)
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Dim WhereMenber As String
		Dim SqlStr As String
		If txtVIN.Text <> "" Then
			WhereMenber = " and ""VIN"" like '%" & txtVIN.Text & "%' "
		End If
		WhereMenber = WhereMenber & " and  ""TestTime"">='" & Me.dtpLow.value & "' and ""TestTime""<='" & Me.dtpHigh.value & "'"
		SelectMember = " ""ID"", ""VIN"",""VIS"",""ID020"" as ""��ǰ��ID"",""Mdl020"" as ""��ǰ��ģʽ"",""Pre020"" as ""��ǰ��ѹ��"",""Temp020"" as ""��ǰ���¶�"",""Battery020"" as ""��ǰ�ֵ��"",""AcSpeed020"" as ""��ǰ�ּ��ٶ�"" ,""ID021"" as ""�Һ���ID"",""Mdl021"" as ""�Һ���ģʽ"",""Pre021"" as ""�Һ���ѹ��"",""Temp021"" as ""�Һ����¶�"",""Battery021"" as ""�Һ��ֵ��"",""AcSpeed021"" as ""�Һ��ּ��ٶ�"" ,""ID022"" as ""��ǰ��ID"",""Mdl022"" as ""��ǰ��ģʽ"",""Pre022"" as ""��ǰ��ѹ��"",""Temp022"" as ""��ǰ���¶�"",""Battery022"" as ""��ǰ�ֵ��"",""AcSpeed022"" as ""��ǰ�ּ��ٶ�"" ,""ID023"" as ""�����ID"" ,""Mdl023"" as ""�����ģʽ"",""Pre023"" as ""�����ѹ��"",""Temp023"" as ""������¶�"",""Battery023"" as ""����ֵ��"",""AcSpeed023"" as ""����ּ��ٶ�"" ,""TestTime"" as ""����ʱ��"",""WriteInTime"" as ""д��ʱ��"" "
		
		SqlStr = "select " & SelectMember & " from ""T_Result"" where 1=1 " & WhereMenber
		
		exportExcel(SqlStr)
	End Sub
	
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		Me.Close()
	End Sub
	
	Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
		On Error GoTo select_ERR
		Dim WhereMenber As String
		Dim SqlStr As String
		If txtVIN.Text <> "" Then
			WhereMenber = " and ""VIN"" like '%" & txtVIN.Text & "%' "
		End If
		WhereMenber = WhereMenber & " and  ""TestTime"">='" & Me.dtpLow.value & "' and ""TestTime""<='" & Me.dtpHigh.value & "'"
		
		
		
		ofy = New CFY
		ofy.ConnectionString = DBCnnStr
		
		SelectMember = " ""ID"", ""VIN"",""VIS"",""ID020"" as ""��ǰ��ID"",""Mdl020"" as ""��ǰ��ģʽ"",""Pre020"" as ""��ǰ��ѹ��"",""Temp020"" as ""��ǰ���¶�"",""Battery020"" as ""��ǰ�ֵ��"",""AcSpeed020"" as ""��ǰ�ּ��ٶ�"" ,""ID021"" as ""�Һ���ID"",""Mdl021"" as ""�Һ���ģʽ"",""Pre021"" as ""�Һ���ѹ��"",""Temp021"" as ""�Һ����¶�"",""Battery021"" as ""�Һ��ֵ��"",""AcSpeed021"" as ""�Һ��ּ��ٶ�"" ,""ID022"" as ""��ǰ��ID"",""Mdl022"" as ""��ǰ��ģʽ"",""Pre022"" as ""��ǰ��ѹ��"",""Temp022"" as ""��ǰ���¶�"",""Battery022"" as ""��ǰ�ֵ��"",""AcSpeed022"" as ""��ǰ�ּ��ٶ�"" ,""ID023"" as ""�����ID"" ,""Mdl023"" as ""�����ģʽ"",""Pre023"" as ""�����ѹ��"",""Temp023"" as ""������¶�"",""Battery023"" as ""����ֵ��"",""AcSpeed023"" as ""����ּ��ٶ�"" ,""TestTime"" as ""����ʱ��"",""WriteInTime"" as ""д��ʱ��"" "
		ofy.tableName = " ""T_Result"" "
		
		nowPage = 1
		ofy.WhereMenber = WhereMenber
		ofy.KeyField = " ""ID"" "
		ofy.PageNum = nowPage
		ofy.SelectMember = SelectMember
		ofy.getRecordSet(rs)
		SqlStr = ofy.SelectSqlStr
		showDataInMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, """T_Result""", SqlStr)
		nowPage = 1
		loadCombo()
		Exit Sub
		
select_ERR: 
		MsgBox(Err.Description)
	End Sub
	
	
	
	
	
	
	
	Private Sub frmHistory_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim WhereMenber As String
		Dim SqlStr As String
		dtpLow.value = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -7, Today)
		dtpHigh.value = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, Today)

		If txtVIN.Text <> "" Then
			WhereMenber = " and ""VIN"" like '" & txtVIN.Text & "' "
		End If
		WhereMenber = WhereMenber & " and  ""TestTime"">='" & Me.dtpLow.value & "' and ""TestTime""<='" & Me.dtpHigh.value & "'"

		ofy = New CFY
		ofy.ConnectionString = DBCnnStr
		
		SelectMember = " ""ID"", ""VIN"",""VIS"",""ID020"" as ""��ǰ��ID"",""Mdl020"" as ""��ǰ��ģʽ"",""Pre020"" as ""��ǰ��ѹ��"",""Temp020"" as ""��ǰ���¶�"",""Battery020"" as ""��ǰ�ֵ��"",""AcSpeed020"" as ""��ǰ�ּ��ٶ�"" ,""ID021"" as ""�Һ���ID"",""Mdl021"" as ""�Һ���ģʽ"",""Pre021"" as ""�Һ���ѹ��"",""Temp021"" as ""�Һ����¶�"",""Battery021"" as ""�Һ��ֵ��"",""AcSpeed021"" as ""�Һ��ּ��ٶ�"" ,""ID022"" as ""��ǰ��ID"",""Mdl022"" as ""��ǰ��ģʽ"",""Pre022"" as ""��ǰ��ѹ��"",""Temp022"" as ""��ǰ���¶�"",""Battery022"" as ""��ǰ�ֵ��"",""AcSpeed022"" as ""��ǰ�ּ��ٶ�"" ,""ID023"" as ""�����ID"" ,""Mdl023"" as ""�����ģʽ"",""Pre023"" as ""�����ѹ��"",""Temp023"" as ""������¶�"",""Battery023"" as ""����ֵ��"",""AcSpeed023"" as ""����ּ��ٶ�"" ,""TestTime"" as ""����ʱ��"",""WriteInTime"" as ""д��ʱ��"" "
		ofy.tableName = " ""T_Result"" "
		
		nowPage = 1
		ofy.WhereMenber = WhereMenber
		ofy.KeyField = " ""ID"" "
		ofy.PageNum = nowPage
		ofy.SelectMember = SelectMember
		ofy.getRecordSet(rs)
		SqlStr = ofy.SelectSqlStr
		showDataInMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, """T_Result""", SqlStr)
		nowPage = 1
		loadCombo()

		Exit Sub
	End Sub
	'******************************************************************************
	'** �� �� ����showDataInMSFlexGrid
	'** ��    �룺
	'** ��    ����
	'** ������������ʾ����
	'** ȫ�ֱ�����
	'** ��    �ߣ�yangshuai
	'** ��    �䣺shuaigoplay@live.cn
	'** ��    �ڣ�2009-2-27
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	
	Public Sub showDataInMSFlexGrid(ByRef msFG As AxMSFlexGridLib.AxMSFlexGrid, ByRef CnnStr As String, ByRef tableName As String, ByRef sql As String)
		'On Error GoTo Err_ShowGrid
		msFG.Clear()
		If sql = "" Then
			Exit Sub
		End If
		Dim cnn As New ADODB.Connection
		Dim rs As New ADODB.Recordset
		Dim rsTmp As New ADODB.Recordset
		Dim i, J As Short
		
		cnn.Open(CnnStr)
		rs.Open(sql, cnn, 1, 3)
		
		With msFG
			.Visible = True
			.cols = rs.Fields.Count
			.Rows = 55
			.FillStyle = 1
			'.CellAlignment = flexAlignLeftCenter
			For i = 0 To rs.Fields.Count - 1
				.set_TextMatrix(0, i, rs.Fields(i).Name)
			Next 
			J = 1
			Do While Not rs.EOF
				For i = 0 To rs.Fields.Count - 1
					'UPGRADE_WARNING: ��⵽ʹ���� Null/IsNull()�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"��
					If IsDbNull(rs.Fields(i).Value) Then
						.set_TextMatrix(J, i, "")
					Else
						.set_TextMatrix(J, i, rs.Fields(i).Value)
						
					End If
				Next 
				rs.MoveNext()
				J = J + 1
			Loop 
		End With
		Call setColWidth(msFG, rs.Fields.Count) '�����п�������̿��Ը����Լ���Ҫ����
		rs.Close()
		'UPGRADE_NOTE: �ڶԶ��� rs ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		rs = Nothing
		cnn.Close()
		
		Exit Sub
Err_ShowGrid: 
		MsgBox("��ʾ���ݳ�����������Ϣ��" & Err.Description)
	End Sub
	Private Sub setColWidth(ByRef msFG As AxMSFlexGridLib.AxMSFlexGrid, ByRef cols As Short)
		Dim i As Short
		With msFG
			.set_ColWidth(0, 0)
			.set_ColWidth(1, 2000)
			For i = 2 To cols - 2 'Ϊÿ���е��н�������
				.set_ColWidth(i, 1150) '�еĿ���,�Ժ��Լ�����
			Next 
			.set_ColWidth(i - 1, 1600)
			.set_ColWidth(i, 1600)
		End With
	End Sub
	
	
	
	
	
	
	
	
	Private Sub Label4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label4.Click
		Dim SqlStr As String
		If nowPage < ofy.PageCount Then
			nowPage = nowPage + 1
			ofy.PageNum = nowPage
			ofy.getRecordSet(rs)
			SqlStr = ofy.SelectSqlStr
			showDataInMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, """T_Result""", SqlStr)
		Else
			MsgBox("�Ѿ���βҳ��")
		End If
		Dim i As Integer
		loadCombo()
		Exit Sub
	End Sub
	
	Private Sub Label5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Label5.Click
		Dim SqlStr As String
		If nowPage > 1 Then
			nowPage = nowPage - 1
			ofy.PageNum = nowPage
			ofy.getRecordSet(rs)
			SqlStr = ofy.SelectSqlStr
			showDataInMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, """T_Result""", SqlStr)
		Else
			MsgBox("�Ѿ�����ҳ��")
		End If
		loadCombo()
		Exit Sub
	End Sub
	
	Public Sub loadCombo()
		Me.Combo1.Items.Clear()
		Dim i As Integer
		For i = 1 To ofy.PageCount
			Me.Combo1.Items.Insert(i - 1, CStr(i))
		Next 
		If Me.Combo1.Items.Count > 0 Then
			Me.Combo1.SelectedIndex = nowPage - 1
		End If
	End Sub
End Class