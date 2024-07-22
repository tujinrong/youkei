// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 住登外者管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.11.09
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaStrPool;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Where;

namespace BCC.Affect.Service.AWKK00111G
{
    public class Converter : CmConerterBase
    {
        private const string STOP = "2";                                    //使用停止
        private const bool SAISIN = true;                                   //最新
        private const string ADRS1 = "1";                                   //住所１
        private const string ADRS2 = "2";                                   //住所２
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";        //日時フォーマット（一時利用）
        private const string C_SPACE_FULL = "　";                           //全角スペース（一時利用、後でDaStrPool.csで追加したら削除する予定）

        /// <summary>
        /// 住登外者情報テーブル
        /// </summary>
        public static tt_afjutogaiDto GetDto(tt_afjutogaiDto dto, MainInfoVM vm, string sexhyoki)
        {
            dto.atenano = vm.atenano;                                       //宛名番号		
            dto.rirekino = CInt(vm.rirekino);                               //履歴番号		
            dto.setaino = vm.setaino;                                       //世帯番号		
            dto.jutogaisyasyubetu = CStr(GetCd(vm.jutogaisyasyubetu));      //住登外者種別		
            dto.jutogaisyajotai = CStr(GetCd(vm.jutogaisyajotai));          //住登外者状態		
            dto.idoymd = CStr(vm.idoymd);                                   //異動年月日		
            dto.idotodokeymd = vm.idotodokeymd;                             //異動届出年月日	
            dto.idojiyu = GetCd(vm.idojiyu);                                //異動事由（コードのみ）
            dto.simei = GetSimei(vm);                                       //氏名			
            dto.si = vm.si;                                                 //氏_日本人		
            dto.mei = vm.mei;                                               //名_日本人		
            dto.simei_gairoma = vm.simei_gairoma;                           //氏名_外国人ローマ字	
            dto.simei_gaikanji = vm.simei_gaikanji;                         //氏名_外国人漢字	
            dto.simei_kana = GetSimeiKana(vm);                              //氏名_フリガナ	
            dto.simei_kana_seion = ToNSeionKana(dto.simei_kana);            //氏名_フリガナ_清音化
            dto.si_kana = ToNKana(vm.si_kana);                              //氏_日本人_フリガナ	
            dto.si_kana_seion = ToNSeionKana(vm.si_kana);                   //氏_日本人_フリガナ_清音化
            dto.mei_kana = ToNKana(vm.mei_kana);                            //名_日本人_フリガナ	
            dto.mei_kana_seion = ToNSeionKana(vm.mei_kana);                 //名_日本人_フリガナ_清音化
            dto.tusyo = vm.tusyo;                                           //通称			
            dto.tusyo_kana = ToNKana(vm.tusyo_kana);                        //通称_フリガナ	
            dto.tusyo_kana_seion = ToNSeionKana(vm.tusyo_kana);             //通称_フリガナ_清音化
            dto.tusyo_kanastatus = vm.tusyo_kanastatus;                     //通称_フリガナ確認状況
            dto.simei_yusen = CStr(GetSimeiYusen(vm, Enum名称区分.名称));   //氏名_優先		
            dto.simei_kana_yusen = GetSimeiYusen(vm, Enum名称区分.カナ);    //氏名_フリガナ_優先	
            dto.simei_kana_yusen_seion = ToNSeionKana(dto.simei_kana_yusen);//氏名_フリガナ_優先_清音化	
            dto.sex = GetCd(vm.sex);                                        //性別（コードのみ）		
            dto.sexhyoki = sexhyoki;                                        //性別表記		
            dto.bymd = vm.bymd;                                             //生年月日		
            dto.bymd_fusyoflg = vm.bymd_fusyoflg;                           //生年月日_不詳フラグ	
            dto.bymd_fusyohyoki = vm.bymd_fusyohyoki;                       //生年月日_不詳表記	
            dto.adrs_sikucd = vm.adrs_sikucd;                               //住所_市区町村コード	
            dto.adrs_tyoazacd = vm.adrs_tyoazacd;                           //住所_町字コード	
            dto.tosi_gyoseikucd = GetCd(vm.tosi_gyoseikucd); //指定都市_行政区等コード（コードのみ）
            dto.adrs_todofuken = vm.adrs_todofuken;                         //住所_都道府県	
            dto.adrs_sikunm = vm.adrs_sikunm;                               //住所_市区郡町村名	
            dto.adrs_tyoaza = vm.adrs_tyoaza;                               //住所_町字		
            dto.adrs_bantihyoki = vm.adrs_bantihyoki;                       //住所_番地号表記	
            dto.adrs_katagaki = vm.adrs_katagaki;                           //住所_方書		
            dto.adrs_katagaki_kana = ToNKana(vm.adrs_katagaki_kana);        //住所_方書_フリガナ	
            dto.adrs_yubin = vm.adrs_yubin;                                 //住所_郵便番号	
            dto.adrs_kokunmcd = vm.adrs_kokunmcd;                           //住所_国名コード	
            dto.adrs_kokunm = vm.adrs_kokunm;                               //住所_国名等		
            dto.adrs_gaiadrs = vm.adrs_gaiadrs;                             //住所_国外住所	
            dto.hokenkbn = GetCd(vm.hokenkbn);                              //保険区分（コードのみ）		
            dto.nayosemotoflg = CStr(GetCd(vm.nayosemotoflg));              //名寄せ元フラグ（コードのみ）	
            dto.nayosesakiatenano = vm.nayosesakiatenano;                   //名寄せ先宛名番号	
            dto.togoatenaflg = CStr(GetCd(vm.togoatenaflg));                //統合宛名フラグ（コードのみ）	
            dto.sansyofukaflg = CStr(GetCd(vm.sansyofuka));                 //他業務参照不可フラグ（コードのみ）	
            dto.stopflg = false;                                            //使用停止フラグ	
            dto.saisinflg = true;                                           //最新フラグ		
            dto.regbusyocd = CStr(GetCd(vm.regbusyocd));                    //登録部署（コードのみ）		

            return dto;
        }

