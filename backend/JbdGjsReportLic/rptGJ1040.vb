Imports JbdGjsCommon

Interface InterfaceRptGJ1040
    Sub sub1(wkDSRep As DataSet, wkKbn As Integer)
End Interface

Public Class rptGJ1040
    Implements InterfaceRptGJ1040

    '前のページのグループ情報を保持
    Private lo_BeforeKenCD As String
    Private lo_BeforeKenNM As String
    Friend pKIKIN2 As Boolean       '2017/07/14　追加

    ''' <summary>
    ''' 帳票名
    ''' </summary>
    ''' <remarks></remarks>
    Private Const con_ReportName As String = "契約者別契約情報入力確認チェックリスト(農場別等)"

    Private Sub rptGJ1040_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

        '2017/07/14　追加開始
        '第２基金の場合のみ、タイトルに(追加納付)を付加する
        If pKIKIN2 Then
            Label36.Text = "<<　契約者別契約情報入力確認チェックリスト(農場別等)(追加納付)　>>"
        End If
        '2017/07/14　追加終了

    End Sub

    Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader.BeforePrint

        ''詳細データが1ページちょうどの場合の対応
        'Dim wkIsNoDetail As Boolean = CInt(txtGroupPageCount.Text) >= 2 '2ページ目以降かどうか。

        'If wkIsNoDetail Then '前のページのグループ情報をセット
        '    txtTodofukenCd.Text = lo_BeforeKenCD
        '    txtTodofukenNm.Text = lo_BeforeKenNM
        'End If

        ''前のページのグループ情報を待避
        'lo_BeforeKenCD = txtTodofukenCd.Text
        'lo_BeforeKenNM = txtTodofukenNm.Text

        ''総合計時はページヘッダーの都道府県を非表示にする
        'If txtCurrentPage.Text = txtMaxPage.Text Then
        '    lblTodofuken.Visible = False
        '    txtTodofukenCd.Visible = False
        '    txtTodofukenNm.Visible = False
        'Else
        '    lblTodofuken.Visible = True
        '    txtTodofukenCd.Visible = True
        '    txtTodofukenNm.Visible = True
        'End If

        ''都道府県別の場合のデータ制御
        'If lblNm.Text = "都道府県" Then
        '    lblTodofuken.Visible = False
        '    txtTodofukenCd.Visible = False
        '    txtTodofukenNm.Visible = False
        '    Line5.Visible = True
        '    Line7.Visible = True
        '    Line2.Visible = False
        '    Line4.Visible = False
        'End If
    End Sub

    Private Sub Detail_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail.Format
        'If txt_DOITU_SEISANSYA_NAME.Text.Trim = "" Then
        '    txt_Kakko1.Text = ""
        '    txt_Kakko2.Text = ""
        'Else
        '    txt_Kakko1.Text = "("
        '    txt_Kakko2.Text = ")"
        'End If


        '2021/07/06 JBD9020 金融機関情報追加 ADD START
        Dim amari As Integer
        amari = CInt(DetailRowNum.Text) Mod 13

        If amari = 2 Then
            DetailBankInfo_Bank.Visible = True
            DetailBankInfo_Siten.Visible = True
            DetailBankInfo_Koza.Visible = True
            DetailBankInfo_Kana.Visible = True
            DetailBankInfo_Meigi.Visible = True
            DetailKeiyakuDate.Visible = True
        Else
            DetailBankInfo_Bank.Visible = False
            DetailBankInfo_Siten.Visible = False
            DetailBankInfo_Koza.Visible = False
            DetailBankInfo_Kana.Visible = False
            DetailBankInfo_Meigi.Visible = False
            DetailKeiyakuDate.Visible = False
        End If

        If amari = 1 Then
            Line2.Visible = False
        Else
            Line2.Visible = True
        End If
        '2021/07/06 JBD9020 金融機関情報追加 ADD END
    End Sub

    Private Sub rptGJ1040_ReportEnd(sender As Object, e As EventArgs) Handles Me.ReportEnd
        '        Line8.Visible = False
    End Sub

    '2021/07/06 JBD9020 金融機関情報追加 ADD START
    Private Sub GroupFooter3_Format(sender As Object, e As EventArgs) Handles GroupFooter3.Format
        If HasukeiRowCnt.Text = "1" Then
            HasukeiBankInfo_Bank.Visible = True
            HasukeiBankInfo_Siten.Visible = True
            HasukeiBankInfo_Koza.Visible = True
            HasukeiBankInfo_Kana.Visible = True
            HasukeiBankInfo_Meigi.Visible = True
            HasukeiKeiyakuDate.Visible = True
        Else
            HasukeiBankInfo_Bank.Visible = False
            HasukeiBankInfo_Siten.Visible = False
            HasukeiBankInfo_Koza.Visible = False
            HasukeiBankInfo_Kana.Visible = False
            HasukeiBankInfo_Meigi.Visible = False
            HasukeiKeiyakuDate.Visible = False
        End If
    End Sub
    '2021/07/06 JBD9020 金融機関情報追加 ADD END


    Sub sub1(wkDSRep As DataSet, wkKbn As Integer) Implements InterfaceRptGJ1040.sub1
        ' Insert code here that implements this method.
        Using wkAR As New rptGJ1040

            '入力者範囲
            If wkKbn = 0 Then
                '入力者別
                wkAR.USER_NAME_HED.Visible = True
            Else
                '契約番号
                wkAR.USER_NAME_HED.Visible = False
            End If

            'ヘッダ用の値を保管
            wkAR.pKIKIN2 = pKIKIN2      '2017/07/14　追加
            ' 用紙サイズを B4横 に設定します。
            wkAR.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.B4
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
