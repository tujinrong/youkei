// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 抽出情報指定（専用）
//             リクエストインターフェース
// 作成日　　: 2024.06.03
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst;

namespace BCC.Affect.Service.AWKK01302D
{
    [DisplayName("帳票発行対象者抽出情報管理（専用）")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK01301G = "AWKK01302D";

        [DisplayName("初期化処理")]
        public InitResponse Init(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //抽出対象一覧
                var mstDtl = db.tm_kktyusyutu.SELECT.WHERE.ByItem(nameof(tm_kktyusyutuDto.tyusyutukinoid), req.kinoid)
                                             .ORDER.By(nameof(tm_kktyusyutuDto.orderseq)).GetDtoList();
                //年度管理されているかどうかの設定
                var nendoSetting = Common.Wraper.GetNendoSetting(db, req.kinoid);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(抽出対象)
                res.selectorlist = mstDtl.Select(e => new DaSelectorKeyModel(e.tyusyututaisyocd, e.tyusyututaisyonm, e.tuticycle)).OrderBy(e => e.value).ToList();
                //年度表示フラグ設定
                res.nendoflg = (nendoSetting == 名称マスタ.システム.通知サイクル._1);

                //正常返し
                return res;
            });
        }

        [DisplayName("個別除外チェック")]
        public CheckResponse Check(CheckRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new CheckResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //年度管理されているかどうかの設定
                var nendoSetting = Common.Wraper.GetNendoSetting(db, req.kinoid);

                //抽出対象
                var mstDto = db.tm_kktyusyutu.SELECT.WHERE.ByKey(req.tyusyututaisyocd!).GetDto();
                //抽出情報一覧
                var dataDtl = db.tt_kktaisyosya_tyusyutu.SELECT.WHERE.ByItem(nameof(tt_kktaisyosya_tyusyutuDto.tyusyututaisyocd), req.tyusyututaisyocd).GetDtoList();

                //抽出シーケンス
                var keylist = new List<long>();
                if (nendoSetting == 名称マスタ.システム.通知サイクル._1)
                {
                    //年度管理されている場合
                    var nendoDataDtl = dataDtl.Where(e => e.nendo == req.nendo).ToList();
                    keylist = nendoDataDtl.Select(e => e.tyusyutuseq).Distinct().ToList();
                }
                else
                {
                    //年度管理されていない場合
                    keylist = dataDtl.Select(e => e.tyusyutuseq).ToList();
                }

                //抽出対象者一覧
                var subDataDtl = db.tt_kktaisyosya_tyusyutu_sub.SELECT.WHERE.ByKeyList(keylist).GetDtoList();
                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //過去に抽出したデータがあるかどうか
                var atenanos = subDataDtl.Select(e => e.atenano).Distinct().ToList();
                if (atenanos.Exists(e => e.Equals(req.atenano)))
                {
                    //Max抽出シーケンスを取得する
                    var maxseq = subDataDtl.Where(e => e.atenano == req.atenano).ToList()
                                            .OrderByDescending(e => e.tyusyutuseq).Select(e => e.tyusyutuseq).FirstOrDefault();
                    //抽出シーケンスが最大の抽出メイン情報を取得する
                    var dataDto = dataDtl.Where(e => e.tyusyutuseq == maxseq).FirstOrDefault();
                    //その抽出メイン情報の抽出サブ情報を取得する
                    var subDataDtl2 = subDataDtl.Where(e => e.tyusyutuseq == maxseq).ToList();

                    //過去に抽出したデータを設定する
                    res.tyusyutuinfo = Wraper.GetVM(db, mstDto, dataDto!, subDataDtl2);

                    //再抽出除外する場合
                    if (mstDto.saityusyutujogaiflg)
                    {
                        res.SetServiceAlert(EnumMessage.K013005);
                        //異常返す
                        return res;

                    }
                    //再抽出除外しない場合
                    else
                    {
                        res.SetServiceAlert(EnumMessage.K013004);
                        //異常返す
                        return res;
                    }

                }

                //正常返し
                return res;
            });
        }
    }
}