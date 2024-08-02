Imports GrapeCity.ActiveReports.SectionReportModel 
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ2040
    Sub sub1(wkDSRep As DataSet, pSyoriKbn As Integer)
End Interface

Public Class rptGJ2040
    Implements InterfaceRptGJ2040

    Property pSyoriKbn As Integer
    Property pKikin2 As Boolean     '2017/07/20　追加
    Property imgInei As Object      '2018/06/12  追加

    Public pRptName As String = "生産者積立金等請求・返還通知書（一部徴収）"     '帳票名

    Private Sub Detail_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.BeforePrint

        '事務委託先表示
        If JIMUITAKU_CD.Text = "" OrElse JIMUITAKU_CD.Text = "0" OrElse
          JIMUITAKU_CD.Text = "000" OrElse JIMUITAKU_CD.Text = "999" Then
            lbl_ITAKU_NAME.Visible = False
            txt_ITAKU_NAME1.Visible = False
        Else
            lbl_ITAKU_NAME.Visible = True
            txt_ITAKU_NAME1.Visible = True
        End If

        'lbl_ITAKU_NAME.Location = New System.Drawing.PointF(CmToInch(1.3), CmToInch(21.8))  '2018/07/09 追加
        'txt_ITAKU_NAME1.Location = New System.Drawing.PointF(CmToInch(4.1), CmToInch(21.8)) '2018/07/09 追加
        lbl_ITAKU_NAME.Location = New System.Drawing.PointF(CmToInch(1.3), CmToInch(21.9))  '2023/08/24 JBD454 変更
        txt_ITAKU_NAME1.Location = New System.Drawing.PointF(CmToInch(4.1), CmToInch(21.9)) '2023/08/24 JBD454 変更

        '銀行表示
        If BANK_INJI_KBN.Text = "2" Then
            s_FurikomiDsp(False)
        Else
            s_FurikomiDsp(True)
        End If

    End Sub


    Private Sub Detail_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail.Format

        '日鶏99発第9999号
        txt_HAKKO.Text = HAKKO_NO_KANJI.Text & SEIKYU_HAKKO_NO_NEN.Text & "発第" & SEIKYU_HAKKO_NO_RENBAN.Text & "号"
        If pSyoriKbn = 1 Then
            txt_SaiHakko.Text = ""
        Else
            txt_SaiHakko.Text = pSyoriKbn
        End If

        '2017/07/20　修正開始
        'lbl_DTL_HD.Text = "第" & TOU_KI_N.Text & "期生産者積立金ご請求明細(" & KEIYAKU_KBN_NM.Text & ")"
        If pKikin2 Then
            txt_Title.Text = "家畜防疫互助基金積立金等請求書兼返還金通知書(追加納付)"
            lbl_DTL_HD.Text = "第" & TOU_KI_N.Text & "期生産者積立金ご請求明細(追加納付)(" & KEIYAKU_KBN_NM.Text & ")"
        Else
            txt_Title.Text = "家畜防疫互助基金積立金等請求書兼返還金通知書"
            lbl_DTL_HD.Text = "第" & TOU_KI_N.Text & "期生産者積立金ご請求明細(" & KEIYAKU_KBN_NM.Text & ")"
        End If
        '2017/07/20　修正終了

        'ヘッダ
        txt_HD_TEXT.Text = "　平素は家畜防疫互助事業にご協力いただきありがとうございます。" & vbCrLf & _
                           "下記のとおり、第" & TOU_KI_N.Text & "期互助事業積立金等のご請求をいたします。併せて、第" & ZEN_KI_N.Text & "期互助金の積立金" & vbCrLf & _
                           "における返還金を通知いたします。なお、第" & TOU_KI_N.Text & "期互助金事業積立金等については、第" & ZEN_KI_N.Text & "期互助事" & vbCrLf & _
                           "業積立金の返還金と相殺したところ下記のとおり積立金等に不足が生じましたので、下記の納付" & vbCrLf & _
                           "金額をお振込みくださいますよう、お願い申し上げます。"

        '返還明細
        lbl_HD1.Text = "第" & ZEN_KI_N.Text & "期生産者積立金　返還金"
        lbl_HD2.Text = "第" & ZEN_KI_N.Text & "期積立金"

        '請求明細
        lbl_DTL_FT1.Text = "　積立金合計(Ｂ) × " & TESURYO_RITU.Text & "％(100円未満切捨)"
        lbl_DTL_FT2.Text = "　第" & TOU_KI_N.Text & "期請求金額合計(Ｄ)"

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

        '印影
        inei.Image = imgInei  '2018/06/12  追加

    End Sub

    Private Sub s_FurikomiDsp(ByVal wEnable As Boolean)

        'lbl_NOFUKIGEN_DATE11.Visible = wEnable
        lbl_NOFUKIGEN_DATE12.Visible = wEnable
        lbl_NOFUKIGEN_DATE13.Visible = wEnable
        txt_NOFUKIGEN_DATE.Visible = wEnable

        'lbl_FURI_BANK_TITLE11.Visible = wEnable
        lbl_FURI_BANK_TITLE12.Visible = wEnable
        lbl_FURI_BANK_TITLE13.Visible = wEnable

        lbl_FURI_BANK_NAME.Visible = wEnable
        txt_FURI_BANK_NAME.Visible = wEnable
        txt_FURI_BANK_KANA.Visible = wEnable

        lbl_FURI_SITEN_NAME.Visible = wEnable
        txt_FURI_SITEN_NAME.Visible = wEnable
        txt_FURI_SITEN_KANA.Visible = wEnable

        lbl_FURI_KOZA_SYUBETU.Visible = wEnable
        txt_FURI_KOZA_SYUBETU.Visible = wEnable

        lbl_FURI_KOZA_NO_N.Visible = wEnable
        txt_FURI_KOZA_NO_N.Visible = wEnable

        lbl_FURI_KOZA_MEIGI.Visible = wEnable
        txt_FURI_KOZA_MEIGI.Visible = wEnable
        txt_FURI_KOZA_MEIGI_KANA.Visible = wEnable


        txt_FURI_FT1.Visible = wEnable
        txt_FURI_FT21.Visible = wEnable
        txt_FURI_FT22.Visible = wEnable
        txt_FURI_FT23.Visible = wEnable
        txt_FURI_FT3.Visible = wEnable
        txt_FURI_FT131.Visible = wEnable    '2017/07/29　追加

    End Sub

    Sub sub1(wkDSRep As DataSet, pSyoriKbn As Integer
             ) Implements InterfaceRptGJ2040.sub1
        Using wkAR As New rptGJ2040
            '2021/04/30 JBD9020 R03年度 UPD END

            '処理区分
            'If rbtn_SYORI_KBN1.Checked Then
            '    wkAR.pSyoriKbn = 1
            'ElseIf rbtn_SYORI_KBN1.Checked Then
            '    wkAR.pSyoriKbn = 2
            '    '2020/09/09 JBD9020 ADD START
            'ElseIf rbtn_SYORI_KBN0.Checked Then
            '    wkAR.pSyoriKbn = 0
            '    '2020/09/09 JBD9020 ADD END
            'Else
            wkAR.pSyoriKbn = pSyoriKbn
            'End If

            '印影を取得
            wkAR.imgInei = f_inei_Get() '2018/06/12 追加
            'ヘッダ用の値を保管
            wkAR.pKikin2 = pKikin2      '2017/07/14　追加
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
