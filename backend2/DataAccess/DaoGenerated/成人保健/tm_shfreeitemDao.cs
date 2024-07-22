// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　成人保健検診結果（フリー）項目コントロールマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_shfreeitemDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_shfreeitem";

        public tm_shfreeitemDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_shfreeitemDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_shfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_shfreeitemDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_shfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_shfreeitemDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_shfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_shfreeitemDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_shfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_shfreeitemDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_shfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_shfreeitemDto GetDtoByKey(string jigyocd, string itemcd)
        {
            return SELECT.WHERE.ByKey(jigyocd, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string jigyocd, string itemcd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(jigyocd, itemcd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_shfreeitemDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
