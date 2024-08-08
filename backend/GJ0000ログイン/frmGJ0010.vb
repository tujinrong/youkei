'*******************************************************************************
'*
'*　　①　フォーム名　　　  frmGJ0010.vb
'*
'*　　②　機能概要　　　　　XXXXXシステム メインメニュー
'*
'*　　③　作成日　　　　　　2014/12/24 test
'*
'*　　④　更新日            
'*
'*******************************************************************************
Option Strict Off
Option Explicit On

'------------------------------------------------------------------

'------------------------------------------------------------------

Imports JbdGjsCommon
Imports System.Reflection       'DLL動的呼出で使用

Imports System.IO

Public Class frmGJ0010

#Region "*** 変数定義 ***"

    Public pSiyoKbn As Integer                              '使用者マスタ.使用区分
    Private pDataSet As New DataSet                         '検索結果一覧セット用データセット

    Public pUKEIRE_YMDHMS As String = String.Empty          '処理開始時間
    Public pCNT As Integer = 0                              '帳票出力件数
    Public pKEY As String = String.Empty
    Private pGJSINI_Array As pGJSINI

    'Private pAryHeader As New ArrayList                     'ヘッダーメニュ用配列 ★★★
    Private keyIndex As Integer = 0                         '現在選択のヘッダー番号
    Private pSYORIKINOH() As SYORIKINO                       'メニューヘッダー用データ構造体
    Private pSYORIKINO() As SYORIKINO                       'メニュー明細用データ構造体

#End Region

#Region "*** 定数定義 ***"
    Private Const C_LINKLABEL As String = "LinkLabel"
#End Region

#Region "*** 構造体定義 ***"
    '処理機能マスタデータ構造体
    Private Structure SYORIKINO
        Public LVL1 As Integer
        Public LVL2 As Integer
        Public LVL3 As Integer
        Public MENU_NAME As String
        Public KINO_NAME As String
        Public KINO_ID As String
        Public SIYO_KBN1 As Integer
        Public SIYO_KBN2 As Integer
        Public SIYO_KBN3 As Integer
        Public SIYO_KBN4 As Integer
        Public SIYO_KBN5 As Integer
        Public DLL_NAME As String
        '処理機能マスタ用の構造体GettterSetter
        Public Sub SetSYORIKINO(ByVal dtRow As DataRow)

            LVL1 = WordHenkan("N", "Z", dtRow("LVL1"))
            LVL2 = WordHenkan("N", "Z", dtRow("LVL2"))
            LVL3 = WordHenkan("N", "Z", dtRow("LVL3"))
            MENU_NAME = WordHenkan("N", "S", dtRow("MENU_NAME"))
            KINO_NAME = WordHenkan("N", "S", dtRow("KINO_NAME"))
            KINO_ID = WordHenkan("N", "S", dtRow("KINO_ID"))
            SIYO_KBN1 = WordHenkan("N", "Z", dtRow("SIYO_KBN1"))
            SIYO_KBN2 = WordHenkan("N", "Z", dtRow("SIYO_KBN2"))
            SIYO_KBN3 = WordHenkan("N", "Z", dtRow("SIYO_KBN3"))
            SIYO_KBN4 = WordHenkan("N", "Z", dtRow("SIYO_KBN4"))
            SIYO_KBN5 = WordHenkan("N", "Z", dtRow("SIYO_KBN5"))
            DLL_NAME = WordHenkan("N", "S", dtRow("DLL_NAME"))

        End Sub

    End Structure
#End Region

#Region "*** 画面制御関連 ***"

#Region "frmGJ0010_Load Form_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmGJ0010_Load
    '説明            :Form_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmGJ0010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'カーソルを砂時計にする
            Me.Cursor = Cursors.WaitCursor

            '画面描画が実行されるため画面を一旦非表示にする
            Me.Visible = False

            'ヘッダーメニューを表示
            If Not f_Menu_Create_Header() Then
                Throw New Exception
            End If

            '明細メニューを取得
            If Not f_Menu_Create_Detail() Then
                Throw New Exception
            End If

            '先頭メニューが使用不可ではない場合のみ初期表示
            If LinkLabel1.Enabled Then
                '初期表示時はLVL1が一番若いデータを表示
                keyIndex = pSYORIKINO(0).LVL1
                'タブ制御
                Call s_ChengeHeaderMenuControl()
            Else
                keyIndex = 0
            End If

            'メニュー内容表示
            If Not f_ShowMenu() Then
                Throw New Exception
            End If

            '画面を表示する
            Me.Visible = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        Finally
            'カーソルを標準に戻す
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

#End Region

#Region "*** 画面クリック関連 ***"

