// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　母子保健管理パターンマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhkanripatternDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_bhkanripattern";

        public tm_bhkanripatternDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_bhkanripatternDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_bhkanripatternDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_bhkanripatternDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_bhkanripatternDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_bhkanripatternDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_bhkanripatternDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_bhkanripatternDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_bhkanripatternDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_bhkanripatternDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_bhkanripatternDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_bhkanripatternDto GetDtoByKey(string bhsyurui, string bhkanripatterncd)
        {
            return SELECT.WHERE.ByKey(bhsyurui, bhkanripatterncd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string bhsyurui, string bhkanripatterncd)
        {
            //物理削除
            DELETE.WHERE.ByKey(bhsyurui, bhkanripatterncd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_bhkanripatternDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
