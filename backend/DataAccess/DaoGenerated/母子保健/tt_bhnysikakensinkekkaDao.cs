// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　乳幼児歯科健診結果（固定項目）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnysikakensinkekkaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnysikakensinkekka";

        public tt_bhnysikakensinkekkaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnysikakensinkekkaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnysikakensinkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnysikakensinkekkaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnysikakensinkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnysikakensinkekkaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnysikakensinkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnysikakensinkekkaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnysikakensinkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnysikakensinkekkaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnysikakensinkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnysikakensinkekkaDto GetDtoByKey(string nykensincd, string atenano, int edano)
        {
            return SELECT.WHERE.ByKey(nykensincd, atenano, edano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string nykensincd, string atenano, int edano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(nykensincd, atenano, edano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnysikakensinkekkaDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
