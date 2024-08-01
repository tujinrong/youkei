Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ1050
    Sub sub1(wkDSRep As DataSet)
End Interface
Public Class rptGJ1050
    Implements InterfaceRptGJ1050

    '前のページのグループ情報を保持
    Private lo_KeiyakusyaCD As String
    Private lo_KeiyakusyaCD_CNT As Integer = 0
    Private cnt_line As Integer = 0 '2021/04/13 JBD9020 R03年度追加基金対応 ADD
    ''' <summary>
    ''' 期金２
    ''' </summary>
    ''' <remarks></remarks>
    Friend pKIKIN2 As Boolean       '2017/07/14　追加

    Private mae_Jimu As String '2021/04/13 JBD9020 R03年度追加基金対応 ADD

    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "事務委託先別・契約者別生産者積立金等一覧表（仮計算）"

    Private Sub rptGJ1050_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

        '2017/07/14　追加開始
        '第２基金の場合のみ、タイトルに(追加納付)を付加する
        If pKIKIN2 Then
            Label36.Text = "<<　事務委託先別・契約者別生産者積立金等一覧表（仮計算）(追加納付)　>>"
        End If
        '2017/07/14　追加終了
        cnt_line = 0 '2021/04/13 JBD9020 R03年度追加基金対応 ADD
    End Sub
    Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.BeforePrint

        ''詳細データが1ページちょうどの場合の対応
        'Dim wkIsNoDetail As Boolean = CInt(txtGroupPageCount.Text) >= 2 '2ページ目以降かどうか。

        'If wkIsNoDetail Then '前のページのグループ情報をセット
        '    txtItakusakiCD.Text = lo_ItakusakiCD
        '    '    txtTodofukenNm.Text = lo_BeforeKenNM
        'End If

        '前のページのグループ情報を待避
        'lo_ItakusakiCD = txtItakusakiCD.Text
        'lo_BeforeKenNM = txtTodofukenNm.Text


        '事務委託先CDの判定
        If JIMUITAKU_CD.Text = "9999" And KEIYAKUSYA_CD.Text = "999999" Then
            NYURYOKU_JYOKYO_NM_HED.Visible = False
            ITAKU_NAME_HED.Visible = False
        End If

        '2021/04/13 JBD9020 R03年度追加基金対応 UPD START
        If JIMUITAKU_CD.Text = "99999" Then
            ITAKU_NAME_HED.Visible = False
        End If
        '2021/04/13 JBD9020 R03年度追加基金対応 UPD END

    End Sub


    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint

        '納付額の算出
        NOUFU_KIN_SUM.Value = TUMITATE_KIN_SUM.Value + JIMU_TESURRYO_SUM.Value




    End Sub

    Private Sub Detail_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail.Format
        '鶏の種類件数が1の場合は合計は表示させない
        If KEIYAKUSYA_CD.Value < "999999" And TORI_KBN_CNT.Value = 1 Then
            Me.GroupFooter3.Visible = False
        Else
            Me.GroupFooter3.Visible = True
        End If

        '2021/04/13 JBD9020 R03年度追加基金対応 ADD START
        If cnt_line = 0 Then
            Line2.Visible = False
        Else
            Line2.Visible = True
        End If
        cnt_line = cnt_line + 1
        If cnt_line >= 16 Then
            cnt_line = 0
        End If
        If mae_Jimu <> JIMUITAKU_CD.Text Then
            cnt_line = 1
        End If
        mae_Jimu = JIMUITAKU_CD.Text
        '2021/04/13 JBD9020 R03年度追加基金対応 ADD END

    End Sub

    '2021/04/13 JBD9020 R03年度追加基金対応 ADD START
    Private Sub Groupfooter3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter3.Format

        If GroupFooter3.Visible = True Then
            If cnt_line = 0 Then
                Line10.Visible = False
            Else
                Line10.Visible = True
            End If
            cnt_line = cnt_line + 1
            If cnt_line >= 16 Then
                cnt_line = 0
            End If
        End If
    End Sub
    '2021/04/13 JBD9020 R03年度追加基金対応 ADD END

    Private Sub GroupHeader3_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader3.BeforePrint
        '契約者CDの判定
        If KEIYAKUSYA_CD.Value = "999999" Then
            KEIYAKUSYA_CD.Visible = False
            KEIYAKUSYA_NAME.Alignment = TextAlignment.Center
        Else
            KEIYAKUSYA_CD.Visible = True
            KEIYAKUSYA_NAME.Alignment = TextAlignment.Justify
        End If

    End Sub

    Sub sub1(wkDSRep As DataSet) Implements InterfaceRptGJ1050.sub1
        ' Insert code here that implements this method.
        Using wkAR As New rptGJ1050

            'ヘッダ用の値を保管
            wkAR.pKIKIN2 = pKIKIN2      '2017/07/14　追加
            ' 用紙サイズを B4横 に設定します。
            wkAR.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
            wkAR.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape
            ' 上下の余白を 1.0cm に設定します。
            wkAR.PageSettings.Margins.Top = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_UP)
            wkAR.PageSettings.Margins.Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_DOWN)
            'wkAR.PageSettings.Margins.Bottom = 0.87
            ' 左右の余白を 1.0cm に設定します。
            wkAR.PageSettings.Margins.Left = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_LEFT)
            wkAR.PageSettings.Margins.Right = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_RIGHT)

            '----------------------------------------------------
            wkAR.DataSource = wkDSRep
            wkAR.DataMember = wkDSRep.Tables(0).TableName
            wkAR.Run() '実行

            ''--------------------------------------------------
            ''ＰＤＦ出力
            ''--------------------------------------------------
            'ファイル存在ﾁｪｯｸ()
            Dim strOutPath As String = ""
            If Not f_ReportPath_Check(strOutPath, 0, myREPORT_PDF_PATH, pAPP & con_ReportName) Then
                Exit Sub
            Else
                Using export As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                    export.Export(wkAR.Document, strOutPath)
                End Using
            End If

            '--------------------------------------------------
            'プレビュー表示
            '--------------------------------------------------
            Dim wkForm As New frmViewer(wkAR, pAPP & con_ReportName) '※このプレビューは関数を抜けたあとも生き残る。
            wkForm.Show()
        End Using

    End Sub


End Class
