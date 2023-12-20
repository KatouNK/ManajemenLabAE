Imports System.Data.Odbc

Public Class DataMHSbaru

    Private idadmin As String

    Public Sub New(ByVal idadmin As String)
        InitializeComponent()
        Me.idadmin = idadmin
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connectionString As String = "Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root"

        ' Mengambil data dari TextBox
        Dim nim As String = TextBoxNIM.Text
        Dim nama As String = TextBoxNama.Text
        Dim kelas As String = TextBoxKelas.Text
        Dim noKoin As String = TextBoxNoKoin.Text

        ' Query untuk memasukkan data ke dalam tabel mahasiswa
        Dim queryInsertMahasiswa As String = "INSERT INTO mahasiswa (Nim, nama_mhs, kelas, no_koin) VALUES (?, ?, ?, ?)"

        Using connection As New OdbcConnection(connectionString)
            Try
                connection.Open()

                Using commandInsertMahasiswa As New OdbcCommand(queryInsertMahasiswa, connection)
                    ' Mengatur parameter untuk query
                    commandInsertMahasiswa.Parameters.AddWithValue("@Nim", nim)
                    commandInsertMahasiswa.Parameters.AddWithValue("@nama_mhs", nama)
                    commandInsertMahasiswa.Parameters.AddWithValue("@kelas", kelas)
                    commandInsertMahasiswa.Parameters.AddWithValue("@no_koin", noKoin)

                    ' Melakukan eksekusi query INSERT
                    commandInsertMahasiswa.ExecuteNonQuery()
                End Using

                MessageBox.Show("Data mahasiswa berhasil ditambahkan.")
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim formManagementMHS As New ManagementMHS(idadmin)
        formManagementMHS.Show()
        Me.Hide()
    End Sub
End Class