// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　住登外者独自施策システム等情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afjutogai_dokujisystemDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afjutogai_dokujisystem";

        public tt_afjutogai_dokujisystemDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afjutogai_dokujisystemDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afjutogai_dokujisystemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afjutogai_dokujisystemDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afjutogai_dokujisystemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afjutogai_dokujisystemDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afjutogai_dokujisystemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afjutogai_dokujisystemDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afjutogai_dokujisystemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afjutogai_dokujisystemDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afjutogai_dokujisystemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afjutogai_dokujisystemDto GetDtoByKey(string atenano, int rirekino, string dokujisystemid)
        {
            return SELECT.WHERE.ByKey(atenano, rirekino, dokujisystemid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int rirekino, string dokujisystemid)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, rirekino, dokujisystemid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afjutogai_dokujisystemDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
