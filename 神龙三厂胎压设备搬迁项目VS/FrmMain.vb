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
	
	'运行状态
	Private gCancel As Boolean
	Dim nn As Short '扩展时钟计数
	Dim mm As Short '扩展时钟计数
	Dim HH As Short '扩展时钟计数
	Public TimerN As Short '排产数据同步周期
	Public TimerStatus As Short '状态诊断周期
	
	'状态参数
	Public DBPosition As String '数据库存储的盘符
	Public SpaceAvailable As Integer '可用空间告警限值
	
	
	Private firstFlag As Boolean
	Private secondFlag As Boolean
	
	Private WithEvents osensorCommand As CSensor
    Private WithEvents osensorLine As New CSensor
    Private car As New CCar
	Private TestCode As String
	Private VINCode As String
	Public MTOCCode As String
	Dim inputCode As Scripting.Dictionary '条码存储对象
	Public TestStateFlag As Short
	Dim barCodeFlag As Boolean
	Dim sensorFlag As Boolean
	Dim sensorControlFlag As Boolean
	Dim testEndDelyed As Boolean
	Dim isInTesting As Boolean '是否正在检测轮胎传感器 Add by ZCJ 2012-07-09
	
	'TestStateFlag标识用法：
	'-1=表示5在保存成功后的3秒种，前提是操作工没有扫描新条码，扫描后状态则变成0
	'0=vin已经输入可以进行准备DSG检测
	'1=右前轮测量成功
	'2=左前轮测量成功
	'3=右后轮测量成功
	'4=左后轮测量成功
	'5=保存成功
	'9998=未装配DSG
	'9999=等待测量
	
	Public BreakFlag As Boolean
	'BreakFlag = False  '系统解锁，锁定后系统将不工作
	'sensorFlag = True  '传动链开
	'barCodeFlag = True '相当于扫描强制录入条码
	
	'解析VT520检测数据
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
	
	'测试完成
	Private Sub Command14_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command14.Click
		'Call DSGTestEnd
		Dim mtoc As String
		Dim tmpCar As CCar
		tmpCar = New CCar
		'mtoc = tmpCar.GetMtocFromVinColl("11")
		tmpCar.VINCode = "11"
		tmpCar.Save()
	End Sub
	'扫描条码
	Private Sub Command17_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command17.Click
		BreakFlag = False
		TestCode = Text2.Text
		If VB.Left(TestCode, 17) = "R010000000000000C" Then '重置条码
			LogWritter("0扫描重置条码")
			resetList()
			Exit Sub
		End If
		If VB.Left(TestCode, 17) = "R020000000000000C" Then '强制输入条码
			LogWritter("扫描强制输入条码")
			barCodeFlag = True
			Exit Sub
		End If
		Debug.Print(TestCode)
		Call txtVIN_KeyPress(txtVIN, New System.Windows.Forms.KeyPressEventArgs(Chr(13)))
	End Sub
	'车辆进入工位
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		If inputCode.Count <> 0 Then
			'再次启动DSGStart
			'UPGRADE_WARNING: 未能解析对象 inputCode() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			Call Me.DSGTestStart(CStr(inputCode(inputCode.Keys(0))))
		End If
	End Sub
	
	'系统解锁
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		
		If BreakFlag Then
			osensorCommand_onChange(True) '系统解锁
		Else
			osensorCommand_onChange(False) '锁定系统
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
	
	'不检验排产队列，相当于扫描强制录入条码
	Private Sub Command5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command5.Click
		barCodeFlag = True
	End Sub
	'传动链解锁
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
	
	'右前轮(测试时用)
	Private Sub Command8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command8.Click
		
		'BreakFlag = False  '系统解锁
		'sensorFlag = True  '传动链开
		TestStateFlag = 0
		Dim tmpID As String
		Dim i As Integer
		If TestStateFlag = 0 Then
			'正常流程，进入工位
			'检测右前轮
			
			TestStateFlag = 1
			updateState("state", CStr(TestStateFlag))
			isInTesting = True 'Add by ZCJ 2012-07-09 开始检测右前轮
			AddMessage("正在检测右前轮……")
			LogWritter("开始第一次检测右前轮……")
			oRVT520.ResetResult()
			oRVT520.Start("Comm")
			
			For i = 0 To 6
				oRVT520.ReadResult()
				'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				tmpID = oRVT520.TireIDResult
				If tmpID <> "00000000" And Trim(tmpID) <> "" Then
					Exit For
				End If
			Next i
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Then '第二次测量
				LogWritter("开始第二次检测右前轮……")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Then '第三次测量
				LogWritter("开始第三次检测右前轮……")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Then '第四次测量
				LogWritter("开始第四次检测右前轮……")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Then '第五次测量
				LogWritter("开始第五次检测右前轮……")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" Then
						Exit For
					End If
				Next i
			End If
			
			isInTesting = False 'Add by ZCJ 2012-07-09 右前轮检测完成
			
			car.TireRFID = tmpID
			LogWritter("右前轮检测数据：" & oRVT520.Result)
			'UPGRADE_WARNING: 未能解析对象 oRVT520.TireMdlResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireRFMdl = oRVT520.TireMdlResult
			'UPGRADE_WARNING: 未能解析对象 oRVT520.TirePreResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireRFPre = oRVT520.TirePreResult
			'UPGRADE_WARNING: 未能解析对象 oRVT520.TireTempResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireRFTemp = oRVT520.TireTempResult
			'UPGRADE_WARNING: 未能解析对象 oRVT520.TireBatteryResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireRFBattery = oRVT520.TireBatteryResult
			'UPGRADE_WARNING: 未能解析对象 oRVT520.TireAcSpeedResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireRFAcSpeed = oRVT520.TireAcSpeedResult
			
			updateState("dsgrf", tmpID)
			updateState("mdlrf", (car.TireRFMdl))
			updateState("prerf", (car.TireRFPre))
			updateState("temprf", (car.TireRFTemp))
			updateState("batteryrf", (car.TireRFBattery))
			updateState("acspeedrf", (car.TireRFAcSpeed))
			
			'右前轮检测完毕
			setFrm(TestStateFlag)
		End If
	End Sub
	'左前轮(测试时用)
	Private Sub Command9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command9.Click
		
		TestStateFlag = 1
		Dim tmpID As String
		Dim i As Integer
		
		If TestStateFlag = 1 Then
			TestStateFlag = 2
			updateState("state", CStr(TestStateFlag))
			isInTesting = True 'Add by ZCJ 2012-07-09 开始检测左前轮
			AddMessage("正在检测左前轮……")
			LogWritter("开始第一次检测左前轮……")
			oLVT520.ResetResult()
			oLVT520.Start("Comm")
			
			For i = 0 To 6
				oLVT520.ReadResult()
				'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				tmpID = oLVT520.TireIDResult
				'If tmpID <> "00000000" And Trim(tmpID) <> "" Then
				If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
					Exit For
				End If
			Next i
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第二次测量
				LogWritter("开始第二次检测左前轮……")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第三次测量
				LogWritter("开始第三次检测左前轮……")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第四次测量
				LogWritter("开始第四次检测左前轮……")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第五次测量
				LogWritter("开始第五次检测左前轮……")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
			End If
			
			isInTesting = False 'Add by ZCJ 2012-07-09 左前轮检测完成
			
			car.TireLFID = tmpID
			LogWritter("左前轮检测数据：" & oLVT520.Result)
			'UPGRADE_WARNING: 未能解析对象 oLVT520.TireMdlResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireLFMdl = oLVT520.TireMdlResult
			'UPGRADE_WARNING: 未能解析对象 oLVT520.TirePreResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireLFPre = oLVT520.TirePreResult
			'UPGRADE_WARNING: 未能解析对象 oLVT520.TireTempResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireLFTemp = oLVT520.TireTempResult
			'UPGRADE_WARNING: 未能解析对象 oLVT520.TireBatteryResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireLFBattery = oLVT520.TireBatteryResult
			'UPGRADE_WARNING: 未能解析对象 oLVT520.TireAcSpeedResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireLFAcSpeed = oLVT520.TireAcSpeedResult
			
			updateState("dsglf", tmpID)
			updateState("mdllf", (car.TireLFMdl))
			updateState("prelf", (car.TireLFPre))
			updateState("templf", (car.TireLFTemp))
			updateState("batterylf", (car.TireLFBattery))
			updateState("acspeedlf", (car.TireLFAcSpeed))
			
			'左前轮检测完毕
			setFrm(TestStateFlag)
		End If
	End Sub
	'右后轮(测试时用)
	Private Sub Command10_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command10.Click
		
		TestStateFlag = 2
		Dim tmpID As String
		Dim i As Integer
		If TestStateFlag = 2 Then
			
			TestStateFlag = 3
			updateState("state", CStr(TestStateFlag))
			isInTesting = True 'Add by ZCJ 2012-07-09 开始检测右后轮
			AddMessage("正在检测右后轮……")
			LogWritter("开始第一次检测右后轮……")
			oRVT520.ResetResult()
			oRVT520.Start("Comm")
			
			For i = 0 To 6
				oRVT520.ReadResult()
				'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				tmpID = oRVT520.TireIDResult
				'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
				If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
					Exit For
				End If
			Next i
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '第二次测量
				LogWritter("开始第二次检测右后轮……")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '第三次测量
				LogWritter("开始第三次检测右后轮……")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '第四次测量
				LogWritter("开始第四次检测右后轮……")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '第五次测量
				LogWritter("开始第五次检测右后轮……")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
			End If
			
			isInTesting = False 'Add by ZCJ 2012-07-09 右后轮检测完成
			
			car.TireRRID = tmpID
			LogWritter("右后轮检测数据：" & oRVT520.Result)
			'UPGRADE_WARNING: 未能解析对象 oRVT520.TireMdlResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireRRMdl = oRVT520.TireMdlResult
			'UPGRADE_WARNING: 未能解析对象 oRVT520.TirePreResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireRRPre = oRVT520.TirePreResult
			'UPGRADE_WARNING: 未能解析对象 oRVT520.TireTempResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireRRTemp = oRVT520.TireTempResult
			'UPGRADE_WARNING: 未能解析对象 oRVT520.TireBatteryResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireRRBattery = oRVT520.TireBatteryResult
			'UPGRADE_WARNING: 未能解析对象 oRVT520.TireAcSpeedResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireRRAcSpeed = oRVT520.TireAcSpeedResult
			
			updateState("dsgrr", tmpID)
			updateState("mdlrr", (car.TireRRMdl))
			updateState("prerr", (car.TireRRPre))
			updateState("temprr", (car.TireRRTemp))
			updateState("batteryrr", (car.TireRRBattery))
			updateState("acspeedrr", (car.TireRRAcSpeed))
			
			TestStateFlag = 3 '右后轮检测完毕
			updateState("state", CStr(TestStateFlag))
			setFrm(TestStateFlag)
		End If
	End Sub
	'左后轮(测试时用)
	Private Sub Command11_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command11.Click
		
		TestStateFlag = 3
		Dim tmpID As String
		Dim i As Integer
		If TestStateFlag = 3 Then
			
			isInTesting = True 'Add by ZCJ 2012-07-09 开始检测左后轮
			AddMessage("正在检测左后轮……")
			LogWritter("开始第一次检测左后轮……")
			oLVT520.ResetResult()
			oLVT520.Start("Comm")
			
			For i = 0 To 6
				oLVT520.ReadResult()
				'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				tmpID = oLVT520.TireIDResult
				'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID Then
				If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
					Exit For
				End If
			Next i
			'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID '第二次测量
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第二次测量
				LogWritter("开始第二次检测左后轮……")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第三次测量
				LogWritter("开始第三次检测左后轮……")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第四次测量
				LogWritter("开始第四次检测左后轮……")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					End If
				Next i
			End If
			
			If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第五次测量
				LogWritter("开始第五次检测左后轮……")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					End If
				Next i
			End If
			
			isInTesting = False 'Add by ZCJ 2012-07-09 左后轮检测完成
			
			car.TireLRID = tmpID
			LogWritter("左后轮检测数据：" & oLVT520.Result)
			'UPGRADE_WARNING: 未能解析对象 oLVT520.TireMdlResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireLRMdl = oLVT520.TireMdlResult
			'UPGRADE_WARNING: 未能解析对象 oLVT520.TirePreResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireLRPre = oLVT520.TirePreResult
			'UPGRADE_WARNING: 未能解析对象 oLVT520.TireTempResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireLRTemp = oLVT520.TireTempResult
			'UPGRADE_WARNING: 未能解析对象 oLVT520.TireBatteryResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireLRBattery = oLVT520.TireBatteryResult
			'UPGRADE_WARNING: 未能解析对象 oLVT520.TireAcSpeedResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			car.TireLRAcSpeed = oLVT520.TireAcSpeedResult
			
			updateState("dsglr", tmpID)
			updateState("mdllr", (car.TireLRMdl))
			updateState("prelr", (car.TireLRPre))
			updateState("templr", (car.TireLRTemp))
			updateState("batterylr", (car.TireLRBattery))
			updateState("acspeedlr", (car.TireLRAcSpeed))
			
			TestStateFlag = 4 '后轮检测完毕
			updateState("state", CStr(TestStateFlag))
			setFrm(TestStateFlag)
			
			If TestStateFlag = 4 Then
				LogWritter("检测完成！")
				
				car.Save()
				If CDbl(car.GetTestState) = 15 Then
			
				Else
					flashBuzzerLamp(Lamp_RedLight_IOPort)
					AddMessage("检测结果存在重复值。", True)
					LogWritter("检测结果存在重复值。启动打印！")
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
	'** 函 数 名：Form_Load
	'** 输    入：
	'** 输    出：
	'** 功能描述：窗体加载时间响应
	'** 全局变量：
	'** 作    者：yangshuai
	'** 邮    箱：shuaigoplay@live.cn
	'** 日    期：2009-2-27
	'** 修 改 者：
	'** 日    期：
	'** 版    本：1.0
	'******************************************************************************
    Private Sub FrmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        '关闭线程安全
        Control.CheckForIllegalCrossThreadCalls() = False
        frmInfo.CheckForIllegalCrossThreadCalls() = False

        modPublic.Main()

        '配置条码扫描枪
        WirledCodeGun_PortNum = getConfigValue("T_CtrlParam", "BarCodeGun", "WirledCodeGun_PortNum")
        WirledCodeGun_Settings = getConfigValue("T_CtrlParam", "BarCodeGun", "WirledCodeGun_Settings")
        SerialPortOnline(SerialPortVIN, WirledCodeGun_PortNum, WirledCodeGun_Settings)
        WirlessCodeGun_PortNum = getConfigValue("T_CtrlParam", "BarCodeGun", "WirlessCodeGun_PortNum")
        WirlessCodeGun_Settings = getConfigValue("T_CtrlParam", "BarCodeGun", "WirlessCodeGun_Settings")
        SerialPortOnline(SerialPortBT, WirlessCodeGun_PortNum, WirlessCodeGun_Settings)

        'Add by ZCJ 2012-07-09 初始化测试状态
        isInTesting = False
        osen0Time = ""
        'Add by ZCJ 2012-07-09 初始化间隔时间
        tmpTime = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Second, -30, Now))

        barCodeFlag = False
        frmInfo.Show()
        initFrom(True)
        Dim testFlag As Boolean
        TestStateFlag = CShort(readState("state"))
        testFlag = CBool(readState("test")) '是否带DSG

        TimerN = CShort(getConfigValue("T_RunParam", "Timer", "TimerDataSync")) '排产队列同步周期
        TimerStatus = CShort(getConfigValue("T_RunParam", "Timer", "TimerStatus")) '系统状态栏检查周期
        DBPosition = getConfigValue("T_RunParam", "Status", "DBPosition") '数据库所在盘符
        SpaceAvailable = CInt(getConfigValue("T_RunParam", "Status", "SpaceAvailable")) '数据库所在硬盘可用空间下限

        '如果带DSG系统并且未检测完成，先加载已检测了的数据
        If testFlag And TestStateFlag <> 9999 Then
            car = getRunStateCar()
            Me.txtVin.Text = car.VINCode
        End If
        '如果已检测完成，则从数据库中加载VIN
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
        '条码对象集合
        inputCode = New Scripting.Dictionary

        'Modiy by ZCJ 2012-07-09 将解锁事件移动至此处
        osensorCommand = sensorCommand '解锁事件
        osensorCommand_onChange((sensorCommand.state))

        '传感器
        osensor0 = sensor0
        osensor1 = sensor1
        osensor2 = sensor2
        osensor3 = sensor3
        osensor4 = sensor4
        osensor5 = sensor5
        osensorLine = sensorLine '停线事件
        oRDCommand = rdResetCommandS '系统复位事件
        DelayTime(1000)

        'UPGRADE_WARNING: 未能解析对象 osensorLine.state 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
        sensorFlag = osensorLine.state
        sensorControlFlag = False '传动链状态,False表示没有锁
        testEndDelyed = False '此标示与TestStateFlag=-1联合使用

        initDictionary()
        iniListInput()
        flashLamp(Lamp_GreenLight_IOPort)
        Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)

    End Sub
	
	'机柜门上的复位按钮事件
	Private Sub oRDCommand_onChange(ByRef state As Boolean) Handles oRDCommand.onChange
		If state Then
			If BreakFlag Then Exit Sub
			LogWritter("系统被复位")
			resetList()
		End If
	End Sub
	'0号传感器
	Private Sub osensor0_onChange(ByRef state As Boolean) Handles osensor0.onChange
		SensorLogWritter("osensor0----" & CStr(state))
		If BreakFlag Then Exit Sub
		
		If osen0Time <> "" Then
			'UPGRADE_WARNING: DateDiff 行为可能不同。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"”
			If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(osen0Time), Now) <= 3 Then
				SensorLogWritter("响应时间未达到要求，osensor0事件未响应.")
				Exit Sub
			Else
				osen0Time = CStr(Now)
			End If
		Else
			osen0Time = CStr(Now)
		End If
		
		If state = True Then
			'车辆进入工位第一个标识
			firstFlag = True
			flashLamp(Lamp_YellowFlash_IOPort)
		ElseIf secondFlag And osensor4.state Then 
			If TestStateFlag < 10 And TestStateFlag <> 3 And TestStateFlag <> 0 And TestStateFlag <> -1 Then
				'If TestStateFlag < 10 And TestStateFlag <> 1 And TestStateFlag <> 3 And TestStateFlag <> 0 Then
				LogWritter("检测完成！")
				
				car.Save()
				If CDbl(car.GetTestState) = 15 Then
				
				Else
					flashBuzzerLamp(Lamp_RedLight_IOPort)
					AddMessage("检测结果存在重复值。", True)
					LogWritter("检测结果存在重复值。启动打印！")
					If car.printFlag And CDbl(car.LastCar.GetTestState) <> 15 Then
						Call printErrResult((car.LastCar))
					End If
					Call printErrResult(car)
				End If
				AddMessage("请注意队列是否正确", True)
				LogWritter("出现半台车现象！")
				DSGTestEnd()
				
				DelayTime(5000)
				oIOCard.OutputController(rdOutput, False)
				oIOCard.OutputController(Lamp_RedLight_IOPort, False)
				oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
			ElseIf TestStateFlag > 9990 And TestStateFlag <> 9995 And TestStateFlag <> 9999 And TestStateFlag <> -1 Then 
				'ElseIf TestStateFlag > 9990 And TestStateFlag <> 9998 And TestStateFlag <> 9997 And TestStateFlag <> 9995 And TestStateFlag <> 9999 Then
				AddMessage("请注意队列是否正确", True)
				LogWritter("出现半台车现象！")
				DSGTestEnd()
				
			End If
		End If
		
	End Sub
	'1号传感器
	Private Sub osensor1_onChange(ByRef state As Boolean) Handles osensor1.onChange
		SensorLogWritter("osensor1----" & CStr(state))
		If BreakFlag Then Exit Sub
		
		secondFlag = state
		If Not firstFlag Then
			'这是异常现象
		End If
		
		If firstFlag And secondFlag Then
			'车辆进如工位等待开始测试
			firstFlag = False
			'secondFlag = False
			If inputCode.Count <> 0 Then
				'再次启动DSGStart
				'UPGRADE_WARNING: 未能解析对象 inputCode() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				Call Me.DSGTestStart(CStr(inputCode(inputCode.Keys(0))))
				tmpTime = CStr(Now)
			End If
			
		End If
	End Sub
	'2号传感器
	Private Sub osensor2_onChange(ByRef state As Boolean) Handles osensor2.onChange
		SensorLogWritter("osensor2----" & CStr(state))
		
		On Error Resume Next
		If BreakFlag Then Exit Sub
		'当传动链停止并且响应停止的时候退出过程
		If Not sensorFlag And sensorControlFlag Then
			SensorLogWritter("传动链停止事件未响应")
			Exit Sub
		End If
		
		'Add by ZCJ 2012-08-09 当正在检测时，退出
		If isInTesting Then Exit Sub
		
		Dim tmpID As String
		Dim i As Integer
		DelayTime(800)
		If osensor1.state And osensor0.state And osensor2.state = state Then
			If TestStateFlag = 0 Then
				'正常流程，进入工位
				'检测右前轮
				
				'UPGRADE_WARNING: DateDiff 行为可能不同。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"”
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step1Time Then
					SensorLogWritter("响应时间未达到要求，osensor2事件未响应.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				
				
				TestStateFlag = 1
				updateState("state", CStr(TestStateFlag))
				
				isInTesting = True 'Add by ZCJ 2012-07-09 开始检测右前轮
				
				AddMessage("正在检测右前轮……")
				LogWritter("开始第一次检测右前轮……")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" Then
						Exit For
					End If
				Next i
				
				LogWritter("第一次检测数据：" & tmpID)
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Then '第二次测量
					LogWritter("开始第二次检测右前轮……")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" Then
							Exit For
						End If
					Next i
					
					LogWritter("第二次检测数据：" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Then '第三次测量
					LogWritter("开始第三次检测右前轮……")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" Then
							Exit For
						End If
					Next i
					
					LogWritter("第三次检测数据：" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Then '第四次测量
					LogWritter("开始第四次检测右前轮……")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" Then
							Exit For
						End If
					Next i
					
					LogWritter("第四次检测数据：" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Then '第五次测量
					LogWritter("开始第五次检测右前轮……")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" Then
							Exit For
						End If
					Next i
					
					LogWritter("第五次检测数据：" & tmpID)
					
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 右前轮检测完成
				
				car.TireRFID = tmpID
				LogWritter("右前轮检测数据：" & oRVT520.Result)
				'UPGRADE_WARNING: 未能解析对象 oRVT520.TireMdlResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireRFMdl = oRVT520.TireMdlResult
				'UPGRADE_WARNING: 未能解析对象 oRVT520.TirePreResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireRFPre = oRVT520.TirePreResult
				'UPGRADE_WARNING: 未能解析对象 oRVT520.TireTempResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireRFTemp = oRVT520.TireTempResult
				'UPGRADE_WARNING: 未能解析对象 oRVT520.TireBatteryResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireRFBattery = oRVT520.TireBatteryResult
				'UPGRADE_WARNING: 未能解析对象 oRVT520.TireAcSpeedResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireRFAcSpeed = oRVT520.TireAcSpeedResult
				
				updateState("dsgrf", tmpID)
				updateState("mdlrf", (car.TireRFMdl))
				updateState("prerf", (car.TireRFPre))
				updateState("temprf", (car.TireRFTemp))
				updateState("batteryrf", (car.TireRFBattery))
				updateState("acspeedrf", (car.TireRFAcSpeed))
				
				'前轮检测完毕
				setFrm(TestStateFlag)
				
			ElseIf TestStateFlag = 2 Then 
				'检测右后轮
				'UPGRADE_WARNING: DateDiff 行为可能不同。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"”
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step3Time Then
					SensorLogWritter("响应时间未达到要求，osensor5事件未响应.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				TestStateFlag = 3 '后轮检测完毕
				updateState("state", CStr(TestStateFlag))
				
				isInTesting = True 'Add by ZCJ 2012-07-09 开始检测右后轮
				
				AddMessage("正在检测右后轮……")
				LogWritter("开始第一次检测右后轮……")
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				
				For i = 0 To 6
					oRVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oRVT520.TireIDResult
					'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
				
				LogWritter("第一次检测数据：" & tmpID)
				
				'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then   '第二次测量
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '第二次测量
					LogWritter("开始第二次检测右后轮……")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
							Exit For
						End If
					Next i
					
					LogWritter("第二次检测数据：" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '第三次测量
					LogWritter("开始第三次检测右后轮……")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
							Exit For
						End If
					Next i
					
					LogWritter("第三次检测数据：" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '第四次测量
					LogWritter("开始第四次检测右后轮……")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
							Exit For
						End If
					Next i
					
					LogWritter("第四次检测数据：" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '第五次测量
					LogWritter("开始第五次检测右后轮……")
					oRVT520.ResetResult()
					oRVT520.Start("Comm")
					For i = 0 To 6
						oRVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
							Exit For
						End If
					Next i
					
					LogWritter("第五次检测数据：" & tmpID)
					
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 右后轮检测完成
				
				car.TireRRID = tmpID
				LogWritter("右后轮检测数据：" & oRVT520.Result)
				'UPGRADE_WARNING: 未能解析对象 oRVT520.TireMdlResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireRRMdl = oRVT520.TireMdlResult
				'UPGRADE_WARNING: 未能解析对象 oRVT520.TirePreResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireRRPre = oRVT520.TirePreResult
				'UPGRADE_WARNING: 未能解析对象 oRVT520.TireTempResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireRRTemp = oRVT520.TireTempResult
				'UPGRADE_WARNING: 未能解析对象 oRVT520.TireBatteryResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireRRBattery = oRVT520.TireBatteryResult
				'UPGRADE_WARNING: 未能解析对象 oRVT520.TireAcSpeedResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireRRAcSpeed = oRVT520.TireAcSpeedResult
				
				updateState("dsgrr", tmpID)
				updateState("mdlrr", (car.TireRRMdl))
				updateState("prerr", (car.TireRRPre))
				updateState("temprr", (car.TireRRTemp))
				updateState("batteryrr", (car.TireRRBattery))
				updateState("acspeedrr", (car.TireRRAcSpeed))
				
				setFrm(TestStateFlag)
			ElseIf TestStateFlag = 9998 Then 
				'不带DSG的车
				
				'UPGRADE_WARNING: DateDiff 行为可能不同。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"”
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step1Time Then
					SensorLogWritter("响应时间未达到要求，osensor2事件未响应.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				
				
				TestStateFlag = TestStateFlag - 1
				updateState("state", CStr(TestStateFlag))
				setFrm(TestStateFlag)
			ElseIf TestStateFlag = 9996 Then 
				'UPGRADE_WARNING: DateDiff 行为可能不同。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"”
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step3Time Then
					SensorLogWritter("响应时间未达到要求，osensor2事件未响应.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				
				
				TestStateFlag = TestStateFlag - 1
				updateState("state", CStr(TestStateFlag))
				setFrm(TestStateFlag)
			End If
			
			isInTesting = False 'Add by ZCJ 2012-07-09 初始化轮胎检测状态
		Else
			
		End If
	End Sub
	'传感器3
	Private Sub osensor3_onChange(ByRef state As Boolean) Handles osensor3.onChange
		SensorLogWritter("osensor3----" & CStr(state))
	End Sub
	'传感器4
	Private Sub osensor4_onChange(ByRef state As Boolean) Handles osensor4.onChange
		SensorLogWritter("osensor4----" & CStr(state))
	End Sub
	'传感器5
	Private Sub osensor5_onChange(ByRef state As Boolean) Handles osensor5.onChange
		SensorLogWritter("osensor5----" & CStr(state))
		
		On Error Resume Next
		If BreakFlag Then Exit Sub
		If Not sensorFlag And sensorControlFlag Then
			SensorLogWritter("传动链停止事件未响应")
			Exit Sub
		End If
		
		'Add by ZCJ 2012-08-09 当正在检测时，退出
		If isInTesting Then Exit Sub
		
		Dim tmpID As String
		Dim i As Integer
		DelayTime(800)
		If osensor3.state And osensor4.state And osensor5.state = state Then
			If TestStateFlag = 1 Then
				'正常流程，进入工位
				'检测左前轮
				
				'UPGRADE_WARNING: DateDiff 行为可能不同。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"”
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step2Time Then
					SensorLogWritter("响应时间未达到要求，osensor5事件未响应.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				
				TestStateFlag = 2
				updateState("state", CStr(TestStateFlag))
				
				isInTesting = True 'Add by ZCJ 2012-07-09 开始检测左前轮
				
				AddMessage("正在检测左前轮……")
				LogWritter("开始第一次检测左前轮……")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					'If tmpID <> "00000000" And Trim(tmpID) <> "" Then
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
				
				LogWritter("第一次检测数据：" & tmpID)
				
				'If tmpID = "00000000" Or Trim(tmpID) = "" Then '第二次测量
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第二次测量
					LogWritter("开始第二次检测左前轮……")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
							Exit For
						End If
					Next i
					
					LogWritter("第二次检测数据：" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第三次测量
					LogWritter("开始第三次检测左前轮……")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
							Exit For
						End If
					Next i
					
					LogWritter("第三次检测数据：" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第四次测量
					LogWritter("开始第四次检测左前轮……")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
							Exit For
						End If
					Next i
					
					LogWritter("第四次检测数据：" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第五次测量
					LogWritter("开始第五次检测左前轮……")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
							Exit For
						End If
					Next i
					
					LogWritter("第五次检测数据：" & tmpID)
					
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 左前轮检测完成
				
				car.TireLFID = tmpID
				LogWritter("左前轮检测数据：" & oLVT520.Result)
				'UPGRADE_WARNING: 未能解析对象 oLVT520.TireMdlResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireLFMdl = oLVT520.TireMdlResult
				'UPGRADE_WARNING: 未能解析对象 oLVT520.TirePreResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireLFPre = oLVT520.TirePreResult
				'UPGRADE_WARNING: 未能解析对象 oLVT520.TireTempResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireLFTemp = oLVT520.TireTempResult
				'UPGRADE_WARNING: 未能解析对象 oLVT520.TireBatteryResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireLFBattery = oLVT520.TireBatteryResult
				'UPGRADE_WARNING: 未能解析对象 oLVT520.TireAcSpeedResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireLFAcSpeed = oLVT520.TireAcSpeedResult
				
				updateState("dsglf", tmpID)
				updateState("mdllf", (car.TireLFMdl))
				updateState("prelf", (car.TireLFPre))
				updateState("templf", (car.TireLFTemp))
				updateState("batterylf", (car.TireLFBattery))
				updateState("acspeedlf", (car.TireLFAcSpeed))
				
				'前轮检测完毕
				setFrm(TestStateFlag)
			ElseIf TestStateFlag = 3 Then 
				'检测左后轮
				'UPGRADE_WARNING: DateDiff 行为可能不同。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"”
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step4Time Then
					SensorLogWritter("响应时间未达到要求，osensor5事件未响应.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				
				TestStateFlag = 4
				updateState("state", CStr(TestStateFlag))
				
				isInTesting = True 'Add by ZCJ 2012-07-09 开始检测左后轮
				
				AddMessage("正在检测左后轮……")
				LogWritter("开始第一次检测左后轮……")
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				
				For i = 0 To 6
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					'If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID Then
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					End If
				Next i
				
				LogWritter("第一次检测数据：" & tmpID)
				
				'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Then '第二次测量
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then
					LogWritter("开始第二次检测左后轮……")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
							Exit For
						End If
					Next i
					
					LogWritter("第二次检测数据：" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第三次测量
					LogWritter("开始第三次检测左后轮……")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
							Exit For
						End If
					Next i
					
					LogWritter("第三次检测数据：" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第四次测量
					LogWritter("开始第四次检测左后轮……")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
							Exit For
						End If
					Next i
					
					LogWritter("第四次检测数据：" & tmpID)
					
				End If
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第五次测量
					LogWritter("开始第五次检测左后轮……")
					oLVT520.ResetResult()
					oLVT520.Start("Comm")
					For i = 0 To 6
						oLVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
							Exit For
						End If
					Next i
					
					
					LogWritter("第五次检测数据：" & tmpID)
					
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 左后轮检测完成
				
				car.TireLRID = tmpID
				LogWritter("左后轮检测数据：" & oLVT520.Result)
				'UPGRADE_WARNING: 未能解析对象 oLVT520.TireMdlResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireLRMdl = oLVT520.TireMdlResult
				'UPGRADE_WARNING: 未能解析对象 oLVT520.TirePreResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireLRPre = oLVT520.TirePreResult
				'UPGRADE_WARNING: 未能解析对象 oLVT520.TireTempResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireLRTemp = oLVT520.TireTempResult
				'UPGRADE_WARNING: 未能解析对象 oLVT520.TireBatteryResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireLRBattery = oLVT520.TireBatteryResult
				'UPGRADE_WARNING: 未能解析对象 oLVT520.TireAcSpeedResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				car.TireLRAcSpeed = oLVT520.TireAcSpeedResult
				
				updateState("dsglr", tmpID)
				updateState("mdllr", (car.TireLRMdl))
				updateState("prelr", (car.TireLRPre))
				updateState("templr", (car.TireLRTemp))
				updateState("batterylr", (car.TireLRBattery))
				updateState("acspeedlr", (car.TireLRAcSpeed))
				
				'后轮检测完毕
				setFrm(TestStateFlag)
				DelayTime(200) '左后轮在界面显示0.2秒
			ElseIf TestStateFlag = 9997 Then 
				'不带DSG的车
				'UPGRADE_WARNING: DateDiff 行为可能不同。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"”
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step2Time Then
					SensorLogWritter("响应时间未达到要求，osensor5事件未响应.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				TestStateFlag = TestStateFlag - 1
				updateState("state", CStr(TestStateFlag))
				setFrm(TestStateFlag)
			ElseIf TestStateFlag = 9995 Then 
				'不带DSG的车
				'UPGRADE_WARNING: DateDiff 行为可能不同。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"”
				If DateDiff(Microsoft.VisualBasic.DateInterval.Second, CDate(tmpTime), Now) <= Step4Time Then
					SensorLogWritter("响应时间未达到要求，osensor5事件未响应.")
					Exit Sub
				Else
					tmpTime = CStr(Now)
				End If
				TestStateFlag = TestStateFlag - 1
				updateState("state", CStr(TestStateFlag))
				setFrm(TestStateFlag)
			End If
			
			If TestStateFlag = 4 Then
				LogWritter("检测完成！")
				
				car.Save()
				If CDbl(car.GetTestState) = 15 Then
					
					flashLamp(Lamp_YellowFlash_IOPort)
				
				Else
					flashBuzzerLamp(Lamp_RedLight_IOPort)
					AddMessage("检测结果存在重复值。", True)
					LogWritter("检测结果存在重复值。启动打印！")
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
	'解锁开关事件
	Private Sub osensorCommand_onChange(ByRef state As Boolean) Handles osensorCommand.onChange
		SensorLogWritter("osensorCommand----" & CStr(state))
		BreakFlag = Not state
		If state Then
		
			AddMessage("系统已解锁！", True)
			setFrm(TestStateFlag)
			LogWritter("系统已解锁！")
			Timer_PrintError.Interval = 1000
		Else
		
			AddMessage("系统已被锁定，请解锁！", True)
			LogWritter("系统已锁定！")
			'UPGRADE_WARNING: 计时器属性 Timer_PrintError.Interval 的值不能为 0。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="169ECF4A-1968-402D-B243-16603CC08604"”
            Timer_PrintError.Interval = 10000
		End If
	End Sub
	'停线事件
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
		If KeyAscii = 13 Then '回车触发
			tmp = txtInputVIN.Text
			
			If tmp = "" Then GoTo EventExitSub
			TestCode = tmp
			If VB.Left(TestCode, 17) = "R010000000000000C" Then
				LogWritter("1扫描重置条码")
				resetList()
				txtInputVIN.Text = "手工录入VIN，回车确认"
				GoTo EventExitSub
			End If
			If VB.Left(TestCode, 17) = "R020000000000000C" Then
				barCodeFlag = True
				txtInputVIN.Text = "手工录入VIN，回车确认"
				GoTo EventExitSub
			End If
			
			Debug.Print(TestCode)
			Call txtVIN_KeyPress(txtVIN, New System.Windows.Forms.KeyPressEventArgs(Chr(13)))
			txtInputVIN.Text = "手工录入VIN，回车确认"
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtInputVIN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtInputVIN.Leave
		txtInputVIN.Text = "手工录入VIN，回车确认"
	End Sub
	
	'处理扫描条码信息
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
			LogWritter("扫描条码：" & TestCode)
			LogWritter("************************************************************")
            If Len(TestCode) = 17 Then
                If isCheckAllQueue Then
                    If frmInfo.ListInput.Items.Count <> 0 And barCodeFlag = False Then
                        If frmInfo.labNext.Text <> VB.Right(tmpKey, 8) Then
                            AddMessage("请注意待扫车辆信息是否正确", True)
                            flashBuzzerLamp(Lamp_RedLight_IOPort)
                            LogWritter("待扫车辆不匹配,调用声音报警")
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
                LogWritter(tmpKey & "进入扫描队列")
                Me.List1.Items.Add(tmpKey)
                frmInfo.ListOutput.Items.Add(VB.Right(tmpKey, 8))
                setFrm(TestStateFlag)
                initDictionary()
                If inputCode.Count = 1 Then
                    'UPGRADE_WARNING: 未能解析对象 inputCode() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
                    txtVin.Text = CStr(Mid(inputCode(inputCode.Keys(0)), 2, 17))
                    frmInfo.labVin.Text = txtVin.Text
                    updateState("test", "False")
                    updateState("vin", (txtVin.Text))
                    TestStateFlag = -1
                    updateState("state", CStr(-1))
                    AddMessage("等待扫描车辆进入工位!")
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
                AddMessage("请注意扫描条码长度是否正确", True)
                flashBuzzerLamp(Lamp_RedLight_IOPort)
                LogWritter("条码长度不正确,调用声音报警!")
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
	'** 函 数 名：DSGTestStart
	'** 输    入：
	'** 输    出：
	'** 功能描述：DSG测试开始
	'** 全局变量：
	'** 作    者：yangshuai
	'** 邮    箱：shuaigoplay@live.cn
	'** 日    期：2009-2-27
	'** 修 改 者：
	'** 日    期：
	'** 版    本：1.0
	'******************************************************************************
	Public Sub DSGTestStart(ByRef vin As String)
		
		isInTesting = False 'Add by ZCJ 2012-07-09 初始化轮胎检测状态
		
		If TestStateFlag <> 9999 Then
			If TestStateFlag <> -1 Then
				'非正常情况启动检测
				Exit Sub
			End If
		End If
		
		txtVIN.Text = Mid(vin, 2, 17)
		frmInfo.labVin.Text = txtVIN.Text
		frmInfo.labNow.Text = VB.Right(txtVIN.Text, 8)
		LogWritter("============================================================")
		LogWritter(txtVIN.Text & "开始测试!")
		If hasDSG(vin) Then
			LogWritter("测试码通过,开始DSG检测!")
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
			LogWritter("车辆未装配DSG,直接通过!")
			updateState("test", "False")
			updateState("vin", (txtVIN.Text))
			
			TestStateFlag = 9998
			setFrm(TestStateFlag)
			updateState("state", CStr(TestStateFlag))
		End If
	End Sub
	'测试完成
	Public Sub DSGTestEnd()
		On Error GoTo END_ERR
		
		isInTesting = False 'Add by ZCJ 2012-07-09 初始化轮胎检测状态
		
		testEndDelyed = True
		TestStateFlag = 9999
		resetState()
		LogWritter(txtVIN.Text & "测试完成!")
		LogWritter("============================================================")
		
		txtVIN.Text = ""
		frmInfo.labNow.Text = ""
		frmInfo.labVin.Text = "胎压检测初始化系统"
		
		setFrm(TestStateFlag)
		'UPGRADE_WARNING: 未能解析对象 inputCode.Keys() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		LogWritter(CStr(inputCode.Keys(0)) & "退出扫描队列!")
		'UPGRADE_WARNING: 未能解析对象 inputCode.Keys() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		delColl(CStr(inputCode.Keys(0)))
		inputCode.Remove(inputCode.Keys(0))
		If inputCode.Count <> 0 Then
			'UPGRADE_WARNING: 未能解析对象 inputCode.Keys() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			updateState("vin", CStr(inputCode.Keys(0)))
			TestStateFlag = -1
			updateState("state", CStr(TestStateFlag))
			'UPGRADE_WARNING: 未能解析对象 inputCode() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
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
			'再次启动DSGStart
			'UPGRADE_WARNING: 未能解析对象 inputCode() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			Call Me.DSGTestStart(CStr(inputCode(inputCode.Keys(0))))
		Else
			LogWritter("扫描队列中车辆数为空")
		End If
		
		Exit Sub
END_ERR: 
		LogWritter(Err.Description)
	End Sub
	'在界面上显示检测到的传感器信息
	'UPGRADE_NOTE: text 已升级到 text_Renamed。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"”
	'UPGRADE_NOTE: str 已升级到 str_Renamed。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"”
	Public Sub showDSGInfo(ByRef str_Renamed As String, ByRef text_Renamed As String, ByRef model As String, ByRef pressure As String, ByRef temperature As String, ByRef battery As String, ByRef acSpeed As String, ByRef imgName As String)
		On Error Resume Next
		Dim Result As Boolean
		Dim mdlArr() As String
		
		CType(Me.Controls("txt" & str_Renamed), Object).Text = text_Renamed
		'UPGRADE_ISSUE: Control 方法 Controls.Picture 未升级。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"”
		CType(Me.Controls("pic" & str_Renamed), Object).Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\" & imgName)
		CType(frmInfo.Controls("txt" & str_Renamed), Object).Text = text_Renamed
		'UPGRADE_ISSUE: Control 方法 Controls.Picture 未升级。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"”
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
			CType(Me.Controls("lb" & str_Renamed & "Temp"), Object).Text = temperature & "℃"
			CType(frmInfo.Controls("lb" & str_Renamed & "Temp"), Object).Text = temperature & "℃"
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
	
	'显示当前的检测状态
	Public Sub setFrm(ByRef state As Short)
		If state = -1 Then
			AddMessage("等待扫描车辆进入工位!")
			initFrom(False)
		ElseIf state = 9999 Then 
			AddMessage("等待扫描VIN，开始测试!")
			initFrom(True)
		ElseIf state > 9000 And state < 9999 Then 
			AddMessage("车辆未装配DSG传感器，直接通过!")
			Select Case state
				Case 9997
					AddMessage("未装配DSG:右前轮已通过测试区域")
				Case 9996
					AddMessage("未装配DSG:左前轮已通过测试区域")
				Case 9995
					AddMessage("未装配DSG:右后轮已通过测试区域")
				Case 9994
					AddMessage("未装配DSG:左后轮已通过测试区域")
			End Select
			
		Else
			Select Case state
				
				Case 0
					AddMessage("条码扫描通过等待车辆进入工位,开始测试!")
					LogWritter("条码扫描通过等待车辆进入工位,开始测试!")
					initFrom(False)
				Case 1
					If car.TireRFID <> "00000000" And Trim(car.TireRFID) <> "" Then
						showDSGInfo("RF", (car.TireRFID), (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Green1.jpg")
						LogWritter("右前轮检测结果：" & car.TireRFID)
						AddMessage("右前轮检测完毕")
					Else
						'Modiy by ZCJ 2012=07-09 新增了正在检测轮胎的状态处理
						If isInTesting = True Then
							AddMessage("正在检测右前轮……")
						Else
							showDSGInfo("RF", "检测失败", (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Red1.jpg")
							LogWritter("右前轮检测失败")
							AddMessage("右前轮检测失败", True)
						End If
					End If
					
				Case 2
					If car.TireRFID <> "00000000" And Trim(car.TireRFID) <> "" Then
						showDSGInfo("RF", (car.TireRFID), (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Green1.jpg")
					Else
						showDSGInfo("RF", "检测失败", (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Red1.jpg")
					End If
					If car.TireLFID <> "00000000" And Trim(car.TireLFID) <> "" Then
						showDSGInfo("LF", (car.TireLFID), (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Green1.jpg")
						LogWritter("左前轮检测结果：" & car.TireLFID)
						AddMessage("左前轮检测完毕")
					Else
						'Modiy by ZCJ 2012=07-09 新增了正在检测轮胎的状态处理
						If isInTesting = True Then
							AddMessage("正在检测左前轮……")
						Else
							showDSGInfo("LF", "检测失败", (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Red1.jpg")
							LogWritter("左前轮检测失败")
							AddMessage("左前轮检测失败", True)
						End If
					End If
					
				Case 3
					If car.TireRFID <> "00000000" And Trim(car.TireRFID) <> "" Then
						showDSGInfo("RF", (car.TireRFID), (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Green1.jpg")
					Else
						showDSGInfo("RF", "检测失败", (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Red1.jpg")
					End If
					If car.TireLFID <> "00000000" And Trim(car.TireLFID) <> "" Then
						showDSGInfo("LF", (car.TireLFID), (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Green1.jpg")
					Else
						showDSGInfo("LF", "检测失败", (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Red1.jpg")
					End If
					If car.TireRRID <> "00000000" And Trim(car.TireRRID) <> "" Then
						showDSGInfo("RR", (car.TireRRID), (car.TireRRMdl), (car.TireRRPre), (car.TireRRTemp), (car.TireRRBattery), (car.TireRRAcSpeed), "Green1.jpg")
						LogWritter("右后轮检测结果：" & car.TireRRID)
						AddMessage("右后轮检测完毕")
					Else
						'Modiy by ZCJ 2012=07-09 新增了正在检测轮胎的状态处理
						If isInTesting = True Then
							AddMessage("正在检测右后轮……")
						Else
							showDSGInfo("RR", "检测失败", (car.TireRRMdl), (car.TireRRPre), (car.TireRRTemp), (car.TireRRBattery), (car.TireRRAcSpeed), "Red1.jpg")
							LogWritter("右后轮检测失败")
							AddMessage("右后轮检测失败", True)
						End If
					End If
					
				Case 4
					If car.TireRFID <> "00000000" And Trim(car.TireRFID) <> "" Then
						showDSGInfo("RF", (car.TireRFID), (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Green1.jpg")
					Else
						showDSGInfo("RF", "检测失败", (car.TireRFMdl), (car.TireRFPre), (car.TireRFTemp), (car.TireRFBattery), (car.TireRFAcSpeed), "Red1.jpg")
					End If
					If car.TireLFID <> "00000000" And Trim(car.TireLFID) <> "" Then
						showDSGInfo("LF", (car.TireLFID), (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Green1.jpg")
					Else
						showDSGInfo("LF", "检测失败", (car.TireLFMdl), (car.TireLFPre), (car.TireLFTemp), (car.TireLFBattery), (car.TireLFAcSpeed), "Red1.jpg")
					End If
					If car.TireRRID <> "00000000" And Trim(car.TireRRID) <> "" Then
						showDSGInfo("RR", (car.TireRRID), (car.TireRRMdl), (car.TireRRPre), (car.TireRRTemp), (car.TireRRBattery), (car.TireRRAcSpeed), "Green1.jpg")
					Else
						showDSGInfo("RR", "检测失败", (car.TireRRMdl), (car.TireRRPre), (car.TireRRTemp), (car.TireRRBattery), (car.TireRRAcSpeed), "Red1.jpg")
					End If
					If car.TireLRID <> "00000000" And Trim(car.TireLRID) <> "" Then
						showDSGInfo("LR", (car.TireLRID), (car.TireLRMdl), (car.TireLRPre), (car.TireLRTemp), (car.TireLRBattery), (car.TireLRAcSpeed), "Green1.jpg")
						LogWritter("左后轮检测结果：" & car.TireLRID)
						AddMessage("左后轮检测完毕")
					Else
						'Modiy by ZCJ 2012=07-09 新增了正在检测轮胎的状态处理
						If isInTesting = True Then
							AddMessage("正在检测左后轮……")
						Else
							showDSGInfo("LR", "检测失败", (car.TireLRMdl), (car.TireLRPre), (car.TireLRTemp), (car.TireLRBattery), (car.TireLRAcSpeed), "Red1.jpg")
							LogWritter("左后轮检测失败")
							AddMessage("左后轮检测失败", True)
						End If
					End If
					
			End Select
		End If
		
	End Sub

	'初始化扫描队列信息
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
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
	'初始化排产队列信息
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
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
	'系统重置，即复位
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
            LogWritter(txtVin.Text & "测试完成!")
            LogWritter("============================================================")
        End If
        txtVin.Text = ""

        setFrm(9999)
        updateState("state", CStr(TestStateFlag)) 'Add by ZCJ 20121207
        frmInfo.labNow.Text = ""

        iniListInput()

        Call closeAll()
        oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
        oIOCard.OutputController(Lamp_Buzzer_IOPort, False) '关闭蜂鸣
    End Sub
	'左击窗体移动
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
	'最小化窗体
	Private Sub Picture1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Picture1.Click
		Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
	End Sub
	'退出系统
	Private Sub picExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picExit.Click
		Dim msgR As Short
		msgR = MsgBox("是否退出胎压初始化系统？", MsgBoxStyle.YesNo, "系统提示")
		If msgR = 7 Then Exit Sub
		
		oIOCard.OutputController(Lamp_Buzzer_IOPort, False) '关闭蜂鸣
		Call closeAll()
        System.Environment.Exit(0)
	End Sub
	'功能描述：关闭灯柱的所有连线，任何灯柱操作都需要先调用该方法
	Public Sub closeAll()
		'oIOCard.OutputController Lamp_Buzzer_IOPort, False '关闭蜂鸣
		oIOCard.OutputController(Lamp_GreenLight_IOPort, False) '关闭绿色
		oIOCard.OutputController(Lamp_GreenFlash_IOPort, False) '关闭绿色闪烁
		oIOCard.OutputController(Lamp_YellowLight_IOPort, False) '关闭黄色
		oIOCard.OutputController(Lamp_YellowFlash_IOPort, False) '关闭黄色闪烁
		oIOCard.OutputController(Lamp_RedLight_IOPort, False) '关闭红色
		oIOCard.OutputController(Lamp_RedFlash_IOPort, False) '关闭红色闪烁
	End Sub
	'功能描述：历史记录查询
	Private Sub picCommandHis_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picCommandHis.Click
		frmHistory.Show()
	End Sub
	'功能描述：日志查询
	Private Sub picCommandLog_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picCommandLog.Click
		frmShowLog.Show()
	End Sub
	'功能描述：数据导出
	Private Sub picCommandOut_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picCommandOut.Click
		frmDateZone.Show()
	End Sub
	'功能描述：系统配置
	Private Sub picCommandConifg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picCommandConifg.Click
		frmPSW.Show()
	End Sub
	'功能描述：系统复位
	Private Sub picCommandReset_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles picCommandReset.Click
		If BreakFlag Then Exit Sub
		LogWritter("系统被复位")
		resetList()
		
		Call closeAll()
		oIOCard.OutputController(Lamp_Buzzer_IOPort, False) '关闭蜂鸣
		flashLamp(Lamp_GreenFlash_IOPort) '绿灯
	End Sub
	'功能描述：状态监控
	Private Sub Timer_StatusQuery_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer_StatusQuery.Tick
		On Error Resume Next
		'Exit Sub
		mm = mm + 1
		If mm < TimerStatus Then
			Exit Sub
		End If
		
		'清除ListMsg的行数
		Do While ListMsg.Items.Count > 20
			ListMsg.Items.RemoveAt(0)
		Loop 
		
		If TestStateFlag <= 5 Then
			mm = 0
			Exit Sub
		End If
		
		'查询硬盘空间状态
		HDDStateQuery()
		'查询控制器主机状态
		TSStateQuery()
		'查询网络状态
		NetStateQuery()
		
		mm = 0
	End Sub
	'功能描述：查询硬盘空间状态
	Private Sub HDDStateQuery()
		System.Windows.Forms.Application.DoEvents()
		If GetHDDState(DBPosition, SpaceAvailable) = 1 Then
			Me.Picture9.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
			frmInfo.Picture9.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
		Else
			Me.Picture9.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			frmInfo.Picture9.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			LogWritter(DBPosition & "硬盘可用空间不足" & CStr(VB6.Format(SpaceAvailable / 1024, "##.#")) & "G")
			AddMessage("硬盘可用空间不足", True)
			'flashBuzzerLamp Lamp_RedLight_IOPort
			'        DelayTime 2000
			'        oIOCard.OutputController Lamp_RedLight_IOPort, False
			'        oIOCard.OutputController rdOutput, False
			'        oIOCard.OutputController Lamp_GreenFlash_IOPort, True
		End If
		
	End Sub
	'功能描述：查询控制器主机状态
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
			LogWritter("右侧控制器故障")
			AddMessage("右侧控制器故障", True)
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
			LogWritter("左侧控制器故障")
			AddMessage("左侧控制器故障", True)
			'flashBuzzerLamp Lamp_RedLight_IOPort
			'        DelayTime 2000
			'        oIOCard.OutputController Lamp_RedLight_IOPort, False
			'        oIOCard.OutputController rdOutput, False
			'        oIOCard.OutputController Lamp_GreenFlash_IOPort, True
		End If
		
		Exit Sub
Error_Renamed: 
		LogWritter("查询控制器状态出错")
	End Sub
	'功能描述：查询网络状态
	Private Sub NetStateQuery()
		On Error GoTo Error_Renamed
		
		Dim objConn As ADODB.Connection
		Dim objConnMES As ADODB.Connection
		
		System.Windows.Forms.Application.DoEvents()
		
		'探查本地数据库服务状态
		objConn = New ADODB.Connection
		objConn.ConnectionTimeout = 2
		objConn.Open(DBCnnStr)
		If objConn.state = ADODB.ObjectStateEnum.adStateOpen Then
			Me.PicNet.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
			frmInfo.PicNet.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
			'            LogWritter "MES数据库连接正常"
			objConn.Close()
		Else
			Me.PicNet.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			frmInfo.PicNet.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			LogWritter("本地数据库连接异常")
			AddMessage("本地数据库连接异常", True)
	
		End If
		
		'UPGRADE_NOTE: 在对对象 objConn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objConn = Nothing
		
		If Ping(MES_IP) Then
			Me.PicInd.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
			frmInfo.PicInd.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
			'        LogWritter "网络正常"
			
			'探查MES服务状态
			On Error GoTo ErrMES
			
			objConnMES = New ADODB.Connection
			objConnMES.ConnectionTimeout = 3
			System.Windows.Forms.Application.DoEvents()
			objConnMES.Open(MESCnnStr)
			If objConnMES.state = ADODB.ObjectStateEnum.adStateOpen Then
				Me.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
				frmInfo.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Green.jpg")
				'            LogWritter "MES数据库连接正常"
				objConnMES.Close()
			Else
				Me.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
				frmInfo.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
				LogWritter("MES数据库连接异常")
				AddMessage("MES数据库连接异常", True)
	
			End If
			
		Else
			Me.PicInd.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			frmInfo.PicInd.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			LogWritter("网络异常")
			AddMessage("网络异常", True)
			
			Me.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			frmInfo.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
			LogWritter("MES数据库连接异常")
		End If
		
		'UPGRADE_NOTE: 在对对象 objConnMES 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objConnMES = Nothing
		
		Exit Sub
ErrMES: 
		Me.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
		frmInfo.Picture6.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\img\Red.jpg")
		LogWritter("MES数据库连接异常")
		'UPGRADE_NOTE: 在对对象 objConnMES 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objConnMES = Nothing
		Exit Sub
Error_Renamed: 
		LogWritter("网络与数据库状态探查过程出错，" & Err.Description)
	End Sub
	'从上游系统同步排产队列信息
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
		
		LogWritter("正在自动同步排产队列数据")
		
		On Error GoTo ErrMES
		'先读取MES上的数据
		objConnMES = New ADODB.Connection
		objRsMES = New ADODB.Recordset
		objConnMES.ConnectionTimeout = 3
		System.Windows.Forms.Application.DoEvents()
		objConnMES.Open(MESCnnStr)
		If objConnMES.state <> ADODB.ObjectStateEnum.adStateOpen Then
			LogWritter("MES数据库连接失败，无法同步数据")
			'UPGRADE_NOTE: 在对对象 objConnMES 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
			objConnMES = Nothing
			Exit Sub
		End If
		strSQL = "select * from mesprd.IF_VEHICLE_TPMS_INFO where tpms_process=0 order by pa_off_seq asc"
		objRsMES.Open(strSQL, objConnMES, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		
		'打开本地数据库连接
		objConn = New ADODB.Connection
		objRs = New ADODB.Recordset
		objConn.ConnectionTimeout = 2
		objConn.Open(DBCnnStr)
		
		strSQL = "select * from vinlist"
		objRs.Open(strSQL, objConn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
		System.Windows.Forms.Application.DoEvents()
		objTmpRs = New ADODB.Recordset
		Do While Not objRsMES.EOF '---添加新数据
			
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
			
			'更新MES系统的下载标识
			strSQL = "update mesprd.IF_VEHICLE_TPMS_INFO set tpms_process=1 where vin='" & objRsMES.Fields("vin").Value & "'"
			objConnMES.Execute(strSQL)
			
			objRsMES.MoveNext()
			objTmpRs.Close()
		Loop 
		objRs.Close()
		objRsMES.Close()
		objConn.Close()
		objConnMES.Close()
		'UPGRADE_NOTE: 在对对象 objRs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objRs = Nothing
		'UPGRADE_NOTE: 在对对象 objTmpRs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objTmpRs = Nothing
		'UPGRADE_NOTE: 在对对象 objRsMES 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objRsMES = Nothing
		'UPGRADE_NOTE: 在对对象 objConn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objConn = Nothing
		'UPGRADE_NOTE: 在对对象 objConnMES 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objConnMES = Nothing
		
		LogWritter("排产队列数据同步完毕")
		
		nn = 0
		Exit Sub
ErrMES: 
		LogWritter("MES数据库连接失败，无法同步数据")
		'UPGRADE_NOTE: 在对对象 objConnMES 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objConnMES = Nothing
		nn = 0
		Exit Sub
Err_Renamed: 
		LogWritter("数据同步过程出错")
		nn = 0
	End Sub
	
	'显示系统信息
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
	'初始化窗体的内容
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
			frmInfo.labVin.Text = "胎压检测初始化系统"
		End If
	End Sub

    '扫描枪串口接收事件
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
                    LogWritter("1扫描重置条码")
                    resetList()
                    Exit Sub
                Case "R020000000000000C"
                    barCodeFlag = True
                    Exit Sub
            End Select
         
            Debug.Print(TestCode)
            Call txtVIN_KeyPress(txtVin, New System.Windows.Forms.KeyPressEventArgs(Chr(13)))
        Catch ex As Exception
            log.LogWritter("扫描枪数据接收异常！")
            log.LogWritter(ex.Message)
        End Try
    End Sub
End Class