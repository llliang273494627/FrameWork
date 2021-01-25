Option Strict Off
Option Explicit On
Friend Class FrmTest
	Inherits System.Windows.Forms.Form

    Dim iocard As IOCard
    Private Sub FrmTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        iocard = New IOCard
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub
End Class