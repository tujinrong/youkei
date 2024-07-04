// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　お知らせ確認状態テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afinfo_userDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afinfo_user";

        public tt_afinfo_userDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afinfo_userDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afinfo_userDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afinfo_userDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afinfo_userDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afinfo_userDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afinfo_userDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afinfo_userDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afinfo_userDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afinfo_userDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afinfo_userDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afinfo_userDto GetDtoByKey(long infoseq, string userid)
        {
            return SELECT.WHERE.ByKey(infoseq, userid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long infoseq, string userid)
        {
            //物理削除
            DELETE.WHERE.ByKey(infoseq, userid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afinfo_userDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
