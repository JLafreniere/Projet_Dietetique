Imports MySql.Data.MySqlClient

Public Class Calendrier
    Inherits Panel


    Dim ds As New DataSet
    Dim da As New MySqlDataAdapter
    Dim bd As New GestionBD("Server=localhost;Database=bd_application;Uid=root;Pwd=;")
    Dim lblAnneeMois As New Label
    Public mc As PanelMois
    Dim btnMoisPrecedent, btnMoisSuivant As Button
    '    Public Property _date_selectionne As Date = Date.Today
    Public Sub New(x As Integer, y As Integer, width As Integer, height As Integer, dateDebut As Date)

        SetBounds(x, y, width, height - 40)
        btnMoisPrecedent = New Button()
        btnMoisSuivant = New Button()

        btnMoisPrecedent.FlatStyle = FlatStyle.Flat
        btnMoisSuivant.FlatStyle = FlatStyle.Flat
        btnMoisSuivant.ForeColor = Color.White
        btnMoisSuivant.Font = New Font("Segoe UI", 14.25, FontStyle.Bold)
        btnMoisPrecedent.BackColor = Color.FromArgb(0, 176, 240)
        btnMoisSuivant.BackColor = Color.FromArgb(0, 176, 240)

        btnMoisPrecedent.Text = "<<"
        btnMoisPrecedent.Font = New Font("Segoe UI", 14.25, FontStyle.Bold)
        btnMoisPrecedent.TextAlign = ContentAlignment.TopCenter
        btnMoisPrecedent.SetBounds(width / 4 - 50, 0, 100, 40)
        btnMoisPrecedent.ForeColor = Color.White
        btnMoisPrecedent.UseVisualStyleBackColor = True

        AddHandler btnMoisPrecedent.Click, Sub(sender2, eventargs2)

                                               MsgBox(mc._date & " :) :) :) " & mc._date.AddMonths(-2))
                                               mc.setDate(mc._date.AddMonths(-3))
                                               ajouterNotifications()
                                               frmAccueil._date_selectionne = mc._date
                                               actualiserComposants()


                                           End Sub

        btnMoisSuivant.Text = ">>"
        btnMoisSuivant.SetBounds((3 * width) / 4 - 50, 0, 100, 40)

        btnMoisSuivant.UseVisualStyleBackColor = True

        AddHandler btnMoisSuivant.Click, Sub(sender3, eventargs3)

                                             mc.setDate(mc._date.AddMonths(-1))
                                             ajouterNotifications()
                                             frmAccueil._date_selectionne = mc._date
                                             actualiserComposants()
                                         End Sub
        Controls.Add(btnMoisSuivant)
        Controls.Add(btnMoisPrecedent)

        actualiserComposants()

    End Sub

    Public Sub addEventJour(ByVal evenement As String, ByVal jourEvenement As Integer)
        mc.ajouterEvenement(jourEvenement, evenement)



    End Sub

    Public Sub actualiserComposants()
        Controls.Remove(mc)
        mc = New PanelMois(0, 50, Width, Height - 100, frmAccueil._date_selectionne)



        mc.bindLabel(lblAnneeMois)

        lblAnneeMois.Font = New Font("Segoe UI", 14.25)

        lblAnneeMois.Text = StrConv(MonthName(mc._date.AddMonths(-1).Date.Month) & " " & mc._date.Year, VbStrConv.ProperCase)
        lblAnneeMois.AutoSize = False


        lblAnneeMois.SetBounds(225, 5, 250, 30)
        lblAnneeMois.TextAlign = ContentAlignment.MiddleCenter

        Controls.Add(lblAnneeMois)


        ajouterNotifications()
        Controls.Add(mc)
    End Sub

    Private Sub ajouterNotifications()

        Dim mois As String = "00"
        Dim annee As String = Split(lblAnneeMois.Text, " ")(1)
        Select Case Split(lblAnneeMois.Text, " ")(0)
            Case "Janvier", "January"
                mois = "01"
            Case "Février", "February"
                mois = "02"
            Case "Mars", "March"
                mois = "03"
            Case "Avril", "April"
                mois = "04"
            Case "Mai", "May"
                mois = "05"
            Case "Juin", "June"
                mois = "06"
            Case "Juillet", "July"
                mois = "07"
            Case "Août", "August"
                mois = "08"
            Case "Septembre", "September"
                mois = "09"
            Case "Octobre", "October"
                mois = "10"
            Case "Novembre", "November"
                mois = "11"
            Case "Décembre", "December"
                mois = "12"
        End Select

        ds = New DataSet


        bd.miseAjourDS(ds, da, "select * from evenements where date_evenement between '" & annee & "-" & mois & "-00' and '" & annee & "-" & mois & "-31'", 0)

        'LANGUE ANGLAISE PLANTE (MOIS/JOUR/ANNEE)


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim str As String = dr(2)

            Try
                addEventJour(dr(1), Split(str, "-")(2))
            Catch exc As Exception

                addEventJour(dr(1), Split(str, "-")(2))
            End Try
        Next


    End Sub

End Class


