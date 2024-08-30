' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: DTO定義
'             ユーザーマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class tm_afuserDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afuser"
        Public Property userid As String                        'ユーザーID
        Public Property pword As String                         'パスワード
        Public Property usernm As String                        'ユーザー名
        Public Property syozokucd As String                    '所属グループコード
        Public Property errorkaisu As Integer                      'ログインエラー回数
        Public Property yukoymdf As String                      '有効年月日（開始）
        Public Property yukoymdt As String                      '有効年月日（終了）
        Public Property pwordhenkoymd As String                 'パスワード変更年月日
        Public Property kanrisyaflg As Boolean                     '管理者フラグ
        Public Property pnoeditflg As Boolean                      '個人番号操作権限付与フラグ
        Public Property alertviewflg As Boolean                    '警告参照フラグ
        Public Property authsetflg As Boolean                      '権限設定フラグ
        Public Property kanrisyakeisyoflg As Boolean               '管理者継承フラグ
        Public Property pnoeditkeisyoflg As Boolean                '個人番号操作権限付与継承フラグ
        Public Property alertviewkeisyoflg As Boolean              '警告参照継承フラグ
        Public Property authsisyokeisyoflg As Boolean              '部署（支所）別更新権限継承フラグ
        Public Property stopflg As Boolean                         '使用停止フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
