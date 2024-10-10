' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: コードマスタメンテナンス
'            レスポンスインターフェース
' 作成日　　: 2024.09.13
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8010

    ''' <summary>
    ''' 初期化処理_一覧画面処理(成功)
    ''' </summary>
    Public Class InitResponse
        Inherits DaResponseBase

        ''' <summary>
        ''' 種類区分情報プルダウンリスト
        ''' </summary>
        Public Property SYURUI_KBN_LIST As List(Of CmCodeNameModel) = New List(Of CmCodeNameModel)


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
        ''' 種類区分コード
        ''' </summary>
        Public Property SYURUI_KBN As Integer? = Nothing

        ''' <summary>
        ''' コード情報リスト
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
