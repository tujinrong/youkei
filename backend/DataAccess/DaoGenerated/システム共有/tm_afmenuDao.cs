// *******************************************************************
// 業務名称  : 健康管理システム
// 機能概要　: テーブルDAO定義
// 　　　　　　メニューマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴  :
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afmenuDao : DaDaoBase
    {
        /// <summary>
        /// テーブル名
        /// </summary>
        public const string TABLE_NAME = "tm_afmenu";

        public tm_afmenuDao(AiSessionContext session)
        {
            base.Session = session;
        }

        /// <summary>
        /// データ抽出
        /// </summary>
        public AiSelectHelper<tm_afmenuDto> SELECT
        {
            get
            {
                var helper = new AiSelectHelper<tm_afmenuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ削除
        /// </summary>
        public AiDeleteHelper<tm_afmenuDto> DELETE
        {
            get
            {
                var helper = new AiDeleteHelper<tm_afmenuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ登録
        /// </summary>
        public AiInsertHelper<tm_afmenuDto> INSERT
        {
            get
            {
                var helper = new AiInsertHelper<tm_afmenuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// データ更新
        /// </summary>
        public AiUpdateHelper<tm_afmenuDto> UPDATE
        {
            get
            {
                var helper = new AiUpdateHelper<tm_afmenuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// グルーピング
        /// </summary>
        public AiGroupHelper<tm_afmenuDto> GROUP
        {
            get
            {
                var helper = new AiGroupHelper<tm_afmenuDto>(Session, TABLE_NAME);
                return helper;
            }
        }

        /// <summary>
        /// 指定キーデータの抽出
        /// </summary>
        public tm_afmenuDto GetDtoByKey(string kinoid)
        {
            return SELECT.WHERE.ByKey(kinoid).GetDto();
        }

        /// <summary>
        /// キーを指定して削除
        /// </summary>
        public void DeleteByKey(string kinoid)
        {
            //物理削除
            DELETE.WHERE.ByKey(kinoid).Execute();
        }

        /// <summary>
        /// データの更新 
        /// </summary>
        public void UpdateDto(tm_afmenuDto dto)
        {
            UPDATE.Execute(dto);
        }
    }
}
