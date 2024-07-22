// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: EUC帳票ロジック処理
//            特殊項目処理
// 作成日　　: 2023.05.07
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.AiReport.Common;
using AIplus.AiReport.Interface;
using AIplus.AiReport.Models;

namespace BCC.Affect.DataAccess
{
    public enum EnumEucPublicPrivate
    {
        内部=1,
        外部=2,
        両方=3
    }
    public class DaSpecialItemInfo
    {
        public string Name { get; set; }

        /// <summary>
        /// 空白:all 1:一覧表 2:台帳 3:経年表 4:集計表 5:カスタマイズ		
        /// </summary>
        public string yosikisyubetu { get; set; }

        //データソース利用
        public bool IsDataSource { get; set; }

        /// <summary>
        /// 検索条件に表示
        /// </summary>
        public bool IsCondition { get; set; }

        public bool IsMapping { get; set; }

        public bool IsCross { get; set; }

        public IArSpecialItem? ItemObject { get; set; }

        public EnumEucPublicPrivate PublicPrivate { get; set; }

        public DaSpecialItemInfo(string name, string yosikisyubetu, bool isDataSource, bool isCondition, bool isMapping, bool isCross, EnumEucPublicPrivate publicPrivate, IArSpecialItem? itemObject)
        {
            Name = name;
            this.yosikisyubetu = yosikisyubetu;
            this.IsDataSource = isDataSource;
            this.IsCondition = isCondition;
            ItemObject = itemObject;
            IsMapping = isMapping;
            IsCross = isCross;
            PublicPrivate = publicPrivate;
        }
    }
    public class DaSpecialItemManager
    {
        public List<DaSpecialItemInfo> Items;


        public DaSpecialItemManager()
        {
            Init(null, "", "", null);
        }

        public DaSpecialItemManager(DaDbContext db, string rptID, string yosikiid, ArConditionModel condition)
        {
            Init(db, rptID, yosikiid, condition);
        }

        private void Init(DaDbContext db, string rptID, string yosikiid, ArConditionModel condition)
        {
            Items = new List<DaSpecialItemInfo>()
            {
                //帳票項目
                new DaSpecialItemInfo("帳票名", "", false, false, true, false, EnumEucPublicPrivate.両方, new DaEucSpecialItem_帳票名(db, rptID)),
                new DaSpecialItemInfo("様式名", "", false, false, true, false,EnumEucPublicPrivate.両方, new DaEucSpecialItem_様式名(db, rptID, yosikiid)),
                new DaSpecialItemInfo(ArConst.ページ番号, "",false, false, true,false, EnumEucPublicPrivate.両方,null),
                new DaSpecialItemInfo(ArConst.総ページ数, "",false, false, true,false, EnumEucPublicPrivate.両方, null),
                new DaSpecialItemInfo(ArConst.ページ番号_総ページ数, "", false, false,true,false, EnumEucPublicPrivate.両方, null),
                new DaSpecialItemInfo(ArConst.データ件数, "", false, false, true, false, EnumEucPublicPrivate.両方, null),
                new DaSpecialItemInfo("連番", "", false, false, true, false, EnumEucPublicPrivate.両方, null),

                //日付項目
                new DaSpecialItemInfo("出力日", "", true,false, true,true, EnumEucPublicPrivate.両方,new DaEucSpecialItem_出力日()),
                new DaSpecialItemInfo("出力日（和暦）", "",true, false, true,true, EnumEucPublicPrivate.両方, new DaEucSpecialItem_出力日和暦()),
                //日付項目・データソース設定項目
                new DaSpecialItemInfo(DaEucService.発行日, "", false, true, true, true, EnumEucPublicPrivate.両方, new DaEucSpecialItem_発行日(condition)),
                new DaSpecialItemInfo($"{DaEucService.発行日}（和暦）", "", false, false, true, true, EnumEucPublicPrivate.両方,new DaEucSpecialItem_発行日_和暦(condition)),
                new DaSpecialItemInfo(DaEucService.基準日, "", false, true, true, true, EnumEucPublicPrivate.両方,new DaEucSpecialItem_基準日(condition)),
                new DaSpecialItemInfo($"{DaEucService.基準日}（和暦）", "",false, false, true, true, EnumEucPublicPrivate.両方, new DaEucSpecialItem_基準日_和暦(condition)),

                //データソース設定項目
                new DaSpecialItemInfo(DaEucService.送付先利用目的, "", true, true, false, false, EnumEucPublicPrivate.両方, null),
                //自治体情報
                new DaSpecialItemInfo("公印", "2", false, false, true, true, EnumEucPublicPrivate.外部, new DaEucSpecialItem_公印(db, rptID, yosikiid)),

                new DaSpecialItemInfo("問い合わせ先", "2", false, false, true, true, EnumEucPublicPrivate.外部, new DaEucSpecialItem_問い合わせ先(db, rptID, yosikiid)),
                new DaSpecialItemInfo("課名", "2", false, false, true, true, EnumEucPublicPrivate.外部, new DaEucSpecialItem_課名(db, rptID, yosikiid)),
                new DaSpecialItemInfo("係名", "2", false, false, true, true, EnumEucPublicPrivate.外部, new DaEucSpecialItem_係名(db, rptID, yosikiid)),
                new DaSpecialItemInfo("代表者", "2", false, false, true, true, EnumEucPublicPrivate.外部, new DaEucSpecialItem_代表者(db, rptID, yosikiid)),
                new DaSpecialItemInfo("市町村コード", "2", false, false, true, true, EnumEucPublicPrivate.外部, new DaEucSpecialItem_市町村コード(db, rptID, yosikiid)),
                new DaSpecialItemInfo("自治体名", "2", false, false, true, true, EnumEucPublicPrivate.外部, new DaEucSpecialItem_自治体名(db, rptID, yosikiid)),
                new DaSpecialItemInfo("県名", "2", false, false, true, true, EnumEucPublicPrivate.外部, new DaEucSpecialItem_県名(db, rptID, yosikiid)),
                new DaSpecialItemInfo("市長", "2", false, false, true, true, EnumEucPublicPrivate.外部, new DaEucSpecialItem_市長(db, rptID, yosikiid)),
            };
        }

