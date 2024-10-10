' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 消費税率一覧表
'            ビューモデル定義
' 作成日　　: 2024.10.03
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8100

    ''' <summary>
    ''' 消費税率一覧情報情報
    ''' </summary>
    Public Class SearchRowVM

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

    End Class
End Namespace
