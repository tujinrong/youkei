// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　バッチログテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afbatchlogDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afbatchlog";

        public tt_afbatchlogDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afbatchlogDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afbatchlogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afbatchlogDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afbatchlogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afbatchlogDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afbatchlogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afbatchlogDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afbatchlogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afbatchlogDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afbatchlogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afbatchlogDto GetDtoByKey(long batchlogseq)
        {
            return SELECT.WHERE.ByKey(batchlogseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long batchlogseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(batchlogseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afbatchlogDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
