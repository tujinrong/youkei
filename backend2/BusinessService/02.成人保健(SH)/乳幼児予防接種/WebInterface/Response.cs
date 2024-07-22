// *******************************************************************
// 業務名称　: 乳幼児予防接種
// 機能概要　: 乳幼児予防接種
//             レスポンスインターフェース
// 作成日　　: 2024.07.23
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.InfantVaccination
{
    /// <summary>
    /// 乳幼児予防接種情報（検索）Response
    /// 乳幼児予防接種情報（詳細検索）Response
    /// </summary>
    public class KensakuResponse : DaResponseBase
    {
        public ulong cmeisai { get; set; }                 //量
        public PersonalInfo mkojin { get; set; }           //個人情報
        public List<FamilyMemberInfo> msetai { get; set; } //世帯構成員情報
        public List<VaccinationInfo> msessyu { get; set; } //接種情報
        public int mbikof { get; set; }                    //備考情報有無
        public List<InfantInfo> mnyken { get; set; }       //乳幼児健診情報
        public string mmemomsg { get; set; }               //メモ情報有無メッセージフラグ
        public MemoExistInfo mmemof { get; set; }          //メモ情報有無情報
        public int mdocf { get; set; }                     //ドキュメント管理情報有無
        public string mdvmsg { get; set; }                 //世帯DV対象者メッセージ表示フラグ
        public string mdvtaisyo { get; set; }              //世帯内のDV対象者氏名
        public int mpushf { get; set; }                    //プッシュ通知希望情報有無
        public int mhomonf { get; set; }                   //訪問指導情報の有無
        public int msodanf { get; set; }                   //健康相談情報の有無
        public List<OtherInfo> mfree { get; set; }         //その他情報
        public string mcovcoupno { get; set; }             //新型コロナ発券No
        // public List<?> kensaku { get; set; }            //unknown
    }

    /// <summary>
    /// 個人情報
    /// </summary>
    public class PersonalInfo
    {
        public string kojinno { get; set; }                //整理番号
        public string kname { get; set; }                  //カナ氏名
        public string bymd { get; set; }                   //生年月日
        public int kyohiflg { get; set; }                  //接種拒否フラグ
        public int rikanm { get; set; }                    //麻しん罹患フラグ
        public int rikanf { get; set; }                    //風しん罹患フラグ
        public int rikanh { get; set; }                    //百日咳罹患フラグ
        public int rikans { get; set; }                    //水痘罹患フラグ
        public int taisyob { get; set; }                   //母子感染対象フラグ
        public string name { get; set; }                   //氏名
        public string sex { get; set; }                    //性別
        public int gage { get; set; }                      //年
        public string gkijun { get; set; }                 //現在の時刻
        public string gyocd { get; set; }                  //行政区コード
        public string gyonm { get; set; }                  //名称
        public string adrs { get; set; }                   //住所
        public string kata { get; set; }                   //方書
        public string sname { get; set; }                  //世帯主名
        public string szeiflg { get; set; }                //世帯課税フラグ（住民税）
        public string kzeiflg { get; set; }                //個人課税区分
        public string hokennm { get; set; }                //保険区分
        public string tel { get; set; }                    //電話番号１
        public string setaino { get; set; }                //世帯番号
        public string jkbn { get; set; }                   //住民区分
        public string idojiyu { get; set; }                //異動事由
        public string tennyuymd { get; set; }              //直近の転入日
        public DateTime juymd { get; set; }                //住民となった日
        public DateTime jnymd { get; set; }                //住民でなくなった日
    }


    /// <summary>
    /// 世帯構成員情報
    /// </summary>
    public class FamilyMemberInfo
    {
        public string kojinno { get; set; }                //整理番号
        public string name { get; set; }                   //氏名
        public string zokunm { get; set; }                 //続柄名称
        public string jkbn { get; set; }                   //住民区分
    }
    
    /// <summary>
    /// 接種情報
    /// </summary>
    public class VaccinationInfo 
    {
        public string sessyukbn { get; set; }              //汎用区分１
        public string sessyuname { get; set; }             //内容
        public string kbn { get; set; }                    //予防接種区分
        public string sessyuymd { get; set; }              //接種日
        public string juriymd { get; set; }                //受理年月日
        public string lotno { get; set; }                  //ロットNo
        public string seizocd { get; set; }                //製造者CD
        public string seizonm { get; set; }                //製造者名
        public string keitai { get; set; }                 //接種形態CD
        public string keitainm { get; set; }               //接種形態名
        public string kikancd { get; set; }                //接種医療機関CD
        public string kikannm { get; set; }                //接種医療機関名
        public string basyocd { get; set; }                //接種場所CD
        public string basyonm { get; set; }                //接種場所名
        public string isicd { get; set; }                  //接種医師CD
        public string isinm { get; set; }                  //接種医師名
        public string yisicd { get; set; }                 //予診医師CD
        public string yisinm { get; set; }                 //予診医師名
        public float sessyuryo { get; set; }               //接種量
        public int koufu { get; set; }                     //接種済証交付有無
        public string koufunm { get; set; }                //接種済証交付有無 名
        public string tyosyu { get; set; }                 //料金徴収有無
        public string tyosyunm { get; set; }               //料金徴収有無 名
        public int kosinflg { get; set; }                  //料金徴収有無 名
        public string groupid { get; set; }                //汎用区分１
        public string groupid2 { get; set; }               //汎用区分２
    }
    
    /// <summary>
    /// 乳幼児健診情報
    /// </summary>
    public class InfantInfo
    {
        public string meisyo { get; set; }                 //内容
        public string kenymd { get; set; }                 //健診年月日
    }
    
    /// <summary>
    /// メモ情報有無情報
    /// </summary>
    public class MemoExistInfo
    {
        public int memof { get; set; }                     //メモ情報有無
        public int tyuif { get; set; }                     //注意フラグ
    }

    /// <summary>
    /// その他情報を
    /// </summary>
    public class OtherInfo
    {
        public string groupid { get; set; }                //グループID
        public string groupid2 { get; set; }               //グループID2
        public string groupnm { get; set; }                //備考
        public string itemcd { get; set; }                 //項目ＣＤ
        public string itemnm { get; set; }                 //項目名
        public short datatype { get; set; }                //データタイプ
        public short cfid { get; set; }                    //コントロールファイルＩＤ
        public string maincd { get; set; }                 //メインＣＤ
        public string subcd { get; set; }                  //サブＣＤ
        public string biko { get; set; }                   //備考
        public string inputdata { get; set; }              //管理項目
        public string naiyo { get; set; }                  //コンテンツ
        public string nendo { get; set; }                  //年度
        public int hissu { get; set; }                     //必須チェック
        public int valdata { get; set; }                   //初期値
        public short seisuketa { get; set; }               //整数部桁数
        public short syosuketa { get; set; }               //小数部桁数
        public string maxkijun {get; set;}                 //わからない(常にヌル)
        public string minkijun {get; set;}                 //わからない(常にヌル)
        public string maxhsido {get; set;}                 //わからない(常にヌル)
        public string minhsido {get; set;}                 //わからない(常にヌル)
        public string maxinput {get; set;}                 //わからない(常にヌル)
        public string mininput {get; set;}                 //わからない(常にヌル)
        public short orderid {get; set;}                   //並び替え用
    } 
    
    /*
    /// <summary>
    /// 接種情報管理（乳幼児）画面で使用する初期情報を抽出するResponse
    /// </summary>
    public class FormInitResponse : CmResponseBase
    {
        public string msyoricd { get; set; }                         // 唯一の索引(primary key)
        public List<VaccinationInfoInit> msessyu { get; set; }       // 接種区分情報(初期化用)
        public List<SqlCfVM> msessyug { get; set; }                  // 予防接種項目グループ（コンボボックス用）
        public List<SqlCfVM> msessyug2 { get; set; }                 // 予防接種項目グループ２（コンボボックス用）
        public List<VaccinationInfoInput> mskbn { get; set; }        // 接種区分情報(入力域コンボ)（コンボボックス用）
        public List<VaccinationInfo> mjsessyu1 { get; set; }         // 接種区分情報（リストボックス(詳細条件-接種日用)）
        public List<VaccinationInfo> mjsessyu2 { get; set; }         // 接種区分情報（リストボックス(詳細条件-医療機関用)）
        public List<VaccinationInfo> mjsessyu3 { get; set; }         // 接種区分情報（リストボックス(詳細条件-接種場所用)）
        public List<VaccinationInfo> mjsessyu4 { get; set; }         // 接種区分情報（リストボックス(詳細条件-接種医師用)）
        public List<VaccinationInfo> mjsessyu5 { get; set; }         // 接種区分情報（リストボックス(詳細条件-予診医師用)）
        public List<VaccinationInfo> mjsessyu6 { get; set; }         // 接種区分情報（リストボックス(詳細条件-未接種用)）
        public List<SqlCfVM> mkeitai { get; set; }                   // 接種形態情報（コンボボックス用）
        public List<SqlCfVM> mjkeitai { get; set; }                  // 接種形態情報（リストボックス用）
        public List<SqlCfVM> mbasyo { get; set; }                    // 接種場所情報（コンボボックス用）
        public List<SqlCfVM> mjbasyo { get; set; }                   // 接種場所情報（リストボックス用）
        public List<MedicalInstitutionInfo> mkikan { get; set; }     // 医療機関情報（コンボボックス用）
        public List<MedicalInstitutionInfo> mjkikan { get; set; }    // 医療機関情報（リストボックス用）
    }

    
    /// <summary>
    /// 接種区分情報(初期化用)
    /// </summary>
    public class VaccinationInfoInit
    {
        public string sessyukbn { get; set; }                        // 汎用区分１
        public string sessyuname { get; set; }                       // 内容
        public string kbn { get; set; }                              // ＣＤ
    }

    /// <summary>
    /// 接種区分情報(入力域コンボ)
    /// </summary>
    public class VaccinationInfoInput
    {
        public string data { get; set; }                             //汎用区分１
        public string label { get; set; }                            //内容
        public string kbn3 { get; set; }                             //汎用区分３
        public string kbn { get; set; }                              //ＣＤ
        public string group { get; set; }                            //汎用区分１
        public string group2 { get; set; }                           //汎用区分２
    }
    
    /// <summary>
    /// 接種区分情報
    /// </summary>
    public class VaccinationInfo
    {
        public string data { get; set; }                             //ＣＤ
        public string label { get; set; }                            //内容
    }

    /// <summary>
    /// 医療機関情報
    /// </summary>
    public class MedicalInstitutionInfo
    {
        public string data { get; set; }                             //機関ＣＤ
        public string label { get; set; }                            //施設名称
        public string kbn { get; set; }                              //ＣＤ
    }
    */
    
}