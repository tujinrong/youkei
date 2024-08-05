' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ログイン
'             サービス処理
' 作成日　　: 2024.07.21
' 作成者　　: AIPlus
' 変更履歴　:
' *******************************************************************

Imports System.Data
Imports BusinessService.JBD.GJS.Db

Namespace JBD.GJS.Service.GJ0000
    <ComponentModel.DisplayName("ログイン")>
    Public Class Service
        Inherits CmServiceBase
        <ComponentModel.DisplayName("ログイン処理")>
        Public Function Login(req As LoginRequest) As LoginResponse
            Return Nolock(req, Function(db)
                Dim res = New LoginResponse()
                Dim sSql As String = String.Empty
                Dim dstDataSet As New DataSet

                Try
                    '検索結果出力用ＳＱＬ作成 
                    If Not f_Search_SQLMake(sSql, req.USER_ID, res) Then
                        Exit Try
                    End If

                    'データSelect
                    If Not f_Select_ODP(dstDataSet, sSql, res, db) Then
                        Exit Try
                    End If

                    If dstDataSet.Tables(0).Rows.Count > 0 Then
                        '画面に該当データを表示
                        '画面にセット
                        If Not f_User_Check(dstDataSet, req.PASS, req.USER_ID, res) Then
                            Exit Try
                        End If

                        'トークンの設定
                        Dim loginTime = DateTime.Now.ToString("yyyyMMddHHmmss")
                        Dim tokenId = req.USER_ID & "|" & loginTime

                        'トークンの取得
                        res.token = DaTokenService.GetTokenGjs(tokenId, "gjs", "gjs")
                    Else
                        'データ存在なし
                        res.SetServiceError("W019 ユーザーＩＤ、パスワードが正しくありません。")
                    End If

                    dstDataSet.Clear()

                Catch ex As Exception
                    '共通例外処理
                    res.SetServiceError(ex.Message)
                Finally

                End Try


            '正常返し
            Return res

            End Function)

        End Function


        <ComponentModel.DisplayName("ユーザー情報を取得する")>
        Public Function GetUserInfo(req As Object) As UserInfoResponse
            Return Nolock(req, Function(db)
                Dim res = New UserInfoResponse()
                Dim sSql As String = String.Empty
                Dim dstDataSet As New DataSet
                Dim tokenStr = req.token
                
                'トークンの取得
                Dim userIdStr = DaTokenService.GetTokenUDGjs(tokenStr, "gjs", "gjs")
                Dim userId = userIdStr.Split("|")
                res.userid = userId(0)
                db.Session.UserID = userId(0)
                
                Try
                    '検索結果出力用ＳＱＬ作成 
                    If Not f_Search_SQLMake(sSql, res.userid, res) Then
                        Exit Try
                    End If

                    'データSelect
                    If Not f_Select_ODP(dstDataSet, sSql, res, db) Then
                        Exit Try
                    End If

                    If dstDataSet.Tables(0).Rows.Count > 0 Then
                        res.usernm = WordHenkan("N", "S", dstDataSet.Tables(0).Rows(0)("USER_NAME").ToString())
                        res.Roles = New List(Of String)
                        res.Roles.Add(dstDataSet.Tables(0).Rows(0)("SIYO_KBN").ToString())
                    Else
                        'データ存在なし
                        res.SetServiceError("W019 ユーザーＩＤ、パスワードが正しくありません。")
                    End If

                    dstDataSet.Clear()

                Catch ex As Exception
                    '共通例外処理
                    res.SetServiceError(ex.Message)
                Finally

                End Try

                '正常返し
                Return res

            End Function)

        End Function

    End Class
End Namespace
