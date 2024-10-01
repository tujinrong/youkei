' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 事務委託先一覧表
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.09.27
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8060

    ''' <summary>
    ''' 事務委託先一覧表
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 初期化処理_画面処理
        ''' </summary>
        Public Shared Function InitResponse(dt As DataTable) As InitResponse
            Dim res As New InitResponse()
            res.KEN_LIST = New List(Of CmCodeNameModel)
            '事務委託先情報
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt.Rows
                Dim item As New CmCodeNameModel
                item.CODE = DaConvertUtil.Cint(DaConvertUtil.CStr(row("MEISYO_CD")))
                item.NAME = DaConvertUtil.CStr(row("MEISYO"))
                res.KEN_LIST.Add(item)
            Next
            Return res
        End Function

        ''' <summary>
        ''' 検索処理_一覧画面処理
        ''' </summary>
        Public Shared Function SearchResponse(dt As DataTable) As SearchResponse
            Dim res = New SearchResponse()
            'データ結果判定
            res.KEKKA_LIST = New List(Of SearchRowVM)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt.Rows
                Dim item As New SearchRowVM
                item.ITAKU_CD = DaConvertUtil.CInt(row("ITAKU_CD"))
                item.ITAKU_NAME = DaConvertUtil.CStr(row("ITAKU_NAME"))
                item.ADDR_TEL = DaConvertUtil.CStr(row("ADDR_TEL"))
                item.ADDR_POST = DaConvertUtil.CStr(row("ADDR_POST"))
                item.ADDR = DaConvertUtil.CStr(row("ADDR"))
                res.KEKKA_LIST.Add(item)
            Next
            Return res
        End Function

        ''' <summary>
        ''' CSV出力処理_一覧画面
        ''' </summary>
        Public Shared Function CsvExportResponse(dt As DataTable) As CsvExportResponse
            Dim res = New CsvExportResponse()
            'CSV作成(日時はサブルーチンでセット)
            res.DATA = f_makeCSVByStream(dt, "JIMUITAKUSAKI_")
            Return res
        End Function
    End Class
End Namespace
