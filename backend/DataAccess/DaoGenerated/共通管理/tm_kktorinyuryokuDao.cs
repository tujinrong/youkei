// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　一括取込入力マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktorinyuryokuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kktorinyuryoku";

        public tm_kktorinyuryokuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kktorinyuryokuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kktorinyuryokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kktorinyuryokuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kktorinyuryokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kktorinyuryokuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kktorinyuryokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kktorinyuryokuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kktorinyuryokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kktorinyuryokuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kktorinyuryokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kktorinyuryokuDto GetDtoByKey(string torinyuryokuno)
        {
            return SELECT.WHERE.ByKey(torinyuryokuno).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string torinyuryokuno, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(torinyuryokuno).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_kktorinyuryokuDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
