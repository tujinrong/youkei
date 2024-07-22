// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　母子保健詳細メニューマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhkksyosaimenyuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_bhkksyosaimenyu";

        public tm_bhkksyosaimenyuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_bhkksyosaimenyuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_bhkksyosaimenyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_bhkksyosaimenyuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_bhkksyosaimenyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_bhkksyosaimenyuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_bhkksyosaimenyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_bhkksyosaimenyuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_bhkksyosaimenyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_bhkksyosaimenyuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_bhkksyosaimenyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_bhkksyosaimenyuDto GetDtoByKey(string bosikbn, string bhsyosaimenyucd)
        {
            return SELECT.WHERE.ByKey(bosikbn, bhsyosaimenyucd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string bosikbn, string bhsyosaimenyucd)
        {
            //物理削除
            DELETE.WHERE.ByKey(bosikbn, bhsyosaimenyucd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_bhkksyosaimenyuDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
