// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　健診受診履歴（固定項目）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnykensinjusinrekiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnykensinjusinreki";

        public tt_bhnykensinjusinrekiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnykensinjusinrekiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnykensinjusinrekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnykensinjusinrekiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnykensinjusinrekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnykensinjusinrekiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnykensinjusinrekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnykensinjusinrekiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnykensinjusinrekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnykensinjusinrekiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnykensinjusinrekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnykensinjusinrekiDto GetDtoByKey(string atenano)
        {
            return SELECT.WHERE.ByKey(atenano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnykensinjusinrekiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
