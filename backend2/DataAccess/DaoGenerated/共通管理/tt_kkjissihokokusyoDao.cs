// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　実施報告書（日報）情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkjissihokokusyoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kkjissihokokusyo";

        public tt_kkjissihokokusyoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kkjissihokokusyoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kkjissihokokusyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kkjissihokokusyoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kkjissihokokusyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kkjissihokokusyoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kkjissihokokusyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kkjissihokokusyoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kkjissihokokusyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kkjissihokokusyoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kkjissihokokusyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kkjissihokokusyoDto GetDtoByKey(long hokokusyono)
        {
            return SELECT.WHERE.ByKey(hokokusyono).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long hokokusyono, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(hokokusyono).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kkjissihokokusyoDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
