/*==============================drop==============================*/
--3.宛名ビュー
drop view if exists vw_afatena;
--2.【住民基本台帳】住民情報ビュー
drop view if exists vw_afjumin;
--1.【住民基本台帳】支援措置対象者情報ビュー
drop view if exists vw_afsiensotitaisyosya;

/*=============================create=============================*/
--1.【住民基本台帳】支援措置対象者情報ビュー
create view vw_afsiensotitaisyosya(
    atenano,
    siensotiymdf,
    siensotiymdt,
    siensotikbn
)
as
select
    t1.atenano,
    t1.siensotiymdf,
    t1.siensotiymdt,
    t1.siensotikbn
from tt_afsiensotitaisyosya t1
where --todo
    t1.delflg = false and 
    t1.saisinflg = true;
comment on view vw_afsiensotitaisyosya is '【住民基本台帳】支援措置対象者情報ビュー';
comment on column vw_afsiensotitaisyosya.atenano is '宛名番号';
comment on column vw_afsiensotitaisyosya.siensotiymdf is '支援措置開始年月日';
comment on column vw_afsiensotitaisyosya.siensotiymdt is '支援措置終了年月日';
comment on column vw_afsiensotitaisyosya.siensotikbn is '支援措置区分';

--2.【住民基本台帳】住民情報ビュー
create view vw_afjumin(
    atenano,
    setaino,
    juminsyubetu,
    juminjotai,
    idoymd,
    idoymd_fusyoflg,
    idoymd_fusyohyoki,
    idotodokeymd,
    idojiyu,
    simei,
    simei_gairoma,
    simei_gaikanji,
    simei_kana,
    kyusi,
    kyusi_kana,
    tusyo,
    tusyo_kana,
    simeiyusenkbn,
    sex,
    sexhyoki,
    bymd,
    bymd_fusyoflg,
    bymd_fusyohyoki,
    zokucd1,
    zokucd2,
    zokucd3,
    zokucd4,
    zokuhyoki,
    adrs_sikucd,
    adrs_tyoazacd,
    tosi_gyoseikucd,
    adrs_todofuken,
    adrs_sikunm,
    adrs_tyoaza,
    adrs_bantihyoki,
    adrs_bantiedanum,
    adrs_katagakicd,
    adrs_katagaki,
    adrs_katagaki_kana,
    adrs_yubin,
    juymd,
    juymd_fusyoflg,
    juymd_fusyohyoki,
    tennyumaeadrs_sikucd,
    tennyumaeadrs_tyoazacd,
    tennyumaeadrs_todofuken,
    tennyumaeadrs_sikunm,
    tennyumaeadrs_tyoaza,
    tennyumaeadrs_bantihyoki,
    tennyumaeadrs_katagaki,
    tennyumaeadrs_yubin,
    tennyumaeadrs_kokunmcd,
    tennyumaeadrs_kokunm,
    tennyumaeadrs_gaiadrs,
    tennyumaeadrs_senusisimei,
    tenkyomaeadrs_sikucd,
    tenkyomaeadrs_tyoazacd,
    tenkyomaeadrs_todofuken,
    tenkyomaeadrs_sikunm,
    tenkyomaeadrs_tyoaza,
    tenkyomaeadrs_bantihyoki,
    tenkyomaeadrs_katagakicd,
    tenkyomaeadrs_katagaki,
    tenkyomaeadrs_katagaki_kana,
    tenkyomaeadrs_yubin,
    todokeymd,
    delidoymd,
    delidoymd_fusyoflg,
    delidoymd_fusyohyoki,
    tennyututiymd,
    tensyutuyoteiadrs_sikucd,
    tensyutuyoteiadrs_tyoazacd,
    tensyutuyoteiadrs_todofuken,
    tensyutuyoteiadrs_sikunm,
    tensyutuyoteiadrs_tyoaza,
    tensyutuyoteiadrs_bantihyoki,
    tensyutuyoteiadrs_katagaki,
    tensyutuyoteiadrs_kokunmcd,
    tensyutuyoteiadrs_kokunm,
    tensyutuyoteiadrs_gaiadrs,
    tensyutuyoteiadrs_yubin,
    tensyutukakuteiadrs_sikucd,
    tensyutukakuteiadrs_tyoazacd,
    tensyutukakuteiadrs_todofuken,
    tensyutukakuteiadrs_sikunm,
    tensyutukakuteiadrs_tyoaza,
    tensyutukakuteiadrs_bantihyoki,
    tensyutukakuteiadrs_katagaki,
    tensyutukakuteiadrs_yubin,
    gaijuymd,
    gaijuymd_fusyoflg,
    gaijuymd_fusyohyoki,
    kokunmcd,
    kokunm,
    kiteikbn,
    zairyucd,
    zairyucd_year,
    zairyucd_month,
    zairyucd_day,
    zairyumanryoymd,
    tikukanricd1,
    tikukanricd2,
    tikukanricd3,
    tikukanricd4,
    tikukanricd5,
    tikukanricd6,
    tikukanricd7,
    tikukanricd8,
    tikukanricd9,
    tikukanricd10,
    personalno
) 
as 
select 
    t1.atenano,
    t1.setaino,
    t1.juminsyubetu,
    t1.juminjotai,
    t1.idoymd,
    t1.idoymd_fusyoflg,
    t1.idoymd_fusyohyoki,
    t1.idotodokeymd,
    t1.idojiyu,
    t1.simei,
    t1.simei_gairoma,
    t1.simei_gaikanji,
    t1.simei_kana,
    t1.kyusi,
    t1.kyusi_kana,
    t1.tusyo,
    t1.tusyo_kana,
    t1.simeiyusenkbn,
    t1.sex,
    t1.sexhyoki,
    t1.bymd,
    t1.bymd_fusyoflg,
    t1.bymd_fusyohyoki,
    t1.zokucd1,
    t1.zokucd2,
    t1.zokucd3,
    t1.zokucd4,
    t1.zokuhyoki,
    t1.adrs_sikucd,
    t1.adrs_tyoazacd,
    t1.tosi_gyoseikucd,
    t1.adrs_todofuken,
    t1.adrs_sikunm,
    t1.adrs_tyoaza,
    t1.adrs_bantihyoki,
    t1.adrs_bantiedanum,
    t1.adrs_katagakicd,
    t1.adrs_katagaki,
    t1.adrs_katagaki_kana,
    t1.adrs_yubin,
    t1.juymd,
    t1.juymd_fusyoflg,
    t1.juymd_fusyohyoki,
    t1.tennyumaeadrs_sikucd,
    t1.tennyumaeadrs_tyoazacd,
    t1.tennyumaeadrs_todofuken,
    t1.tennyumaeadrs_sikunm,
    t1.tennyumaeadrs_tyoaza,
    t1.tennyumaeadrs_bantihyoki,
    t1.tennyumaeadrs_katagaki,
    t1.tennyumaeadrs_yubin,
    t1.tennyumaeadrs_kokunmcd,
    t1.tennyumaeadrs_kokunm,
    t1.tennyumaeadrs_gaiadrs,
    t1.tennyumaeadrs_senusisimei,
    t1.tenkyomaeadrs_sikucd,
    t1.tenkyomaeadrs_tyoazacd,
    t1.tenkyomaeadrs_todofuken,
    t1.tenkyomaeadrs_sikunm,
    t1.tenkyomaeadrs_tyoaza,
    t1.tenkyomaeadrs_bantihyoki,
    t1.tenkyomaeadrs_katagakicd,
    t1.tenkyomaeadrs_katagaki,
    t1.tenkyomaeadrs_katagaki_kana,
    t1.tenkyomaeadrs_yubin,
    t1.todokeymd,
    t1.delidoymd,
    t1.delidoymd_fusyoflg,
    t1.delidoymd_fusyohyoki,
    t1.tennyututiymd,
    t1.tensyutuyoteiadrs_sikucd,
    t1.tensyutuyoteiadrs_tyoazacd,
    t1.tensyutuyoteiadrs_todofuken,
    t1.tensyutuyoteiadrs_sikunm,
    t1.tensyutuyoteiadrs_tyoaza,
    t1.tensyutuyoteiadrs_bantihyoki,
    t1.tensyutuyoteiadrs_katagaki,
    t1.tensyutuyoteiadrs_kokunmcd,
    t1.tensyutuyoteiadrs_kokunm,
    t1.tensyutuyoteiadrs_gaiadrs,
    t1.tensyutuyoteiadrs_yubin,
    t1.tensyutukakuteiadrs_sikucd,
    t1.tensyutukakuteiadrs_tyoazacd,
    t1.tensyutukakuteiadrs_todofuken,
    t1.tensyutukakuteiadrs_sikunm,
    t1.tensyutukakuteiadrs_tyoaza,
    t1.tensyutukakuteiadrs_bantihyoki,
    t1.tensyutukakuteiadrs_katagaki,
    t1.tensyutukakuteiadrs_yubin,
    t1.gaijuymd,
    t1.gaijuymd_fusyoflg,
    t1.gaijuymd_fusyohyoki,
    t1.kokunmcd,
    t1.kokunm,
    t1.kiteikbn,
    t1.zairyucd,
    t1.zairyucd_year,
    t1.zairyucd_month,
    t1.zairyucd_day,
    t1.zairyumanryoymd,
    t1.tikukanricd1,
    t1.tikukanricd2,
    t1.tikukanricd3,
    t1.tikukanricd4,
    t1.tikukanricd5,
    t1.tikukanricd6,
    t1.tikukanricd7,
    t1.tikukanricd8,
    t1.tikukanricd9,
    t1.tikukanricd10,
    t1.personalno
