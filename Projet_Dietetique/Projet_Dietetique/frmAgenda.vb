Public Class frmAgenda
    Private Sub frmAgenda_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        Controls.Add(New Header(Me, True))
        Me.BackColor = Color.White
    End Sub

    Private Sub frmInventaire_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class