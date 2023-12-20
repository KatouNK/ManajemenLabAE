Imports System.Data.Odbc

Public Class ManagementLab

    Private idadmin As String

    Public Sub New(ByVal idadmin As String)
        InitializeComponent()
        Me.idadmin = idadmin
    End Sub

    Private Sub ManagementLab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Pastikan koneksi ke basis data
            Using connection As New OdbcConnection("Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root")
                connection.Open()

                ' Query SQL untuk mendapatkan data dari tabel laboratorium
                Dim query As String = "SELECT * FROM laboratorium"

                Using adapter As New OdbcDataAdapter(query, connection)
                    Dim table As New DataTable()

                    ' Mengisi DataGridView dengan data dari tabel laboratorium
                    adapter.Fill(table)
                    DataGridView1.DataSource = table
                End Using

                ' Query SQL untuk mendapatkan data dari tabel pemesanan
                Dim queryPemesanan As String = "SELECT * FROM pemesanan"

                Using adapter2 As New OdbcDataAdapter(queryPemesanan, connection)
                    Dim table2 As New DataTable()

                    ' Mengisi DataGridView2 dengan data dari tabel pemesanan
                    adapter2.Fill(table2)
                    DataGridView2.DataSource = table2
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim mainform As New MainForm(idadmin)
        mainform.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formManagementAlat As New ManagementAlat(idadmin)
        formManagementAlat.Show()
        Me.Hide()
    End Sub
End Class