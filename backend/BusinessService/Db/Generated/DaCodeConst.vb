' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 名称マスタコード定義
'             
' 作成日　　: 2024.07.17
' 作成者　　: AIPlus
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class DaCodeConst
        ''' <summary>
        ''' 名称マスタ
        ''' </summary>
        Public Class 名称マスタ
            ''' <summary>
            ''' システム
            ''' </summary>
            Public Class システム
                ''' <summary>
                ''' メニュー
                ''' </summary>
                Public Class メニュー
                    ''' <summary>システム共有</summary>
                    Public Const _AWAF As String = "AWAF"
                    ''' <summary>制御情報保守</summary>
                    Public Const _AWAF008 As String = "AWAF008"
                    ''' <summary>共通管理</summary>
                    Public Const _AWKK As String = "AWKK"
                    ''' <summary>基幹システム情報</summary>
                    Public Const _AWKK001 As String = "AWKK001"
                    ''' <summary>マスタ情報保守</summary>
                    Public Const _AWKK002 As String = "AWKK002"
                    ''' <summary>取込設定管理</summary>
                    Public Const _AWKK006 As String = "AWKK006"
                    ''' <summary>取込実行管理</summary>
                    Public Const _AWKK007 As String = "AWKK007"
                    ''' <summary>予約管理</summary>
                    Public Const _AWKK009 As String = "AWKK009"
                    ''' <summary>成人保健</summary>
                    Public Const _AWSH As String = "AWSH"
                    ''' <summary>受診情報管理</summary>
                    Public Const _AWSH001 As String = "AWSH001"
                    ''' <summary>健（検）診対象者管理</summary>
                    Public Const _AWSH003 As String = "AWSH003"
                    ''' <summary>予約管理</summary>
                    Public Const _AWSH004 As String = "AWSH004"
                    ''' <summary>自己負担金</summary>
                    Public Const _AWSH006 As String = "AWSH006"
                    ''' <summary>母子保健</summary>
                    Public Const _AWBH As String = "AWBH"
                    ''' <summary>予防接種</summary>
                    Public Const _AWYS As String = "AWYS"
                    ''' <summary>統計報告</summary>
                    Public Const _AWTH As String = "AWTH"
                    ''' <summary>EUC機能</summary>
                    Public Const _AWEU As String = "AWEU"
                End Class

                ''' <summary>
                ''' 名称マスタメインコード
                ''' </summary>
                Public Class 名称マスタメインコード
                    ''' <summary>システム共有</summary>
                    Public Const _1000 As String = "1000"
                    ''' <summary>共通管理</summary>
                    Public Const _1001 As String = "1001"
                    ''' <summary>成人保健</summary>
                    Public Const _1002 As String = "1002"
                    ''' <summary>母子保健</summary>
                    Public Const _1003 As String = "1003"
                    ''' <summary>予防接種</summary>
                    Public Const _1004 As String = "1004"
                    ''' <summary>統計報告</summary>
                    Public Const _1005 As String = "1005"
                    ''' <summary>EUC機能</summary>
                    Public Const _1006 As String = "1006"
                    ''' <summary>住民基本台帳</summary>
                    Public Const _2001 As String = "2001"
                    ''' <summary>印鑑登録</summary>
                    Public Const _2002 As String = "2002"
                    ''' <summary>戸籍</summary>
                    Public Const _2003 As String = "2003"
                    ''' <summary>戸籍の附票</summary>
                    Public Const _2004 As String = "2004"
                    ''' <summary>選挙（共通）</summary>
                    Public Const _2005 As String = "2005"
                    ''' <summary>選挙人名簿管理</summary>
                    Public Const _2006 As String = "2006"
                    ''' <summary>期日前・不在者投票管理</summary>
                    Public Const _2007 As String = "2007"
                    ''' <summary>当日投票管理</summary>
                    Public Const _2008 As String = "2008"
                    ''' <summary>在外選挙管理</summary>
                    Public Const _2009 As String = "2009"
                    ''' <summary>個人住民税</summary>
                    Public Const _2010 As String = "2010"
                    ''' <summary>法人住民税</summary>
                    Public Const _2011 As String = "2011"
                    ''' <summary>固定資産税</summary>
                    Public Const _2012 As String = "2012"
                    ''' <summary>軽自動車税</summary>
                    Public Const _2013 As String = "2013"
                    ''' <summary>収納管理（税務システム）</summary>
                    Public Const _2014 As String = "2014"
                    ''' <summary>滞納管理（税務システム）</summary>
                    Public Const _2015 As String = "2015"
                    ''' <summary>地方税（共通）</summary>
                    Public Const _2016 As String = "2016"
                    ''' <summary>学齢簿編製</summary>
                    Public Const _2017 As String = "2017"
                    ''' <summary>就学援助</summary>
                    Public Const _2018 As String = "2018"
                    ''' <summary>互助防疫</summary>
                    Public Const _2019 As String = "2019"
                    ''' <summary>児童扶養手当</summary>
                    Public Const _2020 As String = "2020"
                    ''' <summary>生活保護</summary>
                    Public Const _2021 As String = "2021"
                    ''' <summary>障害者福祉</summary>
                    Public Const _2022 As String = "2022"
                    ''' <summary>介護保険</summary>
                    Public Const _2023 As String = "2023"
                    ''' <summary>国民健康保険</summary>
                    Public Const _2024 As String = "2024"
                    ''' <summary>後期高齢者医療</summary>
                    Public Const _2025 As String = "2025"
                    ''' <summary>国民年金</summary>
                    Public Const _2026 As String = "2026"
                    ''' <summary>児童手当</summary>
                    Public Const _2027 As String = "2027"
                    ''' <summary>子ども・子育て支援</summary>
                    Public Const _2028 As String = "2028"
                    ''' <summary>申請管理</summary>
                    Public Const _2029 As String = "2029"
                    ''' <summary>庁内データ連携</summary>
                    Public Const _2030 As String = "2030"
                    ''' <summary>住登外宛名番号管理</summary>
                    Public Const _2031 As String = "2031"
                    ''' <summary>団体内統合宛名管理</summary>
                    Public Const _2032 As String = "2032"
                    ''' <summary>職員認証</summary>
                    Public Const _2033 As String = "2033"
                    ''' <summary>EUC</summary>
                    Public Const _2034 As String = "2034"
                    ''' <summary>レセプト管理（生保）</summary>
                    Public Const _2035 As String = "2035"
                    ''' <summary>統合収納管理</summary>
                    Public Const _2036 As String = "2036"
                    ''' <summary>統合滞納管理</summary>
                    Public Const _2037 As String = "2037"
                    ''' <summary>住民基本台帳</summary>
                    Public Const _3001 As String = "3001"
                    ''' <summary>個人住民税</summary>
                    Public Const _3010 As String = "3010"
                    ''' <summary>互助防疫</summary>
                    Public Const _3019 As String = "3019"
                End Class

                ''' <summary>
                ''' 汎用マスタメインコード
                ''' </summary>
                Public Class 汎用マスタメインコード
                    ''' <summary>システム共有</summary>
                    Public Const _1000 As String = "1000"
                    ''' <summary>共通管理</summary>
                    Public Const _1001 As String = "1001"
                    ''' <summary>成人保健</summary>
                    Public Const _1002 As String = "1002"
                    ''' <summary>母子保健</summary>
                    Public Const _1003 As String = "1003"
                    ''' <summary>予防接種</summary>
                    Public Const _1004 As String = "1004"
                    ''' <summary>統計報告</summary>
                    Public Const _1005 As String = "1005"
                    ''' <summary>EUC機能</summary>
                    Public Const _1006 As String = "1006"
                    ''' <summary>住民基本台帳</summary>
                    Public Const _2001 As String = "2001"
                    ''' <summary>印鑑登録</summary>
                    Public Const _2002 As String = "2002"
                    ''' <summary>戸籍</summary>
                    Public Const _2003 As String = "2003"
                    ''' <summary>戸籍の附票</summary>
                    Public Const _2004 As String = "2004"
                    ''' <summary>選挙（共通）</summary>
                    Public Const _2005 As String = "2005"
                    ''' <summary>選挙人名簿管理</summary>
                    Public Const _2006 As String = "2006"
                    ''' <summary>期日前・不在者投票管理</summary>
                    Public Const _2007 As String = "2007"
                    ''' <summary>当日投票管理</summary>
                    Public Const _2008 As String = "2008"
                    ''' <summary>在外選挙管理</summary>
                    Public Const _2009 As String = "2009"
                    ''' <summary>個人住民税</summary>
                    Public Const _2010 As String = "2010"
                    ''' <summary>法人住民税</summary>
                    Public Const _2011 As String = "2011"
                    ''' <summary>固定資産税</summary>
                    Public Const _2012 As String = "2012"
                    ''' <summary>軽自動車税</summary>
                    Public Const _2013 As String = "2013"
                    ''' <summary>収納管理（税務システム）</summary>
                    Public Const _2014 As String = "2014"
                    ''' <summary>滞納管理（税務システム）</summary>
                    Public Const _2015 As String = "2015"
                    ''' <summary>地方税（共通）</summary>
                    Public Const _2016 As String = "2016"
                    ''' <summary>学齢簿編製</summary>
                    Public Const _2017 As String = "2017"
                    ''' <summary>就学援助</summary>
                    Public Const _2018 As String = "2018"
                    ''' <summary>互助防疫</summary>
                    Public Const _2019 As String = "2019"
                    ''' <summary>児童扶養手当</summary>
                    Public Const _2020 As String = "2020"
                    ''' <summary>生活保護</summary>
                    Public Const _2021 As String = "2021"
                    ''' <summary>障害者福祉</summary>
                    Public Const _2022 As String = "2022"
                    ''' <summary>介護保険</summary>
                    Public Const _2023 As String = "2023"
                    ''' <summary>国民健康保険</summary>
                    Public Const _2024 As String = "2024"
                    ''' <summary>後期高齢者医療</summary>
                    Public Const _2025 As String = "2025"
                    ''' <summary>国民年金</summary>
                    Public Const _2026 As String = "2026"
                    ''' <summary>児童手当</summary>
                    Public Const _2027 As String = "2027"
                    ''' <summary>子ども・子育て支援</summary>
                    Public Const _2028 As String = "2028"
                    ''' <summary>申請管理</summary>
                    Public Const _2029 As String = "2029"
                    ''' <summary>庁内データ連携</summary>
                    Public Const _2030 As String = "2030"
                    ''' <summary>住登外宛名番号管理</summary>
                    Public Const _2031 As String = "2031"
                    ''' <summary>団体内統合宛名管理</summary>
                    Public Const _2032 As String = "2032"
                    ''' <summary>職員認証</summary>
                    Public Const _2033 As String = "2033"
                    ''' <summary>EUC</summary>
                    Public Const _2034 As String = "2034"
                    ''' <summary>レセプト管理（生保）</summary>
                    Public Const _2035 As String = "2035"
                    ''' <summary>統合収納管理</summary>
                    Public Const _2036 As String = "2036"
                    ''' <summary>統合滞納管理</summary>
                    Public Const _2037 As String = "2037"
                    ''' <summary>住民基本台帳</summary>
                    Public Const _3001 As String = "3001"
                    ''' <summary>個人住民税</summary>
                    Public Const _3010 As String = "3010"
                    ''' <summary>互助防疫</summary>
                    Public Const _3019 As String = "3019"
                End Class

                ''' <summary>
                ''' コントロールマスタメインコード
                ''' </summary>
                Public Class コントロールマスタメインコード
                    ''' <summary>システム共有</summary>
                    Public Const _1000 As String = "1000"
                    ''' <summary>共通管理</summary>
                    Public Const _1001 As String = "1001"
                    ''' <summary>成人保健</summary>
                    Public Const _1002 As String = "1002"
                    ''' <summary>母子保健</summary>
                    Public Const _1003 As String = "1003"
                    ''' <summary>予防接種</summary>
                    Public Const _1004 As String = "1004"
                    ''' <summary>統計報告</summary>
                    Public Const _1005 As String = "1005"
                    ''' <summary>EUC機能</summary>
                    Public Const _1006 As String = "1006"
                    ''' <summary>住民基本台帳</summary>
                    Public Const _2001 As String = "2001"
                    ''' <summary>印鑑登録</summary>
                    Public Const _2002 As String = "2002"
                    ''' <summary>戸籍</summary>
                    Public Const _2003 As String = "2003"
                    ''' <summary>戸籍の附票</summary>
                    Public Const _2004 As String = "2004"
                    ''' <summary>選挙（共通）</summary>
                    Public Const _2005 As String = "2005"
                    ''' <summary>選挙人名簿管理</summary>
                    Public Const _2006 As String = "2006"
                    ''' <summary>期日前・不在者投票管理</summary>
                    Public Const _2007 As String = "2007"
                    ''' <summary>当日投票管理</summary>
                    Public Const _2008 As String = "2008"
                    ''' <summary>在外選挙管理</summary>
                    Public Const _2009 As String = "2009"
                    ''' <summary>個人住民税</summary>
                    Public Const _2010 As String = "2010"
                    ''' <summary>法人住民税</summary>
                    Public Const _2011 As String = "2011"
                    ''' <summary>固定資産税</summary>
                    Public Const _2012 As String = "2012"
                    ''' <summary>軽自動車税</summary>
                    Public Const _2013 As String = "2013"
                    ''' <summary>収納管理（税務システム）</summary>
                    Public Const _2014 As String = "2014"
                    ''' <summary>滞納管理（税務システム）</summary>
                    Public Const _2015 As String = "2015"
                    ''' <summary>地方税（共通）</summary>
                    Public Const _2016 As String = "2016"
                    ''' <summary>学齢簿編製</summary>
                    Public Const _2017 As String = "2017"
                    ''' <summary>就学援助</summary>
                    Public Const _2018 As String = "2018"
                    ''' <summary>互助防疫</summary>
                    Public Const _2019 As String = "2019"
                    ''' <summary>児童扶養手当</summary>
                    Public Const _2020 As String = "2020"
                    ''' <summary>生活保護</summary>
                    Public Const _2021 As String = "2021"
                    ''' <summary>障害者福祉</summary>
                    Public Const _2022 As String = "2022"
                    ''' <summary>介護保険</summary>
                    Public Const _2023 As String = "2023"
                    ''' <summary>国民健康保険</summary>
                    Public Const _2024 As String = "2024"
                    ''' <summary>後期高齢者医療</summary>
                    Public Const _2025 As String = "2025"
                    ''' <summary>国民年金</summary>
                    Public Const _2026 As String = "2026"
                    ''' <summary>児童手当</summary>
                    Public Const _2027 As String = "2027"
                    ''' <summary>子ども・子育て支援</summary>
                    Public Const _2028 As String = "2028"
                    ''' <summary>申請管理</summary>
                    Public Const _2029 As String = "2029"
                    ''' <summary>庁内データ連携</summary>
                    Public Const _2030 As String = "2030"
                    ''' <summary>住登外宛名番号管理</summary>
                    Public Const _2031 As String = "2031"
                    ''' <summary>団体内統合宛名管理</summary>
                    Public Const _2032 As String = "2032"
                    ''' <summary>職員認証</summary>
                    Public Const _2033 As String = "2033"
                    ''' <summary>EUC</summary>
                    Public Const _2034 As String = "2034"
                    ''' <summary>レセプト管理（生保）</summary>
                    Public Const _2035 As String = "2035"
                    ''' <summary>統合収納管理</summary>
                    Public Const _2036 As String = "2036"
                    ''' <summary>統合滞納管理</summary>
                    Public Const _2037 As String = "2037"
                    ''' <summary>住民基本台帳</summary>
                    Public Const _3001 As String = "3001"
                    ''' <summary>個人住民税</summary>
                    Public Const _3010 As String = "3010"
                    ''' <summary>互助防疫</summary>
                    Public Const _3019 As String = "3019"
                End Class

                ''' <summary>
                ''' データ型
                ''' </summary>
                Public Class データ型
                    ''' <summary>整数</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>小数</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>文字</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>日付</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>時間</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>フラグ</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' 連携処理区分
                ''' </summary>
                Public Class 連携処理区分
                    ''' <summary>基幹システム連携</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>中間サーバ連携</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>基本データリスト連携</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' DB変更区分
                ''' </summary>
                Public Class DB変更区分
                    ''' <summary>追加</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>更新</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>削除</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' メッセージ切替区分
                ''' </summary>
                Public Class メッセージ切替区分
                    ''' <summary>エラー</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>アラート</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>非表示</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' ファイルタイプ
                ''' </summary>
                Public Class ファイルタイプ
                    ''' <summary>csv</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>doc</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>jpg</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>jpeg</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>png</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>pdf</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>tif</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>txt</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>xml</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>xls</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>xlsm</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>xlsx</summary>
                    Public Const _12 As String = "12"
                    ''' <summary>zip</summary>
                    Public Const _13 As String = "13"
                End Class

                ''' <summary>
                ''' 性別（システム）
                ''' </summary>
                Public Class 性別_システム
                    ''' <summary>男</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>女</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 処理結果コード
                ''' </summary>
                Public Class 処理結果コード
                    ''' <summary>正常終了</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>異常終了</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要確認</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>処理停止</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>実行中</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 表示色コード
                ''' </summary>
                Public Class 表示色コード
                    ''' <summary>黒</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>青</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>赤</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' フリー項目データタイプ
                ''' </summary>
                Public Class フリー項目データタイプ
                    ''' <summary>数値（整数）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>数値（小数点付き実数）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>数値（符号付き整数）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>半角文字（半角数字）</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>半角文字（半角英数字）</summary>
                    Public Const _12 As String = "12"
                    ''' <summary>半角文字（年）</summary>
                    Public Const _13 As String = "13"
                    ''' <summary>半角文字（年）※不詳あり</summary>
                    Public Const _14 As String = "14"
                    ''' <summary>半角文字（年月）</summary>
                    Public Const _15 As String = "15"
                    ''' <summary>半角文字（年月）※不詳あり</summary>
                    Public Const _16 As String = "16"
                    ''' <summary>半角文字（時刻）</summary>
                    Public Const _17 As String = "17"
                    ''' <summary>半角文字（半角）</summary>
                    Public Const _18 As String = "18"
                    ''' <summary>全角文字（全角）※改行不可</summary>
                    Public Const _21 As String = "21"
                    ''' <summary>全角文字（全角）※改行可</summary>
                    Public Const _22 As String = "22"
                    ''' <summary>全角半角文字（全角半角）※改行不可</summary>
                    Public Const _26 As String = "26"
                    ''' <summary>全角半角文字（全角半角）※改行可</summary>
                    Public Const _27 As String = "27"
                    ''' <summary>日付（年月日）</summary>
                    Public Const _31 As String = "31"
                    ''' <summary>日付（年月日）※不詳あり</summary>
                    Public Const _32 As String = "32"
                    ''' <summary>日時（年月日時分秒）</summary>
                    Public Const _33 As String = "33"
                    ''' <summary>コード（名称マスタ）</summary>
                    Public Const _41 As String = "41"
                    ''' <summary>コード（汎用マスタ）</summary>
                    Public Const _42 As String = "42"
                    ''' <summary>コード（ユーザーマスタ）</summary>
                    Public Const _44 As String = "44"
                    ''' <summary>コード（所属グループマスタ）</summary>
                    Public Const _45 As String = "45"
                    ''' <summary>コード（地区情報マスタ)</summary>
                    Public Const _46 As String = "46"
                    ''' <summary>コード（会場情報マスタ)</summary>
                    Public Const _48 As String = "48"
                    ''' <summary>年齢範囲（抽出専用画面のみ使用可）</summary>
                    Public Const _51 As String = "51"
                    ''' <summary>宛名番号</summary>
                    Public Const _61 As String = "61"
                    ''' <summary>医療機関</summary>
                    Public Const _70 As String = "70"
                    ''' <summary>事業従事者</summary>
                    Public Const _71 As String = "71"
                    ''' <summary>検診実施機関</summary>
                    Public Const _72 As String = "72"
                End Class

                ''' <summary>
                ''' 独自施策項目パターン
                ''' </summary>
                Public Class 独自施策項目パターン
                    ''' <summary>半角</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>全角</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>日付</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>コード</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' ファイルマスタ使用区分
                ''' </summary>
                Public Class ファイルマスタ使用区分
                    ''' <summary>取込設定画面ダウロードテンプレート</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 事業集約コード
                ''' </summary>
                Public Class 事業集約コード
                    ''' <summary>◆全体共通◆</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>共通管理</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>成人保健</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>母子保健</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>予防接種</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 文字コード
                ''' </summary>
                Public Class 文字コード
                    ''' <summary>S-JIS</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>UTF-8（BOM付）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>UTF-8（BOM無）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>UTF-16LE（BOM付）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>UTF-16LE（BOM無）</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>UTF-16BE（BOM付）</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>UTF-16BE（BOM無）</summary>
                    Public Const _7 As String = "7"
                End Class

                ''' <summary>
                ''' 引用符（CSV出力用）
                ''' </summary>
                Public Class 引用符_CSV出力用
                    ''' <summary>なし</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>ダブルコーテーション</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>シングルコーテーション</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>混在パターン</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 共通バー番号（共通機能）
                ''' </summary>
                Public Class 共通バー番号_共通機能
                    ''' <summary>メモ情報</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>電子ファイル情報</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>世帯メモ情報</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>連絡先情報</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>個人照会</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>警告情報照会</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>送付先管理</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>フォロー管理</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>検診・指導履歴</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>料金内訳</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>対象サイン</summary>
                    Public Const _11 As String = "11"
                End Class

                ''' <summary>
                ''' 共通バー表示
                ''' </summary>
                Public Class 共通バー表示
                    ''' <summary>基幹系他システム情報照会-メモ情報</summary>
                    Public Const _AWKK00101G_1 As String = "AWKK00101G-1"
                    ''' <summary>基幹系他システム情報照会-電子ファイル情報</summary>
                    Public Const _AWKK00101G_2 As String = "AWKK00101G-2"
                    ''' <summary>基幹系他システム情報照会-世帯メモ情報</summary>
                    Public Const _AWKK00101G_3 As String = "AWKK00101G-3"
                    ''' <summary>基幹系他システム情報照会-連絡先情報</summary>
                    Public Const _AWKK00101G_4 As String = "AWKK00101G-4"
                    ''' <summary>基幹系他システム情報照会-個人照会</summary>
                    Public Const _AWKK00101G_5 As String = "AWKK00101G-5"
                    ''' <summary>基幹系他システム情報照会-警告情報照会</summary>
                    Public Const _AWKK00101G_6 As String = "AWKK00101G-6"
                    ''' <summary>基幹系他システム情報照会-送付先管理</summary>
                    Public Const _AWKK00101G_7 As String = "AWKK00101G-7"
                    ''' <summary>基幹系他システム情報照会-フォロー管理</summary>
                    Public Const _AWKK00101G_8 As String = "AWKK00101G-8"
                    ''' <summary>基幹系他システム情報照会-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWKK00101G_9 As String = "AWKK00101G-9"
                    ''' <summary>住登外者管理-メモ情報</summary>
                    Public Const _AWKK00111G_1 As String = "AWKK00111G-1"
                    ''' <summary>住登外者管理-電子ファイル情報</summary>
                    Public Const _AWKK00111G_2 As String = "AWKK00111G-2"
                    ''' <summary>住登外者管理-世帯メモ情報</summary>
                    Public Const _AWKK00111G_3 As String = "AWKK00111G-3"
                    ''' <summary>住登外者管理-連絡先情報</summary>
                    Public Const _AWKK00111G_4 As String = "AWKK00111G-4"
                    ''' <summary>住登外者管理-個人照会</summary>
                    Public Const _AWKK00111G_5 As String = "AWKK00111G-5"
                    ''' <summary>住登外者管理-警告情報照会</summary>
                    Public Const _AWKK00111G_6 As String = "AWKK00111G-6"
                    ''' <summary>住登外者管理-送付先管理</summary>
                    Public Const _AWKK00111G_7 As String = "AWKK00111G-7"
                    ''' <summary>住登外者管理-フォロー管理</summary>
                    Public Const _AWKK00111G_8 As String = "AWKK00111G-8"
                    ''' <summary>住登外者管理-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWKK00111G_9 As String = "AWKK00111G-9"
                    ''' <summary>帳票発行対象外者管理-メモ情報</summary>
                    Public Const _AWKK01001G_1 As String = "AWKK01001G-1"
                    ''' <summary>帳票発行対象外者管理-電子ファイル情報</summary>
                    Public Const _AWKK01001G_2 As String = "AWKK01001G-2"
                    ''' <summary>帳票発行対象外者管理-世帯メモ情報</summary>
                    Public Const _AWKK01001G_3 As String = "AWKK01001G-3"
                    ''' <summary>帳票発行対象外者管理-連絡先情報</summary>
                    Public Const _AWKK01001G_4 As String = "AWKK01001G-4"
                    ''' <summary>帳票発行対象外者管理-個人照会</summary>
                    Public Const _AWKK01001G_5 As String = "AWKK01001G-5"
                    ''' <summary>帳票発行対象外者管理-警告情報照会</summary>
                    Public Const _AWKK01001G_6 As String = "AWKK01001G-6"
                    ''' <summary>帳票発行対象外者管理-送付先管理</summary>
                    Public Const _AWKK01001G_7 As String = "AWKK01001G-7"
                    ''' <summary>帳票発行対象外者管理-フォロー管理</summary>
                    Public Const _AWKK01001G_8 As String = "AWKK01001G-8"
                    ''' <summary>帳票発行対象外者管理-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWKK01001G_9 As String = "AWKK01001G-9"
                    ''' <summary>保健指導管理-メモ情報</summary>
                    Public Const _AWKK00301G_1 As String = "AWKK00301G-1"
                    ''' <summary>保健指導管理-電子ファイル情報</summary>
                    Public Const _AWKK00301G_2 As String = "AWKK00301G-2"
                    ''' <summary>保健指導管理-世帯メモ情報</summary>
                    Public Const _AWKK00301G_3 As String = "AWKK00301G-3"
                    ''' <summary>保健指導管理-連絡先情報</summary>
                    Public Const _AWKK00301G_4 As String = "AWKK00301G-4"
                    ''' <summary>保健指導管理-個人照会</summary>
                    Public Const _AWKK00301G_5 As String = "AWKK00301G-5"
                    ''' <summary>保健指導管理-警告情報照会</summary>
                    Public Const _AWKK00301G_6 As String = "AWKK00301G-6"
                    ''' <summary>保健指導管理-送付先管理</summary>
                    Public Const _AWKK00301G_7 As String = "AWKK00301G-7"
                    ''' <summary>保健指導管理-フォロー管理</summary>
                    Public Const _AWKK00301G_8 As String = "AWKK00301G-8"
                    ''' <summary>保健指導管理-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWKK00301G_9 As String = "AWKK00301G-9"
                    ''' <summary>集団指導管理-メモ情報</summary>
                    Public Const _AWKK00303G_1 As String = "AWKK00303G-1"
                    ''' <summary>集団指導管理-電子ファイル情報</summary>
                    Public Const _AWKK00303G_2 As String = "AWKK00303G-2"
                    ''' <summary>集団指導管理-世帯メモ情報</summary>
                    Public Const _AWKK00303G_3 As String = "AWKK00303G-3"
                    ''' <summary>集団指導管理-連絡先情報</summary>
                    Public Const _AWKK00303G_4 As String = "AWKK00303G-4"
                    ''' <summary>集団指導管理-個人照会</summary>
                    Public Const _AWKK00303G_5 As String = "AWKK00303G-5"
                    ''' <summary>集団指導管理-警告情報照会</summary>
                    Public Const _AWKK00303G_6 As String = "AWKK00303G-6"
                    ''' <summary>集団指導管理-送付先管理</summary>
                    Public Const _AWKK00303G_7 As String = "AWKK00303G-7"
                    ''' <summary>集団指導管理-フォロー管理</summary>
                    Public Const _AWKK00303G_8 As String = "AWKK00303G-8"
                    ''' <summary>集団指導管理-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWKK00303G_9 As String = "AWKK00303G-9"
                    ''' <summary>フォロー管理-メモ情報</summary>
                    Public Const _AWKK00401G_1 As String = "AWKK00401G-1"
                    ''' <summary>フォロー管理-電子ファイル情報</summary>
                    Public Const _AWKK00401G_2 As String = "AWKK00401G-2"
                    ''' <summary>フォロー管理-世帯メモ情報</summary>
                    Public Const _AWKK00401G_3 As String = "AWKK00401G-3"
                    ''' <summary>フォロー管理-連絡先情報</summary>
                    Public Const _AWKK00401G_4 As String = "AWKK00401G-4"
                    ''' <summary>フォロー管理-個人照会</summary>
                    Public Const _AWKK00401G_5 As String = "AWKK00401G-5"
                    ''' <summary>フォロー管理-警告情報照会</summary>
                    Public Const _AWKK00401G_6 As String = "AWKK00401G-6"
                    ''' <summary>フォロー管理-送付先管理</summary>
                    Public Const _AWKK00401G_7 As String = "AWKK00401G-7"
                    ''' <summary>フォロー管理-フォロー管理</summary>
                    Public Const _AWKK00401G_8 As String = "AWKK00401G-8"
                    ''' <summary>フォロー管理-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWKK00401G_9 As String = "AWKK00401G-9"
                    ''' <summary>事業実施報告書（日報）管理-メモ情報</summary>
                    Public Const _AWKK00501G_1 As String = "AWKK00501G-1"
                    ''' <summary>事業実施報告書（日報）管理-電子ファイル情報</summary>
                    Public Const _AWKK00501G_2 As String = "AWKK00501G-2"
                    ''' <summary>事業実施報告書（日報）管理-世帯メモ情報</summary>
                    Public Const _AWKK00501G_3 As String = "AWKK00501G-3"
                    ''' <summary>事業実施報告書（日報）管理-連絡先情報</summary>
                    Public Const _AWKK00501G_4 As String = "AWKK00501G-4"
                    ''' <summary>事業実施報告書（日報）管理-個人照会</summary>
                    Public Const _AWKK00501G_5 As String = "AWKK00501G-5"
                    ''' <summary>事業実施報告書（日報）管理-警告情報照会</summary>
                    Public Const _AWKK00501G_6 As String = "AWKK00501G-6"
                    ''' <summary>事業実施報告書（日報）管理-送付先管理</summary>
                    Public Const _AWKK00501G_7 As String = "AWKK00501G-7"
                    ''' <summary>事業実施報告書（日報）管理-フォロー管理</summary>
                    Public Const _AWKK00501G_8 As String = "AWKK00501G-8"
                    ''' <summary>事業実施報告書（日報）管理-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWKK00501G_9 As String = "AWKK00501G-9"
                    ''' <summary>事業予約希望者管理-メモ情報</summary>
                    Public Const _AWKK00902G_1 As String = "AWKK00902G-1"
                    ''' <summary>事業予約希望者管理-世帯メモ情報</summary>
                    Public Const _AWKK00902G_3 As String = "AWKK00902G-3"
                    ''' <summary>事業予約希望者管理-連絡先情報</summary>
                    Public Const _AWKK00902G_4 As String = "AWKK00902G-4"
                    ''' <summary>事業予約希望者管理-個人照会</summary>
                    Public Const _AWKK00902G_5 As String = "AWKK00902G-5"
                    ''' <summary>基本健診-メモ情報</summary>
                    Public Const _AWSH00101G_1 As String = "AWSH00101G-1"
                    ''' <summary>基本健診-電子ファイル情報</summary>
                    Public Const _AWSH00101G_2 As String = "AWSH00101G-2"
                    ''' <summary>基本健診-世帯メモ情報</summary>
                    Public Const _AWSH00101G_3 As String = "AWSH00101G-3"
                    ''' <summary>基本健診-連絡先情報</summary>
                    Public Const _AWSH00101G_4 As String = "AWSH00101G-4"
                    ''' <summary>基本健診-個人照会</summary>
                    Public Const _AWSH00101G_5 As String = "AWSH00101G-5"
                    ''' <summary>基本健診-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWSH00101G_9 As String = "AWSH00101G-9"
                    ''' <summary>肝炎検診-メモ情報</summary>
                    Public Const _AWSH00102G_1 As String = "AWSH00102G-1"
                    ''' <summary>肝炎検診-電子ファイル情報</summary>
                    Public Const _AWSH00102G_2 As String = "AWSH00102G-2"
                    ''' <summary>肝炎検診-世帯メモ情報</summary>
                    Public Const _AWSH00102G_3 As String = "AWSH00102G-3"
                    ''' <summary>肝炎検診-連絡先情報</summary>
                    Public Const _AWSH00102G_4 As String = "AWSH00102G-4"
                    ''' <summary>肝炎検診-個人照会</summary>
                    Public Const _AWSH00102G_5 As String = "AWSH00102G-5"
                    ''' <summary>肝炎検診-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWSH00102G_9 As String = "AWSH00102G-9"
                    ''' <summary>胃がん検診-メモ情報</summary>
                    Public Const _AWSH00103G_1 As String = "AWSH00103G-1"
                    ''' <summary>胃がん検診-電子ファイル情報</summary>
                    Public Const _AWSH00103G_2 As String = "AWSH00103G-2"
                    ''' <summary>胃がん検診-世帯メモ情報</summary>
                    Public Const _AWSH00103G_3 As String = "AWSH00103G-3"
                    ''' <summary>胃がん検診-連絡先情報</summary>
                    Public Const _AWSH00103G_4 As String = "AWSH00103G-4"
                    ''' <summary>胃がん検診-個人照会</summary>
                    Public Const _AWSH00103G_5 As String = "AWSH00103G-5"
                    ''' <summary>胃がん検診-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWSH00103G_9 As String = "AWSH00103G-9"
                    ''' <summary>大腸がん検診-メモ情報</summary>
                    Public Const _AWSH00104G_1 As String = "AWSH00104G-1"
                    ''' <summary>大腸がん検診-電子ファイル情報</summary>
                    Public Const _AWSH00104G_2 As String = "AWSH00104G-2"
                    ''' <summary>大腸がん検診-世帯メモ情報</summary>
                    Public Const _AWSH00104G_3 As String = "AWSH00104G-3"
                    ''' <summary>大腸がん検診-連絡先情報</summary>
                    Public Const _AWSH00104G_4 As String = "AWSH00104G-4"
                    ''' <summary>大腸がん検診-個人照会</summary>
                    Public Const _AWSH00104G_5 As String = "AWSH00104G-5"
                    ''' <summary>大腸がん検診-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWSH00104G_9 As String = "AWSH00104G-9"
                    ''' <summary>肺がん検診-メモ情報</summary>
                    Public Const _AWSH00105G_1 As String = "AWSH00105G-1"
                    ''' <summary>肺がん検診-電子ファイル情報</summary>
                    Public Const _AWSH00105G_2 As String = "AWSH00105G-2"
                    ''' <summary>肺がん検診-世帯メモ情報</summary>
                    Public Const _AWSH00105G_3 As String = "AWSH00105G-3"
                    ''' <summary>肺がん検診-連絡先情報</summary>
                    Public Const _AWSH00105G_4 As String = "AWSH00105G-4"
                    ''' <summary>肺がん検診-個人照会</summary>
                    Public Const _AWSH00105G_5 As String = "AWSH00105G-5"
                    ''' <summary>肺がん検診-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWSH00105G_9 As String = "AWSH00105G-9"
                    ''' <summary>子宮頸がん検診-メモ情報</summary>
                    Public Const _AWSH00106G_1 As String = "AWSH00106G-1"
                    ''' <summary>子宮頸がん検診-電子ファイル情報</summary>
                    Public Const _AWSH00106G_2 As String = "AWSH00106G-2"
                    ''' <summary>子宮頸がん検診-世帯メモ情報</summary>
                    Public Const _AWSH00106G_3 As String = "AWSH00106G-3"
                    ''' <summary>子宮頸がん検診-連絡先情報</summary>
                    Public Const _AWSH00106G_4 As String = "AWSH00106G-4"
                    ''' <summary>子宮頸がん検診-個人照会</summary>
                    Public Const _AWSH00106G_5 As String = "AWSH00106G-5"
                    ''' <summary>子宮頸がん検診-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWSH00106G_9 As String = "AWSH00106G-9"
                    ''' <summary>乳がん-メモ情報</summary>
                    Public Const _AWSH00107G_1 As String = "AWSH00107G-1"
                    ''' <summary>乳がん-電子ファイル情報</summary>
                    Public Const _AWSH00107G_2 As String = "AWSH00107G-2"
                    ''' <summary>乳がん-世帯メモ情報</summary>
                    Public Const _AWSH00107G_3 As String = "AWSH00107G-3"
                    ''' <summary>乳がん-連絡先情報</summary>
                    Public Const _AWSH00107G_4 As String = "AWSH00107G-4"
                    ''' <summary>乳がん-個人照会</summary>
                    Public Const _AWSH00107G_5 As String = "AWSH00107G-5"
                    ''' <summary>乳がん-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWSH00107G_9 As String = "AWSH00107G-9"
                    ''' <summary>骨粗鬆症検診-メモ情報</summary>
                    Public Const _AWSH00108G_1 As String = "AWSH00108G-1"
                    ''' <summary>骨粗鬆症検診-電子ファイル情報</summary>
                    Public Const _AWSH00108G_2 As String = "AWSH00108G-2"
                    ''' <summary>骨粗鬆症検診-世帯メモ情報</summary>
                    Public Const _AWSH00108G_3 As String = "AWSH00108G-3"
                    ''' <summary>骨粗鬆症検診-連絡先情報</summary>
                    Public Const _AWSH00108G_4 As String = "AWSH00108G-4"
                    ''' <summary>骨粗鬆症検診-個人照会</summary>
                    Public Const _AWSH00108G_5 As String = "AWSH00108G-5"
                    ''' <summary>骨粗鬆症検診-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWSH00108G_9 As String = "AWSH00108G-9"
                    ''' <summary>歯周疾患検診-メモ情報</summary>
                    Public Const _AWSH00109G_1 As String = "AWSH00109G-1"
                    ''' <summary>歯周疾患検診-電子ファイル情報</summary>
                    Public Const _AWSH00109G_2 As String = "AWSH00109G-2"
                    ''' <summary>歯周疾患検診-世帯メモ情報</summary>
                    Public Const _AWSH00109G_3 As String = "AWSH00109G-3"
                    ''' <summary>歯周疾患検診-連絡先情報</summary>
                    Public Const _AWSH00109G_4 As String = "AWSH00109G-4"
                    ''' <summary>歯周疾患検診-個人照会</summary>
                    Public Const _AWSH00109G_5 As String = "AWSH00109G-5"
                    ''' <summary>歯周疾患検診-健（検）診結果・保健指導履歴照会</summary>
                    Public Const _AWSH00109G_9 As String = "AWSH00109G-9"
                    ''' <summary>健（検）診予約希望者管理-メモ情報</summary>
                    Public Const _AWSH00402G_1 As String = "AWSH00402G-1"
                    ''' <summary>健（検）診予約希望者管理-世帯メモ情報</summary>
                    Public Const _AWSH00402G_3 As String = "AWSH00402G-3"
                    ''' <summary>健（検）診予約希望者管理-連絡先情報</summary>
                    Public Const _AWSH00402G_4 As String = "AWSH00402G-4"
                    ''' <summary>健（検）診予約希望者管理-個人照会</summary>
                    Public Const _AWSH00402G_5 As String = "AWSH00402G-5"
                End Class

                ''' <summary>
                ''' 処理一覧（ログ画面用）
                ''' </summary>
                Public Class 処理一覧_ログ画面用
                    ''' <summary>乳がん検診結果管理-検索処理</summary>
                    Public Const _AWSH00101G_Search As String = "AWSH00101G-Search"
                    ''' <summary>乳がん検診結果管理-初期化処理</summary>
                    Public Const _AWSH00101G_Init As String = "AWSH00101G-Init"
                    ''' <summary>乳がん検診結果管理-保存処理</summary>
                    Public Const _AWSH00101G_Save As String = "AWSH00101G-Save"
                    ''' <summary>乳がん検診結果管理-削除処理</summary>
                    Public Const _AWSH00101G_Delete As String = "AWSH00101G-Delete"
                    ''' <summary>乳がん検診結果管理-基準値取得処理</summary>
                    Public Const _AWSH00101G_GetKijun As String = "AWSH00101G-GetKijun"
                End Class

                ''' <summary>
                ''' 指定コード長さ
                ''' </summary>
                Public Class 指定コード長さ
                    ''' <summary>宛名番号</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>医療機関コード</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 詳細条件コントローラー
                ''' </summary>
                Public Class 詳細条件コントローラー
                    ''' <summary>通用項目</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>年齢/生年月日</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>一覧選択</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>参照ダイアログ</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 一覧テーブル区分
                ''' </summary>
                Public Class 一覧テーブル区分
                    ''' <summary>名称マスタ</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>汎用マスタ</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>医療機関マスタ</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>ユーザーマスタ</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>所属グループマスタ</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>市区町村マスタ</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>地区情報マスタ</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>会場情報マスタ</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>事業従事者担当者情報マスタ</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 画面項目入力コントローラー
                ''' </summary>
                Public Class 画面項目入力コントローラー
                    ''' <summary>増減入力、自由入力</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>テキスト</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>日付（年、年月、年月日、時刻）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>プルダウンリスト</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>検索ダイアログ画面</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>プルダウン+検索ダイアログ</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' 住登区分
                ''' </summary>
                Public Class 住登区分
                    ''' <summary>住民情報</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>住登外情報</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 連携方式
                ''' </summary>
                Public Class 連携方式
                    ''' <summary>CSV</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>API</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 連絡先タブ区分
                ''' </summary>
                Public Class 連絡先タブ区分
                    ''' <summary>妊娠届出情報</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>出生時状況</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>他市町村・医療機関等への接種依頼</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>健康被害救済制度情報</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>その他</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 年号情報
                ''' </summary>
                Public Class 年号情報
                    ''' <summary>明治</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>大正</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>昭和</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>平成</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>令和</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' ログ区分
                ''' </summary>
                Public Class ログ区分
                    ''' <summary>通信ログ</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>バッチログ</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>連携ログ</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 連携方向区分
                ''' </summary>
                Public Class 連携方向区分
                    ''' <summary>他システムから取得</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>他システムへ出力</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 操作処理区分
                ''' </summary>
                Public Class 操作処理区分
                    ''' <summary>追加</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>更新</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>削除</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>検索</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 住民区分
                ''' </summary>
                Public Class 住民区分
                    ''' <summary>住民</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>外国人</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>住登外</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>除票</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>住登外除票</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' 住民区分設定
                ''' </summary>
                Public Class 住民区分設定
                    ''' <summary>住民情報-日本人住民-住登者</summary>
                    Public Const _111 As String = "111"
                    ''' <summary>住民情報-日本人住民-転出者</summary>
                    Public Const _112 As String = "112"
                    ''' <summary>住民情報-日本人住民-死亡者</summary>
                    Public Const _113 As String = "113"
                    ''' <summary>住民情報-日本人住民-その他消除者</summary>
                    Public Const _119 As String = "119"
                    ''' <summary>住民情報-外国人住民-住登者</summary>
                    Public Const _121 As String = "121"
                    ''' <summary>住民情報-外国人住民-転出者</summary>
                    Public Const _122 As String = "122"
                    ''' <summary>住民情報-外国人住民-死亡者</summary>
                    Public Const _123 As String = "123"
                    ''' <summary>住民情報-外国人住民-その他消除者</summary>
                    Public Const _129 As String = "129"
                    ''' <summary>住登外情報-日本人住民-住登者</summary>
                    Public Const _211 As String = "211"
                    ''' <summary>住登外情報-日本人住民-転出者</summary>
                    Public Const _212 As String = "212"
                    ''' <summary>住登外情報-日本人住民-死亡者</summary>
                    Public Const _213 As String = "213"
                    ''' <summary>住登外情報-日本人住民-その他消除者</summary>
                    Public Const _219 As String = "219"
                    ''' <summary>住登外情報-外国人住民-住登者</summary>
                    Public Const _221 As String = "221"
                    ''' <summary>住登外情報-外国人住民-転出者</summary>
                    Public Const _222 As String = "222"
                    ''' <summary>住登外情報-外国人住民-死亡者</summary>
                    Public Const _223 As String = "223"
                    ''' <summary>住登外情報-外国人住民-その他消除者</summary>
                    Public Const _229 As String = "229"
                End Class

                ''' <summary>
                ''' 停止フラグ
                ''' </summary>
                Public Class 停止フラグ
                    ''' <summary>使用中</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>停止</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 最新フラグ
                ''' </summary>
                Public Class 最新フラグ
                    ''' <summary>最新</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>非最新</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 拡事業業務
                ''' </summary>
                Public Class 拡事業業務
                    ''' <summary>共通管理</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>成人保健</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 拡事業種類
                ''' </summary>
                Public Class 拡事業種類
                    ''' <summary>成人健（検）診予約日程事業</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>その他予約日程事業・保健指導事業</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>保健指導・集団指導項目</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>成人健（検）診事業</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 事業区分
                ''' </summary>
                Public Class 事業区分
                    ''' <summary>基本事業</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>市町村拡事業</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 項目区分
                ''' </summary>
                Public Class 項目区分
                    ''' <summary>PKG標準項目拡領域不使用</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>PKG標準項目拡領域使用</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>市区町村独自項目</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 項目配置区分
                ''' </summary>
                Public Class 項目配置区分
                    ''' <summary>右</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>左</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 各種事業コード設定対象
                ''' </summary>
                Public Class 各種事業コード設定対象
                    ''' <summary>基本健診</summary>
                    Public Const _AWSH00101G As String = "AWSH00101G"
                    ''' <summary>肝炎検診</summary>
                    Public Const _AWSH00102G As String = "AWSH00102G"
                    ''' <summary>胃がん検診</summary>
                    Public Const _AWSH00103G As String = "AWSH00103G"
                    ''' <summary>大腸がん検診</summary>
                    Public Const _AWSH00104G As String = "AWSH00104G"
                    ''' <summary>肺がん検診</summary>
                    Public Const _AWSH00105G As String = "AWSH00105G"
                    ''' <summary>子宮頸がん検診</summary>
                    Public Const _AWSH00106G As String = "AWSH00106G"
                    ''' <summary>乳がん</summary>
                    Public Const _AWSH00107G As String = "AWSH00107G"
                    ''' <summary>骨粗鬆症検診</summary>
                    Public Const _AWSH00108G As String = "AWSH00108G"
                    ''' <summary>歯周疾患検診</summary>
                    Public Const _AWSH00109G As String = "AWSH00109G"
                    ''' <summary>事業予約希望者管理（母子）</summary>
                    Public Const _AWKK00902G_1 As String = "AWKK00902G-1"
                    ''' <summary>事業予約希望者管理（成人）</summary>
                    Public Const _AWKK00902G_2 As String = "AWKK00902G-2"
                    ''' <summary>事業予約希望者管理（予約）</summary>
                    Public Const _AWKK00902G_3 As String = "AWKK00902G-3"
                    ''' <summary>健（検）診予約希望者管理</summary>
                    Public Const _AWSH00402G As String = "AWSH00402G"
                    ''' <summary>保健指導管理（母子）</summary>
                    Public Const _AWKK00301G_1 As String = "AWKK00301G-1"
                    ''' <summary>保健指導管理（成人）</summary>
                    Public Const _AWKK00301G_2 As String = "AWKK00301G-2"
                    ''' <summary>集団指導管理（母子）</summary>
                    Public Const _AWKK00303G_1 As String = "AWKK00303G-1"
                    ''' <summary>集団指導管理（成人）</summary>
                    Public Const _AWKK00303G_2 As String = "AWKK00303G-2"
                End Class

                ''' <summary>
                ''' 前回処理結果
                ''' </summary>
                Public Class 前回処理結果
                    ''' <summary>準備完了</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>実行中</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>正常終了</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>異常終了</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' モジュール
                ''' </summary>
                Public Class モジュール
                    ''' <summary>モジュール</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 月
                ''' </summary>
                Public Class 月
                    ''' <summary>1月</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>2月</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>3月</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>4月</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>5月</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>6月</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>7月</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>8月</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>9月</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>10月</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>11月</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>12月</summary>
                    Public Const _12 As String = "12"
                End Class

                ''' <summary>
                ''' 日
                ''' </summary>
                Public Class 日
                    ''' <summary>1</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>2</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>3</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>4</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>5</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>6</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>7</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>8</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>9</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>10</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>11</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>12</summary>
                    Public Const _12 As String = "12"
                    ''' <summary>13</summary>
                    Public Const _13 As String = "13"
                    ''' <summary>14</summary>
                    Public Const _14 As String = "14"
                    ''' <summary>15</summary>
                    Public Const _15 As String = "15"
                    ''' <summary>16</summary>
                    Public Const _16 As String = "16"
                    ''' <summary>17</summary>
                    Public Const _17 As String = "17"
                    ''' <summary>18</summary>
                    Public Const _18 As String = "18"
                    ''' <summary>19</summary>
                    Public Const _19 As String = "19"
                    ''' <summary>20</summary>
                    Public Const _20 As String = "20"
                    ''' <summary>21</summary>
                    Public Const _21 As String = "21"
                    ''' <summary>22</summary>
                    Public Const _22 As String = "22"
                    ''' <summary>23</summary>
                    Public Const _23 As String = "23"
                    ''' <summary>24</summary>
                    Public Const _24 As String = "24"
                    ''' <summary>25</summary>
                    Public Const _25 As String = "25"
                    ''' <summary>26</summary>
                    Public Const _26 As String = "26"
                    ''' <summary>27</summary>
                    Public Const _27 As String = "27"
                    ''' <summary>28</summary>
                    Public Const _28 As String = "28"
                    ''' <summary>29</summary>
                    Public Const _29 As String = "29"
                    ''' <summary>30</summary>
                    Public Const _30 As String = "30"
                    ''' <summary>31</summary>
                    Public Const _31 As String = "31"
                    ''' <summary>最終</summary>
                    Public Const _32 As String = "32"
                End Class

                ''' <summary>
                ''' 週目
                ''' </summary>
                Public Class 週目
                    ''' <summary>第１</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>第２</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>第３</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>第４</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>最終</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 曜日
                ''' </summary>
                Public Class 曜日
                    ''' <summary>日曜日</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>月曜日</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>火曜日</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>水曜日</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>木曜日</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>金曜日</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>土曜日</summary>
                    Public Const _7 As String = "7"
                End Class

                ''' <summary>
                ''' 繰り返し間隔
                ''' </summary>
                Public Class 繰り返し間隔
                    ''' <summary>5分間</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>10分間</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>15分間</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>30分間</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>1時間</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 継続時間
                ''' </summary>
                Public Class 継続時間
                    ''' <summary>無期限</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>15分間</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>30分間</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>1時間</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>12時間</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>1日間</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 頻度区分
                ''' </summary>
                Public Class 頻度区分
                    ''' <summary>一回のみ</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>毎日</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>毎週</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>毎月</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 状態（バッチ）
                ''' </summary>
                Public Class 状態_バッチ
                    ''' <summary>有効</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>無効</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>未登録</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 使用停止フラグ（バッチ）
                ''' </summary>
                Public Class 使用停止フラグ_バッチ
                    ''' <summary>停止しない</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>停止</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 連携区分
                ''' </summary>
                Public Class 連携区分
                    ''' <summary>全件連携</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>差分連携</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' システム区分
                ''' </summary>
                Public Class システム区分
                    ''' <summary>標準準拠システム</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>独自施策システム等</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 入出力区分
                ''' </summary>
                Public Class 入出力区分
                    ''' <summary>入力</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>出力</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 連携先
                ''' </summary>
                Public Class 連携先
                    ''' <summary>住民基本台帳</summary>
                    Public Const _001 As String = "001"
                    ''' <summary>印鑑登録</summary>
                    Public Const _002 As String = "002"
                    ''' <summary>戸籍</summary>
                    Public Const _003 As String = "003"
                    ''' <summary>戸籍附票</summary>
                    Public Const _004 As String = "004"
                    ''' <summary>選挙（共通）</summary>
                    Public Const _005 As String = "005"
                    ''' <summary>選挙人名簿管理</summary>
                    Public Const _006 As String = "006"
                    ''' <summary>期日前・不在者投票管理</summary>
                    Public Const _007 As String = "007"
                    ''' <summary>当日投票管理</summary>
                    Public Const _008 As String = "008"
                    ''' <summary>在外選挙管理</summary>
                    Public Const _009 As String = "009"
                    ''' <summary>個人住民税</summary>
                    Public Const _010 As String = "010"
                    ''' <summary>法人住民税</summary>
                    Public Const _011 As String = "011"
                    ''' <summary>固定資産税</summary>
                    Public Const _012 As String = "012"
                    ''' <summary>軽自動車税</summary>
                    Public Const _013 As String = "013"
                    ''' <summary>収納管理（税務システム</summary>
                    Public Const _014 As String = "014"
                    ''' <summary>滞納管理（税務システム</summary>
                    Public Const _015 As String = "015"
                    ''' <summary>地方税（共通）</summary>
                    Public Const _016 As String = "016"
                    ''' <summary>学齢簿編製</summary>
                    Public Const _017 As String = "017"
                    ''' <summary>就学援助</summary>
                    Public Const _018 As String = "018"
                    ''' <summary>互助防疫</summary>
                    Public Const _019 As String = "019"
                    ''' <summary>児童扶養手当</summary>
                    Public Const _020 As String = "020"
                    ''' <summary>生活保護</summary>
                    Public Const _021 As String = "021"
                    ''' <summary>障害者福祉</summary>
                    Public Const _022 As String = "022"
                    ''' <summary>介護保険</summary>
                    Public Const _023 As String = "023"
                    ''' <summary>国民健康保険</summary>
                    Public Const _024 As String = "024"
                    ''' <summary>後期高齢者医療</summary>
                    Public Const _025 As String = "025"
                    ''' <summary>国民年金</summary>
                    Public Const _026 As String = "026"
                    ''' <summary>児童手当</summary>
                    Public Const _027 As String = "027"
                    ''' <summary>子ども・子育て支援</summary>
                    Public Const _028 As String = "028"
                    ''' <summary>人口動態調査</summary>
                    Public Const _038 As String = "038"
                    ''' <summary>火葬等許可</summary>
                    Public Const _039 As String = "039"
                End Class

                ''' <summary>
                ''' チェック区分
                ''' </summary>
                Public Class チェック区分
                    ''' <summary>チェック無し</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>必須チェック</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>キー項目チェック</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>桁数チェック</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>フォーマットチェック</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>マスタチェック</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 変換区分
                ''' </summary>
                Public Class 変換区分
                    ''' <summary>変換無し</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>固定値</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>関数変換</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>コード変換</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' エラーレベル（連携）
                ''' </summary>
                Public Class エラーレベル_連携
                    ''' <summary>エラー</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>ワーニング</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' ジョブステータス
                ''' </summary>
                Public Class ジョブステータス
                    ''' <summary>実行中</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>正常終了</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>異常終了</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 性別（システム共有）
                ''' </summary>
                Public Class 性別_システム共有
                    ''' <summary>不明（未記入）</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>男</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>女</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' フリー項目特定区分
                ''' </summary>
                Public Class フリー項目特定区分
                    ''' <summary>一次検診結果1</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>一次検診結果2</summary>
                    Public Const _02 As String = "02"
                End Class

                ''' <summary>
                ''' 年度範囲区分
                ''' </summary>
                Public Class 年度範囲区分
                    ''' <summary>システム日付の年度</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>システム日付の年度+1</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>成人保健年度</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 計算区分
                ''' </summary>
                Public Class 計算区分
                    ''' <summary>数式計算</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>内部関数</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>DB関数</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 計算関数（内部）
                ''' </summary>
                Public Class 計算関数_内部
                    ''' <summary>testc</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' グループ（基本データリスト）
                ''' </summary>
                Public Class グループ_基本データリスト
                    ''' <summary>住登外者情報</summary>
                    Public Const _019001 As String = "019001"
                    ''' <summary>個人番号管理</summary>
                    Public Const _019002 As String = "019002"
                    ''' <summary>医療機関情報</summary>
                    Public Const _019003 As String = "019003"
                    ''' <summary>会場情報</summary>
                    Public Const _019004 As String = "019004"
                    ''' <summary>事業従事者（担当者）情報</summary>
                    Public Const _019005 As String = "019005"
                    ''' <summary>地区管理</summary>
                    Public Const _019006 As String = "019006"
                    ''' <summary>事業予定</summary>
                    Public Const _019007 As String = "019007"
                    ''' <summary>個人連絡先</summary>
                    Public Const _019008 As String = "019008"
                    ''' <summary>送付先情報</summary>
                    Public Const _019009 As String = "019009"
                    ''' <summary>健（検）診予約希望者管理</summary>
                    Public Const _019010 As String = "019010"
                    ''' <summary>帳票発送履歴情報</summary>
                    Public Const _019011 As String = "019011"
                    ''' <summary>帳票発行対象外者情報</summary>
                    Public Const _019012 As String = "019012"
                    ''' <summary>メモ情報</summary>
                    Public Const _019013 As String = "019013"
                    ''' <summary>フォロー状況情報</summary>
                    Public Const _019014 As String = "019014"
                    ''' <summary>実施報告書（日報）情報</summary>
                    Public Const _019015 As String = "019015"
                    ''' <summary>伝言情報</summary>
                    Public Const _019016 As String = "019016"
                    ''' <summary>メモ情報（世帯）</summary>
                    Public Const _019017 As String = "019017"
                    ''' <summary>電子ファイル情報</summary>
                    Public Const _019018 As String = "019018"
                    ''' <summary>希望調査結果</summary>
                    Public Const _019019 As String = "019019"
                    ''' <summary>胃がん一次検診</summary>
                    Public Const _019020 As String = "019020"
                    ''' <summary>胃がん精密検査</summary>
                    Public Const _019021 As String = "019021"
                    ''' <summary>肺がん一次検診</summary>
                    Public Const _019022 As String = "019022"
                    ''' <summary>肺がん精密検査</summary>
                    Public Const _019023 As String = "019023"
                    ''' <summary>子宮頸がん一次検診</summary>
                    Public Const _019024 As String = "019024"
                    ''' <summary>子宮頸がん精密検査</summary>
                    Public Const _019025 As String = "019025"
                    ''' <summary>骨粗鬆症一次検診</summary>
                    Public Const _019026 As String = "019026"
                    ''' <summary>骨粗鬆症精密検査</summary>
                    Public Const _019027 As String = "019027"
                    ''' <summary>歯周疾患一次検診</summary>
                    Public Const _019028 As String = "019028"
                    ''' <summary>歯周疾患検診精密検査</summary>
                    Public Const _019029 As String = "019029"
                    ''' <summary>大腸がん一次検診</summary>
                    Public Const _019030 As String = "019030"
                    ''' <summary>大腸がん精密検査</summary>
                    Public Const _019031 As String = "019031"
                    ''' <summary>乳がん一次検診</summary>
                    Public Const _019032 As String = "019032"
                    ''' <summary>乳がん精密検査</summary>
                    Public Const _019033 As String = "019033"
                    ''' <summary>肝炎ウイルス一次検診</summary>
                    Public Const _019034 As String = "019034"
                    ''' <summary>肝炎ウイルス精密検査</summary>
                    Public Const _019035 As String = "019035"
                    ''' <summary>成人保健_独自施策情報（一次）</summary>
                    Public Const _019036 As String = "019036"
                    ''' <summary>成人保健_独自施策情報（精検）</summary>
                    Public Const _019037 As String = "019037"
                    ''' <summary>成人保健_訪問申込情報</summary>
                    Public Const _019038 As String = "019038"
                    ''' <summary>成人保健_訪問結果情報</summary>
                    Public Const _019039 As String = "019039"
                    ''' <summary>成人保健_個別指導申込情報</summary>
                    Public Const _019040 As String = "019040"
                    ''' <summary>成人保健_個別指導結果情報</summary>
                    Public Const _019041 As String = "019041"
                    ''' <summary>成人保健_集団指導申込情報</summary>
                    Public Const _019042 As String = "019042"
                    ''' <summary>成人保健_集団指導結果情報</summary>
                    Public Const _019043 As String = "019043"
                    ''' <summary>妊娠届出情報</summary>
                    Public Const _019044 As String = "019044"
                    ''' <summary>妊娠届出アンケート</summary>
                    Public Const _019045 As String = "019045"
                    ''' <summary>母子健康手帳交付情報</summary>
                    Public Const _019046 As String = "019046"
                    ''' <summary>出産の状態に係る情報</summary>
                    Public Const _019047 As String = "019047"
                    ''' <summary>妊婦健診結果</summary>
                    Public Const _019048 As String = "019048"
                    ''' <summary>妊婦健診費用助成</summary>
                    Public Const _019049 As String = "019049"
                    ''' <summary>妊産婦歯科健診結果</summary>
                    Public Const _019050 As String = "019050"
                    ''' <summary>妊産婦歯科精健結果</summary>
                    Public Const _019051 As String = "019051"
                    ''' <summary>妊婦精健結果</summary>
                    Public Const _019052 As String = "019052"
                    ''' <summary>産婦健診結果</summary>
                    Public Const _019053 As String = "019053"
                    ''' <summary>産婦健診費用助成</summary>
                    Public Const _019054 As String = "019054"
                    ''' <summary>産婦精密健診結果</summary>
                    Public Const _019055 As String = "019055"
                    ''' <summary>産後ケア事業情報</summary>
                    Public Const _019056 As String = "019056"
                    ''' <summary>出生時状況</summary>
                    Public Const _019057 As String = "019057"
                    ''' <summary>新生児聴覚検査結果</summary>
                    Public Const _019058 As String = "019058"
                    ''' <summary>新生児聴覚スクリーニング検査費用助成</summary>
                    Public Const _019059 As String = "019059"
                    ''' <summary>乳幼児健診対象者</summary>
                    Public Const _019060 As String = "019060"
                    ''' <summary>3～4か月児健診結果</summary>
                    Public Const _019061 As String = "019061"
                    ''' <summary>3～4か月児健診アンケート</summary>
                    Public Const _019062 As String = "019062"
                    ''' <summary>1歳6か月児健診結果</summary>
                    Public Const _019063 As String = "019063"
                    ''' <summary>1歳6か月児健診アンケート</summary>
                    Public Const _019064 As String = "019064"
                    ''' <summary>1歳6か月児歯科健診結果</summary>
                    Public Const _019065 As String = "019065"
                    ''' <summary>3歳児健診結果</summary>
                    Public Const _019066 As String = "019066"
                    ''' <summary>3歳児健診アンケート</summary>
                    Public Const _019067 As String = "019067"
                    ''' <summary>3歳児歯科健診結果</summary>
                    Public Const _019068 As String = "019068"
                    ''' <summary>母子保健_独自施策情報（母）</summary>
                    Public Const _019069 As String = "019069"
                    ''' <summary>母子保健_独自施策情報（子）</summary>
                    Public Const _019070 As String = "019070"
                    ''' <summary>健診受診履歴</summary>
                    Public Const _019071 As String = "019071"
                    ''' <summary>精密健診の依頼</summary>
                    Public Const _019072 As String = "019072"
                    ''' <summary>乳幼児精密健診結果</summary>
                    Public Const _019073 As String = "019073"
                    ''' <summary>未受診者勧奨情報</summary>
                    Public Const _019074 As String = "019074"
                    ''' <summary>母子保健_訪問申込情報</summary>
                    Public Const _019075 As String = "019075"
                    ''' <summary>母子保健_訪問結果情報</summary>
                    Public Const _019076 As String = "019076"
                    ''' <summary>母子保健_個別指導申込情報</summary>
                    Public Const _019077 As String = "019077"
                    ''' <summary>母子保健_個別指導結果情報</summary>
                    Public Const _019078 As String = "019078"
                    ''' <summary>母子保健_集団指導申込情報</summary>
                    Public Const _019079 As String = "019079"
                    ''' <summary>母子保健_集団指導結果情報</summary>
                    Public Const _019080 As String = "019080"
                    ''' <summary>予診票発行情報</summary>
                    Public Const _019083 As String = "019083"
                    ''' <summary>他市町村・医療機関等への接種依頼</summary>
                    Public Const _019084 As String = "019084"
                    ''' <summary>各種予防接種の接種実績</summary>
                    Public Const _019085 As String = "019085"
                    ''' <summary>風疹抗体検査実績</summary>
                    Public Const _019086 As String = "019086"
                    ''' <summary>罹患情報</summary>
                    Public Const _019088 As String = "019088"
                    ''' <summary>住登外者宛名基本情報</summary>
                    Public Const _019089 As String = "019089"
                End Class

                ''' <summary>
                ''' 保険区分（共通管理）
                ''' </summary>
                Public Class 保険区分_共通管理
                    ''' <summary>国保</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>後期</summary>
                    Public Const _20 As String = "20"
                    ''' <summary>生保</summary>
                    Public Const _30 As String = "30"
                End Class

                ''' <summary>
                ''' 申込結果区分
                ''' </summary>
                Public Class 申込結果区分
                    ''' <summary>申込</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>結果</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 指導区分
                ''' </summary>
                Public Class 指導区分
                    ''' <summary>訪問指導</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>個別指導</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>集団指導</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' フリー項目用途区分
                ''' </summary>
                Public Class フリー項目用途区分
                    ''' <summary>集団指導事業用</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>集団指導参加者用</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' コース区分
                ''' </summary>
                Public Class コース区分
                    ''' <summary>日程</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>コース</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 取込区分
                ''' </summary>
                Public Class 取込区分
                    ''' <summary>ファイル取込</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>一括入力</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 登録区分
                ''' </summary>
                Public Class 登録区分
                    ''' <summary>削除→追加</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>追加</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>更新</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' ファイル形式
                ''' </summary>
                Public Class ファイル形式
                    ''' <summary>CSVファイル</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>テキストファイル</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>XMLファイル(後日別機能)</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' エンコード
                ''' </summary>
                Public Class エンコード
                    ''' <summary>S-JIS</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>UNICODE(UTF-8)</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>UNICODE(UTF-16)</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' データ形式
                ''' </summary>
                Public Class データ形式
                    ''' <summary>可変長</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>固定長</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' コード管理テーブル
                ''' </summary>
                Public Class コード管理テーブル
                    ''' <summary>汎用マスタ</summary>
                    Public Const _tm_afhanyo As String = "tm_afhanyo"
                    ''' <summary>名称マスタ</summary>
                    Public Const _tm_afmeisyo As String = "tm_afmeisyo"
                End Class

                ''' <summary>
                ''' 区切り記号
                ''' </summary>
                Public Class 区切り記号
                    ''' <summary>カンマ</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>タブ</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' フォーマット（日付）
                ''' </summary>
                Public Class フォーマット_日付
                    ''' <summary>ggy年</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>ggyy年</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>gy</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>gyy</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>yy</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>yyyy</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>yyyy年</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>ggy年M月</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>ggyy年MM月</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>gy.M</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>gyy.MM</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>yyMM</summary>
                    Public Const _12 As String = "12"
                    ''' <summary>yyyy年M月</summary>
                    Public Const _13 As String = "13"
                    ''' <summary>yyyy年MM月</summary>
                    Public Const _14 As String = "14"
                    ''' <summary>yyyy/M</summary>
                    Public Const _15 As String = "15"
                    ''' <summary>yyyy/MM</summary>
                    Public Const _16 As String = "16"
                    ''' <summary>yyyyMM</summary>
                    Public Const _17 As String = "17"
                    ''' <summary>ggy年M月d日</summary>
                    Public Const _18 As String = "18"
                    ''' <summary>ggyy年MM月dd日</summary>
                    Public Const _19 As String = "19"
                    ''' <summary>gy.M.d</summary>
                    Public Const _20 As String = "20"
                    ''' <summary>gyy.MM.dd</summary>
                    Public Const _21 As String = "21"
                    ''' <summary>yyMMdd</summary>
                    Public Const _22 As String = "22"
                    ''' <summary>yyyy年M月d日</summary>
                    Public Const _23 As String = "23"
                    ''' <summary>yyyy年MM月dd日</summary>
                    Public Const _24 As String = "24"
                    ''' <summary>yyyy/M/d</summary>
                    Public Const _25 As String = "25"
                    ''' <summary>yyyy/MM/dd</summary>
                    Public Const _26 As String = "26"
                    ''' <summary>yyyyMMdd</summary>
                    Public Const _27 As String = "27"
                    ''' <summary>ggy年M月d日 H時m分s秒</summary>
                    Public Const _28 As String = "28"
                    ''' <summary>ggyy年MM月dd日 HH時mm分ss秒</summary>
                    Public Const _29 As String = "29"
                    ''' <summary>gy.M.d H:m:s</summary>
                    Public Const _30 As String = "30"
                    ''' <summary>gyy.MM.dd HH:mm:ss</summary>
                    Public Const _31 As String = "31"
                    ''' <summary>yyyy年M月d日 H時m分s秒</summary>
                    Public Const _32 As String = "32"
                    ''' <summary>yyyy年MM月dd日 HH時mm分ss秒</summary>
                    Public Const _33 As String = "33"
                    ''' <summary>yyyy/M/d H:m:s</summary>
                    Public Const _34 As String = "34"
                    ''' <summary>yyyy/MM/dd HH:mm:ss</summary>
                    Public Const _35 As String = "35"
                    ''' <summary>yyyyMMddHHmmss</summary>
                    Public Const _36 As String = "36"
                    ''' <summary>その他</summary>
                    Public Const _99 As String = "99"
                End Class

                ''' <summary>
                ''' 項目特定区分
                ''' </summary>
                Public Class 項目特定区分
                    ''' <summary>宛名番号</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>氏名</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>実施日（一次・申込）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>実施日（精密・結果）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>生年月日</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>実施年齢（一次・申込）</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>実施年齢（精密・結果）</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>実施年度（一次・申込）</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>実施年度（精密・結果）</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>性別</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>検診実施機関番号</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>医療機関コード</summary>
                    Public Const _12 As String = "12"
                    ''' <summary>医療機関名</summary>
                    Public Const _13 As String = "13"
                    ''' <summary>会場コード</summary>
                    Public Const _14 As String = "14"
                    ''' <summary>会場名</summary>
                    Public Const _15 As String = "15"
                End Class

                ''' <summary>
                ''' マッピング区分
                ''' </summary>
                Public Class マッピング区分
                    ''' <summary>マッピングなし</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>関数</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>単一項目移送</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' マッピング方法
                ''' </summary>
                Public Class マッピング方法
                    ''' <summary>宛名番号取得（引数順：カナ氏名、性別、生年月日）</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>医療機関コード取得（引数順：医療機関名）</summary>
                    Public Const _12 As String = "12"
                    ''' <summary>実施年度取得（引数順：検診日、開始日区分（0:4/1 1:4/2））</summary>
                    Public Const _13 As String = "13"
                    ''' <summary>桁数指定</summary>
                    Public Const _21 As String = "21"
                End Class

                ''' <summary>
                ''' 入力区分
                ''' </summary>
                Public Class 入力区分
                    ''' <summary>テキスト</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>コード系</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>画面検索</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>マスタ参照</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>プルダウンリスト</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>関数</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>プルダウン+画面検索</summary>
                    Public Const _7 As String = "7"
                End Class

                ''' <summary>
                ''' 入力方法
                ''' </summary>
                Public Class 入力方法
                    ''' <summary>数値（整数）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>数値（小数点付き実数）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>数値（符号付き整数）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>半角文字（半角数字）</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>半角文字（半角英数字）</summary>
                    Public Const _12 As String = "12"
                    ''' <summary>半角文字（年）</summary>
                    Public Const _13 As String = "13"
                    ''' <summary>半角文字（年）※不詳あり</summary>
                    Public Const _14 As String = "14"
                    ''' <summary>半角文字（年月）</summary>
                    Public Const _15 As String = "15"
                    ''' <summary>半角文字（年月）※不詳あり</summary>
                    Public Const _16 As String = "16"
                    ''' <summary>半角文字（時刻）</summary>
                    Public Const _17 As String = "17"
                    ''' <summary>半角文字（半角）</summary>
                    Public Const _18 As String = "18"
                    ''' <summary>全角文字（全角）※改行不可</summary>
                    Public Const _21 As String = "21"
                    ''' <summary>全角文字（全角）※改行可</summary>
                    Public Const _22 As String = "22"
                    ''' <summary>全角半角文字（全角半角）※改行不可</summary>
                    Public Const _26 As String = "26"
                    ''' <summary>全角半角文字（全角半角）※改行可</summary>
                    Public Const _27 As String = "27"
                    ''' <summary>日付（年月日）</summary>
                    Public Const _31 As String = "31"
                    ''' <summary>日付（年月日）※不詳あり</summary>
                    Public Const _32 As String = "32"
                    ''' <summary>日時（年月日時分秒）</summary>
                    Public Const _33 As String = "33"
                    ''' <summary>コード（ユーザーマスタ）</summary>
                    Public Const _44 As String = "44"
                    ''' <summary>コード（所属グループマスタ）</summary>
                    Public Const _45 As String = "45"
                    ''' <summary>コード（地区情報マスタ)</summary>
                    Public Const _46 As String = "46"
                    ''' <summary>コード（会場情報マスタ)</summary>
                    Public Const _48 As String = "48"
                    ''' <summary>宛名番号</summary>
                    Public Const _61 As String = "61"
                    ''' <summary>医療機関</summary>
                    Public Const _70 As String = "70"
                    ''' <summary>事業従事者</summary>
                    Public Const _71 As String = "71"
                    ''' <summary>検診実施機関</summary>
                    Public Const _72 As String = "72"
                    ''' <summary>【例】年齢計算（引数順：検診日、生年月日）</summary>
                    Public Const _80 As String = "80"
                End Class

                ''' <summary>
                ''' フォーマット（画面定義）
                ''' </summary>
                Public Class フォーマット_画面定義
                    ''' <summary>左0埋め</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>右0埋め</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' エラーレベル
                ''' </summary>
                Public Class エラーレベル
                    ''' <summary>無視</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>情報</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>警告</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>エラー</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 表示入力設定
                ''' </summary>
                Public Class 表示入力設定
                    ''' <summary>入力</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>表示</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>非表示</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 演算子
                ''' </summary>
                Public Class 演算子
                    ''' <summary>=</summary>
                    Public Const _1 As String = "1"
                    ''' <summary><></summary></summary>                    Public Const _2 As String = "2"
                    ''' <summary>></summary>
                    Public Const _3 As String = "3"
                    ''' <summary></></summary>
                    Public Const _4 As String = "4"
                    ''' <summary>>=</summary>
                    Public Const _5 As String = "5"
                    ''' <summary></></summary>
                    Public Const _6 As String = "6"
                    ''' <summary>like</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>not like</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>between</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>not between</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>is null</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>is not null</summary>
                    Public Const _12 As String = "12"
                End Class

                ''' <summary>
                ''' 処理区分
                ''' </summary>
                Public Class 処理区分
                    ''' <summary>画面項目登録</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>固定値登録</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>設定しない</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>関連テーブルの項目から登録</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>手動採番</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>不詳フラグ登録</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>年齢登録（一次・申込）</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>年齢登録（精密・結果）</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>年度登録</summary>
                    Public Const _10 As String = "10"
                End Class

                ''' <summary>
                ''' 処理種別
                ''' </summary>
                Public Class 処理種別
                    ''' <summary>チェック用</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>更新前処理</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>更新後処理</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 削除条件指定
                ''' </summary>
                Public Class 削除条件指定
                    ''' <summary>削除データを含まない</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>削除データのみ</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 地域保健集計区分
                ''' </summary>
                Public Class 地域保健集計区分
                    ''' <summary>訪問指導ー成人保健ー選択肢１（CD:1）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>個別指導ー成人保健ー選択肢１（CD:2）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>集団指導ー成人保健ー選択肢１（CD:3）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>訪問指導ー母子保健ー選択肢１（CD:4）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>個別指導ー母子保健ー選択肢１（CD:5）</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>集団指導ー母子保健ー選択肢１（CD:6）</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>訪問指導ー成人保健ー選択肢２（CD:7）</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>個別指導ー成人保健ー選択肢２（CD:8）</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>集団指導ー成人保健ー選択肢２（CD:9）</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>訪問指導ー母子保健ー選択肢２（CD:10）</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>個別指導ー母子保健ー選択肢２（CD:11）</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>集団指導ー母子保健ー選択肢２（CD:12）</summary>
                    Public Const _12 As String = "12"
                End Class

                ''' <summary>
                ''' 地区区分
                ''' </summary>
                Public Class 地区区分
                    ''' <summary>地区管理コード1</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>地区管理コード2</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>地区管理コード3</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>地区管理コード4</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>地区管理コード5</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>地区管理コード6</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>地区管理コード7</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>地区管理コード8</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>地区管理コード9</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>地区管理コード10</summary>
                    Public Const _10 As String = "10"
                End Class

                ''' <summary>
                ''' 引数区分（マッピング）
                ''' </summary>
                Public Class 引数区分_マッピング
                    ''' <summary>ファイル項目</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>固定値</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 全体個別区分
                ''' </summary>
                Public Class 全体個別区分
                    ''' <summary>全体抽出</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>個別抽出</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 項目管理区分
                ''' </summary>
                Public Class 項目管理区分
                    ''' <summary>グループ単位</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>個人単位</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 抽出条件区分
                ''' </summary>
                Public Class 抽出条件区分
                    ''' <summary>抽出条件</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>抽出条件以外</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 通知サイクル
                ''' </summary>
                Public Class 通知サイクル
                    ''' <summary>毎年</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>生涯一回</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 引数区分（項目定義）
                ''' </summary>
                Public Class 引数区分_項目定義
                    ''' <summary>画面項目</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>固定値</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 医療機関・事業従事者業務区分
                ''' </summary>
                Public Class 医療機関_事業従事者業務区分
                    ''' <summary>成人保健</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>母子保健</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>予防接種</summary>
                    Public Const _03 As String = "03"
                End Class

                ''' <summary>
                ''' 拡・予約・保健指導業務区分
                ''' </summary>
                Public Class 拡_予約_保健指導業務区分
                    ''' <summary>成人保健</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>母子保健</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>予防接種</summary>
                    Public Const _03 As String = "03"
                End Class

                ''' <summary>
                ''' 基準値業務区分
                ''' </summary>
                Public Class 基準値業務区分
                    ''' <summary>成人保健</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>母子保健</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>予防接種</summary>
                    Public Const _03 As String = "03"
                End Class

                ''' <summary>
                ''' EUC業務区分
                ''' </summary>
                Public Class EUC業務区分
                    ''' <summary>共通管理</summary>
                    Public Const _010 As String = "010"
                    ''' <summary>成人保健</summary>
                    Public Const _020 As String = "020"
                    ''' <summary>母子保健</summary>
                    Public Const _030 As String = "030"
                    ''' <summary>母子保健（妊産婦)</summary>
                    Public Const _031 As String = "031"
                    ''' <summary>母子保健（乳幼児）</summary>
                    Public Const _032 As String = "032"
                    ''' <summary>予防接種</summary>
                    Public Const _040 As String = "040"
                    ''' <summary>統計帳票</summary>
                    Public Const _050 As String = "050"
                End Class

                ''' <summary>
                ''' 取込業務区分
                ''' </summary>
                Public Class 取込業務区分
                    ''' <summary>共通管理</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>成人保健</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>母子保健</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>予防接種</summary>
                    Public Const _04 As String = "04"
                End Class

                ''' <summary>
                ''' システム業務区分
                ''' </summary>
                Public Class システム業務区分
                    ''' <summary>共通管理</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>成人保健</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>母子保健</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>予防接種</summary>
                    Public Const _04 As String = "04"
                End Class

                ''' <summary>
                ''' 基本データリストデータ型
                ''' </summary>
                Public Class 基本データリストデータ型
                    ''' <summary>数値（整数）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>数値（小数点付き実数）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>日付（年月日）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>日付（年）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>日時（時分秒）</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 成人保健フリー項目グループ１
                ''' </summary>
                Public Class 成人保健フリー項目グループ１
                    ''' <summary>一次検診</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>精密検査</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 計算関数（内部）（成人）
                ''' </summary>
                Public Class 計算関数_内部_成人
                    ''' <summary>testc</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 計算関数（DB）（成人）
                ''' </summary>
                Public Class 計算関数_DB_成人
                    ''' <summary>testdb</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 対象サイン
                ''' </summary>
                Public Class 対象サイン
                    ''' <summary>対象外</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>対象</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>不明</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 精密検査実施区分
                ''' </summary>
                Public Class 精密検査実施区分
                    ''' <summary>未実施</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>実施</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' クーポン券表示区分
                ''' </summary>
                Public Class クーポン券表示区分
                    ''' <summary>非表示</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>表示</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 減免区分種別
                ''' </summary>
                Public Class 減免区分種別
                    ''' <summary>特定健診</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>がん検診</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 年齢基準日区分
                ''' </summary>
                Public Class 年齢基準日区分
                    ''' <summary>受診日時点</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>指定日</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 対象サイン引継ぎフラグ
                ''' </summary>
                Public Class 対象サイン引継ぎフラグ
                    ''' <summary>しない</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>する</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 健（検）診対象者特殊条件
                ''' </summary>
                Public Class 健_検_診対象者特殊条件
                    ''' <summary>前年度未受診者対象</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 計算区分（成人）
                ''' </summary>
                Public Class 計算区分_成人
                    ''' <summary>数式計算</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>内部関数</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>DB関数</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 生涯一回フラグ
                ''' </summary>
                Public Class 生涯一回フラグ
                    ''' <summary>生涯複数回</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>生涯1回</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 出力形式
                ''' </summary>
                Public Class 出力形式
                    ''' <summary>文字</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>数値</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>年</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>日付</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>日時</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>時間</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>論理</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>バーコード</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>QRコード</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>画像</summary>
                    Public Const _10 As String = "10"
                End Class

                ''' <summary>
                ''' 帳票分類
                ''' </summary>
                Public Class 帳票分類
                    ''' <summary>帳票</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>別様式</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>サブ様式</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 様式種別
                ''' </summary>
                Public Class 様式種別
                    ''' <summary>一覧表</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>台帳</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>経年表</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>集計表</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>カスタマイズ</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 集計種別
                ''' </summary>
                Public Class 集計種別
                    ''' <summary>単純集計表</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>クロス集計</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 専用様式
                ''' </summary>
                Public Class 専用様式
                    ''' <summary>はがき</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>アドレスシール</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>バーコードシール</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>宛名台帳</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 帳票状態区分
                ''' </summary>
                Public Class 帳票状態区分
                    ''' <summary>予定中</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>処理中</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>処理完了</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>処理失敗</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 文字形式
                ''' </summary>
                Public Class 文字形式
                    ''' <summary>文字切り出し</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>敬称編集</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 数値形式
                ''' </summary>
                Public Class 数値形式
                    ''' <summary>カンマ編集</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>小数点なし</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>小数点１桁</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>小数点２桁</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>小数点３桁</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>小数点４桁</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' 年形式
                ''' </summary>
                Public Class 年形式
                    ''' <summary>和暦</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>和暦ゼロ埋め</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>和暦略</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>和暦略ゼロ埋め</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>和暦数値</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>西暦</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' 日付形式
                ''' </summary>
                Public Class 日付形式
                    ''' <summary>和暦</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>和暦ゼロ埋め</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>和暦略</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>和暦略ゼロ埋め</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>和暦数値</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>西暦</summary>
                    Public Const _06 As String = "06"
                    ''' <summary>西暦ゼロ埋め</summary>
                    Public Const _07 As String = "07"
                    ''' <summary>西暦スラッシュ</summary>
                    Public Const _08 As String = "08"
                    ''' <summary>西暦スラッシュゼロ埋め</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>西暦数値</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>和暦日時曜日</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>ユーザー定義</summary>
                    Public Const _99 As String = "99"
                End Class

                ''' <summary>
                ''' 日時形式
                ''' </summary>
                Public Class 日時形式
                    ''' <summary>和暦日時秒</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>和暦日時秒ゼロ埋め</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>和暦日時秒略</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>和暦日時秒略ゼロ埋め</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>西暦日時秒</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>西暦日時秒ゼロ埋め</summary>
                    Public Const _06 As String = "06"
                    ''' <summary>西暦日時秒スラッシュ</summary>
                    Public Const _07 As String = "07"
                    ''' <summary>西暦日時秒スラッシュゼロ埋め</summary>
                    Public Const _08 As String = "08"
                    ''' <summary>西暦日時秒数値</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>ユーザー定義</summary>
                    Public Const _99 As String = "99"
                End Class

                ''' <summary>
                ''' 時間形式
                ''' </summary>
                Public Class 時間形式
                    ''' <summary>12時間制ゼロ埋め全角</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>12時間制ゼロ埋め半角</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>12時間制全角</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>12時間制半角</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>12時間制略ゼロ埋め全角</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>12時間制略ゼロ埋め半角</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>12時間制略全角</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>12時間制略半角</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>24時間制ゼロ埋め全角</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>24時間制ゼロ埋め半角</summary>
                    Public Const _12 As String = "12"
                    ''' <summary>24時間制全角</summary>
                    Public Const _13 As String = "13"
                    ''' <summary>24時間制半角</summary>
                    Public Const _14 As String = "14"
                    ''' <summary>24時間制略ゼロ埋め全角</summary>
                    Public Const _15 As String = "15"
                    ''' <summary>24時間制略ゼロ埋め半角</summary>
                    Public Const _16 As String = "16"
                End Class

                ''' <summary>
                ''' 論理形式
                ''' </summary>
                Public Class 論理形式
                    ''' <summary>丸バツ</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>丸空白</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>はいいいえ</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>ありなし</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>該当非該当</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' バーコード形式
                ''' </summary>
                Public Class バーコード形式
                    ''' <summary>NW7</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>カスタマーコード</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 出力方式
                ''' </summary>
                Public Class 出力方式
                    ''' <summary>EXCEL</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>PDF</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>CSV</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 除票者除外区分
                ''' </summary>
                Public Class 除票者除外区分
                    ''' <summary>除票者を除く</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>除票者を含む</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 検索区分
                ''' </summary>
                Public Class 検索区分
                    ''' <summary>完全一致</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>部分一致（中間一致）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>部分一致（前方一致）</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 国名コード
                ''' </summary>
                Public Class 国名コード
                    ''' <summary>オーストラリア連邦</summary>
                    Public Const _AUS As String = "AUS"
                    ''' <summary>ベルギー王国</summary>
                    Public Const _BEL As String = "BEL"
                    ''' <summary>中華人民共和国 </summary>
                    Public Const _CHN As String = "CHN"
                    ''' <summary>デンマーク王国</summary>
                    Public Const _DNK As String = "DNK"
                    ''' <summary>フランス共和国</summary>
                    Public Const _FRA_ As String = "FRA "
                    ''' <summary>ドイツ連邦共和国</summary>
                    Public Const _DEU As String = "DEU"
                    ''' <summary>日本国</summary>
                    Public Const _JPN As String = "JPN"
                    ''' <summary>大民国</summary>
                    Public Const _KOR_ As String = "KOR "
                End Class

                ''' <summary>
                ''' 指定都市_行政区等コード
                ''' </summary>
                Public Class 指定都市_行政区等コード
                    ''' <summary>北九州市</summary>
                    Public Const _401005 As String = "401005"
                End Class

            End Class
            ''' <summary>
            ''' 標準版
            ''' </summary>
            Public Class 標準版
                ''' <summary>
                ''' 性別（住民基本台帳）
                ''' </summary>
                Public Class 性別_住民基本台帳
                    ''' <summary>不明（未記入）</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>男</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>女</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 住民種別（住民基本台帳）
                ''' </summary>
                Public Class 住民種別_住民基本台帳
                    ''' <summary>日本人住民</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>外国人住民</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 住民状態（住民基本台帳）
                ''' </summary>
                Public Class 住民状態_住民基本台帳
                    ''' <summary>住登者</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>転出者</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>死亡者</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>その他消除者</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 第30条45規定区分
                ''' </summary>
                Public Class 第30条45規定区分
                    ''' <summary>中長期在留者</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>特別永住者</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>一時庇護許可者</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>仮滞在許可者</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>出生による経過滞在者</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>国籍喪失による経過滞在者</summary>
                    Public Const _06 As String = "06"
                End Class

                ''' <summary>
                ''' 在留資格等
                ''' </summary>
                Public Class 在留資格等
                    ''' <summary>教授</summary>
                    Public Const _T03 As String = "T03"
                    ''' <summary>芸術</summary>
                    Public Const _T04 As String = "T04"
                    ''' <summary>宗教</summary>
                    Public Const _T05 As String = "T05"
                    ''' <summary>報道</summary>
                    Public Const _T06 As String = "T06"
                    ''' <summary>投資・経営</summary>
                    Public Const _T11 As String = "T11"
                    ''' <summary>法律･会計業務</summary>
                    Public Const _T12 As String = "T12"
                    ''' <summary>医療</summary>
                    Public Const _T13 As String = "T13"
                    ''' <summary>研究</summary>
                    Public Const _T14 As String = "T14"
                    ''' <summary>教育</summary>
                    Public Const _T15 As String = "T15"
                    ''' <summary>技術</summary>
                    Public Const _T16 As String = "T16"
                    ''' <summary>人文知識・国際業務</summary>
                    Public Const _T17 As String = "T17"
                    ''' <summary>企業内転勤</summary>
                    Public Const _T18 As String = "T18"
                    ''' <summary>興行</summary>
                    Public Const _T19 As String = "T19"
                    ''' <summary>技能</summary>
                    Public Const _T20 As String = "T20"
                    ''' <summary>技能実習1号イ</summary>
                    Public Const _T21 As String = "T21"
                    ''' <summary>技能実習1号ロ</summary>
                    Public Const _T22 As String = "T22"
                    ''' <summary>技能実習2号イ</summary>
                    Public Const _T23 As String = "T23"
                    ''' <summary>技能実習2号ロ</summary>
                    Public Const _T24 As String = "T24"
                    ''' <summary>経営･管理</summary>
                    Public Const _T25 As String = "T25"
                    ''' <summary>技術･人文知識･国際業務</summary>
                    Public Const _T26 As String = "T26"
                    ''' <summary>技能実習3号イ</summary>
                    Public Const _T27 As String = "T27"
                    ''' <summary>技能実習3号ロ</summary>
                    Public Const _T28 As String = "T28"
                    ''' <summary>介護</summary>
                    Public Const _T29 As String = "T29"
                    ''' <summary>文化活動</summary>
                    Public Const _T31 As String = "T31"
                    ''' <summary>留学</summary>
                    Public Const _T41 As String = "T41"
                    ''' <summary>研修</summary>
                    Public Const _T43 As String = "T43"
                    ''' <summary>家族滞在</summary>
                    Public Const _T44 As String = "T44"
                    ''' <summary>特定活動</summary>
                    Public Const _T51 As String = "T51"
                    ''' <summary>日本人の配偶者等</summary>
                    Public Const _T61 As String = "T61"
                    ''' <summary>永住者の配偶者等</summary>
                    Public Const _T62 As String = "T62"
                    ''' <summary>定住者</summary>
                    Public Const _T63 As String = "T63"
                    ''' <summary>特定技能1号</summary>
                    Public Const _T71 As String = "T71"
                    ''' <summary>特定技能2号</summary>
                    Public Const _T72 As String = "T72"
                    ''' <summary>高度専門職1号イ</summary>
                    Public Const _T81 As String = "T81"
                    ''' <summary>高度専門職1号ロ</summary>
                    Public Const _T82 As String = "T82"
                    ''' <summary>高度専門職1号ハ</summary>
                    Public Const _T83 As String = "T83"
                    ''' <summary>高度専門職2号</summary>
                    Public Const _T90 As String = "T90"
                    ''' <summary>永住者</summary>
                    Public Const _X14 As String = "X14"
                    ''' <summary>特別永住者</summary>
                    Public Const _T60 As String = "T60"
                    ''' <summary>仮滞在</summary>
                    Public Const _X82 As String = "X82"
                    ''' <summary>一時庇護</summary>
                    Public Const _X90 As String = "X90"
                    ''' <summary>その他(上記に当てはまる値がない場合)</summary>
                    Public Const _999 As String = "999"
                End Class

                ''' <summary>
                ''' 在留期間等コード年
                ''' </summary>
                Public Class 在留期間等コード年
                    ''' <summary>00</summary>
                    Public Const _00 As String = "00"
                    ''' <summary>1年</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>2年</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>3年</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>4年</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>5年</summary>
                    Public Const _05 As String = "05"
                End Class

                ''' <summary>
                ''' 在留期間等コード月
                ''' </summary>
                Public Class 在留期間等コード月
                    ''' <summary>00</summary>
                    Public Const _00 As String = "00"
                    ''' <summary>1月</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>2月</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>3月</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>4月</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>5月</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>6月</summary>
                    Public Const _06 As String = "06"
                    ''' <summary>7月</summary>
                    Public Const _07 As String = "07"
                    ''' <summary>8月</summary>
                    Public Const _08 As String = "08"
                    ''' <summary>9月</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>10月</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>11月</summary>
                    Public Const _11 As String = "11"
                End Class

                ''' <summary>
                ''' 在留期間等コード日
                ''' </summary>
                Public Class 在留期間等コード日
                    ''' <summary>000</summary>
                    Public Const _000 As String = "000"
                    ''' <summary>1日</summary>
                    Public Const _001 As String = "001"
                    ''' <summary>2日</summary>
                    Public Const _002 As String = "002"
                    ''' <summary>3日</summary>
                    Public Const _003 As String = "003"
                    ''' <summary>4日</summary>
                    Public Const _004 As String = "004"
                    ''' <summary>5日</summary>
                    Public Const _005 As String = "005"
                    ''' <summary>6日</summary>
                    Public Const _006 As String = "006"
                    ''' <summary>7日</summary>
                    Public Const _007 As String = "007"
                    ''' <summary>8日</summary>
                    Public Const _008 As String = "008"
                    ''' <summary>9日</summary>
                    Public Const _009 As String = "009"
                    ''' <summary>10日</summary>
                    Public Const _010 As String = "010"
                    ''' <summary>11日</summary>
                    Public Const _011 As String = "011"
                    ''' <summary>12日</summary>
                    Public Const _012 As String = "012"
                    ''' <summary>13日</summary>
                    Public Const _013 As String = "013"
                    ''' <summary>14日</summary>
                    Public Const _014 As String = "014"
                    ''' <summary>15日</summary>
                    Public Const _015 As String = "015"
                    ''' <summary>16日</summary>
                    Public Const _016 As String = "016"
                    ''' <summary>17日</summary>
                    Public Const _017 As String = "017"
                    ''' <summary>18日</summary>
                    Public Const _018 As String = "018"
                    ''' <summary>19日</summary>
                    Public Const _019 As String = "019"
                    ''' <summary>20日</summary>
                    Public Const _020 As String = "020"
                    ''' <summary>21日</summary>
                    Public Const _021 As String = "021"
                    ''' <summary>22日</summary>
                    Public Const _022 As String = "022"
                    ''' <summary>23日</summary>
                    Public Const _023 As String = "023"
                    ''' <summary>24日</summary>
                    Public Const _024 As String = "024"
                    ''' <summary>25日</summary>
                    Public Const _025 As String = "025"
                    ''' <summary>26日</summary>
                    Public Const _026 As String = "026"
                    ''' <summary>27日</summary>
                    Public Const _027 As String = "027"
                    ''' <summary>28日</summary>
                    Public Const _028 As String = "028"
                    ''' <summary>29日</summary>
                    Public Const _029 As String = "029"
                    ''' <summary>30日</summary>
                    Public Const _030 As String = "030"
                    ''' <summary>31日</summary>
                    Public Const _031 As String = "031"
                    ''' <summary>32日</summary>
                    Public Const _032 As String = "032"
                    ''' <summary>33日</summary>
                    Public Const _033 As String = "033"
                    ''' <summary>34日</summary>
                    Public Const _034 As String = "034"
                    ''' <summary>35日</summary>
                    Public Const _035 As String = "035"
                    ''' <summary>36日</summary>
                    Public Const _036 As String = "036"
                    ''' <summary>37日</summary>
                    Public Const _037 As String = "037"
                    ''' <summary>38日</summary>
                    Public Const _038 As String = "038"
                    ''' <summary>39日</summary>
                    Public Const _039 As String = "039"
                    ''' <summary>40日</summary>
                    Public Const _040 As String = "040"
                    ''' <summary>41日</summary>
                    Public Const _041 As String = "041"
                    ''' <summary>42日</summary>
                    Public Const _042 As String = "042"
                    ''' <summary>43日</summary>
                    Public Const _043 As String = "043"
                    ''' <summary>44日</summary>
                    Public Const _044 As String = "044"
                    ''' <summary>45日</summary>
                    Public Const _045 As String = "045"
                    ''' <summary>46日</summary>
                    Public Const _046 As String = "046"
                    ''' <summary>47日</summary>
                    Public Const _047 As String = "047"
                    ''' <summary>48日</summary>
                    Public Const _048 As String = "048"
                    ''' <summary>49日</summary>
                    Public Const _049 As String = "049"
                    ''' <summary>50日</summary>
                    Public Const _050 As String = "050"
                    ''' <summary>51日</summary>
                    Public Const _051 As String = "051"
                    ''' <summary>52日</summary>
                    Public Const _052 As String = "052"
                    ''' <summary>53日</summary>
                    Public Const _053 As String = "053"
                    ''' <summary>54日</summary>
                    Public Const _054 As String = "054"
                    ''' <summary>55日</summary>
                    Public Const _055 As String = "055"
                    ''' <summary>56日</summary>
                    Public Const _056 As String = "056"
                    ''' <summary>57日</summary>
                    Public Const _057 As String = "057"
                    ''' <summary>58日</summary>
                    Public Const _058 As String = "058"
                    ''' <summary>59日</summary>
                    Public Const _059 As String = "059"
                    ''' <summary>60日</summary>
                    Public Const _060 As String = "060"
                    ''' <summary>61日</summary>
                    Public Const _061 As String = "061"
                    ''' <summary>62日</summary>
                    Public Const _062 As String = "062"
                    ''' <summary>63日</summary>
                    Public Const _063 As String = "063"
                    ''' <summary>64日</summary>
                    Public Const _064 As String = "064"
                    ''' <summary>65日</summary>
                    Public Const _065 As String = "065"
                    ''' <summary>66日</summary>
                    Public Const _066 As String = "066"
                    ''' <summary>67日</summary>
                    Public Const _067 As String = "067"
                    ''' <summary>68日</summary>
                    Public Const _068 As String = "068"
                    ''' <summary>69日</summary>
                    Public Const _069 As String = "069"
                    ''' <summary>70日</summary>
                    Public Const _070 As String = "070"
                    ''' <summary>71日</summary>
                    Public Const _071 As String = "071"
                    ''' <summary>72日</summary>
                    Public Const _072 As String = "072"
                    ''' <summary>73日</summary>
                    Public Const _073 As String = "073"
                    ''' <summary>74日</summary>
                    Public Const _074 As String = "074"
                    ''' <summary>75日</summary>
                    Public Const _075 As String = "075"
                    ''' <summary>76日</summary>
                    Public Const _076 As String = "076"
                    ''' <summary>77日</summary>
                    Public Const _077 As String = "077"
                    ''' <summary>78日</summary>
                    Public Const _078 As String = "078"
                    ''' <summary>79日</summary>
                    Public Const _079 As String = "079"
                    ''' <summary>80日</summary>
                    Public Const _080 As String = "080"
                    ''' <summary>81日</summary>
                    Public Const _081 As String = "081"
                    ''' <summary>82日</summary>
                    Public Const _082 As String = "082"
                    ''' <summary>83日</summary>
                    Public Const _083 As String = "083"
                    ''' <summary>84日</summary>
                    Public Const _084 As String = "084"
                    ''' <summary>85日</summary>
                    Public Const _085 As String = "085"
                    ''' <summary>86日</summary>
                    Public Const _086 As String = "086"
                    ''' <summary>87日</summary>
                    Public Const _087 As String = "087"
                    ''' <summary>88日</summary>
                    Public Const _088 As String = "088"
                    ''' <summary>89日</summary>
                    Public Const _089 As String = "089"
                    ''' <summary>90日</summary>
                    Public Const _090 As String = "090"
                    ''' <summary>91日</summary>
                    Public Const _091 As String = "091"
                    ''' <summary>92日</summary>
                    Public Const _092 As String = "092"
                    ''' <summary>93日</summary>
                    Public Const _093 As String = "093"
                    ''' <summary>94日</summary>
                    Public Const _094 As String = "094"
                    ''' <summary>95日</summary>
                    Public Const _095 As String = "095"
                    ''' <summary>96日</summary>
                    Public Const _096 As String = "096"
                    ''' <summary>97日</summary>
                    Public Const _097 As String = "097"
                    ''' <summary>98日</summary>
                    Public Const _098 As String = "098"
                    ''' <summary>99日</summary>
                    Public Const _099 As String = "099"
                    ''' <summary>100日</summary>
                    Public Const _100 As String = "100"
                    ''' <summary>101日</summary>
                    Public Const _101 As String = "101"
                    ''' <summary>102日</summary>
                    Public Const _102 As String = "102"
                    ''' <summary>103日</summary>
                    Public Const _103 As String = "103"
                    ''' <summary>104日</summary>
                    Public Const _104 As String = "104"
                    ''' <summary>105日</summary>
                    Public Const _105 As String = "105"
                    ''' <summary>106日</summary>
                    Public Const _106 As String = "106"
                    ''' <summary>107日</summary>
                    Public Const _107 As String = "107"
                    ''' <summary>108日</summary>
                    Public Const _108 As String = "108"
                    ''' <summary>109日</summary>
                    Public Const _109 As String = "109"
                    ''' <summary>110日</summary>
                    Public Const _110 As String = "110"
                    ''' <summary>111日</summary>
                    Public Const _111 As String = "111"
                    ''' <summary>112日</summary>
                    Public Const _112 As String = "112"
                    ''' <summary>113日</summary>
                    Public Const _113 As String = "113"
                    ''' <summary>114日</summary>
                    Public Const _114 As String = "114"
                    ''' <summary>115日</summary>
                    Public Const _115 As String = "115"
                    ''' <summary>116日</summary>
                    Public Const _116 As String = "116"
                    ''' <summary>117日</summary>
                    Public Const _117 As String = "117"
                    ''' <summary>118日</summary>
                    Public Const _118 As String = "118"
                    ''' <summary>119日</summary>
                    Public Const _119 As String = "119"
                    ''' <summary>120日</summary>
                    Public Const _120 As String = "120"
                    ''' <summary>121日</summary>
                    Public Const _121 As String = "121"
                    ''' <summary>122日</summary>
                    Public Const _122 As String = "122"
                    ''' <summary>123日</summary>
                    Public Const _123 As String = "123"
                    ''' <summary>124日</summary>
                    Public Const _124 As String = "124"
                    ''' <summary>125日</summary>
                    Public Const _125 As String = "125"
                    ''' <summary>126日</summary>
                    Public Const _126 As String = "126"
                    ''' <summary>127日</summary>
                    Public Const _127 As String = "127"
                    ''' <summary>128日</summary>
                    Public Const _128 As String = "128"
                    ''' <summary>129日</summary>
                    Public Const _129 As String = "129"
                    ''' <summary>130日</summary>
                    Public Const _130 As String = "130"
                    ''' <summary>131日</summary>
                    Public Const _131 As String = "131"
                    ''' <summary>132日</summary>
                    Public Const _132 As String = "132"
                    ''' <summary>133日</summary>
                    Public Const _133 As String = "133"
                    ''' <summary>134日</summary>
                    Public Const _134 As String = "134"
                    ''' <summary>135日</summary>
                    Public Const _135 As String = "135"
                    ''' <summary>136日</summary>
                    Public Const _136 As String = "136"
                    ''' <summary>137日</summary>
                    Public Const _137 As String = "137"
                    ''' <summary>138日</summary>
                    Public Const _138 As String = "138"
                    ''' <summary>139日</summary>
                    Public Const _139 As String = "139"
                    ''' <summary>140日</summary>
                    Public Const _140 As String = "140"
                    ''' <summary>141日</summary>
                    Public Const _141 As String = "141"
                    ''' <summary>142日</summary>
                    Public Const _142 As String = "142"
                    ''' <summary>143日</summary>
                    Public Const _143 As String = "143"
                    ''' <summary>144日</summary>
                    Public Const _144 As String = "144"
                    ''' <summary>145日</summary>
                    Public Const _145 As String = "145"
                    ''' <summary>146日</summary>
                    Public Const _146 As String = "146"
                    ''' <summary>147日</summary>
                    Public Const _147 As String = "147"
                    ''' <summary>148日</summary>
                    Public Const _148 As String = "148"
                    ''' <summary>149日</summary>
                    Public Const _149 As String = "149"
                    ''' <summary>150日</summary>
                    Public Const _150 As String = "150"
                    ''' <summary>151日</summary>
                    Public Const _151 As String = "151"
                    ''' <summary>152日</summary>
                    Public Const _152 As String = "152"
                    ''' <summary>153日</summary>
                    Public Const _153 As String = "153"
                    ''' <summary>154日</summary>
                    Public Const _154 As String = "154"
                    ''' <summary>155日</summary>
                    Public Const _155 As String = "155"
                    ''' <summary>156日</summary>
                    Public Const _156 As String = "156"
                    ''' <summary>157日</summary>
                    Public Const _157 As String = "157"
                    ''' <summary>158日</summary>
                    Public Const _158 As String = "158"
                    ''' <summary>159日</summary>
                    Public Const _159 As String = "159"
                    ''' <summary>160日</summary>
                    Public Const _160 As String = "160"
                    ''' <summary>161日</summary>
                    Public Const _161 As String = "161"
                    ''' <summary>162日</summary>
                    Public Const _162 As String = "162"
                    ''' <summary>163日</summary>
                    Public Const _163 As String = "163"
                    ''' <summary>164日</summary>
                    Public Const _164 As String = "164"
                    ''' <summary>165日</summary>
                    Public Const _165 As String = "165"
                    ''' <summary>166日</summary>
                    Public Const _166 As String = "166"
                    ''' <summary>167日</summary>
                    Public Const _167 As String = "167"
                    ''' <summary>168日</summary>
                    Public Const _168 As String = "168"
                    ''' <summary>169日</summary>
                    Public Const _169 As String = "169"
                    ''' <summary>170日</summary>
                    Public Const _170 As String = "170"
                    ''' <summary>171日</summary>
                    Public Const _171 As String = "171"
                    ''' <summary>172日</summary>
                    Public Const _172 As String = "172"
                    ''' <summary>173日</summary>
                    Public Const _173 As String = "173"
                    ''' <summary>174日</summary>
                    Public Const _174 As String = "174"
                    ''' <summary>175日</summary>
                    Public Const _175 As String = "175"
                    ''' <summary>176日</summary>
                    Public Const _176 As String = "176"
                    ''' <summary>177日</summary>
                    Public Const _177 As String = "177"
                    ''' <summary>178日</summary>
                    Public Const _178 As String = "178"
                    ''' <summary>179日</summary>
                    Public Const _179 As String = "179"
                    ''' <summary>180日</summary>
                    Public Const _180 As String = "180"
                    ''' <summary>181日</summary>
                    Public Const _181 As String = "181"
                    ''' <summary>182日</summary>
                    Public Const _182 As String = "182"
                    ''' <summary>183日</summary>
                    Public Const _183 As String = "183"
                    ''' <summary>184日</summary>
                    Public Const _184 As String = "184"
                    ''' <summary>185日</summary>
                    Public Const _185 As String = "185"
                    ''' <summary>186日</summary>
                    Public Const _186 As String = "186"
                    ''' <summary>187日</summary>
                    Public Const _187 As String = "187"
                    ''' <summary>188日</summary>
                    Public Const _188 As String = "188"
                    ''' <summary>189日</summary>
                    Public Const _189 As String = "189"
                    ''' <summary>190日</summary>
                    Public Const _190 As String = "190"
                    ''' <summary>191日</summary>
                    Public Const _191 As String = "191"
                    ''' <summary>192日</summary>
                    Public Const _192 As String = "192"
                    ''' <summary>193日</summary>
                    Public Const _193 As String = "193"
                    ''' <summary>194日</summary>
                    Public Const _194 As String = "194"
                    ''' <summary>195日</summary>
                    Public Const _195 As String = "195"
                    ''' <summary>196日</summary>
                    Public Const _196 As String = "196"
                    ''' <summary>197日</summary>
                    Public Const _197 As String = "197"
                    ''' <summary>198日</summary>
                    Public Const _198 As String = "198"
                    ''' <summary>199日</summary>
                    Public Const _199 As String = "199"
                    ''' <summary>200日</summary>
                    Public Const _200 As String = "200"
                    ''' <summary>201日</summary>
                    Public Const _201 As String = "201"
                    ''' <summary>202日</summary>
                    Public Const _202 As String = "202"
                    ''' <summary>203日</summary>
                    Public Const _203 As String = "203"
                    ''' <summary>204日</summary>
                    Public Const _204 As String = "204"
                    ''' <summary>205日</summary>
                    Public Const _205 As String = "205"
                    ''' <summary>206日</summary>
                    Public Const _206 As String = "206"
                    ''' <summary>207日</summary>
                    Public Const _207 As String = "207"
                    ''' <summary>208日</summary>
                    Public Const _208 As String = "208"
                    ''' <summary>209日</summary>
                    Public Const _209 As String = "209"
                    ''' <summary>210日</summary>
                    Public Const _210 As String = "210"
                    ''' <summary>211日</summary>
                    Public Const _211 As String = "211"
                    ''' <summary>212日</summary>
                    Public Const _212 As String = "212"
                    ''' <summary>213日</summary>
                    Public Const _213 As String = "213"
                    ''' <summary>214日</summary>
                    Public Const _214 As String = "214"
                    ''' <summary>215日</summary>
                    Public Const _215 As String = "215"
                    ''' <summary>216日</summary>
                    Public Const _216 As String = "216"
                    ''' <summary>217日</summary>
                    Public Const _217 As String = "217"
                    ''' <summary>218日</summary>
                    Public Const _218 As String = "218"
                    ''' <summary>219日</summary>
                    Public Const _219 As String = "219"
                    ''' <summary>220日</summary>
                    Public Const _220 As String = "220"
                    ''' <summary>221日</summary>
                    Public Const _221 As String = "221"
                    ''' <summary>222日</summary>
                    Public Const _222 As String = "222"
                    ''' <summary>223日</summary>
                    Public Const _223 As String = "223"
                    ''' <summary>224日</summary>
                    Public Const _224 As String = "224"
                    ''' <summary>225日</summary>
                    Public Const _225 As String = "225"
                    ''' <summary>226日</summary>
                    Public Const _226 As String = "226"
                    ''' <summary>227日</summary>
                    Public Const _227 As String = "227"
                    ''' <summary>228日</summary>
                    Public Const _228 As String = "228"
                    ''' <summary>229日</summary>
                    Public Const _229 As String = "229"
                    ''' <summary>230日</summary>
                    Public Const _230 As String = "230"
                    ''' <summary>231日</summary>
                    Public Const _231 As String = "231"
                    ''' <summary>232日</summary>
                    Public Const _232 As String = "232"
                    ''' <summary>233日</summary>
                    Public Const _233 As String = "233"
                    ''' <summary>234日</summary>
                    Public Const _234 As String = "234"
                    ''' <summary>235日</summary>
                    Public Const _235 As String = "235"
                    ''' <summary>236日</summary>
                    Public Const _236 As String = "236"
                    ''' <summary>237日</summary>
                    Public Const _237 As String = "237"
                    ''' <summary>238日</summary>
                    Public Const _238 As String = "238"
                    ''' <summary>239日</summary>
                    Public Const _239 As String = "239"
                    ''' <summary>240日</summary>
                    Public Const _240 As String = "240"
                    ''' <summary>241日</summary>
                    Public Const _241 As String = "241"
                    ''' <summary>242日</summary>
                    Public Const _242 As String = "242"
                    ''' <summary>243日</summary>
                    Public Const _243 As String = "243"
                    ''' <summary>244日</summary>
                    Public Const _244 As String = "244"
                    ''' <summary>245日</summary>
                    Public Const _245 As String = "245"
                    ''' <summary>246日</summary>
                    Public Const _246 As String = "246"
                    ''' <summary>247日</summary>
                    Public Const _247 As String = "247"
                    ''' <summary>248日</summary>
                    Public Const _248 As String = "248"
                    ''' <summary>249日</summary>
                    Public Const _249 As String = "249"
                    ''' <summary>250日</summary>
                    Public Const _250 As String = "250"
                    ''' <summary>251日</summary>
                    Public Const _251 As String = "251"
                    ''' <summary>252日</summary>
                    Public Const _252 As String = "252"
                    ''' <summary>253日</summary>
                    Public Const _253 As String = "253"
                    ''' <summary>254日</summary>
                    Public Const _254 As String = "254"
                    ''' <summary>255日</summary>
                    Public Const _255 As String = "255"
                    ''' <summary>256日</summary>
                    Public Const _256 As String = "256"
                    ''' <summary>257日</summary>
                    Public Const _257 As String = "257"
                    ''' <summary>258日</summary>
                    Public Const _258 As String = "258"
                    ''' <summary>259日</summary>
                    Public Const _259 As String = "259"
                    ''' <summary>260日</summary>
                    Public Const _260 As String = "260"
                    ''' <summary>261日</summary>
                    Public Const _261 As String = "261"
                    ''' <summary>262日</summary>
                    Public Const _262 As String = "262"
                    ''' <summary>263日</summary>
                    Public Const _263 As String = "263"
                    ''' <summary>264日</summary>
                    Public Const _264 As String = "264"
                    ''' <summary>265日</summary>
                    Public Const _265 As String = "265"
                    ''' <summary>266日</summary>
                    Public Const _266 As String = "266"
                    ''' <summary>267日</summary>
                    Public Const _267 As String = "267"
                    ''' <summary>268日</summary>
                    Public Const _268 As String = "268"
                    ''' <summary>269日</summary>
                    Public Const _269 As String = "269"
                    ''' <summary>270日</summary>
                    Public Const _270 As String = "270"
                    ''' <summary>271日</summary>
                    Public Const _271 As String = "271"
                    ''' <summary>272日</summary>
                    Public Const _272 As String = "272"
                    ''' <summary>273日</summary>
                    Public Const _273 As String = "273"
                    ''' <summary>274日</summary>
                    Public Const _274 As String = "274"
                    ''' <summary>275日</summary>
                    Public Const _275 As String = "275"
                    ''' <summary>276日</summary>
                    Public Const _276 As String = "276"
                    ''' <summary>277日</summary>
                    Public Const _277 As String = "277"
                    ''' <summary>278日</summary>
                    Public Const _278 As String = "278"
                    ''' <summary>279日</summary>
                    Public Const _279 As String = "279"
                    ''' <summary>280日</summary>
                    Public Const _280 As String = "280"
                    ''' <summary>281日</summary>
                    Public Const _281 As String = "281"
                    ''' <summary>282日</summary>
                    Public Const _282 As String = "282"
                    ''' <summary>283日</summary>
                    Public Const _283 As String = "283"
                    ''' <summary>284日</summary>
                    Public Const _284 As String = "284"
                    ''' <summary>285日</summary>
                    Public Const _285 As String = "285"
                    ''' <summary>286日</summary>
                    Public Const _286 As String = "286"
                    ''' <summary>287日</summary>
                    Public Const _287 As String = "287"
                    ''' <summary>288日</summary>
                    Public Const _288 As String = "288"
                    ''' <summary>289日</summary>
                    Public Const _289 As String = "289"
                    ''' <summary>290日</summary>
                    Public Const _290 As String = "290"
                    ''' <summary>291日</summary>
                    Public Const _291 As String = "291"
                    ''' <summary>292日</summary>
                    Public Const _292 As String = "292"
                    ''' <summary>293日</summary>
                    Public Const _293 As String = "293"
                    ''' <summary>294日</summary>
                    Public Const _294 As String = "294"
                    ''' <summary>295日</summary>
                    Public Const _295 As String = "295"
                    ''' <summary>296日</summary>
                    Public Const _296 As String = "296"
                    ''' <summary>297日</summary>
                    Public Const _297 As String = "297"
                    ''' <summary>298日</summary>
                    Public Const _298 As String = "298"
                    ''' <summary>299日</summary>
                    Public Const _299 As String = "299"
                    ''' <summary>300日</summary>
                    Public Const _300 As String = "300"
                    ''' <summary>301日</summary>
                    Public Const _301 As String = "301"
                    ''' <summary>302日</summary>
                    Public Const _302 As String = "302"
                    ''' <summary>303日</summary>
                    Public Const _303 As String = "303"
                    ''' <summary>304日</summary>
                    Public Const _304 As String = "304"
                    ''' <summary>305日</summary>
                    Public Const _305 As String = "305"
                    ''' <summary>306日</summary>
                    Public Const _306 As String = "306"
                    ''' <summary>307日</summary>
                    Public Const _307 As String = "307"
                    ''' <summary>308日</summary>
                    Public Const _308 As String = "308"
                    ''' <summary>309日</summary>
                    Public Const _309 As String = "309"
                    ''' <summary>310日</summary>
                    Public Const _310 As String = "310"
                    ''' <summary>311日</summary>
                    Public Const _311 As String = "311"
                    ''' <summary>312日</summary>
                    Public Const _312 As String = "312"
                    ''' <summary>313日</summary>
                    Public Const _313 As String = "313"
                    ''' <summary>314日</summary>
                    Public Const _314 As String = "314"
                    ''' <summary>315日</summary>
                    Public Const _315 As String = "315"
                    ''' <summary>316日</summary>
                    Public Const _316 As String = "316"
                    ''' <summary>317日</summary>
                    Public Const _317 As String = "317"
                    ''' <summary>318日</summary>
                    Public Const _318 As String = "318"
                    ''' <summary>319日</summary>
                    Public Const _319 As String = "319"
                    ''' <summary>320日</summary>
                    Public Const _320 As String = "320"
                    ''' <summary>321日</summary>
                    Public Const _321 As String = "321"
                    ''' <summary>322日</summary>
                    Public Const _322 As String = "322"
                    ''' <summary>323日</summary>
                    Public Const _323 As String = "323"
                    ''' <summary>324日</summary>
                    Public Const _324 As String = "324"
                    ''' <summary>325日</summary>
                    Public Const _325 As String = "325"
                    ''' <summary>326日</summary>
                    Public Const _326 As String = "326"
                    ''' <summary>327日</summary>
                    Public Const _327 As String = "327"
                    ''' <summary>328日</summary>
                    Public Const _328 As String = "328"
                    ''' <summary>329日</summary>
                    Public Const _329 As String = "329"
                    ''' <summary>330日</summary>
                    Public Const _330 As String = "330"
                    ''' <summary>331日</summary>
                    Public Const _331 As String = "331"
                    ''' <summary>332日</summary>
                    Public Const _332 As String = "332"
                    ''' <summary>333日</summary>
                    Public Const _333 As String = "333"
                    ''' <summary>334日</summary>
                    Public Const _334 As String = "334"
                    ''' <summary>335日</summary>
                    Public Const _335 As String = "335"
                    ''' <summary>336日</summary>
                    Public Const _336 As String = "336"
                    ''' <summary>337日</summary>
                    Public Const _337 As String = "337"
                    ''' <summary>338日</summary>
                    Public Const _338 As String = "338"
                    ''' <summary>339日</summary>
                    Public Const _339 As String = "339"
                    ''' <summary>340日</summary>
                    Public Const _340 As String = "340"
                    ''' <summary>341日</summary>
                    Public Const _341 As String = "341"
                    ''' <summary>342日</summary>
                    Public Const _342 As String = "342"
                    ''' <summary>343日</summary>
                    Public Const _343 As String = "343"
                    ''' <summary>344日</summary>
                    Public Const _344 As String = "344"
                    ''' <summary>345日</summary>
                    Public Const _345 As String = "345"
                    ''' <summary>346日</summary>
                    Public Const _346 As String = "346"
                    ''' <summary>347日</summary>
                    Public Const _347 As String = "347"
                    ''' <summary>348日</summary>
                    Public Const _348 As String = "348"
                    ''' <summary>349日</summary>
                    Public Const _349 As String = "349"
                    ''' <summary>350日</summary>
                    Public Const _350 As String = "350"
                    ''' <summary>351日</summary>
                    Public Const _351 As String = "351"
                    ''' <summary>352日</summary>
                    Public Const _352 As String = "352"
                    ''' <summary>353日</summary>
                    Public Const _353 As String = "353"
                    ''' <summary>354日</summary>
                    Public Const _354 As String = "354"
                    ''' <summary>355日</summary>
                    Public Const _355 As String = "355"
                    ''' <summary>356日</summary>
                    Public Const _356 As String = "356"
                    ''' <summary>357日</summary>
                    Public Const _357 As String = "357"
                    ''' <summary>358日</summary>
                    Public Const _358 As String = "358"
                    ''' <summary>359日</summary>
                    Public Const _359 As String = "359"
                    ''' <summary>360日</summary>
                    Public Const _360 As String = "360"
                    ''' <summary>361日</summary>
                    Public Const _361 As String = "361"
                    ''' <summary>362日</summary>
                    Public Const _362 As String = "362"
                    ''' <summary>363日</summary>
                    Public Const _363 As String = "363"
                    ''' <summary>364日</summary>
                    Public Const _364 As String = "364"
                    ''' <summary>365日</summary>
                    Public Const _365 As String = "365"
                End Class

                ''' <summary>
                ''' 氏名優先区分
                ''' </summary>
                Public Class 氏名優先区分
                    ''' <summary>氏名（漢字のみ）</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>氏名（ローマ字のみ）</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>氏名（漢字及びローマ字）</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>氏名（ローマ字及び漢字）</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>氏名（漢字のみ）及び通称</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>氏名（ローマ字のみ）及び通称</summary>
                    Public Const _06 As String = "06"
                    ''' <summary>氏名（漢字及びローマ字）及び通称</summary>
                    Public Const _07 As String = "07"
                    ''' <summary>氏名（ローマ字及び漢字）及び通称</summary>
                    Public Const _08 As String = "08"
                    ''' <summary>通称</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>通称及び氏名（漢字のみ）</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>通称及び氏名（ローマ字のみ）</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>通称及び氏名（漢字及びローマ字）</summary>
                    Public Const _12 As String = "12"
                    ''' <summary>通称及び氏名（ローマ字及び漢字）</summary>
                    Public Const _13 As String = "13"
                End Class

                ''' <summary>
                ''' 続柄
                ''' </summary>
                Public Class 続柄
                    ''' <summary>世帯主 </summary>
                    Public Const _02 As String = "02"
                    ''' <summary>夫 </summary>
                    Public Const _11 As String = "11"
                    ''' <summary>妻 </summary>
                    Public Const _12 As String = "12"
                    ''' <summary>夫（未届） </summary>
                    Public Const _13 As String = "13"
                    ''' <summary>妻（未届） </summary>
                    Public Const _14 As String = "14"
                    ''' <summary>子 </summary>
                    Public Const _20 As String = "20"
                    ''' <summary>子（） </summary>
                    Public Const _2X As String = "2X"
                    ''' <summary>父 </summary>
                    Public Const _51 As String = "51"
                    ''' <summary>母 </summary>
                    Public Const _52 As String = "52"
                    ''' <summary>兄 </summary>
                    Public Const _71 As String = "71"
                    ''' <summary>弟 </summary>
                    Public Const _74 As String = "74"
                    ''' <summary>姉 </summary>
                    Public Const _81 As String = "81"
                    ''' <summary>妹 </summary>
                    Public Const _84 As String = "84"
                    ''' <summary>縁故者 </summary>
                    Public Const _96 As String = "96"
                    ''' <summary>同居人 </summary>
                    Public Const _99 As String = "99"
                    ''' <summary>空欄</summary>
                    Public Const _XX As String = "XX"
                End Class

                ''' <summary>
                ''' 記載の事由
                ''' </summary>
                Public Class 記載の事由
                    ''' <summary>記載_国内転入</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>記載_国外転入等</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>記載_出生</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>記載_職権記載（帰化等）</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>記載_職権記載（国籍喪失）</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>記載_職権記載</summary>
                    Public Const _06 As String = "06"
                    ''' <summary>記載_改製</summary>
                    Public Const _07 As String = "07"
                    ''' <summary>記載_再製</summary>
                    Public Const _08 As String = "08"
                    ''' <summary>記載_異動の取消し（増）</summary>
                    Public Const _09 As String = "09"
                End Class

                ''' <summary>
                ''' 消除の事由
                ''' </summary>
                Public Class 消除の事由
                    ''' <summary>消除_国内転出</summary>
                    Public Const _21 As String = "21"
                    ''' <summary>消除_国外転出</summary>
                    Public Const _22 As String = "22"
                    ''' <summary>消除_死亡</summary>
                    Public Const _23 As String = "23"
                    ''' <summary>消除_職権消除（帰化等）</summary>
                    Public Const _24 As String = "24"
                    ''' <summary>消除_職権消除（国籍喪失）</summary>
                    Public Const _25 As String = "25"
                    ''' <summary>消除_職権消除</summary>
                    Public Const _26 As String = "26"
                    ''' <summary>消除_改製</summary>
                    Public Const _27 As String = "27"
                    ''' <summary>消除_異動の取消し（減）</summary>
                    Public Const _28 As String = "28"
                End Class

                ''' <summary>
                ''' 修正の事由
                ''' </summary>
                Public Class 修正の事由
                    ''' <summary>修正_転居</summary>
                    Public Const _41 As String = "41"
                    ''' <summary>修正_軽微な修正</summary>
                    Public Const _42 As String = "42"
                    ''' <summary>修正_職権修正</summary>
                    Public Const _43 As String = "43"
                    ''' <summary>修正_誤記修正</summary>
                    Public Const _44 As String = "44"
                    ''' <summary>修正_個人番号の変更請求</summary>
                    Public Const _45 As String = "45"
                    ''' <summary>修正_個人番号の職権修正</summary>
                    Public Const _46 As String = "46"
                    ''' <summary>修正_個人番号の職権記載</summary>
                    Public Const _47 As String = "47"
                    ''' <summary>修正_住民票コードの変更請求</summary>
                    Public Const _48 As String = "48"
                    ''' <summary>修正_住民票コードの職権記載</summary>
                    Public Const _49 As String = "49"
                    ''' <summary>修正_世帯分離</summary>
                    Public Const _50 As String = "50"
                    ''' <summary>修正_世帯合併</summary>
                    Public Const _51 As String = "51"
                    ''' <summary>修正_世帯変更</summary>
                    Public Const _52 As String = "52"
                    ''' <summary>修正_世帯主変更</summary>
                    Public Const _53 As String = "53"
                    ''' <summary>修正_旧氏の記載</summary>
                    Public Const _54 As String = "54"
                    ''' <summary>修正_旧氏の変更</summary>
                    Public Const _55 As String = "55"
                    ''' <summary>修正_旧氏の削除</summary>
                    Public Const _56 As String = "56"
                    ''' <summary>修正_通称の記載</summary>
                    Public Const _57 As String = "57"
                    ''' <summary>修正_通称の削除</summary>
                    Public Const _58 As String = "58"
                    ''' <summary>修正_異動の取消し（修正）</summary>
                    Public Const _59 As String = "59"
                End Class

                ''' <summary>
                ''' 支援措置区分
                ''' </summary>
                Public Class 支援措置区分
                    ''' <summary>支援措置</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>仮支援措置</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>支援措置終了</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 未申告区分
                ''' </summary>
                Public Class 未申告区分
                    ''' <summary>非該当（未申告なし）</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>該当（一部未申告）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>該当（完全未申告）</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 課税非課税区分
                ''' </summary>
                Public Class 課税非課税区分
                    ''' <summary>非課税</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>課税</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 税額・税額控除
                ''' </summary>
                Public Class 税額_税額控除
                    ''' <summary>市町村民税_調整控除額</summary>
                    Public Const _001 As String = "001"
                    ''' <summary>都道府県民税_調整控除額</summary>
                    Public Const _002 As String = "002"
                    ''' <summary>市町村民税_調整額</summary>
                    Public Const _003 As String = "003"
                    ''' <summary>都道府県民税_調整額</summary>
                    Public Const _004 As String = "004"
                    ''' <summary>市町村民税_住宅借入金等特別税額控除額_入力値</summary>
                    Public Const _005 As String = "005"
                    ''' <summary>市町村民税_住宅借入金等特別税額控除額_計算値</summary>
                    Public Const _006 As String = "006"
                    ''' <summary>市町村民税_住宅借入金等特別税額控除額【税源移譲前】</summary>
                    Public Const _007 As String = "007"
                    ''' <summary>都道府県民税_住宅借入金等特別税額控除額_入力値</summary>
                    Public Const _008 As String = "008"
                    ''' <summary>都道府県民税_住宅借入金等特別税額控除額_計算値</summary>
                    Public Const _009 As String = "009"
                    ''' <summary>都道府県民税_住宅借入金等特別税額控除額【税源移譲前】</summary>
                    Public Const _010 As String = "010"
                    ''' <summary>住宅借入金等特別税額控除額_入力値</summary>
                    Public Const _011 As String = "011"
                    ''' <summary>住宅借入金等特別税額控除額_計算値</summary>
                    Public Const _012 As String = "012"
                    ''' <summary>市町村民税_寄附金税額控除額</summary>
                    Public Const _013 As String = "013"
                    ''' <summary>内）基本控除</summary>
                    Public Const _014 As String = "014"
                    ''' <summary>内）特例控除</summary>
                    Public Const _015 As String = "015"
                    ''' <summary>内）申告特例控除</summary>
                    Public Const _016 As String = "016"
                    ''' <summary>市町村民税_寄附金税額控除額【税源移譲前】</summary>
                    Public Const _017 As String = "017"
                    ''' <summary>都道府県民税_寄附金税額控除額</summary>
                    Public Const _018 As String = "018"
                    ''' <summary>都道府県民税_寄附金税額控除額【税源移譲前】</summary>
                    Public Const _019 As String = "019"
                    ''' <summary>市町村民税_外国税控除額_入力値</summary>
                    Public Const _020 As String = "020"
                    ''' <summary>市町村民税_外国税控除額_計算値</summary>
                    Public Const _021 As String = "021"
                    ''' <summary>都道府県民税_外国税控除額_入力値</summary>
                    Public Const _022 As String = "022"
                    ''' <summary>都道府県民税_外国税控除額_計算値</summary>
                    Public Const _023 As String = "023"
                    ''' <summary>市町村民税_配当控除額</summary>
                    Public Const _024 As String = "024"
                    ''' <summary>都道府県民税_配当控除額</summary>
                    Public Const _025 As String = "025"
                    ''' <summary>市町村民税_配当割額又は株式等譲渡所得割額の控除額</summary>
                    Public Const _026 As String = "026"
                    ''' <summary>都道府県民税_配当割額又は株式等譲渡所得割額の控除額</summary>
                    Public Const _027 As String = "027"
                    ''' <summary>市町村民税_税額控除前所得割額</summary>
                    Public Const _028 As String = "028"
                    ''' <summary>市町村民税所得割額</summary>
                    Public Const _029 As String = "029"
                    ''' <summary>市町村民税所得割額【税源移譲前】</summary>
                    Public Const _030 As String = "030"
                    ''' <summary>市町村民税均等割額</summary>
                    Public Const _031 As String = "031"
                    ''' <summary>都道府県民税_税額控除前所得割額</summary>
                    Public Const _032 As String = "032"
                    ''' <summary>都道府県民税所得割額</summary>
                    Public Const _033 As String = "033"
                    ''' <summary>都道府県民税所得割額【税源移譲前】</summary>
                    Public Const _034 As String = "034"
                    ''' <summary>都道府県民税均等割額</summary>
                    Public Const _035 As String = "035"
                    ''' <summary>市町村民税所得割額（減免前）</summary>
                    Public Const _036 As String = "036"
                    ''' <summary>市町村民税均等割額（減免前）</summary>
                    Public Const _037 As String = "037"
                    ''' <summary>減免税額</summary>
                    Public Const _038 As String = "038"
                    ''' <summary>減免税額（所得割）</summary>
                    Public Const _039 As String = "039"
                    ''' <summary>減免税額（均等割）</summary>
                    Public Const _040 As String = "040"
                    ''' <summary>所得割額_減免後端数保持</summary>
                    Public Const _041 As String = "041"
                    ''' <summary>都道府県民税所得割額（減免前）</summary>
                    Public Const _042 As String = "042"
                    ''' <summary>都道府県民税均等割額（減免前）</summary>
                    Public Const _043 As String = "043"
                    ''' <summary>市町村民税_減免税額（所得割）</summary>
                    Public Const _044 As String = "044"
                    ''' <summary>市町村民税_減免税額（所得割）【税源移譲前】</summary>
                    Public Const _045 As String = "045"
                    ''' <summary>市町村民税_減免税額（均等割）</summary>
                    Public Const _046 As String = "046"
                    ''' <summary>都道府県税_減免税額（所得割）</summary>
                    Public Const _047 As String = "047"
                    ''' <summary>都道府県税_減免税額（所得割）【税源移譲前】</summary>
                    Public Const _048 As String = "048"
                    ''' <summary>都道府県税_減免税額（均等割）</summary>
                    Public Const _049 As String = "049"
                    ''' <summary>税額調整控除額</summary>
                    Public Const _050 As String = "050"
                    ''' <summary>定率控除額</summary>
                    Public Const _051 As String = "051"
                    ''' <summary>免税税額（所得割）</summary>
                    Public Const _052 As String = "052"
                    ''' <summary>軽減税額（均等割）</summary>
                    Public Const _053 As String = "053"
                    ''' <summary>老年者非課税経過措置</summary>
                    Public Const _054 As String = "054"
                    ''' <summary>配当譲渡割控除不足額</summary>
                    Public Const _055 As String = "055"
                    ''' <summary>森林環境税</summary>
                    Public Const _056 As String = "056"
                    ''' <summary>免除税額（森林環境税）</summary>
                    Public Const _057 As String = "057"
                End Class

                ''' <summary>
                ''' 他団体課税対象者区分
                ''' </summary>
                Public Class 他団体課税対象者区分
                    ''' <summary>対象外</summary>
                    Public Const _0_ As String = "0 "
                    ''' <summary>対象</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 職種
                ''' </summary>
                Public Class 職種
                    ''' <summary>医師</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>歯科医師</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>獣医師</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>薬剤師</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>保健師</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>助産師</summary>
                    Public Const _06 As String = "06"
                    ''' <summary>看護師</summary>
                    Public Const _07 As String = "07"
                    ''' <summary>准看護師</summary>
                    Public Const _08 As String = "08"
                    ''' <summary>理学療法士</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>作業療法士</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>歯科衛生士</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>診療放射線技師</summary>
                    Public Const _12 As String = "12"
                    ''' <summary>診療エックス線技師</summary>
                    Public Const _13 As String = "13"
                    ''' <summary>臨床検査技師</summary>
                    Public Const _14 As String = "14"
                    ''' <summary>衛生検査技師</summary>
                    Public Const _15 As String = "15"
                    ''' <summary>管理栄養士</summary>
                    Public Const _16 As String = "16"
                    ''' <summary>栄養士</summary>
                    Public Const _17 As String = "17"
                    ''' <summary>公認心理師</summary>
                    Public Const _18 As String = "18"
                    ''' <summary>医療社会事業員</summary>
                    Public Const _19 As String = "19"
                    ''' <summary>精神保健福祉士</summary>
                    Public Const _20 As String = "20"
                    ''' <summary>精神保健福祉相談員</summary>
                    Public Const _21 As String = "21"
                    ''' <summary>栄養指導員</summary>
                    Public Const _22 As String = "22"
                    ''' <summary>食品衛生監視員</summary>
                    Public Const _23 As String = "23"
                    ''' <summary>環境衛生監視員</summary>
                    Public Const _24 As String = "24"
                    ''' <summary>医療監視員</summary>
                    Public Const _25 As String = "25"
                    ''' <summary>ヘルパー</summary>
                    Public Const _26 As String = "26"
                    ''' <summary>言語聴覚士</summary>
                    Public Const _27 As String = "27"
                    ''' <summary>運動指導士</summary>
                    Public Const _28 As String = "28"
                    ''' <summary>事務職</summary>
                    Public Const _29 As String = "29"
                    ''' <summary>保健推進委員</summary>
                    Public Const _30 As String = "30"
                    ''' <summary>民生委員</summary>
                    Public Const _31 As String = "31"
                    ''' <summary>その他</summary>
                    Public Const _99 As String = "99"
                End Class

                ''' <summary>
                ''' 活動区分
                ''' </summary>
                Public Class 活動区分
                    ''' <summary>活動中</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>休止中</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>退職</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 登録事由
                ''' </summary>
                Public Class 登録事由
                    ''' <summary>DV避難</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>成年後見人</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 金額区分
                ''' </summary>
                Public Class 金額区分
                    ''' <summary>一般</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>節目</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>老人</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>実費</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>特定</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 発行区分
                ''' </summary>
                Public Class 発行区分
                    ''' <summary>印刷未</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>印刷済</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 重要度
                ''' </summary>
                Public Class 重要度
                    ''' <summary>大</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>中</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>小</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 訪問種別（訪問結果情報）
                ''' </summary>
                Public Class 訪問種別_訪問結果情報
                    ''' <summary>健康増進</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>地域保健</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 訪問対象
                ''' </summary>
                Public Class 訪問対象
                    ''' <summary>要指導者等</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>個別健康教育対象者</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>閉じこもり予防</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>介護家族者</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>寝たきり者</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>認知症の者</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 栄養・運動等指導内容
                ''' </summary>
                Public Class 栄養_運動等指導内容
                    ''' <summary>栄養指導</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>栄養指導（病態別）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>運動指導</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>運動指導（病態別）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>休養指導</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>禁煙指導</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>その他　</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 実施区分（個別/集団）
                ''' </summary>
                Public Class 実施区分_個別_集団
                    ''' <summary>個別</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>集団</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 出欠区分
                ''' </summary>
                Public Class 出欠区分
                    ''' <summary>出席</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>欠席</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 相談内容
                ''' </summary>
                Public Class 相談内容
                    ''' <summary>高血圧</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>脂質異常症</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>糖尿病</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>歯周疾患</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>骨粗鬆症</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>女性の健康</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>病態別</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>総合健康相談</summary>
                    Public Const _8 As String = "8"
                End Class

                ''' <summary>
                ''' 個別健康教育対象者区分
                ''' </summary>
                Public Class 個別健康教育対象者区分
                    ''' <summary>対象者（ア）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>対象者（イ）</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 個別健康教育内容
                ''' </summary>
                Public Class 個別健康教育内容
                    ''' <summary>高血圧</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>脂質異常症</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>糖尿病</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>喫煙</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 個別健康教育状態区分
                ''' </summary>
                Public Class 個別健康教育状態区分
                    ''' <summary>初回</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>継続</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>終了</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 個別健康教育実施形態
                ''' </summary>
                Public Class 個別健康教育実施形態
                    ''' <summary>市区町村実施</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>医療機関委託</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 集団健康教育内容
                ''' </summary>
                Public Class 集団健康教育内容
                    ''' <summary>一般</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>歯周疾患</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>ロコモティブシンドローム（運動器症候群）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>慢性閉塞性肺疾患</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>病態別</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>薬</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' 把握経路（フォロー状況情報）
                ''' </summary>
                Public Class 把握経路_フォロー状況情報
                    ''' <summary>訪問</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>電話</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>教室</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>健診</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' フォロー方法
                ''' </summary>
                Public Class フォロー方法
                    ''' <summary>訪問</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>電話</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>教室</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>健診</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' フォロー状況
                ''' </summary>
                Public Class フォロー状況
                    ''' <summary>フォロー済</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>フォロー中</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 成人保健の受診希望
                ''' </summary>
                Public Class 成人保健の受診希望
                    ''' <summary>未回答</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>受ける</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>受けない</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 過去の受診歴
                ''' </summary>
                Public Class 過去の受診歴
                    ''' <summary>前年度に受けた</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>前々年度に受けた</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>前々々年度に受けた</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>なしまたは「３：前々々年度」より前に受けた</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>わからない</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 自治体検診の問診における有無の回答（三択）
                ''' </summary>
                Public Class 自治体検診の問診における有無の回答_三択
                    ''' <summary>いいえ</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>はい</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>わからない</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' がん検診による偶発症の有無
                ''' </summary>
                Public Class がん検診による偶発症の有無
                    ''' <summary>なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>検診中または検診後に重篤な偶発症あり（３以外）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary> 「２．検診中または検診後に重篤な偶発症あり」のうち偶発症による死亡あり</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' がん検診の精密検査による偶発症の有無
                ''' </summary>
                Public Class がん検診の精密検査による偶発症の有無
                    ''' <summary>なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>精密検査中または精密検査後に重篤な偶発症あり（３以外）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary> 「２．精密検査中または精密検査後に重篤な偶発症あり」のうち偶発症による死亡あり</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 血液判断
                ''' </summary>
                Public Class 血液判断
                    ''' <summary>検査なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>空腹時</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>随時</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>不詳</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 胃がん検診の精密検査の対象有無
                ''' </summary>
                Public Class 胃がん検診の精密検査の対象有無
                    ''' <summary>精密検査不要</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要精密検査（胃がん疑い）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>判定不能</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 胃がん検診の検査方法
                ''' </summary>
                Public Class 胃がん検診の検査方法
                    ''' <summary>Ｘ線検査</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>内視鏡検査</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 所見有無
                ''' </summary>
                Public Class 所見有無
                    ''' <summary>所見なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>所見あり</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 胃がん検診の精密検査結果
                ''' </summary>
                Public Class 胃がん検診の精密検査結果
                    ''' <summary>異常認めず</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>胃がんであった者（転移性を含まない）（3、4以外）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>「2：胃がんであった者」のうち早期がん（4以外）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>「3：胃がんでうち早期がん」のうち粘膜内がん</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>胃がんの疑いのある者または未確定</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>胃がん以外の疾患であった者（転移性の胃がんを含む）</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>未受診（不適切受診を含む）</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 肺がん検診の精密検査対象有無
                ''' </summary>
                Public Class 肺がん検診の精密検査対象有無
                    ''' <summary>精密検査不要</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要精密検査（肺がん疑い）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>判定不能</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 肺がん検診の胸部エックス線検査判定
                ''' </summary>
                Public Class 肺がん検診の胸部エックス線検査判定
                    ''' <summary>Ｂ（異常所見を認めない）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>Ｃ（異常所見を認めるが精査を必要としない）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>Ｄ（異常所見を認め、肺癌以外の疾患で治療を要する状態が考えられる）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>Ｅ（肺癌の疑い）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>Ａ（読影不能）</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 肺がん検診の喀痰検査判定
                ''' </summary>
                Public Class 肺がん検診の喀痰検査判定
                    ''' <summary>Ｂ（正常上皮細胞のみ、基底細胞増生、軽度異型扁平上皮化細胞、線毛円柱上皮細胞）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>Ｃ（中等度異型扁平上皮細胞、核の増大や濃染を伴う円柱上皮細胞）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>Ｄ（高度（境界）異型扁平上皮細胞または悪性腫瘍が疑われる細胞を認める）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>Ｅ（悪性腫瘍細胞を認める）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>Ａ（喀痰中に組織球を認めない）</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 肺がん検診の精密検査判定
                ''' </summary>
                Public Class 肺がん検診の精密検査判定
                    ''' <summary>異常認めず</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>肺がんであった者（転移性を含まない）（３以外）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>「２：肺がんであった者」のうち臨床病期 0～Ⅰ期</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>肺がんの疑いのある者または未確定</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>肺がん以外の疾患であった者（転移性の肺がんを含む）</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>未受診（不適切受診を含む）</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 子宮頸がん検診の精密検査判定
                ''' </summary>
                Public Class 子宮頸がん検診の精密検査判定
                    ''' <summary>異常認めず</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>子宮頸がんであった者（転移性を含まない）（３以外）</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>「２：子宮頸がんであった者」のうち進行度がⅠA 期のがん</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>AIS であった者</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>CIN3 であった者</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>CIN2 であった者</summary>
                    Public Const _06 As String = "06"
                    ''' <summary>CIN3 または CIN2 のいずれかで区別できない者(HSIL)</summary>
                    Public Const _07 As String = "07"
                    ''' <summary>CIN1 であった者</summary>
                    Public Const _08 As String = "08"
                    ''' <summary>子宮頸がんの疑いのある者または未確定</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>子宮頸がん、AIS 及び CIN 以外の疾患であった者（転移性の子宮頸がんを含む）</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>未受診（不適切受診を含む）</summary>
                    Public Const _99 As String = "99"
                End Class

                ''' <summary>
                ''' 子宮頸がん検診の頸部細胞診検査判定
                ''' </summary>
                Public Class 子宮頸がん検診の頸部細胞診検査判定
                    ''' <summary>NILM（陰性）</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>ASC-US（意義不明異型扁平上皮）</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>ASC-H（高度病変を除外できない異型扁平上皮）</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>LSIL（軽度扁平上皮内病変）</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>HSIL（高度扁平上皮内病変）</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>SCC（扁平上皮癌）</summary>
                    Public Const _06 As String = "06"
                    ''' <summary>AGC（異型腺細胞）</summary>
                    Public Const _07 As String = "07"
                    ''' <summary>AIS（上皮内腺癌）</summary>
                    Public Const _08 As String = "08"
                    ''' <summary>Adenocarcinoma（腺癌）</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>Other（その他の悪性腫瘍）</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>判定不能</summary>
                    Public Const _99 As String = "99"
                End Class

                ''' <summary>
                ''' 子宮頸がん検診の精密検査の対象有無
                ''' </summary>
                Public Class 子宮頸がん検診の精密検査の対象有無
                    ''' <summary>精密検査不要</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要精密検査（子宮頸がん疑い）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>判定不能</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 初回検体の適否
                ''' </summary>
                Public Class 初回検体の適否
                    ''' <summary>適正（判定可能）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>不適正（判定不可能）・再検査</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 骨粗鬆症検診の精密検査判定
                ''' </summary>
                Public Class 骨粗鬆症検診の精密検査判定
                    ''' <summary>異常を認めず</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>骨量減少であった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>骨粗鬆症であった</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>骨粗鬆症以外であった</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>未受診（不適切受診を含む）</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 過去の検査判定
                ''' </summary>
                Public Class 過去の検査判定
                    ''' <summary>異常を認めず</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>骨量減少であった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>骨粗鬆症であった</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>わからない</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 過去の精密検査の対象有無
                ''' </summary>
                Public Class 過去の精密検査の対象有無
                    ''' <summary>対象外</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要指導</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>要精密検査</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>わからない</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 喫煙習慣
                ''' </summary>
                Public Class 喫煙習慣
                    ''' <summary>喫煙したことはない</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>過去に喫煙していたが、現在は禁煙している</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>現在喫煙している</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' ステロイド内服
                ''' </summary>
                Public Class ステロイド内服
                    ''' <summary>内服したことはない</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>過去に内服していた</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>現在内服している</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 活動量（運動頻度）
                ''' </summary>
                Public Class 活動量_運動頻度
                    ''' <summary>週３回以上</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>週２回程度</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>週１回程度</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>月１から２回</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>月1回未満</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 月経の有無
                ''' </summary>
                Public Class 月経の有無
                    ''' <summary>ほぼ順調にある</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>時々ある</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>１年以上ない</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 閉経の理由
                ''' </summary>
                Public Class 閉経の理由
                    ''' <summary>自然閉経</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>子宮のみ摘出</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>両側卵巣のみ摘出</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>子宮および片側卵巣摘出</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>子宮および両側卵巣摘出</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>その他</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>閉経していない</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 骨粗鬆症検診の検査判定
                ''' </summary>
                Public Class 骨粗鬆症検診の検査判定
                    ''' <summary>異常を認めず</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>骨量減少範囲</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>骨粗鬆症範囲</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>判定不能</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 歯周疾患検診の精密検査判定
                ''' </summary>
                Public Class 歯周疾患検診の精密検査判定
                    ''' <summary>異常を認めず</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>歯周疾患であった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>歯周疾患以外であった</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>未受診（不適切受診を含む）</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 歯周疾患検診の精密検査の対象有無
                ''' </summary>
                Public Class 歯周疾患検診の精密検査の対象有無
                    ''' <summary>異常を認めず</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要指導</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>要精密検査</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>判定不能</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 歯をみがく頻度
                ''' </summary>
                Public Class 歯をみがく頻度
                    ''' <summary>毎日みがく（１回）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>毎日みがく（２回）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>毎日みがく（３回以上）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>ときどきみがく</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>みがかない</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 歯間ブラシやフロスの使用頻度
                ''' </summary>
                Public Class 歯間ブラシやフロスの使用頻度
                    ''' <summary>毎日</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>時々</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>いいえ</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>使っていない</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 喫煙歴
                ''' </summary>
                Public Class 喫煙歴
                    ''' <summary>吸っていない</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>吸っている</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 歯肉出血ＢＯＰ
                ''' </summary>
                Public Class 歯肉出血ＢＯＰ
                    ''' <summary>健全</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>出血あり</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>除外歯</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>該当歯なし</summary>
                    Public Const _X As String = "X"
                End Class

                ''' <summary>
                ''' 歯周ポケットＰＤ
                ''' </summary>
                Public Class 歯周ポケットＰＤ
                    ''' <summary>４ｍｍ未満</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>４ｍｍ以上６ｍｍ未満</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>６ｍｍ以上</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>除外歯</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>該当歯なし</summary>
                    Public Const _X As String = "X"
                End Class

                ''' <summary>
                ''' 歯石の付着
                ''' </summary>
                Public Class 歯石の付着
                    ''' <summary>なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>軽度（点状）あり</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>中程度（帯状）以上あり</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 口腔清掃状態
                ''' </summary>
                Public Class 口腔清掃状態
                    ''' <summary>良好</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>普通</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>不良</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 便潜血検査判定
                ''' </summary>
                Public Class 便潜血検査判定
                    ''' <summary>陰性</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>陽性</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>判定不能</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 大腸がん検診の精密検査の対象有無
                ''' </summary>
                Public Class 大腸がん検診の精密検査の対象有無
                    ''' <summary>精密検査不要</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要精密検査（大腸がん疑い）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>判定不能</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 大腸がん検診の精密検査判定
                ''' </summary>
                Public Class 大腸がん検診の精密検査判定
                    ''' <summary>異常認めず</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>大腸がんであった者（転移性を含まない）（３，４を除く）</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>「２：大腸がんであった者」のうち早期がん（４を除く）</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>「３：大腸がんのうち早期がん」のうち粘膜内がん</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>大腸がんの疑いのある者または未確定</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>腺腫のあった者（７，８を除く）</summary>
                    Public Const _06 As String = "06"
                    ''' <summary>「６：腺腫であった者」のうち直径 10 ㎜以上の腺腫であったもの</summary>
                    Public Const _07 As String = "07"
                    ''' <summary>「６：腺腫であった者」のうち直径 10 ㎜未満であった者</summary>
                    Public Const _08 As String = "08"
                    ''' <summary>大腸がん及び腺腫以外の疾患であった者（転移性の大腸がんを含む）</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>未受診（不適切受診を含む）</summary>
                    Public Const _10 As String = "10"
                End Class

                ''' <summary>
                ''' 乳がん検診のマンモグラフィー検査判定
                ''' </summary>
                Public Class 乳がん検診のマンモグラフィー検査判定
                    ''' <summary>カテゴリー１（異常なし）</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>カテゴリー２（良性）</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>カテゴリー３（良性、しかし悪性を否定できず）</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>カテゴリー４（悪性の疑い）</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>カテゴリー５（悪性）</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>カテゴリーＮ－１（要再撮影）</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>カテゴリーＮ－２（判定は他の検査方法による）</summary>
                    Public Const _99 As String = "99"
                End Class

                ''' <summary>
                ''' 乳がん検診の精密検査対象有無
                ''' </summary>
                Public Class 乳がん検診の精密検査対象有無
                    ''' <summary>精密検査不要</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要精密検査（乳がん疑い）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>判定不能</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 乳がん検診_マンモグラフィー検査一次読影
                ''' </summary>
                Public Class 乳がん検診_マンモグラフィー検査一次読影
                    ''' <summary>異常なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>良性</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>良性、しかし悪性を否定できず</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>悪性の疑い</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>悪性</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>要再撮影</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>判定は他の検査法による</summary>
                    Public Const _7 As String = "7"
                End Class

                ''' <summary>
                ''' 乳がん検診_マンモグラフィー検査二次読影
                ''' </summary>
                Public Class 乳がん検診_マンモグラフィー検査二次読影
                    ''' <summary>異常なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>良性</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>良性、しかし悪性を否定できず</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>悪性の疑い</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>悪性</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>要再撮影</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>判定は他の検査法による</summary>
                    Public Const _7 As String = "7"
                End Class

                ''' <summary>
                ''' 乳がん検診の精密検査結果
                ''' </summary>
                Public Class 乳がん検診の精密検査結果
                    ''' <summary>異常認めず</summary>
                    Public Const _1 As String = "1"
                    ''' <summary> 乳がんであった者（転移性を含まない）（３，４以外）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary> 「２：乳がんであった者」のうち早期がん（４以外）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary> 「３：乳がんのうち早期がん」のうち非浸潤がん</summary>
                    Public Const _4 As String = "4"
                    ''' <summary> 乳がんの疑いのある者または未確定</summary>
                    Public Const _5 As String = "5"
                    ''' <summary> 乳がん以外の疾患であった者（転移性の乳がんを含む）</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>未受診（不適切受診を含む）</summary>
                    Public Const _7 As String = "7"
                End Class

                ''' <summary>
                ''' 肝炎ウイルス検診のB 型肝炎ウイルス検査判定
                ''' </summary>
                Public Class 肝炎ウイルス検診のB_型肝炎ウイルス検査判定
                    ''' <summary>陰性</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>陽性</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>検査を受けず</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 肝炎ウイルス検診のC 型肝炎ウイルス検査判定
                ''' </summary>
                Public Class 肝炎ウイルス検診のC_型肝炎ウイルス検査判定
                    ''' <summary>現在、Ｃ型肝炎ウイルスに感染している可能性が低い</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>現在、Ｃ型肝炎ウイルスに感染している可能性が高い</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>検査を受けず</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 肝炎ウイルス検診の精密検査判定
                ''' </summary>
                Public Class 肝炎ウイルス検診の精密検査判定
                    ''' <summary> 無症候性キャリア（ B 型肝炎ウイルス・ C 型肝炎ウイルス）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary> 慢性肝炎（ B 型肝炎ウイルスによる・ C 型肝炎ウイルスによる）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary> 肝硬変（ B 型肝炎ウイルスによる・ C 型肝炎ウイルスによる）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary> 肝がん（ B 型肝炎ウイルスによる・ C 型肝炎ウイルスによる）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>その他</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' C型判定理由
                ''' </summary>
                Public Class C型判定理由
                    ''' <summary>①</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>②</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>③</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>④</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>⑤</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 届出事由
                ''' </summary>
                Public Class 届出事由
                    ''' <summary>新規</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>転入</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 届出時期（不詳含む）
                ''' </summary>
                Public Class 届出時期_不詳含む
                    ''' <summary>満11週以内(第3月以内)</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>満12週～19週(第4月～第5月)</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>満20週～27週(第6月～第7月)</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>満28週～分娩まで(第8月～分娩まで)</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>分娩後</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>不詳</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' 交付事由
                ''' </summary>
                Public Class 交付事由
                    ''' <summary>新規</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>転入</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>母子手帳再発行</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 受診区分(妊婦健診結果)
                ''' </summary>
                Public Class 受診区分_妊婦健診結果
                    ''' <summary>受診</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>他自治体で受診</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 境界区分
                ''' </summary>
                Public Class 境界区分
                    ''' <summary>－</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>±</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>＋</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' ABO型
                ''' </summary>
                Public Class ABO型
                    ''' <summary>A</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>B</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>O</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>AB</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' RH型
                ''' </summary>
                Public Class RH型
                    ''' <summary>＋</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>－</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 境界区分４
                ''' </summary>
                Public Class 境界区分４
                    ''' <summary>－</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>＋</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 境界区分２
                ''' </summary>
                Public Class 境界区分２
                    ''' <summary>陰性</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>陽性</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 風疹抗体
                ''' </summary>
                Public Class 風疹抗体
                    ''' <summary>予防接種要相談</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>免疫あり</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 子宮頸がん検診
                ''' </summary>
                Public Class 子宮頸がん検診
                    ''' <summary>精密検査不要</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要精密検査</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>判定不能（要再検査）</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 承認区分
                ''' </summary>
                Public Class 承認区分
                    ''' <summary>承認</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>否認</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 訪問理由
                ''' </summary>
                Public Class 訪問理由
                    ''' <summary>身体障害者（児）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>知的障害者（児）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>精神障害者</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 妊産婦区分
                ''' </summary>
                Public Class 妊産婦区分
                    ''' <summary>妊婦</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>産婦</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 歯科判定
                ''' </summary>
                Public Class 歯科判定
                    ''' <summary>異常認めず</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要観察</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>要検査</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>要指導</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>要精検</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>要治療</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' 妊婦歯科歯肉の炎症
                ''' </summary>
                Public Class 妊婦歯科歯肉の炎症
                    ''' <summary>なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>あり（要指導）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>あり（要治療）</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 精密検査判定
                ''' </summary>
                Public Class 精密検査判定
                    ''' <summary>異常を認めず</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>歯周疾患であった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>歯周疾患以外であった</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 精密検査結果
                ''' </summary>
                Public Class 精密検査結果
                    ''' <summary>異常なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>経過観察</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>要医療</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 産婦健診判定
                ''' </summary>
                Public Class 産婦健診判定
                    ''' <summary>問題なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要指導</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>要精密検査</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>要経過観察</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>要医療</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 利用サービス
                ''' </summary>
                Public Class 利用サービス
                    ''' <summary>宿泊型</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>日帰り型</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>訪問型</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 栄養方法（新生児期）
                ''' </summary>
                Public Class 栄養方法_新生児期
                    ''' <summary>母乳</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>人工乳</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>混合</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 先天性代謝異常等検査
                ''' </summary>
                Public Class 先天性代謝異常等検査
                    ''' <summary>正常</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要精密検査</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>受けていない</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>検査結果不明</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 聴覚検査方式
                ''' </summary>
                Public Class 聴覚検査方式
                    ''' <summary>AABR</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>ABR</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>OAE</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>不明</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 聴覚検査結果
                ''' </summary>
                Public Class 聴覚検査結果
                    ''' <summary>パス</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>リファー</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>受けていない</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>不明</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 聴覚検査判定
                ''' </summary>
                Public Class 聴覚検査判定
                    ''' <summary>正常</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>一側性難聴</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>両側難聴</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>評価不能</summary>
                    Public Const _9 As String = "9"
                    ''' <summary>受けていない</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 助成券種類
                ''' </summary>
                Public Class 助成券種類
                    ''' <summary>自動ABR・ABR検査</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>OAE検査</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 実施区分
                ''' </summary>
                Public Class 実施区分
                    ''' <summary>個別</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>集団</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 歳児別健診判定
                ''' </summary>
                Public Class 歳児別健診判定
                    ''' <summary>異常なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>既医療</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>要経過観察</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>要紹介（要精密）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>要紹介（要治療）</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 眼科の判定
                ''' </summary>
                Public Class 眼科の判定
                    ''' <summary>異常なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>既医療</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>要経過観察</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>要精密検査</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 耳鼻科の判定
                ''' </summary>
                Public Class 耳鼻科の判定
                    ''' <summary>異常なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>既医療</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>要経過観察</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>要精密検査</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 栄養
                ''' </summary>
                Public Class 栄養
                    ''' <summary>良</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要指導</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 母乳
                ''' </summary>
                Public Class 母乳
                    ''' <summary>飲んでいない</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>飲んでいる</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 離乳
                ''' </summary>
                Public Class 離乳
                    ''' <summary>完了</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>未完了</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 乳幼児健診アンケート回答（仕上げ磨き）
                ''' </summary>
                Public Class 乳幼児健診アンケート回答_仕上げ磨き
                    ''' <summary>仕上げ磨きをしている</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>保護者だけで磨いている</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>子どもだけで磨いている</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>子どもも保護者も磨いていない</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 乳幼児健診アンケート回答（はい・いいえ・無回答）
                ''' </summary>
                Public Class 乳幼児健診アンケート回答_はい_いいえ_無回答
                    ''' <summary>はい</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>いいえ</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 乳幼児健診アンケート回答（子育て）
                ''' </summary>
                Public Class 乳幼児健診アンケート回答_子育て
                    ''' <summary>そう思う</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>どちらかといえばそう思う</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>どちらかといえばそう思わない</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>そう思わない</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 乳幼児健診アンケート回答（父親育児）
                ''' </summary>
                Public Class 乳幼児健診アンケート回答_父親育児
                    ''' <summary>よくやっている</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>時々やっている</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>ほとんどしない</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>何ともいえない</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 乳幼児健診アンケート回答（浴室ドア）
                ''' </summary>
                Public Class 乳幼児健診アンケート回答_浴室ドア
                    ''' <summary>はい</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>いいえ</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>該当しない</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 乳幼児健診アンケート回答（はい・いいえ・何ともいえない・無回答）
                ''' </summary>
                Public Class 乳幼児健診アンケート回答_はい_いいえ_何ともいえない_無回答
                    ''' <summary>はい</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>いいえ</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>何ともいえない</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 乳幼児健診アンケート回答（育てにくさ）
                ''' </summary>
                Public Class 乳幼児健診アンケート回答_育てにくさ
                    ''' <summary>いつも感じる</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>時々感じる</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>感じない</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 罹患型１
                ''' </summary>
                Public Class 罹患型１
                    ''' <summary>Ｏ１</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>Ｏ２</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>Ａ</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>Ｂ</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>Ｃ</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' むし歯の状態_3歳児健診結果
                ''' </summary>
                Public Class むし歯の状態_3歳児健診結果
                    ''' <summary>むし歯なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>むし歯あり</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 不正咬合
                ''' </summary>
                Public Class 不正咬合
                    ''' <summary>なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>あり</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 産後ケア
                ''' </summary>
                Public Class 産後ケア
                    ''' <summary>はい</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>いいえ</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>どちらとも言えない</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 栄養法_3～4か月児健診結果
                ''' </summary>
                Public Class 栄養法_3から4か月児健診結果
                    ''' <summary>母乳</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>人工乳</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>混合</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 罹患型２
                ''' </summary>
                Public Class 罹患型２
                    ''' <summary>Ｏ</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>Ａ</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>Ｂ</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>Ｃ１</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>Ｃ２</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 所見または今後の処置
                ''' </summary>
                Public Class 所見または今後の処置
                    ''' <summary>異常なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要経過観察</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>要医療</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 勧奨方法
                ''' </summary>
                Public Class 勧奨方法
                    ''' <summary>家庭訪問</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>電話</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>電子メール</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>来庁（はがき・手紙）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>拒否</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 訪問種別（訪問情報）
                ''' </summary>
                Public Class 訪問種別_訪問情報
                    ''' <summary>妊婦</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>産婦</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>新生児（未熟児を除く。）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>未熟児</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>乳児（新生児・未熟児を除く。）</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>幼児</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 笑うことができたし、物事の面白い面もわかった
                ''' </summary>
                Public Class 笑うことができたし_物事の面白い面もわかった
                    ''' <summary>いつもと同様にできた</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>あまりできなかった</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>明らかにできなかった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>全くできなかった</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 物事を楽しみにして待った
                ''' </summary>
                Public Class 物事を楽しみにして待った
                    ''' <summary>いつもと同様にできた</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>あまりできなかった</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>明らかにできなかった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>ほとんどできなかった</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 物事がうまくいかない時、自分を不必要に責めた
                ''' </summary>
                Public Class 物事がうまくいかない時_自分を不必要に責めた
                    ''' <summary>いいえ、全くそうではなかった</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>いいえ、あまり度々ではなかった</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>はい、時々そうだった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>はい、たいていそうだった</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' はっきりとした理由もないのに不安になったり、心配したりした
                ''' </summary>
                Public Class はっきりとした理由もないのに不安になったり_心配したりした
                    ''' <summary>いいえ、そうではなかった</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>ほとんどそうではなかった</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>はい、時々あった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>はい、しょっちゅうあった</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' はっきりとした理由もないのに恐怖に襲われた
                ''' </summary>
                Public Class はっきりとした理由もないのに恐怖に襲われた
                    ''' <summary>いいえ、そうではなかった</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>ほとんどそうではなかった</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>はい、時々あった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>はい、しょっちゅうあった</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' することがたくさんあって大変だった
                ''' </summary>
                Public Class することがたくさんあって大変だった
                    ''' <summary>いいえ、普段通りに対処した</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>いいえ、たいていうまく対処した</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>はい、いつものようにうまく対処できなかった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>はい、たいてい対処できなかった</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 不幸せな気分なので、眠りにくかった
                ''' </summary>
                Public Class 不幸せな気分なので_眠りにくかった
                    ''' <summary>いいえ、全くそうではなかった</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>いいえ、あまり度々ではなかった</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>はい、時々そうだった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>はい、ほとんどいつもそうだった</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 悲しくなったり、惨めになったりした
                ''' </summary>
                Public Class 悲しくなったり_惨めになったりした
                    ''' <summary>いいえ、全くそうではなかった</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>いいえ、あまり度々ではなかった</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>はい、かなりしばしばそうだった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>はい、たいていそうだった</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 不幸せな気分だったので、泣いていた
                ''' </summary>
                Public Class 不幸せな気分だったので_泣いていた
                    ''' <summary>いいえ、全くそうではなかった</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>ほんの時々あった</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>はい、かなりしばしばそうだった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>はい、たいていそうだった</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 自分自身を傷つけるという考えが浮かんできた
                ''' </summary>
                Public Class 自分自身を傷つけるという考えが浮かんできた
                    ''' <summary>全くなかった</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>めったになかった</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>時々そうだった</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>はい、かなりしばしばそうだった</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 保健指導_対象者区分
                ''' </summary>
                Public Class 保健指導_対象者区分
                    ''' <summary>妊婦</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>産婦</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>乳児</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>幼児</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 健康増進_実施対象者
                ''' </summary>
                Public Class 健康増進_実施対象者
                    ''' <summary>妊産婦</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>乳幼児</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>20歳未満</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>20歳以上</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 同伴者
                ''' </summary>
                Public Class 同伴者
                    ''' <summary>母親同伴</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>父親同伴</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>その他同伴</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 階層区分
                ''' </summary>
                Public Class 階層区分
                    ''' <summary>Ａ</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>Ｂ</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>Ｃ</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>Ｃ１</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>Ｃ２</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>Ｄ１</summary>
                    Public Const _06 As String = "06"
                    ''' <summary>Ｄ２</summary>
                    Public Const _07 As String = "07"
                    ''' <summary>Ｄ３</summary>
                    Public Const _08 As String = "08"
                    ''' <summary>Ｄ４</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>Ｄ５</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>Ｄ６</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>Ｄ７</summary>
                    Public Const _12 As String = "12"
                    ''' <summary>Ｄ８</summary>
                    Public Const _13 As String = "13"
                    ''' <summary>Ｄ９</summary>
                    Public Const _14 As String = "14"
                    ''' <summary>Ｄ１０</summary>
                    Public Const _15 As String = "15"
                    ''' <summary>Ｄ１１</summary>
                    Public Const _16 As String = "16"
                    ''' <summary>Ｄ１２</summary>
                    Public Const _17 As String = "17"
                    ''' <summary>Ｄ１３</summary>
                    Public Const _18 As String = "18"
                    ''' <summary>Ｄ１４</summary>
                    Public Const _19 As String = "19"
                    ''' <summary>Ｄ１５</summary>
                    Public Const _20 As String = "20"
                End Class

                ''' <summary>
                ''' 加算対象
                ''' </summary>
                Public Class 加算対象
                    ''' <summary>第一子</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>第二子以降</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 申請区分
                ''' </summary>
                Public Class 申請区分
                    ''' <summary>新規</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>更新</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>変更</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>転院</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>再交付</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>喪失</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' 申請変更理由
                ''' </summary>
                Public Class 申請変更理由
                    ''' <summary>変更</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>転居</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>氏名</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>保険証</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>自己負担額変更</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 保険区分
                ''' </summary>
                Public Class 保険区分
                    ''' <summary>なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>国保</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>協会けんぽ</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>共済</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>組合</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>生保</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>船員</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 課税区分（養育医療申請情報）
                ''' </summary>
                Public Class 課税区分_養育医療申請情報
                    ''' <summary>生活保護</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>市民税非課税</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>均等割のみ課税</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>課税</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 申請者（扶養義務者）続柄
                ''' </summary>
                Public Class 申請者_扶養義務者_続柄
                    ''' <summary>父</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>母</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>祖父</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>祖母</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>叔父・伯父</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>叔母・伯母</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>本人</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 判定結果
                ''' </summary>
                Public Class 判定結果
                    ''' <summary>承認</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>不承認</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' レセプト区分
                ''' </summary>
                Public Class レセプト区分
                    ''' <summary>通常</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>調整</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>過誤</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 予防接種の実施方式
                ''' </summary>
                Public Class 予防接種の実施方式
                    ''' <summary>集団</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>個別</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>住所地外</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>転入前</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 接種区分
                ''' </summary>
                Public Class 接種区分
                    ''' <summary>接種</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>予診のみ</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 特別の事情
                ''' </summary>
                Public Class 特別の事情
                    ''' <summary>規定疾病</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>臓器の移植術</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>医学的知見</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>新型コロナウイルス</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>災害・供給不足等</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 単位
                ''' </summary>
                Public Class 単位
                    ''' <summary>倍</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>EIA価</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>IU/mL</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 接種判定
                ''' </summary>
                Public Class 接種判定
                    ''' <summary>接種対象（陰性）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>接種対象外（陽性）</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 抗体検査方法
                ''' </summary>
                Public Class 抗体検査方法
                    ''' <summary>赤血球凝集抑制法（ＨＩ法）</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>酵素免疫法（ＥＩＡ法）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>ラテックス免疫比濁法（ＬＴＩ法）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>蛍光酵素免疫法（ＥＬＦＡ法）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>化学発光酵素免疫法（ＣＬＥＩＡ法）</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>蛍光免疫測定法（ＦＩＡ法）</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>化学発光免疫測定法（ＣＬＩＡ法）</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>イムノクロマト法（ＩＣＡ法）</summary>
                    Public Const _8 As String = "8"
                End Class

                ''' <summary>
                ''' 抗体検査番号
                ''' </summary>
                Public Class 抗体検査番号
                    ''' <summary>検査番号１</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>検査番号２</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>検査番号３</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>検査番号４</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>検査番号５</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>検査番号６</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' 認定区分
                ''' </summary>
                Public Class 認定区分
                    ''' <summary>認定</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>否認</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 給付の種類
                ''' </summary>
                Public Class 給付の種類
                    ''' <summary>医療費及び医療手当</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>障害児養育年金</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>障害年金</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>死亡一時金</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>遺族年金</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>遺族一時金</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>葬祭料</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>年金額変更</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>未支給給付</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 住民種別
                ''' </summary>
                Public Class 住民種別
                    ''' <summary>日本人住民</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>外国人住民</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 住民状態
                ''' </summary>
                Public Class 住民状態
                    ''' <summary>住登外者</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>住登外死亡者</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>その他消除者</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 骨粗鬆症検診の一次検診判定
                ''' </summary>
                Public Class 骨粗鬆症検診の一次検診判定
                    ''' <summary>異常を認めず</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要指導</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>要精密検査</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>判定不能</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 大腿骨近位部骨折の家族歴
                ''' </summary>
                Public Class 大腿骨近位部骨折の家族歴
                    ''' <summary>なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>あり</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>わからない</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 予防接種区分
                ''' </summary>
                Public Class 予防接種区分
                    ''' <summary>定期接種</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>任意接種</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>臨時接種</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 健やか親子21アンケート回答（心身の調子）
                ''' </summary>
                Public Class 健やか親子21アンケート回答_心身の調子
                    ''' <summary>良好</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>やや良好</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>どちらともいえない</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>ややよくない</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>よくない</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 健やか親子21アンケート回答（経済的状況）
                ''' </summary>
                Public Class 健やか親子21アンケート回答_経済的状況
                    ''' <summary>大変ゆとりがある</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>ややゆとりがある</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>普通</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>やや苦しい</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>大変苦しい</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 健やか親子21アンケート回答（朝起きる時間）
                ''' </summary>
                Public Class 健やか親子21アンケート回答_朝起きる時間
                    ''' <summary>5時よりまえ</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>5時台</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>6時台</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>7時台</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>8時台</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>9時台</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>10時台</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>11時以降</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 健やか親子21アンケート回答（夜寝る時間）
                ''' </summary>
                Public Class 健やか親子21アンケート回答_夜寝る時間
                    ''' <summary>18時よりまえ</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>18時台</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>19時台</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>20時台</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>21時台</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>22時台</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>23時台</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>24時以降</summary>
                    Public Const _8 As String = "8"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 健やか親子21アンケート回答（なし・あり・無回答）
                ''' </summary>
                Public Class 健やか親子21アンケート回答_なし_あり_無回答
                    ''' <summary>なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>あり</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 健やか親子21アンケート回答（あり・なし・無回答）
                ''' </summary>
                Public Class 健やか親子21アンケート回答_あり_なし_無回答
                    ''' <summary>あり</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>なし</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 健やか親子21アンケート回答（働いていたことがある）
                ''' </summary>
                Public Class 健やか親子21アンケート回答_働いていたことがある
                    ''' <summary>働いていたことがある</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>働いていない</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 健やか親子21アンケート回答（利用したことがある）
                ''' </summary>
                Public Class 健やか親子21アンケート回答_利用したことがある
                    ''' <summary>利用したことがある</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>利用したことはない</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' マタニティマークアンケート回答（知らなかった・知っていた）
                ''' </summary>
                Public Class マタニティマークアンケート回答_知らなかった_知っていた
                    ''' <summary>知らなかった</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>知っていた</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 乳幼児歯科健診判定
                ''' </summary>
                Public Class 乳幼児歯科健診判定
                    ''' <summary>問題なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要指導</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>要経過観察</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>要治療</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 育児支援チェックリスト回答1～3、4（3）また5～9
                ''' </summary>
                Public Class 育児支援チェックリスト回答1から3_4_3_また5から9
                    ''' <summary>はい</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>いいえ</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 育児支援チェックリスト回答4（1）
                ''' </summary>
                Public Class 育児支援チェックリスト回答4_1
                    ''' <summary>はい</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>いいえ</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>夫がいない</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 育児支援チェックリスト回答4（2）
                ''' </summary>
                Public Class 育児支援チェックリスト回答4_2
                    ''' <summary>はい</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>いいえ</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>実母がいない</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 赤ちゃんへの気持ち質問票回答１
                ''' </summary>
                Public Class 赤ちゃんへの気持ち質問票回答１
                    ''' <summary>ほとんどいつも強くそう感じる</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>たまに強くそう感じる</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>たまに少しそう感じる</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>全然そう感じない</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 赤ちゃんへの気持ち質問票回答２
                ''' </summary>
                Public Class 赤ちゃんへの気持ち質問票回答２
                    ''' <summary>全然そう感じない</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>たまに少しそう感じる</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>たまに強くそう感じる</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>ほとんどいつも強くそう感じる</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 点数表コード
                ''' </summary>
                Public Class 点数表コード
                    ''' <summary>医科</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>歯科</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>調剤</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>訪問看護</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' 療養・食事コード
                ''' </summary>
                Public Class 療養_食事コード
                    ''' <summary>療養給付分</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>食事（生活）療養費分</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 歯式コード（妊産婦）
                ''' </summary>
                Public Class 歯式コード_妊産婦
                    ''' <summary>健全歯（／）　</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>未処置歯（Ｃ）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>処置歯（○）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>要補綴歯（△）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>欠損補綴歯（▲）</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>補綴不要欠損歯数（×）</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' 歯式コード（子供）
                ''' </summary>
                Public Class 歯式コード_子供
                    ''' <summary>健全歯（／）　</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要観察歯（ＣＯ）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>未処置歯（Ｃ）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>処置歯（○）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>喪失歯（△）</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' 住登外者異動事由
                ''' </summary>
                Public Class 住登外者異動事由
                    ''' <summary>記載_国内転入</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>記載_国外転入等</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>記載_出生</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>記載_職権記載（帰化等）</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>記載_職権記載（国籍喪失）</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>記載_職権記載</summary>
                    Public Const _06 As String = "06"
                    ''' <summary>記載_改製</summary>
                    Public Const _07 As String = "07"
                    ''' <summary>記載_再製</summary>
                    Public Const _08 As String = "08"
                    ''' <summary>記載_異動の取消し（増）</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>消除_国内転出</summary>
                    Public Const _21 As String = "21"
                    ''' <summary>消除_国外転出</summary>
                    Public Const _22 As String = "22"
                    ''' <summary>消除_死亡</summary>
                    Public Const _23 As String = "23"
                    ''' <summary>消除_職権消除（帰化等）</summary>
                    Public Const _24 As String = "24"
                    ''' <summary>消除_職権消除（国籍喪失）</summary>
                    Public Const _25 As String = "25"
                    ''' <summary>消除_職権消除</summary>
                    Public Const _26 As String = "26"
                    ''' <summary>消除_改製</summary>
                    Public Const _27 As String = "27"
                    ''' <summary>消除_異動の取消し（減）</summary>
                    Public Const _28 As String = "28"
                    ''' <summary>修正_転居</summary>
                    Public Const _41 As String = "41"
                    ''' <summary>修正_軽微な修正</summary>
                    Public Const _42 As String = "42"
                    ''' <summary>修正_職権修正</summary>
                    Public Const _43 As String = "43"
                    ''' <summary>修正_誤記修正</summary>
                    Public Const _44 As String = "44"
                    ''' <summary>修正_個人番号の変更請求</summary>
                    Public Const _45 As String = "45"
                    ''' <summary>修正_個人番号の職権修正</summary>
                    Public Const _46 As String = "46"
                    ''' <summary>修正_個人番号の職権記載</summary>
                    Public Const _47 As String = "47"
                    ''' <summary>修正_住民票コードの変更請求</summary>
                    Public Const _48 As String = "48"
                    ''' <summary>修正_住民票コードの職権記載</summary>
                    Public Const _49 As String = "49"
                    ''' <summary>修正_世帯分離</summary>
                    Public Const _50 As String = "50"
                    ''' <summary>修正_世帯合併</summary>
                    Public Const _51 As String = "51"
                    ''' <summary>修正_世帯変更</summary>
                    Public Const _52 As String = "52"
                    ''' <summary>修正_世帯主変更</summary>
                    Public Const _53 As String = "53"
                    ''' <summary>修正_旧氏の記載</summary>
                    Public Const _54 As String = "54"
                    ''' <summary>修正_旧氏の変更</summary>
                    Public Const _55 As String = "55"
                    ''' <summary>修正_旧氏の削除</summary>
                    Public Const _56 As String = "56"
                    ''' <summary>修正_通称の記載</summary>
                    Public Const _57 As String = "57"
                    ''' <summary>修正_通称の削除</summary>
                    Public Const _58 As String = "58"
                    ''' <summary>修正_異動の取消し（修正）</summary>
                    Public Const _59 As String = "59"
                End Class

                ''' <summary>
                ''' 妊婦健診判定
                ''' </summary>
                Public Class 妊婦健診判定
                    ''' <summary>問題なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要指導</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>要精密検査</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>要経過観察</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>要医療</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' パーセンタイル値の範囲
                ''' </summary>
                Public Class パーセンタイル値の範囲
                    ''' <summary>3パーセンタイル未満</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>3パーセンタイル以上10パーセンタイル未満</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>10パーセンタイル以上25パーセンタイル未満</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>25パーセンタイル以上50パーセンタイル未満</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>50パーセンタイル以上75パーセンタイル未満</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>75パーセンタイル以上90パーセンタイル未満</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>90パーセンタイル以上97パーセンタイル未満</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>97パーセンタイル以上</summary>
                    Public Const _8 As String = "8"
                End Class

                ''' <summary>
                ''' 屈折検査判定結果
                ''' </summary>
                Public Class 屈折検査判定結果
                    ''' <summary>異常なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>異常あり</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>判定不可</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>実施不可</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' 食事をかんで食べる時の状態
                ''' </summary>
                Public Class 食事をかんで食べる時の状態
                    ''' <summary>何でもかんで食べることができる</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>歯や歯ぐき、かみ合わせなど気になる部分があり、かみにくいことがある</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>ほとんどかめない</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 冷たいものや熱いものが歯にしみますか
                ''' </summary>
                Public Class 冷たいものや熱いものが歯にしみますか
                    ''' <summary>しみない</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>時々しみる</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>いつもしみる</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' ゆっくりよくかんで食事をしますか
                ''' </summary>
                Public Class ゆっくりよくかんで食事をしますか
                    ''' <summary>毎日</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>時々</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>いいえ</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 歯科医院にいつ頃行きましたか
                ''' </summary>
                Public Class 歯科医院にいつ頃行きましたか
                    ''' <summary>半年以内</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>１年以内</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>１年以上行っていない</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 歯は何本ありますか
                ''' </summary>
                Public Class 歯は何本ありますか
                    ''' <summary>２０本以上</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>１９本以下</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>わからない</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 歯式コード（成人）
                ''' </summary>
                Public Class 歯式コード_成人
                    ''' <summary>健全歯（／）　</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>未処置歯（Ｃ）</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>未処置歯（Ｒ）</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>未処置歯（ＲＣ）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>処置歯（○）</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>要補綴歯（△）</summary>
                    Public Const _6 As String = "6"
                    ''' <summary>欠損補綴歯（▲）</summary>
                    Public Const _7 As String = "7"
                    ''' <summary>補綴不要欠損歯（×）</summary>
                    Public Const _8 As String = "8"
                End Class

                ''' <summary>
                ''' 診察所見の判定
                ''' </summary>
                Public Class 診察所見の判定
                    ''' <summary>異常なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>既医療</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>要経過観察</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>要紹介（要精密）</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>要紹介（要治療）</summary>
                    Public Const _5 As String = "5"
                End Class

                ''' <summary>
                ''' はい・いいえ
                ''' </summary>
                Public Class はい_いいえ
                    ''' <summary>はい</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>いいえ</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 健診種別
                ''' </summary>
                Public Class 健診種別
                    ''' <summary>2週間健診</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>1か月健診</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>その他</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 子宮復古状況
                ''' </summary>
                Public Class 子宮復古状況
                    ''' <summary>良</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>否</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 悪露
                ''' </summary>
                Public Class 悪露
                    ''' <summary>正</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>否</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 分娩経過
                ''' </summary>
                Public Class 分娩経過
                    ''' <summary>頭位</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>骨盤位</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>その他</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 分娩方法
                ''' </summary>
                Public Class 分娩方法
                    ''' <summary>経膣分娩</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>帝王切開</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>器械分娩（吸引・鉗子）</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 出血量（区分）
                ''' </summary>
                Public Class 出血量_区分
                    ''' <summary>少量</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>中量</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>多量</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 出産時の児の状態（性別）
                ''' </summary>
                Public Class 出産時の児の状態_性別
                    ''' <summary>男</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>女</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>不明</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 歯周病
                ''' </summary>
                Public Class 歯周病
                    ''' <summary>思わない</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>思う</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 歯周病の治療の必要
                ''' </summary>
                Public Class 歯周病の治療の必要
                    ''' <summary>言われなかった</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>言われた</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 特別な所見・処置
                ''' </summary>
                Public Class 特別な所見_処置
                    ''' <summary>新生児仮死（死亡)</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>新生児仮死（蘇生） </summary>
                    Public Const _2 As String = "2"
                    ''' <summary>死産</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 異常
                ''' </summary>
                Public Class 異常
                    ''' <summary>なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>あり</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>疑</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 歯の汚れ
                ''' </summary>
                Public Class 歯の汚れ
                    ''' <summary>きれい</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>少ない</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>多い</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 本人性別
                ''' </summary>
                Public Class 本人性別
                    ''' <summary>男</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>女</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' キャンセル待ち
                ''' </summary>
                Public Class キャンセル待ち
                    ''' <summary>希望しない</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>希望する</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 有無
                ''' </summary>
                Public Class 有無
                    ''' <summary>なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>あり</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 実施
                ''' </summary>
                Public Class 実施
                    ''' <summary>未実施</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>実施済</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 該当
                ''' </summary>
                Public Class 該当
                    ''' <summary>該当する</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>該当しない</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 輸血の有無
                ''' </summary>
                Public Class 輸血の有無
                    ''' <summary>有</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>無</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 歯の形態・色調
                ''' </summary>
                Public Class 歯の形態_色調
                    ''' <summary>異常なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>異常あり</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' いいえ・はい
                ''' </summary>
                Public Class いいえ_はい
                    ''' <summary>いいえ</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>はい</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 妊娠歴
                ''' </summary>
                Public Class 妊娠歴
                    ''' <summary>無</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>有</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>不明</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 出産歴
                ''' </summary>
                Public Class 出産歴
                    ''' <summary>無</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>有</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>不明</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' むし歯の状態_1歳6か月児健診結果
                ''' </summary>
                Public Class むし歯の状態_1歳6か月児健診結果
                    ''' <summary>むし歯なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>要注意</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>むし歯あり</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 軟組織異常有無
                ''' </summary>
                Public Class 軟組織異常有無
                    ''' <summary>なし</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>あり</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 栄養法_3～4か月児健診アンケート
                ''' </summary>
                Public Class 栄養法_3から4か月児健診アンケート
                    ''' <summary>母乳</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>人工乳</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>混合</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>無回答</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 要否
                ''' </summary>
                Public Class 要否
                    ''' <summary>否</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>要</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 可・否
                ''' </summary>
                Public Class 可_否
                    ''' <summary>否</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>可</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 有無区分
                ''' </summary>
                Public Class 有無区分
                    ''' <summary>無</summary>
                    Public Const _0_ As String = "0 "
                    ''' <summary>有</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 単併給区分
                ''' </summary>
                Public Class 単併給区分
                    ''' <summary>単給</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>併給</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 認定有無
                ''' </summary>
                Public Class 認定有無
                    ''' <summary>無</summary>
                    Public Const _0_ As String = "0 "
                    ''' <summary>有</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' 資格状態
                ''' </summary>
                Public Class 資格状態
                    ''' <summary>申請（受理）</summary>
                    Public Const _10 As String = "10"
                    ''' <summary>取下</summary>
                    Public Const _20 As String = "20"
                    ''' <summary>却下</summary>
                    Public Const _30 As String = "30"
                    ''' <summary>受給（決定）</summary>
                    Public Const _40 As String = "40"
                    ''' <summary>廃止（支給取消・返還・喪失）</summary>
                    Public Const _50 As String = "50"
                    ''' <summary>保留</summary>
                    Public Const _60 As String = "60"
                End Class

                ''' <summary>
                ''' 身体障害者手帳障害種別
                ''' </summary>
                Public Class 身体障害者手帳障害種別
                    ''' <summary>１種</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>２種</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 身体障害者手帳総合等級
                ''' </summary>
                Public Class 身体障害者手帳総合等級
                    ''' <summary>－級</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>１級</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>２級</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>３級</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>４級</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>５級</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>６級</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' 身体障害者手帳障害部位
                ''' </summary>
                Public Class 身体障害者手帳障害部位
                    ''' <summary>視覚障害</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>聴覚障害</summary>
                    Public Const _21 As String = "21"
                    ''' <summary>平衡機能障害</summary>
                    Public Const _22 As String = "22"
                    ''' <summary>音声機能障害</summary>
                    Public Const _31 As String = "31"
                    ''' <summary>言語機能障害</summary>
                    Public Const _32 As String = "32"
                    ''' <summary>そしゃく機能障害</summary>
                    Public Const _33 As String = "33"
                    ''' <summary>肢体不自由　上肢</summary>
                    Public Const _41 As String = "41"
                    ''' <summary>肢体不自由　下肢</summary>
                    Public Const _42 As String = "42"
                    ''' <summary>肢体不自由　体幹</summary>
                    Public Const _43 As String = "43"
                    ''' <summary>肢体不自由　運動機能障害・上肢</summary>
                    Public Const _44 As String = "44"
                    ''' <summary>肢体不自由　運動機能障害・移動</summary>
                    Public Const _45 As String = "45"
                    ''' <summary>内部障害　心臓機能障害</summary>
                    Public Const _51 As String = "51"
                    ''' <summary>内部障害　腎臓機能障害</summary>
                    Public Const _52 As String = "52"
                    ''' <summary>内部障害　呼吸器機能障害</summary>
                    Public Const _53 As String = "53"
                    ''' <summary>内部障害　膀胱・直腸機能障害</summary>
                    Public Const _54 As String = "54"
                    ''' <summary>内部障害　小腸機能障害</summary>
                    Public Const _55 As String = "55"
                    ''' <summary>内部障害　免疫機能障害</summary>
                    Public Const _56 As String = "56"
                    ''' <summary>内部障害　肝臓機能障害</summary>
                    Public Const _57 As String = "57"
                End Class

                ''' <summary>
                ''' 要介護状態区分コード
                ''' </summary>
                Public Class 要介護状態区分コード
                    ''' <summary>非該当</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>みなし非該当</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>経過的要介護</summary>
                    Public Const _11 As String = "11"
                    ''' <summary>要支援１</summary>
                    Public Const _12 As String = "12"
                    ''' <summary>要支援２</summary>
                    Public Const _13 As String = "13"
                    ''' <summary>みなし要支援</summary>
                    Public Const _19 As String = "19"
                    ''' <summary>要介護１</summary>
                    Public Const _21 As String = "21"
                    ''' <summary>要介護２</summary>
                    Public Const _22 As String = "22"
                    ''' <summary>要介護３</summary>
                    Public Const _23 As String = "23"
                    ''' <summary>要介護４</summary>
                    Public Const _24 As String = "24"
                    ''' <summary>要介護５</summary>
                    Public Const _25 As String = "25"
                    ''' <summary>再調査</summary>
                    Public Const _31 As String = "31"
                    ''' <summary>取消</summary>
                    Public Const _88 As String = "88"
                    ''' <summary>なし</summary>
                    Public Const _99 As String = "99"
                End Class

                ''' <summary>
                ''' 被保険者区分コード
                ''' </summary>
                Public Class 被保険者区分コード
                    ''' <summary>第１号被保険者</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>第２号被保険者</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 要介護認定状況コード
                ''' </summary>
                Public Class 要介護認定状況コード
                    ''' <summary>申請受理</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>申請取下</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>却下</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>認定</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>職権認定</summary>
                    Public Const _05 As String = "05"
                End Class

                ''' <summary>
                ''' 国保資格区分
                ''' </summary>
                Public Class 国保資格区分
                    ''' <summary>世帯主</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>擬制世帯主</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>世帯員</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' マル学マル遠区分
                ''' </summary>
                Public Class マル学マル遠区分
                    ''' <summary>マル学</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>マル遠</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>市外施設適用</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' 国保資格取得事由（集約システム）
                ''' </summary>
                Public Class 国保資格取得事由_集約システム
                    ''' <summary>転入</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>社保離脱</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>生保廃止</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>出生</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>職権回復</summary>
                    Public Const _08 As String = "08"
                    ''' <summary>その他</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>後期高齢者医療制度離脱</summary>
                    Public Const _13 As String = "13"
                    ''' <summary>月中社保離脱</summary>
                    Public Const _14 As String = "14"
                    ''' <summary>月中国保組合離脱</summary>
                    Public Const _15 As String = "15"
                End Class

                ''' <summary>
                ''' 国保資格喪失事由（集約システム）
                ''' </summary>
                Public Class 国保資格喪失事由_集約システム
                    ''' <summary>転出</summary>
                    Public Const _41 As String = "41"
                    ''' <summary>社保加入</summary>
                    Public Const _42 As String = "42"
                    ''' <summary>生保開始</summary>
                    Public Const _43 As String = "43"
                    ''' <summary>死亡</summary>
                    Public Const _44 As String = "44"
                    ''' <summary>職権抹消</summary>
                    Public Const _48 As String = "48"
                    ''' <summary>その他</summary>
                    Public Const _49 As String = "49"
                    ''' <summary>後期高齢者医療制度加入（年齢到達）</summary>
                    Public Const _51 As String = "51"
                    ''' <summary>後期高齢者医療制度加入（障害認定）</summary>
                    Public Const _52 As String = "52"
                End Class

                ''' <summary>
                ''' 証区分
                ''' </summary>
                Public Class 証区分
                    ''' <summary>被保険者証（一般）</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>被保険者証（退職）</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>短期被保険者証（一般）</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>短期被保険者証（退職）</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>資格証明書</summary>
                    Public Const _05 As String = "05"
                End Class

                ''' <summary>
                ''' 個人区分コード
                ''' </summary>
                Public Class 個人区分コード
                    ''' <summary>-</summary>
                    Public Const ___ As String = "-"
                End Class

                ''' <summary>
                ''' 資格取得事由コード
                ''' </summary>
                Public Class 資格取得事由コード
                    ''' <summary>-</summary>
                    Public Const ___ As String = "-"
                End Class

                ''' <summary>
                ''' 資格喪失事由コード
                ''' </summary>
                Public Class 資格喪失事由コード
                    ''' <summary>-</summary>
                    Public Const ___ As String = "-"
                End Class

                ''' <summary>
                ''' 名寄せ元フラグ
                ''' </summary>
                Public Class 名寄せ元フラグ
                    ''' <summary>該当しない</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>該当する</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 他業務参照不可フラグ
                ''' </summary>
                Public Class 他業務参照不可フラグ
                    ''' <summary>参照不可</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>参照可能</summary>
                    Public Const _2 As String = "2"
                End Class

                ''' <summary>
                ''' 性別（団体内統合宛名）
                ''' </summary>
                Public Class 性別_団体内統合宛名
                    ''' <summary>不詳</summary>
                    Public Const _0 As String = "0"
                    ''' <summary>男</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>女</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>その他</summary>
                    Public Const _9 As String = "9"
                End Class

                ''' <summary>
                ''' 統合宛名フラグ
                ''' </summary>
                Public Class 統合宛名フラグ
                    ''' <summary>該当しない</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>該当する</summary>
                    Public Const _2 As String = "2"
                End Class

            End Class
        End Class
        ''' <summary>
        ''' コントロールマスタ
        ''' </summary>
        Public Class コントロールマスタ
            ''' <summary>
            ''' システム
            ''' </summary>
            Public Class システム
                ''' <summary>
                ''' パスワード
                ''' </summary>
                Public Class パスワード
                    ''' <summary>パスワード有効日数</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>パスワード変更通知開始日数</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>パスワードポリシー設定フラグ</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>パスワード上限文字数</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>パスワード必須文字種(半角数字)</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>パスワード必須文字種(半角英字)</summary>
                    Public Const _06 As String = "06"
                    ''' <summary>パスワード必須文字種(半角記号)</summary>
                    Public Const _07 As String = "07"
                    ''' <summary>エラー回数上限</summary>
                    Public Const _08 As String = "08"
                    ''' <summary>使用できる記号</summary>
                    Public Const _09 As String = "09"
                    ''' <summary>パスワード有効期限チェックフラグ</summary>
                    Public Const _10 As String = "10"
                End Class

                ''' <summary>
                ''' config情報
                ''' </summary>
                Public Class config情報
                    ''' <summary>ログイン制限時間</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>システム年度</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>住所表記</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>メモ画面登録支所表示フラグ</summary>
                    Public Const _05 As String = "05"
                    ''' <summary>市区町村コード</summary>
                    Public Const _06 As String = "06"
                End Class

                ''' <summary>
                ''' 画面確認件数
                ''' </summary>
                Public Class 画面確認件数
                    ''' <summary>住民記録台帳照会-確認件数</summary>
                    Public Const _AWKK00101G As String = "AWKK00101G"
                End Class

                ''' <summary>
                ''' 画面上限件数
                ''' </summary>
                Public Class 画面上限件数
                    ''' <summary>住民記録台帳照会-上限件数</summary>
                    Public Const _AWKK00101G As String = "AWKK00101G"
                End Class

                ''' <summary>
                ''' 検診事業の年齢基準指定
                ''' </summary>
                Public Class 検診事業の年齢基準指定
                    ''' <summary>乳がん</summary>
                    Public Const _090 As String = "090"
                End Class

                ''' <summary>
                ''' 検診事業の複数回数指定
                ''' </summary>
                Public Class 検診事業の複数回数指定
                    ''' <summary>乳がん</summary>
                    Public Const _090 As String = "090"
                End Class

                ''' <summary>
                ''' 拡事業関連上限件数
                ''' </summary>
                Public Class 拡事業関連上限件数
                    ''' <summary>拡事業上限件数</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>半角タイプ入力項目の上限件数</summary>
                    Public Const _02 As String = "02"
                    ''' <summary>日付タイプ入力項目の上限件数</summary>
                    Public Const _03 As String = "03"
                    ''' <summary>全角タイプ入力項目の上限件数</summary>
                    Public Const _04 As String = "04"
                    ''' <summary>コードタイプ入力項目の上限件数</summary>
                    Public Const _05 As String = "05"
                End Class

                ''' <summary>
                ''' 同一世帯員更新フラグ
                ''' </summary>
                Public Class 同一世帯員更新フラグ
                    ''' <summary>同一世帯員更新フラグ</summary>
                    Public Const _01 As String = "01"
                End Class

                ''' <summary>
                ''' 付番開始番号
                ''' </summary>
                Public Class 付番開始番号
                    ''' <summary>世帯番号</summary>
                    Public Const _01 As String = "01"
                    ''' <summary>宛名番号</summary>
                    Public Const _02 As String = "02"
                End Class

                ''' <summary>
                ''' 一次結果チェック区分
                ''' </summary>
                Public Class 一次結果チェック区分
                    ''' <summary>一次結果チェック区分</summary>
                    Public Const _AWSH00101G As String = "AWSH00101G"
                End Class

                ''' <summary>
                ''' テンプレート名
                ''' </summary>
                Public Class テンプレート名
                    ''' <summary>アドレスシール.xlsx</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>バーコード.xlsx</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>はがき.xlsx</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>宛名台帳.xlsx</summary>
                    Public Const _4 As String = "4"
                    ''' <summary>件数表行政区.xlsx</summary>
                    Public Const _5 As String = "5"
                    ''' <summary>件数表年齢.xlsx</summary>
                    Public Const _6 As String = "6"
                End Class

                ''' <summary>
                ''' アドレスシールの設定
                ''' </summary>
                Public Class アドレスシールの設定
                    ''' <summary>枚数の設定(縦)</summary>
                    Public Const _3 As String = "3"
                    ''' <summary>枚数の設定(横)</summary>
                    Public Const _4 As String = "4"
                End Class

                ''' <summary>
                ''' バーコードシールの設定
                ''' </summary>
                Public Class バーコードシールの設定
                    ''' <summary>一人あたりの枚数の設定</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>行数</summary>
                    Public Const _2 As String = "2"
                    ''' <summary>列数</summary>
                    Public Const _3 As String = "3"
                End Class

                ''' <summary>
                ''' はがきの設定
                ''' </summary>
                Public Class はがきの設定
                    ''' <summary>用紙1枚あたりの出力人数</summary>
                    Public Const _1 As String = "1"
                End Class

                ''' <summary>
                ''' フォント表示の設定
                ''' </summary>
                Public Class フォント表示の設定
                    ''' <summary>IPAmj明朝の設定</summary>
                    Public Const _1 As String = "1"
                    ''' <summary>その他フォントのシステム固定設定</summary>
                    Public Const _2 As String = "2"
                End Class

            End Class
            ''' <summary>
            ''' 標準版
            ''' </summary>
            Public Class 標準版
            End Class
        End Class
    End Class
End Namespace
