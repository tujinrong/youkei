// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　事業予定テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkjigyoyoteiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kkjigyoyotei";

        public tt_kkjigyoyoteiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kkjigyoyoteiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kkjigyoyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kkjigyoyoteiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kkjigyoyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kkjigyoyoteiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kkjigyoyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kkjigyoyoteiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kkjigyoyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kkjigyoyoteiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kkjigyoyoteiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kkjigyoyoteiDto GetDtoByKey(int nitteino)
        {
            return SELECT.WHERE.ByKey(nitteino).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int nitteino, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(nitteino).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kkjigyoyoteiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
