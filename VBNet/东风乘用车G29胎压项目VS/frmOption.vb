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
	Dim sqlMaterialCode As String
	
	
	'�޸�TPMS��������ʼλ����Ϣ
	Private Sub btMTOCModi_Click()
		'On Error GoTo Err
		'    If txtMtocStartIndex.text = "" Then
		'        MsgBox "TPMS��������ʼλ�ò���Ϊ��!"
		'        txtMtocStartIndex.SetFocus
		'        Exit Sub
		'    End If
		'
		'    If txtMTOCLen.text = "" Then
		'        MsgBox "TPMS�����볤����Ϊ��!"
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
		'    MsgBox "TPMS��������ʼλ����Ϣ�޸ĳɹ�!"
		'
		'    Exit Sub
		'Err:
		'    LogWritter "�޸�TPMS��������ʼλ����Ϣʱʧ�ܣ�����:" & Err.Description
		'    MsgBox "TPMS��������ʼλ����Ϣ�޸�ʧ��!" & Err.Description
	End Sub
	'��ӳ��ͱ������
	Private Sub bt_MTCodeAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bt_MTCodeAdd.Click
		On Error GoTo Err_Renamed
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		If StrConv(txt_CodeStartIndex.Text, VbStrConv.UpperCase) = "" Then
			MsgBox("��ʼλ�ò���Ϊ��")
			Exit Sub
		ElseIf StrConv(txt_CodeLen.Text, VbStrConv.UpperCase) = "" Then 
			MsgBox("���Ȳ���Ϊ��")
			Exit Sub
		ElseIf StrConv(txt_MatchLetter.Text, VbStrConv.UpperCase) = "" Then 
			MsgBox("��ĸ����Ϊ��")
			Exit Sub
		ElseIf StrConv(txt_CarType.Text, VbStrConv.UpperCase) = "" Then 
			MsgBox("���Ͳ���Ϊ��")
			Exit Sub
		ElseIf StrConv(txt_ifTPMS.Text, VbStrConv.UpperCase) = "" Then 
			MsgBox("̥ѹ����Ϊ��")
			Exit Sub
		ElseIf StrConv(txt_ifTPMS.Text, VbStrConv.UpperCase) <> "0" And StrConv(txt_ifTPMS.Text, VbStrConv.UpperCase) <> "1" Then 
			MsgBox("̥ѹ��д����")
			Exit Sub
		End If
		Dim xxx As String
		xxx = "select ""CarType"" from ""cartype_tpms"" where Upper(""CodeStartIndex"")='" & StrConv(txt_CodeStartIndex.Text, VbStrConv.UpperCase) & "' and Upper(""CodeLen"")='" & StrConv(txt_CodeLen.Text, VbStrConv.UpperCase) & "' and Upper(""MatchLetter"")='" & StrConv(txt_MatchLetter.Text, VbStrConv.UpperCase) & "'"
		rs = cnn.Execute("select ""CarType"" from ""cartype_tpms"" where Upper(""CodeStartIndex"")='" & StrConv(txt_CodeStartIndex.Text, VbStrConv.UpperCase) & "' and Upper(""CodeLen"")='" & StrConv(txt_CodeLen.Text, VbStrConv.UpperCase) & "' and Upper(""MatchLetter"")='" & StrConv(txt_MatchLetter.Text, VbStrConv.UpperCase) & "'")
		If Not rs.EOF Then
			MsgBox("�ù����Ѿ�ƥ��!")
			Exit Sub
		End If
		xxx = "insert into ""cartype_tpms"" (""CodeStartIndex"",""CodeLen"",""MatchLetter"",""CarType"",""ifTPMS"") values ('" & txt_CodeStartIndex.Text & "','" & txt_CodeLen.Text & "','" & txt_MatchLetter.Text & "','" & txt_CarType.Text & "','" & txt_ifTPMS.Text & "')"
		cnn.Execute("insert into ""cartype_tpms"" (""CodeStartIndex"",""CodeLen"",""MatchLetter"",""CarType"",""ifTPMS"") values ('" & txt_CodeStartIndex.Text & "','" & txt_CodeLen.Text & "','" & txt_MatchLetter.Text & "','" & txt_CarType.Text & "','" & txt_ifTPMS.Text & "')")
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
		
		showMSFlexGrid((Me.MSFlexGrid4), DBCnnStr, sqlMaterialCode)
		MsgBox("���������ɹ�!")
		Exit Sub
