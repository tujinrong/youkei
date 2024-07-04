// *******************************************************************
// 業務名称　: 生乳取引数量等確認事務支援システム
// 機能概要　: Modelベースクラス
//
// 作成日　　: 2022.08.03
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using Microsoft.VisualBasic.CompilerServices;
namespace BCC.Affect.DataAccess
{
    public class DaEntityModelBase
    {
        public object Copy()
        {
            return MemberwiseClone();
        }

        public T Copy<T>()
        {
            return Conversions.ToGenericParameter<T>(MemberwiseClone());
        }
    }
}