// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　帳票テンプレートファイルマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eutemplatefileDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eutemplatefile";

        public tm_eutemplatefileDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eutemplatefileDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eutemplatefileDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eutemplatefileDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eutemplatefileDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eutemplatefileDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eutemplatefileDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eutemplatefileDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eutemplatefileDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eutemplatefileDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eutemplatefileDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eutemplatefileDto GetDtoByKey(string siyokbn)
        {
            return SELECT.WHERE.ByKey(siyokbn).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string siyokbn, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(siyokbn).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eutemplatefileDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
