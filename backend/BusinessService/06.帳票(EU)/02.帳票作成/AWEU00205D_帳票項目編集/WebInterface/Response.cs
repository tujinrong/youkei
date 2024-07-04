// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票項目編集
//             レスポンスインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00205D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; } //ドロップダウンリスト(集計区分)
        public List<DaSelectorModel> selectorlist2 { get; set; } //ドロップダウンリスト(出力項目区分)
        public List<DaSelectorModel> selectorlist3 { get; set; } //ドロップダウンリスト(並び替え)
        public List<DaSelectorModel> selectorlist4 { get; set; } //ドロップダウンリスト(コード区分)
        public List<DaSelectorModel> selectorlist5 { get; set; } //ドロップダウンリスト(小計区分)
    }

    /// <summary>
    /// マスタ初期化処理
    /// </summary>
    public class InitMasterResponse : DaResponseBase
    {
        public List<MasterVM> masterlist { get; set; } //マスタリスト
    }

    /// <summary>
    /// フォーマット初期化処理
    /// </summary>
    public class InitFormatResponse : DaResponseBase
    {
        public List<FormatVM> formatlist { get; set; } //フォーマットリスト
    }
}