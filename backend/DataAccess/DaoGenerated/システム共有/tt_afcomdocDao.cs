// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　共通ドキュメントテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afcomdocDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afcomdoc";

        public tt_afcomdocDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afcomdocDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afcomdocDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afcomdocDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afcomdocDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afcomdocDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afcomdocDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afcomdocDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afcomdocDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afcomdocDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afcomdocDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afcomdocDto GetDtoByKey(long docseq)
        {
            return SELECT.WHERE.ByKey(docseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long docseq, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(docseq).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afcomdocDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
