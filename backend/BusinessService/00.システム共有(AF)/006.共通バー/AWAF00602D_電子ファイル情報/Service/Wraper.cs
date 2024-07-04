// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 電子ファイル情報
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.03.09
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00602D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 電子ファイル情報(明細部)
        /// </summary>
        public static List<SearchVM> GetVMList(DaDbContext db, DataRowCollection rows, List<string> sisyoList, List<tm_afhanyoDto> dtl1, List<tm_afhanyoDto> dtl2)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(r, sisyoList, dtl1, dtl2)).ToList();
        }

        /// <summary>
        /// ファイル取得
        /// </summary>
        public static DaFileModel GetFile(tt_afkojindocDto dto)
        {
            return new DaFileModel(dto.filenm, $"{DaStrPool.C_DOT}{dto.filetype}", dto.filedata);
        }

        /// <summary>
        /// ファイルリスト取得
        /// </summary>
        public static List<DaFileModel> GetFileList(List<tt_afkojindocDto> dtl)
        {
            return dtl.Count == 1 ? new List<DaFileModel> { GetSingleFile(dtl[0]) } : dtl.Select(GetSingleFile).ToList();
        }

        /// <summary>
        /// 電子ファイル情報(1件)
        /// </summary>
        private static SearchVM GetVM(DataRow row, List<string> sisyoList, List<tm_afhanyoDto> dtl1, List<tm_afhanyoDto> dtl2)
        {
            var vm = new SearchVM();

            vm.docseq = row.CInt(nameof(tt_afkojindocDto.docseq));                          //ドキュメントシーケンス

            var filetype = (EnumFileTypeKbn)row.CInt(nameof(tt_afkojindocDto.filetype));    //ファイルタイプ
            vm.imgflg = CmFileUtil.GetImgFlg(filetype);                                     //画像フラグ
            vm.title = row.Wrap(nameof(tt_afkojindocDto.title));                            //タイトル
            vm.regdttm = row.CDate(nameof(tt_afkojindocDto.regdttm));                       //登録日時(アップロード日時)
            var jigyocd = row.Wrap(nameof(tt_afkojindocDto.jigyocd));                       //事業コード
            //事業(コード：名称)
            vm.jigyo = string.IsNullOrEmpty(jigyocd) ? string.Empty : DaHanyoService.GetCdNm(dtl1, Enum名称区分.名称, jigyocd);
            vm.jigyonm = DaSelectorService.GetName(vm.jigyo);                               //事業名
            var filenm = row.Wrap(nameof(tt_afkojindocDto.filenm));
            vm.filenm = $"{filenm}{DaStrPool.C_DOT}{filetype}";                             //ファイル名
            vm.juyoflg = row.CBool(nameof(tt_afkojindocDto.juyoflg));                       //重要フラグ

            vm.upddttm = row.CDate(nameof(tt_afkojindocDto.upddttm));                       //更新日時(排他用)
            var regsisyo = row.Wrap(nameof(tt_afkojindocDto.regsisyo));                     //登録支所
            vm.regsisyonm = DaHanyoService.GetName(dtl2, Enum名称区分.名称, regsisyo);      //登録支所名
            vm.updflg = string.IsNullOrEmpty(regsisyo) || sisyoList.Contains(regsisyo);     //更新権限フラグ

            return vm;
        }

        /// <summary>
        /// ファイル取得
        /// </summary>
        private static DaFileModel GetSingleFile(tt_afkojindocDto dto)
        {
            return new DaFileModel($"{dto.filenm}{DaStrPool.C_UNDERLINE}{dto.upddttm.ToString(Service.TimeFormat)}", $"{DaStrPool.C_DOT}{dto.filetype}", dto.filedata);
        }
    }
}