Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGJ4012
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
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim NumberSignDisplayField1 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField1 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField1 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField1 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim NumberSignDisplayField2 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField2 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField2 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField2 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess1 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange1 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField3 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField3 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField3 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField3 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim NumberSignDisplayField4 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField4 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField4 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField4 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim NumberSignDisplayField5 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField5 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField5 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField5 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess2 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange2 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField6 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField6 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField6 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField6 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim NumberSignDisplayField7 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField7 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField7 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField7 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim NumberSignDisplayField8 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField8 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField8 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField8 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess3 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange3 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField9 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField9 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField9 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField9 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim NumberSignDisplayField10 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField10 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField10 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField10 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim NumberSignDisplayField11 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField11 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField11 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField11 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess4 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange4 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim ValueProcess5 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange5 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberIntegerPartDisplayField12 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField13 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField14 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField15 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField16 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField17 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim DateEraField1 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField1 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField1 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField3 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField1 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim NumberSignDisplayField12 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField18 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField12 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField12 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess6 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange6 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberIntegerPartDisplayField19 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberSignDisplayField13 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField20 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField13 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField13 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim NumberIntegerPartDisplayField21 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField22 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField23 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField24 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberIntegerPartDisplayField25 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess7 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange7 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.num_KOYO_JOGEN = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOYO_ROTIN = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOYO_KOYO = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOYO_HOSEI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_JIDAI_HOSEI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_JIDAI_JIDAI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_JIDAI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_JIDAI_JOGEN = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_GENKA_SYOKYAKU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_GENKA_JOGEN = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KUSYA = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOYO_HOSEI_1 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_JIDAI_HOSEI_2 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_SONOTA_KOTEIHI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_KIN_TANKA_BET2 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_TANKA = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_HASU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOME1HIKU2_CALC = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOME1HIKU2_DISP = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_MARU3 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_TANKA_SAISYU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOME1_CALC = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOME3_CALC = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOME3_DISP2 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.dateKOFU_KAKUTEI_Ymd = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.num_KUSYA_KIKAN = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_MARU2 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_Syokei5 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_KIN_TANKA_SANTEI8 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOME1_DISP = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOME2 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOME3_DISP1 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_KOFU_RITU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_MARU1 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.num_GENGAKU_RITU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.DropDownButton14 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton15 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton16 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton17 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton18 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton19 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label23 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label26 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdCansel = New JBD.Gjs.Win.JButton(Me.components)
        Me.lbl_KEIYAKUSYA_CD = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKUSYA_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_1 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_2 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_4 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_ADDR_3 = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.lbl_NOJO_CD = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_NOJO_NAME = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_TORI_KBN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_TORI_KBN_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.lbl_KEIYAKU_HASU = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_KEIYAKU_KBN = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label29 = New JBD.Gjs.Win.Label(Me.components)
        Me.lbl_KEIYAKU_KBN_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label30 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label20 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label32 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label33 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label34 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label35 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label36 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label37 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label38 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label31 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label41 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label42 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label43 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label44 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label45 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label46 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label47 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label48 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label49 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label50 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label51 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label52 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label53 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label54 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label55 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label56 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label57 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label58 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label59 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label60 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label61 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label62 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label63 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label64 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label65 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label66 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label67 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label39 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label70 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label69 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label71 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label72 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label73 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label74 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label75 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label76 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label77 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label78 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label79 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label80 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label81 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label82 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label83 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label84 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label85 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label86 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label27 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label28 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label87 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label88 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label89 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label90 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label91 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label93 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label94 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label95 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label96 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label97 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label98 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label99 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label100 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label101 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label102 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label103 = New JBD.Gjs.Win.Label(Me.components)
        Me.rbtnSYORI_JOKYO_KBN_1 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtnSYORI_JOKYO_KBN_2 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.rbtnSYORI_JOKYO_KBN_3 = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.lbl_SYORI_JOKYO_KBN_NM = New JBD.Gjs.Win.JLabel(Me.components)
        Me.Label40 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label68 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label104 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label105 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label106 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label107 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label108 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label109 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label110 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label112 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label113 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label114 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label115 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label111 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label92 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label116 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.num_KOYO_JOGEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOYO_ROTIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOYO_KOYO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOYO_HOSEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_JIDAI_HOSEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_JIDAI_JIDAI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_JIDAI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_JIDAI_JOGEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_GENKA_SYOKYAKU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_GENKA_JOGEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KUSYA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOYO_HOSEI_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_JIDAI_HOSEI_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_SONOTA_KOTEIHI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN_TANKA_BET2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_TANKA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_HASU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOME1HIKU2_CALC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOME1HIKU2_DISP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_MARU3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_TANKA_SAISYU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOME1_CALC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOME3_CALC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOME3_DISP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateKOFU_KAKUTEI_Ymd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KUSYA_KIKAN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_MARU2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_Syokei5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_KIN_TANKA_SANTEI8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOME1_DISP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOME2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOME3_DISP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_KOFU_RITU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_MARU1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num_GENGAKU_RITU, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'num_KOYO_JOGEN
        '
        Me.num_KOYO_JOGEN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOYO_JOGEN.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOYO_JOGEN.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOYO_JOGEN.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField1.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField1.MaxDigits = 5
        NumberDecimalPartDisplayField1.MinDigits = 5
        Me.num_KOYO_JOGEN.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField1, NumberIntegerPartDisplayField1, NumberDecimalSeparatorDisplayField1, NumberDecimalPartDisplayField1})
        Me.num_KOYO_JOGEN.DropDown.AllowDrop = False
        Me.num_KOYO_JOGEN.Enabled = False
        Me.num_KOYO_JOGEN.Fields.DecimalPart.MaxDigits = 5
        Me.num_KOYO_JOGEN.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOYO_JOGEN.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOYO_JOGEN.Fields.IntegerPart.MinDigits = 1
        Me.num_KOYO_JOGEN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOYO_JOGEN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOYO_JOGEN.HighlightText = True
        Me.num_KOYO_JOGEN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOYO_JOGEN.Location = New System.Drawing.Point(226, 309)
        Me.num_KOYO_JOGEN.Name = "num_KOYO_JOGEN"
        Me.num_KOYO_JOGEN.NegativeColor = System.Drawing.Color.Black
        Me.num_KOYO_JOGEN.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOYO_JOGEN, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOYO_JOGEN, Object), CType(Me.num_KOYO_JOGEN, Object), CType(Me.num_KOYO_JOGEN, Object), CType(Me.num_KOYO_JOGEN, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOYO_JOGEN.Size = New System.Drawing.Size(166, 20)
        Me.num_KOYO_JOGEN.Spin.Increment = 0
        Me.num_KOYO_JOGEN.TabIndex = 1136
        Me.num_KOYO_JOGEN.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_KOYO_JOGEN.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOYO_ROTIN
        '
        Me.num_KOYO_ROTIN.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.num_KOYO_ROTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOYO_ROTIN.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOYO_ROTIN.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOYO_ROTIN.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField2.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField2.MaxDigits = 5
        NumberDecimalPartDisplayField2.MinDigits = 5
        Me.num_KOYO_ROTIN.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField2, NumberIntegerPartDisplayField2, NumberDecimalSeparatorDisplayField2, NumberDecimalPartDisplayField2})
        Me.num_KOYO_ROTIN.DropDown.AllowDrop = False
        Me.num_KOYO_ROTIN.Fields.DecimalPart.MaxDigits = 5
        Me.num_KOYO_ROTIN.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOYO_ROTIN.Fields.IntegerPart.MaxDigits = 4
        Me.num_KOYO_ROTIN.Fields.IntegerPart.MinDigits = 1
        Me.num_KOYO_ROTIN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOYO_ROTIN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOYO_ROTIN.HighlightText = True
        Me.num_KOYO_ROTIN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOYO_ROTIN.Location = New System.Drawing.Point(418, 309)
        Me.num_KOYO_ROTIN.Name = "num_KOYO_ROTIN"
        Me.num_KOYO_ROTIN.NegativeColor = System.Drawing.Color.Black
        Me.num_KOYO_ROTIN.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOYO_ROTIN, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOYO_ROTIN, Object), CType(Me.num_KOYO_ROTIN, Object), CType(Me.num_KOYO_ROTIN, Object), CType(Me.num_KOYO_ROTIN, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOYO_ROTIN.Size = New System.Drawing.Size(166, 20)
        Me.num_KOYO_ROTIN.Spin.Increment = 0
        Me.num_KOYO_ROTIN.TabIndex = 1
        ValueProcess1.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_KOYO_ROTIN).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess1})
        InvalidRange1.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange1.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.num_KOYO_ROTIN).AddRange(New Object() {InvalidRange1})
        Me.num_KOYO_ROTIN.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_KOYO_ROTIN.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOYO_KOYO
        '
        Me.num_KOYO_KOYO.BackColor = System.Drawing.Color.White
        Me.num_KOYO_KOYO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOYO_KOYO.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOYO_KOYO.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOYO_KOYO.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField3.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField3.MaxDigits = 5
        NumberDecimalPartDisplayField3.MinDigits = 5
        Me.num_KOYO_KOYO.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField3, NumberIntegerPartDisplayField3, NumberDecimalSeparatorDisplayField3, NumberDecimalPartDisplayField3})
        Me.num_KOYO_KOYO.DropDown.AllowDrop = False
        Me.num_KOYO_KOYO.Enabled = False
        Me.num_KOYO_KOYO.Fields.DecimalPart.MaxDigits = 5
        Me.num_KOYO_KOYO.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOYO_KOYO.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOYO_KOYO.Fields.IntegerPart.MinDigits = 1
        Me.num_KOYO_KOYO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOYO_KOYO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOYO_KOYO.HighlightText = True
        Me.num_KOYO_KOYO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOYO_KOYO.Location = New System.Drawing.Point(610, 309)
        Me.num_KOYO_KOYO.Name = "num_KOYO_KOYO"
        Me.num_KOYO_KOYO.NegativeColor = System.Drawing.Color.Black
        Me.num_KOYO_KOYO.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOYO_KOYO, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOYO_KOYO, Object), CType(Me.num_KOYO_KOYO, Object), CType(Me.num_KOYO_KOYO, Object), CType(Me.num_KOYO_KOYO, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOYO_KOYO.Size = New System.Drawing.Size(166, 20)
        Me.num_KOYO_KOYO.Spin.Increment = 0
        Me.num_KOYO_KOYO.TabIndex = 1148
        Me.num_KOYO_KOYO.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_KOYO_KOYO.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOYO_HOSEI
        '
        Me.num_KOYO_HOSEI.BackColor = System.Drawing.Color.White
        Me.num_KOYO_HOSEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOYO_HOSEI.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOYO_HOSEI.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOYO_HOSEI.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOYO_HOSEI.DropDown.AllowDrop = False
        Me.num_KOYO_HOSEI.Enabled = False
        Me.num_KOYO_HOSEI.Fields.DecimalPart.MaxDigits = 2
        Me.num_KOYO_HOSEI.Fields.DecimalPart.MinDigits = 2
        Me.num_KOYO_HOSEI.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOYO_HOSEI.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOYO_HOSEI.Fields.IntegerPart.MinDigits = 1
        Me.num_KOYO_HOSEI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOYO_HOSEI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOYO_HOSEI.HighlightText = True
        Me.num_KOYO_HOSEI.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOYO_HOSEI.Location = New System.Drawing.Point(804, 309)
        Me.num_KOYO_HOSEI.Name = "num_KOYO_HOSEI"
        Me.num_KOYO_HOSEI.NegativeColor = System.Drawing.Color.Black
        Me.num_KOYO_HOSEI.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOYO_HOSEI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOYO_HOSEI, Object), CType(Me.num_KOYO_HOSEI, Object), CType(Me.num_KOYO_HOSEI, Object), CType(Me.num_KOYO_HOSEI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOYO_HOSEI.Size = New System.Drawing.Size(123, 20)
        Me.num_KOYO_HOSEI.Spin.Increment = 0
        Me.num_KOYO_HOSEI.TabIndex = 1154
        Me.num_KOYO_HOSEI.Value = New Decimal(New Integer() {999999, 0, 0, 131072})
        Me.num_KOYO_HOSEI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_JIDAI_HOSEI
        '
        Me.num_JIDAI_HOSEI.BackColor = System.Drawing.Color.White
        Me.num_JIDAI_HOSEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_JIDAI_HOSEI.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_JIDAI_HOSEI.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_JIDAI_HOSEI.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_JIDAI_HOSEI.DropDown.AllowDrop = False
        Me.num_JIDAI_HOSEI.Enabled = False
        Me.num_JIDAI_HOSEI.Fields.DecimalPart.MaxDigits = 2
        Me.num_JIDAI_HOSEI.Fields.DecimalPart.MinDigits = 2
        Me.num_JIDAI_HOSEI.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_JIDAI_HOSEI.Fields.IntegerPart.MaxDigits = 8
        Me.num_JIDAI_HOSEI.Fields.IntegerPart.MinDigits = 1
        Me.num_JIDAI_HOSEI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_JIDAI_HOSEI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_JIDAI_HOSEI.HighlightText = True
        Me.num_JIDAI_HOSEI.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_JIDAI_HOSEI.Location = New System.Drawing.Point(804, 347)
        Me.num_JIDAI_HOSEI.Name = "num_JIDAI_HOSEI"
        Me.num_JIDAI_HOSEI.NegativeColor = System.Drawing.Color.Black
        Me.num_JIDAI_HOSEI.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_JIDAI_HOSEI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_JIDAI_HOSEI, Object), CType(Me.num_JIDAI_HOSEI, Object), CType(Me.num_JIDAI_HOSEI, Object), CType(Me.num_JIDAI_HOSEI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_JIDAI_HOSEI.Size = New System.Drawing.Size(123, 20)
        Me.num_JIDAI_HOSEI.Spin.Increment = 0
        Me.num_JIDAI_HOSEI.TabIndex = 1169
        Me.num_JIDAI_HOSEI.Value = New Decimal(New Integer() {999999, 0, 0, 131072})
        Me.num_JIDAI_HOSEI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_JIDAI_JIDAI
        '
        Me.num_JIDAI_JIDAI.BackColor = System.Drawing.Color.White
        Me.num_JIDAI_JIDAI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_JIDAI_JIDAI.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_JIDAI_JIDAI.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_JIDAI_JIDAI.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField4.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField4.MaxDigits = 5
        NumberDecimalPartDisplayField4.MinDigits = 5
        Me.num_JIDAI_JIDAI.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField4, NumberIntegerPartDisplayField4, NumberDecimalSeparatorDisplayField4, NumberDecimalPartDisplayField4})
        Me.num_JIDAI_JIDAI.DropDown.AllowDrop = False
        Me.num_JIDAI_JIDAI.Enabled = False
        Me.num_JIDAI_JIDAI.Fields.DecimalPart.MaxDigits = 5
        Me.num_JIDAI_JIDAI.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_JIDAI_JIDAI.Fields.IntegerPart.MaxDigits = 8
        Me.num_JIDAI_JIDAI.Fields.IntegerPart.MinDigits = 1
        Me.num_JIDAI_JIDAI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_JIDAI_JIDAI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_JIDAI_JIDAI.HighlightText = True
        Me.num_JIDAI_JIDAI.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_JIDAI_JIDAI.Location = New System.Drawing.Point(610, 347)
        Me.num_JIDAI_JIDAI.Name = "num_JIDAI_JIDAI"
        Me.num_JIDAI_JIDAI.NegativeColor = System.Drawing.Color.Black
        Me.num_JIDAI_JIDAI.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_JIDAI_JIDAI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_JIDAI_JIDAI, Object), CType(Me.num_JIDAI_JIDAI, Object), CType(Me.num_JIDAI_JIDAI, Object), CType(Me.num_JIDAI_JIDAI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_JIDAI_JIDAI.Size = New System.Drawing.Size(166, 20)
        Me.num_JIDAI_JIDAI.Spin.Increment = 0
        Me.num_JIDAI_JIDAI.TabIndex = 1165
        Me.num_JIDAI_JIDAI.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_JIDAI_JIDAI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_JIDAI
        '
        Me.num_JIDAI.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.num_JIDAI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_JIDAI.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_JIDAI.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_JIDAI.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField5.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField5.MaxDigits = 5
        NumberDecimalPartDisplayField5.MinDigits = 5
        Me.num_JIDAI.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField5, NumberIntegerPartDisplayField5, NumberDecimalSeparatorDisplayField5, NumberDecimalPartDisplayField5})
        Me.num_JIDAI.DropDown.AllowDrop = False
        Me.num_JIDAI.Fields.DecimalPart.MaxDigits = 5
        Me.num_JIDAI.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_JIDAI.Fields.IntegerPart.MaxDigits = 4
        Me.num_JIDAI.Fields.IntegerPart.MinDigits = 1
        Me.num_JIDAI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_JIDAI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_JIDAI.HighlightText = True
        Me.num_JIDAI.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_JIDAI.Location = New System.Drawing.Point(418, 347)
        Me.num_JIDAI.Name = "num_JIDAI"
        Me.num_JIDAI.NegativeColor = System.Drawing.Color.Black
        Me.num_JIDAI.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_JIDAI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_JIDAI, Object), CType(Me.num_JIDAI, Object), CType(Me.num_JIDAI, Object), CType(Me.num_JIDAI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_JIDAI.Size = New System.Drawing.Size(166, 20)
        Me.num_JIDAI.Spin.Increment = 0
        Me.num_JIDAI.TabIndex = 2
        ValueProcess2.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_JIDAI).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess2})
        InvalidRange2.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange2.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.num_JIDAI).AddRange(New Object() {InvalidRange2})
        Me.num_JIDAI.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_JIDAI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_JIDAI_JOGEN
        '
        Me.num_JIDAI_JOGEN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_JIDAI_JOGEN.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_JIDAI_JOGEN.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_JIDAI_JOGEN.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField6.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField6.MaxDigits = 5
        NumberDecimalPartDisplayField6.MinDigits = 5
        Me.num_JIDAI_JOGEN.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField6, NumberIntegerPartDisplayField6, NumberDecimalSeparatorDisplayField6, NumberDecimalPartDisplayField6})
        Me.num_JIDAI_JOGEN.DropDown.AllowDrop = False
        Me.num_JIDAI_JOGEN.Enabled = False
        Me.num_JIDAI_JOGEN.Fields.DecimalPart.MaxDigits = 5
        Me.num_JIDAI_JOGEN.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_JIDAI_JOGEN.Fields.IntegerPart.MaxDigits = 8
        Me.num_JIDAI_JOGEN.Fields.IntegerPart.MinDigits = 1
        Me.num_JIDAI_JOGEN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_JIDAI_JOGEN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_JIDAI_JOGEN.HighlightText = True
        Me.num_JIDAI_JOGEN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_JIDAI_JOGEN.Location = New System.Drawing.Point(226, 347)
        Me.num_JIDAI_JOGEN.Name = "num_JIDAI_JOGEN"
        Me.num_JIDAI_JOGEN.NegativeColor = System.Drawing.Color.Black
        Me.num_JIDAI_JOGEN.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_JIDAI_JOGEN, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_JIDAI_JOGEN, Object), CType(Me.num_JIDAI_JOGEN, Object), CType(Me.num_JIDAI_JOGEN, Object), CType(Me.num_JIDAI_JOGEN, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_JIDAI_JOGEN.Size = New System.Drawing.Size(166, 20)
        Me.num_JIDAI_JOGEN.Spin.Increment = 0
        Me.num_JIDAI_JOGEN.TabIndex = 1157
        Me.num_JIDAI_JOGEN.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_JIDAI_JOGEN.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_GENKA_SYOKYAKU_GENKA_HOSEI
        '
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.BackColor = System.Drawing.Color.White
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.DropDown.AllowDrop = False
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.Enabled = False
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.Fields.DecimalPart.MaxDigits = 2
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.Fields.DecimalPart.MinDigits = 2
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.Fields.IntegerPart.MaxDigits = 8
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.Fields.IntegerPart.MinDigits = 1
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.HighlightText = True
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.Location = New System.Drawing.Point(804, 385)
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.Name = "num_GENKA_SYOKYAKU_GENKA_HOSEI"
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.NegativeColor = System.Drawing.Color.Black
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI, Object), CType(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI, Object), CType(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI, Object), CType(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.Size = New System.Drawing.Size(123, 20)
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.Spin.Increment = 0
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.TabIndex = 1184
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.Value = New Decimal(New Integer() {999999, 0, 0, 131072})
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_GENKA_SYOKYAKU_GENKA_SYOKYAKU
        '
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.BackColor = System.Drawing.Color.White
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField7.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField7.MaxDigits = 5
        NumberDecimalPartDisplayField7.MinDigits = 5
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField7, NumberIntegerPartDisplayField7, NumberDecimalSeparatorDisplayField7, NumberDecimalPartDisplayField7})
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.DropDown.AllowDrop = False
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Enabled = False
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Fields.DecimalPart.MaxDigits = 5
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Fields.IntegerPart.MaxDigits = 8
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Fields.IntegerPart.MinDigits = 1
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.HighlightText = True
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Location = New System.Drawing.Point(610, 385)
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Name = "num_GENKA_SYOKYAKU_GENKA_SYOKYAKU"
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.NegativeColor = System.Drawing.Color.Black
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU, Object), CType(Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU, Object), CType(Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU, Object), CType(Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Size = New System.Drawing.Size(166, 20)
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Spin.Increment = 0
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.TabIndex = 1180
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_GENKA_SYOKYAKU
        '
        Me.num_GENKA_SYOKYAKU.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.num_GENKA_SYOKYAKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_GENKA_SYOKYAKU.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_GENKA_SYOKYAKU.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_GENKA_SYOKYAKU.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField8.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField8.MaxDigits = 5
        NumberDecimalPartDisplayField8.MinDigits = 5
        Me.num_GENKA_SYOKYAKU.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField8, NumberIntegerPartDisplayField8, NumberDecimalSeparatorDisplayField8, NumberDecimalPartDisplayField8})
        Me.num_GENKA_SYOKYAKU.DropDown.AllowDrop = False
        Me.num_GENKA_SYOKYAKU.Fields.DecimalPart.MaxDigits = 5
        Me.num_GENKA_SYOKYAKU.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_GENKA_SYOKYAKU.Fields.IntegerPart.MaxDigits = 4
        Me.num_GENKA_SYOKYAKU.Fields.IntegerPart.MinDigits = 1
        Me.num_GENKA_SYOKYAKU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_GENKA_SYOKYAKU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_GENKA_SYOKYAKU.HighlightText = True
        Me.num_GENKA_SYOKYAKU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_GENKA_SYOKYAKU.Location = New System.Drawing.Point(418, 385)
        Me.num_GENKA_SYOKYAKU.Name = "num_GENKA_SYOKYAKU"
        Me.num_GENKA_SYOKYAKU.NegativeColor = System.Drawing.Color.Black
        Me.num_GENKA_SYOKYAKU.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_GENKA_SYOKYAKU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_GENKA_SYOKYAKU, Object), CType(Me.num_GENKA_SYOKYAKU, Object), CType(Me.num_GENKA_SYOKYAKU, Object), CType(Me.num_GENKA_SYOKYAKU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_GENKA_SYOKYAKU.Size = New System.Drawing.Size(166, 20)
        Me.num_GENKA_SYOKYAKU.Spin.Increment = 0
        Me.num_GENKA_SYOKYAKU.TabIndex = 3
        ValueProcess3.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_GENKA_SYOKYAKU).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess3})
        InvalidRange3.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange3.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.num_GENKA_SYOKYAKU).AddRange(New Object() {InvalidRange3})
        Me.num_GENKA_SYOKYAKU.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_GENKA_SYOKYAKU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_GENKA_JOGEN
        '
        Me.num_GENKA_JOGEN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_GENKA_JOGEN.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_GENKA_JOGEN.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_GENKA_JOGEN.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField9.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField9.MaxDigits = 5
        NumberDecimalPartDisplayField9.MinDigits = 5
        Me.num_GENKA_JOGEN.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField9, NumberIntegerPartDisplayField9, NumberDecimalSeparatorDisplayField9, NumberDecimalPartDisplayField9})
        Me.num_GENKA_JOGEN.DropDown.AllowDrop = False
        Me.num_GENKA_JOGEN.Enabled = False
        Me.num_GENKA_JOGEN.Fields.DecimalPart.MaxDigits = 5
        Me.num_GENKA_JOGEN.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_GENKA_JOGEN.Fields.IntegerPart.MaxDigits = 8
        Me.num_GENKA_JOGEN.Fields.IntegerPart.MinDigits = 1
        Me.num_GENKA_JOGEN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_GENKA_JOGEN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_GENKA_JOGEN.HighlightText = True
        Me.num_GENKA_JOGEN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_GENKA_JOGEN.Location = New System.Drawing.Point(226, 385)
        Me.num_GENKA_JOGEN.Name = "num_GENKA_JOGEN"
        Me.num_GENKA_JOGEN.NegativeColor = System.Drawing.Color.Black
        Me.num_GENKA_JOGEN.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_GENKA_JOGEN, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_GENKA_JOGEN, Object), CType(Me.num_GENKA_JOGEN, Object), CType(Me.num_GENKA_JOGEN, Object), CType(Me.num_GENKA_JOGEN, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_GENKA_JOGEN.Size = New System.Drawing.Size(166, 20)
        Me.num_GENKA_JOGEN.Spin.Increment = 0
        Me.num_GENKA_JOGEN.TabIndex = 1172
        Me.num_GENKA_JOGEN.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_GENKA_JOGEN.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KUSYA
        '
        Me.num_KUSYA.BackColor = System.Drawing.Color.White
        Me.num_KUSYA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KUSYA.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KUSYA.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KUSYA.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField10.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField10.MaxDigits = 5
        NumberDecimalPartDisplayField10.MinDigits = 5
        Me.num_KUSYA.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField10, NumberIntegerPartDisplayField10, NumberDecimalSeparatorDisplayField10, NumberDecimalPartDisplayField10})
        Me.num_KUSYA.DropDown.AllowDrop = False
        Me.num_KUSYA.Enabled = False
        Me.num_KUSYA.Fields.DecimalPart.MaxDigits = 5
        Me.num_KUSYA.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KUSYA.Fields.IntegerPart.MaxDigits = 8
        Me.num_KUSYA.Fields.IntegerPart.MinDigits = 1
        Me.num_KUSYA.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KUSYA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KUSYA.HighlightText = True
        Me.num_KUSYA.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KUSYA.Location = New System.Drawing.Point(610, 443)
        Me.num_KUSYA.Name = "num_KUSYA"
        Me.num_KUSYA.NegativeColor = System.Drawing.Color.Black
        Me.num_KUSYA.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KUSYA, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KUSYA, Object), CType(Me.num_KUSYA, Object), CType(Me.num_KUSYA, Object), CType(Me.num_KUSYA, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KUSYA.Size = New System.Drawing.Size(166, 20)
        Me.num_KUSYA.Spin.Increment = 0
        Me.num_KUSYA.TabIndex = 1190
        Me.num_KUSYA.Value = New Decimal(New Integer() {99, 0, 0, 0})
        Me.num_KUSYA.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOYO_HOSEI_1
        '
        Me.num_KOYO_HOSEI_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOYO_HOSEI_1.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOYO_HOSEI_1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOYO_HOSEI_1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOYO_HOSEI_1.DropDown.AllowDrop = False
        Me.num_KOYO_HOSEI_1.Enabled = False
        Me.num_KOYO_HOSEI_1.Fields.DecimalPart.MaxDigits = 2
        Me.num_KOYO_HOSEI_1.Fields.DecimalPart.MinDigits = 2
        Me.num_KOYO_HOSEI_1.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOYO_HOSEI_1.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOYO_HOSEI_1.Fields.IntegerPart.MinDigits = 1
        Me.num_KOYO_HOSEI_1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOYO_HOSEI_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOYO_HOSEI_1.HighlightText = True
        Me.num_KOYO_HOSEI_1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOYO_HOSEI_1.Location = New System.Drawing.Point(226, 481)
        Me.num_KOYO_HOSEI_1.Name = "num_KOYO_HOSEI_1"
        Me.num_KOYO_HOSEI_1.NegativeColor = System.Drawing.Color.Black
        Me.num_KOYO_HOSEI_1.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOYO_HOSEI_1, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOYO_HOSEI_1, Object), CType(Me.num_KOYO_HOSEI_1, Object), CType(Me.num_KOYO_HOSEI_1, Object), CType(Me.num_KOYO_HOSEI_1, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOYO_HOSEI_1.Size = New System.Drawing.Size(100, 20)
        Me.num_KOYO_HOSEI_1.Spin.Increment = 0
        Me.num_KOYO_HOSEI_1.TabIndex = 1198
        Me.num_KOYO_HOSEI_1.Value = New Decimal(New Integer() {999900, 0, 0, 131072})
        Me.num_KOYO_HOSEI_1.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_JIDAI_HOSEI_2
        '
        Me.num_JIDAI_HOSEI_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_JIDAI_HOSEI_2.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_JIDAI_HOSEI_2.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_JIDAI_HOSEI_2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_JIDAI_HOSEI_2.DropDown.AllowDrop = False
        Me.num_JIDAI_HOSEI_2.Enabled = False
        Me.num_JIDAI_HOSEI_2.Fields.DecimalPart.MaxDigits = 2
        Me.num_JIDAI_HOSEI_2.Fields.DecimalPart.MinDigits = 2
        Me.num_JIDAI_HOSEI_2.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_JIDAI_HOSEI_2.Fields.IntegerPart.MaxDigits = 8
        Me.num_JIDAI_HOSEI_2.Fields.IntegerPart.MinDigits = 1
        Me.num_JIDAI_HOSEI_2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_JIDAI_HOSEI_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_JIDAI_HOSEI_2.HighlightText = True
        Me.num_JIDAI_HOSEI_2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_JIDAI_HOSEI_2.Location = New System.Drawing.Point(354, 481)
        Me.num_JIDAI_HOSEI_2.Name = "num_JIDAI_HOSEI_2"
        Me.num_JIDAI_HOSEI_2.NegativeColor = System.Drawing.Color.Black
        Me.num_JIDAI_HOSEI_2.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_JIDAI_HOSEI_2, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_JIDAI_HOSEI_2, Object), CType(Me.num_JIDAI_HOSEI_2, Object), CType(Me.num_JIDAI_HOSEI_2, Object), CType(Me.num_JIDAI_HOSEI_2, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_JIDAI_HOSEI_2.Size = New System.Drawing.Size(100, 20)
        Me.num_JIDAI_HOSEI_2.Spin.Increment = 0
        Me.num_JIDAI_HOSEI_2.TabIndex = 1206
        Me.num_JIDAI_HOSEI_2.Value = New Decimal(New Integer() {999900, 0, 0, 131072})
        Me.num_JIDAI_HOSEI_2.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_GENKA_SYOKYAKU_GENKA_HOSEI_3
        '
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.DropDown.AllowDrop = False
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Enabled = False
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Fields.DecimalPart.MaxDigits = 2
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Fields.DecimalPart.MinDigits = 2
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Fields.IntegerPart.MaxDigits = 8
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Fields.IntegerPart.MinDigits = 1
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.HighlightText = True
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Location = New System.Drawing.Point(482, 481)
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Name = "num_GENKA_SYOKYAKU_GENKA_HOSEI_3"
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.NegativeColor = System.Drawing.Color.Black
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3, Object), CType(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3, Object), CType(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3, Object), CType(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Size = New System.Drawing.Size(100, 20)
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Spin.Increment = 0
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.TabIndex = 1208
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.Value = New Decimal(New Integer() {999900, 0, 0, 131072})
        Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_SONOTA_KOTEIHI
        '
        Me.num_SONOTA_KOTEIHI.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.num_SONOTA_KOTEIHI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_SONOTA_KOTEIHI.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_SONOTA_KOTEIHI.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_SONOTA_KOTEIHI.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField11.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField11.MaxDigits = 5
        NumberDecimalPartDisplayField11.MinDigits = 5
        Me.num_SONOTA_KOTEIHI.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField11, NumberIntegerPartDisplayField11, NumberDecimalSeparatorDisplayField11, NumberDecimalPartDisplayField11})
        Me.num_SONOTA_KOTEIHI.DropDown.AllowDrop = False
        Me.num_SONOTA_KOTEIHI.Fields.DecimalPart.MaxDigits = 5
        Me.num_SONOTA_KOTEIHI.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_SONOTA_KOTEIHI.Fields.IntegerPart.MaxDigits = 4
        Me.num_SONOTA_KOTEIHI.Fields.IntegerPart.MinDigits = 1
        Me.num_SONOTA_KOTEIHI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_SONOTA_KOTEIHI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_SONOTA_KOTEIHI.HighlightText = True
        Me.num_SONOTA_KOTEIHI.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_SONOTA_KOTEIHI.Location = New System.Drawing.Point(610, 481)
        Me.num_SONOTA_KOTEIHI.Name = "num_SONOTA_KOTEIHI"
        Me.num_SONOTA_KOTEIHI.NegativeColor = System.Drawing.Color.Black
        Me.num_SONOTA_KOTEIHI.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_SONOTA_KOTEIHI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_SONOTA_KOTEIHI, Object), CType(Me.num_SONOTA_KOTEIHI, Object), CType(Me.num_SONOTA_KOTEIHI, Object), CType(Me.num_SONOTA_KOTEIHI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_SONOTA_KOTEIHI.Size = New System.Drawing.Size(166, 20)
        Me.num_SONOTA_KOTEIHI.Spin.Increment = 0
        Me.num_SONOTA_KOTEIHI.TabIndex = 5
        ValueProcess4.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_SONOTA_KOTEIHI).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess4})
        InvalidRange4.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange4.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.num_SONOTA_KOTEIHI).AddRange(New Object() {InvalidRange4})
        Me.num_SONOTA_KOTEIHI.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_SONOTA_KOTEIHI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_KIN_TANKA_BET2
        '
        Me.num_KOFU_KIN_TANKA_BET2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN_TANKA_BET2.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOFU_KIN_TANKA_BET2.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN_TANKA_BET2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_KIN_TANKA_BET2.DropDown.AllowDrop = False
        Me.num_KOFU_KIN_TANKA_BET2.Enabled = False
        Me.num_KOFU_KIN_TANKA_BET2.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN_TANKA_BET2.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN_TANKA_BET2.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_KIN_TANKA_BET2.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN_TANKA_BET2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN_TANKA_BET2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN_TANKA_BET2.HighlightText = True
        Me.num_KOFU_KIN_TANKA_BET2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN_TANKA_BET2.Location = New System.Drawing.Point(226, 519)
        Me.num_KOFU_KIN_TANKA_BET2.Name = "num_KOFU_KIN_TANKA_BET2"
        Me.num_KOFU_KIN_TANKA_BET2.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN_TANKA_BET2.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN_TANKA_BET2, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN_TANKA_BET2, Object), CType(Me.num_KOFU_KIN_TANKA_BET2, Object), CType(Me.num_KOFU_KIN_TANKA_BET2, Object), CType(Me.num_KOFU_KIN_TANKA_BET2, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN_TANKA_BET2.Size = New System.Drawing.Size(195, 20)
        Me.num_KOFU_KIN_TANKA_BET2.Spin.Increment = 0
        Me.num_KOFU_KIN_TANKA_BET2.TabIndex = 1223
        Me.num_KOFU_KIN_TANKA_BET2.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_KOFU_KIN_TANKA_BET2.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_KIN_TANKA_SANTEI_JOGEN
        '
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.DropDown.AllowDrop = False
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.Enabled = False
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.Fields.IntegerPart.MaxDigits = 9
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.HighlightText = True
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.Location = New System.Drawing.Point(417, 519)
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.Name = "num_KOFU_KIN_TANKA_SANTEI_JOGEN"
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN, Object), CType(Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN, Object), CType(Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN, Object), CType(Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.Size = New System.Drawing.Size(195, 20)
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.Spin.Increment = 0
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.TabIndex = 1224
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_TANKA
        '
        Me.num_KOFU_TANKA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_TANKA.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOFU_TANKA.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_TANKA.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_TANKA.DropDown.AllowDrop = False
        Me.num_KOFU_TANKA.Enabled = False
        Me.num_KOFU_TANKA.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_TANKA.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_TANKA.Fields.IntegerPart.MaxDigits = 8
        Me.num_KOFU_TANKA.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_TANKA.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_TANKA.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_TANKA.HighlightText = True
        Me.num_KOFU_TANKA.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_TANKA.Location = New System.Drawing.Point(610, 519)
        Me.num_KOFU_TANKA.Name = "num_KOFU_TANKA"
        Me.num_KOFU_TANKA.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_TANKA.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_TANKA, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_TANKA, Object), CType(Me.num_KOFU_TANKA, Object), CType(Me.num_KOFU_TANKA, Object), CType(Me.num_KOFU_TANKA, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_TANKA.Size = New System.Drawing.Size(195, 20)
        Me.num_KOFU_TANKA.Spin.Increment = 0
        Me.num_KOFU_TANKA.TabIndex = 1225
        Me.num_KOFU_TANKA.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_KOFU_TANKA.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_HASU
        '
        Me.num_KOFU_HASU.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.num_KOFU_HASU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_HASU.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOFU_HASU.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_HASU.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_HASU.DropDown.AllowDrop = False
        Me.num_KOFU_HASU.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_HASU.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_HASU.Fields.IntegerPart.MaxDigits = 7
        Me.num_KOFU_HASU.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_HASU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_HASU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_HASU.HighlightText = True
        Me.num_KOFU_HASU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_HASU.Location = New System.Drawing.Point(413, 549)
        Me.num_KOFU_HASU.Name = "num_KOFU_HASU"
        Me.num_KOFU_HASU.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_HASU.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_HASU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_HASU, Object), CType(Me.num_KOFU_HASU, Object), CType(Me.num_KOFU_HASU, Object), CType(Me.num_KOFU_HASU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_HASU.Size = New System.Drawing.Size(120, 20)
        Me.num_KOFU_HASU.Spin.Increment = 0
        Me.num_KOFU_HASU.TabIndex = 6
        ValueProcess5.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_KOFU_HASU).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess5})
        InvalidRange5.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        InvalidRange5.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.num_KOFU_HASU).AddRange(New Object() {InvalidRange5})
        Me.num_KOFU_HASU.Value = Nothing
        Me.num_KOFU_HASU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOME1HIKU2_CALC
        '
        Me.num_KOME1HIKU2_CALC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOME1HIKU2_CALC.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOME1HIKU2_CALC.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOME1HIKU2_CALC.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField12.GroupSizes = New Integer() {3}
        Me.num_KOME1HIKU2_CALC.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField12})
        Me.num_KOME1HIKU2_CALC.DropDown.AllowDrop = False
        Me.num_KOME1HIKU2_CALC.Enabled = False
        Me.num_KOME1HIKU2_CALC.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOME1HIKU2_CALC.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOME1HIKU2_CALC.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOME1HIKU2_CALC.Fields.IntegerPart.MinDigits = 1
        Me.num_KOME1HIKU2_CALC.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOME1HIKU2_CALC.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOME1HIKU2_CALC.HighlightText = True
        Me.num_KOME1HIKU2_CALC.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOME1HIKU2_CALC.Location = New System.Drawing.Point(413, 602)
        Me.num_KOME1HIKU2_CALC.Name = "num_KOME1HIKU2_CALC"
        Me.num_KOME1HIKU2_CALC.NegativeColor = System.Drawing.Color.Black
        Me.num_KOME1HIKU2_CALC.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOME1HIKU2_CALC, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOME1HIKU2_CALC, Object), CType(Me.num_KOME1HIKU2_CALC, Object), CType(Me.num_KOME1HIKU2_CALC, Object), CType(Me.num_KOME1HIKU2_CALC, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOME1HIKU2_CALC.Size = New System.Drawing.Size(120, 20)
        Me.num_KOME1HIKU2_CALC.Spin.Increment = 0
        Me.num_KOME1HIKU2_CALC.TabIndex = 1236
        Me.num_KOME1HIKU2_CALC.Value = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.num_KOME1HIKU2_CALC.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOME1HIKU2_DISP
        '
        Me.num_KOME1HIKU2_DISP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOME1HIKU2_DISP.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOME1HIKU2_DISP.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOME1HIKU2_DISP.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField13.GroupSizes = New Integer() {3}
        Me.num_KOME1HIKU2_DISP.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField13})
        Me.num_KOME1HIKU2_DISP.DropDown.AllowDrop = False
        Me.num_KOME1HIKU2_DISP.Enabled = False
        Me.num_KOME1HIKU2_DISP.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOME1HIKU2_DISP.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOME1HIKU2_DISP.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOME1HIKU2_DISP.Fields.IntegerPart.MinDigits = 1
        Me.num_KOME1HIKU2_DISP.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOME1HIKU2_DISP.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOME1HIKU2_DISP.HighlightText = True
        Me.num_KOME1HIKU2_DISP.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOME1HIKU2_DISP.Location = New System.Drawing.Point(413, 654)
        Me.num_KOME1HIKU2_DISP.Name = "num_KOME1HIKU2_DISP"
        Me.num_KOME1HIKU2_DISP.NegativeColor = System.Drawing.Color.Black
        Me.num_KOME1HIKU2_DISP.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOME1HIKU2_DISP, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOME1HIKU2_DISP, Object), CType(Me.num_KOME1HIKU2_DISP, Object), CType(Me.num_KOME1HIKU2_DISP, Object), CType(Me.num_KOME1HIKU2_DISP, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOME1HIKU2_DISP.Size = New System.Drawing.Size(120, 20)
        Me.num_KOME1HIKU2_DISP.Spin.Increment = 0
        Me.num_KOME1HIKU2_DISP.TabIndex = 1237
        Me.num_KOME1HIKU2_DISP.Value = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.num_KOME1HIKU2_DISP.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_MARU3
        '
        Me.num_MARU3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_MARU3.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_MARU3.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_MARU3.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField14.GroupSizes = New Integer() {3}
        Me.num_MARU3.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField14})
        Me.num_MARU3.DropDown.AllowDrop = False
        Me.num_MARU3.Enabled = False
        Me.num_MARU3.Fields.DecimalPart.MaxDigits = 0
        Me.num_MARU3.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_MARU3.Fields.IntegerPart.MaxDigits = 12
        Me.num_MARU3.Fields.IntegerPart.MinDigits = 1
        Me.num_MARU3.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_MARU3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_MARU3.HighlightText = True
        Me.num_MARU3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_MARU3.Location = New System.Drawing.Point(199, 678)
        Me.num_MARU3.Name = "num_MARU3"
        Me.num_MARU3.NegativeColor = System.Drawing.Color.Black
        Me.num_MARU3.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_MARU3, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_MARU3, Object), CType(Me.num_MARU3, Object), CType(Me.num_MARU3, Object), CType(Me.num_MARU3, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_MARU3.Size = New System.Drawing.Size(120, 20)
        Me.num_MARU3.Spin.Increment = 0
        Me.num_MARU3.TabIndex = 1242
        Me.num_MARU3.Value = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.num_MARU3.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_TANKA_SAISYU
        '
        Me.num_KOFU_TANKA_SAISYU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOFU_TANKA_SAISYU.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOFU_TANKA_SAISYU.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_TANKA_SAISYU.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_TANKA_SAISYU.DropDown.AllowDrop = False
        Me.num_KOFU_TANKA_SAISYU.Enabled = False
        Me.num_KOFU_TANKA_SAISYU.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_TANKA_SAISYU.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_TANKA_SAISYU.Fields.IntegerPart.MaxDigits = 10
        Me.num_KOFU_TANKA_SAISYU.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_TANKA_SAISYU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_TANKA_SAISYU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_TANKA_SAISYU.HighlightText = True
        Me.num_KOFU_TANKA_SAISYU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_TANKA_SAISYU.Location = New System.Drawing.Point(665, 549)
        Me.num_KOFU_TANKA_SAISYU.Name = "num_KOFU_TANKA_SAISYU"
        Me.num_KOFU_TANKA_SAISYU.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_TANKA_SAISYU.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_TANKA_SAISYU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_TANKA_SAISYU, Object), CType(Me.num_KOFU_TANKA_SAISYU, Object), CType(Me.num_KOFU_TANKA_SAISYU, Object), CType(Me.num_KOFU_TANKA_SAISYU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_TANKA_SAISYU.Size = New System.Drawing.Size(57, 20)
        Me.num_KOFU_TANKA_SAISYU.Spin.Increment = 0
        Me.num_KOFU_TANKA_SAISYU.TabIndex = 1243
        Me.num_KOFU_TANKA_SAISYU.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_KOFU_TANKA_SAISYU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOME1_CALC
        '
        Me.num_KOME1_CALC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOME1_CALC.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOME1_CALC.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOME1_CALC.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField15.GroupSizes = New Integer() {3}
        Me.num_KOME1_CALC.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField15})
        Me.num_KOME1_CALC.DropDown.AllowDrop = False
        Me.num_KOME1_CALC.Enabled = False
        Me.num_KOME1_CALC.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOME1_CALC.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOME1_CALC.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOME1_CALC.Fields.IntegerPart.MinDigits = 1
        Me.num_KOME1_CALC.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOME1_CALC.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOME1_CALC.HighlightText = True
        Me.num_KOME1_CALC.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOME1_CALC.Location = New System.Drawing.Point(807, 549)
        Me.num_KOME1_CALC.Name = "num_KOME1_CALC"
        Me.num_KOME1_CALC.NegativeColor = System.Drawing.Color.Black
        Me.num_KOME1_CALC.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOME1_CALC, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOME1_CALC, Object), CType(Me.num_KOME1_CALC, Object), CType(Me.num_KOME1_CALC, Object), CType(Me.num_KOME1_CALC, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOME1_CALC.Size = New System.Drawing.Size(120, 20)
        Me.num_KOME1_CALC.Spin.Increment = 0
        Me.num_KOME1_CALC.TabIndex = 1245
        Me.num_KOME1_CALC.Value = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.num_KOME1_CALC.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOME3_CALC
        '
        Me.num_KOME3_CALC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOME3_CALC.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOME3_CALC.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOME3_CALC.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField16.GroupSizes = New Integer() {3}
        Me.num_KOME3_CALC.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField16})
        Me.num_KOME3_CALC.DropDown.AllowDrop = False
        Me.num_KOME3_CALC.Enabled = False
        Me.num_KOME3_CALC.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOME3_CALC.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOME3_CALC.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOME3_CALC.Fields.IntegerPart.MinDigits = 1
        Me.num_KOME3_CALC.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOME3_CALC.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOME3_CALC.HighlightText = True
        Me.num_KOME3_CALC.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOME3_CALC.Location = New System.Drawing.Point(807, 602)
        Me.num_KOME3_CALC.Name = "num_KOME3_CALC"
        Me.num_KOME3_CALC.NegativeColor = System.Drawing.Color.Black
        Me.num_KOME3_CALC.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOME3_CALC, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOME3_CALC, Object), CType(Me.num_KOME3_CALC, Object), CType(Me.num_KOME3_CALC, Object), CType(Me.num_KOME3_CALC, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOME3_CALC.Size = New System.Drawing.Size(120, 20)
        Me.num_KOME3_CALC.Spin.Increment = 0
        Me.num_KOME3_CALC.TabIndex = 1246
        Me.num_KOME3_CALC.Value = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.num_KOME3_CALC.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOME3_DISP2
        '
        Me.num_KOME3_DISP2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOME3_DISP2.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOME3_DISP2.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOME3_DISP2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField17.GroupSizes = New Integer() {3}
        Me.num_KOME3_DISP2.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField17})
        Me.num_KOME3_DISP2.DropDown.AllowDrop = False
        Me.num_KOME3_DISP2.Enabled = False
        Me.num_KOME3_DISP2.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOME3_DISP2.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOME3_DISP2.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOME3_DISP2.Fields.IntegerPart.MinDigits = 1
        Me.num_KOME3_DISP2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOME3_DISP2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOME3_DISP2.HighlightText = True
        Me.num_KOME3_DISP2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOME3_DISP2.Location = New System.Drawing.Point(700, 654)
        Me.num_KOME3_DISP2.Name = "num_KOME3_DISP2"
        Me.num_KOME3_DISP2.NegativeColor = System.Drawing.Color.Black
        Me.num_KOME3_DISP2.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOME3_DISP2, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOME3_DISP2, Object), CType(Me.num_KOME3_DISP2, Object), CType(Me.num_KOME3_DISP2, Object), CType(Me.num_KOME3_DISP2, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOME3_DISP2.Size = New System.Drawing.Size(120, 20)
        Me.num_KOME3_DISP2.Spin.Increment = 0
        Me.num_KOME3_DISP2.TabIndex = 1248
        Me.num_KOME3_DISP2.Value = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.num_KOME3_DISP2.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'dateKOFU_KAKUTEI_Ymd
        '
        Me.dateKOFU_KAKUTEI_Ymd.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.dateKOFU_KAKUTEI_Ymd.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.dateKOFU_KAKUTEI_Ymd.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateKOFU_KAKUTEI_Ymd.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateKOFU_KAKUTEI_Ymd.Location = New System.Drawing.Point(587, 712)
        Me.dateKOFU_KAKUTEI_Ymd.Name = "dateKOFU_KAKUTEI_Ymd"
        Me.GcShortcut1.SetShortcuts(Me.dateKOFU_KAKUTEI_Ymd, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateKOFU_KAKUTEI_Ymd, Object), CType(Me.dateKOFU_KAKUTEI_Ymd, Object), CType(Me.dateKOFU_KAKUTEI_Ymd, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateKOFU_KAKUTEI_Ymd.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.dateKOFU_KAKUTEI_Ymd.Size = New System.Drawing.Size(124, 20)
        Me.dateKOFU_KAKUTEI_Ymd.Spin.AllowSpin = False
        Me.dateKOFU_KAKUTEI_Ymd.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateKOFU_KAKUTEI_Ymd.TabIndex = 13
        Me.dateKOFU_KAKUTEI_Ymd.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'num_KUSYA_KIKAN
        '
        Me.num_KUSYA_KIKAN.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.num_KUSYA_KIKAN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KUSYA_KIKAN.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.num_KUSYA_KIKAN.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KUSYA_KIKAN.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField18.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField12.MaxDigits = 5
        NumberDecimalPartDisplayField12.MinDigits = 5
        Me.num_KUSYA_KIKAN.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField12, NumberIntegerPartDisplayField18, NumberDecimalSeparatorDisplayField12, NumberDecimalPartDisplayField12})
        Me.num_KUSYA_KIKAN.DropDown.AllowDrop = False
        Me.num_KUSYA_KIKAN.Fields.DecimalPart.MaxDigits = 5
        Me.num_KUSYA_KIKAN.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KUSYA_KIKAN.Fields.IntegerPart.MaxDigits = 4
        Me.num_KUSYA_KIKAN.Fields.IntegerPart.MinDigits = 1
        Me.num_KUSYA_KIKAN.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KUSYA_KIKAN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KUSYA_KIKAN.HighlightText = True
        Me.num_KUSYA_KIKAN.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KUSYA_KIKAN.Location = New System.Drawing.Point(226, 443)
        Me.num_KUSYA_KIKAN.Name = "num_KUSYA_KIKAN"
        Me.num_KUSYA_KIKAN.NegativeColor = System.Drawing.Color.Black
        Me.num_KUSYA_KIKAN.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KUSYA_KIKAN, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KUSYA_KIKAN, Object), CType(Me.num_KUSYA_KIKAN, Object), CType(Me.num_KUSYA_KIKAN, Object), CType(Me.num_KUSYA_KIKAN, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KUSYA_KIKAN.Size = New System.Drawing.Size(360, 20)
        Me.num_KUSYA_KIKAN.Spin.Increment = 0
        Me.num_KUSYA_KIKAN.TabIndex = 4
        ValueProcess6.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_KUSYA_KIKAN).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess6})
        InvalidRange6.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange6.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.num_KUSYA_KIKAN).AddRange(New Object() {InvalidRange6})
        Me.num_KUSYA_KIKAN.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_KUSYA_KIKAN.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_MARU2
        '
        Me.num_MARU2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_MARU2.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_MARU2.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_MARU2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField19.GroupSizes = New Integer() {3}
        Me.num_MARU2.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField19})
        Me.num_MARU2.DropDown.AllowDrop = False
        Me.num_MARU2.Enabled = False
        Me.num_MARU2.Fields.DecimalPart.MaxDigits = 0
        Me.num_MARU2.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_MARU2.Fields.IntegerPart.MaxDigits = 12
        Me.num_MARU2.Fields.IntegerPart.MinDigits = 1
        Me.num_MARU2.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_MARU2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_MARU2.HighlightText = True
        Me.num_MARU2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_MARU2.Location = New System.Drawing.Point(858, 654)
        Me.num_MARU2.Name = "num_MARU2"
        Me.num_MARU2.NegativeColor = System.Drawing.Color.Black
        Me.num_MARU2.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_MARU2, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_MARU2, Object), CType(Me.num_MARU2, Object), CType(Me.num_MARU2, Object), CType(Me.num_MARU2, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_MARU2.Size = New System.Drawing.Size(120, 20)
        Me.num_MARU2.Spin.Increment = 0
        Me.num_MARU2.TabIndex = 1260
        Me.num_MARU2.Value = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.num_MARU2.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_Syokei5
        '
        Me.num_Syokei5.BackColor = System.Drawing.Color.White
        Me.num_Syokei5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_Syokei5.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_Syokei5.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_Syokei5.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField20.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField13.MaxDigits = 5
        NumberDecimalPartDisplayField13.MinDigits = 5
        Me.num_Syokei5.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField13, NumberIntegerPartDisplayField20, NumberDecimalSeparatorDisplayField13, NumberDecimalPartDisplayField13})
        Me.num_Syokei5.DropDown.AllowDrop = False
        Me.num_Syokei5.Enabled = False
        Me.num_Syokei5.Fields.DecimalPart.MaxDigits = 5
        Me.num_Syokei5.Fields.DecimalPart.MinDigits = 5
        Me.num_Syokei5.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_Syokei5.Fields.IntegerPart.MaxDigits = 6
        Me.num_Syokei5.Fields.IntegerPart.MinDigits = 1
        Me.num_Syokei5.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_Syokei5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_Syokei5.HighlightText = True
        Me.num_Syokei5.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_Syokei5.Location = New System.Drawing.Point(804, 481)
        Me.num_Syokei5.Name = "num_Syokei5"
        Me.num_Syokei5.NegativeColor = System.Drawing.Color.Black
        Me.num_Syokei5.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_Syokei5, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_Syokei5, Object), CType(Me.num_Syokei5, Object), CType(Me.num_Syokei5, Object), CType(Me.num_Syokei5, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_Syokei5.Size = New System.Drawing.Size(123, 20)
        Me.num_Syokei5.Spin.Increment = 0
        Me.num_Syokei5.TabIndex = 1261
        Me.num_Syokei5.Value = New Decimal(New Integer() {999999999, 0, 0, 327680})
        Me.num_Syokei5.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_KIN_TANKA_SANTEI8
        '
        Me.num_KOFU_KIN_TANKA_SANTEI8.BackColor = System.Drawing.Color.White
        Me.num_KOFU_KIN_TANKA_SANTEI8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_KOFU_KIN_TANKA_SANTEI8.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOFU_KIN_TANKA_SANTEI8.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOFU_KIN_TANKA_SANTEI8.DisabledForeColor = System.Drawing.SystemColors.WindowText
        Me.num_KOFU_KIN_TANKA_SANTEI8.DropDown.AllowDrop = False
        Me.num_KOFU_KIN_TANKA_SANTEI8.Enabled = False
        Me.num_KOFU_KIN_TANKA_SANTEI8.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOFU_KIN_TANKA_SANTEI8.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOFU_KIN_TANKA_SANTEI8.Fields.IntegerPart.MaxDigits = 9
        Me.num_KOFU_KIN_TANKA_SANTEI8.Fields.IntegerPart.MinDigits = 1
        Me.num_KOFU_KIN_TANKA_SANTEI8.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOFU_KIN_TANKA_SANTEI8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOFU_KIN_TANKA_SANTEI8.HighlightText = True
        Me.num_KOFU_KIN_TANKA_SANTEI8.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOFU_KIN_TANKA_SANTEI8.Location = New System.Drawing.Point(925, 481)
        Me.num_KOFU_KIN_TANKA_SANTEI8.Name = "num_KOFU_KIN_TANKA_SANTEI8"
        Me.num_KOFU_KIN_TANKA_SANTEI8.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_KIN_TANKA_SANTEI8.Padding = New System.Windows.Forms.Padding(1, 1, 10, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_KIN_TANKA_SANTEI8, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_KIN_TANKA_SANTEI8, Object), CType(Me.num_KOFU_KIN_TANKA_SANTEI8, Object), CType(Me.num_KOFU_KIN_TANKA_SANTEI8, Object), CType(Me.num_KOFU_KIN_TANKA_SANTEI8, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_KIN_TANKA_SANTEI8.Size = New System.Drawing.Size(110, 20)
        Me.num_KOFU_KIN_TANKA_SANTEI8.Spin.Increment = 0
        Me.num_KOFU_KIN_TANKA_SANTEI8.TabIndex = 1262
        Me.num_KOFU_KIN_TANKA_SANTEI8.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.num_KOFU_KIN_TANKA_SANTEI8.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOME1_DISP
        '
        Me.num_KOME1_DISP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOME1_DISP.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOME1_DISP.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOME1_DISP.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField21.GroupSizes = New Integer() {3}
        Me.num_KOME1_DISP.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField21})
        Me.num_KOME1_DISP.DropDown.AllowDrop = False
        Me.num_KOME1_DISP.Enabled = False
        Me.num_KOME1_DISP.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOME1_DISP.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOME1_DISP.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOME1_DISP.Fields.IntegerPart.MinDigits = 1
        Me.num_KOME1_DISP.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOME1_DISP.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOME1_DISP.HighlightText = True
        Me.num_KOME1_DISP.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOME1_DISP.Location = New System.Drawing.Point(413, 576)
        Me.num_KOME1_DISP.Name = "num_KOME1_DISP"
        Me.num_KOME1_DISP.NegativeColor = System.Drawing.Color.Black
        Me.num_KOME1_DISP.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOME1_DISP, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOME1_DISP, Object), CType(Me.num_KOME1_DISP, Object), CType(Me.num_KOME1_DISP, Object), CType(Me.num_KOME1_DISP, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOME1_DISP.Size = New System.Drawing.Size(120, 20)
        Me.num_KOME1_DISP.Spin.Increment = 0
        Me.num_KOME1_DISP.TabIndex = 1264
        Me.num_KOME1_DISP.Value = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.num_KOME1_DISP.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOME2
        '
        Me.num_KOME2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOME2.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOME2.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOME2.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField22.GroupSizes = New Integer() {3}
        Me.num_KOME2.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField22})
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
        Me.num_KOME2.Location = New System.Drawing.Point(807, 576)
        Me.num_KOME2.Name = "num_KOME2"
        Me.num_KOME2.NegativeColor = System.Drawing.Color.Black
        Me.num_KOME2.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOME2, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOME2, Object), CType(Me.num_KOME2, Object), CType(Me.num_KOME2, Object), CType(Me.num_KOME2, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOME2.Size = New System.Drawing.Size(120, 20)
        Me.num_KOME2.Spin.Increment = 0
        Me.num_KOME2.TabIndex = 1272
        Me.num_KOME2.Value = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.num_KOME2.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOME3_DISP1
        '
        Me.num_KOME3_DISP1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_KOME3_DISP1.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_KOME3_DISP1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_KOME3_DISP1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField23.GroupSizes = New Integer() {3}
        Me.num_KOME3_DISP1.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField23})
        Me.num_KOME3_DISP1.DropDown.AllowDrop = False
        Me.num_KOME3_DISP1.Enabled = False
        Me.num_KOME3_DISP1.Fields.DecimalPart.MaxDigits = 0
        Me.num_KOME3_DISP1.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_KOME3_DISP1.Fields.IntegerPart.MaxDigits = 12
        Me.num_KOME3_DISP1.Fields.IntegerPart.MinDigits = 1
        Me.num_KOME3_DISP1.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_KOME3_DISP1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_KOME3_DISP1.HighlightText = True
        Me.num_KOME3_DISP1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_KOME3_DISP1.Location = New System.Drawing.Point(413, 629)
        Me.num_KOME3_DISP1.Name = "num_KOME3_DISP1"
        Me.num_KOME3_DISP1.NegativeColor = System.Drawing.Color.Black
        Me.num_KOME3_DISP1.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOME3_DISP1, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOME3_DISP1, Object), CType(Me.num_KOME3_DISP1, Object), CType(Me.num_KOME3_DISP1, Object), CType(Me.num_KOME3_DISP1, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOME3_DISP1.Size = New System.Drawing.Size(120, 20)
        Me.num_KOME3_DISP1.Spin.Increment = 0
        Me.num_KOME3_DISP1.TabIndex = 1274
        Me.num_KOME3_DISP1.Value = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.num_KOME3_DISP1.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_KOFU_RITU
        '
        Me.num_KOFU_RITU.BackColor = System.Drawing.Color.Gold
        Me.num_KOFU_RITU.BorderStyle = System.Windows.Forms.BorderStyle.None
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
        Me.num_KOFU_RITU.Location = New System.Drawing.Point(661, 629)
        Me.num_KOFU_RITU.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.num_KOFU_RITU.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.num_KOFU_RITU.Name = "num_KOFU_RITU"
        Me.num_KOFU_RITU.NegativeColor = System.Drawing.Color.Black
        Me.num_KOFU_RITU.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_KOFU_RITU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_KOFU_RITU, Object), CType(Me.num_KOFU_RITU, Object), CType(Me.num_KOFU_RITU, Object), CType(Me.num_KOFU_RITU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_KOFU_RITU.Size = New System.Drawing.Size(92, 20)
        Me.num_KOFU_RITU.Spin.Increment = 0
        Me.num_KOFU_RITU.TabIndex = 1276
        Me.num_KOFU_RITU.Value = New Decimal(New Integer() {100, 0, 0, 0})
        Me.num_KOFU_RITU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_MARU1
        '
        Me.num_MARU1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.num_MARU1.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_MARU1.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_MARU1.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField24.GroupSizes = New Integer() {3}
        Me.num_MARU1.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField24})
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
        Me.num_MARU1.Location = New System.Drawing.Point(807, 629)
        Me.num_MARU1.Name = "num_MARU1"
        Me.num_MARU1.NegativeColor = System.Drawing.Color.Black
        Me.num_MARU1.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_MARU1, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_MARU1, Object), CType(Me.num_MARU1, Object), CType(Me.num_MARU1, Object), CType(Me.num_MARU1, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_MARU1.Size = New System.Drawing.Size(120, 20)
        Me.num_MARU1.Spin.Increment = 0
        Me.num_MARU1.TabIndex = 1278
        Me.num_MARU1.Value = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.num_MARU1.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'num_GENGAKU_RITU
        '
        Me.num_GENGAKU_RITU.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.num_GENGAKU_RITU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.num_GENGAKU_RITU.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.num_GENGAKU_RITU.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.num_GENGAKU_RITU.DisabledForeColor = System.Drawing.SystemColors.WindowText
        NumberIntegerPartDisplayField25.GroupSizes = New Integer() {3}
        Me.num_GENGAKU_RITU.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberIntegerPartDisplayField25})
        Me.num_GENGAKU_RITU.DropDown.AllowDrop = False
        Me.num_GENGAKU_RITU.Fields.DecimalPart.MaxDigits = 0
        Me.num_GENGAKU_RITU.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.num_GENGAKU_RITU.Fields.IntegerPart.MaxDigits = 3
        Me.num_GENGAKU_RITU.Fields.IntegerPart.MinDigits = 1
        Me.num_GENGAKU_RITU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.num_GENGAKU_RITU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.num_GENGAKU_RITU.HighlightText = True
        Me.num_GENGAKU_RITU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.num_GENGAKU_RITU.Location = New System.Drawing.Point(689, 575)
        Me.num_GENGAKU_RITU.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.num_GENGAKU_RITU.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.num_GENGAKU_RITU.Name = "num_GENGAKU_RITU"
        Me.num_GENGAKU_RITU.NegativeColor = System.Drawing.Color.Black
        Me.num_GENGAKU_RITU.Padding = New System.Windows.Forms.Padding(1, 1, 5, 1)
        Me.GcShortcut1.SetShortcuts(Me.num_GENGAKU_RITU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.num_GENGAKU_RITU, Object), CType(Me.num_GENGAKU_RITU, Object), CType(Me.num_GENGAKU_RITU, Object), CType(Me.num_GENGAKU_RITU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.num_GENGAKU_RITU.Size = New System.Drawing.Size(52, 20)
        Me.num_GENGAKU_RITU.Spin.Increment = 0
        Me.num_GENGAKU_RITU.TabIndex = 7
        ValueProcess7.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.num_GENGAKU_RITU).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess7})
        InvalidRange7.MaxValue = New Decimal(New Integer() {9999999, 0, 0, 0})
        InvalidRange7.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.num_GENGAKU_RITU).AddRange(New Object() {InvalidRange7})
        Me.num_GENGAKU_RITU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
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
        Me.Label4.Location = New System.Drawing.Point(55, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "契約者番号"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(55, 176)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 15)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "対象農場名"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(55, 200)
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
        Me.Label23.Location = New System.Drawing.Point(891, 176)
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
        Me.Label26.Location = New System.Drawing.Point(702, 176)
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
        Me.lbl_KEIYAKUSYA_CD.Location = New System.Drawing.Point(150, 90)
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
        Me.lbl_KEIYAKUSYA_NM.Location = New System.Drawing.Point(215, 90)
        Me.lbl_KEIYAKUSYA_NM.Name = "lbl_KEIYAKUSYA_NM"
        Me.lbl_KEIYAKUSYA_NM.Size = New System.Drawing.Size(157, 15)
        Me.lbl_KEIYAKUSYA_NM.TabIndex = 1060
        Me.lbl_KEIYAKUSYA_NM.Text = "＠＠＠＠＠＠＠＠＠＠"
        '
        'lbl_ADDR_1
        '
        Me.lbl_ADDR_1.AccessibleDescription = ""
        Me.lbl_ADDR_1.AutoSize = True
        Me.lbl_ADDR_1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_ADDR_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_ADDR_1.Location = New System.Drawing.Point(205, 200)
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
        Me.lbl_ADDR_2.Location = New System.Drawing.Point(335, 200)
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
        Me.lbl_ADDR_4.Location = New System.Drawing.Point(497, 231)
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
        Me.lbl_ADDR_3.Location = New System.Drawing.Point(202, 230)
        Me.lbl_ADDR_3.Name = "lbl_ADDR_3"
        Me.lbl_ADDR_3.Size = New System.Drawing.Size(232, 15)
        Me.lbl_ADDR_3.TabIndex = 1068
        Me.lbl_ADDR_3.Text = "＠＠＠＠＠＠＠＠＠＠＠＠＠＠＠"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(146, 200)
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
        Me.Label6.Location = New System.Drawing.Point(275, 200)
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
        Me.Label7.Location = New System.Drawing.Point(145, 230)
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
        Me.Label8.Location = New System.Drawing.Point(437, 230)
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
        Me.Panel2.Location = New System.Drawing.Point(26, 52)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1022, 25)
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
        Me.Label10.Size = New System.Drawing.Size(137, 19)
        Me.Label10.TabIndex = 1059
        Me.Label10.Text = "１．申請者名等"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(26, 142)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1022, 25)
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
        Me.Label11.Size = New System.Drawing.Size(337, 19)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "２．農場別種類別互助金申請明細登録"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(61, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 35)
        Me.Label2.TabIndex = 1078
        Me.Label2.Text = "補正区分"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'lbl_NOJO_CD
        '
        Me.lbl_NOJO_CD.AutoSize = True
        Me.lbl_NOJO_CD.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_NOJO_CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_NOJO_CD.Location = New System.Drawing.Point(150, 176)
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
        Me.lbl_NOJO_NAME.Location = New System.Drawing.Point(228, 176)
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
        Me.lbl_TORI_KBN.Location = New System.Drawing.Point(775, 176)
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
        Me.lbl_TORI_KBN_NM.Location = New System.Drawing.Point(802, 176)
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
        Me.lbl_KEIYAKU_HASU.Location = New System.Drawing.Point(962, 176)
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
        Me.Label17.Location = New System.Drawing.Point(46, 552)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(147, 15)
        Me.Label17.TabIndex = 1119
        Me.Label17.Text = "経営支援互助金 算定"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(60, 605)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 15)
        Me.Label18.TabIndex = 1121
        Me.Label18.Text = "①積立金交付金額"
        '
        'lbl_KEIYAKU_KBN
        '
        Me.lbl_KEIYAKU_KBN.AutoSize = True
        Me.lbl_KEIYAKU_KBN.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_KBN.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_KBN.Location = New System.Drawing.Point(150, 114)
        Me.lbl_KEIYAKU_KBN.Name = "lbl_KEIYAKU_KBN"
        Me.lbl_KEIYAKU_KBN.Size = New System.Drawing.Size(47, 15)
        Me.lbl_KEIYAKU_KBN.TabIndex = 1128
        Me.lbl_KEIYAKU_KBN.Text = "99999"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(55, 114)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(67, 15)
        Me.Label29.TabIndex = 1127
        Me.Label29.Text = "契約区分"
        '
        'lbl_KEIYAKU_KBN_NM
        '
        Me.lbl_KEIYAKU_KBN_NM.AutoSize = True
        Me.lbl_KEIYAKU_KBN_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_KEIYAKU_KBN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_KEIYAKU_KBN_NM.Location = New System.Drawing.Point(215, 114)
        Me.lbl_KEIYAKU_KBN_NM.Name = "lbl_KEIYAKU_KBN_NM"
        Me.lbl_KEIYAKU_KBN_NM.Size = New System.Drawing.Size(157, 15)
        Me.lbl_KEIYAKU_KBN_NM.TabIndex = 1129
        Me.lbl_KEIYAKU_KBN_NM.Text = "＠＠＠＠＠＠＠＠＠＠"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(226, 256)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(166, 35)
        Me.Label3.TabIndex = 1130
        Me.Label3.Text = "交付上限単価における"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(61, 290)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(166, 39)
        Me.Label25.TabIndex = 1131
        Me.Label25.Text = "①雇用労賃の補正"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(61, 404)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(166, 59)
        Me.Label30.TabIndex = 1132
        Me.Label30.Text = "④空舎期間の補正"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(389, 256)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 35)
        Me.Label9.TabIndex = 1134
        Me.Label9.Text = "　"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(226, 290)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(166, 20)
        Me.Label12.TabIndex = 1135
        Me.Label12.Text = "(雇用労賃)"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(389, 309)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(30, 20)
        Me.Label16.TabIndex = 1138
        Me.Label16.Text = "×"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(418, 256)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(166, 35)
        Me.Label15.TabIndex = 1139
        Me.Label15.Text = "交付対象農場における" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "１羽１ヶ月当たりの"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(389, 290)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 20)
        Me.Label19.TabIndex = 1140
        Me.Label19.Text = "　"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(418, 290)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(166, 20)
        Me.Label20.TabIndex = 1141
        Me.Label20.Text = "(雇用労賃)"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(581, 290)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(30, 20)
        Me.Label21.TabIndex = 1145
        Me.Label21.Text = "　"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(581, 256)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(30, 35)
        Me.Label22.TabIndex = 1143
        Me.Label22.Text = "　"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(581, 309)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(30, 20)
        Me.Label32.TabIndex = 1144
        Me.Label32.Text = "÷"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(610, 290)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(166, 20)
        Me.Label33.TabIndex = 1147
        Me.Label33.Text = "(雇用労賃)"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(610, 256)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(166, 35)
        Me.Label34.TabIndex = 1146
        Me.Label34.Text = "生産費における１羽" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "１ヶ月当たりの"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(775, 290)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(30, 20)
        Me.Label35.TabIndex = 1151
        Me.Label35.Text = "　"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(775, 256)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(30, 35)
        Me.Label36.TabIndex = 1149
        Me.Label36.Text = "　"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(775, 309)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(30, 20)
        Me.Label37.TabIndex = 1150
        Me.Label37.Text = "="
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(804, 290)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(123, 20)
        Me.Label38.TabIndex = 1153
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(804, 328)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(123, 20)
        Me.Label31.TabIndex = 1168
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label41.Location = New System.Drawing.Point(775, 328)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(30, 20)
        Me.Label41.TabIndex = 1167
        Me.Label41.Text = "　"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(775, 347)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(30, 20)
        Me.Label42.TabIndex = 1166
        Me.Label42.Text = "="
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(610, 328)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(166, 20)
        Me.Label43.TabIndex = 1164
        Me.Label43.Text = "(地代)"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label44.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(581, 328)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(30, 20)
        Me.Label44.TabIndex = 1163
        Me.Label44.Text = "　"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(581, 347)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(30, 20)
        Me.Label45.TabIndex = 1162
        Me.Label45.Text = "÷"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label46.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.Location = New System.Drawing.Point(418, 328)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(166, 20)
        Me.Label46.TabIndex = 1160
        Me.Label46.Text = "(地代)"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label47.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(389, 328)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(30, 20)
        Me.Label47.TabIndex = 1159
        Me.Label47.Text = "　"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label48.Location = New System.Drawing.Point(389, 347)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(30, 20)
        Me.Label48.TabIndex = 1158
        Me.Label48.Text = "×"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label49.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label49.Location = New System.Drawing.Point(226, 328)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(166, 20)
        Me.Label49.TabIndex = 1156
        Me.Label49.Text = "(地代)"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label50.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label50.Location = New System.Drawing.Point(61, 328)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(166, 39)
        Me.Label50.TabIndex = 1155
        Me.Label50.Text = "②地代の補正"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label51.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label51.Location = New System.Drawing.Point(804, 366)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(123, 20)
        Me.Label51.TabIndex = 1183
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label52.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(775, 366)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(30, 20)
        Me.Label52.TabIndex = 1182
        Me.Label52.Text = "　"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label53.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label53.Location = New System.Drawing.Point(775, 385)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(30, 20)
        Me.Label53.TabIndex = 1181
        Me.Label53.Text = "="
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label54.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label54.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label54.Location = New System.Drawing.Point(610, 366)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(166, 20)
        Me.Label54.TabIndex = 1179
        Me.Label54.Text = "(減価償却)"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.Transparent
        Me.Label55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label55.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label55.Location = New System.Drawing.Point(581, 366)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(30, 20)
        Me.Label55.TabIndex = 1178
        Me.Label55.Text = "　"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label56.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label56.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label56.Location = New System.Drawing.Point(581, 385)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(30, 20)
        Me.Label56.TabIndex = 1177
        Me.Label56.Text = "÷"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label57.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label57.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label57.Location = New System.Drawing.Point(418, 366)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(166, 20)
        Me.Label57.TabIndex = 1175
        Me.Label57.Text = "(減価償却)"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label58.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label58.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label58.Location = New System.Drawing.Point(389, 366)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(30, 20)
        Me.Label58.TabIndex = 1174
        Me.Label58.Text = "　"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.Transparent
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label59.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label59.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label59.Location = New System.Drawing.Point(389, 385)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(30, 20)
        Me.Label59.TabIndex = 1173
        Me.Label59.Text = "×"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.Color.Transparent
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label60.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label60.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label60.Location = New System.Drawing.Point(226, 366)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(166, 20)
        Me.Label60.TabIndex = 1171
        Me.Label60.Text = "(減価償却)"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.Color.Transparent
        Me.Label61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label61.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label61.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label61.Location = New System.Drawing.Point(61, 366)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(166, 39)
        Me.Label61.TabIndex = 1170
        Me.Label61.Text = "③減価償却の補正"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.Color.Transparent
        Me.Label62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label62.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label62.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label62.Location = New System.Drawing.Point(226, 404)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(360, 40)
        Me.Label62.TabIndex = 1185
        Me.Label62.Text = "⑥交付対象農場の可家畜導入計画における空舎期間"
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label63.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label63.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label63.Location = New System.Drawing.Point(581, 404)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(30, 40)
        Me.Label63.TabIndex = 1187
        Me.Label63.Text = "　"
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.Transparent
        Me.Label64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label64.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label64.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label64.Location = New System.Drawing.Point(610, 404)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(180, 40)
        Me.Label64.TabIndex = 1188
        Me.Label64.Text = "⑦交付上限単価における空舎期間"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label65
        '
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label65.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label65.Location = New System.Drawing.Point(581, 443)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(30, 20)
        Me.Label65.TabIndex = 1189
        Me.Label65.Text = "÷"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label66.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label66.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label66.Location = New System.Drawing.Point(775, 404)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(30, 40)
        Me.Label66.TabIndex = 1191
        Me.Label66.Text = "　"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label67.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label67.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label67.Location = New System.Drawing.Point(775, 443)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(30, 20)
        Me.Label67.TabIndex = 1192
        Me.Label67.Text = "="
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(804, 256)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(123, 35)
        Me.Label39.TabIndex = 1152
        Me.Label39.Text = "算定単価" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(補正係数)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label70
        '
        Me.Label70.BackColor = System.Drawing.Color.Transparent
        Me.Label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label70.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label70.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label70.Location = New System.Drawing.Point(61, 462)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(166, 39)
        Me.Label70.TabIndex = 1196
        Me.Label70.Text = "互助金交付単価の算定"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label69
        '
        Me.Label69.BackColor = System.Drawing.Color.Transparent
        Me.Label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label69.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label69.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label69.Location = New System.Drawing.Point(226, 462)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(100, 20)
        Me.Label69.TabIndex = 1197
        Me.Label69.Text = "①"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label71
        '
        Me.Label71.BackColor = System.Drawing.Color.Transparent
        Me.Label71.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label71.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label71.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label71.Location = New System.Drawing.Point(325, 462)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(30, 20)
        Me.Label71.TabIndex = 1200
        Me.Label71.Text = "　"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label72
        '
        Me.Label72.BackColor = System.Drawing.Color.Transparent
        Me.Label72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label72.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label72.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label72.Location = New System.Drawing.Point(325, 481)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(30, 20)
        Me.Label72.TabIndex = 1199
        Me.Label72.Text = "+"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label73
        '
        Me.Label73.BackColor = System.Drawing.Color.Transparent
        Me.Label73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label73.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label73.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label73.Location = New System.Drawing.Point(453, 462)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(30, 20)
        Me.Label73.TabIndex = 1204
        Me.Label73.Text = "　"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label74
        '
        Me.Label74.BackColor = System.Drawing.Color.Transparent
        Me.Label74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label74.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label74.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label74.Location = New System.Drawing.Point(453, 481)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(30, 20)
        Me.Label74.TabIndex = 1203
        Me.Label74.Text = "+"
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label75
        '
        Me.Label75.BackColor = System.Drawing.Color.Transparent
        Me.Label75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label75.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label75.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label75.Location = New System.Drawing.Point(354, 462)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(100, 20)
        Me.Label75.TabIndex = 1205
        Me.Label75.Text = "②"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label76
        '
        Me.Label76.BackColor = System.Drawing.Color.Transparent
        Me.Label76.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label76.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label76.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label76.Location = New System.Drawing.Point(482, 462)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(100, 20)
        Me.Label76.TabIndex = 1207
        Me.Label76.Text = "③"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label77
        '
        Me.Label77.BackColor = System.Drawing.Color.Transparent
        Me.Label77.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label77.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label77.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label77.Location = New System.Drawing.Point(581, 462)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(30, 20)
        Me.Label77.TabIndex = 1210
        Me.Label77.Text = "　"
        Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label78
        '
        Me.Label78.BackColor = System.Drawing.Color.Transparent
        Me.Label78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label78.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label78.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label78.Location = New System.Drawing.Point(581, 481)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(30, 20)
        Me.Label78.TabIndex = 1209
        Me.Label78.Text = "+"
        Me.Label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label79
        '
        Me.Label79.BackColor = System.Drawing.Color.Transparent
        Me.Label79.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label79.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label79.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label79.Location = New System.Drawing.Point(610, 462)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(166, 20)
        Me.Label79.TabIndex = 1211
        Me.Label79.Text = "④その他固定費"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label80
        '
        Me.Label80.BackColor = System.Drawing.Color.Transparent
        Me.Label80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label80.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label80.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label80.Location = New System.Drawing.Point(775, 481)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(30, 20)
        Me.Label80.TabIndex = 1213
        Me.Label80.Text = "="
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label81
        '
        Me.Label81.BackColor = System.Drawing.Color.Transparent
        Me.Label81.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label81.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label81.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label81.Location = New System.Drawing.Point(775, 462)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(30, 20)
        Me.Label81.TabIndex = 1214
        Me.Label81.Text = "　"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label82
        '
        Me.Label82.BackColor = System.Drawing.Color.Transparent
        Me.Label82.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label82.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label82.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label82.Location = New System.Drawing.Point(804, 462)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(123, 20)
        Me.Label82.TabIndex = 1215
        Me.Label82.Text = "⑤=①＋②+③+④"
        Me.Label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label83
        '
        Me.Label83.BackColor = System.Drawing.Color.Transparent
        Me.Label83.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label83.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label83.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label83.Location = New System.Drawing.Point(925, 462)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(110, 20)
        Me.Label83.TabIndex = 1216
        Me.Label83.Text = "⑧=⑤×⑥／⑦"
        Me.Label83.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(61, 500)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(166, 39)
        Me.Label24.TabIndex = 1219
        Me.Label24.Text = "互助金交付単価の算定"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label84
        '
        Me.Label84.BackColor = System.Drawing.Color.Transparent
        Me.Label84.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label84.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label84.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label84.Location = New System.Drawing.Point(226, 500)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(195, 20)
        Me.Label84.TabIndex = 1220
        Me.Label84.Text = "別表２の交付上限単価"
        Me.Label84.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label85
        '
        Me.Label85.BackColor = System.Drawing.Color.Transparent
        Me.Label85.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label85.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label85.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label85.Location = New System.Drawing.Point(417, 500)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(195, 20)
        Me.Label85.TabIndex = 1221
        Me.Label85.Text = "⑧算定交付上限単価"
        Me.Label85.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label86
        '
        Me.Label86.BackColor = System.Drawing.Color.Transparent
        Me.Label86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label86.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label86.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label86.Location = New System.Drawing.Point(610, 500)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(195, 20)
        Me.Label86.TabIndex = 1222
        Me.Label86.Text = "決定交付上限単価"
        Me.Label86.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(60, 657)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(112, 15)
        Me.Label27.TabIndex = 1226
        Me.Label27.Text = "②国庫交付金額"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(60, 681)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(127, 15)
        Me.Label28.TabIndex = 1227
        Me.Label28.Text = "③経営支援互助金"
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.BackColor = System.Drawing.Color.Transparent
        Me.Label87.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label87.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label87.Location = New System.Drawing.Point(61, 715)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(112, 15)
        Me.Label87.TabIndex = 1228
        Me.Label87.Text = "■入力確認有無"
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.BackColor = System.Drawing.Color.Transparent
        Me.Label88.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label88.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label88.Location = New System.Drawing.Point(199, 552)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(158, 15)
        Me.Label88.TabIndex = 1229
        Me.Label88.Text = "対象羽数（導入羽数等）"
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.BackColor = System.Drawing.Color.Transparent
        Me.Label89.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label89.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label89.Location = New System.Drawing.Point(199, 605)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(211, 15)
        Me.Label89.TabIndex = 1230
        Me.Label89.Text = "経営支援互助金 算定(※1-※2)"
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.BackColor = System.Drawing.Color.Transparent
        Me.Label90.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label90.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label90.Location = New System.Drawing.Point(562, 552)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(97, 15)
        Me.Label90.TabIndex = 1231
        Me.Label90.Text = "最終決定単価"
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.BackColor = System.Drawing.Color.Transparent
        Me.Label91.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label91.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label91.Location = New System.Drawing.Point(199, 657)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(211, 15)
        Me.Label91.TabIndex = 1232
        Me.Label91.Text = "経営支援互助金 算定(※1-※2)"
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.BackColor = System.Drawing.Color.Transparent
        Me.Label93.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label93.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label93.Location = New System.Drawing.Point(561, 657)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(135, 15)
        Me.Label93.TabIndex = 1234
        Me.Label93.Text = "積立金交付金額※3"
        '
        'Label94
        '
        Me.Label94.BackColor = System.Drawing.Color.Transparent
        Me.Label94.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label94.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label94.Location = New System.Drawing.Point(539, 549)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(20, 20)
        Me.Label94.TabIndex = 1238
        Me.Label94.Text = "×"
        Me.Label94.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label95
        '
        Me.Label95.BackColor = System.Drawing.Color.Transparent
        Me.Label95.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label95.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label95.Location = New System.Drawing.Point(539, 602)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(20, 20)
        Me.Label95.TabIndex = 1239
        Me.Label95.Text = "×"
        Me.Label95.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label96
        '
        Me.Label96.BackColor = System.Drawing.Color.Transparent
        Me.Label96.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label96.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label96.Location = New System.Drawing.Point(539, 654)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(20, 20)
        Me.Label96.TabIndex = 1240
        Me.Label96.Text = "－"
        Me.Label96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label97
        '
        Me.Label97.BackColor = System.Drawing.Color.Transparent
        Me.Label97.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label97.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label97.Location = New System.Drawing.Point(778, 602)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(30, 20)
        Me.Label97.TabIndex = 1241
        Me.Label97.Text = "="
        Me.Label97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label98
        '
        Me.Label98.BackColor = System.Drawing.Color.Transparent
        Me.Label98.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label98.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label98.Location = New System.Drawing.Point(778, 549)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(30, 20)
        Me.Label98.TabIndex = 1244
        Me.Label98.Text = "="
        Me.Label98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.BackColor = System.Drawing.Color.Transparent
        Me.Label99.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label99.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label99.Location = New System.Drawing.Point(929, 605)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(146, 15)
        Me.Label99.TabIndex = 1247
        Me.Label99.Text = "（円未満切り上げ）※3"
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.BackColor = System.Drawing.Color.Transparent
        Me.Label100.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label100.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label100.Location = New System.Drawing.Point(325, 681)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(127, 15)
        Me.Label100.TabIndex = 1249
        Me.Label100.Text = "①積立金交付金額"
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.BackColor = System.Drawing.Color.Transparent
        Me.Label101.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label101.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label101.Location = New System.Drawing.Point(483, 681)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(112, 15)
        Me.Label101.TabIndex = 1250
        Me.Label101.Text = "②国庫交付金額"
        '
        'Label102
        '
        Me.Label102.BackColor = System.Drawing.Color.Transparent
        Me.Label102.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label102.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label102.Location = New System.Drawing.Point(455, 678)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(30, 20)
        Me.Label102.TabIndex = 1251
        Me.Label102.Text = "＋"
        Me.Label102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.BackColor = System.Drawing.Color.Transparent
        Me.Label103.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label103.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label103.Location = New System.Drawing.Point(492, 715)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(97, 15)
        Me.Label103.TabIndex = 1253
        Me.Label103.Text = "□確定年月日"
        '
        'rbtnSYORI_JOKYO_KBN_1
        '
        Me.rbtnSYORI_JOKYO_KBN_1.AutoSize = True
        Me.rbtnSYORI_JOKYO_KBN_1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnSYORI_JOKYO_KBN_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtnSYORI_JOKYO_KBN_1.Location = New System.Drawing.Point(231, 712)
        Me.rbtnSYORI_JOKYO_KBN_1.Name = "rbtnSYORI_JOKYO_KBN_1"
        Me.rbtnSYORI_JOKYO_KBN_1.Size = New System.Drawing.Size(76, 20)
        Me.rbtnSYORI_JOKYO_KBN_1.TabIndex = 10
        Me.rbtnSYORI_JOKYO_KBN_1.TabStop = True
        Me.rbtnSYORI_JOKYO_KBN_1.Text = "入力中"
        Me.rbtnSYORI_JOKYO_KBN_1.UseVisualStyleBackColor = True
        '
        'rbtnSYORI_JOKYO_KBN_2
        '
        Me.rbtnSYORI_JOKYO_KBN_2.AutoSize = True
        Me.rbtnSYORI_JOKYO_KBN_2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnSYORI_JOKYO_KBN_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtnSYORI_JOKYO_KBN_2.Location = New System.Drawing.Point(313, 712)
        Me.rbtnSYORI_JOKYO_KBN_2.Name = "rbtnSYORI_JOKYO_KBN_2"
        Me.rbtnSYORI_JOKYO_KBN_2.Size = New System.Drawing.Size(76, 20)
        Me.rbtnSYORI_JOKYO_KBN_2.TabIndex = 11
        Me.rbtnSYORI_JOKYO_KBN_2.TabStop = True
        Me.rbtnSYORI_JOKYO_KBN_2.Text = "審査中"
        Me.rbtnSYORI_JOKYO_KBN_2.UseVisualStyleBackColor = True
        '
        'rbtnSYORI_JOKYO_KBN_3
        '
        Me.rbtnSYORI_JOKYO_KBN_3.AutoSize = True
        Me.rbtnSYORI_JOKYO_KBN_3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnSYORI_JOKYO_KBN_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rbtnSYORI_JOKYO_KBN_3.Location = New System.Drawing.Point(395, 713)
        Me.rbtnSYORI_JOKYO_KBN_3.Name = "rbtnSYORI_JOKYO_KBN_3"
        Me.rbtnSYORI_JOKYO_KBN_3.Size = New System.Drawing.Size(91, 20)
        Me.rbtnSYORI_JOKYO_KBN_3.TabIndex = 12
        Me.rbtnSYORI_JOKYO_KBN_3.TabStop = True
        Me.rbtnSYORI_JOKYO_KBN_3.Text = "交付確定"
        Me.rbtnSYORI_JOKYO_KBN_3.UseVisualStyleBackColor = True
        '
        'lbl_SYORI_JOKYO_KBN_NM
        '
        Me.lbl_SYORI_JOKYO_KBN_NM.AccessibleDescription = ""
        Me.lbl_SYORI_JOKYO_KBN_NM.AutoSize = True
        Me.lbl_SYORI_JOKYO_KBN_NM.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_SYORI_JOKYO_KBN_NM.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.lbl_SYORI_JOKYO_KBN_NM.Location = New System.Drawing.Point(881, 712)
        Me.lbl_SYORI_JOKYO_KBN_NM.Name = "lbl_SYORI_JOKYO_KBN_NM"
        Me.lbl_SYORI_JOKYO_KBN_NM.Size = New System.Drawing.Size(97, 15)
        Me.lbl_SYORI_JOKYO_KBN_NM.TabIndex = 1258
        Me.lbl_SYORI_JOKYO_KBN_NM.Text = "＠＠＠＠＠＠"
        Me.lbl_SYORI_JOKYO_KBN_NM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(823, 654)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(30, 20)
        Me.Label40.TabIndex = 1259
        Me.Label40.Text = "="
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label68.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label68.Location = New System.Drawing.Point(929, 552)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(30, 15)
        Me.Label68.TabIndex = 1263
        Me.Label68.Text = "※1"
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.BackColor = System.Drawing.Color.Transparent
        Me.Label104.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label104.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label104.Location = New System.Drawing.Point(199, 579)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(180, 15)
        Me.Label104.TabIndex = 1265
        Me.Label104.Text = "経営支援互助金 算定(※1)"
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.BackColor = System.Drawing.Color.Transparent
        Me.Label105.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label105.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label105.Location = New System.Drawing.Point(46, 579)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(112, 15)
        Me.Label105.TabIndex = 1266
        Me.Label105.Text = "家伝法違反減額"
        '
        'Label106
        '
        Me.Label106.BackColor = System.Drawing.Color.Transparent
        Me.Label106.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label106.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label106.Location = New System.Drawing.Point(539, 576)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(20, 20)
        Me.Label106.TabIndex = 1267
        Me.Label106.Text = "×"
        Me.Label106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.BackColor = System.Drawing.Color.Transparent
        Me.Label107.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label107.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label107.Location = New System.Drawing.Point(562, 579)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(127, 15)
        Me.Label107.TabIndex = 1268
        Me.Label107.Text = "家伝法違反減額率"
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.BackColor = System.Drawing.Color.Transparent
        Me.Label108.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label108.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label108.Location = New System.Drawing.Point(747, 579)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(15, 15)
        Me.Label108.TabIndex = 1270
        Me.Label108.Text = "%"
        '
        'Label109
        '
        Me.Label109.BackColor = System.Drawing.Color.Transparent
        Me.Label109.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label109.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label109.Location = New System.Drawing.Point(778, 576)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(30, 20)
        Me.Label109.TabIndex = 1271
        Me.Label109.Text = "="
        Me.Label109.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.BackColor = System.Drawing.Color.Transparent
        Me.Label110.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label110.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label110.Location = New System.Drawing.Point(929, 579)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(146, 15)
        Me.Label110.TabIndex = 1273
        Me.Label110.Text = "（円未満切り上げ）※2"
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.BackColor = System.Drawing.Color.Transparent
        Me.Label112.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label112.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label112.Location = New System.Drawing.Point(759, 632)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(15, 15)
        Me.Label112.TabIndex = 1277
        Me.Label112.Text = "%"
        '
        'Label113
        '
        Me.Label113.AutoSize = True
        Me.Label113.BackColor = System.Drawing.Color.Transparent
        Me.Label113.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label113.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label113.Location = New System.Drawing.Point(929, 632)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(138, 15)
        Me.Label113.TabIndex = 1279
        Me.Label113.Text = "（円未満切り上げ）①"
        '
        'Label114
        '
        Me.Label114.AutoSize = True
        Me.Label114.BackColor = System.Drawing.Color.Transparent
        Me.Label114.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label114.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label114.Location = New System.Drawing.Point(978, 657)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(22, 15)
        Me.Label114.TabIndex = 1280
        Me.Label114.Text = "②"
        '
        'Label115
        '
        Me.Label115.BackColor = System.Drawing.Color.Transparent
        Me.Label115.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label115.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label115.Location = New System.Drawing.Point(778, 629)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(30, 20)
        Me.Label115.TabIndex = 1281
        Me.Label115.Text = "="
        Me.Label115.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label111
        '
        Me.Label111.BackColor = System.Drawing.Color.Transparent
        Me.Label111.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label111.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label111.Location = New System.Drawing.Point(539, 629)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(20, 20)
        Me.Label111.TabIndex = 1283
        Me.Label111.Text = "×"
        Me.Label111.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.BackColor = System.Drawing.Color.Transparent
        Me.Label92.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label92.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label92.Location = New System.Drawing.Point(562, 605)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(35, 15)
        Me.Label92.TabIndex = 1233
        Me.Label92.Text = "１/２"
        '
        'Label116
        '
        Me.Label116.AutoSize = True
        Me.Label116.BackColor = System.Drawing.Color.Transparent
        Me.Label116.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label116.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label116.Location = New System.Drawing.Point(562, 632)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(97, 15)
        Me.Label116.TabIndex = 1284
        Me.Label116.Text = "互助金交付率"
        '
        'frmGJ4012
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.Color.PeachPuff
        Me.ClientSize = New System.Drawing.Size(1094, 797)
        Me.Controls.Add(Me.num_GENGAKU_RITU)
        Me.Controls.Add(Me.Label116)
        Me.Controls.Add(Me.Label111)
        Me.Controls.Add(Me.Label115)
        Me.Controls.Add(Me.Label114)
        Me.Controls.Add(Me.Label113)
        Me.Controls.Add(Me.num_MARU1)
        Me.Controls.Add(Me.Label112)
        Me.Controls.Add(Me.num_KOFU_RITU)
        Me.Controls.Add(Me.num_KOME3_DISP1)
        Me.Controls.Add(Me.Label110)
        Me.Controls.Add(Me.num_KOME2)
        Me.Controls.Add(Me.Label109)
        Me.Controls.Add(Me.Label108)
        Me.Controls.Add(Me.Label107)
        Me.Controls.Add(Me.Label106)
        Me.Controls.Add(Me.Label105)
        Me.Controls.Add(Me.Label104)
        Me.Controls.Add(Me.num_KOME1_DISP)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.num_KOFU_KIN_TANKA_SANTEI8)
        Me.Controls.Add(Me.num_Syokei5)
        Me.Controls.Add(Me.num_MARU2)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.lbl_SYORI_JOKYO_KBN_NM)
        Me.Controls.Add(Me.rbtnSYORI_JOKYO_KBN_3)
        Me.Controls.Add(Me.rbtnSYORI_JOKYO_KBN_2)
        Me.Controls.Add(Me.rbtnSYORI_JOKYO_KBN_1)
        Me.Controls.Add(Me.dateKOFU_KAKUTEI_Ymd)
        Me.Controls.Add(Me.Label103)
        Me.Controls.Add(Me.Label102)
        Me.Controls.Add(Me.Label101)
        Me.Controls.Add(Me.Label100)
        Me.Controls.Add(Me.num_KOME3_DISP2)
        Me.Controls.Add(Me.Label99)
        Me.Controls.Add(Me.num_KOME3_CALC)
        Me.Controls.Add(Me.num_KOME1_CALC)
        Me.Controls.Add(Me.Label98)
        Me.Controls.Add(Me.num_KOFU_TANKA_SAISYU)
        Me.Controls.Add(Me.num_MARU3)
        Me.Controls.Add(Me.Label97)
        Me.Controls.Add(Me.Label96)
        Me.Controls.Add(Me.Label95)
        Me.Controls.Add(Me.Label94)
        Me.Controls.Add(Me.num_KOME1HIKU2_DISP)
        Me.Controls.Add(Me.num_KOME1HIKU2_CALC)
        Me.Controls.Add(Me.num_KOFU_HASU)
        Me.Controls.Add(Me.Label93)
        Me.Controls.Add(Me.Label92)
        Me.Controls.Add(Me.Label91)
        Me.Controls.Add(Me.Label90)
        Me.Controls.Add(Me.Label89)
        Me.Controls.Add(Me.Label88)
        Me.Controls.Add(Me.Label87)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.num_KOFU_TANKA)
        Me.Controls.Add(Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN)
        Me.Controls.Add(Me.num_KOFU_KIN_TANKA_BET2)
        Me.Controls.Add(Me.Label86)
        Me.Controls.Add(Me.Label85)
        Me.Controls.Add(Me.Label84)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label83)
        Me.Controls.Add(Me.Label82)
        Me.Controls.Add(Me.Label80)
        Me.Controls.Add(Me.Label81)
        Me.Controls.Add(Me.num_SONOTA_KOTEIHI)
        Me.Controls.Add(Me.Label79)
        Me.Controls.Add(Me.Label77)
        Me.Controls.Add(Me.Label78)
        Me.Controls.Add(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3)
        Me.Controls.Add(Me.Label76)
        Me.Controls.Add(Me.num_JIDAI_HOSEI_2)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.Label73)
        Me.Controls.Add(Me.Label74)
        Me.Controls.Add(Me.Label71)
        Me.Controls.Add(Me.Label72)
        Me.Controls.Add(Me.num_KOYO_HOSEI_1)
        Me.Controls.Add(Me.Label69)
        Me.Controls.Add(Me.Label70)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.num_KUSYA)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.num_GENKA_SYOKYAKU)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.num_GENKA_JOGEN)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.num_JIDAI_HOSEI)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.num_JIDAI_JIDAI)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.num_JIDAI)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.num_JIDAI_JOGEN)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.num_KOYO_HOSEI)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.num_KOYO_KOYO)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.num_KOYO_ROTIN)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.num_KOYO_JOGEN)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_KEIYAKU_KBN_NM)
        Me.Controls.Add(Me.lbl_KEIYAKU_KBN)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lbl_KEIYAKU_HASU)
        Me.Controls.Add(Me.lbl_TORI_KBN_NM)
        Me.Controls.Add(Me.lbl_TORI_KBN)
        Me.Controls.Add(Me.lbl_NOJO_NAME)
        Me.Controls.Add(Me.lbl_NOJO_CD)
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
        Me.Controls.Add(Me.lbl_KEIYAKUSYA_NM)
        Me.Controls.Add(Me.lbl_KEIYAKUSYA_CD)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.num_KUSYA_KIKAN)
        Me.Name = "frmGJ4012"
        Me.Text = "(GJ4012)互助金申請明細入力"
        Me.Controls.SetChildIndex(Me.num_KUSYA_KIKAN, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKUSYA_CD, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKUSYA_NM, 0)
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
        Me.Controls.SetChildIndex(Me.lbl_NOJO_CD, 0)
        Me.Controls.SetChildIndex(Me.lbl_NOJO_NAME, 0)
        Me.Controls.SetChildIndex(Me.lbl_TORI_KBN, 0)
        Me.Controls.SetChildIndex(Me.lbl_TORI_KBN_NM, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_HASU, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label29, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_KBN, 0)
        Me.Controls.SetChildIndex(Me.lbl_KEIYAKU_KBN_NM, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.num_KOYO_JOGEN, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.num_KOYO_ROTIN, 0)
        Me.Controls.SetChildIndex(Me.Label32, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.Label34, 0)
        Me.Controls.SetChildIndex(Me.Label33, 0)
        Me.Controls.SetChildIndex(Me.num_KOYO_KOYO, 0)
        Me.Controls.SetChildIndex(Me.Label37, 0)
        Me.Controls.SetChildIndex(Me.Label36, 0)
        Me.Controls.SetChildIndex(Me.Label35, 0)
        Me.Controls.SetChildIndex(Me.Label39, 0)
        Me.Controls.SetChildIndex(Me.Label38, 0)
        Me.Controls.SetChildIndex(Me.num_KOYO_HOSEI, 0)
        Me.Controls.SetChildIndex(Me.Label50, 0)
        Me.Controls.SetChildIndex(Me.Label49, 0)
        Me.Controls.SetChildIndex(Me.num_JIDAI_JOGEN, 0)
        Me.Controls.SetChildIndex(Me.Label48, 0)
        Me.Controls.SetChildIndex(Me.Label47, 0)
        Me.Controls.SetChildIndex(Me.Label46, 0)
        Me.Controls.SetChildIndex(Me.num_JIDAI, 0)
        Me.Controls.SetChildIndex(Me.Label45, 0)
        Me.Controls.SetChildIndex(Me.Label44, 0)
        Me.Controls.SetChildIndex(Me.Label43, 0)
        Me.Controls.SetChildIndex(Me.num_JIDAI_JIDAI, 0)
        Me.Controls.SetChildIndex(Me.Label42, 0)
        Me.Controls.SetChildIndex(Me.Label41, 0)
        Me.Controls.SetChildIndex(Me.Label31, 0)
        Me.Controls.SetChildIndex(Me.num_JIDAI_HOSEI, 0)
        Me.Controls.SetChildIndex(Me.Label61, 0)
        Me.Controls.SetChildIndex(Me.Label60, 0)
        Me.Controls.SetChildIndex(Me.num_GENKA_JOGEN, 0)
        Me.Controls.SetChildIndex(Me.Label59, 0)
        Me.Controls.SetChildIndex(Me.Label58, 0)
        Me.Controls.SetChildIndex(Me.Label57, 0)
        Me.Controls.SetChildIndex(Me.num_GENKA_SYOKYAKU, 0)
        Me.Controls.SetChildIndex(Me.Label56, 0)
        Me.Controls.SetChildIndex(Me.Label55, 0)
        Me.Controls.SetChildIndex(Me.Label54, 0)
        Me.Controls.SetChildIndex(Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU, 0)
        Me.Controls.SetChildIndex(Me.Label53, 0)
        Me.Controls.SetChildIndex(Me.Label52, 0)
        Me.Controls.SetChildIndex(Me.Label51, 0)
        Me.Controls.SetChildIndex(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI, 0)
        Me.Controls.SetChildIndex(Me.Label62, 0)
        Me.Controls.SetChildIndex(Me.Label63, 0)
        Me.Controls.SetChildIndex(Me.Label64, 0)
        Me.Controls.SetChildIndex(Me.Label65, 0)
        Me.Controls.SetChildIndex(Me.num_KUSYA, 0)
        Me.Controls.SetChildIndex(Me.Label66, 0)
        Me.Controls.SetChildIndex(Me.Label67, 0)
        Me.Controls.SetChildIndex(Me.Label70, 0)
        Me.Controls.SetChildIndex(Me.Label69, 0)
        Me.Controls.SetChildIndex(Me.num_KOYO_HOSEI_1, 0)
        Me.Controls.SetChildIndex(Me.Label72, 0)
        Me.Controls.SetChildIndex(Me.Label71, 0)
        Me.Controls.SetChildIndex(Me.Label74, 0)
        Me.Controls.SetChildIndex(Me.Label73, 0)
        Me.Controls.SetChildIndex(Me.Label75, 0)
        Me.Controls.SetChildIndex(Me.num_JIDAI_HOSEI_2, 0)
        Me.Controls.SetChildIndex(Me.Label76, 0)
        Me.Controls.SetChildIndex(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3, 0)
        Me.Controls.SetChildIndex(Me.Label78, 0)
        Me.Controls.SetChildIndex(Me.Label77, 0)
        Me.Controls.SetChildIndex(Me.Label79, 0)
        Me.Controls.SetChildIndex(Me.num_SONOTA_KOTEIHI, 0)
        Me.Controls.SetChildIndex(Me.Label81, 0)
        Me.Controls.SetChildIndex(Me.Label80, 0)
        Me.Controls.SetChildIndex(Me.Label82, 0)
        Me.Controls.SetChildIndex(Me.Label83, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.Label84, 0)
        Me.Controls.SetChildIndex(Me.Label85, 0)
        Me.Controls.SetChildIndex(Me.Label86, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN_TANKA_BET2, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_TANKA, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.Label87, 0)
        Me.Controls.SetChildIndex(Me.Label88, 0)
        Me.Controls.SetChildIndex(Me.Label89, 0)
        Me.Controls.SetChildIndex(Me.Label90, 0)
        Me.Controls.SetChildIndex(Me.Label91, 0)
        Me.Controls.SetChildIndex(Me.Label92, 0)
        Me.Controls.SetChildIndex(Me.Label93, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_HASU, 0)
        Me.Controls.SetChildIndex(Me.num_KOME1HIKU2_CALC, 0)
        Me.Controls.SetChildIndex(Me.num_KOME1HIKU2_DISP, 0)
        Me.Controls.SetChildIndex(Me.Label94, 0)
        Me.Controls.SetChildIndex(Me.Label95, 0)
        Me.Controls.SetChildIndex(Me.Label96, 0)
        Me.Controls.SetChildIndex(Me.Label97, 0)
        Me.Controls.SetChildIndex(Me.num_MARU3, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_TANKA_SAISYU, 0)
        Me.Controls.SetChildIndex(Me.Label98, 0)
        Me.Controls.SetChildIndex(Me.num_KOME1_CALC, 0)
        Me.Controls.SetChildIndex(Me.num_KOME3_CALC, 0)
        Me.Controls.SetChildIndex(Me.Label99, 0)
        Me.Controls.SetChildIndex(Me.num_KOME3_DISP2, 0)
        Me.Controls.SetChildIndex(Me.Label100, 0)
        Me.Controls.SetChildIndex(Me.Label101, 0)
        Me.Controls.SetChildIndex(Me.Label102, 0)
        Me.Controls.SetChildIndex(Me.Label103, 0)
        Me.Controls.SetChildIndex(Me.dateKOFU_KAKUTEI_Ymd, 0)
        Me.Controls.SetChildIndex(Me.rbtnSYORI_JOKYO_KBN_1, 0)
        Me.Controls.SetChildIndex(Me.rbtnSYORI_JOKYO_KBN_2, 0)
        Me.Controls.SetChildIndex(Me.rbtnSYORI_JOKYO_KBN_3, 0)
        Me.Controls.SetChildIndex(Me.lbl_SYORI_JOKYO_KBN_NM, 0)
        Me.Controls.SetChildIndex(Me.Label40, 0)
        Me.Controls.SetChildIndex(Me.num_MARU2, 0)
        Me.Controls.SetChildIndex(Me.num_Syokei5, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_KIN_TANKA_SANTEI8, 0)
        Me.Controls.SetChildIndex(Me.Label68, 0)
        Me.Controls.SetChildIndex(Me.num_KOME1_DISP, 0)
        Me.Controls.SetChildIndex(Me.Label104, 0)
        Me.Controls.SetChildIndex(Me.Label105, 0)
        Me.Controls.SetChildIndex(Me.Label106, 0)
        Me.Controls.SetChildIndex(Me.Label107, 0)
        Me.Controls.SetChildIndex(Me.Label108, 0)
        Me.Controls.SetChildIndex(Me.Label109, 0)
        Me.Controls.SetChildIndex(Me.num_KOME2, 0)
        Me.Controls.SetChildIndex(Me.Label110, 0)
        Me.Controls.SetChildIndex(Me.num_KOME3_DISP1, 0)
        Me.Controls.SetChildIndex(Me.num_KOFU_RITU, 0)
        Me.Controls.SetChildIndex(Me.Label112, 0)
        Me.Controls.SetChildIndex(Me.num_MARU1, 0)
        Me.Controls.SetChildIndex(Me.Label113, 0)
        Me.Controls.SetChildIndex(Me.Label114, 0)
        Me.Controls.SetChildIndex(Me.Label115, 0)
        Me.Controls.SetChildIndex(Me.Label111, 0)
        Me.Controls.SetChildIndex(Me.Label116, 0)
        Me.Controls.SetChildIndex(Me.num_GENGAKU_RITU, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.num_KOYO_JOGEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOYO_ROTIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOYO_KOYO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOYO_HOSEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_JIDAI_HOSEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_JIDAI_JIDAI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_JIDAI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_JIDAI_JOGEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_GENKA_SYOKYAKU_GENKA_SYOKYAKU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_GENKA_SYOKYAKU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_GENKA_JOGEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KUSYA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOYO_HOSEI_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_JIDAI_HOSEI_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_GENKA_SYOKYAKU_GENKA_HOSEI_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_SONOTA_KOTEIHI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN_TANKA_BET2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN_TANKA_SANTEI_JOGEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_TANKA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_HASU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOME1HIKU2_CALC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOME1HIKU2_DISP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_MARU3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_TANKA_SAISYU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOME1_CALC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOME3_CALC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOME3_DISP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateKOFU_KAKUTEI_Ymd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KUSYA_KIKAN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_MARU2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_Syokei5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_KIN_TANKA_SANTEI8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOME1_DISP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOME2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOME3_DISP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_KOFU_RITU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_MARU1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num_GENGAKU_RITU, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents Label23 As JBD.Gjs.Win.Label
    Friend WithEvents Label26 As JBD.Gjs.Win.Label
    Friend WithEvents cmdCansel As JBD.Gjs.Win.JButton
    Friend WithEvents lbl_KEIYAKUSYA_CD As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKUSYA_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_1 As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_2 As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_4 As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_ADDR_3 As JBD.Gjs.Win.JLabel
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents cmdSave As JBD.Gjs.Win.JButton
    Friend WithEvents lbl_NOJO_CD As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_NOJO_NAME As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_TORI_KBN As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_TORI_KBN_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents lbl_KEIYAKU_HASU As JBD.Gjs.Win.JLabel
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_KEIYAKU_KBN As JBD.Gjs.Win.JLabel
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents lbl_KEIYAKU_KBN_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label25 As JBD.Gjs.Win.Label
    Friend WithEvents Label30 As JBD.Gjs.Win.Label
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOYO_JOGEN As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents Label20 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOYO_ROTIN As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label21 As JBD.Gjs.Win.Label
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents Label32 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOYO_KOYO As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label33 As JBD.Gjs.Win.Label
    Friend WithEvents Label34 As JBD.Gjs.Win.Label
    Friend WithEvents Label35 As JBD.Gjs.Win.Label
    Friend WithEvents Label36 As JBD.Gjs.Win.Label
    Friend WithEvents Label37 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOYO_HOSEI As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label38 As JBD.Gjs.Win.Label
    Friend WithEvents num_JIDAI_HOSEI As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label31 As JBD.Gjs.Win.Label
    Friend WithEvents Label41 As JBD.Gjs.Win.Label
    Friend WithEvents Label42 As JBD.Gjs.Win.Label
    Friend WithEvents num_JIDAI_JIDAI As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label43 As JBD.Gjs.Win.Label
    Friend WithEvents Label44 As JBD.Gjs.Win.Label
    Friend WithEvents Label45 As JBD.Gjs.Win.Label
    Friend WithEvents num_JIDAI As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label46 As JBD.Gjs.Win.Label
    Friend WithEvents Label47 As JBD.Gjs.Win.Label
    Friend WithEvents Label48 As JBD.Gjs.Win.Label
    Friend WithEvents num_JIDAI_JOGEN As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label49 As JBD.Gjs.Win.Label
    Friend WithEvents Label50 As JBD.Gjs.Win.Label
    Friend WithEvents num_GENKA_SYOKYAKU_GENKA_HOSEI As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label51 As JBD.Gjs.Win.Label
    Friend WithEvents Label52 As JBD.Gjs.Win.Label
    Friend WithEvents Label53 As JBD.Gjs.Win.Label
    Friend WithEvents num_GENKA_SYOKYAKU_GENKA_SYOKYAKU As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label54 As JBD.Gjs.Win.Label
    Friend WithEvents Label55 As JBD.Gjs.Win.Label
    Friend WithEvents Label56 As JBD.Gjs.Win.Label
    Friend WithEvents num_GENKA_SYOKYAKU As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label57 As JBD.Gjs.Win.Label
    Friend WithEvents Label58 As JBD.Gjs.Win.Label
    Friend WithEvents Label59 As JBD.Gjs.Win.Label
    Friend WithEvents num_GENKA_JOGEN As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label60 As JBD.Gjs.Win.Label
    Friend WithEvents Label61 As JBD.Gjs.Win.Label
    Friend WithEvents Label62 As JBD.Gjs.Win.Label
    Friend WithEvents Label63 As JBD.Gjs.Win.Label
    Friend WithEvents Label64 As JBD.Gjs.Win.Label
    Friend WithEvents Label65 As JBD.Gjs.Win.Label
    Friend WithEvents num_KUSYA As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label66 As JBD.Gjs.Win.Label
    Friend WithEvents Label67 As JBD.Gjs.Win.Label
    Friend WithEvents Label39 As JBD.Gjs.Win.Label
    Friend WithEvents Label70 As JBD.Gjs.Win.Label
    Friend WithEvents Label69 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOYO_HOSEI_1 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label71 As JBD.Gjs.Win.Label
    Friend WithEvents Label72 As JBD.Gjs.Win.Label
    Friend WithEvents Label73 As JBD.Gjs.Win.Label
    Friend WithEvents Label74 As JBD.Gjs.Win.Label
    Friend WithEvents num_JIDAI_HOSEI_2 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label75 As JBD.Gjs.Win.Label
    Friend WithEvents num_GENKA_SYOKYAKU_GENKA_HOSEI_3 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label76 As JBD.Gjs.Win.Label
    Friend WithEvents Label77 As JBD.Gjs.Win.Label
    Friend WithEvents Label78 As JBD.Gjs.Win.Label
    Friend WithEvents Label79 As JBD.Gjs.Win.Label
    Friend WithEvents num_SONOTA_KOTEIHI As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label80 As JBD.Gjs.Win.Label
    Friend WithEvents Label81 As JBD.Gjs.Win.Label
    Friend WithEvents Label82 As JBD.Gjs.Win.Label
    Friend WithEvents Label83 As JBD.Gjs.Win.Label
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents Label84 As JBD.Gjs.Win.Label
    Friend WithEvents Label85 As JBD.Gjs.Win.Label
    Friend WithEvents Label86 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_KIN_TANKA_BET2 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_KIN_TANKA_SANTEI_JOGEN As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_TANKA As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label27 As JBD.Gjs.Win.Label
    Friend WithEvents Label28 As JBD.Gjs.Win.Label
    Friend WithEvents Label87 As JBD.Gjs.Win.Label
    Friend WithEvents Label88 As JBD.Gjs.Win.Label
    Friend WithEvents Label89 As JBD.Gjs.Win.Label
    Friend WithEvents Label90 As JBD.Gjs.Win.Label
    Friend WithEvents Label91 As JBD.Gjs.Win.Label
    Friend WithEvents Label93 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOFU_HASU As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOME1HIKU2_CALC As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOME1HIKU2_DISP As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label94 As JBD.Gjs.Win.Label
    Friend WithEvents Label95 As JBD.Gjs.Win.Label
    Friend WithEvents Label96 As JBD.Gjs.Win.Label
    Friend WithEvents Label97 As JBD.Gjs.Win.Label
    Friend WithEvents num_MARU3 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_TANKA_SAISYU As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label98 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOME1_CALC As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOME3_CALC As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label99 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOME3_DISP2 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label100 As JBD.Gjs.Win.Label
    Friend WithEvents Label101 As JBD.Gjs.Win.Label
    Friend WithEvents Label102 As JBD.Gjs.Win.Label
    Friend WithEvents Label103 As JBD.Gjs.Win.Label
    Friend WithEvents rbtnSYORI_JOKYO_KBN_1 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtnSYORI_JOKYO_KBN_2 As JBD.Gjs.Win.RadioButton
    Friend WithEvents rbtnSYORI_JOKYO_KBN_3 As JBD.Gjs.Win.RadioButton
    Friend WithEvents lbl_SYORI_JOKYO_KBN_NM As JBD.Gjs.Win.JLabel
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents dateKOFU_KAKUTEI_Ymd As JBD.Gjs.Win.GcDate
    Friend WithEvents num_KUSYA_KIKAN As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_MARU2 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label40 As JBD.Gjs.Win.Label
    Friend WithEvents num_Syokei5 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_KIN_TANKA_SANTEI8 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label68 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOME1_DISP As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label104 As JBD.Gjs.Win.Label
    Friend WithEvents Label105 As JBD.Gjs.Win.Label
    Friend WithEvents Label106 As JBD.Gjs.Win.Label
    Friend WithEvents Label107 As JBD.Gjs.Win.Label
    Friend WithEvents Label108 As JBD.Gjs.Win.Label
    Friend WithEvents Label109 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOME2 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label110 As JBD.Gjs.Win.Label
    Friend WithEvents num_KOME3_DISP1 As JBD.Gjs.Win.GcNumber
    Friend WithEvents num_KOFU_RITU As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label112 As JBD.Gjs.Win.Label
    Friend WithEvents num_MARU1 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label113 As JBD.Gjs.Win.Label
    Friend WithEvents Label114 As JBD.Gjs.Win.Label
    Friend WithEvents Label115 As JBD.Gjs.Win.Label
    Friend WithEvents Label111 As JBD.Gjs.Win.Label
    Friend WithEvents Label92 As JBD.Gjs.Win.Label
    Friend WithEvents Label116 As JBD.Gjs.Win.Label
    Friend WithEvents num_GENGAKU_RITU As JBD.Gjs.Win.GcNumber
End Class
