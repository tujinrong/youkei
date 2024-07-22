// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 
// 
// 作成日　　: 2024.07.12
// 作成者　　: 
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