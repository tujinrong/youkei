'******************************************************************
'** 互助システム(GJS) 既定値設定
'******************************************************************
'フォント設定
Namespace GjsDefaultFont
    Public Module Name
        Public [Default] = "ＭＳ Ｐゴシック"
    End Module
    Public Module Size
        Public [Default] = 11.0!
    End Module
End Namespace

'色の設定
Namespace GjsDefaultColor
    Public Module GjsDefaultColor
        'フォーム既定背景
        Public FormBackColor = System.Drawing.Color.AliceBlue
        'コントロール通常背景
        Public NormalColor = System.Drawing.SystemColors.Window
        'コントロール必須入力背景
        Public MandatoryColor = System.Drawing.Color.FromArgb(255, 192, 192)
        'ラベル背景
        Public LabelBackColor = System.Drawing.Color.CornflowerBlue
        'リンクラベル背景
        Public LinkLabelBackColor = System.Drawing.Color.FromArgb(26, 98, 228)
        'Linkカラー
        Public LinkDefaultColor = System.Drawing.Color.Black
        'Linkカラー選択時文字色
        Public LinkColor = System.Drawing.Color.AliceBlue
        'ボタン背景色
        Public ButtonBackColor = System.Drawing.Color.CornflowerBlue
        'タブコントロール背景
        Public TabControlBackColor = System.Drawing.Color.AliceBlue
        'タブコントロールヘッダー背景(選択時)
        'オーナードローを使用しているため色の設定はBrushesクラスを使用
        Public TabHSelectColor = System.Drawing.Brushes.CornflowerBlue

    End Module

End Namespace

