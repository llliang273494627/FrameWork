Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FrmMain
	Inherits System.Windows.Forms.Form
	'******************************************************************************
	'** �ļ�����FrmMain.frm
	'** ��  Ȩ��CopyRight (c)
	'** �����ˣ�yangshuai
	'** ��  �䣺shuaigoplay@live.cn
	'** ��  �ڣ�2009-2-27
	'** �޸��ˣ�
	'** ��  �ڣ�
	'** ��  ����DSG��̥���������ϵͳ������
	'** ��  ����1.0
	'******************************************************************************
	
	
	Dim tmpTime As String
	'[2011-7-12 16:54:02] osensor0 - ---True
	'[2011-7-12 16:54:10] osensor1 - ---True
	Dim Step1Time As Short
	'[2011-7-12 16:54:26] osensor2 - ---True
	'[2011-7-12 16:54:28] osensor3 - ---True
	'[2011-7-12 16:54:35] osensor4 - ---True
	'[2011-7-12 16:54:37] osensor2 - ---False
	Dim Step2Time As Short
	'[2011-7-12 16:54:52] osensor5 - ---True
	'[2011-7-12 16:55:03] osensor5 - ---False
	Dim Step3Time As Short
	'[2011-7-12 16:55:23] osensor2 - ---True
	'[2011-7-12 16:55:34] osensor2 - ---False
	Dim Step4Time As Short
	'[2011-7-12 16:55:39] osensor0 - ---False
	'[2011-7-12 16:55:47] osensor1 - ---False
	'[2011-7-12 16:55:48] osensor5 - ---True
	'[2011-7-12 16:55:59] osensor5 - ---False
	'[2011-7-12 16:56:05] osensor3 - ---False
	'[2011-7-12 16:56:12] osensor4 - ---False
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
	Public TimerResultUpLoad As Short '̥ѹ������ϴ�����
	
	Public MTCodelen As Short '����������ĳ���
	
	
	'״̬����
	Public DBPosition As String '���ݿ�洢���̷�
	Public SpaceAvailable As Integer '���ÿռ�澯��ֵ
	
	
	Private firstFlag As Boolean
	Private secondFlag As Boolean
	
	Private WithEvents osensorCommand As CSensor
	Private WithEvents osensorLine As CSensor
	Private car As CCar
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
	'�ϴ�״̬
	Dim tmpsign As Boolean
	
	Public CarTypeCode As String 'Add by ZCJ 2014-05-08 ��ǰ��λ�����ĳ���
	
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
	
	'����ʹ�ã�0�Ŵ�����״̬
	Dim sensorstate0 As Boolean
	'����ʹ�ã�1�Ŵ�����״̬
	Dim sensorstate1 As Boolean
	'����ʹ�ã�2�Ŵ�����״̬
	Dim sensorstate2 As Boolean
	'����ʹ�ã�3�Ŵ�����״̬
	Dim sensorstate3 As Boolean
	'����ʹ�ã�4�Ŵ�����״̬
	Dim sensorstate4 As Boolean
	'����ʹ�ã�5�Ŵ�����״̬
	Dim sensorstate5 As Boolean
	
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
	
	Private Sub Command13_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command13.Click
		osensor0 = New CSensor
		osensor0.state = True
		Call osensor0_onChange((osensor0.state))
	End Sub
	
	'�������
	Private Sub Command14_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command14.Click
		'Call DSGTestEnd
		Dim mtoc As String
		Dim tmpCar As CCar
		tmpCar = New CCar
		'mtoc = tmpCar.GetMtocFromVinColl("11")
		tmpCar.VINCode = "11"
		tmpCar.Save(5)
	End Sub
	
	Private Sub Command15_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command15.Click
		osensor1 = New CSensor
		osensor1.state = True
		Call osensor1_onChange((osensor1.state))
	End Sub
	
	Private Sub Command16_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command16.Click
		osensor2 = New CSensor
		osensor2.state = True
		osensor1.state = True
		Call osensor2_onChange((osensor2.state))
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
	
	Private Sub Command18_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command18.Click
		osensor3 = New CSensor
		osensor3.state = True
		Call osensor3_onChange((osensor3.state))
	End Sub
	
	Private Sub Command19_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command19.Click
		osensor4 = New CSensor
		osensor4.state = True
		Call osensor4_onChange((osensor4.state))
	End Sub
	
	'�������빤λ
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		If inputCode.Count <> 0 Then
			'�ٴ�����DSGStart
			'UPGRADE_WARNING: δ�ܽ������� inputCode() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			Call Me.DSGTestStart(CStr(inputCode(inputCode.Keys(0))))
		End If
	End Sub
	
	Private Sub Command20_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command20.Click
		osensor5 = New CSensor
		osensor5.state = True
		osensor1.state = False
		Call osensor5_onChange((osensor5.state))
	End Sub
	'-------------------------ֱ�Ӹ�ֵ����------------------------------
	Public Function Rand_Number(ByRef Num As Object) As String 'numΪ����λ��
		Randomize()
		'UPGRADE_NOTE: str �������� str_Renamed�� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"��
		Dim i, N As Short
		Dim str_Renamed As String
		'UPGRADE_WARNING: δ�ܽ������� Num ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		For i = 1 To Num
			N = Int(Rnd() * 2) + 1 '�������1��2��ֵ
			Select Case N '�ж���һ����Ҫ���ɵ������ֻ���Сд��ĸ
				Case 1 '��������
					str_Renamed = str_Renamed & Chr(Int(Rnd() * 10) + 48) '��0-9��Χ��������һ������
				Case 2 '����Сд��ĸ
					str_Renamed = str_Renamed & Chr(Int(Rnd() * 26) + 97) '��a-z��Χ��������һ����ĸ
			End Select
		Next 
		Rand_Number = str_Renamed
	End Function
	Private Sub Command21_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command21.Click
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
			
			'            For i = 0 To RVT520_icount
			'                oRVT520.ReadResult
			'                tmpID = oRVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" Then
			'                    Exit For
			'                End If
			'            Next i
			'
			'            LogWritter "��һ�μ�����ݣ�" & tmpID
			'
			'            If tmpID = "00000000" Or Trim(tmpID) = "" Then '�ڶ��β���
			'                LogWritter "��ʼ�ڶ��μ����ǰ�֡���"
			'                oLVT520.ResetResult
			'                oLVT520.Start "Comm"    '����������Ҳ��������������ź�
			'                oRVT520.ResetResult
			'                oRVT520.Start "Comm"
			'                For i = 0 To RVT520_icount
			'                    oRVT520.ReadResult
			'                    tmpID = oRVT520.TireIDResult
			'                    If tmpID <> "00000000" And Trim(tmpID) <> "" Then
			'                        Exit For
			'                    End If
			'                Next i
			'
			'                LogWritter "�ڶ��μ�����ݣ�" & tmpID
			'
			'            End If
			
			isInTesting = False 'Add by ZCJ 2012-07-09 ��ǰ�ּ�����
			
			tmpID = Rand_Number(8)
			LogWritter("��ǰ�ּ�����ݣ�" & tmpID)
			car.TireRFMdl = CStr(1)
			car.TireRFPre = CStr(20)
			car.TireRFTemp = CStr(25)
			car.TireRFBattery = "OK"
			car.TireRFAcSpeed = CStr(0)
			car.TireRFID = tmpID
			
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
	
	Private Sub Command22_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command22.Click
		
		'    If DateDiff("s", tmpTime, Now) <= Step2Time Then
		'        MsgBox ("��Ӧʱ��δ�ﵽҪ��!")
		'        Exit Sub
		'    Else
		'        tmpTime = Now
		'    End If
		
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
			'            For i = 0 To LVT520_icount
			'                oLVT520.ReadResult
			'                tmpID = oLVT520.TireIDResult
			'                'If tmpID <> "00000000" And Trim(tmpID) <> "" Then
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
			'                    Exit For
			'                End If
			'            Next i
			'
			'            LogWritter "��һ�μ�����ݣ�" & tmpID
			'
			'            'If tmpID = "00000000" Or Trim(tmpID) = "" Then '�ڶ��β���
			'            If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '�ڶ��β���
			'                LogWritter "��ʼ�ڶ��μ����ǰ�֡���"
			'                oRVT520.ResetResult
			'                oRVT520.Start "Comm"    '�ұ߱��������Ҳ��������������ź�
			'                oLVT520.ResetResult
			'                oLVT520.Start "Comm"
			'                For i = 0 To LVT520_icount
			'                    oLVT520.ReadResult
			'                    tmpID = oLVT520.TireIDResult
			'                    If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
			'                        Exit For
			'                    End If
			'                Next i
			'
			'                LogWritter "�ڶ��μ�����ݣ�" & tmpID
			'
			'            End If
			
			
			isInTesting = False 'Add by ZCJ 2012-07-09 ��ǰ�ּ�����
			
			
			tmpID = Rand_Number(8)
			LogWritter("��ǰ�ּ�����ݣ�" & tmpID)
			car.TireLFMdl = CStr(1)
			car.TireLFPre = CStr(20)
			car.TireLFTemp = CStr(26)
			car.TireLFBattery = "OK"
			car.TireLFAcSpeed = CStr(0)
			car.TireLFID = tmpID
			
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
	
	Private Sub Command23_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command23.Click
		'    If DateDiff("s", tmpTime, Now) <= Step3Time Then
		'        MsgBox ("��Ӧʱ��δ�ﵽҪ��!")
		'        Exit Sub
		'    Else
		'        tmpTime = Now
		'    End If
		
		
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
			
			'            For i = 0 To RVT520_icount
			'                oRVT520.ReadResult
			'                tmpID = oRVT520.TireIDResult
			'                'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
			'                    Exit For
			'                End If
			'            Next i
			'
			'            LogWritter "��һ�μ�����ݣ�" & tmpID
			'
			'            'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then   '�ڶ��β���
			'            If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '�ڶ��β���
			'                LogWritter "��ʼ�ڶ��μ���Һ��֡���"
			'                oLVT520.ResetResult
			'                oLVT520.Start "Comm"    '����������Ҳ��������������ź�
			'                oRVT520.ResetResult
			'                oRVT520.Start "Comm"
			'                For i = 0 To RVT520_icount
			'                    oRVT520.ReadResult
			'                    tmpID = oRVT520.TireIDResult
			'                    If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
			'                        Exit For
			'                    End If
			'                Next i
			'
			'                LogWritter "�ڶ��μ�����ݣ�" & tmpID
			'
			'            End If
			
			
			isInTesting = False 'Add by ZCJ 2012-07-09 �Һ��ּ�����
			
			tmpID = Rand_Number(8)
			car.TireRRID = tmpID
			LogWritter("�Һ��ּ�����ݣ�" & tmpID)
			car.TireRRMdl = CStr(8)
			car.TireRRPre = CStr(21)
			car.TireRRTemp = CStr(26)
			car.TireRRBattery = "OK"
			car.TireRRAcSpeed = CStr(0)
			
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
	
	Private Sub Command24_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command24.Click
		
		'    If DateDiff("s", tmpTime, Now) <= Step4Time Then
		'        MsgBox ("��Ӧʱ��δ�ﵽҪ��!")
		'        Exit Sub
		'    Else
		'        tmpTime = Now
		'    End If
		
		
		TestStateFlag = 3
		Dim tmpID As String
		Dim i As Integer
		If TestStateFlag = 3 Then
			
			isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ��������
			AddMessage("���ڼ������֡���")
			LogWritter("��ʼ��һ�μ������֡���")
			oLVT520.ResetResult()
			oLVT520.Start("Comm")
			
			'            For i = 0 To LVT520_icount
			'                oLVT520.ReadResult
			'                tmpID = oLVT520.TireIDResult
			'                'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID Then
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
			'                    Exit For
			'                End If
			'            Next i
			'
			'            LogWritter "��һ�μ�����ݣ�" & tmpID
			'
			'            'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Then '�ڶ��β���
			'            If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then
			'                LogWritter "��ʼ�ڶ��μ������֡���"
			'                oRVT520.ResetResult
			'                oRVT520.Start "Comm"    '�ұ߱��������Ҳ��������������ź�
			'                oLVT520.ResetResult
			'                oLVT520.Start "Comm"
			'                For i = 0 To LVT520_icount
			'                    oLVT520.ReadResult
			'                    tmpID = oLVT520.TireIDResult
			'                    If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
			'                        Exit For
			'                    End If
			'                Next i
			'
			'                LogWritter "�ڶ��μ�����ݣ�" & tmpID
			'
			'            End If
			
			
			isInTesting = False 'Add by ZCJ 2012-07-09 ����ּ�����
			
			
			tmpID = Rand_Number(8)
			car.TireLRID = tmpID
			LogWritter("����ּ�����ݣ�" & tmpID)
			car.TireLRMdl = CStr(1)
			car.TireLRPre = CStr(50)
			car.TireLRTemp = CStr(22)
			car.TireLRBattery = "OK"
			car.TireLRAcSpeed = CStr(0)
			
			updateState("dsglr", tmpID)
			updateState("mdllr", (car.TireLRMdl))
			updateState("prelr", (car.TireLRPre))
			updateState("templr", (car.TireLRTemp))
			updateState("batterylr", (car.TireLRBattery))
			updateState("acspeedlr", (car.TireLRAcSpeed))
			
			TestStateFlag = 4 '���ּ�����
			setFrm(TestStateFlag)
			updateState("state", CStr(TestStateFlag))
			
			If TestStateFlag = 4 Then
				LogWritter("�����ɣ�")
				tmpsign = car.Save(SpaceAvailable)
				'            If tmpsign = False And PrintModel <> 0 Then
				'                Call printErrResult(car) '�ϴ�mesʧ�ܴ�ӡ
				'            End If
				
				If CDbl(car.GetTestState) = 15 Then
					'                car.CheckResultIsOverStandard
					'                If car.IsOverStandard Then
					'                     Call printErrResult(car)
					'                Else
					'flashLamp Lamp_YellowFlash_IOPort
					flashLamp(Lamp_GreenLight_IOPort)
					'flashLamp Lamp_GreenFlash_IOPort
					'                End If
					If PrintModel = "1" Then
						Call printErrResult(car) 'ȫ����ӡ
					End If
				Else
					flashBuzzerLamp(Lamp_RedLight_IOPort)
					AddMessage("�����ʧ�ܡ�", True)
					LogWritter("�����ʧ�ܣ�")
					'                If car.printFlag And car.LastCar.GetTestState <> 15 Then
					'                    If PrintModel = "2" Or PrintModel = "1" Then
					'                       Call printErrResult(car.LastCar)
					'                    End If
					'                End If
					If PrintModel = "2" Then '��ģʽѡ��ȫ����ӡ�ͽ�ʧ�ܴ�ӡģʽ����ģʽʱ��ӡ
						Call printErrResult(car)
					End If
				End If
				DSGTestEnd()
			ElseIf TestStateFlag = 9994 Then 
				DSGTestEnd()
			End If
			
		End If
	End Sub
	
	'ϵͳ����
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		
		If BreakFlag Then
			osensorCommand_onChange(True) 'ϵͳ����
		Else
			osensorCommand_onChange(False) '����ϵͳ
		End If
		'    Dim Result As Boolean
		'    Dim arr() As String
		'    arr = Split(mdlValue, ",")
		'    Result = judgeMdlIsOK("1", arr)
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
		DelayTime(2000)
		Do While A < 10000
			A = A + 1
		Loop 
	End Sub
	'-------------------------ֱ�Ӹ�ֵ����------------------------------
	'Public Function Rand_Number(Num) As String 'numΪ����λ��
	'    Randomize
	'    Dim i As Integer, n As Integer, str As String
	'    For i = 1 To Num
	'        n = Int(Rnd * 2) + 1 '�������1��2��ֵ
	'        Select Case n '�ж���һ����Ҫ���ɵ������ֻ���Сд��ĸ
	'        Case 1 '��������
	'            str = str & Chr(Int(Rnd * 10) + 48) '��0-9��Χ��������һ������
	'        Case 2 '����Сд��ĸ
	'            str = str & Chr(Int(Rnd * 26) + 97) '��a-z��Χ��������һ����ĸ
	'        End Select
	'    Next
	'    Rand_Number = str
	'End Function
	''��ǰ��(����ʱ��)
	'Private Sub Command8_Click()
	'
	''    If DateDiff("s", tmpTime, Now) <= Step1Time Then
	''        MsgBox ("��Ӧʱ��δ�ﵽҪ��!")
	''        Exit Sub
	''    Else
	''        tmpTime = Now
	''    End If
	'
	'    'BreakFlag = False  'ϵͳ����
	'    'sensorFlag = True  '��������
	'    TestStateFlag = 0
	'    Dim tmpID As String
	'    Dim i As Long
	'    If TestStateFlag = 0 Then
	'        '�������̣����빤λ
	'        '�����ǰ��
	'
	'        TestStateFlag = 1
	'        updateState "state", CStr(TestStateFlag)
	'        isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ�����ǰ��
	'        AddMessage "���ڼ����ǰ�֡���"
	'        LogWritter "��ʼ��һ�μ����ǰ�֡���"
	'        oRVT520.ResetResult
	'        oRVT520.Start "Comm"
	'
	''        For i = 0 To 20
	''            oRVT520.ReadResult
	''            tmpID = oRVT520.TireIDResult
	''            If tmpID <> "00000000" And Trim(tmpID) <> "" Then
	''                Exit For
	''            End If
	''        Next i
	''        If tmpID = "00000000" Or Trim(tmpID) = "" Then '�ұ�û�в⵽�ز�һ��
	''            LogWritter "��ʼ�ڶ��μ����ǰ�֡���"
	''            oRVT520.ResetResult
	''            oRVT520.Start "Comm"
	''            For i = 0 To 20
	''                oRVT520.ReadResult
	''                tmpID = oRVT520.TireIDResult
	''                If tmpID <> "00000000" And Trim(tmpID) <> "" Then
	''                    Exit For
	''                End If
	''            Next i
	''        End If
	'
	'        For i = 0 To RVT520_icount
	'            oRVT520.ReadResult
	'            tmpID = oRVT520.TireIDResult
	'            If tmpID <> "00000000" And Trim(tmpID) <> "" Then
	'                Exit For
	'            End If
	'        Next i
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '�ڶ��β���
	'            LogWritter "��ʼ�ڶ��μ����ǰ�֡���"
	'            oRVT520.ResetResult
	'            oRVT520.Start "Comm"
	'            For i = 0 To RVT520_icount
	'                oRVT520.ReadResult
	'                tmpID = oRVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '�����β���
	'            LogWritter "��ʼ�����μ����ǰ�֡���"
	'            oRVT520.ResetResult
	'            oRVT520.Start "Comm"
	'            For i = 0 To RVT520_icount
	'                oRVT520.ReadResult
	'                tmpID = oRVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '���Ĵβ���
	'            LogWritter "��ʼ���Ĵμ����ǰ�֡���"
	'            oRVT520.ResetResult
	'            oRVT520.Start "Comm"
	'            For i = 0 To RVT520_icount
	'                oRVT520.ReadResult
	'                tmpID = oRVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '����β���
	'            LogWritter "��ʼ����μ����ǰ�֡���"
	'            oRVT520.ResetResult
	'            oRVT520.Start "Comm"
	'            For i = 0 To RVT520_icount
	'                oRVT520.ReadResult
	'                tmpID = oRVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        isInTesting = False 'Add by ZCJ 2012-07-09 ��ǰ�ּ�����
	'
	'        car.TireRFID = Rand_Number(8)
	'        LogWritter "��ǰ�ּ�����ݣ�" & oRVT520.Result
	'        car.TireRFMdl = 1
	'        car.TireRFPre = 20
	'        car.TireRFTemp = 25
	'        car.TireRFBattery = "OK"
	'        car.TireRFAcSpeed = 0
	'
	'        updateState "dsgrf", tmpID
	'        updateState "mdlrf", car.TireRFMdl
	'        updateState "prerf", car.TireRFPre
	'        updateState "temprf", car.TireRFTemp
	'        updateState "batteryrf", car.TireRFBattery
	'        updateState "acspeedrf", car.TireRFAcSpeed
	'
	'        '��ǰ�ּ�����
	'        setFrm TestStateFlag
	'    End If
	'End Sub
	''��ǰ��(����ʱ��)
	'Private Sub Command9_Click()
	'
	''    If DateDiff("s", tmpTime, Now) <= Step2Time Then
	''        MsgBox ("��Ӧʱ��δ�ﵽҪ��!")
	''        Exit Sub
	''    Else
	''        tmpTime = Now
	''    End If
	'
	'    TestStateFlag = 1
	'    Dim tmpID As String
	'    Dim i As Long
	'
	'    If TestStateFlag = 1 Then
	'        TestStateFlag = 2
	'        updateState "state", CStr(TestStateFlag)
	'        isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ�����ǰ��
	'        AddMessage "���ڼ����ǰ�֡���"
	'        LogWritter "��ʼ��һ�μ����ǰ�֡���"
	'        oLVT520.ResetResult
	'        oLVT520.Start "Comm"
	'
	''        For i = 0 To 40
	''            oLVT520.ReadResult
	''            tmpID = oLVT520.TireIDResult
	''            If tmpID <> "00000000" And Trim(tmpID) <> "" Then
	''                Exit For
	''            End If
	''        Next i
	''        If tmpID = "00000000" Or Trim(tmpID) = "" Then '���û�в⵽�ز�һ��
	''            LogWritter "��ʼ�ڶ��μ����ǰ�֡���"
	''            oLVT520.ResetResult
	''            oLVT520.Start "Comm"
	''            For i = 0 To 40
	''                oLVT520.ReadResult
	''                tmpID = oLVT520.TireIDResult
	''                If tmpID <> "00000000" And Trim(tmpID) <> "" Then
	''                    Exit For
	''                End If
	''            Next i
	''        End If
	'
	'        For i = 0 To LVT520_icount
	'            oLVT520.ReadResult
	'            tmpID = oLVT520.TireIDResult
	'            'If tmpID <> "00000000" And Trim(tmpID) <> "" Then
	'            If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
	'                Exit For
	'            End If
	'        Next i
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '�ڶ��β���
	'            LogWritter "��ʼ�ڶ��μ����ǰ�֡���"
	'            oLVT520.ResetResult
	'            oLVT520.Start "Comm"
	'            For i = 0 To LVT520_icount
	'                oLVT520.ReadResult
	'                tmpID = oLVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '�����β���
	'            LogWritter "��ʼ�����μ����ǰ�֡���"
	'            oLVT520.ResetResult
	'            oLVT520.Start "Comm"
	'            For i = 0 To LVT520_icount
	'                oLVT520.ReadResult
	'                tmpID = oLVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '���Ĵβ���
	'            LogWritter "��ʼ���Ĵμ����ǰ�֡���"
	'            oLVT520.ResetResult
	'            oLVT520.Start "Comm"
	'            For i = 0 To LVT520_icount
	'                oLVT520.ReadResult
	'                tmpID = oLVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '����β���
	'            LogWritter "��ʼ����μ����ǰ�֡���"
	'            oLVT520.ResetResult
	'            oLVT520.Start "Comm"
	'            For i = 0 To LVT520_icount
	'                oLVT520.ReadResult
	'                tmpID = oLVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        isInTesting = False 'Add by ZCJ 2012-07-09 ��ǰ�ּ�����
	'
	'        car.TireLFID = Rand_Number(8)
	'        LogWritter "��ǰ�ּ�����ݣ�" & oLVT520.Result
	'        car.TireLFMdl = 1
	'        car.TireLFPre = 20
	'        car.TireLFTemp = 26
	'        car.TireLFBattery = "OK"
	'        car.TireLFAcSpeed = 0
	'
	'        updateState "dsglf", tmpID
	'        updateState "mdllf", car.TireLFMdl
	'        updateState "prelf", car.TireLFPre
	'        updateState "templf", car.TireLFTemp
	'        updateState "batterylf", car.TireLFBattery
	'        updateState "acspeedlf", car.TireLFAcSpeed
	'
	'        '��ǰ�ּ�����
	'        setFrm TestStateFlag
	'    End If
	'End Sub
	''�Һ���(����ʱ��)
	'Private Sub Command10_Click()
	'
	''    If DateDiff("s", tmpTime, Now) <= Step3Time Then
	''        MsgBox ("��Ӧʱ��δ�ﵽҪ��!")
	''        Exit Sub
	''    Else
	''        tmpTime = Now
	''    End If
	'
	'
	'    TestStateFlag = 2
	'    Dim tmpID As String
	'    Dim i As Long
	'    If TestStateFlag = 2 Then
	'
	'        TestStateFlag = 3
	'        updateState "state", CStr(TestStateFlag)
	'        isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ����Һ���
	'        AddMessage "���ڼ���Һ��֡���"
	'        LogWritter "��ʼ��һ�μ���Һ��֡���"
	'        oRVT520.ResetResult
	'        oRVT520.Start "Comm"
	'
	''        For i = 0 To 40
	''            oRVT520.ReadResult
	''            tmpID = oRVT520.TireIDResult
	''            If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
	''                Exit For
	''            End If
	''        Next i
	''        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then   '�ұ�û�в⵽�ز�һ��
	''            LogWritter "��ʼ�ڶ��μ���Һ��֡���"
	''            oRVT520.ResetResult
	''            oRVT520.Start "Comm"
	''            For i = 0 To 40
	''                oRVT520.ReadResult
	''                tmpID = oRVT520.TireIDResult
	''                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
	''                    Exit For
	''                End If
	''            Next i
	''        End If
	''        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then   '�ұ�û�в⵽�ز�һ��
	''            LogWritter "��ʼ�����μ���Һ��֡���"
	''            oRVT520.ResetResult
	''            oRVT520.Start "Comm"
	''            For i = 0 To 40
	''                oRVT520.ReadResult
	''                tmpID = oRVT520.TireIDResult
	''                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
	''                    Exit For
	''                End If
	''            Next i
	''        End If
	'
	'        For i = 0 To RVT520_icount
	'            oRVT520.ReadResult
	'            tmpID = oRVT520.TireIDResult
	'            'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
	'            If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
	'                Exit For
	'            End If
	'        Next i
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '�ڶ��β���
	'            LogWritter "��ʼ�ڶ��μ���Һ��֡���"
	'            oRVT520.ResetResult
	'            oRVT520.Start "Comm"
	'            For i = 0 To RVT520_icount
	'                oRVT520.ReadResult
	'                tmpID = oRVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '�����β���
	'            LogWritter "��ʼ�����μ���Һ��֡���"
	'            oRVT520.ResetResult
	'            oRVT520.Start "Comm"
	'            For i = 0 To RVT520_icount
	'                oRVT520.ReadResult
	'                tmpID = oRVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '���Ĵβ���
	'            LogWritter "��ʼ���Ĵμ���Һ��֡���"
	'            oRVT520.ResetResult
	'            oRVT520.Start "Comm"
	'            For i = 0 To RVT520_icount
	'                oRVT520.ReadResult
	'                tmpID = oRVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '����β���
	'            LogWritter "��ʼ����μ���Һ��֡���"
	'            oRVT520.ResetResult
	'            oRVT520.Start "Comm"
	'            For i = 0 To RVT520_icount
	'                oRVT520.ReadResult
	'                tmpID = oRVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        isInTesting = False 'Add by ZCJ 2012-07-09 �Һ��ּ�����
	'
	'        car.TireRRID = Rand_Number(8)
	'        LogWritter "�Һ��ּ�����ݣ�" & oRVT520.Result
	'        car.TireRRMdl = 8
	'        car.TireRRPre = 21
	'        car.TireRRTemp = 26
	'        car.TireRRBattery = "OK"
	'        car.TireRRAcSpeed = 0
	'
	'        updateState "dsgrr", tmpID
	'        updateState "mdlrr", car.TireRRMdl
	'        updateState "prerr", car.TireRRPre
	'        updateState "temprr", car.TireRRTemp
	'        updateState "batteryrr", car.TireRRBattery
	'        updateState "acspeedrr", car.TireRRAcSpeed
	'
	'        TestStateFlag = 3 '�Һ��ּ�����
	'        updateState "state", CStr(TestStateFlag)
	'        setFrm TestStateFlag
	'    End If
	'End Sub
	''�����(����ʱ��)
	'Private Sub Command11_Click()
	'
	''    If DateDiff("s", tmpTime, Now) <= Step4Time Then
	''        MsgBox ("��Ӧʱ��δ�ﵽҪ��!")
	''        Exit Sub
	''    Else
	''        tmpTime = Now
	''    End If
	'
	'
	'    TestStateFlag = 3
	'    Dim tmpID As String
	'    Dim i As Long
	'    If TestStateFlag = 3 Then
	'
	'        isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ��������
	'        AddMessage "���ڼ������֡���"
	'        LogWritter "��ʼ��һ�μ������֡���"
	'        oLVT520.ResetResult
	'        oLVT520.Start "Comm"
	'
	''        For i = 0 To 40
	''            oLVT520.ReadResult
	''            tmpID = oLVT520.TireIDResult
	''            If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID Then
	''                Exit For
	''            End If
	''        Next i
	''        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Then '���û�в⵽�ز�һ��
	''            LogWritter "��ʼ�ڶ��μ������֡���"
	''            oLVT520.ResetResult
	''            oLVT520.Start "Comm"
	''            For i = 0 To 40
	''                oLVT520.ReadResult
	''                tmpID = oLVT520.TireIDResult
	''                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID Then
	''                    Exit For
	''                End If
	''            Next i
	''        End If
	''        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Then '���û�в⵽�ز�һ��
	''            LogWritter "��ʼ�����μ������֡���"
	''            oLVT520.ResetResult
	''            oLVT520.Start "Comm"
	''            For i = 0 To 40
	''                oLVT520.ReadResult
	''                tmpID = oLVT520.TireIDResult
	''                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID Then
	''                    Exit For
	''                End If
	''            Next i
	''        End If
	'
	'        For i = 0 To LVT520_icount
	'            oLVT520.ReadResult
	'            tmpID = oLVT520.TireIDResult
	'            'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID Then
	'            If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
	'                Exit For
	'            End If
	'        Next i
	'        'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID '�ڶ��β���
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '�ڶ��β���
	'            LogWritter "��ʼ�ڶ��μ������֡���"
	'            oLVT520.ResetResult
	'            oLVT520.Start "Comm"
	'            For i = 0 To LVT520_icount
	'                oLVT520.ReadResult
	'                tmpID = oLVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '�����β���
	'            LogWritter "��ʼ�����μ������֡���"
	'            oLVT520.ResetResult
	'            oLVT520.Start "Comm"
	'            For i = 0 To LVT520_icount
	'                oLVT520.ReadResult
	'                tmpID = oLVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '���Ĵβ���
	'            LogWritter "��ʼ���Ĵμ������֡���"
	'            oLVT520.ResetResult
	'            oLVT520.Start "Comm"
	'            For i = 0 To LVT520_icount
	'                oLVT520.ReadResult
	'                tmpID = oLVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '����β���
	'            LogWritter "��ʼ����μ������֡���"
	'            oLVT520.ResetResult
	'            oLVT520.Start "Comm"
	'            For i = 0 To LVT520_icount
	'                oLVT520.ReadResult
	'                tmpID = oLVT520.TireIDResult
	'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
	'                    Exit For
	'                End If
	'            Next i
	'        End If
	'
	'        isInTesting = False 'Add by ZCJ 2012-07-09 ����ּ�����
	'
	'        car.TireLRID = Rand_Number(8)
	'        LogWritter "����ּ�����ݣ�" & oLVT520.Result
	'        car.TireLRMdl = 1
	'        car.TireLRPre = 23
	'        car.TireLRTemp = 22
	'        car.TireLRBattery = "OK"
	'        car.TireLRAcSpeed = 0
	'
	'        updateState "dsglr", tmpID
	'        updateState "mdllr", car.TireLRMdl
	'        updateState "prelr", car.TireLRPre
	'        updateState "templr", car.TireLRTemp
	'        updateState "batterylr", car.TireLRBattery
	'        updateState "acspeedlr", car.TireLRAcSpeed
	'
	'        TestStateFlag = 4 '���ּ�����
	'        updateState "state", CStr(TestStateFlag)
	'        setFrm TestStateFlag
	'        If TestStateFlag = 4 Then
	'            LogWritter "�����ɣ�"
	'
	'            car.Save
	'            'Call printErrResult(car)
	'            If car.GetTestState = 15 Then
	''����ָ����Χ�򱨾�
	''                car.CheckResultIsOverStandard
	''                If car.IsOverStandard Then
	''                     Call printErrResult(car)
	''                Else
	''                    flashLamp Lamp_YellowFlash_IOPort
	''                End If
	'            Else
	'                flashBuzzerLamp Lamp_RedLight_IOPort
	'                AddMessage "����������ظ�ֵ��", True
	'                LogWritter "����������ظ�ֵ��������ӡ��"
	'                If car.printFlag And car.LastCar.GetTestState <> 15 Then
	'                    Call printErrResult(car.LastCar)
	'                End If
	'
	'                Call printErrResult(car)
	'            End If
	'            DSGTestEnd
	'        ElseIf TestStateFlag = 9994 Then
	'            DSGTestEnd
	'        End If
	'
	'    End If
	'End Sub
	'''-----------------------------------------------------------------------
	
	
	'--------------------------���豸��ֵ����----------------------------
	'��ǰ��(����ʱ��)
	Private Sub Command8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command8.Click
		
		'    If DateDiff("s", tmpTime, Now) <= Step1Time Then
		'        MsgBox ("��Ӧʱ��δ�ﵽҪ��!")
		'        Exit Sub
		'    Else
		'        tmpTime = Now
		'    End If
		
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
			
			For i = 0 To RVT520_icount
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
				oLVT520.ResetResult()
				oLVT520.Start("Comm") '����������Ҳ��������������ź�
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To RVT520_icount
					oRVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" Then
						Exit For
					End If
				Next i
				
				LogWritter("�ڶ��μ�����ݣ�" & tmpID)
				
			End If
			'        oRVT520.ResetResult
			'        oRVT520.Start "Comm"
			'
			'
			'
			'        For i = 0 To RVT520_icount
			'            oRVT520.ReadResult
			'            tmpID = oRVT520.TireIDResult
			'            If tmpID <> "00000000" And Trim(tmpID) <> "" Then
			'                Exit For
			'            End If
			'        Next i
			'
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '�ڶ��β���
			'            LogWritter "��ʼ�ڶ��μ����ǰ�֡���"
			'            oRVT520.ResetResult
			'            oRVT520.Start "Comm"
			'            For i = 0 To RVT520_icount
			'                oRVT520.ReadResult
			'                tmpID = oRVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '�����β���
			'            LogWritter "��ʼ�����μ����ǰ�֡���"
			'            oRVT520.ResetResult
			'            oRVT520.Start "Comm"
			'            For i = 0 To RVT520_icount
			'                oRVT520.ReadResult
			'                tmpID = oRVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			'
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '���Ĵβ���
			'            LogWritter "��ʼ���Ĵμ����ǰ�֡���"
			'            oRVT520.ResetResult
			'            oRVT520.Start "Comm"
			'            For i = 0 To RVT520_icount
			'                oRVT520.ReadResult
			'                tmpID = oRVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			'
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '����β���
			'            LogWritter "��ʼ����μ����ǰ�֡���"
			'            oRVT520.ResetResult
			'            oRVT520.Start "Comm"
			'            For i = 0 To RVT520_icount
			'                oRVT520.ReadResult
			'                tmpID = oRVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			
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
		
		'    If DateDiff("s", tmpTime, Now) <= Step2Time Then
		'        MsgBox ("��Ӧʱ��δ�ﵽҪ��!")
		'        Exit Sub
		'    Else
		'        tmpTime = Now
		'    End If
		
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
			For i = 0 To LVT520_icount
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
				oRVT520.ResetResult()
				oRVT520.Start("Comm") '�ұ߱��������Ҳ��������������ź�
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To LVT520_icount
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
				
				LogWritter("�ڶ��μ�����ݣ�" & tmpID)
				
			End If
			'        oLVT520.ResetResult
			'        oLVT520.Start "Comm"
			
			'        For i = 0 To 40
			'            oLVT520.ReadResult
			'            tmpID = oLVT520.TireIDResult
			'            If tmpID <> "00000000" And Trim(tmpID) <> "" Then
			'                Exit For
			'            End If
			'        Next i
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '���û�в⵽�ز�һ��
			'            LogWritter "��ʼ�ڶ��μ����ǰ�֡���"
			'            oLVT520.ResetResult
			'            oLVT520.Start "Comm"
			'            For i = 0 To 40
			'                oLVT520.ReadResult
			'                tmpID = oLVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			
			'        For i = 0 To LVT520_icount
			'            oLVT520.ReadResult
			'            tmpID = oLVT520.TireIDResult
			'            'If tmpID <> "00000000" And Trim(tmpID) <> "" Then
			'            If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
			'                Exit For
			'            End If
			'        Next i
			'
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '�ڶ��β���
			'            LogWritter "��ʼ�ڶ��μ����ǰ�֡���"
			'            oLVT520.ResetResult
			'            oLVT520.Start "Comm"
			'            For i = 0 To LVT520_icount
			'                oLVT520.ReadResult
			'                tmpID = oLVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '�����β���
			'            LogWritter "��ʼ�����μ����ǰ�֡���"
			'            oLVT520.ResetResult
			'            oLVT520.Start "Comm"
			'            For i = 0 To LVT520_icount
			'                oLVT520.ReadResult
			'                tmpID = oLVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			'
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '���Ĵβ���
			'            LogWritter "��ʼ���Ĵμ����ǰ�֡���"
			'            oLVT520.ResetResult
			'            oLVT520.Start "Comm"
			'            For i = 0 To LVT520_icount
			'                oLVT520.ReadResult
			'                tmpID = oLVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			'
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '����β���
			'            LogWritter "��ʼ����μ����ǰ�֡���"
			'            oLVT520.ResetResult
			'            oLVT520.Start "Comm"
			'            For i = 0 To LVT520_icount
			'                oLVT520.ReadResult
			'                tmpID = oLVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			
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
		
		'    If DateDiff("s", tmpTime, Now) <= Step3Time Then
		'        MsgBox ("��Ӧʱ��δ�ﵽҪ��!")
		'        Exit Sub
		'    Else
		'        tmpTime = Now
		'    End If
		
		
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
			
			For i = 0 To RVT520_icount
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
				oLVT520.ResetResult()
				oLVT520.Start("Comm") '����������Ҳ��������������ź�
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To RVT520_icount
					oRVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
				
				LogWritter("�ڶ��μ�����ݣ�" & tmpID)
				
			End If
			'        oRVT520.ResetResult
			'        oRVT520.Start "Comm"
			
			'        For i = 0 To 40
			'            oRVT520.ReadResult
			'            tmpID = oRVT520.TireIDResult
			'            If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
			'                Exit For
			'            End If
			'        Next i
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then   '�ұ�û�в⵽�ز�һ��
			'            LogWritter "��ʼ�ڶ��μ���Һ��֡���"
			'            oRVT520.ResetResult
			'            oRVT520.Start "Comm"
			'            For i = 0 To 40
			'                oRVT520.ReadResult
			'                tmpID = oRVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then   '�ұ�û�в⵽�ز�һ��
			'            LogWritter "��ʼ�����μ���Һ��֡���"
			'            oRVT520.ResetResult
			'            oRVT520.Start "Comm"
			'            For i = 0 To 40
			'                oRVT520.ReadResult
			'                tmpID = oRVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			
			'        For i = 0 To RVT520_icount
			'            oRVT520.ReadResult
			'            tmpID = oRVT520.TireIDResult
			'            'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
			'            If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
			'                Exit For
			'            End If
			'        Next i
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '�ڶ��β���
			'            LogWritter "��ʼ�ڶ��μ���Һ��֡���"
			'            oRVT520.ResetResult
			'            oRVT520.Start "Comm"
			'            For i = 0 To RVT520_icount
			'                oRVT520.ReadResult
			'                tmpID = oRVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '�����β���
			'            LogWritter "��ʼ�����μ���Һ��֡���"
			'            oRVT520.ResetResult
			'            oRVT520.Start "Comm"
			'            For i = 0 To RVT520_icount
			'                oRVT520.ReadResult
			'                tmpID = oRVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			'
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '���Ĵβ���
			'            LogWritter "��ʼ���Ĵμ���Һ��֡���"
			'            oRVT520.ResetResult
			'            oRVT520.Start "Comm"
			'            For i = 0 To RVT520_icount
			'                oRVT520.ReadResult
			'                tmpID = oRVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			'
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '����β���
			'            LogWritter "��ʼ����μ���Һ��֡���"
			'            oRVT520.ResetResult
			'            oRVT520.Start "Comm"
			'            For i = 0 To RVT520_icount
			'                oRVT520.ReadResult
			'                tmpID = oRVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			
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
		
		'    If DateDiff("s", tmpTime, Now) <= Step4Time Then
		'        MsgBox ("��Ӧʱ��δ�ﵽҪ��!")
		'        Exit Sub
		'    Else
		'        tmpTime = Now
		'    End If
		
		
		TestStateFlag = 3
		Dim tmpID As String
		Dim i As Integer
		If TestStateFlag = 3 Then
			
			isInTesting = True 'Add by ZCJ 2012-07-09 ��ʼ��������
			AddMessage("���ڼ������֡���")
			LogWritter("��ʼ��һ�μ������֡���")
			oLVT520.ResetResult()
			oLVT520.Start("Comm")
			
			For i = 0 To LVT520_icount
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
				oRVT520.ResetResult()
				oRVT520.Start("Comm") '�ұ߱��������Ҳ��������������ź�
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To LVT520_icount
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					End If
				Next i
				
				LogWritter("�ڶ��μ�����ݣ�" & tmpID)
				
			End If
			'        oLVT520.ResetResult
			'        oLVT520.Start "Comm"
			
			'        For i = 0 To 40
			'            oLVT520.ReadResult
			'            tmpID = oLVT520.TireIDResult
			'            If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID Then
			'                Exit For
			'            End If
			'        Next i
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Then '���û�в⵽�ز�һ��
			'            LogWritter "��ʼ�ڶ��μ������֡���"
			'            oLVT520.ResetResult
			'            oLVT520.Start "Comm"
			'            For i = 0 To 40
			'                oLVT520.ReadResult
			'                tmpID = oLVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Then '���û�в⵽�ز�һ��
			'            LogWritter "��ʼ�����μ������֡���"
			'            oLVT520.ResetResult
			'            oLVT520.Start "Comm"
			'            For i = 0 To 40
			'                oLVT520.ReadResult
			'                tmpID = oLVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			
			'        For i = 0 To LVT520_icount
			'            oLVT520.ReadResult
			'            tmpID = oLVT520.TireIDResult
			'            'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID Then
			'            If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
			'                Exit For
			'            End If
			'        Next i
			'        'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID '�ڶ��β���
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '�ڶ��β���
			'            LogWritter "��ʼ�ڶ��μ������֡���"
			'            oLVT520.ResetResult
			'            oLVT520.Start "Comm"
			'            For i = 0 To LVT520_icount
			'                oLVT520.ReadResult
			'                tmpID = oLVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '�����β���
			'            LogWritter "��ʼ�����μ������֡���"
			'            oLVT520.ResetResult
			'            oLVT520.Start "Comm"
			'            For i = 0 To LVT520_icount
			'                oLVT520.ReadResult
			'                tmpID = oLVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			'
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '���Ĵβ���
			'            LogWritter "��ʼ���Ĵμ������֡���"
			'            oLVT520.ResetResult
			'            oLVT520.Start "Comm"
			'            For i = 0 To LVT520_icount
			'                oLVT520.ReadResult
			'                tmpID = oLVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			'
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '����β���
			'            LogWritter "��ʼ����μ������֡���"
			'            oLVT520.ResetResult
			'            oLVT520.Start "Comm"
			'            For i = 0 To LVT520_icount
			'                oLVT520.ReadResult
			'                tmpID = oLVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
			'                    Exit For
			'                End If
			'            Next i
			'        End If
			
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
			setFrm(TestStateFlag)
			updateState("state", CStr(TestStateFlag))
			
			If TestStateFlag = 4 Then
				LogWritter("�����ɣ�")
				
				tmpsign = car.Save(SpaceAvailable)
				'            If tmpsign = False Then
				'                Call printErrResult(car) '�ϴ�ʧ�ܴ�ӡ
				'            End If
				
				If CDbl(car.GetTestState) = 15 Then
					'                car.CheckResultIsOverStandard
					'                If car.IsOverStandard Then
					'                     Call printErrResult(car)
					'                Else
					flashLamp(Lamp_YellowFlash_IOPort)
					'flashLamp Lamp_GreenFlash_IOPort
					'                End If
					'                If PrintModel = "1" Or tmpsign = False Then
					'                   Call printErrResult(car) 'ȫ����ӡ
					'                End If
				Else
					flashBuzzerLamp(Lamp_RedLight_IOPort)
					AddMessage("�����ʧ�ܡ�", True)
					LogWritter("�����ʧ�ܣ�")
					'LogWritter "�����ʧ�ܡ�������ӡ��"
					'                If car.printFlag And car.LastCar.GetTestState <> 15 Then
					'                    If PrintModel = "2" Or PrintModel = "1" Then
					'                       Call printErrResult(car.LastCar)
					'                    End If
					'                End If
					'                If PrintModel = "2" Or PrintModel = "1" Then '��ģʽѡ��ȫ����ӡ�ͽ�ʧ�ܴ�ӡģʽ����ģʽʱ��ӡ
					'                   Call printErrResult(car)
					'                End If
				End If
				DSGTestEnd()
			ElseIf TestStateFlag = 9994 Then 
				DSGTestEnd()
			End If
			
		End If
	End Sub
	'----------------------------------------------
	
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
        modPublic.Main()
        'Add by ZCJ 2012-07-09 ��ʼ������״̬
        isInTesting = False
        osen0Time = ""
        'Add by ZCJ 2012-07-09 ��ʼ�����ʱ��
        tmpTime = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Second, -30, Now))

        car = New CCar

        barCodeFlag = False
        'frmInfo.Show
        initFrom(True)
        Dim testFlag As Boolean
        TestStateFlag = CShort(readState("state"))
        testFlag = CBool(readState("test")) '�Ƿ��DSG

        'TimerN = getConfigValue("T_RunParam", "Timer", "TimerDataSync")     '�Ų�����ͬ������
        TimerStatus = CShort(getConfigValue("T_RunParam", "Timer", "TimerStatus")) 'ϵͳ״̬���������
        DBPosition = getConfigValue("T_RunParam", "Status", "DBPosition") '���ݿ������̷�
        SpaceAvailable = CInt(getConfigValue("T_RunParam", "Status", "SpaceAvailable")) '���ݿ�����Ӳ�̿��ÿռ�����

        '̥ѹ������ϴ�����
        TimerResultUpLoad = CShort(getConfigValue("T_RunParam", "Timer", "TimerResultUpLoad"))
        '�����DSGϵͳ����δ�����ɣ��ȼ����Ѽ���˵�����
        If testFlag And TestStateFlag <> 9999 Then
            car = getRunStateCar()
            Me.txtVin.Text = car.VINCode
        End If
        '����Ѽ����ɣ�������ݿ��м���VIN
        If TestStateFlag > 9000 And TestStateFlag < 9999 Or TestStateFlag = -1 Then
            Me.txtVin.Text = readState("vin")
        End If
        frmInfo.labNow.Text = VB.Right(Me.txtVin.Text, 17)
        If Me.txtVin.Text <> "" Then
            frmInfo.labVin.Text = Me.txtVin.Text
        End If
        setFrm(TestStateFlag)

        '    Step1Time = 4 '8
        '    Step2Time = 13 '17
        '    Step3Time = 13 '17
        '    Step4Time = 14 '18

        'MTCodelen = getConfigValue("T_CtrlParam", "Len", "MTCodeLen") '������ĳ���
        Step1Time = CShort(getConfigValue("T_CtrlParam", "StepTime", "Step1Time")) '
        Step2Time = CShort(getConfigValue("T_CtrlParam", "StepTime", "Step2Time"))
        Step3Time = CShort(getConfigValue("T_CtrlParam", "StepTime", "Step3Time"))
        Step4Time = CShort(getConfigValue("T_CtrlParam", "StepTime", "Step4Time"))

        updateState("state", CStr(TestStateFlag))
        '������󼯺�
        inputCode = New Scripting.Dictionary

        'Modiy by ZCJ 2012-07-09 �������¼��ƶ����˴�
        osensorCommand = sensorCommand '�����¼�
        osensorCommand_onChange(True)

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

        initDictionary() '��ʼ��ɨ�����
        'iniListInput  '��ʼ���Ų����� ��Ҫ
        flashLamp(Lamp_GreenLight_IOPort)
        Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
        Call setWirledComScan() '��ʼ��ɨ��ǹ�Ĵ���
        Call setWirlessComScan()
    End Sub
	
	'�رճ����ȹرյ��������ͷŴ���
	Private Sub FrmMain_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Call closeAll()
		
	End Sub
	
	
	
	
	'��������ǹͨ��
	Private Sub MSCommBT_OnComm(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MSCommBT.OnComm
		On Error GoTo MSCommBT_OnComm_Err
		If BreakFlag Then Exit Sub
		DelayTime(100)
		Dim tmp As Object
		Dim strin As String
		
		'UPGRADE_WARNING: δ�ܽ������� MSCommBT.Input ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		'UPGRADE_WARNING: δ�ܽ������� tmp ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		tmp = MSCommBT.Input
		'UPGRADE_WARNING: δ�ܽ������� tmp ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		If tmp = "" Then Exit Sub
		'UPGRADE_WARNING: δ�ܽ������� tmp ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		strin = strin & tmp
		TestCode = strin
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
		'UPGRADE_WARNING: δ�ܽ������� tmp ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		tmp = ""
		Call txtVIN_KeyPress(txtVIN, New System.Windows.Forms.KeyPressEventArgs(Chr(13)))
		Exit Sub
MSCommBT_OnComm_Err: 
		LogWritter("����ɨ��ǹͨ�Ŵ���" & Err.Description)
	End Sub
	'�������ϵĸ�λ��ť�¼�
	Private Sub oRDCommand_onChange(ByRef state As Boolean) Handles oRDCommand.onChange
		Call picCommandReset_Click(picCommandReset, New System.EventArgs())
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
			'AddMessage "�����ѽ��빤λ"
			flashLamp(Lamp_YellowFlash_IOPort)
		ElseIf osensor1.state And osensor4.state Then 
			If TestStateFlag < 10 And TestStateFlag <> 3 And TestStateFlag <> 0 And TestStateFlag <> -1 Then
				'If TestStateFlag < 10 And TestStateFlag <> 1 And TestStateFlag <> 3 And TestStateFlag <> 0 Then
				LogWritter("�����ɣ�")
				
				car.Save(SpaceAvailable)
				If CDbl(car.GetTestState) = 15 Then
					'                car.CheckResultIsOverStandard
					'                If car.IsOverStandard Then
					'                     Call printErrResult(car)
					'                End If
				Else
					'�װ���ʾ
					AddMessage("ǰ��̥ѹIDѧϰ��λ��", True)
					'��־��¼
					LogWritter(car.VINCode & "̥ѹIDѧϰ��λ��")
					'��һ����ʾǰ��̥ѹIDѧϰ��λ
					Me.frErrorText.Visible = True
					'�����
					oIOCard.OutputController(Lamp_RedLight_IOPort, True)
					'                    '�������
					'                    DSGTestEnd
					'ϵͳ��λ
					resetList()
				End If
				AddMessage("��ע������Ƿ���ȷ", True)
				
				DSGTestEnd()
				
				DelayTime(1000)
				oIOCard.OutputController(rdOutput, False)
				oIOCard.OutputController(Lamp_RedLight_IOPort, False)
				oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
			ElseIf TestStateFlag > 9990 And TestStateFlag <> 9995 And TestStateFlag <> 9999 And TestStateFlag <> -1 Then 
				'ElseIf TestStateFlag > 9990 And TestStateFlag <> 9998 And TestStateFlag <> 9997 And TestStateFlag <> 9995 And TestStateFlag <> 9999 Then
				AddMessage("��ע������Ƿ���ȷ", True)
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
			'If True Then
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
				'�����ұ�VT520
				oRVT520.ResetResult()
				'����VT520
				oRVT520.Start("Comm")
				'ѭ����ȡ
				For i = 0 To RVT520_icount
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
					'�����ұ�VT520
					oRVT520.Start("Comm")
					'ѭ����ȡ
					For i = 0 To RVT520_icount
						oRVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" Then
							Exit For
						End If
					Next i
					
					LogWritter("�ڶ��μ�����ݣ�" & tmpID)
					
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 ��ǰ�ּ�����
				
				car.TireRFID = tmpID
				LogWritter(car.VINCode & "��ǰ�ּ�����ݣ�" & oRVT520.Result)
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
				'�����Ҳ�VT520
				oRVT520.ResetResult()
				'����VT520
				oRVT520.Start("Comm")
				'ѭ����ȡ
				For i = 0 To RVT520_icount
					oRVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oRVT520.TireIDResult
					
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
				
				LogWritter("��һ�μ�����ݣ�" & tmpID)
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '�ڶ��β���
					LogWritter("��ʼ�ڶ��μ���Һ��֡���")
					'�ұߴ���
					oRVT520.Start("Comm")
					'ѭ����ȡ
					For i = 0 To RVT520_icount
						oRVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oRVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
							Exit For
						End If
					Next i
					
					LogWritter("�ڶ��μ�����ݣ�" & tmpID)
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 �Һ��ּ�����
				
				car.TireRRID = tmpID
				LogWritter(car.VINCode & "�Һ��ּ�����ݣ�" & oRVT520.Result)
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
				'�������VT520
				oLVT520.ResetResult()
				'����VT520
				oLVT520.Start("Comm")
				'ѭ����ȡ
				For i = 0 To LVT520_icount
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
				
				LogWritter("��һ�μ�����ݣ�" & tmpID)
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '�ڶ��β���
					LogWritter("��ʼ�ڶ��μ����ǰ�֡���")
					'����VT520
					oLVT520.Start("Comm")
					'ѭ����ȡ
					For i = 0 To LVT520_icount
						oLVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
							Exit For
						End If
					Next i
					
					LogWritter("�ڶ��μ�����ݣ�" & tmpID)
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 ��ǰ�ּ�����
				
				car.TireLFID = tmpID
				LogWritter(car.VINCode & "��ǰ�ּ�����ݣ�" & oLVT520.Result)
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
				'�������VT520
				oLVT520.ResetResult()
				'����VT520
				oLVT520.Start("Comm")
				'ѭ����ȡ
				For i = 0 To LVT520_icount
					oLVT520.ReadResult()
					'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					tmpID = oLVT520.TireIDResult
					
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					ElseIf osensor0.state And osensor1.state Then 
						'�װ���ʾ
						AddMessage("ǰ��̥ѹIDѧϰ��λ��", True)
						'��־��¼
						LogWritter(car.VINCode & "̥ѹIDѧϰ��λ��")
						'��һ����ʾǰ��̥ѹIDѧϰ��λ
						Me.frErrorText.Visible = True
						'�����
						oIOCard.OutputController(Lamp_RedLight_IOPort, True)
						'                    '�������
						'                    DSGTestEnd
						'ϵͳ��λ
						resetList()
						'����
						flashBuzzerLamp(Lamp_RedLight_IOPort)
						Exit Sub
					End If
				Next i
				
				LogWritter("��һ�μ�����ݣ�" & tmpID)
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then
					LogWritter("��ʼ�ڶ��μ������֡���")
					
					oLVT520.Start("Comm")
					For i = 0 To LVT520_icount
						oLVT520.ReadResult()
						'UPGRADE_WARNING: δ�ܽ������� oLVT520.TireIDResult ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
							Exit For
						ElseIf osensor0.state And osensor1.state Then 
							'�װ���ʾ
							AddMessage("ǰ��̥ѹIDѧϰ��λ��", True)
							'��־��¼
							LogWritter(car.VINCode & "̥ѹIDѧϰ��λ��")
							'��һ����ʾǰ��̥ѹIDѧϰ��λ
							Me.frErrorText.Visible = True
							'�����
							oIOCard.OutputController(Lamp_RedLight_IOPort, True)
							'                        '�������
							'                        DSGTestEnd
							'ϵͳ��λ
							resetList()
							'����
							flashBuzzerLamp(Lamp_RedLight_IOPort)
							Exit Sub
						End If
					Next i
					
					LogWritter("�ڶ��μ�����ݣ�" & tmpID)
					
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 ����ּ�����
				
				car.TireLRID = tmpID
				LogWritter(car.VINCode & "����ּ�����ݣ�" & oLVT520.Result)
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
				
				tmpsign = car.Save(SpaceAvailable) '��������
				'            If tmpsign = False Then
				'                Call printErrResult(car) '�ϴ�mesʧ�ܴ�ӡ
				'            End If
				
				
				If CDbl(car.GetTestState) = 15 Then
					'                car.CheckResultIsOverStandard
					'                If car.IsOverStandard Then
					'                     Call printErrResult(car)
					'                Else
					flashLamp(Lamp_YellowFlash_IOPort)
					'flashLamp Lamp_GreenFlash_IOPort
					'                End If
					If PrintModel = "1" Then
						Call printErrResult(car) 'ȫ����ӡ
					End If
				Else
					flashBuzzerLamp(Lamp_RedLight_IOPort)
					AddMessage("�����ʧ�ܡ�", True)
					LogWritter("�����ʧ�ܣ�")
					'LogWritter "�����ʧ�ܡ�������ӡ��"
					'                If car.printFlag And car.LastCar.GetTestState <> 15 Then
					'                    If PrintModel = "2" Or PrintModel = "1" Then
					'                       Call printErrResult(car.LastCar)
					'                    End If
					'                End If
					If PrintModel = "2" Or PrintModel = "1" Then '��ģʽѡ��ȫ����ӡ�ͽ�ʧ�ܴ�ӡģʽ����ģʽʱ��ӡ
						Call printErrResult(car)
					End If
				End If
				DSGTestEnd()
				
				DelayTime(1000)
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
			'Timer_PrintError.Interval = 1000
		Else
			AddMessage("ϵͳ�ѱ��������������", True)
			LogWritter("ϵͳ��������")
			'Timer_PrintError.Interval = 0
		End If
	End Sub
	'ͣ���¼�
	Private Sub osensorLine_onChange(ByRef state As Boolean) Handles osensorLine.onChange
		SensorLogWritter("sensorLine----" & CStr(state))
		sensorFlag = state
	End Sub
	
	
	
	Private Sub Timer_PrintError_Timer()
		On Error GoTo Err_Renamed
		HH = HH + 1
		
		If HH < 5 Then
			Exit Sub
		End If
		
		'Call printErrCode
		Call printErrCodeAuto()
		
		HH = 0
		Exit Sub
Err_Renamed: 
		LogWritter("printErrCode timer error")
		HH = 0
		Exit Sub
	End Sub
	
	
	
	Private Sub Timer_UpLoadResult_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer_UpLoadResult.Tick
		'On Error GoTo Err
		'    HH = HH + 1
		'
		'    If HH < TimerResultUpLoad Then
		'        Exit Sub
		'    End If
		'
		'    If TestStateFlag > -1 And TestStateFlag <= 5 Then
		'        HH = 0
		'        Exit Sub
		'    End If
		'
		''    '�ϴ������
		'   Call UpLoadTestResult
		'
		'    HH = 0
		'    Exit Sub
		'Err:
		'    LogWritter "upload test result timer error"
		'    HH = 0
		'    Exit Sub
	End Sub
	'�����������ϴ����������������
	Private Sub UpLoadTestResult()
		On Error GoTo Error_Renamed
		
		System.Windows.Forms.Application.DoEvents()
		
		Dim localCnn As ADODB.Connection
		Dim localRst As ADODB.Recordset
		Dim remoteCnn As ADODB.Connection
		Dim remoteRst As ADODB.Recordset
		Dim strSQL As String
		Dim sql As String
		Dim tiresID As String
		
		localCnn = New ADODB.Connection
		localRst = New ADODB.Recordset
		remoteCnn = New ADODB.Connection
		remoteRst = New ADODB.Recordset
		
		
		localCnn.ConnectionTimeout = 2
		localCnn.CommandTimeout = 2
		localCnn.Open(DBCnnStr)
		
		
		remoteCnn.ConnectionTimeout = 2
		remoteCnn.CommandTimeout = 2
		remoteCnn.Open(MESCnnStr)
		localRst = localCnn.Execute("select ""VIN"",""ID022"",""ID020"",""ID023"",""ID021"" from ""T_Result"" where ""UploadSign"" is null or ""UploadSign"" = false")
		Do While Not localRst.EOF
			If localRst.Fields("ID020").Value & "" <> "" And localRst.Fields("ID020").Value & "" <> "00000000" And localRst.Fields("ID022").Value & "" <> "" And localRst.Fields("ID022").Value & "" <> "00000000" And localRst.Fields("ID021").Value & "" <> "" And localRst.Fields("ID021").Value & "" <> "00000000" And localRst.Fields("ID023").Value & "" <> "" And localRst.Fields("ID023").Value & "" <> "00000000" Then
				tiresID = ""
				'��ǰ
				If localRst.Fields("ID022").Value & "" = "" Then
					tiresID = tiresID & "00000000"
				Else
					tiresID = tiresID & localRst.Fields("ID022").Value
				End If
				'��ǰ
				If localRst.Fields("ID020").Value & "" = "" Then
					tiresID = tiresID & "00000000"
				Else
					tiresID = tiresID & localRst.Fields("ID020").Value
				End If
				'���
				If localRst.Fields("ID023").Value & "" = "" Then
					tiresID = tiresID & "00000000"
				Else
					tiresID = tiresID & localRst.Fields("ID023").Value
				End If
				'�Һ�
				If localRst.Fields("ID021").Value & "" = "" Then
					tiresID = tiresID & "00000000"
				Else
					tiresID = tiresID & localRst.Fields("ID021").Value
				End If
				strSQL = "select * from ACTIA_DSG where ""VIN"" = '" & localRst.Fields("VIN").Value & "' "
				'remoteRst.Open strSQL, MESCnnStr, adOpenStatic, adLockOptimistic
				'remoteCnn.Open MESCnnStr
				remoteRst = remoteCnn.Execute(strSQL)
				If remoteRst.EOF Then
					'                remoteRst.AddNew
					'                remoteRst("VIN_CODE") = localRst("VIN")
					'                remoteRst("TPMS_SENSOR_ID") = tiresID
					'                remoteRst("TIME") = DateTime.Now
					sql = "insert into ACTIA_DSG (""VIN"",""TPMSID"",""TIME"") values ('" & localRst.Fields("VIN").Value & "','" & tiresID & "',getdate())"
				Else
					'                remoteRst("TPMS_SENSOR_ID") = tiresID
					'                remoteRst("TIME") = DateTime.Now
					sql = "update tpms_result set ""TPMSID""= '" & tiresID & "',""TIME"" = getdate() where ""VIN_CODE""='" & localRst.Fields("VIN").Value & "' "
				End If
				
				remoteCnn.Execute(sql)
				'remoteRst.Update
				remoteRst.Close()
				'UPGRADE_NOTE: �ڶԶ��� remoteRst ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
				remoteRst = Nothing
				
				'���±��ص��ϴ���ʶ
				localCnn.Execute("update ""T_Result"" set ""UploadSign"" = true where ""VIN"" = '" & localRst.Fields("VIN").Value & "' ")
				
			End If
			
			localRst.MoveNext()
		Loop 
		remoteCnn.Close()
		'remoteRst.Close
		'localRst.Close
		localCnn.Close()
		
		'UPGRADE_NOTE: �ڶԶ��� remoteCnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		remoteCnn = Nothing
		'UPGRADE_NOTE: �ڶԶ��� remoteRst ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		remoteRst = Nothing
		'UPGRADE_NOTE: �ڶԶ��� localRst ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		localRst = Nothing
		'UPGRADE_NOTE: �ڶԶ��� localCnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		localCnn = Nothing
		
		Exit Sub
Error_Renamed: 
		LogWritter("�ϴ����������������ʱ����" & Err.Description)
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
				txtInputVIN.Text = "�ֹ�¼��VID���س�ȷ��"
				GoTo EventExitSub
			End If
			If VB.Left(TestCode, 17) = "R020000000000000C" Then
				barCodeFlag = True
				txtInputVIN.Text = "�ֹ�¼��VID���س�ȷ��"
				GoTo EventExitSub
			End If
			
			If UCase(TestCode) = "SHOW" Then
				Command13.Visible = True
				Command15.Visible = True
				Command16.Visible = True
				Command18.Visible = True
				Command19.Visible = True
				Command20.Visible = True
				Command3.Visible = True
				txtInputVIN.Text = ""
				GoTo EventExitSub
			ElseIf UCase(TestCode) = "HIDE" Then 
				Command13.Visible = False
				Command15.Visible = False
				Command16.Visible = False
				Command18.Visible = False
				Command19.Visible = False
				Command20.Visible = False
				Command3.Visible = False
				txtInputVIN.Text = ""
				GoTo EventExitSub
			End If
			
			Debug.Print(TestCode)
			Call txtVIN_KeyPress(txtVIN, New System.Windows.Forms.KeyPressEventArgs(Chr(13)))
			txtInputVIN.Text = "�ֹ�¼��VID���س�ȷ��"
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtInputVIN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtInputVIN.Leave
		txtInputVIN.Text = "�ֹ�¼��VID���س�ȷ��"
	End Sub
	
	'����ɨ��������Ϣ
	Private Sub txtVIN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtVIN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		On Error GoTo Err_Renamed
		Dim sql As String
		Dim cnn As New ADODB.Connection
		Dim rs As New ADODB.Recordset
		
		cnn.ConnectionTimeout = TimeOutNum
		cnn.CommandTimeout = TimeOutNum
		cnn.Open(DBCnnStr)
		
		sql = "select count(0) from ""T_Result"" where ""VIN""='" & VB.Left(TestCode, 17) & "'"
		rs = cnn.Execute(sql)
		
		If rs.Fields(0).value <> 0 Then
			resetList()
			AddMessage(VB.Left(TestCode, 17) & "�ظ����")
			'�ر����ݼ�
			If Not rs Is Nothing Then
				If rs.state = 1 Then
					rs.Close()
				End If
			End If
			'UPGRADE_NOTE: �ڶԶ��� rs ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
			rs = Nothing
			'�ر���������
			If Not cnn Is Nothing Then
				If cnn.state = 1 Then
					cnn.Close()
				End If
			End If
			'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
			cnn = Nothing
			GoTo EventExitSub
		End If
		
		'ϵͳ������ɨ��ǹ����Ӧ
		If BreakFlag Then GoTo EventExitSub
		If KeyAscii = 13 Then
			TestCode = Trim(TestCode)
			TestCode = Replace(TestCode, Chr(10), "")
			TestCode = Replace(TestCode, Chr(13), "")
			If Len(TestCode) = 17 And VB.Left(UCase(TestCode), 1) = "T" Then 'VID��
				LogWritter("************************************************************")
				LogWritter("ɨ�����룺" & TestCode)
				LogWritter("************************************************************")
				oIOCard.OutputController(Lamp_Buzzer_IOPort, False) '�رշ��� �ڶ���ɨ��������ȷ��رշ���
				If inputCode.Exists(TestCode) Then
					GoTo EventExitSub
				End If
				inputCode.Add(TestCode, TestCode)
				insertColl(TestCode) '��VIN,���ͣ��Ƿ��̥ѹд�뵽��ʱ��vincoll��
				LogWritter(TestCode & "����ɨ�����")
				Me.List1.Items.Add(TestCode)
				frmInfo.ListOutput.Items.Add(VB.Right(TestCode, 17))
				Me.ListOutput1.Items.Add(VB.Right(TestCode, 8))
				initDictionary()
				
				If inputCode.Count = 1 Then
					'UPGRADE_WARNING: δ�ܽ������� inputCode() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
					txtVIN.Text = CStr(Mid(inputCode(inputCode.Keys(0)), 1, 17))
					frmInfo.labVin.Text = txtVIN.Text
					updateState("test", "False")
					updateState("vin", (txtVIN.Text))
					'����ɨ��vin��ʱ�����ѽ��빤λ���Ҵ���1�Ź�翪��(TestStateFlag = 0����9998)
					If TestStateFlag = 0 Or TestStateFlag = 9998 Then
						resetList()
						txtInputVIN.Text = ""
						GoTo EventExitSub
					End If
					TestStateFlag = -1
					updateState("state", CStr(-1))
					AddMessage("�ȴ�ɨ�賵�����빤λ!")
					If TestStateFlag <> -1 Then
						resetList()
						txtInputVIN.Text = ""
						GoTo EventExitSub
					End If
				End If
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
				LogWritter("�������룺" & TestCode)
				DelayTime(2000)
				oIOCard.OutputController(Lamp_RedLight_IOPort, False)
				oIOCard.OutputController(rdOutput, False)
				If TestStateFlag = 9999 Or TestStateFlag = -1 Then
					oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
				Else
					oIOCard.OutputController(Lamp_GreenLight_IOPort, False)
					oIOCard.OutputController(Lamp_YellowFlash_IOPort, True)
				End If
				'�رշ���
				oIOCard.OutputController(Lamp_Buzzer_IOPort, False)
			End If
		End If
		GoTo EventExitSub
Err_Renamed: 
		LogWritter(Err.Description)
		'�ر����ݼ�
		If Not rs Is Nothing Then
			If rs.state = 1 Then
				rs.Close()
			End If
		End If
		'UPGRADE_NOTE: �ڶԶ��� rs ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		rs = Nothing
		'�ر���������
		If Not cnn Is Nothing Then
			If cnn.state = 1 Then
				cnn.Close()
			End If
		End If
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
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
		
		txtVIN.Text = Mid(vin, 1, 17)
		frmInfo.labVin.Text = txtVIN.Text
		frmInfo.labNow.Text = VB.Right(txtVIN.Text, 17)
		LogWritter("============================================================")
		LogWritter(txtVIN.Text & "��ʼ����!")
		If hasDSG(vin) Then
			LogWritter("������ͨ��,��ʼDSG���!")
			updateState("test", "True")
			updateState("vin", (txtVIN.Text))
			car = New CCar
			car.VINCode = txtVIN.Text
			
			'Add by ZCJ 2014-05-08
			car.CarType = CarTypeCode
			updateState("cartype", (car.CarType))
			LogWritter("��ǰ�����ĳ���Ϊ��" & car.CarType)
			'End Add
			
			TestStateFlag = 0
			setFrm(TestStateFlag)
			updateState("state", CStr(TestStateFlag))
			'�����ʱtxtvin��������ı�״̬
			If TestStateFlag <> 0 Then
				resetList()
				txtInputVIN.Text = ""
				Exit Sub
			End If
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
			'�����ʱtxtvin��������ı�״̬
			If TestStateFlag <> 9998 Then
				resetList()
				txtInputVIN.Text = ""
				Exit Sub
			End If
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
		
		If inputCode.Count <> 0 Then
			'UPGRADE_WARNING: δ�ܽ������� inputCode.Keys() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			LogWritter(CStr(inputCode.Keys(0)) & "�˳�ɨ�����!")
			'UPGRADE_WARNING: δ�ܽ������� inputCode.Keys() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			delColl(CStr(inputCode.Keys(0)))
			inputCode.Remove(inputCode.Keys(0))
		End If
		
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
		
		DelayTime(2000)
		testEndDelyed = False
		'�̵���
		flashLamp(Lamp_GreenLight_IOPort)
		'�رշ���
		oIOCard.OutputController(Lamp_Buzzer_IOPort, False)
		
		'iniListInput
		initDictionary()
		
		If inputCode.Count <> 0 Then
			'�ٴ�����DSGStart
			'UPGRADE_WARNING: δ�ܽ������� inputCode() ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
			Call Me.DSGTestStart(CStr(inputCode(inputCode.Keys(0))))
		Else
			LogWritter("ɨ������г�����Ϊ��")
		End If
		'������ʾ��
		clearListMsg()
		
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
	
	'��������ǹ������Ϣ����
	Public Sub setWirledComScan()
		On Error GoTo Err_Renamed
		MSComVIN.CommPort = CShort(WirledCodeGun_PortNum)
		MSComVIN.InBufferSize = 1024
		MSComVIN.OutBufferSize = 512
		MSComVIN.InBufferCount = 0
		MSComVIN.Settings = WirledCodeGun_Settings
		MSComVIN.InputMode = MSCommLib.InputModeConstants.comInputModeText
		MSComVIN.RTSEnable = True
		MSComVIN.RThreshold = 1
		MSComVIN.PortOpen = True
		Exit Sub
Err_Renamed: 
		LogWritter("��������ǹ�������ô���" & Err.Description)
	End Sub
	'��������ǹ������Ϣ����
	Public Sub setWirlessComScan()
		On Error GoTo Err_Renamed
		MSCommBT.CommPort = CShort(WirlessCodeGun_PortNum)
		MSCommBT.InBufferSize = 1024
		MSCommBT.OutBufferSize = 512
		MSCommBT.InBufferCount = 0
		MSCommBT.Settings = WirlessCodeGun_Settings
		MSCommBT.InputMode = MSCommLib.InputModeConstants.comInputModeText
		MSCommBT.RTSEnable = True
		MSCommBT.RThreshold = 1
		MSCommBT.PortOpen = True
		Exit Sub
Err_Renamed: 
		LogWritter("��������ǹ�������ô���" & Err.Description)
	End Sub
	'��ʾ��ǰ�ļ��״̬
	Public Sub setFrm(ByRef state As Short)
		If state = -1 Then
			AddMessage("�ȴ�ɨ�賵�����빤λ!")
			initFrom(False)
		ElseIf state = 9999 Then 
			AddMessage("�ȴ�ɨ��VID����ʼ����!")
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
					AddMessage("����ɨ��ͨ��,׼����ʼTPMS����!")
					LogWritter("����ɨ��ͨ��,׼����ʼTPMS����!")
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
	'��������ɨ��ǹ��ɨ����Ϣ
	Private Sub MSComVIN_OnComm(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MSComVIN.OnComm
		If BreakFlag Then Exit Sub
		DelayTime(100)
		Dim tmp As Object
		Dim strin As String
		'UPGRADE_WARNING: δ�ܽ������� MSComVIN.Input ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		'UPGRADE_WARNING: δ�ܽ������� tmp ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		tmp = MSComVIN.Input
		'UPGRADE_WARNING: δ�ܽ������� tmp ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		If tmp = "" Then Exit Sub
		'UPGRADE_WARNING: δ�ܽ������� tmp ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		strin = strin & tmp
		TestCode = strin
		If VB.Left(TestCode, 17) = "R010000000000000C" Then
			LogWritter("1ɨ����������")
			resetList()
			Exit Sub
		End If
		If VB.Left(TestCode, 17) = "R020000000000000C" Then
			barCodeFlag = True
			Exit Sub
		End If
		
		Debug.Print(TestCode)
		'UPGRADE_WARNING: δ�ܽ������� tmp ��Ĭ�����ԡ� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"��
		tmp = ""
		Call txtVIN_KeyPress(txtVIN, New System.Windows.Forms.KeyPressEventArgs(Chr(13)))
		
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
		Me.ListOutput1.Items.Clear()
		Do While Not rs.EOF
			inputCode.Add(Mid(rs.Fields("vin").value, 1, 17), rs.Fields("vin").value)
			Me.List1.Items.Add(Mid(rs.Fields("vin").value, 1, 17))
			'        frmInfo.ListOutput.AddItem Right(Mid(rs("vin").value, 2, 17), 8)
			frmInfo.ListOutput.Items.Add((Mid(rs.Fields("vin").value, 1, 17)))
			Me.ListOutput1.Items.Add(VB.Right(Mid(rs.Fields("vin").value, 1, 17), 8))
			rs.MoveNext()
		Loop 
		rs.Close()
		'UPGRADE_NOTE: �ڶԶ��� rs ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		rs = Nothing
		cnn.Close()
		'UPGRADE_NOTE: �ڶԶ��� cnn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		cnn = Nothing
	End Sub
	
	Public Sub clearListMsg()
		On Error GoTo Err_Renamed
		Dim i As Short
		Dim lstIndex As Short
		'��ListMsg�д���Ԫ�ص�ʱ�������
		If Me.ListMsg.Items.Count > 0 Then
			'ȡ�����һ��Ԫ�ص�index
			lstIndex = Me.ListMsg.Items.Count - 1
			'�޳�Ԫ��
			For i = lstIndex To 0 Step -1
				Me.ListMsg.Items.RemoveAt(i)
			Next 
		End If
		Exit Sub
Err_Renamed: 
		LogWritter(Err.Description & "***" & Err.Source)
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
		'MTOCCode = "InitMTOCCode" 'Add by ZCJ 2012-12-08
		
		delallColl()
		initDictionary()
		
		If testEndDelyed = False And TestStateFlag <> -1 Then
			TestStateFlag = 9999
		End If
		If TestStateFlag <> -1 Then
			resetState()
			LogWritter(txtVIN.Text & "�������!")
			LogWritter("============================================================")
		End If
		txtVIN.Text = ""
		
		setFrm(9999)
		updateState("state", CStr(TestStateFlag)) 'Add by ZCJ 20121207
		frmInfo.labNow.Text = ""
		
		'iniListInput '�Ų����в���
		
		Call closeAll()
		oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
		oIOCard.OutputController(Lamp_Buzzer_IOPort, False) '�رշ���
	End Sub
	'��������ƶ�
	Private Sub FrmMain_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.FromPixelsUserX(eventArgs.X, 0, 15360, 1024)
		Dim Y As Single = VB6.FromPixelsUserY(eventArgs.Y, 0, 12389.4, 779)
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
		'ϵͳ����
		resetList()
		'�������
		Me.frErrorText.Visible = False
		'������ʾ��
		clearListMsg()
		
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
			LogWritter(DBPosition & "Ӳ�̿��ÿռ䲻��" & CStr(VB6.Format(SpaceAvailable / 1024, "##.#")) & "C")
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
		'    If Ping(MES_IP) Then
		'        FrmMain.PicInd.Picture = LoadPicture(App.Path & "\img\Green.jpg")
		'        frmInfo.PicInd.Picture = LoadPicture(App.Path & "\img\Green.jpg")
		''        LogWritter "��������"
		'    Else
		'        FrmMain.PicInd.Picture = LoadPicture(App.Path & "\img\Red.jpg")
		'        frmInfo.PicInd.Picture = LoadPicture(App.Path & "\img\Red.jpg")
		'        LogWritter "�����쳣"
		'        AddMessage "�����쳣", True
		'    End If
		
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
			'flashBuzzerLamp Lamp_RedLight_IOPort
			'        DelayTime 2000
			'        oIOCard.OutputController Lamp_RedLight_IOPort, False
			'        oIOCard.OutputController rdOutput, False
			'        oIOCard.OutputController Lamp_GreenFlash_IOPort, True
		End If
		
		'UPGRADE_NOTE: �ڶԶ��� objConn ������������ǰ�������Խ������١� �����Ի�ø�����Ϣ:��ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"��
		objConn = Nothing
		Exit Sub
Error_Renamed: 
		LogWritter("���������ݿ�״̬̽����̳���" & Err.Description)
	End Sub
	''������������ѯ����״̬
	'Private Sub NetStateQuery()
	'    On Error GoTo Error
	'
	'    Dim objConn As Connection
	'    Dim objConnMES As Connection
	'
	'    DoEvents
	'
	'    '̽�鱾�����ݿ����״̬
	'    Set objConn = New Connection
	'    objConn.ConnectionTimeout = 2
	'    objConn.Open DBCnnStr
	'    If objConn.state = adStateOpen Then
	'        FrmMain.PicNet.Picture = LoadPicture(App.Path & "\img\Green.jpg")
	'        frmInfo.PicNet.Picture = LoadPicture(App.Path & "\img\Green.jpg")
	''            LogWritter "MES���ݿ���������"
	'        objConn.Close
	'    Else
	'        FrmMain.PicNet.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'        frmInfo.PicNet.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'        LogWritter "�������ݿ������쳣"
	'        AddMessage "�������ݿ������쳣", True
	'        'flashBuzzerLamp Lamp_RedLight_IOPort
	''        DelayTime 2000
	''        oIOCard.OutputController Lamp_RedLight_IOPort, False
	''        oIOCard.OutputController rdOutput, False
	''        oIOCard.OutputController Lamp_GreenFlash_IOPort, True
	'    End If
	'
	'    Set objConn = Nothing
	'
	'    If Ping(MES_IP) Then
	'        FrmMain.PicInd.Picture = LoadPicture(App.Path & "\img\Green.jpg")
	'        frmInfo.PicInd.Picture = LoadPicture(App.Path & "\img\Green.jpg")
	''        LogWritter "��������"
	'
	'        '̽��MES����״̬
	'        On Error GoTo ErrMES
	'
	'        Set objConnMES = New Connection
	'        objConnMES.ConnectionTimeout = 3
	'        DoEvents
	'        objConnMES.Open MESCnnStr
	'        If objConnMES.state = adStateOpen Then
	'            FrmMain.Picture6.Picture = LoadPicture(App.Path & "\img\Green.jpg")
	'            frmInfo.Picture6.Picture = LoadPicture(App.Path & "\img\Green.jpg")
	''            LogWritter "MES���ݿ���������"
	'            objConnMES.Close
	'        Else
	'            FrmMain.Picture6.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'            frmInfo.Picture6.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'            LogWritter "MES���ݿ������쳣"
	'            AddMessage "MES���ݿ������쳣", True
	'            'flashBuzzerLamp Lamp_RedLight_IOPort
	''            DelayTime 2000
	''            oIOCard.OutputController Lamp_RedLight_IOPort, False
	''            oIOCard.OutputController rdOutput, False
	''            oIOCard.OutputController Lamp_GreenFlash_IOPort, True
	'        End If
	'
	'    Else
	'        FrmMain.PicInd.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'        frmInfo.PicInd.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'        LogWritter "�����쳣"
	'        AddMessage "�����쳣", True
	'        'flashBuzzerLamp Lamp_RedLight_IOPort
	''        DelayTime 2000
	''        oIOCard.OutputController Lamp_RedLight_IOPort, False
	''        oIOCard.OutputController rdOutput, False
	''        oIOCard.OutputController Lamp_GreenFlash_IOPort, True
	'        FrmMain.Picture6.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'        frmInfo.Picture6.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'        LogWritter "MES���ݿ������쳣"
	'    End If
	'
	'    Set objConnMES = Nothing
	'
	'    Exit Sub
	'ErrMES:
	'    FrmMain.Picture6.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'    frmInfo.Picture6.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'    LogWritter "MES���ݿ������쳣"
	'    Set objConnMES = Nothing
	'    Exit Sub
	'Error:
	'    LogWritter "���������ݿ�״̬̽����̳���" & Err.Description
	'End Sub
	'������ϵͳͬ���Ų�������Ϣ
	Private Sub Timer_DataSync_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer_DataSync.Tick
		
		'On Error GoTo Err
		'    nn = nn + 1
		'
		'    If nn < TimerN Then
		'        Exit Sub
		'    End If
		'
		'    If TestStateFlag <= 5 Then
		'        nn = 0
		'        Exit Sub
		'    End If
		'
		'    If Not Ping(MES_IP) Then
		'        nn = 0
		'        Exit Sub
		'    End If
		'    'ͬ����������
		'    LogWritter "�����Զ�ͬ����������"
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
		'        maxGatherDate = " order by id"
		'        LogWritter "����û�г��ʹ��룬����MES�������ϻ�ȡ"
		'    Else '����������������������µ�
		'        strSQL = "SELECT max(""id"") FROM vinlist;"
		'        objRs.Open strSQL, objConn, adOpenKeyset, adLockOptimistic
		'        formatTimeString = objRs.Fields(0).value
		'        maxGatherDate = " where id > " & formatTimeString & " order by id"
		'        '�ر���������
		'        If Not objRs Is Nothing Then
		'            If objRs.state = 1 Then
		'                objRs.Close
		'            End If
		'        End If
		'        LogWritter "�������³���idΪ" & formatTimeString
		'    End If
		'    '��ʼ����
		'    Set objConnMES = New Connection
		'    Set objRsMES = New Recordset
		'    objConnMES.ConnectionTimeout = 3
		'    objConnMES.Open MESCnnStr
		'    strSQL = "select * from ACTIA_VINLIST" & maxGatherDate
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
		'                strSQL = "SELECT * FROM vinlist where vin = '" & objRsMES("VIN") & "'"
		'                objRs.Open strSQL, objConn, adOpenStatic, adLockOptimistic
		'                '���û�������
		'                If objRs.RecordCount <= 0 Then
		'                    strSQL = "INSERT INTO vinlist(""id"",""vin"", ""tpms"", ""carcode"",""optioncode"",""time"") VALUES ('" & objRsMES("ID") & "','" & objRsMES("VIN") & "', '" & objRsMES("TPMS") & "', '" & objRsMES("CARCODE") & "', '" & objRsMES("OPTIONCODE") & "','" & objRsMES("TIME") & "');"
		'                    LogWritter "����" & objRsMES("VIN")
		'                    i = i + 1
		'                Else
		'                    strSQL = "UPDATE vinlist SET ""id""='" & objRsMES("ID") & "',""vin""='" & objRsMES("VIN") & "', ""tpms""='" & objRsMES("TPMS") & "', ""carcode""='" & objRsMES("CARCODE") & "',optioncode='" & objRsMES("OPTIONCODE") & "', ""time""='" & objRsMES("TIME") & "' WHERE vin = '" & objRsMES("VIN") & "';"
		'                    LogWritter "����" & objRsMES("VIN")
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
		'    strSQL = "delete from vinlist where ""id"" < (select ""id"" from vinlist where ""id"" in (select ""id"" from vinlist order by ""id"" desc limit " & categoryLimit & ") order by ""id"" limit 1)"
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
		'    LogWritter "���������Զ�ͬ�����"
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
		'    'MsgBox "��������ͬ��ʧ�ܣ���鿴��־"
		'
		''    Dim objConn As Connection
		''    Dim objConnMES As Connection
		''    Dim objRs As Recordset
		''    Dim objTmpRs As Recordset
		''    Dim objRsMES As Recordset
		''    Dim strSQL As String
		''
		''    LogWritter "�����Զ�ͬ���Ų���������"
		''
		''    On Error GoTo ErrMES
		''    '�ȶ�ȡMES�ϵ�����
		''    Set objConnMES = New Connection
		''    Set objRsMES = New Recordset
		''    objConnMES.ConnectionTimeout = 3
		''    DoEvents
		''    objConnMES.Open MESCnnStr
		''    If objConnMES.state <> adStateOpen Then
		''        LogWritter "MES���ݿ�����ʧ�ܣ��޷�ͬ������"
		''        Set objConnMES = Nothing
		''        Exit Sub
		''    End If
		''    strSQL = "select * from mesprd.IF_VEHICLE_TPMS_INFO where tpms_process=0 order by pa_off_seq asc"
		''    objRsMES.Open strSQL, objConnMES, adOpenKeyset, adLockOptimistic
		''
		''    '�򿪱������ݿ�����
		''    Set objConn = New Connection
		''    Set objRs = New Recordset
		''    objConn.ConnectionTimeout = 2
		''    objConn.Open DBCnnStr
		''
		''    strSQL = "select * from vinlist"
		''    objRs.Open strSQL, objConn, adOpenStatic, adLockOptimistic
		''    DoEvents
		''    Set objTmpRs = New Recordset
		''    Do While Not objRsMES.EOF              '---���������
		''
		''        strSQL = "select * from vinlist where vin='" & objRsMES("vin") & "'"
		''        objTmpRs.Open strSQL, objConn, adOpenStatic, adLockOptimistic
		''        If objTmpRs.EOF Then
		''            objRs.AddNew
		''            objRs("vin") = objRsMES("vin")
		''            objRs!mtoc = objRsMES!mtoc
		''            objRs!pa_off_seq = objRsMES!pa_off_seq
		''            objRs!pa_off_time = objRsMES!pa_off_time
		''            objRs!createtime = Now()
		''            objRs.Update
		''        Else
		''            objTmpRs!mtoc = objRsMES!mtoc
		''            objTmpRs!pa_off_seq = objRsMES!pa_off_seq
		''            objTmpRs!pa_off_time = objRsMES!pa_off_time
		''            objTmpRs!createtime = Now()
		''            objTmpRs.Update
		''        End If
		''
		''        '����MESϵͳ�����ر�ʶ
		''        strSQL = "update mesprd.IF_VEHICLE_TPMS_INFO set tpms_process=1 where vin='" & objRsMES("vin") & "'"
		''        objConnMES.Execute strSQL
		''
		''        objRsMES.MoveNext
		''        objTmpRs.Close
		''    Loop
		''    objRs.Close
		''    objRsMES.Close
		''    objConn.Close
		''    objConnMES.Close
		''    Set objRs = Nothing
		''    Set objTmpRs = Nothing
		''    Set objRsMES = Nothing
		''    Set objConn = Nothing
		''    Set objConnMES = Nothing
		''
		''    LogWritter "�Ų���������ͬ�����"
		''
		''    nn = 0
		''    Exit Sub
		''ErrMES:
		''    LogWritter "MES���ݿ�����ʧ�ܣ��޷�ͬ������"
		''    Set objConnMES = Nothing
		''    nn = 0
		''    Exit Sub
		''Err:
		''    LogWritter "����ͬ�����̳���"
		''    nn = 0
	End Sub
	
	'��ʾϵͳ��Ϣ
	Public Sub AddMessage(ByRef txt As String, Optional ByRef isAlert As Boolean = False)
		
		If ListMsg.Items.Count > 20 Then
			ListMsg.Items.RemoveAt(0)
		End If
		
		Me.ListMsg.Items.Add("[" & Now & "]" & txt)
		If isAlert Then
			frmInfo.txtInfo.ForeColor = System.Drawing.ColorTranslator.FromOle(&HFF)
			frmInfo.txtInfo.Text = txt
		Else
			frmInfo.txtInfo.ForeColor = System.Drawing.ColorTranslator.FromOle(&H8000000D)
			frmInfo.txtInfo.Text = txt
		End If
		Me.ListMsg.SelectedIndex = Me.ListMsg.Items.Count - 1
		
		LogWritter(txt)
	End Sub
	'��ʼ�����������
	Private Sub initFrom(ByRef isInitVin As Boolean)
        Me.picLF.Image = ImageList.Images.Item(6) ' Me.ImageList.ListImages(6).Picture
        frmInfo.picLF.Image = frmInfo.ImageList.Images.Item(6) '  frmInfo.ImageList.ListImages(6).Picture
        Me.picLR.Image = ImageList.Images.Item(6) ' Me.ImageList.ListImages(6).Picture
        frmInfo.picLR.Image = frmInfo.ImageList.Images.Item(6) 'frmInfo.ImageList.ListImages(6).Picture
        Me.picRF.Image = ImageList.Images.Item(6) ' Me.ImageList.ListImages(6).Picture
        frmInfo.picRF.Image = frmInfo.ImageList.Images.Item(6) 'frmInfo.ImageList.ListImages(6).Picture
        Me.picRR.Image = ImageList.Images.Item(6) ' Me.ImageList.ListImages(6).Picture
        frmInfo.picRR.Image = frmInfo.ImageList.Images.Item(6) ' frmInfo.ImageList.ListImages(6).Picture
		
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
End Class