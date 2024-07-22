// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　CSV出力パターンサブテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_eucsv_subDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_eucsv_sub";

        public tt_eucsv_subDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_eucsv_subDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_eucsv_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_eucsv_subDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_eucsv_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_eucsv_subDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_eucsv_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_eucsv_subDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_eucsv_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_eucsv_subDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_eucsv_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_eucsv_subDto GetDtoByKey(string rptid, string yosikiid, int outputptnno, string reportitemid)
        {
            return SELECT.WHERE.ByKey(rptid, yosikiid, outputptnno, reportitemid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string rptid, string yosikiid, int outputptnno, string reportitemid)
        {
            //物理削除
            DELETE.WHERE.ByKey(rptid, yosikiid, outputptnno, reportitemid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_eucsv_subDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
