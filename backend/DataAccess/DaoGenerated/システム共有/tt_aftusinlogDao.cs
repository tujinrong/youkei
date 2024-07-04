// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　通信ログテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_aftusinlogDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_aftusinlog";

        public tt_aftusinlogDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_aftusinlogDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_aftusinlogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_aftusinlogDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_aftusinlogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_aftusinlogDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_aftusinlogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_aftusinlogDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_aftusinlogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_aftusinlogDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_aftusinlogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_aftusinlogDto GetDtoByKey(long tusinlogseq)
        {
            return SELECT.WHERE.ByKey(tusinlogseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long tusinlogseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(tusinlogseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_aftusinlogDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
