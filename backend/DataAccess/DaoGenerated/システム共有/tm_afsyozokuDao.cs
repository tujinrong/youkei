// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　所属グループマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afsyozokuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afsyozoku";

        public tm_afsyozokuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afsyozokuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afsyozokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afsyozokuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afsyozokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afsyozokuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afsyozokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afsyozokuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afsyozokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afsyozokuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afsyozokuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afsyozokuDto GetDtoByKey(string syozokucd)
        {
            return SELECT.WHERE.ByKey(syozokucd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string syozokucd, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(syozokucd).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afsyozokuDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
