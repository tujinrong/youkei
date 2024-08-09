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
    ''' 契約者農場マスタメンテナンス
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 初期化処理_一覧画面
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

        ''' <summary>
        ''' 検索処理_一覧画面処理
        ''' </summary>
        Public Shared Function SearchResponse(dt As DataTable) As SearchResponse
            Dim res = New SearchResponse()
            res.TOTAL_ROW_COUNT = Cint(dt.Rows(0)("RCNT").ToString())
            res.TOTAL_PAGE_COUNT = Cint(dt.Rows(0)("PCNT").ToString())
            res.KEKKA_LIST = New List(Of KeiyakuNojo)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt.Rows
                Dim item As New KeiyakuNojo
                item.NOJO_CD = Cint(row("NOJO_CD").ToString())
                item.NOJO_NAME = row("NOJO_NAME").ToString()
                item.ADDR = row("ADDR").ToString()
                res.KEKKA_LIST.Add(item)
            Next
            Return res
        End Function
    End Class
End Namespace
