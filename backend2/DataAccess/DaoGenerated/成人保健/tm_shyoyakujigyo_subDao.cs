// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　成人健（検）診予約日程事業サブマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_shyoyakujigyo_subDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_shyoyakujigyo_sub";

        public tm_shyoyakujigyo_subDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_shyoyakujigyo_subDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_shyoyakujigyo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_shyoyakujigyo_subDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_shyoyakujigyo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_shyoyakujigyo_subDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_shyoyakujigyo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_shyoyakujigyo_subDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_shyoyakujigyo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_shyoyakujigyo_subDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_shyoyakujigyo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_shyoyakujigyo_subDto GetDtoByKey(int nendo, string jigyocd, string kensin_jigyocd, string kensahohocd)
        {
            return SELECT.WHERE.ByKey(nendo, jigyocd, kensin_jigyocd, kensahohocd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int nendo, string jigyocd, string kensin_jigyocd, string kensahohocd)
        {
            //物理削除
            DELETE.WHERE.ByKey(nendo, jigyocd, kensin_jigyocd, kensahohocd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_shyoyakujigyo_subDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
