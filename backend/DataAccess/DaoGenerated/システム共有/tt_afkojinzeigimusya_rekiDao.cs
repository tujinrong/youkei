// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　【個人住民税】納税義務者情報履歴テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkojinzeigimusya_rekiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afkojinzeigimusya_reki";

        public tt_afkojinzeigimusya_rekiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afkojinzeigimusya_rekiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afkojinzeigimusya_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afkojinzeigimusya_rekiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afkojinzeigimusya_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afkojinzeigimusya_rekiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afkojinzeigimusya_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afkojinzeigimusya_rekiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afkojinzeigimusya_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afkojinzeigimusya_rekiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afkojinzeigimusya_rekiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afkojinzeigimusya_rekiDto GetDtoByKey(string atenano, int kazeinendo, int kojinrirekino)
        {
            return SELECT.WHERE.ByKey(atenano, kazeinendo, kojinrirekino).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int kazeinendo, int kojinrirekino, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, kazeinendo, kojinrirekino).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afkojinzeigimusya_rekiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
