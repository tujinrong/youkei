// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　テーブル項目値変更ログテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_aflogcolumnDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_aflogcolumn";

        public tt_aflogcolumnDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_aflogcolumnDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_aflogcolumnDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_aflogcolumnDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_aflogcolumnDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_aflogcolumnDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_aflogcolumnDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_aflogcolumnDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_aflogcolumnDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_aflogcolumnDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_aflogcolumnDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_aflogcolumnDto GetDtoByKey(long columnlogseq)
        {
            return SELECT.WHERE.ByKey(columnlogseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long columnlogseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(columnlogseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_aflogcolumnDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
