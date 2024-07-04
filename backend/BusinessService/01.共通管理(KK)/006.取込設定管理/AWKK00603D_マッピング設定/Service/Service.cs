// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.マッピング設定情報ダイアログ画面
// 　　　　　　サービス処理
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00603D
{
    [DisplayName("取込設定：マッピング設定情報ダイアログ画面")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00603D = "AWKK00603D";

        [DisplayName("初期化処理(取込設定：マッピング設定情報ダイアログ画面)")]
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
                //【マッピング区分】のドロップダウンリスト
                res.mappingkbnList = mainService.GetNameSelectorList(db, EnumNmKbn.マッピング区分);

                //変更の場合
                if (req.editkbn == Enum編集区分.変更)
                {
                    //【マッピング方法】のドロップダウンリスト
                    res.mappingmethodList = GetMappingMethodList(db, req.mappingkbn);
                }

                //取込ファイルIF情報のファイル項目ID＋項目名
                List<string> fileitemList = req.fileitemList;
                //【ファイル項目】のドロップダウンリスト
                res.fileitemseqList = GetFileItemList(fileitemList);
                //【引数区分】のドロップダウンリスト(todo)
                res.hikisukbnList = mainService.GetNameSelectorList(db, EnumNmKbn.引数区分_マッピング);

                //正常返し
                return res;
            });
        }

        [DisplayName("【マッピング方法】初期化処理")]
        public InitMappingMethodResponse InitMappingMethod(InitMappingMethodRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitMappingMethodResponse();
                //マッピング方法のドロップダウンリスト
                res.mappingmethodList = GetMappingMethodList(db, req.mappingkbn);
                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 【マッピング方法】のドロップダウンリストを取得する
        /// </summary>
        private List<DaSelectorKeyModel> GetMappingMethodList(DaDbContext db, string mappingkbn)
        {
            //マッピング区分よりマッピング方法のドロップダウンリスト
            var list = DaNameService.GetNameList(db, EnumNmKbn.マッピング方法).Where(x => x.hanyokbn1 == mappingkbn).Select(d => new DaSelectorKeyModel(d.nmcd, d.nm,d.hanyokbn2)).ToList();
            return list;
        }

        /// <summary>
        /// 【ファイル項目】のドロップダウンリストを取得する
        /// </summary>
        private List<DaSelectorModel> GetFileItemList(List<string> fileItemList)
        {
            var list = new List<DaSelectorModel>();
            if (fileItemList != null)
            {
                foreach (string obj in fileItemList)
                {
                    var item = obj.Split(',');
                    if (item != null && item.Length == 2)
                    {
                        //取込ファイルIF情報のファイル項目ID＋項目名からドロップダウンモデルにセットする
                        var model = new DaSelectorModel(item[0].ToString(), item[1].ToString());
                        list.Add(model);
                    }
                }
            }
            return list;
        }
    }
}