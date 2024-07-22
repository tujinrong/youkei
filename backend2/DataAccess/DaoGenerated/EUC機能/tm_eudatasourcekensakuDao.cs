// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUCデータソース検索マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eudatasourcekensakuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eudatasourcekensaku";

        public tm_eudatasourcekensakuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eudatasourcekensakuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eudatasourcekensakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eudatasourcekensakuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eudatasourcekensakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eudatasourcekensakuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eudatasourcekensakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eudatasourcekensakuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eudatasourcekensakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eudatasourcekensakuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eudatasourcekensakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eudatasourcekensakuDto GetDtoByKey(string datasourceid, int jyokenid)
        {
            return SELECT.WHERE.ByKey(datasourceid, jyokenid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string datasourceid, int jyokenid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(datasourceid, jyokenid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eudatasourcekensakuDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
