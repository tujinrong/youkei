// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　保健指導事業（フリー項目）入力情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkhokensidofreeDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kkhokensidofree";

        public tt_kkhokensidofreeDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kkhokensidofreeDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kkhokensidofreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kkhokensidofreeDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kkhokensidofreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kkhokensidofreeDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kkhokensidofreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kkhokensidofreeDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kkhokensidofreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kkhokensidofreeDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kkhokensidofreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kkhokensidofreeDto GetDtoByKey(string hokensidokbn, string gyomukbn, string mosikomikekkakbn, string itemcd, string atenano, int edano)
        {
            return SELECT.WHERE.ByKey(hokensidokbn, gyomukbn, mosikomikekkakbn, itemcd, atenano, edano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string hokensidokbn, string gyomukbn, string mosikomikekkakbn, string itemcd, string atenano, int edano)
        {
            //物理削除
            DELETE.WHERE.ByKey(hokensidokbn, gyomukbn, mosikomikekkakbn, itemcd, atenano, edano).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kkhokensidofreeDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
