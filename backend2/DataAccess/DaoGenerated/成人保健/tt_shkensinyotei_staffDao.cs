// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　健（検）診予定担当者テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shkensinyotei_staffDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_shkensinyotei_staff";

        public tt_shkensinyotei_staffDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_shkensinyotei_staffDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_shkensinyotei_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_shkensinyotei_staffDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_shkensinyotei_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_shkensinyotei_staffDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_shkensinyotei_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_shkensinyotei_staffDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_shkensinyotei_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_shkensinyotei_staffDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_shkensinyotei_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_shkensinyotei_staffDto GetDtoByKey(int nendo, int nitteino, string staffid)
        {
            return SELECT.WHERE.ByKey(nendo, nitteino, staffid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int nendo, int nitteino, string staffid)
        {
            //物理削除
            DELETE.WHERE.ByKey(nendo, nitteino, staffid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_shkensinyotei_staffDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
