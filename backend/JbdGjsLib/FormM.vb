
'------------------------------------------------------------------
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
'------------------------------------------------------------------
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports JbdGjsCommon
Imports Oracle.ManagedDataAccess.Client

Public Class FormM
    Inherits System.Windows.Forms.Form
    Public Sub New()
        'Me.New(Nothing)
        ' この呼び出しは、コンポーネント デザイナで必要です。
        InitializeComponent()

        If myDBUSER = "" And myDBPASS = "" And myDBSID = "" Then
            m_ExecMode = C_MAIN     'メイン画面モード
            m_DevelopMode = True       '開発モード
        Else
            m_ExecMode = C_SUB      'サブ画面モード
        End If

        'ini情報の取得(既に取得されている場合は取得しない)
        Call Set_CommonInfo()

    End Sub

    Public Sub New(ByVal pGJSINI_Array As pGJSINI)
        Me.New(pGJSINI_Array, 1)

    End Sub

    Public Sub New(ByVal pGJSINI_Array As pGJSINI, ByVal pExecMode As Byte)
        MyBase.New()
        ' この呼び出しは、コンポーネント デザイナで必要です。
        InitializeComponent()

        m_ExecMode = pExecMode         'メイン画面モード

        '引数で引き渡されたGJS.INI構造体の内容をグローバル変数へセット
        Call Set_CommonInfo(pGJSINI_Array)

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        'Me.pnlMessage.Visible = False

    End Sub

    Public Sub New(ByVal pCnn As OracleConnection, ByVal pGJSINI_Array As pGJSINI, ByVal component As System.ComponentModel.IContainer)
        MyBase.New()
        ' この呼び出しは、コンポーネント デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。
        'Me.pnlMessage.Visible = False
    End Sub

    'Control は、コンポーネント一覧に後処理を実行するために、dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Protected Overloads Overrides Sub OnLoad(ByVal e As System.EventArgs)

        '-------------------------------------------------------
        ' まず継承元のLOADイベントが実行される
        '-------------------------------------------------------
        If Not Me.DesignMode Then
            '-------------------------------------------------------
            ' 次に継承先ＡＰのLOADイベント等を実行
            '-------------------------------------------------------
            MyBase.OnLoad(e)

        End If

    End Sub

    '-------------------------------------------------------
    ' 画面処理モードプロパティ設定
    '-------------------------------------------------------
    Private m_ExecMode As Byte = 9
    <Category("GJS"), Description("実行時に画面処理区分を取得・設定します。デザイン時には変更しないでください。")> _
    Public Property ExecMode() As Byte
        Get
            Return m_ExecMode
        End Get
        Set(ByVal Value As Byte)
            m_ExecMode = Value
        End Set
    End Property

    '-------------------------------------------------------
    ' 開発モードプロパティ設定
    '-------------------------------------------------------
    Private m_DevelopMode As Boolean = False
    <Category("GJS"), Description("単体実行時に開発区分を取得・設定します。デザイン時には変更しないでください。")> _
    Public Property DevelopMode() As Boolean
        Get
            Return m_DevelopMode
        End Get
        Set(ByVal Value As Boolean)
            m_DevelopMode = Value
        End Set
    End Property

    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Public WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblLine1 As System.Windows.Forms.Label
    Friend WithEvents tipBtn As System.Windows.Forms.ToolTip
    Public WithEvents pnlButton As System.Windows.Forms.Panel
    Public WithEvents lblLOGONUSER As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents lblSysdate As System.Windows.Forms.Label
    Public WithEvents cmdEnd As JBD.Gjs.Win.JButton

    'コントロール デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャはコンポーネント デザイナで必要です。
    ' コンポーネント デザイナを使って変更できます。
    ' コード エディタを使って変更しないでください。  
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.pnlTitle = New System.Windows.Forms.Panel()
        Me.lblSysdate = New System.Windows.Forms.Label()
        Me.lblLOGONUSER = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblLine1 = New System.Windows.Forms.Label()
        Me.tipBtn = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlButton = New System.Windows.Forms.Panel()
        Me.cmdEnd = New JBD.Gjs.Win.JButton(Me.components)
        Me.pnlTitle.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(794, 46)
        Me.MenuStrip1.TabIndex = 826
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.Transparent
        Me.pnlTitle.BackgroundImage = Global.JBD.Gjs.Win.My.Resources.Resources.Title1
        Me.pnlTitle.Controls.Add(Me.lblSysdate)
        Me.pnlTitle.Controls.Add(Me.lblLOGONUSER)
        Me.pnlTitle.Controls.Add(Me.Label1)
        Me.pnlTitle.Controls.Add(Me.lblTitle)
        Me.pnlTitle.Location = New System.Drawing.Point(1, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(793, 46)
        Me.pnlTitle.TabIndex = 827
        '
        'lblSysdate
        '
        Me.lblSysdate.BackColor = System.Drawing.Color.Transparent
        Me.lblSysdate.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSysdate.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblSysdate.Location = New System.Drawing.Point(471, 18)
        Me.lblSysdate.Name = "lblSysdate"
        Me.lblSysdate.Size = New System.Drawing.Size(154, 21)
        Me.lblSysdate.TabIndex = 32
        Me.lblSysdate.Tag = ""
        Me.lblSysdate.Text = "9999年99月99日 （Ｎ）"
        Me.lblSysdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLOGONUSER
        '
        Me.lblLOGONUSER.BackColor = System.Drawing.Color.Transparent
        Me.lblLOGONUSER.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblLOGONUSER.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblLOGONUSER.Location = New System.Drawing.Point(668, 18)
        Me.lblLOGONUSER.Name = "lblLOGONUSER"
        Me.lblLOGONUSER.Size = New System.Drawing.Size(119, 21)
        Me.lblLOGONUSER.TabIndex = 26
        Me.lblLOGONUSER.Text = "XXXXX"
        Me.lblLOGONUSER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(457, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(324, 14)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "ようこそ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitle
        '
        Me.lblTitle.AutoEllipsis = True
        Me.lblTitle.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTitle.Location = New System.Drawing.Point(10, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(448, 32)
        Me.lblTitle.TabIndex = 17
        Me.lblTitle.Tag = ""
        Me.lblTitle.Text = "ＸＸＸＸＸＸＸＸＸＸ"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLine1
        '
        Me.lblLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLine1.Location = New System.Drawing.Point(0, 514)
        Me.lblLine1.Name = "lblLine1"
        Me.lblLine1.Size = New System.Drawing.Size(794, 1)
        Me.lblLine1.TabIndex = 828
        '
        'pnlButton
        '
        Me.pnlButton.BackColor = System.Drawing.Color.Transparent
        Me.pnlButton.CausesValidation = False
        Me.pnlButton.Controls.Add(Me.cmdEnd)
        Me.pnlButton.Location = New System.Drawing.Point(0, 517)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(794, 55)
        Me.pnlButton.TabIndex = 868
        Me.pnlButton.TabStop = True
        '
        'cmdEnd
        '
        Me.cmdEnd.BackColor = System.Drawing.Color.CornflowerBlue
        Me.cmdEnd.CausesValidation = False
        Me.cmdEnd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdEnd.Font = New System.Drawing.Font("MS UI Gothic", 11.0!)
        Me.cmdEnd.Location = New System.Drawing.Point(681, 5)
        Me.cmdEnd.Name = "cmdEnd"
        Me.cmdEnd.Size = New System.Drawing.Size(92, 44)
        Me.cmdEnd.TabIndex = 0
        Me.cmdEnd.Text = "戻る"
        Me.cmdEnd.UseVisualStyleBackColor = True
        '
        'FormM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(794, 572)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.pnlButton)
        Me.Controls.Add(Me.lblLine1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlButton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private Sub FormM_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Not Me.DesignMode Then
            If (Me.ExecMode = C_MENU) OrElse (Me.ExecMode = C_MAIN And Me.DevelopMode) Then
                'データベースへの切断
                Cnn.Close()
            End If
        End If
    End Sub

    Private Sub FormM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Not Me.DesignMode Then
            ' フォームＩＤからＡＰＩＤを取得する
            pAPP = Mid(Me.GetType.Name, 4)
            '画面からＡＰＴＩＴＬＥを取得する
            pAPPTITLE = lblTitle.Text

            '操作ログ出力
            Call f_InfoLog_Put(1)
            Me.Dispose()
        End If
    End Sub

    Public Sub FormM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            'カーソルポインタを砂時計に設定する。
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

            '---------------------------------------------------
            '二重起動チェック
            '---------------------------------------------------
            Dim mt As New System.Threading.Mutex( _
                                    False, Process.GetCurrentProcess.ProcessName)
            'WaitHandle.WaitOne メソッド
            '現在の WaitHandle がシグナルを受入するまで現在のスレッドをブロックします
            If mt.WaitOne(0, False) = False Then
                'このプログラムは、すでに起動しています。
                MessageBox.Show("このプログラムは、すでに起動しています。", "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)
                mt.Close()
                Me.Close()
            End If

            'コンピュータ名取得
            pPCNAME = System.Net.Dns.GetHostName
            ' フォームＩＤからＡＰＩＤを取得する
            pAPP = Mid(Me.GetType.Name, 4)

            '-------------------------------------------------------
            ' 次に継承元以下ロジックが実行される
            '-------------------------------------------------------
            ' フォームＩＤからＡＰＩＤを取得する
            pAPP = Mid(Me.GetType.Name, 4)

            '2014/12/23 JBD368 ADD ↓↓↓
            ' 継承先のDLLからファイルバージョンを取得する
            Dim MyPath As String = Application.StartupPath
            If MyPath.EndsWith("\") = False Then
                MyPath &= "\"
            End If
            Dim ThisAssembly As Reflection.Assembly = MyBase.GetType.Assembly
            Dim MyName As String = ThisAssembly.GetName.Name
            Dim prefix As String = String.Empty
            '2023/09/21 JBD9020 exe名を変更したい UPD START
            'If MyName = "MENU" Then
            '    prefix = ".exe"
            'Else
            '    prefix = ".dll"
            'End If
            'Try
            '    Dim verInfo As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(
            '                        MyPath & MyName & prefix)
            Dim MyPathFile As String = Application.ExecutablePath
            Dim filenm As String
            If MyName.StartsWith("MENU") Then
                filenm = MyPathFile
            Else
                prefix = ".dll"
                filenm = MyPath & MyName & prefix
            End If
            Try
                Dim verInfo As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(filenm)
                '2023/09/21 JBD9020 exe名を変更したい UPD END
                pFILEVERSION = verInfo.FileVersion
            Catch ex As Exception
                '製造時、APPを単独実行した場合を考慮
                pFILEVERSION = ""
            End Try
            '2014/12/23 JBD368 ADD ↑↑↑

            '---------------------------------------------------
            '初期処理
            '---------------------------------------------------
            If FormInit() = True Then
                '成功
            Else
                '失敗
                'フォームクローズ
                Me.Close()
            End If

            '2014/05/09　追加　背景色セット
            If Not DesignMode Then
                Me.BackColor = myBACKCOLOR
            End If

            '-------------------------------------------------------
            ' タイトルエリアへ内容セット
            '-------------------------------------------------------
            '2014/12/23 JBD368 UPD ↓↓↓
            'Me.Text = "(" & pAPP & ")" & pAPPTITLE
            Me.Text = "(" & pAPP & ")" & pAPPTITLE & "  (Ver." & pFILEVERSION & ")"
            '2014/12/23 JBD368 UPD ↑↑↑

            ' タイトルエリアの機能名を表示する
            lblTitle.Text = pAPPTITLE

            ' タイトルエリアのシステム日付および曜日を表示する
            lblSysdate.Text = f_SyoriYmdw_Get()

            ' タイトルエリアのログインユーザ名を表示する
            '2015/01/13 JBD368 UPD ↓↓↓
            'lblLOGONUSER.Text = pLOGINUSEKCRNM & "さん"
            lblLOGONUSER.Text = pLOGINUSERNM
            '2015/01/13 JBD368 UPD ↑↑↑

            '2015/01/13 JBD368 ADD ↓↓↓
            'タイトルエリアのメッセージを表示
            Label1.Text = GjsTool.GetGjsMessage
            '2015/01/13 JBD368 ADD ↑↑↑


            'カーソルポインタをデフォルトに戻す。
            System.Windows.Forms.Cursor.Current = Cursors.Default

        Catch ex As Exception
            ''共通例外処理
            'Show_MessageBox("", ex.Message)

            'フォームクローズ
            Me.Close()
        End Try
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :Form_KeyPress
    '説明            :Enterキー押下時タブ移動処理
    '------------------------------------------------------------------
    Public Sub Form_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Try

            'SendKeys.Send メソッド を使った方法(Shift + Enter で逆方向に移動）
            'Enterキーが押された事を取得
            If e.KeyChar = Chr(Keys.Enter) Then
                e.Handled = True    'KeyPress イベントをキャンセルしBeep音を消音に
                SendKeys.Send(Constants.vbTab)
            Else
            End If

        Catch ex As Exception
            '共通例外処理
            'Show_MessageBox("", ex.Message)

        End Try

    End Sub

    Private Sub [New](ByVal p1 As Object)
        Throw New NotImplementedException
    End Sub

    '------------------------------------------------------------------
    'プロシージャ名  :lblTitle_DoubleClick
    '説明            :タイトル_ダブルクリックイベント
    '2020/08/27 JBD9020 新規作成
    '-----------------------------------------------------------------
    Private Sub lblTitle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTitle.DoubleClick

        Dim db_info As New DB_Info
        db_info.ShowDialog()

    End Sub
End Class