#Region "cmdEnd_Click 終了ボタンクリック処理"
    '------------------------------------------------------------------
    'プロシージャ名  :cmdEnd_Click
    '説明            :終了ボタンクリック処理
    '------------------------------------------------------------------
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            If Show_MessageBox("Q001", "") = DialogResult.No Then   '終了します。よろしいですか？
                '処理を終了しますか？
                Exit Try
            End If

            'フォームクローズ
            Me.Close()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            'データベースへの接断
            Cnn.Close()
            'フォームクローズ
            Me.Close()
        End Try
    End Sub
#End Region

#Region "LinkLabelHead_LinkClicked メニューリンクラベル(ヘッダー)クリック処理"
    Private Sub LinkLabelHead_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked _
                                                                                            , LinkLabel2.LinkClicked _
                                                                                            , LinkLabel3.LinkClicked _
                                                                                            , LinkLabel4.LinkClicked _
                                                                                            , LinkLabel5.LinkClicked _
                                                                                            , LinkLabel6.LinkClicked _
                                                                                            , LinkLabel7.LinkClicked _
                                                                                            , LinkLabel8.LinkClicked _
                                                                                            , LinkLabel9.LinkClicked _
                                                                                            , LinkLabel10.LinkClicked _
                                                                                            , LinkLabel11.LinkClicked _
                                                                                            , LinkLabel12.LinkClicked _
                                                                                            , LinkLabel13.LinkClicked _
                                                                                            , LinkLabel14.LinkClicked _
                                                                                            , LinkLabel15.LinkClicked

        Try
            Dim linkLabel As JBD.Gjs.Win.LinkLabel = CType(sender, JBD.Gjs.Win.LinkLabel)
            Dim index As Integer = CInt(linkLabel.Name.Replace(C_LINKLABEL, ""))
            keyIndex = pSYORIKINOH(index - 1).LVL1
            'タブ制御
            Call s_ChengeHeaderMenuControl()
            'メニューを設定
            If f_ShowMenu() Then
                Exit Sub
            End If
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try
    End Sub
#End Region

#Region "LinkLabelDetail_LinkClicked メニューリンクラベル(明細)クリック処理"
    Private Sub LinkLabelDetail_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles _
                                                                                              LinkLabel1_1.LinkClicked, LinkLabel1_2.LinkClicked, LinkLabel1_3.LinkClicked, LinkLabel1_4.LinkClicked _
                                                                                            , LinkLabel1_5.LinkClicked, LinkLabel1_6.LinkClicked, LinkLabel1_7.LinkClicked, LinkLabel1_8.LinkClicked _
                                                                                            , LinkLabel2_1.LinkClicked, LinkLabel2_2.LinkClicked, LinkLabel2_3.LinkClicked, LinkLabel2_4.LinkClicked _
                                                                                            , LinkLabel2_5.LinkClicked, LinkLabel2_6.LinkClicked, LinkLabel2_7.LinkClicked, LinkLabel2_8.LinkClicked _
                                                                                            , LinkLabel3_1.LinkClicked, LinkLabel3_2.LinkClicked, LinkLabel3_3.LinkClicked, LinkLabel3_4.LinkClicked _
                                                                                            , LinkLabel3_5.LinkClicked, LinkLabel3_6.LinkClicked, LinkLabel3_7.LinkClicked, LinkLabel3_8.LinkClicked _
                                                                                            , LinkLabel4_1.LinkClicked, LinkLabel4_2.LinkClicked, LinkLabel4_3.LinkClicked, LinkLabel4_4.LinkClicked _
                                                                                            , LinkLabel4_5.LinkClicked, LinkLabel4_6.LinkClicked, LinkLabel4_7.LinkClicked, LinkLabel4_8.LinkClicked

        Try
            Dim linkLabel As JBD.Gjs.Win.LinkLabel = CType(sender, JBD.Gjs.Win.LinkLabel)
            Dim iLVL2 As Integer = linkLabel.Name.Replace(C_LINKLABEL, "").ToString.Substring(0, 1)
            Dim iLVL3 As Integer = linkLabel.Name.Replace(C_LINKLABEL, "").ToString.Substring(2, 1)

            '選択画面実行
            Call s_Exe_Start(iLVL2, iLVL3)

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox_Add("W019", "該当メニューは現在使用できません。管理者に確認してください。")
        End Try
    End Sub
#End Region

#End Region

#Region "*** メニュー組み立て ***"

