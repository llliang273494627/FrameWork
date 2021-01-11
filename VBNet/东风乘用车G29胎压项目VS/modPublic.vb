Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module modPublic
	'******************************************************************************
	'** 文件名：modPublic.bas
	'** 版  权：CopyRight (c) 2008-2010 武汉华信数据系统有限公司
	'** 创建人：yangshuai
	'** 邮  箱：shuaigoplay@live.cn
	'** 日  期：2009-2-27
	'** 修改人：
	'** 日  期：
	'** 描  述：公共模块
	'** 版  本：1.0
	'******************************************************************************
	
	
	'关闭指定进程
	Private Structure PROCESSENTRY32
		Dim dwSize As Integer
		Dim cntUsage As Integer
		Dim th32ProcessID As Integer
		Dim th32DefaultHeapID As Integer
		Dim th32ModuleID As Integer
		Dim cntThreads As Integer
		Dim th32ParentProcessID As Integer
		Dim pcPriClassBase As Integer
		Dim dwFlags As Integer
		'UPGRADE_WARNING: 固定长度字符串的大小必须适合缓冲区。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"”
		<VBFixedString(260),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=260)> Public szExeFile() As Char
	End Structure
	Private Declare Function CreateToolhelp32Snapshot Lib "kernel32" (ByVal dwFlags As Integer, ByVal th32ProcessID As Integer) As Integer
	'UPGRADE_WARNING: 结构 PROCESSENTRY32 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Private Declare Function Process32First Lib "kernel32" (ByVal hSnapShot As Integer, ByRef lppe As PROCESSENTRY32) As Integer
	'UPGRADE_WARNING: 结构 PROCESSENTRY32 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Private Declare Function Process32Next Lib "kernel32" (ByVal hSnapShot As Integer, ByRef lppe As PROCESSENTRY32) As Integer
	Private Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Integer, ByVal blnheritHandle As Integer, ByVal dwAppProcessId As Integer) As Integer
	Private Declare Function TerminateProcess Lib "kernel32" (ByVal ApphProcess As Integer, ByVal uExitCode As Integer) As Integer
	Private Declare Sub CloseHandle Lib "kernel32" (ByVal hPass As Integer)
	Private Const TH32CS_SNAPPROCESS As Integer = &H2
	
	
	Private Declare Function GetTickCount Lib "kernel32" () As Integer
	Public ProgramTitle As String '程序Title在所有需要显示的地方全部用该变量，例如msgbox函数的Title参数
	Public DBCnnStr As String '数据库连接字符串全局需要连接数据库的地方全部调用该变量
	Public RDBCnnStr As String
	
	Public MESCnnStr As String 'MES数据库的连接字符串
	Public MES_IP As String 'MES服务器IP地址
	Public DayCount As Short '当天（班次）检测数量
	Public DataDel As Short '是否更新最新数据
	
	Public oIOCard As IOCard 'IO控制对象
	
	'VT520控制相关参数
	Public oLVT520 As CVT520 'VT520控制对象
	Public LVT520_PortNum As Short
	Public LVT520_Settings As String
	Public oRVT520 As CVT520 'VT520控制对象
	Public RVT520_PortNum As Short
	Public RVT520_Settings As String
	Public LVT520_icount As Short '左边VT520的读取次数
	Public RVT520_icount As Short '右边VT520的读取次数
	
	'信号灯相关控制参数（io信号输出端口）
	Public Lamp_GreenFlash_IOPort As Short
	Public Lamp_GreenLight_IOPort As Short
	Public Lamp_YellowLight_IOPort As Short
	Public Lamp_YellowFlash_IOPort As Short
	Public Lamp_RedLight_IOPort As Short
	Public Lamp_RedFlash_IOPort As Short
	Public Lamp_Buzzer_IOPort As Short
	Public Line_IOPort As Short
	
	'不同类型的轮胎传感器所对应的控制器程序号
	Public ProNum_OldSensor As Short 'C4L(旧传感器)
	Public ProNum_NewSensor As Short 'C4L(新传感器)
	
	'打印模式设定
	Public PrintModel As String '0表示全不打印，1表示全部打印，2表示仅失败打印
	
	'条码枪设置
	Public WirledCodeGun_PortNum As String
	Public WirledCodeGun_Settings As String
	Public WirlessCodeGun_PortNum As String
	Public WirlessCodeGun_Settings As String
	
	'喇叭控制参数（io信号输出端口）
	
	
	Public rdOutput As Short
	Public rdResetCommand As Short
	
	'光电开关控制器以及控制参数
	Public sensor0 As CSensor
	Public sensor1 As CSensor
	Public sensor2 As CSensor
	Public sensor3 As CSensor
	Public sensor4 As CSensor
	Public sensor5 As CSensor
	
	Public sensorCommand As CSensor
	Public sensorLine As CSensor
	Public rdResetCommandS As CSensor
	
	Public sensor0Port As Short
	Public sensor1Port As Short
	Public sensor2Port As Short
	Public sensor3Port As Short
	Public sensor4Port As Short
	Public sensor5Port As Short
	
	Public sensorCommandPort As Short
	Public sensorLinePort As Short
	
	'传感器参数设置
	Public mdlValue As String
	Public preMinValue As String
	Public preMaxValue As String
	Public tempMinValue As String
	Public tempMaxValue As String
	Public acSpeedMinValue As String
	Public acSpeedMaxValue As String
	Public mTOCStartIndex As String
	Public tPMSCodeLen As String
	
	'系统扫描条码的模式
	Public isCheckAllQueue As Boolean '是否校验排产队列
	Public isOnlyScanVINCode As Boolean '是否只扫描VIN码，MTOC码将会从MES系统中获得
	Public isOnlyPrintNGWriteResult As Boolean '是否只打印诊断结果为NG的诊断单据
	Public isOnlyPrintNGFlow As Boolean '是否只打印NG的诊断流程，合格的流程不打印
	
	Public TimeOutNum As Short
	Public lineCommandFlag As Boolean
	
	'******************************************************************************
	'** 函 数 名：main
	'** 输    入：
	'** 输    出：
	'** 功能描述：程序主函数初始化全部公共变量，调用主窗体
	'** 全局变量：
	'** 作    者：yangshuai
	'** 邮    箱：shuaigoplay@live.cn
	'** 日    期：2009-2-27
	'** 修 改 者：
	'** 日    期：
	'** 版    本：1.0
	'******************************************************************************
	'UPGRADE_WARNING: 应用程序将在 Sub Main() 结束时终止。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E08DDC71-66BA-424F-A612-80AF11498FF8"”
	Public Sub Main()
		On Error GoTo Main_Err
		DBCnnStr = "Provider=MSDASQL.1;Persist Security Info=False;Data Source=DFPV_DSG101" 'DSG101ODBC
		RDBCnnStr = getConfigValue("T_RunParam", "DB", "RDBCnnStr")
		TimeOutNum = CShort(getConfigValue("T_RunParam", "DB", "TimeOutNum"))
		Dim X As System.Windows.Forms.Form
		For	Each X In My.Application.OpenForms
			X.Close()
		Next X
		
		'得到参数配置getConfigValue
		'动态读取参数配置
		
		ProgramTitle = "DSG初始化系统"
		
		MESCnnStr = getConfigValue("T_RunParam", "DB", "MESCnnStr") 'MES系统Oracle数据库连接字符串
		MES_IP = getConfigValue("T_RunParam", "MES", "MESIP") 'MES系统数据库所在服务器IP地址
		'当天（班次）检测数量限制
		DayCount = CShort(getConfigValue("T_RunParam", "Count", "DayCount"))
		'获取是否保持T_Result表最新数据
		DataDel = CShort(getConfigValue("T_RunParam", "Data", "DataDel"))
		
		'初始化控制对象
		
		'初始化VT520参数
		LVT520_PortNum = CShort(getConfigValue("T_CtrlParam", "LVT520", "LVT520_PortNum"))
		LVT520_Settings = getConfigValue("T_CtrlParam", "LVT520", "LVT520_Settings")
		LVT520_icount = CShort(getConfigValue("T_CtrlParam", "LVT520", "LVT520_icount"))
		
		
		oLVT520 = New CVT520
		oLVT520.CommPort = LVT520_PortNum
		oLVT520.ComSettings = LVT520_Settings
		oLVT520.OpenPort = True
		
		RVT520_PortNum = CShort(getConfigValue("T_CtrlParam", "RVT520", "RVT520_PortNum"))
		RVT520_Settings = getConfigValue("T_CtrlParam", "RVT520", "RVT520_Settings")
		RVT520_icount = CShort(getConfigValue("T_CtrlParam", "RVT520", "RVT520_icount"))
		oRVT520 = New CVT520
		oRVT520.CommPort = RVT520_PortNum
		oRVT520.ComSettings = RVT520_Settings
		oRVT520.OpenPort = True
		
		oIOCard = New IOCard
		
		'读取并初始化对象信号灯控制参数
		Lamp_GreenFlash_IOPort = CShort(getConfigValue("T_CtrlParam", "Lamp", "Lamp_GreenFlash_IOPort"))
		Lamp_GreenLight_IOPort = CShort(getConfigValue("T_CtrlParam", "Lamp", "Lamp_GreenLight_IOPort"))
		Lamp_YellowLight_IOPort = CShort(getConfigValue("T_CtrlParam", "Lamp", "Lamp_YellowLight_IOPort"))
		Lamp_RedLight_IOPort = CShort(getConfigValue("T_CtrlParam", "Lamp", "Lamp_RedLight_IOPort"))
		Lamp_RedFlash_IOPort = CShort(getConfigValue("T_CtrlParam", "Lamp", "Lamp_RedFlash_IOPort"))
		Lamp_Buzzer_IOPort = CShort(getConfigValue("T_CtrlParam", "Lamp", "Lamp_Buzzer_IOPort"))
		Lamp_YellowFlash_IOPort = CShort(getConfigValue("T_CtrlParam", "Lamp", "Lamp_YellowFlash_IOPort"))
		
		Line_IOPort = CShort(getConfigValue("T_CtrlParam", "Line", "Line_IOPort"))
		rdOutput = CShort(getConfigValue("T_CtrlParam", "Lamp", "rdOutput"))
		rdResetCommand = CShort(getConfigValue("T_CtrlParam", "Lamp", "rdResetCommand"))
		sensorCommandPort = CShort(getConfigValue("T_CtrlParam", "Line", "sensorCommandPort"))
		sensorLinePort = CShort(getConfigValue("T_CtrlParam", "Line", "sensorLinePort"))
		'初始化光电开关
		sensor0Port = CShort(getConfigValue("T_CtrlParam", "sensor", "sensor0Port"))
		sensor1Port = CShort(getConfigValue("T_CtrlParam", "sensor", "sensor1Port"))
		sensor2Port = CShort(getConfigValue("T_CtrlParam", "sensor", "sensor2Port"))
		sensor3Port = CShort(getConfigValue("T_CtrlParam", "sensor", "sensor3Port"))
		sensor4Port = CShort(getConfigValue("T_CtrlParam", "sensor", "sensor4Port"))
		sensor5Port = CShort(getConfigValue("T_CtrlParam", "sensor", "sensor5Port"))
		
		'不同类型的轮胎传感器所对应的控制器程序号
		'    ProNum_OldSensor = getConfigValue("T_CtrlParam", "ProgramNum", "ProNum_OldSensor")
		'    ProNum_NewSensor = getConfigValue("T_CtrlParam", "ProgramNum", "ProNum_NewSensor")
		
		'传感器参数设定
		mdlValue = getConfigValue("T_RunParam", "StandardValue", "MdlValue")
		preMinValue = getConfigValue("T_RunParam", "StandardValue", "PreMinValue")
		preMaxValue = getConfigValue("T_RunParam", "StandardValue", "PreMaxValue")
		tempMinValue = getConfigValue("T_RunParam", "StandardValue", "TempMinValue")
		tempMaxValue = getConfigValue("T_RunParam", "StandardValue", "TempMaxValue")
		acSpeedMinValue = getConfigValue("T_RunParam", "StandardValue", "AcSpeedMinValue")
		acSpeedMaxValue = getConfigValue("T_RunParam", "StandardValue", "AcSpeedMaxValue")
		'    mTOCStartIndex = getConfigValue("T_RunParam", "TPMSCode", "MTOCStartIndex")
		'    tPMSCodeLen = getConfigValue("T_RunParam", "TPMSCode", "TPMSCodeLen")
		
		WirledCodeGun_PortNum = getConfigValue("T_CtrlParam", "BarCodeGun", "WirledCodeGun_PortNum")
		WirledCodeGun_Settings = getConfigValue("T_CtrlParam", "BarCodeGun", "WirledCodeGun_Settings")
		
		WirlessCodeGun_PortNum = getConfigValue("T_CtrlParam", "BarCodeGun", "WirlessCodeGun_PortNum")
		WirlessCodeGun_Settings = getConfigValue("T_CtrlParam", "BarCodeGun", "WirlessCodeGun_Settings")
		
		lineCommandFlag = CBool(getConfigValue("T_CtrlParam", "sensor", "lineCommandFlag"))
		
		'isCheckAllQueue = CBool(getConfigValue("T_RunParam", "Queue", "CheckAllQueue"))
		'isOnlyScanVINCode = CBool(getConfigValue("T_RunParam", "Queue", "OnlyScanVINCode"))
		isOnlyPrintNGWriteResult = CBool(getConfigValue("T_RunParam", "Print", "OnlyPrintNGWriteResult"))
		isOnlyPrintNGFlow = CBool(getConfigValue("T_RunParam", "Print", "OnlyPrintNGFlow"))
		
		'打印模式
		PrintModel = getConfigValue("T_RunParam", "Print", "PrintModel")
		
		sensor0 = New CSensor
		sensor1 = New CSensor
		sensor2 = New CSensor
		sensor3 = New CSensor
		sensor4 = New CSensor
		sensor5 = New CSensor
		rdResetCommandS = New CSensor
		sensorCommand = New CSensor
		sensorLine = New CSensor
		
		sensor0.IOPort = sensor0Port
		sensor1.IOPort = sensor1Port
		sensor2.IOPort = sensor2Port
		sensor3.IOPort = sensor3Port
		sensor4.IOPort = sensor4Port
		sensor5.IOPort = sensor5Port
		
		rdResetCommandS.IOPort = rdResetCommand
		sensorCommand.IOPort = sensorCommandPort
		sensorLine.IOPort = sensorLinePort
		
		FrmMain.Show()
		
		Exit Sub
