' *******************************************************************
' �Ɩ����́@: �ݏ��h�u�V�X�e��
' �@�\�T�v�@: �d�l�r���ʃ��W���[��
'
' �쐬���@�@: 2024.07.12
' �쐬�ҁ@�@: 
' �ύX�����@:
' *******************************************************************
Imports JbdGjsDb.JBD.GJS.Db

Namespace JBD.GJS.Common
    Public Module JbdGjsCommon

#Region "*** �ϐ���` ***"
        Public Cnn As DaDbContext
        Public pPCNAME As String
        Public pFILEVERSION As String        '�A�Z���u���o�[�W���� 2014/12/23 ADD JBD368
        Public pAPP As String           'APID
        Public pAPPTITLE As String      '��ʃ^�C�g��
        Public pLOGINUSERID As String   '���O�I�����[�U�h�c 2010/10/23 ADD JBD200
        Public pLOGINUSERNM As String   '���O�I�����[�U��
        Public myDBUSER As String
        Public myDBPASS As String
        Public myDBSID As String
        Public myREPORT_PDF_PATH As String
        Public myREPORT_EXCEL_PATH As String
        Public myTEMPLATE_EXCEL_PATH As String  '2015/03/23 ADD EXCEL�e���v���[�g�p�t�@�C���p�X�ǉ�
        Public myREPORT_PDF_OUTKBN As String
        Public myANNAI_CD As Integer = 0        '2010/11/08 ADD JBD200 �ē����}�X�^�̎�ޏ����\���p
        Public myTAISYO_NENGETU As Date         '2012/02/21 ADD JBD200 ���F�@�l�������p
        Public myYOHAKU_UP As Double
        Public myYOHAKU_DOWN As Double
        Public myYOHAKU_LEFT As Double
        Public myYOHAKU_RIGHT As Double
        Public myBACKCOLOR_STRING As String = String.Empty
        Public myBACKCOLOR As System.Drawing.Color          '2014/05/09�@��ʔw�i�F
        Public myTXT_FURIKOMI_ENTRY As String
        Public myLogonDate As String
        Public myWeekDay As String
        Public pConnection As String
        Public iniFileName As String
        '���ʌ�����ʗp�ϐ�--------------------------------------
        Public pKoumokumei() As String
        Public pKoumokucnt As Integer
        Public pAlign() As String
        Public pMasterKey() As String
        Public pMasterKeycnt As Integer
        Public pSelectSql As String
        Public pTitle As String
        Public pretButton As String
        '------------------------------------------------------------------

        '���b�Z�[�W�i�[�p�ϐ�--------------------------------------
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

        'GJS.INI�i�[�p�ϐ�--------------------------------------
        Public Structure pGJSINI
            Public LOGINUSERID As String            '2010/10/23 ADD JBD200
            Public LOGINUSERNM As String
            Public DBUSER As String
            Public DBPASS As String
            Public DBSID As String
            Public TXT_FURIKOMI_ENTRY As String
            Public REPORT_PDF_PATH As String
            Public REPORT_EXCEL_PATH As String
            Public TEMPLATE_EXCEL_PATH As String  '2015/03/23 ADD EXCEL�e���v���[�g�p�t�@�C���p�X�ǉ�
            Public REPORT_PDF_OUTKBN As String
            Public ANNAI_CD As Integer      '2010/11/08 ADD JBD200 �ē����}�X�^�̎�ޏ����\���p
            Public TAISYO_NENGETU As Date   '2012/02/21 ADD JBD200 ���F�@�l�������p
            Public YOHAKU_UP As Double
            Public YOHAKU_DOWN As Double
            Public YOHAKU_LEFT As Double
            Public YOHAKU_RIGHT As Double
            Public SCR_BACKCOLOR_STRING As String          '2014/05/09�@�ǉ�
            Public SCR_BACKCOLOR As System.Drawing.Color   '2014/05/09�@�ǉ�
        End Structure
        '------------------------------------------------------------------

        Public pCNT As Integer = 0                           '���[�o�͌���
        Private xl As New JbdGjsExcel
        Private pRow As Integer = 0                         'Excel�o�͎��̍s�ԍ�

        '2024/01/22 �z�Q�Ɖ����̂��߁ALib�̐F��ύX�����ꍇ�͂������ύX
        Dim wBaseBackColor As System.Drawing.Color = Color.AliceBlue

        '2017/07/14�@�ǉ��J�n
        Public pKikin2 As Boolean = False
        '2017/07/14�@�ǉ��I��

#End Region

#Region "*** �萔��` ***"

        '���b�Z�[�W�\�����̃A�C�R���^�p
        '('Show_MessageBox�֐��̑�Q�����p)
        Public Const C_MSGICON_QUESTION = 0         'Question
        Public Const C_MSGICON_ERROR = 1            'Error
        Public Const C_MSGICON_WARNING = 2          'Warning
        Public Const C_MSGICON_INFORMATION = 3      'Information

        Public Const C_YOHAKU_UP = 1.5
        Public Const C_YOHAKU_DOWN = 1.0
        Public Const C_YOHAKU_LEFT = 1.0
        Public Const C_YOHAKU_RIGHT = 1.0

        '��ʏ������[�h
        Public Const C_MENU As Byte = 0
        Public Const C_MAIN As Byte = 1
        Public Const C_SUB As Byte = 2

#End Region

#Region "*** ���������֘A ***"

        '------------------------------------------------------------------
        '�v���V�[�W����  :f_ColorConvert
        '����            :ini�擾����
        '����            :
        '�߂�l          :Boolean(����True/�G���[False)
        '�쐬��          :2014/05/09
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
        '�v���V�[�W����  :Get_CommandLine
        '����            :�R�}���h���C�����擾
        '�߂�l          :Boolean(����True/�G���[False)
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
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
            End Try
        End Function
#End Region

#Region "*** �����񐧌�֐� ***"
        '------------------------------------------------------------------
        '�v���V�[�W����  :fMidB
        '����            :��������o�C�g�P�ʂňʒu�w�肵�Đ؂蔲��
        '����            :myString(����)
        '                :sByt(�J�n�o�C�g��)
        '                :nByt(�o�C�g��)
        '�߂�l          :�؎����������Ԃ�
        '------------------------------------------------------------------
        Public Function fMidB(ByVal myString As String, _
                                ByVal sByt As Integer, ByVal nByt As Integer) As String
            '�w��o�C�g�ʒu����w��o�C�g�����̕���������o���֐�
            Dim sjis As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
            Dim tempByt() As Byte = sjis.GetBytes(myString)
            Dim sumByt As Integer = sjis.GetByteCount(myString)
            If sByt < 0 Or nByt <= 0 Or sByt > sumByt Then Return ""
            Dim strTemp As String = sjis.GetString(tempByt, 0, sByt)
            If sByt > 0 And strTemp.EndsWith(ControlChars.NullChar) Then
                sByt += 1   '�J�n�ʒu�������̒��Ȃ玟(�O)�̕�������J�n
            End If
            If sByt + nByt > sumByt Then    '��������葽���擾���悤�Ƃ����ꍇ
                nByt = sumByt - sByt        '������̍Ō�܂ł̕��Ƃ���
            End If
            Return sjis.GetString(tempByt, sByt, nByt).TrimEnd(ControlChars.NullChar)
        End Function
        '------------------------------------------------------------------
        '�v���V�[�W����  :fStrCut
        '����            :��������o�C�g�P�ʂňʒu�w�肵�Đ؂蔲��
        '����            :Mystring(����)
        '                :nLen(�o�C�g��)
        '�߂�l          :�؎����������Ԃ�
        '------------------------------------------------------------------
        Public Function fStrCut(ByVal Mystring As String, ByVal nLen As Integer) As String
            '��������w��̃o�C�g���ɃJ�b�g����֐�(�������f����j
            Dim sjis As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
            Dim TempLen As Integer = sjis.GetByteCount(Mystring)
            If nLen < 1 Or Mystring.Length < 1 Then Return Mystring
            If TempLen <= nLen Then   '�����񂪎w��̃o�C�g�������̏ꍇ�X�y�[�X��t������
                Return Mystring.PadRight(nLen - (TempLen - Mystring.Length), " ")
            End If
            Dim tempByt() As Byte = sjis.GetBytes(Mystring)
            Dim strTemp As String = sjis.GetString(tempByt, 0, nLen)
            '�������������f���ꂽ�甼�p�X�y�[�X�ƒu������(VB2005="�E" ��.NET2003=NullChar �ɂȂ�܂��j
            If strTemp.EndsWith(ControlChars.NullChar) Or strTemp.EndsWith("�E") Then
                strTemp = sjis.GetString(tempByt, 0, nLen - 1) & " "
            End If
            Return strTemp
        End Function

        '------------------------------------------------------------------
        '�v���V�[�W����  :WordHenkan
        '����       :���Ұ��ɂ��w�肳�ꂽ���ڂ�NULL,SPACE,ZERO�^�ɕϊ�����
        '���Ұ�     :�@ strFrom     i,  String,     "N"=NULL,"Z"=ZERO,"S"=SPACE�̕ϊ��O�̌^���w��
        '           :�A strTo       i,  String      "N"=NULL,"Z"=ZERO,"S"=SPACE�̕ϊ���̌^���w��
        '           :�B vardata     i,  Variant      �ϊ��O�̍���
        '�߂�l     :               o,  Variant      �ϊ���̍���
        '------------------------------------------------------------------
        Public Function WordHenkan(ByVal strFrom As String, _
                                        ByVal strTo As String, _
                                        ByVal vardata As Object) As Object

            On Error GoTo Error_WordHenkan
            'NULL����ZERO�ւ̕ϊ�
            If strFrom = "N" And strTo = "Z" Then
                If IsDBNull(vardata) Then
                    WordHenkan = 0
                ElseIf CStr(vardata) = "null" Then
                    WordHenkan = IIf(vardata = "null", "0", RTrim(vardata))
                Else
                    WordHenkan = IIf(IsDBNull(vardata), "0", RTrim(vardata))
                End If
                Exit Function

                'NULL����SPACE�ւ̕ϊ�
            ElseIf strFrom = "N" And strTo = "S" Then
                If IsDBNull(vardata) Then
                    WordHenkan = ""
                ElseIf CStr(vardata) = "null" Then
                    WordHenkan = IIf(vardata = "null", "", RTrim(vardata))
                Else
                    WordHenkan = IIf(IsDBNull(vardata), "", RTrim(vardata))
                End If
                Exit Function
                'ZERO����NULL�ւ̕ϊ�
            ElseIf strFrom = "Z" And strTo = "N" Then

                If IsDBNull(vardata) Or vardata = "0" Then
                    WordHenkan = System.DBNull.Value
                Else
                    WordHenkan = vardata
                End If
                Exit Function

                'ZERO����SPACE�ւ̕ϊ�
            ElseIf strFrom = "Z" And strTo = "S" Then

                If IsDBNull(vardata) Or vardata = "0" Then
                    WordHenkan = ""
                Else
                    WordHenkan = vardata
                End If
                Exit Function
                'SPACE����NULL�ւ̕ϊ�
            ElseIf strFrom = "S" And strTo = "N" Then

                If IsDBNull(vardata) Or Len(RTrim(vardata)) = 0 Then
                    WordHenkan = System.DBNull.Value
                Else
                    WordHenkan = vardata
                End If
                Exit Function
                'SPACE����ZERO�ւ̕ϊ�
            ElseIf strFrom = "S" And strTo = "Z" Then

                If IsDBNull(vardata) Or Len(RTrim(vardata)) = 0 Then
                    WordHenkan = "0"
                Else
                    WordHenkan = vardata
                End If
                Exit Function
            Else
                '����ȊO(�w��~�X)
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
#Region "ReplaceString ������u��"
        '------------------------------------------------------------------
        '�v���V�[�W����  :ReplaceString
        '����       :������u��
        '���Ұ�     :�@ strFrom     i,  String,     "N"=NULL,"Z"=ZERO,"S"=SPACE�̕ϊ��O�̌^���w��
        '           :�A strTo       i,  String      "N"=NULL,"Z"=ZERO,"S"=SPACE�̕ϊ���̌^���w��
        '           :�B vardata     i,  Variant      �ϊ��O�̍���
        '�߂�l     :               o,  Variant      �ϊ���̍���
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

#Region "*** ���t����֐� ***"
        Public Function ACoDateCheckEdit(ByVal objString As String, _
                                            ByVal varEditDate As Object) As Boolean
            '�T�v       : �e�L�X�g�{�b�N�X�ɓ��͂��ꂽ������̓��t�`�F�b�N���s��
            '���Ұ�     : �@objString  �F�e�L�X�g�{�b�N�X��
            '           : �AvarEditDate �F�ҏW���ʂ��Z�b�g�������(Optional)
            '           : �B�߂�l,     �FTrue:���t����  False:���t�ُ�
            '����       :

            Dim intY As Integer
            Dim intM As Integer
            Dim intD As Integer

            Try

                ACoDateCheckEdit = True

                If Len(objString) = 0 Then
                    Exit Function
                End If


                ' YYMMDD �̌`���œ��͂��ꂽ�ꍇ
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

                ' YYYYMMDD �̌`���œ��͂��ꂽ�ꍇ
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

                ' YY-MM-DD(YY/MM/DD) �̌`���œ��͂��ꂽ�ꍇ
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

                ' YYYY-MM-DD(YYYY/MM/DD) �̌`���œ��͂��ꂽ�ꍇ
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
                'Show_MessageBox("", "YYYYMMDD �܂��� YYMMDD �̌`���œ��͂��ĉ������B") 'YYYYMMDD �܂��� YYMMDD �̌`���œ��͂��ĉ������B
                ''Show_MessageBox("YYYYMMDD �܂��� YYMMDD �̌`���œ��͂��ĉ������B", C_MSGICON_ERROR)
                ACoDateCheckEdit = False
                Exit Function

                'ACoDateCheckEdit_Exit2:

                '            'Show_MessageBox("000049", "") '����́A1990�N����2089�N�܂ł���͂��ĉ������B"
                '            ACoDateCheckEdit = False
                '            Exit Function

ACoDateCheckEdit_Exit3:

                'Show_MessageBox("", "�Y��������t�͑��݂��܂���B") 'YYYYMMDD �܂��� YYMMDD �̌`���œ��͂��ĉ������B
                ''Show_MessageBox("�Y��������t�͑��݂��܂���B", C_MSGICON_ERROR)
                ACoDateCheckEdit = False
                Exit Function


            Catch ex As Exception
                '���ʗ�O����
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
            '�T�v       :���邤�`�F�b�N
            '���Ұ�     :intY,i,Integer,�N�i00�`99�C90�`99��1990�`1999�A00�`89��2000�`2089�j
            '           :intM,i,Integer,��
            '           :intD,i,Integer,��
            '           :�߂�l,����->�@0�ȏ�A�ُ�->�@�|�P
            '����       :

            Dim intLeapday As Integer

            Select Case intM
                Case 1, 3, 5, 7, 8, 10, 12
                    If intD > 0 And intD < 32 Then
                        ACoLeapCheck = True
                    Else
                        ACoLeapCheck = False  '���͈̔̓G���[
                    End If

                Case 4, 6, 9, 11
                    If intD > 0 And intD < 31 Then
                        ACoLeapCheck = True
                    Else
                        ACoLeapCheck = False  '���͈̔̓G���[
                    End If

                Case 2
                    If intY Mod 4 = 0 Then     '4�Ŋ���؂��N(����2000�N�͂��邤�N�j
                        intLeapday = 1
                    Else
                        intLeapday = 0
                    End If

                    If intD > 0 And intD < 29 + intLeapday Then
                        ACoLeapCheck = True
                    Else
                        ACoLeapCheck = False  '���͈̔̓G���[
                    End If

                Case Else  '���͈̔̓G���[
                    ACoLeapCheck = False

            End Select
        End Function

