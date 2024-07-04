// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: EUC共通定数
//             共通定数
// 作成日　　: 2023.09.08
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using TSQL;

namespace BCC.Affect.Service.Common;

public static class EucConstant
{
    #region 文字定数

    /**
     * 市区町村汎用コード
     */
    public const string SITYOSON_HANYO_CD = "1";

    /**
     * 市町村名汎用コード
     */
    public const string SITYOSONMEI_HANYO_CD = "2";

    /**
     * 県名汎用コード
     */
    public const string kENMEI_HANYO_CD = "3";

    /**
     * 市長汎用コード
     */
    public const string SITYO_HANYO_CD = "4";

    /**
     * 職務代理名汎用コード
     */
    public const string DAIRIMEI_HANYO_CD = "5";

    /**
     * 市長名汎用コード
     */
    public const string SITYOMEI_HANYO_CD = "6";

    /**
     * 職務代理者汎用コード
     */
    public const string DAIRISYA_HANYO_CD = "7";

    /**
     * デフォルト・テンプレート・ファイル名
     */
    public const string DEFAULT_TEMPLATE_FILE_NM = "default";

    /**
     * 年度
     */
    public const string NENDO_NAME = "年度";

    /**
     * 個人番号フィールド名
     */
    public const string PERSONAL_NO_FIELD = "personalno";

    /**
     * EUC 関数の接頭辞
     */
    public const string EUC_FUNCTION_PREFIX = "ft_";

    #endregion

    #region 数値定数

    /**
     * サブ帳票以外の様式枝番
     */
    public const int NOT_SUB_YOSIKIEDA = 0;

    /**
     * 公印ID
     */
    public const int KOIN_INFO_ID = 0;

    /**
     * excel template min row no
     */
    public const int MIN_ROW = 15;

    /**
     * excel template min col no
     */
    public const int MIN_COL = 1;

    /**
     * excel template row no limit
     */
    public const int ROW_LIMIT = ushort.MaxValue;

    /**
     * excel template col no limit
     */
    public const int COL_LIMIT = 1 << 14;

    #endregion

    #region ドロップダウンリスト定数

    /**
     * コントロールドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> CONTROL_OPTIONS = GetSelectorList<Enumコントロール>();

    /**
     * 使用区分ドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> USE_KBN_OPTIONS = GetSelectorList<Enum使用区分>();

    /**
     * 集計項目区分ドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> SYUKEI_KBN_OPTIONS = GetSelectorList<Enum集計項目区分>();

    /**
     * 様式種別ドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> YOSIKISYUBETU_OPTIONS = GetSelectorList<Enum様式種別>();

    /**
     * 様式種別詳細ドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> YOSIKI_OPTIONS = GetSelectorList<Enum様式種別詳細>();

    /**
     * 帳票様式リスト
     */
    public static readonly List<DaSelectorModel> YOSHIKI_BUNRUI = GetSelectorList<Enum帳票様式>();

    /**
     * 様式作成方法ドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> YOSIKIHOUHOU_OPTIONS = GetSelectorList<Enum様式作成方法>();

    /**
     * 行列固定ドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> MEISAIKOTEI_OPTIONS = GetSelectorList<Enum行列固定>();

    /**
     * 内外区分ドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> NAIGAI_OPTIONS = GetSelectorList<Enum内外区分>();

    /**
     * 集計区分ドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> CROSS_KBN_OPTIONS = GetSelectorList<Enum集計区分>();

    /**
     * 出力項目区分ドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> ITEM_KBN_OPTIONS = GetSelectorList<Enum出力項目区分>();

    /**
     * 並び替えドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> ORDER_KBN_OPTIONS = GetSelectorList<Enum並び替え>();

    /**
     * 小計区分ドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> KBN_1_OPTIONS = GetSelectorList<Enum小計区分>();

    /**
     * DataTypeドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> DATA_TYPE_OPTIONS = GetSelectorList<EnumDataType>();

    /**
     * 固定検索条件
     */
    public static readonly List<Enum検索条件区分> FIXED_JYOKEN_KBNS = new() { Enum検索条件区分.固定条件, Enum検索条件区分.前提条件};

