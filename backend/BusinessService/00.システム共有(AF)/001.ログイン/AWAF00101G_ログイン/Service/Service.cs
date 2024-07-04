// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ログイン
//             サービス処理
// 作成日　　: 2023.01.18
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00101G
{
    [DisplayName("ログイン")]
    public class Service : CmServiceBase
    {
        [DisplayName("ログイン処理")]
        public LoginResponse Login(LoginRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new LoginResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //ユーザーマスタ
                var dto = db.tm_afuser.GetDtoByKey(req.userid);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.USER_LOGIN_ERROR) || (req.userid == DaConst.SYSTEM))
                {
                    return res;   //異常返し
                }

                var today = DaUtil.Today;
                var errs = CInt(dto.errorkaisu);        //ログインエラー回数
                var pwdymd = CDate(dto.pwordhenkoymd);  //パスワード変更年月日

                //コントロールマスタから情報をまとめて取得
                var ctrInfo = DaControlService.GetList(db, EnumCtrlKbn.パスワード);
                //エラー回数上限
                var maxErrs = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._08)!.IntValue1;
                //パスワード有効期限チェック設定フラグ
                var pwdCheckFlg = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._10)!.BoolValue1;
                //パスワード有効日数(有効期限チェック=true)
                var pwdEnableDays = pwdCheckFlg ? ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._01)!.IntValue1 : 0;
                //パスワード変更通知開始日数(有効期限チェック=true)
                var pwdAlertDays = pwdCheckFlg ? ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._02)!.IntValue1 : 0;

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (errs >= maxErrs)
                {
                    //上限回数以上連続認証失敗する場合
                    res.SetServiceError(EnumMessage.USER_LOCK_ERROR);
                }
                else if (dto.pword != req.pword)
                {
                    //パスワードが間違った場合
                    res.SetServiceError(EnumMessage.USER_LOGIN_ERROR);
                }
                else if (today < CDate(dto.yukoymdf) || today > CDate(dto.yukoymdt))
                {
                    //ユーザーアカウントが有効期限範囲外の場合
                    res.SetServiceError(EnumMessage.USER_ACCOUNT_OUT_ERROR);
                }
                else if (pwdCheckFlg && pwdEnableDays > 0 && today > pwdymd.AddDays(pwdEnableDays - 1))
                {
                    //ユーザーのパスワードが有効期限範囲外の場合
                    res.SetServiceError(EnumMessage.USER_PWD_OUT_ERROR);
                }

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //エラーがある場合、エラー回数＋1
                if (res.returncode != EnumServiceResult.OK)
                {
                    dto.errorkaisu += 1;
                    //ユーザーマスタ
                    db.tm_afuser.UpdateDto(dto, dto.upddttm);
                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //４.その他処理
                //-------------------------------------------------------------
                if (req.kbn == Enumログイン区分.一回目)
                //登録支所未選択の場合
                {
                    //支所一覧を取得
                    var hanyodtl = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.部署_支所);
                    //ユーザー所属部署（支所）テーブル
                    var sisyoDtl = db.tt_afuser_sisyo.SELECT.SetSelectItems(nameof(tt_afuser_sisyoDto.sisyocd)).
                                    WHERE.ByKey(req.userid).GetDtoList();
                    //ログインユーザーの支所一覧を取得
                    var cdList = sisyoDtl.Select(e => e.sisyocd).ToList();
                    var list = hanyodtl.Where(e => cdList.Contains(e.hanyocd)).Select(e => Common.Wraper.GetSisyoVM(e)).OrderBy(e => e.sisyocd).ToList();
                    res.sisyolist = list;
                }
                //登録支所を選択して正式ログイン成功した場合のみ
                else
                {
                    //正常の場合、エラー回数をクリア
                    dto.errorkaisu = 0;
                    //ユーザーマスタ
                    db.tm_afuser.UpdateDto(dto, dto.upddttm);

                    //ユーザー情報設定
                    if (dto.authsetflg)
                    {
                        res.userinfo = Wraper.GetUserInfoVM(dto, null);
                    }
                    else
                    {
                        var syozokuDto = db.tm_afsyozoku.GetDtoByKey(dto.syozokucd!);
                        res.userinfo = Wraper.GetUserInfoVM(dto, syozokuDto);
                    }

                    //トークンの設定
                    var tokenId = DaTokenService.SaveToken(db, req.userid, req.regsisyo, dto);
                    //トークンの取得
                    res.token = DaTokenService.GetToken(tokenId, req.userid, req.regsisyo);

                    //パスワード変更通知フラグの設定
                    if (pwdCheckFlg && pwdEnableDays > 0 && pwdAlertDays > 0)
                    {
                        //パスワード期限切れ警告チェック
                        if (today > pwdymd.AddDays(pwdEnableDays - 1).AddDays(0 - pwdAlertDays))
                        {
                            //パスワード変更可能の残り日数
                            var ts = pwdymd.AddDays(pwdEnableDays) - today;
                            res.message = DaMessageService.GetMsg(EnumMessage.C003001, ts.Days);
                            res.pwdmsgflg = true;   //警告フラグ
                        }
                        else
                        {
                            res.pwdmsgflg = false;  //警告フラグ
                        }
                    }
                }

                //正常返し
                return res;
            });
        }
    }
}