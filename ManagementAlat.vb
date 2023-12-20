Imports System.Data.Odbc
Imports System.Reflection.Emit
Imports System.Transactions

Public Class ManagementAlat

    Private idadmin As String

    Public Sub New(ByVal idadmin As String)
        InitializeComponent()
        Me.idadmin = idadmin
    End Sub

    Private Sub ManagementAlat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using connection As New OdbcConnection("Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root")
            connection.Open()

            ' Query SQL untuk mendapatkan data dari tabel laboratorium
            Dim query As String = "SELECT * FROM alat"

            Using adapter As New OdbcDataAdapter(query, connection)
                Dim table As New DataTable()

                ' Mengisi DataGridView dengan data dari tabel laboratorium
                adapter.Fill(table)
                DataGridView1.DataSource = table
            End Using
        End Using

        Dim jumlahAlatRusak As Integer = HitungAlatRusak(DataGridView1)
        Label3.Text = jumlahAlatRusak.ToString()

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


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim mainform As New MainForm(idadmin)
        mainform.Show()
        Me.Hide()
    End Sub

    Private Sub Input_alat_baru_Click(sender As Object, e As EventArgs) Handles Input_alat_baru.Click
        Dim inputAlat As New Input_alat_baru(idadmin)
        inputAlat.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connectionString As String = "Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root"

        Using connection As New OdbcConnection(connectionString)
            Try
                connection.Open()

                Dim idAlat As String = TextBox1.Text

                ' Menghapus data dari tabel simpan berdasarkan Id_Alat
                Dim queryDeleteSimpan As String = "DELETE FROM simpan WHERE id_alat = ?"

                Using commandDeleteSimpan As New OdbcCommand(queryDeleteSimpan, connection)
                    commandDeleteSimpan.Parameters.AddWithValue("@id_alat", idAlat)
                    commandDeleteSimpan.ExecuteNonQuery()
                End Using

                ' Pindahkan data yang dihapus dari tabel alat ke tabel alat_rusak
                Dim queryMoveToAlatRusak As String = "INSERT INTO alat_rusak (id_alat, nama_alat, tgl_penarikan) " &
                                                  "SELECT Id_Alat, Nama_Alat, CURDATE() FROM alat WHERE Id_Alat = ?"

                Using commandMoveToAlatRusak As New OdbcCommand(queryMoveToAlatRusak, connection)
                    commandMoveToAlatRusak.Parameters.AddWithValue("@Id_Alat", idAlat)
                    Dim rowsAffected As Integer = commandMoveToAlatRusak.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Data dari tabel alat berhasil dipindahkan ke tabel alat_rusak.")
                    Else
                        MessageBox.Show("Data dengan Id_Alat tersebut tidak ditemukan di tabel alat.")
                    End If
                End Using

                ' Menghapus data dari tabel alat berdasarkan Id_Alat
                Dim queryDeleteAlat As String = "DELETE FROM alat WHERE Id_Alat = ?"

                Using commandDeleteAlat As New OdbcCommand(queryDeleteAlat, connection)
                    commandDeleteAlat.Parameters.AddWithValue("@Id_Alat", idAlat)
                    Dim rowsAffected As Integer = commandDeleteAlat.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Data dari tabel alat berhasil dihapus.")
                    Else
                        MessageBox.Show("Data dengan Id_Alat tersebut tidak ditemukan di tabel alat.")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

End Class