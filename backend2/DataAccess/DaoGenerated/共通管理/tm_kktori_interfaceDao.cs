// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　取込IFマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktori_interfaceDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kktori_interface";

        public tm_kktori_interfaceDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kktori_interfaceDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kktori_interfaceDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kktori_interfaceDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kktori_interfaceDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kktori_interfaceDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kktori_interfaceDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kktori_interfaceDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kktori_interfaceDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kktori_interfaceDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kktori_interfaceDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kktori_interfaceDto GetDtoByKey(string torinyuryokuno, int fileitemseq)
        {
            return SELECT.WHERE.ByKey(torinyuryokuno, fileitemseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string torinyuryokuno, int fileitemseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(torinyuryokuno, fileitemseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_kktori_interfaceDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
