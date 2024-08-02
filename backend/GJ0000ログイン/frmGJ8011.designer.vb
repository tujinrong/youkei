Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ8011
    Inherits JBD.Gjs.Win.FormL
    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub
    Public Sub New(ByVal pPFSINI_Array As pGJSINI)
        MyBase.New(pPFSINI_Array)
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
        Me.label52 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_SYURUI_KBN_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.cmdTouroku = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.cob_MEISYO_CD = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.txt_MEISYO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.txtRYAKUSYO = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.cob_MEISYO_CD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_MEISYO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRYAKUSYO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdTouroku)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdTouroku, 0)
        '
        'cmdEnd
        '
        Me.cmdEnd.TabIndex = 99
        '
        'label52
        '
        Me.label52.AutoSize = True
        Me.label52.BackColor = System.Drawing.Color.Transparent
        Me.label52.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.label52.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label52.Location = New System.Drawing.Point(195, 261)
        Me.label52.Name = "label52"
        Me.label52.Size = New System.Drawing.Size(67, 15)
        Me.label52.TabIndex = 955
        Me.label52.Text = "種類区分"
        '
        'lbl_SYURUI_KBN_NM
        '
        Me.lbl_SYURUI_KBN_NM.AutoSize = True
        Me.lbl_SYURUI_KBN_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_SYURUI_KBN_NM.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lbl_SYURUI_KBN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_SYURUI_KBN_NM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_SYURUI_KBN_NM.Location = New System.Drawing.Point(284, 261)
        Me.lbl_SYURUI_KBN_NM.Name = "lbl_SYURUI_KBN_NM"
        Me.lbl_SYURUI_KBN_NM.Size = New System.Drawing.Size(307, 15)
        Me.lbl_SYURUI_KBN_NM.TabIndex = 955
        Me.lbl_SYURUI_KBN_NM.Text = "□□□□■□□□□■□□□□■□□□□■"
        '
        'cmdTouroku
        '
        Me.cmdTouroku.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdTouroku.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTouroku.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdTouroku.Location = New System.Drawing.Point(17, 6)
        Me.cmdTouroku.Name = "cmdTouroku"
        Me.cmdTouroku.Size = New System.Drawing.Size(92, 44)
        Me.cmdTouroku.TabIndex = 4
        Me.cmdTouroku.Text = "保存"
        Me.cmdTouroku.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(195, 309)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 15)
        Me.Label2.TabIndex = 955
        Me.Label2.Text = "■名称コード"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(195, 362)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 15)
        Me.Label3.TabIndex = 955
        Me.Label3.Text = "■名称"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(195, 415)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 955
        Me.Label4.Text = "■略称"
        '
        'cob_MEISYO_CD
        '
        Me.cob_MEISYO_CD.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_MEISYO_CD.DropDown.AllowDrop = False
        Me.cob_MEISYO_CD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_MEISYO_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_MEISYO_CD.Format = "9"
        Me.cob_MEISYO_CD.HighlightText = True
        Me.cob_MEISYO_CD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_MEISYO_CD.InputCheck = True
        Me.cob_MEISYO_CD.ListHeaderPane.Height = 22
        Me.cob_MEISYO_CD.Location = New System.Drawing.Point(287, 305)
        Me.cob_MEISYO_CD.MaxLength = 2
        Me.cob_MEISYO_CD.Name = "cob_MEISYO_CD"
        Me.cob_MEISYO_CD.Size = New System.Drawing.Size(36, 22)
        Me.cob_MEISYO_CD.Spin.AllowSpin = False
        Me.cob_MEISYO_CD.TabIndex = 1
        Me.cob_MEISYO_CD.Tag = "都道府県"
        Me.cob_MEISYO_CD.Text = "00"
        '
        'txt_MEISYO
        '
        Me.txt_MEISYO.DropDown.AllowDrop = False
        Me.txt_MEISYO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_MEISYO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_MEISYO.Format = "Ｚ"
        Me.txt_MEISYO.HighlightText = True
        Me.txt_MEISYO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txt_MEISYO.InputCheck = True
        Me.txt_MEISYO.Location = New System.Drawing.Point(287, 359)
        Me.txt_MEISYO.MaxLength = 50
        Me.txt_MEISYO.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_MEISYO.Name = "txt_MEISYO"
        Me.txt_MEISYO.Size = New System.Drawing.Size(513, 20)
        Me.txt_MEISYO.TabIndex = 2
        Me.txt_MEISYO.Text = "ＺＺＺＺＺ"
        '
        'txtRYAKUSYO
        '
        Me.txtRYAKUSYO.DropDown.AllowDrop = False
        Me.txtRYAKUSYO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txtRYAKUSYO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txtRYAKUSYO.Format = "Ｚ"
        Me.txtRYAKUSYO.HighlightText = True
        Me.txtRYAKUSYO.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtRYAKUSYO.InputCheck = True
        Me.txtRYAKUSYO.Location = New System.Drawing.Point(287, 412)
        Me.txtRYAKUSYO.MaxLength = 10
        Me.txtRYAKUSYO.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txtRYAKUSYO.Name = "txtRYAKUSYO"
        Me.txtRYAKUSYO.Size = New System.Drawing.Size(513, 20)
        Me.txtRYAKUSYO.TabIndex = 3
        Me.txtRYAKUSYO.Text = "ＺＺＺＺＺ"
        '
        'frmGJ8011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.txtRYAKUSYO)
        Me.Controls.Add(Me.txt_MEISYO)
        Me.Controls.Add(Me.cob_MEISYO_CD)
        Me.Controls.Add(Me.lbl_SYURUI_KBN_NM)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.label52)
        Me.Name = "frmGJ8011"
        Me.Text = "(GJ8011)コードマスタメンテナンス"
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.label52, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.lbl_SYURUI_KBN_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_MEISYO_CD, 0)
        Me.Controls.SetChildIndex(Me.txt_MEISYO, 0)
        Me.Controls.SetChildIndex(Me.txtRYAKUSYO, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.cob_MEISYO_CD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_MEISYO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRYAKUSYO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents label52 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_SYURUI_KBN_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents cmdTouroku As JBD.Gjs.Win.JButton
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents cob_MEISYO_CD As JBD.Gjs.Win.GcComboBox
    Friend WithEvents txt_MEISYO As JBD.Gjs.Win.GcTextBox
    Friend WithEvents txtRYAKUSYO As JBD.Gjs.Win.GcTextBox

End Class
