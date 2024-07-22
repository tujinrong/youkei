// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　出力順パターンサブテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_eusort_subDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_eusort_sub";

        public tt_eusort_subDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_eusort_subDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_eusort_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_eusort_subDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_eusort_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_eusort_subDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_eusort_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_eusort_subDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_eusort_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_eusort_subDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_eusort_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_eusort_subDto GetDtoByKey(string rptid, string yosikiid, int sortptnno, string reportitemid)
        {
            return SELECT.WHERE.ByKey(rptid, yosikiid, sortptnno, reportitemid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string rptid, string yosikiid, int sortptnno, string reportitemid)
        {
            //物理削除
            DELETE.WHERE.ByKey(rptid, yosikiid, sortptnno, reportitemid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_eusort_subDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
