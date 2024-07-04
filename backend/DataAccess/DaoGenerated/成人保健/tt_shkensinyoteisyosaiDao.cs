// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　健（検）診予定詳細テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shkensinyoteisyosaiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_shkensinyoteisyosai";

        public tt_shkensinyoteisyosaiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_shkensinyoteisyosaiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_shkensinyoteisyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_shkensinyoteisyosaiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_shkensinyoteisyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_shkensinyoteisyosaiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_shkensinyoteisyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_shkensinyoteisyosaiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_shkensinyoteisyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_shkensinyoteisyosaiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_shkensinyoteisyosaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_shkensinyoteisyosaiDto GetDtoByKey(int nendo, int nitteino, string jigyocd, string yoyakubunruicd)
        {
            return SELECT.WHERE.ByKey(nendo, nitteino, jigyocd, yoyakubunruicd).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(int nendo, int nitteino, string jigyocd, string yoyakubunruicd)
        {
            //物理削除
            DELETE.WHERE.ByKey(nendo, nitteino, jigyocd, yoyakubunruicd).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_shkensinyoteisyosaiDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
