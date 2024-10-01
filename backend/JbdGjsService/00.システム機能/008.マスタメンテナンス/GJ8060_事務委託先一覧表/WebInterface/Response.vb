' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 事務委託先一覧表
'            レスポンスインターフェース
' 作成日　　: 2024.09.27
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8060

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

        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class

    ''' <summary>
    ''' 検索処理_一覧画面処理(成功)
    ''' </summary>
    Public Class SearchResponse
        Inherits CmSearchResponseBase

        ''' <summary>
        ''' 期
        ''' </summary>
        Public Property KI As Integer? = Nothing

        ''' <summary>
        ''' 事務委託先情報リスト
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

    ''' <summary>
    ''' CSV出力処理_一覧画面処理(成功)
    ''' </summary>
    Public Class CsvExportResponse
        Inherits DaResponseBase

        ''' <summary>
        ''' ドキュメント情報
        ''' </summary>
        Public Property DATA As FileStream


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
