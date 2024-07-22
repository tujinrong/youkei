// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUCテーブル関連マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eutablekanrenDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eutablekanren";

        public tm_eutablekanrenDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eutablekanrenDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eutablekanrenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eutablekanrenDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eutablekanrenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eutablekanrenDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eutablekanrenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eutablekanrenDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eutablekanrenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eutablekanrenDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eutablekanrenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eutablekanrenDto GetDtoByKey(string tablenm, string kanrentablenm, string jibunkey)
        {
            return SELECT.WHERE.ByKey(tablenm, kanrentablenm, jibunkey).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string tablenm, string kanrentablenm, string jibunkey)
        {
            //物理削除
            DELETE.WHERE.ByKey(tablenm, kanrentablenm, jibunkey).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eutablekanrenDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
