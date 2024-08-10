' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: サービス共通関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Imports System.Diagnostics.Eventing
Imports System.Globalization
Imports JbdGjsService.JBD.GJS.Service.GJ8090
Imports JbdGjsService.JBD.GJS.Service.GJ8091
Imports OracleInternal.Json

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

#Region "f_Search_SQLMake ＳＱＬ作成処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :ＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Search_SQLMakeNew(wKbn As SearchRequest) As String
            Dim wkANDorOR As String = String.Empty
            Dim wkWhere As String = String.Empty
            Dim wSql As String = String.Empty
            Dim wkOrderby As String = String.Empty

            'ＳＱＬ
            Select Case wKbn.SEARCH_METHOD
                Case EnumAndOr.AndCode
                    '検索方法で[すべてを含む]を選択
                    wkANDorOR = " AND "
                Case EnumAndOr.OrCode
                    '検索方法で[いずれかを含む]を選択
                    wkANDorOR = " OR "
                Case Else
                    wkANDorOR = " AND "
            End Select

            '==オプション条件====================
            ' 以下は省略可能な条件なので指定されていた場合にのみ編集
            ' 但し、検索方法が全てを含むなのかいずれかを含むなのかによりwkANDorORの内容がANDかORに変わる

            '農場番号
            If (wKbn.NOJO_CD.HasValue) = True Then
                wkWhere &= " KNJ.NOJO_CD = " & wKbn.NOJO_CD
            End If

            '農場名
            If wKbn.NOJO_NAME.Trim <> "" Then
                If wkWhere <> "" Then
                    wkWhere = wkWhere & wkANDorOR
                End If
                wkWhere &= " KNJ.NOJO_NAME LIKE '%" & wKbn.NOJO_NAME.Trim & "%'"
            End If

            '条件編集
            If wkWhere <> "" Then
                wkWhere = "  AND (" & wkWhere & ")"
            End If

            wkOrderby = "  KNJ.NOJO_CD"
            Select Case wKbn.ORDER_BY
                Case 1
                    wkOrderby = "  KNJ.NOJO_CD ASC "
                Case -1
                    wkOrderby = "  KNJ.NOJO_CD DESC "
                Case 2
                    wkOrderby = "  KNJ.NOJO_NAME ASC "
                Case -2
                    wkOrderby = "  KNJ.NOJO_NAME DESC "
                Case 2
                    wkOrderby = "  KNJ.ADDR_1 || KNJ.ADDR_2 || KNJ.ADDR_3 || KNJ.ADDR_4  ASC "
                Case -2
                    wkOrderby = "  KNJ.ADDR_1 || KNJ.ADDR_2 || KNJ.ADDR_3 || KNJ.ADDR_4  DESC "
            End Select

            '==SQL作成====================
            'SQL作成
            wSql = ""
            wSql &= "SELECT"
            wSql &= "  KNJ.NOJO_CD,"
            wSql &= "  KNJ.NOJO_NAME,"
            wSql &= "  KNJ.ADDR_1 || KNJ.ADDR_2 || KNJ.ADDR_3 || KNJ.ADDR_4 ADDR "
            wSql &= "FROM"
            wSql &= "  TM_KEIYAKU_NOJO KNJ "
            wSql &= "WHERE KNJ.KI = " & wKbn.KI    '期
            wSql &= "  AND KNJ.KEIYAKUSYA_CD = " & wKbn.KEIYAKUSYA_CD    '契約者
            wSql &= wkWhere & " "
            wSql &= "ORDER BY"
            wSql &= wkOrderby & " "
            Return wSql
        End Function