        /// <summary>
        /// 宛名テーブル
        /// </summary>
        public static tt_afatenaDto GetDto(tt_afatenaDto dto, MainInfoVM vm)
        {
            dto.atenano = vm.atenano;                                       //宛名番号
            dto.setaino = vm.setaino;                                       //世帯番号
            dto.jutokbn = Enum住登区分.住登外;                              //住登区分
            //住民種別のデータ型はEnum住民種別と定義されているのでEnum.Parseを利用する、要注意！
            dto.juminsyubetu = (Enum住民種別)Enum.Parse(typeof(Enum住民種別), CStr(GetCd(vm.jutogaisyasyubetu))); //住民種別
            dto.juminjotai = CStr(GetCd(vm.jutogaisyajotai)); //住民状態
            dto.juminkbn = CStr(GetCd(vm.jutogaisyasyubetu)); //住民区分
            dto.simei = GetSimei(vm);                                       //氏名
            dto.simei_kana = GetSimeiKana(vm);                              //氏名_フリガナ
            dto.tusyo = vm.tusyo;                                           //通称
            dto.tusyo_kana = ToNKana(vm.tusyo_kana);                        //通称_フリガナ
            dto.simei_yusen = CStr(GetSimeiYusen(vm, Enum名称区分.名称));   //氏名_優先
            dto.simei_kana_yusen = GetSimeiYusen(vm, Enum名称区分.カナ);    //氏名_フリガナ_優先
            dto.sex = vm.sex;                                               //性別
            dto.bymd = vm.bymd;                                             //生年月日
            dto.bymd_fusyoflg = vm.bymd_fusyoflg;                           //生年月日_不詳フラグ
            dto.bymd_fusyohyoki = vm.bymd_fusyohyoki;                       //生年月日_不詳表記
            dto.zokuhyoki = "XX";                                           //住登外：「未設定」
            dto.adrs_sikucd = CStr(vm.adrs_sikucd);                         //住所_市区町村コード
            dto.adrs_tyoazacd = vm.adrs_tyoazacd;                           //住所_町字コード
            dto.tosi_gyoseikucd = CStr(GetCd(vm.tosi_gyoseikucd));          //指定都市_行政区等コード
            dto.adrs1 = GetAdrs(vm, ADRS1);                                 //住所1
            dto.adrs2 = GetAdrs(vm, ADRS2);                                 //住所2
            dto.adrs_katagakicd = vm.adrs_katagaki;                         //住所_方書コード
            dto.adrs_yubin = CStr(vm.adrs_yubin);                           //住所_郵便番号
            dto.personalno = vm.personalno;                                 //個人番号

            return dto;
        }

