Option Strict Off
Option Explicit On
Friend Class CFY
	
	Dim stableName As String
	Dim skeyField As String
	Dim CnnStr As String
	Dim sselectMember As String
	Dim swhereMenber As String
	Dim spageCount As Integer
	Dim spaginalRecordCount As Integer
	Dim spageNum As Integer
	Dim SqlStr As String
	Dim cnn As ADODB.Connection
	Dim srecordCount As Integer
	Dim rs As ADODB.Recordset
	
	Public WriteOnly Property ConnectionString() As String
		Set(ByVal Value As String)
			On Error Resume Next
			CnnStr = Value
			cnn.Open(CnnStr)
			
			If Err.Number <> 0 Then
				Err.Raise(400000,  , "连接错误！错误信息：" & Err.Description)
			End If
			
		End Set
	End Property
	
	
	Public Property tableName() As String
		Get
			tableName = stableName
		End Get
		Set(ByVal Value As String)
			stableName = Value
		End Set
	End Property
	
	Public Property PageNum() As Integer
		Get
			PageNum = spageNum
		End Get
		Set(ByVal Value As Integer)
			spageNum = Value
		End Set
	End Property
	
	
	Public Property KeyField() As String
		Get
			KeyField = skeyField
		End Get
		Set(ByVal Value As String)
			skeyField = Value
		End Set
	End Property
	
	
	Public WriteOnly Property SelectMember() As String
		Set(ByVal Value As String)
			sselectMember = Value
		End Set
	End Property
	
	Public WriteOnly Property WhereMenber() As String
		Set(ByVal Value As String)
			swhereMenber = Value
		End Set
	End Property
	
	
	Public ReadOnly Property SelectSqlStr() As String
		Get
			SelectSqlStr = SqlStr
		End Get
	End Property
	Public ReadOnly Property PageCount() As Integer
		Get
			PageCount = spageCount
		End Get
	End Property



	Public Sub getRecordSet(ByRef record As ADODB.Recordset)
		On Error GoTo getRecordSet_Err
		If stableName = "" Then
			'Err.Raise 270002, "", "属性TableName没有配置！"
			Exit Sub
		End If
		If skeyField = "" Then
			'Err.Raise 270003, "", "属性KeyField没有配置！"
			Exit Sub
		End If

		Dim tmpSqlStr As String
		Dim tmpArr() As Object
		'UPGRADE_NOTE: 在对对象 record 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		record = Nothing
		tmpSqlStr = "select " & skeyField & " from " & stableName & " where 1=1 " & swhereMenber


		rs = cnn.Execute(tmpSqlStr)


		If Not rs.EOF Then
			'UPGRADE_WARNING: 未能解析对象 rs.GetRows 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			tmpArr = rs.GetRows
			srecordCount = UBound(tmpArr, 2) + 1
		Else
			record = rs
			SqlStr = ""
			Exit Sub
		End If

		Dim remainder As Integer
		remainder = srecordCount Mod spaginalRecordCount
		If remainder = 0 Then
			spageCount = srecordCount \ spaginalRecordCount
		Else
			spageCount = (srecordCount \ spaginalRecordCount) + 1
		End If

		Dim fromInt As Integer
		Dim toInt As Integer

		If spageNum < spageCount Then
			fromInt = spaginalRecordCount * (spageNum - 1)
			toInt = spaginalRecordCount * spageNum - 1
		ElseIf spageNum = spageCount Then
			fromInt = spaginalRecordCount * (spageNum - 1)
			toInt = UBound(tmpArr, 2)
		ElseIf spageNum > spageCount Then
			'Err.Raise 270002, , "属性spageNum(当前页数)大于总页数！"
			Exit Sub
		End If

		Dim i As Integer
		Dim inINStr As String
		inINStr = ""
		For i = fromInt To toInt
			'UPGRADE_WARNING: 未能解析对象 tmpArr() 的默认属性。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"”
			inINStr = inINStr & tmpArr(i) & ","
		Next
		inINStr = Left(inINStr, Len(inINStr) - 1)
		SqlStr = "select " & sselectMember & " from " & stableName & " where " & skeyField & " in (" & inINStr & ")"
		rs = cnn.Execute(SqlStr)

		record = rs

		Exit Sub
getRecordSet_Err:
		MsgBox(Err.Description)
	End Sub

	Public Sub New()
		MyBase.New()
		cnn = New ADODB.Connection
		spaginalRecordCount = 50
		sselectMember = "*"
		srecordCount = 0
		spageNum = 1
	End Sub

End Class