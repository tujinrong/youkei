// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　宛名番号検索履歴テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afatenalogDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afatenalog";

        public tt_afatenalogDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afatenalogDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afatenalogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afatenalogDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afatenalogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afatenalogDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afatenalogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afatenalogDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afatenalogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afatenalogDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afatenalogDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afatenalogDto GetDtoByKey(string userid, string kinoid, string atenano)
        {
            return SELECT.WHERE.ByKey(userid, kinoid, atenano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string userid, string kinoid, string atenano)
        {
            //物理削除
            DELETE.WHERE.ByKey(userid, kinoid, atenano).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afatenalogDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
