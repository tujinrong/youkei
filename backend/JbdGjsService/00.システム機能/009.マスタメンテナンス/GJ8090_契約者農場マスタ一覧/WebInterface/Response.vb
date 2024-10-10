' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 契約者農場マスタ一覧
'            レスポンスインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8090

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
        ''' 契約者情報プルダウンリスト
        ''' </summary>
        Public Property KEIYAKUSYA_CD_NAME_LIST As List(Of CmCodeNameModel) = New List(Of CmCodeNameModel)

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
        ''' 契約者番号
        ''' </summary>
        Public Property KEIYAKUSYA_CD As Integer = Nothing

        ''' <summary>
        ''' 契約者農場情報リスト
        ''' </summary>
        Public Property KEKKA_LIST As List(Of KeiyakuNojo) = New List(Of KeiyakuNojo)


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

        Public Sub New(recode As EnumServiceResult,msg As String)
            MyBase.New(recode, msg)
        End Sub

    End Class
End Namespace
