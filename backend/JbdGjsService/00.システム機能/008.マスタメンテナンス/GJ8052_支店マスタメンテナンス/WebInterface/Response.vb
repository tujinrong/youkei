' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 支店マスタメンテナンス
'             レスポンスインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8052

    ''' <summary>
    ''' 初期化処理_支店詳細画面処理(成功)
    ''' </summary>
    Public Class InitSitenDetailResponse
        Inherits DaResponseBase

        ''' <summary>
        ''' 支店情報
        ''' </summary>
        Public Property SITEN As SitenDetailVM = New SitenDetailVM


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class
End Namespace
