// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ユーザー管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.07.04
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00901G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            var paras = new List<AiKeyValue>();
            if (req.rolekbn == Enumロール区分.ユーザー)
            {
                //ユーザーID
                paras.Add(new AiKeyValue($"{nameof(tm_afuserDto.userid)}_in", CmLogicUtil.GetSearchPara(req.user)));
            }
            //所属グループコード
            paras.Add(new AiKeyValue($"{nameof(tm_afsyozokuDto.syozokucd)}_in", CmLogicUtil.GetSearchPara(req.syozoku)));

            return paras;
        }

        /// <summary>
        /// ユーザーマスタ
        /// </summary>
        public static tm_afuserDto GetDto(tm_afuserDto dto, UserSaveVM vm, string userid)
        {
            dto.userid = userid;                                            //ユーザーID
            dto.syozokucd = ToNStr(DaSelectorService.GetCd(vm.syozoku));    //所属グループコード
            dto.authsetflg = vm.authsetflg;                                 //権限設定フラグ
            dto.stopflg = vm.stopflg;                                       //使用停止フラグ
            dto.usernm = vm.usernm;                                         //ユーザー名
            dto.yukoymdf = vm.yukoymdf;                                     //有効年月日（開始）
            dto.yukoymdt = vm.yukoymdt;                                     //有効年月日（終了）
            dto.errorkaisu = vm.errorkaisu;                                 //ログインエラー回数
            //パスワードが空白の場合、更新なしとして認識する
            if (!string.IsNullOrEmpty(vm.pword))
            {
                dto.pword = vm.pword;                                       //パスワード
                dto.pwordhenkoymd = FormatYMD(DaUtil.Today);                //パスワード変更年月日
            }

            dto.kanrisyaflg = vm.kanrisyaflg;                               //管理者フラグ
            dto.pnoeditflg = vm.pnoeditflg;                                 //個人番号操作権限付与フラグ
            dto.alertviewflg = vm.alertviewflg;                             //警告参照フラグ
            dto.kanrisyakeisyoflg = vm.kanrisyakeisyoflg;                   //管理者継承フラグ
            dto.pnoeditkeisyoflg = vm.pnoeditkeisyoflg;                     //個人番号操作権限付与継承フラグ
            dto.alertviewkeisyoflg = vm.alertviewkeisyoflg;                 //警告参照継承フラグ
            dto.authsisyokeisyoflg = vm.authsisyokeisyoflg;                 //部署（支所）別更新権限継承フラグ

            return dto;
        }

        /// <summary>
        /// ユーザーマスタリスト(継承用)
        /// </summary>
        public static List<tm_afuserDto> GetDtl(List<tm_afuserDto> dtl, tm_afsyozokuDto dto, List<string> delList, List<string> keyList)
        {
            return dtl.Select(e => GetDto(e, dto, delList, keyList)).ToList();
        }

        /// <summary>
        /// ユーザー所属部署（支所）テーブルリスト
        /// </summary>
        public static List<tt_afuser_sisyoDto> GetDtl(List<CmSisyoVM> list, string userid)
        {
            //支所コード一覧を取得
            var lst = list.Select(e => e.sisyocd).ToList();
            return lst.Select(r => GetDto(userid, r)).ToList();
        }

        /// <summary>
        /// 所属グループマスタ
        /// </summary>
        public static tm_afsyozokuDto GetDto(tm_afsyozokuDto dto, SyozokuSaveVM vm, string syozokucd)
        {
            dto.syozokucd = CStr(syozokucd);    //所属グループコード
            dto.stopflg = vm.stopflg;           //使用停止フラグ
            dto.syozokunm = vm.syozokunm;       //所属グループ名

            dto.kanrisyaflg = vm.kanrisyaflg;   //管理者フラグ
            dto.pnoeditflg = vm.pnoeditflg;     //個人番号操作権限付与フラグ
            dto.alertviewflg = vm.alertviewflg; //警告参照区分

            return dto;
        }

        /// <summary>
        /// 部署（支所）別更新権限テーブルリスト
        /// </summary>
        public static List<tt_afauthsisyoDto> GetDtl(List<CmSisyoVM> list, Enumロール区分 rolekbn, string roleid)
        {
            //支所コード一覧を取得
            var lst = list.Select(e => e.sisyocd).ToList();
            return lst.Select(a => GetDto(a, rolekbn, roleid)).ToList();
        }

        /// <summary>
        /// 部署（支所）別更新権限テーブルリスト(継承用)
        /// </summary>
        public static List<tt_afauthsisyoDto> GetDtl(List<string> cds, List<tt_afauthsisyoDto> dtl1, List<tm_afuserDto> dtl2)
        {
            var list = new List<tt_afauthsisyoDto>();

            //該当所属のユーザー(更新後)を遍歴
            foreach (var user in dtl2)
            {
                //継承可能の場合、ユーザー権限を所属権限へ変更する
                if (user.authsisyokeisyoflg)
                {
                    list.AddRange(GetDtl(cds, user.userid));
                }
                //継承不可の場合、ユーザー権限のまま
                else
                {
                    //該当ユーザーのデータを抽出
                    var dtl = dtl1.Where(e => e.roleid == user.userid).ToList();
                    list.AddRange(dtl);
                }
            }

            return list;
        }

        /// <summary>
        /// 画面権限テーブルリスト
        /// </summary>
        public static List<tt_afauthgamenDto> GetDtl(List<KinoSaveVM> authlist, Enumロール区分 rolekbn, string roleid)
        {
            return authlist.Select(a => GetDto(a, rolekbn, roleid)).ToList();
        }

        /// <summary>
        /// 画面権限テーブルリスト(継承用)
        /// </summary>
        public static List<tt_afauthgamenDto> GetDtl(List<string> useridList, List<tt_afauthgamenDto> userAuthDtl, List<tt_afauthgamenDto> syozokuAuthDtl, List<string> idList)
        {
            var list = new List<tt_afauthgamenDto>();
            //全ての機能IDを遍歴
            foreach (var id in idList)
            {
                //該当所属権限を取得
                var dto = syozokuAuthDtl.Find(e => e.kinoid == id);
                //該当ユーザー権限を取得(DB存在の場合)
                var dtl = userAuthDtl.Where(e => e.kinoid == id).ToList();

                list.AddRange(GetDtl(useridList, dto, dtl));
            }

            return list;
        }

        /// <summary>
        /// 帳票権限テーブルリスト
        /// </summary>
        public static List<tt_afauthreportDto> GetDtl(List<ReportSaveVM> eucAuthList, Enumロール区分 rolekbn, string roleid)
        {
            return eucAuthList.Select(e => GetDto(e, rolekbn, roleid)).ToList();
        }

        /// <summary>
        /// 帳票権限テーブルリスト(継承用)
        /// </summary>
        public static List<tt_afauthreportDto> GetDtl(List<string> useridList, List<tt_afauthreportDto> userAuthDtl, List<tt_afauthreportDto> syozokuAuthDtl, List<string> idList)
        {
            var list = new List<tt_afauthreportDto>();
            //全ての帳票権限グループIDを遍歴
            foreach (var id in idList)
            {
                //該当所属権限を取得
                var dto = syozokuAuthDtl.Find(e => e.repgroupid == id);
                //該当ユーザー権限を取得(DB存在の場合)
                var dtl = userAuthDtl.Where(e => e.repgroupid == id).ToList();

                list.AddRange(GetDtl(useridList, dto, dtl));
            }

            return list;
        }

        /// <summary>
        /// ユーザーマスタ(継承用)
        /// </summary>
        private static tm_afuserDto GetDto(tm_afuserDto dto, tm_afsyozokuDto syozokuDto, List<string> delList, List<string> keyList)
        {
            //該当所属から削除されたユーザーの場合、権限設定をユーザー権限へ変更し、所属をクリア
            if (delList.Contains(dto.userid))
            {
                dto.syozokucd = null;   //所属グループコード
                dto.authsetflg = true;  //権限設定フラグ
            }
            //該当所属へ追加されたユーザーと所属変更なしのユーザーの場合、継承フラグの基に関連権限項目を更新
            else if (keyList.Contains(dto.userid))
            {
                dto.syozokucd = syozokuDto.syozokucd;                                                           //所属グループコード
                dto.kanrisyaflg = GetFlg(dto.kanrisyakeisyoflg, syozokuDto.kanrisyaflg, dto.kanrisyaflg);       //管理者フラグ
                dto.pnoeditflg = GetFlg(dto.pnoeditkeisyoflg, syozokuDto.pnoeditflg, dto.pnoeditflg);           //個人番号操作権限付与フラグ
                dto.alertviewflg = GetFlg(dto.alertviewkeisyoflg, syozokuDto.alertviewflg, dto.alertviewflg);   //警告参照フラグ
            }
            return dto;
        }

        /// <summary>
        /// 権限フラグを取得(継承フラグで判断)
        /// </summary>
        private static bool GetFlg(bool keisyoflg, bool newflg, bool oldflg)
        {
            if (keisyoflg) return newflg;
            return oldflg;
        }

        /// <summary>
        /// ユーザー所属部署（支所）テーブル
        /// </summary>
        private static tt_afuser_sisyoDto GetDto(string userid, string sisyocd)
        {
            var dto = new tt_afuser_sisyoDto();
            dto.userid = userid;        //ユーザーID
            dto.sisyocd = sisyocd;      //部署（支所）コード
            return dto;
        }

        /// <summary>
        /// 部署（支所）別更新権限テーブル
        /// </summary>
        private static tt_afauthsisyoDto GetDto(string sisyocd, Enumロール区分 rolekbn, string roleid)
        {
            var dto = new tt_afauthsisyoDto();
            dto.rolekbn = rolekbn;      //ロール区分
            dto.roleid = roleid;        //ロールID
            dto.sisyocd = sisyocd;      //部署（支所）コード
            return dto;
        }

        /// <summary>
        /// 部署（支所）別更新権限テーブル(継承用)
        /// </summary>
        private static List<tt_afauthsisyoDto> GetDtl(List<string> cds, string userid)
        {
            var list = new List<tt_afauthsisyoDto>();
            //所属権限の更新可能支所一覧を遍歴
            foreach (var cd in cds)
            {
                var dto = new tt_afauthsisyoDto();
                dto.rolekbn = Enumロール区分.ユーザー;  //ロール区分
                dto.roleid = userid;                    //ロールID
                dto.sisyocd = cd;                       //部署（支所）コード
                list.Add(dto);
            }

            return list;
        }

        /// <summary>
        /// 画面権限テーブル
        /// </summary>
        private static tt_afauthgamenDto GetDto(KinoSaveVM vm, Enumロール区分 rolekbn, string roleid)
        {
            var dto = new tt_afauthgamenDto();
            dto.rolekbn = rolekbn;                          //ロール区分
            dto.roleid = roleid;                            //ロールID
            dto.kinoid = vm.kinoid;                         //機能ID
            dto.programkbn = vm.programkbn;                 //プログラム区分
            dto.addflg = vm.addflg ?? false;                //追加権限フラグ
            dto.updateflg = vm.updflg ?? false;             //修正権限フラグ
            dto.deleteflg = vm.delflg ?? false;             //削除権限フラグ
            dto.personalnoflg = vm.personalnoflg ?? false;  //個人番号利用権限フラグ
            //所属の場合、継承フラグ設定しない
            if (rolekbn == Enumロール区分.所属)
            {
                dto.keisyoflg = null;                       //継承可能フラグ
            }
            else
            {
                dto.keisyoflg = vm.keisyoflg;               //継承可能フラグ
            }
            return dto;
        }

        /// <summary>
        /// 画面権限テーブルリスト(継承用)
        /// </summary>
        private static List<tt_afauthgamenDto> GetDtl(List<string> useridList, tt_afauthgamenDto? dto, List<tt_afauthgamenDto> dtl)
        {
            var list = new List<tt_afauthgamenDto>();

            //追加更新の場合
            if (dto != null)
            {
                //ユーザーID一覧を遍歴
                foreach (var id in useridList)
                {
                    //ユーザー権限データを取得
                    var userAuthDto = dtl.Find(e => e.roleid == id);
                    list.Add(GetDto(dto, userAuthDto, id));
                }
            }
            //削除の場合
            else
            {
                //継承不可のユーザー権限のみ残す
                var userAuthDtl = dtl.Where(e => CBool(e.keisyoflg) == false).ToList();
                list.AddRange(userAuthDtl);
            }

            return list;
        }

        /// <summary>
        /// 画面権限テーブル(継承用)
        /// </summary>
        private static tt_afauthgamenDto GetDto(tt_afauthgamenDto syozokuDto, tt_afauthgamenDto? userDto, string userid)
        {
            var dto = new tt_afauthgamenDto();
            //基本情報項目
            dto.rolekbn = Enumロール区分.ユーザー;              //ロール区分
            dto.roleid = userid;                                //ロールID
            dto.kinoid = syozokuDto.kinoid;                     //機能ID
            dto.programkbn = syozokuDto.programkbn;             //プログラム区分
            //権限関連項目
            dto.addflg = syozokuDto.addflg;                     //追加フラグ
            dto.updateflg = syozokuDto.updateflg;               //修正フラグ
            dto.deleteflg = syozokuDto.deleteflg;               //削除フラグ
            dto.personalnoflg = syozokuDto.personalnoflg;       //個人番号利用フラグ
            //権限設定が所属権限、かつ、新規の場合
            dto.keisyoflg = true;                               //継承フラグ

            //ユーザー権限データが存在する場合
            if (userDto != null)
            {
                dto.keisyoflg = userDto.keisyoflg;              //継承フラグ
                //継承不可の場合、ユーザー権限のまま
                if (!CBool(dto.keisyoflg))
                {
                    dto.addflg = userDto.addflg;                //追加フラグ
                    dto.updateflg = userDto.updateflg;          //修正フラグ
                    dto.deleteflg = userDto.deleteflg;          //削除フラグ
                    dto.personalnoflg = userDto.personalnoflg;  //個人番号利用フラグ
                }
            }

            return dto;
        }

        /// <summary>
        /// 帳票権限テーブル
        /// </summary>
        private static tt_afauthreportDto GetDto(ReportSaveVM vm, Enumロール区分 rolekbn, string roleid)
        {
            var dto = new tt_afauthreportDto();
            dto.rolekbn = rolekbn;                          //ロール区分
            dto.roleid = roleid;                            //ロールID
            dto.repgroupid = vm.repgroupid;                 //グループID
            //TODO
            //dto.tutisyooutflg = vm.tutisyooutflg ?? false;  //通知書出力フラグ
            dto.pdfoutflg = vm.pdfoutflg ?? false;          //PDF出力フラグ
            dto.exceloutflg = vm.exceloutflg ?? false;      //EXCEL出力フラグ
            dto.othersflg = vm.othersflg ?? false;          //その他出力フラグ
            //TODO
            //dto.personalnoflg = vm.personalnoflg ?? false;  //個人番号利用フラグ
            //所属の場合、継承フラグ設定しない
            if (rolekbn == Enumロール区分.所属)
            {
                dto.keisyoflg = null;                       //継承可能フラグ
            }
            else
            {
                dto.keisyoflg = vm.keisyoflg;               //継承可能フラグ
            }
            return dto;
        }

        /// <summary>
        /// 帳票権限テーブルリスト(継承用)
        /// </summary>
        private static List<tt_afauthreportDto> GetDtl(List<string> useridList, tt_afauthreportDto? dto, List<tt_afauthreportDto> dtl)
        {
            var list = new List<tt_afauthreportDto>();

            //追加更新の場合
            if (dto != null)
            {
                //ユーザーID一覧を遍歴
                foreach (var id in useridList)
                {
                    //ユーザー権限データを取得
                    var userAuthDto = dtl.Find(e => e.roleid == id);
                    list.Add(GetDto(dto, userAuthDto, id));
                }
            }
            //削除の場合
            else
            {
                //継承不可のユーザー権限のみ残す
                var userAuthDtl = dtl.Where(e => CBool(e.keisyoflg) == false).ToList();
                list.AddRange(userAuthDtl);
            }

            return list;
        }

        /// <summary>
        /// 帳票権限テーブル(継承用)
        /// </summary>
        private static tt_afauthreportDto GetDto(tt_afauthreportDto syozokuDto, tt_afauthreportDto? userDto, string userid)
        {
            var dto = new tt_afauthreportDto();
            //基本情報項目
            dto.rolekbn = Enumロール区分.ユーザー;              //ロール区分
            dto.roleid = userid;                                //ロールID
            dto.repgroupid = syozokuDto.repgroupid;             //グループID
            //権限関連項目
            //TODO
            //dto.tutisyooutflg = syozokuDto.tutisyooutflg;       //通知書出力フラグ
            dto.pdfoutflg = syozokuDto.pdfoutflg;               //PDF出力フラグ
            dto.exceloutflg = syozokuDto.exceloutflg;           //EXCEL出力フラグ
            dto.othersflg = syozokuDto.othersflg;               //その他出力フラグ
            //TODO
            //dto.personalnoflg = syozokuDto.personalnoflg;       //個人番号利用フラグ
            //権限設定が所属権限、かつ、新規の場合
            dto.keisyoflg = true;                               //継承フラグ

            //ユーザー権限データが存在する場合
            if (userDto != null)
            {
                dto.keisyoflg = userDto.keisyoflg;              //継承フラグ
                if (!CBool(dto.keisyoflg))
                {
                    //TODO
                    //dto.tutisyooutflg = userDto.tutisyooutflg;  //通知書出力フラグ
                    dto.pdfoutflg = userDto.pdfoutflg;          //PDF出力フラグ
                    dto.exceloutflg = userDto.exceloutflg;      //EXCEL出力フラグ
                    dto.othersflg = userDto.othersflg;          //その他出力フラグ
                    //TODO
                    //dto.personalnoflg = userDto.personalnoflg;  //個人番号利用フラグ
                }
            }

            return dto;
        }
    }
}