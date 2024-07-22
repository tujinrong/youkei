// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUCデータソース項目マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eudatasourceitemDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eudatasourceitem";

        public tm_eudatasourceitemDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eudatasourceitemDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eudatasourceitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eudatasourceitemDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eudatasourceitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eudatasourceitemDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eudatasourceitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eudatasourceitemDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eudatasourceitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eudatasourceitemDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eudatasourceitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eudatasourceitemDto GetDtoByKey(string datasourceid, string sqlcolumn)
        {
            return SELECT.WHERE.ByKey(datasourceid, sqlcolumn).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string datasourceid, string sqlcolumn, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(datasourceid, sqlcolumn).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eudatasourceitemDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
