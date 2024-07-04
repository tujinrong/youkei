// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　汎用マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afhanyoDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afhanyo";

        public tm_afhanyoDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afhanyoDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afhanyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afhanyoDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afhanyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afhanyoDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afhanyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afhanyoDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afhanyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afhanyoDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afhanyoDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afhanyoDto GetDtoByKey(string hanyomaincd, int hanyosubcd, string hanyocd)
        {
            return SELECT.WHERE.ByKey(hanyomaincd, hanyosubcd, hanyocd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string hanyomaincd, int hanyosubcd, string hanyocd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(hanyomaincd, hanyosubcd, hanyocd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afhanyoDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
