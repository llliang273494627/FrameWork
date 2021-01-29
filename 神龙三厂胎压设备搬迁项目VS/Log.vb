Option Strict Off
Option Explicit On

Imports System.IO

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
  
    '����д�����ݣ�׷��ģʽ
    'Ĭ��д����ǰĿ¼��LogĿ¼�ڣ��Ե�ǰ����������txt�ļ�
    Public Sub LogWritter(ByRef txt As String) 'д��־,׷��ģʽ,
        LogWrite("Log", Today.ToString("yyyyMMdd") + ".txt", txt)
    End Sub

    Public Sub LogError(ByVal ex As Exception)
        LogWrite("Log", Today.ToString("yyyyMMdd") + "_Error.txt", ex.Message)
        LogWrite("Log", Today.ToString("yyyyMMdd") + "_Error.txt", ex.StackTrace)
    End Sub
    '////////////////////////END/////////////////////////////////
    Public Sub SensorLogWritter(ByRef txt As String) 'д��־,׷��ģʽ,
        LogWrite("SensorLog", Today.ToString("yyyyMMdd") + ".txt", txt)
    End Sub
  
End Module