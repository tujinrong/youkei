// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　その他日程事業・保健指導事業マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kksonotasidojigyoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kksonotasidojigyo";

        public tm_kksonotasidojigyoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kksonotasidojigyoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kksonotasidojigyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kksonotasidojigyoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kksonotasidojigyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kksonotasidojigyoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kksonotasidojigyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kksonotasidojigyoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kksonotasidojigyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kksonotasidojigyoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kksonotasidojigyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kksonotasidojigyoDto GetDtoByKey(string jigyocd)
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
        public void UpdateDto(tm_kksonotasidojigyoDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