        /// <summary>
        /// 空白:all 1:一覧表 2:台帳 3:経年表 4:集計表 5:カスタマイズ	
        /// </summary>
        public List<string> GetNameList(bool isPageReport, bool isCross, EnumEucPublicPrivate publicPrivte, bool isDataSource)
        {
            //クロス集計以外を排除
            List<DaSpecialItemInfo> list = (!isCross) ? Items.Where(e => e.IsCross == false).ToList():Items;

            list = (isPageReport) ? list: list.Where(e => e.yosikisyubetu != "2").ToList();
            if (!isDataSource)
            {
                list = list.Where(e => isDataSource == false).ToList();
            }
            return list.Where(e=>e.IsMapping && (e.PublicPrivate & publicPrivte) == publicPrivte ).Select(e => e.Name).ToList();
        }

        /// <summary>
        /// 以上以外検索条件
        /// </summary>
        public List<string> GetConditionNameList(bool isDataSource)
        {
            if (isDataSource==false)
            {
                return new List<string>();
            }

            return Items.Where(e => e.IsCondition).Select(e=>e.Name).ToList();
        }

        public List<DaSearchConditionVM> GetConditionList(bool isDataSource)
        {
            return new List<DaSearchConditionVM>();
        }

        public Dictionary<string, IArSpecialItem?> GetSpecialItemDic()
        {
            var dic = new Dictionary<string, IArSpecialItem?>();
            foreach (var item in Items)
            {
                dic.Add(item.Name, item.ItemObject);
            }
            return dic;
        }

    }

