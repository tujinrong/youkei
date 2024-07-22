// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　妊産婦（フリー）項目テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnsfreeDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnsfree";

        public tt_bhnsfreeDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnsfreeDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnsfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnsfreeDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnsfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnsfreeDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnsfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnsfreeDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnsfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnsfreeDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnsfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnsfreeDto GetDtoByKey(string jigyocd, string atenano, long torokuno, int torokunorenban, int edano, string kaisu, string itemcd)
        {
            return SELECT.WHERE.ByKey(jigyocd, atenano, torokuno, torokunorenban, edano, kaisu, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string jigyocd, string atenano, long torokuno, int torokunorenban, int edano, string kaisu, string itemcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(jigyocd, atenano, torokuno, torokunorenban, edano, kaisu, itemcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnsfreeDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
