Option Strict Off
Option Explicit On
Friend Class frmOption
	Inherits System.Windows.Forms.Form
	'******************************************************************************
	'** 文件名：frmOption.frm
	'** 版  权：CopyRight (c) 2008-2010 武汉华信数据系统有限公司
	'** 创建人：yangshuai
	'** 邮  箱：shuaigoplay@live.cn
	'** 日  期：2009-2-27
	'** 修改人：
	'** 日  期：
	'** 描  述：系统设置
	'** 版  本：1.0
	'******************************************************************************
	
	Dim sqlCtrl As String
	Dim sqlRun As String
	Dim sqlTpmsCode As String
	Dim sqlMaterialCode As String
	
	
	'修改TPMS特征码起始位置信息
	Private Sub btMTOCModi_Click()
		'On Error GoTo Err
		'    If txtMtocStartIndex.text = "" Then
		'        MsgBox "TPMS特征码起始位置不能为空!"
		'        txtMtocStartIndex.SetFocus
		'        Exit Sub
		'    End If
		'
		'    If txtMTOCLen.text = "" Then
		'        MsgBox "TPMS特征码长不能为空!"
		'        txtMTOCLen.SetFocus
		'        Exit Sub
		'    End If
		'
		'    Call updateRunParam(txtMtocStartIndex.text, "TPMSCode", "MTOCStartIndex")
		'    Call updateRunParam(txtMTOCLen.text, "TPMSCode", "TPMSCodeLen")
		'
		'    mTOCStartIndex = txtMtocStartIndex.text
		'    tPMSCodeLen = txtMTOCLen.text
		'
		'    MsgBox "TPMS特征码起始位置信息修改成功!"
		'
		'    Exit Sub
		'Err:
		'    LogWritter "修改TPMS特征码起始位置信息时失败，内容:" & Err.Description
		'    MsgBox "TPMS特征码起始位置信息修改失败!" & Err.Description
	End Sub
	'添加车型编码规则
	Private Sub bt_MTCodeAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bt_MTCodeAdd.Click
		On Error GoTo Err_Renamed
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		If StrConv(txt_CodeStartIndex.Text, VbStrConv.UpperCase) = "" Then
			MsgBox("起始位置不得为空")
			Exit Sub
		ElseIf StrConv(txt_CodeLen.Text, VbStrConv.UpperCase) = "" Then 
			MsgBox("长度不得为空")
			Exit Sub
		ElseIf StrConv(txt_MatchLetter.Text, VbStrConv.UpperCase) = "" Then 
			MsgBox("字母不得为空")
			Exit Sub
		ElseIf StrConv(txt_CarType.Text, VbStrConv.UpperCase) = "" Then 
			MsgBox("车型不得为空")
			Exit Sub
		ElseIf StrConv(txt_ifTPMS.Text, VbStrConv.UpperCase) = "" Then 
			MsgBox("胎压不得为空")
			Exit Sub
		ElseIf StrConv(txt_ifTPMS.Text, VbStrConv.UpperCase) <> "0" And StrConv(txt_ifTPMS.Text, VbStrConv.UpperCase) <> "1" Then 
			MsgBox("胎压填写错误")
			Exit Sub
		End If
		Dim xxx As String
		xxx = "select ""CarType"" from ""cartype_tpms"" where Upper(""CodeStartIndex"")='" & StrConv(txt_CodeStartIndex.Text, VbStrConv.UpperCase) & "' and Upper(""CodeLen"")='" & StrConv(txt_CodeLen.Text, VbStrConv.UpperCase) & "' and Upper(""MatchLetter"")='" & StrConv(txt_MatchLetter.Text, VbStrConv.UpperCase) & "'"
		rs = cnn.Execute("select ""CarType"" from ""cartype_tpms"" where Upper(""CodeStartIndex"")='" & StrConv(txt_CodeStartIndex.Text, VbStrConv.UpperCase) & "' and Upper(""CodeLen"")='" & StrConv(txt_CodeLen.Text, VbStrConv.UpperCase) & "' and Upper(""MatchLetter"")='" & StrConv(txt_MatchLetter.Text, VbStrConv.UpperCase) & "'")
		If Not rs.EOF Then
			MsgBox("该规则已经匹配!")
			Exit Sub
		End If
		xxx = "insert into ""cartype_tpms"" (""CodeStartIndex"",""CodeLen"",""MatchLetter"",""CarType"",""ifTPMS"") values ('" & txt_CodeStartIndex.Text & "','" & txt_CodeLen.Text & "','" & txt_MatchLetter.Text & "','" & txt_CarType.Text & "','" & txt_ifTPMS.Text & "')"
		cnn.Execute("insert into ""cartype_tpms"" (""CodeStartIndex"",""CodeLen"",""MatchLetter"",""CarType"",""ifTPMS"") values ('" & txt_CodeStartIndex.Text & "','" & txt_CodeLen.Text & "','" & txt_MatchLetter.Text & "','" & txt_CarType.Text & "','" & txt_ifTPMS.Text & "')")
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
		
		showMSFlexGrid((Me.MSFlexGrid4), DBCnnStr, sqlMaterialCode)
		MsgBox("规则新增成功!")
		Exit Sub
Err_Renamed: 
		LogWritter("新增规则时失败，内容:" & Err.Description)
		MsgBox("规则新增失败!" & Err.Description)
	End Sub
	'取消
	Private Sub bt_MTCodeCancle_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bt_MTCodeCancle.Click
		Me.Close()
	End Sub
	'删除车型编码规则
	Private Sub bt_MTCodeDel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bt_MTCodeDel.Click
		On Error GoTo Err_Renamed
		Dim msgR As Short
		msgR = MsgBox("是否删除该车型配置，序号：" & txt_CarType.Text & "？", MsgBoxStyle.YesNo, "系统提示")
		If msgR = 7 Then Exit Sub
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		cnn.Execute("delete from ""cartype_tpms"" where ""ID""=" & txt_MTID.Text & "")
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
		showMSFlexGrid((Me.MSFlexGrid4), DBCnnStr, sqlMaterialCode)
		MsgBox("车型编码规则删除成功!")
		txt_MTID.Text = ""
		txt_CodeStartIndex.Text = ""
		txt_CodeLen.Text = ""
		txt_MatchLetter.Text = ""
		txt_CarType.Text = ""
		txt_ifTPMS.Text = ""
		Exit Sub
