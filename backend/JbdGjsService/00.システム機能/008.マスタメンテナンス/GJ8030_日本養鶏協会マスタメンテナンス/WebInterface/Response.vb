' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 日本養鶏協会マスタメンテナンス
'             レスポンスインターフェース
' 作成日　　: 2024.08.20
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8030

    ''' <summary>
    ''' 初期化処理_詳細画面処理(成功)
    ''' </summary>
    Public Class InitDetailResponse
        Inherits DaResponseBase

        ''' <summary>
        ''' 金融機関情報プルダウンリスト
        ''' </summary>
        Public Property BANK_LIST As List(Of CmStrCodeNameModel) = New List(Of CmStrCodeNameModel)

        ''' <summary>
        ''' 本支店情報プルダウンリスト
        ''' </summary>
        Public Property SITEN_LIST As List(Of CmStrCodeNameModel) = New List(Of CmStrCodeNameModel)

        ''' <summary>
        ''' 口座種別情報プルダウンリスト
        ''' </summary>
        Public Property KOZA_SYUBETU_LIST As List(Of CmCodeNameModel) = New List(Of CmCodeNameModel)

        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class



    ''' <summary>
    ''' 検索処理_詳細画面処理(成功)
    ''' </summary>
    Public Class SearchDetailResponse
        Inherits DaResponseBase

        ''' <summary>
        ''' 協会情報
        ''' </summary>
        Public Property KYOKAI As DetailVM = New DetailVM


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class

    ''' <summary>
    ''' 保存処理_詳細画面処理(成功)
    ''' </summary>
    Public Class SaveResponse
        Inherits DaResponseBase

        ''' <summary>
        ''' 協会情報
        ''' </summary>
        Public Property KYOKAI As DetailVM = New DetailVM


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class
End Namespace
