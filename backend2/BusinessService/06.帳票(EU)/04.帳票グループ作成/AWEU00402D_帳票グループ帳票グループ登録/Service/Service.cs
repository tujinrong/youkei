// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票グループ帳票グループ登録
//             サービス処理
// 作成日　　: 2023.10.31
// 作成者　　: xiao 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00402D
{
    public class Service : CmServiceBase
    {
        [DisplayName("初期化処理(詳細画面)")]
        public InitResponse InitDetailInfo(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                if (req.editkbn == Enum編集区分.変更)
                {
                    //帳票グループマスタ
                    tm_eurptgroupDto dto = db.tm_eurptgroup.SELECT.WHERE.ByKey(req.rptgroupid).GetDto();
                    //詳細情報を取得
                    Wraper.SetDetailVM(db, res, dto);
                    //更新日時
                    res.upddttm = dto.upddttm;
                }

                //業務区分のドロップダウンリスト
                res.gyomukbnList = DaNameService.GetSelectorList(db, EnumNmKbn.EUC業務区分, Enum名称区分.名称);
                //個人連絡先のドロップダウンリスト
                res.renrakusakicds = GetHanyoSelectorList(db, EnumHanyoKbn.連絡先用事業コード);
                //メモ情報集めるのドロップダウンリスト
                res.memocds = GetHanyoSelectorList(db, EnumHanyoKbn.メモ事業コード);
                //電子ファイル情報集めるのドロップダウンリスト
                res.electronfilecds = GetHanyoSelectorList(db, EnumHanyoKbn.電子ファイル事業コード);
                //フォロー管理集めるのドロップダウンリスト
                res.followmanages = GetHanyoSelectorList(db, EnumHanyoKbn.フォロー把握事業コード);

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();

                //-------------------------------------------------------------
                // １.チェック処理
                //-------------------------------------------------------------
                //帳票グループマスタ
                var rptgroupDto = db.tm_eurptgroup.SELECT.WHERE.ByItem(nameof(tm_eurptgroupDto.rptgroupnm), req.rptgroupnm).GetDto();

                // 帳票グループ名前の重複チェック
                if (req.editkbn == Enum編集区分.新規 && rptgroupDto != null
                    || req.editkbn == Enum編集区分.変更 && rptgroupDto != null && rptgroupDto.rptgroupid != req.rptgroupid)
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, "帳票グループ名前");
                    res.SetServiceError(msg);
                    return res;
                }

                // 更新の場合、排他チェック
                tm_eurptgroupDto? dtoOld = null;
                if (req.editkbn == Enum編集区分.変更)
                {
                    //帳票グループマスタ
                    dtoOld = db.tm_eurptgroup.SELECT.WHERE.ByKey(req.rptgroupid).GetDto();
                    if (dtoOld == null || dtoOld.upddttm != req.upddttm)
                    {
                        throw new AiExclusiveException();
                    }
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                var dttm = DaUtil.Now;
                //帳票グループマスタ情報を取得
                var dto = Converter.GetDto(req, dttm);

                if (req.editkbn == Enum編集区分.新規)
                {
                    //帳票グループマスタから最大ドキュメントシーケンスを取得
                    var maxSeq = db.tm_eurptgroup.SELECT.GetMax<int>(nameof(tm_eurptgroupDto.rptgroupid)) + 1;
                    //帳票グループID
                    dto.rptgroupid = maxSeq.ToString().PadLeft(5, '0');

                    //登録ユーザーID
                    dto.reguserid = req.userid;
                    //登録日時
                    dto.regdttm = dttm;
                }
                else
                {
                    //帳票グループID
                    dto.rptgroupid = req.rptgroupid;
                    //登録ユーザーID
                    dto.reguserid = dtoOld!.reguserid;
                    //登録日時
                    dto.regdttm = dtoOld!.regdttm;
                }

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                if (req.editkbn == Enum編集区分.新規)
                {                   
                    //帳票グループマスタを登録
                    db.tm_eurptgroup.INSERT.Execute(dto);
                }
                else
                {
                    //帳票グループマスタを更新
                    db.tm_eurptgroup.UpdateDto(dto, dtoOld!.upddttm);
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("削除処理")]
        public DaResponseBase Delete(DeleteRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();

                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //EUC帳票マスタ
                var eurptDtl = db.tm_eurpt.SELECT
                            .WHERE.ByFilter($"{nameof(tm_eurptDto.rptgroupid)} = @{nameof(tm_eurptDto.rptgroupid)}", req.rptgroupid).GetDtoList();
                if (eurptDtl.Count != 0 || eurptDtl.Any())
                {
                    res.SetServiceError(EnumMessage.E014001, "帳票グループ");
                    //異常返す
                    return res;
                }
                //帳票グループマスタ
                var dtoOld = db.tm_eurptgroup.SELECT.WHERE.ByKey(req.rptgroupid).GetDto();
                //排他チェック
                if (dtoOld == null || dtoOld.upddttm != req.upddttm)
                {
                    throw new AiExclusiveException();
                }

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                //帳票グループマスタを削除
                db.tm_eurptgroup.DELETE.WHERE.ByKey(req.rptgroupid).Execute();

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 汎用マスタからドロップダウンリスト
        /// </summary>
        private List<DaSelectorModel> GetHanyoSelectorList(DaDbContext db, EnumHanyoKbn kbn)
        {
            return  DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, EnumToStr(kbn)).ToList();
        }
    }
}