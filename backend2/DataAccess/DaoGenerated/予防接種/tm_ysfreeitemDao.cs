// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　予防接種（フリー）項目コントロールマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_ysfreeitemDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_ysfreeitem";

        public tm_ysfreeitemDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_ysfreeitemDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_ysfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_ysfreeitemDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_ysfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_ysfreeitemDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_ysfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_ysfreeitemDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_ysfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_ysfreeitemDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_ysfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_ysfreeitemDto GetDtoByKey(string jigyocd, string itemcd)
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
        public void UpdateDto(tm_ysfreeitemDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
