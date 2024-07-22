// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票出力(一覧画面、出力画面)
//             サービス処理
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00301G
{
    [DisplayName("帳票出力(一覧画面、出力画面)")]
    public class Service : CmServiceBase
    {
        #region 一覧画面

        //検索処理
        private const string PROC_NAME = "sp_aweu00301g_01";

        [DisplayName("初期化処理(一覧画面)")]
        public InitResponse Init(DaRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //帳票グループマスタ
                var rptgroupDtl = db.tm_eurptgroup.SELECT.SetSelectItems(nameof(tm_eurptgroupDto.rptgroupid), nameof(tm_eurptgroupDto.rptgroupnm), nameof(tm_eurptgroupDto.gyomukbn))
                    .ORDER.By(nameof(tm_eurptgroupDto.rptgroupid))
                    .GetDtoList();
                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(業務)
                res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.EUC業務区分, Enum名称区分.名称);
                //ドロップダウンリスト(帳票グループ)
                res.selectorlist2 = rptgroupDtl.Select(x => new DaSelectorKeyModel(x.rptgroupid, x.rptgroupnm, x.gyomukbn)).ToList(); 

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(一覧画面)")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータを取得
                var parameters = Converter.GetParameters(req);
                //検索データを取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //設定総ページ数、総件数
                res.SetPageInfo(pageList.TotalCount, req.pagesize);
                //帳票情報一覧を取得
                res.kekkalist = Wraper.GetReportVMList(pageList.dataTable.Rows);

                //正常返し
                return res;
            });
        }

        #endregion

        #region 出力画面

        private const string PROC_NAME_DETAIL = "sp_aweu00301g_02";
        private const string TIKU_HANYO_KBN2 = "1";
        private const string KINO_ID = "AWEU00301G";

        [DisplayName("初期化処理(出力画面)")]
        public InitDetailResponse InitDetail(InitDetailRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new InitDetailResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //詳細条件設定テーブル
                List<tt_affilterDto>? detailJyokenDtl = null;

                //EUC帳票マスタ
                var rptDto = db.tm_eurpt.GetDtoByKey(req.rptid);

                //EUC帳票検索マスタ
                var rptkensakuDtl = db.tm_eurptkensaku.SELECT.WHERE.ByItem(nameof(tm_eurptkensakuDto.rptid), req.rptid).ORDER.By(nameof(tm_eurptkensakuDto.orderseq)).GetDtoList();

                //宛名フラグ
                if (rptDto.atenaflg)
                {
                    //詳細条件(共通)
                    const string filter =
                        $"{nameof(tt_affilterDto.kinoid)} = @{nameof(tt_affilterDto.kinoid)} " +
                        $"AND {nameof(tt_affilterDto.jyokbn)} = @{nameof(tt_affilterDto.jyokbn)} " +
                        $"AND {nameof(tt_affilterDto.hyojiflg)} = @{nameof(tt_affilterDto.hyojiflg)}";

                    //詳細条件設定テーブル
                    detailJyokenDtl = db.tt_affilter.SELECT.WHERE.ByFilter(filter, KINO_ID, EnumToStr(Enum詳細検索条件区分.共通), true).ORDER.By(nameof(tt_affilterDto.sort)).GetDtoList();
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //帳票説明
                res.rptbiko = rptDto.rptbiko;
                //宛名フラグ
                res.atenaflg = rptDto.atenaflg;
                //様式紐付け名
                res.yosikihimonm = CStr(rptDto.yosikihimonm);
                //検索条件
                if (rptkensakuDtl.Count > 0)
                {
                    res.kensakujyokenlist1 = Wraper.GetKensakuJyokenVMList(db, rptkensakuDtl, out var kensakujyokenlist2);
                    //検索条件以外
                    res.kensakujyokenlist2 = kensakujyokenlist2;
                }

                //抽出パネル表示フラグ=false かつ　様式紐付けなし場合
                if (!rptDto.tyusyutupanelflg && string.IsNullOrEmpty(rptDto.yosikihimonm))
                {
                    //ドロップダウンリスト(出力様式)
                    res.selectorlist = GetYosikiInfoList(db, new YosikiInfoRequest() { rptid = req.rptid }, rptDto);
                }
                else
                {
                    res.selectorlist = new List<YosikiInfo>();
                }
                
                //詳細条件リスト
                res.detailjyokenlist = Wraper.GetDetailJyokenInitVMList(db, detailJyokenDtl);
                //抽出パネル表示フラグ
                res.tyusyutupanelflg = rptDto.tyusyutupanelflg;

                if(res.tyusyutupanelflg)
                {
                    //抽出情報マスタ
                    var tyusyutuDtl = db.tm_kktyusyutu.SELECT.WHERE.ByItem(nameof(tm_kktyusyutuDto.rptid), req.rptid).ORDER.By(nameof(tm_kktyusyutuDto.orderseq)).GetDtoList();
                    //ドロップダウンリスト(抽出対象:抽出対象コード,抽出対象名,通知サイクル,抽出データ詳細区分)
                    res.tyusyututaisyolist = tyusyutuDtl.Select(e => new MyDaSelectorModel(e.tyusyututaisyocd, e.tyusyututaisyonm, e.tuticycle, e.tyusyutudatasyosaikbn)).ToList();

                    //抽出対象コードリスト
                    var cdlist = tyusyutuDtl.Select(e => e.tyusyututaisyocd).ToList();
                    //対象者抽出情報テーブル
                    var taisyosyatyusyutuDtl = db.tt_kktaisyosya_tyusyutu.SELECT.WHERE.ByItemList(nameof(tt_kktaisyosya_tyusyutuDto.tyusyututaisyocd), cdlist).ORDER.By(nameof(tt_kktaisyosya_tyusyutuDto.tyusyutuseq)).GetDtoList();
                    //ドロップダウンリスト(抽出内容:抽出シーケンス,抽出内容,抽出対象コード_年度)
                    res.tyusyutunaiyolist = taisyosyatyusyutuDtl.Where(e=> e.zentaikobetukbn != 名称マスタ.システム.全体個別区分._2).Select(e => new DaSelectorKeyModel(CStr(e.tyusyutuseq), e.tyusyutunaiyo, $"{e.tyusyututaisyocd}_{e.nendo}")).ToList();

                    //紐づけラインナップのメイン・サブを管理する汎用マスタ
                    var hanyoDto = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.帳票出力区分紐づけ, req.rptid);
                    if (hanyoDto != null)
                    {
                        //紐づけラインナップ
                        var hanyoDtl = DaHanyoService.GetHanyoDtl(db, hanyoDto.hanyomaincd, CInt(hanyoDto.hanyokbn1));
                        //ドロップダウンリスト(帳票出力区分:区分コード,区分名称,様式種別,抽出データ詳細区分))
                        res.tyusyutukbnlist = hanyoDtl.Select(e => new MyDaSelectorModel(e.hanyocd, e.nm, e.hanyokbn2, e.hanyokbn1)).ToList();
                    }
                    else
                    {
                        res.tyusyutukbnlist = new List<MyDaSelectorModel>();
                    }
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("様式情報の取得")]
        public YosikiInfoResponse GetYosikiInfo(YosikiInfoRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new YosikiInfoResponse();

                //EUC帳票マスタ
                var rpt = db.tm_eurpt.SELECT.WHERE.ByKey(req.rptid).GetDto();

                //ドロップダウンリスト(出力様式)
                res.selectorlist = GetYosikiInfoList(db, req, rpt);

                //正常返し
                return res;
            });
        }

        [DisplayName("抽出内容が変更時処理")]
        public ChangeTyusyutunaiyoResponse ChangeTyusyutunaiyo(ChangeTyusyutunaiyoRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new ChangeTyusyutunaiyoResponse();

                //対象者抽出情報テーブル
                var dto = db.tt_kktaisyosya_tyusyutu.SELECT.WHERE.ByKey(CInt(req.tyusyutunaiyo)).GetDto();
                if (dto != null)
                {
                    //抽出人数
                    res.atenanocnt = db.tt_kktaisyosya_tyusyutu_sub.SELECT.WHERE.ByKey(dto.tyusyutuseq).GetCount() + "人";
                    //登録日時
                    res.regdttm = DaFormatUtil.FormatWaKjDttm(dto.regdttm);
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("参照元項目入力後参照先項目の選択リストを取得する処理")]
        public GetTargetItemValueResponse GetTargetItemValue(GetTargetItemValueRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new GetTargetItemValueResponse();
                res.targetItemValueList = new List<TargetItemValueVM>();

                //EUC帳票検索マスタから、該当取得先項目データを取得する
                var filter = $"{nameof(tm_eurptkensakuDto.rptid)} = '{req.rptid}' AND {nameof(tm_eurptkensakuDto.jyokenid)} = ANY(ARRAY[{req.targetitemseq}])";
                var kensakuDtl = db.tm_eurptkensaku.SELECT.WHERE.ByFilter(filter).GetDtoList();
                foreach (var dto in kensakuDtl)
                {
                    if (string.IsNullOrEmpty(req.val))
                    {
                        //取得先項目ID,取得先項目の選択リスト
                        res.targetItemValueList.Add(new TargetItemValueVM { jyokenid = CInt(dto.jyokenid), selectorlist = new List<DaSelectorModel>() });
                    }
                    else
                    {
                        //参照元SQL
                        var sql = dto.sansyomotosql;
                        if (!string.IsNullOrEmpty(sql))
                        {
                            sql = sql.Replace($"[{req.jyokenlabel}]", req.val);

                            //取得先項目の選択リストを取得
                            List<DaSelectorModel> selectorlist = db.Session.Query<DaSelectorModel>(sql);
                            //取得先項目ID,取得先項目の選択リスト
                            res.targetItemValueList.Add(new TargetItemValueVM { jyokenid = CInt(dto.jyokenid), selectorlist = selectorlist });
                        }
                    }    
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("検索押下処理(出力画面)")]
        public SearchDetailResponse SearchDetail(DetailSearchRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchDetailResponse();
                string? publickey = null;
                string? privatekey = null;

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //EUC帳票マスタ
                var rptDto = db.tm_eurpt.GetDtoByKey(req.rptid);
                //地区区分
                var tikukbnStr = DaNameService.GetNameList(db, EnumNmKbn.地区区分).FirstOrDefault(x => x.hanyokbn2 == TIKU_HANYO_KBN2)?.nmcd;
                //権限区分
                var authVm = CommonUtil.GetRptAuthVM(db, rptDto.rptgroupid, req.token, req.userid, req.regsisyo);
                if (authVm.personalnoflg)
                {
                    //PEM形式でRSAキーペアを生成
                    DaEncryptUtil.GeneratePemRsaKeyPair(out publickey, out privatekey);
                }

                //ワークシーケンス
                var workseq = req.workseq;
                if(req.workseq<=0)
                {
                    //宛名ワークテーブルから最大ワークシーケンスを取得
                    workseq = db.wk_euatena.SELECT.WHERE.ByItem(nameof(wk_euatenaDto.token), req.token).GetMax<long>(nameof(wk_euatenaDto.workseq));
                }
               
                //パラメータを取得
                var parameters = Converter.GetParameters(workseq, rptDto.rptgroupid, tikukbnStr!);
                //宛名情報を取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME_DETAIL, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //設定総ページ数、総件数
                res.SetPageInfo(pageList.TotalCount, req.pagesize);
                //秘密キー(復号化用)
                res.rsaprivatekey = privatekey;
                //宛名情報リスト
                res.kekkalist = Wraper.GetAtenaVMList(db, pageList.dataTable.Rows, authVm, publickey);
                //正常返し
                return res;
            });
        }

        #endregion

        /// <summary>
        /// ドロップダウンリスト(出力様式)を取得
        /// </summary>
        public List<YosikiInfo> GetYosikiInfoList(DaDbContext db, YosikiInfoRequest req, tm_eurptDto rptDto)
        {
            //EUC様式マスタ
            var yosikiDtl = GetYosikiDtl(db, req, rptDto);
            //EUC様式詳細マスタ
            var rptDetails = db.tm_euyosikisyosai.SELECT.WHERE.ByKey(req.rptid).GetDtoList().Where(e => e.yosikieda == 0).ToList();
            //帳票権限テーブル取得
            var authVm = CommonUtil.GetRptAuthVM(db, rptDto.rptgroupid, req.token, req.userid, req.regsisyo);

            //ドロップダウンリスト(出力様式)
            return Wraper.GetYosikiInfoList(db, req, rptDto, yosikiDtl, rptDetails, authVm);
        }

        /// <summary>
        /// EUC様式マスタデータを取得する
        /// </summary>
        private List<tm_euyosikiDto> GetYosikiDtl(DaDbContext db, YosikiInfoRequest req, tm_eurptDto rptDto)
        {
            //EUC様式マスタデータリスト
            var yosikiDtl = new List<tm_euyosikiDto>();

            //抽出パネル表示の場合
            if (rptDto.tyusyutupanelflg)
            {
                //EUC様式マスタデータリスト
                yosikiDtl = db.tm_euyosiki.SELECT.WHERE.ByKey(req.rptid).GetDtoList();

                //紐づけラインナップのメイン・サブを管理する汎用マスタ
                var hanyoDto = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.帳票出力区分紐づけ, req.rptid);
                if (hanyoDto == null)
                {
                    return yosikiDtl;
                }
                //紐づけ（帳票出力区分）に何が選ばれたとき、どの様式を表示したいかを管理の
                var hanyoDtl = DaHanyoService.GetHanyoDtl(db, hanyoDto.hanyomaincd, CInt(hanyoDto.hanyokbn2)).ToList();

                //すべて設定する様式ＩＤ
                var yosikiidAllList = hanyoDtl.Select(e => e.hanyocd).ToList();

                //設定する様式ＩＤ
                var yosikiidList = new List<string>();

                //様式紐づけ（帳票出力区分）はない場合
                if (string.IsNullOrEmpty(req.tyusyutukbn))
                {
                    //抽出対象コードより設定する様式ＩＤ
                    yosikiidList = hanyoDtl.Where(d => d.hanyokbn2 == req.tyusyututaisyocd).Select(d => d.hanyocd).ToList();
                }
                else
                {
                    //帳票出力区分より設定する様式ＩＤ
                    yosikiidList = hanyoDtl.Where(d => d.hanyokbn1 == req.tyusyutukbn && d.hanyokbn2 == req.tyusyututaisyocd).Select(d => d.hanyocd).ToList();
                }

                //EUC様式マスタデータリスト
                yosikiDtl = yosikiDtl.Where(e => !yosikiidAllList.Contains(e.yosikiid) || yosikiidList.Contains(e.yosikiid)).ToList();
            }
            else
            {
                //様式紐付けから、様式一覧を取得
                if (!string.IsNullOrEmpty(req.himozukevalue))
                {
                    //様式紐付け検索条件を取得するフィルター
                    const string filter =
                        $"{nameof(tm_euyosikiDto.rptid)} = @{nameof(tm_euyosikiDto.rptid)} " +
                        $"AND {nameof(tm_euyosikiDto.himozukejyokenid)} = @{nameof(tm_euyosikiDto.himozukejyokenid)} " +
                        $"AND {nameof(tm_euyosikiDto.himozukevalue)} = @{nameof(tm_euyosikiDto.himozukevalue)}";

                    //EUC様式マスタデータリスト
                    yosikiDtl = db.tm_euyosiki.SELECT.WHERE.ByFilter(filter, req.rptid, req.himozukejyokenid!, req.himozukevalue).GetDtoList();
                }
                else
                {
                    //EUC様式マスタデータリスト
                    yosikiDtl = db.tm_euyosiki.SELECT.WHERE.ByKey(req.rptid).GetDtoList();
                }
            }
            return yosikiDtl;
        }
    }
}