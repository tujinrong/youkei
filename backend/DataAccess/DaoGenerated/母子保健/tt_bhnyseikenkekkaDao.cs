// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　乳幼児精密健診結果（固定項目）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnyseikenkekkaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnyseikenkekka";

        public tt_bhnyseikenkekkaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnyseikenkekkaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnyseikenkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnyseikenkekkaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnyseikenkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnyseikenkekkaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnyseikenkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnyseikenkekkaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnyseikenkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnyseikenkekkaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnyseikenkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnyseikenkekkaDto GetDtoByKey(string atenano, int edano)
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
        public void UpdateDto(tt_bhnyseikenkekkaDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
