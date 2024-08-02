Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ2010
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.TAISYO_DATE_FROM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TAISYO_DATE_TO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TAISYO_DATE_FROM_W = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TAISYO_DATE_TO_W = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdIns = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdUpd = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdDel = New JBD.Gjs.Win.JButton(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdDel)
        Me.pnlButton.Controls.Add(Me.cmdUpd)
        Me.pnlButton.Controls.Add(Me.cmdIns)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdIns, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdUpd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdDel, 0)
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
        Me.cmdEnd.TabIndex = 4
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'dgv_Search
        '
        Me.dgv_Search.AllowUserToAddRows = False
        Me.dgv_Search.AllowUserToDeleteRows = False
        Me.dgv_Search.AllowUserToResizeRows = False
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TAISYO_DATE_FROM, Me.TAISYO_DATE_TO, Me.TAISYO_DATE_FROM_W, Me.TAISYO_DATE_TO_W})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Search.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(29, 94)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(279, 508)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 0
        '
        'TAISYO_DATE_FROM
        '
        Me.TAISYO_DATE_FROM.DataPropertyName = "TAISYO_DATE_FROM"
        Me.TAISYO_DATE_FROM.Frozen = True
        Me.TAISYO_DATE_FROM.HeaderText = "TAISYO_DATE_FROM"
        Me.TAISYO_DATE_FROM.Name = "TAISYO_DATE_FROM"
        Me.TAISYO_DATE_FROM.ReadOnly = True
        Me.TAISYO_DATE_FROM.Visible = False
        '
        'TAISYO_DATE_TO
        '
        Me.TAISYO_DATE_TO.DataPropertyName = "TAISYO_DATE_TO"
        Me.TAISYO_DATE_TO.Frozen = True
        Me.TAISYO_DATE_TO.HeaderText = "TAISYO_DATE_TO"
        Me.TAISYO_DATE_TO.Name = "TAISYO_DATE_TO"
        Me.TAISYO_DATE_TO.ReadOnly = True
        Me.TAISYO_DATE_TO.Visible = False
        '
        'TAISYO_DATE_FROM_W
        '
        Me.TAISYO_DATE_FROM_W.DataPropertyName = "TAISYO_DATE_FROM_W"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TAISYO_DATE_FROM_W.DefaultCellStyle = DataGridViewCellStyle1
        Me.TAISYO_DATE_FROM_W.Frozen = True
        Me.TAISYO_DATE_FROM_W.HeaderText = "年月日（自）"
        Me.TAISYO_DATE_FROM_W.Name = "TAISYO_DATE_FROM_W"
        Me.TAISYO_DATE_FROM_W.ReadOnly = True
        Me.TAISYO_DATE_FROM_W.Width = 138
        '
        'TAISYO_DATE_TO_W
        '
        Me.TAISYO_DATE_TO_W.DataPropertyName = "TAISYO_DATE_TO_W"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TAISYO_DATE_TO_W.DefaultCellStyle = DataGridViewCellStyle2
        Me.TAISYO_DATE_TO_W.Frozen = True
        Me.TAISYO_DATE_TO_W.HeaderText = "年月日（至）"
        Me.TAISYO_DATE_TO_W.Name = "TAISYO_DATE_TO_W"
        Me.TAISYO_DATE_TO_W.ReadOnly = True
        Me.TAISYO_DATE_TO_W.Width = 138
        '
        'cmdIns
        '
        Me.cmdIns.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdIns.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdIns.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdIns.Location = New System.Drawing.Point(12, 6)
        Me.cmdIns.Name = "cmdIns"
        Me.cmdIns.Size = New System.Drawing.Size(92, 44)
        Me.cmdIns.TabIndex = 1
        Me.cmdIns.Text = "新規登録"
        Me.cmdIns.UseVisualStyleBackColor = True
        '
        'cmdUpd
        '
        Me.cmdUpd.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdUpd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdUpd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdUpd.Location = New System.Drawing.Point(119, 6)
        Me.cmdUpd.Name = "cmdUpd"
        Me.cmdUpd.Size = New System.Drawing.Size(92, 44)
        Me.cmdUpd.TabIndex = 2
        Me.cmdUpd.Text = "変更(表示)"
        Me.cmdUpd.UseVisualStyleBackColor = True
        '
        'cmdDel
        '
        Me.cmdDel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDel.Location = New System.Drawing.Point(226, 6)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(92, 44)
        Me.cmdDel.TabIndex = 3
        Me.cmdDel.Text = "削除"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'frmGJ2010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.dgv_Search)
        Me.Name = "frmGJ2010"
        Me.Text = "(GJ2010)契約者積立金・互助単価マスタ一覧"
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents dgv_Search As JBD.Gjs.Win.DataGridView
    Friend WithEvents cmdIns As JBD.Gjs.Win.JButton
    Friend WithEvents cmdUpd As JBD.Gjs.Win.JButton
    Friend WithEvents cmdDel As JBD.Gjs.Win.JButton
    Friend WithEvents TAISYO_DATE_FROM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TAISYO_DATE_TO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TAISYO_DATE_FROM_W As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TAISYO_DATE_TO_W As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
