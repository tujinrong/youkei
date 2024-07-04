// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　使用履歴テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afsiyorirekiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afsiyorireki";

        public tt_afsiyorirekiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afsiyorirekiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afsiyorirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afsiyorirekiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afsiyorirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afsiyorirekiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afsiyorirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afsiyorirekiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afsiyorirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afsiyorirekiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afsiyorirekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afsiyorirekiDto GetDtoByKey(string userid, string kinoid)
        {
            return SELECT.WHERE.ByKey(userid, kinoid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string userid, string kinoid)
        {
            //物理削除
            DELETE.WHERE.ByKey(userid, kinoid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afsiyorirekiDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
