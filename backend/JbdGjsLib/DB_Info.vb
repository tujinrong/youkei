Imports System.Windows.Forms
Imports JbdGjsCommon

'******************************************
'** 機能  ：  GJS全体情報 確認画面
'** 作成日：  2020/09/07 JBD9020
'** 更新日：  
'******************************************
Public Class DB_Info

    Private Sub DB_Info_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Text = DateTime.Today.ToString("yyyy年MM月dd日現在")
        'データベース情報取得
        lblDBUser.Text = f_All_Get()

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
