// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　母子保健項目コントロールマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhitemDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_bhitem";

        public tm_bhitemDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_bhitemDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_bhitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_bhitemDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_bhitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_bhitemDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_bhitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_bhitemDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_bhitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_bhitemDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_bhitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_bhitemDto GetDtoByKey(string bhsyurui, string bhdatalistcd, string itemcd)
        {
            return SELECT.WHERE.ByKey(bhsyurui, bhdatalistcd, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string bhsyurui, string bhdatalistcd, string itemcd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(bhsyurui, bhdatalistcd, itemcd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_bhitemDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