from tt_afjumin t1
where --todo
    t1.delflg = false and 
    t1.saisinflg = true;
comment on view vw_afjumin is '【住民基本台帳】住民情報ビュー';
comment on column vw_afjumin.atenano is '宛名番号';
comment on column vw_afjumin.setaino is '世帯番号';
comment on column vw_afjumin.juminsyubetu is '住民種別';
comment on column vw_afjumin.juminjotai is '住民状態';
comment on column vw_afjumin.idoymd is '異動年月日';
comment on column vw_afjumin.idoymd_fusyoflg is '異動年月日_不詳フラグ';
comment on column vw_afjumin.idoymd_fusyohyoki is '異動年月日_不詳表記';
comment on column vw_afjumin.idotodokeymd is '異動届出年月日';
comment on column vw_afjumin.idojiyu is '異動事由';
comment on column vw_afjumin.simei is '氏名';
comment on column vw_afjumin.simei_gairoma is '氏名_外国人ローマ字';
comment on column vw_afjumin.simei_gaikanji is '氏名_外国人漢字';
comment on column vw_afjumin.simei_kana is '氏名_フリガナ';
comment on column vw_afjumin.kyusi is '旧氏';
comment on column vw_afjumin.kyusi_kana is '旧氏_フリガナ';
comment on column vw_afjumin.tusyo is '通称';
comment on column vw_afjumin.tusyo_kana is '通称_フリガナ';
comment on column vw_afjumin.simeiyusenkbn is '氏名優先区分';
comment on column vw_afjumin.sex is '性別';
comment on column vw_afjumin.sexhyoki is '性別表記';
comment on column vw_afjumin.bymd is '生年月日';
comment on column vw_afjumin.bymd_fusyoflg is '生年月日_不詳フラグ';
comment on column vw_afjumin.bymd_fusyohyoki is '生年月日_不詳表記';
comment on column vw_afjumin.zokucd1 is '続柄コード1';
comment on column vw_afjumin.zokucd2 is '続柄コード2';
comment on column vw_afjumin.zokucd3 is '続柄コード3';
comment on column vw_afjumin.zokucd4 is '続柄コード4';
comment on column vw_afjumin.zokuhyoki is '続柄表記';
comment on column vw_afjumin.adrs_sikucd is '住所_市区町村コード';
comment on column vw_afjumin.adrs_tyoazacd is '住所_町字コード';
comment on column vw_afjumin.tosi_gyoseikucd is '指定都市_行政区等コード';
comment on column vw_afjumin.adrs_todofuken is '住所_都道府県';
comment on column vw_afjumin.adrs_sikunm is '住所_市区郡町村名';
comment on column vw_afjumin.adrs_tyoaza is '住所_町字';
comment on column vw_afjumin.adrs_bantihyoki is '住所_番地号表記';
comment on column vw_afjumin.adrs_bantiedanum is '住所_番地枝番数値';
comment on column vw_afjumin.adrs_katagakicd is '住所_方書コード';
comment on column vw_afjumin.adrs_katagaki is '住所_方書';
comment on column vw_afjumin.adrs_katagaki_kana is '住所_方書_フリガナ';
comment on column vw_afjumin.adrs_yubin is '住所_郵便番号';
comment on column vw_afjumin.juymd is '住民となった年月日';
comment on column vw_afjumin.juymd_fusyoflg is '住民となった年月日_不詳フラグ';
comment on column vw_afjumin.juymd_fusyohyoki is '住民となった年月日_不詳表記';
comment on column vw_afjumin.tennyumaeadrs_sikucd is '転入前住所_市区町村コード';
comment on column vw_afjumin.tennyumaeadrs_tyoazacd is '転入前住所_町字コード';
comment on column vw_afjumin.tennyumaeadrs_todofuken is '転入前住所_都道府県';
comment on column vw_afjumin.tennyumaeadrs_sikunm is '転入前住所_市区郡町村名';
comment on column vw_afjumin.tennyumaeadrs_tyoaza is '転入前住所_町字';
comment on column vw_afjumin.tennyumaeadrs_bantihyoki is '転入前住所_番地号表記';
comment on column vw_afjumin.tennyumaeadrs_katagaki is '転入前住所_方書';
comment on column vw_afjumin.tennyumaeadrs_yubin is '転入前住所_郵便番号';
comment on column vw_afjumin.tennyumaeadrs_kokunmcd is '転入前住所_国名コード';
comment on column vw_afjumin.tennyumaeadrs_kokunm is '転入前住所_国名等';
comment on column vw_afjumin.tennyumaeadrs_gaiadrs is '転入前住所_国外住所';
comment on column vw_afjumin.tennyumaeadrs_senusisimei is '転入前住所_世帯主氏名';
comment on column vw_afjumin.tenkyomaeadrs_sikucd is '転居前住所_市区町村コード';
comment on column vw_afjumin.tenkyomaeadrs_tyoazacd is '転居前住所_町字コード';
comment on column vw_afjumin.tenkyomaeadrs_todofuken is '転居前住所_都道府県';
comment on column vw_afjumin.tenkyomaeadrs_sikunm is '転居前住所_市区郡町村名';
comment on column vw_afjumin.tenkyomaeadrs_tyoaza is '転居前住所_町字';
comment on column vw_afjumin.tenkyomaeadrs_bantihyoki is '転居前住所_番地号表記';
comment on column vw_afjumin.tenkyomaeadrs_katagakicd is '転居前住所_方書コード';
comment on column vw_afjumin.tenkyomaeadrs_katagaki is '転居前住所_方書';
comment on column vw_afjumin.tenkyomaeadrs_katagaki_kana is '転居前住所_方書_フリガナ';
comment on column vw_afjumin.tenkyomaeadrs_yubin is '転居前住所_郵便番号';
comment on column vw_afjumin.todokeymd is '消除の届出年月日';
comment on column vw_afjumin.delidoymd is '消除の異動年月日';
comment on column vw_afjumin.delidoymd_fusyoflg is '消除の異動年月日_不詳フラグ';
comment on column vw_afjumin.delidoymd_fusyohyoki is '消除の異動年月日_不詳表記';
comment on column vw_afjumin.tennyututiymd is '転入通知年月日';
comment on column vw_afjumin.tensyutuyoteiadrs_sikucd is '転出先住所（予定）_市区町村コード';
comment on column vw_afjumin.tensyutuyoteiadrs_tyoazacd is '転出先住所（予定）_町字コード';
comment on column vw_afjumin.tensyutuyoteiadrs_todofuken is '転出先住所（予定）_都道府県';
comment on column vw_afjumin.tensyutuyoteiadrs_sikunm is '転出先住所（予定）_市区郡町村名';
comment on column vw_afjumin.tensyutuyoteiadrs_tyoaza is '転出先住所（予定）_町字';
comment on column vw_afjumin.tensyutuyoteiadrs_bantihyoki is '転出先住所（予定）_番地号表記';
comment on column vw_afjumin.tensyutuyoteiadrs_katagaki is '転出先住所（予定）_方書';
comment on column vw_afjumin.tensyutuyoteiadrs_kokunmcd is '転出先住所（予定）_国名コード';
comment on column vw_afjumin.tensyutuyoteiadrs_kokunm is '転出先住所（予定）_国名等';
comment on column vw_afjumin.tensyutuyoteiadrs_gaiadrs is '転出先住所（予定）_国外住所';
comment on column vw_afjumin.tensyutuyoteiadrs_yubin is '転出先住所（予定）_郵便番号';
comment on column vw_afjumin.tensyutukakuteiadrs_sikucd is '転出先住所（確定）_市区町村コード';
comment on column vw_afjumin.tensyutukakuteiadrs_tyoazacd is '転出先住所（確定）_町字コード';
comment on column vw_afjumin.tensyutukakuteiadrs_todofuken is '転出先住所（確定）_都道府県';
comment on column vw_afjumin.tensyutukakuteiadrs_sikunm is '転出先住所（確定）_市区郡町村名';
comment on column vw_afjumin.tensyutukakuteiadrs_tyoaza is '転出先住所（確定）_町字';
comment on column vw_afjumin.tensyutukakuteiadrs_bantihyoki is '転出先住所（確定）_番地号表記';
comment on column vw_afjumin.tensyutukakuteiadrs_katagaki is '転出先住所（確定）_方書';
comment on column vw_afjumin.tensyutukakuteiadrs_yubin is '転出先住所（確定）_郵便番号';
comment on column vw_afjumin.gaijuymd is '外国人住民となった年月日';
comment on column vw_afjumin.gaijuymd_fusyoflg is '外国人住民となった年月日_不詳フラグ';
comment on column vw_afjumin.gaijuymd_fusyohyoki is '外国人住民となった年月日_不詳表記';
comment on column vw_afjumin.kokunmcd is '国籍等_国名コード';
comment on column vw_afjumin.kokunm is '国籍名等';
comment on column vw_afjumin.kiteikbn is '第30条45規定区分';
comment on column vw_afjumin.zairyucd is '在留資格等コード';
comment on column vw_afjumin.zairyucd_year is '在留期間等コード_年';
comment on column vw_afjumin.zairyucd_month is '在留期間等コード_月';
comment on column vw_afjumin.zairyucd_day is '在留期間等コード_日';
comment on column vw_afjumin.zairyumanryoymd is '在留期間の満了の日';
comment on column vw_afjumin.tikukanricd1 is '地区管理コード1';
comment on column vw_afjumin.tikukanricd2 is '地区管理コード2';
comment on column vw_afjumin.tikukanricd3 is '地区管理コード3';
comment on column vw_afjumin.tikukanricd4 is '地区管理コード4';
comment on column vw_afjumin.tikukanricd5 is '地区管理コード5';
comment on column vw_afjumin.tikukanricd6 is '地区管理コード6';
comment on column vw_afjumin.tikukanricd7 is '地区管理コード7';
comment on column vw_afjumin.tikukanricd8 is '地区管理コード8';
comment on column vw_afjumin.tikukanricd9 is '地区管理コード9';
comment on column vw_afjumin.tikukanricd10 is '地区管理コード10';
comment on column vw_afjumin.personalno is '個人番号';

