' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 金融機関マスタメンテナンス
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8051

    ''' <summary>
    ''' 金融機関マスタメンテナンス
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' 検索処理_詳細画面処理
        ''' </summary>
        Public Shared Function InitBankDetailResponse(ds As DataSet, ek As EnumEditKbn?) As InitBankDetailResponse
            Dim dt = ds.Tables(0)
            Dim item As New InitBankDetailResponse()

            '契約者農場情報処理
            Select Case ek
                Case EnumEditKbn.Edit       '変更入力
                    dt = ds.Tables(1)
                    If dt.Rows.Count > 0 Then
                        Dim row As DataRow = dt.Rows(0)
                        '金融機関コード
                        item.BANK.BANK_CD = CStr(WordHenkan("N", "S", row("BANK_CD")))
                        '金融機関名（ｶﾅ）
                        item.BANK.BANK_KANA = CStr(WordHenkan("N", "S", row("BANK_KANA")))
                        '金融機関名（漢字）
                        item.BANK.BANK_NAME = CStr(WordHenkan("N", "S", row("BANK_NAME")))
                    End If
            End Select

            Return item
        End Function
    End Class
End Namespace
