// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　母子保健健診対象者テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhkensinDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_bhkensin";

        public tm_bhkensinDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_bhkensinDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_bhkensinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_bhkensinDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_bhkensinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_bhkensinDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_bhkensinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_bhkensinDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_bhkensinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_bhkensinDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_bhkensinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_bhkensinDto GetDtoByKey(string bhsyurui, string bhdatalistcd, string atenano)
        {
            return SELECT.WHERE.ByKey(bhsyurui, bhdatalistcd, atenano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string bhsyurui, string bhdatalistcd, string atenano)
        {
            //物理削除
            DELETE.WHERE.ByKey(bhsyurui, bhdatalistcd, atenano).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_bhkensinDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
