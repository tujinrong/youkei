
Imports GrapeCity.Win.Editors
<ComponentModel.LicenseProviderAttribute(GetType(ComponentModel.LicenseProvider))> _
Public Class GcComboBox
    Inherits GrapeCity.Win.Editors.GcComboBox


    Public Sub New()
        Me.New(Nothing)
    End Sub


    Public Sub New(ByVal component As System.ComponentModel.IContainer)
        MyBase.New(component)
        ' この呼び出しは、コンポーネント デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        Me.FlatStyle = GrapeCity.Win.Editors.FlatStyleEx.System
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

    'コントロール デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャはコンポーネント デザイナで必要です。
    ' コンポーネント デザイナを使って変更できます。
    ' コード エディタを使って変更しないでください。  
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GcComboBox
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

    Protected Overrides Sub OnSelectedIndexChanged(sender As Object, e As EventArgs)
        If Me.InputCheck Then
            If Me.SelectedIndex = -1 Then
                If Me.DropDown.AllowDrop Then
                    'ドロップダウン機能が有効な場合
                    If Me.Text = "" Then
                        Me.BackColor = GjsDefaultColor.MandatoryColor
                    Else
                        Me.BackColor = GjsDefaultColor.NormalColor
                    End If
                Else
                    'ドロップダウン機能が無効な場合(マスタコードの入力等）
                    Me.BackColor = GjsDefaultColor.MandatoryColor
                End If

                '2015/02/05 JBD368 UPD ↓↓
                'Me.BackColor = GjsDefaultColor.NormalColor
            ElseIf Me.SelectedIndex = 0 And Me.Text = "" Then

                Me.BackColor = GjsDefaultColor.MandatoryColor

            Else
                Me.BackColor = GjsDefaultColor.NormalColor
                '2015/02/05 JBD368 UPD ↑↑
            End If
        End If
        MyBase.OnSelectedIndexChanged(sender, e)
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)

        If Me.InputCheck Then
            If Not Me.DropDown.AllowDrop Then
                If Me.Text Is Nothing OrElse Me.Text.Length = 0 Then
                    Me.BackColor = GjsDefaultColor.MandatoryColor
                Else
                    Me.BackColor = GjsDefaultColor.NormalColor
                End If
            End If
        End If
        MyBase.OnTextChanged(e)
    End Sub


End Class