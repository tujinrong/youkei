

'*******************************************************************************
'*�@�@�@�@���W���[�����@�@�@JbdGjsDb
'*
'*�@�@�A�@�@�\�T�v�@�@�@�@�@�d�l�r����DB���W���[��
'*
'*  �@�B�@�X�V�����@�@�@�@�@
'*******************************************************************************
Option Strict Off
Option Explicit On

'------------------------------------------------------------------
'------------------------------------------------------------------

Imports System.Data
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Oracle.ManagedDataAccess.Client

Public Class OracleDbHelper

#Region "*** CASE ***"

    Private connectionString As String

    Public Sub New(connString As String)
        connectionString = connString
    End Sub

    Public Function GetData(query As String) As DataTable
        Dim dt As New DataTable()

        Using conn As New OracleConnection(connectionString)
            Using cmd As New OracleCommand(query, conn)
                conn.Open()
                Dim reader As OracleDataReader = cmd.ExecuteReader()
                dt.Load(reader)
                conn.Close()
            End Using
        End Using

        Return dt
    End Function

#End Region

#Region "*** GJ0000 Function gj0000_cmdLogin_Click ���O�C���{�^���N���b�N���� ***"
    '------------------------------------------------------------------
    '�v���V�[�W����  :gj0000_cmdLogin_Click
    '����            :���O�C���{�^���N���b�N����
    '------------------------------------------------------------------
    Public Function gj0000_cmdLogin_Click(userId As String, passWord As String) As String
        Dim sSql As String = String.Empty
        Dim sRetMsg As String = String.Empty
        Dim dstDataSet As New DataSet

        Try
            '�������ʏo�͗p�r�p�k�쐬 
            If Not f_Search_SQLMake(sSql, userId, sRetMsg) Then
                Exit Try
            End If

            If Not f_Select_ODP(dstDataSet, sSql, sRetMsg) Then
                Exit Try
            End If

            If dstDataSet.Tables(0).Rows.Count > 0 Then

                '��ʂɊY���f�[�^��\��
                '��ʂɃZ�b�g
                If Not f_User_Check(dstDataSet, passWord, userId, sRetMsg) Then
                    Exit Try
                End If

            Else
                '�f�[�^���݂Ȃ�
                dstDataSet.Clear()
                sRetMsg = "ERR|gj0000_cmdLogin_Click|W019|" & "���[�U�[�h�c�A�p�X���[�h������������܂���B"
            End If

            Dim loginUserName = WordHenkan("N", "S", dstDataSet.Tables(0).Rows(0)("USER_NAME"))
            Dim pSiyoKbn = dstDataSet.Tables(0).Rows(0)("SIYO_KBN")
            dstDataSet.Clear()
            sRetMsg = "OK|" & loginUserName & "|" & pSiyoKbn

        Catch ex As Exception
            '���ʗ�O����
            sRetMsg = "ERR|gj0000_cmdLogin_Click|EXCEPTION|" & ex.Message
        Finally

        End Try

        Return sRetMsg

    End Function
#End Region

#Region "*** GJ0000 Function f_Search_SQLMake �������ʏo�͗p�r�p�k�쐬 ***"
    '------------------------------------------------------------------
    '�v���V�[�W����  :f_Search_SQLMake
    '����            :�������ʏo�͗p�r�p�k�쐬
    '����            :����
    '�߂�l          :String(SQL��)
    '�X�V��          :2009/01/27 jbd368 �`�F�b�N���X�g2��ǉ�
    '------------------------------------------------------------------
    Private Function f_Search_SQLMake(ByRef sSql As String, userId As String, ByRef sMsg As String) As Boolean
        Dim blnRet As Boolean = False

        Try
            '����
            sSql = " SELECT " & vbCrLf
            sSql += "     U.USER_NAME USER_NAME, " & vbCrLf
            sSql += "     U.PASS PASS, " & vbCrLf
            sSql += "     U.PASS_KIGEN_DATE PASS_KIGEN_DATE, " & vbCrLf
            sSql += "     U.SIYO_KBN SIYO_KBN, " & vbCrLf
            sSql += "     U.TEISI_DATE TEISI_DATE " & vbCrLf
            sSql += " FROM" & vbCrLf
            sSql += "     TM_USER U " & vbCrLf

            'WHERE��������쐬
            sSql += " WHERE" & vbCrLf
            sSql += "    (U.USER_ID = '" & userId.TrimEnd & "')" & vbCrLf
            blnRet = True
        Catch ex As Exception
            '���ʗ�O����
            sMsg = "ERR|f_Search_SQLMake|EXCEPTION|" & ex.Message
        End Try

        Return blnRet

    End Function
#End Region

