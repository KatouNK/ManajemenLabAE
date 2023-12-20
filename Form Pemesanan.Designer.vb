<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Pemesanan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form_Pemesanan))
        Button1 = New Button()
        Label1 = New Label()
        Button3 = New Button()
        DataGridView1 = New DataGridView()
        DateTimePicker1 = New DateTimePicker()
        Label2 = New Label()
        DateTimePicker2 = New DateTimePicker()
        Label3 = New Label()
        kembali = New Button()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Label4 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(644, 76)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 0
        Button1.Text = "Pencarian"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(82, 111)
        Label1.Name = "Label1"
        Label1.Size = New Size(88, 15)
        Label1.TabIndex = 3
        Label1.Text = "Hasil pencarian"
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(81, 403)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 5
        Button3.Text = "Pinjam Alat"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(82, 129)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(637, 150)
        DataGridView1.TabIndex = 6
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(83, 308)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(200, 23)
        DateTimePicker1.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(82, 288)
        Label2.Name = "Label2"
        Label2.Size = New Size(118, 15)
        Label2.TabIndex = 8
        Label2.Text = "Tanggal Peminjaman"
        ' 
        ' DateTimePicker2
        ' 
        DateTimePicker2.Location = New Point(413, 308)
        DateTimePicker2.Name = "DateTimePicker2"
        DateTimePicker2.Size = New Size(200, 23)
        DateTimePicker2.TabIndex = 9
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(413, 288)
        Label3.Name = "Label3"
        Label3.Size = New Size(127, 15)
        Label3.TabIndex = 10
        Label3.Text = "Tanggal Pengembalian"
        ' 
        ' kembali
        ' 
        kembali.Location = New Point(644, 403)
        kembali.Name = "kembali"
        kembali.Size = New Size(75, 23)
        kembali.TabIndex = 11
        kembali.Text = "Kembali"
        kembali.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(83, 74)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(555, 23)
        TextBox1.TabIndex = 12
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(81, 362)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(638, 23)
        TextBox2.TabIndex = 13
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(84, 340)
        Label4.Name = "Label4"
        Label4.Size = New Size(130, 15)
        Label4.TabIndex = 14
        Label4.Text = "Keperluan peminjaman"
        ' 
        ' Form_Pemesanan
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label4)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(kembali)
        Controls.Add(Label3)
        Controls.Add(DateTimePicker2)
        Controls.Add(Label2)
        Controls.Add(DateTimePicker1)
        Controls.Add(DataGridView1)
        Controls.Add(Button3)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form_Pemesanan"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form Peminjaman Alat"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents kembali As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label4 As Label
End Class
