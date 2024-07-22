// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　フォロー内容情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkfollownaiyoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kkfollownaiyo";

        public tt_kkfollownaiyoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kkfollownaiyoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kkfollownaiyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kkfollownaiyoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kkfollownaiyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kkfollownaiyoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kkfollownaiyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kkfollownaiyoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kkfollownaiyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kkfollownaiyoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kkfollownaiyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kkfollownaiyoDto GetDtoByKey(string atenano, int follownaiyoedano)
        {
            return SELECT.WHERE.ByKey(atenano, follownaiyoedano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int follownaiyoedano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, follownaiyoedano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kkfollownaiyoDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
