' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: サービス共通関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Imports System.Globalization

Namespace JBD.GJS.Service

    Public Module JbdGjsService
        Public strGjs As String = "gjs"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :検索結果出力用ＳＱＬ作成
        '引数            :無し
        '戻り値          :String(SQL文)
        '更新日          :
        '------------------------------------------------------------------
        Public Function f_Search_SQLMake(userId As String) As String
            '検索
            Dim sql = " SELECT " & vbCrLf
            sql += "     U.USER_ID USER_ID, " & vbCrLf
            sql += "     U.USER_NAME USER_NAME, " & vbCrLf
            sql += "     U.PASS PASS, " & vbCrLf
            sql += "     U.PASS_KIGEN_DATE PASS_KIGEN_DATE, " & vbCrLf
            sql += "     U.SIYO_KBN SIYO_KBN, " & vbCrLf
            sql += "     U.TEISI_DATE TEISI_DATE " & vbCrLf
            sql += " FROM" & vbCrLf
            sql += "     TM_USER U " & vbCrLf
            'WHERE条件句を作成
            sql += " WHERE" & vbCrLf
            sql += "    (U.USER_ID = '" & userId.TrimEnd & "')" & vbCrLf
            Return sql
        End Function


        '------------------------------------------------------------------
        'プロシージャ名  :f_User_Check
        '説明            :ログインユーザー情報チェック処理
        '引数            :無し
        '戻り値          :String(SQL文)
        '更新日          :
        '------------------------------------------------------------------
        Public Function f_User_Check(dt As DataTable, pw As String, uid As String) As String
            Dim ret As String = String.Empty
            With dt
                'パスワードチェック
                Dim spw = WordHenkan("N", "S", .Rows(0)("PASS")).ToString.TrimEnd
                Dim spw256 = ComputeSHA256Hash(spw, uid)
                If pw.TrimEnd.ToUpper() <> spw256 Then
                    ret = "W019 ユーザーＩＤ、パスワードが正しくありません。"
                End If

                'パスワード有効期限チェック
                If Convert.ToDateTime(.Rows(0)("PASS_KIGEN_DATE")) < Now Then
                    'パスワード有効期限切れ
                    ret = "W019 使用できません。管理者に確認してください。"
                End If

                '利用停止チェック
                If Not .Rows(0)("TEISI_DATE") Is DBNull.Value Then
                    '利用停止ユーザー
                    ret = "W019 使用できません。管理者に確認してください 。"
                End If
            End With
            Return ret
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
        Public Function f_Select_ODP(db As DaDbContext, sql As String) As DataSet
            Dim dt As DataSet = New DataSet()
            Dim daDataAdapter As OracleDataAdapter
            daDataAdapter = New OracleDataAdapter(sql, db.Session.Connection)
            daDataAdapter.Fill(dt)
            daDataAdapter.Dispose()
            Return dt
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
                    WordHenkan = IIf(vardata.ToString() = "null", "0", RTrim(vardata.ToString()))
                Else
                    WordHenkan = IIf(IsDBNull(vardata), "0", RTrim(vardata.ToString()))
                End If
                Exit Function

                'NULLからSPACEへの変換
            ElseIf strFrom = "N" And strTo = "S" Then
                If IsDBNull(vardata) Then
                    WordHenkan = ""
                ElseIf CStr(vardata) = "null" Then
                    WordHenkan = IIf(vardata.ToString() = "null", "", RTrim(vardata.ToString()))
                Else
                    WordHenkan = IIf(IsDBNull(vardata), "", RTrim(vardata.ToString()))
                End If
                Exit Function
                'ZEROからNULLへの変換
            ElseIf strFrom = "Z" And strTo = "N" Then

                If IsDBNull(vardata) Or vardata.ToString() = "0" Then
                    WordHenkan = System.DBNull.Value
                Else
                    WordHenkan = vardata
                End If
                Exit Function

                'ZEROからSPACEへの変換
            ElseIf strFrom = "Z" And strTo = "S" Then

                If IsDBNull(vardata) Or vardata.ToString() = "0" Then
                    WordHenkan = ""
                Else
                    WordHenkan = vardata
                End If
                Exit Function
                'SPACEからNULLへの変換
            ElseIf strFrom = "S" And strTo = "N" Then

                If IsDBNull(vardata) Or Len(RTrim(vardata.ToString())) = 0 Then
                    WordHenkan = System.DBNull.Value
                Else
                    WordHenkan = vardata
                End If
                Exit Function
                'SPACEからZEROへの変換
            ElseIf strFrom = "S" And strTo = "Z" Then

                If IsDBNull(vardata) Or Len(RTrim(vardata.ToString())) = 0 Then
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
                WordHenkan = IIf(IsDBNull(vardata), 0, RTrim(vardata.ToString()))
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

        '------------------------------------------------------------------
        'プロシージャ名  :チェックトークン
        '説明       :
        'ﾊﾟﾗﾒｰﾀ     :① token       i,  String  
        '           :② uid         o,  String  
        '------------------------------------------------------------------
        Public Function CheckToken(token As String) As String
            'トークンの取得
            Dim ret = JbdGjsTokenService.GetTokenUDGjs(token, strGjs, strGjs)
            Dim uids = ret.Split("|")
            Dim uid = uids(0)
            ' 比較する
            If String.IsNullOrEmpty(uid) Then
                Return String.Empty
            End If

            Dim time = uids(1)
            Dim format As String = "yyyyMMddHHmmss"
            Dim dateValue As DateTime
            dateValue = DateTime.ParseExact(time, format, CultureInfo.InvariantCulture)
            '24時間を追加
            dateValue = dateValue.AddHours(24)
            '現在時刻を取得する
            Dim currentTime As DateTime = DateTime.Now
            ' 比较
            If dateValue > currentTime Then
                Return uid
            Else
                Return String.Empty
            End If
        End Function
    End Module

End Namespace
