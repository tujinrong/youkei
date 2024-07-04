// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　健（検）診予約希望者テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shkensinyoyakukibosyaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_shkensinyoyakukibosya";

        public tt_shkensinyoyakukibosyaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_shkensinyoyakukibosyaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_shkensinyoyakukibosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_shkensinyoyakukibosyaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_shkensinyoyakukibosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_shkensinyoyakukibosyaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_shkensinyoyakukibosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_shkensinyoyakukibosyaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_shkensinyoyakukibosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_shkensinyoyakukibosyaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_shkensinyoyakukibosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_shkensinyoyakukibosyaDto GetDtoByKey(int nendo, int nitteino, string atenano)
        {
            return SELECT.WHERE.ByKey(nendo, nitteino, atenano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int nendo, int nitteino, string atenano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(nendo, nitteino, atenano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_shkensinyoyakukibosyaDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
