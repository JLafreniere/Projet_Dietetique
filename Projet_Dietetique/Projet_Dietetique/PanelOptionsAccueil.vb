Public Class PanelOptionsAccueil
    Inherits Panel

    Dim nbBoutons As Integer = 0
    Dim nbBtn As Integer

    Sub New(x As Integer, y As Integer, width As Integer, nbBtnPerRow As Integer)
        Me.SetBounds(x, y, width, 0)
        BackColor = Color.Black
        nbBtn = nbBtnPerRow

    End Sub

    Sub rafraichir() Handles Me.MouseLeave
        For Each b As BoutonOption In Me.Controls
            b.BackColor = Color.LightGray
        Next

    End Sub

    Sub ajouterBouton(imageName As String, destination As Form, buttonName As String)
        If ((nbBoutons Mod nbBtn) = 0) Then
            Me.Height += Width / nbBtn
        End If

        Dim btn As New BoutonOption((nbBoutons Mod nbBtn) * (Me.Width / nbBtn), (nbBoutons \ nbBtn) * (Me.Width / nbBtn), Me.Width / nbBtn, Me.Width / nbBtn, buttonName, imageName, destination)


        nbBoutons += 1


        Controls.Add(btn)


        For Each b As BoutonOption In Controls
            AddHandler b.MouseEnter, Sub()
                                         For Each bo As BoutonOption In Controls
                                             If bo.BackColor = Color.AliceBlue And Not b.btnName = bo.btnName Then
                                                 bo.BackColor = Color.LightGray
                                             End If
                                         Next
                                     End Sub

            AddHandler b.BackColorChanged, Sub()
                                               For Each bo As BoutonOption In Controls
                                                   If bo.BackColor = Color.AliceBlue And Not b.btnName = bo.btnName Then
                                                       bo.BackColor = Color.LightGray
                                                   End If
                                               Next
                                           End Sub


        Next

    End Sub






End Class


