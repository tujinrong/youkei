// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　対象者抽出情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kktaisyosya_tyusyutuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kktaisyosya_tyusyutu";

        public tt_kktaisyosya_tyusyutuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kktaisyosya_tyusyutuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kktaisyosya_tyusyutuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kktaisyosya_tyusyutuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kktaisyosya_tyusyutuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kktaisyosya_tyusyutuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kktaisyosya_tyusyutuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kktaisyosya_tyusyutuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kktaisyosya_tyusyutuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kktaisyosya_tyusyutuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kktaisyosya_tyusyutuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kktaisyosya_tyusyutuDto GetDtoByKey(long tyusyutuseq)
        {
            return SELECT.WHERE.ByKey(tyusyutuseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long tyusyutuseq, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(tyusyutuseq).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kktaisyosya_tyusyutuDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