#Region "f_Menu_Create_Header メニュー組み立て(ヘッダー)"
    '*******************************************************************************
    '*　　①　プロシージャ名        f_Menu_Create_Header
    '*　　②　機能概要              メニューを組み立て(ヘッダー)
    '*　　③　引数　　　　　　　　　無し
    '*　　④　戻り値　　　　　　　　無し
    '*　　⑤　作成日　　　　　　　  2014/12/25 JBD368  
    '*　　⑥　更新日　　　　　　　   
    '*******************************************************************************
    Private Function f_Menu_Create_Header() As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet
        Dim strKIDO As String = String.Empty
        Dim strDllNm As String = String.Empty

        Try

            'メニュー用データ抽出
            '処理機能マスタLVL1のデータを抽出
            sSql += "SELECT " & vbCrLf
            sSql += "  LVL1 " & vbCrLf
            sSql += " ,LVL2 " & vbCrLf
            sSql += " ,LVL3 " & vbCrLf
            sSql += " ,MENU_NAME " & vbCrLf
            sSql += " ,KINO_NAME " & vbCrLf
            sSql += " ,KINO_ID " & vbCrLf
            sSql += " ,SIYO_KBN1 " & vbCrLf
            sSql += " ,SIYO_KBN2 " & vbCrLf
            sSql += " ,SIYO_KBN3 " & vbCrLf
            sSql += " ,SIYO_KBN4 " & vbCrLf
            sSql += " ,SIYO_KBN5 " & vbCrLf
            sSql += " ,DLL_NAME " & vbCrLf
            sSql += "FROM " & vbCrLf
            sSql += "  TM_SYORIKINO " & vbCrLf
            sSql += "WHERE " & vbCrLf
            sSql += "  LVL2 = 0 " & vbCrLf
            sSql += "  AND LVL3 = 0 " & vbCrLf
            sSql += "ORDER BY " & vbCrLf
            sSql += "  LVL1 " & vbCrLf

            Call f_Select_ODP(dstDataSet, sSql)

            If dstDataSet.Tables(0).Rows.Count = 0 Then
                Return False
            End If

            '取得したデータを構造体に格納
            ReDim pSYORIKINOH(dstDataSet.Tables(0).Rows.Count - 1)

            Dim index As Integer = 0
            For index = 0 To dstDataSet.Tables(0).Rows.Count - 1

                '取得したデータを構造体に格納
                Dim dtRow As DataRow = dstDataSet.Tables(0).Rows(index)
                pSYORIKINOH(index).SetSYORIKINO(dtRow)

                '対象コントロールの取得
                Dim cs As Control() = Me.Controls.Find(C_LINKLABEL & (index + 1).ToString, True)
                If cs.Length = 0 Then
                    Continue For
                End If
                Dim wLinkLabel As JBD.Gjs.Win.LinkLabel = CType(cs(0), JBD.Gjs.Win.LinkLabel)
                wLinkLabel.Visible = True

                '表示文字列の設定
                wLinkLabel.Text = pSYORIKINOH(index).MENU_NAME

                'ユーザー権限によるリンクラベルの使用可否制御
                Select Case pSiyoKbn
                    Case 10
                        strKIDO = pSYORIKINOH(index).SIYO_KBN1
                    Case 20
                        strKIDO = pSYORIKINOH(index).SIYO_KBN2
                    Case 30
                        strKIDO = pSYORIKINOH(index).SIYO_KBN3
                    Case 40
                        strKIDO = pSYORIKINOH(index).SIYO_KBN4
                    Case 50
                        strKIDO = pSYORIKINOH(index).SIYO_KBN5
                End Select
                strDllNm = pSYORIKINOH(index).DLL_NAME

                If strKIDO.TrimEnd = "1" Then
                    '起動OK
                    wLinkLabel.Enabled = True
                Else
                    '起動NG
                    wLinkLabel.Enabled = False
                End If

            Next

            '使用しないヘッダーラベルは非表示
            index += 1
            For i As Integer = index To 15
                Dim cs As Control() = Me.Controls.Find(C_LINKLABEL & i.ToString, True)
                If cs.Length > 0 Then
                    CType(cs(0), JBD.Gjs.Win.LinkLabel).Visible = False
                End If
            Next

            Return True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            Return False
        Finally
            dstDataSet = Nothing
        End Try

    End Function
#End Region

