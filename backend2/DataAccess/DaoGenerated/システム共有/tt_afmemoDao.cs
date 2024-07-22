// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　メモテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afmemoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afmemo";

        public tt_afmemoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afmemoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afmemoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afmemoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afmemoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afmemoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afmemoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afmemoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afmemoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afmemoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afmemoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afmemoDto GetDtoByKey(string atenano, int memoseq)
        {
            return SELECT.WHERE.ByKey(atenano, memoseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int memoseq, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, memoseq).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afmemoDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
