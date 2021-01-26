Option Strict Off
Option Explicit On
Friend Class frmOption
	Inherits System.Windows.Forms.Form
	'******************************************************************************
	'** �ļ�����frmOption.frm
	'** ��  Ȩ��CopyRight (c) 2008-2010 �人��������ϵͳ���޹�˾
	'** �����ˣ�yangshuai
	'** ��  �䣺shuaigoplay@live.cn
	'** ��  �ڣ�2009-2-27
	'** �޸��ˣ�
	'** ��  �ڣ�
	'** ��  ����ϵͳ����
	'** ��  ����1.0
	'******************************************************************************
	
	Dim sqlCtrl As String
	Dim sqlRun As String
	Dim sqlTpmsCode As String
	
	
	'�޸�TPMS��������ʼλ����Ϣ
	Private Sub btMTOCModi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btMTOCModi.Click
		On Error GoTo Err_Renamed
		If txtMtocStartIndex.Text = "" Then
			MsgBox("TPMS��������ʼλ�ò���Ϊ��!")
			txtMtocStartIndex.Focus()
			Exit Sub
		End If
		
		If txtMTOCLen.Text = "" Then
			MsgBox("TPMS�����볤����Ϊ��!")
			txtMTOCLen.Focus()
			Exit Sub
		End If
		
		Call updateRunParam((txtMtocStartIndex.Text), "TPMSCode", "MTOCStartIndex")
		Call updateRunParam((txtMTOCLen.Text), "TPMSCode", "TPMSCodeLen")
		
		mTOCStartIndex = txtMtocStartIndex.Text
		tPMSCodeLen = txtMTOCLen.Text
		
		MsgBox("TPMS��������ʼλ����Ϣ�޸ĳɹ�!")
		
		Exit Sub
Err_Renamed: 
		LogWritter("�޸�TPMS��������ʼλ����Ϣʱʧ�ܣ�����:" & Err.Description)
		MsgBox("TPMS��������ʼλ����Ϣ�޸�ʧ��!" & Err.Description)
	End Sub
	
	'����TPMS������
	Private Sub btTPMSAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btTPMSAdd.Click
		On Error GoTo Err_Renamed
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		
		rs = cnn.Execute("select ""TPMSCode"" from ""T_TPMSCodeList"" where Upper(""TPMSCode"")='" & StrConv(txtTPMSCode.Text, VbStrConv.UpperCase) & "'")
		If Not rs.EOF Then
			MsgBox("��TPMS�������Ѵ���!")
			Exit Sub
		End If
		
		cnn.Execute("insert into ""T_TPMSCodeList"" (""TPMSCode"") values ('" & txtTPMSCode.Text & "')")
		
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
		
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		MsgBox("TPMS�����������ɹ�!")
		Exit Sub
Err_Renamed: 
		LogWritter("����TPMS������ʱʧ�ܣ�����:" & Err.Description)
		MsgBox("TPMS����������ʧ��!" & Err.Description)
	End Sub
	
	Private Sub btTPMSCancle_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btTPMSCancle.Click
		Me.Close()
	End Sub
	'ɾ��TPMS������
	Private Sub btTPMSDel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btTPMSDel.Click
		On Error GoTo Err_Renamed
		Dim msgR As Short
		msgR = MsgBox("�Ƿ�ɾ��TPMS������" & txtTPMSCode.Text & "��", MsgBoxStyle.YesNo, "ϵͳ��ʾ")
		If msgR = 7 Then Exit Sub
		
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		
		cnn.Execute("delete from ""T_TPMSCodeList"" where ""ID""=" & txtTPMSID.Text & "")
		
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
		
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		MsgBox("TPMS������ɾ���ɹ�!")
		Exit Sub
Err_Renamed: 
		LogWritter("ɾ��TPMS������ʱʧ�ܣ�����:" & Err.Description)
		MsgBox("TPMS������ɾ��ʧ��!" & Err.Description)
	End Sub
	
	'�޸�TPMS������
	Private Sub btTPMSModi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btTPMSModi.Click
		On Error GoTo Err_Renamed
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		
		rs = cnn.Execute("select ""TPMSCode"" from ""T_TPMSCodeList"" where Upper(""TPMSCode"")='" & StrConv(txtTPMSCode.Text, VbStrConv.UpperCase) & "'")
		If Not rs.EOF Then
			MsgBox("��TPMS�������Ѵ���!")
			Exit Sub
		End If
		
		cnn.Execute("update ""T_TPMSCodeList"" set ""TPMSCode""='" & txtTPMSCode.Text & "' where ""ID""=" & txtTPMSID.Text & "")
		
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
		
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		MsgBox("TPMS�������޸ĳɹ�!")
		Exit Sub
