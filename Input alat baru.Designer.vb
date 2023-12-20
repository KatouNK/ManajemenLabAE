<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Input_alat_baru
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Input_alat_baru))
        TextBoxIdAlat = New TextBox()
        TextBoxNamaAlat = New TextBox()
        TextBoxBeratAlat = New TextBox()
        TextBoxHargaAlat = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        TextBoxIDlab = New TextBox()
        Label5 = New Label()
        Button1 = New Button()
        Label6 = New Label()
        LinkLabel1 = New LinkLabel()
        Button2 = New Button()
        SuspendLayout()
        ' 
        ' TextBoxIdAlat
        ' 
        TextBoxIdAlat.Location = New Point(65, 130)
        TextBoxIdAlat.Name = "TextBoxIdAlat"
        TextBoxIdAlat.Size = New Size(80, 23)
        TextBoxIdAlat.TabIndex = 0
        ' 
        ' TextBoxNamaAlat
        ' 
        TextBoxNamaAlat.Location = New Point(166, 130)
        TextBoxNamaAlat.Name = "TextBoxNamaAlat"
        TextBoxNamaAlat.Size = New Size(262, 23)
        TextBoxNamaAlat.TabIndex = 1
        ' 
        ' TextBoxBeratAlat
        ' 
        TextBoxBeratAlat.Location = New Point(449, 130)
        TextBoxBeratAlat.Name = "TextBoxBeratAlat"
        TextBoxBeratAlat.Size = New Size(135, 23)
        TextBoxBeratAlat.TabIndex = 2
        ' 
        ' TextBoxHargaAlat
        ' 
        TextBoxHargaAlat.Location = New Point(605, 130)
        TextBoxHargaAlat.Name = "TextBoxHargaAlat"
        TextBoxHargaAlat.Size = New Size(137, 23)
        TextBoxHargaAlat.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(65, 112)
        Label1.Name = "Label1"
        Label1.Size = New Size(41, 15)
        Label1.TabIndex = 4
        Label1.Text = "Id Alat"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(166, 112)
        Label2.Name = "Label2"
        Label2.Size = New Size(61, 15)
        Label2.TabIndex = 5
        Label2.Text = "Nama alat"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(605, 112)
        Label3.Name = "Label3"
        Label3.Size = New Size(61, 15)
        Label3.TabIndex = 6
        Label3.Text = "Harga alat"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(449, 112)
        Label4.Name = "Label4"
        Label4.Size = New Size(56, 15)
        Label4.TabIndex = 7
        Label4.Text = "Berat alat"
        ' 
        ' TextBoxIDlab
        ' 
        TextBoxIDlab.Location = New Point(67, 203)
        TextBoxIDlab.Name = "TextBoxIDlab"
        TextBoxIDlab.Size = New Size(160, 23)
        TextBoxIDlab.TabIndex = 8
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(65, 185)
        Label5.Name = "Label5"
        Label5.Size = New Size(90, 15)
        Label5.TabIndex = 9
        Label5.Text = "ID laboratorium"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(57, 367)
        Button1.Name = "Button1"
        Button1.Size = New Size(120, 23)
        Button1.TabIndex = 10
        Button1.Text = "Simpan alat"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.Location = New Point(57, 50)
        Label6.Name = "Label6"
        Label6.Size = New Size(325, 32)
        Label6.TabIndex = 11
        Label6.Text = "Silahkan Input Data Alat Baru"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Location = New Point(57, 393)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(247, 15)
        LinkLabel1.TabIndex = 12
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "Cek tatacara penamaan penyimpanan barang"
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(685, 363)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 13
        Button2.Text = "Kembali"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Input_alat_baru
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button2)
        Controls.Add(LinkLabel1)
        Controls.Add(Label6)
        Controls.Add(Button1)
        Controls.Add(Label5)
        Controls.Add(TextBoxIDlab)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TextBoxHargaAlat)
        Controls.Add(TextBoxBeratAlat)
        Controls.Add(TextBoxNamaAlat)
        Controls.Add(TextBoxIdAlat)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Input_alat_baru"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Input alat"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBoxIdAlat As TextBox
    Friend WithEvents TextBoxNamaAlat As TextBox
    Friend WithEvents TextBoxBeratAlat As TextBox
    Friend WithEvents TextBoxHargaAlat As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxIDlab As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Button2 As Button
End Class
