// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　妊婦健診結果（固定）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnsninpukensinkekkaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnsninpukensinkekka";

        public tt_bhnsninpukensinkekkaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnsninpukensinkekkaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnsninpukensinkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnsninpukensinkekkaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnsninpukensinkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnsninpukensinkekkaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnsninpukensinkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnsninpukensinkekkaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnsninpukensinkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnsninpukensinkekkaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnsninpukensinkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnsninpukensinkekkaDto GetDtoByKey(string atenano, long torokuno, int jusinkaisu)
        {
            return SELECT.WHERE.ByKey(atenano, torokuno, jusinkaisu).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, long torokuno, int jusinkaisu, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, torokuno, jusinkaisu).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnsninpukensinkekkaDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
