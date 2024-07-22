// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　取込変換コードマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktori_henkancodeDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kktori_henkancode";

        public tm_kktori_henkancodeDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kktori_henkancodeDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kktori_henkancodeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kktori_henkancodeDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kktori_henkancodeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kktori_henkancodeDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kktori_henkancodeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kktori_henkancodeDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kktori_henkancodeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kktori_henkancodeDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kktori_henkancodeDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kktori_henkancodeDto GetDtoByKey(string torinyuryokuno, int codehenkankbn, string motocd)
        {
            return SELECT.WHERE.ByKey(torinyuryokuno, codehenkankbn, motocd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string torinyuryokuno, int codehenkankbn, string motocd)
        {
            //物理削除
            DELETE.WHERE.ByKey(torinyuryokuno, codehenkankbn, motocd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_kktori_henkancodeDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
