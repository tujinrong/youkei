// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　EUC帳票検索詳細マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eurptkensakusyosaiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_eurptkensakusyosai";

        public tm_eurptkensakusyosaiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_eurptkensakusyosaiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_eurptkensakusyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_eurptkensakusyosaiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_eurptkensakusyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_eurptkensakusyosaiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_eurptkensakusyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_eurptkensakusyosaiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_eurptkensakusyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_eurptkensakusyosaiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_eurptkensakusyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_eurptkensakusyosaiDto GetDtoByKey(int jyokenseq, string rptid, string yosikiid, int yosikieda)
        {
            return SELECT.WHERE.ByKey(jyokenseq, rptid, yosikiid, yosikieda).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int jyokenseq, string rptid, string yosikiid, int yosikieda)
        {
            //物理削除
            DELETE.WHERE.ByKey(jyokenseq, rptid, yosikiid, yosikieda).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_eurptkensakusyosaiDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
