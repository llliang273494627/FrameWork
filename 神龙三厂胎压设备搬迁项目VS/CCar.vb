Option Strict Off
Option Explicit On
Public Class CCar
    Private m_VINCode As String

    Private m_TireRFID As String

    Private m_TireRFMdl As String
    Private m_TireRFPre As String
    Private m_TireRFTemp As String
    Private m_TireRFBattery As String
    Private m_TireRFAcSpeed As String

    Private m_TireRRID As String

    Private m_TireRRMdl As String
    Private m_TireRRPre As String
    Private m_TireRRTemp As String
    Private m_TireRRBattery As String
    Private m_TireRRAcSpeed As String

    Private m_TireLFID As String

    Private m_TireLFMdl As String
    Private m_TireLFPre As String
    Private m_TireLFTemp As String
    Private m_TireLFBattery As String
    Private m_TireLFAcSpeed As String

    Private m_TireLRID As String

    Private m_TireLRMdl As String
    Private m_TireLRPre As String
    Private m_TireLRTemp As String
    Private m_TireLRBattery As String
    Private m_TireLRAcSpeed As String

    Private testState As Short

    Private LastVin As String
    Public printFlag As Boolean
    Public LastCar As CCar

    Public Sub SetCarInfByVIN(ByRef vin As String)
        Dim cnn As New ADODB.Connection
        Dim rs As ADODB.Recordset
        cnn.Open(DBCnnStr)
        rs = New ADODB.Recordset
        rs.Open("select * from ""T_Result"" where ""VIN""='" & vin & "' ", DBCnnStr, 1, 3)

        If rs.EOF Then
            Exit Sub
        End If
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_VINCode = IIf(IsDBNull(rs.Fields("VIN").Value), "", rs.Fields("VIN").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireRFID = IIf(IsDBNull(rs.Fields("ID020").Value), "", rs.Fields("ID020").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireLFID = IIf(IsDBNull(rs.Fields("ID022").Value), "", rs.Fields("ID022").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireRRID = IIf(IsDBNull(rs.Fields("ID021").Value), "", rs.Fields("ID021").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireLRID = IIf(IsDBNull(rs.Fields("ID023").Value), "", rs.Fields("ID023").Value)

        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireRFMdl = IIf(IsDBNull(rs.Fields("Mdl020").Value), "", rs.Fields("Mdl020").Value)

        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireLFMdl = IIf(IsDBNull(rs.Fields("Mdl022").Value), "", rs.Fields("Mdl022").Value)

        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireRRMdl = IIf(IsDBNull(rs.Fields("Mdl021").Value), "", rs.Fields("Mdl021").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireLRMdl = IIf(IsDBNull(rs.Fields("Mdl023").Value), "", rs.Fields("Mdl023").Value)

        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireRFPre = IIf(IsDBNull(rs.Fields("Pre020").Value), "", rs.Fields("Pre020").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireLFPre = IIf(IsDBNull(rs.Fields("Pre022").Value), "", rs.Fields("Pre022").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireRRPre = IIf(IsDBNull(rs.Fields("Pre021").Value), "", rs.Fields("Pre021").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireLRPre = IIf(IsDBNull(rs.Fields("Pre023").Value), "", rs.Fields("Pre023").Value)

        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireRFTemp = IIf(IsDBNull(rs.Fields("Temp020").Value), "", rs.Fields("Temp020").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireLFTemp = IIf(IsDBNull(rs.Fields("Temp022").Value), "", rs.Fields("Temp022").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireRRTemp = IIf(IsDBNull(rs.Fields("Temp021").Value), "", rs.Fields("Temp021").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireLRTemp = IIf(IsDBNull(rs.Fields("Temp023").Value), "", rs.Fields("Temp023").Value)

        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireRFBattery = IIf(IsDBNull(rs.Fields("Battery020").Value), "", rs.Fields("Battery020").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireLFBattery = IIf(IsDBNull(rs.Fields("Battery022").Value), "", rs.Fields("Battery022").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireRRBattery = IIf(IsDBNull(rs.Fields("Battery021").Value), "", rs.Fields("Battery021").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireLRBattery = IIf(IsDBNull(rs.Fields("Battery023").Value), "", rs.Fields("Battery023").Value)

        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireRFAcSpeed = IIf(IsDBNull(rs.Fields("AcSpeed020").Value), "", rs.Fields("AcSpeed020").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireLFAcSpeed = IIf(IsDBNull(rs.Fields("AcSpeed022").Value), "", rs.Fields("AcSpeed022").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireRRAcSpeed = IIf(IsDBNull(rs.Fields("AcSpeed021").Value), "", rs.Fields("AcSpeed021").Value)
        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        m_TireLRAcSpeed = IIf(IsDBNull(rs.Fields("AcSpeed023").Value), "", rs.Fields("AcSpeed023").Value)

        'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
        testState = IIf(IsDBNull(rs.Fields("TestState").Value), 0, rs.Fields("TestState").Value)
        rs.Close()
        'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
        rs = Nothing
        cnn.Close()
        'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
        cnn = Nothing
    End Sub

    Public ReadOnly Property GetTestState() As String
        Get
            GetTestState = CStr(testState)
        End Get
    End Property

    Public Property VINCode() As String
        Get
            VINCode = m_VINCode
        End Get
        Set(ByVal Value As String)
            m_VINCode = Value
        End Set
    End Property

    Public Property TireRFID() As String
        Get
            TireRFID = m_TireRFID
        End Get
        Set(ByVal Value As String)
            m_TireRFID = Value
        End Set
    End Property


    Public Property TireRFMdl() As String
        Get
            TireRFMdl = m_TireRFMdl
        End Get
        Set(ByVal Value As String)
            m_TireRFMdl = Value
        End Set
    End Property


    Public Property TireRFPre() As String
        Get
            TireRFPre = m_TireRFPre
        End Get
        Set(ByVal Value As String)
            m_TireRFPre = Value
        End Set
    End Property


    Public Property TireRFTemp() As String
        Get
            TireRFTemp = m_TireRFTemp
        End Get
        Set(ByVal Value As String)
            m_TireRFTemp = Value
        End Set
    End Property


    Public Property TireRFBattery() As String
        Get
            TireRFBattery = m_TireRFBattery
        End Get
        Set(ByVal Value As String)
            m_TireRFBattery = Value
        End Set
    End Property


    Public Property TireRFAcSpeed() As String
        Get
            TireRFAcSpeed = m_TireRFAcSpeed
        End Get
        Set(ByVal Value As String)
            m_TireRFAcSpeed = Value
        End Set
    End Property
    '右后

    Public Property TireRRID() As String
        Get
            TireRRID = m_TireRRID
        End Get
        Set(ByVal Value As String)
            m_TireRRID = Value
        End Set
    End Property


    Public Property TireRRMdl() As String
        Get
            TireRRMdl = m_TireRRMdl
        End Get
        Set(ByVal Value As String)
            m_TireRRMdl = Value
        End Set
    End Property


    Public Property TireRRPre() As String
        Get
            TireRRPre = m_TireRRPre
        End Get
        Set(ByVal Value As String)
            m_TireRRPre = Value
        End Set
    End Property


    Public Property TireRRTemp() As String
        Get
            TireRRTemp = m_TireRRTemp
        End Get
        Set(ByVal Value As String)
            m_TireRRTemp = Value
        End Set
    End Property


    Public Property TireRRBattery() As String
        Get
            TireRRBattery = m_TireRRBattery
        End Get
        Set(ByVal Value As String)
            m_TireRRBattery = Value
        End Set
    End Property


    Public Property TireRRAcSpeed() As String
        Get
            TireRRAcSpeed = m_TireRRAcSpeed
        End Get
        Set(ByVal Value As String)
            m_TireRRAcSpeed = Value
        End Set
    End Property
    '左前

    Public Property TireLFID() As String
        Get
            TireLFID = m_TireLFID
        End Get
        Set(ByVal Value As String)
            m_TireLFID = Value
        End Set
    End Property


    Public Property TireLFMdl() As String
        Get
            TireLFMdl = m_TireLFMdl
        End Get
        Set(ByVal Value As String)
            m_TireLFMdl = Value
        End Set
    End Property


    Public Property TireLFPre() As String
        Get
            TireLFPre = m_TireLFPre
        End Get
        Set(ByVal Value As String)
            m_TireLFPre = Value
        End Set
    End Property


    Public Property TireLFTemp() As String
        Get
            TireLFTemp = m_TireLFTemp
        End Get
        Set(ByVal Value As String)
            m_TireLFTemp = Value
        End Set
    End Property


    Public Property TireLFBattery() As String
        Get
            TireLFBattery = m_TireLFBattery
        End Get
        Set(ByVal Value As String)
            m_TireLFBattery = Value
        End Set
    End Property


    Public Property TireLFAcSpeed() As String
        Get
            TireLFAcSpeed = m_TireLFAcSpeed
        End Get
        Set(ByVal Value As String)
            m_TireLFAcSpeed = Value
        End Set
    End Property
    '右后

    Public Property TireLRID() As String
        Get
            TireLRID = m_TireLRID
        End Get
        Set(ByVal Value As String)
            m_TireLRID = Value
        End Set
    End Property


    Public Property TireLRMdl() As String
        Get
            TireLRMdl = m_TireLRMdl
        End Get
        Set(ByVal Value As String)
            m_TireLRMdl = Value
        End Set
    End Property


    Public Property TireLRPre() As String
        Get
            TireLRPre = m_TireLRPre
        End Get
        Set(ByVal Value As String)
            m_TireLRPre = Value
        End Set
    End Property


    Public Property TireLRTemp() As String
        Get
            TireLRTemp = m_TireLRTemp
        End Get
        Set(ByVal Value As String)
            m_TireLRTemp = Value
        End Set
    End Property


    Public Property TireLRBattery() As String
        Get
            TireLRBattery = m_TireLRBattery
        End Get
        Set(ByVal Value As String)
            m_TireLRBattery = Value
        End Set
    End Property


    Public Property TireLRAcSpeed() As String
        Get
            TireLRAcSpeed = m_TireLRAcSpeed
        End Get
        Set(ByVal Value As String)
            m_TireLRAcSpeed = Value
        End Set
    End Property


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