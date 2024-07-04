// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 予防接種情報管理
//             ビューモデル定義
// 作成日　　: 2024.06.18
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWYS00101G
{
    /// <summary>
    /// 検索処理(一覧画面ベース)
    /// </summary>
    public class BaseInfoVM
    {
        //================================= 表示用VM =====================================
        public string atenano { get; set; }         //宛名番号
        public string name { get; set; }            //氏名
        public string kname { get; set; }           //カナ氏名
        public string sexhyoki { get; set; }        //性別
        public string bymd { get; set; }            //生年月日
        public string juminkbn { get; set; }        //住民区分
        public string keikoku { get; set; }         //警告内容
    }

    /// <summary>
    /// 検索処理(予防接種情報一覧画面)
    /// </summary>
    public class JyuminListVM : BaseInfoVM
    {
        public string adrs { get; set; }            //住所(住所1、住所2)
        public string gyoseiku { get; set; }        //行政区
    }

    /// <summary>
    /// 検索処理(詳細画面ヘッダー情報)
    /// </summary>
    public class HeaderInfoVM : CommonBarHeaderBase2VM
    {
        public string atenano { get; set; }         //宛名番号
        public string adrs { get; set; }            //住所(住所1、住所2)
        public string gyoseiku { get; set; }        //行政区
        public string sessyukenno { get; set; }     //接種券番号
    }

    /// <summary>
    /// 接種情報（生涯1回）
    /// </summary>
    public class SessyuOneVm : SessyuAllVm{ }


    /// <summary>
    /// 接種情報（複数回）
    /// </summary>
    public class SessyuAllVm
    {
        //表示項目
        public string datasts { get; set; }                     //状態
        public string sessyu { get; set; }                      //接種種類（コード : 名称)
        public int edano { get; set; }                          //枝番
        public string jissiymd { get; set; }                    //実施日
        public string sessyukbn { get; set; }                   //接種区分（コード : 名称)
        public string lotno { get; set; }                       //ロット番号
        public string vaccinenm { get; set; }                   //ワクチン名（コード : 名称)
        public string vaccinemaker { get; set; }                //ワクチンメーカー（コード : 名称)
        public double sessyuryo { get; set; }                   //接種量
        public string jissikbn { get; set; }                    //実施区分（コード : 名称)
        public string hoteikbn { get; set; }                    //法定区分（コード : 名称)
        public string tokubetunojijyo { get; set; }             //特別の事情（コード : 名称)

        //非表示項目
        public string kaisu { get; set; }                       //回数
        public string sessyucd { get; set; }                    //接種種類（コード)
        public string sessyukbncd { get; set; }                 //接種区分（コード)
        public string vaccinemakercd { get; set; }              //ワクチンメーカーコード
        public string vaccinenmcd { get; set; }                 //ワクチン名コード
        public string jissikbncd { get; set; }                  //実施区分（コード)
        public string hoteikbncd { get; set; }                  //法定区分（コード)
        public string tokubetunojijyocd { get; set; }           //特別の事情（コード)

        public string sessyufilter { get; set; }                //接種種類フィルター区分
        public string sortseq { get; set; }                     //汎用区分1:3～5桁目（表示順）
    }

    /// <summary>
    /// 罹患情報
    /// </summary>
    public class SessyuRikanBaseVm
    {
        //表示項目
        public string rikan { get; set; }                       //罹患コード（コード : 名称)
        public string haakuymd { get; set; }                    //把握日
    }

    /// <summary>
    /// 罹患情報
    /// </summary>
    public class SessyuRikanVm : SessyuRikanBaseVm
    {
        public bool editflg { get; set; }                       //編集フラグ
        public string rikancd { get; set; }                     //罹患コード
        public string rikanjotai { get; set; }                  //罹患状態（把握日が入力された場合、○を表示する）
    }

    /// <summary>
    /// 接種依頼情報
    /// </summary>
    public class SessyuIraiVm
    {
        //表示項目
        public string datasts { get; set; }                     //状態
        public string uketukeymd { get; set; }                  //受付日
        public string iraisaki { get; set; }                    //依頼先
        public string irairiyu { get; set; }                    //依頼理由
        public string hogosya_atenano { get; set; }             //保護者_宛名番号
        public string hogosya_simei { get; set; }               //保護者_氏名
        //非表示項目
        public int edano { get; set; }                          //枝番
    }

    /// <summary>
    /// その他情報タブ_フリー項目情報（表示用）
    /// </summary>
    public class FreeItemDispInfoVM : FreeItemBaseVM
    {
        public string? groupid { get; set; }                    //グループID
        public int orderseq { get; set; }                       //並びシーケンス
    }

    /// <summary>
    /// その他情報タブ_フリー項目情報（表示用）
    /// </summary>
    public class FixItemDispInfoVM : FreeItemDispInfoVM{ }

    /// <summary>
    /// 接種情報詳細画面_固定項目情報（表示用）
    /// </summary>
    public class FixItemSessyuBaseVM : SessyuAllVm
    {
        public string? sessyukenno { get; set; }                        //接種券番号
        public string? jissikikancd { get; set; }                       //実施機関コード
        public string? jissikikan { get; set; }                         //実施機関
        public string? jissikikannm { get; set; }                       //実施機関名
        public string? kaijocd { get; set; }                            //会場コード
        public string? kaijo { get; set; }                              //会場
        public string? kaijonm { get; set; }                            //会場名
        public string? isicd { get; set; }                              //医師コード
        public string? isi { get; set; }                                //医師
        public string? isinm { get; set; }                              //医師名
    }

    /// <summary>
    /// 接種情報詳細画面_固定項目情報（表示用）
    /// </summary>
    public class FixItemSessyuVM : FixItemSessyuBaseVM
    {
        public List<DaSelectorModel> sessyulist { get; set; }           //接種種類リスト
        public List<DaSelectorModel> sessyukbnlist { get; set; }        //接種区分リスト
        public List<DaSelectorModel> vaccinenmlist { get; set; }        //ワクチン名リスト
        public List<DaSelectorModel> vaccinemakerlist { get; set; }     //ワクチンメーカーリスト
        public List<DaSelectorModel> jissikbnlist { get; set; }         //実施区分リスト
        public List<DaSelectorModel> hoteikbnlist { get; set; }         //法定区分リスト
        public List<DaSelectorModel> jissikikanlist { get; set; }       //実施機関リスト
        public List<DaSelectorModel> kaijolist { get; set; }            //会場リスト
        public List<DaSelectorModel> isilist { get; set; }              //医師リスト
        public List<DaSelectorModel> tokubetunojijyolist { get; set; }  //特別の事情リスト
    }

    /// <summary>
    /// 接種依頼情報詳細画面_固定項目情報（表示用）
    /// </summary>
    public class FixItemSessyuIraiBaseVM : SessyuIraiVm
    {
        public List<SessyuVM> sessyusublist { get; set; }               //接種種類（予防接種依頼サブテーブル取得）
    }

    /// <summary>
    /// 接種依頼情報詳細画面_固定項目情報（表示用）
    /// </summary>
    public class FixItemSessyuIraiVM : FixItemSessyuIraiBaseVM
    {
        public List<DaSelectorModel> sessyulist { get; set; }           //接種種類リスト
    }

    /// <summary>
    /// 予防接種依頼サブテーブルの接種種類
    /// </summary>
    public class SessyuVM
    {
        public string sessyu { get; set; }                              //接種種類（コード : 名称）
        public string sessyucd { get; set; }                            //接種種類コード
        public string kaisu { get; set; }                               //回数
    }

    /// <summary>
    /// 風疹抗体検査情報詳細画面_固定項目情報（表示用）
    /// </summary>
    public class FixItemFusinBaseVM
    {
        public string sessyukenno { get; set; }                         //接種券番号
        public string? kotaikensahohocd { get; set; }                   //抗体検査方法（コード）
        public string? kotaikensahoho { get; set; }                     //抗体検査方法（コード : 名称）
        public string? kotaika { get; set; }                            //抗体価
        public string? tanicd { get; set; }                             //単位（抗体価）（コード）
        public string? tani { get; set; }                               //単位（抗体価）（コード : 名称）
        public string sessyuhanteicd { get; set; }                      //接種判定（コード）
        public string sessyuhantei { get; set; }                        //接種判定（コード : 名称）
        public string jissiymd { get; set; }                            //実施日
        public string? jissikikancd { get; set; }                       //実施機関（コード）
        public string? jissikikan { get; set; }                         //実施機関（コード : 名称）
        public string? jissikikannm { get; set; }                       //実施機関名
        public string? isicd { get; set; }                              //医師（コード）
        public string? isi { get; set; }                                //医師（コード : 名称）
        public string? isinm { get; set; }                              //医師名
        public string? kotaikensanocd { get; set; }                     //抗体検査番号（コード）
        public string? kotaikensano { get; set; }                       //抗体検査番号（コード : 名称）
    }

    /// <summary>
    /// 風疹抗体検査情報詳細画面_固定項目情報（表示用）
    /// </summary>
    public class FixItemFusinVM : FixItemFusinBaseVM
    {
        public List<DaSelectorModel> kotaikensahoholist { get; set; }   //抗体検査方法リスト
        public List<DaSelectorModel> tanilist { get; set; }             //単位リスト（抗体価）
        public List<DaSelectorModel> sessyuhanteilist { get; set; }     //接種判定リスト
        public List<DaSelectorModel> jissikikanlist { get; set; }       //実施機関リスト
        public List<DaSelectorModel> isilist { get; set; }              //医師リスト
        public List<DaSelectorModel> kotaikensanolist { get; set; }     //抗体検査番号リスト
    }

    //================================= 保存用VM =====================================
    /// <summary>
    /// 個人詳細画面_フリー項目情報（保存用）
    /// </summary>
    public class FreeItemInfoVM
    {
        public int inputtype { get; set; }                  //入力タイプ
        public string item { get; set; }                    //項目（名称）
        public object? value { get; set; }                  //値
    }

    /// <summary>
    /// 個人詳細画面_申込情報（保存用）
    /// </summary>
    public class SessyuInfoVM
    {
        public string yoteiymd { get; set; }                //実施予定日
        public string yoteitm { get; set; }                 //予定開始時間
        public List<FreeItemInfoVM> freeiteminfo { get; set; } //フリー項目情報
    }

    /// <summary>
    /// 防接種入力チェックメッセージ（保存前チェック用）
    /// </summary>
    public class MessageVM
    {
        public EnumServiceResult MessageKbn { get; set; }   //メッセージ区分（ServiceError：エラー、ServiceAlert：警告）
        public string Message { get; set; }                 //メッセージ内容
    }

    /// <summary>
    /// 予防接種入力チェック処理（保存前チェック用）
    /// </summary>
    public class YSInputCheckInfoVM : SessyuVM
    {
        public List<MessageVM> msglist { get; set; }        //メッセージリスト（接種種類単位）
    }

    
}