// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　母子保健項目テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhitemDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_bhitem";

        public tt_bhitemDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_bhitemDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_bhitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_bhitemDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_bhitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_bhitemDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_bhitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_bhitemDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_bhitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_bhitemDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_bhitemDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_bhitemDto GetDtoByKey(string bhsyurui, string bhsyosaimenyucd, string bhsyosaitabcd, string bhdatalistcd, string atenano, int kensinkaisu, string itemcd)
        {
            return SELECT.WHERE.ByKey(bhsyurui, bhsyosaimenyucd, bhsyosaitabcd, bhdatalistcd, atenano, kensinkaisu, itemcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string bhsyurui, string bhsyosaimenyucd, string bhsyosaitabcd, string bhdatalistcd, string atenano, int kensinkaisu, string itemcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(bhsyurui, bhsyosaimenyucd, bhsyosaitabcd, bhdatalistcd, atenano, kensinkaisu, itemcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_bhitemDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
