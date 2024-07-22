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
    public class tm_bhsyosaimenyuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_bhsyosaimenyu";

        public tm_bhsyosaimenyuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_bhsyosaimenyuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_bhsyosaimenyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_bhsyosaimenyuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_bhsyosaimenyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_bhsyosaimenyuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_bhsyosaimenyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_bhsyosaimenyuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_bhsyosaimenyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_bhsyosaimenyuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_bhsyosaimenyuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_bhsyosaimenyuDto GetDtoByKey(string bhsyurui, string bhsyosaimenyucd)
        {
            return SELECT.WHERE.ByKey(bhsyurui, bhsyosaimenyucd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string bhsyurui, string bhsyosaimenyucd)
        {
            //物理削除
            DELETE.WHERE.ByKey(bhsyurui, bhsyosaimenyucd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_bhsyosaimenyuDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
