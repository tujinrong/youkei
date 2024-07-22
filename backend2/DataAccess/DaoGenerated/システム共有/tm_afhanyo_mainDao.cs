// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　汎用メインマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afhanyo_mainDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afhanyo_main";

        public tm_afhanyo_mainDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afhanyo_mainDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afhanyo_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afhanyo_mainDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afhanyo_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afhanyo_mainDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afhanyo_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afhanyo_mainDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afhanyo_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afhanyo_mainDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afhanyo_mainDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afhanyo_mainDto GetDtoByKey(string hanyomaincd, int hanyosubcd)
        {
            return SELECT.WHERE.ByKey(hanyomaincd, hanyosubcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string hanyomaincd, int hanyosubcd)
        {
            //物理削除
            DELETE.WHERE.ByKey(hanyomaincd, hanyosubcd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afhanyo_mainDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
