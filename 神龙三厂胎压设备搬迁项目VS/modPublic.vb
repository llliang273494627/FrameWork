Option Strict Off
Option Explicit On
Imports DSGTest.Common.Helper
Imports DSGTest.Common.SqlServive.Sql_DPCAWH1_DSG101

Module modPublic

    Public DBCnnStr As String '数据库连接字符串全局需要连接数据库的地方全部调用该变量
    Public RDBCnnStr As String

    Public MESCnnStr As String 'MES数据库的连接字符串
    Public MES_IP As String 'MES服务器IP地址

    Public oIOCard As New IOCard 'IO控制对象

    'VT520控制相关参数
    Public oLVT520 As CVT520 'VT520控制对象
    Public oRVT520 As CVT520 'VT520控制对象

    '信号灯相关控制参数（io信号输出端口）
    Public Lamp_GreenFlash_IOPort As Short
    Public Lamp_GreenLight_IOPort As Short
    Public Lamp_YellowLight_IOPort As Short
    Public Lamp_YellowFlash_IOPort As Short
    Public Lamp_RedLight_IOPort As Short
    Public Lamp_RedFlash_IOPort As Short
    Public Lamp_Buzzer_IOPort As Short

    '不同类型的轮胎传感器所对应的控制器程序号
    Public ProNum_OldSensor As Short '普通X7车型(旧传感器)
    Public ProNum_NewSensor As Short 'X7 DSG&MRN 车型(新传感器)
    Public rdOutput As Short

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

    Public Sub Main()
        Try
            FrameWork.Model.Comm.HelperSqlsugar.Init(4, HelperSetting.ConnecString)
            DBCnnStr = "Provider=MSDASQL.1;Persist Security Info=False;Data Source=DPCAWH1_DSG101" 'DSG101ODBC
            RDBCnnStr = HelperMod.getConfigValue("T_RunParam", "DB", "RDBCnnStr")
            TimeOutNum = CShort(HelperMod.getConfigValue("T_RunParam", "DB", "TimeOutNum"))
            MESCnnStr = HelperMod.getConfigValue("T_RunParam", "DB", "MESCnnStr") 'MES系统Oracle数据库连接字符串
            MES_IP = HelperMod.getConfigValue("T_RunParam", "MES", "MESIP") 'MES系统数据库所在服务器IP地址

            '初始化VT520参数
            oLVT520 = New CVT520
            oLVT520.CommPort = CShort(HelperMod.getConfigValue("T_CtrlParam", "LVT520", "LVT520_PortNum"))
            oLVT520.ComSettings = HelperMod.getConfigValue("T_CtrlParam", "LVT520", "LVT520_Settings")
            oLVT520.OpenPort = True

            oRVT520 = New CVT520
            oRVT520.CommPort = CShort(HelperMod.getConfigValue("T_CtrlParam", "RVT520", "RVT520_PortNum"))
            oRVT520.ComSettings = HelperMod.getConfigValue("T_CtrlParam", "RVT520", "RVT520_Settings")
            oRVT520.OpenPort = True

            '读取并初始化对象信号灯控制参数
            Lamp_GreenFlash_IOPort = CShort(HelperMod.getConfigValue("T_CtrlParam", "Lamp", "Lamp_GreenFlash_IOPort"))
            Lamp_GreenLight_IOPort = CShort(HelperMod.getConfigValue("T_CtrlParam", "Lamp", "Lamp_GreenLight_IOPort"))
            Lamp_YellowLight_IOPort = CShort(HelperMod.getConfigValue("T_CtrlParam", "Lamp", "Lamp_YellowLight_IOPort"))
            Lamp_RedLight_IOPort = CShort(HelperMod.getConfigValue("T_CtrlParam", "Lamp", "Lamp_RedLight_IOPort"))
            Lamp_RedFlash_IOPort = CShort(HelperMod.getConfigValue("T_CtrlParam", "Lamp", "Lamp_RedFlash_IOPort"))
            Lamp_Buzzer_IOPort = CShort(HelperMod.getConfigValue("T_CtrlParam", "Lamp", "Lamp_Buzzer_IOPort"))
            Lamp_YellowFlash_IOPort = CShort(HelperMod.getConfigValue("T_CtrlParam", "Lamp", "Lamp_YellowFlash_IOPort"))
            rdOutput = CShort(HelperMod.getConfigValue("T_CtrlParam", "Lamp", "rdOutput"))

            '传感器参数设定
            mdlValue = HelperMod.getConfigValue("T_RunParam", "StandardValue", "MdlValue")
            preMinValue = HelperMod.getConfigValue("T_RunParam", "StandardValue", "PreMinValue")
            preMaxValue = HelperMod.getConfigValue("T_RunParam", "StandardValue", "PreMaxValue")
            tempMinValue = HelperMod.getConfigValue("T_RunParam", "StandardValue", "TempMinValue")
            tempMaxValue = HelperMod.getConfigValue("T_RunParam", "StandardValue", "TempMaxValue")
            acSpeedMinValue = HelperMod.getConfigValue("T_RunParam", "StandardValue", "AcSpeedMinValue")
            acSpeedMaxValue = HelperMod.getConfigValue("T_RunParam", "StandardValue", "AcSpeedMaxValue")
            mTOCStartIndex = HelperMod.getConfigValue("T_RunParam", "TPMSCode", "MTOCStartIndex")
            tPMSCodeLen = HelperMod.getConfigValue("T_RunParam", "TPMSCode", "TPMSCodeLen")

            '不同类型的轮胎传感器所对应的控制器程序号
            ProNum_OldSensor = CShort(HelperMod.getConfigValue("T_CtrlParam", "ProgramNum", "ProNum_OldSensor"))
            ProNum_NewSensor = CShort(HelperMod.getConfigValue("T_CtrlParam", "ProgramNum", "ProNum_NewSensor"))

            isCheckAllQueue = CBool(HelperMod.getConfigValue("T_RunParam", "Queue", "CheckAllQueue"))
            isOnlyScanVINCode = CBool(HelperMod.getConfigValue("T_RunParam", "Queue", "OnlyScanVINCode"))
            isOnlyPrintNGWriteResult = CBool(HelperMod.getConfigValue("T_RunParam", "Print", "OnlyPrintNGWriteResult"))
            isOnlyPrintNGFlow = CBool(HelperMod.getConfigValue("T_RunParam", "Print", "OnlyPrintNGFlow"))
        Catch ex As Exception
            HelperLogger.LogError("初始化参数失败!", ex)
            MessageBox.Show("初始化参数失败，错误信息：" & Err.Description & "。请检查配置信息！")
        End Try
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
        fileName = getExcelFileName() '得到随机文件名
        cnn.Open(DBCnnStr)
        rs = cnn.Execute(sqlText)
        FSO = CreateObject("Scripting.FileSystemObject")

        NowOutputDir = My.Application.Info.DirectoryPath & "\Export"
        'UPGRADE_WARNING: Dir 有新行为。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"”
        If Trim(Dir(NowOutputDir, FileAttribute.Directory)) = "" Then
            FSO.CreateFolder(NowOutputDir)
        End If

        txtfile = FSO.CreateTextFile(fileName, True)

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
                tmp = tmp & rs.Fields(rs.Fields(i).Name).Value & Chr(9)
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
        MyValue = Int((1000 * Rnd()) + 1).ToString("0000") ' 生成 1 到 1000 之间的随机数值。
        getExcelFileName = Date.Now.ToString("yyyyMMddHHmmss") + MyValue + ".xls"
        getExcelFileName = IO.Path.Combine(IO.Directory.GetCurrentDirectory(), "export", getExcelFileName)
    End Function

    '******************************************************************************
    '** 函 数 名：hasDSG
    '** 输    入：
    '** 输    出：
    '** 功能描述：是否装配DSG
    '** 全局变量：
    '** 作    者：yangshuai
    '** 邮    箱：shuaigoplay@live.cn
    '** 日    期：2009-2-27
    '** 修 改 者：
    '** 日    期：
    '** 版    本：1.0
    '******************************************************************************
    Public Function hasDSG(ByRef CarCode As String) As Boolean
        On Error GoTo hasDSG_Err
        Dim tmpV As String
        tmpV = Mid(CarCode, 24, 1) '取第24位值
        'Modiy by ZCJ 20130625 新增了一种传感器
        If tmpV = "D" Or tmpV = "A" Then
            hasDSG = True

            If tmpV = "D" Then
                SetProNum(CStr(ProNum_OldSensor)) '旧传感器
            ElseIf tmpV = "A" Then
                SetProNum(CStr(ProNum_NewSensor)) '新传感器
            End If
        Else
            hasDSG = False
        End If
        Exit Function

