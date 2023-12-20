Public Class MainForm

    Private idadmin As String

    Public Sub New(ByVal idAdmin As String)
        InitializeComponent()
        Me.idadmin = idAdmin
        SetUsernameLabel = idAdmin
    End Sub

    Public WriteOnly Property SetUsernameLabel As String
        Set(value As String)
            Label2.Text = value
        End Set
    End Property

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim formManagementlab As New ManagementLab(idadmin)
        formManagementlab.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formManagementAlat As New ManagementAlat(idadmin)
        formManagementAlat.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim formLaporan As New laporan_laboratorium(idadmin)
        formLaporan.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim formManagementMHS As New ManagementMHS(idadmin)
        formManagementMHS.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim form1 As New Form1()
        form1.Show()
        Me.Hide()
    End Sub

    ' ...
End Class
