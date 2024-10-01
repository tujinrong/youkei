' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 事務委託先一覧表
'            リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8060

    ''' <summary>
    ''' 初期化処理_一覧画面処理
    ''' </summary>
    Public Class InitRequest
        Inherits DaRequestBase

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer = Nothing

    End Class

   ''' <summary>
    ''' 検索処理_一覧画面処理
    ''' </summary>
    Public Class SearchRequest
        Inherits CmSearchRequestBase

        ''' <summary>
        ''' 検索条件入力情報
        ''' </summary>
        Public Property NYURYOKU_JOHO As SearchVM

    End Class

   ''' <summary>
    ''' CSV出力処理_一覧画面
    ''' </summary>
    Public Class CsvExportRequest
        Inherits CmSearchRequestBase

        ''' <summary>
        ''' CSV出力条件入力情報
        ''' </summary>
        Public Property NYURYOKU_JOHO As SearchVM

    End Class

End Namespace
