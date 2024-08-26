' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: サービスGJ0000関数
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ0000

    Public Module FrmGJ0000Service

#Region "f_Search_SQLMake 検索結果出力用ＳＱＬ作成"
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
#End Region

#Region "f_Search_SQLHome 検索結果出力用ＳＱＬ作成"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Search_SQLHome
        '説明            :検索結果出力用ＳＱＬ作成
        '引数            :無し
        '戻り値          :String(SQL文)
        '更新日          :
        '------------------------------------------------------------------
        Public Function f_Search_SQLHome() As String
            '検索
            Dim sSql =  "SELECT  "
            sSql = sSql & "      SUM(MEI.HASU) AS HASU,  "
            sSql = sSql & "      SUM(MEI.TUMITATE_KIN) AS TUMI,  "
            sSql = sSql & "      COUNT(DISTINCT KEI_S.KEIYAKUSYA_CD) AS CNT_SHINKI,  "
            sSql = sSql & "      COUNT(DISTINCT KEI_K.KEIYAKUSYA_CD) AS CNT_KEI  "
            sSql = sSql & " FROM TT_TUMITATE_MEISAI MEI, TT_TUMITATE TUM, TM_SYORI_KI B, "
            sSql = sSql & "      (SELECT KI, KEIYAKUSYA_CD FROM TM_KEIYAKU WHERE KEIYAKU_JYOKYO = 1) KEI_S, "
            sSql = sSql & "      (SELECT KI, KEIYAKUSYA_CD FROM TM_KEIYAKU WHERE KEIYAKU_JYOKYO = 2) KEI_K "
            sSql = sSql & " WHERE TUM.NYUKIN_DATE <= TRUNC(SYSDATE) AND TUM.SYORI_JOKYO_KBN = 3 AND TUM.SEIKYU_HENKAN_KBN BETWEEN 1 AND 3"
            sSql = sSql & "   AND TUM.DATA_FLG = 1 AND TUM.KI = MEI.KI AND TUM.SEIKYU_KAISU = MEI.SEIKYU_KAISU AND TUM.KEIYAKUSYA_CD = MEI.KEIYAKUSYA_CD"
            sSql = sSql & "   AND TUM.TUMITATE_KBN = MEI.TUMITATE_KBN AND MEI.DATA_FLG = 1 AND TUM.KI = B.KI"
            sSql = sSql & "   AND MEI.KEIYAKUSYA_CD = KEI_S.KEIYAKUSYA_CD(+) AND MEI.KI = KEI_S.KI(+)"
            sSql = sSql & "   AND MEI.KEIYAKUSYA_CD = KEI_K.KEIYAKUSYA_CD(+) AND MEI.KI = KEI_K.KI(+)"
            Return sSql
        End Function
#End Region

#Region "f_User_Check ログインユーザー情報チェック処理"
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
#End Region

#Region "WordHenkan ﾊﾟﾗﾒｰﾀにより指定された項目をNULL,SPACE,ZERO型に変換する"
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
#End Region

#Region "ComputeSHA256Hash SHA256関数"
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
#End Region

    End Module

End Namespace
