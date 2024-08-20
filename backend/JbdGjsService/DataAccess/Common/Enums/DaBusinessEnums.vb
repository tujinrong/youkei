' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 業務共通(DB)
'             区分列挙型
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************


Namespace JBD.GJS.Service
    Public Enum Enum特殊一覧検索機能
        AWSH001        '成人検診
        AWKK00101G     '住民・住登外
        AWKK00401G     'フォロー管理
        AWKK01001G     '帳票発行対象外者管理
        AWSH00302G     '対象サイン
        AWSH00401G     '健（検）診予定管理
        AWSH00402G_1   '健（検）診予約希望者管理(日程一覧画面)
        AWSH00402G_2   '健（検）診予約希望者管理(予約者一覧画面：予約情報)
        AWSH00402G_3   '健（検）診予約希望者管理(予約者一覧画面：予約者情報)
        AWKK00111G     '住登外
        AWKK00301G     '保健指導
        Bosi           '母子保健
    End Enum

    Public Enum Enum名称区分
        名称 = 1
        カナ
        略称
    End Enum

    Public Enum Enumマスタ区分
        名称マスタ = 1
        汎用マスタ
        医療機関マスタ
        ユーザーマスタ
        所属グループマスタ
        市区町村マスタ
        地区情報マスタ
        会場情報マスタ
        事業従事者担当者情報マスタ
        医療機関マスタ_保険
    End Enum

    Public Enum Enumシステムマスタ区分
        名称メインマスタ
        汎用メインマスタ
        EUCテーブルマスタ
        機能マスタ
        タスクスケジュール情報マスタ
        EUC帳票マスタ
        EUC様式詳細マスタ
        帳票発行抽出対象マスタ
    End Enum

    ''' <summary>
    ''' 1:整数;2:小数;3:文字;4:日付;5:時間;6:フラグ
    ''' </summary>
    Public Enum EnumDataType
        整数 = 1
        小数
        文字列
        日付
        時間
        フラグ
    End Enum

    Public Enum EnumMsgCtrlKbn
        エラー = 1
        アラート
        非表示
    End Enum

    Public Enum Enum詳細検索条件区分
        共通 = 1
        独自
    End Enum

    ''' <summary>
    ''' 詳細条件
    ''' </summary>
    Public Enum Enumコントローラータイプ
        通用項目 = 1
        年齢生年月日
        一覧選択
        参照ダイアログ
    End Enum

    ''' <summary>
    ''' 参照ダイアログ項目区分
    ''' </summary>
    Public Enum Enum参照ダイアログ項目区分
        宛名番号 = 1
        医療機関
        事業従事者
        検診実施機関
    End Enum

    Public Enum Enum取得元区分
        テーブル固定項目 = 1
        フリー項目
    End Enum

    Public Enum EnumKensinKbn
        一次 = 1
        精密
    End Enum

    Public Enum Enum計算区分
        Empty = -1
        数式計算 = 1
        内部関数
        DB関数
    End Enum

    ''' <summary>
    ''' 入力項目コントローラータイプ
    ''' </summary>
    Public Enum Enum入力タイプ
        数値_整数 = 1
        数値_小数点付き実数
        数値_符号付き整数
        半角文字_半角数字 = 11
        半角文字_半角英数字
        半角文字_年
        半角文字_年_不詳あり
        半角文字_年月
        半角文字_年月_不詳あり
        半角文字_時刻
        半角文字_半角
        全角文字_全角_改行不可 = 21
        全角文字_全角_改行可
        全角半角文字_全角半角_改行不可 = 26
        全角半角文字_全角半角_改行可
        日付_年月日 = 31
        日付_年月日_不詳あり
        日時_年月日時分秒
        コード_名称マスタ = 41
        コード_汎用マスタ
        コード_ユーザーマスタ = 44
        コード_所属グループマスタ
        コード_地区情報マスタ
        コード_会場情報マスタ = 48
        年齢範囲＿抽出専用画面のみ使用可 = 51
        宛名番号 = 61
        医療機関 = 70
        事業従事者 = 71
        検診実施機関 = 72
    End Enum

    Public Enum Enum住登区分
        住民 = 1
        住登外
    End Enum

    Public Enum Enum住民種別
        日本人住民 = 1
        外国人住民
    End Enum

    ''' <summary>
    ''' 基準値用
    ''' </summary>
    Public Enum EnumSex
        Empty = -1
        男 = 1
        女
    End Enum

    Public Enum Enumロール区分
        ユーザー
        所属
    End Enum

    Public Enum Enumプログラム区分
        画面
        共通バー機能
    End Enum

    Public Enum Enum地区区分
        地区1 = 1
        地区2
        地区3
        地区4
        地区5
        地区6
        地区7
        地区8
        地区9
        地区10
    End Enum

    Public Enum Enum精密検査実施区分
        未実施
        実施
    End Enum

    Public Enum Enum画面表示区分
        非表示
        表示
    End Enum

    Public Enum Enum事業区分
        基本事業
        市区町村拡事業
    End Enum

    Public Enum Enumフリー項目区分区分
        PKG標準項目拡領域不使用 = 1
        PKG標準項目拡領域使用
        市区町村独自項目
    End Enum

    Public Enum Enum指導区分
        訪問指導 = 1
        個別指導
        集団指導
    End Enum

    Public Enum Enum申込結果
        申込 = 1
        結果
    End Enum

    Public Enum Enum項目用途区分
        集団以外
        事業用
        参加者用
    End Enum

    Public Enum Enum町字区分
        Empty = -1
        大字町名 = 1
        丁目
        小字
    End Enum

    Public Enum Enum年齢基準日区分
        受診日時点 = 0
        指定日
    End Enum

    Public Enum Enum引用符_CSV出力用
        なし = 0
        ダブルコーテーション
        シングルコーテーション
        混在パターン
    End Enum

    Public Enum Enum取込業務区分
        共通管理 = 1
        成人保健 = 2
        母子保健 = 3
        予防接種 = 4
    End Enum

    Public Enum Enum取込区分
        ファイル取込 = 1
        一括入力 = 2
    End Enum

    Public Enum Enum登録区分
        削除新規 = 1
        新規 = 2
        更新 = 3
    End Enum

    Public Enum Enumファイル形式
        CSVファイル = 1
        テキストファイル = 2
        XMLファイル = 3
    End Enum

    Public Enum Enumエンコード
        SJIS = 1
        UTF_8 = 2
        UTF_16 = 3
    End Enum

    Public Enum Enumデータ形式
        可変長 = 1
        固定長 = 2
    End Enum

    Public Enum Enum区切り記号
        カンマ = 1
        タブ = 2
    End Enum

    Public Enum Enum項目特定区分
        宛名番号 = 1
        氏名 = 2
        実施日_一次_申込 = 3
        実施日_精密_結果 = 4
        生年月日 = 5
        実施年齢_一次_申込 = 6
        実施年齢_精密_結果 = 7
        年度_一次_申込
        年度_精密_結果
        性別
        検診実施機関番号
        医療機関コード
        医療機関名
        会場コード
        会場名
    End Enum

    Public Enum Enumマッピング区分
        マッピングなし = 0
        関数 = 1
        単一項目移送 = 2
    End Enum

    Public Enum Enumマッピング方法
        宛名番号取得 = 11
        医療機関コード取得 = 12
        年度取得
        桁数指定 = 21
    End Enum

    Public Enum Enum入力区分
        テキスト = 1
        コード系 = 2
        画面検索 = 3
        マスタ参照 = 4
        プルダウンリスト = 5
        関数 = 6
        プルダウン_画面検索 = 7
    End Enum

    Public Enum Enum入力方法
        数値_整数 = 1
        数値_小数点付き実数
        数値_符号付き整数
        半角文字_半角数字 = 11
        半角文字_半角英数字
        半角文字_年
        半角文字_年_不詳あり
        半角文字_年月
        半角文字_年月_不詳あり
        半角文字_時刻
        半角文字_半角
        全角文字_全角_改行不可 = 21
        全角文字_全角_改行可
        全角半角文字_全角半角_改行不可 = 26
        全角半角文字_全角半角_改行可
        日付_年月日 = 31
        日付_年月日_不詳あり
        日時_年月日時分秒 = 33
        宛名番号 = 61
        医療機関 = 70
        事業従事者 = 71
        検診実施機関 = 72
        コード_ユーザーマスタ = 44
        コード_所属グループマスタ = 45
        コード_地区情報マスタ = 46
        コード_会場情報マスタ = 48
    End Enum
    Public Enum Enum年度範囲区分
        システム年度_システム年度 = 1
        システム年度_システム年度Plus1 = 2
        メニュー引き継ぐ_コントロールマスタ年度 = 3
    End Enum
    Public Enum Enumフォーマット_画面定義
        左0埋め = 1
        右0埋め = 2
    End Enum

    Public Enum Enumエラーレベル
        無視 = 0
        情報 = 1
        警告 = 2
        エラー = 3
    End Enum

    Public Enum Enum表示入力設定
        入力 = 1
        表示 = 2
        非表示 = 3
    End Enum

    Public Enum Enum演算子
        等しい = 1
        等しくない = 2
        より大さい = 3
        より小さい = 4
        以上 = 5
        以下 = 6
        [like] = 7
        not_like = 8
        between = 9
        not_between = 10
        is_null = 11
        is_not_null = 12
    End Enum

    Public Enum Enum処理区分
        画面項目登録 = 1
        固定値登録 = 2
        自動 = 3
        設定しない = 4
        関連テーブルの項目から登録 = 5
        手動採番 = 6
        不祥フラグ登録 = 7
        年齢登録_一次申込 = 8
        年齢登録_精密結果 = 9
        年度登録
    End Enum

    Public Enum Enum処理種別
        チェック用 = 1
        更新前処理 = 2
        更新後処理 = 3
    End Enum

    Public Enum Enum自動処理区分
        固定値 = 1
        親テーブルの項目から = 2
        自動採番 = 3
        手動採番 = 4
        自動登録 = 5
    End Enum

    Public Enum Enum待機フラグ
        希望しない = 1
        希望する
    End Enum

    Public Enum Enum減免区分種別
        特定健診 = 1
        がん検診
    End Enum

    Public Enum Enum生涯１回フラグ
        生涯複数回 = 0
        生涯1回
    End Enum

#Region "帳票"

    Public Enum Enum業務区分
        互助防疫共通 = 1
        成人保健
        母子保健
        予防接種
        統計_報告
    End Enum

    Public Enum Enum検索条件区分
        通常条件 = 1
        固定条件
        前提条件
    End Enum

    Public Enum Enum使用区分
        一覧項目 = 1
        集計項目
        併用
    End Enum

    Public Enum Enum出力項目区分
        普通項目 = 1
        宛名番号
        個人番号
    End Enum

    Public Enum Enum集計項目区分
        GroupBy = 1
        Count
        Sum
    End Enum

    Public Enum Enum集計区分
        GroupBy縦 = 1 '行ヘッダー
        GroupBy横 '列ヘッダー
        集計
    End Enum

    Public Enum Enum集計方法
        Count = 1
        Sum
        Max
        Min
    End Enum

    Public Enum Enum集計方法文字
        件数 = Enum集計方法.Count
        合計 = Enum集計方法.Sum
        最大値 = Enum集計方法.Max
        最小値 = Enum集計方法.Min
    End Enum

    Public Enum Enum小計区分
        '0:なし;1:前;2:後
        'なし = 0,
        内訳小計 = 1
        小計
    End Enum

    Public Enum Enumデータタイプ
        文字 = 1
        数値 = 2
        年 = 3
        年月日 = 4
        年月日時分秒 = 5
        時分秒 = 6
        論理型 = 7
        バーコード = 8
        QRコード = 9
        図 = 10
        ' TODO...
    End Enum

    Public Enum EnumTableKbn
        トランザクション = 1
        マスタ
        フリー
        VIEW
    End Enum

    Public Enum Enum帳票様式
        帳票 = 1
        別様式
        サブ様式
    End Enum

    Public Enum Enum内外区分
        内部帳票 = 1
        外部帳票
    End Enum

    Public Enum Enum帳票種別区分
        台帳 = 1
        一覧表
        集計
        特定様式
        CSV
    End Enum

    Public Enum Enum様式種別
        一覧表 = 1
        台帳 = 2
        経年表 = 3
        集計表 = 4
        カスタマイズ = 5
    End Enum

    Public Enum Enum様式種別詳細
        一覧表 = 11
        台帳 = 21
        経年表 = 31
        単純集計表 = 41
        クロス集計 = 42
        はがき = 51
        アドレスシール = 52
        バーコードシール = 53
        宛名台帳 = 54
        '行固定 = 11,
        '行可変 = 12,
        '明細なし = 21,
        '明細あり_行固定 = 22,
        '明細あり_行可変 = 23,
        '経年表 = 31,
        '行列固定 = 41,
        '行列可変 = 42,
        'カスタマイズ = 51,
        'はがき = 52,
        'アドレスシール = 53,
        'バーコードシール = 54,
        '宛名台帳 = 55
    End Enum

    Public Enum Enum様式作成方法
        データソース = 1
        SQL
        プロシージャ
    End Enum
    Public Enum Enum明細有無
        明細あり = 1
        明細なし = 0
    End Enum
    Public Enum Enum行列固定
        固定 = 1
        可変
    End Enum
    Public Enum Enum並び替え
        降順 = 0
        無し
        昇順
    End Enum
    Public Enum Enumページサイズ
        A3 = 3
        A4 = 4
        A5 = 5
        A6 = 6
        B5 = 7
        B6Jis = 8
    End Enum

    Public Enum Enumコントロール
        数値入力 = 1
        文字入力
        日付入力
        時間入力
        数値範囲
        文字範囲
        日付範囲
        時間範囲
        選択
        複数選択
        論理値
        宛名入力
        年度
    End Enum

    Public Enum Enum文字暦法区分
        かな漢字 = 1
        半角カナ
        全角カナ
        英字
        数値
        西暦
        和暦
    End Enum

    Public Enum Enum文字区分
        かな漢字 = Enum文字暦法区分.かな漢字
        半角カナ = Enum文字暦法区分.半角カナ
        全角カナ = Enum文字暦法区分.全角カナ
        英字 = Enum文字暦法区分.英字
        数値 = Enum文字暦法区分.数値
    End Enum

    Public Enum Enum暦法区分
        西暦 = Enum文字暦法区分.西暦
        和暦 = Enum文字暦法区分.和暦
    End Enum

    Public Enum Enum履歴出力状態区分
        予定中 = 1
        処理中
        処理完了
        処理失敗
    End Enum

    Public Enum Enum出力方式
        PDF = 0
        EXCEL = 1
        CSV = 3
    End Enum

    Public Enum CodeTypeEnum
        文字 = 1
        数値
        選択
    End Enum

    Public Enum Enum検索区分
        完全検索 = 0
        部分一致_中間一致
        部分一致_前方一致
    End Enum

#End Region
End Namespace
