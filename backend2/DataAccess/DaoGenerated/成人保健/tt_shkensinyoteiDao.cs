// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　健（検）診予定テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shkensinyoteiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_shkensinyotei";

        public tt_shkensinyoteiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_shkensinyoteiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_shkensinyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_shkensinyoteiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_shkensinyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_shkensinyoteiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_shkensinyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_shkensinyoteiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_shkensinyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_shkensinyoteiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_shkensinyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_shkensinyoteiDto GetDtoByKey(int nendo, int nitteino)
        {
            return SELECT.WHERE.ByKey(nendo, nitteino).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int nendo, int nitteino, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(nendo, nitteino).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_shkensinyoteiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
