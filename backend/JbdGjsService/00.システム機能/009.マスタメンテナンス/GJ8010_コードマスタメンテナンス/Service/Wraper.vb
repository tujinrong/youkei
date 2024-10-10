' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: コードマスタメンテナンス
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.09.13
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8010

    ''' <summary>
    ''' コードマスタメンテナンス
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 初期化処理_一覧画面
        ''' </summary>
        Public Shared Function GetInitResponse(dt As DataTable) As InitResponse
            Dim res = New InitResponse()
            'データ結果判定
            If dt.Rows.Count > 0 Then
                res.SYURUI_KBN_LIST = New List(Of CmCodeNameModel)
                ' dt をループし、List にデータを追加します。
                For Each row As DataRow In dt.Rows
                    Dim item As New CmCodeNameModel
                    item.CODE = DaConvertUtil.CInt(row("MEISYO_CD"))
                    item.NAME = DaConvertUtil.CStr(row("MEISYO"))
                    res.SYURUI_KBN_LIST.Add(item)
                Next
            End If
            Return res
        End Function

        ''' <summary>
        ''' 検索処理_一覧画面処理
        ''' </summary>
        Public Shared Function SearchResponse(dt As DataTable) As SearchResponse
            Dim res = New SearchResponse()
            res.TOTAL_ROW_COUNT = DaConvertUtil.Cint(DaConvertUtil.CStr(dt.Rows(0)("RCNT")))
            res.TOTAL_PAGE_COUNT = DaConvertUtil.Cint(DaConvertUtil.CStr(dt.Rows(0)("PCNT")))
            'データ結果判定
            If dt.Rows.Count > 0 Then
                res.KEKKA_LIST = New List(Of SearchRowVM)
                ' dt をループし、List にデータを追加します。
                For Each row As DataRow In dt.Rows
                    Dim item As New SearchRowVM
                    item.MEISYO_CD = DaConvertUtil.CInt(DaConvertUtil.CStr(row("MEISYO_CD")))
                    item.MEISYO = DaConvertUtil.CStr(row("MEISYO"))
                    item.RYAKUSYO = DaConvertUtil.CStr(row("RYAKUSYO"))
                    res.KEKKA_LIST.Add(item)
                Next
            End If
            Return res
        End Function
    End Class
End Namespace
