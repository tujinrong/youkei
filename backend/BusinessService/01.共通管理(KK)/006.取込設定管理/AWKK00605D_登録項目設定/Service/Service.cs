// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.登録項目設定情報ダイアログ画面
// 　　　　　　サービス処理
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWKK00604D;
using BCC.Affect.Service.CheckImporter;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00605D
{
    [DisplayName("取込設定：登録項目設定情報ダイアログ画面")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00605D = "AWKK00605D";

        [DisplayName("初期化処理(取込設定：登録項目設定情報ダイアログ画面)")]
        public InitResponse InitDetail(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();

                var mainService = new AWKK00601G.Service();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------

                //ドロップダウンリストの初期化データ

                //画面項目情報の画面項目ID＋項目名からドロップダウンモデルにセットするリストを取得する
                var pageitemList = GetPageItemList(req.pageitemList);
                //【データ元画面項目ID】のドロップダウンリスト
                res.pageitemseqList = pageitemList;
                //【処理区分】のドロップダウンリスト
                res.syorikbnList = mainService.GetNameSelectorList(db, EnumNmKbn.処理区分).OrderBy(o => CInt(o.value)).ToList();

                //正常返し
                return res;
            });
        }

        [DisplayName("フィールドドロップダウン初期化処理")]
        public InitFieldidResponse InitFieldid(InitFieldidRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitFieldidResponse();
                //テーブルIDより一括取込入力テーブル項目マスタからドロップダウンモデルにセットするリストを取得する
                var fieldIDList = GetFieldIDList(db, req.tableid);
                //フィールドのドロップダウンリスト
                res.fieldidList = fieldIDList;

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// テーブルIDより一括取込入力テーブル項目マスタからドロップダウンモデルにセットするリストを取得する
        /// </summary>
        private List<DaSelectorModel> GetFieldIDList(DaDbContext db, string tableid)
        {
            //一括取込入力テーブル項目マスタ
            var tablefieldList = ImDBUtil.GetFieldList(db, tableid);

            var list = new List<DaSelectorModel>();
            foreach (var field in tablefieldList)
            {
                //テーブルIDより一括取込入力テーブル項目マスタからドロップダウンモデルにセットする
                var vm = new DaSelectorModel(field.FieldName, field.FieldComment);

                list.Add(vm);
            }
            return list;
        }

        /// <summary>
        /// 画面項目情報の画面項目ID＋項目名からドロップダウンモデルにセットするリストを取得する
        /// </summary>
        private List<DaSelectorModel> GetPageItemList(List<string> pageItemList)
        {
            var list = new List<DaSelectorModel>();
            if (pageItemList != null)
            {
                foreach (string obj in pageItemList)
                {
                    var item = obj.Split(',');
                    if (item != null && item.Length == 2)
                    {
                        //画面項目情報の画面項目ID＋項目名からドロップダウンモデルにセットする
                        var model = new DaSelectorModel(item[0].ToString(), item[1].ToString());
                        list.Add(model);
                    }
                }
            }

            return list;
        }
    }
}