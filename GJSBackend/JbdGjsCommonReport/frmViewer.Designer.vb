<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmViewer
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    Dim MyOption As Integer
    Public Sub New(ByVal rpt As GrapeCity.ActiveReports.SectionReport, ByVal rptName As String)
        MyBase.New()
        InitializeComponent()

        pRpt = rpt
        pstrReportName = rptName
    End Sub
    Public Sub New(ByVal opt As Integer)
        MyBase.New()
        InitializeComponent()

        MyOption = opt
    End Sub
    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Viewer = New GrapeCity.ActiveReports.Viewer.Win.Viewer()
        Me.PdfExport = New GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport()
        Me.XlsExport = New GrapeCity.ActiveReports.Export.Excel.Section.XlsExport()
        Me.SuspendLayout()
        '
        'Viewer
        '
        Me.Viewer.BackColor = System.Drawing.SystemColors.Control
        Me.Viewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Viewer.Document = New GrapeCity.ActiveReports.Document.SectionDocument("ARNet Document")
        Me.Viewer.Location = New System.Drawing.Point(0, 0)
        Me.Viewer.Name = "Viewer"
        Me.Viewer.ReportViewer.CurrentPage = 0
        Me.Viewer.ReportViewer.MultiplePageCols = 3
        Me.Viewer.ReportViewer.MultiplePageRows = 2
        Me.Viewer.ReportViewer.ViewType = GrapeCity.Viewer.Common.Model.ViewType.SinglePage
        Me.Viewer.Size = New System.Drawing.Size(1002, 636)
        Me.Viewer.TabIndex = 0
        Me.Viewer.TableOfContents.Text = "見出し一覧"
        Me.Viewer.TableOfContents.Width = 200
        Me.Viewer.Toolbar.Font = New System.Drawing.Font("メイリオ", 9.0!)
        '
        'XlsExport
        '
        Me.XlsExport.Tweak = 0
        '
        'frmViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1002, 636)
        Me.Controls.Add(Me.Viewer)
        Me.Name = "frmViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "プレビュー"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PdfExport As GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport
    Friend WithEvents XlsExport As GrapeCity.ActiveReports.Export.Excel.Section.XlsExport
    Public WithEvents Viewer As GrapeCity.ActiveReports.Viewer.Win.Viewer
End Class
