// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.プロシージャ管理画面
// 　　　　　　サービス処理
// 作成日　　: 2023.10.09
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using Microsoft.Extensions.Caching.Memory;
using System.Text.RegularExpressions;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00607D
{
    [DisplayName("取込設定：プロシージャ管理画面")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00607D = "AWKK00607D";
        private const string TORIKOMI_FUNCTION_PREFIX = "sp_";

        [DisplayName("初期化処理(取込設定：プロシージャ管理画面)")]
        public InitResponse InitDetail(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();

                //ドロップダウンリストの初期化データ

                //【処理種別】のドロップダウンリスト
                var dtl = DaNameService.GetNameList(db, EnumNmKbn.処理種別);
                res.processingtypeList = dtl.Select(d => new DaSelectorKeyModel(d.nmcd, d.nm, d.kananm)).ToList();

                //プロシージャ情報
                var vm = new ProcedureVM();
                //プロシージャ区分
                vm.prockbn = EnumToStr(Enum処理種別.チェック用);
                res.procedureVM = vm;

                //正常返し
                return res;
            });
        }

        [DisplayName("【選択】【再読み込み】(取込設定：プロシージャ管理画面)")]
        public ReSearchResponse ReSearch(CommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new ReSearchResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //プロシージャマスタ
                tm_kktorinyuryoku_procDto dto = db.tm_kktorinyuryoku_proc.SELECT.WHERE.ByKey(req.procseq).GetDto();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                if (dto != null)
                {
                    DaEucBasicService._memoryCache = new(new MemoryCacheOptions { ExpirationScanFrequency = TimeSpan.FromMinutes(5) });
                    var func = DaEucBasicService.GetFunctionByName(db, dto.procnm, TORIKOMI_FUNCTION_PREFIX);
                    if (func == null)
                    {
                        throw new Exception("プロシージャが存在しません。");
                    }
                    //プロシージャ情報
                    res.procedureVM = Wraper.GetProcedureVM(dto, func);
                }
                DaEucBasicService._memoryCache = new(new MemoryCacheOptions { ExpirationScanFrequency = TimeSpan.FromMinutes(5) });

                //正常返し
                return res;
            });
        }

        [DisplayName("登録処理(取込設定：プロシージャ管理画面)")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //プロシージャマスタ
                var dtoOld = new tm_kktorinyuryoku_procDto();

                //新規排他チェック
                if (req.editkbn == Enum編集区分.新規)
                {
                    //プロシージャ名チェック
                    dtoOld = db.tm_kktorinyuryoku_proc.SELECT.WHERE.ByItem(nameof(tm_kktorinyuryoku_procDto.procnm), req.procedureVM.procnm).GetDto();
                    if (dtoOld != null)
                    {
                        //プロシージャ名が重複しています。
                        var msg = DaMessageService.GetMsg(EnumMessage.E001008, "プロシージャ名");
                        res.SetServiceError(msg);
                        return res;
                    }
                }
                else
                {
                    //編集前のプロシージャマスタ取得
                    dtoOld = db.tm_kktorinyuryoku_proc.SELECT.WHERE.ByKey(req.procedureVM.procseq).GetDto();
                    //更新排他チェック
                    if (dtoOld == null || dtoOld.upddttm.Ticks == DaUtil.Now.Ticks)
                    {
                        throw new AiExclusiveException();
                    }
                }

                //プロシージャ名一致チェック
                var functionName = FunctionParseUtil.CheckAndGetFuctionName(req.procedureVM.procsql, check: true, necessaryPrefix: TORIKOMI_FUNCTION_PREFIX);
                if (!functionName.Equals(req.procedureVM.procnm))
                {
                    //プロシージャ名と一致していません。
                    var msg = DaMessageService.GetMsg(EnumMessage.ITEM_NOTEQUAL_ERROR, "ヘッダー部の「プロシージャ名」は内容部のプロシージャ名");
                    res.SetServiceError(msg);
                    return res;
                }

                //パラメータチェック
                var conditionparams = ParseProcedureParameters(req.procedureVM.procsql);
                if (conditionparams.Count != 1)
                {
                    //引数（１個のみ）を正しく入力してください。
                    var msg = DaMessageService.GetMsg(EnumMessage.ITEM_ILLEGAL_ERROR, "引数（１個のみ）");
                    res.SetServiceError(msg);
                    return res;
                }
                else if (!conditionparams[0].DataType.ToLower().Equals("integer"))
                {
                    //引数データ型（integer型）を正しく入力してください。
                    var msg = DaMessageService.GetMsg(EnumMessage.ITEM_ILLEGAL_ERROR, "引数データ型（integer型）");
                    res.SetServiceError(msg);
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                DateTime dttm = DaUtil.Now;
                //プロシージャマスタ
                tm_kktorinyuryoku_procDto kkprocDto = Converter.GetkkprocDto(dtoOld!, req, dttm);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    kkprocDto.procseq = GetProcSeq(db);
                    //プロシージャマスタデータ登録
                    db.tm_kktorinyuryoku_proc.INSERT.Execute(kkprocDto);
                }
                else //変更の場合
                {
                    //プロシージャマスタデータ更新
                    db.tm_kktorinyuryoku_proc.UpdateDto(kkprocDto, dtoOld!.upddttm);
                    DeleteProcedureData(db, kkprocDto.procnm);
                }

                //-------------------------------------------------------------
                //４.プロシージャ実行
                //-------------------------------------------------------------
                
                DoProcedure(db, req.procedureVM);

                //正常返し
                return res;
            });
        }

        [DisplayName("削除処理(取込設定：プロシージャ管理画面)")]
        public DaResponseBase Delete(CommonRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();

                //-------------------------------------------------------------
                //１.チェック
                //-------------------------------------------------------------
                //編集前のプロシージャマスタ取得
                tm_kktorinyuryoku_procDto kkprocDto = db.tm_kktorinyuryoku_proc.SELECT.WHERE.ByKey(req.procseq).GetDto();
                //排他チェック
                if (kkprocDto == null || kkprocDto.upddttm.Ticks == DaUtil.Now.Ticks)
                {
                    throw new AiExclusiveException();
                }

                //プロシージャ名
                var procnm = "";
                switch (ParseEnum<Enum処理種別>(kkprocDto.prockbn))
                {
                    case Enum処理種別.チェック用:
                        procnm = nameof(tm_kktorinyuryokuDto.proccheck);
                        break;
                    case Enum処理種別.更新前処理:
                        procnm = nameof(tm_kktorinyuryokuDto.procbefore);
                        break;
                    case Enum処理種別.更新後処理:
                        procnm = nameof(tm_kktorinyuryokuDto.procafter);
                        break;
                    default:
                        throw new Exception();
                }

                //一括取込入力マスタ
                tm_kktorinyuryokuDto kkimpDto = db.tm_kktorinyuryoku.SELECT.WHERE.ByItem(procnm, kkprocDto.procnm).GetDto();
                if (kkimpDto != null)
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E004009);
                    res.SetServiceAlert(msg);
                    return res;
                }

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                //プロシージャマスタ
                db.tm_kktorinyuryoku_proc.DELETE.WHERE.ByKey(req.procseq).Execute();
                //ストアドプロシージャを削除
                DeleteProcedureData(db, kkprocDto.procnm);

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// プロシージャ実行
        /// </summary>
        private void DoProcedure(DaDbContext db, ProcedureVM procedureVM)
        {
            var sql = "";
            sql += procedureVM.procsql + " \r\n    ";       //内容

            DaDbUtil.RunSql(db, sql);
        }

        /// <summary>
        /// ストアドプロシージャを削除
        /// </summary>
        private void DeleteProcedureData(DaDbContext db, string procedurenm)
        {
            var sql = "drop function if exists " + procedurenm.ToLower();
            DaDbUtil.RunSql(db, sql);
        }

        /// <summary>
        /// プロシージャNo手動採番(パッケージの意味(1桁) + 連番(4桁))

        /// </summary>
        private string GetProcSeq(DaDbContext db)
        {
            //自動採番MAX
            var maxseq = db.tm_kktorinyuryoku_proc.SELECT.GetMax<int>(nameof(tm_kktorinyuryoku_procDto.procseq));
            if(maxseq != 0)
            {
                //自動採番MAX+1
                return CStr(maxseq + 1);
            }
            //初期値
            return "10001";
        }

        /// <summary>
        /// プロシージャのパラメータを解析
        /// </summary>
        /// <param name="procedureSql"></param>
        /// <returns></returns>
        private static List<ProcedureParameter> ParseProcedureParameters(string procedureSql)
        {
            var parameters = new List<ProcedureParameter>();

            string pattern = @"FUNCTION\s+\w+\s*\(([^)]*)\)";
            var match = Regex.Match(procedureSql, pattern, RegexOptions.IgnoreCase);

            if (match.Success)
            {
                string paramsPart = match.Groups[1].Value;

                string[] paramList = paramsPart.Split(',');

                foreach (var param in paramList)
                {
                    string trimmedParam = param.Trim();

                    string[] paramParts = trimmedParam.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (paramParts.Length >= 2)
                    {
                        string dataType = paramParts[paramParts.Length - 1];
                        string name = paramParts[paramParts.Length - 2];

                        if (paramParts.Length > 2)
                        {
                            name = paramParts[paramParts.Length - 3];
                        }

                        parameters.Add(new ProcedureParameter
                        {
                            Name = name,
                            DataType = dataType
                        });
                    }
                }
            }

            return parameters;
        }
    }
}