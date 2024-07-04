// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索処理
// 　　　　　　レスポンスインターフェースベース
// 作成日　　: 2023.01.26
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service
{
    public class CmSearchResponseBase : DaResponseBase
    {
        public int totalpagecount { get; set; }     //ページ数
        public int totalrowcount { get; set; }      //総件数

        /// <summary>
        /// ページャー設定
        /// </summary>
        public void SetPageInfo(int total, int pagesize)
        {
            totalpagecount = (total + pagesize - 1) / pagesize;    //ページ数
            totalrowcount = total;                                 //総件数
        }
        
        /// <summary>
        /// 上限件数チェック
        /// </summary>
        public bool CheckTotal(int total, bool? queryflg)
        {
            totalrowcount = total;
            //todo warning num and error num
            const int waringNum = 20;
            const int errorNum = 2 * waringNum;
            if (totalrowcount >= errorNum)
            {
                //todo error msg
                SetServiceError("error msg");
                return false;
            }

            if (queryflg == true || totalrowcount < waringNum) return true;

            //todo warning msg
            SetServiceAlert("warning msg");

            return false;
        }
    }
}