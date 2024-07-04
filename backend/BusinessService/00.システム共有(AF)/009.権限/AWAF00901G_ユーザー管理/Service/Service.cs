// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ユーザー管理
// 　　　　　　サービス処理
// 作成日　　: 2023.07.04
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00901G
{
    [DisplayName("ユーザー管理")]
    public class Service : CmServiceBase
    {
        //ユーザー検索
        private const string USER_PROC_NAME = "sp_awaf00901g_01";

        //所属グループ検索
        private const string SYOZOKU_PROC_NAME = "sp_awaf00901g_02";

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //ユーザーマスタ
                var dtl = db.tm_afuser.SELECT.ORDER.By(nameof(tm_afuserDto.userid)).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(ユーザー)
                res.selectorlist1 = dtl.Select(u => new DaSelectorKeyModel(u.userid, u.usernm, u.syozokucd)).ToList();
                //ドロップダウンリスト(所属グループ)
                res.selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.所属グループマスタ, true).OrderBy(e=>e.value).ToList();

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = Converter.GetParameters(req);

                //ユーザータブの場合
                var proc = USER_PROC_NAME;
                //所属タブの場合
                if (req.rolekbn == Enumロール区分.所属)
                {
                    proc = SYOZOKU_PROC_NAME;
                }
                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, proc, parameters, req.pagenum, req.pagesize, req.orderby);

                //コントロールマスタから情報をまとめて取得
                var ctrInfo = DaControlService.GetList(db, EnumCtrlKbn.パスワード);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面項目設定
                if (req.rolekbn == Enumロール区分.ユーザー)
                {
                    //エラー回数上限
                    var maxErrs = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._08)!.IntValue1;
                    //パスワード有効期限チェック設定フラグ
                    var pwdCheckFlg = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._10)!.BoolValue1;
                    //パスワード有効日数(有効期限チェック=true)
                    var pwdEnableDays = pwdCheckFlg ? ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._01)!.IntValue1 : 0;

                    //ユーザー情報一覧
                    res.kekkalist1 = Wraper.GetVMList(pageList.dataTable.Rows, maxErrs, pwdCheckFlg, pwdEnableDays);
                }
                else
                {
                    //所属情報一覧
                    res.kekkalist2 = Wraper.GetVMList(pageList.dataTable.Rows);
                }

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(詳細画面)")]
        public InitDetailResponse InitDetail(InitDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //権限データ
                var gamenDtl = new List<tt_afauthgamenDto>();   //画面権限テーブル
                var reportDtl = new List<tt_afauthreportDto>(); //帳票権限テーブル
                //変更の場合のみDBから取得
                if (req.editkbn == Enum編集区分.変更)
                {
                    //画面権限テーブル
                    gamenDtl = db.tt_afauthgamen.SELECT.WHERE.ByKey(EnumToStr(req.rolekbn), req.roleid).GetDtoList();
                    //帳票権限テーブル
                    reportDtl = db.tt_afauthreport.SELECT.WHERE.ByKey(EnumToStr(req.rolekbn), req.roleid).GetDtoList();
                }

                //基本情報(ユーザー)
                var userDto = new tm_afuserDto();                   //ユーザーマスタ
                var userSisyoDtl = new List<tt_afuser_sisyoDto>();  //ユーザー所属部署（支所）テーブル
                //基本情報(所属)
                var syozokuDto = new tm_afsyozokuDto();             //所属グループマスタ
                var allSyozokus = new List<tm_afsyozokuDto>();      //所属グループマスタ
                var allUsers = new List<tm_afuserDto>();            //ユーザーマスタ

                switch (req.rolekbn)
                {
                    //ユーザー情報の場合
                    case Enumロール区分.ユーザー:
                        //ユーザーマスタ
                        userDto = db.tm_afuser.GetDtoByKey(req.roleid);
                        //ユーザー所属部署（支所）テーブル：登録支所一覧を取得
                        userSisyoDtl = db.tt_afuser_sisyo.SELECT.WHERE.ByKey(req.roleid).ORDER.By(nameof(tt_afuser_sisyoDto.sisyocd)).GetDtoList();
                        break;

                    //所属グループ情報の場合
                    case Enumロール区分.所属:
                        //所属グループマスタ
                        syozokuDto = db.tm_afsyozoku.GetDtoByKey(req.roleid);
                        //全ユーザー一覧を取得
                        allUsers = db.tm_afuser.SELECT.ORDER.By(nameof(tm_afuserDto.userid)).GetDtoList();
                        //全所属一覧を取得
                        allSyozokus = db.tm_afsyozoku.SELECT.GetDtoList();

                        break;

                    default:
                        throw new Exception("Enumロール区分 error");
                }

                //部署（支所）別更新権限テーブル：更新可能支所一覧を取得
                var authSisyoDtl = db.tt_afauthsisyo.SELECT.WHERE.ByKey(EnumToStr(req.rolekbn), req.roleid).ORDER.By(nameof(tt_afauthsisyoDto.sisyocd)).GetDtoList();

                //支所一覧を取得(全て)
                var sisyoDtl = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.部署_支所);

                //画面リスト：データ処理用
                var menuDtl = db.tm_afmenu.SELECT.ORDER.By(nameof(tm_afmenuDto.oyamenuid), nameof(tm_afmenuDto.orderseq)).GetDtoList();
                //共通バーリスト：データ処理用
                var cmBarDtl = DaNameService.GetNameList(db, EnumNmKbn.共通バー番号_共通機能);
                //帳票グループリスト：データ処理用
                var eucDtl = db.tm_eurptgroup.SELECT.GetDtoList();

                //コントロールマスタから情報をまとめて取得：ユーザー状態取得用
                var ctrInfo = DaControlService.GetList(db, EnumCtrlKbn.パスワード);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                switch (req.rolekbn)
                {
                    //ユーザー情報の場合
                    case Enumロール区分.ユーザー:
                        //ユーザー情報(基本情報)
                        res.maininfo1 = Wraper.GetVM(db, req.editkbn, userDto, req.roleid, sisyoDtl, authSisyoDtl, userSisyoDtl);

                        //ユーザー権限情報を取得
                        res.kekkalist4 = Wraper.GetVMList(menuDtl, gamenDtl);   //画面機能権限(ユーザー)
                        res.kekkalist5 = Wraper.GetVMList(cmBarDtl, gamenDtl);  //共通機能権限(ユーザー)
                        res.kekkalist6 = Wraper.GetVMList(eucDtl, reportDtl);   //帳票権限(ユーザー)
                        //所属がある場合
                        if (!string.IsNullOrEmpty(req.syozoku))
                        {
                            //所属権限情報を取得(権限設定フラグ切り替え用)
                            var res2 = GetResponse(db, req.syozoku);
                            res.kekkalist1 = res2.kekkalist1;                     //画面機能権限(所属)
                            res.kekkalist2 = res2.kekkalist2;                     //共通機能権限(所属)
                            res.kekkalist3 = res2.kekkalist3;                     //帳票権限(所属)
                        }
                        break;

                    //所属グループ情報の場合
                    case Enumロール区分.所属:
                        //ユーザー一覧の状態取得用
                        var maxErrs = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._08)!.IntValue1;                           //エラー回数上限
                        var pwdCheckFlg = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._10)!.BoolValue1;                      //パスワード有効期限チェック設定フラグ
                        var pwdEnableDays = pwdCheckFlg ? ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._01)!.IntValue1 : 0;   //パスワード有効日数(有効期限チェック=true)

                        //所属グループ情報(基本情報)
                        res.maininfo2 = Wraper.GetVM(req.editkbn, syozokuDto, req.roleid, sisyoDtl, authSisyoDtl, allUsers, allSyozokus, maxErrs, pwdCheckFlg, pwdEnableDays);
                        res.kekkalist1 = Wraper.GetVMList(menuDtl, gamenDtl);     //画面機能権限(所属)
                        res.kekkalist2 = Wraper.GetVMList(cmBarDtl, gamenDtl);    //共通機能権限(所属)
                        res.kekkalist3 = Wraper.GetVMList(eucDtl, reportDtl);     //帳票権限(所属)
                        break;

                    default:
                        throw new Exception("Enumロール区分 error");
                }

                //支所一覧取得：ダイアログボックス用
                res.sisyolist = Wraper.GetVMList(sisyoDtl);

                //個人番号関連修正権限取得(ログインユーザー)
                res.pnoeditflg = CmLogicUtil.GetPnoeditflg(db, req.token, req.userid, req.regsisyo);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(詳細画面)")]
        public SearchDetailResponse SearchDetail(SearchDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = GetResponse(db, req.syozoku);

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 所属関連権限情報を取得：画面表示用(継承仕様)
        /// </summary>
        private SearchDetailResponse GetResponse(DaDbContext db, string syozoku)
        {
            var res = new SearchDetailResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //所属グループID
            var syozokucd = DaSelectorService.GetCd(syozoku);

            //権限データ
            var gamenDtl = db.tt_afauthgamen.SELECT.WHERE.ByKey(EnumToStr(Enumロール区分.所属), syozokucd).GetDtoList();   //画面権限テーブル
            var reportDtl = db.tt_afauthreport.SELECT.WHERE.ByKey(EnumToStr(Enumロール区分.所属), syozokucd).GetDtoList(); //帳票権限テーブル
            //画面リスト：データ処理用
            var menuDtl = db.tm_afmenu.SELECT.ORDER.By(nameof(tm_afmenuDto.oyamenuid), nameof(tm_afmenuDto.orderseq)).GetDtoList();
            //共通バーリスト：データ処理用
            var cmBarDtl = DaNameService.GetNameList(db, EnumNmKbn.共通バー番号_共通機能);
            //帳票グループリスト：データ処理用
            var eucDtl = db.tm_eurptgroup.SELECT.GetDtoList();

            //所属グループマスタ
            var syozokuDto = db.tm_afsyozoku.GetDtoByKey(syozokucd);
            //支所一覧を取得(全て)：名称取得用
            var sisyoDtl = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.部署_支所);
            //部署（支所）別更新権限テーブル
            var authSisyoDtl = db.tt_afauthsisyo.SELECT.WHERE.ByKey(EnumToStr(Enumロール区分.所属), syozokucd).ORDER.By(nameof(tt_afauthsisyoDto.sisyocd)).GetDtoList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            res.kekkalist1 = Wraper.GetVMList(menuDtl, gamenDtl);   //画面機能権限(所属)
            res.kekkalist2 = Wraper.GetVMList(cmBarDtl, gamenDtl);  //共通機能権限(所属)
            res.kekkalist3 = Wraper.GetVMList(eucDtl, reportDtl);   //帳票権限(所属)
            //継承関連権限項目
            res.authvm = Wraper.GetVM(syozokuDto, sisyoDtl, authSisyoDtl);

            //正常返し
            return res;
        }

        [DisplayName("保存処理")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理(事前)
                //-------------------------------------------------------------
                //業務チェック処理
                if (req.checkflg)
                {
                    if (!Check2(db, req))
                    {
                        switch (req.rolekbn)
                        {
                            case Enumロール区分.ユーザー:
                                res.SetServiceAlert(EnumMessage.K000001, "選択された所属は既に停止されております。", "改めて所属グループ");
                                break;

                            case Enumロール区分.所属:
                                res.SetServiceAlert(EnumMessage.K000001, "所属配下で正常またはロック状態のユーザーがあります。", "改めて所属ユーザー一覧");
                                break;

                            default:
                                throw new Exception("Enumロール区分 error");
                        }
                        //異常返す
                        return res;
                    }

                    //正常返し
                    return res;
                }

                //マスタ存在チェック：新規ID存在する場合、エラーメッセージを返す
                switch (req.rolekbn)
                {
                    case Enumロール区分.ユーザー:
                        var flg1 = db.tm_afuser.SELECT.WHERE.ByKey(req.roleid).Exists();
                        if (req.editkbn == Enum編集区分.新規 && (flg1 || req.roleid == DaConst.SYSTEM))
                        {
                            res.SetServiceError(EnumMessage.E002003, "ユーザーID");
                            //異常返す
                            return res;
                        }
                        break;

                    case Enumロール区分.所属:
                        var flg2 = db.tm_afsyozoku.SELECT.WHERE.ByKey(req.roleid).Exists();
                        if (req.editkbn == Enum編集区分.新規 && flg2)
                        {
                            res.SetServiceError(EnumMessage.E002003, "所属グループコード");
                            //異常返す
                            return res;
                        }
                        break;

                    default:
                        throw new Exception("Enumロール区分 error");
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //基本情報(ユーザー)
                var userDto = new tm_afuserDto();                   //ユーザーマスタ
                var userSisyoDtl = new List<tt_afuser_sisyoDto>();  //ユーザー所属部署（支所）テーブル
                //基本情報(所属)
                var syozokuDto = new tm_afsyozokuDto();             //所属グループマスタ

                //基本情報(共通)
                var sisyoList = new List<CmSisyoVM>();              //更新可能支所一覧
                var authGamenDtl = new List<tt_afauthgamenDto>();   //画面権限テーブル
                var authReportDtl = new List<tt_afauthreportDto>(); //帳票権限テーブル

                //その他処理用(所属の場合のみ：該当所属のユーザー情報更新用)
                var useridList = new List<string>();                //ユーザーID一覧(該当所属の全ユーザー)
                var delUserList = new List<string>();               //ユーザーID一覧(該当所属から削除されたユーザー)
                var addUserList = new List<string>();               //ユーザーID一覧(該当所属へ追加されたユーザー)
                var updUserList = new List<string>();               //ユーザーID一覧(該当所属の中で移動されてないユーザー)

                switch (req.rolekbn)
                {
                    //ユーザー情報の場合
                    case Enumロール区分.ユーザー:
                        //新規の場合
                        var dto1 = new tm_afuserDto();
                        //変更の場合
                        if (req.editkbn == Enum編集区分.変更)
                        {
                            dto1 = db.tm_afuser.GetDtoByKey(req.roleid);
                        }
                        //ユーザーマスタ
                        userDto = Converter.GetDto(dto1, req.maininfo1!, req.roleid);
                        //ユーザー所属部署（支所）テーブル
                        userSisyoDtl = Converter.GetDtl(req.maininfo1!.regsisyolist, req.roleid);

                        //更新可能支所一覧
                        sisyoList = req.maininfo1!.editsisyolist;
                        //画面権限テーブル
                        authGamenDtl = Converter.GetDtl(req.authlist1, req.rolekbn, req.roleid);
                        //帳票権限テーブル
                        authReportDtl = Converter.GetDtl(req.authlist2, req.rolekbn, req.roleid);
                        break;

                    //所属グループ情報の場合
                    case Enumロール区分.所属:
                        //新規の場合
                        var dto2 = new tm_afsyozokuDto();
                        //変更の場合
                        if (req.editkbn == Enum編集区分.変更)
                        {
                            dto2 = db.tm_afsyozoku.GetDtoByKey(req.roleid);
                        }
                        //所属グループマスタ
                        syozokuDto = Converter.GetDto(dto2, req.maininfo2!, req.roleid);

                        //更新可能支所一覧
                        sisyoList = req.maininfo2!.editsisyolist;
                        //画面権限テーブル
                        authGamenDtl = Converter.GetDtl(req.authlist1, req.rolekbn, req.roleid);
                        //帳票権限テーブル
                        authReportDtl = Converter.GetDtl(req.authlist2, req.rolekbn, req.roleid);

                        //ユーザーID一覧(該当所属の全ユーザー)
                        useridList = req.maininfo2!.userlist1.Select(e => e.userid).ToList();
                        //ユーザーID一覧(該当所属から削除されたユーザー)
                        delUserList = req.keylist3.Where(e => useridList.Contains(e) == false).ToList();
                        //ユーザーID一覧(該当所属へ追加されたユーザー)
                        addUserList = useridList.Where(e => req.keylist3.Contains(e) == false).ToList();
                        //ユーザーID一覧(該当所属の中で移動されてないユーザー)
                        updUserList = useridList.Where(e => req.keylist3.Contains(e) == true).ToList();
                        break;

                    default:
                        throw new Exception("Enumロール区分 error");
                }

                //部署（支所）別更新権限テーブル：共通
                var authSisyoDtl = Converter.GetDtl(sisyoList, req.rolekbn, req.roleid);

                //-------------------------------------------------------------
                //３.チェック処理(排他)
                //-------------------------------------------------------------
                if (req.checkflg)
                {
                    if (!Check(db, req, delUserList, addUserList, updUserList))
                    {
                        throw new AiExclusiveException();
                    }

                    //正常返し
                    return res;
                }

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                switch (req.rolekbn)
                {
                    //ユーザー情報の場合
                    case Enumロール区分.ユーザー:
                        //新規の場合
                        if (req.editkbn == Enum編集区分.新規)
                        {
                            //ユーザーマスタ
                            db.tm_afuser.INSERT.Execute(userDto);
                        }
                        //更新の場合
                        else
                        {
                            //ユーザーマスタ
                            db.tm_afuser.UpdateDto(userDto, req.maininfo1!.upddttm!.Value);
                        }

                        //ユーザー所属部署（支所）テーブル：差分更新
                        db.tt_afuser_sisyo.UPDATE.WHERE.ByKey(req.roleid).Execute(userSisyoDtl);
                        break;

                    //所属グループ情報の場合
                    case Enumロール区分.所属:
                        //新規の場合
                        if (req.editkbn == Enum編集区分.新規)
                        {
                            //所属グループマスタ
                            db.tm_afsyozoku.INSERT.Execute(syozokuDto);
                        }
                        //更新の場合
                        else
                        {
                            //所属グループマスタ
                            db.tm_afsyozoku.UpdateDto(syozokuDto, req.maininfo2!.upddttm!.Value);
                        }
                        break;

                    default:
                        throw new Exception("Enumロール区分 error");
                }

                //部署（支所）別更新権限テーブル：差分更新
                db.tt_afauthsisyo.UPDATE.WHERE.ByKey(EnumToStr(req.rolekbn), req.roleid).Execute(authSisyoDtl);
                //画面権限テーブル：差分更新
                db.tt_afauthgamen.UPDATE.WHERE.ByKey(EnumToStr(req.rolekbn), req.roleid).Execute(authGamenDtl);
                //帳票権限テーブル：差分更新
                db.tt_afauthreport.UPDATE.WHERE.ByKey(EnumToStr(req.rolekbn), req.roleid).Execute(authReportDtl);

                //-------------------------------------------------------------
                //５.その他処理
                //-------------------------------------------------------------
                //所属の場合のみ：該当所属のユーザー情報(基本情報、権限情報)を更新
                if (req.rolekbn == Enumロール区分.所属)
                {
                    //ユーザー情報更新処理
                    SetUserAuth(db, delUserList, syozokuDto, useridList, authGamenDtl, authReportDtl, req.maininfo2!.editsisyolist);
                }

                //キャシュークリア
                DaSelectorService.ClearCache();

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 該当所属のユーザー情報(権限を含む)更新
        /// </summary>
        private void SetUserAuth(DaDbContext db, List<string> delList, tm_afsyozokuDto dto,
            List<string> updKeyList, List<tt_afauthgamenDto> dtl1, List<tt_afauthreportDto> dtl2, List<CmSisyoVM> editsisyolist)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //キーリスト(ユーザーマスタ：削除と追加のユーザーに対して、所属変更　=>　対応するユーザー範囲)
            var keylist1 = delList.Concat(updKeyList).ToList();
            //キーリスト(該当所属の全てユーザー(更新後)に対して、権限変更(継承可能)　=>　対応するユーザー範囲)
            var keylist2 = updKeyList.Select(e => new object[] { EnumToStr(Enumロール区分.ユーザー), e }).ToList();

            //ユーザーマスタ
            var userDtl = db.tm_afuser.SELECT.WHERE.ByKeyList(keylist1).GetDtoList();

            //部署（支所）別更新権限テーブル
            var sisyoDtl = db.tt_afauthsisyo.SELECT.WHERE.ByKeyList(keylist2).GetDtoList();
            //ユーザー情報一覧(対応範囲内のユーザー：変更なし、追加)
            var userDtl2 = userDtl.Where(e => updKeyList.Contains(e.userid)).ToList();
            //支所コード一覧(所属権限)
            var sisyos = editsisyolist.Select(e => e.sisyocd).ToList();

            //画面権限テーブル
            var gamenDtl = db.tt_afauthgamen.SELECT.WHERE.ByKeyList(keylist2).GetDtoList();
            //機能ID一覧(画面)
            List<string> idList1 = db.tm_afmenu.SELECT.SetSelectItems(nameof(tm_afmenuDto.kinoid)).WHERE.ByFilter("1=1").GetDtoList().
                        Select(e => e.kinoid).ToList();
            //機能ID一覧(共通バー)
            List<string> idList2 = DaNameService.GetNameList(db, EnumNmKbn.共通バー番号_共通機能).
                        Select(e => e.hanyokbn1!).ToList();
            //機能ID一覧(画面・共通バー)
            List<string> gamenIDs = idList1.Concat(idList2).ToList();

            //帳票権限テーブル
            var reportDtl = db.tt_afauthreport.SELECT.WHERE.ByKeyList(keylist2).GetDtoList();
            //帳票権限グループID一覧
            var reportIDs = db.tm_eurptgroup.SELECT.GetDtoList().Select(e => e.rptgroupid).ToList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //ユーザーマスタ
            userDtl = Converter.GetDtl(userDtl, dto, delList, updKeyList);
            //部署（支所）別更新権限テーブル
            var authSisyoDtl = Converter.GetDtl(sisyos, sisyoDtl, userDtl2);
            //画面権限テーブル
            var authGamenDtl = Converter.GetDtl(updKeyList, gamenDtl, dtl1, gamenIDs);
            //帳票権限テーブル
            var authReportDtl = Converter.GetDtl(updKeyList, reportDtl, dtl2, reportIDs);

            //-------------------------------------------------------------
            //３.DB更新処理
            //-------------------------------------------------------------
            //ユーザー所属グループ差分更新
            db.tm_afuser.UPDATE.WHERE.ByKeyList(keylist1).Execute(userDtl);
            //ユーザー所属部署（支所）テーブル：差分更新
            db.tt_afauthsisyo.UPDATE.WHERE.ByKeyList(keylist2).Execute(authSisyoDtl);
            //画面権限テーブル：差分更新
            db.tt_afauthgamen.UPDATE.WHERE.ByKeyList(keylist2).Execute(authGamenDtl);
            //帳票権限テーブル：差分更新
            db.tt_afauthreport.UPDATE.WHERE.ByKeyList(keylist2).Execute(authReportDtl);
        }

        /// <summary>
        /// 排他チェック
        /// </summary>
        private bool Check(DaDbContext db, SaveRequest req, List<string> delList, List<string> addList, List<string> updList)
        {
            //ユーザー情報、かつ、権限設定が所属権限の場合、メインテーブルで自動排他
            if ((req.rolekbn == Enumロール区分.ユーザー) && (!CBool(req.maininfo1!.authsetflg)))
            {
                return true;
            }

            //上記以外の場合、DBデータと比較して、排他チェックを行う
            //DBデータ取得
            //画面権限テーブル
            var gamenDtl = db.tt_afauthgamen.SELECT.WHERE.ByKey(EnumToStr(req.rolekbn), req.roleid).GetDtoList();
            //帳票権限テーブル
            var reportDtl = db.tt_afauthreport.SELECT.WHERE.ByKey(EnumToStr(req.rolekbn), req.roleid).GetDtoList();

            //判断処理
            //画面権限テーブル
            var flg1 = req.keylist1.Count == gamenDtl.Count &&
                req.keylist1.All(x => gamenDtl.Exists(e => e.kinoid == x.kinoid && e.upddttm == x.upddttm));
            //帳票権限テーブル
            var flg2 = req.keylist2.Count == reportDtl.Count &&
                req.keylist2.All(x => reportDtl.Exists(e => e.repgroupid == x.repgroupid && e.upddttm == x.upddttm));

            //所属グループ情報の場合、該当所属のユーザー一覧の所属変換されたかどうかも確認必要
            if (req.rolekbn == Enumロール区分.所属)
            {
                //ユーザーID一覧(削除されたユーザー、所属変更していないユーザー)
                var keylist = delList.Concat(updList).ToList();
                //ユーザー情報一覧(削除されたユーザー)
                var dtl1 = db.tm_afuser.SELECT.WHERE.ByKeyList(keylist).GetDtoList();
                //該当ユーザーの所属グループIDが変更されたかどうかを確認
                var ct1 = dtl1.Where(e => e.syozokucd != req.roleid).Count();

                //ユーザー情報一覧(追加されたユーザー)
                var dtl2 = db.tm_afuser.SELECT.WHERE.ByKeyList(addList).GetDtoList();
                //該当ユーザーの所属グループIDが空白かどうかを確認
                var ct2 = dtl2.Where(e => !string.IsNullOrEmpty(e.syozokucd)).Count();

                //問題があれば、排他エラー
                if (ct1 > 0 || ct2 > 0)
                {
                    return false;
                }
            }

            return flg1 && flg2;
        }
        /// <summary>
        /// 停止フラグチェック
        /// </summary>
        private bool Check2(DaDbContext db, SaveRequest req)
        {
            switch (req.rolekbn)
            {
                //ユーザー情報の場合
                case Enumロール区分.ユーザー:
                    //所属
                    var syozoku = req.maininfo1!.syozoku;
                    //所属設定する場合
                    if (!string.IsNullOrEmpty(syozoku))
                    {
                        //所属グループID
                        var syozokucd = DaSelectorService.GetCd(syozoku);
                        //所属グループマスタ
                        var syozokuDto = db.tm_afsyozoku.GetDtoByKey(syozokucd);
                        //使用停止ではないユーザーが使用停止の所属を設定された場合
                        if (CBool(syozokuDto.stopflg) == true && req.maininfo1!.stopflg == false)
                        {
                            return false;
                        }
                    }
                    break;

                //所属グループ情報の場合
                case Enumロール区分.所属:

                    var ketlist = req.maininfo2!.userlist1.Select(e => e.userid).ToList();
                    var dtl = db.tm_afuser.SELECT.WHERE.ByKeyList(ketlist).GetDtoList();

                    foreach (var dto in dtl)
                    {
                        //コントロールマスタから情報をまとめて取得：ユーザー状態取得用
                        var ctrInfo = DaControlService.GetList(db, EnumCtrlKbn.パスワード);
                        var maxnum = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._08)!.IntValue1;            //エラー回数上限
                        var flg = ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._10)!.BoolValue1;              //パスワード有効期限チェック設定フラグ
                        var days = flg ? ctrInfo.Find(e => e.ctrlcd == コントロールマスタ.システム.パスワード._01)!.IntValue1 : 0;    //パスワード有効日数(有効期限チェック=true)

                        var yukoymdf = CDate(dto.yukoymdf);             //有効年月日（開始）
                        var yukoymdt = CDate(dto.yukoymdt);             //有効年月日（終了）
                        var stopflg = dto.stopflg;                      //使用停止フラグ
                        var errorkaisu = dto.errorkaisu;                //ログインエラー回数
                        var pwordhenkoymd = CDate(dto.pwordhenkoymd);   //パスワード変更日
                        //状態取得
                        var status = Wraper.GetStatus(stopflg, errorkaisu, yukoymdf, yukoymdt, pwordhenkoymd, maxnum, flg, days);
                        //該当所属が使用停止に設定する時、配下ユーザーの中で使用可能なユーザーまだ存在する場合
                        if (req.maininfo2!.stopflg == true && (status == Enumユーザー状態.正常 || status == Enumユーザー状態.ロック))
                        {
                            return false;
                        }
                    }
                    break;

                default:
                    throw new Exception("Enumロール区分 error");
            }
            return true;
        }
    }
}