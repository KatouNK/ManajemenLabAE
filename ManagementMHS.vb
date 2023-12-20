Imports System.Data.Odbc

Public Class ManagementMHS
    Dim connectionString As String = "Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root"
    Private idadmin As String

    Public Sub New(ByVal idadmin As String)
        InitializeComponent()
        Me.idadmin = idadmin
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dataMHSbaru As New DataMHSbaru(idadmin)
        dataMHSbaru.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim mainform As New MainForm(idadmin)
        mainform.Show()
        Me.Hide()
    End Sub

    Private Sub ManagementMHS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowMahasiswaData()
    End Sub

    Private Sub ShowMahasiswaData()
        Try
            Using connection As New OdbcConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT * FROM mahasiswa"

                Dim adapter As New OdbcDataAdapter(query, connection)
                Dim table As New DataTable()

                adapter.Fill(table)
                DataGridView1.DataSource = table
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class