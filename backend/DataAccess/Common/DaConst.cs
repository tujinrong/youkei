// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 定数クラス
//
// 作成日　　: 2023.07.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using NodaTime;

namespace BCC.Affect.DataAccess
{
    public class DaConst
    {
        //システムユーザー：ユーザーIDとして使用
        public static readonly string SYSTEM = "system";

        //SQL function page parameters name
        public const string PAGE_PARAM_LIMIT = "limit_in";
        public const string PAGE_PARAM_OFFSET = "offset_in";
        public const string PAGE_PARAM_ORDER_BY = "orderby_in";

        // downlaod response header: Content_Disposition
        public const string Content_Disposition = "Content-Disposition";

        public const string SessionID = "sessionid";

        //ログ記入文字(エラー時)
        public const string LOG_ERR_VALUE = "ERROR";

        public const string JapanDateFormat = "ggyy年MM月dd日";

        public const string JapanTimeFormat = "ggyy年MM月dd日 HH:mm:ss";
        public const string JapanTimeFormat2 = "ggyy年MM月dd日 HH時mm分ss秒";
        public const string JapanTimeFormat3 = "yyyy/MM/dd HH:mm:ss";

        public const string DateFormat = "yyyy-MM-dd";

        //タイムゾーン
        public static readonly DateTimeZone TOKYO_TIME_ZONE = DateTimeZoneProviders.Tzdb["Asia/Tokyo"];
        public static readonly TimeZoneInfo TOKYO_TIME_ZONE_INFO = TimeZoneInfo.FindSystemTimeZoneById("Asia/Tokyo");

        //デフォルトの圧縮ファイル名
        public const string DEFAULT_ZIP_FILE_NAME = "ZipFile";

        // パスワードに必要な最小文字数
        public const int PWD_MIN_LENGTH = 8;

        // selector delimiter
        public const string SELECTOR_DELIMITER = " : ";

        //エラー最大件数
        public const int MAX_ERRORS = 1000;
    }
}