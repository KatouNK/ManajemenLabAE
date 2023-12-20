Imports System.Data.Odbc
Imports System.Drawing.Printing

Public Class laporan_laboratorium

    Dim connectionString As String = "Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root"
    Private idadmin As String

    Public Sub New(ByVal idadmin As String)
        InitializeComponent()
        Me.idadmin = idadmin
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Panel1.AutoScroll = True

        ' Memanggil metode untuk menampilkan data dari setiap tabel
        ShowPeminjamanData()
        ShowPengembalianData()
        ShowDataTabelTerima()
        ShowDataAlatrusak()
    End Sub

    Private Sub ShowPeminjamanData()
        Try
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT p.id_peminjaman, m.nama_mhs AS 'Nama Peminjam', a.Nama_Alat AS 'Nama Alat', p.tgl_peminjaman " &
                                      "FROM peminjaman p " &
                                      "INNER JOIN mahasiswa m ON p.nim = m.Nim " &
                                      "INNER JOIN alat a ON p.id_alat = a.Id_Alat"

                Dim adapter As New OdbcDataAdapter(query, connection)
                Dim table As New DataTable()

                adapter.Fill(table)
                DataGridView1.DataSource = table
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ShowPengembalianData()
        Try
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT * FROM pengembalian"

                Dim adapter As New OdbcDataAdapter(query, connection)
                Dim table As New DataTable()

                adapter.Fill(table)
                DataGridView2.DataSource = table
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ShowDataTabelTerima()
        Try
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT t.id_terima, ad.nama_admin AS 'Nama Penerima', t.id_alat, a.Nama_Alat AS 'Nama Alat', t.tgl_pelaporan " &
                                      "FROM terima t " &
                                      "INNER JOIN account_admin ad ON t.id_penerima = ad.username " &
                                      "INNER JOIN alat a ON t.id_alat = a.Id_Alat"

                Dim adapter As New OdbcDataAdapter(query, connection)
                Dim table As New DataTable()

                adapter.Fill(table)
                DataGridView3.DataSource = table
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ShowDataAlatrusak()
        Try
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT * FROM alat_rusak"

                Dim adapter As New OdbcDataAdapter(query, connection)
                Dim table As New DataTable()

                adapter.Fill(table)
                DataGridView4.DataSource = table
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim mainform As New MainForm(idadmin)
        mainform.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Mengatur posisi awal cetakan
        Dim yPos As Integer = 0
        Dim count As Integer = 0

        ' Meloop setiap DataGridView yang ingin dicetak
        For Each dgv As DataGridView In {DataGridView1, DataGridView2, DataGridView3, DataGridView4}
            ' Membuat objek bitmap untuk menampung isi DataGridView
            Dim imagebmp As New Bitmap(dgv.Width, dgv.Height)
            dgv.DrawToBitmap(imagebmp, New Rectangle(0, 0, dgv.Width, dgv.Height))

            ' Menentukan posisi cetakan pada halaman
            Dim rect As New Rectangle(0, yPos, dgv.Width, dgv.Height)

            ' Menggambar DataGridView ke halaman cetakan
            e.Graphics.DrawImage(imagebmp, rect)

            ' Menghitung posisi untuk DataGridView berikutnya
            yPos += dgv.Height
            count += 1

            ' Memeriksa apakah masih ada DataGridView berikutnya
            If count < {DataGridView1, DataGridView2, DataGridView3, DataGridView4}.Length Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
                ' Reset posisi cetakan untuk cetakan berikutnya (jika ada)
                yPos = 0
                count = 0
            End If
        Next
    End Sub
End Class
