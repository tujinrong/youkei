// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　事業予定コーステーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkjigyoyoteicourseDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kkjigyoyoteicourse";

        public tt_kkjigyoyoteicourseDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kkjigyoyoteicourseDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kkjigyoyoteicourseDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kkjigyoyoteicourseDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kkjigyoyoteicourseDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kkjigyoyoteicourseDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kkjigyoyoteicourseDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kkjigyoyoteicourseDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kkjigyoyoteicourseDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kkjigyoyoteicourseDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kkjigyoyoteicourseDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kkjigyoyoteicourseDto GetDtoByKey(int courseno)
        {
            return SELECT.WHERE.ByKey(courseno).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int courseno, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(courseno).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kkjigyoyoteicourseDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