Main_Err: 
		
		MsgBox("初始化参数失败，错误信息：" & Err.Description & "。请检查配置信息！")
		
	End Sub
	
	
	
	'******************************************************************************
	'** 函 数 名：exportExcel
	'** 输    入：sqlText——sql语句
	'** 输    出：
	'** 功能描述：导出sql查询语句的查询结果
	'** 全局变量：
	'** 作    者：yangshuai
	'** 邮    箱：shuaigoplay@live.cn
	'** 日    期：2009-2-28
	'** 修 改 者：
	'** 日    期：
	'** 版    本：1.0
	'******************************************************************************
	
	Public Sub exportExcel(ByRef sqlText As String)
		Dim excelzfc As String
		Dim fileName As String
		Dim FSO As Scripting.FileSystemObject
		Dim txtfile As Scripting.TextStream
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		Dim NowOutputDir As String
		On Error GoTo exportExcel_ERR
		fileName = getExcelFileName '得到随机文件名
		cnn.Open(DBCnnStr)
		rs = cnn.Execute(sqlText)
		FSO = CreateObject("Scripting.FileSystemObject")
		
		NowOutputDir = My.Application.Info.DirectoryPath & "\Export"
		'UPGRADE_WARNING: Dir 有新行为。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"”
		If Trim(Dir(NowOutputDir, FileAttribute.Directory)) = "" Then
			FSO.CreateFolder(NowOutputDir)
		End If
		
		txtfile = FSO.CreateTextFile(fileName, True)
		
		'    For I = 0 To Me.MSFlexGrid1.Rows - 1
		'        For J = 1 To Me.MSFlexGrid1.Cols - 1
		'            excelzfc = excelzfc & MSFlexGrid1.TextMatrix(I, J) & Chr(9)
		'        Next
		'        txtfile.WriteLine
		'    Next
		
		
		'构造表头
		Dim i As Short
		Dim tmp As String
		For i = 0 To rs.Fields.Count - 1
			tmp = tmp & rs.Fields(i).Name & Chr(9)
		Next 
		txtfile.WriteLine(tmp)
		
		'构造表格内部
		Do While Not rs.EOF
			tmp = ""
			For i = 0 To rs.Fields.Count - 1
				tmp = tmp & rs.Fields(rs.Fields(i).Name).value & Chr(9)
			Next 
			txtfile.WriteLine(tmp)
			rs.MoveNext()
		Loop 
		
		'UPGRADE_NOTE: 在对对象 txtfile 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		txtfile = Nothing
		'UPGRADE_NOTE: 在对对象 FSO 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		FSO = Nothing
		
		'打开excel
		Dim db1, xlApp, xlbook, xlsheet As Object
		xlApp = CreateObject("Excel.Application")
		'UPGRADE_WARNING: 未能解析对象 xlApp.DisplayAlerts 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		xlApp.DisplayAlerts = False '不显示警告
		'UPGRADE_WARNING: 未能解析对象 xlApp.Application 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		xlApp.Application.Visible = True '不显示界面
		'UPGRADE_WARNING: 未能解析对象 xlApp.Workbooks 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		xlbook = xlApp.Workbooks.Open(fileName)
		Exit Sub
