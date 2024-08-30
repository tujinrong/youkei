' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: ログイン
'            ビューモデル定義
' 作成日　　: 2024.07.21
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ0000

    ''' <summary>
    ''' ユーザー共通
    ''' </summary>
    Public Class UserInfoVM

        ''' <summary>
        ''' ユーザID
        ''' </summary>
        Public Property USER_ID As String = String.Empty

        ''' <summary>
        ''' ユーザー名
        ''' </summary>
        Public Property USER_NAME As String = String.Empty

        ''' <summary>
        ''' 权限
        ''' </summary>
        Public Property ROLES As List(Of String) = New List(Of String)

    End Class
End Namespace
