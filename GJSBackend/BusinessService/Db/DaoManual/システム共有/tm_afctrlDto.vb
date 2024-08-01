' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             コントロールマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tm_afctrlDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afctrl"
        Public Property ctrlmaincd As String                    'コントロールメインコード
        Public Property ctrlsubcd As Integer                        'コントロールサブコード
        Public Property ctrlcd As String                        'コントロールコード
        Public Property itemnm As String                        '項目名称
        Public Property datatype As EnumDataType                'データ型
        Public Property rangeflg As Boolean                        '範囲フラグ
        Public Property value1 As String                       '値１
        Public Property value2 As String                       '値２
        Public Property biko As String                         '備考
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
