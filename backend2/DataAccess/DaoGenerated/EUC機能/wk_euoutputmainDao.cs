// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　workテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class wk_euoutputmainDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "wk_euoutputmain";

        public wk_euoutputmainDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<wk_euoutputmainDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<wk_euoutputmainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<wk_euoutputmainDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<wk_euoutputmainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<wk_euoutputmainDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<wk_euoutputmainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<wk_euoutputmainDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<wk_euoutputmainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<wk_euoutputmainDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<wk_euoutputmainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public wk_euoutputmainDto GetDtoByKey(long workseq)
        {
            return SELECT.WHERE.ByKey(workseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long workseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(workseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(wk_euoutputmainDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
