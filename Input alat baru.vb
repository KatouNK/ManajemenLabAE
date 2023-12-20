Imports System.Data.Odbc

Public Class Input_alat_baru

    Private idadmin As String

    Public Sub New(ByVal idadmin As String)
        InitializeComponent()
        Me.idadmin = idadmin
    End Sub

    Private Sub Input_alat_baru_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label6.Text = idadmin
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connectionString As String = "Dsn=data_source;uid=root;database=pengelolaan_labolatorium_ae;db=pengelolaan_labolatorium_ae;no_schema=1;port=3306;server=localhost;user=root"

        Using Conn As New OdbcConnection(connectionString)
            Conn.Open()

            ' Mendapatkan nilai dari TextBox
            Dim idAlat As String = TextBoxIdAlat.Text
            Dim namaAlat As String = TextBoxNamaAlat.Text
            Dim beratAlat As String = TextBoxBeratAlat.Text
            Dim hargaAlat As String = TextBoxHargaAlat.Text
            Dim statusAlat As String = "DISIMPAN" ' Misalnya, status default
            Dim idLab As String = TextBoxIDlab.Text ' Ambil id_lab dari TextBox

            ' Memeriksa keberadaan Id_Alat dan id_lab sebelum INSERT
            If IsIdAlatExist(idAlat, Conn) Then
                MessageBox.Show("Id Alat sudah ada dalam tabel.")
            ElseIf Not IsIdLabExist(idLab, Conn) Then
                MessageBox.Show("Id Lab tidak ditemukan dalam tabel laboratorium.")
            Else
                ' Meminta input ID Simpan
                Dim idSimpan As String = InputBox("Masukkan ID Simpan:", "Input ID Simpan")

                ' Jika input kosong, tidak melakukan operasi INSERT
                If Not String.IsNullOrEmpty(idSimpan) Then
                    ' Jalankan perintah SQL INSERT untuk tabel alat
                    Dim queryInsertAlat As String = "INSERT INTO alat (Id_Alat, Nama_Alat, Berat_Alat, Harga_Alat, Status_Alat) VALUES (?, ?, ?, ?, ?)"

                    Using commandInsertAlat As New OdbcCommand(queryInsertAlat, Conn)
                        commandInsertAlat.Parameters.AddWithValue("@Id_Alat", idAlat)
                        commandInsertAlat.Parameters.AddWithValue("@Nama_Alat", namaAlat)
                        commandInsertAlat.Parameters.AddWithValue("@Berat_Alat", beratAlat)
                        commandInsertAlat.Parameters.AddWithValue("@Harga_Alat", hargaAlat)
                        commandInsertAlat.Parameters.AddWithValue("@Status_Alat", statusAlat)

                        ' Jalankan perintah SQL INSERT
                        commandInsertAlat.ExecuteNonQuery()
                    End Using

                    ' Query untuk menyimpan data ke tabel simpan
                    Dim querySimpan As String = "INSERT INTO simpan (id_simpan, id_lab, id_alat, tgl_simpan) VALUES (?, ?, ?, ?)"
                    Using commandSimpan As New OdbcCommand(querySimpan, Conn)
                        commandSimpan.Parameters.AddWithValue("@id_simpan", idSimpan)
                        commandSimpan.Parameters.AddWithValue("@id_lab", idLab)
                        commandSimpan.Parameters.AddWithValue("@id_alat", idAlat)
                        commandSimpan.Parameters.AddWithValue("@tgl_simpan", DateTime.Now.ToString("yyyy-MM-dd"))

                        ' Jalankan perintah SQL INSERT untuk tabel simpan
                        commandSimpan.ExecuteNonQuery()
                    End Using

                    ' Generate random ID untuk tabel terima
                    Dim idTerima As String = Guid.NewGuid().ToString()
                    Dim Id_penerima As String = idadmin

                    ' Query untuk menyimpan data ke tabel terima
                    Dim queryTerima As String = "INSERT INTO terima (id_terima, id_penerima, id_alat, tgl_terima, tgl_pelaporan) VALUES (?, ?, ?, ?, ?)"
                    Using CommandTerima As New OdbcCommand(queryTerima, Conn)
                        CommandTerima.Parameters.AddWithValue("@id_terima", idTerima)
                        CommandTerima.Parameters.AddWithValue("@id_penerima", Id_penerima)
                        CommandTerima.Parameters.AddWithValue("@id_alat", idAlat)
                        CommandTerima.Parameters.AddWithValue("@tgl_terima", DateTime.Now.ToString("yyyy-MM-dd"))
                        CommandTerima.Parameters.AddWithValue("@tgl_pelaporan", DateTime.Now.ToString("yyyy-MM-dd"))

                        ' Jalankan perintah SQL INSERT untuk tabel terima
                        CommandTerima.ExecuteNonQuery()
                    End Using
                End If
            End If
        End Using
    End Sub


    Private Function IsIdAlatExist(idAlat As String, conn As OdbcConnection) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM alat WHERE Id_Alat = ?"

        Using command As New OdbcCommand(query, conn)
            command.Parameters.AddWithValue("@Id_Alat", idAlat)
            Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())

            ' Jika count lebih besar dari nol, berarti Id_Alat sudah ada dalam tabel
            Return count > 0
        End Using
    End Function

    Private Function IsIdLabExist(idLab As String, conn As OdbcConnection) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM laboratorium WHERE id_lab = ?"

        Using command As New OdbcCommand(query, conn)
            command.Parameters.AddWithValue("@id_lab", idLab)
            Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())

            ' Jika count lebih besar dari nol, berarti id_lab sudah ada dalam tabel
            Return count > 0
        End Using
    End Function

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBoxIDlab.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MessageBox.Show("Tata cara penamaan: [KETENTUAN DAN LANGKAH-LANGKAH
a. Barang/peralatan laboratorium yang telah tersedia dalam laboratorium
b. PLP berkoordinasi dengan Kepala Laboratorium menuliskan kode barang, 
lokasi laci, dan pelabelan warna untuk dimasukkan dalam catatan
inventaris/aset laboratorium.
c. Pencatatan yang dilakukan meliputi: tanggal inventarisasi, nama barang, 
jumlah barang, nomor kode barang dan tempat laci serta kondisi barang yang
ada.
Berikut tata cara pemberian kode pada alat-alat yang akan digunakan
Laboratorium Elektronik Mekanik di Politeknik Manufaktur Bandung:
Pencatatan terdiri dari : kode laboratorium (titik) no laci (titik) nomor
barang (titik) jumlah barang.
Misal : EM.A1.01.05
Keterangan :
1. Kode laboratorium: EM
2. No laci : Untuk laci dimulai dengan abjad diikuti dengan angka 
berdasarkan tingkatan letak laci
3. Contoh : laci A rak ke 2 maka A2
 laci A rak ke 3 maka A3 dan seterusnya
]", "Tata Cara Penamaan")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim mainform As New MainForm(idadmin)
        mainform.Show()
        Me.Hide()
    End Sub
End Class