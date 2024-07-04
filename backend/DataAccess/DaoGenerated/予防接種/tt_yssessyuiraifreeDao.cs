// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　予防接種依頼（フリー項目）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_yssessyuiraifreeDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_yssessyuiraifree";

        public tt_yssessyuiraifreeDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_yssessyuiraifreeDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_yssessyuiraifreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_yssessyuiraifreeDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_yssessyuiraifreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_yssessyuiraifreeDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_yssessyuiraifreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_yssessyuiraifreeDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_yssessyuiraifreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_yssessyuiraifreeDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_yssessyuiraifreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_yssessyuiraifreeDto GetDtoByKey(string atenano, int edano, string itemcd)
        {
            return SELECT.WHERE.ByKey(atenano, edano, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int edano, string itemcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, edano, itemcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_yssessyuiraifreeDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
