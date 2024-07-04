// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: EUC帳票ロジック処理
//
// 作成日　　: 2023.04.07
// 作成者　　: 呉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public static partial class DaEucService
    {
        public const string 発行日 = "発行日";
        public const string 基準日 = "基準日";
        public const string 送付先利用目的 = "送付先利用目的";
        //リターンコード
        public const string リターンNO_DATA = "A063001";

        public const string Cアドレスシール = "0Z01";
        public const string Cはがき = "0Z02";
        public const string C宛名台帳 = "0Z03";
        public const string Cバーコード = "0Z04";
        public const string C件数表年齢 = "0Z05";
        public const string C件数表行政区 = "0Z06";

        //集計区分
        public const string CGroupby縦 = "1";
        public const string CGroupby横 = "2";
        public const string C集計 = "3";

        //集計方法
        public const string CCount = "1";
        public const string CSum = "2";
        public const string CMax = "3";
        public const string CMin = "4";

        //小計区分
        public const string Cなし = "0";
        public const string C前 = "1";
        public const string C後 = "2";

        public const string CONST_SUM = "小計";
        public const string CONST_TOTAL = "合計";

        //汎用マスタ情報
        public const string CONST_HANYOMAINCD_1001 = "1001";
        public const int CONST_HANYOSUBCD_1 = 1;
        public const int CONST_HANYOSUBCD_2 = 2;
        public const int CONST_HANYOSUBCD_3 = 3;
        public const int CONST_HANYOSUBCD_4 = 4;
        public const string CONST_HANYOCD_01 = "01";

        //CSVフォーマットのキー
        public const string CONST_XLSX_EXTENSION = @".xlsx";
        public const string CONST_CSV_EXTENSION = @".csv";
        public const string CONDITION_OUTPUTHEADER = "hasHeader";
        public const string CONDITION_ENCODING = "Encoding";
        public const string CONDITION_BOM = "hasBOM";
        public const string CONDITION_QUOTATION = "hasQuotation";

        //SELECT区分：FUNCTION
        public const string CONST_FUNCTION = "FUNCTION";

        //固定帳票のキー
        public const string ITEMID_YUBIN_ADRS = "adrs_yubin";
        public const string ITEMID_YUBIN_ADRS1 = "adrs_yubin1";
        public const string ITEMID_YUBIN_ADRS2 = "adrs_yubin2";
        public const string ITEMID_YUBIN_ADRS3 = "adrs_yubin3";
        public const string ITEMID_YUBIN_ADRS4 = "adrs_yubin4";
        public const string ITEMID_YUBIN_ADRS5 = "adrs_yubin5";
        public const string ITEMID_YUBIN_ADRS6 = "adrs_yubin6";
        public const string ITEMID_YUBIN_ADRS7 = "adrs_yubin7";
        public const string ITEMID_ADRS1_ADRS = "adrs1";
        public const string ITEMID_ADRS2_ADRS = "adrs2";
        public const string ITEMID_SIMEI_YUSEN_ADRS = "simei_yusen";
        public const string ITEMID_KATAGAKICD_ADRS = "adrs_katagakicd";
        public const string ITEMID_CUSTOMERCD_ADRS = "customerCd";
        public const string ITEMID_SIMEI_YUSEN_BARCD = "simei_yusen";
        public const string ITEMID_ATENANO_BARCD = "atenano";
        public const string ITEMID_AGE = "age";
        public const string ITEMID_GYOSEIKUCD = "gyoseikucd";
        public const string ITEMID_GYOSEIKUNM = "gyoseikunm";
        public const string ITEMID_SUM_TOTAL = "total";
        public const string ITEMID_SUM_GENDER = "gender";
        public const string ITEMID_SUM_MALE = "male";
        public const string ITEMID_SUM_FEMALE = "femal";
        public const string ITEMID_SUM_UNKNOWN = "unknown";
        public const string ITEMID_SUM_OTHER = "other";
        public const string ITEMID_NO = "no";
        public const string ITEMID_PRINTDATE = "printdate";

        public const string CONDITION_YUBIN_ADRS = "郵便番号";
        public const string CONDITION_YUBIN_ADRS1 = "郵便番号1";
        public const string CONDITION_YUBIN_ADRS2 = "郵便番号2";
        public const string CONDITION_YUBIN_ADRS3 = "郵便番号3";
        public const string CONDITION_YUBIN_ADRS4 = "郵便番号4";
        public const string CONDITION_YUBIN_ADRS5 = "郵便番号5";
        public const string CONDITION_YUBIN_ADRS6 = "郵便番号6";
        public const string CONDITION_YUBIN_ADRS7 = "郵便番号7";
        public const string CONDITION_ADRS_ADRS = "住所";
        public const string CONDITION_ADRS1_ADRS = "住所１";
        public const string CONDITION_ADRS2_ADRS = "住所２";
        public const string CONDITION_SIMEI_YUSEN_ADRS = "氏名_優先";
        public const string CONDITION_KATAGAKICD_ADRS = "方書";
        public const string CONDITION_CUSTOMERCD_ADRS = "カスタマーコード";
        public const string CONDITION_SIMEI_YUSEN_BARCD = "氏名_優先";
        public const string CONDITION_ATENANO_BARCD = "宛名番号";
        public const string CONDITION_AGE = "年齢";
        public const string CONDITION_GYOSEIKUCD = "行政区コード";
        public const string CONDITION_GYOSEIKUNM = "行政区";
        public const string CONDITION_SUM_TOTAL = "計";
        public const string CONDITION_SUM_GENDER = "性別";
        public const string CONDITION_SUM_MALE = "男";
        public const string CONDITION_SUM_FEMALE = "女";
        public const string CONDITION_SUM_UNKNOWN = "不詳";
        public const string CONDITION_SUM_OTHER = "その他";
        public const string CONDITION_NO = "番号";
        public const string CONDITION_PRINTDATE = "出力日";

        public const string CONDITION_START_COUNT = "枚目から";
        public const string CONDITION_FILE_NM = "ファイル名";
        public const string CONDITION_RIREKI_SEQ = "履歴シーケンス";
        public const string CONDITION_JOB_ID = "タスクID";

        public const string FORMAT_YUBIN_ADRS = "〒 {0}";
        public const string FORMAT_YUBIN_ADRS_2 = "{0}";
        public const string FORMAT_SIMEI_ADRS = "{0}　様";
        public const string FORMAT_SIMEIKATA_ADRS = "【{0}　様方】";
        public const string FORMAT_SIMEI_BARCD = "{0}　様";
    }
}