#Region "f_DateTrim ���ԏȗ�"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_DateTrim
        '����            :�����񁨓��t�ϊ�
        '����            :
        '�߂�l          :Boolean(����True/�G���[False)
        '------------------------------------------------------------------
        Public Function f_DateTrim(ByVal wkDate As Date) As Date
            If IsNothing(wkDate) OrElse wkDate = New Date Then
                Return wkDate
            Else
                Return Date.Parse(wkDate.ToString("yyyy/MM/dd"))
            End If
        End Function
#End Region

#Region "f_Str2DateOrNothing �������Date��Nothing�ɕϊ�"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Str2DateOrNothing
        '����            :�������Date��Nothing�ɕϊ��B
        '����            :
        '�߂�l          :Boolean(����True/�G���[False)
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

#Region "f_DateNothingCheck Date��Nothing�܂��͏����l�ȊO�ł��邩����"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_DateNothingCheck
        '����            :���t��Nothing�܂��͏����l(0001/01/01)�ȊO�ł��邩�`�F�b�N
        '����            :wkDate�F�Ώۓ��t
        '�߂�l          :Boolean(Nothing�ȊO�̏ꍇ�FTrue/Nothing�܂���0001/01/01�̏ꍇ�FFalse)
        '�X�V��          :2015/02/23 JBD368 ADD
        '------------------------------------------------------------------
        Public Function f_DateNothingCheck(ByVal wkDate As Date) As Boolean

            If IsNothing(wkDate) OrElse wkDate.ToString("yyyy/MM/dd") = "0001/01/01" Then
                Return False
            End If

            Return True
        End Function
#End Region

#End Region

