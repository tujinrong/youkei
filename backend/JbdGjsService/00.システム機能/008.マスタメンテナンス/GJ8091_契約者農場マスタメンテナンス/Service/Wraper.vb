' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 契約者農場マスタメンテナンス
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋
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
            res.KEN_CD_NAME_LIST = New List(Of CodeNameModel)
            ' dt をループし、List にデータを追加します。
            For Each row As DataRow In dt.Rows
                Dim item As New CodeNameModel
                item.CODE = Cint(row("MEISYO_CD").ToString())
                item.NAME = row("MEISYO").ToString()
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
            item.KEN_CD_NAME_LIST = New List(Of CodeNameModel)
            For Each row As DataRow In dt.Rows
                Dim it As New CodeNameModel
                it.CODE = Cint(row("MEISYO_CD").ToString())
                it.NAME = row("MEISYO").ToString()
                item.KEN_CD_NAME_LIST.Add(it)
            Next

            '契約者農場情報処理
            Select Case ek
                Case EnumEditKbn.Edit       '変更入力
                    dt = ds.Tables(1)
                    If dt.Rows.Count > 0 Then
                        Dim row As DataRow = dt.Rows(0)
                        item.KEIYAKUSYA_NOJO.KI = Cint(row("KI").ToString())
                        item.KEIYAKUSYA_NOJO.KEIYAKUSYA_CD = Cint(row("KEIYAKUSYA_CD").ToString())
                        item.KEIYAKUSYA_NOJO.NOJO_CD = Cint(row("NOJO_CD").ToString())
                        item.KEIYAKUSYA_NOJO.NOJO_NAME = row("NOJO_NAME").ToString()
                        item.KEIYAKUSYA_NOJO.KEN_CD = Cint(row("KEN_CD").ToString())
                        item.KEIYAKUSYA_NOJO.ADDR_POST = row("ADDR_POST").ToString()
                        item.KEIYAKUSYA_NOJO.ADDR_1 = row("ADDR_1").ToString()
                        item.KEIYAKUSYA_NOJO.ADDR_2 = row("ADDR_2").ToString()           
                        item.KEIYAKUSYA_NOJO.ADDR_3 = row("ADDR_3").ToString()  
                        item.KEIYAKUSYA_NOJO.ADDR_4 = row("ADDR_4").ToString()  
                        item.KEIYAKUSYA_NOJO.MEISAI_NO = Cint(row("MEISAI_NO").ToString())
                        item.KEIYAKUSYA_NOJO.UP_DATE = Cdate(row("UP_DATE"))
                    End If
            End Select

            Return item
        End Function
    End Class
End Namespace
