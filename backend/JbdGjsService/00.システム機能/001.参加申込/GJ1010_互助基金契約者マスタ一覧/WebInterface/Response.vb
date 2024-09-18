' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタ一覧
'            レスポンスインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1010

    ''' <summary>
    ''' 初期化処理_一覧画面処理(成功)
    ''' </summary>
    Public Class InitResponse
        Inherits DaResponseBase

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing

        ''' <summary>
        ''' 都道府県情報プルダウンリスト
        ''' </summary>
        Public Property KEN_LIST As List(Of CmCodeNameModel) = New List(Of CmCodeNameModel)

        ''' <summary>
        ''' 契約区分情報プルダウンリスト
        ''' </summary>
        Public Property KEIYAKU_KBN_LIST As List(Of CmCodeNameModel) = New List(Of CmCodeNameModel)

        ''' <summary>
        ''' 契約状況情報プルダウンリスト
        ''' </summary>
        Public Property KEIYAKU_JYOKYO_LIST As List(Of CmCodeNameModel) = New List(Of CmCodeNameModel)

        ''' <summary>
        ''' 事務委託先情報プルダウンリスト
        ''' </summary>
        Public Property ITAKU_LIST As List(Of CmCodeNameModel) = New List(Of CmCodeNameModel)

        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class

    ''' <summary>
    ''' 検索処理_一覧画面処理処理(成功)
    ''' </summary>
    Public Class SearchResponse
        Inherits CmSearchResponseBase

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer = Nothing

        ''' <summary>
        ''' 契約者情報リスト
        ''' </summary>
        Public Property KEKKA_LIST As List(Of SearchRowVM) = New List(Of SearchRowVM)


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

        Public Sub New(recode As EnumServiceResult, msg As String)
            MyBase.New(recode, msg)
        End Sub

    End Class
End Namespace
