Public Class frmAccueil

    ' Par jonathan lafreniere
    ' Calendrier des évenements à venir
    ' Évènements à venir cette semaine
    Dim btn As New PanelOptionsAccueil(1000, 190, 400, 2)
    Dim cal
    Public Property _date_selectionne As Date = Date.Today
    Dim p As New PanelSemaine(210, 140, 750, 150)

    Private Sub frmAccueil_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        cal = New Calendrier(240, 340, 700, 612, _date_selectionne)


        p.remplirSemaine(Date.Today)


        Controls.Add(New Header(Me, True))
        Controls.Add(p)
        Controls.Add(cal)

        Controls.Add(btn)

        btn.ajouterBouton(AppDomain.CurrentDomain.BaseDirectory & "imagesBoutons\agenda.png", frmAgenda, "Agenda")
        btn.ajouterBouton(AppDomain.CurrentDomain.BaseDirectory & "imagesBoutons\inventaire.png", frmInventaire, "Inventaire")
        btn.ajouterBouton(AppDomain.CurrentDomain.BaseDirectory & "imagesBoutons\produit.png", frmProduits, "Produits")
        btn.ajouterBouton(AppDomain.CurrentDomain.BaseDirectory & "imagesBoutons\recette.png", frmVoirRecettes, "Recettes")

        ''Dim pa As New Panel()
        ''pa.BackColor = Color.LightGray
        ''pa.SetBounds(1000, 190, 450, 600)
        ''Me.Controls.Add(pa)

        Dim refresh As New PictureBox()
        refresh.SetBounds(90, 90, 40, 40)
        refresh.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory & "imagesBoutons\refresh.png")
        refresh.SizeMode = PictureBoxSizeMode.StretchImage
        AddHandler refresh.Click, Sub(sender2, eventargs2)
                                      'CODE ICI

                                  End Sub

        AddHandler refresh.MouseEnter, Sub(sender2, eventargs2)
                                           refresh.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory & "imagesBoutons\refreshHover.png")
                                       End Sub
        AddHandler refresh.MouseLeave, Sub(sender2, eventargs2)
                                           refresh.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory & "imagesBoutons\refresh.png")
                                       End Sub
        AddHandler refresh.MouseDown, Sub(sender2, eventargs2)
                                          refresh.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory & "imagesBoutons\refreshDown.png")
                                      End Sub
        AddHandler refresh.MouseUp, Sub(sender2, eventargs2)
                                        refresh.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory & "imagesBoutons\refreshHover.png")
                                        _date_selectionne = Date.Today
                                        Controls.Remove(cal)
                                        cal = New Calendrier(240, 340, 700, 612, _date_selectionne)
                                        Controls.Add(cal)
                                    End Sub
        Controls.Add(refresh)
    End Sub

    Private Sub centrer() Handles MyBase.GotFocus
        Me.Location = New Point(CInt((Screen.PrimaryScreen.WorkingArea.Width / 2) - (Me.Width / 2)), CInt((Screen.PrimaryScreen.WorkingArea.Height / 2) - (Me.Height / 2)))
        AutoScroll = True
        Text = "Accueil"
    End Sub

    Private Sub frmAccueil_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized


        Dim btnSemPrecedente = New Button()
        Dim btnSemSuivante = New Button()

        btnSemPrecedente.FlatStyle = FlatStyle.Flat
        btnSemSuivante.FlatStyle = FlatStyle.Flat
        btnSemSuivante.ForeColor = Color.White
        btnSemSuivante.Font = New Font("Segoe UI", 14.25, FontStyle.Bold)
        btnSemPrecedente.BackColor = Color.FromArgb(0, 176, 240)
        btnSemSuivante.BackColor = Color.FromArgb(0, 176, 240)

        btnSemPrecedente.Text = "<<"
        btnSemPrecedente.Font = New Font("Segoe UI", 14.25, FontStyle.Bold)
        btnSemPrecedente.TextAlign = ContentAlignment.TopCenter
        btnSemPrecedente.SetBounds(Width / 4 - 50, 0, 100, 40)
        btnSemPrecedente.ForeColor = Color.White
        btnSemPrecedente.UseVisualStyleBackColor = True


        AddHandler btnSemPrecedente.Click, Sub(sender2, eventargs2)
                                               _date_selectionne = GetNextSaturday(_date_selectionne.AddDays(-7))
                                               Controls.Remove(cal)
                                               cal = New Calendrier(240, 340, 700, 612, _date_selectionne)
                                               Controls.Add(cal)

                                               p.remplirSemaine(_date_selectionne)


                                           End Sub

        btnSemSuivante.Text = ">>"
        Dim percent As Double = 0.23
        btnSemSuivante.SetBounds(p.Location.X + (p.Width * (1 - percent)), 80, 100, 40)
        btnSemPrecedente.SetBounds(p.Location.X + (p.Width * percent) - 100, 80, 100, 40)
        btnSemSuivante.UseVisualStyleBackColor = True


        AddHandler btnSemSuivante.Click, Sub(sender3, eventargs3)
                                             _date_selectionne = GetPreviousSunday(_date_selectionne.AddDays(7))




                                             Controls.Remove(cal)
                                             cal = New Calendrier(240, 340, 700, 612, _date_selectionne)
                                             Controls.Add(cal)

                                             p.remplirSemaine(_date_selectionne)
                                         End Sub
        Controls.Add(btnSemSuivante)
        Controls.Add(btnSemPrecedente)

        Dim lbl As New Label
        lbl.Font = New Font("Segoe UI", 14.25)
        lbl.TextAlign = ContentAlignment.MiddleCenter
        lbl.Text = "Semaine du " & GetPreviousSunday(_date_selectionne).Day & " " & MonthName(GetPreviousSunday(_date_selectionne).Month) & " au " & GetNextSaturday(_date_selectionne).Day & " " & MonthName(GetNextSaturday(_date_selectionne).Month)
        lbl.AutoSize = False
        lbl.SetBounds(btnSemPrecedente.Location.X + btnSemPrecedente.Width, 85, btnSemSuivante.Location.X - (btnSemPrecedente.Location.X + btnSemPrecedente.Width), 30)

        MsgBox(lbl.Width & ":)" & lbl.ToString)
        Controls.Add(lbl)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Function GetPreviousSunday(fromDate As Date) As Date
        Return fromDate.AddDays(0 - fromDate.DayOfWeek)
    End Function

    Function GetNextSaturday(fromDate As Date) As Date
        Return fromDate.AddDays(6 - fromDate.DayOfWeek)
    End Function


End Class

