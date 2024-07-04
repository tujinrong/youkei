// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　一括取込入力登録マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktorinyuryoku_torokuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kktorinyuryoku_toroku";

        public tm_kktorinyuryoku_torokuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kktorinyuryoku_torokuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kktorinyuryoku_torokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kktorinyuryoku_torokuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kktorinyuryoku_torokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kktorinyuryoku_torokuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kktorinyuryoku_torokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kktorinyuryoku_torokuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kktorinyuryoku_torokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kktorinyuryoku_torokuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kktorinyuryoku_torokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kktorinyuryoku_torokuDto GetDtoByKey(string torinyuryokuno, string tableid, int recordno, string fieldnm)
        {
            return SELECT.WHERE.ByKey(torinyuryokuno, tableid, recordno, fieldnm).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string torinyuryokuno, string tableid, int recordno, string fieldnm)
        {
            //物理削除
            DELETE.WHERE.ByKey(torinyuryokuno, tableid, recordno, fieldnm).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_kktorinyuryoku_torokuDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
