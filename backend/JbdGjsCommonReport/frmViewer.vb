
Imports GrapeCity.ActiveReports



Public Class frmViewer
    Private pstrReportName As String = String.Empty
    Private pRpt As New GrapeCity.ActiveReports.SectionReport

    Private cmdPDF As ToolStripButton
    Private cmdExcel As ToolStripButton
    Private cmdEnd As ToolStripButton

#Region "frmViewer_FormClosing frmViewer_FormClosingイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmViewer_FormClosing
    '説明            :frmViewer_FormClosingイベント
    '------------------------------------------------------------------
    Private Sub frmViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ' レポートインスタンスをDisposeします。
        pRpt.Document.Dispose()
        pRpt.Dispose()
        pRpt = Nothing

        'メモリの開放
        Call s_GC_Dispose()

    End Sub

#End Region

#Region "frmViewer_Load frmViewer_Loadイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :frmViewer_Load
    '説明            :frmViewer_Loadイベント
    '------------------------------------------------------------------
    Private Sub frmViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load


        Try

            Me.Viewer.Document = pRpt.Document
            pRpt.Run()


            'プレビュー表示と同時にＰＤＦにエクスポートを行います。(iniに設定されているパスへセットする)
            '保存場所は標準は共通変数から取得した場所、もしNULLの場合はマイドキュメントに保存します。
            If myREPORT_PDF_OUTKBN = 1 Then
                Dim export As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
                '出力するPDFファイル名(帳票ID+帳票名+yyyyMMddHHmmss[+.pdf/.xls])
                Dim strFileNM As String = myREPORT_PDF_PATH & "\" & pstrReportName & Now.ToString("yyyyMMddhhmmss") & ".pdf"
                export.Export(pRpt.Document, strFileNM)
                export.Dispose()
            End If

            'ViewerにPDF出力ボタン、Excel出力ボタンを追加します。
            'ボタンを生成します
            ''PDF出力ボタン
            'Dim cmdPDF As New GrapeCity.ActiveReports.SectionReportModel.Toolbar.Button
            'cmdPDF.Enabled = True
            'cmdPDF.Id = 777
            'cmdPDF.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon
            'cmdPDF.ImageIndex = 4
            'cmdPDF.ToolTip = "PDFに出力します"
            'cmdPDF.Visible = True
            'cmdPDF.Caption = "PDF出力"

            ''PDF出力ボタン
            'Dim cmdExcel As New GrapeCity.ActiveReports.SectionReportModel.Toolbar.Button
            'cmdExcel.Enabled = True
            'cmdExcel.Id = 888
            'cmdExcel.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon
            'cmdExcel.ImageIndex = 4
            'cmdExcel.ToolTip = "Excelに出力します"
            'cmdExcel.Visible = True
            'cmdExcel.Caption = "Excel出力"

            ''閉じるボタン
            'Dim cmdEnd As New GrapeCity.ActiveReports.SectionReportModel.Toolbar.Button
            'cmdEnd.Enabled = True
            'cmdEnd.Id = 999
            'cmdEnd.ButtonStyle = DataDynamics.ActiveReports.Toolbar.ButtonStyle.TextAndIcon
            'cmdEnd.ImageIndex = 10
            'cmdEnd.ToolTip = "プレビュー画面を終了します"
            'cmdEnd.Visible = True
            'cmdEnd.Caption = "閉じる"

            'PDF出力ボタン
            cmdPDF = New ToolStripButton("PDF出力")
            cmdPDF.Enabled = True
            cmdPDF.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            cmdPDF.ImageIndex = 4
            cmdPDF.ToolTipText = "PDFに出力します"
            cmdPDF.Visible = True
            AddHandler Me.cmdPDF.Click, AddressOf cmdPDF_Click


            'Excel出力ボタン
            cmdExcel = New ToolStripButton("Excel出力")
            cmdExcel.Enabled = True
            cmdExcel.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            cmdExcel.ImageIndex = 4
            cmdExcel.ToolTipText = "Excelに出力します"
            cmdExcel.Visible = True
            AddHandler Me.cmdExcel.Click, AddressOf cmdExcel_Click

            '閉じるボタン
            cmdEnd = New ToolStripButton("閉じる")
            cmdEnd.Enabled = True
            cmdEnd.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            cmdEnd.ImageIndex = 10
            cmdEnd.ToolTipText = "プレビュー画面を終了します"
            cmdEnd.Visible = True
            AddHandler Me.cmdEnd.Click, AddressOf cmdEnd_Click

            ''ImageListを生成します。
            'Dim i As New System.Windows.Forms.ImageList
            'i.Images.Add(Image.FromFile("C:\icons\1.ico"))
            'i.Images.Add(Image.FromFile("C:\icons\2.ico"))

            ' セパレータ、ボタンを挿入します。
            'Dim spr As New GrapeCity.ActiveReports.SectionReportModel.Toolbar.Separator
            'Dim spr2 As New GrapeCity.ActiveReports.SectionReportModel.Toolbar.Separator
            'Dim spr3 As New GrapeCity.ActiveReports.SectionReportModel.Toolbar.Separator
            'Dim spr4 As New GrapeCity.ActiveReports.SectionReportModel.Toolbar.Separator
            'Me.Viewer.Toolbar.Tools.Insert(4, cmdPDF)
            'Me.Viewer.Toolbar.Tools.Insert(5, spr)
            'Me.Viewer.Toolbar.Tools.Insert(6, cmdExcel)
            'Me.Viewer.Toolbar.Tools.Insert(7, spr2)
            'Me.Viewer.Toolbar.Tools.Insert(28, spr3)
            'Me.Viewer.Toolbar.Tools.Insert(29, cmdEnd)
            'Me.Viewer.Toolbar.Tools.Insert(30, spr4)
            Dim spr As New ToolStripSeparator
            Dim spr2 As New ToolStripSeparator
            Dim spr3 As New ToolStripSeparator
            Dim spr4 As New ToolStripSeparator
            Me.Viewer.Toolbar.ToolStrip.Items.Insert(4, spr2)
            Me.Viewer.Toolbar.ToolStrip.Items.Insert(5, cmdPDF)
            Me.Viewer.Toolbar.ToolStrip.Items.Insert(6, spr)
            Me.Viewer.Toolbar.ToolStrip.Items.Insert(7, cmdExcel)

            Me.Viewer.Toolbar.ToolStrip.Items.Insert(41, spr4)
            Me.Viewer.Toolbar.ToolStrip.Items.Insert(42, cmdEnd)


        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

