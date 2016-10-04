Public Class frmProduits
    Private Sub frmProduits_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        Controls.Add(New Header(Me, False))
        Me.BackColor = Color.White
    End Sub

    Private Sub frmProduits_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class