Public Class frmAccueil

    ' Par jonathan lafreniere
    ' Calendrier des évenements à venir
    ' Évènements à venir cette semaine

    Private Sub frmAccueil_Load(sender As Object, e As EventArgs) Handles MyBase.Shown



        Dim p As New PanelSemaine(210, 140, 750, 150)
        Dim cal As New Calendrier(240, 340, 700, 600, Date.Now)
        Controls.Add(New Header(Me))
        Controls.Add(p)
        Controls.Add(cal)


        Dim pa As New Panel()
        pa.BackColor = Color.LightGray
        pa.SetBounds(1000, 190, 450, 600)
        Me.Controls.Add(pa)


        MsgBox("test")
    End Sub


    Private Sub centrer() Handles MyBase.GotFocus
        Me.Location = New Point(CInt((Screen.PrimaryScreen.WorkingArea.Width / 2) - (Me.Width / 2)), CInt((Screen.PrimaryScreen.WorkingArea.Height / 2) - (Me.Height / 2)))
        AutoScroll = True
        Text = "Accueil"
    End Sub

    Private Sub frmAccueil_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class