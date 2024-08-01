
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class DataGridView
    Inherits System.Windows.Forms.DataGridView

    Public Sub New()
        Me.New(Nothing)
    End Sub


    Public Sub New(ByVal component As System.ComponentModel.IContainer)
        MyBase.New()
        ' この呼び出しは、コンポーネント デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

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
        'DataGridView
        '
        'フォント設定
        Me.Font = New System.Drawing.Font(GjsDefaultFont.Name.Default.ToString, GjsDefaultFont.Size.Default, System.Drawing.FontStyle.Regular)

        'Tab キーがコントロール内の次のセルにフォーカスを移動させるのではなく、
        'タブ順で次のコントロールにフォーカスを移動させるように設定します。
        Me.StandardTab = True
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :DataGridView_KeyDown
    '説明            :Enterキー押下時処理
    '------------------------------------------------------------------
    Private Sub DataGridView_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then  ' --- ［Enter］が押されたら
                e.Handled = True       ' --- 実際に押された［Enter］は無効にして
            End If

        Catch ex As Exception
            '共通例外処理
            'Show_MessageBox("", ex.Message)

        End Try

    End Sub

End Class