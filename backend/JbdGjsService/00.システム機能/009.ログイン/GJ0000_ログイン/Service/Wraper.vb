' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ログイン
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋
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
            Dim tokenId = CStr(dt.Rows(0)("USER_ID")) & "|" & loginTime
            'トークンの取得
            res.TOKEN = CmTokenService.GetTokenGjs(tokenId, strGjs, strGjs)
            Return res
        End Function

        ''' <summary>
        ''' ログイン処理
        ''' </summary>
        Public Shared Function GetUserResponse(dt As DataTable) As UserInfoResponse
            Dim res = New UserInfoResponse()
            res.USER_ID = CStr(dt.Rows(0)("USER_ID"))
            res.USER_NAME = CStr(WordHenkan("N", "S", CStr(dt.Rows(0)("USER_NAME"))))
            res.ROLES = New List(Of String)
            res.ROLES.Add(CStr(dt.Rows(0)("SIYO_KBN")))
            Return res
        End Function

        ''' <summary>
        ''' ホーム情報処理
        ''' </summary>
        Public Shared Function GetHomeResponse(dt As DataTable) As HomeInfoResponse
            Dim res = New HomeInfoResponse()
            If dt.Rows.Count > 0 Then
                res.SHINKI = CLng(WordHenkan("N", "Z", dt.Rows(0)("CNT_SHINKI"))).ToString("##,###,##0")
                res.KEI = CLng(WordHenkan("N", "Z", dt.Rows(0)("CNT_KEI"))).ToString("##,###,##0")
                res.HASU = CLng(WordHenkan("N", "Z", dt.Rows(0)("HASU"))).ToString("##,###,##0").PadLeft(14)
                res.TUMI = CLng(WordHenkan("N", "Z", dt.Rows(0)("TUMI"))).ToString("##,###,##0").PadLeft(14)
            End If
            Return res
        End Function
    End Class
End Namespace
