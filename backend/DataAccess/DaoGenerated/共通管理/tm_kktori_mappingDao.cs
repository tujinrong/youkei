// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　取込項目マッピングマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktori_mappingDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kktori_mapping";

        public tm_kktori_mappingDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kktori_mappingDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kktori_mappingDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kktori_mappingDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kktori_mappingDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kktori_mappingDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kktori_mappingDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kktori_mappingDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kktori_mappingDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kktori_mappingDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kktori_mappingDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kktori_mappingDto GetDtoByKey(string torinyuryokuno, int gamenitemseq)
        {
            return SELECT.WHERE.ByKey(torinyuryokuno, gamenitemseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string torinyuryokuno, int gamenitemseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(torinyuryokuno, gamenitemseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_kktori_mappingDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
