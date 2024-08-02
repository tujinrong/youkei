' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ロジック共通関数
'
' 作成日　　: 2023.05.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports BusinessService.Jbd.Gjs.Db
Imports BusinessService.Jbd.Gjs.Service.GJ0000
Imports Oracle.ManagedDataAccess.Client
Imports System.Data
Imports System.Text
Imports System.Security.Cryptography

Namespace Jbd.Gjs.Service
    Public Module JbdGjsLogicUtil
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :検索結果出力用ＳＱＬ作成
        '引数            :無し
        '戻り値          :String(SQL文)
        '更新日          :
        '------------------------------------------------------------------
        Public Function f_Search_SQLMake(ByRef sSql As String, userId As String, ByRef res As Object) As Boolean
            Dim blnRet As Boolean = False

            Try
                '検索
                sSql = " SELECT " & vbCrLf
                sSql += "     U.USER_NAME USER_NAME, " & vbCrLf
                sSql += "     U.PASS PASS, " & vbCrLf
                sSql += "     U.PASS_KIGEN_DATE PASS_KIGEN_DATE, " & vbCrLf
                sSql += "     U.SIYO_KBN SIYO_KBN, " & vbCrLf
                sSql += "     U.TEISI_DATE TEISI_DATE " & vbCrLf
                sSql += " FROM" & vbCrLf
                sSql += "     TM_USER U " & vbCrLf
                'WHERE条件句を作成
                sSql += " WHERE" & vbCrLf
                sSql += "    (U.USER_ID = '" & userId.TrimEnd & "')" & vbCrLf
                blnRet = True
            Catch ex As Exception
                '共通例外処理
                res.SetServiceError(ex.Message)
            End Try

            Return blnRet

        End Function


        '------------------------------------------------------------------
        'プロシージャ名  :f_User_Check
        '説明            :ログインユーザー情報チェック処理
        '引数            :無し
        '戻り値          :String(SQL文)
        '更新日          :
        '------------------------------------------------------------------
        Public Function f_User_Check(ByVal dstDataSet As DataSet, passWord As String, userId As String, ByRef res As Object) As Boolean

            Dim blnRet As Boolean = False

            Try

                With dstDataSet.Tables(0)

                    'パスワードチェック
                    Dim sPassWord = WordHenkan("N", "S", .Rows(0)("PASS")).ToString.TrimEnd
                    Dim passWordSha256 = ComputeSHA256Hash(sPassWord, userId)
                    If passWord.TrimEnd.ToUpper() <> passWordSha256 Then
                        res.SetServiceError("W019 ユーザーＩＤ、パスワードが正しくありません。")
                        Exit Try
                    End If

                    'パスワード有効期限チェック
                    If .Rows(0)("PASS_KIGEN_DATE") < Now Then
                        'パスワード有効期限切れ
                        res.SetServiceError("W019 使用できません。管理者に確認してください。")
                        Exit Try
                    End If

                    '利用停止チェック
                    If Not .Rows(0)("TEISI_DATE") Is DBNull.Value Then
                        '利用停止ユーザー
                        res.SetServiceError("W019 使用できません。管理者に確認してください 。")
                        Exit Try
                    End If
                    blnRet = True
                End With

            Catch ex As Exception
                '共通例外処理
                res.SetServiceError(ex.Message)
            End Try

            Return blnRet

        End Function


        '------------------------------------------------------------------
        'プロシージャ名  :f_Select_ODP
        '説明            :データSelect
        '引数            :1.ByRef dstDatasetSend  データセット
        '*                2.strTableName    テーブル名
        '*                3.strCriteria     Optional    Where句
        '*                4.strFields       Optional    項目
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Select_ODP(ByRef dstDatasetSend As DataSet, ByVal strSQL As String, ByRef res As Object, ByRef db As DaDbContext) As Boolean
            Dim dstDataSet As New DataSet
            Dim blnRet As Boolean = False

            Try
                Dim daDataAdapter As OracleDataAdapter
                daDataAdapter = New OracleDataAdapter(strSQL, db.Session.Connection)
                daDataAdapter.Fill(dstDataSet)
                dstDatasetSend = dstDataSet
                blnRet = True
                daDataAdapter.Dispose()
            Catch ex As Exception
                '共通例外処理
                dstDatasetSend = Nothing
                res.SetServiceError(ex.Message)
            End Try

            Return blnRet

        End Function


        '------------------------------------------------------------------
        'プロシージャ名  :WordHenkan
        '説明       :ﾊﾟﾗﾒｰﾀにより指定された項目をNULL,SPACE,ZERO型に変換する
        'ﾊﾟﾗﾒｰﾀ     :① strFrom     i,  String,     "N"=NULL,"Z"=ZERO,"S"=SPACEの変換前の型を指定
        '           :② strTo       i,  String      "N"=NULL,"Z"=ZERO,"S"=SPACEの変換後の型を指定
        '           :③ vardata     i,  Variant      変換前の項目
        '戻り値     :               o,  Variant      変換後の項目
        '------------------------------------------------------------------
        Public Function WordHenkan(ByVal strFrom As String,
                                      ByVal strTo As String,
                                      ByVal vardata As Object) As Object

            On Error GoTo Error_WordHenkan
            'NULLからZEROへの変換
            If strFrom = "N" And strTo = "Z" Then
                If IsDBNull(vardata) Then
                    WordHenkan = 0
                ElseIf CStr(vardata) = "null" Then
                    WordHenkan = IIf(vardata = "null", "0", RTrim(vardata))
                Else
                    WordHenkan = IIf(IsDBNull(vardata), "0", RTrim(vardata))
                End If
                Exit Function

                'NULLからSPACEへの変換
            ElseIf strFrom = "N" And strTo = "S" Then
                If IsDBNull(vardata) Then
                    WordHenkan = ""
                ElseIf CStr(vardata) = "null" Then
                    WordHenkan = IIf(vardata = "null", "", RTrim(vardata))
                Else
                    WordHenkan = IIf(IsDBNull(vardata), "", RTrim(vardata))
                End If
                Exit Function
                'ZEROからNULLへの変換
            ElseIf strFrom = "Z" And strTo = "N" Then

                If IsDBNull(vardata) Or vardata = "0" Then
                    WordHenkan = System.DBNull.Value
                Else
                    WordHenkan = vardata
                End If
                Exit Function

                'ZEROからSPACEへの変換
            ElseIf strFrom = "Z" And strTo = "S" Then

                If IsDBNull(vardata) Or vardata = "0" Then
                    WordHenkan = ""
                Else
                    WordHenkan = vardata
                End If
                Exit Function
                'SPACEからNULLへの変換
            ElseIf strFrom = "S" And strTo = "N" Then

                If IsDBNull(vardata) Or Len(RTrim(vardata)) = 0 Then
                    WordHenkan = System.DBNull.Value
                Else
                    WordHenkan = vardata
                End If
                Exit Function
                'SPACEからZEROへの変換
            ElseIf strFrom = "S" And strTo = "Z" Then

                If IsDBNull(vardata) Or Len(RTrim(vardata)) = 0 Then
                    WordHenkan = "0"
                Else
                    WordHenkan = vardata
                End If
                Exit Function
            Else
                'それ以外(指定ミス)
                WordHenkan = vardata
            End If

