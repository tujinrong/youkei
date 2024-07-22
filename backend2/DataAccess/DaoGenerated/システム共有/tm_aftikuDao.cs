// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　地区情報マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_aftikuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_aftiku";

        public tm_aftikuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_aftikuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_aftikuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_aftikuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_aftikuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_aftikuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_aftikuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_aftikuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_aftikuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_aftikuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_aftikuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_aftikuDto GetDtoByKey(string tikukbn, string tikucd)
        {
            return SELECT.WHERE.ByKey(tikukbn, tikucd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string tikukbn, string tikucd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(tikukbn, tikucd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_aftikuDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
