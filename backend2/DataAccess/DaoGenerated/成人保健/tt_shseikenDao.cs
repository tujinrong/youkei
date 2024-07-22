// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　成人保健精密検査結果（固定項目）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shseikenDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_shseiken";

        public tt_shseikenDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_shseikenDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_shseikenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_shseikenDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_shseikenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_shseikenDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_shseikenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_shseikenDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_shseikenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_shseikenDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_shseikenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_shseikenDto GetDtoByKey(string jigyocd, string atenano, int nendo, int kensinkaisu)
        {
            return SELECT.WHERE.ByKey(jigyocd, atenano, nendo, kensinkaisu).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string jigyocd, string atenano, int nendo, int kensinkaisu, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(jigyocd, atenano, nendo, kensinkaisu).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_shseikenDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
