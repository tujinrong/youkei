// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　【障害者福祉】身体障害者手帳等情報履歴テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afsyogaitetyo_rekiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afsyogaitetyo_reki";

        public tt_afsyogaitetyo_rekiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afsyogaitetyo_rekiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afsyogaitetyo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afsyogaitetyo_rekiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afsyogaitetyo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afsyogaitetyo_rekiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afsyogaitetyo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afsyogaitetyo_rekiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afsyogaitetyo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afsyogaitetyo_rekiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afsyogaitetyo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afsyogaitetyo_rekiDto GetDtoByKey(string atenano, int rirekino)
        {
            return SELECT.WHERE.ByKey(atenano, rirekino).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int rirekino, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, rirekino).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afsyogaitetyo_rekiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
