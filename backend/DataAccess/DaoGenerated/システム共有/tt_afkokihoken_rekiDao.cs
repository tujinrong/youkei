// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　【後期高齢者医療】被保険者情報履歴テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkokihoken_rekiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afkokihoken_reki";

        public tt_afkokihoken_rekiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afkokihoken_rekiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afkokihoken_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afkokihoken_rekiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afkokihoken_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afkokihoken_rekiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afkokihoken_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afkokihoken_rekiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afkokihoken_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afkokihoken_rekiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afkokihoken_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afkokihoken_rekiDto GetDtoByKey(string hihokensyano, int rirekino)
        {
            return SELECT.WHERE.ByKey(hihokensyano, rirekino).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string hihokensyano, int rirekino, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(hihokensyano, rirekino).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afkokihoken_rekiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
