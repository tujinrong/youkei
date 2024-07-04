// *******************************************************************
// 業務名称　: 乳幼児予防接種
// 機能概要　: 乳幼児予防接種
//             リクエストインターフェース
// 作成日　　: 2022.12.23
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.InfantVaccination
{
    /// <summary>
    /// 乳幼児予防接種情報を抽出するRequest
    /// </summary>
    public class KensakuRequest : DaRequestBase
    {
        public string systemcd { get; set; }               //処理コード
        public string nendo { get; set; }                  //年度
        public string kojinno { get; set; }                //整理番号
        public string kname { get; set; }                  //カナ氏名
        public string bymd { get; set; }                   //生年月日
        public string edano { get; set; }                  //健診回数(枝番号)
        public string pno { get; set; }                    //個人番号
    }
    
    /// <summary>
    /// 乳幼児予防接種情報を抽出する（詳細検索）Request
    /// </summary>
    public class KensakusRequest : DaRequestBase
    {
        public string systemcd { get; set; }               //処理コード
        public string kname { get; set; }                  //カナ氏名
        public string bymd { get; set; }                   //生年月日
        public string jHakkenNO { get; set; }              //発券No.条件有無
        public string hakkenNO { get; set; }               //発券No.
        public string jgyo { get; set; }                   //行政区条件有無
        public string gyo { get; set; }                    //行政区条件
        public string jjumin { get; set; }                 //住民区分条件有無
        public string jumin { get; set; }                  //銃未区分条件
        public string jman { get; set; }                   //男性生年月日条件有無
        public string manf { get; set; }                   //男性生年月日条件(FROM)
        public string mant { get; set; }                   //男性生年月日条件(TO)
        public string jwoman { get; set; }                 //女性生年月日条件有無
        public string womanf { get; set; }                 //女性生年月日条件(FROM)
        public string womant { get; set; }                 //女性生年月日条件(TO)
        public string jkosinymd { get; set; }              //更新年月日条件有無
        public string kosinymdf { get; set; }              //更新年月日条件(FROM)
        public string kosinymdt { get; set; }              //更新年月日条件(TO)
        public string jsessyuymd { get; set; }             //接種年月日条件有無
        public string symdkbn { get; set; }                //接種年月日条件-接種種別
        public string sessyuymdf { get; set; }             //接種年月日条件(FROM)
        public string sessyuymdt { get; set; }             //接種年月日条件(TO)
        public string jkeitai { get; set; }                //接種形態条件有無
        public string keitai { get; set; }                 //接種形態条件
        public string jkikan { get; set; }                 //医療機関条件有無
        public string kikankbn { get; set; }               //医療機関条件-接種種別
        public string kikan { get; set; }                  //医療機関条件
        public string jbasyo { get; set; }                 //接種場所条件有無
        public string basyokbn { get; set; }               //接種場所条件-接種種別
        public string basyo { get; set; }                  //接種場所条件
        public string jisi { get; set; }                   //接種医師条件有無
        public string isikbn { get; set; }                 //接種医師条件-接種種別
        public string isi { get; set; }                    //接種医師条件
        public string jyisi { get; set; }                  //予診医師条件有無
        public string yisikbn { get; set; }                //予診医師条件-接種種別
        public string yisi { get; set; }                   //予診医師条件
        public string jmi { get; set; }                    //未接種者条件有無
        public string mikbn { get; set; }                  //未接種者条件-接種種別
    }

    /*
    /// <summary>
    /// 接種情報管理（乳幼児）画面で使用する初期情報を抽出するRequest
    /// </summary>
    public class FormInitRequest : CmRequestBase
    {
        public string pgid { get; set; }                   //プログラムＩＤ
    }
    */
}