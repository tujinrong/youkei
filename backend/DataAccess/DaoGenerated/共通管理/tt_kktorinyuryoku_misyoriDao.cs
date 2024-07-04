// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　一括取込入力未処理テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kktorinyuryoku_misyoriDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kktorinyuryoku_misyori";

        public tt_kktorinyuryoku_misyoriDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kktorinyuryoku_misyoriDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kktorinyuryoku_misyoriDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kktorinyuryoku_misyoriDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kktorinyuryoku_misyoriDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kktorinyuryoku_misyoriDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kktorinyuryoku_misyoriDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kktorinyuryoku_misyoriDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kktorinyuryoku_misyoriDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kktorinyuryoku_misyoriDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kktorinyuryoku_misyoriDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kktorinyuryoku_misyoriDto GetDtoByKey(int impjikkoid)
        {
            return SELECT.WHERE.ByKey(impjikkoid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int impjikkoid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(impjikkoid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kktorinyuryoku_misyoriDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
