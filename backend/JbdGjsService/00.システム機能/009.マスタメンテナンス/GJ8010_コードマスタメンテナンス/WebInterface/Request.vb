' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: コードマスタメンテナンス
'            リクエストインターフェース
' 作成日　　: 2024.09.13
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8010

    ''' <summary>
    ''' 初期化処理_一覧画面処理
    ''' </summary>
    Public Class InitRequest
        Inherits DaRequestBase

    End Class

    ''' <summary>
    ''' 検索処理_一覧画面処理
    ''' </summary>
    Public Class SearchRequest
        Inherits CmSearchRequestBase

        ''' <summary>
        ''' 種類区分コード
        ''' </summary>
        Public Property SYURUI_KBN As Integer?

    End Class
End Namespace
