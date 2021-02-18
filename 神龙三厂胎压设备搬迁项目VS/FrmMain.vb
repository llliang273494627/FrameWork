Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FrmMain
    Inherits System.Windows.Forms.Form

	Dim tmpTime As String
	Dim Step1Time As Short
	Dim Step2Time As Short
	Dim Step3Time As Short
	Dim Step4Time As Short
	Dim osen0Time As String
	
	Private WithEvents osensor0 As CSensor
	Private WithEvents osensor1 As CSensor
	Private WithEvents osensor2 As CSensor
	Private WithEvents osensor3 As CSensor
	Private WithEvents osensor4 As CSensor
	Private WithEvents osensor5 As CSensor
	Private WithEvents oRDCommand As CSensor
	
	'����״̬
	Private gCancel As Boolean
	Dim nn As Short '��չʱ�Ӽ���
	Dim mm As Short '��չʱ�Ӽ���
	Dim HH As Short '��չʱ�Ӽ���
	Public TimerN As Short '�Ų�����ͬ������
	Public TimerStatus As Short '״̬�������
	
	'״̬����
	Public DBPosition As String '���ݿ�洢���̷�
	Public SpaceAvailable As Integer '���ÿռ�澯��ֵ
	
	
	Private firstFlag As Boolean
	Private secondFlag As Boolean
	
	Private WithEvents osensorCommand As CSensor
    Private WithEvents osensorLine As New CSensor
    Private car As New CCar
	Private TestCode As String
	Private VINCode As String
	Public MTOCCode As String
	Dim inputCode As Scripting.Dictionary '����洢����
	Public TestStateFlag As Short
	Dim barCodeFlag As Boolean
	Dim sensorFlag As Boolean
	Dim sensorControlFlag As Boolean
	Dim testEndDelyed As Boolean
	Dim isInTesting As Boolean '�Ƿ����ڼ����̥������ Add by ZCJ 2012-07-09
	
	'TestStateFlag��ʶ�÷���
	'-1=��ʾ5�ڱ���ɹ����3���֣�ǰ���ǲ�����û��ɨ�������룬ɨ���״̬����0
	'0=vin�Ѿ�������Խ���׼��DSG���
	'1=��ǰ�ֲ����ɹ�
	'2=��ǰ�ֲ����ɹ�
	'3=�Һ��ֲ����ɹ�
	'4=����ֲ����ɹ�
	'5=����ɹ�
	'9998=δװ��DSG
	'9999=�ȴ�����
	
	Public BreakFlag As Boolean
	'BreakFlag = False  'ϵͳ������������ϵͳ��������
	'sensorFlag = True  '��������
	'barCodeFlag = True '�൱��ɨ��ǿ��¼������
	
	'����VT520�������
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Dim tmp As String
		tmp = "FF 03 1A 00 00 01 00 01 00 00 00 E8 03 00 00 E0 2E 17 00 00 00 00 00 3F CC 47 0D 42 41 47 43"
		
		Dim m_TirePreResult As String
		
		m_TirePreResult = CStr(CInt("&H000003E8") / 300)
		
		Dim Temp As String
		Temp = CStr(CInt("&H0017"))
		Temp = CStr(Val("&H46"))
		
	End Sub
	
	Private Sub Command12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command12.Click
		'   Dim A As Integer
		'   A = CLong("&H8H")
	End Sub
	
	'�������
	Private Sub Command14_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command14.Click
		'Call DSGTestEnd
		Dim mtoc As String
		Dim tmpCar As CCar
		tmpCar = New CCar
		'mtoc = tmpCar.GetMtocFromVinColl("11")
		tmpCar.VINCode = "11"
		tmpCar.Save()
	End Sub
	'ɨ������
	Private Sub Command17_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command17.Click
		BreakFlag = False
		TestCode = Text2.Text
		If VB.Left(TestCode, 17) = "R010000000000000C" Then '��������
			LogWritter("0ɨ����������")
			resetList()
			Exit Sub
		End If
		If VB.Left(TestCode, 17) = "R020000000000000C" Then 'ǿ����������
			LogWritter("ɨ��ǿ����������")
			barCodeFlag = True
			Exit Sub
		End If
		Debug.Print(TestCode)
		Call txtVIN_KeyPress(txtVIN, New System.Windows.Forms.KeyPressEventArgs(Chr(13)))
	End Sub
	'�������빤λ
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		If inputCode.Count <> 0 Then
			'�ٴ�����DSGStart
			'UPGRADE_WARNING: δ�ܽ������� inputCode() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			Call Me.DSGTestStart(CStr(inputCode(inputCode.Keys(0))))
		End If
	End Sub
	
	'ϵͳ����
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		
		If BreakFlag Then
			osensorCommand_onChange(True) 'ϵͳ����
		Else
			osensorCommand_onChange(False) '����ϵͳ
		End If

	End Sub
	
	Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
		
		'    oRVT520.ResetResult
		'    oRVT520.Start "Comm"
		'
		'    For i = 0 To 60
		'        oRVT520.ReadResult
		'        tmpID = oRVT520.TireIDResult
		'        If tmpID <> "00000000" And Trim(tmpID) <> "" Then
		'            Exit For
		'        End If
		'    Next i
		
	End Sub
	
	'�������Ų����У��൱��ɨ��ǿ��¼������
	Private Sub Command5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command5.Click
		barCodeFlag = True
	End Sub
	'����������
	Private Sub Command6_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command6.Click
		sensorControlFlag = False
	End Sub
	
	Private Sub Command7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command7.Click
		Dim A As Short
		Do While A < 10000
			A = A + 1
		Loop 
        Threading.Thread.Sleep(2000)
		Do While A < 10000
			A = A + 1
		Loop 
	End Sub
	
	'��ǰ��(����ʱ��)
	Private Sub Command8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command8.Click
		
		'BreakFlag = False  'ϵͳ����
		'sensorFlag = True  '��������
		TestStateFlag = 0
		Dim tmpID As String
		Dim i As Integer
		If TestStateFlag = 0 Then
			'�������̣����빤λ
			'�����ǰ��
			
			TestStateFlag = 1
			updateState("state", CStr(TestStateFlag))
			isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ�����ǰ��
			AddMessage("���ڼ����ǰ�֡���")
			LogWritter("��ʼ��һ�μ����ǰ�֡���")
			oRVT520.ResetResult()
			oRVT520.Start("Comm")
			
			For i = 0 To 6
				oRVT520.ReadResult()
				'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				tmpID = oRVT520.TireIDResult
				If tmpID <> "00000000" And Trim(tmpID) <> "" Then
					Exit For
				End If
			Next i
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Then '�ڶ��β���
				LogWritter("��ʼ�ڶ��μ����ǰ�֡���")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Then '�����β���
				LogWritter("��ʼ�����μ����ǰ�֡���")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Then '���Ĵβ���
				LogWritter("��ʼ���Ĵμ����ǰ�֡���")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Then '����β���
				LogWritter("��ʼ����μ����ǰ�֡���")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" Then
						Exit For
					End If
				Next i
			End If
			
			isInTesting = False 'Add by ZCJ 2012-07-09 ��ǰ�ּ�����
			
			car.TireRFID = tmpID
			LogWritter("��ǰ�ּ�����ݣ�" & oRVT520.Result)
			'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireMdlResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireRFMdl = oRVT520.TireMdlResult
			'UPGRADE_WARNING: δ�ܽ������� oRVT520.TirePreResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireRFPre = oRVT520.TirePreResult
			'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireTempResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireRFTemp = oRVT520.TireTempResult
			'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireBatteryResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireRFBattery = oRVT520.TireBatteryResult
			'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireAcSpeedResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireRFAcSpeed = oRVT520.TireAcSpeedResult
			
			updateState("dsgrf", tmpID)
			updateState("mdlrf", (car.TireRFMdl))
			updateState("prerf", (car.TireRFPre))
			updateState("temprf", (car.TireRFTemp))
			updateState("batteryrf", (car.TireRFBattery))
			updateState("acspeedrf", (car.TireRFAcSpeed))
			
			'��ǰ�ּ�����
			setFrm(TestStateFlag)
		End If
	End Sub
	'��ǰ��(����ʱ��)
	Private Sub Command9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command9.Click
		
		TestStateFlag = 1
		Dim tmpID As String
		Dim i As Integer
		
		If TestStateFlag = 1 Then
			TestStateFlag = 2
			updateState("state", CStr(TestStateFlag))
			isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ�����ǰ��
			AddMessage("���ڼ����ǰ�֡���")
			LogWritter("��ʼ��һ�μ����ǰ�֡���")
			oLVT520.ResetResult()
			oLVT520.Start("Comm")
			
			For i = 0 To 6
				oLVT520.ReadResult()
				'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				tmpID = oLVT520.TireIDResult
				'If tmpID <> "00000000" And Trim(tmpID) <> "" Then
				If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
					Exit For
				End If
			Next i
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '�ڶ��β���
				LogWritter("��ʼ�ڶ��μ����ǰ�֡���")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '�����β���
				LogWritter("��ʼ�����μ����ǰ�֡���")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '���Ĵβ���
				LogWritter("��ʼ���Ĵμ����ǰ�֡���")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '����β���
				LogWritter("��ʼ����μ����ǰ�֡���")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
			End If
			
			isInTesting = False 'Add by ZCJ 2012-07-09 ��ǰ�ּ�����
			
			car.TireLFID = tmpID
			LogWritter("��ǰ�ּ�����ݣ�" & oLVT520.Result)
			'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireMdlResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireLFMdl = oLVT520.TireMdlResult
			'UPGRADE_WARNING: δ�ܽ������� oLVT520.TirePreResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireLFPre = oLVT520.TirePreResult
			'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireTempResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireLFTemp = oLVT520.TireTempResult
			'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireBatteryResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireLFBattery = oLVT520.TireBatteryResult
			'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireAcSpeedResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireLFAcSpeed = oLVT520.TireAcSpeedResult
			
			updateState("dsglf", tmpID)
			updateState("mdllf", (car.TireLFMdl))
			updateState("prelf", (car.TireLFPre))
			updateState("templf", (car.TireLFTemp))
			updateState("batterylf", (car.TireLFBattery))
			updateState("acspeedlf", (car.TireLFAcSpeed))
			
			'��ǰ�ּ�����
			setFrm(TestStateFlag)
		End If
	End Sub
	'�Һ���(����ʱ��)
	Private Sub Command10_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command10.Click
		
		TestStateFlag = 2
		Dim tmpID As String
		Dim i As Integer
		If TestStateFlag = 2 Then
			
			TestStateFlag = 3
			updateState("state", CStr(TestStateFlag))
			isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ����Һ���
			AddMessage("���ڼ���Һ��֡���")
			LogWritter("��ʼ��һ�μ���Һ��֡���")
			oRVT520.ResetResult()
			oRVT520.Start("Comm")
			
			For i = 0 To 6
				oRVT520.ReadResult()
				'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				tmpID = oRVT520.TireIDResult
				'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
				If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
					Exit For
				End If
			Next i
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '�ڶ��β���
				LogWritter("��ʼ�ڶ��μ���Һ��֡���")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '�����β���
				LogWritter("��ʼ�����μ���Һ��֡���")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '���Ĵβ���
				LogWritter("��ʼ���Ĵμ���Һ��֡���")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '����β���
				LogWritter("��ʼ����μ���Һ��֡���")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
			End If
			
			isInTesting = False 'Add by ZCJ 2012-07-09 �Һ��ּ�����
			
			car.TireRRID = tmpID
			LogWritter("�Һ��ּ�����ݣ�" & oRVT520.Result)
			'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireMdlResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireRRMdl = oRVT520.TireMdlResult
			'UPGRADE_WARNING: δ�ܽ������� oRVT520.TirePreResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireRRPre = oRVT520.TirePreResult
			'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireTempResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireRRTemp = oRVT520.TireTempResult
			'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireBatteryResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireRRBattery = oRVT520.TireBatteryResult
			'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireAcSpeedResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireRRAcSpeed = oRVT520.TireAcSpeedResult
			
			updateState("dsgrr", tmpID)
			updateState("mdlrr", (car.TireRRMdl))
			updateState("prerr", (car.TireRRPre))
			updateState("temprr", (car.TireRRTemp))
			updateState("batteryrr", (car.TireRRBattery))
			updateState("acspeedrr", (car.TireRRAcSpeed))
			
			TestStateFlag = 3 '�Һ��ּ�����
			updateState("state", CStr(TestStateFlag))
			setFrm(TestStateFlag)
		End If
	End Sub
	'�����(����ʱ��)
	Private Sub Command11_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command11.Click
		
		TestStateFlag = 3
		Dim tmpID As String
		Dim i As Integer
		If TestStateFlag = 3 Then
			
			isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ��������
			AddMessage("���ڼ������֡���")
			LogWritter("��ʼ��һ�μ������֡���")
			oLVT520.ResetResult()
			oLVT520.Start("Comm")
			
			For i = 0 To 6
				oLVT520.ReadResult()
				'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				tmpID = oLVT520.TireIDResult
				'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID Then
				If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
					Exit For
				End If
			Next i
			'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID '�ڶ��β���
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '�ڶ��β���
				LogWritter("��ʼ�ڶ��μ������֡���")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '�����β���
				LogWritter("��ʼ�����μ������֡���")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '���Ĵβ���
				LogWritter("��ʼ���Ĵμ������֡���")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '����β���
				LogWritter("��ʼ����μ������֡���")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					End If
				Next i
			End If
			
			isInTesting = False 'Add by ZCJ 2012-07-09 ����ּ�����
			
			car.TireLRID = tmpID
			LogWritter("����ּ�����ݣ�" & oLVT520.Result)
			'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireMdlResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireLRMdl = oLVT520.TireMdlResult
			'UPGRADE_WARNING: δ�ܽ������� oLVT520.TirePreResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireLRPre = oLVT520.TirePreResult
			'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireTempResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireLRTemp = oLVT520.TireTempResult
			'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireBatteryResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireLRBattery = oLVT520.TireBatteryResult
			'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireAcSpeedResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			car.TireLRAcSpeed = oLVT520.TireAcSpeedResult
			
			updateState("dsglr", tmpID)
			updateState("mdllr", (car.TireLRMdl))
			updateState("prelr", (car.TireLRPre))
			updateState("templr", (car.TireLRTemp))
			updateState("batterylr", (car.TireLRBattery))
			updateState("acspeedlr", (car.TireLRAcSpeed))
			
			TestStateFlag = 4 '���ּ�����
			updateState("state", CStr(TestStateFlag))
			setFrm(TestStateFlag)
			
			If TestStateFlag = 4 Then
				LogWritter("�����ɣ�")
				
				car.Save()
				If CDbl(car.GetTestState) = 15 Then
			
				Else
					flashBuzzerLamp(Lamp_RedLight_IOPort)
					AddMessage("����������ظ�ֵ��", True)
					LogWritter("����������ظ�ֵ��������ӡ��")
					If car.printFlag And CDbl(car.LastCar.GetTestState) <> 15 Then
						Call printErrResult((car.LastCar))
					End If
					
					Call printErrResult(car)
				End If
				DSGTestEnd()
			ElseIf TestStateFlag = 9994 Then 
				DSGTestEnd()
			End If
			
		End If
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
    Private Sub FrmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        '�ر��̰߳�ȫ
        Control.CheckForIllegalCrossThreadCalls() = False
        frmInfo.CheckForIllegalCrossThreadCalls() = False

        modPublic.Main()

        '��������ɨ��ǹ
        WirledCodeGun_PortNum = getConfigValue("T_CtrlParam", "BarCodeGun", "WirledCodeGun_PortNum")
        WirledCodeGun_Settings = getConfigValue("T_CtrlParam", "BarCodeGun", "WirledCodeGun_Settings")
        SerialPortOnline(SerialPortVIN, WirledCodeGun_PortNum, WirledCodeGun_Settings)
        WirlessCodeGun_PortNum = getConfigValue("T_CtrlParam", "BarCodeGun", "WirlessCodeGun_PortNum")
        WirlessCodeGun_Settings = getConfigValue("T_CtrlParam", "BarCodeGun", "WirlessCodeGun_Settings")
        SerialPortOnline(SerialPortBT, WirlessCodeGun_PortNum, WirlessCodeGun_Settings)

        'Add by ZCJ 2012-07-09 ��ʼ������״̬
        isInTesting = False
        osen0Time = ""
        'Add by ZCJ 2012-07-09 ��ʼ�����ʱ��
        tmpTime = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Second, -30, Now))

        barCodeFlag = False
        frmInfo.Show()
        initFrom(True)
        Dim testFlag As Boolean
        TestStateFlag = CShort(readState("state"))
        testFlag = CBool(readState("test")) '�Ƿ��DSG

        TimerN = CShort(getConfigValue("T_RunParam", "Timer", "TimerDataSync")) '�Ų�����ͬ������
        TimerStatus = CShort(getConfigValue("T_RunParam", "Timer", "TimerStatus")) 'ϵͳ״̬���������
        DBPosition = getConfigValue("T_RunParam", "Status", "DBPosition") '���ݿ������̷�
        SpaceAvailable = CInt(getConfigValue("T_RunParam", "Status", "SpaceAvailable")) '���ݿ�����Ӳ�̿��ÿռ�����

        '�����DSGϵͳ����δ�����ɣ��ȼ����Ѽ���˵�����
        If testFlag And TestStateFlag <> 9999 Then
            car = getRunStateCar()
            Me.txtVin.Text = car.VINCode
        End If
        '����Ѽ����ɣ�������ݿ��м���VIN
        If TestStateFlag > 9000 And TestStateFlag < 9999 Or TestStateFlag = -1 Then
            Me.txtVin.Text = readState("vin")
        End If
        frmInfo.labNow.Text = VB.Right(Me.txtVin.Text, 8)
        If Me.txtVin.Text <> "" Then
            frmInfo.labVin.Text = Me.txtVin.Text
        End If
        setFrm(TestStateFlag)

        Step1Time = 4 '8
        Step2Time = 13 '17
        Step3Time = 13 '17
        Step4Time = 14 '18

        updateState("state", CStr(TestStateFlag))
        '������󼯺�
        inputCode = New Scripting.Dictionary

        'Modiy by ZCJ 2012-07-09 �������¼��ƶ����˴�
        osensorCommand = sensorCommand '�����¼�
        osensorCommand_onChange((sensorCommand.state))

        '������
        osensor0 = sensor0
        osensor1 = sensor1
        osensor2 = sensor2
        osensor3 = sensor3
        osensor4 = sensor4
        osensor5 = sensor5
        osensorLine = sensorLine 'ͣ���¼�
        oRDCommand = rdResetCommandS 'ϵͳ��λ�¼�
        DelayTime(1000)

        'UPGRADE_WARNING: δ�ܽ������� osensorLine.state ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
        sensorFlag = osensorLine.state
        sensorControlFlag = False '������״̬,False��ʾû����
        testEndDelyed = False '�˱�ʾ��TestStateFlag=-1����ʹ��

        initDictionary()
        iniListInput()
        flashLamp(Lamp_GreenLight_IOPort)
        Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)

    End Sub
	
	'�������ϵĸ�λ��ť�¼�
	Private Sub oRDCommand_onChange(ByRef state As Boolean) Handles oRDCommand.onChange
		If state Then
			If BreakFlag Then Exit Sub
			LogWritter("ϵͳ����λ")
			resetList()
		End If
	End Sub
	'0�Ŵ�����
	Private Sub osensor0_onChange(ByRef state As Boolean) Handles osensor0.onChange
		SensorLogWritter("osensor0----" & CStr(state))
		If BreakFlag Then Exit Sub
		
		If osen0Time <> "" Then
			'UPGRADE_WARNING: DateDiff ��Ϊ���ܲ�ͬ�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"��
			If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(osen0Time), Now) <= 3 Then
				SensorLogWritter("��Ӧʱ��δ�ﵽҪ��osensor0�¼�δ��Ӧ.")
				Exit Sub
			Else
				osen0Time = CStr(Now)
			End If
		Else
			osen0Time = CStr(Now)
		End If
		
		If state = True Then
			'�������빤λ��һ����ʶ
			firstFlag = True
			flashLamp(Lamp_YellowFlash_IOPort)
		ElseIf secondFlag And osensor4.state Then 
			If TestStateFlag < 10 And TestStateFlag <> 3 And TestStateFlag <> 0 And TestStateFlag <> -1 Then
				'If TestStateFlag < 10 And TestStateFlag <> 1 And TestStateFlag <> 3 And TestStateFlag <> 0 Then
				LogWritter("�����ɣ�")
				
				car.Save()
				If CDbl(car.GetTestState) = 15 Then
				
				Else
					flashBuzzerLamp(Lamp_RedLight_IOPort)
					AddMessage("����������ظ�ֵ��", True)
					LogWritter("����������ظ�ֵ��������ӡ��")
					If car.printFlag And CDbl(car.LastCar.GetTestState) <> 15 Then
						Call printErrResult((car.LastCar))
					End If
					Call printErrResult(car)
				End If
				AddMessage("��ע������Ƿ���ȷ", True)
				LogWritter("���ְ�̨������")
				DSGTestEnd()
				
				DelayTime(5000)
				oIOCard.OutputController(rdOutput, False)
				oIOCard.OutputController(Lamp_RedLight_IOPort, False)
				oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
			ElseIf TestStateFlag > 9990 And TestStateFlag <> 9995 And TestStateFlag <> 9999 And TestStateFlag <> -1 Then 
				'ElseIf TestStateFlag > 9990 And TestStateFlag <> 9998 And TestStateFlag <> 9997 And TestStateFlag <> 9995 And TestStateFlag <> 9999 Then
				AddMessage("��ע������Ƿ���ȷ", True)
				LogWritter("���ְ�̨������")
				DSGTestEnd()
				
			End If
		End If
		
	End Sub
	'1�Ŵ�����
	Private Sub osensor1_onChange(ByRef state As Boolean) Handles osensor1.onChange
		SensorLogWritter("osensor1----" & CStr(state))
		If BreakFlag Then Exit Sub
		
		secondFlag = state
		If Not firstFlag Then
			'�����쳣����
		End If
		
		If firstFlag And secondFlag Then
			'�������繤λ�ȴ���ʼ����
			firstFlag = False
			'secondFlag = False
			If inputCode.Count <> 0 Then
				'�ٴ�����DSGStart
				'UPGRADE_WARNING: δ�ܽ������� inputCode() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				Call Me.DSGTestStart(CStr(inputCode(inputCode.Keys(0))))
				tmpTime = CStr(Now)
			End If
			
		End If
	End Sub
	'2�Ŵ�����
	Private Sub osensor2_onChange(ByRef state As Boolean) Handles osensor2.onChange
		SensorLogWritter("osensor2----" & CStr(state))
		
		On Error Resume Next
		If BreakFlag Then Exit Sub
		'��������ֹͣ������Ӧֹͣ��ʱ���˳�����
		If Not sensorFlag And sensorControlFlag Then
			SensorLogWritter("������ֹͣ�¼�δ��Ӧ")
			Exit Sub
		End If
		
		'Add by ZCJ 2012-08-09 �����ڼ��ʱ���˳�
		If isInTesting Then Exit Sub
		
		Dim tmpID As String
		Dim i As Integer
		DelayTime(800)
		If osensor1.state And osensor0.state And osensor2.state = state Then
			If TestStateFlag = 0 Then
				'�������̣����빤λ
				'�����ǰ��
				
				'UPGRADE_WARNING: DateDiff ��Ϊ���ܲ�ͬ�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"��
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step1Time Then
					SensorLogWritter("��Ӧʱ��δ�ﵽҪ��osensor2�¼�δ��Ӧ.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				
				
				TestStateFlag = 1
				updateState("state", CStr(TestStateFlag))
				
				isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ�����ǰ��
				
				AddMessage("���ڼ����ǰ�֡���")
				LogWritter("��ʼ��һ�μ����ǰ�֡���")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" Then
						Exit For
					End If
				Next i
				
				LogWritter("��һ�μ�����ݣ�" & tmpID)
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Then '�ڶ��β���
					LogWritter("��ʼ�ڶ��μ����ǰ�֡���")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" Then
							Exit For
						End If
					Next i
					
					LogWritter("�ڶ��μ�����ݣ�" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Then '�����β���
					LogWritter("��ʼ�����μ����ǰ�֡���")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" Then
							Exit For
						End If
					Next i
					
					LogWritter("�����μ�����ݣ�" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Then '���Ĵβ���
					LogWritter("��ʼ���Ĵμ����ǰ�֡���")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" Then
							Exit For
						End If
					Next i
					
					LogWritter("���Ĵμ�����ݣ�" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Then '����β���
					LogWritter("��ʼ����μ����ǰ�֡���")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" Then
							Exit For
						End If
					Next i
					
					LogWritter("����μ�����ݣ�" & tmpID)
					
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 ��ǰ�ּ�����
				
				car.TireRFID = tmpID
				LogWritter("��ǰ�ּ�����ݣ�" & oRVT520.Result)
				'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireMdlResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireRFMdl = oRVT520.TireMdlResult
				'UPGRADE_WARNING: δ�ܽ������� oRVT520.TirePreResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireRFPre = oRVT520.TirePreResult
				'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireTempResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireRFTemp = oRVT520.TireTempResult
				'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireBatteryResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireRFBattery = oRVT520.TireBatteryResult
				'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireAcSpeedResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireRFAcSpeed = oRVT520.TireAcSpeedResult
				
				updateState("dsgrf", tmpID)
				updateState("mdlrf", (car.TireRFMdl))
				updateState("prerf", (car.TireRFPre))
				updateState("temprf", (car.TireRFTemp))
				updateState("batteryrf", (car.TireRFBattery))
				updateState("acspeedrf", (car.TireRFAcSpeed))
				
				'ǰ�ּ�����
				setFrm(TestStateFlag)
				
			ElseIf TestStateFlag = 2 Then 
				'����Һ���
				'UPGRADE_WARNING: DateDiff ��Ϊ���ܲ�ͬ�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"��
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step3Time Then
					SensorLogWritter("��Ӧʱ��δ�ﵽҪ��osensor5�¼�δ��Ӧ.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				TestStateFlag = 3 '���ּ�����
				updateState("state", CStr(TestStateFlag))
				
				isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ����Һ���
				
				AddMessage("���ڼ���Һ��֡���")
				LogWritter("��ʼ��һ�μ���Һ��֡���")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oRVT520.TireIDResult
					'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
				
				LogWritter("��һ�μ�����ݣ�" & tmpID)
				
				'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then   '�ڶ��β���
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '�ڶ��β���
					LogWritter("��ʼ�ڶ��μ���Һ��֡���")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
							Exit For
						End If
					Next i
					
					LogWritter("�ڶ��μ�����ݣ�" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '�����β���
					LogWritter("��ʼ�����μ���Һ��֡���")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
							Exit For
						End If
					Next i
					
					LogWritter("�����μ�����ݣ�" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '���Ĵβ���
					LogWritter("��ʼ���Ĵμ���Һ��֡���")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
							Exit For
						End If
					Next i
					
					LogWritter("���Ĵμ�����ݣ�" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '����β���
					LogWritter("��ʼ����μ���Һ��֡���")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
							Exit For
						End If
					Next i
					
					LogWritter("����μ�����ݣ�" & tmpID)
					
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 �Һ��ּ�����
				
				car.TireRRID = tmpID
				LogWritter("�Һ��ּ�����ݣ�" & oRVT520.Result)
				'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireMdlResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireRRMdl = oRVT520.TireMdlResult
				'UPGRADE_WARNING: δ�ܽ������� oRVT520.TirePreResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireRRPre = oRVT520.TirePreResult
				'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireTempResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireRRTemp = oRVT520.TireTempResult
				'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireBatteryResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireRRBattery = oRVT520.TireBatteryResult
				'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireAcSpeedResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireRRAcSpeed = oRVT520.TireAcSpeedResult
				
				updateState("dsgrr", tmpID)
				updateState("mdlrr", (car.TireRRMdl))
				updateState("prerr", (car.TireRRPre))
				updateState("temprr", (car.TireRRTemp))
				updateState("batteryrr", (car.TireRRBattery))
				updateState("acspeedrr", (car.TireRRAcSpeed))
				
				setFrm(TestStateFlag)
			ElseIf TestStateFlag = 9998 Then 
				'����DSG�ĳ�
				
				'UPGRADE_WARNING: DateDiff ��Ϊ���ܲ�ͬ�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"��
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step1Time Then
					SensorLogWritter("��Ӧʱ��δ�ﵽҪ��osensor2�¼�δ��Ӧ.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				
				
				TestStateFlag = TestStateFlag - 1
				updateState("state", CStr(TestStateFlag))
				setFrm(TestStateFlag)
			ElseIf TestStateFlag = 9996 Then 
				'UPGRADE_WARNING: DateDiff ��Ϊ���ܲ�ͬ�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"��
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step3Time Then
					SensorLogWritter("��Ӧʱ��δ�ﵽҪ��osensor2�¼�δ��Ӧ.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				
				
				TestStateFlag = TestStateFlag - 1
				updateState("state", CStr(TestStateFlag))
				setFrm(TestStateFlag)
			End If
			
			isInTesting = False 'Add by ZCJ 2012-07-09 ��ʼ����̥���״̬
		Else
			
		End If
	End Sub
	'������3
	Private Sub osensor3_onChange(ByRef state As Boolean) Handles osensor3.onChange
		SensorLogWritter("osensor3----" & CStr(state))
	End Sub
	'������4
	Private Sub osensor4_onChange(ByRef state As Boolean) Handles osensor4.onChange
		SensorLogWritter("osensor4----" & CStr(state))
	End Sub
	'������5
	Private Sub osensor5_onChange(ByRef state As Boolean) Handles osensor5.onChange
		SensorLogWritter("osensor5----" & CStr(state))
		
		On Error Resume Next
		If BreakFlag Then Exit Sub
		If Not sensorFlag And sensorControlFlag Then
			SensorLogWritter("������ֹͣ�¼�δ��Ӧ")
			Exit Sub
		End If
		
		'Add by ZCJ 2012-08-09 �����ڼ��ʱ���˳�
		If isInTesting Then Exit Sub
		
		Dim tmpID As String
		Dim i As Integer
		DelayTime(800)
		If osensor3.state And osensor4.state And osensor5.state = state Then
			If TestStateFlag = 1 Then
				'�������̣����빤λ
				'�����ǰ��
				
				'UPGRADE_WARNING: DateDiff ��Ϊ���ܲ�ͬ�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"��
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step2Time Then
					SensorLogWritter("��Ӧʱ��δ�ﵽҪ��osensor5�¼�δ��Ӧ.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				
				TestStateFlag = 2
				updateState("state", CStr(TestStateFlag))
				
				isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ�����ǰ��
				
				AddMessage("���ڼ����ǰ�֡���")
				LogWritter("��ʼ��һ�μ����ǰ�֡���")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					'If tmpID <> "00000000" And Trim(tmpID) <> "" Then
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
				
				LogWritter("��һ�μ�����ݣ�" & tmpID)
				
				'If tmpID = "00000000" Or Trim(tmpID) = "" Then '�ڶ��β���
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '�ڶ��β���
					LogWritter("��ʼ�ڶ��μ����ǰ�֡���")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
							Exit For
						End If
					Next i
					
					LogWritter("�ڶ��μ�����ݣ�" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '�����β���
					LogWritter("��ʼ�����μ����ǰ�֡���")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
							Exit For
						End If
					Next i
					
					LogWritter("�����μ�����ݣ�" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '���Ĵβ���
					LogWritter("��ʼ���Ĵμ����ǰ�֡���")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
							Exit For
						End If
					Next i
					
					LogWritter("���Ĵμ�����ݣ�" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '����β���
					LogWritter("��ʼ����μ����ǰ�֡���")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
							Exit For
						End If
					Next i
					
					LogWritter("����μ�����ݣ�" & tmpID)
					
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 ��ǰ�ּ�����
				
				car.TireLFID = tmpID
				LogWritter("��ǰ�ּ�����ݣ�" & oLVT520.Result)
				'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireMdlResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireLFMdl = oLVT520.TireMdlResult
				'UPGRADE_WARNING: δ�ܽ������� oLVT520.TirePreResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireLFPre = oLVT520.TirePreResult
				'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireTempResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireLFTemp = oLVT520.TireTempResult
				'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireBatteryResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireLFBattery = oLVT520.TireBatteryResult
				'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireAcSpeedResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireLFAcSpeed = oLVT520.TireAcSpeedResult
				
				updateState("dsglf", tmpID)
				updateState("mdllf", (car.TireLFMdl))
				updateState("prelf", (car.TireLFPre))
				updateState("templf", (car.TireLFTemp))
				updateState("batterylf", (car.TireLFBattery))
				updateState("acspeedlf", (car.TireLFAcSpeed))
				
				'ǰ�ּ�����
				setFrm(TestStateFlag)
			ElseIf TestStateFlag = 3 Then 
				'��������
				'UPGRADE_WARNING: DateDiff ��Ϊ���ܲ�ͬ�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"��
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step4Time Then
					SensorLogWritter("��Ӧʱ��δ�ﵽҪ��osensor5�¼�δ��Ӧ.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				
				TestStateFlag = 4
				updateState("state", CStr(TestStateFlag))
				
				isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ��������
				
				AddMessage("���ڼ������֡���")
				LogWritter("��ʼ��һ�μ������֡���")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID Then
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					End If
				Next i
				
				LogWritter("��һ�μ�����ݣ�" & tmpID)
				
				'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Then '�ڶ��β���
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then
					LogWritter("��ʼ�ڶ��μ������֡���")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
							Exit For
						End If
					Next i
					
					LogWritter("�ڶ��μ�����ݣ�" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '�����β���
					LogWritter("��ʼ�����μ������֡���")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
							Exit For
						End If
					Next i
					
					LogWritter("�����μ�����ݣ�" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '���Ĵβ���
					LogWritter("��ʼ���Ĵμ������֡���")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
							Exit For
						End If
					Next i
					
					LogWritter("���Ĵμ�����ݣ�" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '����β���
					LogWritter("��ʼ����μ������֡���")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
							Exit For
						End If
					Next i
					
					
					LogWritter("����μ�����ݣ�" & tmpID)
					
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 ����ּ�����
				
				car.TireLRID = tmpID
				LogWritter("����ּ�����ݣ�" & oLVT520.Result)
				'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireMdlResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireLRMdl = oLVT520.TireMdlResult
				'UPGRADE_WARNING: δ�ܽ������� oLVT520.TirePreResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireLRPre = oLVT520.TirePreResult
				'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireTempResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireLRTemp = oLVT520.TireTempResult
				'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireBatteryResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireLRBattery = oLVT520.TireBatteryResult
				'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireAcSpeedResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
				car.TireLRAcSpeed = oLVT520.TireAcSpeedResult
				
				updateState("dsglr", tmpID)
				updateState("mdllr", (car.TireLRMdl))
				updateState("prelr", (car.TireLRPre))
				updateState("templr", (car.TireLRTemp))
				updateState("batterylr", (car.TireLRBattery))
				updateState("acspeedlr", (car.TireLRAcSpeed))
				
				'���ּ�����
				setFrm(TestStateFlag)
				DelayTime(200) '������ڽ�����ʾ0.2��
			ElseIf TestStateFlag = 9997 Then 
				'����DSG�ĳ�
				'UPGRADE_WARNING: DateDiff ��Ϊ���ܲ�ͬ�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"��
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step2Time Then
					SensorLogWritter("��Ӧʱ��δ�ﵽҪ��osensor5�¼�δ��Ӧ.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				TestStateFlag = TestStateFlag - 1
				updateState("state", CStr(TestStateFlag))
				setFrm(TestStateFlag)
			ElseIf TestStateFlag = 9995 Then 
				'����DSG�ĳ�
				'UPGRADE_WARNING: DateDiff ��Ϊ���ܲ�ͬ�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"��
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step4Time Then
					SensorLogWritter("��Ӧʱ��δ�ﵽҪ��osensor5�¼�δ��Ӧ.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				TestStateFlag = TestStateFlag - 1
				updateState("state", CStr(TestStateFlag))
				setFrm(TestStateFlag)
			End If
			
			If TestStateFlag = 4 Then
				LogWritter("�����ɣ�")
				
				car.Save()
				If CDbl(car.GetTestState) = 15 Then
					
					flashLamp(Lamp_YellowFlash_IOPort)
				
				Else
					flashBuzzerLamp(Lamp_RedLight_IOPort)
					AddMessage("����������ظ�ֵ��", True)
					LogWritter("����������ظ�ֵ��������ӡ��")
					If car.printFlag And CDbl(car.LastCar.GetTestState) <> 15 Then
						Call printErrResult((car.LastCar))
					End If
					
					Call printErrResult(car)
				End If
				DSGTestEnd()
				
				DelayTime(5000)
				oIOCard.OutputController(rdOutput, False)
				oIOCard.OutputController(Lamp_RedLight_IOPort, False)
				oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
			ElseIf TestStateFlag = 9994 Then 
				'oIOCard.OutputController rdOutput, True
				DSGTestEnd()
			End If
			
		Else
			
		End If
		
	End Sub
	'���������¼�
	Private Sub osensorCommand_onChange(ByRef state As Boolean) Handles osensorCommand.onChange
		SensorLogWritter("osensorCommand----" & CStr(state))
		BreakFlag = Not state
		If state Then
		
			AddMessage("ϵͳ�ѽ�����", True)
			setFrm(TestStateFlag)
			LogWritter("ϵͳ�ѽ�����")
			Timer_PrintError.Interval = 1000
		Else
		
			AddMessage("ϵͳ�ѱ��������������", True)
			LogWritter("ϵͳ��������")
			'UPGRADE_WARNING: ��ʱ������ Timer_PrintError.Interval ��ֵ����Ϊ 0�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="169ECF4A-1968-402D-B243-16603CC08604"��
            Timer_PrintError.Interval = 10000
		End If
	End Sub
	'ͣ���¼�
	Private Sub osensorLine_onChange(ByRef state As Boolean) Handles osensorLine.onChange
		SensorLogWritter("sensorLine----" & CStr(state))
		sensorFlag = state
	End Sub
	
	Private Sub Timer_PrintError_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer_PrintError.Tick
		On Error GoTo Err_Renamed
		HH = HH + 1
		
		If HH < 5 Then
			Exit Sub
		End If
		
		Call printErrCodeAuto()
		
		HH = 0
		Exit Sub
Err_Renamed: 
		LogWritter("printErrCode timer error")
		HH = 0
		Exit Sub
	End Sub
	
	Private Sub txtInputVIN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtInputVIN.Enter
		txtInputVIN.Text = ""
	End Sub
	
	Private Sub txtInputVIN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtInputVIN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If BreakFlag Then GoTo EventExitSub
		Dim tmp As String
		If KeyAscii = 13 Then '�س�����
			tmp = txtInputVIN.Text
			
			If tmp = "" Then GoTo EventExitSub
			TestCode = tmp
			If VB.Left(TestCode, 17) = "R010000000000000C" Then
				LogWritter("1ɨ����������")
				resetList()
				txtInputVIN.Text = "�ֹ�¼��VIN���س�ȷ��"
				GoTo EventExitSub
			End If
			If VB.Left(TestCode, 17) = "R020000000000000C" Then
				barCodeFlag = True
				txtInputVIN.Text = "�ֹ�¼��VIN���س�ȷ��"
				GoTo EventExitSub
			End If
			
			Debug.Print(TestCode)
			Call txtVIN_KeyPress(txtVIN, New System.Windows.Forms.KeyPressEventArgs(Chr(13)))
			txtInputVIN.Text = "�ֹ�¼��VIN���س�ȷ��"
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtInputVIN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtInputVIN.Leave
		txtInputVIN.Text = "�ֹ�¼��VIN���س�ȷ��"
	End Sub
	
	'����ɨ��������Ϣ
	Private Sub txtVIN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVIN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		Dim tmpCode, tmpKey As String
		tmpCode = TestCode
		tmpKey = Mid(tmpCode, 2, 17)
		
		If BreakFlag Then GoTo EventExitSub
		If KeyAscii = 13 Then
			
			
			TestCode = Trim(TestCode)
			TestCode = Replace(TestCode, Chr(10), "")
			TestCode = Replace(TestCode, Chr(13), "")
			LogWritter("************************************************************")
			LogWritter("ɨ�����룺" & TestCode)
			LogWritter("************************************************************")
            If Len(TestCode) = 17 Then
                If isCheckAllQueue Then
                    If frmInfo.ListInput.Items.Count <> 0 And barCodeFlag = False Then
                        If frmInfo.labNext.Text <> VB.Right(tmpKey, 8) Then
                            AddMessage("��ע���ɨ������Ϣ�Ƿ���ȷ", True)
                            flashBuzzerLamp(Lamp_RedLight_IOPort)
                            LogWritter("��ɨ������ƥ��,������������")
                            DelayTime(2000)
                            oIOCard.OutputController(Lamp_RedLight_IOPort, False)
                            oIOCard.OutputController(rdOutput, False)
                            If TestStateFlag = 9999 Or TestStateFlag = -1 Then
                                oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
                            Else
                                oIOCard.OutputController(Lamp_YellowFlash_IOPort, True)
                            End If
                            GoTo EventExitSub
                        End If
                    End If
                End If
                If barCodeFlag Then
                    barCodeFlag = False
                End If
                If inputCode.Exists(tmpKey) Then
                    GoTo EventExitSub
                End If

                inputCode.Add(tmpKey, tmpCode)
                insertColl(tmpCode)
                LogWritter(tmpKey & "����ɨ�����")
                Me.List1.Items.Add(tmpKey)
                frmInfo.ListOutput.Items.Add(VB.Right(tmpKey, 8))
                setFrm(TestStateFlag)
                initDictionary()
                If inputCode.Count = 1 Then
                    'UPGRADE_WARNING: δ�ܽ������� inputCode() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
                    txtVin.Text = CStr(Mid(inputCode(inputCode.Keys(0)), 2, 17))
                    frmInfo.labVin.Text = txtVin.Text
                    updateState("test", "False")
                    updateState("vin", (txtVin.Text))
                    TestStateFlag = -1
                    updateState("state", CStr(-1))
                    AddMessage("�ȴ�ɨ�賵�����빤λ!")
                End If
                iniListInput()
                flashLamp(Lamp_GreenFlash_IOPort)
                DelayTime(1000)
                flashLamp(Lamp_GreenLight_IOPort)
                If TestStateFlag = 9999 Or TestStateFlag = -1 Then
                    oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
                Else
                    oIOCard.OutputController(Lamp_GreenLight_IOPort, False)
                    oIOCard.OutputController(Lamp_YellowFlash_IOPort, True)
                End If
            Else
                AddMessage("��ע��ɨ�����볤���Ƿ���ȷ", True)
                flashBuzzerLamp(Lamp_RedLight_IOPort)
                LogWritter("���볤�Ȳ���ȷ,������������!")
                DelayTime(2000)
                oIOCard.OutputController(Lamp_RedLight_IOPort, False)
                oIOCard.OutputController(rdOutput, False)
                If TestStateFlag = 9999 Or TestStateFlag = -1 Then
                    oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
                Else
                    oIOCard.OutputController(Lamp_GreenLight_IOPort, False)
                    oIOCard.OutputController(Lamp_YellowFlash_IOPort, True)
                End If
            End If
			
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'******************************************************************************
	'** �� �� ����DSGTestStart
	'** ��    �룺
	'** ��    ����
	'** ����������DSG���Կ�ʼ
	'** ȫ�ֱ�����
	'** ��    �ߣ�yangshuai
	'** ��    �䣺shuaigoplay@live.cn
	'** ��    �ڣ�2009-2-27
	'** �� �� �ߣ�
	'** ��    �ڣ�
	'** ��    ����1.0
	'******************************************************************************
	Public Sub DSGTestStart(ByRef vin As String)
		
		isInTesting = False 'Add by ZCJ 2012-07-09 ��ʼ����̥���״̬
		
		If TestStateFlag <> 9999 Then
			If TestStateFlag <> -1 Then
				'����������������
				Exit Sub
			End If
		End If
		
		txtVIN.Text = Mid(vin, 2, 17)
		frmInfo.labVin.Text = txtVIN.Text
		frmInfo.labNow.Text = VB.Right(txtVIN.Text, 8)
		LogWritter("============================================================")
		LogWritter(txtVIN.Text & "��ʼ����!")
		If hasDSG(vin) Then
			LogWritter("������ͨ��,��ʼDSG���!")
			updateState("test", "True")
			updateState("vin", (txtVIN.Text))
			car = New CCar
			car.VINCode = txtVIN.Text
			TestStateFlag = 0
			setFrm(TestStateFlag)
			updateState("state", CStr(TestStateFlag))
			If osensor1.state Then
				osensor1_onChange(True)
			End If
		Else
			LogWritter("����δװ��DSG,ֱ��ͨ��!")
			updateState("test", "False")
			updateState("vin", (txtVIN.Text))
			
			TestStateFlag = 9998
			setFrm(TestStateFlag)
			updateState("state", CStr(TestStateFlag))
		End If
	End Sub
	'�������
	Public Sub DSGTestEnd()
		On Error GoTo END_ERR
		
		isInTesting = False 'Add by ZCJ 2012-07-09 ��ʼ����̥���״̬
		
		testEndDelyed = True
		TestStateFlag = 9999
		resetState()
		LogWritter(txtVIN.Text & "�������!")
		LogWritter("============================================================")
		
		txtVIN.Text = ""
		frmInfo.labNow.Text = ""
		frmInfo.labVin.Text = "̥ѹ����ʼ��ϵͳ"
		
		setFrm(TestStateFlag)
		'UPGRADE_WARNING: δ�ܽ������� inputCode.Keys() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		LogWritter(CStr(inputCode.Keys(0)) & "�˳�ɨ�����!")
		'UPGRADE_WARNING: δ�ܽ������� inputCode.Keys() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		delColl(CStr(inputCode.Keys(0)))
		inputCode.Remove(inputCode.Keys(0))
		If inputCode.Count <> 0 Then
			'UPGRADE_WARNING: δ�ܽ������� inputCode.Keys() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			updateState("vin", CStr(inputCode.Keys(0)))
			TestStateFlag = -1
			updateState("state", CStr(TestStateFlag))
			'UPGRADE_WARNING: δ�ܽ������� inputCode() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			If hasDSG(CStr(inputCode(inputCode.Keys(0)))) Then
				updateState("test", "True")
			Else
				updateState("test", "False")
			End If
		End If
		
		DelayTime(3000)
		testEndDelyed = False
		flashLamp(Lamp_GreenLight_IOPort)
		
		iniListInput()
		initDictionary()
		
		If inputCode.Count <> 0 Then
			'�ٴ�����DSGStart
			'UPGRADE_WARNING: δ�ܽ������� inputCode() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			Call Me.DSGTestStart(CStr(inputCode(inputCode.Keys(0))))
		Else
			LogWritter("ɨ������г�����Ϊ��")
		End If
		
		Exit Sub
END_ERR: 
		LogWritter(Err.Description)
	End Sub
	'�ڽ�������ʾ��⵽�Ĵ�������Ϣ
	'UPGRADE_NOTE: text �������� text_Renamed�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"��
	'UPGRADE_NOTE: str �������� str_Renamed�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"��
	Public Sub showDSGInfo(ByRef str_Renamed As String, ByRef text_Renamed As String, ByRef model As String, ByRef pressure As String, ByRef temperature As String, ByRef battery As String, ByRef acSpeed As String, ByRef imgName As String)
		On Error Resume Next
		Dim Result As Boolean
		Dim mdlArr() As String
		
		CType(Me.Controls("txt" & str_Renamed), Object).Text = text_Renamed
		'UPGRADE_ISSUE: Control ���� Controls.Picture δ������ �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"��
		CType(Me.Controls("pic" & str_Renamed), Object).Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\" & imgName)
		CType(frmInfo.Controls("txt" & str_Renamed), Object).Text = text_Renamed
		'UPGRADE_ISSUE: Control ���� Controls.Picture δ������ �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"��
		CType(frmInfo.Controls("pic" & str_Renamed), Object).Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\" & imgName)
		CType(Me.Controls("lb" & str_Renamed & "Mdl"), Object).Text = model
		CType(frmInfo.Controls("lb" & str_Renamed & "Mdl"), Object).Text = model
		
		mdlArr = Split(mdlValue, ",")
		Result = judgeMdlIsOK(model, mdlArr)
		If Result Then
			CType(Me.Controls("lb" & str_Renamed & "Mdl"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF0000)
			CType(frmInfo.Controls("lb" & str_Renamed & "Mdl"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF0000)
		Else
			CType(Me.Controls("lb" & str_Renamed & "Mdl"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
			CType(frmInfo.Controls("lb" & str_Renamed & "Mdl"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
		End If
		CType(Me.Controls("lb" & str_Renamed & "Mdl"), Object).Text = model
		CType(frmInfo.Controls("lb" & str_Renamed & "Mdl"), Object).Text = model
		
		
		Result = judgeResultIsOK(pressure, preMinValue, preMaxValue)
		If Result Then
			CType(Me.Controls("lb" & str_Renamed & "Pre"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF0000)
			CType(frmInfo.Controls("lb" & str_Renamed & "Pre"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF0000)
		Else
			CType(Me.Controls("lb" & str_Renamed & "Pre"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
			CType(frmInfo.Controls("lb" & str_Renamed & "Pre"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
		End If
		If pressure <> "" Then
			CType(Me.Controls("lb" & str_Renamed & "Pre"), Object).Text = pressure & "kPa"
			CType(frmInfo.Controls("lb" & str_Renamed & "Pre"), Object).Text = pressure & "kPa"
		Else
			CType(Me.Controls("lb" & str_Renamed & "Pre"), Object).Text = ""
			CType(frmInfo.Controls("lb" & str_Renamed & "Pre"), Object).Text = ""
		End If
		
		
		
		Result = judgeResultIsOK(temperature, tempMinValue, tempMaxValue)
		If Result Then
			CType(Me.Controls("lb" & str_Renamed & "Temp"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF0000)
			CType(frmInfo.Controls("lb" & str_Renamed & "Temp"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF0000)
		Else
			CType(Me.Controls("lb" & str_Renamed & "Temp"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
			CType(frmInfo.Controls("lb" & str_Renamed & "Temp"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
		End If
		If temperature <> "" Then
			CType(Me.Controls("lb" & str_Renamed & "Temp"), Object).Text = temperature & "��"
			CType(frmInfo.Controls("lb" & str_Renamed & "Temp"), Object).Text = temperature & "��"
		Else
			CType(Me.Controls("lb" & str_Renamed & "Temp"), Object).Text = ""
			CType(frmInfo.Controls("lb" & str_Renamed & "Temp"), Object).Text = ""
		End If
		
		
		If battery = "OK" Then
			CType(Me.Controls("lb" & str_Renamed & "Battery"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF0000)
			CType(frmInfo.Controls("lb" & str_Renamed & "Battery"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF0000)
		Else
			CType(Me.Controls("lb" & str_Renamed & "Battery"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
			CType(frmInfo.Controls("lb" & str_Renamed & "Battery"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
		End If
		CType(Me.Controls("lb" & str_Renamed & "Battery"), Object).Text = battery
		CType(frmInfo.Controls("lb" & str_Renamed & "Battery"), Object).Text = battery
		
		
		
		Result = judgeResultIsOK(acSpeed, acSpeedMinValue, acSpeedMaxValue)
		If Result Then
			CType(Me.Controls("lb" & str_Renamed & "AcSpeed"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF0000)
			CType(frmInfo.Controls("lb" & str_Renamed & "AcSpeed"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF0000)
		Else
			CType(Me.Controls("lb" & str_Renamed & "AcSpeed"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
			CType(frmInfo.Controls("lb" & str_Renamed & "AcSpeed"), Object).ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
		End If
		If acSpeed <> "" Then
			CType(Me.Controls("lb" & str_Renamed & "AcSpeed"), Object).Text = acSpeed & "g"
			CType(frmInfo.Controls("lb" & str_Renamed & "AcSpeed"), Object).Text = acSpeed & "g"
		Else
			CType(Me.Controls("lb" & str_Renamed & "AcSpeed"), Object).Text = ""
			CType(frmInfo.Controls("lb" & str_Renamed & "AcSpeed"), Object).Text = ""
		End If
	End Sub
	
	'��ʾ��ǰ�ļ��״̬
	Public Sub setFrm(ByRef state As Short)
		If state = -1 Then
			AddMessage("�ȴ�ɨ�賵�����빤λ!")
			initFrom(False)
		ElseIf state = 9999 Then 
			AddMessage("�ȴ�ɨ��VIN����ʼ����!")
			initFrom(True)
		ElseIf state > 9000 And state < 9999 Then 
			AddMessage("����δװ��DSG��������ֱ��ͨ��!")
			Select Case state
				Case 9997
					AddMessage("δװ��DSG:��ǰ����ͨ����������")
				Case 9996
					AddMessage("δװ��DSG:��ǰ����ͨ����������")
				Case 9995
					AddMessage("δװ��DSG:�Һ�����ͨ����������")
				Case 9994
					AddMessage("δװ��DSG:�������ͨ����������")
			End Select
			
		Else
			Select Case state
				
				Case 0
					AddMessage("����ɨ��ͨ���ȴ��������빤λ,��ʼ����!")
					LogWritter("����ɨ��ͨ���ȴ��������빤λ,��ʼ����!")
					initFrom(False)
				Case 1
					If car.TireRFID <> "00000000" And Trim(car.TireRFID) <> "" Then
						showDSGInfo("RF", (car.TireRFID), (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Green1.jpg")
						LogWritter("��ǰ�ּ������" & car.TireRFID)
						AddMessage("��ǰ�ּ�����")
					Else
						'Modiy by ZCJ 2012=07-09 ���������ڼ����̥��״̬����
						If isInTesting = True Then
							AddMessage("���ڼ����ǰ�֡���")
						Else
							showDSGInfo("RF", "���ʧ��", (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Red1.jpg")
							LogWritter("��ǰ�ּ��ʧ��")
							AddMessage("��ǰ�ּ��ʧ��", True)
						End If
					End If
					
				Case 2
					If car.TireRFID <> "00000000" And Trim(car.TireRFID) <> "" Then
						showDSGInfo("RF", (car.TireRFID), (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Green1.jpg")
					Else
						showDSGInfo("RF", "���ʧ��", (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Red1.jpg")
					End If
					If car.TireLFID <> "00000000" And Trim(car.TireLFID) <> "" Then
						showDSGInfo("LF", (car.TireLFID), (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Green1.jpg")
						LogWritter("��ǰ�ּ������" & car.TireLFID)
						AddMessage("��ǰ�ּ�����")
					Else
						'Modiy by ZCJ 2012=07-09 ���������ڼ����̥��״̬����
						If isInTesting = True Then
							AddMessage("���ڼ����ǰ�֡���")
						Else
							showDSGInfo("LF", "���ʧ��", (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Red1.jpg")
							LogWritter("��ǰ�ּ��ʧ��")
							AddMessage("��ǰ�ּ��ʧ��", True)
						End If
					End If
					
				Case 3
					If car.TireRFID <> "00000000" And Trim(car.TireRFID) <> "" Then
						showDSGInfo("RF", (car.TireRFID), (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Green1.jpg")
					Else
						showDSGInfo("RF", "���ʧ��", (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Red1.jpg")
					End If
					If car.TireLFID <> "00000000" And Trim(car.TireLFID) <> "" Then
						showDSGInfo("LF", (car.TireLFID), (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Green1.jpg")
					Else
						showDSGInfo("LF", "���ʧ��", (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Red1.jpg")
					End If
					If car.TireRRID <> "00000000" And Trim(car.TireRRID) <> "" Then
						showDSGInfo("RR", (car.TireRRID), (car.TireRRMdl), (car.TireRRPre), (car.TireRRTemp), (car.TireRRBattery), (car.TireRRAcSpeed), "Green1.jpg")
						LogWritter("�Һ��ּ������" & car.TireRRID)
						AddMessage("�Һ��ּ�����")
					Else
						'Modiy by ZCJ 2012=07-09 ���������ڼ����̥��״̬����
						If isInTesting = True Then
							AddMessage("���ڼ���Һ��֡���")
						Else
							showDSGInfo("RR", "���ʧ��", (car.TireRRMdl), (car.TireRRPre), (car.TireRRTemp), (car.TireRRBattery), (car.TireRRAcSpeed), "Red1.jpg")
							LogWritter("�Һ��ּ��ʧ��")
							AddMessage("�Һ��ּ��ʧ��", True)
						End If
					End If
					
				Case 4
					If car.TireRFID <> "00000000" And Trim(car.TireRFID) <> "" Then
						showDSGInfo("RF", (car.TireRFID), (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Green1.jpg")
					Else
						showDSGInfo("RF", "���ʧ��", (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Red1.jpg")
					End If
					If car.TireLFID <> "00000000" And Trim(car.TireLFID) <> "" Then
						showDSGInfo("LF", (car.TireLFID), (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Green1.jpg")
					Else
						showDSGInfo("LF", "���ʧ��", (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Red1.jpg")
					End If
					If car.TireRRID <> "00000000" And Trim(car.TireRRID) <> "" Then
						showDSGInfo("RR", (car.TireRRID), (car.TireRRMdl), (car.TireRRPre), (car.TireRRTemp), (car.TireRRBattery), (car.TireRRAcSpeed), "Green1.jpg")
					Else
						showDSGInfo("RR", "���ʧ��", (car.TireRRMdl), (car.TireRRPre), (car.TireRRTemp), (car.TireRRBattery), (car.TireRRAcSpeed), "Red1.jpg")
					End If
					If car.TireLRID <> "00000000" And Trim(car.TireLRID) <> "" Then
						showDSGInfo("LR", (car.TireLRID), (car.TireLRMdl), (car.TireLRPre), (car.TireLRTemp), (car.TireLRBattery), (car.TireLRAcSpeed), "Green1.jpg")
						LogWritter("����ּ������" & car.TireLRID)
						AddMessage("����ּ�����")
					Else
						'Modiy by ZCJ 2012=07-09 ���������ڼ����̥��״̬����
						If isInTesting = True Then
							AddMessage("���ڼ������֡���")
						Else
							showDSGInfo("LR", "���ʧ��", (car.TireLRMdl), (car.TireLRPre), (car.TireLRTemp), (car.TireLRBattery), (car.TireLRAcSpeed), "Red1.jpg")
							LogWritter("����ּ��ʧ��")
							AddMessage("����ּ��ʧ��", True)
						End If
					End If
					
			End Select
		End If
		
	End Sub

	'��ʼ��ɨ�������Ϣ
	Public Sub initDictionary()
		On Error Resume Next
		
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select vin from vincoll order by id asc")
		inputCode.RemoveAll()
		Me.List1.Items.Clear()
		frmInfo.ListOutput.Items.Clear()
		Do While Not rs.EOF
			inputCode.Add(Mid(rs.Fields("vin").value, 2, 17), rs.Fields("vin").value)
			Me.List1.Items.Add(Mid(rs.Fields("vin").value, 2, 17))
			frmInfo.ListOutput.Items.Add(VB.Right(Mid(rs.Fields("vin").value, 2, 17), 8))
			rs.MoveNext()
		Loop 
		rs.Close()
		'UPGRADE_NOTE: �ڶԶ��� rs ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		rs = Nothing
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
	End Sub
	'��ʼ���Ų�������Ϣ
	Public Sub iniListInput()
		On Error Resume Next
		Dim cnn As New ADODB.Connection
		Dim rs As New ADODB.Recordset
		Dim tmpStr As String
		Dim flag As Boolean
		Dim tmpVIN As String
		
		cnn.Open(DBCnnStr)
		If Me.txtVIN.Text <> "" Then
			tmpVIN = Me.txtVIN.Text
		Else
			tmpVIN = readState("vin")
		End If
		rs = cnn.Execute("select uw5anoseq from vinlist where vin = '" & tmpVIN & "' order by uw5anoseq desc limit 1")
		If rs.EOF Then
			
			If Me.txtVIN.Text <> "" Then
				Exit Sub
			Else
				tmpStr = "999999999"
			End If
		Else
			tmpStr = rs.Fields(0).Value
		End If
		If TestStateFlag = 9999 And Me.txtVIN.Text = "" Then
			rs = cnn.Execute("select vin from  vinlist where uw5anoseq > '" & tmpStr & "'  order by uw5anoseq asc limit 8")
		Else
			rs = cnn.Execute("select vin from  vinlist where uw5anoseq >= '" & tmpStr & "'  order by uw5anoseq asc limit 8")
		End If
		frmInfo.ListInput.Items.Clear()
		
		flag = False
		Do While Not rs.EOF
			frmInfo.ListInput.Items.Add(VB.Right(rs.Fields(0).Value, 8))
			
			If flag Then
				frmInfo.labNext.Text = VB.Right(rs.Fields(0).Value, 8)
				flag = False
			End If
			If inputCode.Count <> 0 Then
				If rs.Fields(0).Value = inputCode.Keys(inputCode.Count - 1) Then
					flag = True
				End If
			End If
			rs.MoveNext()
		Loop 
		If inputCode.Count = 0 Then
			frmInfo.labNext.Text = VB.Right(VB6.GetItemString(frmInfo.ListInput, 0), 8)
		End If
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
	End Sub
	'ϵͳ���ã�����λ
    Public Sub resetList()
        If BreakFlag Then Exit Sub

        VINCode = "" 'Add by ZCJ 2012-12-08
        MTOCCode = "InitMTOCCode" 'Add by ZCJ 2012-12-08

        delallColl()
        initDictionary()

        If testEndDelyed = False And TestStateFlag <> -1 Then
            TestStateFlag = 9999
        End If
        If TestStateFlag <> -1 Then
            resetState()
            LogWritter(txtVin.Text & "�������!")
            LogWritter("============================================================")
        End If
        txtVin.Text = ""

        setFrm(9999)
        updateState("state", CStr(TestStateFlag)) 'Add by ZCJ 20121207
        frmInfo.labNow.Text = ""

        iniListInput()

        Call closeAll()
        oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
        oIOCard.OutputController(Lamp_Buzzer_IOPort, False) '�رշ���
    End Sub
	'��������ƶ�
	Private Sub FrmMain_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.FromPixelsUserX(eventArgs.X, 0, 15360, 1024)
		Dim Y As Single = VB6.FromPixelsUserY(eventArgs.Y, 0, 12214.5, 768)
		Dim ReturnVal As Integer
		If Button = 1 And Y > 0 And Y < 496 Then
			X = ReleaseCapture()
			ReturnVal = SendMessage(Handle.ToInt32, WM_NCLBUTTONDOWN, HTCAPTION, 0)
		End If
	End Sub
	'��С������
	Private Sub Picture1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Picture1.Click
		Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
	End Sub
	'�˳�ϵͳ
	Private Sub picExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picExit.Click
		Dim msgR As Short
		msgR = MsgBox("�Ƿ��˳�̥ѹ��ʼ��ϵͳ��", MsgBoxStyle.YesNo, "ϵͳ��ʾ")
		If msgR = 7 Then Exit Sub
		
		oIOCard.OutputController(Lamp_Buzzer_IOPort, False) '�رշ���
		Call closeAll()
        System.Environment.Exit(0)
	End Sub
	'�����������رյ������������ߣ��κε�����������Ҫ�ȵ��ø÷���
	Public Sub closeAll()
		'oIOCard.OutputController Lamp_Buzzer_IOPort, False '�رշ���
		oIOCard.OutputController(Lamp_GreenLight_IOPort, False) '�ر���ɫ
		oIOCard.OutputController(Lamp_GreenFlash_IOPort, False) '�ر���ɫ��˸
		oIOCard.OutputController(Lamp_YellowLight_IOPort, False) '�رջ�ɫ
		oIOCard.OutputController(Lamp_YellowFlash_IOPort, False) '�رջ�ɫ��˸
		oIOCard.OutputController(Lamp_RedLight_IOPort, False) '�رպ�ɫ
		oIOCard.OutputController(Lamp_RedFlash_IOPort, False) '�رպ�ɫ��˸
	End Sub
	'������������ʷ��¼��ѯ
	Private Sub picCommandHis_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picCommandHis.Click
		frmHistory.Show()
	End Sub
	'������������־��ѯ
	Private Sub picCommandLog_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picCommandLog.Click
		frmShowLog.Show()
	End Sub
	'�������������ݵ���
	Private Sub picCommandOut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picCommandOut.Click
		frmDateZone.Show()
	End Sub
	'����������ϵͳ����
	Private Sub picCommandConifg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picCommandConifg.Click
		frmPSW.Show()
	End Sub
	'����������ϵͳ��λ
	Private Sub picCommandReset_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picCommandReset.Click
		If BreakFlag Then Exit Sub
		LogWritter("ϵͳ����λ")
		resetList()
		
		Call closeAll()
		oIOCard.OutputController(Lamp_Buzzer_IOPort, False) '�رշ���
		flashLamp(Lamp_GreenFlash_IOPort) '�̵�
	End Sub
	'����������״̬���
	Private Sub Timer_StatusQuery_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer_StatusQuery.Tick
		On Error Resume Next
		'Exit Sub
		mm = mm + 1
		If mm < TimerStatus Then
			Exit Sub
		End If
		
		'���ListMsg������
		Do While ListMsg.Items.Count > 20
			ListMsg.Items.RemoveAt(0)
		Loop 
		
		If TestStateFlag <= 5 Then
			mm = 0
			Exit Sub
		End If
		
		'��ѯӲ�̿ռ�״̬
		HDDStateQuery()
		'��ѯ����������״̬
		TSStateQuery()
		'��ѯ����״̬
		NetStateQuery()
		
		mm = 0
	End Sub
	'������������ѯӲ�̿ռ�״̬
	Private Sub HDDStateQuery()
		System.Windows.Forms.Application.DoEvents()
		If GetHDDState(DBPosition, SpaceAvailable) = 1 Then
			Me.Picture9.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
			frmInfo.Picture9.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
		Else
			Me.Picture9.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			frmInfo.Picture9.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			LogWritter(DBPosition & "Ӳ�̿��ÿռ䲻��" & CStr(VB6.Format(SpaceAvailable / 1024, "##.#")) & "G")
			AddMessage("Ӳ�̿��ÿռ䲻��", True)
			'flashBuzzerLamp Lamp_RedLight_IOPort
			'        DelayTime 2000
			'        oIOCard.OutputController Lamp_RedLight_IOPort, False
			'        oIOCard.OutputController rdOutput, False
			'        oIOCard.OutputController Lamp_GreenFlash_IOPort, True
		End If
		
	End Sub
	'������������ѯ����������״̬
	Private Sub TSStateQuery()
		On Error GoTo Error_Renamed
		System.Windows.Forms.Application.DoEvents()
		
		If TestStateFlag <= 5 Then
			Exit Sub
		End If
		
		oRVT520.ResetResult()
		If oRVT520.status = 3 Then
			Me.Picture8.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
			frmInfo.Picture8.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
		Else
			Me.Picture8.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			frmInfo.Picture8.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			LogWritter("�Ҳ����������")
			AddMessage("�Ҳ����������", True)
			'flashBuzzerLamp Lamp_RedLight_IOPort
			'        DelayTime 2000
			'        oIOCard.OutputController Lamp_RedLight_IOPort, False
			'        oIOCard.OutputController rdOutput, False
			'        oIOCard.OutputController Lamp_GreenFlash_IOPort, True
		End If
		
		oLVT520.ResetResult()
		If oLVT520.status = 3 Then
			Me.Picture7.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
			frmInfo.Picture7.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
		Else
			Me.Picture7.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			frmInfo.Picture7.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			LogWritter("������������")
			AddMessage("������������", True)
			'flashBuzzerLamp Lamp_RedLight_IOPort
			'        DelayTime 2000
			'        oIOCard.OutputController Lamp_RedLight_IOPort, False
			'        oIOCard.OutputController rdOutput, False
			'        oIOCard.OutputController Lamp_GreenFlash_IOPort, True
		End If
		
		Exit Sub
Error_Renamed: 
		LogWritter("��ѯ������״̬����")
	End Sub
	'������������ѯ����״̬
	Private Sub NetStateQuery()
		On Error GoTo Error_Renamed
		
		Dim objConn As ADODB.Connection
		Dim objConnMES As ADODB.Connection
		
		System.Windows.Forms.Application.DoEvents()
		
		'̽�鱾�����ݿ����״̬
		objConn = New ADODB.Connection
		objConn.ConnectionTimeout = 2
		objConn.Open(DBCnnStr)
		If objConn.state = ADODB.ObjectStateEnum.adStateOpen Then
			Me.PicNet.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
			frmInfo.PicNet.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
			'            LogWritter "MES���ݿ���������"
			objConn.Close()
		Else
			Me.PicNet.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			frmInfo.PicNet.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			LogWritter("�������ݿ������쳣")
			AddMessage("�������ݿ������쳣", True)
	
		End If
		
		'UPGRADE_NOTE: �ڶԶ��� objConn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objConn = Nothing
		
		If Ping(MES_IP) Then
			Me.PicInd.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
			frmInfo.PicInd.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
			'        LogWritter "��������"
			
			'̽��MES����״̬
			On Error GoTo ErrMES
			
			objConnMES = New ADODB.Connection
			objConnMES.ConnectionTimeout = 3
			System.Windows.Forms.Application.DoEvents()
			objConnMES.Open(MESCnnStr)
			If objConnMES.state = ADODB.ObjectStateEnum.adStateOpen Then
				Me.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
				frmInfo.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
				'            LogWritter "MES���ݿ���������"
				objConnMES.Close()
			Else
				Me.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
				frmInfo.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
				LogWritter("MES���ݿ������쳣")
				AddMessage("MES���ݿ������쳣", True)
	
			End If
			
		Else
			Me.PicInd.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			frmInfo.PicInd.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			LogWritter("�����쳣")
			AddMessage("�����쳣", True)
			
			Me.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			frmInfo.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			LogWritter("MES���ݿ������쳣")
		End If
		
		'UPGRADE_NOTE: �ڶԶ��� objConnMES ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objConnMES = Nothing
		
		Exit Sub
ErrMES: 
		Me.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
		frmInfo.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
		LogWritter("MES���ݿ������쳣")
		'UPGRADE_NOTE: �ڶԶ��� objConnMES ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objConnMES = Nothing
		Exit Sub
Error_Renamed: 
		LogWritter("���������ݿ�״̬̽����̳���" & Err.Description)
	End Sub
	'������ϵͳͬ���Ų�������Ϣ
	Private Sub Timer_DataSync_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer_DataSync.Tick
		On Error GoTo Err_Renamed
		nn = nn + 1
		
		If nn < TimerN Then
			Exit Sub
		End If
		
		If TestStateFlag <= 5 Then
			nn = 0
			Exit Sub
		End If
		
		If Not Ping(MES_IP) Then
			nn = 0
			Exit Sub
		End If
		
		Dim objConn As ADODB.Connection
		Dim objConnMES As ADODB.Connection
		Dim objRs As ADODB.Recordset
		Dim objTmpRs As ADODB.Recordset
		Dim objRsMES As ADODB.Recordset
		Dim strSQL As String
		
		LogWritter("�����Զ�ͬ���Ų���������")
		
		On Error GoTo ErrMES
		'�ȶ�ȡMES�ϵ�����
		objConnMES = New ADODB.Connection
		objRsMES = New ADODB.Recordset
		objConnMES.ConnectionTimeout = 3
		System.Windows.Forms.Application.DoEvents()
		objConnMES.Open(MESCnnStr)
		If objConnMES.state <> ADODB.ObjectStateEnum.adStateOpen Then
			LogWritter("MES���ݿ�����ʧ�ܣ��޷�ͬ������")
			'UPGRADE_NOTE: �ڶԶ��� objConnMES ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
			objConnMES = Nothing
			Exit Sub
		End If
		strSQL = "select * from mesprd.IF_VEHICLE_TPMS_INFO where tpms_process=0 order by pa_off_seq asc"
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
		
		nn = 0
		Exit Sub
ErrMES: 
		LogWritter("MES���ݿ�����ʧ�ܣ��޷�ͬ������")
		'UPGRADE_NOTE: �ڶԶ��� objConnMES ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objConnMES = Nothing
		nn = 0
		Exit Sub
Err_Renamed: 
		LogWritter("����ͬ�����̳���")
		nn = 0
	End Sub
	
	'��ʾϵͳ��Ϣ
	Public Sub AddMessage(ByRef txt As String, Optional ByRef isAlert As Boolean = False)
		
		Me.ListMsg.Items.Add("[" & Now & "]" & txt)
		If isAlert Then
			frmInfo.txtInfo.ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
			frmInfo.txtInfo.Text = txt
        Else
            frmInfo.txtInfo.ForeColor = System.Drawing.ColorTranslator.FromOle(&H80000002)
            frmInfo.txtInfo.Text = txt
		End If
		Me.ListMsg.SelectedIndex = Me.ListMsg.Items.Count - 1
	End Sub
	'��ʼ�����������
	Private Sub initFrom(ByRef isInitVin As Boolean)
        Me.picLF.Image = ImageList.Images.Item(6) ' Me.ImageList.ListImages(6).Picture
        frmInfo.picLF.Image = frmInfo.ImageList.Images.Item(6) 'frmInfo.ImageList.ListImages(6).Picture
        Me.picLR.Image = ImageList.Images.Item(6) 'Me.ImageList.ListImages(6).Picture
        frmInfo.picLR.Image = frmInfo.ImageList.Images.Item(6) 'frmInfo.ImageList.ListImages(6).Picture
        Me.picRF.Image = ImageList.Images.Item(6) 'Me.ImageList.ListImages(6).Picture
        frmInfo.picRF.Image = frmInfo.ImageList.Images.Item(6) 'frmInfo.ImageList.ListImages(6).Picture
        Me.picRR.Image = ImageList.Images.Item(6) 'Me.ImageList.ListImages(6).Picture
        frmInfo.picRR.Image = frmInfo.ImageList.Images.Item(6) 'frmInfo.ImageList.ListImages(6).Picture
		
		Me.txtLR.Text = ""
		Me.lbLRMdl.Text = ""
		Me.lbLRPre.Text = ""
		Me.lbLRTemp.Text = ""
		Me.lbLRBattery.Text = ""
		Me.lbLRAcSpeed.Text = ""
		
		frmInfo.txtLR.Text = ""
		frmInfo.lbLRMdl.Text = ""
		frmInfo.lbLRPre.Text = ""
		frmInfo.lbLRTemp.Text = ""
		frmInfo.lbLRBattery.Text = ""
		frmInfo.lbLRAcSpeed.Text = ""
		
		Me.txtLF.Text = ""
		Me.lbLFMdl.Text = ""
		Me.lbLFPre.Text = ""
		Me.lbLFTemp.Text = ""
		Me.lbLFBattery.Text = ""
		Me.lbLFAcSpeed.Text = ""
		
		frmInfo.txtLF.Text = ""
		frmInfo.lbLFMdl.Text = ""
		frmInfo.lbLFPre.Text = ""
		frmInfo.lbLFTemp.Text = ""
		frmInfo.lbLFBattery.Text = ""
		frmInfo.lbLFAcSpeed.Text = ""
		
		Me.txtRR.Text = ""
		Me.lbRRMdl.Text = ""
		Me.lbRRPre.Text = ""
		Me.lbRRTemp.Text = ""
		Me.lbRRBattery.Text = ""
		Me.lbRRAcSpeed.Text = ""
		
		frmInfo.txtRR.Text = ""
		frmInfo.lbRRMdl.Text = ""
		frmInfo.lbRRPre.Text = ""
		frmInfo.lbRRTemp.Text = ""
		frmInfo.lbRRBattery.Text = ""
		frmInfo.lbRRAcSpeed.Text = ""
		
		Me.txtRF.Text = ""
		Me.lbRFMdl.Text = ""
		Me.lbRFPre.Text = ""
		Me.lbRFTemp.Text = ""
		Me.lbRFBattery.Text = ""
		Me.lbRFAcSpeed.Text = ""
		
		frmInfo.txtRF.Text = ""
		frmInfo.lbRFMdl.Text = ""
		frmInfo.lbRFPre.Text = ""
		frmInfo.lbRFTemp.Text = ""
		frmInfo.lbRFBattery.Text = ""
		frmInfo.lbRFAcSpeed.Text = ""
		
		If isInitVin Then
			txtVIN.Text = ""
			frmInfo.labVin.Text = "̥ѹ����ʼ��ϵͳ"
		End If
	End Sub

    'ɨ��ǹ���ڽ����¼�
    Private Sub SerialPortVIN_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPortVIN.DataReceived, SerialPortBT.DataReceived
        Try
            Dim serial As IO.Ports.SerialPort = sender
            If BreakFlag Then Exit Sub

            Threading.Thread.Sleep(100)
            TestCode = serial.ReadExisting()
            If String.IsNullOrEmpty(TestCode) Then Exit Sub

            Dim subCode As String = TestCode.Substring(0, 17)
            Select Case subCode
                Case "R010000000000000C"
                    LogWritter("1ɨ����������")
                    resetList()
                    Exit Sub
                Case "R020000000000000C"
                    barCodeFlag = True
                    Exit Sub
            End Select
         
            Debug.Print(TestCode)
            Call txtVIN_KeyPress(txtVin, New System.Windows.Forms.KeyPressEventArgs(Chr(13)))
        Catch ex As Exception
            log.LogWritter("ɨ��ǹ���ݽ����쳣��")
            log.LogWritter(ex.Message)
        End Try
    End Sub
End Class