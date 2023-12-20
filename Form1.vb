Imports System.Data.Odbc

Public Class Form1
    ' String koneksi yang digunakan dalam seluruh form
    Dim connectionString As String = "Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root"

    ' Event handler untuk tombol Login
    Private Sub Login_button_Click(sender As Object, e As EventArgs) Handles Login_Button.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Periksa jika username atau password kosong
        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Username dan password harus diisi!")
        Else
            ' Cek jika pengguna adalah mahasiswa
            If IsMahasiswa(username, password) Then
                ' Jika berhasil, tampilkan form mahasiswa
                Dim Nim As String = txtPassword.Text ' Pastikan nilai Nim diambil dari TextBox yang sesuai
                Dim formMahasiswa As New Form_mahasiswa(Nim)
                formMahasiswa.SetUsernameLabel = txtUsername.Text

                Me.Hide()
                formMahasiswa.Show()

                ' Cek jika pengguna adalah dari laboratorium
            ElseIf IsLaboratorium(username, password) Then
                ' Jika login berhasil dari tabel laboratorium
                Dim namaLab As String = txtUsername.Text
                Dim labForm As New labForm(namaLab)
                labForm.SetUsernameLabel = txtUsername.Text
                labForm.Show()
                Me.Hide()

                ' Cek jika pengguna adalah admin
            ElseIf IsAdmin(username, password) Then
                ' Jika login berhasil dari tabel account_admin
                Dim idAdmin As String = txtUsername.Text
                Dim mainForm As New MainForm(idAdmin)
                mainForm.SetUsernameLabel = txtUsername.Text
                Me.Hide()
                mainForm.Show()

                ' Jika pengguna tidak ditemukan dalam tipe yang ada
            Else
                MessageBox.Show("Username atau password salah!")
            End If
        End If
    End Sub

    ' Fungsi untuk memeriksa apakah pengguna adalah dari laboratorium
    Private Function IsLaboratorium(username As String, password As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM laboratorium WHERE nama_lab = ? AND password_lab = ?"
        Dim userCount As Integer = 0

        Using connection As New OdbcConnection(connectionString)
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("@nama_lab", username)
                command.Parameters.AddWithValue("@password_lab", password)

                connection.Open()
                Dim result As Object = command.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    Integer.TryParse(result.ToString(), userCount)
                End If
            End Using
        End Using

        Return userCount > 0
    End Function

    ' Fungsi untuk memeriksa apakah pengguna adalah mahasiswa
    Private Function IsMahasiswa(username As String, password As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM mahasiswa WHERE nama_mhs = ? AND Nim = ?"
        Dim userCount As Integer = 0

        Using connection As New OdbcConnection(connectionString)
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("@nama_mhs", username)
                command.Parameters.AddWithValue("@Nim", password)

                connection.Open()
                Dim result As Object = command.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    Integer.TryParse(result.ToString(), userCount)
                End If
            End Using
        End Using

        Return userCount > 0
    End Function

    ' Fungsi untuk memeriksa apakah pengguna adalah admin
    Private Function IsAdmin(username As String, password As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM account_admin WHERE username = ? AND password = ?"
        Dim userCount As Integer = 0

        Using connection As New OdbcConnection(connectionString)
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("@username", username)
                command.Parameters.AddWithValue("@password", password)

                connection.Open()
                Dim result As Object = command.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    Integer.TryParse(result.ToString(), userCount)
                End If
            End Using
        End Using

        Return userCount > 0
    End Function
End Class