// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　妊婦健診費用助成（固定）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnsninpukensinhiyojoseiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnsninpukensinhiyojosei";

        public tt_bhnsninpukensinhiyojoseiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnsninpukensinhiyojoseiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnsninpukensinhiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnsninpukensinhiyojoseiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnsninpukensinhiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnsninpukensinhiyojoseiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnsninpukensinhiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnsninpukensinhiyojoseiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnsninpukensinhiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnsninpukensinhiyojoseiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnsninpukensinhiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnsninpukensinhiyojoseiDto GetDtoByKey(string jigyocd, string atenano, long torokuno, int sinseiedano)
        {
            return SELECT.WHERE.ByKey(jigyocd, atenano, torokuno, sinseiedano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string jigyocd, string atenano, long torokuno, int sinseiedano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(jigyocd, atenano, torokuno, sinseiedano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnsninpukensinhiyojoseiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
