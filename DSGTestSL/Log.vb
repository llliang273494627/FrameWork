Option Strict Off
Option Explicit On
Module log
	'可以写入数据，追加模式
	'默认写到当前目录下Log目录内，以当前日期命名的txt文件
	Public Sub LogWritter(ByRef txt As String) '写日志,追加模式,
		Dim FSO As New Scripting.FileSystemObject
		Dim fil As Scripting.File
		Dim ts As Scripting.TextStream
		Dim typeid As Short
		Dim NowOutput, NowOutputDir As String

		On Error Resume Next

		NowOutputDir = My.Application.Info.DirectoryPath & "\Log"
		NowOutput = My.Application.Info.DirectoryPath & "\Log\" & Today.ToString("yyyyMMdd") & ".txt"
		FSO = CreateObject("Scripting.Filesystemobject")

		'UPGRADE_WARNING: Dir 有新行为。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"”
		If Trim(Dir(NowOutputDir, FileAttribute.Directory)) = "" Then
			FSO.CreateFolder(NowOutputDir)
		End If
		'UPGRADE_WARNING: Dir 有新行为。 单击以获得更多信息:“ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"”
		If Trim(Dir(NowOutput)) = "" Then
			FSO.CreateTextFile(NowOutput, False)
		End If

		fil = FSO.GetFile(NowOutput)
		ts = fil.OpenAsTextStream(Scripting.IOMode.ForWriting)

		ts.Write("[" & Now & "]" & txt & vbCrLf)
		ts.Close()
	End Sub
	'////////////////////////END/////////////////////////////////
	Public Sub SensorLogWritter(ByRef txt As String) '写日志,追加模式,
		LogWritter(txt)
	End Sub

End Module