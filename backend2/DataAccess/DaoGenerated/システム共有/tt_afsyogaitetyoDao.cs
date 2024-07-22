// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　【障害者福祉】身体障害者手帳等情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afsyogaitetyoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afsyogaitetyo";

        public tt_afsyogaitetyoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afsyogaitetyoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afsyogaitetyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afsyogaitetyoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afsyogaitetyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afsyogaitetyoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afsyogaitetyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afsyogaitetyoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afsyogaitetyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afsyogaitetyoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afsyogaitetyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afsyogaitetyoDto GetDtoByKey(string atenano)
        {
            return SELECT.WHERE.ByKey(atenano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afsyogaitetyoDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
