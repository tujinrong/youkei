// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　発券情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkhakkenDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kkhakken";

        public tt_kkhakkenDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kkhakkenDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kkhakkenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kkhakkenDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kkhakkenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kkhakkenDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kkhakkenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kkhakkenDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kkhakkenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kkhakkenDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kkhakkenDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kkhakkenDto GetDtoByKey(int nendo, string tyusyututaisyocd, string hakkendatasyosaikbn, string atenano)
        {
            return SELECT.WHERE.ByKey(nendo, tyusyututaisyocd, hakkendatasyosaikbn, atenano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int nendo, string tyusyututaisyocd, string hakkendatasyosaikbn, string atenano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(nendo, tyusyututaisyocd, hakkendatasyosaikbn, atenano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kkhakkenDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
