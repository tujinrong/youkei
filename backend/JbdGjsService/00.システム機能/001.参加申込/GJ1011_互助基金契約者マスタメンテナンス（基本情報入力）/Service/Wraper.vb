' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタメンテナンス（基本情報入力）
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************


Namespace JBD.GJS.Service.GJ1011

    ''' <summary>
    ''' 互助基金契約者マスタメンテナンス（基本情報入力）
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 初期化処理_詳細画面
        ''' </summary>
        Public Shared Function InitDetailResponse(req As InitDetailRequest, dt1 As DataTable, dt2 As DataTable, dt3 As DataTable, dt5 As DataTable, dt6 As DataTable, dt7 As DataTable) As InitDetailResponse
            Dim res = New InitDetailResponse()
            Dim sWhere As String = String.Empty
            res.KEN_LIST = New List(Of CmCodeNameModel)
            res.KEIYAKU_KBN_LIST = New List(Of CmCodeNameModel)
            res.KEIYAKU_JYOKYO_LIST = New List(Of CmCodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt1.Rows
                Dim item As New CmCodeNameModel
                item.CODE = DaConvertUtil.CInt(DaConvertUtil.CStr(row("MEISYO_CD")))
                item.NAME = DaConvertUtil.CStr(row("MEISYO"))
                res.KEN_LIST.Add(item)
            Next

            For Each row As DataRow In dt2.Rows
                Dim item As New CmCodeNameModel
                item.CODE = DaConvertUtil.CInt(DaConvertUtil.CStr(row("MEISYO_CD")))
                item.NAME = DaConvertUtil.CStr(row("MEISYO"))
                res.KEIYAKU_KBN_LIST.Add(item)
            Next

            For Each row As DataRow In dt3.Rows
                Dim item As New CmCodeNameModel
                item.CODE = DaConvertUtil.CInt(DaConvertUtil.CStr(row("MEISYO_CD")))
                item.NAME = DaConvertUtil.CStr(row("MEISYO"))
                res.KEIYAKU_JYOKYO_LIST.Add(item)
            Next

            sWhere = "KI = " & req.KI
            Dim jdt = f_JimuItaku_Data_Select(sWhere)
            'データ結果判定
            If jdt.Rows.Count > 0 Then
                res.JIMUITAKU_LIST = New List(Of CmCodeNameModel)
                ' dt をループし、List にデータを追加します。
                For Each row As DataRow In jdt.Rows
                    Dim item As New CmCodeNameModel
                    item.CODE = DaConvertUtil.CInt(row("ITAKU_CD"))
                    item.NAME = DaConvertUtil.CStr(row("ITAKU_NAME"))
                    res.JIMUITAKU_LIST.Add(item)
                Next
            End If

            res.BANK_LIST = New List(Of CmStrCodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt5.Rows
                Dim item As New CmStrCodeNameModel

                item.CODE = DaConvertUtil.CStr(row("BANK_CD"))
                item.NAME = DaConvertUtil.CStr(row("BANK_NAME"))
                res.BANK_LIST.Add(item)
            Next

            res.SITEN_LIST = New List(Of CmStrCodeNameModel)
            If dt6 IsNot Nothing Then
                For Each row As DataRow In dt6.Rows
                    Dim item As New CmStrCodeNameModel
                    item.CODE = DaConvertUtil.CStr(row("SITEN_CD"))
                    item.NAME = DaConvertUtil.CStr(row("SITEN_NAME"))
                    res.SITEN_LIST.Add(item)
                Next
            End If

            res.KOZA_SYUBETU_LIST = New List(Of CmCodeNameModel)
            For Each row As DataRow In dt7.Rows
                Dim item As New CmCodeNameModel
                item.CODE = DaConvertUtil.CInt(CStr(row("MEISYO_CD")))
                item.NAME = DaConvertUtil.CStr(row("MEISYO"))
                res.KOZA_SYUBETU_LIST.Add(item)
            Next
            Return res
        End Function


        ''' <summary>
        ''' 検索処理_詳細画面
        ''' </summary>
        Public Shared Function SearchDetailResponse(ds As DataSet, ek As EnumEditKbn?) As SearchDetailResponse
            Dim item As New SearchDetailResponse()

            Select Case ek
                Case EnumEditKbn.Edit       '変更入力
                    Dim dt = ds.Tables(0)
                    If dt.Rows.Count > 0 Then
                        Dim row As DataRow = dt.Rows(0)
                        '期
                        item.KEIYAKUSYA.KI = DaConvertUtil.CInt(WordHenkan("N", "S", row("KI")))

                        '↓==========================================================================↓
                        '↓      申請者基本情報１                    　                              ↓
                        '↓==========================================================================↓

                        '契約者番号
                        item.KEIYAKUSYA.KEIYAKUSYA_CD = DaConvertUtil.CInt(WordHenkan("N", "S", row("KEIYAKUSYA_CD")))
                        '都道府県
                        item.KEIYAKUSYA.KEN_CD = DaConvertUtil.CInt(WordHenkan("N", "S", row("KEN_CD")))
                        '契約区分
                        item.KEIYAKUSYA.KEIYAKU_KBN = DaConvertUtil.CInt(WordHenkan("N", "S", row("KEIYAKU_KBN")))
                        '契約状況
                        item.KEIYAKUSYA.KEIYAKU_JYOKYO = DaConvertUtil.CInt(WordHenkan("N", "S", row("KEIYAKU_JYOKYO")))
                        '入金日、返還日
                        If Not IsDBNull(row("NYU_HEN_DATE")) AndAlso Not IsNothing(row("NYU_HEN_DATE")) Then
                            item.KEIYAKUSYA.NYU_HEN_DATE = DaConvertUtil.CNDate(row("NYU_HEN_DATE"))
                        End If
                        '契約日
                        If Not IsDBNull(row("KEIYAKU_DATE")) AndAlso Not IsNothing(row("KEIYAKU_DATE")) Then
                            item.KEIYAKUSYA.KEIYAKU_DATE = DaConvertUtil.CNDate(row("KEIYAKU_DATE"))
                        End If
                        '契約状況
                        item.KEIYAKUSYA.KEIYAKU_JYOKYO = DaConvertUtil.CInt(WordHenkan("N", "S", row("KEIYAKU_JYOKYO")))
                        '経営安定対策事業生産者番号
                        item.KEIYAKUSYA.SEISANSYA_CD = DaConvertUtil.CInt(WordHenkan("N", "S", row("SEISANSYA_CD")))
                        '日鶏協番号
                        item.KEIYAKUSYA.NIKKEIKYO_CD = DaConvertUtil.CInt(WordHenkan("N", "S", row("NIKKEIKYO_CD")))

                        '↓==========================================================================↓
                        '↓      申請者基本情報２                    　                              ↓
                        '↓==========================================================================↓

                        '契約者名
                        item.KEIYAKUSYA.KEIYAKUSYA_NAME = DaConvertUtil.CStr(WordHenkan("N", "S", row("KEIYAKUSYA_NAME")))
                        '契約者名（フリガナ）
                        item.KEIYAKUSYA.KEIYAKUSYA_KANA = DaConvertUtil.CStr(WordHenkan("N", "S", row("KEIYAKUSYA_KANA")))
                        '代表者名
                        item.KEIYAKUSYA.DAIHYO_NAME = DaConvertUtil.CStr(WordHenkan("N", "S", row("DAIHYO_NAME")))
                        '郵便番号
                        item.KEIYAKUSYA.ADDR_POST = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_POST")))
                        '住所１
                        item.KEIYAKUSYA.ADDR_1 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_1")))
                        '住所２
                        item.KEIYAKUSYA.ADDR_2 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_2")))
                        '住所３
                        item.KEIYAKUSYA.ADDR_3 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_3")))
                        '住所４
                        item.KEIYAKUSYA.ADDR_4 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_4")))
                        '電話番号1
                        item.KEIYAKUSYA.ADDR_TEL1 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_TEL1")))
                        '電話番号2
                        item.KEIYAKUSYA.ADDR_TEL2 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_TEL2")))
                        'ＦＡＸ
                        item.KEIYAKUSYA.ADDR_E_MAIL = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_E_MAIL")))
                        '事務委託先番号(変更前)
                        item.KEIYAKUSYA.OLD_JIMUITAKU_CD = DaConvertUtil.CInt(WordHenkan("N", "S", row("JIMUITAKU_CD")))
                        '事務委託先番号
                        item.KEIYAKUSYA.JIMUITAKU_CD = DaConvertUtil.CInt(WordHenkan("N", "S", row("JIMUITAKU_CD")))

                        '↓==========================================================================↓
                        '↓      申請者基本情報３                    　                              ↓
                        '↓==========================================================================↓

                        '振込先コード（金融機関）
                        item.KEIYAKUSYA.FURI_BANK_CD = DaConvertUtil.CStr(WordHenkan("N", "S", row("FURI_BANK_CD")))
                        '振込先支店コード
                        item.KEIYAKUSYA.FURI_BANK_SITEN_CD = DaConvertUtil.CStr(WordHenkan("N", "S", row("FURI_BANK_SITEN_CD")))
                        '口座種別
                        item.KEIYAKUSYA.FURI_KOZA_SYUBETU = DaConvertUtil.CInt(WordHenkan("N", "S", row("FURI_KOZA_SYUBETU")))
                        '口座番号
                        item.KEIYAKUSYA.FURI_KOZA_NO = DaConvertUtil.CStr(WordHenkan("N", "S", row("FURI_KOZA_NO")))
                        '口座名義人
                        item.KEIYAKUSYA.FURI_KOZA_MEIGI = DaConvertUtil.CStr(WordHenkan("N", "S", row("FURI_KOZA_MEIGI")))
                        '口座名義人（カナ）
                        item.KEIYAKUSYA.FURI_KOZA_MEIGI_KANA = DaConvertUtil.CStr(WordHenkan("N", "S", row("FURI_KOZA_MEIGI_KANA")))
                        '備考
                        item.KEIYAKUSYA.BIKO = DaConvertUtil.CStr(WordHenkan("N", "S", row("BIKO")))
                        '入力状況
                        item.KEIYAKUSYA.NYURYOKU_JYOKYO = DaConvertUtil.CInt(WordHenkan("N", "S", row("NYURYOKU_JYOKYO")))
                        '廃業日
                        If Not IsDBNull(row("HAIGYO_DATE")) AndAlso Not IsNothing(row("HAIGYO_DATE")) Then
                            item.KEIYAKUSYA.HAIGYO_DATE = DaConvertUtil.CNDate(row("HAIGYO_DATE"))
                        End If

                        item.KEIYAKUSYA.UP_DATE = DaConvertUtil.CNDate(row("UP_DATE"))
                        End If
            End Select

            Return item
        End Function
    End Class
End Namespace
