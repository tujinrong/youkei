// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ホーム
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.07.20
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00301G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// お知らせ情報リスト
        /// </summary>
        public static List<InfoVM> GetInfoVMList(DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(GetInfoVM).ToList();
        }

        /// <summary>
        /// 外部連携処理結果履歴リスト
        /// </summary>
        public static List<GaibulogVM> GetGaibuVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GetGaibulogVM(db, r)).ToList();
        }

        /// <summary>
        /// ファイルリスト取得
        /// </summary>
        public static List<DaFileModel> GetFileList(List<tt_afgaibulogDto> dtl)
        {
            return dtl.Select(d => new DaFileModel(d.filenm, $".{d.filetype}", d.filedata)).ToList();
        }

        /// <summary>
        /// お知らせ情報
        /// </summary>
        private static InfoVM GetInfoVM(DataRow row)
        {
            var vm = new InfoVM();
            vm.infoseq = row.CLng(nameof(InfoVM.infoseq));  //お知らせシーケンス
            vm.juyodo = row.Wrap(nameof(InfoVM.juyodo));    //重要度
            vm.readflg = row.CBool(nameof(InfoVM.readflg)); //既読未読フラグ
            vm.regdttm = row.CDate(nameof(InfoVM.regdttm)); //登録日時
            vm.syosai = row.Wrap(nameof(InfoVM.syosai));    //詳細
            return vm;
        }

        /// <summary>
        /// 外部連携処理結果履歴
        /// </summary>
        private static GaibulogVM GetGaibulogVM(DaDbContext db, DataRow row)
        {
            var statuscd = row.Wrap(nameof(tt_aflogDto.statuscd));                                              //処理結果コード
            var syorikbn = row.Wrap(nameof(GaibulogVM.syorikbn));                                               //処理区分コード
            var vm = new GaibulogVM();
            vm.gaibulogseq = row.CLng(nameof(GaibulogVM.gaibulogseq));                                          //外部連携ログシーケンス
            vm.syoridttmf = row.CDate(nameof(GaibulogVM.syoridttmf));                                           //処理日時（開始）
            vm.syoridttmt = row.CDate(nameof(GaibulogVM.syoridttmt));                                           //処理日時（終了）
            vm.syorikbn = DaNameService.GetName(db, EnumNmKbn.連携処理区分, syorikbn);                          //処理区分
            vm.usernm = row.Wrap(nameof(GaibulogVM.usernm));                                                    //操作者名
            vm.syorinm = row.Wrap(nameof(GaibulogVM.syorinm));                                                  //処理内容
            vm.status = DaNameService.GetName(db, EnumNmKbn.処理結果コード, statuscd);                          //処理結果
            vm.colorkbn = (Enum表示色区分)CInt(DaNameService.GetKbn1(db, EnumNmKbn.処理結果コード, statuscd));  //処理結果表示色区分
            vm.fileflg = !string.IsNullOrEmpty(row.Wrap(nameof(tt_afgaibulogDto.filenm)));                      //ファイル存在フラグ
            return vm;
        }

        /// <summary>
        /// 親階層リスト(フォルダー)
        /// </summary>
        public static List<MenuModel> GetAllParentsMenu(List<tm_afmeisyoDto> foldDtl)
        {
            return foldDtl.OrderBy(e => e.hanyokbn1).ThenBy(e => CInt(e.hanyokbn2)).Select(e =>
            {
                //完全なパス取得
                var parent = foldDtl.Find(f => f.nmcd == e.hanyokbn1);
                var path = $"/{e.nmcd}";
                while (parent != null)
                {
                    path = $"/{parent.nmcd}{path}";
                    parent = foldDtl.Find(f => f.nmcd == parent.hanyokbn1);
                }

                var m = new MenuModel();
                m.path = path;                  //パス(URL用)
                m.menuid = e.nmcd;              //該当階層ID
                m.parentid = CStr(e.hanyokbn1); //親階層ID(最上階なし)
                m.menuname = e.nm;              //該当階層名
                m.menuseq = CInt(e.hanyokbn2);  //階層内表示順
                m.isfolder = true;              //フォルダフラグ
                return m;
            }).ToList();
        }

        /// <summary>
        /// 子階層リスト(画面)
        /// </summary>
        public static List<MenuModel> GetAllChildrenMenu(List<tm_afmenuDto> menuDtl, List<tm_afkinoDto> kinoDtl, List<GamenModel> authList, List<MenuModel> parentMenus)
        {
            return menuDtl.Select(e =>
            {
                var menu = new MenuModel();
                //パス
                var parentPath = parentMenus.Find(f => f.menuid == e.oyamenuid)?.path ?? string.Empty;
                menu.path = $"{parentPath}/{e.kinoid}";             //パス(URL用)
                menu.menuid = e.kinoid;                             //該当階層ID
                //表示名
                var kino = kinoDtl.Find(k => k.kinoid == e.kinoid)!;
                menu.menuname = kino.hyojinm;                       //該当階層名
                menu.parentid = e.oyamenuid;                        //親階層ID
                menu.menuseq = e.orderseq;                          //階層内表示順
                menu.isfolder = false;                              //フォルダフラグ
                menu.paramkeisyoflg = e.paramkeisyoflg;             //検索パラメーター継承フラグ
                //権限
                var auth = authList.Find(p => p.menuid == e.kinoid);
                menu.enabled = auth != null;                        //アクセス権限
                menu.addflg = auth?.addflg ?? false;                //追加権限フラグ
                menu.updateflg = auth?.updateflg ?? false;          //修正権限フラグ
                menu.deleteflg = auth?.deleteflg ?? false;          //削除権限フラグ
                menu.personalnoflg = auth?.personalnoflg ?? false;  //個人番号利用権限フラグ
                return menu;
            }).ToList();
        }

        /// <summary>
        /// プログラムリスト(画面IDが異なって、プログラムが共用)
        /// </summary>
        public static List<ProgramModel> GetProgramList(List<tm_afmenuDto> menuDtl, List<tm_afkinoDto> kinoDtl)
        {
            //メニューキーリスト
            var keylist = menuDtl.Select(e => e.kinoid).ToList();
            //共用プログラムが存在するメニューリスト
            var list = kinoDtl.Where(e => !string.IsNullOrEmpty(e.programid) && keylist.Contains(e.kinoid)).ToList();
            //プログラム(共用)リスト
            var keylist2 = list.Select(e => e.programid).Distinct().ToList();

            var lst = new List<ProgramModel>();

            foreach (var id in keylist2)
            {
                //同じプログラムに対してのメニューリスト
                var mList = list.Where(e => e.programid == id).ToList();

                lst.Add(new ProgramModel { kinoid = id!, menuids = mList.Select(e => e.kinoid).ToList() });
            }

            return lst;
        }
    }
}