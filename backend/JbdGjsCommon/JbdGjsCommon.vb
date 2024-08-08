' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ＥＭＳ共通モジュール
'
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports JbdGjsDb.JBD.GJS.Db

Namespace JBD.GJS.Common
    Public Module JbdGjsCommon

#Region "*** 変数定義 ***"
        Public Cnn As DaDbContext
        Public pPCNAME As String
        Public pFILEVERSION As String        'アセンブリバージョン 2014/12/23 ADD JBD368
        Public pAPP As String           'APID
        Public pAPPTITLE As String      '画面タイトル
        Public pLOGINUSERID As String   'ログオンユーザＩＤ 2010/10/23 ADD JBD200
        Public pLOGINUSERNM As String   'ログオンユーザ名
        Public myDBUSER As String
        Public myDBPASS As String
        Public myDBSID As String
        Public myREPORT_PDF_PATH As String
        Public myREPORT_EXCEL_PATH As String
        Public myTEMPLATE_EXCEL_PATH As String  '2015/03/23 ADD EXCELテンプレート用ファイルパス追加
        Public myREPORT_PDF_OUTKBN As String
        Public myANNAI_CD As Integer = 0        '2010/11/08 ADD JBD200 案内文マスタの種類初期表示用
        Public myTAISYO_NENGETU As Date         '2012/02/21 ADD JBD200 承認法人受入履歴用
        Public myYOHAKU_UP As Double
        Public myYOHAKU_DOWN As Double
        Public myYOHAKU_LEFT As Double
        Public myYOHAKU_RIGHT As Double
        Public myBACKCOLOR_STRING As String = String.Empty
        Public myBACKCOLOR As System.Drawing.Color          '2014/05/09　画面背景色
        Public myTXT_FURIKOMI_ENTRY As String
        Public myLogonDate As String
        Public myWeekDay As String
        Public pConnection As String
        Public iniFileName As String
        '共通検索画面用変数--------------------------------------
        Public pKoumokumei() As String
        Public pKoumokucnt As Integer
        Public pAlign() As String
        Public pMasterKey() As String
        Public pMasterKeycnt As Integer
        Public pSelectSql As String
        Public pTitle As String
        Public pretButton As String
        '------------------------------------------------------------------

        'メッセージ格納用変数--------------------------------------
        Public Structure pMESSAGE
            Public CD As String
            Public MESSAGE As String
            Public BUTTON As String
            Public ICON As String
            Public DEF As String
        End Structure
        Public pMESSAGE_Array() As pMESSAGE
        Public pMESSAGE_CD_Array() As String
        '------------------------------------------------------------------

        'GJS.INI格納用変数--------------------------------------
        Public Structure pGJSINI
            Public LOGINUSERID As String            '2010/10/23 ADD JBD200
            Public LOGINUSERNM As String
            Public DBUSER As String
            Public DBPASS As String
            Public DBSID As String
            Public TXT_FURIKOMI_ENTRY As String
            Public REPORT_PDF_PATH As String
            Public REPORT_EXCEL_PATH As String
            Public TEMPLATE_EXCEL_PATH As String  '2015/03/23 ADD EXCELテンプレート用ファイルパス追加
            Public REPORT_PDF_OUTKBN As String
            Public ANNAI_CD As Integer      '2010/11/08 ADD JBD200 案内文マスタの種類初期表示用
            Public TAISYO_NENGETU As Date   '2012/02/21 ADD JBD200 承認法人受入履歴用
            Public YOHAKU_UP As Double
            Public YOHAKU_DOWN As Double
            Public YOHAKU_LEFT As Double
            Public YOHAKU_RIGHT As Double
            Public SCR_BACKCOLOR_STRING As String          '2014/05/09　追加
            Public SCR_BACKCOLOR As System.Drawing.Color   '2014/05/09　追加
        End Structure
        '------------------------------------------------------------------

        Public pCNT As Integer = 0                           '帳票出力件数
        Private xl As New JbdGjsExcel
        Private pRow As Integer = 0                         'Excel出力時の行番号

        '2024/01/22 循環参照解消のため、Libの色を変更した場合はここも変更
        Dim wBaseBackColor As System.Drawing.Color = Color.AliceBlue

        '2017/07/14　追加開始
        Public pKikin2 As Boolean = False
        '2017/07/14　追加終了

#End Region

#Region "*** 定数定義 ***"

        'メッセージ表示時のアイコン型用
        '('Show_MessageBox関数の第２引数用)
        Public Const C_MSGICON_QUESTION = 0         'Question
        Public Const C_MSGICON_ERROR = 1            'Error
        Public Const C_MSGICON_WARNING = 2          'Warning
        Public Const C_MSGICON_INFORMATION = 3      'Information

        Public Const C_YOHAKU_UP = 1.5
        Public Const C_YOHAKU_DOWN = 1.0
        Public Const C_YOHAKU_LEFT = 1.0
        Public Const C_YOHAKU_RIGHT = 1.0

        '画面処理モード
        Public Const C_MENU As Byte = 0
        Public Const C_MAIN As Byte = 1
        Public Const C_SUB As Byte = 2

#End Region

#Region "*** 初期処理関連 ***"

        '------------------------------------------------------------------
        'プロシージャ名  :f_ColorConvert
        '説明            :ini取得処理
        '引数            :
        '戻り値          :Boolean(正常True/エラーFalse)
        '作成日          :2014/05/09
        '------------------------------------------------------------------
        Private Function f_ColorConvert(ByVal myBACKCOLOR_STRING As String) As System.Drawing.Color
            Dim wColor As System.Drawing.Color = wBaseBackColor

            Try
                wColor = New ColorConverter().ConvertFromString(myBACKCOLOR_STRING)
            Catch ex As Exception
                wColor = wBaseBackColor
            End Try

            Return wColor

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :Get_CommandLine
        '説明            :コマンドラインを取得
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function Get_CommandLine() As Boolean
            ' Declare variables.
            Get_CommandLine = False
            Try
                Dim separators As String = " "
                Dim commands As String = Microsoft.VisualBasic.Interaction.Command()
                Dim args() As String = commands.Split(separators.ToCharArray)
                Get_CommandLine = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try
        End Function
#End Region

