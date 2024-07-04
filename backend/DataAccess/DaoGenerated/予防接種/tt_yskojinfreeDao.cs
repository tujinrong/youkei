// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　予防接種（フリー項目）個人テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_yskojinfreeDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_yskojinfree";

        public tt_yskojinfreeDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_yskojinfreeDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_yskojinfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_yskojinfreeDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_yskojinfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_yskojinfreeDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_yskojinfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_yskojinfreeDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_yskojinfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_yskojinfreeDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_yskojinfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_yskojinfreeDto GetDtoByKey(string atenano, string itemcd)
        {
            return SELECT.WHERE.ByKey(atenano, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, string itemcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, itemcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_yskojinfreeDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
