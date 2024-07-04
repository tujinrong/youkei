// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　出産の状態に係る（固定）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnssyussanjotaiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnssyussanjotai";

        public tt_bhnssyussanjotaiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnssyussanjotaiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnssyussanjotaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnssyussanjotaiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnssyussanjotaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnssyussanjotaiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnssyussanjotaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnssyussanjotaiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnssyussanjotaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnssyussanjotaiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnssyussanjotaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnssyussanjotaiDto GetDtoByKey(string atenano, long torokuno, int torokunorenban)
        {
            return SELECT.WHERE.ByKey(atenano, torokuno, torokunorenban).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, long torokuno, int torokunorenban, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, torokuno, torokunorenban).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnssyussanjotaiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
