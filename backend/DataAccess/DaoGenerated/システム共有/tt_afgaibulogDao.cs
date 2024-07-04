// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　外部連携処理結果履歴テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afgaibulogDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afgaibulog";

        public tt_afgaibulogDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afgaibulogDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afgaibulogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afgaibulogDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afgaibulogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afgaibulogDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afgaibulogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afgaibulogDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afgaibulogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afgaibulogDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afgaibulogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afgaibulogDto GetDtoByKey(long gaibulogseq)
        {
            return SELECT.WHERE.ByKey(gaibulogseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long gaibulogseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(gaibulogseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afgaibulogDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
