// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　妊産婦ワークテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class wk_euninsanpu_subDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "wk_euninsanpu_sub";

        public wk_euninsanpu_subDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<wk_euninsanpu_subDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<wk_euninsanpu_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<wk_euninsanpu_subDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<wk_euninsanpu_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<wk_euninsanpu_subDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<wk_euninsanpu_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<wk_euninsanpu_subDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<wk_euninsanpu_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<wk_euninsanpu_subDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<wk_euninsanpu_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public wk_euninsanpu_subDto GetDtoByKey(long workseq, string atenano, long torokuno)
        {
            return SELECT.WHERE.ByKey(workseq, atenano, torokuno).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long workseq, string atenano, long torokuno)
        {
            //物理削除
            DELETE.WHERE.ByKey(workseq, atenano, torokuno).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(wk_euninsanpu_subDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
