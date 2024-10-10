' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 使用者マスタ一覧
'            レスポンスインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8040

    ''' <summary>
    ''' 検索処理_一覧画面処理(成功)
    ''' </summary>
    Public Class SearchResponse
        Inherits CmSearchResponseBase

        ''' <summary>
        ''' 使用者情報リスト
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
