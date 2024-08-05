' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ロジック共通仕様処理
'             レスポンスインターフェース
' 作成日　　: 2023.07.04
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service.Common
    ''' <summary>
    ''' 初期化処理(パスワードポリシー)
    ''' </summary>
    Public Class CmPwdInitResponse
        Inherits Db.DaResponseBase
        Public Property pwdflg As Boolean = False               'パスワードポリシー設定フラグ
        Public Property numflg As Boolean = False               '半角数字フラグ
        Public Property enflg As Boolean = False                '半角英字フラグ
        Public Property symbolflg As Boolean = False            '半角記号フラグ
        Public Property symbolstr As String = String.Empty   '使用可能記号
        Public Property maxlen As Integer = Nothing                '最大文字数
    End Class
End Namespace
