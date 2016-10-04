Imports MySql.Data.MySqlClient

Public Class PanelSemaine
    Inherits Panel

    Public pnlJours(5) As PanelJour
    ''Jonathan Lafreniere
    ' Semaine, peut être utilisée dans le calendrier (monthComp = true) ou comme panneau d'alerte (monthComp = false)

    Dim monthComp As Boolean
    Dim bColor As Color
    Dim bo As Boolean = False
    Dim bd As New GestionBD("Server=localhost;Database=bd_application;Uid=root;Pwd=;")

    Property DateSelectionnee As Date = Date.Today

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

    Public Sub remplirSemaine(d As Date)


        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter

        For Each e As PanelJour In pnlJours
            Try
                e.viderJour()
            Catch exc As Exception
            End Try
        Next

        bd.miseAjourDS(ds, da, "select * from evenements where date_evenement between '" & GetPreviousSunday(d) & "' and '" & GetNextSaturday(d) & "'", 0)
        For Each dr As DataRow In ds.Tables(0).Rows
            Try
                pnlJours(DateDiff(DateInterval.Day, GetPreviousSunday(d), dr.Item(2)) - 1).ajouterEvenement(dr.Item(1))
            Catch exc As Exception : End Try
        Next



        bo = True

    End Sub

    Function GetPreviousSunday(fromDate As Date) As Date
        Return fromDate.AddDays(0 - fromDate.DayOfWeek)
    End Function

    Function GetNextSaturday(fromDate As Date) As Date
        Return fromDate.AddDays(6 - fromDate.DayOfWeek)
    End Function


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


    Public Property BorderColor() As Color
        Get
            Return Me.bColor
        End Get
        Set(ByVal value As Color)
            Me.bColor = value
            Me.Refresh()
        End Set
    End Property

    Private bWidth As Integer
    Public Property BorderWidth() As Integer
        Get
            Return Me.bWidth
        End Get
        Set(ByVal value As Integer)
            Me.bWidth = Math.Abs(value)
            Me.Refresh()
        End Set
    End Property

    Public Overridable Sub MyPanel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

        e.Graphics.DrawRectangle(New Pen(Me.bColor, Me.bWidth), Me.ClientRectangle)

    End Sub


End Class

