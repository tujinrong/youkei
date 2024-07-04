// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　集団指導参加者テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kksyudansido_sankasyaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kksyudansido_sankasya";

        public tt_kksyudansido_sankasyaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kksyudansido_sankasyaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kksyudansido_sankasyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kksyudansido_sankasyaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kksyudansido_sankasyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kksyudansido_sankasyaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kksyudansido_sankasyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kksyudansido_sankasyaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kksyudansido_sankasyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kksyudansido_sankasyaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kksyudansido_sankasyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kksyudansido_sankasyaDto GetDtoByKey(string gyomukbn, int edano, string atenano)
        {
            return SELECT.WHERE.ByKey(gyomukbn, edano, atenano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string gyomukbn, int edano, string atenano)
        {
            //物理削除
            DELETE.WHERE.ByKey(gyomukbn, edano, atenano).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kksyudansido_sankasyaDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
