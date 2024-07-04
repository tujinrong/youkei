// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　罹患テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_ysrikanDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_ysrikan";

        public tt_ysrikanDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_ysrikanDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_ysrikanDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_ysrikanDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_ysrikanDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_ysrikanDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_ysrikanDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_ysrikanDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_ysrikanDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_ysrikanDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_ysrikanDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_ysrikanDto GetDtoByKey(string atenano, string rikancd)
        {
            return SELECT.WHERE.ByKey(atenano, rikancd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, string rikancd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, rikancd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_ysrikanDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
