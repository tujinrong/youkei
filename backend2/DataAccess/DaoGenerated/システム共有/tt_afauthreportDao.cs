// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　帳票権限テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afauthreportDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afauthreport";

        public tt_afauthreportDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afauthreportDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afauthreportDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afauthreportDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afauthreportDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afauthreportDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afauthreportDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afauthreportDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afauthreportDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afauthreportDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afauthreportDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afauthreportDto GetDtoByKey(string rolekbn, string roleid, string repgroupid)
        {
            return SELECT.WHERE.ByKey(rolekbn, roleid, repgroupid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string rolekbn, string roleid, string repgroupid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(rolekbn, roleid, repgroupid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afauthreportDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
