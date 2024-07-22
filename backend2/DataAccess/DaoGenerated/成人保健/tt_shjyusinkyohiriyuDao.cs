// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　受診拒否理由テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shjyusinkyohiriyuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_shjyusinkyohiriyu";

        public tt_shjyusinkyohiriyuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_shjyusinkyohiriyuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_shjyusinkyohiriyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_shjyusinkyohiriyuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_shjyusinkyohiriyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_shjyusinkyohiriyuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_shjyusinkyohiriyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_shjyusinkyohiriyuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_shjyusinkyohiriyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_shjyusinkyohiriyuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_shjyusinkyohiriyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_shjyusinkyohiriyuDto GetDtoByKey(int nendo, string atenano, string jigyocd)
        {
            return SELECT.WHERE.ByKey(nendo, atenano, jigyocd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int nendo, string atenano, string jigyocd)
        {
            //物理削除
            DELETE.WHERE.ByKey(nendo, atenano, jigyocd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_shjyusinkyohiriyuDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
