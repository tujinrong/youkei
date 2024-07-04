// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: パスワード変更
//             サービス処理
// 作成日　　: 2023.01.19
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00201D
{
    [DisplayName("パスワード変更")]
    public class Service : CmServiceBase
    {
        [DisplayName("保存処理")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var res = new DaResponseBase();
                var dto = db.tm_afuser.GetDtoByKey(req.userid);

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (req.checkflg)
                {                
                    //旧パスワードチェック
                    if (req.oldpword != dto.pword)
                    {
                        res.SetServiceError(DaMessageService.GetMsg(EnumMessage.ITEM_ILLEGAL_ERROR, "旧パスワード"));
                        //異常返し
                        return res;
                    }

                    //正常返し
                    return res;
                }

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto)) return res; //異常返し
                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                dto = Converter.GetDto(req, dto);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //ユーザーマスタ
                db.tm_afuser.UpdateDto(dto, dto.upddttm);

                //正常返し
                return res;
            });
        }
    }
}