' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             トークンテーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tt_aftokenDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_aftoken"
        Public Property tokenseq As Long                        'トークンシーケンス
        Public Property userid As String                        'ユーザーID
        Public Property regsisyo As String                     '登録支所
        Public Property sisyocd As String                      '部署（支所）コード
        Public Property gamenauth As String                    '画面権限
        Public Property rolekbn As Enumロール区分               'ロール区分
        Public Property syozokucd As String                    '所属グループコード
        Public Property kanrisyaflg As Boolean                     '管理者フラグ
        Public Property pnoeditflg As Boolean                      '個人番号操作権限付与フラグ
        Public Property alertviewflg As Boolean                    '警告参照フラグ
        Public Property accessdttm As Date                  'アクセス日時
    End Class
End Namespace
