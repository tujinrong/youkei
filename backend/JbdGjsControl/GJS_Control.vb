'*******************************************************************************
'*�@�@�@�@���W���[�����@�@�@JbdGjsControl
'*
'*�@�@�A�@�@�\�T�v�@�@�@�@�@GJS���ʃ��W���[��
'*
'*  �@�B�@�X�V�����@�@�@�@�@R5OSVerUP�Ή� �V�K�쐬
'*******************************************************************************
Option Strict Off
Option Explicit On

Imports System.Data
Imports JbdGjsCommon

Public Module GJS_Control

#Region "*** �}�X�^�f�[�^�擾 ***"
#Region "f_CodeMaster_Data_Select �R�[�h�}�X�^�f�[�^�擾"
    '------------------------------------------------------------------
    '�v���V�[�W����  :f_CodeMaster_Data_Select
    '����            :�R�[�h�}�X�^�������œn���ꂽ�f�[�^�敪�ɊY������
    '                 �R�[�h�Ɩ��̂��擾���A�R���{�{�b�N�X�ɃZ�b�g����
    '
    '����            :1.cmbCd  JBD.Gjs.Win.GcComboBox       �R�[�h�R���{�{�b�N�X
    '                 2.cmbMei JBD.Gjs.Win.GcComboBox       ���̃R���{�{�b�N�X
    '                 3.sDATA_KBN   String(Optional)        �f�[�^�敪(4:������ʃf�[�^ 5:�s���{���f�[�^)
    '                 4.blnNullAddFlg   Boolean             �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '                 5.nRYAKU_KBN  Integer                 �������́A���̋敪  0:��������(����)  1:����
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_CodeMaster_Data_Select(ByRef cmbCd As JBD.Gjs.Win.GcComboBox, _
                                             ByRef cmbMei As JBD.Gjs.Win.GcComboBox, _
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

            cmbCd.Items.Clear()
            cmbMei.Items.Clear()

            With dstDataKen.Tables(0)
                If .Rows.Count > 0 Then
                    For i As Integer = 0 To .Rows.Count - 1
                        cmbCd.Items.Add(WordHenkan("N", "S", .Rows(i)("MEISYO_CD")))
                        cmbMei.Items.Add(WordHenkan("N", "S", .Rows(i)("MEISYO")))
                    Next

                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                    If blnNullAddFlg Then
                        '�R���{�󔒍��ڒǉ�
                        cmbCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                Else
                    '�G���[���X�g�o�͂Ȃ�
                    Show_MessageBox("I002", "") '�Y���f�[�^�����݂��܂���B
                End If
            End With

            f_CodeMaster_Data_Select = True

        Catch ex As Exception
            '���ʗ�O����
            Show_MessageBox("", ex.Message)
        End Try

    End Function
    Public Function f_CodeMaster_Data_Select(ByRef cmbCd As JBD.Gjs.Win.GcComboBox, _
                                         ByRef cmbMei As JBD.Gjs.Win.GcComboBox, _
                                         ByVal nDATA_KBN As Integer, _
                                         ByVal blnNullAddFlg As Boolean) As Boolean
        If Not f_CodeMaster_Data_Select(cmbCd, cmbMei, nDATA_KBN, blnNullAddFlg, 0) Then
            Return False
        End If

        Return True
    End Function
    Public Function f_CodeMaster_Data_Select(ByRef cmbCd As JBD.Gjs.Win.GcComboBox, _
                                         ByRef cmbMei As JBD.Gjs.Win.GcComboBox, _
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
    '����            :1.cmbKenCd        JBD.Gjs.Win.GcComboBox      ���R�[�h�R���{�{�b�N�X
    '                 2.cmbKenMei       JBD.Gjs.Win.GcComboBox      �����R���{�{�b�N�X
    '                 3.blnNullAddFlg   Boolean                     �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '                 4.sDATA_KBN       Integer(Optional)           �f�[�^�敪(Default:5�@�����f�[�^)
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_Ken_Data_Select(ByRef cmbKenCd As JBD.Gjs.Win.GcComboBox, _
                                      ByRef cmbKenMei As JBD.Gjs.Win.GcComboBox, _
                                      ByRef blnNullAddFlg As Boolean, _
                                      ByVal nDATA_KBN As Integer) As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataKenCd As New DataSet
        Dim dstDataKenNm As New DataSet
        Dim subItem1 As New GrapeCity.Win.Editors.SubItem()
        Dim subItem2 As New GrapeCity.Win.Editors.SubItem()

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

            cmbKenCd.Items.Clear()
            cmbKenMei.Items.Clear()

            With dstDataKenCd.Tables(0)
                If .Rows.Count > 0 Then

                    'cmbKenCd.AutoGenerateColumns = True
                    'cmbKenCd.DataSource = dstDataKenCd
                    'cmbKenCd.DataMember = "MEISYO_CD"

                    'cmbKenMei.ListColumns.Add(New GrapeCity.Win.Editors.ListColumn("MEISYO_CD"))
                    'cmbKenMei.ListColumns.Add(New GrapeCity.Win.Editors.ListColumn("RYAKUSYO"))

                    For i As Integer = 0 To .Rows.Count - 1
                        cmbKenCd.Items.Add(WordHenkan("N", "S", .Rows(i)("MEISYO_CD")))
                        '2015/01/21 JBD368 UPD ������ �s���{�����͐������̂��g�p����
                        'cmbKenMei.Items.Add(WordHenkan("N", "S", .Rows(i)("RYAKUSYO")))
                        cmbKenMei.Items.Add(WordHenkan("N", "S", .Rows(i)("MEISYO")))
                        '2015/02/21 JBD368 UPD ������

                        'subItem1.Value = WordHenkan("N", "S", .Rows(i)("MEISYO_CD"))
                        'subItem2.Value = WordHenkan("N", "S", .Rows(i)("RYAKUSYO"))
                        'cmbKenMei.Items.AddRange(New GrapeCity.Win.Editors.ListItem(New GrapeCity.Win.Editors.SubItem() {subItem1, subItem2}))

                        'cmbKenMei.Items.Add("")
                        'cmbKenMei.ListColumns.Item(0).DataPropertyName = WordHenkan("N", "S", .Rows(i)("MEISYO_CD"))
                        'cmbKenMei.ListColumns.Item(1).DataPropertyName = WordHenkan("N", "S", .Rows(i)("RYAKUSYO"))

                    Next

                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                    If blnNullAddFlg Then
                        '���}�X�^�R���{�󔒍��ڒǉ�
                        cmbKenCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbKenMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                Else
                    '�G���[���X�g�o�͂Ȃ�
                    Show_MessageBox("I002", "") '�Y���f�[�^�����݂��܂���B
                    'Show_MessageBox("�Y���f�[�^�����݂��܂���B", C_MSGICON_INFORMATION) '�Y���f�[�^�����݂��܂���B
                End If
            End With


            f_Ken_Data_Select = True

        Catch ex As Exception
            '���ʗ�O����
            Show_MessageBox("", ex.Message)
        End Try

    End Function
    Public Function f_Ken_Data_Select(ByRef cmbKenCd As JBD.Gjs.Win.GcComboBox, _
                                  ByRef cmbKenMei As JBD.Gjs.Win.GcComboBox, _
                                  ByRef blnNullAddFlg As Boolean) As Boolean
        If Not f_Ken_Data_Select(cmbKenCd, cmbKenMei, blnNullAddFlg, 5) Then
            Return False
        End If

        Return True
    End Function
    Public Function f_Ken_Data_Select(ByRef cmbKenCd As JBD.Gjs.Win.GcComboBox, _
                                  ByRef cmbKenMei As JBD.Gjs.Win.GcComboBox) As Boolean
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
    '����            :1.cmbSankaCd  JBD.Gjs.Win.GcComboBox     �㗝�l�R�[�h�R���{�{�b�N�X
    '                 2.cmbSankaMei JBD.Gjs.Win.GcComboBox     �㗝�l���R���{�{�b�N�X
    '                 3.blnNullAddFlg   Boolean                �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_Itaku_Data_Select(ByRef cmbItakuCd As JBD.Gjs.Win.GcComboBox, _
                                          ByRef cmbItakuMei As JBD.Gjs.Win.GcComboBox, _
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

            cmbItakuCd.Items.Clear()
            cmbItakuMei.Items.Clear()

            With dstDataItaku.Tables(0)
                If .Rows.Count > 0 Then
                    For i As Integer = 0 To .Rows.Count - 1
                        cmbItakuCd.Items.Add(WordHenkan("N", "S", .Rows(i)("ITAKU_CD")))
                        cmbItakuMei.Items.Add(WordHenkan("N", "S", .Rows(i)("ITAKU_NAME")))
                    Next

                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                    If blnNullAddFlg Then
                        '�R���{�󔒍��ڒǉ�
                        cmbItakuCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbItakuMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                End If
            End With

            '�Y���f�[�^����(�ϑ���g�p��)
            cmbItakuCd.Enabled = True
            cmbItakuMei.Enabled = True

            f_Itaku_Data_Select = True

        Catch ex As Exception
            '���ʗ�O����
            Show_MessageBox("", ex.Message)
        End Try

    End Function
    Public Function f_Itaku_Data_Select(ByRef cmbItakuCd As JBD.Gjs.Win.GcComboBox, _
                                          ByRef cmbItakuMei As JBD.Gjs.Win.GcComboBox) As Boolean

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
    '����            :1.cmbSeisanCd     JBD.Gjs.Win.GcComboBox   ���Y�҃R�[�h�R���{�{�b�N�X
    '                 2.cmbSeisanMei    JBD.Gjs.Win.GcComboBox   ���Y�Җ��R���{�{�b�N�X
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
    Public Function f_Seisansya_Data_Select(ByRef cmbSeisanCd As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanMei As JBD.Gjs.Win.GcComboBox, _
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

            cmbSeisanCd.Items.Clear()
            cmbSeisanMei.Items.Clear()

            With dstDataSanka.Tables(0)
                If .Rows.Count > 0 Then
                    For i As Integer = 0 To .Rows.Count - 1
                        cmbSeisanCd.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_CD")))
                        cmbSeisanMei.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_NAME")))
                    Next

                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                    If blnNullAddFlg Then
                        '�R���{�󔒍��ڒǉ�
                        cmbSeisanCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSeisanMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                End If
            End With

            '���Y�҃R�[�h�g�p��
            cmbSeisanCd.Enabled = True
            cmbSeisanMei.Enabled = True

            f_Seisansya_Data_Select = True

        Catch ex As Exception
            '���ʗ�O����
            Show_MessageBox("", ex.Message)
        End Try

    End Function
    Public Function f_Seisansya_Data_Select(ByRef cmbSeisanCd As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanMei As JBD.Gjs.Win.GcComboBox, _
                                            ByVal strWhere As String, _
                                            ByVal nKensakuKbn As Integer) As Boolean
        If Not f_Seisansya_Data_Select(cmbSeisanCd, cmbSeisanMei, strWhere, nKensakuKbn, False) Then
            Return False
        End If
        Return True
    End Function
    Public Function f_Seisansya_Data_Select(ByRef cmbSeisanCd As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanMei As JBD.Gjs.Win.GcComboBox, _
                                            ByVal strWhere As String) As Boolean
        If Not f_Seisansya_Data_Select(cmbSeisanCd, cmbSeisanMei, strWhere, 0, False) Then
            Return False
        End If
        Return True
    End Function
    Public Function f_Seisansya_Data_Select(ByRef cmbSeisanCd As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanMei As JBD.Gjs.Win.GcComboBox) As Boolean
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
    '����            :1.cmbItakuCdFm   JBD.Gjs.Win.GcComboBox     �㗝�l�R�[�h�R���{�{�b�N�XFROM
    '                 2.cmbSeisanCdFm  JBD.Gjs.Win.GcComboBox     ���Y�҃R�[�h�R���{�{�b�N�XFROM
    '                 3.cmbSeisanMeiFm JBD.Gjs.Win.GcComboBox     ���Y�Җ��R���{�{�b�N�XFROM
    '                 4.blnNullAddFlg   Boolean                   �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '                 5.cmbItakuCdTo   JBD.Gjs.Win.GcComboBox     �㗝�l�R�[�h�R���{�{�b�N�XTO
    '                 6.cmbSeisanCdTo  JBD.Gjs.Win.GcComboBox     ���Y�҃R�[�h�R���{�{�b�N�XTO
    '                 7.cmbSeisanMeiTo JBD.Gjs.Win.GcComboBox     ���Y�Җ��R���{�{�b�N�XTO
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_Itaku_Seisansya_Data_Select(ByRef cmbItakuCdFm As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanCdFm As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanMeiFm As JBD.Gjs.Win.GcComboBox, _
                                            ByVal blnNullAddFlg As Boolean, _
                                            ByRef cmbItakuCdTo As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanCdTo As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanMeiTo As JBD.Gjs.Win.GcComboBox) As Boolean

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
                If cmbItakuCdFm.Text = "" Then
                    ' �㗝�l�R�[�hFROM�͖��w��
                    ' ����Đ��Y�҂͑S��
                Else
                    ' �㗝�l�R�[�hFROM�͎w�肳��Ă���
                    ' ����Đ��Y��FROM�͑㗝�l�R�[�hFROM�ƈ�v������̂��Ώ�
                    sWhere = sWhere & "  ITAKU_CD = '" & cmbItakuCdFm.Text & "'" & vbCrLf
                End If
            Else
                '�㗝�l�R�[�hTo�͎w�肳��Ă���
                If cmbItakuCdFm.Text = "" Or cmbItakuCdTo.Text = "" Then
                    ' �㗝�l�R�[�hFROM�܂���TO�͖��w��
                    ' ����Đ��Y��FROM�����TO�͑S��
                Else
                    If cmbItakuCdFm.Text <> cmbItakuCdTo.Text Then
                        ' �㗝�l�R�[�hFROM��TO�͓���łȂ�
                        ' ����Đ��Y��FROM�����TO�͑S��
                    Else
                        ' �㗝�l�R�[�hFROM��TO�͓���ł���
                        ' ����Đ��Y��FROM�����TO�͑㗝�l�R�[�h�ƈ�v������̂��Ώ�
                        sWhere = sWhere & "  ITAKU_CD = '" & cmbItakuCdFm.Text & "'" & vbCrLf
                    End If
                End If
            End If

            If sWhere <> "" Then
                sSql = sSql & " WHERE" & vbCrLf
                sSql = sSql & sWhere
            End If
            sSql = sSql & " ORDER BY SEISANSYA_CD" & vbCrLf

            Call f_Select_ODP(dstDataSanka, sSql)


            cmbSeisanCdFm.Items.Clear()
            cmbSeisanMeiFm.Items.Clear()
            If cmbItakuCdTo Is Nothing Or cmbSeisanCdTo Is Nothing Or cmbSeisanMeiTo Is Nothing Then
            Else
                cmbSeisanCdTo.Items.Clear()
                cmbSeisanMeiTo.Items.Clear()
            End If

            With dstDataSanka.Tables(0)
                If .Rows.Count > 0 Then
                    For i As Integer = 0 To .Rows.Count - 1
                        cmbSeisanCdFm.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_CD")))
                        cmbSeisanMeiFm.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_NAME")))
                        If cmbItakuCdTo Is Nothing Or cmbSeisanCdTo Is Nothing Or cmbSeisanMeiTo Is Nothing Then
                        Else
                            cmbSeisanCdTo.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_CD")))
                            cmbSeisanMeiTo.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_NAME")))
                        End If
                    Next

                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                    If blnNullAddFlg Then
                        '�R���{�󔒍��ڒǉ�
                        cmbSeisanCdFm.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSeisanMeiFm.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                        If cmbItakuCdTo Is Nothing Or cmbSeisanCdTo Is Nothing Or cmbSeisanMeiTo Is Nothing Then
                        Else
                            '�R���{�󔒍��ڒǉ�
                            cmbSeisanCdTo.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSeisanMeiTo.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                        End If
                    End If
                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                End If
            End With

            '���Y�҃R�[�h�g�p��
            cmbSeisanCdFm.Enabled = True
            cmbSeisanMeiFm.Enabled = True
            If cmbItakuCdTo Is Nothing Or cmbSeisanCdTo Is Nothing Or cmbSeisanMeiTo Is Nothing Then
            Else
                cmbSeisanCdTo.Enabled = True
                cmbSeisanMeiTo.Enabled = True
            End If

            f_Itaku_Seisansya_Data_Select = True

        Catch ex As Exception
            '���ʗ�O����
            Show_MessageBox("", ex.Message)
        End Try

    End Function
    Public Function f_Itaku_Seisansya_Data_Select(ByRef cmbItakuCdFm As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanCdFm As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanMeiFm As JBD.Gjs.Win.GcComboBox, _
                                            ByVal blnNullAddFlg As Boolean, _
                                            ByRef cmbItakuCdTo As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanCdTo As JBD.Gjs.Win.GcComboBox) As Boolean

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
    Public Function f_Itaku_Seisansya_Data_Select(ByRef cmbItakuCdFm As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanCdFm As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanMeiFm As JBD.Gjs.Win.GcComboBox, _
                                            ByVal blnNullAddFlg As Boolean, _
                                            ByRef cmbItakuCdTo As JBD.Gjs.Win.GcComboBox) As Boolean

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
    Public Function f_Itaku_Seisansya_Data_Select(ByRef cmbItakuCdFm As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanCdFm As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanMeiFm As JBD.Gjs.Win.GcComboBox, _
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
    Public Function f_Itaku_Seisansya_Data_Select(ByRef cmbItakuCdFm As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanCdFm As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbSeisanMeiFm As JBD.Gjs.Win.GcComboBox) As Boolean

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
    '����            :1.cmbBankCd  JBD.Gjs.Win.GcComboBox       ���Z�@�փR�[�h�R���{�{�b�N�X
    '                 2.cmbBankMei JBD.Gjs.Win.GcComboBox       ���Z�@�֖��R���{�{�b�N�X
    '                 3.blnNullAddFlg   Boolean                 �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '                 4.sDATA_KBN   String(Optional)            �f�[�^�敪(Default:"")
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_Bank_Data_Select(ByRef cmbBankCd As JBD.Gjs.Win.GcComboBox, _
                                       ByRef cmbBankMei As JBD.Gjs.Win.GcComboBox, _
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

            cmbBankCd.Items.Clear()
            cmbBankMei.Items.Clear()

            With dstDataSet.Tables(0)
                If .Rows.Count > 0 Then

                    For i As Integer = 0 To .Rows.Count - 1
                        cmbBankCd.Items.Add(WordHenkan("N", "S", .Rows(i)("BANK_CD")))
                        cmbBankMei.Items.Add(WordHenkan("N", "S", .Rows(i)("BANK_NAME")))
                    Next

                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                    If blnNullAddFlg Then
                        '�R���{�󔒍��ڒǉ�
                        cmbBankCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbBankMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                Else
                    '�G���[���X�g�o�͂Ȃ�
                    Show_MessageBox("I002", "") '�Y���f�[�^�����݂��܂���B
                    'Show_MessageBox("�Y���f�[�^�����݂��܂���B", C_MSGICON_INFORMATION)
                End If
            End With

            f_Bank_Data_Select = True

        Catch ex As Exception
            '���ʗ�O����
            Show_MessageBox("", ex.Message)
        Finally
            dstDataSet.Dispose()
        End Try


    End Function
    Public Function f_Bank_Data_Select(ByRef cmbBankCd As JBD.Gjs.Win.GcComboBox, _
                                       ByRef cmbBankMei As JBD.Gjs.Win.GcComboBox, _
                                       ByVal blnNullAddFlg As Boolean) As Boolean

        If Not f_Bank_Data_Select(cmbBankCd,
                                  cmbBankMei,
                                  blnNullAddFlg,
                                  "") Then
            Return False
        End If
        Return True
    End Function
    Public Function f_Bank_Data_Select(ByRef cmbBankCd As JBD.Gjs.Win.GcComboBox, _
                                       ByRef cmbBankMei As JBD.Gjs.Win.GcComboBox) As Boolean

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
    '����            :1.cmbShopCd  JBD.Gjs.Win.GcComboBox       ���Z�@�֎x�X�R�[�h�R���{�{�b�N�X
    '                 2.cmbShopMei JBD.Gjs.Win.GcComboBox       ���Z�@�֎x�X���R���{�{�b�N�X
    '                 3.sBankCD     String                      ���Z�@�փR�[�h
    '                 4.blnNullAddFlg   Boolean                 �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '                 5.sDATA_KBN   String(Optional)            �f�[�^�敪(Default:"")
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_BankShop_Data_Select(ByRef cmbShopCd As JBD.Gjs.Win.GcComboBox, _
                                       ByRef cmbShopMei As JBD.Gjs.Win.GcComboBox, _
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

            cmbShopCd.Items.Clear()
            cmbShopMei.Items.Clear()

            With dstDataSet.Tables(0)
                If .Rows.Count > 0 Then

                    For i As Integer = 0 To .Rows.Count - 1
                        cmbShopCd.Items.Add(WordHenkan("N", "S", .Rows(i)("SITEN_CD")))
                        cmbShopMei.Items.Add(WordHenkan("N", "S", .Rows(i)("SITEN_NAME")))
                    Next

                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                    If blnNullAddFlg Then
                        '�R���{�󔒍��ڒǉ�
                        cmbShopCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbShopMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                End If
            End With

            f_BankShop_Data_Select = True

        Catch ex As Exception
            '���ʗ�O����
            Show_MessageBox("", ex.Message)
        Finally
            dstDataSet.Dispose()
        End Try

    End Function
    Public Function f_BankShop_Data_Select(ByRef cmbShopCd As JBD.Gjs.Win.GcComboBox, _
                                       ByRef cmbShopMei As JBD.Gjs.Win.GcComboBox, _
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
    Public Function f_BankShop_Data_Select(ByRef cmbShopCd As JBD.Gjs.Win.GcComboBox, _
                                       ByRef cmbShopMei As JBD.Gjs.Win.GcComboBox, _
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
    '����            :1.cmbDoituSeisansyaCd  JBD.Gjs.Win.GcComboBox       ���ꐶ�Y�҃O���[�v�R�[�h�R���{�{�b�N�X
    '                 2.cmbDoituSeisansyaMei JBD.Gjs.Win.GcComboBox       ���ꐶ�Y�҃O���[�v���R���{�{�b�N�X
    '                 3.blnNullAddFlg   Boolean                 �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_Doitu_Seisansya_Data_Select(ByRef cmbDoituSeisansyaCd As JBD.Gjs.Win.GcComboBox, _
                                       ByRef cmbDoituSeisansyaMei As JBD.Gjs.Win.GcComboBox, _
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

            cmbDoituSeisansyaCd.Items.Clear()
            cmbDoituSeisansyaMei.Items.Clear()

            With dstDataSet.Tables(0)
                If .Rows.Count > 0 Then

                    For i As Integer = 0 To .Rows.Count - 1
                        cmbDoituSeisansyaCd.Items.Add(WordHenkan("N", "S", .Rows(i)("DOITU_SEISANSYA_CD")))
                        cmbDoituSeisansyaMei.Items.Add(WordHenkan("N", "S", .Rows(i)("DOITU_SEISANSYA_NAME")))
                    Next

                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                    If blnNullAddFlg Then
                        '�R���{�󔒍��ڒǉ�
                        cmbDoituSeisansyaCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbDoituSeisansyaMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                Else
                    '�G���[���X�g�o�͂Ȃ�
                    'Show_MessageBox("I002", "") '�Y���f�[�^�����݂��܂���B
                    'Show_MessageBox("�Y���f�[�^�����݂��܂���B", C_MSGICON_INFORMATION)
                End If
            End With

            f_Doitu_Seisansya_Data_Select = True

        Catch ex As Exception
            '���ʗ�O����
            Show_MessageBox("", ex.Message)
        Finally
            dstDataSet.Dispose()
        End Try

    End Function

    Public Function f_Doitu_Seisansya_Data_Select(ByRef cmbDoituSeisansyaCd As JBD.Gjs.Win.GcComboBox, _
                                       ByRef cmbDoituSeisansyaMei As JBD.Gjs.Win.GcComboBox) As Boolean

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
    '����            :1.cmbSyokucyoCd  JBD.Gjs.Win.GcComboBox       �H��������R�[�h�R���{�{�b�N�X
    '                 2.cmbSyokucyoMei JBD.Gjs.Win.GcComboBox       �H�������ꖼ�R���{�{�b�N�X
    '                 3.blnNullAddFlg   Boolean                 �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_Syokcyo_Data_Select(ByRef cmbSyokucyoCd As JBD.Gjs.Win.GcComboBox, _
                                                  ByRef cmbSyokucyoMei As JBD.Gjs.Win.GcComboBox, _
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

            cmbSyokucyoCd.Items.Clear()
            cmbSyokucyoMei.Items.Clear()

            With dstDataSet.Tables(0)
                If .Rows.Count > 0 Then

                    For i As Integer = 0 To .Rows.Count - 1
                        cmbSyokucyoCd.Items.Add(WordHenkan("N", "S", .Rows(i)("SYOKUCYO_CD")))
                        cmbSyokucyoMei.Items.Add(WordHenkan("N", "S", .Rows(i)("SYOKUCYO_NAME")))
                    Next

                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                    If blnNullAddFlg Then
                        '�R���{�󔒍��ڒǉ�
                        cmbSyokucyoCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSyokucyoMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                Else
                    '�G���[���X�g�o�͂Ȃ�
                    'Show_MessageBox("I002", "") '�Y���f�[�^�����݂��܂���B
                    'Show_MessageBox("�Y���f�[�^�����݂��܂���B", C_MSGICON_INFORMATION)
                End If
            End With

            f_Syokcyo_Data_Select = True

        Catch ex As Exception
            '���ʗ�O����
            Show_MessageBox("", ex.Message)
        Finally
            dstDataSet.Dispose()
        End Try

    End Function

    Public Function f_Syokcyo_Data_Select(ByRef cmbSyokucyoCd As JBD.Gjs.Win.GcComboBox, _
                                       ByRef cmbSyokucyoMei As JBD.Gjs.Win.GcComboBox) As Boolean

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
    '����            :1.cmbUserCd  JBD.Gjs.Win.GcComboBox       �S���҃R�[�h�R���{�{�b�N�X
    '                 2.cmbUserMei JBD.Gjs.Win.GcComboBox       �S���Җ��R���{�{�b�N�X
    '                 3.blnNullAddFlg   Boolean                 �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_User_Data_Select(ByRef cmbUserCd As JBD.Gjs.Win.GcComboBox, _
                                                  ByRef cmbUserMei As JBD.Gjs.Win.GcComboBox, _
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

            cmbUserCd.Items.Clear()
            cmbUserMei.Items.Clear()

            With dstDataSet.Tables(0)
                If .Rows.Count > 0 Then

                    For i As Integer = 0 To .Rows.Count - 1
                        cmbUserCd.Items.Add(WordHenkan("N", "S", .Rows(i)("USER_ID")))
                        cmbUserMei.Items.Add(WordHenkan("N", "S", .Rows(i)("USER_NAME")))
                    Next

                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                    If blnNullAddFlg Then
                        '�R���{�󔒍��ڒǉ�
                        cmbUserCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbUserMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                Else
                    '�G���[���X�g�o�͂Ȃ�
                    'Show_MessageBox("I002", "") '�Y���f�[�^�����݂��܂���B
                    'Show_MessageBox("�Y���f�[�^�����݂��܂���B", C_MSGICON_INFORMATION)
                End If
            End With

            f_User_Data_Select = True

        Catch ex As Exception
            '���ʗ�O����
            Show_MessageBox("", ex.Message)
        Finally
            dstDataSet.Dispose()
        End Try

    End Function

    Public Function f_User_Data_Select(ByRef cmbUserCd As JBD.Gjs.Win.GcComboBox, _
                                       ByRef cmbUserMei As JBD.Gjs.Win.GcComboBox) As Boolean

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
    '����            :1.cmbKeiyakuCd     JBD.Gjs.Win.GcComboBox   �_��҃R�[�h�R���{�{�b�N�X
    '                 2.cmbKeiyakuMei    JBD.Gjs.Win.GcComboBox   �_��Җ��R���{�{�b�N�X
    '                 3.strWhere        String                    �_��҃}�X�^�������� WHERE����w�肷��
    '                 4.blnNullAddFlg   Boolean                   �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '                 5.blnEnable       Boolean                   �R���{�̓��͉�(TRUE:���͉\ FALSE:���͕s��)
    '                 6.strUser       Boolean                   �@���X�L�[�}�̃f�[�^���K�v�Ȏ��A�X�L�[�}���Z�b�g(""�̂Ƃ��A���X�L�[�})   '2017/07/07�ǉ�
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As JBD.Gjs.Win.GcComboBox, _
                                          ByRef cmbKeiyakuMei As JBD.Gjs.Win.GcComboBox, _
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
        '    Show_MessageBox("", ex.Message)
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

            cmbKeiyakuCd.Clear()
            cmbKeiyakuMei.Clear()

            With dstDataSanka.Tables(0)
                If .Rows.Count > 0 Then

                    '�R���{�{�b�N�X�Ƀf�[�^���o�C���h
                    cmbKeiyakuCd.DataSource = dstDataSanka.Tables(0)
                    '�s�v�ȃJ�������폜����
                    cmbKeiyakuCd.ListColumns.RemoveAt(1)

                    '�R���{�{�b�N�X�Ƀf�[�^���o�C���h
                    cmbKeiyakuMei.DataSource = dstDataSanka.Tables(0)
                    '�s�v�ȃJ�������폜����
                    cmbKeiyakuMei.ListColumns.RemoveAt(0)
                    '���̂̃R���{�{�b�N�X�̕���ݒ�
                    cmbKeiyakuMei.ListColumns(0).Width = cmbKeiyakuMei.Width

                End If
            End With

            '�_��҃R�[�h�g�p��
            cmbKeiyakuCd.Enabled = blnEnable
            cmbKeiyakuMei.Enabled = blnEnable

            f_Keiyaku_Data_Select = True

        Catch ex As Exception
            '���ʗ�O����
            Show_MessageBox("", ex.Message)
        End Try

    End Function


    '------------------------------------------------------------------
    '�v���V�[�W����  :f_Keiyaku_Data_Select
    '����            :�_��҃f�[�^�擾
    '����            :1.cmbKeiyakuCd     JBD.Gjs.Win.GcComboBox   �_��҃R�[�h�R���{�{�b�N�X
    '                 2.cmbKeiyakuMei    JBD.Gjs.Win.GcComboBox   �_��Җ��R���{�{�b�N�X
    '                 3.strWhere        String                    �_��҃}�X�^�������� WHERE����w�肷��
    '                 4.blnNullAddFlg   Boolean                   �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '                 5.blnEnable       Boolean                   �R���{�̓��͉�(TRUE:���͉\ FALSE:���͕s��)
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As JBD.Gjs.Win.GcComboBox, _
                                          ByRef cmbKeiyakuMei As JBD.Gjs.Win.GcComboBox, _
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
    '����            :1.cmbKeiyakuCd     JBD.Gjs.Win.GcComboBox   �_��҃R�[�h�R���{�{�b�N�X
    '                 2.cmbKeiyakuMei    JBD.Gjs.Win.GcComboBox   �_��Җ��R���{�{�b�N�X
    '                 3.strWhere        String                    �_��҃}�X�^�������� WHERE����w�肷��
    '                 4.blnNullAddFlg   Boolean                   �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As JBD.Gjs.Win.GcComboBox, _
                                                ByRef cmbKeiyakuMei As JBD.Gjs.Win.GcComboBox, _
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
    '����            :1.cmbKeiyakuCd     JBD.Gjs.Win.GcComboBox   �_��҃R�[�h�R���{�{�b�N�X
    '                 2.cmbKeiyakuMei    JBD.Gjs.Win.GcComboBox   �_��Җ��R���{�{�b�N�X
    '                 3.strWhere        String                    �_��҃}�X�^�������� WHERE����w�肷��
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As JBD.Gjs.Win.GcComboBox, _
                                                ByRef cmbKeiyakuMei As JBD.Gjs.Win.GcComboBox, _
                                                ByVal strWhere As String) As Boolean

        If Not f_Keiyaku_Data_Select(cmbKeiyakuCd, cmbKeiyakuMei, strWhere, False, True) Then
            Return False
        End If

        Return True

    End Function

    '------------------------------------------------------------------
    '�v���V�[�W����  :f_Keiyaku_Data_Select
    '����            :�_��҃f�[�^�擾
    '����            :1.cmbKeiyakuCd     JBD.Gjs.Win.GcComboBox   �_��҃R�[�h�R���{�{�b�N�X
    '                 2.cmbKeiyakuMei    JBD.Gjs.Win.GcComboBox   �_��Җ��R���{�{�b�N�X
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As JBD.Gjs.Win.GcComboBox, _
                                             ByRef cmbKeiyakuMei As JBD.Gjs.Win.GcComboBox) As Boolean

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
    '����            :1.cmbJimuItakuCd     JBD.Gjs.Win.GcComboBox   �����ϑ���R�[�h�R���{�{�b�N�X
    '                 2.cmbJimuItakuMei    JBD.Gjs.Win.GcComboBox   �����ϑ��於�R���{�{�b�N�X
    '                 3.strWhere        String                      �����ϑ���}�X�^�������� WHERE����w�肷��
    '                 4.blnNullAddFlg   Boolean                     �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_JimuItaku_Data_Select(ByRef cmbJimuItakuCd As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbJimuItakuMei As JBD.Gjs.Win.GcComboBox, _
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
        '    Show_MessageBox("", ex.Message)
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

            cmbJimuItakuCd.Clear()
            cmbJimuItakuMei.Clear()

            With dstDataSanka.Tables(0)
                If .Rows.Count > 0 Then
                    '�R���{�{�b�N�X�Ƀf�[�^���o�C���h
                    cmbJimuItakuCd.DataSource = dstDataSanka.Tables(0)
                    '�s�v�ȃJ�������폜����
                    cmbJimuItakuCd.ListColumns.RemoveAt(1)

                    '�R���{�{�b�N�X�Ƀf�[�^���o�C���h
                    cmbJimuItakuMei.DataSource = dstDataSanka.Tables(0)
                    '�s�v�ȃJ�������폜����
                    cmbJimuItakuMei.ListColumns.RemoveAt(0)
                    '���̂̃R���{�{�b�N�X�̕���ݒ�
                    cmbJimuItakuMei.ListColumns(0).Width = cmbJimuItakuMei.Width
                End If
            End With

            '�����ϑ���R�[�h�g�p��
            cmbJimuItakuCd.Enabled = blnEnable
            cmbJimuItakuMei.Enabled = blnEnable

            f_JimuItaku_Data_Select = True

        Catch ex As Exception
            '���ʗ�O����
            Show_MessageBox("", ex.Message)
        End Try
        '2015/03/03 JBD368 UPD ������

    End Function

    '------------------------------------------------------------------
    '�v���V�[�W����  :f_JimuItaku_Data_Select
    '����            :�����ϑ���f�[�^�擾
    '����            :1.cmbJimuItakuCd     JBD.Gjs.Win.GcComboBox   �����ϑ���R�[�h�R���{�{�b�N�X
    '                 2.cmbJimuItakuMei    JBD.Gjs.Win.GcComboBox   �����ϑ��於�R���{�{�b�N�X
    '                 3.strWhere        String                    �����ϑ���}�X�^�������� WHERE����w�肷��
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_JimuItaku_Data_Select(ByRef cmbJimuItakuCd As JBD.Gjs.Win.GcComboBox, _
                                                ByRef cmbJimuItakuMei As JBD.Gjs.Win.GcComboBox, _
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
    '����            :1.cmbJimuItakuCd     JBD.Gjs.Win.GcComboBox   �����ϑ���R�[�h�R���{�{�b�N�X
    '                 2.cmbJimuItakuMei    JBD.Gjs.Win.GcComboBox   �����ϑ��於�R���{�{�b�N�X
    '                 3.strWhere        String                    �����ϑ���}�X�^�������� WHERE����w�肷��
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_JimuItaku_Data_Select(ByRef cmbJimuItakuCd As JBD.Gjs.Win.GcComboBox, _
                                                ByRef cmbJimuItakuMei As JBD.Gjs.Win.GcComboBox, _
                                                ByVal strWhere As String) As Boolean

        If Not f_JimuItaku_Data_Select(cmbJimuItakuCd, cmbJimuItakuMei, strWhere, False, True) Then
            Return False
        End If

        Return True

    End Function

    '------------------------------------------------------------------
    '�v���V�[�W����  :f_JimuItaku_Data_Select
    '����            :�����ϑ���f�[�^�擾
    '����            :1.cmbJimuItakuCd     JBD.Gjs.Win.GcComboBox   �����ϑ���R�[�h�R���{�{�b�N�X
    '                 2.cmbJimuItakuMei    JBD.Gjs.Win.GcComboBox   �����ϑ��於�R���{�{�b�N�X
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_JimuItaku_Data_Select(ByRef cmbJimuItakuCd As JBD.Gjs.Win.GcComboBox, _
                                             ByRef cmbJimuItakuMei As JBD.Gjs.Win.GcComboBox) As Boolean

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
    '����            :1.cmbKeiyakuNojoCd     JBD.Gjs.Win.GcComboBox   �_��_��R�[�h�R���{�{�b�N�X
    '                 2.cmbKeiyakuNojoMei    JBD.Gjs.Win.GcComboBox   �_��_�ꖼ�R���{�{�b�N�X
    '                 3.strWhere        String                      �_��_��}�X�^�������� WHERE����w�肷��
    '                 4.blnNullAddFlg   Boolean                     �X�y�[�X���ڂ��R���{�ɒǉ����邩���Ȃ����̃t���O(False(����):�X�y�[�X���ڂ�ǉ����Ȃ��@True:�X�y�[�X���ڂ�ǉ�����)
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_KeiyakuNojo_Data_Select(ByRef cmbKeiyakuNojoCd As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbKeiyakuNojoMei As JBD.Gjs.Win.GcComboBox, _
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

            cmbKeiyakuNojoCd.Items.Clear()
            cmbKeiyakuNojoMei.Items.Clear()

            With dstDataSanka.Tables(0)
                If .Rows.Count > 0 Then
                    For i As Integer = 0 To .Rows.Count - 1
                        cmbKeiyakuNojoCd.Items.Add(WordHenkan("N", "S", .Rows(i)("NOJO_CD")))
                        cmbKeiyakuNojoMei.Items.Add(WordHenkan("N", "S", .Rows(i)("NOJO_NAME")))
                    Next

                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��
                    If blnNullAddFlg Then
                        '�R���{�󔒍��ڒǉ�
                        cmbKeiyakuNojoCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbKeiyakuNojoMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '��***** 2010/09/15 JBD200 ADD ��3����=True�̎��A�󔒍��ڂ�ǉ�����悤�ǉ� *****��

                End If
            End With

            '�_��_��R�[�h�g�p��
            cmbKeiyakuNojoCd.Enabled = blnEnable
            cmbKeiyakuNojoMei.Enabled = blnEnable

            f_KeiyakuNojo_Data_Select = True

        Catch ex As Exception
            '���ʗ�O����
            Show_MessageBox("", ex.Message)
        End Try

    End Function

    '------------------------------------------------------------------
    '�v���V�[�W����  :f_KeiyakuNojo_Data_Select
    '����            :�_��_��f�[�^�擾
    '����            :1.cmbKeiyakuNojoCd     JBD.Gjs.Win.GcComboBox   �_��_��R�[�h�R���{�{�b�N�X
    '                 2.cmbKeiyakuNojoMei    JBD.Gjs.Win.GcComboBox   �_��_�ꖼ�R���{�{�b�N�X
    '                 3.strWhere        String                    �_��_��}�X�^�������� WHERE����w�肷��
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_KeiyakuNojo_Data_Select(ByRef cmbKeiyakuNojoCd As JBD.Gjs.Win.GcComboBox, _
                                                ByRef cmbKeiyakuNojoMei As JBD.Gjs.Win.GcComboBox, _
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
    '����            :1.cmbKeiyakuNojoCd     JBD.Gjs.Win.GcComboBox   �_��_��R�[�h�R���{�{�b�N�X
    '                 2.cmbKeiyakuNojoMei    JBD.Gjs.Win.GcComboBox   �_��_�ꖼ�R���{�{�b�N�X
    '                 3.strWhere        String                    �_��_��}�X�^�������� WHERE����w�肷��
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_KeiyakuNojo_Data_Select(ByRef cmbKeiyakuNojoCd As JBD.Gjs.Win.GcComboBox, _
                                                ByRef cmbKeiyakuNojoMei As JBD.Gjs.Win.GcComboBox, _
                                                ByVal strWhere As String) As Boolean

        If Not f_KeiyakuNojo_Data_Select(cmbKeiyakuNojoCd, cmbKeiyakuNojoMei, strWhere, False, True) Then
            Return False
        End If

        Return True

    End Function

    '------------------------------------------------------------------
    '�v���V�[�W����  :f_KeiyakuNojo_Data_Select
    '����            :�_��_��f�[�^�擾
    '����            :1.cmbKeiyakuNojoCd     JBD.Gjs.Win.GcComboBox   �_��_��R�[�h�R���{�{�b�N�X
    '                 2.cmbKeiyakuNojoMei    JBD.Gjs.Win.GcComboBox   �_��_�ꖼ�R���{�{�b�N�X
    '�߂�l          :Boolean(����True/�G���[False)
    '------------------------------------------------------------------
    Public Function f_KeiyakuNojo_Data_Select(ByRef cmbKeiyakuNojoCd As JBD.Gjs.Win.GcComboBox, _
                                             ByRef cmbKeiyakuNojoMei As JBD.Gjs.Win.GcComboBox) As Boolean

        If Not f_KeiyakuNojo_Data_Select(cmbKeiyakuNojoCd, cmbKeiyakuNojoMei, "", False, True) Then
            Return False
        End If

        Return True

    End Function

#End Region


#End Region

End Module