#End Region

        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLMake
        '説明            :ＳＱＬ作成処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Search_SQLMakePage(psize As Integer, pnum As Integer, sql As String) As String
            '==SQL作成====================
            Dim wSql = ""
            wSql &= "SELECT * "
            wSql &= "  FROM ( "
            wSql &= " SELECT T1.NOJO_CD,                              "
            wSql &= "        T1.NOJO_NAME,                            "
            wSql &= "        T1.ADDR,                                 "
            wSql &= "        COUNT(1) OVER() AS RCNT,               "
            wSql &= "        CEIL(COUNT(1) OVER()/ " & psize & " ) AS PCNT   , ROWNUM AS RM  "
            wSql &= " FROM                                            "
            wSql &= " ( " & sql & " ) "
            wSql &= "  T1  )  "
            wSql &= " WHERE RM <= (" & psize & " * " & pnum & " )    "
            wSql &= "   AND RM >  (" & psize & " * " & pnum & " - " & psize & ") "
            Return wSql
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
                    ret = "ユーザーＩＤ、パスワードが正しくありません。"
                End If

                'パスワード有効期限チェック
                If Convert.ToDateTime(.Rows(0)("PASS_KIGEN_DATE")) < Now Then
                    'パスワード有効期限切れ
                    ret = "使用できません。管理者に確認してください。"
                End If

                '利用停止チェック
                If Not .Rows(0)("TEISI_DATE") Is DBNull.Value Then
                    '利用停止ユーザー
                    ret = "使用できません。管理者に確認してください 。"
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

        Public Function f_SetForm_Data_New(req As SearchDetailRequest) As String
            Dim ret As Boolean = False
            Dim wkDS As New DataSet
            Dim wSql As String = String.Empty
            'SQL
            wSql = "SELECT * FROM TM_KEIYAKU_NOJO" & _
                    " WHERE KI = " & req.KI & _
                    "  AND KEIYAKUSYA_CD = " & req.KEIYAKUSYA_CD & _
                    "  AND NOJO_CD = " & req.NOJO_CD
            Return wSql
        End Function

