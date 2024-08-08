' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             汎用メインマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tm_afhanyo_mainDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afhanyo_main"
        Public Property hanyomaincd As String                   '汎用メインコード
        Public Property hanyosubcd As Integer                       '汎用サブコード
        Public Property hanyosubcdnm As String                  '汎用サブコード名称
        Public Property kananm As String                       'カナ名称
        Public Property shortnm As String                      '略称
        Public Property keta As Integer                            '桁数
        Public Property userryoikikaisicd As Integer               'ユーザ領域開始コード
        Public Property iflg As Boolean                            'INSERT可能フラグ
        Public Property uflg As Boolean                            'UPDATE可能フラグ
        Public Property dflg As Boolean                            'DELETE可能フラグ
        Public Property biko As String                         '備考
    End Class
End Namespace