--3.宛名ビュー
create view vw_afatena(
    atenano,
    setaino,
    jutokbn,
    juminsyubetu,
    juminjotai,
    simei,
    simei_kana,
    tusyo,
    tusyo_kana,
    sex,
    sexhyoki,
    bymd,
    bymd_fusyoflg,
    bymd_fusyohyoki,
    zokuhyoki,
    adrs_sikucd,
    adrs_tyoazacd,
    tosi_gyoseikucd,
    adrs,
    adrs_katagakicd,
    adrs_yubin,
    tikukanricd1,
    tikukanricd2,
    tikukanricd3,
    tikukanricd4,
    tikukanricd5,
    tikukanricd6,
    tikukanricd7,
    tikukanricd8,
    tikukanricd9,
    tikukanricd10,
    siensotiflg,
    personalno
) 
as 
select 
    u1.atenano,
    u1.setaino,
    u1.jutokbn,
    u1.juminsyubetu,
    u1.juminjotai,
    u1.simei,
    u1.simei_kana,
    u1.tusyo,
    u1.tusyo_kana,
    u1.sex,
    u1.sexhyoki,
    u1.bymd,
    u1.bymd_fusyoflg,
    u1.bymd_fusyohyoki,
    u1.zokuhyoki,
    u1.adrs_sikucd,
    u1.adrs_tyoazacd,
    u1.tosi_gyoseikucd,
    u1.adrs,
    u1.adrs_katagakicd,
    u1.adrs_yubin,
    u1.tikukanricd1,
    u1.tikukanricd2,
    u1.tikukanricd3,
    u1.tikukanricd4,
    u1.tikukanricd5,
    u1.tikukanricd6,
    u1.tikukanricd7,
    u1.tikukanricd8,
    u1.tikukanricd9,
    u1.tikukanricd10,
    u1.siensotiflg,
    u1.personalno
