// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　機能マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afkinoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afkino";

        public tm_afkinoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afkinoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afkinoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afkinoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afkinoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afkinoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afkinoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afkinoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afkinoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afkinoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afkinoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afkinoDto GetDtoByKey(string kinoid)
        {
            return SELECT.WHERE.ByKey(kinoid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string kinoid)
        {
            //物理削除
            DELETE.WHERE.ByKey(kinoid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afkinoDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
