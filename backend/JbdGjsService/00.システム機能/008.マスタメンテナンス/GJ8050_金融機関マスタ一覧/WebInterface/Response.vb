' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 金融機関マスタ一覧
'            レスポンスインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8050

    ''' <summary>
    ''' 検索処理_一覧画面処理処理(成功)
    ''' </summary>
    Public Class SearchBankResponse
        Inherits CmSearchResponseBase

        ''' <summary>
        ''' 金融機関情報リスト
        ''' </summary>
        Public Property KEKKA_LIST As List(Of SearchBankRowVM) = New List(Of SearchBankRowVM)


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

        Public Sub New(recode As EnumServiceResult, msg As String)
            MyBase.New(recode, msg)
        End Sub

    End Class


    ''' <summary>
    ''' 検索処理_支店一覧画面(成功)
    ''' </summary>
    Public Class SearchSitenResponse
        Inherits CmSearchResponseBase

        ''' <summary>
        ''' 金融機関情報リスト
        ''' </summary>
        Public Property KEKKA_LIST As List(Of SearchSitenRowVM) = New List(Of SearchSitenRowVM)


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
