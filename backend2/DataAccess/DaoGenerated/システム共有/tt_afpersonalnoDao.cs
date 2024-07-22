// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　個人番号管理テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afpersonalnoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afpersonalno";

        public tt_afpersonalnoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afpersonalnoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afpersonalnoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afpersonalnoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afpersonalnoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afpersonalnoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afpersonalnoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afpersonalnoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afpersonalnoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afpersonalnoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afpersonalnoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afpersonalnoDto GetDtoByKey(string atenano, int rirekino)
        {
            return SELECT.WHERE.ByKey(atenano, rirekino).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int rirekino, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, rirekino).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afpersonalnoDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
