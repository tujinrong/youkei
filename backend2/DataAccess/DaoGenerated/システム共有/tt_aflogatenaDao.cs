// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　宛名番号ログテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_aflogatenaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_aflogatena";

        public tt_aflogatenaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_aflogatenaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_aflogatenaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_aflogatenaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_aflogatenaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_aflogatenaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_aflogatenaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_aflogatenaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_aflogatenaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_aflogatenaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_aflogatenaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_aflogatenaDto GetDtoByKey(long atenalogseq)
        {
            return SELECT.WHERE.ByKey(atenalogseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long atenalogseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenalogseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_aflogatenaDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