Err_Renamed: 
		LogWritter("删除车型编码规则时失败，内容:" & Err.Description)
		MsgBox("车型编码规则删除失败!" & Err.Description)
	End Sub
	'修改车型编码规则
	Private Sub bt_MTCodeModi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bt_MTCodeModi.Click
		On Error GoTo Err_Renamed
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		If StrConv(txt_ifTPMS.Text, VbStrConv.UpperCase) <> "0" And StrConv(txt_ifTPMS.Text, VbStrConv.UpperCase) <> "1" Then
			MsgBox("胎压填写错误")
			Exit Sub
		End If
		cnn.Open(DBCnnStr)
		
		cnn.Execute("update ""cartype_tpms"" set ""CodeStartIndex""='" & txt_CodeStartIndex.Text & "',""CodeLen""='" & txt_CodeLen.Text & "',""MatchLetter""='" & txt_MatchLetter.Text & "',""CarType""='" & txt_CarType.Text & "',""ifTPMS""='" & txt_ifTPMS.Text & "' where ""ID""=" & txt_MTID.Text & "")
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
		
		showMSFlexGrid((Me.MSFlexGrid4), DBCnnStr, sqlMaterialCode)
		MsgBox("物料号规则修改成功!")
		Exit Sub
Err_Renamed: 
		LogWritter("修改物料号规则时失败，内容:" & Err.Description)
		MsgBox("物料号规则修改失败!" & Err.Description)
	End Sub
	
	'新增程序号
	Private Sub btTPMSAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btTPMSAdd.Click
		On Error GoTo Err_Renamed
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		If StrConv(txtCarType.Text, VbStrConv.UpperCase) = "" Then
			MsgBox("车型不得为空")
			Exit Sub
		ElseIf StrConv(txtCarType.Text, VbStrConv.UpperCase) = "" Then 
			MsgBox("程序号不得为空")
			Exit Sub
		End If
		Dim xxx As String
		xxx = "select ""CarType"" from ""cartype_prono"" where Upper(""CarType"")='" & StrConv(txtCarType.Text, VbStrConv.UpperCase) & "'"
		rs = cnn.Execute("select ""CarType"" from ""cartype_prono"" where Upper(""CarType"")='" & StrConv(txtCarType.Text, VbStrConv.UpperCase) & "'")
		If Not rs.EOF Then
			MsgBox("该车型已经配置程序号!")
			Exit Sub
		End If
		xxx = "insert into ""cartype_prono"" (""CarType"",""ProNum"") values ('" & txtCarType.Text & "','" & txtProNum.Text & "')"
		cnn.Execute("insert into ""cartype_prono"" (""CarType"",""ProNum"") values ('" & txtCarType.Text & "','" & txtProNum.Text & "')")
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
		
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		MsgBox("程序号新增成功!")
		Exit Sub
Err_Renamed: 
		LogWritter("新增程序号时失败，内容:" & Err.Description)
		MsgBox("程序号新增失败!" & Err.Description)
	End Sub
	
	Private Sub btTPMSCancle_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btTPMSCancle.Click
		Me.Close()
	End Sub
	'删除程序号
	Private Sub btTPMSDel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btTPMSDel.Click
		On Error GoTo Err_Renamed
		Dim msgR As Short
		msgR = MsgBox("是否删除该车型的程序号" & txtCarType.Text & "？", MsgBoxStyle.YesNo, "系统提示")
		If msgR = 7 Then Exit Sub
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		cnn.Execute("delete from ""cartype_prono"" where ""ID""=" & txtTPMSID.Text & "")
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		MsgBox("程序号删除成功!")
		txtTPMSID.Text = ""
		txtCarType.Text = ""
		txtProNum.Text = ""
		Exit Sub
Err_Renamed: 
		LogWritter("删除程序号时失败，内容:" & Err.Description)
		MsgBox("程序号删除失败!" & Err.Description)
	End Sub
	
	'修改程序号
	Private Sub btTPMSModi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btTPMSModi.Click
		On Error GoTo Err_Renamed
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		
		'    Set rs = cnn.Execute("select ""CarType"" from ""cartype_prono"" where Upper(""CarType"")='" & StrConv(txtCarType.text, vbUpperCase) & "'")
		'    If Not rs.EOF Then
		'        MsgBox "该车型程序号已存在!"
		'        Exit Sub
		'    End If
		
		cnn.Execute("update ""cartype_prono"" set ""CarType""='" & txtCarType.Text & "',""ProNum""='" & txtProNum.Text & "' where ""ID""=" & txtTPMSID.Text & "")
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
		
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		MsgBox("程序号修改成功!")
		Exit Sub
Err_Renamed: 
		LogWritter("修改程序号时失败，内容:" & Err.Description)
		MsgBox("程序号修改失败!" & Err.Description)
	End Sub
	
	'是否检验排产队列
	'UPGRADE_WARNING: 初始化窗体时可能激发事件 chkAllQueue.CheckStateChanged。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"”
	Private Sub chkAllQueue_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkAllQueue.CheckStateChanged
		If chkAllQueue.CheckState = System.Windows.Forms.CheckState.Checked Then
			isCheckAllQueue = True
			Call updateRunParam(CStr(1), "Queue", "CheckAllQueue")
		Else
			isCheckAllQueue = False
			Call updateRunParam(CStr(0), "Queue", "CheckAllQueue")
		End If
	End Sub
	
	'是否只打印诊断结果为NG的诊断单据
	Private Sub chkOnlyPrintNGWriteResult_Click()
		'    If chkOnlyPrintNGWriteResult.value = vbChecked Then
		'        isOnlyPrintNGWriteResult = True
		'        Call updateRunParam(1, "Print", "OnlyPrintNGWriteResult")
		'    Else
		'        isOnlyPrintNGWriteResult = False
		'        Call updateRunParam(0, "Print", "OnlyPrintNGWriteResult")
		'    End If
	End Sub
	
	'仅扫描VIN码
	'UPGRADE_WARNING: 初始化窗体时可能激发事件 chkOnlyScanVINCode.CheckStateChanged。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"”
	Private Sub chkOnlyScanVINCode_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkOnlyScanVINCode.CheckStateChanged
		If chkOnlyScanVINCode.CheckState = System.Windows.Forms.CheckState.Checked Then
			isOnlyScanVINCode = True
			Call updateRunParam(CStr(1), "Queue", "OnlyScanVINCode")
		Else
			isOnlyScanVINCode = False
			FrmMain.MTOCCode = "InitMTOCCode"
			Call updateRunParam(CStr(0), "Queue", "OnlyScanVINCode")
		End If
	End Sub
	'是否只打印NG的诊断流程，合格的流程不打印
	Private Sub chkPrintNGFlow_Click()
		'    If chkPrintNGFlow.value = vbChecked Then
		'        isOnlyPrintNGFlow = True
		'        Call updateRunParam(1, "Print", "OnlyPrintNGFlow")
		'    Else
		'        isOnlyPrintNGFlow = False
		'        Call updateRunParam(0, "Print", "OnlyPrintNGFlow")
		'    End If
	End Sub
	
	'修改加速度范围值
	Private Sub cmdAcSpeedSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAcSpeedSave.Click
		On Error GoTo Err_Renamed
		If txtAcSpeedMin.Text = "" Then
			MsgBox("传感器加速度最小值不能为空!")
			txtAcSpeedMin.Focus()
			Exit Sub
		End If
		
		If txtAcSpeedMax.Text = "" Then
			MsgBox("传感器加速度最大值不能为空!")
			txtAcSpeedMax.Focus()
			Exit Sub
		End If
		
		Call updateRunParam((txtAcSpeedMin.Text), "StandardValue", "AcSpeedMinValue")
		Call updateRunParam((txtAcSpeedMax.Text), "StandardValue", "AcSpeedMaxValue")
		
		acSpeedMinValue = txtAcSpeedMin.Text
		acSpeedMaxValue = txtAcSpeedMax.Text
		
		MsgBox("传感器加速度值范围修改成功!")
		
		Exit Sub
