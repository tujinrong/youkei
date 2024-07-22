// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　予防接種（フリー項目）接種テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_yssessyufreeDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_yssessyufree";

        public tt_yssessyufreeDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_yssessyufreeDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_yssessyufreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_yssessyufreeDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_yssessyufreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_yssessyufreeDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_yssessyufreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_yssessyufreeDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_yssessyufreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_yssessyufreeDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_yssessyufreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_yssessyufreeDto GetDtoByKey(string atenano, string sessyucd, string kaisu, int edano, string itemcd)
        {
            return SELECT.WHERE.ByKey(atenano, sessyucd, kaisu, edano, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, string sessyucd, string kaisu, int edano, string itemcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, sessyucd, kaisu, edano, itemcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_yssessyufreeDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
