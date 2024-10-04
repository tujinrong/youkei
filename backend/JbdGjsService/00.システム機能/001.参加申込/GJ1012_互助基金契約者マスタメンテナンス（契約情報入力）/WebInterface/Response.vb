' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタメンテナンス（契約情報入力）
'             レスポンスインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1012

    ''' <summary>
    ''' 検索処理_一覧画面処理(成功)
    ''' </summary>
    Public Class SearchResponse
        Inherits DaResponseBase
        ''' <summary>
        ''' 契約区分コード
        ''' </summary>
        Public Property KEIYAKU_KBN As Integer? = Nothing

        ''' <summary>
        ''' 契約区分コード
        ''' </summary>
        Public Property KEIYAKUSYA_NAME As String = String.Empty

        ''' <summary>
        ''' 農場情報プルダウンリスト
        ''' </summary>
        Public Property NOJO_LIST As List(Of CmCodeNameModel) = New List(Of CmCodeNameModel)

        ''' <summary>
        ''' 鶏の種類情報プルダウンリスト
        ''' </summary>
        Public Property TORI_KBN_LIST As List(Of CmCodeNameModel) = New List(Of CmCodeNameModel)

        ''' <summary>
        ''' 契約羽数合計
        ''' </summary>
        Public Property HASU_GOKEI As CmKeiGokeiModel = New CmKeiGokeiModel

        ''' <summary>
        ''' 契約農場別明細情報(表示)リスト
        ''' </summary>
        Public Property KEKKA_LIST As List(Of SearchRowVM) = New List(Of SearchRowVM)


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class

    ''' <summary>
    ''' 農場住所情報初期化処理_詳細画面処理(成功)
    ''' </summary>
    Public Class InitNojoResponse
        Inherits DaResponseBase


        ''' <summary>
        ''' 農場住所情報
        ''' </summary>
        Public Property NOJO_ADDR As NojoAddrVM = New NojoAddrVM

        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class
End Namespace
