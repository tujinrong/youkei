// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　【国民健康保険】国保資格情報履歴テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkokuho_rekiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afkokuho_reki";

        public tt_afkokuho_rekiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afkokuho_rekiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afkokuho_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afkokuho_rekiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afkokuho_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afkokuho_rekiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afkokuho_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afkokuho_rekiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afkokuho_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afkokuho_rekiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afkokuho_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afkokuho_rekiDto GetDtoByKey(string atenano, int hihokensyarirekino)
        {
            return SELECT.WHERE.ByKey(atenano, hihokensyarirekino).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int hihokensyarirekino, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, hihokensyarirekino).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afkokuho_rekiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