Err_Renamed: 
		LogWritter("修改传感器加速度值时失败，内容:" & Err.Description)
		MsgBox("传感器加速度值范围修改失败!" & Err.Description)
	End Sub
	'修改模式
	Private Sub cmdMdlSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMdlSave.Click
		If txtMdl.Text = "" Then
			MsgBox("传感器模式不能为空!")
			txtMdl.Focus()
			Exit Sub
		End If
		
		Call updateRunParam((txtMdl.Text), "StandardValue", "MdlValue")
		mdlValue = txtMdl.Text
	End Sub
	
	'修改压力范围值
	Private Sub cmdPreSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPreSave.Click
		On Error GoTo Err_Renamed
		If txtPreMin.Text = "" Then
			MsgBox("传感器压力最小值不能为空!")
			txtPreMin.Focus()
			Exit Sub
		End If
		
		If txtPreMax.Text = "" Then
			MsgBox("传感器压力最大值不能为空!")
			txtPreMax.Focus()
			Exit Sub
		End If
		
		Call updateRunParam((txtPreMin.Text), "StandardValue", "PreMinValue")
		Call updateRunParam((txtPreMax.Text), "StandardValue", "PreMaxValue")
		
		preMinValue = txtPreMin.Text
		preMaxValue = txtPreMax.Text
		
		MsgBox("传感器压力值范围修改成功!")
		
		Exit Sub
Err_Renamed: 
		LogWritter("修改传感器压力值时失败，内容:" & Err.Description)
		MsgBox("传感器压力值范围修改失败!" & Err.Description)
	End Sub
	'修改温度范围值
	Private Sub cmdTempSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTempSave.Click
		On Error GoTo Err_Renamed
		If txtTempMin.Text = "" Then
			MsgBox("传感器温度最小值不能为空!")
			txtTempMin.Focus()
			Exit Sub
		End If
		
		If txtTempMax.Text = "" Then
			MsgBox("传感器温度最大值不能为空!")
			txtTempMax.Focus()
			Exit Sub
		End If
		
		Call updateRunParam((txtTempMin.Text), "StandardValue", "TempMinValue")
		Call updateRunParam((txtTempMax.Text), "StandardValue", "TempMaxValue")
		
		tempMinValue = txtTempMin.Text
		tempMaxValue = txtTempMax.Text
		
		MsgBox("传感器温度值范围修改成功!")
		
		Exit Sub
Err_Renamed: 
		LogWritter("修改传感器温度值时失败，内容:" & Err.Description)
		MsgBox("传感器温度值范围修改失败!" & Err.Description)
	End Sub
	
	'UPGRADE_WARNING: 初始化窗体时可能激发事件 ComboCtrl.SelectedIndexChanged。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"”
	Private Sub ComboCtrl_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ComboCtrl.SelectedIndexChanged
		sqlCtrl = "select ""ID"" as ""编号"",""Group"" as ""组"",""Description"" as ""描述"",""Key"" as ""关键字"",""Value"" as ""值"" from ""T_CtrlParam"" where ""Group""='" & Me.ComboCtrl.Text & "'  order by ""ID"" "
		showMSFlexGrid((Me.MSFlexGrid2), DBCnnStr, sqlCtrl)
	End Sub
	
	
	'UPGRADE_WARNING: 初始化窗体时可能激发事件 ComboRun.SelectedIndexChanged。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"”
	Private Sub ComboRun_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ComboRun.SelectedIndexChanged
		sqlRun = "select ""ID"" as ""编号"",""Group"" as ""组"",""Description"" as ""描述"",""Key"" as ""关键字"",""Value"" as ""值"" from ""T_RunParam"" where ""Group""='" & Me.ComboRun.Text & "' order by ""ID""  "
		showMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, sqlRun)
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Me.Close()
	End Sub
	
	Private Sub Command10_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command10.Click
		frmQueueInfo.Show()
	End Sub
	
	Private Sub Command11_Click()
		On Error GoTo Err_Renamed
		Dim msgR As Short
		msgR = MsgBox("是否删除该物料号的编码规则" & txtCarType.Text & "？", MsgBoxStyle.YesNo, "系统提示")
		If msgR = 7 Then Exit Sub
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		cnn.Execute("delete from ""cartype_tpms"" where ""ID""=" & txt_MTID.Text & "")
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		MsgBox("物料号规则删除成功!")
		Exit Sub
Err_Renamed: 
		LogWritter("物料号规则删除时失败，内容:" & Err.Description)
		MsgBox("物料号规则删除失败!" & Err.Description)
	End Sub
	
	Private Sub Command12_Click()
		Me.Close()
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		On Error GoTo update_err
		updateParam("Run", CInt(Me.MSFlexGrid1.get_TextMatrix(Me.MSFlexGrid1.Row, 0)))
		showMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, sqlRun)
		Exit Sub
update_err: 
		MsgBox("修改错误，错误信息：" & Err.Description)
		
	End Sub
	
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		On Error GoTo update_err
		updateParam("Ctrl", CInt(Me.MSFlexGrid2.get_TextMatrix(Me.MSFlexGrid2.Row, 0)))
		showMSFlexGrid((Me.MSFlexGrid2), DBCnnStr, sqlCtrl)
		Exit Sub
