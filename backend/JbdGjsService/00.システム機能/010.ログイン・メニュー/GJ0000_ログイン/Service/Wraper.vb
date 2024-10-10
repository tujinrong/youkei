' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: ログイン
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ0000

    ''' <summary>
    ''' ログイン
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' ログイン処理
        ''' </summary>
        Public Shared Function GetLoginResponse(dt As DataTable) As LoginResponse
            Dim res = New LoginResponse()
            'トークンの設定
            Dim loginTime = DateTime.Now.ToString("yyyyMMddHHmmss")
            Dim tokenId = DaConvertUtil.CStr(dt.Rows(0)("USER_ID")) & "|" & loginTime
            'トークンの取得
            res.TOKEN = CmTokenService.GetTokenGjs(tokenId, FrmService.strGjs, FrmService.strGjs)
            Return res
        End Function

    End Class
End Namespace
