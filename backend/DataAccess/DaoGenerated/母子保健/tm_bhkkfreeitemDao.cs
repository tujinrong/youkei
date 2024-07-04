// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　母子保健（フリー）項目コントロールマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhkkfreeitemDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_bhkkfreeitem";

        public tm_bhkkfreeitemDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_bhkkfreeitemDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_bhkkfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_bhkkfreeitemDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_bhkkfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_bhkkfreeitemDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_bhkkfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_bhkkfreeitemDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_bhkkfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_bhkkfreeitemDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_bhkkfreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_bhkkfreeitemDto GetDtoByKey(string bosikbn, string jigyocd, string itemcd)
        {
            return SELECT.WHERE.ByKey(bosikbn, jigyocd, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string bosikbn, string jigyocd, string itemcd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(bosikbn, jigyocd, itemcd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_bhkkfreeitemDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
