<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataMHSbaru
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(DataMHSbaru))
        TextBoxNIM = New TextBox()
        TextBoxNama = New TextBox()
        TextBoxNoKoin = New TextBox()
        TextBoxKelas = New TextBox()
        Button1 = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Button2 = New Button()
        SuspendLayout()
        ' 
        ' TextBoxNIM
        ' 
        TextBoxNIM.Location = New Point(52, 124)
        TextBoxNIM.Name = "TextBoxNIM"
        TextBoxNIM.Size = New Size(160, 23)
        TextBoxNIM.TabIndex = 0
        ' 
        ' TextBoxNama
        ' 
        TextBoxNama.Location = New Point(233, 124)
        TextBoxNama.Name = "TextBoxNama"
        TextBoxNama.Size = New Size(257, 23)
        TextBoxNama.TabIndex = 1
        ' 
        ' TextBoxNoKoin
        ' 
        TextBoxNoKoin.Location = New Point(184, 185)
        TextBoxNoKoin.Name = "TextBoxNoKoin"
        TextBoxNoKoin.Size = New Size(58, 23)
        TextBoxNoKoin.TabIndex = 2
        ' 
        ' TextBoxKelas
        ' 
        TextBoxKelas.Location = New Point(52, 185)
        TextBoxKelas.Name = "TextBoxKelas"
        TextBoxKelas.Size = New Size(115, 23)
        TextBoxKelas.TabIndex = 3
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(52, 260)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 4
        Button1.Text = "Registrasi"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(49, 107)
        Label1.Name = "Label1"
        Label1.Size = New Size(91, 15)
        Label1.TabIndex = 5
        Label1.Text = "Nim mahasiswa"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(233, 106)
        Label2.Name = "Label2"
        Label2.Size = New Size(100, 15)
        Label2.TabIndex = 6
        Label2.Text = "Nama mahasiswa"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(52, 167)
        Label3.Name = "Label3"
        Label3.Size = New Size(34, 15)
        Label3.TabIndex = 7
        Label3.Text = "Kelas"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(184, 167)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 15)
        Label4.TabIndex = 8
        Label4.Text = "No koin"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(52, 28)
        Label5.Name = "Label5"
        Label5.Size = New Size(255, 30)
        Label5.TabIndex = 9
        Label5.Text = "Registrasi data mahasiswa"
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(667, 260)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 10
        Button2.Text = "Kembali"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' DataMHSbaru
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 329)
        Controls.Add(Button2)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Controls.Add(TextBoxKelas)
        Controls.Add(TextBoxNoKoin)
        Controls.Add(TextBoxNama)
        Controls.Add(TextBoxNIM)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "DataMHSbaru"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Registrasi mahasiswa"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBoxNIM As TextBox
    Friend WithEvents TextBoxNama As TextBox
    Friend WithEvents TextBoxNoKoin As TextBox
    Friend WithEvents TextBoxKelas As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button2 As Button
End Class
