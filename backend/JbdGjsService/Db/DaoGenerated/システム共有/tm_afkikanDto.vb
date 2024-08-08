' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             医療機関マスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tm_afkikanDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afkikan"
        Public Property kikancd As String                       '医療機関コード（自治体独自）
        Public Property hokenkikancd As String                  '保険医療機関コード
        Public Property kanakikannm As String                   '医療機関名カナ
        Public Property kikannm As String                       '医療機関名
        Public Property yubin As String                         '郵便番号
        Public Property adrs As String                          '住所
        Public Property katagaki As String                     '方書
        Public Property tel As String                          '電話番号
        Public Property fax As String                          'FAX番号
        Public Property syozokuisikai As String                '所属医師会
        Public Property stopflg As Boolean                         '使用停止フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
