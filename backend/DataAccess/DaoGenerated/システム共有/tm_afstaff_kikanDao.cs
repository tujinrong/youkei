// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　事業従事者（担当者）所属機関
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afstaff_kikanDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afstaff_kikan";

        public tm_afstaff_kikanDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afstaff_kikanDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afstaff_kikanDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afstaff_kikanDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afstaff_kikanDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afstaff_kikanDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afstaff_kikanDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afstaff_kikanDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afstaff_kikanDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afstaff_kikanDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afstaff_kikanDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afstaff_kikanDto GetDtoByKey(string staffid, string kikancd)
        {
            return SELECT.WHERE.ByKey(staffid, kikancd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string staffid, string kikancd)
        {
            //物理削除
            DELETE.WHERE.ByKey(staffid, kikancd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afstaff_kikanDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
