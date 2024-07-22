// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　母子保健パーセンタイル値マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhpasentairuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_bhpasentairu";

        public tm_bhpasentairuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_bhpasentairuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_bhpasentairuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_bhpasentairuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_bhpasentairuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_bhpasentairuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_bhpasentairuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_bhpasentairuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_bhpasentairuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_bhpasentairuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_bhpasentairuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_bhpasentairuDto GetDtoByKey(string buicd, string sex, int month, int date, string pasentairucd)
        {
            return SELECT.WHERE.ByKey(buicd, sex, month, date, pasentairucd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string buicd, string sex, int month, int date, string pasentairucd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(buicd, sex, month, date, pasentairucd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_bhpasentairuDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
