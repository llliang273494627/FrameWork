Option Strict Off
Option Explicit On
Friend Class frmShowLog
	Inherits System.Windows.Forms.Form

	Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateSelected

        If DateDiff(Microsoft.VisualBasic.DateInterval.Day, e.Start.Date, Today) < 0 Then
            MsgBox("对不起没有" & e.Start & "的日志！")
        Else
            Dim path = IO.Path.Combine(IO.Directory.GetCurrentDirectory(), "Log", e.Start.Date + ".txt")
            Shell("notepad " + path, AppWinStyle.NormalFocus)
        End If
    End Sub
End Class