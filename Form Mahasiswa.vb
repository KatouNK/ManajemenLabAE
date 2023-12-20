Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form_mahasiswa

    Private NimDiterima As String

    Public Sub New(Nim As String)
        InitializeComponent()
        NimDiterima = Nim
    End Sub
    Private Sub button1_click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Form_pemesanan As New Form_Pemesanan(NimDiterima)
        Form_pemesanan.Show()
        Me.Hide()
    End Sub

    Public WriteOnly Property SetUsernameLabel As String
        Set(value As String)
            Label2.Text = value
        End Set
    End Property


    Private Sub button2_click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Form_pengembalian As New Form_Pengembalian(NimDiterima)
        Form_pengembalian.Show()
        Me.Hide()
    End Sub

    Private Sub Form_mahasiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click
        Dim form1 As New Form1()
        form1.Show()
        Me.Close()
    End Sub

End Class