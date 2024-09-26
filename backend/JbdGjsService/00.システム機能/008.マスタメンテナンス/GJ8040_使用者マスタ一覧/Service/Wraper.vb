' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 使用者マスタ一覧
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8040

    ''' <summary>
    ''' 契約者農場マスタ一覧
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 検索処理_一覧画面処理
        ''' </summary>
        Public Shared Function SearchResponse(dt As DataTable) As SearchResponse
            Dim res = New SearchResponse()
            'データ結果判定
            If dt.Rows.Count > 0 Then
                res.KEKKA_LIST = New List(Of SearchRowVM)
                ' dt をループし、List にデータを追加します。
                For Each row As DataRow In dt.Rows
                    Dim item As New SearchRowVM
                    item.USER_ID = DaConvertUtil.CStr(row("USER_ID"))
                    item.USER_NAME = DaConvertUtil.CStr(row("USER_NAME"))
                    item.SIYO_KBN_NAME = DaConvertUtil.CStr(row("SIYO_KBN_NAME"))
                    item.TEISI_DATE = DaConvertUtil.CDate(row("TEISI_DATE"))
                    item.TEISI_RIYU = DaConvertUtil.CStr(row("TEISI_RIYU"))
                    res.KEKKA_LIST.Add(item)
                Next
            End If
            Return res
        End Function
    End Class
End Namespace
