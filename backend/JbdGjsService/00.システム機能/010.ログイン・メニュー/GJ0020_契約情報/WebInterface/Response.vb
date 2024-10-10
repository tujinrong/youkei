' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 契約情報
'            レスポンスインターフェース
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ0020

    ''' <summary>
    ''' ホーム情報処理(成功)
    ''' </summary>
    Public Class HomeInfoResponse
        Inherits DaResponseBase

        ''' <summary>
        ''' 新規
        ''' </summary>
        Public Property KEIYAKUSU_SHINKI As Integer = 0

        ''' <summary>
        ''' 継続
        ''' </summary>
        Public Property KEIYAKUSU_KEIZOKU As Integer =  0

        ''' <summary>
        ''' 羽数
        ''' </summary>
        Public Property HASU As Long = 0

        ''' <summary>
        ''' 積立金額
        ''' </summary>
        Public Property TUMITATE_KIN As Long = 0


        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            MyBase.New(msg)
        End Sub

    End Class
End Namespace