Err_Renamed: 
		LogWritter("��������ʱʧ�ܣ�����:" & Err.Description)
		MsgBox("��������ʧ��!" & Err.Description)
	End Sub
	'ȡ��
	Private Sub bt_MTCodeCancle_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bt_MTCodeCancle.Click
		Me.Close()
	End Sub
	'ɾ�����ͱ������
	Private Sub bt_MTCodeDel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bt_MTCodeDel.Click
		On Error GoTo Err_Renamed
		Dim msgR As Short
		msgR = MsgBox("�Ƿ�ɾ���ó������ã���ţ�" & txt_CarType.Text & "��", MsgBoxStyle.YesNo, "ϵͳ��ʾ")
		If msgR = 7 Then Exit Sub
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		cnn.Execute("delete from ""cartype_tpms"" where ""ID""=" & txt_MTID.Text & "")
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
		showMSFlexGrid((Me.MSFlexGrid4), DBCnnStr, sqlMaterialCode)
		MsgBox("���ͱ������ɾ���ɹ�!")
		txt_MTID.Text = ""
		txt_CodeStartIndex.Text = ""
		txt_CodeLen.Text = ""
		txt_MatchLetter.Text = ""
		txt_CarType.Text = ""
		txt_ifTPMS.Text = ""
		Exit Sub
Err_Renamed: 
		LogWritter("ɾ�����ͱ������ʱʧ�ܣ�����:" & Err.Description)
		MsgBox("���ͱ������ɾ��ʧ��!" & Err.Description)
	End Sub
	'�޸ĳ��ͱ������
	Private Sub bt_MTCodeModi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bt_MTCodeModi.Click
		On Error GoTo Err_Renamed
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		If StrConv(txt_ifTPMS.Text, VbStrConv.UpperCase) <> "0" And StrConv(txt_ifTPMS.Text, VbStrConv.UpperCase) <> "1" Then
			MsgBox("̥ѹ��д����")
			Exit Sub
		End If
		cnn.Open(DBCnnStr)
		
		cnn.Execute("update ""cartype_tpms"" set ""CodeStartIndex""='" & txt_CodeStartIndex.Text & "',""CodeLen""='" & txt_CodeLen.Text & "',""MatchLetter""='" & txt_MatchLetter.Text & "',""CarType""='" & txt_CarType.Text & "',""ifTPMS""='" & txt_ifTPMS.Text & "' where ""ID""=" & txt_MTID.Text & "")
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
		
		showMSFlexGrid((Me.MSFlexGrid4), DBCnnStr, sqlMaterialCode)
		MsgBox("���ϺŹ����޸ĳɹ�!")
		Exit Sub
Err_Renamed: 
		LogWritter("�޸����ϺŹ���ʱʧ�ܣ�����:" & Err.Description)
		MsgBox("���ϺŹ����޸�ʧ��!" & Err.Description)
	End Sub
	
	'���������
	Private Sub btTPMSAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btTPMSAdd.Click
		On Error GoTo Err_Renamed
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		If StrConv(txtCarType.Text, VbStrConv.UpperCase) = "" Then
			MsgBox("���Ͳ���Ϊ��")
			Exit Sub
		ElseIf StrConv(txtCarType.Text, VbStrConv.UpperCase) = "" Then 
			MsgBox("����Ų���Ϊ��")
			Exit Sub
		End If
		Dim xxx As String
		xxx = "select ""CarType"" from ""cartype_prono"" where Upper(""CarType"")='" & StrConv(txtCarType.Text, VbStrConv.UpperCase) & "'"
		rs = cnn.Execute("select ""CarType"" from ""cartype_prono"" where Upper(""CarType"")='" & StrConv(txtCarType.Text, VbStrConv.UpperCase) & "'")
		If Not rs.EOF Then
			MsgBox("�ó����Ѿ����ó����!")
			Exit Sub
		End If
		xxx = "insert into ""cartype_prono"" (""CarType"",""ProNum"") values ('" & txtCarType.Text & "','" & txtProNum.Text & "')"
		cnn.Execute("insert into ""cartype_prono"" (""CarType"",""ProNum"") values ('" & txtCarType.Text & "','" & txtProNum.Text & "')")
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
		
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		MsgBox("����������ɹ�!")
		Exit Sub
