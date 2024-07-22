// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　健（検）診予約希望者詳細テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shkensinkibosyasyosaiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_shkensinkibosyasyosai";

        public tt_shkensinkibosyasyosaiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_shkensinkibosyasyosaiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_shkensinkibosyasyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_shkensinkibosyasyosaiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_shkensinkibosyasyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_shkensinkibosyasyosaiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_shkensinkibosyasyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_shkensinkibosyasyosaiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_shkensinkibosyasyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_shkensinkibosyasyosaiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_shkensinkibosyasyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_shkensinkibosyasyosaiDto GetDtoByKey(int nendo, int nitteino, string atenano, string jigyocd)
        {
            return SELECT.WHERE.ByKey(nendo, nitteino, atenano, jigyocd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int nendo, int nitteino, string atenano, string jigyocd)
        {
            //物理削除
            DELETE.WHERE.ByKey(nendo, nitteino, atenano, jigyocd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_shkensinkibosyasyosaiDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
