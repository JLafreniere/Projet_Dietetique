

Imports System.Data
Imports MySql.Data.MySqlClient

Public Class GestionBD

    Private _position As Integer = 0
    Public _Connectionstring As String
    Public _conn As New MySqlConnection
    Private _cmd As MySqlCommand
    Dim gestionOperation As New MySqlCommandBuilder

    Public Sub New(ByVal connexionString As String)
        _conn = New MySqlConnection(connexionString)

        _conn.Open()
        _conn.Close()
    End Sub

    ' Permet de modifier ou d’obtenir la position actuelle
    Public Property position() As Integer
        Get
            Return _position
        End Get
        Set(ByVal value As Integer)
            _position = value
        End Set
    End Property
    'Chaîne de connexion à la bd
    Public Property ConnectionString() As String
        Get
            Return _Connectionstring
        End Get
        Set(ByVal value As String)
            _Connectionstring = value
        End Set
    End Property
    'Remplir dataset des données de la bd en fonction de la requête reçue de l’application.
    Sub Requete(ByVal req As String, ByVal ds As DataSet, ByVal da As MySqlDataAdapter, ByVal table As String)
        _conn.Close()

        Try
            If _conn.State <> ConnectionState.Open Then
                _conn.Open()
            End If
        Catch ae As MySqlException
            MessageBox.Show(ae.Message.ToString())
        End Try
        _cmd = New MySqlCommand
        _cmd.Connection = _conn
        _cmd.CommandText = req
        da.SelectCommand = _cmd
        Try
            '_cmd.ExecuteNonQuery()
            da = New MySqlDataAdapter(_cmd)
            da.Fill(ds, table)
        Catch ae As MySqlException
            MessageBox.Show(ae.Message.ToString())

        End Try

        _conn.Close()
    End Sub

    Function executeScalar(ByVal req As String)
        Dim obj As New Object
        _conn.Close()

        Try
            If _conn.State <> ConnectionState.Open Then
                _conn.Open()
            End If
        Catch ae As MySqlException
            MessageBox.Show(ae.Message.ToString())
        End Try

        Dim cmd As New MySqlCommand(req, _conn)

        Try
            '_cmd.ExecuteNonQuery()

            obj = cmd.ExecuteScalar()

        Catch ae As MySqlException
            MessageBox.Show(ae.Message.ToString())

        End Try
        Return obj
        _conn.Close()
    End Function


    '- Met à jour la bd selon la requete. Utilisée pour les insert, les update, delete.
    Sub nonQuery(ByVal req As String)



        Try
            If _conn.State <> ConnectionState.Open Then
                _conn.Open()
            End If
        Catch e As MySqlException
            MessageBox.Show(e.Message.ToString())
        End Try
        _cmd = New MySqlCommand(req, _conn)
        Try
            _cmd.ExecuteNonQuery()
        Catch e As MySqlException
            MessageBox.Show(e.Message.ToString())

        End Try
        _conn.Close()
    End Sub

    '- Met à jour la bd en fonction du dataset passé en paramètre
    Sub miseAjourBD(ByVal ds As DataSet, ByVal da As MySqlDataAdapter, tbl As String)


        Try
            If _conn.State <> ConnectionState.Open Then
                _conn.Open()
            End If
        Catch ae As MySqlException
            MessageBox.Show(ae.Message.ToString())
        End Try



        Try
            gestionOperation = New MySqlCommandBuilder(da)
            da.Update(ds, tbl)
        Catch e As MySqlException
            MessageBox.Show(e.Message.ToString())
        End Try
        _conn.Close()
    End Sub
    ' Met à jour un dataset avec les informations de la bd.
    Sub miseAjourDS(ByRef ds As DataSet, ByRef da As MySqlDataAdapter, req As String, table As String)
        ds = New DataSet
        da = New MySqlDataAdapter
        Requete(req, ds, da, table)
    End Sub

End Class

