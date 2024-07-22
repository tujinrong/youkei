// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　【個人住民税】個人住民税課税情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkojinzeikazeiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afkojinzeikazei";

        public tt_afkojinzeikazeiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afkojinzeikazeiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afkojinzeikazeiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afkojinzeikazeiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afkojinzeikazeiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afkojinzeikazeiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afkojinzeikazeiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afkojinzeikazeiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afkojinzeikazeiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afkojinzeikazeiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afkojinzeikazeiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afkojinzeikazeiDto GetDtoByKey(string atenano, int kazeinendo)
        {
            return SELECT.WHERE.ByKey(atenano, kazeinendo).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int kazeinendo, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, kazeinendo).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afkojinzeikazeiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