update_err: 
		MsgBox("修改错误，错误信息：" & Err.Description)
	End Sub
	
	Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
		Me.Close()
	End Sub
	
	'手动下载排产队列数据 根据id排序
	Private Sub Command5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command5.Click
		On Error GoTo Err_Renamed
		'如果与MES系统Ping不通则退出同步过程
		If Not Ping(MES_IP) Then
			MsgBox("网络故障，请排查")
			Exit Sub
		End If
		'同步车型数据
		LogWritter("正在同步车型数据")
		Dim objConn As ADODB.Connection
		Dim objConnMES As ADODB.Connection
		Dim objRs As ADODB.Recordset
		Dim objRsMES As ADODB.Recordset
		Dim strSQL As String
		Dim existRecord As String
		objConn = New ADODB.Connection
		objRs = New ADODB.Recordset
		objConn.ConnectionTimeout = 2
		objConn.Open(DBCnnStr)
		'判断本地是否存在数据
		LogWritter("判断本地是否存在数据") '--------------------------------------------------------------------
		strSQL = "select count(0) from vinlist;"
		objRs.Open(strSQL, objConn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		existRecord = objRs.Fields(0).value
		'关闭数据连接
		If Not objRs Is Nothing Then
			If objRs.state = 1 Then
				objRs.Close()
			End If
		End If
		'生成在MES系统上的条件子句
		Dim maxGatherDate As String
		Dim formatTimeString As String
		'如果本地没有数据则全部下载
		LogWritter("如果本地没有数据则全部下载") '--------------------------------------------------------------------
		If CDbl(existRecord) = 0 Then
			maxGatherDate = " order by id"
			LogWritter("本地没有车型代码，将从MES服务器上获取")
		Else '如果本地有数据则下载最新的
			strSQL = "SELECT max(""id"") FROM vinlist;"
			objRs.Open(strSQL, objConn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
			formatTimeString = objRs.Fields(0).value
			maxGatherDate = " where id > " & formatTimeString & " order by id"
			'关闭数据连接
			If Not objRs Is Nothing Then
				If objRs.state = 1 Then
					objRs.Close()
				End If
			End If
			LogWritter("本地最新车型id为" & formatTimeString)
		End If
		'开始更新
		objConnMES = New ADODB.Connection
		objRsMES = New ADODB.Recordset
		objConnMES.ConnectionTimeout = 3
		objConnMES.Open(MESCnnStr)
		'.....................................这个SQL是测试用的！！！
		'strSQL = "select * from system.car_prc_seq_v" & maxGatherDate
		strSQL = "select * from ACTIA_VINLIST" & maxGatherDate
		objRsMES.Open(strSQL, objConnMES, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		'取得车型记录的上限值
		Dim categoryLimit As String
		categoryLimit = getConfigValue("T_RunParam", "Status", "CategoryLimit")
		LogWritter("取得车型记录的上限值" & categoryLimit)
		Dim i As Short
		i = 0
		'查询出来的数据更新到本地
		System.Windows.Forms.Application.DoEvents()
		If objRsMES.EOF Then
			LogWritter("MES服务器上没有比本地新的数据")
		Else
			LogWritter("MES服务器上存在比本地新的数据")
			'把同步下来的数据写入本地
			Do While Not objRsMES.EOF
				On Error GoTo InsideErr
				System.Windows.Forms.Application.DoEvents()
				'先查询本地是否有这条记录
				strSQL = "SELECT * FROM vinlist where vin = '" & objRsMES.Fields("VIN").Value & "'"
				objRs.Open(strSQL, objConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
				'如果没有则插入
				If objRs.RecordCount <= 0 Then
					strSQL = "INSERT INTO vinlist(""id"",""vin"", ""tpms"", ""carcode"",""optioncode"",""time"") VALUES ('" & objRsMES.Fields("ID").Value & "','" & objRsMES.Fields("VIN").Value & "', '" & objRsMES.Fields("TPMS").Value & "', '" & objRsMES.Fields("CARCODE").Value & "', '" & objRsMES.Fields("OPTIONCODE").Value & "','" & objRsMES.Fields("TIME").Value & "');"
					LogWritter("插入" & objRsMES.Fields("VIN").Value)
					i = i + 1
				Else
					strSQL = "UPDATE vinlist SET ""id""='" & objRsMES.Fields("ID").Value & "',""vin""='" & objRsMES.Fields("VIN").Value & "', ""tpms""='" & objRsMES.Fields("TPMS").Value & "', ""carcode""='" & objRsMES.Fields("CARCODE").Value & "',optioncode='" & objRsMES.Fields("OPTIONCODE").Value & "', ""time""='" & objRsMES.Fields("TIME").Value & "' WHERE vin = '" & objRsMES.Fields("VIN").Value & "';"
					LogWritter("更新" & objRsMES.Fields("VIN").Value)
				End If
				objConn.Execute(strSQL)
InsideErr: 
				'关闭本地数据集
				If Not objRs Is Nothing Then
					If objRs.state = 1 Then
						objRs.Close()
					End If
				End If
				'处理下一条数据
				objRsMES.MoveNext()
				LogWritter("循环一次的时间") '--------------------------------------------------------------------
				'如果超过限制转到删除逻辑
				If i >= CDbl(categoryLimit) Then
					GoTo DeleteRecords
				End If
				System.Windows.Forms.Application.DoEvents()
			Loop 
		End If
		'删除本地超过数量的数据
DeleteRecords: 
		strSQL = "delete from vinlist where ""id"" < (select ""id"" from vinlist where ""id"" in (select ""id"" from vinlist order by ""id"" desc limit " & categoryLimit & ") order by ""id"" limit 1)"
		'strSQL = "delete from vinlist where ""sortid"" < (select ""sortid"" from vinlist where ""sortid"" in (select ""sortid"" from vinlist order by ""sortid"" desc limit " & categoryLimit & ") order by ""sortid"" limit 1)"
		objConn.Execute(strSQL)
		LogWritter("删除多余的数据成功")
		'关闭MES数据集
		If Not objRsMES Is Nothing Then
			If objRsMES.state = 1 Then
				objRsMES.Close()
			End If
		End If
		'关闭本地连接
		If Not objConn Is Nothing Then
			If objConn.state = 1 Then
				objConn.Close()
			End If
		End If
		'关闭MES连接
		If Not objConnMES Is Nothing Then
			If objConnMES.state = 1 Then
				objConnMES.Close()
			End If
		End If
		
		'UPGRADE_NOTE: 在对对象 objRs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objRs = Nothing
		'UPGRADE_NOTE: 在对对象 objRsMES 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objRsMES = Nothing
		'UPGRADE_NOTE: 在对对象 objConn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objConn = Nothing
		'UPGRADE_NOTE: 在对对象 objConnMES 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objConnMES = Nothing
		
		LogWritter("车型数据同步完毕")
		MsgBox("车型数据同步完毕")
		Exit Sub
Err_Renamed: 
		'关闭本地数据集
		If Not objRs Is Nothing Then
			If objRs.state = 1 Then
				objRs.Close()
			End If
		End If
		'关闭MES数据集
		If Not objRsMES Is Nothing Then
			If objRsMES.state = 1 Then
				objRsMES.Close()
			End If
		End If
		'关闭本地连接
		If Not objConn Is Nothing Then
			If objConn.state = 1 Then
				objConn.Close()
			End If
		End If
		'关闭MES连接
		If Not objConnMES Is Nothing Then
			If objConnMES.state = 1 Then
				objConnMES.Close()
			End If
		End If
		
		'UPGRADE_NOTE: 在对对象 objRs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objRs = Nothing
		'UPGRADE_NOTE: 在对对象 objRsMES 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objRsMES = Nothing
		'UPGRADE_NOTE: 在对对象 objConn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objConn = Nothing
		'UPGRADE_NOTE: 在对对象 objConnMES 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objConnMES = Nothing
		
		LogWritter(Err.Description & Err.Source)
		MsgBox("车型数据同步失败，请查看日志")
	End Sub
	''手动下载排产队列数据 根据时间排序
	'Private Sub Command5_Click()
	'On Error GoTo Err:
	'     '如果与MES系统Ping不通则退出同步过程
	'    If Not Ping(MES_IP) Then
	'        MsgBox "网络故障，请排查"
	'        Exit Sub
	'    End If
	'    '同步车型数据
	'    LogWritter "正在同步车型数据"
	'    Dim objConn As Connection
	'    Dim objConnMES As Connection
	'    Dim objRs As Recordset
	'    Dim objRsMES As Recordset
	'    Dim strSQL As String
	'    Dim existRecord As String
	'    Set objConn = New Connection
	'    Set objRs = New Recordset
	'    objConn.ConnectionTimeout = 2
	'    objConn.Open DBCnnStr
	'    '判断本地是否存在数据
	'    strSQL = "select count(0) from vinlist;"
	'    objRs.Open strSQL, objConn, adOpenKeyset, adLockOptimistic
	'    existRecord = objRs.Fields(0).value
	'    '关闭数据连接
	'    If Not objRs Is Nothing Then
	'        If objRs.state = 1 Then
	'            objRs.Close
	'        End If
	'    End If
	'    '生成在MES系统上的条件子句
	'    Dim maxGatherDate As String
	'    Dim formatTimeString As String
	'    '如果本地没有数据则全部下载
	'    If existRecord = 0 Then
	'        maxGatherDate = " order by LAST_UPDATE_DATE"
	'        'maxGatherDate = " where SITES_CODE='5A1560' order by SEQ_NO"
	'        LogWritter "本地没有车型代码，将从MES服务器上获取"
	'    Else '如果本地有数据则下载最新的
	'        strSQL = "SELECT max(""LAST_UPDATE_DATE"") FROM vinlist;"
	'        'strSQL = "SELECT max(""sortid"") FROM vinlist;"
	'        objRs.Open strSQL, objConn, adOpenKeyset, adLockOptimistic
	'        'formatTimeString = objRs.Fields(0).value
	'       formatTimeString = objRs.Fields(0).value
	'       formatTimeString = Replace(formatTimeString, "上午 ", "")
	'       formatTimeString = Replace(formatTimeString, "AM ", "")
	'       formatTimeString = Replace(formatTimeString, "下午 ", "")
	'       formatTimeString = Replace(formatTimeString, "PM ", "")
	'       maxGatherDate = " where SITES_CODE='5A1560' and LAST_UPDATE_DATE > to_date('" & formatTimeString & "','yyyy-MM-dd HH24:mi:ss') order by LAST_UPDATE_DATE"
	'       ' maxGatherDate = " where SITES_CODE='5A1560' and SEQ_NO > " & formatTimeString & " order by SEQ_NO"
	'        '关闭数据连接
	'        If Not objRs Is Nothing Then
	'            If objRs.state = 1 Then
	'                objRs.Close
	'            End If
	'        End If
	'        LogWritter "本地最新车型代码的时间为" & formatTimeString
	'        'LogWritter "本地最新车型代码的车序为" & formatTimeString
	'    End If
	'    '开始更新
	'    Set objConnMES = New Connection
	'    Set objRsMES = New Recordset
	'    objConnMES.ConnectionTimeout = 3
	'    objConnMES.Open MESCnnStr
	'    '.....................................这个SQL是测试用的！！！
	'    'strSQL = "select * from system.car_prc_seq_v" & maxGatherDate
	'    strSQL = "select * from car_prc_seq_v" & maxGatherDate
	'    objRsMES.Open strSQL, objConnMES, adOpenKeyset, adLockOptimistic
	'    '取得车型记录的上限值
	'    Dim categoryLimit As String
	'    categoryLimit = getConfigValue("T_RunParam", "Status", "CategoryLimit")
	'    LogWritter "取得车型记录的上限值" & categoryLimit
	'    Dim i As Integer
	'    i = 0
	'    '查询出来的数据更新到本地
	'    DoEvents
	'    If objRsMES.EOF Then
	'        LogWritter "MES服务器上没有比本地新的数据"
	'    Else
	'        LogWritter "MES服务器上存在比本地新的数据"
	'        '把同步下来的数据写入本地
	'        Do While Not objRsMES.EOF
	'            On Error GoTo InsideErr:
	'                DoEvents
	'                '先查询本地是否有这条记录
	'                strSQL = "SELECT * FROM vinlist where vin = '" & objRsMES("VIN_CODE") & "'"
	'                objRs.Open strSQL, objConn, adOpenStatic, adLockOptimistic
	'                '如果没有则插入
	'                If objRs.RecordCount <= 0 Then
	'                    strSQL = "INSERT INTO vinlist(""LINE_CODE"", ""SITES_CODE"", ""BODY_NUMBER"", vin, carcode, ""OPTION_CODE"", ""ATTRIBUTE_CODE"", sortid, ""WORK_DATE"", ""LAST_UPDATE_DATE"", tpms) VALUES ('" & objRsMES("LINE_CODE") & "', '" & objRsMES("SITES_CODE") & "', '" & objRsMES("BODY_NUMBER") & "', '" & objRsMES("VIN_CODE") & "', '" & objRsMES("CAR_CODE") & "','" & objRsMES("OPTION_CODE") & "','" & objRsMES("ATTRIBUTE_CODE") & "','" & objRsMES("SEQ_NO") & "','" & objRsMES("WORK_DATE") & "','" & objRsMES("LAST_UPDATE_DATE") & "','1');"
	'                    LogWritter "插入" & objRsMES("VIN_CODE")
	'                    i = i + 1
	'                Else
	'                    strSQL = "UPDATE vinlist SET ""LINE_CODE""='" & objRsMES("LINE_CODE") & "', ""SITES_CODE""='" & objRsMES("SITES_CODE") & "', ""BODY_NUMBER""='" & objRsMES("BODY_NUMBER") & "',carcode='" & objRsMES("CAR_CODE") & "', ""OPTION_CODE""='" & objRsMES("OPTION_CODE") & "',""ATTRIBUTE_CODE""='" & objRsMES("ATTRIBUTE_CODE") & "',sortid='" & objRsMES("SEQ_NO") & "',""WORK_DATE""='" & objRsMES("WORK_DATE") & "',""LAST_UPDATE_DATE""='" & objRsMES("LAST_UPDATE_DATE") & "' WHERE vin = '" & objRsMES("VIN_CODE") & "';"
	'                    LogWritter "更新" & objRsMES("VIN_CODE")
	'                End If
	'                objConn.Execute strSQL
	'InsideErr:
	'                '关闭本地数据集
	'                If Not objRs Is Nothing Then
	'                    If objRs.state = 1 Then
	'                        objRs.Close
	'                    End If
	'                End If
	'                '处理下一条数据
	'                objRsMES.MoveNext
	'                '如果超过限制转到删除逻辑
	'                If i >= categoryLimit Then
	'                    GoTo DeleteRecords
	'                End If
	'            DoEvents
	'        Loop
	'    End If
	'    '删除本地超过数量的数据
	'DeleteRecords:
	'    strSQL = "delete from vinlist where ""LAST_UPDATE_DATE"" < (select ""LAST_UPDATE_DATE"" from vinlist where ""LAST_UPDATE_DATE"" in (select ""LAST_UPDATE_DATE"" from vinlist order by ""LAST_UPDATE_DATE"" desc limit " & categoryLimit & ") order by ""LAST_UPDATE_DATE"" limit 1)"
	'    'strSQL = "delete from vinlist where ""sortid"" < (select ""sortid"" from vinlist where ""sortid"" in (select ""sortid"" from vinlist order by ""sortid"" desc limit " & categoryLimit & ") order by ""sortid"" limit 1)"
	'    objConn.Execute strSQL
	'    LogWritter "删除多余的数据成功"
	'    '关闭MES数据集
	'    If Not objRsMES Is Nothing Then
	'        If objRsMES.state = 1 Then
	'            objRsMES.Close
	'        End If
	'    End If
	'    '关闭本地连接
	'    If Not objConn Is Nothing Then
	'        If objConn.state = 1 Then
	'            objConn.Close
	'        End If
	'    End If
	'    '关闭MES连接
	'    If Not objConnMES Is Nothing Then
	'        If objConnMES.state = 1 Then
	'            objConnMES.Close
	'        End If
	'    End If
	'
	'    Set objRs = Nothing
	'    Set objRsMES = Nothing
	'    Set objConn = Nothing
	'    Set objConnMES = Nothing
	'
	'    LogWritter "车型数据同步完毕"
	'    MsgBox "车型数据同步完毕"
	'    Exit Sub
	'Err:
	'    '关闭本地数据集
	'    If Not objRs Is Nothing Then
	'        If objRs.state = 1 Then
	'            objRs.Close
	'        End If
	'    End If
	'    '关闭MES数据集
	'    If Not objRsMES Is Nothing Then
	'        If objRsMES.state = 1 Then
	'            objRsMES.Close
	'        End If
	'    End If
	'    '关闭本地连接
	'    If Not objConn Is Nothing Then
	'        If objConn.state = 1 Then
	'            objConn.Close
	'        End If
	'    End If
	'    '关闭MES连接
	'    If Not objConnMES Is Nothing Then
	'        If objConnMES.state = 1 Then
	'            objConnMES.Close
	'        End If
	'    End If
	'
	'    Set objRs = Nothing
	'    Set objRsMES = Nothing
	'    Set objConn = Nothing
	'    Set objConnMES = Nothing
	'
	'    LogWritter Err.Description & Err.Source
	'    MsgBox "车型数据同步失败，请查看日志"
	'End Sub
	
	Private Sub Command6_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command6.Click
		On Error GoTo Err_Renamed
		Dim objConn As ADODB.Connection
		Dim objRs As ADODB.Recordset
		Dim strSQL As String
		
		If Text1.Text = Text2.Text And Text1.Text <> "" Then
			
			'打开本地数据库连接
			objConn = New ADODB.Connection
			objRs = New ADODB.Recordset
			objConn.ConnectionTimeout = 2
			objConn.Open(DBCnnStr)
			
			strSQL = "UPDATE ""T_Psw"" SET ""psw"" = '" & Text1.Text & "'"
			objRs.Open(strSQL, objConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
			objConn.Close()
			'UPGRADE_NOTE: 在对对象 objRs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
			objRs = Nothing
			'UPGRADE_NOTE: 在对对象 objConn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
			objConn = Nothing
			MsgBox("管理密码修改成功")
			LogWritter("管理密码修改成功")
			
		Else
			MsgBox("管理密码不能为空")
		End If
		Exit Sub
Err_Renamed: 
		LogWritter("修改密码过程出错")
	End Sub
	
	Private Sub Command7_Click()
		'    If txtVin.text = "" Then
		'        MsgBox "打印VIN不能为空!"
		'        txtVin.SetFocus
		'        Exit Sub
		'    End If
		'
		'    Dim cnn As New ADODB.Connection
		'    Dim rs As ADODB.Recordset
		'    cnn.Open DBCnnStr
		'    Set rs = cnn.Execute("select ""VIN"" from ""T_Result"" where ""VIN""='" & txtVin.text & "'")
		'
		'    If rs.EOF Then
		'        rs.Close
		'        Set rs = Nothing
		'        cnn.Close
		'        Set cnn = Nothing
		'        MsgBox "系统中不存在该车的相关检测信息!"
		'        Exit Sub
		'    End If
		'
		'    printErrCodeByVIN (txtVin.text)
	End Sub
	
	'Private Sub Command8_Click()
	'On Error GoTo Err
	'    Dim cnn As New ADODB.Connection
	'    Dim rs As ADODB.Recordset
	'    cnn.Open DBCnnStr
	'    If StrConv(txt_MaterialCode.text, vbUpperCase) = "" Then
	'       MsgBox "物料编号不得为空"
	'       Exit Sub
	'    ElseIf StrConv(txt_CarType.text, vbUpperCase) = "" Then
	'      MsgBox "车型不得为空"
	'      Exit Sub
	'    ElseIf StrConv(txt_ifTPMS.text, vbUpperCase) = "" Then
	'      MsgBox "胎压不得为空"
	'      Exit Sub
	'    ElseIf txt_ifTPMS.text <> "0" Or txt_ifTPMS.text <> "1" Then
	'      MsgBox "胎压设置有误"
	'      Exit Sub
	'    End If
	'    Dim xxx As String
	'    xxx = "select ""MaterialCode"" from ""cartype_tpms"" where Upper(""MaterialCode"")='" & StrConv(txtCarType.text, vbUpperCase) & "' "
	'    Set rs = cnn.Execute("select ""MaterialCode"" from ""cartype_tpms"" where Upper(""MaterialCode"")='" & StrConv(txtCarType.text, vbUpperCase) & "' ")
	'    If Not rs.EOF Then
	'        MsgBox "该物料号已经配置!"
	'        Exit Sub
	'    End If
	'    xxx = "insert into ""cartype_tpms"" (""MaterialCode"",""CarType"",""ifTPMS"") values ('" & txt_MaterialCode.text & "','" & txt_CarType.text & "','" & txt_ifTPMS.text & "')"
	'    cnn.Execute ("insert into ""cartype_tpms"" (""MaterialCode"",""CarType"",""ifTPMS"") values ('" & txt_MaterialCode.text & "','" & txt_CarType.text & "','" & txt_ifTPMS.text & "')")
	'    cnn.Close
	'    Set cnn = Nothing
	'
	'    showMSFlexGrid Me.MSFlexGrid3, DBCnnStr, sqlTpmsCode
	'    MsgBox "物料号编码规则新增成功!"
	'    Exit Sub
	'Err:
	'    LogWritter "新增物料编码失败，内容:" & Err.Description
	'    MsgBox "新增物料编码失败!" & Err.Description
	'End Sub
	'
	'Private Sub Command9_Click()
	'On Error GoTo Err
	'    Dim cnn As New ADODB.Connection
	'    Dim rs As ADODB.Recordset
	'    cnn.Open DBCnnStr
	'
	''    Set rs = cnn.Execute("select ""CarType"" from ""cartype_prono"" where Upper(""CarType"")='" & StrConv(txtCarType.text, vbUpperCase) & "'")
	''    If Not rs.EOF Then
	''        MsgBox "该车型程序号已存在!"
	''        Exit Sub
	''    End If
	'
	'    cnn.Execute ("update ""cartype_tpms"" set ""MaterialCode""='" & txt_MaterialCode.text & "',""CarType""='" & txt_CarType.text & "',""ifTPMS""='" & txt_ifTPMS.text & "' where ""ID""=" & txt_MTID.text & "")
	'    cnn.Close
	'    Set cnn = Nothing
	'
	'    showMSFlexGrid Me.MSFlexGrid3, DBCnnStr, sqlTpmsCode
	'    MsgBox "物料号规则修改成功!"
	'    Exit Sub
	'Err:
	'    LogWritter "物料号规则修改失败，内容:" & Err.Description
	'    MsgBox "物料号规则修改失败!" & Err.Description
	'End Sub
	
	Private Sub frmOption_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		WindowsXPC1.InitSubClassing()
		Me.SSTab1.SelectedIndex = 0
		sqlCtrl = "Select ""ID"" as ""编号"",""Group"" as ""组"",""Description"" as ""描述"",""Key"" as ""关键字"",""Value"" as ""值"" from ""T_CtrlParam"" order by ""ID"" "
		sqlRun = "Select ""ID"" as ""编号"",""Group"" as ""组"",""Description"" as ""描述"",""Key"" as ""关键字"",""Value"" as ""值"" from ""T_RunParam"" order by ""ID"" "
		sqlTpmsCode = "select ""ID"",""ID"" as ""编号"",""CarType"" as ""车型"",""ProNum"" as ""程序号"" from ""cartype_prono"" order by ""ID"""
		'2016.1.13添加
		sqlMaterialCode = "select ""ID"",""ID"" as ""编号"",""MatchLetter"" as ""匹配的字母"",""CodeStartIndex"" as ""起始位置"",""CodeLen"" as ""长度"",""CarType"" as ""车型"",""ifTPMS"" as ""是否带胎压"" from ""cartype_tpms"" order by ""ID"""
		'构造参数表
		loadCombo((Me.ComboRun), "T_RunParam")
		showMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, sqlRun)
		loadCombo((Me.ComboCtrl), "T_CtrlParam")
		showMSFlexGrid((Me.MSFlexGrid2), DBCnnStr, sqlCtrl)
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		showMSFlexGrid((Me.MSFlexGrid4), DBCnnStr, sqlMaterialCode) '2016.1.13添加
		'    Me.MSFlexGrid3.ColWidth(1) = 800
		'    Me.MSFlexGrid3.ColWidth(2) = 1200
		'    Me.MSFlexGrid3.ColWidth(3) = 1200
		'    Me.MSFlexGrid3.ColWidth(4) = 1200
		If isCheckAllQueue Then
			chkAllQueue.CheckState = System.Windows.Forms.CheckState.Checked
		Else
			chkAllQueue.CheckState = System.Windows.Forms.CheckState.Unchecked
		End If
		If isOnlyScanVINCode Then
			chkOnlyScanVINCode.CheckState = System.Windows.Forms.CheckState.Checked
		Else
			chkOnlyScanVINCode.CheckState = System.Windows.Forms.CheckState.Unchecked
		End If
		'    If isOnlyPrintNGWriteResult Then
		'        chkOnlyPrintNGWriteResult.value = 1
		'    Else
		'        chkOnlyPrintNGWriteResult.value = 0
		'    End If
		'    If isOnlyPrintNGFlow Then
		'        chkPrintNGFlow.value = 1
		'    Else
		'        chkPrintNGFlow.value = 0
		'    End If
		
		txtMdl.Text = mdlValue
		txtPreMin.Text = preMinValue
		txtPreMax.Text = preMaxValue
		txtTempMin.Text = tempMinValue
		txtTempMax.Text = tempMaxValue
		txtAcSpeedMin.Text = acSpeedMinValue
		txtAcSpeedMax.Text = acSpeedMaxValue
		'    txtMtocStartIndex.text = mTOCStartIndex
		'    txtMTOCLen.text = tPMSCodeLen
		
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
	End Sub
	
	'******************************************************************************
	'** 函 数 名：showMSFlexGrid
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
	
	Public Sub showMSFlexGrid(ByRef msFG As AxMSFlexGridLib.AxMSFlexGrid, ByRef CnnStr As String, ByRef sql As String)
		On Error GoTo Err_ShowGrid
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
			.Rows = rs.RecordCount + 11
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
			.set_ColWidth(1, 800)
			For i = 2 To cols - 1 '为每行中的列进行设置
				.set_ColWidth(i, 1400) '列的宽度,以后自己估算
			Next 
			
		End With
	End Sub
	
	Private Sub MSFlexGrid1_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MSFlexGrid1.ClickEvent
		On Error Resume Next
		txtGroupRun.Text = Me.MSFlexGrid1.get_TextMatrix(Me.MSFlexGrid1.Row, 1)
		txtDescriptionRun.Text = Me.MSFlexGrid1.get_TextMatrix(Me.MSFlexGrid1.Row, 2)
		txtKeyRun.Text = Me.MSFlexGrid1.get_TextMatrix(Me.MSFlexGrid1.Row, 3)
		txtValueRun.Text = Me.MSFlexGrid1.get_TextMatrix(Me.MSFlexGrid1.Row, 4)
		
	End Sub
	
	Private Sub MSFlexGrid2_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MSFlexGrid2.ClickEvent
		On Error Resume Next
		txtGroupCtrl.Text = Me.MSFlexGrid2.get_TextMatrix(Me.MSFlexGrid2.Row, 1)
		txtDescriptionCtrl.Text = Me.MSFlexGrid2.get_TextMatrix(Me.MSFlexGrid2.Row, 2)
		txtKeyCtrl.Text = Me.MSFlexGrid2.get_TextMatrix(Me.MSFlexGrid2.Row, 3)
		txtValueCtrl.Text = Me.MSFlexGrid2.get_TextMatrix(Me.MSFlexGrid2.Row, 4)
		'showMSFlexGrid Me.MSFlexGrid2, DBCnnStr, sqlCtrl
	End Sub
	
	
	
	'******************************************************************************
	'** 函 数 名：updateParam
	'** 输    入：
	'** 输    出：
	'** 功能描述：修改配置
	'** 全局变量：
	'** 作    者：yangshuai
	'** 邮    箱：shuaigoplay@live.cn
	'** 日    期：2009-2-27
	'** 修 改 者：
	'** 日    期：
	'** 版    本：1.0
	'******************************************************************************
	Public Sub updateParam(ByRef typeStr As String, ByRef id As Integer)
		Dim cnn As New ADODB.Connection
		Dim tableName As String
		Dim textName As String
		tableName = Chr(34) & "T_" & typeStr & "Param" & Chr(34)
		textName = "txtValue" & typeStr
		cnn.Open(DBCnnStr)
		cnn.Execute("update " & tableName & " set ""Value""='" & CType(Me.Controls(textName), Object).Text & "' where ""ID""=" & id)
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
	
	
	'******************************************************************************
	'** 函 数 名：loadCombo载入Combo控件内容
	'** 输    入：
	'** 输    出：
	'** 功能描述：修改配置
	'** 全局变量：
	'** 作    者：yangshuai
	'** 邮    箱：shuaigoplay@live.cn
	'** 日    期：2009-2-27
	'** 修 改 者：
	'** 日    期：
	'** 版    本：1.0
	'******************************************************************************
	Private Sub loadCombo(ByRef combo As System.Windows.Forms.ComboBox, ByRef tableName As String)
		On Error GoTo loadCombo_err
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select ""Group"" from """ & tableName & """ group by ""Group""  ")
		combo.Items.Clear()
		Do While Not rs.EOF
			combo.Items.Add(rs.Fields(0).value)
			rs.MoveNext()
		Loop 
		cnn.Close()
		Exit Sub
loadCombo_err: 
		MsgBox("加载错误！错误信息：" & Err.Description)
		
	End Sub
	Private Sub MSFlexGrid3_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MSFlexGrid3.ClickEvent
		On Error Resume Next
		txtTPMSID.Text = Me.MSFlexGrid3.get_TextMatrix(Me.MSFlexGrid3.Row, 1)
		txtCarType.Text = Me.MSFlexGrid3.get_TextMatrix(Me.MSFlexGrid3.Row, 2)
		txtProNum.Text = Me.MSFlexGrid3.get_TextMatrix(Me.MSFlexGrid3.Row, 3)
	End Sub
	Public Function readRunParam(ByRef key As String, ByRef group As String) As String
		On Error Resume Next
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select ""Value"" from ""T_RunParam"" where ""Key""='" & key & "' and ""Group""='" & group & "'")
		readRunParam = rs.Fields("Value").Value
		rs.Close()
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Function
	Public Function updateRunParam(ByRef value As String, ByRef group As String, ByRef key As String) As Object
		On Error Resume Next
		Dim cnn As New ADODB.Connection
		cnn.Open(DBCnnStr)
		cnn.Execute("update ""T_RunParam"" set ""Value""='" & value & "'  where ""Key""='" & key & "' and ""Group""='" & group & "'")
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Function
	
	Private Sub MSFlexGrid4_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MSFlexGrid4.ClickEvent
		On Error Resume Next
		txt_MTID.Text = Me.MSFlexGrid4.get_TextMatrix(Me.MSFlexGrid4.Row, 1)
		txt_MatchLetter.Text = Me.MSFlexGrid4.get_TextMatrix(Me.MSFlexGrid4.Row, 2)
		txt_CodeStartIndex.Text = Me.MSFlexGrid4.get_TextMatrix(Me.MSFlexGrid4.Row, 3)
		txt_CodeLen.Text = Me.MSFlexGrid4.get_TextMatrix(Me.MSFlexGrid4.Row, 4)
		txt_CarType.Text = Me.MSFlexGrid4.get_TextMatrix(Me.MSFlexGrid4.Row, 5)
		txt_ifTPMS.Text = Me.MSFlexGrid4.get_TextMatrix(Me.MSFlexGrid4.Row, 6)
	End Sub
End Class