<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ0000
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_UserId = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_PassWord = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label1 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdLogin = New JBD.Gjs.Win.Button(Me.components)
        Me.cmdEnd = New JBD.Gjs.Win.Button(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.txt_UserId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PassWord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(74, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ユーザーＩＤ"
        '
        'txt_UserId
        '
        Me.txt_UserId.DropDown.AllowDrop = False
        Me.txt_UserId.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_UserId.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_UserId.HighlightText = True
        Me.txt_UserId.Location = New System.Drawing.Point(183, 44)
        Me.txt_UserId.MaxLength = 10
        Me.txt_UserId.Name = "txt_UserId"
        Me.txt_UserId.Size = New System.Drawing.Size(176, 22)
        Me.txt_UserId.TabIndex = 3
        Me.txt_UserId.Text = "XXXXXXXXXX"
        '
        'txt_PassWord
        '
        Me.txt_PassWord.DropDown.AllowDrop = False
        Me.txt_PassWord.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_PassWord.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_PassWord.HighlightText = True
        Me.txt_PassWord.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_PassWord.Location = New System.Drawing.Point(183, 85)
        Me.txt_PassWord.MaxLength = 20
        Me.txt_PassWord.Name = "txt_PassWord"
        Me.txt_PassWord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_PassWord.Size = New System.Drawing.Size(176, 22)
        Me.txt_PassWord.TabIndex = 5
        Me.txt_PassWord.Text = "XXXXXXXXXXXXXXXXXXXX"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(74, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "パスワード"
        '
        'cmdLogin
        '
        Me.cmdLogin.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLogin.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdLogin.Location = New System.Drawing.Point(59, 255)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(94, 35)
        Me.cmdLogin.TabIndex = 6
        Me.cmdLogin.Text = "ログイン"
        Me.cmdLogin.UseVisualStyleBackColor = True
        '
        'cmdEnd
        '
        Me.cmdEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEnd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdEnd.Location = New System.Drawing.Point(318, 255)
        Me.cmdEnd.Name = "cmdEnd"
        Me.cmdEnd.Size = New System.Drawing.Size(94, 35)
        Me.cmdEnd.TabIndex = 7
        Me.cmdEnd.Text = "終了"
        Me.cmdEnd.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.GJ0000.My.Resources.Resources.GJS_LOGIN
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(100, 113)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(249, 161)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'frmGJ0000
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(474, 312)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdEnd)
        Me.Controls.Add(Me.cmdLogin)
        Me.Controls.Add(Me.txt_PassWord)
        Me.Controls.Add(Me.txt_UserId)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmGJ0000"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "日本養鶏協会　互助防疫システム　ログイン"
        CType(Me.txt_UserId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PassWord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents txt_UserId As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_PassWord As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label1 As JBD.Gjs.Win.Label
    Friend WithEvents cmdLogin As JBD.Gjs.Win.Button
    Friend WithEvents cmdEnd As JBD.Gjs.Win.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
