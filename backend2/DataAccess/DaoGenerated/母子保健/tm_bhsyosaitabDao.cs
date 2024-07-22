// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　母子保健詳細タブマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhsyosaitabDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_bhsyosaitab";

        public tm_bhsyosaitabDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_bhsyosaitabDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_bhsyosaitabDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_bhsyosaitabDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_bhsyosaitabDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_bhsyosaitabDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_bhsyosaitabDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_bhsyosaitabDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_bhsyosaitabDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_bhsyosaitabDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_bhsyosaitabDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_bhsyosaitabDto GetDtoByKey(string bhsyurui, string bhsyosaimenyucd, string bhsyosaitabcd)
        {
            return SELECT.WHERE.ByKey(bhsyurui, bhsyosaimenyucd, bhsyosaitabcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string bhsyurui, string bhsyosaimenyucd, string bhsyosaitabcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(bhsyurui, bhsyosaimenyucd, bhsyosaitabcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_bhsyosaitabDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
