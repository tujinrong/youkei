' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタメンテナンス（農場情報入力）
'             リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1013

    ''' <summary>
    ''' 検索処理_詳細画面処理
    ''' </summary>
    Public Class SearchRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing

        ''' <summary>
        ''' 契約者番号
        ''' </summary>
        Public Property KEIYAKUSYA_CD As Integer? = Nothing

    End Class

    ''' <summary>
    ''' 検索処理_詳細画面処理
    ''' </summary>
    Public Class InitDetailRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing

        ''' <summary>
        ''' 契約者番号
        ''' </summary>
        Public Property KEIYAKUSYA_CD As Integer? = Nothing

        ''' <summary>
        ''' 農場番号
        ''' </summary>
        Public Property NOJO_CD As Integer? = Nothing

    End Class

    ''' <summary>
    ''' 保存処理_詳細画面処理
    ''' </summary>
    Public Class SaveRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 農場登録情報(入力)
        ''' </summary>
        Public Property NOJO_JOHO As DetailVM = New DetailVM

    End Class
End Namespace
