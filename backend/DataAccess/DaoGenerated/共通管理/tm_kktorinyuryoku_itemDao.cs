// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　一括取込入力項目定義マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktorinyuryoku_itemDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kktorinyuryoku_item";

        public tm_kktorinyuryoku_itemDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kktorinyuryoku_itemDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kktorinyuryoku_itemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kktorinyuryoku_itemDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kktorinyuryoku_itemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kktorinyuryoku_itemDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kktorinyuryoku_itemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kktorinyuryoku_itemDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kktorinyuryoku_itemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kktorinyuryoku_itemDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kktorinyuryoku_itemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kktorinyuryoku_itemDto GetDtoByKey(string torinyuryokuno, int gamenitemseq)
        {
            return SELECT.WHERE.ByKey(torinyuryokuno, gamenitemseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string torinyuryokuno, int gamenitemseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(torinyuryokuno, gamenitemseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_kktorinyuryoku_itemDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
