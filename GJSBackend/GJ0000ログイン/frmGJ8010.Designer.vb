Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ8010
    Inherits JBD.Gjs.Win.FormL
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.MEISYO_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MEISYO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RYAKUSYO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYURUI_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYURUI_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdIns = New JBD.Gjs.Win.JButton(Me.components)
        Me.cob_SYURUI_KBN = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.cob_SYURUI_KBN_NM = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.DropDownButton8 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label28 = New JBD.Gjs.Win.Label(Me.components)
        Me.CmdUpd = New JBD.Gjs.Win.JButton(Me.components)
        Me.CmdDel = New JBD.Gjs.Win.JButton(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_SYURUI_KBN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cob_SYURUI_KBN_NM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.CmdDel)
        Me.pnlButton.Controls.Add(Me.CmdUpd)
        Me.pnlButton.Controls.Add(Me.cmdIns)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdIns, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.CmdUpd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.CmdDel, 0)
        '
        'cmdEnd
        '
        Me.cmdEnd.TabIndex = 99
        '
        'dgv_Search
        '
        Me.dgv_Search.AllowUserToAddRows = False
        Me.dgv_Search.AllowUserToDeleteRows = False
        Me.dgv_Search.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Search.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MEISYO_CD, Me.MEISYO, Me.RYAKUSYO, Me.SYURUI_KBN, Me.SYURUI_KBN_NM})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Search.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(188, 151)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Search.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(619, 438)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 3
        '
        'MEISYO_CD
        '
        Me.MEISYO_CD.DataPropertyName = "MEISYO_CD"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEISYO_CD.DefaultCellStyle = DataGridViewCellStyle2
        Me.MEISYO_CD.Frozen = True
        Me.MEISYO_CD.HeaderText = "名称コード"
        Me.MEISYO_CD.Name = "MEISYO_CD"
        Me.MEISYO_CD.ReadOnly = True
        Me.MEISYO_CD.Width = 75
        '
        'MEISYO
        '
        Me.MEISYO.DataPropertyName = "MEISYO"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MEISYO.DefaultCellStyle = DataGridViewCellStyle3
        Me.MEISYO.FillWeight = 110.0!
        Me.MEISYO.Frozen = True
        Me.MEISYO.HeaderText = "名称"
        Me.MEISYO.Name = "MEISYO"
        Me.MEISYO.ReadOnly = True
        Me.MEISYO.Width = 420
        '
        'RYAKUSYO
        '
        Me.RYAKUSYO.DataPropertyName = "RYAKUSYO"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RYAKUSYO.DefaultCellStyle = DataGridViewCellStyle4
        Me.RYAKUSYO.FillWeight = 110.0!
        Me.RYAKUSYO.Frozen = True
        Me.RYAKUSYO.HeaderText = "略称"
        Me.RYAKUSYO.Name = "RYAKUSYO"
        Me.RYAKUSYO.ReadOnly = True
        Me.RYAKUSYO.Width = 110
        '
        'SYURUI_KBN
        '
        Me.SYURUI_KBN.DataPropertyName = "SYURUI_KBN"
        Me.SYURUI_KBN.Frozen = True
        Me.SYURUI_KBN.HeaderText = "SYURUI_KBN"
        Me.SYURUI_KBN.Name = "SYURUI_KBN"
        Me.SYURUI_KBN.ReadOnly = True
        Me.SYURUI_KBN.Visible = False
        '
        'SYURUI_KBN_NM
        '
        Me.SYURUI_KBN_NM.DataPropertyName = "SYURUI_KBN_NM"
        Me.SYURUI_KBN_NM.HeaderText = "SYURUI_KBN_NM"
        Me.SYURUI_KBN_NM.Name = "SYURUI_KBN_NM"
        Me.SYURUI_KBN_NM.ReadOnly = True
        Me.SYURUI_KBN_NM.Visible = False
        '
        'cmdIns
        '
        Me.cmdIns.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdIns.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdIns.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIns.Location = New System.Drawing.Point(17, 3)
        Me.cmdIns.Name = "cmdIns"
        Me.cmdIns.Size = New System.Drawing.Size(92, 44)
        Me.cmdIns.TabIndex = 10
        Me.cmdIns.Text = "新規登録"
        Me.cmdIns.UseVisualStyleBackColor = True
        '
        'cob_SYURUI_KBN
        '
        Me.cob_SYURUI_KBN.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_SYURUI_KBN.DropDown.AllowDrop = False
        Me.cob_SYURUI_KBN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_SYURUI_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_SYURUI_KBN.Format = "99"
        Me.cob_SYURUI_KBN.HighlightText = True
        Me.cob_SYURUI_KBN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_SYURUI_KBN.ListHeaderPane.Height = 22
        Me.cob_SYURUI_KBN.Location = New System.Drawing.Point(274, 104)
        Me.cob_SYURUI_KBN.MaxLength = 2
        Me.cob_SYURUI_KBN.Name = "cob_SYURUI_KBN"
        Me.cob_SYURUI_KBN.Size = New System.Drawing.Size(27, 22)
        Me.cob_SYURUI_KBN.Spin.AllowSpin = False
        Me.cob_SYURUI_KBN.TabIndex = 1
        Me.cob_SYURUI_KBN.Tag = "種類区分"
        Me.cob_SYURUI_KBN.Text = "0"
        Me.cob_SYURUI_KBN.Visible = False
        '
        'cob_SYURUI_KBN_NM
        '
        Me.cob_SYURUI_KBN_NM.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cob_SYURUI_KBN_NM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cob_SYURUI_KBN_NM.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_SYURUI_KBN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_SYURUI_KBN_NM.InputCheck = True
        Me.cob_SYURUI_KBN_NM.ListHeaderPane.Height = 22
        Me.cob_SYURUI_KBN_NM.ListHeaderPane.Visible = False
        Me.cob_SYURUI_KBN_NM.Location = New System.Drawing.Point(307, 104)
        Me.cob_SYURUI_KBN_NM.Name = "cob_SYURUI_KBN_NM"
        Me.cob_SYURUI_KBN_NM.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton8})
        Me.cob_SYURUI_KBN_NM.Size = New System.Drawing.Size(500, 22)
        Me.cob_SYURUI_KBN_NM.TabIndex = 2
        Me.cob_SYURUI_KBN_NM.TabStop = False
        Me.cob_SYURUI_KBN_NM.Tag = "種類区分名"
        '
        'DropDownButton8
        '
        Me.DropDownButton8.Name = "DropDownButton8"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(189, 107)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(82, 15)
        Me.Label28.TabIndex = 953
        Me.Label28.Text = "■種類区分"
        '
        'CmdUpd
        '
        Me.CmdUpd.BackColor = System.Drawing.Color.CornflowerBlue
        Me.CmdUpd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdUpd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmdUpd.Location = New System.Drawing.Point(115, 3)
        Me.CmdUpd.Name = "CmdUpd"
        Me.CmdUpd.Size = New System.Drawing.Size(92, 44)
        Me.CmdUpd.TabIndex = 11
        Me.CmdUpd.Text = "変更(表示)"
        Me.CmdUpd.UseVisualStyleBackColor = True
        '
        'CmdDel
        '
        Me.CmdDel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.CmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CmdDel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmdDel.Location = New System.Drawing.Point(213, 3)
        Me.CmdDel.Name = "CmdDel"
        Me.CmdDel.Size = New System.Drawing.Size(92, 44)
        Me.CmdDel.TabIndex = 12
        Me.CmdDel.Text = "削除"
        Me.CmdDel.UseVisualStyleBackColor = True
        '
        'frmGJ8010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.cob_SYURUI_KBN)
        Me.Controls.Add(Me.cob_SYURUI_KBN_NM)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.dgv_Search)
        Me.Name = "frmGJ8010"
        Me.Text = "(GJ8010)コード一覧"
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.cob_SYURUI_KBN_NM, 0)
        Me.Controls.SetChildIndex(Me.cob_SYURUI_KBN, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_SYURUI_KBN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cob_SYURUI_KBN_NM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_Search As JBD.Gjs.Win.DataGridView
    Friend WithEvents cmdIns As JBD.Gjs.Win.JButton
    Friend WithEvents cob_SYURUI_KBN As JBD.Gjs.Win.GcComboBox
    Friend WithEvents cob_SYURUI_KBN_NM As JBD.Gjs.Win.GcComboBox
    Friend WithEvents DropDownButton8 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label28 As JBD.Gjs.Win.Label
    Friend WithEvents CmdDel As JBD.Gjs.Win.JButton
    Friend WithEvents CmdUpd As JBD.Gjs.Win.JButton
    Friend WithEvents MEISYO_CD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MEISYO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RYAKUSYO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SYURUI_KBN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SYURUI_KBN_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut

End Class
