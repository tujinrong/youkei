// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票項目編集
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00205D
{
    [DisplayName("帳票項目編集")]
    public class Service : CmServiceBase
    {
        private const long RATIO = 100000000L;

        [DisplayName("初期化処理")]
        public InitResponse Init(DaRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new InitResponse();

                res.selectorlist1 = EucConstant.CROSS_KBN_OPTIONS;  //ドロップダウンリスト(集計区分)
                res.selectorlist2 = EucConstant.ITEM_KBN_OPTIONS;   //ドロップダウンリスト(出力項目区分)
                res.selectorlist3 = EucConstant.ORDER_KBN_OPTIONS;  //(並び替え)
                res.selectorlist5 = EucConstant.KBN_1_OPTIONS;      //ドロップダウンリスト(小計区分)

                //正常返し
                return res;
            });
        }

        [DisplayName("マスタ初期化処理")]
        public InitMasterResponse InitMaster(DaRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new InitMasterResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var itemNameDtl = DaEucBasicService.GetTableItemNameDtl(db);
                var sql = AWEU00105D.Service.GetMasterSql(itemNameDtl);
                var rows = DaDbUtil.GetDataTable(db, sql).Rows;

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //マスタリスト
                res.masterlist = Wraper.GetMasterVMList(db, itemNameDtl, rows); 

                //正常返し
                return res;
            });
        }

        [DisplayName("フォーマット初期化処理")]
        public InitFormatResponse InitFormat(DaRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new InitFormatResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //フォーマット情報を取得
                var formatDtl = DaNameService.GetNameList(db, EnumNmKbn.出力形式).ToList();
                //フォーマット詳細情報を取得
                var formatSyosaiDict = GetFormatSyosaiDic(db);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //フォーマットリスト
                res.formatlist = Wraper.GetFormatVMList(formatDtl, formatSyosaiDict); 

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// フォーマット詳細情報を取得
        /// </summary>
        private Dictionary<long, (EnumNmKbn, List<tm_afmeisyoDto>)> GetFormatSyosaiDic(DaDbContext db)
        {
            var formatSyosaiDic = new Dictionary<long, (EnumNmKbn, List<tm_afmeisyoDto>)>
                {
                    { (long)EnumNmKbn.文字形式 % RATIO, (EnumNmKbn.文字形式, DaNameService.GetNameList(db, EnumNmKbn.文字形式).ToList()) },
                    { (long)EnumNmKbn.数値形式 % RATIO, (EnumNmKbn.数値形式, DaNameService.GetNameList(db, EnumNmKbn.数値形式).ToList()) },
                    { (long)EnumNmKbn.年形式 % RATIO, (EnumNmKbn.年形式, DaNameService.GetNameList(db, EnumNmKbn.年形式).ToList()) },
                    { (long)EnumNmKbn.日付形式 % RATIO, (EnumNmKbn.日付形式, DaNameService.GetNameList(db, EnumNmKbn.日付形式).ToList()) },
                    { (long)EnumNmKbn.日時形式 % RATIO, (EnumNmKbn.日時形式, DaNameService.GetNameList(db, EnumNmKbn.日時形式).ToList()) },
                    { (long)EnumNmKbn.時間形式 % RATIO, (EnumNmKbn.時間形式, DaNameService.GetNameList(db, EnumNmKbn.時間形式).ToList()) },
                    { (long)EnumNmKbn.論理形式 % RATIO, (EnumNmKbn.論理形式, DaNameService.GetNameList(db, EnumNmKbn.論理形式).ToList()) },
                    { (long)EnumNmKbn.バーコード形式 % RATIO, (EnumNmKbn.バーコード形式, DaNameService.GetNameList(db, EnumNmKbn.バーコード形式).ToList()) }
                };

            return formatSyosaiDic;
        }
    }
}