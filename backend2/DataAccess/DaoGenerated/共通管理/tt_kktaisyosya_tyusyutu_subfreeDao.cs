// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　対象者抽出情報サブ項目テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kktaisyosya_tyusyutu_subfreeDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kktaisyosya_tyusyutu_subfree";

        public tt_kktaisyosya_tyusyutu_subfreeDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kktaisyosya_tyusyutu_subfreeDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kktaisyosya_tyusyutu_subfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kktaisyosya_tyusyutu_subfreeDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kktaisyosya_tyusyutu_subfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kktaisyosya_tyusyutu_subfreeDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kktaisyosya_tyusyutu_subfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kktaisyosya_tyusyutu_subfreeDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kktaisyosya_tyusyutu_subfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kktaisyosya_tyusyutu_subfreeDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kktaisyosya_tyusyutu_subfreeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kktaisyosya_tyusyutu_subfreeDto GetDtoByKey(long tyusyutuseq, string atenano, string itemcd)
        {
            return SELECT.WHERE.ByKey(tyusyutuseq, atenano, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long tyusyutuseq, string atenano, string itemcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(tyusyutuseq, atenano, itemcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kktaisyosya_tyusyutu_subfreeDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
