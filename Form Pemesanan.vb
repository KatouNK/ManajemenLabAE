Imports System.Configuration
Imports System.Data.Odbc
Imports System.Reflection.Metadata

Public Class Form_Pemesanan
    Dim SearchResult As New DataSet()
    Private nimDiterima As String

    Public Sub New(nimDiterima As String)
        InitializeComponent()
        Me.nimDiterima = nimDiterima
    End Sub


    Private Sub Form_Pemesanan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.ForeColor = Color.DimGray
        TextBox1.Font = New Font(TextBox1.Font, FontStyle.Italic)
        TextBox1.Text = "Isi peminjaman disini"
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If TextBox1.Text = "Isi peminjaman disini" Then
            TextBox1.Font = New Font(TextBox1.Font, FontStyle.Regular)
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            TextBox1.Text = "Isi peminjaman disini"
            TextBox1.Font = New Font(TextBox1.Font, FontStyle.Italic)
            TextBox1.ForeColor = Color.DimGray
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim searchText As String = TextBox1.Text.Trim()

        If Not String.IsNullOrWhiteSpace(searchText) Then
            Try
                Using Conn As New OdbcConnection("Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root")
                    Conn.Open()
                    Dim query As String = "SELECT a.Id_Alat, a.Nama_Alat, a.Status_Alat, l.id_lab, l.nama_lab
                                           FROM simpan s 
                                           INNER JOIN alat a ON s.id_alat = a.id_alat
                                           INNER JOIN laboratorium l ON s.id_lab = l.id_lab
                                           WHERE a.Nama_Alat LIKE ? OR l.nama_lab LIKE ?"

                    Using command As New OdbcCommand(query, Conn)
                        command.Parameters.AddWithValue("@searchText", "%" & searchText & "%")
                        command.Parameters.AddWithValue("@searchTextLab", "%" & searchText & "%")

                        Dim adapter As New OdbcDataAdapter(command)
                        SearchResult.Clear()
                        adapter.Fill(SearchResult, "SearchResult")

                        DataGridView1.DataSource = SearchResult.Tables("SearchResult")
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Masukkan nama alat atau lab untuk pencarian.")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.Rows.Count > 0 AndAlso DataGridView1.Columns.Count > 0 Then
            ' Pastikan ada setidaknya satu baris dan kolom yang cukup di DataGridView

            Dim statusAlat As String = DataGridView1.Rows(0).Cells(2).Value.ToString().Trim()

            If statusAlat = "DISIMPAN" Then
                Try
                    Using Conn As New OdbcConnection("Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root")
                        Conn.Open()


                        Dim idPeminjaman As String = GenerateRandomId()
                        Dim id_lab As String = DataGridView1.Rows(0).Cells(3).Value.ToString()
                        Dim Id_alat As String = DataGridView1.Rows(0).Cells(0).Value.ToString()
                        Dim Nim As String = nimDiterima
                        Dim keperluan As String = TextBox2.Text
                        Dim tgl_peminjaman As DateTime = DateTimePicker1.Value
                        Dim jamselesai As DateTime = Now
                        Dim tgl_selesai As DateTime = DateTimePicker2.Value



                        ' Simpan data ke tabel peminjaman
                        Dim queryInsertPeminjaman As String = "INSERT INTO peminjaman (id_peminjaman, id_lab, Id_alat, Nim, nama_keperluan, tgl_peminjaman, tgl_selesai, kembali) VALUES (?, ?, ?, ?, ?, ?, ?, 'BELUM')"
                        Using commandInsertPeminjaman As New OdbcCommand(queryInsertPeminjaman, Conn)
                            commandInsertPeminjaman.Parameters.AddWithValue("@id_peminjaman", idPeminjaman)
                            commandInsertPeminjaman.Parameters.AddWithValue("@id_lab", id_lab)
                            commandInsertPeminjaman.Parameters.AddWithValue("@Id_alat", Id_alat)
                            commandInsertPeminjaman.Parameters.AddWithValue("@Nim", Nim)
                            commandInsertPeminjaman.Parameters.AddWithValue("@nama_keperluan", keperluan)
                            commandInsertPeminjaman.Parameters.AddWithValue("@tgl_peminjaman", tgl_peminjaman)
                            'commandInsertPeminjaman.Parameters.AddWithValue
                            commandInsertPeminjaman.Parameters.AddWithValue("@tgl_selesai", tgl_selesai)

                            commandInsertPeminjaman.ExecuteNonQuery()
                        End Using
                        Dim idPenerima As String = nimDiterima
                        Dim queryNamaMahasiswa As String = "SELECT nama_mhs FROM mahasiswa WHERE Nim = ?"
                        Dim namaMahasiswa As String = ""

                        Using commandNamaMahasiswa As New OdbcCommand(queryNamaMahasiswa, Conn)
                            commandNamaMahasiswa.Parameters.AddWithValue("@Nim", nimDiterima)
                            namaMahasiswa = Convert.ToString(commandNamaMahasiswa.ExecuteScalar())
                        End Using

                        ' Update status mahasiswa
                        Dim queryUpdateMHS As String = "UPDATE mahasiswa SET status = 'MEMINJAM' WHERE Nim = ?"
                        Using CommandUpdateMHS As New OdbcCommand(queryUpdateMHS, Conn)
                            CommandUpdateMHS.Parameters.AddWithValue("@Nim", nimDiterima)
                            CommandUpdateMHS.ExecuteNonQuery()
                        End Using

                        ' Update status peminjaman
                        Dim queryUpdatePeminjaman As String = "UPDATE peminjaman SET kembali = 'BELUM' WHERE Nim = ?"
                        Using commandUpdatePeminjaman As New OdbcCommand(queryUpdatePeminjaman, Conn)
                            commandUpdatePeminjaman.Parameters.AddWithValue("@Nim", nimDiterima)
                            commandUpdatePeminjaman.ExecuteNonQuery()
                        End Using

                        ' Update status alat menjadi 'DIPINJAM'
                        Dim queryUpdateAlat As String = "UPDATE alat SET Status_Alat = 'DIPINJAM' WHERE id_alat = ?"
                        Using commandUpdateAlat As New OdbcCommand(queryUpdateAlat, Conn)
                            commandUpdateAlat.Parameters.AddWithValue("@Id_alat", Id_alat)
                            commandUpdateAlat.ExecuteNonQuery()
                        End Using

                        MessageBox.Show("Alat berhasil dipinjam!")
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            Else
                MessageBox.Show("Alat sudah dipinjam atau status tidak valid untuk peminjaman.")
            End If
        Else
            MessageBox.Show("Pilih alat yang ingin dipinjam terlebih dahulu.")
        End If
    End Sub



    Private Function GenerateRandomId() As String
        Return Guid.NewGuid().ToString()
    End Function

    Private Sub kembali_Click(sender As Object, e As EventArgs) Handles kembali.Click
        Dim formMahasiswa As New Form_mahasiswa(nimDiterima)
        formMahasiswa.Show()
        Me.Hide()
    End Sub


End Class
