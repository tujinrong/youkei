// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ログ情報管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.09.05
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00803G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータ取得(一覧画面)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            var paras = new List<AiKeyValue> {
                new($"{nameof(SearchListRequest.logkbn)}_in", CNInt(req.logkbn)),                               //ログ区分
                new($"{nameof(SearchListRequest.status)}_in", DaSelectorService.GetCd(req.status)),             //処理結果コード
                new($"{nameof(SearchListRequest.syoridttmf)}_in", req.syoridttmf),                              //処理日時（開始）
                new($"{nameof(SearchListRequest.syoridttmt)}_in", req.syoridttmt),                              //処理日時（終了）
                new($"{nameof(SearchListRequest.service)}_in", DaSelectorService.GetCd(req.service)),           //機能ID
                new($"{nameof(SearchListRequest.method)}_in", DaSelectorService.GetCd(req.method)),             //処理
                new($"{nameof(SearchListRequest.user)}_in", DaSelectorService.GetCd(req.user)),                 //ユーザーID
                new($"{nameof(SearchListRequest.atenano)}_in", req.atenano),                                    //宛名番号
                new($"{nameof(SearchListRequest.personalno)}_in", CmLogicUtil.GetPersonalnoDB(req.personalno)), //個人番号
                new($"{nameof(SearchListRequest.pnokbn)}_in", req.pnokbn)                                       //個人番号操作区分
            };

            return paras;
        }
        /// <summary>
        /// 検索パラメータ取得(一覧画面)
        /// </summary>
        public static List<AiKeyValue> GetParameters(long seq)
        {
            var paras = new List<AiKeyValue> {
                new($"{nameof(SearchCommonRequest.sessionseq)}_in", seq) //ログシーケンス
            };

            return paras;
        }
        /// <summary>
        /// 検索パラメータ取得(詳細画面：項目値変更情報)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchColumnDetailRequest req)
        {
            var paras = new List<AiKeyValue> {
                new($"{nameof(SearchCommonRequest.sessionseq)}_in", req.sessionseq) //ログシーケンス
            };
            AddParameters(paras, nameof(tt_aflogcolumnDto.tablenm), req.table);     //変更テーブル
            AddParameters(paras, nameof(tt_aflogcolumnDto.itemnm), req.item);       //変更項目
            AddParameters(paras, nameof(tt_aflogcolumnDto.henkokbn), req.henkokbn); //変更区分

            return paras;
        }
        /// <summary>
        /// 検索パラメータ取得(出力処理)
        /// </summary>
        public static List<AiKeyValue> GetParameters(OutputRequest req)
        {
            var paras = new List<AiKeyValue> {
                new($"{nameof(OutputRequest.logkbn)}_in", CNInt(req.logkbn)),                               //ログ区分
                new($"{nameof(OutputRequest.status)}_in", DaSelectorService.GetCd(req.status)),             //処理結果コード
                new($"{nameof(OutputRequest.syoridttmf)}_in", req.syoridttmf),                              //処理日時（開始）
                new($"{nameof(OutputRequest.syoridttmt)}_in", req.syoridttmt),                              //処理日時（終了）
                new($"{nameof(OutputRequest.service)}_in", DaSelectorService.GetCd(req.service)),           //機能ID
                new($"{nameof(OutputRequest.method)}_in", DaSelectorService.GetCd(req.method)),             //処理
                new($"{nameof(OutputRequest.user)}_in", DaSelectorService.GetCd(req.user)),                 //ユーザーID
                new($"{nameof(OutputRequest.atenano)}_in", req.atenano),                                    //宛名番号
                new($"{nameof(OutputRequest.personalno)}_in", CmLogicUtil.GetPersonalnoDB(req.personalno)), //個人番号
                new($"{nameof(OutputRequest.pnokbn)}_in", req.pnokbn)                                       //個人番号操作区分
            };

            return paras;
        }
        /// <summary>
        /// パラメータ設定
        /// </summary>
        private static void AddParameters(List<AiKeyValue> paras, string itemnm, string? value)
        {
            string? str = null;
            if (!string.IsNullOrEmpty(value))
            {
                str = DaSelectorService.GetCd(value);
            }
            paras.Add(new AiKeyValue($"{itemnm}_in", str));
        }
    }
}