hasDSG_Err:
        LogWritter("hasDSG函数内发现错误，错误信息：" & Err.Description)
        hasDSG = False
    End Function

    'Add by ZCJ 2012-10-20 设置左右两边控制器的程序号
    Public Function SetProNum(ByRef ProNum As String) As Object
        On Error GoTo SetProNum_Err
        oRVT520.SendProNum(CShort(ProNum))
        oLVT520.SendProNum(CShort(ProNum))
        LogWritter("将控制器的程序号设置为" & ProNum)

        Exit Function
SetProNum_Err:
        LogWritter("在设置控制器程序号为" & ProNum & "时出错，错误信息：" & Err.Description)
    End Function

    Public Sub printErrResult(ByRef car As CCar)

        Dim frm As New Form2
        Dim CRV As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        CRV.ReportSource = frm.CreateCrystal(car)
        CRV.ExportReport()
        Exit Sub

    End Sub

    Public Sub printErrCodeAuto()
        Dim WriteInErrorCodeAuto As Object
        On Error Resume Next

        Dim tmpStr As String
        Dim rsDB As New ADODB.Recordset
        rsDB.Fields.Append("name", ADODB.DataTypeEnum.adBSTR)
        rsDB.Open()
        rsDB.AddNew()
        rsDB.Fields("name").Value = "name"
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
        isWriteIn = IIf(IsDBNull(rs.Fields("IsWriteIn").Value), False, CBool(rs.Fields("IsWriteIn").Value))
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        writeInResult = IIf(IsDBNull(rs.Fields("WriteInResult").Value), False, CBool(rs.Fields("WriteInResult").Value))
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        isPrint = IIf(IsDBNull(rs.Fields("IsPrint").Value), True, CBool(rs.Fields("IsPrint").Value))

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
            'Unload(WriteInErrorCodeAuto)
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
        rsDB.Fields("name").Value = "name"
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
        writeInResult = IIf(IsDBNull(rs.Fields("WriteInResult").Value), False, CBool(rs.Fields("WriteInResult").Value))

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
        'Unload(WriteInErrorCodeAuto)

        LogWritter("手动打印" & vin & "的诊断结果信息成功！")

        rs.Close()
        'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
        rs = Nothing
        cnn.Close()
        'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
        cnn = Nothing
    End Sub

    Public Sub flashLamp(ByRef IOPort As Short)
        oIOCard.OutputController(Lamp_GreenLight_IOPort, False) '关闭绿色
        oIOCard.OutputController(Lamp_GreenFlash_IOPort, False) '关闭绿色闪烁
        oIOCard.OutputController(Lamp_YellowLight_IOPort, False) '关闭黄色
        oIOCard.OutputController(Lamp_YellowFlash_IOPort, False) '关闭黄色闪烁
        oIOCard.OutputController(Lamp_RedLight_IOPort, False) '关闭红色
        oIOCard.OutputController(Lamp_RedFlash_IOPort, False) '关闭红色闪烁
        oIOCard.OutputController(IOPort, True)
    End Sub

    Public Sub flashBuzzerLamp(ByRef IOPort As Short)
        oIOCard.OutputController(Lamp_GreenLight_IOPort, False) '关闭绿色
        oIOCard.OutputController(Lamp_GreenFlash_IOPort, False) '关闭绿色闪烁
        oIOCard.OutputController(Lamp_YellowLight_IOPort, False) '关闭黄色
        oIOCard.OutputController(Lamp_YellowFlash_IOPort, False) '关闭黄色闪烁
        oIOCard.OutputController(Lamp_RedLight_IOPort, False) '关闭红色
        oIOCard.OutputController(Lamp_RedFlash_IOPort, False) '关闭红色闪烁
        oIOCard.OutputController(Lamp_Buzzer_IOPort, True)
        oIOCard.OutputController(IOPort, True)
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

    Public Function getRunStateCar() As CCar
        On Error Resume Next
        Dim cnn As New ADODB.Connection
        Dim rs As ADODB.Recordset
        getRunStateCar = New CCar
        cnn.Open(DBCnnStr)
        rs = cnn.Execute("select * from runstate")
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.VINCode = IIf(IsDBNull(rs.Fields("vin").Value), "", rs.Fields("vin").Value)

        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRFID = IIf(IsDBNull(rs.Fields("dsgrf").Value), "", rs.Fields("dsgrf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRFMdl = IIf(IsDBNull(rs.Fields("mdlrf").Value), "", rs.Fields("mdlrf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRFPre = IIf(IsDBNull(rs.Fields("prerf").Value), "", rs.Fields("prerf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRFTemp = IIf(IsDBNull(rs.Fields("temprf").Value), "", rs.Fields("temprf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRFBattery = IIf(IsDBNull(rs.Fields("batteryrf").Value), "", rs.Fields("batteryrf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRFAcSpeed = IIf(IsDBNull(rs.Fields("acspeedrf").Value), "", rs.Fields("acspeedrf").Value)

        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireLFID = IIf(IsDBNull(rs.Fields("dsglf").Value), "", rs.Fields("dsglf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireLFMdl = IIf(IsDBNull(rs.Fields("mdllf").Value), "", rs.Fields("mdllf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireLFPre = IIf(IsDBNull(rs.Fields("prelf").Value), "", rs.Fields("prelf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireLFTemp = IIf(IsDBNull(rs.Fields("templf").Value), "", rs.Fields("templf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireLFBattery = IIf(IsDBNull(rs.Fields("batterylf").Value), "", rs.Fields("batterylf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireLFAcSpeed = IIf(IsDBNull(rs.Fields("acspeedlf").Value), "", rs.Fields("acspeedlf").Value)

        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRRID = IIf(IsDBNull(rs.Fields("dsgrr").Value), "", rs.Fields("dsgrr").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRRMdl = IIf(IsDBNull(rs.Fields("mdlrr").Value), "", rs.Fields("mdlrr").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRRPre = IIf(IsDBNull(rs.Fields("preRR").Value), "", rs.Fields("preRR").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRRTemp = IIf(IsDBNull(rs.Fields("temprr").Value), "", rs.Fields("temprr").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRRBattery = IIf(IsDBNull(rs.Fields("batteryrr").Value), "", rs.Fields("batteryrr").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRRAcSpeed = IIf(IsDBNull(rs.Fields("acspeedrr").Value), "", rs.Fields("acspeedrr").Value)

        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRFID = IIf(IsDBNull(rs.Fields("dsgrf").Value), "", rs.Fields("dsgrf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRFMdl = IIf(IsDBNull(rs.Fields("mdlrf").Value), "", rs.Fields("mdlrf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRFPre = IIf(IsDBNull(rs.Fields("preRF").Value), "", rs.Fields("preRF").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRFTemp = IIf(IsDBNull(rs.Fields("temprf").Value), "", rs.Fields("temprf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRFBattery = IIf(IsDBNull(rs.Fields("batteryrf").Value), "", rs.Fields("batteryrf").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        getRunStateCar.TireRFAcSpeed = IIf(IsDBNull(rs.Fields("acspeedrf").Value), "", rs.Fields("acspeedrf").Value)

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

End Module