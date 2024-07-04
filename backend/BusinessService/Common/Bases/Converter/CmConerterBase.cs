// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ベースロジック
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service
{
    public class CmConerterBase
    {
        /// <summary>
        /// 検索入力欄(通常)
        /// </summary>
        public static string? ToLikeStr(string? value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return $"%{value}%";
        }
        /// <summary>
        /// 検索入力欄(カナ)
        /// </summary>
        public static string? ToKanaLikeStr(string? value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return $"%{DaConvertUtil.ToKana(value)}%";
        }
        /// <summary>
        /// 検索入力欄(氏名カナ)
        /// </summary>
        public static string? ToKnameLikeStr(string? kname)
        {
            if (!string.IsNullOrEmpty(kname))
            {
                //カタカナへ変換
                kname = DaConvertUtil.ToKana(kname);
                //清音化
                kname = DaConvertUtil.ToSeion(kname);
                //%変換
                kname = kname.Replace("％", "%");
                return $"{kname}%";
            }
            else
            {
                return null;
            }
        }
    }
}