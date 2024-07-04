// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.変換区分管理画面
// 　　　　　　サービス処理
// 作成日　　: 2024.03.06
// 作成者　　: 高
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00609D
{
    [DisplayName("取込設定：変換区分管理画面")]
    public class Service : CmServiceBase
    {
        [DisplayName("初期化処理(取込設定：変換区分管理画面)")]
        public InitResponse InitDetail(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //【コ-ド管理テ-プル】のドロップダウンリストを取得
                res.codeManagerTableList = DaNameService.GetSelectorList(db, EnumNmKbn.コード管理テーブル, Enum名称区分.名称);

                //-------------------------------------------------------------
                //2.データ加工処理
                //-------------------------------------------------------------
                List<ChangeCodeMainExVM> list = new List<ChangeCodeMainExVM>();
                foreach (var changeCodeMain in req.changeCodeMainList)
                {
                    var vm = new ChangeCodeMainExVM();
                    vm.codehenkankbn = changeCodeMain.codehenkankbn;                                                    //コード変換区分
                    vm.codekanritablenm = changeCodeMain.codekanritablenm;                                              //変換区分名称
                    vm.henkankbnnm = changeCodeMain.henkankbnnm;                                                        //コード管理テーブル名
                    vm.maincd = changeCodeMain.maincd;                                                                  //メインコード
                    vm.subcd = changeCodeMain.subcd;                                                                    //サブコード
                    vm.sonotajoken = changeCodeMain.sonotajoken;                                                        //その他条件
                    vm.rowMaincdList = GetMaincdList(db, changeCodeMain.codekanritablenm);                              //行【メインコード】のドロップダウンリスト
                    vm.rowSubcdList = GetSubcdList(db, changeCodeMain.codekanritablenm, changeCodeMain.maincd);         //行【サブコード】のドロップダウンリスト
                    list.Add(vm);
                }
                //変換コードメイン補充情報を取得
                res.changeCodeMainExList = list;    

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(【メインコード】のドロップダウンリスト)")]
        public InitMaincdResponse InitMaincdList(InitMaincdRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitMaincdResponse();

                //-------------------------------------------------------------
                //データ加工処理
                //-------------------------------------------------------------
                //【メインコード】のドロップダウンリストを取得
                res.maincdList = GetMaincdList(db, req.tablename);

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(【サブコード】のドロップダウンリスト)")]
        public InitSubcdResponse InitSubcdList(InitSubcdRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitSubcdResponse();

                //-------------------------------------------------------------
                //データ加工処理
                //-------------------------------------------------------------
                //【サブコード】のドロップダウンリストを取得
                res.subcdList = GetSubcdList(db, req.tablename, req.maincd);

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// メインコードのドロップダウンリストを取得
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        private List<DaSelectorModel> GetMaincdList(DaDbContext db, string tablename)
        {
            EnumNmKbn enumNmKbn;
            if (tablename == tm_afmeisyoDto.TABLE_NAME)
            {
                enumNmKbn = EnumNmKbn.名称マスタメインコード;
            }
            else
            {
                enumNmKbn = EnumNmKbn.汎用マスタメインコード;
            }

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            return DaNameService.GetSelectorList(db, enumNmKbn, Enum名称区分.名称);
        }

        /// <summary>
        /// サブコードのドロップダウンリストを取得
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tablename"></param>
        /// <param name="maincd"></param>
        /// <returns></returns>
        private List<DaSelectorModel> GetSubcdList(DaDbContext db, string tablename, string maincd)
        {
            if (tablename == tm_afmeisyoDto.TABLE_NAME)
            {
                //名称メインマスタ情報を取得
                var dtl = db.tm_afmeisyo_main.SELECT.WHERE.ByKey(maincd).GetDtoList();
                return Wraper.GetSelectorList(dtl);
            }
            else
            {
                //汎用メインマスタ情報を取得
                var dtl = db.tm_afhanyo_main.SELECT.WHERE.ByKey(maincd).GetDtoList();
                return Wraper.GetSelectorList(dtl);
            }
        }
    }
}