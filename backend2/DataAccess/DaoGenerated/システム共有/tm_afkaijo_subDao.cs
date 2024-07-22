// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　会場情報サブマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afkaijo_subDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afkaijo_sub";

        public tm_afkaijo_subDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afkaijo_subDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afkaijo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afkaijo_subDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afkaijo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afkaijo_subDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afkaijo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afkaijo_subDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afkaijo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afkaijo_subDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afkaijo_subDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afkaijo_subDto GetDtoByKey(string kaijocd, string tikukbn, string tikucd)
        {
            return SELECT.WHERE.ByKey(kaijocd, tikukbn, tikucd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string kaijocd, string tikukbn, string tikucd)
        {
            //物理削除
            DELETE.WHERE.ByKey(kaijocd, tikukbn, tikucd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afkaijo_subDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
