// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　実施報告書（日報）情報サブテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkjissihokokusyo_subDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kkjissihokokusyo_sub";

        public tt_kkjissihokokusyo_subDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kkjissihokokusyo_subDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kkjissihokokusyo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kkjissihokokusyo_subDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kkjissihokokusyo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kkjissihokokusyo_subDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kkjissihokokusyo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kkjissihokokusyo_subDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kkjissihokokusyo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kkjissihokokusyo_subDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kkjissihokokusyo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kkjissihokokusyo_subDto GetDtoByKey(long hokokusyono, string staffid)
        {
            return SELECT.WHERE.ByKey(hokokusyono, staffid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long hokokusyono, string staffid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(hokokusyono, staffid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kkjissihokokusyo_subDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
