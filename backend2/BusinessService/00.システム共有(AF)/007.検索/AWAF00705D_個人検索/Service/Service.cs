// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 個人検索
// 　　　　　　サービス処理
// 作成日　　: 2024.04.01
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst;

namespace BCC.Affect.Service.AWAF00705D
{
    [DisplayName("個人検索")]
    public class Service : CmServiceBase
    {
        /// <summary>
        /// 検索処理
        /// </summary>
        private const string PROC_NAME = "sp_awaf00705d_01";

        [DisplayName("初期化処理")]
        public InitResponse Init(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(性別)
                res.sexlist = DaNameService.GetSelectorList(db, EnumNmKbn.性別_システム共有, Enum名称区分.名称);
                //ドロップダウンリスト(住民区分)
                res.juminkbnlist = DaNameService.GetSelectorList(db, EnumNmKbn.住民区分, Enum名称区分.名称);
                //ドロップダウンリスト(保険区分)
                res.hokenkbnlist = DaNameService.GetSelectorList(db, EnumNmKbn.保険区分_共通管理, Enum名称区分.名称);
                //ドロップダウンリスト(住民区分)初期値(コード値「5」未満の選択肢は選択状態とする)
                res.juminkbns = res.juminkbnlist.Where(e => DaConvertUtil.CInt(e.value) < 5).Select(e=>e.value).ToArray();

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ取得
                var param = Converter.GetParameters(req);

                //個人情報一覧取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, param, req.pagenum, req.pagesize, req.orderby);

                //警告参照フラグ取得
                var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
                //住所表記フラグ
                var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面項目設定
                res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows, alertviewflg, adrsFlg);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }
    }
}