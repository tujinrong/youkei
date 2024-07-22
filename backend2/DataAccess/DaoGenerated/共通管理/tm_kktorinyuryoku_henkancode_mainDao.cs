// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　一括取込入力変換コードメインマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktorinyuryoku_henkancode_mainDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kktorinyuryoku_henkancode_main";

        public tm_kktorinyuryoku_henkancode_mainDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kktorinyuryoku_henkancode_mainDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kktorinyuryoku_henkancode_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kktorinyuryoku_henkancode_mainDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kktorinyuryoku_henkancode_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kktorinyuryoku_henkancode_mainDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kktorinyuryoku_henkancode_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kktorinyuryoku_henkancode_mainDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kktorinyuryoku_henkancode_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kktorinyuryoku_henkancode_mainDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kktorinyuryoku_henkancode_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kktorinyuryoku_henkancode_mainDto GetDtoByKey(string torinyuryokuno, int codehenkankbn)
        {
            return SELECT.WHERE.ByKey(torinyuryokuno, codehenkankbn).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string torinyuryokuno, int codehenkankbn)
        {
            //物理削除
            DELETE.WHERE.ByKey(torinyuryokuno, codehenkankbn).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_kktorinyuryoku_henkancode_mainDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
