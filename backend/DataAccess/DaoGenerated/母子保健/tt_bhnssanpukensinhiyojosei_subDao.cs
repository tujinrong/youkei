// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　産婦健診費用助成（固定）サブテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnssanpukensinhiyojosei_subDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnssanpukensinhiyojosei_sub";

        public tt_bhnssanpukensinhiyojosei_subDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnssanpukensinhiyojosei_subDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnssanpukensinhiyojosei_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnssanpukensinhiyojosei_subDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnssanpukensinhiyojosei_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnssanpukensinhiyojosei_subDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnssanpukensinhiyojosei_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnssanpukensinhiyojosei_subDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnssanpukensinhiyojosei_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnssanpukensinhiyojosei_subDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnssanpukensinhiyojosei_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnssanpukensinhiyojosei_subDto GetDtoByKey(string atenano, long torokuno, int sinseiedano, int edano)
        {
            return SELECT.WHERE.ByKey(atenano, torokuno, sinseiedano, edano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, long torokuno, int sinseiedano, int edano)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, torokuno, sinseiedano, edano).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnssanpukensinhiyojosei_subDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