from
(
(
select 
    v1.atenano,
    v1.setaino,
    '1' as jutokbn,
    v1.juminsyubetu,
    v1.juminjotai,
    v1.simei,
    v1.simei_kana,
    v1.tusyo,
    v1.tusyo_kana,
    v1.sex,
    v1.sexhyoki,
    v1.bymd,
    v1.bymd_fusyoflg,
    v1.bymd_fusyohyoki,
    v1.zokuhyoki,
    v1.adrs_sikucd,
    v1.adrs_tyoazacd,
    v1.tosi_gyoseikucd,
    case when (select value1 from tm_afctrl where ctrlmaincd = '1000' and ctrlsubcd = 2 and ctrlcd = '03' limit 1)  = '1' 
        then v1.adrs_todofuken || v1.adrs_sikunm || v1.adrs_tyoaza || v1.adrs_bantihyoki || v1.adrs_katagaki
        else v1.adrs_tyoaza || v1.adrs_bantihyoki || v1.adrs_katagaki
    end as adrs,
    v1.adrs_katagakicd,
    v1.adrs_yubin,
    v1.tikukanricd1,
    v1.tikukanricd2,
    v1.tikukanricd3,
    v1.tikukanricd4,
    v1.tikukanricd5,
    v1.tikukanricd6,
    v1.tikukanricd7,
    v1.tikukanricd8,
    v1.tikukanricd9,
    v1.tikukanricd10,
    case when v2.atenano is not null 
        then true
        else false
    end as siensotiflg,
    v1.personalno
from vw_afjumin v1
left join vw_afsiensotitaisyosya v2
on v1.atenano = v2.atenano and
v2.siensotiymdf <= to_char(current_date,'yyyy-MM-dd') and
v2.siensotiymdt <= to_char(current_date,'yyyy-MM-dd')
and v2.siensotikbn = '1'--todo
) --住民情報
union all
(
select 
    t1.atenano,
    t1.setaino,
    '2' as jutokbn,
    t1.jutogaisyasyubetu as juminsyubetu,
    t1.jutogaisyajotai as juminjotai,
    t1.simei,
    t1.simei_kana,
    t1.tusyo,
    t1.tusyo_kana,
    case when t1.sex is null 
        then '0'
        else t1.sex
    end as sex,
    t1.sexhyoki,
    t1.bymd,
    t1.bymd_fusyoflg,
    t1.bymd_fusyohyoki,
    '未設定' as zokuhyoki,
    t1.adrs_sikucd,
    t1.adrs_tyoazacd,
    t1.tosi_gyoseikucd,
    case when (select value1 from tm_afctrl where ctrlmaincd = '1000' and ctrlsubcd = 2 and ctrlcd = '03' limit 1)  = '1' 
        then t1.adrs_todofuken || t1.adrs_sikunm || t1.adrs_tyoaza || t1.adrs_bantihyoki || t1.adrs_katagaki
        else t1.adrs_tyoaza || t1.adrs_bantihyoki || t1.adrs_katagaki
    end as adrs,
    null as adrs_katagakicd,
    t1.adrs_yubin,
    null as tikukanricd1,
    null as tikukanricd2,
    null as tikukanricd3,
    null as tikukanricd4,
    null as tikukanricd5,
    null as tikukanricd6,
    null as tikukanricd7,
    null as tikukanricd8,
    null as tikukanricd9,
    null as tikukanricd10,
    case when v1.atenano is not null 
        then true
        else false
    end as siensotiflg,
    t2.personalno
from tt_afjutogai t1
left join vw_afsiensotitaisyosya v1
on t1.atenano = v1.atenano and
v1.siensotiymdf <= to_char(current_date,'yyyy-MM-dd') and
v1.siensotiymdt <= to_char(current_date,'yyyy-MM-dd')
and v1.siensotikbn = '1'--todo
left join tt_afpersonalno as t2
on t1.atenano = t2.atenano and 
t1.rirekino = t2.rirekino and
t2.delflg = false and 
t2.saisinflg = true
where --todo
    t1.delflg = false and 
    t1.saisinflg = true
) --住登外
) as u1;

