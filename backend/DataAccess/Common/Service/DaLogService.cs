// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ログ処理
//
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using System;
using System.Diagnostics;

namespace BCC.Affect.DataAccess
{
    public class DaLogService
    {
        public enum Level
        {
            ERROR,
            WARN,
            DEBUG,
            INFO
        }

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()!.DeclaringType);

        public static void WriteMessage(string method, string msg)
        {
            _logger.Info($"{method} {msg}");
        }

        public static void WriteException(string method, Exception ex)
        {
            _logger.Error($"{method} {ex.Message} {ex.StackTrace}");
        }

    }
}