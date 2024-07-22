// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　対象者抽出情報項目テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kktaisyosya_tyusyutufreeDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kktaisyosya_tyusyutufree";

        public tt_kktaisyosya_tyusyutufreeDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kktaisyosya_tyusyutufreeDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kktaisyosya_tyusyutufreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kktaisyosya_tyusyutufreeDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kktaisyosya_tyusyutufreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kktaisyosya_tyusyutufreeDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kktaisyosya_tyusyutufreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kktaisyosya_tyusyutufreeDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kktaisyosya_tyusyutufreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kktaisyosya_tyusyutufreeDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kktaisyosya_tyusyutufreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kktaisyosya_tyusyutufreeDto GetDtoByKey(long tyusyutuseq, string itemcd)
        {
            return SELECT.WHERE.ByKey(tyusyutuseq, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long tyusyutuseq, string itemcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(tyusyutuseq, itemcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kktaisyosya_tyusyutufreeDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