Err_Renamed: 
		LogWritter("�޸�TPMS������ʱʧ�ܣ�����:" & Err.Description)
		MsgBox("TPMS�������޸�ʧ��!" & Err.Description)
	End Sub
	
	'�Ƿ�����Ų�����
	'UPGRADE_WARNING: ��ʼ������ʱ���ܼ����¼� chkAllQueue.CheckStateChanged�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"��
	Private Sub chkAllQueue_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkAllQueue.CheckStateChanged
		If chkAllQueue.CheckState = System.Windows.Forms.CheckState.Checked Then
			isCheckAllQueue = True
			Call updateRunParam(CStr(1), "Queue", "CheckAllQueue")
		Else
			isCheckAllQueue = False
			Call updateRunParam(CStr(0), "Queue", "CheckAllQueue")
		End If
	End Sub
	
	'�Ƿ�ֻ��ӡ��Ͻ��ΪNG����ϵ���
	'UPGRADE_WARNING: ��ʼ������ʱ���ܼ����¼� chkOnlyPrintNGWriteResult.CheckStateChanged�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"��
	Private Sub chkOnlyPrintNGWriteResult_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkOnlyPrintNGWriteResult.CheckStateChanged
		If chkOnlyPrintNGWriteResult.CheckState = System.Windows.Forms.CheckState.Checked Then
			isOnlyPrintNGWriteResult = True
			Call updateRunParam(CStr(1), "Print", "OnlyPrintNGWriteResult")
		Else
			isOnlyPrintNGWriteResult = False
			Call updateRunParam(CStr(0), "Print", "OnlyPrintNGWriteResult")
		End If
	End Sub
	
	'��ɨ��VIN��
	'UPGRADE_WARNING: ��ʼ������ʱ���ܼ����¼� chkOnlyScanVINCode.CheckStateChanged�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"��
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
	'�Ƿ�ֻ��ӡNG��������̣��ϸ�����̲���ӡ
	'UPGRADE_WARNING: ��ʼ������ʱ���ܼ����¼� chkPrintNGFlow.CheckStateChanged�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"��
	Private Sub chkPrintNGFlow_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkPrintNGFlow.CheckStateChanged
		If chkPrintNGFlow.CheckState = System.Windows.Forms.CheckState.Checked Then
			isOnlyPrintNGFlow = True
			Call updateRunParam(CStr(1), "Print", "OnlyPrintNGFlow")
		Else
			isOnlyPrintNGFlow = False
			Call updateRunParam(CStr(0), "Print", "OnlyPrintNGFlow")
		End If
	End Sub
	
	'�޸ļ��ٶȷ�Χֵ
	Private Sub cmdAcSpeedSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAcSpeedSave.Click
		On Error GoTo Err_Renamed
		If txtAcSpeedMin.Text = "" Then
			MsgBox("���������ٶ���Сֵ����Ϊ��!")
			txtAcSpeedMin.Focus()
			Exit Sub
		End If
		
		If txtAcSpeedMax.Text = "" Then
			MsgBox("���������ٶ����ֵ����Ϊ��!")
			txtAcSpeedMax.Focus()
			Exit Sub
		End If
		
		Call updateRunParam((txtAcSpeedMin.Text), "StandardValue", "AcSpeedMinValue")
		Call updateRunParam((txtAcSpeedMax.Text), "StandardValue", "AcSpeedMaxValue")
		
		acSpeedMinValue = txtAcSpeedMin.Text
		acSpeedMaxValue = txtAcSpeedMax.Text
		
		MsgBox("���������ٶ�ֵ��Χ�޸ĳɹ�!")
		
		Exit Sub
