Imports System.Data.Odbc
Imports System.Windows.Forms.DataFormats

Public Class Pemesanan
    Private namaLab As String

    Public Sub New(ByVal namaLab As String)
        InitializeComponent()
        Me.namaLab = namaLab
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

    Dim SearchResult As New DataSet()
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.Rows.Count > 0 AndAlso DataGridView1.Columns.Count > 0 Then
            Dim statusAlat As String = DataGridView1.Rows(0).Cells(2).Value.ToString()


            Try
                Using Conn As New OdbcConnection("Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root")
                    Conn.Open()

                    ' Insert pemesanan
                    Dim queryInsertPemesanan As String = "INSERT INTO pemesanan (id_pesan, id_lab, Id_alat, jumlah_pesan, tgl_pesan, pemesan) VALUES (?, ?, ?, ?, ?, ?)"

                    Dim idPemesanan As String = GenerateRandomId()
                    Dim jumlah As Integer = textboxkeperluan.Text
                    Dim tglPesan As DateTime = DateTime.Now
                    Dim idlab As String = DataGridView1.Rows(0).Cells(3).Value.ToString()
                    Dim Id_alat As String = DataGridView1.Rows(0).Cells(0).Value.ToString()



                    Using commandInsert As New OdbcCommand(queryInsertPemesanan, Conn)
                        commandInsert.Parameters.AddWithValue("id_pesan", idPemesanan)
                        commandInsert.Parameters.AddWithValue("id_lab", idlab)
                        commandInsert.Parameters.AddWithValue("Id_alat", Id_alat)
                        commandInsert.Parameters.AddWithValue("jumlah_pesan", jumlah)
                        commandInsert.Parameters.AddWithValue("tgl_pesan", tglPesan)
                        commandInsert.Parameters.AddWithValue("pemesan", namaLab)
                        commandInsert.ExecuteNonQuery()
                    End Using



                End Using

                MessageBox.Show("Pemesanan berhasil!")
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Status alat tidak valid untuk dipesan.")
        End If

    End Sub
    Private Function GenerateRandomId() As String
        Return Guid.NewGuid().ToString()
    End Function
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles textboxkeperluan.TextChanged

    End Sub

    Private Sub ButtonKembali_Click(sender As Object, e As EventArgs) Handles ButtonKembali.Click

        Dim formLab As New labForm(namaLab)
        formLab.Show()
        Me.Close()

    End Sub

End Class