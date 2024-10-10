' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: メニュー
' 　　　　　　DB項目から画面項目に変換
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ0010

    ''' <summary>
    ''' メニュー
    ''' </summary>
    Public Class Wraper
        Inherits Common.Wraper

        ''' <summary>
        ''' メニュー処理
        ''' </summary>
        Public Shared Function GetUserResponse(dt As DataTable) As UserInfoResponse
            If dt.Rows.Count > 0 Then
                Dim res = New UserInfoResponse()
                res.USER_ID = DaConvertUtil.CStr(dt.Rows(0)("USER_ID"))
                res.USER_NAME = DaConvertUtil.CStr(WordHenkan("N", "S", DaConvertUtil.CStr(dt.Rows(0)("USER_NAME"))))
                res.ROLES = New List(Of String)
                res.ROLES.Add(DaConvertUtil.CStr(dt.Rows(0)("SIYO_KBN")))
                Return res
            Else
                Return New UserInfoResponse("ユーザーＩＤ、パスワードが正しくありません。")
            End If
        End Function

    End Class
End Namespace
