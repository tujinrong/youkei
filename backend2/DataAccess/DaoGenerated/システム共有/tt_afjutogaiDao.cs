// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　住登外者情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afjutogaiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afjutogai";

        public tt_afjutogaiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afjutogaiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afjutogaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afjutogaiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afjutogaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afjutogaiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afjutogaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afjutogaiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afjutogaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afjutogaiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afjutogaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afjutogaiDto GetDtoByKey(string atenano, int rirekino)
        {
            return SELECT.WHERE.ByKey(atenano, rirekino).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int rirekino, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, rirekino).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afjutogaiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
