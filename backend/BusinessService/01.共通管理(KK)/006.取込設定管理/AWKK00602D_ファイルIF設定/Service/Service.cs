// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.ファイルIF情報ダイアログ画面
// 　　　　　　サービス処理
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00602D
{
    [DisplayName("取込設定：取込ファイルIF情報ダイアログ画面")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00602D = "AWKK00602D";

        [DisplayName("初期化処理(取込設定：取込ファイルIF情報ダイアログ画面)")]
        public InitResponse InitDetail(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var mainService = new AWKK00601G.Service();
                //ドロップダウンリストの初期化データ
                //【データ型】のドロップダウンリスト
                res.datatypeList = DaNameService.GetNameList(db, EnumNmKbn.入力方法).Where(x => x.hanyokbn1 == EnumToStr(Enum入力区分.テキスト)).Select(d => new DaSelectorModel(d.nmcd, d.nm)).OrderBy(o => CInt(o.value)).ToList();
                //【フォーマットチェック】のドロップダウンリスト
                res.fmtcheckList = mainService.GetNameSelectorList(db, EnumNmKbn.フォーマットチェック関数);
                //【フォーマット変換】のドロップダウンリスト
                res.fmtchangeList = mainService.GetNameSelectorList(db, EnumNmKbn.フォーマット変換関数);

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(フォーマット)")]
        public InitFormatListResponse InitFormatList(InitFormatListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitFormatListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //【フォーマット】のドロップダウンリスト
                res.formatList = DaNameService.GetNameList(db, EnumNmKbn.フォーマット_日付).Where(x => x.hanyokbn1 != null && x.hanyokbn1.Contains(req.datatype)).Select(d => new DaSelectorModel(d.nmcd, d.nm)).OrderBy(o => CInt(o.value)).ToList();

                //正常返し
                return res;
            });
        }
    }
}