Option Strict Off
Option Explicit On

Imports System.IO
Imports System.Text

Module log
    Private Sub LogWrite(ByVal dirPath As String, ByVal fileName As String, ByVal message As String)
        Dim path As String = IO.Path.Combine(Directory.GetCurrentDirectory(), dirPath)
        If IO.Directory.Exists(path) = False Then
            IO.Directory.CreateDirectory(path)
        End If
        Dim fileFullName As String = IO.Path.Combine(path, fileName)
        Dim stream As FileStream = New FileStream(fileFullName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
        Dim write As StreamWriter = New StreamWriter(stream)
        write.WriteLine(Date.Now.ToString() + " " + message)
        write.Flush()
        write.Close()
    End Sub

    Public Sub LogWritter(ByRef txt As String) '写日志,追加模式,
        LogWrite("Log", Today.ToString("yyyyMMdd") + "_Log.txt", txt)
    End Sub

    Public Sub LogError(ByVal ex As Exception)
        Dim str As StringBuilder = New StringBuilder
        str.AppendLine(ex.Message)
        str.AppendLine(ex.StackTrace)
        LogWrite("Log", Today.ToString("yyyyMMdd") + "_Error.txt", str.ToString)
    End Sub

    Public Sub LogError(mes As String, ByVal ex As Exception)
        Dim str As StringBuilder = New StringBuilder
        str.AppendLine(mes)
        str.AppendLine(ex.Message)
        str.AppendLine(ex.StackTrace)
        LogWrite("Log", Today.ToString("yyyyMMdd") + "_Error.txt", str.ToString)
    End Sub

    Public Sub SensorLogWritter(ByRef txt As String) '写日志,追加模式,
        LogWrite("SensorLog", Today.ToString("yyyyMMdd") + ".txt", txt)
    End Sub

End Module