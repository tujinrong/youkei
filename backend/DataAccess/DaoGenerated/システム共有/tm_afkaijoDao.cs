// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　会場情報マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afkaijoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afkaijo";

        public tm_afkaijoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afkaijoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afkaijoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afkaijoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afkaijoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afkaijoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afkaijoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afkaijoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afkaijoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afkaijoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afkaijoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afkaijoDto GetDtoByKey(string kaijocd)
        {
            return SELECT.WHERE.ByKey(kaijocd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string kaijocd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(kaijocd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afkaijoDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
