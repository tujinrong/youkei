' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 事務委託先マスタメンテナンス
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.09.27
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8061

    ''' <summary>
    ''' 事務委託先マスタメンテナンス
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 検索処理_詳細画面処理
        ''' </summary>
        Public Shared Function InitDetailResponse(ds As DataSet, ek As EnumEditKbn?) As InitDetailResponse
            Dim dt = ds.Tables(0)
            Dim item As New InitDetailResponse()

            '都道府県情報プルダウンリスト
            item.KEN_LIST = New List(Of CmCodeNameModel)
            For Each row As DataRow In dt.Rows
                Dim it As New CmCodeNameModel
                it.CODE = DaConvertUtil.CInt(DaConvertUtil.CStr(row("MEISYO_CD")))
                it.NAME = DaConvertUtil.CStr(row("MEISYO"))
                item.KEN_LIST.Add(it)
            Next

            '事務委託先情報
            Select Case ek
                Case EnumEditKbn.Edit       '変更入力
                    dt = ds.Tables(1)
                    If dt.Rows.Count > 0 Then
                        Dim row As DataRow = dt.Rows(0)
                        item.ITAKU.KI = DaConvertUtil.CInt(WordHenkan("N", "Z", row("KI")))
                        item.ITAKU.ITAKU_CD = DaConvertUtil.CInt(WordHenkan("N", "Z", row("ITAKU_CD")))
                        If Not String.IsNullOrEmpty( row("KEN_CD").ToString())
                            item.ITAKU.KEN_CD = DaConvertUtil.CInt(WordHenkan("N", "S", row("KEN_CD")))
                        End If
                        item.ITAKU.ITAKU_NAME = DaConvertUtil.CStr(WordHenkan("N", "S", row("ITAKU_NAME")))
                        item.ITAKU.ITAKU_RYAKU = DaConvertUtil.CStr(WordHenkan("N", "S", row("ITAKU_RYAKU")))
                        item.ITAKU.DAIHYO_NAME = DaConvertUtil.CStr(WordHenkan("N", "S", row("DAIHYO_NAME")))
                        item.ITAKU.TANTO_NAME = DaConvertUtil.CStr(WordHenkan("N", "S", row("TANTO_NAME")))
                        item.ITAKU.ADDR_POST = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_POST")))
                        item.ITAKU.ADDR_1 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_1")))
                        item.ITAKU.ADDR_2 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_2")))
                        item.ITAKU.ADDR_3 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_3")))
                        item.ITAKU.ADDR_4 = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_4")))
                        item.ITAKU.ADDR_TEL = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_TEL")))
                        item.ITAKU.ADDR_FAX = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_FAX")))
                        item.ITAKU.ADDR_E_MAIL = DaConvertUtil.CStr(WordHenkan("N", "S", row("ADDR_E_MAIL")))
                        If Not String.IsNullOrEmpty( row("BANK_INJI_KBN").ToString())
                            item.ITAKU.BANK_INJI_KBN = DaConvertUtil.CInt(WordHenkan("N", "S", row("BANK_INJI_KBN")))
                        End If
                        If Not String.IsNullOrEmpty( row("MATOMESAKI").ToString())
                            item.ITAKU.MATOMESAKI = DaConvertUtil.CInt(row("MATOMESAKI"))
                        End If
                        item.ITAKU.MOSIKOMISYORUI = DaConvertUtil.CStr(WordHenkan("N", "S", row("MOSIKOMISYORUI")))
                        item.ITAKU.SEIKYUSYO = DaConvertUtil.CStr(WordHenkan("N", "S", row("SEIKYUSYO")))
                        item.ITAKU.NYUKINHOHO = DaConvertUtil.CStr(WordHenkan("N", "S", row("NYUKINHOHO")))
                        If Not String.IsNullOrEmpty( row("MATOMESAKI").ToString())
                            item.ITAKU.LABELHAKKO = DaConvertUtil.CInt(WordHenkan("N", "S", row("LABELHAKKO")))
                        End If
                        If Not String.IsNullOrEmpty( row("MATOMESAKI").ToString())
                            item.ITAKU.JYOGAI_FLG = DaConvertUtil.CInt(WordHenkan("N", "S", row("JYOGAI_FLG")))
                        End If
                        item.ITAKU.BIKO = DaConvertUtil.CStr(WordHenkan("N", "S", row("BIKO")))
                        If Not String.IsNullOrEmpty( row("UP_DATE").ToString())
                            item.ITAKU.UP_DATE = DaConvertUtil.CDate(row("UP_DATE"))
                        End If
                    End If
            End Select

            Return item
        End Function
    End Class
End Namespace
