' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 使用者マスタメンテナンス
'             レスポンスインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8041

    ''' <summary>
    ''' 初期化処理_詳細画面処理(成功)
    ''' </summary>
    Public Class InitDetailResponse
        Inherits DaResponseBase

        ''' <summary>
        ''' 使用区分情報プルダウンリスト
        ''' </summary>
        Public Property SIYO_KBN_LIST As List(Of CmCodeNameModel) = New List(Of CmCodeNameModel)

        ''' <summary>
        ''' 使用者情報
        ''' </summary>
        Public Property USER As DetailVM = New DetailVM


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class
End Namespace
