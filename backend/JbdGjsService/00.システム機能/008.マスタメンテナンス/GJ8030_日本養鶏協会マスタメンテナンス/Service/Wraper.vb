' *******************************************************************
' 業務名称　: 互助事業システム
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
        Public Shared Function GetInitDetailResponse(dt1 As DataTable, dt2 As DataTable, dt3 As DataTable) As InitDetailResponse
            Dim res = New InitDetailResponse()

            res.BANK_LIST = New List(Of CmStrCodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt1.Rows
                Dim item As New CmStrCodeNameModel

                item.CODE = CStr(row("BANK_CD"))
                item.NAME = CStr(row("BANK_NAME"))
                res.BANK_LIST.Add(item)
            Next
            res.SITEN_LIST = New List(Of CmStrCodeNameModel)
            For Each row As DataRow In dt2.Rows
                Dim item As New CmStrCodeNameModel
                item.CODE = CStr(row("SITEN_CD"))
                item.NAME = CStr(row("SITEN_NAME"))
                res.SITEN_LIST.Add(item)
            Next
            res.KOZA_SYUBETU_LIST = New List(Of CmCodeNameModel)
            For Each row As DataRow In dt3.Rows
                Dim item As New CmCodeNameModel
                item.CODE = CInt(CStr(row("MEISYO_CD")))
                item.NAME = CStr(row("MEISYO"))
                res.KOZA_SYUBETU_LIST.Add(item)
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
                '協会名称 ”社団法人　日本養鶏協会”
                item.KYOKAI.KYOKAI_NAME = CStr(WordHenkan("N", "S", row("KYOKAI_NAME")))
                '役職名 ”会長”
                item.KYOKAI.YAKUMEI = CStr(WordHenkan("N", "S", row("YAKUMEI")))
                '会長名 
                item.KYOKAI.KAICHO_NAME = CStr(WordHenkan("N", "S", row("KAICHO_NAME")))

                '事業名
                item.KYOKAI.JIGYO_NAME = CStr(WordHenkan("N", "S", row("JIGYO_NAME")))
                '予備１
                item.KYOKAI.YOBI1 = CStr(WordHenkan("N", "S", row("YOBI1")))

                '郵便番号
                item.KYOKAI.POST = CStr(WordHenkan("N", "S", row("POST")))
                '住所１
                item.KYOKAI.ADDR1 = CStr(WordHenkan("N", "S", row("ADDR1")))
                '住所２
                item.KYOKAI.ADDR2 = CStr(WordHenkan("N", "S", row("ADDR2")))

                '電話番号１ 連絡先１
                item.KYOKAI.TEL1 = CStr(WordHenkan("N", "S", row("TEL1")))
                'ＦＡＸ１
                item.KYOKAI.FAX1 = CStr(WordHenkan("N", "S", row("FAX1")))
                'Ｅ－ｍａｉｌ１
                item.KYOKAI.E_MAIL1 = CStr(WordHenkan("N", "S", row("E_MAIL1")))

                '電話番号２ 連絡先２
                item.KYOKAI.TEL2 = CStr(WordHenkan("N", "S", row("TEL2")))
                'ＦＡＸ２
                item.KYOKAI.FAX2 = CStr(WordHenkan("N", "S", row("FAX2")))
                'Ｅ－ｍａｉｌ２
                item.KYOKAI.E_MAIL2 = CStr(WordHenkan("N", "S", row("E_MAIL2")))
                'ホームページURL
                item.KYOKAI.HP_URL = CStr(WordHenkan("N", "S", row("HP_URL")))

                '登録番号  2023/08/04 JBD454 R5年度インボイス対応 ADD
                item.KYOKAI.TOUROKU_NO = CStr(WordHenkan("N", "S", row("TOUROKU_NO")))

                '発行番号・漢字
                item.KYOKAI.HAKKO_NO_KANJI = CStr(WordHenkan("N", "S", row("HAKKO_NO_KANJI")))

                '--------------------
                '振込口座情報
                '--------------------
                '交付金支払口座（金融機関） 交付金の支払い金融機関情報
                item.KYOKAI.FURI_BANK_CD = CStr(WordHenkan("N", "S", row("FURI_BANK_CD")))
                '支払先支店コード
                item.KYOKAI.FURI_BANK_SITEN_CD = CStr(WordHenkan("N", "S", row("FURI_BANK_SITEN_CD")))
                '口座種別
                item.KYOKAI.FURI_KOZA_SYUBETU = CInt(WordHenkan("N", "S", row("FURI_KOZA_SYUBETU")))
                '口座番号
                item.KYOKAI.FURI_KOZA_NO = CStr(WordHenkan("N", "S", row("FURI_KOZA_NO")))
                '種別コード
                item.KYOKAI.FURI_SYUBETU = CInt(WordHenkan("N", "S", row("FURI_SYUBETU")))
                '口座名義人
                item.KYOKAI.FURI_KOZA_MEIGI = CStr(WordHenkan("N", "S", row("FURI_KOZA_MEIGI")))
                '口座名義人（カナ）
                item.KYOKAI.FURI_KOZA_MEIGI_KANA = CStr(WordHenkan("N", "S", row("FURI_KOZA_MEIGI_KANA")))

                '--------------------
                '支払口座情報
                '--------------------
                '交付金支払口座（金融機関） 交付金の支払い金融機関情報
                item.KYOKAI.KOFU_BANK_CD = CStr(WordHenkan("N", "S", row("KOFU_BANK_CD")))
                '支払先支店コード
                item.KYOKAI.KOFU_BANK_SITEN_CD = CStr(WordHenkan("N", "S", row("KOFU_BANK_SITEN_CD")))
                '口座種別
                item.KYOKAI.KOFU_KOZA_SYUBETU = CInt(WordHenkan("N", "S", row("KOFU_KOZA_SYUBETU")))
                '口座番号
                item.KYOKAI.KOFU_KOZA_NO = CStr(WordHenkan("N", "S", row("KOFU_KOZA_NO")))
                '種別コード
                item.KYOKAI.KOFU_SYUBETU = CInt(WordHenkan("N", "S", row("KOFU_SYUBETU")))
                'コード区分
                item.KYOKAI.KOFU_CD_KBN = CInt(WordHenkan("N", "S", row("KOFU_CD_KBN")))
                ''依頼人コード
                item.KYOKAI.KOFU_KAISYA_CD = CInt(WordHenkan("N", "S", row("KOFU_KAISYA_CD")))
                '振込依頼人名
                item.KYOKAI.KOFU_KAISYA_NAME = CStr(WordHenkan("N", "S", row("KOFU_KAISYA_NAME")))

                item.KYOKAI.UP_DATE = CDate(row("UP_DATE"))
                Return item
            Else
                Return New SearchDetailResponse("該当デ一タが存在しませんでした。")
            End If
        End Function
    End Class

End Namespace