#Region "f_Data_Deleate 契約者農場削除処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Deleate
    '説明            :契約者農場削除処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_Data_Deleate_Gj8091(db As DaDbContext, wNojoCd As DeleteRequest) As DaResponseBase

        Dim wkCmd As New OracleCommand
        Dim wkSql As String = String.Empty
        Dim wkRet As Boolean = False



            'ストアドプロシージャの呼び出し
            wkCmd.Connection = db.Session.Connection
            wkCmd.CommandType = CommandType.StoredProcedure
            '
            wkCmd.CommandText = "PKG_GJ8091.GJ8091_KEIYAKU_NOJO_DEL"

            '引き渡し
            'グループコード
            Dim paraKI As OracleParameter = wkCmd.Parameters.Add("IN_KI", wNojoCd.KI)
            Dim paraKEIYAKU_CD As OracleParameter = wkCmd.Parameters.Add("IN_KEIYAKU", wNojoCd.KEIYAKUSYA_CD)
            Dim paraNOJO_CD As OracleParameter = wkCmd.Parameters.Add("IN_NOJO_CD", wNojoCd.NOJO_CD)

            '戻り
            Dim p_MSGCD As OracleParameter = wkCmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = wkCmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            wkCmd.ExecuteNonQuery()

            Debug.Print(wkCmd.Parameters("OU_MSGCD").Value.ToString())
            If wkCmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                If wkCmd.Parameters("OU_MSGCD").Value.ToString() = "99" Then
                    '削除済みは政情終了とみなす
                    wkRet = True
                End If
                Throw New Exception(wkCmd.Parameters("OU_MSGCD").Value.ToString() & ":" & wkCmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            wkRet = True

            'データベースへの接続を閉じる
            If Not wkCmd Is Nothing Then
                wkCmd.Dispose()
            End If

        Return New DaResponseBase


    End Function
#End Region

#Region "f_Data_Insert 契約者農場更新処理"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Data_Insert
    '説明            :契約者農場更新処理
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_Data_Update(db As DaDbContext, wNojoCd As SaveRequest) As DaResponseBase
        Dim Cmd As New OracleCommand
        Dim ret As Boolean = False

        'Try

            'ストアドプロシージャの呼び出し
            Cmd.Connection = db.Session.Connection
            Cmd.CommandType = CommandType.StoredProcedure


            Select Case wNojoCd.EDIT_KBN
                Case Enum編集区分.変更       '変更入力
                    Cmd.CommandText = "PKG_GJ8091.GJ8091_KEIYAKU_NOJO_UPD"
                Case Enum編集区分.新規       '新規入力
                    Cmd.CommandText = "PKG_GJ8091.GJ8091_KEIYAKU_NOJO_INS"
            End Select


            '引き渡し

            '期 
            Cmd.Parameters.Add("IN_KI", wNojoCd.KEIYAKUSYA_NOJO.KI)
            '契約者番号
            Cmd.Parameters.Add("IN_KEIYAKUSYA_CD", wNojoCd.KEIYAKUSYA_NOJO.KEIYAKUSYA_CD
                               )
            '農場番号 
            Cmd.Parameters.Add("IN_NOJO_CD", wNojoCd.KEIYAKUSYA_NOJO.NOJO_CD
                               )
            '都道府県コード
            Cmd.Parameters.Add("IN_KEN_CD", wNojoCd.KEIYAKUSYA_NOJO.KEN_CD
                               )
            '農場名
            Cmd.Parameters.Add("IN_NOJO_NAME", wNojoCd.KEIYAKUSYA_NOJO.NOJO_NAME
                               )

            '郵便番号
            Cmd.Parameters.Add("IN_ADDR_POST", wNojoCd.KEIYAKUSYA_NOJO.ADDR_POST
                               )
            '住所１
            Cmd.Parameters.Add("IN_ADDR_1", wNojoCd.KEIYAKUSYA_NOJO.ADDR_1
                               )
            '住所２
            Cmd.Parameters.Add("IN_ADDR_2", wNojoCd.KEIYAKUSYA_NOJO.ADDR_2
                               )
            '住所３
            If wNojoCd.KEIYAKUSYA_NOJO.ADDR_3.Trim = "" Then
                Cmd.Parameters.Add("IN_ADDR_3", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_ADDR_3", wNojoCd.KEIYAKUSYA_NOJO.ADDR_3)
            End If
            '住所４
            If wNojoCd.KEIYAKUSYA_NOJO.ADDR_4.Trim = "" Then
                Cmd.Parameters.Add("IN_ADDR_4", DBNull.Value)
            Else
                Cmd.Parameters.Add("IN_ADDR_4", wNojoCd.KEIYAKUSYA_NOJO.ADDR_4)
            End If

            '電話番号
            Cmd.Parameters.Add("IN_MEISAI_NO", wNojoCd.KEIYAKUSYA_NOJO.MEISAI_NO)

            ''共通
            'If pSyoriKbn = Enu_SyoriKubun.Insert Then
            '    'データ登録日
            '    Cmd.Parameters.Add("IN_REG_DATE", Now)
            '    'データ登録ＩＤ
            '    Cmd.Parameters.Add("IN_REG_ID", wNojoCd.USER_ID)
            'End If
            Select Case wNojoCd.EDIT_KBN
                Case Enum編集区分.新規       '新規入力
                'データ登録日
                Cmd.Parameters.Add("IN_REG_DATE", Now)
                'データ登録ＩＤ
                Cmd.Parameters.Add("IN_REG_ID", wNojoCd.USER_ID)
            End Select

            'データ更新日
            Cmd.Parameters.Add("IN_UP_DATE", Now)
            'データ更新ＩＤ
            Cmd.Parameters.Add("IN_UP_ID", wNojoCd.USER_ID)
            'コンピュータ名
            Cmd.Parameters.Add("IN_COM_NAME", wNojoCd.USER_ID)

            '戻り
            Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
            Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

            Cmd.ExecuteNonQuery()
            Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())
            If Cmd.Parameters("OU_MSGCD").Value.ToString() <> "0" Then
                Throw New Exception(Cmd.Parameters("OU_MSGCD").Value.ToString() & ":" & Cmd.Parameters("OU_MSGNM").Value.ToString())
            End If

            'データベースへの接続を閉じる
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If

            ret = True

        'Catch ex As Exception
        '    '共通例外処理
        '    If ex.Message <> "Err" Then
        '        Show_MessageBox("", ex.Message)
        '    End If
        '    If Not Cmd Is Nothing Then
        '        Cmd.Dispose()
        '    End If
        'End Try

        Return New DaResponseBase
    End Function

#End Region

    End Module

End Namespace
