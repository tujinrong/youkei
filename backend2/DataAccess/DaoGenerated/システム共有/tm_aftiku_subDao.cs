// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　地区情報サブマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_aftiku_subDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_aftiku_sub";

        public tm_aftiku_subDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_aftiku_subDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_aftiku_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_aftiku_subDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_aftiku_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_aftiku_subDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_aftiku_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_aftiku_subDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_aftiku_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_aftiku_subDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_aftiku_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_aftiku_subDto GetDtoByKey(string tikukbn, string tikucd, string staffid)
        {
            return SELECT.WHERE.ByKey(tikukbn, tikucd, staffid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string tikukbn, string tikucd, string staffid)
        {
            //物理削除
            DELETE.WHERE.ByKey(tikukbn, tikucd, staffid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_aftiku_subDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
