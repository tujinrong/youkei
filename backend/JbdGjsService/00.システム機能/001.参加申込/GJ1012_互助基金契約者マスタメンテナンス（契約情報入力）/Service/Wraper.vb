' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタメンテナンス（契約情報入力）
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Imports JbdGjsDb.JBD.GJS

Namespace JBD.GJS.Service.GJ1012

    ''' <summary>
    ''' 互助基金契約者マスタメンテナンス（契約情報入力）
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 検索処理_一覧画面処理
        ''' </summary>
        Public Shared Function SearchResponse(dt1 As DataTable, dt2 As DataTable, dt3 As DataTable, dt4 As DataTable) As SearchResponse
            Dim res = New SearchResponse()
            res.NOJO_LIST = New List(Of CmCodeNameModel)
            res.TORI_KBN_LIST = New List(Of CmCodeNameModel)
            'データ結果判定
            For Each row As DataRow In dt1.Rows
                Dim item As New CmCodeNameModel
                item.CODE = DaConvertUtil.CInt(DaConvertUtil.CStr(row("NOJO_CD")))
                item.NAME = DaConvertUtil.CStr(row("NOJO_NAME"))
                res.NOJO_LIST.Add(item)
            Next

            For Each row As DataRow In dt2.Rows
                Dim item As New CmCodeNameModel
                item.CODE = DaConvertUtil.CInt(DaConvertUtil.CStr(row("MEISYO_CD")))
                item.NAME = DaConvertUtil.CStr(row("MEISYO"))
                res.TORI_KBN_LIST.Add(item)
            Next

            If dt3.Rows.Count > 0 Then
                Dim row As DataRow = dt3.Rows(0)
                res.HASU_GOKEI.SAIRANKEI_SEIKEI = DaConvertUtil.CInt(WordHenkan("N", "Z", row("HASU" & Format(1, "00"))))
                res.HASU_GOKEI.SAIRANKEI_IKUSEIKEI = DaConvertUtil.CInt(WordHenkan("N", "Z", row("HASU" & Format(2, "00"))))
                res.HASU_GOKEI.NIKUYOUKEI = DaConvertUtil.CInt(WordHenkan("N", "Z", row("HASU" & Format(3, "00"))))
                res.HASU_GOKEI.SYUKEI_SEIKEI = DaConvertUtil.CInt(WordHenkan("N", "Z", row("HASU" & Format(4, "00"))))
                res.HASU_GOKEI.SYUKEI_IKUSEIKEI = DaConvertUtil.CInt(WordHenkan("N", "Z", row("HASU" & Format(5, "00"))))
                res.HASU_GOKEI.UZURA = DaConvertUtil.CInt(WordHenkan("N", "Z", row("HASU" & Format(6, "00"))))
                res.HASU_GOKEI.AHIRU = DaConvertUtil.CInt(WordHenkan("N", "Z", row("HASU" & Format(7, "00"))))
                res.HASU_GOKEI.KIJI = DaConvertUtil.CInt(WordHenkan("N", "Z", row("HASU" & Format(8, "00"))))
                res.HASU_GOKEI.HOROHOROTORI = DaConvertUtil.CInt(WordHenkan("N", "Z", row("HASU" & Format(9, "00"))))
                res.HASU_GOKEI.SICHIMENCHOU = DaConvertUtil.CInt(WordHenkan("N", "Z", row("HASU" & Format(10, "00"))))
                res.HASU_GOKEI.DACHOU = DaConvertUtil.CInt(WordHenkan("N", "Z", row("HASU" & Format(11, "00"))))
            End If

            If dt4.Rows.Count > 0 Then
                res.KEKKA_LIST = New List(Of SearchRowVM)
                ' dt をループし、List にデータを追加します。
                For Each row As DataRow In dt4.Rows
                    Dim item As New SearchRowVM
                    item.SEQNO = DaConvertUtil.CInt(row("SEQNO"))
                    item.KI = DaConvertUtil.CInt(row("KI"))
                    item.KEIYAKUSYA_CD = DaConvertUtil.CInt(row("KEIYAKUSYA_CD"))
                    item.MEISAI_NO = DaConvertUtil.CInt(row("MEISAI_NO"))
                    item.NOJO_CD = DaConvertUtil.CInt(row("NOJO_CD"))
                    item.NOJO_NAME = DaConvertUtil.CStr(row("NOJO_NM"))
                    item.NOJO_ADDR = DaConvertUtil.CStr(row("ADDR"))
                    item.ADDR_POST = DaConvertUtil.CStr(row("ADDR_POST"))
                    item.ADDR_1 = DaConvertUtil.CStr(row("ADDR_1"))
                    item.ADDR_2 = DaConvertUtil.CStr(row("ADDR_2"))
                    item.ADDR_3 = DaConvertUtil.CStr(row("ADDR_3"))
                    item.ADDR_4 = DaConvertUtil.CStr(row("ADDR_4"))
                    item.TORI_KBN = DaConvertUtil.CInt(row("TORI_KBN"))
                    item.TORI_KBN_NAME = DaConvertUtil.CStr(row("TORI_KBN_NM"))
                    item.KEIYAKU_HASU = DaConvertUtil.CInt(row("KEIYAKU_HASU"))
                    item.KEIYAKU_DATE.VALUE_FM = DaConvertUtil.CDate(row("KEIYAKU_DATE_FROM"))
                    item.KEIYAKU_DATE.VALUE_TO = DaConvertUtil.CDate(row("KEIYAKU_DATE_TO"))
                    item.BIKO = DaConvertUtil.CStr(row("BIKO"))
                    res.KEKKA_LIST.Add(item)
                Next
            End If
            Return res
        End Function

        ''' <summary>
        ''' 検索処理_一覧画面処理
        ''' </summary>
        Public Shared Function InitNojoResponse(dt As DataTable) As InitNojoResponse
            Dim res = New InitNojoResponse()
            res.NOJO_ADDR = New NojoAddrVM
            'データ結果判定

            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                res.NOJO_ADDR.MEISAI_NO = DaConvertUtil.CInt(WordHenkan("N", "S", row("MEISAI_NO")))
                Dim wStr As String = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_POST")))
                If wStr = "" Then
                    res.NOJO_ADDR.ADDR_POST = ""
                Else
                    res.NOJO_ADDR.ADDR_POST = DaConvertUtil.f_MidB(wStr, 1, 3) & "-" & DaConvertUtil.f_MidB(wStr, 4, 4)
                End If
                res.NOJO_ADDR.ADDR_1 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_1")))
                res.NOJO_ADDR.ADDR_2 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_2")))
                res.NOJO_ADDR.ADDR_3 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_3")))
                res.NOJO_ADDR.ADDR_4 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_4")))
            End If
            Return res
        End Function

    End Class
End Namespace
