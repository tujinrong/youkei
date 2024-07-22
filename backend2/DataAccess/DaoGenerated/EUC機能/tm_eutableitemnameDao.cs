// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUCテーブル項目名称マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eutableitemnameDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eutableitemname";

        public tm_eutableitemnameDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eutableitemnameDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eutableitemnameDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eutableitemnameDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eutableitemnameDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eutableitemnameDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eutableitemnameDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eutableitemnameDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eutableitemnameDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eutableitemnameDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eutableitemnameDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eutableitemnameDto GetDtoByKey(string mastercd)
        {
            return SELECT.WHERE.ByKey(mastercd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string mastercd)
        {
            //物理削除
            DELETE.WHERE.ByKey(mastercd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eutableitemnameDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
