// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　送付先管理テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afsofusakiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afsofusaki";

        public tt_afsofusakiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afsofusakiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afsofusakiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afsofusakiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afsofusakiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afsofusakiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afsofusakiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afsofusakiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afsofusakiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afsofusakiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afsofusakiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afsofusakiDto GetDtoByKey(string atenano, string riyomokuteki)
        {
            return SELECT.WHERE.ByKey(atenano, riyomokuteki).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, string riyomokuteki, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, riyomokuteki).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afsofusakiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
