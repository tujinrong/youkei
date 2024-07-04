// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　名称マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afmeisyoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afmeisyo";

        public tm_afmeisyoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afmeisyoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afmeisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afmeisyoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afmeisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afmeisyoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afmeisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afmeisyoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afmeisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afmeisyoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afmeisyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afmeisyoDto GetDtoByKey(string nmmaincd, int nmsubcd, string nmcd)
        {
            return SELECT.WHERE.ByKey(nmmaincd, nmsubcd, nmcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string nmmaincd, int nmsubcd, string nmcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(nmmaincd, nmsubcd, nmcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afmeisyoDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
