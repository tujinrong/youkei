' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 互助基金契約者マスタメンテナンス（農場情報入力）
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ1013

    ''' <summary>
    ''' 互助基金契約者マスタメンテナンス（農場情報入力）
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper
        ''' <summary>
        ''' 検索処理_一覧画面処理
        ''' </summary>
        Public Shared Function SearchResponse(dt As DataTable) As SearchResponse
            Dim res = New SearchResponse()

            If dt.Rows.Count > 0 Then
                res.NOJO_JOHO_LIST = New List(Of NojoJohoVM)
                ' dt をループし、List にデータを追加します。
                For Each row As DataRow In dt.Rows
                    Dim item As New NojoJohoVM
                    item.NOJO_CD = DaConvertUtil.CInt(row("NOJO_CD"))
                    item.NOJO_NAME = DaConvertUtil.CStr(row("NOJO_NM"))
                    item.ADDR = DaConvertUtil.CStr(row("ADDR"))
                    res.NOJO_JOHO_LIST.Add(item)
                Next
            End If
            Return res
        End Function

        ''' <summary>
        ''' 検索処理_詳細画面処理
        ''' </summary>
        Public Shared Function InitDetailResponse(ds As DataSet, ek As EnumEditKbn?) As InitDetailResponse
            Dim dt = ds.Tables(0)
            Dim item As New InitDetailResponse()

            '都道府県情報処理
            item.KEN_LIST = New List(Of CmCodeNameModel)
            For Each row As DataRow In dt.Rows
                Dim it As New CmCodeNameModel
                it.CODE = DaConvertUtil.CInt(DaConvertUtil.CStr(row("MEISYO_CD")))
                it.NAME = DaConvertUtil.CStr(row("MEISYO"))
                item.KEN_LIST.Add(it)
            Next

            '契約者農場情報処理
            Select Case ek
                Case EnumEditKbn.Edit       '変更入力
                    dt = ds.Tables(1)
                    If dt.Rows.Count > 0 Then
                        Dim row As DataRow = dt.Rows(0)
                        item.NOJO_JOHO.KI = DaConvertUtil.CInt(DaConvertUtil.CStr(row("KI")))
                        item.NOJO_JOHO.KEIYAKUSYA_CD = DaConvertUtil.CInt(DaConvertUtil.CStr(row("KEIYAKUSYA_CD")))
                        item.NOJO_JOHO.NOJO_CD = DaConvertUtil.CInt(DaConvertUtil.CStr(row("NOJO_CD")))
                        item.NOJO_JOHO.NOJO_NAME = DaConvertUtil.CStr(row("NOJO_NAME"))
                        item.NOJO_JOHO.KEN_CD = DaConvertUtil.CInt(DaConvertUtil.CStr(row("KEN_CD")))
                        item.NOJO_JOHO.ADDR_POST = DaConvertUtil.CStr(row("ADDR_POST"))
                        item.NOJO_JOHO.ADDR_1 = DaConvertUtil.CStr(row("ADDR_1"))
                        item.NOJO_JOHO.ADDR_2 = DaConvertUtil.CStr(row("ADDR_2"))
                        If String.IsNullOrEmpty(row("ADDR_3").ToString()) Then
                            item.NOJO_JOHO.ADDR_3 = String.Empty
                        Else
                            item.NOJO_JOHO.ADDR_3 = CStr(row("ADDR_3"))
                        End If
                        If String.IsNullOrEmpty(row("ADDR_4").ToString()) Then
                            item.NOJO_JOHO.ADDR_4 = String.Empty
                        Else
                            item.NOJO_JOHO.ADDR_4 = DaConvertUtil.CStr(row("ADDR_4"))
                        End If
                        item.NOJO_JOHO.MEISAI_NO = DaConvertUtil.CInt(DaConvertUtil.CStr(row("MEISAI_NO")))
                        item.NOJO_JOHO.UP_DATE = DaConvertUtil.CDate(row("UP_DATE"))
                    End If
            End Select

            Return item
        End Function
    End Class
End Namespace
