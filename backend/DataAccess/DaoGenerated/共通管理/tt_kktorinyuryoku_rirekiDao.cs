// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　一括取込入力履歴テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kktorinyuryoku_rirekiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kktorinyuryoku_rireki";

        public tt_kktorinyuryoku_rirekiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kktorinyuryoku_rirekiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kktorinyuryoku_rirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kktorinyuryoku_rirekiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kktorinyuryoku_rirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kktorinyuryoku_rirekiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kktorinyuryoku_rirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kktorinyuryoku_rirekiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kktorinyuryoku_rirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kktorinyuryoku_rirekiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kktorinyuryoku_rirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kktorinyuryoku_rirekiDto GetDtoByKey(int imprirekino)
        {
            return SELECT.WHERE.ByKey(imprirekino).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int imprirekino)
        {
            //物理削除
            DELETE.WHERE.ByKey(imprirekino).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kktorinyuryoku_rirekiDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
