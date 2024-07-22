// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　メインログテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_aflogDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_aflog";

        public tt_aflogDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_aflogDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_aflogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_aflogDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_aflogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_aflogDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_aflogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_aflogDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_aflogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_aflogDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_aflogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_aflogDto GetDtoByKey(long sessionseq)
        {
            return SELECT.WHERE.ByKey(sessionseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long sessionseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(sessionseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_aflogDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
