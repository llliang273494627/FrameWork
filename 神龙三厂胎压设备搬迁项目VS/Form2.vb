Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim vin As String = TextBox1.Text.Trim()
        DBCnnStr = "Provider=MSDASQL.1;Persist Security Info=False;Data Source=DPCAWH1_DSG101" 'DSG101ODBC
        CrystalReportViewer1.ReportSource() = CreateCrystal(vin)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CrystalReportViewer1.ExportReport()
    End Sub

    '编辑水晶报表
    Private Function CreateCrystal(ByRef vin As String) As CrystalReport1
        Dim WriteInErrorCodeAuto As New CrystalReport1
        Dim cot As CrystalDecisions.CrystalReports.Engine.TextObject

        Dim cnn As New ADODB.Connection
        Dim rs As ADODB.Recordset
        Dim writeInResult As Boolean

        cnn.Open(DBCnnStr)
        rs = cnn.Execute("select ""VIN"",""ID020"",""ID022"",""ID021"",""ID023"",""WriteInTime"",""ErrorCode"",""MTOC"",""WriteInResult"" from ""T_Result"" where ""VIN""='" & vin & "'")

        If rs.EOF Then
            rs.Close()
            rs = Nothing
            cnn.Close()
            cnn = Nothing
            CreateCrystal = WriteInErrorCodeAuto
            Exit Function
        End If
        If IsDBNull(rs.Fields("WriteInResult").Value) Then
            writeInResult = False
        Else
            writeInResult = CBool(rs.Fields("WriteInResult").Value)
        End If

        '给水晶报表赋值
        cot = WriteInErrorCodeAuto.Section1().ReportObjects().Item("lblVIN")
        cot.Text = "VIN码：" & rs.Fields("VIN").Value
        cot = WriteInErrorCodeAuto.Section1().ReportObjects().Item("lblDate")
        cot.Text = "日期：" & VB6.Format(rs.Fields("WriteInTime").Value, "yyyy-MM-dd HH:mm:ss")
        cot = WriteInErrorCodeAuto.Section1().ReportObjects().Item("labResult")
        cot.Text = "诊断：" & IIf(writeInResult, "合格", "不合格")
        If Not writeInResult Then
            cot.Color() = Color.Red
        End If

        cot = WriteInErrorCodeAuto.Section1().ReportObjects().Item("lbl1")
        cot.Text = "右前轮：" & rs.Fields("ID020").Value
        If String.IsNullOrEmpty(rs.Fields("ID020").Value) Or rs.Fields("ID020").Value = "00000000" Then
            cot.Color() = Color.Red
        End If
        cot = WriteInErrorCodeAuto.Section1().ReportObjects().Item("lbl2")
        cot.Text = "左前轮：" & rs.Fields("ID022").Value
        If String.IsNullOrEmpty(rs.Fields("ID022").Value) Or rs.Fields("ID022").Value = "00000000" Then
            cot.Color() = Color.Red
        End If
        cot = WriteInErrorCodeAuto.Section1().ReportObjects().Item("lbl3")
        cot.Text = "右后轮：" & rs.Fields("ID021").Value
        If String.IsNullOrEmpty(rs.Fields("ID021").Value) Or rs.Fields("ID021").Value = "00000000" Then
            cot.Color() = Color.Red
        End If
        cot = WriteInErrorCodeAuto.Section1().ReportObjects().Item("lbl4")
        cot.Text = "左后轮：" & rs.Fields("ID023").Value
        If String.IsNullOrEmpty(rs.Fields("ID023").Value) Or rs.Fields("ID023").Value = "00000000" Then
            cot.Color() = Color.Red
        End If

        rs.Close()
        rs = Nothing
        cnn.Close()
        cnn = Nothing
        CreateCrystal = WriteInErrorCodeAuto
    End Function

    Public Function CreateCrystal(ByRef car As CCar) As CrystalReport1

        Dim DataReport1 As New CrystalReport1
        Dim cot As CrystalDecisions.CrystalReports.Engine.TextObject

        Dim tmpStr As String
        Dim rs As New ADODB.Recordset
        Dim mdlArr() As String

        cot = DataReport1.Section1().ReportObjects().Item("lblVIN")
        cot.Text += car.VINCode
        cot = DataReport1.Section1().ReportObjects().Item("lbldate")
        cot.Text += Date.Now.ToString()
        cot = DataReport1.Section1().ReportObjects().Item("labResult")
        If CDbl(car.GetTestState) = 15 Then
            cot.Text = "OK"
        Else
            cot.Text = "NG"
            cot.Color() = Color.Red
        End If

        Dim resultState As String = DToB(CShort(car.GetTestState))

        mdlArr = Split(mdlValue, ",")
        If Mid(resultState, 1, 1) = "1" Then
            cot = DataReport1.Section1().ReportObjects().Item("lbl1")
            cot.Text += car.TireRFID
            '判断模式
            If judgeMdlIsOK((car.TireRFMdl), mdlArr) = False Then
                tmpStr = ";模式" & car.TireRFMdl & "(不合格)"
            End If

            '判断压力值是否合格
            If CDec(car.TireRFPre) < CDec(preMinValue) Then
                tmpStr = ";压力" & car.TireRFPre & "kPa(偏低)"
            ElseIf CDec(car.TireRFPre) > CDec(preMaxValue) Then
                tmpStr = ";压力" & car.TireRFPre & "kPa(偏高)"
            End If
            '判断温度值是否合格
            If CDec(car.TireRFTemp) < CDec(tempMinValue) Then
                tmpStr = tmpStr & ";温度" & car.TireRFTemp & "℃(偏低)"
            ElseIf CDec(car.TireRFTemp) > CDec(tempMaxValue) Then
                tmpStr = tmpStr & ";温度" & car.TireRFTemp & "℃(偏高)"
            End If
            '判断加速度是否合格
            If CDec(car.TireRFAcSpeed) < CDec(acSpeedMinValue) Then
                tmpStr = tmpStr & ";加速度" & car.TireRFAcSpeed & "g(偏低)"
            ElseIf CDec(car.TireRFAcSpeed) > CDec(acSpeedMaxValue) Then
                tmpStr = tmpStr & ";加速度" & car.TireRFAcSpeed & "g(偏高)"
            End If
            '判断电池电量
            If car.TireRFBattery <> "OK" Then
                tmpStr = tmpStr & ";电池电量低"
            End If
        Else
            cot = DataReport1.Section1().ReportObjects().Item("lbl1")
            cot.Text += "检测失败"
            cot.Color() = Color.Red
        End If
        If tmpStr <> "" Then
            cot = DataReport1.Section1().ReportObjects().Item("lbl1")
            cot.Text += tmpStr
            cot.Color() = Color.Red
            tmpStr = ""
            cot = DataReport1.Section1().ReportObjects().Item("labResult")
            cot.Text = "NG"
            cot.Color() = Color.Red
        End If

        If Mid(resultState, 2, 1) = "1" Then
            cot = DataReport1.Section1().ReportObjects().Item("lbl2")
            cot.Text += car.TireLFID
            '判断模式
            If judgeMdlIsOK((car.TireLFMdl), mdlArr) = False Then
                tmpStr = ";模式" & car.TireLFMdl & "(不合格)"
            End If

            '判断压力值是否合格
            If CDec(car.TireLFPre) < CDec(preMinValue) Then
                tmpStr = ";压力" & car.TireLFPre & "kPa(偏低)"
            ElseIf CDec(car.TireLFPre) > CDec(preMaxValue) Then
                tmpStr = ";压力" & car.TireLFPre & "kPa(偏高)"
            End If
            '判断温度值是否合格
            If CDec(car.TireLFTemp) < CDec(tempMinValue) Then
                tmpStr = tmpStr & ";温度" & car.TireLFTemp & "℃(偏低)"
            ElseIf CDec(car.TireLFTemp) > CDec(tempMaxValue) Then
                tmpStr = tmpStr & ";温度" & car.TireLFTemp & "℃(偏高)"
            End If
            '判断加速度是否合格
            If CDec(car.TireLFAcSpeed) < CDec(acSpeedMinValue) Then
                tmpStr = tmpStr & ";加速度" & car.TireLFAcSpeed & "g(偏低)"
            ElseIf CDec(car.TireLFAcSpeed) > CDec(acSpeedMaxValue) Then
                tmpStr = tmpStr & ";加速度" & car.TireLFAcSpeed & "g(偏高)"
            End If
            '判断电池电量
            If car.TireLFBattery <> "OK" Then
                tmpStr = tmpStr & ";电池电量低"
            End If
        Else
            cot = DataReport1.Section1().ReportObjects().Item("lbl2")
            cot.Text += "检测失败"
            cot.Color() = Color.Red
        End If
        If tmpStr <> "" Then
            cot = DataReport1.Section1().ReportObjects().Item("lbl2")
            cot.Text += tmpStr
            cot.Color() = Color.Red
            tmpStr = ""
            cot = DataReport1.Section1().ReportObjects().Item("labResult")
            cot.Text = "NG"
            cot.Color() = Color.Red
        End If

        If Mid(resultState, 3, 1) = "1" Then
            cot = DataReport1.Section1().ReportObjects().Item("lbl4")
            cot.Text += car.TireRRID
            '判断模式
            If judgeMdlIsOK((car.TireRRMdl), mdlArr) = False Then
                tmpStr = ";模式" & car.TireRRMdl & "(不合格)"
            End If

            '判断压力值是否合格
            If CDec(car.TireRRPre) < CDec(preMinValue) Then
                tmpStr = ";压力" & car.TireRRPre & "kPa(偏低)"
            ElseIf CDec(car.TireRRPre) > CDec(preMaxValue) Then
                tmpStr = ";压力" & car.TireRRPre & "kPa(偏高)"
            End If
            '判断温度值是否合格
            If CDec(car.TireRRTemp) < CDec(tempMinValue) Then
                tmpStr = tmpStr & ";温度" & car.TireRRTemp & "℃(偏低)"
            ElseIf CDec(car.TireRRTemp) > CDec(tempMaxValue) Then
                tmpStr = tmpStr & ";温度" & car.TireRRTemp & "℃(偏高)"
            End If
            '判断加速度是否合格
            If CDec(car.TireRRAcSpeed) < CDec(acSpeedMinValue) Then
                tmpStr = tmpStr & ";加速度" & car.TireRRAcSpeed & "g(偏低)"
            ElseIf CDec(car.TireRRAcSpeed) > CDec(acSpeedMaxValue) Then
                tmpStr = tmpStr & ";加速度" & car.TireRRAcSpeed & "g(偏高)"
            End If
            '判断电池电量
            If car.TireRRBattery <> "OK" Then
                tmpStr = tmpStr & ";电池电量低"
            End If
        Else
            cot = DataReport1.Section1().ReportObjects().Item("lbl4")
            cot.Text += "检测失败"
            cot.Color() = Color.Red
        End If
        If tmpStr <> "" Then
            cot = DataReport1.Section1().ReportObjects().Item("lbl4")
            cot.Text += tmpStr
            cot.Color() = Color.Red
            tmpStr = ""
            cot = DataReport1.Section1().ReportObjects().Item("labResult")
            cot.Text = "NG"
            cot.Color() = Color.Red
        End If

        If Mid(resultState, 4, 1) = "1" Then
            cot = DataReport1.Section1().ReportObjects().Item("lbl3")
            cot.Text += car.TireLRID
            '判断模式
            If judgeMdlIsOK((car.TireLRMdl), mdlArr) = False Then
                tmpStr = ";模式" & car.TireLRMdl & "(不合格)"
            End If

            '判断压力值是否合格
            If CDec(car.TireLRPre) < CDec(preMinValue) Then
                tmpStr = ";压力" & car.TireLRPre & "kPa(偏低)"
            ElseIf CDec(car.TireLRPre) > CDec(preMaxValue) Then
                tmpStr = ";压力" & car.TireLRPre & "kPa(偏高)"
            End If
            '判断温度值是否合格
            If CDec(car.TireLRTemp) < CDec(tempMinValue) Then
                tmpStr = tmpStr & ";温度" & car.TireLRTemp & "℃(偏低)"
            ElseIf CDec(car.TireLRTemp) > CDec(tempMaxValue) Then
                tmpStr = tmpStr & ";温度" & car.TireLRTemp & "℃(偏高)"
            End If
            '判断加速度是否合格
            If CDec(car.TireLRAcSpeed) < CDec(acSpeedMinValue) Then
                tmpStr = tmpStr & ";加速度" & car.TireLRAcSpeed & "g(偏低)"
            ElseIf CDec(car.TireLRAcSpeed) > CDec(acSpeedMaxValue) Then
                tmpStr = tmpStr & ";加速度" & car.TireLRAcSpeed & "g(偏高)"
            End If
            '判断电池电量
            If car.TireLRBattery <> "OK" Then
                tmpStr = tmpStr & ";电池电量低"
            End If
        Else
            cot = DataReport1.Section1().ReportObjects().Item("lbl3")
            cot.Text += "检测失败"
            cot.Color() = Color.Red
        End If
        If tmpStr <> "" Then
            cot = DataReport1.Section1().ReportObjects().Item("lbl3")
            cot.Text += tmpStr
            cot.Color() = Color.Red
            tmpStr = ""
            cot = DataReport1.Section1().ReportObjects().Item("labResult")
            cot.Text = "NG"
            cot.Color() = Color.Red
        End If
        CreateCrystal = DataReport1
    End Function
End Class