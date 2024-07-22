// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　自己負担金マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_shjikofutankinDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_shjikofutankin";

        public tm_shjikofutankinDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_shjikofutankinDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_shjikofutankinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_shjikofutankinDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_shjikofutankinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_shjikofutankinDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_shjikofutankinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_shjikofutankinDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_shjikofutankinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_shjikofutankinDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_shjikofutankinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_shjikofutankinDto GetDtoByKey(int nendo, string kensin_jigyocd, string ryokinpattern, string kensahohocd, string sex, string agehani, string genmenkbn)
        {
            return SELECT.WHERE.ByKey(nendo, kensin_jigyocd, ryokinpattern, kensahohocd, sex, agehani, genmenkbn).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int nendo, string kensin_jigyocd, string ryokinpattern, string kensahohocd, string sex, string agehani, string genmenkbn, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(nendo, kensin_jigyocd, ryokinpattern, kensahohocd, sex, agehani, genmenkbn).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_shjikofutankinDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
