Option Strict Off
Option Explicit On
Friend Class IOCard
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
	Private PortDOState(15) As Boolean '���ڴ��IO�����״̬
	Private DiValue As Short 'ȡ����״ֵ̬
	Private iPreVal As Short '������м����
	Private iPreVal1 As Short '������м����
	Event EventTest(ByRef testPort As System.Array)
	Private m_Form As System.Windows.Forms.Form
	'Private m_timer As Timer
	Private WithEvents m_timer As System.Windows.Forms.Timer
	
	
	Public Function getState() As Collection
		Dim col As Collection
		Dim i As Short
		col = New Collection
		For i = 0 To UBound(DIWordState)
			col.Add(DIWordState(i))
		Next 
		getState = col
	End Function
	
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
		'UPGRADE_WARNING: δ�ܽ������� devicelist() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		tt = DRV_GetAddress(devicelist(0)) 'ɨ���豸
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
	'** �� �� ����ActivateCard
	'** ��    �룺IO��ͨ���ţ�730���ж���ͨ��
	'** ��    ����
	'** �������������ǰ����ͨ��
	'** ȫ�ֱ�����
	'** ����ģ�飺
	'** ��    �ߣ�hexiaoqin
	'** ��    �䣺
	'** ��    �ڣ�2009-03-05
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	Private Sub ActivateCard(ByRef AddressNO As Short)
		Dim szszErrMsg As Object
		Dim value As Integer
		lpDioGetCurrentDoByte.Port = AddressNO
		lpDioGetCurrentDoByte.value = DRV_GetAddress(value)
		
		ErrCde = DRV_DioGetCurrentDOByte(DeviceHandle, lpDioGetCurrentDoByte)
		If (ErrCde <> 0) Then
			'UPGRADE_WARNING: δ�ܽ������� szszErrMsg ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			DRV_GetErrorMessage(ErrCde, szszErrMsg)
			'Response = MsgBox(szszErrMsg, vbOKOnly, "Error!!")
			Exit Sub
		End If
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
		Dim ii As Short
		Dim tempNum As Short
		Dim TestRes As Boolean
		Dim gnNumOfSubdevices As Short
		Dim nOutEntries As Short
		Dim lpSubDeviceList As Integer
		Dim dwDeviceNum As Integer
		
		
		' Avoid to open Advantech Demo Card
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
	'** �� �� ����DOBit
	'** ��    �룺��ǰ���ݷֽ�������
	'** ��    ����
	'** �������������ڷֽ�IO��������
	'** ȫ�ֱ�����
	'** ����ģ�飺
	'** ��    �ߣ�hexiaoqin
	'** ��    �䣺
	'** ��    �ڣ�2009-03-05
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	Private Function DOBit(ByRef bit As Short) As Short
		Dim i As Short
		
		DOBit = 1
		If bit >= 1 Then
			For i = 1 To bit
				DOBit = DOBit * 2
			Next i
		End If
		
	End Function
	'******************************************************************************
	'** �� �� ����DOBitPort
	'** ��    �룺IO��ͨ���ţ�����״̬
	'** ��    ����
	'** ����������ִ��IO�������
	'** ȫ�ֱ�����
	'** ����ģ�飺
	'** ��    �ߣ�hexiaoqin
	'** ��    �䣺
	'** ��    �ڣ�2009-03-05
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	Private Function DOBitPort(ByRef DOPort As Short, ByRef OFFState As Boolean) As Object
		Dim DoValue As Object
		Dim i As Short
		PortDOState(DOPort) = OFFState
		'UPGRADE_WARNING: δ�ܽ������� DoValue ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		DoValue = 0
		For i = 0 To 7
			If PortDOState(i) = True Then
				'UPGRADE_WARNING: δ�ܽ������� DoValue ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				DoValue = DoValue + DOBit(i)
				'  Else
				'    DoValue = DoValue + DOBit(DOPort)
			End If
		Next i
		lpDioWritePort.Port = lpDioPortMode.Port
		lpDioWritePort.Mask = 255
		'UPGRADE_WARNING: δ�ܽ������� DoValue ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		lpDioWritePort.state = DoValue
		ErrCde = DRV_DioWritePortByte(DeviceHandle, lpDioWritePort)
		If (ErrCde <> 0) Then
			DRV_GetErrorMessage(ErrCde, szErrMsg.Value)
			'Response = MsgBox(szszErrMsg, vbOKOnly, "Error!!")
			Exit Function
		End If
	End Function
	'******************************************************************************
	'** �� �� ����OutputController
	'** ��    �룺DOportNoͨ���ţ��ؿ�
	'** ��    ����
	'** �������������ⲿ�������ģ��
	'** ȫ�ֱ�����
	'** ����ģ�飺
	'** ��    �ߣ�hexiaoqin
	'** ��    �䣺
	'** ��    �ڣ�2009-03-05
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	Public Sub OutputController(ByRef DOportNo As Short, ByRef OFFState As Boolean)
		If DOportNo < 8 Then
			
			lpDioPortMode.Port = 0
			
			lpDioPortMode.dir_Renamed = OUTPORT
			
			' not every digital I/O card could use DRV_DioSetPortMode function
			If lpDevFeatures.usDIOPort > 0 Then
				ErrCde = DRV_DioSetPortMode(DeviceHandle, lpDioPortMode)
				If (ErrCde <> 0) Then
					DRV_GetErrorMessage(ErrCde, szErrMsg.Value)
					'Response = MsgBox(szErrMsg, vbOKOnly, "Error!!")
					Exit Sub
				End If
			End If
			Call ActivateCard(0)
			Call DOBitPort(DOportNo, OFFState)
		End If
		If DOportNo > 7 Then
			lpDioPortMode.Port = 1
			
			lpDioPortMode.dir_Renamed = OUTPORT
			
			' not every digital I/O card could use DRV_DioSetPortMode function
			If lpDevFeatures.usDIOPort > 0 Then
				ErrCde = DRV_DioSetPortMode(DeviceHandle, lpDioPortMode)
				If (ErrCde <> 0) Then
					DRV_GetErrorMessage(ErrCde, szErrMsg.Value)
					'Response = MsgBox(szErrMsg, vbOKOnly, "Error!!")
					Exit Sub
				End If
			End If
			Call ActivateCard(1)
			Call DOBitPort(DOportNo - 8, OFFState)
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
	'******************************************************************************
	'** �� �� ����Class_Initialize
	'** ��    �룺
	'** ��    ����
	'** ������������ʼ����
	'** ȫ�ֱ�����
	'** ����ģ�飺
	'** ��    �ߣ�hexiaoqin
	'** ��    �䣺
	'** ��    �ڣ�2009-03-05
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	'UPGRADE_NOTE: Class_Initialize �������� Class_Initialize_Renamed�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"��
	Private Sub Class_Initialize_Renamed()
		m_Form = FrmTest
		m_timer = FrmTest.Timer1
		Call IniStallCard()
		m_timer.Enabled = True
		m_timer.Interval = 100
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	Private Sub m_timer_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles m_timer.Tick
		Call GetPortValue(0)
		Call GetPortValue(1)
		ShowPortChang()
	End Sub
End Class