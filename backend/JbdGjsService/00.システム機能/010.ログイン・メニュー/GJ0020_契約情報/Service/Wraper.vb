' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 契約情報
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ0020

    ''' <summary>
    ''' ログイン
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' ホーム情報処理
        ''' </summary>
        Public Shared Function GetHomeResponse(dt As DataTable) As HomeInfoResponse
            Dim res = New HomeInfoResponse()
            If dt.Rows.Count > 0 Then
                res.KEIYAKUSU_SHINKI = DaConvertUtil.CInt(WordHenkan("N", "Z", dt.Rows(0)("CNT_SHINKI")))
                res.KEIYAKUSU_KEIZOKU = DaConvertUtil.CInt(WordHenkan("N", "Z", dt.Rows(0)("CNT_KEI")))
                res.HASU = DaConvertUtil.CLng(WordHenkan("N", "Z", dt.Rows(0)("HASU")))
                res.TUMITATE_KIN = DaConvertUtil.CLng(WordHenkan("N", "Z", dt.Rows(0)("TUMI")))
            End If
            Return res
        End Function
    End Class
End Namespace
