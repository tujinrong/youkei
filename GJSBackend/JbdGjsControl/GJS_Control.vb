'*******************************************************************************
'*　　①　モジュール名　　　JbdGjsControl
'*
'*　　②　機能概要　　　　　GJS共通モジュール
'*
'*  　③　更新履歴　　　　　R5OSVerUP対応 新規作成
'*******************************************************************************
Option Strict Off
Option Explicit On

Imports System.Data
Imports JbdGjsCommon

Public Module GJS_Control

#Region "*** マスタデータ取得 ***"
#Region "f_CodeMaster_Data_Select コードマスタデータ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_CodeMaster_Data_Select
    '説明            :コードマスタより引数で渡されたデータ区分に該当する
    '                 コードと名称を取得し、コンボボックスにセットする
    '
    '引数            :1.cmbCd  JBD.Gjs.Win.GcComboBox       コードコンボボックス
    '                 2.cmbMei JBD.Gjs.Win.GcComboBox       名称コンボボックス
    '                 3.sDATA_KBN   String(Optional)        データ区分(4:口座種別データ 5:都道府県データ)
    '                 4.blnNullAddFlg   Boolean             スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '                 5.nRYAKU_KBN  Integer                 正式名称、略称区分  0:正式名称(既定)  1:略称
    '戻り値          :Boolean(正常True/エラーFalse)
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

                    '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                    If blnNullAddFlg Then
                        'コンボ空白項目追加
                        cmbCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                Else
                    'エラーリスト出力なし
                    Show_MessageBox("I002", "") '該当データが存在しません。
                End If
            End With

            f_CodeMaster_Data_Select = True

        Catch ex As Exception
            '共通例外処理
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
#Region "f_Ken_Data_Select 県データ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Ken_Data_Select
    '説明            :県データ取得
    '引数            :1.cmbKenCd        JBD.Gjs.Win.GcComboBox      県コードコンボボックス
    '                 2.cmbKenMei       JBD.Gjs.Win.GcComboBox      県名コンボボックス
    '                 3.blnNullAddFlg   Boolean                     スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '                 4.sDATA_KBN       Integer(Optional)           データ区分(Default:5　←県データ)
    '戻り値          :Boolean(正常True/エラーFalse)
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
                        '2015/01/21 JBD368 UPD ↓↓↓ 都道府県名は正式名称を使用する
                        'cmbKenMei.Items.Add(WordHenkan("N", "S", .Rows(i)("RYAKUSYO")))
                        cmbKenMei.Items.Add(WordHenkan("N", "S", .Rows(i)("MEISYO")))
                        '2015/02/21 JBD368 UPD ↑↑↑

                        'subItem1.Value = WordHenkan("N", "S", .Rows(i)("MEISYO_CD"))
                        'subItem2.Value = WordHenkan("N", "S", .Rows(i)("RYAKUSYO"))
                        'cmbKenMei.Items.AddRange(New GrapeCity.Win.Editors.ListItem(New GrapeCity.Win.Editors.SubItem() {subItem1, subItem2}))

                        'cmbKenMei.Items.Add("")
                        'cmbKenMei.ListColumns.Item(0).DataPropertyName = WordHenkan("N", "S", .Rows(i)("MEISYO_CD"))
                        'cmbKenMei.ListColumns.Item(1).DataPropertyName = WordHenkan("N", "S", .Rows(i)("RYAKUSYO"))

                    Next

                    '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                    If blnNullAddFlg Then
                        '県マスタコンボ空白項目追加
                        cmbKenCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbKenMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                Else
                    'エラーリスト出力なし
                    Show_MessageBox("I002", "") '該当データが存在しません。
                    'Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION) '該当データが存在しません。
                End If
            End With


            f_Ken_Data_Select = True

        Catch ex As Exception
            '共通例外処理
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
#Region "f_Itaku_Data_Select 代理人データ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Itaku_Data_Select
    '説明            :代理人データ取得
    '引数            :1.cmbSankaCd  JBD.Gjs.Win.GcComboBox     代理人コードコンボボックス
    '                 2.cmbSankaMei JBD.Gjs.Win.GcComboBox     代理人名コンボボックス
    '                 3.blnNullAddFlg   Boolean                スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '戻り値          :Boolean(正常True/エラーFalse)
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

                    '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                    If blnNullAddFlg Then
                        'コンボ空白項目追加
                        cmbItakuCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbItakuMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                End If
            End With

            '該当データあり(委託先使用可)
            cmbItakuCd.Enabled = True
            cmbItakuMei.Enabled = True

            f_Itaku_Data_Select = True

        Catch ex As Exception
            '共通例外処理
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
#Region "f_Seisansya_Data_Select 生産者データ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Seisansya_Data_Select
    '説明            :生産者データ取得
    '引数            :1.cmbSeisanCd     JBD.Gjs.Win.GcComboBox   生産者コードコンボボックス
    '                 2.cmbSeisanMei    JBD.Gjs.Win.GcComboBox   生産者名コンボボックス
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

            cmbSeisanCd.Items.Clear()
            cmbSeisanMei.Items.Clear()

            With dstDataSanka.Tables(0)
                If .Rows.Count > 0 Then
                    For i As Integer = 0 To .Rows.Count - 1
                        cmbSeisanCd.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_CD")))
                        cmbSeisanMei.Items.Add(WordHenkan("N", "S", .Rows(i)("SEISANSYA_NAME")))
                    Next

                    '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                    If blnNullAddFlg Then
                        'コンボ空白項目追加
                        cmbSeisanCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSeisanMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                End If
            End With

            '生産者コード使用可
            cmbSeisanCd.Enabled = True
            cmbSeisanMei.Enabled = True

            f_Seisansya_Data_Select = True

        Catch ex As Exception
            '共通例外処理
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
#Region "f_Itaku_Seisansya_Data_Select 代理人コードに紐付く生産者データ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Itaku_Seisansya_Data_Select
    '説明            :生産者データ取得
    '引数            :1.cmbItakuCdFm   JBD.Gjs.Win.GcComboBox     代理人コードコンボボックスFROM
    '                 2.cmbSeisanCdFm  JBD.Gjs.Win.GcComboBox     生産者コードコンボボックスFROM
    '                 3.cmbSeisanMeiFm JBD.Gjs.Win.GcComboBox     生産者名コンボボックスFROM
    '                 4.blnNullAddFlg   Boolean                   スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '                 5.cmbItakuCdTo   JBD.Gjs.Win.GcComboBox     代理人コードコンボボックスTO
    '                 6.cmbSeisanCdTo  JBD.Gjs.Win.GcComboBox     生産者コードコンボボックスTO
    '                 7.cmbSeisanMeiTo JBD.Gjs.Win.GcComboBox     生産者名コンボボックスTO
    '戻り値          :Boolean(正常True/エラーFalse)
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
                '代理人コードToは未指定
                If cmbItakuCdFm.Text = "" Then
                    ' 代理人コードFROMは未指定
                    ' よって生産者は全件
                Else
                    ' 代理人コードFROMは指定されている
                    ' よって生産者FROMは代理人コードFROMと一致するものが対象
                    sWhere = sWhere & "  ITAKU_CD = '" & cmbItakuCdFm.Text & "'" & vbCrLf
                End If
            Else
                '代理人コードToは指定されている
                If cmbItakuCdFm.Text = "" Or cmbItakuCdTo.Text = "" Then
                    ' 代理人コードFROMまたはTOは未指定
                    ' よって生産者FROMおよびTOは全件
                Else
                    If cmbItakuCdFm.Text <> cmbItakuCdTo.Text Then
                        ' 代理人コードFROMとTOは同一でない
                        ' よって生産者FROMおよびTOは全件
                    Else
                        ' 代理人コードFROMとTOは同一である
                        ' よって生産者FROMおよびTOは代理人コードと一致するものが対象
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

                    '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                    If blnNullAddFlg Then
                        'コンボ空白項目追加
                        cmbSeisanCdFm.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSeisanMeiFm.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                        If cmbItakuCdTo Is Nothing Or cmbSeisanCdTo Is Nothing Or cmbSeisanMeiTo Is Nothing Then
                        Else
                            'コンボ空白項目追加
                            cmbSeisanCdTo.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSeisanMeiTo.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                        End If
                    End If
                    '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                End If
            End With

            '生産者コード使用可
            cmbSeisanCdFm.Enabled = True
            cmbSeisanMeiFm.Enabled = True
            If cmbItakuCdTo Is Nothing Or cmbSeisanCdTo Is Nothing Or cmbSeisanMeiTo Is Nothing Then
            Else
                cmbSeisanCdTo.Enabled = True
                cmbSeisanMeiTo.Enabled = True
            End If

            f_Itaku_Seisansya_Data_Select = True

        Catch ex As Exception
            '共通例外処理
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
#Region "f_Itaku_Data_Select 金融機関データ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Itaku_Data_Select
    '説明            :金融機関データ取得
    '引数            :1.cmbBankCd  JBD.Gjs.Win.GcComboBox       金融機関コードコンボボックス
    '                 2.cmbBankMei JBD.Gjs.Win.GcComboBox       金融機関名コンボボックス
    '                 3.blnNullAddFlg   Boolean                 スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '                 4.sDATA_KBN   String(Optional)            データ区分(Default:"")
    '戻り値          :Boolean(正常True/エラーFalse)
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

                    '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                    If blnNullAddFlg Then
                        'コンボ空白項目追加
                        cmbBankCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbBankMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                Else
                    'エラーリスト出力なし
                    Show_MessageBox("I002", "") '該当データが存在しません。
                    'Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION)
                End If
            End With

            f_Bank_Data_Select = True

        Catch ex As Exception
            '共通例外処理
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
#Region "f_BankShop_Data_Select 金融機関支店データ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_BankShop_Data_Select
    '説明            :金融機関支店データ取得
    '引数            :1.cmbShopCd  JBD.Gjs.Win.GcComboBox       金融機関支店コードコンボボックス
    '                 2.cmbShopMei JBD.Gjs.Win.GcComboBox       金融機関支店名コンボボックス
    '                 3.sBankCD     String                      金融機関コード
    '                 4.blnNullAddFlg   Boolean                 スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '                 5.sDATA_KBN   String(Optional)            データ区分(Default:"")
    '戻り値          :Boolean(正常True/エラーFalse)
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

                    '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                    If blnNullAddFlg Then
                        'コンボ空白項目追加
                        cmbShopCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbShopMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                End If
            End With

            f_BankShop_Data_Select = True

        Catch ex As Exception
            '共通例外処理
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
#Region "f_Doitu_Seisansya_Data_Select 同一生産者グループデータ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Doitu_Seisansya_Data_Select
    '説明            :同一生産者グループデータ取得
    '引数            :1.cmbDoituSeisansyaCd  JBD.Gjs.Win.GcComboBox       同一生産者グループコードコンボボックス
    '                 2.cmbDoituSeisansyaMei JBD.Gjs.Win.GcComboBox       同一生産者グループ名コンボボックス
    '                 3.blnNullAddFlg   Boolean                 スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '戻り値          :Boolean(正常True/エラーFalse)
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

                    '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                    If blnNullAddFlg Then
                        'コンボ空白項目追加
                        cmbDoituSeisansyaCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbDoituSeisansyaMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                Else
                    'エラーリスト出力なし
                    'Show_MessageBox("I002", "") '該当データが存在しません。
                    'Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION)
                End If
            End With

            f_Doitu_Seisansya_Data_Select = True

        Catch ex As Exception
            '共通例外処理
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
#Region "f_Syokcyo_Data_Select 食鳥処理場データ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Syokcyo_Data_Select
    '説明            :食鳥処理場データ取得
    '引数            :1.cmbSyokucyoCd  JBD.Gjs.Win.GcComboBox       食鳥処理場コードコンボボックス
    '                 2.cmbSyokucyoMei JBD.Gjs.Win.GcComboBox       食鳥処理場名コンボボックス
    '                 3.blnNullAddFlg   Boolean                 スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '戻り値          :Boolean(正常True/エラーFalse)
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

                    '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                    If blnNullAddFlg Then
                        'コンボ空白項目追加
                        cmbSyokucyoCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbSyokucyoMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                Else
                    'エラーリスト出力なし
                    'Show_MessageBox("I002", "") '該当データが存在しません。
                    'Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION)
                End If
            End With

            f_Syokcyo_Data_Select = True

        Catch ex As Exception
            '共通例外処理
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
#Region "f_User_Data_Select 担当者データ取得"
    '------------------------------------------------------------------
    'プロシージャ名  :f_User_Data_Select
    '説明            :担当者データ取得
    '引数            :1.cmbUserCd  JBD.Gjs.Win.GcComboBox       担当者コードコンボボックス
    '                 2.cmbUserMei JBD.Gjs.Win.GcComboBox       担当者名コンボボックス
    '                 3.blnNullAddFlg   Boolean                 スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '戻り値          :Boolean(正常True/エラーFalse)
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

                    '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                    If blnNullAddFlg Then
                        'コンボ空白項目追加
                        cmbUserCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbUserMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                Else
                    'エラーリスト出力なし
                    'Show_MessageBox("I002", "") '該当データが存在しません。
                    'Show_MessageBox("該当データが存在しません。", C_MSGICON_INFORMATION)
                End If
            End With

            f_User_Data_Select = True

        Catch ex As Exception
            '共通例外処理
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
#Region "f_Keiyaku_Data_Select 契約者データ取得(防疫互助)"
    '------------------------------------------------------------------
    'プロシージャ名  :f_Keiyaku_Data_Select
    '説明            :契約者データ取得
    '引数            :1.cmbKeiyakuCd     JBD.Gjs.Win.GcComboBox   契約者コードコンボボックス
    '                 2.cmbKeiyakuMei    JBD.Gjs.Win.GcComboBox   契約者名コンボボックス
    '                 3.strWhere        String                    契約者マスタ検索条件 WHERE句を指定する
    '                 4.blnNullAddFlg   Boolean                   スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '                 5.blnEnable       Boolean                   コンボの入力可否(TRUE:入力可能 FALSE:入力不可)
    '                 6.strUser       Boolean                   　他スキーマのデータが必要な時、スキーマをセット(""のとき、自スキーマ)   '2017/07/07追加
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As JBD.Gjs.Win.GcComboBox, _
                                          ByRef cmbKeiyakuMei As JBD.Gjs.Win.GcComboBox, _
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
        '    Show_MessageBox("", ex.Message)
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

            cmbKeiyakuCd.Clear()
            cmbKeiyakuMei.Clear()

            With dstDataSanka.Tables(0)
                If .Rows.Count > 0 Then

                    'コンボボックスにデータをバインド
                    cmbKeiyakuCd.DataSource = dstDataSanka.Tables(0)
                    '不要なカラムを削除する
                    cmbKeiyakuCd.ListColumns.RemoveAt(1)

                    'コンボボックスにデータをバインド
                    cmbKeiyakuMei.DataSource = dstDataSanka.Tables(0)
                    '不要なカラムを削除する
                    cmbKeiyakuMei.ListColumns.RemoveAt(0)
                    '名称のコンボボックスの幅を設定
                    cmbKeiyakuMei.ListColumns(0).Width = cmbKeiyakuMei.Width

                End If
            End With

            '契約者コード使用可
            cmbKeiyakuCd.Enabled = blnEnable
            cmbKeiyakuMei.Enabled = blnEnable

            f_Keiyaku_Data_Select = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function


    '------------------------------------------------------------------
    'プロシージャ名  :f_Keiyaku_Data_Select
    '説明            :契約者データ取得
    '引数            :1.cmbKeiyakuCd     JBD.Gjs.Win.GcComboBox   契約者コードコンボボックス
    '                 2.cmbKeiyakuMei    JBD.Gjs.Win.GcComboBox   契約者名コンボボックス
    '                 3.strWhere        String                    契約者マスタ検索条件 WHERE句を指定する
    '                 4.blnNullAddFlg   Boolean                   スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '                 5.blnEnable       Boolean                   コンボの入力可否(TRUE:入力可能 FALSE:入力不可)
    '戻り値          :Boolean(正常True/エラーFalse)
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
    'プロシージャ名  :f_Keiyaku_Data_Select
    '説明            :契約者データ取得
    '引数            :1.cmbKeiyakuCd     JBD.Gjs.Win.GcComboBox   契約者コードコンボボックス
    '                 2.cmbKeiyakuMei    JBD.Gjs.Win.GcComboBox   契約者名コンボボックス
    '                 3.strWhere        String                    契約者マスタ検索条件 WHERE句を指定する
    '                 4.blnNullAddFlg   Boolean                   スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '戻り値          :Boolean(正常True/エラーFalse)
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
    'プロシージャ名  :f_Keiyaku_Data_Select
    '説明            :契約者データ取得
    '引数            :1.cmbKeiyakuCd     JBD.Gjs.Win.GcComboBox   契約者コードコンボボックス
    '                 2.cmbKeiyakuMei    JBD.Gjs.Win.GcComboBox   契約者名コンボボックス
    '                 3.strWhere        String                    契約者マスタ検索条件 WHERE句を指定する
    '戻り値          :Boolean(正常True/エラーFalse)
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
    'プロシージャ名  :f_Keiyaku_Data_Select
    '説明            :契約者データ取得
    '引数            :1.cmbKeiyakuCd     JBD.Gjs.Win.GcComboBox   契約者コードコンボボックス
    '                 2.cmbKeiyakuMei    JBD.Gjs.Win.GcComboBox   契約者名コンボボックス
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_Keiyaku_Data_Select(ByRef cmbKeiyakuCd As JBD.Gjs.Win.GcComboBox, _
                                             ByRef cmbKeiyakuMei As JBD.Gjs.Win.GcComboBox) As Boolean

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
    '引数            :1.cmbJimuItakuCd     JBD.Gjs.Win.GcComboBox   事務委託先コードコンボボックス
    '                 2.cmbJimuItakuMei    JBD.Gjs.Win.GcComboBox   事務委託先名コンボボックス
    '                 3.strWhere        String                      事務委託先マスタ検索条件 WHERE句を指定する
    '                 4.blnNullAddFlg   Boolean                     スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_JimuItaku_Data_Select(ByRef cmbJimuItakuCd As JBD.Gjs.Win.GcComboBox, _
                                            ByRef cmbJimuItakuMei As JBD.Gjs.Win.GcComboBox, _
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
        '    Show_MessageBox("", ex.Message)
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

            cmbJimuItakuCd.Clear()
            cmbJimuItakuMei.Clear()

            With dstDataSanka.Tables(0)
                If .Rows.Count > 0 Then
                    'コンボボックスにデータをバインド
                    cmbJimuItakuCd.DataSource = dstDataSanka.Tables(0)
                    '不要なカラムを削除する
                    cmbJimuItakuCd.ListColumns.RemoveAt(1)

                    'コンボボックスにデータをバインド
                    cmbJimuItakuMei.DataSource = dstDataSanka.Tables(0)
                    '不要なカラムを削除する
                    cmbJimuItakuMei.ListColumns.RemoveAt(0)
                    '名称のコンボボックスの幅を設定
                    cmbJimuItakuMei.ListColumns(0).Width = cmbJimuItakuMei.Width
                End If
            End With

            '事務委託先コード使用可
            cmbJimuItakuCd.Enabled = blnEnable
            cmbJimuItakuMei.Enabled = blnEnable

            f_JimuItaku_Data_Select = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try
        '2015/03/03 JBD368 UPD ↑↑↑

    End Function

    '------------------------------------------------------------------
    'プロシージャ名  :f_JimuItaku_Data_Select
    '説明            :事務委託先データ取得
    '引数            :1.cmbJimuItakuCd     JBD.Gjs.Win.GcComboBox   事務委託先コードコンボボックス
    '                 2.cmbJimuItakuMei    JBD.Gjs.Win.GcComboBox   事務委託先名コンボボックス
    '                 3.strWhere        String                    事務委託先マスタ検索条件 WHERE句を指定する
    '戻り値          :Boolean(正常True/エラーFalse)
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
    'プロシージャ名  :f_JimuItaku_Data_Select
    '説明            :事務委託先データ取得
    '引数            :1.cmbJimuItakuCd     JBD.Gjs.Win.GcComboBox   事務委託先コードコンボボックス
    '                 2.cmbJimuItakuMei    JBD.Gjs.Win.GcComboBox   事務委託先名コンボボックス
    '                 3.strWhere        String                    事務委託先マスタ検索条件 WHERE句を指定する
    '戻り値          :Boolean(正常True/エラーFalse)
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
    'プロシージャ名  :f_JimuItaku_Data_Select
    '説明            :事務委託先データ取得
    '引数            :1.cmbJimuItakuCd     JBD.Gjs.Win.GcComboBox   事務委託先コードコンボボックス
    '                 2.cmbJimuItakuMei    JBD.Gjs.Win.GcComboBox   事務委託先名コンボボックス
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Public Function f_JimuItaku_Data_Select(ByRef cmbJimuItakuCd As JBD.Gjs.Win.GcComboBox, _
                                             ByRef cmbJimuItakuMei As JBD.Gjs.Win.GcComboBox) As Boolean

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
    '引数            :1.cmbKeiyakuNojoCd     JBD.Gjs.Win.GcComboBox   契約農場コードコンボボックス
    '                 2.cmbKeiyakuNojoMei    JBD.Gjs.Win.GcComboBox   契約農場名コンボボックス
    '                 3.strWhere        String                      契約農場マスタ検索条件 WHERE句を指定する
    '                 4.blnNullAddFlg   Boolean                     スペース項目をコンボに追加するかしないかのフラグ(False(既定):スペース項目を追加しない　True:スペース項目を追加する)
    '戻り値          :Boolean(正常True/エラーFalse)
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

                    '↓***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↓
                    If blnNullAddFlg Then
                        'コンボ空白項目追加
                        cmbKeiyakuNojoCd.Items.Insert(0, New GrapeCity.Win.Editors.ListItem()) : cmbKeiyakuNojoMei.Items.Insert(0, New GrapeCity.Win.Editors.ListItem())
                    End If
                    '↑***** 2010/09/15 JBD200 ADD 第3引数=Trueの時、空白項目を追加するよう追加 *****↑

                End If
            End With

            '契約農場コード使用可
            cmbKeiyakuNojoCd.Enabled = blnEnable
            cmbKeiyakuNojoMei.Enabled = blnEnable

            f_KeiyakuNojo_Data_Select = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Function

    '------------------------------------------------------------------
    'プロシージャ名  :f_KeiyakuNojo_Data_Select
    '説明            :契約農場データ取得
    '引数            :1.cmbKeiyakuNojoCd     JBD.Gjs.Win.GcComboBox   契約農場コードコンボボックス
    '                 2.cmbKeiyakuNojoMei    JBD.Gjs.Win.GcComboBox   契約農場名コンボボックス
    '                 3.strWhere        String                    契約農場マスタ検索条件 WHERE句を指定する
    '戻り値          :Boolean(正常True/エラーFalse)
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
    'プロシージャ名  :f_KeiyakuNojo_Data_Select
    '説明            :契約農場データ取得
    '引数            :1.cmbKeiyakuNojoCd     JBD.Gjs.Win.GcComboBox   契約農場コードコンボボックス
    '                 2.cmbKeiyakuNojoMei    JBD.Gjs.Win.GcComboBox   契約農場名コンボボックス
    '                 3.strWhere        String                    契約農場マスタ検索条件 WHERE句を指定する
    '戻り値          :Boolean(正常True/エラーFalse)
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
    'プロシージャ名  :f_KeiyakuNojo_Data_Select
    '説明            :契約農場データ取得
    '引数            :1.cmbKeiyakuNojoCd     JBD.Gjs.Win.GcComboBox   契約農場コードコンボボックス
    '                 2.cmbKeiyakuNojoMei    JBD.Gjs.Win.GcComboBox   契約農場名コンボボックス
    '戻り値          :Boolean(正常True/エラーFalse)
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