exportExcel_ERR: 
		MsgBox("数据导出Excel出错，错误信息：" & Err.Description)
	End Sub
	
	'******************************************************************************
	'** 函 数 名：getExcelFileName
	'** 输    入：
	'** 输    出：生成的新的excel文件名
	'** 功能描述：生成的新的excel文件名 年+月+日+时+分+秒+1000内随机数.xls
	'** 全局变量：
	'** 作    者：yangshuai
	'** 邮    箱：shuaigoplay@live.cn
	'** 日    期：2009-2-28
	'** 修 改 者：
	'** 日    期：
	'** 版    本：1.0
	'******************************************************************************
	Public Function getExcelFileName() As String
		Dim MyValue As String
		Randomize() ' 对随机数生成器做初始化的动作。
		MyValue = VB6.Format(Int((1000 * Rnd()) + 1), "0000") ' 生成 1 到 1000 之间的随机数值。
		getExcelFileName = GetProjectPath & "export\"
		getExcelFileName = getExcelFileName & VB6.Format(Year(Now), "0000")
		getExcelFileName = getExcelFileName & VB6.Format(Month(Now), "00")
		getExcelFileName = getExcelFileName & VB6.Format(VB.Day(Now), "00")
		getExcelFileName = getExcelFileName & VB6.Format(Hour(Now), "00")
		getExcelFileName = getExcelFileName & VB6.Format(Minute(Now), "00")
		getExcelFileName = getExcelFileName & VB6.Format(Second(Now), "00")
		getExcelFileName = getExcelFileName & MyValue
		getExcelFileName = getExcelFileName & ".xls"
	End Function
	
	'******************************************************************************
	'** 函 数 名：GetProjectPath
	'** 输    入：
	'** 输    出：
	'** 功能描述：
	'** 全局变量：
	'** 作    者：yangshuai
	'** 邮    箱：shuaigoplay@live.cn
	'** 日    期：2009-2-27
	'** 修 改 者：
	'** 日    期：
	'** 版    本：1.0
	'******************************************************************************
	
	Public Function GetProjectPath() As String
		If Right(My.Application.Info.DirectoryPath, 1) <> "\" Then
			GetProjectPath = My.Application.Info.DirectoryPath & "\"
		Else
			GetProjectPath = My.Application.Info.DirectoryPath
		End If
	End Function
	
	'******************************************************************************
	'** 函 数 名：hasDSG
	'** 输    入：
	'** 输    出：
	'** 功能描述：是否装配DSG
	'** 全局变量：
	'** 作    者：xiaosq
	'** 邮    箱：xiaosq@huaxindata.com.cn
	'** 日    期：2009-2-27
	'** 修 改 者：
	'** 日    期：
	'** 版    本：2.0
	'******************************************************************************
	Public Function hasDSG(ByRef CarCode As String) As Boolean
		On Error GoTo hasDSG_Err
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		Dim TPMS As String
		Dim intFlag As Short
		Dim tmpV As String
		Dim tmpCarType As String
		Dim tmpT As Object
		Dim tmpJ As String '一个是发射程序号，一个是干扰程序号
		Dim sqlT As Object
		Dim sqlJ As String '查询语句
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select tpms,cartype from vincoll where vin='" & CarCode & "'")
		If Not rs.EOF Then
			TPMS = rs.Fields(0).value
			FrmMain.CarTypeCode = rs.Fields(1).value
		Else
			TPMS = ""
			FrmMain.CarTypeCode = ""
		End If
		
		If TPMS = "1" Then
			hasDSG = True
		Else
			hasDSG = False
		End If
		'-----------设置程序号--------------
		Call SetProNum((FrmMain.CarTypeCode))
		'-----------------------------------
		If Not rs Is Nothing Then
			If rs.state = 1 Then
				rs.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		
		If Not cnn Is Nothing Then
			If cnn.state = 1 Then
				cnn.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
		Exit Function
hasDSG_Err: 
		LogWritter("hasDSG函数内发现错误，错误信息：" & Err.Description)
		hasDSG = False
		
		If Not rs Is Nothing Then
			If rs.state = 1 Then
				rs.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		
		If Not cnn Is Nothing Then
			If cnn.state = 1 Then
				cnn.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Function
	Public Function hasProNum(ByRef CarType As String) As String '根据车型获得程序号
		On Error GoTo hasProNum_Err
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		Dim tmpCarType As Object
		Dim sql As String
		cnn.Open(DBCnnStr)
		sql = "select ""ProNum"" from ""cartype_prono"" where ""CarType"" = '" & CarType & "'"
		rs = cnn.Execute(sql)
		If Not rs.EOF Then
			hasProNum = rs.Fields(0).value
		Else
			hasProNum = CStr(1) '如果找不到车型，默认1号程序
		End If
		
		If Not rs Is Nothing Then
			If rs.state = 1 Then
				rs.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		
		If Not cnn Is Nothing Then
			If cnn.state = 1 Then
				cnn.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
		Exit Function
hasProNum_Err: 
		LogWritter("hasProNum函数内发现错误，错误信息：" & Err.Description)
		
		If Not rs Is Nothing Then
			If rs.state = 1 Then
				rs.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		
		If Not cnn Is Nothing Then
			If cnn.state = 1 Then
				cnn.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Function
	'Add by  2016-1-11 根据当车型设置程序号
	Public Function SetProNum(ByRef CarType As String) As Object
		On Error GoTo SetProNum_Err
		Dim proNum As String
		proNum = hasProNum(CarType)
		oRVT520.SendProNum(CShort(proNum)) '
		oLVT520.SendProNum(CShort(proNum))
		'LogWritter "将控制器的程序号设置为" & ProNum
		Exit Function
SetProNum_Err: 
		LogWritter("在设置控制器程序号时出错，错误信息：" & Err.Description)
	End Function
	
	'******************************************************************************
	'** 函 数 名：getConfigValue
	'** 输    入：
	'** 输    出：
	'** 功能描述：得到配置值
	'** 全局变量：
	'** 作    者：yangshuai
	'** 邮    箱：shuaigoplay@live.cn
	'** 日    期：2009-2-27
	'** 修 改 者：
	'** 日    期：
	'** 版    本：1.0
	'******************************************************************************
	Public Function getConfigValue(ByRef tableName As String, ByRef group As String, ByRef key As String) As String
		On Error GoTo getConfigValue_err
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select ""Value"" from """ & tableName & """ where ""Group""='" & group & "' and ""Key""='" & key & "' ")
		If Not rs.EOF Then
			getConfigValue = rs.Fields(0).value
		Else
			getConfigValue = ""
		End If
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
		Exit Function