        /// <summary>
        /// 個人番号管理テーブル
        /// </summary>
        public static tt_afpersonalnoDto GetDto(SaveRequest req, tt_afpersonalnoDto dto, MainInfoVM vm, int perrirekino)
        {
            dto.atenano = vm.atenano;                                       //宛名番号
            dto.rirekino = perrirekino;                                     //履歴番号
            dto.personalno = vm.personalno;                                 //個人番号
            dto.renkeimotosousauserid = req.userid;                         //連携元操作者ID
            dto.renkeimotosousadttm = DateTime.Today;                       //連携元操作日時
            dto.saisinflg = SAISIN;                                         //最新フラグ

            return dto;
        }

        /// <summary>
        /// 住登外者情報--同世帯員更新用
        /// </summary>
        public static tt_afjutogaiDto GetDto(tt_afjutogaiDto dto, SeitaiInfoVM vm1, IdoInfoVM vm2, int rirekino)
        {
            //履歴番号をカウントアップ
            dto.rirekino = rirekino;                                        //履歴番号

            //基本情報（世帯）
            dto.setaino = vm1.setaino;                                      //世帯番号
            dto.adrs_yubin = vm1.adrs_yubin;                                //郵便番号
            dto.tosi_gyoseikucd = vm1.tosi_gyoseikucd;                      //指定都市_行政区等コード
            dto.adrs_sikucd = vm1.adrs_sikucd;                              //市区町村
            dto.adrs_tyoazacd = vm1.adrs_tyoazacd;                          //町字コード
            dto.adrs_tyoaza = vm1.adrs_tyoaza;                              //町字名
            dto.adrs_bantihyoki = vm1.adrs_bantihyoki;                      //番地号表記
            dto.adrs_katagaki_kana = ToNKana(vm1.adrs_katagaki_kana);       //方書(フリガナ)
            dto.adrs_katagaki = vm1.adrs_katagaki;                          //方書(漢字)

            dto.adrs_todofuken = vm1.adrs_todofuken;                        //都道府県
            dto.adrs_sikunm = vm1.adrs_sikunm;                              //市区町村名

            //基本情報（異動）
            dto.idoymd = vm2.idoymd;                                        //異動年月日
            dto.idotodokeymd = vm2.idotodokeymd;                            //異動届出年月日
            dto.idojiyu = vm2.idojiyu;                                      //異動事由

            return dto;
        }

        /// <summary>
        /// 宛名情報--同世帯員更新用
        /// </summary>
        public static tt_afatenaDto GetDto(tt_afatenaDto dto, SeitaiInfoVM vm)
        {
            //基本情報（世帯）
            dto.setaino = vm.setaino;                                       //世帯番号
            dto.adrs_yubin = CStr(vm.adrs_yubin);                           //住所_郵便番号
            dto.tosi_gyoseikucd = vm.tosi_gyoseikucd;                       //指定都市_行政区等コード
            dto.adrs_sikucd = CStr(vm.adrs_sikucd);                         //住所_市区町村コード
            dto.adrs_tyoazacd = CStr(vm.adrs_tyoazacd);                     //町字コード

            return dto;
        }

        /// <summary>
        /// 住登外者参照業務情報テーブル
        /// </summary>
        public static tt_afjutogai_gyomuDto GetDto(tt_afjutogai_gyomuDto dto, RefListVM vm, string atenano, int rirekino)
        {
            dto.atenano = atenano;                                          //宛名番号
            dto.rirekino = rirekino;                                        //履歴番号
            dto.gyomuid = vm.hanyocd;                                       //業務ID

            return dto;
        }

        /// <summary>
        /// 住登外者独自施策システム等情報テーブル
        /// </summary>
        public static tt_afjutogai_dokujisystemDto GetDto(tt_afjutogai_dokujisystemDto dto, RefListVM vm, string atenano, int rirekino)
        {
            dto.atenano = atenano;                                          //宛名番号
            dto.rirekino = rirekino;                                        //履歴番号
            dto.dokujisystemid = vm.hanyocd;                                //独自施策システム等ID

            return dto;
        }

