// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 乳幼児情報管理-発育曲線
// 　　　　　　サービス処理
// 作成日　　: 2024.03.08
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWBH00402D
{
    [DisplayName("乳幼児情報管理-発育曲線")]
    public class Service : CmServiceBase
    {
        //母子保健事業コード
        private const string JIGYOCD = "00099";             //発育曲線（仕様未確定）

        [DisplayName("発育曲線表示処理")]
        public ShowCurveResponse ShowCurve(ShowCurveRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return ShowCurve(db, req);
            });
        }

        //************************************************************** 処理ロジェック **************************************************************
        /// <summary>
        ///　発育曲線表示処理
        /// </summary>
        private ShowCurveResponse ShowCurve(DaDbContext db, ShowCurveRequest req)
        {
            var res = new ShowCurveResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、該当宛名番号の住民情報を取得
            var atenadto = db.tt_afatena.GetDtoByKey(req.atenano);
            if (atenadto == null) { throw new AiExclusiveException(); }

            //B、発育曲線のヘッダー情報を取得
            res.headerinfo = Wraper.GetHeaderVM(db, atenadto);

            //C、母子保健（フリー）項目コントロールマスタから発育曲線の項目コード情報を取得
            var graphcdlist = GetGraphCdList(db, req.bosikbn, JIGYOCD);

            var graphlistall = new List<GraphListVM>();
            var i = 1;
            foreach ( var graphinfo in graphcdlist)
            {
                //各発育曲線を設定
                var graphlist = GetGraphList(db, req, JIGYOCD, graphinfo, i);

                graphlistall.Add(graphlist);
                i++;
            };

            res.graphlist = graphlistall;

            //正常返し
            return res;
        }

        /// <summary>
        /// 個別発育曲線情報を取得
        /// </summary>
        private static GraphListVM GetGraphList(DaDbContext db, ShowCurveRequest req, string jigyocd, tm_bhkkfreeitemDto graphinfo, int i)
        {
            var graphvm = new GraphListVM();

            //A、該当発育曲線のフリー項目情報を取得
            var dtl = db.tt_bhnyfree.SELECT.WHERE.ByFilter($"{nameof(tt_bhnyfreeDto.jigyocd)}=@jigyocd and " +
                                                           $"{nameof(tt_bhnyfreeDto.atenano)}=@atenano and " +
                                                           $"{nameof(tt_bhnyfreeDto.itemcd)}=@itemcd"
                                                           , jigyocd, req.atenano, graphinfo.itemcd).GetDtoList()
                                                 .OrderBy(e => e.edano).ToList();

            //B、本人のグラフデータ設定
            graphvm.curveinfolist = Wraper.GetCurveInfoVMList(db, dtl);

            //C、P3(全体3%)とP97(全体97%)のグラフ処理
            var p3list = new List<CurveInfoVM>();
            var p97list = new List<CurveInfoVM>();

            foreach (CurveInfoVM vm in graphvm.curveinfolist)
            {
                //該当回数の総人数を取得
                var totalnum = db.tt_bhnyfree.SELECT.WHERE.ByFilter($"{nameof(tt_bhnyfreeDto.jigyocd)}=@jigyocd and " +
                                                                    $"{nameof(tt_bhnyfreeDto.edano)}=@edano and " +
                                                                    $"{nameof(tt_bhnyfreeDto.itemcd)}=@itemcd"
                                                                    , jigyocd, vm.kaisu, graphinfo.itemcd).GetCount();

                //該当回数の全体3 % の対象件数を計算する
                var p3num = CInt(Math.Round(CDbl(totalnum) * 0.03, 0));
                if (p3num < 1)
                {
                    //一件未満の場合は、対象件数は1と設定する
                    p3num = 1;
                }

                //該当回数のP3(全体3%)のグラフデータを取得
                var p3dtl = db.tt_bhnyfree.SELECT.WHERE.ByFilter($"{nameof(tt_bhnyfreeDto.jigyocd)}=@jigyocd and " +
                                                                 $"{nameof(tt_bhnyfreeDto.edano)}=@edano and " +
                                                                 $"{nameof(tt_bhnyfreeDto.itemcd)}=@itemcd"
                                                                 , jigyocd, vm.kaisu, graphinfo.itemcd).GetDtoList()
                                                       .OrderByDescending(e => e.numvalue).Skip(0).Take(p3num).ToList();

                //該当回数のP3平均値を取得
                double val = CDbl(p3dtl.Sum(e => e.numvalue) / p3num);
                val = CDbl(FormatNumber(val, 2));

                //該当履歴回数のP3(全体3%)データを設定
                var p3vm = new CurveInfoVM()
                {
                    kaisu = vm.kaisu,
                    value = val,
                };

                //P3(全体3%)のグラフデータリストに追加
                p3list.Add(p3vm);

                //該当回数の全体97%の対象件数を計算する
                var p97num = totalnum - p3num;

                //該当回数のP97(全体97 %)のグラフデータを取得
                var p97dtl = db.tt_bhnyfree.SELECT.WHERE.ByFilter($"{nameof(tt_bhnyfreeDto.jigyocd)}=@jigyocd and " +
                                                                  $"{nameof(tt_bhnyfreeDto.edano)}=@edano and " +
                                                                  $"{nameof(tt_bhnyfreeDto.itemcd)}=@itemcd"
                                                                  , jigyocd, vm.kaisu, graphinfo.itemcd).GetDtoList()
                                                        .OrderByDescending(e => e.numvalue).Skip(p3num).ToList();

                //該当履歴回数のP97平均値を取得
                val = CDbl(p97dtl.Sum(e => e.numvalue) / p97num);
                val = CDbl(FormatNumber(val, 2));

                //該当履歴回数のP97(全体97%)データを設定
                var p97vm = new CurveInfoVM()
                {
                    kaisu = vm.kaisu,
                    value = val,
                };

                //P97(全体97%)のグラフデータリストに追加
                p97list.Add(p97vm);
            }

            //-------------------------------------------------------------
            //２.データ設定
            //-------------------------------------------------------------

            //リクエストデータ設定
            graphvm.no = i;                                     //発育曲線番号
            graphvm.itemnm = CStr(graphinfo.itemnm);            //部位名称
            graphvm.tani = CStr(graphinfo.tani);                //単位
            graphvm.p3curveinfolist = p3list;                   //P3(全体3%)のグラフ
            graphvm.p97curveinfolist = p97list;                 //P97(全体97%)のグラフ

            return graphvm;
        }

        /// <summary>
        ///乳幼児の発育曲線フリー項目コードリストを取得
        /// </summary>
        private static List<tm_bhkkfreeitemDto> GetGraphCdList(DaDbContext db, string bosikbn, string jigyocd)
        {
            var dtl = db.tm_bhkkfreeitem.SELECT.WHERE.ByKey(bosikbn, jigyocd).GetDtoList().OrderBy(e => e.orderseq).ToList();
            return dtl;
        }

        /// <summary>
        ///Double型保留ｎ小数
        /// </summary>
        static string FormatNumber(double num, int decimalPlaces)
        {
            return num.ToString("#." + new string('0', decimalPlaces));
        }
    }
}