Public Class PanelSemaine
    Inherits Panel

    Public pnlJours(5) As PanelJour
    ''Jonathan Lafreniere
    ' Semaine, peut être utilisée dans le calendrier (monthComp = true) ou comme panneau d'alerte (monthComp = false)

    Dim monthComp As Boolean

    Public Sub New(x As Integer, y As Integer, width As Integer, height As Integer, firstWeek As Boolean, monthComponent As Boolean)


        'Initialise le panneau de semaine
        'Si l'argument firstweek est vrai, le panneau incluera le titre des jours
        'Si l'argument monthComponent est vrai, aucun linkLabel ne sera ajouté si le panneau contient trop de texte


        ReDim pnlJours(7)
        Me.SetBounds(x, y, width, height)
        Me.Visible = True

        monthComp = monthComponent

        For i As Integer = 0 To 6 'Création des 7 jours de la semaine
            Dim pnl As PanelJour
            If (firstWeek) Then
                pnl = New PanelJour((width / 7) * i, 0, width / 7, height, IntegerJour(i), True, True, monthComponent)

            Else
                pnl = New PanelJour((width / 7) * i, 0, width / 7, height, IntegerJour(i), True, False, monthComponent)
            End If
            pnlJours(i) = pnl
            Me.Controls.Add(pnl)
        Next

    End Sub

    Public Sub New(x As Integer, y As Integer, width As Integer, height As Integer)
        ReDim pnlJours(5)
        Me.SetBounds(x, y, width, height)
        Me.Visible = True


        For i As Integer = 1 To 5 'Création des 5 jours de la semaine

            Dim pnl As New PanelJour((width / 5) * (i - 1), 0, width / 5, height, IntegerJour(i), False, True, monthComp)
            pnlJours(i - 1) = pnl
            Me.Controls.Add(pnl)

        Next

    End Sub

    Public Sub ajouterEvenement(ByVal jour As Integer, ByVal evenement As String) 'Ajoute un évènement à la case associée à la valeur de "jour" (0-6)
        pnlJours(jour).ajouterEvenement(evenement)
    End Sub

    Public Function IntegerJour(ByVal jour As Integer) 'Conversion chiffre/nom de jour
        Select Case jour
            Case 0
                Return "Dimanche"
            Case 1
                Return "Lundi"
            Case 2
                Return "Mardi"
            Case 3
                Return "Mercredi"
            Case 4
                Return "Jeudi"
            Case 5
                Return "Vendredi"
            Case 6
                Return "Samedi"
        End Select
        Return "NULL"
    End Function



End Class
