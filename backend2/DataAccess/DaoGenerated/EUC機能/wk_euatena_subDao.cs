// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　宛名ワークテーブルサブ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class wk_euatena_subDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "wk_euatena_sub";

        public wk_euatena_subDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<wk_euatena_subDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<wk_euatena_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<wk_euatena_subDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<wk_euatena_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<wk_euatena_subDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<wk_euatena_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<wk_euatena_subDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<wk_euatena_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<wk_euatena_subDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<wk_euatena_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public wk_euatena_subDto GetDtoByKey(long workseq, string atenano)
        {
            return SELECT.WHERE.ByKey(workseq, atenano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long workseq, string atenano)
        {
            //物理削除
            DELETE.WHERE.ByKey(workseq, atenano).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(wk_euatena_subDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
