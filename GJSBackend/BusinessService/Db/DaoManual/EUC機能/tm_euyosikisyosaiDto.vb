' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             EUC様式詳細マスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tm_euyosikisyosaiDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_euyosikisyosai"
        Public Property rptid As String                         '帳票ID
        Public Property yosikiid As String                      '様式ID
        Public Property yosikieda As Integer                        '様式枝番
        Public Property yosikinm As String                      '様式名
        Public Property yosikisyubetu As Enum様式種別                 '様式種別
        Public Property yosikikbn As Enum様式種別詳細                     '様式種別詳細
        Public Property meisaiflg As Boolean                       '明細有無
        Public Property meisaikoteikbn As String               '行（列）固定区分
        Public Property yosikihouhou As Enum様式作成方法                  '様式作成方法
        Public Property datasourceid As String                 'データソースID
        Public Property himozukejyokenid As Integer                '様式紐付け条件ID
        Public Property sql As String                          'SQL
        Public Property procnm As String                       'プロシージャ名
        Public Property distinctflg As Boolean                     '重複データ排除フラグ
        Public Property nulltozeroflg As Boolean                   '空白値ゼロ出力フラグ
        Public Property startrow As Integer                        'テンプレート明細開始行
        Public Property loopmaxrow As Integer                      '１ページあたりの最大行数
        Public Property looprow As Integer                         '1明細あたりの行数
        Public Property startcol As Integer                        '明細開始列数
        Public Property loopmaxcol As Integer                      '１ページあたりの最大列数
        Public Property loopcol As Integer                         '1明細あたりの列数
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
