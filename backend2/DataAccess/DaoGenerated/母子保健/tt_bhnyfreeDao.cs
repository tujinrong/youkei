// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　乳幼児（フリー）項目テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnyfreeDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnyfree";

        public tt_bhnyfreeDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnyfreeDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnyfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnyfreeDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnyfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnyfreeDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnyfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnyfreeDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnyfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnyfreeDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnyfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnyfreeDto GetDtoByKey(string jigyocd, string atenano, int edano, string itemcd)
        {
            return SELECT.WHERE.ByKey(jigyocd, atenano, edano, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string jigyocd, string atenano, int edano, string itemcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(jigyocd, atenano, edano, itemcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnyfreeDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
