// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　基準値マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kkkijunDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kkkijun";

        public tm_kkkijunDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kkkijunDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kkkijunDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kkkijunDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kkkijunDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kkkijunDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kkkijunDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kkkijunDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kkkijunDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kkkijunDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kkkijunDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kkkijunDto GetDtoByKey(string gyomukbn, string kijunjigyocd, string itemcd, int edano)
        {
            return SELECT.WHERE.ByKey(gyomukbn, kijunjigyocd, itemcd, edano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string gyomukbn, string kijunjigyocd, string itemcd, int edano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(gyomukbn, kijunjigyocd, itemcd, edano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_kkkijunDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
