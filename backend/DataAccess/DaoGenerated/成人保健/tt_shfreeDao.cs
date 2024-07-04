// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　成人保健検診結果（フリー項目）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shfreeDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_shfree";

        public tt_shfreeDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_shfreeDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_shfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_shfreeDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_shfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_shfreeDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_shfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_shfreeDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_shfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_shfreeDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_shfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_shfreeDto GetDtoByKey(string jigyocd, string atenano, int nendo, int kensinkaisu, string itemcd)
        {
            return SELECT.WHERE.ByKey(jigyocd, atenano, nendo, kensinkaisu, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string jigyocd, string atenano, int nendo, int kensinkaisu, string itemcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(jigyocd, atenano, nendo, kensinkaisu, itemcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_shfreeDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