        /// <summary>
        /// 住登外者固定検索条件取得：住登外者一覧を検索する場合場合
        /// </summary>
        //Todo：後でCommon--LogicService--Service--Converterに移動する予定
        public static FrConditionModel GetFixedCondition(SearchListRequest req)
        {
            var fixedCondition = new FrConditionModel();
            //宛名番号あるいは個人番号入力された場合、他の検索条件を無視する（概要4.1.3）
            if (!string.IsNullOrEmpty(req.atenano) || !string.IsNullOrEmpty(req.personalno))
            {
                //宛名番号
                if (!string.IsNullOrEmpty(req.atenano))
                {
                    fixedCondition.And(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.atenano), FrEnumValueOprator.EQ, req.atenano);
                }
                else
                {
                    //個人番号（検索のため暗号化）
                    if (!string.IsNullOrEmpty(req.personalno))
                    {
                        fixedCondition.And(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.personalno), FrEnumValueOprator.EQ, DaEncryptUtil.AesEncrypt(req.personalno));
                    }
                }
            }
            else
            //宛名番号または個人番号入力していない場合
            {
                //氏名
                if (!string.IsNullOrEmpty(req.name))
                {
                    var name = req.name.Replace(SPACE_FULL, string.Empty);
                    name = name.Replace(SPACE, string.Empty);
                    var cond = $"" +
                        $"REPLACE(REPLACE({tt_afjutogaiDto.TABLE_NAME}{C_DOT}{nameof(tt_afjutogaiDto.simei)},'{SPACE_FULL}','{string.Empty}'),'{SPACE}','{string.Empty}'){SPACE}LIKE{SPACE}'{ToLikeStr(name)}'{SPACE}OR{SPACE}" +
                        $"{tt_afjutogaiDto.TABLE_NAME}{C_DOT}{nameof(tt_afjutogaiDto.tusyo)}{SPACE}LIKE{SPACE}'{ToLikeStr(name)}'";
                    fixedCondition.And(cond);
                }
                //カナ氏名
                if (!string.IsNullOrEmpty(req.kname))
                {
                    var cond = new FrConditionModel()
                        .Sub(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.simei_kana_seion), FrEnumValueOprator.LK, ToKnameLikeStr(req.kname)!)
                        .Or(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.tusyo_kana_seion), FrEnumValueOprator.LK, ToKnameLikeStr(req.kname)!)
                        .EndSub();
                    fixedCondition.And(cond);
                }
                //生年月日
                if (!string.IsNullOrEmpty(req.bymd))
                {
                    fixedCondition.And(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.bymd), FrEnumValueOprator.EQ, req.bymd);
                }
                //生年月日_不詳フラグ
                if (req.fusyoflg)
                {
                    fixedCondition.And(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.bymd_fusyoflg), FrEnumValueOprator.EQ, req.fusyoflg);
                }
                //登録ユーザーID
                if (!string.IsNullOrEmpty(req.reguser))
                {
                    var reguser = CmLogicUtil.GetSearchPara(req.reguser);
                    if (!string.IsNullOrEmpty(reguser)) fixedCondition.And(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.reguserid), FrEnumValueOprator.EQ, reguser);
                }
                //登録日時（開始）
                if (req.regdatef.HasValue)
                {
                    var strdate = FormatYMD(req.regdatef, DateTimeFormat);
                    fixedCondition.And(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.regdttm), FrEnumValueOprator.GT, strdate);
                }
                //登録日時（終了）
                if (req.regdatet.HasValue)
                {
                    var strdate = FormatYMD(req.regdatet, DateTimeFormat);
                    fixedCondition.And(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.regdttm), FrEnumValueOprator.LT, strdate);
                }
                //更新ユーザーID
                if (!string.IsNullOrEmpty(req.upduser))
                {
                    var upduser = CmLogicUtil.GetSearchPara(req.upduser);
                    if (!string.IsNullOrEmpty(upduser)) fixedCondition.And(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.upduserid), FrEnumValueOprator.EQ, upduser);
                }
                //更新日時（開始）
                if (req.upddatef.HasValue)
                {
                    var strdate = FormatYMD(req.upddatef, DateTimeFormat);
                    fixedCondition.And(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.upddttm), FrEnumValueOprator.GT, strdate);
                }
                //更新日時（終了）
                if (req.upddatet.HasValue)
                {
                    var strdate = FormatYMD(req.upddatet, DateTimeFormat);
                    fixedCondition.And(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.upddttm), FrEnumValueOprator.LT, strdate);
                }
                //使用停止フラグ
                if (!string.IsNullOrEmpty(req.delflg))
                {
                    var delflg = GetCd(req.delflg);

                    bool stopflg = CmLogicUtil.GetSearchPara(delflg) == STOP;
                    fixedCondition.And(tt_afjutogaiDto.TABLE_NAME, nameof(tt_afjutogaiDto.stopflg), FrEnumValueOprator.EQ, stopflg);
                }

                //SQL文挿入
                //業務ID
                if (!string.IsNullOrEmpty(req.gyomuid))
                {
                    var cond = $"EXISTS{C_LEFT_BRACKET_HALF}{C_CR}" +
                        $"SELECT{C_SPACE}{tt_afjutogai_gyomuDto.TABLE_NAME}{C_DOT}{nameof(tt_afjutogai_gyomuDto.atenano)}{C_SPACE}{C_CR}" +
                        $"FROM{C_SPACE}{tt_afjutogai_gyomuDto.TABLE_NAME}{C_CR}" +
                        $"WHERE{C_SPACE}{tt_afjutogai_gyomuDto.TABLE_NAME}{C_DOT}{nameof(tt_afjutogai_gyomuDto.atenano)}{C_SPACE}{C_EQ}{C_SPACE}{tt_afjutogaiDto.TABLE_NAME}{C_DOT}{nameof(tt_afjutogaiDto.atenano)}{C_SPACE}{C_CR}" +
                        $"AND{C_SPACE}{tt_afjutogai_gyomuDto.TABLE_NAME}.{nameof(tt_afjutogai_gyomuDto.gyomuid)}{C_SPACE}{C_EQ}{C_SPACE}{C_SQT}{CmLogicUtil.GetSearchPara(req.gyomuid)}{C_SQT}{C_CR}{C_RIGHT_BRACKET_HALF}";
                    fixedCondition.And(cond);
                }

                //SQL文挿入
                //独自施策システム等ID
                if (!string.IsNullOrEmpty(req.dokujisystemid))
                {
                    var cond = $"EXISTS{C_LEFT_BRACKET_HALF}{C_CR}" +
                        $"SELECT{C_SPACE}{tt_afjutogai_dokujisystemDto.TABLE_NAME}{C_DOT}{nameof(tt_afjutogai_dokujisystemDto.atenano)}{C_SPACE}{C_CR}" +
                        $"FROM{C_SPACE}{tt_afjutogai_dokujisystemDto.TABLE_NAME}{C_CR}" +
                        $"WHERE{C_SPACE}{tt_afjutogai_dokujisystemDto.TABLE_NAME}{C_DOT}{nameof(tt_afjutogai_dokujisystemDto.atenano)}{C_SPACE}{C_EQ}{C_SPACE}{tt_afjutogaiDto.TABLE_NAME}{C_DOT}{nameof(tt_afjutogaiDto.atenano)}{C_SPACE}{C_CR}" +
                        $"AND{C_SPACE}{tt_afjutogai_dokujisystemDto.TABLE_NAME}.{nameof(tt_afjutogai_dokujisystemDto.dokujisystemid)}{C_SPACE}{C_EQ}{C_SPACE}{C_SQT}{CmLogicUtil.GetSearchPara(req.dokujisystemid)}{C_SQT}{C_CR}{C_RIGHT_BRACKET_HALF}";
                    fixedCondition.And(cond);
                }
            }

            return fixedCondition;
        }

        /// <summary>
        /// データ操作区分取得
        /// </summary>
        public static EnumActionType? GetKBN(DateTime? upddttm, bool editflg)
        {
            //下記以外の場合、修正なし
            EnumActionType? kbn = null;
            if (upddttm != null)
            {
                if (editflg)
                {
                    //更新日あり、編集フラグ☑=>更新
                    kbn = EnumActionType.Update;
                }
                else
                {
                    //更新日あり、編集フラグ☐=>削除
                    kbn = EnumActionType.Delete;
                }
            }
            else if (editflg)
            {
                //更新日なし、編集フラグ☑=>新規
                kbn = EnumActionType.Insert;
            }

            return kbn;
        }

        /// <summary>
        /// 氏名取得
        /// </summary>
        public static string GetSimei(MainInfoVM vm)
        {
            var jutogaisyasyubetu = (Enum住民種別)Enum.Parse(typeof(Enum住民種別), CStr(GetCd(vm.jutogaisyasyubetu)));

            // 日本人住民（氏_日本人　と　名_日本人　を全角スペースで連結して登録）
            if (jutogaisyasyubetu == Enum住民種別.日本人住民) { return $"{CStr(vm.si)}{C_SPACE_FULL}{CStr(vm.mei)}"; }

            // 外国人住民（氏名_外国人ローマ字　と　氏名_外国人漢字　を全角スペースで連結して登録）
            if (jutogaisyasyubetu == Enum住民種別.外国人住民) { return $"{CStr(vm.simei_gairoma)}{C_SPACE_FULL}{CStr(vm.simei_gaikanji)}"; }

            return string.Empty;
        }

        /// <summary>
        /// 氏名フリガナ取得
        /// </summary>
        public static string GetSimeiKana(MainInfoVM vm)
        {
            var jutogaisyasyubetu = (Enum住民種別)Enum.Parse(typeof(Enum住民種別), CStr(GetCd(vm.jutogaisyasyubetu)));

            // 日本人住民（氏_日本人_フリガナ　と　名_日本人_フリガナ　を全角スペースで連結して登録）
            if (jutogaisyasyubetu == Enum住民種別.日本人住民) { return $"{ToNKana(vm.si_kana)}{C_SPACE_FULL}{ToNKana(vm.mei_kana)}"; }

            // 外国人住民（入力内容を登録）
            if (jutogaisyasyubetu == Enum住民種別.外国人住民) { return CStr(ToNKana(vm.simei_kana)); }

            return string.Empty;
        }

        /// <summary>
        /// 氏名_優先と氏名_フリガナ_優先取得
        /// </summary>
        public static string? GetSimeiYusen(MainInfoVM vm, Enum名称区分 kbn)
        {
            String? str = null;

            var jutogaisyasyubetu = (Enum住民種別)Enum.Parse(typeof(Enum住民種別), CStr(GetCd(vm.jutogaisyasyubetu)));

            if (kbn == Enum名称区分.名称)
            {
                //氏名_優先を取得
                switch (jutogaisyasyubetu)
                {
                    case Enum住民種別.日本人住民:       // 日本人住民（氏_日本人　と　名_日本人　を全角スペースで連結して登録）
                        str = $"{CStr(vm.si)}{C_SPACE_FULL}{CStr(vm.mei)}";
                        break;

                    case Enum住民種別.外国人住民:       // 外国人住民（①通称②氏名_漢字外国人③氏名_外国人ローマ字）
                        if (!string.IsNullOrEmpty(vm.tusyo))
                        {
                            str = vm.tusyo;
                        }
                        else if (!string.IsNullOrEmpty(vm.simei_gaikanji))
                        {
                            str = vm.simei_gaikanji;
                        }
                        else if (!string.IsNullOrEmpty(vm.simei_gairoma))
                        {
                            str = vm.simei_gairoma;
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (kbn == Enum名称区分.カナ)
            {
                //氏名_優先を取得
                switch (jutogaisyasyubetu)
                {
                    case Enum住民種別.日本人住民:       // 日本人住民（氏_日本人_フリガナ　と　名_日本人_フリガナ　を全角スペースで連結して登録）
                        str = $"{ToNKana(vm.si_kana)}{C_SPACE_FULL}{ToNKana(vm.mei_kana)}";
                        break;

                    case Enum住民種別.外国人住民:       // 外国人住民（①通称_フリガナ②氏名_フリガナ）
                        if (!string.IsNullOrEmpty(vm.tusyo_kana))
                        {
                            str = ToNKana(vm.tusyo_kana);
                        }
                        else if (!string.IsNullOrEmpty(vm.simei_kana))
                        {
                            str = ToNKana(vm.simei_kana);
                        }
                        break;
                    default:
                        break;
                }
            }
            return str;
        }

        /// <summary>
        /// 住所１と住所２取得
        /// </summary>
        public static string GetAdrs(MainInfoVM vm, string adrsflg)
        {
            string str = string.Empty;

            if (adrsflg == ADRS1)
            {
                //住所１：住所_都道府県＋住所_市区郡町村名
                if (!string.IsNullOrEmpty(vm.adrs_todofuken)) { str = $"{str}{vm.adrs_todofuken}"; }
                if (!string.IsNullOrEmpty(vm.adrs_sikunm)) { str = $"{str}{vm.adrs_sikunm}"; }
            }
            else if (adrsflg == ADRS2)
            {
                //住所２：住所_町字＋住所_番地号表記＋住所_方書
                if (!string.IsNullOrEmpty(vm.adrs_tyoaza)) { str = $"{str}{vm.adrs_tyoaza}"; }
                if (!string.IsNullOrEmpty(vm.adrs_bantihyoki)) { str = $"{str}{vm.adrs_bantihyoki}"; }
                if (!string.IsNullOrEmpty(vm.adrs_katagaki)) { str = $"{str}{vm.adrs_katagaki}"; }
            }

            return str;
        }
    }
}
