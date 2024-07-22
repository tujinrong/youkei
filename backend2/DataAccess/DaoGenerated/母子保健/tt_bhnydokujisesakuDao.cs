// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　独自施策（子）（固定項目）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnydokujisesakuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnydokujisesaku";

        public tt_bhnydokujisesakuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnydokujisesakuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnydokujisesakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnydokujisesakuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnydokujisesakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnydokujisesakuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnydokujisesakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnydokujisesakuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnydokujisesakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnydokujisesakuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnydokujisesakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnydokujisesakuDto GetDtoByKey(string jigyocd, string atenano, int edano)
        {
            return SELECT.WHERE.ByKey(jigyocd, atenano, edano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string jigyocd, string atenano, int edano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(jigyocd, atenano, edano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnydokujisesakuDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
