// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　産婦健診費用助成（固定）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnssanpukensinhiyojoseiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnssanpukensinhiyojosei";

        public tt_bhnssanpukensinhiyojoseiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnssanpukensinhiyojoseiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnssanpukensinhiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnssanpukensinhiyojoseiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnssanpukensinhiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnssanpukensinhiyojoseiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnssanpukensinhiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnssanpukensinhiyojoseiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnssanpukensinhiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnssanpukensinhiyojoseiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnssanpukensinhiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnssanpukensinhiyojoseiDto GetDtoByKey(string atenano, long torokuno, int sinseiedano)
        {
            return SELECT.WHERE.ByKey(atenano, torokuno, sinseiedano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, long torokuno, int sinseiedano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, torokuno, sinseiedano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnssanpukensinhiyojoseiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
