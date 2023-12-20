Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class labForm
    Private namaLab As String

    Public Sub New(ByVal namaLab As String)
        InitializeComponent()
        Me.namaLab = namaLab
        SetUsernameLabel = namaLab ' Atur label pengguna di sini atau pada saat Load form
    End Sub

    Public WriteOnly Property SetUsernameLabel As String
        Set(value As String)
            ' Atur label pengguna di sini
            Label2.Text = namaLab
        End Set
    End Property

    Private Sub labForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = namaLab
        TextBox1.ForeColor = Color.DimGray
        TextBox1.Font = New Font(TextBox1.Font, FontStyle.Italic)
        TextBox1.Text = "Isi id alat disini"


        Dim connectionString As String = "Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root"
        Using connection As New OdbcConnection(connectionString)


            connection.Open()

            Dim sqlQuery As String = "SELECT id_lab FROM laboratorium WHERE nama_lab = ?"
            Using command As New OdbcCommand(sqlQuery, connection)
                command.Parameters.AddWithValue("@namaLab", namaLab)

                ' Membaca hasil query
                Using reader As OdbcDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        ' Jika data ditemukan
                        Dim idLab As String = reader("id_lab").ToString()

                        ' Query SQL dengan JOIN untuk menampilkan seluruh isi tabel simpan dan nama alatnya
                        Dim joinQuery As String = "SELECT s.*, a.Nama_Alat, a.Status_Alat " &
                                                  "FROM simpan s " &
                                                  "INNER JOIN alat a ON s.id_alat = a.Id_Alat " &
                                                  "WHERE s.id_lab = ?"


                        Using joinCommand As New OdbcCommand(joinQuery, connection)
                            ' Menambahkan parameter id_lab yang sudah diperoleh sebelumnya
                            joinCommand.Parameters.AddWithValue("@idLab", idLab)

                            ' Membaca hasil query ke dalam DataTable
                            Dim dataTable As New DataTable()
                            dataTable.Load(joinCommand.ExecuteReader())

                            ' Tampilkan data ke dalam DataGridView1
                            DataGridView1.DataSource = dataTable
                        End Using
                    End If

                    Dim jumlahAlatRusak As Integer = HitungAlatRusak(DataGridView1)
                    Label4.Text = jumlahAlatRusak.ToString()

                End Using
            End Using
        End Using
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text = "Isi id alat disini" Then
            TextBox1.Font = New Font(TextBox1.Font, FontStyle.Regular)
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            TextBox1.Text = "Isi id alat disini"
            TextBox1.Font = New Font(TextBox1.Font, FontStyle.Italic)
            TextBox1.ForeColor = Color.DimGray
        End If
    End Sub

    Private Function HitungAlatRusak(dataGridView As DataGridView) As Integer
        Dim rusakCount As Integer = 0

        For Each row As DataGridViewRow In dataGridView.Rows
            ' Pastikan baris tidak kosong dan kolom Status_Alat memiliki nilai
            If Not row.IsNewRow AndAlso row.Cells("Status_Alat").Value IsNot Nothing Then
                Dim statusAlat As String = row.Cells("Status_Alat").Value.ToString()

                ' Jika status alat adalah RUSAK, tambahkan ke jumlah alat rusak
                If statusAlat.ToUpper() = "RUSAK" Then
                    rusakCount += 1
                End If
            End If
        Next

        Return rusakCount
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formPemesanan As New Pemesanan(namaLab)
        formPemesanan.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connectionString As String = "Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root"

        Using connection As New OdbcConnection(connectionString)
            connection.Open() ' Buka koneksi

            Dim idAlat As String = TextBox1.Text
            Dim queryUpdateStatus As String = "UPDATE alat SET Status_Alat = 'RUSAK' WHERE Id_Alat = ?"

            ' Eksekusi query dengan parameter ID alat
            Using commandUpdateStatus As New OdbcCommand(queryUpdateStatus, connection)
                commandUpdateStatus.Parameters.AddWithValue("@Id_Alat", idAlat)
                commandUpdateStatus.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub ButtonKembali_Click(sender As Object, e As EventArgs) Handles ButtonKembali.Click
        ' Kembali ke Form1
        Dim form1 As New Form1()
        form1.Show()
        Me.Close() ' Menutup form labForm
    End Sub

End Class

