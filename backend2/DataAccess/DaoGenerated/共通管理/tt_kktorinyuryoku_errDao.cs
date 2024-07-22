// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　一括取込入力エラーテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kktorinyuryoku_errDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kktorinyuryoku_err";

        public tt_kktorinyuryoku_errDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kktorinyuryoku_errDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kktorinyuryoku_errDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kktorinyuryoku_errDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kktorinyuryoku_errDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kktorinyuryoku_errDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kktorinyuryoku_errDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kktorinyuryoku_errDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kktorinyuryoku_errDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kktorinyuryoku_errDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kktorinyuryoku_errDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kktorinyuryoku_errDto GetDtoByKey(int impjikkoid, int errseq)
        {
            return SELECT.WHERE.ByKey(impjikkoid, errseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int impjikkoid, int errseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(impjikkoid, errseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kktorinyuryoku_errDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
