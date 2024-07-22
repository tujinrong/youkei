// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 連絡先
// 　　　　　　サービス処理
// 作成日　　: 2023.07.13
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00605D
{
    [DisplayName("連絡先")]
    public class Service : CmServiceBase
    {
        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //利用事業(コード：名称)
                var jigyo = CmLogicUtil.GetJigyocdSelectorList(db, Enum事業コード区分.連絡先, req.kinoid!, Enum名称区分.名称, req.patternno, false)![0].ToString();
                //利用事業コード
                var jigyocd = DaSelectorService.GetCd(jigyo);
                //連絡先タブ区分
                var kbn = (Enum連絡先タブ区分)CInt(DaNameService.GetKbn2(db, EnumNmKbn.共通バー表示, $"{req.kinoid!}{DaStrPool.DASHED}{(int)Enum共通バー番号.連絡先}").Split(DaStrPool.DASHED)[1]);

                //キーリスト取得(タブ)
                var keylist = GetKeyList(db, req.atenano, kbn);
                //キーリスト取得(連絡先)
                var keylist2 = keylist.Select(e => new object[] { e.atenano, jigyocd }).ToList();
                //キーリスト取得(宛名)
                var keylist3 = keylist.Select(e => e.atenano).ToList();

                //連絡先テーブル
                var dtl1 = db.tt_afrenrakusaki.SELECT.WHERE.ByKeyList(keylist2).GetDtoList();
                //宛名テーブル
                var dtl2 = db.tt_afatena.SELECT.WHERE.ByKeyList(keylist3).GetDtoList();

                //更新可能支所一覧
                var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

                //登録支所
                var dtl3 = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.部署_支所);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //連絡先情報一覧
                res.kekkalist = Wraper.GetVMList(db, sisyoList, dtl1, dtl2, dtl3, keylist, jigyocd, jigyo);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //利用事業コード
                var jigyocd = DaSelectorService.GetCd(req.detailinfo.jigyo);
                //連絡先テーブル
                var newDto = new tt_afrenrakusakiDto();
                var oldDto = db.tt_afrenrakusaki.GetDtoByKey(req.detailinfo.atenano, jigyocd);

                //編集区分を取得
                var kbn = Enum編集区分.変更;
                if (req.detailinfo.upddttm == null && oldDto == null)
                {
                    kbn = Enum編集区分.新規;
                }
                else
                {
                    newDto = oldDto;
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                newDto = Converter.GetDto(req.detailinfo, newDto, jigyocd);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //新規の場合
                if (kbn == Enum編集区分.新規)
                {
                    db.tt_afrenrakusaki.INSERT.SetDiffLogParameter(null).Execute(newDto);
                }
                //更新の場合
                else
                {
                    db.tt_afrenrakusaki.UPDATE.SetDiffLogParameter(null).SetLock(req.detailinfo.upddttm!.Value).Execute(newDto);
                }

                //正常返し
                return new DaResponseBase();
            });
        }

        [DisplayName("削除処理")]
        public DaResponseBase Delete(DeleteRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //利用事業コード
                var jigyocd = DaSelectorService.GetCd(req.jigyo);

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                db.tt_afrenrakusaki.DELETE.SetDiffLogParameter(null).WHERE.ByKey(req.atenano, jigyocd).SetLock(req.upddttm).Execute();

                //正常返し
                return new DaResponseBase();
            });
        }

        /// <summary>
        /// キーリスト取得
        /// </summary>
        private List<KeyVM> GetKeyList(DaDbContext db, string atenano, Enum連絡先タブ区分 kbn)
        {
            var list = new List<KeyVM>();

            switch (kbn)
            {
                case Enum連絡先タブ区分.妊娠届出情報:
                    //本人
                    list.Add(new KeyVM(atenano, Enum連絡先タブ名称.本人));
                    //todo 仕様未定
                    //tt_afninsintodoke 妊娠届出テーブル
                    //父親
                    //var dto1 = db.tt_afatena.SELECT.WHERE.ByKey(atenano).GetDto();
                    //if (!string.IsNullOrEmpty(dto1?.atenano))
                    //{
                    list.Add(new KeyVM("800000000000001", Enum連絡先タブ名称.父親));
                    //}
                    break;

                case Enum連絡先タブ区分.出生時状況:
                    //本人
                    list.Add(new KeyVM(atenano, Enum連絡先タブ名称.本人));
                    //todo 仕様未定
                    //母親
                    //var dto1 = db.tt_afatena.SELECT.WHERE.ByKey(atenano).GetDto();
                    //if (!string.IsNullOrEmpty(dto1?.atenano))
                    //{
                    list.Add(new KeyVM("800000000000002", Enum連絡先タブ名称.母親));
                    //}
                    //父親
                    //var dto1 = db.tt_afatena.SELECT.WHERE.ByKey(atenano).GetDto();
                    //if (!string.IsNullOrEmpty(dto1?.atenano))
                    //{
                    list.Add(new KeyVM("800000000000001", Enum連絡先タブ名称.父親));
                    //}
                    //保護者
                    //var dto1 = db.tt_afatena.SELECT.WHERE.ByKey(atenano).GetDto();
                    //if (!string.IsNullOrEmpty(dto1?.atenano))
                    //{
                    list.Add(new KeyVM("800000000000003", Enum連絡先タブ名称.保護者));
                    //}
                    break;

                case Enum連絡先タブ区分.他市町村_医療機関等への接種依頼:
                    //本人
                    list.Add(new KeyVM(atenano, Enum連絡先タブ名称.本人));
                    //todo 仕様未定
                    //保護者
                    //var dto1 = db.tt_afatena.SELECT.WHERE.ByKey(atenano).GetDto();
                    //if (!string.IsNullOrEmpty(dto1?.atenano))
                    //{
                    list.Add(new KeyVM("800000000000003", Enum連絡先タブ名称.保護者));
                    //}
                    break;

                case Enum連絡先タブ区分.健康被害救済制度情報:
                    //該当者
                    list.Add(new KeyVM(atenano, Enum連絡先タブ名称.該当者));
                    //todo 仕様未定
                    //保護者
                    //var dto1 = db.tt_afatena.SELECT.WHERE.ByKey(atenano).GetDto();
                    //if (!string.IsNullOrEmpty(dto1?.atenano))
                    //{
                    list.Add(new KeyVM("800000000000003", Enum連絡先タブ名称.保護者));
                    //}
                    break;

                case Enum連絡先タブ区分.その他:
                    //本人
                    list.Add(new KeyVM(atenano, Enum連絡先タブ名称.本人));
                    break;

                default:
                    throw new Exception("Enum連絡先タブ区分 error");
            }

            return list;
        }
    }
}