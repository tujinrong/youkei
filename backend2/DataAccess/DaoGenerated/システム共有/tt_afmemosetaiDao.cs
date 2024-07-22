// *******************************************************************
// 業務名称  : 互助防疫システム
// 機能概要　: テーブルDAO定義
// 　　　　　　メモ情報（世帯）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afmemosetaiDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tt_afmemosetai";

        public tt_afmemosetaiDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tt_afmemosetaiDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tt_afmemosetaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tt_afmemosetaiDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tt_afmemosetaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tt_afmemosetaiDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tt_afmemosetaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tt_afmemosetaiDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tt_afmemosetaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tt_afmemosetaiDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tt_afmemosetaiDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tt_afmemosetaiDto GetDtoByKey(string setaino, int memoseq)
        {
            return SELECT.WHERE.ByKey(setaino, memoseq).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string setaino, int memoseq, DateTime timeStamp)
        {
            //物理削除
            DELETE.WHERE.ByKey(setaino, memoseq).SetLock(timeStamp).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tt_afmemosetaiDto dto, DateTime timestamp)
        {
            //排他更新
            UPDATE.SetLock(timestamp).Execute(dto);
        }
    }
}
