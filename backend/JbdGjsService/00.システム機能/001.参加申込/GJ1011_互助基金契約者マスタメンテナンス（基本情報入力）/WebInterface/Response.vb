' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタメンテナンス（基本情報入力）
'             レスポンスインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1011

    ''' <summary>
    ''' 初期化処理_詳細画面処理(成功)
    ''' </summary>
    Public Class InitDetailResponse
        Inherits DaResponseBase

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
        Public Property JIMUITAKU_LIST As List(Of CmCodeNameModel) = New List(Of CmCodeNameModel)

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
        ''' 契約者情報
        ''' </summary>
        Public Property KEIYAKUSYA As DetailVM = New DetailVM


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class
End Namespace
