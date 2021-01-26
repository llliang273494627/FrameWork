Option Strict Off
Option Explicit On
Module modMD5
	'Option Explicit
	
	
	
	' Visual Basic MD5 Implementation
	' Robert Hubley and David Midkiff (mdj2023@hotmail.com)
	' modify by simonyan, Support chinese
	' Standard MD5 implementation optimised for the Visual Basic environment.
	' Conforms to all standards and can be used in digital signature or password
	' protection related schemes.
	
	Private Const OFFSET_4 As Double = 4294967296#
	Private Const MAXINT_4 As Double = 2147483647
	Private state(4) As Integer
	Private ByteCounter As Integer
	Private ByteBuffer(63) As Byte
	Private Const S11 As Short = 7
	Private Const S12 As Short = 12
	Private Const S13 As Short = 17
	Private Const S14 As Short = 22
	Private Const S21 As Short = 5
	Private Const S22 As Short = 9
	Private Const S23 As Short = 14
	Private Const S24 As Short = 20
	Private Const S31 As Short = 4
	Private Const S32 As Short = 11
	Private Const S33 As Short = 16
	Private Const S34 As Short = 23
	Private Const S41 As Short = 6
	Private Const S42 As Short = 10
	Private Const S43 As Short = 15
	Private Const S44 As Short = 21
	ReadOnly Property RegisterA() As String
		Get
			RegisterA = CStr(state(1))
		End Get
	End Property
	ReadOnly Property RegisterB() As String
		Get
			RegisterB = CStr(state(2))
		End Get
	End Property
	
	ReadOnly Property RegisterC() As String
		Get
			RegisterC = CStr(state(3))
		End Get
	End Property
	
	ReadOnly Property RegisterD() As String
		Get
			RegisterD = CStr(state(4))
		End Get
	End Property
	Public Function Md5_String_Calc(ByRef SourceString As String) As String
		MD5Init()
		'UPGRADE_ISSUE: 常量 vbFromUnicode 未升级。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"”
		'UPGRADE_ISSUE: 不支持 LenB 函数。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"”
        MD5Update(StringToArray(SourceString).Length, StringToArray(SourceString))
		MD5Final()
		Md5_String_Calc = GetValues
	End Function
	Public Function Md5_File_Calc(ByRef InFile As String) As String
		Dim DigestFileToHexStr As Object
		On Error GoTo Errorhandler
		'UPGRADE_ISSUE: 不支持 GoSub 语句。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"”
        'GoSub begin
        Dim FileO As Short
        FileO = FreeFile()
        Call FileLen(InFile)
        FileOpen(FileO, InFile, OpenMode.Binary, OpenAccess.Read)
        MD5Init()
        Do While Not EOF(FileO)
            'UPGRADE_WARNING: Get 已升级到 FileGet 并具有新行为。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"”
            FileGet(FileO, ByteBuffer)
            If Loc(FileO) < LOF(FileO) Then
                ByteCounter = ByteCounter + 64
                MD5Transform(ByteBuffer)
            End If
        Loop
        ByteCounter = ByteCounter + (LOF(FileO) Mod 64)
        FileClose(FileO)
        MD5Final()
        Md5_File_Calc = GetValues()
		
