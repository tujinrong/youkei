' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 処理対象期・年度マスタメンテナンス
'             レスポンスインターフェース
' 作成日　　: 2024.08.20
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8020

    ''' <summary>
    ''' 検索処理_詳細画面処理(成功)
    ''' </summary>
    Public Class InitDetailResponse
        Inherits DaResponseBase

        ''' <summary>
        ''' 契約者農場情報
        ''' </summary>
        Public Property SYORI_KI As DetailVM = New DetailVM


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class
End Namespace
