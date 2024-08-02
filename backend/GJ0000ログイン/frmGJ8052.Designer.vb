Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ8052
    Inherits JBD.Gjs.Win.FormX

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub
    Public Sub New(ByVal pGJSINI_Array As pGJSINI)
        MyBase.New(pGJSINI_Array)
        InitializeComponent()
    End Sub
    'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.grpDATAKBN = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_DATA_KBN2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_DATA_KBN1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdTop = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdLast = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdNext = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdBef = New JBD.Gjs.Win.JButton(Me.components)
        Me.txt_Now = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblTotal = New JBD.Gjs.Win.Label(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.txt_SITEN_NAME = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_SITEN_KANA = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_BANK_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txt_SITEN_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label1 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_SHITEN_CD = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.pnlButton.SuspendLayout()
        Me.grpDATAKBN.SuspendLayout()
        CType(Me.txt_Now, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SITEN_NAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SITEN_KANA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_BANK_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SITEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_SHITEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = "支店マスタ登録・変更"
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.lblTotal)
        Me.pnlButton.Controls.Add(Me.Label16)
        Me.pnlButton.Controls.Add(Me.txt_Now)
        Me.pnlButton.Controls.Add(Me.cmdBef)
        Me.pnlButton.Controls.Add(Me.cmdNext)
        Me.pnlButton.Controls.Add(Me.cmdLast)
        Me.pnlButton.Controls.Add(Me.cmdTop)
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.Location = New System.Drawing.Point(0, 744)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdTop, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdLast, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdNext, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdBef, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.txt_Now, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.Label16, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.lblTotal, 0)
        '
        'cmdEnd
        '
        Me.cmdEnd.TabIndex = 12
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(31, 5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 6
        Me.cmdSave.Text = "保存"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'grpDATAKBN
        '
        Me.grpDATAKBN.Controls.Add(Me.rbtn_DATA_KBN2)
        Me.grpDATAKBN.Controls.Add(Me.rbtn_DATA_KBN1)
        Me.grpDATAKBN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grpDATAKBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpDATAKBN.Location = New System.Drawing.Point(319, 112)
        Me.grpDATAKBN.Name = "grpDATAKBN"
        Me.grpDATAKBN.Size = New System.Drawing.Size(145, 38)
        Me.grpDATAKBN.TabIndex = 0
        Me.grpDATAKBN.TabStop = False
        Me.grpDATAKBN.Visible = False
        '
        'rbtn_DATA_KBN2
        '
        Me.rbtn_DATA_KBN2.AutoSize = True
        Me.rbtn_DATA_KBN2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_DATA_KBN2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.rbtn_DATA_KBN2.Location = New System.Drawing.Point(77, 12)
        Me.rbtn_DATA_KBN2.Name = "rbtn_DATA_KBN2"
        Me.rbtn_DATA_KBN2.Size = New System.Drawing.Size(61, 20)
        Me.rbtn_DATA_KBN2.TabIndex = 1
        Me.rbtn_DATA_KBN2.Text = "無効"
        Me.rbtn_DATA_KBN2.UseVisualStyleBackColor = True
        '
        'rbtn_DATA_KBN1
        '
        Me.rbtn_DATA_KBN1.AutoSize = True
        Me.rbtn_DATA_KBN1.Checked = True
        Me.rbtn_DATA_KBN1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_DATA_KBN1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.rbtn_DATA_KBN1.Location = New System.Drawing.Point(10, 12)
        Me.rbtn_DATA_KBN1.Name = "rbtn_DATA_KBN1"
        Me.rbtn_DATA_KBN1.Size = New System.Drawing.Size(61, 20)
        Me.rbtn_DATA_KBN1.TabIndex = 0
        Me.rbtn_DATA_KBN1.TabStop = True
        Me.rbtn_DATA_KBN1.Text = "有効"
        Me.rbtn_DATA_KBN1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(168, 161)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 15)
        Me.Label10.TabIndex = 963
        Me.Label10.Text = "■金融機関コード"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(168, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 15)
        Me.Label6.TabIndex = 954
        Me.Label6.Text = "■データ区分"
        Me.Label6.Visible = False
        '
        'cmdTop
        '
        Me.cmdTop.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdTop.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTop.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdTop.Location = New System.Drawing.Point(257, 14)
        Me.cmdTop.Name = "cmdTop"
        Me.cmdTop.Size = New System.Drawing.Size(40, 25)
        Me.cmdTop.TabIndex = 7
        Me.cmdTop.TabStop = False
        Me.cmdTop.Text = "≪"
        Me.cmdTop.UseVisualStyleBackColor = True
        '
        'cmdLast
        '
        Me.cmdLast.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdLast.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLast.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdLast.Location = New System.Drawing.Point(531, 14)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 25)
        Me.cmdLast.TabIndex = 11
        Me.cmdLast.Text = "≫"
        Me.cmdLast.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdNext.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdNext.Location = New System.Drawing.Point(483, 14)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 25)
        Me.cmdNext.TabIndex = 10
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdBef
        '
        Me.cmdBef.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdBef.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBef.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdBef.Location = New System.Drawing.Point(305, 14)
        Me.cmdBef.Name = "cmdBef"
        Me.cmdBef.Size = New System.Drawing.Size(40, 25)
        Me.cmdBef.TabIndex = 8
        Me.cmdBef.TabStop = False
        Me.cmdBef.Text = "<"
        Me.cmdBef.UseVisualStyleBackColor = True
        '
        'txt_Now
        '
        Me.txt_Now.ContentAlignment = System.Drawing.ContentAlignment.TopRight
        Me.txt_Now.DropDown.AllowDrop = False
        Me.txt_Now.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_Now.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_Now.Format = "9"
        Me.txt_Now.HighlightText = True
        Me.txt_Now.Location = New System.Drawing.Point(358, 14)
        Me.txt_Now.MaxLength = 9
        Me.txt_Now.Name = "txt_Now"
        Me.txt_Now.Size = New System.Drawing.Size(51, 25)
        Me.txt_Now.TabIndex = 9
        Me.txt_Now.TabStop = False
        Me.txt_Now.Text = "99999"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(413, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 15)
        Me.Label16.TabIndex = 1017
        Me.Label16.Text = "/"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblTotal.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotal.Location = New System.Drawing.Point(429, 17)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(47, 15)
        Me.lblTotal.TabIndex = 1018
        Me.lblTotal.Text = "99999"
        '
        'txt_SITEN_NAME
        '
        Me.txt_SITEN_NAME.DropDown.AllowDrop = False
        Me.txt_SITEN_NAME.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_SITEN_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_SITEN_NAME.Format = "Ｚ"
        Me.txt_SITEN_NAME.HighlightText = True
        Me.txt_SITEN_NAME.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_SITEN_NAME.Location = New System.Drawing.Point(319, 242)
        Me.txt_SITEN_NAME.MaxLength = 30
        Me.txt_SITEN_NAME.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_SITEN_NAME.Name = "txt_SITEN_NAME"
        Me.txt_SITEN_NAME.Size = New System.Drawing.Size(330, 22)
        Me.txt_SITEN_NAME.TabIndex = 5
        Me.txt_SITEN_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(168, 245)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 15)
        Me.Label5.TabIndex = 1019
        Me.Label5.Text = "■支店名（漢字）"
        '
        'txt_SITEN_KANA
        '
        Me.txt_SITEN_KANA.DropDown.AllowDrop = False
        Me.txt_SITEN_KANA.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_SITEN_KANA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_SITEN_KANA.Format = "AaK9@"
        Me.txt_SITEN_KANA.HighlightText = True
        Me.txt_SITEN_KANA.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_SITEN_KANA.Location = New System.Drawing.Point(319, 214)
        Me.txt_SITEN_KANA.MaxLength = 60
        Me.txt_SITEN_KANA.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_SITEN_KANA.Name = "txt_SITEN_KANA"
        Me.txt_SITEN_KANA.Size = New System.Drawing.Size(631, 22)
        Me.txt_SITEN_KANA.TabIndex = 4
        Me.txt_SITEN_KANA.Text = "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(168, 217)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 15)
        Me.Label19.TabIndex = 1028
        Me.Label19.Text = "■支店名（ｶﾅ）"
        '
        'txt_BANK_CD
        '
        Me.txt_BANK_CD.DropDown.AllowDrop = False
        Me.txt_BANK_CD.Enabled = False
        Me.txt_BANK_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_BANK_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_BANK_CD.Format = "9"
        Me.txt_BANK_CD.HighlightText = True
        Me.txt_BANK_CD.Location = New System.Drawing.Point(319, 158)
        Me.txt_BANK_CD.MaxLength = 4
        Me.txt_BANK_CD.Name = "txt_BANK_CD"
        Me.txt_BANK_CD.Size = New System.Drawing.Size(43, 22)
        Me.txt_BANK_CD.TabIndex = 2
        Me.txt_BANK_CD.Text = "0000"
        '
        'txt_SITEN_CD
        '
        Me.txt_SITEN_CD.DropDown.AllowDrop = False
        Me.txt_SITEN_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_SITEN_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_SITEN_CD.Format = "9"
        Me.txt_SITEN_CD.HighlightText = True
        Me.txt_SITEN_CD.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txt_SITEN_CD.Location = New System.Drawing.Point(319, 186)
        Me.txt_SITEN_CD.MaxLength = 3
        Me.txt_SITEN_CD.Name = "txt_SITEN_CD"
        Me.txt_SITEN_CD.Size = New System.Drawing.Size(34, 22)
        Me.txt_SITEN_CD.TabIndex = 3
        Me.txt_SITEN_CD.Text = "000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(168, 189)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 15)
        Me.Label1.TabIndex = 1030
        Me.Label1.Text = "■支店コード"
        '
        'txt_SHITEN_CD
        '
        Me.txt_SHITEN_CD.DropDown.AllowDrop = False
        Me.txt_SHITEN_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_SHITEN_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_SHITEN_CD.Format = "9"
        Me.txt_SHITEN_CD.HighlightText = True
        Me.txt_SHITEN_CD.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txt_SHITEN_CD.Location = New System.Drawing.Point(100, 100)
        Me.txt_SHITEN_CD.MaxLength = 3
        Me.txt_SHITEN_CD.Name = "txt_SHITEN_CD"
        Me.txt_SHITEN_CD.Size = New System.Drawing.Size(34, 22)
        Me.txt_SHITEN_CD.TabIndex = 2
        Me.txt_SHITEN_CD.Text = "000"
        '
        'frmGJ8052
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.txt_SITEN_CD)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_BANK_CD)
        Me.Controls.Add(Me.txt_SITEN_KANA)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txt_SITEN_NAME)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.grpDATAKBN)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmGJ8052"
        Me.Text = "(FS1332)支店マスタ登録・変更"
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.grpDATAKBN, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txt_SITEN_NAME, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.txt_SITEN_KANA, 0)
        Me.Controls.SetChildIndex(Me.txt_BANK_CD, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txt_SITEN_CD, 0)
        Me.pnlButton.ResumeLayout(False)
        Me.pnlButton.PerformLayout()
        Me.grpDATAKBN.ResumeLayout(False)
        Me.grpDATAKBN.PerformLayout()
        CType(Me.txt_Now, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SITEN_NAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SITEN_KANA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_BANK_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SITEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_SHITEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSave As JBD.Gjs.Win.JButton
    Friend WithEvents grpDATAKBN As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_DATA_KBN2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_DATA_KBN1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents cmdTop As JBD.Gjs.Win.JButton
    Friend WithEvents txt_Now As JBD.Gjs.Win.GcTextBox
    Friend WithEvents cmdBef As JBD.Gjs.Win.JButton
    Friend WithEvents cmdNext As JBD.Gjs.Win.JButton
    Friend WithEvents cmdLast As JBD.Gjs.Win.JButton
    Friend WithEvents lblTotal As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents txt_SITEN_NAME As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents txt_SITEN_KANA As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents txt_BANK_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txt_SITEN_CD As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label1 As JBD.Gjs.Win.Label
    Friend WithEvents txt_SHITEN_CD As JBD.Gjs.Win.GcTextBox

End Class
