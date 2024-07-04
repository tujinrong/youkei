// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 定数クラス
//            
// 作成日　　: 2023.01.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.BatchService
{
    public class BtConst
    {
        public const int INTERVALEVERYDAY = 12 * 60 * 60 * 1000;
        public const int INTERVAL2MINUTES = 2 * 60 * 1000;
        public const int INTERVAL5MINUTES = 5 * 60 * 1000;
        public const int MINUTESLATER2 = 2;

        public const string SUCCESS_MSG = "success";
        public const string FAIL_DEFAULT_MSG = "fail";
    }
}