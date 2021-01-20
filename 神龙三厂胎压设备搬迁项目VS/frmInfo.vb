Option Strict Off
Option Explicit On
Friend Class frmInfo
	Inherits System.Windows.Forms.Form

    '鼠标按下左键是的坐标点
    Private mousePoint As Point

    Private Sub frmInfo_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            mousePoint = e.Location
        End If
    End Sub

    Private Sub frmInfo_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = MouseButtons.Left Then
            Dim x As Integer
            Dim y As Integer
            x = e.X - mousePoint.X
            y = e.Y - mousePoint.Y
            Location = Point.Add(Location, New Size(x, y))
        End If
    End Sub
End Class