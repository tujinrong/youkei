// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUCデータソース結合マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eudatasourcejoinDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eudatasourcejoin";

        public tm_eudatasourcejoinDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eudatasourcejoinDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eudatasourcejoinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eudatasourcejoinDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eudatasourcejoinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eudatasourcejoinDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eudatasourcejoinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eudatasourcejoinDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eudatasourcejoinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eudatasourcejoinDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eudatasourcejoinDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eudatasourcejoinDto GetDtoByKey(string datasourceid, string tablealias)
        {
            return SELECT.WHERE.ByKey(datasourceid, tablealias).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string datasourceid, string tablealias)
        {
            //物理削除
            DELETE.WHERE.ByKey(datasourceid, tablealias).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eudatasourcejoinDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
