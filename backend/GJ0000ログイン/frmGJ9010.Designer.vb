Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ9010
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.txt_KI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.cmdSav = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdCan = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.cbo_KOFU_TUMI_SITEN_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.grpDATAKBN = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rbtn_NYURYOKU_JYOKYO2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtn_NYURYOKU_JYOKYO1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_KEIYAKUSYA_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_KEIYAKUSYA_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton5 = New GrapeCity.Win.Editors.DropDownButton()
        Me.pnlButton.SuspendLayout()
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_KOFU_TUMI_SITEN_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDATAKBN.SuspendLayout()
        CType(Me.cob_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdCan)
        Me.pnlButton.Controls.Add(Me.cmdSav)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSav, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCan, 0)
        '
        'lblLOGONUSER
        '
        Me.lblLOGONUSER.Text = "さん"
        '
        'lblSysdate
        '
        Me.lblSysdate.Text = "2010年8月26日（木）"
        '
        'cmdEnd
        '
        Me.cmdEnd.TabIndex = 2
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'txt_KI
        '
        Me.txt_KI.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_KI.DropDown.AllowDrop = False
        Me.txt_KI.Enabled = False
        Me.txt_KI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_KI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_KI.Format = "9"
        Me.txt_KI.HighlightText = True
        Me.txt_KI.InputCheck = True
        Me.txt_KI.Location = New System.Drawing.Point(244, 94)
        Me.txt_KI.MaxLength = 2
        Me.txt_KI.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_KI.Name = "txt_KI"
        Me.GcShortcut1.SetShortcuts(Me.txt_KI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_KI, Object)}, New String() {"ShortcutClear"}))
        Me.txt_KI.Size = New System.Drawing.Size(31, 20)
        Me.txt_KI.TabIndex = 0
        Me.txt_KI.Text = "99"
        '
        'cmdSav
        '
        Me.cmdSav.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSav.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSav.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSav.Location = New System.Drawing.Point(36, 6)
        Me.cmdSav.Name = "cmdSav"
        Me.cmdSav.Size = New System.Drawing.Size(92, 44)
        Me.cmdSav.TabIndex = 0
        Me.cmdSav.Text = "実行"
        Me.cmdSav.UseVisualStyleBackColor = True
        '
        'cmdCan
        '
        Me.cmdCan.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCan.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCan.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCan.Location = New System.Drawing.Point(150, 6)
        Me.cmdCan.Name = "cmdCan"
        Me.cmdCan.Size = New System.Drawing.Size(92, 44)
        Me.cmdCan.TabIndex = 1
        Me.cmdCan.Text = "キャンセル"
        Me.cmdCan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(52, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 15)
        Me.Label2.TabIndex = 872
        Me.Label2.Text = "■コピー後の入力確認有無"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(52, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 874
        Me.Label3.Text = "■対象期"
        '
        'cbo_KOFU_TUMI_SITEN_CD
        '
        Me.cbo_KOFU_TUMI_SITEN_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cbo_KOFU_TUMI_SITEN_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cbo_KOFU_TUMI_SITEN_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cbo_KOFU_TUMI_SITEN_CD.Format = "9"
        Me.cbo_KOFU_TUMI_SITEN_CD.HighlightText = True
        Me.cbo_KOFU_TUMI_SITEN_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cbo_KOFU_TUMI_SITEN_CD.ListHeaderPane.Height = 22
        Me.cbo_KOFU_TUMI_SITEN_CD.Location = New System.Drawing.Point(560, 689)
        Me.cbo_KOFU_TUMI_SITEN_CD.MaxLength = 3
        Me.cbo_KOFU_TUMI_SITEN_CD.Name = "cbo_KOFU_TUMI_SITEN_CD"
        Me.cbo_KOFU_TUMI_SITEN_CD.Size = New System.Drawing.Size(40, 22)
        Me.cbo_KOFU_TUMI_SITEN_CD.TabIndex = 927
        Me.cbo_KOFU_TUMI_SITEN_CD.Text = "000"
        '
        'grpDATAKBN
        '
        Me.grpDATAKBN.Controls.Add(Me.rbtn_NYURYOKU_JYOKYO2)
        Me.grpDATAKBN.Controls.Add(Me.rbtn_NYURYOKU_JYOKYO1)
        Me.grpDATAKBN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grpDATAKBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.grpDATAKBN.Location = New System.Drawing.Point(244, 157)
        Me.grpDATAKBN.Name = "grpDATAKBN"
        Me.grpDATAKBN.Size = New System.Drawing.Size(202, 38)
        Me.grpDATAKBN.TabIndex = 3
        Me.grpDATAKBN.TabStop = False
        '
        'rbtn_NYURYOKU_JYOKYO2
        '
        Me.rbtn_NYURYOKU_JYOKYO2.AutoSize = True
        Me.rbtn_NYURYOKU_JYOKYO2.BackColor = System.Drawing.Color.Transparent
        Me.rbtn_NYURYOKU_JYOKYO2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_NYURYOKU_JYOKYO2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_NYURYOKU_JYOKYO2.Location = New System.Drawing.Point(108, 12)
        Me.rbtn_NYURYOKU_JYOKYO2.Name = "rbtn_NYURYOKU_JYOKYO2"
        Me.rbtn_NYURYOKU_JYOKYO2.Size = New System.Drawing.Size(91, 20)
        Me.rbtn_NYURYOKU_JYOKYO2.TabIndex = 1
        Me.rbtn_NYURYOKU_JYOKYO2.Text = "入力確定"
        Me.rbtn_NYURYOKU_JYOKYO2.UseVisualStyleBackColor = False
        '
        'rbtn_NYURYOKU_JYOKYO1
        '
        Me.rbtn_NYURYOKU_JYOKYO1.AutoSize = True
        Me.rbtn_NYURYOKU_JYOKYO1.BackColor = System.Drawing.Color.Transparent
        Me.rbtn_NYURYOKU_JYOKYO1.Checked = True
        Me.rbtn_NYURYOKU_JYOKYO1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtn_NYURYOKU_JYOKYO1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtn_NYURYOKU_JYOKYO1.Location = New System.Drawing.Point(10, 12)
        Me.rbtn_NYURYOKU_JYOKYO1.Name = "rbtn_NYURYOKU_JYOKYO1"
        Me.rbtn_NYURYOKU_JYOKYO1.Size = New System.Drawing.Size(76, 20)
        Me.rbtn_NYURYOKU_JYOKYO1.TabIndex = 0
        Me.rbtn_NYURYOKU_JYOKYO1.TabStop = True
        Me.rbtn_NYURYOKU_JYOKYO1.Text = "入力中"
        Me.rbtn_NYURYOKU_JYOKYO1.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(52, 131)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 15)
        Me.Label11.TabIndex = 977
        Me.Label11.Text = "■契約番号"
        '
        'cob_KEIYAKUSYA_CD
        '
        Me.cob_KEIYAKUSYA_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KEIYAKUSYA_CD.DropDown.AllowDrop = False
        Me.cob_KEIYAKUSYA_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKUSYA_CD.Format = "9"
        Me.cob_KEIYAKUSYA_CD.HighlightText = True
        Me.cob_KEIYAKUSYA_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KEIYAKUSYA_CD.ListHeaderPane.Height = 22
        Me.cob_KEIYAKUSYA_CD.Location = New System.Drawing.Point(244, 128)
        Me.cob_KEIYAKUSYA_CD.MaxLength = 5
        Me.cob_KEIYAKUSYA_CD.Name = "cob_KEIYAKUSYA_CD"
        Me.cob_KEIYAKUSYA_CD.Size = New System.Drawing.Size(51, 22)
        Me.cob_KEIYAKUSYA_CD.Spin.AllowSpin = False
        Me.cob_KEIYAKUSYA_CD.TabIndex = 1
        Me.cob_KEIYAKUSYA_CD.Tag = "都道府県"
        Me.cob_KEIYAKUSYA_CD.Text = "00000"
        '
        'cob_KEIYAKUSYA_NM
        '
        Me.cob_KEIYAKUSYA_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_KEIYAKUSYA_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KEIYAKUSYA_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KEIYAKUSYA_NM.ListHeaderPane.Height = 22
        Me.cob_KEIYAKUSYA_NM.ListHeaderPane.Visible = False
        Me.cob_KEIYAKUSYA_NM.Location = New System.Drawing.Point(301, 128)
        Me.cob_KEIYAKUSYA_NM.Name = "cob_KEIYAKUSYA_NM"
        Me.cob_KEIYAKUSYA_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton5})
        Me.cob_KEIYAKUSYA_NM.Size = New System.Drawing.Size(415, 22)
        Me.cob_KEIYAKUSYA_NM.TabIndex = 2
        Me.cob_KEIYAKUSYA_NM.TabStop = False
        '
        'DropDownButton5
        '
        Me.DropDownButton5.Name = "DropDownButton5"
        '
        'frmGJ9010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.cob_KEIYAKUSYA_CD)
        Me.Controls.Add(Me.cob_KEIYAKUSYA_NM)
        Me.Controls.Add(Me.txt_KI)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.grpDATAKBN)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmGJ9010"
        Me.Text = "(mX)"
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.grpDATAKBN, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.txt_KI, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKUSYA_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_KEIYAKUSYA_CD, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.txt_KI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_KOFU_TUMI_SITEN_CD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDATAKBN.ResumeLayout(False)
        Me.grpDATAKBN.PerformLayout()
        CType(Me.cob_KEIYAKUSYA_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_KEIYAKUSYA_NM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents cmdSav As JBD.Gjs.Win.JButton
    Friend WithEvents cmdCan As JBD.Gjs.Win.JButton
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents cbo_KOFU_TUMI_SITEN_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents grpDATAKBN As JBD.Gjs.Win.GroupBox
    Friend WithEvents rbtn_NYURYOKU_JYOKYO2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtn_NYURYOKU_JYOKYO1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents txt_KI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents cob_KEIYAKUSYA_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_KEIYAKUSYA_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton5 As GrapeCity.Win.Editors.DropDownButton

End Class
