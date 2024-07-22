// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　医療機関サブマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afkikan_subDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afkikan_sub";

        public tm_afkikan_subDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afkikan_subDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afkikan_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afkikan_subDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afkikan_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afkikan_subDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afkikan_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afkikan_subDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afkikan_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afkikan_subDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afkikan_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afkikan_subDto GetDtoByKey(string kikancd, string jissijigyo)
        {
            return SELECT.WHERE.ByKey(kikancd, jissijigyo).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string kikancd, string jissijigyo)
        {
            //物理削除
            DELETE.WHERE.ByKey(kikancd, jissijigyo).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afkikan_subDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
