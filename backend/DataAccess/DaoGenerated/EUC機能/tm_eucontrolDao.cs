// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUC帳票コントロールマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eucontrolDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eucontrol";

        public tm_eucontrolDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eucontrolDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eucontrolDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eucontrolDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eucontrolDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eucontrolDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eucontrolDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eucontrolDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eucontrolDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eucontrolDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eucontrolDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eucontrolDto GetDtoByKey(int controlid)
        {
            return SELECT.WHERE.ByKey(controlid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int controlid)
        {
            //物理削除
            DELETE.WHERE.ByKey(controlid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eucontrolDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
