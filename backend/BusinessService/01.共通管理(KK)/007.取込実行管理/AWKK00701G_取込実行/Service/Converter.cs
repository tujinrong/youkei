// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************

using AIplus.AiImporter;
using BCC.Affect.Service.CheckImporter;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00701G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータを取得(取込設定一覧画面)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchKimpListRequest req)
        {
            var paras = new List<AiKeyValue> {
                new($"{nameof(SearchKimpListRequest.gyoumukbn)}_in", req.gyoumukbn),    //業務区分
                new($"{nameof(SearchKimpListRequest.impkbn)}_in", req.impkbn),          //一括取込入力区分
                new($"{nameof(SearchKimpListRequest.impnm)}_in", req.impnm)             //一括取込入力名 
            };

            return paras;
        }

        /// <summary>
        /// 検索パラメータを取得(未処理一覧画面/取込履歴一覧画面)
        /// </summary>
        public static List<AiKeyValue> GetParametersDetail(SearchKimpListRequest req)
        {
            var paras = new List<AiKeyValue> {
                new($"{nameof(SearchKimpListRequest.gyoumukbn)}_in", req.gyoumukbn),      //業務区分
                new($"{nameof(SearchKimpListRequest.impkbn)}_in", req.impkbn)             //一括取込入力区分
            };

            return paras;
        }

        /// <summary>
        /// 画面項目データ情報がデータテーブルに変換する
        /// </summary>
        public static DataTable GetPageItemDetailDtByVmList(List<KimpDetailRowVM> detailList)
        {
            var data = new DataTable();
            foreach (KimpDetailRowVM vm in detailList)
            {
                if (data.Columns.Count == 0)
                {
                    data.Columns.Add("RowNo");
                    for (int i = 0; i < vm.PageItemBodyList.Count; i++)
                    {
                        data.Columns.Add("Column" + vm.PageItemBodyList[i].pageitemseq);
                    }
                }
                var dataList = new List<string?>();
                dataList.Add(vm.rowno.ToString());//行番号
                List<string?> itemvalues = vm.PageItemBodyList.OrderBy(e => e.dataseq).Select(e => e.val).ToList();
                dataList.AddRange(itemvalues);
                data.Rows.Add(dataList.ToArray());
            }

            return data;
        }

        /// <summary>
        /// 画面項目データ情報が一時テーブルデータに変換する
        /// </summary>
        public static DataTable GetPageItemDetailDtByVmList2(List<KimpDetailRowVM> detailList, tm_kktorinyuryokuDto tm_kkimpDto, List<tm_kktorinyuryoku_itemDto> pageitemDtl)
        {
            var data = new DataTable();
            foreach (KimpDetailRowVM vm in detailList)
            {
                if (data.Columns.Count == 0)
                {
                    data.Columns.Add("RowNo");
                    for (int i = 0; i < vm.PageItemBodyList.Count; i++)
                    {
                        var pageitemseq = vm.PageItemBodyList[i].pageitemseq;
                        var item = pageitemDtl.Find(e => e.gamenitemseq == pageitemseq);
                        if (tm_kkimpDto.torinyuryokbn == EnumToStr(Enum取込区分.ファイル取込) && item!.inputkbn == EnumToStr(Enum入力区分.コード系))
                        {
                            data.Columns.Add("Column" + pageitemseq + "_bef");
                        }
                        data.Columns.Add("Column" + pageitemseq);
                    }
                }

                var dataList = new List<string?> { vm.rowno.ToString() }; // 行番号
                foreach (var bodyItem in vm.PageItemBodyList.OrderBy(e => e.dataseq))
                {
                    var item = pageitemDtl.Find(e => e.gamenitemseq == bodyItem.pageitemseq);

                    if (tm_kkimpDto.torinyuryokbn == EnumToStr(Enum取込区分.ファイル取込) && item!.inputkbn == EnumToStr(Enum入力区分.コード系))
                    {
                        var splitValues = bodyItem.val?.Split(',');
                        if (splitValues != null && splitValues.Length > 1)
                        {
                            dataList.Add(splitValues[0]);
                            dataList.Add(splitValues[1]);
                        }
                        else
                        {
                            dataList.Add(string.Empty);
                            dataList.Add(string.Empty);
                        }
                    }
                    else
                    {
                        dataList.Add(bodyItem.val);
                    }
                }
                data.Rows.Add(dataList.ToArray());
            }
            return data;
        }

        /// <summary>
        /// 取込データ詳細情報がデータテーブルに変換する
        /// </summary>
        public static DataTable GetPageItemDetailDtByDtl(DataTable temptableData, Dictionary<string, int>? wktableDic)
        {
            var data = new DataTable();
            var oldRowNo = 0;
            var itemvalues = new List<string?>();
            for (int i = 0; i < temptableData.Rows.Count; i++)
            {
                var row = temptableData.Rows[i];
                foreach (DataColumn column in temptableData.Columns)
                {
                    if (wktableDic != null && wktableDic.TryGetValue(column.ColumnName, out var value))
                    {
                        if (i == 0) data.Columns.Add("Column" + value);
                        if (oldRowNo != 0 && oldRowNo != CInt(row["rowno"]))
                        {
                            data.Rows.Add(itemvalues.ToArray());
                            itemvalues = new List<string?>();
                        }
                        itemvalues.Add(CStr(row[column]));
                        oldRowNo = CInt(row["rowno"]);
                    }
                }

            }
            if (itemvalues.Count > 0)
            {
                data.Rows.Add(itemvalues.ToArray());
            }

            return data;
        }

        /// <summary>
        /// 取込データ詳細情報を取得する(更新用)
        /// </summary>
        public static List<tt_kktorinyuryoku_misyoriitemDto> GetKkimpDataDetailUptDtl(int impexeid, List<KimpDetailRowVM> detailList, Dictionary<int, string> itemDic)
        {
            var dtl = new List<tt_kktorinyuryoku_misyoriitemDto>();
            foreach (KimpDetailRowVM vm in detailList)
            {
                int colIndex = 0;
                foreach (PageItemBodyModel model in vm.PageItemBodyList)
                {
                    var dto = new tt_kktorinyuryoku_misyoriitemDto
                    {
                        impjikkoid = impexeid,              //取込実行ID
                        dataseq = model.dataseq,            //データID
                        rowno = vm.rowno,                   //行番号
                        colno = colIndex,                   //列番号
                        itemseq = model.pageitemseq,        //項目ID
                        itemnm = itemDic.ContainsKey(colIndex) ? itemDic[model.pageitemseq] : string.Empty, //項目名
                        itemvalue = model.val ?? string.Empty   //項目値
                    };
                    dtl.Add(dto);
                    colIndex++;
                }
            }

            return dtl;
        }

        /// <summary>
        /// 取込データ詳細情報を取得する(仮保存 新規用)
        /// </summary>
        public static List<tt_kktorinyuryoku_misyoriitemDto> GetKkimpDataDetailAddDtl(int impexeid, int dataseq, List<KimpDetailRowVM> detailList, Dictionary<int, string> itemDic)
        {
            var dtl = new List<tt_kktorinyuryoku_misyoriitemDto>();
            foreach (KimpDetailRowVM vm in detailList)
            {
                int colIndex = 0;
                foreach (PageItemBodyModel model in vm.PageItemBodyList)
                {
                    var dto = new tt_kktorinyuryoku_misyoriitemDto
                    {
                        impjikkoid = impexeid,              //取込実行ID
                        dataseq = dataseq,                  //データID
                        rowno = vm.rowno,                   //行番号
                        colno = colIndex,                   //列番号
                        itemseq = model.pageitemseq,        //項目ID
                        itemnm = itemDic.ContainsKey(model.pageitemseq) ? itemDic[model.pageitemseq] : string.Empty,    //項目名
                        itemvalue = model.val ?? string.Empty   //項目値
                    };
                    dtl.Add(dto);
                    colIndex++;
                    dataseq++;
                }
            }

            return dtl;
        }

        /// <summary>
        /// 一括取込入力未処理テーブル(新規用)
        /// </summary>
        public static tt_kktorinyuryoku_misyoriDto GetKkimpDataDto(DaDbContext db, string impno, string userid,
                                                DaFileModel? file, string? filetype, int? fileRowCnt, int totalcnt, int errcnt)
        {
            DateTime dttm = DaUtil.Now;

            var kimpDataDto = new tt_kktorinyuryoku_misyoriDto();
            kimpDataDto.torinyuryokuno = impno;                     //一括取込入力No
            if (file != null)
            {
                kimpDataDto.filenm = file.filenm;           //ファイル名
                kimpDataDto.filedata = file.filedata;       //ファイル
            }
            if (filetype != null)
            {
                kimpDataDto.filetype = CInt(DaNameService.GetKbn1(db, EnumNmKbn.ファイル形式, filetype));//ファイルタイプ
            }
            kimpDataDto.filegokeirow = fileRowCnt;          //ファイル総行数
            kimpDataDto.totalcnt = totalcnt;                //件数
            kimpDataDto.errcnt = errcnt;                    //エラー件数
            kimpDataDto.reguserid = userid;                 //登録ユーザーID
            kimpDataDto.regdttm = dttm;                     //登録日時
            kimpDataDto.upduserid = userid;                 //更新ユーザーID
            kimpDataDto.upddttm = dttm;                     //更新日時
            return kimpDataDto;
        }

        /// <summary>
        /// 取込履歴情報を取得する
        /// </summary>
        public static tt_kktorinyuryoku_rirekiDto GeKkimpHistoryDto(SaveRequest req, tm_kktorinyuryokuDto kkimpDto, tt_kktorinyuryoku_misyoriDto kkimpdataDto)
        {
            //一括取込入力履歴テーブル
            var tt_KkimphistoryDto = new tt_kktorinyuryoku_rirekiDto
            {
                gyomukbn = kkimpDto.gyomukbn,                            //業務区分
                torinyuryokunm = kkimpDto.torinyuryokunm,                                  //一括取込入力名
                torinyuryokbn = kkimpDto.torinyuryokbn,                                //一括取込入力区分
                filenm = kkimpdataDto.filenm,                            //ファイル名
                filetype = CInt(kkimpdataDto.filetype),    //ファイルタイプ
                filedata = kkimpdataDto.filedata,                        //ファイルデータ
                torokucnt = kkimpdataDto.totalcnt - kkimpdataDto.errcnt, //登録件数
                errcnt = kkimpdataDto.errcnt,                            //エラー件数
                reguserid = req.userid,                                  //登録ユーザーID
                regdttm = DaUtil.Now                                     //登録日時
            };

            return tt_KkimphistoryDto;
        }

        /// <summary>
        /// 取込データ詳細情報を取得する
        /// </summary>
        public static void SetKkimpDataDetailDt(int impexeid, List<ImEditDataRow> editDataList, ref DataTable dt)
        {
            foreach (ImEditDataRow editDataRow in editDataList)
            {
                DataRow row = dt.NewRow();
                row[nameof(tt_kktorinyuryoku_misyoriitemDto.impjikkoid)] = impexeid;                  //取込実行ID
                row[nameof(tt_kktorinyuryoku_misyoriitemDto.dataseq)] = editDataRow.dataseq;          //データID
                row[nameof(tt_kktorinyuryoku_misyoriitemDto.rowno)] = editDataRow.rowno;              //行番号
                row[nameof(tt_kktorinyuryoku_misyoriitemDto.colno)] = editDataRow.colno;              //列番号
                row[nameof(tt_kktorinyuryoku_misyoriitemDto.itemseq)] = editDataRow.pageitemseq;      //項目ID
                row[nameof(tt_kktorinyuryoku_misyoriitemDto.itemnm)] = editDataRow.itemnm;            //項目名
                row[nameof(tt_kktorinyuryoku_misyoriitemDto.itemvalue)] = editDataRow.val;            //項目値

                dt.Rows.Add(row);
            }
        }

        /// <summary>
        /// 取込エラーデータを取得する
        /// </summary>
        public static List<tt_kktorinyuryoku_errDto> GetKkimpDataErrDtl(int impexeid, List<ImEditErrorRow> EditErrList)
        {
            var detailList = new List<tt_kktorinyuryoku_errDto>();
            int errseq = 0;
            foreach (ImEditErrorRow editErrorRow in EditErrList)
            {
                var dto = new tt_kktorinyuryoku_errDto
                {
                    impjikkoid = impexeid,              //取込実行ID
                    errseq = ++errseq,                  //エラーID
                    dataseq = editErrorRow.dataseq,     //データID
                    rowno = editErrorRow.rowno,         //行番号
                    atenano = editErrorRow.atenano,     //宛名番号
                    simei = editErrorRow.shimei,        //氏名
                    itemnm = editErrorRow.itemnm,       //項目名
                    itemvalue = editErrorRow.itemvalue, //項目値
                    msg = editErrorRow.msg,             //メッセージ
                    errkbn = editErrorRow.errkbn        //エラー区分
                };

                detailList.Add(dto);
            }
            return detailList;
        }
    }
}