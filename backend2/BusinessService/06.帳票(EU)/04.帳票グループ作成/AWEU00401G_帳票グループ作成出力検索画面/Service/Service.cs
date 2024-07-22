// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票グループ作成出力検索画面
//             サービス処理
// 作成日　　: 2023.10.31
// 作成者　　: xiao 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00401G
{
    public class Service : CmServiceBase
    {
        private const string PROC_NAME = "sp_aweu00401g_01";

        [DisplayName("初期化処理")]
        public InitResponse Init(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //帳票グループマスタ
                var groupDtl = db.tm_eurptgroup.SELECT.ORDER.By(nameof(tm_eurptgroupDto.rptgroupid)).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //帳票グループのドロップダウンリスト
                res.groupList = groupDtl.Select(e => new DaSelectorModel(e.rptgroupid, e.rptgroupnm)).ToList();

                // 正常返し
                return res;
            });
        }

        [DisplayName("帳票グループID取得")]
        public SearchMaxGroupidResponse SearchMaxGroupid(SearchMaxGroupidRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new SearchMaxGroupidResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //帳票グループマスタ
                var sql = $@"
                            select MAX(t.rptgroupid) as rptgroupid                 --帳票グループID
                            from tm_eurptgroup t  
                            where t.rptgroupid like'{req.packageMark}%'                                                           
                            ".Trim();

                var rptDtl = DaDbUtil.GetDataTable(db, sql);
                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //帳票グループID
                string maxGroupId = "00000";
                if (rptDtl.Rows.Count > 0 && rptDtl.Rows[0]["rptgroupid"] != DBNull.Value)
                {
                    maxGroupId = rptDtl.Rows[0]["rptgroupid"].ToString();
                }
                int number = int.Parse(maxGroupId);
                number += 1;
                if ("0".Equals(req.packageMark))
                {
                    // 結果を文字列に変換し、PadLeft を使用して元の長さの先頭のゼロを保持します。
                    res.maxGroupid = number.ToString().PadLeft(maxGroupId.Length, '0');
                }
                else
                {
                    res.maxGroupid = number.ToString();
                }
                // 正常返し
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
                //パラメータを取得
                var parameters = Converter.GetParameters(req);
                //帳票情報取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, parameters, req.pagenum, req.pagesize);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //帳票情報一覧を取得
                res.kekkalist = Wraper.GetSearchVmList(db, pageList.dataTable.Rows);
                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }
    }
}