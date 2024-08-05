' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             EUC帳票項目マスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tm_eurptitemDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_eurptitem"
        Public Property rptid As String                         '帳票ID
        Public Property yosikiid As String                      '様式ID
        Public Property yosikieda As Integer                        '様式枝番
        Public Property yosikiitemid As String                  '様式項目ID
        Public Property reportitemnm As String                  '帳票項目名称
        Public Property csvitemnm As String                     'CSV項目名称
        Public Property sqlcolumn As String                    'SQLカラム
        Public Property tablealias As String                    'テーブル別名
        Public Property orderkbn As Enum並び替え                 '並び替え
        Public Property orderkbnseq As Integer                     '並び替えシーケンス
        Public Property orderseq As Integer                        '並びシーケンス
        Public Property reportoutputflg As Boolean                 '帳票出力フラグ
        Public Property csvoutputflg As Boolean                    'CSV出力フラグ
        Public Property headerflg As Boolean                       'ヘッダーフラグ
        Public Property kaipageflg As Boolean                      '改ページフラグ
        Public Property itemkbn As Enum出力項目区分               '項目区分
        Public Property formatkbn As String                    'フォーマット区分
        Public Property formatkbn2 As String                   'フォーマット区分2
        Public Property formatsyosai As String                 'フォーマット詳細
        Public Property height As Integer                          '高
        Public Property width As Integer                           '幅
        Public Property offsetx As Integer                         'X軸オフセット
        Public Property offsety As Integer                         'Y軸オフセット
        Public Property blankvalue As String                   '白紙表示
        Public Property mastercd As String                     '名称マスタコード
        Public Property masterpara As String                   '名称マスタパラメータ
        Public Property keyvaluepairsjson As String            '複数のキー・値・ペアjson
        Public Property crosskbn As String                     '集計区分
        'public string syukeihoho { get; set; }                   //集計方法
        Public Property kbn1 As String                         '小計区分
        Public Property level As Integer                           '集計レベル
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
