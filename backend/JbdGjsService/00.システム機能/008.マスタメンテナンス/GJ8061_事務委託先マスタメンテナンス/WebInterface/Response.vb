' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 事務委託先マスタメンテナンス
'             レスポンスインターフェース
' 作成日　　: 2024.09.27
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8061

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
        ''' 事務委託先情報
        ''' </summary>
        Public Property ITAKU As DetailVM = New DetailVM


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class
End Namespace