getConfigValue_err: 
		LogWritter("数据库操作错误！错误信息：" & Err.Description)
		If cnn.state = 1 Then
			cnn.Close()
		End If
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Function
	''******************************************************************************
	''** 函 数 名：setConfigValue
	''** 输    入：
	''** 输    出：
	''** 功能描述：设置配置值
	''** 全局变量：
	''** 作    者：yangshuai
	''** 邮    箱：shuaigoplay@live.cn
	''** 日    期：2009-2-27
	''** 修 改 者：
	''** 日    期：
	''** 版    本：1.0
	''******************************************************************************
	'Public Function setConfigValue(tableName As String, Group As String, key As String, value As String)
	'    Dim cnn As New ADODB.Connection
	'    Dim rs As ADODB.Recordset
	'    cnn.Open DBCnnStr
	'    Set rs = cnn.Execute("select ")
	'    cnn.Close
	'End Function
	
	Public Sub printErrResult(ByRef car As CCar)
		Dim DataReport1 As Object
		On Error GoTo printError
		Dim tmpStr As String
		Dim rs As New ADODB.Recordset
		Dim mdlArr() As String
		
		rs.Fields.Append("name", ADODB.DataTypeEnum.adBSTR)
		rs.Open()
		rs.AddNew()
		rs.Fields("name").value = "name"
		
		'UPGRADE_WARNING: 未能解析对象 DataReport1.DataSource 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		DataReport1.DataSource = rs
		
		'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		DataReport1.Sections("Section1").Controls("lblVIN").Caption = DataReport1.Sections("Section1").Controls("lblVIN").Caption & car.VINCode
		
		
		'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		DataReport1.Sections("Section1").Controls("lbldate").Caption = DataReport1.Sections("Section1").Controls("lbldate").Caption & Today
		'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		DataReport1.Sections("Section1").Controls("lbltime").Caption = DataReport1.Sections("Section1").Controls("lbltime").Caption & TimeOfDay
		If CDbl(car.GetTestState) = 15 Then
			'        If car.IsOverStandard Then 'Modiy by ZCJ 2012-07-09
			'            DataReport1.Sections("Section1").Controls("labResult").Caption = "NG"
			'            DataReport1.Sections("Section1").Controls("labResult").ForeColor = &HFF&
			'        Else
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("labResult").Caption = "OK"
			'        End If
		Else
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("labResult").Caption = "NG"
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("labResult").ForeColor = &HFF
		End If
		Dim resultState As String
		resultState = DToB(CShort(car.GetTestState))
		
		mdlArr = Split(mdlValue, ",")
		
		If Mid(resultState, 1, 1) = "1" Then
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl1").Caption = DataReport1.Sections("Section1").Controls("lbl1").Caption & car.TireRFID
			'判断模式
			'        If judgeMdlIsOK(car.TireRFMdl, mdlArr) = False Then
			'            tmpStr = ";模式" & car.TireRFMdl & "(不合格)"
			'        End If
			
			'判断压力值是否合格
			If CDec(car.TireRFPre) < CDec(preMinValue) Then
				tmpStr = ";压力" & car.TireRFPre & "kPa(偏低)"
			ElseIf CDec(car.TireRFPre) > CDec(preMaxValue) Then 
				tmpStr = ";压力" & car.TireRFPre & "kPa(偏高)"
			End If
			'判断温度值是否合格
			'        If CCur(car.TireRFTemp) < CCur(tempMinValue) Then
			'            tmpStr = tmpStr & ";温度" & car.TireRFTemp & "℃(偏低)"
			'        ElseIf CCur(car.TireRFTemp) > CCur(tempMaxValue) Then
			'            tmpStr = tmpStr & ";温度" & car.TireRFTemp & "℃(偏高)"
			'        End If
			'判断加速度是否合格
			'        If CCur(car.TireRFAcSpeed) < CCur(acSpeedMinValue) Then
			'            tmpStr = tmpStr & ";加速度" & car.TireRFAcSpeed & "g(偏低)"
			'        ElseIf CCur(car.TireRFAcSpeed) > CCur(acSpeedMaxValue) Then
			'            tmpStr = tmpStr & ";加速度" & car.TireRFAcSpeed & "g(偏高)"
			'        End If
			'判断电池电量
			'        If car.TireRFBattery <> "OK" Then
			'            tmpStr = tmpStr & ";电池电量低"
			'        End If
		Else
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl1").ForeColor = &HFF
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl1").Caption = DataReport1.Sections("Section1").Controls("lbl1").Caption & "检测失败"
		End If
		If tmpStr <> "" Then
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl1").Caption = DataReport1.Sections("Section1").Controls("lbl1").Caption & tmpStr
			tmpStr = ""
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("labResult").Caption = "NG"
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("labResult").ForeColor = &HFF
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl1").ForeColor = &HFF
		End If
		
		
		
		
		If Mid(resultState, 2, 1) = "1" Then
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl2").Caption = DataReport1.Sections("Section1").Controls("lbl2").Caption & car.TireLFID
			'        '判断模式
			'        If judgeMdlIsOK(car.TireLFMdl, mdlArr) = False Then
			'            tmpStr = ";模式" & car.TireLFMdl & "(不合格)"
			'        End If
			
			'判断压力值是否合格
			If CDec(car.TireLFPre) < CDec(preMinValue) Then
				tmpStr = ";压力" & car.TireLFPre & "kPa(偏低)"
			ElseIf CDec(car.TireLFPre) > CDec(preMaxValue) Then 
				tmpStr = ";压力" & car.TireLFPre & "kPa(偏高)"
			End If
			'        '判断温度值是否合格
			'        If CCur(car.TireLFTemp) < CCur(tempMinValue) Then
			'            tmpStr = tmpStr & ";温度" & car.TireLFTemp & "℃(偏低)"
			'        ElseIf CCur(car.TireLFTemp) > CCur(tempMaxValue) Then
			'            tmpStr = tmpStr & ";温度" & car.TireLFTemp & "℃(偏高)"
			'        End If
			'        '判断加速度是否合格
			'        If CCur(car.TireLFAcSpeed) < CCur(acSpeedMinValue) Then
			'            tmpStr = tmpStr & ";加速度" & car.TireLFAcSpeed & "g(偏低)"
			'        ElseIf CCur(car.TireLFAcSpeed) > CCur(acSpeedMaxValue) Then
			'            tmpStr = tmpStr & ";加速度" & car.TireLFAcSpeed & "g(偏高)"
			'        End If
			'        '判断电池电量
			'        If car.TireLFBattery <> "OK" Then
			'            tmpStr = tmpStr & ";电池电量低"
			'        End If
		Else
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl2").ForeColor = &HFF
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl2").Caption = DataReport1.Sections("Section1").Controls("lbl2").Caption & "检测失败"
		End If
		If tmpStr <> "" Then
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl2").Caption = DataReport1.Sections("Section1").Controls("lbl2").Caption & tmpStr
			tmpStr = ""
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("labResult").Caption = "NG"
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("labResult").ForeColor = &HFF
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl2").ForeColor = &HFF
		End If
		
		
		If Mid(resultState, 3, 1) = "1" Then
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl4").Caption = DataReport1.Sections("Section1").Controls("lbl4").Caption & car.TireRRID
			'        '判断模式
			'        If judgeMdlIsOK(car.TireRRMdl, mdlArr) = False Then
			'            tmpStr = ";模式" & car.TireRRMdl & "(不合格)"
			'        End If
			
			'判断压力值是否合格
			If CDec(car.TireRRPre) < CDec(preMinValue) Then
				tmpStr = ";压力" & car.TireRRPre & "kPa(偏低)"
			ElseIf CDec(car.TireRRPre) > CDec(preMaxValue) Then 
				tmpStr = ";压力" & car.TireRRPre & "kPa(偏高)"
			End If
			'        '判断温度值是否合格
			'        If CCur(car.TireRRTemp) < CCur(tempMinValue) Then
			'            tmpStr = tmpStr & ";温度" & car.TireRRTemp & "℃(偏低)"
			'        ElseIf CCur(car.TireRRTemp) > CCur(tempMaxValue) Then
			'            tmpStr = tmpStr & ";温度" & car.TireRRTemp & "℃(偏高)"
			'        End If
			'        '判断加速度是否合格
			'        If CCur(car.TireRRAcSpeed) < CCur(acSpeedMinValue) Then
			'            tmpStr = tmpStr & ";加速度" & car.TireRRAcSpeed & "g(偏低)"
			'        ElseIf CCur(car.TireRRAcSpeed) > CCur(acSpeedMaxValue) Then
			'            tmpStr = tmpStr & ";加速度" & car.TireRRAcSpeed & "g(偏高)"
			'        End If
			'        '判断电池电量
			'        If car.TireRRBattery <> "OK" Then
			'            tmpStr = tmpStr & ";电池电量低"
			'        End If
		Else
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl4").ForeColor = &HFF
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl4").Caption = DataReport1.Sections("Section1").Controls("lbl4").Caption & "检测失败"
		End If
		If tmpStr <> "" Then
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl4").Caption = DataReport1.Sections("Section1").Controls("lbl4").Caption & tmpStr
			tmpStr = ""
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("labResult").Caption = "NG"
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("labResult").ForeColor = &HFF
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl4").ForeColor = &HFF
		End If
		
		
		
		If Mid(resultState, 4, 1) = "1" Then
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl3").Caption = DataReport1.Sections("Section1").Controls("lbl3").Caption & car.TireLRID
			'        '判断模式
			'        If judgeMdlIsOK(car.TireLRMdl, mdlArr) = False Then
			'            tmpStr = ";模式" & car.TireLRMdl & "(不合格)"
			'        End If
			
			'判断压力值是否合格
			If CDec(car.TireLRPre) < CDec(preMinValue) Then
				tmpStr = ";压力" & car.TireLRPre & "kPa(偏低)"
			ElseIf CDec(car.TireLRPre) > CDec(preMaxValue) Then 
				tmpStr = ";压力" & car.TireLRPre & "kPa(偏高)"
			End If
			'        '判断温度值是否合格
			'        If CCur(car.TireLRTemp) < CCur(tempMinValue) Then
			'            tmpStr = tmpStr & ";温度" & car.TireLRTemp & "℃(偏低)"
			'        ElseIf CCur(car.TireLRTemp) > CCur(tempMaxValue) Then
			'            tmpStr = tmpStr & ";温度" & car.TireLRTemp & "℃(偏高)"
			'        End If
			'        '判断加速度是否合格
			'        If CCur(car.TireLRAcSpeed) < CCur(acSpeedMinValue) Then
			'            tmpStr = tmpStr & ";加速度" & car.TireLRAcSpeed & "g(偏低)"
			'        ElseIf CCur(car.TireLRAcSpeed) > CCur(acSpeedMaxValue) Then
			'            tmpStr = tmpStr & ";加速度" & car.TireLRAcSpeed & "g(偏高)"
			'        End If
			'        '判断电池电量
			'        If car.TireLRBattery <> "OK" Then
			'            tmpStr = tmpStr & ";电池电量低"
			'        End If
		Else
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl3").ForeColor = &HFF
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl3").Caption = DataReport1.Sections("Section1").Controls("lbl3").Caption & "检测失败"
		End If
		If tmpStr <> "" Then
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl3").Caption = DataReport1.Sections("Section1").Controls("lbl3").Caption & tmpStr
			tmpStr = ""
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("labResult").Caption = "NG"
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("labResult").ForeColor = &HFF
			'UPGRADE_WARNING: 未能解析对象 DataReport1.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			DataReport1.Sections("Section1").Controls("lbl3").ForeColor = &HFF
		End If
		
		
		'UPGRADE_WARNING: 未能解析对象 DataReport1.PrintReport 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		DataReport1.PrintReport()
		'UPGRADE_ISSUE: 卸载 DataReport1 未升级。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="875EBAD7-D704-4539-9969-BC7DBDAA62A2"”
		Unload(DataReport1)
		Exit Sub
