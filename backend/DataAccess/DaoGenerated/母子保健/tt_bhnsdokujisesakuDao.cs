// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　独自施策（母）（固定）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnsdokujisesakuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnsdokujisesaku";

        public tt_bhnsdokujisesakuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnsdokujisesakuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnsdokujisesakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnsdokujisesakuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnsdokujisesakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnsdokujisesakuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnsdokujisesakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnsdokujisesakuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnsdokujisesakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnsdokujisesakuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnsdokujisesakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnsdokujisesakuDto GetDtoByKey(string jigyocd, string atenano, long torokuno, int edano)
        {
            return SELECT.WHERE.ByKey(jigyocd, atenano, torokuno, edano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string jigyocd, string atenano, long torokuno, int edano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(jigyocd, atenano, torokuno, edano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnsdokujisesakuDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
