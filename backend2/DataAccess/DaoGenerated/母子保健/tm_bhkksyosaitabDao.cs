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
    public class tm_bhkksyosaitabDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_bhkksyosaitab";

        public tm_bhkksyosaitabDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_bhkksyosaitabDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_bhkksyosaitabDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_bhkksyosaitabDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_bhkksyosaitabDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_bhkksyosaitabDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_bhkksyosaitabDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_bhkksyosaitabDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_bhkksyosaitabDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_bhkksyosaitabDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_bhkksyosaitabDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_bhkksyosaitabDto GetDtoByKey(string bosikbn, string bhsyosaimenyucd, string bhsyosaitabcd)
        {
            return SELECT.WHERE.ByKey(bosikbn, bhsyosaimenyucd, bhsyosaitabcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string bosikbn, string bhsyosaimenyucd, string bhsyosaitabcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(bosikbn, bhsyosaimenyucd, bhsyosaitabcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_bhkksyosaitabDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
