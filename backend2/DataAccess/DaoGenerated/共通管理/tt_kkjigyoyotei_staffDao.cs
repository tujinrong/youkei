// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　事業予定担当者テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkjigyoyotei_staffDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kkjigyoyotei_staff";

        public tt_kkjigyoyotei_staffDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kkjigyoyotei_staffDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kkjigyoyotei_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kkjigyoyotei_staffDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kkjigyoyotei_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kkjigyoyotei_staffDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kkjigyoyotei_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kkjigyoyotei_staffDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kkjigyoyotei_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kkjigyoyotei_staffDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kkjigyoyotei_staffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kkjigyoyotei_staffDto GetDtoByKey(int nitteino, string staffid)
        {
            return SELECT.WHERE.ByKey(nitteino, staffid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int nitteino, string staffid)
        {
            //物理削除
            DELETE.WHERE.ByKey(nitteino, staffid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kkjigyoyotei_staffDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
