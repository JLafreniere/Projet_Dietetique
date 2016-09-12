Imports System.ComponentModel

Public Class PanelMois
    Inherits Panel

    ' Par Jonathan Lafrenière
    ' Affichage d'un mois dans le calendrier


    Dim semaines(6) As PanelSemaine
    '(10, 400, 750, 125, True, True)
    'Dim s2 As New PanelSemaine(10, 525, 750, 100, True, False)
    'Dim s3 As New PanelSemaine(10, 625, 750, 100, True, False)
    'Dim s4 As New PanelSemaine(10, 725, 750, 100, True, False)
    'Dim s5 As New PanelSemaine(10, 825, 750, 100, True, False)

    Dim lbl As New Label

    Public Property _date As Date
    Dim nbSemaines As Integer = 0

    Public Sub New(x As Integer, y As Integer, width As Integer, height As Integer, dateDebut As Date)

        Size = New Size(width, height)
        Me.Location = New Point(x, y)
        Dim d As Date = New Date(dateDebut.Year, dateDebut.Month, Date.DaysInMonth(dateDebut.Year, dateDebut.Month))

        setDate(d)
    End Sub

    Public Sub creerCalendrier(ByVal d As Date)


        Me.Controls.Clear()


        semaines(0) = New PanelSemaine(0, 0, Width, 40 + ((Height - 40) / 6), True, True)
        semaines(1) = New PanelSemaine(0, 40 + ((Height - 40) / 6), Width, ((Height - 40) / 6), False, True)
        semaines(2) = New PanelSemaine(0, 40 + 2 * ((Height - 40) / 6), Width, ((Height - 40) / 6), False, True)
        semaines(3) = New PanelSemaine(0, 40 + 3 * ((Height - 40) / 6), Width, ((Height - 40) / 6), False, True)
        semaines(4) = New PanelSemaine(0, 40 + 4 * ((Height - 40) / 6), Width, ((Height - 40) / 6), False, True)
        semaines(5) = New PanelSemaine(0, 40 + 5 * ((Height - 40) / 6), Width, ((Height - 40) / 6), False, True)
        nbSemaines = numberOfWeek(d) - 1
        For i As Integer = 0 To nbSemaines
            Me.Controls.Add(semaines(i))
        Next


        remplirJours()
    End Sub


    Public Sub setDate(ByVal d As Date)
        _date = d

        lbl.Text = StrConv(MonthName(d.Month) & " " & d.Year, VbStrConv.ProperCase)

        creerCalendrier(d)

    End Sub

    Public Function numberOfWeek(dat As Date)

        Dim DaysInMonth As Integer = Date.DaysInMonth(dat.Year, dat.Month)
        Dim datFinMois As Date = New Date(dat.Year, dat.Month, DaysInMonth)

        Dim beginningOfMonth As New DateTime(dat.Year, dat.Month, 1)

        While (datFinMois.AddDays(1).DayOfWeek <> Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
            datFinMois = datFinMois.AddDays(1)
        End While

        Return (Math.Truncate((datFinMois.Subtract(beginningOfMonth).TotalDays / 7)) + 1)
    End Function


    Private Sub remplirJours()


        Dim semaine As Integer = 0
        Dim beginningOfMonth As New DateTime(_date.Year, _date.Month, 1)
        Dim moisSuivant As Integer = _date.AddMonths(1).Month

        _date = beginningOfMonth

        While (_date.AddDays(0).Month <> moisSuivant)

            Select Case _date.ToString("dddd")
                Case "dimanche", "Sunday"
                    semaines(semaine).pnlJours(0).ajouterEvenement(_date.Day)
                    semaines(semaine).pnlJours(0).Tag = _date.Day
                Case "lundi", "Monday"
                    semaines(semaine).pnlJours(1).ajouterEvenement(_date.Day)
                    semaines(semaine).pnlJours(1).Tag = _date.Day
                Case "mardi", "Tuesday"
                    semaines(semaine).pnlJours(2).ajouterEvenement(_date.Day)
                    semaines(semaine).pnlJours(2).Tag = _date.Day
                Case "mercredi", "Wednesday"
                    semaines(semaine).pnlJours(3).ajouterEvenement(_date.Day)
                    semaines(semaine).pnlJours(3).Tag = _date.Day
                Case "jeudi", "Thursday"
                    semaines(semaine).pnlJours(4).ajouterEvenement(_date.Day)
                    semaines(semaine).pnlJours(4).Tag = _date.Day
                Case "vendredi", "Friday"
                    semaines(semaine).pnlJours(5).ajouterEvenement(_date.Day)
                    semaines(semaine).pnlJours(5).Tag = _date.Day
                Case "samedi", "Saturday"
                    semaines(semaine).pnlJours(6).ajouterEvenement(_date.Day)
                    semaines(semaine).pnlJours(6).Tag = _date.Day
                    semaine = semaine + 1


            End Select

            _date = _date.AddDays(1)
        End While


        For i As Integer = 0 To nbSemaines
            For ii As Integer = 0 To 6
                semaines(i).pnlJours(ii).gray()
            Next
        Next



    End Sub


    Public Sub bindLabel(ByRef lblAnneeMois As Label)
        lbl = lblAnneeMois
    End Sub

    Public Sub ajouterEvenement(jour As Integer, evenement As String)

        For i As Integer = 0 To nbSemaines
            For ii As Integer = 0 To 6
                If semaines(i).pnlJours(ii).Tag = jour Then
                    semaines(i).pnlJours(ii).ajouterEvenementMois(evenement)

                    Dim pb As New PictureBox
                    If Not semaines(i).pnlJours(ii).dayN Then
                        pb.SetBounds((semaines(i).pnlJours(ii).Width / 2) - (semaines(i).pnlJours(ii).Width / 2.5), semaines(i).pnlJours(ii).Height / 2 - (semaines(i).pnlJours(ii).Height / 2.5), semaines(i).pnlJours(ii).Width / 1.25, semaines(i).pnlJours(ii).Height / 1.25)
                    Else
                        pb.SetBounds((semaines(i).pnlJours(ii).Width / 2) - (semaines(i).pnlJours(ii).Width / 2.5), (semaines(i).pnlJours(ii).Height + 40) / 2 - ((semaines(i).pnlJours(ii).Height - 40) / 2.5), semaines(i).pnlJours(ii).Width / 1.25, (semaines(i).pnlJours(ii).Height - 40) / 1.25)
                    End If

                    pb.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory & "imgAlerte.png")
                    pb.SizeMode = PictureBoxSizeMode.StretchImage
                    pb.Tag = evenement
                    AddHandler pb.Click, Sub(sender2, eventargs2)

                                             MsgBox(pb.Tag)
                                         End Sub

                    semaines(i).pnlJours(ii).Controls.Add(pb)

                End If
            Next
        Next

    End Sub


End Class
