Option Strict Off
Option Explicit On
Friend Class frmQueueInfo
	Inherits System.Windows.Forms.Form
	Dim ofy As CFY
	Dim SelectMember As String
	Dim nowPage As Integer
	Dim rs As ADODB.Recordset
	
	'UPGRADE_WARNING: 初始化窗体时可能激发事件 Combo1.SelectedIndexChanged。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"”
	Private Sub Combo1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo1.SelectedIndexChanged
		Dim SqlStr As String
		nowPage = CInt(Me.Combo1.Text)
		ofy.PageNum = nowPage
		ofy.getRecordSet(rs)
		SqlStr = ofy.SelectSqlStr
		showDataInMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, "vinlist", SqlStr)
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Dim WhereMenber As String
		Dim SqlStr As String
		If txtVIN.Text <> "" Then
			WhereMenber = " and vin like '%" & txtVIN.Text & "%' "
		End If
		WhereMenber = WhereMenber & " and  pa_off_time>='" & Me.dtpLow.value & "' and pa_off_time<='" & Me.dtpHigh.value & "'"
		SelectMember = " id as ""编号"", vin as ""VIN码"",mtoc as ""MTOC码"",pa_off_seq as ""流水号"",pa_off_time as ""涂装下线时间"",createtime as ""下载时间"" "
		
		SqlStr = "select " & SelectMember & " from vinlist where 1=1 " & WhereMenber
		
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
			WhereMenber = " and vin like '%" & txtVIN.Text & "%' "
		End If
		WhereMenber = WhereMenber & " and  pa_off_time>='" & Me.dtpLow.value & "' and pa_off_time<='" & Me.dtpHigh.value & "'"
		
		
		
		ofy = New CFY
		ofy.ConnectionString = DBCnnStr
		
		SelectMember = " id, vin as ""VIN码"",mtoc as ""MTOC码"",pa_off_seq as ""流水号"",pa_off_time as ""涂装下线时间"",createtime as ""下载时间"" "
		ofy.tableName = " vinlist "
		
		nowPage = 1
		ofy.WhereMenber = WhereMenber
		ofy.KeyField = " id "
		ofy.PageNum = nowPage
		ofy.SelectMember = SelectMember
		ofy.getRecordSet(rs)
		SqlStr = ofy.SelectSqlStr
		showDataInMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, "vinlist", SqlStr)
		nowPage = 1
		loadCombo()
		Exit Sub
		
select_ERR: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub frmQueueInfo_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim WhereMenber As String
		Dim SqlStr As String
		dtpLow.value = DateAdd(Microsoft.VisualBasic.DateInterval.Day, -7, Today)
		dtpHigh.value = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, Today)
		
		
		
		If txtVIN.Text <> "" Then
			WhereMenber = " and vin like '" & txtVIN.Text & "' "
		End If
		WhereMenber = WhereMenber & " and  pa_off_time>='" & Me.dtpLow.value & "' and pa_off_time<='" & Me.dtpHigh.value & "'"
		
		
		
		ofy = New CFY
		ofy.ConnectionString = DBCnnStr
		
		SelectMember = " id, vin as ""VIN码"",mtoc as ""MTOC码"",pa_off_seq as ""流水号"",pa_off_time as ""涂装下线时间"",createtime as ""下载时间"" "
		ofy.tableName = " vinlist "
		
		nowPage = 1
		ofy.WhereMenber = WhereMenber
		ofy.KeyField = " id "
		ofy.PageNum = nowPage
		ofy.SelectMember = SelectMember
		ofy.getRecordSet(rs)
		SqlStr = ofy.SelectSqlStr
		showDataInMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, "vinlist", SqlStr)
		nowPage = 1
		loadCombo()

		Exit Sub
	End Sub
	'******************************************************************************
	'** 函 数 名：showDataInMSFlexGrid
	'** 输    入：
	'** 输    出：
	'** 功能描述：显示表格
	'** 全局变量：
	'** 作    者：yangshuai
	'** 邮    箱：shuaigoplay@live.cn
	'** 日    期：2009-2-27
	'** 修 改 者：
	'** 日    期：
	'** 版    本：1.0
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
					'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
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
		Call setColWidth(msFG, rs.Fields.Count) '设置列宽这个过程可以根据自己需要更改
		rs.Close()
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		cnn.Close()
		
		Exit Sub
Err_ShowGrid: 
		MsgBox("显示数据出错！错误信息：" & Err.Description)
	End Sub
	Private Sub setColWidth(ByRef msFG As AxMSFlexGridLib.AxMSFlexGrid, ByRef cols As Short)
		Dim i As Short
		With msFG
			.set_ColWidth(0, 0)
			.set_ColWidth(1, 2000)
			For i = 2 To cols - 2 '为每行中的列进行设置
				.set_ColWidth(i, 1000) '列的宽度,以后自己估算
			Next 
			.set_ColWidth(i - 1, 1800)
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
			showDataInMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, "vinlist", SqlStr)
		Else
			MsgBox("已经是尾页！")
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
			showDataInMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, "vinlist", SqlStr)
		Else
			MsgBox("已经是首页！")
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