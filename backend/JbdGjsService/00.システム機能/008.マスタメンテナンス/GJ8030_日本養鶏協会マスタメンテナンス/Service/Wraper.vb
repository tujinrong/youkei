' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 日本養鶏協会マスタメンテナンス
'             DB項目から画面項目に変換
' 作成日　　: 2024.08.20
' 作成者　　: 唐
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8030

    ''' <summary>
    ''' 日本養鶏協会マスタメンテナンス
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 初期化処理_一覧画面
        ''' </summary>
        Public Shared Function GetInitFuriDetailResponse(dt1 As DataTable, dt2 As DataTable, dt3 As DataTable) As InitFuriDetailResponse
            Dim res = New InitFuriDetailResponse()

            res.FURI_BANK_LIST = New List(Of CodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt1.Rows
                Dim item As New CodeNameModel
                item.CODE = CInt(CStr(row("BANK_CD")))
                item.NAME = CStr(row("BANK_NAME"))
                res.FURI_BANK_LIST.Add(item)
            Next
            res.FURI_SITEN_LIST = New List(Of CmCodeStrNameModel)
            For Each row As DataRow In dt2.Rows
                Dim item As New CmCodeStrNameModel
                item.CODE = CStr(row("SITEN_CD"))
                item.NAME = CStr(row("SITEN_NAME"))
                res.FURI_SITEN_LIST.Add(item)
            Next
            res.FURI_KOZA_SYUBETU_LIST = New List(Of CodeNameModel)
            For Each row As DataRow In dt3.Rows
                Dim item As New CodeNameModel
                item.CODE = CInt(CStr(row("MEISYO_CD")))
                item.NAME = CStr(row("MEISYO"))
                res.FURI_KOZA_SYUBETU_LIST.Add(item)
            Next
            Return res
        End Function

        ''' <summary>
        ''' 初期化処理_一覧画面
        ''' </summary>
        Public Shared Function GetInitKofuDetailResponse(dt1 As DataTable, dt2 As DataTable, dt3 As DataTable) As InitKofuDetailResponse
            Dim res = New InitKofuDetailResponse()

            res.KOFU_BANK_LIST = New List(Of CodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt1.Rows
                Dim item As New CodeNameModel
                item.CODE = CInt(CStr(row("BANK_CD")))
                item.NAME = CStr(row("BANK_NAME"))
                res.KOFU_BANK_LIST.Add(item)
            Next
            res.KOFU_SITEN_LIST = New List(Of CmCodeStrNameModel)
            For Each row As DataRow In dt2.Rows
                Dim item As New CmCodeStrNameModel
                item.CODE = CStr(row("SITEN_CD"))
                item.NAME = CStr(row("SITEN_NAME"))
                res.KOFU_SITEN_LIST.Add(item)
            Next
            res.KOFU_KOZA_SYUBETU_LIST = New List(Of CodeNameModel)
            For Each row As DataRow In dt3.Rows
                Dim item As New CodeNameModel
                item.CODE = CInt(CStr(row("MEISYO_CD")))
                item.NAME = CStr(row("MEISYO"))
                res.KOFU_KOZA_SYUBETU_LIST.Add(item)
            Next
            Return res
        End Function

        ''' <summary>
        ''' 検索処理_詳細画面処理
        ''' </summary>
        Public Shared Function GetSearchDetailResponse(dt As DataTable) As SearchDetailResponse
            'データ結果判定
            If dt.Rows.Count > 0 Then
                ' dt をループし、List にデータを追加します。
                Dim row As DataRow = dt.Rows(0)
                Dim item = New SearchDetailResponse()
                item.KYOKAI.KYOKAI_KBN = CInt(CStr(row("KYOKAI_KBN")))
                item.KYOKAI.KYOKAI_NAME = CStr(row("KYOKAI_NAME"))
                item.KYOKAI.JIGYO_NAME = CStr(row("JIGYO_NAME"))
                item.KYOKAI.YAKUMEI = CStr(row("YAKUMEI"))
                item.KYOKAI.KAICHO_NAME = CStr(row("KAICHO_NAME"))
                item.KYOKAI.YOBI1 = CStr(row("YOBI1"))
                item.KYOKAI.POST = CStr(row("POST"))
                item.KYOKAI.ADDR1 = CStr(row("ADDR1"))
                item.KYOKAI.ADDR2 = CStr(row("ADDR2"))
                item.KYOKAI.HAKKO_NO_KANJI = CStr(row("HAKKO_NO_KANJI"))
                item.KYOKAI.TEL1 = CStr(row("TEL1"))
                item.KYOKAI.FAX1 = CStr(row("FAX1"))
                item.KYOKAI.E_MAIL1 = CStr(row("E_MAIL1"))
                item.KYOKAI.TEL2 = CStr(row("TEL2"))
                item.KYOKAI.FAX2 = CStr(row("FAX2"))
                item.KYOKAI.E_MAIL2 = CStr(row("E_MAIL2"))
                item.KYOKAI.HP_URL = CStr(row("HP_URL"))
                item.KYOKAI.TOUROKU_NO = CStr(row("TOUROKU_NO"))
                item.KYOKAI.FURI_BANK_CD = CStr(row("FURI_BANK_CD"))
                item.KYOKAI.FURI_BANK_SITEN_CD = CStr(row("FURI_BANK_SITEN_CD"))
                item.KYOKAI.FURI_KOZA_SYUBETU = CInt(CStr(row("FURI_KOZA_SYUBETU")))
                item.KYOKAI.FURI_KOZA_NO = CStr(row("FURI_KOZA_NO"))
                item.KYOKAI.FURI_SYUBETU = CInt(CStr(row("FURI_SYUBETU")))
                item.KYOKAI.FURI_KOZA_MEIGI_KANA = CStr(row("FURI_KOZA_MEIGI_KANA"))
                item.KYOKAI.FURI_KOZA_MEIGI = CStr(row("FURI_KOZA_MEIGI"))
                item.KYOKAI.KOFU_BANK_CD = CStr(row("KOFU_BANK_CD"))
                item.KYOKAI.KOFU_BANK_SITEN_CD = CStr(row("KOFU_BANK_SITEN_CD"))
                item.KYOKAI.KOFU_KOZA_SYUBETU = CInt(CStr(row("KOFU_KOZA_SYUBETU")))
                item.KYOKAI.KOFU_KOZA_NO = CStr(row("KOFU_KOZA_NO"))
                item.KYOKAI.KOFU_SYUBETU = CInt(CStr(row("KOFU_SYUBETU")))
                item.KYOKAI.KOFU_CD_KBN = CInt(CStr(row("KOFU_CD_KBN")))
                item.KYOKAI.KOFU_KAISYA_CD = CInt(CStr(row("KOFU_KAISYA_CD")))
                item.KYOKAI.KOFU_KAISYA_NAME = CStr(row("KOFU_KAISYA_NAME"))
                item.KYOKAI.UP_DATE = CDate(row("UP_DATE"))
                Return item
            Else
                Return New SearchDetailResponse("該当デ一タが存在しませんでした。")
            End If
        End Function
    End Class

End Namespace
