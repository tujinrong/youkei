// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ドロップダウンリスト
//
// 作成日　　: 2023.03.14
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using Microsoft.Extensions.Caching.Memory;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.DataAccess
{
    public static class DaSelectorService
    {
        private static MemoryCache _cache;
        const int CACHE_MINIUTE = 5;

        public static void ClearCache()
        {
            _cache?.Clear();
            DaNameService.ClearCache();
            DaControlService.ClearCache();

        }

        /// <summary>
        /// ドロップダウンリスト取得
        /// </summary>
        /// <param name="db"></param>
        /// <param name="kbn1">名称区分：表示用</param>
        /// <param name="kbn2">マスタ区分</param>
        /// <param name="keys">
        /// 1.名称マスタ：①EnumNmKbn　②maincd,subcd
        /// 2.汎用マスタ：①keycd(maincd-subcd)　②maincd,subcd
        /// 3.医療機関マスタ：実施事業コード
        /// </param>
        /// <returns></returns>
        public static List<DaSelectorModel> GetSelectorList(DaDbContext db, Enum名称区分 kbn1, Enumマスタ区分 kbn2, bool hasStopFlg = false, params string[] keys)
        {
            //キャッシュ初期化
            if (_cache == null)
            {
                _cache = new MemoryCache(new MemoryCacheOptions());
            }

            switch (kbn2)
            {
                case Enumマスタ区分.名称マスタ:
                    {
                        string maincd;
                        string subcd;
                        if (keys.Length == 1)
                        {
                            maincd = (CLng(keys[0]) / DaNameService.MAINCODE_DIGIT).ToString();
                            subcd = (CLng(keys[0]) % DaNameService.MAINCODE_DIGIT).ToString();
                        }
                        else if (keys.Length == 2)
                        {
                            maincd = keys[0];
                            subcd = keys[1];
                        }
                        else
                        {
                            throw new Exception("params count error");
                        }
                        var key = $"{kbn2}{kbn1}{maincd}{subcd}";
                        string name;
                        switch (kbn1)
                        {
                            case Enum名称区分.名称: name = nameof(tm_afmeisyoDto.nm); break;
                            case Enum名称区分.カナ: name = nameof(tm_afmeisyoDto.kananm); break;
                            case Enum名称区分.略称: name = nameof(tm_afmeisyoDto.shortnm); break;
                            default: throw new ArgumentException();
                        };
                        string sql = GetSelectSQL(tm_afmeisyoDto.TABLE_NAME,
                                                nameof(tm_afmeisyoDto.nmcd),
                                                name,
                                                $"{nameof(tm_afmeisyoDto.nmmaincd)}='{maincd}' and {nameof(tm_afmeisyoDto.nmsubcd)}={subcd}");
                        return GetSelectList(db, key, sql);
                    }

                case Enumマスタ区分.汎用マスタ:
                    {
                        string maincd;
                        string subcd;
                        if (keys.Length == 1)
                        {
                            maincd = (CLng(keys[0]) / DaNameService.MAINCODE_DIGIT).ToString();
                            subcd = (CLng(keys[0]) % DaNameService.MAINCODE_DIGIT).ToString();
                        }
                        else if (keys.Length == 2)
                        {
                            maincd = keys[0];
                            subcd = keys[1];
                        }
                        else
                        {
                            throw new Exception("params count error");
                        }
                        var key = $"{hasStopFlg}{kbn2}{kbn1}{maincd}{subcd}";
                        string name;
                        switch (kbn1)
                        {
                            case Enum名称区分.名称: name = nameof(tm_afhanyoDto.nm); break;
                            case Enum名称区分.カナ: name = nameof(tm_afhanyoDto.kananm); break;
                            case Enum名称区分.略称: name = nameof(tm_afhanyoDto.shortnm); break;
                            default: throw new ArgumentException();
                        };
                        var where = @$"{nameof(tm_afhanyoDto.hanyomaincd)}='{maincd}' and 
                                                    {nameof(tm_afhanyoDto.hanyosubcd)}='{subcd}'
                                                    {GetStopFlgWhereSql(hasStopFlg, nameof(tm_afhanyoDto.stopflg))}";

                        var order = @$" {nameof(tm_afhanyoDto.orderseq)} , {nameof(tm_afhanyoDto.hanyocd)}";

                        string sql = GetSelectSQL(tm_afhanyoDto.TABLE_NAME,
                                                nameof(tm_afhanyoDto.hanyocd),
                                                name,
                                                where, order);
                        //NoCache
                        //return GetSelectList(db, key, sql);
                        return db.Session.Query<DaSelectorModel>(sql);
                    }

                case Enumマスタ区分.医療機関マスタ:
                case Enumマスタ区分.医療機関マスタ_保険:
                    {
                        var keyvalue = (keys.Length == 1) ? keys[0] : string.Empty;
                        var kikancd = (kbn2 == Enumマスタ区分.医療機関マスタ) ? nameof(tm_afkikanDto.kikancd) : nameof(tm_afkikanDto.hokenkikancd);

                        var key = $"{hasStopFlg}{kbn2}{kbn1}{keyvalue}";
                        var name = (kbn1 == Enum名称区分.カナ) ? nameof(tm_afkikanDto.kanakikannm) : nameof(tm_afkikanDto.kikannm);
                        string sql;
                        if (keyvalue == string.Empty)
                        {
                            sql = @$"select {kikancd} {nameof(DaSelectorModel.value)}, 
                                            {name} {nameof(DaSelectorModel.label)} 
                                        from {tm_afkikanDto.TABLE_NAME}
                                        where 1 = 1 {GetStopFlgWhereSql(hasStopFlg, nameof(tm_afkikanDto.stopflg))}
                                        order by {kikancd}";
                        }
                        else
                        {
                            sql = @$"select distinct t1.{kikancd} {nameof(DaSelectorModel.value)}, 
                                            {name} {nameof(DaSelectorModel.label)} 
                                        from {tm_afkikanDto.TABLE_NAME} t1 inner join {tm_afkikan_subDto.TABLE_NAME} t2 on t1.kikancd = t2.kikancd
                                        where t2.jissijigyo = any(string_to_array('{keyvalue}', ','))
                                        {GetStopFlgWhereSql(hasStopFlg, nameof(tm_afkikanDto.stopflg), "t1")}
                                        order by t1.{kikancd}";
                        }
                        return GetSelectList(db, key, sql);
                    }

                case Enumマスタ区分.ユーザーマスタ:
                    {
                        var keyvalue = (keys.Length == 1) ? keys[0] : string.Empty;
                        var key = $"{hasStopFlg}{kbn2}{keyvalue}";
                        var where = (keyvalue == string.Empty) ? "1 = 1" : $"{nameof(tm_afuserDto.syozokucd)}='{keyvalue}'";
                        where = $"{where}{GetStopFlgWhereSql(hasStopFlg, nameof(tm_afuserDto.stopflg))}";
                        string sql = GetSelectSQL(tm_afuserDto.TABLE_NAME,
                                                nameof(tm_afuserDto.userid),
                                                nameof(tm_afuserDto.usernm),
                                                where);
                        return GetSelectList(db, key, sql);
                    }

                case Enumマスタ区分.所属グループマスタ:
                    {
                        string key = $"{hasStopFlg}{kbn2}";
                        var where = $"1 = 1{GetStopFlgWhereSql(hasStopFlg, nameof(tm_afsyozokuDto.stopflg))}";
                        string sql = GetSelectSQL(tm_afsyozokuDto.TABLE_NAME,
                                                nameof(tm_afsyozokuDto.syozokucd),
                                                nameof(tm_afsyozokuDto.syozokunm),
                                                where);
                        return GetSelectList(db, key, sql);
                    }

                case Enumマスタ区分.市区町村マスタ:
                    {
                        string key = $"{kbn2}{kbn1}";
                        string sql = GetSelectSQL(tm_afsikutyosonDto.TABLE_NAME,
                                                nameof(tm_afsikutyosonDto.sikucd),
                                                (kbn1 == Enum名称区分.カナ) ? nameof(tm_afsikutyosonDto.sikunm_kana) : nameof(tm_afsikutyosonDto.sikunm)
                                                );
                        return GetSelectList(db, key, sql);
                    }

                case Enumマスタ区分.地区情報マスタ:
                    {
                        var keyvalue = (keys.Length == 1) ? keys[0] : string.Empty;
                        string key = $"{hasStopFlg}{kbn2}{kbn1}{keyvalue}";
                        var where = (keyvalue == string.Empty) ? "1 = 1" : $"{nameof(tm_aftikuDto.tikukbn)}='{keyvalue}'";
                        where = $"{where}{GetStopFlgWhereSql(hasStopFlg, nameof(tm_aftikuDto.stopflg))}";
                        string sql = GetSelectSQL(tm_aftikuDto.TABLE_NAME,
                                                nameof(tm_aftikuDto.tikucd),
                                                (kbn1 == Enum名称区分.カナ) ? nameof(tm_aftikuDto.kanatikunm) : nameof(tm_aftikuDto.tikunm),
                                                where);
                        return GetSelectList(db, key, sql);
                    }

                case Enumマスタ区分.会場情報マスタ:
                    {
                        string key = $"{hasStopFlg}{kbn2}{kbn1}";
                        var where = $"1 = 1{GetStopFlgWhereSql(hasStopFlg, nameof(tm_afkaijoDto.stopflg))}";
                        string sql = GetSelectSQL(tm_afkaijoDto.TABLE_NAME,
                                                nameof(tm_afkaijoDto.kaijocd),
                                                (kbn1 == Enum名称区分.カナ) ? nameof(tm_afkaijoDto.kanakaijonm) : nameof(tm_afkaijoDto.kaijonm),
                                                where);
                        return GetSelectList(db, key, sql);
                    }
                case Enumマスタ区分.事業従事者担当者情報マスタ:
                    {
                        //事業コード一覧
                        var keyvalue = (keys.Length == 1) ? keys[0] : string.Empty;
                        string key = $"{hasStopFlg}{kbn2}{kbn1}";
                        var name = (kbn1 == Enum名称区分.カナ) ? nameof(tm_afstaffDto.kanastaffsimei) : nameof(tm_afstaffDto.staffsimei);
                        var where = $"1 = 1{GetStopFlgWhereSql(hasStopFlg, nameof(tm_afstaffDto.stopflg))}";
                        string sql = GetSelectSQL(tm_afstaffDto.TABLE_NAME,
                                                nameof(tm_afstaffDto.staffid),
                                                name,
                                                where);
                        if (!string.IsNullOrEmpty(keyvalue))
                        {
                            sql = @$"select distinct t1.staffid {nameof(DaSelectorModel.value)}, 
                                            {name} {nameof(DaSelectorModel.label)} 
                                        from {tm_afstaffDto.TABLE_NAME} t1 inner join {tm_afstaff_subDto.TABLE_NAME} t2 on t1.staffid = t2.staffid
                                        where t2.jissijigyo = any(string_to_array('{keyvalue}', ','))
                                        {GetStopFlgWhereSql(hasStopFlg, nameof(tm_afstaffDto.stopflg), "t1")}
                                        order by t1.staffid";
                        }
                        return GetSelectList(db, key, sql);
                    }

                //todo
                default:
                    throw new Exception("Enumマスタ区分 error");
            }
        }

        public static List<DaSelectorModel> GetSelectorList(DaDbContext db, Enum名称区分 kbn1, Enumシステムマスタ区分 kbn2, params string[] keys)
        {
            //キャッシュ初期化
            if (_cache == null)
            {
                _cache = new MemoryCache(new MemoryCacheOptions());
            }
            switch (kbn2)
            {
                case Enumシステムマスタ区分.名称メインマスタ:
                    {
                        var keyvalue = (keys.Length == 1) ? keys[0] : throw new ArgumentException();
                        string key = $"{kbn2}{keyvalue}";
                        string name;
                        switch (kbn1)
                        {
                            case Enum名称区分.名称: name = nameof(tm_afmeisyo_mainDto.nmsubcdnm); break;
                            case Enum名称区分.カナ: name = nameof(tm_afmeisyo_mainDto.kananm); break;
                            case Enum名称区分.略称: name = nameof(tm_afmeisyo_mainDto.shortnm); break;
                            default: throw new ArgumentException();
                        };
                        var sql = @$"select cast(nmsubcd as varchar) {nameof(DaSelectorModel.value)}, 
                                        {name} {nameof(DaSelectorModel.label)} 
                                 from {tm_afmeisyo_mainDto.TABLE_NAME}
                                 where nmmaincd='{keyvalue}'
                                 order by nmsubcd";

                        return GetSelectList(db, key, sql);
                    }
                case Enumシステムマスタ区分.汎用メインマスタ:
                    {
                        var keyvalue = (keys.Length == 1) ? keys[0] : throw new ArgumentException();
                        string key = $"{kbn2}{keyvalue}";
                        string name;
                        switch (kbn1)
                        {
                            case Enum名称区分.名称: name = nameof(tm_afhanyo_mainDto.hanyosubcdnm); break;
                            case Enum名称区分.カナ: name = nameof(tm_afhanyo_mainDto.kananm); break;
                            case Enum名称区分.略称: name = nameof(tm_afhanyo_mainDto.shortnm); break;
                            default: throw new ArgumentException();
                        };
                        var sql = @$"select cast(hanyosubcd as varchar) {nameof(DaSelectorModel.value)}, 
                                        {name} {nameof(DaSelectorModel.label)} 
                                 from {tm_afhanyo_mainDto.TABLE_NAME}
                                 where hanyomaincd='{keyvalue}'
                                 order by hanyosubcd";
                        return GetSelectList(db, key, sql);
                    }

                case Enumシステムマスタ区分.EUCテーブルマスタ:
                    {
                        string key = $"{kbn2}";
                        string sql = GetSelectSQL(tm_eutableDto.TABLE_NAME,
                                                nameof(tm_eutableDto.tablenm),
                                                nameof(tm_eutableDto.tablehyojinm),
                                                $"", nameof(tm_eutableDto.orderseq));
                        return GetSelectList(db, key, sql);
                    }

                case Enumシステムマスタ区分.機能マスタ:
                    {
                        string key = $"{kbn2}";
                        string sql = GetSelectSQL(tm_afkinoDto.TABLE_NAME,
                                                nameof(tm_afkinoDto.kinoid),
                                                nameof(tm_afkinoDto.hyojinm),
                                                $"", nameof(tm_afkinoDto.kinoid));
                        return GetSelectList(db, key, sql);
                    }

                case Enumシステムマスタ区分.タスクスケジュール情報マスタ:
                    {
                        string key = $"{kbn2}{kbn1}";

                        string sql = GetSelectSQL(tm_aftaskscheduleDto.TABLE_NAME,
                                                nameof(tm_aftaskscheduleDto.taskid),
                                                nameof(tm_aftaskscheduleDto.tasknm)
                                                );
                        return GetSelectList(db, key, sql);
                    }

                case Enumシステムマスタ区分.EUC帳票マスタ:
                    {
                        string key = $"{kbn2}{kbn1}";

                        string sql = GetSelectSQL(tm_eurptDto.TABLE_NAME,
                                                nameof(tm_eurptDto.rptid),
                                                nameof(tm_eurptDto.rptnm)
                                                );
                        return GetSelectList(db, key, sql);
                    }

                case Enumシステムマスタ区分.EUC様式詳細マスタ:
                    {
                        string key = $"{kbn2}{kbn1}";

                        string sql = GetSelectSQL(tm_euyosikisyosaiDto.TABLE_NAME,
                                                nameof(tm_euyosikisyosaiDto.yosikiid),
                                                nameof(tm_euyosikisyosaiDto.yosikinm)
                                                );
                        return GetSelectList(db, key, sql);
                    }

                case Enumシステムマスタ区分.帳票発行抽出対象マスタ:
                    {
                        string key = $"{kbn2}{kbn1}";

                        string sql = GetSelectSQL(tm_afrpthakkotyusyututaisyoDto.TABLE_NAME,
                                                nameof(tm_afrpthakkotyusyututaisyoDto.taisyocd),
                                                nameof(tm_afrpthakkotyusyututaisyoDto.taisyonm)
                                                );
                        return GetSelectList(db, key, sql);
                    }
                //todo
                default:
                    throw new Exception("Enumマスタ区分 error");
            }
        }

        /// <summary>
        /// 表記取得(コード：名称)
        /// </summary>
        public static string GetCdNm(DaDbContext db, string code, Enum名称区分 kbn1, Enumマスタ区分 kbn2, params string[] keys)
        {
            if (string.IsNullOrEmpty(code))
            {
                return string.Empty;
            }

            return GetCodeName(db, code, kbn1, kbn2, keys);
        }

        /// <summary>
        /// 表記取得(コード：名称)
        /// </summary>
        public static string GetCdNm(List<DaSelectorModel> list, string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return string.Empty;
            }
            var name = list.Find(e => e.value == code);
            if (name == null) return $"{code}{DaConst.SELECTOR_DELIMITER}";
            return $"{code}{DaConst.SELECTOR_DELIMITER}{name.label}";
        }

        public static string GetName(DaDbContext db, string code, Enum名称区分 kbn1, Enumマスタ区分 kbn2, params string[] keys)
        {
            if (string.IsNullOrEmpty(code))
            {
                return string.Empty;
            }

            var list = GetSelectorList(db, kbn1, kbn2, true, keys);
            return GetName(list, code);
        }

        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetName(List<DaSelectorModel> list, string code)
        {
            var row = list.Find(e => e.value == code);
            return (row == null) ? string.Empty : row.label;
        }

        /// <summary>
        /// コード取得
        /// </summary>
        public static string GetCd(string? CdNm)
        {
            return string.IsNullOrEmpty(CdNm) ? string.Empty : CdNm.Split(DaConst.SELECTOR_DELIMITER)[0];
        }

        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetName(string CdNm)
        {
            if (string.IsNullOrEmpty(CdNm))
            {
                return string.Empty;
            }
            return CdNm.Split(DaConst.SELECTOR_DELIMITER)[1];
        }

        /// <summary>
        /// コード：名称の取得
        /// </summary>
        private static string GetCodeName(DaDbContext db, string cd, Enum名称区分 kbn1, Enumマスタ区分 kbn2, params string[] keys)
        {
            var list = GetSelectorList(db, kbn1, kbn2, true, keys);
            return GetCdNm(list, cd);
        }

        /// <summary>
        /// SQLの組み込み
        /// </summary>
        private static string GetSelectSQL(string table, string cd, string name, string where = "", string orderby = "")
        {
            string order = string.IsNullOrEmpty(orderby) ? cd : orderby;
            if (string.IsNullOrEmpty(where))
            {
                return $"select {cd} {nameof(DaSelectorModel.value)}, {name} {nameof(DaSelectorModel.label)} from {table} order by {order}";
            }
            else
            {
                return $"select {cd} {nameof(DaSelectorModel.value)}, {name} {nameof(DaSelectorModel.label)} from {table} where {where} order by {order}";
            }
        }

        /// <summary>
        /// キャッシュ化一覧の取得
        /// </summary>
        private static List<DaSelectorModel> GetSelectList(DaDbContext db, string key, string sql)
        {
            List<DaSelectorModel> data;
            if (!_cache.TryGetValue(key, out data!))
            {
                data = db.Session.Query<DaSelectorModel>(sql);
                _cache.Set(key, data, TimeSpan.FromMinutes(CACHE_MINIUTE));
            }
            return data;
        }
        /// <summary>
        /// 使用停止sql
        /// </summary>
        private static string GetStopFlgWhereSql(bool hasStopFlg, string flgNm, string? tbId = null)
        {
            var where = string.Empty;
            if (!hasStopFlg)
            {
                var tbIdSql = string.IsNullOrEmpty(tbId) ? string.Empty : $"{tbId}.";
                where = $" and {tbIdSql}{flgNm} = false";
            }
            return where;
        }
    }
}