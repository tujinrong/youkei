// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 基準値共通関数
//
// 作成日　　: 2023.07.03
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaStrPool;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaCodeConst;
using BCC.Affect.Service.AWSH001;
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service
{
    public static class CmKijunUtil
    {
        /// <summary>
        /// 基準値マスタ(検診)
        /// </summary>
        /// <param name="db"></param>
        /// <param name="freeitemlist">フリー項目キーリスト</param>
        /// <param name="jissiymd1">実施日(一次)</param>
        /// <param name="jissiymd2">実施日(精密)</param>
        /// <param name="nendo">年度</param>
        /// <param name="sex">性別</param>
        /// <param name="dto">宛名データ</param>
        /// <param name="jigyocd">事業コード</param>
        /// <param name="ageSureFlg">年齢確定フラグ</param>
        /// <param name="sexSureFlg">性別確定フラグ</param>
        /// <returns></returns>
        public static List<tm_kkkijunDto> GetDtl(DaDbContext db, List<KjFreeItemVM> freeitemlist,
                                                DateTime? jissiymd1, DateTime? jissiymd2,
                                                string kensahohocd1,
                                                int nendo, Enum性別 sex,
                                                tt_afatenaDto dto, string jigyocd,
                                                bool ageSureFlg, bool sexSureFlg)
        {
            //基準値マスタ(結果格納用)
            var dtl = new List<tm_kkkijunDto>();

            //年度マスタの基準日
            var kijunymd = CmLogicUtil.GetNendoKijunymd(db, nendo, sex, jigyocd, kensahohocd1);

            //基準値マスタのキー
            var keys = new string[] { nameof(tm_kkkijunDto.gyomukbn), nameof(tm_kkkijunDto.kijunjigyocd), nameof(tm_kkkijunDto.itemcd) };
            var keyList = new List<object[]>();
            //基準値の有効日
            var kijunymdList = new List<string[]>();
            foreach (var item in freeitemlist)
            {
                keyList.Add(new object[] { 名称マスタ.システム.基準値業務区分._01, jigyocd, item.itemcd });
                kijunymdList.Add(new string[] { item.itemcd, string.IsNullOrEmpty(kijunymd) ? FormatYMD(item.groupid == EnumKensinKbn.一次 ? jissiymd1 : jissiymd2) : kijunymd });
            }

            //基準値マスタデータ取得
            var tm_kkkijunDtl = db.tm_kkkijun.SELECT.WHERE.ByItemList(keys, keyList).GetDtoList();

            foreach (var day in kijunymdList)
            {
                //有効期間内データを抽出
                var list = tm_kkkijunDtl.Where(x => (x.itemcd == day[0]) &&
                                                        (string.Compare(day[1], x.yukoymdf) >= 0) &&
                                                        (string.Compare(day[1], x.yukoymdt) <= 0)).ToList();
                //性別で基準値を絞る
                if (sexSureFlg)
                {
                    list = list.Where(x => (x.sex == EnumSex.Empty) || ((int)x.sex == CInt(dto.sex))).ToList();
                }
                //年齢で基準値を絞る
                if (ageSureFlg)
                {
                    //実施日が基準日の場合
                    var age = DaUtil.GetAge(CDate(dto.bymd), CDate(day[1]));
                    //年度マスタ基準日が基準日の場合
                    if (!string.IsNullOrEmpty(kijunymd)) age = DaUtil.GetAge(CDate(dto.bymd), CDate(kijunymd));
                    list = list.Where(x => (x.agef == null || (x.agef <= age)) &&
                                           (x.aget == null || (x.aget >= age))).ToList();
                }

                dtl.AddRange(list);
            }
            return dtl;
        }

        /// <summary>
        /// 項目基準値(検診)
        /// </summary>
        public static KjItemVM GetVM(KjFreeItemVM item, List<tm_kkkijunDto> kijunDtl, bool ageSureFlg, bool sexSureFlg, Enum性別 sex)
        {
            var vm = new KjItemVM();
            vm.itemcd = item.itemcd;    //項目コード
            //基準値取得
            var filteredDtl = kijunDtl.Where(x => x.itemcd == item.itemcd).OrderBy(x => x.sex).ThenBy(x => x.agef).ThenBy(x => x.edano).ToList();

            if (filteredDtl.Any())
            {
                vm = SetValue(filteredDtl, vm, ageSureFlg, sexSureFlg, sex);    //値表記と基準値リスト
            }

            return vm;
        }

        /// <summary>
        /// 値表記とチェック範囲を取得
        /// </summary>
        private static KjItemVM SetValue(IReadOnlyList<tm_kkkijunDto> filteredDtl, KjItemVM vm, bool ageSureFlg, bool sexSureFlg, Enum性別 sex)
        {
            List<List<string>> list = new List<List<string>>();

            for (var index = (int)Enum基準値範囲.正常値範囲; index <= (int)Enum基準値範囲.異常値範囲; index++)
            {
                var itemList = new List<KModel>();
                //範囲整理
                foreach (var dto in filteredDtl)
                {
                    var model = new KModel(dto, index, ageSureFlg, sexSureFlg);
                    var key = model.Key();
                    if (itemList.Exists(e => e.Key() == key))
                    {
                        var item = itemList.Find(e => e.Key() == key)!;
                        item.values.AddRange(model.values);
                    }
                    else
                    {
                        itemList.Add(model);
                    }
                }
                var lst = new List<string>();
                foreach (var item in itemList)
                {
                    //行表記
                    NzStrList(item.ToString(), lst);
                }
                list.Add(lst);
                if (itemList.Count == 1 && GetCheckFlg(itemList[0], sex) && index == (int)Enum基準値範囲.正常値範囲)
                {
                    vm.kijunlist = filteredDtl.Select(GetVM).ToList();  //基準値リスト
                }
            }
            vm.kijunvaluehyoki = string.Join(C_LF, list[(int)Enum基準値範囲.正常値範囲]);   //基準値表記
            vm.alertvaluehyoki = string.Join(C_LF, list[(int)Enum基準値範囲.注意値範囲]);   //注意値表記
            vm.errvaluehyoki = string.Join(C_LF, list[(int)Enum基準値範囲.異常値範囲]);     //異常値表記

            return vm;
        }

        /// <summary>
        /// 基準値モデル
        /// </summary>
        private class KModel
        {
            public bool ageSureFlg;             //年齢確定フラグ
            public bool sexSureFlg;             //性別確定フラグ
            public int? AgeFrom { get; set; }   //年齢（開始）
            public int? AgeTo { get; set; }     //年齢（終了）
            public EnumSex Sex { get; set; }    //性別
            //年齢性別確定の場合、複数正常値範囲も可能
            public List<string> values { get; set; } = new List<string>();

            public KModel(tm_kkkijunDto dto, int index, bool flg1, bool flg2)
            {
                AgeFrom = dto.agef;
                AgeTo = dto.aget;
                Sex = dto.sex;
                ageSureFlg = flg1;
                sexSureFlg = flg2;
                switch (index)
                {
                    case (int)Enum基準値範囲.正常値範囲:
                        NzStrList(dto.kijunvaluehyoki, values);
                        break;
                    case (int)Enum基準値範囲.注意値範囲:
                        NzStrList(dto.alertvaluehyoki, values);
                        break;
                    case (int)Enum基準値範囲.異常値範囲:
                        NzStrList(dto.errvaluehyoki, values);
                        break;
                    default:
                        throw new Exception("Enum基準値範囲 error");
                }
            }
            //タイトル表記
            public string Key()
            {
                var k = string.Empty;
                //性別表記
                var t1 = GetSexTitle(Sex);
                //年齢表記
                var t2 = GetAgeTitle(AgeFrom, AgeTo);

                //年齢別で表示する場合
                if (!ageSureFlg && sexSureFlg)
                {
                    k = t2;
                }
                //性別別で表示する場合
                else if (ageSureFlg && !sexSureFlg)
                {
                    k = t1;
                }
                //性別(年齢)別で表示する場合
                else if (!ageSureFlg && !sexSureFlg)
                {
                    if (!string.IsNullOrEmpty(t1) && !string.IsNullOrEmpty(t2))
                    {
                        k = $"{t1}{C_LEFT_BRACKET_FULL}{t2}{C_RIGHT_BRACKET_FULL}";
                    }
                    else if (!string.IsNullOrEmpty(t1))
                    {
                        k = t1;
                    }
                    else if (!string.IsNullOrEmpty(t2))
                    {
                        k = t2;
                    }
                }

                return k;
            }
            //基準値範囲表記
            public override string ToString()
            {
                var t = string.Empty;
                if (!string.IsNullOrEmpty(Key())) t = $"{Key()}{C_COLON_FULL}";

                if (values.Count != 0)
                {
                    //年齢性別確定でも複数正常値範囲の場合、「、」で連結
                    return $"{t}{string.Join(C_COMMA2, values)}";
                }
                else
                {
                    //値空白の場合
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// 年齢表記取得
        /// </summary>
        private static string GetAgeTitle(int? agef, int? aget)
        {
            var t = string.Empty;
            //年齢分けなし、正常値範囲複数の場合
            if (agef == null && aget == null) return t;
            //上記以外の場合、年齢範囲で連結
            if (agef != null) t = $"{agef}歳";
            if (aget != null)
            {
                if (string.IsNullOrEmpty(t))
                {
                    t = $"{aget}歳以下";
                }
                else
                {
                    t = $"{t}{C_TILDE_FULL}{aget}歳";
                }
            }
            else
            {
                t = $"{t}以上";
            }

            return t;
        }

        /// <summary>
        /// 性別表記取得
        /// </summary>
        private static string GetSexTitle(EnumSex sex)
        {
            var t = string.Empty;
            if (sex != EnumSex.Empty)
            {
                t = $"{sex}性";
            }
            return t;
        }

        /// <summary>
        /// 基準値マスタ
        /// </summary>
        private static KijunVM GetVM(tm_kkkijunDto dto)
        {
            var vm = new KijunVM();
            vm.errvalue1t = dto.errvalue1t;           //異常値（数値）以下
            vm.alertvalue1f = dto.alertvalue1f;       //注意値（数値）開始
            vm.alertvalue1t = dto.alertvalue1t;       //注意値（数値）終了
            vm.kijunvaluef = dto.kijunvaluef;         //基準値（数値）開始
            vm.kijunvaluet = dto.kijunvaluet;         //基準値（数値）終了
            vm.alertvalue2f = dto.alertvalue2f;       //注意値（数値）開始
            vm.alertvalue2t = dto.alertvalue2t;       //注意値（数値）終了
            vm.errvalue2f = dto.errvalue2f;           //異常値（数値）以上
            vm.hanteicd = dto.hanteicd;               //基準値（コード）
            vm.alerthanteicd = dto.alerthanteicd;     //注意値（コード）
            vm.errhanteicd = dto.errhanteicd;         //異常値（コード）
            return vm;
        }

        /// <summary>
        /// 基準値範囲チェックフラグ取得：チェックするかどうか
        /// </summary>
        private static bool GetCheckFlg(KModel km, Enum性別 sex)
        {
            //年齢不明の場合
            if (!km.ageSureFlg)
            {
                //基準値マスタ絞り1件けど、年齢範囲がある場合、チェック不要
                if (km.AgeFrom != null || km.AgeTo != null)
                { return false; }
            }
            //性別不明の場合
            if (!km.sexSureFlg)
            {
                //基準値マスタ絞り1件けど、性別指定がある場合、チェック不要
                if (km.Sex != EnumSex.Empty)
                { return false; }
            }
            //性別確定の場合
            else
            {
                //基準値マスタ絞り1件けど、性別指定で患者の性別と異なる場合、チェック不要
                if ((km.Sex != EnumSex.Empty) && ((int)km.Sex != (int)sex))
                { return false; }
            }
            return true;
        }
    }
}