// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　ジョブ管理テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afjobDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afjob";

        public tt_afjobDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afjobDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afjobDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afjobDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afjobDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afjobDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afjobDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afjobDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afjobDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afjobDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afjobDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afjobDto GetDtoByKey(int jobseq)
        {
            return SELECT.WHERE.ByKey(jobseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int jobseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(jobseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afjobDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
