Public Class Header
    Inherits Panel

    Dim currentForm As Form
    Public pbLogo As PictureBox
    Dim OngletOffset As Integer = 60
    Dim f As New Font("Segoe UI", 14.25, FontStyle.Bold)
    Dim nomOnglets() As String = {"Accueil", "Agenda", "Inventaire", "Produits", "Recettes"}
    Dim formulairesOnglets() As Form = {frmAccueil, frmAgenda, frmInventaire, frmProduits, frmVoirRecettes}

    'Par Jonathan Lafrenière
    'En tête de tous les formulaires, gestion de la transition entre les onglets

    Public Sub New(currentForm As Form, tabs As Boolean)

        Me.currentForm = currentForm
        Height = 50
        BackColor = Color.FromArgb(0, 176, 240)
        Dock = DockStyle.Top

        pbLogo = New PictureBox()
        pbLogo.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory & "logo.png")

        pbLogo.SetBounds(10, 5, 40, 40)
        pbLogo.SizeMode = PictureBoxSizeMode.StretchImage

        AddHandler pbLogo.Click, Sub(sender2, eventargs2)
                                     Try
                                         currentForm.Hide()
                                         frmAccueil.Show()

                                     Catch exc As Exception : End Try
                                 End Sub


        Controls.Add(pbLogo)
        If tabs Then



            Dim str() As String = nomOnglets
            Dim frm() As Form = formulairesOnglets



            For i As Integer = 0 To nomOnglets.Length - 1
                If currentForm.Text = str(i) Then
                    ajouterOnglet(str(i), frm(i), True)
                Else
                    ajouterOnglet(str(i), frm(i), False)
                End If
            Next
        Else

            Dim lbl As New Label
            lbl.Font = New Font("Segoe UI", 20.25, FontStyle.Bold)
            lbl.ForeColor = Color.White

            lbl.AutoSize = True
            lbl.SetBounds(60, 5, 0, 0)
            lbl.Text = currentForm.Text
            Controls.Add(lbl)

            currentForm.FormBorderStyle = FormBorderStyle.None

        End If

    End Sub


    Private Sub ajouterOnglet(btnText As String, form As Form, currentTab As Boolean)

        Dim lbl As New Label

        Dim pnl As New Panel()
        lbl.Text = btnText
        lbl.Font = f
        lbl.ForeColor = Color.White

        Dim clipRect As New Rectangle


        If currentTab Then
            pnl.BackColor = Color.White
            lbl.ForeColor = Color.FromArgb(0, 176, 240)
        Else
            pnl.BackColor = Color.FromArgb(0, 176, 240)
            AddHandler lbl.Click, Sub(sender2, eventargs2)
                                      Try
                                          currentForm.Hide()
                                          form.Show()
                                          pnl.BackColor = Color.FromArgb(0, 176, 240)

                                      Catch exc As Exception : End Try
                                  End Sub
            AddHandler pnl.Click, Sub(sender2, eventargs2)
                                      Try
                                          currentForm.Hide()
                                          form.Show()
                                          pnl.BackColor = Color.FromArgb(0, 176, 240)

                                      Catch exc As Exception : End Try
                                  End Sub


            AddHandler pnl.MouseEnter, Sub(sender2, eventargs2)
                                           pnl.BackColor = Color.FromArgb(0, 176 * 1.2, 255)


                                       End Sub

            AddHandler pnl.MouseLeave, Sub(sender2, eventargs2)
                                           pnl.BackColor = Color.FromArgb(0, 176, 240)


                                       End Sub

            AddHandler lbl.MouseEnter, Sub(sender2, eventargs2)
                                           pnl.BackColor = Color.FromArgb(0, 176 * 1.2, 255)

                                       End Sub
        End If

        lbl.AutoSize = True
        lbl.SetBounds(20, 20, 0, 0)




        pnl.Controls.Add(lbl)
        pnl.SetBounds(OngletOffset, 0, lbl.Width + 40, 100)



        Controls.Add(pnl)




        OngletOffset = pnl.Location.X + pnl.Width
    End Sub

End Class

