// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: Global変数
//
// 作成日　　: 2024.07.12
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.AiReport.Common;
using NpgsqlTypes;

namespace BCC.Affect.DataAccess
{
    public class DaGlobal
    {
        public static bool WriteExcelLog = false;

        private static string _ConnectionString;
        private static string _OracleConnectionString;

        public delegate string GetConfigValue(string key);
        public static GetConfigValue? GetConnectionStringFunc = null;
        public delegate string GetOracleConfigValue(string key);
        public static GetOracleConfigValue? GetOracleConnectionStringFunc = null;
        public delegate T GetSectionConfigValueDelegate<out T>(string section, string key);
        public static GetSectionConfigValueDelegate<string>? GetSectionConfigStringValueFunc = null;

        public static string ConnectionString
        {
            get
            {
                if (GetConnectionStringFunc == null)
                {
#if DEBUG
                    return "Host=43.163.201.169;Port=5433;Database=postgres;SearchPath=public;uid=postgres;pwd=AIplus2023!;Pooling=true; MinPoolSize=1; MaxPoolSize=200; Connection Idle Lifetime=300; Connection Pruning Interval=10;";
                    //return "Host=localhost;Port=5432;Database=postgres;SearchPath=public;uid=postgres;pwd=AIplus2023!;Pooling=true; MinPoolSize=1; MaxPoolSize=200; Connection Idle Lifetime=300; Connection Pruning Interval=10;";
#else
                    return "";
#endif
                }
                var setting = GetConnectionStringFunc("connectionString");

                if (!string.IsNullOrEmpty(setting))
                {
                    _ConnectionString = setting;
                }
                else
                {
                    throw new Exception("ポータルサーバーの接続文字列を取得できないので、管理者に連絡してください。");
                }

                return _ConnectionString;
            }
        }

        public static string OracleConnectionString
        {
            get
            {
                if (GetOracleConnectionStringFunc == null)
                {
#if DEBUG
                    return "User Id=GJS;Password=GJS;Data Source=User Id=GJS;Password=GJS;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=S19C01)))";
#else
                    return "";
#endif
                }
                var setting = GetOracleConnectionStringFunc("OracleConnectionString");

                if (!string.IsNullOrEmpty(setting))
                {
                    _OracleConnectionString = setting;
                }
                else
                {
                    throw new Exception("ポータルサーバーの接続文字列を取得できないので、管理者に連絡してください。");
                }

                return _OracleConnectionString;
            }
        }

        /// <summary>
        /// DB初期化
        /// </summary>
        public static void InitDbLib()
        {
            //性能テスト
            //AiGlobal.PostgresSchema = "report";

            AiGlobal.DiffHandler = DaDbLogService.DiffDelegate!;
            AiGlobal.SqlLogHandler = DaDbLogService.LogDelegate!;
            
            //AiGlobal.LogDiffHandler = DaDbLogService.DiffLogDelegate!;

            //パラメータタイプ
            AiGlobal.ParameterTypeDic = new Dictionary<string, int>() { { "nendo", (int)NpgsqlDbType.Char } };

            //DB固定項目名設定
            AiGlobal.CreateUserFieldName = nameof(tm_afuserDto.reguserid);
            AiGlobal.CreateTimeFieldName = nameof(tm_afuserDto.regdttm);
            AiGlobal.UpdateUserFieldName = nameof(tm_afuserDto.upduserid);
            AiGlobal.UpdateTimeFieldName = nameof(tm_afuserDto.upddttm);
            AiGlobal.TimeStampFieldName = nameof(tm_afuserDto.upddttm);
            //登録支所
            AiGlobal.CreateUnitName = nameof(tt_shkensinDto.regsisyo);
            //削除フラグ
            AiGlobal.DeleteFlagName = "delflg";

            AiGlobal.SystemTableItems = new string[] { nameof(tm_afuserDto.reguserid), nameof(tm_afuserDto.regdttm), nameof(tm_afuserDto.upduserid), nameof(tm_afuserDto.upddttm), nameof(tt_shkensinDto.regsisyo) };
            AiGlobal.SetUpdateFieldsWhenInsert = true;
            AiGlobal.DatabaseType = EnumDatabaseType.POSTGRE;

            //暗号化解読方法設定
            ArGlobal.DeEncrypt = DaEncryptUtil.AesDecrypt;
        }

        /*        public static class Path
                {
                    //リクエストの時に取得する
                    public static string ServerPath;

                    public static string UpdloadPath => System.IO.Path.GetTempPath();
                    /// <summary>
                    /// ダウンロードファイルのパス
                    /// </summary>
                    public static string DwonloadFullPath => System.IO.Path.Combine(ServerPath, DaConst.DONWLOAD_PATH);

                    /// <summary>
                    /// メッセージファイルのパス
                    /// </summary>
                    public static string ResourceFullPath => System.IO.Path.Combine(ServerPath, DaConst.RESOURCE_PATH);
                }*/

    }
}