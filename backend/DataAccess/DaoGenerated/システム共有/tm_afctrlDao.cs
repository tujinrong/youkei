// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　コントロールマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afctrlDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afctrl";

        public tm_afctrlDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afctrlDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afctrlDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afctrlDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afctrlDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afctrlDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afctrlDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afctrlDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afctrlDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afctrlDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afctrlDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afctrlDto GetDtoByKey(string ctrlmaincd, int ctrlsubcd, string ctrlcd)
        {
            return SELECT.WHERE.ByKey(ctrlmaincd, ctrlsubcd, ctrlcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string ctrlmaincd, int ctrlsubcd, string ctrlcd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(ctrlmaincd, ctrlsubcd, ctrlcd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afctrlDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
