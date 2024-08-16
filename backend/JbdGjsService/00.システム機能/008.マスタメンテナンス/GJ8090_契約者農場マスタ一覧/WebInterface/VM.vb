' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 契約者農場マスタ一覧
'            ビューモデル定義
' 作成日　　: 2024.07.12
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8090

    ''' <summary>
    ''' 契約者農場情報
    ''' </summary>
    Public Class KeiyakuNojo

        ''' <summary>
        ''' 農場コード
        ''' </summary>
        Public Property NOJO_CD As Integer = Nothing

        ''' <summary>
        ''' 農場名
        ''' </summary>
        Public Property NOJO_NAME As String = String.Empty

        ''' <summary>
        ''' 住所
        ''' </summary>
        Public Property ADDR As String = String.Empty

    End Class
End Namespace
