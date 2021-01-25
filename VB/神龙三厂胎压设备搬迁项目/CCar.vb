Option Strict Off
Option Explicit On
Friend Class CCar
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
	Private overStandard As Boolean
	
	'Public LastResulr As Boolean
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
		m_VINCode = IIf(IsDbNull(rs.Fields("VIN").value), "", rs.Fields("VIN").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireRFID = IIf(IsDbNull(rs.Fields("ID020").value), "", rs.Fields("ID020").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireLFID = IIf(IsDbNull(rs.Fields("ID022").value), "", rs.Fields("ID022").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireRRID = IIf(IsDbNull(rs.Fields("ID021").value), "", rs.Fields("ID021").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireLRID = IIf(IsDbNull(rs.Fields("ID023").value), "", rs.Fields("ID023").value)
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireRFMdl = IIf(IsDbNull(rs.Fields("Mdl020").value), "", rs.Fields("Mdl020").value)
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireLFMdl = IIf(IsDbNull(rs.Fields("Mdl022").value), "", rs.Fields("Mdl022").value)
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireRRMdl = IIf(IsDbNull(rs.Fields("Mdl021").value), "", rs.Fields("Mdl021").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireLRMdl = IIf(IsDbNull(rs.Fields("Mdl023").value), "", rs.Fields("Mdl023").value)
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireRFPre = IIf(IsDbNull(rs.Fields("Pre020").value), "", rs.Fields("Pre020").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireLFPre = IIf(IsDbNull(rs.Fields("Pre022").value), "", rs.Fields("Pre022").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireRRPre = IIf(IsDbNull(rs.Fields("Pre021").value), "", rs.Fields("Pre021").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireLRPre = IIf(IsDbNull(rs.Fields("Pre023").value), "", rs.Fields("Pre023").value)
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireRFTemp = IIf(IsDbNull(rs.Fields("Temp020").value), "", rs.Fields("Temp020").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireLFTemp = IIf(IsDbNull(rs.Fields("Temp022").value), "", rs.Fields("Temp022").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireRRTemp = IIf(IsDbNull(rs.Fields("Temp021").value), "", rs.Fields("Temp021").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireLRTemp = IIf(IsDbNull(rs.Fields("Temp023").value), "", rs.Fields("Temp023").value)
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireRFBattery = IIf(IsDbNull(rs.Fields("Battery020").value), "", rs.Fields("Battery020").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireLFBattery = IIf(IsDbNull(rs.Fields("Battery022").value), "", rs.Fields("Battery022").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireRRBattery = IIf(IsDbNull(rs.Fields("Battery021").value), "", rs.Fields("Battery021").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireLRBattery = IIf(IsDbNull(rs.Fields("Battery023").value), "", rs.Fields("Battery023").value)
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireRFAcSpeed = IIf(IsDbNull(rs.Fields("AcSpeed020").value), "", rs.Fields("AcSpeed020").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireLFAcSpeed = IIf(IsDbNull(rs.Fields("AcSpeed022").value), "", rs.Fields("AcSpeed022").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireRRAcSpeed = IIf(IsDbNull(rs.Fields("AcSpeed021").value), "", rs.Fields("AcSpeed021").value)
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		m_TireLRAcSpeed = IIf(IsDbNull(rs.Fields("AcSpeed023").value), "", rs.Fields("AcSpeed023").value)
		
		'UPGRADE_WARNING: 检测到使用了 Null/IsNull()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"”
		testState = IIf(IsDbNull(rs.Fields("TestState").value), 0, rs.Fields("TestState").value)
		rs.Close()
		'UPGRADE_NOTE: 在对对象 rs 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		rs = Nothing
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
	
	Public Sub CheckResultIsOverStandard()
		On Error Resume Next
		Dim Result As Boolean
		overStandard = False
		Dim mdlArr() As String
		Dim i As Short
		
		mdlArr = Split(mdlValue, ",")
		
		'判断右前轮
		'模式
		Result = judgeMdlIsOK(m_TireRFMdl, mdlArr)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		
		'压力
		Result = judgeResultIsOK(m_TireRFPre, preMinValue, preMaxValue)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		'温度
		Result = judgeResultIsOK(m_TireRFTemp, tempMinValue, tempMaxValue)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		'电池
		If m_TireRFBattery <> "OK" Then
			overStandard = True
			Exit Sub
		End If
		'加速度
		Result = judgeResultIsOK(m_TireRFAcSpeed, acSpeedMinValue, acSpeedMaxValue)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		
		
		'判断左前轮
		'模式
		Result = judgeMdlIsOK(m_TireLFMdl, mdlArr)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		
		'压力
		Result = judgeResultIsOK(m_TireLFPre, preMinValue, preMaxValue)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		'温度
		Result = judgeResultIsOK(m_TireLFTemp, tempMinValue, tempMaxValue)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		'电池
		If m_TireLFBattery <> "OK" Then
			overStandard = True
			Exit Sub
		End If
		'加速度
		Result = judgeResultIsOK(m_TireLFAcSpeed, acSpeedMinValue, acSpeedMaxValue)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		
		
		'判断右后轮
		'模式
		Result = judgeMdlIsOK(m_TireRRMdl, mdlArr)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		
		'压力
		Result = judgeResultIsOK(m_TireRRPre, preMinValue, preMaxValue)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		'温度
		Result = judgeResultIsOK(m_TireRRTemp, tempMinValue, tempMaxValue)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		'电池
		If m_TireRRBattery <> "OK" Then
			overStandard = True
			Exit Sub
		End If
		'加速度
		Result = judgeResultIsOK(m_TireRRAcSpeed, acSpeedMinValue, acSpeedMaxValue)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		
		'判断左后轮
		'模式
		Result = judgeMdlIsOK(m_TireLRMdl, mdlArr)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		
		'压力
		Result = judgeResultIsOK(m_TireLRPre, preMinValue, preMaxValue)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		'温度
		Result = judgeResultIsOK(m_TireLRTemp, tempMinValue, tempMaxValue)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
		'电池
		If m_TireLRBattery <> "OK" Then
			overStandard = True
			Exit Sub
		End If
		'加速度
		Result = judgeResultIsOK(m_TireLRAcSpeed, acSpeedMinValue, acSpeedMaxValue)
		If Not Result Then
			overStandard = True
			Exit Sub
		End If
	End Sub
	
	Public ReadOnly Property GetTestState() As String
		Get
			GetTestState = CStr(testState)
		End Get
	End Property
	
	Public ReadOnly Property IsOverStandard() As String
		Get
			IsOverStandard = CStr(overStandard)
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
			LastVin = lastrs.Fields(0).value
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
		
		
		rs.Fields("VIN").value = m_VINCode
		rs.Fields("VIS").value = Right(m_VINCode, 8)
		rs.Fields("ID020").value = m_TireRFID
		rs.Fields("ID022").value = m_TireLFID
		rs.Fields("ID021").value = m_TireRRID
		rs.Fields("ID023").value = m_TireLRID
		
		rs.Fields("Mdl020").value = m_TireRFMdl
		rs.Fields("Mdl022").value = m_TireLFMdl
		rs.Fields("Mdl021").value = m_TireRRMdl
		rs.Fields("Mdl023").value = m_TireLRMdl
		
		rs.Fields("Pre020").value = m_TireRFPre
		rs.Fields("Pre022").value = m_TireLFPre
		rs.Fields("Pre021").value = m_TireRRPre
		rs.Fields("Pre023").value = m_TireLRPre
		
		rs.Fields("Temp020").value = m_TireRFTemp
		rs.Fields("Temp022").value = m_TireLFTemp
		rs.Fields("Temp021").value = m_TireRRTemp
		rs.Fields("Temp023").value = m_TireLRTemp
		
		rs.Fields("Battery020").value = m_TireRFBattery
		rs.Fields("Battery022").value = m_TireLFBattery
		rs.Fields("Battery021").value = m_TireRRBattery
		rs.Fields("Battery023").value = m_TireLRBattery
		
		rs.Fields("AcSpeed020").value = m_TireRFAcSpeed
		rs.Fields("AcSpeed022").value = m_TireLFAcSpeed
		rs.Fields("AcSpeed021").value = m_TireRRAcSpeed
		rs.Fields("AcSpeed023").value = m_TireLRAcSpeed
		
		rs.Fields("TestTime").value = Now
		rs.Fields("TestState").value = testState
		rs.Fields("Dev").value = "101"
		rs.Fields("UploadSign").value = False
		rs.Fields("DownloadSign").value = False
		
		'获取MTOC码
		mtoc = GetMtocFromVinColl(m_VINCode)
		If mtoc <> "" Then
			rs.Fields("MTOC").value = mtoc
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
		
		
		rs.Fields("VIN").value = m_VINCode
		rs.Fields("VIS").value = Right(m_VINCode, 8)
		rs.Fields("ID020").value = m_TireRFID
		rs.Fields("ID022").value = m_TireLFID
		rs.Fields("ID021").value = m_TireRRID
		rs.Fields("ID023").value = m_TireLRID
		
		rs.Fields("Mdl020").value = m_TireRFMdl
		rs.Fields("Mdl022").value = m_TireLFMdl
		rs.Fields("Mdl021").value = m_TireRRMdl
		rs.Fields("Mdl023").value = m_TireLRMdl
		
		rs.Fields("Pre020").value = m_TireRFPre
		rs.Fields("Pre022").value = m_TireLFPre
		rs.Fields("Pre021").value = m_TireRRPre
		rs.Fields("Pre023").value = m_TireLRPre
		
		rs.Fields("Temp020").value = m_TireRFTemp
		rs.Fields("Temp022").value = m_TireLFTemp
		rs.Fields("Temp021").value = m_TireRRTemp
		rs.Fields("Temp023").value = m_TireLRTemp
		
		rs.Fields("Battery020").value = m_TireRFBattery
		rs.Fields("Battery022").value = m_TireLFBattery
		rs.Fields("Battery021").value = m_TireRRBattery
		rs.Fields("Battery023").value = m_TireLRBattery
		
		rs.Fields("AcSpeed020").value = m_TireRFAcSpeed
		rs.Fields("AcSpeed022").value = m_TireLFAcSpeed
		rs.Fields("AcSpeed021").value = m_TireRRAcSpeed
		rs.Fields("AcSpeed023").value = m_TireLRAcSpeed
		
		rs.Fields("Dev").value = "101"
		rs.Fields("TestTime").value = Now
		rs.Fields("TestState").value = testState
		rs.Fields("UploadSign").value = False
		rs.Fields("DownloadSign").value = False
		If mtoc <> "" Then
			rs.Fields("MTOC").value = mtoc
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
			GetMtocFromVinColl = rs.Fields("mtoc").value & ""
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