' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 支店マスタメンテナンス
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8052

    ''' <summary>
    ''' 金融機関マスタメンテナンス
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 検索処理_詳細画面処理
        ''' </summary>
        Public Shared Function InitBankDetailResponse(ds As DataSet, ek As EnumEditKbn?) As InitSitenDetailResponse
            Dim item As New InitSitenDetailResponse()

            '契約者農場情報処理
            Select Case ek
                Case EnumEditKbn.Edit       '変更入力
                    Dim dt = ds.Tables(0)
                    If dt.Rows.Count > 0 Then
                        Dim row As DataRow = dt.Rows(0)
                        '金融機関コード
                        item.SITEN.BANK_CD = DaConvertUtil.CStr(WordHenkan("N", "S", row("BANK_CD")))
                        '支店コード
                        item.SITEN.SITEN_CD = DaConvertUtil.CStr(WordHenkan("N", "S", row("SITEN_CD")))
                        '支店名（ｶﾅ）
                        item.SITEN.SITEN_KANA = DaConvertUtil.CStr(WordHenkan("N", "S", row("SITEN_KANA")))
                        '支店名（漢字）
                        item.SITEN.SITEN_NAME = DaConvertUtil.CStr(WordHenkan("N", "S", row("SITEN_NAME")))
                        item.SITEN.UP_DATE = DaConvertUtil.CNDate( row("UP_DATE"))
                    End If
            End Select

            Return item
        End Function
    End Class
End Namespace
