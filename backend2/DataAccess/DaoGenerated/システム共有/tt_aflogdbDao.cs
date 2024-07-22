// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　DB操作ログテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_aflogdbDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_aflogdb";

        public tt_aflogdbDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_aflogdbDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_aflogdbDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_aflogdbDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_aflogdbDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_aflogdbDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_aflogdbDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_aflogdbDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_aflogdbDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_aflogdbDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_aflogdbDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_aflogdbDto GetDtoByKey(long dblogseq)
        {
            return SELECT.WHERE.ByKey(dblogseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long dblogseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(dblogseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_aflogdbDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
