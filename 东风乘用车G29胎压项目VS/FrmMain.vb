Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FrmMain
	Inherits System.Windows.Forms.Form
	'******************************************************************************
	'** 文件名：FrmMain.frm
	'** 版  权：CopyRight (c)
	'** 创建人：yangshuai
	'** 邮  箱：shuaigoplay@live.cn
	'** 日  期：2009-2-27
	'** 修改人：
	'** 日  期：
	'** 描  述：DSG轮胎传感器检测系统主界面
	'** 版  本：1.0
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
	
	'运行状态
	Private gCancel As Boolean
	Dim nn As Short '扩展时钟计数
	Dim mm As Short '扩展时钟计数
	Dim HH As Short '扩展时钟计数
	Public TimerN As Short '排产数据同步周期
	Public TimerStatus As Short '状态诊断周期
	Public TimerResultUpLoad As Short '胎压检测结果上传周期
	
	Public MTCodelen As Short '整车配置码的长度
	
	
	'状态参数
	Public DBPosition As String '数据库存储的盘符
	Public SpaceAvailable As Integer '可用空间告警限值
	
	
	Private firstFlag As Boolean
	Private secondFlag As Boolean
	
	Private WithEvents osensorCommand As CSensor
	Private WithEvents osensorLine As CSensor
	Private car As CCar
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
	'上传状态
	Dim tmpsign As Boolean
	
	Public CarTypeCode As String 'Add by ZCJ 2014-05-08 当前工位车辆的车型
	
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
	
	'测试使用，0号传感器状态
	Dim sensorstate0 As Boolean
	'测试使用，1号传感器状态
	Dim sensorstate1 As Boolean
	'测试使用，2号传感器状态
	Dim sensorstate2 As Boolean
	'测试使用，3号传感器状态
	Dim sensorstate3 As Boolean
	'测试使用，4号传感器状态
	Dim sensorstate4 As Boolean
	'测试使用，5号传感器状态
	Dim sensorstate5 As Boolean
	
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
	
	Private Sub Command13_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command13.Click
		osensor0 = New CSensor
		osensor0.state = True
		Call osensor0_onChange((osensor0.state))
	End Sub
	
	'测试完成
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
	
	'车辆进入工位
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		If inputCode.Count <> 0 Then
			'再次启动DSGStart
			'UPGRADE_WARNING: 未能解析对象 inputCode() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			Call Me.DSGTestStart(CStr(inputCode(inputCode.Keys(0))))
		End If
	End Sub
	
	Private Sub Command20_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command20.Click
		osensor5 = New CSensor
		osensor5.state = True
		osensor1.state = False
		Call osensor5_onChange((osensor5.state))
	End Sub
	'-------------------------直接赋值测试------------------------------
	Public Function Rand_Number(ByRef Num As Object) As String 'num为产生位数
		Randomize()
		'UPGRADE_NOTE: str 已升级到 str_Renamed。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"”
		Dim i, N As Short
		Dim str_Renamed As String
		'UPGRADE_WARNING: 未能解析对象 Num 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		For i = 1 To Num
			N = Int(Rnd() * 2) + 1 '随机生成1或2赋值
			Select Case N '判断下一个数要生成的是数字还是小写字母
				Case 1 '生成数字
					str_Renamed = str_Renamed & Chr(Int(Rnd() * 10) + 48) '在0-9范围里的随机挑一个数字
				Case 2 '生成小写字母
					str_Renamed = str_Renamed & Chr(Int(Rnd() * 26) + 97) '在a-z范围里的随机挑一个字母
			End Select
		Next 
		Rand_Number = str_Renamed
	End Function
	Private Sub Command21_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command21.Click
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
			
			'            For i = 0 To RVT520_icount
			'                oRVT520.ReadResult
			'                tmpID = oRVT520.TireIDResult
			'                If tmpID <> "00000000" And Trim(tmpID) <> "" Then
			'                    Exit For
			'                End If
			'            Next i
			'
			'            LogWritter "第一次检测数据：" & tmpID
			'
			'            If tmpID = "00000000" Or Trim(tmpID) = "" Then '第二次测量
			'                LogWritter "开始第二次检测右前轮……"
			'                oLVT520.ResetResult
			'                oLVT520.Start "Comm"    '左边天线面板也工作，发射干扰信号
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
			'                LogWritter "第二次检测数据：" & tmpID
			'
			'            End If
			
			isInTesting = False 'Add by ZCJ 2012-07-09 右前轮检测完成
			
			tmpID = Rand_Number(8)
			LogWritter("右前轮检测数据：" & tmpID)
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
			
			'右前轮检测完毕
			setFrm(TestStateFlag)
		End If
	End Sub
	
	Private Sub Command22_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command22.Click
		
		'    If DateDiff("s", tmpTime, Now) <= Step2Time Then
		'        MsgBox ("响应时间未达到要求!")
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
			isInTesting = True 'Add by ZCJ 2012-07-09 开始检测左前轮
			AddMessage("正在检测左前轮……")
			LogWritter("开始第一次检测左前轮……")
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
			'            LogWritter "第一次检测数据：" & tmpID
			'
			'            'If tmpID = "00000000" Or Trim(tmpID) = "" Then '第二次测量
			'            If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第二次测量
			'                LogWritter "开始第二次检测左前轮……"
			'                oRVT520.ResetResult
			'                oRVT520.Start "Comm"    '右边边天线面板也工作，发射干扰信号
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
			'                LogWritter "第二次检测数据：" & tmpID
			'
			'            End If
			
			
			isInTesting = False 'Add by ZCJ 2012-07-09 左前轮检测完成
			
			
			tmpID = Rand_Number(8)
			LogWritter("左前轮检测数据：" & tmpID)
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
			
			'左前轮检测完毕
			setFrm(TestStateFlag)
		End If
	End Sub
	
	Private Sub Command23_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command23.Click
		'    If DateDiff("s", tmpTime, Now) <= Step3Time Then
		'        MsgBox ("响应时间未达到要求!")
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
			isInTesting = True 'Add by ZCJ 2012-07-09 开始检测右后轮
			AddMessage("正在检测右后轮……")
			LogWritter("开始第一次检测右后轮……")
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
			'            LogWritter "第一次检测数据：" & tmpID
			'
			'            'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then   '第二次测量
			'            If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '第二次测量
			'                LogWritter "开始第二次检测右后轮……"
			'                oLVT520.ResetResult
			'                oLVT520.Start "Comm"    '左边天线面板也工作，发射干扰信号
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
			'                LogWritter "第二次检测数据：" & tmpID
			'
			'            End If
			
			
			isInTesting = False 'Add by ZCJ 2012-07-09 右后轮检测完成
			
			tmpID = Rand_Number(8)
			car.TireRRID = tmpID
			LogWritter("右后轮检测数据：" & tmpID)
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
			
			TestStateFlag = 3 '右后轮检测完毕
			updateState("state", CStr(TestStateFlag))
			setFrm(TestStateFlag)
		End If
	End Sub
	
	Private Sub Command24_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command24.Click
		
		'    If DateDiff("s", tmpTime, Now) <= Step4Time Then
		'        MsgBox ("响应时间未达到要求!")
		'        Exit Sub
		'    Else
		'        tmpTime = Now
		'    End If
		
		
		TestStateFlag = 3
		Dim tmpID As String
		Dim i As Integer
		If TestStateFlag = 3 Then
			
			isInTesting = True 'Add by ZCJ 2012-07-09 开始检测左后轮
			AddMessage("正在检测左后轮……")
			LogWritter("开始第一次检测左后轮……")
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
			'            LogWritter "第一次检测数据：" & tmpID
			'
			'            'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Then '第二次测量
			'            If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then
			'                LogWritter "开始第二次检测左后轮……"
			'                oRVT520.ResetResult
			'                oRVT520.Start "Comm"    '右边边天线面板也工作，发射干扰信号
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
			'                LogWritter "第二次检测数据：" & tmpID
			'
			'            End If
			
			
			isInTesting = False 'Add by ZCJ 2012-07-09 左后轮检测完成
			
			
			tmpID = Rand_Number(8)
			car.TireLRID = tmpID
			LogWritter("左后轮检测数据：" & tmpID)
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
			
			TestStateFlag = 4 '后轮检测完毕
			setFrm(TestStateFlag)
			updateState("state", CStr(TestStateFlag))
			
			If TestStateFlag = 4 Then
				LogWritter("检测完成！")
				tmpsign = car.Save(SpaceAvailable)
				'            If tmpsign = False And PrintModel <> 0 Then
				'                Call printErrResult(car) '上传mes失败打印
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
						Call printErrResult(car) '全部打印
					End If
				Else
					flashBuzzerLamp(Lamp_RedLight_IOPort)
					AddMessage("检测结果失败。", True)
					LogWritter("检测结果失败！")
					'                If car.printFlag And car.LastCar.GetTestState <> 15 Then
					'                    If PrintModel = "2" Or PrintModel = "1" Then
					'                       Call printErrResult(car.LastCar)
					'                    End If
					'                End If
					If PrintModel = "2" Then '仅模式选择全部打印和仅失败打印模式两种模式时打印
						Call printErrResult(car)
					End If
				End If
				DSGTestEnd()
			ElseIf TestStateFlag = 9994 Then 
				DSGTestEnd()
			End If
			
		End If
	End Sub
	
	'系统解锁
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		
		If BreakFlag Then
			osensorCommand_onChange(True) '系统解锁
		Else
			osensorCommand_onChange(False) '锁定系统
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
		DelayTime(2000)
		Do While A < 10000
			A = A + 1
		Loop 
	End Sub
	'-------------------------直接赋值测试------------------------------
	'Public Function Rand_Number(Num) As String 'num为产生位数
	'    Randomize
	'    Dim i As Integer, n As Integer, str As String
	'    For i = 1 To Num
	'        n = Int(Rnd * 2) + 1 '随机生成1或2赋值
	'        Select Case n '判断下一个数要生成的是数字还是小写字母
	'        Case 1 '生成数字
	'            str = str & Chr(Int(Rnd * 10) + 48) '在0-9范围里的随机挑一个数字
	'        Case 2 '生成小写字母
	'            str = str & Chr(Int(Rnd * 26) + 97) '在a-z范围里的随机挑一个字母
	'        End Select
	'    Next
	'    Rand_Number = str
	'End Function
	''右前轮(测试时用)
	'Private Sub Command8_Click()
	'
	''    If DateDiff("s", tmpTime, Now) <= Step1Time Then
	''        MsgBox ("响应时间未达到要求!")
	''        Exit Sub
	''    Else
	''        tmpTime = Now
	''    End If
	'
	'    'BreakFlag = False  '系统解锁
	'    'sensorFlag = True  '传动链开
	'    TestStateFlag = 0
	'    Dim tmpID As String
	'    Dim i As Long
	'    If TestStateFlag = 0 Then
	'        '正常流程，进入工位
	'        '检测右前轮
	'
	'        TestStateFlag = 1
	'        updateState "state", CStr(TestStateFlag)
	'        isInTesting = True 'Add by ZCJ 2012-07-09 开始检测右前轮
	'        AddMessage "正在检测右前轮……"
	'        LogWritter "开始第一次检测右前轮……"
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
	''        If tmpID = "00000000" Or Trim(tmpID) = "" Then '右边没有测到重测一次
	''            LogWritter "开始第二次检测右前轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '第二次测量
	'            LogWritter "开始第二次检测右前轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '第三次测量
	'            LogWritter "开始第三次检测右前轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '第四次测量
	'            LogWritter "开始第四次检测右前轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '第五次测量
	'            LogWritter "开始第五次检测右前轮……"
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
	'        isInTesting = False 'Add by ZCJ 2012-07-09 右前轮检测完成
	'
	'        car.TireRFID = Rand_Number(8)
	'        LogWritter "右前轮检测数据：" & oRVT520.Result
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
	'        '右前轮检测完毕
	'        setFrm TestStateFlag
	'    End If
	'End Sub
	''左前轮(测试时用)
	'Private Sub Command9_Click()
	'
	''    If DateDiff("s", tmpTime, Now) <= Step2Time Then
	''        MsgBox ("响应时间未达到要求!")
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
	'        isInTesting = True 'Add by ZCJ 2012-07-09 开始检测左前轮
	'        AddMessage "正在检测左前轮……"
	'        LogWritter "开始第一次检测左前轮……"
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
	''        If tmpID = "00000000" Or Trim(tmpID) = "" Then '左边没有测到重测一次
	''            LogWritter "开始第二次检测左前轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第二次测量
	'            LogWritter "开始第二次检测左前轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第三次测量
	'            LogWritter "开始第三次检测左前轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第四次测量
	'            LogWritter "开始第四次检测左前轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第五次测量
	'            LogWritter "开始第五次检测左前轮……"
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
	'        isInTesting = False 'Add by ZCJ 2012-07-09 左前轮检测完成
	'
	'        car.TireLFID = Rand_Number(8)
	'        LogWritter "左前轮检测数据：" & oLVT520.Result
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
	'        '左前轮检测完毕
	'        setFrm TestStateFlag
	'    End If
	'End Sub
	''右后轮(测试时用)
	'Private Sub Command10_Click()
	'
	''    If DateDiff("s", tmpTime, Now) <= Step3Time Then
	''        MsgBox ("响应时间未达到要求!")
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
	'        isInTesting = True 'Add by ZCJ 2012-07-09 开始检测右后轮
	'        AddMessage "正在检测右后轮……"
	'        LogWritter "开始第一次检测右后轮……"
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
	''        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then   '右边没有测到重测一次
	''            LogWritter "开始第二次检测右后轮……"
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
	''        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then   '右边没有测到重测一次
	''            LogWritter "开始第三次检测右后轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '第二次测量
	'            LogWritter "开始第二次检测右后轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '第三次测量
	'            LogWritter "开始第三次检测右后轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '第四次测量
	'            LogWritter "开始第四次检测右后轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '第五次测量
	'            LogWritter "开始第五次检测右后轮……"
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
	'        isInTesting = False 'Add by ZCJ 2012-07-09 右后轮检测完成
	'
	'        car.TireRRID = Rand_Number(8)
	'        LogWritter "右后轮检测数据：" & oRVT520.Result
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
	'        TestStateFlag = 3 '右后轮检测完毕
	'        updateState "state", CStr(TestStateFlag)
	'        setFrm TestStateFlag
	'    End If
	'End Sub
	''左后轮(测试时用)
	'Private Sub Command11_Click()
	'
	''    If DateDiff("s", tmpTime, Now) <= Step4Time Then
	''        MsgBox ("响应时间未达到要求!")
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
	'        isInTesting = True 'Add by ZCJ 2012-07-09 开始检测左后轮
	'        AddMessage "正在检测左后轮……"
	'        LogWritter "开始第一次检测左后轮……"
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
	''        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Then '左边没有测到重测一次
	''            LogWritter "开始第二次检测左后轮……"
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
	''        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Then '左边没有测到重测一次
	''            LogWritter "开始第三次检测左后轮……"
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
	'        'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID '第二次测量
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第二次测量
	'            LogWritter "开始第二次检测左后轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第三次测量
	'            LogWritter "开始第三次检测左后轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第四次测量
	'            LogWritter "开始第四次检测左后轮……"
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
	'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第五次测量
	'            LogWritter "开始第五次检测左后轮……"
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
	'        isInTesting = False 'Add by ZCJ 2012-07-09 左后轮检测完成
	'
	'        car.TireLRID = Rand_Number(8)
	'        LogWritter "左后轮检测数据：" & oLVT520.Result
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
	'        TestStateFlag = 4 '后轮检测完毕
	'        updateState "state", CStr(TestStateFlag)
	'        setFrm TestStateFlag
	'        If TestStateFlag = 4 Then
	'            LogWritter "检测完成！"
	'
	'            car.Save
	'            'Call printErrResult(car)
	'            If car.GetTestState = 15 Then
	''超过指定范围则报警
	''                car.CheckResultIsOverStandard
	''                If car.IsOverStandard Then
	''                     Call printErrResult(car)
	''                Else
	''                    flashLamp Lamp_YellowFlash_IOPort
	''                End If
	'            Else
	'                flashBuzzerLamp Lamp_RedLight_IOPort
	'                AddMessage "检测结果存在重复值。", True
	'                LogWritter "检测结果存在重复值。启动打印！"
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
	
	
	'--------------------------从设备读值测试----------------------------
	'右前轮(测试时用)
	Private Sub Command8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command8.Click
		
		'    If DateDiff("s", tmpTime, Now) <= Step1Time Then
		'        MsgBox ("响应时间未达到要求!")
		'        Exit Sub
		'    Else
		'        tmpTime = Now
		'    End If
		
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
			
			For i = 0 To RVT520_icount
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
				oLVT520.ResetResult()
				oLVT520.Start("Comm") '左边天线面板也工作，发射干扰信号
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To RVT520_icount
					oRVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" Then
						Exit For
					End If
				Next i
				
				LogWritter("第二次检测数据：" & tmpID)
				
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '第二次测量
			'            LogWritter "开始第二次检测右前轮……"
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
			
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '第三次测量
			'            LogWritter "开始第三次检测右前轮……"
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '第四次测量
			'            LogWritter "开始第四次检测右前轮……"
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '第五次测量
			'            LogWritter "开始第五次检测右前轮……"
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
		
		'    If DateDiff("s", tmpTime, Now) <= Step2Time Then
		'        MsgBox ("响应时间未达到要求!")
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
			isInTesting = True 'Add by ZCJ 2012-07-09 开始检测左前轮
			AddMessage("正在检测左前轮……")
			LogWritter("开始第一次检测左前轮……")
			oLVT520.ResetResult()
			oLVT520.Start("Comm")
			For i = 0 To LVT520_icount
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
				oRVT520.ResetResult()
				oRVT520.Start("Comm") '右边边天线面板也工作，发射干扰信号
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To LVT520_icount
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
				
				LogWritter("第二次检测数据：" & tmpID)
				
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Then '左边没有测到重测一次
			'            LogWritter "开始第二次检测左前轮……"
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第二次测量
			'            LogWritter "开始第二次检测左前轮……"
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
			
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第三次测量
			'            LogWritter "开始第三次检测左前轮……"
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第四次测量
			'            LogWritter "开始第四次检测左前轮……"
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第五次测量
			'            LogWritter "开始第五次检测左前轮……"
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
		
		'    If DateDiff("s", tmpTime, Now) <= Step3Time Then
		'        MsgBox ("响应时间未达到要求!")
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
			isInTesting = True 'Add by ZCJ 2012-07-09 开始检测右后轮
			AddMessage("正在检测右后轮……")
			LogWritter("开始第一次检测右后轮……")
			oRVT520.ResetResult()
			oRVT520.Start("Comm")
			
			For i = 0 To RVT520_icount
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
				oLVT520.ResetResult()
				oLVT520.Start("Comm") '左边天线面板也工作，发射干扰信号
				oRVT520.ResetResult()
				oRVT520.Start("Comm")
				For i = 0 To RVT520_icount
					oRVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oRVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
				
				LogWritter("第二次检测数据：" & tmpID)
				
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then   '右边没有测到重测一次
			'            LogWritter "开始第二次检测右后轮……"
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then   '右边没有测到重测一次
			'            LogWritter "开始第三次检测右后轮……"
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '第二次测量
			'            LogWritter "开始第二次检测右后轮……"
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
			
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '第三次测量
			'            LogWritter "开始第三次检测右后轮……"
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '第四次测量
			'            LogWritter "开始第四次检测右后轮……"
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then   '第五次测量
			'            LogWritter "开始第五次检测右后轮……"
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
		
		'    If DateDiff("s", tmpTime, Now) <= Step4Time Then
		'        MsgBox ("响应时间未达到要求!")
		'        Exit Sub
		'    Else
		'        tmpTime = Now
		'    End If
		
		
		TestStateFlag = 3
		Dim tmpID As String
		Dim i As Integer
		If TestStateFlag = 3 Then
			
			isInTesting = True 'Add by ZCJ 2012-07-09 开始检测左后轮
			AddMessage("正在检测左后轮……")
			LogWritter("开始第一次检测左后轮……")
			oLVT520.ResetResult()
			oLVT520.Start("Comm")
			
			For i = 0 To LVT520_icount
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
				oRVT520.ResetResult()
				oRVT520.Start("Comm") '右边边天线面板也工作，发射干扰信号
				oLVT520.ResetResult()
				oLVT520.Start("Comm")
				For i = 0 To LVT520_icount
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					End If
				Next i
				
				LogWritter("第二次检测数据：" & tmpID)
				
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Then '左边没有测到重测一次
			'            LogWritter "开始第二次检测左后轮……"
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Then '左边没有测到重测一次
			'            LogWritter "开始第三次检测左后轮……"
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
			'        'If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID '第二次测量
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第二次测量
			'            LogWritter "开始第二次检测左后轮……"
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
			
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第三次测量
			'            LogWritter "开始第三次检测左后轮……"
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第四次测量
			'            LogWritter "开始第四次检测左后轮……"
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
			'        If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then '第五次测量
			'            LogWritter "开始第五次检测左后轮……"
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
			setFrm(TestStateFlag)
			updateState("state", CStr(TestStateFlag))
			
			If TestStateFlag = 4 Then
				LogWritter("检测完成！")
				
				tmpsign = car.Save(SpaceAvailable)
				'            If tmpsign = False Then
				'                Call printErrResult(car) '上传失败打印
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
					'                   Call printErrResult(car) '全部打印
					'                End If
				Else
					flashBuzzerLamp(Lamp_RedLight_IOPort)
					AddMessage("检测结果失败。", True)
					LogWritter("检测结果失败！")
					'LogWritter "检测结果失败。启动打印！"
					'                If car.printFlag And car.LastCar.GetTestState <> 15 Then
					'                    If PrintModel = "2" Or PrintModel = "1" Then
					'                       Call printErrResult(car.LastCar)
					'                    End If
					'                End If
					'                If PrintModel = "2" Or PrintModel = "1" Then '仅模式选择全部打印和仅失败打印模式两种模式时打印
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
        modPublic.Main()
        'Add by ZCJ 2012-07-09 初始化测试状态
        isInTesting = False
        osen0Time = ""
        'Add by ZCJ 2012-07-09 初始化间隔时间
        tmpTime = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Second, -30, Now))

        car = New CCar

        barCodeFlag = False
        'frmInfo.Show
        initFrom(True)
        Dim testFlag As Boolean
        TestStateFlag = CShort(readState("state"))
        testFlag = CBool(readState("test")) '是否带DSG

        'TimerN = getConfigValue("T_RunParam", "Timer", "TimerDataSync")     '排产队列同步周期
        TimerStatus = CShort(getConfigValue("T_RunParam", "Timer", "TimerStatus")) '系统状态栏检查周期
        DBPosition = getConfigValue("T_RunParam", "Status", "DBPosition") '数据库所在盘符
        SpaceAvailable = CInt(getConfigValue("T_RunParam", "Status", "SpaceAvailable")) '数据库所在硬盘可用空间下限

        '胎压检测结果上传周期
        TimerResultUpLoad = CShort(getConfigValue("T_RunParam", "Timer", "TimerResultUpLoad"))
        '如果带DSG系统并且未检测完成，先加载已检测了的数据
        If testFlag And TestStateFlag <> 9999 Then
            car = getRunStateCar()
            Me.txtVin.Text = car.VINCode
        End If
        '如果已检测完成，则从数据库中加载VIN
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

        'MTCodelen = getConfigValue("T_CtrlParam", "Len", "MTCodeLen") '物料码的长度
        Step1Time = CShort(getConfigValue("T_CtrlParam", "StepTime", "Step1Time")) '
        Step2Time = CShort(getConfigValue("T_CtrlParam", "StepTime", "Step2Time"))
        Step3Time = CShort(getConfigValue("T_CtrlParam", "StepTime", "Step3Time"))
        Step4Time = CShort(getConfigValue("T_CtrlParam", "StepTime", "Step4Time"))

        updateState("state", CStr(TestStateFlag))
        '条码对象集合
        inputCode = New Scripting.Dictionary

        'Modiy by ZCJ 2012-07-09 将解锁事件移动至此处
        osensorCommand = sensorCommand '解锁事件
        osensorCommand_onChange(True)

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

        initDictionary() '初始化扫描队列
        'iniListInput  '初始化排产队列 不要
        flashLamp(Lamp_GreenLight_IOPort)
        Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
        Call setWirledComScan() '初始化扫描枪的串口
        Call setWirlessComScan()
    End Sub
	
	'关闭程序：先关闭灯柱，再释放窗体
	Private Sub FrmMain_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Call closeAll()
		
	End Sub
	
	
	
	
	'无线条码枪通信
	Private Sub MSCommBT_OnComm(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MSCommBT.OnComm
		On Error GoTo MSCommBT_OnComm_Err
		If BreakFlag Then Exit Sub
		DelayTime(100)
		Dim tmp As Object
		Dim strin As String
		
		'UPGRADE_WARNING: 未能解析对象 MSCommBT.Input 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		'UPGRADE_WARNING: 未能解析对象 tmp 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		tmp = MSCommBT.Input
		'UPGRADE_WARNING: 未能解析对象 tmp 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		If tmp = "" Then Exit Sub
		'UPGRADE_WARNING: 未能解析对象 tmp 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		strin = strin & tmp
		TestCode = strin
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
		'UPGRADE_WARNING: 未能解析对象 tmp 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		tmp = ""
		Call txtVIN_KeyPress(txtVIN, New System.Windows.Forms.KeyPressEventArgs(Chr(13)))
		Exit Sub
MSCommBT_OnComm_Err: 
		LogWritter("蓝牙扫描枪通信错误：" & Err.Description)
	End Sub
	'机柜门上的复位按钮事件
	Private Sub oRDCommand_onChange(ByRef state As Boolean) Handles oRDCommand.onChange
		Call picCommandReset_Click(picCommandReset, New System.EventArgs())
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
			'AddMessage "车辆已进入工位"
			flashLamp(Lamp_YellowFlash_IOPort)
		ElseIf osensor1.state And osensor4.state Then 
			If TestStateFlag < 10 And TestStateFlag <> 3 And TestStateFlag <> 0 And TestStateFlag <> -1 Then
				'If TestStateFlag < 10 And TestStateFlag <> 1 And TestStateFlag <> 3 And TestStateFlag <> 0 Then
				LogWritter("检测完成！")
				
				car.Save(SpaceAvailable)
				If CDbl(car.GetTestState) = 15 Then
					'                car.CheckResultIsOverStandard
					'                If car.IsOverStandard Then
					'                     Call printErrResult(car)
					'                End If
				Else
					'白板提示
					AddMessage("前后车胎压ID学习错位！", True)
					'日志记录
					LogWritter(car.VINCode & "胎压ID学习错位！")
					'第一屏提示前后车胎压ID学习错位
					Me.frErrorText.Visible = True
					'红灯亮
					oIOCard.OutputController(Lamp_RedLight_IOPort, True)
					'                    '结束检测
					'                    DSGTestEnd
					'系统复位
					resetList()
				End If
				AddMessage("请注意队列是否正确", True)
				
				DSGTestEnd()
				
				DelayTime(1000)
				oIOCard.OutputController(rdOutput, False)
				oIOCard.OutputController(Lamp_RedLight_IOPort, False)
				oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
			ElseIf TestStateFlag > 9990 And TestStateFlag <> 9995 And TestStateFlag <> 9999 And TestStateFlag <> -1 Then 
				'ElseIf TestStateFlag > 9990 And TestStateFlag <> 9998 And TestStateFlag <> 9997 And TestStateFlag <> 9995 And TestStateFlag <> 9999 Then
				AddMessage("请注意队列是否正确", True)
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
			'If True Then
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
				'重置右边VT520
				oRVT520.ResetResult()
				'触发VT520
				oRVT520.Start("Comm")
				'循环读取
				For i = 0 To RVT520_icount
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
					'触发右边VT520
					oRVT520.Start("Comm")
					'循环读取
					For i = 0 To RVT520_icount
						oRVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" Then
							Exit For
						End If
					Next i
					
					LogWritter("第二次检测数据：" & tmpID)
					
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 右前轮检测完成
				
				car.TireRFID = tmpID
				LogWritter(car.VINCode & "右前轮检测数据：" & oRVT520.Result)
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
				'重置右侧VT520
				oRVT520.ResetResult()
				'触发VT520
				oRVT520.Start("Comm")
				'循环读取
				For i = 0 To RVT520_icount
					oRVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oRVT520.TireIDResult
					
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
						Exit For
					End If
				Next i
				
				LogWritter("第一次检测数据：" & tmpID)
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireLFID Then '第二次测量
					LogWritter("开始第二次检测右后轮……")
					'右边触发
					oRVT520.Start("Comm")
					'循环读取
					For i = 0 To RVT520_icount
						oRVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oRVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oRVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireLFID Then
							Exit For
						End If
					Next i
					
					LogWritter("第二次检测数据：" & tmpID)
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 右后轮检测完成
				
				car.TireRRID = tmpID
				LogWritter(car.VINCode & "右后轮检测数据：" & oRVT520.Result)
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
				'重置左侧VT520
				oLVT520.ResetResult()
				'触发VT520
				oLVT520.Start("Comm")
				'循环读取
				For i = 0 To LVT520_icount
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
						Exit For
					End If
				Next i
				
				LogWritter("第一次检测数据：" & tmpID)
				
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireRFID Then '第二次测量
					LogWritter("开始第二次检测左前轮……")
					'触发VT520
					oLVT520.Start("Comm")
					'循环读取
					For i = 0 To LVT520_icount
						oLVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireRFID Then
							Exit For
						End If
					Next i
					
					LogWritter("第二次检测数据：" & tmpID)
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 左前轮检测完成
				
				car.TireLFID = tmpID
				LogWritter(car.VINCode & "左前轮检测数据：" & oLVT520.Result)
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
				'重置左侧VT520
				oLVT520.ResetResult()
				'触发VT520
				oLVT520.Start("Comm")
				'循环读取
				For i = 0 To LVT520_icount
					oLVT520.ReadResult()
					'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					tmpID = oLVT520.TireIDResult
					
					If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
						Exit For
					ElseIf osensor0.state And osensor1.state Then 
						'白板提示
						AddMessage("前后车胎压ID学习错位！", True)
						'日志记录
						LogWritter(car.VINCode & "胎压ID学习错位！")
						'第一屏提示前后车胎压ID学习错位
						Me.frErrorText.Visible = True
						'红灯亮
						oIOCard.OutputController(Lamp_RedLight_IOPort, True)
						'                    '结束检测
						'                    DSGTestEnd
						'系统复位
						resetList()
						'蜂鸣
						flashBuzzerLamp(Lamp_RedLight_IOPort)
						Exit Sub
					End If
				Next i
				
				LogWritter("第一次检测数据：" & tmpID)
				If tmpID = "00000000" Or Trim(tmpID) = "" Or Trim(tmpID) = car.TireLFID Or Trim(tmpID) = car.TireRFID Or Trim(tmpID) = car.TireRRID Then
					LogWritter("开始第二次检测左后轮……")
					
					oLVT520.Start("Comm")
					For i = 0 To LVT520_icount
						oLVT520.ReadResult()
						'UPGRADE_WARNING: 未能解析对象 oLVT520.TireIDResult 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						tmpID = oLVT520.TireIDResult
						If tmpID <> "00000000" And Trim(tmpID) <> "" And Trim(tmpID) <> car.TireLFID And Trim(tmpID) <> car.TireRFID And Trim(tmpID) <> car.TireRRID Then
							Exit For
						ElseIf osensor0.state And osensor1.state Then 
							'白板提示
							AddMessage("前后车胎压ID学习错位！", True)
							'日志记录
							LogWritter(car.VINCode & "胎压ID学习错位！")
							'第一屏提示前后车胎压ID学习错位
							Me.frErrorText.Visible = True
							'红灯亮
							oIOCard.OutputController(Lamp_RedLight_IOPort, True)
							'                        '结束检测
							'                        DSGTestEnd
							'系统复位
							resetList()
							'蜂鸣
							flashBuzzerLamp(Lamp_RedLight_IOPort)
							Exit Sub
						End If
					Next i
					
					LogWritter("第二次检测数据：" & tmpID)
					
				End If
				
				isInTesting = False 'Add by ZCJ 2012-07-09 左后轮检测完成
				
				car.TireLRID = tmpID
				LogWritter(car.VINCode & "左后轮检测数据：" & oLVT520.Result)
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
				
				tmpsign = car.Save(SpaceAvailable) '保存数据
				'            If tmpsign = False Then
				'                Call printErrResult(car) '上传mes失败打印
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
						Call printErrResult(car) '全部打印
					End If
				Else
					flashBuzzerLamp(Lamp_RedLight_IOPort)
					AddMessage("检测结果失败。", True)
					LogWritter("检测结果失败！")
					'LogWritter "检测结果失败。启动打印！"
					'                If car.printFlag And car.LastCar.GetTestState <> 15 Then
					'                    If PrintModel = "2" Or PrintModel = "1" Then
					'                       Call printErrResult(car.LastCar)
					'                    End If
					'                End If
					If PrintModel = "2" Or PrintModel = "1" Then '仅模式选择全部打印和仅失败打印模式两种模式时打印
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
	'解锁开关事件
	Private Sub osensorCommand_onChange(ByRef state As Boolean) Handles osensorCommand.onChange
		SensorLogWritter("osensorCommand----" & CStr(state))
		BreakFlag = Not state
		If state Then
			AddMessage("系统已解锁！", True)
			setFrm(TestStateFlag)
			LogWritter("系统已解锁！")
			'Timer_PrintError.Interval = 1000
		Else
			AddMessage("系统已被锁定，请解锁！", True)
			LogWritter("系统已锁定！")
			'Timer_PrintError.Interval = 0
		End If
	End Sub
	'停线事件
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
		''    '上传检测结果
		'   Call UpLoadTestResult
		'
		'    HH = 0
		'    Exit Sub
		'Err:
		'    LogWritter "upload test result timer error"
		'    HH = 0
		'    Exit Sub
	End Sub
	'功能描述：上传检测结果到电检服务器
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
				'左前
				If localRst.Fields("ID022").Value & "" = "" Then
					tiresID = tiresID & "00000000"
				Else
					tiresID = tiresID & localRst.Fields("ID022").Value
				End If
				'右前
				If localRst.Fields("ID020").Value & "" = "" Then
					tiresID = tiresID & "00000000"
				Else
					tiresID = tiresID & localRst.Fields("ID020").Value
				End If
				'左后
				If localRst.Fields("ID023").Value & "" = "" Then
					tiresID = tiresID & "00000000"
				Else
					tiresID = tiresID & localRst.Fields("ID023").Value
				End If
				'右后
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
				'UPGRADE_NOTE: 在对对象 remoteRst 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
				remoteRst = Nothing
				
				'更新本地的上传标识
				localCnn.Execute("update ""T_Result"" set ""UploadSign"" = true where ""VIN"" = '" & localRst.Fields("VIN").Value & "' ")
				
			End If
			
			localRst.MoveNext()
		Loop 
		remoteCnn.Close()
		'remoteRst.Close
		'localRst.Close
		localCnn.Close()
		
		'UPGRADE_NOTE: 在对对象 remoteCnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		remoteCnn = Nothing
		'UPGRADE_NOTE: 在对对象 remoteRst 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		remoteRst = Nothing
		'UPGRADE_NOTE: 在对对象 localRst 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		localRst = Nothing
		'UPGRADE_NOTE: 在对对象 localCnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		localCnn = Nothing
		
		Exit Sub
Error_Renamed: 
		LogWritter("上传检测结果到电检服务器时出错：" & Err.Description)
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
				txtInputVIN.Text = "手工录入VID，回车确认"
				GoTo EventExitSub
			End If
			If VB.Left(TestCode, 17) = "R020000000000000C" Then
				barCodeFlag = True
				txtInputVIN.Text = "手工录入VID，回车确认"
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
			txtInputVIN.Text = "手工录入VID，回车确认"
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtInputVIN_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtInputVIN.Leave
		txtInputVIN.Text = "手工录入VID，回车确认"
	End Sub
	
	'处理扫描条码信息
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
			AddMessage(VB.Left(TestCode, 17) & "重复检测")
			'关闭数据集
			If Not rs Is Nothing Then
				If rs.state = 1 Then
					rs.Close()
				End If
			End If
			'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
			rs = Nothing
			'关闭数据连接
			If Not cnn Is Nothing Then
				If cnn.state = 1 Then
					cnn.Close()
				End If
			End If
			'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
			cnn = Nothing
			GoTo EventExitSub
		End If
		
		'系统锁定后扫描枪不响应
		If BreakFlag Then GoTo EventExitSub
		If KeyAscii = 13 Then
			TestCode = Trim(TestCode)
			TestCode = Replace(TestCode, Chr(10), "")
			TestCode = Replace(TestCode, Chr(13), "")
			If Len(TestCode) = 17 And VB.Left(UCase(TestCode), 1) = "T" Then 'VID码
				LogWritter("************************************************************")
				LogWritter("扫描条码：" & TestCode)
				LogWritter("************************************************************")
				oIOCard.OutputController(Lamp_Buzzer_IOPort, False) '关闭蜂鸣 第二次扫描条码正确后关闭蜂鸣
				If inputCode.Exists(TestCode) Then
					GoTo EventExitSub
				End If
				inputCode.Add(TestCode, TestCode)
				insertColl(TestCode) '将VIN,车型，是否带胎压写入到临时表vincoll中
				LogWritter(TestCode & "进入扫描队列")
				Me.List1.Items.Add(TestCode)
				frmInfo.ListOutput.Items.Add(VB.Right(TestCode, 17))
				Me.ListOutput1.Items.Add(VB.Right(TestCode, 8))
				initDictionary()
				
				If inputCode.Count = 1 Then
					'UPGRADE_WARNING: 未能解析对象 inputCode() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					txtVIN.Text = CStr(Mid(inputCode(inputCode.Keys(0)), 1, 17))
					frmInfo.labVin.Text = txtVIN.Text
					updateState("test", "False")
					updateState("vin", (txtVIN.Text))
					'避免扫描vin码时车辆已进入工位并且触发1号光电开关(TestStateFlag = 0或者9998)
					If TestStateFlag = 0 Or TestStateFlag = 9998 Then
						resetList()
						txtInputVIN.Text = ""
						GoTo EventExitSub
					End If
					TestStateFlag = -1
					updateState("state", CStr(-1))
					AddMessage("等待扫描车辆进入工位!")
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
				AddMessage("请注意扫描条码长度是否正确", True)
				flashBuzzerLamp(Lamp_RedLight_IOPort)
				LogWritter("条码长度不正确,调用声音报警!")
				LogWritter("错误条码：" & TestCode)
				DelayTime(2000)
				oIOCard.OutputController(Lamp_RedLight_IOPort, False)
				oIOCard.OutputController(rdOutput, False)
				If TestStateFlag = 9999 Or TestStateFlag = -1 Then
					oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
				Else
					oIOCard.OutputController(Lamp_GreenLight_IOPort, False)
					oIOCard.OutputController(Lamp_YellowFlash_IOPort, True)
				End If
				'关闭蜂鸣
				oIOCard.OutputController(Lamp_Buzzer_IOPort, False)
			End If
		End If
		GoTo EventExitSub
Err_Renamed: 
		LogWritter(Err.Description)
		'关闭数据集
		If Not rs Is Nothing Then
			If rs.state = 1 Then
				rs.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		'关闭数据连接
		If Not cnn Is Nothing Then
			If cnn.state = 1 Then
				cnn.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
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
		
		txtVIN.Text = Mid(vin, 1, 17)
		frmInfo.labVin.Text = txtVIN.Text
		frmInfo.labNow.Text = VB.Right(txtVIN.Text, 17)
		LogWritter("============================================================")
		LogWritter(txtVIN.Text & "开始测试!")
		If hasDSG(vin) Then
			LogWritter("测试码通过,开始DSG检测!")
			updateState("test", "True")
			updateState("vin", (txtVIN.Text))
			car = New CCar
			car.VINCode = txtVIN.Text
			
			'Add by ZCJ 2014-05-08
			car.CarType = CarTypeCode
			updateState("cartype", (car.CarType))
			LogWritter("当前车辆的车型为：" & car.CarType)
			'End Add
			
			TestStateFlag = 0
			setFrm(TestStateFlag)
			updateState("state", CStr(TestStateFlag))
			'避免此时txtvin方法里面改变状态
			If TestStateFlag <> 0 Then
				resetList()
				txtInputVIN.Text = ""
				Exit Sub
			End If
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
			'避免此时txtvin方法里面改变状态
			If TestStateFlag <> 9998 Then
				resetList()
				txtInputVIN.Text = ""
				Exit Sub
			End If
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
		
		If inputCode.Count <> 0 Then
			'UPGRADE_WARNING: 未能解析对象 inputCode.Keys() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			LogWritter(CStr(inputCode.Keys(0)) & "退出扫描队列!")
			'UPGRADE_WARNING: 未能解析对象 inputCode.Keys() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			delColl(CStr(inputCode.Keys(0)))
			inputCode.Remove(inputCode.Keys(0))
		End If
		
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
		
		DelayTime(2000)
		testEndDelyed = False
		'绿灯亮
		flashLamp(Lamp_GreenLight_IOPort)
		'关闭蜂鸣
		oIOCard.OutputController(Lamp_Buzzer_IOPort, False)
		
		'iniListInput
		initDictionary()
		
		If inputCode.Count <> 0 Then
			'再次启动DSGStart
			'UPGRADE_WARNING: 未能解析对象 inputCode() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			Call Me.DSGTestStart(CStr(inputCode(inputCode.Keys(0))))
		Else
			LogWritter("扫描队列中车辆数为空")
		End If
		'重置提示板
		clearListMsg()
		
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
	
	'有线条码枪串口信息设置
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
		LogWritter("有线条码枪串口设置错误：" & Err.Description)
	End Sub
	'无线条码枪串口信息设置
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
		LogWritter("无线条码枪串口设置错误：" & Err.Description)
	End Sub
	'显示当前的检测状态
	Public Sub setFrm(ByRef state As Short)
		If state = -1 Then
			AddMessage("等待扫描车辆进入工位!")
			initFrom(False)
		ElseIf state = 9999 Then 
			AddMessage("等待扫描VID，开始测试!")
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
					AddMessage("条码扫描通过,准备开始TPMS测试!")
					LogWritter("条码扫描通过,准备开始TPMS测试!")
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
	'处理有线扫描枪的扫描信息
	Private Sub MSComVIN_OnComm(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MSComVIN.OnComm
		If BreakFlag Then Exit Sub
		DelayTime(100)
		Dim tmp As Object
		Dim strin As String
		'UPGRADE_WARNING: 未能解析对象 MSComVIN.Input 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		'UPGRADE_WARNING: 未能解析对象 tmp 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		tmp = MSComVIN.Input
		'UPGRADE_WARNING: 未能解析对象 tmp 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		If tmp = "" Then Exit Sub
		'UPGRADE_WARNING: 未能解析对象 tmp 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		strin = strin & tmp
		TestCode = strin
		If VB.Left(TestCode, 17) = "R010000000000000C" Then
			LogWritter("1扫描重置条码")
			resetList()
			Exit Sub
		End If
		If VB.Left(TestCode, 17) = "R020000000000000C" Then
			barCodeFlag = True
			Exit Sub
		End If
		
		Debug.Print(TestCode)
		'UPGRADE_WARNING: 未能解析对象 tmp 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		tmp = ""
		Call txtVIN_KeyPress(txtVIN, New System.Windows.Forms.KeyPressEventArgs(Chr(13)))
		
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
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
	
	Public Sub clearListMsg()
		On Error GoTo Err_Renamed
		Dim i As Short
		Dim lstIndex As Short
		'当ListMsg中存在元素的时侯则清空
		If Me.ListMsg.Items.Count > 0 Then
			'取得最后一个元素的index
			lstIndex = Me.ListMsg.Items.Count - 1
			'剔除元素
			For i = lstIndex To 0 Step -1
				Me.ListMsg.Items.RemoveAt(i)
			Next 
		End If
		Exit Sub
Err_Renamed: 
		LogWritter(Err.Description & "***" & Err.Source)
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
		'MTOCCode = "InitMTOCCode" 'Add by ZCJ 2012-12-08
		
		delallColl()
		initDictionary()
		
		If testEndDelyed = False And TestStateFlag <> -1 Then
			TestStateFlag = 9999
		End If
		If TestStateFlag <> -1 Then
			resetState()
			LogWritter(txtVIN.Text & "测试完成!")
			LogWritter("============================================================")
		End If
		txtVIN.Text = ""
		
		setFrm(9999)
		updateState("state", CStr(TestStateFlag)) 'Add by ZCJ 20121207
		frmInfo.labNow.Text = ""
		
		'iniListInput '排产队列不管
		
		Call closeAll()
		oIOCard.OutputController(Lamp_GreenLight_IOPort, True)
		oIOCard.OutputController(Lamp_Buzzer_IOPort, False) '关闭蜂鸣
	End Sub
	'左击窗体移动
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
		'系统重置
		resetList()
		'隐藏面板
		Me.frErrorText.Visible = False
		'重置提示板
		clearListMsg()
		
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
			LogWritter(DBPosition & "硬盘可用空间不足" & CStr(VB6.Format(SpaceAvailable / 1024, "##.#")) & "C")
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
		'    If Ping(MES_IP) Then
		'        FrmMain.PicInd.Picture = LoadPicture(App.Path & "\img\Green.jpg")
		'        frmInfo.PicInd.Picture = LoadPicture(App.Path & "\img\Green.jpg")
		''        LogWritter "网络正常"
		'    Else
		'        FrmMain.PicInd.Picture = LoadPicture(App.Path & "\img\Red.jpg")
		'        frmInfo.PicInd.Picture = LoadPicture(App.Path & "\img\Red.jpg")
		'        LogWritter "网络异常"
		'        AddMessage "网络异常", True
		'    End If
		
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
			'flashBuzzerLamp Lamp_RedLight_IOPort
			'        DelayTime 2000
			'        oIOCard.OutputController Lamp_RedLight_IOPort, False
			'        oIOCard.OutputController rdOutput, False
			'        oIOCard.OutputController Lamp_GreenFlash_IOPort, True
		End If
		
		'UPGRADE_NOTE: 在对对象 objConn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		objConn = Nothing
		Exit Sub
Error_Renamed: 
		LogWritter("网络与数据库状态探查过程出错，" & Err.Description)
	End Sub
	''功能描述：查询网络状态
	'Private Sub NetStateQuery()
	'    On Error GoTo Error
	'
	'    Dim objConn As Connection
	'    Dim objConnMES As Connection
	'
	'    DoEvents
	'
	'    '探查本地数据库服务状态
	'    Set objConn = New Connection
	'    objConn.ConnectionTimeout = 2
	'    objConn.Open DBCnnStr
	'    If objConn.state = adStateOpen Then
	'        FrmMain.PicNet.Picture = LoadPicture(App.Path & "\img\Green.jpg")
	'        frmInfo.PicNet.Picture = LoadPicture(App.Path & "\img\Green.jpg")
	''            LogWritter "MES数据库连接正常"
	'        objConn.Close
	'    Else
	'        FrmMain.PicNet.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'        frmInfo.PicNet.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'        LogWritter "本地数据库连接异常"
	'        AddMessage "本地数据库连接异常", True
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
	''        LogWritter "网络正常"
	'
	'        '探查MES服务状态
	'        On Error GoTo ErrMES
	'
	'        Set objConnMES = New Connection
	'        objConnMES.ConnectionTimeout = 3
	'        DoEvents
	'        objConnMES.Open MESCnnStr
	'        If objConnMES.state = adStateOpen Then
	'            FrmMain.Picture6.Picture = LoadPicture(App.Path & "\img\Green.jpg")
	'            frmInfo.Picture6.Picture = LoadPicture(App.Path & "\img\Green.jpg")
	''            LogWritter "MES数据库连接正常"
	'            objConnMES.Close
	'        Else
	'            FrmMain.Picture6.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'            frmInfo.Picture6.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'            LogWritter "MES数据库连接异常"
	'            AddMessage "MES数据库连接异常", True
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
	'        LogWritter "网络异常"
	'        AddMessage "网络异常", True
	'        'flashBuzzerLamp Lamp_RedLight_IOPort
	''        DelayTime 2000
	''        oIOCard.OutputController Lamp_RedLight_IOPort, False
	''        oIOCard.OutputController rdOutput, False
	''        oIOCard.OutputController Lamp_GreenFlash_IOPort, True
	'        FrmMain.Picture6.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'        frmInfo.Picture6.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'        LogWritter "MES数据库连接异常"
	'    End If
	'
	'    Set objConnMES = Nothing
	'
	'    Exit Sub
	'ErrMES:
	'    FrmMain.Picture6.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'    frmInfo.Picture6.Picture = LoadPicture(App.Path & "\img\Red.jpg")
	'    LogWritter "MES数据库连接异常"
	'    Set objConnMES = Nothing
	'    Exit Sub
	'Error:
	'    LogWritter "网络与数据库状态探查过程出错，" & Err.Description
	'End Sub
	'从上游系统同步排产队列信息
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
		'    '同步车型数据
		'    LogWritter "正在自动同步车型数据"
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
		'        maxGatherDate = " order by id"
		'        LogWritter "本地没有车型代码，将从MES服务器上获取"
		'    Else '如果本地有数据则下载最新的
		'        strSQL = "SELECT max(""id"") FROM vinlist;"
		'        objRs.Open strSQL, objConn, adOpenKeyset, adLockOptimistic
		'        formatTimeString = objRs.Fields(0).value
		'        maxGatherDate = " where id > " & formatTimeString & " order by id"
		'        '关闭数据连接
		'        If Not objRs Is Nothing Then
		'            If objRs.state = 1 Then
		'                objRs.Close
		'            End If
		'        End If
		'        LogWritter "本地最新车型id为" & formatTimeString
		'    End If
		'    '开始更新
		'    Set objConnMES = New Connection
		'    Set objRsMES = New Recordset
		'    objConnMES.ConnectionTimeout = 3
		'    objConnMES.Open MESCnnStr
		'    strSQL = "select * from ACTIA_VINLIST" & maxGatherDate
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
		'                strSQL = "SELECT * FROM vinlist where vin = '" & objRsMES("VIN") & "'"
		'                objRs.Open strSQL, objConn, adOpenStatic, adLockOptimistic
		'                '如果没有则插入
		'                If objRs.RecordCount <= 0 Then
		'                    strSQL = "INSERT INTO vinlist(""id"",""vin"", ""tpms"", ""carcode"",""optioncode"",""time"") VALUES ('" & objRsMES("ID") & "','" & objRsMES("VIN") & "', '" & objRsMES("TPMS") & "', '" & objRsMES("CARCODE") & "', '" & objRsMES("OPTIONCODE") & "','" & objRsMES("TIME") & "');"
		'                    LogWritter "插入" & objRsMES("VIN")
		'                    i = i + 1
		'                Else
		'                    strSQL = "UPDATE vinlist SET ""id""='" & objRsMES("ID") & "',""vin""='" & objRsMES("VIN") & "', ""tpms""='" & objRsMES("TPMS") & "', ""carcode""='" & objRsMES("CARCODE") & "',optioncode='" & objRsMES("OPTIONCODE") & "', ""time""='" & objRsMES("TIME") & "' WHERE vin = '" & objRsMES("VIN") & "';"
		'                    LogWritter "更新" & objRsMES("VIN")
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
		'    strSQL = "delete from vinlist where ""id"" < (select ""id"" from vinlist where ""id"" in (select ""id"" from vinlist order by ""id"" desc limit " & categoryLimit & ") order by ""id"" limit 1)"
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
		'    LogWritter "车型数据自动同步完毕"
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
		'    'MsgBox "车型数据同步失败，请查看日志"
		'
		''    Dim objConn As Connection
		''    Dim objConnMES As Connection
		''    Dim objRs As Recordset
		''    Dim objTmpRs As Recordset
		''    Dim objRsMES As Recordset
		''    Dim strSQL As String
		''
		''    LogWritter "正在自动同步排产队列数据"
		''
		''    On Error GoTo ErrMES
		''    '先读取MES上的数据
		''    Set objConnMES = New Connection
		''    Set objRsMES = New Recordset
		''    objConnMES.ConnectionTimeout = 3
		''    DoEvents
		''    objConnMES.Open MESCnnStr
		''    If objConnMES.state <> adStateOpen Then
		''        LogWritter "MES数据库连接失败，无法同步数据"
		''        Set objConnMES = Nothing
		''        Exit Sub
		''    End If
		''    strSQL = "select * from mesprd.IF_VEHICLE_TPMS_INFO where tpms_process=0 order by pa_off_seq asc"
		''    objRsMES.Open strSQL, objConnMES, adOpenKeyset, adLockOptimistic
		''
		''    '打开本地数据库连接
		''    Set objConn = New Connection
		''    Set objRs = New Recordset
		''    objConn.ConnectionTimeout = 2
		''    objConn.Open DBCnnStr
		''
		''    strSQL = "select * from vinlist"
		''    objRs.Open strSQL, objConn, adOpenStatic, adLockOptimistic
		''    DoEvents
		''    Set objTmpRs = New Recordset
		''    Do While Not objRsMES.EOF              '---添加新数据
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
		''        '更新MES系统的下载标识
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
		''    LogWritter "排产队列数据同步完毕"
		''
		''    nn = 0
		''    Exit Sub
		''ErrMES:
		''    LogWritter "MES数据库连接失败，无法同步数据"
		''    Set objConnMES = Nothing
		''    nn = 0
		''    Exit Sub
		''Err:
		''    LogWritter "数据同步过程出错"
		''    nn = 0
	End Sub
	
	'显示系统信息
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
	'初始化窗体的内容
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
			frmInfo.labVin.Text = "胎压检测初始化系统"
		End If
	End Sub
End Class