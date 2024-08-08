Imports GrapeCity.ActiveReports.SectionReportModel 
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ4050
    Sub sub1(wkDSRep As DataSet, pSyoriKbn As Integer)
End Interface

Public Class rptGJ4050
    Implements InterfaceRptGJ4050
    '１ページの最大出力行数
    Const MAX_ROW_COUNT As Integer = 8

    Dim GroupCount As Int16     'グループ内のレコード数
    Dim iCnt As Integer         '詳細行の番号
    Dim mCnt As Integer         'レコードの番号
    Dim gCnt As Integer         'グループの番号
    Dim MAX_mCnt As Integer     'レコードの最大値（全部でいくつのレコードが存在しているかを表します）
    Dim MAX_gCnt As Integer     'グループの最大値（全部でいくつのグループが存在しているかを表します）

    Public pSyoriKbn As Integer
    Property pKikin2 As Boolean     '2017/09/08　追加
    Public pRptName As String = "家畜防疫互助金交付通知書（振込）"     '帳票名

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint

        ''事務委託先表示
        'If JIMUITAKU_CD.Text = "" OrElse JIMUITAKU_CD.Text = "0" OrElse
        '  JIMUITAKU_CD.Text = "000" OrElse JIMUITAKU_CD.Text = "999" Then
        '    lbl_ITAKU_NAME.Visible = False
        '    txt_ITAKU_NAME1.Visible = False
        'Else
        '    lbl_ITAKU_NAME.Visible = True
        '    txt_ITAKU_NAME1.Visible = True
        'End If

        ''銀行表示
        'If BANK_INJI_KBN.Text = "2" Then
        '    s_FurikomiDsp(False)
        'Else
        '    s_FurikomiDsp(True)
        'End If




    End Sub


    Private Sub Detail_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail.Format

        ''日鶏99発第9999号
        'txt_HAKKOa.Text = HAKKO_NO_KANJIa.Text & SEIKYU_HAKKO_NO_NENa.Text & "発第" & SEIKYU_HAKKO_NO_RENBANa.Text & "号"
        'If pSyoriKbn = 1 Then
        '    txt_SaiHakkoa.Text = ""
        'Else
        '    txt_SaiHakkoa.Text = pSyoriKbn
        'End If

        ''ヘッダ
        'txt_HD_TEXT.Text = "　平素は家畜防疫互助事業にご協力いただきありがとうございます。" & vbCrLf & _
        '                   "下記のとおり、第" & TOU_KI_N.Text & "期互助事業積立金等のご請求をいたします。併せて、第" & ZEN_KI_N.Text & "期互助金の積立金" & vbCrLf & _
        '                   "における返還金を通知いたします。なお、第" & TOU_KI_N.Text & "期互助金事業積立金等については、第" & ZEN_KI_N.Text & "期互助事" & vbCrLf & _
        '                   "業積立金の返還金と相殺したところ下記のとおり積立金等に不足が生じましたので、下記の納付" & vbCrLf & _
        '                   "金額をお振込くださいますよう、お願い申し上げます。"

        ''返還明細
        'lbl_HD1.Text = "第" & ZEN_KI_N.Text & "生産者積立金　返還金"
        'lbl_HD2.Text = "第" & ZEN_KI_N.Text & "期積立金"

        ''請求明細
        'lbl_DTL_HD.Text = "第" & TOU_KI_N.Text & "期生産者積立金ご請求明細（" & KEIYAKU_KBN_NM.Text & "）"
        'lbl_DTL_FT1.Text = "　積立金合計(Ｂ) × " & TESURYO_RITU.Text & "％(100円未満切捨)"
        'lbl_DTL_FT2.Text = "　第" & TOU_KI_N.Text & "期請求金額合計(Ｄ)"

        ''事務委託先表示
        'If JIMUITAKU_CD.Text = "" OrElse JIMUITAKU_CD.Text = "0" OrElse
        '  JIMUITAKU_CD.Text = "000" OrElse JIMUITAKU_CD.Text = "999" Then
        '    lbl_ITAKU_NAME.Visible = False
        '    txt_ITAKU_NAME1.Visible = False
        'Else
        '    lbl_ITAKU_NAME.Visible = True
        '    txt_ITAKU_NAME1.Visible = True
        'End If

        '銀行表示
        'If BANK_INJI_KBN.Text = "2" Then
        '    s_FurikomiDsp(False)
        'Else
        '    s_FurikomiDsp(True)
        'End If


        GroupCount = GroupCount + 1
        If IIf(DTL_CNT.Text = "", 0, DTL_CNT.Text) < 6 Then
            Detail.RepeatToFill = True
        ElseIf GroupCount = 10 Then
            'Detail.RepeatToFill = True
        Else
            Detail.RepeatToFill = False
        End If

        '2017/09/08　追加開始
        'タイトル
        If pKikin2 Then
            '第２基金
            TextBox7.Text = "家畜防疫互助金交付通知書(追加納付)"
        End If
        '2017/09/08　追加終了

    End Sub

    Private Sub s_FurikomiDsp(ByVal wEnable As Boolean)

        'lbl_NOFUKIGEN_DATE11.Visible = wEnable
        'lbl_NOFUKIGEN_DATE12.Visible = wEnable
        'lbl_NOFUKIGEN_DATE13.Visible = wEnable
        'txt_NOFUKIGEN_DATE.Visible = wEnable

        'lbl_FURI_BANK_TITLE11.Visible = wEnable
        'lbl_FURI_BANK_TITLE12.Visible = wEnable
        'lbl_FURI_BANK_TITLE13.Visible = wEnable

        'lbl_FURI_BANK_NAME.Visible = wEnable
        'txt_FURI_BANK_NAME.Visible = wEnable
        'txt_FURI_BANK_KANA.Visible = wEnable

        'lbl_FURI_SITEN_NAME.Visible = wEnable
        'txt_FURI_SITEN_NAME.Visible = wEnable
        'txt_FURI_SITEN_KANA.Visible = wEnable

        'lbl_FURI_KOZA_SYUBETU.Visible = wEnable
        'txt_FURI_KOZA_SYUBETU.Visible = wEnable

        'lbl_FURI_KOZA_NO_N.Visible = wEnable
        'txt_FURI_KOZA_NO_N.Visible = wEnable

        'lbl_FURI_KOZA_MEIGI.Visible = wEnable
        'txt_FURI_KOZA_MEIGI.Visible = wEnable
        'txt_FURI_KOZA_MEIGI_KANA.Visible = wEnable


        'txt_FURI_FT1.Visible = wEnable
        'txt_FURI_FT21.Visible = wEnable
        'txt_FURI_FT22.Visible = wEnable
        'txt_FURI_FT23.Visible = wEnable
        'txt_FURI_FT3.Visible = wEnable

    End Sub



    Private Sub GRP_HD_KEIYAKUSYA_CD_BeforePrint(sender As Object, e As System.EventArgs) Handles GRP_HD_KEIYAKUSYA_CD.BeforePrint

    End Sub

    Private Sub rptGJ4050_PageStart(sender As Object, e As System.EventArgs) Handles Me.PageStart
        GroupCount = 0
    End Sub
    Sub sub1(wkDSRep As DataSet, pSyoriKbn As Integer) Implements InterfaceRptGJ4050.sub1
        Using wkAR As New rptGJ4050
            '処理区分
            'If rbtn_SYORI_KBN1.Checked Then
            '    wkAR.pSyoriKbn = 1
            'ElseIf rbtn_SYORI_KBN1.Checked Then
            '    wkAR.pSyoriKbn = 2
            'Else
            wkAR.pSyoriKbn = pSyoriKbn
            'End If

            'ヘッダ用の値を保管
            wkAR.pKikin2 = pKikin2      '2017/09/08　追加
            ' 用紙サイズを A4縦 に設定します。
            wkAR.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
            wkAR.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait
            ' 上下の余白を 1.0cm に設定します。
            wkAR.PageSettings.Margins.Top = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_UP)
            wkAR.PageSettings.Margins.Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_DOWN)
            ' 左の余白を 1.0cm に設定します。
            wkAR.PageSettings.Margins.Left = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_LEFT)
            ' 右の余白を 0.0cm に設定します。
            myYOHAKU_RIGHT = 0
            wkAR.PageSettings.Margins.Right = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_RIGHT)

            '----------------------------------------------------

            '----------------------------------------------------
            wkAR.DataSource = wkDSRep
            wkAR.DataMember = wkDSRep.Tables(0).TableName
            wkAR.Run(False) '実行

            ''--------------------------------------------------
            ''ＰＤＦ出力
            ''--------------------------------------------------
            'ファイル存在ﾁｪｯｸ()
            Dim strOutPath As String = ""
            If Not f_ReportPath_Check(strOutPath, 0, myREPORT_PDF_PATH, pAPP & pRptName) Then
                Exit Sub
            Else
                Using export As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                    export.Export(wkAR.Document, strOutPath)
                End Using
            End If

            '--------------------------------------------------
            'プレビュー表示
            '--------------------------------------------------
            Dim wkForm As New frmViewer(wkAR, pAPP & pRptName) '※このプレビューは関数を抜けたあとも生き残る。
            wkForm.Show()

        End Using
    End Sub
End Class
