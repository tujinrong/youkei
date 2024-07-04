// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: トークン管理
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using Newtonsoft.Json;
using static BCC.Affect.DataAccess.DaStrPool;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.DataAccess
{
    public class DaTokenService
    {
        /// <summary>
        /// ログインの時に呼び出し
        /// </summary>
        /// <param name="SID"></param>
        /// <returns></returns>
        public static long SaveToken(DaDbContext db, string userid, string? regsisyo, tm_afuserDto userDto)
        {
            // 同じユーザー同時ログイン可
            //tc_aftokenDao.DELETE(new AiSessionModel()).WHERE.ByItem(nameof(tt_aftokenDto.userid), userid).Execute();
            var dto = GetDto(db, userid, regsisyo, userDto);
            db.tt_aftoken.INSERT.Execute(dto);
            db.tt_aftoken.DELETE.WHERE.ByFilter($"{nameof(tt_aftokenDto.accessdttm)}<@{nameof(tt_aftokenDto.accessdttm)}", DaUtil.Now.AddDays(-1)).Execute();
            return dto.tokenseq;
        }

        public static void DeleteUserID(DaDbContext db, string userID)
        {
            db.tt_aftoken.DELETE.WHERE.ByItem(nameof(tt_aftokenDto.userid), userID).Execute();
        }

        public static void DeleteUserID(DaDbContext db, List<string> list)
        {
            db.tt_aftoken.DELETE.WHERE.ByItemList(nameof(tt_aftokenDto.userid), list).Execute();
        }

        public static void DeleteAll(DaDbContext db)
        {
            db.tt_aftoken.DELETE.WHERE.ByFilter("1=1").Execute();
        }

        /// <summary>
        /// トークンに変換
        /// </summary>
        public static string GetToken(long tokenID, string userid, string? regsisyo)
        {
            return DaEncryptUtil.TokenEncrypt(tokenID.ToString(), userid, regsisyo);
        }

        /// <summary>
        /// トークンIDに変換
        /// </summary>
        public static long GetTokenUD(string token, string userid, string? regsisyo)
        {
            return CLng(DaEncryptUtil.TokenDecrypt(token, userid, regsisyo));
        }

        /// <summary>
        /// トークンテーブル
        /// </summary>
        public static bool Validate(DaDbContext db, string token, ref string userid, ref string? regsisyo, ref string message)
        {
            long tokenseq = GetTokenUD(token, userid, regsisyo);
            Console.WriteLine("=============tokenseq===========");
            Console.WriteLine(tokenseq);
            Console.WriteLine(DaUtil.Now);
            var dto = db.tt_aftoken.GetDtoByKey(tokenseq);
            if (dto is null)
            {
                message = "検証失敗！";
                return false;
            }
            var lasttime = dto.accessdttm;
            var TimeOut = lasttime.Add(DaControlService.GetSystemConfig(db).TokenTimeout);
            Console.WriteLine("=============lasttime===========");
            Console.WriteLine(lasttime);
            Console.WriteLine(DaUtil.Now);
            Console.WriteLine("=============TimeOut===========");
            Console.WriteLine(TimeOut);
            Console.WriteLine(DaUtil.Now);
            if (TimeOut < DaUtil.Now)
            {
                db.tt_aftoken.DeleteByKey(tokenseq);
                message = "期限が切れた！";
                return false;
            }
            else
            {
                dto.accessdttm = DaUtil.Now;
                db.tt_aftoken.UpdateDto(dto);
                userid = dto.userid;
                return true;
            }
            //message = "検証成功";
        }
        /// <summary>
        /// トークンテーブル
        /// </summary>
        private static tt_aftokenDto GetDto(DaDbContext db, string userid, string? regsisyo, tm_afuserDto userDto)
        {
            var dto = new tt_aftokenDto();
            dto.userid = userid;                //ユーザーID
            dto.regsisyo = regsisyo;            //登録支所
            dto.accessdttm = DaUtil.Now;        //アクセス日時
            dto.syozokucd = userDto.syozokucd;  //所属グループコード

            //権限設定がユーザー権限の場合
            if (userDto.authsetflg)
            {
                dto.rolekbn = Enumロール区分.ユーザー;
                dto.kanrisyaflg = userDto.kanrisyaflg;                                                                  //管理者フラグ
                dto.pnoeditflg = userDto.pnoeditflg;                                                                    //個人番号操作権限付与フラグ
                dto.alertviewflg = userDto.alertviewflg;                                                                //警告参照フラグ
                dto.sisyocd = string.Join(COMMA, GetSisyoList(db, Enumロール区分.ユーザー, userid));                    //更新可能支所一覧
                dto.gamenauth = JsonConvert.SerializeObject(GetGamenAuthList(db, Enumロール区分.ユーザー, userid));     //画面権限(共通バーを含む)
            }
            //権限設定が所属権限の場合
            else
            {
                var syozokuDto = db.tm_afsyozoku.GetDtoByKey(userDto.syozokucd!);
                dto.rolekbn = Enumロール区分.所属;
                dto.kanrisyaflg = syozokuDto.kanrisyaflg;                                                                   //管理者フラグ
                dto.pnoeditflg = syozokuDto.pnoeditflg;                                                                     //個人番号操作権限付与フラグ
                dto.alertviewflg = syozokuDto.alertviewflg;                                                                 //警告参照フラグ
                dto.sisyocd = string.Join(COMMA, GetSisyoList(db, Enumロール区分.所属, userDto.syozokucd!));                //更新可能支所一覧
                dto.gamenauth = JsonConvert.SerializeObject(GetGamenAuthList(db, Enumロール区分.所属, userDto.syozokucd!)); //画面権限(共通バーを含む)
            }
            return dto;
        }
        /// <summary>
        /// 更新可能支所一覧
        /// </summary>
        private static List<string> GetSisyoList(DaDbContext db, Enumロール区分 rolekbn, string roleid)
        {
            var list = new List<string>();
            var dtl = db.tt_afauthsisyo.SELECT.WHERE.ByKey(EnumToStr(rolekbn), roleid).GetDtoList();
            list = dtl.Select(e => e.sisyocd).ToList();
            return list;
        }
        /// <summary>
        /// 画面権限一覧
        /// </summary>
        private static List<GamenModel> GetGamenAuthList(DaDbContext db, Enumロール区分 rolekbn, string roleid)
        {
            var list = new List<GamenModel>();
            var dtl = db.tt_afauthgamen.SELECT.WHERE.ByKey(EnumToStr(rolekbn), roleid).GetDtoList();
            foreach (var dto in dtl)
            {
                list.Add(GetModel(dto));
            }
            return list;
        }
        /// <summary>
        /// 画面権限
        /// </summary>
        private static GamenModel GetModel(tt_afauthgamenDto dto)
        {
            var model = new GamenModel();
            model.programkbn = dto.programkbn;          //プログラム区分(0:画面;1:共通バー)
            model.menuid = dto.kinoid;                  //機能ID
            model.addflg = dto.addflg;                  //追加権限フラグ
            model.updateflg = dto.updateflg;            //修正権限フラグ
            model.deleteflg = dto.deleteflg;            //削除権限フラグ
            model.personalnoflg = dto.personalnoflg;    //個人番号利用権限フラグ
            return model;
        }
    }
}