Error_WordHenkan:
            If strFrom = "N" And strTo = "Z" Then
                WordHenkan = IIf(IsDBNull(vardata), 0, RTrim(vardata))
                'WordHenkan = "0"
            ElseIf strFrom = "N" And strTo = "S" Then
                WordHenkan = ""
            ElseIf strFrom = "Z" And strTo = "N" Then
                WordHenkan = System.DBNull.Value
            ElseIf strFrom = "Z" And strTo = "S" Then
                WordHenkan = ""
            ElseIf strFrom = "S" And strTo = "N" Then
                WordHenkan = System.DBNull.Value
            ElseIf strFrom = "S" And strTo = "Z" Then
                WordHenkan = "0"
            End If
            Exit Function
        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :ComputeSHA256Hash
        '説明       :SHA256関数
        'ﾊﾟﾗﾒｰﾀ     :① data       i,  String  
        '           :② salt       i,  String  
        '------------------------------------------------------------------
        Function ComputeSHA256Hash(data As String, salt As String) As String
            Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(data & salt)
            Using sha256 As SHA256 = SHA256.Create()
                Dim hashBytes As Byte() = sha256.ComputeHash(inputBytes)
                Return BitConverter.ToString(hashBytes).Replace("-", "")
            End Using
        End Function
    End Module
End Namespace
