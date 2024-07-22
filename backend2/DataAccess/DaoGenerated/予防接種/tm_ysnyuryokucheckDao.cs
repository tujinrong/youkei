// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　予防接種入力チェックマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_ysnyuryokucheckDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_ysnyuryokucheck";

        public tm_ysnyuryokucheckDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_ysnyuryokucheckDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_ysnyuryokucheckDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_ysnyuryokucheckDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_ysnyuryokucheckDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_ysnyuryokucheckDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_ysnyuryokucheckDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_ysnyuryokucheckDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_ysnyuryokucheckDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_ysnyuryokucheckDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_ysnyuryokucheckDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_ysnyuryokucheckDto GetDtoByKey(string sessyucd, string kaisu)
        {
            return SELECT.WHERE.ByKey(sessyucd, kaisu).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string sessyucd, string kaisu, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(sessyucd, kaisu).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_ysnyuryokucheckDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
