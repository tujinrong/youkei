// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUC帳票出力履歴テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_eurirekiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_eurireki";

        public tt_eurirekiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_eurirekiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_eurirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_eurirekiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_eurirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_eurirekiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_eurirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_eurirekiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_eurirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_eurirekiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_eurirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_eurirekiDto GetDtoByKey(long rirekiseq)
        {
            return SELECT.WHERE.ByKey(rirekiseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long rirekiseq, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(rirekiseq).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_eurirekiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
