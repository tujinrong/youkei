// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnytyokakukensahiyojoseiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnytyokakukensahiyojosei";

        public tt_bhnytyokakukensahiyojoseiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnytyokakukensahiyojoseiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnytyokakukensahiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnytyokakukensahiyojoseiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnytyokakukensahiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnytyokakukensahiyojoseiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnytyokakukensahiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnytyokakukensahiyojoseiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnytyokakukensahiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnytyokakukensahiyojoseiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnytyokakukensahiyojoseiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnytyokakukensahiyojoseiDto GetDtoByKey(string atenano, int edano)
        {
            return SELECT.WHERE.ByKey(atenano, edano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int edano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, edano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnytyokakukensahiyojoseiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
