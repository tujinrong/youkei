// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　帳票グループマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eutyohyogroupDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eutyohyogroup";

        public tm_eutyohyogroupDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eutyohyogroupDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eutyohyogroupDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eutyohyogroupDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eutyohyogroupDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eutyohyogroupDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eutyohyogroupDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eutyohyogroupDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eutyohyogroupDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eutyohyogroupDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eutyohyogroupDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eutyohyogroupDto GetDtoByKey(int reportgroupid)
        {
            return SELECT.WHERE.ByKey(reportgroupid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int reportgroupid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(reportgroupid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eutyohyogroupDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
