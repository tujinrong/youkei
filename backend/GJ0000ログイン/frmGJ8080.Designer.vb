Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ8080
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
        Dim ValueProcess1 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange1 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim DateEraYearField1 As GrapeCity.Win.Editors.Fields.DateEraYearField = New GrapeCity.Win.Editors.Fields.DateEraYearField()
        Dim DateEraField1 As GrapeCity.Win.Editors.Fields.DateEraField = New GrapeCity.Win.Editors.Fields.DateEraField()
        Dim DateLiteralField1 As GrapeCity.Win.Editors.Fields.DateLiteralField = New GrapeCity.Win.Editors.Fields.DateLiteralField()
        Dim NumberSignDisplayField1 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField1 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField1 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField1 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
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
        Dim NumberDecimalSeparatorDisplayField12 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField12 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess13 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange13 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField13 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField13 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField13 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField13 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess14 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange14 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField14 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField14 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField14 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField14 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess15 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange15 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField15 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField15 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField15 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField15 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess16 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange16 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField16 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField16 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField16 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField16 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess17 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange17 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField17 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField17 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField17 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField17 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess18 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange18 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField18 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField18 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField18 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField18 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess19 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange19 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField19 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField19 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField19 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField19 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess20 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange20 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField20 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField20 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField20 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField20 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess21 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange21 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField21 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField21 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField21 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField21 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess22 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange22 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField22 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField22 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField22 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField22 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess23 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange23 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField23 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField23 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField23 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField23 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess24 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange24 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField24 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField24 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField24 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField24 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess25 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange25 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField25 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField25 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField25 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField25 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess26 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange26 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField26 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField26 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField26 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField26 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess27 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange27 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField27 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField27 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField27 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField27 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess28 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange28 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField28 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField28 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField28 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField28 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess29 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange29 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField29 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField29 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField29 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField29 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess30 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange30 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField30 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField30 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField30 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField30 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess31 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange31 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField31 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField31 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField31 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField31 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess32 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange32 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField32 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField32 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField32 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField32 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess33 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange33 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField33 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField33 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField33 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField33 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess34 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange34 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField34 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField34 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField34 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField34 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess35 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange35 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField35 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField35 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField35 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField35 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess36 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange36 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField36 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField36 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField36 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField36 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess37 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange37 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField37 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField37 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField37 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField37 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess38 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange38 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField38 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField38 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField38 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField38 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess39 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange39 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField39 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField39 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField39 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField39 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess40 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange40 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField40 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField40 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField40 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField40 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess41 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange41 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField41 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField41 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField41 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField41 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess42 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange42 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField42 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField42 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField42 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField42 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess43 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange43 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField43 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField43 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField43 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField43 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess44 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange44 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField44 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField44 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField44 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField44 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess45 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange45 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField45 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField45 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField45 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField45 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess46 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange46 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField46 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField46 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField46 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField46 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess47 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange47 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField47 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField47 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField47 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField47 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess48 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange48 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField48 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField48 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField48 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField48 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess49 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange49 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField49 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField49 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField49 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField49 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess50 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange50 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField50 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField50 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField50 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField50 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess51 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange51 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField51 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField51 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField51 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField51 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess52 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange52 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField52 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField52 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField52 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField52 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess53 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange53 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField53 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField53 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField53 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField53 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess54 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange54 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField54 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField54 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField54 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField54 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess55 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange55 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField55 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField55 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField55 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField55 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess56 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange56 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField56 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField56 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField56 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField56 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess57 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange57 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField57 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField57 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField57 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField57 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess58 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange58 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField58 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField58 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField58 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField58 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess59 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange59 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField59 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField59 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField59 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField59 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess60 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange60 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField60 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField60 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField60 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField60 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess61 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange61 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField61 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField61 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField61 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField61 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess62 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange62 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField62 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField62 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField62 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField62 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess63 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange63 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField63 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField63 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField63 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField63 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess64 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange64 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField64 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField64 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField64 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField64 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess65 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange65 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField65 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField65 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField65 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField65 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess66 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange66 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField66 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField66 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField66 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField66 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess67 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange67 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField67 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField67 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField67 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField67 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess68 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange68 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField68 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField68 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField68 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField68 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess69 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange69 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField69 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField69 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField69 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField69 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess70 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange70 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField70 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField70 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField70 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField70 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess71 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange71 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField71 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField71 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField71 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField71 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess72 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange72 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField72 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField72 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField72 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField72 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess73 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange73 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField73 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField73 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField73 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField73 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess74 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange74 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField74 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField74 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField74 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField74 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess75 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange75 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField75 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField75 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField75 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField75 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess76 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange76 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField76 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField76 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField76 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField76 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess77 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange77 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField77 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField77 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField77 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField77 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess78 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange78 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField78 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField78 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField78 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField78 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess79 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange79 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField79 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField79 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField79 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField79 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess80 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange80 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField80 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField80 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField80 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField80 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess81 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange81 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField81 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField81 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField81 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField81 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess82 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange82 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField82 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField82 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField82 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField82 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess83 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange83 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField83 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField83 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField83 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField83 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess84 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange84 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField84 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField84 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField84 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField84 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess85 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange85 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField85 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField85 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField85 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField85 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess86 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange86 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField86 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField86 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField86 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField86 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess87 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange87 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField87 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField87 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField87 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField87 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess88 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange88 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField88 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField88 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField88 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField88 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess89 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange89 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField89 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField89 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField89 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField89 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess90 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange90 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField90 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField90 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField90 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField90 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess91 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange91 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField91 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField91 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField91 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField91 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess92 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange92 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField92 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField92 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField92 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField92 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess93 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange93 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField93 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField93 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField93 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField93 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess94 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange94 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField94 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField94 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField94 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField94 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess95 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange95 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField95 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField95 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField95 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField95 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess96 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange96 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField96 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField96 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField96 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField96 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess97 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange97 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField97 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField97 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField97 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField97 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess98 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange98 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField98 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField98 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField98 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField98 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess99 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange99 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField99 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField99 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField99 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField99 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess100 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange100 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField100 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField100 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField100 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField100 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess101 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange101 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField101 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField101 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField101 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField101 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess102 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange102 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField102 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField102 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField102 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField102 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess103 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange103 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField103 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField103 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField103 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField103 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess104 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange104 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField104 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField104 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField104 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField104 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess105 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange105 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField105 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField105 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField105 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField105 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess106 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange106 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField106 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField106 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField106 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField106 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess107 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange107 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField107 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField107 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField107 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField107 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess108 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange108 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField108 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField108 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField108 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField108 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess109 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange109 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField109 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField109 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField109 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField109 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess110 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange110 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField110 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField110 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField110 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField110 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess111 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange111 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField111 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField111 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField111 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField111 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess112 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange112 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Dim NumberSignDisplayField112 As GrapeCity.Win.Editors.Fields.NumberSignDisplayField = New GrapeCity.Win.Editors.Fields.NumberSignDisplayField()
        Dim NumberIntegerPartDisplayField112 As GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberIntegerPartDisplayField()
        Dim NumberDecimalSeparatorDisplayField112 As GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalSeparatorDisplayField()
        Dim NumberDecimalPartDisplayField112 As GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField = New GrapeCity.Win.Editors.Fields.NumberDecimalPartDisplayField()
        Dim ValueProcess113 As GrapeCity.Win.Editors.ValueProcess = New GrapeCity.Win.Editors.ValueProcess()
        Dim InvalidRange113 As GrapeCity.Win.Editors.GcNumberValidator.InvalidRange = New GrapeCity.Win.Editors.GcNumberValidator.InvalidRange()
        Me.Label5 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label6 = New JBD.Gjs.Win.Label(Me.components)
        Me.numKI = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.dateTAISYO_NENDO = New JBD.Gjs.Win.GcDate(Me.components)
        Me.DropDownButton1 = New GrapeCity.Win.Editors.DropDownButton()
        Me.numKOYO_JOGEN11 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO11 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI11 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN11 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU11 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN11 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU12 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN12 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI12 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN12 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO12 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN12 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU13 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN13 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI13 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN13 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO13 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN13 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU14 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN14 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI14 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN14 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO14 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN14 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU15 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN15 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI15 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN15 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO15 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN15 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU25 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN25 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI25 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN25 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO25 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN25 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU24 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN24 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI24 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN24 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO24 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN24 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU23 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN23 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI23 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN23 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO23 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN23 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU22 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN22 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI22 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN22 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO22 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN22 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU21 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN21 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI21 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN21 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO21 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN21 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU36 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN36 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI36 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN36 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO36 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN36 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA36 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA25 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA24 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA23 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA22 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA21 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA15 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA14 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA13 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA12 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA11 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA37 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU37 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN37 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI37 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN37 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO37 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN37 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA38 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU38 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN38 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI38 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN38 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO38 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN38 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA39 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU39 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN39 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI39 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN39 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO39 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN39 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA40 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU40 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN40 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI40 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN40 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO40 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN40 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKUSYA41 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_SYOKYAKU41 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numGENKA_JOGEN41 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JIDAI41 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numJIDAI_JOGEN41 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_KOYO41 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.numKOYO_JOGEN41 = New JBD.Gjs.Win.GcNumber(Me.components)
        Me.cmdSearch = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdSave = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdDelete = New JBD.Gjs.Win.JButton(Me.components)
        Me.cmdCancel = New JBD.Gjs.Win.JButton(Me.components)
        Me.DropDownButton4 = New GrapeCity.Win.Editors.DropDownButton()
        Me.GcDateValidator1 = New GrapeCity.Win.Editors.GcDateValidator()
        Me.GcNumberValidator1 = New GrapeCity.Win.Editors.GcNumberValidator()
        Me.Label2 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label3 = New JBD.Gjs.Win.Label(Me.components)
        Me.DropDownButton11 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton2 = New GrapeCity.Win.Editors.DropDownButton()
        Me.DropDownButton3 = New GrapeCity.Win.Editors.DropDownButton()
        Me.Label4 = New JBD.Gjs.Win.Label(Me.components)
        Me.rdoARI = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.GroupBox1 = New JBD.Gjs.Win.GroupBox(Me.components)
        Me.rdoNASI = New JBD.Gjs.Win.RadioButton(Me.components)
        Me.Label7 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label8 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label9 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label10 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label11 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label15 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label12 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label16 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label17 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label18 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label25 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label26 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label29 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label30 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label31 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label34 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label27 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label32 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label35 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label36 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label37 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label38 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label28 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label33 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label39 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label40 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label41 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label42 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label43 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label44 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label45 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label46 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label13 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label14 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label19 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label20 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label21 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label22 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label23 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label24 = New JBD.Gjs.Win.Label(Me.components)
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
        Me.Label68 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label69 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label70 = New JBD.Gjs.Win.Label(Me.components)
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
        Me.Label84 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label85 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label86 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label87 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label88 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label89 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label90 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label91 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label92 = New JBD.Gjs.Win.Label(Me.components)
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
        Me.Label104 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label105 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label106 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label107 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label108 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label109 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label110 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label111 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label112 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label113 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label114 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label115 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label116 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label117 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label118 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label119 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label120 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label121 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label122 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label123 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label124 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label125 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label126 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label127 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label128 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label129 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label130 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label131 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label132 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label133 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label134 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label135 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label136 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label137 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label138 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label139 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label140 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label141 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label142 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label143 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label144 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label145 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label146 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label147 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label148 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label149 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label150 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label151 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label152 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label153 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label154 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label155 = New JBD.Gjs.Win.Label(Me.components)
        Me.Label156 = New JBD.Gjs.Win.Label(Me.components)
        Me.pnlButton.SuspendLayout()
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dateTAISYO_NENDO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKUSYA41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_SYOKYAKU41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGENKA_JOGEN41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JIDAI41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJIDAI_JOGEN41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_KOYO41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numKOYO_JOGEN41, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.cmdCancel)
        Me.pnlButton.Controls.Add(Me.cmdDelete)
        Me.pnlButton.Controls.Add(Me.cmdSave)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdEnd, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdSave, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdDelete, 0)
        Me.pnlButton.Controls.SetChildIndex(Me.cmdCancel, 0)
        '
        'cmdEnd
        '
        Me.cmdEnd.TabIndex = 99
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(63, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 957
        Me.Label5.Text = "■期"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(197, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 15)
        Me.Label6.TabIndex = 958
        Me.Label6.Text = "期"
        '
        'numKI
        '
        Me.numKI.AllowDeleteToNull = True
        Me.numKI.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.numKI.DropDown.AllowDrop = False
        Me.numKI.Fields.DecimalPart.MaxDigits = 0
        Me.numKI.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKI.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKI.Fields.IntegerPart.MaxDigits = 2
        Me.numKI.Fields.IntegerPart.MinDigits = 1
        Me.numKI.Fields.SignPrefix.NegativePattern = ""
        Me.numKI.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKI.HighlightText = True
        Me.numKI.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKI.InputCheck = True
        Me.numKI.Location = New System.Drawing.Point(151, 60)
        Me.numKI.Name = "numKI"
        Me.GcShortcut1.SetShortcuts(Me.numKI, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKI, Object), CType(Me.numKI, Object), CType(Me.numKI, Object), CType(Me.numKI, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKI.Size = New System.Drawing.Size(39, 20)
        Me.numKI.Spin.Increment = 0
        Me.numKI.TabIndex = 1
        ValueProcess1.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKI).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess1})
        InvalidRange1.MaxValue = New Decimal(New Integer() {99, 0, 0, 0})
        InvalidRange1.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKI).AddRange(New Object() {InvalidRange1})
        Me.numKI.Value = New Decimal(New Integer() {99, 0, 0, 0})
        Me.numKI.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        Me.numKI.ZeroSuppress = True
        '
        'dateTAISYO_NENDO
        '
        Me.dateTAISYO_NENDO.AcceptsCrLf = GrapeCity.Win.Editors.CrLfMode.Filter
        Me.dateTAISYO_NENDO.DefaultActiveField = DateEraYearField1
        Me.dateTAISYO_NENDO.DropDownCalendar.CalendarType = GrapeCity.Win.Editors.CalendarType.YearMonth
        Me.dateTAISYO_NENDO.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1})
        Me.dateTAISYO_NENDO.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.dateTAISYO_NENDO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.dateTAISYO_NENDO.InputCheck = True
        Me.dateTAISYO_NENDO.Location = New System.Drawing.Point(151, 95)
        Me.dateTAISYO_NENDO.Name = "dateTAISYO_NENDO"
        Me.GcShortcut1.SetShortcuts(Me.dateTAISYO_NENDO, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.F5, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.dateTAISYO_NENDO, Object), CType(Me.dateTAISYO_NENDO, Object), CType(Me.dateTAISYO_NENDO, Object)}, New String() {"ShortcutClear", "SetNow", "ApplyRecommendedValue"}))
        Me.dateTAISYO_NENDO.SideButtons.AddRange(New GrapeCity.Win.Editors.SideButtonBase() {Me.DropDownButton1})
        Me.dateTAISYO_NENDO.Size = New System.Drawing.Size(76, 20)
        Me.dateTAISYO_NENDO.Spin.AllowSpin = False
        Me.dateTAISYO_NENDO.TabIndex = 2
        Me.dateTAISYO_NENDO.Value = New Date(2015, 1, 16, 16, 39, 59, 0)
        '
        'DropDownButton1
        '
        Me.DropDownButton1.Name = "DropDownButton1"
        '
        'numKOYO_JOGEN11
        '
        Me.numKOYO_JOGEN11.AllowDeleteToNull = True
        NumberIntegerPartDisplayField1.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField1.MaxDigits = 5
        NumberDecimalPartDisplayField1.MinDigits = 5
        Me.numKOYO_JOGEN11.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField1, NumberIntegerPartDisplayField1, NumberDecimalSeparatorDisplayField1, NumberDecimalPartDisplayField1})
        Me.numKOYO_JOGEN11.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN11.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN11.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN11.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN11.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN11.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN11.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN11.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN11.HighlightText = True
        Me.numKOYO_JOGEN11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN11.InputCheck = True
        Me.numKOYO_JOGEN11.Location = New System.Drawing.Point(209, 221)
        Me.numKOYO_JOGEN11.Name = "numKOYO_JOGEN11"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN11, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN11, Object), CType(Me.numKOYO_JOGEN11, Object), CType(Me.numKOYO_JOGEN11, Object), CType(Me.numKOYO_JOGEN11, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN11.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN11.Spin.Increment = 0
        Me.numKOYO_JOGEN11.TabIndex = 7
        ValueProcess2.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN11).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess2})
        InvalidRange2.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange2.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN11).AddRange(New Object() {InvalidRange2})
        Me.numKOYO_JOGEN11.Value = New Decimal(New Integer() {999999999, 0, 0, 327680})
        Me.numKOYO_JOGEN11.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO11
        '
        Me.numKOYO_KOYO11.AllowDeleteToNull = True
        NumberIntegerPartDisplayField2.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField2.MaxDigits = 5
        NumberDecimalPartDisplayField2.MinDigits = 5
        Me.numKOYO_KOYO11.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField2, NumberIntegerPartDisplayField2, NumberDecimalSeparatorDisplayField2, NumberDecimalPartDisplayField2})
        Me.numKOYO_KOYO11.DropDown.AllowDrop = False
        Me.numKOYO_KOYO11.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO11.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO11.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO11.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO11.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO11.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO11.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO11.HighlightText = True
        Me.numKOYO_KOYO11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO11.InputCheck = True
        Me.numKOYO_KOYO11.Location = New System.Drawing.Point(316, 220)
        Me.numKOYO_KOYO11.Name = "numKOYO_KOYO11"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO11, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO11, Object), CType(Me.numKOYO_KOYO11, Object), CType(Me.numKOYO_KOYO11, Object), CType(Me.numKOYO_KOYO11, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO11.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO11.Spin.Increment = 0
        Me.numKOYO_KOYO11.TabIndex = 8
        ValueProcess3.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO11).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess3})
        InvalidRange3.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange3.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO11).AddRange(New Object() {InvalidRange3})
        Me.numKOYO_KOYO11.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO11.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI11
        '
        Me.numJIDAI_JIDAI11.AllowDeleteToNull = True
        NumberIntegerPartDisplayField3.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField3.MaxDigits = 5
        NumberDecimalPartDisplayField3.MinDigits = 5
        Me.numJIDAI_JIDAI11.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField3, NumberIntegerPartDisplayField3, NumberDecimalSeparatorDisplayField3, NumberDecimalPartDisplayField3})
        Me.numJIDAI_JIDAI11.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI11.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI11.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI11.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI11.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI11.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI11.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI11.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI11.HighlightText = True
        Me.numJIDAI_JIDAI11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI11.InputCheck = True
        Me.numJIDAI_JIDAI11.Location = New System.Drawing.Point(530, 220)
        Me.numJIDAI_JIDAI11.Name = "numJIDAI_JIDAI11"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI11, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI11, Object), CType(Me.numJIDAI_JIDAI11, Object), CType(Me.numJIDAI_JIDAI11, Object), CType(Me.numJIDAI_JIDAI11, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI11.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI11.Spin.Increment = 0
        Me.numJIDAI_JIDAI11.TabIndex = 10
        ValueProcess4.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI11).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess4})
        InvalidRange4.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange4.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI11).AddRange(New Object() {InvalidRange4})
        Me.numJIDAI_JIDAI11.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI11.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN11
        '
        Me.numJIDAI_JOGEN11.AllowDeleteToNull = True
        NumberIntegerPartDisplayField4.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField4.MaxDigits = 5
        NumberDecimalPartDisplayField4.MinDigits = 5
        Me.numJIDAI_JOGEN11.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField4, NumberIntegerPartDisplayField4, NumberDecimalSeparatorDisplayField4, NumberDecimalPartDisplayField4})
        Me.numJIDAI_JOGEN11.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN11.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN11.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN11.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN11.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN11.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN11.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN11.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN11.HighlightText = True
        Me.numJIDAI_JOGEN11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN11.InputCheck = True
        Me.numJIDAI_JOGEN11.Location = New System.Drawing.Point(423, 220)
        Me.numJIDAI_JOGEN11.Name = "numJIDAI_JOGEN11"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN11, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN11, Object), CType(Me.numJIDAI_JOGEN11, Object), CType(Me.numJIDAI_JOGEN11, Object), CType(Me.numJIDAI_JOGEN11, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN11.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN11.Spin.Increment = 0
        Me.numJIDAI_JOGEN11.TabIndex = 9
        ValueProcess5.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN11).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess5})
        InvalidRange5.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange5.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN11).AddRange(New Object() {InvalidRange5})
        Me.numJIDAI_JOGEN11.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN11.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU11
        '
        Me.numGENKA_SYOKYAKU11.AllowDeleteToNull = True
        NumberIntegerPartDisplayField5.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField5.MaxDigits = 5
        NumberDecimalPartDisplayField5.MinDigits = 5
        Me.numGENKA_SYOKYAKU11.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField5, NumberIntegerPartDisplayField5, NumberDecimalSeparatorDisplayField5, NumberDecimalPartDisplayField5})
        Me.numGENKA_SYOKYAKU11.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU11.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU11.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU11.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU11.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU11.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU11.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU11.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU11.HighlightText = True
        Me.numGENKA_SYOKYAKU11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU11.InputCheck = True
        Me.numGENKA_SYOKYAKU11.Location = New System.Drawing.Point(743, 220)
        Me.numGENKA_SYOKYAKU11.Name = "numGENKA_SYOKYAKU11"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU11, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU11, Object), CType(Me.numGENKA_SYOKYAKU11, Object), CType(Me.numGENKA_SYOKYAKU11, Object), CType(Me.numGENKA_SYOKYAKU11, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU11.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU11.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU11.TabIndex = 12
        ValueProcess6.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU11).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess6})
        InvalidRange6.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange6.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU11).AddRange(New Object() {InvalidRange6})
        Me.numGENKA_SYOKYAKU11.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU11.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN11
        '
        Me.numGENKA_JOGEN11.AllowDeleteToNull = True
        NumberIntegerPartDisplayField6.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField6.MaxDigits = 5
        NumberDecimalPartDisplayField6.MinDigits = 5
        Me.numGENKA_JOGEN11.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField6, NumberIntegerPartDisplayField6, NumberDecimalSeparatorDisplayField6, NumberDecimalPartDisplayField6})
        Me.numGENKA_JOGEN11.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN11.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN11.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN11.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN11.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN11.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN11.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN11.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN11.HighlightText = True
        Me.numGENKA_JOGEN11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN11.InputCheck = True
        Me.numGENKA_JOGEN11.Location = New System.Drawing.Point(637, 220)
        Me.numGENKA_JOGEN11.Name = "numGENKA_JOGEN11"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN11, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN11, Object), CType(Me.numGENKA_JOGEN11, Object), CType(Me.numGENKA_JOGEN11, Object), CType(Me.numGENKA_JOGEN11, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN11.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN11.Spin.Increment = 0
        Me.numGENKA_JOGEN11.TabIndex = 11
        ValueProcess7.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN11).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess7})
        InvalidRange7.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange7.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN11).AddRange(New Object() {InvalidRange7})
        Me.numGENKA_JOGEN11.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN11.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU12
        '
        Me.numGENKA_SYOKYAKU12.AllowDeleteToNull = True
        NumberIntegerPartDisplayField7.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField7.MaxDigits = 5
        NumberDecimalPartDisplayField7.MinDigits = 5
        Me.numGENKA_SYOKYAKU12.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField7, NumberIntegerPartDisplayField7, NumberDecimalSeparatorDisplayField7, NumberDecimalPartDisplayField7})
        Me.numGENKA_SYOKYAKU12.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU12.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU12.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU12.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU12.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU12.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU12.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU12.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU12.HighlightText = True
        Me.numGENKA_SYOKYAKU12.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU12.InputCheck = True
        Me.numGENKA_SYOKYAKU12.Location = New System.Drawing.Point(743, 245)
        Me.numGENKA_SYOKYAKU12.Name = "numGENKA_SYOKYAKU12"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU12, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU12, Object), CType(Me.numGENKA_SYOKYAKU12, Object), CType(Me.numGENKA_SYOKYAKU12, Object), CType(Me.numGENKA_SYOKYAKU12, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU12.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU12.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU12.TabIndex = 19
        ValueProcess8.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU12).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess8})
        InvalidRange8.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange8.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU12).AddRange(New Object() {InvalidRange8})
        Me.numGENKA_SYOKYAKU12.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU12.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN12
        '
        Me.numGENKA_JOGEN12.AllowDeleteToNull = True
        NumberIntegerPartDisplayField8.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField8.MaxDigits = 5
        NumberDecimalPartDisplayField8.MinDigits = 5
        Me.numGENKA_JOGEN12.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField8, NumberIntegerPartDisplayField8, NumberDecimalSeparatorDisplayField8, NumberDecimalPartDisplayField8})
        Me.numGENKA_JOGEN12.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN12.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN12.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN12.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN12.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN12.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN12.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN12.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN12.HighlightText = True
        Me.numGENKA_JOGEN12.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN12.InputCheck = True
        Me.numGENKA_JOGEN12.Location = New System.Drawing.Point(637, 245)
        Me.numGENKA_JOGEN12.Name = "numGENKA_JOGEN12"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN12, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN12, Object), CType(Me.numGENKA_JOGEN12, Object), CType(Me.numGENKA_JOGEN12, Object), CType(Me.numGENKA_JOGEN12, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN12.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN12.Spin.Increment = 0
        Me.numGENKA_JOGEN12.TabIndex = 18
        ValueProcess9.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN12).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess9})
        InvalidRange9.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange9.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN12).AddRange(New Object() {InvalidRange9})
        Me.numGENKA_JOGEN12.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN12.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI12
        '
        Me.numJIDAI_JIDAI12.AllowDeleteToNull = True
        NumberIntegerPartDisplayField9.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField9.MaxDigits = 5
        NumberDecimalPartDisplayField9.MinDigits = 5
        Me.numJIDAI_JIDAI12.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField9, NumberIntegerPartDisplayField9, NumberDecimalSeparatorDisplayField9, NumberDecimalPartDisplayField9})
        Me.numJIDAI_JIDAI12.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI12.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI12.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI12.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI12.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI12.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI12.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI12.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI12.HighlightText = True
        Me.numJIDAI_JIDAI12.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI12.InputCheck = True
        Me.numJIDAI_JIDAI12.Location = New System.Drawing.Point(530, 245)
        Me.numJIDAI_JIDAI12.Name = "numJIDAI_JIDAI12"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI12, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI12, Object), CType(Me.numJIDAI_JIDAI12, Object), CType(Me.numJIDAI_JIDAI12, Object), CType(Me.numJIDAI_JIDAI12, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI12.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI12.Spin.Increment = 0
        Me.numJIDAI_JIDAI12.TabIndex = 17
        ValueProcess10.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI12).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess10})
        InvalidRange10.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange10.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI12).AddRange(New Object() {InvalidRange10})
        Me.numJIDAI_JIDAI12.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI12.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN12
        '
        Me.numJIDAI_JOGEN12.AllowDeleteToNull = True
        NumberIntegerPartDisplayField10.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField10.MaxDigits = 5
        NumberDecimalPartDisplayField10.MinDigits = 5
        Me.numJIDAI_JOGEN12.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField10, NumberIntegerPartDisplayField10, NumberDecimalSeparatorDisplayField10, NumberDecimalPartDisplayField10})
        Me.numJIDAI_JOGEN12.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN12.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN12.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN12.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN12.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN12.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN12.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN12.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN12.HighlightText = True
        Me.numJIDAI_JOGEN12.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN12.InputCheck = True
        Me.numJIDAI_JOGEN12.Location = New System.Drawing.Point(423, 245)
        Me.numJIDAI_JOGEN12.Name = "numJIDAI_JOGEN12"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN12, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN12, Object), CType(Me.numJIDAI_JOGEN12, Object), CType(Me.numJIDAI_JOGEN12, Object), CType(Me.numJIDAI_JOGEN12, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN12.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN12.Spin.Increment = 0
        Me.numJIDAI_JOGEN12.TabIndex = 16
        ValueProcess11.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN12).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess11})
        InvalidRange11.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange11.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN12).AddRange(New Object() {InvalidRange11})
        Me.numJIDAI_JOGEN12.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN12.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO12
        '
        Me.numKOYO_KOYO12.AllowDeleteToNull = True
        NumberIntegerPartDisplayField11.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField11.MaxDigits = 5
        NumberDecimalPartDisplayField11.MinDigits = 5
        Me.numKOYO_KOYO12.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField11, NumberIntegerPartDisplayField11, NumberDecimalSeparatorDisplayField11, NumberDecimalPartDisplayField11})
        Me.numKOYO_KOYO12.DropDown.AllowDrop = False
        Me.numKOYO_KOYO12.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO12.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO12.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO12.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO12.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO12.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO12.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO12.HighlightText = True
        Me.numKOYO_KOYO12.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO12.InputCheck = True
        Me.numKOYO_KOYO12.Location = New System.Drawing.Point(316, 245)
        Me.numKOYO_KOYO12.Name = "numKOYO_KOYO12"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO12, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO12, Object), CType(Me.numKOYO_KOYO12, Object), CType(Me.numKOYO_KOYO12, Object), CType(Me.numKOYO_KOYO12, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO12.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO12.Spin.Increment = 0
        Me.numKOYO_KOYO12.TabIndex = 15
        ValueProcess12.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO12).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess12})
        InvalidRange12.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange12.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO12).AddRange(New Object() {InvalidRange12})
        Me.numKOYO_KOYO12.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO12.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN12
        '
        Me.numKOYO_JOGEN12.AllowDeleteToNull = True
        NumberIntegerPartDisplayField12.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField12.MaxDigits = 5
        NumberDecimalPartDisplayField12.MinDigits = 5
        Me.numKOYO_JOGEN12.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField12, NumberIntegerPartDisplayField12, NumberDecimalSeparatorDisplayField12, NumberDecimalPartDisplayField12})
        Me.numKOYO_JOGEN12.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN12.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN12.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN12.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN12.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN12.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN12.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN12.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN12.HighlightText = True
        Me.numKOYO_JOGEN12.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN12.InputCheck = True
        Me.numKOYO_JOGEN12.Location = New System.Drawing.Point(209, 245)
        Me.numKOYO_JOGEN12.Name = "numKOYO_JOGEN12"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN12, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN12, Object), CType(Me.numKOYO_JOGEN12, Object), CType(Me.numKOYO_JOGEN12, Object), CType(Me.numKOYO_JOGEN12, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN12.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN12.Spin.Increment = 0
        Me.numKOYO_JOGEN12.TabIndex = 14
        ValueProcess13.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN12).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess13})
        InvalidRange13.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange13.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN12).AddRange(New Object() {InvalidRange13})
        Me.numKOYO_JOGEN12.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_JOGEN12.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU13
        '
        Me.numGENKA_SYOKYAKU13.AllowDeleteToNull = True
        NumberIntegerPartDisplayField13.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField13.MaxDigits = 5
        NumberDecimalPartDisplayField13.MinDigits = 5
        Me.numGENKA_SYOKYAKU13.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField13, NumberIntegerPartDisplayField13, NumberDecimalSeparatorDisplayField13, NumberDecimalPartDisplayField13})
        Me.numGENKA_SYOKYAKU13.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU13.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU13.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU13.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU13.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU13.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU13.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU13.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU13.HighlightText = True
        Me.numGENKA_SYOKYAKU13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU13.InputCheck = True
        Me.numGENKA_SYOKYAKU13.Location = New System.Drawing.Point(743, 270)
        Me.numGENKA_SYOKYAKU13.Name = "numGENKA_SYOKYAKU13"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU13, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU13, Object), CType(Me.numGENKA_SYOKYAKU13, Object), CType(Me.numGENKA_SYOKYAKU13, Object), CType(Me.numGENKA_SYOKYAKU13, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU13.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU13.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU13.TabIndex = 26
        ValueProcess14.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU13).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess14})
        InvalidRange14.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange14.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU13).AddRange(New Object() {InvalidRange14})
        Me.numGENKA_SYOKYAKU13.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU13.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN13
        '
        Me.numGENKA_JOGEN13.AllowDeleteToNull = True
        NumberIntegerPartDisplayField14.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField14.MaxDigits = 5
        NumberDecimalPartDisplayField14.MinDigits = 5
        Me.numGENKA_JOGEN13.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField14, NumberIntegerPartDisplayField14, NumberDecimalSeparatorDisplayField14, NumberDecimalPartDisplayField14})
        Me.numGENKA_JOGEN13.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN13.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN13.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN13.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN13.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN13.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN13.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN13.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN13.HighlightText = True
        Me.numGENKA_JOGEN13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN13.InputCheck = True
        Me.numGENKA_JOGEN13.Location = New System.Drawing.Point(637, 270)
        Me.numGENKA_JOGEN13.Name = "numGENKA_JOGEN13"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN13, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN13, Object), CType(Me.numGENKA_JOGEN13, Object), CType(Me.numGENKA_JOGEN13, Object), CType(Me.numGENKA_JOGEN13, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN13.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN13.Spin.Increment = 0
        Me.numGENKA_JOGEN13.TabIndex = 25
        ValueProcess15.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN13).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess15})
        InvalidRange15.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange15.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN13).AddRange(New Object() {InvalidRange15})
        Me.numGENKA_JOGEN13.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN13.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI13
        '
        Me.numJIDAI_JIDAI13.AllowDeleteToNull = True
        NumberIntegerPartDisplayField15.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField15.MaxDigits = 5
        NumberDecimalPartDisplayField15.MinDigits = 5
        Me.numJIDAI_JIDAI13.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField15, NumberIntegerPartDisplayField15, NumberDecimalSeparatorDisplayField15, NumberDecimalPartDisplayField15})
        Me.numJIDAI_JIDAI13.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI13.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI13.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI13.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI13.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI13.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI13.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI13.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI13.HighlightText = True
        Me.numJIDAI_JIDAI13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI13.InputCheck = True
        Me.numJIDAI_JIDAI13.Location = New System.Drawing.Point(530, 270)
        Me.numJIDAI_JIDAI13.Name = "numJIDAI_JIDAI13"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI13, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI13, Object), CType(Me.numJIDAI_JIDAI13, Object), CType(Me.numJIDAI_JIDAI13, Object), CType(Me.numJIDAI_JIDAI13, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI13.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI13.Spin.Increment = 0
        Me.numJIDAI_JIDAI13.TabIndex = 24
        ValueProcess16.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI13).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess16})
        InvalidRange16.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange16.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI13).AddRange(New Object() {InvalidRange16})
        Me.numJIDAI_JIDAI13.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI13.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN13
        '
        Me.numJIDAI_JOGEN13.AllowDeleteToNull = True
        NumberIntegerPartDisplayField16.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField16.MaxDigits = 5
        NumberDecimalPartDisplayField16.MinDigits = 5
        Me.numJIDAI_JOGEN13.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField16, NumberIntegerPartDisplayField16, NumberDecimalSeparatorDisplayField16, NumberDecimalPartDisplayField16})
        Me.numJIDAI_JOGEN13.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN13.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN13.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN13.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN13.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN13.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN13.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN13.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN13.HighlightText = True
        Me.numJIDAI_JOGEN13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN13.InputCheck = True
        Me.numJIDAI_JOGEN13.Location = New System.Drawing.Point(423, 270)
        Me.numJIDAI_JOGEN13.Name = "numJIDAI_JOGEN13"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN13, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN13, Object), CType(Me.numJIDAI_JOGEN13, Object), CType(Me.numJIDAI_JOGEN13, Object), CType(Me.numJIDAI_JOGEN13, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN13.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN13.Spin.Increment = 0
        Me.numJIDAI_JOGEN13.TabIndex = 23
        ValueProcess17.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN13).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess17})
        InvalidRange17.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange17.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN13).AddRange(New Object() {InvalidRange17})
        Me.numJIDAI_JOGEN13.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN13.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO13
        '
        Me.numKOYO_KOYO13.AllowDeleteToNull = True
        NumberIntegerPartDisplayField17.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField17.MaxDigits = 5
        NumberDecimalPartDisplayField17.MinDigits = 5
        Me.numKOYO_KOYO13.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField17, NumberIntegerPartDisplayField17, NumberDecimalSeparatorDisplayField17, NumberDecimalPartDisplayField17})
        Me.numKOYO_KOYO13.DropDown.AllowDrop = False
        Me.numKOYO_KOYO13.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO13.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO13.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO13.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO13.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO13.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO13.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO13.HighlightText = True
        Me.numKOYO_KOYO13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO13.InputCheck = True
        Me.numKOYO_KOYO13.Location = New System.Drawing.Point(316, 270)
        Me.numKOYO_KOYO13.Name = "numKOYO_KOYO13"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO13, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO13, Object), CType(Me.numKOYO_KOYO13, Object), CType(Me.numKOYO_KOYO13, Object), CType(Me.numKOYO_KOYO13, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO13.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO13.Spin.Increment = 0
        Me.numKOYO_KOYO13.TabIndex = 22
        ValueProcess18.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO13).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess18})
        InvalidRange18.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange18.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO13).AddRange(New Object() {InvalidRange18})
        Me.numKOYO_KOYO13.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO13.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN13
        '
        Me.numKOYO_JOGEN13.AllowDeleteToNull = True
        NumberIntegerPartDisplayField18.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField18.MaxDigits = 5
        NumberDecimalPartDisplayField18.MinDigits = 5
        Me.numKOYO_JOGEN13.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField18, NumberIntegerPartDisplayField18, NumberDecimalSeparatorDisplayField18, NumberDecimalPartDisplayField18})
        Me.numKOYO_JOGEN13.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN13.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN13.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN13.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN13.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN13.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN13.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN13.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN13.HighlightText = True
        Me.numKOYO_JOGEN13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN13.InputCheck = True
        Me.numKOYO_JOGEN13.Location = New System.Drawing.Point(209, 270)
        Me.numKOYO_JOGEN13.Name = "numKOYO_JOGEN13"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN13, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN13, Object), CType(Me.numKOYO_JOGEN13, Object), CType(Me.numKOYO_JOGEN13, Object), CType(Me.numKOYO_JOGEN13, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN13.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN13.Spin.Increment = 0
        Me.numKOYO_JOGEN13.TabIndex = 21
        ValueProcess19.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN13).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess19})
        InvalidRange19.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange19.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN13).AddRange(New Object() {InvalidRange19})
        Me.numKOYO_JOGEN13.Value = New Decimal(New Integer() {999900000, 0, 0, 327680})
        Me.numKOYO_JOGEN13.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU14
        '
        Me.numGENKA_SYOKYAKU14.AllowDeleteToNull = True
        NumberIntegerPartDisplayField19.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField19.MaxDigits = 5
        NumberDecimalPartDisplayField19.MinDigits = 5
        Me.numGENKA_SYOKYAKU14.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField19, NumberIntegerPartDisplayField19, NumberDecimalSeparatorDisplayField19, NumberDecimalPartDisplayField19})
        Me.numGENKA_SYOKYAKU14.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU14.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU14.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU14.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU14.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU14.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU14.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU14.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU14.HighlightText = True
        Me.numGENKA_SYOKYAKU14.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU14.InputCheck = True
        Me.numGENKA_SYOKYAKU14.Location = New System.Drawing.Point(743, 295)
        Me.numGENKA_SYOKYAKU14.Name = "numGENKA_SYOKYAKU14"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU14, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU14, Object), CType(Me.numGENKA_SYOKYAKU14, Object), CType(Me.numGENKA_SYOKYAKU14, Object), CType(Me.numGENKA_SYOKYAKU14, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU14.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU14.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU14.TabIndex = 33
        ValueProcess20.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU14).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess20})
        InvalidRange20.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange20.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU14).AddRange(New Object() {InvalidRange20})
        Me.numGENKA_SYOKYAKU14.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU14.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN14
        '
        Me.numGENKA_JOGEN14.AllowDeleteToNull = True
        NumberIntegerPartDisplayField20.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField20.MaxDigits = 5
        NumberDecimalPartDisplayField20.MinDigits = 5
        Me.numGENKA_JOGEN14.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField20, NumberIntegerPartDisplayField20, NumberDecimalSeparatorDisplayField20, NumberDecimalPartDisplayField20})
        Me.numGENKA_JOGEN14.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN14.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN14.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN14.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN14.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN14.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN14.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN14.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN14.HighlightText = True
        Me.numGENKA_JOGEN14.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN14.InputCheck = True
        Me.numGENKA_JOGEN14.Location = New System.Drawing.Point(637, 295)
        Me.numGENKA_JOGEN14.Name = "numGENKA_JOGEN14"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN14, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN14, Object), CType(Me.numGENKA_JOGEN14, Object), CType(Me.numGENKA_JOGEN14, Object), CType(Me.numGENKA_JOGEN14, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN14.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN14.Spin.Increment = 0
        Me.numGENKA_JOGEN14.TabIndex = 32
        ValueProcess21.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN14).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess21})
        InvalidRange21.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange21.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN14).AddRange(New Object() {InvalidRange21})
        Me.numGENKA_JOGEN14.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN14.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI14
        '
        Me.numJIDAI_JIDAI14.AllowDeleteToNull = True
        NumberIntegerPartDisplayField21.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField21.MaxDigits = 5
        NumberDecimalPartDisplayField21.MinDigits = 5
        Me.numJIDAI_JIDAI14.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField21, NumberIntegerPartDisplayField21, NumberDecimalSeparatorDisplayField21, NumberDecimalPartDisplayField21})
        Me.numJIDAI_JIDAI14.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI14.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI14.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI14.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI14.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI14.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI14.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI14.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI14.HighlightText = True
        Me.numJIDAI_JIDAI14.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI14.InputCheck = True
        Me.numJIDAI_JIDAI14.Location = New System.Drawing.Point(530, 295)
        Me.numJIDAI_JIDAI14.Name = "numJIDAI_JIDAI14"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI14, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI14, Object), CType(Me.numJIDAI_JIDAI14, Object), CType(Me.numJIDAI_JIDAI14, Object), CType(Me.numJIDAI_JIDAI14, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI14.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI14.Spin.Increment = 0
        Me.numJIDAI_JIDAI14.TabIndex = 31
        ValueProcess22.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI14).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess22})
        InvalidRange22.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange22.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI14).AddRange(New Object() {InvalidRange22})
        Me.numJIDAI_JIDAI14.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI14.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN14
        '
        Me.numJIDAI_JOGEN14.AllowDeleteToNull = True
        NumberIntegerPartDisplayField22.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField22.MaxDigits = 5
        NumberDecimalPartDisplayField22.MinDigits = 5
        Me.numJIDAI_JOGEN14.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField22, NumberIntegerPartDisplayField22, NumberDecimalSeparatorDisplayField22, NumberDecimalPartDisplayField22})
        Me.numJIDAI_JOGEN14.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN14.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN14.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN14.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN14.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN14.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN14.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN14.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN14.HighlightText = True
        Me.numJIDAI_JOGEN14.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN14.InputCheck = True
        Me.numJIDAI_JOGEN14.Location = New System.Drawing.Point(423, 295)
        Me.numJIDAI_JOGEN14.Name = "numJIDAI_JOGEN14"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN14, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN14, Object), CType(Me.numJIDAI_JOGEN14, Object), CType(Me.numJIDAI_JOGEN14, Object), CType(Me.numJIDAI_JOGEN14, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN14.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN14.Spin.Increment = 0
        Me.numJIDAI_JOGEN14.TabIndex = 30
        ValueProcess23.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN14).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess23})
        InvalidRange23.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange23.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN14).AddRange(New Object() {InvalidRange23})
        Me.numJIDAI_JOGEN14.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN14.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO14
        '
        Me.numKOYO_KOYO14.AllowDeleteToNull = True
        NumberIntegerPartDisplayField23.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField23.MaxDigits = 5
        NumberDecimalPartDisplayField23.MinDigits = 5
        Me.numKOYO_KOYO14.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField23, NumberIntegerPartDisplayField23, NumberDecimalSeparatorDisplayField23, NumberDecimalPartDisplayField23})
        Me.numKOYO_KOYO14.DropDown.AllowDrop = False
        Me.numKOYO_KOYO14.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO14.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO14.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO14.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO14.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO14.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO14.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO14.HighlightText = True
        Me.numKOYO_KOYO14.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO14.InputCheck = True
        Me.numKOYO_KOYO14.Location = New System.Drawing.Point(316, 295)
        Me.numKOYO_KOYO14.Name = "numKOYO_KOYO14"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO14, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO14, Object), CType(Me.numKOYO_KOYO14, Object), CType(Me.numKOYO_KOYO14, Object), CType(Me.numKOYO_KOYO14, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO14.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO14.Spin.Increment = 0
        Me.numKOYO_KOYO14.TabIndex = 29
        ValueProcess24.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO14).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess24})
        InvalidRange24.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange24.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO14).AddRange(New Object() {InvalidRange24})
        Me.numKOYO_KOYO14.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO14.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN14
        '
        Me.numKOYO_JOGEN14.AllowDeleteToNull = True
        NumberIntegerPartDisplayField24.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField24.MaxDigits = 5
        NumberDecimalPartDisplayField24.MinDigits = 5
        Me.numKOYO_JOGEN14.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField24, NumberIntegerPartDisplayField24, NumberDecimalSeparatorDisplayField24, NumberDecimalPartDisplayField24})
        Me.numKOYO_JOGEN14.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN14.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN14.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN14.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN14.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN14.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN14.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN14.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN14.HighlightText = True
        Me.numKOYO_JOGEN14.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN14.InputCheck = True
        Me.numKOYO_JOGEN14.Location = New System.Drawing.Point(209, 295)
        Me.numKOYO_JOGEN14.Name = "numKOYO_JOGEN14"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN14, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN14, Object), CType(Me.numKOYO_JOGEN14, Object), CType(Me.numKOYO_JOGEN14, Object), CType(Me.numKOYO_JOGEN14, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN14.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN14.Spin.Increment = 0
        Me.numKOYO_JOGEN14.TabIndex = 28
        ValueProcess25.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN14).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess25})
        InvalidRange25.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange25.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN14).AddRange(New Object() {InvalidRange25})
        Me.numKOYO_JOGEN14.Value = New Decimal(New Integer() {999900000, 0, 0, 327680})
        Me.numKOYO_JOGEN14.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU15
        '
        Me.numGENKA_SYOKYAKU15.AllowDeleteToNull = True
        NumberIntegerPartDisplayField25.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField25.MaxDigits = 5
        NumberDecimalPartDisplayField25.MinDigits = 5
        Me.numGENKA_SYOKYAKU15.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField25, NumberIntegerPartDisplayField25, NumberDecimalSeparatorDisplayField25, NumberDecimalPartDisplayField25})
        Me.numGENKA_SYOKYAKU15.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU15.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU15.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU15.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU15.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU15.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU15.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU15.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU15.HighlightText = True
        Me.numGENKA_SYOKYAKU15.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU15.InputCheck = True
        Me.numGENKA_SYOKYAKU15.Location = New System.Drawing.Point(743, 320)
        Me.numGENKA_SYOKYAKU15.Name = "numGENKA_SYOKYAKU15"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU15, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU15, Object), CType(Me.numGENKA_SYOKYAKU15, Object), CType(Me.numGENKA_SYOKYAKU15, Object), CType(Me.numGENKA_SYOKYAKU15, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU15.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU15.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU15.TabIndex = 40
        ValueProcess26.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU15).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess26})
        InvalidRange26.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange26.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU15).AddRange(New Object() {InvalidRange26})
        Me.numGENKA_SYOKYAKU15.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU15.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN15
        '
        Me.numGENKA_JOGEN15.AllowDeleteToNull = True
        NumberIntegerPartDisplayField26.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField26.MaxDigits = 5
        NumberDecimalPartDisplayField26.MinDigits = 5
        Me.numGENKA_JOGEN15.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField26, NumberIntegerPartDisplayField26, NumberDecimalSeparatorDisplayField26, NumberDecimalPartDisplayField26})
        Me.numGENKA_JOGEN15.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN15.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN15.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN15.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN15.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN15.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN15.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN15.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN15.HighlightText = True
        Me.numGENKA_JOGEN15.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN15.InputCheck = True
        Me.numGENKA_JOGEN15.Location = New System.Drawing.Point(637, 320)
        Me.numGENKA_JOGEN15.Name = "numGENKA_JOGEN15"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN15, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN15, Object), CType(Me.numGENKA_JOGEN15, Object), CType(Me.numGENKA_JOGEN15, Object), CType(Me.numGENKA_JOGEN15, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN15.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN15.Spin.Increment = 0
        Me.numGENKA_JOGEN15.TabIndex = 39
        ValueProcess27.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN15).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess27})
        InvalidRange27.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange27.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN15).AddRange(New Object() {InvalidRange27})
        Me.numGENKA_JOGEN15.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN15.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI15
        '
        Me.numJIDAI_JIDAI15.AllowDeleteToNull = True
        NumberIntegerPartDisplayField27.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField27.MaxDigits = 5
        NumberDecimalPartDisplayField27.MinDigits = 5
        Me.numJIDAI_JIDAI15.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField27, NumberIntegerPartDisplayField27, NumberDecimalSeparatorDisplayField27, NumberDecimalPartDisplayField27})
        Me.numJIDAI_JIDAI15.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI15.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI15.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI15.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI15.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI15.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI15.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI15.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI15.HighlightText = True
        Me.numJIDAI_JIDAI15.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI15.InputCheck = True
        Me.numJIDAI_JIDAI15.Location = New System.Drawing.Point(530, 320)
        Me.numJIDAI_JIDAI15.Name = "numJIDAI_JIDAI15"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI15, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI15, Object), CType(Me.numJIDAI_JIDAI15, Object), CType(Me.numJIDAI_JIDAI15, Object), CType(Me.numJIDAI_JIDAI15, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI15.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI15.Spin.Increment = 0
        Me.numJIDAI_JIDAI15.TabIndex = 38
        ValueProcess28.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI15).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess28})
        InvalidRange28.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange28.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI15).AddRange(New Object() {InvalidRange28})
        Me.numJIDAI_JIDAI15.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI15.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN15
        '
        Me.numJIDAI_JOGEN15.AllowDeleteToNull = True
        NumberIntegerPartDisplayField28.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField28.MaxDigits = 5
        NumberDecimalPartDisplayField28.MinDigits = 5
        Me.numJIDAI_JOGEN15.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField28, NumberIntegerPartDisplayField28, NumberDecimalSeparatorDisplayField28, NumberDecimalPartDisplayField28})
        Me.numJIDAI_JOGEN15.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN15.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN15.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN15.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN15.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN15.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN15.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN15.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN15.HighlightText = True
        Me.numJIDAI_JOGEN15.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN15.InputCheck = True
        Me.numJIDAI_JOGEN15.Location = New System.Drawing.Point(423, 320)
        Me.numJIDAI_JOGEN15.Name = "numJIDAI_JOGEN15"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN15, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN15, Object), CType(Me.numJIDAI_JOGEN15, Object), CType(Me.numJIDAI_JOGEN15, Object), CType(Me.numJIDAI_JOGEN15, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN15.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN15.Spin.Increment = 0
        Me.numJIDAI_JOGEN15.TabIndex = 37
        ValueProcess29.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN15).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess29})
        InvalidRange29.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange29.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN15).AddRange(New Object() {InvalidRange29})
        Me.numJIDAI_JOGEN15.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN15.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO15
        '
        Me.numKOYO_KOYO15.AllowDeleteToNull = True
        NumberIntegerPartDisplayField29.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField29.MaxDigits = 5
        NumberDecimalPartDisplayField29.MinDigits = 5
        Me.numKOYO_KOYO15.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField29, NumberIntegerPartDisplayField29, NumberDecimalSeparatorDisplayField29, NumberDecimalPartDisplayField29})
        Me.numKOYO_KOYO15.DropDown.AllowDrop = False
        Me.numKOYO_KOYO15.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO15.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO15.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO15.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO15.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO15.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO15.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO15.HighlightText = True
        Me.numKOYO_KOYO15.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO15.InputCheck = True
        Me.numKOYO_KOYO15.Location = New System.Drawing.Point(316, 320)
        Me.numKOYO_KOYO15.Name = "numKOYO_KOYO15"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO15, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO15, Object), CType(Me.numKOYO_KOYO15, Object), CType(Me.numKOYO_KOYO15, Object), CType(Me.numKOYO_KOYO15, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO15.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO15.Spin.Increment = 0
        Me.numKOYO_KOYO15.TabIndex = 36
        ValueProcess30.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO15).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess30})
        InvalidRange30.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange30.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO15).AddRange(New Object() {InvalidRange30})
        Me.numKOYO_KOYO15.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO15.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN15
        '
        Me.numKOYO_JOGEN15.AllowDeleteToNull = True
        NumberIntegerPartDisplayField30.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField30.MaxDigits = 5
        NumberDecimalPartDisplayField30.MinDigits = 5
        Me.numKOYO_JOGEN15.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField30, NumberIntegerPartDisplayField30, NumberDecimalSeparatorDisplayField30, NumberDecimalPartDisplayField30})
        Me.numKOYO_JOGEN15.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN15.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN15.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN15.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN15.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN15.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN15.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN15.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN15.HighlightText = True
        Me.numKOYO_JOGEN15.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN15.InputCheck = True
        Me.numKOYO_JOGEN15.Location = New System.Drawing.Point(209, 320)
        Me.numKOYO_JOGEN15.Name = "numKOYO_JOGEN15"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN15, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN15, Object), CType(Me.numKOYO_JOGEN15, Object), CType(Me.numKOYO_JOGEN15, Object), CType(Me.numKOYO_JOGEN15, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN15.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN15.Spin.Increment = 0
        Me.numKOYO_JOGEN15.TabIndex = 35
        ValueProcess31.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN15).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess31})
        InvalidRange31.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange31.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN15).AddRange(New Object() {InvalidRange31})
        Me.numKOYO_JOGEN15.Value = New Decimal(New Integer() {999900000, 0, 0, 327680})
        Me.numKOYO_JOGEN15.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU25
        '
        Me.numGENKA_SYOKYAKU25.AllowDeleteToNull = True
        NumberIntegerPartDisplayField31.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField31.MaxDigits = 5
        NumberDecimalPartDisplayField31.MinDigits = 5
        Me.numGENKA_SYOKYAKU25.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField31, NumberIntegerPartDisplayField31, NumberDecimalSeparatorDisplayField31, NumberDecimalPartDisplayField31})
        Me.numGENKA_SYOKYAKU25.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU25.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU25.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU25.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU25.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU25.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU25.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU25.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU25.HighlightText = True
        Me.numGENKA_SYOKYAKU25.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU25.InputCheck = True
        Me.numGENKA_SYOKYAKU25.Location = New System.Drawing.Point(743, 445)
        Me.numGENKA_SYOKYAKU25.Name = "numGENKA_SYOKYAKU25"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU25, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU25, Object), CType(Me.numGENKA_SYOKYAKU25, Object), CType(Me.numGENKA_SYOKYAKU25, Object), CType(Me.numGENKA_SYOKYAKU25, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU25.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU25.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU25.TabIndex = 75
        ValueProcess32.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU25).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess32})
        InvalidRange32.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange32.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU25).AddRange(New Object() {InvalidRange32})
        Me.numGENKA_SYOKYAKU25.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU25.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN25
        '
        Me.numGENKA_JOGEN25.AllowDeleteToNull = True
        NumberIntegerPartDisplayField32.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField32.MaxDigits = 5
        NumberDecimalPartDisplayField32.MinDigits = 5
        Me.numGENKA_JOGEN25.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField32, NumberIntegerPartDisplayField32, NumberDecimalSeparatorDisplayField32, NumberDecimalPartDisplayField32})
        Me.numGENKA_JOGEN25.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN25.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN25.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN25.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN25.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN25.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN25.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN25.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN25.HighlightText = True
        Me.numGENKA_JOGEN25.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN25.InputCheck = True
        Me.numGENKA_JOGEN25.Location = New System.Drawing.Point(637, 445)
        Me.numGENKA_JOGEN25.Name = "numGENKA_JOGEN25"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN25, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN25, Object), CType(Me.numGENKA_JOGEN25, Object), CType(Me.numGENKA_JOGEN25, Object), CType(Me.numGENKA_JOGEN25, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN25.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN25.Spin.Increment = 0
        Me.numGENKA_JOGEN25.TabIndex = 74
        ValueProcess33.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN25).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess33})
        InvalidRange33.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange33.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN25).AddRange(New Object() {InvalidRange33})
        Me.numGENKA_JOGEN25.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN25.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI25
        '
        Me.numJIDAI_JIDAI25.AllowDeleteToNull = True
        NumberIntegerPartDisplayField33.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField33.MaxDigits = 5
        NumberDecimalPartDisplayField33.MinDigits = 5
        Me.numJIDAI_JIDAI25.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField33, NumberIntegerPartDisplayField33, NumberDecimalSeparatorDisplayField33, NumberDecimalPartDisplayField33})
        Me.numJIDAI_JIDAI25.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI25.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI25.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI25.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI25.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI25.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI25.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI25.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI25.HighlightText = True
        Me.numJIDAI_JIDAI25.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI25.InputCheck = True
        Me.numJIDAI_JIDAI25.Location = New System.Drawing.Point(530, 445)
        Me.numJIDAI_JIDAI25.Name = "numJIDAI_JIDAI25"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI25, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI25, Object), CType(Me.numJIDAI_JIDAI25, Object), CType(Me.numJIDAI_JIDAI25, Object), CType(Me.numJIDAI_JIDAI25, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI25.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI25.Spin.Increment = 0
        Me.numJIDAI_JIDAI25.TabIndex = 73
        ValueProcess34.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI25).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess34})
        InvalidRange34.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange34.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI25).AddRange(New Object() {InvalidRange34})
        Me.numJIDAI_JIDAI25.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI25.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN25
        '
        Me.numJIDAI_JOGEN25.AllowDeleteToNull = True
        NumberIntegerPartDisplayField34.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField34.MaxDigits = 5
        NumberDecimalPartDisplayField34.MinDigits = 5
        Me.numJIDAI_JOGEN25.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField34, NumberIntegerPartDisplayField34, NumberDecimalSeparatorDisplayField34, NumberDecimalPartDisplayField34})
        Me.numJIDAI_JOGEN25.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN25.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN25.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN25.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN25.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN25.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN25.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN25.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN25.HighlightText = True
        Me.numJIDAI_JOGEN25.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN25.InputCheck = True
        Me.numJIDAI_JOGEN25.Location = New System.Drawing.Point(423, 445)
        Me.numJIDAI_JOGEN25.Name = "numJIDAI_JOGEN25"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN25, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN25, Object), CType(Me.numJIDAI_JOGEN25, Object), CType(Me.numJIDAI_JOGEN25, Object), CType(Me.numJIDAI_JOGEN25, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN25.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN25.Spin.Increment = 0
        Me.numJIDAI_JOGEN25.TabIndex = 72
        ValueProcess35.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN25).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess35})
        InvalidRange35.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange35.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN25).AddRange(New Object() {InvalidRange35})
        Me.numJIDAI_JOGEN25.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN25.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO25
        '
        Me.numKOYO_KOYO25.AllowDeleteToNull = True
        NumberIntegerPartDisplayField35.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField35.MaxDigits = 5
        NumberDecimalPartDisplayField35.MinDigits = 5
        Me.numKOYO_KOYO25.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField35, NumberIntegerPartDisplayField35, NumberDecimalSeparatorDisplayField35, NumberDecimalPartDisplayField35})
        Me.numKOYO_KOYO25.DropDown.AllowDrop = False
        Me.numKOYO_KOYO25.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO25.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO25.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO25.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO25.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO25.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO25.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO25.HighlightText = True
        Me.numKOYO_KOYO25.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO25.InputCheck = True
        Me.numKOYO_KOYO25.Location = New System.Drawing.Point(316, 445)
        Me.numKOYO_KOYO25.Name = "numKOYO_KOYO25"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO25, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO25, Object), CType(Me.numKOYO_KOYO25, Object), CType(Me.numKOYO_KOYO25, Object), CType(Me.numKOYO_KOYO25, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO25.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO25.Spin.Increment = 0
        Me.numKOYO_KOYO25.TabIndex = 71
        ValueProcess36.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO25).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess36})
        InvalidRange36.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange36.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO25).AddRange(New Object() {InvalidRange36})
        Me.numKOYO_KOYO25.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO25.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN25
        '
        Me.numKOYO_JOGEN25.AllowDeleteToNull = True
        NumberIntegerPartDisplayField36.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField36.MaxDigits = 5
        NumberDecimalPartDisplayField36.MinDigits = 5
        Me.numKOYO_JOGEN25.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField36, NumberIntegerPartDisplayField36, NumberDecimalSeparatorDisplayField36, NumberDecimalPartDisplayField36})
        Me.numKOYO_JOGEN25.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN25.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN25.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN25.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN25.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN25.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN25.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN25.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN25.HighlightText = True
        Me.numKOYO_JOGEN25.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN25.InputCheck = True
        Me.numKOYO_JOGEN25.Location = New System.Drawing.Point(209, 445)
        Me.numKOYO_JOGEN25.Name = "numKOYO_JOGEN25"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN25, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN25, Object), CType(Me.numKOYO_JOGEN25, Object), CType(Me.numKOYO_JOGEN25, Object), CType(Me.numKOYO_JOGEN25, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN25.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN25.Spin.Increment = 0
        Me.numKOYO_JOGEN25.TabIndex = 70
        ValueProcess37.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN25).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess37})
        InvalidRange37.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange37.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN25).AddRange(New Object() {InvalidRange37})
        Me.numKOYO_JOGEN25.Value = New Decimal(New Integer() {999900000, 0, 0, 327680})
        Me.numKOYO_JOGEN25.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU24
        '
        Me.numGENKA_SYOKYAKU24.AllowDeleteToNull = True
        NumberIntegerPartDisplayField37.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField37.MaxDigits = 5
        NumberDecimalPartDisplayField37.MinDigits = 5
        Me.numGENKA_SYOKYAKU24.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField37, NumberIntegerPartDisplayField37, NumberDecimalSeparatorDisplayField37, NumberDecimalPartDisplayField37})
        Me.numGENKA_SYOKYAKU24.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU24.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU24.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU24.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU24.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU24.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU24.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU24.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU24.HighlightText = True
        Me.numGENKA_SYOKYAKU24.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU24.InputCheck = True
        Me.numGENKA_SYOKYAKU24.Location = New System.Drawing.Point(743, 420)
        Me.numGENKA_SYOKYAKU24.Name = "numGENKA_SYOKYAKU24"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU24, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU24, Object), CType(Me.numGENKA_SYOKYAKU24, Object), CType(Me.numGENKA_SYOKYAKU24, Object), CType(Me.numGENKA_SYOKYAKU24, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU24.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU24.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU24.TabIndex = 68
        ValueProcess38.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU24).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess38})
        InvalidRange38.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange38.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU24).AddRange(New Object() {InvalidRange38})
        Me.numGENKA_SYOKYAKU24.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU24.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN24
        '
        Me.numGENKA_JOGEN24.AllowDeleteToNull = True
        NumberIntegerPartDisplayField38.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField38.MaxDigits = 5
        NumberDecimalPartDisplayField38.MinDigits = 5
        Me.numGENKA_JOGEN24.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField38, NumberIntegerPartDisplayField38, NumberDecimalSeparatorDisplayField38, NumberDecimalPartDisplayField38})
        Me.numGENKA_JOGEN24.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN24.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN24.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN24.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN24.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN24.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN24.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN24.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN24.HighlightText = True
        Me.numGENKA_JOGEN24.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN24.InputCheck = True
        Me.numGENKA_JOGEN24.Location = New System.Drawing.Point(637, 420)
        Me.numGENKA_JOGEN24.Name = "numGENKA_JOGEN24"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN24, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN24, Object), CType(Me.numGENKA_JOGEN24, Object), CType(Me.numGENKA_JOGEN24, Object), CType(Me.numGENKA_JOGEN24, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN24.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN24.Spin.Increment = 0
        Me.numGENKA_JOGEN24.TabIndex = 67
        ValueProcess39.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN24).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess39})
        InvalidRange39.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange39.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN24).AddRange(New Object() {InvalidRange39})
        Me.numGENKA_JOGEN24.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN24.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI24
        '
        Me.numJIDAI_JIDAI24.AllowDeleteToNull = True
        NumberIntegerPartDisplayField39.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField39.MaxDigits = 5
        NumberDecimalPartDisplayField39.MinDigits = 5
        Me.numJIDAI_JIDAI24.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField39, NumberIntegerPartDisplayField39, NumberDecimalSeparatorDisplayField39, NumberDecimalPartDisplayField39})
        Me.numJIDAI_JIDAI24.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI24.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI24.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI24.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI24.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI24.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI24.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI24.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI24.HighlightText = True
        Me.numJIDAI_JIDAI24.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI24.InputCheck = True
        Me.numJIDAI_JIDAI24.Location = New System.Drawing.Point(530, 420)
        Me.numJIDAI_JIDAI24.Name = "numJIDAI_JIDAI24"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI24, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI24, Object), CType(Me.numJIDAI_JIDAI24, Object), CType(Me.numJIDAI_JIDAI24, Object), CType(Me.numJIDAI_JIDAI24, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI24.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI24.Spin.Increment = 0
        Me.numJIDAI_JIDAI24.TabIndex = 66
        ValueProcess40.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI24).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess40})
        InvalidRange40.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange40.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI24).AddRange(New Object() {InvalidRange40})
        Me.numJIDAI_JIDAI24.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI24.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN24
        '
        Me.numJIDAI_JOGEN24.AllowDeleteToNull = True
        NumberIntegerPartDisplayField40.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField40.MaxDigits = 5
        NumberDecimalPartDisplayField40.MinDigits = 5
        Me.numJIDAI_JOGEN24.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField40, NumberIntegerPartDisplayField40, NumberDecimalSeparatorDisplayField40, NumberDecimalPartDisplayField40})
        Me.numJIDAI_JOGEN24.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN24.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN24.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN24.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN24.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN24.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN24.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN24.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN24.HighlightText = True
        Me.numJIDAI_JOGEN24.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN24.InputCheck = True
        Me.numJIDAI_JOGEN24.Location = New System.Drawing.Point(423, 420)
        Me.numJIDAI_JOGEN24.Name = "numJIDAI_JOGEN24"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN24, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN24, Object), CType(Me.numJIDAI_JOGEN24, Object), CType(Me.numJIDAI_JOGEN24, Object), CType(Me.numJIDAI_JOGEN24, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN24.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN24.Spin.Increment = 0
        Me.numJIDAI_JOGEN24.TabIndex = 65
        ValueProcess41.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN24).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess41})
        InvalidRange41.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange41.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN24).AddRange(New Object() {InvalidRange41})
        Me.numJIDAI_JOGEN24.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN24.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO24
        '
        Me.numKOYO_KOYO24.AllowDeleteToNull = True
        NumberIntegerPartDisplayField41.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField41.MaxDigits = 5
        NumberDecimalPartDisplayField41.MinDigits = 5
        Me.numKOYO_KOYO24.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField41, NumberIntegerPartDisplayField41, NumberDecimalSeparatorDisplayField41, NumberDecimalPartDisplayField41})
        Me.numKOYO_KOYO24.DropDown.AllowDrop = False
        Me.numKOYO_KOYO24.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO24.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO24.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO24.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO24.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO24.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO24.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO24.HighlightText = True
        Me.numKOYO_KOYO24.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO24.InputCheck = True
        Me.numKOYO_KOYO24.Location = New System.Drawing.Point(316, 420)
        Me.numKOYO_KOYO24.Name = "numKOYO_KOYO24"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO24, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO24, Object), CType(Me.numKOYO_KOYO24, Object), CType(Me.numKOYO_KOYO24, Object), CType(Me.numKOYO_KOYO24, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO24.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO24.Spin.Increment = 0
        Me.numKOYO_KOYO24.TabIndex = 64
        ValueProcess42.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO24).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess42})
        InvalidRange42.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange42.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO24).AddRange(New Object() {InvalidRange42})
        Me.numKOYO_KOYO24.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO24.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN24
        '
        Me.numKOYO_JOGEN24.AllowDeleteToNull = True
        NumberIntegerPartDisplayField42.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField42.MaxDigits = 5
        NumberDecimalPartDisplayField42.MinDigits = 5
        Me.numKOYO_JOGEN24.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField42, NumberIntegerPartDisplayField42, NumberDecimalSeparatorDisplayField42, NumberDecimalPartDisplayField42})
        Me.numKOYO_JOGEN24.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN24.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN24.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN24.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN24.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN24.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN24.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN24.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN24.HighlightText = True
        Me.numKOYO_JOGEN24.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN24.InputCheck = True
        Me.numKOYO_JOGEN24.Location = New System.Drawing.Point(209, 420)
        Me.numKOYO_JOGEN24.Name = "numKOYO_JOGEN24"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN24, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN24, Object), CType(Me.numKOYO_JOGEN24, Object), CType(Me.numKOYO_JOGEN24, Object), CType(Me.numKOYO_JOGEN24, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN24.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN24.Spin.Increment = 0
        Me.numKOYO_JOGEN24.TabIndex = 63
        ValueProcess43.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN24).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess43})
        InvalidRange43.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange43.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN24).AddRange(New Object() {InvalidRange43})
        Me.numKOYO_JOGEN24.Value = New Decimal(New Integer() {999900000, 0, 0, 327680})
        Me.numKOYO_JOGEN24.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU23
        '
        Me.numGENKA_SYOKYAKU23.AllowDeleteToNull = True
        NumberIntegerPartDisplayField43.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField43.MaxDigits = 5
        NumberDecimalPartDisplayField43.MinDigits = 5
        Me.numGENKA_SYOKYAKU23.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField43, NumberIntegerPartDisplayField43, NumberDecimalSeparatorDisplayField43, NumberDecimalPartDisplayField43})
        Me.numGENKA_SYOKYAKU23.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU23.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU23.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU23.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU23.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU23.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU23.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU23.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU23.HighlightText = True
        Me.numGENKA_SYOKYAKU23.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU23.InputCheck = True
        Me.numGENKA_SYOKYAKU23.Location = New System.Drawing.Point(743, 395)
        Me.numGENKA_SYOKYAKU23.Name = "numGENKA_SYOKYAKU23"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU23, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU23, Object), CType(Me.numGENKA_SYOKYAKU23, Object), CType(Me.numGENKA_SYOKYAKU23, Object), CType(Me.numGENKA_SYOKYAKU23, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU23.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU23.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU23.TabIndex = 61
        ValueProcess44.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU23).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess44})
        InvalidRange44.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange44.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU23).AddRange(New Object() {InvalidRange44})
        Me.numGENKA_SYOKYAKU23.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU23.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN23
        '
        Me.numGENKA_JOGEN23.AllowDeleteToNull = True
        NumberIntegerPartDisplayField44.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField44.MaxDigits = 5
        NumberDecimalPartDisplayField44.MinDigits = 5
        Me.numGENKA_JOGEN23.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField44, NumberIntegerPartDisplayField44, NumberDecimalSeparatorDisplayField44, NumberDecimalPartDisplayField44})
        Me.numGENKA_JOGEN23.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN23.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN23.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN23.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN23.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN23.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN23.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN23.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN23.HighlightText = True
        Me.numGENKA_JOGEN23.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN23.InputCheck = True
        Me.numGENKA_JOGEN23.Location = New System.Drawing.Point(637, 395)
        Me.numGENKA_JOGEN23.Name = "numGENKA_JOGEN23"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN23, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN23, Object), CType(Me.numGENKA_JOGEN23, Object), CType(Me.numGENKA_JOGEN23, Object), CType(Me.numGENKA_JOGEN23, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN23.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN23.Spin.Increment = 0
        Me.numGENKA_JOGEN23.TabIndex = 60
        ValueProcess45.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN23).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess45})
        InvalidRange45.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange45.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN23).AddRange(New Object() {InvalidRange45})
        Me.numGENKA_JOGEN23.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN23.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI23
        '
        Me.numJIDAI_JIDAI23.AllowDeleteToNull = True
        NumberIntegerPartDisplayField45.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField45.MaxDigits = 5
        NumberDecimalPartDisplayField45.MinDigits = 5
        Me.numJIDAI_JIDAI23.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField45, NumberIntegerPartDisplayField45, NumberDecimalSeparatorDisplayField45, NumberDecimalPartDisplayField45})
        Me.numJIDAI_JIDAI23.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI23.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI23.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI23.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI23.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI23.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI23.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI23.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI23.HighlightText = True
        Me.numJIDAI_JIDAI23.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI23.InputCheck = True
        Me.numJIDAI_JIDAI23.Location = New System.Drawing.Point(530, 395)
        Me.numJIDAI_JIDAI23.Name = "numJIDAI_JIDAI23"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI23, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI23, Object), CType(Me.numJIDAI_JIDAI23, Object), CType(Me.numJIDAI_JIDAI23, Object), CType(Me.numJIDAI_JIDAI23, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI23.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI23.Spin.Increment = 0
        Me.numJIDAI_JIDAI23.TabIndex = 59
        ValueProcess46.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI23).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess46})
        InvalidRange46.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange46.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI23).AddRange(New Object() {InvalidRange46})
        Me.numJIDAI_JIDAI23.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI23.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN23
        '
        Me.numJIDAI_JOGEN23.AllowDeleteToNull = True
        NumberIntegerPartDisplayField46.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField46.MaxDigits = 5
        NumberDecimalPartDisplayField46.MinDigits = 5
        Me.numJIDAI_JOGEN23.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField46, NumberIntegerPartDisplayField46, NumberDecimalSeparatorDisplayField46, NumberDecimalPartDisplayField46})
        Me.numJIDAI_JOGEN23.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN23.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN23.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN23.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN23.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN23.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN23.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN23.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN23.HighlightText = True
        Me.numJIDAI_JOGEN23.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN23.InputCheck = True
        Me.numJIDAI_JOGEN23.Location = New System.Drawing.Point(423, 395)
        Me.numJIDAI_JOGEN23.Name = "numJIDAI_JOGEN23"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN23, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN23, Object), CType(Me.numJIDAI_JOGEN23, Object), CType(Me.numJIDAI_JOGEN23, Object), CType(Me.numJIDAI_JOGEN23, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN23.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN23.Spin.Increment = 0
        Me.numJIDAI_JOGEN23.TabIndex = 58
        ValueProcess47.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN23).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess47})
        InvalidRange47.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange47.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN23).AddRange(New Object() {InvalidRange47})
        Me.numJIDAI_JOGEN23.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN23.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO23
        '
        Me.numKOYO_KOYO23.AllowDeleteToNull = True
        NumberIntegerPartDisplayField47.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField47.MaxDigits = 5
        NumberDecimalPartDisplayField47.MinDigits = 5
        Me.numKOYO_KOYO23.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField47, NumberIntegerPartDisplayField47, NumberDecimalSeparatorDisplayField47, NumberDecimalPartDisplayField47})
        Me.numKOYO_KOYO23.DropDown.AllowDrop = False
        Me.numKOYO_KOYO23.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO23.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO23.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO23.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO23.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO23.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO23.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO23.HighlightText = True
        Me.numKOYO_KOYO23.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO23.InputCheck = True
        Me.numKOYO_KOYO23.Location = New System.Drawing.Point(316, 395)
        Me.numKOYO_KOYO23.Name = "numKOYO_KOYO23"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO23, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO23, Object), CType(Me.numKOYO_KOYO23, Object), CType(Me.numKOYO_KOYO23, Object), CType(Me.numKOYO_KOYO23, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO23.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO23.Spin.Increment = 0
        Me.numKOYO_KOYO23.TabIndex = 57
        ValueProcess48.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO23).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess48})
        InvalidRange48.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange48.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO23).AddRange(New Object() {InvalidRange48})
        Me.numKOYO_KOYO23.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO23.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN23
        '
        Me.numKOYO_JOGEN23.AllowDeleteToNull = True
        NumberIntegerPartDisplayField48.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField48.MaxDigits = 5
        NumberDecimalPartDisplayField48.MinDigits = 5
        Me.numKOYO_JOGEN23.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField48, NumberIntegerPartDisplayField48, NumberDecimalSeparatorDisplayField48, NumberDecimalPartDisplayField48})
        Me.numKOYO_JOGEN23.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN23.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN23.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN23.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN23.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN23.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN23.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN23.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN23.HighlightText = True
        Me.numKOYO_JOGEN23.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN23.InputCheck = True
        Me.numKOYO_JOGEN23.Location = New System.Drawing.Point(209, 395)
        Me.numKOYO_JOGEN23.Name = "numKOYO_JOGEN23"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN23, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN23, Object), CType(Me.numKOYO_JOGEN23, Object), CType(Me.numKOYO_JOGEN23, Object), CType(Me.numKOYO_JOGEN23, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN23.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN23.Spin.Increment = 0
        Me.numKOYO_JOGEN23.TabIndex = 56
        ValueProcess49.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN23).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess49})
        InvalidRange49.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange49.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN23).AddRange(New Object() {InvalidRange49})
        Me.numKOYO_JOGEN23.Value = New Decimal(New Integer() {999900000, 0, 0, 327680})
        Me.numKOYO_JOGEN23.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU22
        '
        Me.numGENKA_SYOKYAKU22.AllowDeleteToNull = True
        NumberIntegerPartDisplayField49.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField49.MaxDigits = 5
        NumberDecimalPartDisplayField49.MinDigits = 5
        Me.numGENKA_SYOKYAKU22.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField49, NumberIntegerPartDisplayField49, NumberDecimalSeparatorDisplayField49, NumberDecimalPartDisplayField49})
        Me.numGENKA_SYOKYAKU22.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU22.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU22.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU22.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU22.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU22.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU22.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU22.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU22.HighlightText = True
        Me.numGENKA_SYOKYAKU22.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU22.InputCheck = True
        Me.numGENKA_SYOKYAKU22.Location = New System.Drawing.Point(743, 370)
        Me.numGENKA_SYOKYAKU22.Name = "numGENKA_SYOKYAKU22"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU22, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU22, Object), CType(Me.numGENKA_SYOKYAKU22, Object), CType(Me.numGENKA_SYOKYAKU22, Object), CType(Me.numGENKA_SYOKYAKU22, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU22.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU22.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU22.TabIndex = 54
        ValueProcess50.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU22).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess50})
        InvalidRange50.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange50.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU22).AddRange(New Object() {InvalidRange50})
        Me.numGENKA_SYOKYAKU22.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU22.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN22
        '
        Me.numGENKA_JOGEN22.AllowDeleteToNull = True
        NumberIntegerPartDisplayField50.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField50.MaxDigits = 5
        NumberDecimalPartDisplayField50.MinDigits = 5
        Me.numGENKA_JOGEN22.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField50, NumberIntegerPartDisplayField50, NumberDecimalSeparatorDisplayField50, NumberDecimalPartDisplayField50})
        Me.numGENKA_JOGEN22.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN22.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN22.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN22.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN22.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN22.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN22.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN22.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN22.HighlightText = True
        Me.numGENKA_JOGEN22.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN22.InputCheck = True
        Me.numGENKA_JOGEN22.Location = New System.Drawing.Point(637, 370)
        Me.numGENKA_JOGEN22.Name = "numGENKA_JOGEN22"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN22, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN22, Object), CType(Me.numGENKA_JOGEN22, Object), CType(Me.numGENKA_JOGEN22, Object), CType(Me.numGENKA_JOGEN22, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN22.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN22.Spin.Increment = 0
        Me.numGENKA_JOGEN22.TabIndex = 53
        ValueProcess51.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN22).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess51})
        InvalidRange51.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange51.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN22).AddRange(New Object() {InvalidRange51})
        Me.numGENKA_JOGEN22.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN22.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI22
        '
        Me.numJIDAI_JIDAI22.AllowDeleteToNull = True
        NumberIntegerPartDisplayField51.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField51.MaxDigits = 5
        NumberDecimalPartDisplayField51.MinDigits = 5
        Me.numJIDAI_JIDAI22.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField51, NumberIntegerPartDisplayField51, NumberDecimalSeparatorDisplayField51, NumberDecimalPartDisplayField51})
        Me.numJIDAI_JIDAI22.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI22.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI22.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI22.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI22.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI22.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI22.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI22.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI22.HighlightText = True
        Me.numJIDAI_JIDAI22.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI22.InputCheck = True
        Me.numJIDAI_JIDAI22.Location = New System.Drawing.Point(530, 370)
        Me.numJIDAI_JIDAI22.Name = "numJIDAI_JIDAI22"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI22, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI22, Object), CType(Me.numJIDAI_JIDAI22, Object), CType(Me.numJIDAI_JIDAI22, Object), CType(Me.numJIDAI_JIDAI22, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI22.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI22.Spin.Increment = 0
        Me.numJIDAI_JIDAI22.TabIndex = 52
        ValueProcess52.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI22).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess52})
        InvalidRange52.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange52.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI22).AddRange(New Object() {InvalidRange52})
        Me.numJIDAI_JIDAI22.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI22.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN22
        '
        Me.numJIDAI_JOGEN22.AllowDeleteToNull = True
        NumberIntegerPartDisplayField52.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField52.MaxDigits = 5
        NumberDecimalPartDisplayField52.MinDigits = 5
        Me.numJIDAI_JOGEN22.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField52, NumberIntegerPartDisplayField52, NumberDecimalSeparatorDisplayField52, NumberDecimalPartDisplayField52})
        Me.numJIDAI_JOGEN22.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN22.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN22.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN22.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN22.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN22.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN22.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN22.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN22.HighlightText = True
        Me.numJIDAI_JOGEN22.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN22.InputCheck = True
        Me.numJIDAI_JOGEN22.Location = New System.Drawing.Point(423, 370)
        Me.numJIDAI_JOGEN22.Name = "numJIDAI_JOGEN22"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN22, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN22, Object), CType(Me.numJIDAI_JOGEN22, Object), CType(Me.numJIDAI_JOGEN22, Object), CType(Me.numJIDAI_JOGEN22, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN22.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN22.Spin.Increment = 0
        Me.numJIDAI_JOGEN22.TabIndex = 51
        ValueProcess53.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN22).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess53})
        InvalidRange53.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange53.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN22).AddRange(New Object() {InvalidRange53})
        Me.numJIDAI_JOGEN22.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN22.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO22
        '
        Me.numKOYO_KOYO22.AllowDeleteToNull = True
        NumberIntegerPartDisplayField53.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField53.MaxDigits = 5
        NumberDecimalPartDisplayField53.MinDigits = 5
        Me.numKOYO_KOYO22.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField53, NumberIntegerPartDisplayField53, NumberDecimalSeparatorDisplayField53, NumberDecimalPartDisplayField53})
        Me.numKOYO_KOYO22.DropDown.AllowDrop = False
        Me.numKOYO_KOYO22.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO22.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO22.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO22.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO22.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO22.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO22.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO22.HighlightText = True
        Me.numKOYO_KOYO22.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO22.InputCheck = True
        Me.numKOYO_KOYO22.Location = New System.Drawing.Point(316, 370)
        Me.numKOYO_KOYO22.Name = "numKOYO_KOYO22"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO22, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO22, Object), CType(Me.numKOYO_KOYO22, Object), CType(Me.numKOYO_KOYO22, Object), CType(Me.numKOYO_KOYO22, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO22.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO22.Spin.Increment = 0
        Me.numKOYO_KOYO22.TabIndex = 50
        ValueProcess54.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO22).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess54})
        InvalidRange54.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange54.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO22).AddRange(New Object() {InvalidRange54})
        Me.numKOYO_KOYO22.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO22.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN22
        '
        Me.numKOYO_JOGEN22.AllowDeleteToNull = True
        NumberIntegerPartDisplayField54.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField54.MaxDigits = 5
        NumberDecimalPartDisplayField54.MinDigits = 5
        Me.numKOYO_JOGEN22.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField54, NumberIntegerPartDisplayField54, NumberDecimalSeparatorDisplayField54, NumberDecimalPartDisplayField54})
        Me.numKOYO_JOGEN22.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN22.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN22.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN22.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN22.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN22.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN22.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN22.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN22.HighlightText = True
        Me.numKOYO_JOGEN22.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN22.InputCheck = True
        Me.numKOYO_JOGEN22.Location = New System.Drawing.Point(209, 370)
        Me.numKOYO_JOGEN22.Name = "numKOYO_JOGEN22"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN22, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN22, Object), CType(Me.numKOYO_JOGEN22, Object), CType(Me.numKOYO_JOGEN22, Object), CType(Me.numKOYO_JOGEN22, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN22.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN22.Spin.Increment = 0
        Me.numKOYO_JOGEN22.TabIndex = 49
        ValueProcess55.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN22).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess55})
        InvalidRange55.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange55.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN22).AddRange(New Object() {InvalidRange55})
        Me.numKOYO_JOGEN22.Value = New Decimal(New Integer() {999900000, 0, 0, 327680})
        Me.numKOYO_JOGEN22.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU21
        '
        Me.numGENKA_SYOKYAKU21.AllowDeleteToNull = True
        NumberIntegerPartDisplayField55.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField55.MaxDigits = 5
        NumberDecimalPartDisplayField55.MinDigits = 5
        Me.numGENKA_SYOKYAKU21.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField55, NumberIntegerPartDisplayField55, NumberDecimalSeparatorDisplayField55, NumberDecimalPartDisplayField55})
        Me.numGENKA_SYOKYAKU21.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU21.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU21.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU21.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU21.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU21.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU21.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU21.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU21.HighlightText = True
        Me.numGENKA_SYOKYAKU21.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU21.InputCheck = True
        Me.numGENKA_SYOKYAKU21.Location = New System.Drawing.Point(743, 345)
        Me.numGENKA_SYOKYAKU21.Name = "numGENKA_SYOKYAKU21"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU21, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU21, Object), CType(Me.numGENKA_SYOKYAKU21, Object), CType(Me.numGENKA_SYOKYAKU21, Object), CType(Me.numGENKA_SYOKYAKU21, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU21.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU21.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU21.TabIndex = 47
        ValueProcess56.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU21).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess56})
        InvalidRange56.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange56.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU21).AddRange(New Object() {InvalidRange56})
        Me.numGENKA_SYOKYAKU21.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU21.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN21
        '
        Me.numGENKA_JOGEN21.AllowDeleteToNull = True
        NumberIntegerPartDisplayField56.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField56.MaxDigits = 5
        NumberDecimalPartDisplayField56.MinDigits = 5
        Me.numGENKA_JOGEN21.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField56, NumberIntegerPartDisplayField56, NumberDecimalSeparatorDisplayField56, NumberDecimalPartDisplayField56})
        Me.numGENKA_JOGEN21.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN21.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN21.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN21.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN21.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN21.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN21.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN21.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN21.HighlightText = True
        Me.numGENKA_JOGEN21.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN21.InputCheck = True
        Me.numGENKA_JOGEN21.Location = New System.Drawing.Point(637, 345)
        Me.numGENKA_JOGEN21.Name = "numGENKA_JOGEN21"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN21, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN21, Object), CType(Me.numGENKA_JOGEN21, Object), CType(Me.numGENKA_JOGEN21, Object), CType(Me.numGENKA_JOGEN21, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN21.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN21.Spin.Increment = 0
        Me.numGENKA_JOGEN21.TabIndex = 46
        ValueProcess57.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN21).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess57})
        InvalidRange57.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange57.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN21).AddRange(New Object() {InvalidRange57})
        Me.numGENKA_JOGEN21.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN21.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI21
        '
        Me.numJIDAI_JIDAI21.AllowDeleteToNull = True
        NumberIntegerPartDisplayField57.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField57.MaxDigits = 5
        NumberDecimalPartDisplayField57.MinDigits = 5
        Me.numJIDAI_JIDAI21.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField57, NumberIntegerPartDisplayField57, NumberDecimalSeparatorDisplayField57, NumberDecimalPartDisplayField57})
        Me.numJIDAI_JIDAI21.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI21.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI21.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI21.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI21.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI21.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI21.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI21.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI21.HighlightText = True
        Me.numJIDAI_JIDAI21.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI21.InputCheck = True
        Me.numJIDAI_JIDAI21.Location = New System.Drawing.Point(530, 345)
        Me.numJIDAI_JIDAI21.Name = "numJIDAI_JIDAI21"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI21, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI21, Object), CType(Me.numJIDAI_JIDAI21, Object), CType(Me.numJIDAI_JIDAI21, Object), CType(Me.numJIDAI_JIDAI21, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI21.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI21.Spin.Increment = 0
        Me.numJIDAI_JIDAI21.TabIndex = 45
        ValueProcess58.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI21).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess58})
        InvalidRange58.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange58.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI21).AddRange(New Object() {InvalidRange58})
        Me.numJIDAI_JIDAI21.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI21.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN21
        '
        Me.numJIDAI_JOGEN21.AllowDeleteToNull = True
        NumberIntegerPartDisplayField58.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField58.MaxDigits = 5
        NumberDecimalPartDisplayField58.MinDigits = 5
        Me.numJIDAI_JOGEN21.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField58, NumberIntegerPartDisplayField58, NumberDecimalSeparatorDisplayField58, NumberDecimalPartDisplayField58})
        Me.numJIDAI_JOGEN21.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN21.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN21.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN21.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN21.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN21.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN21.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN21.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN21.HighlightText = True
        Me.numJIDAI_JOGEN21.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN21.InputCheck = True
        Me.numJIDAI_JOGEN21.Location = New System.Drawing.Point(423, 345)
        Me.numJIDAI_JOGEN21.Name = "numJIDAI_JOGEN21"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN21, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN21, Object), CType(Me.numJIDAI_JOGEN21, Object), CType(Me.numJIDAI_JOGEN21, Object), CType(Me.numJIDAI_JOGEN21, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN21.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN21.Spin.Increment = 0
        Me.numJIDAI_JOGEN21.TabIndex = 44
        ValueProcess59.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN21).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess59})
        InvalidRange59.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange59.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN21).AddRange(New Object() {InvalidRange59})
        Me.numJIDAI_JOGEN21.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN21.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO21
        '
        Me.numKOYO_KOYO21.AllowDeleteToNull = True
        NumberIntegerPartDisplayField59.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField59.MaxDigits = 5
        NumberDecimalPartDisplayField59.MinDigits = 5
        Me.numKOYO_KOYO21.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField59, NumberIntegerPartDisplayField59, NumberDecimalSeparatorDisplayField59, NumberDecimalPartDisplayField59})
        Me.numKOYO_KOYO21.DropDown.AllowDrop = False
        Me.numKOYO_KOYO21.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO21.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO21.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO21.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO21.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO21.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO21.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO21.HighlightText = True
        Me.numKOYO_KOYO21.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO21.InputCheck = True
        Me.numKOYO_KOYO21.Location = New System.Drawing.Point(316, 345)
        Me.numKOYO_KOYO21.Name = "numKOYO_KOYO21"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO21, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO21, Object), CType(Me.numKOYO_KOYO21, Object), CType(Me.numKOYO_KOYO21, Object), CType(Me.numKOYO_KOYO21, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO21.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO21.Spin.Increment = 0
        Me.numKOYO_KOYO21.TabIndex = 43
        ValueProcess60.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO21).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess60})
        InvalidRange60.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange60.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO21).AddRange(New Object() {InvalidRange60})
        Me.numKOYO_KOYO21.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO21.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN21
        '
        Me.numKOYO_JOGEN21.AllowDeleteToNull = True
        NumberIntegerPartDisplayField60.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField60.MaxDigits = 5
        NumberDecimalPartDisplayField60.MinDigits = 5
        Me.numKOYO_JOGEN21.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField60, NumberIntegerPartDisplayField60, NumberDecimalSeparatorDisplayField60, NumberDecimalPartDisplayField60})
        Me.numKOYO_JOGEN21.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN21.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN21.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN21.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN21.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN21.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN21.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN21.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN21.HighlightText = True
        Me.numKOYO_JOGEN21.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN21.InputCheck = True
        Me.numKOYO_JOGEN21.Location = New System.Drawing.Point(209, 345)
        Me.numKOYO_JOGEN21.Name = "numKOYO_JOGEN21"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN21, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN21, Object), CType(Me.numKOYO_JOGEN21, Object), CType(Me.numKOYO_JOGEN21, Object), CType(Me.numKOYO_JOGEN21, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN21.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN21.Spin.Increment = 0
        Me.numKOYO_JOGEN21.TabIndex = 42
        ValueProcess61.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN21).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess61})
        InvalidRange61.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange61.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN21).AddRange(New Object() {InvalidRange61})
        Me.numKOYO_JOGEN21.Value = New Decimal(New Integer() {999900000, 0, 0, 327680})
        Me.numKOYO_JOGEN21.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU36
        '
        Me.numGENKA_SYOKYAKU36.AllowDeleteToNull = True
        NumberIntegerPartDisplayField61.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField61.MaxDigits = 5
        NumberDecimalPartDisplayField61.MinDigits = 5
        Me.numGENKA_SYOKYAKU36.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField61, NumberIntegerPartDisplayField61, NumberDecimalSeparatorDisplayField61, NumberDecimalPartDisplayField61})
        Me.numGENKA_SYOKYAKU36.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU36.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU36.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU36.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU36.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU36.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU36.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU36.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU36.HighlightText = True
        Me.numGENKA_SYOKYAKU36.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU36.InputCheck = True
        Me.numGENKA_SYOKYAKU36.Location = New System.Drawing.Point(743, 470)
        Me.numGENKA_SYOKYAKU36.Name = "numGENKA_SYOKYAKU36"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU36, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU36, Object), CType(Me.numGENKA_SYOKYAKU36, Object), CType(Me.numGENKA_SYOKYAKU36, Object), CType(Me.numGENKA_SYOKYAKU36, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU36.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU36.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU36.TabIndex = 82
        ValueProcess62.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU36).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess62})
        InvalidRange62.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange62.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU36).AddRange(New Object() {InvalidRange62})
        Me.numGENKA_SYOKYAKU36.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU36.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN36
        '
        Me.numGENKA_JOGEN36.AllowDeleteToNull = True
        NumberIntegerPartDisplayField62.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField62.MaxDigits = 5
        NumberDecimalPartDisplayField62.MinDigits = 5
        Me.numGENKA_JOGEN36.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField62, NumberIntegerPartDisplayField62, NumberDecimalSeparatorDisplayField62, NumberDecimalPartDisplayField62})
        Me.numGENKA_JOGEN36.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN36.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN36.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN36.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN36.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN36.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN36.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN36.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN36.HighlightText = True
        Me.numGENKA_JOGEN36.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN36.InputCheck = True
        Me.numGENKA_JOGEN36.Location = New System.Drawing.Point(637, 470)
        Me.numGENKA_JOGEN36.Name = "numGENKA_JOGEN36"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN36, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN36, Object), CType(Me.numGENKA_JOGEN36, Object), CType(Me.numGENKA_JOGEN36, Object), CType(Me.numGENKA_JOGEN36, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN36.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN36.Spin.Increment = 0
        Me.numGENKA_JOGEN36.TabIndex = 81
        ValueProcess63.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN36).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess63})
        InvalidRange63.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange63.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN36).AddRange(New Object() {InvalidRange63})
        Me.numGENKA_JOGEN36.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN36.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI36
        '
        Me.numJIDAI_JIDAI36.AllowDeleteToNull = True
        NumberIntegerPartDisplayField63.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField63.MaxDigits = 5
        NumberDecimalPartDisplayField63.MinDigits = 5
        Me.numJIDAI_JIDAI36.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField63, NumberIntegerPartDisplayField63, NumberDecimalSeparatorDisplayField63, NumberDecimalPartDisplayField63})
        Me.numJIDAI_JIDAI36.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI36.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI36.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI36.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI36.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI36.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI36.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI36.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI36.HighlightText = True
        Me.numJIDAI_JIDAI36.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI36.InputCheck = True
        Me.numJIDAI_JIDAI36.Location = New System.Drawing.Point(530, 470)
        Me.numJIDAI_JIDAI36.Name = "numJIDAI_JIDAI36"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI36, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI36, Object), CType(Me.numJIDAI_JIDAI36, Object), CType(Me.numJIDAI_JIDAI36, Object), CType(Me.numJIDAI_JIDAI36, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI36.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI36.Spin.Increment = 0
        Me.numJIDAI_JIDAI36.TabIndex = 80
        ValueProcess64.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI36).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess64})
        InvalidRange64.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange64.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI36).AddRange(New Object() {InvalidRange64})
        Me.numJIDAI_JIDAI36.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI36.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN36
        '
        Me.numJIDAI_JOGEN36.AllowDeleteToNull = True
        NumberIntegerPartDisplayField64.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField64.MaxDigits = 5
        NumberDecimalPartDisplayField64.MinDigits = 5
        Me.numJIDAI_JOGEN36.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField64, NumberIntegerPartDisplayField64, NumberDecimalSeparatorDisplayField64, NumberDecimalPartDisplayField64})
        Me.numJIDAI_JOGEN36.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN36.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN36.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN36.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN36.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN36.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN36.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN36.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN36.HighlightText = True
        Me.numJIDAI_JOGEN36.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN36.InputCheck = True
        Me.numJIDAI_JOGEN36.Location = New System.Drawing.Point(423, 470)
        Me.numJIDAI_JOGEN36.Name = "numJIDAI_JOGEN36"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN36, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN36, Object), CType(Me.numJIDAI_JOGEN36, Object), CType(Me.numJIDAI_JOGEN36, Object), CType(Me.numJIDAI_JOGEN36, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN36.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN36.Spin.Increment = 0
        Me.numJIDAI_JOGEN36.TabIndex = 79
        ValueProcess65.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN36).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess65})
        InvalidRange65.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange65.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN36).AddRange(New Object() {InvalidRange65})
        Me.numJIDAI_JOGEN36.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN36.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO36
        '
        Me.numKOYO_KOYO36.AllowDeleteToNull = True
        NumberIntegerPartDisplayField65.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField65.MaxDigits = 5
        NumberDecimalPartDisplayField65.MinDigits = 5
        Me.numKOYO_KOYO36.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField65, NumberIntegerPartDisplayField65, NumberDecimalSeparatorDisplayField65, NumberDecimalPartDisplayField65})
        Me.numKOYO_KOYO36.DropDown.AllowDrop = False
        Me.numKOYO_KOYO36.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO36.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO36.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO36.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO36.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO36.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO36.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO36.HighlightText = True
        Me.numKOYO_KOYO36.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO36.InputCheck = True
        Me.numKOYO_KOYO36.Location = New System.Drawing.Point(316, 470)
        Me.numKOYO_KOYO36.Name = "numKOYO_KOYO36"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO36, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO36, Object), CType(Me.numKOYO_KOYO36, Object), CType(Me.numKOYO_KOYO36, Object), CType(Me.numKOYO_KOYO36, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO36.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO36.Spin.Increment = 0
        Me.numKOYO_KOYO36.TabIndex = 78
        ValueProcess66.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO36).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess66})
        InvalidRange66.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange66.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO36).AddRange(New Object() {InvalidRange66})
        Me.numKOYO_KOYO36.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO36.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN36
        '
        Me.numKOYO_JOGEN36.AllowDeleteToNull = True
        NumberIntegerPartDisplayField66.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField66.MaxDigits = 5
        NumberDecimalPartDisplayField66.MinDigits = 5
        Me.numKOYO_JOGEN36.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField66, NumberIntegerPartDisplayField66, NumberDecimalSeparatorDisplayField66, NumberDecimalPartDisplayField66})
        Me.numKOYO_JOGEN36.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN36.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN36.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN36.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN36.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN36.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN36.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN36.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN36.HighlightText = True
        Me.numKOYO_JOGEN36.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN36.InputCheck = True
        Me.numKOYO_JOGEN36.Location = New System.Drawing.Point(209, 470)
        Me.numKOYO_JOGEN36.Name = "numKOYO_JOGEN36"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN36, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN36, Object), CType(Me.numKOYO_JOGEN36, Object), CType(Me.numKOYO_JOGEN36, Object), CType(Me.numKOYO_JOGEN36, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN36.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN36.Spin.Increment = 0
        Me.numKOYO_JOGEN36.TabIndex = 77
        ValueProcess67.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN36).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess67})
        InvalidRange67.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange67.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN36).AddRange(New Object() {InvalidRange67})
        Me.numKOYO_JOGEN36.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_JOGEN36.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA36
        '
        Me.numKUSYA36.AllowDeleteToNull = True
        NumberIntegerPartDisplayField67.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField67.MaxDigits = 5
        NumberDecimalPartDisplayField67.MinDigits = 5
        Me.numKUSYA36.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField67, NumberIntegerPartDisplayField67, NumberDecimalSeparatorDisplayField67, NumberDecimalPartDisplayField67})
        Me.numKUSYA36.DropDown.AllowDrop = False
        Me.numKUSYA36.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA36.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA36.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA36.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA36.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA36.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA36.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA36.HighlightText = True
        Me.numKUSYA36.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA36.InputCheck = True
        Me.numKUSYA36.Location = New System.Drawing.Point(852, 470)
        Me.numKUSYA36.Name = "numKUSYA36"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA36, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA36, Object), CType(Me.numKUSYA36, Object), CType(Me.numKUSYA36, Object), CType(Me.numKUSYA36, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA36.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA36.Spin.Increment = 0
        Me.numKUSYA36.TabIndex = 83
        ValueProcess68.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA36).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess68})
        InvalidRange68.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange68.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA36).AddRange(New Object() {InvalidRange68})
        Me.numKUSYA36.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA36.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA25
        '
        Me.numKUSYA25.AllowDeleteToNull = True
        NumberIntegerPartDisplayField68.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField68.MaxDigits = 5
        NumberDecimalPartDisplayField68.MinDigits = 5
        Me.numKUSYA25.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField68, NumberIntegerPartDisplayField68, NumberDecimalSeparatorDisplayField68, NumberDecimalPartDisplayField68})
        Me.numKUSYA25.DropDown.AllowDrop = False
        Me.numKUSYA25.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA25.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA25.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA25.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA25.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA25.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA25.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA25.HighlightText = True
        Me.numKUSYA25.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA25.InputCheck = True
        Me.numKUSYA25.Location = New System.Drawing.Point(852, 445)
        Me.numKUSYA25.Name = "numKUSYA25"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA25, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA25, Object), CType(Me.numKUSYA25, Object), CType(Me.numKUSYA25, Object), CType(Me.numKUSYA25, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA25.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA25.Spin.Increment = 0
        Me.numKUSYA25.TabIndex = 76
        ValueProcess69.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA25).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess69})
        InvalidRange69.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange69.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA25).AddRange(New Object() {InvalidRange69})
        Me.numKUSYA25.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA25.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA24
        '
        Me.numKUSYA24.AllowDeleteToNull = True
        NumberIntegerPartDisplayField69.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField69.MaxDigits = 5
        NumberDecimalPartDisplayField69.MinDigits = 5
        Me.numKUSYA24.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField69, NumberIntegerPartDisplayField69, NumberDecimalSeparatorDisplayField69, NumberDecimalPartDisplayField69})
        Me.numKUSYA24.DropDown.AllowDrop = False
        Me.numKUSYA24.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA24.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA24.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA24.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA24.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA24.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA24.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA24.HighlightText = True
        Me.numKUSYA24.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA24.InputCheck = True
        Me.numKUSYA24.Location = New System.Drawing.Point(852, 420)
        Me.numKUSYA24.Name = "numKUSYA24"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA24, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA24, Object), CType(Me.numKUSYA24, Object), CType(Me.numKUSYA24, Object), CType(Me.numKUSYA24, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA24.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA24.Spin.Increment = 0
        Me.numKUSYA24.TabIndex = 69
        ValueProcess70.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA24).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess70})
        InvalidRange70.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange70.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA24).AddRange(New Object() {InvalidRange70})
        Me.numKUSYA24.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA24.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA23
        '
        Me.numKUSYA23.AllowDeleteToNull = True
        NumberIntegerPartDisplayField70.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField70.MaxDigits = 5
        NumberDecimalPartDisplayField70.MinDigits = 5
        Me.numKUSYA23.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField70, NumberIntegerPartDisplayField70, NumberDecimalSeparatorDisplayField70, NumberDecimalPartDisplayField70})
        Me.numKUSYA23.DropDown.AllowDrop = False
        Me.numKUSYA23.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA23.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA23.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA23.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA23.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA23.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA23.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA23.HighlightText = True
        Me.numKUSYA23.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA23.InputCheck = True
        Me.numKUSYA23.Location = New System.Drawing.Point(852, 395)
        Me.numKUSYA23.Name = "numKUSYA23"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA23, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA23, Object), CType(Me.numKUSYA23, Object), CType(Me.numKUSYA23, Object), CType(Me.numKUSYA23, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA23.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA23.Spin.Increment = 0
        Me.numKUSYA23.TabIndex = 62
        ValueProcess71.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA23).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess71})
        InvalidRange71.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange71.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA23).AddRange(New Object() {InvalidRange71})
        Me.numKUSYA23.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA23.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA22
        '
        Me.numKUSYA22.AllowDeleteToNull = True
        NumberIntegerPartDisplayField71.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField71.MaxDigits = 5
        NumberDecimalPartDisplayField71.MinDigits = 5
        Me.numKUSYA22.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField71, NumberIntegerPartDisplayField71, NumberDecimalSeparatorDisplayField71, NumberDecimalPartDisplayField71})
        Me.numKUSYA22.DropDown.AllowDrop = False
        Me.numKUSYA22.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA22.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA22.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA22.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA22.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA22.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA22.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA22.HighlightText = True
        Me.numKUSYA22.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA22.InputCheck = True
        Me.numKUSYA22.Location = New System.Drawing.Point(852, 370)
        Me.numKUSYA22.Name = "numKUSYA22"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA22, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA22, Object), CType(Me.numKUSYA22, Object), CType(Me.numKUSYA22, Object), CType(Me.numKUSYA22, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA22.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA22.Spin.Increment = 0
        Me.numKUSYA22.TabIndex = 55
        ValueProcess72.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA22).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess72})
        InvalidRange72.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange72.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA22).AddRange(New Object() {InvalidRange72})
        Me.numKUSYA22.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA22.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA21
        '
        Me.numKUSYA21.AllowDeleteToNull = True
        NumberIntegerPartDisplayField72.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField72.MaxDigits = 5
        NumberDecimalPartDisplayField72.MinDigits = 5
        Me.numKUSYA21.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField72, NumberIntegerPartDisplayField72, NumberDecimalSeparatorDisplayField72, NumberDecimalPartDisplayField72})
        Me.numKUSYA21.DropDown.AllowDrop = False
        Me.numKUSYA21.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA21.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA21.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA21.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA21.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA21.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA21.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA21.HighlightText = True
        Me.numKUSYA21.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA21.InputCheck = True
        Me.numKUSYA21.Location = New System.Drawing.Point(852, 345)
        Me.numKUSYA21.Name = "numKUSYA21"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA21, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA21, Object), CType(Me.numKUSYA21, Object), CType(Me.numKUSYA21, Object), CType(Me.numKUSYA21, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA21.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA21.Spin.Increment = 0
        Me.numKUSYA21.TabIndex = 48
        ValueProcess73.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA21).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess73})
        InvalidRange73.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange73.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA21).AddRange(New Object() {InvalidRange73})
        Me.numKUSYA21.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA21.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA15
        '
        Me.numKUSYA15.AllowDeleteToNull = True
        NumberIntegerPartDisplayField73.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField73.MaxDigits = 5
        NumberDecimalPartDisplayField73.MinDigits = 5
        Me.numKUSYA15.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField73, NumberIntegerPartDisplayField73, NumberDecimalSeparatorDisplayField73, NumberDecimalPartDisplayField73})
        Me.numKUSYA15.DropDown.AllowDrop = False
        Me.numKUSYA15.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA15.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA15.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA15.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA15.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA15.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA15.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA15.HighlightText = True
        Me.numKUSYA15.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA15.InputCheck = True
        Me.numKUSYA15.Location = New System.Drawing.Point(852, 320)
        Me.numKUSYA15.Name = "numKUSYA15"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA15, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA15, Object), CType(Me.numKUSYA15, Object), CType(Me.numKUSYA15, Object), CType(Me.numKUSYA15, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA15.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA15.Spin.Increment = 0
        Me.numKUSYA15.TabIndex = 41
        ValueProcess74.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA15).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess74})
        InvalidRange74.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange74.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA15).AddRange(New Object() {InvalidRange74})
        Me.numKUSYA15.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA15.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA14
        '
        Me.numKUSYA14.AllowDeleteToNull = True
        NumberIntegerPartDisplayField74.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField74.MaxDigits = 5
        NumberDecimalPartDisplayField74.MinDigits = 5
        Me.numKUSYA14.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField74, NumberIntegerPartDisplayField74, NumberDecimalSeparatorDisplayField74, NumberDecimalPartDisplayField74})
        Me.numKUSYA14.DropDown.AllowDrop = False
        Me.numKUSYA14.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA14.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA14.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA14.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA14.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA14.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA14.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA14.HighlightText = True
        Me.numKUSYA14.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA14.InputCheck = True
        Me.numKUSYA14.Location = New System.Drawing.Point(852, 295)
        Me.numKUSYA14.Name = "numKUSYA14"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA14, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA14, Object), CType(Me.numKUSYA14, Object), CType(Me.numKUSYA14, Object), CType(Me.numKUSYA14, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA14.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA14.Spin.Increment = 0
        Me.numKUSYA14.TabIndex = 34
        ValueProcess75.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA14).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess75})
        InvalidRange75.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange75.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA14).AddRange(New Object() {InvalidRange75})
        Me.numKUSYA14.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA14.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA13
        '
        Me.numKUSYA13.AllowDeleteToNull = True
        NumberIntegerPartDisplayField75.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField75.MaxDigits = 5
        NumberDecimalPartDisplayField75.MinDigits = 5
        Me.numKUSYA13.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField75, NumberIntegerPartDisplayField75, NumberDecimalSeparatorDisplayField75, NumberDecimalPartDisplayField75})
        Me.numKUSYA13.DropDown.AllowDrop = False
        Me.numKUSYA13.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA13.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA13.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA13.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA13.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA13.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA13.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA13.HighlightText = True
        Me.numKUSYA13.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA13.InputCheck = True
        Me.numKUSYA13.Location = New System.Drawing.Point(852, 270)
        Me.numKUSYA13.Name = "numKUSYA13"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA13, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA13, Object), CType(Me.numKUSYA13, Object), CType(Me.numKUSYA13, Object), CType(Me.numKUSYA13, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA13.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA13.Spin.Increment = 0
        Me.numKUSYA13.TabIndex = 27
        ValueProcess76.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA13).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess76})
        InvalidRange76.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange76.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA13).AddRange(New Object() {InvalidRange76})
        Me.numKUSYA13.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA13.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA12
        '
        Me.numKUSYA12.AllowDeleteToNull = True
        NumberIntegerPartDisplayField76.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField76.MaxDigits = 5
        NumberDecimalPartDisplayField76.MinDigits = 5
        Me.numKUSYA12.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField76, NumberIntegerPartDisplayField76, NumberDecimalSeparatorDisplayField76, NumberDecimalPartDisplayField76})
        Me.numKUSYA12.DropDown.AllowDrop = False
        Me.numKUSYA12.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA12.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA12.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA12.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA12.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA12.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA12.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA12.HighlightText = True
        Me.numKUSYA12.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA12.InputCheck = True
        Me.numKUSYA12.Location = New System.Drawing.Point(852, 245)
        Me.numKUSYA12.Name = "numKUSYA12"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA12, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA12, Object), CType(Me.numKUSYA12, Object), CType(Me.numKUSYA12, Object), CType(Me.numKUSYA12, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA12.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA12.Spin.Increment = 0
        Me.numKUSYA12.TabIndex = 20
        ValueProcess77.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA12).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess77})
        InvalidRange77.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange77.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA12).AddRange(New Object() {InvalidRange77})
        Me.numKUSYA12.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA12.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA11
        '
        Me.numKUSYA11.AllowDeleteToNull = True
        NumberIntegerPartDisplayField77.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField77.MaxDigits = 5
        NumberDecimalPartDisplayField77.MinDigits = 5
        Me.numKUSYA11.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField77, NumberIntegerPartDisplayField77, NumberDecimalSeparatorDisplayField77, NumberDecimalPartDisplayField77})
        Me.numKUSYA11.DropDown.AllowDrop = False
        Me.numKUSYA11.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA11.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA11.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA11.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA11.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA11.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA11.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA11.HighlightText = True
        Me.numKUSYA11.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA11.InputCheck = True
        Me.numKUSYA11.Location = New System.Drawing.Point(852, 220)
        Me.numKUSYA11.Name = "numKUSYA11"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA11, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA11, Object), CType(Me.numKUSYA11, Object), CType(Me.numKUSYA11, Object), CType(Me.numKUSYA11, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA11.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA11.Spin.Increment = 0
        Me.numKUSYA11.TabIndex = 13
        ValueProcess78.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA11).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess78})
        InvalidRange78.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange78.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA11).AddRange(New Object() {InvalidRange78})
        Me.numKUSYA11.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA11.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA37
        '
        Me.numKUSYA37.AllowDeleteToNull = True
        NumberIntegerPartDisplayField78.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField78.MaxDigits = 5
        NumberDecimalPartDisplayField78.MinDigits = 5
        Me.numKUSYA37.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField78, NumberIntegerPartDisplayField78, NumberDecimalSeparatorDisplayField78, NumberDecimalPartDisplayField78})
        Me.numKUSYA37.DropDown.AllowDrop = False
        Me.numKUSYA37.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA37.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA37.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA37.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA37.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA37.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA37.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA37.HighlightText = True
        Me.numKUSYA37.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA37.InputCheck = True
        Me.numKUSYA37.Location = New System.Drawing.Point(852, 495)
        Me.numKUSYA37.Name = "numKUSYA37"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA37, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA37, Object), CType(Me.numKUSYA37, Object), CType(Me.numKUSYA37, Object), CType(Me.numKUSYA37, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA37.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA37.Spin.Increment = 0
        Me.numKUSYA37.TabIndex = 90
        ValueProcess79.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA37).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess79})
        InvalidRange79.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange79.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA37).AddRange(New Object() {InvalidRange79})
        Me.numKUSYA37.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA37.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU37
        '
        Me.numGENKA_SYOKYAKU37.AllowDeleteToNull = True
        NumberIntegerPartDisplayField79.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField79.MaxDigits = 5
        NumberDecimalPartDisplayField79.MinDigits = 5
        Me.numGENKA_SYOKYAKU37.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField79, NumberIntegerPartDisplayField79, NumberDecimalSeparatorDisplayField79, NumberDecimalPartDisplayField79})
        Me.numGENKA_SYOKYAKU37.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU37.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU37.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU37.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU37.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU37.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU37.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU37.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU37.HighlightText = True
        Me.numGENKA_SYOKYAKU37.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU37.InputCheck = True
        Me.numGENKA_SYOKYAKU37.Location = New System.Drawing.Point(743, 495)
        Me.numGENKA_SYOKYAKU37.Name = "numGENKA_SYOKYAKU37"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU37, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU37, Object), CType(Me.numGENKA_SYOKYAKU37, Object), CType(Me.numGENKA_SYOKYAKU37, Object), CType(Me.numGENKA_SYOKYAKU37, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU37.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU37.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU37.TabIndex = 89
        ValueProcess80.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU37).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess80})
        InvalidRange80.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange80.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU37).AddRange(New Object() {InvalidRange80})
        Me.numGENKA_SYOKYAKU37.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU37.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN37
        '
        Me.numGENKA_JOGEN37.AllowDeleteToNull = True
        NumberIntegerPartDisplayField80.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField80.MaxDigits = 5
        NumberDecimalPartDisplayField80.MinDigits = 5
        Me.numGENKA_JOGEN37.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField80, NumberIntegerPartDisplayField80, NumberDecimalSeparatorDisplayField80, NumberDecimalPartDisplayField80})
        Me.numGENKA_JOGEN37.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN37.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN37.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN37.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN37.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN37.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN37.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN37.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN37.HighlightText = True
        Me.numGENKA_JOGEN37.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN37.InputCheck = True
        Me.numGENKA_JOGEN37.Location = New System.Drawing.Point(637, 495)
        Me.numGENKA_JOGEN37.Name = "numGENKA_JOGEN37"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN37, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN37, Object), CType(Me.numGENKA_JOGEN37, Object), CType(Me.numGENKA_JOGEN37, Object), CType(Me.numGENKA_JOGEN37, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN37.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN37.Spin.Increment = 0
        Me.numGENKA_JOGEN37.TabIndex = 88
        ValueProcess81.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN37).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess81})
        InvalidRange81.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange81.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN37).AddRange(New Object() {InvalidRange81})
        Me.numGENKA_JOGEN37.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN37.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI37
        '
        Me.numJIDAI_JIDAI37.AllowDeleteToNull = True
        NumberIntegerPartDisplayField81.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField81.MaxDigits = 5
        NumberDecimalPartDisplayField81.MinDigits = 5
        Me.numJIDAI_JIDAI37.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField81, NumberIntegerPartDisplayField81, NumberDecimalSeparatorDisplayField81, NumberDecimalPartDisplayField81})
        Me.numJIDAI_JIDAI37.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI37.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI37.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI37.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI37.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI37.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI37.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI37.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI37.HighlightText = True
        Me.numJIDAI_JIDAI37.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI37.InputCheck = True
        Me.numJIDAI_JIDAI37.Location = New System.Drawing.Point(530, 495)
        Me.numJIDAI_JIDAI37.Name = "numJIDAI_JIDAI37"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI37, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI37, Object), CType(Me.numJIDAI_JIDAI37, Object), CType(Me.numJIDAI_JIDAI37, Object), CType(Me.numJIDAI_JIDAI37, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI37.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI37.Spin.Increment = 0
        Me.numJIDAI_JIDAI37.TabIndex = 87
        ValueProcess82.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI37).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess82})
        InvalidRange82.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange82.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI37).AddRange(New Object() {InvalidRange82})
        Me.numJIDAI_JIDAI37.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI37.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN37
        '
        Me.numJIDAI_JOGEN37.AllowDeleteToNull = True
        NumberIntegerPartDisplayField82.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField82.MaxDigits = 5
        NumberDecimalPartDisplayField82.MinDigits = 5
        Me.numJIDAI_JOGEN37.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField82, NumberIntegerPartDisplayField82, NumberDecimalSeparatorDisplayField82, NumberDecimalPartDisplayField82})
        Me.numJIDAI_JOGEN37.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN37.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN37.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN37.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN37.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN37.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN37.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN37.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN37.HighlightText = True
        Me.numJIDAI_JOGEN37.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN37.InputCheck = True
        Me.numJIDAI_JOGEN37.Location = New System.Drawing.Point(423, 495)
        Me.numJIDAI_JOGEN37.Name = "numJIDAI_JOGEN37"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN37, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN37, Object), CType(Me.numJIDAI_JOGEN37, Object), CType(Me.numJIDAI_JOGEN37, Object), CType(Me.numJIDAI_JOGEN37, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN37.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN37.Spin.Increment = 0
        Me.numJIDAI_JOGEN37.TabIndex = 86
        ValueProcess83.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN37).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess83})
        InvalidRange83.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange83.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN37).AddRange(New Object() {InvalidRange83})
        Me.numJIDAI_JOGEN37.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN37.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO37
        '
        Me.numKOYO_KOYO37.AllowDeleteToNull = True
        NumberIntegerPartDisplayField83.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField83.MaxDigits = 5
        NumberDecimalPartDisplayField83.MinDigits = 5
        Me.numKOYO_KOYO37.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField83, NumberIntegerPartDisplayField83, NumberDecimalSeparatorDisplayField83, NumberDecimalPartDisplayField83})
        Me.numKOYO_KOYO37.DropDown.AllowDrop = False
        Me.numKOYO_KOYO37.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO37.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO37.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO37.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO37.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO37.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO37.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO37.HighlightText = True
        Me.numKOYO_KOYO37.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO37.InputCheck = True
        Me.numKOYO_KOYO37.Location = New System.Drawing.Point(316, 495)
        Me.numKOYO_KOYO37.Name = "numKOYO_KOYO37"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO37, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO37, Object), CType(Me.numKOYO_KOYO37, Object), CType(Me.numKOYO_KOYO37, Object), CType(Me.numKOYO_KOYO37, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO37.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO37.Spin.Increment = 0
        Me.numKOYO_KOYO37.TabIndex = 85
        ValueProcess84.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO37).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess84})
        InvalidRange84.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange84.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO37).AddRange(New Object() {InvalidRange84})
        Me.numKOYO_KOYO37.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO37.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN37
        '
        Me.numKOYO_JOGEN37.AllowDeleteToNull = True
        NumberIntegerPartDisplayField84.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField84.MaxDigits = 5
        NumberDecimalPartDisplayField84.MinDigits = 5
        Me.numKOYO_JOGEN37.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField84, NumberIntegerPartDisplayField84, NumberDecimalSeparatorDisplayField84, NumberDecimalPartDisplayField84})
        Me.numKOYO_JOGEN37.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN37.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN37.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN37.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN37.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN37.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN37.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN37.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN37.HighlightText = True
        Me.numKOYO_JOGEN37.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN37.InputCheck = True
        Me.numKOYO_JOGEN37.Location = New System.Drawing.Point(209, 495)
        Me.numKOYO_JOGEN37.Name = "numKOYO_JOGEN37"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN37, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN37, Object), CType(Me.numKOYO_JOGEN37, Object), CType(Me.numKOYO_JOGEN37, Object), CType(Me.numKOYO_JOGEN37, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN37.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN37.Spin.Increment = 0
        Me.numKOYO_JOGEN37.TabIndex = 84
        ValueProcess85.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN37).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess85})
        InvalidRange85.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange85.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN37).AddRange(New Object() {InvalidRange85})
        Me.numKOYO_JOGEN37.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_JOGEN37.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA38
        '
        Me.numKUSYA38.AllowDeleteToNull = True
        NumberIntegerPartDisplayField85.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField85.MaxDigits = 5
        NumberDecimalPartDisplayField85.MinDigits = 5
        Me.numKUSYA38.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField85, NumberIntegerPartDisplayField85, NumberDecimalSeparatorDisplayField85, NumberDecimalPartDisplayField85})
        Me.numKUSYA38.DropDown.AllowDrop = False
        Me.numKUSYA38.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA38.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA38.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA38.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA38.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA38.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA38.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA38.HighlightText = True
        Me.numKUSYA38.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA38.InputCheck = True
        Me.numKUSYA38.Location = New System.Drawing.Point(852, 520)
        Me.numKUSYA38.Name = "numKUSYA38"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA38, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA38, Object), CType(Me.numKUSYA38, Object), CType(Me.numKUSYA38, Object), CType(Me.numKUSYA38, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA38.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA38.Spin.Increment = 0
        Me.numKUSYA38.TabIndex = 97
        ValueProcess86.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA38).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess86})
        InvalidRange86.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange86.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA38).AddRange(New Object() {InvalidRange86})
        Me.numKUSYA38.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA38.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU38
        '
        Me.numGENKA_SYOKYAKU38.AllowDeleteToNull = True
        NumberIntegerPartDisplayField86.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField86.MaxDigits = 5
        NumberDecimalPartDisplayField86.MinDigits = 5
        Me.numGENKA_SYOKYAKU38.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField86, NumberIntegerPartDisplayField86, NumberDecimalSeparatorDisplayField86, NumberDecimalPartDisplayField86})
        Me.numGENKA_SYOKYAKU38.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU38.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU38.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU38.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU38.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU38.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU38.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU38.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU38.HighlightText = True
        Me.numGENKA_SYOKYAKU38.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU38.InputCheck = True
        Me.numGENKA_SYOKYAKU38.Location = New System.Drawing.Point(743, 520)
        Me.numGENKA_SYOKYAKU38.Name = "numGENKA_SYOKYAKU38"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU38, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU38, Object), CType(Me.numGENKA_SYOKYAKU38, Object), CType(Me.numGENKA_SYOKYAKU38, Object), CType(Me.numGENKA_SYOKYAKU38, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU38.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU38.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU38.TabIndex = 96
        ValueProcess87.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU38).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess87})
        InvalidRange87.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange87.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU38).AddRange(New Object() {InvalidRange87})
        Me.numGENKA_SYOKYAKU38.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU38.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN38
        '
        Me.numGENKA_JOGEN38.AllowDeleteToNull = True
        NumberIntegerPartDisplayField87.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField87.MaxDigits = 5
        NumberDecimalPartDisplayField87.MinDigits = 5
        Me.numGENKA_JOGEN38.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField87, NumberIntegerPartDisplayField87, NumberDecimalSeparatorDisplayField87, NumberDecimalPartDisplayField87})
        Me.numGENKA_JOGEN38.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN38.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN38.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN38.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN38.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN38.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN38.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN38.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN38.HighlightText = True
        Me.numGENKA_JOGEN38.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN38.InputCheck = True
        Me.numGENKA_JOGEN38.Location = New System.Drawing.Point(637, 520)
        Me.numGENKA_JOGEN38.Name = "numGENKA_JOGEN38"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN38, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN38, Object), CType(Me.numGENKA_JOGEN38, Object), CType(Me.numGENKA_JOGEN38, Object), CType(Me.numGENKA_JOGEN38, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN38.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN38.Spin.Increment = 0
        Me.numGENKA_JOGEN38.TabIndex = 95
        ValueProcess88.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN38).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess88})
        InvalidRange88.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange88.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN38).AddRange(New Object() {InvalidRange88})
        Me.numGENKA_JOGEN38.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN38.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI38
        '
        Me.numJIDAI_JIDAI38.AllowDeleteToNull = True
        NumberIntegerPartDisplayField88.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField88.MaxDigits = 5
        NumberDecimalPartDisplayField88.MinDigits = 5
        Me.numJIDAI_JIDAI38.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField88, NumberIntegerPartDisplayField88, NumberDecimalSeparatorDisplayField88, NumberDecimalPartDisplayField88})
        Me.numJIDAI_JIDAI38.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI38.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI38.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI38.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI38.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI38.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI38.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI38.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI38.HighlightText = True
        Me.numJIDAI_JIDAI38.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI38.InputCheck = True
        Me.numJIDAI_JIDAI38.Location = New System.Drawing.Point(530, 520)
        Me.numJIDAI_JIDAI38.Name = "numJIDAI_JIDAI38"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI38, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI38, Object), CType(Me.numJIDAI_JIDAI38, Object), CType(Me.numJIDAI_JIDAI38, Object), CType(Me.numJIDAI_JIDAI38, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI38.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI38.Spin.Increment = 0
        Me.numJIDAI_JIDAI38.TabIndex = 94
        ValueProcess89.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI38).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess89})
        InvalidRange89.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange89.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI38).AddRange(New Object() {InvalidRange89})
        Me.numJIDAI_JIDAI38.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI38.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN38
        '
        Me.numJIDAI_JOGEN38.AllowDeleteToNull = True
        NumberIntegerPartDisplayField89.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField89.MaxDigits = 5
        NumberDecimalPartDisplayField89.MinDigits = 5
        Me.numJIDAI_JOGEN38.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField89, NumberIntegerPartDisplayField89, NumberDecimalSeparatorDisplayField89, NumberDecimalPartDisplayField89})
        Me.numJIDAI_JOGEN38.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN38.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN38.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN38.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN38.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN38.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN38.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN38.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN38.HighlightText = True
        Me.numJIDAI_JOGEN38.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN38.InputCheck = True
        Me.numJIDAI_JOGEN38.Location = New System.Drawing.Point(423, 520)
        Me.numJIDAI_JOGEN38.Name = "numJIDAI_JOGEN38"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN38, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN38, Object), CType(Me.numJIDAI_JOGEN38, Object), CType(Me.numJIDAI_JOGEN38, Object), CType(Me.numJIDAI_JOGEN38, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN38.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN38.Spin.Increment = 0
        Me.numJIDAI_JOGEN38.TabIndex = 93
        ValueProcess90.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN38).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess90})
        InvalidRange90.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange90.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN38).AddRange(New Object() {InvalidRange90})
        Me.numJIDAI_JOGEN38.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN38.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO38
        '
        Me.numKOYO_KOYO38.AllowDeleteToNull = True
        NumberIntegerPartDisplayField90.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField90.MaxDigits = 5
        NumberDecimalPartDisplayField90.MinDigits = 5
        Me.numKOYO_KOYO38.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField90, NumberIntegerPartDisplayField90, NumberDecimalSeparatorDisplayField90, NumberDecimalPartDisplayField90})
        Me.numKOYO_KOYO38.DropDown.AllowDrop = False
        Me.numKOYO_KOYO38.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO38.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO38.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO38.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO38.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO38.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO38.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO38.HighlightText = True
        Me.numKOYO_KOYO38.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO38.InputCheck = True
        Me.numKOYO_KOYO38.Location = New System.Drawing.Point(316, 520)
        Me.numKOYO_KOYO38.Name = "numKOYO_KOYO38"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO38, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO38, Object), CType(Me.numKOYO_KOYO38, Object), CType(Me.numKOYO_KOYO38, Object), CType(Me.numKOYO_KOYO38, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO38.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO38.Spin.Increment = 0
        Me.numKOYO_KOYO38.TabIndex = 92
        ValueProcess91.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO38).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess91})
        InvalidRange91.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange91.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO38).AddRange(New Object() {InvalidRange91})
        Me.numKOYO_KOYO38.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO38.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN38
        '
        Me.numKOYO_JOGEN38.AllowDeleteToNull = True
        NumberIntegerPartDisplayField91.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField91.MaxDigits = 5
        NumberDecimalPartDisplayField91.MinDigits = 5
        Me.numKOYO_JOGEN38.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField91, NumberIntegerPartDisplayField91, NumberDecimalSeparatorDisplayField91, NumberDecimalPartDisplayField91})
        Me.numKOYO_JOGEN38.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN38.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN38.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN38.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN38.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN38.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN38.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN38.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN38.HighlightText = True
        Me.numKOYO_JOGEN38.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN38.InputCheck = True
        Me.numKOYO_JOGEN38.Location = New System.Drawing.Point(209, 520)
        Me.numKOYO_JOGEN38.Name = "numKOYO_JOGEN38"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN38, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN38, Object), CType(Me.numKOYO_JOGEN38, Object), CType(Me.numKOYO_JOGEN38, Object), CType(Me.numKOYO_JOGEN38, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN38.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN38.Spin.Increment = 0
        Me.numKOYO_JOGEN38.TabIndex = 91
        ValueProcess92.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN38).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess92})
        InvalidRange92.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange92.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN38).AddRange(New Object() {InvalidRange92})
        Me.numKOYO_JOGEN38.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_JOGEN38.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA39
        '
        Me.numKUSYA39.AllowDeleteToNull = True
        NumberIntegerPartDisplayField92.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField92.MaxDigits = 5
        NumberDecimalPartDisplayField92.MinDigits = 5
        Me.numKUSYA39.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField92, NumberIntegerPartDisplayField92, NumberDecimalSeparatorDisplayField92, NumberDecimalPartDisplayField92})
        Me.numKUSYA39.DropDown.AllowDrop = False
        Me.numKUSYA39.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA39.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA39.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA39.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA39.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA39.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA39.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA39.HighlightText = True
        Me.numKUSYA39.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA39.InputCheck = True
        Me.numKUSYA39.Location = New System.Drawing.Point(852, 545)
        Me.numKUSYA39.Name = "numKUSYA39"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA39, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA39, Object), CType(Me.numKUSYA39, Object), CType(Me.numKUSYA39, Object), CType(Me.numKUSYA39, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA39.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA39.Spin.Increment = 0
        Me.numKUSYA39.TabIndex = 104
        ValueProcess93.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA39).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess93})
        InvalidRange93.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange93.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA39).AddRange(New Object() {InvalidRange93})
        Me.numKUSYA39.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA39.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU39
        '
        Me.numGENKA_SYOKYAKU39.AllowDeleteToNull = True
        NumberIntegerPartDisplayField93.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField93.MaxDigits = 5
        NumberDecimalPartDisplayField93.MinDigits = 5
        Me.numGENKA_SYOKYAKU39.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField93, NumberIntegerPartDisplayField93, NumberDecimalSeparatorDisplayField93, NumberDecimalPartDisplayField93})
        Me.numGENKA_SYOKYAKU39.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU39.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU39.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU39.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU39.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU39.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU39.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU39.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU39.HighlightText = True
        Me.numGENKA_SYOKYAKU39.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU39.InputCheck = True
        Me.numGENKA_SYOKYAKU39.Location = New System.Drawing.Point(743, 545)
        Me.numGENKA_SYOKYAKU39.Name = "numGENKA_SYOKYAKU39"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU39, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU39, Object), CType(Me.numGENKA_SYOKYAKU39, Object), CType(Me.numGENKA_SYOKYAKU39, Object), CType(Me.numGENKA_SYOKYAKU39, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU39.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU39.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU39.TabIndex = 103
        ValueProcess94.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU39).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess94})
        InvalidRange94.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange94.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU39).AddRange(New Object() {InvalidRange94})
        Me.numGENKA_SYOKYAKU39.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU39.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN39
        '
        Me.numGENKA_JOGEN39.AllowDeleteToNull = True
        NumberIntegerPartDisplayField94.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField94.MaxDigits = 5
        NumberDecimalPartDisplayField94.MinDigits = 5
        Me.numGENKA_JOGEN39.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField94, NumberIntegerPartDisplayField94, NumberDecimalSeparatorDisplayField94, NumberDecimalPartDisplayField94})
        Me.numGENKA_JOGEN39.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN39.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN39.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN39.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN39.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN39.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN39.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN39.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN39.HighlightText = True
        Me.numGENKA_JOGEN39.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN39.InputCheck = True
        Me.numGENKA_JOGEN39.Location = New System.Drawing.Point(637, 545)
        Me.numGENKA_JOGEN39.Name = "numGENKA_JOGEN39"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN39, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN39, Object), CType(Me.numGENKA_JOGEN39, Object), CType(Me.numGENKA_JOGEN39, Object), CType(Me.numGENKA_JOGEN39, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN39.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN39.Spin.Increment = 0
        Me.numGENKA_JOGEN39.TabIndex = 102
        ValueProcess95.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN39).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess95})
        InvalidRange95.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange95.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN39).AddRange(New Object() {InvalidRange95})
        Me.numGENKA_JOGEN39.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN39.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI39
        '
        Me.numJIDAI_JIDAI39.AllowDeleteToNull = True
        NumberIntegerPartDisplayField95.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField95.MaxDigits = 5
        NumberDecimalPartDisplayField95.MinDigits = 5
        Me.numJIDAI_JIDAI39.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField95, NumberIntegerPartDisplayField95, NumberDecimalSeparatorDisplayField95, NumberDecimalPartDisplayField95})
        Me.numJIDAI_JIDAI39.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI39.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI39.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI39.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI39.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI39.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI39.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI39.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI39.HighlightText = True
        Me.numJIDAI_JIDAI39.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI39.InputCheck = True
        Me.numJIDAI_JIDAI39.Location = New System.Drawing.Point(530, 545)
        Me.numJIDAI_JIDAI39.Name = "numJIDAI_JIDAI39"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI39, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI39, Object), CType(Me.numJIDAI_JIDAI39, Object), CType(Me.numJIDAI_JIDAI39, Object), CType(Me.numJIDAI_JIDAI39, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI39.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI39.Spin.Increment = 0
        Me.numJIDAI_JIDAI39.TabIndex = 101
        ValueProcess96.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI39).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess96})
        InvalidRange96.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange96.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI39).AddRange(New Object() {InvalidRange96})
        Me.numJIDAI_JIDAI39.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI39.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN39
        '
        Me.numJIDAI_JOGEN39.AllowDeleteToNull = True
        NumberIntegerPartDisplayField96.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField96.MaxDigits = 5
        NumberDecimalPartDisplayField96.MinDigits = 5
        Me.numJIDAI_JOGEN39.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField96, NumberIntegerPartDisplayField96, NumberDecimalSeparatorDisplayField96, NumberDecimalPartDisplayField96})
        Me.numJIDAI_JOGEN39.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN39.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN39.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN39.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN39.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN39.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN39.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN39.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN39.HighlightText = True
        Me.numJIDAI_JOGEN39.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN39.InputCheck = True
        Me.numJIDAI_JOGEN39.Location = New System.Drawing.Point(423, 545)
        Me.numJIDAI_JOGEN39.Name = "numJIDAI_JOGEN39"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN39, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN39, Object), CType(Me.numJIDAI_JOGEN39, Object), CType(Me.numJIDAI_JOGEN39, Object), CType(Me.numJIDAI_JOGEN39, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN39.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN39.Spin.Increment = 0
        Me.numJIDAI_JOGEN39.TabIndex = 100
        ValueProcess97.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN39).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess97})
        InvalidRange97.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange97.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN39).AddRange(New Object() {InvalidRange97})
        Me.numJIDAI_JOGEN39.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN39.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO39
        '
        Me.numKOYO_KOYO39.AllowDeleteToNull = True
        NumberIntegerPartDisplayField97.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField97.MaxDigits = 5
        NumberDecimalPartDisplayField97.MinDigits = 5
        Me.numKOYO_KOYO39.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField97, NumberIntegerPartDisplayField97, NumberDecimalSeparatorDisplayField97, NumberDecimalPartDisplayField97})
        Me.numKOYO_KOYO39.DropDown.AllowDrop = False
        Me.numKOYO_KOYO39.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO39.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO39.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO39.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO39.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO39.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO39.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO39.HighlightText = True
        Me.numKOYO_KOYO39.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO39.InputCheck = True
        Me.numKOYO_KOYO39.Location = New System.Drawing.Point(316, 545)
        Me.numKOYO_KOYO39.Name = "numKOYO_KOYO39"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO39, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO39, Object), CType(Me.numKOYO_KOYO39, Object), CType(Me.numKOYO_KOYO39, Object), CType(Me.numKOYO_KOYO39, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO39.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO39.Spin.Increment = 0
        Me.numKOYO_KOYO39.TabIndex = 99
        ValueProcess98.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO39).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess98})
        InvalidRange98.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange98.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO39).AddRange(New Object() {InvalidRange98})
        Me.numKOYO_KOYO39.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO39.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN39
        '
        Me.numKOYO_JOGEN39.AllowDeleteToNull = True
        NumberIntegerPartDisplayField98.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField98.MaxDigits = 5
        NumberDecimalPartDisplayField98.MinDigits = 5
        Me.numKOYO_JOGEN39.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField98, NumberIntegerPartDisplayField98, NumberDecimalSeparatorDisplayField98, NumberDecimalPartDisplayField98})
        Me.numKOYO_JOGEN39.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN39.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN39.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN39.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN39.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN39.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN39.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN39.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN39.HighlightText = True
        Me.numKOYO_JOGEN39.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN39.InputCheck = True
        Me.numKOYO_JOGEN39.Location = New System.Drawing.Point(209, 545)
        Me.numKOYO_JOGEN39.Name = "numKOYO_JOGEN39"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN39, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN39, Object), CType(Me.numKOYO_JOGEN39, Object), CType(Me.numKOYO_JOGEN39, Object), CType(Me.numKOYO_JOGEN39, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN39.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN39.Spin.Increment = 0
        Me.numKOYO_JOGEN39.TabIndex = 98
        ValueProcess99.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN39).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess99})
        InvalidRange99.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange99.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN39).AddRange(New Object() {InvalidRange99})
        Me.numKOYO_JOGEN39.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_JOGEN39.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA40
        '
        Me.numKUSYA40.AllowDeleteToNull = True
        NumberIntegerPartDisplayField99.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField99.MaxDigits = 5
        NumberDecimalPartDisplayField99.MinDigits = 5
        Me.numKUSYA40.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField99, NumberIntegerPartDisplayField99, NumberDecimalSeparatorDisplayField99, NumberDecimalPartDisplayField99})
        Me.numKUSYA40.DropDown.AllowDrop = False
        Me.numKUSYA40.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA40.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA40.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA40.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA40.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA40.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA40.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA40.HighlightText = True
        Me.numKUSYA40.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA40.InputCheck = True
        Me.numKUSYA40.Location = New System.Drawing.Point(852, 570)
        Me.numKUSYA40.Name = "numKUSYA40"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA40, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA40, Object), CType(Me.numKUSYA40, Object), CType(Me.numKUSYA40, Object), CType(Me.numKUSYA40, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA40.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA40.Spin.Increment = 0
        Me.numKUSYA40.TabIndex = 111
        ValueProcess100.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA40).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess100})
        InvalidRange100.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange100.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA40).AddRange(New Object() {InvalidRange100})
        Me.numKUSYA40.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA40.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU40
        '
        Me.numGENKA_SYOKYAKU40.AllowDeleteToNull = True
        NumberIntegerPartDisplayField100.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField100.MaxDigits = 5
        NumberDecimalPartDisplayField100.MinDigits = 5
        Me.numGENKA_SYOKYAKU40.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField100, NumberIntegerPartDisplayField100, NumberDecimalSeparatorDisplayField100, NumberDecimalPartDisplayField100})
        Me.numGENKA_SYOKYAKU40.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU40.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU40.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU40.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU40.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU40.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU40.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU40.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU40.HighlightText = True
        Me.numGENKA_SYOKYAKU40.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU40.InputCheck = True
        Me.numGENKA_SYOKYAKU40.Location = New System.Drawing.Point(743, 570)
        Me.numGENKA_SYOKYAKU40.Name = "numGENKA_SYOKYAKU40"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU40, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU40, Object), CType(Me.numGENKA_SYOKYAKU40, Object), CType(Me.numGENKA_SYOKYAKU40, Object), CType(Me.numGENKA_SYOKYAKU40, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU40.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU40.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU40.TabIndex = 110
        ValueProcess101.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU40).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess101})
        InvalidRange101.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange101.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU40).AddRange(New Object() {InvalidRange101})
        Me.numGENKA_SYOKYAKU40.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU40.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN40
        '
        Me.numGENKA_JOGEN40.AllowDeleteToNull = True
        NumberIntegerPartDisplayField101.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField101.MaxDigits = 5
        NumberDecimalPartDisplayField101.MinDigits = 5
        Me.numGENKA_JOGEN40.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField101, NumberIntegerPartDisplayField101, NumberDecimalSeparatorDisplayField101, NumberDecimalPartDisplayField101})
        Me.numGENKA_JOGEN40.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN40.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN40.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN40.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN40.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN40.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN40.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN40.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN40.HighlightText = True
        Me.numGENKA_JOGEN40.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN40.InputCheck = True
        Me.numGENKA_JOGEN40.Location = New System.Drawing.Point(637, 570)
        Me.numGENKA_JOGEN40.Name = "numGENKA_JOGEN40"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN40, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN40, Object), CType(Me.numGENKA_JOGEN40, Object), CType(Me.numGENKA_JOGEN40, Object), CType(Me.numGENKA_JOGEN40, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN40.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN40.Spin.Increment = 0
        Me.numGENKA_JOGEN40.TabIndex = 109
        ValueProcess102.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN40).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess102})
        InvalidRange102.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange102.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN40).AddRange(New Object() {InvalidRange102})
        Me.numGENKA_JOGEN40.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN40.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI40
        '
        Me.numJIDAI_JIDAI40.AllowDeleteToNull = True
        NumberIntegerPartDisplayField102.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField102.MaxDigits = 5
        NumberDecimalPartDisplayField102.MinDigits = 5
        Me.numJIDAI_JIDAI40.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField102, NumberIntegerPartDisplayField102, NumberDecimalSeparatorDisplayField102, NumberDecimalPartDisplayField102})
        Me.numJIDAI_JIDAI40.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI40.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI40.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI40.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI40.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI40.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI40.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI40.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI40.HighlightText = True
        Me.numJIDAI_JIDAI40.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI40.InputCheck = True
        Me.numJIDAI_JIDAI40.Location = New System.Drawing.Point(530, 570)
        Me.numJIDAI_JIDAI40.Name = "numJIDAI_JIDAI40"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI40, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI40, Object), CType(Me.numJIDAI_JIDAI40, Object), CType(Me.numJIDAI_JIDAI40, Object), CType(Me.numJIDAI_JIDAI40, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI40.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI40.Spin.Increment = 0
        Me.numJIDAI_JIDAI40.TabIndex = 108
        ValueProcess103.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI40).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess103})
        InvalidRange103.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange103.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI40).AddRange(New Object() {InvalidRange103})
        Me.numJIDAI_JIDAI40.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI40.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN40
        '
        Me.numJIDAI_JOGEN40.AllowDeleteToNull = True
        NumberIntegerPartDisplayField103.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField103.MaxDigits = 5
        NumberDecimalPartDisplayField103.MinDigits = 5
        Me.numJIDAI_JOGEN40.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField103, NumberIntegerPartDisplayField103, NumberDecimalSeparatorDisplayField103, NumberDecimalPartDisplayField103})
        Me.numJIDAI_JOGEN40.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN40.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN40.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN40.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN40.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN40.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN40.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN40.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN40.HighlightText = True
        Me.numJIDAI_JOGEN40.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN40.InputCheck = True
        Me.numJIDAI_JOGEN40.Location = New System.Drawing.Point(423, 570)
        Me.numJIDAI_JOGEN40.Name = "numJIDAI_JOGEN40"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN40, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN40, Object), CType(Me.numJIDAI_JOGEN40, Object), CType(Me.numJIDAI_JOGEN40, Object), CType(Me.numJIDAI_JOGEN40, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN40.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN40.Spin.Increment = 0
        Me.numJIDAI_JOGEN40.TabIndex = 107
        ValueProcess104.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN40).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess104})
        InvalidRange104.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange104.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN40).AddRange(New Object() {InvalidRange104})
        Me.numJIDAI_JOGEN40.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN40.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO40
        '
        Me.numKOYO_KOYO40.AllowDeleteToNull = True
        NumberIntegerPartDisplayField104.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField104.MaxDigits = 5
        NumberDecimalPartDisplayField104.MinDigits = 5
        Me.numKOYO_KOYO40.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField104, NumberIntegerPartDisplayField104, NumberDecimalSeparatorDisplayField104, NumberDecimalPartDisplayField104})
        Me.numKOYO_KOYO40.DropDown.AllowDrop = False
        Me.numKOYO_KOYO40.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO40.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO40.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO40.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO40.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO40.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO40.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO40.HighlightText = True
        Me.numKOYO_KOYO40.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO40.InputCheck = True
        Me.numKOYO_KOYO40.Location = New System.Drawing.Point(316, 570)
        Me.numKOYO_KOYO40.Name = "numKOYO_KOYO40"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO40, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO40, Object), CType(Me.numKOYO_KOYO40, Object), CType(Me.numKOYO_KOYO40, Object), CType(Me.numKOYO_KOYO40, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO40.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO40.Spin.Increment = 0
        Me.numKOYO_KOYO40.TabIndex = 106
        ValueProcess105.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO40).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess105})
        InvalidRange105.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange105.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO40).AddRange(New Object() {InvalidRange105})
        Me.numKOYO_KOYO40.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO40.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN40
        '
        Me.numKOYO_JOGEN40.AllowDeleteToNull = True
        NumberIntegerPartDisplayField105.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField105.MaxDigits = 5
        NumberDecimalPartDisplayField105.MinDigits = 5
        Me.numKOYO_JOGEN40.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField105, NumberIntegerPartDisplayField105, NumberDecimalSeparatorDisplayField105, NumberDecimalPartDisplayField105})
        Me.numKOYO_JOGEN40.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN40.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN40.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN40.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN40.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN40.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN40.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN40.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN40.HighlightText = True
        Me.numKOYO_JOGEN40.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN40.InputCheck = True
        Me.numKOYO_JOGEN40.Location = New System.Drawing.Point(209, 570)
        Me.numKOYO_JOGEN40.Name = "numKOYO_JOGEN40"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN40, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN40, Object), CType(Me.numKOYO_JOGEN40, Object), CType(Me.numKOYO_JOGEN40, Object), CType(Me.numKOYO_JOGEN40, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN40.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN40.Spin.Increment = 0
        Me.numKOYO_JOGEN40.TabIndex = 105
        ValueProcess106.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN40).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess106})
        InvalidRange106.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange106.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN40).AddRange(New Object() {InvalidRange106})
        Me.numKOYO_JOGEN40.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_JOGEN40.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKUSYA41
        '
        Me.numKUSYA41.AllowDeleteToNull = True
        NumberIntegerPartDisplayField106.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField106.MaxDigits = 5
        NumberDecimalPartDisplayField106.MinDigits = 5
        Me.numKUSYA41.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField106, NumberIntegerPartDisplayField106, NumberDecimalSeparatorDisplayField106, NumberDecimalPartDisplayField106})
        Me.numKUSYA41.DropDown.AllowDrop = False
        Me.numKUSYA41.Fields.DecimalPart.MaxDigits = 5
        Me.numKUSYA41.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKUSYA41.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKUSYA41.Fields.IntegerPart.MaxDigits = 4
        Me.numKUSYA41.Fields.IntegerPart.MinDigits = 1
        Me.numKUSYA41.Fields.SignPrefix.NegativePattern = ""
        Me.numKUSYA41.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKUSYA41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKUSYA41.HighlightText = True
        Me.numKUSYA41.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKUSYA41.InputCheck = True
        Me.numKUSYA41.Location = New System.Drawing.Point(852, 595)
        Me.numKUSYA41.Name = "numKUSYA41"
        Me.GcShortcut1.SetShortcuts(Me.numKUSYA41, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKUSYA41, Object), CType(Me.numKUSYA41, Object), CType(Me.numKUSYA41, Object), CType(Me.numKUSYA41, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKUSYA41.Size = New System.Drawing.Size(90, 20)
        Me.numKUSYA41.Spin.Increment = 0
        Me.numKUSYA41.TabIndex = 118
        ValueProcess107.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKUSYA41).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess107})
        InvalidRange107.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange107.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKUSYA41).AddRange(New Object() {InvalidRange107})
        Me.numKUSYA41.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKUSYA41.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_SYOKYAKU41
        '
        Me.numGENKA_SYOKYAKU41.AllowDeleteToNull = True
        NumberIntegerPartDisplayField107.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField107.MaxDigits = 5
        NumberDecimalPartDisplayField107.MinDigits = 5
        Me.numGENKA_SYOKYAKU41.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField107, NumberIntegerPartDisplayField107, NumberDecimalSeparatorDisplayField107, NumberDecimalPartDisplayField107})
        Me.numGENKA_SYOKYAKU41.DropDown.AllowDrop = False
        Me.numGENKA_SYOKYAKU41.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_SYOKYAKU41.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_SYOKYAKU41.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_SYOKYAKU41.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_SYOKYAKU41.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_SYOKYAKU41.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_SYOKYAKU41.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_SYOKYAKU41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_SYOKYAKU41.HighlightText = True
        Me.numGENKA_SYOKYAKU41.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_SYOKYAKU41.InputCheck = True
        Me.numGENKA_SYOKYAKU41.Location = New System.Drawing.Point(743, 595)
        Me.numGENKA_SYOKYAKU41.Name = "numGENKA_SYOKYAKU41"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_SYOKYAKU41, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_SYOKYAKU41, Object), CType(Me.numGENKA_SYOKYAKU41, Object), CType(Me.numGENKA_SYOKYAKU41, Object), CType(Me.numGENKA_SYOKYAKU41, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_SYOKYAKU41.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_SYOKYAKU41.Spin.Increment = 0
        Me.numGENKA_SYOKYAKU41.TabIndex = 117
        ValueProcess108.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_SYOKYAKU41).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess108})
        InvalidRange108.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange108.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_SYOKYAKU41).AddRange(New Object() {InvalidRange108})
        Me.numGENKA_SYOKYAKU41.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_SYOKYAKU41.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numGENKA_JOGEN41
        '
        Me.numGENKA_JOGEN41.AllowDeleteToNull = True
        NumberIntegerPartDisplayField108.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField108.MaxDigits = 5
        NumberDecimalPartDisplayField108.MinDigits = 5
        Me.numGENKA_JOGEN41.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField108, NumberIntegerPartDisplayField108, NumberDecimalSeparatorDisplayField108, NumberDecimalPartDisplayField108})
        Me.numGENKA_JOGEN41.DropDown.AllowDrop = False
        Me.numGENKA_JOGEN41.Fields.DecimalPart.MaxDigits = 5
        Me.numGENKA_JOGEN41.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numGENKA_JOGEN41.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numGENKA_JOGEN41.Fields.IntegerPart.MaxDigits = 4
        Me.numGENKA_JOGEN41.Fields.IntegerPart.MinDigits = 1
        Me.numGENKA_JOGEN41.Fields.SignPrefix.NegativePattern = ""
        Me.numGENKA_JOGEN41.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numGENKA_JOGEN41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numGENKA_JOGEN41.HighlightText = True
        Me.numGENKA_JOGEN41.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numGENKA_JOGEN41.InputCheck = True
        Me.numGENKA_JOGEN41.Location = New System.Drawing.Point(637, 595)
        Me.numGENKA_JOGEN41.Name = "numGENKA_JOGEN41"
        Me.GcShortcut1.SetShortcuts(Me.numGENKA_JOGEN41, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numGENKA_JOGEN41, Object), CType(Me.numGENKA_JOGEN41, Object), CType(Me.numGENKA_JOGEN41, Object), CType(Me.numGENKA_JOGEN41, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numGENKA_JOGEN41.Size = New System.Drawing.Size(90, 20)
        Me.numGENKA_JOGEN41.Spin.Increment = 0
        Me.numGENKA_JOGEN41.TabIndex = 116
        ValueProcess109.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numGENKA_JOGEN41).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess109})
        InvalidRange109.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange109.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numGENKA_JOGEN41).AddRange(New Object() {InvalidRange109})
        Me.numGENKA_JOGEN41.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numGENKA_JOGEN41.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JIDAI41
        '
        Me.numJIDAI_JIDAI41.AllowDeleteToNull = True
        NumberIntegerPartDisplayField109.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField109.MaxDigits = 5
        NumberDecimalPartDisplayField109.MinDigits = 5
        Me.numJIDAI_JIDAI41.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField109, NumberIntegerPartDisplayField109, NumberDecimalSeparatorDisplayField109, NumberDecimalPartDisplayField109})
        Me.numJIDAI_JIDAI41.DropDown.AllowDrop = False
        Me.numJIDAI_JIDAI41.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JIDAI41.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JIDAI41.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JIDAI41.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JIDAI41.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JIDAI41.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JIDAI41.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JIDAI41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JIDAI41.HighlightText = True
        Me.numJIDAI_JIDAI41.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JIDAI41.InputCheck = True
        Me.numJIDAI_JIDAI41.Location = New System.Drawing.Point(530, 595)
        Me.numJIDAI_JIDAI41.Name = "numJIDAI_JIDAI41"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JIDAI41, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JIDAI41, Object), CType(Me.numJIDAI_JIDAI41, Object), CType(Me.numJIDAI_JIDAI41, Object), CType(Me.numJIDAI_JIDAI41, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JIDAI41.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JIDAI41.Spin.Increment = 0
        Me.numJIDAI_JIDAI41.TabIndex = 115
        ValueProcess110.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JIDAI41).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess110})
        InvalidRange110.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange110.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JIDAI41).AddRange(New Object() {InvalidRange110})
        Me.numJIDAI_JIDAI41.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JIDAI41.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numJIDAI_JOGEN41
        '
        Me.numJIDAI_JOGEN41.AllowDeleteToNull = True
        NumberIntegerPartDisplayField110.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField110.MaxDigits = 5
        NumberDecimalPartDisplayField110.MinDigits = 5
        Me.numJIDAI_JOGEN41.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField110, NumberIntegerPartDisplayField110, NumberDecimalSeparatorDisplayField110, NumberDecimalPartDisplayField110})
        Me.numJIDAI_JOGEN41.DropDown.AllowDrop = False
        Me.numJIDAI_JOGEN41.Fields.DecimalPart.MaxDigits = 5
        Me.numJIDAI_JOGEN41.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numJIDAI_JOGEN41.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numJIDAI_JOGEN41.Fields.IntegerPart.MaxDigits = 4
        Me.numJIDAI_JOGEN41.Fields.IntegerPart.MinDigits = 1
        Me.numJIDAI_JOGEN41.Fields.SignPrefix.NegativePattern = ""
        Me.numJIDAI_JOGEN41.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numJIDAI_JOGEN41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numJIDAI_JOGEN41.HighlightText = True
        Me.numJIDAI_JOGEN41.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numJIDAI_JOGEN41.InputCheck = True
        Me.numJIDAI_JOGEN41.Location = New System.Drawing.Point(423, 595)
        Me.numJIDAI_JOGEN41.Name = "numJIDAI_JOGEN41"
        Me.GcShortcut1.SetShortcuts(Me.numJIDAI_JOGEN41, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numJIDAI_JOGEN41, Object), CType(Me.numJIDAI_JOGEN41, Object), CType(Me.numJIDAI_JOGEN41, Object), CType(Me.numJIDAI_JOGEN41, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numJIDAI_JOGEN41.Size = New System.Drawing.Size(90, 20)
        Me.numJIDAI_JOGEN41.Spin.Increment = 0
        Me.numJIDAI_JOGEN41.TabIndex = 114
        ValueProcess111.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numJIDAI_JOGEN41).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess111})
        InvalidRange111.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange111.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numJIDAI_JOGEN41).AddRange(New Object() {InvalidRange111})
        Me.numJIDAI_JOGEN41.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numJIDAI_JOGEN41.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_KOYO41
        '
        Me.numKOYO_KOYO41.AllowDeleteToNull = True
        NumberIntegerPartDisplayField111.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField111.MaxDigits = 5
        NumberDecimalPartDisplayField111.MinDigits = 5
        Me.numKOYO_KOYO41.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField111, NumberIntegerPartDisplayField111, NumberDecimalSeparatorDisplayField111, NumberDecimalPartDisplayField111})
        Me.numKOYO_KOYO41.DropDown.AllowDrop = False
        Me.numKOYO_KOYO41.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_KOYO41.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_KOYO41.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_KOYO41.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_KOYO41.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_KOYO41.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_KOYO41.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_KOYO41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_KOYO41.HighlightText = True
        Me.numKOYO_KOYO41.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_KOYO41.InputCheck = True
        Me.numKOYO_KOYO41.Location = New System.Drawing.Point(316, 595)
        Me.numKOYO_KOYO41.Name = "numKOYO_KOYO41"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_KOYO41, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_KOYO41, Object), CType(Me.numKOYO_KOYO41, Object), CType(Me.numKOYO_KOYO41, Object), CType(Me.numKOYO_KOYO41, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_KOYO41.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_KOYO41.Spin.Increment = 0
        Me.numKOYO_KOYO41.TabIndex = 113
        ValueProcess112.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_KOYO41).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess112})
        InvalidRange112.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange112.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_KOYO41).AddRange(New Object() {InvalidRange112})
        Me.numKOYO_KOYO41.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_KOYO41.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'numKOYO_JOGEN41
        '
        Me.numKOYO_JOGEN41.AllowDeleteToNull = True
        NumberIntegerPartDisplayField112.GroupSizes = New Integer() {3, 3, 0}
        NumberDecimalPartDisplayField112.MaxDigits = 5
        NumberDecimalPartDisplayField112.MinDigits = 5
        Me.numKOYO_JOGEN41.DisplayFields.AddRange(New GrapeCity.Win.Editors.Fields.NumberDisplayField() {NumberSignDisplayField112, NumberIntegerPartDisplayField112, NumberDecimalSeparatorDisplayField112, NumberDecimalPartDisplayField112})
        Me.numKOYO_JOGEN41.DropDown.AllowDrop = False
        Me.numKOYO_JOGEN41.Fields.DecimalPart.MaxDigits = 5
        Me.numKOYO_JOGEN41.Fields.IntegerPart.GroupSeparator = Global.Microsoft.VisualBasic.ChrW(0)
        Me.numKOYO_JOGEN41.Fields.IntegerPart.GroupSizes = New Integer() {0}
        Me.numKOYO_JOGEN41.Fields.IntegerPart.MaxDigits = 4
        Me.numKOYO_JOGEN41.Fields.IntegerPart.MinDigits = 1
        Me.numKOYO_JOGEN41.Fields.SignPrefix.NegativePattern = ""
        Me.numKOYO_JOGEN41.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
        Me.numKOYO_JOGEN41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.numKOYO_JOGEN41.HighlightText = True
        Me.numKOYO_JOGEN41.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.numKOYO_JOGEN41.InputCheck = True
        Me.numKOYO_JOGEN41.Location = New System.Drawing.Point(209, 595)
        Me.numKOYO_JOGEN41.Name = "numKOYO_JOGEN41"
        Me.GcShortcut1.SetShortcuts(Me.numKOYO_JOGEN41, New GrapeCity.Win.Editors.ShortcutCollection(New System.Windows.Forms.Keys() {System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.Subtract, System.Windows.Forms.Keys.OemMinus, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.[Return]), System.Windows.Forms.Keys)}, New Object() {CType(Me.numKOYO_JOGEN41, Object), CType(Me.numKOYO_JOGEN41, Object), CType(Me.numKOYO_JOGEN41, Object), CType(Me.numKOYO_JOGEN41, Object)}, New String() {"SetZero", "SwitchSign", "SwitchSign", "ApplyRecommendedValue"}))
        Me.numKOYO_JOGEN41.Size = New System.Drawing.Size(90, 20)
        Me.numKOYO_JOGEN41.Spin.Increment = 0
        Me.numKOYO_JOGEN41.TabIndex = 112
        ValueProcess113.ValueProcessOption = GrapeCity.Win.Editors.ValueProcessOption.Clear
        Me.GcNumberValidator1.GetValidateActions(Me.numKOYO_JOGEN41).AddRange(New GrapeCity.Win.Editors.ValidateAction() {ValueProcess113})
        InvalidRange113.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 327680})
        InvalidRange113.MinValue = New Decimal(New Integer() {1, 0, 0, 327680})
        Me.GcNumberValidator1.GetValidateItems(Me.numKOYO_JOGEN41).AddRange(New Object() {InvalidRange113})
        Me.numKOYO_JOGEN41.Value = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numKOYO_JOGEN41.ValueSign = GrapeCity.Win.Editors.ValueSignControl.Positive
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSearch.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdSearch.Location = New System.Drawing.Point(690, 67)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(92, 44)
        Me.cmdSearch.TabIndex = 6
        Me.cmdSearch.Text = "検索"
        Me.cmdSearch.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSave.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdSave.Location = New System.Drawing.Point(12, 6)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 44)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "保存"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'cmdDelete
        '
        Me.cmdDelete.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdDelete.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdDelete.Location = New System.Drawing.Point(119, 6)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(92, 44)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.Text = "削除"
        Me.cmdDelete.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.cmdCancel.Location = New System.Drawing.Point(226, 6)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(92, 44)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'DropDownButton4
        '
        Me.DropDownButton4.Name = "DropDownButton4"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(63, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 975
        Me.Label2.Text = "■対象年度"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(233, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 976
        Me.Label3.Text = "年度"
        '
        'DropDownButton11
        '
        Me.DropDownButton11.Name = "DropDownButton11"
        '
        'DropDownButton2
        '
        Me.DropDownButton2.Name = "DropDownButton2"
        '
        'DropDownButton3
        '
        Me.DropDownButton3.Name = "DropDownButton3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(301, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 15)
        Me.Label4.TabIndex = 978
        Me.Label4.Text = "■前年度コピー有無"
        '
        'rdoARI
        '
        Me.rdoARI.AutoSize = True
        Me.rdoARI.Checked = True
        Me.rdoARI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoARI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoARI.Location = New System.Drawing.Point(36, 10)
        Me.rdoARI.Name = "rdoARI"
        Me.rdoARI.Size = New System.Drawing.Size(46, 20)
        Me.rdoARI.TabIndex = 4
        Me.rdoARI.TabStop = True
        Me.rdoARI.Text = "有"
        Me.rdoARI.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoNASI)
        Me.GroupBox1.Controls.Add(Me.rdoARI)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(437, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(173, 37)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'rdoNASI
        '
        Me.rdoNASI.AutoSize = True
        Me.rdoNASI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rdoNASI.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.rdoNASI.Location = New System.Drawing.Point(97, 10)
        Me.rdoNASI.Name = "rdoNASI"
        Me.rdoNASI.Size = New System.Drawing.Size(46, 20)
        Me.rdoNASI.TabIndex = 5
        Me.rdoNASI.Text = "無"
        Me.rdoNASI.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(30, 158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 60)
        Me.Label7.TabIndex = 981
        Me.Label7.Text = "契約" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "区分"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(30, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 26)
        Me.Label8.TabIndex = 983
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(82, 158)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 60)
        Me.Label9.TabIndex = 984
        Me.Label9.Text = "鳥の種類"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(82, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(121, 26)
        Me.Label10.TabIndex = 985
        Me.Label10.Text = "補正項目"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(30, 217)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 126)
        Me.Label11.TabIndex = 986
        Me.Label11.Text = "家族型"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(82, 217)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 26)
        Me.Label15.TabIndex = 989
        Me.Label15.Text = "採卵鶏（成鶏）"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(82, 242)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(121, 26)
        Me.Label12.TabIndex = 990
        Me.Label12.Text = "採卵鶏（育成鶏）"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(82, 267)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(121, 26)
        Me.Label16.TabIndex = 991
        Me.Label16.Text = "肉用鶏"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(82, 292)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(121, 26)
        Me.Label17.TabIndex = 992
        Me.Label17.Text = "種鶏（成鶏）"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(82, 317)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(121, 26)
        Me.Label18.TabIndex = 993
        Me.Label18.Text = "種鶏（育成鶏）"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(200, 133)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(215, 26)
        Me.Label25.TabIndex = 1000
        Me.Label25.Text = "雇用労賃補正"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(200, 158)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(215, 36)
        Me.Label26.TabIndex = 1001
        Me.Label26.Text = "生産費における１羽" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1ヶ月当たりの"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(200, 193)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(108, 25)
        Me.Label29.TabIndex = 1004
        Me.Label29.Text = "上限単価"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(307, 193)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(108, 25)
        Me.Label30.TabIndex = 1005
        Me.Label30.Text = "雇用労費"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(200, 217)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(108, 26)
        Me.Label31.TabIndex = 1006
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(307, 217)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(108, 26)
        Me.Label34.TabIndex = 1010
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(520, 217)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(108, 26)
        Me.Label27.TabIndex = 1018
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(414, 217)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(108, 26)
        Me.Label32.TabIndex = 1016
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(520, 193)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(108, 25)
        Me.Label35.TabIndex = 1015
        Me.Label35.Text = "地代"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(414, 193)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(108, 25)
        Me.Label36.TabIndex = 1014
        Me.Label36.Text = "上限地代"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(414, 158)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(214, 36)
        Me.Label37.TabIndex = 1013
        Me.Label37.Text = "生産費における１羽" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1ヶ月当たりの"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(414, 133)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(214, 26)
        Me.Label38.TabIndex = 1012
        Me.Label38.Text = "地代補正"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(734, 217)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(108, 26)
        Me.Label28.TabIndex = 1026
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(627, 217)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(108, 26)
        Me.Label33.TabIndex = 1024
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(734, 193)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(108, 25)
        Me.Label39.TabIndex = 1023
        Me.Label39.Text = "償却費"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label40.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(620, 193)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(122, 25)
        Me.Label40.TabIndex = 1022
        Me.Label40.Text = "上限減価償却費"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label41.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label41.Location = New System.Drawing.Point(627, 158)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(215, 36)
        Me.Label41.TabIndex = 1021
        Me.Label41.Text = "生産費における１羽" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1ヶ月当たりの"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label42.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(627, 133)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(215, 26)
        Me.Label42.TabIndex = 1020
        Me.Label42.Text = "原価償却費補正"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(839, 133)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(114, 26)
        Me.Label43.TabIndex = 1028
        Me.Label43.Text = "空舎期間の補正"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label44.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(841, 158)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(112, 60)
        Me.Label44.TabIndex = 1029
        Me.Label44.Text = "交付上限" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "単価における" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "空舎期間"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(841, 217)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(112, 26)
        Me.Label45.TabIndex = 1031
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.Location = New System.Drawing.Point(836, 114)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(114, 19)
        Me.Label46.TabIndex = 1032
        Me.Label46.Text = "（単位：円、月）"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(734, 242)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 26)
        Me.Label13.TabIndex = 1043
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(627, 242)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 26)
        Me.Label14.TabIndex = 1041
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(520, 242)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(108, 26)
        Me.Label19.TabIndex = 1039
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(414, 242)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(108, 26)
        Me.Label20.TabIndex = 1037
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(307, 242)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(108, 26)
        Me.Label21.TabIndex = 1035
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(200, 242)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(108, 26)
        Me.Label22.TabIndex = 1033
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(841, 242)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(112, 26)
        Me.Label23.TabIndex = 1046
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(734, 267)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(108, 26)
        Me.Label24.TabIndex = 1057
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label47.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(627, 267)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(108, 26)
        Me.Label47.TabIndex = 1055
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label48.Location = New System.Drawing.Point(520, 267)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(108, 26)
        Me.Label48.TabIndex = 1053
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label49.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label49.Location = New System.Drawing.Point(414, 267)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(108, 26)
        Me.Label49.TabIndex = 1051
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label50.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label50.Location = New System.Drawing.Point(307, 267)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(108, 26)
        Me.Label50.TabIndex = 1049
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label51.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label51.Location = New System.Drawing.Point(200, 267)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(108, 26)
        Me.Label51.TabIndex = 1047
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label52.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(841, 267)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(112, 26)
        Me.Label52.TabIndex = 1060
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label53.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label53.Location = New System.Drawing.Point(734, 292)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(108, 26)
        Me.Label53.TabIndex = 1071
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label54.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label54.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label54.Location = New System.Drawing.Point(627, 292)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(108, 26)
        Me.Label54.TabIndex = 1069
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.Transparent
        Me.Label55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label55.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label55.Location = New System.Drawing.Point(520, 292)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(108, 26)
        Me.Label55.TabIndex = 1067
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label56.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label56.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label56.Location = New System.Drawing.Point(414, 292)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(108, 26)
        Me.Label56.TabIndex = 1065
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label57.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label57.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label57.Location = New System.Drawing.Point(307, 292)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(108, 26)
        Me.Label57.TabIndex = 1063
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label58.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label58.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label58.Location = New System.Drawing.Point(200, 292)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(108, 26)
        Me.Label58.TabIndex = 1061
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.Transparent
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label59.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label59.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label59.Location = New System.Drawing.Point(841, 292)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(112, 26)
        Me.Label59.TabIndex = 1074
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.Color.Transparent
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label60.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label60.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label60.Location = New System.Drawing.Point(734, 317)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(108, 26)
        Me.Label60.TabIndex = 1085
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.Color.Transparent
        Me.Label61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label61.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label61.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label61.Location = New System.Drawing.Point(627, 317)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(108, 26)
        Me.Label61.TabIndex = 1083
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.Color.Transparent
        Me.Label62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label62.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label62.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label62.Location = New System.Drawing.Point(520, 317)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(108, 26)
        Me.Label62.TabIndex = 1081
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label63.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label63.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label63.Location = New System.Drawing.Point(414, 317)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(108, 26)
        Me.Label63.TabIndex = 1079
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.Transparent
        Me.Label64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label64.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label64.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label64.Location = New System.Drawing.Point(307, 317)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(108, 26)
        Me.Label64.TabIndex = 1077
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label65
        '
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label65.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label65.Location = New System.Drawing.Point(200, 317)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(108, 26)
        Me.Label65.TabIndex = 1075
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label66
        '
        Me.Label66.BackColor = System.Drawing.Color.Transparent
        Me.Label66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label66.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label66.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label66.Location = New System.Drawing.Point(841, 317)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(112, 26)
        Me.Label66.TabIndex = 1088
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label67.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label67.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label67.Location = New System.Drawing.Point(734, 442)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(108, 26)
        Me.Label67.TabIndex = 1161
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label68
        '
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label68.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label68.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label68.Location = New System.Drawing.Point(627, 442)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(108, 26)
        Me.Label68.TabIndex = 1159
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label69
        '
        Me.Label69.BackColor = System.Drawing.Color.Transparent
        Me.Label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label69.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label69.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label69.Location = New System.Drawing.Point(520, 442)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(108, 26)
        Me.Label69.TabIndex = 1157
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label70
        '
        Me.Label70.BackColor = System.Drawing.Color.Transparent
        Me.Label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label70.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label70.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label70.Location = New System.Drawing.Point(414, 442)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(108, 26)
        Me.Label70.TabIndex = 1155
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label71
        '
        Me.Label71.BackColor = System.Drawing.Color.Transparent
        Me.Label71.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label71.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label71.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label71.Location = New System.Drawing.Point(307, 442)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(108, 26)
        Me.Label71.TabIndex = 1153
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label72
        '
        Me.Label72.BackColor = System.Drawing.Color.Transparent
        Me.Label72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label72.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label72.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label72.Location = New System.Drawing.Point(200, 442)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(108, 26)
        Me.Label72.TabIndex = 1151
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label73
        '
        Me.Label73.BackColor = System.Drawing.Color.Transparent
        Me.Label73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label73.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label73.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label73.Location = New System.Drawing.Point(841, 442)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(112, 26)
        Me.Label73.TabIndex = 1164
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label74
        '
        Me.Label74.BackColor = System.Drawing.Color.Transparent
        Me.Label74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label74.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label74.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label74.Location = New System.Drawing.Point(734, 417)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(108, 26)
        Me.Label74.TabIndex = 1147
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label75
        '
        Me.Label75.BackColor = System.Drawing.Color.Transparent
        Me.Label75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label75.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label75.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label75.Location = New System.Drawing.Point(627, 417)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(108, 26)
        Me.Label75.TabIndex = 1145
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label76
        '
        Me.Label76.BackColor = System.Drawing.Color.Transparent
        Me.Label76.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label76.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label76.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label76.Location = New System.Drawing.Point(520, 417)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(108, 26)
        Me.Label76.TabIndex = 1143
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label77
        '
        Me.Label77.BackColor = System.Drawing.Color.Transparent
        Me.Label77.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label77.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label77.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label77.Location = New System.Drawing.Point(414, 417)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(108, 26)
        Me.Label77.TabIndex = 1141
        Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label78
        '
        Me.Label78.BackColor = System.Drawing.Color.Transparent
        Me.Label78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label78.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label78.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label78.Location = New System.Drawing.Point(307, 417)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(108, 26)
        Me.Label78.TabIndex = 1139
        Me.Label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label79
        '
        Me.Label79.BackColor = System.Drawing.Color.Transparent
        Me.Label79.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label79.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label79.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label79.Location = New System.Drawing.Point(200, 417)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(108, 26)
        Me.Label79.TabIndex = 1137
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label80
        '
        Me.Label80.BackColor = System.Drawing.Color.Transparent
        Me.Label80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label80.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label80.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label80.Location = New System.Drawing.Point(841, 417)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(112, 26)
        Me.Label80.TabIndex = 1150
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label81
        '
        Me.Label81.BackColor = System.Drawing.Color.Transparent
        Me.Label81.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label81.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label81.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label81.Location = New System.Drawing.Point(734, 392)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(108, 26)
        Me.Label81.TabIndex = 1133
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label82
        '
        Me.Label82.BackColor = System.Drawing.Color.Transparent
        Me.Label82.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label82.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label82.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label82.Location = New System.Drawing.Point(627, 392)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(108, 26)
        Me.Label82.TabIndex = 1131
        Me.Label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label83
        '
        Me.Label83.BackColor = System.Drawing.Color.Transparent
        Me.Label83.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label83.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label83.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label83.Location = New System.Drawing.Point(520, 392)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(108, 26)
        Me.Label83.TabIndex = 1129
        Me.Label83.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label84
        '
        Me.Label84.BackColor = System.Drawing.Color.Transparent
        Me.Label84.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label84.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label84.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label84.Location = New System.Drawing.Point(414, 392)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(108, 26)
        Me.Label84.TabIndex = 1127
        Me.Label84.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label85
        '
        Me.Label85.BackColor = System.Drawing.Color.Transparent
        Me.Label85.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label85.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label85.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label85.Location = New System.Drawing.Point(307, 392)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(108, 26)
        Me.Label85.TabIndex = 1125
        Me.Label85.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label86
        '
        Me.Label86.BackColor = System.Drawing.Color.Transparent
        Me.Label86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label86.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label86.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label86.Location = New System.Drawing.Point(200, 392)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(108, 26)
        Me.Label86.TabIndex = 1123
        Me.Label86.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label87
        '
        Me.Label87.BackColor = System.Drawing.Color.Transparent
        Me.Label87.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label87.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label87.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label87.Location = New System.Drawing.Point(841, 392)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(112, 26)
        Me.Label87.TabIndex = 1136
        Me.Label87.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label88
        '
        Me.Label88.BackColor = System.Drawing.Color.Transparent
        Me.Label88.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label88.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label88.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label88.Location = New System.Drawing.Point(734, 367)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(108, 26)
        Me.Label88.TabIndex = 1119
        Me.Label88.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label89
        '
        Me.Label89.BackColor = System.Drawing.Color.Transparent
        Me.Label89.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label89.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label89.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label89.Location = New System.Drawing.Point(627, 367)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(108, 26)
        Me.Label89.TabIndex = 1117
        Me.Label89.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label90
        '
        Me.Label90.BackColor = System.Drawing.Color.Transparent
        Me.Label90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label90.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label90.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label90.Location = New System.Drawing.Point(520, 367)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(108, 26)
        Me.Label90.TabIndex = 1115
        Me.Label90.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label91
        '
        Me.Label91.BackColor = System.Drawing.Color.Transparent
        Me.Label91.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label91.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label91.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label91.Location = New System.Drawing.Point(414, 367)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(108, 26)
        Me.Label91.TabIndex = 1113
        Me.Label91.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label92
        '
        Me.Label92.BackColor = System.Drawing.Color.Transparent
        Me.Label92.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label92.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label92.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label92.Location = New System.Drawing.Point(307, 367)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(108, 26)
        Me.Label92.TabIndex = 1111
        Me.Label92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label93
        '
        Me.Label93.BackColor = System.Drawing.Color.Transparent
        Me.Label93.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label93.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label93.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label93.Location = New System.Drawing.Point(200, 367)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(108, 26)
        Me.Label93.TabIndex = 1109
        Me.Label93.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label94
        '
        Me.Label94.BackColor = System.Drawing.Color.Transparent
        Me.Label94.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label94.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label94.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label94.Location = New System.Drawing.Point(841, 367)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(112, 26)
        Me.Label94.TabIndex = 1122
        Me.Label94.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label95
        '
        Me.Label95.BackColor = System.Drawing.Color.Transparent
        Me.Label95.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label95.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label95.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label95.Location = New System.Drawing.Point(734, 342)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(108, 26)
        Me.Label95.TabIndex = 1105
        Me.Label95.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label96
        '
        Me.Label96.BackColor = System.Drawing.Color.Transparent
        Me.Label96.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label96.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label96.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label96.Location = New System.Drawing.Point(627, 342)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(108, 26)
        Me.Label96.TabIndex = 1103
        Me.Label96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label97
        '
        Me.Label97.BackColor = System.Drawing.Color.Transparent
        Me.Label97.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label97.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label97.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label97.Location = New System.Drawing.Point(520, 342)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(108, 26)
        Me.Label97.TabIndex = 1101
        Me.Label97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label98
        '
        Me.Label98.BackColor = System.Drawing.Color.Transparent
        Me.Label98.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label98.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label98.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label98.Location = New System.Drawing.Point(414, 342)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(108, 26)
        Me.Label98.TabIndex = 1099
        Me.Label98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label99
        '
        Me.Label99.BackColor = System.Drawing.Color.Transparent
        Me.Label99.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label99.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label99.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label99.Location = New System.Drawing.Point(307, 342)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(108, 26)
        Me.Label99.TabIndex = 1097
        Me.Label99.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label100
        '
        Me.Label100.BackColor = System.Drawing.Color.Transparent
        Me.Label100.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label100.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label100.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label100.Location = New System.Drawing.Point(200, 342)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(108, 26)
        Me.Label100.TabIndex = 1095
        Me.Label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label101
        '
        Me.Label101.BackColor = System.Drawing.Color.Transparent
        Me.Label101.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label101.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label101.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label101.Location = New System.Drawing.Point(82, 442)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(121, 26)
        Me.Label101.TabIndex = 1094
        Me.Label101.Text = "種鶏（育成鶏）"
        Me.Label101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label102
        '
        Me.Label102.BackColor = System.Drawing.Color.Transparent
        Me.Label102.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label102.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label102.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label102.Location = New System.Drawing.Point(82, 417)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(121, 26)
        Me.Label102.TabIndex = 1093
        Me.Label102.Text = "種鶏（成鶏）"
        Me.Label102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label103
        '
        Me.Label103.BackColor = System.Drawing.Color.Transparent
        Me.Label103.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label103.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label103.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label103.Location = New System.Drawing.Point(82, 392)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(121, 26)
        Me.Label103.TabIndex = 1092
        Me.Label103.Text = "肉用鶏"
        Me.Label103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label104
        '
        Me.Label104.BackColor = System.Drawing.Color.Transparent
        Me.Label104.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label104.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label104.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label104.Location = New System.Drawing.Point(82, 367)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(121, 26)
        Me.Label104.TabIndex = 1091
        Me.Label104.Text = "採卵鶏（育成鶏）"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label105
        '
        Me.Label105.BackColor = System.Drawing.Color.Transparent
        Me.Label105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label105.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label105.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label105.Location = New System.Drawing.Point(82, 342)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(121, 26)
        Me.Label105.TabIndex = 1090
        Me.Label105.Text = "採卵鶏（成鶏）"
        Me.Label105.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label106
        '
        Me.Label106.BackColor = System.Drawing.Color.Transparent
        Me.Label106.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label106.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label106.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label106.Location = New System.Drawing.Point(30, 342)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(54, 126)
        Me.Label106.TabIndex = 1089
        Me.Label106.Text = "企業型"
        Me.Label106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label107
        '
        Me.Label107.BackColor = System.Drawing.Color.Transparent
        Me.Label107.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label107.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label107.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label107.Location = New System.Drawing.Point(841, 342)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(112, 26)
        Me.Label107.TabIndex = 1108
        Me.Label107.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label108
        '
        Me.Label108.BackColor = System.Drawing.Color.Transparent
        Me.Label108.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label108.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label108.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label108.Location = New System.Drawing.Point(30, 467)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(54, 151)
        Me.Label108.TabIndex = 1165
        Me.Label108.Text = "鶏以外"
        Me.Label108.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label109
        '
        Me.Label109.BackColor = System.Drawing.Color.Transparent
        Me.Label109.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label109.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label109.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label109.Location = New System.Drawing.Point(734, 467)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(108, 26)
        Me.Label109.TabIndex = 1177
        Me.Label109.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label110
        '
        Me.Label110.BackColor = System.Drawing.Color.Transparent
        Me.Label110.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label110.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label110.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label110.Location = New System.Drawing.Point(627, 467)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(108, 26)
        Me.Label110.TabIndex = 1175
        Me.Label110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label111
        '
        Me.Label111.BackColor = System.Drawing.Color.Transparent
        Me.Label111.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label111.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label111.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label111.Location = New System.Drawing.Point(520, 467)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(108, 26)
        Me.Label111.TabIndex = 1173
        Me.Label111.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label112
        '
        Me.Label112.BackColor = System.Drawing.Color.Transparent
        Me.Label112.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label112.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label112.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label112.Location = New System.Drawing.Point(414, 467)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(108, 26)
        Me.Label112.TabIndex = 1171
        Me.Label112.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label113
        '
        Me.Label113.BackColor = System.Drawing.Color.Transparent
        Me.Label113.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label113.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label113.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label113.Location = New System.Drawing.Point(307, 467)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(108, 26)
        Me.Label113.TabIndex = 1169
        Me.Label113.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label114
        '
        Me.Label114.BackColor = System.Drawing.Color.Transparent
        Me.Label114.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label114.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label114.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label114.Location = New System.Drawing.Point(200, 467)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(108, 26)
        Me.Label114.TabIndex = 1167
        Me.Label114.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label115
        '
        Me.Label115.BackColor = System.Drawing.Color.Transparent
        Me.Label115.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label115.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label115.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label115.Location = New System.Drawing.Point(841, 467)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(112, 26)
        Me.Label115.TabIndex = 1180
        Me.Label115.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label116
        '
        Me.Label116.BackColor = System.Drawing.Color.Transparent
        Me.Label116.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label116.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label116.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label116.Location = New System.Drawing.Point(82, 467)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(121, 26)
        Me.Label116.TabIndex = 1166
        Me.Label116.Text = "うずら"
        Me.Label116.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label117
        '
        Me.Label117.BackColor = System.Drawing.Color.Transparent
        Me.Label117.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label117.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label117.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label117.Location = New System.Drawing.Point(82, 492)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(121, 26)
        Me.Label117.TabIndex = 1181
        Me.Label117.Text = "あひる"
        Me.Label117.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label118
        '
        Me.Label118.BackColor = System.Drawing.Color.Transparent
        Me.Label118.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label118.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label118.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label118.Location = New System.Drawing.Point(82, 517)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(121, 26)
        Me.Label118.TabIndex = 1182
        Me.Label118.Text = "きじ"
        Me.Label118.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label119
        '
        Me.Label119.BackColor = System.Drawing.Color.Transparent
        Me.Label119.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label119.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label119.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label119.Location = New System.Drawing.Point(82, 542)
        Me.Label119.Name = "Label119"
        Me.Label119.Size = New System.Drawing.Size(121, 26)
        Me.Label119.TabIndex = 1183
        Me.Label119.Text = "ほろほろ鳥"
        Me.Label119.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label120
        '
        Me.Label120.BackColor = System.Drawing.Color.Transparent
        Me.Label120.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label120.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label120.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label120.Location = New System.Drawing.Point(82, 567)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(121, 26)
        Me.Label120.TabIndex = 1184
        Me.Label120.Text = "七面鳥"
        Me.Label120.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label121
        '
        Me.Label121.BackColor = System.Drawing.Color.Transparent
        Me.Label121.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label121.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label121.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label121.Location = New System.Drawing.Point(82, 592)
        Me.Label121.Name = "Label121"
        Me.Label121.Size = New System.Drawing.Size(121, 26)
        Me.Label121.TabIndex = 1185
        Me.Label121.Text = "だちょう"
        Me.Label121.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label122
        '
        Me.Label122.BackColor = System.Drawing.Color.Transparent
        Me.Label122.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label122.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label122.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label122.Location = New System.Drawing.Point(734, 492)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(108, 26)
        Me.Label122.TabIndex = 1198
        Me.Label122.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label123
        '
        Me.Label123.BackColor = System.Drawing.Color.Transparent
        Me.Label123.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label123.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label123.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label123.Location = New System.Drawing.Point(627, 492)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(108, 26)
        Me.Label123.TabIndex = 1197
        Me.Label123.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label124
        '
        Me.Label124.BackColor = System.Drawing.Color.Transparent
        Me.Label124.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label124.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label124.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label124.Location = New System.Drawing.Point(520, 492)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(108, 26)
        Me.Label124.TabIndex = 1196
        Me.Label124.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label125
        '
        Me.Label125.BackColor = System.Drawing.Color.Transparent
        Me.Label125.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label125.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label125.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label125.Location = New System.Drawing.Point(414, 492)
        Me.Label125.Name = "Label125"
        Me.Label125.Size = New System.Drawing.Size(108, 26)
        Me.Label125.TabIndex = 1195
        Me.Label125.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label126
        '
        Me.Label126.BackColor = System.Drawing.Color.Transparent
        Me.Label126.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label126.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label126.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label126.Location = New System.Drawing.Point(307, 492)
        Me.Label126.Name = "Label126"
        Me.Label126.Size = New System.Drawing.Size(108, 26)
        Me.Label126.TabIndex = 1194
        Me.Label126.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label127
        '
        Me.Label127.BackColor = System.Drawing.Color.Transparent
        Me.Label127.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label127.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label127.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label127.Location = New System.Drawing.Point(200, 492)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(108, 26)
        Me.Label127.TabIndex = 1193
        Me.Label127.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label128
        '
        Me.Label128.BackColor = System.Drawing.Color.Transparent
        Me.Label128.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label128.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label128.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label128.Location = New System.Drawing.Point(841, 492)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(112, 26)
        Me.Label128.TabIndex = 1199
        Me.Label128.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label129
        '
        Me.Label129.BackColor = System.Drawing.Color.Transparent
        Me.Label129.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label129.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label129.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label129.Location = New System.Drawing.Point(734, 517)
        Me.Label129.Name = "Label129"
        Me.Label129.Size = New System.Drawing.Size(108, 26)
        Me.Label129.TabIndex = 1212
        Me.Label129.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label130
        '
        Me.Label130.BackColor = System.Drawing.Color.Transparent
        Me.Label130.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label130.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label130.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label130.Location = New System.Drawing.Point(627, 517)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(108, 26)
        Me.Label130.TabIndex = 1211
        Me.Label130.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label131
        '
        Me.Label131.BackColor = System.Drawing.Color.Transparent
        Me.Label131.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label131.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label131.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label131.Location = New System.Drawing.Point(520, 517)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(108, 26)
        Me.Label131.TabIndex = 1210
        Me.Label131.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label132
        '
        Me.Label132.BackColor = System.Drawing.Color.Transparent
        Me.Label132.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label132.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label132.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label132.Location = New System.Drawing.Point(414, 517)
        Me.Label132.Name = "Label132"
        Me.Label132.Size = New System.Drawing.Size(108, 26)
        Me.Label132.TabIndex = 1209
        Me.Label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label133
        '
        Me.Label133.BackColor = System.Drawing.Color.Transparent
        Me.Label133.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label133.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label133.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label133.Location = New System.Drawing.Point(307, 517)
        Me.Label133.Name = "Label133"
        Me.Label133.Size = New System.Drawing.Size(108, 26)
        Me.Label133.TabIndex = 1208
        Me.Label133.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label134
        '
        Me.Label134.BackColor = System.Drawing.Color.Transparent
        Me.Label134.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label134.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label134.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label134.Location = New System.Drawing.Point(200, 517)
        Me.Label134.Name = "Label134"
        Me.Label134.Size = New System.Drawing.Size(108, 26)
        Me.Label134.TabIndex = 1207
        Me.Label134.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label135
        '
        Me.Label135.BackColor = System.Drawing.Color.Transparent
        Me.Label135.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label135.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label135.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label135.Location = New System.Drawing.Point(841, 517)
        Me.Label135.Name = "Label135"
        Me.Label135.Size = New System.Drawing.Size(112, 26)
        Me.Label135.TabIndex = 1213
        Me.Label135.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label136
        '
        Me.Label136.BackColor = System.Drawing.Color.Transparent
        Me.Label136.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label136.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label136.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label136.Location = New System.Drawing.Point(734, 542)
        Me.Label136.Name = "Label136"
        Me.Label136.Size = New System.Drawing.Size(108, 26)
        Me.Label136.TabIndex = 1226
        Me.Label136.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label137
        '
        Me.Label137.BackColor = System.Drawing.Color.Transparent
        Me.Label137.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label137.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label137.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label137.Location = New System.Drawing.Point(627, 542)
        Me.Label137.Name = "Label137"
        Me.Label137.Size = New System.Drawing.Size(108, 26)
        Me.Label137.TabIndex = 1225
        Me.Label137.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label138
        '
        Me.Label138.BackColor = System.Drawing.Color.Transparent
        Me.Label138.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label138.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label138.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label138.Location = New System.Drawing.Point(520, 542)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(108, 26)
        Me.Label138.TabIndex = 1224
        Me.Label138.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label139
        '
        Me.Label139.BackColor = System.Drawing.Color.Transparent
        Me.Label139.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label139.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label139.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label139.Location = New System.Drawing.Point(414, 542)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(108, 26)
        Me.Label139.TabIndex = 1223
        Me.Label139.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label140
        '
        Me.Label140.BackColor = System.Drawing.Color.Transparent
        Me.Label140.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label140.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label140.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label140.Location = New System.Drawing.Point(307, 542)
        Me.Label140.Name = "Label140"
        Me.Label140.Size = New System.Drawing.Size(108, 26)
        Me.Label140.TabIndex = 1222
        Me.Label140.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label141
        '
        Me.Label141.BackColor = System.Drawing.Color.Transparent
        Me.Label141.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label141.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label141.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label141.Location = New System.Drawing.Point(200, 542)
        Me.Label141.Name = "Label141"
        Me.Label141.Size = New System.Drawing.Size(108, 26)
        Me.Label141.TabIndex = 1221
        Me.Label141.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label142
        '
        Me.Label142.BackColor = System.Drawing.Color.Transparent
        Me.Label142.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label142.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label142.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label142.Location = New System.Drawing.Point(841, 542)
        Me.Label142.Name = "Label142"
        Me.Label142.Size = New System.Drawing.Size(112, 26)
        Me.Label142.TabIndex = 1227
        Me.Label142.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label143
        '
        Me.Label143.BackColor = System.Drawing.Color.Transparent
        Me.Label143.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label143.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label143.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label143.Location = New System.Drawing.Point(734, 567)
        Me.Label143.Name = "Label143"
        Me.Label143.Size = New System.Drawing.Size(108, 26)
        Me.Label143.TabIndex = 1240
        Me.Label143.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label144
        '
        Me.Label144.BackColor = System.Drawing.Color.Transparent
        Me.Label144.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label144.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label144.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label144.Location = New System.Drawing.Point(627, 567)
        Me.Label144.Name = "Label144"
        Me.Label144.Size = New System.Drawing.Size(108, 26)
        Me.Label144.TabIndex = 1239
        Me.Label144.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label145
        '
        Me.Label145.BackColor = System.Drawing.Color.Transparent
        Me.Label145.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label145.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label145.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label145.Location = New System.Drawing.Point(520, 567)
        Me.Label145.Name = "Label145"
        Me.Label145.Size = New System.Drawing.Size(108, 26)
        Me.Label145.TabIndex = 1238
        Me.Label145.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label146
        '
        Me.Label146.BackColor = System.Drawing.Color.Transparent
        Me.Label146.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label146.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label146.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label146.Location = New System.Drawing.Point(414, 567)
        Me.Label146.Name = "Label146"
        Me.Label146.Size = New System.Drawing.Size(108, 26)
        Me.Label146.TabIndex = 1237
        Me.Label146.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label147
        '
        Me.Label147.BackColor = System.Drawing.Color.Transparent
        Me.Label147.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label147.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label147.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label147.Location = New System.Drawing.Point(307, 567)
        Me.Label147.Name = "Label147"
        Me.Label147.Size = New System.Drawing.Size(108, 26)
        Me.Label147.TabIndex = 1236
        Me.Label147.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label148
        '
        Me.Label148.BackColor = System.Drawing.Color.Transparent
        Me.Label148.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label148.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label148.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label148.Location = New System.Drawing.Point(200, 567)
        Me.Label148.Name = "Label148"
        Me.Label148.Size = New System.Drawing.Size(108, 26)
        Me.Label148.TabIndex = 1235
        Me.Label148.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label149
        '
        Me.Label149.BackColor = System.Drawing.Color.Transparent
        Me.Label149.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label149.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label149.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label149.Location = New System.Drawing.Point(841, 567)
        Me.Label149.Name = "Label149"
        Me.Label149.Size = New System.Drawing.Size(112, 26)
        Me.Label149.TabIndex = 1241
        Me.Label149.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label150
        '
        Me.Label150.BackColor = System.Drawing.Color.Transparent
        Me.Label150.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label150.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label150.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label150.Location = New System.Drawing.Point(734, 592)
        Me.Label150.Name = "Label150"
        Me.Label150.Size = New System.Drawing.Size(108, 26)
        Me.Label150.TabIndex = 1254
        Me.Label150.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label151
        '
        Me.Label151.BackColor = System.Drawing.Color.Transparent
        Me.Label151.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label151.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label151.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label151.Location = New System.Drawing.Point(627, 592)
        Me.Label151.Name = "Label151"
        Me.Label151.Size = New System.Drawing.Size(108, 26)
        Me.Label151.TabIndex = 1253
        Me.Label151.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label152
        '
        Me.Label152.BackColor = System.Drawing.Color.Transparent
        Me.Label152.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label152.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label152.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label152.Location = New System.Drawing.Point(520, 592)
        Me.Label152.Name = "Label152"
        Me.Label152.Size = New System.Drawing.Size(108, 26)
        Me.Label152.TabIndex = 1252
        Me.Label152.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label153
        '
        Me.Label153.BackColor = System.Drawing.Color.Transparent
        Me.Label153.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label153.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label153.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label153.Location = New System.Drawing.Point(414, 592)
        Me.Label153.Name = "Label153"
        Me.Label153.Size = New System.Drawing.Size(108, 26)
        Me.Label153.TabIndex = 1251
        Me.Label153.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label154
        '
        Me.Label154.BackColor = System.Drawing.Color.Transparent
        Me.Label154.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label154.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label154.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label154.Location = New System.Drawing.Point(307, 592)
        Me.Label154.Name = "Label154"
        Me.Label154.Size = New System.Drawing.Size(108, 26)
        Me.Label154.TabIndex = 1250
        Me.Label154.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label155
        '
        Me.Label155.BackColor = System.Drawing.Color.Transparent
        Me.Label155.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label155.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label155.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label155.Location = New System.Drawing.Point(200, 592)
        Me.Label155.Name = "Label155"
        Me.Label155.Size = New System.Drawing.Size(108, 26)
        Me.Label155.TabIndex = 1249
        Me.Label155.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label156
        '
        Me.Label156.BackColor = System.Drawing.Color.Transparent
        Me.Label156.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label156.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label156.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label156.Location = New System.Drawing.Point(841, 592)
        Me.Label156.Name = "Label156"
        Me.Label156.Size = New System.Drawing.Size(112, 26)
        Me.Label156.TabIndex = 1255
        Me.Label156.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmGJ8080
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.numKUSYA41)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU41)
        Me.Controls.Add(Me.Label150)
        Me.Controls.Add(Me.numGENKA_JOGEN41)
        Me.Controls.Add(Me.Label151)
        Me.Controls.Add(Me.numJIDAI_JIDAI41)
        Me.Controls.Add(Me.Label152)
        Me.Controls.Add(Me.numJIDAI_JOGEN41)
        Me.Controls.Add(Me.Label153)
        Me.Controls.Add(Me.numKOYO_KOYO41)
        Me.Controls.Add(Me.Label154)
        Me.Controls.Add(Me.numKOYO_JOGEN41)
        Me.Controls.Add(Me.Label155)
        Me.Controls.Add(Me.Label156)
        Me.Controls.Add(Me.numKUSYA40)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU40)
        Me.Controls.Add(Me.Label143)
        Me.Controls.Add(Me.numGENKA_JOGEN40)
        Me.Controls.Add(Me.Label144)
        Me.Controls.Add(Me.numJIDAI_JIDAI40)
        Me.Controls.Add(Me.Label145)
        Me.Controls.Add(Me.numJIDAI_JOGEN40)
        Me.Controls.Add(Me.Label146)
        Me.Controls.Add(Me.numKOYO_KOYO40)
        Me.Controls.Add(Me.Label147)
        Me.Controls.Add(Me.numKOYO_JOGEN40)
        Me.Controls.Add(Me.Label148)
        Me.Controls.Add(Me.Label149)
        Me.Controls.Add(Me.numKUSYA39)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU39)
        Me.Controls.Add(Me.Label136)
        Me.Controls.Add(Me.numGENKA_JOGEN39)
        Me.Controls.Add(Me.Label137)
        Me.Controls.Add(Me.numJIDAI_JIDAI39)
        Me.Controls.Add(Me.Label138)
        Me.Controls.Add(Me.numJIDAI_JOGEN39)
        Me.Controls.Add(Me.Label139)
        Me.Controls.Add(Me.numKOYO_KOYO39)
        Me.Controls.Add(Me.Label140)
        Me.Controls.Add(Me.numKOYO_JOGEN39)
        Me.Controls.Add(Me.Label141)
        Me.Controls.Add(Me.Label142)
        Me.Controls.Add(Me.numKUSYA38)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU38)
        Me.Controls.Add(Me.Label129)
        Me.Controls.Add(Me.numGENKA_JOGEN38)
        Me.Controls.Add(Me.Label130)
        Me.Controls.Add(Me.numJIDAI_JIDAI38)
        Me.Controls.Add(Me.Label131)
        Me.Controls.Add(Me.numJIDAI_JOGEN38)
        Me.Controls.Add(Me.Label132)
        Me.Controls.Add(Me.numKOYO_KOYO38)
        Me.Controls.Add(Me.Label133)
        Me.Controls.Add(Me.numKOYO_JOGEN38)
        Me.Controls.Add(Me.Label134)
        Me.Controls.Add(Me.Label135)
        Me.Controls.Add(Me.numKUSYA37)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU37)
        Me.Controls.Add(Me.Label122)
        Me.Controls.Add(Me.numGENKA_JOGEN37)
        Me.Controls.Add(Me.Label123)
        Me.Controls.Add(Me.numJIDAI_JIDAI37)
        Me.Controls.Add(Me.Label124)
        Me.Controls.Add(Me.numJIDAI_JOGEN37)
        Me.Controls.Add(Me.Label125)
        Me.Controls.Add(Me.numKOYO_KOYO37)
        Me.Controls.Add(Me.Label126)
        Me.Controls.Add(Me.numKOYO_JOGEN37)
        Me.Controls.Add(Me.Label127)
        Me.Controls.Add(Me.Label128)
        Me.Controls.Add(Me.Label121)
        Me.Controls.Add(Me.Label120)
        Me.Controls.Add(Me.Label119)
        Me.Controls.Add(Me.Label118)
        Me.Controls.Add(Me.Label117)
        Me.Controls.Add(Me.numKUSYA36)
        Me.Controls.Add(Me.numKUSYA25)
        Me.Controls.Add(Me.numKUSYA24)
        Me.Controls.Add(Me.numKUSYA23)
        Me.Controls.Add(Me.numKUSYA22)
        Me.Controls.Add(Me.numKUSYA21)
        Me.Controls.Add(Me.numKUSYA15)
        Me.Controls.Add(Me.numKUSYA14)
        Me.Controls.Add(Me.numKUSYA13)
        Me.Controls.Add(Me.numKUSYA12)
        Me.Controls.Add(Me.numKUSYA11)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU36)
        Me.Controls.Add(Me.Label109)
        Me.Controls.Add(Me.numGENKA_JOGEN36)
        Me.Controls.Add(Me.Label110)
        Me.Controls.Add(Me.numJIDAI_JIDAI36)
        Me.Controls.Add(Me.Label111)
        Me.Controls.Add(Me.numJIDAI_JOGEN36)
        Me.Controls.Add(Me.Label112)
        Me.Controls.Add(Me.numKOYO_KOYO36)
        Me.Controls.Add(Me.Label113)
        Me.Controls.Add(Me.numKOYO_JOGEN36)
        Me.Controls.Add(Me.Label114)
        Me.Controls.Add(Me.Label115)
        Me.Controls.Add(Me.Label116)
        Me.Controls.Add(Me.Label108)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU25)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.numGENKA_JOGEN25)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.numJIDAI_JIDAI25)
        Me.Controls.Add(Me.Label69)
        Me.Controls.Add(Me.numJIDAI_JOGEN25)
        Me.Controls.Add(Me.Label70)
        Me.Controls.Add(Me.numKOYO_KOYO25)
        Me.Controls.Add(Me.Label71)
        Me.Controls.Add(Me.numKOYO_JOGEN25)
        Me.Controls.Add(Me.Label72)
        Me.Controls.Add(Me.Label73)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU24)
        Me.Controls.Add(Me.Label74)
        Me.Controls.Add(Me.numGENKA_JOGEN24)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.numJIDAI_JIDAI24)
        Me.Controls.Add(Me.Label76)
        Me.Controls.Add(Me.numJIDAI_JOGEN24)
        Me.Controls.Add(Me.Label77)
        Me.Controls.Add(Me.numKOYO_KOYO24)
        Me.Controls.Add(Me.Label78)
        Me.Controls.Add(Me.numKOYO_JOGEN24)
        Me.Controls.Add(Me.Label79)
        Me.Controls.Add(Me.Label80)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU23)
        Me.Controls.Add(Me.Label81)
        Me.Controls.Add(Me.numGENKA_JOGEN23)
        Me.Controls.Add(Me.Label82)
        Me.Controls.Add(Me.numJIDAI_JIDAI23)
        Me.Controls.Add(Me.Label83)
        Me.Controls.Add(Me.numJIDAI_JOGEN23)
        Me.Controls.Add(Me.Label84)
        Me.Controls.Add(Me.numKOYO_KOYO23)
        Me.Controls.Add(Me.Label85)
        Me.Controls.Add(Me.numKOYO_JOGEN23)
        Me.Controls.Add(Me.Label86)
        Me.Controls.Add(Me.Label87)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU22)
        Me.Controls.Add(Me.Label88)
        Me.Controls.Add(Me.numGENKA_JOGEN22)
        Me.Controls.Add(Me.Label89)
        Me.Controls.Add(Me.numJIDAI_JIDAI22)
        Me.Controls.Add(Me.Label90)
        Me.Controls.Add(Me.numJIDAI_JOGEN22)
        Me.Controls.Add(Me.Label91)
        Me.Controls.Add(Me.numKOYO_KOYO22)
        Me.Controls.Add(Me.Label92)
        Me.Controls.Add(Me.numKOYO_JOGEN22)
        Me.Controls.Add(Me.Label93)
        Me.Controls.Add(Me.Label94)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU21)
        Me.Controls.Add(Me.Label95)
        Me.Controls.Add(Me.numGENKA_JOGEN21)
        Me.Controls.Add(Me.Label96)
        Me.Controls.Add(Me.numJIDAI_JIDAI21)
        Me.Controls.Add(Me.Label97)
        Me.Controls.Add(Me.numJIDAI_JOGEN21)
        Me.Controls.Add(Me.Label98)
        Me.Controls.Add(Me.numKOYO_KOYO21)
        Me.Controls.Add(Me.Label99)
        Me.Controls.Add(Me.numKOYO_JOGEN21)
        Me.Controls.Add(Me.Label100)
        Me.Controls.Add(Me.Label101)
        Me.Controls.Add(Me.Label102)
        Me.Controls.Add(Me.Label103)
        Me.Controls.Add(Me.Label104)
        Me.Controls.Add(Me.Label105)
        Me.Controls.Add(Me.Label106)
        Me.Controls.Add(Me.Label107)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU15)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.numGENKA_JOGEN15)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.numJIDAI_JIDAI15)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.numJIDAI_JOGEN15)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.numKOYO_KOYO15)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.numKOYO_JOGEN15)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU14)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.numGENKA_JOGEN14)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.numJIDAI_JIDAI14)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.numJIDAI_JOGEN14)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.numKOYO_KOYO14)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.numKOYO_JOGEN14)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU13)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.numGENKA_JOGEN13)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.numJIDAI_JIDAI13)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.numJIDAI_JOGEN13)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.numKOYO_KOYO13)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.numKOYO_JOGEN13)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.numGENKA_JOGEN12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.numJIDAI_JIDAI12)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.numJIDAI_JOGEN12)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.numKOYO_KOYO12)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.numKOYO_JOGEN12)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.numGENKA_SYOKYAKU11)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.numGENKA_JOGEN11)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.numJIDAI_JIDAI11)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.numJIDAI_JOGEN11)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.numKOYO_KOYO11)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.numKOYO_JOGEN11)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dateTAISYO_NENDO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.numKI)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label45)
        Me.Name = "frmGJ8080"
        Me.Text = "(GJ8080)互助金交付単価算定基礎指数マスタメンテナンス"
        Me.Controls.SetChildIndex(Me.Label45, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.numKI, 0)
        Me.Controls.SetChildIndex(Me.cmdSearch, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dateTAISYO_NENDO, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.Label31, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN11, 0)
        Me.Controls.SetChildIndex(Me.Label34, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO11, 0)
        Me.Controls.SetChildIndex(Me.Label38, 0)
        Me.Controls.SetChildIndex(Me.Label37, 0)
        Me.Controls.SetChildIndex(Me.Label36, 0)
        Me.Controls.SetChildIndex(Me.Label32, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN11, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI11, 0)
        Me.Controls.SetChildIndex(Me.Label40, 0)
        Me.Controls.SetChildIndex(Me.Label39, 0)
        Me.Controls.SetChildIndex(Me.Label33, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN11, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU11, 0)
        Me.Controls.SetChildIndex(Me.Label43, 0)
        Me.Controls.SetChildIndex(Me.Label44, 0)
        Me.Controls.SetChildIndex(Me.Label46, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN12, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO12, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN12, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI12, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN12, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU12, 0)
        Me.Controls.SetChildIndex(Me.Label52, 0)
        Me.Controls.SetChildIndex(Me.Label51, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN13, 0)
        Me.Controls.SetChildIndex(Me.Label50, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO13, 0)
        Me.Controls.SetChildIndex(Me.Label49, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN13, 0)
        Me.Controls.SetChildIndex(Me.Label48, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI13, 0)
        Me.Controls.SetChildIndex(Me.Label47, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN13, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU13, 0)
        Me.Controls.SetChildIndex(Me.Label59, 0)
        Me.Controls.SetChildIndex(Me.Label58, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN14, 0)
        Me.Controls.SetChildIndex(Me.Label57, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO14, 0)
        Me.Controls.SetChildIndex(Me.Label56, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN14, 0)
        Me.Controls.SetChildIndex(Me.Label55, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI14, 0)
        Me.Controls.SetChildIndex(Me.Label54, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN14, 0)
        Me.Controls.SetChildIndex(Me.Label53, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU14, 0)
        Me.Controls.SetChildIndex(Me.Label66, 0)
        Me.Controls.SetChildIndex(Me.Label65, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN15, 0)
        Me.Controls.SetChildIndex(Me.Label64, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO15, 0)
        Me.Controls.SetChildIndex(Me.Label63, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN15, 0)
        Me.Controls.SetChildIndex(Me.Label62, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI15, 0)
        Me.Controls.SetChildIndex(Me.Label61, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN15, 0)
        Me.Controls.SetChildIndex(Me.Label60, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU15, 0)
        Me.Controls.SetChildIndex(Me.Label107, 0)
        Me.Controls.SetChildIndex(Me.Label106, 0)
        Me.Controls.SetChildIndex(Me.Label105, 0)
        Me.Controls.SetChildIndex(Me.Label104, 0)
        Me.Controls.SetChildIndex(Me.Label103, 0)
        Me.Controls.SetChildIndex(Me.Label102, 0)
        Me.Controls.SetChildIndex(Me.Label101, 0)
        Me.Controls.SetChildIndex(Me.Label100, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN21, 0)
        Me.Controls.SetChildIndex(Me.Label99, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO21, 0)
        Me.Controls.SetChildIndex(Me.Label98, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN21, 0)
        Me.Controls.SetChildIndex(Me.Label97, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI21, 0)
        Me.Controls.SetChildIndex(Me.Label96, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN21, 0)
        Me.Controls.SetChildIndex(Me.Label95, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU21, 0)
        Me.Controls.SetChildIndex(Me.Label94, 0)
        Me.Controls.SetChildIndex(Me.Label93, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN22, 0)
        Me.Controls.SetChildIndex(Me.Label92, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO22, 0)
        Me.Controls.SetChildIndex(Me.Label91, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN22, 0)
        Me.Controls.SetChildIndex(Me.Label90, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI22, 0)
        Me.Controls.SetChildIndex(Me.Label89, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN22, 0)
        Me.Controls.SetChildIndex(Me.Label88, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU22, 0)
        Me.Controls.SetChildIndex(Me.Label87, 0)
        Me.Controls.SetChildIndex(Me.Label86, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN23, 0)
        Me.Controls.SetChildIndex(Me.Label85, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO23, 0)
        Me.Controls.SetChildIndex(Me.Label84, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN23, 0)
        Me.Controls.SetChildIndex(Me.Label83, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI23, 0)
        Me.Controls.SetChildIndex(Me.Label82, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN23, 0)
        Me.Controls.SetChildIndex(Me.Label81, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU23, 0)
        Me.Controls.SetChildIndex(Me.Label80, 0)
        Me.Controls.SetChildIndex(Me.Label79, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN24, 0)
        Me.Controls.SetChildIndex(Me.Label78, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO24, 0)
        Me.Controls.SetChildIndex(Me.Label77, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN24, 0)
        Me.Controls.SetChildIndex(Me.Label76, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI24, 0)
        Me.Controls.SetChildIndex(Me.Label75, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN24, 0)
        Me.Controls.SetChildIndex(Me.Label74, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU24, 0)
        Me.Controls.SetChildIndex(Me.Label73, 0)
        Me.Controls.SetChildIndex(Me.Label72, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN25, 0)
        Me.Controls.SetChildIndex(Me.Label71, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO25, 0)
        Me.Controls.SetChildIndex(Me.Label70, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN25, 0)
        Me.Controls.SetChildIndex(Me.Label69, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI25, 0)
        Me.Controls.SetChildIndex(Me.Label68, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN25, 0)
        Me.Controls.SetChildIndex(Me.Label67, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU25, 0)
        Me.Controls.SetChildIndex(Me.Label108, 0)
        Me.Controls.SetChildIndex(Me.Label116, 0)
        Me.Controls.SetChildIndex(Me.Label115, 0)
        Me.Controls.SetChildIndex(Me.Label114, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN36, 0)
        Me.Controls.SetChildIndex(Me.Label113, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO36, 0)
        Me.Controls.SetChildIndex(Me.Label112, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN36, 0)
        Me.Controls.SetChildIndex(Me.Label111, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI36, 0)
        Me.Controls.SetChildIndex(Me.Label110, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN36, 0)
        Me.Controls.SetChildIndex(Me.Label109, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU36, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA11, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA12, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA13, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA14, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA15, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA21, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA22, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA23, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA24, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA25, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA36, 0)
        Me.Controls.SetChildIndex(Me.Label117, 0)
        Me.Controls.SetChildIndex(Me.Label118, 0)
        Me.Controls.SetChildIndex(Me.Label119, 0)
        Me.Controls.SetChildIndex(Me.Label120, 0)
        Me.Controls.SetChildIndex(Me.Label121, 0)
        Me.Controls.SetChildIndex(Me.Label128, 0)
        Me.Controls.SetChildIndex(Me.Label127, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN37, 0)
        Me.Controls.SetChildIndex(Me.Label126, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO37, 0)
        Me.Controls.SetChildIndex(Me.Label125, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN37, 0)
        Me.Controls.SetChildIndex(Me.Label124, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI37, 0)
        Me.Controls.SetChildIndex(Me.Label123, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN37, 0)
        Me.Controls.SetChildIndex(Me.Label122, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU37, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA37, 0)
        Me.Controls.SetChildIndex(Me.Label135, 0)
        Me.Controls.SetChildIndex(Me.Label134, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN38, 0)
        Me.Controls.SetChildIndex(Me.Label133, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO38, 0)
        Me.Controls.SetChildIndex(Me.Label132, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN38, 0)
        Me.Controls.SetChildIndex(Me.Label131, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI38, 0)
        Me.Controls.SetChildIndex(Me.Label130, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN38, 0)
        Me.Controls.SetChildIndex(Me.Label129, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU38, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA38, 0)
        Me.Controls.SetChildIndex(Me.Label142, 0)
        Me.Controls.SetChildIndex(Me.Label141, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN39, 0)
        Me.Controls.SetChildIndex(Me.Label140, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO39, 0)
        Me.Controls.SetChildIndex(Me.Label139, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN39, 0)
        Me.Controls.SetChildIndex(Me.Label138, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI39, 0)
        Me.Controls.SetChildIndex(Me.Label137, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN39, 0)
        Me.Controls.SetChildIndex(Me.Label136, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU39, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA39, 0)
        Me.Controls.SetChildIndex(Me.Label149, 0)
        Me.Controls.SetChildIndex(Me.Label148, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN40, 0)
        Me.Controls.SetChildIndex(Me.Label147, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO40, 0)
        Me.Controls.SetChildIndex(Me.Label146, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN40, 0)
        Me.Controls.SetChildIndex(Me.Label145, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI40, 0)
        Me.Controls.SetChildIndex(Me.Label144, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN40, 0)
        Me.Controls.SetChildIndex(Me.Label143, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU40, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA40, 0)
        Me.Controls.SetChildIndex(Me.Label156, 0)
        Me.Controls.SetChildIndex(Me.Label155, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_JOGEN41, 0)
        Me.Controls.SetChildIndex(Me.Label154, 0)
        Me.Controls.SetChildIndex(Me.numKOYO_KOYO41, 0)
        Me.Controls.SetChildIndex(Me.Label153, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JOGEN41, 0)
        Me.Controls.SetChildIndex(Me.Label152, 0)
        Me.Controls.SetChildIndex(Me.numJIDAI_JIDAI41, 0)
        Me.Controls.SetChildIndex(Me.Label151, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_JOGEN41, 0)
        Me.Controls.SetChildIndex(Me.Label150, 0)
        Me.Controls.SetChildIndex(Me.numGENKA_SYOKYAKU41, 0)
        Me.Controls.SetChildIndex(Me.numKUSYA41, 0)
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.Label29, 0)
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.Label35, 0)
        Me.Controls.SetChildIndex(Me.Label42, 0)
        Me.Controls.SetChildIndex(Me.Label41, 0)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.numKI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dateTAISYO_NENDO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKUSYA41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_SYOKYAKU41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGENKA_JOGEN41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JIDAI41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJIDAI_JOGEN41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_KOYO41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numKOYO_JOGEN41, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As JBD.Gjs.Win.Label
    Friend WithEvents Label6 As JBD.Gjs.Win.Label
    Friend WithEvents numKI As JBD.Gjs.Win.GcNumber
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents cmdSearch As JBD.Gjs.Win.JButton
    Friend WithEvents cmdCancel As JBD.Gjs.Win.JButton
    Friend WithEvents cmdDelete As JBD.Gjs.Win.JButton
    Friend WithEvents cmdSave As JBD.Gjs.Win.JButton
    Friend WithEvents DropDownButton4 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents GcDateValidator1 As GrapeCity.Win.Editors.GcDateValidator
    Friend WithEvents GcNumberValidator1 As GrapeCity.Win.Editors.GcNumberValidator
    Friend WithEvents Label2 As JBD.Gjs.Win.Label
    Friend WithEvents Label3 As JBD.Gjs.Win.Label
    Friend WithEvents DropDownButton11 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton2 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents DropDownButton3 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents dateTAISYO_NENDO As JBD.Gjs.Win.GcDate
    Friend WithEvents DropDownButton1 As GrapeCity.Win.Editors.DropDownButton
    Friend WithEvents Label4 As JBD.Gjs.Win.Label
    Friend WithEvents rdoARI As JBD.Gjs.Win.RadioButton
    Friend WithEvents GroupBox1 As JBD.Gjs.Win.GroupBox
    Friend WithEvents rdoNASI As JBD.Gjs.Win.RadioButton
    Friend WithEvents Label7 As JBD.Gjs.Win.Label
    Friend WithEvents Label8 As JBD.Gjs.Win.Label
    Friend WithEvents Label9 As JBD.Gjs.Win.Label
    Friend WithEvents Label10 As JBD.Gjs.Win.Label
    Friend WithEvents Label11 As JBD.Gjs.Win.Label
    Friend WithEvents Label15 As JBD.Gjs.Win.Label
    Friend WithEvents Label12 As JBD.Gjs.Win.Label
    Friend WithEvents Label16 As JBD.Gjs.Win.Label
    Friend WithEvents Label17 As JBD.Gjs.Win.Label
    Friend WithEvents Label18 As JBD.Gjs.Win.Label
    Friend WithEvents Label25 As JBD.Gjs.Win.Label
    Friend WithEvents Label26 As JBD.Gjs.Win.Label
    Friend WithEvents Label29 As JBD.Gjs.Win.Label
    Friend WithEvents Label30 As JBD.Gjs.Win.Label
    Friend WithEvents Label31 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN11 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numKOYO_KOYO11 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label34 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI11 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label27 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN11 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label32 As JBD.Gjs.Win.Label
    Friend WithEvents Label35 As JBD.Gjs.Win.Label
    Friend WithEvents Label36 As JBD.Gjs.Win.Label
    Friend WithEvents Label37 As JBD.Gjs.Win.Label
    Friend WithEvents Label38 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_SYOKYAKU11 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label28 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN11 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label33 As JBD.Gjs.Win.Label
    Friend WithEvents Label39 As JBD.Gjs.Win.Label
    Friend WithEvents Label40 As JBD.Gjs.Win.Label
    Friend WithEvents Label41 As JBD.Gjs.Win.Label
    Friend WithEvents Label42 As JBD.Gjs.Win.Label
    Friend WithEvents Label43 As JBD.Gjs.Win.Label
    Friend WithEvents Label44 As JBD.Gjs.Win.Label
    Friend WithEvents Label45 As JBD.Gjs.Win.Label
    Friend WithEvents Label46 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_SYOKYAKU12 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label13 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN12 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label14 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI12 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label19 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN12 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label20 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO12 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label21 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN12 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label22 As JBD.Gjs.Win.Label
    Friend WithEvents Label23 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_SYOKYAKU13 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label24 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN13 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label47 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI13 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label48 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN13 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label49 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO13 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label50 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN13 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label51 As JBD.Gjs.Win.Label
    Friend WithEvents Label52 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_SYOKYAKU14 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label53 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN14 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label54 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI14 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label55 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN14 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label56 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO14 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label57 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN14 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label58 As JBD.Gjs.Win.Label
    Friend WithEvents Label59 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_SYOKYAKU15 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label60 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN15 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label61 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI15 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label62 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN15 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label63 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO15 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label64 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN15 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label65 As JBD.Gjs.Win.Label
    Friend WithEvents Label66 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_SYOKYAKU25 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label67 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN25 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label68 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI25 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label69 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN25 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label70 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO25 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label71 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN25 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label72 As JBD.Gjs.Win.Label
    Friend WithEvents Label73 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_SYOKYAKU24 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label74 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN24 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label75 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI24 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label76 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN24 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label77 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO24 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label78 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN24 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label79 As JBD.Gjs.Win.Label
    Friend WithEvents Label80 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_SYOKYAKU23 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label81 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN23 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label82 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI23 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label83 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN23 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label84 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO23 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label85 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN23 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label86 As JBD.Gjs.Win.Label
    Friend WithEvents Label87 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_SYOKYAKU22 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label88 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN22 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label89 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI22 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label90 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN22 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label91 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO22 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label92 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN22 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label93 As JBD.Gjs.Win.Label
    Friend WithEvents Label94 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_SYOKYAKU21 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label95 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN21 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label96 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI21 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label97 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN21 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label98 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO21 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label99 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN21 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label100 As JBD.Gjs.Win.Label
    Friend WithEvents Label101 As JBD.Gjs.Win.Label
    Friend WithEvents Label102 As JBD.Gjs.Win.Label
    Friend WithEvents Label103 As JBD.Gjs.Win.Label
    Friend WithEvents Label104 As JBD.Gjs.Win.Label
    Friend WithEvents Label105 As JBD.Gjs.Win.Label
    Friend WithEvents Label106 As JBD.Gjs.Win.Label
    Friend WithEvents Label107 As JBD.Gjs.Win.Label
    Friend WithEvents Label108 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_SYOKYAKU36 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label109 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN36 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label110 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI36 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label111 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN36 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label112 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO36 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label113 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN36 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label114 As JBD.Gjs.Win.Label
    Friend WithEvents Label115 As JBD.Gjs.Win.Label
    Friend WithEvents Label116 As JBD.Gjs.Win.Label
    Friend WithEvents numKUSYA36 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numKUSYA25 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numKUSYA24 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numKUSYA23 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numKUSYA22 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numKUSYA21 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numKUSYA15 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numKUSYA14 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numKUSYA13 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numKUSYA12 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numKUSYA11 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label117 As JBD.Gjs.Win.Label
    Friend WithEvents Label118 As JBD.Gjs.Win.Label
    Friend WithEvents Label119 As JBD.Gjs.Win.Label
    Friend WithEvents Label120 As JBD.Gjs.Win.Label
    Friend WithEvents Label121 As JBD.Gjs.Win.Label
    Friend WithEvents numKUSYA37 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numGENKA_SYOKYAKU37 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label122 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN37 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label123 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI37 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label124 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN37 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label125 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO37 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label126 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN37 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label127 As JBD.Gjs.Win.Label
    Friend WithEvents Label128 As JBD.Gjs.Win.Label
    Friend WithEvents numKUSYA38 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numGENKA_SYOKYAKU38 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label129 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN38 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label130 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI38 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label131 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN38 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label132 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO38 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label133 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN38 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label134 As JBD.Gjs.Win.Label
    Friend WithEvents Label135 As JBD.Gjs.Win.Label
    Friend WithEvents numKUSYA39 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numGENKA_SYOKYAKU39 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label136 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN39 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label137 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI39 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label138 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN39 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label139 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO39 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label140 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN39 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label141 As JBD.Gjs.Win.Label
    Friend WithEvents Label142 As JBD.Gjs.Win.Label
    Friend WithEvents numKUSYA40 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numGENKA_SYOKYAKU40 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label143 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN40 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label144 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI40 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label145 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN40 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label146 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO40 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label147 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN40 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label148 As JBD.Gjs.Win.Label
    Friend WithEvents Label149 As JBD.Gjs.Win.Label
    Friend WithEvents numKUSYA41 As JBD.Gjs.Win.GcNumber
    Friend WithEvents numGENKA_SYOKYAKU41 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label150 As JBD.Gjs.Win.Label
    Friend WithEvents numGENKA_JOGEN41 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label151 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JIDAI41 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label152 As JBD.Gjs.Win.Label
    Friend WithEvents numJIDAI_JOGEN41 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label153 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_KOYO41 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label154 As JBD.Gjs.Win.Label
    Friend WithEvents numKOYO_JOGEN41 As JBD.Gjs.Win.GcNumber
    Friend WithEvents Label155 As JBD.Gjs.Win.Label
    Friend WithEvents Label156 As JBD.Gjs.Win.Label

End Class