#Region "f_Menu_Create_Detail メニューを組み立て(明細)"
    '*******************************************************************************
    '*　　①　プロシージャ名        f_Menu_Create_Detail
    '*　　②　機能概要              メニューを組み立て(明細)
    '*　　③　引数　　　　　　　　　無し
    '*　　④　戻り値　　　　　　　　無し
    '*　　⑤　作成日　　　　　　　  2014/12/25 JBD368  
    '*　　⑥　更新日　　　　　　　   
    '*******************************************************************************
    Private Function f_Menu_Create_Detail() As Boolean

        Dim sSql As String = String.Empty
        Dim dstDataSet As New DataSet

        Try

            'メニュー用データ抽出
            '処理機能マスタの明細データを抽出
            sSql += "SELECT " & vbCrLf
            sSql += "  * " & vbCrLf
            sSql += "FROM " & vbCrLf
            sSql += "  TM_SYORIKINO " & vbCrLf
            sSql += "WHERE " & vbCrLf
            sSql += "  NOT (LVL2 = 0 " & vbCrLf
            sSql += "  AND  LVL3 = 0) " & vbCrLf
            sSql += "ORDER BY " & vbCrLf
            sSql += "  LVL1 " & vbCrLf
            sSql += " ,LVL2 " & vbCrLf
            sSql += " ,LVL3 " & vbCrLf

            Call f_Select_ODP(dstDataSet, sSql)

            If dstDataSet.Tables(0).Rows.Count = 0 Then
                Return False
            End If

            '取得したデータを構造体に格納
            ReDim pSYORIKINO(dstDataSet.Tables(0).Rows.Count - 1)
            For i As Integer = 0 To dstDataSet.Tables(0).Rows.Count - 1
                Dim dtRow As DataRow = dstDataSet.Tables(0).Rows(i)

                pSYORIKINO(i).SetSYORIKINO(dtRow)
            Next

            Return True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            Return False
        Finally
            dstDataSet = Nothing
        End Try

    End Function



#End Region

#Region "f_ShowMenu メニュー(明細)内容表示"
    Private Function f_ShowMenu() As Boolean

        Try
            'メニューのラベルのtextを初期化
            Call s_LinkLabel_NameReset()

            'ラベルのカテゴリを設定
            For i As Integer = 0 To pSYORIKINO.Length - 1

                '処理したいLVL1より小さい場合は飛ばして次のレコードへ
                If pSYORIKINO(i).LVL1 < keyIndex Then
                    Continue For
                End If
                '処理したいLVL1より大きい場合はループを抜ける
                If pSYORIKINO(i).LVL1 > keyIndex Then
                    Exit For
                End If

                'ラベルの文字列に構造体のデータをセット
                Dim sLabelName As String = C_LINKLABEL
                sLabelName += pSYORIKINO(i).LVL2.ToString & "_" & pSYORIKINO(i).LVL3.ToString

                Dim cs As Control() = Me.Controls.Find(sLabelName, True)
                'Console.Out.WriteLine(sLabelName)
                Dim sName As String = String.Empty
                If cs.Length > 0 Then
                    sName = String.Empty
                    sName = "(" & pSYORIKINO(i).KINO_ID & ") " & pSYORIKINO(i).KINO_NAME
                    CType(cs(0), JBD.Gjs.Win.LinkLabel).Text = sName

                    '2015/03/04 JBD368 ADD ↓↓↓
                    'ユーザー権限によるリンクラベルの使用可否制御
                    Dim iKIDO As Integer
                    Select Case pSiyoKbn
                        Case 10
                            iKIDO = pSYORIKINO(i).SIYO_KBN1
                        Case 20
                            iKIDO = pSYORIKINO(i).SIYO_KBN2
                        Case 30
                            iKIDO = pSYORIKINO(i).SIYO_KBN3
                        Case 40
                            iKIDO = pSYORIKINO(i).SIYO_KBN4
                        Case 50
                            iKIDO = pSYORIKINO(i).SIYO_KBN5
                    End Select

                    If iKIDO = 1 Then
                        '起動OK
                        CType(cs(0), JBD.Gjs.Win.LinkLabel).Enabled = True
                    Else
                        '起動NG
                        CType(cs(0), JBD.Gjs.Win.LinkLabel).Enabled = False
                    End If
                    '215/03/04 JBD368 ADD ↑↑↑
                End If
            Next

            '使用しないLinkLabelは非表示にする
            For i As Integer = 1 To 4
                For j As Integer = 1 To 8
                    Dim cs As Control() = Me.Controls.Find(C_LINKLABEL & i.ToString & "_" & j.ToString, True)
                    Dim wLinkLabel As JBD.Gjs.Win.LinkLabel = CType(cs(0), JBD.Gjs.Win.LinkLabel)
                    Dim sLabelName As String = wLinkLabel.Text
                    If sLabelName.IndexOf(C_LINKLABEL) > -1 Then
                        wLinkLabel.Visible = False
                    Else
                        wLinkLabel.Visible = True
                    End If
                Next
            Next

            Return True
        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
            Return False
        Finally
        End Try
    End Function
#End Region

