// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　母子保健詳細メニューマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhkksyosaimenuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_bhkksyosaimenu";

        public tm_bhkksyosaimenuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_bhkksyosaimenuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_bhkksyosaimenuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_bhkksyosaimenuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_bhkksyosaimenuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_bhkksyosaimenuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_bhkksyosaimenuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_bhkksyosaimenuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_bhkksyosaimenuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_bhkksyosaimenuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_bhkksyosaimenuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_bhkksyosaimenuDto GetDtoByKey(string bosikbn, string bhsyosaimenyucd)
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
        public void UpdateDto(tm_bhkksyosaimenuDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
