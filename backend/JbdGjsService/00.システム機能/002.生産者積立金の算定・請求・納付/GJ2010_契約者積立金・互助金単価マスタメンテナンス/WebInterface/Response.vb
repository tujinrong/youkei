' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 契約者積立金・互助金単価マスタ一覧
'            レスポンスインターフェース
' 作成日　　: 2024.10.09
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ2010

    ''' <summary>
    ''' 検索処理_一覧画面処理(成功)
    ''' </summary>
    Public Class SearchResponse
        Inherits CmSearchResponseBase

        ''' <summary>
        ''' 積立金・互助金単価マスタ情報リスト
        ''' </summary>
        Public Property KEKKA_LIST As List(Of CmDateFmToModel) = New List(Of CmDateFmToModel)


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
