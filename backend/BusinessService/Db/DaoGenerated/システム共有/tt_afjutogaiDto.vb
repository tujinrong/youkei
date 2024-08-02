' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             住登外者情報テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tt_afjutogaiDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afjutogai"
        Public Property atenano As String                       '宛名番号
        Public Property rirekino As Integer                         '履歴番号
        Public Property setaino As String                       '世帯番号
        Public Property jutogaisyasyubetu As String             '住登外者種別
        Public Property jutogaisyajotai As String               '住登外者状態
        Public Property idoymd As String                        '異動年月日
        Public Property idotodokeymd As String                  '異動届出年月日
        Public Property idojiyu As String                      '異動事由
        Public Property simei As String                         '氏名
        Public Property si As String                           '氏_日本人
        Public Property mei As String                          '名_日本人
        Public Property simei_gairoma As String                '氏名_外国人ローマ字
        Public Property simei_gaikanji As String               '氏名_外国人漢字
        Public Property simei_kana As String                   '氏名_フリガナ
        Public Property simei_kana_seion As String             '氏名_フリガナ_清音化
        Public Property si_kana As String                      '氏_日本人_フリガナ
        Public Property si_kana_seion As String                '氏_日本人_フリガナ_清音化
        Public Property mei_kana As String                     '名_日本人_フリガナ
        Public Property mei_kana_seion As String               '名_日本人_フリガナ_清音化
        Public Property tusyo As String                        '通称
        Public Property tusyo_kana As String                   '通称_フリガナ
        Public Property tusyo_kana_seion As String             '通称_フリガナ_清音化
        Public Property tusyo_kanastatus As String             '通称_フリガナ確認状況
        Public Property simei_yusen As String                   '氏名_優先
        Public Property simei_kana_yusen As String             '氏名_フリガナ_優先
        Public Property simei_kana_yusen_seion As String       '氏名_フリガナ_優先_清音化
        Public Property sex As String                          '性別
        Public Property sexhyoki As String                     '性別表記
        Public Property bymd As String                         '生年月日
        Public Property bymd_fusyoflg As Boolean                  '生年月日_不詳フラグ
        Public Property bymd_fusyohyoki As String              '生年月日_不詳表記
        Public Property adrs_sikucd As String                  '住所_市区町村コード
        Public Property adrs_tyoazacd As String                '住所_町字コード
        Public Property tosi_gyoseikucd As String              '指定都市_行政区等コード
        Public Property adrs_todofuken As String               '住所_都道府県
        Public Property adrs_sikunm As String                  '住所_市区郡町村名
        Public Property adrs_tyoaza As String                  '住所_町字
        Public Property adrs_bantihyoki As String              '住所_番地号表記
        Public Property adrs_katagaki As String                '住所_方書
        Public Property adrs_katagaki_kana As String           '住所_方書_フリガナ
        Public Property adrs_yubin As String                   '住所_郵便番号
        Public Property adrs_kokunmcd As String                '住所_国名コード
        Public Property adrs_kokunm As String                  '住所_国名等
        Public Property adrs_gaiadrs As String                 '住所_国外住所
        Public Property hokenkbn As String                     '保険区分
        Public Property nayosemotoflg As String                 '名寄せ元フラグ
        Public Property nayosesakiatenano As String            '名寄せ先宛名番号
        Public Property togoatenaflg As String                  '統合宛名フラグ
        Public Property sansyofukaflg As String                 '他業務参照不可フラグ
        Public Property stopflg As Boolean                         '使用停止フラグ
        Public Property renkeimotosousauserid As String        '連携元操作者ID
        Public Property renkeimotosousadttm As Date        '連携元操作日時
        Public Property saisinflg As Boolean                       '最新フラグ
        Public Property regbusyocd As String                    '登録部署
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