Err_Renamed: 
		LogWritter("���������ʱʧ�ܣ�����:" & Err.Description)
		MsgBox("���������ʧ��!" & Err.Description)
	End Sub
	
	Private Sub btTPMSCancle_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btTPMSCancle.Click
		Me.Close()
	End Sub
	'ɾ�������
	Private Sub btTPMSDel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btTPMSDel.Click
		On Error GoTo Err_Renamed
		Dim msgR As Short
		msgR = MsgBox("�Ƿ�ɾ���ó��͵ĳ����" & txtCarType.Text & "��", MsgBoxStyle.YesNo, "ϵͳ��ʾ")
		If msgR = 7 Then Exit Sub
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		cnn.Execute("delete from ""cartype_prono"" where ""ID""=" & txtTPMSID.Text & "")
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		MsgBox("�����ɾ���ɹ�!")
		txtTPMSID.Text = ""
		txtCarType.Text = ""
		txtProNum.Text = ""
		Exit Sub
Err_Renamed: 
		LogWritter("ɾ�������ʱʧ�ܣ�����:" & Err.Description)
		MsgBox("�����ɾ��ʧ��!" & Err.Description)
	End Sub
	
	'�޸ĳ����
	Private Sub btTPMSModi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btTPMSModi.Click
		On Error GoTo Err_Renamed
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		
		'    Set rs = cnn.Execute("select ""CarType"" from ""cartype_prono"" where Upper(""CarType"")='" & StrConv(txtCarType.text, vbUpperCase) & "'")
		'    If Not rs.EOF Then
		'        MsgBox "�ó��ͳ�����Ѵ���!"
		'        Exit Sub
		'    End If
		
		cnn.Execute("update ""cartype_prono"" set ""CarType""='" & txtCarType.Text & "',""ProNum""='" & txtProNum.Text & "' where ""ID""=" & txtTPMSID.Text & "")
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
		
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		MsgBox("������޸ĳɹ�!")
		Exit Sub
Err_Renamed: 
		LogWritter("�޸ĳ����ʱʧ�ܣ�����:" & Err.Description)
		MsgBox("������޸�ʧ��!" & Err.Description)
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
	Private Sub chkOnlyPrintNGWriteResult_Click()
		'    If chkOnlyPrintNGWriteResult.value = vbChecked Then
		'        isOnlyPrintNGWriteResult = True
		'        Call updateRunParam(1, "Print", "OnlyPrintNGWriteResult")
		'    Else
		'        isOnlyPrintNGWriteResult = False
		'        Call updateRunParam(0, "Print", "OnlyPrintNGWriteResult")
		'    End If
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
	Private Sub chkPrintNGFlow_Click()
		'    If chkPrintNGFlow.value = vbChecked Then
		'        isOnlyPrintNGFlow = True
		'        Call updateRunParam(1, "Print", "OnlyPrintNGFlow")
		'    Else
		'        isOnlyPrintNGFlow = False
		'        Call updateRunParam(0, "Print", "OnlyPrintNGFlow")
		'    End If
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
	
	Private Sub Command11_Click()
		On Error GoTo Err_Renamed
		Dim msgR As Short
		msgR = MsgBox("�Ƿ�ɾ�������Ϻŵı������" & txtCarType.Text & "��", MsgBoxStyle.YesNo, "ϵͳ��ʾ")
		If msgR = 7 Then Exit Sub
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		cnn.Execute("delete from ""cartype_tpms"" where ""ID""=" & txt_MTID.Text & "")
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		MsgBox("���ϺŹ���ɾ���ɹ�!")
		Exit Sub
