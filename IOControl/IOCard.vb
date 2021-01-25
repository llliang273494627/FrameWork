Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("IOCard_NET.IOCard")> Public Class IOCard
	'******************************************************************************
	'** �ļ�����IOCard.cls
	'** ��  Ȩ��CopyRight (c) 2009-2011 �人��������ϵͳ���޹�˾
	'** �����ˣ�hexiaoqin
	'** ��  �䣺
	'** ��  �ڣ�2009-03-05
	'** �޸��ˣ�
	'** ��  �ڣ�2009-03-05
	'** ��  ����
	'**
	'** ��  ����1.0
	'******************************************************************************
	'Option Explicit
	Private DIWordState(15) As Boolean '���ڽ��������״̬
	Private DIState(15) As Boolean '���ڽ��������״̬
	Private TestMing As String '���ڴ��IO����ַ
	Private DiValue As Short 'ȡ����״ֵ̬
	Private iPreVal As Short '������м����
	Private iPreVal1 As Short '������м����
	Event EventTest(ByRef testPort As System.Array)
	Private WithEvents m_timer As System.Windows.Forms.Timer

	'******************************************************************************
	'** �� �� ����ShowPortChang
	'** ��    �룺
	'** ��    ����IO�����״̬
	'** ���������������ṩ�ⲿ��ѯIO�����״̬
	'** ȫ�ֱ�����
	'** ����ģ�飺
	'** ��    �ߣ�hexiaoqin
	'** ��    �䣺
	'** ��    �ڣ�2009-03-05
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	Private Sub ShowPortChang()
		Dim raiseE As Boolean
		raiseE = True
		Dim i As Short
		For i = 0 To 15
			If DIWordState(i) <> DIState(i) Then
				raiseE = False
				'       MsgBox "portChang"
			End If
			DIWordState(i) = DIState(i)
		Next i
		If Not raiseE Then
			RaiseEvent EventTest(DIWordState)
		End If
	End Sub

	'******************************************************************************
	'** �� �� ����IniStallCard
	'** ��    �룺
	'** ��    ����
	'** ������������ʼ��IO��
	'** ȫ�ֱ�����
	'** ����ģ�飺
	'** ��    �ߣ�hexiaoqin
	'** ��    �䣺
	'** ��    �ڣ�2009-03-05
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	Private Sub IniStallCard()
		Dim gnNumOfDevices As Short
		Dim nOutEntries As Short
		Dim i As Object
		Dim ii As Short
		Dim tt As Integer
		Dim tempStr As String

		' Add type of PC Laboratory Card
		'UPGRADE_WARNING: δ�ܽ������� devicelist(0) ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		tt = DRV_GetAddress(0) 'ɨ���豸
		ErrCde = DRV_DeviceGetList(tt, MaxEntries, nOutEntries)
		If (ErrCde <> 0) Then
			DRV_GetErrorMessage(ErrCde, szErrMsg.Value)
			'Response = MsgBox(szErrMsg, vbOKOnly, "Error!!")
			Exit Sub
		End If

		ErrCde = DRV_DeviceGetNumOfList(gnNumOfDevices) 'ɨ���豸��
		If (ErrCde <> 0) Then
			DRV_GetErrorMessage(ErrCde, szErrMsg.Value)
			'Response = MsgBox(szErrMsg, vbOKOnly, "Error!!")
			Exit Sub
		End If

		For i = 0 To (gnNumOfDevices - 1) 'ɨ���豸��ַ
			tempStr = ""
			For ii = 0 To MaxDevNameLen
				'UPGRADE_WARNING: δ�ܽ������� i ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				tempStr = tempStr & Chr(devicelist(i).szDeviceName(ii))
			Next ii
			TestMing = Mid(tempStr, 1, 16)
			Debug.Print(TestMing)
		Next i
		Call GetDevice()
	End Sub

	'******************************************************************************
	'** �� �� ����GetDevice
	'** ��    �룺
	'** ��    ����
	'** ����������ȡIO����һЩ����������730
	'** ȫ�ֱ�����
	'** ����ģ�飺
	'** ��    �ߣ�hexiaoqin
	'** ��    �䣺
	'** ��    �ڣ�2009-03-05
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	Private Sub GetDevice()
		Dim temp As String
		Dim i As Object
		Dim tempNum As Short
		Dim TestRes As Boolean
		Dim gnNumOfSubdevices As Short
		Dim dwDeviceNum As Integer

		TestRes = TestStr(TestMing, "DEMO")
		If (Not TestRes) Then
			' Check if there is any device attatched on this COM port or CAN
			gnNumOfSubdevices = devicelist(0).nNumOfSubdevices
			If (gnNumOfSubdevices > MaxDev) Then
				gnNumOfSubdevices = MaxDev
			End If

			' retrieve the information of all installed devices

			If (gnNumOfSubdevices = 0) Then
				dwDeviceNum = devicelist(0).dwDeviceNum
				ErrCde = DRV_DeviceOpen(dwDeviceNum, DeviceHandle)
				If (ErrCde <> 0) Then
					DRV_GetErrorMessage(ErrCde, szErrMsg.Value)
					'Response = MsgBox(szErrMsg, vbOKOnly, "Error!!")
					Exit Sub
				Else
					bRun = True
				End If

				'UPGRADE_WARNING: δ�ܽ������� lpDevFeatures ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				ptDevGetFeatures.buffer = DRV_GetAddress(lpDevFeatures)
				ErrCde = DRV_DeviceGetFeatures(DeviceHandle, ptDevGetFeatures)
				If (ErrCde <> 0) Then
					DRV_GetErrorMessage(ErrCde, szErrMsg.Value)
					'Response = MsgBox(szErrMsg, vbOKOnly, "Error!!")
					Exit Sub
				End If
				tempNum = (lpDevFeatures.usMaxDOChl + 7) \ 8
				For i = 0 To (tempNum - 1)
					'UPGRADE_WARNING: δ�ܽ������� i ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					temp = "Port#" & Str(i)
				Next i
			End If
		End If
	End Sub

	'******************************************************************************
	'** �� �� ����TestStr
	'** ��    �룺��ַ�룬״̬��
	'** ��    ����
	'** �����������ֽ��IO���ĵ�ǰ��ַ��
	'** ȫ�ֱ�����
	'** ����ģ�飺
	'** ��    �ߣ�hexiaoqin
	'** ��    �䣺
	'** ��    �ڣ�2009-03-05
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	Private Function TestStr(ByRef DStr As String, ByRef TStr As String) As Boolean
		Dim lenD As Object
		Dim lenT As Short
		Dim i As Short

		TestStr = False
		'UPGRADE_WARNING: δ�ܽ������� lenD ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		lenD = Len(DStr)
		lenT = Len(TStr)

		'UPGRADE_WARNING: δ�ܽ������� lenD ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		For i = 1 To (lenD - lenT + 1)
			If (Mid(DStr, i, lenT) = TStr) Then
				TestStr = True
			End If
		Next i

		If DStr = "" Then
			TestStr = True
		End If
	End Function

	'******************************************************************************
	'** �� �� ����GetPortValue
	'** ��    �룺IO��ͨ����
	'** ��    ����
	'** �������������ڻ�ȡIO���ĵ�ǰ״ֵ̬
	'** ȫ�ֱ�����
	'** ����ģ�飺
	'** ��    �ߣ�hexiaoqin
	'** ��    �䣺
	'** ��    �ڣ�2009-03-05
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	Private Sub GetPortValue(ByRef PortAddress As Short)
		lpDioPortMode.Port = PortAddress
		lpDioPortMode.dir_Renamed = INPORT
		If lpDevFeatures.usDIOPort > 0 Then
			ErrCde = DRV_DioSetPortMode(DeviceHandle, lpDioPortMode)
			If (ErrCde <> 0) Then
				DRV_GetErrorMessage(ErrCde, szErrMsg.Value)
				'Response = MsgBox(szErrMsg, vbOKOnly, "Error!!")
				Exit Sub
			End If
		End If

		lpDioReadPort.Port = PortAddress
		lpDioReadPort.value = DRV_GetAddress(DiValue)
		ErrCde = DRV_DioReadPortByte(DeviceHandle, lpDioReadPort)
		If (ErrCde <> 0) Then
			DRV_GetErrorMessage(ErrCde, szErrMsg.Value)
			'Response = MsgBox(szErrMsg, vbOKOnly, "Error!!")
			Exit Sub
		End If
		Call UpdateLed(PortAddress, DiValue)
	End Sub

	'******************************************************************************
	'** �� �� ����ActivateCard
	'** ��    �룺IO��ͨ���ţ���ǰIO����״ֵ̬
	'** ��    ����
	'** ������������Ҫ���ڸ�������״̬
	'** ȫ�ֱ�����
	'** ����ģ�飺
	'** ��    �ߣ�hexiaoqin
	'** ��    �䣺
	'** ��    �ڣ�2009-03-05
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	Private Sub UpdateLed(ByRef AddressNO As Short, ByRef iValue As Short)
		Dim i As Object
		Dim iShift As Short
		iShift = 1
		If AddressNO = 0 Then
			For i = 0 To 7
				If (iValue And iShift) <> (iPreVal And iShift) Then
					If (iValue And iShift) = iShift Then
						'UPGRADE_WARNING: δ�ܽ������� i ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						DIState(i) = True
					Else
						'UPGRADE_WARNING: δ�ܽ������� i ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						DIState(i) = False
					End If
				End If
				iShift = iShift * 2
			Next 
			iPreVal = iValue
		ElseIf AddressNO = 1 Then 
			For i = 0 To 7
				If (iValue And iShift) <> (iPreVal1 And iShift) Then
					If (iValue And iShift) = iShift Then
						'UPGRADE_WARNING: δ�ܽ������� i ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						DIState(i + 8) = True
					Else
						'UPGRADE_WARNING: δ�ܽ������� i ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						DIState(i + 8) = False
					End If
				End If
				iShift = iShift * 2
			Next 
			iPreVal1 = iValue
		End If
	End Sub

	Public Sub New()
		MyBase.New()
		Call IniStallCard()
		m_timer = New Timer
		m_timer.Enabled = True
		m_timer.Interval = 100
		m_timer.Start()
	End Sub
	
	Private Sub m_timer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_timer.Tick
		Call GetPortValue(0)
		Call GetPortValue(1)
		ShowPortChang()
	End Sub
End Class