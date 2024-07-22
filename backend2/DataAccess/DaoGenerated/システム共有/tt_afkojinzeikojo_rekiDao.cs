// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　【個人住民税】個人住民税税額控除情報履歴テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkojinzeikojo_rekiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afkojinzeikojo_reki";

        public tt_afkojinzeikojo_rekiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afkojinzeikojo_rekiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afkojinzeikojo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afkojinzeikojo_rekiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afkojinzeikojo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afkojinzeikojo_rekiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afkojinzeikojo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afkojinzeikojo_rekiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afkojinzeikojo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afkojinzeikojo_rekiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afkojinzeikojo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afkojinzeikojo_rekiDto GetDtoByKey(string atenano, int kazeinendo, int kojorirekino, string kojocd)
        {
            return SELECT.WHERE.ByKey(atenano, kazeinendo, kojorirekino, kojocd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int kazeinendo, int kojorirekino, string kojocd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, kazeinendo, kojorirekino, kojocd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afkojinzeikojo_rekiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
