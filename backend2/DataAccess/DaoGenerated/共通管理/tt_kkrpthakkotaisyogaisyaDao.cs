// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　帳票発行対象外者テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkrpthakkotaisyogaisyaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kkrpthakkotaisyogaisya";

        public tt_kkrpthakkotaisyogaisyaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kkrpthakkotaisyogaisyaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kkrpthakkotaisyogaisyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kkrpthakkotaisyogaisyaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kkrpthakkotaisyogaisyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kkrpthakkotaisyogaisyaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kkrpthakkotaisyogaisyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kkrpthakkotaisyogaisyaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kkrpthakkotaisyogaisyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kkrpthakkotaisyogaisyaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kkrpthakkotaisyogaisyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kkrpthakkotaisyogaisyaDto GetDtoByKey(string atenano, string rptgroupid)
        {
            return SELECT.WHERE.ByKey(atenano, rptgroupid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, string rptgroupid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, rptgroupid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kkrpthakkotaisyogaisyaDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
