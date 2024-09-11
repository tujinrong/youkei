' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタ一覧
'            リクエストインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1010

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
        ''' 期
        ''' </summary>
        Public Property KI As Integer = Nothing

        ''' <summary>
        ''' 都道府県
        ''' </summary>
        Public Property KEN_CD As CmCodeFmToModel = New CmCodeFmToModel

        ''' <summary>
        ''' 未継続・未契約者を除く
        ''' </summary>
        Public Property NOZOKU_FLG As Boolean = True

        ''' <summary>
        ''' 契約者番号
        ''' </summary>
        Public Property KEIYAKUSYA_CD As Integer? = Nothing

        ''' <summary>
        ''' 契約区分
        ''' </summary>
        Public Property KEIYAKU_KBN As Integer? = Nothing

        ''' <summary>
        ''' 契約状況
        ''' </summary>
        Public Property KEIYAKU_JYOKYO As Integer? = Nothing

        ''' <summary>
        ''' 契約者名
        ''' </summary>
        Public Property KEIYAKUSYA_NAME As String = String.Empty

        ''' <summary>
        ''' 契約者名（ﾌﾘｶﾞﾅ）
        ''' </summary>
        Public Property KEIYAKUSYA_KANA As String = String.Empty

        ''' <summary>
        ''' 住所
        ''' </summary>
        Public Property ADDR As String = String.Empty

        ''' <summary>
        ''' 電話番号
        ''' </summary>
        Public Property ADDR_TEL1 As String = String.Empty

        ''' <summary>
        ''' 事務委託先
        ''' </summary>
        Public Property JIMUITAKU_CD As CmCodeFmToModel = New CmCodeFmToModel

        ''' <summary>
        ''' 検索方法
        ''' </summary>
        Public Property SEARCH_METHOD As EnumAndOr? = EnumAndOr.AndCode

    End Class
End Namespace
