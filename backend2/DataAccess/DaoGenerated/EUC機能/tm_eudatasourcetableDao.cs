// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUCデータソーステーブルマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eudatasourcetableDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eudatasourcetable";

        public tm_eudatasourcetableDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eudatasourcetableDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eudatasourcetableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eudatasourcetableDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eudatasourcetableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eudatasourcetableDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eudatasourcetableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eudatasourcetableDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eudatasourcetableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eudatasourcetableDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eudatasourcetableDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eudatasourcetableDto GetDtoByKey(string datasourceid, string tablealias)
        {
            return SELECT.WHERE.ByKey(datasourceid, tablealias).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string datasourceid, string tablealias, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(datasourceid, tablealias).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eudatasourcetableDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
