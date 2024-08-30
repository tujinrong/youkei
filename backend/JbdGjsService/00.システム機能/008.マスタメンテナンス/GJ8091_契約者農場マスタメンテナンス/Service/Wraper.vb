' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 契約者農場マスタメンテナンス
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8091

    ''' <summary>
    ''' 契約者農場マスタメンテナンス
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 初期化処理_詳細画面処理
        ''' </summary>
        Public Shared Function GetInitDetailResponse(dt As DataTable) As InitDetailResponse
            Dim res = New InitDetailResponse()
            res.KEN_CD_NAME_LIST = New List(Of CmCodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt.Rows
                Dim item As New CmCodeNameModel
                item.CODE = CInt(CStr(row("MEISYO_CD")))
                item.NAME = CStr(row("MEISYO"))
                res.KEN_CD_NAME_LIST.Add(item)
            Next
            Return res
        End Function

        ''' <summary>
        ''' 検索処理_詳細画面処理
        ''' </summary>
        Public Shared Function InitDetailResponse(ds As DataSet, ek As EnumEditKbn?) As InitDetailResponse
            Dim dt = ds.Tables(0)
            Dim item As New InitDetailResponse()

            '都道府県情報処理
            item.KEN_CD_NAME_LIST = New List(Of CmCodeNameModel)
            For Each row As DataRow In dt.Rows
                Dim it As New CmCodeNameModel
                it.CODE = Cint(CStr(row("MEISYO_CD")))
                it.NAME = CStr(row("MEISYO"))
                item.KEN_CD_NAME_LIST.Add(it)
            Next

            '契約者農場情報処理
            Select Case ek
                Case EnumEditKbn.Edit       '変更入力
                    dt = ds.Tables(1)
                    If dt.Rows.Count > 0 Then
                        Dim row As DataRow = dt.Rows(0)
                        item.KEIYAKUSYA_NOJO.KI = Cint(CStr(row("KI")))
                        item.KEIYAKUSYA_NOJO.KEIYAKUSYA_CD = Cint(CStr(row("KEIYAKUSYA_CD")))
                        item.KEIYAKUSYA_NOJO.NOJO_CD = Cint(CStr(row("NOJO_CD")))
                        item.KEIYAKUSYA_NOJO.NOJO_NAME = CStr(row("NOJO_NAME"))
                        item.KEIYAKUSYA_NOJO.KEN_CD = Cint(CStr(row("KEN_CD")))
                        item.KEIYAKUSYA_NOJO.ADDR_POST = CStr(row("ADDR_POST"))
                        item.KEIYAKUSYA_NOJO.ADDR_1 = CStr(row("ADDR_1"))
                        item.KEIYAKUSYA_NOJO.ADDR_2 = CStr(row("ADDR_2"))
                        If String.IsNullOrEmpty( row("ADDR_3").ToString())
                            item.KEIYAKUSYA_NOJO.ADDR_3 = String.Empty
                        Else
                            item.KEIYAKUSYA_NOJO.ADDR_3 = CStr(row("ADDR_3"))  
                        End If
                        If String.IsNullOrEmpty( row("ADDR_4").ToString())
                            item.KEIYAKUSYA_NOJO.ADDR_4 = String.Empty
                        Else
                            item.KEIYAKUSYA_NOJO.ADDR_4 = CStr(row("ADDR_4"))  
                        End If
                        item.KEIYAKUSYA_NOJO.MEISAI_NO = Cint(CStr(row("MEISAI_NO")))
                        item.KEIYAKUSYA_NOJO.UP_DATE = Cdate(row("UP_DATE"))
                    End If
            End Select

            Return item
        End Function
    End Class
End Namespace
