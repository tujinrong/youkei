// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　年度マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_shnendoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_shnendo";

        public tm_shnendoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_shnendoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_shnendoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_shnendoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_shnendoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_shnendoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_shnendoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_shnendoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_shnendoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_shnendoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_shnendoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_shnendoDto GetDtoByKey(int nendo, string jigyocd, string kensahohocd)
        {
            return SELECT.WHERE.ByKey(nendo, jigyocd, kensahohocd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int nendo, string jigyocd, string kensahohocd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(nendo, jigyocd, kensahohocd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_shnendoDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
