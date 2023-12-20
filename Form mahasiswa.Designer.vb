<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_mahasiswa
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
        components = New ComponentModel.Container()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form_mahasiswa))
        Label1 = New Label()
        Label2 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        LogoutButton = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(32, 38)
        Label1.Name = "Label1"
        Label1.Size = New Size(70, 32)
        Label1.TabIndex = 0
        Label1.Text = "Halo "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(85, 38)
        Label2.Name = "Label2"
        Label2.Size = New Size(129, 32)
        Label2.TabIndex = 1
        Label2.Text = "Mahasiswa"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(40, 315)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 4
        Button1.Text = "Reservasi"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(139, 315)
        Button2.Name = "Button2"
        Button2.Size = New Size(98, 23)
        Button2.TabIndex = 5
        Button2.Text = "Pengembalian"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(61, 4)
        ' 
        ' LogoutButton
        ' 
        LogoutButton.Location = New Point(676, 315)
        LogoutButton.Name = "LogoutButton"
        LogoutButton.Size = New Size(75, 23)
        LogoutButton.TabIndex = 6
        LogoutButton.Text = "Log out"
        LogoutButton.TextImageRelation = TextImageRelation.ImageBeforeText
        LogoutButton.UseVisualStyleBackColor = True
        ' 
        ' Form_mahasiswa
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(LogoutButton)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form_mahasiswa"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form mahasiswa"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents LogoutButton As Button
End Class
