// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　事業予約希望者テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkjigyoyoyakukibosyaDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_kkjigyoyoyakukibosya";

        public tt_kkjigyoyoyakukibosyaDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_kkjigyoyoyakukibosyaDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_kkjigyoyoyakukibosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_kkjigyoyoyakukibosyaDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_kkjigyoyoyakukibosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_kkjigyoyoyakukibosyaDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_kkjigyoyoyakukibosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_kkjigyoyoyakukibosyaDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_kkjigyoyoyakukibosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_kkjigyoyoyakukibosyaDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_kkjigyoyoyakukibosyaDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_kkjigyoyoyakukibosyaDto GetDtoByKey(int nitteino, string atenano)
        {
            return SELECT.WHERE.ByKey(nitteino, atenano).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int nitteino, string atenano, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(nitteino, atenano).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_kkjigyoyoyakukibosyaDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
