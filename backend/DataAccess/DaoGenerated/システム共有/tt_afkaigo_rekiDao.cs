// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　【介護保険】被保険者情報履歴テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkaigo_rekiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afkaigo_reki";

        public tt_afkaigo_rekiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afkaigo_rekiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afkaigo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afkaigo_rekiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afkaigo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afkaigo_rekiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afkaigo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afkaigo_rekiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afkaigo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afkaigo_rekiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afkaigo_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afkaigo_rekiDto GetDtoByKey(string atenano, string kaigohokensyano, string hihokensyano, int sikakurirekino)
        {
            return SELECT.WHERE.ByKey(atenano, kaigohokensyano, hihokensyano, sikakurirekino).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, string kaigohokensyano, string hihokensyano, int sikakurirekino, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, kaigohokensyano, hihokensyano, sikakurirekino).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afkaigo_rekiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
