// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　ユーザー所属部署（支所）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afuser_sisyoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afuser_sisyo";

        public tt_afuser_sisyoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afuser_sisyoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afuser_sisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afuser_sisyoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afuser_sisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afuser_sisyoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afuser_sisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afuser_sisyoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afuser_sisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afuser_sisyoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afuser_sisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afuser_sisyoDto GetDtoByKey(string userid, string sisyocd)
        {
            return SELECT.WHERE.ByKey(userid, sisyocd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string userid, string sisyocd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(userid, sisyocd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afuser_sisyoDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
