// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　一括取込入力プロシージャマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktorinyuryoku_procDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kktorinyuryoku_proc";

        public tm_kktorinyuryoku_procDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kktorinyuryoku_procDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kktorinyuryoku_procDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kktorinyuryoku_procDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kktorinyuryoku_procDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kktorinyuryoku_procDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kktorinyuryoku_procDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kktorinyuryoku_procDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kktorinyuryoku_procDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kktorinyuryoku_procDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kktorinyuryoku_procDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kktorinyuryoku_procDto GetDtoByKey(string procseq)
        {
            return SELECT.WHERE.ByKey(procseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string procseq, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(procseq).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_kktorinyuryoku_procDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
