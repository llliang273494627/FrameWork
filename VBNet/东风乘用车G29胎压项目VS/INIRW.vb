Option Strict Off
Option Explicit On
Module winini
	'////////////////////windows ini 标准配置文件动态链接文件处理库  ///////////////////

	'UPGRADE_ISSUE: 不支持将参数声明为“As Any”。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"”
	Declare Function GetPrivateProfileString Lib "KERNEL32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Object, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
	'UPGRADE_ISSUE: 不支持将参数声明为“As Any”。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"”
	'UPGRADE_ISSUE: 不支持将参数声明为“As Any”。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"”
	Declare Function WritePrivateProfileString Lib "KERNEL32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Object, ByVal lpString As Object, ByVal lpFileName As String) As Integer
	Declare Function WritePrivateProfileSection Lib "KERNEL32"  Alias "WritePrivateProfileSectionA"(ByVal lpAppName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
	Public Declare Function GetPrivateProfileInt Lib "KERNEL32"  Alias "GetPrivateProfileIntA"(ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal nDefault As Integer, ByVal lpFileName As String) As Integer
	
	
	
	Declare Function SetWindowsHookEx Lib "user32"  Alias "SetWindowsHookExA"(ByVal idHook As Integer, ByVal lpfn As Integer, ByVal hmod As Integer, ByVal dwThreadId As Integer) As Integer
	
	Declare Function UnhookWindowsHookEx Lib "user32" (ByVal hHook As Integer) As Integer

	'UPGRADE_ISSUE: 不支持将参数声明为“As Any”。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"”
	Declare Function CallNextHookEx Lib "user32" (ByVal hHook As Integer, ByVal ncode As Integer, ByVal wParam As Integer, ByRef lParam As Object) As Integer

	Const WH_KEYBOARD As Short = 2
	
	Dim hHook As Integer
	
	
	
	Public Function GetIniS(ByVal SectionName As String, ByVal KeyWord As String, ByVal DefString As String, ByVal Path As String) As String
		Dim ResultString As New VB6.FixedLengthString(144)
		Dim Temp As Short
		Dim s As String
		Dim i As Short
		
		Temp = GetPrivateProfileString(SectionName, KeyWord, "", ResultString.Value, 144, Path)
		'检索关键词的值
		If Temp > 0 Then '关键词的值不为空
			s = ""
			For i = 1 To 144
				If Asc(Mid(ResultString.Value, i, 1)) = 0 Then
					Exit For
				Else
					s = s & Mid(ResultString.Value, i, 1)
				End If
			Next 
		Else
			Temp = WritePrivateProfileString(SectionName, KeyWord, DefString, Path)
			'将缺省值写入INI文件
			s = DefString
		End If
		GetIniS = s
	End Function
	
	Public Function GetIniN(ByVal SectionName As String, ByVal KeyWord As String, ByVal DefValue As Integer, ByVal Path As String) As Integer
		Dim d As Integer
		Dim s As String
		
		d = DefValue
		GetIniN = GetPrivateProfileInt(SectionName, KeyWord, DefValue, Path)
		If d <> DefValue Then
			s = "" & d
			d = WritePrivateProfileString(SectionName, KeyWord, s, Path)
		End If
	End Function
	
	Public Sub SetIniS(ByVal SectionName As String, ByVal KeyWord As String, ByVal ValStr As String, ByVal Path As String)
		Dim res As Short
		res = WritePrivateProfileString(SectionName, KeyWord, ValStr, Path)
	End Sub
	
	Public Sub SetIniN(ByVal SectionName As String, ByVal KeyWord As String, ByVal ValInt As Short, ByVal Path As String)
		Dim res As Short
		Dim s As String
		s = Str(ValInt)
		res = WritePrivateProfileString(SectionName, KeyWord, s, Path)
	End Sub
	
	Public Sub DeleteAllKeyWords(ByVal SectionName As String, ByVal Path As String)
		WritePrivateProfileSection(SectionName, "", Path)
	End Sub
	
	Public Sub DeleteKeyWord(ByVal SectionName As String, ByVal KeyWord As String, ByVal Path As String)
		WritePrivateProfileString(SectionName, KeyWord, "", Path)
	End Sub
	
	Public Function GetNode(ByVal change_str As String, ByVal findstr As String, ByVal strtype As Short) As String
		Dim i As Object
		'Dim nodetype() As String
		'nodetype = Split(change_str, "||")
		'MsgBox change_str
		'MsgBox nodetype(0)
		
		Dim Node() As String
		Node = Split(change_str, vbCrLf)
		
		Dim NodeStr() As String
		
		
		For i = 0 To UBound(Node)
			'UPGRADE_WARNING: 未能解析对象 i 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			If Trim(Node(i)) <> "" Then
				'UPGRADE_WARNING: 未能解析对象 i 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
				NodeStr = Split(Node(i), "*")
				If NodeStr(0) = findstr Then
					'UPGRADE_WARNING: 未能解析对象 i 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
					If Node(i) <> findstr & "*" Then
						GetNode = NodeStr(1)
						Exit Function
					Else
						GetNode = "0"
						Exit Function
					End If
				End If
			End If
		Next i
		
		GetNode = "0"
	End Function
End Module