// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　予防接種事業マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_ysjigyoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_ysjigyo";

        public tm_ysjigyoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_ysjigyoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_ysjigyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_ysjigyoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_ysjigyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_ysjigyoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_ysjigyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_ysjigyoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_ysjigyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_ysjigyoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_ysjigyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_ysjigyoDto GetDtoByKey(string jigyocd)
        {
            return SELECT.WHERE.ByKey(jigyocd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string jigyocd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(jigyocd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_ysjigyoDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
