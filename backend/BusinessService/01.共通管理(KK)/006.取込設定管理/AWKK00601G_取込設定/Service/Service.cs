// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定
// 　　　　　　サービス処理
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.CheckImporter;
using BCC.Affect.Service.Common;
using NPOI.SS.UserModel;
using System.Text.RegularExpressions;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00601G
{
    [DisplayName("取込設定")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00601G = "AWKK00601G";

        //検索処理(一覧画面)
        private const string PROC_NAME1 = "sp_awkk00601g_01";

        //シート名
        private const string SHEET_NAME_HEAD = "メイン情報";
        private const string SHEET_NAME_FILEINFO = "基本情報";
        private const string SHEET_NAME_FILEIF = "ファイルIF";
        private const string SHEET_NAME_CHANGECODE_MAIN = "変換コードメイン";
        private const string SHEET_NAME_PAGEITEM = "項目定義";
        private const string SHEET_NAME_CHANGECODE = "変換コード";
        private const string SHEET_NAME_ITEMMAP = "マッピング設定";
        private const string SHEET_NAME_INSERT = "登録仕様";

        //シートNo
        private const int SHEET_NO_HEAD = 1;             //メイン情報
        private const int SHEET_NO_FILEINFO = 2;         //基本情報
        private const int SHEET_NO_FILEIF = 3;           //ファイルIF
        private const int SHEET_NO_CHANGECODE_MAIN = 4;  //変換コードメイン
        private const int SHEET_NO_PAGEITEM = 5;         //項目定義
        private const int SHEET_NO_CHANGECODE = 6;       //変換コード
        private const int SHEET_NO_ITEMMAP = 7;          //マッピング設定
        private const int SHEET_NO_INSERT = 8;           //登録仕様

        //明細行のスタートインデックス
        private const int START_ROW_INDEX_HEAD = 2;             //メイン情報
        private const int START_ROW_INDEX_FILEINFO = 2;         //基本情報
        private const int START_ROW_INDEX_FILEIF = 5;           //ファイルIF
        private const int START_ROW_INDEX_CHANGECODE_MAIN = 5;  //変換コードメイン
        private const int START_ROW_INDEX_PAGEITEM = 5;         //項目定義
        private const int START_ROW_INDEX_CHANGECODE = 5;       //変換コード
        private const int START_ROW_INDEX_ITEMMAP = 5;          //マッピング設定
        private const int START_ROW_INDEX_INSERT = 5;           //登録仕様

        private const string MEISYO_TABLE_NAME = "名称マスタ";
        private const string HANYO_TABLE_NAME = "汎用マスタ";
        private const string TM_KKIMPCODEHENKANMAIN_TABLE_NAME = "一括取込入力変換コードメインマスタ";
        private const string TM_KKIMPTABLE_TABLE_NAME = "一括取込入力テーブルマスタ";

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------

                //業務のドロップダウンリストの初期化データ
                res.gyoumuSelectorList = GetNameSelectorList(db, EnumNmKbn.取込業務区分);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(一覧画面)")]
        public SearchListResponse Search(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = Converter.GetParameters(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME1, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //汎用取込設定情報一覧
                res.kekkaList = Wraper.GetVMList(db, pageList.dataTable.Rows);

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

                //初期化処理データをセットする
                //①アップロード後遷移の場合
                if (req.isUpload)
                {
                    //初期化処理詳細データをセットする(アップロード後遷移の場合)
                    SetIniDetailDataByUpload(db, req, res);
                }
                //②一覧画面に選択した行で遷移の場合
                else
                {
                    if (req.editkbn == Enum編集区分.新規)
                    {
                        //初期化処理データをセットする(新規)
                        SetInitDetailAddData(db, res);
                    }
                    else
                    {
                        //初期化処理詳細データをセットする(更新)
                        SetInitDetailUpdateData(db, req.impno, res);
                    }
                }

                //ヘッダのドロップダウンリストの初期化データをセットする
                SetInitDetailHeadSelectorData(db, res);

                //ボディーのドロップダウンリストの初期化データをセットする
                SetInitDetailBodySelectorData(db, req, res, res.hearderData);

                //正常返し
                return res;
            });
        }

        [DisplayName("登録項目設定情報：明細一覧初期化処理（ヘッダーテーブル変更時）(詳細画面)")]
        public InitTableFieldResponse IniTableFieldList(InitTableFieldRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitTableFieldResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //テーブルの登録項目設定情報を取得する
                res.insertVM = GetTableFieldList(db, req.tableid);

                //正常返し
                return res;
            });
        }

        [DisplayName("変換コード情報：【本システムコード】ドロップダウン初期化処理(【変換区分】変更時）(詳細画面)")]
        public InitSystemCodeResponse InitSysCodeList(InitSystemCodeRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitSystemCodeResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //【本システムコード】のドロップダウンリストを取得する
                res.systemcodeList = GetSysCodeList(db, req.changeCodeMainData);

                //正常返し
                return res;
            });
        }

        [DisplayName("ヘッダー情報：「並び順」重複エラーチェック(詳細画面)")]
        public DaResponseBase CheckOrderSeq(CheckOrderSeqRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();

                //「並び順」重複エラーチェック
                var msg = CheckOrderseqMsg(db, req.gyoumukbn, req.impkbn, req.orderseq, req.impno);
                if (!string.IsNullOrEmpty(msg))
                {
                    //一括取込入力Noが重複しています。
                    res.SetServiceError(msg);
                    return res;
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("登録処理")]
        public SaveDetailResponse Save(SaveDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new SaveDetailResponse();

                //一括取込入力No
                string impno = req.hearderData.impno;

                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                var msg = Check(db, req, impno);
                if (!string.IsNullOrEmpty(msg))
                {
                    res.SetServiceError(msg);
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                var dtoOld = new tm_kktorinyuryokuDto();
                if (req.editkbn == Enum編集区分.変更)
                {
                    //編集前の一括取込入力マスタ取得
                    dtoOld = GetKkimpDto(db, impno);

                    //更新排他チェック
                    if (dtoOld == null || dtoOld.upddttm != req.upddttm)
                    {
                        throw new AiExclusiveException();
                    }
                }

                //-------------------------------------------------------------
                //３.データ加工処理 & DB更新処理
                //-------------------------------------------------------------
                //更新日時
                DateTime dttm = DaUtil.Now;

                //※ヘッダー情報
                //一括取込入力マスタ
                tm_kktorinyuryokuDto kkimpDto = Converter.GetkkimpDto(dtoOld, req, dttm);

                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //一括取込入力No
                    if (string.IsNullOrEmpty(impno))
                    {
                        //一括取込入力No手動採番
                        impno = GetImpno(db);
                    }
                    //一括取込入力No
                    kkimpDto.torinyuryokuno = impno;
                    //一括取込入力マスタ登録
                    db.tm_kktorinyuryoku.INSERT.Execute(kkimpDto);
                }
                else //変更の場合
                {
                    //一括取込入力マスタ変更
                    db.tm_kktorinyuryoku.UpdateDto(kkimpDto, dtoOld.upddttm);

                    //汎用取込関連テーブルを削除
                    DeleteData(db, impno);
                }

                //一括取込入力区分がファイル取込の場合
                if (kkimpDto.torinyuryokbn == EnumToStr(Enum取込区分.ファイル取込))
                {
                    //取込基本情報マスタ登録
                    tm_kktori_kihonDto kkimpfileinfoDto = Converter.GetFileInfoDto(impno, req.fileinfoData);
                    db.tm_kktori_kihon.INSERT.Execute(kkimpfileinfoDto);

                    //取込IFマスタ登録
                    List<tm_kktori_interfaceDto> kkimpfileifDtl = Converter.GetFileIFDtl(impno, req.fileifList);
                    db.tm_kktori_interface.INSERT.Execute(kkimpfileifDtl);

                    //取込変換コードマスタ登録
                    List<tm_kktori_henkancodeDto> kkimpcdchangeDtl = Converter.GetCodeChangeDtl(impno, req.codechangeList);
                    db.tm_kktori_henkancode.INSERT.Execute(kkimpcdchangeDtl);

                    //取込項目マッピングマスタ登録
                    List<tm_kktori_mappingDto> kkimpitemmappingDtl = Converter.GetItemMappingDtl(impno, req.itemmappingList);
                    db.tm_kktori_mapping.INSERT.Execute(kkimpitemmappingDtl);
                }

                //一括取込入力対象テーブルマスタ登録
                List<tm_kktorinyuryoku_taisyotableDto> kkimptblsDtl = Converter.GetTaishoTableDtl(impno, req.hearderData);
                db.tm_kktorinyuryoku_taisyotable.INSERT.Execute(kkimptblsDtl);

                //一括取込入力項目定義マスタ登録
                List<tm_kktorinyuryoku_itemDto> kkimppageitemDtl = Converter.GetPageItemDtl(impno, req.pageitemList);
                db.tm_kktorinyuryoku_item.INSERT.Execute(kkimppageitemDtl);

                //一括取込入力登録マスタ登録
                List<tm_kktorinyuryoku_torokuDto> kkimpinsertdetailDtl = Converter.GetInsertDetailDtl(impno, req.insertList, kkimptblsDtl);
                db.tm_kktorinyuryoku_toroku.INSERT.Execute(kkimpinsertdetailDtl);

                //一括取込入力変換コードメインマスタ
                List<tm_kktorinyuryoku_henkancode_mainDto> changeCodeMainDtl = Converter.GetChangeCodeMainDto(impno, req.changeCodeMainList);
                db.tm_kktorinyuryoku_henkancode_main.INSERT.Execute(changeCodeMainDtl);

                //正常返し
                return res;
            });
        }

        [DisplayName("削除処理")]
        public DaResponseBase Delete(DeleteDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();

                //一括取込入力No
                string impno = req.impno;

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //編集前の一括取込入力マスタ取得
                tm_kktorinyuryokuDto kkimpDto = GetKkimpDto(db, impno);
                //排他チェック
                if (kkimpDto == null || kkimpDto.upddttm != req.upddttm)
                {
                    throw new AiExclusiveException();
                }

                //関連チェック
                var msg = CheckKanrenTable(db, impno, "削除");
                if (!string.IsNullOrEmpty(msg))
                {
                    //関連チェックエラーメッセージを表示
                    res.SetServiceError(msg);
                    return res;
                }

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                //一括取込入力マスタ削除
                db.tm_kktorinyuryoku.DELETE.WHERE.ByKey(impno).Execute();
                //汎用取込関連テーブルを削除
                DeleteData(db, impno);

                //正常返し
                return res;
            });
        }

        [DisplayName("ダウンロード処理")]
        public CmDownloadResponseBase Download(DetailCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new CmDownloadResponseBase();

                //ファイルマスタ
                var tm_affileDto = db.tm_affile.SELECT.WHERE.ByKey("01").GetDto();
                if (tm_affileDto == null)
                {
                    throw new AiExclusiveException();
                }

                //初期化処理詳細データ
                var detailData = new InitDetailResponse();

                //初期化処理詳細データをセットする
                SetInitDetailUpdateData(db, req.impno, detailData);

                //一時変数宣言
                var rowIndex = 0; var colIndex = 0; var startRowIndex = 0;
                //ファイルタイプ
                var filetype = "." + DaNameService.GetName(db, EnumNmKbn.ファイルタイプ, CStr(tm_affileDto.filetype));
                //一時出力ファイル名取得
                var tempFileName = Path.GetTempFileName();
                tempFileName = Path.ChangeExtension(tempFileName, filetype);
                File.WriteAllBytes(tempFileName, tm_affileDto.filedata);
                //出力ファイル名
                var fileName = tm_affileDto.filenm;

                var excelReprot = new ExcelLogger();

                //※ヘッダー情報を出力
                //定数定義
                var sheetName = SHEET_NAME_HEAD;
                startRowIndex = START_ROW_INDEX_HEAD;
                var bOpen = excelReprot.Open(tempFileName, sheetName, true);

                //ヘッダーの基本情報
                HeaderVM hearderData = detailData.hearderData;
                rowIndex = startRowIndex; colIndex = 1;
                excelReprot.WriteCell(colIndex, rowIndex++, hearderData.gyoumukbn);                     //業務区分
                excelReprot.WriteCell(colIndex, rowIndex++, hearderData.impno);                         //一括取込入力No
                excelReprot.WriteCell(colIndex, rowIndex++, hearderData.impnm);                         //一括取込入力名
                excelReprot.WriteCell(colIndex, rowIndex++, hearderData.impkbn);                        //一括取込入力区分
                excelReprot.WriteCell(colIndex, rowIndex++, SetBoolStr(hearderData.yeardispflg));       //年度表示フラグ
                excelReprot.WriteCell(colIndex, rowIndex++, CStr(hearderData.nendohanikbn));            //年度範囲区分
                excelReprot.WriteCell(colIndex, rowIndex++, hearderData.regupdkbn);                     //登録区分
                excelReprot.WriteCell(colIndex, rowIndex++, hearderData.orderseq);                      //並び順シーケンス
                excelReprot.WriteCell(colIndex, rowIndex++, CStr(hearderData.memo));                    //説明

                //対象テーブル物理名リスト
                foreach (string tableid in hearderData.tableidList)
                {
                    //対象テーブル物理名
                    excelReprot.WriteCell(colIndex, rowIndex++, tableid);
                }
                rowIndex = rowIndex + 10 - hearderData.tableidList.Count;
                excelReprot.WriteCell(colIndex, rowIndex++, CStr(hearderData.procchk));
                excelReprot.WriteCell(colIndex, rowIndex++, CStr(hearderData.procbefore));
                excelReprot.WriteCell(colIndex, rowIndex++, CStr(hearderData.procafter));
                excelReprot.Close();


                //※変換コードメイン情報を出力
                //定数定義
                sheetName = SHEET_NAME_CHANGECODE_MAIN;
                startRowIndex = START_ROW_INDEX_CHANGECODE_MAIN;
                bOpen = excelReprot.Open(tempFileName, sheetName, true);
                //読込列インデックスリストを取得する
                var firstRow = excelReprot.sheet.GetRow(0);
                List<int> colIndexList = GetColIndexList(firstRow);

                //変換コードメイン情報
                List<ChangeCodeMainVM> changeCodeMainList = detailData.changeCodeMainList;
                rowIndex = startRowIndex;
                for (var i = 0; i < changeCodeMainList.Count; i++)
                {
                    colIndex = 0;

                    var data = changeCodeMainList[i];
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.codehenkankbn);    //コード変換区分
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.henkankbnnm);      //変換区分名称
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.codekanritablenm); //コード管理テーブル名
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.maincd);           //メインコード
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.subcd);            //サブコード
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.sonotajoken));//その他条件
                    rowIndex++;
                }

                excelReprot.Close();

                //※画面項目定義情報を出力
                //定数定義
                sheetName = SHEET_NAME_PAGEITEM;
                startRowIndex = START_ROW_INDEX_PAGEITEM;
                bOpen = excelReprot.Open(tempFileName, sheetName, true);
                //読込列インデックスリストを取得する
                firstRow = excelReprot.sheet.GetRow(0);
                colIndexList = GetColIndexList(firstRow);

                //画面項目定義情報
                List<PageItemVM> pageitemList = detailData.pageitemList;
                rowIndex = startRowIndex;
                for (var i = 0; i < pageitemList.Count; i++)
                {
                    colIndex = 0;

                    var data = pageitemList[i];
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.pageitemseq);                  //画面項目ID
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.itemnm);                       //項目名
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.wktablecolnm);                 //ワークテーブルカラム名
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.itemkbn));                //項目特定区分
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.inputkbn);                     //入力区分
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.inputtype);                    //入力方法
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.hikisu));                 //引数
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.jigyocd));                //実施事業
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.len);                          //桁数
                    if (data.len2 != null)
                    {
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CInt(data.len2));               //桁数（小数部）
                    }
                    else
                    {
                        colIndex++;
                    }
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.width);                        //幅
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.format));                 //フォーマット
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.requiredflg);                  //必須フラグ
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, SetBoolStr(data.uniqueflg));        //一意フラグ
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.dispinputkbn);                 //表示入力設定区分
                    if (data.sortno != null)
                    {
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CInt(data.sortno));             //並び順
                    }
                    else
                    {
                        colIndex++;
                    }
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.yearchkflg));             //年度チェック
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, SetBoolStr(data.nendoflg));         //年度フラグ
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.seiki));                  //正規表現
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.minval));                 //最小値
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.maxval));                 //最大値
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.defaultval));             //初期値
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.fixedval));               //固定値
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.fromfieldid));            //参照元フィールド
                    if (data.fromitemseq != null)
                    {
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CInt(data.fromitemseq));        //参照元項目ID
                    }
                    else
                    {
                        colIndex++;
                    }
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.targetfieldid));          //取得先フィールド
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.msttable));               //マスタチェックテーブル
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.mstjyoken));              //マスタチェック条件
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.mstfield));               //マスタチェック項目
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.jherrlelkbn));            //条件必須エラーレベル区分
                    if (data.jhitemseq != null)
                    {
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CInt(data.jhitemseq));          //条件必須項目ID
                    }
                    else
                    {
                        colIndex++;
                    }
                    excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.jhenzan));                //条件必須演算子
                    //演算子:between or not between
                    if (data.jhenzan == EnumToStr(Enum演算子.between) || data.jhenzan == EnumToStr(Enum演算子.not_between))
                    {
                        if (data.jhval != null && data.jhval.Split(',').Length == 2)
                        {
                            excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.jhval.Split(',')[0]);  //条件必須値1
                            excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.jhval.Split(',')[1]);  //条件必須値2
                        }
                    }
                    else
                    {
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.jhval));              //条件必須値1
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, "");                            //条件必須値2
                    }

                    rowIndex++;
                }

                excelReprot.Close();

                //※登録仕様情報を出力
                //定数定義
                sheetName = SHEET_NAME_INSERT;
                startRowIndex = START_ROW_INDEX_INSERT;
                bOpen = excelReprot.Open(tempFileName, sheetName, true);
                //読込列インデックスリストを取得する
                firstRow = excelReprot.sheet.GetRow(0);
                colIndexList = GetColIndexList(firstRow);

                //登録仕様情報
                List<InsertVM> insertList = detailData.insertList;
                rowIndex = startRowIndex;
                foreach (InsertVM detail in insertList)
                {
                    if (detail.insertdetailList != null && detail.insertdetailList.Count > 0)
                    {
                        for (var i = 0; i < detail.insertdetailList.Count; i++)
                        {
                            colIndex = 0;

                            var data = detail.insertdetailList[i];
                            excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.tableid);                  //テーブル物理名
                            excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.recno);                    //レコードNo
                            excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.fieldid);                  //フィールド物理名
                            excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.syorikbn);                 //処理区分
                            if (data.pageitemseq != null)
                            {
                                excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CInt(data.pageitemseq));    //データ元画面項目ID
                            }
                            else
                            {
                                colIndex++;
                            }
                            excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.fixedval));           //固定値
                            excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.datamototablenm));    //データ元テーブル名
                            excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.datamotofieldnm));    //データ元フィールド名
                            excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.saibankey));          //採番キー

                            rowIndex++;
                        }
                    };
                }

                excelReprot.Close();

                //一括取込入力区分が[ファイル取込]の場合
                if (detailData.hearderData.impkbn == EnumToStr(Enum取込区分.ファイル取込))
                {
                    //※基本情報を出力
                    //定数定義
                    sheetName = SHEET_NAME_FILEINFO;
                    startRowIndex = START_ROW_INDEX_FILEINFO;
                    bOpen = excelReprot.Open(tempFileName, sheetName, true);

                    //取込ファイルの基本情報
                    FileInfoVM fileinfoData = detailData.fileinfoData;
                    rowIndex = startRowIndex; colIndex = 1;
                    excelReprot.WriteCell(colIndex, rowIndex++, fileinfoData.filetype);                     //ファイル形式
                    excelReprot.WriteCell(colIndex, rowIndex++, fileinfoData.fileencode);                   //エンコード
                    excelReprot.WriteCell(colIndex, rowIndex++, CStr(fileinfoData.filenmrule));             //ファイル名称
                    excelReprot.WriteCell(colIndex, rowIndex++, SetBoolStr(fileinfoData.filenmruleflg));    //正規表現
                    excelReprot.WriteCell(colIndex, rowIndex++, fileinfoData.datakbn);                      //データ形式
                    if (fileinfoData.recordlen != null)
                    {
                        excelReprot.WriteCell(colIndex, rowIndex++, CInt(fileinfoData.recordlen));          //レコード長
                    }
                    else
                    {
                        rowIndex++;
                    }
                    excelReprot.WriteCell(colIndex, rowIndex++, CStr(fileinfoData.quoteskbn));              //引用符
                    excelReprot.WriteCell(colIndex, rowIndex++, CStr(fileinfoData.dividekbn));              //区切り記号
                    excelReprot.WriteCell(colIndex, rowIndex++, fileinfoData.headerrows);                   //ヘッダー行数
                    excelReprot.WriteCell(colIndex, rowIndex++, fileinfoData.footerrows);                   //フッター行数

                    excelReprot.Close();

                    //※ファイルI/F情報を出力
                    //定数定義
                    sheetName = SHEET_NAME_FILEIF;
                    startRowIndex = START_ROW_INDEX_FILEIF;
                    bOpen = excelReprot.Open(tempFileName, sheetName, true);
                    //読込列インデックスリストを取得する
                    firstRow = excelReprot.sheet.GetRow(0);
                    colIndexList = GetColIndexList(firstRow);

                    //取込ファイルI/F情報
                    List<FileIFVM> fileifList = detailData.fileifList;
                    rowIndex = startRowIndex;
                    for (var i = 0; i < fileifList.Count; i++)
                    {
                        colIndex = 0;

                        var data = fileifList[i];
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.fileitemseq);              //№
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.itemnm));             //項目名称
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, SetBoolStr(data.keyflg));       //キー(参照)
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, SetBoolStr(data.requiredflg));  //必須(参照)
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.datatype);                 //データ型
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.len);                      //桁数（整数部）
                        if (data.len2 != null)
                        {
                            excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CInt(data.len2));           //桁数（小数部）
                        }
                        else
                        {
                            colIndex++;
                        }
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.format));             //フォーマット
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.fmtcheck));           //フォーマットチェック
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.fmtchange));          //フォーマット変換
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.memo));               //備考

                        rowIndex++;
                    }
                    excelReprot.Close();

                    //※変換コード情報を出力
                    //定数定義
                    sheetName = SHEET_NAME_CHANGECODE;
                    startRowIndex = START_ROW_INDEX_CHANGECODE;
                    bOpen = excelReprot.Open(tempFileName, sheetName, true);
                    //読込列インデックスリストを取得する
                    firstRow = excelReprot.sheet.GetRow(0);
                    colIndexList = GetColIndexList(firstRow);

                    //変換コード情報
                    List<CodeChangeVM> codechangeList = detailData.codechangeList;
                    rowIndex = startRowIndex;
                    foreach (CodeChangeVM detail in codechangeList)
                    {
                        if (detail.codechangedetailList != null && detail.codechangedetailList.Count > 0)
                        {
                            for (var i = 0; i < detail.codechangedetailList.Count; i++)
                            {
                                colIndex = 0;

                                var data = detail.codechangedetailList[i];
                                excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.cdchangekbn);          //コード変換区分
                                excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.oldcode);              //元コード
                                excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.oldcodememo));    //元コード説明
                                excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.newcode);              //変換後コード
                                excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.newcodememo));    //変換後コード説明
                                rowIndex++;
                            }
                        }
                    }

                    excelReprot.Close();

                    //※マッピング設定情報を出力
                    //定数定義
                    sheetName = SHEET_NAME_ITEMMAP;
                    startRowIndex = START_ROW_INDEX_ITEMMAP;
                    bOpen = excelReprot.Open(tempFileName, sheetName, true);
                    //読込列インデックスリストを取得する
                    firstRow = excelReprot.sheet.GetRow(0);
                    colIndexList = GetColIndexList(firstRow);

                    //マッピング設定情報
                    List<ItemMappingVM> itemmappingList = detailData.itemmappingList;
                    rowIndex = startRowIndex;
                    for (var i = 0; i < itemmappingList.Count; i++)
                    {
                        colIndex = 0;

                        var data = itemmappingList[i];
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.pageitemseq);           //画面項目ID
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, data.mappingkbn);            //マッピング区分
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.mappingmethod));   //マッピング方法
                        excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CStr(data.fileitemseq));     //ファイル項目
                        if (data.substrfrom != null)
                        {
                            excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CInt(data.substrfrom));  //指定桁数（開始）
                        }
                        else
                        {
                            colIndex++;
                        }
                        if (data.substrto != null)
                        {
                            excelReprot.WriteCell(colIndexList[colIndex++], rowIndex, CInt(data.substrto));    //指定桁数（終了）
                        }
                        else
                        {
                            colIndex++;
                        }
                        rowIndex++;
                    }

                    excelReprot.Close();
                }

                //Excelファイルからbyte[]に変換
                FileStream fs = File.OpenRead(tempFileName);
                byte[] bytebuffer;
                bytebuffer = new byte[fs.Length];
                fs.Read(bytebuffer, 0, (int)fs.Length);
                fs.Close();

                res = CmDownloadService.GetDownloadResponse(new DaFileModel(fileName, filetype, bytebuffer));

                File.Delete(tempFileName);

                //出力
                return res;

            });
        }

        [DisplayName("アップロード処理")]
        public UploadResponse ExcelUpload(UploadRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new UploadResponse();

                //リスト取得
                List<DaFileModel> files = req.files;

                if (files.Count >= 0)
                {
                    //データ取得
                    var filedata = files[0].filedata;

                    //取込設定アップロードエラーリスト
                    var errList = new List<UploadErrorVM>();
                    //アップロードデータ
                    var uploadData = new UploadData();

                    //アップロードデータを取得する
                    var msg = GetUploadData(db, filedata, req, ref uploadData, ref errList);

                    // エラー
                    if (!string.IsNullOrEmpty(msg))
                    {
                        //エラーメッセージ設定
                        res.SetServiceError(msg);
                        return res;
                    }

                    //アップロードデータを取得
                    res.uploadData = uploadData;

                    if (errList.Count > 0)
                    {
                        //出力エラーファイルデータを取得
                        res.errorbytebuffer = GetUploadErrorData(errList);
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
                //ファイル名
                var fileName = "取込設定アップロードエラー_" + DaUtil.Now.ToString("yyyyMMddhhmmss");
                res = CmDownloadService.GetDownloadResponse(new DaFileModel(fileName, ".xlsx", req.errorbytebuffer));
                //正常返し
                return res;
            });
        }

        [DisplayName("ストアドプロシージャ情報のドロップダウンリスト再検索処理")]
        public ReSearchProcResponse ReSearchProc(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new ReSearchProcResponse();
                //※詳細画面:ストアドプロシージャ情報のドロップダウンリストの初期化データ
                res = GetProcSelectorList(db);

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 汎用取込関連テーブルを削除
        /// </summary>
        private void DeleteData(DaDbContext db, string impno)
        {
            //一括取込入力対象テーブルマスタ
            db.tm_kktorinyuryoku_taisyotable.DELETE.WHERE.ByKey(impno).Execute();

            //取込基本情報マスタ
            db.tm_kktori_kihon.DELETE.WHERE.ByKey(impno).Execute();
            //取込IFマスタ
            db.tm_kktori_interface.DELETE.WHERE.ByKey(impno).Execute();
            //取込変換コードマスタ
            db.tm_kktori_henkancode.DELETE.WHERE.ByItem(nameof(tm_kktori_henkancodeDto.torinyuryokuno), impno).Execute();
            //取込項目マッピングマスタ
            db.tm_kktori_mapping.DELETE.WHERE.ByKey(impno).Execute();

            //一括取込入力項目定義マスタ
            db.tm_kktorinyuryoku_item.DELETE.WHERE.ByKey(impno).Execute();
            //一括取込入力登録マスタ
            db.tm_kktorinyuryoku_toroku.DELETE.WHERE.ByKey(impno).Execute();

            //一括取込入力変換コードメインマスタ
            db.tm_kktorinyuryoku_henkancode_main.DELETE.WHERE.ByKey(impno).Execute();
        }

        #region 初期化処理　検索処理(詳細画面)

        /// <summary>
        /// 詳細画面：初期化処理データをセットする(新規)
        /// </summary>
        private void SetInitDetailAddData(DaDbContext db, InitDetailResponse res)
        {
            //※詳細画面:ヘッダー情報の初期値を設定
            res.hearderData = new HeaderVM();
            res.hearderData.regupdkbn = EnumToStr(Enum登録区分.削除新規);         //登録区分：削除新規
            res.hearderData.gyoumukbn = 取込業務区分._01;                         //業務区分：共通管理
            res.hearderData.impkbn = EnumToStr(Enum取込区分.ファイル取込);        //一括取込入力区分：ファイル取込

            //※詳細画面:基本情報の初期値を設定
            res.fileinfoData = new FileInfoVM();
            res.fileinfoData.filetype = EnumToStr(Enumファイル形式.CSVファイル);  //ファイル形式：CSVファイル
            res.fileinfoData.fileencode = EnumToStr(Enumエンコード.SJIS);         //エンコード：S-JIS
            res.fileinfoData.datakbn = EnumToStr(Enumデータ形式.可変長);          //データ形式：可変長
            res.fileinfoData.quoteskbn = EnumToStr(Enum引用符_CSV出力用.なし);    //引用符：なし
            res.fileinfoData.dividekbn = EnumToStr(Enum区切り記号.カンマ);        //区切り記号：カンマ

            //詳細画面:ファイルI/F情報を設定
            res.fileifList = new List<FileIFVM>();
            //詳細画面:取込コード変換情報を設定
            res.codechangeList = new List<CodeChangeVM>();
            //詳細画面:マッピング設定情報を設定
            res.itemmappingList = new List<ItemMappingVM>();
            //詳細画面:画面項目情報を設定
            res.pageitemList = new List<PageItemVM>();
            //詳細画面:登録仕様情報を設定
            res.insertList = new List<InsertVM>();
            //詳細画面:変換コードメイン情報を設定
            res.changeCodeMainList = new List<ChangeCodeMainVM>();
        }

        /// <summary>
        /// 詳細画面：初期化処理詳細データをセットする(更新)
        /// </summary>
        private void SetInitDetailUpdateData(DaDbContext db, string impno, InitDetailResponse res)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //一括取込入力マスタ
            tm_kktorinyuryokuDto kkimpDto = GetKkimpDto(db, impno);
            if (kkimpDto == null)
            {
                throw new AiExclusiveException();
            }

            //更新日時
            res.upddttm = kkimpDto.upddttm;

            //※詳細画面:ヘッダー情報を設定
            //一括取込入力対象テーブルマスタ
            List<tm_kktorinyuryoku_taisyotableDto> kkimptblsDtl = GetInsertTableDtl(db, impno);
            var tablenmlist = kkimptblsDtl.Select(e => e.tablenm).ToList();
            //ヘッダー情報を取得する
            res.hearderData = Wraper.GetHeaderVM(kkimpDto, tablenmlist);

            //※詳細画面:変換コードメイン情報を設定
            //一括取込入力変換コードメインマスタ
            List<tm_kktorinyuryoku_henkancode_mainDto> changeCodeMainDtl = GetChangeCodeMainDtl(db, impno);
            //変換コードメイン情報を取得する
            res.changeCodeMainList = Wraper.GetChangeCodeMainVMList(changeCodeMainDtl);

            //※詳細画面:画面項目情報を設定
            //一括取込入力テーブルマスタ
            List<tm_kktorinyuryoku_tableDto> tableDtl = GetTableDtl(db);
            //一括取込入力項目定義マスタ
            List<tm_kktorinyuryoku_itemDto> pageitemDtl = GetPageItemDtl(db, impno);
            //画面項目情報を取得する
            res.pageitemList = Wraper.GetPageItemVMList(db, pageitemDtl, tableDtl, changeCodeMainDtl);

            //一括取込入力区分が[ファイル取込]の場合
            if (res.hearderData.impkbn == EnumToStr(Enum取込区分.ファイル取込))
            {
                //※詳細画面:基本情報を設定
                //取込基本情報マスタ
                tm_kktori_kihonDto kkimpfileinfoDto = GetKihonDto(db, impno);
                //基本情報を取得する
                res.fileinfoData = Wraper.GetFileInfoVM(kkimpfileinfoDto);

                //※詳細画面:ファイルI/F情報を設定
                //取込IFマスタ
                List<tm_kktori_interfaceDto> kkimpfileifDtl = GeImpIfDtl(db, impno);
                //ファイルI/F情報を取得する
                res.fileifList = Wraper.GetFileIFVMList(db, kkimpfileifDtl);

                //※詳細画面:取込コード変換情報を設定
                //取込変換コードマスタ
                List<tm_kktori_henkancodeDto> ttkkimpcdchangeDtl = GetChangeCodeDtl(db, impno);
                //取込コード変換情報を取得する
                res.codechangeList = Wraper.GetCodeChangeVMList(ttkkimpcdchangeDtl);

                //※詳細画面:マッピング設定情報を設定
                //取込項目マッピングマスタ
                List<tm_kktori_mappingDto> kkimpitemmappingDtl = GetMappingDtl(db, impno);
                //マッピング設定情報を取得する
                res.itemmappingList = Wraper.GetItemMappingVMList(db, kkimpitemmappingDtl, res.fileifList, res.pageitemList);
            };

            //登録区分が[プロシージャ]の場合
            //if (res.hearderData.regupdkbn == EnumToStr(Enum登録区分.プロシージャ))
            //TODO高
            if (true)
            {
                //※詳細画面:登録仕様情報を設定
                //一括取込入力登録マスタ
                List<tm_kktorinyuryoku_torokuDto> insertdetailDtl = GetInsertDetailDtl(db, impno);
                //登録仕様情報を取得する
                res.insertList = Wraper.GetInsertVMList(db, insertdetailDtl, tableDtl, res.hearderData.tableidList, res.pageitemList);
            }
            
        }

        /// <summary>
        /// //初期化処理詳細データをセットする(アップロード後遷移の場合)
        /// </summary>
        private void SetIniDetailDataByUpload(DaDbContext db, InitDetailRequest req, InitDetailResponse res)
        {
            if (req.editkbn == Enum編集区分.変更)
            {
                //一括取込入力マスタ
                tm_kktorinyuryokuDto kkimpDto = GetKkimpDto(db, req.impno);
                if (kkimpDto == null)
                {
                    throw new AiExclusiveException();
                }

                //更新日時
                res.upddttm = kkimpDto.upddttm;
            }

            //アップロードデータ
            var uploadData = req.uploadData;

            //※詳細画面:ヘッダー情報を設定
            res.hearderData = uploadData.hearderData;
            //※詳細画面:画面項目情報を設定
            res.pageitemList = uploadData.pageitemList;
            //※詳細画面:登録仕様情報を設定
            res.insertList = uploadData.insertList;
            //※詳細画面:変換コードメイン情報を設定
            res.changeCodeMainList = uploadData.changeCodeMainList;

            //ファイル取込の場合
            if (uploadData.hearderData.impkbn == EnumToStr(Enum取込区分.ファイル取込))
            {
                //※詳細画面:基本情報を設定
                res.fileinfoData = uploadData.fileinfoData;
                //※詳細画面:ファイルI/F情報を設定
                res.fileifList = uploadData.fileifList;
                //※詳細画面:取込コード変換情報を設定
                res.codechangeList = uploadData.codechangeList;
                //※詳細画面:マッピング設定情報を設定
                res.itemmappingList = uploadData.itemmappingList;
            }
        }

        /// <summary>
        /// 詳細画面：【ヘッダ】のドロップダウンリストの初期化データをセットする
        /// </summary>
        private void SetInitDetailHeadSelectorData(DaDbContext db, InitDetailResponse res)
        {
            //※詳細画面:ヘッダー情報のドロップダウンリストの初期化データ

            //【業務区分】のドロップダウンリスト
            res.gyoumukbnList = GetNameSelectorList(db, EnumNmKbn.取込業務区分);
            //【一括取込入力区分】のドロップダウンリスト
            res.impkbnList = GetNameSelectorList(db, EnumNmKbn.取込区分);
            //【登録区分】のドロップダウンリスト
            res.regupdkbnList = GetNameSelectorList(db, EnumNmKbn.登録区分);
            //【年度範囲区分】のドロップダウンリスト
            res.nendohanikbnList = GetNameSelectorList(db, EnumNmKbn.年度範囲区分);
            //【テーブル】のドロップダウンリスト
            res.headtableidList = SetTableList(db);
        }

        /// <summary>
        /// 詳細画面：【ボディー】のドロップダウンリストの初期化データをセットする
        /// </summary>
        private void SetInitDetailBodySelectorData(DaDbContext db, InitDetailRequest req, InitDetailResponse res, HeaderVM hearderData)
        {
            //新規の場合　または　修正の一括取込入力区分が[ファイル取込]の場合
            if (req.editkbn == Enum編集区分.新規 || hearderData.impkbn == EnumToStr(Enum取込区分.ファイル取込))
            {
                //※詳細画面:基本情報のドロップダウンリストの初期化データ
                //【ファイル形式】のドロップダウンリスト
                res.filetypeList = DaNameService.GetNameList(db, EnumNmKbn.ファイル形式).Where(x => x.hanyokbn1 == "1").Select(d => new DaSelectorModel(d.nmcd, d.nm)).ToList();
                //【エンコード】のドロップダウンリスト
                res.filenmruleList = GetNameSelectorList(db, EnumNmKbn.エンコード);
                //【データ形式】のドロップダウンリスト
                res.datakbnList = DaNameService.GetNameList(db, EnumNmKbn.データ形式).Where(x => x.hanyokbn1 == "1").Select(d => new DaSelectorModel(d.nmcd, d.nm)).OrderBy(d => d.value).ToList();
                //【引用符存在区分】のドロップダウンリスト
                res.quoteskbnList = GetNameSelectorList(db, EnumNmKbn.引用符_CSV出力用);
                //【区切り記号】のドロップダウンリスト
                res.dividekbnList = GetNameSelectorList(db, EnumNmKbn.区切り記号);
            }

            //※詳細画面:変換コード情報のドロップダウンリストの初期化データ
            //【変換区分】のドロップダウンリスト
            res.changekbnList = res.changeCodeMainList.Select(d => new DaSelectorModel(CStr(d.codehenkankbn), d.henkankbnnm)).ToList();

            //※詳細画面:ストアドプロシージャ情報のドロップダウンリストの初期化データ
            var procResponse = GetProcSelectorList(db);
            //【チェック用】のドロップダウンリスト
            res.procchkList = procResponse.procchkList;
            //【更新前処理】のドロップダウンリスト
            res.procbeforeList = procResponse.procbeforeList;
            //【更新後処理】のドロップダウンリスト
            res.procafterList = procResponse.procafterList;
        }

        /// <summary>
        /// 【本システムコード】のドロップダウンリストをセットする
        /// </summary>
        private List<DaSelectorModel> GetSysCodeList(DaDbContext db, ChangeCodeMainVM changeCodeMainData)
        {
            if (changeCodeMainData == null || string.IsNullOrEmpty(changeCodeMainData.codekanritablenm))
            {
                return new List<DaSelectorModel>();
            }

            //コード管理テーブル名
            string cdtableid = changeCodeMainData.codekanritablenm;
            //メインコード
            var maincd = changeCodeMainData.maincd;
            //サブコード
            var subcd = CInt(changeCodeMainData.subcd);
            //名称マスタ
            if (cdtableid.Equals(tm_afmeisyoDto.TABLE_NAME))
            {
                if (!string.IsNullOrEmpty(changeCodeMainData.sonotajoken))
                {
                    //その他条件があり
                    return db.tm_afmeisyo.SELECT.WHERE
                        .ByFilter($"{ nameof(tm_afmeisyoDto.nmmaincd) } = '{ maincd }' AND {nameof(tm_afmeisyoDto.nmsubcd)} = { subcd } AND { changeCodeMainData.sonotajoken }").GetDtoList()
                            .Select(e => new DaSelectorModel { value = e.nmcd, label = e.nm }).ToList();
                }
                else
                {
                    //その他条件がなし
                    return DaNameService.GetSelectorList(db, maincd, subcd, Enum名称区分.名称);
                }
            }
            //汎用マスタ
            else if (cdtableid.Equals(tm_afhanyoDto.TABLE_NAME))
            {
                if (!string.IsNullOrEmpty(changeCodeMainData.sonotajoken))
                {
                    //その他条件があり
                    return db.tm_afhanyo.SELECT.WHERE
                        .ByFilter($"{nameof( tm_afhanyoDto.hanyomaincd) } = '{ maincd }' AND { nameof(tm_afhanyoDto.hanyosubcd) } = { subcd } AND {changeCodeMainData.sonotajoken}").GetDtoList()
                            .Select(e => new DaSelectorModel { value = e.hanyocd, label = e.nm }).ToList();
                }
                else
                {
                    //その他条件がなし
                    return DaHanyoService.GetSelectorList(db, maincd, subcd, Enum名称区分.名称);
                }
            }
            else
            {
                return new List<DaSelectorModel>();
            }
        }

        /// <summary>
        /// ヘッダー情報：【テーブル】のドロップダウンリストをセットする
        /// </summary>
        private List<DaSelectorKeyModel> SetTableList(DaDbContext db)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //一括取込入力テーブルマスタを取得する(取込対象)
            var tableDtl = GetImpTableDtl(db);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //【テーブル】のドロップダウンリストを取得する
            var tableList = tableDtl.Select(d => new DaSelectorKeyModel(d.tablenm, d.tableronrinm, d.oyatablenm)).ToList();

            return tableList;
        }

        /// <summary>
        /// テーブルの登録項目設定情報を取得する
        /// </summary>
        private InsertVM GetTableFieldList(DaDbContext db, string tableid)
        {
            var vm = new InsertVM();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //一括取込入力テーブル項目マスタを取得する
            List<AiFieldInfo> tableItemList = ImDBUtil.GetFieldList(db, tableid);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            vm.tableid = tableid;
            vm.insertdetailList = new List<InsertDetailVM>();
            foreach (AiFieldInfo tableItemDto in tableItemList)
            {
                //テーブルの登録項目設定明細情報を取得する
                var detailVM = Wraper.GetInsertDetailVM(db, tableid, 1, tableItemDto);

                vm.insertdetailList.Add(detailVM);
            }

            return vm;
        }

        /// <summary>
        /// プロシージャマスタからプロシージャ名ドロップダウンリスト取得
        /// </summary>
        public ReSearchProcResponse GetProcSelectorList(DaDbContext db)
        {
            var res = new ReSearchProcResponse();

            //プロシージャマスタ
            List<tm_kktorinyuryoku_procDto> procDtl = db.tm_kktorinyuryoku_proc.SELECT.GetDtoList();

            //【チェック用】のドロップダウンリスト
            res.procchkList = procDtl.Where(e => e.prockbn == EnumToStr(Enum処理種別.チェック用)).OrderBy(e => e.procnm).Select(d => new DaSelectorModel(d.procnm, d.procnm)).ToList();
            //【更新前処理】のドロップダウンリスト
            res.procbeforeList = procDtl.Where(e => e.prockbn == EnumToStr(Enum処理種別.更新前処理)).OrderBy(e => e.procnm).Select(d => new DaSelectorModel(d.procnm, d.procnm)).ToList();
            //【更新後処理】のドロップダウンリスト
            res.procafterList = procDtl.Where(e => e.prockbn == EnumToStr(Enum処理種別.更新後処理)).OrderBy(e => e.procnm).Select(d => new DaSelectorModel(d.procnm, d.procnm)).ToList();

            //正常返し
            return res;
        }

        #endregion

        #region 取込テーブルデータを取得

        /// <summary>
        /// 一括取込入力マスタを取得する
        /// </summary>
        public static tm_kktorinyuryokuDto GetKkimpDto(DaDbContext db, string impno)
        {
            //一括取込入力マスタを取得する
            tm_kktorinyuryokuDto kkimpDto = db.tm_kktorinyuryoku.SELECT.WHERE.ByKey(impno).GetDto();
            return kkimpDto;
        }

        /// <summary>
        /// 一括取込入力対象テーブルマスタを取得する
        /// </summary>
        public static List<tm_kktorinyuryoku_taisyotableDto> GetInsertTableDtl(DaDbContext db, string impno)
        {
            //一括取込入力対象テーブルマスタ
            List<tm_kktorinyuryoku_taisyotableDto> dtl = db.tm_kktorinyuryoku_taisyotable.SELECT.WHERE.ByKey(impno).GetDtoList();
            return dtl;
        }

        /// <summary>
        ///取込基本情報マスタを取得する
        /// </summary>
        public static tm_kktori_kihonDto GetKihonDto(DaDbContext db, string impno)
        {
            //取込基本情報マスタ
            tm_kktori_kihonDto dto = db.tm_kktori_kihon.SELECT.WHERE.ByKey(impno).GetDto();
            return dto;
        }

        /// <summary>
        /// //取込IFマスタを取得する
        /// </summary>
        public static List<tm_kktori_interfaceDto> GeImpIfDtl(DaDbContext db, string impno)
        {
            //取込IFマスタを取得する
            List<tm_kktori_interfaceDto> dtl = db.tm_kktori_interface.SELECT.WHERE.ByKey(impno).ORDER.By(nameof(tm_kktori_interfaceDto.fileitemseq)).GetDtoList();
            return dtl;
        }

        /// <summary>
        /// 取込変換コードマスタを取得する
        /// </summary>
        private static List<tm_kktori_henkancodeDto> GetChangeCodeDtl(DaDbContext db, string impno)
        {
            //取込変換コードマスタを取得する
            List<tm_kktori_henkancodeDto> dtl = db.tm_kktori_henkancode.SELECT.WHERE.ByItem(nameof(tm_kktori_henkancodeDto.torinyuryokuno), impno).ORDER.By(nameof(tm_kktori_henkancodeDto.codehenkankbn), nameof(tm_kktori_henkancodeDto.henkangocd)).GetDtoList();
            return dtl;
        }

        /// <summary>
        /// 一括取込入力変換コードメインマスタを取得する
        /// </summary>
        private List<tm_kktorinyuryoku_henkancode_mainDto> GetChangeCodeMainDtl(DaDbContext db, string impno)
        {
            //一括取込入力変換コードメインマスタを取得する
            List<tm_kktorinyuryoku_henkancode_mainDto> dtl = db.tm_kktorinyuryoku_henkancode_main.SELECT.WHERE.ByKey(impno).GetDtoList();

            return dtl;
        }

        /// <summary>
        /// 一括取込入力項目定義マスタを取得する
        /// </summary>
        private static List<tm_kktorinyuryoku_itemDto> GetPageItemDtl(DaDbContext db, string impno)
        {
            //一括取込入力項目定義マスタを取得する
            List<tm_kktorinyuryoku_itemDto> dtl = db.tm_kktorinyuryoku_item.SELECT.WHERE.ByKey(impno).ORDER.By(nameof(tm_kktorinyuryoku_itemDto.gamenitemseq)).GetDtoList();
            return dtl;
        }

        /// <summary>
        /// 取込項目マッピングマスタを取得する
        /// </summary>
        private static List<tm_kktori_mappingDto> GetMappingDtl(DaDbContext db, string impno)
        {
            //取込項目マッピングマスタを取得する
            List<tm_kktori_mappingDto> dtl = db.tm_kktori_mapping.SELECT.WHERE.ByKey(impno).ORDER.By(nameof(tm_kktori_mappingDto.gamenitemseq)).GetDtoList();
            return dtl;
        }

        /// <summary>
        /// 一括取込入力登録マスタを取得する
        /// </summary>
        private static List<tm_kktorinyuryoku_torokuDto> GetInsertDetailDtl(DaDbContext db, string impno)
        {
            //一括取込入力登録マスタを取得する
            List<tm_kktorinyuryoku_torokuDto> dtl = db.tm_kktorinyuryoku_toroku.SELECT.WHERE.ByKey(impno).GetDtoList();
            return dtl;
        }

        /// <summary>
        /// 一括取込入力テーブルマスタを取得する(全てテーブル)
        /// </summary>
        private static List<tm_kktorinyuryoku_tableDto> GetTableDtl(DaDbContext db)
        {
            // 一括取込入力テーブルマスタを取得する
            List<tm_kktorinyuryoku_tableDto> dtl = db.tm_kktorinyuryoku_table.SELECT.GetDtoList();
            return dtl;
        }

        /// <summary>
        /// 一括取込入力テーブルマスタを取得する(取込対象テーブル)
        /// </summary>
        private static List<tm_kktorinyuryoku_tableDto> GetImpTableDtl(DaDbContext db)
        {
            // 一括取込入力テーブルマスタを取得する(取込対象)
            List<tm_kktorinyuryoku_tableDto> dtl = db.tm_kktorinyuryoku_table.SELECT.WHERE.ByItem(nameof(tm_kktorinyuryoku_tableDto.imptaisyoflg), true).ORDER.By(nameof(tm_kktorinyuryoku_tableDto.orderseq)).GetDtoList();
            return dtl;
        }

        /// <summary>
        /// 名称マスタからドロップダウンリスト取得
        /// </summary>
        public List<DaSelectorModel> GetNameSelectorList(DaDbContext db, EnumNmKbn kbn2)
        {
            //ドロップダウンリスト取得
            var list = DaNameService.GetSelectorList(db, kbn2, Enum名称区分.名称);
            return list;
        }

        #endregion

        #region 取込設定アップロード

        /// <summary>
        /// 取得するアップロードデータを取得する
        /// </summary>
        private string GetUploadData(DaDbContext db, byte[] filedata, UploadRequest req, ref UploadData uploadData, ref List<UploadErrorVM> errList)
        {
            //一時出力ファイル名取得
            var tempFileName = Path.GetTempFileName() + ".xlsx";

            FileStream fs = File.OpenWrite(tempFileName);
            fs.Write(filedata, 0, filedata.Length);
            fs.Close();

            fs = File.OpenRead(tempFileName);
            IWorkbook book = WorkbookFactory.Create(fs);

            //ヘッダーシートチェック
            if (book.GetSheet(SHEET_NAME_HEAD) == null)
            {
                //エラーメッセージ設定
                return DaMessageService.GetMsg(EnumMessage.E003006, "シート数");
            }

            //一時変数宣言
            var rowIndex = 1; var colIndex = 1; var startRowIndex = 1;
            //シート名
            var sheetNo = 0;
            //シート名
            var sheetName = "";
            ISheet sheet;
            IRow sRow;

            //※詳細画面:ヘッダ情報を取得する
            //定数定義
            sheetName = SHEET_NAME_HEAD;           //シート名
            startRowIndex = START_ROW_INDEX_HEAD;  //スタート行インデックス
            sheetNo = SHEET_NO_HEAD;               //シートNo
            sheet = book.GetSheet(sheetName);

            rowIndex = startRowIndex;
            colIndex = 1;

            //一括取込入力マスタ
            var headDto = new tm_kktorinyuryokuDto();
            headDto.gyomukbn = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);             //業務区分
            headDto.torinyuryokuno = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);       //一括取込入力No
            headDto.torinyuryokunm = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);       //一括取込入力名
            headDto.torinyuryokbn = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);        //一括取込入力区分
            var value = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);                    //年度表示フラグ
            headDto.nendohyojiflg = GetUploadFlgItemValue("年度表示フラグ", value, sheetNo, sheetName, rowIndex, ref errList);
            headDto.nendohanikbn = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);         //年度範囲区分
            headDto.torokukbn = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);            //登録区分
            headDto.orderseq = GetCellIntValue(sheet.GetRow(rowIndex++), colIndex);             //並び順シーケンス
            headDto.comment = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);              //説明

            //一括取込Noが選択行と異なる場合はエラーとし
            if (req.editkbn == Enum編集区分.変更 && headDto.torinyuryokuno != req.impno)
            {
                //エラーメッセージ設定
                return DaMessageService.GetMsg(EnumMessage.ITEM_NOTEQUAL_ERROR, "一括取込入力No");
            }

            //一括取込入力マスタ
            tm_kktorinyuryokuDto? kkimpDto = null;
            if (!string.IsNullOrEmpty(headDto.torinyuryokuno))
            {
                //括取込入力マスタを取得する
                kkimpDto = GetKkimpDto(db, headDto.torinyuryokuno);
            }

            //EXCELの一括入力No存在チェック
            var msg = CheckUploadImpno(req.editkbn, kkimpDto, headDto.torinyuryokuno);
            if (!string.IsNullOrEmpty(msg))
            {
                return msg;
            }

            //シート数のチェック
            if (book.GetSheet(SHEET_NAME_CHANGECODE_MAIN) == null ||
                book.GetSheet(SHEET_NAME_PAGEITEM) == null ||
                book.GetSheet(SHEET_NAME_INSERT) == null ||
                (headDto.torinyuryokbn == EnumToStr(Enum取込区分.ファイル取込) && (
                book.GetSheet(SHEET_NAME_FILEINFO) == null ||
                book.GetSheet(SHEET_NAME_FILEIF) == null ||
                book.GetSheet(SHEET_NAME_CHANGECODE) == null ||
                book.GetSheet(SHEET_NAME_ITEMMAP) == null))
                )
            {
                //エラーメッセージ設定
                return DaMessageService.GetMsg(EnumMessage.E003006, "シート数");
            }

            //対象テーブルリスト
            var tablenmlist = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                var tableid = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);
                if (!string.IsNullOrEmpty(tableid.Trim()))
                {
                    tablenmlist.Add(tableid);
                }
            }
            //チェックプロシージャ名
            headDto.proccheck = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);
            //更新前プロシージャ名
            headDto.procbefore = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);
            //更新後プロシージャ名
            headDto.procafter = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);

            //ヘッダー情報を取得する
            uploadData.hearderData = Wraper.GetHeaderVM(headDto, tablenmlist);
            //一括取込入力テーブルマスタ
            List<tm_kktorinyuryoku_tableDto> tableDtl = GetTableDtl(db);
            //取込ファイルヘッダー情報アップロード時必要なチェック
            var subErrList = GetUploadHeadErrorList(db, uploadData.hearderData, sheetNo, sheetName, tableDtl);
            errList.AddRange(subErrList);


            //※詳細画面:変換コードメイン情報を取得する
            //定数定義
            sheetName = SHEET_NAME_CHANGECODE_MAIN;           //シート名
            startRowIndex = START_ROW_INDEX_CHANGECODE_MAIN;  //スタート行インデックス
            sheetNo = SHEET_NO_CHANGECODE_MAIN;               //シートNo
            sheet = book.GetSheet(sheetName);
            //読込列インデックスリストを取得する
            var firstRow = sheet.GetRow(0);
            List<int> colIndexList = GetColIndexList(firstRow);

            //一括取込入力変換コードメインマスタリスト
            var changeCodeMainDtl = new List<tm_kktorinyuryoku_henkancode_mainDto>();
            if (colIndexList.Count >= 5)
            {

                for (rowIndex = startRowIndex; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    sRow = sheet.GetRow(rowIndex);
                    colIndex = 0;
                    //空白行の場合　または　「コード変換区分」列空白の場合、読み込み終了とする
                    if (IsRowBlank(sRow) || GetCellNIntValue(sRow, colIndexList[0]) == null)
                    {
                        break;
                    }

                    //一括取込入力変換コードメインマスタ
                    var codeMainDto = new tm_kktorinyuryoku_henkancode_mainDto();
                    codeMainDto.codehenkankbn = GetCellIntValue(sRow, colIndexList[colIndex++]);    //コード変換区分
                    codeMainDto.henkankbnnm = GetCellStrValue(sRow, colIndexList[colIndex++]);      //変換区分名称
                    codeMainDto.codekanritablenm = GetCellStrValue(sRow, colIndexList[colIndex++]); //コード管理テーブル名
                    codeMainDto.maincd = GetCellStrValue(sRow, colIndexList[colIndex++]);           //メインコード
                    codeMainDto.subcd = GetCellStrValue(sRow, colIndexList[colIndex++]);            //サブコード
                    codeMainDto.sonotajoken = GetCellStrValue(sRow, colIndexList[colIndex++]);      //その他条件

                    changeCodeMainDtl.Add(codeMainDto);
                }

                //変換コードメイン情報を取得する
                uploadData.changeCodeMainList = Wraper.GetChangeCodeMainVMList(changeCodeMainDtl);

                //取込ファイル変換コードメイン情報アップロード時必要なチェック
                subErrList = GetUploadChangeCodeMainErrorList(db, uploadData.changeCodeMainList, sheetNo, sheetName, startRowIndex);
                errList.AddRange(subErrList);
            }

            //※詳細画面:画面項目情報を取得する
            //定数定義
            sheetName = SHEET_NAME_PAGEITEM;           //シート名
            startRowIndex = START_ROW_INDEX_PAGEITEM;  //スタート行インデックス
            sheetNo = SHEET_NO_PAGEITEM;               //シートNo
            sheet = book.GetSheet(sheetName);
            //読込列インデックスリストを取得する
            firstRow = sheet.GetRow(0);
            colIndexList = GetColIndexList(firstRow);

            //一括取込入力項目定義マスタ
            var pageitemDtl = new List<tm_kktorinyuryoku_itemDto>();
            if (colIndexList.Count >= 31)
            {
                for (rowIndex = startRowIndex; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    sRow = sheet.GetRow(rowIndex);

                    //空白行の場合　または　「画面項目ID」列空白の場合、読み込み終了とする
                    if (IsRowBlank(sRow) || GetCellNIntValue(sRow, colIndexList[0]) == null)
                    {
                        break;
                    }

                    //一括取込入力項目定義マスタ
                    var itemDto = new tm_kktorinyuryoku_itemDto();
                    colIndex = 0;
                    itemDto.gamenitemseq = GetCellIntValue(sRow, colIndexList[colIndex++]);               //画面項目ID
                    itemDto.itemnm = GetCellStrValue(sRow, colIndexList[colIndex++]);                     //項目名
                    itemDto.wktablecolnm = GetCellStrValue(sRow, colIndexList[colIndex++]);               //ワークテーブルカラム名
                    itemDto.itemtokuteikbn = GetCellStrValue(sRow, colIndexList[colIndex++]);             //項目特定区分
                    itemDto.inputkbn = GetCellStrValue(sRow, colIndexList[colIndex++]);                   //入力区分
                    itemDto.inputhoho = GetCellStrValue(sRow, colIndexList[colIndex++]);                  //入力方法
                    itemDto.hikisu = GetCellStrValue(sRow, colIndexList[colIndex++]);                     //引数
                    itemDto.jigyocd = GetCellStrValue(sRow, colIndexList[colIndex++]);                    //事業コード
                    itemDto.ketasu = GetCellIntValue(sRow, colIndexList[colIndex++]);                     //桁数
                    itemDto.syosuketasu = GetCellNIntValue(sRow, colIndexList[colIndex++]);               //桁数（小数部）
                    itemDto.width = GetCellIntValue(sRow, colIndexList[colIndex++]);                      //幅
                    itemDto.format = GetCellStrValue(sRow, colIndexList[colIndex++]);                     //フォーマット
                    itemDto.hissuflg = GetCellStrValue(sRow, colIndexList[colIndex++]);                   //必須フラグ	
                    value = GetCellStrValue(sRow, colIndexList[colIndex++]);                              //一意フラグ
                    itemDto.itiiflg = GetUploadFlgItemValue("一意フラグ", value, sheetNo, sheetName, rowIndex, ref errList);
                    itemDto.hyojiinputkbn = GetCellStrValue(sRow, colIndexList[colIndex++]);              //表示入力設定区分
                    itemDto.orderseq = GetCellNIntValue(sRow, colIndexList[colIndex++]);                  //並び順
                    itemDto.nendocheck = GetCellStrValue(sRow, colIndexList[colIndex++]);                 //年度チェック
                    value = GetCellStrValue(sRow, colIndexList[colIndex++]);                              //年度フラグ
                    itemDto.nendoflg = GetUploadFlgItemValue("年度フラグ", value, sheetNo, sheetName, rowIndex, ref errList);
                    itemDto.seikihyogen = GetCellStrValue(sRow, colIndexList[colIndex++]);                //正規表現
                    itemDto.minvalue = GetCellStrValue(sRow, colIndexList[colIndex++]);                   //最小値
                    itemDto.maxvalue = GetCellStrValue(sRow, colIndexList[colIndex++]);                   //最大値
                    itemDto.syokiti = GetCellStrValue(sRow, colIndexList[colIndex++]);                    //初期値
                    itemDto.koteiti = GetCellStrValue(sRow, colIndexList[colIndex++]);                    //固定値
                    itemDto.sansyomotofield = GetCellStrValue(sRow, colIndexList[colIndex++]);            //参照元フィールド
                    itemDto.sansyomotoseq = GetCellNIntValue(sRow, colIndexList[colIndex++]);             //参照元項目ID
                    itemDto.syutokusakifield = GetCellStrValue(sRow, colIndexList[colIndex++]);           //取得先フィールド
                    itemDto.masterchecktable = GetCellStrValue(sRow, colIndexList[colIndex++]);           //マスタチェックテーブル
                    itemDto.mastercheckjoken = GetCellStrValue(sRow, colIndexList[colIndex++]);           //マスタチェック条件
                    itemDto.mastercheckitem = GetCellStrValue(sRow, colIndexList[colIndex++]);            //マスタチェック項目
                    itemDto.jokenhissuerrorkbn = GetCellStrValue(sRow, colIndexList[colIndex++]);         //条件必須エラーレベル区分
                    itemDto.jokenhissuitemseq = GetCellNIntValue(sRow, colIndexList[colIndex++]);         //条件必須項目ID
                    itemDto.jokenhissuenzansi = GetCellStrValue(sRow, colIndexList[colIndex++]);          //条件必須演算子
                    itemDto.jokenhissuvalue = GetCellStrValue(sRow, colIndexList[colIndex++]);            //条件必須値

                    //演算子:between or not between
                    if (!string.IsNullOrEmpty(itemDto.jokenhissuenzansi)
                        && (itemDto.jokenhissuenzansi.Equals(EnumToStr(Enum演算子.between))
                        || itemDto.jokenhissuenzansi.Equals(EnumToStr(Enum演算子.not_between))))
                    {
                        //条件必須値
                        itemDto.jokenhissuvalue = itemDto.jokenhissuvalue + "," + GetCellStrValue(sRow, colIndexList[colIndex++]);
                    }

                    pageitemDtl.Add(itemDto);
                }

                //画面項目情報を取得する
                uploadData.pageitemList = Wraper.GetPageItemVMList(db, pageitemDtl, tableDtl, changeCodeMainDtl);
                //画面項目情報アップロード時必要なチェック
                subErrList = GetUploadPageItemErrorList(uploadData.pageitemList, sheetNo, sheetName, startRowIndex, db);
                errList.AddRange(subErrList);
            }

            //一括取込入力区分が[ファイル取込]の場合
            if (headDto.torinyuryokbn == EnumToStr(Enum取込区分.ファイル取込))
            {
                //※詳細画面:基本情報を取得する
                //定数定義
                sheetName = SHEET_NAME_FILEINFO;           //シート名
                startRowIndex = START_ROW_INDEX_FILEINFO;  //スタート行インデックス
                sheetNo = SHEET_NO_FILEINFO;               //シートNo
                sheet = book.GetSheet(sheetName);

                rowIndex = startRowIndex;
                colIndex = 1;

                sRow = sheet.GetRow(0);

                //取込基本情報マスタ
                var fileinfoDto = new tm_kktori_kihonDto();
                fileinfoDto.filekeisiki = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);        //ファイル形式
                fileinfoDto.fileencode = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);         //エンコード
                fileinfoDto.filenm = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);             //ファイル名称
                value = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);                        　//正規表現
                fileinfoDto.seikihyogen = GetUploadFlgItemValue("正規表現", value, sheetNo, sheetName, rowIndex, ref errList);
                fileinfoDto.datakeisiki = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);        //データ形式
                fileinfoDto.recordlen = GetCellNIntValue(sheet.GetRow(rowIndex++), colIndex);         //レコード長
                fileinfoDto.inyofusonzaikbn = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);    //引用符
                fileinfoDto.kugirikigo = GetCellStrValue(sheet.GetRow(rowIndex++), colIndex);         //区切り記号
                fileinfoDto.headerrows = GetCellIntValue(sheet.GetRow(rowIndex++), colIndex);         //ヘッダー行
                fileinfoDto.footerrows = GetCellIntValue(sheet.GetRow(rowIndex++), colIndex);         //フッター行

                //基本情報を取得する
                uploadData.fileinfoData = Wraper.GetFileInfoVM(fileinfoDto);
                //取込ファイル基本情報アップロード時必要なチェック
                subErrList = GetUploadFileInfoErrorList(db, uploadData.fileinfoData, sheetNo, sheetName);
                errList.AddRange(subErrList);

                //※詳細画面:ファイルI/F情報を取得する
                //定数定義
                sheetName = SHEET_NAME_FILEIF;          //シート名
                startRowIndex = START_ROW_INDEX_FILEIF; //スタート行インデックス
                sheetNo = SHEET_NO_FILEIF;              //シートNo
                sheet = book.GetSheet(sheetName);
                //読込列インデックスリストを取得する
                firstRow = sheet.GetRow(0);
                colIndexList = GetColIndexList(firstRow);

                //取込IFマスタリスト
                var fileifDtl = new List<tm_kktori_interfaceDto>();

                for (rowIndex = startRowIndex; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    sRow = sheet.GetRow(rowIndex);
                    colIndex = 0;

                    //空白行の場合　または　「№」列空白の場合、読み込み終了とする
                    if (IsRowBlank(sRow) || GetCellNIntValue(sRow, colIndexList[0]) == null)
                    {
                        break;
                    }

                    //取込IFマスタ
                    var fileIfDto = new tm_kktori_interfaceDto();
                    fileIfDto.fileitemseq = GetCellIntValue(sRow, colIndexList[colIndex++]);     //№
                    fileIfDto.itemnm = GetCellStrValue(sRow, colIndexList[colIndex++]);          //項目名称
                    value = GetCellStrValue(sRow, colIndexList[colIndex++]);                     //キー(参照)
                    fileIfDto.keyflg = GetUploadFlgItemValue("キー(参照)", value, sheetNo, sheetName, rowIndex, ref errList);
                    value = GetCellStrValue(sRow, colIndexList[colIndex++]);                     //必須(参照)
                    fileIfDto.hissuflg = GetUploadFlgItemValue("必須(参照)", value, sheetNo, sheetName, rowIndex, ref errList);
                    fileIfDto.datatype = GetCellStrValue(sRow, colIndexList[colIndex++]);        //データ型
                    fileIfDto.ketasu = GetCellIntValue(sRow, colIndexList[colIndex++]);          //桁数（整数部）
                    fileIfDto.syosuketasu = GetCellNIntValue(sRow, colIndexList[colIndex++]);    //桁数（小数部）
                    fileIfDto.format = GetCellStrValue(sRow, colIndexList[colIndex++]);          //フォーマット
                    fileIfDto.formatcheck = GetCellStrValue(sRow, colIndexList[colIndex++]);     //フォーマットチェック
                    fileIfDto.formathenkan = GetCellStrValue(sRow, colIndexList[colIndex++]);    //フォーマット変換
                    fileIfDto.biko = GetCellStrValue(sRow, colIndexList[colIndex++]);            //備考

                    fileifDtl.Add(fileIfDto);
                }

                //ファイルI/F情報を取得する
                uploadData.fileifList = Wraper.GetFileIFVMList(db, fileifDtl);
                //取込設定アップロードエラーを取得する(取込ファイルIF）
                subErrList = GetUploadFileIfErrorList(uploadData.fileifList, sheetNo, sheetName, startRowIndex);
                errList.AddRange(subErrList);


                //※詳細画面:取込コード変換情報を取得する
                //定数定義
                sheetName = SHEET_NAME_CHANGECODE;          //シート名
                startRowIndex = START_ROW_INDEX_CHANGECODE; //スタート行インデックス
                sheetNo = SHEET_NO_CHANGECODE;              //シートNo
                sheet = book.GetSheet(sheetName);
                //読込列インデックスリストを取得する
                firstRow = sheet.GetRow(0);
                colIndexList = GetColIndexList(firstRow);

                //取込変換コードマスタ
                var codeDtl = new List<tm_kktori_henkancodeDto>();

                for (rowIndex = startRowIndex; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    sRow = sheet.GetRow(rowIndex);
                    colIndex = 0;

                    //空白行の場合　または　「コード変換区分」列空白の場合、読み込み終了とする
                    if (IsRowBlank(sRow) || GetCellNIntValue(sRow, colIndexList[0]) == null)
                    {
                        break;
                    }
                    //取込変換コードマスタ
                    var codeDto = new tm_kktori_henkancodeDto();
                    codeDto.codehenkankbn = GetCellIntValue(sRow, colIndexList[colIndex++]);      //コード変換区分
                    codeDto.motocd = GetCellStrValue(sRow, colIndexList[colIndex++]);             //元コード
                    codeDto.motocdcomment = GetCellStrValue(sRow, colIndexList[colIndex++]);      //元コード説明
                    codeDto.henkangocd = GetCellStrValue(sRow, colIndexList[colIndex++]);         //変換後コード
                    codeDto.henkangocdcomment = GetCellStrValue(sRow, colIndexList[colIndex++]);  //変換後コード説明

                    codeDtl.Add(codeDto);
                }

                //取込変換コード情報を取得する
                uploadData.codechangeList = Wraper.GetCodeChangeVMList(codeDtl);
                //取込設定アップロードエラーを取得する(変換コード）
                subErrList = GetUploadChangeCodeErrorList(db, codeDtl, uploadData, sheetNo, sheetName, startRowIndex);
                errList.AddRange(subErrList);


                //※詳細画面:マッピング設定情報を取得する
                //定数定義
                sheetName = SHEET_NAME_ITEMMAP;          //シート名
                startRowIndex = START_ROW_INDEX_ITEMMAP; //スタート行インデックス
                sheetNo = SHEET_NO_ITEMMAP;              //シートNo
                sheet = book.GetSheet(sheetName);
                //読込列インデックスリストを取得する
                firstRow = sheet.GetRow(0);
                colIndexList = GetColIndexList(firstRow);

                //取込項目マッピングマスタ
                var itemmappingDtl = new List<tm_kktori_mappingDto>();

                for (rowIndex = startRowIndex; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    sRow = sheet.GetRow(rowIndex);
                    colIndex = 0;
                    //空白行の場合　または　「画面項目ID」列空白の場合、読み込み終了とする
                    if (IsRowBlank(sRow) || GetCellNIntValue(sRow, colIndexList[0]) == null)
                    {
                        break;
                    }

                    //取込項目マッピングマスタ
                    var mapDto = new tm_kktori_mappingDto();
                    mapDto.gamenitemseq = GetCellIntValue(sRow, colIndexList[colIndex++]);       //画面項目ID
                    mapDto.mappingkbn = GetCellStrValue(sRow, colIndexList[colIndex++]);         //マッピング区分
                    mapDto.mappinghoho = GetCellStrValue(sRow, colIndexList[colIndex++]);        //マッピング方法
                    mapDto.fileitemseq = GetCellStrValue(sRow, colIndexList[colIndex++]);        //ファイル項目
                    mapDto.siteiketasufrom = GetCellNIntValue(sRow, colIndexList[colIndex++]);   //指定桁数（開始）
                    mapDto.siteiketasuto = GetCellNIntValue(sRow, colIndexList[colIndex++]);     //指定桁数（終了）

                    itemmappingDtl.Add(mapDto);
                }

                //マッピング設定情報を取得する
                uploadData.itemmappingList = Wraper.GetItemMappingVMList(db, itemmappingDtl, uploadData.fileifList, uploadData.pageitemList);
                //取込設定アップロードエラーを取得する(マッピング設定）
                subErrList = GetUploadItemMappingErrorList(db, uploadData.itemmappingList, uploadData.pageitemList, uploadData.fileifList, sheetNo, sheetName, startRowIndex);
                errList.AddRange(subErrList);
            }

            //※詳細画面:登録仕様情報を取得する
            //定数定義
            sheetName = SHEET_NAME_INSERT;          //シート名
            startRowIndex = START_ROW_INDEX_INSERT; //スタート行インデックス
            sheetNo = SHEET_NO_INSERT;              //シートNo
            sheet = book.GetSheet(sheetName);
            //読込列インデックスリストを取得する
            firstRow = sheet.GetRow(0);
            colIndexList = GetColIndexList(firstRow);

            //一括取込入力登録マスタ
            var insertdetailDtl = new List<tm_kktorinyuryoku_torokuDto>();
            for (rowIndex = startRowIndex; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                sRow = sheet.GetRow(rowIndex);
                colIndex = 0;
                //空白行の場合　または　「テーブル物理名」列空白の場合、読み込み終了とする 
                if (IsRowBlank(sRow) || string.IsNullOrEmpty(GetCellStrValue(sRow, colIndexList[0])))
                {
                    break;
                }

                //一括取込入力登録マスタ
                var insertDto = new tm_kktorinyuryoku_torokuDto();
                insertDto.tableid = GetCellStrValue(sRow, colIndexList[colIndex++]);          //テーブル物理名
                insertDto.recordno = GetCellIntValue(sRow, colIndexList[colIndex++]);         //レコードNo
                insertDto.fieldnm = GetCellStrValue(sRow, colIndexList[colIndex++]);          //フィールド物理名
                insertDto.syorikbn = GetCellStrValue(sRow, colIndexList[colIndex++]);         //処理区分
                insertDto.datamotoitemseq = GetCellNIntValue(sRow, colIndexList[colIndex++]); //データ元画面項目ID
                insertDto.koteiti = GetCellStrValue(sRow, colIndexList[colIndex++]);          //固定値
                insertDto.datamototablenm = GetCellStrValue(sRow, colIndexList[colIndex++]);  //データ元テーブル
                insertDto.datamotofieldnm = GetCellStrValue(sRow, colIndexList[colIndex++]);  //データ元フィールド
                insertDto.saibankey = GetCellStrValue(sRow, colIndexList[colIndex++]);        //採番キー

                insertdetailDtl.Add(insertDto);
            }

            //テーブルidリスト
            var tableidList = insertdetailDtl.Select(e => e.tableid).Distinct().ToList();
            //登録仕様情報を取得する
            uploadData.insertList = Wraper.GetInsertVMList(db, insertdetailDtl, tableDtl, tableidList, uploadData.pageitemList);

            //取込設定アップロードエラーを取得する(登録仕様）
            subErrList = GetUploadInsertDetailErrorList(db, insertdetailDtl, sheetNo, sheetName, startRowIndex, uploadData);
            errList.AddRange(subErrList);

            return "";
        }

        /// <summary>
        /// 読込列インデックスリストを取得する
        /// </summary>
        private List<int> GetColIndexList(IRow firstRow)
        {
            var colIndexList = new List<int>();
            for (int i = 1; i < firstRow.Cells.Count; i++)
            {
                if (firstRow.Cells[i].StringCellValue == "●")
                {
                    colIndexList.Add(firstRow.Cells[i].ColumnIndex);
                }
            }
            return colIndexList;
        }

        /// <summary>
        /// EXCELの一括入力No存在チェック
        /// </summary>
        private string CheckUploadImpno(Enum編集区分 editkbn, tm_kktorinyuryokuDto? kkimpDto, string fileImpno)
        {
            //「アップロード(更新)」の場合(一覧画面で選択した行の取込設定を更新する。)
            if (editkbn == Enum編集区分.変更)
            {
                //既存データ存在しない場合はエラー
                if (kkimpDto == null)
                {
                    return DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "対象", "アップロード実行");
                }
            }
            else//「アップロード(新規)」の場合
            {
                //既存データ存在する場合はエラー
                if (kkimpDto != null)
                {
                    //エラーメッセージ設定
                    return DaMessageService.GetMsg(EnumMessage.E002003, "一括取込入力No");
                }
            }
            return "";
        }

        /// <summary>
        /// 出力エラーファイルデータを取得
        /// </summary>
        private byte[] GetUploadErrorData(List<UploadErrorVM> errList)
        {
            //シートNoリスト
            errList = errList.OrderBy(x => x.sheetNo).ThenBy(x => CInt(x.rowIndex)).ToList();

            //一時出力エラーファイル名取得
            var errTempFileName = Path.GetTempFileName();

            var excelReprot = new ExcelLogger();

            //エラーファイル出力
            //定数定義
            var sheetName = "エラー一覧";
            var sStr0 = "No,シート,行,項目名（タイトル名）,項目値,エラー内容";
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
            //明細行
            for (int i = 0; i < errList.Count; i++)
            {
                colIndex = 0;
                excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, i + 1);                  //No
                excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, errList[i].sheetName);   //シート
                excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, errList[i].rowIndex);    //行
                excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, errList[i].title);       //項目名（タイトル名）
                excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, errList[i].itemValue);   //項目値
                excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, errList[i].errMsg);      //エラー内容
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
        /// 取込設定アップロードエラーを取得する(ヘッダー情報）
        /// </summary>
        private List<UploadErrorVM> GetUploadHeadErrorList(DaDbContext db, HeaderVM headData, int sheetNo, string sheetName,
            List<tm_kktorinyuryoku_tableDto> tableDtl)
        {
            var errList = new List<UploadErrorVM>();

            //【業務区分】存在チェック
            CheckUploadExistErrorFromNameList("業務区分", headData.gyoumukbn, db, EnumNmKbn.取込業務区分, sheetNo, sheetName, 3, ref errList);
            //【一括取込入力区分】存在チェック
            CheckUploadExistErrorFromNameList("一括取込入力区分", headData.impkbn, db, EnumNmKbn.取込区分, sheetNo, sheetName, 6, ref errList);
            //【年度範囲区分】存在チェック
            CheckUploadExistErrorFromNameList("年度範囲区分", CStr(headData.nendohanikbn), db, EnumNmKbn.年度範囲区分, sheetNo, sheetName, 8, ref errList);
            //【登録区分】存在チェック
            CheckUploadExistErrorFromNameList("登録区分", headData.regupdkbn, db, EnumNmKbn.登録区分, sheetNo, sheetName, 9, ref errList);

            //【並び順シーケンス】重複チェック   (「業務区分」「一括取込入力区分」単位（メニュー単位）で重複しない)
            var errMsg = CheckOrderseqMsg(db, headData.gyoumukbn, headData.impkbn, headData.orderseq, headData.impno);
            if (!string.IsNullOrEmpty(errMsg))
            {
                var err = GetUploadErrorDetail(sheetNo, sheetName, 9, "並び順シーケンス", CStr(headData.orderseq), errMsg);
                errList.Add(err);
            }

            //【テーブル】存在チェック
            var tableidIndex = 10;
            foreach (string tableid in headData.tableidList)
            {
                //対象テーブル存在
                var tableDto = tableDtl.Find(e => e.tablenm == tableid && e.imptaisyoflg);
                if (tableDto == null)
                {
                    errMsg = DaMessageService.GetMsg(EnumMessage.E003005, TM_KKIMPTABLE_TABLE_NAME);
                    var err = GetUploadErrorDetail(sheetNo, sheetName, tableidIndex, "テーブル", tableid, errMsg);
                    errList.Add(err);
                }
                tableidIndex++;
            }
            //プロシージャ存在チェック
            var procIndex = 20;
            var procList = new List<string?>
            {
                headData.procchk,
                headData.procbefore,
                headData.procafter
            };

            foreach (var proc in procList)
            {
                if (!string.IsNullOrEmpty(proc))
                {
                    var procDto = db.tm_kktorinyuryoku_proc.SELECT.WHERE.ByItem(nameof(tm_kktorinyuryoku_procDto.procnm), proc).GetDto();
                    if (procDto == null)
                    {
                        //エラーメッセージ設定
                        errMsg = DaMessageService.GetMsg(EnumMessage.E003005, "一括取込入力プロシージャマスタ");
                        var err = GetUploadErrorDetail(sheetNo, sheetName, procIndex, "プロシージャ", proc, errMsg);
                        errList.Add(err);
                    }
                }
                procIndex++;
            };
            //【一括取込入力No】桁数チェック
            CheckUploadDataLen("一括取込入力No", headData.impno, 4, sheetNo, sheetName, 4, ref errList);
            //【一括取込入力名】桁数チェック
            CheckUploadDataLen("一括取込入力名", headData.impnm, 50, sheetNo, sheetName, 5, ref errList);
            //【並び順シーケンス】桁数チェック
            CheckUploadDataLen("並び順シーケンス", CStr(headData.orderseq), 4, sheetNo, sheetName, 10, ref errList);
            //【説明】桁数チェック
            CheckUploadDataLen("説明", headData.memo, 100, sheetNo, sheetName, 11, ref errList);
            //【チェック用プロシージャ】桁数チェック
            CheckUploadDataLen("チェック用プロシージャ", headData.procchk, 100, sheetNo, sheetName, 22, ref errList);
            //【更新前プロシージャ】桁数チェック
            CheckUploadDataLen("更新前プロシージャ", headData.procbefore, 100, sheetNo, sheetName, 23, ref errList);
            //【更新後プロシージャ】桁数チェック
            CheckUploadDataLen("更新後プロシージャ", headData.procafter, 100, sheetNo, sheetName, 24, ref errList);


            return errList;
        }

        /// <summary>
        /// 取込設定アップロードエラーを取得する(変換コードメイン情報）
        /// </summary>
        private List<UploadErrorVM> GetUploadChangeCodeMainErrorList(DaDbContext db, List<ChangeCodeMainVM> changeCodeMainList, int sheetNo, string sheetName, int startRowIndex)
        {
            var errList = new List<UploadErrorVM>();

            //【コード変換区分】重複チェック
            bool hasDuplicates = changeCodeMainList.GroupBy(item => item.codehenkankbn).Any(group => group.Count() > 1);
            if (hasDuplicates)
            {
                var errMsg = DaMessageService.GetMsg(EnumMessage.E001008, "項目No");
                var err = GetUploadErrorDetail(sheetNo, sheetName, 0, "項目No", "", errMsg);
                errList.Add(err);
            }

            foreach (var vm in changeCodeMainList)
            {
                var iRowIndex = ++startRowIndex;

                //【コード変換区分】桁数チェック
                CheckUploadDataLen("コード変換区分", CStr(vm.codehenkankbn), 4, sheetNo, sheetName, iRowIndex, ref errList);

                //【変換区分名称】桁数チェック
                CheckUploadDataLen("変換区分名称", vm.henkankbnnm, 30, sheetNo, sheetName, iRowIndex, ref errList);

                //【その他条件】桁数チェック
                CheckUploadDataLen("その他条件", vm.sonotajoken, 200, sheetNo, sheetName, iRowIndex, ref errList);

                //コード管理テーブル名
                var tableid = vm.codekanritablenm;

                //【コード管理テーブル名】存在チェック
                var dtl = DaNameService.GetNameList(db, EnumNmKbn.コード管理テーブル);
                var dto = dtl.Find(e => e.nmcd == tableid);
                if (dto == null)
                {
                    var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, "コード管理テーブル名");
                    var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "コード管理テーブル名", tableid, errMsg);
                    errList.Add(err);
                    continue;
                }

                //【コード管理テーブル名】は名称マスタの場合
                if (tableid.Equals(tm_afmeisyoDto.TABLE_NAME))
                {
                    var maincdList = DaNameService.GetSelectorList(db, EnumNmKbn.名称マスタメインコード, Enum名称区分.名称);
                    //メインコード存在しない場合
                    if (!maincdList.Exists(e => e.value == vm.maincd))
                    {
                        var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, "名称マスタ");
                        var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "メインコード", vm.maincd, errMsg);
                        errList.Add(err);
                    }
                    else
                    {
                        //名称メインマスタ
                        var subcdDto = db.tm_afmeisyo_main.GetDtoByKey(vm.maincd, CInt(vm.subcd));
                        //サブコード存在しない場合
                        if (subcdDto == null)
                        {
                            var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, "名称メインマスタ");
                            var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "サブコード", vm.subcd, errMsg);
                            errList.Add(err);
                        }
                    }
                }

                //【コード管理テーブル名】が汎用マスタの場合
                else if (tableid.Equals(tm_afhanyoDto.TABLE_NAME))
                {
                    var maincdList = DaNameService.GetSelectorList(db, EnumNmKbn.汎用マスタメインコード, Enum名称区分.名称);
                    //メインコード存在しない場合
                    if (!maincdList.Exists(e => e.value == vm.maincd))
                    {
                        var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, "名称マスタ");
                        var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "メインコード", vm.maincd, errMsg);
                        errList.Add(err);
                    }
                    else
                    {
                        //汎用メインマスタ
                        var subcdDto = db.tm_afhanyo_main.GetDtoByKey(vm.maincd, CInt(vm.subcd));
                        //サブコード存在しない場合
                        if (subcdDto == null)
                        {
                            var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, "汎用メインマスタ");
                            var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "サブコード", vm.subcd, errMsg);
                            errList.Add(err);
                        }
                    }
                }
            }

            return errList;
        }

        /// <summary>
        /// 取込設定アップロードエラーを取得する(取込ファイル基本情報）
        /// </summary>
        private List<UploadErrorVM> GetUploadFileInfoErrorList(DaDbContext db, FileInfoVM fileinfoData, int sheetNo, string sheetName)
        {
            var errList = new List<UploadErrorVM>();

            //【ファイル形式】存在チェック
            CheckUploadExistErrorFromNameList2("ファイル形式", fileinfoData.filetype, db, EnumNmKbn.ファイル形式, sheetNo, sheetName, 2, ref errList);
            //【エンコード】存在チェック
            CheckUploadExistErrorFromNameList("エンコード", fileinfoData.fileencode, db, EnumNmKbn.エンコード, sheetNo, sheetName, 3, ref errList);
            //【データ形式】存在チェック
            CheckUploadExistErrorFromNameList2("データ形式", fileinfoData.datakbn, db, EnumNmKbn.データ形式, sheetNo, sheetName, 6, ref errList);

            //データ形式が可変長の場合
            if (ParseEnum<Enumデータ形式>(fileinfoData.datakbn) == Enumデータ形式.可変長)
            {
                //【引用符】存在チェック
                CheckUploadExistErrorFromNameList("引用符", CStr(fileinfoData.quoteskbn), db, EnumNmKbn.引用符_CSV出力用, sheetNo, sheetName, 9, ref errList);
                //【区切り記号】存在チェック
                CheckUploadExistErrorFromNameList("区切り記号", CStr(fileinfoData.dividekbn), db, EnumNmKbn.区切り記号, sheetNo, sheetName, 10, ref errList);
            }

            //【ファイル名称】桁数チェック
            CheckUploadDataLen("ファイル名称", fileinfoData.filenmrule, 50, sheetNo, sheetName, 4, ref errList);
            //【レコード長】桁数チェック
            CheckUploadDataLen("レコード長", CStr(fileinfoData.recordlen), 8, sheetNo, sheetName, 8, ref errList);
            //【ヘッダー行数】桁数チェック
            CheckUploadDataLen("ヘッダー行数", CStr(fileinfoData.headerrows), 3, sheetNo, sheetName, 11, ref errList);
            //【フッター行数】桁数チェック
            CheckUploadDataLen("フッター行数", CStr(fileinfoData.footerrows), 3, sheetNo, sheetName, 12, ref errList);

            return errList;
        }

        /// <summary>
        /// 取込設定アップロードエラーを取得する(取込ファイルIF）
        /// </summary>
        private List<UploadErrorVM> GetUploadFileIfErrorList(List<FileIFVM> fileifList, int sheetNo, string sheetName, int startRowIndex)
        {
            var errList = new List<UploadErrorVM>();

            foreach (var vm in fileifList)
            {
                var iRowIndex = ++startRowIndex;
                //【データ型】存在チェック
                CheckUploadExistErrorByName("データ型", vm.datatype, vm.datatypeName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);
                //【フォーマット】存在チェック
                CheckUploadExistErrorByName("フォーマット", vm.format, vm.formatName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);
                //【フォーマットチェック】存在チェック
                CheckUploadExistErrorByName("フォーマットチェック", vm.fmtcheck, vm.fmtcheckName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);
                //【フォーマット変換】存在チェック
                CheckUploadExistErrorByName("フォーマット変換", vm.fmtchange, vm.fmtchangeName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);

                //【項目名称】桁数チェック
                CheckUploadDataLen("項目名称", vm.itemnm, 100, sheetNo, sheetName, iRowIndex, ref errList);
                //【桁数】桁数チェック
                CheckUploadDataLen("桁数", CStr(vm.len), 3, sheetNo, sheetName, iRowIndex, ref errList);
                //【桁数-小数部】桁数チェック
                CheckUploadDataLen("桁数-小数部", CStr(vm.len2), 3, sheetNo, sheetName, iRowIndex, ref errList);
                //【備考】桁数チェック
                CheckUploadDataLen("備考", vm.memo, 30, sheetNo, sheetName, iRowIndex, ref errList);
            }

            return errList;
        }

        /// <summary>
        /// 取込設定アップロードエラーを取得する(画面項目定義）
        /// </summary>
        private List<UploadErrorVM> GetUploadPageItemErrorList(List<PageItemVM> pageitemList, int sheetNo, string sheetName, int startRowIndex, DaDbContext db)
        {
            var errList = new List<UploadErrorVM>();

            //項目Noリスト
            var seqList = new List<int>();
            //ワークテーブルカラム名リスト
            var wktablenmList = new List<string>();
            foreach (var vm in pageitemList)
            {
                var iRowIndex = ++startRowIndex;

                //【項目No】重複チェック
                if (seqList.Contains(vm.pageitemseq))
                {
                    var errMsg = DaMessageService.GetMsg(EnumMessage.E001008, "項目No");
                    var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "項目No", CStr(vm.pageitemseq), errMsg);
                    errList.Add(err);
                }

                seqList.Add(vm.pageitemseq);

                //【ワークテーブルカラム名】重複チェック
                if (wktablenmList.Contains(vm.wktablecolnm))
                {
                    var errMsg = DaMessageService.GetMsg(EnumMessage.E001008, "ワークテーブルカラム名");
                    var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "ワークテーブルカラム名", CStr(vm.wktablecolnm), errMsg);
                    errList.Add(err);
                }
                wktablenmList.Add(vm.wktablecolnm);

                //画面項目定義の入力区分は関数の場合
                if (vm.inputkbn.Equals(EnumToStr(Enum入力区分.関数)) && !string.IsNullOrEmpty(vm.inputtype))
                {
                    string errMsg;
                    //関数のパラメーター数チェック
                    errMsg = CheckUploadMethodParamNum(db, vm.inputtype, vm.hikisu, EnumNmKbn.入力方法);
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "引数", CStr(vm.hikisu), errMsg);
                        errList.Add(err);
                    }
                    //引数値の存在チェック
                    //画面項目の引数を取得
                    var hikisuList = CStr(vm.hikisu).Split(',').Where(e => !e.Contains("'")).ToArray();
                    foreach (var hikisu in hikisuList)
                    {
                        var item = pageitemList.Find(e => e.pageitemseq == CInt(hikisu));
                        //引数値が画面項目に存在しない場合
                        if (item == null)
                        {
                            errMsg = DaMessageService.GetMsg(EnumMessage.E003005, $"引数値が画面項目");
                            var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "引数", CStr(vm.hikisu), errMsg);
                            errList.Add(err);
                        }
                    }

                }

                //【入力区分】存在チェック
                CheckUploadExistErrorByName("入力区分", vm.inputkbn, vm.inputkbnName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);
                //【フォーマット】存在チェック
                CheckUploadExistErrorByName("フォーマット", vm.format, vm.formatName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);
                //【必須フラグ】存在チェック
                CheckUploadExistErrorByName("必須フラグ", vm.requiredflg, vm.requiredflgName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);
                //【表示入力設定区分】存在チェック
                CheckUploadExistErrorByName("表示入力設定区分", vm.dispinputkbn, vm.dispinputkbnName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);

                //【正規表現】合法性チェック
                if (!string.IsNullOrEmpty(vm.seiki) && !CheckRegexMatch(vm.seiki))
                {
                    var errMsg = DaMessageService.GetMsg(EnumMessage.E003006, "正規表現");
                    var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "正規表現", vm.seiki, errMsg);
                    errList.Add(err);
                }

                //【入力区分（名称）】ありの場合
                if (!string.IsNullOrEmpty(vm.inputkbnName))
                {

                    if (vm.inputkbn == EnumToStr(Enum入力区分.マスタ参照))
                    {
                        //【入力方法】存在チェック
                        CheckUploadExistErrorByName("入力方法", vm.inputtype, vm.inputtypeName, TM_KKIMPTABLE_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);

                        //【参照元画面項目】存在チェック
                        CheckUploadExistErrorByName("参照元画面項目", CStr(vm.fromitemseq), vm.fromitemseqName, "画面項目定義", sheetNo, sheetName, iRowIndex, ref errList);

                        if (!string.IsNullOrEmpty(vm.inputtypeName))
                        {
                            //【参照元フィールド】存在チェック
                            CheckUploadExistErrorByName("参照元フィールド", CStr(vm.fromfieldid), vm.fromfieldidName, vm.inputtypeName, sheetNo, sheetName, iRowIndex, ref errList);
                            //【取得先フィールド】存在チェック
                            CheckUploadExistErrorByName("取得先フィールド", CStr(vm.targetfieldid), vm.targetfieldidName, vm.inputtypeName, sheetNo, sheetName, iRowIndex, ref errList);
                        }
                    }
                    else if (vm.inputkbn == EnumToStr(Enum入力区分.コード系))
                    {
                        //【入力方法】存在チェック
                        CheckUploadExistErrorByName("入力方法", vm.inputtype, vm.inputtypeName, TM_KKIMPCODEHENKANMAIN_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);
                    }
                    else
                    {
                        //【入力方法】存在チェック
                        CheckUploadExistErrorByName("入力方法", vm.inputtype, vm.inputtypeName, MEISYO_TABLE_NAME + "の該当入力区分", sheetNo, sheetName, iRowIndex, ref errList);

                        if (vm.inputtype.Equals(EnumToStr(Enum入力方法.医療機関)) || vm.inputtype.Equals(EnumToStr(Enum入力方法.事業従事者)) || vm.inputtype.Equals(EnumToStr(Enum入力方法.事業従事者)))
                        {
                            //【実施事業】存在チェック
                            CheckUploadExistErrorByNames(errList, sheetNo, sheetName, iRowIndex, "実施事業", vm.jigyocd, vm.jigyocdName, HANYO_TABLE_NAME, true);
                        }
                    }
                }

                //【マスタチェックテーブル】存在チェック
                CheckUploadExistErrorByName("マスタチェックテーブル", CStr(vm.msttable), vm.msttableName, TM_KKIMPTABLE_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);
                if (!string.IsNullOrEmpty(vm.msttableName))
                {
                    //【マスタチェック項目】存在チェック
                    CheckUploadExistErrorByName("マスタチェック項目", CStr(vm.mstfield), vm.mstfieldName, vm.msttableName, sheetNo, sheetName, iRowIndex, ref errList);
                }

                //【年度チェック】存在チェック
                CheckUploadExistErrorByName("年度チェック", vm.yearchkflg, vm.yearchkflgName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);

                //【条件必須エラーレベル区分】存在チェック
                CheckUploadExistErrorByName("条件必須エラーレベル区分", vm.jherrlelkbn, vm.jherrlelkbnName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);
                //【条件必須項目】存在チェック
                CheckUploadExistErrorByName("条件必須項目", CStr(vm.jhitemseq), vm.jhitemseqName, "画面項目定義", sheetNo, sheetName, iRowIndex, ref errList);
                //【条件必須演算子】存在チェック
                CheckUploadExistErrorByName("条件必須演算子", CStr(vm.jhenzan), vm.jhenzanName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);
                //【項目特定区分】存在チェック
                CheckUploadExistErrorByName("項目特定区分", CStr(vm.itemkbn), vm.itemkbnName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);

                //【項目名】桁数チェック
                CheckUploadDataLen("項目名", CStr(vm.itemnm), 100, sheetNo, sheetName, iRowIndex, ref errList);
                //【ワークテーブルカラム名】桁数チェック
                CheckUploadDataLen("ワークテーブルカラム名", CStr(vm.wktablecolnm), 100, sheetNo, sheetName, iRowIndex, ref errList);
                //【桁数】桁数チェック
                CheckUploadDataLen("桁数", CStr(vm.len), 3, sheetNo, sheetName, iRowIndex, ref errList);
                //【桁数（小数部）】桁数チェック
                CheckUploadDataLen("桁数（小数部）", CStr(vm.len2), 3, sheetNo, sheetName, iRowIndex, ref errList);
                //【幅】桁数チェック
                CheckUploadDataLen("幅", CStr(vm.width), 3, sheetNo, sheetName, iRowIndex, ref errList);
                //【並び順】桁数チェック
                CheckUploadDataLen("並び順", CStr(vm.sortno), 3, sheetNo, sheetName, iRowIndex, ref errList);
                //【正規表現】桁数チェック
                CheckUploadDataLen("正規表現", vm.seiki, 100, sheetNo, sheetName, iRowIndex, ref errList);
                //【最小値】桁数チェック
                CheckUploadDataLen("最小値", vm.minval, 20, sheetNo, sheetName, iRowIndex, ref errList);
                //【最大値】桁数チェック
                CheckUploadDataLen("最大値", vm.maxval, 20, sheetNo, sheetName, iRowIndex, ref errList);
                //【初期値】桁数チェック
                CheckUploadDataLen("初期値", vm.defaultval, 100, sheetNo, sheetName, iRowIndex, ref errList);
                //【固定値】桁数チェック
                CheckUploadDataLen("固定値", vm.fixedval, 100, sheetNo, sheetName, iRowIndex, ref errList);
                //【マスタ存在ー条件Sql】桁数チェック
                CheckUploadDataLen("マスタ存在ー条件Sql", vm.mstjyoken, 50, sheetNo, sheetName, iRowIndex, ref errList);
                //【条件必須値】桁数チェック
                CheckUploadDataLen("条件必須値", vm.jhval, 50, sheetNo, sheetName, iRowIndex, ref errList);
            }

            return errList;
        }

        /// <summary>
        /// 取込設定アップロードエラーを取得する(変換コード情報）
        /// </summary>
        private List<UploadErrorVM> GetUploadChangeCodeErrorList(DaDbContext db, List<tm_kktori_henkancodeDto> codeDtl, UploadData uploadData, int sheetNo, string sheetName, int startRowIndex)
        {
            var errList = new List<UploadErrorVM>();

            //システムコード
            var systemcodeDic = new Dictionary<int, List<DaSelectorModel>>();

            foreach (var dto in codeDtl)
            {
                var iRowIndex = ++startRowIndex;

                //【コード変換区分】存在チェック
                var cdchangeDto = uploadData.changeCodeMainList.Find(x => x.codehenkankbn == dto.codehenkankbn);
                if (cdchangeDto == null)
                {
                    var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, TM_KKIMPCODEHENKANMAIN_TABLE_NAME);
                    var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "コード変換区分", CStr(dto.codehenkankbn), errMsg);
                    errList.Add(err);
                }

                //【変換後コード】存在チェック
                if (cdchangeDto != null && !string.IsNullOrEmpty(dto.henkangocd))
                {
                    //システムコード
                    if (!systemcodeDic.ContainsKey(dto.codehenkankbn))
                    {
                        var codeList = GetSysCodeList(db, cdchangeDto);
                        systemcodeDic.Add(dto.codehenkankbn, codeList);
                    }
                    var systemcodeList = systemcodeDic[cdchangeDto.codehenkankbn];

                    //システムコードの存在チェック
                    var systemcode = systemcodeList.Find(x => x.value == dto.henkangocd);
                    if (systemcode == null)
                    {
                        //名称マスタ
                        var tablenm = MEISYO_TABLE_NAME;
                        //汎用マスタ
                        if (cdchangeDto.codekanritablenm.Equals(tm_afhanyoDto.TABLE_NAME))
                        {
                            tablenm = HANYO_TABLE_NAME;
                        }

                        var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, tablenm);
                        var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "システムコード", dto.henkangocd, errMsg);
                        errList.Add(err);
                    }
                }

                //【ファイルコード】桁数チェック
                CheckUploadDataLen("ファイルコード", dto.motocd, 30, sheetNo, sheetName, iRowIndex, ref errList);
                //【ファイルコード説明】桁数チェック
                CheckUploadDataLen("ファイルコード説明", dto.motocdcomment, 200, sheetNo, sheetName, iRowIndex, ref errList);
                //【本システムコード説明】桁数チェック
                CheckUploadDataLen("本システムコード説明", dto.henkangocdcomment, 200, sheetNo, sheetName, iRowIndex, ref errList);
            }

            return errList;
        }

        /// <summary>
        /// 取込設定アップロードエラーを取得する(マッピング設定）
        /// </summary>
        private List<UploadErrorVM> GetUploadItemMappingErrorList(DaDbContext db, List<ItemMappingVM> itemmappingList, List<PageItemVM> pageitemList, List<FileIFVM> fileifList, int sheetNo, string sheetName, int startRowIndex)
        {
            var errList = new List<UploadErrorVM>();

            //画面項目数一致チェック
            if (pageitemList.Count != itemmappingList.Count)
            {
                var errMsg = DaMessageService.GetMsg(EnumMessage.E003008, "項目数", "項目定義の項目数");
                var err = GetUploadErrorDetail(sheetNo, sheetName, 0, "項目No", "", errMsg);
                errList.Add(err);
            }

            foreach (var vm in itemmappingList)
            {
                var iRowIndex = ++startRowIndex;

                //【項目No】存在チェック
                if (!pageitemList.Exists(e => e.pageitemseq == vm.pageitemseq))
                {
                    var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, "項目定義の項目No");
                    var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "項目No", CStr(vm.pageitemseq), errMsg);
                    errList.Add(err);
                }

                //【マッピング区分】存在チェック
                CheckUploadExistErrorByName("マッピング区分", vm.mappingkbn, vm.mappingkbnName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);
                //【マッピング方法】存在チェック
                CheckUploadExistErrorByName("マッピング方法", vm.mappingmethod, vm.mappingmethodName, MEISYO_TABLE_NAME, sheetNo, sheetName, iRowIndex, ref errList);

                //ファイル項目のマッピング区分は関数の場合
                if (vm.mappingkbn.Equals(EnumToStr(Enumマッピング区分.関数)) && !string.IsNullOrEmpty(vm.mappingmethod))
                {
                    string errMsg;
                    //関数のパラメーター数チェック
                    errMsg = CheckUploadMethodParamNum(db, vm.mappingmethod, vm.fileitemseq, EnumNmKbn.マッピング方法);
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "ファイル項目", CStr(vm.fileitemseq), errMsg);
                        errList.Add(err);
                    }
                    //引数値の存在チェック
                    //ファイル項目の引数値を取得
                    var seqList = CStr(vm.fileitemseq).Split(',').Where(e => !e.Contains("'")).ToArray();
                    foreach (var seq in seqList)
                    {
                        var item = fileifList.Find(e => e.fileitemseq == CInt(seq));
                        //引数値がファイル項目に存在しない場合
                        if (item == null)
                        {
                            errMsg = DaMessageService.GetMsg(EnumMessage.E003005, $"引数値がファイル項目");
                            var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "ファイル項目", CStr(vm.fileitemseq), errMsg);
                            errList.Add(err);
                        }
                    }
                }

                //【ファイル項目】桁数チェック
                CheckUploadDataLen("ファイル項目", vm.fileitemseq, 100, sheetNo, sheetName, iRowIndex, ref errList);
                //【項目名称】桁数チェック
                CheckUploadDataLen("項目名称", vm.pageitemnm, 30, sheetNo, sheetName, iRowIndex, ref errList);
                //【桁数指定開始】桁数チェック
                CheckUploadDataLen("桁数指定開始", CStr(vm.substrfrom), 3, sheetNo, sheetName, iRowIndex, ref errList);
                //【桁数指定終了】桁数チェック
                CheckUploadDataLen("桁数指定終了", CStr(vm.substrto), 3, sheetNo, sheetName, iRowIndex, ref errList);
            }

            return errList;
        }

        /// <summary>
        /// 取込設定アップロードエラーを取得する(登録仕様）
        /// </summary>
        private List<UploadErrorVM> GetUploadInsertDetailErrorList(DaDbContext db, List<tm_kktorinyuryoku_torokuDto> insertdetailDtl,
                                                            int sheetNo, string sheetName, int startRowIndex,
                                                            UploadData uploadData)
        {
            var errList = new List<UploadErrorVM>();

            foreach (var insertDto in insertdetailDtl)
            {
                var iRowIndex = ++startRowIndex;

                //【テーブル物理名】存在チェック
                if (!uploadData.hearderData.tableidList.Contains(insertDto.tableid))
                {
                    var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, "対象テーブル");
                    var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "テーブル物理名", insertDto.tableid, errMsg);
                    errList.Add(err);
                    continue;
                }
                //【フィールド物理名】存在チェック
                var name = Wraper.GetFieldLogicName(db, insertDto.tableid, insertDto.fieldnm);
                if (string.IsNullOrEmpty(name))
                {
                    var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, insertDto.tableid);
                    var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "フィールド物理名", insertDto.fieldnm, errMsg);
                    errList.Add(err);
                }
                //【処理区分】存在チェック
                if (!string.IsNullOrEmpty(insertDto.syorikbn))
                {
                    CheckUploadExistErrorFromNameList("処理区分", insertDto.syorikbn, db, EnumNmKbn.処理区分, sheetNo, sheetName, iRowIndex, ref errList);
                }
                //【データ元画面項目ID】存在チェック
                if (insertDto.datamotoitemseq != null)
                {
                    var pageItemDto = uploadData.pageitemList.Find(x => x.pageitemseq == insertDto.datamotoitemseq);
                    if (pageItemDto == null)
                    {
                        var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, "画面項目定義");
                        var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "データ元画面項目", CStr(insertDto.datamotoitemseq), errMsg);
                        errList.Add(err);
                    }
                }

                //処理区分が関連テーブルの項目から登録の場合
                if (insertDto.syorikbn == EnumToStr(Enum処理区分.関連テーブルの項目から登録))
                {
                    //データ元テーブル(論理名)入力チェック
                    if (string.IsNullOrEmpty(insertDto.datamototablenm))
                    {
                        var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, "取込対象テーブル");
                        var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "データ元テーブル", CStr(insertDto.datamototablenm), errMsg);
                        errList.Add(err);
                    }
                    //データ元テーブル(論理名)存在チェック
                    else if (!uploadData.hearderData.tableidList.Contains(insertDto.datamototablenm))
                    {
                        var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, insertDto.datamototablenm);
                        var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "データ元テーブル", insertDto.datamototablenm, errMsg);
                        errList.Add(err);
                    }
                    //データ元フィールド(論理名)入力チェック
                    else if (string.IsNullOrEmpty(insertDto.datamotofieldnm))
                    {
                        var errMsg = DaMessageService.GetMsg(EnumMessage.ITEM_REQUIRE_ERROR, "データ元フィールド");
                        var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "データ元フィールド", CStr(insertDto.datamotofieldnm), errMsg);
                        errList.Add(err);
                    }
                    else
                    {
                        //データ元フィールド(論理名)存在チェック
                        name = Wraper.GetFieldLogicName(db, insertDto.datamototablenm, insertDto.datamotofieldnm);
                        if (string.IsNullOrEmpty(name))
                        {
                            var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, insertDto.datamotofieldnm);
                            var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, "データ元フィールド", insertDto.datamotofieldnm, errMsg);
                            errList.Add(err);
                        }
                    }
                }

                //処理区分が手動採番の場合
                if (insertDto.syorikbn == EnumToStr(Enum処理区分.手動採番))
                {
                    //採番キー存在チェック
                    name = Wraper.GetFieldLogicNames(db, insertDto.tableid, insertDto.saibankey);
                    CheckUploadExistErrorByNames(errList, sheetNo, sheetName, iRowIndex, "採番キー", insertDto.saibankey, name, insertDto.tableid, false);
                }
            }

            return errList;
        }

        /// <summary>
        /// 取込設定アップロード：関数のパラメーター数チェック
        /// </summary>
        private string CheckUploadMethodParamNum(DaDbContext db, string method, string? itemseq, EnumNmKbn kbn)
        {
            var kbn2 = DaNameService.GetKbn2(db, kbn, method);
            if (!string.IsNullOrEmpty(kbn2) && int.TryParse(kbn2, out int paramLen))
            {
                if (CStr(itemseq).Split(',').Length != paramLen)
                {
                    var errMsg = DaMessageService.GetMsg(EnumMessage.ITEM_NOTEQUAL_ERROR, $"関数のパラメーター数({paramLen})");
                    return errMsg;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 取込設定アップロード：コード存在チェック
        /// </summary>
        private void CheckUploadExistErrorByName(string title, string? itemValue, string? itemName, string source, int sheetNo, string sheetName, int iRowIndex, ref List<UploadErrorVM> errList)
        {
            //存在チェック
            //値があり、名称がない場合、エラーとなる
            if (!string.IsNullOrEmpty(itemValue) && string.IsNullOrEmpty(itemName))
            {
                var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, source);
                var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, title, itemValue, errMsg);
                errList.Add(err);
            }
        }

        /// <summary>
        /// 取込設定アップロードエラー：複数コード存在チェック
        /// </summary>
        private void CheckUploadExistErrorByNames(List<UploadErrorVM> errList, int sheetNo, string sheetName, int iRowIndex, string title, string? itemValue, string? itemName, string source, bool isRequire)
        {
            //必須チェック
            //値がない場合、エラーとなる
            if (isRequire && string.IsNullOrEmpty(itemValue))
            {
                var errMsg = DaMessageService.GetMsg(EnumMessage.ITEM_REQUIRE_ERROR, source);
                var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, title, CStr(itemValue), errMsg);
                errList.Add(err);
            }

            //存在チェック
            //値があり、名称がない場合、エラーとなる
            if (!string.IsNullOrEmpty(itemValue)
                && (string.IsNullOrEmpty(itemName) || itemValue.Split(',').Length != itemName.Split(',').Length))
            {
                var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, source);
                var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, title, itemValue, errMsg);
                errList.Add(err);
            }
        }

        /// <summary>
        /// 取込設定アップロード：桁数チェック
        /// </summary>
        private void CheckUploadDataLen(string title, string? itemValue, int len, int sheetNo, string sheetName, int iRowIndex, ref List<UploadErrorVM> errList)
        {
            //桁数チェック
            if (!string.IsNullOrEmpty(itemValue) && itemValue.Length > len)
            {
                var errMsg = DaMessageService.GetMsg(EnumMessage.E003006, $"{title}の桁数({len})");
                var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, title, itemValue, errMsg);
                errList.Add(err);
                return;
            }
        }

        /// <summary>
        /// 取込設定アップロード：名称マスタに存在チェック
        /// </summary>
        private void CheckUploadExistErrorFromNameList(string title, string itemValue, DaDbContext db, EnumNmKbn kbn2, int sheetNo, string sheetName, int iRowIndex, ref List<UploadErrorVM> errList)
        {
            if (string.IsNullOrEmpty(itemValue))
            {
                return;
            }
            //名称取得
            var dto = DaNameService.GetNameList(db, kbn2).Find(x => x.nmcd == itemValue);
            if (dto == null)
            {
                var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, MEISYO_TABLE_NAME);
                var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, title, itemValue, errMsg);
                errList.Add(err);
            }
        }

        /// <summary>
        /// 取込設定アップロード：名称マスタに存在チェック
        /// </summary>
        private void CheckUploadExistErrorFromNameList2(string title, string itemValue, DaDbContext db, EnumNmKbn kbn2, int sheetNo, string sheetName, int iRowIndex, ref List<UploadErrorVM> errList)
        {
            if (string.IsNullOrEmpty(itemValue))
            {
                return;
            }
            //名称取得
            var dto = DaNameService.GetNameList(db, kbn2).Find(x => x.nmcd == itemValue && x.hanyokbn1 == "1");
            if (dto == null)
            {
                var errMsg = DaMessageService.GetMsg(EnumMessage.E003005, MEISYO_TABLE_NAME);
                var err = GetUploadErrorDetail(sheetNo, sheetName, iRowIndex, title, itemValue, errMsg);
                errList.Add(err);
            }
        }

        /// <summary>
        /// 取込設定アップロードデータを取得する（1、0のみ取得）
        /// </summary>
        private bool GetUploadFlgItemValue(string title, string value, int sheetNo, string sheetName, int rowIndex, ref List<UploadErrorVM> errList)
        {
            //1、0のみチェック
            if (!string.IsNullOrEmpty(value) && (!value.Equals("0") && !value.Equals("1")))
            {
                var errMsg = DaMessageService.GetMsg(EnumMessage.ITEM_REQUIRE_ERROR, "1、0のみ");

                var err = GetUploadErrorDetail(sheetNo, sheetName, rowIndex + 1, title, value, errMsg);
                errList.Add(err);
            }

            return CBool(value);
        }

        /// <summary>
        /// 取込設定アップロードエラーを取得する
        /// </summary>
        private UploadErrorVM GetUploadErrorDetail(int sheetNo, string sheetName, int? rowIndex, string title, string itemValue, string errMsg)
        {
            var err = new UploadErrorVM();
            err.sheetNo = sheetNo;                                  //シートNo
            err.sheetName = sheetName;                              //シート名
            err.rowIndex = rowIndex == null ? "" : CStr(rowIndex);  //行
            err.title = title;                                      //項目名（タイトル名）
            err.itemValue = itemValue;                              //項目値
            err.errMsg = errMsg;                                    //エラー内容
            return err;
        }

        /// <summary>
        /// 正規表現合法性チェック
        /// </summary>
        private bool CheckRegexMatch(string pattern)
        {
            try
            {
                var regex = new Regex(pattern);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <summary>
        /// 空白行チェック
        /// </summary>
        private bool IsRowBlank(IRow sRow)
        {
            if (sRow == null || sRow.Cells.Count == 0)
            {
                return true;
            }
            if (sRow.Cells[0].CellType == CellType.Blank)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 数値項目を取得する
        /// </summary>
        private int GetCellIntValue(IRow row, int cIndex)
        {
            if (row.Cells[cIndex].CellType == CellType.Numeric || row.Cells[cIndex].CellType == CellType.Blank)
            {
                return CInt(row.Cells[cIndex].NumericCellValue);
            }

            if (row.Cells[cIndex].CellType == CellType.String)
            {
                var value = row.Cells[cIndex].StringCellValue;
                if (!string.IsNullOrEmpty(value) && int.TryParse(value, out int intValue))
                {
                    return intValue;
                }
            }

            return 0;
        }

        /// <summary>
        /// 数値項目(空)を取得する
        /// </summary>
        private int? GetCellNIntValue(IRow row, int cIndex)
        {
            if (row.Cells[cIndex].CellType == CellType.Numeric)
            {
                return CNInt(row.Cells[cIndex].NumericCellValue);
            }

            if (row.Cells[cIndex].CellType == CellType.String)
            {
                var value = row.Cells[cIndex].StringCellValue;
                if (!string.IsNullOrEmpty(value) && int.TryParse(value, out int intValue))
                {
                    return intValue;
                }
            }

            return null;
        }

        /// <summary>
        /// 文字項目を取得する
        /// </summary>
        private string GetCellStrValue(IRow row, int cIndex)
        {
            if (row.Cells[cIndex].CellType == CellType.String)
            {
                return CStr(row.Cells[cIndex].StringCellValue);
            }
            if (row.Cells[cIndex].CellType == CellType.Numeric)
            {
                return CStr(row.Cells[cIndex].NumericCellValue);
            }

            return string.Empty;
        }

        #endregion

        /// <summary>
        /// 一括取込入力No手動採番(パッケージの意味(1桁) + 連番(3桁))
        /// </summary>
        private string GetImpno(DaDbContext db)
        {
            //自動採番MAX
            var maxseq = db.tm_kktorinyuryoku.SELECT.WHERE.ByFilter($"{nameof(tm_kktorinyuryokuDto.torinyuryokuno)} LIKE '1%'").GetMax<int>(nameof(tm_kktorinyuryokuDto.torinyuryokuno));
            if (maxseq != 0)
            {
                //自動採番MAX+1
                return CStr(maxseq + 1);
            }
            //初期値
            return "1001";
        }

        /// <summary>
        /// 登録チェック
        /// </summary>
        private string Check(DaDbContext db, SaveDetailRequest req, string impno)
        {
            if (req.editkbn == Enum編集区分.変更)
            {
                //関連チェック
                var msg = CheckKanrenTable(db, impno, "更新");
                if (!string.IsNullOrEmpty(msg))
                {
                    return msg;
                }
            }

            //「並び順」重複エラーチェック
            return CheckOrderseqMsg(db, req.hearderData.gyoumukbn, req.hearderData.impkbn, req.hearderData.orderseq, impno);
        }

        /// <summary>
        /// 「並び順」重複エラーチェック
        /// </summary>
        private string CheckOrderseqMsg(DaDbContext db, string gyoumukbn, string impkbn, int orderseq, string impno)
        {
            //「業務」と「一括取込入力区分」から一括取込入力マスタ取得
            tm_kktorinyuryokuDto dto = db.tm_kktorinyuryoku.SELECT.WHERE.ByItemList(
                new string[] {
                    nameof(tm_kktorinyuryokuDto.gyomukbn),
                    nameof(tm_kktorinyuryokuDto.torinyuryokbn),
                    nameof(tm_kktorinyuryokuDto.orderseq)
                },
                new List<object[]>() { new object[] { gyoumukbn, impkbn, orderseq } }).GetDto();

            //並び順存在した場合、エラーメッセージを表示する
            if (dto != null && (string.IsNullOrEmpty(impno) || !impno.Equals(dto.torinyuryokuno)))
            {
                //並び順が重複しています。既に使用されている{0}です。
                return DaMessageService.GetMsg(EnumMessage.E002003, "並び順");
            }

            return "";
        }

        /// <summary>
        /// 関連チェック
        /// </summary>
        private string CheckKanrenTable(DaDbContext db, string impno, string shori)
        {
            //一括取込入力未処理テーブル
            var kkimpdataDtl = db.tt_kktorinyuryoku_misyori.SELECT.WHERE.ByItem(nameof(tt_kktorinyuryoku_misyoriDto.torinyuryokuno), impno).GetDtoList();
            if (kkimpdataDtl != null && kkimpdataDtl.Count > 0)
            {
                //該当取込設定が取込実行に使用されています。{0}できません。
                return DaMessageService.GetMsg(EnumMessage.E014003, shori);
            }
            return string.Empty;
        }

        /// <summary>
        /// 値変換
        /// </summary>
        private string SetBoolStr(bool? obj)
        {
            if (CBool(obj))
            {
                return "1";
            }
            return "0";
        }
    }
}