#Region "*** GJ0000 Function f_User_Check ���O�C�����[�U�[���`�F�b�N���� ***"

    Private Function f_User_Check(ByVal dstDataSet As DataSet, passWord As String, userId As String, ByRef sMsg As String) As Boolean

        Dim blnRet As Boolean = False

        Try

            With dstDataSet.Tables(0)

                '�p�X���[�h�`�F�b�N
                Dim sPassWord = WordHenkan("N", "S", .Rows(0)("PASS")).ToString.TrimEnd
                Dim passWordSha256 = ComputeSHA256Hash(sPassWord, userId)
                If passWord.TrimEnd <> passWordSha256 Then
                    'Show_MessageBox_Add("W019", "���[�U�[�h�c�A�p�X���[�h������������܂���B") '���[�U�[�h�c�A�p�X���[�h������������܂���B
                    sMsg = "ERR|f_User_Check|W019|" & "���[�U�[�h�c�A�p�X���[�h������������܂���B"
                    Exit Try
                End If

                '�p�X���[�h�L�������`�F�b�N
                If .Rows(0)("PASS_KIGEN_DATE") < Now Then
                    '�p�X���[�h�L�������؂�
                    'Show_MessageBox_Add("W019", "�g�p�ł��܂���B�Ǘ��҂Ɋm�F���Ă��������B") '�g�p�ł��܂���B�Ǘ��҂Ɋm�F���Ă��������B
                    sMsg = "ERR|f_User_Check|W019|" & "�g�p�ł��܂���B�Ǘ��҂Ɋm�F���Ă��������B"
                    Exit Try
                End If

                '���p��~�`�F�b�N
                If Not .Rows(0)("TEISI_DATE") Is DBNull.Value Then
                    '���p��~���[�U�[
                    'Show_MessageBox_Add("W019", "�g�p�ł��܂���B�Ǘ��҂Ɋm�F���Ă��������B") '�g�p�ł��܂���B�Ǘ��҂Ɋm�F���Ă��������B
                    sMsg = "ERR|f_User_Check|W019|" & "�g�p�ł��܂���B�Ǘ��҂Ɋm�F���Ă������� �B"
                    Exit Try
                End If
                blnRet = True
            End With

        Catch ex As Exception
            '���ʗ�O����
            sMsg = "ERR|f_User_Check|EXCEPTION|" & ex.Message
        End Try

        Return blnRet

    End Function

#End Region

#Region "*** �ϐ���` ***"

    Public Cnn As New OracleConnection
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
    '------------------------------------------------------------------

    '���ʌ�����ʗp�ϐ�--------------------------------------
    Public pKoumokumei() As String
    Public pKoumokucnt As Integer
    Public pAlign() As String
    Public pMasterKey() As String
    Public pMasterKeycnt As Integer
    Public pSelectSql As String
    Public pTitle As String
    Public pretButton As String

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
    Public xl As New JbdGjsDb.Excel
    Private pRow As Integer = 0                         'Excel�o�͎��̍s�ԍ�

    '2024/01/22 �z�Q�Ɖ����̂��߁ALib�̐F��ύX�����ꍇ�͂������ύX
    Dim wBaseBackColor As System.Drawing.Color

    '2017/07/14�@�ǉ��J�n
    Public pKikin2 As Boolean = False
    '2017/07/14�@�ǉ��I��

#End Region

#Region "*** �萔��` ***"

    '���b�Z�[�W�\�����̃A�C�R���^�p
    '(Show_MessageBox�֐��̑�Q�����p)
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
    Public Function f_Select_ODP(ByRef dstDatasetSend As DataSet, ByVal strSQL As String, ByRef sMsg As String) As Boolean
        Dim dstDataSet As New DataSet
        Dim objOraDB As Object = ""
        Dim blnRet As Boolean = False

        Using conn As New OracleConnection(connectionString)
            Try
                Dim daDataAdapter As OracleDataAdapter
                daDataAdapter = New OracleDataAdapter(strSQL, conn)
                daDataAdapter.Fill(dstDataSet)
                dstDatasetSend = dstDataSet
                blnRet = True
                daDataAdapter.Dispose()
                conn.Close()
            Catch ex As Exception
                '���ʗ�O����
                conn.Close()
                dstDatasetSend = Nothing
                sMsg = "1|f_Select_ODP|EXCEPTION|" & ex.Message
            End Try
        End Using

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


            Cmd.Connection = Cnn
            Cmd.CommandText = strSQL

            ' OracleDataReader�I�u�W�F�N�g�𐶐����܂��B
            rdr = Cmd.ExecuteReader

            blnRet = True
        Catch ex As Exception
            '���ʗ�O����
            'Show_MessageBox("", ex.Message)
            'Show_MessageBox(ex.Message, C_MSGICON_ERROR)
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
            Dim Cmd As New OracleCommand(strSQL, Cnn)
            trans = Cnn.BeginTransaction()
            Cmd.ExecuteNonQuery()
            trans.Commit()
        Catch ex As OracleException
            '���ʗ�O����
            'Show_MessageBox("", ex.Message)
            'Show_MessageBox(ex.Message, C_MSGICON_ERROR)
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

            Dim Cmd As New OracleCommand(strSQL, Cnn)
            Cmd.ExecuteNonQuery()
            blnAns = True
        Catch ex As OracleException
            '���ʗ�O����
            'Show_MessageBox("", ex.Message)
            'Show_MessageBox(ex.Message, C_MSGICON_ERROR)
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
                .Connection = Cnn
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
            'Show_MessageBox(ex.Message, C_MSGICON_ERROR)
            If Not Cmd Is Nothing Then
                Cmd.Dispose()
            End If
        End Try

    End Function
#End Region

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
    Public Function fMidB(ByVal myString As String,
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
    Public Function WordHenkan(ByVal strFrom As String,
                                  ByVal strTo As String,
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

#Region "*** SHA256�֐� ***"

    Function ComputeSHA256Hash(data As String, salt As String) As String
        Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(data & salt)
        Using sha256 As SHA256 = SHA256.Create()
            Dim hashBytes As Byte() = sha256.ComputeHash(inputBytes)
            Return BitConverter.ToString(hashBytes).Replace("-", "")
        End Using
    End Function

#End Region

    '#Region "*** ���t����֐� ***"
    '    Public Function ACoDateCheckEdit(ByVal objTextBox As TextBox,
    '                                        ByVal varEditDate As Object) As Boolean
    '        '�T�v       : �e�L�X�g�{�b�N�X�ɓ��͂��ꂽ������̓��t�`�F�b�N���s��
    '        '���Ұ�     : �@objTextBox  �F�e�L�X�g�{�b�N�X��
    '        '           : �AvarEditDate �F�ҏW���ʂ��Z�b�g�������(Optional)
    '        '           : �B�߂�l,     �FTrue:���t����  False:���t�ُ�
    '        '����       :

    '        Dim intY As Integer
    '        Dim intM As Integer
    '        Dim intD As Integer

    '        Try

    '            ACoDateCheckEdit = True

    '            If Len(objTextBox.Text) = 0 Then
    '                Exit Function
    '            End If


    '            ' YYMMDD �̌`���œ��͂��ꂽ�ꍇ
    '            If Len(objTextBox.Text) = 6 Then
    '                If IsNumeric(Left$(objTextBox.Text, 2)) Then
    '                    intY = CInt(Left$(objTextBox.Text, 2))
    '                Else
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If IsNumeric(Mid$(objTextBox.Text, 3, 2)) Then
    '                    intM = CInt(Mid$(objTextBox.Text, 3, 2))
    '                Else
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If IsNumeric(Mid$(objTextBox.Text, 5, 2)) Then
    '                    intD = CInt(Mid$(objTextBox.Text, 5, 2))
    '                Else
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If ACoLeapCheck(intY, intM, intD) = False Then
    '                    GoTo ACoDateCheckEdit_Exit3
    '                End If

    '                If Left$(objTextBox.Text, 2) < "90" Then
    '                    If varEditDate = "Missing" Then
    '                        objTextBox.Text = "20" & Left$(objTextBox.Text, 2) & "/" & Mid$(objTextBox.Text, 3, 2) & "/" & Mid$(objTextBox.Text, 5, 2)
    '                    Else
    '                        varEditDate = "20" & Left$(objTextBox.Text, 2) & "/" & Mid$(objTextBox.Text, 3, 2) & "/" & Mid$(objTextBox.Text, 5, 2)
    '                    End If
    '                Else
    '                    If varEditDate = "Missing" Then
    '                        objTextBox.Text = "19" & Left$(objTextBox.Text, 2) & "/" & Mid$(objTextBox.Text, 3, 2) & "/" & Mid$(objTextBox.Text, 5, 2)
    '                    Else
    '                        varEditDate = "19" & Left$(objTextBox.Text, 2) & "/" & Mid$(objTextBox.Text, 3, 2) & "/" & Mid$(objTextBox.Text, 5, 2)
    '                    End If
    '                End If

    '                Exit Function
    '            End If

    '            ' YYYYMMDD �̌`���œ��͂��ꂽ�ꍇ
    '            If Len(objTextBox.Text) = 8 And Not (Mid$(objTextBox.Text, 3, 1) = "-" Or Mid$(objTextBox.Text, 3, 1) = "/") Then
    '                'If Left$(objTextBox.Text, 4) < "1900" Or Left$(objTextBox.Text, 4) > "2089" Then
    '                '    GoTo ACoDateCheckEdit_Exit2
    '                'End If

    '                If Mid$(objTextBox.Text, 5, 2) < "01" Or Mid$(objTextBox.Text, 5, 2) > "12" Or
    '                    Mid$(objTextBox.Text, 7, 2) < "01" Or Mid$(objTextBox.Text, 7, 2) > "31" Then
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If IsNumeric(Mid$(objTextBox.Text, 3, 2)) Then
    '                    intY = CInt(Mid$(objTextBox.Text, 3, 2))
    '                Else
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If IsNumeric(Mid$(objTextBox.Text, 5, 2)) Then
    '                    intM = CInt(Mid$(objTextBox.Text, 5, 2))
    '                Else
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If IsNumeric(Mid$(objTextBox.Text, 7, 2)) Then
    '                    intD = CInt(Mid$(objTextBox.Text, 7, 2))
    '                Else
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If ACoLeapCheck(intY, intM, intD) = False Then
    '                    GoTo ACoDateCheckEdit_Exit3
    '                End If

    '                If varEditDate = "Missing" Then
    '                    objTextBox.Text = Left$(objTextBox.Text, 4) & "/" & Mid$(objTextBox.Text, 5, 2) & "/" & Mid$(objTextBox.Text, 7, 2)
    '                Else
    '                    varEditDate = Left$(objTextBox.Text, 4) & "/" & Mid$(objTextBox.Text, 5, 2) & "/" & Mid$(objTextBox.Text, 7, 2)
    '                End If

    '                Exit Function
    '            End If

    '            ' YY-MM-DD(YY/MM/DD) �̌`���œ��͂��ꂽ�ꍇ
    '            If Len(objTextBox.Text) = 8 And (Mid$(objTextBox.Text, 3, 1) = "-" Or Mid$(objTextBox.Text, 3, 1) = "/") Then
    '                If Left$(objTextBox.Text, 2) < "00" Or Left$(objTextBox.Text, 2) > "99" Or
    '                    Mid$(objTextBox.Text, 4, 2) < "01" Or Mid$(objTextBox.Text, 4, 2) > "12" Or
    '                    Mid$(objTextBox.Text, 7, 2) < "01" Or Mid$(objTextBox.Text, 7, 2) > "31" Then
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If IsNumeric(Left$(objTextBox.Text, 2)) Then
    '                    intY = CInt(Left$(objTextBox.Text, 2))
    '                Else
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If IsNumeric(Mid$(objTextBox.Text, 4, 2)) Then
    '                    intM = CInt(Mid$(objTextBox.Text, 4, 2))
    '                Else
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If IsNumeric(Mid$(objTextBox.Text, 7, 2)) Then
    '                    intD = CInt(Mid$(objTextBox.Text, 7, 2))
    '                Else
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If ACoLeapCheck(intY, intM, intD) = False Then
    '                    GoTo ACoDateCheckEdit_Exit3
    '                End If

    '                If Left$(objTextBox.Text, 2) < "90" Then
    '                    If varEditDate = "Missing" Then
    '                        objTextBox.Text = "20" & Left$(objTextBox.Text, 2) & "/" & Mid$(objTextBox.Text, 4, 2) & "/" & Mid$(objTextBox.Text, 7, 2)
    '                    Else
    '                        varEditDate = "20" & Left$(objTextBox.Text, 2) & "/" & Mid$(objTextBox.Text, 4, 2) & "/" & Mid$(objTextBox.Text, 7, 2)
    '                    End If
    '                Else
    '                    If varEditDate = "Missing" Then
    '                        objTextBox.Text = "19" & Left$(objTextBox.Text, 2) & "/" & Mid$(objTextBox.Text, 4, 2) & "/" & Mid$(objTextBox.Text, 7, 2)
    '                    Else
    '                        varEditDate = "19" & Left$(objTextBox.Text, 2) & "/" & Mid$(objTextBox.Text, 4, 2) & "/" & Mid$(objTextBox.Text, 7, 2)
    '                    End If
    '                End If

    '                Exit Function

    '            End If

    '            ' YYYY-MM-DD(YYYY/MM/DD) �̌`���œ��͂��ꂽ�ꍇ
    '            If Len(objTextBox.Text) = 10 And (Mid$(objTextBox.Text, 5, 1) = "-" Or Mid$(objTextBox.Text, 5, 1) = "/") Then
    '                'If Left$(objTextBox.Text, 4) < "1990" Or Left$(objTextBox.Text, 4) > "2089" Then
    '                '    GoTo ACoDateCheckEdit_Exit2
    '                'End If

    '                If Mid$(objTextBox.Text, 6, 2) < "01" Or Mid$(objTextBox.Text, 6, 2) > "12" Or
    '                    Mid$(objTextBox.Text, 9, 2) < "01" Or Mid$(objTextBox.Text, 9, 2) > "31" Then
    '                    GoTo ACoDateCheckEdit_Exit1
    '                    Exit Function
    '                End If

    '                If IsNumeric(Mid$(objTextBox.Text, 3, 2)) Then
    '                    intY = CInt(Mid$(objTextBox.Text, 3, 2))
    '                Else
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If IsNumeric(Mid$(objTextBox.Text, 6, 2)) Then
    '                    intM = CInt(Mid$(objTextBox.Text, 6, 2))
    '                Else
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If IsNumeric(Mid$(objTextBox.Text, 9, 2)) Then
    '                    intD = CInt(Mid$(objTextBox.Text, 9, 2))
    '                Else
    '                    GoTo ACoDateCheckEdit_Exit1
    '                End If

    '                If ACoLeapCheck(intY, intM, intD) = False Then
    '                    GoTo ACoDateCheckEdit_Exit3
    '                End If

    '                If varEditDate = "Missing" Then
    '                    objTextBox.Text = Left$(objTextBox.Text, 4) & "/" & Mid$(objTextBox.Text, 6, 2) & "/" & Mid$(objTextBox.Text, 9, 2)
    '                Else
    '                    varEditDate = Left$(objTextBox.Text, 4) & "/" & Mid$(objTextBox.Text, 6, 2) & "/" & Mid$(objTextBox.Text, 9, 2)
    '                End If

    '                Exit Function
    '            End If

    'ACoDateCheckEdit_Exit1:
    '            Show_MessageBox("", "YYYYMMDD �܂��� YYMMDD �̌`���œ��͂��ĉ������B") 'YYYYMMDD �܂��� YYMMDD �̌`���œ��͂��ĉ������B
    '            'Show_MessageBox("YYYYMMDD �܂��� YYMMDD �̌`���œ��͂��ĉ������B", C_MSGICON_ERROR)
    '            ACoDateCheckEdit = False
    '            Exit Function

    '            'ACoDateCheckEdit_Exit2:

    '            '            Show_MessageBox("000049", "") '����́A1990�N����2089�N�܂ł���͂��ĉ������B"
    '            '            ACoDateCheckEdit = False
    '            '            Exit Function

    'ACoDateCheckEdit_Exit3:

    '            Show_MessageBox("", "�Y��������t�͑��݂��܂���B") 'YYYYMMDD �܂��� YYMMDD �̌`���œ��͂��ĉ������B
    '            'Show_MessageBox("�Y��������t�͑��݂��܂���B", C_MSGICON_ERROR)
    '            ACoDateCheckEdit = False
    '            Exit Function


    '        Catch ex As Exception
    '            '���ʗ�O����
    '            Show_MessageBox("", ex.Message)
    '            'Show_MessageBox(ex.Message, C_MSGICON_ERROR)
    '            ACoDateCheckEdit = False
    '        End Try


    '    End Function
    '    Public Function ACoDateCheckEdit(ByVal objTextBox As TextBox) As Boolean
    '        If Not ACoDateCheckEdit(objTextBox, "Missing") Then
    '            Return False
    '        End If
    '        Return True
    '    End Function
    '    Public Function ACoLeapCheck(ByVal intY As Integer, ByVal intM As Integer, ByVal intD As Integer) As Boolean
    '        '�T�v       :���邤�`�F�b�N
    '        '���Ұ�     :intY,i,Integer,�N�i00�`99�C90�`99��1990�`1999�A00�`89��2000�`2089�j
    '        '           :intM,i,Integer,��
    '        '           :intD,i,Integer,��
    '        '           :�߂�l,����->�@0�ȏ�A�ُ�->�@�|�P
    '        '����       :

    '        Dim intLeapday As Integer

    '        Select Case intM
    '            Case 1, 3, 5, 7, 8, 10, 12
    '                If intD > 0 And intD < 32 Then
    '                    ACoLeapCheck = True
    '                Else
    '                    ACoLeapCheck = False  '���͈̔̓G���[
    '                End If

    '            Case 4, 6, 9, 11
    '                If intD > 0 And intD < 31 Then
    '                    ACoLeapCheck = True
    '                Else
    '                    ACoLeapCheck = False  '���͈̔̓G���[
    '                End If

    '            Case 2
    '                If intY Mod 4 = 0 Then     '4�Ŋ���؂��N(����2000�N�͂��邤�N�j
    '                    intLeapday = 1
    '                Else
    '                    intLeapday = 0
    '                End If

    '                If intD > 0 And intD < 29 + intLeapday Then
    '                    ACoLeapCheck = True
    '                Else
    '                    ACoLeapCheck = False  '���͈̔̓G���[
    '                End If

    '            Case Else  '���͈̔̓G���[
    '                ACoLeapCheck = False

    '        End Select
    '    End Function

    '#Region "f_DateTrim ���ԏȗ�"
    '    '------------------------------------------------------------------
    '    '�v���V�[�W����  :f_DateTrim
    '    '����            :�����񁨓��t�ϊ�
    '    '����            :
    '    '�߂�l          :Boolean(����True/�G���[False)
    '    '------------------------------------------------------------------
    '    Public Function f_DateTrim(ByVal wkDate As Date) As Date
    '        If IsNothing(wkDate) OrElse wkDate = New Date Then
    '            Return wkDate
    '        Else
    '            Return Date.Parse(wkDate.ToString("yyyy/MM/dd"))
    '        End If
    '    End Function
    '#End Region

    '#Region "f_Str2DateOrNothing �������Date��Nothing�ɕϊ�"
    '    '------------------------------------------------------------------
    '    '�v���V�[�W����  :f_Str2DateOrNothing
    '    '����            :�������Date��Nothing�ɕϊ��B
    '    '����            :
    '    '�߂�l          :Boolean(����True/�G���[False)
    '    '------------------------------------------------------------------
    '    Public Function f_Str2DateOrNothing(ByVal wkDateStr As String) As Date
    '        Dim wkdate As New Date
    '        If Date.TryParse(wkDateStr, wkdate) Then
    '            Return wkdate
    '        Else
    '            Return Nothing
    '        End If
    '    End Function
    '#End Region

    '#Region "f_DateNothingCheck Date��Nothing�܂��͏����l�ȊO�ł��邩����"
    '    '------------------------------------------------------------------
    '    '�v���V�[�W����  :f_DateNothingCheck
    '    '����            :���t��Nothing�܂��͏����l(0001/01/01)�ȊO�ł��邩�`�F�b�N
    '    '����            :wkDate�F�Ώۓ��t
    '    '�߂�l          :Boolean(Nothing�ȊO�̏ꍇ�FTrue/Nothing�܂���0001/01/01�̏ꍇ�FFalse)
    '    '�X�V��          :2015/02/23 JBD368 ADD
    '    '------------------------------------------------------------------
    '    Public Function f_DateNothingCheck(ByVal wkDate As Date) As Boolean

    '        If IsNothing(wkDate) OrElse wkDate.ToString("yyyy/MM/dd") = "0001/01/01" Then
    '            Return False
    '        End If

    '        Return True
    '    End Function
    '#End Region

    '#End Region

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
        wkKVs.Add(New KeyValuePair(Of String, Object)(
                "SEISANSYA_CD",
                  SEISANSYA_CD
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
        wkKVs.Add(New KeyValuePair(Of String, Object)(
                "SYURUI_KBN",
                  SYURUI_KBN
               ))

        '�L�[�ǉ�(���̃R�[�h)
        wkKVs.Add(New KeyValuePair(Of String, Object)(
                "MEISYO_CD",
                  MEISYO_CD
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
        wkKVs.Add(New KeyValuePair(Of String, Object)(
                "ITAKU_CD",
                  ITAKU_CD
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
        wkKVs.Add(New KeyValuePair(Of String, Object)(
                "BANK_CD",
                  BANK_CD
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
        wkKVs.Add(New KeyValuePair(Of String, Object)(
                "BANK_CD",
                  BANK_CD
               ))

        '�L�[�ǉ�(���Z�@�֎x�X�R�[�h)
        wkKVs.Add(New KeyValuePair(Of String, Object)(
                "SITEN_CD",
                  SITEN_CD
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
                wkCmd.Connection = Cnn

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
            Cmd.Connection = Cnn
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
                'Show_MessageBox("000011", "") '�}�X�^�Ƀf�[�^���o�^����Ă��܂���B
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

    '------------------------------------------------------------------
    '�v���V�[�W����  :Show_MessageBox
    '����            :���b�Z�[�W�{�b�N�X�\������
    '����            :Message(���b�Z�[�W���e)
    '                 varICON(�A�C�R�� 0:Question(�ȗ����f�t�H���g) 1:Error 2:Warning 3:Information)
    '�߂�l          :DialogResult(���b�Z�[�W�{�b�N�X�̉����{�^���߂�l)
    '------------------------------------------------------------------
    'Public Function Show_MessageBox(ByVal CD As String,
    '                                ByVal Message As String,
    '                                ByVal varBUTTON As String,
    '                                ByVal varICON As String,
    '                                ByVal varDEF As String) As DialogResult
    '    Dim Position As Long
    '    Dim intButtons As System.Windows.Forms.MessageBoxButtons
    '    Dim intIcon As System.Windows.Forms.MessageBoxIcon
    '    Dim intDefault As System.Windows.Forms.MessageBoxDefaultButton


    '    If CD = "" Then
    '        '�{�^���̎��
    '        Select Case varBUTTON
    '            Case 0
    '                intButtons = MessageBoxButtons.OK           '0
    '            Case 1
    '                intButtons = MessageBoxButtons.OKCancel
    '            Case 2
    '                intButtons = MessageBoxButtons.AbortRetryIgnore
    '            Case 3
    '                intButtons = MessageBoxButtons.YesNoCancel
    '            Case 4
    '                intButtons = MessageBoxButtons.YesNo            '4
    '            Case 5
    '                intButtons = MessageBoxButtons.RetryCancel
    '        End Select

    '        '�A�C�R���̎��
    '        Select Case varICON
    '            Case 0
    '                intIcon = MessageBoxIcon.None
    '            Case 1
    '                intIcon = MessageBoxIcon.Hand
    '            Case 2
    '                intIcon = MessageBoxIcon.Stop
    '            Case 3
    '                intIcon = MessageBoxIcon.Error
    '            Case 4
    '                intIcon = MessageBoxIcon.Question
    '            Case 5
    '                intIcon = MessageBoxIcon.Exclamation
    '            Case 6
    '                intIcon = MessageBoxIcon.Warning
    '            Case 7
    '                intIcon = MessageBoxIcon.Asterisk
    '            Case 8
    '                intIcon = MessageBoxIcon.Information
    '        End Select

    '        '�f�t�H���g�̃J�[�\���ʒu
    '        Select Case varDEF
    '            Case 0
    '                intDefault = MessageBoxDefaultButton.Button1   '0
    '            Case 1
    '                intDefault = MessageBoxDefaultButton.Button2   '256
    '            Case 2
    '                intDefault = MessageBoxDefaultButton.Button3   '512
    '        End Select


    '        Show_MessageBox = MessageBox.Show(Message, pAPP, intButtons, intIcon, intDefault)
    '    Else
    '        Position = Array.IndexOf(pMESSAGE_CD_Array, CD)
    '        '�{�^���̎��
    '        Select Case pMESSAGE_Array(Position).BUTTON
    '            Case 0
    '                intButtons = MessageBoxButtons.OK           '0
    '            Case 1
    '                intButtons = MessageBoxButtons.OKCancel
    '            Case 2
    '                intButtons = MessageBoxButtons.AbortRetryIgnore
    '            Case 3
    '                intButtons = MessageBoxButtons.YesNoCancel
    '            Case 4
    '                intButtons = MessageBoxButtons.YesNo            '4
    '            Case 5
    '                intButtons = MessageBoxButtons.RetryCancel
    '        End Select

    '        '�A�C�R���̎��
    '        Select Case pMESSAGE_Array(Position).ICON
    '            Case 0
    '                intIcon = MessageBoxIcon.None
    '            Case 1
    '                intIcon = MessageBoxIcon.Hand
    '            Case 2
    '                intIcon = MessageBoxIcon.Stop
    '            Case 3
    '                intIcon = MessageBoxIcon.Error
    '            Case 4
    '                intIcon = MessageBoxIcon.Question
    '            Case 5
    '                intIcon = MessageBoxIcon.Exclamation
    '            Case 6
    '                intIcon = MessageBoxIcon.Warning
    '            Case 7
    '                intIcon = MessageBoxIcon.Asterisk
    '            Case 8
    '                intIcon = MessageBoxIcon.Information
    '        End Select

    '        '�f�t�H���g�̃J�[�\���ʒu
    '        Select Case pMESSAGE_Array(Position).DEF
    '            Case 0
    '                intDefault = MessageBoxDefaultButton.Button1   '0
    '            Case 1
    '                intDefault = MessageBoxDefaultButton.Button2   '256
    '            Case 2
    '                intDefault = MessageBoxDefaultButton.Button3   '512
    '        End Select

    '        Show_MessageBox = MessageBox.Show(pMESSAGE_Array(Position).MESSAGE, pAPP, intButtons, intIcon, intDefault)
    '    End If

    'End Function

    'Public Function Show_MessageBox(ByVal CD As String,
    '                               ByVal Message As String,
    '                               ByVal varBUTTON As String,
    '                               ByVal varICON As String) As DialogResult

    '    Return Show_MessageBox(CD, Message, varBUTTON, varICON, "0")
    'End Function

    'Public Function Show_MessageBox(ByVal CD As String,
    '                                 ByVal Message As String,
    '                                 ByVal varBUTTON As String) As DialogResult

    '    Return Show_MessageBox(CD, Message, varBUTTON, "0", "0")
    'End Function

    'Public Function Show_MessageBox(ByVal CD As String,
    '                            ByVal Message As String) As DialogResult

    '    Return Show_MessageBox(CD, Message, "0", "0", "0")
    'End Function

    '------------------------------------------------------------------
    '�v���V�[�W����  :Show_MessageBox_Add
    '����            :���b�Z�[�W�{�b�N�X�\������(���b�Z�[�W��t������o�[�W�����j
    '����            :CD�i���b�Z�[�W�R�[�h�j
    '                 kbn(�ʏ탁�b�Z�[�W�\���֐��Ƌ�ʂ��邽�߂̋敪 �O���Z�b�g���Ă��������j
    '                 Message(���b�Z�[�W���e)
    '�߂�l          :DialogResult(���b�Z�[�W�{�b�N�X�̉����{�^���߂�l)
    '------------------------------------------------------------------
    'Public Function Show_MessageBox_Add(ByVal CD As String, ByVal ParamArray Message() As Object) As DialogResult
    '    Dim Position As Long
    '    Dim intButtons As System.Windows.Forms.MessageBoxButtons
    '    Dim intIcon As System.Windows.Forms.MessageBoxIcon
    '    Dim intDefault As System.Windows.Forms.MessageBoxDefaultButton


    '    If CD = "" Then
    '        Show_MessageBox_Add = MessageBox.Show(Message(0), pAPP, 0, 0, 0)
    '    Else
    '        Position = Array.IndexOf(pMESSAGE_CD_Array, CD)
    '        '�{�^���̎��
    '        Select Case pMESSAGE_Array(Position).BUTTON
    '            Case 0
    '                intButtons = MessageBoxButtons.OK           '0
    '            Case 1
    '                intButtons = MessageBoxButtons.OKCancel
    '            Case 2
    '                intButtons = MessageBoxButtons.AbortRetryIgnore
    '            Case 3
    '                intButtons = MessageBoxButtons.YesNoCancel
    '            Case 4
    '                intButtons = MessageBoxButtons.YesNo            '4
    '            Case 5
    '                intButtons = MessageBoxButtons.RetryCancel
    '        End Select

    '        '�A�C�R���̎��
    '        Select Case pMESSAGE_Array(Position).ICON
    '            Case 0
    '                intIcon = MessageBoxIcon.None
    '            Case 1
    '                intIcon = MessageBoxIcon.Hand
    '            Case 2
    '                intIcon = MessageBoxIcon.Stop
    '            Case 3
    '                intIcon = MessageBoxIcon.Error
    '            Case 4
    '                intIcon = MessageBoxIcon.Question
    '            Case 5
    '                intIcon = MessageBoxIcon.Exclamation
    '            Case 6
    '                intIcon = MessageBoxIcon.Warning
    '            Case 7
    '                intIcon = MessageBoxIcon.Asterisk
    '            Case 8
    '                intIcon = MessageBoxIcon.Information
    '        End Select

    '        '�f�t�H���g�̃J�[�\���ʒu
    '        Select Case pMESSAGE_Array(Position).DEF
    '            Case 0
    '                intDefault = MessageBoxDefaultButton.Button1   '0
    '            Case 1
    '                intDefault = MessageBoxDefaultButton.Button2   '256
    '            Case 2
    '                intDefault = MessageBoxDefaultButton.Button3   '512
    '        End Select

    '        '���b�Z�[�W����"@"���������ꍇ�w��̕����ƒu������
    '        Dim strMESSAGE As String = pMESSAGE_Array(Position).MESSAGE
    '        For i As Integer = LBound(Message) To 9
    '            If i > UBound(Message) Then
    '                strMESSAGE = ReplaceString(strMESSAGE, "@" & i, "")
    '            ElseIf Microsoft.VisualBasic.Information.IsDBNull(Message(i)) Then
    '                strMESSAGE = ReplaceString(strMESSAGE, "@" & i, "")
    '            Else
    '                strMESSAGE = ReplaceString(strMESSAGE, "@" & i, CStr(Message(i)))
    '            End If
    '        Next i

    '        ''���s����
    '        strMESSAGE = ReplaceString(strMESSAGE, "/n", vbCr)

    '        ''TAB����
    '        strMESSAGE = ReplaceString(strMESSAGE, "/t", vbTab)

    '        Show_MessageBox_Add = MessageBox.Show(strMESSAGE, pAPP, intButtons, intIcon, intDefault)
    '    End If

    'End Function

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
                'Show_MessageBox("�v���O�����h�c���w�肳��Ă��܂���B", C_MSGICON_ERROR)
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

                'Call f_Select_ODP(dstDataSet, sSql)

                With dstDataSet.Tables(0)
                    If .Rows.Count > 0 Then
                        'For i As Integer = 0 To .Rows.Count - 1
                        'pAPPTITLE = WordHenkan("N", "S", .Rows(0)("KINO_NAME"))
                        pAPPTITLE = WordHenkan("N", "S", .Rows(0)("PROGRAMNM"))
                        'Next
                    Else
                        '���R�[�h�Ȃ�
                        'Show_MessageBox("000004", "") '�Y���f�[�^�����݂��܂���B
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
            wSql = "SELECT MEISYO_CD FROM TM_CODE " &
                   "WHERE SYURUI_KBN = 0" &
                   "  AND MEISYO_CD = 99"

            'DB����f�[�^���擾
            'If f_Select_ODP(wkDS, wSql) = False Then
            '    Exit Try
            'End If

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
            Cmd.Connection = Cnn
            Cmd.CommandType = CommandType.StoredProcedure
            '
            Cmd.CommandText = "PKG_SYORI_RIREKI.SYORI_RIREKI_INS"

            '�����n��
            Dim paraKAISISYURYO As OracleParameter =
                         Cmd.Parameters.Add("IN_SYORI_RIREKI_KAISI_SYURYO", nKAISI_SYURYO_FLG)
            Dim paraSYORIDATE As OracleParameter =
                         Cmd.Parameters.Add("IN_SYORI_RIREKI_SYORI_DATE", dSYORI_DATE)
            Dim paraPGCD As OracleParameter =
                         Cmd.Parameters.Add("IN_SYORI_RIREKI_PG_CD", sPGCD)
            Dim paraSYORINAME As OracleParameter =
                         Cmd.Parameters.Add("IN_SYORI_RIREKI_SYORI_NAME", sSYORI_NAME)
            Dim paraREGDATE As OracleParameter =
                         Cmd.Parameters.Add("IN_SYORI_RIREKI_REG_DATE", dREG_DATE)
            Dim paraREGID As OracleParameter =
                         Cmd.Parameters.Add("IN_SYORI_RIREKI_REG_ID", sREG_ID)
            Dim paraCOMNAME As OracleParameter =
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

    '#Region "��ʃN���A����"

    '    '------------------------------------------------------------------
    '    '�v���V�[�W����  :f_ClearFormALL
    '    '����            :�t�H�[���N���A����
    '    '����            :rKbn(�t�H�[���A�����敪)
    '    '�߂�l          :Boolean(����True/�G���[False)
    '    '�쐬��          :2013/06/10
    '    '------------------------------------------------------------------
    '    Public Function f_ClearFormALL(ByVal wkForm As Form, ByVal rKbn As String) As Boolean

    '        f_ClearFormALL = False

    '        Try

    '            '�t�H�[����ɔz�u����Ă��邷�ׂẴR���g���[�����
    '            Dim All_Ctl As Control() = f_GetAllControls(wkForm)

    '            '�R���g���[���N���A����
    '            For Each objCtrl As Control In All_Ctl
    '                f_ClearControl(rKbn, objCtrl)
    '            Next

    '            '����I��
    '            f_ClearFormALL = True

    '        Catch ex As Exception
    '            '���ʗ�O����
    '            Show_MessageBox("", ex.Message)
    '        End Try

    '    End Function

    '    '------------------------------------------------------------------
    '    '�v���V�[�W����  :f_GetAllControls
    '    '                 �t�H�[����ɔz�u����Ă��邷�ׂẴR���g���[�����
    '    '����            :frm(�t�H�[��)
    '    '�߂�l          :Control�^�̔z��
    '    '�쐬��          :2013/06/10
    '    '------------------------------------------------------------------
    '    Public Function f_GetAllControls(ByVal frm As Control) As Control()
    '        Dim buf As ArrayList = New ArrayList

    '        For Each ctl As Control In frm.Controls
    '            buf.Add(ctl)
    '            buf.AddRange(f_GetAllControls(ctl))
    '        Next
    '        Return CType(buf.ToArray(GetType(Control)), Control())

    '    End Function

    '    ''' <summary>
    '    ''' �R���g���[���N���A����
    '    ''' </summary>
    '    ''' <param name="rKbn">�����敪</param>
    '    ''' <param name="objCtrl">�N���A�ΏۃR���g���[��</param>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>
    '    Public Function f_ClearControl(ByVal rKbn As String, ByVal objCtrl As Object) As Boolean

    '        f_ClearControl = False
    '        Try

    '            f_ClearControl = True

    '            Select Case TypeName(objCtrl)

    '                Case "GcTextBox", "GcDate"
    '                    '÷���ޯ���A���t�^
    '                    If rKbn = "C" Then
    '                        If objCtrl.Name <> "txt_Now" Then
    '                            objCtrl.Text = ""
    '                        End If
    '                    Else
    '                        '÷���ޯ���A���t�^
    '                        objCtrl.Text = ""
    '                    End If

    '                Case "GcMask"
    '                    'Ͻ�
    '                    objCtrl.Value = ""

    '                Case "GcNumber"
    '                    '���l�^
    '                    objCtrl.Text = ""

    '                Case "GcComboBox"
    '                    '�����ޯ��
    '                    If rKbn = "C" Then
    '                        objCtrl.Items.Clear()
    '                        objCtrl.text = ""
    '                    Else
    '                        objCtrl.SelectedIndex = -1
    '                        objCtrl.text = ""
    '                    End If
    '                Case "CheckBox"
    '                    '�����ޯ��
    '                    objCtrl.Checked = False
    '                Case "DataGridView"
    '                    '�f�[�^�O���b�h
    '                    If Not (objCtrl.DataSource Is Nothing) AndAlso TypeOf objCtrl.DataSource Is DataSet Then
    '                        DirectCast(objCtrl.DataSource, DataSet).Clear()
    '                    End If
    '                Case "RadioButton"
    '                    '׼޵����
    '                    If objCtrl.TabIndex = 0 Then
    '                        objCtrl.Checked = True
    '                    Else
    '                        objCtrl.Checked = False
    '                    End If
    '                Case "JLabel"       '2015/01/16 JBD368 ADD
    '                    '�f�[�^�\���p���x��
    '                    objCtrl.Text = ""
    '            End Select

    '        Catch ex As Exception
    '            '���ʗ�O����
    '            Show_MessageBox("", ex.Message)
    '        End Try

    '    End Function
    '#End Region

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

            'If Not f_Select_ODP(dstDataSet, sSql) Then
            '    Exit Try
            'End If

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

    '#Region "FROM�`TO���쐧��"

    '    '------------------------------------------------------------------
    '    '�v���V�[�W����  :s_From_Validating
    '    '����            :FROM�`TO���ڂ�FROM�����쐧��i�Ή��I�u�W�F�N�g�FGcTextBox,GcNumber�j
    '    '                 FROM�����ڂ�Validating��Call����
    '    '����            :1.txtFrom     Object       FROM���I�u�W�F�N�g
    '    '                 2.txtTo       Object       TO���I�u�W�F�N�g
    '    '�߂�l          :����
    '    '------------------------------------------------------------------
    '    Public Sub s_From_Validating(ByVal txtFrom As Object, ByVal txtTo As Object)

    '        Select Case TypeName(txtFrom)

    '            Case "GcTextBox"
    '                '÷���ޯ��

    '                If txtFrom.Text = "" Then
    '                    'FM�����͂�TO�����͂�������
    '                    If txtTo.Text <> "" Then
    '                        txtTo.Text = ""
    '                    End If
    '                    Exit Sub
    '                End If

    '                'FROM���͂�TO�������͂�������
    '                If txtTo.Text = "" Then
    '                    'TO��FROM�̓��e���Z�b�g
    '                    txtTo.Text = txtFrom.Text
    '                End If

    '            Case "GcNumber"
    '                '���l�^

    '                '��***** 2011/06/27 JBD200 ZERO�͖����͂Ɣ��f����̂ł͂Ȃ����͉\�Ƃ���悤�ύX *****��
    '                'If txtFrom.Text = "" Or txtFrom.Text = "0" Then
    '                '    'FM�����͂�TO�����͂�������
    '                '    If txtTo.Text <> "" And txtTo.Text <> "0" Then
    '                '        txtTo.Text = ""
    '                '    End If
    '                '    Exit Sub
    '                'End If

    '                ''FROM���͂�TO�������͂�������
    '                'If txtTo.Text = "" Or txtTo.Text = "0" Then
    '                '    'TO��FROM�̓��e���Z�b�g
    '                '    txtTo.Text = txtFrom.Text
    '                'End If

    '                If txtFrom.Text = "" Then
    '                    'FM�����͂�TO�����͂�������
    '                    If txtTo.Text <> "" Then
    '                        txtTo.Text = ""
    '                    End If
    '                    Exit Sub
    '                End If

    '                'FROM���͂�TO�������͂�������
    '                If txtTo.Text = "" Then
    '                    'TO��FROM�̓��e���Z�b�g
    '                    txtTo.Text = txtFrom.Text
    '                End If
    '                '��***** 2011/06/27 JBD200 ZERO�͖����͂Ɣ��f����̂ł͂Ȃ����͉\�Ƃ���悤�ύX *****��

    '            Case "GcDate"
    '                '���t�^

    '                If txtFrom.Value Is Nothing Then
    '                    'FM�����͂�TO�����͂�������
    '                    If Not txtTo.Value Is Nothing Then
    '                        txtTo.Text = txtFrom.Text
    '                    End If
    '                    Exit Sub
    '                End If

    '                'FROM���͂�TO�������͂�������
    '                If txtTo.Value Is Nothing Then
    '                    'TO��FROM�̓��e���Z�b�g
    '                    txtTo.Text = txtFrom.Text
    '                End If

    '        End Select

    '    End Sub

    '    '------------------------------------------------------------------
    '    '�v���V�[�W����  :s_To_Validating
    '    '����            :FROM�`TO���ڂ�TO�����쐧��i�Ή��I�u�W�F�N�g�FGcTextBox,GcNumber�j
    '    '                 TO�����ڂ�Validating��Call����
    '    '����            :1.txtTo     Object       TO���I�u�W�F�N�g
    '    '                 2.txtFrom   Object       FROM���I�u�W�F�N�g
    '    '�߂�l          :����
    '    '------------------------------------------------------------------
    '    Public Sub s_To_Validating(ByVal txtTo As Object, ByVal txtFrom As Object)

    '        Select Case TypeName(txtTo)

    '            Case "GcTextBox"
    '                '÷���ޯ��

    '                If txtTo.Text = "" Then
    '                    If txtFrom.Text <> "" Then
    '                        'TO�����͂�FROM�����͂��������AFROM�̓��e��TO�ɃZ�b�g
    '                        txtTo.Text = txtFrom.Text
    '                    End If
    '                    Exit Sub
    '                End If

    '                If txtFrom.Text <> "" Then
    '                    'TO���͂�FROM�����͂��������A���������X���[����
    '                Else
    '                    'TO���͂�FROM�������͂��������ATO�̓��e��FROM�ɃZ�b�g
    '                    txtFrom.Text = txtTo.Text
    '                End If

    '            Case "GcNumber"
    '                '���l�^
    '                '��***** 2011/06/27 JBD200 ZERO�͖����͂Ɣ��f����̂ł͂Ȃ����͉\�Ƃ���悤�ύX *****��
    '                'If txtTo.Text = "" Or txtTo.Text = "0" Then
    '                '    If txtFrom.Text <> "" And txtFrom.Text <> "0" Then
    '                '        'TO�����͂�FROM�����͂��������AFROM�̓��e��TO�ɃZ�b�g
    '                '        txtTo.Text = txtFrom.Text
    '                '    End If
    '                '    Exit Sub
    '                'End If

    '                'If txtFrom.Text <> "" And txtFrom.Text <> "0" Then
    '                '    'TO���͂�FROM�����͂��������A���������X���[����
    '                'Else
    '                '    'TO���͂�FROM�������͂��������ATO�̓��e��FROM�ɃZ�b�g
    '                '    txtFrom.Text = txtTo.Text
    '                'End If

    '                If txtTo.Text = "" Then
    '                    If txtFrom.Text <> "" Then
    '                        'TO�����͂�FROM�����͂��������AFROM�̓��e��TO�ɃZ�b�g
    '                        txtTo.Text = txtFrom.Text
    '                    End If
    '                    Exit Sub
    '                End If

    '                If txtFrom.Text <> "" Then
    '                    'TO���͂�FROM�����͂��������A���������X���[����
    '                Else
    '                    'TO���͂�FROM�������͂��������ATO�̓��e��FROM�ɃZ�b�g
    '                    txtFrom.Text = txtTo.Text
    '                End If
    '                '��***** 2011/06/27 JBD200 ZERO�͖����͂Ɣ��f����̂ł͂Ȃ����͉\�Ƃ���悤�ύX *****��

    '            Case "GcDate"
    '                '���t�^

    '                If txtTo.Value Is Nothing Then
    '                    If Not txtFrom.Value Is Nothing Then
    '                        'TO�����͂�FROM�����͂��������AFROM�̓��e��TO�ɃZ�b�g
    '                        txtTo.Text = txtFrom.Text
    '                    End If
    '                    Exit Sub
    '                End If

    '                If Not txtFrom.Value Is Nothing Then
    '                    'TO���͂�FROM�����͂��������A���������X���[����
    '                Else
    '                    'TO���͂�FROM�������͂��������ATO�̓��e��FROM�ɃZ�b�g
    '                    txtFrom.Text = txtTo.Text
    '                End If

    '        End Select

    '    End Sub

    '    '------------------------------------------------------------------
    '    '�v���V�[�W����  :s_CboFrom_Validating
    '    '����            :FROM�`TO���ڂ�FROM�����쐧��i�Ή��I�u�W�F�N�g�FGcComboBox�j
    '    '                 FROM�����ڂ�Validating��Call����
    '    '����            :1.cboCdFrom       Object       FROM���R�[�h�R���{�I�u�W�F�N�g
    '    '                 2.cboMeiFrom      Object       FROM�����̃R���{�I�u�W�F�N�g
    '    '                 3.cboCdTo         Object       TO���R�[�h�R���{�I�u�W�F�N�g
    '    '                 4.cboMeiTo        Object       TO�����̃R���{�I�u�W�F�N�g
    '    '                 5.strCharNumFlg   String       ���l�E�����t���O("0":���l(�ȗ�������)(Long�^) "1":���� "2":���l(Decimal�^))
    '    '�߂�l          :����
    '    '------------------------------------------------------------------
    '    Public Sub s_CboFrom_Validating(ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object, ByVal cboCdTo As Object, ByVal cboMeiTo As Object, ByVal strCharNumFlg As String)
    '        Dim strFmtwk As String = "0"
    '        Dim strFmt As String

    '        If cboCdFrom.Text = "" Then
    '            'FM�����͂�TO�����͂�������
    '            If cboCdTo.Text <> "" Then
    '                cboCdTo.SelectedIndex = -1
    '            End If
    '            Exit Sub
    '        End If

    '        '�R�[�h�̂P���ڂ�0�̏ꍇ�͂O���폜
    '        'If Mid(cboCdFrom.Text, 1, 1) = 0 Then
    '        '    cboCdFrom.Text = Mid(cboCdFrom.Text, 2, 1)
    '        '    Exit Sub
    '        'End If
    '        If strCharNumFlg = "1" Then
    '            'DB���ڂ�����
    '            strFmt = strFmtwk.PadRight(cboCdFrom.MaxLength, "0")
    '            cboCdFrom.Text = Format(CLng(cboCdFrom.Text), strFmt)
    '            cboCdFrom.SelectedValue = Format(CLng(cboCdFrom.Text), strFmt)  '2015/03/03 JBD368 ADD

    '            '2015/03/03 JBD368 ADD �������ݒ�l��Decimal�^�̏ꍇ���l��
    '        ElseIf strCharNumFlg = "2" Then

    '            'DB���ڂ����l(Decimal�^)
    '            cboCdFrom.Text = CDec(cboCdFrom.Text)
    '            cboCdFrom.SelectedValue = CDec(cboCdFrom.Text)
    '            '2015/03/03 JBD368 ADD ������
    '        Else
    '            'DB���ڂ����l(Long�^)
    '            cboCdFrom.Text = CLng(cboCdFrom.Text)
    '            cboCdFrom.SelectedValue = cboCdFrom.Text  '2015/03/03 JBD368 ADD
    '        End If

    '        'cboCdFrom.SelectedValue = cboCdFrom.Text     '2015/03/03 JBD368 DEL �^�ɂ����SelectedValue��ݒ�l��ύX���邽�ߍ폜

    '        If cboCdFrom.SelectedValue Is Nothing Then
    '            cboCdFrom.SelectedIndex = -1
    '            cboMeiFrom.SelectedIndex = -1
    '            Show_MessageBox_Add("W012", cboCdFrom.Tag) '�w�肳�ꂽ@0������������܂���B
    '            cboCdFrom.Focus()
    '        Else
    '            'FROM���͂�TO�������͂�������
    '            If cboCdTo.Text = "" Then
    '                cboCdTo.SelectedValue = cboCdFrom.Text
    '            End If
    '        End If

    '    End Sub

    '    Public Sub s_CboFrom_Validating(ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object, ByVal cboCdTo As Object, ByVal cboMeiTo As Object)

    '        Call s_CboFrom_Validating(cboCdFrom, cboMeiFrom, cboCdTo, cboMeiTo, "0")

    '    End Sub


    '    '------------------------------------------------------------------
    '    '�v���V�[�W����  :s_CboTo_Validating
    '    '����            :FROM�`TO���ڂ�TO�����쐧��i�Ή��I�u�W�F�N�g�FGcComboBox�j
    '    '                 TO�����ڂ�Validating��Call����
    '    '����            :1.cboCdTo         Object       TO���R�[�h�R���{�I�u�W�F�N�g
    '    '                 2.cboMeiTo        Object       TO�����̃R���{�I�u�W�F�N�g
    '    '                 3.cboCdFrom       Object       FROM���R�[�h�R���{�I�u�W�F�N�g
    '    '                 4.cboMeiFrom      Object       FROM�����̃R���{�I�u�W�F�N�g
    '    '                 5.strCharNumFlg   String       ���l�E�����t���O("0":���l(�ȗ�������)(Long�^) "1":���� "2":���l(Decimal�^))
    '    '�߂�l          :����
    '    '------------------------------------------------------------------
    '    Public Sub s_CboTo_Validating(ByVal cboCdTo As Object, ByVal cboMeiTo As Object, ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object, ByVal strCharNumFlg As String)
    '        Dim strFmtwk As String = "0"
    '        Dim strFmt As String

    '        If cboCdTo.Text = "" Then
    '            If cboCdFrom.Text <> "" Then
    '                'TO�����͂�FROM�����͂��������AFROM�̓��e��TO�ɃZ�b�g
    '                '��2018/06/27 �C��
    '                'cboCdTo.SelectedValue = cboCdFrom.Text
    '                If strCharNumFlg = "1" Then
    '                    'DB���ڂ�����
    '                    strFmt = strFmtwk.PadRight(cboCdFrom.MaxLength, "0")
    '                    cboCdTo.SelectedValue = Format(CLng(cboCdFrom.Text), strFmt)
    '                ElseIf strCharNumFlg = "2" Then
    '                    'DB���ڂ����l(Decimal�^)
    '                    cboCdTo.SelectedValue = CDec(cboCdFrom.Text)
    '                Else
    '                    'DB���ڂ����l(Long�^)
    '                    cboCdTo.SelectedValue = cboCdFrom.Text
    '                End If
    '                '��2018/06/27 �C��
    '            End If
    '            Exit Sub
    '        End If

    '        '�R�[�h�̂P���ڂ�0�̏ꍇ�͂O���폜
    '        'If Mid(cboCdTo.Text, 1, 1) = 0 Then
    '        '    cboCdTo.Text = Mid(cboCdTo.Text, 2, 1)
    '        '    Exit Sub
    '        'End If
    '        'cboCdTo.Text = CLng(cboCdTo.Text)
    '        If strCharNumFlg = "1" Then
    '            'DB���ڂ�����
    '            strFmt = strFmtwk.PadRight(cboCdFrom.MaxLength, "0")
    '            cboCdTo.Text = Format(CLng(cboCdTo.Text), strFmt)
    '            cboCdTo.SelectedValue = Format(CLng(cboCdTo.Text), strFmt)  '2015/03/03 JBD368 ADD

    '            '2015/03/03 JBD368 ADD ������ �ݒ�l��Decimal�^�̏ꍇ���l��
    '        ElseIf strCharNumFlg = "2" Then

    '            'DB���ڂ����l(Decimal�^)
    '            cboCdTo.Text = CDec(cboCdTo.Text)
    '            cboCdTo.SelectedValue = CDec(cboCdTo.Text)
    '            '2015/03/03 JBD368 ADD ������
    '        Else
    '            'DB���ڂ����l(Long�^)
    '            cboCdTo.Text = CLng(cboCdTo.Text)
    '            cboCdTo.SelectedValue = cboCdTo.Text      '2015/03/03 JBD368 ADD
    '        End If

    '        'cboCdTo.SeletedItem.Value = cboCdTo.Text            '2015/03/03 JBD368 DEL �^�ɂ����SelectedValue��ݒ�l��ύX���邽�ߍ폜

    '        If cboCdTo.SelectedValue Is Nothing Then
    '            cboCdTo.SelectedIndex = -1
    '            cboMeiTo.SelectedIndex = -1
    '            Show_MessageBox_Add("W012", cboCdFrom.Tag) '�w�肳�ꂽ@0������������܂���B

    '            cboCdTo.Focus()
    '        Else
    '            If cboCdFrom.Text <> "" Then
    '                'TO���͂�FROM�����͂��������A���������X���[
    '            Else
    '                'TO���͂�FROM�������͂��������ATO�̓��e��FROM�ɃZ�b�g
    '                cboCdFrom.SelectedValue = cboCdTo.Text
    '            End If
    '        End If

    '    End Sub

    '    Public Sub s_CboTo_Validating(ByVal cboCdTo As Object, ByVal cboMeiTo As Object, ByVal cboCdFrom As Object, ByVal cboMeiFrom As Object)

    '        Call s_CboTo_Validating(cboCdTo, cboMeiTo, cboCdFrom, cboMeiFrom, "0")

    '    End Sub

    '    '------------------------------------------------------------------
    '    '�v���V�[�W����  :s_CboMeiFrom_SelectedIndexChanged
    '    '����            :FROM�`TO���ڂ�FROM�����̃R���{���쐧��i�Ή��I�u�W�F�N�g�FGcComboBox�j
    '    '                 FROM�����̃R���{���ڂ�Validating��Call����
    '    '����            :1.cboMeiFrom      Object       FROM�����̃R���{�I�u�W�F�N�g
    '    '                 2.cboCdFrom       Object       FROM���R�[�h�R���{�I�u�W�F�N�g
    '    '                 3.cboMeiTo        Object       TO�����̃R���{�I�u�W�F�N�g
    '    '                 4.cboCdTo         Object       TO���R�[�h�R���{�I�u�W�F�N�g
    '    '�߂�l          :����
    '    '------------------------------------------------------------------
    '    Public Sub s_CboMeiFrom_SelectedIndexChanged(ByVal cboMeiFrom As Object, ByVal cboCdFrom As Object, ByVal cboMeiTo As Object, ByVal cboCdTo As Object)

    '        cboCdFrom.SelectedIndex = cboMeiFrom.SelectedIndex

    '        If cboCdFrom.Text = "" Then
    '            'FM�����͂�TO�����͂�������
    '            'If cboCdTo.Text <> "" Then
    '            '    cboCdTo.SelectedIndex = -1
    '            'End If
    '            Exit Sub
    '        Else
    '            If cboCdTo.Text = "" Then
    '                cboCdTo.SelectedIndex = cboCdFrom.SelectedIndex
    '            End If
    '        End If

    '    End Sub

    '    '------------------------------------------------------------------
    '    '�v���V�[�W����  :s_CboMeiTo_Validating
    '    '����            :FROM�`TO���ڂ�TO�����쐧��i�Ή��I�u�W�F�N�g�FGcComboBox�j
    '    '                 TO�����ڂ�Validating��Call����
    '    '����            :1.cboMeiTo    Object       TO�����̃R���{�I�u�W�F�N�g
    '    '                 2.cboCdTo     Object       TO���R�[�h�R���{�I�u�W�F�N�g
    '    '                 3.cboMeiFrom  Object       FROM�����̃R���{�I�u�W�F�N�g
    '    '                 4.cboCdFrom   Object       FROM���R�[�h�R���{�I�u�W�F�N�g
    '    '�߂�l          :����
    '    '------------------------------------------------------------------
    '    Public Sub s_CboMeiTo_Validating(ByVal cboMeiTo As Object, ByVal cboCdTo As Object, ByVal cboMeiFrom As Object, ByVal cboCdFrom As Object)

    '        cboCdTo.SelectedIndex = cboMeiTo.SelectedIndex

    '        If cboCdTo.Text = "" Then
    '            'If cob_KenCdFm.Text <> "" Then
    '            '    'TO�����͂�FROM�����͂��������AFROM�̓��e��TO�ɃZ�b�g
    '            '    cob_KenCdTo.SelectedIndex = cob_KenCdFm.SelectedIndex
    '            'End If
    '            Exit Sub
    '        End If

    '        If cboCdFrom.Text <> "" Then
    '            'TO���͂�FROM�����͂��������A���������X���[
    '        Else
    '            'TO���͂�FROM�������͂��������ATO�̓��e��FROM�ɃZ�b�g
    '            cboCdFrom.SelectedIndex = cboCdTo.SelectedIndex
    '        End If

    '    End Sub

    '#End Region

    '#Region "f_Daisyo_Check �召�`�F�b�N"
    '    '------------------------------------------------------------------
    '    '�v���V�[�W����  :f_Daisyo_Check
    '    '����            :FROM-TO���ړ��e�召�`�F�b�N
    '    '����            :objCtrlFrom(FROM����޼ު��)
    '    '                 objCtrlTo(TO����޼ު��)
    '    '                 strKoumokuNm(�װү���ޕ\�����̍��ږ�)
    '    '                 MsgDsp(���b�Z�[�W�\���L��)
    '    '                 intZokusei(���ڑ��� 0:String����(���l�ȊO�̕�������͉�) 1:Number����(���l�ȊO�̕����͓��͕s��) 
    '    '                                     2:Date����  3:Number����(0�͓��͂Ƃ݂Ȃ�)
    '    '�߂�l          :Boolean(����True/�G���[False)
    '    '�C����          :2014/08/11
    '    '------------------------------------------------------------------
    '    Public Function f_Daisyo_Check(ByVal objCtrlFrom As Object, ByVal objCtrlTo As Object, ByVal strKoumokuNm As String,
    '                                    ByVal MsgDsp As Boolean, Optional ByVal intZokusei As Integer = 0) As Boolean
    '        Dim ret As Boolean = False

    '        Try

    '            Select Case TypeName(objCtrlFrom)
    '                Case "GcTextBox", "GcComboBox"
    '                    'FROM���͂Ȃ�
    '                    If (objCtrlFrom.Text Is Nothing OrElse objCtrlFrom.Text.TrimEnd = "") AndAlso
    '                       (Not objCtrlTo.Text Is Nothing AndAlso objCtrlTo.Text.TrimEnd <> "") Then
    '                        If MsgDsp Then
    '                            Show_MessageBox_Add("W008", strKoumokuNm & "From") '@0�͕K�{���͍��ڂł��B
    '                        End If
    '                        objCtrlFrom.Focus()
    '                        Exit Try
    '                    End If

    '                    'TO���͂Ȃ�
    '                    If (objCtrlTo.Text Is Nothing OrElse objCtrlTo.Text.TrimEnd = "") AndAlso
    '                       (Not objCtrlFrom.Text Is Nothing AndAlso objCtrlFrom.Text.TrimEnd <> "") Then
    '                        If MsgDsp Then
    '                            Show_MessageBox_Add("W008", strKoumokuNm & "To")    '@0�͕K�{���͍��ڂł��B
    '                        End If
    '                        objCtrlFrom.Focus()
    '                        Exit Try
    '                    End If

    '                    '�召�`�F�b�N
    '                    If objCtrlFrom.Text Is Nothing AndAlso objCtrlTo.Text Is Nothing Then
    '                    Else
    '                        If (Not objCtrlFrom.Text Is Nothing AndAlso objCtrlFrom.Text.TrimEnd <> "") AndAlso
    '                           (Not objCtrlTo.Text Is Nothing AndAlso objCtrlTo.Text.TrimEnd <> "") Then       '2010/11/24 UPD JBD200 ��r�����C��
    '                            If intZokusei = 1 Then
    '                                If CDec(objCtrlFrom.Text.ToString.TrimEnd) > CDec(objCtrlTo.Text.ToString.TrimEnd) Then     '2010/11/24 UPD JBD200 TEXT�𐔒l�ɕϊ����Ĕ�r����悤�C��
    '                                    If MsgDsp Then
    '                                        Show_MessageBox_Add("W003", "�w�肳�ꂽ" & strKoumokuNm)    '@0�͈͎̔w�肪����������܂���B
    '                                    End If
    '                                    objCtrlFrom.Focus()
    '                                    Exit Try
    '                                End If
    '                            Else
    '                                If objCtrlFrom.Text > objCtrlTo.Text Then
    '                                    If MsgDsp Then
    '                                        Show_MessageBox_Add("W003", "�w�肳�ꂽ" & strKoumokuNm)    '@0�͈͎̔w�肪����������܂���B
    '                                    End If
    '                                    objCtrlFrom.Focus()
    '                                    Exit Try
    '                                End If
    '                            End If
    '                        End If
    '                    End If

    '                Case "GcDate"
    '                    'FROM���͂Ȃ�
    '                    If objCtrlFrom.value Is Nothing AndAlso Not objCtrlTo.value Is Nothing Then
    '                        If MsgDsp Then
    '                            Show_MessageBox_Add("W008", strKoumokuNm & "From") '@0�͕K�{���͍��ڂł��B
    '                        End If
    '                        objCtrlFrom.Focus()
    '                        Exit Try
    '                    End If

    '                    'TO���͂Ȃ�
    '                    If objCtrlTo.value Is Nothing AndAlso Not objCtrlFrom.value Is Nothing Then
    '                        If MsgDsp Then
    '                            Show_MessageBox_Add("W008", strKoumokuNm & "To")    '@0�͕K�{���͍��ڂł��B
    '                        End If
    '                        objCtrlFrom.Focus()
    '                        Exit Try
    '                    End If

    '                    '�召�`�F�b�N
    '                    If objCtrlFrom.value Is Nothing AndAlso objCtrlTo.value Is Nothing Then
    '                    Else
    '                        If objCtrlFrom.Value > objCtrlTo.Value Then
    '                            If MsgDsp Then
    '                                Show_MessageBox_Add("W003", "�w�肳�ꂽ" & strKoumokuNm)    '@0�͈͎̔w�肪����������܂���B
    '                            End If
    '                            objCtrlFrom.Focus()
    '                            Exit Try
    '                        End If
    '                    End If

    '                Case "GcNumber"
    '                    '0���͂n�j
    '                    If intZokusei = 3 Then
    '                        'FROM���͂Ȃ�
    '                        If (objCtrlFrom.Value Is Nothing) AndAlso Not (objCtrlTo.Value Is Nothing) Then
    '                            If MsgDsp Then
    '                                Show_MessageBox_Add("W008", strKoumokuNm & "From") '@0�͕K�{���͍��ڂł��B
    '                            End If
    '                            objCtrlFrom.Focus()
    '                            Exit Try
    '                        End If

    '                        'TO���͂Ȃ�
    '                        If Not (objCtrlFrom.Value Is Nothing) AndAlso (objCtrlTo.Value Is Nothing) Then
    '                            If MsgDsp Then
    '                                Show_MessageBox_Add("W008", strKoumokuNm & "To")    '@0�͕K�{���͍��ڂł��B
    '                            End If
    '                            objCtrlTo.Focus()
    '                            Exit Try
    '                        End If

    '                        '�召�`�F�b�N
    '                        If (objCtrlFrom.Value Is Nothing AndAlso objCtrlTo.Value Is Nothing) Then
    '                        Else
    '                            If objCtrlFrom.Value > objCtrlTo.Value Then
    '                                If MsgDsp Then
    '                                    Show_MessageBox_Add("W003", "�w�肳�ꂽ" & strKoumokuNm)    '@0�͈͎̔w�肪����������܂���B
    '                                End If
    '                                objCtrlFrom.Focus()
    '                                Exit Try
    '                            End If
    '                        End If
    '                    Else
    '                        '0���͖͂����͂Ƃ݂Ȃ�
    '                        'FROM���͂Ȃ�
    '                        If (objCtrlFrom.Value Is Nothing OrElse objCtrlFrom.Value = 0) AndAlso
    '                           (Not objCtrlTo.Value Is Nothing AndAlso objCtrlTo.Value <> 0) Then
    '                            If MsgDsp Then
    '                                Show_MessageBox_Add("W008", strKoumokuNm & "From") '@0�͕K�{���͍��ڂł��B
    '                            End If
    '                            objCtrlFrom.Focus()
    '                            Exit Try
    '                        End If

    '                        'TO���͂Ȃ�
    '                        If (objCtrlTo.Value Is Nothing OrElse objCtrlTo.Value = 0) AndAlso
    '                           (Not objCtrlFrom.Value Is Nothing AndAlso objCtrlFrom.Value <> 0) Then
    '                            If MsgDsp Then
    '                                Show_MessageBox_Add("W008", strKoumokuNm & "To")    '@0�͕K�{���͍��ڂł��B
    '                            End If
    '                            objCtrlTo.Focus()
    '                            Exit Try
    '                        End If

    '                        '�召�`�F�b�N
    '                        If (objCtrlFrom.Value Is Nothing OrElse objCtrlFrom.Value = 0) AndAlso
    '                           (objCtrlTo.Value Is Nothing OrElse objCtrlTo.Value = 0) Then
    '                        Else
    '                            If objCtrlFrom.Value > objCtrlTo.Value Then
    '                                If MsgDsp Then
    '                                    Show_MessageBox_Add("W003", "�w�肳�ꂽ" & strKoumokuNm)    '@0�͈͎̔w�肪����������܂���B
    '                                End If
    '                                objCtrlFrom.Focus()
    '                                Exit Try
    '                            End If
    '                        End If
    '                    End If

    '            End Select

    '            ret = True

    '        Catch ex As Exception
    '            '���ʗ�O����
    '            Show_MessageBox("", ex.Message)
    '        End Try

    '        Return ret

    '    End Function

    '#End Region

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
            'Show_MessageBox(ex.Message, C_MSGICON_ERROR)
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
    Public Function f_ReportPath_Check(ByRef strOutputPath As String,
                                        ByVal OutKbn As Integer,
                                        ByVal strPath As String,
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
                'Call Show_MessageBox_Add("W009", " " & strPath & "��")          '@0�o�͐悪���݂��܂���B
                'Call Show_MessageBox(strPath & "�̏o�͐悪���݂��܂���B", C_MSGICON_WARNING)          '@0�o�͐悪���݂��܂���B
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
            'Show_MessageBox(ex.Message, C_MSGICON_ERROR)
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
                'Call Show_MessageBox_Add("W009", " " & strPath & "��")          '@0�o�͐悪���݂��܂���B
                'Call Show_MessageBox(strPath & "�̏o�͐悪���݂��܂���B", C_MSGICON_WARNING)          '@0�o�͐悪���݂��܂���B
                Exit Try
            End If

            ret = True

        Catch ex As Exception
            '���ʗ�O����
            'Show_MessageBox("", ex.Message)
            'Show_MessageBox(ex.Message, C_MSGICON_ERROR)
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
                'If Show_MessageBox("Q010", "") = DialogResult.No Then     '���Ƀt�@�C�������݂��܂��B�㏑�����Ă���낵���ł����H
                '    'If Show_MessageBox("���Ƀt�@�C�������݂��܂��B�㏑�����Ă���낵���ł����H", C_MSGICON_QUESTION) = DialogResult.No Then     '���Ƀt�@�C�������݂��܂��B�㏑�����Ă���낵���ł����H
                '    Exit Try
                'End If
            End If

            ret = True

        Catch ex As Exception
            '���ʗ�O����
            'Show_MessageBox("", ex.Message)
            'Show_MessageBox(ex.Message, C_MSGICON_ERROR)
        End Try

        Return ret

    End Function


#End Region

    '#Region "f_FileDialog �t�@�C���_�C�A���O�̕\��"
    '    '------------------------------------------------------------------
    '    '�v���V�[�W����  :f_FileDialog
    '    '����            :�t�@�C���_�C�A���O�̕\��
    '    '�����@�@�@�@�@�@:1. OutputMode    String  PDF�o�͂̏ꍇ:"pdf" Excel�o�͂̏ꍇ:"xls" CSV�o�͂̏ꍇ:"csv"
    '    '�@�@�@�@�@�@�@�@:2. fileNm(ByRef) String  [�Q�Ǝ�]���[ID & ���[�����Z�b�g [�߂�]�t�@�C�������܂ރp�X
    '    '�߂�l          :Boolean(����True/�G���[False)
    '    '------------------------------------------------------------------
    '    Public Function f_FileDialog(ByVal OutputMode As String, ByRef fileNm As String) As Boolean

    '        ' OpenFileDialog �̐V�����C���X�^���X�𐶐����� (�f�U�C�i����ǉ����Ă���ꍇ�͕K�v�Ȃ�)
    '        Dim OpenFileDialog1 As New SaveFileDialog

    '        Try
    '            OpenFileDialog1.Title = "���O��t���ĕۑ�"

    '            Select Case OutputMode
    '                Case "pdf"
    '                    'PDF�o��

    '                    '�����l�𐧌�}�X�^�ݒ�̃p�X�ɂ���B
    '                    OpenFileDialog1.InitialDirectory = myREPORT_PDF_PATH
    '                    '�t�@�C���̎�ނ�ݒ�
    '                    OpenFileDialog1.Filter = "PDF�t�@�C��(*.pdf)|*.pdf"

    '                Case "xls"
    '                    'Excel�o��

    '                    '�����l�𐧌�}�X�^�ݒ�̃p�X�ɂ���B
    '                    OpenFileDialog1.InitialDirectory = myREPORT_EXCEL_PATH
    '                    '�t�@�C���̎�ނ�ݒ�
    '                    OpenFileDialog1.Filter = "Excel 97-2003 �u�b�N(*.xls)|*.xls"


    '                Case "xlsx"         '2015/03/23 ADD Start
    '                    'Excel�o��
    '                    '�����l�𐧌�}�X�^�ݒ�̃p�X�ɂ���B
    '                    OpenFileDialog1.InitialDirectory = myREPORT_EXCEL_PATH
    '                    '�t�@�C���̎�ނ�ݒ�
    '                    OpenFileDialog1.Filter = "Excel �u�b�N(*.xlsx)|*.xlsx"
    '                    '2015/03/23 ADD End

    '                Case "csv"
    '                    'CSV�o��

    '                    '�����l�𐧌�}�X�^�ݒ�̃p�X�ɂ���B
    '                    OpenFileDialog1.InitialDirectory = myREPORT_EXCEL_PATH
    '                    '�t�@�C���̎�ނ�ݒ�
    '                    OpenFileDialog1.Filter = "CSV�J���}��؂�(*.csv)|*.csv"


    '            End Select

    '            ' �����\������t�@�C������ݒ肷��(���[ID+���[��+yyyyMMddHHmmss[+.pdf/.xls])
    '            OpenFileDialog1.FileName = fileNm & Now.ToString("yyyyMMddHHmmss")

    '            '' �_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌����� (�����l False)
    '            OpenFileDialog1.RestoreDirectory = True
    '            '���[�U�[�����ɑ��݂���t�@�C�������w�肵���ꍇ�� [���O��t���ĕۑ�] �_�C�A���O �{�b�N�X�Ōx����\�����邩�ǂ����������l���擾�܂��͐ݒ肵�܂��B
    '            OpenFileDialog1.OverwritePrompt = True

    '            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
    '                fileNm = OpenFileDialog1.FileName
    '            Else
    '                fileNm = ""
    '                Return False
    '            End If

    '            Return True

    '        Catch ex As Exception
    '            Throw New Exception(ex.Message)
    '        Finally
    '            OpenFileDialog1.Dispose()
    '        End Try

    '    End Function
    '#End Region

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
        'If f_FileDialog("csv", wkFileName) = False Then
        '    Return False
        'End If
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

            'f_Select_ODP(wkDS, wkSB.ToString)

            With wkDS
                If .Tables(0).Rows.Count <> 0 Then
                    pSYORI_KBN = wkDS.Tables(0).Rows(0)("SYORI_KBN")
                    pJIGYO_NENDO = wkDS.Tables(0).Rows(0)("JIGYO_NENDO")
                    pTAISYO_NENDO = wkDS.Tables(0).Rows(0)("TAISYO_NENDO")
                    'pTAISYO_SIHANKI = wkDS.Tables(0).Rows(0)("TAISYO_SIHANKI")
                    pREG_DATE = wkDS.Tables(0).Rows(0)("REG_DATE")
                    'pREG_ID = wkDS.Tables(0).Rows(0)("REG_ID")
                    'pREG_ID = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("REG_ID"))
                    pUP_DATE = wkDS.Tables(0).Rows(0)("UP_DATE")
                    'pUP_ID = wkDS.Tables(0).Rows(0)("UP_ID")
                    ' pUP_ID = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("UP_ID"))
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

            'f_Select_ODP(wkDS, wkSB.ToString)

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

            'f_Select_ODP(wkDS, wkSB.ToString)

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

            'f_Select_ODP(wkDS, wkSB.ToString)

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
                    ' pREG_ID = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("REG_ID"))
                    pUP_DATE = wkDS.Tables(0).Rows(0)("UP_DATE")
                    ' pUP_ID = WordHenkan("N", "S", wkDS.Tables(0).Rows(0)("UP_ID"))

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

        'f_Select_ODP(wkDS, wkSB.ToString)

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

        'f_Select_ODP(wkDS, wkSB.ToString)

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

        'f_Select_ODP(wkDS, wkSB.ToString)

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

        'f_Select_ODP(wkDS, wkSB.ToString)

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

        'f_Select_ODP(wkDS, wkSB.ToString)

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

        'f_Select_ODP(wkDS, wkSB.ToString)

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
    '    'Dim bmp = New Bitmap(myAssembly.GetManifestResourceStream("JbdGjsCommon.inei.gif"))

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
                'MessageBox.Show("�������`�l(�J�i)�Ɏg�p�ł��Ȃ��������܂܂�Ă��܂��B" & vbCrLf & vbCrLf &
                '                "�g�p�\����" & vbCrLf &
                '                "�����@�@�@�@�@0 1 2 3 4 5 6 7 8 9" & vbCrLf &
                '                "�p���@�@�@�@�@A B C D E F G H I J K L M " & vbCrLf &
                '                "�@�@�@�@�@�@�@N O P Q R S T U V W X Y Z" & vbCrLf &
                '                "�J�i�����@�@�@� � � � � � � � � � � � � � � � � � � � " & vbCrLf &
                '                "�@�@�@�@�@�@�@� � � � � � � � � � � � � � � � � � � � � � � � �" & vbCrLf &
                '                "���_�E�����_�@� �" & vbCrLf &
                '                "�L���@�@�@�@�@. ( ) - " & vbCrLf &
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

            'Call f_Select_ODP(dstDataSet, sSql)

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

End Class
