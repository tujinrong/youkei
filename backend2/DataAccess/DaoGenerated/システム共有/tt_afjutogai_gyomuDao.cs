// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　住登外者参照業務情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afjutogai_gyomuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afjutogai_gyomu";

        public tt_afjutogai_gyomuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afjutogai_gyomuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afjutogai_gyomuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afjutogai_gyomuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afjutogai_gyomuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afjutogai_gyomuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afjutogai_gyomuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afjutogai_gyomuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afjutogai_gyomuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afjutogai_gyomuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afjutogai_gyomuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afjutogai_gyomuDto GetDtoByKey(string atenano, int rirekino, string gyomuid)
        {
            return SELECT.WHERE.ByKey(atenano, rirekino, gyomuid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int rirekino, string gyomuid)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, rirekino, gyomuid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afjutogai_gyomuDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
