' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ログイン
'             ビューモデル定義
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service.GJ0000
    ''' <summary>
    ''' ユーザー共通
    ''' </summary>
    Public Class UserInfoVM
        Public Property USER_ID As String      'ユーザID
        Public Property USER_NM As String      'ユーザー名
        'Public Property syozokunm As String   '所属名
        'Public Property kanrisyaflg As Boolean   '管理者フラグ
        Public Property ROLES As List(Of String)

    End Class
End Namespace