#End Region

#Region "Viewer_ToolClick ToolBarクリックイベント"
    '------------------------------------------------------------------
    'プロシージャ名  :Viewer_ToolClick
    '説明            :ToolBarクリックイベント
    '------------------------------------------------------------------
    Private Sub cmdEnd_Click(sender As Object, e As EventArgs)

        Try
            '閉じるボタンが押された場合は終了
            Me.Close()

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

    End Sub

    Private Sub cmdPDF_Click(sender As Object, e As EventArgs)

        Dim strFileNm As String = pstrReportName

        Try
            'マウスカーソルを砂時計に変更
            Me.Cursor = Cursors.WaitCursor

            'ＰＤＦにエクスポートを行います。
            'エクスポート先パス取得(ダイアログボックス表示)
            If Not f_FileDialog("pdf", strFileNm) Then
                Exit Try
            End If
            Dim export As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
            export.Export(pRpt.Document, strFileNm)

            export.Dispose()

            ''処理終了メッセージ
            Call Show_MessageBox("I004", "")

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        'カーソルをデフォルトに戻す
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub cmdExcel_Click(sender As Object, e As EventArgs)

        Dim strFileNm As String = pstrReportName

        Try
            'マウスカーソルを砂時計に変更
            Me.Cursor = Cursors.WaitCursor

            'Ｅｘｃｅｌにエクスポートを行います。
            Dim export As New GrapeCity.ActiveReports.Export.Excel.Section.XlsExport
            'エクスポート先パス取得(ダイアログボックス表示)
            If Not f_FileDialog("xls", strFileNm) Then
                Exit Try
            End If
            export.Export(Viewer.Document, strFileNm)

            export.Dispose()

            ''処理終了メッセージ
            Call Show_MessageBox("I005", "")

        Catch ex As Exception
            '共通例外処理
            Show_MessageBox("", ex.Message)
        End Try

        'カーソルをデフォルトに戻す
        Me.Cursor = Cursors.Default

    End Sub
    'Private Sub Viewer_ToolClick(ByVal sender As Object, ByVal e As DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs) Handles Viewer.ToolClick
    '    Dim strFileNm As String = pstrReportName
    '    Dim strEX As String = String.Empty

    '    Try
    '        If e.Tool.Id = 999 Then
    '            '閉じるボタンが押された場合は終了
    '            Me.Close()
    '            Exit Try
    '        End If

    '        'マウスカーソルを砂時計に変更
    '        Me.Cursor = Cursors.WaitCursor

    '        Select Case e.Tool.Id
    '            Case 777        'PDF出力ボタン

    '                'ＰＤＦにエクスポートを行います。
    '                'エクスポート先パス取得(ダイアログボックス表示)
    '                If Not f_FileDialog("pdf", strFileNm) Then
    '                    Exit Try
    '                End If
    '                Dim export As New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
    '                export.Export(pRpt.Document, strFileNm)

    '                export.Dispose()

    '                ''処理終了メッセージ
    '                Call Show_MessageBox("I004", "")


    '            Case 888        'Excel出力ボタン

    '                'Ｅｘｃｅｌにエクスポートを行います。
    '                Dim export As New XlsExport
    '                'エクスポート先パス取得(ダイアログボックス表示)
    '                If Not f_FileDialog("xls", strFileNm) Then
    '                    Exit Try
    '                End If
    '                export.Export(Viewer.Document, strFileNm)

    '                export.Dispose()

    '                ''処理終了メッセージ
    '                Call Show_MessageBox("I005", "")

    '        End Select


    '    Catch ex As Exception
    '        '共通例外処理
    '        Show_MessageBox("", ex.Message)
    '    End Try

    '    'カーソルをデフォルトに戻す
    '    Me.Cursor = Cursors.Default

    'End Sub


#End Region
End Class