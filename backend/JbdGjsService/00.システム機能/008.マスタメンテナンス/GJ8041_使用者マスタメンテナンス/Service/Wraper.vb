' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 使用者マスタメンテナンス
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8041

    ''' <summary>
    ''' 使用者マスタメンテナンス
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 検索処理_詳細画面処理
        ''' </summary>
        Public Shared Function InitDetailResponse(ds As DataSet, dt2 As DataTable, ek As EnumEditKbn?) As InitDetailResponse
            Dim dt = ds.Tables(0)
            Dim item As New InitDetailResponse()

            '使用区分情報プルダウンリスト
            item.SIYO_KBN_LIST = New List(Of CmCodeNameModel)
            For Each row As DataRow In dt2.Rows
                Dim it As New CmCodeNameModel
                it.CODE = DaConvertUtil.CInt(DaConvertUtil.CStr(row("MEISYO_CD")))
                it.NAME = DaConvertUtil.CStr(row("MEISYO"))
                item.SIYO_KBN_LIST.Add(it)
            Next

            '使用者情報
            Select Case ek
                Case EnumEditKbn.Edit       '変更入力
                    dt = ds.Tables(1)
                    If dt.Rows.Count > 0 Then
                        Dim row As DataRow = dt.Rows(0)
                        item.USER.USER_ID = DaConvertUtil.CStr(WordHenkan("N", "S", row("USER_ID")))
                        item.USER.USER_NAME = DaConvertUtil.CStr(WordHenkan("N", "S", row("USER_NAME")))
                        item.USER.PASS = DaConvertUtil.CStr(WordHenkan("N", "S", row("PASS")))
                        item.USER.PASS_KIGEN_DATE = DaConvertUtil.CDate(row("PASS_KIGEN_DATE"))
                        item.USER.PASS_UP_DATE = DaConvertUtil.CDate(row("PASS_UP_DATE"))
                        item.USER.SIYO_KBN = DaConvertUtil.CInt(WordHenkan("N", "Z", row("SIYO_KBN")))
                        item.USER.TEISI_DATE = DaConvertUtil.CDate(row("TEISI_DATE"))
                        item.USER.TEISI_RIYU = DaConvertUtil.CStr(row("TEISI_RIYU"))
                        item.USER.UP_DATE = DaConvertUtil.CDate(row("UP_DATE"))
                    End If
            End Select

            Return item
        End Function
    End Class
End Namespace
