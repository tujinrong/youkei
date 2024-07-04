// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUC様式マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_euyosikiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_euyosiki";

        public tm_euyosikiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_euyosikiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_euyosikiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_euyosikiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_euyosikiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_euyosikiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_euyosikiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_euyosikiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_euyosikiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_euyosikiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_euyosikiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_euyosikiDto GetDtoByKey(string rptid, string yosikiid)
        {
            return SELECT.WHERE.ByKey(rptid, yosikiid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string rptid, string yosikiid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(rptid, yosikiid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_euyosikiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
