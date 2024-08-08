' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 契約者農場マスタメンテナンス
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8090

    ''' <summary>
    ''' ログイン
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' ログイン処理
        ''' </summary>
        Public Shared Function GetInitResponse(dt As DataTable) As InitResponse
            Dim res = New InitResponse()
            res.KEIYAKUSYA_CD_NAME_LIST = New List(Of CodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt.Rows
                Dim item As New CodeNameModel
                item.CODE = Cint(row("KEIYAKUSYA_CD").ToString())
                item.NAME = row("KEIYAKUSYA_NAME").ToString()
                res.KEIYAKUSYA_CD_NAME_LIST.Add(item)
            Next
            Return res
        End Function
    End Class
End Namespace
