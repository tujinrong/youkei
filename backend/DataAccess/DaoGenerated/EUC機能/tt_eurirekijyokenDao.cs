// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUC帳票出力履歴条件テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_eurirekijyokenDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_eurirekijyoken";

        public tt_eurirekijyokenDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_eurirekijyokenDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_eurirekijyokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_eurirekijyokenDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_eurirekijyokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_eurirekijyokenDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_eurirekijyokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_eurirekijyokenDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_eurirekijyokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_eurirekijyokenDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_eurirekijyokenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_eurirekijyokenDto GetDtoByKey(long rirekiseq, int jyokenseq)
        {
            return SELECT.WHERE.ByKey(rirekiseq, jyokenseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long rirekiseq, int jyokenseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(rirekiseq, jyokenseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_eurirekijyokenDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
