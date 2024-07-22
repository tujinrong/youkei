// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　帳票グループマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eurptgroupDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eurptgroup";

        public tm_eurptgroupDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eurptgroupDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eurptgroupDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eurptgroupDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eurptgroupDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eurptgroupDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eurptgroupDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eurptgroupDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eurptgroupDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eurptgroupDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eurptgroupDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eurptgroupDto GetDtoByKey(string rptgroupid)
        {
            return SELECT.WHERE.ByKey(rptgroupid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string rptgroupid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(rptgroupid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eurptgroupDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
