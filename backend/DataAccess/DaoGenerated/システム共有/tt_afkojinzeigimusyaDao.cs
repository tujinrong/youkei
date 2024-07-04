// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　【個人住民税】納税義務者情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkojinzeigimusyaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afkojinzeigimusya";

        public tt_afkojinzeigimusyaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afkojinzeigimusyaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afkojinzeigimusyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afkojinzeigimusyaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afkojinzeigimusyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afkojinzeigimusyaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afkojinzeigimusyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afkojinzeigimusyaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afkojinzeigimusyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afkojinzeigimusyaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afkojinzeigimusyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afkojinzeigimusyaDto GetDtoByKey(string atenano, int kazeinendo)
        {
            return SELECT.WHERE.ByKey(atenano, kazeinendo).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string atenano, int kazeinendo, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(atenano, kazeinendo).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afkojinzeigimusyaDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
