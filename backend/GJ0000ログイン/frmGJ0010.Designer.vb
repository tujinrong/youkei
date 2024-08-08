Imports JbdGjsCommon
Imports JbdGjsControl
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGJ0010
    Inherits JBD.Gjs.Win.FormL

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub
    Public Sub New(ByVal pGJSINI_Array As pGJSINI)
        MyBase.New(pGJSINI_Array)
        InitializeComponent()
    End Sub

    'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LinkLabel1 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel2 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.GcShortcut1 = New GrapeCity.Win.Editors.GcShortcut(Me.components)
        Me.LinkLabel3 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel4 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel5 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel6 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel7 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel8 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel9 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel10 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel11 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel12 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel13 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel14 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel15 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.LinkLabel4_8 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel4_7 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel4_6 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel4_5 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel4_4 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel4_3 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel4_2 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel4_1 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.LinkLabel3_8 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel3_7 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel3_6 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel3_5 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel3_4 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel3_3 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel3_2 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel3_1 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LinkLabel2_8 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel2_7 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel2_6 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel2_5 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel2_4 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel2_3 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel2_2 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel2_1 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LinkLabel1_8 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel1_7 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel1_6 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel1_5 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel1_4 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel1_3 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel1_2 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.LinkLabel1_1 = New JBD.Gjs.Win.LinkLabel(Me.components)
        Me.pnlButton.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlButton
        '
        Me.pnlButton.TabIndex = 2
        '
        'cmdEnd
        '
        Me.cmdEnd.Text = "終了"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(16, 20)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "LinkLabel1"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel2.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2.Location = New System.Drawing.Point(16, 53)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel2.TabIndex = 1
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "LinkLabel2"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3.Location = New System.Drawing.Point(16, 86)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel3.TabIndex = 2
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "LinkLabel3"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel4.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel4.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4.Location = New System.Drawing.Point(16, 119)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel4.TabIndex = 3
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "LinkLabel4"
        '
        'LinkLabel5
        '
        Me.LinkLabel5.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel5.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel5.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel5.Location = New System.Drawing.Point(16, 152)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel5.TabIndex = 4
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "LinkLabel5"
        '
        'LinkLabel6
        '
        Me.LinkLabel6.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel6.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel6.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel6.Location = New System.Drawing.Point(16, 185)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel6.TabIndex = 5
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "LinkLabel6"
        '
        'LinkLabel7
        '
        Me.LinkLabel7.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel7.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel7.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel7.Location = New System.Drawing.Point(16, 218)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel7.TabIndex = 6
        Me.LinkLabel7.TabStop = True
        Me.LinkLabel7.Text = "LinkLabel7"
        '
        'LinkLabel8
        '
        Me.LinkLabel8.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel8.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel8.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel8.Location = New System.Drawing.Point(16, 251)
        Me.LinkLabel8.Name = "LinkLabel8"
        Me.LinkLabel8.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel8.TabIndex = 7
        Me.LinkLabel8.TabStop = True
        Me.LinkLabel8.Text = "LinkLabel8"
        '
        'LinkLabel9
        '
        Me.LinkLabel9.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel9.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel9.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel9.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel9.Location = New System.Drawing.Point(16, 284)
        Me.LinkLabel9.Name = "LinkLabel9"
        Me.LinkLabel9.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel9.TabIndex = 8
        Me.LinkLabel9.TabStop = True
        Me.LinkLabel9.Text = "LinkLabel9"
        '
        'LinkLabel10
        '
        Me.LinkLabel10.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel10.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel10.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel10.Location = New System.Drawing.Point(16, 317)
        Me.LinkLabel10.Name = "LinkLabel10"
        Me.LinkLabel10.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel10.TabIndex = 9
        Me.LinkLabel10.TabStop = True
        Me.LinkLabel10.Text = "LinkLabel10"
        '
        'LinkLabel11
        '
        Me.LinkLabel11.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel11.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel11.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel11.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel11.Location = New System.Drawing.Point(16, 350)
        Me.LinkLabel11.Name = "LinkLabel11"
        Me.LinkLabel11.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel11.TabIndex = 10
        Me.LinkLabel11.TabStop = True
        Me.LinkLabel11.Text = "LinkLabel11"
        '
        'LinkLabel12
        '
        Me.LinkLabel12.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel12.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel12.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel12.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel12.Location = New System.Drawing.Point(16, 383)
        Me.LinkLabel12.Name = "LinkLabel12"
        Me.LinkLabel12.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel12.TabIndex = 11
        Me.LinkLabel12.TabStop = True
        Me.LinkLabel12.Text = "LinkLabel12"
        '
        'LinkLabel13
        '
        Me.LinkLabel13.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel13.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel13.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel13.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel13.Location = New System.Drawing.Point(16, 416)
        Me.LinkLabel13.Name = "LinkLabel13"
        Me.LinkLabel13.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel13.TabIndex = 12
        Me.LinkLabel13.TabStop = True
        Me.LinkLabel13.Text = "LinkLabel13"
        '
        'LinkLabel14
        '
        Me.LinkLabel14.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel14.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel14.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel14.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel14.Location = New System.Drawing.Point(16, 449)
        Me.LinkLabel14.Name = "LinkLabel14"
        Me.LinkLabel14.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel14.TabIndex = 13
        Me.LinkLabel14.TabStop = True
        Me.LinkLabel14.Text = "LinkLabel14"
        '
        'LinkLabel15
        '
        Me.LinkLabel15.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel15.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel15.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel15.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel15.Location = New System.Drawing.Point(16, 482)
        Me.LinkLabel15.Name = "LinkLabel15"
        Me.LinkLabel15.Size = New System.Drawing.Size(197, 15)
        Me.LinkLabel15.TabIndex = 14
        Me.LinkLabel15.TabStop = True
        Me.LinkLabel15.Text = "LinkLabel15"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.LinkLabel3)
        Me.Panel1.Controls.Add(Me.LinkLabel4)
        Me.Panel1.Controls.Add(Me.LinkLabel5)
        Me.Panel1.Controls.Add(Me.LinkLabel6)
        Me.Panel1.Controls.Add(Me.LinkLabel7)
        Me.Panel1.Controls.Add(Me.LinkLabel8)
        Me.Panel1.Controls.Add(Me.LinkLabel9)
        Me.Panel1.Controls.Add(Me.LinkLabel10)
        Me.Panel1.Controls.Add(Me.LinkLabel11)
        Me.Panel1.Controls.Add(Me.LinkLabel12)
        Me.Panel1.Controls.Add(Me.LinkLabel13)
        Me.Panel1.Controls.Add(Me.LinkLabel14)
        Me.Panel1.Controls.Add(Me.LinkLabel15)
        Me.Panel1.Location = New System.Drawing.Point(12, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(229, 561)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Location = New System.Drawing.Point(247, 52)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(747, 579)
        Me.Panel2.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.Controls.Add(Me.LinkLabel4_8)
        Me.Panel6.Controls.Add(Me.LinkLabel4_7)
        Me.Panel6.Controls.Add(Me.LinkLabel4_6)
        Me.Panel6.Controls.Add(Me.LinkLabel4_5)
        Me.Panel6.Controls.Add(Me.LinkLabel4_4)
        Me.Panel6.Controls.Add(Me.LinkLabel4_3)
        Me.Panel6.Controls.Add(Me.LinkLabel4_2)
        Me.Panel6.Controls.Add(Me.LinkLabel4_1)
        Me.Panel6.Location = New System.Drawing.Point(376, 284)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(340, 268)
        Me.Panel6.TabIndex = 4
        Me.Panel6.Visible = False
        '
        'LinkLabel4_8
        '
        Me.LinkLabel4_8.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel4_8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel4_8.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_8.Location = New System.Drawing.Point(15, 238)
        Me.LinkLabel4_8.Name = "LinkLabel4_8"
        Me.LinkLabel4_8.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel4_8.TabIndex = 7
        Me.LinkLabel4_8.TabStop = True
        Me.LinkLabel4_8.Text = "LinkLabel4_8"
        Me.LinkLabel4_8.Visible = False
        '
        'LinkLabel4_7
        '
        Me.LinkLabel4_7.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel4_7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel4_7.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_7.Location = New System.Drawing.Point(15, 213)
        Me.LinkLabel4_7.Name = "LinkLabel4_7"
        Me.LinkLabel4_7.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel4_7.TabIndex = 6
        Me.LinkLabel4_7.TabStop = True
        Me.LinkLabel4_7.Text = "LinkLabel4_7"
        Me.LinkLabel4_7.Visible = False
        '
        'LinkLabel4_6
        '
        Me.LinkLabel4_6.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel4_6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel4_6.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_6.Location = New System.Drawing.Point(15, 181)
        Me.LinkLabel4_6.Name = "LinkLabel4_6"
        Me.LinkLabel4_6.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel4_6.TabIndex = 5
        Me.LinkLabel4_6.TabStop = True
        Me.LinkLabel4_6.Text = "LinkLabel4_6"
        Me.LinkLabel4_6.Visible = False
        '
        'LinkLabel4_5
        '
        Me.LinkLabel4_5.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel4_5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel4_5.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_5.Location = New System.Drawing.Point(15, 149)
        Me.LinkLabel4_5.Name = "LinkLabel4_5"
        Me.LinkLabel4_5.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel4_5.TabIndex = 4
        Me.LinkLabel4_5.TabStop = True
        Me.LinkLabel4_5.Text = "LinkLabel4_5"
        Me.LinkLabel4_5.Visible = False
        '
        'LinkLabel4_4
        '
        Me.LinkLabel4_4.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel4_4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel4_4.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_4.Location = New System.Drawing.Point(15, 117)
        Me.LinkLabel4_4.Name = "LinkLabel4_4"
        Me.LinkLabel4_4.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel4_4.TabIndex = 3
        Me.LinkLabel4_4.TabStop = True
        Me.LinkLabel4_4.Text = "LinkLabel4_4"
        Me.LinkLabel4_4.Visible = False
        '
        'LinkLabel4_3
        '
        Me.LinkLabel4_3.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel4_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel4_3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_3.Location = New System.Drawing.Point(15, 85)
        Me.LinkLabel4_3.Name = "LinkLabel4_3"
        Me.LinkLabel4_3.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel4_3.TabIndex = 2
        Me.LinkLabel4_3.TabStop = True
        Me.LinkLabel4_3.Text = "LinkLabel4_3"
        Me.LinkLabel4_3.Visible = False
        '
        'LinkLabel4_2
        '
        Me.LinkLabel4_2.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel4_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel4_2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_2.Location = New System.Drawing.Point(15, 53)
        Me.LinkLabel4_2.Name = "LinkLabel4_2"
        Me.LinkLabel4_2.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel4_2.TabIndex = 1
        Me.LinkLabel4_2.TabStop = True
        Me.LinkLabel4_2.Text = "LinkLabel4_2"
        Me.LinkLabel4_2.Visible = False
        '
        'LinkLabel4_1
        '
        Me.LinkLabel4_1.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel4_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel4_1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel4_1.Location = New System.Drawing.Point(15, 21)
        Me.LinkLabel4_1.Name = "LinkLabel4_1"
        Me.LinkLabel4_1.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel4_1.TabIndex = 0
        Me.LinkLabel4_1.TabStop = True
        Me.LinkLabel4_1.Text = "LinkLabel4_1"
        Me.LinkLabel4_1.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.LinkLabel3_8)
        Me.Panel5.Controls.Add(Me.LinkLabel3_7)
        Me.Panel5.Controls.Add(Me.LinkLabel3_6)
        Me.Panel5.Controls.Add(Me.LinkLabel3_5)
        Me.Panel5.Controls.Add(Me.LinkLabel3_4)
        Me.Panel5.Controls.Add(Me.LinkLabel3_3)
        Me.Panel5.Controls.Add(Me.LinkLabel3_2)
        Me.Panel5.Controls.Add(Me.LinkLabel3_1)
        Me.Panel5.Location = New System.Drawing.Point(389, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(340, 268)
        Me.Panel5.TabIndex = 2
        Me.Panel5.Visible = False
        '
        'LinkLabel3_8
        '
        Me.LinkLabel3_8.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel3_8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel3_8.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_8.Location = New System.Drawing.Point(15, 236)
        Me.LinkLabel3_8.Name = "LinkLabel3_8"
        Me.LinkLabel3_8.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel3_8.TabIndex = 7
        Me.LinkLabel3_8.TabStop = True
        Me.LinkLabel3_8.Text = "LinkLabel3_8"
        Me.LinkLabel3_8.Visible = False
        '
        'LinkLabel3_7
        '
        Me.LinkLabel3_7.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel3_7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel3_7.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_7.Location = New System.Drawing.Point(15, 212)
        Me.LinkLabel3_7.Name = "LinkLabel3_7"
        Me.LinkLabel3_7.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel3_7.TabIndex = 6
        Me.LinkLabel3_7.TabStop = True
        Me.LinkLabel3_7.Text = "LinkLabel3_7"
        Me.LinkLabel3_7.Visible = False
        '
        'LinkLabel3_6
        '
        Me.LinkLabel3_6.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel3_6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel3_6.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_6.Location = New System.Drawing.Point(15, 180)
        Me.LinkLabel3_6.Name = "LinkLabel3_6"
        Me.LinkLabel3_6.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel3_6.TabIndex = 5
        Me.LinkLabel3_6.TabStop = True
        Me.LinkLabel3_6.Text = "LinkLabel3_6"
        Me.LinkLabel3_6.Visible = False
        '
        'LinkLabel3_5
        '
        Me.LinkLabel3_5.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel3_5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel3_5.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_5.Location = New System.Drawing.Point(15, 148)
        Me.LinkLabel3_5.Name = "LinkLabel3_5"
        Me.LinkLabel3_5.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel3_5.TabIndex = 4
        Me.LinkLabel3_5.TabStop = True
        Me.LinkLabel3_5.Text = "LinkLabel3_5"
        Me.LinkLabel3_5.Visible = False
        '
        'LinkLabel3_4
        '
        Me.LinkLabel3_4.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel3_4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel3_4.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_4.Location = New System.Drawing.Point(15, 116)
        Me.LinkLabel3_4.Name = "LinkLabel3_4"
        Me.LinkLabel3_4.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel3_4.TabIndex = 3
        Me.LinkLabel3_4.TabStop = True
        Me.LinkLabel3_4.Text = "LinkLabel3_4"
        Me.LinkLabel3_4.Visible = False
        '
        'LinkLabel3_3
        '
        Me.LinkLabel3_3.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel3_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel3_3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_3.Location = New System.Drawing.Point(15, 84)
        Me.LinkLabel3_3.Name = "LinkLabel3_3"
        Me.LinkLabel3_3.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel3_3.TabIndex = 2
        Me.LinkLabel3_3.TabStop = True
        Me.LinkLabel3_3.Text = "LinkLabel3_3"
        Me.LinkLabel3_3.Visible = False
        '
        'LinkLabel3_2
        '
        Me.LinkLabel3_2.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel3_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel3_2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_2.Location = New System.Drawing.Point(15, 52)
        Me.LinkLabel3_2.Name = "LinkLabel3_2"
        Me.LinkLabel3_2.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel3_2.TabIndex = 1
        Me.LinkLabel3_2.TabStop = True
        Me.LinkLabel3_2.Text = "LinkLabel3_2"
        Me.LinkLabel3_2.Visible = False
        '
        'LinkLabel3_1
        '
        Me.LinkLabel3_1.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel3_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel3_1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel3_1.Location = New System.Drawing.Point(15, 20)
        Me.LinkLabel3_1.Name = "LinkLabel3_1"
        Me.LinkLabel3_1.Size = New System.Drawing.Size(310, 15)
        Me.LinkLabel3_1.TabIndex = 0
        Me.LinkLabel3_1.TabStop = True
        Me.LinkLabel3_1.Text = "LinkLabel3_1"
        Me.LinkLabel3_1.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel4.Controls.Add(Me.LinkLabel2_8)
        Me.Panel4.Controls.Add(Me.LinkLabel2_7)
        Me.Panel4.Controls.Add(Me.LinkLabel2_6)
        Me.Panel4.Controls.Add(Me.LinkLabel2_5)
        Me.Panel4.Controls.Add(Me.LinkLabel2_4)
        Me.Panel4.Controls.Add(Me.LinkLabel2_3)
        Me.Panel4.Controls.Add(Me.LinkLabel2_2)
        Me.Panel4.Controls.Add(Me.LinkLabel2_1)
        Me.Panel4.Location = New System.Drawing.Point(9, 293)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(721, 275)
        Me.Panel4.TabIndex = 3
        '
        'LinkLabel2_8
        '
        Me.LinkLabel2_8.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel2_8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel2_8.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_8.Location = New System.Drawing.Point(16, 244)
        Me.LinkLabel2_8.Name = "LinkLabel2_8"
        Me.LinkLabel2_8.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel2_8.TabIndex = 8
        Me.LinkLabel2_8.TabStop = True
        Me.LinkLabel2_8.Text = "LinkLabel2_8"
        '
        'LinkLabel2_7
        '
        Me.LinkLabel2_7.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel2_7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel2_7.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_7.Location = New System.Drawing.Point(16, 212)
        Me.LinkLabel2_7.Name = "LinkLabel2_7"
        Me.LinkLabel2_7.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel2_7.TabIndex = 6
        Me.LinkLabel2_7.TabStop = True
        Me.LinkLabel2_7.Text = "LinkLabel2_7"
        '
        'LinkLabel2_6
        '
        Me.LinkLabel2_6.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel2_6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel2_6.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_6.Location = New System.Drawing.Point(16, 180)
        Me.LinkLabel2_6.Name = "LinkLabel2_6"
        Me.LinkLabel2_6.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel2_6.TabIndex = 5
        Me.LinkLabel2_6.TabStop = True
        Me.LinkLabel2_6.Text = "LinkLabel2_6"
        '
        'LinkLabel2_5
        '
        Me.LinkLabel2_5.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel2_5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel2_5.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_5.Location = New System.Drawing.Point(16, 148)
        Me.LinkLabel2_5.Name = "LinkLabel2_5"
        Me.LinkLabel2_5.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel2_5.TabIndex = 4
        Me.LinkLabel2_5.TabStop = True
        Me.LinkLabel2_5.Text = "LinkLabel2_5"
        '
        'LinkLabel2_4
        '
        Me.LinkLabel2_4.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel2_4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel2_4.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_4.Location = New System.Drawing.Point(16, 116)
        Me.LinkLabel2_4.Name = "LinkLabel2_4"
        Me.LinkLabel2_4.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel2_4.TabIndex = 3
        Me.LinkLabel2_4.TabStop = True
        Me.LinkLabel2_4.Text = "LinkLabel2_4"
        '
        'LinkLabel2_3
        '
        Me.LinkLabel2_3.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel2_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel2_3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_3.Location = New System.Drawing.Point(16, 84)
        Me.LinkLabel2_3.Name = "LinkLabel2_3"
        Me.LinkLabel2_3.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel2_3.TabIndex = 2
        Me.LinkLabel2_3.TabStop = True
        Me.LinkLabel2_3.Text = "LinkLabel2_3"
        '
        'LinkLabel2_2
        '
        Me.LinkLabel2_2.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel2_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel2_2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_2.Location = New System.Drawing.Point(16, 52)
        Me.LinkLabel2_2.Name = "LinkLabel2_2"
        Me.LinkLabel2_2.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel2_2.TabIndex = 1
        Me.LinkLabel2_2.TabStop = True
        Me.LinkLabel2_2.Text = "LinkLabel2_2"
        '
        'LinkLabel2_1
        '
        Me.LinkLabel2_1.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel2_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.0!)
        Me.LinkLabel2_1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel2_1.Location = New System.Drawing.Point(16, 20)
        Me.LinkLabel2_1.Name = "LinkLabel2_1"
        Me.LinkLabel2_1.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel2_1.TabIndex = 0
        Me.LinkLabel2_1.TabStop = True
        Me.LinkLabel2_1.Text = "LinkLabel2_1"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.Controls.Add(Me.LinkLabel1_8)
        Me.Panel3.Controls.Add(Me.LinkLabel1_7)
        Me.Panel3.Controls.Add(Me.LinkLabel1_6)
        Me.Panel3.Controls.Add(Me.LinkLabel1_5)
        Me.Panel3.Controls.Add(Me.LinkLabel1_4)
        Me.Panel3.Controls.Add(Me.LinkLabel1_3)
        Me.Panel3.Controls.Add(Me.LinkLabel1_2)
        Me.Panel3.Controls.Add(Me.LinkLabel1_1)
        Me.Panel3.Location = New System.Drawing.Point(9, 7)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(721, 275)
        Me.Panel3.TabIndex = 1
        '
        'LinkLabel1_8
        '
        Me.LinkLabel1_8.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_8.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1_8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel1_8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel1_8.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_8.Location = New System.Drawing.Point(16, 244)
        Me.LinkLabel1_8.Name = "LinkLabel1_8"
        Me.LinkLabel1_8.Size = New System.Drawing.Size(701, 20)
        Me.LinkLabel1_8.TabIndex = 8
        Me.LinkLabel1_8.TabStop = True
        Me.LinkLabel1_8.Text = "LinkLabel1_8"
        '
        'LinkLabel1_7
        '
        Me.LinkLabel1_7.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_7.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1_7.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel1_7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel1_7.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_7.Location = New System.Drawing.Point(16, 212)
        Me.LinkLabel1_7.Name = "LinkLabel1_7"
        Me.LinkLabel1_7.Size = New System.Drawing.Size(701, 20)
        Me.LinkLabel1_7.TabIndex = 6
        Me.LinkLabel1_7.TabStop = True
        Me.LinkLabel1_7.Text = "LinkLabel1_7"
        '
        'LinkLabel1_6
        '
        Me.LinkLabel1_6.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_6.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1_6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel1_6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel1_6.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_6.Location = New System.Drawing.Point(16, 180)
        Me.LinkLabel1_6.Name = "LinkLabel1_6"
        Me.LinkLabel1_6.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel1_6.TabIndex = 5
        Me.LinkLabel1_6.TabStop = True
        Me.LinkLabel1_6.Text = "LinkLabel1_6"
        '
        'LinkLabel1_5
        '
        Me.LinkLabel1_5.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_5.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1_5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel1_5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel1_5.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_5.Location = New System.Drawing.Point(16, 148)
        Me.LinkLabel1_5.Name = "LinkLabel1_5"
        Me.LinkLabel1_5.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel1_5.TabIndex = 4
        Me.LinkLabel1_5.TabStop = True
        Me.LinkLabel1_5.Text = "LinkLabel1_5"
        '
        'LinkLabel1_4
        '
        Me.LinkLabel1_4.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_4.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1_4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel1_4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel1_4.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_4.Location = New System.Drawing.Point(16, 116)
        Me.LinkLabel1_4.Name = "LinkLabel1_4"
        Me.LinkLabel1_4.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel1_4.TabIndex = 3
        Me.LinkLabel1_4.TabStop = True
        Me.LinkLabel1_4.Text = "LinkLabel1_4"
        '
        'LinkLabel1_3
        '
        Me.LinkLabel1_3.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_3.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1_3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel1_3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel1_3.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_3.Location = New System.Drawing.Point(16, 84)
        Me.LinkLabel1_3.Name = "LinkLabel1_3"
        Me.LinkLabel1_3.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel1_3.TabIndex = 2
        Me.LinkLabel1_3.TabStop = True
        Me.LinkLabel1_3.Text = "LinkLabel1_3"
        '
        'LinkLabel1_2
        '
        Me.LinkLabel1_2.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_2.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1_2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel1_2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel1_2.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_2.Location = New System.Drawing.Point(16, 52)
        Me.LinkLabel1_2.Name = "LinkLabel1_2"
        Me.LinkLabel1_2.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel1_2.TabIndex = 1
        Me.LinkLabel1_2.TabStop = True
        Me.LinkLabel1_2.Text = "LinkLabel1_2"
        '
        'LinkLabel1_1
        '
        Me.LinkLabel1_1.ActiveLinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1_1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LinkLabel1_1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LinkLabel1_1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1_1.Location = New System.Drawing.Point(16, 20)
        Me.LinkLabel1_1.Name = "LinkLabel1_1"
        Me.LinkLabel1_1.Size = New System.Drawing.Size(701, 15)
        Me.LinkLabel1_1.TabIndex = 0
        Me.LinkLabel1_1.TabStop = True
        Me.LinkLabel1_1.Text = "LinkLabel1_1"
        '
        'frmGJ0010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(994, 692)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmGJ0010"
        Me.Controls.SetChildIndex(Me.pnlButton, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.pnlButton.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LinkLabel1 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel2 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents GcShortcut1 As GrapeCity.Win.Editors.GcShortcut
    Friend WithEvents LinkLabel3 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel4 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel5 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel6 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel7 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel8 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel9 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel10 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel11 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel12 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel13 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel14 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel15 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel1_7 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel1_6 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel1_5 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel1_4 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel1_3 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel1_2 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel1_1 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel2_7 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel2_6 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel2_5 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel2_4 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel2_3 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel2_2 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel2_1 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel3_7 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel3_6 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel3_5 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel3_4 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel3_3 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel3_2 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel3_1 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel4_7 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel4_6 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel4_5 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel4_4 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel4_3 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel4_2 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel4_1 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel1_8 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel2_8 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel4_8 As JBD.Gjs.Win.LinkLabel
    Friend WithEvents LinkLabel3_8 As JBD.Gjs.Win.LinkLabel

End Class
