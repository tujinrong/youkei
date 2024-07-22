// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票項目編集
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWEU00105D;

namespace BCC.Affect.Service.AWEU00205D
{
    public class Wraper : CmWraperBase
    {
        private const string NUM_ONE = "1";

        /// <summary>
        /// マスタ情報リストを取得
        /// </summary>
        public static List<MasterVM> GetMasterVMList(DaDbContext db, List<tm_eutableitemnameDto> itemNameDtl, DataRowCollection rows)
        {
            var dict = rows.Cast<DataRow>().ToDictionary(r => (r.Wrap(nameof(tm_eutableitemnameDto.tablenm)), r.Wrap(nameof(CdVM.columnnm))),
                r => r.Wrap(nameof(CdVM.columncomment)));

            var list = new List<MasterVM>(itemNameDtl.Count + 1);
            //マスタ情報を取得
            list.AddRange(itemNameDtl.Select(dto => GetMasterVM(db, dto, dict)));

             MasterVM manul = new()
            {
                mastercd = string.Empty,    //マスタコード
                masterhyojinm = "手入力",   //マスタ名称
                cdlist = new List<CdVM>(0), //コードリスト
                manualflg = true            //手入力フラグ
            };

            list.Add(manul);
            return list;
        }

        /// <summary>
        /// フォーマット情報リストを取得
        /// </summary>
        public static List<FormatVM> GetFormatVMList(IEnumerable<tm_afmeisyoDto> formatDtl, IReadOnlyDictionary<long, (EnumNmKbn, List<tm_afmeisyoDto>)> formatSyosaiDict)
        {
            formatDtl = formatDtl.OrderBy(x => int.TryParse(x.nmcd, out var i) ? i : int.MaxValue);

            return formatDtl.Select(x => GetFormatVM(x, formatSyosaiDict)).ToList();
        }

        /// <summary>
        /// マスタ情報を取得
        /// </summary>
        private static MasterVM GetMasterVM(DaDbContext db, tm_eutableitemnameDto dto, IReadOnlyDictionary<(string, string), string> dict)
        {
            var vm = new MasterVM();
            vm.mastercd = dto.mastercd;                             //マスタコード
            vm.masterhyojinm = dto.masterhyojinm;                   //マスタ名称
            vm.cdlist = AWEU00105D.Wraper.GetCdList(db, dto, dict); //コードリスト
            vm.manualflg = false;                                   //手入力フラグ
            return vm;
        }

        /// <summary>
        /// フォーマット情報を取得
        /// </summary>
        private static FormatVM GetFormatVM(tm_afmeisyoDto dto, IReadOnlyDictionary<long, (EnumNmKbn, List<tm_afmeisyoDto>)> formatSyosaiDict)
        {
            var vm = new FormatVM();
            vm.formatkbn = dto.nmcd;  //フォーマット区分
            vm.formatnm = dto.nm;     //フォーマット名称
            if (long.TryParse(dto.hanyokbn1, out var l) && formatSyosaiDict.TryGetValue(l, out var tuple))
            {
                //フォーマット詳細情報リストを取得
                vm.syosailist = GetFormatSyosaiVMList(tuple, dto.nmcd); 
            }

            return vm;
        }

        /// <summary>
        /// フォーマット詳細情報リストを取得
        /// </summary>
        private static List<FormatSyosaiVM> GetFormatSyosaiVMList((EnumNmKbn, List<tm_afmeisyoDto>) tuple, string nmcd)
        {
            var isTime = tuple.Item1 is EnumNmKbn.年形式 or EnumNmKbn.日付形式 or EnumNmKbn.日時形式 or EnumNmKbn.時間形式;
            var now = DaUtil.Now;
            var list = tuple.Item2.OrderBy(x => int.TryParse(x.nmcd, out var i) ? i : int.MaxValue);
            return list.Select(x => GetFormatSyosaiVM(x, isTime, now,nmcd)).OrderBy(e => e.formattypenm).ToList();
        }
        
        /// <summary>
        /// フォーマット詳細情報を取得
        /// </summary>
        private static FormatSyosaiVM GetFormatSyosaiVM(tm_afmeisyoDto dto, bool isTime, DateTime now, string nmcd)
        {
            var syosaiVm = new FormatSyosaiVM();
            syosaiVm.formatkbn2 = dto.nmcd;         //フォーマット区分2
            syosaiVm.formattypenm = dto.nm;         //フォーマット種別名
            syosaiVm.formatsyosai = dto.hanyokbn1;  //フォーマット詳細
            //ユーザー定義フラグ
            syosaiVm.userdefinedflg = "ユーザー定義".Equals(dto.nm, StringComparison.OrdinalIgnoreCase); 
            if (NUM_ONE.Equals(nmcd))
            {
                syosaiVm.userdefinedflg = true;
            }

            if(isTime && !string.IsNullOrEmpty(dto.hanyokbn1))
            {
                //フォーマット例
                syosaiVm.formatexample = AiDataUtil.FormatDate(now, dto.hanyokbn1) ; 
            }
            return syosaiVm;
        }
    }
}