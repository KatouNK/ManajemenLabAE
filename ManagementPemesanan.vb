Public Class ManagementPemesanan
    Private Sub ManagementPemesanan_load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.ForeColor = Color.DimGray
        TextBox1.Font = New Font(TextBox1.Font, FontStyle.Italic)
        TextBox1.Text = "Isi Id pemesanan disini untuk konfirmasi"
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text = "Isi Id pemesanan disini untuk konfirmasi" Then
            TextBox1.Font = New Font(TextBox1.Font, FontStyle.Regular)
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            TextBox1.Text = "Isi Id pemesanan disini untuk konfirmasi"
            TextBox1.Font = New Font(TextBox1.Font, FontStyle.Italic)
            TextBox1.ForeColor = Color.DimGray
        End If
    End Sub
End Class