// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　ワクチンマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_ysvaccineDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_ysvaccine";

        public tm_ysvaccineDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_ysvaccineDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_ysvaccineDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_ysvaccineDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_ysvaccineDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_ysvaccineDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_ysvaccineDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_ysvaccineDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_ysvaccineDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_ysvaccineDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_ysvaccineDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_ysvaccineDto GetDtoByKey(string sessyucd, string vaccinemakercd, string vaccinenmcd)
        {
            return SELECT.WHERE.ByKey(sessyucd, vaccinemakercd, vaccinenmcd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string sessyucd, string vaccinemakercd, string vaccinenmcd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(sessyucd, vaccinemakercd, vaccinenmcd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_ysvaccineDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