comment on view vw_afatena is '宛名ビュー';
comment on column vw_afatena.atenano is '宛名番号';
comment on column vw_afatena.setaino is '世帯番号';
comment on column vw_afatena.jutokbn is '住登区分';
comment on column vw_afatena.juminsyubetu is '住民種別';
comment on column vw_afatena.juminjotai is '住民状態';
comment on column vw_afatena.simei is '氏名';
comment on column vw_afatena.simei_kana is '氏名_フリガナ';
comment on column vw_afatena.tusyo is '通称';
comment on column vw_afatena.tusyo_kana is '通称_フリガナ';
comment on column vw_afatena.sex is '性別';
comment on column vw_afatena.sexhyoki is '性別表記';
comment on column vw_afatena.bymd is '生年月日';
comment on column vw_afatena.bymd_fusyoflg is '生年月日_不詳フラグ';
comment on column vw_afatena.bymd_fusyohyoki is '生年月日_不詳表記';
comment on column vw_afatena.zokuhyoki is '続柄表記';
comment on column vw_afatena.adrs_sikucd is '住所_市区町村コード';
comment on column vw_afatena.adrs_tyoazacd is '住所_町字コード';
comment on column vw_afatena.tosi_gyoseikucd is '指定都市_行政区等コード';
comment on column vw_afatena.adrs is '住所';
comment on column vw_afatena.adrs_katagakicd is '住所_方書コード';
comment on column vw_afatena.adrs_yubin is '住所_郵便番号';
comment on column vw_afatena.tikukanricd1 is '地区管理コード1';
comment on column vw_afatena.tikukanricd2 is '地区管理コード2';
comment on column vw_afatena.tikukanricd3 is '地区管理コード3';
comment on column vw_afatena.tikukanricd4 is '地区管理コード4';
comment on column vw_afatena.tikukanricd5 is '地区管理コード5';
comment on column vw_afatena.tikukanricd6 is '地区管理コード6';
comment on column vw_afatena.tikukanricd7 is '地区管理コード7';
comment on column vw_afatena.tikukanricd8 is '地区管理コード8';
comment on column vw_afatena.tikukanricd9 is '地区管理コード9';
comment on column vw_afatena.tikukanricd10 is '地区管理コード10';
comment on column vw_afatena.siensotiflg is '支援措置対象者フラグ';
comment on column vw_afatena.personalno is '個人番号';