Option Strict Off
Option Explicit On
Module modApiPing

	Public Const PING_TIMEOUT As Short = 200
	Public Const WS_VERSION_REQD As Integer = &H101
	Public Const WS_VERSION_MAJOR As Boolean = WS_VERSION_REQD And &H100 And &HFF '///////////////////
	Public Const WS_VERSION_MINOR As Boolean = WS_VERSION_REQD And &HFF
	Public Const MIN_SOCKETS_REQD As Short = 1
	Public Const MAX_WSADescription As Short = 256
	Public Const MAX_WSASYSStatus As Short = 128
	
	Public Structure ICMP_OPTIONS
		Dim Ttl As Byte
		Dim Tos As Byte
		Dim Flags As Byte
		Dim OptionsSize As Byte
		Dim OptionsData As Integer
	End Structure

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

	Public Structure WSADATA
		Dim wVersion As Short
		Dim wHighVersion As Short
		<VBFixedArray(MAX_WSADescription)> Dim szDescription() As Byte
		<VBFixedArray(MAX_WSASYSStatus)> Dim szSystemStatus() As Byte
		Dim wMaxSockets As Short
		Dim wMaxUDPDG As Short
		Dim dwVendorInfo As Integer

	End Structure
	
	
	Public Declare Function IcmpCreateFile Lib "icmp.dll" () As Integer
	
	Public Declare Function IcmpCloseHandle Lib "icmp.dll" (ByVal IcmpHandle As Integer) As Integer
	
	'UPGRADE_WARNING: 结构 ICMP_ECHO_REPLY 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Public Declare Function IcmpSendEcho Lib "icmp.dll" (ByVal IcmpHandle As Integer, ByVal DestinationAddress As Integer, ByVal RequestData As String, ByVal RequestSize As Short, ByVal RequestOptions As Integer, ByRef ReplyBuffer As ICMP_ECHO_REPLY, ByVal ReplySize As Integer, ByVal Timeout As Integer) As Integer

	'UPGRADE_WARNING: 结构 WSADATA 可能要求封送处理属性作为此 Declare 语句中的参数传递。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"”
	Public Declare Function WSAStartup Lib "WSOCK32.DLL" (ByVal wVersionRequired As Integer, ByRef lpWSADATA As WSADATA) As Integer

	Public Declare Function WSACleanup Lib "WSOCK32.DLL" () As Integer

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