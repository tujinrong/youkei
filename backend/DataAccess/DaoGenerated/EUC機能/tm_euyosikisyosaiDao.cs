// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUC様式詳細マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_euyosikisyosaiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_euyosikisyosai";

        public tm_euyosikisyosaiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_euyosikisyosaiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_euyosikisyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_euyosikisyosaiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_euyosikisyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_euyosikisyosaiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_euyosikisyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_euyosikisyosaiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_euyosikisyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_euyosikisyosaiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_euyosikisyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_euyosikisyosaiDto GetDtoByKey(string rptid, string yosikiid, int yosikieda)
        {
            return SELECT.WHERE.ByKey(rptid, yosikiid, yosikieda).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string rptid, string yosikiid, int yosikieda, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(rptid, yosikiid, yosikieda).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_euyosikisyosaiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
