' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             宛名テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_afatenaDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afatena"
        Public Property atenano As String                       '宛名番号
        Public Property setaino As String                       '世帯番号
        Public Property jutokbn As Enum住登区分                 '住登区分
        Public Property juminsyubetu As Enum住民種別            '住民種別
        Public Property juminjotai As String                    '住民状態
        Public Property juminkbn As String                      '住民区分
        Public Property simei As String                         '氏名
        Public Property simei_kana As String                   '氏名_フリガナ
        Public Property simei_kana_seion As String             '氏名_フリガナ_清音化
        Public Property tusyo As String                        '通称
        Public Property tusyo_kana As String                   '通称_フリガナ
        Public Property tusyo_kana_seion As String             '通称_フリガナ_清音化
        Public Property simei_yusen As String                   '氏名_優先
        Public Property simei_kana_yusen As String             '氏名_フリガナ_優先
        Public Property simei_kana_yusen_seion As String       '氏名_フリガナ_優先_清音化
        Public Property sex As String                           '性別
        Public Property bymd As String                         '生年月日
        Public Property bymd_fusyoflg As Boolean                  '生年月日_不詳フラグ
        Public Property bymd_fusyohyoki As String              '生年月日_不詳表記
        Public Property zokucd1 As String                      '続柄コード1
        Public Property zokucd2 As String                      '続柄コード2
        Public Property zokucd3 As String                      '続柄コード3
        Public Property zokucd4 As String                      '続柄コード4
        Public Property zokuhyoki As String                     '続柄表記
        Public Property adrs_sikucd As String                   '住所_市区町村コード
        Public Property adrs_tyoazacd As String                 '住所_町字コード
        Public Property tosi_gyoseikucd As String              '指定都市_行政区等コード
        Public Property adrs1 As String                         '住所1
        Public Property adrs2 As String                        '住所2
        Public Property adrs_katagakicd As String              '住所_方書コード
        Public Property adrs_yubin As String                    '住所_郵便番号
        Public Property tikukanricd1 As String                 '地区管理コード1
        Public Property tikukanricd2 As String                 '地区管理コード2
        Public Property tikukanricd3 As String                 '地区管理コード3
        Public Property tikukanricd4 As String                 '地区管理コード4
        Public Property tikukanricd5 As String                 '地区管理コード5
        Public Property tikukanricd6 As String                 '地区管理コード6
        Public Property tikukanricd7 As String                 '地区管理コード7
        Public Property tikukanricd8 As String                 '地区管理コード8
        Public Property tikukanricd9 As String                 '地区管理コード9
        Public Property tikukanricd10 As String                '地区管理コード10
        Public Property gyoseikucd As String                   '行政区コード
        Public Property siensotikbn As String                  '支援措置区分
        Public Property personalno As String                   '個人番号
        Public Property kazeikbn As String                     '課税非課税区分
        Public Property kazeikbn_setai As String               '課税非課税区分（世帯）
        Public Property hokenkbn As String                     '保険区分
        Public Property genmenkbn_tokutei As String            '減免区分（特定健診）
        Public Property genmenkbn_gan As String                '減免区分（がん検診）
    End Class
End Namespace