Err_Renamed: 
		LogWritter("�޸Ĵ��������ٶ�ֵʱʧ�ܣ�����:" & Err.Description)
		MsgBox("���������ٶ�ֵ��Χ�޸�ʧ��!" & Err.Description)
	End Sub
	'�޸�ģʽ
	Private Sub cmdMdlSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMdlSave.Click
		If txtMdl.Text = "" Then
			MsgBox("������ģʽ����Ϊ��!")
			txtMdl.Focus()
			Exit Sub
		End If
		
		Call updateRunParam((txtMdl.Text), "StandardValue", "MdlValue")
		mdlValue = txtMdl.Text
	End Sub
	
	'�޸�ѹ����Χֵ
	Private Sub cmdPreSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPreSave.Click
		On Error GoTo Err_Renamed
		If txtPreMin.Text = "" Then
			MsgBox("������ѹ����Сֵ����Ϊ��!")
			txtPreMin.Focus()
			Exit Sub
		End If
		
		If txtPreMax.Text = "" Then
			MsgBox("������ѹ�����ֵ����Ϊ��!")
			txtPreMax.Focus()
			Exit Sub
		End If
		
		Call updateRunParam((txtPreMin.Text), "StandardValue", "PreMinValue")
		Call updateRunParam((txtPreMax.Text), "StandardValue", "PreMaxValue")
		
		preMinValue = txtPreMin.Text
		preMaxValue = txtPreMax.Text
		
		MsgBox("������ѹ��ֵ��Χ�޸ĳɹ�!")
		
		Exit Sub
Err_Renamed: 
		LogWritter("�޸Ĵ�����ѹ��ֵʱʧ�ܣ�����:" & Err.Description)
		MsgBox("������ѹ��ֵ��Χ�޸�ʧ��!" & Err.Description)
	End Sub
	'�޸��¶ȷ�Χֵ
	Private Sub cmdTempSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTempSave.Click
		On Error GoTo Err_Renamed
		If txtTempMin.Text = "" Then
			MsgBox("�������¶���Сֵ����Ϊ��!")
			txtTempMin.Focus()
			Exit Sub
		End If
		
		If txtTempMax.Text = "" Then
			MsgBox("�������¶����ֵ����Ϊ��!")
			txtTempMax.Focus()
			Exit Sub
		End If
		
		Call updateRunParam((txtTempMin.Text), "StandardValue", "TempMinValue")
		Call updateRunParam((txtTempMax.Text), "StandardValue", "TempMaxValue")
		
		tempMinValue = txtTempMin.Text
		tempMaxValue = txtTempMax.Text
		
		MsgBox("�������¶�ֵ��Χ�޸ĳɹ�!")
		
		Exit Sub
Err_Renamed: 
		LogWritter("�޸Ĵ������¶�ֵʱʧ�ܣ�����:" & Err.Description)
		MsgBox("�������¶�ֵ��Χ�޸�ʧ��!" & Err.Description)
	End Sub
	
	'UPGRADE_WARNING: ��ʼ������ʱ���ܼ����¼� ComboCtrl.SelectedIndexChanged�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"��
	Private Sub ComboCtrl_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ComboCtrl.SelectedIndexChanged
		sqlCtrl = "select ""ID"" as ""���"",""Group"" as ""��"",""Description"" as ""����"",""Key"" as ""�ؼ���"",""Value"" as ""ֵ"" from ""T_CtrlParam"" where ""Group""='" & Me.ComboCtrl.Text & "'  order by ""ID"" "
		showMSFlexGrid((Me.MSFlexGrid2), DBCnnStr, sqlCtrl)
	End Sub
	
	
	'UPGRADE_WARNING: ��ʼ������ʱ���ܼ����¼� ComboRun.SelectedIndexChanged�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"��
	Private Sub ComboRun_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ComboRun.SelectedIndexChanged
		sqlRun = "select ""ID"" as ""���"",""Group"" as ""��"",""Description"" as ""����"",""Key"" as ""�ؼ���"",""Value"" as ""ֵ"" from ""T_RunParam"" where ""Group""='" & Me.ComboRun.Text & "' order by ""ID""  "
		showMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, sqlRun)
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Me.Close()
	End Sub
	
	Private Sub Command10_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command10.Click
		frmQueueInfo.Show()
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		On Error GoTo update_err
		updateParam("Run", CInt(Me.MSFlexGrid1.get_TextMatrix(Me.MSFlexGrid1.Row, 0)))
		showMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, sqlRun)
		Exit Sub
