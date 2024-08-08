' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             詳細条件設定テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_affilterDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_affilter"
        Public Property kinoid As String                        '機能ID
        Public Property jyokbn As Enum詳細検索条件区分          '条件区分
        Public Property jyoseq As Integer                           '条件シーケンス
        Public Property hyojinm As String                       '詳細条件表示名
        Public Property ctrltype As Enumコントローラータイプ    'コントローラータイプ
        Public Property hyojiflg As Boolean                        '表示フラグ
        Public Property sort As Integer                            '並び順
        Public Property placeholder As String                  '入力説明
        Public Property rangeflg As Boolean                        '範囲フラグ
        Public Property sethanyokbn1 As String                  '設定用汎用区分1
        Public Property sethanyokbn2 As String                 '設定用汎用区分2
        Public Property sethanyokbn3 As String                 '設定用汎用区分3
        Public Property sethanyokbn4 As String                 '設定用汎用区分4
        Public Property sethanyokbn5 As String                 '設定用汎用区分5
        Public Property getkbn As Enum取得元区分                '検索対象データ取得区分
        Public Property tablenm1 As String                      'テーブル物理名1
        Public Property komokunm1 As String                     '項目物理名1
        Public Property keycd1 As String                       '主キーコード1
        Public Property itemcd1 As String                      '項目コード1
        Public Property tablenm2 As String                     'テーブル物理名2
        Public Property komokunm2 As String                    '項目物理名2
        Public Property keycd2 As String                       '主キーコード2
        Public Property itemcd2 As String                      '項目コード2
        Public Property tablenm3 As String                     'テーブル物理名3
        Public Property komokunm3 As String                    '項目物理名3
        Public Property keycd3 As String                       '主キーコード3
        Public Property itemcd3 As String                      '項目コード3
    End Class
End Namespace
