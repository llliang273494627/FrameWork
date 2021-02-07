Option Strict Off
Option Explicit On
Public Class CCar
    Inherits DSGTest.Common.Comm.CCar

    Private LastVin As String
    Public printFlag As Boolean
    Public LastCar As CCar

    Public Sub Save()
        On Error GoTo CCAR_SAVE_ERR
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim lastrs As ADODB.Recordset
        Dim sql As String
        Dim mtoc As String
        cnn.CommandTimeout = TimeOutNum
        cnn.Open(DBCnnStr)

        lastrs = cnn.Execute("select ""VIN"" from ""T_Result"" order by ""ID"" desc limit 1")
        printFlag = False
        If Not lastrs.EOF Then
            LastVin = lastrs.Fields(0).Value
        End If
        LastCar = New CCar
        If LastVin <> m_VINCode And LastVin <> "" Then

            LastCar.SetCarInfByVIN(LastVin)
            If m_TireRFID <> "" And m_TireRFID <> "00000000" Then
                Select Case m_TireRFID
                    Case LastCar.TireLFID
                        printFlag = True
                        LastCar.TireLFID = "00000000"
                        m_TireRFID = "00000000"
                    Case LastCar.TireLRID
                        printFlag = True
                        LastCar.TireLRID = "00000000"
                        m_TireRFID = "00000000"
                    Case LastCar.TireRFID
                        printFlag = True
                        LastCar.TireRFID = "00000000"
                        m_TireRFID = "00000000"
                    Case LastCar.TireRRID
                        printFlag = True
                        LastCar.TireRRID = "00000000"
                        m_TireRFID = "00000000"
                End Select
            End If

            If m_TireLFID <> "" And m_TireLFID <> "00000000" Then
                Select Case m_TireLFID
                    Case LastCar.TireLFID
                        printFlag = True
                        LastCar.TireLFID = "00000000"
                        m_TireLFID = "00000000"
                    Case LastCar.TireLRID
                        printFlag = True
                        LastCar.TireLRID = "00000000"
                        m_TireLFID = "00000000"
                    Case LastCar.TireRFID
                        printFlag = True
                        LastCar.TireRFID = "00000000"
                        m_TireLFID = "00000000"
                    Case LastCar.TireRRID
                        printFlag = True
                        LastCar.TireRRID = "00000000"
                        m_TireLFID = "00000000"
                End Select
            End If

            If m_TireRRID <> "" And m_TireRRID <> "00000000" Then
                Select Case m_TireRRID
                    Case LastCar.TireLFID
                        printFlag = True
                        LastCar.TireLFID = "00000000"
                        m_TireRRID = "00000000"
                    Case LastCar.TireLRID
                        printFlag = True
                        LastCar.TireLRID = "00000000"
                        m_TireRRID = "00000000"
                    Case LastCar.TireRFID
                        printFlag = True
                        LastCar.TireRFID = "00000000"
                        m_TireRRID = "00000000"
                    Case LastCar.TireRRID
                        printFlag = True
                        LastCar.TireRRID = "00000000"
                        m_TireRRID = "00000000"
                End Select
            End If
            If m_TireLRID <> "" And m_TireLRID <> "00000000" Then
                Select Case m_TireLRID
                    Case LastCar.TireLFID
                        printFlag = True
                        LastCar.TireLFID = "00000000"
                        m_TireLRID = "00000000"
                    Case LastCar.TireLRID
                        printFlag = True
                        LastCar.TireLRID = "00000000"
                        m_TireLRID = "00000000"
                    Case LastCar.TireRFID
                        printFlag = True
                        LastCar.TireRFID = "00000000"
                        m_TireLRID = "00000000"
                    Case LastCar.TireRRID
                        printFlag = True
                        LastCar.TireRRID = "00000000"
                        m_TireLRID = "00000000"
                End Select
            End If
            'LastCar.Save
        End If


        testState = 0
        If Len(m_TireRFID) = 8 And m_TireRFID <> "00000000" And Trim(m_TireRFID) <> "" And m_TireRFID <> m_TireLFID And m_TireRFID <> m_TireLRID And m_TireRFID <> m_TireRRID Then
            testState = testState + 8
        End If
        If Len(m_TireLFID) = 8 And m_TireLFID <> "00000000" And Trim(m_TireLFID) <> "" And m_TireLFID <> m_TireRFID And m_TireLFID <> m_TireLRID And m_TireLFID <> m_TireRRID Then
            testState = testState + 4
        End If
        If Len(m_TireRRID) = 8 And m_TireRRID <> "00000000" And Trim(m_TireRRID) <> "" And m_TireRRID <> m_TireLFID And m_TireRRID <> m_TireLRID And m_TireRRID <> m_TireRFID Then
            testState = testState + 2
        End If
        If Len(m_TireLRID) = 8 And m_TireLRID <> "00000000" And Trim(m_TireLRID) <> "" And m_TireLRID <> m_TireLFID And m_TireLRID <> m_TireRFID And m_TireLRID <> m_TireRRID Then
            testState = testState + 1
        End If

        rs.Open("select * from ""T_Result"" where ""VIN""='" & m_VINCode & "' ", DBCnnStr, 1, 3)
        If rs.EOF Then
            rs.AddNew()
        End If


        rs.Fields("VIN").Value = m_VINCode
        rs.Fields("VIS").Value = Right(m_VINCode, 8)
        rs.Fields("ID020").Value = m_TireRFID
        rs.Fields("ID022").Value = m_TireLFID
        rs.Fields("ID021").Value = m_TireRRID
        rs.Fields("ID023").Value = m_TireLRID

        rs.Fields("Mdl020").Value = m_TireRFMdl
        rs.Fields("Mdl022").Value = m_TireLFMdl
        rs.Fields("Mdl021").Value = m_TireRRMdl
        rs.Fields("Mdl023").Value = m_TireLRMdl

        rs.Fields("Pre020").Value = m_TireRFPre
        rs.Fields("Pre022").Value = m_TireLFPre
        rs.Fields("Pre021").Value = m_TireRRPre
        rs.Fields("Pre023").Value = m_TireLRPre

        rs.Fields("Temp020").Value = m_TireRFTemp
        rs.Fields("Temp022").Value = m_TireLFTemp
        rs.Fields("Temp021").Value = m_TireRRTemp
        rs.Fields("Temp023").Value = m_TireLRTemp

        rs.Fields("Battery020").Value = m_TireRFBattery
        rs.Fields("Battery022").Value = m_TireLFBattery
        rs.Fields("Battery021").Value = m_TireRRBattery
        rs.Fields("Battery023").Value = m_TireLRBattery

        rs.Fields("AcSpeed020").Value = m_TireRFAcSpeed
        rs.Fields("AcSpeed022").Value = m_TireLFAcSpeed
        rs.Fields("AcSpeed021").Value = m_TireRRAcSpeed
        rs.Fields("AcSpeed023").Value = m_TireLRAcSpeed

        rs.Fields("TestTime").Value = Now
        rs.Fields("TestState").Value = testState
        rs.Fields("Dev").Value = "101"
        rs.Fields("UploadSign").Value = False
        rs.Fields("DownloadSign").Value = False

        '获取MTOC码
        mtoc = GetMtocFromVinColl(m_VINCode)
        If mtoc <> "" Then
            rs.Fields("MTOC").Value = mtoc
        End If

        rs.Update()
        rs.Close()
        'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
        rs = Nothing
        cnn.Close()

        '存入远程数据库
        cnn.ConnectionTimeout = TimeOutNum 'Add by ZCJ 2012/02/21
        cnn.CommandTimeout = TimeOutNum
        cnn.Open(RDBCnnStr)

        rs.Open("select * from ""T_Result"" where ""VIN""='" & m_VINCode & "' ", RDBCnnStr, 1, 3)

        If rs.EOF Then
            rs.AddNew()
        End If


        rs.Fields("VIN").Value = m_VINCode
        rs.Fields("VIS").Value = Right(m_VINCode, 8)
        rs.Fields("ID020").Value = m_TireRFID
        rs.Fields("ID022").Value = m_TireLFID
        rs.Fields("ID021").Value = m_TireRRID
        rs.Fields("ID023").Value = m_TireLRID

        rs.Fields("Mdl020").Value = m_TireRFMdl
        rs.Fields("Mdl022").Value = m_TireLFMdl
        rs.Fields("Mdl021").Value = m_TireRRMdl
        rs.Fields("Mdl023").Value = m_TireLRMdl

        rs.Fields("Pre020").Value = m_TireRFPre
        rs.Fields("Pre022").Value = m_TireLFPre
        rs.Fields("Pre021").Value = m_TireRRPre
        rs.Fields("Pre023").Value = m_TireLRPre

        rs.Fields("Temp020").Value = m_TireRFTemp
        rs.Fields("Temp022").Value = m_TireLFTemp
        rs.Fields("Temp021").Value = m_TireRRTemp
        rs.Fields("Temp023").Value = m_TireLRTemp

        rs.Fields("Battery020").Value = m_TireRFBattery
        rs.Fields("Battery022").Value = m_TireLFBattery
        rs.Fields("Battery021").Value = m_TireRRBattery
        rs.Fields("Battery023").Value = m_TireLRBattery

        rs.Fields("AcSpeed020").Value = m_TireRFAcSpeed
        rs.Fields("AcSpeed022").Value = m_TireLFAcSpeed
        rs.Fields("AcSpeed021").Value = m_TireRRAcSpeed
        rs.Fields("AcSpeed023").Value = m_TireLRAcSpeed

        rs.Fields("Dev").Value = "101"
        rs.Fields("TestTime").Value = Now
        rs.Fields("TestState").Value = testState
        rs.Fields("UploadSign").Value = False
        rs.Fields("DownloadSign").Value = False
        If mtoc <> "" Then
            rs.Fields("MTOC").Value = mtoc
        End If

        rs.Update()
        rs.Close()
        'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
        rs = Nothing
        cnn.Close()

        'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
        cnn = Nothing
        Exit Sub
CCAR_SAVE_ERR:
        LogWritter("CCAR_SAVE_ERR 错误信息：" & Err.Description)
    End Sub

    Public Function GetMtocFromVinColl(ByRef vin As String) As String
        On Error GoTo Err_Renamed
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        cnn.CommandTimeout = TimeOutNum
        cnn.Open(DBCnnStr)
        rs = cnn.Execute("select mtoc from vincoll where vin='" & vin & "'")
        If Not rs.EOF Then
            GetMtocFromVinColl = rs.Fields("mtoc").Value & ""
        Else
            GetMtocFromVinColl = ""
        End If
        rs.Close()
        'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
        rs = Nothing
        cnn.Close()
        Exit Function
Err_Renamed:
        GetMtocFromVinColl = ""
    End Function
End Class