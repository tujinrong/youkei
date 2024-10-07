' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 消費税率マスタメンテナンス
'             ビューモデル定義
' 作成日　　: 2024.10.07
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8101

    ''' <summary>
    ''' 消費税率情報
    ''' </summary>
    Public Class DetailVM

        ''' <summary>
        ''' 適用開始日
        ''' </summary>
        Public Property TAX_DATE_FROM As DateTime? = Nothing

        ''' <summary>
        ''' 適用終了日
        ''' </summary>
        Public Property TAX_DATE_TO As DateTime? = Nothing

        ''' <summary>
        ''' 消費税率(%)
        ''' </summary>
        Public Property TAX_RITU As Integer? = Nothing

        ''' <summary>
        ''' データ更新日
        ''' </summary>
        Public Property UP_DATE As DateTime? = Nothing

    End Class
End Namespace
