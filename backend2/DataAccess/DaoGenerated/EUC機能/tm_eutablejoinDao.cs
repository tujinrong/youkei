// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUCテーブル結合マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eutablejoinDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eutablejoin";

        public tm_eutablejoinDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eutablejoinDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eutablejoinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eutablejoinDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eutablejoinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eutablejoinDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eutablejoinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eutablejoinDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eutablejoinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eutablejoinDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eutablejoinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eutablejoinDto GetDtoByKey(string tablealias, string kanrentablealias)
        {
            return SELECT.WHERE.ByKey(tablealias, kanrentablealias).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string tablealias, string kanrentablealias)
        {
            //物理削除
            DELETE.WHERE.ByKey(tablealias, kanrentablealias).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eutablejoinDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
