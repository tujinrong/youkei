// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUC帳票検索マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eurptkensakuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eurptkensaku";

        public tm_eurptkensakuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eurptkensakuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eurptkensakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eurptkensakuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eurptkensakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eurptkensakuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eurptkensakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eurptkensakuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eurptkensakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eurptkensakuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eurptkensakuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eurptkensakuDto GetDtoByKey(int jyokenseq)
        {
            return SELECT.WHERE.ByKey(jyokenseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int jyokenseq, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(jyokenseq).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eurptkensakuDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