Errorhandler: 
		'UPGRADE_WARNING: 未能解析对象 DigestFileToHexStr 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
		DigestFileToHexStr = ""
		Exit Function

		
	End Function
	Private Function StringToArray(ByRef InString As String) As Byte()
		Dim i As Short
		Dim bytBuffer() As Byte
		'UPGRADE_ISSUE: 常量 vbFromUnicode 未升级。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"”
		'UPGRADE_ISSUE: 不支持 LenB 函数。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"”
        'ReDim bytBuffer(LenB(StrConv(InString, vbFromUnicode)))
		'UPGRADE_ISSUE: 常量 vbFromUnicode 未升级。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"”
		'UPGRADE_TODO: 代码已升级为使用可能具有不同行为的 System.Text.UnicodeEncoding.Unicode.GetBytes()。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="93DD716C-10E3-41BE-A4A8-3BA40157905B"”
        bytBuffer = System.Text.UnicodeEncoding.Unicode.GetBytes(InString)
		StringToArray = VB6.CopyArray(bytBuffer)
	End Function
	Public Function GetValues() As String
		GetValues = LongToString(state(1)) & LongToString(state(2)) & LongToString(state(3)) & LongToString(state(4))
	End Function
	Private Function LongToString(ByRef Num As Integer) As String
		Dim C, A, B, d As Byte
		A = Num And &HFF
		If A < 16 Then LongToString = "0" & Hex(A) Else LongToString = Hex(A)
		B = (Num And &HFF00) \ 256
		If B < 16 Then LongToString = LongToString & "0" & Hex(B) Else LongToString = LongToString & Hex(B)
		C = (Num And &HFF0000) \ 65536
		If C < 16 Then LongToString = LongToString & "0" & Hex(C) Else LongToString = LongToString & Hex(C)
		If Num < 0 Then d = ((Num And &H7F000000) \ 16777216) Or &H80 Else d = (Num And &HFF000000) \ 16777216
		If d < 16 Then LongToString = LongToString & "0" & Hex(d) Else LongToString = LongToString & Hex(d)
	End Function
	
	Public Sub MD5Init()
		ByteCounter = 0
		state(1) = UnsignedToLong(1732584193#)
		state(2) = UnsignedToLong(4023233417#)
		state(3) = UnsignedToLong(2562383102#)
		state(4) = UnsignedToLong(271733878#)
	End Sub
	
	Public Sub MD5Final()
		Dim dblBits As Double
		Dim padding(72) As Byte
		Dim lngBytesBuffered As Integer
		padding(0) = &H80
		dblBits = ByteCounter * 8
		lngBytesBuffered = ByteCounter Mod 64
		If lngBytesBuffered <= 56 Then MD5Update(56 - lngBytesBuffered, padding) Else MD5Update(120 - ByteCounter, padding)
		padding(0) = UnsignedToLong(dblBits) And &HFF
		padding(1) = UnsignedToLong(dblBits) \ 256 And &HFF
		padding(2) = UnsignedToLong(dblBits) \ 65536 And &HFF
		padding(3) = UnsignedToLong(dblBits) \ 16777216 And &HFF
		padding(4) = 0
		padding(5) = 0
		padding(6) = 0
		padding(7) = 0
		MD5Update(8, padding)
	End Sub
	Public Sub MD5Update(ByRef InputLen As Integer, ByRef InputBuffer() As Byte)
		Dim J, II, i, K As Short
		Dim lngBufferRemaining, lngBufferedBytes, lngRem As Integer
		
		lngBufferedBytes = ByteCounter Mod 64
		lngBufferRemaining = 64 - lngBufferedBytes
		ByteCounter = ByteCounter + InputLen
		
		If InputLen >= lngBufferRemaining Then
			For II = 0 To lngBufferRemaining - 1
				ByteBuffer(lngBufferedBytes + II) = InputBuffer(II)
			Next II
			MD5Transform(ByteBuffer)
			lngRem = (InputLen) Mod 64
			For i = lngBufferRemaining To InputLen - II - lngRem Step 64
				For J = 0 To 63
					ByteBuffer(J) = InputBuffer(i + J)
				Next J
				MD5Transform(ByteBuffer)
			Next i
			lngBufferedBytes = 0
		Else
			i = 0
		End If
		For K = 0 To InputLen - i - 1
			ByteBuffer(lngBufferedBytes + K) = InputBuffer(i + K)
		Next K
	End Sub
	Private Sub MD5Transform(ByRef Buffer() As Byte)
		Dim X(16) As Integer
		Dim C, A, B, d As Integer
		
		A = state(1)
		B = state(2)
		C = state(3)
		d = state(4)
		Decode(64, X, Buffer)
		FF(A, B, C, d, X(0), S11, -680876936)
		FF(d, A, B, C, X(1), S12, -389564586)
		FF(C, d, A, B, X(2), S13, 606105819)
		FF(B, C, d, A, X(3), S14, -1044525330)
		FF(A, B, C, d, X(4), S11, -176418897)
		FF(d, A, B, C, X(5), S12, 1200080426)
		FF(C, d, A, B, X(6), S13, -1473231341)
		FF(B, C, d, A, X(7), S14, -45705983)
		FF(A, B, C, d, X(8), S11, 1770035416)
		FF(d, A, B, C, X(9), S12, -1958414417)
		FF(C, d, A, B, X(10), S13, -42063)
		FF(B, C, d, A, X(11), S14, -1990404162)
		FF(A, B, C, d, X(12), S11, 1804603682)
		FF(d, A, B, C, X(13), S12, -40341101)
		FF(C, d, A, B, X(14), S13, -1502002290)
		FF(B, C, d, A, X(15), S14, 1236535329)
		
		GG(A, B, C, d, X(1), S21, -165796510)
		GG(d, A, B, C, X(6), S22, -1069501632)
		GG(C, d, A, B, X(11), S23, 643717713)
		GG(B, C, d, A, X(0), S24, -373897302)
		GG(A, B, C, d, X(5), S21, -701558691)
		GG(d, A, B, C, X(10), S22, 38016083)
		GG(C, d, A, B, X(15), S23, -660478335)
		GG(B, C, d, A, X(4), S24, -405537848)
		GG(A, B, C, d, X(9), S21, 568446438)
		GG(d, A, B, C, X(14), S22, -1019803690)
		GG(C, d, A, B, X(3), S23, -187363961)
		GG(B, C, d, A, X(8), S24, 1163531501)
		GG(A, B, C, d, X(13), S21, -1444681467)
		GG(d, A, B, C, X(2), S22, -51403784)
		GG(C, d, A, B, X(7), S23, 1735328473)
		GG(B, C, d, A, X(12), S24, -1926607734)
		
		HH(A, B, C, d, X(5), S31, -378558)
		HH(d, A, B, C, X(8), S32, -2022574463)
		HH(C, d, A, B, X(11), S33, 1839030562)
		HH(B, C, d, A, X(14), S34, -35309556)
		HH(A, B, C, d, X(1), S31, -1530992060)
		HH(d, A, B, C, X(4), S32, 1272893353)
		HH(C, d, A, B, X(7), S33, -155497632)
		HH(B, C, d, A, X(10), S34, -1094730640)
		HH(A, B, C, d, X(13), S31, 681279174)
		HH(d, A, B, C, X(0), S32, -358537222)
		HH(C, d, A, B, X(3), S33, -722521979)
		HH(B, C, d, A, X(6), S34, 76029189)
		HH(A, B, C, d, X(9), S31, -640364487)
		HH(d, A, B, C, X(12), S32, -421815835)
		HH(C, d, A, B, X(15), S33, 530742520)
		HH(B, C, d, A, X(2), S34, -995338651)
		
		II(A, B, C, d, X(0), S41, -198630844)
		II(d, A, B, C, X(7), S42, 1126891415)
		II(C, d, A, B, X(14), S43, -1416354905)
		II(B, C, d, A, X(5), S44, -57434055)
		II(A, B, C, d, X(12), S41, 1700485571)
		II(d, A, B, C, X(3), S42, -1894986606)
		II(C, d, A, B, X(10), S43, -1051523)
		II(B, C, d, A, X(1), S44, -2054922799)
		II(A, B, C, d, X(8), S41, 1873313359)
		II(d, A, B, C, X(15), S42, -30611744)
		II(C, d, A, B, X(6), S43, -1560198380)
		II(B, C, d, A, X(13), S44, 1309151649)
		II(A, B, C, d, X(4), S41, -145523070)
		II(d, A, B, C, X(11), S42, -1120210379)
		II(C, d, A, B, X(2), S43, 718787259)
		II(B, C, d, A, X(9), S44, -343485551)
		
		state(1) = LongOverflowAdd(state(1), A)
		state(2) = LongOverflowAdd(state(2), B)
		state(3) = LongOverflowAdd(state(3), C)
		state(4) = LongOverflowAdd(state(4), d)
	End Sub
	
	Private Sub Decode(ByRef Length As Short, ByRef OutputBuffer() As Integer, ByRef InputBuffer() As Byte)
		Dim intDblIndex, intByteIndex As Short
		Dim dblSum As Double
		For intByteIndex = 0 To Length - 1 Step 4
			dblSum = InputBuffer(intByteIndex) + InputBuffer(intByteIndex + 1) * 256# + InputBuffer(intByteIndex + 2) * 65536# + InputBuffer(intByteIndex + 3) * 16777216#
			OutputBuffer(intDblIndex) = UnsignedToLong(dblSum)
			intDblIndex = intDblIndex + 1
		Next intByteIndex
	End Sub
	Private Function FF(ByRef A As Integer, ByRef B As Integer, ByRef C As Integer, ByRef d As Integer, ByRef X As Integer, ByRef s As Integer, ByRef ac As Integer) As Integer
		A = LongOverflowAdd4(A, (B And C) Or (Not (B) And d), X, ac)
		A = LongLeftRotate(A, s)
		A = LongOverflowAdd(A, B)
	End Function
	Private Function GG(ByRef A As Integer, ByRef B As Integer, ByRef C As Integer, ByRef d As Integer, ByRef X As Integer, ByRef s As Integer, ByRef ac As Integer) As Integer
		A = LongOverflowAdd4(A, (B And d) Or (C And Not (d)), X, ac)
		A = LongLeftRotate(A, s)
		A = LongOverflowAdd(A, B)
	End Function
	Private Function HH(ByRef A As Integer, ByRef B As Integer, ByRef C As Integer, ByRef d As Integer, ByRef X As Integer, ByRef s As Integer, ByRef ac As Integer) As Integer
		A = LongOverflowAdd4(A, B Xor C Xor d, X, ac)
		A = LongLeftRotate(A, s)
		A = LongOverflowAdd(A, B)
	End Function
	Private Function II(ByRef A As Integer, ByRef B As Integer, ByRef C As Integer, ByRef d As Integer, ByRef X As Integer, ByRef s As Integer, ByRef ac As Integer) As Integer
		A = LongOverflowAdd4(A, C Xor (B Or Not (d)), X, ac)
		A = LongLeftRotate(A, s)
		A = LongOverflowAdd(A, B)
	End Function
	
	Function LongLeftRotate(ByRef value As Integer, ByRef Bits As Integer) As Integer
		Dim lngSign, lngI As Integer
		Bits = Bits Mod 32
		If Bits = 0 Then LongLeftRotate = value : Exit Function
		For lngI = 1 To Bits
			lngSign = value And &HC0000000
			value = CShort(value And &H3FFFFFFF) * 2
			value = value Or ((lngSign < 0) And 1) Or (CBool(lngSign And &H40000000) And &H80000000)
		Next 
		LongLeftRotate = value
	End Function
	Private Function LongOverflowAdd(ByRef Val1 As Integer, ByRef Val2 As Integer) As Integer
		Dim lngLowWord, lngHighWord, lngOverflow As Integer
		lngLowWord = CShort(Val1 And &HFFFF) + CShort(Val2 And &HFFFF)
		lngOverflow = lngLowWord \ 65536
		lngHighWord = (((Val1 And &HFFFF0000) \ 65536) + ((Val2 And &HFFFF0000) \ 65536) + lngOverflow) And &HFFFF
		LongOverflowAdd = UnsignedToLong((lngHighWord * 65536#) + CShort(lngLowWord And &HFFFF))
	End Function
	Private Function LongOverflowAdd4(ByRef Val1 As Integer, ByRef Val2 As Integer, ByRef val3 As Integer, ByRef val4 As Integer) As Integer
		Dim lngLowWord, lngHighWord, lngOverflow As Integer
		lngLowWord = CShort(CShort(CShort(Val1 And &HFFFF) + CShort(Val2 And &HFFFF)) + CShort(val3 And &HFFFF)) + CShort(val4 And &HFFFF)
		lngOverflow = lngLowWord \ 65536
		lngHighWord = (((Val1 And &HFFFF0000) \ 65536) + ((Val2 And &HFFFF0000) \ 65536) + ((val3 And &HFFFF0000) \ 65536) + ((val4 And &HFFFF0000) \ 65536) + lngOverflow) And &HFFFF
		LongOverflowAdd4 = UnsignedToLong((lngHighWord * 65536#) + CShort(lngLowWord And &HFFFF))
	End Function
	
	Private Function UnsignedToLong(ByRef value As Double) As Integer
		If value < 0 Or value >= OFFSET_4 Then Error(6)
		If value <= MAXINT_4 Then UnsignedToLong = value Else UnsignedToLong = value - OFFSET_4
	End Function
	Private Function LongToUnsigned(ByRef value As Integer) As Double
		If value < 0 Then LongToUnsigned = value + OFFSET_4 Else LongToUnsigned = value
	End Function
End Module