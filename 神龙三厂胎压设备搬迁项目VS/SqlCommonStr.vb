Public Class SqlCommonStr
	Public Sub insertColl(ByRef code As String)
		On Error Resume Next
		Dim cnn As New ADODB.Connection
		cnn.Open(DBCnnStr)
		cnn.Execute("insert into vincoll(vin) values ('" & code & "')")
		cnn.Close()
		'UPGRADE_NOTE: 在对对象 cnn 进行垃圾回收前，不可以将其销毁。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"”
		cnn = Nothing
	End Sub
End Class