#Region "s_LinkLabel_NameReset メニューリンクラベル初期化"
    Private Sub s_LinkLabel_NameReset()

        'メニュー明細のTextを初期化
        For i As Integer = 1 To 4
            For j As Integer = 1 To 8
                Dim sLabelName As String = C_LINKLABEL & i.ToString & "_" & j.ToString
                Dim cs As Control() = Me.Controls.Find(sLabelName, True)
                Dim wLinkLabel As JBD.Gjs.Win.LinkLabel = CType(cs(0), JBD.Gjs.Win.LinkLabel)
                wLinkLabel.Text = sLabelName
            Next
        Next

    End Sub
#End Region

#Region "s_ChengeHeaderMenuControl ヘッダーメニュー制御"
    Private Sub s_ChengeHeaderMenuControl()

        'リンクラベルの制御
        '一旦すべてのラベルの背景、文字色を初期化
        For i As Integer = 0 To 14
            Dim cs1 As Control() = Me.Controls.Find(C_LINKLABEL & (i + 1).ToString, True)
            If cs1.Length > 0 Then
                CType(cs1(0), JBD.Gjs.Win.LinkLabel).BackColor = Color.Transparent
                CType(cs1(0), JBD.Gjs.Win.LinkLabel).LinkColor = JBD.Gjs.Win.GjsDefaultColor.LinkDefaultColor
                CType(cs1(0), JBD.Gjs.Win.LinkLabel).ActiveLinkColor = JBD.Gjs.Win.GjsDefaultColor.LinkDefaultColor
            End If
        Next

        '今回クリックのもののみ背景、文字色を変更
        For i As Integer = 0 To pSYORIKINOH.Length - 1
            If keyIndex = pSYORIKINOH(i).LVL1 Then
                Dim cs2 As Control() = Me.Controls.Find(C_LINKLABEL & (i + 1).ToString, True)
                If cs2.Length > 0 Then
                    CType(cs2(0), JBD.Gjs.Win.LinkLabel).BackColor = JBD.Gjs.Win.GjsDefaultColor.LinkLabelBackColor
                    CType(cs2(0), JBD.Gjs.Win.LinkLabel).LinkColor = JBD.Gjs.Win.GjsDefaultColor.LinkColor
                    CType(cs2(0), JBD.Gjs.Win.LinkLabel).ActiveLinkColor = JBD.Gjs.Win.GjsDefaultColor.LinkColor
                End If
                Exit For
            End If
        Next

    End Sub
#End Region

#End Region

#Region "その他ローカル関数"
#Region "f_pINI_Array Hiku.INI構造体の内容セット"
    '------------------------------------------------------------------
    'プロシージャ名  :f_pHIKUINI_Array
    '説明            :Hiku.INI構造体の内容セット
    '引数            :なし
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_pINI_Array(ByVal pNJHINI_Array) As Boolean
        Dim ret As Boolean = False

        Try

            pNJHINI_Array.LOGINUSERID = pLOGINUSERID
            pNJHINI_Array.LOGINUSERNM = pLOGINUSERNM
            pNJHINI_Array.DBUSER = myDBUSER
            pNJHINI_Array.DBPASS = myDBPASS
            pNJHINI_Array.DBSID = myDBSID
            '2021/04/12 JBD9020 R03年度追加基金対応 DEL START
            'pNJHINI_Array.CSV_SANKA_ENTRY = myCSV_SANKA_ENTRY
            'pNJHINI_Array.CSV_SANKA_ENTRY_SERVER = myCSV_SANKA_ENTRY_SERVER
            'pNJHINI_Array.CSV_KANRI_DATA_SERVER = myCSV_KANRI_DATA_SERVER
            'pNJHINI_Array.TXT_KANRI_ENTRY = myTXT_KANRI_ENTRY
            'pNJHINI_Array.TXT_KANRI_ENTRY_SERVER = myTXT_KANRI_ENTRY_SERVER
            '2021/04/12 JBD9020 R03年度追加基金対応 DEL END
            pNJHINI_Array.TXT_FURIKOMI_ENTRY = myTXT_FURIKOMI_ENTRY
            '2021/04/12 JBD9020 R03年度追加基金対応 DEL START
            'pNJHINI_Array.TXT_FURIKOMI_ENTRY_SERVER = myTXT_FURIKOMI_ENTRY_SERVER
            'pNJHINI_Array.TXT_HIKIOTOSHI_ENTRY = myTXT_HIKIOTOSHI_ENTRY
            'pNJHINI_Array.DMP_FILE_PATH = myDMP_FILE_PATH
            'pNJHINI_Array.DMP_LOG_PATH = myDMP_LOG_PATH
            'pNJHINI_Array.DMP_DBUSER = myDMP_DBUSER
            'pNJHINI_Array.DMP_DBPASS = myDMP_DBPASS
            'pNJHINI_Array.DMP_DBSID = myDMP_DBSID
            'pNJHINI_Array.DMP_TIME_OUT = myDMP_TIME_OUT
            '2021/04/12 JBD9020 R03年度追加基金対応 DEL END
            pNJHINI_Array.REPORT_PDF_PATH = myREPORT_PDF_PATH
            pNJHINI_Array.REPORT_EXCEL_PATH = myREPORT_EXCEL_PATH
            '2021/04/12 JBD9020 R03年度追加基金対応 DEL START
            'pNJHINI_Array.ZIP_PASSWORD = myZIP_PASSWORD
            'pNJHINI_Array.ZIP_PATH = myZIP_PATH
            'pNJHINI_Array.BACKUP_PATH = myBACKUP_PATH
            '2021/04/12 JBD9020 R03年度追加基金対応 DEL END
            pNJHINI_Array.REPORT_PDF_OUTKBN = myREPORT_PDF_OUTKBN

            pNJHINI_Array.YOHAKU_UP = myYOHAKU_UP
            pNJHINI_Array.YOHAKU_DOWN = myYOHAKU_DOWN
            pNJHINI_Array.YOHAKU_LEFT = myYOHAKU_LEFT
            pNJHINI_Array.YOHAKU_RIGHT = myYOHAKU_RIGHT

            pGJSINI_Array.SCR_BACKCOLOR = myBACKCOLOR
            pGJSINI_Array.SCR_BACKCOLOR_STRING = myBACKCOLOR_STRING

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        Return ret

    End Function
