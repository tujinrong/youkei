// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　ヘルプドキュメントマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afhelpdocDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afhelpdoc";

        public tm_afhelpdocDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afhelpdocDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afhelpdocDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afhelpdocDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afhelpdocDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afhelpdocDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afhelpdocDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afhelpdocDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afhelpdocDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afhelpdocDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afhelpdocDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afhelpdocDto GetDtoByKey(long docseq)
        {
            return SELECT.WHERE.ByKey(docseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(long docseq)
        {
            //物理削除
            DELETE.WHERE.ByKey(docseq).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afhelpdocDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
