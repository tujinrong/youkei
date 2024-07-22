// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検診結果管理
//             リクエストインターフェース
// 作成日　　: 2023.07.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH001
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListRequest : DaRequestBase
    {
        public int nendo { get; set; }  //年度
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchRequest : Common.PersonSearchRequest
    {
        public int nendo { get; set; }      //年度
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailRequest : InitListRequest
    {
        public string atenano { get; set; }     //宛名番号
        public int? kensinkaisu { get; set; }   //検診回数
        public Enum遷移区分 kbn { get; set; }   //遷移区分
    }

    /// <summary>
    /// 保存処理(詳細画面)
    /// </summary>
    public class SaveRequest : CmSaveRequestBase
    {
        public int nendo { get; set; }              //年度
        public string atenano { get; set; }         //宛名番号
        public int kensinkaisu { get; set; }        //検診回数
        public bool? editflg1 { get; set; }         //編集区分(一次)
        public bool? editflg2 { get; set; }         //編集区分(精密)
        public KsTimeUpdateVM kekka { get; set; }   //該当回目の検診結果
        public bool dataflg1 { get; set; }          //データフラグ(一次：データ存在)
        public bool dataflg2 { get; set; }          //データフラグ(精密：データ存在)
    }

    /// <summary>
    /// 削除処理(詳細画面)
    /// </summary>
    public class DeleteRequest : InitListRequest
    {
        public string atenano { get; set; }             //宛名番号
        public int? kensinkaisu { get; set; }           //検診回数(1件削除)
        public List<KsLockVM> locklist { get; set; }    //キーリスト(排他用)
        public Enum削除区分 delkbn { get; set; }        //削除区分
    }

    /// <summary>
    /// 基準値取得処理
    /// </summary>
    public class GetKijunRequest : InitListRequest
    {
        public string atenano { get; set; }                     //宛名番号
        public DateTime? jissiymd1 { get; set; }                //実施日(一次)
        public DateTime? jissiymd2 { get; set; }                //実施日(精密)
        public string? kensahoho1 { get; set; }                 //検査方法(一次固定)(コード：名称)
        public List<KjFreeItemVM> freeitemlist { get; set; }    //フリー項目リスト
    }

    /// <summary>
    /// 実施年齢取得処理
    /// </summary>
    public class GetAgeRequest : DaRequestBase
    {
        public string atenano { get; set; }     //宛名番号
        public DateTime? jissiymd { get; set; } //実施日
    }

    /// <summary>
    /// 精密検診チェック処理
    /// </summary>
    public class SeiKenEditCheckRequest : DaRequestBase
    {
        public List<KsKekkaItemVM> kekkalist { get; set; }  //結果項目一覧(一次)
        public List<KsKekkaItemVM>? oldlist { get; set; }   //old結果項目一覧(一次)
        public bool dataflg1 { get; set; }                  //データフラグ(一次：データ存在)
        public bool dataflg2 { get; set; }                  //データフラグ(精密：データ存在)
    }

    /// <summary>
    /// 計算処理
    /// </summary>
    public class CalculateRequest : DaRequestBase
    {
        public List<KsKekkaItemVM> kekkalist { get; set; }  //結果項目一覧(全部)
    }

    /// <summary>
    /// 新規追加権限チェック処理(詳細画面)
    /// </summary>
    public class AuthCheckRequest : InitListRequest
    {
        public string atenano { get; set; }     //宛名番号
    }
}