// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　取込基本情報マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktori_kihonDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_kktori_kihon";

        public tm_kktori_kihonDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_kktori_kihonDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_kktori_kihonDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_kktori_kihonDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_kktori_kihonDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_kktori_kihonDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_kktori_kihonDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_kktori_kihonDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_kktori_kihonDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_kktori_kihonDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_kktori_kihonDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_kktori_kihonDto GetDtoByKey(string torinyuryokuno)
        {
            return SELECT.WHERE.ByKey(torinyuryokuno).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string torinyuryokuno)
        {
            //物理削除
            DELETE.WHERE.ByKey(torinyuryokuno).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_kktori_kihonDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
