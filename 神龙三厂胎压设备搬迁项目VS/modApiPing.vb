Option Strict Off
Option Explicit On
Module modApiPing
	
	Public Const IP_STATUS_BASE As Short = 11000
	Public Const IP_SUCCESS As Short = 0
	Public Const IP_BUF_TOO_SMALL As Short = (11000 + 1)
	Public Const IP_DEST_NET_UNREACHABLE As Short = (11000 + 2)
	Public Const IP_DEST_HOST_UNREACHABLE As Short = (11000 + 3)
	Public Const IP_DEST_PROT_UNREACHABLE As Short = (11000 + 4)
	Public Const IP_DEST_PORT_UNREACHABLE As Short = (11000 + 5)
	Public Const IP_NO_RESOURCES As Short = (11000 + 6)
	Public Const IP_BAD_OPTION As Short = (11000 + 7)
	Public Const IP_HW_ERROR As Short = (11000 + 8)
	Public Const IP_PACKET_TOO_BIG As Short = (11000 + 9)
	Public Const IP_REQ_TIMED_OUT As Short = (11000 + 10)
	Public Const IP_BAD_REQ As Short = (11000 + 11)
	Public Const IP_BAD_ROUTE As Short = (11000 + 12)
	Public Const IP_TTL_EXPIRED_TRANSIT As Short = (11000 + 13)
	Public Const IP_TTL_EXPIRED_REASSEM As Short = (11000 + 14)
	Public Const IP_PARAM_PROBLEM As Short = (11000 + 15)
	Public Const IP_SOURCE_QUENCH As Short = (11000 + 16)
	Public Const IP_OPTION_TOO_BIG As Short = (11000 + 17)
	Public Const IP_BAD_DESTINATION As Short = (11000 + 18)
	Public Const IP_ADDR_DELETED As Short = (11000 + 19)
	Public Const IP_SPEC_MTU_CHANGE As Short = (11000 + 20)
	Public Const IP_MTU_CHANGE As Short = (11000 + 21)
	Public Const IP_UNLOAD As Short = (11000 + 22)
	Public Const IP_ADDR_ADDED As Short = (11000 + 23)
	Public Const IP_GENERAL_FAILURE As Short = (11000 + 50)
	Public Const MAX_IP_STATUS As Short = 11000 + 50
	Public Const IP_PENDING As Short = (11000 + 255)
	Public Const PING_TIMEOUT As Short = 200
	Public Const WS_VERSION_REQD As Integer = &H101
	Public Const WS_VERSION_MAJOR As Boolean = WS_VERSION_REQD And &H100 And &HFF '///////////////////
	Public Const WS_VERSION_MINOR As Boolean = WS_VERSION_REQD And &HFF
	Public Const MIN_SOCKETS_REQD As Short = 1
	Public Const SOCKET_ERROR As Short = -1
	
	Public Const MAX_WSADescription As Short = 256
	Public Const MAX_WSASYSStatus As Short = 128
	
	Public Structure ICMP_OPTIONS
		Dim Ttl As Byte
		Dim Tos As Byte
		Dim Flags As Byte
		Dim OptionsSize As Byte
		Dim OptionsData As Integer
	End Structure
	
	Dim ICMPOPT As ICMP_OPTIONS
	
	Public Structure ICMP_ECHO_REPLY
		Dim Address As Integer
		Dim status As Integer
		Dim RoundTripTime As Integer
		Dim DataSize As Short
		Dim Reserved As Short
		Dim DataPointer As Integer
		Dim Options As ICMP_OPTIONS
		'UPGRADE_WARNING: 固定长度字符串的大小必须适合缓冲区。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"”
		<VBFixedString(250),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=250)> Public Data() As Char
	End Structure
	
	Public Structure HOSTENT
		Dim hName As Integer
		Dim hAliases As Integer
		Dim hAddrType As Short
		Dim hLen As Short
		Dim hAddrList As Integer
	End Structure
	
	Public Structure WSADATA
		Dim wVersion As Short
		Dim wHighVersion As Short
		<VBFixedArray(MAX_WSADescription)> Dim szDescription() As Byte
		<VBFixedArray(MAX_WSASYSStatus)> Dim szSystemStatus() As Byte
		Dim wMaxSockets As Short
		Dim wMaxUDPDG As Short
		Dim dwVendorInfo As Integer
		
		'UPGRADE_TODO: 必须调用“Initialize”来初始化此结构的实例。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"”
		Public Sub Initialize()
			ReDim szDescription(MAX_WSADescription)
			ReDim szSystemStatus(MAX_WSASYSStatus)
		End Sub
	End Structure
	
	
	Public Declare Function IcmpCreateFile Lib "icmp.dll" () As Integer
	
	Public Declare Function IcmpCloseHandle Lib "icmp.dll" (ByVal IcmpHandle As Integer) As Integer
	
	'UPGRADE_WARNING: 结构 ICMP_ECHO_REPLY 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Public Declare Function IcmpSendEcho Lib "icmp.dll" (ByVal IcmpHandle As Integer, ByVal DestinationAddress As Integer, ByVal RequestData As String, ByVal RequestSize As Short, ByVal RequestOptions As Integer, ByRef ReplyBuffer As ICMP_ECHO_REPLY, ByVal ReplySize As Integer, ByVal Timeout As Integer) As Integer
	
	Public Declare Function WSAGetLastError Lib "WSOCK32.DLL" () As Integer
	
	'UPGRADE_WARNING: 结构 WSADATA 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Public Declare Function WSAStartup Lib "WSOCK32.DLL" (ByVal wVersionRequired As Integer, ByRef lpWSADATA As WSADATA) As Integer
	
	Public Declare Function WSACleanup Lib "WSOCK32.DLL" () As Integer
	
	Public Declare Function gethostname Lib "WSOCK32.DLL" (ByVal szHost As String, ByVal dwHostLen As Integer) As Integer
	
	Public Declare Function gethostbyname Lib "WSOCK32.DLL" (ByVal szHost As String) As Integer
	
	'UPGRADE_ISSUE: 不支持将参数声明为“As Any”。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"”
    Public Declare Sub RtlMoveMemory Lib "KERNEL32" (ByRef hpvDest As Object, ByVal hpvSource As Integer, ByVal cbCopy As Integer)
	
	
	Public Function GetStatusCode(ByRef status As Integer) As String
		
		Dim Msg As String
		
		Select Case status
			Case IP_SUCCESS : Msg = "ip success"
			Case IP_BUF_TOO_SMALL : Msg = "ip buf too_small"
			Case IP_DEST_NET_UNREACHABLE : Msg = "ip dest net unreachable"
			Case IP_DEST_HOST_UNREACHABLE : Msg = "ip dest host unreachable"
			Case IP_DEST_PROT_UNREACHABLE : Msg = "ip dest prot unreachable"
			Case IP_DEST_PORT_UNREACHABLE : Msg = "ip dest port unreachable"
			Case IP_NO_RESOURCES : Msg = "ip no resources"
			Case IP_BAD_OPTION : Msg = "ip bad option"
			Case IP_HW_ERROR : Msg = "ip hw_error"
			Case IP_PACKET_TOO_BIG : Msg = "ip packet too_big"
			Case IP_REQ_TIMED_OUT : Msg = "ip req timed out"
			Case IP_BAD_REQ : Msg = "ip bad req"
			Case IP_BAD_ROUTE : Msg = "ip bad route"
			Case IP_TTL_EXPIRED_TRANSIT : Msg = "ip ttl expired transit"
			Case IP_TTL_EXPIRED_REASSEM : Msg = "ip ttl expired reassem"
			Case IP_PARAM_PROBLEM : Msg = "ip param_problem"
			Case IP_SOURCE_QUENCH : Msg = "ip source quench"
			Case IP_OPTION_TOO_BIG : Msg = "ip option too_big"
			Case IP_BAD_DESTINATION : Msg = "ip bad destination"
			Case IP_ADDR_DELETED : Msg = "ip addr deleted"
			Case IP_SPEC_MTU_CHANGE : Msg = "ip spec mtu change"
			Case IP_MTU_CHANGE : Msg = "ip mtu_change"
			Case IP_UNLOAD : Msg = "ip unload"
			Case IP_ADDR_ADDED : Msg = "ip addr added"
			Case IP_GENERAL_FAILURE : Msg = "ip general failure"
			Case IP_PENDING : Msg = "ip pending"
			Case PING_TIMEOUT : Msg = "ping timeout"
			Case Else : Msg = "unknown msg returned"
		End Select
		
		GetStatusCode = CStr(status) & " [ " & Msg & " ]"
		
	End Function
	
	
	Public Function HiByte(ByVal wParam As Short) As Object
		
		'UPGRADE_WARNING: 未能解析对象 HiByte 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		HiByte = wParam And &H100 And &HFF
		
	End Function
	
	
	Public Function LoByte(ByVal wParam As Short) As Object
		
		'UPGRADE_WARNING: 未能解析对象 LoByte 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		LoByte = wParam And &HFF
		
	End Function
	
	
	Public Function Ping(ByRef szAddress As String) As Boolean
		
		Dim hPort As Integer
		Dim dwAddress As Integer
		Dim sDataToSend As String
		Dim iOpt As Integer
		Dim ECHO As ICMP_ECHO_REPLY
		sDataToSend = "Echo This"
		dwAddress = AddressStringToLong(szAddress)
		
		Call SocketsInitialize()
		hPort = IcmpCreateFile()
		
		If IcmpSendEcho(hPort, dwAddress, sDataToSend, Len(sDataToSend), 0, ECHO, Len(ECHO), PING_TIMEOUT) Then
			Ping = True
		Else : Ping = False
		End If
		
		Call IcmpCloseHandle(hPort)
		Call SocketsCleanup()
		
	End Function
	
	
	Function AddressStringToLong(ByVal tmp As String) As Integer
		
		Dim i As Short
		'UPGRADE_WARNING: 数组 parts 的下限已由 1 更改为 0。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"”
		Dim parts(4) As String
		
		i = 0
		
		'we have to extract each part of the
		'123.456.789.123 string, delimited by
		'a period
		While InStr(tmp, ".") > 0
			i = i + 1
			parts(i) = Mid(tmp, 1, InStr(tmp, ".") - 1)
			tmp = Mid(tmp, InStr(tmp, ".") + 1)
		End While
		
		i = i + 1
		parts(i) = tmp
		
		If i <> 4 Then
			AddressStringToLong = 0
			Exit Function
		End If
		
		'build the long value out of the
		'hex of the extracted strings
		AddressStringToLong = Val("&H" & Right("00" & Hex(CInt(parts(4))), 2) & Right("00" & Hex(CInt(parts(3))), 2) & Right("00" & Hex(CInt(parts(2))), 2) & Right("00" & Hex(CInt(parts(1))), 2))
		
	End Function
	
	
	Public Function SocketsCleanup() As Boolean
		
		Dim X As Integer
		
		X = WSACleanup()
		
		If X <> 0 Then
			MsgBox("Windows Sockets error " & Trim(Str(X)) & " occurred in Cleanup.", MsgBoxStyle.Exclamation)
			SocketsCleanup = False
		Else
			SocketsCleanup = True
		End If
		
	End Function
	
	
	Public Function SocketsInitialize() As Boolean
		
		'UPGRADE_WARNING: 结构 WSAD 中的数组可能需要先初始化才可以使用。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"”
		Dim WSAD As WSADATA
		Dim X As Short
		Dim szHiByte, szLoByte, szBuf As String
		
		X = WSAStartup(WS_VERSION_REQD, WSAD)
		
		If X <> 0 Then
			MsgBox("Windows Sockets for 32 bit Windows " & "environments is not successfully responding.")
			SocketsInitialize = False
			Exit Function
		End If
		
		'UPGRADE_WARNING: 未能解析对象 HiByte(WSAD.wVersion) 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		'UPGRADE_WARNING: 未能解析对象 LoByte(WSAD.wVersion) 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		If LoByte(WSAD.wVersion) < WS_VERSION_MAJOR Or (LoByte(WSAD.wVersion) = WS_VERSION_MAJOR And HiByte(WSAD.wVersion) < WS_VERSION_MINOR) Then
			
			'UPGRADE_WARNING: 未能解析对象 HiByte() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			szHiByte = Trim(Str(HiByte(WSAD.wVersion)))
			'UPGRADE_WARNING: 未能解析对象 LoByte() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			szLoByte = Trim(Str(LoByte(WSAD.wVersion)))
			szBuf = "Windows Sockets Version " & szLoByte & "." & szHiByte
			szBuf = szBuf & " is not supported by Windows " & "Sockets for 32 bit Windows environments."
			MsgBox(szBuf, MsgBoxStyle.Exclamation)
			SocketsInitialize = False
			Exit Function
			
		End If
		
		If WSAD.wMaxSockets < MIN_SOCKETS_REQD Then
			szBuf = "This application requires a minimum of " & Trim(Str(MIN_SOCKETS_REQD)) & " supported sockets."
			MsgBox(szBuf, MsgBoxStyle.Exclamation)
			SocketsInitialize = False
			Exit Function
		End If
		
		SocketsInitialize = True
		
	End Function
End Module