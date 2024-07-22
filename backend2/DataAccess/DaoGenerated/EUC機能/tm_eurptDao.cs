// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUC帳票マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eurptDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eurpt";

        public tm_eurptDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eurptDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eurptDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eurptDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eurptDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eurptDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eurptDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eurptDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eurptDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eurptDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eurptDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eurptDto GetDtoByKey(string rptid)
        {
            return SELECT.WHERE.ByKey(rptid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string rptid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(rptid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eurptDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
