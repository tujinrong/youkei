--コントロールマスタ
drop table if exists tm_afctrl;
create table tm_afctrl(
    ctrlmaincd varchar(4) not null,
    ctrlsubcd integer not null,
    ctrlcd varchar(20) not null,
    itemnm varchar(200) not null,
    datatype smallint not null,
    rangeflg boolean not null default false,
    value1 varchar(100),
    value2 varchar(100),
    biko varchar(200),
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(ctrlmaincd,ctrlsubcd,ctrlcd)
);
comment on table tm_afctrl is 'コントロールマスタ';
comment on column tm_afctrl.ctrlmaincd is 'コントロールメインコード';
comment on column tm_afctrl.ctrlsubcd is 'コントロールサブコード';
comment on column tm_afctrl.ctrlcd is 'コントロールコード';
comment on column tm_afctrl.itemnm is '項目名称';
comment on column tm_afctrl.datatype is 'データ型';
comment on column tm_afctrl.rangeflg is '範囲フラグ';
comment on column tm_afctrl.value1 is '値１';
comment on column tm_afctrl.value2 is '値２';
comment on column tm_afctrl.biko is '備考';
comment on column tm_afctrl.upduserid is '更新ユーザーID';
comment on column tm_afctrl.upddttm is '更新日時';

--コントロールメインマスタ
drop table if exists tm_afctrl_main;
create table tm_afctrl_main(
    ctrlmaincd varchar(4) not null,
    ctrlsubcd integer not null,
    ctrlsubcdnm varchar(100) not null,
    kananm varchar(100),
    shortnm varchar(50),
    biko varchar(200),
primary key(ctrlmaincd,ctrlsubcd)
);
comment on table tm_afctrl_main is 'コントロールメインマスタ';
comment on column tm_afctrl_main.ctrlmaincd is 'コントロールメインコード';
comment on column tm_afctrl_main.ctrlsubcd is 'コントロールサブコード';
comment on column tm_afctrl_main.ctrlsubcdnm is 'コントロールサブコード名称';
comment on column tm_afctrl_main.kananm is 'カナ名称';
comment on column tm_afctrl_main.shortnm is '略称';
comment on column tm_afctrl_main.biko is '備考';

--ファイルマスタ
drop table if exists tm_affile;
create table tm_affile(
    siyokbn varchar(2) not null,
    filenm varchar(200) not null,
    filetype smallint not null,
    filedata bytea not null,
primary key(siyokbn)
);
comment on table tm_affile is 'ファイルマスタ';
comment on column tm_affile.siyokbn is '使用区分';
comment on column tm_affile.filenm is 'ファイル名';
comment on column tm_affile.filetype is 'ファイルタイプ';
comment on column tm_affile.filedata is 'ファイルデータ';

--汎用マスタ
drop table if exists tm_afhanyo;
create table tm_afhanyo(
    hanyomaincd varchar(4) not null,
    hanyosubcd integer not null,
    hanyocd varchar(20) not null,
    nm varchar(100) not null,
    kananm varchar(100),
    shortnm varchar(50),
    biko varchar(200),
    hanyokbn1 varchar(1000),
    hanyokbn2 varchar(1000),
    hanyokbn3 varchar(1000),
    stopflg boolean not null default false,
    orderseq smallint,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(hanyomaincd,hanyosubcd,hanyocd)
);
comment on table tm_afhanyo is '汎用マスタ';
comment on column tm_afhanyo.hanyomaincd is '汎用メインコード';
comment on column tm_afhanyo.hanyosubcd is '汎用サブコード';
comment on column tm_afhanyo.hanyocd is '汎用コード';
comment on column tm_afhanyo.nm is '名称';
comment on column tm_afhanyo.kananm is 'カナ名称';
comment on column tm_afhanyo.shortnm is '略称';
comment on column tm_afhanyo.biko is '備考';
comment on column tm_afhanyo.hanyokbn1 is '汎用区分1';
comment on column tm_afhanyo.hanyokbn2 is '汎用区分2';
comment on column tm_afhanyo.hanyokbn3 is '汎用区分3';
comment on column tm_afhanyo.stopflg is '使用停止フラグ';
comment on column tm_afhanyo.orderseq is '並びシーケンス';
comment on column tm_afhanyo.reguserid is '登録ユーザーID';
comment on column tm_afhanyo.regdttm is '登録日時';
comment on column tm_afhanyo.upduserid is '更新ユーザーID';
comment on column tm_afhanyo.upddttm is '更新日時';

--汎用メインマスタ
drop table if exists tm_afhanyo_main;
create table tm_afhanyo_main(
    hanyomaincd varchar(4) not null,
    hanyosubcd integer not null,
    hanyosubcdnm varchar(100) not null,
    kananm varchar(100),
    shortnm varchar(50),
    keta integer,
    userryoikikaisicd integer,
    iflg boolean not null,
    uflg boolean not null,
    dflg boolean not null,
    biko varchar(200),
primary key(hanyomaincd,hanyosubcd)
);
comment on table tm_afhanyo_main is '汎用メインマスタ';
comment on column tm_afhanyo_main.hanyomaincd is '汎用メインコード';
comment on column tm_afhanyo_main.hanyosubcd is '汎用サブコード';
comment on column tm_afhanyo_main.hanyosubcdnm is '汎用サブコード名称';
comment on column tm_afhanyo_main.kananm is 'カナ名称';
comment on column tm_afhanyo_main.shortnm is '略称';
comment on column tm_afhanyo_main.keta is '桁数';
comment on column tm_afhanyo_main.userryoikikaisicd is 'ユーザ領域開始コード';
comment on column tm_afhanyo_main.iflg is 'INSERT可能フラグ';
comment on column tm_afhanyo_main.uflg is 'UPDATE可能フラグ';
comment on column tm_afhanyo_main.dflg is 'DELETE可能フラグ';
comment on column tm_afhanyo_main.biko is '備考';

--ヘルプドキュメントマスタ
drop table if exists tm_afhelpdoc;
create table tm_afhelpdoc(
    docseq bigserial not null,
    kinoid varchar(10) not null,
    filenm varchar(200) not null,
    filetype smallint not null,
    filesize integer not null,
    filedata bytea not null,
primary key(docseq)
);
comment on table tm_afhelpdoc is 'ヘルプドキュメントマスタ';
comment on column tm_afhelpdoc.docseq is 'ドキュメントシーケンス';
comment on column tm_afhelpdoc.kinoid is '機能ID';
comment on column tm_afhelpdoc.filenm is 'ファイル名';
comment on column tm_afhelpdoc.filetype is 'ファイルタイプ';
comment on column tm_afhelpdoc.filesize is 'ファイルサイズ';
comment on column tm_afhelpdoc.filedata is 'ファイルデータ';

--会場情報マスタ
drop table if exists tm_afkaijo;
create table tm_afkaijo(
    kaijocd varchar(7) not null,
    kaijonm varchar(100) not null,
    kanakaijonm varchar(100) not null,
    adrs varchar(84) not null,
    katagaki varchar(300) not null,
    kaijorenrakusaki varchar(15) not null,
    gyoseikucd varchar(12),
    stopflg boolean not null default false,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(kaijocd)
);
comment on table tm_afkaijo is '会場情報マスタ';
comment on column tm_afkaijo.kaijocd is '会場コード';
comment on column tm_afkaijo.kaijonm is '会場名';
comment on column tm_afkaijo.kanakaijonm is '会場名（カナ）';
comment on column tm_afkaijo.adrs is '住所';
comment on column tm_afkaijo.katagaki is '方書';
comment on column tm_afkaijo.kaijorenrakusaki is '会場連絡先';
comment on column tm_afkaijo.gyoseikucd is '行政区';
comment on column tm_afkaijo.stopflg is '使用停止フラグ';
comment on column tm_afkaijo.reguserid is '登録ユーザーID';
comment on column tm_afkaijo.regdttm is '登録日時';
comment on column tm_afkaijo.upduserid is '更新ユーザーID';
comment on column tm_afkaijo.upddttm is '更新日時';

--会場情報サブマスタ
drop table if exists tm_afkaijo_sub;
create table tm_afkaijo_sub(
    kaijocd varchar(7) not null,
    tikukbn varchar(2) not null,
    tikucd varchar(12) not null,
primary key(kaijocd,tikukbn,tikucd)
);
comment on table tm_afkaijo_sub is '会場情報サブマスタ';
comment on column tm_afkaijo_sub.kaijocd is '会場コード';
comment on column tm_afkaijo_sub.tikukbn is '地区区分';
comment on column tm_afkaijo_sub.tikucd is '地区コード';

--医療機関マスタ
drop table if exists tm_afkikan;
create table tm_afkikan(
    kikancd varchar(10) not null,
    hokenkikancd varchar(10) not null,
    kanakikannm varchar(100) not null,
    kikannm varchar(40) not null,
    yubin varchar(7) not null,
    adrs varchar(84) not null,
    katagaki varchar(300),
    tel varchar(15),
    fax varchar(15),
    syozokuisikai varchar(2),
    stopflg boolean not null default false,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(kikancd)
);
comment on table tm_afkikan is '医療機関マスタ';
comment on column tm_afkikan.kikancd is '医療機関コード（自治体独自）';
comment on column tm_afkikan.hokenkikancd is '保険医療機関コード';
comment on column tm_afkikan.kanakikannm is '医療機関名カナ';
comment on column tm_afkikan.kikannm is '医療機関名';
comment on column tm_afkikan.yubin is '郵便番号';
comment on column tm_afkikan.adrs is '住所';
comment on column tm_afkikan.katagaki is '方書';
comment on column tm_afkikan.tel is '電話番号';
comment on column tm_afkikan.fax is 'FAX番号';
comment on column tm_afkikan.syozokuisikai is '所属医師会';
comment on column tm_afkikan.stopflg is '使用停止フラグ';
comment on column tm_afkikan.reguserid is '登録ユーザーID';
comment on column tm_afkikan.regdttm is '登録日時';
comment on column tm_afkikan.upduserid is '更新ユーザーID';
comment on column tm_afkikan.upddttm is '更新日時';

--医療機関サブマスタ
drop table if exists tm_afkikan_sub;
create table tm_afkikan_sub(
    kikancd varchar(10) not null,
    jissijigyo varchar(5) not null,
primary key(kikancd,jissijigyo)
);
comment on table tm_afkikan_sub is '医療機関サブマスタ';
comment on column tm_afkikan_sub.kikancd is '医療機関コード（自治体独自）';
comment on column tm_afkikan_sub.jissijigyo is '医療機関・事業従事者（担当者）事業コード';

--機能マスタ
drop table if exists tm_afkino;
create table tm_afkino(
    kinoid varchar(10) not null,
    hyojinm varchar(30) not null,
    programid varchar(100),
    hanyokbn varchar(20),
primary key(kinoid)
);
comment on table tm_afkino is '機能マスタ';
comment on column tm_afkino.kinoid is '機能ID';
comment on column tm_afkino.hyojinm is '表示名称';
comment on column tm_afkino.programid is 'プログラムID（共用）';
comment on column tm_afkino.hanyokbn is '汎用区分';

--名称マスタ
drop table if exists tm_afmeisyo;
create table tm_afmeisyo(
    nmmaincd varchar(4) not null,
    nmsubcd integer not null,
    nmcd varchar(20) not null,
    nm varchar(100) not null,
    kananm varchar(100),
    shortnm varchar(50),
    biko varchar(200),
    hanyokbn1 varchar(1000),
    hanyokbn2 varchar(1000),
    hanyokbn3 varchar(1000),
primary key(nmmaincd,nmsubcd,nmcd)
);
comment on table tm_afmeisyo is '名称マスタ';
comment on column tm_afmeisyo.nmmaincd is '名称メインコード';
comment on column tm_afmeisyo.nmsubcd is '名称サブコード';
comment on column tm_afmeisyo.nmcd is '名称コード';
comment on column tm_afmeisyo.nm is '名称';
comment on column tm_afmeisyo.kananm is 'カナ名称';
comment on column tm_afmeisyo.shortnm is '略称';
comment on column tm_afmeisyo.biko is '備考';
comment on column tm_afmeisyo.hanyokbn1 is '汎用区分1';
comment on column tm_afmeisyo.hanyokbn2 is '汎用区分2';
comment on column tm_afmeisyo.hanyokbn3 is '汎用区分3';

--名称メインマスタ
drop table if exists tm_afmeisyo_main;
create table tm_afmeisyo_main(
    nmmaincd varchar(4) not null,
    nmsubcd integer not null,
    nmsubcdnm varchar(100) not null,
    kananm varchar(100),
    shortnm varchar(50),
    keta integer,
    biko varchar(200),
primary key(nmmaincd,nmsubcd)
);
comment on table tm_afmeisyo_main is '名称メインマスタ';
comment on column tm_afmeisyo_main.nmmaincd is '名称メインコード';
comment on column tm_afmeisyo_main.nmsubcd is '名称サブコード';
comment on column tm_afmeisyo_main.nmsubcdnm is '名称サブコード名称';
comment on column tm_afmeisyo_main.kananm is 'カナ名称';
comment on column tm_afmeisyo_main.shortnm is '略称';
comment on column tm_afmeisyo_main.keta is '桁数';
comment on column tm_afmeisyo_main.biko is '備考';

--メニューマスタ
drop table if exists tm_afmenu;
create table tm_afmenu(
    kinoid varchar(10) not null,
    oyamenuid varchar(7) not null,
    orderseq smallint not null,
    paramkeisyoflg boolean not null default false,
    addctrlflg boolean not null default false,
    updctrlflg boolean not null default false,
    delctrlflg boolean not null default false,
    pnousectrlflg boolean not null default false,
primary key(kinoid)
);
comment on table tm_afmenu is 'メニューマスタ';
comment on column tm_afmenu.kinoid is '機能ID';
comment on column tm_afmenu.oyamenuid is '親メニューID';
comment on column tm_afmenu.orderseq is '並びシーケンス';
comment on column tm_afmenu.paramkeisyoflg is '検索パラメーター継承フラグ';
comment on column tm_afmenu.addctrlflg is '追加権限制御フラグ';
comment on column tm_afmenu.updctrlflg is '修正権限制御フラグ';
comment on column tm_afmenu.delctrlflg is '削除権限制御フラグ';
comment on column tm_afmenu.pnousectrlflg is '個人番号利用権限制御フラグ';

--メッセージコントロールマスタ
drop table if exists tm_afmsgctrl;
create table tm_afmsgctrl(
    ctrlmsgid varchar(30) not null,
    ctrlmsgnm varchar(100) not null,
    msgkbn smallint not null,
    errormsgid varchar(10) not null,
    alertmsgid varchar(10) not null,
    biko varchar(200),
primary key(ctrlmsgid)
);
comment on table tm_afmsgctrl is 'メッセージコントロールマスタ';
comment on column tm_afmsgctrl.ctrlmsgid is 'コントロールメッセージID';
comment on column tm_afmsgctrl.ctrlmsgnm is 'コントロールメッセージ名';
comment on column tm_afmsgctrl.msgkbn is 'メッセージ区分';
comment on column tm_afmsgctrl.errormsgid is 'エラーメッセージID';
comment on column tm_afmsgctrl.alertmsgid is 'アラートメッセージID';
comment on column tm_afmsgctrl.biko is '備考';

--市区町村マスタ
drop table if exists tm_afsikutyoson;
create table tm_afsikutyoson(
    sikucd varchar(6) not null,
    todofukennm varchar(4) not null,
    todofukennm_kana varchar(50) not null,
    todofukennm_eiji varchar(50) not null,
    gunnm varchar(50),
    gunnm_kana varchar(50),
    gunnm_eiji varchar(50),
    sikunm varchar(50) not null,
    sikunm_kana varchar(50) not null,
    sikunm_eiji varchar(50) not null,
    seireisikunm varchar(50),
    seireisikunm_kana varchar(50),
    seireisikunm_eiji varchar(50),
    koryokuhasseiymd varchar(10) not null,
    haisiymd varchar(10) not null,
    biko varchar(200),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(sikucd)
);
comment on table tm_afsikutyoson is '市区町村マスタ';
comment on column tm_afsikutyoson.sikucd is '市区町村コード';
comment on column tm_afsikutyoson.todofukennm is '都道府県名';
comment on column tm_afsikutyoson.todofukennm_kana is '都道府県名_カナ';
comment on column tm_afsikutyoson.todofukennm_eiji is '都道府県名_英字';
comment on column tm_afsikutyoson.gunnm is '郡名';
comment on column tm_afsikutyoson.gunnm_kana is '郡名_カナ';
comment on column tm_afsikutyoson.gunnm_eiji is '郡名_英字';
comment on column tm_afsikutyoson.sikunm is '市区町村名';
comment on column tm_afsikutyoson.sikunm_kana is '市区町村名_カナ';
comment on column tm_afsikutyoson.sikunm_eiji is '市区町村名_英字';
comment on column tm_afsikutyoson.seireisikunm is '政令市区名';
comment on column tm_afsikutyoson.seireisikunm_kana is '政令市区名_カナ';
comment on column tm_afsikutyoson.seireisikunm_eiji is '政令市区名_英字';
comment on column tm_afsikutyoson.koryokuhasseiymd is '効力発生日';
comment on column tm_afsikutyoson.haisiymd is '廃止日';
comment on column tm_afsikutyoson.biko is '備考';
comment on column tm_afsikutyoson.reguserid is '登録ユーザーID';
comment on column tm_afsikutyoson.regdttm is '登録日時';
comment on column tm_afsikutyoson.upduserid is '更新ユーザーID';
comment on column tm_afsikutyoson.upddttm is '更新日時';

--事業従事者（担当者）情報マスタ
drop table if exists tm_afstaff;
create table tm_afstaff(
    staffid varchar(10) not null,
    staffsimei varchar(100) not null,
    kanastaffsimei varchar(100) not null,
    syokusyu varchar(2) not null,
    katudokbn varchar(1) not null,
    syokuinflg boolean not null default true,
    stopflg boolean not null default false,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(staffid)
);
comment on table tm_afstaff is '事業従事者（担当者）情報マスタ';
comment on column tm_afstaff.staffid is '事業従事者ID';
comment on column tm_afstaff.staffsimei is '事業従事者氏名';
comment on column tm_afstaff.kanastaffsimei is '事業従事者カナ氏名';
comment on column tm_afstaff.syokusyu is '職種';
comment on column tm_afstaff.katudokbn is '活動区分';
comment on column tm_afstaff.syokuinflg is '職員フラグ';
comment on column tm_afstaff.stopflg is '使用停止フラグ';
comment on column tm_afstaff.reguserid is '登録ユーザーID';
comment on column tm_afstaff.regdttm is '登録日時';
comment on column tm_afstaff.upduserid is '更新ユーザーID';
comment on column tm_afstaff.upddttm is '更新日時';

--事業従事者（担当者）所属機関
drop table if exists tm_afstaff_kikan;
create table tm_afstaff_kikan(
    staffid varchar(10) not null,
    kikancd varchar(10) not null,
primary key(staffid,kikancd)
);
comment on table tm_afstaff_kikan is '事業従事者（担当者）所属機関';
comment on column tm_afstaff_kikan.staffid is '事業従事者ID';
comment on column tm_afstaff_kikan.kikancd is '医療機関コード（自治体独自）';

--事業従事者（担当者）サブマスタ
drop table if exists tm_afstaff_sub;
create table tm_afstaff_sub(
    staffid varchar(10) not null,
    jissijigyo varchar(5) not null,
primary key(staffid,jissijigyo)
);
comment on table tm_afstaff_sub is '事業従事者（担当者）サブマスタ';
comment on column tm_afstaff_sub.staffid is '事業従事者ID';
comment on column tm_afstaff_sub.jissijigyo is '医療機関・事業従事者（担当者）事業コード';

--所属グループマスタ
drop table if exists tm_afsyozoku;
create table tm_afsyozoku(
    syozokucd varchar(3) not null,
    syozokunm varchar(50) not null,
    kanrisyaflg boolean not null default false,
    pnoeditflg boolean not null default false,
    alertviewflg boolean not null default false,
    stopflg boolean not null default false,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(syozokucd)
);
comment on table tm_afsyozoku is '所属グループマスタ';
comment on column tm_afsyozoku.syozokucd is '所属グループコード';
comment on column tm_afsyozoku.syozokunm is '所属グループ名';
comment on column tm_afsyozoku.kanrisyaflg is '管理者フラグ';
comment on column tm_afsyozoku.pnoeditflg is '個人番号操作権限付与フラグ';
comment on column tm_afsyozoku.alertviewflg is '警告参照区分';
comment on column tm_afsyozoku.stopflg is '使用停止フラグ';
comment on column tm_afsyozoku.reguserid is '登録ユーザーID';
comment on column tm_afsyozoku.regdttm is '登録日時';
comment on column tm_afsyozoku.upduserid is '更新ユーザーID';
comment on column tm_afsyozoku.upddttm is '更新日時';

--地区情報マスタ
drop table if exists tm_aftiku;
create table tm_aftiku(
    tikukbn varchar(2) not null,
    tikucd varchar(12) not null,
    tikunm varchar(100) not null,
    kanatikunm varchar(100) not null,
    stopflg boolean not null default false,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(tikukbn,tikucd)
);
comment on table tm_aftiku is '地区情報マスタ';
comment on column tm_aftiku.tikukbn is '地区区分';
comment on column tm_aftiku.tikucd is '地区コード';
comment on column tm_aftiku.tikunm is '地区名';
comment on column tm_aftiku.kanatikunm is '地区名（カナ）';
comment on column tm_aftiku.stopflg is '使用停止フラグ';
comment on column tm_aftiku.reguserid is '登録ユーザーID';
comment on column tm_aftiku.regdttm is '登録日時';
comment on column tm_aftiku.upduserid is '更新ユーザーID';
comment on column tm_aftiku.upddttm is '更新日時';

--地区情報サブマスタ
drop table if exists tm_aftiku_sub;
create table tm_aftiku_sub(
    tikukbn varchar(2) not null,
    tikucd varchar(12) not null,
    staffid varchar(10) not null,
primary key(tikukbn,tikucd,staffid)
);
comment on table tm_aftiku_sub is '地区情報サブマスタ';
comment on column tm_aftiku_sub.tikukbn is '地区区分';
comment on column tm_aftiku_sub.tikucd is '地区コード';
comment on column tm_aftiku_sub.staffid is '地区担当者';

--町字マスタ
drop table if exists tm_aftyoaza;
create table tm_aftyoaza(
    sikucd varchar(6) not null,
    tyoazaid varchar(7) not null,
    tyoazakbn varchar(1),
    oazatyonm varchar(120),
    oazatyonm_kana varchar(120),
    oazatyonm_eiji varchar(120),
    tyomeinm varchar(120),
    tyomeinm_kana varchar(120),
    tyomeinm_suji varchar(20),
    koazanm varchar(120),
    koazanm_kana varchar(120),
    koazanm_eiji varchar(50),
    jukyoflg varchar(1) not null,
    jukyocd varchar(1),
    oazatyo_tusyoflg varchar(1),
    koaza_tusyoflg varchar(1),
    oazatyo_gaijiflg varchar(1),
    koaza_gaijiflg varchar(1),
    statusflg varchar(1),
    kibanflg varchar(1),
    koryokuhasseiymd varchar(10),
    haisiymd varchar(10),
    siryocd varchar(2),
    yubin varchar(7),
    biko varchar(200),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(sikucd,tyoazaid)
);
comment on table tm_aftyoaza is '町字マスタ';
comment on column tm_aftyoaza.sikucd is '市区町村コード';
comment on column tm_aftyoaza.tyoazaid is '町字ID';
comment on column tm_aftyoaza.tyoazakbn is '町字区分コード';
comment on column tm_aftyoaza.oazatyonm is '大字・町名';
comment on column tm_aftyoaza.oazatyonm_kana is '大字・町名_カナ';
comment on column tm_aftyoaza.oazatyonm_eiji is '大字・町名_英字';
comment on column tm_aftyoaza.tyomeinm is '丁目名';
comment on column tm_aftyoaza.tyomeinm_kana is '丁目名_カナ';
comment on column tm_aftyoaza.tyomeinm_suji is '丁目名_数字';
comment on column tm_aftyoaza.koazanm is '小字名';
comment on column tm_aftyoaza.koazanm_kana is '小字名_カナ';
comment on column tm_aftyoaza.koazanm_eiji is '小字名_英字';
comment on column tm_aftyoaza.jukyoflg is '住居表示フラグ';
comment on column tm_aftyoaza.jukyocd is '住居表示方式コード';
comment on column tm_aftyoaza.oazatyo_tusyoflg is '大字・町_通称フラグ';
comment on column tm_aftyoaza.koaza_tusyoflg is '小字_通称フラグ';
comment on column tm_aftyoaza.oazatyo_gaijiflg is '大字・町_外字フラグ';
comment on column tm_aftyoaza.koaza_gaijiflg is '小字_外字フラグ';
comment on column tm_aftyoaza.statusflg is '状態フラグ';
comment on column tm_aftyoaza.kibanflg is '起番フラグ';
comment on column tm_aftyoaza.koryokuhasseiymd is '効力発生日';
comment on column tm_aftyoaza.haisiymd is '廃止日';
comment on column tm_aftyoaza.siryocd is '原典資料コード';
comment on column tm_aftyoaza.yubin is '郵便番号';
comment on column tm_aftyoaza.biko is '備考';
comment on column tm_aftyoaza.reguserid is '登録ユーザーID';
comment on column tm_aftyoaza.regdttm is '登録日時';
comment on column tm_aftyoaza.upduserid is '更新ユーザーID';
comment on column tm_aftyoaza.upddttm is '更新日時';

--ユーザーマスタ
drop table if exists tm_afuser;
create table tm_afuser(
    userid varchar(10) not null,
    pword varchar(64) not null,
    usernm varchar(50) not null,
    syozokucd varchar(3),
    errorkaisu smallint,
    yukoymdf varchar(10) not null,
    yukoymdt varchar(10) not null,
    pwordhenkoymd varchar(10) not null,
    kanrisyaflg boolean not null default false,
    pnoeditflg boolean not null default false,
    alertviewflg boolean not null default false,
    authsetflg boolean not null default false,
    kanrisyakeisyoflg boolean not null default true,
    pnoeditkeisyoflg boolean not null default true,
    alertviewkeisyoflg boolean not null default true,
    authsisyokeisyoflg boolean not null default true,
    stopflg boolean not null default false,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(userid)
);
comment on table tm_afuser is 'ユーザーマスタ';
comment on column tm_afuser.userid is 'ユーザーID';
comment on column tm_afuser.pword is 'パスワード';
comment on column tm_afuser.usernm is 'ユーザー名';
comment on column tm_afuser.syozokucd is '所属グループコード';
comment on column tm_afuser.errorkaisu is 'ログインエラー回数';
comment on column tm_afuser.yukoymdf is '有効年月日（開始）';
comment on column tm_afuser.yukoymdt is '有効年月日（終了）';
comment on column tm_afuser.pwordhenkoymd is 'パスワード変更年月日';
comment on column tm_afuser.kanrisyaflg is '管理者フラグ';
comment on column tm_afuser.pnoeditflg is '個人番号操作権限付与フラグ';
comment on column tm_afuser.alertviewflg is '警告参照フラグ';
comment on column tm_afuser.authsetflg is '権限設定フラグ';
comment on column tm_afuser.kanrisyakeisyoflg is '管理者継承フラグ';
comment on column tm_afuser.pnoeditkeisyoflg is '個人番号操作権限付与継承フラグ';
comment on column tm_afuser.alertviewkeisyoflg is '警告参照継承フラグ';
comment on column tm_afuser.authsisyokeisyoflg is '部署（支所）別更新権限継承フラグ';
comment on column tm_afuser.stopflg is '使用停止フラグ';
comment on column tm_afuser.reguserid is '登録ユーザーID';
comment on column tm_afuser.regdttm is '登録日時';
comment on column tm_afuser.upduserid is '更新ユーザーID';
comment on column tm_afuser.upddttm is '更新日時';

--宛名テーブル
drop table if exists tt_afatena;
create table tt_afatena(
    atenano varchar(15) not null,
    setaino varchar(15) not null,
    jutokbn varchar(1) not null,
    juminsyubetu varchar(1) not null,
    juminjotai varchar(1) not null,
    juminkbn varchar(1) not null,
    simei varchar(100) not null,
    simei_kana varchar(100),
    simei_kana_seion varchar(100),
    tusyo varchar(100),
    tusyo_kana varchar(100),
    tusyo_kana_seion varchar(100),
    simei_yusen varchar(200) not null,
    simei_kana_yusen varchar(100),
    simei_kana_yusen_seion varchar(100),
    sex varchar(1) not null,
    bymd varchar(10),
    bymd_fusyoflg boolean,
    bymd_fusyohyoki varchar(72),
    zokucd1 varchar(2),
    zokucd2 varchar(2),
    zokucd3 varchar(2),
    zokucd4 varchar(2),
    zokuhyoki varchar(20) not null,
    adrs_sikucd varchar(6) not null,
    adrs_tyoazacd varchar(7) not null,
    tosi_gyoseikucd varchar(12),
    adrs1 varchar(16) not null,
    adrs2 varchar(470),
    adrs_katagakicd varchar(20),
    adrs_yubin varchar(7) not null,
    tikukanricd1 varchar(12),
    tikukanricd2 varchar(12),
    tikukanricd3 varchar(12),
    tikukanricd4 varchar(12),
    tikukanricd5 varchar(12),
    tikukanricd6 varchar(12),
    tikukanricd7 varchar(12),
    tikukanricd8 varchar(12),
    tikukanricd9 varchar(12),
    tikukanricd10 varchar(12),
    gyoseikucd varchar(12),
    siensotikbn varchar(1),
    personalno varchar(50),
    kazeikbn varchar(1),
    kazeikbn_setai varchar(1),
    hokenkbn varchar(2),
    genmenkbn_tokutei varchar(2),
    genmenkbn_gan varchar(2),
primary key(atenano)
);
comment on table tt_afatena is '宛名テーブル';
comment on column tt_afatena.atenano is '宛名番号';
comment on column tt_afatena.setaino is '世帯番号';
comment on column tt_afatena.jutokbn is '住登区分';
comment on column tt_afatena.juminsyubetu is '住民種別';
comment on column tt_afatena.juminjotai is '住民状態';
comment on column tt_afatena.juminkbn is '住民区分';
comment on column tt_afatena.simei is '氏名';
comment on column tt_afatena.simei_kana is '氏名_フリガナ';
comment on column tt_afatena.simei_kana_seion is '氏名_フリガナ_清音化';
comment on column tt_afatena.tusyo is '通称';
comment on column tt_afatena.tusyo_kana is '通称_フリガナ';
comment on column tt_afatena.tusyo_kana_seion is '通称_フリガナ_清音化';
comment on column tt_afatena.simei_yusen is '氏名_優先';
comment on column tt_afatena.simei_kana_yusen is '氏名_フリガナ_優先';
comment on column tt_afatena.simei_kana_yusen_seion is '氏名_フリガナ_優先_清音化';
comment on column tt_afatena.sex is '性別';
comment on column tt_afatena.bymd is '生年月日';
comment on column tt_afatena.bymd_fusyoflg is '生年月日_不詳フラグ';
comment on column tt_afatena.bymd_fusyohyoki is '生年月日_不詳表記';
comment on column tt_afatena.zokucd1 is '続柄コード1';
comment on column tt_afatena.zokucd2 is '続柄コード2';
comment on column tt_afatena.zokucd3 is '続柄コード3';
comment on column tt_afatena.zokucd4 is '続柄コード4';
comment on column tt_afatena.zokuhyoki is '続柄表記';
comment on column tt_afatena.adrs_sikucd is '住所_市区町村コード';
comment on column tt_afatena.adrs_tyoazacd is '住所_町字コード';
comment on column tt_afatena.tosi_gyoseikucd is '指定都市_行政区等コード';
comment on column tt_afatena.adrs1 is '住所1';
comment on column tt_afatena.adrs2 is '住所2';
comment on column tt_afatena.adrs_katagakicd is '住所_方書コード';
comment on column tt_afatena.adrs_yubin is '住所_郵便番号';
comment on column tt_afatena.tikukanricd1 is '地区管理コード1';
comment on column tt_afatena.tikukanricd2 is '地区管理コード2';
comment on column tt_afatena.tikukanricd3 is '地区管理コード3';
comment on column tt_afatena.tikukanricd4 is '地区管理コード4';
comment on column tt_afatena.tikukanricd5 is '地区管理コード5';
comment on column tt_afatena.tikukanricd6 is '地区管理コード6';
comment on column tt_afatena.tikukanricd7 is '地区管理コード7';
comment on column tt_afatena.tikukanricd8 is '地区管理コード8';
comment on column tt_afatena.tikukanricd9 is '地区管理コード9';
comment on column tt_afatena.tikukanricd10 is '地区管理コード10';
comment on column tt_afatena.gyoseikucd is '行政区コード';
comment on column tt_afatena.siensotikbn is '支援措置区分';
comment on column tt_afatena.personalno is '個人番号';
comment on column tt_afatena.kazeikbn is '課税非課税区分';
comment on column tt_afatena.kazeikbn_setai is '課税非課税区分（世帯）';
comment on column tt_afatena.hokenkbn is '保険区分';
comment on column tt_afatena.genmenkbn_tokutei is '減免区分（特定健診）';
comment on column tt_afatena.genmenkbn_gan is '減免区分（がん検診）';

--宛名番号検索履歴テーブル
drop table if exists tt_afatenalog;
create table tt_afatenalog(
    userid varchar(10) not null,
    kinoid varchar(10) not null,
    atenano varchar(15) not null,
    syoridttm timestamp not null,
primary key(userid,kinoid,atenano)
);
comment on table tt_afatenalog is '宛名番号検索履歴テーブル';
comment on column tt_afatenalog.userid is 'ユーザーID';
comment on column tt_afatenalog.kinoid is '機能ID';
comment on column tt_afatenalog.atenano is '宛名番号';
comment on column tt_afatenalog.syoridttm is '処理日時';

--画面権限テーブル
drop table if exists tt_afauthgamen;
create table tt_afauthgamen(
    rolekbn varchar(1) not null,
    roleid varchar(10) not null,
    kinoid varchar(10) not null,
    programkbn varchar(1) not null,
    addflg boolean not null default false,
    updateflg boolean not null default false,
    deleteflg boolean not null default false,
    personalnoflg boolean not null default false,
    keisyoflg boolean,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(rolekbn,roleid,kinoid)
);
comment on table tt_afauthgamen is '画面権限テーブル';
comment on column tt_afauthgamen.rolekbn is 'ロール区分';
comment on column tt_afauthgamen.roleid is 'ロールID';
comment on column tt_afauthgamen.kinoid is '機能ID';
comment on column tt_afauthgamen.programkbn is 'プログラム区分';
comment on column tt_afauthgamen.addflg is '追加フラグ';
comment on column tt_afauthgamen.updateflg is '修正フラグ';
comment on column tt_afauthgamen.deleteflg is '削除フラグ';
comment on column tt_afauthgamen.personalnoflg is '個人番号利用フラグ';
comment on column tt_afauthgamen.keisyoflg is '継承フラグ';
comment on column tt_afauthgamen.reguserid is '登録ユーザーID';
comment on column tt_afauthgamen.regdttm is '登録日時';
comment on column tt_afauthgamen.upduserid is '更新ユーザーID';
comment on column tt_afauthgamen.upddttm is '更新日時';

--帳票権限テーブル
drop table if exists tt_afauthreport;
create table tt_afauthreport(
    rolekbn varchar(1) not null,
    roleid varchar(10) not null,
    repgroupid varchar(5) not null,
    pdfoutflg boolean not null default false,
    exceloutflg boolean not null default false,
    othersflg boolean not null default false,
    keisyoflg boolean,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(rolekbn,roleid,repgroupid)
);
comment on table tt_afauthreport is '帳票権限テーブル';
comment on column tt_afauthreport.rolekbn is 'ロール区分';
comment on column tt_afauthreport.roleid is 'ロールID';
comment on column tt_afauthreport.repgroupid is 'グループID';
comment on column tt_afauthreport.pdfoutflg is 'PDF出力フラグ';
comment on column tt_afauthreport.exceloutflg is 'EXCEL出力フラグ';
comment on column tt_afauthreport.othersflg is 'その他出力フラグ';
comment on column tt_afauthreport.keisyoflg is '継承フラグ';
comment on column tt_afauthreport.reguserid is '登録ユーザーID';
comment on column tt_afauthreport.regdttm is '登録日時';
comment on column tt_afauthreport.upduserid is '更新ユーザーID';
comment on column tt_afauthreport.upddttm is '更新日時';

--部署（支所）別更新権限テーブル
drop table if exists tt_afauthsisyo;
create table tt_afauthsisyo(
    rolekbn varchar(1) not null,
    roleid varchar(10) not null,
    sisyocd varchar(3) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(rolekbn,roleid,sisyocd)
);
comment on table tt_afauthsisyo is '部署（支所）別更新権限テーブル';
comment on column tt_afauthsisyo.rolekbn is 'ロール区分';
comment on column tt_afauthsisyo.roleid is 'ロールID';
comment on column tt_afauthsisyo.sisyocd is '部署（支所）コード';
comment on column tt_afauthsisyo.reguserid is '登録ユーザーID';
comment on column tt_afauthsisyo.regdttm is '登録日時';
comment on column tt_afauthsisyo.upduserid is '更新ユーザーID';
comment on column tt_afauthsisyo.upddttm is '更新日時';

--バッチログテーブル
drop table if exists tt_afbatchlog;
create table tt_afbatchlog(
    batchlogseq bigserial not null,
    sessionseq bigint not null,
    syoridttmf timestamp not null,
    syoridttmt timestamp not null,
    msg varchar,
    pram varchar,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
primary key(batchlogseq)
);
comment on table tt_afbatchlog is 'バッチログテーブル';
comment on column tt_afbatchlog.batchlogseq is 'バッチログシーケンス';
comment on column tt_afbatchlog.sessionseq is 'セッションシーケンス';
comment on column tt_afbatchlog.syoridttmf is '処理日時（開始）';
comment on column tt_afbatchlog.syoridttmt is '処理日時（終了）';
comment on column tt_afbatchlog.msg is 'メッセージ';
comment on column tt_afbatchlog.pram is 'パラメータ';
comment on column tt_afbatchlog.reguserid is '登録ユーザーID';
comment on column tt_afbatchlog.regdttm is '登録日時';

--共通ドキュメントテーブル
drop table if exists tt_afcomdoc;
create table tt_afcomdoc(
    docseq bigserial not null,
    filenm varchar(255) not null,
    jigyocd varchar(5),
    title varchar(100),
    filetype smallint not null,
    filesize integer not null,
    filedata bytea not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(docseq)
);
comment on table tt_afcomdoc is '共通ドキュメントテーブル';
comment on column tt_afcomdoc.docseq is 'ドキュメントシーケンス';
comment on column tt_afcomdoc.filenm is 'ファイル名';
comment on column tt_afcomdoc.jigyocd is '事業コード';
comment on column tt_afcomdoc.title is 'タイトル';
comment on column tt_afcomdoc.filetype is 'ファイルタイプ';
comment on column tt_afcomdoc.filesize is 'ファイルサイズ';
comment on column tt_afcomdoc.filedata is 'ファイルデータ';
comment on column tt_afcomdoc.regsisyo is '登録支所';
comment on column tt_afcomdoc.reguserid is '登録ユーザーID';
comment on column tt_afcomdoc.regdttm is '登録日時';
comment on column tt_afcomdoc.upduserid is '更新ユーザーID';
comment on column tt_afcomdoc.upddttm is '更新日時';

--詳細条件設定テーブル
drop table if exists tt_affilter;
create table tt_affilter(
    kinoid varchar(10) not null,
    jyokbn varchar(1) not null,
    jyoseq smallint not null,
    hyojinm varchar(150) not null,
    ctrltype varchar(1) not null,
    hyojiflg boolean not null default true,
    sort smallint,
    placeholder varchar(100),
    rangeflg boolean not null default false,
    sethanyokbn1 varchar(100) not null,
    sethanyokbn2 varchar(100),
    sethanyokbn3 varchar(100),
    sethanyokbn4 varchar(100),
    sethanyokbn5 varchar(100),
    getkbn varchar(1) not null,
    tablenm1 varchar(100) not null,
    komokunm1 varchar(100) not null,
    keycd1 varchar(100),
    itemcd1 varchar(100),
    tablenm2 varchar(100),
    komokunm2 varchar(100),
    keycd2 varchar(100),
    itemcd2 varchar(100),
    tablenm3 varchar(100),
    komokunm3 varchar(100),
    keycd3 varchar(100),
    itemcd3 varchar(100),
primary key(kinoid,jyokbn,jyoseq)
);
comment on table tt_affilter is '詳細条件設定テーブル';
comment on column tt_affilter.kinoid is '機能ID';
comment on column tt_affilter.jyokbn is '条件区分';
comment on column tt_affilter.jyoseq is '条件シーケンス';
comment on column tt_affilter.hyojinm is '詳細条件表示名';
comment on column tt_affilter.ctrltype is 'コントローラータイプ';
comment on column tt_affilter.hyojiflg is '表示フラグ';
comment on column tt_affilter.sort is '並び順';
comment on column tt_affilter.placeholder is '入力説明';
comment on column tt_affilter.rangeflg is '範囲フラグ';
comment on column tt_affilter.sethanyokbn1 is '設定用汎用区分1';
comment on column tt_affilter.sethanyokbn2 is '設定用汎用区分2';
comment on column tt_affilter.sethanyokbn3 is '設定用汎用区分3';
comment on column tt_affilter.sethanyokbn4 is '設定用汎用区分4';
comment on column tt_affilter.sethanyokbn5 is '設定用汎用区分5';
comment on column tt_affilter.getkbn is '検索対象データ取得区分';
comment on column tt_affilter.tablenm1 is 'テーブル物理名1';
comment on column tt_affilter.komokunm1 is '項目物理名1';
comment on column tt_affilter.keycd1 is '主キーコード1';
comment on column tt_affilter.itemcd1 is '項目コード1';
comment on column tt_affilter.tablenm2 is 'テーブル物理名2';
comment on column tt_affilter.komokunm2 is '項目物理名2';
comment on column tt_affilter.keycd2 is '主キーコード2';
comment on column tt_affilter.itemcd2 is '項目コード2';
comment on column tt_affilter.tablenm3 is 'テーブル物理名3';
comment on column tt_affilter.komokunm3 is '項目物理名3';
comment on column tt_affilter.keycd3 is '主キーコード3';
comment on column tt_affilter.itemcd3 is '項目コード3';

--外部連携処理結果履歴テーブル
drop table if exists tt_afgaibulog;
create table tt_afgaibulog(
    gaibulogseq bigserial not null,
    sessionseq bigint not null,
    syoridttmf timestamp not null,
    syoridttmt timestamp not null,
    msg varchar,
    ipadrs varchar(15),
    kbn varchar(1) not null,
    kbn2 varchar(1) not null,
    kbn3 varchar(1) not null,
    apidata varchar,
    filenm varchar(200),
    filetype smallint,
    filesize integer,
    filedata bytea,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
primary key(gaibulogseq)
);
comment on table tt_afgaibulog is '外部連携処理結果履歴テーブル';
comment on column tt_afgaibulog.gaibulogseq is '外部連携ログシーケンス';
comment on column tt_afgaibulog.sessionseq is 'セッションシーケンス';
comment on column tt_afgaibulog.syoridttmf is '処理日時（開始）';
comment on column tt_afgaibulog.syoridttmt is '処理日時（終了）';
comment on column tt_afgaibulog.msg is 'メッセージ';
comment on column tt_afgaibulog.ipadrs is 'IPアドレス（実行）';
comment on column tt_afgaibulog.kbn is '連携区分';
comment on column tt_afgaibulog.kbn2 is '連携方式';
comment on column tt_afgaibulog.kbn3 is '処理区分';
comment on column tt_afgaibulog.apidata is 'API連携データ';
comment on column tt_afgaibulog.filenm is 'ファイル名';
comment on column tt_afgaibulog.filetype is 'ファイルタイプ';
comment on column tt_afgaibulog.filesize is 'ファイルサイズ';
comment on column tt_afgaibulog.filedata is 'ファイルデータ';
comment on column tt_afgaibulog.reguserid is '登録ユーザーID';
comment on column tt_afgaibulog.regdttm is '登録日時';

--お知らせテーブル
drop table if exists tt_afinfo;
create table tt_afinfo(
    infoseq bigserial not null,
    juyodo varchar(2) not null,
    kigenymd varchar(10) not null,
    syosai varchar(2000),
    atesakiflg boolean not null,
    atesaki varchar,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(infoseq)
);
comment on table tt_afinfo is 'お知らせテーブル';
comment on column tt_afinfo.infoseq is 'お知らせシーケンス';
comment on column tt_afinfo.juyodo is '重要度';
comment on column tt_afinfo.kigenymd is '掲示期限年月日';
comment on column tt_afinfo.syosai is '詳細';
comment on column tt_afinfo.atesakiflg is '宛先指定フラグ';
comment on column tt_afinfo.atesaki is '宛先';
comment on column tt_afinfo.reguserid is '登録ユーザーID';
comment on column tt_afinfo.regdttm is '登録日時';
comment on column tt_afinfo.upduserid is '更新ユーザーID';
comment on column tt_afinfo.upddttm is '更新日時';

--お知らせ確認状態テーブル
drop table if exists tt_afinfo_user;
create table tt_afinfo_user(
    infoseq bigint not null,
    userid varchar(10) not null,
primary key(infoseq,userid)
);
comment on table tt_afinfo_user is 'お知らせ確認状態テーブル';
comment on column tt_afinfo_user.infoseq is 'お知らせシーケンス';
comment on column tt_afinfo_user.userid is 'ユーザーID';

--【住民基本台帳】住民情報テーブル
drop table if exists tt_afjumin;
create table tt_afjumin(
    atenano varchar(15) not null,
    setaino varchar(15) not null,
    juminsyubetu varchar(1) not null,
    juminjotai varchar(1) not null,
    idoymd varchar(10) not null,
    idoymd_fusyoflg boolean not null,
    idoymd_fusyohyoki varchar(72),
    idotodokeymd varchar(10),
    idojiyu varchar(2) not null,
    simei varchar(100) not null,
    simei_gairoma varchar(100),
    simei_gaikanji varchar(100),
    simei_kana varchar(100),
    kyusi varchar(50),
    kyusi_kana varchar(50),
    tusyo varchar(100),
    tusyo_kana varchar(100),
    simeiyusenkbn varchar(2),
    simei_yusen varchar(200) not null,
    simei_kana_yusen varchar(100),
    sex varchar(1) not null,
    sexhyoki varchar(10) not null,
    bymd varchar(10) not null,
    bymd_fusyoflg boolean not null,
    bymd_fusyohyoki varchar(72),
    zokucd1 varchar(2) not null,
    zokucd2 varchar(2),
    zokucd3 varchar(2),
    zokucd4 varchar(2),
    zokuhyoki varchar(20) not null,
    adrs_sikucd varchar(6) not null,
    adrs_tyoazacd varchar(7) not null,
    tosi_gyoseikucd varchar(12),
    adrs_todofuken varchar(4) not null,
    adrs_sikunm varchar(12) not null,
    adrs_tyoaza varchar(120),
    adrs_bantihyoki varchar(50),
    adrs_bantiedanum varchar(30),
    adrs_katagakicd varchar(20),
    adrs_katagaki varchar(300),
    adrs_katagaki_kana varchar(300),
    adrs_yubin varchar(7) not null,
    juymd varchar(10),
    juymd_fusyoflg boolean,
    juymd_fusyohyoki varchar(72),
    tennyumaeadrs_sikucd varchar(6),
    tennyumaeadrs_tyoazacd varchar(7),
    tennyumaeadrs_todofuken varchar(4),
    tennyumaeadrs_sikunm varchar(12),
    tennyumaeadrs_tyoaza varchar(120),
    tennyumaeadrs_bantihyoki varchar(50),
    tennyumaeadrs_katagaki varchar(300),
    tennyumaeadrs_yubin varchar(7),
    tennyumaeadrs_kokunmcd varchar(3),
    tennyumaeadrs_kokunm varchar(200),
    tennyumaeadrs_gaiadrs varchar(300),
    tennyumaeadrs_senusisimei varchar(100),
    tenkyomaeadrs_sikucd varchar(6),
    tenkyomaeadrs_tyoazacd varchar(7),
    tenkyomaeadrs_todofuken varchar(4),
    tenkyomaeadrs_sikunm varchar(12),
    tenkyomaeadrs_tyoaza varchar(120),
    tenkyomaeadrs_bantihyoki varchar(50),
    tenkyomaeadrs_katagakicd varchar(20),
    tenkyomaeadrs_katagaki varchar(300),
    tenkyomaeadrs_katagaki_kana varchar(300),
    tenkyomaeadrs_yubin varchar(7),
    todokeymd varchar(10),
    delidoymd varchar(10),
    delidoymd_fusyoflg boolean,
    delidoymd_fusyohyoki varchar(72),
    tennyututiymd varchar(10),
    tensyutuyoteiadrs_sikucd varchar(6),
    tensyutuyoteiadrs_tyoazacd varchar(7),
    tensyutuyoteiadrs_todofuken varchar(4),
    tensyutuyoteiadrs_sikunm varchar(12),
    tensyutuyoteiadrs_tyoaza varchar(120),
    tensyutuyoteiadrs_bantihyoki varchar(50),
    tensyutuyoteiadrs_katagaki varchar(300),
    tensyutuyoteiadrs_kokunmcd varchar(3),
    tensyutuyoteiadrs_kokunm varchar(200),
    tensyutuyoteiadrs_gaiadrs varchar(300),
    tensyutuyoteiadrs_yubin varchar(7),
    tensyutukakuteiadrs_sikucd varchar(6),
    tensyutukakuteiadrs_tyoazacd varchar(7),
    tensyutukakuteiadrs_todofuken varchar(4),
    tensyutukakuteiadrs_sikunm varchar(12),
    tensyutukakuteiadrs_tyoaza varchar(120),
    tensyutukakuteiadrs_bantihyoki varchar(50),
    tensyutukakuteiadrs_katagaki varchar(300),
    tensyutukakuteiadrs_yubin varchar(7),
    gaijuymd varchar(10),
    gaijuymd_fusyoflg boolean,
    gaijuymd_fusyohyoki varchar(72),
    kokunmcd varchar(3),
    kokunm varchar(200),
    kiteikbn varchar(2),
    zairyucd varchar(3),
    zairyucd_year varchar(2),
    zairyucd_month varchar(2),
    zairyucd_day varchar(3),
    zairyumanryoymd varchar(10),
    tikukanricd1 varchar(12),
    tikukanricd2 varchar(12),
    tikukanricd3 varchar(12),
    tikukanricd4 varchar(12),
    tikukanricd5 varchar(12),
    tikukanricd6 varchar(12),
    tikukanricd7 varchar(12),
    tikukanricd8 varchar(12),
    tikukanricd9 varchar(12),
    tikukanricd10 varchar(12),
    personalno varchar(50),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano)
);
comment on table tt_afjumin is '【住民基本台帳】住民情報テーブル';
comment on column tt_afjumin.atenano is '宛名番号';
comment on column tt_afjumin.setaino is '世帯番号';
comment on column tt_afjumin.juminsyubetu is '住民種別';
comment on column tt_afjumin.juminjotai is '住民状態';
comment on column tt_afjumin.idoymd is '異動年月日';
comment on column tt_afjumin.idoymd_fusyoflg is '異動年月日_不詳フラグ';
comment on column tt_afjumin.idoymd_fusyohyoki is '異動年月日_不詳表記';
comment on column tt_afjumin.idotodokeymd is '異動届出年月日';
comment on column tt_afjumin.idojiyu is '異動事由';
comment on column tt_afjumin.simei is '氏名';
comment on column tt_afjumin.simei_gairoma is '氏名_外国人ローマ字';
comment on column tt_afjumin.simei_gaikanji is '氏名_外国人漢字';
comment on column tt_afjumin.simei_kana is '氏名_フリガナ';
comment on column tt_afjumin.kyusi is '旧氏';
comment on column tt_afjumin.kyusi_kana is '旧氏_フリガナ';
comment on column tt_afjumin.tusyo is '通称';
comment on column tt_afjumin.tusyo_kana is '通称_フリガナ';
comment on column tt_afjumin.simeiyusenkbn is '氏名優先区分';
comment on column tt_afjumin.simei_yusen is '氏名_優先';
comment on column tt_afjumin.simei_kana_yusen is '氏名_フリガナ_優先';
comment on column tt_afjumin.sex is '性別';
comment on column tt_afjumin.sexhyoki is '性別表記';
comment on column tt_afjumin.bymd is '生年月日';
comment on column tt_afjumin.bymd_fusyoflg is '生年月日_不詳フラグ';
comment on column tt_afjumin.bymd_fusyohyoki is '生年月日_不詳表記';
comment on column tt_afjumin.zokucd1 is '続柄コード1';
comment on column tt_afjumin.zokucd2 is '続柄コード2';
comment on column tt_afjumin.zokucd3 is '続柄コード3';
comment on column tt_afjumin.zokucd4 is '続柄コード4';
comment on column tt_afjumin.zokuhyoki is '続柄表記';
comment on column tt_afjumin.adrs_sikucd is '住所_市区町村コード';
comment on column tt_afjumin.adrs_tyoazacd is '住所_町字コード';
comment on column tt_afjumin.tosi_gyoseikucd is '指定都市_行政区等コード';
comment on column tt_afjumin.adrs_todofuken is '住所_都道府県';
comment on column tt_afjumin.adrs_sikunm is '住所_市区郡町村名';
comment on column tt_afjumin.adrs_tyoaza is '住所_町字';
comment on column tt_afjumin.adrs_bantihyoki is '住所_番地号表記';
comment on column tt_afjumin.adrs_bantiedanum is '住所_番地枝番数値';
comment on column tt_afjumin.adrs_katagakicd is '住所_方書コード';
comment on column tt_afjumin.adrs_katagaki is '住所_方書';
comment on column tt_afjumin.adrs_katagaki_kana is '住所_方書_フリガナ';
comment on column tt_afjumin.adrs_yubin is '住所_郵便番号';
comment on column tt_afjumin.juymd is '住民となった年月日';
comment on column tt_afjumin.juymd_fusyoflg is '住民となった年月日_不詳フラグ';
comment on column tt_afjumin.juymd_fusyohyoki is '住民となった年月日_不詳表記';
comment on column tt_afjumin.tennyumaeadrs_sikucd is '転入前住所_市区町村コード';
comment on column tt_afjumin.tennyumaeadrs_tyoazacd is '転入前住所_町字コード';
comment on column tt_afjumin.tennyumaeadrs_todofuken is '転入前住所_都道府県';
comment on column tt_afjumin.tennyumaeadrs_sikunm is '転入前住所_市区郡町村名';
comment on column tt_afjumin.tennyumaeadrs_tyoaza is '転入前住所_町字';
comment on column tt_afjumin.tennyumaeadrs_bantihyoki is '転入前住所_番地号表記';
comment on column tt_afjumin.tennyumaeadrs_katagaki is '転入前住所_方書';
comment on column tt_afjumin.tennyumaeadrs_yubin is '転入前住所_郵便番号';
comment on column tt_afjumin.tennyumaeadrs_kokunmcd is '転入前住所_国名コード';
comment on column tt_afjumin.tennyumaeadrs_kokunm is '転入前住所_国名等';
comment on column tt_afjumin.tennyumaeadrs_gaiadrs is '転入前住所_国外住所';
comment on column tt_afjumin.tennyumaeadrs_senusisimei is '転入前住所_世帯主氏名';
comment on column tt_afjumin.tenkyomaeadrs_sikucd is '転居前住所_市区町村コード';
comment on column tt_afjumin.tenkyomaeadrs_tyoazacd is '転居前住所_町字コード';
comment on column tt_afjumin.tenkyomaeadrs_todofuken is '転居前住所_都道府県';
comment on column tt_afjumin.tenkyomaeadrs_sikunm is '転居前住所_市区郡町村名';
comment on column tt_afjumin.tenkyomaeadrs_tyoaza is '転居前住所_町字';
comment on column tt_afjumin.tenkyomaeadrs_bantihyoki is '転居前住所_番地号表記';
comment on column tt_afjumin.tenkyomaeadrs_katagakicd is '転居前住所_方書コード';
comment on column tt_afjumin.tenkyomaeadrs_katagaki is '転居前住所_方書';
comment on column tt_afjumin.tenkyomaeadrs_katagaki_kana is '転居前住所_方書_フリガナ';
comment on column tt_afjumin.tenkyomaeadrs_yubin is '転居前住所_郵便番号';
comment on column tt_afjumin.todokeymd is '消除の届出年月日';
comment on column tt_afjumin.delidoymd is '消除の異動年月日';
comment on column tt_afjumin.delidoymd_fusyoflg is '消除の異動年月日_不詳フラグ';
comment on column tt_afjumin.delidoymd_fusyohyoki is '消除の異動年月日_不詳表記';
comment on column tt_afjumin.tennyututiymd is '転入通知年月日';
comment on column tt_afjumin.tensyutuyoteiadrs_sikucd is '転出先住所（予定）_市区町村コード';
comment on column tt_afjumin.tensyutuyoteiadrs_tyoazacd is '転出先住所（予定）_町字コード';
comment on column tt_afjumin.tensyutuyoteiadrs_todofuken is '転出先住所（予定）_都道府県';
comment on column tt_afjumin.tensyutuyoteiadrs_sikunm is '転出先住所（予定）_市区郡町村名';
comment on column tt_afjumin.tensyutuyoteiadrs_tyoaza is '転出先住所（予定）_町字';
comment on column tt_afjumin.tensyutuyoteiadrs_bantihyoki is '転出先住所（予定）_番地号表記';
comment on column tt_afjumin.tensyutuyoteiadrs_katagaki is '転出先住所（予定）_方書';
comment on column tt_afjumin.tensyutuyoteiadrs_kokunmcd is '転出先住所（予定）_国名コード';
comment on column tt_afjumin.tensyutuyoteiadrs_kokunm is '転出先住所（予定）_国名等';
comment on column tt_afjumin.tensyutuyoteiadrs_gaiadrs is '転出先住所（予定）_国外住所';
comment on column tt_afjumin.tensyutuyoteiadrs_yubin is '転出先住所（予定）_郵便番号';
comment on column tt_afjumin.tensyutukakuteiadrs_sikucd is '転出先住所（確定）_市区町村コード';
comment on column tt_afjumin.tensyutukakuteiadrs_tyoazacd is '転出先住所（確定）_町字コード';
comment on column tt_afjumin.tensyutukakuteiadrs_todofuken is '転出先住所（確定）_都道府県';
comment on column tt_afjumin.tensyutukakuteiadrs_sikunm is '転出先住所（確定）_市区郡町村名';
comment on column tt_afjumin.tensyutukakuteiadrs_tyoaza is '転出先住所（確定）_町字';
comment on column tt_afjumin.tensyutukakuteiadrs_bantihyoki is '転出先住所（確定）_番地号表記';
comment on column tt_afjumin.tensyutukakuteiadrs_katagaki is '転出先住所（確定）_方書';
comment on column tt_afjumin.tensyutukakuteiadrs_yubin is '転出先住所（確定）_郵便番号';
comment on column tt_afjumin.gaijuymd is '外国人住民となった年月日';
comment on column tt_afjumin.gaijuymd_fusyoflg is '外国人住民となった年月日_不詳フラグ';
comment on column tt_afjumin.gaijuymd_fusyohyoki is '外国人住民となった年月日_不詳表記';
comment on column tt_afjumin.kokunmcd is '国籍等_国名コード';
comment on column tt_afjumin.kokunm is '国籍名等';
comment on column tt_afjumin.kiteikbn is '第30条45規定区分';
comment on column tt_afjumin.zairyucd is '在留資格等コード';
comment on column tt_afjumin.zairyucd_year is '在留期間等コード_年';
comment on column tt_afjumin.zairyucd_month is '在留期間等コード_月';
comment on column tt_afjumin.zairyucd_day is '在留期間等コード_日';
comment on column tt_afjumin.zairyumanryoymd is '在留期間の満了の日';
comment on column tt_afjumin.tikukanricd1 is '地区管理コード1';
comment on column tt_afjumin.tikukanricd2 is '地区管理コード2';
comment on column tt_afjumin.tikukanricd3 is '地区管理コード3';
comment on column tt_afjumin.tikukanricd4 is '地区管理コード4';
comment on column tt_afjumin.tikukanricd5 is '地区管理コード5';
comment on column tt_afjumin.tikukanricd6 is '地区管理コード6';
comment on column tt_afjumin.tikukanricd7 is '地区管理コード7';
comment on column tt_afjumin.tikukanricd8 is '地区管理コード8';
comment on column tt_afjumin.tikukanricd9 is '地区管理コード9';
comment on column tt_afjumin.tikukanricd10 is '地区管理コード10';
comment on column tt_afjumin.personalno is '個人番号';
comment on column tt_afjumin.reguserid is '登録ユーザーID';
comment on column tt_afjumin.regdttm is '登録日時';
comment on column tt_afjumin.upduserid is '更新ユーザーID';
comment on column tt_afjumin.upddttm is '更新日時';

--【住民基本台帳】住民情報履歴テーブル
drop table if exists tt_afjumin_reki;
create table tt_afjumin_reki(
    atenano varchar(15) not null,
    kojinrirekino smallint not null,
    kojinrireki_edano smallint not null,
    setaino varchar(15) not null,
    juminsyubetu varchar(1) not null,
    juminjotai varchar(1) not null,
    idoymd varchar(10) not null,
    idoymd_fusyoflg boolean not null,
    idoymd_fusyohyoki varchar(72),
    idotodokeymd varchar(10),
    idojiyu varchar(2) not null,
    simei varchar(100) not null,
    simei_gairoma varchar(100),
    simei_gaikanji varchar(100),
    simei_kana varchar(100),
    kyusi varchar(50),
    kyusi_kana varchar(50),
    tusyo varchar(100),
    tusyo_kana varchar(100),
    simeiyusenkbn varchar(2),
    simei_yusen varchar(200) not null,
    simei_kana_yusen varchar(100),
    sex varchar(1) not null,
    sexhyoki varchar(10) not null,
    bymd varchar(10) not null,
    bymd_fusyoflg boolean not null,
    bymd_fusyohyoki varchar(72),
    zokucd1 varchar(2) not null,
    zokucd2 varchar(2),
    zokucd3 varchar(2),
    zokucd4 varchar(2),
    zokuhyoki varchar(20) not null,
    adrs_sikucd varchar(6) not null,
    adrs_tyoazacd varchar(7) not null,
    tosi_gyoseikucd varchar(12),
    adrs_todofuken varchar(4) not null,
    adrs_sikunm varchar(12) not null,
    adrs_tyoaza varchar(120),
    adrs_bantihyoki varchar(50),
    adrs_bantiedanum varchar(30),
    adrs_katagakicd varchar(20),
    adrs_katagaki varchar(300),
    adrs_katagaki_kana varchar(300),
    adrs_yubin varchar(7) not null,
    juymd varchar(10),
    juymd_fusyoflg boolean,
    juymd_fusyohyoki varchar(72),
    tennyumaeadrs_sikucd varchar(6),
    tennyumaeadrs_tyoazacd varchar(7),
    tennyumaeadrs_todofuken varchar(4),
    tennyumaeadrs_sikunm varchar(12),
    tennyumaeadrs_tyoaza varchar(120),
    tennyumaeadrs_bantihyoki varchar(50),
    tennyumaeadrs_katagaki varchar(300),
    tennyumaeadrs_yubin varchar(7),
    tennyumaeadrs_kokunmcd varchar(3),
    tennyumaeadrs_kokunm varchar(200),
    tennyumaeadrs_gaiadrs varchar(300),
    tennyumaeadrs_senusisimei varchar(100),
    tenkyomaeadrs_sikucd varchar(6),
    tenkyomaeadrs_tyoazacd varchar(7),
    tenkyomaeadrs_todofuken varchar(4),
    tenkyomaeadrs_sikunm varchar(12),
    tenkyomaeadrs_tyoaza varchar(120),
    tenkyomaeadrs_bantihyoki varchar(50),
    tenkyomaeadrs_katagakicd varchar(20),
    tenkyomaeadrs_katagaki varchar(300),
    tenkyomaeadrs_katagaki_kana varchar(300),
    tenkyomaeadrs_yubin varchar(7),
    todokeymd varchar(10),
    delidoymd varchar(10),
    delidoymd_fusyoflg boolean,
    delidoymd_fusyohyoki varchar(72),
    tennyututiymd varchar(10),
    tensyutuyoteiadrs_sikucd varchar(6),
    tensyutuyoteiadrs_tyoazacd varchar(7),
    tensyutuyoteiadrs_todofuken varchar(4),
    tensyutuyoteiadrs_sikunm varchar(12),
    tensyutuyoteiadrs_tyoaza varchar(120),
    tensyutuyoteiadrs_bantihyoki varchar(50),
    tensyutuyoteiadrs_katagaki varchar(300),
    tensyutuyoteiadrs_kokunmcd varchar(3),
    tensyutuyoteiadrs_kokunm varchar(200),
    tensyutuyoteiadrs_gaiadrs varchar(300),
    tensyutuyoteiadrs_yubin varchar(7),
    tensyutukakuteiadrs_sikucd varchar(6),
    tensyutukakuteiadrs_tyoazacd varchar(7),
    tensyutukakuteiadrs_todofuken varchar(4),
    tensyutukakuteiadrs_sikunm varchar(12),
    tensyutukakuteiadrs_tyoaza varchar(120),
    tensyutukakuteiadrs_bantihyoki varchar(50),
    tensyutukakuteiadrs_katagaki varchar(300),
    tensyutukakuteiadrs_yubin varchar(7),
    gaijuymd varchar(10),
    gaijuymd_fusyoflg boolean,
    gaijuymd_fusyohyoki varchar(72),
    kokunmcd varchar(3),
    kokunm varchar(200),
    kiteikbn varchar(2),
    zairyucd varchar(3),
    zairyucd_year varchar(2),
    zairyucd_month varchar(2),
    zairyucd_day varchar(3),
    zairyumanryoymd varchar(10),
    tikukanricd1 varchar(12),
    tikukanricd2 varchar(12),
    tikukanricd3 varchar(12),
    tikukanricd4 varchar(12),
    tikukanricd5 varchar(12),
    tikukanricd6 varchar(12),
    tikukanricd7 varchar(12),
    tikukanricd8 varchar(12),
    tikukanricd9 varchar(12),
    tikukanricd10 varchar(12),
    personalno varchar(50),
    renkeimotosousauserid varchar(10) not null,
    renkeimotosousadttm timestamp not null,
    saisinflg boolean not null default true,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,kojinrirekino,kojinrireki_edano)
);
comment on table tt_afjumin_reki is '【住民基本台帳】住民情報履歴テーブル';
comment on column tt_afjumin_reki.atenano is '宛名番号';
comment on column tt_afjumin_reki.kojinrirekino is '個人履歴番号';
comment on column tt_afjumin_reki.kojinrireki_edano is '個人履歴番号_枝番号';
comment on column tt_afjumin_reki.setaino is '世帯番号';
comment on column tt_afjumin_reki.juminsyubetu is '住民種別';
comment on column tt_afjumin_reki.juminjotai is '住民状態';
comment on column tt_afjumin_reki.idoymd is '異動年月日';
comment on column tt_afjumin_reki.idoymd_fusyoflg is '異動年月日_不詳フラグ';
comment on column tt_afjumin_reki.idoymd_fusyohyoki is '異動年月日_不詳表記';
comment on column tt_afjumin_reki.idotodokeymd is '異動届出年月日';
comment on column tt_afjumin_reki.idojiyu is '異動事由';
comment on column tt_afjumin_reki.simei is '氏名';
comment on column tt_afjumin_reki.simei_gairoma is '氏名_外国人ローマ字';
comment on column tt_afjumin_reki.simei_gaikanji is '氏名_外国人漢字';
comment on column tt_afjumin_reki.simei_kana is '氏名_フリガナ';
comment on column tt_afjumin_reki.kyusi is '旧氏';
comment on column tt_afjumin_reki.kyusi_kana is '旧氏_フリガナ';
comment on column tt_afjumin_reki.tusyo is '通称';
comment on column tt_afjumin_reki.tusyo_kana is '通称_フリガナ';
comment on column tt_afjumin_reki.simeiyusenkbn is '氏名優先区分';
comment on column tt_afjumin_reki.simei_yusen is '氏名_優先';
comment on column tt_afjumin_reki.simei_kana_yusen is '氏名_フリガナ_優先';
comment on column tt_afjumin_reki.sex is '性別';
comment on column tt_afjumin_reki.sexhyoki is '性別表記';
comment on column tt_afjumin_reki.bymd is '生年月日';
comment on column tt_afjumin_reki.bymd_fusyoflg is '生年月日_不詳フラグ';
comment on column tt_afjumin_reki.bymd_fusyohyoki is '生年月日_不詳表記';
comment on column tt_afjumin_reki.zokucd1 is '続柄コード1';
comment on column tt_afjumin_reki.zokucd2 is '続柄コード2';
comment on column tt_afjumin_reki.zokucd3 is '続柄コード3';
comment on column tt_afjumin_reki.zokucd4 is '続柄コード4';
comment on column tt_afjumin_reki.zokuhyoki is '続柄表記';
comment on column tt_afjumin_reki.adrs_sikucd is '住所_市区町村コード';
comment on column tt_afjumin_reki.adrs_tyoazacd is '住所_町字コード';
comment on column tt_afjumin_reki.tosi_gyoseikucd is '指定都市_行政区等コード';
comment on column tt_afjumin_reki.adrs_todofuken is '住所_都道府県';
comment on column tt_afjumin_reki.adrs_sikunm is '住所_市区郡町村名';
comment on column tt_afjumin_reki.adrs_tyoaza is '住所_町字';
comment on column tt_afjumin_reki.adrs_bantihyoki is '住所_番地号表記';
comment on column tt_afjumin_reki.adrs_bantiedanum is '住所_番地枝番数値';
comment on column tt_afjumin_reki.adrs_katagakicd is '住所_方書コード';
comment on column tt_afjumin_reki.adrs_katagaki is '住所_方書';
comment on column tt_afjumin_reki.adrs_katagaki_kana is '住所_方書_フリガナ';
comment on column tt_afjumin_reki.adrs_yubin is '住所_郵便番号';
comment on column tt_afjumin_reki.juymd is '住民となった年月日';
comment on column tt_afjumin_reki.juymd_fusyoflg is '住民となった年月日_不詳フラグ';
comment on column tt_afjumin_reki.juymd_fusyohyoki is '住民となった年月日_不詳表記';
comment on column tt_afjumin_reki.tennyumaeadrs_sikucd is '転入前住所_市区町村コード';
comment on column tt_afjumin_reki.tennyumaeadrs_tyoazacd is '転入前住所_町字コード';
comment on column tt_afjumin_reki.tennyumaeadrs_todofuken is '転入前住所_都道府県';
comment on column tt_afjumin_reki.tennyumaeadrs_sikunm is '転入前住所_市区郡町村名';
comment on column tt_afjumin_reki.tennyumaeadrs_tyoaza is '転入前住所_町字';
comment on column tt_afjumin_reki.tennyumaeadrs_bantihyoki is '転入前住所_番地号表記';
comment on column tt_afjumin_reki.tennyumaeadrs_katagaki is '転入前住所_方書';
comment on column tt_afjumin_reki.tennyumaeadrs_yubin is '転入前住所_郵便番号';
comment on column tt_afjumin_reki.tennyumaeadrs_kokunmcd is '転入前住所_国名コード';
comment on column tt_afjumin_reki.tennyumaeadrs_kokunm is '転入前住所_国名等';
comment on column tt_afjumin_reki.tennyumaeadrs_gaiadrs is '転入前住所_国外住所';
comment on column tt_afjumin_reki.tennyumaeadrs_senusisimei is '転入前住所_世帯主氏名';
comment on column tt_afjumin_reki.tenkyomaeadrs_sikucd is '転居前住所_市区町村コード';
comment on column tt_afjumin_reki.tenkyomaeadrs_tyoazacd is '転居前住所_町字コード';
comment on column tt_afjumin_reki.tenkyomaeadrs_todofuken is '転居前住所_都道府県';
comment on column tt_afjumin_reki.tenkyomaeadrs_sikunm is '転居前住所_市区郡町村名';
comment on column tt_afjumin_reki.tenkyomaeadrs_tyoaza is '転居前住所_町字';
comment on column tt_afjumin_reki.tenkyomaeadrs_bantihyoki is '転居前住所_番地号表記';
comment on column tt_afjumin_reki.tenkyomaeadrs_katagakicd is '転居前住所_方書コード';
comment on column tt_afjumin_reki.tenkyomaeadrs_katagaki is '転居前住所_方書';
comment on column tt_afjumin_reki.tenkyomaeadrs_katagaki_kana is '転居前住所_方書_フリガナ';
comment on column tt_afjumin_reki.tenkyomaeadrs_yubin is '転居前住所_郵便番号';
comment on column tt_afjumin_reki.todokeymd is '消除の届出年月日';
comment on column tt_afjumin_reki.delidoymd is '消除の異動年月日';
comment on column tt_afjumin_reki.delidoymd_fusyoflg is '消除の異動年月日_不詳フラグ';
comment on column tt_afjumin_reki.delidoymd_fusyohyoki is '消除の異動年月日_不詳表記';
comment on column tt_afjumin_reki.tennyututiymd is '転入通知年月日';
comment on column tt_afjumin_reki.tensyutuyoteiadrs_sikucd is '転出先住所（予定）_市区町村コード';
comment on column tt_afjumin_reki.tensyutuyoteiadrs_tyoazacd is '転出先住所（予定）_町字コード';
comment on column tt_afjumin_reki.tensyutuyoteiadrs_todofuken is '転出先住所（予定）_都道府県';
comment on column tt_afjumin_reki.tensyutuyoteiadrs_sikunm is '転出先住所（予定）_市区郡町村名';
comment on column tt_afjumin_reki.tensyutuyoteiadrs_tyoaza is '転出先住所（予定）_町字';
comment on column tt_afjumin_reki.tensyutuyoteiadrs_bantihyoki is '転出先住所（予定）_番地号表記';
comment on column tt_afjumin_reki.tensyutuyoteiadrs_katagaki is '転出先住所（予定）_方書';
comment on column tt_afjumin_reki.tensyutuyoteiadrs_kokunmcd is '転出先住所（予定）_国名コード';
comment on column tt_afjumin_reki.tensyutuyoteiadrs_kokunm is '転出先住所（予定）_国名等';
comment on column tt_afjumin_reki.tensyutuyoteiadrs_gaiadrs is '転出先住所（予定）_国外住所';
comment on column tt_afjumin_reki.tensyutuyoteiadrs_yubin is '転出先住所（予定）_郵便番号';
comment on column tt_afjumin_reki.tensyutukakuteiadrs_sikucd is '転出先住所（確定）_市区町村コード';
comment on column tt_afjumin_reki.tensyutukakuteiadrs_tyoazacd is '転出先住所（確定）_町字コード';
comment on column tt_afjumin_reki.tensyutukakuteiadrs_todofuken is '転出先住所（確定）_都道府県';
comment on column tt_afjumin_reki.tensyutukakuteiadrs_sikunm is '転出先住所（確定）_市区郡町村名';
comment on column tt_afjumin_reki.tensyutukakuteiadrs_tyoaza is '転出先住所（確定）_町字';
comment on column tt_afjumin_reki.tensyutukakuteiadrs_bantihyoki is '転出先住所（確定）_番地号表記';
comment on column tt_afjumin_reki.tensyutukakuteiadrs_katagaki is '転出先住所（確定）_方書';
comment on column tt_afjumin_reki.tensyutukakuteiadrs_yubin is '転出先住所（確定）_郵便番号';
comment on column tt_afjumin_reki.gaijuymd is '外国人住民となった年月日';
comment on column tt_afjumin_reki.gaijuymd_fusyoflg is '外国人住民となった年月日_不詳フラグ';
comment on column tt_afjumin_reki.gaijuymd_fusyohyoki is '外国人住民となった年月日_不詳表記';
comment on column tt_afjumin_reki.kokunmcd is '国籍等_国名コード';
comment on column tt_afjumin_reki.kokunm is '国籍名等';
comment on column tt_afjumin_reki.kiteikbn is '第30条45規定区分';
comment on column tt_afjumin_reki.zairyucd is '在留資格等コード';
comment on column tt_afjumin_reki.zairyucd_year is '在留期間等コード_年';
comment on column tt_afjumin_reki.zairyucd_month is '在留期間等コード_月';
comment on column tt_afjumin_reki.zairyucd_day is '在留期間等コード_日';
comment on column tt_afjumin_reki.zairyumanryoymd is '在留期間の満了の日';
comment on column tt_afjumin_reki.tikukanricd1 is '地区管理コード1';
comment on column tt_afjumin_reki.tikukanricd2 is '地区管理コード2';
comment on column tt_afjumin_reki.tikukanricd3 is '地区管理コード3';
comment on column tt_afjumin_reki.tikukanricd4 is '地区管理コード4';
comment on column tt_afjumin_reki.tikukanricd5 is '地区管理コード5';
comment on column tt_afjumin_reki.tikukanricd6 is '地区管理コード6';
comment on column tt_afjumin_reki.tikukanricd7 is '地区管理コード7';
comment on column tt_afjumin_reki.tikukanricd8 is '地区管理コード8';
comment on column tt_afjumin_reki.tikukanricd9 is '地区管理コード9';
comment on column tt_afjumin_reki.tikukanricd10 is '地区管理コード10';
comment on column tt_afjumin_reki.personalno is '個人番号';
comment on column tt_afjumin_reki.renkeimotosousauserid is '連携元操作者ID';
comment on column tt_afjumin_reki.renkeimotosousadttm is '連携元操作日時';
comment on column tt_afjumin_reki.saisinflg is '最新フラグ';
comment on column tt_afjumin_reki.reguserid is '登録ユーザーID';
comment on column tt_afjumin_reki.regdttm is '登録日時';
comment on column tt_afjumin_reki.upduserid is '更新ユーザーID';
comment on column tt_afjumin_reki.upddttm is '更新日時';

--住登外者情報テーブル
drop table if exists tt_afjutogai;
create table tt_afjutogai(
    atenano varchar(15) not null,
    rirekino smallint not null,
    setaino varchar(15) not null,
    jutogaisyasyubetu varchar(1) not null,
    jutogaisyajotai varchar(1) not null,
    idoymd varchar(10) not null,
    idotodokeymd varchar(10) not null,
    idojiyu varchar(2),
    simei varchar(100) not null,
    si varchar(50),
    mei varchar(50),
    simei_gairoma varchar(100),
    simei_gaikanji varchar(100),
    simei_kana varchar(100),
    simei_kana_seion varchar(100),
    si_kana varchar(50),
    si_kana_seion varchar(50),
    mei_kana varchar(50),
    mei_kana_seion varchar(50),
    tusyo varchar(100),
    tusyo_kana varchar(100),
    tusyo_kana_seion varchar(100),
    tusyo_kanastatus varchar(1),
    simei_yusen varchar(200) not null,
    simei_kana_yusen varchar(100),
    simei_kana_yusen_seion varchar(100),
    sex varchar(1),
    sexhyoki varchar(10),
    bymd varchar(10),
    bymd_fusyoflg boolean,
    bymd_fusyohyoki varchar(72),
    adrs_sikucd varchar(6),
    adrs_tyoazacd varchar(7),
    tosi_gyoseikucd varchar(12),
    adrs_todofuken varchar(4),
    adrs_sikunm varchar(12),
    adrs_tyoaza varchar(120),
    adrs_bantihyoki varchar(50),
    adrs_katagaki varchar(300),
    adrs_katagaki_kana varchar(300),
    adrs_yubin varchar(7),
    adrs_kokunmcd varchar(3),
    adrs_kokunm varchar(200),
    adrs_gaiadrs varchar(300),
    hokenkbn varchar(2),
    nayosemotoflg varchar(1) not null default 0,
    nayosesakiatenano varchar(15),
    togoatenaflg varchar(1) not null,
    sansyofukaflg varchar(1) not null,
    stopflg boolean not null default false,
    renkeimotosousauserid varchar(10),
    renkeimotosousadttm timestamp,
    saisinflg boolean not null default true,
    regbusyocd varchar(3) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,rirekino)
);
comment on table tt_afjutogai is '住登外者情報テーブル';
comment on column tt_afjutogai.atenano is '宛名番号';
comment on column tt_afjutogai.rirekino is '履歴番号';
comment on column tt_afjutogai.setaino is '世帯番号';
comment on column tt_afjutogai.jutogaisyasyubetu is '住登外者種別';
comment on column tt_afjutogai.jutogaisyajotai is '住登外者状態';
comment on column tt_afjutogai.idoymd is '異動年月日';
comment on column tt_afjutogai.idotodokeymd is '異動届出年月日';
comment on column tt_afjutogai.idojiyu is '異動事由';
comment on column tt_afjutogai.simei is '氏名';
comment on column tt_afjutogai.si is '氏_日本人';
comment on column tt_afjutogai.mei is '名_日本人';
comment on column tt_afjutogai.simei_gairoma is '氏名_外国人ローマ字';
comment on column tt_afjutogai.simei_gaikanji is '氏名_外国人漢字';
comment on column tt_afjutogai.simei_kana is '氏名_フリガナ';
comment on column tt_afjutogai.simei_kana_seion is '氏名_フリガナ_清音化';
comment on column tt_afjutogai.si_kana is '氏_日本人_フリガナ';
comment on column tt_afjutogai.si_kana_seion is '氏_日本人_フリガナ_清音化';
comment on column tt_afjutogai.mei_kana is '名_日本人_フリガナ';
comment on column tt_afjutogai.mei_kana_seion is '名_日本人_フリガナ_清音化';
comment on column tt_afjutogai.tusyo is '通称';
comment on column tt_afjutogai.tusyo_kana is '通称_フリガナ';
comment on column tt_afjutogai.tusyo_kana_seion is '通称_フリガナ_清音化';
comment on column tt_afjutogai.tusyo_kanastatus is '通称_フリガナ確認状況';
comment on column tt_afjutogai.simei_yusen is '氏名_優先';
comment on column tt_afjutogai.simei_kana_yusen is '氏名_フリガナ_優先';
comment on column tt_afjutogai.simei_kana_yusen_seion is '氏名_フリガナ_優先_清音化';
comment on column tt_afjutogai.sex is '性別';
comment on column tt_afjutogai.sexhyoki is '性別表記';
comment on column tt_afjutogai.bymd is '生年月日';
comment on column tt_afjutogai.bymd_fusyoflg is '生年月日_不詳フラグ';
comment on column tt_afjutogai.bymd_fusyohyoki is '生年月日_不詳表記';
comment on column tt_afjutogai.adrs_sikucd is '住所_市区町村コード';
comment on column tt_afjutogai.adrs_tyoazacd is '住所_町字コード';
comment on column tt_afjutogai.tosi_gyoseikucd is '指定都市_行政区等コード';
comment on column tt_afjutogai.adrs_todofuken is '住所_都道府県';
comment on column tt_afjutogai.adrs_sikunm is '住所_市区郡町村名';
comment on column tt_afjutogai.adrs_tyoaza is '住所_町字';
comment on column tt_afjutogai.adrs_bantihyoki is '住所_番地号表記';
comment on column tt_afjutogai.adrs_katagaki is '住所_方書';
comment on column tt_afjutogai.adrs_katagaki_kana is '住所_方書_フリガナ';
comment on column tt_afjutogai.adrs_yubin is '住所_郵便番号';
comment on column tt_afjutogai.adrs_kokunmcd is '住所_国名コード';
comment on column tt_afjutogai.adrs_kokunm is '住所_国名等';
comment on column tt_afjutogai.adrs_gaiadrs is '住所_国外住所';
comment on column tt_afjutogai.hokenkbn is '保険区分';
comment on column tt_afjutogai.nayosemotoflg is '名寄せ元フラグ';
comment on column tt_afjutogai.nayosesakiatenano is '名寄せ先宛名番号';
comment on column tt_afjutogai.togoatenaflg is '統合宛名フラグ';
comment on column tt_afjutogai.sansyofukaflg is '他業務参照不可フラグ';
comment on column tt_afjutogai.stopflg is '使用停止フラグ';
comment on column tt_afjutogai.renkeimotosousauserid is '連携元操作者ID';
comment on column tt_afjutogai.renkeimotosousadttm is '連携元操作日時';
comment on column tt_afjutogai.saisinflg is '最新フラグ';
comment on column tt_afjutogai.regbusyocd is '登録部署';
comment on column tt_afjutogai.reguserid is '登録ユーザーID';
comment on column tt_afjutogai.regdttm is '登録日時';
comment on column tt_afjutogai.upduserid is '更新ユーザーID';
comment on column tt_afjutogai.upddttm is '更新日時';

--住登外者独自施策システム等情報テーブル
drop table if exists tt_afjutogai_dokujisystem;
create table tt_afjutogai_dokujisystem(
    atenano varchar(15) not null,
    rirekino smallint not null,
    dokujisystemid varchar(3) not null,
primary key(atenano,rirekino,dokujisystemid)
);
comment on table tt_afjutogai_dokujisystem is '住登外者独自施策システム等情報テーブル';
comment on column tt_afjutogai_dokujisystem.atenano is '宛名番号';
comment on column tt_afjutogai_dokujisystem.rirekino is '履歴番号';
comment on column tt_afjutogai_dokujisystem.dokujisystemid is '独自施策システム等ID';

--住登外者参照業務情報テーブル
drop table if exists tt_afjutogai_gyomu;
create table tt_afjutogai_gyomu(
    atenano varchar(15) not null,
    rirekino smallint not null,
    gyomuid varchar(3) not null,
primary key(atenano,rirekino,gyomuid)
);
comment on table tt_afjutogai_gyomu is '住登外者参照業務情報テーブル';
comment on column tt_afjutogai_gyomu.atenano is '宛名番号';
comment on column tt_afjutogai_gyomu.rirekino is '履歴番号';
comment on column tt_afjutogai_gyomu.gyomuid is '業務ID';

--【介護保険】被保険者情報テーブル
drop table if exists tt_afkaigo;
create table tt_afkaigo(
    atenano varchar(15) not null,
    kaigohokensyano varchar(6) not null,
    hihokensyano varchar(10) not null,
    hihokensyakbncd varchar(1) not null,
    sikakusyutokuymd varchar(10) not null,
    sikakusosituymd varchar(10) not null,
    yokaigoninteijokyocd varchar(2) not null,
    yokaigojotaikbncd varchar(2),
    yokaigoninteiymd varchar(10),
    yokaigoyukoymdf varchar(10),
    yokaigoyukoymdt varchar(10),
    kohijukyusyano varchar(7) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano)
);
comment on table tt_afkaigo is '【介護保険】被保険者情報テーブル';
comment on column tt_afkaigo.atenano is '宛名番号';
comment on column tt_afkaigo.kaigohokensyano is '介護保険者番号';
comment on column tt_afkaigo.hihokensyano is '被保険者番号';
comment on column tt_afkaigo.hihokensyakbncd is '被保険者区分コード';
comment on column tt_afkaigo.sikakusyutokuymd is '資格取得日';
comment on column tt_afkaigo.sikakusosituymd is '資格喪失日';
comment on column tt_afkaigo.yokaigoninteijokyocd is '要介護認定状況コード';
comment on column tt_afkaigo.yokaigojotaikbncd is '要介護状態区分コード';
comment on column tt_afkaigo.yokaigoninteiymd is '要介護認定日';
comment on column tt_afkaigo.yokaigoyukoymdf is '要介護認定有効期間開始日';
comment on column tt_afkaigo.yokaigoyukoymdt is '要介護認定有効期間終了日';
comment on column tt_afkaigo.kohijukyusyano is '公費受給者番号';
comment on column tt_afkaigo.reguserid is '登録ユーザーID';
comment on column tt_afkaigo.regdttm is '登録日時';
comment on column tt_afkaigo.upduserid is '更新ユーザーID';
comment on column tt_afkaigo.upddttm is '更新日時';

--【介護保険】被保険者情報履歴テーブル
drop table if exists tt_afkaigo_reki;
create table tt_afkaigo_reki(
    atenano varchar(15) not null,
    kaigohokensyano varchar(6) not null,
    hihokensyano varchar(10) not null,
    sikakurirekino integer not null,
    hihokensyakbncd varchar(1) not null,
    sikakusyutokuymd varchar(10) not null,
    sikakusosituymd varchar(10) not null,
    yokaigoninteijokyocd varchar(2) not null,
    yokaigojotaikbncd varchar(2),
    yokaigoninteiymd varchar(10),
    yokaigoyukoymdf varchar(10),
    yokaigoyukoymdt varchar(10),
    kohijukyusyano varchar(7) not null,
    renkeimotosousauserid varchar(10) not null,
    renkeimotosousadttm timestamp not null,
    saisinflg boolean not null default true,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,kaigohokensyano,hihokensyano,sikakurirekino)
);
comment on table tt_afkaigo_reki is '【介護保険】被保険者情報履歴テーブル';
comment on column tt_afkaigo_reki.atenano is '宛名番号';
comment on column tt_afkaigo_reki.kaigohokensyano is '介護保険者番号';
comment on column tt_afkaigo_reki.hihokensyano is '被保険者番号';
comment on column tt_afkaigo_reki.sikakurirekino is '資格履歴番号';
comment on column tt_afkaigo_reki.hihokensyakbncd is '被保険者区分コード';
comment on column tt_afkaigo_reki.sikakusyutokuymd is '資格取得日';
comment on column tt_afkaigo_reki.sikakusosituymd is '資格喪失日';
comment on column tt_afkaigo_reki.yokaigoninteijokyocd is '要介護認定状況コード';
comment on column tt_afkaigo_reki.yokaigojotaikbncd is '要介護状態区分コード';
comment on column tt_afkaigo_reki.yokaigoninteiymd is '要介護認定日';
comment on column tt_afkaigo_reki.yokaigoyukoymdf is '要介護認定有効期間開始日';
comment on column tt_afkaigo_reki.yokaigoyukoymdt is '要介護認定有効期間終了日';
comment on column tt_afkaigo_reki.kohijukyusyano is '公費受給者番号';
comment on column tt_afkaigo_reki.renkeimotosousauserid is '連携元操作者ID';
comment on column tt_afkaigo_reki.renkeimotosousadttm is '連携元操作日時';
comment on column tt_afkaigo_reki.saisinflg is '最新フラグ';
comment on column tt_afkaigo_reki.reguserid is '登録ユーザーID';
comment on column tt_afkaigo_reki.regdttm is '登録日時';
comment on column tt_afkaigo_reki.upduserid is '更新ユーザーID';
comment on column tt_afkaigo_reki.upddttm is '更新日時';

--個人ドキュメントテーブル
drop table if exists tt_afkojindoc;
create table tt_afkojindoc(
    atenano varchar(15) not null,
    docseq integer not null,
    filenm varchar(255) not null,
    jigyocd varchar(5),
    title varchar(100),
    filetype smallint not null,
    filesize integer not null,
    filedata bytea not null,
    juyoflg boolean not null default false,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,docseq)
);
comment on table tt_afkojindoc is '個人ドキュメントテーブル';
comment on column tt_afkojindoc.atenano is '宛名番号';
comment on column tt_afkojindoc.docseq is 'ドキュメントシーケンス';
comment on column tt_afkojindoc.filenm is 'ファイル名';
comment on column tt_afkojindoc.jigyocd is '電子ファイル事業コード';
comment on column tt_afkojindoc.title is 'タイトル';
comment on column tt_afkojindoc.filetype is 'ファイルタイプ';
comment on column tt_afkojindoc.filesize is 'ファイルサイズ';
comment on column tt_afkojindoc.filedata is 'ファイルデータ';
comment on column tt_afkojindoc.juyoflg is '重要フラグ';
comment on column tt_afkojindoc.regsisyo is '登録支所';
comment on column tt_afkojindoc.reguserid is '登録ユーザーID';
comment on column tt_afkojindoc.regdttm is '登録日時';
comment on column tt_afkojindoc.upduserid is '更新ユーザーID';
comment on column tt_afkojindoc.upddttm is '更新日時';

--【個人住民税】納税義務者情報テーブル
drop table if exists tt_afkojinzeigimusya;
create table tt_afkojinzeigimusya(
    atenano varchar(15) not null,
    kazeinendo smallint not null,
    tosi_gyoseikucd varchar(12),
    misinkokukbn varchar(1) not null,
    takazeikbn varchar(1) not null,
    takazeisikucd varchar(6),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,kazeinendo)
);
comment on table tt_afkojinzeigimusya is '【個人住民税】納税義務者情報テーブル';
comment on column tt_afkojinzeigimusya.atenano is '宛名番号';
comment on column tt_afkojinzeigimusya.kazeinendo is '課税年度';
comment on column tt_afkojinzeigimusya.tosi_gyoseikucd is '指定都市_行政区等コード';
comment on column tt_afkojinzeigimusya.misinkokukbn is '未申告区分';
comment on column tt_afkojinzeigimusya.takazeikbn is '他団体課税対象者区分';
comment on column tt_afkojinzeigimusya.takazeisikucd is '他団体課税対象者の課税先市区町村コード';
comment on column tt_afkojinzeigimusya.reguserid is '登録ユーザーID';
comment on column tt_afkojinzeigimusya.regdttm is '登録日時';
comment on column tt_afkojinzeigimusya.upduserid is '更新ユーザーID';
comment on column tt_afkojinzeigimusya.upddttm is '更新日時';

--【個人住民税】納税義務者情報履歴テーブル
drop table if exists tt_afkojinzeigimusya_reki;
create table tt_afkojinzeigimusya_reki(
    atenano varchar(15) not null,
    kazeinendo smallint not null,
    kojinrirekino smallint not null,
    tosi_gyoseikucd varchar(12),
    misinkokukbn varchar(1) not null,
    takazeikbn varchar(1) not null,
    takazeisikucd varchar(6),
    renkeimotosousauserid varchar(10) not null,
    renkeimotosousadttm timestamp not null,
    saisinflg boolean not null default true,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,kazeinendo,kojinrirekino)
);
comment on table tt_afkojinzeigimusya_reki is '【個人住民税】納税義務者情報履歴テーブル';
comment on column tt_afkojinzeigimusya_reki.atenano is '宛名番号';
comment on column tt_afkojinzeigimusya_reki.kazeinendo is '課税年度';
comment on column tt_afkojinzeigimusya_reki.kojinrirekino is '個人履歴番号';
comment on column tt_afkojinzeigimusya_reki.tosi_gyoseikucd is '指定都市_行政区等コード';
comment on column tt_afkojinzeigimusya_reki.misinkokukbn is '未申告区分';
comment on column tt_afkojinzeigimusya_reki.takazeikbn is '他団体課税対象者区分';
comment on column tt_afkojinzeigimusya_reki.takazeisikucd is '他団体課税対象者の課税先市区町村コード';
comment on column tt_afkojinzeigimusya_reki.renkeimotosousauserid is '連携元操作者ID';
comment on column tt_afkojinzeigimusya_reki.renkeimotosousadttm is '連携元操作日時';
comment on column tt_afkojinzeigimusya_reki.saisinflg is '最新フラグ';
comment on column tt_afkojinzeigimusya_reki.reguserid is '登録ユーザーID';
comment on column tt_afkojinzeigimusya_reki.regdttm is '登録日時';
comment on column tt_afkojinzeigimusya_reki.upduserid is '更新ユーザーID';
comment on column tt_afkojinzeigimusya_reki.upddttm is '更新日時';

--【個人住民税】個人住民税課税情報テーブル
drop table if exists tt_afkojinzeikazei;
create table tt_afkojinzeikazei(
    atenano varchar(15) not null,
    kazeinendo smallint not null,
    tosi_gyoseikucd varchar(12),
    kazeikbn varchar(1) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,kazeinendo)
);
comment on table tt_afkojinzeikazei is '【個人住民税】個人住民税課税情報テーブル';
comment on column tt_afkojinzeikazei.atenano is '宛名番号';
comment on column tt_afkojinzeikazei.kazeinendo is '課税年度';
comment on column tt_afkojinzeikazei.tosi_gyoseikucd is '指定都市_行政区等コード';
comment on column tt_afkojinzeikazei.kazeikbn is '課税非課税区分';
comment on column tt_afkojinzeikazei.reguserid is '登録ユーザーID';
comment on column tt_afkojinzeikazei.regdttm is '登録日時';
comment on column tt_afkojinzeikazei.upduserid is '更新ユーザーID';
comment on column tt_afkojinzeikazei.upddttm is '更新日時';

--【個人住民税】個人住民税課税情報履歴テーブル
drop table if exists tt_afkojinzeikazei_reki;
create table tt_afkojinzeikazei_reki(
    atenano varchar(15) not null,
    kazeinendo smallint not null,
    kazeirirekino integer not null,
    tosi_gyoseikucd varchar(12),
    kazeikbn varchar(1) not null,
    renkeimotosousauserid varchar(10) not null,
    renkeimotosousadttm timestamp not null,
    saisinflg boolean not null default true,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,kazeinendo,kazeirirekino)
);
comment on table tt_afkojinzeikazei_reki is '【個人住民税】個人住民税課税情報履歴テーブル';
comment on column tt_afkojinzeikazei_reki.atenano is '宛名番号';
comment on column tt_afkojinzeikazei_reki.kazeinendo is '課税年度';
comment on column tt_afkojinzeikazei_reki.kazeirirekino is '課税情報履歴番号';
comment on column tt_afkojinzeikazei_reki.tosi_gyoseikucd is '指定都市_行政区等コード';
comment on column tt_afkojinzeikazei_reki.kazeikbn is '課税非課税区分';
comment on column tt_afkojinzeikazei_reki.renkeimotosousauserid is '連携元操作者ID';
comment on column tt_afkojinzeikazei_reki.renkeimotosousadttm is '連携元操作日時';
comment on column tt_afkojinzeikazei_reki.saisinflg is '最新フラグ';
comment on column tt_afkojinzeikazei_reki.reguserid is '登録ユーザーID';
comment on column tt_afkojinzeikazei_reki.regdttm is '登録日時';
comment on column tt_afkojinzeikazei_reki.upduserid is '更新ユーザーID';
comment on column tt_afkojinzeikazei_reki.upddttm is '更新日時';

--【個人住民税】個人住民税税額控除情報テーブル
drop table if exists tt_afkojinzeikojo;
create table tt_afkojinzeikojo(
    atenano varchar(15) not null,
    kazeinendo smallint not null,
    kojocd varchar(3) not null,
    tosi_gyoseikucd varchar(12),
    kojokingaku bigint not null default 0,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,kazeinendo,kojocd)
);
comment on table tt_afkojinzeikojo is '【個人住民税】個人住民税税額控除情報テーブル';
comment on column tt_afkojinzeikojo.atenano is '宛名番号';
comment on column tt_afkojinzeikojo.kazeinendo is '課税年度';
comment on column tt_afkojinzeikojo.kojocd is '税額・税額控除コード';
comment on column tt_afkojinzeikojo.tosi_gyoseikucd is '指定都市_行政区等コード';
comment on column tt_afkojinzeikojo.kojokingaku is '税額控除金額';
comment on column tt_afkojinzeikojo.reguserid is '登録ユーザーID';
comment on column tt_afkojinzeikojo.regdttm is '登録日時';
comment on column tt_afkojinzeikojo.upduserid is '更新ユーザーID';
comment on column tt_afkojinzeikojo.upddttm is '更新日時';

--【個人住民税】個人住民税税額控除情報履歴テーブル
drop table if exists tt_afkojinzeikojo_reki;
create table tt_afkojinzeikojo_reki(
    atenano varchar(15) not null,
    kazeinendo smallint not null,
    kojorirekino integer not null,
    kojocd varchar(3) not null,
    tosi_gyoseikucd varchar(12),
    kojokingaku bigint not null default 0,
    renkeimotosousauserid varchar(10) not null,
    renkeimotosousadttm timestamp not null,
    saisinflg boolean not null default true,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,kazeinendo,kojorirekino,kojocd)
);
comment on table tt_afkojinzeikojo_reki is '【個人住民税】個人住民税税額控除情報履歴テーブル';
comment on column tt_afkojinzeikojo_reki.atenano is '宛名番号';
comment on column tt_afkojinzeikojo_reki.kazeinendo is '課税年度';
comment on column tt_afkojinzeikojo_reki.kojorirekino is '税額控除情報履歴番号';
comment on column tt_afkojinzeikojo_reki.kojocd is '税額・税額控除コード';
comment on column tt_afkojinzeikojo_reki.tosi_gyoseikucd is '指定都市_行政区等コード';
comment on column tt_afkojinzeikojo_reki.kojokingaku is '税額控除金額';
comment on column tt_afkojinzeikojo_reki.renkeimotosousauserid is '連携元操作者ID';
comment on column tt_afkojinzeikojo_reki.renkeimotosousadttm is '連携元操作日時';
comment on column tt_afkojinzeikojo_reki.saisinflg is '最新フラグ';
comment on column tt_afkojinzeikojo_reki.reguserid is '登録ユーザーID';
comment on column tt_afkojinzeikojo_reki.regdttm is '登録日時';
comment on column tt_afkojinzeikojo_reki.upduserid is '更新ユーザーID';
comment on column tt_afkojinzeikojo_reki.upddttm is '更新日時';

--【後期高齢者医療】被保険者情報テーブル
drop table if exists tt_afkokihoken;
create table tt_afkokihoken(
    atenano varchar(15) not null,
    hihokensyano varchar(8) not null,
    kojinkbncd varchar(1) not null,
    hiho_sikakusyutokujiyucd varchar(3) not null,
    hiho_sikakusyutokuymd varchar(10) not null,
    hiho_sikakusositujiyucd varchar(3),
    hiho_sikakusosituymd varchar(10),
    hoken_tekiyoymdf varchar(10) not null,
    hoken_tekiyoymdt varchar(10),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano)
);
comment on table tt_afkokihoken is '【後期高齢者医療】被保険者情報テーブル';
comment on column tt_afkokihoken.atenano is '宛名番号';
comment on column tt_afkokihoken.hihokensyano is '被保険者番号';
comment on column tt_afkokihoken.kojinkbncd is '個人区分コード';
comment on column tt_afkokihoken.hiho_sikakusyutokujiyucd is '被保険者資格取得事由コード';
comment on column tt_afkokihoken.hiho_sikakusyutokuymd is '被保険者資格取得年月日';
comment on column tt_afkokihoken.hiho_sikakusositujiyucd is '被保険者資格喪失事由コード';
comment on column tt_afkokihoken.hiho_sikakusosituymd is '被保険者資格喪失年月日';
comment on column tt_afkokihoken.hoken_tekiyoymdf is '保険者番号適用開始年月日';
comment on column tt_afkokihoken.hoken_tekiyoymdt is '保険者番号適用終了年月日';
comment on column tt_afkokihoken.reguserid is '登録ユーザーID';
comment on column tt_afkokihoken.regdttm is '登録日時';
comment on column tt_afkokihoken.upduserid is '更新ユーザーID';
comment on column tt_afkokihoken.upddttm is '更新日時';

--【後期高齢者医療】被保険者情報履歴テーブル
drop table if exists tt_afkokihoken_reki;
create table tt_afkokihoken_reki(
    hihokensyano varchar(8) not null,
    rirekino integer not null,
    kojinkbncd varchar(1) not null,
    atenano varchar(15) not null,
    hiho_sikakusyutokujiyucd varchar(3) not null,
    hiho_sikakusyutokuymd varchar(10) not null,
    hiho_sikakusositujiyucd varchar(3),
    hiho_sikakusosituymd varchar(10),
    hoken_tekiyoymdf varchar(10) not null,
    hoken_tekiyoymdt varchar(10),
    renkeimotosousauserid varchar(10) not null,
    renkeimotosousadttm timestamp not null,
    saisinflg boolean not null default true,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(hihokensyano,rirekino)
);
comment on table tt_afkokihoken_reki is '【後期高齢者医療】被保険者情報履歴テーブル';
comment on column tt_afkokihoken_reki.hihokensyano is '被保険者番号';
comment on column tt_afkokihoken_reki.rirekino is '履歴番号';
comment on column tt_afkokihoken_reki.kojinkbncd is '個人区分コード';
comment on column tt_afkokihoken_reki.atenano is '宛名番号';
comment on column tt_afkokihoken_reki.hiho_sikakusyutokujiyucd is '被保険者資格取得事由コード';
comment on column tt_afkokihoken_reki.hiho_sikakusyutokuymd is '被保険者資格取得年月日';
comment on column tt_afkokihoken_reki.hiho_sikakusositujiyucd is '被保険者資格喪失事由コード';
comment on column tt_afkokihoken_reki.hiho_sikakusosituymd is '被保険者資格喪失年月日';
comment on column tt_afkokihoken_reki.hoken_tekiyoymdf is '保険者番号適用開始年月日';
comment on column tt_afkokihoken_reki.hoken_tekiyoymdt is '保険者番号適用終了年月日';
comment on column tt_afkokihoken_reki.renkeimotosousauserid is '連携元操作者ID';
comment on column tt_afkokihoken_reki.renkeimotosousadttm is '連携元操作日時';
comment on column tt_afkokihoken_reki.saisinflg is '最新フラグ';
comment on column tt_afkokihoken_reki.reguserid is '登録ユーザーID';
comment on column tt_afkokihoken_reki.regdttm is '登録日時';
comment on column tt_afkokihoken_reki.upduserid is '更新ユーザーID';
comment on column tt_afkokihoken_reki.upddttm is '更新日時';

--【国民健康保険】国保資格情報テーブル
drop table if exists tt_afkokuho;
create table tt_afkokuho(
    atenano varchar(15) not null,
    sikutyosonhokenjano varchar(8) not null,
    hokenjanm varchar(50),
    kokuho_kigono varchar(12) not null,
    kokuho_edano varchar(2) not null,
    kokuho_sikakukbn varchar(1) not null,
    kokuho_sikakusyutokuymd varchar(10) not null,
    kokuho_sikakusyutokujiyu varchar(2) not null,
    kokuho_sikakusosituymd varchar(10),
    kokuho_sikakusositujiyu varchar(2),
    kokuho_tekiyoymdf varchar(10) not null,
    kokuho_tekiyoymdt varchar(10),
    syokbn varchar(2) not null,
    yukokigenymd varchar(10) not null,
    marugakumaruenkbn varchar(1),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano)
);
comment on table tt_afkokuho is '【国民健康保険】国保資格情報テーブル';
comment on column tt_afkokuho.atenano is '宛名番号';
comment on column tt_afkokuho.sikutyosonhokenjano is '市区町村保険者番号';
comment on column tt_afkokuho.hokenjanm is '保険者名称';
comment on column tt_afkokuho.kokuho_kigono is '国保記号番号';
comment on column tt_afkokuho.kokuho_edano is '枝番';
comment on column tt_afkokuho.kokuho_sikakukbn is '国保資格区分';
comment on column tt_afkokuho.kokuho_sikakusyutokuymd is '国保資格取得年月日';
comment on column tt_afkokuho.kokuho_sikakusyutokujiyu is '国保資格取得事由';
comment on column tt_afkokuho.kokuho_sikakusosituymd is '国保資格喪失年月日';
comment on column tt_afkokuho.kokuho_sikakusositujiyu is '国保資格喪失事由';
comment on column tt_afkokuho.kokuho_tekiyoymdf is '国保適用開始年月日';
comment on column tt_afkokuho.kokuho_tekiyoymdt is '国保適用終了年月日';
comment on column tt_afkokuho.syokbn is '証区分';
comment on column tt_afkokuho.yukokigenymd is '有効期限';
comment on column tt_afkokuho.marugakumaruenkbn is 'マル学マル遠区分';
comment on column tt_afkokuho.reguserid is '登録ユーザーID';
comment on column tt_afkokuho.regdttm is '登録日時';
comment on column tt_afkokuho.upduserid is '更新ユーザーID';
comment on column tt_afkokuho.upddttm is '更新日時';

--【国民健康保険】国保資格情報履歴テーブル
drop table if exists tt_afkokuho_reki;
create table tt_afkokuho_reki(
    atenano varchar(15) not null,
    hihokensyarirekino smallint not null,
    sikutyosonhokenjano varchar(8) not null,
    hokenjanm varchar(50),
    kokuho_kigono varchar(12) not null,
    kokuho_edano varchar(2) not null,
    kokuho_sikakukbn varchar(1) not null,
    kokuho_sikakusyutokuymd varchar(10) not null,
    kokuho_sikakusyutokujiyu varchar(2) not null,
    kokuho_sikakusosituymd varchar(10),
    kokuho_sikakusositujiyu varchar(2),
    kokuho_tekiyoymdf varchar(10) not null,
    kokuho_tekiyoymdt varchar(10),
    syokbn varchar(2) not null,
    yukokigenymd varchar(10) not null,
    marugakumaruenkbn varchar(1),
    renkeimotosousauserid varchar(10) not null,
    renkeimotosousadttm timestamp not null,
    saisinflg boolean not null default true,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,hihokensyarirekino)
);
comment on table tt_afkokuho_reki is '【国民健康保険】国保資格情報履歴テーブル';
comment on column tt_afkokuho_reki.atenano is '宛名番号';
comment on column tt_afkokuho_reki.hihokensyarirekino is '被保険者履歴番号';
comment on column tt_afkokuho_reki.sikutyosonhokenjano is '市区町村保険者番号';
comment on column tt_afkokuho_reki.hokenjanm is '保険者名称';
comment on column tt_afkokuho_reki.kokuho_kigono is '国保記号番号';
comment on column tt_afkokuho_reki.kokuho_edano is '枝番';
comment on column tt_afkokuho_reki.kokuho_sikakukbn is '国保資格区分';
comment on column tt_afkokuho_reki.kokuho_sikakusyutokuymd is '国保資格取得年月日';
comment on column tt_afkokuho_reki.kokuho_sikakusyutokujiyu is '国保資格取得事由';
comment on column tt_afkokuho_reki.kokuho_sikakusosituymd is '国保資格喪失年月日';
comment on column tt_afkokuho_reki.kokuho_sikakusositujiyu is '国保資格喪失事由';
comment on column tt_afkokuho_reki.kokuho_tekiyoymdf is '国保適用開始年月日';
comment on column tt_afkokuho_reki.kokuho_tekiyoymdt is '国保適用終了年月日';
comment on column tt_afkokuho_reki.syokbn is '証区分';
comment on column tt_afkokuho_reki.yukokigenymd is '有効期限';
comment on column tt_afkokuho_reki.marugakumaruenkbn is 'マル学マル遠区分';
comment on column tt_afkokuho_reki.renkeimotosousauserid is '連携元操作者ID';
comment on column tt_afkokuho_reki.renkeimotosousadttm is '連携元操作日時';
comment on column tt_afkokuho_reki.saisinflg is '最新フラグ';
comment on column tt_afkokuho_reki.reguserid is '登録ユーザーID';
comment on column tt_afkokuho_reki.regdttm is '登録日時';
comment on column tt_afkokuho_reki.upduserid is '更新ユーザーID';
comment on column tt_afkokuho_reki.upddttm is '更新日時';

--メインログテーブル
drop table if exists tt_aflog;
create table tt_aflog(
    sessionseq bigserial not null,
    syoridttmf timestamp not null,
    syoridttmt timestamp,
    milisec integer,
    statuscd varchar(1) not null,
    kinoid varchar(10),
    service varchar(64),
    method varchar(32),
    methodnm varchar(64),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
primary key(sessionseq)
);
comment on table tt_aflog is 'メインログテーブル';
comment on column tt_aflog.sessionseq is 'セッションシーケンス';
comment on column tt_aflog.syoridttmf is '処理日時（開始）';
comment on column tt_aflog.syoridttmt is '処理日時（終了）';
comment on column tt_aflog.milisec is '処理時間';
comment on column tt_aflog.statuscd is '処理結果コード';
comment on column tt_aflog.kinoid is '機能ID';
comment on column tt_aflog.service is 'サービス名';
comment on column tt_aflog.method is 'メソッド';
comment on column tt_aflog.methodnm is 'メソッド名';
comment on column tt_aflog.reguserid is '登録ユーザーID';
comment on column tt_aflog.regdttm is '登録日時';

--宛名番号ログテーブル
drop table if exists tt_aflogatena;
create table tt_aflogatena(
    atenalogseq bigserial not null,
    sessionseq bigint not null,
    atenano varchar(15) not null,
    pnouseflg boolean not null,
    usekbn varchar(1) not null,
    msg varchar,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
primary key(atenalogseq)
);
comment on table tt_aflogatena is '宛名番号ログテーブル';
comment on column tt_aflogatena.atenalogseq is '宛名番号ログシーケンス';
comment on column tt_aflogatena.sessionseq is 'セッションシーケンス';
comment on column tt_aflogatena.atenano is '宛名番号';
comment on column tt_aflogatena.pnouseflg is '個人番号操作フラグ';
comment on column tt_aflogatena.usekbn is '操作区分';
comment on column tt_aflogatena.msg is 'メッセージ';
comment on column tt_aflogatena.reguserid is '登録ユーザーID';
comment on column tt_aflogatena.regdttm is '登録日時';

--テーブル項目値変更ログテーブル
drop table if exists tt_aflogcolumn;
create table tt_aflogcolumn(
    columnlogseq bigserial not null,
    sessionseq bigint,
    tablenm varchar(100) not null,
    henkokbn varchar(1) not null,
    keys varchar(200),
    itemnm varchar(200),
    valuebefore varchar,
    valueafter varchar,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
primary key(columnlogseq)
);
comment on table tt_aflogcolumn is 'テーブル項目値変更ログテーブル';
comment on column tt_aflogcolumn.columnlogseq is '項目値変更ログシーケンス';
comment on column tt_aflogcolumn.sessionseq is 'セッションシーケンス';
comment on column tt_aflogcolumn.tablenm is 'テーブル名';
comment on column tt_aflogcolumn.henkokbn is '変更区分';
comment on column tt_aflogcolumn.keys is 'キー';
comment on column tt_aflogcolumn.itemnm is '項目名';
comment on column tt_aflogcolumn.valuebefore is '変更前内容';
comment on column tt_aflogcolumn.valueafter is '更新後内容';
comment on column tt_aflogcolumn.reguserid is '登録ユーザーID';
comment on column tt_aflogcolumn.regdttm is '登録日時';

--DB操作ログテーブル
drop table if exists tt_aflogdb;
create table tt_aflogdb(
    dblogseq bigserial not null,
    sessionseq bigint,
    sql varchar,
    msg varchar,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
primary key(dblogseq)
);
comment on table tt_aflogdb is 'DB操作ログテーブル';
comment on column tt_aflogdb.dblogseq is 'DB操作ログシーケンス';
comment on column tt_aflogdb.sessionseq is 'セッションシーケンス';
comment on column tt_aflogdb.sql is 'SQL';
comment on column tt_aflogdb.msg is 'メッセージ';
comment on column tt_aflogdb.reguserid is '登録ユーザーID';
comment on column tt_aflogdb.regdttm is '登録日時';

--メモテーブル
drop table if exists tt_afmemo;
create table tt_afmemo(
    atenano varchar(15) not null,
    memoseq integer not null,
    jigyokbn varchar(5) not null,
    juyodo varchar(1) not null,
    title varchar(50),
    memo varchar(2000) not null,
    kigenymd varchar(10),
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,memoseq)
);
comment on table tt_afmemo is 'メモテーブル';
comment on column tt_afmemo.atenano is '宛名番号';
comment on column tt_afmemo.memoseq is 'メモシーケンス';
comment on column tt_afmemo.jigyokbn is 'メモ事業コード';
comment on column tt_afmemo.juyodo is '重要度';
comment on column tt_afmemo.title is '件名（タイトル）';
comment on column tt_afmemo.memo is 'メモ（フリーテキスト）';
comment on column tt_afmemo.kigenymd is '期限日';
comment on column tt_afmemo.regsisyo is '登録支所';
comment on column tt_afmemo.reguserid is '登録ユーザーID';
comment on column tt_afmemo.regdttm is '登録日時';
comment on column tt_afmemo.upduserid is '更新ユーザーID';
comment on column tt_afmemo.upddttm is '更新日時';

--メモ情報（世帯）テーブル
drop table if exists tt_afmemosetai;
create table tt_afmemosetai(
    setaino varchar(15) not null,
    memoseq integer not null,
    jigyokbn varchar(5) not null,
    juyodo varchar(1) not null,
    title varchar(50),
    memo varchar(2000) not null,
    kigenymd varchar(10),
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(setaino,memoseq)
);
comment on table tt_afmemosetai is 'メモ情報（世帯）テーブル';
comment on column tt_afmemosetai.setaino is '世帯番号';
comment on column tt_afmemosetai.memoseq is 'メモシーケンス';
comment on column tt_afmemosetai.jigyokbn is 'メモ事業コード';
comment on column tt_afmemosetai.juyodo is '重要度';
comment on column tt_afmemosetai.title is '件名（タイトル）';
comment on column tt_afmemosetai.memo is 'メモ（フリーテキスト）';
comment on column tt_afmemosetai.kigenymd is '期限日';
comment on column tt_afmemosetai.regsisyo is '登録支所';
comment on column tt_afmemosetai.reguserid is '登録ユーザーID';
comment on column tt_afmemosetai.regdttm is '登録日時';
comment on column tt_afmemosetai.upduserid is '更新ユーザーID';
comment on column tt_afmemosetai.upddttm is '更新日時';

--お気に入りテーブル
drop table if exists tt_afokiniiri;
create table tt_afokiniiri(
    userid varchar(10) not null,
    kinoid varchar(10) not null,
    orderseq smallint not null,
primary key(userid,kinoid)
);
comment on table tt_afokiniiri is 'お気に入りテーブル';
comment on column tt_afokiniiri.userid is 'ユーザーID';
comment on column tt_afokiniiri.kinoid is '機能ID';
comment on column tt_afokiniiri.orderseq is '並びシーケンス';

--個人番号管理テーブル
drop table if exists tt_afpersonalno;
create table tt_afpersonalno(
    atenano varchar(15) not null,
    rirekino smallint not null,
    personalno varchar(50),
    renkeimotosousauserid varchar(10) not null,
    renkeimotosousadttm timestamp not null,
    saisinflg boolean not null default true,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,rirekino)
);
comment on table tt_afpersonalno is '個人番号管理テーブル';
comment on column tt_afpersonalno.atenano is '宛名番号';
comment on column tt_afpersonalno.rirekino is '履歴番号';
comment on column tt_afpersonalno.personalno is '個人番号（マイナンバー）';
comment on column tt_afpersonalno.renkeimotosousauserid is '連携元操作者ID';
comment on column tt_afpersonalno.renkeimotosousadttm is '連携元操作日時';
comment on column tt_afpersonalno.saisinflg is '最新フラグ';
comment on column tt_afpersonalno.reguserid is '登録ユーザーID';
comment on column tt_afpersonalno.regdttm is '登録日時';
comment on column tt_afpersonalno.upduserid is '更新ユーザーID';
comment on column tt_afpersonalno.upddttm is '更新日時';

--連絡先テーブル
drop table if exists tt_afrenrakusaki;
create table tt_afrenrakusaki(
    atenano varchar(15) not null,
    jigyocd varchar(5) not null,
    tel varchar(15),
    keitaitel varchar(15),
    emailadrs varchar(254),
    emailadrs2 varchar(254),
    syosai varchar(2000),
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,jigyocd)
);
comment on table tt_afrenrakusaki is '連絡先テーブル';
comment on column tt_afrenrakusaki.atenano is '宛名番号';
comment on column tt_afrenrakusaki.jigyocd is '個人連絡先利用事業コード';
comment on column tt_afrenrakusaki.tel is '電話番号';
comment on column tt_afrenrakusaki.keitaitel is '携帯番号';
comment on column tt_afrenrakusaki.emailadrs is 'E-mailアドレス';
comment on column tt_afrenrakusaki.emailadrs2 is 'E-mailアドレス2';
comment on column tt_afrenrakusaki.syosai is '連絡先詳細';
comment on column tt_afrenrakusaki.regsisyo is '登録支所';
comment on column tt_afrenrakusaki.reguserid is '登録ユーザーID';
comment on column tt_afrenrakusaki.regdttm is '登録日時';
comment on column tt_afrenrakusaki.upduserid is '更新ユーザーID';
comment on column tt_afrenrakusaki.upddttm is '更新日時';

--【生活保護】生活保護受給情報テーブル
drop table if exists tt_afseiho;
create table tt_afseiho(
    atenano varchar(15) not null,
    seihoymdf varchar(10) not null,
    teisiymd varchar(10) not null,
    teisikaijoymd varchar(10),
    tanheikyukbn varchar(1),
    seikatufujoflg boolean default false,
    jutakufujoflg boolean default false,
    kyoikufujoflg boolean default false,
    iryofujoflg boolean default false,
    syussanfujoflg boolean default false,
    seigyofujoflg boolean default false,
    sosaifujoflg boolean default false,
    haisiymd varchar(10),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano)
);
comment on table tt_afseiho is '【生活保護】生活保護受給情報テーブル';
comment on column tt_afseiho.atenano is '宛名番号';
comment on column tt_afseiho.seihoymdf is '生活保護開始年月日';
comment on column tt_afseiho.teisiymd is '停止年月日';
comment on column tt_afseiho.teisikaijoymd is '停止解除年月日';
comment on column tt_afseiho.tanheikyukbn is '単併給区分';
comment on column tt_afseiho.seikatufujoflg is '生活扶助フラグ';
comment on column tt_afseiho.jutakufujoflg is '住宅扶助フラグ';
comment on column tt_afseiho.kyoikufujoflg is '教育扶助フラグ';
comment on column tt_afseiho.iryofujoflg is '医療扶助フラグ';
comment on column tt_afseiho.syussanfujoflg is '出産扶助フラグ';
comment on column tt_afseiho.seigyofujoflg is '生業扶助フラグ';
comment on column tt_afseiho.sosaifujoflg is '葬祭扶助フラグ';
comment on column tt_afseiho.haisiymd is '廃止年月日';
comment on column tt_afseiho.reguserid is '登録ユーザーID';
comment on column tt_afseiho.regdttm is '登録日時';
comment on column tt_afseiho.upduserid is '更新ユーザーID';
comment on column tt_afseiho.upddttm is '更新日時';

--【生活保護】生活保護受給情報履歴テーブル
drop table if exists tt_afseiho_reki;
create table tt_afseiho_reki(
    fukusijimusyocd varchar(6) not null,
    caseno varchar(10) not null,
    sinseirirekino integer not null,
    ketteirirekino integer not null,
    inno smallint not null,
    atenano varchar(15) not null,
    seihoymdf varchar(10) not null,
    teisiymd varchar(10) not null,
    teisikaijoymd varchar(10),
    tanheikyukbn varchar(1),
    seikatufujoflg boolean default false,
    jutakufujoflg boolean default false,
    kyoikufujoflg boolean default false,
    iryofujoflg boolean default false,
    syussanfujoflg boolean default false,
    seigyofujoflg boolean default false,
    sosaifujoflg boolean default false,
    haisiymd varchar(10),
    renkeimotosousauserid varchar(10) not null,
    renkeimotosousadttm timestamp not null,
    saisinflg boolean not null default true,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(fukusijimusyocd,caseno,sinseirirekino,ketteirirekino,inno)
);
comment on table tt_afseiho_reki is '【生活保護】生活保護受給情報履歴テーブル';
comment on column tt_afseiho_reki.fukusijimusyocd is '福祉事務所コード';
comment on column tt_afseiho_reki.caseno is 'ケース番号';
comment on column tt_afseiho_reki.sinseirirekino is '申請履歴番号';
comment on column tt_afseiho_reki.ketteirirekino is '決定履歴番号';
comment on column tt_afseiho_reki.inno is '員番号';
comment on column tt_afseiho_reki.atenano is '宛名番号';
comment on column tt_afseiho_reki.seihoymdf is '生活保護開始年月日';
comment on column tt_afseiho_reki.teisiymd is '停止年月日';
comment on column tt_afseiho_reki.teisikaijoymd is '停止解除年月日';
comment on column tt_afseiho_reki.tanheikyukbn is '単併給区分';
comment on column tt_afseiho_reki.seikatufujoflg is '生活扶助フラグ';
comment on column tt_afseiho_reki.jutakufujoflg is '住宅扶助フラグ';
comment on column tt_afseiho_reki.kyoikufujoflg is '教育扶助フラグ';
comment on column tt_afseiho_reki.iryofujoflg is '医療扶助フラグ';
comment on column tt_afseiho_reki.syussanfujoflg is '出産扶助フラグ';
comment on column tt_afseiho_reki.seigyofujoflg is '生業扶助フラグ';
comment on column tt_afseiho_reki.sosaifujoflg is '葬祭扶助フラグ';
comment on column tt_afseiho_reki.haisiymd is '廃止年月日';
comment on column tt_afseiho_reki.renkeimotosousauserid is '連携元操作者ID';
comment on column tt_afseiho_reki.renkeimotosousadttm is '連携元操作日時';
comment on column tt_afseiho_reki.saisinflg is '最新フラグ';
comment on column tt_afseiho_reki.reguserid is '登録ユーザーID';
comment on column tt_afseiho_reki.regdttm is '登録日時';
comment on column tt_afseiho_reki.upduserid is '更新ユーザーID';
comment on column tt_afseiho_reki.upddttm is '更新日時';

--【住民基本台帳】支援措置対象者情報テーブル
drop table if exists tt_afsiensotitaisyosya;
create table tt_afsiensotitaisyosya(
    atenano varchar(15) not null,
    siensotiymdf varchar(10) not null,
    siensotiymdt varchar(10) not null,
    siensotikbn varchar(1) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano)
);
comment on table tt_afsiensotitaisyosya is '【住民基本台帳】支援措置対象者情報テーブル';
comment on column tt_afsiensotitaisyosya.atenano is '宛名番号';
comment on column tt_afsiensotitaisyosya.siensotiymdf is '支援措置開始年月日';
comment on column tt_afsiensotitaisyosya.siensotiymdt is '支援措置終了年月日';
comment on column tt_afsiensotitaisyosya.siensotikbn is '支援措置区分';
comment on column tt_afsiensotitaisyosya.reguserid is '登録ユーザーID';
comment on column tt_afsiensotitaisyosya.regdttm is '登録日時';
comment on column tt_afsiensotitaisyosya.upduserid is '更新ユーザーID';
comment on column tt_afsiensotitaisyosya.upddttm is '更新日時';

--【住民基本台帳】支援措置対象者情報履歴テーブル
drop table if exists tt_afsiensotitaisyosya_reki;
create table tt_afsiensotitaisyosya_reki(
    atenano varchar(15) not null,
    rirekino smallint not null,
    siensotiymdf varchar(10) not null,
    siensotiymdt varchar(10) not null,
    siensotikbn varchar(1) not null,
    renkeimotosousauserid varchar(10) not null,
    renkeimotosousadttm timestamp not null,
    saisinflg boolean not null default true,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,rirekino,siensotiymdf)
);
comment on table tt_afsiensotitaisyosya_reki is '【住民基本台帳】支援措置対象者情報履歴テーブル';
comment on column tt_afsiensotitaisyosya_reki.atenano is '宛名番号';
comment on column tt_afsiensotitaisyosya_reki.rirekino is '履歴番号';
comment on column tt_afsiensotitaisyosya_reki.siensotiymdf is '支援措置開始年月日';
comment on column tt_afsiensotitaisyosya_reki.siensotiymdt is '支援措置終了年月日';
comment on column tt_afsiensotitaisyosya_reki.siensotikbn is '支援措置区分';
comment on column tt_afsiensotitaisyosya_reki.renkeimotosousauserid is '連携元操作者ID';
comment on column tt_afsiensotitaisyosya_reki.renkeimotosousadttm is '連携元操作日時';
comment on column tt_afsiensotitaisyosya_reki.saisinflg is '最新フラグ';
comment on column tt_afsiensotitaisyosya_reki.reguserid is '登録ユーザーID';
comment on column tt_afsiensotitaisyosya_reki.regdttm is '登録日時';
comment on column tt_afsiensotitaisyosya_reki.upduserid is '更新ユーザーID';
comment on column tt_afsiensotitaisyosya_reki.upddttm is '更新日時';

--使用履歴テーブル
drop table if exists tt_afsiyorireki;
create table tt_afsiyorireki(
    userid varchar(10) not null,
    kinoid varchar(10) not null,
    syoridttm timestamp not null,
primary key(userid,kinoid)
);
comment on table tt_afsiyorireki is '使用履歴テーブル';
comment on column tt_afsiyorireki.userid is 'ユーザーID';
comment on column tt_afsiyorireki.kinoid is '機能ID';
comment on column tt_afsiyorireki.syoridttm is '処理日時';

--送付先管理テーブル
drop table if exists tt_afsofusaki;
create table tt_afsofusaki(
    atenano varchar(15) not null,
    riyomokuteki varchar(3) not null,
    adrs_sikucd varchar(6) not null,
    adrs_tyoazacd varchar(7) not null,
    adrs_todofuken varchar(4) not null,
    adrs_sikunm varchar(12) not null,
    adrs_tyoaza varchar(120),
    adrs_bantihyoki varchar(50),
    adrs_katagaki varchar(300),
    adrs_yubin varchar(7),
    sofusaki_simei varchar(100) not null,
    torokujiyu varchar(1),
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,riyomokuteki)
);
comment on table tt_afsofusaki is '送付先管理テーブル';
comment on column tt_afsofusaki.atenano is '宛名番号';
comment on column tt_afsofusaki.riyomokuteki is '利用目的';
comment on column tt_afsofusaki.adrs_sikucd is '住所_市区町村コード';
comment on column tt_afsofusaki.adrs_tyoazacd is '住所_町字コード';
comment on column tt_afsofusaki.adrs_todofuken is '住所_都道府県';
comment on column tt_afsofusaki.adrs_sikunm is '住所_市区郡町村名';
comment on column tt_afsofusaki.adrs_tyoaza is '住所_町字';
comment on column tt_afsofusaki.adrs_bantihyoki is '住所_番地号表記';
comment on column tt_afsofusaki.adrs_katagaki is '住所_方書';
comment on column tt_afsofusaki.adrs_yubin is '住所_郵便番号';
comment on column tt_afsofusaki.sofusaki_simei is '送付先氏名';
comment on column tt_afsofusaki.torokujiyu is '登録事由';
comment on column tt_afsofusaki.regsisyo is '登録支所';
comment on column tt_afsofusaki.reguserid is '登録ユーザーID';
comment on column tt_afsofusaki.regdttm is '登録日時';
comment on column tt_afsofusaki.upduserid is '更新ユーザーID';
comment on column tt_afsofusaki.upddttm is '更新日時';

--【障害者福祉】身体障害者手帳等情報テーブル
drop table if exists tt_afsyogaitetyo;
create table tt_afsyogaitetyo(
    atenano varchar(15) not null,
    henkanymd varchar(10),
    sikakujotaicd varchar(2) not null,
    syokaikofuymd varchar(10),
    tetyono varchar(10),
    tokeibuicd varchar(2),
    syogainm varchar(1000),
    syogaisyubetucd varchar(1),
    sogotokyucd varchar(1),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano)
);
comment on table tt_afsyogaitetyo is '【障害者福祉】身体障害者手帳等情報テーブル';
comment on column tt_afsyogaitetyo.atenano is '宛名番号';
comment on column tt_afsyogaitetyo.henkanymd is '返還日';
comment on column tt_afsyogaitetyo.sikakujotaicd is '資格状態コード';
comment on column tt_afsyogaitetyo.syokaikofuymd is '初回交付日';
comment on column tt_afsyogaitetyo.tetyono is '手帳番号';
comment on column tt_afsyogaitetyo.tokeibuicd is '統計部位コード';
comment on column tt_afsyogaitetyo.syogainm is '障害名';
comment on column tt_afsyogaitetyo.syogaisyubetucd is '障害種別コード';
comment on column tt_afsyogaitetyo.sogotokyucd is '総合等級コード';
comment on column tt_afsyogaitetyo.reguserid is '登録ユーザーID';
comment on column tt_afsyogaitetyo.regdttm is '登録日時';
comment on column tt_afsyogaitetyo.upduserid is '更新ユーザーID';
comment on column tt_afsyogaitetyo.upddttm is '更新日時';

--【障害者福祉】身体障害者手帳等情報履歴テーブル
drop table if exists tt_afsyogaitetyo_reki;
create table tt_afsyogaitetyo_reki(
    atenano varchar(15) not null,
    rirekino integer not null,
    henkanymd varchar(10),
    sikakujotaicd varchar(2) not null,
    syokaikofuymd varchar(10),
    tetyono varchar(10),
    tokeibuicd varchar(2),
    syogainm varchar(1000),
    syogaisyubetucd varchar(1),
    sogotokyucd varchar(1),
    renkeimotosousauserid varchar(10) not null,
    renkeimotosousadttm timestamp not null,
    saisinflg boolean not null default true,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,rirekino)
);
comment on table tt_afsyogaitetyo_reki is '【障害者福祉】身体障害者手帳等情報履歴テーブル';
comment on column tt_afsyogaitetyo_reki.atenano is '宛名番号';
comment on column tt_afsyogaitetyo_reki.rirekino is '履歴番号';
comment on column tt_afsyogaitetyo_reki.henkanymd is '返還日';
comment on column tt_afsyogaitetyo_reki.sikakujotaicd is '資格状態コード';
comment on column tt_afsyogaitetyo_reki.syokaikofuymd is '初回交付日';
comment on column tt_afsyogaitetyo_reki.tetyono is '手帳番号';
comment on column tt_afsyogaitetyo_reki.tokeibuicd is '統計部位コード';
comment on column tt_afsyogaitetyo_reki.syogainm is '障害名';
comment on column tt_afsyogaitetyo_reki.syogaisyubetucd is '障害種別コード';
comment on column tt_afsyogaitetyo_reki.sogotokyucd is '総合等級コード';
comment on column tt_afsyogaitetyo_reki.renkeimotosousauserid is '連携元操作者ID';
comment on column tt_afsyogaitetyo_reki.renkeimotosousadttm is '連携元操作日時';
comment on column tt_afsyogaitetyo_reki.saisinflg is '最新フラグ';
comment on column tt_afsyogaitetyo_reki.reguserid is '登録ユーザーID';
comment on column tt_afsyogaitetyo_reki.regdttm is '登録日時';
comment on column tt_afsyogaitetyo_reki.upduserid is '更新ユーザーID';
comment on column tt_afsyogaitetyo_reki.upddttm is '更新日時';

--トークンテーブル
drop table if exists tt_aftoken;
create table tt_aftoken(
    tokenseq bigserial not null,
    userid varchar(10) not null,
    regsisyo varchar(3),
    sisyocd varchar,
    gamenauth varchar,
    rolekbn varchar(1) not null,
    syozokucd varchar(3),
    kanrisyaflg boolean not null default false,
    pnoeditflg boolean not null default false,
    alertviewflg boolean not null default false,
    accessdttm timestamp not null,
primary key(tokenseq)
);
comment on table tt_aftoken is 'トークンテーブル';
comment on column tt_aftoken.tokenseq is 'トークンシーケンス';
comment on column tt_aftoken.userid is 'ユーザーID';
comment on column tt_aftoken.regsisyo is '登録支所';
comment on column tt_aftoken.sisyocd is '部署（支所）コード';
comment on column tt_aftoken.gamenauth is '画面権限';
comment on column tt_aftoken.rolekbn is 'ロール区分';
comment on column tt_aftoken.syozokucd is '所属グループコード';
comment on column tt_aftoken.kanrisyaflg is '管理者フラグ';
comment on column tt_aftoken.pnoeditflg is '個人番号操作権限付与フラグ';
comment on column tt_aftoken.alertviewflg is '警告参照フラグ';
comment on column tt_aftoken.accessdttm is 'アクセス日時';

--通信ログテーブル
drop table if exists tt_aftusinlog;
create table tt_aftusinlog(
    tusinlogseq bigserial not null,
    sessionseq bigint not null,
    syoridttmf timestamp not null,
    syoridttmt timestamp not null,
    msg varchar,
    request varchar,
    response varchar,
    ipadrs varchar(15),
    os varchar(50),
    browser varchar(100),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
primary key(tusinlogseq)
);
comment on table tt_aftusinlog is '通信ログテーブル';
comment on column tt_aftusinlog.tusinlogseq is '通信ログシーケンス';
comment on column tt_aftusinlog.sessionseq is 'セッションシーケンス';
comment on column tt_aftusinlog.syoridttmf is '処理日時（開始）';
comment on column tt_aftusinlog.syoridttmt is '処理日時（終了）';
comment on column tt_aftusinlog.msg is 'メッセージ';
comment on column tt_aftusinlog.request is 'リクエスト';
comment on column tt_aftusinlog.response is 'レスポンス';
comment on column tt_aftusinlog.ipadrs is 'IPアドレス';
comment on column tt_aftusinlog.os is 'OS';
comment on column tt_aftusinlog.browser is 'ブラウザー情報';
comment on column tt_aftusinlog.reguserid is '登録ユーザーID';
comment on column tt_aftusinlog.regdttm is '登録日時';

--ユーザー所属部署（支所）テーブル
drop table if exists tt_afuser_sisyo;
create table tt_afuser_sisyo(
    userid varchar(10) not null,
    sisyocd varchar(3) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(userid,sisyocd)
);
comment on table tt_afuser_sisyo is 'ユーザー所属部署（支所）テーブル';
comment on column tt_afuser_sisyo.userid is 'ユーザーID';
comment on column tt_afuser_sisyo.sisyocd is '部署（支所）コード';
comment on column tt_afuser_sisyo.reguserid is '登録ユーザーID';
comment on column tt_afuser_sisyo.regdttm is '登録日時';
comment on column tt_afuser_sisyo.upduserid is '更新ユーザーID';
comment on column tt_afuser_sisyo.upddttm is '更新日時';

--タスクスケジュールマスタ
drop table if exists tm_aftaskschedule;
create table tm_aftaskschedule(
    taskid varchar(6) not null,
    tasknm varchar not null,
    renkeiid varchar,
    biko varchar,
    zenjikkodttmf timestamp,
    zenjikkodttmt timestamp,
    jikaijikkodttmt timestamp,
    syorikbn varchar(1) not null,
    gyomukbn varchar(1) not null,
    modulecd varchar not null,
    hikisu varchar,
    yukoymdf varchar(10) not null,
    yukotmf varchar(4) not null,
    hindokbn varchar(1) not null,
    syukustopflg boolean not null,
    yobi varchar(7),
    maitukihiyobikbn varchar(1),
    maitukituki varchar(12),
    maitukihi varchar(32),
    maitukisyu varchar(5),
    statuscd varchar(1),
    kurikaesikanflg boolean,
    kurikaesikankbn varchar(1),
    jikantaif varchar(2),
    jikantait varchar(2),
    jikannaif varchar(2),
    jikannait varchar(2),
    stopflg boolean not null default false,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(taskid)
);
comment on table tm_aftaskschedule is 'タスクスケジュールマスタ';
comment on column tm_aftaskschedule.taskid is 'タスクID';
comment on column tm_aftaskschedule.tasknm is 'タスク名';
comment on column tm_aftaskschedule.renkeiid is 'HangFire連携ID';
comment on column tm_aftaskschedule.biko is '説明';
comment on column tm_aftaskschedule.zenjikkodttmf is '前回の実行日時（開始）';
comment on column tm_aftaskschedule.zenjikkodttmt is '前回の実行日時（終了）';
comment on column tm_aftaskschedule.jikaijikkodttmt is '次回実行日時';
comment on column tm_aftaskschedule.syorikbn is '処理区分';
comment on column tm_aftaskschedule.gyomukbn is '業務区分';
comment on column tm_aftaskschedule.modulecd is 'モジュールコード';
comment on column tm_aftaskschedule.hikisu is '引数';
comment on column tm_aftaskschedule.yukoymdf is '有効年月日（開始）';
comment on column tm_aftaskschedule.yukotmf is '有効時間（開始）';
comment on column tm_aftaskschedule.hindokbn is '頻度区分';
comment on column tm_aftaskschedule.syukustopflg is '祝日停止フラグ';
comment on column tm_aftaskschedule.yobi is '曜日';
comment on column tm_aftaskschedule.maitukihiyobikbn is '毎月の日・曜日区分';
comment on column tm_aftaskschedule.maitukituki is '毎月の月';
comment on column tm_aftaskschedule.maitukihi is '毎月の日';
comment on column tm_aftaskschedule.maitukisyu is '毎月の週';
comment on column tm_aftaskschedule.statuscd is '処理結果コード';
comment on column tm_aftaskschedule.kurikaesikanflg is '繰り返し間隔フラグ';
comment on column tm_aftaskschedule.kurikaesikankbn is '繰り返し間隔区分';
comment on column tm_aftaskschedule.jikantaif is '時間帯開始_時';
comment on column tm_aftaskschedule.jikantait is '時間帯終了_時';
comment on column tm_aftaskschedule.jikannaif is '時間内開始_分';
comment on column tm_aftaskschedule.jikannait is '時間内終了_分';
comment on column tm_aftaskschedule.stopflg is '使用停止フラグ';
comment on column tm_aftaskschedule.reguserid is '登録ユーザーID';
comment on column tm_aftaskschedule.regdttm is '登録日時';
comment on column tm_aftaskschedule.upduserid is '更新ユーザーID';
comment on column tm_aftaskschedule.upddttm is '更新日時';

--基準値マスタ
drop table if exists tm_kkkijun;
create table tm_kkkijun(
    gyomukbn varchar(2) not null,
    kijunjigyocd varchar(5) not null,
    itemcd varchar(12) not null,
    edano smallint not null,
    yukoymdf varchar(10) not null,
    yukoymdt varchar(10) not null,
    agef smallint,
    aget smallint,
    sex varchar(1),
    kijunvaluehyoki varchar(100),
    alertvaluehyoki varchar(100),
    errvaluehyoki varchar(100),
    errvalue1t double precision,
    alertvalue1f double precision,
    alertvalue1t double precision,
    kijunvaluef double precision,
    kijunvaluet double precision,
    alertvalue2f double precision,
    alertvalue2t double precision,
    errvalue2f double precision,
    hanteicd varchar(100),
    alerthanteicd varchar(100),
    errhanteicd varchar(100),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(gyomukbn,kijunjigyocd,itemcd,edano)
);
comment on table tm_kkkijun is '基準値マスタ';
comment on column tm_kkkijun.gyomukbn is '業務区分';
comment on column tm_kkkijun.kijunjigyocd is '基準値事業コード';
comment on column tm_kkkijun.itemcd is '項目コード';
comment on column tm_kkkijun.edano is '枝番';
comment on column tm_kkkijun.yukoymdf is '有効年月日（開始）';
comment on column tm_kkkijun.yukoymdt is '有効年月日（終了）';
comment on column tm_kkkijun.agef is '年齢（開始）';
comment on column tm_kkkijun.aget is '年齢（終了）';
comment on column tm_kkkijun.sex is '性別';
comment on column tm_kkkijun.kijunvaluehyoki is '基準値表記';
comment on column tm_kkkijun.alertvaluehyoki is '注意値表記';
comment on column tm_kkkijun.errvaluehyoki is '異常値表記';
comment on column tm_kkkijun.errvalue1t is '異常値（数値）以下';
comment on column tm_kkkijun.alertvalue1f is '注意値（数値）開始';
comment on column tm_kkkijun.alertvalue1t is '注意値（数値）終了';
comment on column tm_kkkijun.kijunvaluef is '基準値（数値）開始';
comment on column tm_kkkijun.kijunvaluet is '基準値（数値）終了';
comment on column tm_kkkijun.alertvalue2f is '注意値（数値）開始';
comment on column tm_kkkijun.alertvalue2t is '注意値（数値）終了';
comment on column tm_kkkijun.errvalue2f is '異常値（数値）以上';
comment on column tm_kkkijun.hanteicd is '基準値（コード）';
comment on column tm_kkkijun.alerthanteicd is '注意値（コード）';
comment on column tm_kkkijun.errhanteicd is '異常値（コード）';
comment on column tm_kkkijun.reguserid is '登録ユーザーID';
comment on column tm_kkkijun.regdttm is '登録日時';
comment on column tm_kkkijun.upduserid is '更新ユーザーID';
comment on column tm_kkkijun.upddttm is '更新日時';

--指導（フリー項目）コントロールマスタ
drop table if exists tm_kksidofreeitem;
create table tm_kksidofreeitem(
    sidokbn varchar(1) not null,
    gyomukbn varchar(2) not null,
    mosikomikekkakbn varchar(1) not null,
    itemyotokbn varchar(1) not null,
    itemcd varchar(12) not null,
    itemnm varchar(100) not null,
    itemkbn varchar(1) not null,
    groupid varchar(2),
    groupid2 varchar(2),
    inputtype smallint not null,
    codejoken1 varchar(100),
    codejoken2 varchar(100),
    codejoken3 varchar(100),
    keta varchar(10),
    hissuflg boolean not null default false,
    hanif varchar(100),
    hanit varchar(100),
    inputflg boolean not null default true,
    msgkbn smallint not null,
    tani varchar(100),
    syokiti varchar(1000),
    orderseq smallint not null,
    syukeikbn varchar(100),
    komokutokuteikbn varchar(2),
    keisankbn varchar(1),
    keisansusiki varchar(2000),
    keisankansuid varchar(20),
    keisanparam varchar,
    biko varchar(1000),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(sidokbn,gyomukbn,mosikomikekkakbn,itemyotokbn,itemcd)
);
comment on table tm_kksidofreeitem is '指導（フリー項目）コントロールマスタ';
comment on column tm_kksidofreeitem.sidokbn is '指導区分';
comment on column tm_kksidofreeitem.gyomukbn is '業務区分';
comment on column tm_kksidofreeitem.mosikomikekkakbn is '申込結果区分';
comment on column tm_kksidofreeitem.itemyotokbn is '項目用途区分';
comment on column tm_kksidofreeitem.itemcd is '項目コード';
comment on column tm_kksidofreeitem.itemnm is '項目名';
comment on column tm_kksidofreeitem.itemkbn is '項目区分';
comment on column tm_kksidofreeitem.groupid is 'グループID';
comment on column tm_kksidofreeitem.groupid2 is 'グループID2';
comment on column tm_kksidofreeitem.inputtype is '入力タイプ';
comment on column tm_kksidofreeitem.codejoken1 is 'コード条件1';
comment on column tm_kksidofreeitem.codejoken2 is 'コード条件2';
comment on column tm_kksidofreeitem.codejoken3 is 'コード条件3';
comment on column tm_kksidofreeitem.keta is '入力桁';
comment on column tm_kksidofreeitem.hissuflg is '必須フラグ';
comment on column tm_kksidofreeitem.hanif is '入力範囲（開始）';
comment on column tm_kksidofreeitem.hanit is '入力範囲（終了）';
comment on column tm_kksidofreeitem.inputflg is '入力フラグ';
comment on column tm_kksidofreeitem.msgkbn is 'メッセージ区分';
comment on column tm_kksidofreeitem.tani is '単位';
comment on column tm_kksidofreeitem.syokiti is '初期値';
comment on column tm_kksidofreeitem.orderseq is '並びシーケンス';
comment on column tm_kksidofreeitem.syukeikbn is '利用地域保健集計区分';
comment on column tm_kksidofreeitem.komokutokuteikbn is '項目特定区分';
comment on column tm_kksidofreeitem.keisankbn is '計算区分';
comment on column tm_kksidofreeitem.keisansusiki is '計算数式';
comment on column tm_kksidofreeitem.keisankansuid is '計算関数ID';
comment on column tm_kksidofreeitem.keisanparam is '計算パラメータ';
comment on column tm_kksidofreeitem.biko is '備考';
comment on column tm_kksidofreeitem.reguserid is '登録ユーザーID';
comment on column tm_kksidofreeitem.regdttm is '登録日時';
comment on column tm_kksidofreeitem.upduserid is '更新ユーザーID';
comment on column tm_kksidofreeitem.upddttm is '更新日時';

--その他日程事業・保健指導事業マスタ
drop table if exists tm_kksonotasidojigyo;
create table tm_kksonotasidojigyo(
    jigyocd varchar(5) not null,
    jigyonm varchar(100) not null,
    gyomukbn varchar(2) not null,
    yoyakuriyoflg boolean not null default false,
    homonriyoflg boolean not null default false,
    sodanriyoflg boolean not null default false,
    syudanriyoflg boolean not null default false,
    stopflg boolean not null default false,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(jigyocd)
);
comment on table tm_kksonotasidojigyo is 'その他日程事業・保健指導事業マスタ';
comment on column tm_kksonotasidojigyo.jigyocd is 'その他日程事業・保健指導事業コード';
comment on column tm_kksonotasidojigyo.jigyonm is 'その他日程事業・保健指導事業名';
comment on column tm_kksonotasidojigyo.gyomukbn is '業務区分';
comment on column tm_kksonotasidojigyo.yoyakuriyoflg is '予約利用フラグ';
comment on column tm_kksonotasidojigyo.homonriyoflg is '訪問利用フラグ';
comment on column tm_kksonotasidojigyo.sodanriyoflg is '相談利用フラグ';
comment on column tm_kksonotasidojigyo.syudanriyoflg is '集団利用フラグ';
comment on column tm_kksonotasidojigyo.stopflg is '使用停止フラグ';
comment on column tm_kksonotasidojigyo.reguserid is '登録ユーザーID';
comment on column tm_kksonotasidojigyo.regdttm is '登録日時';
comment on column tm_kksonotasidojigyo.upduserid is '更新ユーザーID';
comment on column tm_kksonotasidojigyo.upddttm is '更新日時';

--フォロー結果情報テーブル
drop table if exists tt_kkfollowkekka;
create table tt_kkfollowkekka(
    atenano varchar(15) not null,
    follownaiyoedano integer not null,
    edano integer not null,
    followjigyocd varchar(5),
    followhoho varchar(1),
    followjissiymd varchar(10),
    followtm varchar(4),
    followkaijocd varchar(7),
    followkekka varchar(200),
    followstaffid varchar(10),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,follownaiyoedano,edano)
);
comment on table tt_kkfollowkekka is 'フォロー結果情報テーブル';
comment on column tt_kkfollowkekka.atenano is '宛名番号';
comment on column tt_kkfollowkekka.follownaiyoedano is 'フォロー内容枝番';
comment on column tt_kkfollowkekka.edano is '枝番';
comment on column tt_kkfollowkekka.followjigyocd is 'フォロー事業コード';
comment on column tt_kkfollowkekka.followhoho is 'フォロー方法';
comment on column tt_kkfollowkekka.followjissiymd is 'フォロー実施日';
comment on column tt_kkfollowkekka.followtm is 'フォロー時間';
comment on column tt_kkfollowkekka.followkaijocd is 'フォロー会場コード';
comment on column tt_kkfollowkekka.followkekka is 'フォロー結果';
comment on column tt_kkfollowkekka.followstaffid is 'フォロー担当者';
comment on column tt_kkfollowkekka.reguserid is '登録ユーザーID';
comment on column tt_kkfollowkekka.regdttm is '登録日時';
comment on column tt_kkfollowkekka.upduserid is '更新ユーザーID';
comment on column tt_kkfollowkekka.upddttm is '更新日時';

--フォロー内容情報テーブル
drop table if exists tt_kkfollownaiyo;
create table tt_kkfollownaiyo(
    atenano varchar(15) not null,
    follownaiyoedano integer not null,
    follownaiyo varchar(200),
    followstatus varchar(1) not null,
    haakukeiro varchar(1) not null,
    haakujigyocd varchar(5) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,follownaiyoedano)
);
comment on table tt_kkfollownaiyo is 'フォロー内容情報テーブル';
comment on column tt_kkfollownaiyo.atenano is '宛名番号';
comment on column tt_kkfollownaiyo.follownaiyoedano is 'フォロー内容枝番';
comment on column tt_kkfollownaiyo.follownaiyo is 'フォロー内容';
comment on column tt_kkfollownaiyo.followstatus is 'フォロー状況';
comment on column tt_kkfollownaiyo.haakukeiro is '把握経路';
comment on column tt_kkfollownaiyo.haakujigyocd is 'フォロー把握事業コード';
comment on column tt_kkfollownaiyo.regsisyo is '登録支所';
comment on column tt_kkfollownaiyo.reguserid is '登録ユーザーID';
comment on column tt_kkfollownaiyo.regdttm is '登録日時';
comment on column tt_kkfollownaiyo.upduserid is '更新ユーザーID';
comment on column tt_kkfollownaiyo.upddttm is '更新日時';

--フォロー予定情報テーブル
drop table if exists tt_kkfollowyotei;
create table tt_kkfollowyotei(
    atenano varchar(15) not null,
    follownaiyoedano integer not null,
    edano integer not null,
    followjigyocd varchar(5),
    followhoho varchar(1),
    followyoteiymd varchar(10),
    followtm varchar(4),
    followkaijocd varchar(7),
    followriyu varchar(200),
    followstaffid varchar(10),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,follownaiyoedano,edano)
);
comment on table tt_kkfollowyotei is 'フォロー予定情報テーブル';
comment on column tt_kkfollowyotei.atenano is '宛名番号';
comment on column tt_kkfollowyotei.follownaiyoedano is 'フォロー内容枝番';
comment on column tt_kkfollowyotei.edano is '枝番';
comment on column tt_kkfollowyotei.followjigyocd is 'フォロー事業コード';
comment on column tt_kkfollowyotei.followhoho is 'フォロー方法';
comment on column tt_kkfollowyotei.followyoteiymd is 'フォロー予定日';
comment on column tt_kkfollowyotei.followtm is 'フォロー時間';
comment on column tt_kkfollowyotei.followkaijocd is 'フォロー会場コード';
comment on column tt_kkfollowyotei.followriyu is 'フォロー理由';
comment on column tt_kkfollowyotei.followstaffid is 'フォロー担当者';
comment on column tt_kkfollowyotei.reguserid is '登録ユーザーID';
comment on column tt_kkfollowyotei.regdttm is '登録日時';
comment on column tt_kkfollowyotei.upduserid is '更新ユーザーID';
comment on column tt_kkfollowyotei.upddttm is '更新日時';

--保健指導事業（フリー項目）入力情報テーブル
drop table if exists tt_kkhokensidofree;
create table tt_kkhokensidofree(
    hokensidokbn varchar(1) not null,
    gyomukbn varchar(2) not null,
    mosikomikekkakbn varchar(1) not null,
    itemcd varchar(12) not null,
    atenano varchar(15) not null,
    edano integer not null,
    fusyoflg boolean not null,
    numvalue double precision,
    strvalue varchar(1000),
primary key(hokensidokbn,gyomukbn,mosikomikekkakbn,itemcd,atenano,edano)
);
comment on table tt_kkhokensidofree is '保健指導事業（フリー項目）入力情報テーブル';
comment on column tt_kkhokensidofree.hokensidokbn is '保健指導区分';
comment on column tt_kkhokensidofree.gyomukbn is '業務区分';
comment on column tt_kkhokensidofree.mosikomikekkakbn is '申込結果区分';
comment on column tt_kkhokensidofree.itemcd is '項目コード';
comment on column tt_kkhokensidofree.atenano is '宛名番号';
comment on column tt_kkhokensidofree.edano is '枝番';
comment on column tt_kkhokensidofree.fusyoflg is '不詳フラグ';
comment on column tt_kkhokensidofree.numvalue is '数値項目';
comment on column tt_kkhokensidofree.strvalue is '文字項目';

--保健指導結果情報（固定項目）テーブル
drop table if exists tt_kkhokensido_kekka;
create table tt_kkhokensido_kekka(
    hokensidokbn varchar(1) not null,
    gyomukbn varchar(2) not null,
    atenano varchar(15) not null,
    edano integer not null,
    jigyocd varchar(5) not null,
    jissiymd varchar(10) not null,
    tmf varchar(4) not null,
    tmt varchar(4),
    kaijocd varchar(7),
    syukeikbn varchar(3) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(hokensidokbn,gyomukbn,atenano,edano)
);
comment on table tt_kkhokensido_kekka is '保健指導結果情報（固定項目）テーブル';
comment on column tt_kkhokensido_kekka.hokensidokbn is '保健指導区分';
comment on column tt_kkhokensido_kekka.gyomukbn is '業務区分';
comment on column tt_kkhokensido_kekka.atenano is '宛名番号';
comment on column tt_kkhokensido_kekka.edano is '枝番';
comment on column tt_kkhokensido_kekka.jigyocd is 'その他日程事業・保健指導事業コード';
comment on column tt_kkhokensido_kekka.jissiymd is '実施日';
comment on column tt_kkhokensido_kekka.tmf is '開始時間';
comment on column tt_kkhokensido_kekka.tmt is '終了時間';
comment on column tt_kkhokensido_kekka.kaijocd is '会場コード';
comment on column tt_kkhokensido_kekka.syukeikbn is '地域保健集計区分';
comment on column tt_kkhokensido_kekka.regsisyo is '登録支所';
comment on column tt_kkhokensido_kekka.reguserid is '登録ユーザーID';
comment on column tt_kkhokensido_kekka.regdttm is '登録日時';
comment on column tt_kkhokensido_kekka.upduserid is '更新ユーザーID';
comment on column tt_kkhokensido_kekka.upddttm is '更新日時';

--保健指導申込情報（固定項目）テーブル
drop table if exists tt_kkhokensido_mosikomi;
create table tt_kkhokensido_mosikomi(
    hokensidokbn varchar(1) not null,
    gyomukbn varchar(2) not null,
    atenano varchar(15) not null,
    edano integer not null,
    jigyocd varchar(5) not null,
    yoteiymd varchar(10),
    yoteitm varchar(4),
    kaijocd varchar(7),
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(hokensidokbn,gyomukbn,atenano,edano)
);
comment on table tt_kkhokensido_mosikomi is '保健指導申込情報（固定項目）テーブル';
comment on column tt_kkhokensido_mosikomi.hokensidokbn is '保健指導区分';
comment on column tt_kkhokensido_mosikomi.gyomukbn is '業務区分';
comment on column tt_kkhokensido_mosikomi.atenano is '宛名番号';
comment on column tt_kkhokensido_mosikomi.edano is '枝番';
comment on column tt_kkhokensido_mosikomi.jigyocd is 'その他日程事業・保健指導事業コード';
comment on column tt_kkhokensido_mosikomi.yoteiymd is '実施予定日';
comment on column tt_kkhokensido_mosikomi.yoteitm is '予定開始時間';
comment on column tt_kkhokensido_mosikomi.kaijocd is '会場コード';
comment on column tt_kkhokensido_mosikomi.regsisyo is '登録支所';
comment on column tt_kkhokensido_mosikomi.reguserid is '登録ユーザーID';
comment on column tt_kkhokensido_mosikomi.regdttm is '登録日時';
comment on column tt_kkhokensido_mosikomi.upduserid is '更新ユーザーID';
comment on column tt_kkhokensido_mosikomi.upddttm is '更新日時';

--保健指導担当者テーブル
drop table if exists tt_kkhokensido_staff;
create table tt_kkhokensido_staff(
    hokensidokbn varchar(1) not null,
    gyomukbn varchar(2) not null,
    atenano varchar(15) not null,
    edano integer not null,
    mosikomikekkakbn varchar(1) not null,
    staffid varchar(10) not null,
primary key(hokensidokbn,gyomukbn,atenano,edano,mosikomikekkakbn,staffid)
);
comment on table tt_kkhokensido_staff is '保健指導担当者テーブル';
comment on column tt_kkhokensido_staff.hokensidokbn is '保健指導区分';
comment on column tt_kkhokensido_staff.gyomukbn is '業務区分';
comment on column tt_kkhokensido_staff.atenano is '宛名番号';
comment on column tt_kkhokensido_staff.edano is '枝番';
comment on column tt_kkhokensido_staff.mosikomikekkakbn is '申込結果区分';
comment on column tt_kkhokensido_staff.staffid is '担当者';

--実施報告書（日報）情報テーブル
drop table if exists tt_kkjissihokokusyo;
create table tt_kkjissihokokusyo(
    hokokusyono bigint not null,
    jigyocd varchar(5) not null,
    jissiymd varchar(10) not null,
    kaijocd varchar(7) not null,
    timef varchar(4),
    timet varchar(4),
    syussekisya integer,
    jissinaiyo varchar(1000),
    haifusiryo varchar(1000),
    baitai varchar(200),
    mantotalnum integer default 0,
    womantotalnum integer default 0,
    fumeitotalnum integer default 0,
    mannum integer default 0,
    womannum integer default 0,
    fumeinum integer default 0,
    comment varchar(1000),
    hanseipoint varchar(1000),
    jigyomokuteki varchar(1000),
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(hokokusyono)
);
comment on table tt_kkjissihokokusyo is '実施報告書（日報）情報テーブル';
comment on column tt_kkjissihokokusyo.hokokusyono is '事業報告書番号';
comment on column tt_kkjissihokokusyo.jigyocd is '事業実施報告書（日報）事業コード';
comment on column tt_kkjissihokokusyo.jissiymd is '実施日';
comment on column tt_kkjissihokokusyo.kaijocd is '会場コード';
comment on column tt_kkjissihokokusyo.timef is '開始時間';
comment on column tt_kkjissihokokusyo.timet is '終了時間';
comment on column tt_kkjissihokokusyo.syussekisya is '出席者数';
comment on column tt_kkjissihokokusyo.jissinaiyo is '実施内容';
comment on column tt_kkjissihokokusyo.haifusiryo is '配布資料';
comment on column tt_kkjissihokokusyo.baitai is '媒体';
comment on column tt_kkjissihokokusyo.mantotalnum is '男性延べ人数';
comment on column tt_kkjissihokokusyo.womantotalnum is '女性延べ人数';
comment on column tt_kkjissihokokusyo.fumeitotalnum is '性別不明延べ人数';
comment on column tt_kkjissihokokusyo.mannum is '男性実人数';
comment on column tt_kkjissihokokusyo.womannum is '女性実人数';
comment on column tt_kkjissihokokusyo.fumeinum is '性別不明実人数';
comment on column tt_kkjissihokokusyo.comment is 'コメント';
comment on column tt_kkjissihokokusyo.hanseipoint is '反省点';
comment on column tt_kkjissihokokusyo.jigyomokuteki is '事業目的';
comment on column tt_kkjissihokokusyo.regsisyo is '登録支所';
comment on column tt_kkjissihokokusyo.reguserid is '登録ユーザーID';
comment on column tt_kkjissihokokusyo.regdttm is '登録日時';
comment on column tt_kkjissihokokusyo.upduserid is '更新ユーザーID';
comment on column tt_kkjissihokokusyo.upddttm is '更新日時';

--実施報告書（日報）情報サブテーブル
drop table if exists tt_kkjissihokokusyo_sub;
create table tt_kkjissihokokusyo_sub(
    hokokusyono bigint not null,
    staffid varchar(10) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(hokokusyono,staffid)
);
comment on table tt_kkjissihokokusyo_sub is '実施報告書（日報）情報サブテーブル';
comment on column tt_kkjissihokokusyo_sub.hokokusyono is '事業報告書番号';
comment on column tt_kkjissihokokusyo_sub.staffid is '事業従事者ID';
comment on column tt_kkjissihokokusyo_sub.reguserid is '登録ユーザーID';
comment on column tt_kkjissihokokusyo_sub.regdttm is '登録日時';
comment on column tt_kkjissihokokusyo_sub.upduserid is '更新ユーザーID';
comment on column tt_kkjissihokokusyo_sub.upddttm is '更新日時';

--帳票発行対象外者テーブル
drop table if exists tt_kkrpthakkotaisyogaisya;
create table tt_kkrpthakkotaisyogaisya(
    atenano varchar(15) not null,
    rptgroupid varchar(5) not null,
    uketukeymd varchar(10) not null,
    taisyogairiyu varchar(1000),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,rptgroupid)
);
comment on table tt_kkrpthakkotaisyogaisya is '帳票発行対象外者テーブル';
comment on column tt_kkrpthakkotaisyogaisya.atenano is '宛名番号';
comment on column tt_kkrpthakkotaisyogaisya.rptgroupid is '帳票グループID';
comment on column tt_kkrpthakkotaisyogaisya.uketukeymd is '受付日';
comment on column tt_kkrpthakkotaisyogaisya.taisyogairiyu is '対象外理由';
comment on column tt_kkrpthakkotaisyogaisya.reguserid is '登録ユーザーID';
comment on column tt_kkrpthakkotaisyogaisya.regdttm is '登録日時';
comment on column tt_kkrpthakkotaisyogaisya.upduserid is '更新ユーザーID';
comment on column tt_kkrpthakkotaisyogaisya.upddttm is '更新日時';

--集団指導事業（フリー項目）入力情報テーブル
drop table if exists tt_kksyudansidofree;
create table tt_kksyudansidofree(
    gyomukbn varchar(2) not null,
    edano integer not null,
    mosikomikekkakbn varchar(1) not null,
    itemcd varchar(12) not null,
    fusyoflg boolean not null,
    numvalue double precision,
    strvalue varchar(1000),
primary key(gyomukbn,edano,mosikomikekkakbn,itemcd)
);
comment on table tt_kksyudansidofree is '集団指導事業（フリー項目）入力情報テーブル';
comment on column tt_kksyudansidofree.gyomukbn is '業務区分';
comment on column tt_kksyudansidofree.edano is '枝番';
comment on column tt_kksyudansidofree.mosikomikekkakbn is '申込結果区分';
comment on column tt_kksyudansidofree.itemcd is '項目コード';
comment on column tt_kksyudansidofree.fusyoflg is '不詳フラグ';
comment on column tt_kksyudansidofree.numvalue is '数値項目';
comment on column tt_kksyudansidofree.strvalue is '文字項目';

--集団指導結果情報（固定項目）テーブル
drop table if exists tt_kksyudansido_kekka;
create table tt_kksyudansido_kekka(
    gyomukbn varchar(2) not null,
    edano integer not null,
    jigyocd varchar(5) not null,
    jissiymd varchar(10) not null,
    tmf varchar(4) not null,
    tmt varchar(4),
    kaijocd varchar(7),
    syukeikbn varchar(3) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(gyomukbn,edano)
);
comment on table tt_kksyudansido_kekka is '集団指導結果情報（固定項目）テーブル';
comment on column tt_kksyudansido_kekka.gyomukbn is '業務区分';
comment on column tt_kksyudansido_kekka.edano is '枝番';
comment on column tt_kksyudansido_kekka.jigyocd is 'その他日程事業・保健指導事業コード';
comment on column tt_kksyudansido_kekka.jissiymd is '実施日';
comment on column tt_kksyudansido_kekka.tmf is '開始時間';
comment on column tt_kksyudansido_kekka.tmt is '終了時間';
comment on column tt_kksyudansido_kekka.kaijocd is '会場コード';
comment on column tt_kksyudansido_kekka.syukeikbn is '地域保健集計区分';
comment on column tt_kksyudansido_kekka.regsisyo is '登録支所';
comment on column tt_kksyudansido_kekka.reguserid is '登録ユーザーID';
comment on column tt_kksyudansido_kekka.regdttm is '登録日時';
comment on column tt_kksyudansido_kekka.upduserid is '更新ユーザーID';
comment on column tt_kksyudansido_kekka.upddttm is '更新日時';

--集団指導申込情報（固定項目）テーブル
drop table if exists tt_kksyudansido_mosikomi;
create table tt_kksyudansido_mosikomi(
    gyomukbn varchar(2) not null,
    edano integer not null,
    jigyocd varchar(5) not null,
    yoteiymd varchar(10),
    yoteitm varchar(4),
    kaijocd varchar(7),
    nitteno integer,
    nittesyosaino integer,
    coursenm varchar(50),
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(gyomukbn,edano)
);
comment on table tt_kksyudansido_mosikomi is '集団指導申込情報（固定項目）テーブル';
comment on column tt_kksyudansido_mosikomi.gyomukbn is '業務区分';
comment on column tt_kksyudansido_mosikomi.edano is '枝番';
comment on column tt_kksyudansido_mosikomi.jigyocd is 'その他日程事業・保健指導事業コード';
comment on column tt_kksyudansido_mosikomi.yoteiymd is '実施予定日';
comment on column tt_kksyudansido_mosikomi.yoteitm is '予定開始時間';
comment on column tt_kksyudansido_mosikomi.kaijocd is '会場コード';
comment on column tt_kksyudansido_mosikomi.nitteno is '日程番号';
comment on column tt_kksyudansido_mosikomi.nittesyosaino is '日程詳細番号';
comment on column tt_kksyudansido_mosikomi.coursenm is 'コース名';
comment on column tt_kksyudansido_mosikomi.regsisyo is '登録支所';
comment on column tt_kksyudansido_mosikomi.reguserid is '登録ユーザーID';
comment on column tt_kksyudansido_mosikomi.regdttm is '登録日時';
comment on column tt_kksyudansido_mosikomi.upduserid is '更新ユーザーID';
comment on column tt_kksyudansido_mosikomi.upddttm is '更新日時';

--集団指導参加者テーブル
drop table if exists tt_kksyudansido_sankasya;
create table tt_kksyudansido_sankasya(
    gyomukbn varchar(2) not null,
    edano integer not null,
    atenano varchar(15) not null,
    jigyocd varchar(5) not null,
    syukketukbn varchar(1) not null,
primary key(gyomukbn,edano,atenano)
);
comment on table tt_kksyudansido_sankasya is '集団指導参加者テーブル';
comment on column tt_kksyudansido_sankasya.gyomukbn is '業務区分';
comment on column tt_kksyudansido_sankasya.edano is '枝番';
comment on column tt_kksyudansido_sankasya.atenano is '宛名番号';
comment on column tt_kksyudansido_sankasya.jigyocd is 'その他日程事業・保健指導事業コード';
comment on column tt_kksyudansido_sankasya.syukketukbn is '出欠区分';

--集団指導参加者（フリー項目）入力情報テーブル
drop table if exists tt_kksyudansido_sankasyafree;
create table tt_kksyudansido_sankasyafree(
    gyomukbn varchar(2) not null,
    edano integer not null,
    mosikomikekkakbn varchar(1) not null,
    itemcd varchar(12) not null,
    atenano varchar(15) not null,
    fusyoflg boolean not null,
    numvalue double precision,
    strvalue varchar(1000),
primary key(gyomukbn,edano,mosikomikekkakbn,itemcd,atenano)
);
comment on table tt_kksyudansido_sankasyafree is '集団指導参加者（フリー項目）入力情報テーブル';
comment on column tt_kksyudansido_sankasyafree.gyomukbn is '業務区分';
comment on column tt_kksyudansido_sankasyafree.edano is '枝番';
comment on column tt_kksyudansido_sankasyafree.mosikomikekkakbn is '申込結果区分';
comment on column tt_kksyudansido_sankasyafree.itemcd is '項目コード';
comment on column tt_kksyudansido_sankasyafree.atenano is '宛名番号';
comment on column tt_kksyudansido_sankasyafree.fusyoflg is '不詳フラグ';
comment on column tt_kksyudansido_sankasyafree.numvalue is '数値項目';
comment on column tt_kksyudansido_sankasyafree.strvalue is '文字項目';

--集団指導参加者結果情報（固定項目）テーブル
drop table if exists tt_kksyudansido_sankasyakekka;
create table tt_kksyudansido_sankasyakekka(
    gyomukbn varchar(2) not null,
    edano integer not null,
    atenano varchar(15) not null,
    syukeikbn varchar(3),
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(gyomukbn,edano,atenano)
);
comment on table tt_kksyudansido_sankasyakekka is '集団指導参加者結果情報（固定項目）テーブル';
comment on column tt_kksyudansido_sankasyakekka.gyomukbn is '業務区分';
comment on column tt_kksyudansido_sankasyakekka.edano is '枝番';
comment on column tt_kksyudansido_sankasyakekka.atenano is '宛名番号';
comment on column tt_kksyudansido_sankasyakekka.syukeikbn is '地域保健集計区分';
comment on column tt_kksyudansido_sankasyakekka.regsisyo is '登録支所';
comment on column tt_kksyudansido_sankasyakekka.reguserid is '登録ユーザーID';
comment on column tt_kksyudansido_sankasyakekka.regdttm is '登録日時';
comment on column tt_kksyudansido_sankasyakekka.upduserid is '更新ユーザーID';
comment on column tt_kksyudansido_sankasyakekka.upddttm is '更新日時';

--集団指導参加者申込情報（固定項目）テーブル
drop table if exists tt_kksyudansido_sankasyamosikomi;
create table tt_kksyudansido_sankasyamosikomi(
    gyomukbn varchar(2) not null,
    edano integer not null,
    atenano varchar(15) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(gyomukbn,edano,atenano)
);
comment on table tt_kksyudansido_sankasyamosikomi is '集団指導参加者申込情報（固定項目）テーブル';
comment on column tt_kksyudansido_sankasyamosikomi.gyomukbn is '業務区分';
comment on column tt_kksyudansido_sankasyamosikomi.edano is '枝番';
comment on column tt_kksyudansido_sankasyamosikomi.atenano is '宛名番号';
comment on column tt_kksyudansido_sankasyamosikomi.regsisyo is '登録支所';
comment on column tt_kksyudansido_sankasyamosikomi.reguserid is '登録ユーザーID';
comment on column tt_kksyudansido_sankasyamosikomi.regdttm is '登録日時';
comment on column tt_kksyudansido_sankasyamosikomi.upduserid is '更新ユーザーID';
comment on column tt_kksyudansido_sankasyamosikomi.upddttm is '更新日時';

--集団指導担当者テーブル
drop table if exists tt_kksyudansido_staff;
create table tt_kksyudansido_staff(
    gyomukbn varchar(2) not null,
    edano integer not null,
    mosikomikekkakbn varchar(1) not null,
    staffid varchar(10) not null,
primary key(gyomukbn,edano,mosikomikekkakbn,staffid)
);
comment on table tt_kksyudansido_staff is '集団指導担当者テーブル';
comment on column tt_kksyudansido_staff.gyomukbn is '業務区分';
comment on column tt_kksyudansido_staff.edano is '枝番';
comment on column tt_kksyudansido_staff.mosikomikekkakbn is '申込結果区分';
comment on column tt_kksyudansido_staff.staffid is '担当者';

--一括取込入力マスタ
drop table if exists tm_kktorinyuryoku;
create table tm_kktorinyuryoku(
    torinyuryokuno varchar(4) not null,
    torinyuryokunm varchar(50) not null,
    torinyuryokbn varchar(1) not null,
    gyomukbn varchar(2) not null,
    nendohyojiflg boolean not null default false,
    nendohanikbn varchar(1),
    torokukbn varchar(1) not null,
    comment varchar(100),
    proccheck varchar(100),
    procbefore varchar(100),
    procafter varchar(100),
    orderseq smallint not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(torinyuryokuno)
);
comment on table tm_kktorinyuryoku is '一括取込入力マスタ';
comment on column tm_kktorinyuryoku.torinyuryokuno is '一括取込入力No';
comment on column tm_kktorinyuryoku.torinyuryokunm is '一括取込入力名';
comment on column tm_kktorinyuryoku.torinyuryokbn is '一括取込入力区分';
comment on column tm_kktorinyuryoku.gyomukbn is '業務区分';
comment on column tm_kktorinyuryoku.nendohyojiflg is '年度表示フラグ';
comment on column tm_kktorinyuryoku.nendohanikbn is '年度範囲区分';
comment on column tm_kktorinyuryoku.torokukbn is '登録区分';
comment on column tm_kktorinyuryoku.comment is '説明';
comment on column tm_kktorinyuryoku.proccheck is 'チェックプロシージャ名';
comment on column tm_kktorinyuryoku.procbefore is '更新前プロシージャ名';
comment on column tm_kktorinyuryoku.procafter is '更新後プロシージャ名';
comment on column tm_kktorinyuryoku.orderseq is '並び順シーケンス';
comment on column tm_kktorinyuryoku.reguserid is '登録ユーザーID';
comment on column tm_kktorinyuryoku.regdttm is '登録日時';
comment on column tm_kktorinyuryoku.upduserid is '更新ユーザーID';
comment on column tm_kktorinyuryoku.upddttm is '更新日時';

--取込基本情報マスタ
drop table if exists tm_kktori_kihon;
create table tm_kktori_kihon(
    torinyuryokuno varchar(4) not null,
    filekeisiki varchar(1) not null,
    fileencode varchar(1) not null,
    filenm varchar(50),
    seikihyogen boolean not null default false,
    datakeisiki varchar(1) not null,
    recordlen integer,
    inyofusonzaikbn varchar(1),
    kugirikigo varchar(1),
    headerrows integer not null default 0,
    footerrows integer not null default 0,
primary key(torinyuryokuno)
);
comment on table tm_kktori_kihon is '取込基本情報マスタ';
comment on column tm_kktori_kihon.torinyuryokuno is '一括取込入力No';
comment on column tm_kktori_kihon.filekeisiki is 'ファイル形式';
comment on column tm_kktori_kihon.fileencode is 'ファイルエンコード';
comment on column tm_kktori_kihon.filenm is 'ファイル名称';
comment on column tm_kktori_kihon.seikihyogen is '正規表現';
comment on column tm_kktori_kihon.datakeisiki is 'データ形式';
comment on column tm_kktori_kihon.recordlen is 'レコード長';
comment on column tm_kktori_kihon.inyofusonzaikbn is '引用符存在区分';
comment on column tm_kktori_kihon.kugirikigo is '区切り記号';
comment on column tm_kktori_kihon.headerrows is 'ヘッダー行数';
comment on column tm_kktori_kihon.footerrows is 'フッター行数';

--一括取込入力対象テーブルマスタ
drop table if exists tm_kktorinyuryoku_taisyotable;
create table tm_kktorinyuryoku_taisyotable(
    torinyuryokuno varchar(4) not null,
    tablenm varchar(100) not null,
primary key(torinyuryokuno,tablenm)
);
comment on table tm_kktorinyuryoku_taisyotable is '一括取込入力対象テーブルマスタ';
comment on column tm_kktorinyuryoku_taisyotable.torinyuryokuno is '一括取込入力No';
comment on column tm_kktorinyuryoku_taisyotable.tablenm is 'テーブル物理名';

--取込IFマスタ
drop table if exists tm_kktori_interface;
create table tm_kktori_interface(
    torinyuryokuno varchar(4) not null,
    fileitemseq integer not null,
    itemnm varchar(100) not null,
    keyflg boolean not null default false,
    hissuflg boolean not null default false,
    datatype varchar(2) not null,
    ketasu integer not null,
    syosuketasu integer,
    format varchar(20),
    formatcheck varchar(20),
    formathenkan varchar(20),
    biko varchar(30),
primary key(torinyuryokuno,fileitemseq)
);
comment on table tm_kktori_interface is '取込IFマスタ';
comment on column tm_kktori_interface.torinyuryokuno is '一括取込入力No';
comment on column tm_kktori_interface.fileitemseq is 'ファイル項目ID';
comment on column tm_kktori_interface.itemnm is '項目名';
comment on column tm_kktori_interface.keyflg is 'キーフラグ';
comment on column tm_kktori_interface.hissuflg is '必須フラグ';
comment on column tm_kktori_interface.datatype is 'データ型';
comment on column tm_kktori_interface.ketasu is '桁数';
comment on column tm_kktori_interface.syosuketasu is '桁数（小数部）';
comment on column tm_kktori_interface.format is 'フォーマット';
comment on column tm_kktori_interface.formatcheck is 'フォーマットチェック';
comment on column tm_kktori_interface.formathenkan is 'フォーマット変換';
comment on column tm_kktori_interface.biko is '備考';

--一括取込入力項目定義マスタ
drop table if exists tm_kktorinyuryoku_item;
create table tm_kktorinyuryoku_item(
    torinyuryokuno varchar(4) not null,
    gamenitemseq integer not null,
    itemnm varchar(100) not null,
    wktablecolnm varchar(100) not null,
    inputkbn varchar(2) not null,
    inputhoho varchar(30) not null,
    hikisu varchar(200),
    ketasu integer not null,
    syosuketasu integer,
    width integer not null,
    format varchar(1),
    hissuflg varchar(1) not null,
    itiiflg boolean not null default false,
    hyojiinputkbn varchar(1) not null default 0,
    orderseq smallint,
    sansyomotoseq integer,
    sansyomotofield varchar(30),
    syutokusakifield varchar(30),
    nendoflg boolean,
    nendocheck varchar(1),
    seikihyogen varchar(100),
    minvalue varchar(20),
    maxvalue varchar(20),
    syokiti varchar(100),
    koteiti varchar(100),
    masterchecktable varchar(30),
    mastercheckjoken varchar(50),
    mastercheckitem varchar(30),
    jokenhissuerrorkbn varchar(1),
    jokenhissuitemseq integer,
    jokenhissuenzansi varchar(2),
    jokenhissuvalue varchar(50),
    jigyocd varchar(20),
    itemtokuteikbn varchar(2),
primary key(torinyuryokuno,gamenitemseq)
);
comment on table tm_kktorinyuryoku_item is '一括取込入力項目定義マスタ';
comment on column tm_kktorinyuryoku_item.torinyuryokuno is '一括取込入力No';
comment on column tm_kktorinyuryoku_item.gamenitemseq is '画面項目シーケンス';
comment on column tm_kktorinyuryoku_item.itemnm is '項目名';
comment on column tm_kktorinyuryoku_item.wktablecolnm is 'ワークテーブルカラム名';
comment on column tm_kktorinyuryoku_item.inputkbn is '入力区分';
comment on column tm_kktorinyuryoku_item.inputhoho is '入力方法';
comment on column tm_kktorinyuryoku_item.hikisu is '引数';
comment on column tm_kktorinyuryoku_item.ketasu is '桁数';
comment on column tm_kktorinyuryoku_item.syosuketasu is '桁数（小数部）';
comment on column tm_kktorinyuryoku_item.width is '幅';
comment on column tm_kktorinyuryoku_item.format is 'フォーマット';
comment on column tm_kktorinyuryoku_item.hissuflg is '必須フラグ';
comment on column tm_kktorinyuryoku_item.itiiflg is '一意フラグ';
comment on column tm_kktorinyuryoku_item.hyojiinputkbn is '表示入力設定区分';
comment on column tm_kktorinyuryoku_item.orderseq is '並びシーケンス';
comment on column tm_kktorinyuryoku_item.sansyomotoseq is '参照元項目シーケンス';
comment on column tm_kktorinyuryoku_item.sansyomotofield is '参照元フィールド';
comment on column tm_kktorinyuryoku_item.syutokusakifield is '取得先フィールド';
comment on column tm_kktorinyuryoku_item.nendoflg is '年度フラグ';
comment on column tm_kktorinyuryoku_item.nendocheck is '年度チェック';
comment on column tm_kktorinyuryoku_item.seikihyogen is '正規表現';
comment on column tm_kktorinyuryoku_item.minvalue is '最小値';
comment on column tm_kktorinyuryoku_item.maxvalue is '最大値';
comment on column tm_kktorinyuryoku_item.syokiti is '初期値';
comment on column tm_kktorinyuryoku_item.koteiti is '固定値';
comment on column tm_kktorinyuryoku_item.masterchecktable is 'マスタチェックテーブル';
comment on column tm_kktorinyuryoku_item.mastercheckjoken is 'マスタチェック条件';
comment on column tm_kktorinyuryoku_item.mastercheckitem is 'マスタチェック項目';
comment on column tm_kktorinyuryoku_item.jokenhissuerrorkbn is '条件必須エラーレベル区分';
comment on column tm_kktorinyuryoku_item.jokenhissuitemseq is '条件必須項目シーケンス';
comment on column tm_kktorinyuryoku_item.jokenhissuenzansi is '条件必須演算子';
comment on column tm_kktorinyuryoku_item.jokenhissuvalue is '条件必須値';
comment on column tm_kktorinyuryoku_item.jigyocd is '医療機関・事業従事者（担当者）事業コード';
comment on column tm_kktorinyuryoku_item.itemtokuteikbn is '項目特定区分';

--一括取込入力変換コードメインマスタ
drop table if exists tm_kktorinyuryoku_henkancode_main;
create table tm_kktorinyuryoku_henkancode_main(
    torinyuryokuno varchar(4) not null,
    codehenkankbn integer not null,
    henkankbnnm varchar(30) not null,
    codekanritablenm varchar(30) not null,
    maincd varchar(30) not null,
    subcd varchar(30) not null,
    sonotajoken varchar(200),
primary key(torinyuryokuno,codehenkankbn)
);
comment on table tm_kktorinyuryoku_henkancode_main is '一括取込入力変換コードメインマスタ';
comment on column tm_kktorinyuryoku_henkancode_main.torinyuryokuno is '一括取込入力No';
comment on column tm_kktorinyuryoku_henkancode_main.codehenkankbn is 'コード変換区分';
comment on column tm_kktorinyuryoku_henkancode_main.henkankbnnm is '変換区分名称';
comment on column tm_kktorinyuryoku_henkancode_main.codekanritablenm is 'コード管理テーブル名';
comment on column tm_kktorinyuryoku_henkancode_main.maincd is 'メインコード';
comment on column tm_kktorinyuryoku_henkancode_main.subcd is 'サブコード';
comment on column tm_kktorinyuryoku_henkancode_main.sonotajoken is 'その他条件';

--取込変換コードマスタ
drop table if exists tm_kktori_henkancode;
create table tm_kktori_henkancode(
    torinyuryokuno varchar(4) not null,
    codehenkankbn integer not null,
    motocd varchar(30) not null,
    motocdcomment varchar(200),
    henkangocd varchar(30) not null,
    henkangocdcomment varchar(200),
primary key(torinyuryokuno,codehenkankbn,motocd)
);
comment on table tm_kktori_henkancode is '取込変換コードマスタ';
comment on column tm_kktori_henkancode.torinyuryokuno is '一括取込入力No';
comment on column tm_kktori_henkancode.codehenkankbn is 'コード変換区分';
comment on column tm_kktori_henkancode.motocd is '元コード';
comment on column tm_kktori_henkancode.motocdcomment is '元コード説明';
comment on column tm_kktori_henkancode.henkangocd is '変換後コード';
comment on column tm_kktori_henkancode.henkangocdcomment is '変換後コード説明';

--取込項目マッピングマスタ
drop table if exists tm_kktori_mapping;
create table tm_kktori_mapping(
    torinyuryokuno varchar(4) not null,
    gamenitemseq integer not null,
    fileitemseq varchar(100),
    mappingkbn varchar(1) not null,
    mappinghoho varchar(30),
    siteiketasufrom integer,
    siteiketasuto integer,
primary key(torinyuryokuno,gamenitemseq)
);
comment on table tm_kktori_mapping is '取込項目マッピングマスタ';
comment on column tm_kktori_mapping.torinyuryokuno is '一括取込入力No';
comment on column tm_kktori_mapping.gamenitemseq is '画面項目シーケンス';
comment on column tm_kktori_mapping.fileitemseq is 'ファイル項目ID';
comment on column tm_kktori_mapping.mappingkbn is 'マッピング区分';
comment on column tm_kktori_mapping.mappinghoho is 'マッピング方法';
comment on column tm_kktori_mapping.siteiketasufrom is '指定桁数（開始）';
comment on column tm_kktori_mapping.siteiketasuto is '指定桁数（終了）';

--一括取込入力登録マスタ
drop table if exists tm_kktorinyuryoku_toroku;
create table tm_kktorinyuryoku_toroku(
    torinyuryokuno varchar(4) not null,
    tableid varchar(100) not null,
    recordno smallint not null,
    fieldnm varchar(100) not null,
    syorikbn varchar(2) not null,
    datamotoitemseq integer,
    koteiti varchar(100),
    datamototablenm varchar(100),
    datamotofieldnm varchar(100),
    saibankey varchar(200),
primary key(torinyuryokuno,tableid,recordno,fieldnm)
);
comment on table tm_kktorinyuryoku_toroku is '一括取込入力登録マスタ';
comment on column tm_kktorinyuryoku_toroku.torinyuryokuno is '一括取込入力No';
comment on column tm_kktorinyuryoku_toroku.tableid is 'テーブル物理名';
comment on column tm_kktorinyuryoku_toroku.recordno is 'レコードNo';
comment on column tm_kktorinyuryoku_toroku.fieldnm is 'フィールド物理名';
comment on column tm_kktorinyuryoku_toroku.syorikbn is '処理区分';
comment on column tm_kktorinyuryoku_toroku.datamotoitemseq is 'データ元画面項目シーケンス';
comment on column tm_kktorinyuryoku_toroku.koteiti is '固定値';
comment on column tm_kktorinyuryoku_toroku.datamototablenm is 'データ元テーブル';
comment on column tm_kktorinyuryoku_toroku.datamotofieldnm is 'データ元フィールド';
comment on column tm_kktorinyuryoku_toroku.saibankey is '採番キー';

--一括取込入力テーブルマスタ
drop table if exists tm_kktorinyuryoku_table;
create table tm_kktorinyuryoku_table(
    tablenm varchar(100) not null,
    tableronrinm varchar(50) not null,
    imptaisyoflg boolean not null default false,
    sansyoflg boolean not null default false,
    sonzaicheckflg boolean not null default false,
    orderseq smallint not null,
    oyatablenm varchar(100),
primary key(tablenm)
);
comment on table tm_kktorinyuryoku_table is '一括取込入力テーブルマスタ';
comment on column tm_kktorinyuryoku_table.tablenm is 'テーブル物理名';
comment on column tm_kktorinyuryoku_table.tableronrinm is 'テーブル論理名';
comment on column tm_kktorinyuryoku_table.imptaisyoflg is '取込対象フラグ';
comment on column tm_kktorinyuryoku_table.sansyoflg is '参照対象フラグ';
comment on column tm_kktorinyuryoku_table.sonzaicheckflg is '存在チェック対象フラグ';
comment on column tm_kktorinyuryoku_table.orderseq is '並びシーケンス';
comment on column tm_kktorinyuryoku_table.oyatablenm is '親テーブル';

--一括取込入力プロシージャマスタ
drop table if exists tm_kktorinyuryoku_proc;
create table tm_kktorinyuryoku_proc(
    procseq varchar(5) not null,
    procnm varchar(100) not null,
    prockbn varchar(1) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(procseq)
);
comment on table tm_kktorinyuryoku_proc is '一括取込入力プロシージャマスタ';
comment on column tm_kktorinyuryoku_proc.procseq is 'プロシージャNo';
comment on column tm_kktorinyuryoku_proc.procnm is 'プロシージャ名';
comment on column tm_kktorinyuryoku_proc.prockbn is 'プロシージャ区分';
comment on column tm_kktorinyuryoku_proc.reguserid is '登録ユーザーID';
comment on column tm_kktorinyuryoku_proc.regdttm is '登録日時';
comment on column tm_kktorinyuryoku_proc.upduserid is '更新ユーザーID';
comment on column tm_kktorinyuryoku_proc.upddttm is '更新日時';

--一括取込入力未処理テーブル
drop table if exists tt_kktorinyuryoku_misyori;
create table tt_kktorinyuryoku_misyori(
    impjikkoid integer not null,
    torinyuryokuno varchar(4) not null,
    filenm varchar(100),
    filedata bytea,
    filetype smallint,
    filegokeirow integer,
    totalcnt integer not null,
    errcnt integer not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(impjikkoid)
);
comment on table tt_kktorinyuryoku_misyori is '一括取込入力未処理テーブル';
comment on column tt_kktorinyuryoku_misyori.impjikkoid is '取込実行ID';
comment on column tt_kktorinyuryoku_misyori.torinyuryokuno is '一括取込入力No';
comment on column tt_kktorinyuryoku_misyori.filenm is 'ファイル名';
comment on column tt_kktorinyuryoku_misyori.filedata is 'ファイルデータ';
comment on column tt_kktorinyuryoku_misyori.filetype is 'ファイルタイプ';
comment on column tt_kktorinyuryoku_misyori.filegokeirow is 'ファイル合計行';
comment on column tt_kktorinyuryoku_misyori.totalcnt is '件数';
comment on column tt_kktorinyuryoku_misyori.errcnt is 'エラー件数';
comment on column tt_kktorinyuryoku_misyori.reguserid is '登録ユーザーID';
comment on column tt_kktorinyuryoku_misyori.regdttm is '登録日時';
comment on column tt_kktorinyuryoku_misyori.upduserid is '更新ユーザーID';
comment on column tt_kktorinyuryoku_misyori.upddttm is '更新日時';

--一括取込入力未処理項目テーブル
drop table if exists tt_kktorinyuryoku_misyoriitem;
create table tt_kktorinyuryoku_misyoriitem(
    impjikkoid integer not null,
    dataseq integer not null,
    rowno integer not null,
    colno integer not null,
    itemseq integer not null,
    itemnm varchar(30) not null,
    itemvalue varchar(100),
primary key(impjikkoid,dataseq)
);
comment on table tt_kktorinyuryoku_misyoriitem is '一括取込入力未処理項目テーブル';
comment on column tt_kktorinyuryoku_misyoriitem.impjikkoid is '取込実行ID';
comment on column tt_kktorinyuryoku_misyoriitem.dataseq is 'データシーケンス';
comment on column tt_kktorinyuryoku_misyoriitem.rowno is '行番号';
comment on column tt_kktorinyuryoku_misyoriitem.colno is '列番号';
comment on column tt_kktorinyuryoku_misyoriitem.itemseq is '項目シーケンス';
comment on column tt_kktorinyuryoku_misyoriitem.itemnm is '項目名';
comment on column tt_kktorinyuryoku_misyoriitem.itemvalue is '項目値';

--一括取込入力エラーテーブル
drop table if exists tt_kktorinyuryoku_err;
create table tt_kktorinyuryoku_err(
    impjikkoid integer not null,
    errseq integer not null,
    dataseq integer,
    rowno integer not null,
    atenano varchar(15),
    simei varchar(50),
    itemnm varchar(30),
    itemvalue varchar(100),
    msg varchar(200) not null,
    errkbn varchar(1) not null,
primary key(impjikkoid,errseq)
);
comment on table tt_kktorinyuryoku_err is '一括取込入力エラーテーブル';
comment on column tt_kktorinyuryoku_err.impjikkoid is '取込実行ID';
comment on column tt_kktorinyuryoku_err.errseq is 'エラーシーケンス';
comment on column tt_kktorinyuryoku_err.dataseq is 'データシーケンス';
comment on column tt_kktorinyuryoku_err.rowno is '行番号';
comment on column tt_kktorinyuryoku_err.atenano is '宛名番号';
comment on column tt_kktorinyuryoku_err.simei is '氏名';
comment on column tt_kktorinyuryoku_err.itemnm is '項目名';
comment on column tt_kktorinyuryoku_err.itemvalue is '項目値';
comment on column tt_kktorinyuryoku_err.msg is 'メッセージ';
comment on column tt_kktorinyuryoku_err.errkbn is 'エラー区分';

--一括取込入力履歴テーブル
drop table if exists tt_kktorinyuryoku_rireki;
create table tt_kktorinyuryoku_rireki(
    imprirekino integer not null,
    gyomukbn varchar(2) not null,
    torinyuryokunm varchar(50) not null,
    torinyuryokbn varchar(1) not null,
    filenm varchar(100),
    filetype smallint,
    filedata bytea,
    torokucnt integer not null,
    errcnt integer not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
primary key(imprirekino)
);
comment on table tt_kktorinyuryoku_rireki is '一括取込入力履歴テーブル';
comment on column tt_kktorinyuryoku_rireki.imprirekino is '取込履歴No';
comment on column tt_kktorinyuryoku_rireki.gyomukbn is '業務区分';
comment on column tt_kktorinyuryoku_rireki.torinyuryokunm is '一括取込入力名';
comment on column tt_kktorinyuryoku_rireki.torinyuryokbn is '一括取込入力区分';
comment on column tt_kktorinyuryoku_rireki.filenm is 'ファイル名';
comment on column tt_kktorinyuryoku_rireki.filetype is 'ファイルタイプ';
comment on column tt_kktorinyuryoku_rireki.filedata is 'ファイルデータ';
comment on column tt_kktorinyuryoku_rireki.torokucnt is '登録件数';
comment on column tt_kktorinyuryoku_rireki.errcnt is 'エラー件数';
comment on column tt_kktorinyuryoku_rireki.reguserid is '登録ユーザーID';
comment on column tt_kktorinyuryoku_rireki.regdttm is '登録日時';

--事業予定テーブル
drop table if exists tt_kkjigyoyotei;
create table tt_kkjigyoyotei(
    nitteino integer not null,
    jigyocd varchar(5) not null,
    courseno integer,
    kaisu integer,
    jissinaiyo varchar(100),
    jissiyoteiymd varchar(10) not null,
    tmf varchar(4) not null,
    tmt varchar(4),
    kaijocd varchar(7) not null,
    kikancd varchar(10),
    teiin smallint not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(nitteino)
);
comment on table tt_kkjigyoyotei is '事業予定テーブル';
comment on column tt_kkjigyoyotei.nitteino is '日程番号';
comment on column tt_kkjigyoyotei.jigyocd is 'その他日程事業・保健指導事業コード';
comment on column tt_kkjigyoyotei.courseno is 'コース番号';
comment on column tt_kkjigyoyotei.kaisu is '回数';
comment on column tt_kkjigyoyotei.jissinaiyo is '実施内容';
comment on column tt_kkjigyoyotei.jissiyoteiymd is '実施予定日';
comment on column tt_kkjigyoyotei.tmf is '開始時間';
comment on column tt_kkjigyoyotei.tmt is '終了時間';
comment on column tt_kkjigyoyotei.kaijocd is '会場コード';
comment on column tt_kkjigyoyotei.kikancd is '医療機関コード';
comment on column tt_kkjigyoyotei.teiin is '定員';
comment on column tt_kkjigyoyotei.regsisyo is '登録支所';
comment on column tt_kkjigyoyotei.reguserid is '登録ユーザーID';
comment on column tt_kkjigyoyotei.regdttm is '登録日時';
comment on column tt_kkjigyoyotei.upduserid is '更新ユーザーID';
comment on column tt_kkjigyoyotei.upddttm is '更新日時';

--事業予定コーステーブル
drop table if exists tt_kkjigyoyoteicourse;
create table tt_kkjigyoyoteicourse(
    courseno integer not null,
    coursenm varchar(50) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(courseno)
);
comment on table tt_kkjigyoyoteicourse is '事業予定コーステーブル';
comment on column tt_kkjigyoyoteicourse.courseno is 'コース番号';
comment on column tt_kkjigyoyoteicourse.coursenm is 'コース名';
comment on column tt_kkjigyoyoteicourse.regsisyo is '登録支所';
comment on column tt_kkjigyoyoteicourse.reguserid is '登録ユーザーID';
comment on column tt_kkjigyoyoteicourse.regdttm is '登録日時';
comment on column tt_kkjigyoyoteicourse.upduserid is '更新ユーザーID';
comment on column tt_kkjigyoyoteicourse.upddttm is '更新日時';

--事業予定担当者テーブル
drop table if exists tt_kkjigyoyotei_staff;
create table tt_kkjigyoyotei_staff(
    nitteino integer not null,
    staffid varchar(10) not null,
primary key(nitteino,staffid)
);
comment on table tt_kkjigyoyotei_staff is '事業予定担当者テーブル';
comment on column tt_kkjigyoyotei_staff.nitteino is '日程番号';
comment on column tt_kkjigyoyotei_staff.staffid is '担当者';

--事業予約希望者テーブル
drop table if exists tt_kkjigyoyoyakukibosya;
create table tt_kkjigyoyoyakukibosya(
    nitteino integer not null,
    atenano varchar(15) not null,
    yoyakuno integer not null,
    cancelmatiflg varchar(1) not null,
    jusinkingaku integer,
    kingaku_sityosonhutan integer,
    syokaiuketukeymd varchar(10),
    biko varchar(300),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(nitteino,atenano)
);
comment on table tt_kkjigyoyoyakukibosya is '事業予約希望者テーブル';
comment on column tt_kkjigyoyoyakukibosya.nitteino is '日程番号';
comment on column tt_kkjigyoyoyakukibosya.atenano is '宛名番号';
comment on column tt_kkjigyoyoyakukibosya.yoyakuno is '予約番号';
comment on column tt_kkjigyoyoyakukibosya.cancelmatiflg is 'キャンセル待ち';
comment on column tt_kkjigyoyoyakukibosya.jusinkingaku is '受診金額';
comment on column tt_kkjigyoyoyakukibosya.kingaku_sityosonhutan is '金額（市区町村負担）';
comment on column tt_kkjigyoyoyakukibosya.syokaiuketukeymd is '初回受付日';
comment on column tt_kkjigyoyoyakukibosya.biko is '備考';
comment on column tt_kkjigyoyoyakukibosya.reguserid is '登録ユーザーID';
comment on column tt_kkjigyoyoyakukibosya.regdttm is '登録日時';
comment on column tt_kkjigyoyoyakukibosya.upduserid is '更新ユーザーID';
comment on column tt_kkjigyoyoyakukibosya.upddttm is '更新日時';

--抽出情報マスタ
drop table if exists tm_kktyusyutu;
create table tm_kktyusyutu(
    tyusyututaisyocd varchar(5) not null,
    tyusyututaisyonm varchar(200) not null,
    rptid varchar(4) not null,
    tyusyutudatasyosaikbn varchar(50),
    syosaikbnmaincd varchar(4) not null,
    syosaikbnsubcd integer not null,
    tuticycle varchar(1) not null,
    saityusyutujogaiflg boolean not null,
    sinkidatatenyuryokuflg boolean not null,
    hakkeninfoflg boolean not null,
    tyusyutukinoid varchar(10),
    storedfunction varchar(100) not null,
    orderseq smallint not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(tyusyututaisyocd)
);
comment on table tm_kktyusyutu is '抽出情報マスタ';
comment on column tm_kktyusyutu.tyusyututaisyocd is '抽出対象コード';
comment on column tm_kktyusyutu.tyusyututaisyonm is '抽出対象名';
comment on column tm_kktyusyutu.rptid is '帳票ID';
comment on column tm_kktyusyutu.tyusyutudatasyosaikbn is '抽出データ詳細区分';
comment on column tm_kktyusyutu.syosaikbnmaincd is '詳細区分メインコード';
comment on column tm_kktyusyutu.syosaikbnsubcd is '詳細区分サブコード';
comment on column tm_kktyusyutu.tuticycle is '通知サイクル';
comment on column tm_kktyusyutu.saityusyutujogaiflg is '再抽出除外フラグ';
comment on column tm_kktyusyutu.sinkidatatenyuryokuflg is '新規入力フラグ';
comment on column tm_kktyusyutu.hakkeninfoflg is '発券情報管理フラグ';
comment on column tm_kktyusyutu.tyusyutukinoid is '抽出画面機能ID';
comment on column tm_kktyusyutu.storedfunction is 'ストアドファンクション';
comment on column tm_kktyusyutu.orderseq is '並びシーケンス';
comment on column tm_kktyusyutu.reguserid is '登録ユーザーID';
comment on column tm_kktyusyutu.regdttm is '登録日時';
comment on column tm_kktyusyutu.upduserid is '更新ユーザーID';
comment on column tm_kktyusyutu.upddttm is '更新日時';

--対象者抽出情報テーブル
drop table if exists tt_kktaisyosya_tyusyutu;
create table tt_kktaisyosya_tyusyutu(
    tyusyutuseq bigint not null,
    nendo smallint not null,
    tyusyututaisyocd varchar(5) not null,
    zentaikobetukbn varchar(1),
    tyusyutunaiyo varchar(200) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(tyusyutuseq)
);
comment on table tt_kktaisyosya_tyusyutu is '対象者抽出情報テーブル';
comment on column tt_kktaisyosya_tyusyutu.tyusyutuseq is '抽出シーケンス';
comment on column tt_kktaisyosya_tyusyutu.nendo is '年度';
comment on column tt_kktaisyosya_tyusyutu.tyusyututaisyocd is '抽出対象コード';
comment on column tt_kktaisyosya_tyusyutu.zentaikobetukbn is '全体個別区分';
comment on column tt_kktaisyosya_tyusyutu.tyusyutunaiyo is '抽出内容';
comment on column tt_kktaisyosya_tyusyutu.regsisyo is '登録支所';
comment on column tt_kktaisyosya_tyusyutu.reguserid is '登録ユーザーID';
comment on column tt_kktaisyosya_tyusyutu.regdttm is '登録日時';
comment on column tt_kktaisyosya_tyusyutu.upduserid is '更新ユーザーID';
comment on column tt_kktaisyosya_tyusyutu.upddttm is '更新日時';

--対象者抽出情報項目テーブル
drop table if exists tt_kktaisyosya_tyusyutufree;
create table tt_kktaisyosya_tyusyutufree(
    tyusyutuseq bigint not null,
    itemcd varchar(12) not null,
    fusyoflg boolean,
    numvalue double precision,
    strvalue varchar(1000),
primary key(tyusyutuseq,itemcd)
);
comment on table tt_kktaisyosya_tyusyutufree is '対象者抽出情報項目テーブル';
comment on column tt_kktaisyosya_tyusyutufree.tyusyutuseq is '抽出シーケンス';
comment on column tt_kktaisyosya_tyusyutufree.itemcd is '項目コード';
comment on column tt_kktaisyosya_tyusyutufree.fusyoflg is '不詳フラグ';
comment on column tt_kktaisyosya_tyusyutufree.numvalue is '数値項目';
comment on column tt_kktaisyosya_tyusyutufree.strvalue is '文字項目';

--対象者抽出情報サブテーブル
drop table if exists tt_kktaisyosya_tyusyutu_sub;
create table tt_kktaisyosya_tyusyutu_sub(
    tyusyutuseq bigint not null,
    atenano varchar(15) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(tyusyutuseq,atenano)
);
comment on table tt_kktaisyosya_tyusyutu_sub is '対象者抽出情報サブテーブル';
comment on column tt_kktaisyosya_tyusyutu_sub.tyusyutuseq is '抽出シーケンス';
comment on column tt_kktaisyosya_tyusyutu_sub.atenano is '宛名番号';
comment on column tt_kktaisyosya_tyusyutu_sub.reguserid is '登録ユーザーID';
comment on column tt_kktaisyosya_tyusyutu_sub.regdttm is '登録日時';
comment on column tt_kktaisyosya_tyusyutu_sub.upduserid is '更新ユーザーID';
comment on column tt_kktaisyosya_tyusyutu_sub.upddttm is '更新日時';

--対象者抽出情報サブ項目テーブル
drop table if exists tt_kktaisyosya_tyusyutu_subfree;
create table tt_kktaisyosya_tyusyutu_subfree(
    tyusyutuseq bigint not null,
    atenano varchar(15) not null,
    itemcd varchar(12) not null,
    fusyoflg boolean,
    numvalue double precision,
    strvalue varchar(1000),
primary key(tyusyutuseq,atenano,itemcd)
);
comment on table tt_kktaisyosya_tyusyutu_subfree is '対象者抽出情報サブ項目テーブル';
comment on column tt_kktaisyosya_tyusyutu_subfree.tyusyutuseq is '抽出シーケンス';
comment on column tt_kktaisyosya_tyusyutu_subfree.atenano is '宛名番号';
comment on column tt_kktaisyosya_tyusyutu_subfree.itemcd is '項目コード';
comment on column tt_kktaisyosya_tyusyutu_subfree.fusyoflg is '不詳フラグ';
comment on column tt_kktaisyosya_tyusyutu_subfree.numvalue is '数値項目';
comment on column tt_kktaisyosya_tyusyutu_subfree.strvalue is '文字項目';

--発券情報テーブル
drop table if exists tt_kkhakken;
create table tt_kkhakken(
    nendo smallint not null,
    tyusyututaisyocd varchar(5) not null,
    hakkendatasyosaikbn varchar(50) not null,
    atenano varchar(15) not null,
    hakkenno varchar(50) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(nendo,tyusyututaisyocd,hakkendatasyosaikbn,atenano)
);
comment on table tt_kkhakken is '発券情報テーブル';
comment on column tt_kkhakken.nendo is '年度';
comment on column tt_kkhakken.tyusyututaisyocd is '抽出対象コード';
comment on column tt_kkhakken.hakkendatasyosaikbn is '発券データ詳細区分';
comment on column tt_kkhakken.atenano is '宛名番号';
comment on column tt_kkhakken.hakkenno is '発券番号';
comment on column tt_kkhakken.reguserid is '登録ユーザーID';
comment on column tt_kkhakken.regdttm is '登録日時';
comment on column tt_kkhakken.upduserid is '更新ユーザーID';
comment on column tt_kkhakken.upddttm is '更新日時';

--対象者抽出情報項目コントロールマスタ
drop table if exists tm_kktaisyosya_tyusyutufreeitem;
create table tm_kktaisyosya_tyusyutufreeitem(
    tyusyututaisyocd varchar(5) not null,
    itemkanrikbn varchar(1) not null,
    itemcd varchar(12) not null,
    itemnm varchar(100) not null,
    tyusyutujyokenkbn varchar(1) not null,
    itemkbn varchar(1) not null,
    inputtype smallint not null,
    codejoken1 varchar(100),
    codejoken2 varchar(100),
    codejoken3 varchar(100),
    keta varchar(10),
    hissuflg boolean not null default false,
    hanif varchar(100),
    hanit varchar(100),
    inputflg boolean not null default true,
    msgkbn smallint not null,
    tani varchar(100),
    orderseq smallint not null,
    biko varchar(1000),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(tyusyututaisyocd,itemkanrikbn,itemcd)
);
comment on table tm_kktaisyosya_tyusyutufreeitem is '対象者抽出情報項目コントロールマスタ';
comment on column tm_kktaisyosya_tyusyutufreeitem.tyusyututaisyocd is '抽出対象コード';
comment on column tm_kktaisyosya_tyusyutufreeitem.itemkanrikbn is '項目管理区分';
comment on column tm_kktaisyosya_tyusyutufreeitem.itemcd is '項目コード';
comment on column tm_kktaisyosya_tyusyutufreeitem.itemnm is '項目名';
comment on column tm_kktaisyosya_tyusyutufreeitem.tyusyutujyokenkbn is '抽出条件区分';
comment on column tm_kktaisyosya_tyusyutufreeitem.itemkbn is '項目区分';
comment on column tm_kktaisyosya_tyusyutufreeitem.inputtype is '入力タイプ';
comment on column tm_kktaisyosya_tyusyutufreeitem.codejoken1 is 'コード条件1';
comment on column tm_kktaisyosya_tyusyutufreeitem.codejoken2 is 'コード条件2';
comment on column tm_kktaisyosya_tyusyutufreeitem.codejoken3 is 'コード条件3';
comment on column tm_kktaisyosya_tyusyutufreeitem.keta is '入力桁';
comment on column tm_kktaisyosya_tyusyutufreeitem.hissuflg is '必須フラグ';
comment on column tm_kktaisyosya_tyusyutufreeitem.hanif is '入力範囲（開始）';
comment on column tm_kktaisyosya_tyusyutufreeitem.hanit is '入力範囲（終了）';
comment on column tm_kktaisyosya_tyusyutufreeitem.inputflg is '入力フラグ';
comment on column tm_kktaisyosya_tyusyutufreeitem.msgkbn is 'メッセージ区分';
comment on column tm_kktaisyosya_tyusyutufreeitem.tani is '単位';
comment on column tm_kktaisyosya_tyusyutufreeitem.orderseq is '並びシーケンス';
comment on column tm_kktaisyosya_tyusyutufreeitem.biko is '備考';
comment on column tm_kktaisyosya_tyusyutufreeitem.reguserid is '登録ユーザーID';
comment on column tm_kktaisyosya_tyusyutufreeitem.regdttm is '登録日時';
comment on column tm_kktaisyosya_tyusyutufreeitem.upduserid is '更新ユーザーID';
comment on column tm_kktaisyosya_tyusyutufreeitem.upddttm is '更新日時';

--帳票発行履歴テーブル
drop table if exists tt_kkrpthakkorireki;
create table tt_kkrpthakkorireki(
    hakkoseq bigint not null,
    rptid varchar(4) not null,
    yosikiid varchar(4),
    outputkbn smallint,
    hakkodatasyosaikbn varchar(50),
    tyusyutuseq bigint,
    nendo smallint not null,
    hassoymd varchar(10) not null,
    hakkokbn varchar(1),
    hakkobasyo varchar(100),
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(hakkoseq)
);
comment on table tt_kkrpthakkorireki is '帳票発行履歴テーブル';
comment on column tt_kkrpthakkorireki.hakkoseq is '発行シーケンス';
comment on column tt_kkrpthakkorireki.rptid is '帳票ID';
comment on column tt_kkrpthakkorireki.yosikiid is '様式ID';
comment on column tt_kkrpthakkorireki.outputkbn is '出力方式';
comment on column tt_kkrpthakkorireki.hakkodatasyosaikbn is '発行データ詳細区分';
comment on column tt_kkrpthakkorireki.tyusyutuseq is '抽出シーケンス';
comment on column tt_kkrpthakkorireki.nendo is '年度';
comment on column tt_kkrpthakkorireki.hassoymd is '発送日';
comment on column tt_kkrpthakkorireki.hakkokbn is '発行区分';
comment on column tt_kkrpthakkorireki.hakkobasyo is '発行場所';
comment on column tt_kkrpthakkorireki.regsisyo is '登録支所';
comment on column tt_kkrpthakkorireki.reguserid is '登録ユーザーID';
comment on column tt_kkrpthakkorireki.regdttm is '登録日時';
comment on column tt_kkrpthakkorireki.upduserid is '更新ユーザーID';
comment on column tt_kkrpthakkorireki.upddttm is '更新日時';

--帳票発行履歴サブテーブル
drop table if exists tt_kkrpthakkorireki_sub;
create table tt_kkrpthakkorireki_sub(
    hakkoseq bigint not null,
    atenano varchar(15) not null,
    ninsanputorokuno bigint not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(hakkoseq,atenano,ninsanputorokuno)
);
comment on table tt_kkrpthakkorireki_sub is '帳票発行履歴サブテーブル';
comment on column tt_kkrpthakkorireki_sub.hakkoseq is '発行シーケンス';
comment on column tt_kkrpthakkorireki_sub.atenano is '宛名番号';
comment on column tt_kkrpthakkorireki_sub.ninsanputorokuno is '妊産婦登録番号';
comment on column tt_kkrpthakkorireki_sub.reguserid is '登録ユーザーID';
comment on column tt_kkrpthakkorireki_sub.regdttm is '登録日時';
comment on column tt_kkrpthakkorireki_sub.upduserid is '更新ユーザーID';
comment on column tt_kkrpthakkorireki_sub.upddttm is '更新日時';

--成人保健検診結果（フリー）項目コントロールマスタ
drop table if exists tm_shfreeitem;
create table tm_shfreeitem(
    jigyocd varchar(2) not null,
    itemcd varchar(12) not null,
    itemnm varchar(100) not null,
    itemkbn varchar(1) not null,
    groupid varchar(1) not null,
    groupid2 varchar(2),
    inputtype smallint not null,
    codejoken1 varchar(100),
    codejoken2 varchar(100),
    codejoken3 varchar(100),
    keta varchar(10),
    hissuflg boolean not null default false,
    hanif varchar(100),
    hanit varchar(100),
    rirekiflg boolean not null default false,
    hyojinendof smallint,
    hyojinendot smallint,
    inputflg boolean not null default true,
    msgkbn smallint not null,
    tani varchar(100),
    syokiti varchar(1000),
    keisankbn varchar(1),
    keisansusiki varchar(2000),
    keisankansuid varchar(20),
    keisanparam varchar,
    komokutokuteikbn varchar(2),
    riyokensahohocd varchar,
    haitiflg boolean not null default true,
    orderseq smallint not null,
    biko varchar(1000),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(jigyocd,itemcd)
);
comment on table tm_shfreeitem is '成人保健検診結果（フリー）項目コントロールマスタ';
comment on column tm_shfreeitem.jigyocd is '検診種別';
comment on column tm_shfreeitem.itemcd is '項目コード';
comment on column tm_shfreeitem.itemnm is '項目名';
comment on column tm_shfreeitem.itemkbn is '項目区分';
comment on column tm_shfreeitem.groupid is 'グループID';
comment on column tm_shfreeitem.groupid2 is 'グループID2';
comment on column tm_shfreeitem.inputtype is '入力タイプ';
comment on column tm_shfreeitem.codejoken1 is 'コード条件1';
comment on column tm_shfreeitem.codejoken2 is 'コード条件2';
comment on column tm_shfreeitem.codejoken3 is 'コード条件3';
comment on column tm_shfreeitem.keta is '入力桁';
comment on column tm_shfreeitem.hissuflg is '必須フラグ';
comment on column tm_shfreeitem.hanif is '入力範囲（開始）';
comment on column tm_shfreeitem.hanit is '入力範囲（終了）';
comment on column tm_shfreeitem.rirekiflg is '履歴管理フラグ';
comment on column tm_shfreeitem.hyojinendof is '表示年度（開始）';
comment on column tm_shfreeitem.hyojinendot is '表示年度（終了）';
comment on column tm_shfreeitem.inputflg is '入力フラグ';
comment on column tm_shfreeitem.msgkbn is 'メッセージ区分';
comment on column tm_shfreeitem.tani is '単位';
comment on column tm_shfreeitem.syokiti is '初期値';
comment on column tm_shfreeitem.keisankbn is '計算区分';
comment on column tm_shfreeitem.keisansusiki is '計算数式';
comment on column tm_shfreeitem.keisankansuid is '計算関数ID';
comment on column tm_shfreeitem.keisanparam is '計算パラメータ';
comment on column tm_shfreeitem.komokutokuteikbn is '項目特定区分';
comment on column tm_shfreeitem.riyokensahohocd is '利用検査方法コード';
comment on column tm_shfreeitem.haitiflg is '画面配置フラグ';
comment on column tm_shfreeitem.orderseq is '並びシーケンス';
comment on column tm_shfreeitem.biko is '備考';
comment on column tm_shfreeitem.reguserid is '登録ユーザーID';
comment on column tm_shfreeitem.regdttm is '登録日時';
comment on column tm_shfreeitem.upduserid is '更新ユーザーID';
comment on column tm_shfreeitem.upddttm is '更新日時';

--成人健（検）診事業マスタ
drop table if exists tm_shkensinjigyo;
create table tm_shkensinjigyo(
    jigyocd varchar(2) not null,
    kihonkakutyokbn varchar(1) not null,
    seikenjissikbn varchar(1) not null default 0,
    genmenkbn varchar(1) not null default 2,
    cuponhyojikbn varchar(1) not null default 0,
    syogaiikaiflg boolean not null default false,
    kensahoho_setflg boolean not null default false,
    kensahoho_maincd varchar(4),
    kensahoho_subcd integer,
    yoyakubunrui_maincd varchar(4),
    yoyakubunrui_subcd integer,
    groupid2_maincd varchar(4),
    groupid2_subcd integer,
    yoyakuchk varchar(1) not null,
    kensinchk varchar(1) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(jigyocd)
);
comment on table tm_shkensinjigyo is '成人健（検）診事業マスタ';
comment on column tm_shkensinjigyo.jigyocd is '検診種別';
comment on column tm_shkensinjigyo.kihonkakutyokbn is '基本／拡張事業区分';
comment on column tm_shkensinjigyo.seikenjissikbn is '精密検査実施区分';
comment on column tm_shkensinjigyo.genmenkbn is '減免区分';
comment on column tm_shkensinjigyo.cuponhyojikbn is 'クーポン券表示区分';
comment on column tm_shkensinjigyo.syogaiikaiflg is '生涯１回フラグ';
comment on column tm_shkensinjigyo.kensahoho_setflg is '検査方法設定フラグ';
comment on column tm_shkensinjigyo.kensahoho_maincd is '検査方法メインコード';
comment on column tm_shkensinjigyo.kensahoho_subcd is '検査方法サブコード';
comment on column tm_shkensinjigyo.yoyakubunrui_maincd is '予約分類メインコード';
comment on column tm_shkensinjigyo.yoyakubunrui_subcd is '予約分類サブコード';
comment on column tm_shkensinjigyo.groupid2_maincd is 'フリー項目グループ右設定メインコード';
comment on column tm_shkensinjigyo.groupid2_subcd is 'フリー項目グループ右設定サブコード';
comment on column tm_shkensinjigyo.yoyakuchk is '予約画面チェック区分';
comment on column tm_shkensinjigyo.kensinchk is '健（検）診画面チェック区分';
comment on column tm_shkensinjigyo.reguserid is '登録ユーザーID';
comment on column tm_shkensinjigyo.regdttm is '登録日時';
comment on column tm_shkensinjigyo.upduserid is '更新ユーザーID';
comment on column tm_shkensinjigyo.upddttm is '更新日時';

--年度マスタ
drop table if exists tm_shnendo;
create table tm_shnendo(
    nendo smallint not null,
    jigyocd varchar(2) not null,
    kensahohocd varchar(2) not null,
    sex varchar(1),
    age varchar(50) not null,
    kijunkbn varchar(1) not null,
    kijunymd varchar(10),
    hokenkbn varchar(2),
    tokusyu varchar(100),
    sql varchar(2000),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(nendo,jigyocd,kensahohocd)
);
comment on table tm_shnendo is '年度マスタ';
comment on column tm_shnendo.nendo is '年度';
comment on column tm_shnendo.jigyocd is '検診種別';
comment on column tm_shnendo.kensahohocd is '検査方法コード';
comment on column tm_shnendo.sex is '性別';
comment on column tm_shnendo.age is '年齢';
comment on column tm_shnendo.kijunkbn is '年齢基準日区分';
comment on column tm_shnendo.kijunymd is '年齢計算基準日';
comment on column tm_shnendo.hokenkbn is '保険区分';
comment on column tm_shnendo.tokusyu is '特殊';
comment on column tm_shnendo.sql is 'SQL文';
comment on column tm_shnendo.reguserid is '登録ユーザーID';
comment on column tm_shnendo.regdttm is '登録日時';
comment on column tm_shnendo.upduserid is '更新ユーザーID';
comment on column tm_shnendo.upddttm is '更新日時';

--成人保健検診結果（フリー項目）テーブル
drop table if exists tt_shfree;
create table tt_shfree(
    jigyocd varchar(2) not null,
    atenano varchar(15) not null,
    nendo smallint not null,
    kensinkaisu smallint not null,
    itemcd varchar(12) not null,
    kensinkbn varchar(1) not null,
    fusyoflg boolean,
    numvalue double precision,
    strvalue varchar(1000),
primary key(jigyocd,atenano,nendo,kensinkaisu,itemcd)
);
comment on table tt_shfree is '成人保健検診結果（フリー項目）テーブル';
comment on column tt_shfree.jigyocd is '検診種別';
comment on column tt_shfree.atenano is '宛名番号';
comment on column tt_shfree.nendo is '実施年度';
comment on column tt_shfree.kensinkaisu is '検診回数';
comment on column tt_shfree.itemcd is '項目コード';
comment on column tt_shfree.kensinkbn is '区分';
comment on column tt_shfree.fusyoflg is '不詳フラグ';
comment on column tt_shfree.numvalue is '数値項目';
comment on column tt_shfree.strvalue is '文字項目';

--受診拒否理由テーブル
drop table if exists tt_shjyusinkyohiriyu;
create table tt_shjyusinkyohiriyu(
    nendo smallint not null,
    atenano varchar(15) not null,
    jigyocd varchar(2) not null,
    kyohiriyu varchar(2) not null,
primary key(nendo,atenano,jigyocd)
);
comment on table tt_shjyusinkyohiriyu is '受診拒否理由テーブル';
comment on column tt_shjyusinkyohiriyu.nendo is '年度';
comment on column tt_shjyusinkyohiriyu.atenano is '宛名番号';
comment on column tt_shjyusinkyohiriyu.jigyocd is '検診種別';
comment on column tt_shjyusinkyohiriyu.kyohiriyu is '受診拒否理由';

--成人保健一次検診結果（固定項目）テーブル
drop table if exists tt_shkensin;
create table tt_shkensin(
    jigyocd varchar(2) not null,
    atenano varchar(15) not null,
    nendo smallint not null,
    kensinkaisu smallint not null,
    jissiymd varchar(10) not null,
    jissiage smallint,
    kensahohocd varchar(2),
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(jigyocd,atenano,nendo,kensinkaisu)
);
comment on table tt_shkensin is '成人保健一次検診結果（固定項目）テーブル';
comment on column tt_shkensin.jigyocd is '検診種別';
comment on column tt_shkensin.atenano is '宛名番号';
comment on column tt_shkensin.nendo is '実施年度';
comment on column tt_shkensin.kensinkaisu is '検診回数';
comment on column tt_shkensin.jissiymd is '実施日';
comment on column tt_shkensin.jissiage is '実施年齢';
comment on column tt_shkensin.kensahohocd is '検査方法';
comment on column tt_shkensin.regsisyo is '登録支所';
comment on column tt_shkensin.reguserid is '登録ユーザーID';
comment on column tt_shkensin.regdttm is '登録日時';
comment on column tt_shkensin.upduserid is '更新ユーザーID';
comment on column tt_shkensin.upddttm is '更新日時';

--成人保健精密検査結果（固定項目）テーブル
drop table if exists tt_shseiken;
create table tt_shseiken(
    jigyocd varchar(2) not null,
    atenano varchar(15) not null,
    nendo smallint not null,
    kensinkaisu smallint not null,
    jissiymd varchar(10),
    jissiage smallint,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(jigyocd,atenano,nendo,kensinkaisu)
);
comment on table tt_shseiken is '成人保健精密検査結果（固定項目）テーブル';
comment on column tt_shseiken.jigyocd is '検診種別';
comment on column tt_shseiken.atenano is '宛名番号';
comment on column tt_shseiken.nendo is '実施年度';
comment on column tt_shseiken.kensinkaisu is '検診回数';
comment on column tt_shseiken.jissiymd is '実施日';
comment on column tt_shseiken.jissiage is '実施年齢';
comment on column tt_shseiken.regsisyo is '登録支所';
comment on column tt_shseiken.reguserid is '登録ユーザーID';
comment on column tt_shseiken.regdttm is '登録日時';
comment on column tt_shseiken.upduserid is '更新ユーザーID';
comment on column tt_shseiken.upddttm is '更新日時';

--健（検）診予定テーブル
drop table if exists tt_shkensinyotei;
create table tt_shkensinyotei(
    nendo smallint not null,
    nitteino integer not null,
    jigyocd varchar(5) not null,
    yoteiymd varchar(10) not null,
    tmf varchar(4) not null,
    tmt varchar(4),
    kaijocd varchar(7) not null,
    kikancd varchar(10),
    teiin smallint not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(nendo,nitteino)
);
comment on table tt_shkensinyotei is '健（検）診予定テーブル';
comment on column tt_shkensinyotei.nendo is '年度';
comment on column tt_shkensinyotei.nitteino is '日程番号';
comment on column tt_shkensinyotei.jigyocd is '成人健（検）診予約日程事業コード';
comment on column tt_shkensinyotei.yoteiymd is '実施予定日';
comment on column tt_shkensinyotei.tmf is '開始時間';
comment on column tt_shkensinyotei.tmt is '終了時間';
comment on column tt_shkensinyotei.kaijocd is '会場コード';
comment on column tt_shkensinyotei.kikancd is '医療機関コード';
comment on column tt_shkensinyotei.teiin is '定員';
comment on column tt_shkensinyotei.regsisyo is '登録支所';
comment on column tt_shkensinyotei.reguserid is '登録ユーザーID';
comment on column tt_shkensinyotei.regdttm is '登録日時';
comment on column tt_shkensinyotei.upduserid is '更新ユーザーID';
comment on column tt_shkensinyotei.upddttm is '更新日時';

--健（検）診予定詳細テーブル
drop table if exists tt_shkensinyoteisyosai;
create table tt_shkensinyoteisyosai(
    nendo smallint not null,
    nitteino integer not null,
    jigyocd varchar(2) not null,
    yoyakubunruicd varchar(2) not null,
    teiin_kensin smallint not null,
primary key(nendo,nitteino,jigyocd,yoyakubunruicd)
);
comment on table tt_shkensinyoteisyosai is '健（検）診予定詳細テーブル';
comment on column tt_shkensinyoteisyosai.nendo is '年度';
comment on column tt_shkensinyoteisyosai.nitteino is '日程番号';
comment on column tt_shkensinyoteisyosai.jigyocd is '検診種別';
comment on column tt_shkensinyoteisyosai.yoyakubunruicd is '予約分類コード';
comment on column tt_shkensinyoteisyosai.teiin_kensin is '定員(検診)';

--健（検）診予定担当者テーブル
drop table if exists tt_shkensinyotei_staff;
create table tt_shkensinyotei_staff(
    nendo smallint not null,
    nitteino integer not null,
    staffid varchar(10) not null,
primary key(nendo,nitteino,staffid)
);
comment on table tt_shkensinyotei_staff is '健（検）診予定担当者テーブル';
comment on column tt_shkensinyotei_staff.nendo is '年度';
comment on column tt_shkensinyotei_staff.nitteino is '日程番号';
comment on column tt_shkensinyotei_staff.staffid is '担当者';

--健（検）診予約希望者テーブル
drop table if exists tt_shkensinyoyakukibosya;
create table tt_shkensinyoyakukibosya(
    nendo smallint not null,
    nitteino integer not null,
    atenano varchar(15) not null,
    yoyakuno integer not null,
    biko varchar(300),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(nendo,nitteino,atenano)
);
comment on table tt_shkensinyoyakukibosya is '健（検）診予約希望者テーブル';
comment on column tt_shkensinyoyakukibosya.nendo is '年度';
comment on column tt_shkensinyoyakukibosya.nitteino is '日程番号';
comment on column tt_shkensinyoyakukibosya.atenano is '宛名番号';
comment on column tt_shkensinyoyakukibosya.yoyakuno is '予約番号';
comment on column tt_shkensinyoyakukibosya.biko is '備考';
comment on column tt_shkensinyoyakukibosya.reguserid is '登録ユーザーID';
comment on column tt_shkensinyoyakukibosya.regdttm is '登録日時';
comment on column tt_shkensinyoyakukibosya.upduserid is '更新ユーザーID';
comment on column tt_shkensinyoyakukibosya.upddttm is '更新日時';

--健（検）診予約希望者詳細テーブル
drop table if exists tt_shkensinkibosyasyosai;
create table tt_shkensinkibosyasyosai(
    nendo smallint not null,
    nitteino integer not null,
    atenano varchar(15) not null,
    jigyocd varchar(2) not null,
    kensahohocd varchar(2) not null,
    cancelmatiflg varchar(1) not null,
    syokaiuketukeymd varchar(10),
    henkouketukeymd varchar(10),
primary key(nendo,nitteino,atenano,jigyocd)
);
comment on table tt_shkensinkibosyasyosai is '健（検）診予約希望者詳細テーブル';
comment on column tt_shkensinkibosyasyosai.nendo is '年度';
comment on column tt_shkensinkibosyasyosai.nitteino is '日程番号';
comment on column tt_shkensinkibosyasyosai.atenano is '宛名番号';
comment on column tt_shkensinkibosyasyosai.jigyocd is '検診種別';
comment on column tt_shkensinkibosyasyosai.kensahohocd is '検査方法コード';
comment on column tt_shkensinkibosyasyosai.cancelmatiflg is 'キャンセル待ち';
comment on column tt_shkensinkibosyasyosai.syokaiuketukeymd is '初回受付日';
comment on column tt_shkensinkibosyasyosai.henkouketukeymd is '受付変更日';

--自己負担金マスタ
drop table if exists tm_shjikofutankin;
create table tm_shjikofutankin(
    nendo smallint not null,
    kensin_jigyocd varchar(2) not null,
    ryokinpattern varchar(2) not null,
    kensahohocd varchar(2) not null,
    sex varchar(50) not null,
    agehani varchar(100) not null,
    genmenkbn varchar(2) not null,
    jusinkingaku integer not null,
    kingaku_sityosonhutan integer,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(nendo,kensin_jigyocd,ryokinpattern,kensahohocd,sex,agehani,genmenkbn)
);
comment on table tm_shjikofutankin is '自己負担金マスタ';
comment on column tm_shjikofutankin.nendo is '年度';
comment on column tm_shjikofutankin.kensin_jigyocd is '検診種別';
comment on column tm_shjikofutankin.ryokinpattern is '料金パターン';
comment on column tm_shjikofutankin.kensahohocd is '検査方法コード';
comment on column tm_shjikofutankin.sex is '性別';
comment on column tm_shjikofutankin.agehani is '年齢範囲';
comment on column tm_shjikofutankin.genmenkbn is '減免区分';
comment on column tm_shjikofutankin.jusinkingaku is '受診金額';
comment on column tm_shjikofutankin.kingaku_sityosonhutan is '金額（市区町村負担）';
comment on column tm_shjikofutankin.reguserid is '登録ユーザーID';
comment on column tm_shjikofutankin.regdttm is '登録日時';
comment on column tm_shjikofutankin.upduserid is '更新ユーザーID';
comment on column tm_shjikofutankin.upddttm is '更新日時';

--成人健（検）診予約日程事業マスタ
drop table if exists tm_shyoyakujigyo;
create table tm_shyoyakujigyo(
    nendo smallint not null,
    jigyocd varchar(5) not null,
    ryokinpattern varchar(2) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(nendo,jigyocd)
);
comment on table tm_shyoyakujigyo is '成人健（検）診予約日程事業マスタ';
comment on column tm_shyoyakujigyo.nendo is '年度';
comment on column tm_shyoyakujigyo.jigyocd is '成人健（検）診予約日程事業コード';
comment on column tm_shyoyakujigyo.ryokinpattern is '料金パターン';
comment on column tm_shyoyakujigyo.reguserid is '登録ユーザーID';
comment on column tm_shyoyakujigyo.regdttm is '登録日時';
comment on column tm_shyoyakujigyo.upduserid is '更新ユーザーID';
comment on column tm_shyoyakujigyo.upddttm is '更新日時';

--成人健（検）診予約日程事業サブマスタ
drop table if exists tm_shyoyakujigyo_sub;
create table tm_shyoyakujigyo_sub(
    nendo smallint not null,
    jigyocd varchar(5) not null,
    kensin_jigyocd varchar(2) not null,
    kensahohocd varchar(2) not null,
    optionflg boolean not null default false,
primary key(nendo,jigyocd,kensin_jigyocd,kensahohocd)
);
comment on table tm_shyoyakujigyo_sub is '成人健（検）診予約日程事業サブマスタ';
comment on column tm_shyoyakujigyo_sub.nendo is '年度';
comment on column tm_shyoyakujigyo_sub.jigyocd is '成人健（検）診予約日程事業コード';
comment on column tm_shyoyakujigyo_sub.kensin_jigyocd is '検診種別';
comment on column tm_shyoyakujigyo_sub.kensahohocd is '成人健（検）診検査方法コード';
comment on column tm_shyoyakujigyo_sub.optionflg is 'オプションフラグ';

--母子保健詳細メニューマスタ
drop table if exists tm_bhkksyosaimenu;
create table tm_bhkksyosaimenu(
    bosikbn varchar(1) not null,
    bhsyosaimenyucd varchar(3) not null,
    bhsyosaimenyunm varchar(30) not null,
    bhsyosaimenyushortnm varchar(20) not null,
    orderseq smallint not null,
primary key(bosikbn,bhsyosaimenyucd)
);
comment on table tm_bhkksyosaimenu is '母子保健詳細メニューマスタ';
comment on column tm_bhkksyosaimenu.bosikbn is '母子区分';
comment on column tm_bhkksyosaimenu.bhsyosaimenyucd is '母子保健詳細メニューコード';
comment on column tm_bhkksyosaimenu.bhsyosaimenyunm is '母子保健詳細メニュー名称';
comment on column tm_bhkksyosaimenu.bhsyosaimenyushortnm is '母子保健詳細メニュー略称';
comment on column tm_bhkksyosaimenu.orderseq is '並びシーケンス';

--母子保健詳細タブマスタ
drop table if exists tm_bhkksyosaitab;
create table tm_bhkksyosaitab(
    bosikbn varchar(1) not null,
    bhsyosaimenyucd varchar(3) not null,
    bhsyosaitabcd varchar(3) not null,
    bhsyosaitabnm varchar(50) not null,
    jigyocd varchar(5) not null,
    orderseq smallint not null,
primary key(bosikbn,bhsyosaimenyucd,bhsyosaitabcd)
);
comment on table tm_bhkksyosaitab is '母子保健詳細タブマスタ';
comment on column tm_bhkksyosaitab.bosikbn is '母子区分';
comment on column tm_bhkksyosaitab.bhsyosaimenyucd is '母子保健詳細メニューコード';
comment on column tm_bhkksyosaitab.bhsyosaitabcd is '母子保健詳細タブコード';
comment on column tm_bhkksyosaitab.bhsyosaitabnm is '母子保健詳細タブ名称';
comment on column tm_bhkksyosaitab.jigyocd is '母子保健事業コード';
comment on column tm_bhkksyosaitab.orderseq is '並びシーケンス';

--母子保健事業マスタ
drop table if exists tm_bhkkjigyo;
create table tm_bhkkjigyo(
    bosikbn varchar(1) not null,
    jigyocd varchar(5) not null,
    kihonkakutyokbn varchar(1) not null,
    bhkanripatterncd varchar(3) not null,
    rirekiflg boolean not null,
    tataiflg boolean not null,
    kaisuflg boolean not null,
    nykensincd varchar(5) not null,
    groupid_maincd varchar(4),
    groupid_subcd integer,
    groupid2_maincd varchar(4),
    groupid2_subcd integer,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(bosikbn,jigyocd)
);
comment on table tm_bhkkjigyo is '母子保健事業マスタ';
comment on column tm_bhkkjigyo.bosikbn is '母子区分';
comment on column tm_bhkkjigyo.jigyocd is '母子保健事業コード';
comment on column tm_bhkkjigyo.kihonkakutyokbn is '基本／拡張事業区分';
comment on column tm_bhkkjigyo.bhkanripatterncd is '母子保健管理パターンコード';
comment on column tm_bhkkjigyo.rirekiflg is '履歴管理フラグ';
comment on column tm_bhkkjigyo.tataiflg is '多胎管理フラグ';
comment on column tm_bhkkjigyo.kaisuflg is '回数管理フラグ';
comment on column tm_bhkkjigyo.nykensincd is '乳幼児健診コード';
comment on column tm_bhkkjigyo.groupid_maincd is 'フリー項目グループ左設定メインコード';
comment on column tm_bhkkjigyo.groupid_subcd is 'フリー項目グループ左設定サブコード';
comment on column tm_bhkkjigyo.groupid2_maincd is 'フリー項目グループ右設定メインコード';
comment on column tm_bhkkjigyo.groupid2_subcd is 'フリー項目グループ右設定サブコード';
comment on column tm_bhkkjigyo.reguserid is '登録ユーザーID';
comment on column tm_bhkkjigyo.regdttm is '登録日時';
comment on column tm_bhkkjigyo.upduserid is '更新ユーザーID';
comment on column tm_bhkkjigyo.upddttm is '更新日時';

--母子保健（フリー）項目コントロールマスタ
drop table if exists tm_bhkkfreeitem;
create table tm_bhkkfreeitem(
    bosikbn varchar(1) not null,
    jigyocd varchar(5) not null,
    itemcd varchar(12) not null,
    itemnm varchar(100) not null,
    itemkbn varchar(1) not null,
    groupid varchar(2) not null,
    groupid2 varchar(2),
    inputtype smallint not null,
    codejoken1 varchar(100),
    codejoken2 varchar(100),
    codejoken3 varchar(100),
    keta varchar(10),
    hissuflg boolean not null default false,
    hanif varchar(100),
    hanit varchar(100),
    inputflg boolean not null default true,
    msgkbn smallint not null,
    tani varchar(100),
    syokiti varchar(1000),
    keisankbn varchar(1),
    keisansusiki varchar(2000),
    keisankansuid varchar(20),
    keisanparam varchar,
    komokutokuteikbn varchar(2) not null,
    orderseq smallint not null,
    biko varchar(1000),
    riyokaisu varchar(100) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(bosikbn,jigyocd,itemcd)
);
comment on table tm_bhkkfreeitem is '母子保健（フリー）項目コントロールマスタ';
comment on column tm_bhkkfreeitem.bosikbn is '母子区分';
comment on column tm_bhkkfreeitem.jigyocd is '母子保健事業コード';
comment on column tm_bhkkfreeitem.itemcd is '項目コード';
comment on column tm_bhkkfreeitem.itemnm is '項目名';
comment on column tm_bhkkfreeitem.itemkbn is '項目区分';
comment on column tm_bhkkfreeitem.groupid is 'グループID';
comment on column tm_bhkkfreeitem.groupid2 is 'グループID2';
comment on column tm_bhkkfreeitem.inputtype is '入力タイプ';
comment on column tm_bhkkfreeitem.codejoken1 is 'コード条件1';
comment on column tm_bhkkfreeitem.codejoken2 is 'コード条件2';
comment on column tm_bhkkfreeitem.codejoken3 is 'コード条件3';
comment on column tm_bhkkfreeitem.keta is '入力桁';
comment on column tm_bhkkfreeitem.hissuflg is '必須フラグ';
comment on column tm_bhkkfreeitem.hanif is '入力範囲（開始）';
comment on column tm_bhkkfreeitem.hanit is '入力範囲（終了）';
comment on column tm_bhkkfreeitem.inputflg is '入力フラグ';
comment on column tm_bhkkfreeitem.msgkbn is 'メッセージ区分';
comment on column tm_bhkkfreeitem.tani is '単位';
comment on column tm_bhkkfreeitem.syokiti is '初期値';
comment on column tm_bhkkfreeitem.keisankbn is '計算区分';
comment on column tm_bhkkfreeitem.keisansusiki is '計算数式';
comment on column tm_bhkkfreeitem.keisankansuid is '計算関数ID';
comment on column tm_bhkkfreeitem.keisanparam is '計算パラメータ';
comment on column tm_bhkkfreeitem.komokutokuteikbn is '項目特定区分';
comment on column tm_bhkkfreeitem.orderseq is '並びシーケンス';
comment on column tm_bhkkfreeitem.biko is '備考';
comment on column tm_bhkkfreeitem.riyokaisu is '利用回数';
comment on column tm_bhkkfreeitem.reguserid is '登録ユーザーID';
comment on column tm_bhkkfreeitem.regdttm is '登録日時';
comment on column tm_bhkkfreeitem.upduserid is '更新ユーザーID';
comment on column tm_bhkkfreeitem.upddttm is '更新日時';

--乳幼児パーセンタイル値マスタ
drop table if exists tm_bhnypasentairu;
create table tm_bhnypasentairu(
    buicd varchar(1) not null,
    sex varchar(1) not null,
    month smallint not null,
    date smallint not null,
    pasentairucd varchar(1) not null,
    pasentairuti smallint not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(buicd,sex,month,date,pasentairucd)
);
comment on table tm_bhnypasentairu is '乳幼児パーセンタイル値マスタ';
comment on column tm_bhnypasentairu.buicd is '部位コード';
comment on column tm_bhnypasentairu.sex is '性別';
comment on column tm_bhnypasentairu.month is '月';
comment on column tm_bhnypasentairu.date is '日';
comment on column tm_bhnypasentairu.pasentairucd is 'パーセンタイル値コード';
comment on column tm_bhnypasentairu.pasentairuti is 'パーセンタイル値';
comment on column tm_bhnypasentairu.regsisyo is '登録支所';
comment on column tm_bhnypasentairu.reguserid is '登録ユーザーID';
comment on column tm_bhnypasentairu.regdttm is '登録日時';
comment on column tm_bhnypasentairu.upduserid is '更新ユーザーID';
comment on column tm_bhnypasentairu.upddttm is '更新日時';

--乳幼児（フリー）項目テーブル
drop table if exists tt_bhnyfree;
create table tt_bhnyfree(
    jigyocd varchar(5) not null,
    atenano varchar(15) not null,
    edano smallint not null,
    itemcd varchar(12) not null,
    fusyoflg boolean,
    numvalue double precision,
    strvalue varchar(1000),
primary key(jigyocd,atenano,edano,itemcd)
);
comment on table tt_bhnyfree is '乳幼児（フリー）項目テーブル';
comment on column tt_bhnyfree.jigyocd is '母子保健事業コード';
comment on column tt_bhnyfree.atenano is '宛名番号';
comment on column tt_bhnyfree.edano is '枝番';
comment on column tt_bhnyfree.itemcd is '項目コード';
comment on column tt_bhnyfree.fusyoflg is '不詳フラグ';
comment on column tt_bhnyfree.numvalue is '数値項目';
comment on column tt_bhnyfree.strvalue is '文字項目';

--妊産婦（フリー）項目テーブル
drop table if exists tt_bhnsfree;
create table tt_bhnsfree(
    jigyocd varchar(5) not null,
    atenano varchar(15) not null,
    torokuno bigint not null,
    torokunorenban smallint not null,
    edano smallint not null,
    kaisu varchar(2) not null,
    itemcd varchar(12) not null,
    fusyoflg boolean,
    numvalue double precision,
    strvalue varchar(1000),
primary key(jigyocd,atenano,torokuno,torokunorenban,edano,kaisu,itemcd)
);
comment on table tt_bhnsfree is '妊産婦（フリー）項目テーブル';
comment on column tt_bhnsfree.jigyocd is '母子保健事業コード';
comment on column tt_bhnsfree.atenano is '宛名番号';
comment on column tt_bhnsfree.torokuno is '登録番号';
comment on column tt_bhnsfree.torokunorenban is '登録番号連番';
comment on column tt_bhnsfree.edano is '枝番';
comment on column tt_bhnsfree.kaisu is '回数';
comment on column tt_bhnsfree.itemcd is '項目コード';
comment on column tt_bhnsfree.fusyoflg is '不詳フラグ';
comment on column tt_bhnsfree.numvalue is '数値項目';
comment on column tt_bhnsfree.strvalue is '文字項目';

--出生時状況（固定項目）テーブル
drop table if exists tt_bhnysyussyojijokyo;
create table tt_bhnysyussyojijokyo(
    atenano varchar(15) not null,
    torokuno bigint not null,
    torokunorenban smallint not null,
    hahaoyaatenano varchar(15) not null,
    titioyaatenano varchar(15) not null,
    hogosyaatenano varchar(15) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano)
);
comment on table tt_bhnysyussyojijokyo is '出生時状況（固定項目）テーブル';
comment on column tt_bhnysyussyojijokyo.atenano is '宛名番号';
comment on column tt_bhnysyussyojijokyo.torokuno is '登録番号';
comment on column tt_bhnysyussyojijokyo.torokunorenban is '登録番号連番';
comment on column tt_bhnysyussyojijokyo.hahaoyaatenano is '母親_宛名番号';
comment on column tt_bhnysyussyojijokyo.titioyaatenano is '父親_宛名番号';
comment on column tt_bhnysyussyojijokyo.hogosyaatenano is '保護者_宛名番号';
comment on column tt_bhnysyussyojijokyo.regsisyo is '登録支所';
comment on column tt_bhnysyussyojijokyo.reguserid is '登録ユーザーID';
comment on column tt_bhnysyussyojijokyo.regdttm is '登録日時';
comment on column tt_bhnysyussyojijokyo.upduserid is '更新ユーザーID';
comment on column tt_bhnysyussyojijokyo.upddttm is '更新日時';

--新生児聴覚検査結果（固定項目）テーブル
drop table if exists tt_bhnytyokakukensakekka;
create table tt_bhnytyokakukensakekka(
    atenano varchar(15) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano)
);
comment on table tt_bhnytyokakukensakekka is '新生児聴覚検査結果（固定項目）テーブル';
comment on column tt_bhnytyokakukensakekka.atenano is '宛名番号';
comment on column tt_bhnytyokakukensakekka.regsisyo is '登録支所';
comment on column tt_bhnytyokakukensakekka.reguserid is '登録ユーザーID';
comment on column tt_bhnytyokakukensakekka.regdttm is '登録日時';
comment on column tt_bhnytyokakukensakekka.upduserid is '更新ユーザーID';
comment on column tt_bhnytyokakukensakekka.upddttm is '更新日時';

--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
drop table if exists tt_bhnytyokakukensahiyojosei;
create table tt_bhnytyokakukensahiyojosei(
    atenano varchar(15) not null,
    edano smallint not null,
    sinseiymd varchar(10) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,edano)
);
comment on table tt_bhnytyokakukensahiyojosei is '新生児聴覚スクリーニング検査費用助成（固定項目）テーブル';
comment on column tt_bhnytyokakukensahiyojosei.atenano is '宛名番号';
comment on column tt_bhnytyokakukensahiyojosei.edano is '枝番';
comment on column tt_bhnytyokakukensahiyojosei.sinseiymd is '申請日';
comment on column tt_bhnytyokakukensahiyojosei.regsisyo is '登録支所';
comment on column tt_bhnytyokakukensahiyojosei.reguserid is '登録ユーザーID';
comment on column tt_bhnytyokakukensahiyojosei.regdttm is '登録日時';
comment on column tt_bhnytyokakukensahiyojosei.upduserid is '更新ユーザーID';
comment on column tt_bhnytyokakukensahiyojosei.upddttm is '更新日時';

--乳幼児健診結果（固定項目）テーブル
drop table if exists tt_bhnykensinkekka;
create table tt_bhnykensinkekka(
    nykensincd varchar(5) not null,
    atenano varchar(15) not null,
    edano smallint not null,
    jusinymd varchar(10) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(nykensincd,atenano,edano)
);
comment on table tt_bhnykensinkekka is '乳幼児健診結果（固定項目）テーブル';
comment on column tt_bhnykensinkekka.nykensincd is '乳幼児健診コード';
comment on column tt_bhnykensinkekka.atenano is '宛名番号';
comment on column tt_bhnykensinkekka.edano is '枝番';
comment on column tt_bhnykensinkekka.jusinymd is '健診受診日';
comment on column tt_bhnykensinkekka.regsisyo is '登録支所';
comment on column tt_bhnykensinkekka.reguserid is '登録ユーザーID';
comment on column tt_bhnykensinkekka.regdttm is '登録日時';
comment on column tt_bhnykensinkekka.upduserid is '更新ユーザーID';
comment on column tt_bhnykensinkekka.upddttm is '更新日時';

--乳幼児健診アンケート（固定項目）テーブル
drop table if exists tt_bhnykensinanketo;
create table tt_bhnykensinanketo(
    nykensincd varchar(5) not null,
    atenano varchar(15) not null,
    edano smallint not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(nykensincd,atenano,edano)
);
comment on table tt_bhnykensinanketo is '乳幼児健診アンケート（固定項目）テーブル';
comment on column tt_bhnykensinanketo.nykensincd is '乳幼児健診コード';
comment on column tt_bhnykensinanketo.atenano is '宛名番号';
comment on column tt_bhnykensinanketo.edano is '枝番';
comment on column tt_bhnykensinanketo.regsisyo is '登録支所';
comment on column tt_bhnykensinanketo.reguserid is '登録ユーザーID';
comment on column tt_bhnykensinanketo.regdttm is '登録日時';
comment on column tt_bhnykensinanketo.upduserid is '更新ユーザーID';
comment on column tt_bhnykensinanketo.upddttm is '更新日時';

--乳幼児歯科健診結果（固定項目）テーブル
drop table if exists tt_bhnysikakensinkekka;
create table tt_bhnysikakensinkekka(
    nykensincd varchar(5) not null,
    atenano varchar(15) not null,
    edano smallint not null,
    sikajusinymd varchar(10) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(nykensincd,atenano,edano)
);
comment on table tt_bhnysikakensinkekka is '乳幼児歯科健診結果（固定項目）テーブル';
comment on column tt_bhnysikakensinkekka.nykensincd is '乳幼児健診コード';
comment on column tt_bhnysikakensinkekka.atenano is '宛名番号';
comment on column tt_bhnysikakensinkekka.edano is '枝番';
comment on column tt_bhnysikakensinkekka.sikajusinymd is '歯科健診受診日';
comment on column tt_bhnysikakensinkekka.regsisyo is '登録支所';
comment on column tt_bhnysikakensinkekka.reguserid is '登録ユーザーID';
comment on column tt_bhnysikakensinkekka.regdttm is '登録日時';
comment on column tt_bhnysikakensinkekka.upduserid is '更新ユーザーID';
comment on column tt_bhnysikakensinkekka.upddttm is '更新日時';

--独自施策（子）（固定項目）テーブル
drop table if exists tt_bhnydokujisesaku;
create table tt_bhnydokujisesaku(
    jigyocd varchar(5) not null,
    atenano varchar(15) not null,
    edano smallint not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(jigyocd,atenano,edano)
);
comment on table tt_bhnydokujisesaku is '独自施策（子）（固定項目）テーブル';
comment on column tt_bhnydokujisesaku.jigyocd is '母子保健事業コード';
comment on column tt_bhnydokujisesaku.atenano is '宛名番号';
comment on column tt_bhnydokujisesaku.edano is '枝番';
comment on column tt_bhnydokujisesaku.regsisyo is '登録支所';
comment on column tt_bhnydokujisesaku.reguserid is '登録ユーザーID';
comment on column tt_bhnydokujisesaku.regdttm is '登録日時';
comment on column tt_bhnydokujisesaku.upduserid is '更新ユーザーID';
comment on column tt_bhnydokujisesaku.upddttm is '更新日時';

--乳幼児精密健診結果（固定項目）テーブル
drop table if exists tt_bhnyseikenkekka;
create table tt_bhnyseikenkekka(
    atenano varchar(15) not null,
    edano smallint not null,
    seikenjissiymd varchar(10) not null,
    haakukeiro varchar(5) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,edano)
);
comment on table tt_bhnyseikenkekka is '乳幼児精密健診結果（固定項目）テーブル';
comment on column tt_bhnyseikenkekka.atenano is '宛名番号';
comment on column tt_bhnyseikenkekka.edano is '枝番';
comment on column tt_bhnyseikenkekka.seikenjissiymd is '精密健診実施日';
comment on column tt_bhnyseikenkekka.haakukeiro is '把握経路';
comment on column tt_bhnyseikenkekka.regsisyo is '登録支所';
comment on column tt_bhnyseikenkekka.reguserid is '登録ユーザーID';
comment on column tt_bhnyseikenkekka.regdttm is '登録日時';
comment on column tt_bhnyseikenkekka.upduserid is '更新ユーザーID';
comment on column tt_bhnyseikenkekka.upddttm is '更新日時';

--健診受診履歴（固定項目）テーブル
drop table if exists tt_bhnykensinjusinreki;
create table tt_bhnykensinjusinreki(
    atenano varchar(15) not null,
    haakuymd varchar(10) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano)
);
comment on table tt_bhnykensinjusinreki is '健診受診履歴（固定項目）テーブル';
comment on column tt_bhnykensinjusinreki.atenano is '宛名番号';
comment on column tt_bhnykensinjusinreki.haakuymd is '把握日';
comment on column tt_bhnykensinjusinreki.regsisyo is '登録支所';
comment on column tt_bhnykensinjusinreki.reguserid is '登録ユーザーID';
comment on column tt_bhnykensinjusinreki.regdttm is '登録日時';
comment on column tt_bhnykensinjusinreki.upduserid is '更新ユーザーID';
comment on column tt_bhnykensinjusinreki.upddttm is '更新日時';

--未受診者勧奨（固定項目）テーブル
drop table if exists tt_bhnymijusinsyakansyo;
create table tt_bhnymijusinsyakansyo(
    atenano varchar(15) not null,
    edano smallint not null,
    mijusinhaakuymd varchar(10) not null,
    mijusinjigyo varchar(5) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,edano)
);
comment on table tt_bhnymijusinsyakansyo is '未受診者勧奨（固定項目）テーブル';
comment on column tt_bhnymijusinsyakansyo.atenano is '宛名番号';
comment on column tt_bhnymijusinsyakansyo.edano is '枝番';
comment on column tt_bhnymijusinsyakansyo.mijusinhaakuymd is '未受診把握日';
comment on column tt_bhnymijusinsyakansyo.mijusinjigyo is '未受診事業';
comment on column tt_bhnymijusinsyakansyo.regsisyo is '登録支所';
comment on column tt_bhnymijusinsyakansyo.reguserid is '登録ユーザーID';
comment on column tt_bhnymijusinsyakansyo.regdttm is '登録日時';
comment on column tt_bhnymijusinsyakansyo.upduserid is '更新ユーザーID';
comment on column tt_bhnymijusinsyakansyo.upddttm is '更新日時';

--精密健診の依頼（固定項目）テーブル
drop table if exists tt_bhnyseikenirai;
create table tt_bhnyseikenirai(
    atenano varchar(15) not null,
    edano smallint not null,
    haakukeiro varchar(5) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,edano)
);
comment on table tt_bhnyseikenirai is '精密健診の依頼（固定項目）テーブル';
comment on column tt_bhnyseikenirai.atenano is '宛名番号';
comment on column tt_bhnyseikenirai.edano is '枝番';
comment on column tt_bhnyseikenirai.haakukeiro is '把握経路';
comment on column tt_bhnyseikenirai.regsisyo is '登録支所';
comment on column tt_bhnyseikenirai.reguserid is '登録ユーザーID';
comment on column tt_bhnyseikenirai.regdttm is '登録日時';
comment on column tt_bhnyseikenirai.upduserid is '更新ユーザーID';
comment on column tt_bhnyseikenirai.upddttm is '更新日時';

--妊娠届出（固定）テーブル
drop table if exists tt_bhnsninsintodokede;
create table tt_bhnsninsintodokede(
    atenano varchar(15) not null,
    torokuno bigint not null,
    todokedeymd varchar(10) not null,
    titioyaatenano varchar(15) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,torokuno)
);
comment on table tt_bhnsninsintodokede is '妊娠届出（固定）テーブル';
comment on column tt_bhnsninsintodokede.atenano is '宛名番号';
comment on column tt_bhnsninsintodokede.torokuno is '登録番号';
comment on column tt_bhnsninsintodokede.todokedeymd is '届出年月日';
comment on column tt_bhnsninsintodokede.titioyaatenano is '父親_宛名番号';
comment on column tt_bhnsninsintodokede.regsisyo is '登録支所';
comment on column tt_bhnsninsintodokede.reguserid is '登録ユーザーID';
comment on column tt_bhnsninsintodokede.regdttm is '登録日時';
comment on column tt_bhnsninsintodokede.upduserid is '更新ユーザーID';
comment on column tt_bhnsninsintodokede.upddttm is '更新日時';

--妊娠届出アンケート（固定）テーブル
drop table if exists tt_bhnsninsintodokedeanketo;
create table tt_bhnsninsintodokedeanketo(
    atenano varchar(15) not null,
    torokuno bigint not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,torokuno)
);
comment on table tt_bhnsninsintodokedeanketo is '妊娠届出アンケート（固定）テーブル';
comment on column tt_bhnsninsintodokedeanketo.atenano is '宛名番号';
comment on column tt_bhnsninsintodokedeanketo.torokuno is '登録番号';
comment on column tt_bhnsninsintodokedeanketo.regsisyo is '登録支所';
comment on column tt_bhnsninsintodokedeanketo.reguserid is '登録ユーザーID';
comment on column tt_bhnsninsintodokedeanketo.regdttm is '登録日時';
comment on column tt_bhnsninsintodokedeanketo.upduserid is '更新ユーザーID';
comment on column tt_bhnsninsintodokedeanketo.upddttm is '更新日時';

--母子健康手帳交付（固定）テーブル
drop table if exists tt_bhnsbosikenkotetyokofu;
create table tt_bhnsbosikenkotetyokofu(
    atenano varchar(15) not null,
    torokuno bigint not null,
    torokunorenban smallint not null,
    bositetyokofubi varchar(10) not null,
    bositetyokofuno varchar(20) not null,
    bositetyokofunoedano smallint not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,torokuno,torokunorenban)
);
comment on table tt_bhnsbosikenkotetyokofu is '母子健康手帳交付（固定）テーブル';
comment on column tt_bhnsbosikenkotetyokofu.atenano is '宛名番号';
comment on column tt_bhnsbosikenkotetyokofu.torokuno is '登録番号';
comment on column tt_bhnsbosikenkotetyokofu.torokunorenban is '登録番号連番';
comment on column tt_bhnsbosikenkotetyokofu.bositetyokofubi is '母子健康手帳交付日';
comment on column tt_bhnsbosikenkotetyokofu.bositetyokofuno is '母子健康手帳交付番号';
comment on column tt_bhnsbosikenkotetyokofu.bositetyokofunoedano is '母子健康手帳交付番号枝番';
comment on column tt_bhnsbosikenkotetyokofu.regsisyo is '登録支所';
comment on column tt_bhnsbosikenkotetyokofu.reguserid is '登録ユーザーID';
comment on column tt_bhnsbosikenkotetyokofu.regdttm is '登録日時';
comment on column tt_bhnsbosikenkotetyokofu.upduserid is '更新ユーザーID';
comment on column tt_bhnsbosikenkotetyokofu.upddttm is '更新日時';

--出産の状態に係る（固定）テーブル
drop table if exists tt_bhnssyussanjotai;
create table tt_bhnssyussanjotai(
    atenano varchar(15) not null,
    torokuno bigint not null,
    torokunorenban smallint not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,torokuno,torokunorenban)
);
comment on table tt_bhnssyussanjotai is '出産の状態に係る（固定）テーブル';
comment on column tt_bhnssyussanjotai.atenano is '宛名番号';
comment on column tt_bhnssyussanjotai.torokuno is '登録番号';
comment on column tt_bhnssyussanjotai.torokunorenban is '登録番号連番';
comment on column tt_bhnssyussanjotai.regsisyo is '登録支所';
comment on column tt_bhnssyussanjotai.reguserid is '登録ユーザーID';
comment on column tt_bhnssyussanjotai.regdttm is '登録日時';
comment on column tt_bhnssyussanjotai.upduserid is '更新ユーザーID';
comment on column tt_bhnssyussanjotai.upddttm is '更新日時';

--妊婦健診結果（固定）テーブル
drop table if exists tt_bhnsninpukensinkekka;
create table tt_bhnsninpukensinkekka(
    atenano varchar(15) not null,
    torokuno bigint not null,
    jusinkaisu varchar(2) not null,
    jusinymd varchar(10) not null,
    jusinkbn varchar(1) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,torokuno,jusinkaisu)
);
comment on table tt_bhnsninpukensinkekka is '妊婦健診結果（固定）テーブル';
comment on column tt_bhnsninpukensinkekka.atenano is '宛名番号';
comment on column tt_bhnsninpukensinkekka.torokuno is '登録番号';
comment on column tt_bhnsninpukensinkekka.jusinkaisu is '受診回数';
comment on column tt_bhnsninpukensinkekka.jusinymd is '受診日';
comment on column tt_bhnsninpukensinkekka.jusinkbn is '受診区分';
comment on column tt_bhnsninpukensinkekka.regsisyo is '登録支所';
comment on column tt_bhnsninpukensinkekka.reguserid is '登録ユーザーID';
comment on column tt_bhnsninpukensinkekka.regdttm is '登録日時';
comment on column tt_bhnsninpukensinkekka.upduserid is '更新ユーザーID';
comment on column tt_bhnsninpukensinkekka.upddttm is '更新日時';

--妊婦健診費用助成（固定）テーブル
drop table if exists tt_bhnsninpukensinhiyojosei;
create table tt_bhnsninpukensinhiyojosei(
    jigyocd varchar(5) not null,
    atenano varchar(15) not null,
    torokuno bigint not null,
    sinseiedano smallint not null,
    sinseiymd varchar(10) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(jigyocd,atenano,torokuno,sinseiedano)
);
comment on table tt_bhnsninpukensinhiyojosei is '妊婦健診費用助成（固定）テーブル';
comment on column tt_bhnsninpukensinhiyojosei.jigyocd is '母子保健事業コード';
comment on column tt_bhnsninpukensinhiyojosei.atenano is '宛名番号';
comment on column tt_bhnsninpukensinhiyojosei.torokuno is '登録番号';
comment on column tt_bhnsninpukensinhiyojosei.sinseiedano is '申請枝番';
comment on column tt_bhnsninpukensinhiyojosei.sinseiymd is '申請日';
comment on column tt_bhnsninpukensinhiyojosei.regsisyo is '登録支所';
comment on column tt_bhnsninpukensinhiyojosei.reguserid is '登録ユーザーID';
comment on column tt_bhnsninpukensinhiyojosei.regdttm is '登録日時';
comment on column tt_bhnsninpukensinhiyojosei.upduserid is '更新ユーザーID';
comment on column tt_bhnsninpukensinhiyojosei.upddttm is '更新日時';

--妊婦健診費用助成（固定）サブテーブル
drop table if exists tt_bhnsninpukensinhiyojosei_sub;
create table tt_bhnsninpukensinhiyojosei_sub(
    jigyocd varchar(5) not null,
    atenano varchar(15) not null,
    torokuno bigint not null,
    sinseiedano smallint not null,
    edano smallint not null,
    joseikensyurui varchar(2) not null,
    jusinymd varchar(10) not null,
    siharaikingaku integer not null,
    joseikingaku integer not null,
primary key(jigyocd,atenano,torokuno,sinseiedano,edano)
);
comment on table tt_bhnsninpukensinhiyojosei_sub is '妊婦健診費用助成（固定）サブテーブル';
comment on column tt_bhnsninpukensinhiyojosei_sub.jigyocd is '母子保健事業コード';
comment on column tt_bhnsninpukensinhiyojosei_sub.atenano is '宛名番号';
comment on column tt_bhnsninpukensinhiyojosei_sub.torokuno is '登録番号';
comment on column tt_bhnsninpukensinhiyojosei_sub.sinseiedano is '申請枝番';
comment on column tt_bhnsninpukensinhiyojosei_sub.edano is '枝番';
comment on column tt_bhnsninpukensinhiyojosei_sub.joseikensyurui is '助成券種類';
comment on column tt_bhnsninpukensinhiyojosei_sub.jusinymd is '受診年月日';
comment on column tt_bhnsninpukensinhiyojosei_sub.siharaikingaku is '支払金額';
comment on column tt_bhnsninpukensinhiyojosei_sub.joseikingaku is '助成金額';

--妊産婦歯科健診結果（固定）テーブル
drop table if exists tt_bhnssikakensinkekka;
create table tt_bhnssikakensinkekka(
    atenano varchar(15) not null,
    torokuno bigint not null,
    edano smallint not null,
    ninsanpusikajusinymd varchar(10) not null,
    ninsanpukbn varchar(1) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,torokuno,edano)
);
comment on table tt_bhnssikakensinkekka is '妊産婦歯科健診結果（固定）テーブル';
comment on column tt_bhnssikakensinkekka.atenano is '宛名番号';
comment on column tt_bhnssikakensinkekka.torokuno is '登録番号';
comment on column tt_bhnssikakensinkekka.edano is '枝番';
comment on column tt_bhnssikakensinkekka.ninsanpusikajusinymd is '妊産婦歯科健診受診日';
comment on column tt_bhnssikakensinkekka.ninsanpukbn is '妊産婦区分';
comment on column tt_bhnssikakensinkekka.regsisyo is '登録支所';
comment on column tt_bhnssikakensinkekka.reguserid is '登録ユーザーID';
comment on column tt_bhnssikakensinkekka.regdttm is '登録日時';
comment on column tt_bhnssikakensinkekka.upduserid is '更新ユーザーID';
comment on column tt_bhnssikakensinkekka.upddttm is '更新日時';

--妊産婦歯科精健結果（固定）テーブル
drop table if exists tt_bhnssikaseikenkekka;
create table tt_bhnssikaseikenkekka(
    atenano varchar(15) not null,
    torokuno bigint not null,
    edano smallint not null,
    seimitukensajissiymd varchar(10) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,torokuno,edano)
);
comment on table tt_bhnssikaseikenkekka is '妊産婦歯科精健結果（固定）テーブル';
comment on column tt_bhnssikaseikenkekka.atenano is '宛名番号';
comment on column tt_bhnssikaseikenkekka.torokuno is '登録番号';
comment on column tt_bhnssikaseikenkekka.edano is '枝番';
comment on column tt_bhnssikaseikenkekka.seimitukensajissiymd is '精密検査実施日';
comment on column tt_bhnssikaseikenkekka.regsisyo is '登録支所';
comment on column tt_bhnssikaseikenkekka.reguserid is '登録ユーザーID';
comment on column tt_bhnssikaseikenkekka.regdttm is '登録日時';
comment on column tt_bhnssikaseikenkekka.upduserid is '更新ユーザーID';
comment on column tt_bhnssikaseikenkekka.upddttm is '更新日時';

--妊婦精健結果（固定）テーブル
drop table if exists tt_bhnsninpuseikenkekka;
create table tt_bhnsninpuseikenkekka(
    atenano varchar(15) not null,
    torokuno bigint not null,
    edano smallint not null,
    seimitukensajissiymd varchar(10) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,torokuno,edano)
);
comment on table tt_bhnsninpuseikenkekka is '妊婦精健結果（固定）テーブル';
comment on column tt_bhnsninpuseikenkekka.atenano is '宛名番号';
comment on column tt_bhnsninpuseikenkekka.torokuno is '登録番号';
comment on column tt_bhnsninpuseikenkekka.edano is '枝番';
comment on column tt_bhnsninpuseikenkekka.seimitukensajissiymd is '精密検査実施日';
comment on column tt_bhnsninpuseikenkekka.regsisyo is '登録支所';
comment on column tt_bhnsninpuseikenkekka.reguserid is '登録ユーザーID';
comment on column tt_bhnsninpuseikenkekka.regdttm is '登録日時';
comment on column tt_bhnsninpuseikenkekka.upduserid is '更新ユーザーID';
comment on column tt_bhnsninpuseikenkekka.upddttm is '更新日時';

--産婦健診結果（固定）テーブル
drop table if exists tt_bhnssanpukensinkekka;
create table tt_bhnssanpukensinkekka(
    atenano varchar(15) not null,
    torokuno bigint not null,
    edano smallint not null,
    jusinymd varchar(10) not null,
    kensinsyubetu varchar(2) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,torokuno,edano)
);
comment on table tt_bhnssanpukensinkekka is '産婦健診結果（固定）テーブル';
comment on column tt_bhnssanpukensinkekka.atenano is '宛名番号';
comment on column tt_bhnssanpukensinkekka.torokuno is '登録番号';
comment on column tt_bhnssanpukensinkekka.edano is '枝番';
comment on column tt_bhnssanpukensinkekka.jusinymd is '受診日';
comment on column tt_bhnssanpukensinkekka.kensinsyubetu is '健診種別';
comment on column tt_bhnssanpukensinkekka.regsisyo is '登録支所';
comment on column tt_bhnssanpukensinkekka.reguserid is '登録ユーザーID';
comment on column tt_bhnssanpukensinkekka.regdttm is '登録日時';
comment on column tt_bhnssanpukensinkekka.upduserid is '更新ユーザーID';
comment on column tt_bhnssanpukensinkekka.upddttm is '更新日時';

--産婦健診費用助成（固定）テーブル
drop table if exists tt_bhnssanpukensinhiyojosei;
create table tt_bhnssanpukensinhiyojosei(
    atenano varchar(15) not null,
    torokuno bigint not null,
    sinseiedano smallint not null,
    sinseiymd varchar(10) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,torokuno,sinseiedano)
);
comment on table tt_bhnssanpukensinhiyojosei is '産婦健診費用助成（固定）テーブル';
comment on column tt_bhnssanpukensinhiyojosei.atenano is '宛名番号';
comment on column tt_bhnssanpukensinhiyojosei.torokuno is '登録番号';
comment on column tt_bhnssanpukensinhiyojosei.sinseiedano is '申請枝番';
comment on column tt_bhnssanpukensinhiyojosei.sinseiymd is '申請日';
comment on column tt_bhnssanpukensinhiyojosei.regsisyo is '登録支所';
comment on column tt_bhnssanpukensinhiyojosei.reguserid is '登録ユーザーID';
comment on column tt_bhnssanpukensinhiyojosei.regdttm is '登録日時';
comment on column tt_bhnssanpukensinhiyojosei.upduserid is '更新ユーザーID';
comment on column tt_bhnssanpukensinhiyojosei.upddttm is '更新日時';

--産婦健診費用助成（固定）サブテーブル
drop table if exists tt_bhnssanpukensinhiyojosei_sub;
create table tt_bhnssanpukensinhiyojosei_sub(
    atenano varchar(15) not null,
    torokuno bigint not null,
    sinseiedano smallint not null,
    edano smallint not null,
    joseikensyurui varchar(2) not null,
    jusinymd varchar(10) not null,
    siharaikingaku integer not null,
    joseikingaku integer not null,
primary key(atenano,torokuno,sinseiedano,edano)
);
comment on table tt_bhnssanpukensinhiyojosei_sub is '産婦健診費用助成（固定）サブテーブル';
comment on column tt_bhnssanpukensinhiyojosei_sub.atenano is '宛名番号';
comment on column tt_bhnssanpukensinhiyojosei_sub.torokuno is '登録番号';
comment on column tt_bhnssanpukensinhiyojosei_sub.sinseiedano is '申請枝番';
comment on column tt_bhnssanpukensinhiyojosei_sub.edano is '枝番';
comment on column tt_bhnssanpukensinhiyojosei_sub.joseikensyurui is '助成券種類';
comment on column tt_bhnssanpukensinhiyojosei_sub.jusinymd is '受診年月日';
comment on column tt_bhnssanpukensinhiyojosei_sub.siharaikingaku is '支払金額';
comment on column tt_bhnssanpukensinhiyojosei_sub.joseikingaku is '助成金額';

--産婦精密健診結果（固定）テーブル
drop table if exists tt_bhnssanpuseikenkekka;
create table tt_bhnssanpuseikenkekka(
    atenano varchar(15) not null,
    torokuno bigint not null,
    edano smallint not null,
    seimitukensajissiymd varchar(10) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,torokuno,edano)
);
comment on table tt_bhnssanpuseikenkekka is '産婦精密健診結果（固定）テーブル';
comment on column tt_bhnssanpuseikenkekka.atenano is '宛名番号';
comment on column tt_bhnssanpuseikenkekka.torokuno is '登録番号';
comment on column tt_bhnssanpuseikenkekka.edano is '枝番';
comment on column tt_bhnssanpuseikenkekka.seimitukensajissiymd is '精密検査実施日';
comment on column tt_bhnssanpuseikenkekka.regsisyo is '登録支所';
comment on column tt_bhnssanpuseikenkekka.reguserid is '登録ユーザーID';
comment on column tt_bhnssanpuseikenkekka.regdttm is '登録日時';
comment on column tt_bhnssanpuseikenkekka.upduserid is '更新ユーザーID';
comment on column tt_bhnssanpuseikenkekka.upddttm is '更新日時';

--産後ケア事業（固定）テーブル
drop table if exists tt_bhnssangocarejigyo;
create table tt_bhnssangocarejigyo(
    atenano varchar(15) not null,
    torokuno bigint not null,
    edano smallint not null,
    sinseiymd varchar(10) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,torokuno,edano)
);
comment on table tt_bhnssangocarejigyo is '産後ケア事業（固定）テーブル';
comment on column tt_bhnssangocarejigyo.atenano is '宛名番号';
comment on column tt_bhnssangocarejigyo.torokuno is '登録番号';
comment on column tt_bhnssangocarejigyo.edano is '枝番';
comment on column tt_bhnssangocarejigyo.sinseiymd is '申請日';
comment on column tt_bhnssangocarejigyo.regsisyo is '登録支所';
comment on column tt_bhnssangocarejigyo.reguserid is '登録ユーザーID';
comment on column tt_bhnssangocarejigyo.regdttm is '登録日時';
comment on column tt_bhnssangocarejigyo.upduserid is '更新ユーザーID';
comment on column tt_bhnssangocarejigyo.upddttm is '更新日時';

--独自施策（母）（固定）テーブル
drop table if exists tt_bhnsdokujisesaku;
create table tt_bhnsdokujisesaku(
    jigyocd varchar(5) not null,
    atenano varchar(15) not null,
    torokuno bigint not null,
    edano smallint not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(jigyocd,atenano,torokuno,edano)
);
comment on table tt_bhnsdokujisesaku is '独自施策（母）（固定）テーブル';
comment on column tt_bhnsdokujisesaku.jigyocd is '母子保健事業コード';
comment on column tt_bhnsdokujisesaku.atenano is '宛名番号';
comment on column tt_bhnsdokujisesaku.torokuno is '登録番号';
comment on column tt_bhnsdokujisesaku.edano is '枝番';
comment on column tt_bhnsdokujisesaku.regsisyo is '登録支所';
comment on column tt_bhnsdokujisesaku.reguserid is '登録ユーザーID';
comment on column tt_bhnsdokujisesaku.regdttm is '登録日時';
comment on column tt_bhnsdokujisesaku.upduserid is '更新ユーザーID';
comment on column tt_bhnsdokujisesaku.upddttm is '更新日時';

--母子保健管理パターンマスタ
drop table if exists tm_bhkanripattern;
create table tm_bhkanripattern(
    bhsyurui varchar(1) not null,
    bhkanripatterncd varchar(3) not null,
    bhkanripatternname varchar(30) not null,
primary key(bhsyurui,bhkanripatterncd)
);
comment on table tm_bhkanripattern is '母子保健管理パターンマスタ';
comment on column tm_bhkanripattern.bhsyurui is '母子種類';
comment on column tm_bhkanripattern.bhkanripatterncd is '母子管理パターンコード';
comment on column tm_bhkanripattern.bhkanripatternname is '母子管理パターン名称';

--母子保健健診対象者テーブル
drop table if exists tm_bhkensin;
create table tm_bhkensin(
    bhsyurui varchar(1) not null,
    bhdatalistcd varchar(2) not null,
    atenano varchar(15) not null,
    uketukeymd char(10) not null,
    kensinyoteiymd char(10) not null,
    uketukedttm char(5) not null,
    kaijocd varchar(7) not null,
    osiraseflg boolean not null default false,
    annaiflg boolean not null default false,
primary key(bhsyurui,bhdatalistcd,atenano)
);
comment on table tm_bhkensin is '母子保健健診対象者テーブル';
comment on column tm_bhkensin.bhsyurui is '母子種類';
comment on column tm_bhkensin.bhdatalistcd is '母子データリストコード';
comment on column tm_bhkensin.atenano is '宛名番号';
comment on column tm_bhkensin.uketukeymd is '受付日';
comment on column tm_bhkensin.kensinyoteiymd is '健診予定日';
comment on column tm_bhkensin.uketukedttm is '受付開始時間';
comment on column tm_bhkensin.kaijocd is '会場コード';
comment on column tm_bhkensin.osiraseflg is 'お知らせ出力フラグ';
comment on column tm_bhkensin.annaiflg is '案内出力フラグ';

--ワクチンマスタ
drop table if exists tm_ysvaccine;
create table tm_ysvaccine(
    sessyucd varchar(5) not null,
    vaccinemakercd varchar(4) not null,
    vaccinenmcd varchar(2) not null,
    stopflg boolean not null default false,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(sessyucd,vaccinemakercd,vaccinenmcd)
);
comment on table tm_ysvaccine is 'ワクチンマスタ';
comment on column tm_ysvaccine.sessyucd is '接種種類コード';
comment on column tm_ysvaccine.vaccinemakercd is 'ワクチンメーカーコード';
comment on column tm_ysvaccine.vaccinenmcd is 'ワクチン名コード';
comment on column tm_ysvaccine.stopflg is '使用停止フラグ';
comment on column tm_ysvaccine.reguserid is '登録ユーザーID';
comment on column tm_ysvaccine.regdttm is '登録日時';
comment on column tm_ysvaccine.upduserid is '更新ユーザーID';
comment on column tm_ysvaccine.upddttm is '更新日時';

--予診票発行情報テーブル(案)
drop table if exists tt_ysyosinhakko;
create table tt_ysyosinhakko(
    atenano varchar(15) not null,
    sessyucd varchar(5) not null,
    kaisu varchar(2) not null,
    rirekino smallint not null,
    hakkoymd varchar(10) not null,
    hakkobasyo varchar(100),
    sessyukenno varchar(10),
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,sessyucd,kaisu,rirekino)
);
comment on table tt_ysyosinhakko is '予診票発行情報テーブル(案)';
comment on column tt_ysyosinhakko.atenano is '宛名番号';
comment on column tt_ysyosinhakko.sessyucd is '接種種類コード';
comment on column tt_ysyosinhakko.kaisu is '回数';
comment on column tt_ysyosinhakko.rirekino is '履歴番号';
comment on column tt_ysyosinhakko.hakkoymd is '発行日';
comment on column tt_ysyosinhakko.hakkobasyo is '発行場所';
comment on column tt_ysyosinhakko.sessyukenno is '接種券番号';
comment on column tt_ysyosinhakko.regsisyo is '登録支所';
comment on column tt_ysyosinhakko.reguserid is '登録ユーザーID';
comment on column tt_ysyosinhakko.regdttm is '登録日時';
comment on column tt_ysyosinhakko.upduserid is '更新ユーザーID';
comment on column tt_ysyosinhakko.upddttm is '更新日時';

--予防接種依頼テーブル
drop table if exists tt_yssessyuirai;
create table tt_yssessyuirai(
    atenano varchar(15) not null,
    edano integer not null,
    uketukeymd varchar(10) not null,
    iraisaki varchar(100),
    irairiyu varchar(100),
    hogosya_atenano varchar(15),
    hogosya_simei varchar(100),
    regsisyo varchar(3) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,edano)
);
comment on table tt_yssessyuirai is '予防接種依頼テーブル';
comment on column tt_yssessyuirai.atenano is '宛名番号';
comment on column tt_yssessyuirai.edano is '枝番';
comment on column tt_yssessyuirai.uketukeymd is '受付日';
comment on column tt_yssessyuirai.iraisaki is '依頼先';
comment on column tt_yssessyuirai.irairiyu is '依頼理由';
comment on column tt_yssessyuirai.hogosya_atenano is '保護者_宛名番号';
comment on column tt_yssessyuirai.hogosya_simei is '保護者_氏名';
comment on column tt_yssessyuirai.regsisyo is '登録支所';
comment on column tt_yssessyuirai.reguserid is '登録ユーザーID';
comment on column tt_yssessyuirai.regdttm is '登録日時';
comment on column tt_yssessyuirai.upduserid is '更新ユーザーID';
comment on column tt_yssessyuirai.upddttm is '更新日時';

--予防接種依頼サブテーブル
drop table if exists tt_yssessyuirai_sub;
create table tt_yssessyuirai_sub(
    atenano varchar(15) not null,
    edano integer not null,
    sessyucd varchar(5) not null,
    kaisu varchar(2) not null,
primary key(atenano,edano,sessyucd,kaisu)
);
comment on table tt_yssessyuirai_sub is '予防接種依頼サブテーブル';
comment on column tt_yssessyuirai_sub.atenano is '宛名番号';
comment on column tt_yssessyuirai_sub.edano is '枝番';
comment on column tt_yssessyuirai_sub.sessyucd is '接種種類コード';
comment on column tt_yssessyuirai_sub.kaisu is '回数';

--予防接種テーブル
drop table if exists tt_yssessyu;
create table tt_yssessyu(
    atenano varchar(15) not null,
    sessyucd varchar(5) not null,
    kaisu varchar(2) not null,
    edano integer not null,
    sessyukenno varchar(10),
    jissikbn varchar(1) not null,
    sessyukbn varchar(1) not null,
    jissiymd varchar(10),
    hoteikbn varchar(1),
    jissikikancd varchar(10),
    jissikikannm varchar(40),
    kaijocd varchar(7),
    kaijonm varchar(100),
    isicd varchar(10),
    isinm varchar(100),
    lotno varchar(20),
    sessyuryo double precision,
    vaccinemakercd varchar(4),
    vaccinenmcd varchar(2),
    tokubetunojijyo varchar(1),
    regsisyo varchar(3) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,sessyucd,kaisu,edano)
);
comment on table tt_yssessyu is '予防接種テーブル';
comment on column tt_yssessyu.atenano is '宛名番号';
comment on column tt_yssessyu.sessyucd is '接種種類コード';
comment on column tt_yssessyu.kaisu is '回数';
comment on column tt_yssessyu.edano is '枝番';
comment on column tt_yssessyu.sessyukenno is '接種券番号';
comment on column tt_yssessyu.jissikbn is '実施区分';
comment on column tt_yssessyu.sessyukbn is '接種区分';
comment on column tt_yssessyu.jissiymd is '実施日';
comment on column tt_yssessyu.hoteikbn is '法定区分';
comment on column tt_yssessyu.jissikikancd is '実施機関コード';
comment on column tt_yssessyu.jissikikannm is '実施機関名';
comment on column tt_yssessyu.kaijocd is '会場コード';
comment on column tt_yssessyu.kaijonm is '会場名';
comment on column tt_yssessyu.isicd is '医師コード';
comment on column tt_yssessyu.isinm is '医師名';
comment on column tt_yssessyu.lotno is 'ロット番号';
comment on column tt_yssessyu.sessyuryo is '接種量';
comment on column tt_yssessyu.vaccinemakercd is 'ワクチンメーカーコード';
comment on column tt_yssessyu.vaccinenmcd is 'ワクチン名コード';
comment on column tt_yssessyu.tokubetunojijyo is '特別の事情';
comment on column tt_yssessyu.regsisyo is '登録支所';
comment on column tt_yssessyu.reguserid is '登録ユーザーID';
comment on column tt_yssessyu.regdttm is '登録日時';
comment on column tt_yssessyu.upduserid is '更新ユーザーID';
comment on column tt_yssessyu.upddttm is '更新日時';

--風疹抗体検査テーブル
drop table if exists tt_ysfusinkotai;
create table tt_ysfusinkotai(
    atenano varchar(15) not null,
    sessyukenno varchar(10) not null,
    jissiymd varchar(10) not null,
    jissikikancd varchar(10),
    jissikikannm varchar(40),
    isicd varchar(10),
    isinm varchar(100),
    sessyuhanteicd varchar(1) not null,
    kotaikensahohocd varchar(1),
    kotaika varchar(10),
    tanicd varchar(1),
    kotaikensanocd varchar(1),
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano)
);
comment on table tt_ysfusinkotai is '風疹抗体検査テーブル';
comment on column tt_ysfusinkotai.atenano is '宛名番号';
comment on column tt_ysfusinkotai.sessyukenno is '接種券番号';
comment on column tt_ysfusinkotai.jissiymd is '実施日';
comment on column tt_ysfusinkotai.jissikikancd is '実施機関コード';
comment on column tt_ysfusinkotai.jissikikannm is '実施機関名';
comment on column tt_ysfusinkotai.isicd is '医師コード';
comment on column tt_ysfusinkotai.isinm is '医師名';
comment on column tt_ysfusinkotai.sessyuhanteicd is '接種判定コード';
comment on column tt_ysfusinkotai.kotaikensahohocd is '抗体検査方法コード';
comment on column tt_ysfusinkotai.kotaika is '抗体価';
comment on column tt_ysfusinkotai.tanicd is '単位コード';
comment on column tt_ysfusinkotai.kotaikensanocd is '抗体検査番号コード';
comment on column tt_ysfusinkotai.regsisyo is '登録支所';
comment on column tt_ysfusinkotai.reguserid is '登録ユーザーID';
comment on column tt_ysfusinkotai.regdttm is '登録日時';
comment on column tt_ysfusinkotai.upduserid is '更新ユーザーID';
comment on column tt_ysfusinkotai.upddttm is '更新日時';

--罹患テーブル
drop table if exists tt_ysrikan;
create table tt_ysrikan(
    atenano varchar(15) not null,
    rikancd varchar(2) not null,
    haakuymd varchar(10) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano,rikancd)
);
comment on table tt_ysrikan is '罹患テーブル';
comment on column tt_ysrikan.atenano is '宛名番号';
comment on column tt_ysrikan.rikancd is '罹患コード';
comment on column tt_ysrikan.haakuymd is '把握日';
comment on column tt_ysrikan.regsisyo is '登録支所';
comment on column tt_ysrikan.reguserid is '登録ユーザーID';
comment on column tt_ysrikan.regdttm is '登録日時';
comment on column tt_ysrikan.upduserid is '更新ユーザーID';
comment on column tt_ysrikan.upddttm is '更新日時';

--予防接種その他テーブル
drop table if exists tt_yssonota;
create table tt_yssonota(
    atenano varchar(15) not null,
    regsisyo varchar(3),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(atenano)
);
comment on table tt_yssonota is '予防接種その他テーブル';
comment on column tt_yssonota.atenano is '宛名番号';
comment on column tt_yssonota.regsisyo is '登録支所';
comment on column tt_yssonota.reguserid is '登録ユーザーID';
comment on column tt_yssonota.regdttm is '登録日時';
comment on column tt_yssonota.upduserid is '更新ユーザーID';
comment on column tt_yssonota.upddttm is '更新日時';

--予防接種入力チェックマスタ
drop table if exists tm_ysnyuryokucheck;
create table tm_ysnyuryokucheck(
    sessyucd varchar(5) not null,
    kaisu varchar(2) not null,
    vaccinesyu varchar(1) not null,
    sessyuchk1 varchar(100),
    sessyuchk2 varchar(100),
    zensessyu varchar(100),
    rikanchk1 varchar(100),
    rikanchk2 varchar(100),
    kanost smallint,
    kanosttani varchar(1),
    kanoed smallint,
    kanoedtani varchar(1),
    kanohanikbn varchar(1),
    kanocomment varchar(100),
    hyojunst smallint,
    hyojunsttani varchar(1),
    hyojuned smallint,
    hyojunedtani varchar(1),
    hyojunhanikbn varchar(1),
    hyojuncomment varchar(100),
    kankakumin smallint,
    kankakumax smallint,
    kankakutani varchar(1),
    kankakucomment varchar(100),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(sessyucd,kaisu)
);
comment on table tm_ysnyuryokucheck is '予防接種入力チェックマスタ';
comment on column tm_ysnyuryokucheck.sessyucd is '接種種類コード';
comment on column tm_ysnyuryokucheck.kaisu is '回数';
comment on column tm_ysnyuryokucheck.vaccinesyu is 'ワクチン種類';
comment on column tm_ysnyuryokucheck.sessyuchk1 is '接種済みチェック1(エラー)';
comment on column tm_ysnyuryokucheck.sessyuchk2 is '接種済みチェック2(警告)';
comment on column tm_ysnyuryokucheck.zensessyu is '前回接種種類';
comment on column tm_ysnyuryokucheck.rikanchk1 is '罹患済みチェック1(エラー)';
comment on column tm_ysnyuryokucheck.rikanchk2 is '罹患済みチェック2(警告)';
comment on column tm_ysnyuryokucheck.kanost is '接種可能開始';
comment on column tm_ysnyuryokucheck.kanosttani is '接種可能開始単位';
comment on column tm_ysnyuryokucheck.kanoed is '接種可能終了';
comment on column tm_ysnyuryokucheck.kanoedtani is '接種可能終了単位';
comment on column tm_ysnyuryokucheck.kanohanikbn is '接種可能範囲区分';
comment on column tm_ysnyuryokucheck.kanocomment is '接種可能コメント';
comment on column tm_ysnyuryokucheck.hyojunst is '接種標準開始';
comment on column tm_ysnyuryokucheck.hyojunsttani is '接種標準開始単位';
comment on column tm_ysnyuryokucheck.hyojuned is '接種標準終了';
comment on column tm_ysnyuryokucheck.hyojunedtani is '接種標準終了単位';
comment on column tm_ysnyuryokucheck.hyojunhanikbn is '接種標準範囲区分';
comment on column tm_ysnyuryokucheck.hyojuncomment is '接種標準コメント';
comment on column tm_ysnyuryokucheck.kankakumin is '接種間隔下限';
comment on column tm_ysnyuryokucheck.kankakumax is '接種間隔上限';
comment on column tm_ysnyuryokucheck.kankakutani is '接種間隔単位';
comment on column tm_ysnyuryokucheck.kankakucomment is '接種間隔コメント';
comment on column tm_ysnyuryokucheck.reguserid is '登録ユーザーID';
comment on column tm_ysnyuryokucheck.regdttm is '登録日時';
comment on column tm_ysnyuryokucheck.upduserid is '更新ユーザーID';
comment on column tm_ysnyuryokucheck.upddttm is '更新日時';

--予防接種（フリー項目）個人テーブル
drop table if exists tt_yskojinfree;
create table tt_yskojinfree(
    atenano varchar(15) not null,
    itemcd varchar(12) not null,
    fusyoflg boolean,
    numvalue double precision,
    strvalue varchar(1000),
primary key(atenano,itemcd)
);
comment on table tt_yskojinfree is '予防接種（フリー項目）個人テーブル';
comment on column tt_yskojinfree.atenano is '宛名番号';
comment on column tt_yskojinfree.itemcd is '項目コード';
comment on column tt_yskojinfree.fusyoflg is '不詳フラグ';
comment on column tt_yskojinfree.numvalue is '数値項目';
comment on column tt_yskojinfree.strvalue is '文字項目';

--予防接種（フリー項目）接種テーブル
drop table if exists tt_yssessyufree;
create table tt_yssessyufree(
    atenano varchar(15) not null,
    sessyucd varchar(5) not null,
    kaisu varchar(2) not null,
    edano integer not null,
    itemcd varchar(12) not null,
    fusyoflg boolean,
    numvalue double precision,
    strvalue varchar(1000),
primary key(atenano,sessyucd,kaisu,edano,itemcd)
);
comment on table tt_yssessyufree is '予防接種（フリー項目）接種テーブル';
comment on column tt_yssessyufree.atenano is '宛名番号';
comment on column tt_yssessyufree.sessyucd is '接種種類コード';
comment on column tt_yssessyufree.kaisu is '回数';
comment on column tt_yssessyufree.edano is '枝番';
comment on column tt_yssessyufree.itemcd is '項目コード';
comment on column tt_yssessyufree.fusyoflg is '不詳フラグ';
comment on column tt_yssessyufree.numvalue is '数値項目';
comment on column tt_yssessyufree.strvalue is '文字項目';

--予防接種依頼（フリー項目）テーブル
drop table if exists tt_yssessyuiraifree;
create table tt_yssessyuiraifree(
    atenano varchar(15) not null,
    edano integer not null,
    itemcd varchar(12) not null,
    fusyoflg boolean,
    numvalue double precision,
    strvalue varchar(1000),
primary key(atenano,edano,itemcd)
);
comment on table tt_yssessyuiraifree is '予防接種依頼（フリー項目）テーブル';
comment on column tt_yssessyuiraifree.atenano is '宛名番号';
comment on column tt_yssessyuiraifree.edano is '枝番';
comment on column tt_yssessyuiraifree.itemcd is '項目コード';
comment on column tt_yssessyuiraifree.fusyoflg is '不詳フラグ';
comment on column tt_yssessyuiraifree.numvalue is '数値項目';
comment on column tt_yssessyuiraifree.strvalue is '文字項目';

--予防接種（フリー）項目コントロールマスタ
drop table if exists tm_ysfreeitem;
create table tm_ysfreeitem(
    jigyocd varchar(5) not null,
    itemcd varchar(12) not null,
    itemnm varchar(100) not null,
    itemkbn varchar(1) not null,
    groupid varchar(2),
    groupid2 varchar(2),
    inputtype smallint not null,
    codejoken1 varchar(100),
    codejoken2 varchar(100),
    codejoken3 varchar(100),
    keta varchar(10),
    hissuflg boolean not null default false,
    hanif varchar(100),
    hanit varchar(100),
    inputflg boolean not null default true,
    msgkbn smallint not null,
    tani varchar(100),
    syokiti varchar(1000),
    keisankbn varchar(1),
    keisansusiki varchar(2000),
    keisankansuid varchar(20),
    keisanparam varchar,
    komokutokuteikbn varchar(2),
    orderseq smallint not null,
    biko varchar(1000),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(jigyocd,itemcd)
);
comment on table tm_ysfreeitem is '予防接種（フリー）項目コントロールマスタ';
comment on column tm_ysfreeitem.jigyocd is '予防接種事業コード';
comment on column tm_ysfreeitem.itemcd is '項目コード';
comment on column tm_ysfreeitem.itemnm is '項目名';
comment on column tm_ysfreeitem.itemkbn is '項目区分';
comment on column tm_ysfreeitem.groupid is 'グループID';
comment on column tm_ysfreeitem.groupid2 is 'グループID2';
comment on column tm_ysfreeitem.inputtype is '入力タイプ';
comment on column tm_ysfreeitem.codejoken1 is 'コード条件1';
comment on column tm_ysfreeitem.codejoken2 is 'コード条件2';
comment on column tm_ysfreeitem.codejoken3 is 'コード条件3';
comment on column tm_ysfreeitem.keta is '入力桁';
comment on column tm_ysfreeitem.hissuflg is '必須フラグ';
comment on column tm_ysfreeitem.hanif is '入力範囲（開始）';
comment on column tm_ysfreeitem.hanit is '入力範囲（終了）';
comment on column tm_ysfreeitem.inputflg is '入力フラグ';
comment on column tm_ysfreeitem.msgkbn is 'メッセージ区分';
comment on column tm_ysfreeitem.tani is '単位';
comment on column tm_ysfreeitem.syokiti is '初期値';
comment on column tm_ysfreeitem.keisankbn is '計算区分';
comment on column tm_ysfreeitem.keisansusiki is '計算数式';
comment on column tm_ysfreeitem.keisankansuid is '計算関数ID';
comment on column tm_ysfreeitem.keisanparam is '計算パラメータ';
comment on column tm_ysfreeitem.komokutokuteikbn is '項目特定区分';
comment on column tm_ysfreeitem.orderseq is '並びシーケンス';
comment on column tm_ysfreeitem.biko is '備考';
comment on column tm_ysfreeitem.reguserid is '登録ユーザーID';
comment on column tm_ysfreeitem.regdttm is '登録日時';
comment on column tm_ysfreeitem.upduserid is '更新ユーザーID';
comment on column tm_ysfreeitem.upddttm is '更新日時';

--風しん抗体検査（フリー項目）テーブル
drop table if exists tt_ysfusinkotaifree;
create table tt_ysfusinkotaifree(
    atenano varchar(15) not null,
    itemcd varchar(12) not null,
    fusyoflg boolean,
    numvalue double precision,
    strvalue varchar(1000),
primary key(atenano,itemcd)
);
comment on table tt_ysfusinkotaifree is '風しん抗体検査（フリー項目）テーブル';
comment on column tt_ysfusinkotaifree.atenano is '宛名番号';
comment on column tt_ysfusinkotaifree.itemcd is '項目コード';
comment on column tt_ysfusinkotaifree.fusyoflg is '不詳フラグ';
comment on column tt_ysfusinkotaifree.numvalue is '数値項目';
comment on column tt_ysfusinkotaifree.strvalue is '文字項目';

--予防接種事業マスタ
drop table if exists tm_ysjigyo;
create table tm_ysjigyo(
    jigyocd varchar(5) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(jigyocd)
);
comment on table tm_ysjigyo is '予防接種事業マスタ';
comment on column tm_ysjigyo.jigyocd is '予防接種事業コード';
comment on column tm_ysjigyo.reguserid is '登録ユーザーID';
comment on column tm_ysjigyo.regdttm is '登録日時';
comment on column tm_ysjigyo.upduserid is '更新ユーザーID';
comment on column tm_ysjigyo.upddttm is '更新日時';

--EUCテーブルマスタ
drop table if exists tm_eutable;
create table tm_eutable(
    tablealias varchar(60) not null,
    tablenm varchar(40) not null,
    tablehyojinm varchar(50) not null,
    tablekbn varchar(1) not null,
    tableflg boolean not null,
    orderseq smallint not null default 0,
primary key(tablealias)
);
comment on table tm_eutable is 'EUCテーブルマスタ';
comment on column tm_eutable.tablealias is 'テーブル別名';
comment on column tm_eutable.tablenm is 'テーブル物理名';
comment on column tm_eutable.tablehyojinm is 'テーブル名称';
comment on column tm_eutable.tablekbn is 'テーブル区分';
comment on column tm_eutable.tableflg is 'テーブルフラグ';
comment on column tm_eutable.orderseq is '並びシーケンス';

--EUCテーブル項目マスタ
drop table if exists tm_eutableitem;
create table tm_eutableitem(
    sqlcolumn varchar(200) not null,
    itemid varchar(60) not null,
    itemhyojinm varchar(50) not null,
    orderseq smallint not null default 0,
    datatype smallint not null,
    selectflg boolean not null,
    usekbn smallint not null,
    itemkbn varchar(1) not null,
    syukeikbn varchar(1),
    tablealias varchar(60) not null,
    tablealias2 varchar(120),
    mastercd varchar(20),
    masterpara varchar(20),
    daibunrui varchar(50),
    tyubunrui varchar(25),
    syobunrui varchar(25),
    biko varchar(50),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(sqlcolumn)
);
comment on table tm_eutableitem is 'EUCテーブル項目マスタ';
comment on column tm_eutableitem.sqlcolumn is 'SQLカラム';
comment on column tm_eutableitem.itemid is '項目ID';
comment on column tm_eutableitem.itemhyojinm is '表示名称';
comment on column tm_eutableitem.orderseq is '並びシーケンス';
comment on column tm_eutableitem.datatype is 'データ型';
comment on column tm_eutableitem.selectflg is '既定選択フラグ';
comment on column tm_eutableitem.usekbn is '使用区分';
comment on column tm_eutableitem.itemkbn is '出力項目区分';
comment on column tm_eutableitem.syukeikbn is '集計項目区分';
comment on column tm_eutableitem.tablealias is 'テーブル別名';
comment on column tm_eutableitem.tablealias2 is 'テーブル別名２';
comment on column tm_eutableitem.mastercd is '名称マスタコード';
comment on column tm_eutableitem.masterpara is '名称マスタパラメータ';
comment on column tm_eutableitem.daibunrui is '大分類';
comment on column tm_eutableitem.tyubunrui is '中分類';
comment on column tm_eutableitem.syobunrui is '小分類';
comment on column tm_eutableitem.biko is '備考';
comment on column tm_eutableitem.reguserid is '登録ユーザーID';
comment on column tm_eutableitem.regdttm is '登録日時';
comment on column tm_eutableitem.upduserid is '更新ユーザーID';
comment on column tm_eutableitem.upddttm is '更新日時';

--EUCテーブル項目名称マスタ
drop table if exists tm_eutableitemname;
create table tm_eutableitemname(
    mastercd varchar(20) not null,
    masterhyojinm varchar(50) not null,
    tablenm varchar(50) not null,
    keynm varchar(20) not null,
    meisyonm varchar(20) not null,
    maincd varchar(20),
    subcd varchar(20),
    maincdnumflg boolean not null,
primary key(mastercd)
);
comment on table tm_eutableitemname is 'EUCテーブル項目名称マスタ';
comment on column tm_eutableitemname.mastercd is '名称マスタコード';
comment on column tm_eutableitemname.masterhyojinm is 'マスタ名称';
comment on column tm_eutableitemname.tablenm is 'テーブル物理名';
comment on column tm_eutableitemname.keynm is 'キー項目物理名';
comment on column tm_eutableitemname.meisyonm is '名称項目物理名';
comment on column tm_eutableitemname.maincd is 'メインコード';
comment on column tm_eutableitemname.subcd is 'サブコード';
comment on column tm_eutableitemname.maincdnumflg is 'メインコード数値フラグ';

--EUCテーブル結合マスタ
drop table if exists tm_eutablejoin;
create table tm_eutablejoin(
    tablealias varchar(60) not null,
    kanrentablealias varchar(60) not null,
    ketugosql varchar(400) not null,
    jokenflg boolean not null default true,
    orderseq smallint,
primary key(tablealias,kanrentablealias)
);
comment on table tm_eutablejoin is 'EUCテーブル結合マスタ';
comment on column tm_eutablejoin.tablealias is 'テーブル別名';
comment on column tm_eutablejoin.kanrentablealias is '上位テーブル別名';
comment on column tm_eutablejoin.ketugosql is '結合SQL';
comment on column tm_eutablejoin.jokenflg is '条件フラグ';
comment on column tm_eutablejoin.orderseq is '並びシーケンス';

--EUCデータソースマスタ
drop table if exists tm_eudatasource;
create table tm_eudatasource(
    datasourceid varchar(4) not null,
    datasourcenm varchar(30) not null,
    gyoumucd varchar(3) not null,
    orderseq smallint not null default 0,
    maintablealias varchar(60) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(datasourceid)
);
comment on table tm_eudatasource is 'EUCデータソースマスタ';
comment on column tm_eudatasource.datasourceid is 'データソースID';
comment on column tm_eudatasource.datasourcenm is 'データソース名称';
comment on column tm_eudatasource.gyoumucd is '業務コード';
comment on column tm_eudatasource.orderseq is '並び順';
comment on column tm_eudatasource.maintablealias is 'メインテーブル別名';
comment on column tm_eudatasource.reguserid is '登録ユーザーID';
comment on column tm_eudatasource.regdttm is '登録日時';
comment on column tm_eudatasource.upduserid is '更新ユーザーID';
comment on column tm_eudatasource.upddttm is '更新日時';

--EUCデータソース結合マスタ
drop table if exists tm_eudatasourcejoin;
create table tm_eudatasourcejoin(
    datasourceid varchar(4) not null,
    tablealias varchar(60) not null,
    kanrentablealias varchar(60) not null,
    ketugosql varchar(400) not null,
    jokenflg boolean not null default true,
    orderseq smallint,
primary key(datasourceid,tablealias)
);
comment on table tm_eudatasourcejoin is 'EUCデータソース結合マスタ';
comment on column tm_eudatasourcejoin.datasourceid is 'データソースID';
comment on column tm_eudatasourcejoin.tablealias is 'テーブル別名';
comment on column tm_eudatasourcejoin.kanrentablealias is '上位テーブル別名';
comment on column tm_eudatasourcejoin.ketugosql is '結合SQL';
comment on column tm_eudatasourcejoin.jokenflg is '条件フラグ';
comment on column tm_eudatasourcejoin.orderseq is '並びシーケンス';

--EUCデータソース項目マスタ
drop table if exists tm_eudatasourceitem;
create table tm_eudatasourceitem(
    datasourceid varchar(4) not null,
    sqlcolumn varchar(200) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(datasourceid,sqlcolumn)
);
comment on table tm_eudatasourceitem is 'EUCデータソース項目マスタ';
comment on column tm_eudatasourceitem.datasourceid is 'データソースID';
comment on column tm_eudatasourceitem.sqlcolumn is 'SQLカラム';
comment on column tm_eudatasourceitem.reguserid is '登録ユーザーID';
comment on column tm_eudatasourceitem.regdttm is '登録日時';
comment on column tm_eudatasourceitem.upduserid is '更新ユーザーID';
comment on column tm_eudatasourceitem.upddttm is '更新日時';

--EUCデータソース検索マスタ
drop table if exists tm_eudatasourcekensaku;
create table tm_eudatasourcekensaku(
    datasourceid varchar(4) not null,
    jyokenid smallint not null,
    sqlcolumn varchar(200),
    jyokenkbn smallint not null,
    jyokenlabel varchar(50) not null,
    variables varchar(100),
    sql varchar(256) not null,
    tablealias varchar(180),
    controlkbn smallint not null,
    mastercd varchar(20),
    masterpara varchar(20),
    sansyomotosql varchar(256),
    datatype smallint not null,
    nendohanikbn varchar(1),
    syokiti varchar(20),
    aimaikbn varchar(1),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(datasourceid,jyokenid)
);
comment on table tm_eudatasourcekensaku is 'EUCデータソース検索マスタ';
comment on column tm_eudatasourcekensaku.datasourceid is 'データソースID';
comment on column tm_eudatasourcekensaku.jyokenid is '条件ID';
comment on column tm_eudatasourcekensaku.sqlcolumn is 'SQLカラム';
comment on column tm_eudatasourcekensaku.jyokenkbn is '検索条件区分';
comment on column tm_eudatasourcekensaku.jyokenlabel is 'ラベル';
comment on column tm_eudatasourcekensaku.variables is '変数名';
comment on column tm_eudatasourcekensaku.sql is 'SQL';
comment on column tm_eudatasourcekensaku.tablealias is 'テーブル別名';
comment on column tm_eudatasourcekensaku.controlkbn is 'コントロール区分';
comment on column tm_eudatasourcekensaku.mastercd is '名称マスタコード';
comment on column tm_eudatasourcekensaku.masterpara is '名称マスタパラメータ';
comment on column tm_eudatasourcekensaku.sansyomotosql is '参照元SQL';
comment on column tm_eudatasourcekensaku.datatype is 'データ型';
comment on column tm_eudatasourcekensaku.nendohanikbn is '年度範囲区分';
comment on column tm_eudatasourcekensaku.syokiti is '初期値';
comment on column tm_eudatasourcekensaku.aimaikbn is '曖昧検索区分';
comment on column tm_eudatasourcekensaku.reguserid is '登録ユーザーID';
comment on column tm_eudatasourcekensaku.regdttm is '登録日時';
comment on column tm_eudatasourcekensaku.upduserid is '更新ユーザーID';
comment on column tm_eudatasourcekensaku.upddttm is '更新日時';

--EUC帳票マスタ
drop table if exists tm_eurpt;
create table tm_eurpt(
    rptid varchar(4) not null,
    rptnm varchar(50) not null,
    rptgroupid varchar(5) not null,
    datasourceid varchar(4),
    tyusyutupanelflg boolean not null,
    yosikihimonm varchar(10),
    atenaflg boolean not null,
    ninsanputorokunoflg boolean not null,
    addresssealflg boolean not null,
    barcodesealflg boolean not null,
    hagakiflg boolean not null,
    atenadaityoflg boolean not null,
    kensuhyonenreiflg boolean not null,
    kensuhyogyoseikuflg boolean not null,
    sql text,
    procnm varchar(50),
    orderseq integer not null default 0,
    rptbiko varchar(500),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(rptid)
);
comment on table tm_eurpt is 'EUC帳票マスタ';
comment on column tm_eurpt.rptid is '帳票ID';
comment on column tm_eurpt.rptnm is '帳票名';
comment on column tm_eurpt.rptgroupid is '帳票グループID';
comment on column tm_eurpt.datasourceid is 'データソースID';
comment on column tm_eurpt.tyusyutupanelflg is '抽出パネル表示フラグ';
comment on column tm_eurpt.yosikihimonm is '様式紐付け名';
comment on column tm_eurpt.atenaflg is '宛名フラグ';
comment on column tm_eurpt.ninsanputorokunoflg is '妊産婦登録番号発行履歴設定フラグ';
comment on column tm_eurpt.addresssealflg is 'アドレスシールフラグ';
comment on column tm_eurpt.barcodesealflg is 'バーコードシール出力フラグ';
comment on column tm_eurpt.hagakiflg is 'はがき出力フラグ';
comment on column tm_eurpt.atenadaityoflg is '宛名台帳出力フラグ';
comment on column tm_eurpt.kensuhyonenreiflg is '件数表(年齢別)出力フラグ';
comment on column tm_eurpt.kensuhyogyoseikuflg is '件数表(行政区別)出力フラグ';
comment on column tm_eurpt.sql is 'SQL';
comment on column tm_eurpt.procnm is 'プロシージャ名';
comment on column tm_eurpt.orderseq is '並びシーケンス';
comment on column tm_eurpt.rptbiko is '帳票説明';
comment on column tm_eurpt.reguserid is '登録ユーザーID';
comment on column tm_eurpt.regdttm is '登録日時';
comment on column tm_eurpt.upduserid is '更新ユーザーID';
comment on column tm_eurpt.upddttm is '更新日時';

--EUC様式マスタ
drop table if exists tm_euyosiki;
create table tm_euyosiki(
    rptid varchar(4) not null,
    yosikiid varchar(4) not null,
    naigaikbn varchar(1) not null,
    hakoflg boolean,
    himozukejyokenid smallint,
    himozukevalue varchar(20),
    templatefilenm varchar(50),
    templatefiledata bytea,
    endrow smallint,
    endcol smallint,
    pagesize smallint,
    landscape boolean,
    koinnmflg boolean not null default false,
    koinpicflg boolean not null default false,
    dairisyaflg boolean not null default false,
    kacd varchar(10),
    kakaricd varchar(10),
    toiawasesakicd varchar(10),
    gyomuflg boolean not null default false,
    updateflg boolean not null default false,
    updatesql text not null,
    tutisyoflg boolean not null default false,
    pdfflg boolean not null default false,
    excelflg boolean not null default false,
    otherflg boolean not null default false,
    sortptnno smallint,
    outputptnno smallint,
    orderseq smallint not null default 0,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(rptid,yosikiid)
);
comment on table tm_euyosiki is 'EUC様式マスタ';
comment on column tm_euyosiki.rptid is '帳票ID';
comment on column tm_euyosiki.yosikiid is '様式ID';
comment on column tm_euyosiki.naigaikbn is '内外区分';
comment on column tm_euyosiki.hakoflg is '帳票発行履歴更新フラグ';
comment on column tm_euyosiki.himozukejyokenid is '様式紐付け条件ID';
comment on column tm_euyosiki.himozukevalue is '様式紐付け値';
comment on column tm_euyosiki.templatefilenm is 'テンプレートファイル名';
comment on column tm_euyosiki.templatefiledata is 'テンプレートファイル';
comment on column tm_euyosiki.endrow is 'テンプレート終了行';
comment on column tm_euyosiki.endcol is 'テンプレート終了列';
comment on column tm_euyosiki.pagesize is 'ページサイズ';
comment on column tm_euyosiki.landscape is '用紙の向き';
comment on column tm_euyosiki.koinnmflg is '市区町村印字フラグ';
comment on column tm_euyosiki.koinpicflg is '電子更新印字フラグ';
comment on column tm_euyosiki.dairisyaflg is '職務代理者適用フラグ';
comment on column tm_euyosiki.kacd is '課コード';
comment on column tm_euyosiki.kakaricd is '係コード';
comment on column tm_euyosiki.toiawasesakicd is '問い合わせ先コード';
comment on column tm_euyosiki.gyomuflg is '業務画面使用フラグ';
comment on column tm_euyosiki.updateflg is '更新フラグ';
comment on column tm_euyosiki.updatesql is '更新プロシージャ/SQL';
comment on column tm_euyosiki.tutisyoflg is '通知書出力フラグ';
comment on column tm_euyosiki.pdfflg is 'PDF出力フラグ';
comment on column tm_euyosiki.excelflg is 'EXCEL出力フラグ';
comment on column tm_euyosiki.otherflg is 'その他出力フラグ';
comment on column tm_euyosiki.sortptnno is '出力順パターン';
comment on column tm_euyosiki.outputptnno is 'CSV出力パターン';
comment on column tm_euyosiki.orderseq is '並び順';
comment on column tm_euyosiki.reguserid is '登録ユーザーID';
comment on column tm_euyosiki.regdttm is '登録日時';
comment on column tm_euyosiki.upduserid is '更新ユーザーID';
comment on column tm_euyosiki.upddttm is '更新日時';

--EUC様式詳細マスタ
drop table if exists tm_euyosikisyosai;
create table tm_euyosikisyosai(
    rptid varchar(4) not null,
    yosikiid varchar(4) not null,
    yosikieda smallint not null,
    yosikinm varchar(50) not null,
    yosikisyubetu varchar(1) not null,
    yosikikbn varchar(2) not null,
    meisaiflg boolean not null,
    meisaikoteikbn varchar(1),
    yosikihouhou varchar(1) not null,
    datasourceid varchar(4),
    himozukejyokenid smallint,
    distinctflg boolean not null,
    nulltozeroflg boolean not null default false,
    startrow smallint,
    loopmaxrow smallint,
    looprow smallint,
    startcol smallint,
    loopmaxcol smallint,
    loopcol smallint,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(rptid,yosikiid,yosikieda)
);
comment on table tm_euyosikisyosai is 'EUC様式詳細マスタ';
comment on column tm_euyosikisyosai.rptid is '帳票ID';
comment on column tm_euyosikisyosai.yosikiid is '様式ID';
comment on column tm_euyosikisyosai.yosikieda is '様式枝番';
comment on column tm_euyosikisyosai.yosikinm is '様式名';
comment on column tm_euyosikisyosai.yosikisyubetu is '様式種別';
comment on column tm_euyosikisyosai.yosikikbn is '様式種別詳細';
comment on column tm_euyosikisyosai.meisaiflg is '明細有無';
comment on column tm_euyosikisyosai.meisaikoteikbn is '行（列）固定区分';
comment on column tm_euyosikisyosai.yosikihouhou is '様式作成方法';
comment on column tm_euyosikisyosai.datasourceid is 'データソースID';
comment on column tm_euyosikisyosai.himozukejyokenid is '様式紐付け条件ID';
comment on column tm_euyosikisyosai.distinctflg is '重複データ排除フラグ';
comment on column tm_euyosikisyosai.nulltozeroflg is '空白値ゼロ出力フラグ';
comment on column tm_euyosikisyosai.startrow is 'テンプレート明細開始行';
comment on column tm_euyosikisyosai.loopmaxrow is '１ページあたりの最大行数';
comment on column tm_euyosikisyosai.looprow is '1明細あたりの行数';
comment on column tm_euyosikisyosai.startcol is '明細開始列数';
comment on column tm_euyosikisyosai.loopmaxcol is '１ページあたりの最大列数';
comment on column tm_euyosikisyosai.loopcol is '1明細あたりの列数';
comment on column tm_euyosikisyosai.reguserid is '登録ユーザーID';
comment on column tm_euyosikisyosai.regdttm is '登録日時';
comment on column tm_euyosikisyosai.upduserid is '更新ユーザーID';
comment on column tm_euyosikisyosai.upddttm is '更新日時';

--EUC帳票項目マスタ
drop table if exists tm_eurptitem;
create table tm_eurptitem(
    rptid varchar(4) not null,
    yosikiid varchar(4) not null,
    yosikieda smallint not null,
    yosikiitemid varchar(60) not null,
    reportitemnm varchar(50) not null,
    csvitemnm varchar(50) not null,
    sqlcolumn varchar(200),
    tablealias varchar(180) not null,
    orderkbn smallint not null default 0,
    orderkbnseq smallint default 0,
    orderseq smallint,
    reportoutputflg boolean not null default true,
    csvoutputflg boolean not null default true,
    headerflg boolean not null default true,
    kaipageflg boolean not null default true,
    itemkbn varchar(1) not null,
    formatkbn smallint,
    formatkbn2 varchar(20),
    formatsyosai varchar(50),
    height smallint,
    width smallint,
    offsetx smallint,
    offsety smallint,
    blankvalue varchar(100),
    mastercd varchar(20),
    masterpara varchar(20),
    keyvaluepairsjson text,
    crosskbn varchar(1),
    kbn1 varchar(1),
    level smallint,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(rptid,yosikiid,yosikieda,yosikiitemid)
);
comment on table tm_eurptitem is 'EUC帳票項目マスタ';
comment on column tm_eurptitem.rptid is '帳票ID';
comment on column tm_eurptitem.yosikiid is '様式ID';
comment on column tm_eurptitem.yosikieda is '様式枝番';
comment on column tm_eurptitem.yosikiitemid is '様式項目ID';
comment on column tm_eurptitem.reportitemnm is '帳票項目名称';
comment on column tm_eurptitem.csvitemnm is 'CSV項目名称';
comment on column tm_eurptitem.sqlcolumn is 'SQLカラム';
comment on column tm_eurptitem.tablealias is 'テーブル別名';
comment on column tm_eurptitem.orderkbn is '並び替え';
comment on column tm_eurptitem.orderkbnseq is '並び替えシーケンス';
comment on column tm_eurptitem.orderseq is '並びシーケンス';
comment on column tm_eurptitem.reportoutputflg is '帳票出力フラグ';
comment on column tm_eurptitem.csvoutputflg is 'CSV出力フラグ';
comment on column tm_eurptitem.headerflg is 'ヘッダーフラグ';
comment on column tm_eurptitem.kaipageflg is '改ページフラグ';
comment on column tm_eurptitem.itemkbn is '項目区分';
comment on column tm_eurptitem.formatkbn is 'フォーマット区分';
comment on column tm_eurptitem.formatkbn2 is 'フォーマット区分2';
comment on column tm_eurptitem.formatsyosai is 'フォーマット詳細';
comment on column tm_eurptitem.height is '高';
comment on column tm_eurptitem.width is '幅';
comment on column tm_eurptitem.offsetx is 'X軸オフセット';
comment on column tm_eurptitem.offsety is 'Y軸オフセット';
comment on column tm_eurptitem.blankvalue is '白紙表示';
comment on column tm_eurptitem.mastercd is '名称マスタコード';
comment on column tm_eurptitem.masterpara is '名称マスタパラメータ';
comment on column tm_eurptitem.keyvaluepairsjson is 'コード名称ラインアップ';
comment on column tm_eurptitem.crosskbn is '集計区分';
comment on column tm_eurptitem.kbn1 is '小計区分';
comment on column tm_eurptitem.level is '集計レベル';
comment on column tm_eurptitem.reguserid is '登録ユーザーID';
comment on column tm_eurptitem.regdttm is '登録日時';
comment on column tm_eurptitem.upduserid is '更新ユーザーID';
comment on column tm_eurptitem.upddttm is '更新日時';

--EUC帳票検索マスタ
drop table if exists tm_eurptkensaku;
create table tm_eurptkensaku(
    jyokenseq serial not null,
    rptid varchar(4) not null,
    datasourceid varchar(4),
    jyokenid smallint,
    jyokenkbn varchar(1),
    jyokenlabel varchar(50),
    variables varchar(100),
    sql varchar(256),
    tablealias varchar(180),
    controlkbn smallint,
    mastercd varchar(20),
    masterpara varchar(20),
    sansyomotosql varchar(256),
    hissuflg boolean default false,
    orderseq smallint,
    datatype smallint,
    nendohanikbn varchar(1),
    syokiti varchar(20),
    aimaikbn varchar(1),
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(jyokenseq)
);
comment on table tm_eurptkensaku is 'EUC帳票検索マスタ';
comment on column tm_eurptkensaku.jyokenseq is '条件シーケンス';
comment on column tm_eurptkensaku.rptid is '帳票ID';
comment on column tm_eurptkensaku.datasourceid is 'データソースID';
comment on column tm_eurptkensaku.jyokenid is '条件ID';
comment on column tm_eurptkensaku.jyokenkbn is '検索条件区分';
comment on column tm_eurptkensaku.jyokenlabel is 'ラベル';
comment on column tm_eurptkensaku.variables is '変数名';
comment on column tm_eurptkensaku.sql is 'SQL';
comment on column tm_eurptkensaku.tablealias is 'テーブル別名';
comment on column tm_eurptkensaku.controlkbn is 'コントロール区分';
comment on column tm_eurptkensaku.mastercd is '名称マスタコード';
comment on column tm_eurptkensaku.masterpara is '名称マスタパラメータ';
comment on column tm_eurptkensaku.sansyomotosql is '参照元SQL';
comment on column tm_eurptkensaku.hissuflg is '必須フラグ';
comment on column tm_eurptkensaku.orderseq is '並びシーケンス';
comment on column tm_eurptkensaku.datatype is 'データ型';
comment on column tm_eurptkensaku.nendohanikbn is '年度範囲区分';
comment on column tm_eurptkensaku.syokiti is '初期値';
comment on column tm_eurptkensaku.aimaikbn is '曖昧検索区分';
comment on column tm_eurptkensaku.reguserid is '登録ユーザーID';
comment on column tm_eurptkensaku.regdttm is '登録日時';
comment on column tm_eurptkensaku.upduserid is '更新ユーザーID';
comment on column tm_eurptkensaku.upddttm is '更新日時';

--EUC帳票検索詳細マスタ
drop table if exists tm_eurptkensakusyosai;
create table tm_eurptkensakusyosai(
    jyokenseq serial not null,
    rptid varchar(4) not null,
    yosikiid varchar(4) not null,
    yosikieda smallint not null,
    sql varchar(256) not null,
    tablealias varchar(180) not null,
    jyokenkbn varchar(1) not null,
    jyokenlabel varchar(50) not null,
    variables varchar(60) not null,
primary key(jyokenseq,rptid,yosikiid,yosikieda)
);
comment on table tm_eurptkensakusyosai is 'EUC帳票検索詳細マスタ';
comment on column tm_eurptkensakusyosai.jyokenseq is '条件シーケンス';
comment on column tm_eurptkensakusyosai.rptid is '帳票ID';
comment on column tm_eurptkensakusyosai.yosikiid is '様式ID';
comment on column tm_eurptkensakusyosai.yosikieda is '様式枝番';
comment on column tm_eurptkensakusyosai.sql is 'SQL';
comment on column tm_eurptkensakusyosai.tablealias is 'テーブル別名';
comment on column tm_eurptkensakusyosai.jyokenkbn is '条件区分';
comment on column tm_eurptkensakusyosai.jyokenlabel is 'ラベル';
comment on column tm_eurptkensakusyosai.variables is '変数';

--EUC帳票出力履歴テーブル
drop table if exists tt_eurireki;
create table tt_eurireki(
    rirekiseq bigserial not null,
    rptid varchar(4) not null,
    yosikiid varchar(4) not null,
    outputkbn smallint not null,
    memo varchar(200),
    jyotaikbn varchar(1) not null,
    num integer,
    syoridttmf timestamp not null,
    syoridttmt timestamp,
    milisec integer,
    filenm varchar(200) not null,
    filedata bytea,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(rirekiseq)
);
comment on table tt_eurireki is 'EUC帳票出力履歴テーブル';
comment on column tt_eurireki.rirekiseq is '履歴シーケンス';
comment on column tt_eurireki.rptid is '帳票ID';
comment on column tt_eurireki.yosikiid is '様式ID';
comment on column tt_eurireki.outputkbn is '出力方式';
comment on column tt_eurireki.memo is '検索条件メモ';
comment on column tt_eurireki.jyotaikbn is '状態区分';
comment on column tt_eurireki.num is '結果件数';
comment on column tt_eurireki.syoridttmf is '処理日時（開始）';
comment on column tt_eurireki.syoridttmt is '処理日時（終了）';
comment on column tt_eurireki.milisec is '処理時間';
comment on column tt_eurireki.filenm is 'ファイル名';
comment on column tt_eurireki.filedata is '結果ファイル';
comment on column tt_eurireki.reguserid is '登録ユーザーID';
comment on column tt_eurireki.regdttm is '登録日時';
comment on column tt_eurireki.upduserid is '更新ユーザーID';
comment on column tt_eurireki.upddttm is '更新日時';

--EUC帳票出力履歴条件テーブル
drop table if exists tt_eurirekijyoken;
create table tt_eurirekijyoken(
    rirekiseq bigint not null,
    jyokenseq int not null,
    jyokenlabel varchar(50) not null,
    value varchar(1000) not null,
primary key(rirekiseq,jyokenseq)
);
comment on table tt_eurirekijyoken is 'EUC帳票出力履歴条件テーブル';
comment on column tt_eurirekijyoken.rirekiseq is '履歴シーケンス';
comment on column tt_eurirekijyoken.jyokenseq is '条件シーケンス';
comment on column tt_eurirekijyoken.jyokenlabel is 'ラベル';
comment on column tt_eurirekijyoken.value is '値';

--帳票グループマスタ
drop table if exists tm_eurptgroup;
create table tm_eurptgroup(
    rptgroupid varchar(5) not null,
    rptgroupnm varchar(50) not null,
    gyomukbn varchar(3) not null,
    kojinrenrakusakicd varchar(6),
    memocd varchar,
    electronfilecd varchar,
    followmanage varchar,
    orderseq smallint not null default 0,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(rptgroupid)
);
comment on table tm_eurptgroup is '帳票グループマスタ';
comment on column tm_eurptgroup.rptgroupid is '帳票グループID';
comment on column tm_eurptgroup.rptgroupnm is '帳票グループ名';
comment on column tm_eurptgroup.gyomukbn is '業務区分';
comment on column tm_eurptgroup.kojinrenrakusakicd is '個人連絡先';
comment on column tm_eurptgroup.memocd is 'メモ情報（複数）';
comment on column tm_eurptgroup.electronfilecd is '電子ファイル（複数）';
comment on column tm_eurptgroup.followmanage is 'フォロー管理（複数）';
comment on column tm_eurptgroup.orderseq is '並び順';
comment on column tm_eurptgroup.reguserid is '登録ユーザーID';
comment on column tm_eurptgroup.regdttm is '登録日時';
comment on column tm_eurptgroup.upduserid is '更新ユーザーID';
comment on column tm_eurptgroup.upddttm is '更新日時';

--帳票テンプレートファイルマスタ
drop table if exists tm_eutemplatefile;
create table tm_eutemplatefile(
    siyokbn varchar(2) not null,
    filenm varchar(200) not null,
    filetype smallint not null,
    filedata bytea not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(siyokbn)
);
comment on table tm_eutemplatefile is '帳票テンプレートファイルマスタ';
comment on column tm_eutemplatefile.siyokbn is '使用区分';
comment on column tm_eutemplatefile.filenm is 'ファイル名';
comment on column tm_eutemplatefile.filetype is 'ファイルタイプ';
comment on column tm_eutemplatefile.filedata is 'ファイルデータ';
comment on column tm_eutemplatefile.reguserid is '登録ユーザーID';
comment on column tm_eutemplatefile.regdttm is '登録日時';
comment on column tm_eutemplatefile.upduserid is '更新ユーザーID';
comment on column tm_eutemplatefile.upddttm is '更新日時';

--公印マスタ
drop table if exists tm_eukoin;
create table tm_eukoin(
    koinid smallint not null default 0,
    sikutyosontyokoin bytea not null,
    dairisyakoin bytea not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(koinid)
);
comment on table tm_eukoin is '公印マスタ';
comment on column tm_eukoin.koinid is '公印ID';
comment on column tm_eukoin.sikutyosontyokoin is '市区町村長公印';
comment on column tm_eukoin.dairisyakoin is '職務代理者公印';
comment on column tm_eukoin.reguserid is '登録ユーザーID';
comment on column tm_eukoin.regdttm is '登録日時';
comment on column tm_eukoin.upduserid is '更新ユーザーID';
comment on column tm_eukoin.upddttm is '更新日時';

--出力順パターンテーブル
drop table if exists tt_eusort;
create table tt_eusort(
    rptid varchar(4) not null,
    yosikiid varchar(4) not null,
    sortptnno smallint not null,
    sortptnnm varchar(100) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(rptid,yosikiid,sortptnno)
);
comment on table tt_eusort is '出力順パターンテーブル';
comment on column tt_eusort.rptid is '帳票ID';
comment on column tt_eusort.yosikiid is '様式ID';
comment on column tt_eusort.sortptnno is '出力順パターン番号';
comment on column tt_eusort.sortptnnm is '出力順パターン名';
comment on column tt_eusort.reguserid is '登録ユーザーID';
comment on column tt_eusort.regdttm is '登録日時';
comment on column tt_eusort.upduserid is '更新ユーザーID';
comment on column tt_eusort.upddttm is '更新日時';

--出力順パターンサブテーブル
drop table if exists tt_eusort_sub;
create table tt_eusort_sub(
    rptid varchar(4) not null,
    yosikiid varchar(4) not null,
    sortptnno smallint not null,
    reportitemid varchar(60) not null,
    descflg boolean not null,
    pageflg boolean not null,
    orderseq smallint not null,
primary key(rptid,yosikiid,sortptnno,reportitemid)
);
comment on table tt_eusort_sub is '出力順パターンサブテーブル';
comment on column tt_eusort_sub.rptid is '帳票ID';
comment on column tt_eusort_sub.yosikiid is '様式ID';
comment on column tt_eusort_sub.sortptnno is '出力順パターン番号';
comment on column tt_eusort_sub.reportitemid is '帳票項目ID';
comment on column tt_eusort_sub.descflg is '降順フラグ';
comment on column tt_eusort_sub.pageflg is '改ページフラグ';
comment on column tt_eusort_sub.orderseq is '並びシーケンス';

--CSV出力パターンテーブル
drop table if exists tt_eucsv;
create table tt_eucsv(
    rptid varchar(4) not null,
    yosikiid varchar(4) not null,
    outputptnno smallint not null,
    outputptnnm varchar(100) not null,
    reguserid varchar(10) not null,
    regdttm timestamp not null,
    upduserid varchar(10) not null,
    upddttm timestamp not null,
primary key(rptid,yosikiid,outputptnno)
);
comment on table tt_eucsv is 'CSV出力パターンテーブル';
comment on column tt_eucsv.rptid is '帳票ID';
comment on column tt_eucsv.yosikiid is '様式ID';
comment on column tt_eucsv.outputptnno is '出力パターン番号';
comment on column tt_eucsv.outputptnnm is '出力パターン名';
comment on column tt_eucsv.reguserid is '登録ユーザーID';
comment on column tt_eucsv.regdttm is '登録日時';
comment on column tt_eucsv.upduserid is '更新ユーザーID';
comment on column tt_eucsv.upddttm is '更新日時';

--CSV出力パターンサブテーブル
drop table if exists tt_eucsv_sub;
create table tt_eucsv_sub(
    rptid varchar(4) not null,
    yosikiid varchar(4) not null,
    outputptnno smallint not null,
    reportitemid varchar(60) not null,
    orderseq smallint not null,
primary key(rptid,yosikiid,outputptnno,reportitemid)
);
comment on table tt_eucsv_sub is 'CSV出力パターンサブテーブル';
comment on column tt_eucsv_sub.rptid is '帳票ID';
comment on column tt_eucsv_sub.yosikiid is '様式ID';
comment on column tt_eucsv_sub.outputptnno is '出力パターン番号';
comment on column tt_eucsv_sub.reportitemid is '帳票項目ID';
comment on column tt_eucsv_sub.orderseq is '並びシーケンス';

--宛名ワークテーブル
drop table if exists wk_euatena;
create table wk_euatena(
    workseq bigserial not null,
    token varchar(50),
    jikoymd varchar(10),
    batflg boolean not null,
primary key(workseq)
);
comment on table wk_euatena is '宛名ワークテーブル';
comment on column wk_euatena.workseq is 'ワークシーケンス';
comment on column wk_euatena.token is 'トークン';
comment on column wk_euatena.jikoymd is '作成日';
comment on column wk_euatena.batflg is 'バッチフラグ';

--宛名ワークテーブルサブ
drop table if exists wk_euatena_sub;
create table wk_euatena_sub(
    workseq bigint not null,
    atenano varchar(15) not null,
    formflg boolean not null,
    taisyoflg boolean not null,
    taisyooutflg boolean not null,
primary key(workseq,atenano)
);
comment on table wk_euatena_sub is '宛名ワークテーブルサブ';
comment on column wk_euatena_sub.workseq is 'ワークシーケンス';
comment on column wk_euatena_sub.atenano is '宛名番号';
comment on column wk_euatena_sub.formflg is '出力フラグ';
comment on column wk_euatena_sub.taisyoflg is '対象外者フラグ';
comment on column wk_euatena_sub.taisyooutflg is '対象外出力可能フラグ';

--妊産婦ワークテーブル
drop table if exists wk_euninsanpu_sub;
create table wk_euninsanpu_sub(
    workseq bigint not null,
    atenano varchar(15) not null,
    torokuno bigint not null,
primary key(workseq,atenano,torokuno)
);
comment on table wk_euninsanpu_sub is '妊産婦ワークテーブル';
comment on column wk_euninsanpu_sub.workseq is 'ワークシーケンス';
comment on column wk_euninsanpu_sub.atenano is '宛名番号';
comment on column wk_euninsanpu_sub.torokuno is '登録番号';