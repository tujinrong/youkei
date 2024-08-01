' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ログイン
'             レスポンスインターフェース
' 作成日　　: 
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Imports BusinessService.Jbd.Gjs.Service.Common

Namespace Jbd.Gjs.Service.GJ0000
    ''' <summary>
    ''' ログイン処理(成功)
    ''' </summary>
    Public Class LoginResponse
        Inherits Db.DaResponseBase
        Public Property token As String               'トークン(ベースロジック)
        'Public Property userinfo As UserInfoVM        'ユーザー情報(共通)
        'Public Property sisyolist As List(Of CmSisyoVM)  '支所リスト(登録支所選択用)
        'Public Property pwdmsgflg As Boolean             '警告フラグ true:警告メッセージが出る(通知範囲以内の場合)
    End Class

    Public Class UserInfoResponse
        Inherits Db.DaResponseBase
         Public Property userid As String      'ユーザID
        Public Property usernm As String      'ユーザー名
        Public Property Roles As List(Of String)
    End Class
End Namespace
