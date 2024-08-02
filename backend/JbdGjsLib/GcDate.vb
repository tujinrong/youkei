
Imports GrapeCity.Win.Editors
<ComponentModel.LicenseProviderAttribute(GetType(ComponentModel.LicenseProvider))> _
Public Class GcDate
    Inherits GrapeCity.Win.Editors.GcDate
    'Inherits GrapeCity.Win.Input.Interop.GcDate


    Public Sub New()
        Me.New(Nothing)
    End Sub


    Public Sub New(ByVal component As System.ComponentModel.IContainer)
        MyBase.New(component)
        ' この呼び出しは、コンポーネント デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System

        '2010/09/29 JBD200 フォーカス取得時にテキストを選択状態にしない
        Me.HighlightText = 0

        '2010/09/29 JBD200 日付入力フィールドの書式設定
        'Dim DateEraField1 As New GrapeCity.Win.Editors.Fields.DateEraField()
        'Dim DateLiteralField1 As New GrapeCity.Win.Editors.Fields.DateLiteralField()
        'Dim DateEraYearField1 As New GrapeCity.Win.Editors.Fields.DateEraYearField()
        'Me.Fields.AddRange(New GrapeCity.Win.Editors.Fields.DateField() {DateEraField1, DateLiteralField1, DateEraYearField1})
        'Me.DefaultActiveField = DateEraYearField1

    End Sub

    'Control は、コンポーネント一覧に後処理を実行するために、dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private flgOnEnter As Boolean = False
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        If Me.DesignMode Then Exit Sub

        MyBase.OnEnter(e)
        If Me.Value Is Nothing Or Me.Text = "" Then
            Me.Text = ""
            'If Me.CursorPosition <> GrapeCity.Win.Input.DateCursorPosition.Era Then
            Me.SelectionStart = 1
            '↓2019/04/10 JBD368 UPD 元号対応
            'System.Windows.Forms.SendKeys.Send("H")
            Me.ImeMode = System.Windows.Forms.ImeMode.Off 'R5年度　OSバージョンアップ　既存バグ修正のため　2024/03/08 JBD 453 Add
            System.Windows.Forms.SendKeys.Send("R")
            '↑2019/04/10 JBD368 UPD 元号対応
            'End If
        End If
        flgOnEnter = True
    End Sub

    Protected Overloads Overrides Function GetDefaultFields() As GrapeCity.Win.Editors.Fields.DateField()
        '  
        ' デフォルトの入力フィールドを設定します。  
        '  
        Return GrapeCity.Win.Editors.Fields.DateFieldsBuilder.BuildFields("yyyy/MM/dd")

    End Function


    'コントロール デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャはコンポーネント デザイナで必要です。
    ' コンポーネント デザイナを使って変更できます。
    ' コード エディタを使って変更しないでください。  
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GcDate
        '
        'フォント設定
        Me.Font = New System.Drawing.Font(GjsDefaultFont.Name.Default.ToString, GjsDefaultFont.Size.Default, System.Drawing.FontStyle.Regular)

        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    ''' <summary>
    ''' 必須入力プロパティ
    ''' </summary>
    ''' <remarks>Trueの場合、背景色を変更します。入力済みの場合背景はデフォルトに戻ります。</remarks>
    Private _InputCheck As Boolean = False
    <System.ComponentModel.DefaultValue(False)> _
    <System.ComponentModel.Description("Trueの場合、背景色を変更します。入力済みの場合背景はデフォルトに戻ります。")> _
    Public Property InputCheck() As Boolean

        Get
            Return _InputCheck
        End Get

        Set(ByVal value As Boolean)
            Select Case value
                Case True
                    Me.BackColor = GjsDefaultColor.MandatoryColor
                Case False
                    Me.BackColor = GjsDefaultColor.NormalColor
            End Select
            _InputCheck = value
        End Set
    End Property

    Protected Overrides Sub OnTextChanged(e As EventArgs)

        If Me.InputCheck Then
            If Me.Value Is Nothing OrElse Me.Value.ToString.Length = 0 Then
                Me.BackColor = GjsDefaultColor.MandatoryColor
            Else
                Me.BackColor = GjsDefaultColor.NormalColor
            End If
        End If
        MyBase.OnTextChanged(e)
    End Sub

End Class