// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　帳票発行履歴テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afrpthakkorirekiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afrpthakkorireki";

        public tt_afrpthakkorirekiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afrpthakkorirekiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afrpthakkorirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afrpthakkorirekiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afrpthakkorirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afrpthakkorirekiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afrpthakkorirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afrpthakkorirekiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afrpthakkorirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afrpthakkorirekiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afrpthakkorirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afrpthakkorirekiDto GetDtoByKey(long hakkoseq, int hakkoseqeda)
        {
            return SELECT.WHERE.ByKey(hakkoseq, hakkoseqeda).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long hakkoseq, int hakkoseqeda, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(hakkoseq, hakkoseqeda).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afrpthakkorirekiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
