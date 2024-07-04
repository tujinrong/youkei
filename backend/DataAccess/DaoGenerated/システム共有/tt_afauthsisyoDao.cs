// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　部署（支所）別更新権限テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afauthsisyoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afauthsisyo";

        public tt_afauthsisyoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afauthsisyoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afauthsisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afauthsisyoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afauthsisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afauthsisyoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afauthsisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afauthsisyoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afauthsisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afauthsisyoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afauthsisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afauthsisyoDto GetDtoByKey(string rolekbn, string roleid, string sisyocd)
        {
            return SELECT.WHERE.ByKey(rolekbn, roleid, sisyocd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string rolekbn, string roleid, string sisyocd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(rolekbn, roleid, sisyocd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afauthsisyoDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
