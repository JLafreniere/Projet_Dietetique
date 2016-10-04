Public Class BoutonOption
    Inherits Panel

    Dim WithEvents pb As New PictureBox
    Dim WithEvents lblpb As Label
    Dim destination As Form
    Property btnName As String
    Public Sub New(_X As Integer, _Y As Integer, _Width As Integer, _Height As Integer, buttonName As String, imageName As String, _destination As Form)
        btnName = buttonName
        SetBounds(_X, _Y, _Width, _Height)
        BackColor = Color.LightGray

        pb = New PictureBox()
        pb.Image = Image.FromFile(imageName)
        pb.SizeMode = PictureBoxSizeMode.StretchImage
        pb.SetBounds(Width * 0.1, Height * 0.1, Width * 0.8, Height * 0.8)
        pb.BackColor = Color.Transparent

        lblpb = New Label
        lblpb.Location = New Point(10, 10)
        lblpb.Text = buttonName
        lblpb.AutoSize = True
        lblpb.Font = New Font("Segoe UI", 14.25, FontStyle.Bold)
        lblpb.ForeColor = Color.Gray
        lblpb.BackColor = Color.Transparent
        lblpb.Visible = True
        Controls.Add(lblpb)
        Controls.Add(pb)
        destination = _destination

    End Sub


    Public Sub t(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.MouseEnter, pb.MouseEnter, lblpb.MouseEnter
        BackColor = Color.AliceBlue
    End Sub

    Public Sub t2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        BackColor = Color.LightGray
    End Sub


    Public Sub t3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Click, pb.Click, lblpb.Click



        destination.Show()
        destination.WindowState = FormWindowState.Maximized
        frmAccueil.Hide()

    End Sub

End Class