#Region "*** 文字列制御関数 ***"
        '------------------------------------------------------------------
        'プロシージャ名  :fMidB
        '説明            :文字列をバイト単位で位置指定して切り抜く
        '引数            :myString(文字)
        '                :sByt(開始バイト数)
        '                :nByt(バイト数)
        '戻り値          :切取った文字を返す
        '------------------------------------------------------------------
        Public Function fMidB(ByVal myString As String, _
                                ByVal sByt As Integer, ByVal nByt As Integer) As String
            '指定バイト位置から指定バイト数分の文字列を取り出す関数
            Dim sjis As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
            Dim tempByt() As Byte = sjis.GetBytes(myString)
            Dim sumByt As Integer = sjis.GetByteCount(myString)
            If sByt < 0 Or nByt <= 0 Or sByt > sumByt Then Return ""
            Dim strTemp As String = sjis.GetString(tempByt, 0, sByt)
            If sByt > 0 And strTemp.EndsWith(ControlChars.NullChar) Then
                sByt += 1   '開始位置が漢字の中なら次(前)の文字から開始
            End If
            If sByt + nByt > sumByt Then    '文字長より多く取得しようとした場合
                nByt = sumByt - sByt        '文字列の最後までの分とする
            End If
            Return sjis.GetString(tempByt, sByt, nByt).TrimEnd(ControlChars.NullChar)
        End Function
        '------------------------------------------------------------------
        'プロシージャ名  :fStrCut
        '説明            :文字列をバイト単位で位置指定して切り抜く
        '引数            :Mystring(文字)
        '                :nLen(バイト数)
        '戻り値          :切取った文字を返す
        '------------------------------------------------------------------
        Public Function fStrCut(ByVal Mystring As String, ByVal nLen As Integer) As String
            '文字列を指定のバイト数にカットする関数(漢字分断回避）
            Dim sjis As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
            Dim TempLen As Integer = sjis.GetByteCount(Mystring)
            If nLen < 1 Or Mystring.Length < 1 Then Return Mystring
            If TempLen <= nLen Then   '文字列が指定のバイト数未満の場合スペースを付加する
                Return Mystring.PadRight(nLen - (TempLen - Mystring.Length), " ")
            End If
            Dim tempByt() As Byte = sjis.GetBytes(Mystring)
            Dim strTemp As String = sjis.GetString(tempByt, 0, nLen)
            '末尾が漢字分断されたら半角スペースと置き換え(VB2005="・" で.NET2003=NullChar になります）
            If strTemp.EndsWith(ControlChars.NullChar) Or strTemp.EndsWith("・") Then
                strTemp = sjis.GetString(tempByt, 0, nLen - 1) & " "
            End If
            Return strTemp
        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :WordHenkan
        '説明       :ﾊﾟﾗﾒｰﾀにより指定された項目をNULL,SPACE,ZERO型に変換する
        'ﾊﾟﾗﾒｰﾀ     :① strFrom     i,  String,     "N"=NULL,"Z"=ZERO,"S"=SPACEの変換前の型を指定
        '           :② strTo       i,  String      "N"=NULL,"Z"=ZERO,"S"=SPACEの変換後の型を指定
        '           :③ vardata     i,  Variant      変換前の項目
        '戻り値     :               o,  Variant      変換後の項目
        '------------------------------------------------------------------
        Public Function WordHenkan(ByVal strFrom As String, _
                                        ByVal strTo As String, _
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
#Region "ReplaceString 文字列置換"
        '------------------------------------------------------------------
        'プロシージャ名  :ReplaceString
        '説明       :文字列置換
        'ﾊﾟﾗﾒｰﾀ     :① strFrom     i,  String,     "N"=NULL,"Z"=ZERO,"S"=SPACEの変換前の型を指定
        '           :② strTo       i,  String      "N"=NULL,"Z"=ZERO,"S"=SPACEの変換後の型を指定
        '           :③ vardata     i,  Variant      変換前の項目
        '戻り値     :               o,  Variant      変換後の項目
        '------------------------------------------------------------------
        Public Function ReplaceString(ByVal vntSource As String, ByVal str1 As String, ByVal str2 As String) As String
            Dim strTmp As String
            Dim intSt As Integer

            strTmp = vntSource
            intSt = 1
            Do
                intSt = InStr(intSt, strTmp, str1)
                If intSt = 0 Then
                    Exit Do
                End If
                strTmp = Microsoft.VisualBasic.Left(strTmp, intSt - 1) & str2 & Mid(strTmp, intSt + Len(str1))
                intSt = intSt + Len(str2)
            Loop
            ReplaceString = strTmp

        End Function
#End Region

#End Region

#Region "*** 日付制御関数 ***"
        Public Function ACoDateCheckEdit(ByVal objString As String, _
                                            ByVal varEditDate As Object) As Boolean
            '概要       : テキストボックスに入力された文字列の日付チェックを行う
            'ﾊﾟﾗﾒｰﾀ     : ①objString  ：テキストボックス名
            '           : ②varEditDate ：編集結果をセットする引数(Optional)
            '           : ③戻り値,     ：True:日付正常  False:日付異常
            '説明       :

            Dim intY As Integer
            Dim intM As Integer
            Dim intD As Integer

            Try

                ACoDateCheckEdit = True

                If Len(objString) = 0 Then
                    Exit Function
                End If


                ' YYMMDD の形式で入力された場合
                If Len(objString) = 6 Then
                    If IsNumeric(Left$(objString, 2)) Then
                        intY = CInt(Left$(objString, 2))
                    Else
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If IsNumeric(Mid$(objString, 3, 2)) Then
                        intM = CInt(Mid$(objString, 3, 2))
                    Else
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If IsNumeric(Mid$(objString, 5, 2)) Then
                        intD = CInt(Mid$(objString, 5, 2))
                    Else
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If ACoLeapCheck(intY, intM, intD) = False Then
                        GoTo ACoDateCheckEdit_Exit3
                    End If

                    If Left$(objString, 2) < "90" Then
                        If varEditDate = "Missing" Then
                            objString = "20" & Left$(objString, 2) & "/" & Mid$(objString, 3, 2) & "/" & Mid$(objString, 5, 2)
                        Else
                            varEditDate = "20" & Left$(objString, 2) & "/" & Mid$(objString, 3, 2) & "/" & Mid$(objString, 5, 2)
                        End If
                    Else
                        If varEditDate = "Missing" Then
                            objString = "19" & Left$(objString, 2) & "/" & Mid$(objString, 3, 2) & "/" & Mid$(objString, 5, 2)
                        Else
                            varEditDate = "19" & Left$(objString, 2) & "/" & Mid$(objString, 3, 2) & "/" & Mid$(objString, 5, 2)
                        End If
                    End If

                    Exit Function
                End If

                ' YYYYMMDD の形式で入力された場合
                If Len(objString) = 8 And Not (Mid$(objString, 3, 1) = "-" Or Mid$(objString, 3, 1) = "/") Then
                    'If Left$(objString, 4) < "1900" Or Left$(objString, 4) > "2089" Then
                    '    GoTo ACoDateCheckEdit_Exit2
                    'End If

                    If Mid$(objString, 5, 2) < "01" Or Mid$(objString, 5, 2) > "12" Or _
                        Mid$(objString, 7, 2) < "01" Or Mid$(objString, 7, 2) > "31" Then
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If IsNumeric(Mid$(objString, 3, 2)) Then
                        intY = CInt(Mid$(objString, 3, 2))
                    Else
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If IsNumeric(Mid$(objString, 5, 2)) Then
                        intM = CInt(Mid$(objString, 5, 2))
                    Else
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If IsNumeric(Mid$(objString, 7, 2)) Then
                        intD = CInt(Mid$(objString, 7, 2))
                    Else
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If ACoLeapCheck(intY, intM, intD) = False Then
                        GoTo ACoDateCheckEdit_Exit3
                    End If

                    If varEditDate = "Missing" Then
                        objString = Left$(objString, 4) & "/" & Mid$(objString, 5, 2) & "/" & Mid$(objString, 7, 2)
                    Else
                        varEditDate = Left$(objString, 4) & "/" & Mid$(objString, 5, 2) & "/" & Mid$(objString, 7, 2)
                    End If

                    Exit Function
                End If

                ' YY-MM-DD(YY/MM/DD) の形式で入力された場合
                If Len(objString) = 8 And (Mid$(objString, 3, 1) = "-" Or Mid$(objString, 3, 1) = "/") Then
                    If Left$(objString, 2) < "00" Or Left$(objString, 2) > "99" Or _
                        Mid$(objString, 4, 2) < "01" Or Mid$(objString, 4, 2) > "12" Or _
                        Mid$(objString, 7, 2) < "01" Or Mid$(objString, 7, 2) > "31" Then
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If IsNumeric(Left$(objString, 2)) Then
                        intY = CInt(Left$(objString, 2))
                    Else
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If IsNumeric(Mid$(objString, 4, 2)) Then
                        intM = CInt(Mid$(objString, 4, 2))
                    Else
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If IsNumeric(Mid$(objString, 7, 2)) Then
                        intD = CInt(Mid$(objString, 7, 2))
                    Else
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If ACoLeapCheck(intY, intM, intD) = False Then
                        GoTo ACoDateCheckEdit_Exit3
                    End If

                    If Left$(objString, 2) < "90" Then
                        If varEditDate = "Missing" Then
                            objString = "20" & Left$(objString, 2) & "/" & Mid$(objString, 4, 2) & "/" & Mid$(objString, 7, 2)
                        Else
                            varEditDate = "20" & Left$(objString, 2) & "/" & Mid$(objString, 4, 2) & "/" & Mid$(objString, 7, 2)
                        End If
                    Else
                        If varEditDate = "Missing" Then
                            objString = "19" & Left$(objString, 2) & "/" & Mid$(objString, 4, 2) & "/" & Mid$(objString, 7, 2)
                        Else
                            varEditDate = "19" & Left$(objString, 2) & "/" & Mid$(objString, 4, 2) & "/" & Mid$(objString, 7, 2)
                        End If
                    End If

                    Exit Function

                End If

                ' YYYY-MM-DD(YYYY/MM/DD) の形式で入力された場合
                If Len(objString) = 10 And (Mid$(objString, 5, 1) = "-" Or Mid$(objString, 5, 1) = "/") Then
                    'If Left$(objString, 4) < "1990" Or Left$(objString, 4) > "2089" Then
                    '    GoTo ACoDateCheckEdit_Exit2
                    'End If

                    If Mid$(objString, 6, 2) < "01" Or Mid$(objString, 6, 2) > "12" Or _
                        Mid$(objString, 9, 2) < "01" Or Mid$(objString, 9, 2) > "31" Then
                        GoTo ACoDateCheckEdit_Exit1
                        Exit Function
                    End If

                    If IsNumeric(Mid$(objString, 3, 2)) Then
                        intY = CInt(Mid$(objString, 3, 2))
                    Else
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If IsNumeric(Mid$(objString, 6, 2)) Then
                        intM = CInt(Mid$(objString, 6, 2))
                    Else
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If IsNumeric(Mid$(objString, 9, 2)) Then
                        intD = CInt(Mid$(objString, 9, 2))
                    Else
                        GoTo ACoDateCheckEdit_Exit1
                    End If

                    If ACoLeapCheck(intY, intM, intD) = False Then
                        GoTo ACoDateCheckEdit_Exit3
                    End If

                    If varEditDate = "Missing" Then
                        objString = Left$(objString, 4) & "/" & Mid$(objString, 6, 2) & "/" & Mid$(objString, 9, 2)
                    Else
                        varEditDate = Left$(objString, 4) & "/" & Mid$(objString, 6, 2) & "/" & Mid$(objString, 9, 2)
                    End If

                    Exit Function
                End If

ACoDateCheckEdit_Exit1:
                'Show_MessageBox("", "YYYYMMDD または YYMMDD の形式で入力して下さい。") 'YYYYMMDD または YYMMDD の形式で入力して下さい。
                ''Show_MessageBox("YYYYMMDD または YYMMDD の形式で入力して下さい。", C_MSGICON_ERROR)
                ACoDateCheckEdit = False
                Exit Function

                'ACoDateCheckEdit_Exit2:

                '            'Show_MessageBox("000049", "") '西暦は、1990年から2089年までを入力して下さい。"
                '            ACoDateCheckEdit = False
                '            Exit Function

ACoDateCheckEdit_Exit3:

                'Show_MessageBox("", "該当する日付は存在しません。") 'YYYYMMDD または YYMMDD の形式で入力して下さい。
                ''Show_MessageBox("該当する日付は存在しません。", C_MSGICON_ERROR)
                ACoDateCheckEdit = False
                Exit Function


            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
                ACoDateCheckEdit = False
            End Try


        End Function
        Public Function ACoDateCheckEdit(ByVal objString As String) As Boolean
            If Not ACoDateCheckEdit(objString, "Missing") Then
                Return False
            End If
            Return True
        End Function
        Public Function ACoLeapCheck(ByVal intY As Integer, ByVal intM As Integer, ByVal intD As Integer) As Boolean
            '概要       :うるうチェック
            'ﾊﾟﾗﾒｰﾀ     :intY,i,Integer,年（00～99，90～99は1990～1999、00～89は2000～2089）
            '           :intM,i,Integer,月
            '           :intD,i,Integer,日
            '           :戻り値,正常->　0以上、異常->　－１
            '説明       :

            Dim intLeapday As Integer

            Select Case intM
                Case 1, 3, 5, 7, 8, 10, 12
                    If intD > 0 And intD < 32 Then
                        ACoLeapCheck = True
                    Else
                        ACoLeapCheck = False  '日の範囲エラー
                    End If

                Case 4, 6, 9, 11
                    If intD > 0 And intD < 31 Then
                        ACoLeapCheck = True
                    Else
                        ACoLeapCheck = False  '日の範囲エラー
                    End If

                Case 2
                    If intY Mod 4 = 0 Then     '4で割り切れる年(西暦2000年はうるう年）
                        intLeapday = 1
                    Else
                        intLeapday = 0
                    End If

                    If intD > 0 And intD < 29 + intLeapday Then
                        ACoLeapCheck = True
                    Else
                        ACoLeapCheck = False  '日の範囲エラー
                    End If

                Case Else  '月の範囲エラー
                    ACoLeapCheck = False

            End Select
        End Function

#Region "f_DateTrim 時間省略"
        '------------------------------------------------------------------
        'プロシージャ名  :f_DateTrim
        '説明            :文字列→日付変換
        '引数            :
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_DateTrim(ByVal wkDate As Date) As Date
            If IsNothing(wkDate) OrElse wkDate = New Date Then
                Return wkDate
            Else
                Return Date.Parse(wkDate.ToString("yyyy/MM/dd"))
            End If
        End Function
#End Region

#Region "f_Str2DateOrNothing 文字列をDateかNothingに変換"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Str2DateOrNothing
        '説明            :文字列をDateかNothingに変換。
        '引数            :
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Str2DateOrNothing(ByVal wkDateStr As String) As Date
            Dim wkdate As New Date
            If Date.TryParse(wkDateStr, wkdate) Then
                Return wkdate
            Else
                Return Nothing
            End If
        End Function
#End Region

#Region "f_DateNothingCheck DateがNothingまたは初期値以外であるか判定"
        '------------------------------------------------------------------
        'プロシージャ名  :f_DateNothingCheck
        '説明            :日付がNothingまたは初期値(0001/01/01)以外であるかチェック
        '引数            :wkDate：対象日付
        '戻り値          :Boolean(Nothing以外の場合：True/Nothingまたは0001/01/01の場合：False)
        '更新日          :2015/02/23 JBD368 ADD
        '------------------------------------------------------------------
        Public Function f_DateNothingCheck(ByVal wkDate As Date) As Boolean

            If IsNothing(wkDate) OrElse wkDate.ToString("yyyy/MM/dd") = "0001/01/01" Then
                Return False
            End If

            Return True
        End Function
#End Region

#End Region

#Region "*** SQL関数関連 ***"
#Region "f_Select_ODP SELECT"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Select_ODP
        '説明            :データSelect
        '引数            :1.ByRef dstDatasetSend  データセット
        '*                2.strTableName    テーブル名
        '*                3.strCriteria     Optional    Where句
        '*                4.strFields       Optional    項目
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Select_ODP(ByRef dstDatasetSend As DataSet, ByVal strSQL As String) As Boolean
            'Dim strSQL As String
            Dim dstDataSet As New DataSet
            Dim objOraDB As Object = ""
            Dim blnRet As Boolean = False

            ''マルチサーバー対応
            'Cnn.ConnectionString = pConnection

            ''抽出
            'strSQL = "SELECT " & IIf(strFields = "", "*", strFields) & _
            '      " FROM " & strTableName
            'If strCriteria = "" Then
            'Else
            '    strSQL = strSQL & " WHERE " & strCriteria
            'End If

            Debug.WriteLine(strSQL)
            Try
                Dim daDataAdapter As OracleDataAdapter
                'If db.db.Connection.State = Data.ConnectionState.Closed Then
                '    db.db.Connection.Open()
                'End If
                daDataAdapter = New OracleDataAdapter(strSQL, Cnn.db.Connection)
                daDataAdapter.Fill(dstDataSet)
                dstDatasetSend = dstDataSet
                blnRet = True
            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
                dstDatasetSend = Nothing
            End Try

            Return blnRet

        End Function


 Public Function f_Select_ODP_New(db As DaDbContext, ByRef dstDatasetSend As DataSet, ByVal strSQL As String) As Boolean
            'Dim strSQL As String
            Dim dstDataSet As New DataSet
            Dim objOraDB As Object = ""
            Dim blnRet As Boolean = False

            ''マルチサーバー対応
            'Cnn.ConnectionString = pConnection

            ''抽出
            'strSQL = "SELECT " & IIf(strFields = "", "*", strFields) & _
            '      " FROM " & strTableName
            'If strCriteria = "" Then
            'Else
            '    strSQL = strSQL & " WHERE " & strCriteria
            'End If

            Debug.WriteLine(strSQL)
            Try
                Dim daDataAdapter As OracleDataAdapter
                if db.db.connection.state = data.connectionstate.closed then
                    db.db.connection.open()
                end if
                daDataAdapter = New OracleDataAdapter(strSQL, db.db.Connection)
                daDataAdapter.Fill(dstDataSet)
                dstDatasetSend = dstDataSet
                blnRet = True
            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
                dstDatasetSend = Nothing
            End Try

            Return blnRet

        End Function
#End Region
#Region "f_Select_ODR SELECT"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Select_ODR
        '説明            :データSelect(OracleDataReader使用)
        '引数            :1.ByRef dstDatasetSend  データセット
        '*                2.strTableName    テーブル名
        '*                3.strCriteria     Optional    Where句
        '*                4.strFields       Optional    項目
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Select_ODR(ByRef rdr As Oracle.ManagedDataAccess.Client.OracleDataReader, ByVal strSQL As String) As Boolean
            '**************
            'Dim strSQL As String
            Dim blnRet As Boolean = False

            Try
                Dim Cmd As New Oracle.ManagedDataAccess.Client.OracleCommand


                Cmd.Connection = Cnn.db.Connection
                Cmd.CommandText = strSQL

                ' OracleDataReaderオブジェクトを生成します。
                rdr = Cmd.ExecuteReader

                blnRet = True
            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
            End Try

            Return blnRet

        End Function
#End Region
#Region "f_SqlEdit SQL文に含まれているｱﾎﾟｽﾄﾛﾌｨｰを二重化する"
        '------------------------------------------------------------------
        'プロシージャ名  :f_SqlEdit
        '説明            :SQL文に含まれているｱﾎﾟｽﾄﾛﾌｨｰを二重化する
        '引数            :1.strSQL      変換前SQL文
        '戻り値          :String        変換後SQL文
        '------------------------------------------------------------------
        Public Function f_SqlEdit(ByVal strSQL As String) As String
            Dim i As Integer
            Dim editSQL As String
            Dim SQLchar As String

            i = 0
            editSQL = ""
            If InStr(strSQL, "'") <> 0 Then
                Do While i < Len(strSQL)
                    i = i + 1
                    SQLchar = Mid(strSQL, i, 1)
                    If SQLchar = "'" Then
                        editSQL = editSQL + "''"
                    Else
                        editSQL = editSQL + SQLchar
                    End If
                Loop
            Else
                editSQL = strSQL
            End If
            Return editSQL
        End Function
#End Region
#Region "f_ExecuteSQLODP_TRANS SQLステートメントを発行する(COMMITする)"
        '------------------------------------------------------------------
        'プロシージャ名  :f_ExecuteSQLODP_TRANS
        '説明            :SQLステートメントを発行する(COMMITする)
        '引数            :1.strSQL      SQLステートメント
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_ExecuteSQLODP_TRANS(ByVal strSQL As String) As Boolean

            Debug.WriteLine(strSQL)
            f_ExecuteSQLODP_TRANS = False

            Dim trans As Oracle.ManagedDataAccess.Client.OracleTransaction = Nothing
            Try
                Dim Cmd As New OracleCommand(strSQL, Cnn.db.Connection)
                trans = Cnn.db.Connection.BeginTransaction()
                Cmd.ExecuteNonQuery()
                trans.Commit()
            Catch ex As OracleException
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
                trans.Rollback()
                Exit Function
            End Try
            f_ExecuteSQLODP_TRANS = True

        End Function
#End Region
#Region "f_ExecuteSQLODP SQLステートメントを発行する"
        '------------------------------------------------------------------
        'プロシージャ名  :f_ExecuteSQLODP
        '説明            :SQLステートメントを発行する
        '引数            :1.strSQL      SQLステートメント
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_ExecuteSQLODP(ByVal strSQL As String) As Boolean
            Dim blnAns As Boolean = False

            Try
                Debug.WriteLine(strSQL)

                Dim Cmd As New OracleCommand(strSQL, Cnn.db.Connection)
                Cmd.ExecuteNonQuery()
                blnAns = True
            Catch ex As OracleException
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
                Return blnAns
            End Try
            Return blnAns

        End Function
#End Region
#Region "f_Data_ExecuteNonQuery SQLを実行する"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Data_ExecuteNonQuery
        '説明            :
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Data_ExecuteNonQuery(ByVal sSQL As String) As Boolean


            Dim Cmd As New OracleCommand


            f_Data_ExecuteNonQuery = False

            Try
                With Cmd
                    .Connection = Cnn.db.Connection
                    .BindByName = True
                    .CommandText = sSQL

                    .ExecuteNonQuery()

                    If Not Cmd Is Nothing Then
                        .Dispose()
                    End If
                End With

                f_Data_ExecuteNonQuery = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
                If Not Cmd Is Nothing Then
                    Cmd.Dispose()
                End If
            End Try

        End Function
#End Region
#End Region

#Region "マスタ存在チェック"

        ''' <summary>
        ''' 生産者マスタ(TM_SEISANSYA)存在チェック
        ''' </summary>
        ''' <param name="SEISANSYA_CD">生産者コード</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function f_Exists_TM_SEISANSYA(ByVal SEISANSYA_CD As Integer) As Boolean
            Dim wkKVs As New List(Of KeyValuePair(Of String, Object))
            '■テーブル名
            Dim wkTableName = "TM_SEISANSYA"


            '■キー追加　×　N
            'wkKVs.Add(New KeyValuePair(Of String, Object)( _
            '        "列名", _
            '          値 _
            '       ))


            'キー追加(生産者コード)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "SEISANSYA_CD", _
                        SEISANSYA_CD _
                    ))


            Return f_Exists_DT(wkTableName, wkKVs.ToArray)

        End Function

        ''' <summary>
        ''' コードマスタ(TM_CODE)存在チェック
        ''' </summary>
        ''' <param name="SYURUI_KBN">処理区分</param>
        ''' <param name="MEISYO_CD">名称コード</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function f_Exists_TM_CODE(ByVal SYURUI_KBN As Integer, ByVal MEISYO_CD As Integer) As Boolean
            Dim wkKVs As New List(Of KeyValuePair(Of String, Object))
            '■テーブル名
            Dim wkTableName = "TM_CODE"


            '■キー追加　×　N
            'wkKVs.Add(New KeyValuePair(Of String, Object)( _
            '        "列名", _
            '          値 _
            '       ))


            'キー追加(種類区分)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "SYURUI_KBN", _
                        SYURUI_KBN _
                    ))

            'キー追加(名称コード)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "MEISYO_CD", _
                        MEISYO_CD _
                    ))

            Return f_Exists_DT(wkTableName, wkKVs.ToArray)

        End Function

        ''' <summary>
        ''' 代理人マスタ(TM_ITAKU)存在チェック
        ''' </summary>
        ''' <param name="ITAKU_CD">代理人番号</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function f_Exists_TM_ITAKU(ByVal ITAKU_CD As Integer) As Boolean
            Dim wkKVs As New List(Of KeyValuePair(Of String, Object))
            '■テーブル名
            Dim wkTableName = "TM_ITAKU"


            '■キー追加　×　N
            'wkKVs.Add(New KeyValuePair(Of String, Object)( _
            '        "列名", _
            '          値 _
            '       ))


            'キー追加(代理人番号)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "ITAKU_CD", _
                        ITAKU_CD _
                    ))



            Return f_Exists_DT(wkTableName, wkKVs.ToArray)

        End Function

        ''' <summary>
        ''' 金融機関マスタ(TM_BANK)存在チェック
        ''' </summary>
        ''' <param name="BANK_CD">金融機関コード</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function f_Exists_TM_BANK(ByVal BANK_CD As Integer) As Boolean
            Dim wkKVs As New List(Of KeyValuePair(Of String, Object))
            '■テーブル名
            Dim wkTableName = "TM_BANK"


            '■キー追加　×　N
            'wkKVs.Add(New KeyValuePair(Of String, Object)( _
            '        "列名", _
            '          値 _
            '       ))


            'キー追加(金融機関コード)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "BANK_CD", _
                        BANK_CD _
                    ))



            Return f_Exists_DT(wkTableName, wkKVs.ToArray)

        End Function

        ''' <summary>
        ''' 金融機関支店マスタ(TM_SITEN)存在チェック
        ''' </summary>
        ''' <param name="BANK_CD">金融機関コード</param>
        ''' <param name="SITEN_CD">金融機関支店コード</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function f_Exists_TM_SITEN(ByVal BANK_CD As Integer, ByVal SITEN_CD As Integer) As Boolean
            Dim wkKVs As New List(Of KeyValuePair(Of String, Object))
            '■テーブル名
            Dim wkTableName = "TM_SITEN"


            '■キー追加　×　N
            'wkKVs.Add(New KeyValuePair(Of String, Object)( _
            '        "列名", _
            '          値 _
            '       ))


            'キー追加(金融機関コード)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "BANK_CD", _
                        BANK_CD _
                    ))

            'キー追加(金融機関支店コード)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "SITEN_CD", _
                        SITEN_CD _
                    ))


            Return f_Exists_DT(wkTableName, wkKVs.ToArray)

        End Function

        ''' <summary>
        ''' 存在チェック
        ''' </summary>
        ''' <param name="wkTableName"></param>
        ''' <param name="wkKeys"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function f_Exists_DT(ByVal wkTableName As String, ByVal ParamArray wkKeys() As KeyValuePair(Of String, Object)) As Boolean
            Dim wkRtnBool As Boolean = False

            Try
                Using wkCmd As New Oracle.ManagedDataAccess.Client.OracleCommand
                    wkCmd.Connection = Cnn.db.Connection

                    wkCmd.CommandText = ""
                    wkCmd.CommandText &= "select * from " & wkTableName & " "
                    wkCmd.CommandText &= "Where 1=1 "

                    For i As Integer = 0 To wkKeys.Count - 1
                        wkCmd.CommandText &= "    and " & wkKeys(i).Key & " = :" & wkKeys(i).Key & " "
                        wkCmd.Parameters.Add(":" & wkKeys(i).Key & i, wkKeys(i).Value)
                    Next


                    Using wkRdr As Oracle.ManagedDataAccess.Client.OracleDataReader = wkCmd.ExecuteReader
                        wkRtnBool = wkRdr.HasRows
                    End Using

                End Using


            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox(ex.Message, C_MSGICON_ERROR)
            End Try

            Return wkRtnBool

        End Function

#End Region

#Region "メッセージ関連"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Message_Select
        '説明            :メッセージマスタ取得処理
        '引数            :
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Message_Select() As Boolean

            Dim sSql As String
            Dim Cmd As New OracleCommand
            Dim r As Long

            f_Message_Select = False

            Try
                Cmd.Connection = Cnn.db.Connection
                Cmd.BindByName = True

                sSql = " "
                sSql = sSql & " SELECT  "
                sSql = sSql & "   MESSAGECD, "
                sSql = sSql & "   MESSAGE, "
                sSql = sSql & "   MESSAGEBUTTONS, "
                sSql = sSql & "   MESSAGEICON, "
                sSql = sSql & "   DEFAULTBUTTON "
                sSql = sSql & " FROM  "
                sSql = sSql & "   TM_MESSAGE "
                sSql = sSql & " ORDER BY MESSAGECD "

                Cmd.CommandText = sSql


                Dim rdr As OracleDataReader = Cmd.ExecuteReader

                r = 0
                ReDim pMESSAGE_Array(r)
                ReDim pMESSAGE_CD_Array(r)

                While rdr.Read
                    ReDim Preserve pMESSAGE_Array(r)
                    ReDim Preserve pMESSAGE_CD_Array(r)

                    pMESSAGE_CD_Array(r) = WordHenkan("N", "S", rdr("MESSAGECD"))
                    pMESSAGE_Array(r).CD = WordHenkan("N", "S", rdr("MESSAGECD"))
                    pMESSAGE_Array(r).MESSAGE = WordHenkan("N", "S", rdr("MESSAGE"))
                    pMESSAGE_Array(r).BUTTON = WordHenkan("N", "S", rdr("MESSAGEBUTTONS"))
                    pMESSAGE_Array(r).ICON = WordHenkan("N", "S", rdr("MESSAGEICON"))
                    pMESSAGE_Array(r).DEF = WordHenkan("N", "S", rdr("DEFAULTBUTTON"))

                    r = r + 1

                End While

                If r > 0 Then
                Else
                    ''Show_MessageBox("000011", "") 'マスタにデータが登録されていません。
                    'Show_MessageBox("", "マスタにデータが登録されていません。") 'マスタにデータが登録されていません。
                End If
                rdr.Close()


                If Not Cmd Is Nothing Then
                    Cmd.Dispose()
                End If

                f_Message_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                If Not Cmd Is Nothing Then
                    Cmd.Dispose()
                End If
            End Try

        End Function
#End Region

#Region "タイトル表示関連"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Title_Get
        '説明            :タイトル表題取得処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '                 外部共通変数:pAPPTITLEにタイトル表題文字列が入る
        '------------------------------------------------------------------
        Public Function f_Title_Get() As Boolean

            Dim sSql As String = String.Empty
            Dim dstDataSet As New DataSet

            f_Title_Get = False

            Try
                pAPPTITLE = ""

                If Trim(pAPP) = "" Then
                    ''Show_MessageBox("プログラムＩＤが指定されていません。", C_MSGICON_ERROR)
                    pAPPTITLE = "ID未指定"
                Else
                    'Cmd.Connection = Cnn
                    'Cmd.BindByName = True

                    sSql = " "
                    'sSql = sSql & " SELECT  " & vbCrLf
                    'sSql = sSql & " CHOHYO_ID, " & vbCrLf
                    'sSql = sSql & " KINO_NAME, " & vbCrLf
                    'sSql = sSql & " SIYO_KBN1, " & vbCrLf
                    'sSql = sSql & " SIYO_KBN2, " & vbCrLf
                    'sSql = sSql & " SIYO_KBN3, " & vbCrLf
                    'sSql = sSql & " SIYO_KBN4, " & vbCrLf
                    'sSql = sSql & " SIYO_KBN5 " & vbCrLf
                    'sSql = sSql & " FROM  " & vbCrLf
                    'sSql = sSql & " TM_SYORIKINO " & vbCrLf
                    'sSql = sSql & " WHERE "
                    'sSql = sSql & " KINO_ID = '" & pAPP & "'" & vbCrLf
                    sSql = sSql & " SELECT  " & vbCrLf
                    sSql = sSql & " PROGRAMNM, " & vbCrLf
                    sSql = sSql & " PROGRAMKBN " & vbCrLf
                    sSql = sSql & " FROM  " & vbCrLf
                    sSql = sSql & " TM_PROGRAM " & vbCrLf
                    sSql = sSql & " WHERE "
                    sSql = sSql & " PROGRAMID = '" & pAPP & "'" & vbCrLf

                    Call f_Select_ODP(dstDataSet, sSql)

                    With dstDataSet.Tables(0)
                        If .Rows.Count > 0 Then
                            'For i As Integer = 0 To .Rows.Count - 1
                            'pAPPTITLE = WordHenkan("N", "S", .Rows(0)("KINO_NAME"))
                            pAPPTITLE = WordHenkan("N", "S", .Rows(0)("PROGRAMNM"))
                            'Next
                        Else
                            'レコードなし
                            ''Show_MessageBox("000004", "") '該当データが存在しません。
                            pAPPTITLE = "DB未登録"
                        End If
                    End With

                    f_Title_Get = True
                End If

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_SyoriYmdw_Get
        '説明            :タイトル日付文字取得処理
        '引数            :なし
        '戻り値          :String(タイトルエリアに表示する日付文字列)
        '------------------------------------------------------------------
        Public Function f_SyoriYmdw_Get() As String
            Dim sWeek As String = ""
            Dim dSysdate As Date = System.DateTime.Now

            f_SyoriYmdw_Get = ""

            Try

                ' システム日付および曜日を表示する
                Select Case Weekday(dSysdate)
                    Case FirstDayOfWeek.Sunday
                        sWeek = "日"
                    Case FirstDayOfWeek.Monday
                        sWeek = "月"
                    Case FirstDayOfWeek.Tuesday
                        sWeek = "火"
                    Case FirstDayOfWeek.Wednesday
                        sWeek = "水"
                    Case FirstDayOfWeek.Thursday
                        sWeek = "木"
                    Case FirstDayOfWeek.Friday
                        sWeek = "金"
                    Case FirstDayOfWeek.Saturday
                        sWeek = "土"
                    Case Else
                        sWeek = ""
                End Select

                f_SyoriYmdw_Get = Format(dSysdate, "yyyy年M月d日") & "（" & sWeek & "）"

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_KikinFlg_Get
        '説明            :タイトル表題取得処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '                 外部共通変数:pAPPTITLEにタイトル表題文字列が入る
        '------------------------------------------------------------------
        Public Function f_KikinFlg_Get() As Boolean
            Dim ret As Boolean = False
            Dim wSql As String = String.Empty
            Dim wkDS As New DataSet

            Try

                '初期値
                pKikin2 = False

                'コードマスタ検索
                wSql = "SELECT MEISYO_CD FROM TM_CODE " & _
                        "WHERE SYURUI_KBN = 0" & _
                        "  AND MEISYO_CD = 99"

                'DBからデータを取得
                If f_Select_ODP(wkDS, wSql) = False Then
                    Exit Try
                End If

                'データ有は第２基金
                If wkDS.Tables(0).Rows.Count > 0 Then
                    pKikin2 = True
                End If

                ret = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

            Return ret

        End Function

#End Region

#Region "操作ログ出力関連"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Title_Get
        '説明            :操作ログ出力処理
        '引数            :1.intKaisiSyuryoFlg  開始・終了フラグ(0:開始 1:終了)
        '*                2.strTableName    テーブル名
        '*                3.strCriteria     Optional    Where句
        '*                4.strFields       Optional    項目
        '戻り値          :Boolean(正常True/エラーFalse)
        '                 外部共通変数:pAPPTITLEにタイトル表題文字列が入る
        '------------------------------------------------------------------
        Public Function f_InfoLog_Put(ByVal intKaisiSyuryoFlg As Integer) As Boolean
            Dim Cmd As New OracleCommand
            Dim blnErr As Boolean = False
            Dim ret As Boolean = False

            Dim nKAISI_SYURYO_FLG As Integer = intKaisiSyuryoFlg
            Dim dSYORI_DATE As Date = CDate(Format(Now, "yyyy/MM/dd HH:mm:ss"))
            Dim sPGCD As String = pAPP
            Dim sSYORI_NAME As String = pAPPTITLE
            Dim dREG_DATE As Date = dSYORI_DATE
            'Dim sREG_ID As String = pAPP               '2010/11/10 DEL JBD200
            Dim sREG_ID As String = pLOGINUSERID        '2010/11/10 ADD JBD200 ＰＧＩＤからログインユーザＩＤに変更
            Dim sCOM_NAME As String = ""

            'Dim dstDataSet As New DataSet

            Try

                'ストアドプロシージャの呼び出し
                Cmd.Connection = Cnn.db.Connection
                Cmd.CommandType = CommandType.StoredProcedure
                '
                Cmd.CommandText = "PKG_SYORI_RIREKI.SYORI_RIREKI_INS"

                '引き渡し
                Dim paraKAISISYURYO As OracleParameter = _
                                Cmd.Parameters.Add("IN_SYORI_RIREKI_KAISI_SYURYO", nKAISI_SYURYO_FLG)
                Dim paraSYORIDATE As OracleParameter = _
                                Cmd.Parameters.Add("IN_SYORI_RIREKI_SYORI_DATE", dSYORI_DATE)
                Dim paraPGCD As OracleParameter = _
                                Cmd.Parameters.Add("IN_SYORI_RIREKI_PG_CD", sPGCD)
                Dim paraSYORINAME As OracleParameter = _
                                Cmd.Parameters.Add("IN_SYORI_RIREKI_SYORI_NAME", sSYORI_NAME)
                Dim paraREGDATE As OracleParameter = _
                                Cmd.Parameters.Add("IN_SYORI_RIREKI_REG_DATE", dREG_DATE)
                Dim paraREGID As OracleParameter = _
                                Cmd.Parameters.Add("IN_SYORI_RIREKI_REG_ID", sREG_ID)
                Dim paraCOMNAME As OracleParameter = _
                                Cmd.Parameters.Add("IN_SYORI_RIREKI_COM_NAME", pPCNAME)

                '戻り
                Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
                Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

                Cmd.ExecuteNonQuery()
                Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())

                'データベースへの接続を閉じる
                If Not Cmd Is Nothing Then
                    Cmd.Dispose()
                End If

                blnErr = False          'エラーなし

                ret = True

            Catch ex As Exception
                '共通例外処理
                If ex.Message <> "Err" Then
                    'Show_MessageBox("", ex.Message)
                End If
            Finally
                'エラー有りの時、ロールバック
                If blnErr Then
                    ''RollBack
                    'If blnIsTran = True Then
                    '    myTrans.Rollback()
                    'End If
                    Cmd.Dispose()
                End If
            End Try

            Return ret

        End Function

#End Region

#Region "f_Output_Excel Excel出力処理"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Output_Excel
        '説明            :CSV出力処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Private Function f_Output_Excel(ByVal sSql As String) As Boolean
            Dim ret As Boolean = False

            Dim dstDataSet As New DataSet
            Dim strKENCD As String = String.Empty
            Dim newErr As Boolean = False
            Dim strOutPath As String = String.Empty
            Dim dRow As DataRow
            Dim blnExist As Boolean = False

            ret = False

            Try

                If Not f_Select_ODP(dstDataSet, sSql) Then
                    Exit Try
                End If

                If dstDataSet.Tables(0).Rows.Count > 0 Then

                    For i As Integer = 0 To dstDataSet.Tables(0).Rows.Count - 1


                        'シートの2行目からデータを出力する（初期化）
                        pRow = 2

                        '----- (6)ブックを保存します -----
                        'ファイル保存/メモリ解放
                        If Not f_XlsFileSave(strOutPath) Then
                            Exit Try
                        End If

                        '----- (1)新しいブックの作成 -----

                        ''開始時間の取得
                        'pUKEIRE_YMDHMS = Now.ToString


                        '出力件数の初期化
                        pCNT = 0

                        blnExist = False
                        ''県毎にTemplateファイルよりExcelファイルを作成→オープン
                        'If f_ExcelMake_KEN(dstDataSet, strKENCD, strOutPath, newErr) Then
                        '    blnExist = True
                        'End If

                        '----- (4)明細データをシートへ出力 -----
                        If blnExist Then
                            dRow = dstDataSet.Tables(0).Rows(i)

                            If Not f_SetExcelData(dRow) Then
                                Exit Try
                            End If

                            pRow += 1
                        End If
                    Next

                    If blnExist Then
                        '----- (7)まだ最後のブックは保存されていないので、保存・解放します -----
                        '最後の県コードのファイル保存/メモリ解放
                        If Not f_XlsFileSave(strOutPath) Then
                            Exit Try
                        End If

                    End If
                    dstDataSet.Clear()
                    dstDataSet.Dispose()

                Else
                    'エラーリスト出力なし
                    'Show_MessageBox("I002", "") '該当データが存在しません。
                    Exit Try
                End If

                ret = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                xl.xlCloseComObject()
                'メモリを解放します
                Call s_GC_Dispose()
            End Try

            Return ret

        End Function
#End Region

#Region "f_SetExcelData Excel出力用データ作成"
        '------------------------------------------------------------------
        'プロシージャ名  :f_SetExcelData
        '説明            :Excel出力用データ作成
        '引数            :なし
        '戻り値          :String(SQL文)
        '------------------------------------------------------------------
        Private Function f_SetExcelData(ByVal dRow As DataRow) As Boolean
            Dim ret As Boolean = False

            Try

                'セルにデータを作成 セット例)xl.SetdataCell(行番号, セル番号, 内容)

                xl.SetdataCell(pRow, 1, dRow("SNKCD"))      '対象生産者番号
                xl.SetdataCell(pRow, 2, dRow("SNKNM"))      '対象生産者名
                xl.SetdataCell(pRow, 3, dRow("JYUFUKU"))    '重複フラグ
                xl.SetdataCell(pRow, 4, dRow("CD"))         '管理者番号
                xl.SetdataCell(pRow, 5, dRow("NAME"))       '管理者名
                xl.SetdataCell(pRow, 6, dRow("ITKCD"))      '事務委託先コード
                xl.SetdataCell(pRow, 7, dRow("ITKNM"))      '事務委託先名

                pCNT += 1       '参加者数をカウント

                ret = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

            Return ret

        End Function
#End Region

#Region "f_XlsFileSave ファイル保存、メモリ解放"
        '------------------------------------------------------------------
        'プロシージャ名  :f_XlsFileSave
        '説明            :ファイル保存、メモリ解放
        '引数            :strOutPath  対象ファイルパス
        '戻り値          :boolean(True:正常終了/False:異常終了)
        '------------------------------------------------------------------
        Private Function f_XlsFileSave(ByVal strOutPath As String) As Boolean
            Dim ret As Boolean = False

            Try
                '既にExcelファイル作成処理を行っている場合は次の件の処理を行う前に
                'ファイルを保存

                '保存する前に先頭のテンプレートシートを削除する
                xl.WorkSheetDelete(1)
                '==保存処理==
                xl.xlSaveWorkBook(strOutPath)
                '==オブジェクトの解放==
                xl.xlCloseComObject()

                ret = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

            Return ret

        End Function
#End Region

#Region "FROM～TO動作制御"

        '------------------------------------------------------------------
        'プロシージャ名  :s_From_Validating
        '説明            :FROM～TO項目のFROM側動作制御（対応オブジェクト：GcString,GcNumber）
        '                 FROM側項目のValidatingでCallする
        '引数            :1.txtFrom     Object       FROM側オブジェクト
        '                 2.txtTo       Object       TO側オブジェクト
        '戻り値          :無し
        '------------------------------------------------------------------
        Public Sub s_From_Validating(ByVal txtFrom As Object, ByVal txtTo As Object)

            Select Case TypeName(txtFrom)

                Case "GcString"
                    'ﾃｷｽﾄﾎﾞｯｸｽ

                    If txtFrom.Text = "" Then
                        'FM未入力でTOが入力だった時
                        If txtTo.Text <> "" Then
                            txtTo.Text = ""
                        End If
                        Exit Sub
                    End If

                    'FROM入力でTOが未入力だった時
                    If txtTo.Text = "" Then
                        'TOにFROMの内容をセット
                        txtTo.Text = txtFrom.Text
                    End If

                Case "GcNumber"
                    '数値型

                    '↓***** 2011/06/27 JBD200 ZEROは未入力と判断するのではなく入力可能とするよう変更 *****↓
                    'If txtFrom.Text = "" Or txtFrom.Text = "0" Then
                    '    'FM未入力でTOが入力だった時
                    '    If txtTo.Text <> "" And txtTo.Text <> "0" Then
                    '        txtTo.Text = ""
                    '    End If
                    '    Exit Sub
                    'End If

                    ''FROM入力でTOが未入力だった時
                    'If txtTo.Text = "" Or txtTo.Text = "0" Then
                    '    'TOにFROMの内容をセット
                    '    txtTo.Text = txtFrom.Text
                    'End If

                    If txtFrom.Text = "" Then
                        'FM未入力でTOが入力だった時
                        If txtTo.Text <> "" Then
                            txtTo.Text = ""
                        End If
                        Exit Sub
                    End If

                    'FROM入力でTOが未入力だった時
                    If txtTo.Text = "" Then
                        'TOにFROMの内容をセット
                        txtTo.Text = txtFrom.Text
                    End If
                '↑***** 2011/06/27 JBD200 ZEROは未入力と判断するのではなく入力可能とするよう変更 *****↑

                Case "GcDate"
                    '日付型

                    If txtFrom.Value Is Nothing Then
                        'FM未入力でTOが入力だった時
                        If Not txtTo.Value Is Nothing Then
                            txtTo.Text = txtFrom.Text
                        End If
                        Exit Sub
                    End If

                    'FROM入力でTOが未入力だった時
                    If txtTo.Value Is Nothing Then
                        'TOにFROMの内容をセット
                        txtTo.Text = txtFrom.Text
                    End If

            End Select

        End Sub

        '------------------------------------------------------------------
        'プロシージャ名  :s_To_Validating
        '説明            :FROM～TO項目のTO側動作制御（対応オブジェクト：GcString,GcNumber）
        '                 TO側項目のValidatingでCallする
        '引数            :1.txtTo     Object       TO側オブジェクト
        '                 2.txtFrom   Object       FROM側オブジェクト
        '戻り値          :無し
        '------------------------------------------------------------------
        Public Sub s_To_Validating(ByVal txtTo As Object, ByVal txtFrom As Object)

            Select Case TypeName(txtTo)

                Case "GcString"
                    'ﾃｷｽﾄﾎﾞｯｸｽ

                    If txtTo.Text = "" Then
                        If txtFrom.Text <> "" Then
                            'TO未入力でFROMが入力だった時、FROMの内容をTOにセット
                            txtTo.Text = txtFrom.Text
                        End If
                        Exit Sub
                    End If

                    If txtFrom.Text <> "" Then
                        'TO入力でFROMも入力だった時、何もせずスルーする
                    Else
                        'TO入力でFROMが未入力だった時、TOの内容をFROMにセット
                        txtFrom.Text = txtTo.Text
                    End If

                Case "GcNumber"
                    '数値型
                    '↓***** 2011/06/27 JBD200 ZEROは未入力と判断するのではなく入力可能とするよう変更 *****↓
                    'If txtTo.Text = "" Or txtTo.Text = "0" Then
                    '    If txtFrom.Text <> "" And txtFrom.Text <> "0" Then
                    '        'TO未入力でFROMが入力だった時、FROMの内容をTOにセット
                    '        txtTo.Text = txtFrom.Text
                    '    End If
                    '    Exit Sub
                    'End If

                    'If txtFrom.Text <> "" And txtFrom.Text <> "0" Then
                    '    'TO入力でFROMも入力だった時、何もせずスルーする
                    'Else
                    '    'TO入力でFROMが未入力だった時、TOの内容をFROMにセット
                    '    txtFrom.Text = txtTo.Text
                    'End If

                    If txtTo.Text = "" Then
                        If txtFrom.Text <> "" Then
                            'TO未入力でFROMが入力だった時、FROMの内容をTOにセット
                            txtTo.Text = txtFrom.Text
                        End If
                        Exit Sub
                    End If

                    If txtFrom.Text <> "" Then
                        'TO入力でFROMも入力だった時、何もせずスルーする
                    Else
                        'TO入力でFROMが未入力だった時、TOの内容をFROMにセット
                        txtFrom.Text = txtTo.Text
                    End If
                '↑***** 2011/06/27 JBD200 ZEROは未入力と判断するのではなく入力可能とするよう変更 *****↑

                Case "GcDate"
                    '日付型

                    If txtTo.Value Is Nothing Then
                        If Not txtFrom.Value Is Nothing Then
                            'TO未入力でFROMが入力だった時、FROMの内容をTOにセット
                            txtTo.Text = txtFrom.Text
                        End If
                        Exit Sub
                    End If

                    If Not txtFrom.Value Is Nothing Then
                        'TO入力でFROMも入力だった時、何もせずスルーする
                    Else
                        'TO入力でFROMが未入力だった時、TOの内容をFROMにセット
                        txtFrom.Text = txtTo.Text
                    End If

            End Select

        End Sub

        '------------------------------------------------------------------
        'プロシージャ名  :s_CboFrom_Validating
        '説明            :FROM～TO項目のFROM側動作制御（対応オブジェクト：GcComboBox）
        '                 FROM側項目のValidatingでCallする
        '引数            :1.cboCdFrom       Object       FROM側コードコンボオブジェクト
        '                 2.cboMeiFrom      Object       FROM側名称コンボオブジェクト
        '                 3.cboCdTo         Object       TO側コードコンボオブジェクト
        '                 4.cboMeiTo        Object       TO側名称コンボオブジェクト
        '                 5.strCharNumFlg   String       数値・文字フラグ("0":数値(省略時既定)(Long型) "1":文字 "2":数値(Decimal型))
        '戻り値          :無し
        '------------------------------------------------------------------
        Public Sub s_CboFrom_Validating(ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object, ByVal cboCdTo As Object, ByVal cboMeiTo As Object, ByVal strCharNumFlg As String)
            Dim strFmtwk As String = "0"
            Dim strFmt As String

            If cboCdFrom.Text = "" Then
                'FM未入力でTOが入力だった時
                If cboCdTo.Text <> "" Then
                    cboCdTo.SelectedIndex = -1
                End If
                Exit Sub
            End If

            'コードの１桁目が0の場合は０を削除
            'If Mid(cboCdFrom.Text, 1, 1) = 0 Then
            '    cboCdFrom.Text = Mid(cboCdFrom.Text, 2, 1)
            '    Exit Sub
            'End If
            If strCharNumFlg = "1" Then
                'DB項目が文字
                strFmt = strFmtwk.PadRight(cboCdFrom.MaxLength, "0")
                cboCdFrom.Text = Format(CLng(cboCdFrom.Text), strFmt)
                cboCdFrom.SelectedValue = Format(CLng(cboCdFrom.Text), strFmt)  '2015/03/03 JBD368 ADD

                '2015/03/03 JBD368 ADD ↓↓↓設定値がDecimal型の場合を考慮
            ElseIf strCharNumFlg = "2" Then

                'DB項目が数値(Decimal型)
                cboCdFrom.Text = CDec(cboCdFrom.Text)
                cboCdFrom.SelectedValue = CDec(cboCdFrom.Text)
                '2015/03/03 JBD368 ADD ↑↑↑
            Else
                'DB項目が数値(Long型)
                cboCdFrom.Text = CLng(cboCdFrom.Text)
                cboCdFrom.SelectedValue = cboCdFrom.Text  '2015/03/03 JBD368 ADD
            End If

            'cboCdFrom.SelectedValue = cboCdFrom.Text     '2015/03/03 JBD368 DEL 型によってSelectedValueを設定値を変更するため削除

            If cboCdFrom.SelectedValue Is Nothing Then
                cboCdFrom.SelectedIndex = -1
                cboMeiFrom.SelectedIndex = -1
                'Show_MessageBox_Add("W012", cboCdFrom.Tag) '指定された@0が正しくありません。
                cboCdFrom.Focus()
            Else
                'FROM入力でTOが未入力だった時
                If cboCdTo.Text = "" Then
                    cboCdTo.SelectedValue = cboCdFrom.Text
                End If
            End If

        End Sub

        Public Sub s_CboFrom_Validating(ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object, ByVal cboCdTo As Object, ByVal cboMeiTo As Object)

            Call s_CboFrom_Validating(cboCdFrom, cboMeiFrom, cboCdTo, cboMeiTo, "0")

        End Sub


        '------------------------------------------------------------------
        'プロシージャ名  :s_CboTo_Validating
        '説明            :FROM～TO項目のTO側動作制御（対応オブジェクト：GcComboBox）
        '                 TO側項目のValidatingでCallする
        '引数            :1.cboCdTo         Object       TO側コードコンボオブジェクト
        '                 2.cboMeiTo        Object       TO側名称コンボオブジェクト
        '                 3.cboCdFrom       Object       FROM側コードコンボオブジェクト
        '                 4.cboMeiFrom      Object       FROM側名称コンボオブジェクト
        '                 5.strCharNumFlg   String       数値・文字フラグ("0":数値(省略時既定)(Long型) "1":文字 "2":数値(Decimal型))
        '戻り値          :無し
        '------------------------------------------------------------------
        Public Sub s_CboTo_Validating(ByVal cboCdTo As Object, ByVal cboMeiTo As Object, ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object, ByVal strCharNumFlg As String)
            Dim strFmtwk As String = "0"
            Dim strFmt As String

            If cboCdTo.Text = "" Then
                If cboCdFrom.Text <> "" Then
                    'TO未入力でFROMが入力だった時、FROMの内容をTOにセット
                    '↓2018/06/27 修正
                    'cboCdTo.SelectedValue = cboCdFrom.Text
                    If strCharNumFlg = "1" Then
                        'DB項目が文字
                        strFmt = strFmtwk.PadRight(cboCdFrom.MaxLength, "0")
                        cboCdTo.SelectedValue = Format(CLng(cboCdFrom.Text), strFmt)
                    ElseIf strCharNumFlg = "2" Then
                        'DB項目が数値(Decimal型)
                        cboCdTo.SelectedValue = CDec(cboCdFrom.Text)
                    Else
                        'DB項目が数値(Long型)
                        cboCdTo.SelectedValue = cboCdFrom.Text
                    End If
                    '↑2018/06/27 修正
                End If
                Exit Sub
            End If

            'コードの１桁目が0の場合は０を削除
            'If Mid(cboCdTo.Text, 1, 1) = 0 Then
            '    cboCdTo.Text = Mid(cboCdTo.Text, 2, 1)
            '    Exit Sub
            'End If
            'cboCdTo.Text = CLng(cboCdTo.Text)
            If strCharNumFlg = "1" Then
                'DB項目が文字
                strFmt = strFmtwk.PadRight(cboCdFrom.MaxLength, "0")
                cboCdTo.Text = Format(CLng(cboCdTo.Text), strFmt)
                cboCdTo.SelectedValue = Format(CLng(cboCdTo.Text), strFmt)  '2015/03/03 JBD368 ADD

                '2015/03/03 JBD368 ADD ↓↓↓ 設定値がDecimal型の場合を考慮
            ElseIf strCharNumFlg = "2" Then

                'DB項目が数値(Decimal型)
                cboCdTo.Text = CDec(cboCdTo.Text)
                cboCdTo.SelectedValue = CDec(cboCdTo.Text)
                '2015/03/03 JBD368 ADD ↑↑↑
            Else
                'DB項目が数値(Long型)
                cboCdTo.Text = CLng(cboCdTo.Text)
                cboCdTo.SelectedValue = cboCdTo.Text      '2015/03/03 JBD368 ADD
            End If

            'cboCdTo.SeletedItem.Value = cboCdTo.Text            '2015/03/03 JBD368 DEL 型によってSelectedValueを設定値を変更するため削除

            If cboCdTo.SelectedValue Is Nothing Then
                cboCdTo.SelectedIndex = -1
                cboMeiTo.SelectedIndex = -1
                'Show_MessageBox_Add("W012", cboCdFrom.Tag) '指定された@0が正しくありません。

                cboCdTo.Focus()
            Else
                If cboCdFrom.Text <> "" Then
                    'TO入力でFROMも入力だった時、何もせずスルー
                Else
                    'TO入力でFROMが未入力だった時、TOの内容をFROMにセット
                    cboCdFrom.SelectedValue = cboCdTo.Text
                End If
            End If

        End Sub

        Public Sub s_CboTo_Validating(ByVal cboCdTo As Object, ByVal cboMeiTo As Object, ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object)

            Call s_CboTo_Validating(cboCdTo, cboMeiTo, cboCdFrom, cboMeiFrom, "0")

        End Sub

        '------------------------------------------------------------------
        'プロシージャ名  :s_CboMeiFrom_SelectedIndexChanged
        '説明            :FROM～TO項目のFROM側名称コンボ動作制御（対応オブジェクト：GcComboBox）
        '                 FROM側名称コンボ項目のValidatingでCallする
        '引数            :1.cboMeiFrom      Object       FROM側名称コンボオブジェクト
        '                 2.cboCdFrom       Object       FROM側コードコンボオブジェクト
        '                 3.cboMeiTo        Object       TO側名称コンボオブジェクト
        '                 4.cboCdTo         Object       TO側コードコンボオブジェクト
        '戻り値          :無し
        '------------------------------------------------------------------
        Public Sub s_CboMeiFrom_SelectedIndexChanged(ByVal cboMeiFrom As Object, ByVal cboCdFrom As Object, ByVal cboMeiTo As Object, ByVal cboCdTo As Object)

            cboCdFrom.SelectedIndex = cboMeiFrom.SelectedIndex

            If cboCdFrom.Text = "" Then
                'FM未入力でTOが入力だった時
                'If cboCdTo.Text <> "" Then
                '    cboCdTo.SelectedIndex = -1
                'End If
                Exit Sub
            Else
                If cboCdTo.Text = "" Then
                    cboCdTo.SelectedIndex = cboCdFrom.SelectedIndex
                End If
            End If

        End Sub

        '------------------------------------------------------------------
        'プロシージャ名  :s_CboMeiTo_Validating
        '説明            :FROM～TO項目のTO側動作制御（対応オブジェクト：GcComboBox）
        '                 TO側項目のValidatingでCallする
        '引数            :1.cboMeiTo    Object       TO側名称コンボオブジェクト
        '                 2.cboCdTo     Object       TO側コードコンボオブジェクト
        '                 3.cboMeiFrom  Object       FROM側名称コンボオブジェクト
        '                 4.cboCdFrom   Object       FROM側コードコンボオブジェクト
        '戻り値          :無し
        '------------------------------------------------------------------
        Public Sub s_CboMeiTo_Validating(ByVal cboMeiTo As Object, ByVal cboCdTo As Object, ByVal cboMeiFrom As Object, ByVal cboCdFrom As Object)

            cboCdTo.SelectedIndex = cboMeiTo.SelectedIndex

            If cboCdTo.Text = "" Then
                'If cob_KenCdFm.Text <> "" Then
                '    'TO未入力でFROMが入力だった時、FROMの内容をTOにセット
                '    cob_KenCdTo.SelectedIndex = cob_KenCdFm.SelectedIndex
                'End If
                Exit Sub
            End If

            If cboCdFrom.Text <> "" Then
                'TO入力でFROMも入力だった時、何もせずスルー
            Else
                'TO入力でFROMが未入力だった時、TOの内容をFROMにセット
                cboCdFrom.SelectedIndex = cboCdTo.SelectedIndex
            End If

        End Sub

#End Region

#Region "f_Daisyo_Check 大小チェック"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Daisyo_Check
        '説明            :FROM-TO項目内容大小チェック
        '引数            :objCtrlFrom(FROM側ｵﾌﾞｼﾞｪｸﾄ)
        '                 objCtrlTo(TO側ｵﾌﾞｼﾞｪｸﾄ)
        '                 strKoumokuNm(ｴﾗｰﾒｯｾｰｼﾞ表示時の項目名)
        '                 MsgDsp(メッセージ表示有無)
        '                 intZokusei(項目属性 0:String項目(数値以外の文字を入力可) 1:Number項目(数値以外の文字は入力不可) 
        '                                     2:Date項目  3:Number項目(0は入力とみなす)
        '戻り値          :Boolean(正常True/エラーFalse)
        '修正日          :2014/08/11
        '------------------------------------------------------------------
        Public Function f_Daisyo_Check(ByVal objCtrlFrom As Object, ByVal objCtrlTo As Object, ByVal strKoumokuNm As String,
                                        ByVal MsgDsp As Boolean, Optional ByVal intZokusei As Integer = 0) As Boolean
            Dim ret As Boolean = False

            Try

                Select Case TypeName(objCtrlFrom)
                    Case "GcString", "GcComboBox"
                        'FROM入力なし
                        If (objCtrlFrom.Text Is Nothing OrElse objCtrlFrom.Text.TrimEnd = "") AndAlso
                            (Not objCtrlTo.Text Is Nothing AndAlso objCtrlTo.Text.TrimEnd <> "") Then
                            If MsgDsp Then
                                'Show_MessageBox_Add("W008", strKoumokuNm & "From") '@0は必須入力項目です。
                            End If
                            objCtrlFrom.Focus()
                            Exit Try
                        End If

                        'TO入力なし
                        If (objCtrlTo.Text Is Nothing OrElse objCtrlTo.Text.TrimEnd = "") AndAlso
                            (Not objCtrlFrom.Text Is Nothing AndAlso objCtrlFrom.Text.TrimEnd <> "") Then
                            If MsgDsp Then
                                'Show_MessageBox_Add("W008", strKoumokuNm & "To")    '@0は必須入力項目です。
                            End If
                            objCtrlFrom.Focus()
                            Exit Try
                        End If

                        '大小チェック
                        If objCtrlFrom.Text Is Nothing AndAlso objCtrlTo.Text Is Nothing Then
                        Else
                            If (Not objCtrlFrom.Text Is Nothing AndAlso objCtrlFrom.Text.TrimEnd <> "") AndAlso
                                (Not objCtrlTo.Text Is Nothing AndAlso objCtrlTo.Text.TrimEnd <> "") Then       '2010/11/24 UPD JBD200 比較条件修正
                                If intZokusei = 1 Then
                                    If CDec(objCtrlFrom.Text.ToString.TrimEnd) > CDec(objCtrlTo.Text.ToString.TrimEnd) Then     '2010/11/24 UPD JBD200 TEXTを数値に変換して比較するよう修正
                                        If MsgDsp Then
                                            'Show_MessageBox_Add("W003", "指定された" & strKoumokuNm)    '@0の範囲指定が正しくありません。
                                        End If
                                        objCtrlFrom.Focus()
                                        Exit Try
                                    End If
                                Else
                                    If objCtrlFrom.Text > objCtrlTo.Text Then
                                        If MsgDsp Then
                                            'Show_MessageBox_Add("W003", "指定された" & strKoumokuNm)    '@0の範囲指定が正しくありません。
                                        End If
                                        objCtrlFrom.Focus()
                                        Exit Try
                                    End If
                                End If
                            End If
                        End If

                    Case "GcDate"
                        'FROM入力なし
                        If objCtrlFrom.value Is Nothing AndAlso Not objCtrlTo.value Is Nothing Then
                            If MsgDsp Then
                                'Show_MessageBox_Add("W008", strKoumokuNm & "From") '@0は必須入力項目です。
                            End If
                            objCtrlFrom.Focus()
                            Exit Try
                        End If

                        'TO入力なし
                        If objCtrlTo.value Is Nothing AndAlso Not objCtrlFrom.value Is Nothing Then
                            If MsgDsp Then
                                'Show_MessageBox_Add("W008", strKoumokuNm & "To")    '@0は必須入力項目です。
                            End If
                            objCtrlFrom.Focus()
                            Exit Try
                        End If

                        '大小チェック
                        If objCtrlFrom.value Is Nothing AndAlso objCtrlTo.value Is Nothing Then
                        Else
                            If objCtrlFrom.Value > objCtrlTo.Value Then
                                If MsgDsp Then
                                    'Show_MessageBox_Add("W003", "指定された" & strKoumokuNm)    '@0の範囲指定が正しくありません。
                                End If
                                objCtrlFrom.Focus()
                                Exit Try
                            End If
                        End If

                    Case "GcNumber"
                        '0入力ＯＫ
                        If intZokusei = 3 Then
                            'FROM入力なし
                            If (objCtrlFrom.Value Is Nothing) AndAlso Not (objCtrlTo.Value Is Nothing) Then
                                If MsgDsp Then
                                    'Show_MessageBox_Add("W008", strKoumokuNm & "From") '@0は必須入力項目です。
                                End If
                                objCtrlFrom.Focus()
                                Exit Try
                            End If

                            'TO入力なし
                            If Not (objCtrlFrom.Value Is Nothing) AndAlso (objCtrlTo.Value Is Nothing) Then
                                If MsgDsp Then
                                    'Show_MessageBox_Add("W008", strKoumokuNm & "To")    '@0は必須入力項目です。
                                End If
                                objCtrlTo.Focus()
                                Exit Try
                            End If

                            '大小チェック
                            If (objCtrlFrom.Value Is Nothing AndAlso objCtrlTo.Value Is Nothing) Then
                            Else
                                If objCtrlFrom.Value > objCtrlTo.Value Then
                                    If MsgDsp Then
                                        'Show_MessageBox_Add("W003", "指定された" & strKoumokuNm)    '@0の範囲指定が正しくありません。
                                    End If
                                    objCtrlFrom.Focus()
                                    Exit Try
                                End If
                            End If
                        Else
                            '0入力は未入力とみなす
                            'FROM入力なし
                            If (objCtrlFrom.Value Is Nothing OrElse objCtrlFrom.Value = 0) AndAlso
                                (Not objCtrlTo.Value Is Nothing AndAlso objCtrlTo.Value <> 0) Then
                                If MsgDsp Then
                                    'Show_MessageBox_Add("W008", strKoumokuNm & "From") '@0は必須入力項目です。
                                End If
                                objCtrlFrom.Focus()
                                Exit Try
                            End If

                            'TO入力なし
                            If (objCtrlTo.Value Is Nothing OrElse objCtrlTo.Value = 0) AndAlso
                                (Not objCtrlFrom.Value Is Nothing AndAlso objCtrlFrom.Value <> 0) Then
                                If MsgDsp Then
                                    'Show_MessageBox_Add("W008", strKoumokuNm & "To")    '@0は必須入力項目です。
                                End If
                                objCtrlTo.Focus()
                                Exit Try
                            End If

                            '大小チェック
                            If (objCtrlFrom.Value Is Nothing OrElse objCtrlFrom.Value = 0) AndAlso
                                (objCtrlTo.Value Is Nothing OrElse objCtrlTo.Value = 0) Then
                            Else
                                If objCtrlFrom.Value > objCtrlTo.Value Then
                                    If MsgDsp Then
                                        'Show_MessageBox_Add("W003", "指定された" & strKoumokuNm)    '@0の範囲指定が正しくありません。
                                    End If
                                    objCtrlFrom.Focus()
                                    Exit Try
                                End If
                            End If
                        End If

                End Select

                ret = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

            Return ret

        End Function

#End Region

#Region "** その他制御 ***"
#Region "s_GC_Dispose メモリの解放"
        '------------------------------------------------------------------
        'プロシージャ名  :s_GC_Dispose
        '説明            :メモリの解放
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Sub s_GC_Dispose()

            Try
                ' ガベージコレクションを実行します。
                System.GC.Collect()
                ' ファイナライゼーションが終わるまでスレッド待機します。
                System.GC.WaitForPendingFinalizers()

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
            End Try

        End Sub
#End Region

#Region "f_ReportPath_Check レポート出力用パス存在ﾁｪｯｸ"
        '------------------------------------------------------------------
        'プロシージャ名  :f_ReportPath_Check
        '説明            :レポート出力用パス存在ﾁｪｯｸ
        '引数            :1.OutKbn      Integer         出力拡張子区分(0:PDF,1:XLS)
        '                 2.strPath     String          出力パス
        '                 3.strFileName String          出力ファイル名
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_ReportPath_Check(ByRef strOutputPath As String, _
                                            ByVal OutKbn As Integer, _
                                            ByVal strPath As String, _
                                            ByVal strFileName As String) As Boolean


            Dim ret As Boolean = False
            Dim strEX As String = String.Empty

            Try
                '拡張子の設定
                If OutKbn = 0 Then
                    'PDF
                    strEX = ".pdf"
                Else
                    'Excel
                    strEX = ".xls"
                End If

                'ファイル名設定
                strFileName += Now.ToString("yyyyMMddHHmmss") & strEX

                'フォルダ存在ﾁｪｯｸ
                If Not f_DirectoryExist_Check(strPath) Then
                    Exit Try
                End If

                If strPath.TrimEnd.Length = 0 OrElse strFileName.TrimEnd.Length = 0 Then
                    Dim errPath As String = String.Empty
                    If strPath.TrimEnd.Length = 0 Then
                        errPath = strPath
                    Else
                        errPath = strFileName
                    End If
                    ' ファイル名が設定されていない場合、エラーメッセージ表示
                    'Call 'Show_MessageBox_Add("W009", " " & strPath & "の")          '@0出力先が存在しません。
                    'Call 'Show_MessageBox(strPath & "の出力先が存在しません。", C_MSGICON_WARNING)          '@0出力先が存在しません。
                    Exit Try
                End If


                If Microsoft.VisualBasic.Right(strPath, 1) = "\" Then
                    strOutputPath = strPath & strFileName
                Else
                    strOutputPath = strPath & "\" & strFileName
                End If


                '同名ファイル存在ﾁｪｯｸ
                If Not f_FileExist_Check(strOutputPath) Then
                    strOutputPath = ""
                    Exit Try
                End If

                ret = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
            End Try

            Return ret

        End Function


#End Region

#Region "f_DirectoryExist_Check フォルダ存在ﾁｪｯｸ"
        '------------------------------------------------------------------
        'プロシージャ名  :f_DirectoryExist_Check
        '説明            :フォルダ存在ﾁｪｯｸ
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_DirectoryExist_Check(ByVal strPath As String) As Boolean

            Dim ret As Boolean = False

            Try

                'フォルダの存在ﾁｪｯｸ
                If Microsoft.VisualBasic.Right(strPath, 1) = "\" Then
                    strPath = strPath.Substring(0, strPath.TrimEnd.Length - 1)
                End If

                If Not Directory.Exists(strPath) Then
                    'iniに設定されているフォルダが存在しない場合、エラーメッセージ表示
                    'Call 'Show_MessageBox_Add("W009", " " & strPath & "の")          '@0出力先が存在しません。
                    'Call 'Show_MessageBox(strPath & "の出力先が存在しません。", C_MSGICON_WARNING)          '@0出力先が存在しません。
                    Exit Try
                End If

                ret = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
            End Try

            Return ret

        End Function


#End Region

#Region "f_FileExist_Check 同名ファイル存在ﾁｪｯｸ"
        '------------------------------------------------------------------
        'プロシージャ名  :f_FileExist_Check
        '説明            :同名ファイル存在ﾁｪｯｸ
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_FileExist_Check(ByVal strOutputPath As String) As Boolean

            Dim ret As Boolean = False

            Try

                '同名ファイル存在ﾁｪｯｸ
                If File.Exists(strOutputPath) Then
                    ' ファイルが既に存在する場合、上書きするかどうか確認します。
                    'If 'Show_MessageBox("Q010", "") = DialogResult.No Then     '既にファイルが存在します。上書きしてもよろしいですか？
                    '    'If 'Show_MessageBox("既にファイルが存在します。上書きしてもよろしいですか？", C_MSGICON_QUESTION) = DialogResult.No Then     '既にファイルが存在します。上書きしてもよろしいですか？
                    '    Exit Try
                    'End If
                    ret = True
                Else
                    ret = False
                End If

                ret = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
            End Try

            Return ret

        End Function


#End Region

#Region "f_FileDialog ファイルダイアログの表示"
        '------------------------------------------------------------------
        'プロシージャ名  :f_FileDialog
        '説明            :ファイルダイアログの表示
        '引数　　　　　　:1. OutputMode    String  PDF出力の場合:"pdf" Excel出力の場合:"xls" CSV出力の場合:"csv"
        '　　　　　　　　:2. fileNm(ByRef) String  [参照時]帳票ID & 帳票名をセット [戻り]ファイル名を含むパス
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_FileDialog(ByVal OutputMode As String, ByRef fileNm As String) As Boolean

            ' OpenFileDialog の新しいインスタンスを生成する (デザイナから追加している場合は必要ない)
            'Dim OpenFileDialog1 As New SaveFileDialog

            'Try
            '    OpenFileDialog1.Title = "名前を付けて保存"

            '    Select Case OutputMode
            '        Case "pdf"
            '            'PDF出力

            '            '初期値を制御マスタ設定のパスにする。
            '            OpenFileDialog1.InitialDirectory = myREPORT_PDF_PATH
            '            'ファイルの種類を設定
            '            OpenFileDialog1.Filter = "PDFファイル(*.pdf)|*.pdf"

            '        Case "xls"
            '            'Excel出力

            '            '初期値を制御マスタ設定のパスにする。
            '            OpenFileDialog1.InitialDirectory = myREPORT_EXCEL_PATH
            '            'ファイルの種類を設定
            '            OpenFileDialog1.Filter = "Excel 97-2003 ブック(*.xls)|*.xls"


            '        Case "xlsx"         '2015/03/23 ADD Start
            '            'Excel出力
            '            '初期値を制御マスタ設定のパスにする。
            '            OpenFileDialog1.InitialDirectory = myREPORT_EXCEL_PATH
            '            'ファイルの種類を設定
            '            OpenFileDialog1.Filter = "Excel ブック(*.xlsx)|*.xlsx"
            '            '2015/03/23 ADD End

            '        Case "csv"
            '            'CSV出力

            '            '初期値を制御マスタ設定のパスにする。
            '            OpenFileDialog1.InitialDirectory = myREPORT_EXCEL_PATH
            '            'ファイルの種類を設定
            '            OpenFileDialog1.Filter = "CSVカンマ区切り(*.csv)|*.csv"


            '    End Select

            '    ' 初期表示するファイル名を設定する(帳票ID+帳票名+yyyyMMddHHmmss[+.pdf/.xls])
            '    OpenFileDialog1.FileName = fileNm & Now.ToString("yyyyMMddHHmmss")

            '    '' ダイアログボックスを閉じる前に現在のディレクトリを復元する (初期値 False)
            '    OpenFileDialog1.RestoreDirectory = True
            '    'ユーザーが既に存在するファイル名を指定した場合に [名前を付けて保存] ダイアログ ボックスで警告を表示するかどうかを示す値を取得または設定します。
            '    OpenFileDialog1.OverwritePrompt = True

            '    If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            '        fileNm = OpenFileDialog1.FileName
            '    Else
            '        fileNm = ""
            '        Return False
            '    End If

            '    Return True

            'Catch ex As Exception
            '    Throw New Exception(ex.Message)
            'Finally
            '    OpenFileDialog1.Dispose()
            'End Try
            Return True
        End Function
#End Region

#Region "f_GetDirectory レポート出力用ディレクトリー検索"
        '------------------------------------------------------------------
        'プロシージャ名  :f_GetDirectory
        '説明            :レポート出力用ディレクトリー検索
        '引数            :ikbn      処理区分(0:PDF出力 1:Excel出力)
        '                 newKENCD  県コード
        '　             　newPATH   ファイル作成場所のPath(ByRef)
        '               　blnPath   県コードフォルダが存在しない場合はFalse　存在する場合はTrue
        '戻り値          :Boolean(正常True/エラーFalse)
        '修正日          :2009/11/06
        '------------------------------------------------------------------
        Public Function f_GetDirectory(ByVal iKbn As Integer, ByVal newKENCD As Integer, ByRef newPATH As String, ByRef blnPath As Boolean) As Boolean
            Dim sSql As String = String.Empty
            Dim blnAnd As Boolean = False
            Dim strPath As String = String.Empty
            Dim ret As Boolean = False


            Try
                '引数.処理区分により取得するパスの内容を変更
                Select Case iKbn
                    Case 0
                        'PDF用パス取得
                        strPath = myREPORT_PDF_PATH
                    Case 1
                        'Excel用パス取得
                        strPath = myREPORT_EXCEL_PATH
                End Select

                If Microsoft.VisualBasic.Right(strPath, 1) = "\" Then
                    strPath = strPath.Substring(0, strPath.TrimEnd.Length - 1)
                End If


                '出力用パス存在チェック
                If Not f_DirectoryExist_Check(strPath) Then
                    blnPath = False
                    Exit Try
                Else
                    blnPath = True
                End If

                '都道府県用パス存在チェック
                Try
                    ' Only get subdirectories that begin with the letter "p."
                    Dim dirs As String() = Directory.GetDirectories(strPath, CStr(Format(newKENCD, "00")) & "*")
                    Dim dir As String
                    For Each dir In dirs
                        'ディレクトリーセット
                        newPATH = dir
                        '正常終了
                        ret = True
                        Exit For
                    Next

                Catch e As Exception
                    ret = False
                End Try

            Catch ex As Exception
                ret = False
            End Try

            Return ret
        End Function
#End Region

#Region "f_makeCSVByDT CSV文字列生成"
        ''' <summary>
        ''' CSV文字列生成
        ''' </summary>
        ''' <param name="wkDT"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function f_makeCSVByDT(ByVal wkDT As DataTable, ByVal wkFileName As String) As Boolean
            Dim wkSB As New System.Text.StringBuilder
            Dim wkLine As New List(Of String)
            Dim wkValue As Object
            'Dim wkFileName As String = ""

            '*** 2010/09/03 JBD UPD ***
            '修正部分　START
            If f_FileDialog("csv", wkFileName) = False Then
                Return False
            End If
            If wkFileName = "" Then
                Return False
            End If
            '修正部分　END
            '*** 2010/09/03 JBD UPD ***

            'ヘッダ
            For c As Integer = 0 To wkDT.Columns.Count - 1
                wkLine.Add(wkDT.Columns(c).ColumnName)
            Next
            wkSB.AppendLine(String.Join(",", wkLine.ToArray))


            For Each wkRow As DataRow In wkDT.Rows
                wkLine.Clear()
                For c As Integer = 0 To wkDT.Columns.Count - 1
                    wkValue = wkRow.Item(c)
                    Select Case True
                        Case wkValue Is Nothing, IsDBNull(wkValue)
                            'NULLの場合は空を代入。
                            wkLine.Add("")
                        Case TypeOf wkValue Is String
                            '文字列の場合はダブルクオートで囲む。
                            wkLine.Add("""" & wkValue.ToString & """")
                        Case TypeOf wkValue Is Date
                            '日付の場合はyyyy/MM/dd形式に
                            wkLine.Add(DirectCast(wkValue, Date).ToString("yyyy/MM/dd"))
                        Case Else
                            '数字などの場合はそのまま文字列に。
                            wkLine.Add(wkValue.ToString)
                    End Select

                Next

                wkSB.AppendLine(String.Join(",", wkLine.ToArray))

            Next

            Try
                'ファイルオープン
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
                Using wkSW = New IO.StreamWriter(wkFileName, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                    wkSW.Write(wkSB.ToString)
                End Using
                'Show_MessageBox("I501", "")     'CSV出力が終了しました。
            Catch ex As OracleException
                '共通例外処理
                'Show_MessageBox("", ex.Message)
                Return False
            End Try


            Return True
        End Function

        Public Function f_makeCSVByDT(ByVal wkDT As DataTable) As Boolean

            Return f_makeCSVByDT(wkDT, "")

        End Function
#End Region

#End Region

#Region "データ取得クラス"

#Region "事業対象年度"

        ''' <summary>
        ''' 事業対象年度
        ''' </summary>
        ''' <remarks></remarks>
        Public Class Obj_TM_SYORI_NENDO
            Property pSYORI_KBN As Integer
            Property pJIGYO_NENDO As Integer
            Property pTAISYO_NENDO As Integer
            'Property pTAISYO_SIHANKI As Integer
            Property pREG_DATE As Date
            Property pREG_ID As String
            Property pUP_DATE As Date
            Property pUP_ID As String
            Property pCOM_NAME As String

            Property pTAISYO_NENGETU_FROM As Integer
            Property pTAISYO_NENGETU_TO As Integer

            Property pTAISYO_HANBAI_NENGETU As Decimal

            Property pTAISYO_NENDO_byDate As Date = Nothing
            Property pJIGYO_NENDO_byDate As Date = Nothing


            ''' <summary>
            ''' データ取得
            ''' </summary>
            ''' <remarks></remarks>
            Sub New()
                Dim wkDS As New DataSet
                Dim wkSB As New System.Text.StringBuilder


                wkSB.AppendLine("select * ")
                wkSB.AppendLine("from  TM_SYORI_NENDO")
                wkSB.AppendLine("order by JIGYO_NENDO　desc") '一件しかデータがないのが前提だが、とりあえず最大の年度を取ってくる。

                f_Select_ODP(wkDS, wkSB.ToString)

                With wkDS
                    If .Tables(0).Rows.Count <> 0 Then
                        pSYORI_KBN = wkDS.Tables(0).Rows(0)("SYORI_KBN")
                        pJIGYO_NENDO = wkDS.Tables(0).Rows(0)("JIGYO_NENDO")
                        pTAISYO_NENDO = wkDS.Tables(0).Rows(0)("TAISYO_NENDO")
                        'pTAISYO_SIHANKI = wkDS.Tables(0).Rows(0)("TAISYO_SIHANKI")
                        pREG_DATE = wkDS.Tables(0).Rows(0)("REG_DATE")
                        'pREG_ID = wkDS.Tables(0).Rows(0)("REG_ID")
                        pREG_ID = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("REG_ID"))
                        pUP_DATE = wkDS.Tables(0).Rows(0)("UP_DATE")
                        'pUP_ID = wkDS.Tables(0).Rows(0)("UP_ID")
                        pUP_ID = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("UP_ID"))
                        pTAISYO_NENGETU_FROM = wkDS.Tables(0).Rows(0)("TAISYO_NENGETU_FROM")
                        pTAISYO_NENGETU_TO = wkDS.Tables(0).Rows(0)("TAISYO_NENGETU_TO")

                        pTAISYO_HANBAI_NENGETU = wkDS.Tables(0).Rows(0)("TAISYO_HANBAI_NENGETU")

                        Date.TryParse(wkDS.Tables(0).Rows(0)("JIGYO_NENDO") & "/04/01", pJIGYO_NENDO_byDate)
                        Date.TryParse(wkDS.Tables(0).Rows(0)("TAISYO_NENDO") & "/04/01", pTAISYO_NENDO_byDate)
                    End If
                End With
            End Sub

            ''' <summary>
            ''' データ取得(処理区分指定)
            ''' </summary>
            ''' <remarks></remarks>
            Sub New(ByVal wkSYORI_KBN)
                Dim wkDS As New DataSet
                Dim wkSB As New System.Text.StringBuilder

                wkSB.AppendLine("select * ")
                wkSB.AppendLine("from  TM_SYORI_NENDO")
                wkSB.AppendLine("where SYORI_KBN = '" & wkSYORI_KBN & "'")

                f_Select_ODP(wkDS, wkSB.ToString)

                With wkDS
                    If .Tables(0).Rows.Count <> 0 Then
                        pSYORI_KBN = wkDS.Tables(0).Rows(0)("SYORI_KBN")
                        pJIGYO_NENDO = wkDS.Tables(0).Rows(0)("JIGYO_NENDO")
                        pTAISYO_NENDO = wkDS.Tables(0).Rows(0)("TAISYO_NENDO")
                        'pTAISYO_SIHANKI = wkDS.Tables(0).Rows(0)("TAISYO_SIHANKI")
                        pREG_DATE = wkDS.Tables(0).Rows(0)("REG_DATE")
                        pREG_ID = wkDS.Tables(0).Rows(0)("REG_ID")
                        pUP_DATE = wkDS.Tables(0).Rows(0)("UP_DATE")
                        pUP_ID = wkDS.Tables(0).Rows(0)("UP_ID")

                        pTAISYO_NENGETU_FROM = wkDS.Tables(0).Rows(0)("TAISYO_NENGETU_FROM")
                        pTAISYO_NENGETU_TO = wkDS.Tables(0).Rows(0)("TAISYO_NENGETU_TO")

                        Date.TryParse(wkDS.Tables(0).Rows(0)("JIGYO_NENDO") & "/04/01", pJIGYO_NENDO_byDate)
                        Date.TryParse(wkDS.Tables(0).Rows(0)("TAISYO_NENDO") & "/04/01", pTAISYO_NENDO_byDate)
                    End If

                End With
            End Sub

        End Class
#End Region
#Region "コントロールマスタ"

        ''' <summary>
        ''' コントロールマスタ
        ''' </summary>
        ''' <remarks></remarks>
        Public Class Obj_TM_CONTROL
            Property pPDF_PATH As String
            Property pPASS_KIGEN As Integer
            Property pWAREKI_NEN As Integer
            Property pSEISANSYA_KIGO As String

            ''' <summary>
            ''' データ取得
            ''' </summary>
            ''' <remarks></remarks>
            Sub New()
                Dim wkDS As New DataSet
                Dim wkSB As New System.Text.StringBuilder


                wkSB.AppendLine("select * ")
                wkSB.AppendLine("from  TM_CONTROL")
                wkSB.AppendLine("order by PASS_KIGEN　desc") '一件しかデータがないのが前提だが、とりあえず最大の使用者マスタ　パスワード有効期限を取ってくる。

                f_Select_ODP(wkDS, wkSB.ToString)

                With wkDS
                    If .Tables(0).Rows.Count <> 0 Then
                        If wkDS.Tables(0).Rows(0)("PDF_PATH") Is DBNull.Value Then
                            pPDF_PATH = ""
                        Else
                            pPDF_PATH = wkDS.Tables(0).Rows(0)("PDF_PATH")
                        End If

                        pPASS_KIGEN = wkDS.Tables(0).Rows(0)("PASS_KIGEN")
                        pWAREKI_NEN = wkDS.Tables(0).Rows(0)("WAREKI_NEN")
                        pSEISANSYA_KIGO = wkDS.Tables(0).Rows(0)("SEISANSYA_KIGO")

                        'Date.TryParse(wkDS.Tables(0).Rows(0)("JIGYO_NENDO") & "/04/01", pJIGYO_NENDO_byDate)
                        'Date.TryParse(wkDS.Tables(0).Rows(0)("TAISYO_NENDO") & "/04/01", pTAISYO_NENDO_byDate)

                    End If
                End With
            End Sub

        End Class
#End Region
#Region "処理対象期・年度マスタ"
        ''' <summary>
        ''' 処理対象期・年度
        ''' </summary>
        ''' <remarks></remarks>
        Public Class Obj_TM_SYORI_NENDO_KI
            Property pKI As Integer
            Property pJIGYO_NENDO As Integer
            Property pJIGYO_SYURYO_NENDO As Integer

            Property pZENKI_TUMITATE_DATE As Date
            Property pZENKI_KOFU_DATE As Date
            Property pHENKAN_KEISAN_DATE As Date

            Property pHENKAN_NINZU As Integer
            Property pHENKAN_GOKEI As Long
            Property pHENKAN_RITU As Decimal

            Property pTAISYO_NENDO As Integer
            Property pNOFU_KIGEN As Date
            Property pHASSEI_KAISU As Integer
            Property pBIKO As Integer
            Property pREG_DATE As Date
            Property pREG_ID As String
            Property pUP_DATE As Date
            Property pUP_ID As String
            Property pCOM_NAME As String

            Property pTAISYO_NENGETU_FROM As Integer
            Property pTAISYO_NENGETU_TO As Integer

            Property pJIGYO_NENDO_byDate As Date = Nothing
            Property pJIGYO_SYURYO_NENDO_byDate As Date = Nothing
            Property pTAISYO_NENDO_byDate As Date = Nothing

            ''' <summary>
            ''' データ取得
            ''' </summary>
            ''' <remarks></remarks>
            Sub New()
                Dim wkDS As New DataSet
                Dim wkSB As New System.Text.StringBuilder

                wkSB.AppendLine("select * ")
                wkSB.AppendLine("from  TM_SYORI_KI")
                wkSB.AppendLine("order by KI　desc") '一件しかデータがないのが前提だが、とりあえず最大の期を取ってくる。

               Using db = New DaDbContext()
                   f_Select_ODP_New(db,wkDS, wkSB.ToString)
               End Using

                With wkDS
                    If .Tables(0).Rows.Count <> 0 Then
                        pKI = wkDS.Tables(0).Rows(0)("KI")
                        pJIGYO_NENDO = wkDS.Tables(0).Rows(0)("JIGYO_NENDO")
                        pJIGYO_SYURYO_NENDO = wkDS.Tables(0).Rows(0)("JIGYO_SYURYO_NENDO")

                        '2015/02/23 JBD368 UPD ↓↓↓
                        'pZENKI_TUMITATE_DATE = wkDS.Tables(0).Rows(0)("ZENKI_TUMITATE_DATE")
                        'pZENKI_KOFU_DATE = wkDS.Tables(0).Rows(0)("ZENKI_KOFU_DATE")
                        'pHENKAN_KEISAN_DATE = wkDS.Tables(0).Rows(0)("HENKAN_KEISAN_DATE")

                        'pHENKAN_NINZU = wkDS.Tables(0).Rows(0)("HENKAN_NINZU")
                        'pHENKAN_GOKEI = wkDS.Tables(0).Rows(0)("HENKAN_GOKEI")
                        'pHENKAN_RITU = wkDS.Tables(0).Rows(0)("HENKAN_RITU")
                        If Not (wkDS.Tables(0).Rows(0)("ZENKI_TUMITATE_DATE")) Is DBNull.Value Then
                            pZENKI_TUMITATE_DATE = wkDS.Tables(0).Rows(0)("ZENKI_TUMITATE_DATE")
                        Else
                            pZENKI_TUMITATE_DATE = Nothing
                        End If
                        If Not (wkDS.Tables(0).Rows(0)("ZENKI_KOFU_DATE")) Is DBNull.Value Then
                            pZENKI_KOFU_DATE = wkDS.Tables(0).Rows(0)("ZENKI_KOFU_DATE")
                        Else
                            pZENKI_KOFU_DATE = Nothing
                        End If
                        If Not (wkDS.Tables(0).Rows(0)("HENKAN_KEISAN_DATE")) Is DBNull.Value Then
                            pHENKAN_KEISAN_DATE = wkDS.Tables(0).Rows(0)("HENKAN_KEISAN_DATE")
                        Else
                            pHENKAN_KEISAN_DATE = Nothing
                        End If

                        If Not (wkDS.Tables(0).Rows(0)("HENKAN_NINZU")) Is DBNull.Value Then
                            pHENKAN_NINZU = wkDS.Tables(0).Rows(0)("HENKAN_NINZU")
                        End If
                        If Not (wkDS.Tables(0).Rows(0)("HENKAN_GOKEI")) Is DBNull.Value Then
                            pHENKAN_GOKEI = wkDS.Tables(0).Rows(0)("HENKAN_GOKEI")
                        End If
                        If Not (wkDS.Tables(0).Rows(0)("HENKAN_RITU")) Is DBNull.Value Then
                            pHENKAN_RITU = wkDS.Tables(0).Rows(0)("HENKAN_RITU")
                        End If
                        '2015/02/23 JBD368 UPD ↑↑↑
                        '2015/03/02 JBD368 UPD ↓↓↓
                        'pTAISYO_NENDO = wkDS.Tables(0).Rows(0)("TAISYO_NENDO")
                        'pNOFU_KIGEN = wkDS.Tables(0).Rows(0)("NOFU_KIGEN")
                        'pHASSEI_KAISU = wkDS.Tables(0).Rows(0)("HASSEI_KAISU")
                        If Not (wkDS.Tables(0).Rows(0)("TAISYO_NENDO")) Is DBNull.Value Then
                            pTAISYO_NENDO = wkDS.Tables(0).Rows(0)("TAISYO_NENDO")
                        End If
                        If Not (wkDS.Tables(0).Rows(0)("NOFU_KIGEN")) Is DBNull.Value Then
                            pNOFU_KIGEN = wkDS.Tables(0).Rows(0)("NOFU_KIGEN")
                        End If
                        If Not (wkDS.Tables(0).Rows(0)("HASSEI_KAISU")) Is DBNull.Value Then
                            pHASSEI_KAISU = wkDS.Tables(0).Rows(0)("HASSEI_KAISU")
                        End If
                        '2015/03/02 JBD368 UPD ↑↑↑

                        pREG_DATE = wkDS.Tables(0).Rows(0)("REG_DATE")
                        pREG_ID = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("REG_ID"))
                        pUP_DATE = wkDS.Tables(0).Rows(0)("UP_DATE")
                        pUP_ID = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("UP_ID"))

                        Date.TryParse(wkDS.Tables(0).Rows(0)("JIGYO_NENDO") & "/04/01", pJIGYO_NENDO_byDate)
                        Date.TryParse(CInt(wkDS.Tables(0).Rows(0)("JIGYO_SYURYO_NENDO")) + 1 & "/03/31", pJIGYO_SYURYO_NENDO_byDate)
                        Date.TryParse(wkDS.Tables(0).Rows(0)("TAISYO_NENDO") & "/04/01", pTAISYO_NENDO_byDate)

                    End If
                End With
            End Sub

        End Class

#End Region
#End Region

#Region "*** 成鶏更新 日付関連関数 ***"

        '------------------------------------------------------------------
        'プロシージャ名  :f_Saisou_Syukkabi_Get
        '説明            :引数で渡された基準日より最早出荷日を算出する
        '
        '引数            :1.dtStandard          Date     基準日
        '                 2.numTaisyoNendo      Integer  対象年度
        '
        '戻り値          :Date    算出した最早出荷日
        '------------------------------------------------------------------
        Public Function f_Saisou_Syukkabi_Get(ByVal dtStandard As Date, ByVal numTaisyoNendo As Integer) As Date
            Dim wkDS As New DataSet
            Dim wkSB As New System.Text.StringBuilder
            Dim dtWkYmd As Date

            '↓----- 2012/03/27 JBD200 UPDATE 仕様変更 -----↓
            'wkSB.AppendLine("select SEIKEI_SAISOU_SYUKKABI ")
            wkSB.AppendLine("select SEIKEI_SYUKKA_KIKAN ")
            '↑----- 2012/03/27 JBD200 UPDATE 仕様変更 -----↑
            wkSB.AppendLine("from  TM_GYOMU_YOKEN ")
            wkSB.AppendLine("where TAISYO_NENDO = " & numTaisyoNendo & "")

            f_Select_ODP(wkDS, wkSB.ToString)

            With wkDS
                If .Tables(0).Rows.Count <> 0 Then
                    '↓----- 2012/03/27 JBD200 UPDATE 仕様変更 -----↓
                    'dtWkYmd = dtStandard.AddDays(-1 * wkDS.Tables(0).Rows(0)("SEIKEI_SAISOU_SYUKKABI"))
                    dtWkYmd = dtStandard.AddDays(-1 * wkDS.Tables(0).Rows(0)("SEIKEI_SYUKKA_KIKAN"))
                    '↑----- 2012/03/27 JBD200 UPDATE 仕様変更 -----↑
                Else
                    dtWkYmd = dtStandard.AddDays(-30)
                End If

            End With

            Return dtWkYmd

        End Function

        Public Function f_Saisou_Syukkabi_Get(ByVal dtStandard As Date) As Date
            Dim wkDS As New DataSet
            Dim wkSB As New System.Text.StringBuilder
            Dim nYYYY As Integer

            wkSB.AppendLine("select TAISYO_NENDO ")
            wkSB.AppendLine("from  TM_SYORI_NENDO ")
            wkSB.AppendLine("where SYORI_KBN = 1")

            f_Select_ODP(wkDS, wkSB.ToString)

            With wkDS
                If .Tables(0).Rows.Count <> 0 Then
                    nYYYY = wkDS.Tables(0).Rows(0)("TAISYO_NENDO")
                Else
                    nYYYY = Now.Year
                End If

            End With

            Return f_Saisou_Syukkabi_Get(dtStandard, nYYYY)

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_Saichi_syukkabi_Get
        '説明            :引数で渡された事業終了日より最遅出荷日を算出する
        '
        '引数            :1.dtEnterpriseEnd     Date     事業終了日
        '
        '戻り値          :Date    算出した最遅出荷日
        '------------------------------------------------------------------
        Public Function f_Saichi_Syukkabi_Get(ByVal dtEnterpriseEnd As Date) As Date

            Return dtEnterpriseEnd.AddDays(-1)

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_KeikakuSinsei_Kigen_Get
        '説明            :引数で渡された最終出荷日より計画申請期限を算出する
        '
        '引数            :1.dtLatestShipdate    Date     最終出荷日
        '                 2.numTaisyoNendo      Integer  対象年度
        '
        '戻り値          :Date    算出した計画申請期限
        '------------------------------------------------------------------
        Public Function f_KeikakuSinsei_Kigen_Get(ByVal dtLatestShipdate As Date, ByVal numTaisyoNendo As Integer) As Date
            Dim wkDS As New DataSet
            Dim wkSB As New System.Text.StringBuilder
            Dim dtWkYmd As Date

            wkSB.AppendLine("select SEIKEI_KEIKAKU_SINSEI_KIGEN ")
            wkSB.AppendLine("from  TM_GYOMU_YOKEN ")
            wkSB.AppendLine("where TAISYO_NENDO = " & numTaisyoNendo & "")

            f_Select_ODP(wkDS, wkSB.ToString)

            With wkDS
                If .Tables(0).Rows.Count <> 0 Then
                    dtWkYmd = dtLatestShipdate.AddDays(wkDS.Tables(0).Rows(0)("SEIKEI_KEIKAKU_SINSEI_KIGEN"))
                Else
                    dtWkYmd = dtLatestShipdate.AddDays(30)
                End If

            End With

            Return dtWkYmd

        End Function

        Public Function f_KeikakuSinsei_Kigen_Get(ByVal dtLatestShipdate As Date) As Date
            Dim wkDS As New DataSet
            Dim wkSB As New System.Text.StringBuilder
            Dim nYYYY As Integer

            wkSB.AppendLine("select TAISYO_NENDO ")
            wkSB.AppendLine("from  TM_SYORI_NENDO ")
            wkSB.AppendLine("where SYORI_KBN = 1")

            f_Select_ODP(wkDS, wkSB.ToString)

            With wkDS
                If .Tables(0).Rows.Count <> 0 Then
                    nYYYY = wkDS.Tables(0).Rows(0)("TAISYO_NENDO")
                Else
                    nYYYY = Now.Year
                End If

            End With

            Return f_KeikakuSinsei_Kigen_Get(dtLatestShipdate, nYYYY)

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_Kusya_Kikan_Get
        '説明            :引数で渡された最終出荷日および導入日より空舎期間を算出する
        '
        '引数            :1.dtLatestShipdate    Date     最終出荷日
        '                 2.dtIntroductorydate  Date     導入日
        '
        '戻り値          :Long    算出した空舎期間
        '------------------------------------------------------------------
        Public Function f_Kusya_Kikan_Get(ByVal dtLatestShipdate As Date, ByVal dtIntroductorydate As Date) As Long
            Dim nKikan As Long

            '空舎期間 = 導入日 - 最終出荷日 - 1
            'nKikan = DateDiff(DateInterval.Day, dtIntroductorydate, dtLatestShipdate) - 1
            nKikan = DateDiff(DateInterval.Day, dtLatestShipdate, dtIntroductorydate) - 1

            If nKikan < 0 Then
                nKikan = 0
            End If

            Return nKikan

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_Donyu_Kikan_Get
        '説明            :引数で渡された最終出荷日および最終導入日より導入期間を算出する
        '
        '引数            :1.dtLatestShipdate    Date     最終出荷日
        '                 2.dtIntroductorydate  Date     最終導入日
        '
        '戻り値          :Long    算出した導入期間
        '------------------------------------------------------------------
        Public Function f_Donyu_Kikan_Get(ByVal dtLatestShipdate As Date, ByVal dtIntroductorydate As Date) As Long
            Dim nKikan As Long

            '空舎期間 = 導入日 - 最終出荷日 - 1
            'nKikan = DateDiff(DateInterval.Day, dtIntroductorydate, dtLatestShipdate)
            nKikan = DateDiff(DateInterval.Day, dtLatestShipdate, dtIntroductorydate)

            If nKikan < 0 Then
                nKikan = 0
            End If

            Return nKikan

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_JissekiHoukoku_Kigen_Get
        '説明            :引数で渡された最終導入日より実績報告期限を算出する
        '
        '引数            :1.dtIntroductorydate  Date     最終導入日
        '                 2.numTaisyoNendo      Integer  対象年度
        '
        '戻り値          :Date    算出した実績報告期限
        '------------------------------------------------------------------
        Public Function f_JissekiHoukoku_Kigen_Get(ByVal dtIntroductorydate As Date, ByVal numTaisyoNendo As Integer) As Date
            Dim wkDS As New DataSet
            Dim wkSB As New System.Text.StringBuilder
            Dim dtWkYmd As Date

            wkSB.AppendLine("select SEIKEI_JISSEKI_HOKOKU_KIGEN ")
            wkSB.AppendLine("from  TM_GYOMU_YOKEN ")
            wkSB.AppendLine("where TAISYO_NENDO = " & numTaisyoNendo & "")

            f_Select_ODP(wkDS, wkSB.ToString)

            With wkDS
                If .Tables(0).Rows.Count <> 0 Then
                    dtWkYmd = dtIntroductorydate.AddDays(wkDS.Tables(0).Rows(0)("SEIKEI_JISSEKI_HOKOKU_KIGEN"))
                Else
                    dtWkYmd = dtIntroductorydate.AddDays(30)
                End If
                '当日分の１日を減算 
                dtWkYmd = dtWkYmd.AddDays(-1)    '2012/04/19　追加
            End With

            Return dtWkYmd

        End Function

        Public Function f_JissekiHoukoku_Kigen_Get(ByVal dtIntroductorydate As Date) As Date
            Dim wkDS As New DataSet
            Dim wkSB As New System.Text.StringBuilder
            Dim nYYYY As Integer

            wkSB.AppendLine("select TAISYO_NENDO ")
            wkSB.AppendLine("from  TM_SYORI_NENDO ")
            wkSB.AppendLine("where SYORI_KBN = 1")

            f_Select_ODP(wkDS, wkSB.ToString)

            With wkDS
                If .Tables(0).Rows.Count <> 0 Then
                    nYYYY = wkDS.Tables(0).Rows(0)("TAISYO_NENDO")
                Else
                    nYYYY = Now.Year
                End If

            End With

            Return f_JissekiHoukoku_Kigen_Get(dtIntroductorydate, nYYYY)

        End Function


#End Region

#Region "*** 印影を取得 ***"
        '------------------------------------------------------------------
        'プロシージャ名  :f_inei_Get 2018/06/12 新規作成
        '説明            :印影を取得する
        '
        '戻り値          :bmp    印影
        '------------------------------------------------------------------
        'Public Function f_inei_Get() As Object

        '    Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        '    Dim bmp = New Bitmap(myAssembly.GetManifestResourceStream("JbdGjsCommon.inei.gif"))

        '    Return bmp

        'End Function
#End Region

#Region "*** 口座名義カナ可能文字チェック ***"
        '------------------------------------------------------------------
        'プロシージャ名  :f_chk_Zengin 2018/07/03 新規作成
        '説明            :口座名義カナ可能文字チェックする
        '
        '戻り値          :boolean
        '------------------------------------------------------------------
        Public Function f_chk_Zengin(ByVal str As String) As Boolean

            Dim charArray As Char() = New Char() {" "c, "ﾞ"c, "ﾟ"c, "("c, ")"c, "-"c, "."c, "0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c, "J"c, "K"c, "L"c, "M"c, "N"c, "O"c, "P"c, "Q"c, "R"c, "S"c, "T"c, "U"c, "V"c, "W"c, "X"c, "Y"c, "Z"c, "ｱ"c, "ｲ"c, "ｳ"c, "ｴ"c, "ｵ"c, "ｶ"c, "ｷ"c, "ｸ"c, "ｹ"c, "ｺ"c, "ｻ"c, "ｼ"c, "ｽ"c, "ｾ"c, "ｿ"c, "ﾀ"c, "ﾁ"c, "ﾂ"c, "ﾃ"c, "ﾄ"c, "ﾅ"c, "ﾆ"c, "ﾇ"c, "ﾈ"c, "ﾉ"c, "ﾊ"c, "ﾋ"c, "ﾌ"c, "ﾍ"c, "ﾎ"c, "ﾏ"c, "ﾐ"c, "ﾑ"c, "ﾒ"c, "ﾓ"c, "ﾔ"c, "ﾕ"c, "ﾖ"c, "ﾗ"c, "ﾘ"c, "ﾙ"c, "ﾚ"c, "ﾛ"c, "ﾜ"c, "ﾝ"c}
            Dim i As Integer
            Dim bool As Boolean

            For i = 0 To str.Length - 1
                bool = False
                For Each a As Char In charArray
                    If str(i) = a Then
                        bool = True
                    End If
                Next
                If bool = False Then
                    'MessageBox.Show("口座名義人(カナ)に使用できない文字が含まれています。" & vbCrLf & vbCrLf & _
                    '                "使用可能文字" & vbCrLf & _
                    '                "数字　　　　　0 1 2 3 4 5 6 7 8 9" & vbCrLf & _
                    '                "英字　　　　　A B C D E F G H I J K L M " & vbCrLf & _
                    '                "　　　　　　　N O P Q R S T U V W X Y Z" & vbCrLf & _
                    '                "カナ文字　　　ｱ ｲ ｳ ｴ ｵ ｶ ｷ ｸ ｹ ｺ ｻ ｼ ｽ ｾ ｿ ﾀ ﾁ ﾂ ﾃ ﾄ " & vbCrLf & _
                    '                "　　　　　　　ﾅ ﾆ ﾇ ﾈ ﾉ ﾊ ﾋ ﾌ ﾍ ﾎ ﾏ ﾐ ﾑ ﾒ ﾓ ﾔ ﾕ ﾖ ﾗ ﾘ ﾙ ﾚ ﾛ ﾜ ﾝ" & vbCrLf & _
                    '                "濁点・半濁点　ﾞ ﾟ" & vbCrLf & _
                    '                "記号　　　　　. ( ) - " & vbCrLf & _
                    '                "半角スペース", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            Next

            Return True

        End Function
#End Region

#Region "タイトル表示関連"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Title_Get
        '説明            :タイトル表題取得処理
        '引数            :なし
        '戻り値          :Boolean(正常True/エラーFalse)
        '                 外部共通変数:pAPPTITLEにタイトル表題文字列が入る
        '2021/02/16 JBD9020 新規作成
        '------------------------------------------------------------------
        Public Function f_All_Get() As String

            Dim sSql As String = String.Empty
            Dim dstDataSet As New DataSet
            Dim allget As String = String.Empty

            f_All_Get = ""

            Try

                sSql = ""
                sSql = sSql & "SELECT  "
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

                Call f_Select_ODP(dstDataSet, sSql)

                With dstDataSet.Tables(0)
                    If .Rows.Count > 0 Then
                        allget = "契約数: (新規 " & CLng(WordHenkan("N", "Z", .Rows(0)("CNT_SHINKI"))).ToString("##,###,##0") & " "
                        allget = allget & "継続 " & CLng(WordHenkan("N", "Z", .Rows(0)("CNT_KEI"))).ToString("##,###,##0") & ")" & vbCrLf & vbCrLf
                        allget = allget & "羽数: 　　" & CLng(WordHenkan("N", "Z", .Rows(0)("HASU"))).ToString("##,###,##0").PadLeft(14) & " 羽" & vbCrLf & vbCrLf
                        allget = allget & "積立金額: " & CLng(WordHenkan("N", "Z", .Rows(0)("TUMI"))).ToString("##,###,##0").PadLeft(14) & " 円"
                    Else
                        'レコードなし
                        allget = "契約数: (新規 0 "
                        allget = allget & "継続 0)" & vbCrLf & vbCrLf
                        allget = allget & "羽数: 　　なし" & vbCrLf & vbCrLf
                        allget = allget & "積立金額: なし"
                    End If
                End With

                f_All_Get = allget

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

        End Function
#End Region


    #Region "*** マスタデータ取得 ***"
    #Region "f_CodeMaster_Data_Select コードマスタデータ取得"
        '------------------------------------------------------------------
        'プロシージャ名  :f_CodeMaster_Data_Select
        '説明            :コードマスタより引数で渡されたデータ区分に該当する
        '                 コードと名称を取得し、コンボボックスにセットする
        '
        '引数            :1.cmbCd  String       コードコンボボックス
        '                 2.cmbMei String       名称コンボボックス
        '                 3.sDATA_KBN   String(Optional)        データ区分(4:口座種別データ 5:都道府県データ)
        '                 4.blnNullAddFlg   Boolean             スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '                 5.nRYAKU_KBN  Integer                 正式名称、略称区分  0:正式名称(既定)  1:略称
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_CodeMaster_Data_Select(ByRef cmbCd As String, _
                                                 ByRef cmbMei As String, _
                                                 ByVal nDATA_KBN As Integer, _
                                                 ByVal blnNullAddFlg As Boolean, _
                                                 ByVal nRYAKU_KBN As Integer) As Boolean

            Dim sSql As String = String.Empty
            Dim dstDataKen As New DataSet

            f_CodeMaster_Data_Select = False

            Try

                sSql = " SELECT " & vbCrLf
                sSql = sSql & "  MEISYO_CD," & vbCrLf
                If nRYAKU_KBN = 0 Then
                    sSql = sSql & "  MEISYO MEISYO" & vbCrLf
                Else
                    sSql = sSql & "  RYAKUSYO MEISYO" & vbCrLf
                End If
                sSql = sSql & " FROM" & vbCrLf
                sSql = sSql & "  TM_CODE" & vbCrLf
                'If nDATA_KBN <> "" Then
                sSql = sSql & " WHERE" & vbCrLf
                sSql = sSql & "  SYURUI_KBN = " & nDATA_KBN & "" & vbCrLf
                'End If
                sSql = sSql & " ORDER BY MEISYO_CD" & vbCrLf

                Call f_Select_ODP(dstDataKen, sSql)

                'cmbCd.Items.Clear()
                'cmbMei.Items.Clear()

                'With dstDataKen.Tables(0)
                '    If .Rows.Count > 0 Then
                '        For i As Integer = 0 To .Rows.Count - 1
                '            cmbCd.Items.Add(WordHenkan("N", "S", .Rows(i)("MEISYO_CD")))
                '            cmbMei.Items.Add(WordHenkan("N", "S", .Rows(i)("MEISYO")))
                '        Next

                '        '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                '        If blnNullAddFlg Then
                '            'コンボ空白項目追加
                '            cmbCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                '    Else
                '        'エラーリスト出力なし
                '        'Show_MessageBox("I002", "") '該当データが存在しません。
                '    End If
                'End With

                f_CodeMaster_Data_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

        End Function
        Public Function f_CodeMaster_Data_Select(ByRef cmbCd As String, _
                                             ByRef cmbMei As String, _
                                             ByVal nDATA_KBN As Integer, _
                                             ByVal blnNullAddFlg As Boolean) As Boolean
            If Not f_CodeMaster_Data_Select(cmbCd, cmbMei, nDATA_KBN, blnNullAddFlg, 0) Then
                Return False
            End If

            Return True
        End Function
        Public Function f_CodeMaster_Data_Select(ByRef cmbCd As String, _
                                             ByRef cmbMei As String, _
                                             ByVal nDATA_KBN As Integer) As Boolean
            If Not f_CodeMaster_Data_Select(cmbCd, cmbMei, nDATA_KBN, False, 0) Then
                Return False
            End If

            Return True
        End Function

    #End Region
    #Region "f_Ken_Data_Select 県データ取得"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Ken_Data_Select
        '説明            :県データ取得
        '引数            :1.cmbKenCd        String      県コードコンボボックス
        '                 2.cmbKenMei       String      県名コンボボックス
        '                 3.blnNullAddFlg   Boolean                     スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '                 4.sDATA_KBN       Integer(Optional)           データ区分(Default:5　←県データ)
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Ken_Data_Select(ByRef cmbKenCd As String, _
                                          ByRef cmbKenMei As String, _
                                          ByRef blnNullAddFlg As Boolean, _
                                          ByVal nDATA_KBN As Integer) As Boolean

            Dim sSql As String = String.Empty
            Dim dstDataKenCd As New DataSet
            Dim dstDataKenNm As New DataSet
            'Dim subItem1 As New GrapeCity.Win.Editors.SubItem()
            'Dim subItem2 As New GrapeCity.Win.Editors.SubItem()

            f_Ken_Data_Select = False

            Try

                sSql = " SELECT " & vbCrLf
                sSql = sSql & "  MEISYO_CD," & vbCrLf
                '2015/01/21 JBD368 UPD ↓↓↓ 都道府県名は正式名称を使用する
                'sSql = sSql & "  RYAKUSYO" & vbCrLf
                sSql = sSql & "  MEISYO" & vbCrLf
                '2015/01/21 JBD368 UPD ↑↑↑
                sSql = sSql & " FROM" & vbCrLf
                sSql = sSql & "  TM_CODE" & vbCrLf
                'If nDATA_KBN <> "" Then
                sSql = sSql & " WHERE" & vbCrLf
                sSql = sSql & "  SYURUI_KBN = " & nDATA_KBN & "" & vbCrLf
                'End If
                sSql = sSql & " ORDER BY MEISYO_CD" & vbCrLf

                Call f_Select_ODP(dstDataKenCd, sSql)

                'cmbKenCd.Items.Clear()
                'cmbKenMei.Items.Clear()

                'With dstDataKenCd.Tables(0)
                '    If .Rows.Count > 0 Then

                '        'cmbKenCd.AutoGenerateColumns = True
                '        'cmbKenCd.DataSource = dstDataKenCd
                '        'cmbKenCd.DataMember = "MEISYO_CD"

                '        'cmbKenMei.ListColumns.Add(New GrapeCity.Win.Editors.ListColumn("MEISYO_CD"))
                '        'cmbKenMei.ListColumns.Add(New GrapeCity.Win.Editors.ListColumn("RYAKUSYO"))

                '        For i As Integer = 0 To .Rows.Count - 1
                '            cmbKenCd.Items.Add(WordHenkan("N", "S", .Rows(i)("MEISYO_CD")))
                '            '2015/01/21 JBD368 UPD ↓↓↓ 都道府県名は正式名称を使用する
                '            'cmbKenMei.Items.Add(WordHenkan("N", "S", .Rows(i)("RYAKUSYO")))
                '            cmbKenMei.Items.Add(WordHenkan("N", "S", .Rows(i)("MEISYO")))
                '            '2015/02/21 JBD368 UPD ↑↑↑

                '            'subItem1.Value = WordHenkan("N", "S", .Rows(i)("MEISYO_CD"))
                '            'subItem2.Value = WordHenkan("N", "S", .Rows(i)("RYAKUSYO"))
                '            'cmbKenMei.Items.AddRange(New GrapeCity.Win.Editors.ListItem(New GrapeCity.Win.Editors.SubItem() {subItem1, subItem2}))

                '            'cmbKenMei.Items.Add("")
                '            'cmbKenMei.ListColumns.Item(0).DataPropertyName = WordHenkan("N", "S", .Rows(i)("MEISYO_CD"))
                '            'cmbKenMei.ListColumns.Item(1).DataPropertyName = WordHenkan("N", "S", .Rows(i)("RYAKUSYO"))

                '        Next

                '        '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                '        If blnNullAddFlg Then
                '            '県マスタコンボ空白項目追加
                '            cmbKenCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbKenMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                '    Else
                '        'エラーリスト出力なし
                '        'Show_MessageBox("I002", "") '該当データが存在しません。
                '        ''Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION) '該当データが存在しません。
                '    End If
                'End With


                f_Ken_Data_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

        End Function
        Public Function f_Ken_Data_Select(ByRef cmbKenCd As String, _
                                      ByRef cmbKenMei As String, _
                                      ByRef blnNullAddFlg As Boolean) As Boolean
            If Not f_Ken_Data_Select(cmbKenCd, cmbKenMei, blnNullAddFlg, 5) Then
                Return False
            End If

            Return True
        End Function
        Public Function f_Ken_Data_Select(ByRef cmbKenCd As String, _
                                      ByRef cmbKenMei As String) As Boolean
            If Not f_Ken_Data_Select(cmbKenCd, cmbKenMei, False, 5) Then
                Return False
            End If

            Return True
        End Function

    #End Region
    #Region "f_Itaku_Data_Select 代理人データ取得"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Itaku_Data_Select
        '説明            :代理人データ取得
        '引数            :1.cmbSankaCd  String     代理人コードコンボボックス
        '                 2.cmbSankaMei String     代理人名コンボボックス
        '                 3.blnNullAddFlg   Boolean                スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Itaku_Data_Select(ByRef cmbItakuCd As String, _
                                              ByRef cmbItakuMei As String, _
                                              ByVal blnNullAddFlg As Boolean) As Boolean

            Dim sSql As String = String.Empty
            Dim dstDataItaku As New DataSet

            f_Itaku_Data_Select = False

            Try

                sSql = " SELECT " & vbCrLf
                sSql = sSql & "  ITAKU_CD ," & vbCrLf
                sSql = sSql & "  ITAKU_NAME" & vbCrLf
                sSql = sSql & " FROM" & vbCrLf
                sSql = sSql & "  TM_ITAKU" & vbCrLf

                sSql = sSql & " ORDER BY ITAKU_CD" & vbCrLf

                Call f_Select_ODP(dstDataItaku, sSql)

                'cmbItakuCd.Items.Clear()
                'cmbItakuMei.Items.Clear()

                'With dstDataItaku.Tables(0)
                '    If .Rows.Count > 0 Then
                '        For i As Integer = 0 To .Rows.Count - 1
                '            cmbItakuCd.Items.Add(WordHenkan("N", "S", .Rows(i)("ITAKU_CD")))
                '            cmbItakuMei.Items.Add(WordHenkan("N", "S", .Rows(i)("ITAKU_NAME")))
                '        Next

                '        '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                '        If blnNullAddFlg Then
                '            'コンボ空白項目追加
                '            cmbItakuCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbItakuMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                '    End If
                'End With

                ''該当データあり(委託先使用可)
                'cmbItakuCd.Enabled = True
                'cmbItakuMei.Enabled = True

                f_Itaku_Data_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

        End Function
        Public Function f_Itaku_Data_Select(ByRef cmbItakuCd As String, _
                                              ByRef cmbItakuMei As String) As Boolean

            If Not f_Itaku_Data_Select(cmbItakuCd, cmbItakuMei, False) Then
                Return False
            End If

            Return True
        End Function

    #End Region
    #Region "f_Seisansya_Data_Select 生産者データ取得"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Seisansya_Data_Select
        '説明            :生産者データ取得
        '引数            :1.cmbSeisanCd     String   生産者コードコンボボックス
        '                 2.cmbSeisanMei    String   生産者名コンボボックス
        '                 3.strWhere        String                   生産者マスタ検索条件 WHERE句を指定する ""の場合、検索条件は次項目が優先される
        '                 4.nKensakuKbn     Inbteger                 生産者マスタの項目：生産単位区分に限定した検索条件 前項目のstrWHEREが指定されている場合、無視される
        '                                                             0:全ての生産単位区分
        '                                                             1:生産単位区分=1のもののみ
        '                                                             2:生産単位区分=2のもののみ
        '                                                             3:生産単位区分=3のもののみ
        '                                                            12:生産単位区分=1または生産単位区分=2のもの
        '                                                            13:生産単位区分=1または生産単位区分=3のもの
        '                                                            23:生産単位区分=2または生産単位区分=3のもの
        '                 5.blnNullAddFlg   Boolean                  スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Seisansya_Data_Select(ByRef cmbSeisanCd As String, _
                                                ByRef cmbSeisanMei As String, _
                                                ByVal strWhere As String, _
                                                ByVal nKensakuKbn As Integer, _
                                                ByVal blnNullAddFlg As Boolean) As Boolean

            Dim sSql As String = String.Empty
            Dim sWhere As String = String.Empty
            Dim dstDataSanka As New DataSet

            f_Seisansya_Data_Select = False

            Try

                sSql = "SELECT " & vbCrLf
                sSql = sSql & "  SEISANSYA_CD," & vbCrLf
                sSql = sSql & "  SEISANSYA_NAME" & vbCrLf
                sSql = sSql & " FROM" & vbCrLf
                sSql = sSql & "  TM_SEISANSYA" & vbCrLf

                '検索条件として県コードが指定された
                'If sKEN_CD <> "" Then
                '    sWhere = sWhere & "  KEN_CD = '" & sKEN_CD & "'" & vbCrLf
                'End If


                If strWhere <> "" Then
                    '第三引数が指定されている
                    sWhere = strWhere
                Else
                    Select Case nKensakuKbn
                        Case 1
                            sWhere = sWhere & "  SEISANTANI_KBN = 1" & vbCrLf
                        Case 2
                            sWhere = sWhere & "  SEISANTANI_KBN = 2" & vbCrLf
                        Case 3
                            sWhere = sWhere & "  SEISANTANI_KBN = 3" & vbCrLf
                        Case 12
                            sWhere = sWhere & "  SEISANTANI_KBN = 1 or SEISANTANI_KBN = 2" & vbCrLf
                        Case 13
                            sWhere = sWhere & "  SEISANTANI_KBN = 1 or SEISANTANI_KBN = 3" & vbCrLf
                        Case 23
                            sWhere = sWhere & "  SEISANTANI_KBN = 2 or SEISANTANI_KBN = 3" & vbCrLf
                    End Select
                End If


                If sWhere <> "" Then
                    sSql = sSql & " WHERE" & vbCrLf
                    sSql = sSql & sWhere
                End If
                sSql = sSql & " ORDER BY SEISANSYA_CD" & vbCrLf

                Call f_Select_ODP(dstDataSanka, sSql)

                'cmbSeisanCd.Items.Clear()
                'cmbSeisanMei.Items.Clear()

                'With dstDataSanka.Tables(0)
                '    If .Rows.Count > 0 Then
                '        For i As Integer = 0 To .Rows.Count - 1
                '            cmbSeisanCd.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_CD")))
                '            cmbSeisanMei.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_NAME")))
                '        Next

                '        '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                '        If blnNullAddFlg Then
                '            'コンボ空白項目追加
                '            cmbSeisanCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSeisanMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                '    End If
                'End With

                ''生産者コード使用可
                'cmbSeisanCd.Enabled = True
                'cmbSeisanMei.Enabled = True

                f_Seisansya_Data_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

        End Function
        Public Function f_Seisansya_Data_Select(ByRef cmbSeisanCd As String, _
                                                ByRef cmbSeisanMei As String, _
                                                ByVal strWhere As String, _
                                                ByVal nKensakuKbn As Integer) As Boolean
            If Not f_Seisansya_Data_Select(cmbSeisanCd, cmbSeisanMei, strWhere, nKensakuKbn, False) Then
                Return False
            End If
            Return True
        End Function
        Public Function f_Seisansya_Data_Select(ByRef cmbSeisanCd As String, _
                                                ByRef cmbSeisanMei As String, _
                                                ByVal strWhere As String) As Boolean
            If Not f_Seisansya_Data_Select(cmbSeisanCd, cmbSeisanMei, strWhere, 0, False) Then
                Return False
            End If
            Return True
        End Function
        Public Function f_Seisansya_Data_Select(ByRef cmbSeisanCd As String, _
                                                ByRef cmbSeisanMei As String) As Boolean
            If Not f_Seisansya_Data_Select(cmbSeisanCd, cmbSeisanMei, "", 0, False) Then
                Return False
            End If
            Return True
        End Function

    #End Region
    #Region "f_Itaku_Seisansya_Data_Select 代理人コードに紐付く生産者データ取得"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Itaku_Seisansya_Data_Select
        '説明            :生産者データ取得
        '引数            :1.cmbItakuCdFm   String     代理人コードコンボボックスFROM
        '                 2.cmbSeisanCdFm  String     生産者コードコンボボックスFROM
        '                 3.cmbSeisanMeiFm String     生産者名コンボボックスFROM
        '                 4.blnNullAddFlg   Boolean                   スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '                 5.cmbItakuCdTo   String     代理人コードコンボボックスTO
        '                 6.cmbSeisanCdTo  String     生産者コードコンボボックスTO
        '                 7.cmbSeisanMeiTo String     生産者名コンボボックスTO
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Itaku_Seisansya_Data_Select(ByRef cmbItakuCdFm As String, _
                                                ByRef cmbSeisanCdFm As String, _
                                                ByRef cmbSeisanMeiFm As String, _
                                                ByVal blnNullAddFlg As Boolean, _
                                                ByRef cmbItakuCdTo As String, _
                                                ByRef cmbSeisanCdTo As String, _
                                                ByRef cmbSeisanMeiTo As String) As Boolean

            Dim sSql As String = String.Empty
            Dim sWhere As String = String.Empty
            Dim dstDataSanka As New DataSet

            f_Itaku_Seisansya_Data_Select = False

            Try

                sSql = "SELECT " & vbCrLf
                sSql = sSql & "  SEISANSYA_CD," & vbCrLf
                sSql = sSql & "  SEISANSYA_NAME" & vbCrLf
                sSql = sSql & " FROM" & vbCrLf
                sSql = sSql & "  TM_SEISANSYA" & vbCrLf


                If cmbItakuCdTo Is Nothing Or cmbSeisanCdTo Is Nothing Or cmbSeisanMeiTo Is Nothing Then
                    '代理人コードToは未指定
                    If cmbItakuCdFm = "" Then
                        ' 代理人コードFROMは未指定
                        ' よって生産者は全件
                    Else
                        ' 代理人コードFROMは指定されている
                        ' よって生産者FROMは代理人コードFROMと一致するものが対象
                        sWhere = sWhere & "  ITAKU_CD = '" & cmbItakuCdFm & "'" & vbCrLf
                    End If
                Else
                    '代理人コードToは指定されている
                    If cmbItakuCdFm = "" Or cmbItakuCdTo = "" Then
                        ' 代理人コードFROMまたはTOは未指定
                        ' よって生産者FROMおよびTOは全件
                    Else
                        If cmbItakuCdFm <> cmbItakuCdTo Then
                            ' 代理人コードFROMとTOは同一でない
                            ' よって生産者FROMおよびTOは全件
                        Else
                            ' 代理人コードFROMとTOは同一である
                            ' よって生産者FROMおよびTOは代理人コードと一致するものが対象
                            sWhere = sWhere & "  ITAKU_CD = '" & cmbItakuCdFm & "'" & vbCrLf
                        End If
                    End If
                End If

                If sWhere <> "" Then
                    sSql = sSql & " WHERE" & vbCrLf
                    sSql = sSql & sWhere
                End If
                sSql = sSql & " ORDER BY SEISANSYA_CD" & vbCrLf

                Call f_Select_ODP(dstDataSanka, sSql)


                'cmbSeisanCdFm.Items.Clear()
                'cmbSeisanMeiFm.Items.Clear()
                'If cmbItakuCdTo Is Nothing Or cmbSeisanCdTo Is Nothing Or cmbSeisanMeiTo Is Nothing Then
                'Else
                '    cmbSeisanCdTo.Items.Clear()
                '    cmbSeisanMeiTo.Items.Clear()
                'End If

                'With dstDataSanka.Tables(0)
                '    If .Rows.Count > 0 Then
                '        For i As Integer = 0 To .Rows.Count - 1
                '            cmbSeisanCdFm.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_CD")))
                '            cmbSeisanMeiFm.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_NAME")))
                '            If cmbItakuCdTo Is Nothing Or cmbSeisanCdTo Is Nothing Or cmbSeisanMeiTo Is Nothing Then
                '            Else
                '                cmbSeisanCdTo.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_CD")))
                '                cmbSeisanMeiTo.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_NAME")))
                '            End If
                '        Next

                '        '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                '        If blnNullAddFlg Then
                '            'コンボ空白項目追加
                '            cmbSeisanCdFm.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSeisanMeiFm.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '            If cmbItakuCdTo Is Nothing Or cmbSeisanCdTo Is Nothing Or cmbSeisanMeiTo Is Nothing Then
                '            Else
                '                'コンボ空白項目追加
                '                cmbSeisanCdTo.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSeisanMeiTo.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '            End If
                '        End If
                '        '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                '    End If
                'End With

                ''生産者コード使用可
                'cmbSeisanCdFm.Enabled = True
                'cmbSeisanMeiFm.Enabled = True
                'If cmbItakuCdTo Is Nothing Or cmbSeisanCdTo Is Nothing Or cmbSeisanMeiTo Is Nothing Then
                'Else
                '    cmbSeisanCdTo.Enabled = True
                '    cmbSeisanMeiTo.Enabled = True
                'End If

                f_Itaku_Seisansya_Data_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

        End Function
        Public Function f_Itaku_Seisansya_Data_Select(ByRef cmbItakuCdFm As String, _
                                                ByRef cmbSeisanCdFm As String, _
                                                ByRef cmbSeisanMeiFm As String, _
                                                ByVal blnNullAddFlg As Boolean, _
                                                ByRef cmbItakuCdTo As String, _
                                                ByRef cmbSeisanCdTo As String) As Boolean

            If Not f_Itaku_Seisansya_Data_Select(cmbItakuCdFm, _
                                                 cmbSeisanCdFm, _
                                                 cmbSeisanMeiFm, _
                                                 blnNullAddFlg, _
                                                 cmbItakuCdTo, _
                                                 cmbSeisanCdTo,
                                                 Nothing) Then
                Return False
            End If
            Return True
        End Function
        Public Function f_Itaku_Seisansya_Data_Select(ByRef cmbItakuCdFm As String, _
                                                ByRef cmbSeisanCdFm As String, _
                                                ByRef cmbSeisanMeiFm As String, _
                                                ByVal blnNullAddFlg As Boolean, _
                                                ByRef cmbItakuCdTo As String) As Boolean

            If Not f_Itaku_Seisansya_Data_Select(cmbItakuCdFm, _
                                                 cmbSeisanCdFm, _
                                                 cmbSeisanMeiFm, _
                                                 blnNullAddFlg, _
                                                 cmbItakuCdTo, _
                                                 Nothing, Nothing) Then
                Return False
            End If
            Return True
        End Function
        Public Function f_Itaku_Seisansya_Data_Select(ByRef cmbItakuCdFm As String, _
                                                ByRef cmbSeisanCdFm As String, _
                                                ByRef cmbSeisanMeiFm As String, _
                                                ByVal blnNullAddFlg As Boolean) As Boolean

            If Not f_Itaku_Seisansya_Data_Select(cmbItakuCdFm, _
                                                 cmbSeisanCdFm, _
                                                 cmbSeisanMeiFm, _
                                                 blnNullAddFlg, _
                                                 Nothing, Nothing, Nothing) Then
                Return False
            End If
            Return True
        End Function
        Public Function f_Itaku_Seisansya_Data_Select(ByRef cmbItakuCdFm As String, _
                                                ByRef cmbSeisanCdFm As String, _
                                                ByRef cmbSeisanMeiFm As String) As Boolean

            If Not f_Itaku_Seisansya_Data_Select(cmbItakuCdFm, _
                                                 cmbSeisanCdFm, _
                                                 cmbSeisanMeiFm, _
                                                 False, _
                                                 Nothing, Nothing, Nothing) Then
                Return False
            End If
            Return True
        End Function

    #End Region
    #Region "f_Itaku_Data_Select 金融機関データ取得"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Itaku_Data_Select
        '説明            :金融機関データ取得
        '引数            :1.cmbBankCd  String       金融機関コードコンボボックス
        '                 2.cmbBankMei String       金融機関名コンボボックス
        '                 3.blnNullAddFlg   Boolean                 スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '                 4.sDATA_KBN   String(Optional)            データ区分(Default:"")
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Bank_Data_Select(ByRef cmbBankCd As String, _
                                           ByRef cmbBankMei As String, _
                                           ByVal blnNullAddFlg As Boolean, _
                                           ByVal sDATA_KBN As String) As Boolean

            Dim sSql As String = String.Empty
            Dim dstDataSet As New DataSet

            f_Bank_Data_Select = False

            Try

                sSql = " SELECT " & vbCrLf
                sSql = sSql & "  BANK_CD," & vbCrLf
                sSql = sSql & "  BANK_NAME" & vbCrLf
                sSql = sSql & " FROM" & vbCrLf
                sSql = sSql & "  TM_BANK" & vbCrLf
                'If sDATA_KBN <> "" Then
                '    sSql = sSql & " WHERE" & vbCrLf
                '    sSql = sSql & "  DATA_KBN = '" & sDATA_KBN & "'" & vbCrLf
                'End If
                sSql = sSql & " ORDER BY BANK_CD" & vbCrLf

                Call f_Select_ODP(dstDataSet, sSql)

                'cmbBankCd.Items.Clear()
                'cmbBankMei.Items.Clear()

                'With dstDataSet.Tables(0)
                '    If .Rows.Count > 0 Then

                '        For i As Integer = 0 To .Rows.Count - 1
                '            cmbBankCd.Items.Add(WordHenkan("N", "S", .Rows(i)("BANK_CD")))
                '            cmbBankMei.Items.Add(WordHenkan("N", "S", .Rows(i)("BANK_NAME")))
                '        Next

                '        '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                '        If blnNullAddFlg Then
                '            'コンボ空白項目追加
                '            cmbBankCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbBankMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                '    Else
                '        'エラーリスト出力なし
                '        'Show_MessageBox("I002", "") '該当データが存在しません。
                '        ''Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION)
                '    End If
                'End With

                f_Bank_Data_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            Finally
                dstDataSet.Dispose()
            End Try


        End Function
        Public Function f_Bank_Data_Select(ByRef cmbBankCd As String, _
                                           ByRef cmbBankMei As String, _
                                           ByVal blnNullAddFlg As Boolean) As Boolean

            If Not f_Bank_Data_Select(cmbBankCd,
                                      cmbBankMei,
                                      blnNullAddFlg,
                                      "") Then
                Return False
            End If
            Return True
        End Function
        Public Function f_Bank_Data_Select(ByRef cmbBankCd As String, _
                                           ByRef cmbBankMei As String) As Boolean

            If Not f_Bank_Data_Select(cmbBankCd,
                                      cmbBankMei,
                                      False,
                                      "") Then
                Return False
            End If
            Return True
        End Function

    #End Region
    #Region "f_BankShop_Data_Select 金融機関支店データ取得"
        '------------------------------------------------------------------
        'プロシージャ名  :f_BankShop_Data_Select
        '説明            :金融機関支店データ取得
        '引数            :1.cmbShopCd  String       金融機関支店コードコンボボックス
        '                 2.cmbShopMei String       金融機関支店名コンボボックス
        '                 3.sBankCD     String                      金融機関コード
        '                 4.blnNullAddFlg   Boolean                 スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '                 5.sDATA_KBN   String(Optional)            データ区分(Default:"")
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_BankShop_Data_Select(ByRef cmbShopCd As String, _
                                           ByRef cmbShopMei As String, _
                                           ByVal sBankCD As String, _
                                           ByVal blnNullAddFlg As Boolean, _
                                           ByVal sDATA_KBN As String) As Boolean

            Dim sSql As String = String.Empty
            Dim sWhere As String = String.Empty
            Dim dstDataSet As New DataSet

            f_BankShop_Data_Select = False

            Try

                sSql = " SELECT " & vbCrLf
                sSql = sSql & "  SITEN_CD," & vbCrLf
                sSql = sSql & "  SITEN_NAME" & vbCrLf
                sSql = sSql & " FROM" & vbCrLf
                sSql = sSql & "  TM_SITEN" & vbCrLf
                'If sDATA_KBN <> "" Then
                '    sWhere = sWhere & "  DATA_KBN = '" & sDATA_KBN & "'" & vbCrLf
                'End If
                If sBankCD <> "" Then
                    If sWhere <> "" Then
                        sWhere = sWhere & "  AND"
                    End If
                    sWhere = sWhere & " BANK_CD = '" & sBankCD & "'" & vbCrLf
                End If
                If sWhere <> "" Then
                    sSql = sSql & " WHERE" & vbCrLf
                    sSql = sSql & sWhere
                End If
                sSql = sSql & " ORDER BY BANK_CD, SITEN_CD" & vbCrLf

                Call f_Select_ODP(dstDataSet, sSql)

                'cmbShopCd.Items.Clear()
                'cmbShopMei.Items.Clear()

                'With dstDataSet.Tables(0)
                '    If .Rows.Count > 0 Then

                '        For i As Integer = 0 To .Rows.Count - 1
                '            cmbShopCd.Items.Add(WordHenkan("N", "S", .Rows(i)("SITEN_CD")))
                '            cmbShopMei.Items.Add(WordHenkan("N", "S", .Rows(i)("SITEN_NAME")))
                '        Next

                '        '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                '        If blnNullAddFlg Then
                '            'コンボ空白項目追加
                '            cmbShopCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbShopMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                '    End If
                'End With

                f_BankShop_Data_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            Finally
                dstDataSet.Dispose()
            End Try

        End Function
        Public Function f_BankShop_Data_Select(ByRef cmbShopCd As String, _
                                           ByRef cmbShopMei As String, _
                                           ByVal sBankCD As String, _
                                           ByVal blnNullAddFlg As Boolean) As Boolean

            If Not f_BankShop_Data_Select(cmbShopCd,
                                          cmbShopMei,
                                          sBankCD,
                                          blnNullAddFlg,
                                          "") Then
                Return False
            End If
            Return True
        End Function
        Public Function f_BankShop_Data_Select(ByRef cmbShopCd As String, _
                                           ByRef cmbShopMei As String, _
                                           ByVal sBankCD As String) As Boolean

            If Not f_BankShop_Data_Select(cmbShopCd,
                                          cmbShopMei,
                                          sBankCD,
                                          False,
                                          "") Then
                Return False
            End If
            Return True
        End Function

    #End Region
    #Region "f_Doitu_Seisansya_Data_Select 同一生産者グループデータ取得"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Doitu_Seisansya_Data_Select
        '説明            :同一生産者グループデータ取得
        '引数            :1.cmbDoituSeisansyaCd  String       同一生産者グループコードコンボボックス
        '                 2.cmbDoituSeisansyaMei String       同一生産者グループ名コンボボックス
        '                 3.blnNullAddFlg   Boolean                 スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Doitu_Seisansya_Data_Select(ByRef cmbDoituSeisansyaCd As String, _
                                           ByRef cmbDoituSeisansyaMei As String, _
                                           ByVal blnNullAddFlg As Boolean) As Boolean

            Dim sSql As String = String.Empty
            Dim dstDataSet As New DataSet

            f_Doitu_Seisansya_Data_Select = False

            Try

                sSql = " SELECT " & vbCrLf
                sSql = sSql & "  DOITU_SEISANSYA_CD," & vbCrLf
                sSql = sSql & "  DOITU_SEISANSYA_NAME" & vbCrLf
                sSql = sSql & " FROM" & vbCrLf
                sSql = sSql & "  TM_DOITU_SEISANSYA" & vbCrLf
                sSql = sSql & " ORDER BY DOITU_SEISANSYA_CD" & vbCrLf

                Call f_Select_ODP(dstDataSet, sSql)

                'cmbDoituSeisansyaCd.Items.Clear()
                'cmbDoituSeisansyaMei.Items.Clear()

                'With dstDataSet.Tables(0)
                '    If .Rows.Count > 0 Then

                '        For i As Integer = 0 To .Rows.Count - 1
                '            cmbDoituSeisansyaCd.Items.Add(WordHenkan("N", "S", .Rows(i)("DOITU_SEISANSYA_CD")))
                '            cmbDoituSeisansyaMei.Items.Add(WordHenkan("N", "S", .Rows(i)("DOITU_SEISANSYA_NAME")))
                '        Next

                '        '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                '        If blnNullAddFlg Then
                '            'コンボ空白項目追加
                '            cmbDoituSeisansyaCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbDoituSeisansyaMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                '    Else
                '        'エラーリスト出力なし
                '        ''Show_MessageBox("I002", "") '該当データが存在しません。
                '        ''Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION)
                '    End If
                'End With

                f_Doitu_Seisansya_Data_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            Finally
                dstDataSet.Dispose()
            End Try

        End Function

        Public Function f_Doitu_Seisansya_Data_Select(ByRef cmbDoituSeisansyaCd As String, _
                                           ByRef cmbDoituSeisansyaMei As String) As Boolean

            If Not f_Doitu_Seisansya_Data_Select(cmbDoituSeisansyaCd,
                                      cmbDoituSeisansyaMei,
                                      False) Then
                Return False
            End If
            Return True
        End Function

    #End Region
    #Region "f_Syokcyo_Data_Select 食鳥処理場データ取得"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Syokcyo_Data_Select
        '説明            :食鳥処理場データ取得
        '引数            :1.cmbSyokucyoCd  String       食鳥処理場コードコンボボックス
        '                 2.cmbSyokucyoMei String       食鳥処理場名コンボボックス
        '                 3.blnNullAddFlg   Boolean                 スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Syokcyo_Data_Select(ByRef cmbSyokucyoCd As String, _
                                                      ByRef cmbSyokucyoMei As String, _
                                                      ByVal blnNullAddFlg As Boolean) As Boolean

            Dim sSql As String = String.Empty
            Dim dstDataSet As New DataSet

            f_Syokcyo_Data_Select = False

            Try

                sSql = " SELECT " & vbCrLf
                sSql = sSql & "  SYOKUCYO_CD," & vbCrLf
                sSql = sSql & "  SYOKUCYO_NAME" & vbCrLf
                sSql = sSql & " FROM" & vbCrLf
                sSql = sSql & "  TM_SYOKUCYO" & vbCrLf
                sSql = sSql & " ORDER BY SYOKUCYO_CD" & vbCrLf

                Call f_Select_ODP(dstDataSet, sSql)

                'cmbSyokucyoCd.Items.Clear()
                'cmbSyokucyoMei.Items.Clear()

                'With dstDataSet.Tables(0)
                '    If .Rows.Count > 0 Then

                '        For i As Integer = 0 To .Rows.Count - 1
                '            cmbSyokucyoCd.Items.Add(WordHenkan("N", "S", .Rows(i)("SYOKUCYO_CD")))
                '            cmbSyokucyoMei.Items.Add(WordHenkan("N", "S", .Rows(i)("SYOKUCYO_NAME")))
                '        Next

                '        '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                '        If blnNullAddFlg Then
                '            'コンボ空白項目追加
                '            cmbSyokucyoCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSyokucyoMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                '    Else
                '        'エラーリスト出力なし
                '        ''Show_MessageBox("I002", "") '該当データが存在しません。
                '        ''Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION)
                '    End If
                'End With

                f_Syokcyo_Data_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            Finally
                dstDataSet.Dispose()
            End Try

        End Function

        Public Function f_Syokcyo_Data_Select(ByRef cmbSyokucyoCd As String, _
                                           ByRef cmbSyokucyoMei As String) As Boolean

            If Not f_Syokcyo_Data_Select(cmbSyokucyoCd,
                                      cmbSyokucyoMei,
                                      False) Then
                Return False
            End If
            Return True
        End Function

    #End Region
    #Region "f_User_Data_Select 担当者データ取得"
        '------------------------------------------------------------------
        'プロシージャ名  :f_User_Data_Select
        '説明            :担当者データ取得
        '引数            :1.cmbUserCd  String       担当者コードコンボボックス
        '                 2.cmbUserMei String       担当者名コンボボックス
        '                 3.blnNullAddFlg   Boolean                 スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_User_Data_Select(ByRef cmbUserCd As String, _
                                                      ByRef cmbUserMei As String, _
                                                      ByVal blnNullAddFlg As Boolean) As Boolean

            Dim sSql As String = String.Empty
            Dim dstDataSet As New DataSet

            f_User_Data_Select = False

            Try

                sSql = " SELECT " & vbCrLf
                sSql = sSql & "  USER_ID," & vbCrLf
                sSql = sSql & "  USER_NAME" & vbCrLf
                sSql = sSql & " FROM" & vbCrLf
                sSql = sSql & "  TM_USER" & vbCrLf
                sSql = sSql & " ORDER BY USER_ID" & vbCrLf

                Call f_Select_ODP(dstDataSet, sSql)

                'cmbUserCd.Items.Clear()
                'cmbUserMei.Items.Clear()

                'With dstDataSet.Tables(0)
                '    If .Rows.Count > 0 Then

                '        For i As Integer = 0 To .Rows.Count - 1
                '            cmbUserCd.Items.Add(WordHenkan("N", "S", .Rows(i)("USER_ID")))
                '            cmbUserMei.Items.Add(WordHenkan("N", "S", .Rows(i)("USER_NAME")))
                '        Next

                '        '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                '        If blnNullAddFlg Then
                '            'コンボ空白項目追加
                '            cmbUserCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbUserMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                '    Else
                '        'エラーリスト出力なし
                '        ''Show_MessageBox("I002", "") '該当データが存在しません。
                '        ''Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION)
                '    End If
                'End With

                f_User_Data_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            Finally
                dstDataSet.Dispose()
            End Try

        End Function

        Public Function f_User_Data_Select(ByRef cmbUserCd As String, _
                                           ByRef cmbUserMei As String) As Boolean

            If Not f_User_Data_Select(cmbUserCd,
                                      cmbUserMei,
                                      False) Then
                Return False
            End If
            Return True
        End Function

    #End Region
    #Region "f_Keiyaku_Data_Select 契約者データ取得(防疫互助)"
        '------------------------------------------------------------------
        'プロシージャ名  :f_Keiyaku_Data_Select
        '説明            :契約者データ取得
        '引数            :1.cmbKeiyakuCd     String   契約者コードコンボボックス
        '                 2.cmbKeiyakuMei    String   契約者名コンボボックス
        '                 3.strWhere        String                    契約者マスタ検索条件 WHERE句を指定する
        '                 4.blnNullAddFlg   Boolean                   スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '                 5.blnEnable       Boolean                   コンボの入力可否(TRUE:入力可能 FALSE:入力不可)
        '                 6.strUser       Boolean                   　他スキーマのデータが必要な時、スキーマをセット(""のとき、自スキーマ)   '2017/07/07追加
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As String, _
                                              ByRef cmbKeiyakuMei As String, _
                                              ByVal strWhere As String, _
                                              ByVal blnNullAddFlg As Boolean, _
                                              ByVal blnEnable As Boolean, _
                                              ByVal strUser As String) As Boolean

            '2015/03/03 JBD368 UPD ↓↓↓
            'Dim sSql As String = String.Empty
            'Dim dstDataSanka As New DataSet

            'f_Keiyaku_Data_Select = False

            'Try

            '    sSql = "SELECT "
            '    sSql = sSql & "  KEIYAKUSYA_CD,"
            '    sSql = sSql & "  KEIYAKUSYA_NAME"
            '    sSql = sSql & " FROM"
            '    sSql = sSql & "  TM_KEIYAKU"

            '    If strWhere <> "" Then
            '        sSql = sSql & " WHERE"
            '        sSql = sSql & " " & strWhere
            '    End If

            '    sSql = sSql & " ORDER BY KEIYAKUSYA_CD"

            '    Call f_Select_ODP(dstDataSanka, sSql)

            '    cmbKeiyakuCd.Items.Clear()
            '    cmbKeiyakuMei.Items.Clear()

            '    With dstDataSanka.Tables(0)
            '        If .Rows.Count > 0 Then
            '            For i As Integer = 0 To .Rows.Count - 1
            '                cmbKeiyakuCd.Items.Add(WordHenkan("N", "S", .Rows(i)("KEIYAKUSYA_CD")))
            '                cmbKeiyakuMei.Items.Add(WordHenkan("N", "S", .Rows(i)("KEIYAKUSYA_NAME")))
            '            Next

            '            '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
            '            If blnNullAddFlg Then
            '                'コンボ空白項目追加
            '                cmbKeiyakuCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbKeiyakuMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
            '            End If
            '            '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

            '        End If
            '    End With

            '    '契約者コード使用可
            '    cmbKeiyakuCd.Enabled = blnEnable
            '    cmbKeiyakuMei.Enabled = blnEnable

            '    f_Keiyaku_Data_Select = True

            'Catch ex As Exception
            '    '共通例外処理
            '    'Show_MessageBox("", ex.Message)
            'End Try


            Dim sSql As String = String.Empty
            Dim sSqlWhere As String = String.Empty  '2015/04/02 JBD368 ADD
            Dim dstDataSanka As New DataSet

            f_Keiyaku_Data_Select = False

            Try

                sSql = ""
                If blnNullAddFlg Then   '第3引数=Trueの時、空白項目を追加
                    'コンボ空白項目追加
                    sSql = "SELECT "
                    sSql = sSql & "NULL AS KEIYAKUSYA_CD, NULL AS KEIYAKUSYA_NAME "
                    sSql = sSql & "FROM DUAL "
                    sSql = sSql & "UNION ALL "
                End If
                sSql = sSql & "SELECT "
                sSql = sSql & "  KEIYAKUSYA_CD,"
                sSql = sSql & "  KEIYAKUSYA_NAME"
                sSql = sSql & " FROM"
                If strUser = "" Then
                    sSql = sSql & "  TM_KEIYAKU"
                Else
                    sSql = sSql & "  " & strUser & ".TM_KEIYAKU"
                End If

                '↓2015/04/02 JBD368 UPD
                'If strWhere <> "" Then
                '    sSql = sSql & " WHERE"
                '    sSql = sSql & " " & strWhere
                'End If
                sSqlWhere = ""
                sSqlWhere = sSqlWhere & " WHERE"
                '契約区分がNULLのデータは未参加の契約者とみなし、コンボボックスには追加しない。
                sSqlWhere = sSqlWhere & "   KEIYAKU_KBN IS NOT NULL"

                If strWhere <> "" Then
                    sSqlWhere = sSqlWhere & " AND " & strWhere
                End If
                sSql = sSql & sSqlWhere
                '↑2015/04/02 JBD368 UPD

                If blnNullAddFlg Then   '第3引数=Trueの時、空白項目を追加のため空白を先頭にする
                    sSql = sSql & " ORDER BY KEIYAKUSYA_CD NULLS FIRST"
                Else
                    sSql = sSql & " ORDER BY KEIYAKUSYA_CD"
                End If

                Call f_Select_ODP(dstDataSanka, sSql)

                'cmbKeiyakuCd.Clear()
                'cmbKeiyakuMei.Clear()

                'With dstDataSanka.Tables(0)
                '    If .Rows.Count > 0 Then

                '        'コンボボックスにデータをバインド
                '        cmbKeiyakuCd.DataSource = dstDataSanka.Tables(0)
                '        '不要なカラムを削除する
                '        cmbKeiyakuCd.ListColumns.RemoveAt(1)

                '        'コンボボックスにデータをバインド
                '        cmbKeiyakuMei.DataSource = dstDataSanka.Tables(0)
                '        '不要なカラムを削除する
                '        cmbKeiyakuMei.ListColumns.RemoveAt(0)
                '        '名称のコンボボックスの幅を設定
                '        cmbKeiyakuMei.ListColumns(0).Width = cmbKeiyakuMei.Width

                '    End If
                'End With

                ''契約者コード使用可
                'cmbKeiyakuCd.Enabled = blnEnable
                'cmbKeiyakuMei.Enabled = blnEnable

                f_Keiyaku_Data_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

        End Function

        Public Function f_Keiyaku_Data_Select_New(ki As Integer, blnNullAddFlg As Boolean, strUser As String) As DataTable
            Dim sSql As String = String.Empty
            Dim sSqlWhere As String = String.Empty  '2015/04/02 JBD368 ADD
            Dim dstDataSanka As New DataSet
            sSql = ""
            'If blnNullAddFlg Then   '第3引数=Trueの時、空白項目を追加
            '    'コンボ空白項目追加
            '    sSql = "SELECT "
            '    sSql = sSql & "NULL AS KEIYAKUSYA_CD, NULL AS KEIYAKUSYA_NAME "
            '    sSql = sSql & "FROM DUAL "
            '    sSql = sSql & "UNION ALL "
            'End If
            sSql = sSql & "SELECT "
            sSql = sSql & "  KEIYAKUSYA_CD,"
            sSql = sSql & "  KEIYAKUSYA_NAME"
            sSql = sSql & " FROM"
            If strUser = "" Then
                sSql = sSql & "  TM_KEIYAKU"
            Else
                sSql = sSql & "  " & strUser & ".TM_KEIYAKU"
            End If

            sSqlWhere = ""
            sSqlWhere = sSqlWhere & " WHERE"
            '契約区分がNULLのデータは未参加の契約者とみなし、コンボボックスには追加しない。
            sSqlWhere = sSqlWhere & "   KEIYAKU_KBN IS NOT NULL"

            If ki.ToString() <> "" Then
                sSqlWhere = sSqlWhere & " AND " & "KI = " & ki.ToString()
            End If
            sSql = sSql & sSqlWhere
            '↑2015/04/02 JBD368 UPD

            If blnNullAddFlg Then   '第3引数=Trueの時、空白項目を追加のため空白を先頭にする
                sSql = sSql & " ORDER BY KEIYAKUSYA_CD NULLS FIRST"
            Else
                sSql = sSql & " ORDER BY KEIYAKUSYA_CD"
            End If

            Using db = New DaDbContext()
                f_Select_ODP_New(db,dstDataSanka, sSql)
            End Using
            Dim dt = dstDataSanka.Tables(0)
            Return dt
        End Function


        '------------------------------------------------------------------
        'プロシージャ名  :f_Keiyaku_Data_Select
        '説明            :契約者データ取得
        '引数            :1.cmbKeiyakuCd     String   契約者コードコンボボックス
        '                 2.cmbKeiyakuMei    String   契約者名コンボボックス
        '                 3.strWhere        String                    契約者マスタ検索条件 WHERE句を指定する
        '                 4.blnNullAddFlg   Boolean                   スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '                 5.blnEnable       Boolean                   コンボの入力可否(TRUE:入力可能 FALSE:入力不可)
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As String, _
                                              ByRef cmbKeiyakuMei As String, _
                                              ByVal strWhere As String, _
                                              ByVal blnNullAddFlg As Boolean, _
                                              ByVal blnEnable As Boolean) As Boolean

            If Not f_Keiyaku_Data_Select(cmbKeiyakuCd, cmbKeiyakuMei, strWhere, blnNullAddFlg, blnEnable, "") Then
                Return False
            End If

            Return True

        End Function


        '------------------------------------------------------------------
        'プロシージャ名  :f_Keiyaku_Data_Select
        '説明            :契約者データ取得
        '引数            :1.cmbKeiyakuCd     String   契約者コードコンボボックス
        '                 2.cmbKeiyakuMei    String   契約者名コンボボックス
        '                 3.strWhere        String                    契約者マスタ検索条件 WHERE句を指定する
        '                 4.blnNullAddFlg   Boolean                   スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As String, _
                                                    ByRef cmbKeiyakuMei As String, _
                                                    ByVal strWhere As String, _
                                                    ByVal blnNullAddFlg As Boolean) As Boolean

            If Not f_Keiyaku_Data_Select(cmbKeiyakuCd, cmbKeiyakuMei, strWhere, blnNullAddFlg, True) Then
                Return False
            End If

            Return True

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_Keiyaku_Data_Select
        '説明            :契約者データ取得
        '引数            :1.cmbKeiyakuCd     String   契約者コードコンボボックス
        '                 2.cmbKeiyakuMei    String   契約者名コンボボックス
        '                 3.strWhere        String                    契約者マスタ検索条件 WHERE句を指定する
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As String, _
                                                    ByRef cmbKeiyakuMei As String, _
                                                    ByVal strWhere As String) As Boolean

            If Not f_Keiyaku_Data_Select(cmbKeiyakuCd, cmbKeiyakuMei, strWhere, False, True) Then
                Return False
            End If

            Return True

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_Keiyaku_Data_Select
        '説明            :契約者データ取得
        '引数            :1.cmbKeiyakuCd     String   契約者コードコンボボックス
        '                 2.cmbKeiyakuMei    String   契約者名コンボボックス
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As String, _
                                                 ByRef cmbKeiyakuMei As String) As Boolean

            If Not f_Keiyaku_Data_Select(cmbKeiyakuCd, cmbKeiyakuMei, "", False, True) Then
                Return False
            End If

            Return True

        End Function

    #End Region
    #Region "f_JimuItaku_Data_Select 事務委託先データ取得(防疫互助)"
        '------------------------------------------------------------------
        'プロシージャ名  :f_JimuItaku_Data_Select
        '説明            :事務委託先データ取得(防疫互助)
        '引数            :1.cmbJimuItakuCd     String   事務委託先コードコンボボックス
        '                 2.cmbJimuItakuMei    String   事務委託先名コンボボックス
        '                 3.strWhere        String                      事務委託先マスタ検索条件 WHERE句を指定する
        '                 4.blnNullAddFlg   Boolean                     スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_JimuItaku_Data_Select(ByRef cmbJimuItakuCd As String, _
                                                ByRef cmbJimuItakuMei As String, _
                                                ByVal strWhere As String, _
                                                ByVal blnNullAddFlg As Boolean, _
                                                ByVal blnEnable As Boolean) As Boolean

            '2015/03/03 JBD368 UPD ↓↓↓ コンボボックスへのセット方法を変更
            'Dim sSql As String = String.Empty
            'Dim dstDataSanka As New DataSet

            'f_JimuItaku_Data_Select = False

            'Try

            '    sSql = "SELECT "
            '    sSql = sSql & "  ITAKU_CD,"
            '    sSql = sSql & "  ITAKU_NAME"
            '    sSql = sSql & " FROM"
            '    sSql = sSql & "  TM_JIMUITAKU"

            '    If strWhere <> "" Then
            '        sSql = sSql & " WHERE"
            '        sSql = sSql & " " & strWhere
            '    End If

            '    sSql = sSql & " ORDER BY ITAKU_CD"

            '    Call f_Select_ODP(dstDataSanka, sSql)

            '    cmbJimuItakuCd.Items.Clear()
            '    cmbJimuItakuMei.Items.Clear()

            '    With dstDataSanka.Tables(0)
            '        If .Rows.Count > 0 Then
            '            For i As Integer = 0 To .Rows.Count - 1
            '                cmbJimuItakuCd.Items.Add(WordHenkan("N", "S", .Rows(i)("ITAKU_CD")))
            '                cmbJimuItakuMei.Items.Add(WordHenkan("N", "S", .Rows(i)("ITAKU_NAME")))
            '            Next

            '            '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
            '            If blnNullAddFlg Then
            '                'コンボ空白項目追加
            '                cmbJimuItakuCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbJimuItakuMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
            '            End If
            '            '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

            '        End If
            '    End With

            '    '事務委託先コード使用可
            '    cmbJimuItakuCd.Enabled = blnEnable
            '    cmbJimuItakuMei.Enabled = blnEnable

            '    f_JimuItaku_Data_Select = True

            'Catch ex As Exception
            '    '共通例外処理
            '    'Show_MessageBox("", ex.Message)
            'End Try


            Dim sSql As String = String.Empty
            Dim dstDataSanka As New DataSet

            f_JimuItaku_Data_Select = False

            Try

                sSql = ""
                If blnNullAddFlg Then   '第3引数=Trueの時、空白項目を追加
                    'コンボ空白項目追加
                    sSql = "SELECT "
                    sSql = sSql & "NULL AS ITAKU_CD, NULL AS ITAKU_NAME "
                    sSql = sSql & "FROM DUAL "
                    sSql = sSql & "UNION ALL "
                End If
                sSql = sSql & "SELECT "
                sSql = sSql & "  ITAKU_CD,"
                sSql = sSql & "  ITAKU_NAME"
                sSql = sSql & " FROM"
                sSql = sSql & "  TM_JIMUITAKU"

                If strWhere <> "" Then
                    sSql = sSql & " WHERE"
                    sSql = sSql & " " & strWhere
                End If

                If blnNullAddFlg Then   '第3引数=Trueの時、空白項目を先頭に表示する
                    sSql = sSql & " ORDER BY ITAKU_CD NULLS FIRST"
                Else
                    sSql = sSql & " ORDER BY ITAKU_CD"
                End If

                Call f_Select_ODP(dstDataSanka, sSql)

                'cmbJimuItakuCd.Clear()
                'cmbJimuItakuMei.Clear()

                'With dstDataSanka.Tables(0)
                '    If .Rows.Count > 0 Then
                '        'コンボボックスにデータをバインド
                '        cmbJimuItakuCd.DataSource = dstDataSanka.Tables(0)
                '        '不要なカラムを削除する
                '        cmbJimuItakuCd.ListColumns.RemoveAt(1)

                '        'コンボボックスにデータをバインド
                '        cmbJimuItakuMei.DataSource = dstDataSanka.Tables(0)
                '        '不要なカラムを削除する
                '        cmbJimuItakuMei.ListColumns.RemoveAt(0)
                '        '名称のコンボボックスの幅を設定
                '        cmbJimuItakuMei.ListColumns(0).Width = cmbJimuItakuMei.Width
                '    End If
                'End With

                ''事務委託先コード使用可
                'cmbJimuItakuCd.Enabled = blnEnable
                'cmbJimuItakuMei.Enabled = blnEnable

                f_JimuItaku_Data_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try
            '2015/03/03 JBD368 UPD ↑↑↑

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_JimuItaku_Data_Select
        '説明            :事務委託先データ取得
        '引数            :1.cmbJimuItakuCd     String   事務委託先コードコンボボックス
        '                 2.cmbJimuItakuMei    String   事務委託先名コンボボックス
        '                 3.strWhere        String                    事務委託先マスタ検索条件 WHERE句を指定する
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_JimuItaku_Data_Select(ByRef cmbJimuItakuCd As String, _
                                                    ByRef cmbJimuItakuMei As String, _
                                                    ByVal strWhere As String, _
                                                    ByVal blnNullAddFlg As Boolean) As Boolean

            If Not f_JimuItaku_Data_Select(cmbJimuItakuCd, cmbJimuItakuMei, strWhere, blnNullAddFlg, True) Then
                Return False
            End If

            Return True

        End Function
        '------------------------------------------------------------------
        'プロシージャ名  :f_JimuItaku_Data_Select
        '説明            :事務委託先データ取得
        '引数            :1.cmbJimuItakuCd     String   事務委託先コードコンボボックス
        '                 2.cmbJimuItakuMei    String   事務委託先名コンボボックス
        '                 3.strWhere        String                    事務委託先マスタ検索条件 WHERE句を指定する
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_JimuItaku_Data_Select(ByRef cmbJimuItakuCd As String, _
                                                    ByRef cmbJimuItakuMei As String, _
                                                    ByVal strWhere As String) As Boolean

            If Not f_JimuItaku_Data_Select(cmbJimuItakuCd, cmbJimuItakuMei, strWhere, False, True) Then
                Return False
            End If

            Return True

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_JimuItaku_Data_Select
        '説明            :事務委託先データ取得
        '引数            :1.cmbJimuItakuCd     String   事務委託先コードコンボボックス
        '                 2.cmbJimuItakuMei    String   事務委託先名コンボボックス
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_JimuItaku_Data_Select(ByRef cmbJimuItakuCd As String, _
                                                 ByRef cmbJimuItakuMei As String) As Boolean

            If Not f_JimuItaku_Data_Select(cmbJimuItakuCd, cmbJimuItakuMei, "", False, True) Then
                Return False
            End If

            Return True

        End Function

    #End Region
    #Region "f_KeiyakuNojo_Data_Select 契約農場データ取得(防疫互助)"
        '------------------------------------------------------------------
        'プロシージャ名  :f_KeiyakuNojo_Data_Select
        '説明            :契約農場データ取得(防疫互助)
        '引数            :1.cmbKeiyakuNojoCd     String   契約農場コードコンボボックス
        '                 2.cmbKeiyakuNojoMei    String   契約農場名コンボボックス
        '                 3.strWhere        String                      契約農場マスタ検索条件 WHERE句を指定する
        '                 4.blnNullAddFlg   Boolean                     スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_KeiyakuNojo_Data_Select(ByRef cmbKeiyakuNojoCd As String, _
                                                ByRef cmbKeiyakuNojoMei As String, _
                                                ByVal strWhere As String, _
                                                ByVal blnNullAddFlg As Boolean,
                                                ByVal blnEnable As Boolean) As Boolean

            Dim sSql As String = String.Empty
            Dim dstDataSanka As New DataSet

            f_KeiyakuNojo_Data_Select = False

            Try

                sSql = "SELECT "
                sSql = sSql & "  NOJO_CD,"
                sSql = sSql & "  NOJO_NAME"
                sSql = sSql & " FROM"
                sSql = sSql & "  TM_KEIYAKU_NOJO"

                If strWhere <> "" Then
                    sSql = sSql & " WHERE"
                    sSql = sSql & " " & strWhere
                End If

                sSql = sSql & " ORDER BY NOJO_CD"

                Call f_Select_ODP(dstDataSanka, sSql)

                'cmbKeiyakuNojoCd.Items.Clear()
                'cmbKeiyakuNojoMei.Items.Clear()

                'With dstDataSanka.Tables(0)
                '    If .Rows.Count > 0 Then
                '        For i As Integer = 0 To .Rows.Count - 1
                '            cmbKeiyakuNojoCd.Items.Add(WordHenkan("N", "S", .Rows(i)("NOJO_CD")))
                '            cmbKeiyakuNojoMei.Items.Add(WordHenkan("N", "S", .Rows(i)("NOJO_NAME")))
                '        Next

                '        '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                '        If blnNullAddFlg Then
                '            'コンボ空白項目追加
                '            cmbKeiyakuNojoCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbKeiyakuNojoMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                '    End If
                'End With

                ''契約農場コード使用可
                'cmbKeiyakuNojoCd.Enabled = blnEnable
                'cmbKeiyakuNojoMei.Enabled = blnEnable

                f_KeiyakuNojo_Data_Select = True

            Catch ex As Exception
                '共通例外処理
                'Show_MessageBox("", ex.Message)
            End Try

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_KeiyakuNojo_Data_Select
        '説明            :契約農場データ取得
        '引数            :1.cmbKeiyakuNojoCd     String   契約農場コードコンボボックス
        '                 2.cmbKeiyakuNojoMei    String   契約農場名コンボボックス
        '                 3.strWhere        String                    契約農場マスタ検索条件 WHERE句を指定する
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_KeiyakuNojo_Data_Select(ByRef cmbKeiyakuNojoCd As String, _
                                                    ByRef cmbKeiyakuNojoMei As String, _
                                                    ByVal strWhere As String, _
                                                    ByVal blnNullAddFlg As Boolean) As Boolean

            If Not f_KeiyakuNojo_Data_Select(cmbKeiyakuNojoCd, cmbKeiyakuNojoMei, strWhere, blnNullAddFlg, True) Then
                Return False
            End If

            Return True

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_KeiyakuNojo_Data_Select
        '説明            :契約農場データ取得
        '引数            :1.cmbKeiyakuNojoCd     String   契約農場コードコンボボックス
        '                 2.cmbKeiyakuNojoMei    String   契約農場名コンボボックス
        '                 3.strWhere        String                    契約農場マスタ検索条件 WHERE句を指定する
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_KeiyakuNojo_Data_Select(ByRef cmbKeiyakuNojoCd As String, _
                                                    ByRef cmbKeiyakuNojoMei As String, _
                                                    ByVal strWhere As String) As Boolean

            If Not f_KeiyakuNojo_Data_Select(cmbKeiyakuNojoCd, cmbKeiyakuNojoMei, strWhere, False, True) Then
                Return False
            End If

            Return True

        End Function

        '------------------------------------------------------------------
        'プロシージャ名  :f_KeiyakuNojo_Data_Select
        '説明            :契約農場データ取得
        '引数            :1.cmbKeiyakuNojoCd     String   契約農場コードコンボボックス
        '                 2.cmbKeiyakuNojoMei    String   契約農場名コンボボックス
        '戻り値          :Boolean(正常True/エラーFalse)
        '------------------------------------------------------------------
        Public Function f_KeiyakuNojo_Data_Select(ByRef cmbKeiyakuNojoCd As String, _
                                                 ByRef cmbKeiyakuNojoMei As String) As Boolean

            If Not f_KeiyakuNojo_Data_Select(cmbKeiyakuNojoCd, cmbKeiyakuNojoMei, "", False, True) Then
                Return False
            End If

            Return True

        End Function

    #End Region


    #End Region

    End Module
End Namespace