printError: 
		LogWritter("打印错误，错误信息：" & Err.Description)
	End Sub
	
	Public Sub printErrCode()
		Dim WriteInErrorCode As Object
		On Error Resume Next
		
		'DoEvents
		
		Dim tmpStr As String
		Dim rsDB As New ADODB.Recordset
		rsDB.Fields.Append("name", ADODB.DataTypeEnum.adBSTR)
		rsDB.Open()
		rsDB.AddNew()
		rsDB.Fields("name").value = "name"
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.DataSource 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCode.DataSource = rsDB
		
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		Dim isWriteIn As Boolean
		Dim writeInResult As Boolean
		Dim isPrint As Boolean
		Dim errorCodeList() As String
		Dim i As Short
		
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select ""VIN"",""ID020"",""ID022"",""ID021"",""ID023"",""WriteInTime"",""IsWriteIn"",""WriteInResult"",""ErrorCode"",""IsPrint"" from ""T_Result"" where ""IsWriteIn""=true and ""IsPrint""=false order by ""ID"" asc limit 1")
		
		If rs.EOF Then
			rs.Close()
			'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
			rs = Nothing
			cnn.Close()
			'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
			cnn = Nothing
			Exit Sub
		End If
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		isWriteIn = IIf(IsDbNull(rs.Fields("IsWriteIn").Value), False, CBool(rs.Fields("IsWriteIn").Value))
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		writeInResult = IIf(IsDbNull(rs.Fields("WriteInResult").Value), False, CBool(rs.Fields("WriteInResult").Value))
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		isPrint = IIf(IsDbNull(rs.Fields("IsPrint").Value), True, CBool(rs.Fields("IsPrint").Value))
		
		If isWriteIn And Not isPrint Then
			
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCode.Sections("Section1").Controls("lbVIN").Caption = "VIN码：" & rs.Fields("VIN").Value
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCode.Sections("Section1").Controls("lbDateTime").Caption = "日期：" & VB6.Format(rs.Fields("WriteInTime").Value, "yyyy-MM-dd HH:mm:ss")
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCode.Sections("Section1").Controls("lbResult").Caption = "诊断                            " & IIf(writeInResult, "合格", "不合格")
			
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCode.Sections("Section1").Controls("lbLF").Caption = "左前轮：" & rs.Fields("ID022").Value
			If CStr(rs.Fields("ID022").Value) = "00000000" Or CStr(rs.Fields("ID022").Value) = "" Then
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCode.Sections("Section1").Controls("lbLF").ForeColor = &HFF
			End If
			
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCode.Sections("Section1").Controls("lbRF").Caption = "右前轮：" & rs.Fields("ID020").Value
			If CStr(rs.Fields("ID020").Value) = "00000000" Or CStr(rs.Fields("ID020").Value) = "" Then
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCode.Sections("Section1").Controls("lbRF").ForeColor = &HFF
			End If
			
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCode.Sections("Section1").Controls("lbLR").Caption = "左后轮：" & rs.Fields("ID023").Value
			If CStr(rs.Fields("ID023").Value) = "00000000" Or CStr(rs.Fields("ID023").Value) = "" Then
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCode.Sections("Section1").Controls("lbLR").ForeColor = &HFF
			End If
			
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCode.Sections("Section1").Controls("lbRR").Caption = "右后轮：" & rs.Fields("ID021").Value
			If CStr(rs.Fields("ID021").Value) = "00000000" Or CStr(rs.Fields("ID021").Value) = "" Then
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCode.Sections("Section1").Controls("lbRR").ForeColor = &HFF
			End If
			
			If Not writeInResult Then
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCode.Sections("Section1").Controls("lbResult").ForeColor = &HFF
			End If
			
			errorCodeList = Split(CStr(rs.Fields("ErrorCode").Value), ";")
			For i = 0 To UBound(errorCodeList)
				
				If i <> UBound(errorCodeList) Then
					'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					WriteInErrorCode.Sections("Section1").Controls("lbError" & (i + 1)).Caption = errorCodeList(i)
					If Right(errorCodeList(i), 2) = "失败" Or Right(errorCodeList(i), 3) = "不合格" Then
						'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						WriteInErrorCode.Sections("Section1").Controls("lbError" & (i + 1)).ForeColor = &HFF
					End If
				End If
			Next 
			
			cnn.Execute("update ""T_Result"" set ""IsPrint""=true where ""VIN""='" & rs.Fields("VIN").Value & "'")
			
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCode.PrintReport 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCode.PrintReport()
			'UPGRADE_ISSUE: 卸载 WriteInErrorCode 未升级。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="875EBAD7-D704-4539-9969-BC7DBDAA62A2"”
			Unload(WriteInErrorCode)
		Else
			
		End If
		rs.Close()
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
	
	Public Sub printErrCodeAuto()
		Dim WriteInErrorCodeAuto As Object
		On Error Resume Next
		
		'DoEvents
		
		Dim tmpStr As String
		Dim rsDB As New ADODB.Recordset
		rsDB.Fields.Append("name", ADODB.DataTypeEnum.adBSTR)
		rsDB.Open()
		rsDB.AddNew()
		rsDB.Fields("name").value = "name"
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.DataSource 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCodeAuto.DataSource = rsDB
		
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		Dim isWriteIn As Boolean
		Dim writeInResult As Boolean
		Dim isPrint As Boolean
		Dim errorCodeList() As String
		Dim rowArr() As String
		Dim i As Short
		Dim tmpIndex As Short
		Dim maxID As Short
		Dim tmp As Short
		
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select max(""ID"") as ""ID"" from ""T_Result"" where ""IsPrint""=true")
		If Not rs.EOF Then
			maxID = CShort(rs.Fields("ID").Value)
		Else
			maxID = 0
		End If
		
		If isOnlyPrintNGWriteResult Then
			rs = cnn.Execute("select ""VIN"",""ID020"",""ID022"",""ID021"",""ID023"",""WriteInTime"",""IsWriteIn"",""WriteInResult"",""ErrorCode"",""IsPrint"",""MTOC"" from ""T_Result"" where ""IsWriteIn""=true and ""WriteInResult""=false and ""IsPrint""=false and ""ID"">" & maxID & " order by ""ID"" asc limit 1")
		Else
			rs = cnn.Execute("select ""VIN"",""ID020"",""ID022"",""ID021"",""ID023"",""WriteInTime"",""IsWriteIn"",""WriteInResult"",""ErrorCode"",""IsPrint"",""MTOC"" from ""T_Result"" where ""IsWriteIn""=true and ""IsPrint""=false and ""ID"">" & maxID & " order by ""ID"" asc limit 1")
		End If
		
		If rs.EOF Then
			rs.Close()
			'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
			rs = Nothing
			cnn.Close()
			'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
			cnn = Nothing
			Exit Sub
		End If
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		isWriteIn = IIf(IsDbNull(rs.Fields("IsWriteIn").Value), False, CBool(rs.Fields("IsWriteIn").Value))
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		writeInResult = IIf(IsDbNull(rs.Fields("WriteInResult").Value), False, CBool(rs.Fields("WriteInResult").Value))
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		isPrint = IIf(IsDbNull(rs.Fields("IsPrint").Value), True, CBool(rs.Fields("IsPrint").Value))
		
		If isWriteIn And Not isPrint Then
			
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbVIN").Caption = "车辆代码：" & rs.Fields("VIN").Value
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lblMTOC").Caption = "MTOC码：" & rs.Fields("MTOC").Value
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbDateTime").Caption = "日期：" & VB6.Format(rs.Fields("WriteInTime").Value, "yyyy-MM-dd HH:mm:ss")
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult").Caption = "诊断                            " & IIf(writeInResult, "合格", "不合格")
			
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbLF").Caption = "左前轮：" & rs.Fields("ID022").Value
			If CStr(rs.Fields("ID022").Value) = "00000000" Or CStr(rs.Fields("ID022").Value) = "" Then
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCodeAuto.Sections("Section1").Controls("lbLF").ForeColor = &HFF
			End If
			
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbRF").Caption = "右前轮：" & rs.Fields("ID020").Value
			If CStr(rs.Fields("ID020").Value) = "00000000" Or CStr(rs.Fields("ID020").Value) = "" Then
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCodeAuto.Sections("Section1").Controls("lbRF").ForeColor = &HFF
			End If
			
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbLR").Caption = "左后轮：" & rs.Fields("ID023").Value
			If CStr(rs.Fields("ID023").Value) = "00000000" Or CStr(rs.Fields("ID023").Value) = "" Then
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCodeAuto.Sections("Section1").Controls("lbLR").ForeColor = &HFF
			End If
			
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbRR").Caption = "右后轮：" & rs.Fields("ID021").Value
			If CStr(rs.Fields("ID021").Value) = "00000000" Or CStr(rs.Fields("ID021").Value) = "" Then
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCodeAuto.Sections("Section1").Controls("lbRR").ForeColor = &HFF
			End If
			
			If Not writeInResult Then
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult").ForeColor = &HFF
			End If
			
			If CStr(rs.Fields("ErrorCode").Value & "") = "" Then
				errorCodeList = Split(CStr(rs.Fields("ErrorCode").Value & "&S"), "&S")
			Else
				errorCodeList = Split(CStr(rs.Fields("ErrorCode").Value), "&S")
			End If
			
			'WriteInErrorCodeAuto.Sections("Section1").Visible = False
			'WriteInErrorCodeAuto.Sections("Section1").Height = 3000
			'DataReport1.Sections("Section1").Controls("Text1").CanGrow = True '自动换行
			
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (1)).Caption = ""
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (1)).Caption = ""
			
			i = 0
			If UBound(errorCodeList) > -1 Then
				For i = 0 To UBound(errorCodeList)
					
					If i <> UBound(errorCodeList) Then
						If Left(errorCodeList(i), 2) = "&P" Then
							rowArr = Split(CStr(errorCodeList(i)), "&C")
							rowArr(0) = Replace(rowArr(0), "&P", (i + 1) & " ") '序号
							If rowArr(1) = "失败" Or rowArr(1) = "不合格" Then
								tmpIndex = tmpIndex + 1
								If isOnlyPrintNGFlow Then
									tmp = tmpIndex
								Else
									tmp = i + 1
								End If
								'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
								WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (tmp)).ForeColor = &HFF
								'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
								WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (tmp)).ForeColor = &HFF
							End If
							If Len(rowArr(0)) > 32 Then
								rowArr(0) = Mid(rowArr(0), 1, 32)
							End If
							If isOnlyPrintNGFlow Then
								If rowArr(1) = "成功" Then
									
								Else
									'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
									WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (tmpIndex)).Caption = rowArr(0)
									'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
									WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (tmpIndex)).Caption = rowArr(1)
								End If
							Else
								'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
								WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (i + 1)).Caption = rowArr(0)
								'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
								WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (i + 1)).Caption = rowArr(1)
							End If
						Else
							tmpIndex = tmpIndex + 1
							errorCodeList(i) = "  " & errorCodeList(i)
							If isOnlyPrintNGFlow Then
								tmp = tmpIndex
							Else
								tmp = i + 1
							End If
							'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
							WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (tmp)).ForeColor = &HFF
							'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
							WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (tmp)).Top = 15
							'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
							WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (tmp)).Visible = False
							If Len(errorCodeList(i)) > 32 Then
								'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
								WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (tmp)).Width = 4050
							End If
							If Len(errorCodeList(i)) > 36 Then
								errorCodeList(i) = Mid(errorCodeList(i), 1, 36)
							End If
							'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
							WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (tmp)).Caption = errorCodeList(i)
						End If
					End If
				Next 
				
				If isOnlyPrintNGFlow Then
					i = tmpIndex
				Else
					i = UBound(errorCodeList)
				End If
			End If
			
			For i = i To 31
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (i + 1)).Top = 15
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (i + 1)).Visible = False
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (i + 1)).Top = 15
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (i + 1)).Visible = False
			Next i
			
			If isOnlyPrintNGFlow Then
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCodeAuto.Sections("Section1").Controls("lbErrorEnd").Top = 3000 + tmpIndex * 330
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCodeAuto.Sections("Section1").Height = 3300 + tmpIndex * 330
			Else
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCodeAuto.Sections("Section1").Controls("lbErrorEnd").Top = 3000 + UBound(errorCodeList) * 330
				'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				WriteInErrorCodeAuto.Sections("Section1").Height = 3300 + UBound(errorCodeList) * 330
			End If
			
			cnn.Execute("update ""T_Result"" set ""IsPrint""=true where ""VIN""='" & rs.Fields("VIN").Value & "'")
			
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.PrintReport 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.PrintReport()
			'UPGRADE_ISSUE: 卸载 WriteInErrorCodeAuto 未升级。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="875EBAD7-D704-4539-9969-BC7DBDAA62A2"”
			Unload(WriteInErrorCodeAuto)
		Else
			
		End If
		rs.Close()
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
	'根据VIN条码打印诊结果
	Public Sub printErrCodeByVIN(ByRef vin As String)
		Dim WriteInErrorCodeAuto As Object
		On Error Resume Next
		
		'DoEvents
		
		Dim tmpStr As String
		Dim rsDB As New ADODB.Recordset
		rsDB.Fields.Append("name", ADODB.DataTypeEnum.adBSTR)
		rsDB.Open()
		rsDB.AddNew()
		rsDB.Fields("name").value = "name"
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.DataSource 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCodeAuto.DataSource = rsDB
		
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		Dim isWriteIn As Boolean
		Dim writeInResult As Boolean
		Dim isPrint As Boolean
		Dim errorCodeList() As String
		Dim rowArr() As String
		Dim i As Short
		Dim tmpIndex As Short
		Dim maxID As Short
		Dim tmp As Short
		
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select ""VIN"",""ID020"",""ID022"",""ID021"",""ID023"",""WriteInTime"",""ErrorCode"",""MTOC"",""WriteInResult"" from ""T_Result"" where ""VIN""='" & vin & "'")
		
		If rs.EOF Then
			rs.Close()
			'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
			rs = Nothing
			cnn.Close()
			'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
			cnn = Nothing
			Exit Sub
		End If
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		writeInResult = IIf(IsDbNull(rs.Fields("WriteInResult").Value), False, CBool(rs.Fields("WriteInResult").Value))
		
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCodeAuto.Sections("Section1").Controls("lbVIN").Caption = "VIN码：" & rs.Fields("VIN").Value
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCodeAuto.Sections("Section1").Controls("lblMTOC").Caption = "MTOC码：" & rs.Fields("MTOC").Value
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCodeAuto.Sections("Section1").Controls("lbDateTime").Caption = "日期：" & VB6.Format(rs.Fields("WriteInTime").Value, "yyyy-MM-dd HH:mm:ss")
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult").Caption = "诊断                            " & IIf(writeInResult, "合格", "不合格")
		
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCodeAuto.Sections("Section1").Controls("lbLF").Caption = "左前轮：" & rs.Fields("ID022").Value
		If CStr(rs.Fields("ID022").Value) = "00000000" Or CStr(rs.Fields("ID022").Value) = "" Then
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbLF").ForeColor = &HFF
		End If
		
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCodeAuto.Sections("Section1").Controls("lbRF").Caption = "右前轮：" & rs.Fields("ID020").Value
		If CStr(rs.Fields("ID020").Value) = "00000000" Or CStr(rs.Fields("ID020").Value) = "" Then
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbRF").ForeColor = &HFF
		End If
		
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCodeAuto.Sections("Section1").Controls("lbLR").Caption = "左后轮：" & rs.Fields("ID023").Value
		If CStr(rs.Fields("ID023").Value) = "00000000" Or CStr(rs.Fields("ID023").Value) = "" Then
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbLR").ForeColor = &HFF
		End If
		
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCodeAuto.Sections("Section1").Controls("lbRR").Caption = "右后轮：" & rs.Fields("ID021").Value
		If CStr(rs.Fields("ID021").Value) = "00000000" Or CStr(rs.Fields("ID021").Value) = "" Then
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbRR").ForeColor = &HFF
		End If
		
		If Not writeInResult Then
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult").ForeColor = &HFF
		End If
		
		If CStr(rs.Fields("ErrorCode").Value & "") = "" Then
			errorCodeList = Split(CStr(rs.Fields("ErrorCode").Value & "&S"), "&S")
		Else
			errorCodeList = Split(CStr(rs.Fields("ErrorCode").Value), "&S")
		End If
		
		
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (1)).Caption = ""
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (1)).Caption = ""
		
		i = 0
		If UBound(errorCodeList) > -1 Then
			For i = 0 To UBound(errorCodeList)
				
				If i <> UBound(errorCodeList) Then
					If Left(errorCodeList(i), 2) = "&P" Then
						rowArr = Split(CStr(errorCodeList(i)), "&C")
						rowArr(0) = Replace(rowArr(0), "&P", (i + 1) & " ") '序号
						If rowArr(1) = "失败" Or rowArr(1) = "不合格" Then
							tmpIndex = tmpIndex + 1
							If isOnlyPrintNGFlow Then
								tmp = tmpIndex
							Else
								tmp = i + 1
							End If
							'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
							WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (tmp)).ForeColor = &HFF
							'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
							WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (tmp)).ForeColor = &HFF
						End If
						If Len(rowArr(0)) > 32 Then
							rowArr(0) = Mid(rowArr(0), 1, 32)
						End If
						If isOnlyPrintNGFlow Then
							If rowArr(1) = "成功" Then
								
							Else
								'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
								WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (tmpIndex)).Caption = rowArr(0)
								'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
								WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (tmpIndex)).Caption = rowArr(1)
							End If
						Else
							'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
							WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (i + 1)).Caption = rowArr(0)
							'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
							WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (i + 1)).Caption = rowArr(1)
						End If
					Else
						tmpIndex = tmpIndex + 1
						errorCodeList(i) = "  " & errorCodeList(i)
						If isOnlyPrintNGFlow Then
							tmp = tmpIndex
						Else
							tmp = i + 1
						End If
						'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (tmp)).ForeColor = &HFF
						'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (tmp)).Top = 15
						'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (tmp)).Visible = False
						If Len(errorCodeList(i)) > 32 Then
							'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
							WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (tmp)).Width = 4050
						End If
						If Len(errorCodeList(i)) > 36 Then
							errorCodeList(i) = Mid(errorCodeList(i), 1, 36)
						End If
						'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
						WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (tmp)).Caption = errorCodeList(i)
					End If
				End If
			Next 
			
			If isOnlyPrintNGFlow Then
				i = tmpIndex
			Else
				i = UBound(errorCodeList)
			End If
		End If
		For i = i To 31
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (i + 1)).Top = 15
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbError" & (i + 1)).Visible = False
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (i + 1)).Top = 15
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbResult" & (i + 1)).Visible = False
		Next i
		
		If isOnlyPrintNGFlow Then
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbErrorEnd").Top = 3000 + tmpIndex * 330
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Height = 3300 + tmpIndex * 330
		Else
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Controls("lbErrorEnd").Top = 3000 + UBound(errorCodeList) * 330
			'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.Sections 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			WriteInErrorCodeAuto.Sections("Section1").Height = 3300 + UBound(errorCodeList) * 330
		End If
		
		'UPGRADE_WARNING: 未能解析对象 WriteInErrorCodeAuto.PrintReport 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		WriteInErrorCodeAuto.PrintReport()
		'UPGRADE_ISSUE: 卸载 WriteInErrorCodeAuto 未升级。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="875EBAD7-D704-4539-9969-BC7DBDAA62A2"”
		Unload(WriteInErrorCodeAuto)
		
		LogWritter("手动打印" & vin & "的诊断结果信息成功！")
		
		rs.Close()
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
	
	'******************************************************************************
	'** 函 数 名：closeAll
	'** 输    入：
	'** 输    出：
	'** 功能描述：关闭灯柱的所有连线，任何灯柱操作都需要先调用该方法
	'** 全局变量：
	'** 作    者：yangshuai
	'** 邮    箱：shuaigoplay@live.cn
	'** 日    期：2009-2-27
	'** 修 改 者：
	'** 日    期：
	'** 版    本：1.0
	'******************************************************************************
	Public Sub closeAll()
		'oIOCard.OutputController Lamp_Buzzer_IOPort, False '关闭蜂鸣
		oIOCard.OutputController(Lamp_GreenLight_IOPort, False) '关闭绿色
		oIOCard.OutputController(Lamp_GreenFlash_IOPort, False) '关闭绿色闪烁
		oIOCard.OutputController(Lamp_YellowLight_IOPort, False) '关闭黄色
		oIOCard.OutputController(Lamp_YellowFlash_IOPort, False) '关闭黄色闪烁
		oIOCard.OutputController(Lamp_RedLight_IOPort, False) '关闭红色
		oIOCard.OutputController(Lamp_RedFlash_IOPort, False) '关闭红色闪烁
	End Sub
	
	Public Sub openLamp(ByRef IOPort As Short)
		Call closeAll()
		oIOCard.OutputController(IOPort, True)
	End Sub
	Public Sub flashLamp(ByRef IOPort As Short)
		Call closeAll()
		oIOCard.OutputController(IOPort, True)
	End Sub
	
	Public Sub flashBuzzerLamp(ByRef IOPort As Short)
		Call closeAll()
		oIOCard.OutputController(Lamp_Buzzer_IOPort, True)
		oIOCard.OutputController(IOPort, True)
	End Sub
	
	Public Sub DelayTime(ByRef LngTime As Integer)
		On Error Resume Next
		Dim LngTick As Integer
		LngTick = GetTickCount()
		Do 
			System.Windows.Forms.Application.DoEvents() : System.Windows.Forms.Application.DoEvents()
		Loop Until (GetTickCount() - LngTick) >= LngTime
	End Sub
	
	
	Function DToB(ByRef v As Short) As String
		If v > 15 Then
			DToB = ""
			Exit Function
		End If
		Select Case v
			Case 0
				DToB = "0000"
			Case 1
				DToB = "0001"
			Case 2
				DToB = "0010"
			Case 3
				DToB = "0011"
			Case 4
				DToB = "0100"
			Case 5
				DToB = "0101"
			Case 6
				DToB = "0110"
			Case 7
				DToB = "0111"
			Case 8
				DToB = "1000"
			Case 9
				DToB = "1001"
			Case 10
				DToB = "1010"
			Case 11
				DToB = "1011"
			Case 12
				DToB = "1100"
			Case 13
				DToB = "1101"
			Case 14
				DToB = "1110"
			Case 15
				DToB = "1111"
		End Select
	End Function
	
	
	Public Sub updateState(ByRef key As String, ByRef value As String)
		On Error Resume Next
		Dim cnn As New ADODB.Connection
		cnn.Open(DBCnnStr)
		cnn.Execute("update runstate set " & key & "='" & value & "'")
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
	
	Public Function readState(ByRef key As String) As String
		On Error Resume Next
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select * from runstate")
		readState = rs.Fields(key).Value
		rs.Close()
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Function
	
	Public Sub resetState()
		On Error Resume Next
		Dim cnn As New ADODB.Connection
		cnn.Open(DBCnnStr)
		cnn.Execute("UPDATE runstate SET  test='False', dsgrf=null, dsglf=null, dsgrr=null, dsglr=null,mdlrf=null, mdllf=null, mdlrr=null, mdllr=null,prerf=null, prelf=null, prerr=null, prelr=null,temprf=null, templf=null, temprr=null, templr=null,batteryrf=null, batterylf=null, batteryrr=null, batterylr=null,acspeedrf=null, acspeedlf=null, acspeedrr=null, acspeedlr=null, state=9999")
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
	Public Sub insertColl(ByRef code As String)
		On Error Resume Next
		Dim tmpLen, tmpStartIndex, tmpLetter As Object
		Dim tmpResult As Short '定义判断车型的起始位置和长度,和匹配的字母
		Dim rs As ADODB.Recordset
		Dim tmpIfTPMS, tmpCarType, tmpOne As String 'VIN中需要匹配的那位数
		Dim cnn As New ADODB.Connection
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select ""CodeStartIndex"",""CodeLen"",""MatchLetter"",""CarType"",""ifTPMS"" from cartype_tpms")
		Do While Not rs.EOF
			'UPGRADE_WARNING: 未能解析对象 tmpStartIndex 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			tmpStartIndex = CShort(rs.Fields("CodeStartIndex").Value)
			'UPGRADE_WARNING: 未能解析对象 tmpLen 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			tmpLen = CShort(rs.Fields("CodeLen").Value)
			'UPGRADE_WARNING: 未能解析对象 tmpLetter 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			tmpLetter = rs.Fields("MatchLetter").Value
			'UPGRADE_WARNING: 未能解析对象 tmpLen 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			'UPGRADE_WARNING: 未能解析对象 tmpStartIndex 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			tmpOne = Mid(code, tmpStartIndex, tmpLen)
			'UPGRADE_WARNING: 未能解析对象 tmpLetter 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			If tmpOne = tmpLetter Then '如果配置的车型找的到，则停止继续
				tmpResult = 1
				tmpCarType = rs.Fields("CarType").value
				tmpIfTPMS = rs.Fields("ifTPMS").value
				Call insertCarTypeTpms(code, tmpCarType, tmpIfTPMS)
				Exit Do
			End If
			rs.MoveNext()
		Loop 
		If Not tmpResult = 1 Then '没有匹配的车型
			tmpResult = 0
			tmpCarType = "no"
			tmpIfTPMS = CStr(0)
			Call insertCarTypeTpms(code, tmpCarType, tmpIfTPMS)
		End If
		
		If Not rs Is Nothing Then
			If rs.state = 1 Then
				rs.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		
		If Not cnn Is Nothing Then
			If cnn.state = 1 Then
				cnn.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
	Public Function insertCarTypeTpms(ByRef vin As String, ByRef CarType As String, ByRef ifTPMS As String) As Object '插入车型，胎压信息
		On Error Resume Next
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select ""vin"" from vincoll where ""vin"" = " & vin & "")
		If Not rs.EOF Then
			cnn.Execute("insert into ""vincoll"" (""vin"",""tpms"",""cartype"") values ('" & vin & "','" & ifTPMS & "','" & CarType & "')")
		Else
			cnn.Execute("update vincoll set ""cartype""='" & CarType & "',""tpms"" ='" & ifTPMS & "' where ""vin"" = '" & vin & "'")
		End If
		
		If Not rs Is Nothing Then
			If rs.state = 1 Then
				rs.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		
		If Not cnn Is Nothing Then
			If cnn.state = 1 Then
				cnn.Close()
			End If
		End If
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Function
	
	
	Public Sub delColl(ByRef vin As String)
		On Error Resume Next
		Dim cnn As New ADODB.Connection
		cnn.Open(DBCnnStr)
		cnn.Execute("delete from vincoll where vin like '%" & vin & "%'")
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
	Public Sub delallColl()
		On Error Resume Next
		Dim cnn As New ADODB.Connection
		cnn.Open(DBCnnStr)
		cnn.Execute("delete from vincoll")
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
	Public Function getRunStateCar() As CCar
		On Error Resume Next
		Dim cnn As New ADODB.Connection
		Dim rs As ADODB.Recordset
		getRunStateCar = New CCar
		cnn.Open(DBCnnStr)
		rs = cnn.Execute("select * from runstate")
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.VINCode = IIf(IsDbNull(rs.Fields("vin").Value), "", rs.Fields("vin").Value)
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRFID = IIf(IsDbNull(rs.Fields("dsgrf").Value), "", rs.Fields("dsgrf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRFMdl = IIf(IsDbNull(rs.Fields("mdlrf").Value), "", rs.Fields("mdlrf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRFPre = IIf(IsDbNull(rs.Fields("prerf").Value), "", rs.Fields("prerf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRFTemp = IIf(IsDbNull(rs.Fields("temprf").Value), "", rs.Fields("temprf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRFBattery = IIf(IsDbNull(rs.Fields("batteryrf").Value), "", rs.Fields("batteryrf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRFAcSpeed = IIf(IsDbNull(rs.Fields("acspeedrf").Value), "", rs.Fields("acspeedrf").Value)
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireLFID = IIf(IsDbNull(rs.Fields("dsglf").Value), "", rs.Fields("dsglf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireLFMdl = IIf(IsDbNull(rs.Fields("mdllf").Value), "", rs.Fields("mdllf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireLFPre = IIf(IsDbNull(rs.Fields("prelf").Value), "", rs.Fields("prelf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireLFTemp = IIf(IsDbNull(rs.Fields("templf").Value), "", rs.Fields("templf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireLFBattery = IIf(IsDbNull(rs.Fields("batterylf").Value), "", rs.Fields("batterylf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireLFAcSpeed = IIf(IsDbNull(rs.Fields("acspeedlf").Value), "", rs.Fields("acspeedlf").Value)
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRRID = IIf(IsDbNull(rs.Fields("dsgrr").Value), "", rs.Fields("dsgrr").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRRMdl = IIf(IsDbNull(rs.Fields("mdlrr").Value), "", rs.Fields("mdlrr").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRRPre = IIf(IsDbNull(rs.Fields("preRR").Value), "", rs.Fields("preRR").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRRTemp = IIf(IsDbNull(rs.Fields("temprr").Value), "", rs.Fields("temprr").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRRBattery = IIf(IsDbNull(rs.Fields("batteryrr").Value), "", rs.Fields("batteryrr").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRRAcSpeed = IIf(IsDbNull(rs.Fields("acspeedrr").Value), "", rs.Fields("acspeedrr").Value)
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRFID = IIf(IsDbNull(rs.Fields("dsgrf").Value), "", rs.Fields("dsgrf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRFMdl = IIf(IsDbNull(rs.Fields("mdlrf").Value), "", rs.Fields("mdlrf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRFPre = IIf(IsDbNull(rs.Fields("preRF").Value), "", rs.Fields("preRF").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRFTemp = IIf(IsDbNull(rs.Fields("temprf").Value), "", rs.Fields("temprf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRFBattery = IIf(IsDbNull(rs.Fields("batteryrf").Value), "", rs.Fields("batteryrf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.TireRFAcSpeed = IIf(IsDbNull(rs.Fields("acspeedrf").Value), "", rs.Fields("acspeedrf").Value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		getRunStateCar.CarType = IIf(IsDbNull(rs.Fields("cartype").Value), "", rs.Fields("cartype").Value)
		
		rs.Close()
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Function
	
	'判断传感器的压力、温度、加速度值是否符合标准，电池电量状态
	Public Function judgeResultIsOK(ByRef value As String, ByRef min As String, ByRef max As String) As Boolean
		On Error Resume Next
		judgeResultIsOK = False
		If CDec(min) <= CDec(value) And CDec(max) >= CDec(value) Then
			judgeResultIsOK = True
		End If
	End Function
	'判断传感器模式是否合格
	Public Function judgeMdlIsOK(ByRef mdl As String, ByRef mdlValueArr() As String) As Boolean
		Dim index As Short
		judgeMdlIsOK = False
		For index = 0 To UBound(mdlValueArr)
			If mdl = mdlValueArr(index) Then
				judgeMdlIsOK = True
				Exit Function
			End If
		Next index
	End Function
	
	'关闭指定名称的进程
	Public Sub KillProcess(ByRef sProcess As String)
		Dim lSnapShot As Integer
		Dim lNextProcess As Integer
		Dim tPE As PROCESSENTRY32
		lSnapShot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0)
		Dim lProcess As Integer
		Dim lExitCode As Integer
		If lSnapShot <> -1 Then
			tPE.dwSize = Len(tPE)
			lNextProcess = Process32First(lSnapShot, tPE)
			Do While lNextProcess
				If LCase(sProcess) = LCase(Left(tPE.szExeFile, InStr(1, tPE.szExeFile, Chr(0)) - 1)) Then
					lProcess = OpenProcess(1, False, tPE.th32ProcessID)
					TerminateProcess(lProcess, lExitCode)
					CloseHandle(lProcess)
				End If
				lNextProcess = Process32Next(lSnapShot, tPE)
			Loop 
			CloseHandle((lSnapShot))
		End If
	End Sub
End Module