// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　集団指導参加者結果情報（固定項目）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kksyudansido_sankasyakekkaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kksyudansido_sankasyakekka";

        public tt_kksyudansido_sankasyakekkaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kksyudansido_sankasyakekkaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kksyudansido_sankasyakekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kksyudansido_sankasyakekkaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kksyudansido_sankasyakekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kksyudansido_sankasyakekkaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kksyudansido_sankasyakekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kksyudansido_sankasyakekkaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kksyudansido_sankasyakekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kksyudansido_sankasyakekkaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kksyudansido_sankasyakekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kksyudansido_sankasyakekkaDto GetDtoByKey(string gyomukbn, int edano, string atenano)
        {
            return SELECT.WHERE.ByKey(gyomukbn, edano, atenano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string gyomukbn, int edano, string atenano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(gyomukbn, edano, atenano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kksyudansido_sankasyakekkaDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
