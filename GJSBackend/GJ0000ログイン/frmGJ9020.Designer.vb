'Imports Oracle.DataAccess.Client
'Imports Oracle.DataAccess.Types
Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ9020
    Inherits JBD.Gjs.Win.FormL

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub
    Public Sub New(ByVal pgjsINI_Array As pgjsINI)
        MyBase.New(pgjsINI_Array)
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
        Dim DateEraYearField2 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraField2 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField4 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateLiteralField5 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField2 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField6 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField2 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.date_FURIKOMIYMD = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton6 = New GrapeCity.Win.Editors.DropDownButton()
        Me.txt_Path = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.cmdExec = New JBD.Gjs.Win.Button(Me.components)
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label31 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdReference = New JBD.Gjs.Win.Button(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.txt_TAISYO_KI = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.date_FURIKOMIYMD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Path, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TAISYO_KI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdExec)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdExec, 0)
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
        Me.cmdEnd.TabIndex = 7
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'date_FURIKOMIYMD
        '
        Me.date_FURIKOMIYMD.DefaultActiveField = DateEraYearField2
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.date_FURIKOMIYMD.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateLiteralField4, DateEraYearField2, DateLiteralField5, DateMonthField2, DateLiteralField6, DateDayField2})
        Me.date_FURIKOMIYMD.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.date_FURIKOMIYMD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.date_FURIKOMIYMD.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.date_FURIKOMIYMD.Location = New System.Drawing.Point(266, 256)
        Me.date_FURIKOMIYMD.Name = "date_FURIKOMIYMD"
        Me.GcShortcut1.SetShortcuts(Me.date_FURIKOMIYMD, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.date_FURIKOMIYMD, Object), CType(Me.date_FURIKOMIYMD, Object), CType(Me.date_FURIKOMIYMD, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.date_FURIKOMIYMD.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton6})
        Me.date_FURIKOMIYMD.Size = New System.Drawing.Size(123, 22)
        Me.date_FURIKOMIYMD.TabIndex = 5
        Me.date_FURIKOMIYMD.Value = New Date(2010, 8, 28, 0, 0, 0, 0)
        '
        'DropDownButton6
        '
        Me.DropDownButton6.Name = "DropDownButton6"
        '
        'txt_Path
        '
        Me.txt_Path.DropDown.AllowDrop = False
        Me.txt_Path.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_Path.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_Path.HighlightText = True
        Me.txt_Path.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txt_Path.Location = New System.Drawing.Point(266, 99)
        Me.txt_Path.MaxLength = 256
        Me.txt_Path.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_Path.Name = "txt_Path"
        Me.GcShortcut1.SetShortcuts(Me.txt_Path, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_Path, Object)}, New String() {"ShortcutClear"}))
        Me.txt_Path.Size = New System.Drawing.Size(473, 20)
        Me.txt_Path.TabIndex = 1
        Me.txt_Path.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        '
        'cmdExec
        '
        Me.cmdExec.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdExec.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdExec.Location = New System.Drawing.Point(30, 6)
        Me.cmdExec.Name = "cmdExec"
        Me.cmdExec.Size = New System.Drawing.Size(92, 44)
        Me.cmdExec.TabIndex = 6
        Me.cmdExec.Text = "実行"
        Me.cmdExec.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(108, 258)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(97, 15)
        Me.Label22.TabIndex = 15
        Me.Label22.Text = "■振込予定日"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label31.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(755, 720)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(251, 15)
        Me.Label31.TabIndex = 869
        Me.Label31.Text = "（請求金額と入金金額は一致している）"
        '
        'cmdReference
        '
        Me.cmdReference.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdReference.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdReference.Location = New System.Drawing.Point(760, 92)
        Me.cmdReference.Name = "cmdReference"
        Me.cmdReference.Size = New System.Drawing.Size(94, 35)
        Me.cmdReference.TabIndex = 2
        Me.cmdReference.Text = "参照"
        Me.cmdReference.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(108, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 15)
        Me.Label4.TabIndex = 1003
        Me.Label4.Text = "■出力ファイル名"
        '
        'txt_TAISYO_KI
        '
        Me.txt_TAISYO_KI.DropDown.AllowDrop = False
        Me.txt_TAISYO_KI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_TAISYO_KI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.txt_TAISYO_KI.Format = "9"
        Me.txt_TAISYO_KI.HighlightText = True
        Me.txt_TAISYO_KI.Location = New System.Drawing.Point(266, 174)
        Me.txt_TAISYO_KI.MaxLength = 2
        Me.txt_TAISYO_KI.Name = "txt_TAISYO_KI"
        Me.txt_TAISYO_KI.Size = New System.Drawing.Size(30, 22)
        Me.txt_TAISYO_KI.TabIndex = 3
        Me.txt_TAISYO_KI.Text = "00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(108, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 1000
        Me.Label2.Text = "■対象期"
        '
        'frmGJ9020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.cmdReference)
        Me.Controls.Add(Me.txt_Path)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_TAISYO_KI)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.date_FURIKOMIYMD)
        Me.Controls.Add(Me.Label22)
        Me.Name = "frmGJ9020"
        Me.Text = "(mX)"
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.date_FURIKOMIYMD, 0)
        Me.Controls.SetChildIndex(Me.Label31, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txt_TAISYO_KI, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txt_Path, 0)
        Me.Controls.SetChildIndex(Me.cmdReference, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.date_FURIKOMIYMD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Path, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TAISYO_KI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents cmdExec As JBD.Gjs.Win.Button
    Friend WithEvents date_FURIKOMIYMD As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton6 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents Label31 As JBD.Gjs.Win.Label
    Friend WithEvents cmdReference As JBD.Gjs.Win.Button
    Friend WithEvents txt_Path As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents txt_TAISYO_KI As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
End Class
