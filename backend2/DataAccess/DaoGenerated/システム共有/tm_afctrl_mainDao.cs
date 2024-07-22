// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　コントロールメインマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afctrl_mainDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afctrl_main";

        public tm_afctrl_mainDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afctrl_mainDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afctrl_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afctrl_mainDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afctrl_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afctrl_mainDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afctrl_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afctrl_mainDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afctrl_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afctrl_mainDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afctrl_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afctrl_mainDto GetDtoByKey(string ctrlmaincd, int ctrlsubcd)
        {
            return SELECT.WHERE.ByKey(ctrlmaincd, ctrlsubcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string ctrlmaincd, int ctrlsubcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(ctrlmaincd, ctrlsubcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afctrl_mainDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
