// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　一括取込入力対象テーブルマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktorinyuryoku_taisyotableDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kktorinyuryoku_taisyotable";

        public tm_kktorinyuryoku_taisyotableDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kktorinyuryoku_taisyotableDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kktorinyuryoku_taisyotableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kktorinyuryoku_taisyotableDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kktorinyuryoku_taisyotableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kktorinyuryoku_taisyotableDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kktorinyuryoku_taisyotableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kktorinyuryoku_taisyotableDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kktorinyuryoku_taisyotableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kktorinyuryoku_taisyotableDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kktorinyuryoku_taisyotableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kktorinyuryoku_taisyotableDto GetDtoByKey(string torinyuryokuno, string tablenm)
        {
            return SELECT.WHERE.ByKey(torinyuryokuno, tablenm).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string torinyuryokuno, string tablenm)
        {
            //物理削除
            DELETE.WHERE.ByKey(torinyuryokuno, tablenm).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_kktorinyuryoku_taisyotableDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