Err_Renamed: 
		LogWritter("���ϺŹ���ɾ��ʱʧ�ܣ�����:" & Err.Description)
		MsgBox("���ϺŹ���ɾ��ʧ��!" & Err.Description)
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
	
	'�ֶ������Ų��������� ����id����
	Private Sub Command5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command5.Click
		On Error GoTo Err_Renamed
		'�����MESϵͳPing��ͨ���˳�ͬ������
		If Not Ping(MES_IP) Then
			MsgBox("������ϣ����Ų�")
			Exit Sub
		End If
		'ͬ����������
		LogWritter("����ͬ����������")
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
		'�жϱ����Ƿ��������
		LogWritter("�жϱ����Ƿ��������") '--------------------------------------------------------------------
		strSQL = "select count(0) from vinlist;"
		objRs.Open(strSQL, objConn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		existRecord = objRs.Fields(0).value
		'�ر���������
		If Not objRs Is Nothing Then
			If objRs.state = 1 Then
				objRs.Close()
			End If
		End If
		'������MESϵͳ�ϵ������Ӿ�
		Dim maxGatherDate As String
		Dim formatTimeString As String
		'�������û��������ȫ������
		LogWritter("�������û��������ȫ������") '--------------------------------------------------------------------
		If CDbl(existRecord) = 0 Then
			maxGatherDate = " order by id"
			LogWritter("����û�г��ʹ��룬����MES�������ϻ�ȡ")
		Else '����������������������µ�
			strSQL = "SELECT max(""id"") FROM vinlist;"
			objRs.Open(strSQL, objConn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
			formatTimeString = objRs.Fields(0).value
			maxGatherDate = " where id > " & formatTimeString & " order by id"
			'�ر���������
			If Not objRs Is Nothing Then
				If objRs.state = 1 Then
					objRs.Close()
				End If
			End If
			LogWritter("�������³���idΪ" & formatTimeString)
		End If
		'��ʼ����
		objConnMES = New ADODB.Connection
		objRsMES = New ADODB.Recordset
		objConnMES.ConnectionTimeout = 3
		objConnMES.Open(MESCnnStr)
		'.....................................���SQL�ǲ����õģ�����
		'strSQL = "select * from system.car_prc_seq_v" & maxGatherDate
		strSQL = "select * from ACTIA_VINLIST" & maxGatherDate
		objRsMES.Open(strSQL, objConnMES, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		'ȡ�ó��ͼ�¼������ֵ
		Dim categoryLimit As String
		categoryLimit = getConfigValue("T_RunParam", "Status", "CategoryLimit")
		LogWritter("ȡ�ó��ͼ�¼������ֵ" & categoryLimit)
		Dim i As Short
		i = 0
		'��ѯ���������ݸ��µ�����
		System.Windows.Forms.Application.DoEvents()
		If objRsMES.EOF Then
			LogWritter("MES��������û�бȱ����µ�����")
		Else
			LogWritter("MES�������ϴ��ڱȱ����µ�����")
			'��ͬ������������д�뱾��
			Do While Not objRsMES.EOF
				On Error GoTo InsideErr
				System.Windows.Forms.Application.DoEvents()
				'�Ȳ�ѯ�����Ƿ���������¼
				strSQL = "SELECT * FROM vinlist where vin = '" & objRsMES.Fields("VIN").Value & "'"
				objRs.Open(strSQL, objConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
				'���û�������
				If objRs.RecordCount <= 0 Then
					strSQL = "INSERT INTO vinlist(""id"",""vin"", ""tpms"", ""carcode"",""optioncode"",""time"") VALUES ('" & objRsMES.Fields("ID").Value & "','" & objRsMES.Fields("VIN").Value & "', '" & objRsMES.Fields("TPMS").Value & "', '" & objRsMES.Fields("CARCODE").Value & "', '" & objRsMES.Fields("OPTIONCODE").Value & "','" & objRsMES.Fields("TIME").Value & "');"
					LogWritter("����" & objRsMES.Fields("VIN").Value)
					i = i + 1
				Else
					strSQL = "UPDATE vinlist SET ""id""='" & objRsMES.Fields("ID").Value & "',""vin""='" & objRsMES.Fields("VIN").Value & "', ""tpms""='" & objRsMES.Fields("TPMS").Value & "', ""carcode""='" & objRsMES.Fields("CARCODE").Value & "',optioncode='" & objRsMES.Fields("OPTIONCODE").Value & "', ""time""='" & objRsMES.Fields("TIME").Value & "' WHERE vin = '" & objRsMES.Fields("VIN").Value & "';"
					LogWritter("����" & objRsMES.Fields("VIN").Value)
				End If
				objConn.Execute(strSQL)
InsideErr: 
				'�رձ������ݼ�
				If Not objRs Is Nothing Then
					If objRs.state = 1 Then
						objRs.Close()
					End If
				End If
				'������һ������
				objRsMES.MoveNext()
				LogWritter("ѭ��һ�ε�ʱ��") '--------------------------------------------------------------------
				'�����������ת��ɾ���߼�
				If i >= CDbl(categoryLimit) Then
					GoTo DeleteRecords
				End If
				System.Windows.Forms.Application.DoEvents()
			Loop 
		End If
		'ɾ�����س�������������
DeleteRecords: 
		strSQL = "delete from vinlist where ""id"" < (select ""id"" from vinlist where ""id"" in (select ""id"" from vinlist order by ""id"" desc limit " & categoryLimit & ") order by ""id"" limit 1)"
		'strSQL = "delete from vinlist where ""sortid"" < (select ""sortid"" from vinlist where ""sortid"" in (select ""sortid"" from vinlist order by ""sortid"" desc limit " & categoryLimit & ") order by ""sortid"" limit 1)"
		objConn.Execute(strSQL)
		LogWritter("ɾ����������ݳɹ�")
		'�ر�MES���ݼ�
		If Not objRsMES Is Nothing Then
			If objRsMES.state = 1 Then
				objRsMES.Close()
			End If
		End If
		'�رձ�������
		If Not objConn Is Nothing Then
			If objConn.state = 1 Then
				objConn.Close()
			End If
		End If
		'�ر�MES����
		If Not objConnMES Is Nothing Then
			If objConnMES.state = 1 Then
				objConnMES.Close()
			End If
		End If
		
		'UPGRADE_NOTE: �ڶԶ��� objRs ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objRs = Nothing
		'UPGRADE_NOTE: �ڶԶ��� objRsMES ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objRsMES = Nothing
		'UPGRADE_NOTE: �ڶԶ��� objConn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objConn = Nothing
		'UPGRADE_NOTE: �ڶԶ��� objConnMES ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objConnMES = Nothing
		
		LogWritter("��������ͬ�����")
		MsgBox("��������ͬ�����")
		Exit Sub
Err_Renamed: 
		'�رձ������ݼ�
		If Not objRs Is Nothing Then
			If objRs.state = 1 Then
				objRs.Close()
			End If
		End If
		'�ر�MES���ݼ�
		If Not objRsMES Is Nothing Then
			If objRsMES.state = 1 Then
				objRsMES.Close()
			End If
		End If
		'�رձ�������
		If Not objConn Is Nothing Then
			If objConn.state = 1 Then
				objConn.Close()
			End If
		End If
		'�ر�MES����
		If Not objConnMES Is Nothing Then
			If objConnMES.state = 1 Then
				objConnMES.Close()
			End If
		End If
		
		'UPGRADE_NOTE: �ڶԶ��� objRs ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objRs = Nothing
		'UPGRADE_NOTE: �ڶԶ��� objRsMES ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objRsMES = Nothing
		'UPGRADE_NOTE: �ڶԶ��� objConn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objConn = Nothing
		'UPGRADE_NOTE: �ڶԶ��� objConnMES ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objConnMES = Nothing
		
		LogWritter(Err.Description & Err.Source)
		MsgBox("��������ͬ��ʧ�ܣ���鿴��־")
	End Sub
	''�ֶ������Ų��������� ����ʱ������
	'Private Sub Command5_Click()
	'On Error GoTo Err:
	'     '�����MESϵͳPing��ͨ���˳�ͬ������
	'    If Not Ping(MES_IP) Then
	'        MsgBox "������ϣ����Ų�"
	'        Exit Sub
	'    End If
	'    'ͬ����������
	'    LogWritter "����ͬ����������"
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
	'    '�жϱ����Ƿ��������
	'    strSQL = "select count(0) from vinlist;"
	'    objRs.Open strSQL, objConn, adOpenKeyset, adLockOptimistic
	'    existRecord = objRs.Fields(0).value
	'    '�ر���������
	'    If Not objRs Is Nothing Then
	'        If objRs.state = 1 Then
	'            objRs.Close
	'        End If
	'    End If
	'    '������MESϵͳ�ϵ������Ӿ�
	'    Dim maxGatherDate As String
	'    Dim formatTimeString As String
	'    '�������û��������ȫ������
	'    If existRecord = 0 Then
	'        maxGatherDate = " order by LAST_UPDATE_DATE"
	'        'maxGatherDate = " where SITES_CODE='5A1560' order by SEQ_NO"
	'        LogWritter "����û�г��ʹ��룬����MES�������ϻ�ȡ"
	'    Else '����������������������µ�
	'        strSQL = "SELECT max(""LAST_UPDATE_DATE"") FROM vinlist;"
	'        'strSQL = "SELECT max(""sortid"") FROM vinlist;"
	'        objRs.Open strSQL, objConn, adOpenKeyset, adLockOptimistic
	'        'formatTimeString = objRs.Fields(0).value
	'       formatTimeString = objRs.Fields(0).value
	'       formatTimeString = Replace(formatTimeString, "���� ", "")
	'       formatTimeString = Replace(formatTimeString, "AM ", "")
	'       formatTimeString = Replace(formatTimeString, "���� ", "")
	'       formatTimeString = Replace(formatTimeString, "PM ", "")
	'       maxGatherDate = " where SITES_CODE='5A1560' and LAST_UPDATE_DATE > to_date('" & formatTimeString & "','yyyy-MM-dd HH24:mi:ss') order by LAST_UPDATE_DATE"
	'       ' maxGatherDate = " where SITES_CODE='5A1560' and SEQ_NO > " & formatTimeString & " order by SEQ_NO"
	'        '�ر���������
	'        If Not objRs Is Nothing Then
	'            If objRs.state = 1 Then
	'                objRs.Close
	'            End If
	'        End If
	'        LogWritter "�������³��ʹ����ʱ��Ϊ" & formatTimeString
	'        'LogWritter "�������³��ʹ���ĳ���Ϊ" & formatTimeString
	'    End If
	'    '��ʼ����
	'    Set objConnMES = New Connection
	'    Set objRsMES = New Recordset
	'    objConnMES.ConnectionTimeout = 3
	'    objConnMES.Open MESCnnStr
	'    '.....................................���SQL�ǲ����õģ�����
	'    'strSQL = "select * from system.car_prc_seq_v" & maxGatherDate
	'    strSQL = "select * from car_prc_seq_v" & maxGatherDate
	'    objRsMES.Open strSQL, objConnMES, adOpenKeyset, adLockOptimistic
	'    'ȡ�ó��ͼ�¼������ֵ
	'    Dim categoryLimit As String
	'    categoryLimit = getConfigValue("T_RunParam", "Status", "CategoryLimit")
	'    LogWritter "ȡ�ó��ͼ�¼������ֵ" & categoryLimit
	'    Dim i As Integer
	'    i = 0
	'    '��ѯ���������ݸ��µ�����
	'    DoEvents
	'    If objRsMES.EOF Then
	'        LogWritter "MES��������û�бȱ����µ�����"
	'    Else
	'        LogWritter "MES�������ϴ��ڱȱ����µ�����"
	'        '��ͬ������������д�뱾��
	'        Do While Not objRsMES.EOF
	'            On Error GoTo InsideErr:
	'                DoEvents
	'                '�Ȳ�ѯ�����Ƿ���������¼
	'                strSQL = "SELECT * FROM vinlist where vin = '" & objRsMES("VIN_CODE") & "'"
	'                objRs.Open strSQL, objConn, adOpenStatic, adLockOptimistic
	'                '���û�������
	'                If objRs.RecordCount <= 0 Then
	'                    strSQL = "INSERT INTO vinlist(""LINE_CODE"", ""SITES_CODE"", ""BODY_NUMBER"", vin, carcode, ""OPTION_CODE"", ""ATTRIBUTE_CODE"", sortid, ""WORK_DATE"", ""LAST_UPDATE_DATE"", tpms) VALUES ('" & objRsMES("LINE_CODE") & "', '" & objRsMES("SITES_CODE") & "', '" & objRsMES("BODY_NUMBER") & "', '" & objRsMES("VIN_CODE") & "', '" & objRsMES("CAR_CODE") & "','" & objRsMES("OPTION_CODE") & "','" & objRsMES("ATTRIBUTE_CODE") & "','" & objRsMES("SEQ_NO") & "','" & objRsMES("WORK_DATE") & "','" & objRsMES("LAST_UPDATE_DATE") & "','1');"
	'                    LogWritter "����" & objRsMES("VIN_CODE")
	'                    i = i + 1
	'                Else
	'                    strSQL = "UPDATE vinlist SET ""LINE_CODE""='" & objRsMES("LINE_CODE") & "', ""SITES_CODE""='" & objRsMES("SITES_CODE") & "', ""BODY_NUMBER""='" & objRsMES("BODY_NUMBER") & "',carcode='" & objRsMES("CAR_CODE") & "', ""OPTION_CODE""='" & objRsMES("OPTION_CODE") & "',""ATTRIBUTE_CODE""='" & objRsMES("ATTRIBUTE_CODE") & "',sortid='" & objRsMES("SEQ_NO") & "',""WORK_DATE""='" & objRsMES("WORK_DATE") & "',""LAST_UPDATE_DATE""='" & objRsMES("LAST_UPDATE_DATE") & "' WHERE vin = '" & objRsMES("VIN_CODE") & "';"
	'                    LogWritter "����" & objRsMES("VIN_CODE")
	'                End If
	'                objConn.Execute strSQL
	'InsideErr:
	'                '�رձ������ݼ�
	'                If Not objRs Is Nothing Then
	'                    If objRs.state = 1 Then
	'                        objRs.Close
	'                    End If
	'                End If
	'                '������һ������
	'                objRsMES.MoveNext
	'                '�����������ת��ɾ���߼�
	'                If i >= categoryLimit Then
	'                    GoTo DeleteRecords
	'                End If
	'            DoEvents
	'        Loop
	'    End If
	'    'ɾ�����س�������������
	'DeleteRecords:
	'    strSQL = "delete from vinlist where ""LAST_UPDATE_DATE"" < (select ""LAST_UPDATE_DATE"" from vinlist where ""LAST_UPDATE_DATE"" in (select ""LAST_UPDATE_DATE"" from vinlist order by ""LAST_UPDATE_DATE"" desc limit " & categoryLimit & ") order by ""LAST_UPDATE_DATE"" limit 1)"
	'    'strSQL = "delete from vinlist where ""sortid"" < (select ""sortid"" from vinlist where ""sortid"" in (select ""sortid"" from vinlist order by ""sortid"" desc limit " & categoryLimit & ") order by ""sortid"" limit 1)"
	'    objConn.Execute strSQL
	'    LogWritter "ɾ����������ݳɹ�"
	'    '�ر�MES���ݼ�
	'    If Not objRsMES Is Nothing Then
	'        If objRsMES.state = 1 Then
	'            objRsMES.Close
	'        End If
	'    End If
	'    '�رձ�������
	'    If Not objConn Is Nothing Then
	'        If objConn.state = 1 Then
	'            objConn.Close
	'        End If
	'    End If
	'    '�ر�MES����
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
	'    LogWritter "��������ͬ�����"
	'    MsgBox "��������ͬ�����"
	'    Exit Sub
	'Err:
	'    '�رձ������ݼ�
	'    If Not objRs Is Nothing Then
	'        If objRs.state = 1 Then
	'            objRs.Close
	'        End If
	'    End If
	'    '�ر�MES���ݼ�
	'    If Not objRsMES Is Nothing Then
	'        If objRsMES.state = 1 Then
	'            objRsMES.Close
	'        End If
	'    End If
	'    '�رձ�������
	'    If Not objConn Is Nothing Then
	'        If objConn.state = 1 Then
	'            objConn.Close
	'        End If
	'    End If
	'    '�ر�MES����
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
	'    MsgBox "��������ͬ��ʧ�ܣ���鿴��־"
	'End Sub
	
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
	
	Private Sub Command7_Click()
		'    If txtVin.text = "" Then
		'        MsgBox "��ӡVIN����Ϊ��!"
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
		'        MsgBox "ϵͳ�в����ڸó�����ؼ����Ϣ!"
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
	'       MsgBox "���ϱ�Ų���Ϊ��"
	'       Exit Sub
	'    ElseIf StrConv(txt_CarType.text, vbUpperCase) = "" Then
	'      MsgBox "���Ͳ���Ϊ��"
	'      Exit Sub
	'    ElseIf StrConv(txt_ifTPMS.text, vbUpperCase) = "" Then
	'      MsgBox "̥ѹ����Ϊ��"
	'      Exit Sub
	'    ElseIf txt_ifTPMS.text <> "0" Or txt_ifTPMS.text <> "1" Then
	'      MsgBox "̥ѹ��������"
	'      Exit Sub
	'    End If
	'    Dim xxx As String
	'    xxx = "select ""MaterialCode"" from ""cartype_tpms"" where Upper(""MaterialCode"")='" & StrConv(txtCarType.text, vbUpperCase) & "' "
	'    Set rs = cnn.Execute("select ""MaterialCode"" from ""cartype_tpms"" where Upper(""MaterialCode"")='" & StrConv(txtCarType.text, vbUpperCase) & "' ")
	'    If Not rs.EOF Then
	'        MsgBox "�����Ϻ��Ѿ�����!"
	'        Exit Sub
	'    End If
	'    xxx = "insert into ""cartype_tpms"" (""MaterialCode"",""CarType"",""ifTPMS"") values ('" & txt_MaterialCode.text & "','" & txt_CarType.text & "','" & txt_ifTPMS.text & "')"
	'    cnn.Execute ("insert into ""cartype_tpms"" (""MaterialCode"",""CarType"",""ifTPMS"") values ('" & txt_MaterialCode.text & "','" & txt_CarType.text & "','" & txt_ifTPMS.text & "')")
	'    cnn.Close
	'    Set cnn = Nothing
	'
	'    showMSFlexGrid Me.MSFlexGrid3, DBCnnStr, sqlTpmsCode
	'    MsgBox "���Ϻű�����������ɹ�!"
	'    Exit Sub
	'Err:
	'    LogWritter "�������ϱ���ʧ�ܣ�����:" & Err.Description
	'    MsgBox "�������ϱ���ʧ��!" & Err.Description
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
	''        MsgBox "�ó��ͳ�����Ѵ���!"
	''        Exit Sub
	''    End If
	'
	'    cnn.Execute ("update ""cartype_tpms"" set ""MaterialCode""='" & txt_MaterialCode.text & "',""CarType""='" & txt_CarType.text & "',""ifTPMS""='" & txt_ifTPMS.text & "' where ""ID""=" & txt_MTID.text & "")
	'    cnn.Close
	'    Set cnn = Nothing
	'
	'    showMSFlexGrid Me.MSFlexGrid3, DBCnnStr, sqlTpmsCode
	'    MsgBox "���ϺŹ����޸ĳɹ�!"
	'    Exit Sub
	'Err:
	'    LogWritter "���ϺŹ����޸�ʧ�ܣ�����:" & Err.Description
	'    MsgBox "���ϺŹ����޸�ʧ��!" & Err.Description
	'End Sub
	
	Private Sub frmOption_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		WindowsXPC1.InitSubClassing()
		Me.SSTab1.SelectedIndex = 0
		sqlCtrl = "Select ""ID"" as ""���"",""Group"" as ""��"",""Description"" as ""����"",""Key"" as ""�ؼ���"",""Value"" as ""ֵ"" from ""T_CtrlParam"" order by ""ID"" "
		sqlRun = "Select ""ID"" as ""���"",""Group"" as ""��"",""Description"" as ""����"",""Key"" as ""�ؼ���"",""Value"" as ""ֵ"" from ""T_RunParam"" order by ""ID"" "
		sqlTpmsCode = "select ""ID"",""ID"" as ""���"",""CarType"" as ""����"",""ProNum"" as ""�����"" from ""cartype_prono"" order by ""ID"""
		'2016.1.13���
		sqlMaterialCode = "select ""ID"",""ID"" as ""���"",""MatchLetter"" as ""ƥ�����ĸ"",""CodeStartIndex"" as ""��ʼλ��"",""CodeLen"" as ""����"",""CarType"" as ""����"",""ifTPMS"" as ""�Ƿ��̥ѹ"" from ""cartype_tpms"" order by ""ID"""
		'���������
		loadCombo((Me.ComboRun), "T_RunParam")
		showMSFlexGrid((Me.MSFlexGrid1), DBCnnStr, sqlRun)
		loadCombo((Me.ComboCtrl), "T_CtrlParam")
		showMSFlexGrid((Me.MSFlexGrid2), DBCnnStr, sqlCtrl)
		showMSFlexGrid((Me.MSFlexGrid3), DBCnnStr, sqlTpmsCode)
		showMSFlexGrid((Me.MSFlexGrid4), DBCnnStr, sqlMaterialCode) '2016.1.13���
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
				.set_ColWidth(i, 1400) '�еĿ��,�Ժ��Լ�����
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