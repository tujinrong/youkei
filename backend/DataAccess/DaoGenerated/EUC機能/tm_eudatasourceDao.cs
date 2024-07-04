// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUCデータソースマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eudatasourceDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eudatasource";

        public tm_eudatasourceDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eudatasourceDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eudatasourceDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eudatasourceDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eudatasourceDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eudatasourceDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eudatasourceDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eudatasourceDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eudatasourceDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eudatasourceDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eudatasourceDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eudatasourceDto GetDtoByKey(string datasourceid)
        {
            return SELECT.WHERE.ByKey(datasourceid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string datasourceid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(datasourceid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eudatasourceDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
