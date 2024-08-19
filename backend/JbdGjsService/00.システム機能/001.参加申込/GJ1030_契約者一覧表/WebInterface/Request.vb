' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 契約者一覧表
'            リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1030

    ''' <summary>
    ''' 初期化処理_一覧画面処理
    ''' </summary>
    Public Class InitRequest
        Inherits Db.DaRequestBase

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
        Public Property NOJO_CD As Integer? = Nothing

        ''' <summary>
        ''' 農場名
        ''' </summary>
        Public Property NOJO_NAME As String = String.Empty

        ''' <summary>
        ''' 検索方法
        ''' </summary>
        Public Property SEARCH_METHOD As EnumAndOr? = EnumAndOr.AndCode

    End Class
End Namespace