#Region "*** SQL�֐��֘A ***"
#Region "f_Select_ODP SELECT"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Select_ODP
        '����            :�f�[�^Select
        '����            :1.ByRef dstDatasetSend  �f�[�^�Z�b�g
        '*                2.strTableName    �e�[�u����
        '*                3.strCriteria     Optional    Where��
        '*                4.strFields       Optional    ����
        '�߂�l          :Boolean(����True/�G���[False)
        '------------------------------------------------------------------
        Public Function f_Select_ODP(ByRef dstDatasetSend As DataSet, ByVal strSQL As String) As Boolean
            'Dim strSQL As String
            Dim dstDataSet As New DataSet
            Dim objOraDB As Object = ""
            Dim blnRet As Boolean = False

            ''�}���`�T�[�o�[�Ή�
            'Cnn.ConnectionString = pConnection

            ''���o
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
                '���ʗ�O����
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

            ''�}���`�T�[�o�[�Ή�
            'Cnn.ConnectionString = pConnection

            ''���o
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
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
                dstDatasetSend = Nothing
            End Try

            Return blnRet

        End Function
#End Region
#Region "f_Select_ODR SELECT"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Select_ODR
        '����            :�f�[�^Select(OracleDataReader�g�p)
        '����            :1.ByRef dstDatasetSend  �f�[�^�Z�b�g
        '*                2.strTableName    �e�[�u����
        '*                3.strCriteria     Optional    Where��
        '*                4.strFields       Optional    ����
        '�߂�l          :Boolean(����True/�G���[False)
        '------------------------------------------------------------------
        Public Function f_Select_ODR(ByRef rdr As Oracle.ManagedDataAccess.Client.OracleDataReader, ByVal strSQL As String) As Boolean
            '**************
            'Dim strSQL As String
            Dim blnRet As Boolean = False

            Try
                Dim Cmd As New Oracle.ManagedDataAccess.Client.OracleCommand


                Cmd.Connection = Cnn.db.Connection
                Cmd.CommandText = strSQL

                ' OracleDataReader�I�u�W�F�N�g�𐶐����܂��B
                rdr = Cmd.ExecuteReader

                blnRet = True
            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
            End Try

            Return blnRet

        End Function
#End Region
#Region "f_SqlEdit SQL���Ɋ܂܂�Ă����߽��̨����d������"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_SqlEdit
        '����            :SQL���Ɋ܂܂�Ă����߽��̨����d������
        '����            :1.strSQL      �ϊ��OSQL��
        '�߂�l          :String        �ϊ���SQL��
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
#Region "f_ExecuteSQLODP_TRANS SQL�X�e�[�g�����g�𔭍s����(COMMIT����)"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_ExecuteSQLODP_TRANS
        '����            :SQL�X�e�[�g�����g�𔭍s����(COMMIT����)
        '����            :1.strSQL      SQL�X�e�[�g�����g
        '�߂�l          :Boolean(����True/�G���[False)
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
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
                trans.Rollback()
                Exit Function
            End Try
            f_ExecuteSQLODP_TRANS = True

        End Function
#End Region
#Region "f_ExecuteSQLODP SQL�X�e�[�g�����g�𔭍s����"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_ExecuteSQLODP
        '����            :SQL�X�e�[�g�����g�𔭍s����
        '����            :1.strSQL      SQL�X�e�[�g�����g
        '�߂�l          :Boolean(����True/�G���[False)
        '------------------------------------------------------------------
        Public Function f_ExecuteSQLODP(ByVal strSQL As String) As Boolean
            Dim blnAns As Boolean = False

            Try
                Debug.WriteLine(strSQL)

                Dim Cmd As New OracleCommand(strSQL, Cnn.db.Connection)
                Cmd.ExecuteNonQuery()
                blnAns = True
            Catch ex As OracleException
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
                Return blnAns
            End Try
            Return blnAns

        End Function
#End Region
#Region "f_Data_ExecuteNonQuery SQL�����s����"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Data_ExecuteNonQuery
        '����            :
        '����            :�Ȃ�
        '�߂�l          :Boolean(����True/�G���[False)
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
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
                If Not Cmd Is Nothing Then
                    Cmd.Dispose()
                End If
            End Try

        End Function
#End Region
#End Region

#Region "�}�X�^���݃`�F�b�N"

        ''' <summary>
        ''' ���Y�҃}�X�^(TM_SEISANSYA)���݃`�F�b�N
        ''' </summary>
        ''' <param name="SEISANSYA_CD">���Y�҃R�[�h</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function f_Exists_TM_SEISANSYA(ByVal SEISANSYA_CD As Integer) As Boolean
            Dim wkKVs As New List(Of KeyValuePair(Of String, Object))
            '���e�[�u����
            Dim wkTableName = "TM_SEISANSYA"


            '���L�[�ǉ��@�~�@N
            'wkKVs.Add(New KeyValuePair(Of String, Object)( _
            '        "��", _
            '          �l _
            '       ))


            '�L�[�ǉ�(���Y�҃R�[�h)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "SEISANSYA_CD", _
                        SEISANSYA_CD _
                    ))


            Return f_Exists_DT(wkTableName, wkKVs.ToArray)

        End Function

        ''' <summary>
        ''' �R�[�h�}�X�^(TM_CODE)���݃`�F�b�N
        ''' </summary>
        ''' <param name="SYURUI_KBN">�����敪</param>
        ''' <param name="MEISYO_CD">���̃R�[�h</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function f_Exists_TM_CODE(ByVal SYURUI_KBN As Integer, ByVal MEISYO_CD As Integer) As Boolean
            Dim wkKVs As New List(Of KeyValuePair(Of String, Object))
            '���e�[�u����
            Dim wkTableName = "TM_CODE"


            '���L�[�ǉ��@�~�@N
            'wkKVs.Add(New KeyValuePair(Of String, Object)( _
            '        "��", _
            '          �l _
            '       ))


            '�L�[�ǉ�(��ދ敪)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "SYURUI_KBN", _
                        SYURUI_KBN _
                    ))

            '�L�[�ǉ�(���̃R�[�h)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "MEISYO_CD", _
                        MEISYO_CD _
                    ))

            Return f_Exists_DT(wkTableName, wkKVs.ToArray)

        End Function

        ''' <summary>
        ''' �㗝�l�}�X�^(TM_ITAKU)���݃`�F�b�N
        ''' </summary>
        ''' <param name="ITAKU_CD">�㗝�l�ԍ�</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function f_Exists_TM_ITAKU(ByVal ITAKU_CD As Integer) As Boolean
            Dim wkKVs As New List(Of KeyValuePair(Of String, Object))
            '���e�[�u����
            Dim wkTableName = "TM_ITAKU"


            '���L�[�ǉ��@�~�@N
            'wkKVs.Add(New KeyValuePair(Of String, Object)( _
            '        "��", _
            '          �l _
            '       ))


            '�L�[�ǉ�(�㗝�l�ԍ�)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "ITAKU_CD", _
                        ITAKU_CD _
                    ))



            Return f_Exists_DT(wkTableName, wkKVs.ToArray)

        End Function

        ''' <summary>
        ''' ���Z�@�փ}�X�^(TM_BANK)���݃`�F�b�N
        ''' </summary>
        ''' <param name="BANK_CD">���Z�@�փR�[�h</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function f_Exists_TM_BANK(ByVal BANK_CD As Integer) As Boolean
            Dim wkKVs As New List(Of KeyValuePair(Of String, Object))
            '���e�[�u����
            Dim wkTableName = "TM_BANK"


            '���L�[�ǉ��@�~�@N
            'wkKVs.Add(New KeyValuePair(Of String, Object)( _
            '        "��", _
            '          �l _
            '       ))


            '�L�[�ǉ�(���Z�@�փR�[�h)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "BANK_CD", _
                        BANK_CD _
                    ))



            Return f_Exists_DT(wkTableName, wkKVs.ToArray)

        End Function

        ''' <summary>
        ''' ���Z�@�֎x�X�}�X�^(TM_SITEN)���݃`�F�b�N
        ''' </summary>
        ''' <param name="BANK_CD">���Z�@�փR�[�h</param>
        ''' <param name="SITEN_CD">���Z�@�֎x�X�R�[�h</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function f_Exists_TM_SITEN(ByVal BANK_CD As Integer, ByVal SITEN_CD As Integer) As Boolean
            Dim wkKVs As New List(Of KeyValuePair(Of String, Object))
            '���e�[�u����
            Dim wkTableName = "TM_SITEN"


            '���L�[�ǉ��@�~�@N
            'wkKVs.Add(New KeyValuePair(Of String, Object)( _
            '        "��", _
            '          �l _
            '       ))


            '�L�[�ǉ�(���Z�@�փR�[�h)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "BANK_CD", _
                        BANK_CD _
                    ))

            '�L�[�ǉ�(���Z�@�֎x�X�R�[�h)
            wkKVs.Add(New KeyValuePair(Of String, Object)( _
                    "SITEN_CD", _
                        SITEN_CD _
                    ))


            Return f_Exists_DT(wkTableName, wkKVs.ToArray)

        End Function

        ''' <summary>
        ''' ���݃`�F�b�N
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
                '���ʗ�O����
                'Show_MessageBox(ex.Message, C_MSGICON_ERROR)
            End Try

            Return wkRtnBool

        End Function

#End Region

#Region "���b�Z�[�W�֘A"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Message_Select
        '����            :���b�Z�[�W�}�X�^�擾����
        '����            :
        '�߂�l          :Boolean(����True/�G���[False)
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
                    ''Show_MessageBox("000011", "") '�}�X�^�Ƀf�[�^���o�^����Ă��܂���B
                    'Show_MessageBox("", "�}�X�^�Ƀf�[�^���o�^����Ă��܂���B") '�}�X�^�Ƀf�[�^���o�^����Ă��܂���B
                End If
                rdr.Close()


                If Not Cmd Is Nothing Then
                    Cmd.Dispose()
                End If

                f_Message_Select = True

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
                If Not Cmd Is Nothing Then
                    Cmd.Dispose()
                End If
            End Try

        End Function
#End Region

#Region "�^�C�g���\���֘A"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Title_Get
        '����            :�^�C�g���\��擾����
        '����            :�Ȃ�
        '�߂�l          :Boolean(����True/�G���[False)
        '                 �O�����ʕϐ�:pAPPTITLE�Ƀ^�C�g���\�蕶���񂪓���
        '------------------------------------------------------------------
        Public Function f_Title_Get() As Boolean

            Dim sSql As String = String.Empty
            Dim dstDataSet As New DataSet

            f_Title_Get = False

            Try
                pAPPTITLE = ""

                If Trim(pAPP) = "" Then
                    ''Show_MessageBox("�v���O�����h�c���w�肳��Ă��܂���B", C_MSGICON_ERROR)
                    pAPPTITLE = "ID���w��"
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
                            '���R�[�h�Ȃ�
                            ''Show_MessageBox("000004", "") '�Y���f�[�^�����݂��܂���B
                            pAPPTITLE = "DB���o�^"
                        End If
                    End With

                    f_Title_Get = True
                End If

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
            End Try

        End Function

        '------------------------------------------------------------------
        '�v���V�[�W����  :f_SyoriYmdw_Get
        '����            :�^�C�g�����t�����擾����
        '����            :�Ȃ�
        '�߂�l          :String(�^�C�g���G���A�ɕ\��������t������)
        '------------------------------------------------------------------
        Public Function f_SyoriYmdw_Get() As String
            Dim sWeek As String = ""
            Dim dSysdate As Date = System.DateTime.Now

            f_SyoriYmdw_Get = ""

            Try

                ' �V�X�e�����t����їj����\������
                Select Case Weekday(dSysdate)
                    Case FirstDayOfWeek.Sunday
                        sWeek = "��"
                    Case FirstDayOfWeek.Monday
                        sWeek = "��"
                    Case FirstDayOfWeek.Tuesday
                        sWeek = "��"
                    Case FirstDayOfWeek.Wednesday
                        sWeek = "��"
                    Case FirstDayOfWeek.Thursday
                        sWeek = "��"
                    Case FirstDayOfWeek.Friday
                        sWeek = "��"
                    Case FirstDayOfWeek.Saturday
                        sWeek = "�y"
                    Case Else
                        sWeek = ""
                End Select

                f_SyoriYmdw_Get = Format(dSysdate, "yyyy�NM��d��") & "�i" & sWeek & "�j"

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
            End Try

        End Function

        '------------------------------------------------------------------
        '�v���V�[�W����  :f_KikinFlg_Get
        '����            :�^�C�g���\��擾����
        '����            :�Ȃ�
        '�߂�l          :Boolean(����True/�G���[False)
        '                 �O�����ʕϐ�:pAPPTITLE�Ƀ^�C�g���\�蕶���񂪓���
        '------------------------------------------------------------------
        Public Function f_KikinFlg_Get() As Boolean
            Dim ret As Boolean = False
            Dim wSql As String = String.Empty
            Dim wkDS As New DataSet

            Try

                '�����l
                pKikin2 = False

                '�R�[�h�}�X�^����
                wSql = "SELECT MEISYO_CD FROM TM_CODE " & _
                        "WHERE SYURUI_KBN = 0" & _
                        "  AND MEISYO_CD = 99"

                'DB����f�[�^���擾
                If f_Select_ODP(wkDS, wSql) = False Then
                    Exit Try
                End If

                '�f�[�^�L�͑�Q���
                If wkDS.Tables(0).Rows.Count > 0 Then
                    pKikin2 = True
                End If

                ret = True

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
            End Try

            Return ret

        End Function

#End Region

#Region "���샍�O�o�͊֘A"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Title_Get
        '����            :���샍�O�o�͏���
        '����            :1.intKaisiSyuryoFlg  �J�n�E�I���t���O(0:�J�n 1:�I��)
        '*                2.strTableName    �e�[�u����
        '*                3.strCriteria     Optional    Where��
        '*                4.strFields       Optional    ����
        '�߂�l          :Boolean(����True/�G���[False)
        '                 �O�����ʕϐ�:pAPPTITLE�Ƀ^�C�g���\�蕶���񂪓���
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
            Dim sREG_ID As String = pLOGINUSERID        '2010/11/10 ADD JBD200 �o�f�h�c���烍�O�C�����[�U�h�c�ɕύX
            Dim sCOM_NAME As String = ""

            'Dim dstDataSet As New DataSet

            Try

                '�X�g�A�h�v���V�[�W���̌Ăяo��
                Cmd.Connection = Cnn.db.Connection
                Cmd.CommandType = CommandType.StoredProcedure
                '
                Cmd.CommandText = "PKG_SYORI_RIREKI.SYORI_RIREKI_INS"

                '�����n��
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

                '�߂�
                Dim p_MSGCD As OracleParameter = Cmd.Parameters.Add("OU_MSGCD", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)
                Dim p_MSGNM As OracleParameter = Cmd.Parameters.Add("OU_MSGNM", OracleDbType.Varchar2, 255, DBNull.Value, ParameterDirection.Output)

                Cmd.ExecuteNonQuery()
                Debug.Print(Cmd.Parameters("OU_MSGCD").Value.ToString())

                '�f�[�^�x�[�X�ւ̐ڑ������
                If Not Cmd Is Nothing Then
                    Cmd.Dispose()
                End If

                blnErr = False          '�G���[�Ȃ�

                ret = True

            Catch ex As Exception
                '���ʗ�O����
                If ex.Message <> "Err" Then
                    'Show_MessageBox("", ex.Message)
                End If
            Finally
                '�G���[�L��̎��A���[���o�b�N
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

#Region "f_Output_Excel Excel�o�͏���"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Output_Excel
        '����            :CSV�o�͏���
        '����            :�Ȃ�
        '�߂�l          :Boolean(����True/�G���[False)
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


                        '�V�[�g��2�s�ڂ���f�[�^���o�͂���i�������j
                        pRow = 2

                        '----- (6)�u�b�N��ۑ����܂� -----
                        '�t�@�C���ۑ�/���������
                        If Not f_XlsFileSave(strOutPath) Then
                            Exit Try
                        End If

                        '----- (1)�V�����u�b�N�̍쐬 -----

                        ''�J�n���Ԃ̎擾
                        'pUKEIRE_YMDHMS = Now.ToString


                        '�o�͌����̏�����
                        pCNT = 0

                        blnExist = False
                        ''������Template�t�@�C�����Excel�t�@�C�����쐬���I�[�v��
                        'If f_ExcelMake_KEN(dstDataSet, strKENCD, strOutPath, newErr) Then
                        '    blnExist = True
                        'End If

                        '----- (4)���׃f�[�^���V�[�g�֏o�� -----
                        If blnExist Then
                            dRow = dstDataSet.Tables(0).Rows(i)

                            If Not f_SetExcelData(dRow) Then
                                Exit Try
                            End If

                            pRow += 1
                        End If
                    Next

                    If blnExist Then
                        '----- (7)�܂��Ō�̃u�b�N�͕ۑ�����Ă��Ȃ��̂ŁA�ۑ��E������܂� -----
                        '�Ō�̌��R�[�h�̃t�@�C���ۑ�/���������
                        If Not f_XlsFileSave(strOutPath) Then
                            Exit Try
                        End If

                    End If
                    dstDataSet.Clear()
                    dstDataSet.Dispose()

                Else
                    '�G���[���X�g�o�͂Ȃ�
                    'Show_MessageBox("I002", "") '�Y���f�[�^�����݂��܂���B
                    Exit Try
                End If

                ret = True

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
                xl.xlCloseComObject()
                '��������������܂�
                Call s_GC_Dispose()
            End Try

            Return ret

        End Function
#End Region

#Region "f_SetExcelData Excel�o�͗p�f�[�^�쐬"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_SetExcelData
        '����            :Excel�o�͗p�f�[�^�쐬
        '����            :�Ȃ�
        '�߂�l          :String(SQL��)
        '------------------------------------------------------------------
        Private Function f_SetExcelData(ByVal dRow As DataRow) As Boolean
            Dim ret As Boolean = False

            Try

                '�Z���Ƀf�[�^���쐬 �Z�b�g��)xl.SetdataCell(�s�ԍ�, �Z���ԍ�, ���e)

                xl.SetdataCell(pRow, 1, dRow("SNKCD"))      '�Ώې��Y�Ҕԍ�
                xl.SetdataCell(pRow, 2, dRow("SNKNM"))      '�Ώې��Y�Җ�
                xl.SetdataCell(pRow, 3, dRow("JYUFUKU"))    '�d���t���O
                xl.SetdataCell(pRow, 4, dRow("CD"))         '�Ǘ��Ҕԍ�
                xl.SetdataCell(pRow, 5, dRow("NAME"))       '�Ǘ��Җ�
                xl.SetdataCell(pRow, 6, dRow("ITKCD"))      '�����ϑ���R�[�h
                xl.SetdataCell(pRow, 7, dRow("ITKNM"))      '�����ϑ��於

                pCNT += 1       '�Q���Ґ����J�E���g

                ret = True

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
            End Try

            Return ret

        End Function
#End Region

#Region "f_XlsFileSave �t�@�C���ۑ��A���������"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_XlsFileSave
        '����            :�t�@�C���ۑ��A���������
        '����            :strOutPath  �Ώۃt�@�C���p�X
        '�߂�l          :boolean(True:����I��/False:�ُ�I��)
        '------------------------------------------------------------------
        Private Function f_XlsFileSave(ByVal strOutPath As String) As Boolean
            Dim ret As Boolean = False

            Try
                '����Excel�t�@�C���쐬�������s���Ă���ꍇ�͎��̌��̏������s���O��
                '�t�@�C����ۑ�

                '�ۑ�����O�ɐ擪�̃e���v���[�g�V�[�g���폜����
                xl.WorkSheetDelete(1)
                '==�ۑ�����==
                xl.xlSaveWorkBook(strOutPath)
                '==�I�u�W�F�N�g�̉��==
                xl.xlCloseComObject()

                ret = True

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
            End Try

            Return ret

        End Function
#End Region

#Region "FROM�`TO���쐧��"

        '------------------------------------------------------------------
        '�v���V�[�W����  :s_From_Validating
        '����            :FROM�`TO���ڂ�FROM�����쐧��i�Ή��I�u�W�F�N�g�FGcString,GcNumber�j
        '                 FROM�����ڂ�Validating��Call����
        '����            :1.txtFrom     Object       FROM���I�u�W�F�N�g
        '                 2.txtTo       Object       TO���I�u�W�F�N�g
        '�߂�l          :����
        '------------------------------------------------------------------
        Public Sub s_From_Validating(ByVal txtFrom As Object, ByVal txtTo As Object)

            Select Case TypeName(txtFrom)

                Case "GcString"
                    '÷���ޯ��

                    If txtFrom.Text = "" Then
                        'FM�����͂�TO�����͂�������
                        If txtTo.Text <> "" Then
                            txtTo.Text = ""
                        End If
                        Exit Sub
                    End If

                    'FROM���͂�TO�������͂�������
                    If txtTo.Text = "" Then
                        'TO��FROM�̓��e���Z�b�g
                        txtTo.Text = txtFrom.Text
                    End If

                Case "GcNumber"
                    '���l�^

                    '��***** 2011/06/27 JBD200 ZERO�͖����͂Ɣ��f����̂ł͂Ȃ����͉\�Ƃ���悤�ύX *****��
                    'If txtFrom.Text = "" Or txtFrom.Text = "0" Then
                    '    'FM�����͂�TO�����͂�������
                    '    If txtTo.Text <> "" And txtTo.Text <> "0" Then
                    '        txtTo.Text = ""
                    '    End If
                    '    Exit Sub
                    'End If

                    ''FROM���͂�TO�������͂�������
                    'If txtTo.Text = "" Or txtTo.Text = "0" Then
                    '    'TO��FROM�̓��e���Z�b�g
                    '    txtTo.Text = txtFrom.Text
                    'End If

                    If txtFrom.Text = "" Then
                        'FM�����͂�TO�����͂�������
                        If txtTo.Text <> "" Then
                            txtTo.Text = ""
                        End If
                        Exit Sub
                    End If

                    'FROM���͂�TO�������͂�������
                    If txtTo.Text = "" Then
                        'TO��FROM�̓��e���Z�b�g
                        txtTo.Text = txtFrom.Text
                    End If
                '��***** 2011/06/27 JBD200 ZERO�͖����͂Ɣ��f����̂ł͂Ȃ����͉\�Ƃ���悤�ύX *****��

                Case "GcDate"
                    '���t�^

                    If txtFrom.Value Is Nothing Then
                        'FM�����͂�TO�����͂�������
                        If Not txtTo.Value Is Nothing Then
                            txtTo.Text = txtFrom.Text
                        End If
                        Exit Sub
                    End If

                    'FROM���͂�TO�������͂�������
                    If txtTo.Value Is Nothing Then
                        'TO��FROM�̓��e���Z�b�g
                        txtTo.Text = txtFrom.Text
                    End If

            End Select

        End Sub

        '------------------------------------------------------------------
        '�v���V�[�W����  :s_To_Validating
        '����            :FROM�`TO���ڂ�TO�����쐧��i�Ή��I�u�W�F�N�g�FGcString,GcNumber�j
        '                 TO�����ڂ�Validating��Call����
        '����            :1.txtTo     Object       TO���I�u�W�F�N�g
        '                 2.txtFrom   Object       FROM���I�u�W�F�N�g
        '�߂�l          :����
        '------------------------------------------------------------------
        Public Sub s_To_Validating(ByVal txtTo As Object, ByVal txtFrom As Object)

            Select Case TypeName(txtTo)

                Case "GcString"
                    '÷���ޯ��

                    If txtTo.Text = "" Then
                        If txtFrom.Text <> "" Then
                            'TO�����͂�FROM�����͂��������AFROM�̓��e��TO�ɃZ�b�g
                            txtTo.Text = txtFrom.Text
                        End If
                        Exit Sub
                    End If

                    If txtFrom.Text <> "" Then
                        'TO���͂�FROM�����͂��������A���������X���[����
                    Else
                        'TO���͂�FROM�������͂��������ATO�̓��e��FROM�ɃZ�b�g
                        txtFrom.Text = txtTo.Text
                    End If

                Case "GcNumber"
                    '���l�^
                    '��***** 2011/06/27 JBD200 ZERO�͖����͂Ɣ��f����̂ł͂Ȃ����͉\�Ƃ���悤�ύX *****��
                    'If txtTo.Text = "" Or txtTo.Text = "0" Then
                    '    If txtFrom.Text <> "" And txtFrom.Text <> "0" Then
                    '        'TO�����͂�FROM�����͂��������AFROM�̓��e��TO�ɃZ�b�g
                    '        txtTo.Text = txtFrom.Text
                    '    End If
                    '    Exit Sub
                    'End If

                    'If txtFrom.Text <> "" And txtFrom.Text <> "0" Then
                    '    'TO���͂�FROM�����͂��������A���������X���[����
                    'Else
                    '    'TO���͂�FROM�������͂��������ATO�̓��e��FROM�ɃZ�b�g
                    '    txtFrom.Text = txtTo.Text
                    'End If

                    If txtTo.Text = "" Then
                        If txtFrom.Text <> "" Then
                            'TO�����͂�FROM�����͂��������AFROM�̓��e��TO�ɃZ�b�g
                            txtTo.Text = txtFrom.Text
                        End If
                        Exit Sub
                    End If

                    If txtFrom.Text <> "" Then
                        'TO���͂�FROM�����͂��������A���������X���[����
                    Else
                        'TO���͂�FROM�������͂��������ATO�̓��e��FROM�ɃZ�b�g
                        txtFrom.Text = txtTo.Text
                    End If
                '��***** 2011/06/27 JBD200 ZERO�͖����͂Ɣ��f����̂ł͂Ȃ����͉\�Ƃ���悤�ύX *****��

                Case "GcDate"
                    '���t�^

                    If txtTo.Value Is Nothing Then
                        If Not txtFrom.Value Is Nothing Then
                            'TO�����͂�FROM�����͂��������AFROM�̓��e��TO�ɃZ�b�g
                            txtTo.Text = txtFrom.Text
                        End If
                        Exit Sub
                    End If

                    If Not txtFrom.Value Is Nothing Then
                        'TO���͂�FROM�����͂��������A���������X���[����
                    Else
                        'TO���͂�FROM�������͂��������ATO�̓��e��FROM�ɃZ�b�g
                        txtFrom.Text = txtTo.Text
                    End If

            End Select

        End Sub

        '------------------------------------------------------------------
        '�v���V�[�W����  :s_CboFrom_Validating
        '����            :FROM�`TO���ڂ�FROM�����쐧��i�Ή��I�u�W�F�N�g�FGcComboBox�j
        '                 FROM�����ڂ�Validating��Call����
        '����            :1.cboCdFrom       Object       FROM���R�[�h�R���{�I�u�W�F�N�g
        '                 2.cboMeiFrom      Object       FROM�����̃R���{�I�u�W�F�N�g
        '                 3.cboCdTo         Object       TO���R�[�h�R���{�I�u�W�F�N�g
        '                 4.cboMeiTo        Object       TO�����̃R���{�I�u�W�F�N�g
        '                 5.strCharNumFlg   String       ���l�E�����t���O("0":���l(�ȗ�������)(Long�^) "1":���� "2":���l(Decimal�^))
        '�߂�l          :����
        '------------------------------------------------------------------
        Public Sub s_CboFrom_Validating(ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object, ByVal cboCdTo As Object, ByVal cboMeiTo As Object, ByVal strCharNumFlg As String)
            Dim strFmtwk As String = "0"
            Dim strFmt As String

            If cboCdFrom.Text = "" Then
                'FM�����͂�TO�����͂�������
                If cboCdTo.Text <> "" Then
                    cboCdTo.SelectedIndex = -1
                End If
                Exit Sub
            End If

            '�R�[�h�̂P���ڂ�0�̏ꍇ�͂O���폜
            'If Mid(cboCdFrom.Text, 1, 1) = 0 Then
            '    cboCdFrom.Text = Mid(cboCdFrom.Text, 2, 1)
            '    Exit Sub
            'End If
            If strCharNumFlg = "1" Then
                'DB���ڂ�����
                strFmt = strFmtwk.PadRight(cboCdFrom.MaxLength, "0")
                cboCdFrom.Text = Format(CLng(cboCdFrom.Text), strFmt)
                cboCdFrom.SelectedValue = Format(CLng(cboCdFrom.Text), strFmt)  '2015/03/03 JBD368 ADD

                '2015/03/03 JBD368 ADD �������ݒ�l��Decimal�^�̏ꍇ���l��
            ElseIf strCharNumFlg = "2" Then

                'DB���ڂ����l(Decimal�^)
                cboCdFrom.Text = CDec(cboCdFrom.Text)
                cboCdFrom.SelectedValue = CDec(cboCdFrom.Text)
                '2015/03/03 JBD368 ADD ������
            Else
                'DB���ڂ����l(Long�^)
                cboCdFrom.Text = CLng(cboCdFrom.Text)
                cboCdFrom.SelectedValue = cboCdFrom.Text  '2015/03/03 JBD368 ADD
            End If

            'cboCdFrom.SelectedValue = cboCdFrom.Text     '2015/03/03 JBD368 DEL �^�ɂ����SelectedValue��ݒ�l��ύX���邽�ߍ폜

            If cboCdFrom.SelectedValue Is Nothing Then
                cboCdFrom.SelectedIndex = -1
                cboMeiFrom.SelectedIndex = -1
                'Show_MessageBox_Add("W012", cboCdFrom.Tag) '�w�肳�ꂽ@0������������܂���B
                cboCdFrom.Focus()
            Else
                'FROM���͂�TO�������͂�������
                If cboCdTo.Text = "" Then
                    cboCdTo.SelectedValue = cboCdFrom.Text
                End If
            End If

        End Sub

        Public Sub s_CboFrom_Validating(ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object, ByVal cboCdTo As Object, ByVal cboMeiTo As Object)

            Call s_CboFrom_Validating(cboCdFrom, cboMeiFrom, cboCdTo, cboMeiTo, "0")

        End Sub


        '------------------------------------------------------------------
        '�v���V�[�W����  :s_CboTo_Validating
        '����            :FROM�`TO���ڂ�TO�����쐧��i�Ή��I�u�W�F�N�g�FGcComboBox�j
        '                 TO�����ڂ�Validating��Call����
        '����            :1.cboCdTo         Object       TO���R�[�h�R���{�I�u�W�F�N�g
        '                 2.cboMeiTo        Object       TO�����̃R���{�I�u�W�F�N�g
        '                 3.cboCdFrom       Object       FROM���R�[�h�R���{�I�u�W�F�N�g
        '                 4.cboMeiFrom      Object       FROM�����̃R���{�I�u�W�F�N�g
        '                 5.strCharNumFlg   String       ���l�E�����t���O("0":���l(�ȗ�������)(Long�^) "1":���� "2":���l(Decimal�^))
        '�߂�l          :����
        '------------------------------------------------------------------
        Public Sub s_CboTo_Validating(ByVal cboCdTo As Object, ByVal cboMeiTo As Object, ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object, ByVal strCharNumFlg As String)
            Dim strFmtwk As String = "0"
            Dim strFmt As String

            If cboCdTo.Text = "" Then
                If cboCdFrom.Text <> "" Then
                    'TO�����͂�FROM�����͂��������AFROM�̓��e��TO�ɃZ�b�g
                    '��2018/06/27 �C��
                    'cboCdTo.SelectedValue = cboCdFrom.Text
                    If strCharNumFlg = "1" Then
                        'DB���ڂ�����
                        strFmt = strFmtwk.PadRight(cboCdFrom.MaxLength, "0")
                        cboCdTo.SelectedValue = Format(CLng(cboCdFrom.Text), strFmt)
                    ElseIf strCharNumFlg = "2" Then
                        'DB���ڂ����l(Decimal�^)
                        cboCdTo.SelectedValue = CDec(cboCdFrom.Text)
                    Else
                        'DB���ڂ����l(Long�^)
                        cboCdTo.SelectedValue = cboCdFrom.Text
                    End If
                    '��2018/06/27 �C��
                End If
                Exit Sub
            End If

            '�R�[�h�̂P���ڂ�0�̏ꍇ�͂O���폜
            'If Mid(cboCdTo.Text, 1, 1) = 0 Then
            '    cboCdTo.Text = Mid(cboCdTo.Text, 2, 1)
            '    Exit Sub
            'End If
            'cboCdTo.Text = CLng(cboCdTo.Text)
            If strCharNumFlg = "1" Then
                'DB���ڂ�����
                strFmt = strFmtwk.PadRight(cboCdFrom.MaxLength, "0")
                cboCdTo.Text = Format(CLng(cboCdTo.Text), strFmt)
                cboCdTo.SelectedValue = Format(CLng(cboCdTo.Text), strFmt)  '2015/03/03 JBD368 ADD

                '2015/03/03 JBD368 ADD ������ �ݒ�l��Decimal�^�̏ꍇ���l��
            ElseIf strCharNumFlg = "2" Then

                'DB���ڂ����l(Decimal�^)
                cboCdTo.Text = CDec(cboCdTo.Text)
                cboCdTo.SelectedValue = CDec(cboCdTo.Text)
                '2015/03/03 JBD368 ADD ������
            Else
                'DB���ڂ����l(Long�^)
                cboCdTo.Text = CLng(cboCdTo.Text)
                cboCdTo.SelectedValue = cboCdTo.Text      '2015/03/03 JBD368 ADD
            End If

            'cboCdTo.SeletedItem.Value = cboCdTo.Text            '2015/03/03 JBD368 DEL �^�ɂ����SelectedValue��ݒ�l��ύX���邽�ߍ폜

            If cboCdTo.SelectedValue Is Nothing Then
                cboCdTo.SelectedIndex = -1
                cboMeiTo.SelectedIndex = -1
                'Show_MessageBox_Add("W012", cboCdFrom.Tag) '�w�肳�ꂽ@0������������܂���B

                cboCdTo.Focus()
            Else
                If cboCdFrom.Text <> "" Then
                    'TO���͂�FROM�����͂��������A���������X���[
                Else
                    'TO���͂�FROM�������͂��������ATO�̓��e��FROM�ɃZ�b�g
                    cboCdFrom.SelectedValue = cboCdTo.Text
                End If
            End If

        End Sub

        Public Sub s_CboTo_Validating(ByVal cboCdTo As Object, ByVal cboMeiTo As Object, ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object)

            Call s_CboTo_Validating(cboCdTo, cboMeiTo, cboCdFrom, cboMeiFrom, "0")

        End Sub

        '------------------------------------------------------------------
        '�v���V�[�W����  :s_CboMeiFrom_SelectedIndexChanged
        '����            :FROM�`TO���ڂ�FROM�����̃R���{���쐧��i�Ή��I�u�W�F�N�g�FGcComboBox�j
        '                 FROM�����̃R���{���ڂ�Validating��Call����
        '����            :1.cboMeiFrom      Object       FROM�����̃R���{�I�u�W�F�N�g
        '                 2.cboCdFrom       Object       FROM���R�[�h�R���{�I�u�W�F�N�g
        '                 3.cboMeiTo        Object       TO�����̃R���{�I�u�W�F�N�g
        '                 4.cboCdTo         Object       TO���R�[�h�R���{�I�u�W�F�N�g
        '�߂�l          :����
        '------------------------------------------------------------------
        Public Sub s_CboMeiFrom_SelectedIndexChanged(ByVal cboMeiFrom As Object, ByVal cboCdFrom As Object, ByVal cboMeiTo As Object, ByVal cboCdTo As Object)

            cboCdFrom.SelectedIndex = cboMeiFrom.SelectedIndex

            If cboCdFrom.Text = "" Then
                'FM�����͂�TO�����͂�������
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
        '�v���V�[�W����  :s_CboMeiTo_Validating
        '����            :FROM�`TO���ڂ�TO�����쐧��i�Ή��I�u�W�F�N�g�FGcComboBox�j
        '                 TO�����ڂ�Validating��Call����
        '����            :1.cboMeiTo    Object       TO�����̃R���{�I�u�W�F�N�g
        '                 2.cboCdTo     Object       TO���R�[�h�R���{�I�u�W�F�N�g
        '                 3.cboMeiFrom  Object       FROM�����̃R���{�I�u�W�F�N�g
        '                 4.cboCdFrom   Object       FROM���R�[�h�R���{�I�u�W�F�N�g
        '�߂�l          :����
        '------------------------------------------------------------------
        Public Sub s_CboMeiTo_Validating(ByVal cboMeiTo As Object, ByVal cboCdTo As Object, ByVal cboMeiFrom As Object, ByVal cboCdFrom As Object)

            cboCdTo.SelectedIndex = cboMeiTo.SelectedIndex

            If cboCdTo.Text = "" Then
                'If cob_KenCdFm.Text <> "" Then
                '    'TO�����͂�FROM�����͂��������AFROM�̓��e��TO�ɃZ�b�g
                '    cob_KenCdTo.SelectedIndex = cob_KenCdFm.SelectedIndex
                'End If
                Exit Sub
            End If

            If cboCdFrom.Text <> "" Then
                'TO���͂�FROM�����͂��������A���������X���[
            Else
                'TO���͂�FROM�������͂��������ATO�̓��e��FROM�ɃZ�b�g
                cboCdFrom.SelectedIndex = cboCdTo.SelectedIndex
            End If

        End Sub

#End Region

#Region "f_Daisyo_Check �召�`�F�b�N"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Daisyo_Check
        '����            :FROM-TO���ړ��e�召�`�F�b�N
        '����            :objCtrlFrom(FROM����޼ު��)
        '                 objCtrlTo(TO����޼ު��)
        '                 strKoumokuNm(�װү���ޕ\�����̍��ږ�)
        '                 MsgDsp(���b�Z�[�W�\���L��)
        '                 intZokusei(���ڑ��� 0:String����(���l�ȊO�̕�������͉�) 1:Number����(���l�ȊO�̕����͓��͕s��) 
        '                                     2:Date����  3:Number����(0�͓��͂Ƃ݂Ȃ�)
        '�߂�l          :Boolean(����True/�G���[False)
        '�C����          :2014/08/11
        '------------------------------------------------------------------
        Public Function f_Daisyo_Check(ByVal objCtrlFrom As Object, ByVal objCtrlTo As Object, ByVal strKoumokuNm As String,
                                        ByVal MsgDsp As Boolean, Optional ByVal intZokusei As Integer = 0) As Boolean
            Dim ret As Boolean = False

            Try

                Select Case TypeName(objCtrlFrom)
                    Case "GcString", "GcComboBox"
                        'FROM���͂Ȃ�
                        If (objCtrlFrom.Text Is Nothing OrElse objCtrlFrom.Text.TrimEnd = "") AndAlso
                            (Not objCtrlTo.Text Is Nothing AndAlso objCtrlTo.Text.TrimEnd <> "") Then
                            If MsgDsp Then
                                'Show_MessageBox_Add("W008", strKoumokuNm & "From") '@0�͕K�{���͍��ڂł��B
                            End If
                            objCtrlFrom.Focus()
                            Exit Try
                        End If

                        'TO���͂Ȃ�
                        If (objCtrlTo.Text Is Nothing OrElse objCtrlTo.Text.TrimEnd = "") AndAlso
                            (Not objCtrlFrom.Text Is Nothing AndAlso objCtrlFrom.Text.TrimEnd <> "") Then
                            If MsgDsp Then
                                'Show_MessageBox_Add("W008", strKoumokuNm & "To")    '@0�͕K�{���͍��ڂł��B
                            End If
                            objCtrlFrom.Focus()
                            Exit Try
                        End If

                        '�召�`�F�b�N
                        If objCtrlFrom.Text Is Nothing AndAlso objCtrlTo.Text Is Nothing Then
                        Else
                            If (Not objCtrlFrom.Text Is Nothing AndAlso objCtrlFrom.Text.TrimEnd <> "") AndAlso
                                (Not objCtrlTo.Text Is Nothing AndAlso objCtrlTo.Text.TrimEnd <> "") Then       '2010/11/24 UPD JBD200 ��r�����C��
                                If intZokusei = 1 Then
                                    If CDec(objCtrlFrom.Text.ToString.TrimEnd) > CDec(objCtrlTo.Text.ToString.TrimEnd) Then     '2010/11/24 UPD JBD200 TEXT�𐔒l�ɕϊ����Ĕ�r����悤�C��
                                        If MsgDsp Then
                                            'Show_MessageBox_Add("W003", "�w�肳�ꂽ" & strKoumokuNm)    '@0�͈͎̔w�肪����������܂���B
                                        End If
                                        objCtrlFrom.Focus()
                                        Exit Try
                                    End If
                                Else
                                    If objCtrlFrom.Text > objCtrlTo.Text Then
                                        If MsgDsp Then
                                            'Show_MessageBox_Add("W003", "�w�肳�ꂽ" & strKoumokuNm)    '@0�͈͎̔w�肪����������܂���B
                                        End If
                                        objCtrlFrom.Focus()
                                        Exit Try
                                    End If
                                End If
                            End If
                        End If

                    Case "GcDate"
                        'FROM���͂Ȃ�
                        If objCtrlFrom.value Is Nothing AndAlso Not objCtrlTo.value Is Nothing Then
                            If MsgDsp Then
                                'Show_MessageBox_Add("W008", strKoumokuNm & "From") '@0�͕K�{���͍��ڂł��B
                            End If
                            objCtrlFrom.Focus()
                            Exit Try
                        End If

                        'TO���͂Ȃ�
                        If objCtrlTo.value Is Nothing AndAlso Not objCtrlFrom.value Is Nothing Then
                            If MsgDsp Then
                                'Show_MessageBox_Add("W008", strKoumokuNm & "To")    '@0�͕K�{���͍��ڂł��B
                            End If
                            objCtrlFrom.Focus()
                            Exit Try
                        End If

                        '�召�`�F�b�N
                        If objCtrlFrom.value Is Nothing AndAlso objCtrlTo.value Is Nothing Then
                        Else
                            If objCtrlFrom.Value > objCtrlTo.Value Then
                                If MsgDsp Then
                                    'Show_MessageBox_Add("W003", "�w�肳�ꂽ" & strKoumokuNm)    '@0�͈͎̔w�肪����������܂���B
                                End If
                                objCtrlFrom.Focus()
                                Exit Try
                            End If
                        End If

                    Case "GcNumber"
                        '0���͂n�j
                        If intZokusei = 3 Then
                            'FROM���͂Ȃ�
                            If (objCtrlFrom.Value Is Nothing) AndAlso Not (objCtrlTo.Value Is Nothing) Then
                                If MsgDsp Then
                                    'Show_MessageBox_Add("W008", strKoumokuNm & "From") '@0�͕K�{���͍��ڂł��B
                                End If
                                objCtrlFrom.Focus()
                                Exit Try
                            End If

                            'TO���͂Ȃ�
                            If Not (objCtrlFrom.Value Is Nothing) AndAlso (objCtrlTo.Value Is Nothing) Then
                                If MsgDsp Then
                                    'Show_MessageBox_Add("W008", strKoumokuNm & "To")    '@0�͕K�{���͍��ڂł��B
                                End If
                                objCtrlTo.Focus()
                                Exit Try
                            End If

                            '�召�`�F�b�N
                            If (objCtrlFrom.Value Is Nothing AndAlso objCtrlTo.Value Is Nothing) Then
                            Else
                                If objCtrlFrom.Value > objCtrlTo.Value Then
                                    If MsgDsp Then
                                        'Show_MessageBox_Add("W003", "�w�肳�ꂽ" & strKoumokuNm)    '@0�͈͎̔w�肪����������܂���B
                                    End If
                                    objCtrlFrom.Focus()
                                    Exit Try
                                End If
                            End If
                        Else
                            '0���͖͂����͂Ƃ݂Ȃ�
                            'FROM���͂Ȃ�
                            If (objCtrlFrom.Value Is Nothing OrElse objCtrlFrom.Value = 0) AndAlso
                                (Not objCtrlTo.Value Is Nothing AndAlso objCtrlTo.Value <> 0) Then
                                If MsgDsp Then
                                    'Show_MessageBox_Add("W008", strKoumokuNm & "From") '@0�͕K�{���͍��ڂł��B
                                End If
                                objCtrlFrom.Focus()
                                Exit Try
                            End If

                            'TO���͂Ȃ�
                            If (objCtrlTo.Value Is Nothing OrElse objCtrlTo.Value = 0) AndAlso
                                (Not objCtrlFrom.Value Is Nothing AndAlso objCtrlFrom.Value <> 0) Then
                                If MsgDsp Then
                                    'Show_MessageBox_Add("W008", strKoumokuNm & "To")    '@0�͕K�{���͍��ڂł��B
                                End If
                                objCtrlTo.Focus()
                                Exit Try
                            End If

                            '�召�`�F�b�N
                            If (objCtrlFrom.Value Is Nothing OrElse objCtrlFrom.Value = 0) AndAlso
                                (objCtrlTo.Value Is Nothing OrElse objCtrlTo.Value = 0) Then
                            Else
                                If objCtrlFrom.Value > objCtrlTo.Value Then
                                    If MsgDsp Then
                                        'Show_MessageBox_Add("W003", "�w�肳�ꂽ" & strKoumokuNm)    '@0�͈͎̔w�肪����������܂���B
                                    End If
                                    objCtrlFrom.Focus()
                                    Exit Try
                                End If
                            End If
                        End If

                End Select

                ret = True

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
            End Try

            Return ret

        End Function

#End Region

#Region "** ���̑����� ***"
#Region "s_GC_Dispose �������̉��"
        '------------------------------------------------------------------
        '�v���V�[�W����  :s_GC_Dispose
        '����            :�������̉��
        '����            :�Ȃ�
        '�߂�l          :Boolean(����True/�G���[False)
        '------------------------------------------------------------------
        Public Sub s_GC_Dispose()

            Try
                ' �K�x�[�W�R���N�V���������s���܂��B
                System.GC.Collect()
                ' �t�@�C�i���C�[�[�V�������I���܂ŃX���b�h�ҋ@���܂��B
                System.GC.WaitForPendingFinalizers()

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
            End Try

        End Sub
#End Region

#Region "f_ReportPath_Check ���|�[�g�o�͗p�p�X��������"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_ReportPath_Check
        '����            :���|�[�g�o�͗p�p�X��������
        '����            :1.OutKbn      Integer         �o�͊g���q�敪(0:PDF,1:XLS)
        '                 2.strPath     String          �o�̓p�X
        '                 3.strFileName String          �o�̓t�@�C����
        '�߂�l          :Boolean(����True/�G���[False)
        '------------------------------------------------------------------
        Public Function f_ReportPath_Check(ByRef strOutputPath As String, _
                                            ByVal OutKbn As Integer, _
                                            ByVal strPath As String, _
                                            ByVal strFileName As String) As Boolean


            Dim ret As Boolean = False
            Dim strEX As String = String.Empty

            Try
                '�g���q�̐ݒ�
                If OutKbn = 0 Then
                    'PDF
                    strEX = ".pdf"
                Else
                    'Excel
                    strEX = ".xls"
                End If

                '�t�@�C�����ݒ�
                strFileName += Now.ToString("yyyyMMddHHmmss") & strEX

                '�t�H���_��������
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
                    ' �t�@�C�������ݒ肳��Ă��Ȃ��ꍇ�A�G���[���b�Z�[�W�\��
                    'Call 'Show_MessageBox_Add("W009", " " & strPath & "��")          '@0�o�͐悪���݂��܂���B
                    'Call 'Show_MessageBox(strPath & "�̏o�͐悪���݂��܂���B", C_MSGICON_WARNING)          '@0�o�͐悪���݂��܂���B
                    Exit Try
                End If


                If Microsoft.VisualBasic.Right(strPath, 1) = "\" Then
                    strOutputPath = strPath & strFileName
                Else
                    strOutputPath = strPath & "\" & strFileName
                End If


                '�����t�@�C����������
                If Not f_FileExist_Check(strOutputPath) Then
                    strOutputPath = ""
                    Exit Try
                End If

                ret = True

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
            End Try

            Return ret

        End Function


#End Region

#Region "f_DirectoryExist_Check �t�H���_��������"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_DirectoryExist_Check
        '����            :�t�H���_��������
        '����            :�Ȃ�
        '�߂�l          :Boolean(����True/�G���[False)
        '------------------------------------------------------------------
        Public Function f_DirectoryExist_Check(ByVal strPath As String) As Boolean

            Dim ret As Boolean = False

            Try

                '�t�H���_�̑�������
                If Microsoft.VisualBasic.Right(strPath, 1) = "\" Then
                    strPath = strPath.Substring(0, strPath.TrimEnd.Length - 1)
                End If

                If Not Directory.Exists(strPath) Then
                    'ini�ɐݒ肳��Ă���t�H���_�����݂��Ȃ��ꍇ�A�G���[���b�Z�[�W�\��
                    'Call 'Show_MessageBox_Add("W009", " " & strPath & "��")          '@0�o�͐悪���݂��܂���B
                    'Call 'Show_MessageBox(strPath & "�̏o�͐悪���݂��܂���B", C_MSGICON_WARNING)          '@0�o�͐悪���݂��܂���B
                    Exit Try
                End If

                ret = True

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
            End Try

            Return ret

        End Function


#End Region

#Region "f_FileExist_Check �����t�@�C����������"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_FileExist_Check
        '����            :�����t�@�C����������
        '����            :�Ȃ�
        '�߂�l          :Boolean(����True/�G���[False)
        '------------------------------------------------------------------
        Public Function f_FileExist_Check(ByVal strOutputPath As String) As Boolean

            Dim ret As Boolean = False

            Try

                '�����t�@�C����������
                If File.Exists(strOutputPath) Then
                    ' �t�@�C�������ɑ��݂���ꍇ�A�㏑�����邩�ǂ����m�F���܂��B
                    'If 'Show_MessageBox("Q010", "") = DialogResult.No Then     '���Ƀt�@�C�������݂��܂��B�㏑�����Ă���낵���ł����H
                    '    'If 'Show_MessageBox("���Ƀt�@�C�������݂��܂��B�㏑�����Ă���낵���ł����H", C_MSGICON_QUESTION) = DialogResult.No Then     '���Ƀt�@�C�������݂��܂��B�㏑�����Ă���낵���ł����H
                    '    Exit Try
                    'End If
                    ret = True
                Else
                    ret = False
                End If

                ret = True

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
                ''Show_MessageBox(ex.Message, C_MSGICON_ERROR)
            End Try

            Return ret

        End Function


#End Region

#Region "f_FileDialog �t�@�C���_�C�A���O�̕\��"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_FileDialog
        '����            :�t�@�C���_�C�A���O�̕\��
        '�����@�@�@�@�@�@:1. OutputMode    String  PDF�o�͂̏ꍇ:"pdf" Excel�o�͂̏ꍇ:"xls" CSV�o�͂̏ꍇ:"csv"
        '�@�@�@�@�@�@�@�@:2. fileNm(ByRef) String  [�Q�Ǝ�]���[ID & ���[�����Z�b�g [�߂�]�t�@�C�������܂ރp�X
        '�߂�l          :Boolean(����True/�G���[False)
        '------------------------------------------------------------------
        Public Function f_FileDialog(ByVal OutputMode As String, ByRef fileNm As String) As Boolean

            ' OpenFileDialog �̐V�����C���X�^���X�𐶐����� (�f�U�C�i����ǉ����Ă���ꍇ�͕K�v�Ȃ�)
            'Dim OpenFileDialog1 As New SaveFileDialog

            'Try
            '    OpenFileDialog1.Title = "���O��t���ĕۑ�"

            '    Select Case OutputMode
            '        Case "pdf"
            '            'PDF�o��

            '            '�����l�𐧌�}�X�^�ݒ�̃p�X�ɂ���B
            '            OpenFileDialog1.InitialDirectory = myREPORT_PDF_PATH
            '            '�t�@�C���̎�ނ�ݒ�
            '            OpenFileDialog1.Filter = "PDF�t�@�C��(*.pdf)|*.pdf"

            '        Case "xls"
            '            'Excel�o��

            '            '�����l�𐧌�}�X�^�ݒ�̃p�X�ɂ���B
            '            OpenFileDialog1.InitialDirectory = myREPORT_EXCEL_PATH
            '            '�t�@�C���̎�ނ�ݒ�
            '            OpenFileDialog1.Filter = "Excel 97-2003 �u�b�N(*.xls)|*.xls"


            '        Case "xlsx"         '2015/03/23 ADD Start
            '            'Excel�o��
            '            '�����l�𐧌�}�X�^�ݒ�̃p�X�ɂ���B
            '            OpenFileDialog1.InitialDirectory = myREPORT_EXCEL_PATH
            '            '�t�@�C���̎�ނ�ݒ�
            '            OpenFileDialog1.Filter = "Excel �u�b�N(*.xlsx)|*.xlsx"
            '            '2015/03/23 ADD End

            '        Case "csv"
            '            'CSV�o��

            '            '�����l�𐧌�}�X�^�ݒ�̃p�X�ɂ���B
            '            OpenFileDialog1.InitialDirectory = myREPORT_EXCEL_PATH
            '            '�t�@�C���̎�ނ�ݒ�
            '            OpenFileDialog1.Filter = "CSV�J���}��؂�(*.csv)|*.csv"


            '    End Select

            '    ' �����\������t�@�C������ݒ肷��(���[ID+���[��+yyyyMMddHHmmss[+.pdf/.xls])
            '    OpenFileDialog1.FileName = fileNm & Now.ToString("yyyyMMddHHmmss")

            '    '' �_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌����� (�����l False)
            '    OpenFileDialog1.RestoreDirectory = True
            '    '���[�U�[�����ɑ��݂���t�@�C�������w�肵���ꍇ�� [���O��t���ĕۑ�] �_�C�A���O �{�b�N�X�Ōx����\�����邩�ǂ����������l���擾�܂��͐ݒ肵�܂��B
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

#Region "f_GetDirectory ���|�[�g�o�͗p�f�B���N�g���[����"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_GetDirectory
        '����            :���|�[�g�o�͗p�f�B���N�g���[����
        '����            :ikbn      �����敪(0:PDF�o�� 1:Excel�o��)
        '                 newKENCD  ���R�[�h
        '�@             �@newPATH   �t�@�C���쐬�ꏊ��Path(ByRef)
        '               �@blnPath   ���R�[�h�t�H���_�����݂��Ȃ��ꍇ��False�@���݂���ꍇ��True
        '�߂�l          :Boolean(����True/�G���[False)
        '�C����          :2009/11/06
        '------------------------------------------------------------------
        Public Function f_GetDirectory(ByVal iKbn As Integer, ByVal newKENCD As Integer, ByRef newPATH As String, ByRef blnPath As Boolean) As Boolean
            Dim sSql As String = String.Empty
            Dim blnAnd As Boolean = False
            Dim strPath As String = String.Empty
            Dim ret As Boolean = False


            Try
                '����.�����敪�ɂ��擾����p�X�̓��e��ύX
                Select Case iKbn
                    Case 0
                        'PDF�p�p�X�擾
                        strPath = myREPORT_PDF_PATH
                    Case 1
                        'Excel�p�p�X�擾
                        strPath = myREPORT_EXCEL_PATH
                End Select

                If Microsoft.VisualBasic.Right(strPath, 1) = "\" Then
                    strPath = strPath.Substring(0, strPath.TrimEnd.Length - 1)
                End If


                '�o�͗p�p�X���݃`�F�b�N
                If Not f_DirectoryExist_Check(strPath) Then
                    blnPath = False
                    Exit Try
                Else
                    blnPath = True
                End If

                '�s���{���p�p�X���݃`�F�b�N
                Try
                    ' Only get subdirectories that begin with the letter "p."
                    Dim dirs As String() = Directory.GetDirectories(strPath, CStr(Format(newKENCD, "00")) & "*")
                    Dim dir As String
                    For Each dir In dirs
                        '�f�B���N�g���[�Z�b�g
                        newPATH = dir
                        '����I��
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

#Region "f_makeCSVByDT CSV�����񐶐�"
        ''' <summary>
        ''' CSV�����񐶐�
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
            '�C�������@START
            If f_FileDialog("csv", wkFileName) = False Then
                Return False
            End If
            If wkFileName = "" Then
                Return False
            End If
            '�C�������@END
            '*** 2010/09/03 JBD UPD ***

            '�w�b�_
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
                            'NULL�̏ꍇ�͋�����B
                            wkLine.Add("")
                        Case TypeOf wkValue Is String
                            '������̏ꍇ�̓_�u���N�I�[�g�ň͂ށB
                            wkLine.Add("""" & wkValue.ToString & """")
                        Case TypeOf wkValue Is Date
                            '���t�̏ꍇ��yyyy/MM/dd�`����
                            wkLine.Add(DirectCast(wkValue, Date).ToString("yyyy/MM/dd"))
                        Case Else
                            '�����Ȃǂ̏ꍇ�͂��̂܂ܕ�����ɁB
                            wkLine.Add(wkValue.ToString)
                    End Select

                Next

                wkSB.AppendLine(String.Join(",", wkLine.ToArray))

            Next

            Try
                '�t�@�C���I�[�v��
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
                Using wkSW = New IO.StreamWriter(wkFileName, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
                    wkSW.Write(wkSB.ToString)
                End Using
                'Show_MessageBox("I501", "")     'CSV�o�͂��I�����܂����B
            Catch ex As OracleException
                '���ʗ�O����
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

#Region "�f�[�^�擾�N���X"

#Region "���ƑΏ۔N�x"

        ''' <summary>
        ''' ���ƑΏ۔N�x
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
            ''' �f�[�^�擾
            ''' </summary>
            ''' <remarks></remarks>
            Sub New()
                Dim wkDS As New DataSet
                Dim wkSB As New System.Text.StringBuilder


                wkSB.AppendLine("select * ")
                wkSB.AppendLine("from  TM_SYORI_NENDO")
                wkSB.AppendLine("order by JIGYO_NENDO�@desc") '�ꌏ�����f�[�^���Ȃ��̂��O�񂾂��A�Ƃ肠�����ő�̔N�x������Ă���B

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
            ''' �f�[�^�擾(�����敪�w��)
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
#Region "�R���g���[���}�X�^"

        ''' <summary>
        ''' �R���g���[���}�X�^
        ''' </summary>
        ''' <remarks></remarks>
        Public Class Obj_TM_CONTROL
            Property pPDF_PATH As String
            Property pPASS_KIGEN As Integer
            Property pWAREKI_NEN As Integer
            Property pSEISANSYA_KIGO As String

            ''' <summary>
            ''' �f�[�^�擾
            ''' </summary>
            ''' <remarks></remarks>
            Sub New()
                Dim wkDS As New DataSet
                Dim wkSB As New System.Text.StringBuilder


                wkSB.AppendLine("select * ")
                wkSB.AppendLine("from  TM_CONTROL")
                wkSB.AppendLine("order by PASS_KIGEN�@desc") '�ꌏ�����f�[�^���Ȃ��̂��O�񂾂��A�Ƃ肠�����ő�̎g�p�҃}�X�^�@�p�X���[�h�L������������Ă���B

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
#Region "�����Ώۊ��E�N�x�}�X�^"
        ''' <summary>
        ''' �����Ώۊ��E�N�x
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
            ''' �f�[�^�擾
            ''' </summary>
            ''' <remarks></remarks>
            Sub New()
                Dim wkDS As New DataSet
                Dim wkSB As New System.Text.StringBuilder

                wkSB.AppendLine("select * ")
                wkSB.AppendLine("from  TM_SYORI_KI")
                wkSB.AppendLine("order by KI�@desc") '�ꌏ�����f�[�^���Ȃ��̂��O�񂾂��A�Ƃ肠�����ő�̊�������Ă���B

               Using db = New DaDbContext()
                   f_Select_ODP_New(db,wkDS, wkSB.ToString)
               End Using

                With wkDS
                    If .Tables(0).Rows.Count <> 0 Then
                        pKI = wkDS.Tables(0).Rows(0)("KI")
                        pJIGYO_NENDO = wkDS.Tables(0).Rows(0)("JIGYO_NENDO")
                        pJIGYO_SYURYO_NENDO = wkDS.Tables(0).Rows(0)("JIGYO_SYURYO_NENDO")

                        '2015/02/23 JBD368 UPD ������
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
                        '2015/02/23 JBD368 UPD ������
                        '2015/03/02 JBD368 UPD ������
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
                        '2015/03/02 JBD368 UPD ������

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

#Region "*** ���{�X�V ���t�֘A�֐� ***"

        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Saisou_Syukkabi_Get
        '����            :�����œn���ꂽ������ő��o�ד����Z�o����
        '
        '����            :1.dtStandard          Date     ���
        '                 2.numTaisyoNendo      Integer  �Ώ۔N�x
        '
        '�߂�l          :Date    �Z�o�����ő��o�ד�
        '------------------------------------------------------------------
        Public Function f_Saisou_Syukkabi_Get(ByVal dtStandard As Date, ByVal numTaisyoNendo As Integer) As Date
            Dim wkDS As New DataSet
            Dim wkSB As New System.Text.StringBuilder
            Dim dtWkYmd As Date

            '��----- 2012/03/27 JBD200 UPDATE �d�l�ύX -----��
            'wkSB.AppendLine("select SEIKEI_SAISOU_SYUKKABI ")
            wkSB.AppendLine("select SEIKEI_SYUKKA_KIKAN ")
            '��----- 2012/03/27 JBD200 UPDATE �d�l�ύX -----��
            wkSB.AppendLine("from  TM_GYOMU_YOKEN ")
            wkSB.AppendLine("where TAISYO_NENDO = " & numTaisyoNendo & "")

            f_Select_ODP(wkDS, wkSB.ToString)

            With wkDS
                If .Tables(0).Rows.Count <> 0 Then
                    '��----- 2012/03/27 JBD200 UPDATE �d�l�ύX -----��
                    'dtWkYmd = dtStandard.AddDays(-1 * wkDS.Tables(0).Rows(0)("SEIKEI_SAISOU_SYUKKABI"))
                    dtWkYmd = dtStandard.AddDays(-1 * wkDS.Tables(0).Rows(0)("SEIKEI_SYUKKA_KIKAN"))
                    '��----- 2012/03/27 JBD200 UPDATE �d�l�ύX -----��
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
        '�v���V�[�W����  :f_Saichi_syukkabi_Get
        '����            :�����œn���ꂽ���ƏI�������Œx�o�ד����Z�o����
        '
        '����            :1.dtEnterpriseEnd     Date     ���ƏI����
        '
        '�߂�l          :Date    �Z�o�����Œx�o�ד�
        '------------------------------------------------------------------
        Public Function f_Saichi_Syukkabi_Get(ByVal dtEnterpriseEnd As Date) As Date

            Return dtEnterpriseEnd.AddDays(-1)

        End Function

        '------------------------------------------------------------------
        '�v���V�[�W����  :f_KeikakuSinsei_Kigen_Get
        '����            :�����œn���ꂽ�ŏI�o�ד����v��\���������Z�o����
        '
        '����            :1.dtLatestShipdate    Date     �ŏI�o�ד�
        '                 2.numTaisyoNendo      Integer  �Ώ۔N�x
        '
        '�߂�l          :Date    �Z�o�����v��\������
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
        '�v���V�[�W����  :f_Kusya_Kikan_Get
        '����            :�����œn���ꂽ�ŏI�o�ד�����ѓ���������Ɋ��Ԃ��Z�o����
        '
        '����            :1.dtLatestShipdate    Date     �ŏI�o�ד�
        '                 2.dtIntroductorydate  Date     ������
        '
        '�߂�l          :Long    �Z�o������Ɋ���
        '------------------------------------------------------------------
        Public Function f_Kusya_Kikan_Get(ByVal dtLatestShipdate As Date, ByVal dtIntroductorydate As Date) As Long
            Dim nKikan As Long

            '��Ɋ��� = ������ - �ŏI�o�ד� - 1
            'nKikan = DateDiff(DateInterval.Day, dtIntroductorydate, dtLatestShipdate) - 1
            nKikan = DateDiff(DateInterval.Day, dtLatestShipdate, dtIntroductorydate) - 1

            If nKikan < 0 Then
                nKikan = 0
            End If

            Return nKikan

        End Function

        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Donyu_Kikan_Get
        '����            :�����œn���ꂽ�ŏI�o�ד�����эŏI��������蓱�����Ԃ��Z�o����
        '
        '����            :1.dtLatestShipdate    Date     �ŏI�o�ד�
        '                 2.dtIntroductorydate  Date     �ŏI������
        '
        '�߂�l          :Long    �Z�o������������
        '------------------------------------------------------------------
        Public Function f_Donyu_Kikan_Get(ByVal dtLatestShipdate As Date, ByVal dtIntroductorydate As Date) As Long
            Dim nKikan As Long

            '��Ɋ��� = ������ - �ŏI�o�ד� - 1
            'nKikan = DateDiff(DateInterval.Day, dtIntroductorydate, dtLatestShipdate)
            nKikan = DateDiff(DateInterval.Day, dtLatestShipdate, dtIntroductorydate)

            If nKikan < 0 Then
                nKikan = 0
            End If

            Return nKikan

        End Function

        '------------------------------------------------------------------
        '�v���V�[�W����  :f_JissekiHoukoku_Kigen_Get
        '����            :�����œn���ꂽ�ŏI�����������ѕ񍐊������Z�o����
        '
        '����            :1.dtIntroductorydate  Date     �ŏI������
        '                 2.numTaisyoNendo      Integer  �Ώ۔N�x
        '
        '�߂�l          :Date    �Z�o�������ѕ񍐊���
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
                '�������̂P�������Z 
                dtWkYmd = dtWkYmd.AddDays(-1)    '2012/04/19�@�ǉ�
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

#Region "*** ��e���擾 ***"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_inei_Get 2018/06/12 �V�K�쐬
        '����            :��e���擾����
        '
        '�߂�l          :bmp    ��e
        '------------------------------------------------------------------
        'Public Function f_inei_Get() As Object

        '    Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        '    Dim bmp = New Bitmap(myAssembly.GetManifestResourceStream("JbdGjsCommon.inei.gif"))

        '    Return bmp

        'End Function
#End Region

#Region "*** �������`�J�i�\�����`�F�b�N ***"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_chk_Zengin 2018/07/03 �V�K�쐬
        '����            :�������`�J�i�\�����`�F�b�N����
        '
        '�߂�l          :boolean
        '------------------------------------------------------------------
        Public Function f_chk_Zengin(ByVal str As String) As Boolean

            Dim charArray As Char() = New Char() {" "c, "�"c, "�"c, "("c, ")"c, "-"c, "."c, "0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c, "J"c, "K"c, "L"c, "M"c, "N"c, "O"c, "P"c, "Q"c, "R"c, "S"c, "T"c, "U"c, "V"c, "W"c, "X"c, "Y"c, "Z"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c, "�"c}
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
                    'MessageBox.Show("�������`�l(�J�i)�Ɏg�p�ł��Ȃ��������܂܂�Ă��܂��B" & vbCrLf & vbCrLf & _
                    '                "�g�p�\����" & vbCrLf & _
                    '                "�����@�@�@�@�@0 1 2 3 4 5 6 7 8 9" & vbCrLf & _
                    '                "�p���@�@�@�@�@A B C D E F G H I J K L M " & vbCrLf & _
                    '                "�@�@�@�@�@�@�@N O P Q R S T U V W X Y Z" & vbCrLf & _
                    '                "�J�i�����@�@�@� � � � � � � � � � � � � � � � � � � � " & vbCrLf & _
                    '                "�@�@�@�@�@�@�@� � � � � � � � � � � � � � � � � � � � � � � � �" & vbCrLf & _
                    '                "���_�E�����_�@� �" & vbCrLf & _
                    '                "�L���@�@�@�@�@. ( ) - " & vbCrLf & _
                    '                "���p�X�y�[�X", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            Next

            Return True

        End Function
#End Region

#Region "�^�C�g���\���֘A"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Title_Get
        '����            :�^�C�g���\��擾����
        '����            :�Ȃ�
        '�߂�l          :Boolean(����True/�G���[False)
        '                 �O�����ʕϐ�:pAPPTITLE�Ƀ^�C�g���\�蕶���񂪓���
        '2021/02/16 JBD9020 �V�K�쐬
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
                        allget = "�_��: (�V�K " & CLng(WordHenkan("N", "Z", .Rows(0)("CNT_SHINKI"))).ToString("##,###,##0") & " "
                        allget = allget & "�p�� " & CLng(WordHenkan("N", "Z", .Rows(0)("CNT_KEI"))).ToString("##,###,##0") & ")" & vbCrLf & vbCrLf
                        allget = allget & "�H��: �@�@" & CLng(WordHenkan("N", "Z", .Rows(0)("HASU"))).ToString("##,###,##0").PadLeft(14) & " �H" & vbCrLf & vbCrLf
                        allget = allget & "�ϗ����z: " & CLng(WordHenkan("N", "Z", .Rows(0)("TUMI"))).ToString("##,###,##0").PadLeft(14) & " �~"
                    Else
                        '���R�[�h�Ȃ�
                        allget = "�_��: (�V�K 0 "
                        allget = allget & "�p�� 0)" & vbCrLf & vbCrLf
                        allget = allget & "�H��: �@�@�Ȃ�" & vbCrLf & vbCrLf
                        allget = allget & "�ϗ����z: �Ȃ�"
                    End If
                End With

                f_All_Get = allget

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
            End Try

        End Function
#End Region


    #Region "*** �}�X�^�f�[�^�擾 ***"
    #Region "f_CodeMaster_Data_Select �R�[�h�}�X�^�f�[�^�擾"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_CodeMaster_Data_Select
        '����            :�R�[�h�}�X�^�������œn���ꂽ�f�[�^�敪�ɊY������
        '                 �R�[�h�Ɩ��̂��擾���A�R���{�{�b�N�X�ɃZ�b�g����
        '
        '����            :1.cmbCd  String       �R�[�h�R���{�{�b�N�X
        '                 2.cmbMei String       ���̃R���{�{�b�N�X
        '                 3.sDATA_KBN   String(Optional)        �f�[�^�敪(4:������ʃf�[�^ 5:�s���{���f�[�^)
        '                 4.blnNullAddFlg   Boolean             �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '                 5.nRYAKU_KBN  Integer                 �������́A���̋敪  0:��������(����)  1:����
        '�߂�l          :Boolean(����True/�G���[False)
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

                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                '        If blnNullAddFlg Then
                '            '�R���{�󔒍��ڒǉ�
                '            cmbCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                '    Else
                '        '�G���[���X�g�o�͂Ȃ�
                '        'Show_MessageBox("I002", "") '�Y���f�[�^�����݂��܂���B
                '    End If
                'End With

                f_CodeMaster_Data_Select = True

            Catch ex As Exception
                '���ʗ�O����
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
    #Region "f_Ken_Data_Select ���f�[�^�擾"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Ken_Data_Select
        '����            :���f�[�^�擾
        '����            :1.cmbKenCd        String      ���R�[�h�R���{�{�b�N�X
        '                 2.cmbKenMei       String      �����R���{�{�b�N�X
        '                 3.blnNullAddFlg   Boolean                     �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '                 4.sDATA_KBN       Integer(Optional)           �f�[�^�敪(Default:5�@�����f�[�^)
        '�߂�l          :Boolean(����True/�G���[False)
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
                '2015/01/21 JBD368 UPD ������ �s���{�����͐������̂��g�p����
                'sSql = sSql & "  RYAKUSYO" & vbCrLf
                sSql = sSql & "  MEISYO" & vbCrLf
                '2015/01/21 JBD368 UPD ������
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
                '            '2015/01/21 JBD368 UPD ������ �s���{�����͐������̂��g�p����
                '            'cmbKenMei.Items.Add(WordHenkan("N", "S", .Rows(i)("RYAKUSYO")))
                '            cmbKenMei.Items.Add(WordHenkan("N", "S", .Rows(i)("MEISYO")))
                '            '2015/02/21 JBD368 UPD ������

                '            'subItem1.Value = WordHenkan("N", "S", .Rows(i)("MEISYO_CD"))
                '            'subItem2.Value = WordHenkan("N", "S", .Rows(i)("RYAKUSYO"))
                '            'cmbKenMei.Items.AddRange(New GrapeCity.Win.Editors.ListItem(New GrapeCity.Win.Editors.SubItem() {subItem1, subItem2}))

                '            'cmbKenMei.Items.Add("")
                '            'cmbKenMei.ListColumns.Item(0).DataPropertyName = WordHenkan("N", "S", .Rows(i)("MEISYO_CD"))
                '            'cmbKenMei.ListColumns.Item(1).DataPropertyName = WordHenkan("N", "S", .Rows(i)("RYAKUSYO"))

                '        Next

                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                '        If blnNullAddFlg Then
                '            '���}�X�^�R���{�󔒍��ڒǉ�
                '            cmbKenCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbKenMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                '    Else
                '        '�G���[���X�g�o�͂Ȃ�
                '        'Show_MessageBox("I002", "") '�Y���f�[�^�����݂��܂���B
                '        ''Show_MessageBox("�Y���f�[�^�����݂��܂���B", C_MSGICON_INFORMATION) '�Y���f�[�^�����݂��܂���B
                '    End If
                'End With


                f_Ken_Data_Select = True

            Catch ex As Exception
                '���ʗ�O����
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
    #Region "f_Itaku_Data_Select �㗝�l�f�[�^�擾"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Itaku_Data_Select
        '����            :�㗝�l�f�[�^�擾
        '����            :1.cmbSankaCd  String     �㗝�l�R�[�h�R���{�{�b�N�X
        '                 2.cmbSankaMei String     �㗝�l���R���{�{�b�N�X
        '                 3.blnNullAddFlg   Boolean                �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '�߂�l          :Boolean(����True/�G���[False)
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

                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                '        If blnNullAddFlg Then
                '            '�R���{�󔒍��ڒǉ�
                '            cmbItakuCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbItakuMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                '    End If
                'End With

                ''�Y���f�[�^����(�ϑ���g�p��)
                'cmbItakuCd.Enabled = True
                'cmbItakuMei.Enabled = True

                f_Itaku_Data_Select = True

            Catch ex As Exception
                '���ʗ�O����
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
    #Region "f_Seisansya_Data_Select ���Y�҃f�[�^�擾"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Seisansya_Data_Select
        '����            :���Y�҃f�[�^�擾
        '����            :1.cmbSeisanCd     String   ���Y�҃R�[�h�R���{�{�b�N�X
        '                 2.cmbSeisanMei    String   ���Y�Җ��R���{�{�b�N�X
        '                 3.strWhere        String                   ���Y�҃}�X�^�������� WHERE����w�肷�� ""�̏ꍇ�A���������͎����ڂ��D�悳���
        '                 4.nKensakuKbn     Inbteger                 ���Y�҃}�X�^�̍��ځF���Y�P�ʋ敪�Ɍ��肵���������� �O���ڂ�strWHERE���w�肳��Ă���ꍇ�A���������
        '                                                             0:�S�Ă̐��Y�P�ʋ敪
        '                                                             1:���Y�P�ʋ敪=1�̂��̂̂�
        '                                                             2:���Y�P�ʋ敪=2�̂��̂̂�
        '                                                             3:���Y�P�ʋ敪=3�̂��̂̂�
        '                                                            12:���Y�P�ʋ敪=1�܂��͐��Y�P�ʋ敪=2�̂���
        '                                                            13:���Y�P�ʋ敪=1�܂��͐��Y�P�ʋ敪=3�̂���
        '                                                            23:���Y�P�ʋ敪=2�܂��͐��Y�P�ʋ敪=3�̂���
        '                 5.blnNullAddFlg   Boolean                  �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '�߂�l          :Boolean(����True/�G���[False)
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

                '���������Ƃ��Č��R�[�h���w�肳�ꂽ
                'If sKEN_CD <> "" Then
                '    sWhere = sWhere & "  KEN_CD = '" & sKEN_CD & "'" & vbCrLf
                'End If


                If strWhere <> "" Then
                    '��O�������w�肳��Ă���
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

                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                '        If blnNullAddFlg Then
                '            '�R���{�󔒍��ڒǉ�
                '            cmbSeisanCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSeisanMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                '    End If
                'End With

                ''���Y�҃R�[�h�g�p��
                'cmbSeisanCd.Enabled = True
                'cmbSeisanMei.Enabled = True

                f_Seisansya_Data_Select = True

            Catch ex As Exception
                '���ʗ�O����
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
    #Region "f_Itaku_Seisansya_Data_Select �㗝�l�R�[�h�ɕR�t�����Y�҃f�[�^�擾"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Itaku_Seisansya_Data_Select
        '����            :���Y�҃f�[�^�擾
        '����            :1.cmbItakuCdFm   String     �㗝�l�R�[�h�R���{�{�b�N�XFROM
        '                 2.cmbSeisanCdFm  String     ���Y�҃R�[�h�R���{�{�b�N�XFROM
        '                 3.cmbSeisanMeiFm String     ���Y�Җ��R���{�{�b�N�XFROM
        '                 4.blnNullAddFlg   Boolean                   �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '                 5.cmbItakuCdTo   String     �㗝�l�R�[�h�R���{�{�b�N�XTO
        '                 6.cmbSeisanCdTo  String     ���Y�҃R�[�h�R���{�{�b�N�XTO
        '                 7.cmbSeisanMeiTo String     ���Y�Җ��R���{�{�b�N�XTO
        '�߂�l          :Boolean(����True/�G���[False)
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
                    '�㗝�l�R�[�hTo�͖��w��
                    If cmbItakuCdFm = "" Then
                        ' �㗝�l�R�[�hFROM�͖��w��
                        ' ����Đ��Y�҂͑S��
                    Else
                        ' �㗝�l�R�[�hFROM�͎w�肳��Ă���
                        ' ����Đ��Y��FROM�͑㗝�l�R�[�hFROM�ƈ�v������̂��Ώ�
                        sWhere = sWhere & "  ITAKU_CD = '" & cmbItakuCdFm & "'" & vbCrLf
                    End If
                Else
                    '�㗝�l�R�[�hTo�͎w�肳��Ă���
                    If cmbItakuCdFm = "" Or cmbItakuCdTo = "" Then
                        ' �㗝�l�R�[�hFROM�܂���TO�͖��w��
                        ' ����Đ��Y��FROM�����TO�͑S��
                    Else
                        If cmbItakuCdFm <> cmbItakuCdTo Then
                            ' �㗝�l�R�[�hFROM��TO�͓���łȂ�
                            ' ����Đ��Y��FROM�����TO�͑S��
                        Else
                            ' �㗝�l�R�[�hFROM��TO�͓���ł���
                            ' ����Đ��Y��FROM�����TO�͑㗝�l�R�[�h�ƈ�v������̂��Ώ�
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

                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                '        If blnNullAddFlg Then
                '            '�R���{�󔒍��ڒǉ�
                '            cmbSeisanCdFm.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSeisanMeiFm.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '            If cmbItakuCdTo Is Nothing Or cmbSeisanCdTo Is Nothing Or cmbSeisanMeiTo Is Nothing Then
                '            Else
                '                '�R���{�󔒍��ڒǉ�
                '                cmbSeisanCdTo.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSeisanMeiTo.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '            End If
                '        End If
                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                '    End If
                'End With

                ''���Y�҃R�[�h�g�p��
                'cmbSeisanCdFm.Enabled = True
                'cmbSeisanMeiFm.Enabled = True
                'If cmbItakuCdTo Is Nothing Or cmbSeisanCdTo Is Nothing Or cmbSeisanMeiTo Is Nothing Then
                'Else
                '    cmbSeisanCdTo.Enabled = True
                '    cmbSeisanMeiTo.Enabled = True
                'End If

                f_Itaku_Seisansya_Data_Select = True

            Catch ex As Exception
                '���ʗ�O����
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
    #Region "f_Itaku_Data_Select ���Z�@�փf�[�^�擾"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Itaku_Data_Select
        '����            :���Z�@�փf�[�^�擾
        '����            :1.cmbBankCd  String       ���Z�@�փR�[�h�R���{�{�b�N�X
        '                 2.cmbBankMei String       ���Z�@�֖��R���{�{�b�N�X
        '                 3.blnNullAddFlg   Boolean                 �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '                 4.sDATA_KBN   String(Optional)            �f�[�^�敪(Default:"")
        '�߂�l          :Boolean(����True/�G���[False)
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

                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                '        If blnNullAddFlg Then
                '            '�R���{�󔒍��ڒǉ�
                '            cmbBankCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbBankMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                '    Else
                '        '�G���[���X�g�o�͂Ȃ�
                '        'Show_MessageBox("I002", "") '�Y���f�[�^�����݂��܂���B
                '        ''Show_MessageBox("�Y���f�[�^�����݂��܂���B", C_MSGICON_INFORMATION)
                '    End If
                'End With

                f_Bank_Data_Select = True

            Catch ex As Exception
                '���ʗ�O����
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
    #Region "f_BankShop_Data_Select ���Z�@�֎x�X�f�[�^�擾"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_BankShop_Data_Select
        '����            :���Z�@�֎x�X�f�[�^�擾
        '����            :1.cmbShopCd  String       ���Z�@�֎x�X�R�[�h�R���{�{�b�N�X
        '                 2.cmbShopMei String       ���Z�@�֎x�X���R���{�{�b�N�X
        '                 3.sBankCD     String                      ���Z�@�փR�[�h
        '                 4.blnNullAddFlg   Boolean                 �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '                 5.sDATA_KBN   String(Optional)            �f�[�^�敪(Default:"")
        '�߂�l          :Boolean(����True/�G���[False)
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

                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                '        If blnNullAddFlg Then
                '            '�R���{�󔒍��ڒǉ�
                '            cmbShopCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbShopMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                '    End If
                'End With

                f_BankShop_Data_Select = True

            Catch ex As Exception
                '���ʗ�O����
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
    #Region "f_Doitu_Seisansya_Data_Select ���ꐶ�Y�҃O���[�v�f�[�^�擾"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Doitu_Seisansya_Data_Select
        '����            :���ꐶ�Y�҃O���[�v�f�[�^�擾
        '����            :1.cmbDoituSeisansyaCd  String       ���ꐶ�Y�҃O���[�v�R�[�h�R���{�{�b�N�X
        '                 2.cmbDoituSeisansyaMei String       ���ꐶ�Y�҃O���[�v���R���{�{�b�N�X
        '                 3.blnNullAddFlg   Boolean                 �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '�߂�l          :Boolean(����True/�G���[False)
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

                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                '        If blnNullAddFlg Then
                '            '�R���{�󔒍��ڒǉ�
                '            cmbDoituSeisansyaCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbDoituSeisansyaMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                '    Else
                '        '�G���[���X�g�o�͂Ȃ�
                '        ''Show_MessageBox("I002", "") '�Y���f�[�^�����݂��܂���B
                '        ''Show_MessageBox("�Y���f�[�^�����݂��܂���B", C_MSGICON_INFORMATION)
                '    End If
                'End With

                f_Doitu_Seisansya_Data_Select = True

            Catch ex As Exception
                '���ʗ�O����
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
    #Region "f_Syokcyo_Data_Select �H��������f�[�^�擾"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Syokcyo_Data_Select
        '����            :�H��������f�[�^�擾
        '����            :1.cmbSyokucyoCd  String       �H��������R�[�h�R���{�{�b�N�X
        '                 2.cmbSyokucyoMei String       �H�������ꖼ�R���{�{�b�N�X
        '                 3.blnNullAddFlg   Boolean                 �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '�߂�l          :Boolean(����True/�G���[False)
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

                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                '        If blnNullAddFlg Then
                '            '�R���{�󔒍��ڒǉ�
                '            cmbSyokucyoCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSyokucyoMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                '    Else
                '        '�G���[���X�g�o�͂Ȃ�
                '        ''Show_MessageBox("I002", "") '�Y���f�[�^�����݂��܂���B
                '        ''Show_MessageBox("�Y���f�[�^�����݂��܂���B", C_MSGICON_INFORMATION)
                '    End If
                'End With

                f_Syokcyo_Data_Select = True

            Catch ex As Exception
                '���ʗ�O����
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
    #Region "f_User_Data_Select �S���҃f�[�^�擾"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_User_Data_Select
        '����            :�S���҃f�[�^�擾
        '����            :1.cmbUserCd  String       �S���҃R�[�h�R���{�{�b�N�X
        '                 2.cmbUserMei String       �S���Җ��R���{�{�b�N�X
        '                 3.blnNullAddFlg   Boolean                 �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '�߂�l          :Boolean(����True/�G���[False)
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

                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                '        If blnNullAddFlg Then
                '            '�R���{�󔒍��ڒǉ�
                '            cmbUserCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbUserMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                '    Else
                '        '�G���[���X�g�o�͂Ȃ�
                '        ''Show_MessageBox("I002", "") '�Y���f�[�^�����݂��܂���B
                '        ''Show_MessageBox("�Y���f�[�^�����݂��܂���B", C_MSGICON_INFORMATION)
                '    End If
                'End With

                f_User_Data_Select = True

            Catch ex As Exception
                '���ʗ�O����
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
    #Region "f_Keiyaku_Data_Select �_��҃f�[�^�擾(�h�u�ݏ�)"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_Keiyaku_Data_Select
        '����            :�_��҃f�[�^�擾
        '����            :1.cmbKeiyakuCd     String   �_��҃R�[�h�R���{�{�b�N�X
        '                 2.cmbKeiyakuMei    String   �_��Җ��R���{�{�b�N�X
        '                 3.strWhere        String                    �_��҃}�X�^�������� WHERE����w�肷��
        '                 4.blnNullAddFlg   Boolean                   �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '                 5.blnEnable       Boolean                   �R���{�̓��͉�(TRUE:���͉\ FALSE:���͕s��)
        '                 6.strUser       Boolean                   �@���X�L�[�}�̃f�[�^���K�v�Ȏ��A�X�L�[�}���Z�b�g(""�̂Ƃ��A���X�L�[�})   '2017/07/07�ǉ�
        '�߂�l          :Boolean(����True/�G���[False)
        '------------------------------------------------------------------
        Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As String, _
                                              ByRef cmbKeiyakuMei As String, _
                                              ByVal strWhere As String, _
                                              ByVal blnNullAddFlg As Boolean, _
                                              ByVal blnEnable As Boolean, _
                                              ByVal strUser As String) As Boolean

            '2015/03/03 JBD368 UPD ������
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

            '            '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
            '            If blnNullAddFlg Then
            '                '�R���{�󔒍��ڒǉ�
            '                cmbKeiyakuCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbKeiyakuMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
            '            End If
            '            '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

            '        End If
            '    End With

            '    '�_��҃R�[�h�g�p��
            '    cmbKeiyakuCd.Enabled = blnEnable
            '    cmbKeiyakuMei.Enabled = blnEnable

            '    f_Keiyaku_Data_Select = True

            'Catch ex As Exception
            '    '���ʗ�O����
            '    'Show_MessageBox("", ex.Message)
            'End Try


            Dim sSql As String = String.Empty
            Dim sSqlWhere As String = String.Empty  '2015/04/02 JBD368 ADD
            Dim dstDataSanka As New DataSet

            f_Keiyaku_Data_Select = False

            Try

                sSql = ""
                If blnNullAddFlg Then   '��3����=True�̎��A�󔒍��ڂ�ǉ�
                    '�R���{�󔒍��ڒǉ�
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

                '��2015/04/02 JBD368 UPD
                'If strWhere <> "" Then
                '    sSql = sSql & " WHERE"
                '    sSql = sSql & " " & strWhere
                'End If
                sSqlWhere = ""
                sSqlWhere = sSqlWhere & " WHERE"
                '�_��敪��NULL�̃f�[�^�͖��Q���̌_��҂Ƃ݂Ȃ��A�R���{�{�b�N�X�ɂ͒ǉ����Ȃ��B
                sSqlWhere = sSqlWhere & "   KEIYAKU_KBN IS NOT NULL"

                If strWhere <> "" Then
                    sSqlWhere = sSqlWhere & " AND " & strWhere
                End If
                sSql = sSql & sSqlWhere
                '��2015/04/02 JBD368 UPD

                If blnNullAddFlg Then   '��3����=True�̎��A�󔒍��ڂ�ǉ��̂��ߋ󔒂�擪�ɂ���
                    sSql = sSql & " ORDER BY KEIYAKUSYA_CD NULLS FIRST"
                Else
                    sSql = sSql & " ORDER BY KEIYAKUSYA_CD"
                End If

                Call f_Select_ODP(dstDataSanka, sSql)

                'cmbKeiyakuCd.Clear()
                'cmbKeiyakuMei.Clear()

                'With dstDataSanka.Tables(0)
                '    If .Rows.Count > 0 Then

                '        '�R���{�{�b�N�X�Ƀf�[�^���o�C���h
                '        cmbKeiyakuCd.DataSource = dstDataSanka.Tables(0)
                '        '�s�v�ȃJ�������폜����
                '        cmbKeiyakuCd.ListColumns.RemoveAt(1)

                '        '�R���{�{�b�N�X�Ƀf�[�^���o�C���h
                '        cmbKeiyakuMei.DataSource = dstDataSanka.Tables(0)
                '        '�s�v�ȃJ�������폜����
                '        cmbKeiyakuMei.ListColumns.RemoveAt(0)
                '        '���̂̃R���{�{�b�N�X�̕���ݒ�
                '        cmbKeiyakuMei.ListColumns(0).Width = cmbKeiyakuMei.Width

                '    End If
                'End With

                ''�_��҃R�[�h�g�p��
                'cmbKeiyakuCd.Enabled = blnEnable
                'cmbKeiyakuMei.Enabled = blnEnable

                f_Keiyaku_Data_Select = True

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
            End Try

        End Function

        Public Function f_Keiyaku_Data_Select_New(ki As Integer, blnNullAddFlg As Boolean, strUser As String) As DataTable
            Dim sSql As String = String.Empty
            Dim sSqlWhere As String = String.Empty  '2015/04/02 JBD368 ADD
            Dim dstDataSanka As New DataSet
            sSql = ""
            'If blnNullAddFlg Then   '��3����=True�̎��A�󔒍��ڂ�ǉ�
            '    '�R���{�󔒍��ڒǉ�
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
            '�_��敪��NULL�̃f�[�^�͖��Q���̌_��҂Ƃ݂Ȃ��A�R���{�{�b�N�X�ɂ͒ǉ����Ȃ��B
            sSqlWhere = sSqlWhere & "   KEIYAKU_KBN IS NOT NULL"

            If ki.ToString() <> "" Then
                sSqlWhere = sSqlWhere & " AND " & "KI = " & ki.ToString()
            End If
            sSql = sSql & sSqlWhere
            '��2015/04/02 JBD368 UPD

            If blnNullAddFlg Then   '��3����=True�̎��A�󔒍��ڂ�ǉ��̂��ߋ󔒂�擪�ɂ���
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
        '�v���V�[�W����  :f_Keiyaku_Data_Select
        '����            :�_��҃f�[�^�擾
        '����            :1.cmbKeiyakuCd     String   �_��҃R�[�h�R���{�{�b�N�X
        '                 2.cmbKeiyakuMei    String   �_��Җ��R���{�{�b�N�X
        '                 3.strWhere        String                    �_��҃}�X�^�������� WHERE����w�肷��
        '                 4.blnNullAddFlg   Boolean                   �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '                 5.blnEnable       Boolean                   �R���{�̓��͉�(TRUE:���͉\ FALSE:���͕s��)
        '�߂�l          :Boolean(����True/�G���[False)
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
        '�v���V�[�W����  :f_Keiyaku_Data_Select
        '����            :�_��҃f�[�^�擾
        '����            :1.cmbKeiyakuCd     String   �_��҃R�[�h�R���{�{�b�N�X
        '                 2.cmbKeiyakuMei    String   �_��Җ��R���{�{�b�N�X
        '                 3.strWhere        String                    �_��҃}�X�^�������� WHERE����w�肷��
        '                 4.blnNullAddFlg   Boolean                   �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '�߂�l          :Boolean(����True/�G���[False)
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
        '�v���V�[�W����  :f_Keiyaku_Data_Select
        '����            :�_��҃f�[�^�擾
        '����            :1.cmbKeiyakuCd     String   �_��҃R�[�h�R���{�{�b�N�X
        '                 2.cmbKeiyakuMei    String   �_��Җ��R���{�{�b�N�X
        '                 3.strWhere        String                    �_��҃}�X�^�������� WHERE����w�肷��
        '�߂�l          :Boolean(����True/�G���[False)
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
        '�v���V�[�W����  :f_Keiyaku_Data_Select
        '����            :�_��҃f�[�^�擾
        '����            :1.cmbKeiyakuCd     String   �_��҃R�[�h�R���{�{�b�N�X
        '                 2.cmbKeiyakuMei    String   �_��Җ��R���{�{�b�N�X
        '�߂�l          :Boolean(����True/�G���[False)
        '------------------------------------------------------------------
        Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As String, _
                                                 ByRef cmbKeiyakuMei As String) As Boolean

            If Not f_Keiyaku_Data_Select(cmbKeiyakuCd, cmbKeiyakuMei, "", False, True) Then
                Return False
            End If

            Return True

        End Function

    #End Region
    #Region "f_JimuItaku_Data_Select �����ϑ���f�[�^�擾(�h�u�ݏ�)"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_JimuItaku_Data_Select
        '����            :�����ϑ���f�[�^�擾(�h�u�ݏ�)
        '����            :1.cmbJimuItakuCd     String   �����ϑ���R�[�h�R���{�{�b�N�X
        '                 2.cmbJimuItakuMei    String   �����ϑ��於�R���{�{�b�N�X
        '                 3.strWhere        String                      �����ϑ���}�X�^�������� WHERE����w�肷��
        '                 4.blnNullAddFlg   Boolean                     �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '�߂�l          :Boolean(����True/�G���[False)
        '------------------------------------------------------------------
        Public Function f_JimuItaku_Data_Select(ByRef cmbJimuItakuCd As String, _
                                                ByRef cmbJimuItakuMei As String, _
                                                ByVal strWhere As String, _
                                                ByVal blnNullAddFlg As Boolean, _
                                                ByVal blnEnable As Boolean) As Boolean

            '2015/03/03 JBD368 UPD ������ �R���{�{�b�N�X�ւ̃Z�b�g���@��ύX
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

            '            '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
            '            If blnNullAddFlg Then
            '                '�R���{�󔒍��ڒǉ�
            '                cmbJimuItakuCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbJimuItakuMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
            '            End If
            '            '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

            '        End If
            '    End With

            '    '�����ϑ���R�[�h�g�p��
            '    cmbJimuItakuCd.Enabled = blnEnable
            '    cmbJimuItakuMei.Enabled = blnEnable

            '    f_JimuItaku_Data_Select = True

            'Catch ex As Exception
            '    '���ʗ�O����
            '    'Show_MessageBox("", ex.Message)
            'End Try


            Dim sSql As String = String.Empty
            Dim dstDataSanka As New DataSet

            f_JimuItaku_Data_Select = False

            Try

                sSql = ""
                If blnNullAddFlg Then   '��3����=True�̎��A�󔒍��ڂ�ǉ�
                    '�R���{�󔒍��ڒǉ�
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

                If blnNullAddFlg Then   '��3����=True�̎��A�󔒍��ڂ�擪�ɕ\������
                    sSql = sSql & " ORDER BY ITAKU_CD NULLS FIRST"
                Else
                    sSql = sSql & " ORDER BY ITAKU_CD"
                End If

                Call f_Select_ODP(dstDataSanka, sSql)

                'cmbJimuItakuCd.Clear()
                'cmbJimuItakuMei.Clear()

                'With dstDataSanka.Tables(0)
                '    If .Rows.Count > 0 Then
                '        '�R���{�{�b�N�X�Ƀf�[�^���o�C���h
                '        cmbJimuItakuCd.DataSource = dstDataSanka.Tables(0)
                '        '�s�v�ȃJ�������폜����
                '        cmbJimuItakuCd.ListColumns.RemoveAt(1)

                '        '�R���{�{�b�N�X�Ƀf�[�^���o�C���h
                '        cmbJimuItakuMei.DataSource = dstDataSanka.Tables(0)
                '        '�s�v�ȃJ�������폜����
                '        cmbJimuItakuMei.ListColumns.RemoveAt(0)
                '        '���̂̃R���{�{�b�N�X�̕���ݒ�
                '        cmbJimuItakuMei.ListColumns(0).Width = cmbJimuItakuMei.Width
                '    End If
                'End With

                ''�����ϑ���R�[�h�g�p��
                'cmbJimuItakuCd.Enabled = blnEnable
                'cmbJimuItakuMei.Enabled = blnEnable

                f_JimuItaku_Data_Select = True

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
            End Try
            '2015/03/03 JBD368 UPD ������

        End Function

        '------------------------------------------------------------------
        '�v���V�[�W����  :f_JimuItaku_Data_Select
        '����            :�����ϑ���f�[�^�擾
        '����            :1.cmbJimuItakuCd     String   �����ϑ���R�[�h�R���{�{�b�N�X
        '                 2.cmbJimuItakuMei    String   �����ϑ��於�R���{�{�b�N�X
        '                 3.strWhere        String                    �����ϑ���}�X�^�������� WHERE����w�肷��
        '�߂�l          :Boolean(����True/�G���[False)
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
        '�v���V�[�W����  :f_JimuItaku_Data_Select
        '����            :�����ϑ���f�[�^�擾
        '����            :1.cmbJimuItakuCd     String   �����ϑ���R�[�h�R���{�{�b�N�X
        '                 2.cmbJimuItakuMei    String   �����ϑ��於�R���{�{�b�N�X
        '                 3.strWhere        String                    �����ϑ���}�X�^�������� WHERE����w�肷��
        '�߂�l          :Boolean(����True/�G���[False)
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
        '�v���V�[�W����  :f_JimuItaku_Data_Select
        '����            :�����ϑ���f�[�^�擾
        '����            :1.cmbJimuItakuCd     String   �����ϑ���R�[�h�R���{�{�b�N�X
        '                 2.cmbJimuItakuMei    String   �����ϑ��於�R���{�{�b�N�X
        '�߂�l          :Boolean(����True/�G���[False)
        '------------------------------------------------------------------
        Public Function f_JimuItaku_Data_Select(ByRef cmbJimuItakuCd As String, _
                                                 ByRef cmbJimuItakuMei As String) As Boolean

            If Not f_JimuItaku_Data_Select(cmbJimuItakuCd, cmbJimuItakuMei, "", False, True) Then
                Return False
            End If

            Return True

        End Function

    #End Region
    #Region "f_KeiyakuNojo_Data_Select �_��_��f�[�^�擾(�h�u�ݏ�)"
        '------------------------------------------------------------------
        '�v���V�[�W����  :f_KeiyakuNojo_Data_Select
        '����            :�_��_��f�[�^�擾(�h�u�ݏ�)
        '����            :1.cmbKeiyakuNojoCd     String   �_��_��R�[�h�R���{�{�b�N�X
        '                 2.cmbKeiyakuNojoMei    String   �_��_�ꖼ�R���{�{�b�N�X
        '                 3.strWhere        String                      �_��_��}�X�^�������� WHERE����w�肷��
        '                 4.blnNullAddFlg   Boolean                     �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
        '�߂�l          :Boolean(����True/�G���[False)
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

                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                '        If blnNullAddFlg Then
                '            '�R���{�󔒍��ڒǉ�
                '            cmbKeiyakuNojoCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbKeiyakuNojoMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                '        End If
                '        '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                '    End If
                'End With

                ''�_��_��R�[�h�g�p��
                'cmbKeiyakuNojoCd.Enabled = blnEnable
                'cmbKeiyakuNojoMei.Enabled = blnEnable

                f_KeiyakuNojo_Data_Select = True

            Catch ex As Exception
                '���ʗ�O����
                'Show_MessageBox("", ex.Message)
            End Try

        End Function

        '------------------------------------------------------------------
        '�v���V�[�W����  :f_KeiyakuNojo_Data_Select
        '����            :�_��_��f�[�^�擾
        '����            :1.cmbKeiyakuNojoCd     String   �_��_��R�[�h�R���{�{�b�N�X
        '                 2.cmbKeiyakuNojoMei    String   �_��_�ꖼ�R���{�{�b�N�X
        '                 3.strWhere        String                    �_��_��}�X�^�������� WHERE����w�肷��
        '�߂�l          :Boolean(����True/�G���[False)
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
        '�v���V�[�W����  :f_KeiyakuNojo_Data_Select
        '����            :�_��_��f�[�^�擾
        '����            :1.cmbKeiyakuNojoCd     String   �_��_��R�[�h�R���{�{�b�N�X
        '                 2.cmbKeiyakuNojoMei    String   �_��_�ꖼ�R���{�{�b�N�X
        '                 3.strWhere        String                    �_��_��}�X�^�������� WHERE����w�肷��
        '�߂�l          :Boolean(����True/�G���[False)
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
        '�v���V�[�W����  :f_KeiyakuNojo_Data_Select
        '����            :�_��_��f�[�^�擾
        '����            :1.cmbKeiyakuNojoCd     String   �_��_��R�[�h�R���{�{�b�N�X
        '                 2.cmbKeiyakuNojoMei    String   �_��_�ꖼ�R���{�{�b�N�X
        '�߂�l          :Boolean(����True/�G���[False)
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
