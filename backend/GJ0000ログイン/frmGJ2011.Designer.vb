Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGJ2011
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
        Dim DateEraField1 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField1 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField2 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField1 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField3 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField1 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim DateEraField2 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField4 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateEraYearField2 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateLiteralField5 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateMonthField2 As GrapeCity.Win.Editors.Fields.DateMonthField = New GrapeCity.Win.Editors.Fields.DateMonthField()
        Dim DateLiteralField6 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim DateDayField2 As GrapeCity.Win.Editors.Fields.DateDayField = New GrapeCity.Win.Editors.Fields.DateDayField()
        Dim NumberSignDisplayField1 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField1 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField1 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField1 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess1 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange1 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim ValueProcess2 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange2 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField2 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField2 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField2 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField2 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess3 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange3 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField3 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField3 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField3 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField3 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess4 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange4 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField4 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField4 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField4 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField4 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess5 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange5 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField5 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField5 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField5 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField5 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess6 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange6 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField6 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField6 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField6 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField6 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess7 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange7 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField7 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField7 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField7 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField7 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess8 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange8 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField8 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField8 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField8 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField8 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess9 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange9 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField9 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField9 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField9 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField9 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess10 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange10 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField10 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField10 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField10 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField10 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess11 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange11 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField11 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField11 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField11 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField11 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess12 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange12 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField12 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField12 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess13 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange13 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField13 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField13 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess14 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange14 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField14 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField14 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess15 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange15 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField15 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField15 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess16 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange16 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField16 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField16 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess17 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange17 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField17 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField17 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess18 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange18 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField18 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField18 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess19 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange19 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField19 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField19 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess20 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange20 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField20 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField20 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess21 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange21 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField21 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField21 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess22 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange22 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField22 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField22 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess23 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange23 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField23 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField23 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess24 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange24 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField24 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField24 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess25 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange25 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField25 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField25 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess26 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange26 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField26 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField26 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess27 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange27 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField27 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField27 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess28 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange28 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField28 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField28 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess29 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange29 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField29 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField29 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess30 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange30 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField30 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField30 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess31 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange31 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField31 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField31 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess32 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange32 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField32 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField32 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess33 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange33 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField33 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField33 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess34 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange34 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField34 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField34 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess35 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange35 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField35 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField35 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess36 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange36 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField36 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField36 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess37 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange37 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField37 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField37 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess38 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange38 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField38 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField38 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess39 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange39 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField39 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField39 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess40 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange40 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField40 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField40 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess41 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange41 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField41 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField41 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess42 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange42 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField42 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField42 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess43 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange43 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField43 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField43 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim ValueProcess44 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange44 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField44 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField44 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField12 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField12 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess45 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange45 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField45 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField45 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField13 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField13 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess46 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange46 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField46 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField46 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField14 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField14 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess47 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange47 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField47 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField47 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField15 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField15 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess48 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange48 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField48 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField48 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField16 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField16 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess49 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange49 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim ValueProcess50 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange50 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Me.cob_KenCdFm = New JBD.Gjs.Win.GcComboBox(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.dateTAISYO_DATE_To = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton8 = New GrapeCity.Win.Editors.DropDownButton()
        Me.dateTAISYO_DATE_Fm = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.numTUMITATE_TANKA11 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTESURYO_RITU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA12 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA13 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA14 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA15 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA25 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA24 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA23 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA22 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA21 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA36 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA11 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA12 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA14 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA13 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA21 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA15 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA36 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA25 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA24 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA23 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA22 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA36 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA25 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA24 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA23 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA22 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA21 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA15 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA14 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA13 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA12 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA11 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA41 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA40 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA39 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA38 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numSYOKYAKU_TANKA37 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA41 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA40 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA39 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA38 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKEIEISIEN_TANKA37 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA41 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA40 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA39 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA38 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numTUMITATE_TANKA37 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOFU_RITU = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label116 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label108 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label101 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label102 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label103 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label104 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label105 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label106 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label45 = New JBD.Gjs.Win.Label(Me.components)
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label20 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label23 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label36 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label26 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label27 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label28 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label29 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label30 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label32 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label33 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label34 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label35 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label37 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label31 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label38 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label39 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label40 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label41 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label42 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label43 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label44 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label46 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label47 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label48 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label49 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label50 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label66 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label67 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label68 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label69 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label70 = New JBD.Gjs.Win.Label(Me.components)
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
        Me.Label71 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label72 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.cob_KenCdFm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateTAISYO_DATE_To, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateTAISYO_DATE_Fm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTESURYO_RITU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSYOKYAKU_TANKA37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKEIEISIEN_TANKA37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTUMITATE_TANKA37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOFU_RITU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = ""
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
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
        Me.cmdEnd.TabIndex = 15
        '
        'cob_KenCdFm
        '
        Me.cob_KenCdFm.AllowSpace = GrapeCity.Win.Editors.AllowSpace.None
        Me.cob_KenCdFm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.cob_KenCdFm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cob_KenCdFm.Format = "9"
        Me.cob_KenCdFm.HighlightText = True
        Me.cob_KenCdFm.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cob_KenCdFm.ListHeaderPane.Height = 22
        Me.cob_KenCdFm.Location = New System.Drawing.Point(280, 135)
        Me.cob_KenCdFm.MaxLength = 2
        Me.cob_KenCdFm.Name = "cob_KenCdFm"
        Me.GcShortcut1.SetShortcuts(Me.cob_KenCdFm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.cob_KenCdFm, Object), CType(Me.cob_KenCdFm, Object)}, New String() {"ShortcutClear", "ApplyRecommendedValue"}))
        Me.cob_KenCdFm.Size = New System.Drawing.Size(36, 22)
        Me.cob_KenCdFm.TabIndex = 872
        Me.cob_KenCdFm.Text = "00"
        '
        'dateTAISYO_DATE_To
        '
        Me.dateTAISYO_DATE_To.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField2.Text = "/"
        DateLiteralField3.Text = "/"
        Me.dateTAISYO_DATE_To.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1, DateLiteralField2, DateMonthField1, DateLiteralField3, DateDayField1})
        Me.dateTAISYO_DATE_To.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateTAISYO_DATE_To.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateTAISYO_DATE_To.InputCheck = True
        Me.dateTAISYO_DATE_To.Location = New System.Drawing.Point(335, 67)
        Me.dateTAISYO_DATE_To.Name = "dateTAISYO_DATE_To"
        Me.GcShortcut1.SetShortcuts(Me.dateTAISYO_DATE_To, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateTAISYO_DATE_To, Object), CType(Me.dateTAISYO_DATE_To, Object), CType(Me.dateTAISYO_DATE_To, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateTAISYO_DATE_To.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton8})
        Me.dateTAISYO_DATE_To.Size = New System.Drawing.Size(124, 20)
        Me.dateTAISYO_DATE_To.Spin.AllowSpin = False
        Me.dateTAISYO_DATE_To.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateTAISYO_DATE_To.TabIndex = 2
        Me.dateTAISYO_DATE_To.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton8
        '
        Me.DropDownButton8.Name = "DropDownButton8"
        '
        'dateTAISYO_DATE_Fm
        '
        Me.dateTAISYO_DATE_Fm.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        DateLiteralField5.Text = "/"
        DateLiteralField6.Text = "/"
        Me.dateTAISYO_DATE_Fm.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField2, DateLiteralField4, DateEraYearField2, DateLiteralField5, DateMonthField2, DateLiteralField6, DateDayField2})
        Me.dateTAISYO_DATE_Fm.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateTAISYO_DATE_Fm.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateTAISYO_DATE_Fm.InputCheck = True
        Me.dateTAISYO_DATE_Fm.Location = New System.Drawing.Point(174, 67)
        Me.dateTAISYO_DATE_Fm.Name = "dateTAISYO_DATE_Fm"
        Me.GcShortcut1.SetShortcuts(Me.dateTAISYO_DATE_Fm, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateTAISYO_DATE_Fm, Object), CType(Me.dateTAISYO_DATE_Fm, Object), CType(Me.dateTAISYO_DATE_Fm, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateTAISYO_DATE_Fm.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.dateTAISYO_DATE_Fm.Size = New System.Drawing.Size(124, 20)
        Me.dateTAISYO_DATE_Fm.Spin.AllowSpin = False
        Me.dateTAISYO_DATE_Fm.TabAction = GrapeCity.Win.Editors.TabAction.Field
        Me.dateTAISYO_DATE_Fm.TabIndex = 1
        Me.dateTAISYO_DATE_Fm.Value = New Date(2015, 1, 15, 0, 0, 0, 0)
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'numTUMITATE_TANKA11
        '
        Me.numTUMITATE_TANKA11.AllowDeleteToNull = True
        NumberIntegerPartDisplayField1.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField1.MaxDigits = 1
        NumberDecimalPartDisplayField1.MinDigits = 1
        Me.numTUMITATE_TANKA11.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField1, NumberIntegerPartDisplayField1, NumberDecimalSeparatorDisplayField1, NumberDecimalPartDisplayField1})
        Me.numTUMITATE_TANKA11.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA11.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA11.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA11.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA11.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA11.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA11.HighlightText = True
        Me.numTUMITATE_TANKA11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA11.InputCheck = True
        Me.numTUMITATE_TANKA11.Location = New System.Drawing.Point(404, 175)
        Me.numTUMITATE_TANKA11.Name = "numTUMITATE_TANKA11"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA11, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA11, Object), CType(Me.numTUMITATE_TANKA11, Object), CType(Me.numTUMITATE_TANKA11, Object), CType(Me.numTUMITATE_TANKA11, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA11.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA11.Spin.Increment = 0
        Me.numTUMITATE_TANKA11.TabIndex = 11
        ValueProcess1.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA11).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess1})
        InvalidRange1.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange1.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA11).AddRange(New Object() {InvalidRange1})
        Me.numTUMITATE_TANKA11.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA11.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTESURYO_RITU
        '
        Me.numTESURYO_RITU.AllowDeleteToNull = True
        Me.numTESURYO_RITU.DropDown.AllowDrop = False
        Me.numTESURYO_RITU.Fields.DecimalPart.MaxDigits = 0
        Me.numTESURYO_RITU.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTESURYO_RITU.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numTESURYO_RITU.Fields.IntegerPart.MaxDigits = 2
        Me.numTESURYO_RITU.Fields.IntegerPart.MinDigits = 1
        Me.numTESURYO_RITU.Fields.SignPrefix.NegativePattern = ""
        Me.numTESURYO_RITU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTESURYO_RITU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTESURYO_RITU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTESURYO_RITU.InputCheck = True
        Me.numTESURYO_RITU.Location = New System.Drawing.Point(174, 594)
        Me.numTESURYO_RITU.Name = "numTESURYO_RITU"
        Me.GcShortcut1.SetShortcuts(Me.numTESURYO_RITU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTESURYO_RITU, Object), CType(Me.numTESURYO_RITU, Object), CType(Me.numTESURYO_RITU, Object), CType(Me.numTESURYO_RITU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTESURYO_RITU.Size = New System.Drawing.Size(36, 20)
        Me.numTESURYO_RITU.Spin.Increment = 0
        Me.numTESURYO_RITU.TabIndex = 71
        ValueProcess2.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTESURYO_RITU).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess2})
        InvalidRange2.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        InvalidRange2.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numTESURYO_RITU).AddRange(New Object() {InvalidRange2})
        Me.numTESURYO_RITU.Value = New Decimal(New Integer() {99, 0, 0, 0})
        Me.numTESURYO_RITU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA12
        '
        Me.numTUMITATE_TANKA12.AllowDeleteToNull = True
        NumberIntegerPartDisplayField2.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField2.MaxDigits = 1
        NumberDecimalPartDisplayField2.MinDigits = 1
        Me.numTUMITATE_TANKA12.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField2, NumberIntegerPartDisplayField2, NumberDecimalSeparatorDisplayField2, NumberDecimalPartDisplayField2})
        Me.numTUMITATE_TANKA12.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA12.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA12.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA12.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA12.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA12.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA12.HighlightText = True
        Me.numTUMITATE_TANKA12.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA12.InputCheck = True
        Me.numTUMITATE_TANKA12.Location = New System.Drawing.Point(404, 200)
        Me.numTUMITATE_TANKA12.Name = "numTUMITATE_TANKA12"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA12, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA12, Object), CType(Me.numTUMITATE_TANKA12, Object), CType(Me.numTUMITATE_TANKA12, Object), CType(Me.numTUMITATE_TANKA12, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA12.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA12.Spin.Increment = 0
        Me.numTUMITATE_TANKA12.TabIndex = 14
        ValueProcess3.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA12).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess3})
        InvalidRange3.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange3.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA12).AddRange(New Object() {InvalidRange3})
        Me.numTUMITATE_TANKA12.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA12.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA13
        '
        Me.numTUMITATE_TANKA13.AllowDeleteToNull = True
        NumberIntegerPartDisplayField3.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField3.MaxDigits = 1
        NumberDecimalPartDisplayField3.MinDigits = 1
        Me.numTUMITATE_TANKA13.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField3, NumberIntegerPartDisplayField3, NumberDecimalSeparatorDisplayField3, NumberDecimalPartDisplayField3})
        Me.numTUMITATE_TANKA13.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA13.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA13.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA13.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA13.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA13.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA13.HighlightText = True
        Me.numTUMITATE_TANKA13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA13.InputCheck = True
        Me.numTUMITATE_TANKA13.Location = New System.Drawing.Point(404, 225)
        Me.numTUMITATE_TANKA13.Name = "numTUMITATE_TANKA13"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA13, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA13, Object), CType(Me.numTUMITATE_TANKA13, Object), CType(Me.numTUMITATE_TANKA13, Object), CType(Me.numTUMITATE_TANKA13, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA13.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA13.Spin.Increment = 0
        Me.numTUMITATE_TANKA13.TabIndex = 17
        ValueProcess4.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA13).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess4})
        InvalidRange4.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange4.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA13).AddRange(New Object() {InvalidRange4})
        Me.numTUMITATE_TANKA13.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA13.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA14
        '
        Me.numTUMITATE_TANKA14.AllowDeleteToNull = True
        NumberIntegerPartDisplayField4.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField4.MaxDigits = 1
        NumberDecimalPartDisplayField4.MinDigits = 1
        Me.numTUMITATE_TANKA14.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField4, NumberIntegerPartDisplayField4, NumberDecimalSeparatorDisplayField4, NumberDecimalPartDisplayField4})
        Me.numTUMITATE_TANKA14.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA14.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA14.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA14.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA14.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA14.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA14.HighlightText = True
        Me.numTUMITATE_TANKA14.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA14.InputCheck = True
        Me.numTUMITATE_TANKA14.Location = New System.Drawing.Point(404, 250)
        Me.numTUMITATE_TANKA14.Name = "numTUMITATE_TANKA14"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA14, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA14, Object), CType(Me.numTUMITATE_TANKA14, Object), CType(Me.numTUMITATE_TANKA14, Object), CType(Me.numTUMITATE_TANKA14, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA14.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA14.Spin.Increment = 0
        Me.numTUMITATE_TANKA14.TabIndex = 20
        ValueProcess5.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA14).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess5})
        InvalidRange5.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange5.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA14).AddRange(New Object() {InvalidRange5})
        Me.numTUMITATE_TANKA14.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA14.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA15
        '
        Me.numTUMITATE_TANKA15.AllowDeleteToNull = True
        NumberIntegerPartDisplayField5.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField5.MaxDigits = 1
        NumberDecimalPartDisplayField5.MinDigits = 1
        Me.numTUMITATE_TANKA15.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField5, NumberIntegerPartDisplayField5, NumberDecimalSeparatorDisplayField5, NumberDecimalPartDisplayField5})
        Me.numTUMITATE_TANKA15.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA15.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA15.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA15.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA15.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA15.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA15.HighlightText = True
        Me.numTUMITATE_TANKA15.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA15.InputCheck = True
        Me.numTUMITATE_TANKA15.Location = New System.Drawing.Point(404, 275)
        Me.numTUMITATE_TANKA15.Name = "numTUMITATE_TANKA15"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA15, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA15, Object), CType(Me.numTUMITATE_TANKA15, Object), CType(Me.numTUMITATE_TANKA15, Object), CType(Me.numTUMITATE_TANKA15, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA15.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA15.Spin.Increment = 0
        Me.numTUMITATE_TANKA15.TabIndex = 23
        ValueProcess6.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA15).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess6})
        InvalidRange6.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange6.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA15).AddRange(New Object() {InvalidRange6})
        Me.numTUMITATE_TANKA15.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA15.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA25
        '
        Me.numTUMITATE_TANKA25.AllowDeleteToNull = True
        NumberIntegerPartDisplayField6.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField6.MaxDigits = 1
        NumberDecimalPartDisplayField6.MinDigits = 1
        Me.numTUMITATE_TANKA25.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField6, NumberIntegerPartDisplayField6, NumberDecimalSeparatorDisplayField6, NumberDecimalPartDisplayField6})
        Me.numTUMITATE_TANKA25.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA25.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA25.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA25.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA25.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA25.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA25.HighlightText = True
        Me.numTUMITATE_TANKA25.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA25.InputCheck = True
        Me.numTUMITATE_TANKA25.Location = New System.Drawing.Point(404, 400)
        Me.numTUMITATE_TANKA25.Name = "numTUMITATE_TANKA25"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA25, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA25, Object), CType(Me.numTUMITATE_TANKA25, Object), CType(Me.numTUMITATE_TANKA25, Object), CType(Me.numTUMITATE_TANKA25, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA25.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA25.Spin.Increment = 0
        Me.numTUMITATE_TANKA25.TabIndex = 43
        ValueProcess7.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA25).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess7})
        InvalidRange7.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange7.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA25).AddRange(New Object() {InvalidRange7})
        Me.numTUMITATE_TANKA25.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA25.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA24
        '
        Me.numTUMITATE_TANKA24.AllowDeleteToNull = True
        NumberIntegerPartDisplayField7.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField7.MaxDigits = 1
        NumberDecimalPartDisplayField7.MinDigits = 1
        Me.numTUMITATE_TANKA24.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField7, NumberIntegerPartDisplayField7, NumberDecimalSeparatorDisplayField7, NumberDecimalPartDisplayField7})
        Me.numTUMITATE_TANKA24.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA24.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA24.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA24.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA24.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA24.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA24.HighlightText = True
        Me.numTUMITATE_TANKA24.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA24.InputCheck = True
        Me.numTUMITATE_TANKA24.Location = New System.Drawing.Point(404, 375)
        Me.numTUMITATE_TANKA24.Name = "numTUMITATE_TANKA24"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA24, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA24, Object), CType(Me.numTUMITATE_TANKA24, Object), CType(Me.numTUMITATE_TANKA24, Object), CType(Me.numTUMITATE_TANKA24, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA24.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA24.Spin.Increment = 0
        Me.numTUMITATE_TANKA24.TabIndex = 40
        ValueProcess8.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA24).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess8})
        InvalidRange8.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange8.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA24).AddRange(New Object() {InvalidRange8})
        Me.numTUMITATE_TANKA24.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA24.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA23
        '
        Me.numTUMITATE_TANKA23.AllowDeleteToNull = True
        NumberIntegerPartDisplayField8.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField8.MaxDigits = 1
        NumberDecimalPartDisplayField8.MinDigits = 1
        Me.numTUMITATE_TANKA23.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField8, NumberIntegerPartDisplayField8, NumberDecimalSeparatorDisplayField8, NumberDecimalPartDisplayField8})
        Me.numTUMITATE_TANKA23.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA23.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA23.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA23.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA23.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA23.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA23.HighlightText = True
        Me.numTUMITATE_TANKA23.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA23.InputCheck = True
        Me.numTUMITATE_TANKA23.Location = New System.Drawing.Point(404, 350)
        Me.numTUMITATE_TANKA23.Name = "numTUMITATE_TANKA23"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA23, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA23, Object), CType(Me.numTUMITATE_TANKA23, Object), CType(Me.numTUMITATE_TANKA23, Object), CType(Me.numTUMITATE_TANKA23, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA23.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA23.Spin.Increment = 0
        Me.numTUMITATE_TANKA23.TabIndex = 37
        ValueProcess9.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA23).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess9})
        InvalidRange9.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange9.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA23).AddRange(New Object() {InvalidRange9})
        Me.numTUMITATE_TANKA23.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA23.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA22
        '
        Me.numTUMITATE_TANKA22.AllowDeleteToNull = True
        NumberIntegerPartDisplayField9.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField9.MaxDigits = 1
        NumberDecimalPartDisplayField9.MinDigits = 1
        Me.numTUMITATE_TANKA22.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField9, NumberIntegerPartDisplayField9, NumberDecimalSeparatorDisplayField9, NumberDecimalPartDisplayField9})
        Me.numTUMITATE_TANKA22.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA22.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA22.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA22.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA22.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA22.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA22.HighlightText = True
        Me.numTUMITATE_TANKA22.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA22.InputCheck = True
        Me.numTUMITATE_TANKA22.Location = New System.Drawing.Point(404, 325)
        Me.numTUMITATE_TANKA22.Name = "numTUMITATE_TANKA22"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA22, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA22, Object), CType(Me.numTUMITATE_TANKA22, Object), CType(Me.numTUMITATE_TANKA22, Object), CType(Me.numTUMITATE_TANKA22, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA22.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA22.Spin.Increment = 0
        Me.numTUMITATE_TANKA22.TabIndex = 34
        ValueProcess10.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA22).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess10})
        InvalidRange10.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange10.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA22).AddRange(New Object() {InvalidRange10})
        Me.numTUMITATE_TANKA22.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA22.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA21
        '
        Me.numTUMITATE_TANKA21.AllowDeleteToNull = True
        NumberIntegerPartDisplayField10.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField10.MaxDigits = 1
        NumberDecimalPartDisplayField10.MinDigits = 1
        Me.numTUMITATE_TANKA21.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField10, NumberIntegerPartDisplayField10, NumberDecimalSeparatorDisplayField10, NumberDecimalPartDisplayField10})
        Me.numTUMITATE_TANKA21.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA21.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA21.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA21.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA21.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA21.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA21.HighlightText = True
        Me.numTUMITATE_TANKA21.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA21.InputCheck = True
        Me.numTUMITATE_TANKA21.Location = New System.Drawing.Point(404, 300)
        Me.numTUMITATE_TANKA21.Name = "numTUMITATE_TANKA21"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA21, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA21, Object), CType(Me.numTUMITATE_TANKA21, Object), CType(Me.numTUMITATE_TANKA21, Object), CType(Me.numTUMITATE_TANKA21, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA21.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA21.Spin.Increment = 0
        Me.numTUMITATE_TANKA21.TabIndex = 31
        ValueProcess11.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA21).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess11})
        InvalidRange11.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange11.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA21).AddRange(New Object() {InvalidRange11})
        Me.numTUMITATE_TANKA21.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA21.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA36
        '
        Me.numTUMITATE_TANKA36.AllowDeleteToNull = True
        NumberIntegerPartDisplayField11.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField11.MaxDigits = 1
        NumberDecimalPartDisplayField11.MinDigits = 1
        Me.numTUMITATE_TANKA36.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField11, NumberIntegerPartDisplayField11, NumberDecimalSeparatorDisplayField11, NumberDecimalPartDisplayField11})
        Me.numTUMITATE_TANKA36.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA36.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA36.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA36.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA36.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA36.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA36.HighlightText = True
        Me.numTUMITATE_TANKA36.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA36.InputCheck = True
        Me.numTUMITATE_TANKA36.Location = New System.Drawing.Point(404, 425)
        Me.numTUMITATE_TANKA36.Name = "numTUMITATE_TANKA36"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA36, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA36, Object), CType(Me.numTUMITATE_TANKA36, Object), CType(Me.numTUMITATE_TANKA36, Object), CType(Me.numTUMITATE_TANKA36, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA36.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA36.Spin.Increment = 0
        Me.numTUMITATE_TANKA36.TabIndex = 51
        ValueProcess12.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA36).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess12})
        InvalidRange12.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange12.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA36).AddRange(New Object() {InvalidRange12})
        Me.numTUMITATE_TANKA36.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA36.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA11
        '
        Me.numKEIEISIEN_TANKA11.AllowDeleteToNull = True
        NumberIntegerPartDisplayField12.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField12.MinDigits = 0
        Me.numKEIEISIEN_TANKA11.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField12, NumberIntegerPartDisplayField12})
        Me.numKEIEISIEN_TANKA11.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA11.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA11.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA11.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA11.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA11.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA11.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA11.HighlightText = True
        Me.numKEIEISIEN_TANKA11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA11.InputCheck = True
        Me.numKEIEISIEN_TANKA11.Location = New System.Drawing.Point(528, 175)
        Me.numKEIEISIEN_TANKA11.Name = "numKEIEISIEN_TANKA11"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA11, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA11, Object), CType(Me.numKEIEISIEN_TANKA11, Object), CType(Me.numKEIEISIEN_TANKA11, Object), CType(Me.numKEIEISIEN_TANKA11, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA11.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA11.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA11.TabIndex = 12
        ValueProcess13.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA11).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess13})
        InvalidRange13.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange13.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA11).AddRange(New Object() {InvalidRange13})
        Me.numKEIEISIEN_TANKA11.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA11.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA12
        '
        Me.numKEIEISIEN_TANKA12.AllowDeleteToNull = True
        NumberIntegerPartDisplayField13.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField13.MinDigits = 0
        Me.numKEIEISIEN_TANKA12.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField13, NumberIntegerPartDisplayField13})
        Me.numKEIEISIEN_TANKA12.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA12.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA12.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA12.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA12.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA12.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA12.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA12.HighlightText = True
        Me.numKEIEISIEN_TANKA12.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA12.InputCheck = True
        Me.numKEIEISIEN_TANKA12.Location = New System.Drawing.Point(528, 200)
        Me.numKEIEISIEN_TANKA12.Name = "numKEIEISIEN_TANKA12"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA12, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA12, Object), CType(Me.numKEIEISIEN_TANKA12, Object), CType(Me.numKEIEISIEN_TANKA12, Object), CType(Me.numKEIEISIEN_TANKA12, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA12.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA12.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA12.TabIndex = 15
        ValueProcess14.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA12).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess14})
        InvalidRange14.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange14.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA12).AddRange(New Object() {InvalidRange14})
        Me.numKEIEISIEN_TANKA12.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA12.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA14
        '
        Me.numKEIEISIEN_TANKA14.AllowDeleteToNull = True
        NumberIntegerPartDisplayField14.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField14.MinDigits = 0
        Me.numKEIEISIEN_TANKA14.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField14, NumberIntegerPartDisplayField14})
        Me.numKEIEISIEN_TANKA14.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA14.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA14.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA14.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA14.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA14.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA14.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA14.HighlightText = True
        Me.numKEIEISIEN_TANKA14.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA14.InputCheck = True
        Me.numKEIEISIEN_TANKA14.Location = New System.Drawing.Point(528, 250)
        Me.numKEIEISIEN_TANKA14.Name = "numKEIEISIEN_TANKA14"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA14, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA14, Object), CType(Me.numKEIEISIEN_TANKA14, Object), CType(Me.numKEIEISIEN_TANKA14, Object), CType(Me.numKEIEISIEN_TANKA14, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA14.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA14.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA14.TabIndex = 21
        ValueProcess15.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA14).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess15})
        InvalidRange15.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange15.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA14).AddRange(New Object() {InvalidRange15})
        Me.numKEIEISIEN_TANKA14.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA14.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA13
        '
        Me.numKEIEISIEN_TANKA13.AllowDeleteToNull = True
        NumberIntegerPartDisplayField15.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField15.MinDigits = 0
        Me.numKEIEISIEN_TANKA13.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField15, NumberIntegerPartDisplayField15})
        Me.numKEIEISIEN_TANKA13.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA13.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA13.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA13.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA13.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA13.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA13.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA13.HighlightText = True
        Me.numKEIEISIEN_TANKA13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA13.InputCheck = True
        Me.numKEIEISIEN_TANKA13.Location = New System.Drawing.Point(528, 225)
        Me.numKEIEISIEN_TANKA13.Name = "numKEIEISIEN_TANKA13"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA13, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA13, Object), CType(Me.numKEIEISIEN_TANKA13, Object), CType(Me.numKEIEISIEN_TANKA13, Object), CType(Me.numKEIEISIEN_TANKA13, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA13.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA13.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA13.TabIndex = 18
        ValueProcess16.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA13).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess16})
        InvalidRange16.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange16.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA13).AddRange(New Object() {InvalidRange16})
        Me.numKEIEISIEN_TANKA13.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA13.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA21
        '
        Me.numKEIEISIEN_TANKA21.AllowDeleteToNull = True
        NumberIntegerPartDisplayField16.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField16.MinDigits = 0
        Me.numKEIEISIEN_TANKA21.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField16, NumberIntegerPartDisplayField16})
        Me.numKEIEISIEN_TANKA21.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA21.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA21.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA21.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA21.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA21.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA21.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA21.HighlightText = True
        Me.numKEIEISIEN_TANKA21.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA21.InputCheck = True
        Me.numKEIEISIEN_TANKA21.Location = New System.Drawing.Point(528, 300)
        Me.numKEIEISIEN_TANKA21.Name = "numKEIEISIEN_TANKA21"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA21, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA21, Object), CType(Me.numKEIEISIEN_TANKA21, Object), CType(Me.numKEIEISIEN_TANKA21, Object), CType(Me.numKEIEISIEN_TANKA21, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA21.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA21.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA21.TabIndex = 32
        ValueProcess17.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA21).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess17})
        InvalidRange17.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange17.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA21).AddRange(New Object() {InvalidRange17})
        Me.numKEIEISIEN_TANKA21.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA21.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA15
        '
        Me.numKEIEISIEN_TANKA15.AllowDeleteToNull = True
        NumberIntegerPartDisplayField17.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField17.MinDigits = 0
        Me.numKEIEISIEN_TANKA15.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField17, NumberIntegerPartDisplayField17})
        Me.numKEIEISIEN_TANKA15.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA15.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA15.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA15.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA15.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA15.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA15.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA15.HighlightText = True
        Me.numKEIEISIEN_TANKA15.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA15.InputCheck = True
        Me.numKEIEISIEN_TANKA15.Location = New System.Drawing.Point(528, 275)
        Me.numKEIEISIEN_TANKA15.Name = "numKEIEISIEN_TANKA15"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA15, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA15, Object), CType(Me.numKEIEISIEN_TANKA15, Object), CType(Me.numKEIEISIEN_TANKA15, Object), CType(Me.numKEIEISIEN_TANKA15, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA15.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA15.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA15.TabIndex = 24
        ValueProcess18.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA15).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess18})
        InvalidRange18.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange18.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA15).AddRange(New Object() {InvalidRange18})
        Me.numKEIEISIEN_TANKA15.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA15.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA36
        '
        Me.numKEIEISIEN_TANKA36.AllowDeleteToNull = True
        NumberIntegerPartDisplayField18.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField18.MinDigits = 0
        Me.numKEIEISIEN_TANKA36.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField18, NumberIntegerPartDisplayField18})
        Me.numKEIEISIEN_TANKA36.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA36.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA36.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA36.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA36.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA36.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA36.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA36.HighlightText = True
        Me.numKEIEISIEN_TANKA36.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA36.InputCheck = True
        Me.numKEIEISIEN_TANKA36.Location = New System.Drawing.Point(528, 425)
        Me.numKEIEISIEN_TANKA36.Name = "numKEIEISIEN_TANKA36"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA36, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA36, Object), CType(Me.numKEIEISIEN_TANKA36, Object), CType(Me.numKEIEISIEN_TANKA36, Object), CType(Me.numKEIEISIEN_TANKA36, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA36.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA36.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA36.TabIndex = 52
        ValueProcess19.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA36).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess19})
        InvalidRange19.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange19.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA36).AddRange(New Object() {InvalidRange19})
        Me.numKEIEISIEN_TANKA36.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA36.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA25
        '
        Me.numKEIEISIEN_TANKA25.AllowDeleteToNull = True
        NumberIntegerPartDisplayField19.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField19.MinDigits = 0
        Me.numKEIEISIEN_TANKA25.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField19, NumberIntegerPartDisplayField19})
        Me.numKEIEISIEN_TANKA25.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA25.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA25.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA25.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA25.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA25.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA25.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA25.HighlightText = True
        Me.numKEIEISIEN_TANKA25.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA25.InputCheck = True
        Me.numKEIEISIEN_TANKA25.Location = New System.Drawing.Point(528, 400)
        Me.numKEIEISIEN_TANKA25.Name = "numKEIEISIEN_TANKA25"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA25, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA25, Object), CType(Me.numKEIEISIEN_TANKA25, Object), CType(Me.numKEIEISIEN_TANKA25, Object), CType(Me.numKEIEISIEN_TANKA25, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA25.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA25.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA25.TabIndex = 44
        ValueProcess20.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA25).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess20})
        InvalidRange20.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange20.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA25).AddRange(New Object() {InvalidRange20})
        Me.numKEIEISIEN_TANKA25.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA25.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA24
        '
        Me.numKEIEISIEN_TANKA24.AllowDeleteToNull = True
        NumberIntegerPartDisplayField20.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField20.MinDigits = 0
        Me.numKEIEISIEN_TANKA24.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField20, NumberIntegerPartDisplayField20})
        Me.numKEIEISIEN_TANKA24.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA24.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA24.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA24.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA24.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA24.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA24.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA24.HighlightText = True
        Me.numKEIEISIEN_TANKA24.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA24.InputCheck = True
        Me.numKEIEISIEN_TANKA24.Location = New System.Drawing.Point(528, 375)
        Me.numKEIEISIEN_TANKA24.Name = "numKEIEISIEN_TANKA24"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA24, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA24, Object), CType(Me.numKEIEISIEN_TANKA24, Object), CType(Me.numKEIEISIEN_TANKA24, Object), CType(Me.numKEIEISIEN_TANKA24, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA24.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA24.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA24.TabIndex = 41
        ValueProcess21.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA24).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess21})
        InvalidRange21.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange21.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA24).AddRange(New Object() {InvalidRange21})
        Me.numKEIEISIEN_TANKA24.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA24.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA23
        '
        Me.numKEIEISIEN_TANKA23.AllowDeleteToNull = True
        NumberIntegerPartDisplayField21.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField21.MinDigits = 0
        Me.numKEIEISIEN_TANKA23.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField21, NumberIntegerPartDisplayField21})
        Me.numKEIEISIEN_TANKA23.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA23.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA23.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA23.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA23.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA23.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA23.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA23.HighlightText = True
        Me.numKEIEISIEN_TANKA23.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA23.InputCheck = True
        Me.numKEIEISIEN_TANKA23.Location = New System.Drawing.Point(528, 350)
        Me.numKEIEISIEN_TANKA23.Name = "numKEIEISIEN_TANKA23"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA23, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA23, Object), CType(Me.numKEIEISIEN_TANKA23, Object), CType(Me.numKEIEISIEN_TANKA23, Object), CType(Me.numKEIEISIEN_TANKA23, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA23.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA23.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA23.TabIndex = 38
        ValueProcess22.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA23).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess22})
        InvalidRange22.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange22.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA23).AddRange(New Object() {InvalidRange22})
        Me.numKEIEISIEN_TANKA23.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA23.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA22
        '
        Me.numKEIEISIEN_TANKA22.AllowDeleteToNull = True
        NumberIntegerPartDisplayField22.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField22.MinDigits = 0
        Me.numKEIEISIEN_TANKA22.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField22, NumberIntegerPartDisplayField22})
        Me.numKEIEISIEN_TANKA22.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA22.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA22.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA22.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA22.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA22.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA22.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA22.HighlightText = True
        Me.numKEIEISIEN_TANKA22.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA22.InputCheck = True
        Me.numKEIEISIEN_TANKA22.Location = New System.Drawing.Point(528, 325)
        Me.numKEIEISIEN_TANKA22.Name = "numKEIEISIEN_TANKA22"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA22, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA22, Object), CType(Me.numKEIEISIEN_TANKA22, Object), CType(Me.numKEIEISIEN_TANKA22, Object), CType(Me.numKEIEISIEN_TANKA22, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA22.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA22.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA22.TabIndex = 35
        ValueProcess23.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA22).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess23})
        InvalidRange23.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange23.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA22).AddRange(New Object() {InvalidRange23})
        Me.numKEIEISIEN_TANKA22.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA22.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA36
        '
        Me.numSYOKYAKU_TANKA36.AllowDeleteToNull = True
        NumberIntegerPartDisplayField23.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField23.MinDigits = 0
        Me.numSYOKYAKU_TANKA36.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField23, NumberIntegerPartDisplayField23})
        Me.numSYOKYAKU_TANKA36.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA36.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA36.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA36.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA36.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA36.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA36.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA36.HighlightText = True
        Me.numSYOKYAKU_TANKA36.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA36.InputCheck = True
        Me.numSYOKYAKU_TANKA36.Location = New System.Drawing.Point(666, 425)
        Me.numSYOKYAKU_TANKA36.Name = "numSYOKYAKU_TANKA36"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA36, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA36, Object), CType(Me.numSYOKYAKU_TANKA36, Object), CType(Me.numSYOKYAKU_TANKA36, Object), CType(Me.numSYOKYAKU_TANKA36, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA36.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA36.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA36.TabIndex = 53
        ValueProcess24.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA36).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess24})
        InvalidRange24.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange24.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA36).AddRange(New Object() {InvalidRange24})
        Me.numSYOKYAKU_TANKA36.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA36.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA25
        '
        Me.numSYOKYAKU_TANKA25.AllowDeleteToNull = True
        NumberIntegerPartDisplayField24.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField24.MinDigits = 0
        Me.numSYOKYAKU_TANKA25.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField24, NumberIntegerPartDisplayField24})
        Me.numSYOKYAKU_TANKA25.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA25.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA25.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA25.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA25.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA25.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA25.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA25.HighlightText = True
        Me.numSYOKYAKU_TANKA25.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA25.InputCheck = True
        Me.numSYOKYAKU_TANKA25.Location = New System.Drawing.Point(666, 400)
        Me.numSYOKYAKU_TANKA25.Name = "numSYOKYAKU_TANKA25"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA25, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA25, Object), CType(Me.numSYOKYAKU_TANKA25, Object), CType(Me.numSYOKYAKU_TANKA25, Object), CType(Me.numSYOKYAKU_TANKA25, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA25.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA25.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA25.TabIndex = 45
        ValueProcess25.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA25).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess25})
        InvalidRange25.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange25.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA25).AddRange(New Object() {InvalidRange25})
        Me.numSYOKYAKU_TANKA25.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA25.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA24
        '
        Me.numSYOKYAKU_TANKA24.AllowDeleteToNull = True
        NumberIntegerPartDisplayField25.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField25.MinDigits = 0
        Me.numSYOKYAKU_TANKA24.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField25, NumberIntegerPartDisplayField25})
        Me.numSYOKYAKU_TANKA24.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA24.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA24.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA24.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA24.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA24.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA24.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA24.HighlightText = True
        Me.numSYOKYAKU_TANKA24.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA24.InputCheck = True
        Me.numSYOKYAKU_TANKA24.Location = New System.Drawing.Point(666, 375)
        Me.numSYOKYAKU_TANKA24.Name = "numSYOKYAKU_TANKA24"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA24, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA24, Object), CType(Me.numSYOKYAKU_TANKA24, Object), CType(Me.numSYOKYAKU_TANKA24, Object), CType(Me.numSYOKYAKU_TANKA24, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA24.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA24.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA24.TabIndex = 42
        ValueProcess26.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA24).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess26})
        InvalidRange26.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange26.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA24).AddRange(New Object() {InvalidRange26})
        Me.numSYOKYAKU_TANKA24.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA24.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA23
        '
        Me.numSYOKYAKU_TANKA23.AllowDeleteToNull = True
        NumberIntegerPartDisplayField26.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField26.MinDigits = 0
        Me.numSYOKYAKU_TANKA23.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField26, NumberIntegerPartDisplayField26})
        Me.numSYOKYAKU_TANKA23.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA23.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA23.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA23.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA23.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA23.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA23.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA23.HighlightText = True
        Me.numSYOKYAKU_TANKA23.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA23.InputCheck = True
        Me.numSYOKYAKU_TANKA23.Location = New System.Drawing.Point(666, 350)
        Me.numSYOKYAKU_TANKA23.Name = "numSYOKYAKU_TANKA23"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA23, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA23, Object), CType(Me.numSYOKYAKU_TANKA23, Object), CType(Me.numSYOKYAKU_TANKA23, Object), CType(Me.numSYOKYAKU_TANKA23, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA23.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA23.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA23.TabIndex = 39
        ValueProcess27.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA23).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess27})
        InvalidRange27.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange27.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA23).AddRange(New Object() {InvalidRange27})
        Me.numSYOKYAKU_TANKA23.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA23.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA22
        '
        Me.numSYOKYAKU_TANKA22.AllowDeleteToNull = True
        NumberIntegerPartDisplayField27.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField27.MinDigits = 0
        Me.numSYOKYAKU_TANKA22.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField27, NumberIntegerPartDisplayField27})
        Me.numSYOKYAKU_TANKA22.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA22.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA22.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA22.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA22.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA22.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA22.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA22.HighlightText = True
        Me.numSYOKYAKU_TANKA22.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA22.InputCheck = True
        Me.numSYOKYAKU_TANKA22.Location = New System.Drawing.Point(666, 325)
        Me.numSYOKYAKU_TANKA22.Name = "numSYOKYAKU_TANKA22"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA22, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA22, Object), CType(Me.numSYOKYAKU_TANKA22, Object), CType(Me.numSYOKYAKU_TANKA22, Object), CType(Me.numSYOKYAKU_TANKA22, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA22.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA22.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA22.TabIndex = 36
        ValueProcess28.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA22).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess28})
        InvalidRange28.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange28.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA22).AddRange(New Object() {InvalidRange28})
        Me.numSYOKYAKU_TANKA22.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA22.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA21
        '
        Me.numSYOKYAKU_TANKA21.AllowDeleteToNull = True
        NumberIntegerPartDisplayField28.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField28.MinDigits = 0
        Me.numSYOKYAKU_TANKA21.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField28, NumberIntegerPartDisplayField28})
        Me.numSYOKYAKU_TANKA21.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA21.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA21.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA21.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA21.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA21.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA21.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA21.HighlightText = True
        Me.numSYOKYAKU_TANKA21.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA21.InputCheck = True
        Me.numSYOKYAKU_TANKA21.Location = New System.Drawing.Point(666, 300)
        Me.numSYOKYAKU_TANKA21.Name = "numSYOKYAKU_TANKA21"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA21, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA21, Object), CType(Me.numSYOKYAKU_TANKA21, Object), CType(Me.numSYOKYAKU_TANKA21, Object), CType(Me.numSYOKYAKU_TANKA21, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA21.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA21.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA21.TabIndex = 33
        ValueProcess29.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA21).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess29})
        InvalidRange29.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange29.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA21).AddRange(New Object() {InvalidRange29})
        Me.numSYOKYAKU_TANKA21.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA21.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA15
        '
        Me.numSYOKYAKU_TANKA15.AllowDeleteToNull = True
        NumberIntegerPartDisplayField29.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField29.MinDigits = 0
        Me.numSYOKYAKU_TANKA15.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField29, NumberIntegerPartDisplayField29})
        Me.numSYOKYAKU_TANKA15.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA15.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA15.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA15.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA15.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA15.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA15.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA15.HighlightText = True
        Me.numSYOKYAKU_TANKA15.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA15.InputCheck = True
        Me.numSYOKYAKU_TANKA15.Location = New System.Drawing.Point(666, 275)
        Me.numSYOKYAKU_TANKA15.Name = "numSYOKYAKU_TANKA15"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA15, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA15, Object), CType(Me.numSYOKYAKU_TANKA15, Object), CType(Me.numSYOKYAKU_TANKA15, Object), CType(Me.numSYOKYAKU_TANKA15, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA15.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA15.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA15.TabIndex = 25
        ValueProcess30.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA15).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess30})
        InvalidRange30.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange30.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA15).AddRange(New Object() {InvalidRange30})
        Me.numSYOKYAKU_TANKA15.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA15.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA14
        '
        Me.numSYOKYAKU_TANKA14.AllowDeleteToNull = True
        NumberIntegerPartDisplayField30.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField30.MinDigits = 0
        Me.numSYOKYAKU_TANKA14.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField30, NumberIntegerPartDisplayField30})
        Me.numSYOKYAKU_TANKA14.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA14.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA14.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA14.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA14.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA14.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA14.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA14.HighlightText = True
        Me.numSYOKYAKU_TANKA14.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA14.InputCheck = True
        Me.numSYOKYAKU_TANKA14.Location = New System.Drawing.Point(666, 250)
        Me.numSYOKYAKU_TANKA14.Name = "numSYOKYAKU_TANKA14"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA14, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA14, Object), CType(Me.numSYOKYAKU_TANKA14, Object), CType(Me.numSYOKYAKU_TANKA14, Object), CType(Me.numSYOKYAKU_TANKA14, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA14.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA14.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA14.TabIndex = 22
        ValueProcess31.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA14).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess31})
        InvalidRange31.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange31.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA14).AddRange(New Object() {InvalidRange31})
        Me.numSYOKYAKU_TANKA14.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA14.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA13
        '
        Me.numSYOKYAKU_TANKA13.AllowDeleteToNull = True
        NumberIntegerPartDisplayField31.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField31.MinDigits = 0
        Me.numSYOKYAKU_TANKA13.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField31, NumberIntegerPartDisplayField31})
        Me.numSYOKYAKU_TANKA13.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA13.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA13.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA13.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA13.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA13.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA13.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA13.HighlightText = True
        Me.numSYOKYAKU_TANKA13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA13.InputCheck = True
        Me.numSYOKYAKU_TANKA13.Location = New System.Drawing.Point(666, 225)
        Me.numSYOKYAKU_TANKA13.Name = "numSYOKYAKU_TANKA13"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA13, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA13, Object), CType(Me.numSYOKYAKU_TANKA13, Object), CType(Me.numSYOKYAKU_TANKA13, Object), CType(Me.numSYOKYAKU_TANKA13, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA13.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA13.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA13.TabIndex = 19
        ValueProcess32.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA13).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess32})
        InvalidRange32.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange32.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA13).AddRange(New Object() {InvalidRange32})
        Me.numSYOKYAKU_TANKA13.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA13.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA12
        '
        Me.numSYOKYAKU_TANKA12.AllowDeleteToNull = True
        NumberIntegerPartDisplayField32.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField32.MinDigits = 0
        Me.numSYOKYAKU_TANKA12.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField32, NumberIntegerPartDisplayField32})
        Me.numSYOKYAKU_TANKA12.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA12.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA12.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA12.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA12.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA12.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA12.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA12.HighlightText = True
        Me.numSYOKYAKU_TANKA12.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA12.InputCheck = True
        Me.numSYOKYAKU_TANKA12.Location = New System.Drawing.Point(666, 200)
        Me.numSYOKYAKU_TANKA12.Name = "numSYOKYAKU_TANKA12"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA12, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA12, Object), CType(Me.numSYOKYAKU_TANKA12, Object), CType(Me.numSYOKYAKU_TANKA12, Object), CType(Me.numSYOKYAKU_TANKA12, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA12.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA12.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA12.TabIndex = 16
        ValueProcess33.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA12).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess33})
        InvalidRange33.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange33.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA12).AddRange(New Object() {InvalidRange33})
        Me.numSYOKYAKU_TANKA12.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA12.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA11
        '
        Me.numSYOKYAKU_TANKA11.AllowDeleteToNull = True
        NumberIntegerPartDisplayField33.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField33.MinDigits = 0
        Me.numSYOKYAKU_TANKA11.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField33, NumberIntegerPartDisplayField33})
        Me.numSYOKYAKU_TANKA11.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA11.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA11.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA11.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA11.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA11.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA11.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA11.HighlightText = True
        Me.numSYOKYAKU_TANKA11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA11.InputCheck = True
        Me.numSYOKYAKU_TANKA11.Location = New System.Drawing.Point(666, 175)
        Me.numSYOKYAKU_TANKA11.Name = "numSYOKYAKU_TANKA11"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA11, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA11, Object), CType(Me.numSYOKYAKU_TANKA11, Object), CType(Me.numSYOKYAKU_TANKA11, Object), CType(Me.numSYOKYAKU_TANKA11, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA11.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA11.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA11.TabIndex = 13
        ValueProcess34.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA11).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess34})
        InvalidRange34.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange34.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA11).AddRange(New Object() {InvalidRange34})
        Me.numSYOKYAKU_TANKA11.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA11.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA41
        '
        Me.numSYOKYAKU_TANKA41.AllowDeleteToNull = True
        NumberIntegerPartDisplayField34.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField34.MinDigits = 0
        Me.numSYOKYAKU_TANKA41.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField34, NumberIntegerPartDisplayField34})
        Me.numSYOKYAKU_TANKA41.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA41.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA41.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA41.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA41.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA41.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA41.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA41.HighlightText = True
        Me.numSYOKYAKU_TANKA41.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA41.InputCheck = True
        Me.numSYOKYAKU_TANKA41.Location = New System.Drawing.Point(666, 550)
        Me.numSYOKYAKU_TANKA41.Name = "numSYOKYAKU_TANKA41"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA41, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA41, Object), CType(Me.numSYOKYAKU_TANKA41, Object), CType(Me.numSYOKYAKU_TANKA41, Object), CType(Me.numSYOKYAKU_TANKA41, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA41.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA41.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA41.TabIndex = 69
        ValueProcess35.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA41).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess35})
        InvalidRange35.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange35.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA41).AddRange(New Object() {InvalidRange35})
        Me.numSYOKYAKU_TANKA41.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA41.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA40
        '
        Me.numSYOKYAKU_TANKA40.AllowDeleteToNull = True
        NumberIntegerPartDisplayField35.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField35.MinDigits = 0
        Me.numSYOKYAKU_TANKA40.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField35, NumberIntegerPartDisplayField35})
        Me.numSYOKYAKU_TANKA40.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA40.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA40.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA40.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA40.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA40.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA40.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA40.HighlightText = True
        Me.numSYOKYAKU_TANKA40.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA40.InputCheck = True
        Me.numSYOKYAKU_TANKA40.Location = New System.Drawing.Point(666, 525)
        Me.numSYOKYAKU_TANKA40.Name = "numSYOKYAKU_TANKA40"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA40, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA40, Object), CType(Me.numSYOKYAKU_TANKA40, Object), CType(Me.numSYOKYAKU_TANKA40, Object), CType(Me.numSYOKYAKU_TANKA40, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA40.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA40.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA40.TabIndex = 66
        ValueProcess36.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA40).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess36})
        InvalidRange36.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange36.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA40).AddRange(New Object() {InvalidRange36})
        Me.numSYOKYAKU_TANKA40.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA40.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA39
        '
        Me.numSYOKYAKU_TANKA39.AllowDeleteToNull = True
        NumberIntegerPartDisplayField36.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField36.MinDigits = 0
        Me.numSYOKYAKU_TANKA39.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField36, NumberIntegerPartDisplayField36})
        Me.numSYOKYAKU_TANKA39.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA39.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA39.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA39.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA39.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA39.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA39.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA39.HighlightText = True
        Me.numSYOKYAKU_TANKA39.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA39.InputCheck = True
        Me.numSYOKYAKU_TANKA39.Location = New System.Drawing.Point(666, 500)
        Me.numSYOKYAKU_TANKA39.Name = "numSYOKYAKU_TANKA39"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA39, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA39, Object), CType(Me.numSYOKYAKU_TANKA39, Object), CType(Me.numSYOKYAKU_TANKA39, Object), CType(Me.numSYOKYAKU_TANKA39, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA39.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA39.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA39.TabIndex = 63
        ValueProcess37.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA39).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess37})
        InvalidRange37.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange37.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA39).AddRange(New Object() {InvalidRange37})
        Me.numSYOKYAKU_TANKA39.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA39.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA38
        '
        Me.numSYOKYAKU_TANKA38.AllowDeleteToNull = True
        NumberIntegerPartDisplayField37.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField37.MinDigits = 0
        Me.numSYOKYAKU_TANKA38.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField37, NumberIntegerPartDisplayField37})
        Me.numSYOKYAKU_TANKA38.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA38.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA38.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA38.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA38.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA38.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA38.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA38.HighlightText = True
        Me.numSYOKYAKU_TANKA38.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA38.InputCheck = True
        Me.numSYOKYAKU_TANKA38.Location = New System.Drawing.Point(666, 475)
        Me.numSYOKYAKU_TANKA38.Name = "numSYOKYAKU_TANKA38"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA38, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA38, Object), CType(Me.numSYOKYAKU_TANKA38, Object), CType(Me.numSYOKYAKU_TANKA38, Object), CType(Me.numSYOKYAKU_TANKA38, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA38.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA38.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA38.TabIndex = 59
        ValueProcess38.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA38).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess38})
        InvalidRange38.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange38.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA38).AddRange(New Object() {InvalidRange38})
        Me.numSYOKYAKU_TANKA38.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA38.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numSYOKYAKU_TANKA37
        '
        Me.numSYOKYAKU_TANKA37.AllowDeleteToNull = True
        NumberIntegerPartDisplayField38.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField38.MinDigits = 0
        Me.numSYOKYAKU_TANKA37.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField38, NumberIntegerPartDisplayField38})
        Me.numSYOKYAKU_TANKA37.DropDown.AllowDrop = False
        Me.numSYOKYAKU_TANKA37.Fields.DecimalPart.MaxDigits = 0
        Me.numSYOKYAKU_TANKA37.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numSYOKYAKU_TANKA37.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numSYOKYAKU_TANKA37.Fields.IntegerPart.MaxDigits = 4
        Me.numSYOKYAKU_TANKA37.Fields.IntegerPart.MinDigits = 1
        Me.numSYOKYAKU_TANKA37.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numSYOKYAKU_TANKA37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numSYOKYAKU_TANKA37.HighlightText = True
        Me.numSYOKYAKU_TANKA37.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numSYOKYAKU_TANKA37.InputCheck = True
        Me.numSYOKYAKU_TANKA37.Location = New System.Drawing.Point(666, 450)
        Me.numSYOKYAKU_TANKA37.Name = "numSYOKYAKU_TANKA37"
        Me.GcShortcut1.SetShortcuts(Me.numSYOKYAKU_TANKA37, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numSYOKYAKU_TANKA37, Object), CType(Me.numSYOKYAKU_TANKA37, Object), CType(Me.numSYOKYAKU_TANKA37, Object), CType(Me.numSYOKYAKU_TANKA37, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numSYOKYAKU_TANKA37.Size = New System.Drawing.Size(67, 20)
        Me.numSYOKYAKU_TANKA37.Spin.Increment = 0
        Me.numSYOKYAKU_TANKA37.TabIndex = 56
        ValueProcess39.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numSYOKYAKU_TANKA37).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess39})
        InvalidRange39.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        InvalidRange39.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numSYOKYAKU_TANKA37).AddRange(New Object() {InvalidRange39})
        Me.numSYOKYAKU_TANKA37.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numSYOKYAKU_TANKA37.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA41
        '
        Me.numKEIEISIEN_TANKA41.AllowDeleteToNull = True
        NumberIntegerPartDisplayField39.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField39.MinDigits = 0
        Me.numKEIEISIEN_TANKA41.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField39, NumberIntegerPartDisplayField39})
        Me.numKEIEISIEN_TANKA41.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA41.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA41.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA41.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA41.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA41.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA41.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA41.HighlightText = True
        Me.numKEIEISIEN_TANKA41.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA41.InputCheck = True
        Me.numKEIEISIEN_TANKA41.Location = New System.Drawing.Point(528, 550)
        Me.numKEIEISIEN_TANKA41.Name = "numKEIEISIEN_TANKA41"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA41, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA41, Object), CType(Me.numKEIEISIEN_TANKA41, Object), CType(Me.numKEIEISIEN_TANKA41, Object), CType(Me.numKEIEISIEN_TANKA41, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA41.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA41.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA41.TabIndex = 68
        ValueProcess40.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA41).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess40})
        InvalidRange40.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange40.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA41).AddRange(New Object() {InvalidRange40})
        Me.numKEIEISIEN_TANKA41.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA41.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA40
        '
        Me.numKEIEISIEN_TANKA40.AllowDeleteToNull = True
        NumberIntegerPartDisplayField40.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField40.MinDigits = 0
        Me.numKEIEISIEN_TANKA40.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField40, NumberIntegerPartDisplayField40})
        Me.numKEIEISIEN_TANKA40.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA40.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA40.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA40.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA40.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA40.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA40.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA40.HighlightText = True
        Me.numKEIEISIEN_TANKA40.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA40.InputCheck = True
        Me.numKEIEISIEN_TANKA40.Location = New System.Drawing.Point(528, 525)
        Me.numKEIEISIEN_TANKA40.Name = "numKEIEISIEN_TANKA40"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA40, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA40, Object), CType(Me.numKEIEISIEN_TANKA40, Object), CType(Me.numKEIEISIEN_TANKA40, Object), CType(Me.numKEIEISIEN_TANKA40, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA40.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA40.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA40.TabIndex = 65
        ValueProcess41.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA40).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess41})
        InvalidRange41.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange41.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA40).AddRange(New Object() {InvalidRange41})
        Me.numKEIEISIEN_TANKA40.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA40.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA39
        '
        Me.numKEIEISIEN_TANKA39.AllowDeleteToNull = True
        NumberIntegerPartDisplayField41.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField41.MinDigits = 0
        Me.numKEIEISIEN_TANKA39.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField41, NumberIntegerPartDisplayField41})
        Me.numKEIEISIEN_TANKA39.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA39.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA39.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA39.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA39.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA39.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA39.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA39.HighlightText = True
        Me.numKEIEISIEN_TANKA39.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA39.InputCheck = True
        Me.numKEIEISIEN_TANKA39.Location = New System.Drawing.Point(528, 500)
        Me.numKEIEISIEN_TANKA39.Name = "numKEIEISIEN_TANKA39"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA39, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA39, Object), CType(Me.numKEIEISIEN_TANKA39, Object), CType(Me.numKEIEISIEN_TANKA39, Object), CType(Me.numKEIEISIEN_TANKA39, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA39.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA39.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA39.TabIndex = 62
        ValueProcess42.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA39).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess42})
        InvalidRange42.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange42.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA39).AddRange(New Object() {InvalidRange42})
        Me.numKEIEISIEN_TANKA39.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA39.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA38
        '
        Me.numKEIEISIEN_TANKA38.AllowDeleteToNull = True
        NumberIntegerPartDisplayField42.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField42.MinDigits = 0
        Me.numKEIEISIEN_TANKA38.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField42, NumberIntegerPartDisplayField42})
        Me.numKEIEISIEN_TANKA38.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA38.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA38.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA38.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA38.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA38.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA38.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA38.HighlightText = True
        Me.numKEIEISIEN_TANKA38.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA38.InputCheck = True
        Me.numKEIEISIEN_TANKA38.Location = New System.Drawing.Point(528, 475)
        Me.numKEIEISIEN_TANKA38.Name = "numKEIEISIEN_TANKA38"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA38, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA38, Object), CType(Me.numKEIEISIEN_TANKA38, Object), CType(Me.numKEIEISIEN_TANKA38, Object), CType(Me.numKEIEISIEN_TANKA38, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA38.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA38.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA38.TabIndex = 58
        ValueProcess43.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA38).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess43})
        InvalidRange43.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange43.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA38).AddRange(New Object() {InvalidRange43})
        Me.numKEIEISIEN_TANKA38.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA38.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKEIEISIEN_TANKA37
        '
        Me.numKEIEISIEN_TANKA37.AllowDeleteToNull = True
        NumberIntegerPartDisplayField43.GroupSizes = New Integer() {3, 3, 0}
        NumberIntegerPartDisplayField43.MinDigits = 0
        Me.numKEIEISIEN_TANKA37.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField43, NumberIntegerPartDisplayField43})
        Me.numKEIEISIEN_TANKA37.DropDown.AllowDrop = False
        Me.numKEIEISIEN_TANKA37.Fields.DecimalPart.MaxDigits = 0
        Me.numKEIEISIEN_TANKA37.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKEIEISIEN_TANKA37.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numKEIEISIEN_TANKA37.Fields.IntegerPart.MaxDigits = 5
        Me.numKEIEISIEN_TANKA37.Fields.IntegerPart.MinDigits = 1
        Me.numKEIEISIEN_TANKA37.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKEIEISIEN_TANKA37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKEIEISIEN_TANKA37.HighlightText = True
        Me.numKEIEISIEN_TANKA37.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKEIEISIEN_TANKA37.InputCheck = True
        Me.numKEIEISIEN_TANKA37.Location = New System.Drawing.Point(528, 450)
        Me.numKEIEISIEN_TANKA37.Name = "numKEIEISIEN_TANKA37"
        Me.GcShortcut1.SetShortcuts(Me.numKEIEISIEN_TANKA37, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKEIEISIEN_TANKA37, Object), CType(Me.numKEIEISIEN_TANKA37, Object), CType(Me.numKEIEISIEN_TANKA37, Object), CType(Me.numKEIEISIEN_TANKA37, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKEIEISIEN_TANKA37.Size = New System.Drawing.Size(67, 20)
        Me.numKEIEISIEN_TANKA37.Spin.Increment = 0
        Me.numKEIEISIEN_TANKA37.TabIndex = 55
        ValueProcess44.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKEIEISIEN_TANKA37).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess44})
        InvalidRange44.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        InvalidRange44.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKEIEISIEN_TANKA37).AddRange(New Object() {InvalidRange44})
        Me.numKEIEISIEN_TANKA37.Value = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numKEIEISIEN_TANKA37.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA41
        '
        Me.numTUMITATE_TANKA41.AllowDeleteToNull = True
        NumberIntegerPartDisplayField44.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField12.MaxDigits = 1
        NumberDecimalPartDisplayField12.MinDigits = 1
        Me.numTUMITATE_TANKA41.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField44, NumberIntegerPartDisplayField44, NumberDecimalSeparatorDisplayField12, NumberDecimalPartDisplayField12})
        Me.numTUMITATE_TANKA41.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA41.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA41.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA41.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA41.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA41.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA41.HighlightText = True
        Me.numTUMITATE_TANKA41.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA41.InputCheck = True
        Me.numTUMITATE_TANKA41.Location = New System.Drawing.Point(404, 550)
        Me.numTUMITATE_TANKA41.Name = "numTUMITATE_TANKA41"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA41, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA41, Object), CType(Me.numTUMITATE_TANKA41, Object), CType(Me.numTUMITATE_TANKA41, Object), CType(Me.numTUMITATE_TANKA41, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA41.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA41.Spin.Increment = 0
        Me.numTUMITATE_TANKA41.TabIndex = 67
        ValueProcess45.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA41).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess45})
        InvalidRange45.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange45.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA41).AddRange(New Object() {InvalidRange45})
        Me.numTUMITATE_TANKA41.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA41.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA40
        '
        Me.numTUMITATE_TANKA40.AllowDeleteToNull = True
        NumberIntegerPartDisplayField45.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField13.MaxDigits = 1
        NumberDecimalPartDisplayField13.MinDigits = 1
        Me.numTUMITATE_TANKA40.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField45, NumberIntegerPartDisplayField45, NumberDecimalSeparatorDisplayField13, NumberDecimalPartDisplayField13})
        Me.numTUMITATE_TANKA40.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA40.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA40.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA40.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA40.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA40.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA40.HighlightText = True
        Me.numTUMITATE_TANKA40.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA40.InputCheck = True
        Me.numTUMITATE_TANKA40.Location = New System.Drawing.Point(404, 525)
        Me.numTUMITATE_TANKA40.Name = "numTUMITATE_TANKA40"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA40, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA40, Object), CType(Me.numTUMITATE_TANKA40, Object), CType(Me.numTUMITATE_TANKA40, Object), CType(Me.numTUMITATE_TANKA40, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA40.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA40.Spin.Increment = 0
        Me.numTUMITATE_TANKA40.TabIndex = 64
        ValueProcess46.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA40).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess46})
        InvalidRange46.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange46.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA40).AddRange(New Object() {InvalidRange46})
        Me.numTUMITATE_TANKA40.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA40.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA39
        '
        Me.numTUMITATE_TANKA39.AllowDeleteToNull = True
        NumberIntegerPartDisplayField46.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField14.MaxDigits = 1
        NumberDecimalPartDisplayField14.MinDigits = 1
        Me.numTUMITATE_TANKA39.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField46, NumberIntegerPartDisplayField46, NumberDecimalSeparatorDisplayField14, NumberDecimalPartDisplayField14})
        Me.numTUMITATE_TANKA39.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA39.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA39.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA39.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA39.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA39.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA39.HighlightText = True
        Me.numTUMITATE_TANKA39.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA39.InputCheck = True
        Me.numTUMITATE_TANKA39.Location = New System.Drawing.Point(404, 500)
        Me.numTUMITATE_TANKA39.Name = "numTUMITATE_TANKA39"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA39, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA39, Object), CType(Me.numTUMITATE_TANKA39, Object), CType(Me.numTUMITATE_TANKA39, Object), CType(Me.numTUMITATE_TANKA39, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA39.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA39.Spin.Increment = 0
        Me.numTUMITATE_TANKA39.TabIndex = 61
        ValueProcess47.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA39).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess47})
        InvalidRange47.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange47.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA39).AddRange(New Object() {InvalidRange47})
        Me.numTUMITATE_TANKA39.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA39.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA38
        '
        Me.numTUMITATE_TANKA38.AllowDeleteToNull = True
        NumberIntegerPartDisplayField47.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField15.MaxDigits = 1
        NumberDecimalPartDisplayField15.MinDigits = 1
        Me.numTUMITATE_TANKA38.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField47, NumberIntegerPartDisplayField47, NumberDecimalSeparatorDisplayField15, NumberDecimalPartDisplayField15})
        Me.numTUMITATE_TANKA38.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA38.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA38.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA38.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA38.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA38.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA38.HighlightText = True
        Me.numTUMITATE_TANKA38.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA38.InputCheck = True
        Me.numTUMITATE_TANKA38.Location = New System.Drawing.Point(404, 475)
        Me.numTUMITATE_TANKA38.Name = "numTUMITATE_TANKA38"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA38, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA38, Object), CType(Me.numTUMITATE_TANKA38, Object), CType(Me.numTUMITATE_TANKA38, Object), CType(Me.numTUMITATE_TANKA38, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA38.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA38.Spin.Increment = 0
        Me.numTUMITATE_TANKA38.TabIndex = 57
        ValueProcess48.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA38).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess48})
        InvalidRange48.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange48.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA38).AddRange(New Object() {InvalidRange48})
        Me.numTUMITATE_TANKA38.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA38.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numTUMITATE_TANKA37
        '
        Me.numTUMITATE_TANKA37.AllowDeleteToNull = True
        NumberIntegerPartDisplayField48.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField16.MaxDigits = 1
        NumberDecimalPartDisplayField16.MinDigits = 1
        Me.numTUMITATE_TANKA37.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField48, NumberIntegerPartDisplayField48, NumberDecimalSeparatorDisplayField16, NumberDecimalPartDisplayField16})
        Me.numTUMITATE_TANKA37.DropDown.AllowDrop = False
        Me.numTUMITATE_TANKA37.Fields.DecimalPart.MaxDigits = 1
        Me.numTUMITATE_TANKA37.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numTUMITATE_TANKA37.Fields.IntegerPart.GroupSizes = New Integer() {3, 3, 0}
        Me.numTUMITATE_TANKA37.Fields.IntegerPart.MaxDigits = 3
        Me.numTUMITATE_TANKA37.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numTUMITATE_TANKA37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numTUMITATE_TANKA37.HighlightText = True
        Me.numTUMITATE_TANKA37.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numTUMITATE_TANKA37.InputCheck = True
        Me.numTUMITATE_TANKA37.Location = New System.Drawing.Point(404, 450)
        Me.numTUMITATE_TANKA37.Name = "numTUMITATE_TANKA37"
        Me.GcShortcut1.SetShortcuts(Me.numTUMITATE_TANKA37, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numTUMITATE_TANKA37, Object), CType(Me.numTUMITATE_TANKA37, Object), CType(Me.numTUMITATE_TANKA37, Object), CType(Me.numTUMITATE_TANKA37, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numTUMITATE_TANKA37.Size = New System.Drawing.Size(55, 20)
        Me.numTUMITATE_TANKA37.Spin.Increment = 0
        Me.numTUMITATE_TANKA37.TabIndex = 54
        ValueProcess49.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numTUMITATE_TANKA37).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess49})
        InvalidRange49.MaxValue = New Decimal(New Integer() {9999, 0, 0, 65536})
        InvalidRange49.MinValue = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.GcNumberValidator1.GetValidateItems(Me.numTUMITATE_TANKA37).AddRange(New Object() {InvalidRange49})
        Me.numTUMITATE_TANKA37.Value = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.numTUMITATE_TANKA37.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOFU_RITU
        '
        Me.numKOFU_RITU.AllowDeleteToNull = True
        Me.numKOFU_RITU.DropDown.AllowDrop = False
        Me.numKOFU_RITU.Fields.DecimalPart.MaxDigits = 6
        Me.numKOFU_RITU.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOFU_RITU.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOFU_RITU.Fields.IntegerPart.MaxDigits = 3
        Me.numKOFU_RITU.Fields.IntegerPart.MinDigits = 1
        Me.numKOFU_RITU.Fields.SignPrefix.NegativePattern = ""
        Me.numKOFU_RITU.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOFU_RITU.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOFU_RITU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOFU_RITU.InputCheck = True
        Me.numKOFU_RITU.Location = New System.Drawing.Point(416, 594)
        Me.numKOFU_RITU.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numKOFU_RITU.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numKOFU_RITU.Name = "numKOFU_RITU"
        Me.GcShortcut1.SetShortcuts(Me.numKOFU_RITU, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOFU_RITU, Object), CType(Me.numKOFU_RITU, Object), CType(Me.numKOFU_RITU, Object), CType(Me.numKOFU_RITU, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOFU_RITU.Size = New System.Drawing.Size(103, 20)
        Me.numKOFU_RITU.Spin.Increment = 0
        Me.numKOFU_RITU.TabIndex = 72
        ValueProcess50.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOFU_RITU).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess50})
        InvalidRange50.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        InvalidRange50.MinValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOFU_RITU).AddRange(New Object() {InvalidRange50})
        Me.numKOFU_RITU.Value = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numKOFU_RITU.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(12, 6)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 9
        Me.cmdSave.Text = "保存"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(90, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 871
        Me.Label2.Text = "■年月日"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(307, 70)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 15)
        Me.Label13.TabIndex = 985
        Me.Label13.Text = "～"
        '
        'Label116
        '
        Me.Label116.BackColor = System.Drawing.Color.Transparent
        Me.Label116.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label116.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label116.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label116.Location = New System.Drawing.Point(242, 422)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(121, 26)
        Me.Label116.TabIndex = 1182
        Me.Label116.Text = "うずら"
        Me.Label116.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label108
        '
        Me.Label108.BackColor = System.Drawing.Color.Transparent
        Me.Label108.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label108.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label108.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label108.Location = New System.Drawing.Point(174, 422)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(69, 151)
        Me.Label108.TabIndex = 1181
        Me.Label108.Text = "鶏以外"
        Me.Label108.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label101
        '
        Me.Label101.BackColor = System.Drawing.Color.Transparent
        Me.Label101.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label101.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label101.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label101.Location = New System.Drawing.Point(242, 397)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(121, 26)
        Me.Label101.TabIndex = 1180
        Me.Label101.Text = "種鶏（育成鶏）"
        Me.Label101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label102
        '
        Me.Label102.BackColor = System.Drawing.Color.Transparent
        Me.Label102.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label102.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label102.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label102.Location = New System.Drawing.Point(242, 372)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(121, 26)
        Me.Label102.TabIndex = 1179
        Me.Label102.Text = "種鶏（成鶏）"
        Me.Label102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label103
        '
        Me.Label103.BackColor = System.Drawing.Color.Transparent
        Me.Label103.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label103.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label103.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label103.Location = New System.Drawing.Point(242, 347)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(121, 26)
        Me.Label103.TabIndex = 1178
        Me.Label103.Text = "肉用鶏"
        Me.Label103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label104
        '
        Me.Label104.BackColor = System.Drawing.Color.Transparent
        Me.Label104.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label104.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label104.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label104.Location = New System.Drawing.Point(242, 322)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(121, 26)
        Me.Label104.TabIndex = 1177
        Me.Label104.Text = "採卵鶏（育成鶏）"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label105
        '
        Me.Label105.BackColor = System.Drawing.Color.Transparent
        Me.Label105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label105.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label105.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label105.Location = New System.Drawing.Point(242, 297)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(121, 26)
        Me.Label105.TabIndex = 1176
        Me.Label105.Text = "採卵鶏（成鶏）"
        Me.Label105.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label106
        '
        Me.Label106.BackColor = System.Drawing.Color.Transparent
        Me.Label106.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label106.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label106.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label106.Location = New System.Drawing.Point(174, 297)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(69, 126)
        Me.Label106.TabIndex = 1175
        Me.Label106.Text = "企業型"
        Me.Label106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(242, 272)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(121, 26)
        Me.Label18.TabIndex = 1174
        Me.Label18.Text = "種鶏（育成鶏）"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(242, 247)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(121, 26)
        Me.Label17.TabIndex = 1173
        Me.Label17.Text = "種鶏（成鶏）"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(242, 222)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(121, 26)
        Me.Label16.TabIndex = 1172
        Me.Label16.Text = "肉用鶏"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(242, 197)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(121, 26)
        Me.Label12.TabIndex = 1171
        Me.Label12.Text = "採卵鶏（育成鶏）"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(242, 172)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 26)
        Me.Label15.TabIndex = 1170
        Me.Label15.Text = "採卵鶏（成鶏）"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(174, 172)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 126)
        Me.Label11.TabIndex = 1169
        Me.Label11.Text = "家族型"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(242, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 60)
        Me.Label9.TabIndex = 1168
        Me.Label9.Text = "鳥の種類"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(174, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 60)
        Me.Label7.TabIndex = 1167
        Me.Label7.Text = "契約区分"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(362, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 60)
        Me.Label3.TabIndex = 1183
        Me.Label3.Text = "契約者積立金" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "単価"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(498, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 60)
        Me.Label4.TabIndex = 1184
        Me.Label4.Text = "経営支援互助金" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "単価"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(636, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 60)
        Me.Label5.TabIndex = 1185
        Me.Label5.Text = "焼却・埋却等互助金" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "単価"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(362, 172)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(139, 26)
        Me.Label45.TabIndex = 1187
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(90, 597)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 15)
        Me.Label6.TabIndex = 1189
        Me.Label6.Text = "■手数料率"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(362, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 26)
        Me.Label8.TabIndex = 1191
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(362, 222)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 26)
        Me.Label10.TabIndex = 1193
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(362, 247)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(139, 26)
        Me.Label14.TabIndex = 1195
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(362, 272)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(139, 26)
        Me.Label19.TabIndex = 1197
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(362, 397)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(139, 26)
        Me.Label20.TabIndex = 1207
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(362, 372)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(139, 26)
        Me.Label21.TabIndex = 1205
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(362, 347)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(139, 26)
        Me.Label22.TabIndex = 1203
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(362, 322)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(139, 26)
        Me.Label23.TabIndex = 1201
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(362, 297)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(139, 26)
        Me.Label24.TabIndex = 1199
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(362, 422)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(139, 26)
        Me.Label25.TabIndex = 1209
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(498, 172)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(139, 26)
        Me.Label36.TabIndex = 1211
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(498, 197)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(139, 26)
        Me.Label26.TabIndex = 1213
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(498, 247)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(139, 26)
        Me.Label27.TabIndex = 1217
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(498, 222)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(139, 26)
        Me.Label28.TabIndex = 1215
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(498, 297)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(139, 26)
        Me.Label29.TabIndex = 1221
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(498, 272)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(139, 26)
        Me.Label30.TabIndex = 1219
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(498, 422)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(139, 26)
        Me.Label32.TabIndex = 1231
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(498, 397)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(139, 26)
        Me.Label33.TabIndex = 1229
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(498, 372)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(139, 26)
        Me.Label34.TabIndex = 1227
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(498, 347)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(139, 26)
        Me.Label35.TabIndex = 1225
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(498, 322)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(139, 26)
        Me.Label37.TabIndex = 1223
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(636, 422)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(139, 26)
        Me.Label31.TabIndex = 1253
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(636, 397)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(139, 26)
        Me.Label38.TabIndex = 1251
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(636, 372)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(139, 26)
        Me.Label39.TabIndex = 1249
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(636, 347)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(139, 26)
        Me.Label40.TabIndex = 1247
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label41.Location = New System.Drawing.Point(636, 322)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(139, 26)
        Me.Label41.TabIndex = 1245
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(636, 297)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(139, 26)
        Me.Label42.TabIndex = 1243
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(636, 272)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(139, 26)
        Me.Label43.TabIndex = 1241
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label44.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(636, 247)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(139, 26)
        Me.Label44.TabIndex = 1239
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label46.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.Location = New System.Drawing.Point(636, 222)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(139, 26)
        Me.Label46.TabIndex = 1237
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label47.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(636, 197)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(139, 26)
        Me.Label47.TabIndex = 1235
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label48.Location = New System.Drawing.Point(636, 172)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(139, 26)
        Me.Label48.TabIndex = 1233
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label49.Location = New System.Drawing.Point(212, 597)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(22, 15)
        Me.Label49.TabIndex = 1254
        Me.Label49.Text = "％"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label50.Location = New System.Drawing.Point(705, 98)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(76, 15)
        Me.Label50.TabIndex = 1255
        Me.Label50.Text = "（単位：円）"
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label66.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label66.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label66.Location = New System.Drawing.Point(242, 547)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(121, 26)
        Me.Label66.TabIndex = 1275
        Me.Label66.Text = "だちょう"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label67.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label67.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label67.Location = New System.Drawing.Point(242, 522)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(121, 26)
        Me.Label67.TabIndex = 1274
        Me.Label67.Text = "七面鳥"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label68
        '
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label68.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label68.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label68.Location = New System.Drawing.Point(242, 497)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(121, 26)
        Me.Label68.TabIndex = 1273
        Me.Label68.Text = "ほろほろ鳥"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label69
        '
        Me.Label69.BackColor = System.Drawing.Color.Transparent
        Me.Label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label69.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label69.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label69.Location = New System.Drawing.Point(242, 472)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(121, 26)
        Me.Label69.TabIndex = 1272
        Me.Label69.Text = "きじ"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label70
        '
        Me.Label70.BackColor = System.Drawing.Color.Transparent
        Me.Label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label70.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label70.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label70.Location = New System.Drawing.Point(242, 447)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(121, 26)
        Me.Label70.TabIndex = 1271
        Me.Label70.Text = "あひる"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label51.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label51.Location = New System.Drawing.Point(636, 547)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(139, 26)
        Me.Label51.TabIndex = 1305
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label52.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(636, 522)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(139, 26)
        Me.Label52.TabIndex = 1304
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label53.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label53.Location = New System.Drawing.Point(636, 497)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(139, 26)
        Me.Label53.TabIndex = 1303
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label54.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label54.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label54.Location = New System.Drawing.Point(636, 472)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(139, 26)
        Me.Label54.TabIndex = 1302
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.Transparent
        Me.Label55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label55.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label55.Location = New System.Drawing.Point(636, 447)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(139, 26)
        Me.Label55.TabIndex = 1301
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label56.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label56.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label56.Location = New System.Drawing.Point(498, 547)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(139, 26)
        Me.Label56.TabIndex = 1300
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label57.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label57.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label57.Location = New System.Drawing.Point(498, 522)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(139, 26)
        Me.Label57.TabIndex = 1299
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label58.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label58.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label58.Location = New System.Drawing.Point(498, 497)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(139, 26)
        Me.Label58.TabIndex = 1298
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.Transparent
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label59.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label59.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label59.Location = New System.Drawing.Point(498, 472)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(139, 26)
        Me.Label59.TabIndex = 1297
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.Color.Transparent
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label60.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label60.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label60.Location = New System.Drawing.Point(498, 447)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(139, 26)
        Me.Label60.TabIndex = 1296
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.Color.Transparent
        Me.Label61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label61.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label61.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label61.Location = New System.Drawing.Point(362, 547)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(139, 26)
        Me.Label61.TabIndex = 1295
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.Color.Transparent
        Me.Label62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label62.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label62.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label62.Location = New System.Drawing.Point(362, 522)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(139, 26)
        Me.Label62.TabIndex = 1294
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label63.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label63.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label63.Location = New System.Drawing.Point(362, 497)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(139, 26)
        Me.Label63.TabIndex = 1293
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.Transparent
        Me.Label64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label64.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label64.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label64.Location = New System.Drawing.Point(362, 472)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(139, 26)
        Me.Label64.TabIndex = 1292
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label65
        '
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label65.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label65.Location = New System.Drawing.Point(362, 447)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(139, 26)
        Me.Label65.TabIndex = 1291
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.BackColor = System.Drawing.Color.Transparent
        Me.Label71.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label71.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label71.Location = New System.Drawing.Point(525, 597)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(22, 15)
        Me.Label71.TabIndex = 1308
        Me.Label71.Text = "％"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.BackColor = System.Drawing.Color.Transparent
        Me.Label72.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label72.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label72.Location = New System.Drawing.Point(302, 597)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(112, 15)
        Me.Label72.TabIndex = 1307
        Me.Label72.Text = "■互助金交付率"
        '
        'frmGJ2011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.Label71)
        Me.Controls.Add(Me.Label72)
        Me.Controls.Add(Me.numKOFU_RITU)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA41)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA40)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA39)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA38)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA37)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA41)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA40)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA39)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA38)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA37)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.numTUMITATE_TANKA41)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.numTUMITATE_TANKA40)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.numTUMITATE_TANKA39)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.numTUMITATE_TANKA38)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.numTUMITATE_TANKA37)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.Label69)
        Me.Controls.Add(Me.Label70)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA36)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA25)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA24)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA23)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA22)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA21)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA15)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA14)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA13)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA12)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.numSYOKYAKU_TANKA11)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA36)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA25)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA24)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA23)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA22)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA21)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA15)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA14)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA13)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA12)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.numKEIEISIEN_TANKA11)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.numTUMITATE_TANKA36)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.numTUMITATE_TANKA25)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.numTUMITATE_TANKA24)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.numTUMITATE_TANKA23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.numTUMITATE_TANKA22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.numTUMITATE_TANKA21)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.numTUMITATE_TANKA15)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.numTUMITATE_TANKA14)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.numTUMITATE_TANKA13)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.numTUMITATE_TANKA12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.numTESURYO_RITU)
        Me.Controls.Add(Me.numTUMITATE_TANKA11)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label116)
        Me.Controls.Add(Me.Label108)
        Me.Controls.Add(Me.Label101)
        Me.Controls.Add(Me.Label102)
        Me.Controls.Add(Me.Label103)
        Me.Controls.Add(Me.Label104)
        Me.Controls.Add(Me.Label105)
        Me.Controls.Add(Me.Label106)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dateTAISYO_DATE_To)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dateTAISYO_DATE_Fm)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmGJ2011"
        Me.Text = "(GJ2011)契約者積立金・互助金単価マスタメンテナンス"
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.dateTAISYO_DATE_Fm, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.dateTAISYO_DATE_To, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label106, 0)
        Me.Controls.SetChildIndex(Me.Label105, 0)
        Me.Controls.SetChildIndex(Me.Label104, 0)
        Me.Controls.SetChildIndex(Me.Label103, 0)
        Me.Controls.SetChildIndex(Me.Label102, 0)
        Me.Controls.SetChildIndex(Me.Label101, 0)
        Me.Controls.SetChildIndex(Me.Label108, 0)
        Me.Controls.SetChildIndex(Me.Label116, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label45, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA11, 0)
        Me.Controls.SetChildIndex(Me.numTESURYO_RITU, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA12, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA13, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA14, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA15, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA21, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA22, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA23, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA24, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA25, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA36, 0)
        Me.Controls.SetChildIndex(Me.Label36, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA11, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA12, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA13, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA14, 0)
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA15, 0)
        Me.Controls.SetChildIndex(Me.Label29, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA21, 0)
        Me.Controls.SetChildIndex(Me.Label37, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA22, 0)
        Me.Controls.SetChildIndex(Me.Label35, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA23, 0)
        Me.Controls.SetChildIndex(Me.Label34, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA24, 0)
        Me.Controls.SetChildIndex(Me.Label33, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA25, 0)
        Me.Controls.SetChildIndex(Me.Label32, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA36, 0)
        Me.Controls.SetChildIndex(Me.Label48, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA11, 0)
        Me.Controls.SetChildIndex(Me.Label47, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA12, 0)
        Me.Controls.SetChildIndex(Me.Label46, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA13, 0)
        Me.Controls.SetChildIndex(Me.Label44, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA14, 0)
        Me.Controls.SetChildIndex(Me.Label43, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA15, 0)
        Me.Controls.SetChildIndex(Me.Label42, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA21, 0)
        Me.Controls.SetChildIndex(Me.Label41, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA22, 0)
        Me.Controls.SetChildIndex(Me.Label40, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA23, 0)
        Me.Controls.SetChildIndex(Me.Label39, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA24, 0)
        Me.Controls.SetChildIndex(Me.Label38, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA25, 0)
        Me.Controls.SetChildIndex(Me.Label31, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA36, 0)
        Me.Controls.SetChildIndex(Me.Label49, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label50, 0)
        Me.Controls.SetChildIndex(Me.Label70, 0)
        Me.Controls.SetChildIndex(Me.Label69, 0)
        Me.Controls.SetChildIndex(Me.Label68, 0)
        Me.Controls.SetChildIndex(Me.Label67, 0)
        Me.Controls.SetChildIndex(Me.Label66, 0)
        Me.Controls.SetChildIndex(Me.Label65, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA37, 0)
        Me.Controls.SetChildIndex(Me.Label64, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA38, 0)
        Me.Controls.SetChildIndex(Me.Label63, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA39, 0)
        Me.Controls.SetChildIndex(Me.Label62, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA40, 0)
        Me.Controls.SetChildIndex(Me.Label61, 0)
        Me.Controls.SetChildIndex(Me.numTUMITATE_TANKA41, 0)
        Me.Controls.SetChildIndex(Me.Label60, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA37, 0)
        Me.Controls.SetChildIndex(Me.Label59, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA38, 0)
        Me.Controls.SetChildIndex(Me.Label58, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA39, 0)
        Me.Controls.SetChildIndex(Me.Label57, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA40, 0)
        Me.Controls.SetChildIndex(Me.Label56, 0)
        Me.Controls.SetChildIndex(Me.numKEIEISIEN_TANKA41, 0)
        Me.Controls.SetChildIndex(Me.Label55, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA37, 0)
        Me.Controls.SetChildIndex(Me.Label54, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA38, 0)
        Me.Controls.SetChildIndex(Me.Label53, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA39, 0)
        Me.Controls.SetChildIndex(Me.Label52, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA40, 0)
        Me.Controls.SetChildIndex(Me.Label51, 0)
        Me.Controls.SetChildIndex(Me.numSYOKYAKU_TANKA41, 0)
        Me.Controls.SetChildIndex(Me.numKOFU_RITU, 0)
        Me.Controls.SetChildIndex(Me.Label72, 0)
        Me.Controls.SetChildIndex(Me.Label71, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.cob_KenCdFm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateTAISYO_DATE_To, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateTAISYO_DATE_Fm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTESURYO_RITU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSYOKYAKU_TANKA37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKEIEISIEN_TANKA37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTUMITATE_TANKA37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOFU_RITU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cob_KenCdFm As JBD.Gjs.Win.GcComboBox
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents cmdSave As JBD.Gjs.Win.JButton
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents dateTAISYO_DATE_To As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton8 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents dateTAISYO_DATE_Fm As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label116 As JBD.Gjs.Win.Label
    Friend WithEvents Label108 As JBD.Gjs.Win.Label
    Friend WithEvents Label101 As JBD.Gjs.Win.Label
    Friend WithEvents Label102 As JBD.Gjs.Win.Label
    Friend WithEvents Label103 As JBD.Gjs.Win.Label
    Friend WithEvents Label104 As JBD.Gjs.Win.Label
    Friend WithEvents Label105 As JBD.Gjs.Win.Label
    Friend WithEvents Label106 As JBD.Gjs.Win.Label
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA11 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label45 As JBD.Gjs.Win.Label
    Friend WithEvents numTESURYO_RITU As JBD.Gjs.Win.GcNumber
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA12 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA13 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA14 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA15 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA25 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label20 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA24 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label21 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA23 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA22 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label23 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA21 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA36 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label25 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA11 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label36 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA12 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label26 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA14 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label27 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA13 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label28 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA21 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA15 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label30 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA36 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label32 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA25 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label33 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA24 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label34 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA23 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label35 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA22 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label37 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA36 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label31 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA25 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label38 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA24 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label39 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA23 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label40 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA22 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label41 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA21 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label42 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA15 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label43 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA14 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label44 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA13 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label46 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA12 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label47 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA11 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label48 As JBD.Gjs.Win.Label
    Friend WithEvents Label49 As JBD.Gjs.Win.Label
    Friend WithEvents Label50 As JBD.Gjs.Win.Label
    Friend WithEvents Label66 As JBD.Gjs.Win.Label
    Friend WithEvents Label67 As JBD.Gjs.Win.Label
    Friend WithEvents Label68 As JBD.Gjs.Win.Label
    Friend WithEvents Label69 As JBD.Gjs.Win.Label
    Friend WithEvents Label70 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA41 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label51 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA40 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label52 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA39 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label53 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA38 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label54 As JBD.Gjs.Win.Label
    Friend WithEvents numSYOKYAKU_TANKA37 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label55 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA41 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label56 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA40 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label57 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA39 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label58 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA38 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label59 As JBD.Gjs.Win.Label
    Friend WithEvents numKEIEISIEN_TANKA37 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label60 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA41 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label61 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA40 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label62 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA39 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label63 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA38 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label64 As JBD.Gjs.Win.Label
    Friend WithEvents numTUMITATE_TANKA37 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label65 As JBD.Gjs.Win.Label
    Friend WithEvents Label71 As JBD.Gjs.Win.Label
    Friend WithEvents Label72 As JBD.Gjs.Win.Label
    Friend WithEvents numKOFU_RITU As JBD.Gjs.Win.GcNumber
End Class
