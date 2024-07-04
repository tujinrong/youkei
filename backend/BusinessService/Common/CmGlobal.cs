// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 
// 
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service
{
    public class CmGlobal
    {
        private static EnumRuntimeMode _RuntimeMode = EnumRuntimeMode.NORMAL;

        public static EnumRuntimeMode RuntimeMode
        {
            get
            {
                return _RuntimeMode;
            }
            set
            {
                _RuntimeMode = value;
                // DaGlobal.WriteExcelLog = Not (_RuntimeMode = SvEnumRuntimeMode.NORMAL)
            }
        }
    }
}