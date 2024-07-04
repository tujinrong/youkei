// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: CSV出力項目選択
// 　　　　　　サービス処理
// 作成日　　: 2024.02.26
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00307D
{
    [DisplayName("CSV出力項目選択")]
    public class Service : CmServiceBase
    {
        [DisplayName("初期化処理")]
        public InitResponse Init(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //CSV出力パターンテーブル取得
                var filer = $"{nameof(tm_eurptitemDto.rptid)} = @{nameof(tm_eurptitemDto.rptid)}";
                var dtl = db.tt_eucsv.SELECT.WHERE.ByFilter(filer, req.rptid).GetDtoList().OrderBy(e => e.outputptnno).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(出力パターン)
                res.selectorlist = dtl.Select(e => new DaSelectorModel(e.outputptnno.ToString(), e.outputptnnm)).ToList();

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //EUC帳票項目マスタ取得
                var filer = $"{nameof(tm_eurptitemDto.rptid)} = @{nameof(tm_eurptitemDto.rptid)} " +
                $"          and {nameof(tm_eurptitemDto.yosikiid)} = @{nameof(tm_eurptitemDto.yosikiid)} ";
                var dtl = db.tm_eurptitem.SELECT.WHERE.ByFilter(filer, req.rptid, req.yosikiid).GetDtoList()
                    .Where(x => x.csvoutputflg).OrderBy(x => x.yosikiitemid)
                    .ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //帳票項目リスト(全て)
                res.kekkalist1 = Wraper.GetVMList(dtl);

                //修正の場合
                if (req.outputptnno != 0)
                {
                    //帳票CSV出力パターンテーブル取得
                    var dto = db.tt_eucsv.GetDtoByKey(req.rptid,req.yosikiid, req.outputptnno);
                    //帳票CSV出力パターンサブテーブル取得
                    var csvfiler = $"{nameof(tt_eucsv_subDto.rptid)} = @{nameof(tt_eucsv_subDto.rptid)} " +
                                    $"and {nameof(tt_eucsv_subDto.yosikiid)} = @{nameof(tt_eucsv_subDto.yosikiid)} " +
                                    $"and {nameof(tt_eucsv_subDto.outputptnno)} = @{nameof(tt_eucsv_subDto.outputptnno)} ";
                    var dtl2 = db.tt_eucsv_sub.SELECT.WHERE.ByFilter(csvfiler, req.rptid, req.yosikiid, req.outputptnno).GetDtoList().OrderBy(e => e.orderseq).ToList();
                    if (dto != null) 
                    {
                        res.outputptnnm = dto.outputptnnm;    //出力パターン名
                        res.upddttm = dto.upddttm;            //更新日時
                    }
                    if (dto != null)
                    {
                        //帳票項目リスト(出力用、ソート済)
                        res.kekkalist2 = dtl2.Select(e => e.reportitemid).ToList();
                    }
                }
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
                //１.データ取得
                //-------------------------------------------------------------
                // 帳票CSV出力パターンテーブル
                var dto = new tt_eucsvDto();
                //新規の場合
                if (req.outputptnno == 0)
                {
                    //出力パターン番号：自動採番
                    var filer = $"{nameof(tm_eurptitemDto.rptid)} = @{nameof(tm_eurptitemDto.rptid)}";
                    //帳票CSV出力パターンテーブル
                    dto.outputptnno = db.tt_eucsv.SELECT.WHERE.ByFilter(filer,req.rptid).GetMax<int>(nameof(tt_eucsvDto.outputptnno)) + 1;
                    dto.rptid = req.rptid;               //帳票ID
                    dto.yosikiid = req.yosikiid;         //様式ID
                    dto.outputptnnm = req.outputptnnm;   //出力パターン名
                }
                else
                {
                    //修正の場合
                    //排他
                    if (!db.tt_eucsv.SELECT.WHERE.ByKey(req.rptid, req.yosikiid, req.outputptnno).Exists()) throw new AiExclusiveException();
                    //帳票CSV出力パターンテーブル
                    dto = db.tt_eucsv.GetDtoByKey(req.rptid, req.yosikiid,req.outputptnno);
                }
                //EUC様式マスタ取得
                var yosikiDto = db.tm_euyosiki.GetDtoByKey(req.rptid, req.yosikiid);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                if (yosikiDto == null)
                {
                    throw new AiExclusiveException();
                }

                //出力パターン番号
                yosikiDto.outputptnno = dto.outputptnno;

                //帳票CSV出力パターンサブテーブル
                var dtl = Converter.GetDtl(req, dto.outputptnno);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //新規の場合
                if (req.outputptnno == 0)
                {
                    //CSV出力パターンテーブル
                    db.tt_eucsv.INSERT.Execute(dto);
                }
                else
                {
                    //修正の場合
                    //CSV出力パターンテーブル
                    db.tt_eucsv.UpdateDto(dto, req.upddttm!.Value);
                }
                //帳票CSV出力パターンサブテーブル
                db.tt_eucsv_sub.UPDATE.WHERE.ByKey(req.rptid, req.yosikiid, dto.outputptnno).Execute(dtl);
                //EUC様式マスタ
                db.tm_euyosiki.UpdateDto(yosikiDto, yosikiDto.upddttm);
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
                //１.データ取得
                //-------------------------------------------------------------
                //排他
                if (!db.tt_eucsv.SELECT.WHERE.ByKey(req.rptid, req.yosikiid, req.outputptnno).Exists())
                {
                    throw new AiExclusiveException();
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //帳票CSV出力パターンテーブル
                db.tt_eucsv.DeleteByKey(req.rptid,req.yosikiid, req.outputptnno, req.upddttm);
                //帳票CSV出力パターンサブテーブル
                db.tt_eucsv_sub.DELETE.WHERE.ByFilter($"{nameof(tt_eucsv_subDto.rptid)}=@rptid and " +
                                                              $"{nameof(tt_eucsv_subDto.yosikiid)}=@yosikiid and " +
                                                              $"{nameof(tt_eucsv_subDto.outputptnno)}=@outputptnno  "
                                                              , req.rptid,req.yosikiid, req.outputptnno).Execute();

                //正常返し
                return res;
            });
        }
    }
}