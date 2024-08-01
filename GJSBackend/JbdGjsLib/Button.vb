
Imports System.ComponentModel
Public Class Button
    Inherits System.Windows.Forms.Button

    Public Sub New()
        Me.New(Nothing)
    End Sub


    Public Sub New(ByVal component As System.ComponentModel.IContainer)
        MyBase.New()
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
        components = New System.ComponentModel.Container

        '
        'Button
        '
        'フォント設定
        Me.Font = New System.Drawing.Font(GjsDefaultFont.Name.Default.ToString, GjsDefaultFont.Size.Default, System.Drawing.FontStyle.Regular)

    End Sub


End Class