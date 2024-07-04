// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　出力順パターンテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_eusortDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_eusort";

        public tt_eusortDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_eusortDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_eusortDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_eusortDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_eusortDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_eusortDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_eusortDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_eusortDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_eusortDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_eusortDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_eusortDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_eusortDto GetDtoByKey(string rptid, string yosikiid, int sortptnno)
        {
            return SELECT.WHERE.ByKey(rptid, yosikiid, sortptnno).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string rptid, string yosikiid, int sortptnno, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(rptid, yosikiid, sortptnno).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_eusortDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
