' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 金融機関マスタ一覧
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8050

    ''' <summary>
    ''' 金融機関マスタ一覧
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 検索処理_金融機関一覧画面処理
        ''' </summary>
        Public Shared Function SearchBankResponse(dt As DataTable) As SearchBankResponse
            Dim res = New SearchBankResponse()
            'データ結果判定
            If dt.Rows.Count > 0 Then
                res.TOTAL_ROW_COUNT = DaConvertUtil.CInt(DaConvertUtil.CStr(dt.Rows(0)("RCNT")))
                res.TOTAL_PAGE_COUNT = DaConvertUtil.CInt(DaConvertUtil.CStr(dt.Rows(0)("PCNT")))
                res.KEKKA_LIST = New List(Of SearchBankRowVM)
                ' dt をループし、List にデータを追加します。
                For Each row As DataRow In dt.Rows
                    Dim item As New SearchBankRowVM
                    item.BANK_CD = DaConvertUtil.CStr(row("BANK_CD"))
                    item.BANK_KANA = DaConvertUtil.CStr(row("BANK_KANA"))
                    item.BANK_NAME = DaConvertUtil.CStr(row("BANK_NAME"))
                    res.KEKKA_LIST.Add(item)
                Next
            End If
            Return res
        End Function

        ''' <summary>
        ''' 検索処理_支店一覧画面処理
        ''' </summary>
        Public Shared Function SearchSitenResponse(dt As DataTable) As SearchSitenResponse
            Dim res = New SearchSitenResponse()
            'データ結果判定
            If dt.Rows.Count > 0 Then
                res.TOTAL_ROW_COUNT = DaConvertUtil.CInt(DaConvertUtil.CStr(dt.Rows(0)("RCNT")))
                res.TOTAL_PAGE_COUNT = DaConvertUtil.CInt(DaConvertUtil.CStr(dt.Rows(0)("PCNT")))
                res.KEKKA_LIST = New List(Of SearchSitenRowVM)
                ' dt をループし、List にデータを追加します。
                For Each row As DataRow In dt.Rows
                    Dim item As New SearchSitenRowVM
                    item.BANK_CD = DaConvertUtil.CStr(row("BANK_CD"))
                    item.SITEN_CD = DaConvertUtil.CStr(row("SITEN_CD"))
                    item.SITEN_KANA = DaConvertUtil.CStr(row("SITEN_KANA"))
                    item.SITEN_NAME = DaConvertUtil.CStr(row("SITEN_NAME"))
                    res.KEKKA_LIST.Add(item)
                Next
            End If
            Return res
        End Function
    End Class
End Namespace