    public class DaEucSpecialItemBase
    {
        protected ArConditionModel _condition;
        protected DaDbContext _db;
        protected string _rptID;
        protected string _yosikiid;
    }
    public class DaEucSpecialItem_帳票名 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_帳票名(DaDbContext db, string rptID)
        {
            _db = db;
            _rptID = rptID;
        }
        public object GetValue()
        {
            var rptSheet = _db.tm_eurpt.SELECT.WHERE.ByKey(_rptID).GetDto();
            return rptSheet.rptnm;
        }
    }
    public class DaEucSpecialItem_様式名 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_様式名(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            _rptID = rptID;
            _yosikiid = yosikiid;
        }
        public object GetValue()
        {
            var rptSheet = _db.tm_euyosikisyosai.SELECT.WHERE.ByKey(_rptID, _yosikiid).GetDto();
            return rptSheet.yosikinm;
        }
    }

    public class DaEucSpecialItem_出力日 : IArSpecialItem
    {
        public object GetValue()
        {
            return DaFormatUtil.FormatKjYMD(DateTime.Today);
        }
    }

    public class DaEucSpecialItem_出力日和暦 : IArSpecialItem
    {
        public object GetValue()
        {
            return DaFormatUtil.FormatWaKjYMD(DateTime.Today);
        }
    }
    public class DaEucSpecialItem_発行日 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_発行日(ArConditionModel condition)
        {
            _condition = condition;
        }

        /// <summary>
        /// 発行日コントロールから取得
        /// </summary>
        public object GetValue()
        {
            if (_condition != null && _condition.searchDic.TryGetValue(DaEucService.発行日, out var value) && DateTime.TryParse((string)value, out DateTime parsedDate))
            {
                return DaFormatUtil.FormatKjYMD(parsedDate);
            }
            return DaFormatUtil.FormatKjYMD(DateTime.Today);
        }
    }
    public class DaEucSpecialItem_発行日_和暦 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_発行日_和暦(ArConditionModel condition)
        {
            _condition = condition;
        }

        /// <summary>
        /// 発行日コントロールから取得
        /// </summary>
        public object GetValue()
        {
            if (_condition != null && _condition.searchDic.TryGetValue(DaEucService.発行日, out var value) && DateTime.TryParse((string)value, out DateTime parsedDate))
            {
                return DaFormatUtil.FormatWaKjYMD(parsedDate);
            }
            return DaFormatUtil.FormatWaKjYMD(DateTime.Today);
        }
    }
    public class DaEucSpecialItem_基準日 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_基準日(ArConditionModel condition)
        {
            _condition = condition;
        }

        /// <summary>
        /// 基準日コントロールから取得
        /// </summary>
        public object GetValue()
        {
            if (_condition != null && _condition.searchDic.TryGetValue(DaEucService.基準日, out var value) && DateTime.TryParse((string)value, out DateTime parsedDate))
            {
                return DaFormatUtil.FormatKjYMD(parsedDate);
            }
            return DaFormatUtil.FormatKjYMD(DateTime.Today);
        }
    }
    public class DaEucSpecialItem_基準日_和暦 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_基準日_和暦(ArConditionModel condition)
        {
            _condition = condition;
        }

        /// <summary>
        /// 基準日コントロールから取得
        /// </summary>
        public object GetValue()
        {
            if (_condition != null && _condition.searchDic.TryGetValue(DaEucService.基準日, out var value) && DateTime.TryParse((string)value, out DateTime parsedDate))
            {
                return DaFormatUtil.FormatWaKjYMD(parsedDate);
            }
            return DaFormatUtil.FormatWaKjYMD(DateTime.Today);
        }
    }

    public class 送付先利用目的 : DaEucSpecialItemBase, IArSpecialItem
    {
        public 送付先利用目的(ArConditionModel condition)
        {
            _condition = condition;
        }

        /// <summary>
        /// 送付先利用目的コントロールから取得
        /// </summary>
        public object GetValue()
        {
            if (_condition != null && _condition.searchDic.TryGetValue(DaEucService.送付先利用目的, out var value))
            {
                return DaSelectorService.GetName(_db, DaConvertUtil.CStr(value), Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "3019", "100005");
            }
            return "";
        }
    }

    public class DaEucSpecialItem_問い合わせ先 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_問い合わせ先(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            _rptID = rptID;
            _yosikiid = yosikiid;
        }
        public object GetValue()
        {
            var rptSheet = _db.tm_euyosiki.SELECT.WHERE.ByKey(_rptID, _yosikiid).GetDto();
            var cd = rptSheet.toiawasesakicd!;
            //return DaSelectorService.GetName(_db, cd, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "4");
            var dto = DaHanyoService.GetHanyoDto(_db, EnumHanyoKbn.問い合わせ内容コード, cd);
            return (dto != null) ? dto.hanyokbn1 ?? "" : "";

        }
    }
    public class DaEucSpecialItem_課名 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_課名(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            _rptID = rptID;
            _yosikiid = yosikiid;
        }
        public object GetValue()
        {
            var rptSheet = _db.tm_euyosiki.SELECT.WHERE.ByKey(_rptID, _yosikiid).GetDto();
            var cd = rptSheet.kacd!;
            //DaSelectorService.GetName(_db, cd, Enum名称区分., Enumマスタ区分.汎用マスタ, "1001", "2");
            var dto = DaHanyoService.GetHanyoDto(_db, EnumHanyoKbn.課, cd);
            return (dto != null) ? dto.hanyokbn1 ?? "" : "";
        }
    }

    public class DaEucSpecialItem_係名 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_係名(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            _rptID = rptID;
            _yosikiid = yosikiid;
        }
        public object GetValue()
        {
            var rptSheet = _db.tm_euyosiki.SELECT.WHERE.ByKey(_rptID, _yosikiid).GetDto();
            var cd = rptSheet.kakaricd!;
            //return DaSelectorService.GetName(_db, cd, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "3");
            var dto = DaHanyoService.GetHanyoDto(_db, EnumHanyoKbn.係, cd);
            return (dto != null) ? dto.hanyokbn1 ?? "" : "";

        }
    }

    public class DaEucSpecialItem_公印 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_公印(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            _rptID = rptID;
            _yosikiid = yosikiid;
        }

        public object GetValue()
        {
            var rptSheet = _db.tm_euyosiki.SELECT.WHERE.ByKey(_rptID, _yosikiid).GetDto();
            var dairi = rptSheet.dairisyaflg;
            var koin = _db.tm_eukoin.SELECT.WHERE.ByKey(0).GetDto();
            ArImageModel model = new ArImageModel();
            model.Width = 20;
            model.Height= 20;
            if (dairi)
            {
                var dto = DaHanyoService.GetHanyoDto(_db, EnumHanyoKbn.自治体情報, "6");
                if (string.IsNullOrEmpty(dto.hanyokbn1) || string.IsNullOrEmpty(dto.hanyokbn2))
                {
                    model.ImageData = koin.dairisyakoin;
                }
                DateTime dt1, dt2;
                if (DateTime.TryParse(dto.hanyokbn1, out dt1) == false || DateTime.TryParse(dto.hanyokbn2, out dt2) == false)
                {
                    model.ImageData = koin.dairisyakoin;
                }
                else if (dt1 <= DateTime.Today && DateTime.Today <= dt2)
                {
                    model.ImageData = koin.dairisyakoin;
                }
                else
                {
                    model.ImageData = koin.dairisyakoin;
                }
            }
            else
            {
                model.ImageData = koin.sikutyosontyokoin;
            }
            return model;
        }
    }
    public class DaEucSpecialItem_代表者 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_代表者(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            _rptID = rptID;
            _yosikiid = yosikiid;
        }
        public object GetValue()
        {
            var rptSheet = _db.tm_euyosiki.SELECT.WHERE.ByKey(_rptID, _yosikiid).GetDto();
            var dairi = rptSheet.dairisyaflg;
            var daihyosya= DaSelectorService.GetName(_db, "6", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1"); 
            if (dairi)
            {
                var dto = DaHanyoService.GetHanyoDto(_db, EnumHanyoKbn.自治体情報, "6");
                if (string.IsNullOrEmpty(dto.hanyokbn1) || string.IsNullOrEmpty(dto.hanyokbn2))
                {
                    return daihyosya;
                }
                DateTime dt1, dt2;
                if (DateTime.TryParse(dto.hanyokbn1, out dt1)==false || DateTime.TryParse(dto.hanyokbn2, out dt2)==false)
                {
                    return daihyosya;
                }
                else if (dt1<= DateTime.Today && DateTime.Today<=dt2)
                {
                    return DaSelectorService.GetName(_db, "7", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1");
                }
                else
                {
                    return daihyosya;
                }
            }
            else
            {
                return daihyosya;
            }
        }
    }
    public class DaEucSpecialItem_市町村コード : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_市町村コード(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            _rptID = rptID;
            _yosikiid = yosikiid;
        }
        public object GetValue()
        {
            return DaSelectorService.GetName(_db, "1", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1"); ;
        }
    }
    public class DaEucSpecialItem_自治体名 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_自治体名(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            _rptID = rptID;
            _yosikiid = yosikiid;
        }
        public object GetValue()
        {
            return DaSelectorService.GetName(_db, "2", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1"); ;
        }
    }
    public class DaEucSpecialItem_県名 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_県名(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            _rptID = rptID;
            _yosikiid = yosikiid;
        }
        public object GetValue()
        {
            return DaSelectorService.GetName(_db, "3", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1"); ;
        }
    }
    public class DaEucSpecialItem_市長 : DaEucSpecialItemBase, IArSpecialItem
    {
        public DaEucSpecialItem_市長(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            _rptID = rptID;
            _yosikiid = yosikiid;
        }
        public object GetValue()
        {

            var rptSheet = _db.tm_euyosiki.SELECT.WHERE.ByKey(_rptID, _yosikiid).GetDto();
            var dairi = rptSheet.dairisyaflg;
            var daihyosya = DaSelectorService.GetName(_db, "4", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1");
            if (dairi)
            {
                var dto = DaHanyoService.GetHanyoDto(_db, EnumHanyoKbn.自治体情報, "6");
                if (string.IsNullOrEmpty(dto.hanyokbn1) || string.IsNullOrEmpty(dto.hanyokbn2))
                {
                    return daihyosya;
                }
                DateTime dt1, dt2;
                if (DateTime.TryParse(dto.hanyokbn1, out dt1) == false || DateTime.TryParse(dto.hanyokbn2, out dt2) == false)
                {
                    return daihyosya;
                }
                else if (dt1 <= DateTime.Today && DateTime.Today <= dt2)
                {
                    return DaSelectorService.GetName(_db, "5", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1");
                }
                else
                {
                    return daihyosya;
                }
            }
            else
            {
                return daihyosya;
            }
        }
    }

}
