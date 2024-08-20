' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 業務共通(処理)
'             区分列挙型
' 作成日　　: 2024.07.12
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Enum Enum予約関係分類
        名称関係 = 1
        検査方法コード関係
    End Enum
    Public Enum Enum対象区分
        対象外 = 0
        対象
        不明 = 9
    End Enum
    Public Enum Enumフリー項目グループNo
        グループ = 1
        グループ2
    End Enum
    Public Enum Enumフリーマスタ分類
        成人 = 1
        指導
        母子
        対象者抽出
    End Enum
    Public Enum Enum拡予約指導業務区分
        成人保健 = 1
        母子保健
        予防接種
    End Enum
    Public Enum Enum基準値業務区分
        成人保健 = 1
        母子保健
        予防接種
    End Enum
    Public Enum Enumコントローラー分類
        数値 = 1
        文字
        日付
        選択
        検索
        選択_検索
    End Enum
    Public Enum Enum検診関連汎用マスタ区分
        検査方法 = 1
        予約分類
        グループ2
    End Enum
    Public Enum Enumログ区分
        通信ログ = 1
        バッチログ
        連携ログ
    End Enum
    Public Enum Enumログイン区分
        一回目 = 1
        二回目
    End Enum
    Public Enum Enum編集区分
        新規 = 1
        変更
    End Enum
    Public Enum Enum遷移区分
        初期化 = 1
        タブ追加
    End Enum
    Public Enum Enum表示区分
        期限内 = 1
        すべて
    End Enum
    Public Enum Enum未読区分
        未読 = 1
        すべて
    End Enum
    Public Enum Enum更新区分
        追加 = 1
        削除
    End Enum
    Public Enum Enumお気に入り区分
        なし = Enum更新区分.追加
        あり = Enum更新区分.削除
    End Enum
    Public Enum Enum処理結果区分
        正常終了
        異常終了
        要確認
        処理停止
        実行中             ' todo chen: ログと同じ名称マスタコードでいい？BCC様に要確認
    End Enum
    Public Enum Enum表示色区分
        黒
        青
        赤
    End Enum

    Public Enum Enum共通バー番号
        メモ情報 = 1
        電子ファイル情報
        メモ情報_世帯
        連絡先
        個人照会
        警告情報照会
        送付先管理
        フォロー管理
        健診結果保健指導履歴照会
        料金内訳
        対象サイン
    End Enum

    Public Enum Enum項目区分
        文字 = 1
        数字
        日付
        日付不明
        日時 = 5
    End Enum

    Public Enum Enum性別
        不明 = 0
        男 = EnumSex.男
        女 = EnumSex.女
        その他 = 9
    End Enum
    Public Enum EnumBirthSearchKbn
        年齢 = 1
        生年月日
    End Enum

    Public Enum Enum入力値保存型
        数値 = 1
        文字
    End Enum

    ''' <summary>
    ''' 画面項目入力タイプ
    ''' </summary>
    Public Enum Enum画面項目入力
        数値 = 1
        文字
        日付
        選択
        検索
        選択_検索
    End Enum

    Public Enum Enum基準値範囲
        正常値範囲 = 0
        注意値範囲
        異常値範囲
    End Enum

    Public Enum Enumユーザー状態
        正常
        停止
        ロック
        無効
    End Enum

    Public Enum Enum表示
        非表示
        表示
    End Enum

    Public Enum Enum連絡先タブ区分
        妊娠届出情報 = 1
        出生時状況
        他市町村_医療機関等への接種依頼
        健康被害救済制度情報
        その他
    End Enum

    Public Enum Enum連絡先タブ名称
        本人
        父親
        母親
        保護者
        該当者
        請求者
    End Enum

    Public Enum Enum事業コード区分
        メモ = 1
        電子ファイル
        医療機関
        事業従事者
        連絡先
        フォロー事業
    End Enum

    Public Enum Enum事業コードパターン
        DB設定 = 1
        画面選択
    End Enum

    Public Enum Enum事業コード取得方法
        集約区分 = 1
        事業コード
    End Enum

    Public Enum Enum削除区分
        単一削除
        全削除
    End Enum

    Public Enum Enum入力タイプ分類
        半角 = 1
        全角
        日付
        コード
    End Enum

    Public Enum Enum入力タイプ型
        数値 = 1
        文字
    End Enum

    Public Enum Enum条件コード区分
        コード1 = 1
        コード2
        コード3
    End Enum

    Public Enum EnumAndOr
        AndCode
        OrCode
    End Enum

End Namespace
