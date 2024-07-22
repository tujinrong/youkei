// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　宛名ワークテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class wk_euatenaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "wk_euatena";

        public wk_euatenaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<wk_euatenaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<wk_euatenaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<wk_euatenaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<wk_euatenaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<wk_euatenaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<wk_euatenaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<wk_euatenaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<wk_euatenaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<wk_euatenaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<wk_euatenaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public wk_euatenaDto GetDtoByKey(long workseq)
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
        public void UpdateDto(wk_euatenaDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
