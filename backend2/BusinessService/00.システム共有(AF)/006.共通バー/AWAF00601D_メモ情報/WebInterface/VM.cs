// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: メモ情報
//             ビューモデル定義
// 作成日　　: 2024.07.02
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWAF00601D
{
    /// <summary>
    /// メモ情報(新規)
    /// </summary>
    public class AddVM
    {
        public string jigyokbn { get; set; }    //登録事業（共通・各事業）
        public string juyodo { get; set; }      //重要度
        public string title { get; set; }       //件名（タイトル）
        public string memo { get; set; }        //メモ（フリーテキスト）
        public string kigenymd { get; set; }    //期限日
    }

    /// <summary>
    /// メモ情報(更新)
    /// </summary>
    public class UpdVM : AddVM
    {
        public int memoseq { get; set; }    //メモシーケンス
    }

    /// <summary>
    /// メモ情報(検索)
    /// </summary>
    public class SearchVM : UpdVM
    {
        public string regsisyo { get; set; }    //登録支所
        public string regusernm { get; set; }   //登録者
        public DateTime regdttm { get; set; }   //登録日時
        public string updusernm { get; set; }   //登録者
        public DateTime upddttm { get; set; }   //更新日時
        public bool updflg { get; set; }        //更新権限フラグ
    }

    /// <summary>
    /// 排他チェック用モデル
    /// </summary>
    public class LockVM
    {
        public int memoseq { get; set; }         //メモシーケンス
        public DateTime upddttm { get; set; }    //更新日時
    }
}