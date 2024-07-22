// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUC帳票権限
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eureportkegenDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eureportkegen";

        public tm_eureportkegenDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eureportkegenDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eureportkegenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eureportkegenDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eureportkegenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eureportkegenDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eureportkegenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eureportkegenDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eureportkegenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eureportkegenDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eureportkegenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eureportkegenDto GetDtoByKey(int reportid, int seq)
        {
            return SELECT.WHERE.ByKey(reportid, seq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int reportid, int seq, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(reportid, seq).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eureportkegenDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