    /**
     * 固定検索条件ドロップダウンリスト
     */
    public static readonly List<DaSelectorModel> FIXED_JYOKEN_KBN_OPTIONS = FIXED_JYOKEN_KBNS.Select(x => new DaSelectorModel(DaConvertUtil.EnumToStr(x), x.ToString())).ToList();

    /// <summary>
    /// 列挙型をドロップダウンリストに変換
    /// </summary>
    private static List<DaSelectorModel> GetSelectorList<TEnum>() where TEnum : Enum
    {
        return Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Select(x => new DaSelectorModel(DaConvertUtil.EnumToStr(x), x.ToString()))
            .ToList();
    }

    #endregion

    #region その他

    /**
     * コントロール to シンボル
     */
    public static readonly Dictionary<Enumコントロール, string> CONTROL_SYMBOL_DIC = new()
    {
        { Enumコントロール.数値入力, DaStrPool.EQ },
        { Enumコントロール.文字入力, DaStrPool.EQ },
        { Enumコントロール.日付入力, DaStrPool.EQ },
        { Enumコントロール.時間入力, DaStrPool.EQ },
        { Enumコントロール.数値範囲, nameof(TSQLKeywords.BETWEEN) },
        { Enumコントロール.文字範囲, nameof(TSQLKeywords.BETWEEN) },
        { Enumコントロール.日付範囲, nameof(TSQLKeywords.BETWEEN) },
        { Enumコントロール.時間範囲, nameof(TSQLKeywords.BETWEEN) },
        { Enumコントロール.選択, DaStrPool.EQ },
        { Enumコントロール.複数選択, DaStrPool.EQ },
        { Enumコントロール.論理値, DaStrPool.EQ }
    };

    public static readonly Dictionary<Enum様式種別, List<DaSelectorModel>> YOSHIKI_TYPE_MAPPING_DIC = new()
    {
        { Enum様式種別.一覧表, new List<Enum様式種別詳細> { Enum様式種別詳細.一覧表 }.Select(x => new DaSelectorModel(DaConvertUtil.EnumToStr(x), x.ToString())).ToList() },
        { Enum様式種別.台帳, new List<Enum様式種別詳細> { Enum様式種別詳細.台帳 }.Select(x => new DaSelectorModel(DaConvertUtil.EnumToStr(x), x.ToString())).ToList() },
        { Enum様式種別.経年表, new List<Enum様式種別詳細> { Enum様式種別詳細.経年表 }.Select(x => new DaSelectorModel(DaConvertUtil.EnumToStr(x), x.ToString())).ToList() },
        { Enum様式種別.集計表, new List<Enum様式種別詳細> { Enum様式種別詳細.単純集計表, Enum様式種別詳細.クロス集計 }.Select(x => new DaSelectorModel(DaConvertUtil.EnumToStr(x), x.ToString())).ToList() },
        {
            Enum様式種別.カスタマイズ,
            new List<Enum様式種別詳細> { Enum様式種別詳細.はがき, Enum様式種別詳細.アドレスシール, Enum様式種別詳細.バーコードシール, Enum様式種別詳細.宛名台帳 }.Select(x => new DaSelectorModel(DaConvertUtil.EnumToStr(x), x.ToString())).ToList()
        },
    };

    /**
     * 特別様式
     */
    public static readonly HashSet<string> SPECIAL_YOSHIKI_ID_SET = new()
    {
        DaEucService.Cアドレスシール,
        DaEucService.Cはがき,
        DaEucService.C宛名台帳,
        DaEucService.Cバーコード,
        DaEucService.C件数表年齢,
        DaEucService.C件数表行政区
    };

    #endregion
}