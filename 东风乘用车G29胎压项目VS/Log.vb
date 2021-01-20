Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Text

Module log
    'д����־�ļ�
    Private Sub LogWritter(txt As String, fileDir As String, fileName As String) 'д��־,׷��ģʽ,
        Try
            If Directory.Exists(fileDir) = False Then
                Directory.CreateDirectory(fileDir)
            End If
            fileName = Path.Combine(fileDir, fileName)

            Dim writeStream As Stream
            Dim write As StreamWriter
            writeStream = New FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.Write)
            write = New StreamWriter(writeStream, Encoding.UTF8)
            write.WriteLine($"[{Date.Now}]  {txt}")
            write.Flush()
            write.Close()
        Catch ex As Exception
        End Try
    End Sub

    'Ĭ��д����ǰĿ¼��LogĿ¼�ڣ��Ե�ǰ����������txt�ļ�
    Public Sub LogWritter(txt As String) 'д��־,׷��ģʽ,
        Dim NowOutput, NowOutputDir As String
        NowOutputDir = Path.Combine(Directory.GetCurrentDirectory(), "Log")
        NowOutput = Date.Now.ToString("yyyyMMdd") + ".txt"
        LogWritter(txt, NowOutputDir, NowOutput)
    End Sub

    Public Sub SensorLogWritter(txt As String) 'д��־,׷��ģʽ,
        Dim NowOutput, NowOutputDir As String
        NowOutputDir = Path.Combine(Directory.GetCurrentDirectory(), "SensorLog")
        NowOutput = Date.Now.ToString("yyyyMMdd") + ".txt"
        LogWritter(txt, NowOutputDir, NowOutput)
    End Sub

End Module