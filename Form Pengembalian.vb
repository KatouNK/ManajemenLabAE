Imports System.Data.Odbc

Public Class Form_Pengembalian
    Dim nimDiterima As String

    Public Sub New(nimDiterima As String)
        InitializeComponent()
        Me.nimDiterima = nimDiterima
    End Sub

    Private Sub Form_Pengembalian_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox1.ForeColor = Color.DimGray
        TextBox1.Font = New Font(TextBox1.Font, FontStyle.Italic)
        TextBox1.Text = "Isi id alat disini"

        ' Tampilkan data peminjaman berdasarkan nimDiterima
        Try
            Using Conn As New OdbcConnection("Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root")
                Conn.Open()
                Dim query As String = "SELECT * FROM peminjaman WHERE Nim = ?"
                Using command As New OdbcCommand(query, Conn)
                    command.Parameters.AddWithValue("@Nim", nimDiterima)
                    Dim adapter As New OdbcDataAdapter(command)
                    Dim peminjamanTable As New DataTable()
                    adapter.Fill(peminjamanTable)

                    ' Tampilkan data pada DataGridView
                    DataGridView1.DataSource = peminjamanTable
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
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

    Private Sub button_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim jamSelesai As DateTime = DateTime.Now

            Using Conn As New OdbcConnection("Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root")
                Conn.Open()

                ' Memulai transaksi
                Using transaction As OdbcTransaction = Conn.BeginTransaction()
                    Try
                        ' Update peminjaman
                        Dim queryUpdate As String = "UPDATE peminjaman SET kembali = 'SUDAH', jam_selesai = ? WHERE Nim = ?"
                        Using commandUpdate As New OdbcCommand(queryUpdate, Conn)
                            commandUpdate.Transaction = transaction
                            commandUpdate.Parameters.AddWithValue("@Jam_Selesai", jamSelesai.ToString("HH:mm:ss"))
                            commandUpdate.Parameters.AddWithValue("@Nim", nimDiterima)
                            commandUpdate.ExecuteNonQuery()
                        End Using

                        ' Update status alat
                        Dim queryUpdateAlat As String = "UPDATE alat SET Status_Alat = 'DISIMPAN' WHERE Id_alat IN (SELECT Id_alat FROM peminjaman WHERE Nim = ?)"
                        Using commandUpdateAlat As New OdbcCommand(queryUpdateAlat, Conn)
                            commandUpdateAlat.Transaction = transaction
                            commandUpdateAlat.Parameters.AddWithValue("@Nim", nimDiterima)
                            commandUpdateAlat.ExecuteNonQuery()
                        End Using

                        Dim queryNamaMahasiswa As String = "SELECT nama_mhs FROM mahasiswa WHERE Nim = ?"
                        Dim queryNamaAlat As String = "SELECT Nama_Alat FROM alat WHERE Id_Alat = ?"
                        Dim namaMahasiswa As String = ""
                        Dim idAlat As String = DataGridView1.Rows(0).Cells(2).Value.ToString()
                        Dim namaAlat As String = ""
                        Dim tanggalPengembalian As String = DateTime.Now.ToString("yyyy-MM-dd") ' Format tanggal sesuai dengan yang diterima oleh database

                        Using commandNamaMahasiswa As New OdbcCommand(queryNamaMahasiswa, Conn, transaction)
                            commandNamaMahasiswa.Parameters.AddWithValue("@Nim", nimDiterima)
                            namaMahasiswa = Convert.ToString(commandNamaMahasiswa.ExecuteScalar())
                        End Using

                        Using commandNamaAlat As New OdbcCommand(queryNamaAlat, Conn, transaction)
                            commandNamaAlat.Parameters.AddWithValue("@Id_alat", idAlat)
                            namaAlat = Convert.ToString(commandNamaAlat.ExecuteScalar())
                        End Using

                        ' Insert data ke tabel Pengembalian
                        Dim queryInsertPengembalian As String = "INSERT INTO Pengembalian (Nim, nama_mahasiswa, id_alat, nama_alat, tanggal_pengembalian) VALUES (?, ?, ?, ?, ?)"
                        Using commandInsertPengembalian As New OdbcCommand(queryInsertPengembalian, Conn)
                            commandInsertPengembalian.Transaction = transaction
                            commandInsertPengembalian.Parameters.AddWithValue("@Nim", nimDiterima)
                            commandInsertPengembalian.Parameters.AddWithValue("@nama_mahasiswa", namaMahasiswa)
                            commandInsertPengembalian.Parameters.AddWithValue("@id_alat", idAlat)
                            commandInsertPengembalian.Parameters.AddWithValue("@nama_alat", namaAlat)
                            commandInsertPengembalian.Parameters.AddWithValue("@tanggal_pengembalian", tanggalPengembalian)
                            commandInsertPengembalian.ExecuteNonQuery()
                        End Using

                        ' Hapus data peminjaman
                        Dim queryDelete As String = "DELETE FROM peminjaman WHERE Nim = ?"
                        Using commandDelete As New OdbcCommand(queryDelete, Conn)
                            commandDelete.Transaction = transaction
                            commandDelete.Parameters.AddWithValue("@Nim", nimDiterima)
                            commandDelete.ExecuteNonQuery()
                        End Using

                        Dim queryUpdateMHS As String = "UPDATE mahasiswa SET status = '' WHERE Nim = ?"
                        Using CommandUpdateMHS As New OdbcCommand(queryUpdateMHS, Conn)
                            CommandUpdateMHS.Parameters.AddWithValue("@Nim", nimDiterima)
                            CommandUpdateMHS.ExecuteNonQuery()
                        End Using

                        ' Commit transaksi jika semua operasi berhasil
                        transaction.Commit()
                        MessageBox.Show("Pengembalian berhasil ditandai dan data peminjaman dihapus.")
                    Catch ex As Exception
                        ' Rollback transaksi jika terjadi kesalahan
                        transaction.Rollback()
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub



    Private Sub kembali_Click(sender As Object, e As EventArgs) Handles Kembali.Click
        Dim formMahasiswa As New Form_mahasiswa(nimDiterima)
        formMahasiswa.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim idAlat As String = TextBox1.Text
        Dim queryUpdateStatus As String = "UPDATE peminjaman SET status_alat = 'RUSAK' WHERE Id_Alat = ?"

        ' Eksekusi query dengan parameter ID alat
        Using commandUpdateStatus As New OdbcCommand(queryUpdateStatus, Conn)
            commandUpdateStatus.Parameters.AddWithValue("@Id_alat", idAlat)
            commandUpdateStatus.ExecuteNonQuery()
        End Using
    End Sub
End Class