' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 契約者農場マスタ一覧
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8090

    ''' <summary>
    ''' 契約者農場マスタ一覧
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 初期化処理_一覧画面
        ''' </summary>
        Public Shared Function GetInitResponse(dt As DataTable) As InitResponse
            Dim res = New InitResponse()
            res.KEIYAKUSYA_CD_NAME_LIST = New List(Of CmCodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt.Rows
                Dim item As New CmCodeNameModel
                item.CODE = Cint(CStr(row("KEIYAKUSYA_CD")))
                item.NAME = CStr(row("KEIYAKUSYA_NAME"))
                res.KEIYAKUSYA_CD_NAME_LIST.Add(item)
            Next
            Return res
        End Function

        ''' <summary>
        ''' 検索処理_一覧画面処理
        ''' </summary>
        Public Shared Function SearchResponse(dt As DataTable) As SearchResponse
            Dim res = New SearchResponse()
            'データ結果判定
            If dt.Rows.Count > 0 Then
                res.TOTAL_ROW_COUNT = Cint(CStr(dt.Rows(0)("RCNT")))
                res.TOTAL_PAGE_COUNT = Cint(CStr(dt.Rows(0)("PCNT")))
                res.KEKKA_LIST = New List(Of KeiyakuNojo)
                ' dt をループし、List にデータを追加します。
                For Each row As DataRow In dt.Rows
                    Dim item As New KeiyakuNojo
                    item.NOJO_CD = Cint(CStr(row("NOJO_CD")))
                    item.NOJO_NAME = CStr(row("NOJO_NAME"))
                    item.ADDR = CStr(row("ADDR"))
                    res.KEKKA_LIST.Add(item)
                Next
            End If
            Return res
        End Function
    End Class
End Namespace
