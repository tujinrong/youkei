// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　指導（フリー項目）コントロールマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kksidofreeitemDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kksidofreeitem";

        public tm_kksidofreeitemDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kksidofreeitemDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kksidofreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kksidofreeitemDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kksidofreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kksidofreeitemDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kksidofreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kksidofreeitemDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kksidofreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kksidofreeitemDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kksidofreeitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kksidofreeitemDto GetDtoByKey(string sidokbn, string gyomukbn, string mosikomikekkakbn, string itemyotokbn, string itemcd)
        {
            return SELECT.WHERE.ByKey(sidokbn, gyomukbn, mosikomikekkakbn, itemyotokbn, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string sidokbn, string gyomukbn, string mosikomikekkakbn, string itemyotokbn, string itemcd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(sidokbn, gyomukbn, mosikomikekkakbn, itemyotokbn, itemcd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_kksidofreeitemDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
