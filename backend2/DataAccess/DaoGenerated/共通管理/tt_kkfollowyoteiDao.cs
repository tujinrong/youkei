// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　フォロー予定情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkfollowyoteiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kkfollowyotei";

        public tt_kkfollowyoteiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kkfollowyoteiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kkfollowyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kkfollowyoteiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kkfollowyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kkfollowyoteiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kkfollowyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kkfollowyoteiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kkfollowyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kkfollowyoteiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kkfollowyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kkfollowyoteiDto GetDtoByKey(string atenano, int follownaiyoedano, int edano)
        {
            return SELECT.WHERE.ByKey(atenano, follownaiyoedano, edano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int follownaiyoedano, int edano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, follownaiyoedano, edano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kkfollowyoteiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
