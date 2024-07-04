// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　集団指導事業（フリー項目）入力情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kksyudansidofreeDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kksyudansidofree";

        public tt_kksyudansidofreeDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kksyudansidofreeDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kksyudansidofreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kksyudansidofreeDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kksyudansidofreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kksyudansidofreeDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kksyudansidofreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kksyudansidofreeDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kksyudansidofreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kksyudansidofreeDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kksyudansidofreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kksyudansidofreeDto GetDtoByKey(string gyomukbn, int edano, string mosikomikekkakbn, string itemcd)
        {
            return SELECT.WHERE.ByKey(gyomukbn, edano, mosikomikekkakbn, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string gyomukbn, int edano, string mosikomikekkakbn, string itemcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(gyomukbn, edano, mosikomikekkakbn, itemcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kksyudansidofreeDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
