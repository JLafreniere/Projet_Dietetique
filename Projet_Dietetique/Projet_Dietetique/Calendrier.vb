Imports MySql.Data.MySqlClient

Public Class Calendrier
    Inherits Panel


    Dim ds As New DataSet
    Dim da As New MySqlDataAdapter
    Dim bd As New GestionBD("Server=localhost;Database=bd_application;Uid=root;Pwd=;")
    Dim lblAnneeMois As New Label
    Public mc
    Dim btnMoisPrecedent, btnMoisSuivant As Button
    Public Sub New(x As Integer, y As Integer, width As Integer, height As Integer, dateDebut As Date)

        SetBounds(x, y, width, height - 40)

        mc = New PanelMois(0, 40, width, height - 80, Date.Now)
        btnMoisPrecedent = New Button()
        btnMoisSuivant = New Button()

        btnMoisPrecedent.Text = "<<"
        btnMoisPrecedent.SetBounds(width / 4 - 50, 5, 100, 30)
        btnMoisPrecedent.BackColor = DefaultBackColor
        btnMoisPrecedent.UseVisualStyleBackColor = True

        AddHandler btnMoisPrecedent.Click, Sub(sender2, eventargs2)

                                               mc.setDate(mc._date.addMonths(-2))
                                               ajouterNotifications()

                                           End Sub

        btnMoisSuivant.Text = ">>"
        btnMoisSuivant.SetBounds((3 * width) / 4 - 50, 5, 100, 30)
        btnMoisSuivant.BackColor = DefaultBackColor
        btnMoisSuivant.UseVisualStyleBackColor = True
        AddHandler btnMoisSuivant.Click, Sub(sender3, eventargs3)

                                             mc.setDate(mc._date.addMonths(0.5))
                                             ajouterNotifications()

                                         End Sub


        mc.bindLabel(lblAnneeMois)

        lblAnneeMois.Font = New Font("Segoe UI", 14.25)

        lblAnneeMois.Text = StrConv(MonthName(mc._date.addMonths(-1).date.month) & " " & mc._date.year, VbStrConv.ProperCase)
        lblAnneeMois.AutoSize = False


        lblAnneeMois.SetBounds(225, 5, 250, 30)
        lblAnneeMois.TextAlign = ContentAlignment.MiddleCenter

        Controls.Add(lblAnneeMois)
        Controls.Add(btnMoisSuivant)
        Controls.Add(btnMoisPrecedent)

        ajouterNotifications()
        Controls.Add(mc)

    End Sub

    Public Sub addEventJour(ByVal evenement As String, ByVal jourEvenement As Integer)
        mc.ajouterEvenement(jourEvenement, evenement)
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
            Try
                addEventJour(dr(1), Split(dr(2), "-")(2))
            Catch exc As Exception

                addEventJour(dr(1), Split(dr(2), "/")(1))
            End Try
        Next


    End Sub

End Class
