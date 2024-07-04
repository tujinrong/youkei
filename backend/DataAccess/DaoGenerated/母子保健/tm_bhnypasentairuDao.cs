// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　乳幼児パーセンタイル値マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhnypasentairuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_bhnypasentairu";

        public tm_bhnypasentairuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_bhnypasentairuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_bhnypasentairuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_bhnypasentairuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_bhnypasentairuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_bhnypasentairuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_bhnypasentairuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_bhnypasentairuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_bhnypasentairuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_bhnypasentairuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_bhnypasentairuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_bhnypasentairuDto GetDtoByKey(string buicd, string sex, int month, int date, string pasentairucd)
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
        public void UpdateDto(tm_bhnypasentairuDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
