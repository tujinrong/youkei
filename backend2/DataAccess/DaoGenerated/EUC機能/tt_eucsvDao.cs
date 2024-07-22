// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　CSV出力パターンテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_eucsvDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_eucsv";

        public tt_eucsvDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_eucsvDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_eucsvDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_eucsvDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_eucsvDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_eucsvDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_eucsvDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_eucsvDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_eucsvDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_eucsvDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_eucsvDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_eucsvDto GetDtoByKey(string rptid, string yosikiid, int outputptnno)
        {
            return SELECT.WHERE.ByKey(rptid, yosikiid, outputptnno).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string rptid, string yosikiid, int outputptnno, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(rptid, yosikiid, outputptnno).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_eucsvDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
