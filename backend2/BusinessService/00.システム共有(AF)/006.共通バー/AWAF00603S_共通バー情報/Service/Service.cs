// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 共通バー情報
// 　　　　　　サービス処理
// 作成日　　: 2024.07.10
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00603S
{
    [DisplayName("共通バー情報")]
    public class Service : CmServiceBase
    {
        private const string PROC_NAME = "sp_awaf00603s_01";

        [DisplayName("初期化処理")]
        public InitResponse Init(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //共通バー一覧(全て)
                var barList = DaNameService.GetNameList(db, EnumNmKbn.共通バー表示).Where(e => e.hanyokbn1 == req.kinoid && e.hanyokbn3 == EnumToStr(Enum表示.表示)).ToList();
                //共通バーNo.一覧(全て)
                var barnoList = barList.Select(e => e.hanyokbn2!.Split(DaStrPool.DASHED)[0]).ToList();
                //名称マスタ
                var dtl = DaNameService.GetNameList(db, EnumNmKbn.共通バー番号_共通機能).Where(d => barnoList.Contains(d.nmcd)).OrderBy(d => CInt(d.nmcd)).ToList();
                //共通バー機能ID一覧(全て)
                var barKinoidList = dtl.Select(e => e.hanyokbn1).ToList();

                //共通バー一覧(アクセス可)
                var authList = CmLogicUtil.GetAuthList(db, req.token, req.userid, req.regsisyo).Where(e => e.programkbn == Enumプログラム区分.共通バー機能).ToList();

                //世帯番号取得
                var setaino = db.tt_afatena.GetDtoByKey(req.atenano)?.setaino ?? string.Empty;

                //事業コード一覧：AWAF00601D_メモ情報、AWAF00604D_メモ情報（世帯）
                var keyList1 = new List<string>();
                if (barKinoidList.Contains("AWAF00601D") || barKinoidList.Contains("AWAF00604D"))
                {
                    keyList1 = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.メモ, req.kinoid!, req.patternno, false);
                }
                //事業コード一覧：AWAF00602D_電子ファイル情報
                var keyList2 = new List<string>();
                if (barKinoidList.Contains("AWAF00602D"))
                {
                    keyList2 = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.電子ファイル, req.kinoid!, req.patternno, false);
                }

                //事業コード一覧：AWAF00605D_連絡先
                var keyList3 = new List<string>();
                if (barKinoidList.Contains("AWAF00605D"))
                {
                    keyList3 = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.連絡先, req.kinoid!, req.patternno, false);
                }

                //事業コード一覧：AWAF00609D_フォロー管理
                var keyList4 = new List<string>();
                if (barKinoidList.Contains("AWAF00609D"))
                {
                    keyList4 = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.フォロー事業, req.kinoid!, req.patternno, false);
                }

                //パラメータ取得
                var param = Converter.GetParameters(req, keyList1, keyList2, keyList3, keyList4, setaino);

                //注意フラグ一覧
                var dt = DaDbUtil.GetProcedureData(db, PROC_NAME, param);

                //警告参照フラグ取得
                var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面項目設定
                res.kekkalist = Wraper.GetVMList(db, dtl, dt.Rows, authList, alertviewflg);

                //正常返し
                return res;
            });
        }
    }
}