update_err: 
		MsgBox("�޸Ĵ��󣬴�����Ϣ��" & Err.Description)
		
	End Sub
	
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		On Error GoTo update_err
		updateParam("Ctrl", CInt(Me.MSFlexGrid2.get_TextMatrix(Me.MSFlexGrid2.Row, 0)))
		showMSFlexGrid((Me.MSFlexGrid2), DBCnnStr, sqlCtrl)
		Exit Sub
update_err: 
		MsgBox("�޸Ĵ��󣬴�����Ϣ��" & Err.Description)
	End Sub
	
	Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
		Me.Close()
	End Sub
	
	'�ֶ������Ų���������
	Private Sub Command5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command5.Click
		On Error GoTo Err_Renamed
		Dim diaFlag As Short
		
		If FrmMain.TestStateFlag <= 5 Then
			diaFlag = MsgBox("�������ڽ���̥ѹ��⣬���Ժ��������Ų�������Ϣ", MsgBoxStyle.OKOnly, "ϵͳ��ʾ")
			Exit Sub
		End If
		
		diaFlag = MsgBox("�Ƿ������Ų�������Ϣ?", MsgBoxStyle.YesNo, "ϵͳ��ʾ")
		If diaFlag = 7 Then
			Exit Sub
		End If
		
		If Not Ping(MES_IP) Then
			diaFlag = MsgBox("����MES������ʱʧ�ܣ���������״̬�Ƿ�ͨ!", MsgBoxStyle.OKOnly, "ϵͳ��ʾ")
			Exit Sub
		End If
		
		Dim objConn As ADODB.Connection
		Dim objConnMES As ADODB.Connection
		Dim objRs As ADODB.Recordset
		Dim objTmpRs As ADODB.Recordset
		Dim objRsMES As ADODB.Recordset
		Dim strSQL As String
		
		'�ȶ�ȡMES�ϵ�����
		objConnMES = New ADODB.Connection
		objRsMES = New ADODB.Recordset
		objConnMES.ConnectionTimeout = 3
		System.Windows.Forms.Application.DoEvents()
		objConnMES.Open(MESCnnStr)
		If objConnMES.state <> ADODB.ObjectStateEnum.adStateOpen Then
			diaFlag = MsgBox("����MES���ݿ�ʱʧ�ܣ�����Oracle�ͻ���������Ϣ�Ƿ���ȷ!", MsgBoxStyle.OKOnly, "ϵͳ��ʾ")
			'UPGRADE_NOTE: �ڶԶ��� objConnMES ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
			objConnMES = Nothing
			Exit Sub
		End If
		LogWritter("�����ֶ�ͬ���Ų���������")
		strSQL = "select * from mesprd.IF_VEHICLE_TPMS_INFO where tpms_process=0 order by pa_off_seq asc"
		'strSQL = "update mesprd.IF_VEHICLE_TPMS_INFO set tpms_process=0 where pa_off_seq>=18452"
		objRsMES.Open(strSQL, objConnMES, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		
		'�򿪱������ݿ�����
		objConn = New ADODB.Connection
		objRs = New ADODB.Recordset
		objConn.ConnectionTimeout = 2
		objConn.Open(DBCnnStr)
		
		strSQL = "select * from vinlist"
		objRs.Open(strSQL, objConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
		System.Windows.Forms.Application.DoEvents()
		objTmpRs = New ADODB.Recordset
		Do While Not objRsMES.EOF '---���������
			strSQL = "select * from vinlist where vin='" & objRsMES.Fields("vin").Value & "'"
			objTmpRs.Open(strSQL, objConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
			If objTmpRs.EOF Then
				objRs.AddNew()
				objRs.Fields("vin").Value = objRsMES.Fields("vin").Value
				objRs.Fields("mtoc").Value = objRsMES.Fields("mtoc").Value
				objRs.Fields("pa_off_seq").Value = objRsMES.Fields("pa_off_seq").Value
				objRs.Fields("pa_off_time").Value = objRsMES.Fields("pa_off_time").Value
				objRs.Fields("createtime").Value = Now
				objRs.Update()
			Else
				objTmpRs.Fields("mtoc").Value = objRsMES.Fields("mtoc").Value
				objTmpRs.Fields("pa_off_seq").Value = objRsMES.Fields("pa_off_seq").Value
				objTmpRs.Fields("pa_off_time").Value = objRsMES.Fields("pa_off_time").Value
				objTmpRs.Fields("createtime").Value = Now
				objTmpRs.Update()
			End If
			
			'����MESϵͳ�����ر�ʶ
			strSQL = "update mesprd.IF_VEHICLE_TPMS_INFO set tpms_process=1 where vin='" & objRsMES.Fields("vin").Value & "'"
			objConnMES.Execute(strSQL)
			
			objRsMES.MoveNext()
			objTmpRs.Close()
		Loop 
		objRs.Close()
		objRsMES.Close()
		objConn.Close()
		objConnMES.Close()
		'UPGRADE_NOTE: �ڶԶ��� objRs ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objRs = Nothing
		'UPGRADE_NOTE: �ڶԶ��� objTmpRs ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objTmpRs = Nothing
		'UPGRADE_NOTE: �ڶԶ��� objRsMES ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objRsMES = Nothing
		'UPGRADE_NOTE: �ڶԶ��� objConn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objConn = Nothing
		'UPGRADE_NOTE: �ڶԶ��� objConnMES ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objConnMES = Nothing
		
		LogWritter("�Ų���������ͬ�����")
		diaFlag = MsgBox("�Ų������������سɹ�!", MsgBoxStyle.OKOnly, "ϵͳ��ʾ")
		Exit Sub
Err_Renamed: 
		LogWritter(Err.Description)
		diaFlag = MsgBox(Err.Description, MsgBoxStyle.OKOnly, "ϵͳ��ʾ")
	End Sub
	
	Private Sub Command6_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command6.Click
		On Error GoTo Err_Renamed
		Dim objConn As ADODB.Connection
		Dim objRs As ADODB.Recordset
		Dim strSQL As String
		
		If Text1.Text = Text2.Text And Text1.Text <> "" Then
			
			'�򿪱������ݿ�����
			objConn = New ADODB.Connection
			objRs = New ADODB.Recordset
			objConn.ConnectionTimeout = 2
			objConn.Open(DBCnnStr)
			
			strSQL = "UPDATE ""T_Psw"" SET ""psw"" = '" & Text1.Text & "'"
			objRs.Open(strSQL, objConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
			objConn.Close()
			'UPGRADE_NOTE: �ڶԶ��� objRs ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
			objRs = Nothing
			'UPGRADE_NOTE: �ڶԶ��� objConn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
			objConn = Nothing
			MsgBox("���������޸ĳɹ�")
			LogWritter("���������޸ĳɹ�")
			
		Else
			MsgBox("�������벻��Ϊ��")
		End If
		Exit Sub
Err_Renamed: 
		LogWritter("�޸�������̳���")
	End Sub
	
	Private Sub Command7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command7.Click
		If txtVIN.Text = "" Then
			MsgBox("��ӡVIN����Ϊ��!")
			txtVIN.Focus()
			Exit Sub
		End If
		
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select ""VIN"" from ""T_Result"" where ""VIN""='" & txtVIN.Text & "'")
		
		If rs.EOF Then
			rs.Close()
			'UPGRADE_NOTE: �ڶԶ��� rs ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
			rs = Nothing
			cnn.Close()
			'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
			cnn = Nothing
			MsgBox("ϵͳ�в����ڸó�����ؼ����Ϣ!")
			Exit Sub
		End If
		
		printErrCodeByVIN((txtVIN.Text))
	End Sub
	
	Private Sub frmOption_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		WindowsXPC1.InitSubClassing()
		Me.SSTab1.SelectedIndex = 0
		Me.SSTab1.TabPages.Item(3).Visible = False
		
		sqlCtrl = "Select ""ID"" as ""���"",""Group"" as ""��"",""Description"" as ""����"",""Key"" as ""�ؼ���"",""Value"" as ""ֵ"" from ""T_CtrlParam"" order by ""ID"" "
		sqlRun = "Select ""ID"" as ""���"",""Group"" as ""��"",""Description"" as ""����"",""Key"" as ""�ؼ���"",""Value"" as ""ֵ"" from ""T_RunParam"" order by ""ID"" "
		sqlTpmsCode = "select ""ID"",""ID"" as ""���"",""TPMSCode"" as ""TPMS������"" from ""T_TPMSCodeList"" order by ""ID"""
		'���������
		loadCombo((Me.ComboRun), "T_RunParam")
		showMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, sqlRun)
		loadCombo((Me.ComboCtrl), "T_CtrlParam")
		showMSFlexGrid((Me.MSFlexGrid2), DBCnnStr, sqlCtrl)
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		Me.MSFlexGrid3.set_ColWidth(1, 800)
		
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
		If isOnlyPrintNGWriteResult Then
			chkOnlyPrintNGWriteResult.CheckState = System.Windows.Forms.CheckState.Checked
		Else
			chkOnlyPrintNGWriteResult.CheckState = System.Windows.Forms.CheckState.Unchecked
		End If
		If isOnlyPrintNGFlow Then
			chkPrintNGFlow.CheckState = System.Windows.Forms.CheckState.Checked
		Else
			chkPrintNGFlow.CheckState = System.Windows.Forms.CheckState.Unchecked
		End If
		
		txtMdl.Text = mdlValue
		txtPreMin.Text = preMinValue
		txtPreMax.Text = preMaxValue
		txtTempMin.Text = tempMinValue
		txtTempMax.Text = tempMaxValue
		txtAcSpeedMin.Text = acSpeedMinValue
		txtAcSpeedMax.Text = acSpeedMaxValue
		txtMtocStartIndex.Text = mTOCStartIndex
		txtMTOCLen.Text = tPMSCodeLen
		
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
	End Sub
	
	'******************************************************************************
	'** �� �� ����showMSFlexGrid
	'** ��    �룺
	'** ��    ����
	'** ������������ʾ���
	'** ȫ�ֱ�����
	'** ��    �ߣ�yangshuai
	'** ��    �䣺shuaigoplay@live.cn
	'** ��    �ڣ�2009-2-27
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
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
		MsgBox("��ʾ���ݳ���������Ϣ��" & Err.Description)
	End Sub
	Private Sub setColWidth(ByRef msFG As AxMSFlexGridLib.AxMSFlexGrid, ByRef cols As Short)
		Dim i As Short
		With msFG
			.set_ColWidth(0, 0)
			.set_ColWidth(1, 800)
			For i = 2 To cols - 1 'Ϊÿ���е��н�������
				.set_ColWidth(i, 1500) '�еĿ��,�Ժ��Լ�����
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
	'** �� �� ����updateParam
	'** ��    �룺
	'** ��    ����
	'** �����������޸�����
	'** ȫ�ֱ�����
	'** ��    �ߣ�yangshuai
	'** ��    �䣺shuaigoplay@live.cn
	'** ��    �ڣ�2009-2-27
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
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
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
	End Sub
	
	
	'******************************************************************************
	'** �� �� ����loadCombo����Combo�ؼ�����
	'** ��    �룺
	'** ��    ����
	'** �����������޸�����
	'** ȫ�ֱ�����
	'** ��    �ߣ�yangshuai
	'** ��    �䣺shuaigoplay@live.cn
	'** ��    �ڣ�2009-2-27
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
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
		MsgBox("���ش��󣡴�����Ϣ��" & Err.Description)
		
	End Sub
	Private Sub MSFlexGrid3_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MSFlexGrid3.ClickEvent
		On Error Resume Next
		txtTPMSID.Text = Me.MSFlexGrid3.get_TextMatrix(Me.MSFlexGrid3.Row, 1)
		txtTPMSCode.Text = Me.MSFlexGrid3.get_TextMatrix(Me.MSFlexGrid3.Row, 2)
	End Sub
	Public Function readRunParam(ByRef key As String, ByRef group As String) As String
		On Error Resume Next
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select ""Value"" from ""T_RunParam"" where ""Key""='" & key & "' and ""Group""='" & group & "'")
		readRunParam = rs.Fields("Value").Value
		rs.Close()
		'UPGRADE_NOTE: �ڶԶ��� rs ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		rs = Nothing
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
	End Function
	Public Function updateRunParam(ByRef value As String, ByRef group As String, ByRef key As String) As Object
		On Error Resume Next
		Dim cnn As New ADODB.Connection
		cnn.Open(DBCnnStr)
		cnn.Execute("update ""T_RunParam"" set ""Value""='" & value & "'  where ""Key""='" & key & "' and ""Group""='" & group & "'")
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
	End Function
End Class