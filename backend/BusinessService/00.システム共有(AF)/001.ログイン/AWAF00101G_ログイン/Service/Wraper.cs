// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ログイン
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.02.21
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00101G
{
    public class Wraper : Common.Wraper
    {
        /// <summary>
        /// ユーザー共通
        /// </summary>
        public static UserInfoVM GetUserInfoVM(tm_afuserDto dto, tm_afsyozokuDto? syozokuDto)
        {
            var vm = new UserInfoVM();
            vm.userid = dto.userid;                         //ユーザーID
            vm.usernm = dto.usernm;                         //ユーザー名
            vm.syozokunm = CStr(syozokuDto?.syozokunm);     //所属コード
            //ユーザー権限設定の場合
            if (dto.authsetflg)
            {
                vm.kanrisyaflg = dto.kanrisyaflg;           //管理者フラグ
            }
            //所属権限設定の場合
            else
            {
                vm.kanrisyaflg = syozokuDto!.kanrisyaflg;   //管理者フラグ
            }
            return vm;
        }
    }
}