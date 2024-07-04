// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票管理(一覧)
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWEU00306D;
using BCC.Affect.Service.Common;
using Microsoft.Extensions.Caching.Memory;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Text.RegularExpressions;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00201G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索処理（一覧検索）
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            return new List<AiKeyValue>
            {
                new($"{nameof(SearchListRequest.gyoumucd)}_in", DaSelectorService.GetCd(req.gyoumucd)),           //業務コード
                new($"{nameof(SearchListRequest.rptgroupid)}_in", DaSelectorService.GetCd(req.rptgroupid)),       //帳票グループID
                new($"{nameof(SearchListRequest.rptnm)}_in", ToLikeStr(req.rptnm)),                               //帳票名
                new($"{nameof(SearchListRequest.yosikinm)}_in", ToLikeStr(req.yosikinm)),                         //様式名
                new($"{nameof(SearchListRequest.yoshikibunrui)}_in", DaSelectorService.GetCd(req.yoshikibunrui)), //様式分類
                new($"{nameof(SearchListRequest.yosikisyubetu)}_in", DaSelectorService.GetCd(req.yosikisyubetu)), //様式種別
            };
        }

        /// <summary>
        /// 帳票タブ情報を取得
        /// </summary>
        public static tm_eurptDto GetReportDto(tm_eurptDto eureportDto, SaveProjectRequest req)
        {
            eureportDto.rptnm = req.rptnm;                                              //帳票名
            eureportDto.rptid = req.rptid;                                              //帳票ID
            eureportDto.rptbiko = req.rptDetailParam.rptbiko;                           //帳票説明
            eureportDto.datasourceid = req.datasourceid;                                //データソースID
            eureportDto.procnm = req.procnm;                                            //プロシージャ名
            eureportDto.sql = req.sql;                                                  //SQL
            eureportDto.atenaflg = req.rptDetailParam.atenaflg;                         //宛名フラグ
            eureportDto.ninsanputorokunoflg = req.rptDetailParam.ninsanpuflg;                   //妊産婦フラグ
            eureportDto.addresssealflg = req.rptDetailParam.addresssealflg;             //アドレスシール固定様式
            eureportDto.barcodesealflg = req.rptDetailParam.barcodesealflg;             //バーコードシール固定様式
            eureportDto.hagakiflg = req.rptDetailParam.hagakiflg;                       //はがき固定様式
            eureportDto.atenadaityoflg = req.rptDetailParam.atenadaityoflg;             //宛名台帳　固定様式
            eureportDto.kensuhyonenreiflg = req.rptDetailParam.kensuhyonenreiflg;       //件数表(年齢別)固定様式
            eureportDto.kensuhyogyoseikuflg = req.rptDetailParam.kensuhyogyoseikuflg;   //件数表(行政区別)固定様式
            eureportDto.rptgroupid = req.rptDetailParam.rptgroupid;                     // 帳票グループID
            eureportDto.yosikihimonm = req.rptDetailParam.yosikihimonm;                 // 様式紐付け名
            if (!req.rptDetailParam.orderseq.HasValue)
            {
                eureportDto.orderseq = 0;
            }
            else
            {
                eureportDto.orderseq = (int)req.rptDetailParam.orderseq;                //並びシーケンス
            }
            
            eureportDto.tyusyutupanelflg = req.rptDetailParam.tyusyutupanelflg;         // 抽出パネル表示フラグ

            return eureportDto;
        }

        /// <summary>
        /// updateSqlチェック処理
        /// 帳票様式を取得
        /// </summary>
        public static String CheckUpdateSql(DaDbContext db, string updateSql, List<SearchConditionVM> kensakuList)
        {
            string errorMeg = "";
            //文字列に 2 つの括弧が含まれているかどうかを判断します
            if (ContainsTwoLeftParentheses(updateSql))
            {
                //入力値が不正です。
                errorMeg = DaMessageService.GetMsg(EnumMessage.E003006, updateSql);
                return errorMeg;
            }
            //文法チェック
            int startIndex = updateSql.IndexOf('(');
            int endIndex = updateSql.LastIndexOf(')');
            if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
            {

                var sqlName = updateSql.Substring(0, startIndex).Trim();

                DaEucBasicService._memoryCache = new(new MemoryCacheOptions { ExpirationScanFrequency = TimeSpan.FromMinutes(5) });

                var functionVO = DaEucBasicService.GetFunctionByName(db, sqlName, sqlName);
                //プロシージャの存在性
                if (functionVO == null)
                {
                    //updateSql存在しません
                    errorMeg = DaMessageService.GetMsg(EnumMessage.E003005, sqlName);
                    return errorMeg;
                }
                string valuesString = updateSql.Substring(startIndex + 1, endIndex - startIndex - 1);
                if (string.IsNullOrEmpty(valuesString))
                {
                    //入力値が不正です。確認してください。
                    errorMeg = DaMessageService.GetMsg(EnumMessage.ITEM_ILLEGAL_ALERT, sqlName);
                    return errorMeg;

                }
                List<object> valuesList = new List<object>(valuesString.Split(','));
                //入力した引数はDBから取得するプロシージャ引数の数が一致する
                if (functionVO != null && functionVO.conditionparams.Count != valuesList.Count)
                {
                    //一致していません
                    errorMeg = DaMessageService.GetMsg(EnumMessage.ITEM_NOTEQUAL_ERROR, $"{sqlName}の引数");
                    return errorMeg;
                }

                //ストアド プロシージャのデータ型と usql のパラメータ値の型を比較します。
                for (int i = 0; i < functionVO!.conditionparams.Count && i < valuesList.Count; i++)
                {
                    var cell = functionVO.conditionparams[i];
                    var parameterValue = valuesList[i] != null ? valuesList[i].ToString()!.Trim() : null;
                    if (!parameterValue!.Contains("@"))
                    {
                        // DataType とパラメータ値の型が一致するかどうかを確認する
                        if (!string.IsNullOrEmpty(parameterValue))
                        {
                            if (cell.DataType != EnumDataType.整数 
                                && cell.DataType != EnumDataType.小数 
                                && cell.DataType != EnumDataType.フラグ)
                            {
                                if(!Regex.IsMatch(parameterValue, @"^'.*'$"))
                                {
                                    errorMeg = DaMessageService.GetMsg(EnumMessage.ITEM_NOTEQUAL_ERROR, $"{sqlName}のパラメータ値[{parameterValue}]のデータ型");
                                    return errorMeg;
                                }
                            }
                        }
                        else
                        {
                            errorMeg = DaMessageService.GetMsg(EnumMessage.E003006, $"{sqlName}のパラメータ値");
                            return errorMeg;
                        }
                    }
                }

                //「＠」を付けた引数名は検索条件に存在する
                var containingAt = valuesList.Where(item => item.ToString()!.Contains("@")).ToList();
                if (containingAt.Count > 0)
                {
                    //「＠」で対応範囲内でしょうか
                    foreach (var atInfo in containingAt)
                    {
                        bool foundMatch = false;
                        var newAtInfo = atInfo.ToString()!.Replace("@", "").Trim();
                        //最初に固定パラメータ項目を一致させます
                        if (!DaSystemParameterManager.IsSystemParameter(newAtInfo))
                        {
                            //一致するものがない場合は、受信した条件と一致します。
                            for (int j = 0; j < kensakuList.Count; j++)
                            {
                                if (kensakuList[j].jyokenlabel == newAtInfo)
                                {
                                    foundMatch = true;
                                    break;
                                }
                            }

                            if (!foundMatch)
                            {
                                errorMeg = DaMessageService.GetMsg(EnumMessage.E003005, $"{newAtInfo}の入力値");
                                return errorMeg;
                            }
                        }
                    }
                }
            }
            else
            {
                //updateSqlが不正です
                errorMeg = DaMessageService.GetMsg(EnumMessage.E003005, updateSql);
            }

            DaEucBasicService._memoryCache = new(new MemoryCacheOptions { ExpirationScanFrequency = TimeSpan.FromMinutes(5) });
            return errorMeg;
        }

        /// <summary>
        /// 括弧の判断します
        /// </summary>
        static bool ContainsTwoLeftParentheses(string updateSql)
        {
            int count = 0;
            bool insideQuotes = false;

            foreach (char c in updateSql)
            {
                if (c == '"')
                    insideQuotes = !insideQuotes;

                if (!insideQuotes)
                {
                    if (c == '(')
                        count++;

                    if (c == ')')
                        count--;
                }
            }

            return count >= 2;
        }

        /// <summary>
        /// 帳票様式詳細を取得
        /// </summary>
        public static tm_euyosikisyosaiDto GetReportSyosaiDto(tm_euyosikisyosaiDto yosikisyosaiDto, SaveProjectRequest req)
        {
            yosikisyosaiDto.rptid = req.rptid;                                                  //帳票ID
            yosikisyosaiDto.yosikiid = req.yosikiid;                                            //様式ID
            yosikisyosaiDto.yosikieda = req.yosikieda;                                          //様式枝番
            yosikisyosaiDto.yosikinm = req.yosikinm;                                            //様式名
            yosikisyosaiDto.yosikisyubetu = req.styleDetailParam.yosikisyubetu;                 //様式種別 
            yosikisyosaiDto.yosikikbn = req.styleDetailParam.yosikikbn;                         //様式種別詳細
            yosikisyosaiDto.meisaiflg = req.styleDetailParam.meisaiflg;                         //明細有無
            yosikisyosaiDto.yosikihouhou = req.yosikihouhou;                                    //様式作成方法
            yosikisyosaiDto.distinctflg = CBool(req.styleDetailParam.distinctflg);              //重複データ排除フラグ
            yosikisyosaiDto.meisaikoteikbn = req.styleDetailParam.meisaikoteikbn;               //行（列）固定区分
            yosikisyosaiDto.nulltozeroflg = CBool(req.styleDetailParam.nulltozeroflg);          //空白値ゼロ出力フラグ
            yosikisyosaiDto.himozukejyokenid = req.styleDetailParam.himozukejyokenid;           //紐づけ条件ID
            if (req.excelData.Count > 0)
            {
                var excelData = req.excelData[0];
                yosikisyosaiDto.startrow = excelData?.startrow ?? 1;                            //テンプレート明細開始行
                yosikisyosaiDto.loopmaxrow = excelData?.loopmaxrow ?? 15;                       //ページあたりの最大行数
                yosikisyosaiDto.looprow = excelData?.looprow ?? 1;                    　        //単 一データ行の数
                yosikisyosaiDto.startcol = excelData?.startcol ?? 1;                            //明細開始列数
                yosikisyosaiDto.loopmaxcol = excelData?.loopmaxcol ?? 5;                        //（複数列の場合）データの最大列数
                yosikisyosaiDto.loopcol = excelData?.loopcol ?? 1;                              //（複数列の場合）明細列数（列間のColumn数）
            }
            return yosikisyosaiDto;
        }

        /// <summary>
        /// 帳票様式を取得
        /// </summary>
        public static tm_euyosikiDto GetReportYosikiDto(tm_euyosikiDto yosikiDto, SaveProjectRequest req)
        {
            if (req.excelData.Count > 0 && req.files.Count > 0)
            {
                var excelData = req.excelData[0];
                yosikiDto.templatefilenm = excelData.templatefilenm;               //テンプレートファイル名
                yosikiDto.templatefiledata = GetRealExcelFileData(req.files[0].filedata, excelData.celldatas); //テンプレートファイル         
                yosikiDto.endrow = excelData?.endrow is null or < 1 ? (excelData?.loopmaxrow ?? 15) : excelData.endrow.Value;                            //テンプレート終了行
                yosikiDto.endcol = excelData?.endcol is null or < 1 ? CommonUtil.GetExcelEndCol(excelData?.templatefiledata) : excelData.endcol.Value;                            //テンプレート終了列
                yosikiDto.pagesize = (int?)excelData.pagesize;                     //ページサイズ
                yosikiDto.landscape = excelData?.landscape ?? false;               //用紙の向き
            }
            yosikiDto.rptid = req.rptid;
            yosikiDto.yosikiid = req.yosikiid;
            yosikiDto.pdfflg = CBool(req.styleDetailParam.pdfflg);                  //pdf出力形式          
            yosikiDto.excelflg = CBool(req.styleDetailParam.excelflg);              //excel出力形式
            yosikiDto.otherflg = CBool(req.styleDetailParam.otherflg);              //other出力形式
            yosikiDto.koinnmflg = req.styleDetailParam.koinnmflg;                  // 市区町村印字 公印
            yosikiDto.koinpicflg = req.styleDetailParam.koinpicflg;                // 電子更新印字公印
            yosikiDto.dairisyaflg = req.styleDetailParam.dairisyaflg;              // 職務代理者適用公印
            yosikiDto.naigaikbn = req.styleDetailParam.naigaikbn;                  //内外区分
            yosikiDto.toiawasesakicd = req.styleDetailParam.toiawasesakicd;        //問い合わせ
            yosikiDto.kacd = CNStr(req.styleDetailParam.kacd);                     //課コード
            yosikiDto.kakaricd = CNStr(req.styleDetailParam.kakaricd);             //係コード
            yosikiDto.updatesql = req.styleDetailParam.updatesql;                  //更新プロシージャ/SQL   
            yosikiDto.himozukevalue = CNStr(req.styleDetailParam.himozukevalue);   // 様式紐付け値
            yosikiDto.himozukejyokenid = req.styleDetailParam.himozukejyokenid;    // 様式紐付けID
            //更新日時
            yosikiDto.hakokbn = req.styleDetailParam.hakokbn;                      //帳票発行履歴管理区分
            yosikiDto.gyomuflg = CBool(req.styleDetailParam.gyomuflg);             //業務画面使用フラグ
            yosikiDto.tutisyoflg = CBool(req.styleDetailParam.tutisyoflg);         //通知書出力フラグ
            yosikiDto.hakoflg = CBool(req.styleDetailParam.hakoflg);               //帳票発行履歴管理フラグ
            yosikiDto.updateflg = CBool(req.styleDetailParam.updateflg);           //更新フラグ

            if (!req.styleDetailParam.orderseq.HasValue)
            {
                yosikiDto.orderseq = 0;                       //並びシーケンス
            }
            else 
            {
                yosikiDto.orderseq = (int)req.styleDetailParam.orderseq;
            }                    
            return yosikiDto;
        }

        /// <summary>
        /// 帳票項目リストを取得
        /// </summary>
        public static List<tm_eurptitemDto> GetReportItemDtl(List<ReportItemDetailVM> definitionList, SaveProjectRequest req, List<tm_eurptitemDto>? grouptableitemDtl = null,
            HashSet<string>? checkeditemryasyos = null)
        {
            var rptItemId = 1;
            var orderseq = 0;
            if (req.styleDetailParam.yosikikbn == Enum様式種別詳細.クロス集計)
            {
                definitionList = definitionList.OrderBy(e => e.crosskbn).ThenBy(e => e.level).ToList();
            }

            definitionList = checkeditemryasyos == null || !checkeditemryasyos.Any() ? definitionList : definitionList.Where(x => checkeditemryasyos.Contains(x.reportitemnm)).ToList();
            return definitionList.Select(x => GetRepotItemDto(x, req, req.kbn == Enum帳票様式.サブ様式 ? rptItemId++ : 0, orderseq++, grouptableitemDtl)).Where(x => x != null).ToList()!;
        }

        /// <summary>
        /// 帳票項目を取得
        /// </summary>
        private static tm_eurptitemDto? GetRepotItemDto(ReportItemDetailVM vm, SaveProjectRequest req, int rptItemId, int orderseq, List<tm_eurptitemDto>? grouptableitemDtl = null)
        {
            var sql = vm.sqlcolumn;
            if (string.IsNullOrEmpty(sql) && grouptableitemDtl != null)
            {
                var find = grouptableitemDtl.Find(x => x.yosikiitemid == vm.yosikiitemid);
                if (find == null) return null;
                sql = find.sqlcolumn;
            }
            var dto = new tm_eurptitemDto();
            dto.rptid = req.rptid;                                  //帳票ID
            dto.yosikiid = req.yosikiid;                            //様式ID
            dto.yosikieda = rptItemId;                              //様式枝番ID
            dto.yosikiitemid = vm.yosikiitemid;                     //グループ項目ID
            dto.reportitemnm = vm.reportitemnm;                     //帳票項目名称
            dto.csvitemnm = vm.csvitemnm;                           //CSV項目名称
            dto.tablealias = vm.tablealias;                         //テーブル別名
            dto.sqlcolumn = sql;                                    //SQL
            dto.orderkbn = vm.orderkbn;                             //並び替え
            dto.orderkbnseq = vm.orderkbnseq;                       //並び替えシーケンス
            dto.orderseq = orderseq;                                //並びシーケンス
            dto.reportoutputflg = CBool(vm.reportoutputflg);        //帳票出力フラグ
            dto.csvoutputflg = CBool(vm.csvoutputflg);              //CSV出力フラグ
            dto.headerflg = CBool(vm.headerflg);                    //ヘッダーフラグ
            dto.kaipageflg = CBool(vm.kaipageflg);                  //改ページフラグ
            dto.itemkbn = vm.itemkbn;                               //項目区分
            dto.mastercd = CNStr(vm.mastercd);                      //名称マスタコード
            dto.kaipageflg = vm.kaipageflg;                         //改ページフラグ
            dto.masterpara = CNStr(vm.masterpara);                  //名称マスタパラメータ
            dto.formatkbn = CNStr(vm.formatkbn);
            dto.formatkbn2 = CNStr(vm.formatkbn2);
            dto.formatsyosai = vm.formatsyosai;                     //フォマード詳細
            dto.height = vm.height;                                 //高
            dto.width = vm.width;                                   //幅
            dto.offsetx = vm.offsetx;                               // 水平調整
            dto.offsety = vm.offsety;                               // 垂直調整
            dto.crosskbn = EnumToNStr(vm.crosskbn);                 //集計区分
            //dto.syukeihoho = CNStr(vm.syukeihoho);                  //集計方法
            dto.keyvaluepairsjson = CNStr(vm.keyvaluepairsjson);    //複数のキー・値・ペアjson
            dto.kbn1 = CNStr(vm.kbn1);                              //小計区分
            dto.level = CNInt(vm.level);                            //集計レベル
            dto.blankvalue = vm.blankvalue;                         //白紙時出力
            return dto;
        }

        /// <summary>
        /// データソースの固定条件リストを取得
        /// </summary>
        public static List<tm_eurptkensakuDto> GetDataSourseCoditionDtl(List<tm_eudatasourcekensakuDto> kensakuList, string rptid)
        {
            var seq = 1;
            return kensakuList.Select(x => GetDataSourseCoditionDto(x, rptid, seq++)).ToList();
        }

        /// <summary>
        /// データソースの固定条件を取得
        /// </summary>
        private static tm_eurptkensakuDto GetDataSourseCoditionDto(tm_eudatasourcekensakuDto vm, string rptid, int seq)
        {
            var dto = new tm_eurptkensakuDto();
            dto.rptid = rptid;                                                      //帳票ID
            dto.datasourceid = vm.datasourceid;                                     //データソースID
            dto.jyokenlabel = vm.jyokenlabel;                                       //ラベル
            dto.jyokenid = vm.jyokenid;                                             //条件ID
            dto.jyokenkbn = EnumToStr(Enum検索条件区分.固定条件);                   //検索条件区分
            dto.tablealias = vm.tablealias;                                         //テーブル別名
            dto.variables = vm.variables;                                           //変数名
            dto.mastercd = vm.mastercd;                                             //名称マスタコード
            dto.masterpara = vm.masterpara;                                         //名称マスタパラメータ
            dto.sansyomotosql = vm.sansyomotosql;                                   //参照元SQL
            dto.orderseq = seq;                                                     //並びシーケンス
            dto.sql = vm.sql;                                                       //SQL
            dto.hissuflg = false;                                                    //必須フラグ
            dto.controlkbn = (int)vm.controlkbn;                                    //コントロール区分
            dto.datatype = (int)vm.datatype;                                        //データ型
            if (dto.jyokenid < 0)
            {
                dto.datasourceid = null;                                            //データソースID
                dto.jyokenid = null;                                                //条件ID

            }
            return dto;
        }

        /// <summary>
        /// 帳票の検索条件リストを取得
        /// </summary>
        public static List<tm_eurptkensakuDto> GeReportCoditionDtl(List<SearchConditionVM> rptConditionList, string rptid, Enum様式作成方法 yosikihouhou)
        {
            //if (rptDto.yosikisyubetu == Enum様式種別.経年表 && rptConditionList.All(x => x.label != EucConstant.NENDO_NAME))
            //{
            //    throw new Exception("経年表には年度の検索条件が必要です。");
            //}
            var orderseq = 0;
            return rptConditionList.Select(x => GetReportCoditionDto(x, rptid, yosikihouhou,++orderseq)).ToList();
        }

        /// <summary>
        /// 帳票の検索条件を取得
        /// </summary>
        private static tm_eurptkensakuDto GetReportCoditionDto(SearchConditionVM vm, string rptid, Enum様式作成方法 yosikihouhou,int orderseq)
        {
            var dto = new tm_eurptkensakuDto();
            dto.rptid = rptid;                                      //帳票ID
            dto.datasourceid = vm.datasourceid;                     //データソースID
            dto.jyokenlabel = vm.jyokenlabel;                       //ラベル
            dto.jyokenid = vm.jyokenid;                             //条件ID
            dto.tablealias = vm.tablealias;                         //テーブル別名
            dto.variables = vm.variables;                           //変数名
            dto.mastercd = vm.mastercd;                             //名称マスタコード
            dto.masterpara = vm.masterpara;                         //名称マスタパラメータ 
            dto.sansyomotosql = vm.sansyomotosql;                   //参照元SQL
            dto.orderseq = vm.orderseq;                             //並びシーケンス
            if (vm.orderseq < 999) 
            {
                dto.orderseq = orderseq; 
            }                           
            dto.sql = vm.sql;                                       //SQL
            dto.hissuflg = CBool(vm.hissuflg);                      //必須フラグ
            dto.nendohanikbn = vm.nendohanikbn;                     //年度範囲区分
            dto.controlkbn = (int)vm.controlkbn;                    //コントロール区分  
            dto.datatype = vm.datatype;                             //データ型
            dto.syokiti = CStr(vm.syokiti);                         //初期値
            dto.jyokenkbn = EnumToStr(Enum検索条件区分.通常条件);       //検索条件区分
            //条件追加
            if (!string.IsNullOrEmpty(vm.sqlcolumn) && string.IsNullOrEmpty(vm.datasourceid))
            {
                int indexOfDot = vm.sqlcolumn.IndexOf('.');
                if (indexOfDot != -1)
                {
                    dto.tablealias = vm.sqlcolumn.Substring(0, indexOfDot);
                }
            }
            if (vm.controlkbn == Enumコントロール.文字入力 && !string.IsNullOrEmpty(vm.aimaikbn))
            {
                dto.aimaikbn = CStr(vm.aimaikbn);                                                                //曖昧検索区分
            }
            return dto;
        }

        /// <summary>
        /// セル値入力後のエクセルの取得
        /// </summary>
        public static byte[] GetRealExcelFileData(byte[] oriFileBytes, IEnumerable<List<CellVM>> cellDatas)
        {
            var sheetCellDicList = cellDatas.Select(x => x.ToDictionary(c => (c.rowindex, c.columnindex), c => c.value)).ToList();
            int maxRowIndex = sheetCellDicList.Max(dic => dic.Keys.Max(key => key.Item1));
            int maxColumnIndex = sheetCellDicList.Max(dic => dic.Keys.Max(key => key.Item2));
            using var stream = new MemoryStream(oriFileBytes);
            var workbook = new XSSFWorkbook(stream);

            for (var i = 0; i < sheetCellDicList.Count; i++)
            {
                var sheet = workbook.GetSheetAt(i);
                for (var j = 0; j <= Math.Max(sheet.LastRowNum, maxRowIndex); j++)
                {
                    var row = sheet.GetRow(j);
                    int maxCellIndex = -1;
                    if (row == null)
                    {
                        row = sheet.CreateRow(j);
                    }
                    else
                    {
                        maxCellIndex = GetMaxCellIndex(row);
                    }
                    for (var k = 0; k <= Math.Max(maxCellIndex, maxColumnIndex); k++)
                    {
                        var cell = row.GetCell(k) ?? row.CreateCell(k);
                        cell.SetBlank();
                        if (sheetCellDicList[i].TryGetValue((j, k), out var value))
                        {
                            SetCellValue(cell, value);
                        }
                    }
                }
            }

            using var output = new MemoryStream();
            workbook.Write(output);
            return output.ToArray();
        }

        /// <summary>
        /// 行の最大値を取得
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static int GetMaxCellIndex(IRow row)
        {
            int maxCellIndex = -1;
            for (int k = row.FirstCellNum; k < row.LastCellNum; k++)
            {
                var cell = row.GetCell(k);
                if (cell != null && !IsCellEmpty(cell))
                {
                    maxCellIndex = k;
                }
            }
            return maxCellIndex;
        }

        /// <summary>
        ///セル非空白
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static bool IsCellEmpty(ICell cell)
        {
            if (cell == null)
            {
                return true;
            }

            switch (cell.CellType)
            {
                case CellType.String:
                    return string.IsNullOrWhiteSpace(cell.StringCellValue);
                case CellType.Numeric:
                    return false;
                case CellType.Boolean:
                    return false;
                case CellType.Formula:
                    return string.IsNullOrWhiteSpace(cell.CellFormula);
                case CellType.Blank:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// セルに値を設定
        /// </summary>
        private static void SetCellValue(ICell cell, object? value)
        {
            switch (value)
            {
                case null:
                    cell.SetBlank();
                    break;
                case double d:
                    cell.SetCellValue(d);
                    break;
                case DateTime dt:
                    cell.SetCellValue(dt);
                    break;
                case string s:
                    cell.SetCellValue(string.IsNullOrEmpty(s) ? null : s);
                    break;
                case bool b:
                    cell.SetCellValue(b);
                    break;
                default:
                    var valueStr = value.ToString();
                    cell.SetCellValue(string.IsNullOrEmpty(valueStr) ? null : valueStr);
                    break;
            }
        }

        /// <summary>
        /// 出力順パターンサブ情報リスト取得(新規)
        /// </summary>
        public static List<tt_eusort_subDto> GetAddSortSubDtl(string rptid, string yosikiid, List<SortSubVM> sortsublist,  int sortptnno)
        {
            return sortsublist.Select((x, index) => GetSortSubDto(x, rptid, yosikiid, sortptnno, index + 1)).ToList();
        }

        /// <summary>
        /// 出力順パターンサブ情報取得
        /// </summary>
        private static tt_eusort_subDto GetSortSubDto(SortSubVM vm, string rptid, string yosikiid, int sortptnno, int orderseq)
        {
            var dto = new tt_eusort_subDto();
            dto.rptid = rptid;                         //帳票ID
            dto.yosikiid = yosikiid;                   //様式ID
            dto.sortptnno = sortptnno;                 //出力順パターン番号
            dto.reportitemid = vm.reportitemid;        //帳票項目ID
            dto.descflg = vm.descflg;                  //降順フラグ
            dto.pageflg = vm.pageflg;                  //改ページフラグ
            dto.orderseq = orderseq;                   //並びシーケンス
            return dto;
        }
        /// <summary>
        /// 検索条件SQLのチェック
        /// </summary>
        public static string CheckSqlcolumn(DaDbContext db, List<string> sqlcolumns)
        {
            // SQLColumn,検索条件SQLのチェック
            bool hasError = false;
            string msg = string.Empty;
            var errors = new List<string>();  // すべてのエラーメッセージを保存するために使用されます
            foreach (var sqlcolumn in sqlcolumns)
            {
                var ret = DaEucService.CheckItemSQL(db, sqlcolumn);
                if (ret != null)
                {
                    hasError = true;
                    errors.Add(ret);
                }
            }
            if (hasError)
            {
                msg = string.Join(",", errors);
            }
            return msg;
        }
        /// <summary>
        /// 経年表の場合、項目定義で改ページと年度フラグのチェック
        /// </summary>
        public static string CheckNendoReportItem(List<ReportItemDetailVM> kaipageflgItemList, List<ReportItemDetailVM> headerflgItemList)
        {
            string msg = string.Empty;
            if (kaipageflgItemList.Count == 0)
            {
                 msg = DaMessageService.GetMsg(EnumMessage.E064015, "改ページ");
            }else if (headerflgItemList.Count == 0)
            {
                 msg = DaMessageService.GetMsg(EnumMessage.E064015, "年度フラグ");
            }
            return msg;
        }
        /// <summary>
        /// 単純集計表の場合、項目定義での項目の集計区分は少なくとも 1 つが集計のチェック
        /// </summary>
        public static string CheckTanjunshukeiItemList(List<ReportItemDetailVM> tanjunshukeiItemList)
        {
            string msg = string.Empty;
            if (tanjunshukeiItemList.Count == 0)
            {
                msg = DaMessageService.GetMsg(EnumMessage.E064015, "集計項目");
            }
            return msg;
        }
    }
}