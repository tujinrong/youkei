// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　母子保健データリストマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhdatalistDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_bhdatalist";

        public tm_bhdatalistDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_bhdatalistDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_bhdatalistDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_bhdatalistDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_bhdatalistDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_bhdatalistDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_bhdatalistDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_bhdatalistDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_bhdatalistDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_bhdatalistDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_bhdatalistDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_bhdatalistDto GetDtoByKey(string bhsyurui, string bhdatalistcd)
        {
            return SELECT.WHERE.ByKey(bhsyurui, bhdatalistcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string bhsyurui, string bhdatalistcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(bhsyurui, bhdatalistcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_bhdatalistDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
