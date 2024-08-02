Imports GrapeCity.ActiveReports.SectionReportModel 
Imports GrapeCity.ActiveReports.Document.Section
Imports JbdGjsCommon
Interface InterfaceRptGJ3021
    Sub sub1(wkDSRep As DataSet, KEIYAKU_KBN_MAE As Integer, pSyoriKbn As Integer)
End Interface

Public Class rptGJ3021
    Implements InterfaceRptGJ3021

    'Property pSyoriKbn As Integer
    'Property pKeiyakuKbnMae As Integer
    'Property pKikin2 As Boolean     '2017/07/14　追加
    'Property imgInei As Object      '2018/07/09  追加
    '''' <summary>
    '''' リスト用
    '''' </summary>
    '''' <remarks></remarks>
    'Public pRptName As String = "互助基金契約区分変更の請求書（契約区分変更）"  '帳票名
    'Private Sub rptGJ3021_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

    '    For i As Integer = 1 To 6
    '        CType(Me.Detail.Controls("lbl_NO" & i), GrapeCity.ActiveReports.SectionReportModel.Label).Text = ""
    '        CType(Me.Detail.Controls("lbl_TORI_KBN_NM" & i), GrapeCity.ActiveReports.SectionReportModel.Label).Text = ""
    '        CType(Me.Detail.Controls("txt_MAE_HASU" & i), GrapeCity.ActiveReports.SectionReportModel.TextBox).Text = ""
    '        CType(Me.Detail.Controls("txt_MAE_HASU" & i), GrapeCity.ActiveReports.SectionReportModel.TextBox).Text = ""
    '        CType(Me.Detail.Controls("txt_MAE_TANKA" & i), GrapeCity.ActiveReports.SectionReportModel.TextBox).Text = ""
    '        CType(Me.Detail.Controls("txt_MAE_TUMITATE" & i), GrapeCity.ActiveReports.SectionReportModel.TextBox).Text = ""
    '        CType(Me.Detail.Controls("txt_ATO_TANKA" & i), GrapeCity.ActiveReports.SectionReportModel.TextBox).Text = ""
    '        CType(Me.Detail.Controls("txt_ATO_TUMITATE" & i), GrapeCity.ActiveReports.SectionReportModel.TextBox).Text = ""
    '        CType(Me.Detail.Controls("txt_ATO_SAGAKU" & i), GrapeCity.ActiveReports.SectionReportModel.TextBox).Text = ""
    '    Next

    'End Sub

    'Private Sub Detail_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail.Format
    '    Dim wKBN As Integer = 1
    '    Dim wGokeiKingaku_Visible As Boolean = True

    '    '日鶏99発第9999号
    '    If pSyoriKbn = 0 Then
    '        '仮請求
    '        txt_HAKKO.Text = HAKKO_NO_KANJI.Text & "  " & "発第" & "    " & "号"
    '        txt_SaiHakko.Text = ""
    '    Else
    '        '仮請求以外
    '        txt_HAKKO.Text = HAKKO_NO_KANJI.Text & SEIKYU_HAKKO_NO_NEN.Text & "発第" & SEIKYU_HAKKO_NO_RENBAN.Text & "号"
    '        If pSyoriKbn > 1 Then
    '            txt_SaiHakko.Text = pSyoriKbn
    '        Else
    '            txt_SaiHakko.Text = ""
    '        End If
    '    End If

    '    '契約区分によって変更となる部分
    '    '2017/07/14　修正開始
    '    'If pKeiyakuKbnMae = 1 Then
    '    '    '家族→企業
    '    '    txt_Title.Text = "家畜防疫互助基金積立金等請求通知書（契約型変更）"
    '    '    txt_Body.Text = "　平素は家畜防疫互助事業にご協力いただきありがとうございます。" & vbCrLf & _
    '    '                    "先般申請があった契約型の変更に伴い、下記のとおり差額をご請求申し上げます。つきまして" & vbCrLf & _
    '    '                    "は、下記の納付金額を期限までにお振込みくださいますようお願い申し上げます。"
    '    '    txt_title1.Text = "（家族型から企業型に変更）"
    '    'Else
    '    '    '企業→家族
    '    '    txt_Title.Text = "家畜防疫互助基金積立金等返還金通知書（契約型変更）"
    '    '    txt_Body.Text = "　平素は家畜防疫互助事業にご協力いただきありがとうございます。" & vbCrLf & _
    '    '                    "先般申請があった契約型の変更に伴い、下記のとおり返還金が生じましたので通知いたします。" & vbCrLf & _
    '    '                    "なお、返還金は下記の金融機関にお振込みいたします。"
    '    '    txt_title1.Text = "（企業型から家族型に変更）"
    '    'End If

    '    If pKeiyakuKbnMae = 1 Then
    '        '家族→企業
    '        If pKikin2 Then
    '            txt_Title.Text = "家畜防疫互助基金積立金等請求通知書(追加納付)(契約型変更)"
    '        Else
    '            txt_Title.Text = "家畜防疫互助基金積立金等請求通知書(契約型変更)"
    '        End If
    '        txt_Body.Text = "　平素は家畜防疫互助事業にご協力いただきありがとうございます。" & vbCrLf & _
    '                        "先般申請があった契約型の変更に伴い、下記のとおり差額をご請求申し上げます。つきまして" & vbCrLf & _
    '                        "は、下記の納付金額を期限までにお振込みくださいますようお願い申し上げます。"
    '        txt_title1.Text = "(家族型から企業型に変更)"
    '        wGokeiKingaku_Visible = True    '2017/11/06　徴収時は合計表示
    '    Else
    '        '企業→家族
    '        If pKikin2 Then
    '            txt_Title.Text = "家畜防疫互助基金積立金等返還金通知書(追加納付)(契約型変更)"
    '        Else
    '            txt_Title.Text = "家畜防疫互助基金積立金等返還金通知書(契約型変更)"
    '        End If
    '        txt_Body.Text = "　平素は家畜防疫互助事業にご協力いただきありがとうございます。" & vbCrLf & _
    '                        "先般申請があった契約型の変更に伴い、下記のとおり返還金が生じましたので通知いたします。" & vbCrLf & _
    '                        "なお、返還金は下記の金融機関にお振込みいたします。"
    '        txt_title1.Text = "(企業型から家族型に変更)"
    '        wGokeiKingaku_Visible = False   '2017/11/06　返還時は合計非表示
    '    End If
    '    '2017/07/14　修正終了

    '    '合計金額等のコメント
    '    '2018/07/04　修正開始
    '    'lbl_KEI_FT1.Text = "（手数料：積立金合計×" & TESURYO_RITU.Text & "％"
    '    'lbl_KEI_FT2.Text = "　１００円未満は切り捨てた額です）"
    '    lbl_KEI_FT1.Text = "（手数料：積立金合計×" & TESURYO_RITU.Text & "％）"
    '    lbl_KEI_FT2.Text = "　　　　（100円未満切捨）"
    '    '2018/07/04　修正終了

    '    '事務委託先表示
    '    If pKeiyakuKbnMae = 1 Then
    '        wKBN = 1
    '    Else
    '        wKBN = 2
    '    End If

    '    '徴収　(家族→企業)
    '    If pKeiyakuKbnMae = 1 Then
    '        '事務委託先表示
    '        If JIMUITAKU_CD.Text = "" OrElse JIMUITAKU_CD.Text = "0" OrElse
    '           JIMUITAKU_CD.Text = "000" OrElse JIMUITAKU_CD.Text = "999" Then
    '            lbl_ITAKU_NAME1.Visible = False
    '            txt_ITAKU_NAME1.Visible = False
    '        Else
    '            lbl_ITAKU_NAME1.Visible = True
    '            txt_ITAKU_NAME1.Visible = True
    '        End If
    '        '銀行表示
    '        If BANK_INJI_KBN.Text = "2" Then
    '            s_FurikomiDsp1(False)
    '        Else
    '            s_FurikomiDsp1(True)
    '        End If
    '    Else
    '        '事務委託先表示
    '        If JIMUITAKU_CD.Text = "" OrElse JIMUITAKU_CD.Text = "0" OrElse
    '           JIMUITAKU_CD.Text = "000" OrElse JIMUITAKU_CD.Text = "999" Then
    '            lbl_ITAKU_NAME2.Visible = False
    '            txt_ITAKU_NAME2.Visible = False
    '        Else
    '            lbl_ITAKU_NAME2.Visible = True
    '            txt_ITAKU_NAME2.Visible = True
    '        End If
    '        '銀行表示
    '        If BANK_INJI_KBN.Text = "2" Then
    '            s_FurikomiDsp2(False)
    '        Else
    '            s_FurikomiDsp2(True)
    '        End If
    '    End If

    '    '印影
    '    inei.Image = imgInei      '2018/07/09  追加

    'End Sub

    'Private Sub s_FurikomiDsp1(ByVal wEnable As Boolean)

    '    'lbl_NOFUKIGEN_DATE11.Visible = wEnable     '2015/03/17　削除
    '    lbl_NOFUKIGEN_DATE12.Visible = wEnable
    '    lbl_NOFUKIGEN_DATE13.Visible = wEnable
    '    txt_NOFUKIGEN_DATE1.Visible = wEnable

    '    'lbl_FURI_BANK_TITLE11.Visible = wEnable    '2015/03/17　削除
    '    lbl_FURI_BANK_TITLE12.Visible = wEnable
    '    lbl_FURI_BANK_TITLE13.Visible = wEnable

    '    lbl_FURI_BANK_NAME1.Visible = wEnable
    '    txt_FURI_BANK_NAME1.Visible = wEnable
    '    txt_FURI_BANK_KANA1.Visible = wEnable

    '    lbl_FURI_SITEN_NAME1.Visible = wEnable
    '    txt_FURI_SITEN_NAME1.Visible = wEnable
    '    txt_FURI_SITEN_KANA1.Visible = wEnable

    '    lbl_FURI_KOZA_SYUBETU1.Visible = wEnable
    '    txt_FURI_KOZA_SYUBETU1.Visible = wEnable

    '    lbl_FURI_KOZA_NO_N1.Visible = wEnable
    '    txt_FURI_KOZA_NO_N1.Visible = wEnable

    '    lbl_FURI_KOZA_MEIGI1.Visible = wEnable
    '    txt_FURI_KOZA_MEIGI1.Visible = wEnable
    '    txt_FURI_KOZA_MEIGI_KANA1.Visible = wEnable

    '    txt_FURI_FT11.Visible = wEnable
    '    txt_FURI_FT121.Visible = wEnable
    '    txt_FURI_FT122.Visible = wEnable
    '    txt_FURI_FT123.Visible = wEnable
    '    txt_FURI_FT13.Visible = wEnable
    '    txt_FURI_FT131.Visible = wEnable
    '    txt_FURI_FT14.Visible = wEnable   '2018/07/09 追加
    '    txt_FURI_FT141.Visible = wEnable  '2018/07/09 追加

    'End Sub

    'Private Sub s_FurikomiDsp2(ByVal wEnable As Boolean)

    '    'lbl_NOFUKIGEN_DATE21.Visible = wEnable     '2015/03/17　削除
    '    lbl_NOFUKIGEN_DATE22.Visible = wEnable
    '    lbl_NOFUKIGEN_DATE23.Visible = wEnable
    '    txt_NOFUKIGEN_DATE2.Visible = wEnable

    '    'lbl_FURI_BANK_TITLE21.Visible = wEnable    '2015/03/17　削除
    '    lbl_FURI_BANK_TITLE22.Visible = wEnable
    '    lbl_FURI_BANK_TITLE23.Visible = wEnable

    '    lbl_FURI_BANK_NAME2.Visible = wEnable
    '    txt_FURI_BANK_NAME2.Visible = wEnable

    '    lbl_FURI_SITEN_NAME2.Visible = wEnable
    '    txt_FURI_SITEN_NAME2.Visible = wEnable

    '    lbl_FURI_KOZA_SYUBETU2.Visible = wEnable
    '    txt_FURI_KOZA_SYUBETU2.Visible = wEnable

    '    lbl_FURI_KOZA_NO_N2.Visible = wEnable
    '    txt_FURI_KOZA_NO_N2.Visible = wEnable

    '    lbl_FURI_KOZA_MEIGI2.Visible = wEnable
    '    txt_FURI_KOZA_MEIGI2.Visible = wEnable

    '    txt_FURI_FT21.Visible = wEnable

    'End Sub

    'Private Sub GRP_FT_KEIYAKU_KBN1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRP_FT_KEIYAKU_KBN1.Format

    'End Sub
    Sub sub1(wkDSRep As DataSet, KEIYAKU_KBN_MAE As Integer, pSyoriKbn As Integer) Implements InterfaceRptGJ3021.sub1
        'Using wkAR As New rptGJ3021
        '    'ヘッダ用の値を保管
        '    wkAR.pKikin2 = pKikin2      '2017/07/14　追加
        '    '印影を取得
        '    wkAR.imgInei = f_inei_Get() '2018/07/09  追加
        '    ' 用紙サイズを A4縦 に設定します。
        '    wkAR.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        '    wkAR.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait
        '    ' 上下の余白を 1.0cm に設定します。
        '    wkAR.PageSettings.Margins.Top = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_UP)
        '    wkAR.PageSettings.Margins.Bottom = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_DOWN)
        '    ' 左の余白を 1.0cm に設定します。
        '    wkAR.PageSettings.Margins.Left = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_LEFT)
        '    ' 右の余白を 0.0cm に設定します。
        '    myYOHAKU_RIGHT = 0
        '    wkAR.PageSettings.Margins.Right = GrapeCity.ActiveReports.SectionReport.CmToInch(myYOHAKU_RIGHT)

        '    '----------------------------------------------------

        '    '変更前　契約区分
        '    wkAR.pKeiyakuKbnMae = KEIYAKU_KBN_MAE

        '    If KEIYAKU_KBN_MAE = 1 Then
        '        '徴収　(家族→企業)
        '        pRptName = "互助基金契約区分変更（契約区分変更）請求通知書"
        '        wkAR.GRP_FT_GOKEI_KINGAKU.Visible = True    '2017/11/06　追加
        '        wkAR.GRP_FT_KEIYAKU_KBN1.Visible = True
        '        wkAR.GRP_FT_KEIYAKU_KBN2.Visible = False
        '    Else
        '        '返還　(企業→家族)
        '        pRptName = "互助基金契約区分変更（契約区分変更）返還通知書"
        '        wkAR.GRP_FT_GOKEI_KINGAKU.Visible = False   '2017/11/06　追加
        '        wkAR.GRP_FT_KEIYAKU_KBN1.Visible = False
        '        wkAR.GRP_FT_KEIYAKU_KBN2.Visible = True
        '    End If

        '    'If rbtn_SYORI_KBN0.Checked Then
        '    '    wkAR.pSyoriKbn = 0
        '    'ElseIf rbtn_SYORI_KBN1.Checked Then
        '    '    wkAR.pSyoriKbn = 1
        '    'ElseIf rbtn_SYORI_KBN2.Checked Then
        '    '    wkAR.pSyoriKbn = 2
        '    'Else
        '    wkAR.pSyoriKbn = pSyoriKbn
        '    'End If
        '    '----------------------------------------------------
        '    wkAR.DataSource = wkDSRep
        '    wkAR.DataMember = wkDSRep.Tables(0).TableName
        '    wkAR.Run() '実行

        '    ''--------------------------------------------------
        '    ''ＰＤＦ出力
        '    ''--------------------------------------------------
        '    'ファイル存在ﾁｪｯｸ()
        '    Dim strOutPath As String = ""
        '    If Not f_ReportPath_Check(strOutPath, 0, myREPORT_PDF_PATH, pAPP & pRptName) Then
        '        Exit Sub

        '    Else
        '        Using export As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
        '            export.Export(wkAR.Document, strOutPath)
        '        End Using
        '    End If

        '    '--------------------------------------------------
        '    'プレビュー表示
        '    '--------------------------------------------------
        '    Dim wkForm As New frmViewer(wkAR, pAPP & pRptName) '※このプレビューは関数を抜けたあとも生き残る。
        '    wkForm.Show()

        'End Using
    End Sub
End Class
