// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　集団指導結果情報（固定項目）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kksyudansido_kekkaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kksyudansido_kekka";

        public tt_kksyudansido_kekkaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kksyudansido_kekkaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kksyudansido_kekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kksyudansido_kekkaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kksyudansido_kekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kksyudansido_kekkaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kksyudansido_kekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kksyudansido_kekkaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kksyudansido_kekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kksyudansido_kekkaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kksyudansido_kekkaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kksyudansido_kekkaDto GetDtoByKey(string gyomukbn, int edano)
        {
            return SELECT.WHERE.ByKey(gyomukbn, edano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string gyomukbn, int edano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(gyomukbn, edano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kksyudansido_kekkaDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
