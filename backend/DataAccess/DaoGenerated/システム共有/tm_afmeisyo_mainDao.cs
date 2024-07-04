// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　名称メインマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afmeisyo_mainDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afmeisyo_main";

        public tm_afmeisyo_mainDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afmeisyo_mainDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afmeisyo_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afmeisyo_mainDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afmeisyo_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afmeisyo_mainDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afmeisyo_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afmeisyo_mainDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afmeisyo_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afmeisyo_mainDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afmeisyo_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afmeisyo_mainDto GetDtoByKey(string nmmaincd, int nmsubcd)
        {
            return SELECT.WHERE.ByKey(nmmaincd, nmsubcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string nmmaincd, int nmsubcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(nmmaincd, nmsubcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afmeisyo_mainDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
