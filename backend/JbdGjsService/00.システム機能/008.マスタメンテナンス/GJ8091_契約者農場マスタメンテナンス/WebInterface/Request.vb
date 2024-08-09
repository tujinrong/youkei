' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 契約者農場マスタメンテナンス
'             リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8091

    ''' <summary>
    ''' 検索処理_詳細画面処理
    ''' </summary>
    Public Class SearchDetailRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer = Nothing

        ''' <summary>
        ''' 契約者番号
        ''' </summary>
        Public Property KEIYAKUSYA_CD As Integer = Nothing

        ''' <summary>
        ''' 農場番号
        ''' </summary>
        Public Property NOJO_CD As Integer = Nothing

    End Class
End Namespace
