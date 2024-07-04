// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行.ファイルアップロード
// 　　　　　　サービス処理
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using AIplus.AiImporter;
using BCC.Affect.Service.CheckImporter;
using BCC.Affect.Service.Common;
using Microsoft.VisualBasic;
using NPOI.SS.UserModel;
using System.Text;
using System.Text.RegularExpressions;
using Ude;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;
using EnumMessage = BCC.Affect.DataAccess.EnumMessage;

namespace BCC.Affect.Service.AWKK00702D
{
    [DisplayName("取込実行")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00702D = "AWKK00702D";

        [DisplayName("アップロードチェック処理(実行)")]
        public ExcelUploadResponse ExcelUploadCheck(UploadRequest req)
        {
            //※プログレスバーをセットする
            AiProgress.SetProgress(req.processKey, ImportProcess.FileCheck, 0);

            return Transction(req, (DaDbContext db) =>
            {
                var res = new ExcelUploadResponse();

                //リスト取得
                List<DaFileModel> files = req.files;
                //データ加工処理
                if (files.Count >= 0)
                {
                    //ファイル情報
                    DaFileModel file = files[0];

                    //一括取込入力No
                    string impno = req.impno;
                    //取込基本情報マスタ
                    var kimpInfo = db.tm_kktori_kihon.GetDtoByKey(impno);

                    //ファイル基本情報チェック
                    string msg = CheckFileInfo(db, file, kimpInfo);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        //エラーメッセージ設定
                        res.SetServiceError(msg);
                        //正常返し
                        return res;
                    }

                    //エンコード
                    var fileencode = DaNameService.GetKbn1(db, EnumNmKbn.エンコード, kimpInfo.fileencode);
                    //ファイルエンコードを取得する
                    var encoding = GetFileEncoding(file.filedata);
                    //エンコードチェック
                    if (encoding == null || encoding == Encoding.GetEncoding("ASCII"))
                    {
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                        if (ParseEnum<Enumエンコード>(kimpInfo.fileencode) == Enumエンコード.SJIS)
                        {
                            encoding = Encoding.GetEncoding("Shift_JIS");
                        }
                        else
                        {
                            encoding = Encoding.GetEncoding("UTF-8");
                        }
                    }
                    else if (!encoding.WebName.ToUpper().Contains(fileencode.ToUpper()))
                    {
                        //エラーメッセージ設定
                        res.SetServiceError(DaMessageService.GetMsg(EnumMessage.E003006, "エンコード"));
                        //正常返し
                        return res;
                    }

                    //取込設定アップロードエラーリスト
                    var errList = new List<ImFileErrorRow>();
                    //ファイルデータ
                    var importDataList = new List<string[]>();
                    if (kimpInfo.datakeisiki.Equals(EnumToStr(Enumデータ形式.可変長)))
                    {
                        //ファイルを読み込む(可変長の場合)
                        importDataList = GetFileData(kimpInfo, file.filedata, encoding);
                    }
                    else
                    {
                        //ファイルデータを取得(固定長の場合)
                        List<string> fileDataList = GetFixLenFileData(file.filedata, kimpInfo, encoding);
                        if (fileDataList.Count > 0)
                        {
                            //ファイルデータを加工処理(固定長の場合)
                            importDataList = GetImportDataList(db, fileDataList, kimpInfo, ref errList);
                        }
                    }

                    if (importDataList.Count == 0)
                    {
                        //エラーメッセージ設定
                        res.SetServiceError(DaMessageService.GetMsg(EnumMessage.E004006, "該当データ", "指定したファイル"));
                        //正常返し
                        return res;
                    }

                    //取込IFマスタ
                    List<tm_kktori_interfaceDto> kkimpfileifDtl = db.tm_kktori_interface.SELECT.WHERE.ByKey(impno).ORDER.By(nameof(tm_kktori_interfaceDto.fileitemseq)).GetDtoList();

                    //ファイルデータテーブル取得
                    DataTable filedata = GetFileDataToTable(kimpInfo, kkimpfileifDtl.Count, importDataList, ref errList);

                    //※プログレスバーをセットする
                    AiProgress.SetProgress(req.processKey, ImportProcess.FileCheck, 5);

                    //ファイルデータが取得できる場合
                    if (filedata.Rows.Count > 0)
                    {
                        //データテーブルに変換
                        var editDt = new DataTable();

                        //ファイルデータチェックしてインポート
                        var result = CheckImportData(db, req, kkimpfileifDtl, filedata, ref errList, ref editDt);
                        if (result.Success)
                        {
                            //ファイルチェックエラーあり場合
                            if (result.FileErrorList.Count > 0)
                            {
                                //ファイルチェックエラー
                                errList = result.FileErrorList;
                            }
                            else
                            {
                                //ファイル行数
                                var fileRowCnt = importDataList.Count;

                                //取込データ登録して、取込実行IDを取得
                                res.impexeid = SaveKimpData(db, req, result, file, fileRowCnt, kimpInfo);

                                //※プログレスバーをセットする
                                AiProgress.SetProgress(req.processKey, ImportProcess.PageItemCheck, 95);

                                //チェックプロシージャありの場合
                                if (result.EditErrorList.Count == 0)
                                {
                                    //一括取込入力マスタ
                                    tm_kktorinyuryokuDto tm_kkimpDto = AWKK00701G.Service.GetKkimpDto(db, impno);

                                    //チェックプロシージャ名がありの場合
                                    if (!string.IsNullOrEmpty(tm_kkimpDto.proccheck))
                                    {
                                        //一括取込入力マスタデータを取得する
                                        tm_kktorinyuryokuDto kkimpDto = AWKK00701G.Service.GetKkimpDto(db, impno);

                                        //一括取込入力項目定義マスタ
                                        List<tm_kktorinyuryoku_itemDto> pageitemDtl = AWKK00701G.Service.GetPageItemDtl(db, impno);
                                        //一時テーブルデータ用のデータテーブルを取得
                                        var dt = AWKK00701G.Service.GetDataTable(db, res.impexeid, kkimpDto, pageitemDtl, null);
                                        //チェックプロシージャ
                                        msg = new AWKK00701G.Service().DoCheckProc(db, tm_kkimpDto.proccheck, res.impexeid, dt, impno);
                                        if (!string.IsNullOrEmpty(msg))
                                        {
                                            res.SetServiceError(msg);
                                            return res;
                                        }
                                    }
                                }
                                //※プログレスバーをセットする
                                AiProgress.SetProgress(req.processKey, ImportProcess.PageItemCheck, 100);
                            }
                        }
                        else
                        {
                            msg = result.ErrMsg;
                            if (string.IsNullOrEmpty(msg))
                            {
                                msg = DaMessageService.GetMsg(EnumMessage.E004007, "取込アップロード");
                            }
                            res.SetServiceError(msg);
                            return res;
                        }
                    }

                    //ファイルエラーありの場合
                    if (errList.Count > 0)
                    {
                        res = new ExcelUploadResponse();
                        //出力エラーファイルデータを取得する
                        res.errorbytebuffer = GetErrorData(errList);

                        //※プログレスバーをセットする
                        AiProgress.SetProgress(req.processKey, ImportProcess.FileCheck, 100);
                    }
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("エラー出力処理")]
        public CmDownloadResponseBase ErrorDownload(ErrorDownloadRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new CmDownloadResponseBase();
                //出力ファイル名
                var fileName = $"ファイル取込エラー_{DaUtil.Now.ToString("yyyyMMddhhmmss")}";
                //単一ファイルのダウンロード応答を取得
                res = CmDownloadService.GetDownloadResponse(new DaFileModel(fileName, ".xlsx", req.errorbytebuffer));
                //正常返し
                return res;
            });
        }

        /// <summary>
        /// ファイル基本情報チェック
        /// </summary>
        private string CheckFileInfo(DaDbContext db, DaFileModel file, tm_kktori_kihonDto kimpInfo)
        {
            //メッセージ返し
            string msg = string.Empty;

            //ファイル形式
            var filetype = DaNameService.GetShortName(db, EnumNmKbn.ファイル形式, kimpInfo.filekeisiki);
            //ファイル形式：設定した内容と一致
            if (!filetype.Equals(file.filetype[1..]))
            {
                msg = DaMessageService.GetMsg(EnumMessage.E003006, "ファイル形式（拡張子）");
                return msg;
            }

            //正規表現フラグ
            if (!kimpInfo.seikihyogen)
            {
                //設定されたファイル名
                if (!string.IsNullOrEmpty(kimpInfo.filenm) && !kimpInfo.filenm.Equals(file.filenm))
                {
                    msg = DaMessageService.GetMsg(EnumMessage.E003008, "ファイル名", $"設定されたファイル名({kimpInfo.filenm})");
                    return msg;
                }
            }
            else
            {
                //設定された正規表現
                Regex obj = new Regex(kimpInfo.filenm!);
                if (!obj.IsMatch(kimpInfo.filenm!))
                {
                    msg = DaMessageService.GetMsg(EnumMessage.E003008, "ファイル名", $"設定された正規表現({kimpInfo.filenm})");
                    return msg;
                }
            }
            return msg;
        }

        /// <summary>
        /// ファイルデータを取得する(可変長の場合)
        /// </summary>
        private List<string[]> GetFileData(tm_kktori_kihonDto kimpInfo, byte[] filedata, Encoding encoding)
        {
            //区切り記号を取得
            int divideChar = GetDivideChar(kimpInfo.kugirikigo!);
            //引用符
            bool isQuote = !kimpInfo.inyofusonzaikbn!.Equals(引用符_CSV出力用._0);
            //ファイルを読み込む
            List<string[]> importDataList = ImFileUtil.ReadFileData(filedata, encoding, divideChar, isQuote);

            if (importDataList.Count > 0)
            {
                //ヘッダー行数、フッター行数除去
                int itemsToTake = Math.Max(0, importDataList.Count - kimpInfo.headerrows - kimpInfo.footerrows);
                importDataList = importDataList.Skip(kimpInfo.headerrows).Take(itemsToTake).ToList();
            }

            return importDataList;
        }

        /// <summary>
        /// ファイルデータテーブルを取得する
        /// </summary>
        private DataTable GetFileDataToTable(tm_kktori_kihonDto kimpInfo, int itemCount, List<string[]> importDataList, ref List<ImFileErrorRow> errList)
        {
            var data = new DataTable();
            if (data.Columns.Count == 0)
            {
                //項目数+1(行番号列も追加)
                for (int i = 0; i < itemCount + 1; i++)
                {
                    data.Columns.Add("Column" + i);
                }
            }

            //基本情報チェック
            for (int rowIndex = 0; rowIndex < importDataList.Count; rowIndex++)
            {
                var splData = importDataList[rowIndex];

                //行番号
                int rowNo = rowIndex + 1;

                if (errList.Exists(e => e.RowNo == rowNo))
                {
                    continue;
                }

                ImFileErrorRow? errorRow = null;

                //項目数
                if (!itemCount.Equals(splData.Length))
                {
                    errorRow = new ImFileErrorRow(rowNo, "項目数", splData.Length.ToString(), EnumMessage.E003006, "項目数");
                    AddError(ref errList, errorRow);
                }

                if (errorRow == null)
                {
                    var dataList = new List<object>();
                    dataList.Add(rowNo);        //行番号
                    dataList.AddRange(splData); //行データ
                    data.Rows.Add(dataList.ToArray());
                }
            }

            return data;
        }

        /// <summary>
        /// ファイルデータチェックしてインポート
        /// </summary>
        private ImCheckResult CheckImportData(DaDbContext db, UploadRequest req, List<tm_kktori_interfaceDto> kkimpfileifDtl, DataTable filedata,
            ref List<ImFileErrorRow> errList, ref DataTable editDt)
        {
            //一括取込入力No
            string impno = req.impno;

            //ファイル項目IDリスト
            List<int> fileitemseqList = kkimpfileifDtl.Select(e => e.fileitemseq).ToList();
            //行番号列名
            filedata.Columns[0].ColumnName = "RowNo";
            for (int i = 1; i < filedata.Columns.Count; i++)
            {
                //列名がファイル項目IDでセットする
                filedata.Columns[i].ColumnName = fileitemseqList[i - 1].ToString();

            }

            //一括取込入力項目定義マスタ
            List<tm_kktorinyuryoku_itemDto> kkimppageitemDtl = AWKK00701G.Service.GetPageItemDtl(db, impno);
            //取込項目マッピングマスタ
            List<tm_kktori_mappingDto> kkimpitemmappingDtl = db.tm_kktori_mapping.SELECT.WHERE.ByKey(impno).ORDER.By(nameof(tm_kktori_mappingDto.gamenitemseq)).GetDtoList();

            var imDef = new ImDef();
            //ファイルIF項目を取得する
            imDef.FileColumns = Wraper.GetFileifDataList(kkimpfileifDtl);
            //マッピング項目を取得する
            imDef.TransferColumns = Wraper.GetMappingDataList(kkimpitemmappingDtl, kkimppageitemDtl);
            //マッピング項目を取得する
            imDef.TransferColumns = imDef.TransferColumns.OrderBy(a => kkimppageitemDtl.FindIndex(b => b.gamenitemseq == a.pageitemseq)).ToList();

            var option = new ImCheckOption();
            //処理キー
            option.ProcessKey = req.processKey;

            //一括取込入力マスタ
            tm_kktorinyuryokuDto tm_kkimpDto = AWKK00701G.Service.GetKkimpDto(db, impno);

            //チェックデータを取得する
            AWKK00701G.Service.GetCheckEditData(db, tm_kkimpDto, ref imDef, ref option);
            //ファイルデータからインポート
            var result = CheckImporter.CheckImporter.ImportFromFile(db, filedata, imDef, option, errList);

            if (result.Success)
            {
                //データテーブルに変換
                editDt = GetDataTable(result.EditDataList);

                //特定項目-実施年齢
                var isHasJissiAge = kkimppageitemDtl.Exists(d => !string.IsNullOrEmpty(d.itemtokuteikbn) && (d.itemtokuteikbn.Equals(EnumToStr(Enum項目特定区分.実施年齢_一次_申込))
                                                                || d.itemtokuteikbn.Equals(EnumToStr(Enum項目特定区分.実施年齢_精密_結果))));
                if (isHasJissiAge)
                {
                    //明細データから取得した特定項目値を取得
                    var editRowTokuteDataList = AWKK00701G.Service.GetTokuteItemValue(db, editDt, kkimppageitemDtl);
                    //画面特定項目値をセット
                    SetEditDataList(result.EditDataList, editDt, editRowTokuteDataList, kkimppageitemDtl);
                }
            }

            return result;
        }

        /// <summary>
        /// 画面特定項目値をセット
        /// </summary>
        private void SetEditDataList(List<ImEditDataRow> editDataList, DataTable editDt, List<ImEditorRowDef> editRowTokuteDataList, List<tm_kktorinyuryoku_itemDto> kkimppageitemDtl)
        {
            //設定した画面項目--実施年齢
            int? agePageItemSeq = AWKK00701G.Service.GetPageItemSeq(kkimppageitemDtl, EnumToStr(Enum項目特定区分.実施年齢_一次_申込));
            //設定した画面項目--実施年齢(精密)
            int? seiAgePageItemSeq = AWKK00701G.Service.GetPageItemSeq(kkimppageitemDtl, EnumToStr(Enum項目特定区分.実施年齢_精密_結果));

            foreach (var data in editRowTokuteDataList)
            {
                //実施年齢
                if (agePageItemSeq != null)
                {
                    var item = editDataList.Find(e => e.rowno == data.RowIndex + 1 && e.pageitemseq == agePageItemSeq);
                    if (item != null)
                        item.val = CStr(data.JissiAge);

                    if (editDt.Columns.Contains("Column" + agePageItemSeq))
                    {
                        editDt.Rows[data.RowIndex]["Column" + agePageItemSeq] = CStr(data.JissiAge);
                    }
                }
                //実施年齢(精密)
                if (seiAgePageItemSeq != null)
                {
                    var item = editDataList.Find(e => e.rowno == data.RowIndex + 1 && e.pageitemseq == seiAgePageItemSeq);
                    if (item != null)
                        item.val = CStr(data.SeiJissiAge);

                    if (editDt.Columns.Contains("Column" + seiAgePageItemSeq))
                    {
                        editDt.Rows[data.RowIndex]["Column" + seiAgePageItemSeq] = CStr(data.SeiJissiAge);
                    }
                }
            }
        }

        /// <summary>
        /// 取込データ登録
        /// </summary>
        private int SaveKimpData(DaDbContext db, UploadRequest req, ImCheckResult result, DaFileModel file, int fileRowCnt, tm_kktori_kihonDto kimpInfo)
        {
            //エラー件数
            int errcnt = 0;
            if (result.EditErrorList.Count > 0)
            {
                //エラー件数
                errcnt = result.EditErrorList.Select(e => e.rowno).Distinct().Count();
            }
            //一括取込入力未処理テーブルのデータを取得する
            tt_kktorinyuryoku_misyoriDto kimpDataDto = AWKK00701G.Converter.GetKkimpDataDto(db, req.impno, req.userid, file, kimpInfo.filekeisiki,
                                                                            fileRowCnt, fileRowCnt, errcnt);

            //取込実行ID手動採番MAX+1
            kimpDataDto.impjikkoid = db.tt_kktorinyuryoku_misyori.SELECT.GetMax<int>(nameof(tt_kktorinyuryoku_misyoriDto.impjikkoid)) + 1;

            //①　一括取込入力未処理テーブルデータ登録
            db.tt_kktorinyuryoku_misyori.INSERT.Execute(kimpDataDto);

            //取込実行ID
            int impexeid = kimpDataDto.impjikkoid;

            //②一括取込入力未処理項目テーブル登録
            AWKK00701G.Service.SaveKkimpDetailData(db, impexeid, result.EditDataList, req.processKey);

            if (errcnt > 0)
            {
                //③一括取込入力エラーテーブル登録
                AWKK00701G.Service.SaveKkimpErrorData(db, impexeid, result.EditErrorList);
            }
            //取込実行ID
            return impexeid;
        }

        /// <summary>
        /// 出力エラーファイルデータを取得する
        /// </summary>
        private byte[] GetErrorData(List<ImFileErrorRow> errList)
        {

            //一時出力エラーファイル名取得
            var errTempFileName = Path.GetTempFileName();
            var excelReprot = new ExcelLogger();

            //エラーファイル出力
            //定数定義
            var sheetName = "エラー一覧";
            var sStr0 = "No,行,項目名（タイトル名）,項目値,エラー内容";
            var bOpen = excelReprot.Open(errTempFileName, sheetName, true);
            ICellStyle headStyle = excelReprot.CreateHeadStyle();
            ICellStyle bodyStyle = excelReprot.CreateBodyStyle();
            var rowIndex = 0; var colIndex = 0;
            //ヘッダー
            var sArr = sStr0.Split(",");
            for (colIndex = 0; colIndex < sArr.Length; colIndex++)
            {
                excelReprot.WriteCell(headStyle, colIndex, rowIndex, sArr[colIndex], true, true);
            }
            rowIndex = 1;
            errList = errList.OrderBy(x => x.RowNo).ToList();
            //明細行
            for (int i = 0; i < errList.Count; i++)
            {
                colIndex = 0;
                excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, i + 1);                  //No
                excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, errList[i].RowNo);       //行
                excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, errList[i].Title);       //項目名（タイトル名）
                excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, errList[i].ItemValue);   //項目値
                excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, errList[i].Msg);         //エラー内容
                rowIndex++;
            }
            excelReprot.Close();

            //Excelファイルからbyte[]に変換
            var fileName = errTempFileName + ".xlsx";
            var fs = File.OpenRead(fileName);
            byte[] bytebuffer = new byte[fs.Length];
            fs.Read(bytebuffer, 0, (int)fs.Length);
            fs.Close();

            File.Delete(errTempFileName); File.Delete(errTempFileName + ".xlsx");

            //エラーデータ
            return bytebuffer;

        }

        /// <summary>
        /// ファイルエンコードを取得する
        /// </summary>
        private Encoding? GetFileEncoding(byte[] fileData)
        {
            byte[] byteArray = fileData;
            var cdet = new CharsetDetector();
            cdet.Feed(byteArray, 0, byteArray.Length);
            cdet.DataEnd();
            if (cdet.Charset != null)
            {
                var encoding = Encoding.GetEncoding(cdet.Charset);
                return encoding;
            }
            return null;
        }

        /// <summary>
        /// 区切り記号を取得
        /// </summary>
        private int GetDivideChar(string dividekbn)
        {
            int divideChar;
            if (dividekbn.Equals(EnumToStr(Enum区切り記号.カンマ)))
            {
                //カンマ
                divideChar = Convert.ToInt32(',');
            }
            else
            {
                //タブ
                divideChar = Convert.ToInt32('\t');
            }
            return divideChar;
        }

        /// <summary>
        /// ファイルデータを取得(固定長の場合)
        /// </summary>
        private List<string> GetFixLenFileData(byte[] filedata, tm_kktori_kihonDto kimpInfo, Encoding targetEncoding)
        {
            var dataList = new List<string>();
            var stream = new MemoryStream(filedata);
            using (var sr = new StreamReader(stream, targetEncoding))
            {
                var strCsvData = sr.ReadToEnd();
                strCsvData = strCsvData.Replace(Constants.vbCrLf, Constants.vbLf);
                strCsvData = strCsvData.Replace(Constants.vbCr, Constants.vbLf);

                var splCsvData = Strings.Split(strCsvData, Constants.vbLf);
                dataList = new List<string>();

                var loopTo = splCsvData.Length;
                for (int rowCount = 0; rowCount < loopTo; rowCount++)
                {
                    var rowData = splCsvData[rowCount];
                    dataList.Add(rowData);
                }
            }

            //ヘッダー行数、フッター行数除去
            if (dataList.Count > 0)
            {
                int itemsToTake = Math.Max(0, dataList.Count - kimpInfo.headerrows - kimpInfo.footerrows);
                dataList = dataList.Skip(kimpInfo.headerrows).Take(itemsToTake).ToList();
            }

            return dataList;
        }

        /// <summary>
        /// ファイルデータを加工処理(固定長の場合)
        /// </summary>
        private List<string[]> GetImportDataList(DaDbContext db, List<string> fileDataList, tm_kktori_kihonDto kimpInfo, ref List<ImFileErrorRow> errList)
        {
            var importDataList = new List<string[]>();

            //取込IFマスタ
            List<tm_kktori_interfaceDto> kkimpfileifDtl = db.tm_kktori_interface.SELECT.WHERE.ByKey(kimpInfo.torinyuryokuno).ORDER.By(nameof(tm_kktori_interfaceDto.fileitemseq)).GetDtoList();

            for (int rowIndex = 0; rowIndex < fileDataList.Count; rowIndex++)
            {
                var inputString = fileDataList[rowIndex];
                //全長
                var totalLength = inputString.Length;
                //レコード長チェック
                if (totalLength != kimpInfo.recordlen)
                {
                    var errorRow = new ImFileErrorRow(rowIndex + 1, "レコード長", totalLength.ToString(), EnumMessage.E003006, "レコード長");
                    AddError(ref errList, errorRow);
                    importDataList.Add(Array.Empty<string>());
                }
                else
                {
                    var substrings = new List<string>();
                    int startIndex = 0;
                    foreach (var dto in kkimpfileifDtl)
                    {
                        int length = dto.ketasu;
                        //桁数（小数部）ありの場合
                        if (dto.syosuketasu != null)
                        {
                            length = dto.ketasu + CInt(dto.syosuketasu) + 1;
                        }
                        if (startIndex + length > totalLength)
                        {
                            substrings.Add(inputString.Substring(startIndex).Trim());
                            break;
                        }

                        substrings.Add(inputString.Substring(startIndex, length).Trim());
                        startIndex += length;
                    }

                    importDataList.Add(substrings.ToArray());
                }
            }
            return importDataList;
        }

        /// <summary>
        /// エラーを追加
        /// </summary>
        private void AddError(ref List<ImFileErrorRow> errList, ImFileErrorRow error)
        {
            if (errList.Count > DaConst.MAX_ERRORS)
            {
                throw new ImErrorOverExcetion();
            }
            errList.Add(error);
        }

        /// <summary>
        /// データテーブルに変換
        /// </summary>
        private DataTable GetDataTable(List<ImEditDataRow> EditDataList)
        {
            var dt = new DataTable();

            var data = new DataTable();
            var detailList = EditDataList.OrderBy(e => e.rowno).ThenBy(e => e.dataseq).ToList();
            List<int> pageitemseqList = detailList.Select(e => e.pageitemseq).Distinct().ToList();
            data.Columns.Add("RowNo");
            for (var i = 0; i < pageitemseqList.Count; i++)
            {
                //データテーブル列名
                data.Columns.Add("Column" + pageitemseqList[i]);
            }

            var oldRowNo = 0;
            var itemvalues = new List<string?>();
            for (var i = 0; i < detailList.Count; i++)
            {
                var dto = detailList[i];

                if (i == 0)
                {
                    itemvalues.Insert(0, CStr(dto.rowno));
                }

                if (oldRowNo != 0 && oldRowNo != dto.rowno)
                {
                    data.Rows.Add(itemvalues.ToArray());
                    itemvalues = new List<string?>();
                    itemvalues.Insert(0, CStr(dto.rowno));
                }

                itemvalues.Add(dto.val);

                oldRowNo = dto.rowno;

                if (i == detailList.Count - 1)
                {
                    data.Rows.Add(itemvalues.ToArray());
                }
            }

            return data;
        }
    }
}