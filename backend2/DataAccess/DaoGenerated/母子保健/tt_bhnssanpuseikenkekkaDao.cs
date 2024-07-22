// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　産婦精密健診結果（固定）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnssanpuseikenkekkaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhnssanpuseikenkekka";

        public tt_bhnssanpuseikenkekkaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhnssanpuseikenkekkaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhnssanpuseikenkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhnssanpuseikenkekkaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhnssanpuseikenkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhnssanpuseikenkekkaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhnssanpuseikenkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhnssanpuseikenkekkaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhnssanpuseikenkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhnssanpuseikenkekkaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhnssanpuseikenkekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhnssanpuseikenkekkaDto GetDtoByKey(string atenano, long torokuno, int edano)
        {
            return SELECT.WHERE.ByKey(atenano, torokuno, edano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, long torokuno, int edano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, torokuno, edano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhnssanpuseikenkekkaDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
