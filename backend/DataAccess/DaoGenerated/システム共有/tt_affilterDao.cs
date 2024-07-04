// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　詳細条件設定テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_affilterDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_affilter";

        public tt_affilterDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_affilterDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_affilterDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_affilterDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_affilterDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_affilterDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_affilterDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_affilterDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_affilterDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_affilterDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_affilterDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_affilterDto GetDtoByKey(string kinoid, string jyokbn, int jyoseq)
        {
            return SELECT.WHERE.ByKey(kinoid, jyokbn, jyoseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string kinoid, string jyokbn, int jyoseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(kinoid, jyokbn, jyoseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_affilterDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
