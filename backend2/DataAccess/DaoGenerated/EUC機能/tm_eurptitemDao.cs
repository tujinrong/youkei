// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUC帳票項目マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eurptitemDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eurptitem";

        public tm_eurptitemDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eurptitemDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eurptitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eurptitemDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eurptitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eurptitemDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eurptitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eurptitemDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eurptitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eurptitemDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eurptitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eurptitemDto GetDtoByKey(string rptid, string yosikiid, int yosikieda, string yosikiitemid)
        {
            return SELECT.WHERE.ByKey(rptid, yosikiid, yosikieda, yosikiitemid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string rptid, string yosikiid, int yosikieda, string yosikiitemid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(rptid, yosikiid, yosikieda, yosikiitemid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eurptitemDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
