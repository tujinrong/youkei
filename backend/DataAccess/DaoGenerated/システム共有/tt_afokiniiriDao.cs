// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　お気に入りテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afokiniiriDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afokiniiri";

        public tt_afokiniiriDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afokiniiriDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afokiniiriDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afokiniiriDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afokiniiriDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afokiniiriDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afokiniiriDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afokiniiriDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afokiniiriDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afokiniiriDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afokiniiriDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afokiniiriDto GetDtoByKey(string userid, string kinoid)
        {
            return SELECT.WHERE.ByKey(userid, kinoid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string userid, string kinoid)
        {
            //物理削除
            DELETE.WHERE.ByKey(userid, kinoid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afokiniiriDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
