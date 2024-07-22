// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　事業従事者（担当者）情報マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afstaffDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afstaff";

        public tm_afstaffDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afstaffDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afstaffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afstaffDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afstaffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afstaffDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afstaffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afstaffDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afstaffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afstaffDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afstaffDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afstaffDto GetDtoByKey(string staffid)
        {
            return SELECT.WHERE.ByKey(staffid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string staffid, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(staffid).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afstaffDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
