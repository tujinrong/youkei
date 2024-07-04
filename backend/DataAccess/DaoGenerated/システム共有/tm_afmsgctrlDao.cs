// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　メッセージコントロールマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afmsgctrlDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afmsgctrl";

        public tm_afmsgctrlDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afmsgctrlDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afmsgctrlDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afmsgctrlDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afmsgctrlDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afmsgctrlDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afmsgctrlDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afmsgctrlDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afmsgctrlDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afmsgctrlDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afmsgctrlDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afmsgctrlDto GetDtoByKey(string ctrlmsgid)
        {
            return SELECT.WHERE.ByKey(ctrlmsgid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string ctrlmsgid)
        {
            //物理削除
            DELETE.WHERE.ByKey(ctrlmsgid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afmsgctrlDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
