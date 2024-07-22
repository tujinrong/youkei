// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　母子健康手帳交付（固定）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnsbosikenkotetyokofuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnsbosikenkotetyokofu";

        public tt_bhnsbosikenkotetyokofuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnsbosikenkotetyokofuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnsbosikenkotetyokofuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnsbosikenkotetyokofuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnsbosikenkotetyokofuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnsbosikenkotetyokofuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnsbosikenkotetyokofuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnsbosikenkotetyokofuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnsbosikenkotetyokofuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnsbosikenkotetyokofuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnsbosikenkotetyokofuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnsbosikenkotetyokofuDto GetDtoByKey(string atenano, long torokuno, int torokunorenban)
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
        public void UpdateDto(tt_bhnsbosikenkotetyokofuDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
