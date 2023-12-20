Imports System.Data.Common
Imports System.Data.Odbc
Module koneksidatabase
    Public Conn As OdbcConnection
    Public DA As OdbcDataAdapter
    Public DS As DataSet

    Sub koneksiDB()
        Try
            Conn = New OdbcConnection("Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root")
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
                MsgBox("koneksi ke database sukses", vbInformation, "koneksi sukses")

            End If
        Catch ex As Exception
            MsgBox("koneksi kedatabase gagal", vbCritical, "koneksi gagal")

        End Try
    End Sub


End Module