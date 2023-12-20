<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Pengembalian
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form_Pengembalian))
        DataGridView1 = New DataGridView()
        Label1 = New Label()
        Button1 = New Button()
        Kembali = New Button()
        Button2 = New Button()
        TextBox1 = New TextBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(30, 53)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(722, 299)
        DataGridView1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(30, 35)
        Label1.Name = "Label1"
        Label1.Size = New Size(160, 15)
        Label1.TabIndex = 1
        Label1.Text = "Benda yang sedang dipinjam"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(30, 433)
        Button1.Name = "Button1"
        Button1.Size = New Size(132, 23)
        Button1.TabIndex = 2
        Button1.Text = "Tandai dikembalikan"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Kembali
        ' 
        Kembali.Location = New Point(677, 383)
        Kembali.Name = "Kembali"
        Kembali.Size = New Size(75, 23)
        Kembali.TabIndex = 3
        Kembali.Text = "Kembali"
        Kembali.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(30, 383)
        Button2.Name = "Button2"
        Button2.Size = New Size(164, 23)
        Button2.TabIndex = 4
        Button2.Text = "Laporkan kerusakan alat"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(209, 383)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(272, 23)
        TextBox1.TabIndex = 5
        ' 
        ' Form_Pengembalian
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 490)
        Controls.Add(TextBox1)
        Controls.Add(Button2)
        Controls.Add(Kembali)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Controls.Add(DataGridView1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form_Pengembalian"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form Pengembalian"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Kembali As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
End Class