#End Region

#Region "LoSubExeStart EXE起動"
    '*******************************************************************************
    '*　　①　プロシージャ名        LoSubExeStart
    '*　　②　機能概要              EXE起動
    '*　　③　引数　　　　　　　　　iLVL2, iLVL3
    '*　　④　戻り値　　　　　　　　無し
    '*　　⑤　作成日　　　　　　　  2014/12/25 JBD368
    '*　　⑥　更新日　　　　　　　  
    '*******************************************************************************
    Private Sub s_Exe_Start(ByVal iLVL2 As Integer, ByVal iLVL3 As Integer)

        Dim strDll As String = String.Empty
        Dim strPGID As String = String.Empty

        Try
            For i As Integer = 0 To pSYORIKINO.Length - 1
                If pSYORIKINO(i).LVL1 = keyIndex Then
                    If pSYORIKINO(i).LVL2 = iLVL2 Then
                        If pSYORIKINO(i).LVL3 = iLVL3 Then

                            'DLL名
                            strDll = pSYORIKINO(i).DLL_NAME
                            'PG名
                            strPGID = pSYORIKINO(i).KINO_ID
                            Exit For
                        End If
                    End If
                End If
            Next

            '使用チェック
            If strDll = "" OrElse strPGID = "" Then
                'プログラムに未組み込み
                Show_MessageBox_Add("E003", "現在使用できません。")
                Exit Sub
            End If

            '引数で引き渡されたHiku.INI構造体の内容をグローバル変数へセット
            If Not f_pINI_Array(pGJSINI_Array) Then
                Exit Try
            End If

            '現画面、非表示
            Me.Visible = False

            'ブログラム起動
            'f_ApShow(pGJSINI_Array, strPGID, strDll)

            If strPGID = "GJ1030" Then
                Dim form As New frmGJ1030(pGJSINI_Array)
                form.Owner = Me
                ''form.pSel_KENCD = strKENCD          '現在選択されている行のキーを渡します
                'form.pSel_ITAKUCD = strITAKUCD      '現在選択されている行のキーを渡します
                'form.pSel_NO = intNo                '現在選択されている行のキーを渡します
                'form.pSiyoKbn = dstDataSet.Tables(0).Rows(0)("SIYO_KBN")
                'form.paryKEY_9081 = paryKEY_9080

                'フォームクローズ
                Me.Visible = False

                form.ShowDialog()
            End If

            If strPGID = "GJ1020" Then
                Dim form As New frmGJ1020(pGJSINI_Array)
                form.Owner = Me
                ''form.pSel_KENCD = strKENCD          '現在選択されている行のキーを渡します
                'form.pSel_ITAKUCD = strITAKUCD      '現在選択されている行のキーを渡します
                'form.pSel_NO = intNo                '現在選択されている行のキーを渡します
                'form.pSiyoKbn = dstDataSet.Tables(0).Rows(0)("SIYO_KBN")
                'form.paryKEY_9081 = paryKEY_9080

                'フォームクローズ
                Me.Visible = False

                form.ShowDialog()
            End If

            If strPGID = "GJ1040" Then
                Dim form As New frmGJ1040(pGJSINI_Array)
                form.Owner = Me
                ''form.pSel_KENCD = strKENCD          '現在選択されている行のキーを渡します
                'form.pSel_ITAKUCD = strITAKUCD      '現在選択されている行のキーを渡します
                'form.pSel_NO = intNo                '現在選択されている行のキーを渡します
                'form.pSiyoKbn = dstDataSet.Tables(0).Rows(0)("SIYO_KBN")
                'form.paryKEY_9081 = paryKEY_9080

                'フォームクローズ
                Me.Visible = False

                form.ShowDialog()
            End If

            If strPGID = "GJ1050" Then
                Dim form As New frmGJ1050(pGJSINI_Array)
                form.Owner = Me
                ''form.pSel_KENCD = strKENCD          '現在選択されている行のキーを渡します
                'form.pSel_ITAKUCD = strITAKUCD      '現在選択されている行のキーを渡します
                'form.pSel_NO = intNo                '現在選択されている行のキーを渡します
                'form.pSiyoKbn = dstDataSet.Tables(0).Rows(0)("SIYO_KBN")
                'form.paryKEY_9081 = paryKEY_9080

                'フォームクローズ
                Me.Visible = False

                form.ShowDialog()
            End If

            If strPGID = "GJ1060" Then
                Dim form As New frmGJ1060(pGJSINI_Array)
                form.Owner = Me
                ''form.pSel_KENCD = strKENCD          '現在選択されている行のキーを渡します
                'form.pSel_ITAKUCD = strITAKUCD      '現在選択されている行のキーを渡します
                'form.pSel_NO = intNo                '現在選択されている行のキーを渡します
                'form.pSiyoKbn = dstDataSet.Tables(0).Rows(0)("SIYO_KBN")
                'form.paryKEY_9081 = paryKEY_9080

                'フォームクローズ
                Me.Visible = False

                form.ShowDialog()
            End If

            If strPGID = "GJ1070" Then
                Dim form As New frmGJ1070(pGJSINI_Array)
                form.Owner = Me
                ''form.pSel_KENCD = strKENCD          '現在選択されている行のキーを渡します
                'form.pSel_ITAKUCD = strITAKUCD      '現在選択されている行のキーを渡します
                'form.pSel_NO = intNo                '現在選択されている行のキーを渡します
                'form.pSiyoKbn = dstDataSet.Tables(0).Rows(0)("SIYO_KBN")
                'form.paryKEY_9081 = paryKEY_9080

                'フォームクローズ
                Me.Visible = False

                form.ShowDialog()
            End If

            If strPGID = "GJ1010" Then
                Dim form As New frmGJ1010(pGJSINI_Array)
                form.Owner = Me
                ''form.pSel_KENCD = strKENCD          '現在選択されている行のキーを渡します
                'form.pSel_ITAKUCD = strITAKUCD      '現在選択されている行のキーを渡します
                'form.pSel_NO = intNo                '現在選択されている行のキーを渡します
                'form.pSiyoKbn = dstDataSet.Tables(0).Rows(0)("SIYO_KBN")
                'form.paryKEY_9081 = paryKEY_9080

                'フォームクローズ
                Me.Visible = False

                form.ShowDialog()
            End If

            If strPGID = "GJ1011" Then
                Dim form As New frmGJ1011(pGJSINI_Array)
                form.Owner = Me
                ''form.pSel_KENCD = strKENCD          '現在選択されている行のキーを渡します
                'form.pSel_ITAKUCD = strITAKUCD      '現在選択されている行のキーを渡します
                'form.pSel_NO = intNo                '現在選択されている行のキーを渡します
                'form.pSiyoKbn = dstDataSet.Tables(0).Rows(0)("SIYO_KBN")
                'form.paryKEY_9081 = paryKEY_9080

                'フォームクローズ
                Me.Visible = False

                form.ShowDialog()
            End If

            If strPGID = "GJ1012" Then
                Dim form As New frmGJ1012(pGJSINI_Array)
                form.Owner = Me
                ''form.pSel_KENCD = strKENCD          '現在選択されている行のキーを渡します
                'form.pSel_ITAKUCD = strITAKUCD      '現在選択されている行のキーを渡します
                'form.pSel_NO = intNo                '現在選択されている行のキーを渡します
                'form.pSiyoKbn = dstDataSet.Tables(0).Rows(0)("SIYO_KBN")
                'form.paryKEY_9081 = paryKEY_9080

                'フォームクローズ
                Me.Visible = False

                form.ShowDialog()
            End If

            If strPGID = "GJ1013" Then
                Dim form As New frmGJ1013(pGJSINI_Array)
                form.Owner = Me
                ''form.pSel_KENCD = strKENCD          '現在選択されている行のキーを渡します
                'form.pSel_ITAKUCD = strITAKUCD      '現在選択されている行のキーを渡します
                'form.pSel_NO = intNo                '現在選択されている行のキーを渡します
                'form.pSiyoKbn = dstDataSet.Tables(0).Rows(0)("SIYO_KBN")
                'form.paryKEY_9081 = paryKEY_9080

                'フォームクローズ
                Me.Visible = False

                form.ShowDialog()
            End If

            If strPGID = "GJ2010" Then
                Dim form As New frmGJ2010(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2011" Then
                Dim form As New frmGJ2011(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2020" Then
                Dim form As New frmGJ2020(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2030" Then
                Dim form As New frmGJ2030(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2040" Then
                Dim form As New frmGJ2040(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2050" Then
                Dim form As New frmGJ2050(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2051" Then
                Dim form As New frmGJ2051(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2060" Then
                Dim form As New frmGJ2060(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2061" Then
                Dim form As New frmGJ2061(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2070" Then
                Dim form As New frmGJ2070(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2080" Then
                Dim form As New frmGJ2080(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2090" Then
                Dim form As New frmGJ2090(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2091" Then
                Dim form As New frmGJ2091(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2092" Then
                Dim form As New frmGJ2092(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2100" Then
                Dim form As New frmGJ2100(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2110" Then
                Dim form As New frmGJ2110(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ2120" Then
                Dim form As New frmGJ2120(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ3010" Then
                Dim form As New frmGJ3010(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ3020" Then
                Dim form As New frmGJ3020(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ3030" Then
                Dim form As New frmGJ3030(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ4010" Then
                Dim form As New frmGJ4010(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ4020" Then
                Dim form As New frmGJ4020(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ4030" Then
                Dim form As New frmGJ4030(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ4040" Then
                Dim form As New frmGJ4040(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ4050" Then
                Dim form As New frmGJ4050(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ4060" Then
                Dim form As New frmGJ4060(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ4070" Then
                Dim form As New frmGJ4070(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ5010" Then
                Dim form As New frmGJ5010(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ7010" Then
                Dim form As New frmGJ7010(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ7020" Then
                Dim form As New frmGJ7020(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ7030" Then
                Dim form As New frmGJ7030(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ6010" Then
                Dim form As New frmGJ6010(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ6020" Then
                Dim form As New frmGJ6020(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ6030" Then
                Dim form As New frmGJ6030(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ6040" Then
                Dim form As New frmGJ6040(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ6021" Then
                Dim form As New frmGJ6021(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ8010" Then
                Dim form As New frmGJ8010(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ8020" Then
                Dim form As New frmGJ8020(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ8030" Then
                Dim form As New frmGJ8030(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ8040" Then
                Dim form As New frmGJ8040(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ8050" Then
                Dim form As New frmGJ8050(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ8060" Then
                Dim form As New frmGJ8060(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ8070" Then
                Dim form As New frmGJ8070(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ8080" Then
                Dim form As New frmGJ8080(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ8090" Then
                Dim form As New frmGJ8090(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ8100" Then
                Dim form As New frmGJ8100(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ9010" Then
                Dim form As New frmGJ9010(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            If strPGID = "GJ9020" Then
                Dim form As New frmGJ9020(pGJSINI_Array)
                form.Owner = Me
                Me.Visible = False
                form.ShowDialog()
            End If
            '現画面、再表示
            Me.Visible = True
            Me.WindowState = FormWindowState.Normal

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox_Add("W019", "該当メニューは現在使用できません。管理者に確認してください。")
        Finally
            If Me.WindowState = FormWindowState.Minimized Then
                Me.WindowState = FormWindowState.Normal
            End If
        End Try

    End Sub
#End Region

#Region "f_ApShow プログラム起動"
    '------------------------------------------------------------------
    'プロシージャ名  :f_ApShow
    '説明            :プログラム起動
    '引数            :pNJHINI_Array, strPGID, strDllName
    '戻り値          :Boolean(正常True/エラーFalse)
    '------------------------------------------------------------------
    Private Function f_ApShow(ByVal pNJHINI_Array As pGJSINI, ByVal strPGID As String, ByVal strDllName As String) As Boolean
        Dim ret As Boolean = False

        Try

            'DLL読込 modify sf
            Dim asm As Assembly = Assembly.LoadFrom(strDllName)
            'クラス取得
            Dim myType As Type = asm.GetType(strDllName & ".frm" & strPGID)
            'インスタンス作成
            Dim target As Object = myType.InvokeMember(Nothing,
                BindingFlags.CreateInstance,
                Nothing,
                Nothing,
                New Object() {pNJHINI_Array})
            'FORM SHOW
            Dim Form = CType(target, Form)
            Form.ShowDialog()

            ret = True

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox_Add("W019", "該当メニューは現在使用できません。管理者に確認してください。")
        Finally

        End Try

        Return ret

    End Function
#End Region
#End Region






End Class


