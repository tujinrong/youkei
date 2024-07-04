// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　保健指導担当者テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkhokensido_staffDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kkhokensido_staff";

        public tt_kkhokensido_staffDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kkhokensido_staffDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kkhokensido_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kkhokensido_staffDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kkhokensido_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kkhokensido_staffDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kkhokensido_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kkhokensido_staffDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kkhokensido_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kkhokensido_staffDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kkhokensido_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kkhokensido_staffDto GetDtoByKey(string hokensidokbn, string gyomukbn, string atenano, int edano, string mosikomikekkakbn, string staffid)
        {
            return SELECT.WHERE.ByKey(hokensidokbn, gyomukbn, atenano, edano, mosikomikekkakbn, staffid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string hokensidokbn, string gyomukbn, string atenano, int edano, string mosikomikekkakbn, string staffid)
        {
            //物理削除
            DELETE.WHERE.ByKey(hokensidokbn, gyomukbn, atenano, edano, mosikomikekkakbn, staffid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kkhokensido_staffDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
