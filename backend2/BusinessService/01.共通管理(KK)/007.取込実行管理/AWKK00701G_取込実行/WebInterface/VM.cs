// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行
//             ビューモデル定義
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00701G
{
    /// <summary>
    /// 汎用取込設定情報モデル(取込設定一覧画面)
    /// </summary>
    public class KimpRowVM
    {
        public string impno { get; set; }       //一括取込入力No
        public string impnm { get; set; }       //一括取込入力名
        public string impkbn { get; set; }      //一括取込入力区分
        public string gyoumukbn { get; set; }   //業務区分
        public string memo { get; set; }        //説明
    }

    /// <summary>
    /// 取込データ情報モデル(未処理一覧画面)
    /// </summary>
    public class KimpDataRowVM
    {
        public int impexeid { get; set; }       //取込実行ID
        public string impno { get; set; }       //一括取込入力No
        public string impnm { get; set; }       //一括取込入力名
        public string gyoumukbn { get; set; }   //業務
        public string? filename { get; set; }   //ファイル名
        public int totalcnt { get; set; }       //件数
        public int errcnt { get; set; }         //エラー件数
        public string upduserid { get; set; }   //更新ユーザーID(前回更新者)
        public string upddttmShow { get; set; } //更新日時(前回更新時間)
        public DateTime upddttm { get; set; }   //更新日時(前回更新時間)Lock用
    }

    /// <summary>
    /// 取込履歴情報モデル(取込履歴一覧画面)
    /// </summary>
    public class KimpHistoryRowVM
    {
        public int rirekiid { get; set; }       //履歴番号
        public string regdttm { get; set; }     //登録日時(実行日時)
        public string reguserid { get; set; }   //登録ユーザーID(担当者)
        public string gyoumukbn { get; set; }   //業務
        public string impnm { get; set; }       //一括取込入力名
        public string impkbn { get; set; }      //一括取込入力区分
        public string? filename { get; set; }   //ファイル名
        public int regcnt { get; set; }         //登録件数(処理件数)
        public int errcnt { get; set; }         //エラー件数
    }

    /// <summary>
    /// 画面項目一覧明細情報モデル(取込（一括入力）編集画面)
    /// </summary>
    public class KimpDetailRowVM
    {
        public int impexeid { get; set; }                               //取込実行ID
        public int rowno { get; set; }                                  //行番号
        public string errMsg { get; set; }                              //エラー内容
        public List<PageItemBodyModel> PageItemBodyList { get; set; }   //画面項目リスト
    }

    /// <summary>
    /// 画面項目情報モデル(取込（一括入力）編集画面)
    /// </summary>
    public class PageItemBodyModel
    {
        public int dataseq { get; set; }        //データID
        public string? val { get; set; }        //項目値
        public int pageitemseq { get; set; }    //画面項目ID
        public bool errflg { get; set; }        //エラーフラグ (true:エラーなし、false:エラーあり)
        public string errkbn { get; set; }      //エラー区分
    }

    /// <summary>
    /// 画面項目定義情報モデル(取込（一括入力）編集画面)
    /// </summary>
    public class PageItemHeaderModel
    {
        public int pageitemseq { get; set; }           //画面項目ID
        public string itemnm { get; set; }             //項目名
        public string wktablecolnm { get; set; }       //ワークテーブルカラム名
        public string inputkbn { get; set; }           //入力区分
        public string inputtype { get; set; }          //入力方法
        public string? hikisu { get; set; }            //引数
        public int len { get; set; }                   //桁数
        public int? len2 { get; set; }                 //桁数（小数部）
        public int width { get; set; }                 //幅
        public string? format { get; set; }            //フォーマット
        public string requiredflg { get; set; }        //必須フラグ
        public bool uniqueflg { get; set; }            //一意フラグ
        public string dispinputkbn { get; set; }       //表示入力設定区分
        public int? sortno { get; set; }               //並び順
        public int? fromitemseq { get; set; }          //参照元項目ID
        public string? fromfieldid { get; set; }       //参照元フィールド
        public string? targetfieldid { get; set; }     //取得先フィールド
        public bool? nendoflg { get; set; }            //年度フラグ
        public string? yearchkflg { get; set; }        //年度チェック
        public string? seiki { get; set; }             //正規表現
        public string? minval { get; set; }            //最小値
        public string? maxval { get; set; }            //最大値
        public string? defaultval { get; set; }        //初期値
        public string? fixedval { get; set; }          //固定値
        public string? msttable { get; set; }          //マスタチェックテーブル
        public string? mstjyoken { get; set; }         //マスタチェック条件
        public string? mstfield { get; set; }          //マスタチェック項目
        public string? jherrlelkbn { get; set; }        //条件必須エラーレベル区分
        public int? jhitemseq { get; set; }            //条件必須項目ID
        public string? jhenzan { get; set; }           //条件必須演算子
        public string? jhval { get; set; }             //条件必須値
        public string? targetitemseq { get; set; }     //参照先項目ID(複数? ,)
        public string? itemkbn { get; set; }           //項目特定区分
        public string? jigyocd { get; set; }           //医療機関・事業従事者（担当者）事業コード
    }

    /// <summary>
    /// 排他チェック用モデル
    /// </summary>
    public class LockVM
    {
        public int impexeid { get; set; }       //取込実行ID
        public DateTime upddttm { get; set; }   //更新日時
        public LockVM(int impexeid, DateTime upddttm)
        {
            this.impexeid = impexeid;   //取込実行ID
            this.upddttm = upddttm;     //更新日時
        }
    }

    /// <summary>
    /// 編集画面検索用
    /// </summary>
    public class tt_kkimpdatadetailModel 
    {
        public int rowno { get; set; }       //行番号
    }

}