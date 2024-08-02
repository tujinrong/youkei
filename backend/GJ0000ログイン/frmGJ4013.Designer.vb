Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ4013
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
        Dim NumberSignDisplayField1 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField1 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberSignDisplayField2 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField2 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberSignDisplayField3 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField3 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberSignDisplayField4 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField4 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberSignDisplayField5 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField5 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberSignDisplayField6 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField6 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberSignDisplayField7 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField7 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess1 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange1 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim DateEraField1 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField1 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField1 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField3 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField1 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim NumberIntegerPartDisplayField8 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField9 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField10 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberSignDisplayField8 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField11 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess2 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange2 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim ValueProcess3 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange3 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim ValueProcess4 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange4 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField9 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField12 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess5 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange5 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberIntegerPartDisplayField13 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess6 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange6 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberIntegerPartDisplayField14 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess7 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange7 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberIntegerPartDisplayField15 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess8 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange8 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberIntegerPartDisplayField16 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess9 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange9 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberIntegerPartDisplayField17 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess10 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange10 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberIntegerPartDisplayField18 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess11 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange11 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim DateEraField2 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField4 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField2 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField5 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField2 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField6 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField2 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim NumberSignDisplayField10 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField19 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberSignDisplayField11 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField20 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberSignDisplayField12 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField21 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberSignDisplayField13 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField22 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberSignDisplayField14 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField23 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess12 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange12 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberIntegerPartDisplayField24 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField25 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField26 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField27 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess13 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange13 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.num_KOFU_HASU01 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_HASU02 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_HASU04 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_HASU03 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_HASU06 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_HASU05 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_HASU00 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.txt_HASSEI_KAISU = New JBD.Gjs.Win.GcTextBox(Me.components)
        Me.num_KOFU_KIN01 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_KIN02 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_KIN03 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_KIN04 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_KIN05 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_KIN06 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_KIN00 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_HASU_NYU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.dateKOFU_KAKUTEI_Ymd = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.num_KOFU_HASU_DISP = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_TANKA = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_MARU1 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_MARU2 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_SYOKYAKU_KEIHI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KUNI_KOFUKIN = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOME1 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_MARU3_DISP1 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOME3_CALC = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_MARU3_DISP2 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOME3_DISP2 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_MARU5 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_MARU6 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.dateSINSEI_DATE = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton7 = New GrapeCity.Win.Editors.DropDownButton()
        Me.num_KOFU_KIN11 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_KIN10 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_KIN09 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_KIN08 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_KIN07 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_HASU11 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_HASU10 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_HASU09 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_HASU08 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_HASU07 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_GENGAKU_RITU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_MARU4 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_RITU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOME2 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_MARU3_CALC = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOME3_DISP1 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.DropDownButton14 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton15 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton16 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton17 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton18 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton19 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.dgv_Search = New JBD.Gjs.Win.DataGridView(Me.components)
        Me.MEISAI_NO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOJO_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TORI_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEISAN_KAISU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYORI_JOKYO_KBN_NM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KOFU_HASU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GENGAKU_RITU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KOFU_KIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOJO_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TORI_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SYORI_JOKYO_KBN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEI_TUMITATE_KIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KUNI_KOFU_KIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_POST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDR_4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKUSYA_CD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HASSEI_KAISU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KEIYAKU_HASU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KOFU_RITU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdDel = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label23 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label26 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdCansel = New JBD.Gjs.Win.JButton(Me.components)
        Me.lbl_KEIYAKUSYA_CD = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKUSYA_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KI = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_POST = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_1 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_2 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_4 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_3 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label20 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdSearch = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_NOJO_CD = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_NOJO_NAME = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_TORI_KBN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_TORI_KBN_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKU_HASU = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label29 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label30 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label31 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label32 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label33 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label34 = New JBD.Gjs.Win.Label(Me.components)
        Me.rbtnSYORI_JOKYO_KBN_3 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtnSYORI_JOKYO_KBN_2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtnSYORI_JOKYO_KBN_1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label103 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label87 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label35 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label36 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label95 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label37 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label97 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label27 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label28 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label96 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label38 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label39 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label42 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label43 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label92 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label44 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label99 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label45 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label46 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label47 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label48 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label49 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_SYORI_JOKYO_KBN_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label50 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label40 = New JBD.Gjs.Win.Label(Me.components)
        Me.lblCOUNT = New JBD.Gjs.Win.Label(Me.components)
        Me.Label51 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label52 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label53 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label54 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label55 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label56 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label116 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label113 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label112 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label110 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label108 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label107 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label58 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label89 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label59 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label60 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label61 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label62 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label63 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label64 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label65 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label66 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label41 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label57 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label67 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.num_KOFU_HASU01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU00, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_HASSEI_KAISU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN00, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU_NYU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateKOFU_KAKUTEI_Ymd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU_DISP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_TANKA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_MARU1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_MARU2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_SYOKYAKU_KEIHI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KUNI_KOFUKIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOME1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_MARU3_DISP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOME3_CALC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_MARU3_DISP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOME3_DISP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_MARU5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_MARU6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateSINSEI_DATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_GENGAKU_RITU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_MARU4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_RITU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOME2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_MARU3_CALC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOME3_DISP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.Controls.Add(Me.cmdCansel)
        Me.pnlButton.TabIndex = 101
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCansel, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
        '
        'lblLOGONUSER
        '
        Me.lblLOGONUSER.Text = "さん"
        '
        'lblSysdate
        '
        Me.lblSysdate.Text = "2010年9月6日（月）"
        '
        'cmdEnd
        '
        Me.cmdEnd.Location = New System.Drawing.Point(967, 6)
        Me.cmdEnd.TabIndex = 3
        '
        'num_KOFU_HASU01
        '
        Me.num_KOFU_HASU01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU01.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU01.DropDown.AllowDrop = False
        Me.num_KOFU_HASU01.Enabled = False
        Me.num_KOFU_HASU01.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU01.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU01.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_HASU01.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU01.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU01.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU01.HighlightText = True
        Me.num_KOFU_HASU01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU01.Location = New System.Drawing.Point(210, 310)
        Me.num_KOFU_HASU01.Name = "num_KOFU_HASU01"
        Me.num_KOFU_HASU01.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU01.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU01, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU01, Object), CType(Me.num_KOFU_HASU01, Object), CType(Me.num_KOFU_HASU01, Object), CType(Me.num_KOFU_HASU01, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU01.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_HASU01.Spin.Increment = 0
        Me.num_KOFU_HASU01.TabIndex = 1086
        Me.num_KOFU_HASU01.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_KOFU_HASU01.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_HASU02
        '
        Me.num_KOFU_HASU02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU02.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU02.DropDown.AllowDrop = False
        Me.num_KOFU_HASU02.Enabled = False
        Me.num_KOFU_HASU02.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU02.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU02.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_HASU02.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU02.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU02.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU02.HighlightText = True
        Me.num_KOFU_HASU02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU02.Location = New System.Drawing.Point(331, 310)
        Me.num_KOFU_HASU02.Name = "num_KOFU_HASU02"
        Me.num_KOFU_HASU02.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU02.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU02, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU02, Object), CType(Me.num_KOFU_HASU02, Object), CType(Me.num_KOFU_HASU02, Object), CType(Me.num_KOFU_HASU02, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU02.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_HASU02.Spin.Increment = 0
        Me.num_KOFU_HASU02.TabIndex = 1088
        Me.num_KOFU_HASU02.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_KOFU_HASU02.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_HASU04
        '
        Me.num_KOFU_HASU04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU04.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU04.DropDown.AllowDrop = False
        Me.num_KOFU_HASU04.Enabled = False
        Me.num_KOFU_HASU04.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU04.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU04.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_HASU04.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU04.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU04.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU04.HighlightText = True
        Me.num_KOFU_HASU04.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU04.Location = New System.Drawing.Point(574, 310)
        Me.num_KOFU_HASU04.Name = "num_KOFU_HASU04"
        Me.num_KOFU_HASU04.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU04.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU04, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU04, Object), CType(Me.num_KOFU_HASU04, Object), CType(Me.num_KOFU_HASU04, Object), CType(Me.num_KOFU_HASU04, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU04.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_HASU04.Spin.Increment = 0
        Me.num_KOFU_HASU04.TabIndex = 1092
        Me.num_KOFU_HASU04.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_KOFU_HASU04.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_HASU03
        '
        Me.num_KOFU_HASU03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU03.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU03.DropDown.AllowDrop = False
        Me.num_KOFU_HASU03.Enabled = False
        Me.num_KOFU_HASU03.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU03.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU03.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_HASU03.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU03.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU03.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU03.HighlightText = True
        Me.num_KOFU_HASU03.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU03.Location = New System.Drawing.Point(453, 310)
        Me.num_KOFU_HASU03.Name = "num_KOFU_HASU03"
        Me.num_KOFU_HASU03.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU03.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU03, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU03, Object), CType(Me.num_KOFU_HASU03, Object), CType(Me.num_KOFU_HASU03, Object), CType(Me.num_KOFU_HASU03, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU03.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_HASU03.Spin.Increment = 0
        Me.num_KOFU_HASU03.TabIndex = 1090
        Me.num_KOFU_HASU03.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_KOFU_HASU03.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_HASU06
        '
        Me.num_KOFU_HASU06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU06.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU06.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU06.DropDown.AllowDrop = False
        Me.num_KOFU_HASU06.Enabled = False
        Me.num_KOFU_HASU06.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU06.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU06.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_HASU06.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU06.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU06.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU06.HighlightText = True
        Me.num_KOFU_HASU06.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU06.Location = New System.Drawing.Point(29, 376)
        Me.num_KOFU_HASU06.Name = "num_KOFU_HASU06"
        Me.num_KOFU_HASU06.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU06.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU06, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU06, Object), CType(Me.num_KOFU_HASU06, Object), CType(Me.num_KOFU_HASU06, Object), CType(Me.num_KOFU_HASU06, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU06.Size = New System.Drawing.Size(182, 22)
        Me.num_KOFU_HASU06.Spin.Increment = 0
        Me.num_KOFU_HASU06.TabIndex = 1096
        Me.num_KOFU_HASU06.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_KOFU_HASU06.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_HASU05
        '
        Me.num_KOFU_HASU05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU05.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU05.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU05.DropDown.AllowDrop = False
        Me.num_KOFU_HASU05.Enabled = False
        Me.num_KOFU_HASU05.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU05.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU05.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_HASU05.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU05.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU05.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU05.HighlightText = True
        Me.num_KOFU_HASU05.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU05.Location = New System.Drawing.Point(694, 310)
        Me.num_KOFU_HASU05.Name = "num_KOFU_HASU05"
        Me.num_KOFU_HASU05.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU05.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU05, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU05, Object), CType(Me.num_KOFU_HASU05, Object), CType(Me.num_KOFU_HASU05, Object), CType(Me.num_KOFU_HASU05, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU05.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_HASU05.Spin.Increment = 0
        Me.num_KOFU_HASU05.TabIndex = 1094
        Me.num_KOFU_HASU05.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_KOFU_HASU05.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_HASU00
        '
        Me.num_KOFU_HASU00.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU00.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU00.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU00.DropDown.AllowDrop = False
        Me.num_KOFU_HASU00.Enabled = False
        Me.num_KOFU_HASU00.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU00.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU00.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_HASU00.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU00.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU00.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU00.HighlightText = True
        Me.num_KOFU_HASU00.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU00.Location = New System.Drawing.Point(816, 376)
        Me.num_KOFU_HASU00.Name = "num_KOFU_HASU00"
        Me.num_KOFU_HASU00.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU00.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU00, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU00, Object), CType(Me.num_KOFU_HASU00, Object), CType(Me.num_KOFU_HASU00, Object), CType(Me.num_KOFU_HASU00, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU00.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_HASU00.Spin.Increment = 0
        Me.num_KOFU_HASU00.TabIndex = 1098
        Me.num_KOFU_HASU00.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_KOFU_HASU00.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'txt_HASSEI_KAISU
        '
        Me.txt_HASSEI_KAISU.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.txt_HASSEI_KAISU.DropDown.AllowDrop = False
        Me.txt_HASSEI_KAISU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.txt_HASSEI_KAISU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt_HASSEI_KAISU.Format = "9"
        Me.txt_HASSEI_KAISU.HighlightText = True
        Me.txt_HASSEI_KAISU.InputCheck = True
        Me.txt_HASSEI_KAISU.Location = New System.Drawing.Point(107, 75)
        Me.txt_HASSEI_KAISU.MaxLength = 2
        Me.txt_HASSEI_KAISU.MaxLengthUnit = GrapeCity.Win.Editors.LengthUnit.[Byte]
        Me.txt_HASSEI_KAISU.Name = "txt_HASSEI_KAISU"
        Me.GcShortcut1.SetShortcuts(Me.txt_HASSEI_KAISU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2}, New Object() {CType(Me.txt_HASSEI_KAISU, Object)}, New String() {"ShortcutClear"}))
        Me.txt_HASSEI_KAISU.Size = New System.Drawing.Size(36, 20)
        Me.txt_HASSEI_KAISU.TabIndex = 0
        Me.txt_HASSEI_KAISU.Text = "99"
        '
        'num_KOFU_KIN01
        '
        Me.num_KOFU_KIN01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN01.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN01.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField1.GroupSizes = New Integer() {3, 3, 3}
        Me.num_KOFU_KIN01.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField1, NumberIntegerPartDisplayField1})
        Me.num_KOFU_KIN01.DropDown.AllowDrop = False
        Me.num_KOFU_KIN01.Enabled = False
        Me.num_KOFU_KIN01.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN01.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN01.Fields.IntegerPart.MaxDigits = 11
        Me.num_KOFU_KIN01.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN01.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN01.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN01.HighlightText = True
        Me.num_KOFU_KIN01.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN01.Location = New System.Drawing.Point(210, 331)
        Me.num_KOFU_KIN01.Name = "num_KOFU_KIN01"
        Me.num_KOFU_KIN01.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN01.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN01, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN01, Object), CType(Me.num_KOFU_KIN01, Object), CType(Me.num_KOFU_KIN01, Object), CType(Me.num_KOFU_KIN01, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN01.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_KIN01.Spin.Increment = 0
        Me.num_KOFU_KIN01.TabIndex = 1107
        Me.num_KOFU_KIN01.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOFU_KIN01.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_KIN02
        '
        Me.num_KOFU_KIN02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN02.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN02.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField2.GroupSizes = New Integer() {3, 3, 3}
        Me.num_KOFU_KIN02.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField2, NumberIntegerPartDisplayField2})
        Me.num_KOFU_KIN02.DropDown.AllowDrop = False
        Me.num_KOFU_KIN02.Enabled = False
        Me.num_KOFU_KIN02.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN02.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN02.Fields.IntegerPart.MaxDigits = 11
        Me.num_KOFU_KIN02.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN02.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN02.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN02.HighlightText = True
        Me.num_KOFU_KIN02.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN02.Location = New System.Drawing.Point(331, 331)
        Me.num_KOFU_KIN02.Name = "num_KOFU_KIN02"
        Me.num_KOFU_KIN02.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN02.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN02, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN02, Object), CType(Me.num_KOFU_KIN02, Object), CType(Me.num_KOFU_KIN02, Object), CType(Me.num_KOFU_KIN02, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN02.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_KIN02.Spin.Increment = 0
        Me.num_KOFU_KIN02.TabIndex = 1108
        Me.num_KOFU_KIN02.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOFU_KIN02.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_KIN03
        '
        Me.num_KOFU_KIN03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN03.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN03.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField3.GroupSizes = New Integer() {3, 3, 3}
        Me.num_KOFU_KIN03.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField3, NumberIntegerPartDisplayField3})
        Me.num_KOFU_KIN03.DropDown.AllowDrop = False
        Me.num_KOFU_KIN03.Enabled = False
        Me.num_KOFU_KIN03.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN03.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN03.Fields.IntegerPart.MaxDigits = 11
        Me.num_KOFU_KIN03.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN03.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN03.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN03.HighlightText = True
        Me.num_KOFU_KIN03.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN03.Location = New System.Drawing.Point(453, 331)
        Me.num_KOFU_KIN03.Name = "num_KOFU_KIN03"
        Me.num_KOFU_KIN03.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN03.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN03, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN03, Object), CType(Me.num_KOFU_KIN03, Object), CType(Me.num_KOFU_KIN03, Object), CType(Me.num_KOFU_KIN03, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN03.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_KIN03.Spin.Increment = 0
        Me.num_KOFU_KIN03.TabIndex = 1109
        Me.num_KOFU_KIN03.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOFU_KIN03.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_KIN04
        '
        Me.num_KOFU_KIN04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN04.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN04.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField4.GroupSizes = New Integer() {3, 3, 3}
        Me.num_KOFU_KIN04.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField4, NumberIntegerPartDisplayField4})
        Me.num_KOFU_KIN04.DropDown.AllowDrop = False
        Me.num_KOFU_KIN04.Enabled = False
        Me.num_KOFU_KIN04.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN04.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN04.Fields.IntegerPart.MaxDigits = 11
        Me.num_KOFU_KIN04.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN04.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN04.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN04.HighlightText = True
        Me.num_KOFU_KIN04.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN04.Location = New System.Drawing.Point(574, 331)
        Me.num_KOFU_KIN04.Name = "num_KOFU_KIN04"
        Me.num_KOFU_KIN04.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN04.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN04, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN04, Object), CType(Me.num_KOFU_KIN04, Object), CType(Me.num_KOFU_KIN04, Object), CType(Me.num_KOFU_KIN04, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN04.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_KIN04.Spin.Increment = 0
        Me.num_KOFU_KIN04.TabIndex = 1110
        Me.num_KOFU_KIN04.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOFU_KIN04.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_KIN05
        '
        Me.num_KOFU_KIN05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN05.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN05.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField5.GroupSizes = New Integer() {3, 3, 3}
        Me.num_KOFU_KIN05.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField5, NumberIntegerPartDisplayField5})
        Me.num_KOFU_KIN05.DropDown.AllowDrop = False
        Me.num_KOFU_KIN05.Enabled = False
        Me.num_KOFU_KIN05.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN05.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN05.Fields.IntegerPart.MaxDigits = 11
        Me.num_KOFU_KIN05.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN05.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN05.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN05.HighlightText = True
        Me.num_KOFU_KIN05.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN05.Location = New System.Drawing.Point(694, 331)
        Me.num_KOFU_KIN05.Name = "num_KOFU_KIN05"
        Me.num_KOFU_KIN05.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN05.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN05, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN05, Object), CType(Me.num_KOFU_KIN05, Object), CType(Me.num_KOFU_KIN05, Object), CType(Me.num_KOFU_KIN05, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN05.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_KIN05.Spin.Increment = 0
        Me.num_KOFU_KIN05.TabIndex = 1111
        Me.num_KOFU_KIN05.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOFU_KIN05.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_KIN06
        '
        Me.num_KOFU_KIN06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN06.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN06.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField6.GroupSizes = New Integer() {3, 3, 3}
        Me.num_KOFU_KIN06.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField6, NumberIntegerPartDisplayField6})
        Me.num_KOFU_KIN06.DropDown.AllowDrop = False
        Me.num_KOFU_KIN06.Enabled = False
        Me.num_KOFU_KIN06.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN06.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN06.Fields.IntegerPart.MaxDigits = 11
        Me.num_KOFU_KIN06.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN06.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN06.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN06.HighlightText = True
        Me.num_KOFU_KIN06.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN06.Location = New System.Drawing.Point(29, 397)
        Me.num_KOFU_KIN06.Name = "num_KOFU_KIN06"
        Me.num_KOFU_KIN06.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN06.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN06, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN06, Object), CType(Me.num_KOFU_KIN06, Object), CType(Me.num_KOFU_KIN06, Object), CType(Me.num_KOFU_KIN06, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN06.Size = New System.Drawing.Size(182, 22)
        Me.num_KOFU_KIN06.Spin.Increment = 0
        Me.num_KOFU_KIN06.TabIndex = 1112
        Me.num_KOFU_KIN06.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOFU_KIN06.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_KIN00
        '
        Me.num_KOFU_KIN00.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN00.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN00.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField7.GroupSizes = New Integer() {3, 3, 3}
        Me.num_KOFU_KIN00.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField7, NumberIntegerPartDisplayField7})
        Me.num_KOFU_KIN00.DropDown.AllowDrop = False
        Me.num_KOFU_KIN00.Enabled = False
        Me.num_KOFU_KIN00.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN00.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN00.Fields.IntegerPart.MaxDigits = 11
        Me.num_KOFU_KIN00.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN00.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN00.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN00.HighlightText = True
        Me.num_KOFU_KIN00.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN00.Location = New System.Drawing.Point(816, 397)
        Me.num_KOFU_KIN00.Name = "num_KOFU_KIN00"
        Me.num_KOFU_KIN00.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN00.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN00, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN00, Object), CType(Me.num_KOFU_KIN00, Object), CType(Me.num_KOFU_KIN00, Object), CType(Me.num_KOFU_KIN00, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN00.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_KIN00.Spin.Increment = 0
        Me.num_KOFU_KIN00.TabIndex = 1113
        Me.num_KOFU_KIN00.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOFU_KIN00.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_HASU_NYU
        '
        Me.num_KOFU_HASU_NYU.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.num_KOFU_HASU_NYU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU_NYU.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOFU_HASU_NYU.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU_NYU.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU_NYU.DropDown.AllowDrop = False
        Me.num_KOFU_HASU_NYU.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU_NYU.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU_NYU.Fields.IntegerPart.MaxDigits = 7
        Me.num_KOFU_HASU_NYU.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU_NYU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU_NYU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU_NYU.HighlightText = True
        Me.num_KOFU_HASU_NYU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU_NYU.Location = New System.Drawing.Point(407, 520)
        Me.num_KOFU_HASU_NYU.Name = "num_KOFU_HASU_NYU"
        Me.num_KOFU_HASU_NYU.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU_NYU.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU_NYU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU_NYU, Object), CType(Me.num_KOFU_HASU_NYU, Object), CType(Me.num_KOFU_HASU_NYU, Object), CType(Me.num_KOFU_HASU_NYU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU_NYU.Size = New System.Drawing.Size(107, 20)
        Me.num_KOFU_HASU_NYU.Spin.Increment = 0
        Me.num_KOFU_HASU_NYU.TabIndex = 10
        ValueProcess1.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_KOFU_HASU_NYU).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess1})
        InvalidRange1.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        InvalidRange1.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.num_KOFU_HASU_NYU).AddRange(New Object() {InvalidRange1})
        Me.num_KOFU_HASU_NYU.Value = Nothing
        Me.num_KOFU_HASU_NYU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'dateKOFU_KAKUTEI_Ymd
        '
        Me.dateKOFU_KAKUTEI_Ymd.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.dateKOFU_KAKUTEI_Ymd.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.dateKOFU_KAKUTEI_Ymd.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateKOFU_KAKUTEI_Ymd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateKOFU_KAKUTEI_Ymd.Location = New System.Drawing.Point(628, 718)
        Me.dateKOFU_KAKUTEI_Ymd.Name = "dateKOFU_KAKUTEI_Ymd"
        Me.GcShortcut1.SetShortcuts(Me.dateKOFU_KAKUTEI_Ymd, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateKOFU_KAKUTEI_Ymd, Object), CType(Me.dateKOFU_KAKUTEI_Ymd, Object), CType(Me.dateKOFU_KAKUTEI_Ymd, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateKOFU_KAKUTEI_Ymd.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.dateKOFU_KAKUTEI_Ymd.Size = New System.Drawing.Size(124, 20)
        Me.dateKOFU_KAKUTEI_Ymd.Spin.AllowSpin = False
        Me.dateKOFU_KAKUTEI_Ymd.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateKOFU_KAKUTEI_Ymd.TabIndex = 24
        Me.dateKOFU_KAKUTEI_Ymd.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'num_KOFU_HASU_DISP
        '
        Me.num_KOFU_HASU_DISP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOFU_HASU_DISP.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOFU_HASU_DISP.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU_DISP.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField8.GroupSizes = New Integer() {3}
        Me.num_KOFU_HASU_DISP.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField8})
        Me.num_KOFU_HASU_DISP.DropDown.AllowDrop = False
        Me.num_KOFU_HASU_DISP.Enabled = False
        Me.num_KOFU_HASU_DISP.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU_DISP.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU_DISP.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOFU_HASU_DISP.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU_DISP.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU_DISP.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU_DISP.HighlightText = True
        Me.num_KOFU_HASU_DISP.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU_DISP.Location = New System.Drawing.Point(407, 543)
        Me.num_KOFU_HASU_DISP.Name = "num_KOFU_HASU_DISP"
        Me.num_KOFU_HASU_DISP.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU_DISP.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU_DISP, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU_DISP, Object), CType(Me.num_KOFU_HASU_DISP, Object), CType(Me.num_KOFU_HASU_DISP, Object), CType(Me.num_KOFU_HASU_DISP, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU_DISP.Size = New System.Drawing.Size(107, 20)
        Me.num_KOFU_HASU_DISP.Spin.Increment = 0
        Me.num_KOFU_HASU_DISP.TabIndex = 4
        Me.num_KOFU_HASU_DISP.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOFU_HASU_DISP.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_TANKA
        '
        Me.num_KOFU_TANKA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOFU_TANKA.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOFU_TANKA.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_TANKA.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField9.GroupSizes = New Integer() {3}
        Me.num_KOFU_TANKA.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField9})
        Me.num_KOFU_TANKA.DropDown.AllowDrop = False
        Me.num_KOFU_TANKA.Enabled = False
        Me.num_KOFU_TANKA.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_TANKA.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_TANKA.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOFU_TANKA.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_TANKA.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_TANKA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_TANKA.HighlightText = True
        Me.num_KOFU_TANKA.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_TANKA.Location = New System.Drawing.Point(736, 543)
        Me.num_KOFU_TANKA.Name = "num_KOFU_TANKA"
        Me.num_KOFU_TANKA.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_TANKA.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_TANKA, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_TANKA, Object), CType(Me.num_KOFU_TANKA, Object), CType(Me.num_KOFU_TANKA, Object), CType(Me.num_KOFU_TANKA, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_TANKA.Size = New System.Drawing.Size(43, 20)
        Me.num_KOFU_TANKA.Spin.Increment = 0
        Me.num_KOFU_TANKA.TabIndex = 5
        Me.num_KOFU_TANKA.Value = New Decimal(New Integer() {999, 0, 0, 0})
        Me.num_KOFU_TANKA.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_MARU1
        '
        Me.num_MARU1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_MARU1.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_MARU1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_MARU1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField10.GroupSizes = New Integer() {3}
        Me.num_MARU1.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField10})
        Me.num_MARU1.DropDown.AllowDrop = False
        Me.num_MARU1.Enabled = False
        Me.num_MARU1.Fields.DecimalPart.MaxDigits = 0
        Me.num_MARU1.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_MARU1.Fields.IntegerPart.MaxDigits = 12
        Me.num_MARU1.Fields.IntegerPart.MinDigits = 1
        Me.num_MARU1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_MARU1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_MARU1.HighlightText = True
        Me.num_MARU1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_MARU1.Location = New System.Drawing.Point(917, 543)
        Me.num_MARU1.Name = "num_MARU1"
        Me.num_MARU1.NegativeColor = System.Drawing.Color.Black
        Me.num_MARU1.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_MARU1, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_MARU1, Object), CType(Me.num_MARU1, Object), CType(Me.num_MARU1, Object), CType(Me.num_MARU1, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_MARU1.Size = New System.Drawing.Size(107, 20)
        Me.num_MARU1.Spin.Increment = 0
        Me.num_MARU1.TabIndex = 6
        Me.num_MARU1.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_MARU1.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_MARU2
        '
        Me.num_MARU2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_MARU2.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_MARU2.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_MARU2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField11.GroupSizes = New Integer() {3}
        Me.num_MARU2.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField8, NumberIntegerPartDisplayField11})
        Me.num_MARU2.DropDown.AllowDrop = False
        Me.num_MARU2.Enabled = False
        Me.num_MARU2.Fields.DecimalPart.MaxDigits = 0
        Me.num_MARU2.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_MARU2.Fields.IntegerPart.MaxDigits = 12
        Me.num_MARU2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_MARU2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_MARU2.HighlightText = True
        Me.num_MARU2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_MARU2.Location = New System.Drawing.Point(917, 566)
        Me.num_MARU2.Name = "num_MARU2"
        Me.num_MARU2.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_MARU2, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_MARU2, Object), CType(Me.num_MARU2, Object), CType(Me.num_MARU2, Object), CType(Me.num_MARU2, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_MARU2.Size = New System.Drawing.Size(107, 20)
        Me.num_MARU2.Spin.Increment = 0
        Me.num_MARU2.TabIndex = 9
        ValueProcess2.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_MARU2).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess2})
        Me.GcNumberValidator1.GetValidateItems(Me.num_MARU2).AddRange(New Object() {InvalidRange2})
        Me.num_MARU2.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        '
        'num_SYOKYAKU_KEIHI
        '
        Me.num_SYOKYAKU_KEIHI.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.num_SYOKYAKU_KEIHI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_SYOKYAKU_KEIHI.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_SYOKYAKU_KEIHI.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_SYOKYAKU_KEIHI.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_SYOKYAKU_KEIHI.DropDown.AllowDrop = False
        Me.num_SYOKYAKU_KEIHI.Fields.DecimalPart.MaxDigits = 0
        Me.num_SYOKYAKU_KEIHI.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_SYOKYAKU_KEIHI.Fields.IntegerPart.MaxDigits = 7
        Me.num_SYOKYAKU_KEIHI.Fields.IntegerPart.MinDigits = 1
        Me.num_SYOKYAKU_KEIHI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_SYOKYAKU_KEIHI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_SYOKYAKU_KEIHI.HighlightText = True
        Me.num_SYOKYAKU_KEIHI.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_SYOKYAKU_KEIHI.Location = New System.Drawing.Point(348, 566)
        Me.num_SYOKYAKU_KEIHI.Name = "num_SYOKYAKU_KEIHI"
        Me.num_SYOKYAKU_KEIHI.NegativeColor = System.Drawing.Color.Black
        Me.num_SYOKYAKU_KEIHI.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_SYOKYAKU_KEIHI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_SYOKYAKU_KEIHI, Object), CType(Me.num_SYOKYAKU_KEIHI, Object), CType(Me.num_SYOKYAKU_KEIHI, Object), CType(Me.num_SYOKYAKU_KEIHI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_SYOKYAKU_KEIHI.Size = New System.Drawing.Size(107, 20)
        Me.num_SYOKYAKU_KEIHI.Spin.Increment = 0
        Me.num_SYOKYAKU_KEIHI.TabIndex = 11
        ValueProcess3.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_SYOKYAKU_KEIHI).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess3})
        InvalidRange3.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        InvalidRange3.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.num_SYOKYAKU_KEIHI).AddRange(New Object() {InvalidRange3})
        Me.num_SYOKYAKU_KEIHI.Value = Nothing
        Me.num_SYOKYAKU_KEIHI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KUNI_KOFUKIN
        '
        Me.num_KUNI_KOFUKIN.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.num_KUNI_KOFUKIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KUNI_KOFUKIN.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KUNI_KOFUKIN.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KUNI_KOFUKIN.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KUNI_KOFUKIN.DropDown.AllowDrop = False
        Me.num_KUNI_KOFUKIN.Fields.DecimalPart.MaxDigits = 0
        Me.num_KUNI_KOFUKIN.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KUNI_KOFUKIN.Fields.IntegerPart.MaxDigits = 7
        Me.num_KUNI_KOFUKIN.Fields.IntegerPart.MinDigits = 1
        Me.num_KUNI_KOFUKIN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KUNI_KOFUKIN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KUNI_KOFUKIN.HighlightText = True
        Me.num_KUNI_KOFUKIN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KUNI_KOFUKIN.Location = New System.Drawing.Point(736, 566)
        Me.num_KUNI_KOFUKIN.Name = "num_KUNI_KOFUKIN"
        Me.num_KUNI_KOFUKIN.NegativeColor = System.Drawing.Color.Black
        Me.num_KUNI_KOFUKIN.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KUNI_KOFUKIN, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KUNI_KOFUKIN, Object), CType(Me.num_KUNI_KOFUKIN, Object), CType(Me.num_KUNI_KOFUKIN, Object), CType(Me.num_KUNI_KOFUKIN, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KUNI_KOFUKIN.Size = New System.Drawing.Size(107, 20)
        Me.num_KUNI_KOFUKIN.Spin.Increment = 0
        Me.num_KUNI_KOFUKIN.TabIndex = 12
        ValueProcess4.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_KUNI_KOFUKIN).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess4})
        InvalidRange4.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        InvalidRange4.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.num_KUNI_KOFUKIN).AddRange(New Object() {InvalidRange4})
        Me.num_KUNI_KOFUKIN.Value = Nothing
        Me.num_KUNI_KOFUKIN.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOME1
        '
        Me.num_KOME1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOME1.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOME1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOME1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField12.GroupSizes = New Integer() {3}
        Me.num_KOME1.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField9, NumberIntegerPartDisplayField12})
        Me.num_KOME1.DropDown.AllowDrop = False
        Me.num_KOME1.Enabled = False
        Me.num_KOME1.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOME1.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOME1.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOME1.Fields.IntegerPart.MinDigits = 1
        Me.num_KOME1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOME1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOME1.HighlightText = True
        Me.num_KOME1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOME1.Location = New System.Drawing.Point(441, 589)
        Me.num_KOME1.Name = "num_KOME1"
        Me.num_KOME1.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOME1, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOME1, Object), CType(Me.num_KOME1, Object), CType(Me.num_KOME1, Object), CType(Me.num_KOME1, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOME1.Size = New System.Drawing.Size(107, 20)
        Me.num_KOME1.Spin.Increment = 0
        Me.num_KOME1.TabIndex = 10
        ValueProcess5.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_KOME1).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess5})
        Me.GcNumberValidator1.GetValidateItems(Me.num_KOME1).AddRange(New Object() {InvalidRange5})
        Me.num_KOME1.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        '
        'num_MARU3_DISP1
        '
        Me.num_MARU3_DISP1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_MARU3_DISP1.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_MARU3_DISP1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_MARU3_DISP1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField13.GroupSizes = New Integer() {3}
        Me.num_MARU3_DISP1.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField13})
        Me.num_MARU3_DISP1.DropDown.AllowDrop = False
        Me.num_MARU3_DISP1.Enabled = False
        Me.num_MARU3_DISP1.Fields.DecimalPart.MaxDigits = 0
        Me.num_MARU3_DISP1.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_MARU3_DISP1.Fields.IntegerPart.MaxDigits = 12
        Me.num_MARU3_DISP1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_MARU3_DISP1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_MARU3_DISP1.HighlightText = True
        Me.num_MARU3_DISP1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_MARU3_DISP1.Location = New System.Drawing.Point(441, 633)
        Me.num_MARU3_DISP1.Name = "num_MARU3_DISP1"
        Me.num_MARU3_DISP1.NegativeColor = System.Drawing.Color.Black
        Me.num_MARU3_DISP1.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_MARU3_DISP1, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_MARU3_DISP1, Object), CType(Me.num_MARU3_DISP1, Object), CType(Me.num_MARU3_DISP1, Object), CType(Me.num_MARU3_DISP1, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_MARU3_DISP1.Size = New System.Drawing.Size(107, 20)
        Me.num_MARU3_DISP1.Spin.Increment = 0
        Me.num_MARU3_DISP1.TabIndex = 11
        ValueProcess6.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_MARU3_DISP1).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess6})
        Me.GcNumberValidator1.GetValidateItems(Me.num_MARU3_DISP1).AddRange(New Object() {InvalidRange6})
        Me.num_MARU3_DISP1.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        '
        'num_KOME3_CALC
        '
        Me.num_KOME3_CALC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOME3_CALC.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOME3_CALC.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOME3_CALC.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField14.GroupSizes = New Integer() {3}
        Me.num_KOME3_CALC.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField14})
        Me.num_KOME3_CALC.DropDown.AllowDrop = False
        Me.num_KOME3_CALC.Enabled = False
        Me.num_KOME3_CALC.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOME3_CALC.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOME3_CALC.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOME3_CALC.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOME3_CALC.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOME3_CALC.HighlightText = True
        Me.num_KOME3_CALC.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOME3_CALC.Location = New System.Drawing.Point(862, 632)
        Me.num_KOME3_CALC.Name = "num_KOME3_CALC"
        Me.num_KOME3_CALC.NegativeColor = System.Drawing.Color.Black
        Me.num_KOME3_CALC.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOME3_CALC, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOME3_CALC, Object), CType(Me.num_KOME3_CALC, Object), CType(Me.num_KOME3_CALC, Object), CType(Me.num_KOME3_CALC, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOME3_CALC.Size = New System.Drawing.Size(107, 20)
        Me.num_KOME3_CALC.Spin.Increment = 0
        Me.num_KOME3_CALC.TabIndex = 12
        ValueProcess7.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_KOME3_CALC).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess7})
        Me.GcNumberValidator1.GetValidateItems(Me.num_KOME3_CALC).AddRange(New Object() {InvalidRange7})
        Me.num_KOME3_CALC.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        '
        'num_MARU3_DISP2
        '
        Me.num_MARU3_DISP2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_MARU3_DISP2.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_MARU3_DISP2.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_MARU3_DISP2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField15.GroupSizes = New Integer() {3}
        Me.num_MARU3_DISP2.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField15})
        Me.num_MARU3_DISP2.DropDown.AllowDrop = False
        Me.num_MARU3_DISP2.Enabled = False
        Me.num_MARU3_DISP2.Fields.DecimalPart.MaxDigits = 0
        Me.num_MARU3_DISP2.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_MARU3_DISP2.Fields.IntegerPart.MaxDigits = 12
        Me.num_MARU3_DISP2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_MARU3_DISP2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_MARU3_DISP2.HighlightText = True
        Me.num_MARU3_DISP2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_MARU3_DISP2.Location = New System.Drawing.Point(441, 677)
        Me.num_MARU3_DISP2.Name = "num_MARU3_DISP2"
        Me.num_MARU3_DISP2.NegativeColor = System.Drawing.Color.Black
        Me.num_MARU3_DISP2.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_MARU3_DISP2, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_MARU3_DISP2, Object), CType(Me.num_MARU3_DISP2, Object), CType(Me.num_MARU3_DISP2, Object), CType(Me.num_MARU3_DISP2, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_MARU3_DISP2.Size = New System.Drawing.Size(107, 20)
        Me.num_MARU3_DISP2.Spin.Increment = 0
        Me.num_MARU3_DISP2.TabIndex = 13
        ValueProcess8.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_MARU3_DISP2).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess8})
        Me.GcNumberValidator1.GetValidateItems(Me.num_MARU3_DISP2).AddRange(New Object() {InvalidRange8})
        Me.num_MARU3_DISP2.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        '
        'num_KOME3_DISP2
        '
        Me.num_KOME3_DISP2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOME3_DISP2.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOME3_DISP2.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOME3_DISP2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField16.GroupSizes = New Integer() {3}
        Me.num_KOME3_DISP2.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField16})
        Me.num_KOME3_DISP2.DropDown.AllowDrop = False
        Me.num_KOME3_DISP2.Enabled = False
        Me.num_KOME3_DISP2.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOME3_DISP2.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOME3_DISP2.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOME3_DISP2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOME3_DISP2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOME3_DISP2.HighlightText = True
        Me.num_KOME3_DISP2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOME3_DISP2.Location = New System.Drawing.Point(790, 677)
        Me.num_KOME3_DISP2.Name = "num_KOME3_DISP2"
        Me.num_KOME3_DISP2.NegativeColor = System.Drawing.Color.Black
        Me.num_KOME3_DISP2.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOME3_DISP2, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOME3_DISP2, Object), CType(Me.num_KOME3_DISP2, Object), CType(Me.num_KOME3_DISP2, Object), CType(Me.num_KOME3_DISP2, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOME3_DISP2.Size = New System.Drawing.Size(107, 20)
        Me.num_KOME3_DISP2.Spin.Increment = 0
        Me.num_KOME3_DISP2.TabIndex = 14
        ValueProcess9.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_KOME3_DISP2).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess9})
        Me.GcNumberValidator1.GetValidateItems(Me.num_KOME3_DISP2).AddRange(New Object() {InvalidRange9})
        Me.num_KOME3_DISP2.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        '
        'num_MARU5
        '
        Me.num_MARU5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_MARU5.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_MARU5.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_MARU5.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField17.GroupSizes = New Integer() {3}
        Me.num_MARU5.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField17})
        Me.num_MARU5.DropDown.AllowDrop = False
        Me.num_MARU5.Enabled = False
        Me.num_MARU5.Fields.DecimalPart.MaxDigits = 0
        Me.num_MARU5.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_MARU5.Fields.IntegerPart.MaxDigits = 12
        Me.num_MARU5.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_MARU5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_MARU5.HighlightText = True
        Me.num_MARU5.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_MARU5.Location = New System.Drawing.Point(925, 677)
        Me.num_MARU5.Name = "num_MARU5"
        Me.num_MARU5.NegativeColor = System.Drawing.Color.Black
        Me.num_MARU5.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_MARU5, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_MARU5, Object), CType(Me.num_MARU5, Object), CType(Me.num_MARU5, Object), CType(Me.num_MARU5, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_MARU5.Size = New System.Drawing.Size(107, 20)
        Me.num_MARU5.Spin.Increment = 0
        Me.num_MARU5.TabIndex = 15
        ValueProcess10.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_MARU5).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess10})
        Me.GcNumberValidator1.GetValidateItems(Me.num_MARU5).AddRange(New Object() {InvalidRange10})
        Me.num_MARU5.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        '
        'num_MARU6
        '
        Me.num_MARU6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_MARU6.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_MARU6.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_MARU6.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField18.GroupSizes = New Integer() {3}
        Me.num_MARU6.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField18})
        Me.num_MARU6.DropDown.AllowDrop = False
        Me.num_MARU6.Enabled = False
        Me.num_MARU6.Fields.DecimalPart.MaxDigits = 0
        Me.num_MARU6.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_MARU6.Fields.IntegerPart.MaxDigits = 12
        Me.num_MARU6.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_MARU6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_MARU6.HighlightText = True
        Me.num_MARU6.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_MARU6.Location = New System.Drawing.Point(262, 698)
        Me.num_MARU6.Name = "num_MARU6"
        Me.num_MARU6.NegativeColor = System.Drawing.Color.Black
        Me.num_MARU6.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_MARU6, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_MARU6, Object), CType(Me.num_MARU6, Object), CType(Me.num_MARU6, Object), CType(Me.num_MARU6, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_MARU6.Size = New System.Drawing.Size(107, 20)
        Me.num_MARU6.Spin.Increment = 0
        Me.num_MARU6.TabIndex = 16
        ValueProcess11.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_MARU6).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess11})
        Me.GcNumberValidator1.GetValidateItems(Me.num_MARU6).AddRange(New Object() {InvalidRange11})
        Me.num_MARU6.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        '
        'dateSINSEI_DATE
        '
        Me.dateSINSEI_DATE.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.dateSINSEI_DATE.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateLiteralField4, DateEraYearField2, DateLiteralField5, DateMonthField2, DateLiteralField6, DateDayField2})
        Me.dateSINSEI_DATE.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateSINSEI_DATE.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateSINSEI_DATE.InputCheck = True
        Me.dateSINSEI_DATE.Location = New System.Drawing.Point(107, 130)
        Me.dateSINSEI_DATE.Name = "dateSINSEI_DATE"
        Me.GcShortcut1.SetShortcuts(Me.dateSINSEI_DATE, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateSINSEI_DATE, Object), CType(Me.dateSINSEI_DATE, Object), CType(Me.dateSINSEI_DATE, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateSINSEI_DATE.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton7})
        Me.dateSINSEI_DATE.Size = New System.Drawing.Size(124, 20)
        Me.dateSINSEI_DATE.Spin.AllowSpin = False
        Me.dateSINSEI_DATE.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateSINSEI_DATE.TabIndex = 1300
        Me.dateSINSEI_DATE.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton7
        '
        Me.DropDownButton7.Name = "DropDownButton7"
        '
        'num_KOFU_KIN11
        '
        Me.num_KOFU_KIN11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN11.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN11.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField19.GroupSizes = New Integer() {3, 3, 3}
        Me.num_KOFU_KIN11.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField10, NumberIntegerPartDisplayField19})
        Me.num_KOFU_KIN11.DropDown.AllowDrop = False
        Me.num_KOFU_KIN11.Enabled = False
        Me.num_KOFU_KIN11.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN11.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN11.Fields.IntegerPart.MaxDigits = 11
        Me.num_KOFU_KIN11.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN11.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN11.HighlightText = True
        Me.num_KOFU_KIN11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN11.Location = New System.Drawing.Point(694, 397)
        Me.num_KOFU_KIN11.Name = "num_KOFU_KIN11"
        Me.num_KOFU_KIN11.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN11.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN11, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN11, Object), CType(Me.num_KOFU_KIN11, Object), CType(Me.num_KOFU_KIN11, Object), CType(Me.num_KOFU_KIN11, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN11.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_KIN11.Spin.Increment = 0
        Me.num_KOFU_KIN11.TabIndex = 1315
        Me.num_KOFU_KIN11.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOFU_KIN11.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_KIN10
        '
        Me.num_KOFU_KIN10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN10.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN10.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField20.GroupSizes = New Integer() {3, 3, 3}
        Me.num_KOFU_KIN10.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField11, NumberIntegerPartDisplayField20})
        Me.num_KOFU_KIN10.DropDown.AllowDrop = False
        Me.num_KOFU_KIN10.Enabled = False
        Me.num_KOFU_KIN10.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN10.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN10.Fields.IntegerPart.MaxDigits = 11
        Me.num_KOFU_KIN10.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN10.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN10.HighlightText = True
        Me.num_KOFU_KIN10.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN10.Location = New System.Drawing.Point(574, 397)
        Me.num_KOFU_KIN10.Name = "num_KOFU_KIN10"
        Me.num_KOFU_KIN10.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN10.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN10, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN10, Object), CType(Me.num_KOFU_KIN10, Object), CType(Me.num_KOFU_KIN10, Object), CType(Me.num_KOFU_KIN10, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN10.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_KIN10.Spin.Increment = 0
        Me.num_KOFU_KIN10.TabIndex = 1314
        Me.num_KOFU_KIN10.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOFU_KIN10.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_KIN09
        '
        Me.num_KOFU_KIN09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN09.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN09.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField21.GroupSizes = New Integer() {3, 3, 3}
        Me.num_KOFU_KIN09.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField12, NumberIntegerPartDisplayField21})
        Me.num_KOFU_KIN09.DropDown.AllowDrop = False
        Me.num_KOFU_KIN09.Enabled = False
        Me.num_KOFU_KIN09.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN09.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN09.Fields.IntegerPart.MaxDigits = 11
        Me.num_KOFU_KIN09.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN09.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN09.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN09.HighlightText = True
        Me.num_KOFU_KIN09.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN09.Location = New System.Drawing.Point(453, 397)
        Me.num_KOFU_KIN09.Name = "num_KOFU_KIN09"
        Me.num_KOFU_KIN09.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN09.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN09, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN09, Object), CType(Me.num_KOFU_KIN09, Object), CType(Me.num_KOFU_KIN09, Object), CType(Me.num_KOFU_KIN09, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN09.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_KIN09.Spin.Increment = 0
        Me.num_KOFU_KIN09.TabIndex = 1313
        Me.num_KOFU_KIN09.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOFU_KIN09.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_KIN08
        '
        Me.num_KOFU_KIN08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN08.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN08.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField22.GroupSizes = New Integer() {3, 3, 3}
        Me.num_KOFU_KIN08.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField13, NumberIntegerPartDisplayField22})
        Me.num_KOFU_KIN08.DropDown.AllowDrop = False
        Me.num_KOFU_KIN08.Enabled = False
        Me.num_KOFU_KIN08.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN08.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN08.Fields.IntegerPart.MaxDigits = 11
        Me.num_KOFU_KIN08.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN08.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN08.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN08.HighlightText = True
        Me.num_KOFU_KIN08.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN08.Location = New System.Drawing.Point(331, 397)
        Me.num_KOFU_KIN08.Name = "num_KOFU_KIN08"
        Me.num_KOFU_KIN08.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN08.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN08, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN08, Object), CType(Me.num_KOFU_KIN08, Object), CType(Me.num_KOFU_KIN08, Object), CType(Me.num_KOFU_KIN08, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN08.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_KIN08.Spin.Increment = 0
        Me.num_KOFU_KIN08.TabIndex = 1312
        Me.num_KOFU_KIN08.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOFU_KIN08.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_KIN07
        '
        Me.num_KOFU_KIN07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN07.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN07.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField23.GroupSizes = New Integer() {3, 3, 3}
        Me.num_KOFU_KIN07.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField14, NumberIntegerPartDisplayField23})
        Me.num_KOFU_KIN07.DropDown.AllowDrop = False
        Me.num_KOFU_KIN07.Enabled = False
        Me.num_KOFU_KIN07.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN07.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN07.Fields.IntegerPart.MaxDigits = 11
        Me.num_KOFU_KIN07.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN07.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN07.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN07.HighlightText = True
        Me.num_KOFU_KIN07.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN07.Location = New System.Drawing.Point(210, 397)
        Me.num_KOFU_KIN07.Name = "num_KOFU_KIN07"
        Me.num_KOFU_KIN07.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN07.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN07, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN07, Object), CType(Me.num_KOFU_KIN07, Object), CType(Me.num_KOFU_KIN07, Object), CType(Me.num_KOFU_KIN07, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN07.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_KIN07.Spin.Increment = 0
        Me.num_KOFU_KIN07.TabIndex = 1311
        Me.num_KOFU_KIN07.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOFU_KIN07.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_HASU11
        '
        Me.num_KOFU_HASU11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU11.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU11.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU11.DropDown.AllowDrop = False
        Me.num_KOFU_HASU11.Enabled = False
        Me.num_KOFU_HASU11.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU11.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU11.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_HASU11.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU11.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU11.HighlightText = True
        Me.num_KOFU_HASU11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU11.Location = New System.Drawing.Point(694, 376)
        Me.num_KOFU_HASU11.Name = "num_KOFU_HASU11"
        Me.num_KOFU_HASU11.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU11.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU11, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU11, Object), CType(Me.num_KOFU_HASU11, Object), CType(Me.num_KOFU_HASU11, Object), CType(Me.num_KOFU_HASU11, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU11.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_HASU11.Spin.Increment = 0
        Me.num_KOFU_HASU11.TabIndex = 1310
        Me.num_KOFU_HASU11.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_KOFU_HASU11.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_HASU10
        '
        Me.num_KOFU_HASU10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU10.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU10.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU10.DropDown.AllowDrop = False
        Me.num_KOFU_HASU10.Enabled = False
        Me.num_KOFU_HASU10.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU10.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU10.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_HASU10.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU10.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU10.HighlightText = True
        Me.num_KOFU_HASU10.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU10.Location = New System.Drawing.Point(574, 376)
        Me.num_KOFU_HASU10.Name = "num_KOFU_HASU10"
        Me.num_KOFU_HASU10.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU10.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU10, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU10, Object), CType(Me.num_KOFU_HASU10, Object), CType(Me.num_KOFU_HASU10, Object), CType(Me.num_KOFU_HASU10, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU10.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_HASU10.Spin.Increment = 0
        Me.num_KOFU_HASU10.TabIndex = 1308
        Me.num_KOFU_HASU10.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_KOFU_HASU10.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_HASU09
        '
        Me.num_KOFU_HASU09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU09.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU09.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU09.DropDown.AllowDrop = False
        Me.num_KOFU_HASU09.Enabled = False
        Me.num_KOFU_HASU09.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU09.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU09.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_HASU09.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU09.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU09.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU09.HighlightText = True
        Me.num_KOFU_HASU09.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU09.Location = New System.Drawing.Point(453, 376)
        Me.num_KOFU_HASU09.Name = "num_KOFU_HASU09"
        Me.num_KOFU_HASU09.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU09.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU09, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU09, Object), CType(Me.num_KOFU_HASU09, Object), CType(Me.num_KOFU_HASU09, Object), CType(Me.num_KOFU_HASU09, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU09.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_HASU09.Spin.Increment = 0
        Me.num_KOFU_HASU09.TabIndex = 1306
        Me.num_KOFU_HASU09.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_KOFU_HASU09.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_HASU08
        '
        Me.num_KOFU_HASU08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU08.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU08.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU08.DropDown.AllowDrop = False
        Me.num_KOFU_HASU08.Enabled = False
        Me.num_KOFU_HASU08.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU08.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU08.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_HASU08.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU08.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU08.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU08.HighlightText = True
        Me.num_KOFU_HASU08.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU08.Location = New System.Drawing.Point(331, 376)
        Me.num_KOFU_HASU08.Name = "num_KOFU_HASU08"
        Me.num_KOFU_HASU08.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU08.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU08, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU08, Object), CType(Me.num_KOFU_HASU08, Object), CType(Me.num_KOFU_HASU08, Object), CType(Me.num_KOFU_HASU08, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU08.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_HASU08.Spin.Increment = 0
        Me.num_KOFU_HASU08.TabIndex = 1304
        Me.num_KOFU_HASU08.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_KOFU_HASU08.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_HASU07
        '
        Me.num_KOFU_HASU07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU07.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU07.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU07.DropDown.AllowDrop = False
        Me.num_KOFU_HASU07.Enabled = False
        Me.num_KOFU_HASU07.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU07.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU07.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_HASU07.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU07.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU07.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU07.HighlightText = True
        Me.num_KOFU_HASU07.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU07.Location = New System.Drawing.Point(210, 376)
        Me.num_KOFU_HASU07.Name = "num_KOFU_HASU07"
        Me.num_KOFU_HASU07.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU07.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU07, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU07, Object), CType(Me.num_KOFU_HASU07, Object), CType(Me.num_KOFU_HASU07, Object), CType(Me.num_KOFU_HASU07, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU07.Size = New System.Drawing.Size(124, 22)
        Me.num_KOFU_HASU07.Spin.Increment = 0
        Me.num_KOFU_HASU07.TabIndex = 1302
        Me.num_KOFU_HASU07.Value = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.num_KOFU_HASU07.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_GENGAKU_RITU
        '
        Me.num_GENGAKU_RITU.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.num_GENGAKU_RITU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_GENGAKU_RITU.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_GENGAKU_RITU.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_GENGAKU_RITU.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_GENGAKU_RITU.DropDown.AllowDrop = False
        Me.num_GENGAKU_RITU.Fields.DecimalPart.MaxDigits = 0
        Me.num_GENGAKU_RITU.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_GENGAKU_RITU.Fields.IntegerPart.MaxDigits = 3
        Me.num_GENGAKU_RITU.Fields.IntegerPart.MinDigits = 1
        Me.num_GENGAKU_RITU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_GENGAKU_RITU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_GENGAKU_RITU.HighlightText = True
        Me.num_GENGAKU_RITU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_GENGAKU_RITU.Location = New System.Drawing.Point(736, 588)
        Me.num_GENGAKU_RITU.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.num_GENGAKU_RITU.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.num_GENGAKU_RITU.Name = "num_GENGAKU_RITU"
        Me.num_GENGAKU_RITU.NegativeColor = System.Drawing.Color.Black
        Me.num_GENGAKU_RITU.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_GENGAKU_RITU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_GENGAKU_RITU, Object), CType(Me.num_GENGAKU_RITU, Object), CType(Me.num_GENGAKU_RITU, Object), CType(Me.num_GENGAKU_RITU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_GENGAKU_RITU.Size = New System.Drawing.Size(52, 20)
        Me.num_GENGAKU_RITU.Spin.Increment = 0
        Me.num_GENGAKU_RITU.TabIndex = 13
        ValueProcess12.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_GENGAKU_RITU).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess12})
        InvalidRange12.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        InvalidRange12.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.num_GENGAKU_RITU).AddRange(New Object() {InvalidRange12})
        Me.num_GENGAKU_RITU.Value = Nothing
        Me.num_GENGAKU_RITU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_MARU4
        '
        Me.num_MARU4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_MARU4.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_MARU4.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_MARU4.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField24.GroupSizes = New Integer() {3}
        Me.num_MARU4.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField24})
        Me.num_MARU4.DropDown.AllowDrop = False
        Me.num_MARU4.Enabled = False
        Me.num_MARU4.Fields.DecimalPart.MaxDigits = 0
        Me.num_MARU4.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_MARU4.Fields.IntegerPart.MaxDigits = 12
        Me.num_MARU4.Fields.IntegerPart.MinDigits = 1
        Me.num_MARU4.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_MARU4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_MARU4.HighlightText = True
        Me.num_MARU4.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_MARU4.Location = New System.Drawing.Point(862, 654)
        Me.num_MARU4.Name = "num_MARU4"
        Me.num_MARU4.NegativeColor = System.Drawing.Color.Black
        Me.num_MARU4.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_MARU4, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_MARU4, Object), CType(Me.num_MARU4, Object), CType(Me.num_MARU4, Object), CType(Me.num_MARU4, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_MARU4.Size = New System.Drawing.Size(107, 20)
        Me.num_MARU4.Spin.Increment = 0
        Me.num_MARU4.TabIndex = 1323
        Me.num_MARU4.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_MARU4.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_RITU
        '
        Me.num_KOFU_RITU.BackColor = System.Drawing.Color.Gold
        Me.num_KOFU_RITU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_RITU.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOFU_RITU.DisabledBackColor = System.Drawing.Color.Gold
        Me.num_KOFU_RITU.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_RITU.DropDown.AllowDrop = False
        Me.num_KOFU_RITU.Enabled = False
        Me.num_KOFU_RITU.Fields.DecimalPart.MaxDigits = 6
        Me.num_KOFU_RITU.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_RITU.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOFU_RITU.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_RITU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_RITU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_RITU.HighlightText = True
        Me.num_KOFU_RITU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_RITU.Location = New System.Drawing.Point(684, 654)
        Me.num_KOFU_RITU.Name = "num_KOFU_RITU"
        Me.num_KOFU_RITU.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_RITU.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_RITU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_RITU, Object), CType(Me.num_KOFU_RITU, Object), CType(Me.num_KOFU_RITU, Object), CType(Me.num_KOFU_RITU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_RITU.Size = New System.Drawing.Size(92, 20)
        Me.num_KOFU_RITU.Spin.Increment = 0
        Me.num_KOFU_RITU.TabIndex = 1321
        Me.num_KOFU_RITU.Value = New Decimal(New Integer() {999999999, 0, 0, 393216})
        Me.num_KOFU_RITU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOME2
        '
        Me.num_KOME2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOME2.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOME2.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOME2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField25.GroupSizes = New Integer() {3}
        Me.num_KOME2.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField25})
        Me.num_KOME2.DropDown.AllowDrop = False
        Me.num_KOME2.Enabled = False
        Me.num_KOME2.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOME2.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOME2.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOME2.Fields.IntegerPart.MinDigits = 1
        Me.num_KOME2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOME2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOME2.HighlightText = True
        Me.num_KOME2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOME2.Location = New System.Drawing.Point(862, 588)
        Me.num_KOME2.Name = "num_KOME2"
        Me.num_KOME2.NegativeColor = System.Drawing.Color.Black
        Me.num_KOME2.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOME2, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOME2, Object), CType(Me.num_KOME2, Object), CType(Me.num_KOME2, Object), CType(Me.num_KOME2, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOME2.Size = New System.Drawing.Size(107, 20)
        Me.num_KOME2.Spin.Increment = 0
        Me.num_KOME2.TabIndex = 1319
        Me.num_KOME2.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_KOME2.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_MARU3_CALC
        '
        Me.num_MARU3_CALC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_MARU3_CALC.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_MARU3_CALC.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_MARU3_CALC.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField26.GroupSizes = New Integer() {3}
        Me.num_MARU3_CALC.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField26})
        Me.num_MARU3_CALC.DropDown.AllowDrop = False
        Me.num_MARU3_CALC.Enabled = False
        Me.num_MARU3_CALC.Fields.DecimalPart.MaxDigits = 0
        Me.num_MARU3_CALC.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_MARU3_CALC.Fields.IntegerPart.MaxDigits = 12
        Me.num_MARU3_CALC.Fields.IntegerPart.MinDigits = 1
        Me.num_MARU3_CALC.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_MARU3_CALC.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_MARU3_CALC.HighlightText = True
        Me.num_MARU3_CALC.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_MARU3_CALC.Location = New System.Drawing.Point(862, 610)
        Me.num_MARU3_CALC.Name = "num_MARU3_CALC"
        Me.num_MARU3_CALC.NegativeColor = System.Drawing.Color.Black
        Me.num_MARU3_CALC.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_MARU3_CALC, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_MARU3_CALC, Object), CType(Me.num_MARU3_CALC, Object), CType(Me.num_MARU3_CALC, Object), CType(Me.num_MARU3_CALC, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_MARU3_CALC.Size = New System.Drawing.Size(107, 20)
        Me.num_MARU3_CALC.Spin.Increment = 0
        Me.num_MARU3_CALC.TabIndex = 1328
        Me.num_MARU3_CALC.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.num_MARU3_CALC.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOME3_DISP1
        '
        Me.num_KOME3_DISP1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOME3_DISP1.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOME3_DISP1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOME3_DISP1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField27.GroupSizes = New Integer() {3}
        Me.num_KOME3_DISP1.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField27})
        Me.num_KOME3_DISP1.DropDown.AllowDrop = False
        Me.num_KOME3_DISP1.Enabled = False
        Me.num_KOME3_DISP1.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOME3_DISP1.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOME3_DISP1.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOME3_DISP1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOME3_DISP1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOME3_DISP1.HighlightText = True
        Me.num_KOME3_DISP1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOME3_DISP1.Location = New System.Drawing.Point(441, 655)
        Me.num_KOME3_DISP1.Name = "num_KOME3_DISP1"
        Me.num_KOME3_DISP1.NegativeColor = System.Drawing.Color.Black
        Me.num_KOME3_DISP1.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOME3_DISP1, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOME3_DISP1, Object), CType(Me.num_KOME3_DISP1, Object), CType(Me.num_KOME3_DISP1, Object), CType(Me.num_KOME3_DISP1, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOME3_DISP1.Size = New System.Drawing.Size(107, 20)
        Me.num_KOME3_DISP1.Spin.Increment = 0
        Me.num_KOME3_DISP1.TabIndex = 1330
        ValueProcess13.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_KOME3_DISP1).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess13})
        Me.GcNumberValidator1.GetValidateItems(Me.num_KOME3_DISP1).AddRange(New Object() {InvalidRange13})
        Me.num_KOME3_DISP1.Value = New Decimal(New Integer() {1215752191, 23, 0, 0})
        '
        'DropDownButton14
        '
        Me.DropDownButton14.Name = "DropDownButton14"
        '
        'DropDownButton15
        '
        Me.DropDownButton15.Name = "DropDownButton15"
        '
        'DropDownButton16
        '
        Me.DropDownButton16.Name = "DropDownButton16"
        '
        'DropDownButton17
        '
        Me.DropDownButton17.Name = "DropDownButton17"
        '
        'DropDownButton18
        '
        Me.DropDownButton18.Name = "DropDownButton18"
        '
        'DropDownButton19
        '
        Me.DropDownButton19.Name = "DropDownButton19"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(13, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "契約者番号"
        '
        'dgv_Search
        '
        Me.dgv_Search.AllowUserToAddRows = False
        Me.dgv_Search.AllowUserToDeleteRows = False
        Me.dgv_Search.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Search.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Search.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MEISAI_NO, Me.NOJO_NAME, Me.ADDR, Me.TORI_KBN_NM, Me.KEISAN_KAISU, Me.SYORI_JOKYO_KBN_NM, Me.KOFU_HASU, Me.GENGAKU_RITU, Me.KOFU_KIN, Me.NOJO_CD, Me.TORI_KBN, Me.SYORI_JOKYO_KBN, Me.SEI_TUMITATE_KIN, Me.KUNI_KOFU_KIN, Me.ADDR_POST, Me.ADDR_1, Me.ADDR_2, Me.ADDR_3, Me.ADDR_4, Me.KI, Me.KEIYAKUSYA_CD, Me.HASSEI_KAISU, Me.KEIYAKU_HASU, Me.KOFU_RITU})
        Me.dgv_Search.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dgv_Search.Location = New System.Drawing.Point(13, 152)
        Me.dgv_Search.MultiSelect = False
        Me.dgv_Search.Name = "dgv_Search"
        Me.dgv_Search.ReadOnly = True
        Me.dgv_Search.RowHeadersVisible = False
        Me.dgv_Search.RowTemplate.Height = 21
        Me.dgv_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Search.Size = New System.Drawing.Size(1069, 130)
        Me.dgv_Search.StandardTab = True
        Me.dgv_Search.TabIndex = 2
        '
        'MEISAI_NO
        '
        Me.MEISAI_NO.DataPropertyName = "MEISAI_NO"
        Me.MEISAI_NO.Frozen = True
        Me.MEISAI_NO.HeaderText = "明細番号"
        Me.MEISAI_NO.Name = "MEISAI_NO"
        Me.MEISAI_NO.ReadOnly = True
        Me.MEISAI_NO.Width = 75
        '
        'NOJO_NAME
        '
        Me.NOJO_NAME.DataPropertyName = "NOJO_NAME"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NOJO_NAME.DefaultCellStyle = DataGridViewCellStyle2
        Me.NOJO_NAME.Frozen = True
        Me.NOJO_NAME.HeaderText = "農場名"
        Me.NOJO_NAME.Name = "NOJO_NAME"
        Me.NOJO_NAME.ReadOnly = True
        Me.NOJO_NAME.Width = 165
        '
        'ADDR
        '
        Me.ADDR.DataPropertyName = "ADDR"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR.DefaultCellStyle = DataGridViewCellStyle3
        Me.ADDR.Frozen = True
        Me.ADDR.HeaderText = "農場住所"
        Me.ADDR.Name = "ADDR"
        Me.ADDR.ReadOnly = True
        Me.ADDR.Width = 215
        '
        'TORI_KBN_NM
        '
        Me.TORI_KBN_NM.DataPropertyName = "TORI_KBN_NM"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.TORI_KBN_NM.DefaultCellStyle = DataGridViewCellStyle4
        Me.TORI_KBN_NM.Frozen = True
        Me.TORI_KBN_NM.HeaderText = "鳥の種類"
        Me.TORI_KBN_NM.Name = "TORI_KBN_NM"
        Me.TORI_KBN_NM.ReadOnly = True
        Me.TORI_KBN_NM.Width = 80
        '
        'KEISAN_KAISU
        '
        Me.KEISAN_KAISU.DataPropertyName = "KEISAN_KAISU"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.KEISAN_KAISU.DefaultCellStyle = DataGridViewCellStyle5
        Me.KEISAN_KAISU.Frozen = True
        Me.KEISAN_KAISU.HeaderText = "計算回数"
        Me.KEISAN_KAISU.Name = "KEISAN_KAISU"
        Me.KEISAN_KAISU.ReadOnly = True
        Me.KEISAN_KAISU.Width = 75
        '
        'SYORI_JOKYO_KBN_NM
        '
        Me.SYORI_JOKYO_KBN_NM.DataPropertyName = "SYORI_JOKYO_KBN_NM"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.SYORI_JOKYO_KBN_NM.DefaultCellStyle = DataGridViewCellStyle6
        Me.SYORI_JOKYO_KBN_NM.Frozen = True
        Me.SYORI_JOKYO_KBN_NM.HeaderText = "処理状況"
        Me.SYORI_JOKYO_KBN_NM.Name = "SYORI_JOKYO_KBN_NM"
        Me.SYORI_JOKYO_KBN_NM.ReadOnly = True
        Me.SYORI_JOKYO_KBN_NM.Width = 80
        '
        'KOFU_HASU
        '
        Me.KOFU_HASU.DataPropertyName = "KOFU_HASU"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle7.NullValue = Nothing
        Me.KOFU_HASU.DefaultCellStyle = DataGridViewCellStyle7
        Me.KOFU_HASU.Frozen = True
        Me.KOFU_HASU.HeaderText = "互助金対象羽数"
        Me.KOFU_HASU.Name = "KOFU_HASU"
        Me.KOFU_HASU.ReadOnly = True
        Me.KOFU_HASU.Width = 120
        '
        'GENGAKU_RITU
        '
        Me.GENGAKU_RITU.DataPropertyName = "GENGAKU_RITU"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!)
        Me.GENGAKU_RITU.DefaultCellStyle = DataGridViewCellStyle8
        Me.GENGAKU_RITU.Frozen = True
        Me.GENGAKU_RITU.HeaderText = "減額率%"
        Me.GENGAKU_RITU.Name = "GENGAKU_RITU"
        Me.GENGAKU_RITU.ReadOnly = True
        Me.GENGAKU_RITU.Width = 80
        '
        'KOFU_KIN
        '
        Me.KOFU_KIN.DataPropertyName = "KOFU_KIN"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle9.NullValue = Nothing
        Me.KOFU_KIN.DefaultCellStyle = DataGridViewCellStyle9
        Me.KOFU_KIN.Frozen = True
        Me.KOFU_KIN.HeaderText = "焼却・埋却等互助金額"
        Me.KOFU_KIN.Name = "KOFU_KIN"
        Me.KOFU_KIN.ReadOnly = True
        Me.KOFU_KIN.Width = 160
        '
        'NOJO_CD
        '
        Me.NOJO_CD.DataPropertyName = "NOJO_CD"
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.NOJO_CD.DefaultCellStyle = DataGridViewCellStyle10
        Me.NOJO_CD.Frozen = True
        Me.NOJO_CD.HeaderText = "農場コード"
        Me.NOJO_CD.Name = "NOJO_CD"
        Me.NOJO_CD.ReadOnly = True
        Me.NOJO_CD.Visible = False
        '
        'TORI_KBN
        '
        Me.TORI_KBN.DataPropertyName = "TORI_KBN"
        DataGridViewCellStyle11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.TORI_KBN.DefaultCellStyle = DataGridViewCellStyle11
        Me.TORI_KBN.Frozen = True
        Me.TORI_KBN.HeaderText = "鳥の種類コード"
        Me.TORI_KBN.Name = "TORI_KBN"
        Me.TORI_KBN.ReadOnly = True
        Me.TORI_KBN.Visible = False
        Me.TORI_KBN.Width = 20
        '
        'SYORI_JOKYO_KBN
        '
        Me.SYORI_JOKYO_KBN.DataPropertyName = "SYORI_JOKYO_KBN"
        Me.SYORI_JOKYO_KBN.Frozen = True
        Me.SYORI_JOKYO_KBN.HeaderText = "処理状況区分コード"
        Me.SYORI_JOKYO_KBN.Name = "SYORI_JOKYO_KBN"
        Me.SYORI_JOKYO_KBN.ReadOnly = True
        Me.SYORI_JOKYO_KBN.Visible = False
        '
        'SEI_TUMITATE_KIN
        '
        Me.SEI_TUMITATE_KIN.DataPropertyName = "SEI_TUMITATE_KIN"
        Me.SEI_TUMITATE_KIN.Frozen = True
        Me.SEI_TUMITATE_KIN.HeaderText = "積立金交付額"
        Me.SEI_TUMITATE_KIN.Name = "SEI_TUMITATE_KIN"
        Me.SEI_TUMITATE_KIN.ReadOnly = True
        Me.SEI_TUMITATE_KIN.Visible = False
        '
        'KUNI_KOFU_KIN
        '
        Me.KUNI_KOFU_KIN.DataPropertyName = "KUNI_KOFU_KIN"
        Me.KUNI_KOFU_KIN.Frozen = True
        Me.KUNI_KOFU_KIN.HeaderText = "国庫交付額"
        Me.KUNI_KOFU_KIN.Name = "KUNI_KOFU_KIN"
        Me.KUNI_KOFU_KIN.ReadOnly = True
        Me.KUNI_KOFU_KIN.Visible = False
        '
        'ADDR_POST
        '
        Me.ADDR_POST.DataPropertyName = "ADDR_POST"
        Me.ADDR_POST.Frozen = True
        Me.ADDR_POST.HeaderText = "郵便番号"
        Me.ADDR_POST.Name = "ADDR_POST"
        Me.ADDR_POST.ReadOnly = True
        Me.ADDR_POST.Visible = False
        '
        'ADDR_1
        '
        Me.ADDR_1.DataPropertyName = "ADDR_1"
        DataGridViewCellStyle12.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_1.DefaultCellStyle = DataGridViewCellStyle12
        Me.ADDR_1.Frozen = True
        Me.ADDR_1.HeaderText = "住所1"
        Me.ADDR_1.Name = "ADDR_1"
        Me.ADDR_1.ReadOnly = True
        Me.ADDR_1.Visible = False
        '
        'ADDR_2
        '
        Me.ADDR_2.DataPropertyName = "ADDR_2"
        DataGridViewCellStyle13.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_2.DefaultCellStyle = DataGridViewCellStyle13
        Me.ADDR_2.Frozen = True
        Me.ADDR_2.HeaderText = "住所2"
        Me.ADDR_2.Name = "ADDR_2"
        Me.ADDR_2.ReadOnly = True
        Me.ADDR_2.Visible = False
        '
        'ADDR_3
        '
        Me.ADDR_3.DataPropertyName = "ADDR_3"
        DataGridViewCellStyle14.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_3.DefaultCellStyle = DataGridViewCellStyle14
        Me.ADDR_3.Frozen = True
        Me.ADDR_3.HeaderText = "住所3"
        Me.ADDR_3.Name = "ADDR_3"
        Me.ADDR_3.ReadOnly = True
        Me.ADDR_3.Visible = False
        '
        'ADDR_4
        '
        Me.ADDR_4.DataPropertyName = "ADDR_4"
        DataGridViewCellStyle15.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ADDR_4.DefaultCellStyle = DataGridViewCellStyle15
        Me.ADDR_4.Frozen = True
        Me.ADDR_4.HeaderText = "住所4"
        Me.ADDR_4.Name = "ADDR_4"
        Me.ADDR_4.ReadOnly = True
        Me.ADDR_4.Visible = False
        '
        'KI
        '
        Me.KI.DataPropertyName = "KI"
        Me.KI.Frozen = True
        Me.KI.HeaderText = "期"
        Me.KI.Name = "KI"
        Me.KI.ReadOnly = True
        Me.KI.Visible = False
        '
        'KEIYAKUSYA_CD
        '
        Me.KEIYAKUSYA_CD.DataPropertyName = "KEIYAKUSYA_CD"
        Me.KEIYAKUSYA_CD.Frozen = True
        Me.KEIYAKUSYA_CD.HeaderText = "契約者番号"
        Me.KEIYAKUSYA_CD.Name = "KEIYAKUSYA_CD"
        Me.KEIYAKUSYA_CD.ReadOnly = True
        Me.KEIYAKUSYA_CD.Visible = False
        '
        'HASSEI_KAISU
        '
        Me.HASSEI_KAISU.DataPropertyName = "HASSEI_KAISU"
        Me.HASSEI_KAISU.Frozen = True
        Me.HASSEI_KAISU.HeaderText = "発生回数"
        Me.HASSEI_KAISU.Name = "HASSEI_KAISU"
        Me.HASSEI_KAISU.ReadOnly = True
        Me.HASSEI_KAISU.Visible = False
        '
        'KEIYAKU_HASU
        '
        Me.KEIYAKU_HASU.DataPropertyName = "KEIYAKU_HASU"
        Me.KEIYAKU_HASU.HeaderText = "契約羽数"
        Me.KEIYAKU_HASU.Name = "KEIYAKU_HASU"
        Me.KEIYAKU_HASU.ReadOnly = True
        Me.KEIYAKU_HASU.Visible = False
        '
        'KOFU_RITU
        '
        Me.KOFU_RITU.DataPropertyName = "KOFU_RITU"
        Me.KOFU_RITU.HeaderText = "交付率"
        Me.KOFU_RITU.Name = "KOFU_RITU"
        Me.KOFU_RITU.ReadOnly = True
        Me.KOFU_RITU.Visible = False
        '
        'cmdDel
        '
        Me.cmdDel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdDel.Location = New System.Drawing.Point(978, 375)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(92, 44)
        Me.cmdDel.TabIndex = 3
        Me.cmdDel.Text = "削除"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(23, 454)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 15)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "農場"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(23, 472)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 15)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "住所"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(23, 522)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(67, 15)
        Me.Label23.TabIndex = 52
        Me.Label23.Text = "契約羽数"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(23, 503)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(67, 15)
        Me.Label26.TabIndex = 58
        Me.Label26.Text = "鶏の種類"
        '
        'cmdCansel
        '
        Me.cmdCansel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCansel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCansel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdCansel.Location = New System.Drawing.Point(119, 6)
        Me.cmdCansel.Name = "cmdCansel"
        Me.cmdCansel.Size = New System.Drawing.Size(92, 44)
        Me.cmdCansel.TabIndex = 2
        Me.cmdCansel.Text = "キャンセル"
        Me.cmdCansel.UseVisualStyleBackColor = True
        '
        'lbl_KEIYAKUSYA_CD
        '
        Me.lbl_KEIYAKUSYA_CD.AutoSize = True
        Me.lbl_KEIYAKUSYA_CD.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKUSYA_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKUSYA_CD.Location = New System.Drawing.Point(108, 50)
        Me.lbl_KEIYAKUSYA_CD.Name = "lbl_KEIYAKUSYA_CD"
        Me.lbl_KEIYAKUSYA_CD.Size = New System.Drawing.Size(47, 15)
        Me.lbl_KEIYAKUSYA_CD.TabIndex = 1059
        Me.lbl_KEIYAKUSYA_CD.Text = "99999"
        '
        'lbl_KEIYAKUSYA_NM
        '
        Me.lbl_KEIYAKUSYA_NM.AutoSize = True
        Me.lbl_KEIYAKUSYA_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKUSYA_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKUSYA_NM.Location = New System.Drawing.Point(173, 50)
        Me.lbl_KEIYAKUSYA_NM.Name = "lbl_KEIYAKUSYA_NM"
        Me.lbl_KEIYAKUSYA_NM.Size = New System.Drawing.Size(157, 15)
        Me.lbl_KEIYAKUSYA_NM.TabIndex = 1060
        Me.lbl_KEIYAKUSYA_NM.Text = "＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_KI
        '
        Me.lbl_KI.AutoSize = True
        Me.lbl_KI.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KI.Location = New System.Drawing.Point(277, 77)
        Me.lbl_KI.Name = "lbl_KI"
        Me.lbl_KI.Size = New System.Drawing.Size(53, 15)
        Me.lbl_KI.TabIndex = 1061
        Me.lbl_KI.Text = "第99期"
        Me.lbl_KI.Visible = False
        '
        'lbl_ADDR_POST
        '
        Me.lbl_ADDR_POST.AutoSize = True
        Me.lbl_ADDR_POST.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_POST.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_POST.Location = New System.Drawing.Point(176, 472)
        Me.lbl_ADDR_POST.Name = "lbl_ADDR_POST"
        Me.lbl_ADDR_POST.Size = New System.Drawing.Size(71, 15)
        Me.lbl_ADDR_POST.TabIndex = 1063
        Me.lbl_ADDR_POST.Text = "999-9999"
        '
        'lbl_ADDR_1
        '
        Me.lbl_ADDR_1.AccessibleDescription = ""
        Me.lbl_ADDR_1.AutoSize = True
        Me.lbl_ADDR_1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_1.Location = New System.Drawing.Point(317, 471)
        Me.lbl_ADDR_1.Name = "lbl_ADDR_1"
        Me.lbl_ADDR_1.Size = New System.Drawing.Size(67, 15)
        Me.lbl_ADDR_1.TabIndex = 1066
        Me.lbl_ADDR_1.Text = "＠＠＠＠"
        '
        'lbl_ADDR_2
        '
        Me.lbl_ADDR_2.AccessibleDescription = "v"
        Me.lbl_ADDR_2.AutoSize = True
        Me.lbl_ADDR_2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_2.Location = New System.Drawing.Point(447, 471)
        Me.lbl_ADDR_2.Name = "lbl_ADDR_2"
        Me.lbl_ADDR_2.Size = New System.Drawing.Size(232, 15)
        Me.lbl_ADDR_2.TabIndex = 1067
        Me.lbl_ADDR_2.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_ADDR_4
        '
        Me.lbl_ADDR_4.AutoSize = True
        Me.lbl_ADDR_4.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_4.Location = New System.Drawing.Point(612, 488)
        Me.lbl_ADDR_4.Name = "lbl_ADDR_4"
        Me.lbl_ADDR_4.Size = New System.Drawing.Size(307, 15)
        Me.lbl_ADDR_4.TabIndex = 1069
        Me.lbl_ADDR_4.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_ADDR_3
        '
        Me.lbl_ADDR_3.AutoSize = True
        Me.lbl_ADDR_3.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_3.Location = New System.Drawing.Point(317, 488)
        Me.lbl_ADDR_3.Name = "lbl_ADDR_3"
        Me.lbl_ADDR_3.Size = New System.Drawing.Size(232, 15)
        Me.lbl_ADDR_3.TabIndex = 1068
        Me.lbl_ADDR_3.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(149, 472)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 15)
        Me.Label3.TabIndex = 1070
        Me.Label3.Text = "〒"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(258, 471)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 1071
        Me.Label5.Text = "(住所１)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(387, 471)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 1072
        Me.Label6.Text = "(住所２)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(258, 488)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 15)
        Me.Label7.TabIndex = 1073
        Me.Label7.Text = "(住所3)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(552, 488)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 15)
        Me.Label8.TabIndex = 1074
        Me.Label8.Text = "(住所４)"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Location = New System.Drawing.Point(26, 102)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(994, 25)
        Me.Panel2.TabIndex = 1076
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(29, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(381, 19)
        Me.Label10.TabIndex = 1059
        Me.Label10.Text = "１．契約農場別明細情報（交付情報）（表示）"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(26, 425)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(994, 25)
        Me.Panel1.TabIndex = 1077
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(29, 2)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(257, 19)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "２．契約農場別登録明細情報"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(29, 286)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 26)
        Me.Label2.TabIndex = 1078
        Me.Label2.Text = "鶏の種類"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(29, 310)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(182, 22)
        Me.Label9.TabIndex = 1079
        Me.Label9.Text = "互助金対象羽数"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(210, 286)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 26)
        Me.Label16.TabIndex = 1084
        Me.Label16.Text = "採卵鶏(成鶏)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(331, 286)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 26)
        Me.Label15.TabIndex = 1087
        Me.Label15.Text = "採卵鶏(育成鶏)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(574, 286)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(124, 26)
        Me.Label19.TabIndex = 1091
        Me.Label19.Text = "種鶏(成鶏)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(453, 286)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(124, 26)
        Me.Label20.TabIndex = 1089
        Me.Label20.Text = "肉用鶏"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(29, 352)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(182, 26)
        Me.Label21.TabIndex = 1095
        Me.Label21.Text = "うずら"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(694, 286)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(124, 26)
        Me.Label22.TabIndex = 1093
        Me.Label22.Text = "種鶏(育成鶏)"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(816, 352)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(124, 26)
        Me.Label24.TabIndex = 1097
        Me.Label24.Text = "合計"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(12, 6)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "保存"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(13, 78)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(82, 15)
        Me.Label25.TabIndex = 1104
        Me.Label25.Text = "■認定回数"
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(171, 69)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(94, 29)
        Me.cmdSearch.TabIndex = 1
        Me.cmdSearch.Text = "検索"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(29, 331)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(182, 22)
        Me.Label12.TabIndex = 1106
        Me.Label12.Text = "焼却・埋却等互助金交付額"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_NOJO_CD
        '
        Me.lbl_NOJO_CD.AutoSize = True
        Me.lbl_NOJO_CD.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_NOJO_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_NOJO_CD.Location = New System.Drawing.Point(149, 454)
        Me.lbl_NOJO_CD.Name = "lbl_NOJO_CD"
        Me.lbl_NOJO_CD.Size = New System.Drawing.Size(71, 15)
        Me.lbl_NOJO_CD.TabIndex = 1114
        Me.lbl_NOJO_CD.Text = "99999999"
        '
        'lbl_NOJO_NAME
        '
        Me.lbl_NOJO_NAME.AutoSize = True
        Me.lbl_NOJO_NAME.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_NOJO_NAME.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_NOJO_NAME.Location = New System.Drawing.Point(258, 454)
        Me.lbl_NOJO_NAME.Name = "lbl_NOJO_NAME"
        Me.lbl_NOJO_NAME.Size = New System.Drawing.Size(457, 15)
        Me.lbl_NOJO_NAME.TabIndex = 1115
        Me.lbl_NOJO_NAME.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_TORI_KBN
        '
        Me.lbl_TORI_KBN.AutoSize = True
        Me.lbl_TORI_KBN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_TORI_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_TORI_KBN.Location = New System.Drawing.Point(149, 503)
        Me.lbl_TORI_KBN.Name = "lbl_TORI_KBN"
        Me.lbl_TORI_KBN.Size = New System.Drawing.Size(15, 15)
        Me.lbl_TORI_KBN.TabIndex = 1116
        Me.lbl_TORI_KBN.Text = "9"
        '
        'lbl_TORI_KBN_NM
        '
        Me.lbl_TORI_KBN_NM.AccessibleDescription = ""
        Me.lbl_TORI_KBN_NM.AutoSize = True
        Me.lbl_TORI_KBN_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_TORI_KBN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_TORI_KBN_NM.Location = New System.Drawing.Point(176, 503)
        Me.lbl_TORI_KBN_NM.Name = "lbl_TORI_KBN_NM"
        Me.lbl_TORI_KBN_NM.Size = New System.Drawing.Size(67, 15)
        Me.lbl_TORI_KBN_NM.TabIndex = 1117
        Me.lbl_TORI_KBN_NM.Text = "＠＠＠＠"
        '
        'lbl_KEIYAKU_HASU
        '
        Me.lbl_KEIYAKU_HASU.AutoSize = True
        Me.lbl_KEIYAKU_HASU.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_HASU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_HASU.Location = New System.Drawing.Point(149, 522)
        Me.lbl_KEIYAKU_HASU.Name = "lbl_KEIYAKU_HASU"
        Me.lbl_KEIYAKU_HASU.Size = New System.Drawing.Size(69, 15)
        Me.lbl_KEIYAKU_HASU.TabIndex = 1118
        Me.lbl_KEIYAKU_HASU.Text = "9,999,999"
        Me.lbl_KEIYAKU_HASU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(259, 522)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(142, 15)
        Me.Label17.TabIndex = 1119
        Me.Label17.Text = "互助金交付対象羽数"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(23, 546)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(112, 15)
        Me.Label29.TabIndex = 1128
        Me.Label29.Text = "①互助金算定額" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(23, 569)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(97, 15)
        Me.Label30.TabIndex = 1129
        Me.Label30.Text = "②焼却等経費" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(23, 591)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(180, 15)
        Me.Label31.TabIndex = 1130
        Me.Label31.Text = "③焼却・埋却互助金算定額"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(23, 635)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(211, 15)
        Me.Label32.TabIndex = 1131
        Me.Label32.Text = "④焼却・埋却互助金（積立金分）"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(23, 680)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(241, 15)
        Me.Label33.TabIndex = 1132
        Me.Label33.Text = "⑤焼却・埋却互助金（国庫交付金分）"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(23, 701)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(135, 15)
        Me.Label34.TabIndex = 1133
        Me.Label34.Text = "⑥焼却・埋却互助金"
        '
        'rbtnSYORI_JOKYO_KBN_3
        '
        Me.rbtnSYORI_JOKYO_KBN_3.AutoSize = True
        Me.rbtnSYORI_JOKYO_KBN_3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnSYORI_JOKYO_KBN_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtnSYORI_JOKYO_KBN_3.Location = New System.Drawing.Point(428, 718)
        Me.rbtnSYORI_JOKYO_KBN_3.Name = "rbtnSYORI_JOKYO_KBN_3"
        Me.rbtnSYORI_JOKYO_KBN_3.Size = New System.Drawing.Size(91, 20)
        Me.rbtnSYORI_JOKYO_KBN_3.TabIndex = 23
        Me.rbtnSYORI_JOKYO_KBN_3.TabStop = True
        Me.rbtnSYORI_JOKYO_KBN_3.Text = "交付確定"
        Me.rbtnSYORI_JOKYO_KBN_3.UseVisualStyleBackColor = True
        '
        'rbtnSYORI_JOKYO_KBN_2
        '
        Me.rbtnSYORI_JOKYO_KBN_2.AutoSize = True
        Me.rbtnSYORI_JOKYO_KBN_2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnSYORI_JOKYO_KBN_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtnSYORI_JOKYO_KBN_2.Location = New System.Drawing.Point(346, 719)
        Me.rbtnSYORI_JOKYO_KBN_2.Name = "rbtnSYORI_JOKYO_KBN_2"
        Me.rbtnSYORI_JOKYO_KBN_2.Size = New System.Drawing.Size(76, 20)
        Me.rbtnSYORI_JOKYO_KBN_2.TabIndex = 22
        Me.rbtnSYORI_JOKYO_KBN_2.TabStop = True
        Me.rbtnSYORI_JOKYO_KBN_2.Text = "審査中"
        Me.rbtnSYORI_JOKYO_KBN_2.UseVisualStyleBackColor = True
        '
        'rbtnSYORI_JOKYO_KBN_1
        '
        Me.rbtnSYORI_JOKYO_KBN_1.AutoSize = True
        Me.rbtnSYORI_JOKYO_KBN_1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnSYORI_JOKYO_KBN_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtnSYORI_JOKYO_KBN_1.Location = New System.Drawing.Point(264, 719)
        Me.rbtnSYORI_JOKYO_KBN_1.Name = "rbtnSYORI_JOKYO_KBN_1"
        Me.rbtnSYORI_JOKYO_KBN_1.Size = New System.Drawing.Size(76, 20)
        Me.rbtnSYORI_JOKYO_KBN_1.TabIndex = 21
        Me.rbtnSYORI_JOKYO_KBN_1.TabStop = True
        Me.rbtnSYORI_JOKYO_KBN_1.Text = "入力中"
        Me.rbtnSYORI_JOKYO_KBN_1.UseVisualStyleBackColor = True
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.BackColor = System.Drawing.Color.Transparent
        Me.Label103.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label103.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label103.Location = New System.Drawing.Point(525, 721)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(97, 15)
        Me.Label103.TabIndex = 24
        Me.Label103.Text = "□確定年月日"
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.BackColor = System.Drawing.Color.Transparent
        Me.Label87.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label87.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label87.Location = New System.Drawing.Point(23, 721)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(112, 15)
        Me.Label87.TabIndex = 1260
        Me.Label87.Text = "■入力確認有無"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(533, 522)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(181, 15)
        Me.Label35.TabIndex = 1263
        Me.Label35.Text = "（焼却・埋却等羽数が対象）"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(259, 546)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(142, 15)
        Me.Label36.TabIndex = 1264
        Me.Label36.Text = "互助金交付対象羽数"
        '
        'Label95
        '
        Me.Label95.BackColor = System.Drawing.Color.Transparent
        Me.Label95.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label95.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label95.Location = New System.Drawing.Point(550, 543)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(20, 20)
        Me.Label95.TabIndex = 1266
        Me.Label95.Text = "×"
        Me.Label95.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(573, 546)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(120, 15)
        Me.Label37.TabIndex = 1267
        Me.Label37.Text = "焼却・埋却等単価"
        '
        'Label97
        '
        Me.Label97.BackColor = System.Drawing.Color.Transparent
        Me.Label97.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label97.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label97.Location = New System.Drawing.Point(896, 543)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(20, 20)
        Me.Label97.TabIndex = 1269
        Me.Label97.Text = "="
        Me.Label97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(259, 569)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 15)
        Me.Label18.TabIndex = 1271
        Me.Label18.Text = "焼却等経費"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(462, 566)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(30, 20)
        Me.Label27.TabIndex = 1273
        Me.Label27.Text = "×"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(491, 566)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(46, 20)
        Me.Label28.TabIndex = 1274
        Me.Label28.Text = "０．９"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label96
        '
        Me.Label96.BackColor = System.Drawing.Color.Transparent
        Me.Label96.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label96.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label96.Location = New System.Drawing.Point(550, 566)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(20, 20)
        Me.Label96.TabIndex = 1275
        Me.Label96.Text = "－"
        Me.Label96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(573, 569)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(163, 15)
        Me.Label38.TabIndex = 1276
        Me.Label38.Text = "国交付金（家伝法２１条）"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(896, 566)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(20, 20)
        Me.Label39.TabIndex = 1279
        Me.Label39.Text = "="
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(259, 635)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(180, 15)
        Me.Label42.TabIndex = 1282
        Me.Label42.Text = "③焼却・埋却互助金算定額"
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(550, 632)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(20, 20)
        Me.Label43.TabIndex = 1284
        Me.Label43.Text = "×"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.BackColor = System.Drawing.Color.Transparent
        Me.Label92.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label92.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label92.Location = New System.Drawing.Point(573, 635)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(35, 15)
        Me.Label92.TabIndex = 1285
        Me.Label92.Text = "１/２"
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(842, 632)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(20, 20)
        Me.Label44.TabIndex = 1286
        Me.Label44.Text = "="
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.BackColor = System.Drawing.Color.Transparent
        Me.Label99.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label99.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label99.Location = New System.Drawing.Point(970, 635)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(121, 15)
        Me.Label99.TabIndex = 1288
        Me.Label99.Text = "（円未満切上）※3"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(259, 680)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(180, 15)
        Me.Label45.TabIndex = 1289
        Me.Label45.Text = "③焼却・埋却互助金算定額"
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.Location = New System.Drawing.Point(550, 677)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(20, 20)
        Me.Label46.TabIndex = 1291
        Me.Label46.Text = "－"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(573, 680)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(219, 15)
        Me.Label47.TabIndex = 1292
        Me.Label47.Text = "※3焼却・埋却互助金（積立金分）"
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label48.Location = New System.Drawing.Point(904, 677)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(20, 20)
        Me.Label48.TabIndex = 1294
        Me.Label48.Text = "="
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label49.Location = New System.Drawing.Point(371, 701)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(68, 15)
        Me.Label49.TabIndex = 1297
        Me.Label49.Text = "（④＋⑤）"
        '
        'lbl_SYORI_JOKYO_KBN_NM
        '
        Me.lbl_SYORI_JOKYO_KBN_NM.AccessibleDescription = ""
        Me.lbl_SYORI_JOKYO_KBN_NM.AutoSize = True
        Me.lbl_SYORI_JOKYO_KBN_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_SYORI_JOKYO_KBN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_SYORI_JOKYO_KBN_NM.Location = New System.Drawing.Point(819, 720)
        Me.lbl_SYORI_JOKYO_KBN_NM.Name = "lbl_SYORI_JOKYO_KBN_NM"
        Me.lbl_SYORI_JOKYO_KBN_NM.Size = New System.Drawing.Size(97, 15)
        Me.lbl_SYORI_JOKYO_KBN_NM.TabIndex = 1298
        Me.lbl_SYORI_JOKYO_KBN_NM.Text = "＠＠＠＠＠＠"
        Me.lbl_SYORI_JOKYO_KBN_NM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label50.Location = New System.Drawing.Point(13, 133)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(67, 15)
        Me.Label50.TabIndex = 1299
        Me.Label50.Text = "■申請日"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label40.Location = New System.Drawing.Point(933, 132)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(75, 15)
        Me.Label40.TabIndex = 1135
        Me.Label40.Text = "抽出件数："
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCOUNT
        '
        Me.lblCOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblCOUNT.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblCOUNT.Location = New System.Drawing.Point(1004, 132)
        Me.lblCOUNT.Name = "lblCOUNT"
        Me.lblCOUNT.Size = New System.Drawing.Size(55, 15)
        Me.lblCOUNT.TabIndex = 1136
        Me.lblCOUNT.Text = "99999"
        Me.lblCOUNT.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label51.Location = New System.Drawing.Point(1061, 132)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(20, 15)
        Me.Label51.TabIndex = 1137
        Me.Label51.Text = "件"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label52.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(694, 352)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(124, 26)
        Me.Label52.TabIndex = 1309
        Me.Label52.Text = "だちょう"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label53.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label53.Location = New System.Drawing.Point(574, 352)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(124, 26)
        Me.Label53.TabIndex = 1307
        Me.Label53.Text = "七面鳥"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label54.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label54.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label54.Location = New System.Drawing.Point(453, 352)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(124, 26)
        Me.Label54.TabIndex = 1305
        Me.Label54.Text = "ほろほろ鳥"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.Transparent
        Me.Label55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label55.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label55.Location = New System.Drawing.Point(331, 352)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(124, 26)
        Me.Label55.TabIndex = 1303
        Me.Label55.Text = "きじ"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label56.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label56.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label56.Location = New System.Drawing.Point(210, 352)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(124, 26)
        Me.Label56.TabIndex = 1301
        Me.Label56.Text = "あひる"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label116
        '
        Me.Label116.AutoSize = True
        Me.Label116.BackColor = System.Drawing.Color.Transparent
        Me.Label116.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label116.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label116.Location = New System.Drawing.Point(573, 657)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(97, 15)
        Me.Label116.TabIndex = 1325
        Me.Label116.Text = "互助金交付率"
        '
        'Label113
        '
        Me.Label113.AutoSize = True
        Me.Label113.BackColor = System.Drawing.Color.Transparent
        Me.Label113.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label113.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label113.Location = New System.Drawing.Point(970, 657)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(113, 15)
        Me.Label113.TabIndex = 1324
        Me.Label113.Text = "（円未満切上）④"
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.BackColor = System.Drawing.Color.Transparent
        Me.Label112.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label112.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label112.Location = New System.Drawing.Point(780, 657)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(15, 15)
        Me.Label112.TabIndex = 1322
        Me.Label112.Text = "%"
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.BackColor = System.Drawing.Color.Transparent
        Me.Label110.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label110.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label110.Location = New System.Drawing.Point(970, 591)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(121, 15)
        Me.Label110.TabIndex = 1320
        Me.Label110.Text = "（円未満切上）※2"
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.BackColor = System.Drawing.Color.Transparent
        Me.Label108.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label108.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label108.Location = New System.Drawing.Point(842, 591)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(15, 15)
        Me.Label108.TabIndex = 1318
        Me.Label108.Text = "%"
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.BackColor = System.Drawing.Color.Transparent
        Me.Label107.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label107.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label107.Location = New System.Drawing.Point(573, 591)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(127, 15)
        Me.Label107.TabIndex = 1317
        Me.Label107.Text = "家伝法違反減額率"
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label58.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label58.Location = New System.Drawing.Point(970, 610)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(30, 20)
        Me.Label58.TabIndex = 1329
        Me.Label58.Text = "③"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.BackColor = System.Drawing.Color.Transparent
        Me.Label89.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label89.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label89.Location = New System.Drawing.Point(573, 613)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(239, 15)
        Me.Label89.TabIndex = 1327
        Me.Label89.Text = "焼却・埋却互助金 算定 (※1 - ※2) "
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.BackColor = System.Drawing.Color.Transparent
        Me.Label59.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label59.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label59.Location = New System.Drawing.Point(405, 657)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(30, 15)
        Me.Label59.TabIndex = 1331
        Me.Label59.Text = "※3"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.BackColor = System.Drawing.Color.Transparent
        Me.Label60.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label60.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label60.Location = New System.Drawing.Point(1026, 546)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(22, 15)
        Me.Label60.TabIndex = 1332
        Me.Label60.Text = "①"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.BackColor = System.Drawing.Color.Transparent
        Me.Label61.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label61.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label61.Location = New System.Drawing.Point(1026, 569)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(22, 15)
        Me.Label61.TabIndex = 1333
        Me.Label61.Text = "②"
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.Color.Transparent
        Me.Label62.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label62.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label62.Location = New System.Drawing.Point(842, 588)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(20, 20)
        Me.Label62.TabIndex = 1334
        Me.Label62.Text = "="
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label63.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label63.Location = New System.Drawing.Point(842, 610)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(20, 20)
        Me.Label63.TabIndex = 1335
        Me.Label63.Text = "="
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.Transparent
        Me.Label64.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label64.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label64.Location = New System.Drawing.Point(842, 654)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(20, 20)
        Me.Label64.TabIndex = 1336
        Me.Label64.Text = "="
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label65.Location = New System.Drawing.Point(274, 591)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(165, 15)
        Me.Label65.TabIndex = 1337
        Me.Label65.Text = "※1 （①と②の少ない方）"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label66.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label66.Location = New System.Drawing.Point(1034, 680)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(22, 15)
        Me.Label66.TabIndex = 1338
        Me.Label66.Text = "⑤"
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label41.Location = New System.Drawing.Point(550, 655)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(20, 20)
        Me.Label41.TabIndex = 1339
        Me.Label41.Text = "×"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label57.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label57.Location = New System.Drawing.Point(550, 589)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(20, 20)
        Me.Label57.TabIndex = 1340
        Me.Label57.Text = "×"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label67.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label67.Location = New System.Drawing.Point(792, 591)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(15, 15)
        Me.Label67.TabIndex = 1341
        Me.Label67.Text = "%"
        '
        'frmGJ4013
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.Color.PeachPuff
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label116)
        Me.Controls.Add(Me.Label107)
        Me.Controls.Add(Me.num_KOME3_DISP1)
        Me.Controls.Add(Me.num_KOME1)
        Me.Controls.Add(Me.num_MARU3_CALC)
        Me.Controls.Add(Me.num_MARU4)
        Me.Controls.Add(Me.num_KOME2)
        Me.Controls.Add(Me.num_KOME3_CALC)
        Me.Controls.Add(Me.num_MARU2)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.Label89)
        Me.Controls.Add(Me.num_GENGAKU_RITU)
        Me.Controls.Add(Me.Label113)
        Me.Controls.Add(Me.Label112)
        Me.Controls.Add(Me.num_KOFU_RITU)
        Me.Controls.Add(Me.Label110)
        Me.Controls.Add(Me.Label108)
        Me.Controls.Add(Me.num_KOFU_KIN11)
        Me.Controls.Add(Me.num_KOFU_KIN10)
        Me.Controls.Add(Me.num_KOFU_KIN09)
        Me.Controls.Add(Me.num_KOFU_KIN08)
        Me.Controls.Add(Me.num_KOFU_KIN07)
        Me.Controls.Add(Me.num_KOFU_HASU11)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.num_KOFU_HASU10)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.num_KOFU_HASU09)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.num_KOFU_HASU08)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.num_KOFU_HASU07)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.dateSINSEI_DATE)
        Me.Controls.Add(Me.lblCOUNT)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.lbl_SYORI_JOKYO_KBN_NM)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.num_MARU6)
        Me.Controls.Add(Me.num_MARU5)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.num_KOME3_DISP2)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.num_MARU3_DISP2)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label99)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label92)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.num_MARU3_DISP1)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.num_KUNI_KOFUKIN)
        Me.Controls.Add(Me.num_SYOKYAKU_KEIHI)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label96)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.num_MARU1)
        Me.Controls.Add(Me.Label97)
        Me.Controls.Add(Me.num_KOFU_TANKA)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label95)
        Me.Controls.Add(Me.num_KOFU_HASU_DISP)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.rbtnSYORI_JOKYO_KBN_3)
        Me.Controls.Add(Me.rbtnSYORI_JOKYO_KBN_2)
        Me.Controls.Add(Me.rbtnSYORI_JOKYO_KBN_1)
        Me.Controls.Add(Me.dateKOFU_KAKUTEI_Ymd)
        Me.Controls.Add(Me.Label103)
        Me.Controls.Add(Me.Label87)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.num_KOFU_HASU_NYU)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lbl_KEIYAKU_HASU)
        Me.Controls.Add(Me.lbl_TORI_KBN_NM)
        Me.Controls.Add(Me.lbl_TORI_KBN)
        Me.Controls.Add(Me.lbl_NOJO_NAME)
        Me.Controls.Add(Me.lbl_NOJO_CD)
        Me.Controls.Add(Me.num_KOFU_KIN00)
        Me.Controls.Add(Me.num_KOFU_KIN06)
        Me.Controls.Add(Me.num_KOFU_KIN05)
        Me.Controls.Add(Me.num_KOFU_KIN04)
        Me.Controls.Add(Me.num_KOFU_KIN03)
        Me.Controls.Add(Me.num_KOFU_KIN02)
        Me.Controls.Add(Me.num_KOFU_KIN01)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.txt_HASSEI_KAISU)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.num_KOFU_HASU00)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.num_KOFU_HASU06)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.num_KOFU_HASU05)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.num_KOFU_HASU04)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.num_KOFU_HASU03)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.num_KOFU_HASU02)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.num_KOFU_HASU01)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lbl_ADDR_4)
        Me.Controls.Add(Me.lbl_ADDR_3)
        Me.Controls.Add(Me.lbl_ADDR_2)
        Me.Controls.Add(Me.lbl_ADDR_1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_ADDR_POST)
        Me.Controls.Add(Me.lbl_KI)
        Me.Controls.Add(Me.lbl_KEIYAKUSYA_NM)
        Me.Controls.Add(Me.lbl_KEIYAKUSYA_CD)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cmdDel)
        Me.Controls.Add(Me.dgv_Search)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmGJ4013"
        Me.Text = "(GJ4013)焼却・埋却互助金申請情報入力（契約交付情報表示）"
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dgv_Search, 0)
        Me.Controls.SetChildIndex(Me.cmdDel, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKUSYA_NM, 0)
        Me.Controls.SetChildIndex(Me.lbl_KI, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_POST, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_1, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_2, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_3, 0)
        Me.Controls.SetChildIndex(Me.lbl_ADDR_4, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU01, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU02, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU03, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU04, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU05, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU06, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU00, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.txt_HASSEI_KAISU, 0)
        Me.Controls.SetChildIndex(Me.cmdSearch, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN01, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN02, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN03, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN04, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN05, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN06, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN00, 0)
        Me.Controls.SetChildIndex(Me.lbl_NOJO_CD, 0)
        Me.Controls.SetChildIndex(Me.lbl_NOJO_NAME, 0)
        Me.Controls.SetChildIndex(Me.lbl_TORI_KBN, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.lbl_TORI_KBN_NM, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_HASU, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU_NYU, 0)
        Me.Controls.SetChildIndex(Me.Label29, 0)
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.Label31, 0)
        Me.Controls.SetChildIndex(Me.Label32, 0)
        Me.Controls.SetChildIndex(Me.Label33, 0)
        Me.Controls.SetChildIndex(Me.Label34, 0)
        Me.Controls.SetChildIndex(Me.Label87, 0)
        Me.Controls.SetChildIndex(Me.Label103, 0)
        Me.Controls.SetChildIndex(Me.dateKOFU_KAKUTEI_Ymd, 0)
        Me.Controls.SetChildIndex(Me.rbtnSYORI_JOKYO_KBN_1, 0)
        Me.Controls.SetChildIndex(Me.rbtnSYORI_JOKYO_KBN_2, 0)
        Me.Controls.SetChildIndex(Me.rbtnSYORI_JOKYO_KBN_3, 0)
        Me.Controls.SetChildIndex(Me.Label35, 0)
        Me.Controls.SetChildIndex(Me.Label36, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU_DISP, 0)
        Me.Controls.SetChildIndex(Me.Label95, 0)
        Me.Controls.SetChildIndex(Me.Label37, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_TANKA, 0)
        Me.Controls.SetChildIndex(Me.Label97, 0)
        Me.Controls.SetChildIndex(Me.num_MARU1, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.Label96, 0)
        Me.Controls.SetChildIndex(Me.Label38, 0)
        Me.Controls.SetChildIndex(Me.num_SYOKYAKU_KEIHI, 0)
        Me.Controls.SetChildIndex(Me.num_KUNI_KOFUKIN, 0)
        Me.Controls.SetChildIndex(Me.Label39, 0)
        Me.Controls.SetChildIndex(Me.Label42, 0)
        Me.Controls.SetChildIndex(Me.num_MARU3_DISP1, 0)
        Me.Controls.SetChildIndex(Me.Label43, 0)
        Me.Controls.SetChildIndex(Me.Label92, 0)
        Me.Controls.SetChildIndex(Me.Label44, 0)
        Me.Controls.SetChildIndex(Me.Label99, 0)
        Me.Controls.SetChildIndex(Me.Label45, 0)
        Me.Controls.SetChildIndex(Me.num_MARU3_DISP2, 0)
        Me.Controls.SetChildIndex(Me.Label46, 0)
        Me.Controls.SetChildIndex(Me.Label47, 0)
        Me.Controls.SetChildIndex(Me.num_KOME3_DISP2, 0)
        Me.Controls.SetChildIndex(Me.Label48, 0)
        Me.Controls.SetChildIndex(Me.num_MARU5, 0)
        Me.Controls.SetChildIndex(Me.num_MARU6, 0)
        Me.Controls.SetChildIndex(Me.Label49, 0)
        Me.Controls.SetChildIndex(Me.lbl_SYORI_JOKYO_KBN_NM, 0)
        Me.Controls.SetChildIndex(Me.Label50, 0)
        Me.Controls.SetChildIndex(Me.Label51, 0)
        Me.Controls.SetChildIndex(Me.lblCOUNT, 0)
        Me.Controls.SetChildIndex(Me.dateSINSEI_DATE, 0)
        Me.Controls.SetChildIndex(Me.Label40, 0)
        Me.Controls.SetChildIndex(Me.Label56, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU07, 0)
        Me.Controls.SetChildIndex(Me.Label55, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU08, 0)
        Me.Controls.SetChildIndex(Me.Label54, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU09, 0)
        Me.Controls.SetChildIndex(Me.Label53, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU10, 0)
        Me.Controls.SetChildIndex(Me.Label52, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU11, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN07, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN08, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN09, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN10, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN11, 0)
        Me.Controls.SetChildIndex(Me.Label108, 0)
        Me.Controls.SetChildIndex(Me.Label110, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_RITU, 0)
        Me.Controls.SetChildIndex(Me.Label112, 0)
        Me.Controls.SetChildIndex(Me.Label113, 0)
        Me.Controls.SetChildIndex(Me.num_GENGAKU_RITU, 0)
        Me.Controls.SetChildIndex(Me.Label89, 0)
        Me.Controls.SetChildIndex(Me.Label58, 0)
        Me.Controls.SetChildIndex(Me.Label59, 0)
        Me.Controls.SetChildIndex(Me.Label60, 0)
        Me.Controls.SetChildIndex(Me.Label61, 0)
        Me.Controls.SetChildIndex(Me.Label62, 0)
        Me.Controls.SetChildIndex(Me.Label63, 0)
        Me.Controls.SetChildIndex(Me.Label64, 0)
        Me.Controls.SetChildIndex(Me.Label65, 0)
        Me.Controls.SetChildIndex(Me.Label66, 0)
        Me.Controls.SetChildIndex(Me.num_MARU2, 0)
        Me.Controls.SetChildIndex(Me.num_KOME3_CALC, 0)
        Me.Controls.SetChildIndex(Me.num_KOME2, 0)
        Me.Controls.SetChildIndex(Me.num_MARU4, 0)
        Me.Controls.SetChildIndex(Me.num_MARU3_CALC, 0)
        Me.Controls.SetChildIndex(Me.num_KOME1, 0)
        Me.Controls.SetChildIndex(Me.num_KOME3_DISP1, 0)
        Me.Controls.SetChildIndex(Me.Label107, 0)
        Me.Controls.SetChildIndex(Me.Label116, 0)
        Me.Controls.SetChildIndex(Me.Label41, 0)
        Me.Controls.SetChildIndex(Me.Label57, 0)
        Me.Controls.SetChildIndex(Me.Label67, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.num_KOFU_HASU01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU00, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_HASSEI_KAISU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN00, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU_NYU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateKOFU_KAKUTEI_Ymd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU_DISP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_TANKA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_MARU1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_MARU2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_SYOKYAKU_KEIHI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KUNI_KOFUKIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOME1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_MARU3_DISP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOME3_CALC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_MARU3_DISP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOME3_DISP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_MARU5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_MARU6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateSINSEI_DATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_GENGAKU_RITU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_MARU4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_RITU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOME2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_MARU3_CALC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOME3_DISP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents GcDateValidator1 As GrapeCity.Win.Editors.GcDateValidator
    Friend WithEvents DropDownButton14 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton15 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton16 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton17 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton18 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton19 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents dgv_Search As JBD.Gjs.Win.DataGridView
    Friend WithEvents cmdDel As JBD.Gjs.Win.JButton
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents Label23 As JBD.Gjs.Win.Label
    Friend WithEvents Label26 As JBD.Gjs.Win.Label
    Friend WithEvents cmdCansel As JBD.Gjs.Win.JButton
    Friend WithEvents lbl_KEIYAKUSYA_CD As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKUSYA_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KI As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_POST As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_1 As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_2 As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_4 As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_3 As JBD.Gjs.Win.JLabel
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_HASU01 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_HASU02 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_HASU04 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_HASU03 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label20 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_HASU06 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label21 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_HASU05 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_HASU00 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents cmdSave As JBD.Gjs.Win.JButton
    Friend WithEvents txt_HASSEI_KAISU As JBD.Gjs.Win.GcTextBox
    Friend WithEvents Label25 As JBD.Gjs.Win.Label
    Friend WithEvents cmdSearch As JBD.Gjs.Win.JButton
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_KIN01 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_KIN02 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_KIN03 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_KIN04 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_KIN05 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_KIN06 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_KIN00 As JBD.Gjs.Win.GcNumber
    Friend WithEvents lbl_NOJO_CD As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_NOJO_NAME As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_TORI_KBN As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_TORI_KBN_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKU_HASU As JBD.Gjs.Win.JLabel
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_HASU_NYU As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents Label30 As JBD.Gjs.Win.Label
    Friend WithEvents Label31 As JBD.Gjs.Win.Label
    Friend WithEvents Label32 As JBD.Gjs.Win.Label
    Friend WithEvents Label33 As JBD.Gjs.Win.Label
    Friend WithEvents Label34 As JBD.Gjs.Win.Label
    Friend WithEvents rbtnSYORI_JOKYO_KBN_3 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtnSYORI_JOKYO_KBN_2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtnSYORI_JOKYO_KBN_1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents dateKOFU_KAKUTEI_Ymd As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label103 As JBD.Gjs.Win.Label
    Friend WithEvents Label87 As JBD.Gjs.Win.Label
    Friend WithEvents Label35 As JBD.Gjs.Win.Label
    Friend WithEvents Label36 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_HASU_DISP As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label95 As JBD.Gjs.Win.Label
    Friend WithEvents Label37 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_TANKA As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label97 As JBD.Gjs.Win.Label
    Friend WithEvents num_MARU1 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents num_MARU2 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label27 As JBD.Gjs.Win.Label
    Friend WithEvents Label28 As JBD.Gjs.Win.Label
    Friend WithEvents Label96 As JBD.Gjs.Win.Label
    Friend WithEvents Label38 As JBD.Gjs.Win.Label
    Friend WithEvents num_SYOKYAKU_KEIHI As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KUNI_KOFUKIN As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label39 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOME1 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label42 As JBD.Gjs.Win.Label
    Friend WithEvents num_MARU3_DISP1 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label43 As JBD.Gjs.Win.Label
    Friend WithEvents Label92 As JBD.Gjs.Win.Label
    Friend WithEvents Label44 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOME3_CALC As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label99 As JBD.Gjs.Win.Label
    Friend WithEvents Label45 As JBD.Gjs.Win.Label
    Friend WithEvents num_MARU3_DISP2 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label46 As JBD.Gjs.Win.Label
    Friend WithEvents Label47 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOME3_DISP2 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label48 As JBD.Gjs.Win.Label
    Friend WithEvents num_MARU5 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_MARU6 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label49 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_SYORI_JOKYO_KBN_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents dateSINSEI_DATE As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton7 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label50 As JBD.Gjs.Win.Label
    Friend WithEvents Label40 As JBD.Gjs.Win.Label
    Friend WithEvents lblCOUNT As JBD.Gjs.Win.Label
    Friend WithEvents Label51 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_KIN11 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_KIN10 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_KIN09 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_KIN08 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_KIN07 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_HASU11 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label52 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_HASU10 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label53 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_HASU09 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label54 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_HASU08 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label55 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_HASU07 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label56 As JBD.Gjs.Win.Label
    Friend WithEvents num_GENGAKU_RITU As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label116 As JBD.Gjs.Win.Label
    Friend WithEvents Label113 As JBD.Gjs.Win.Label
    Friend WithEvents num_MARU4 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label112 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_RITU As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label110 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOME2 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label108 As JBD.Gjs.Win.Label
    Friend WithEvents Label107 As JBD.Gjs.Win.Label
    Friend WithEvents Label58 As JBD.Gjs.Win.Label
    Friend WithEvents num_MARU3_CALC As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label89 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOME3_DISP1 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label59 As JBD.Gjs.Win.Label
    Friend WithEvents Label60 As JBD.Gjs.Win.Label
    Friend WithEvents Label61 As JBD.Gjs.Win.Label
    Friend WithEvents Label62 As JBD.Gjs.Win.Label
    Friend WithEvents Label63 As JBD.Gjs.Win.Label
    Friend WithEvents Label64 As JBD.Gjs.Win.Label
    Friend WithEvents Label65 As JBD.Gjs.Win.Label
    Friend WithEvents Label66 As JBD.Gjs.Win.Label
    Friend WithEvents Label41 As JBD.Gjs.Win.Label
    Friend WithEvents Label57 As JBD.Gjs.Win.Label
    Friend WithEvents Label67 As JBD.Gjs.Win.Label
    Friend WithEvents MEISAI_NO As DataGridViewTextBoxColumn
    Friend WithEvents NOJO_NAME As DataGridViewTextBoxColumn
    Friend WithEvents ADDR As DataGridViewTextBoxColumn
    Friend WithEvents TORI_KBN_NM As DataGridViewTextBoxColumn
    Friend WithEvents KEISAN_KAISU As DataGridViewTextBoxColumn
    Friend WithEvents SYORI_JOKYO_KBN_NM As DataGridViewTextBoxColumn
    Friend WithEvents KOFU_HASU As DataGridViewTextBoxColumn
    Friend WithEvents GENGAKU_RITU As DataGridViewTextBoxColumn
    Friend WithEvents KOFU_KIN As DataGridViewTextBoxColumn
    Friend WithEvents NOJO_CD As DataGridViewTextBoxColumn
    Friend WithEvents TORI_KBN As DataGridViewTextBoxColumn
    Friend WithEvents SYORI_JOKYO_KBN As DataGridViewTextBoxColumn
    Friend WithEvents SEI_TUMITATE_KIN As DataGridViewTextBoxColumn
    Friend WithEvents KUNI_KOFU_KIN As DataGridViewTextBoxColumn
    Friend WithEvents ADDR_POST As DataGridViewTextBoxColumn
    Friend WithEvents ADDR_1 As DataGridViewTextBoxColumn
    Friend WithEvents ADDR_2 As DataGridViewTextBoxColumn
    Friend WithEvents ADDR_3 As DataGridViewTextBoxColumn
    Friend WithEvents ADDR_4 As DataGridViewTextBoxColumn
    Friend WithEvents KI As DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKUSYA_CD As DataGridViewTextBoxColumn
    Friend WithEvents HASSEI_KAISU As DataGridViewTextBoxColumn
    Friend WithEvents KEIYAKU_HASU As DataGridViewTextBoxColumn
    Friend WithEvents KOFU_RITU As DataGridViewTextBoxColumn
End Class
