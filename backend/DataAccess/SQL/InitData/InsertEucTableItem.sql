delete from tm_eutableitem;
--コントロールメインコード
INSERT INTO tm_eutableitem VALUES('tm_afctrl.ctrlmaincd','000_tm_afctrl_001','コントロールメインコード',NULL,1,3,True,1,'1','1','tm_afctrl',NULL,NULL,NULL,'コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コントロールサブコード
INSERT INTO tm_eutableitem VALUES('tm_afctrl.ctrlsubcd','000_tm_afctrl_002','コントロールサブコード',NULL,1,1,True,1,'1','1','tm_afctrl',NULL,NULL,NULL,'コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コントロールコード
INSERT INTO tm_eutableitem VALUES('tm_afctrl.ctrlcd','000_tm_afctrl_003','コントロールコード',NULL,1,3,True,1,'1','1','tm_afctrl',NULL,NULL,NULL,'コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目名称
INSERT INTO tm_eutableitem VALUES('tm_afctrl.itemnm','000_tm_afctrl_004','項目名称',NULL,1,3,True,1,'1','1','tm_afctrl',NULL,NULL,NULL,'コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--データ型コード
INSERT INTO tm_eutableitem VALUES('tm_afctrl.datatype','000_tm_afctrl_005','データ型コード',NULL,1,1,True,3,'1',NULL,'tm_afctrl',NULL,'111','1000,6','コントロールマスタ','データ型',NULL,'system','2023-01-01','system','2023-01-01');
--データ型名称
INSERT INTO tm_eutableitem VALUES('tm_afctrl_datatype_nm.nm','000_tm_afctrl_006','データ型名称',NULL,0,2,False,1,'1',NULL,'tm_afctrl_datatype_nm',NULL,NULL,NULL,'コントロールマスタ','データ型',NULL,'system','2023-01-01','system','2023-01-01');
--データ型CD:名称
INSERT INTO tm_eutableitem VALUES('tm_afctrl.datatype || '':'' || tm_afctrl_datatype_nm.nm','000_tm_afctrl_007','データ型CD:名称',NULL,0,2,False,1,'1',NULL,'tm_afctrl','tm_afctrl_datatype_nm',NULL,NULL,'コントロールマスタ','データ型',NULL,'system','2023-01-01','system','2023-01-01');
--範囲フラグ
INSERT INTO tm_eutableitem VALUES('tm_afctrl.rangeflg','000_tm_afctrl_008','範囲フラグ',NULL,1,6,True,1,'1','1','tm_afctrl',NULL,NULL,NULL,'コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--値１
INSERT INTO tm_eutableitem VALUES('tm_afctrl.value1','000_tm_afctrl_009','値１',NULL,1,3,True,1,'1','1','tm_afctrl',NULL,NULL,NULL,'コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--値２
INSERT INTO tm_eutableitem VALUES('tm_afctrl.value2','000_tm_afctrl_010','値２',NULL,1,3,True,1,'1','1','tm_afctrl',NULL,NULL,NULL,'コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--備考
INSERT INTO tm_eutableitem VALUES('tm_afctrl.biko','000_tm_afctrl_011','備考',NULL,1,3,True,1,'1','1','tm_afctrl',NULL,NULL,NULL,'コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afctrl.upduserid','000_tm_afctrl_012','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_afctrl',NULL,NULL,NULL,'コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_afctrl.upddttm','000_tm_afctrl_013','更新日時',NULL,1,4,False,1,'1','1','tm_afctrl',NULL,NULL,NULL,'コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コントロールメインコード
INSERT INTO tm_eutableitem VALUES('tm_afctrl_main.ctrlmaincd','000_tm_afctrl_main_001','コントロールメインコード',NULL,1,3,True,1,'1','1','tm_afctrl_main',NULL,NULL,NULL,'コントロールメインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コントロールサブコード
INSERT INTO tm_eutableitem VALUES('tm_afctrl_main.ctrlsubcd','000_tm_afctrl_main_002','コントロールサブコード',NULL,1,1,True,1,'1','1','tm_afctrl_main',NULL,NULL,NULL,'コントロールメインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コントロールサブコード名称
INSERT INTO tm_eutableitem VALUES('tm_afctrl_main.ctrlsubcdnm','000_tm_afctrl_main_003','コントロールサブコード名称',NULL,1,3,True,1,'1','1','tm_afctrl_main',NULL,NULL,NULL,'コントロールメインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--カナ名称
INSERT INTO tm_eutableitem VALUES('tm_afctrl_main.kananm','000_tm_afctrl_main_004','カナ名称',NULL,1,3,True,1,'1','1','tm_afctrl_main',NULL,NULL,NULL,'コントロールメインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--略称
INSERT INTO tm_eutableitem VALUES('tm_afctrl_main.shortnm','000_tm_afctrl_main_005','略称',NULL,1,3,True,1,'1','1','tm_afctrl_main',NULL,NULL,NULL,'コントロールメインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--備考
INSERT INTO tm_eutableitem VALUES('tm_afctrl_main.biko','000_tm_afctrl_main_006','備考',NULL,1,3,True,1,'1','1','tm_afctrl_main',NULL,NULL,NULL,'コントロールメインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--汎用メインコード
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.hanyomaincd','000_tm_afhanyo_001','汎用メインコード',NULL,1,3,True,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--汎用サブコード
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.hanyosubcd','000_tm_afhanyo_002','汎用サブコード',NULL,1,1,True,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--汎用コード
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.hanyocd','000_tm_afhanyo_003','汎用コード',NULL,1,3,True,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--名称
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.nm','000_tm_afhanyo_004','名称',NULL,1,3,True,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--カナ名称
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.kananm','000_tm_afhanyo_005','カナ名称',NULL,1,3,True,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--略称
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.shortnm','000_tm_afhanyo_006','略称',NULL,1,3,True,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--備考
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.biko','000_tm_afhanyo_007','備考',NULL,1,3,True,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--汎用区分1
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.hanyokbn1','000_tm_afhanyo_008','汎用区分1',NULL,1,3,True,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--汎用区分2
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.hanyokbn2','000_tm_afhanyo_009','汎用区分2',NULL,1,3,True,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--汎用区分3
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.hanyokbn3','000_tm_afhanyo_010','汎用区分3',NULL,1,3,True,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--使用停止フラグ
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.stopflg','000_tm_afhanyo_011','使用停止フラグ',NULL,1,6,True,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.reguserid','000_tm_afhanyo_012','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.regdttm','000_tm_afhanyo_013','登録日時',NULL,1,4,False,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.upduserid','000_tm_afhanyo_014','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_afhanyo.upddttm','000_tm_afhanyo_015','更新日時',NULL,1,4,False,1,'1','1','tm_afhanyo',NULL,NULL,NULL,'汎用マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--汎用メインコード
INSERT INTO tm_eutableitem VALUES('tm_afhanyo_main.hanyomaincd','000_tm_afhanyo_main_001','汎用メインコード',NULL,1,3,True,1,'1','1','tm_afhanyo_main',NULL,NULL,NULL,'汎用メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--汎用サブコード
INSERT INTO tm_eutableitem VALUES('tm_afhanyo_main.hanyosubcd','000_tm_afhanyo_main_002','汎用サブコード',NULL,1,1,True,1,'1','1','tm_afhanyo_main',NULL,NULL,NULL,'汎用メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--汎用サブコード名称
INSERT INTO tm_eutableitem VALUES('tm_afhanyo_main.hanyosubcdnm','000_tm_afhanyo_main_003','汎用サブコード名称',NULL,1,3,True,1,'1','1','tm_afhanyo_main',NULL,NULL,NULL,'汎用メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--カナ名称
INSERT INTO tm_eutableitem VALUES('tm_afhanyo_main.kananm','000_tm_afhanyo_main_004','カナ名称',NULL,1,3,True,1,'1','1','tm_afhanyo_main',NULL,NULL,NULL,'汎用メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--略称
INSERT INTO tm_eutableitem VALUES('tm_afhanyo_main.shortnm','000_tm_afhanyo_main_005','略称',NULL,1,3,True,1,'1','1','tm_afhanyo_main',NULL,NULL,NULL,'汎用メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--桁数
INSERT INTO tm_eutableitem VALUES('tm_afhanyo_main.keta','000_tm_afhanyo_main_006','桁数',NULL,1,1,True,1,'1','1','tm_afhanyo_main',NULL,NULL,NULL,'汎用メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--INSERT可能フラグ
INSERT INTO tm_eutableitem VALUES('tm_afhanyo_main.iflg','000_tm_afhanyo_main_007','INSERT可能フラグ',NULL,1,6,True,1,'1','1','tm_afhanyo_main',NULL,NULL,NULL,'汎用メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--UPDATE可能フラグ
INSERT INTO tm_eutableitem VALUES('tm_afhanyo_main.uflg','000_tm_afhanyo_main_008','UPDATE可能フラグ',NULL,1,6,True,1,'1','1','tm_afhanyo_main',NULL,NULL,NULL,'汎用メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--DELETE可能フラグ
INSERT INTO tm_eutableitem VALUES('tm_afhanyo_main.dflg','000_tm_afhanyo_main_009','DELETE可能フラグ',NULL,1,6,True,1,'1','1','tm_afhanyo_main',NULL,NULL,NULL,'汎用メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--備考
INSERT INTO tm_eutableitem VALUES('tm_afhanyo_main.biko','000_tm_afhanyo_main_010','備考',NULL,1,3,True,1,'1','1','tm_afhanyo_main',NULL,NULL,NULL,'汎用メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ドキュメントシーケンス
INSERT INTO tm_eutableitem VALUES('tm_afhelpdoc.docseq','000_tm_afhelpdoc_001','ドキュメントシーケンス',NULL,1,1,True,1,'1','1','tm_afhelpdoc',NULL,NULL,NULL,'ヘルプドキュメントマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--機能ID
INSERT INTO tm_eutableitem VALUES('tm_afhelpdoc.kinoid','000_tm_afhelpdoc_002','機能ID',NULL,1,3,True,1,'1','1','tm_afhelpdoc',NULL,NULL,NULL,'ヘルプドキュメントマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ファイル名
INSERT INTO tm_eutableitem VALUES('tm_afhelpdoc.filenm','000_tm_afhelpdoc_003','ファイル名',NULL,1,3,True,1,'1','1','tm_afhelpdoc',NULL,NULL,NULL,'ヘルプドキュメントマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプコード
INSERT INTO tm_eutableitem VALUES('tm_afhelpdoc.filetype','000_tm_afhelpdoc_004','ファイルタイプコード',NULL,1,1,True,3,'1',NULL,'tm_afhelpdoc',NULL,'111','1000,10','ヘルプドキュメントマスタ','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプ名称
INSERT INTO tm_eutableitem VALUES('tm_afhelpdoc_filetype_nm.nm','000_tm_afhelpdoc_005','ファイルタイプ名称',NULL,0,2,False,1,'1',NULL,'tm_afhelpdoc_filetype_nm',NULL,NULL,NULL,'ヘルプドキュメントマスタ','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプCD:名称
INSERT INTO tm_eutableitem VALUES('tm_afhelpdoc.filetype || '':'' || tm_afhelpdoc_filetype_nm.nm','000_tm_afhelpdoc_006','ファイルタイプCD:名称',NULL,0,2,False,1,'1',NULL,'tm_afhelpdoc','tm_afhelpdoc_filetype_nm',NULL,NULL,'ヘルプドキュメントマスタ','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルサイズ
INSERT INTO tm_eutableitem VALUES('tm_afhelpdoc.filesize','000_tm_afhelpdoc_007','ファイルサイズ',NULL,1,1,True,1,'1','1','tm_afhelpdoc',NULL,NULL,NULL,'ヘルプドキュメントマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ファイルデータ
INSERT INTO tm_eutableitem VALUES('tm_afhelpdoc.filedata','000_tm_afhelpdoc_008','ファイルデータ',NULL,1,7,True,1,'1','1','tm_afhelpdoc',NULL,NULL,NULL,'ヘルプドキュメントマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--会場コード
INSERT INTO tm_eutableitem VALUES('tm_afkaijo.kaijocd','000_tm_afkaijo_001','会場コード',NULL,1,3,True,1,'1','1','tm_afkaijo',NULL,NULL,NULL,'会場情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--会場名
INSERT INTO tm_eutableitem VALUES('tm_afkaijo.kaijonm','000_tm_afkaijo_002','会場名',NULL,1,3,True,1,'1','1','tm_afkaijo',NULL,NULL,NULL,'会場情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--会場名（カナ）
INSERT INTO tm_eutableitem VALUES('tm_afkaijo.kanakaijonm','000_tm_afkaijo_003','会場名（カナ）',NULL,1,3,True,1,'1','1','tm_afkaijo',NULL,NULL,NULL,'会場情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住所
INSERT INTO tm_eutableitem VALUES('tm_afkaijo.adrs','000_tm_afkaijo_004','住所',NULL,1,3,True,1,'1','1','tm_afkaijo',NULL,NULL,NULL,'会場情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--方書
INSERT INTO tm_eutableitem VALUES('tm_afkaijo.katagaki','000_tm_afkaijo_005','方書',NULL,1,3,True,1,'1','1','tm_afkaijo',NULL,NULL,NULL,'会場情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--会場連絡先
INSERT INTO tm_eutableitem VALUES('tm_afkaijo.kaijorenrakusaki','000_tm_afkaijo_006','会場連絡先',NULL,1,3,True,1,'1','1','tm_afkaijo',NULL,NULL,NULL,'会場情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--行政区
INSERT INTO tm_eutableitem VALUES('tm_afkaijo.gyoseikucd','000_tm_afkaijo_007','行政区',NULL,1,3,True,1,'1','1','tm_afkaijo',NULL,NULL,NULL,'会場情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--使用停止フラグ
INSERT INTO tm_eutableitem VALUES('tm_afkaijo.stopflg','000_tm_afkaijo_008','使用停止フラグ',NULL,1,6,True,1,'1','1','tm_afkaijo',NULL,NULL,NULL,'会場情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afkaijo.reguserid','000_tm_afkaijo_009','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_afkaijo',NULL,NULL,NULL,'会場情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_afkaijo.regdttm','000_tm_afkaijo_010','登録日時',NULL,1,4,False,1,'1','1','tm_afkaijo',NULL,NULL,NULL,'会場情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afkaijo.upduserid','000_tm_afkaijo_011','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_afkaijo',NULL,NULL,NULL,'会場情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_afkaijo.upddttm','000_tm_afkaijo_012','更新日時',NULL,1,4,False,1,'1','1','tm_afkaijo',NULL,NULL,NULL,'会場情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--会場コード
INSERT INTO tm_eutableitem VALUES('tm_afkaijo_sub.kaijocd','000_tm_afkaijo_sub_001','会場コード',NULL,1,3,True,1,'1','1','tm_afkaijo_sub',NULL,NULL,NULL,'会場情報サブマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--地区区分コード
INSERT INTO tm_eutableitem VALUES('tm_afkaijo_sub.tikukbn','000_tm_afkaijo_sub_002','地区区分コード',NULL,1,3,True,3,'1',NULL,'tm_afkaijo_sub',NULL,'111','1001,37','会場情報サブマスタ','地区区分',NULL,'system','2023-01-01','system','2023-01-01');
--地区区分名称
INSERT INTO tm_eutableitem VALUES('tm_afkaijo_sub_tikukbn_nm.nm','000_tm_afkaijo_sub_003','地区区分名称',NULL,0,2,False,1,'1',NULL,'tm_afkaijo_sub_tikukbn_nm',NULL,NULL,NULL,'会場情報サブマスタ','地区区分',NULL,'system','2023-01-01','system','2023-01-01');
--地区区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_afkaijo_sub.tikukbn || '':'' || tm_afkaijo_sub_tikukbn_nm.nm','000_tm_afkaijo_sub_004','地区区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_afkaijo_sub','tm_afkaijo_sub_tikukbn_nm',NULL,NULL,'会場情報サブマスタ','地区区分',NULL,'system','2023-01-01','system','2023-01-01');
--地区コード
INSERT INTO tm_eutableitem VALUES('tm_afkaijo_sub.tikucd','000_tm_afkaijo_sub_005','地区コード',NULL,1,3,True,1,'1','1','tm_afkaijo_sub',NULL,NULL,NULL,'会場情報サブマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--医療機関コード（自治体独自）
INSERT INTO tm_eutableitem VALUES('tm_afkikan.kikancd','000_tm_afkikan_001','医療機関コード（自治体独自）',NULL,1,3,True,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--保険医療機関コード
INSERT INTO tm_eutableitem VALUES('tm_afkikan.hokenkikancd','000_tm_afkikan_002','保険医療機関コード',NULL,1,3,True,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--医療機関名カナ
INSERT INTO tm_eutableitem VALUES('tm_afkikan.kanakikannm','000_tm_afkikan_003','医療機関名カナ',NULL,1,3,True,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--医療機関名
INSERT INTO tm_eutableitem VALUES('tm_afkikan.kikannm','000_tm_afkikan_004','医療機関名',NULL,1,3,True,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--郵便番号
INSERT INTO tm_eutableitem VALUES('tm_afkikan.yubin','000_tm_afkikan_005','郵便番号',NULL,1,3,True,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住所
INSERT INTO tm_eutableitem VALUES('tm_afkikan.adrs','000_tm_afkikan_006','住所',NULL,1,3,True,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--方書
INSERT INTO tm_eutableitem VALUES('tm_afkikan.katagaki','000_tm_afkikan_007','方書',NULL,1,3,True,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--電話番号
INSERT INTO tm_eutableitem VALUES('tm_afkikan.tel','000_tm_afkikan_008','電話番号',NULL,1,3,True,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--FAX番号
INSERT INTO tm_eutableitem VALUES('tm_afkikan.fax','000_tm_afkikan_009','FAX番号',NULL,1,3,True,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--所属医師会コード
INSERT INTO tm_eutableitem VALUES('tm_afkikan.syozokuisikai','000_tm_afkikan_010','所属医師会コード',NULL,1,3,True,3,'1',NULL,'tm_afkikan',NULL,'121','1000,37','医療機関マスタ','所属医師会',NULL,'system','2023-01-01','system','2023-01-01');
--所属医師会名称
INSERT INTO tm_eutableitem VALUES('tm_afkikan_syozokuisikai_nm.nm','000_tm_afkikan_011','所属医師会名称',NULL,0,2,False,1,'1',NULL,'tm_afkikan_syozokuisikai_nm',NULL,NULL,NULL,'医療機関マスタ','所属医師会',NULL,'system','2023-01-01','system','2023-01-01');
--所属医師会CD:名称
INSERT INTO tm_eutableitem VALUES('tm_afkikan.syozokuisikai || '':'' || tm_afkikan_syozokuisikai_nm.nm','000_tm_afkikan_012','所属医師会CD:名称',NULL,0,2,False,1,'1',NULL,'tm_afkikan','tm_afkikan_syozokuisikai_nm',NULL,NULL,'医療機関マスタ','所属医師会',NULL,'system','2023-01-01','system','2023-01-01');
--使用停止フラグ
INSERT INTO tm_eutableitem VALUES('tm_afkikan.stopflg','000_tm_afkikan_013','使用停止フラグ',NULL,1,6,True,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afkikan.reguserid','000_tm_afkikan_014','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_afkikan.regdttm','000_tm_afkikan_015','登録日時',NULL,1,4,False,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afkikan.upduserid','000_tm_afkikan_016','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_afkikan.upddttm','000_tm_afkikan_017','更新日時',NULL,1,4,False,1,'1','1','tm_afkikan',NULL,NULL,NULL,'医療機関マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--医療機関コード（自治体独自）
INSERT INTO tm_eutableitem VALUES('tm_afkikan_sub.kikancd','000_tm_afkikan_sub_001','医療機関コード（自治体独自）',NULL,1,3,True,1,'1','1','tm_afkikan_sub',NULL,NULL,NULL,'医療機関サブマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--医療機関・事業従事者（担当者）事業コード
INSERT INTO tm_eutableitem VALUES('tm_afkikan_sub.jissijigyo','000_tm_afkikan_sub_002','医療機関・事業従事者（担当者）事業コード',NULL,1,3,True,3,'1',NULL,'tm_afkikan_sub',NULL,'121','3019,100003','医療機関サブマスタ','医療機関・事業従事者（担当者）事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--医療機関・事業従事者（担当者）事業名称
INSERT INTO tm_eutableitem VALUES('tm_afkikan_sub_jissijigyo_nm.nm','000_tm_afkikan_sub_003','医療機関・事業従事者（担当者）事業名称',NULL,0,2,False,1,'1',NULL,'tm_afkikan_sub_jissijigyo_nm',NULL,NULL,NULL,'医療機関サブマスタ','医療機関・事業従事者（担当者）事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--医療機関・事業従事者（担当者）事業CD:名称
INSERT INTO tm_eutableitem VALUES('tm_afkikan_sub.jissijigyo || '':'' || tm_afkikan_sub_jissijigyo_nm.nm','000_tm_afkikan_sub_004','医療機関・事業従事者（担当者）事業CD:名称',NULL,0,2,False,1,'1',NULL,'tm_afkikan_sub','tm_afkikan_sub_jissijigyo_nm',NULL,NULL,'医療機関サブマスタ','医療機関・事業従事者（担当者）事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--名称メインコード
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo.nmmaincd','000_tm_afmeisyo_001','名称メインコード',NULL,1,3,True,1,'1','1','tm_afmeisyo',NULL,NULL,NULL,'名称マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--名称サブコード
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo.nmsubcd','000_tm_afmeisyo_002','名称サブコード',NULL,1,1,True,1,'1','1','tm_afmeisyo',NULL,NULL,NULL,'名称マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--名称コード
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo.nmcd','000_tm_afmeisyo_003','名称コード',NULL,1,3,True,1,'1','1','tm_afmeisyo',NULL,NULL,NULL,'名称マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--名称
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo.nm','000_tm_afmeisyo_004','名称',NULL,1,3,True,1,'1','1','tm_afmeisyo',NULL,NULL,NULL,'名称マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--カナ名称
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo.kananm','000_tm_afmeisyo_005','カナ名称',NULL,1,3,True,1,'1','1','tm_afmeisyo',NULL,NULL,NULL,'名称マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--略称
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo.shortnm','000_tm_afmeisyo_006','略称',NULL,1,3,True,1,'1','1','tm_afmeisyo',NULL,NULL,NULL,'名称マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--備考
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo.biko','000_tm_afmeisyo_007','備考',NULL,1,3,True,1,'1','1','tm_afmeisyo',NULL,NULL,NULL,'名称マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--汎用区分1
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo.hanyokbn1','000_tm_afmeisyo_008','汎用区分1',NULL,1,3,True,1,'1','1','tm_afmeisyo',NULL,NULL,NULL,'名称マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--汎用区分2
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo.hanyokbn2','000_tm_afmeisyo_009','汎用区分2',NULL,1,3,True,1,'1','1','tm_afmeisyo',NULL,NULL,NULL,'名称マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--汎用区分3
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo.hanyokbn3','000_tm_afmeisyo_010','汎用区分3',NULL,1,3,True,1,'1','1','tm_afmeisyo',NULL,NULL,NULL,'名称マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--名称メインコード
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo_main.nmmaincd','000_tm_afmeisyo_main_001','名称メインコード',NULL,1,3,True,1,'1','1','tm_afmeisyo_main',NULL,NULL,NULL,'名称メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--名称サブコード
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo_main.nmsubcd','000_tm_afmeisyo_main_002','名称サブコード',NULL,1,1,True,1,'1','1','tm_afmeisyo_main',NULL,NULL,NULL,'名称メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--名称サブコード名称
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo_main.nmsubcdnm','000_tm_afmeisyo_main_003','名称サブコード名称',NULL,1,3,True,1,'1','1','tm_afmeisyo_main',NULL,NULL,NULL,'名称メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--カナ名称
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo_main.kananm','000_tm_afmeisyo_main_004','カナ名称',NULL,1,3,True,1,'1','1','tm_afmeisyo_main',NULL,NULL,NULL,'名称メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--略称
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo_main.shortnm','000_tm_afmeisyo_main_005','略称',NULL,1,3,True,1,'1','1','tm_afmeisyo_main',NULL,NULL,NULL,'名称メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--桁数
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo_main.keta','000_tm_afmeisyo_main_006','桁数',NULL,1,1,True,1,'1','1','tm_afmeisyo_main',NULL,NULL,NULL,'名称メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--備考
INSERT INTO tm_eutableitem VALUES('tm_afmeisyo_main.biko','000_tm_afmeisyo_main_007','備考',NULL,1,3,True,1,'1','1','tm_afmeisyo_main',NULL,NULL,NULL,'名称メインマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--機能ID
INSERT INTO tm_eutableitem VALUES('tm_afmenu.kinoid','000_tm_afmenu_001','機能ID',NULL,1,3,True,1,'1','1','tm_afmenu',NULL,NULL,NULL,'メニューマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--親メニューIDコード
INSERT INTO tm_eutableitem VALUES('tm_afmenu.oyamenuid','000_tm_afmenu_002','親メニューIDコード',NULL,1,3,True,3,'1',NULL,'tm_afmenu',NULL,'111','1000,1','メニューマスタ','親メニューID',NULL,'system','2023-01-01','system','2023-01-01');
--親メニューID名称
INSERT INTO tm_eutableitem VALUES('tm_afmenu_oyamenuid_nm.nm','000_tm_afmenu_003','親メニューID名称',NULL,0,2,False,1,'1',NULL,'tm_afmenu_oyamenuid_nm',NULL,NULL,NULL,'メニューマスタ','親メニューID',NULL,'system','2023-01-01','system','2023-01-01');
--親メニューIDCD:名称
INSERT INTO tm_eutableitem VALUES('tm_afmenu.oyamenuid || '':'' || tm_afmenu_oyamenuid_nm.nm','000_tm_afmenu_004','親メニューIDCD:名称',NULL,0,2,False,1,'1',NULL,'tm_afmenu','tm_afmenu_oyamenuid_nm',NULL,NULL,'メニューマスタ','親メニューID',NULL,'system','2023-01-01','system','2023-01-01');
--並びシーケンス
INSERT INTO tm_eutableitem VALUES('tm_afmenu.orderseq','000_tm_afmenu_005','並びシーケンス',NULL,1,1,True,1,'1','1','tm_afmenu',NULL,NULL,NULL,'メニューマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--検索パラメーター継承フラグ
INSERT INTO tm_eutableitem VALUES('tm_afmenu.paramkeisyoflg','000_tm_afmenu_006','検索パラメーター継承フラグ',NULL,1,6,True,1,'1','1','tm_afmenu',NULL,NULL,NULL,'メニューマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--追加権限制御フラグ
INSERT INTO tm_eutableitem VALUES('tm_afmenu.addctrlflg','000_tm_afmenu_007','追加権限制御フラグ',NULL,1,6,True,1,'1','1','tm_afmenu',NULL,NULL,NULL,'メニューマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--修正権限制御フラグ
INSERT INTO tm_eutableitem VALUES('tm_afmenu.updctrlflg','000_tm_afmenu_008','修正権限制御フラグ',NULL,1,6,True,1,'1','1','tm_afmenu',NULL,NULL,NULL,'メニューマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--削除権限制御フラグ
INSERT INTO tm_eutableitem VALUES('tm_afmenu.delctrlflg','000_tm_afmenu_009','削除権限制御フラグ',NULL,1,6,True,1,'1','1','tm_afmenu',NULL,NULL,NULL,'メニューマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人番号利用権限制御フラグ
INSERT INTO tm_eutableitem VALUES('tm_afmenu.pnousectrlflg','000_tm_afmenu_010','個人番号利用権限制御フラグ',NULL,1,6,True,1,'1','1','tm_afmenu',NULL,NULL,NULL,'メニューマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--機能ID
INSERT INTO tm_eutableitem VALUES('tm_afkino.kinoid','000_tm_afkino_001','機能ID',NULL,1,3,True,1,'1','1','tm_afkino',NULL,NULL,NULL,'機能マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--表示名称
INSERT INTO tm_eutableitem VALUES('tm_afkino.hyojinm','000_tm_afkino_002','表示名称',NULL,1,3,True,1,'1','1','tm_afkino',NULL,NULL,NULL,'機能マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--プログラムID（共用）
INSERT INTO tm_eutableitem VALUES('tm_afkino.programid','000_tm_afkino_003','プログラムID（共用）',NULL,1,3,True,1,'1','1','tm_afkino',NULL,NULL,NULL,'機能マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--汎用区分
INSERT INTO tm_eutableitem VALUES('tm_afkino.hanyokbn','000_tm_afkino_004','汎用区分',NULL,1,3,True,1,'1','1','tm_afkino',NULL,NULL,NULL,'機能マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コントロールメッセージID
INSERT INTO tm_eutableitem VALUES('tm_afmsgctrl.ctrlmsgid','000_tm_afmsgctrl_001','コントロールメッセージID',NULL,1,3,True,1,'1','1','tm_afmsgctrl',NULL,NULL,NULL,'メッセージコントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コントロールメッセージ名
INSERT INTO tm_eutableitem VALUES('tm_afmsgctrl.ctrlmsgnm','000_tm_afmsgctrl_002','コントロールメッセージ名',NULL,1,3,True,1,'1','1','tm_afmsgctrl',NULL,NULL,NULL,'メッセージコントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ区分コード
INSERT INTO tm_eutableitem VALUES('tm_afmsgctrl.msgkbn','000_tm_afmsgctrl_003','メッセージ区分コード',NULL,1,1,True,3,'1',NULL,'tm_afmsgctrl',NULL,'111','1000,9','メッセージコントロールマスタ','メッセージ区分',NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ区分名称
INSERT INTO tm_eutableitem VALUES('tm_afmsgctrl_msgkbn_nm.nm','000_tm_afmsgctrl_004','メッセージ区分名称',NULL,0,2,False,1,'1',NULL,'tm_afmsgctrl_msgkbn_nm',NULL,NULL,NULL,'メッセージコントロールマスタ','メッセージ区分',NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_afmsgctrl.msgkbn || '':'' || tm_afmsgctrl_msgkbn_nm.nm','000_tm_afmsgctrl_005','メッセージ区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_afmsgctrl','tm_afmsgctrl_msgkbn_nm',NULL,NULL,'メッセージコントロールマスタ','メッセージ区分',NULL,'system','2023-01-01','system','2023-01-01');
--エラーメッセージID
INSERT INTO tm_eutableitem VALUES('tm_afmsgctrl.errormsgid','000_tm_afmsgctrl_006','エラーメッセージID',NULL,1,3,True,1,'1','1','tm_afmsgctrl',NULL,NULL,NULL,'メッセージコントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--アラートメッセージID
INSERT INTO tm_eutableitem VALUES('tm_afmsgctrl.alertmsgid','000_tm_afmsgctrl_007','アラートメッセージID',NULL,1,3,True,1,'1','1','tm_afmsgctrl',NULL,NULL,NULL,'メッセージコントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--備考
INSERT INTO tm_eutableitem VALUES('tm_afmsgctrl.biko','000_tm_afmsgctrl_008','備考',NULL,1,3,True,1,'1','1','tm_afmsgctrl',NULL,NULL,NULL,'メッセージコントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--事業コード
INSERT INTO tm_eutableitem VALUES('tm_afnendo.jigyocd','000_tm_afnendo_001','事業コード',NULL,1,3,True,1,'1','1','tm_afnendo',NULL,NULL,NULL,'年度マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--年度
INSERT INTO tm_eutableitem VALUES('tm_afnendo.nendo','000_tm_afnendo_002','年度',NULL,1,1,True,1,'1','1','tm_afnendo',NULL,NULL,NULL,'年度マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tm_afnendo.edano','000_tm_afnendo_003','枝番',NULL,1,1,True,1,'1','1','tm_afnendo',NULL,NULL,NULL,'年度マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--性別
INSERT INTO tm_eutableitem VALUES('tm_afnendo.sex','000_tm_afnendo_004','性別',NULL,1,3,True,1,'1','1','tm_afnendo',NULL,NULL,NULL,'年度マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--年齢計算基準日
INSERT INTO tm_eutableitem VALUES('tm_afnendo.kijunymd','000_tm_afnendo_005','年齢計算基準日',NULL,1,3,True,1,'1','1','tm_afnendo',NULL,NULL,NULL,'年度マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afnendo.reguserid','000_tm_afnendo_006','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_afnendo',NULL,NULL,NULL,'年度マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_afnendo.regdttm','000_tm_afnendo_007','登録日時',NULL,1,4,False,1,'1','1','tm_afnendo',NULL,NULL,NULL,'年度マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afnendo.upduserid','000_tm_afnendo_008','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_afnendo',NULL,NULL,NULL,'年度マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_afnendo.upddttm','000_tm_afnendo_009','更新日時',NULL,1,4,False,1,'1','1','tm_afnendo',NULL,NULL,NULL,'年度マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--市区町村コード
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.sikucd','000_tm_afsikutyoson_001','市区町村コード',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--都道府県名
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.todofukennm','000_tm_afsikutyoson_002','都道府県名',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--都道府県名_カナ
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.todofukennm_kana','000_tm_afsikutyoson_003','都道府県名_カナ',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ','都道府県名''',NULL,'system','2023-01-01','system','2023-01-01');
--都道府県名_英字
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.todofukennm_eiji','000_tm_afsikutyoson_004','都道府県名_英字',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ','都道府県名''',NULL,'system','2023-01-01','system','2023-01-01');
--郡名
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.gunnm','000_tm_afsikutyoson_005','郡名',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--郡名_カナ
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.gunnm_kana','000_tm_afsikutyoson_006','郡名_カナ',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ','郡名''',NULL,'system','2023-01-01','system','2023-01-01');
--郡名_英字
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.gunnm_eiji','000_tm_afsikutyoson_007','郡名_英字',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ','郡名''',NULL,'system','2023-01-01','system','2023-01-01');
--市区町村名
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.sikunm','000_tm_afsikutyoson_008','市区町村名',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--市区町村名_カナ
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.sikunm_kana','000_tm_afsikutyoson_009','市区町村名_カナ',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ','市区町村名''',NULL,'system','2023-01-01','system','2023-01-01');
--市区町村名_英字
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.sikunm_eiji','000_tm_afsikutyoson_010','市区町村名_英字',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ','市区町村名''',NULL,'system','2023-01-01','system','2023-01-01');
--政令市区名
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.seireisikunm','000_tm_afsikutyoson_011','政令市区名',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--政令市区名_カナ
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.seireisikunm_kana','000_tm_afsikutyoson_012','政令市区名_カナ',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ','政令市区名''',NULL,'system','2023-01-01','system','2023-01-01');
--政令市区名_英字
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.seireisikunm_eiji','000_tm_afsikutyoson_013','政令市区名_英字',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ','政令市区名''',NULL,'system','2023-01-01','system','2023-01-01');
--効力発生日
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.koryokuhasseiymd','000_tm_afsikutyoson_014','効力発生日',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--廃止日
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.haisiymd','000_tm_afsikutyoson_015','廃止日',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--備考
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.biko','000_tm_afsikutyoson_016','備考',NULL,1,3,True,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.reguserid','000_tm_afsikutyoson_017','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.regdttm','000_tm_afsikutyoson_018','登録日時',NULL,1,4,False,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.upduserid','000_tm_afsikutyoson_019','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_afsikutyoson.upddttm','000_tm_afsikutyoson_020','更新日時',NULL,1,4,False,1,'1','1','tm_afsikutyoson',NULL,NULL,NULL,'市区町村マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--事業従事者ID
INSERT INTO tm_eutableitem VALUES('tm_afstaff.staffid','000_tm_afstaff_001','事業従事者ID',NULL,1,3,True,1,'1','1','tm_afstaff',NULL,NULL,NULL,'事業従事者（担当者）情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--事業従事者氏名
INSERT INTO tm_eutableitem VALUES('tm_afstaff.staffsimei','000_tm_afstaff_002','事業従事者氏名',NULL,1,3,True,1,'1','1','tm_afstaff',NULL,NULL,NULL,'事業従事者（担当者）情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--事業従事者カナ氏名
INSERT INTO tm_eutableitem VALUES('tm_afstaff.kanastaffsimei','000_tm_afstaff_003','事業従事者カナ氏名',NULL,1,3,True,1,'1','1','tm_afstaff',NULL,NULL,NULL,'事業従事者（担当者）情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--職種コード
INSERT INTO tm_eutableitem VALUES('tm_afstaff.syokusyu','000_tm_afstaff_004','職種コード',NULL,1,3,True,3,'1',NULL,'tm_afstaff',NULL,'111','2019,2','事業従事者（担当者）情報マスタ','職種',NULL,'system','2023-01-01','system','2023-01-01');
--職種名称
INSERT INTO tm_eutableitem VALUES('tm_afstaff_syokusyu_nm.nm','000_tm_afstaff_005','職種名称',NULL,0,2,False,1,'1',NULL,'tm_afstaff_syokusyu_nm',NULL,NULL,NULL,'事業従事者（担当者）情報マスタ','職種',NULL,'system','2023-01-01','system','2023-01-01');
--職種CD:名称
INSERT INTO tm_eutableitem VALUES('tm_afstaff.syokusyu || '':'' || tm_afstaff_syokusyu_nm.nm','000_tm_afstaff_006','職種CD:名称',NULL,0,2,False,1,'1',NULL,'tm_afstaff','tm_afstaff_syokusyu_nm',NULL,NULL,'事業従事者（担当者）情報マスタ','職種',NULL,'system','2023-01-01','system','2023-01-01');
--活動区分コード
INSERT INTO tm_eutableitem VALUES('tm_afstaff.katudokbn','000_tm_afstaff_007','活動区分コード',NULL,1,3,True,3,'1',NULL,'tm_afstaff',NULL,'111','2019,3','事業従事者（担当者）情報マスタ','活動区分',NULL,'system','2023-01-01','system','2023-01-01');
--活動区分名称
INSERT INTO tm_eutableitem VALUES('tm_afstaff_katudokbn_nm.nm','000_tm_afstaff_008','活動区分名称',NULL,0,2,False,1,'1',NULL,'tm_afstaff_katudokbn_nm',NULL,NULL,NULL,'事業従事者（担当者）情報マスタ','活動区分',NULL,'system','2023-01-01','system','2023-01-01');
--活動区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_afstaff.katudokbn || '':'' || tm_afstaff_katudokbn_nm.nm','000_tm_afstaff_009','活動区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_afstaff','tm_afstaff_katudokbn_nm',NULL,NULL,'事業従事者（担当者）情報マスタ','活動区分',NULL,'system','2023-01-01','system','2023-01-01');
--使用停止フラグ
INSERT INTO tm_eutableitem VALUES('tm_afstaff.stopflg','000_tm_afstaff_010','使用停止フラグ',NULL,1,6,True,1,'1','1','tm_afstaff',NULL,NULL,NULL,'事業従事者（担当者）情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afstaff.reguserid','000_tm_afstaff_011','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_afstaff',NULL,NULL,NULL,'事業従事者（担当者）情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_afstaff.regdttm','000_tm_afstaff_012','登録日時',NULL,1,4,False,1,'1','1','tm_afstaff',NULL,NULL,NULL,'事業従事者（担当者）情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afstaff.upduserid','000_tm_afstaff_013','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_afstaff',NULL,NULL,NULL,'事業従事者（担当者）情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_afstaff.upddttm','000_tm_afstaff_014','更新日時',NULL,1,4,False,1,'1','1','tm_afstaff',NULL,NULL,NULL,'事業従事者（担当者）情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--事業従事者ID
INSERT INTO tm_eutableitem VALUES('tm_afstaff_kikan.staffid','000_tm_afstaff_kikan_001','事業従事者ID',NULL,1,3,True,1,'1','1','tm_afstaff_kikan',NULL,NULL,NULL,'事業従事者（担当者）所属機関',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--医療機関コード（自治体独自）
INSERT INTO tm_eutableitem VALUES('tm_afstaff_kikan.kikancd','000_tm_afstaff_kikan_002','医療機関コード（自治体独自）',NULL,1,3,True,1,'1','1','tm_afstaff_kikan',NULL,NULL,NULL,'事業従事者（担当者）所属機関',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--事業従事者ID
INSERT INTO tm_eutableitem VALUES('tm_afstaff_sub.staffid','000_tm_afstaff_sub_001','事業従事者ID',NULL,1,3,True,1,'1','1','tm_afstaff_sub',NULL,NULL,NULL,'事業従事者（担当者）サブマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--医療機関・事業従事者（担当者）事業コード
INSERT INTO tm_eutableitem VALUES('tm_afstaff_sub.jissijigyo','000_tm_afstaff_sub_002','医療機関・事業従事者（担当者）事業コード',NULL,1,3,True,3,'1',NULL,'tm_afstaff_sub',NULL,'121','3019,100003','事業従事者（担当者）サブマスタ','医療機関・事業従事者（担当者）事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--医療機関・事業従事者（担当者）事業名称
INSERT INTO tm_eutableitem VALUES('tm_afstaff_sub_jissijigyo_nm.nm','000_tm_afstaff_sub_003','医療機関・事業従事者（担当者）事業名称',NULL,0,2,False,1,'1',NULL,'tm_afstaff_sub_jissijigyo_nm',NULL,NULL,NULL,'事業従事者（担当者）サブマスタ','医療機関・事業従事者（担当者）事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--医療機関・事業従事者（担当者）事業CD:名称
INSERT INTO tm_eutableitem VALUES('tm_afstaff_sub.jissijigyo || '':'' || tm_afstaff_sub_jissijigyo_nm.nm','000_tm_afstaff_sub_004','医療機関・事業従事者（担当者）事業CD:名称',NULL,0,2,False,1,'1',NULL,'tm_afstaff_sub','tm_afstaff_sub_jissijigyo_nm',NULL,NULL,'事業従事者（担当者）サブマスタ','医療機関・事業従事者（担当者）事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--所属グループコード
INSERT INTO tm_eutableitem VALUES('tm_afsyozoku.syozokucd','000_tm_afsyozoku_001','所属グループコード',NULL,1,3,True,1,'1','1','tm_afsyozoku',NULL,NULL,NULL,'所属グループマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--所属グループ名
INSERT INTO tm_eutableitem VALUES('tm_afsyozoku.syozokunm','000_tm_afsyozoku_002','所属グループ名',NULL,1,3,True,1,'1','1','tm_afsyozoku',NULL,NULL,NULL,'所属グループマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--管理者フラグ
INSERT INTO tm_eutableitem VALUES('tm_afsyozoku.kanrisyaflg','000_tm_afsyozoku_003','管理者フラグ',NULL,1,6,True,1,'1','1','tm_afsyozoku',NULL,NULL,NULL,'所属グループマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人番号操作権限付与フラグ
INSERT INTO tm_eutableitem VALUES('tm_afsyozoku.pnoeditflg','000_tm_afsyozoku_004','個人番号操作権限付与フラグ',NULL,1,6,True,1,'1','1','tm_afsyozoku',NULL,NULL,NULL,'所属グループマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--警告参照区分
INSERT INTO tm_eutableitem VALUES('tm_afsyozoku.alertviewflg','000_tm_afsyozoku_005','警告参照区分',NULL,1,6,True,1,'1','1','tm_afsyozoku',NULL,NULL,NULL,'所属グループマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--使用停止フラグ
INSERT INTO tm_eutableitem VALUES('tm_afsyozoku.stopflg','000_tm_afsyozoku_006','使用停止フラグ',NULL,1,6,True,1,'1','1','tm_afsyozoku',NULL,NULL,NULL,'所属グループマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afsyozoku.reguserid','000_tm_afsyozoku_007','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_afsyozoku',NULL,NULL,NULL,'所属グループマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_afsyozoku.regdttm','000_tm_afsyozoku_008','登録日時',NULL,1,4,False,1,'1','1','tm_afsyozoku',NULL,NULL,NULL,'所属グループマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afsyozoku.upduserid','000_tm_afsyozoku_009','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_afsyozoku',NULL,NULL,NULL,'所属グループマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_afsyozoku.upddttm','000_tm_afsyozoku_010','更新日時',NULL,1,4,False,1,'1','1','tm_afsyozoku',NULL,NULL,NULL,'所属グループマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--地区区分コード
INSERT INTO tm_eutableitem VALUES('tm_aftiku.tikukbn','000_tm_aftiku_001','地区区分コード',NULL,1,1,True,3,'1',NULL,'tm_aftiku',NULL,'111','1001,37','地区情報マスタ','地区区分',NULL,'system','2023-01-01','system','2023-01-01');
--地区区分名称
INSERT INTO tm_eutableitem VALUES('tm_aftiku_tikukbn_nm.nm','000_tm_aftiku_002','地区区分名称',NULL,0,2,False,1,'1',NULL,'tm_aftiku_tikukbn_nm',NULL,NULL,NULL,'地区情報マスタ','地区区分',NULL,'system','2023-01-01','system','2023-01-01');
--地区区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_aftiku.tikukbn || '':'' || tm_aftiku_tikukbn_nm.nm','000_tm_aftiku_003','地区区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_aftiku','tm_aftiku_tikukbn_nm',NULL,NULL,'地区情報マスタ','地区区分',NULL,'system','2023-01-01','system','2023-01-01');
--地区コード
INSERT INTO tm_eutableitem VALUES('tm_aftiku.tikucd','000_tm_aftiku_004','地区コード',NULL,1,3,True,1,'1','1','tm_aftiku',NULL,NULL,NULL,'地区情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--地区名
INSERT INTO tm_eutableitem VALUES('tm_aftiku.tikunm','000_tm_aftiku_005','地区名',NULL,1,3,True,1,'1','1','tm_aftiku',NULL,NULL,NULL,'地区情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--地区名（カナ）
INSERT INTO tm_eutableitem VALUES('tm_aftiku.kanatikunm','000_tm_aftiku_006','地区名（カナ）',NULL,1,3,True,1,'1','1','tm_aftiku',NULL,NULL,NULL,'地区情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--使用停止フラグ
INSERT INTO tm_eutableitem VALUES('tm_aftiku.stopflg','000_tm_aftiku_007','使用停止フラグ',NULL,1,6,True,1,'1','1','tm_aftiku',NULL,NULL,NULL,'地区情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_aftiku.reguserid','000_tm_aftiku_008','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_aftiku',NULL,NULL,NULL,'地区情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_aftiku.regdttm','000_tm_aftiku_009','登録日時',NULL,1,4,False,1,'1','1','tm_aftiku',NULL,NULL,NULL,'地区情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_aftiku.upduserid','000_tm_aftiku_010','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_aftiku',NULL,NULL,NULL,'地区情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_aftiku.upddttm','000_tm_aftiku_011','更新日時',NULL,1,4,False,1,'1','1','tm_aftiku',NULL,NULL,NULL,'地区情報マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--地区区分コード
INSERT INTO tm_eutableitem VALUES('tm_aftiku_sub.tikukbn','000_tm_aftiku_sub_001','地区区分コード',NULL,1,1,True,3,'1',NULL,'tm_aftiku_sub',NULL,'111','1001,37','地区情報サブマスタ','地区区分',NULL,'system','2023-01-01','system','2023-01-01');
--地区区分名称
INSERT INTO tm_eutableitem VALUES('tm_aftiku_sub_tikukbn_nm.nm','000_tm_aftiku_sub_002','地区区分名称',NULL,0,2,False,1,'1',NULL,'tm_aftiku_sub_tikukbn_nm',NULL,NULL,NULL,'地区情報サブマスタ','地区区分',NULL,'system','2023-01-01','system','2023-01-01');
--地区区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_aftiku_sub.tikukbn || '':'' || tm_aftiku_sub_tikukbn_nm.nm','000_tm_aftiku_sub_003','地区区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_aftiku_sub','tm_aftiku_sub_tikukbn_nm',NULL,NULL,'地区情報サブマスタ','地区区分',NULL,'system','2023-01-01','system','2023-01-01');
--地区コード
INSERT INTO tm_eutableitem VALUES('tm_aftiku_sub.tikucd','000_tm_aftiku_sub_004','地区コード',NULL,1,3,True,1,'1','1','tm_aftiku_sub',NULL,NULL,NULL,'地区情報サブマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--地区担当者
INSERT INTO tm_eutableitem VALUES('tm_aftiku_sub.staffid','000_tm_aftiku_sub_005','地区担当者',NULL,1,3,True,1,'1','1','tm_aftiku_sub',NULL,NULL,NULL,'地区情報サブマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--市区町村コード
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.sikucd','000_tm_aftyoaza_001','市区町村コード',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--町字ID
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.tyoazaid','000_tm_aftyoaza_002','町字ID',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--町字区分コード
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.tyoazakbn','000_tm_aftyoaza_003','町字区分コード',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--大字・町名
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.oazatyonm','000_tm_aftyoaza_004','大字・町名',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--大字・町名_カナ
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.oazatyonm_kana','000_tm_aftyoaza_005','大字・町名_カナ',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ','大字・町名''',NULL,'system','2023-01-01','system','2023-01-01');
--大字・町名_英字
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.oazatyonm_eiji','000_tm_aftyoaza_006','大字・町名_英字',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ','大字・町名''',NULL,'system','2023-01-01','system','2023-01-01');
--丁目名
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.tyomeinm','000_tm_aftyoaza_007','丁目名',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--丁目名_カナ
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.tyomeinm_kana','000_tm_aftyoaza_008','丁目名_カナ',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ','丁目名''',NULL,'system','2023-01-01','system','2023-01-01');
--丁目名_数字
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.tyomeinm_suji','000_tm_aftyoaza_009','丁目名_数字',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ','丁目名''',NULL,'system','2023-01-01','system','2023-01-01');
--小字名
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.koazanm','000_tm_aftyoaza_010','小字名',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--小字名_カナ
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.koazanm_kana','000_tm_aftyoaza_011','小字名_カナ',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ','小字名''',NULL,'system','2023-01-01','system','2023-01-01');
--小字名_英字
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.koazanm_eiji','000_tm_aftyoaza_012','小字名_英字',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ','小字名''',NULL,'system','2023-01-01','system','2023-01-01');
--住居表示フラグ
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.jukyoflg','000_tm_aftyoaza_013','住居表示フラグ',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住居表示方式コード
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.jukyocd','000_tm_aftyoaza_014','住居表示方式コード',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--大字・町_通称フラグ
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.oazatyo_tusyoflg','000_tm_aftyoaza_015','大字・町_通称フラグ',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ','大字・町''',NULL,'system','2023-01-01','system','2023-01-01');
--小字_通称フラグ
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.koaza_tusyoflg','000_tm_aftyoaza_016','小字_通称フラグ',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ','小字''',NULL,'system','2023-01-01','system','2023-01-01');
--大字・町_外字フラグ
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.oazatyo_gaijiflg','000_tm_aftyoaza_017','大字・町_外字フラグ',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ','大字・町''',NULL,'system','2023-01-01','system','2023-01-01');
--小字_外字フラグ
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.koaza_gaijiflg','000_tm_aftyoaza_018','小字_外字フラグ',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ','小字''',NULL,'system','2023-01-01','system','2023-01-01');
--状態フラグ
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.statusflg','000_tm_aftyoaza_019','状態フラグ',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--起番フラグ
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.kibanflg','000_tm_aftyoaza_020','起番フラグ',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--効力発生日
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.koryokuhasseiymd','000_tm_aftyoaza_021','効力発生日',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--廃止日
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.haisiymd','000_tm_aftyoaza_022','廃止日',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--原典資料コード
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.siryocd','000_tm_aftyoaza_023','原典資料コード',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--郵便番号
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.yubin','000_tm_aftyoaza_024','郵便番号',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--備考
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.biko','000_tm_aftyoaza_025','備考',NULL,1,3,True,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.reguserid','000_tm_aftyoaza_026','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.regdttm','000_tm_aftyoaza_027','登録日時',NULL,1,4,False,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.upduserid','000_tm_aftyoaza_028','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_aftyoaza.upddttm','000_tm_aftyoaza_029','更新日時',NULL,1,4,False,1,'1','1','tm_aftyoaza',NULL,NULL,NULL,'町字マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afuser.userid','000_tm_afuser_001','ユーザーID',NULL,1,3,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--パスワード
INSERT INTO tm_eutableitem VALUES('tm_afuser.pword','000_tm_afuser_002','パスワード',NULL,1,3,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ユーザー名
INSERT INTO tm_eutableitem VALUES('tm_afuser.usernm','000_tm_afuser_003','ユーザー名',NULL,1,3,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--所属グループコード
INSERT INTO tm_eutableitem VALUES('tm_afuser.syozokucd','000_tm_afuser_004','所属グループコード',NULL,1,3,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ログインエラー回数
INSERT INTO tm_eutableitem VALUES('tm_afuser.errorkaisu','000_tm_afuser_005','ログインエラー回数',NULL,1,1,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--有効年月日（開始）
INSERT INTO tm_eutableitem VALUES('tm_afuser.yukoymdf','000_tm_afuser_006','有効年月日（開始）',NULL,1,3,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--有効年月日（終了）
INSERT INTO tm_eutableitem VALUES('tm_afuser.yukoymdt','000_tm_afuser_007','有効年月日（終了）',NULL,1,3,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--パスワード変更年月日
INSERT INTO tm_eutableitem VALUES('tm_afuser.pwordhenkoymd','000_tm_afuser_008','パスワード変更年月日',NULL,1,3,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--管理者フラグ
INSERT INTO tm_eutableitem VALUES('tm_afuser.kanrisyaflg','000_tm_afuser_009','管理者フラグ',NULL,1,6,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人番号操作権限付与フラグ
INSERT INTO tm_eutableitem VALUES('tm_afuser.pnoeditflg','000_tm_afuser_010','個人番号操作権限付与フラグ',NULL,1,6,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--警告参照フラグ
INSERT INTO tm_eutableitem VALUES('tm_afuser.alertviewflg','000_tm_afuser_011','警告参照フラグ',NULL,1,6,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--権限設定フラグ
INSERT INTO tm_eutableitem VALUES('tm_afuser.authsetflg','000_tm_afuser_012','権限設定フラグ',NULL,1,6,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--管理者継承フラグ
INSERT INTO tm_eutableitem VALUES('tm_afuser.kanrisyakeisyoflg','000_tm_afuser_013','管理者継承フラグ',NULL,1,6,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人番号操作権限付与継承フラグ
INSERT INTO tm_eutableitem VALUES('tm_afuser.pnoeditkeisyoflg','000_tm_afuser_014','個人番号操作権限付与継承フラグ',NULL,1,6,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--警告参照継承フラグ
INSERT INTO tm_eutableitem VALUES('tm_afuser.alertviewkeisyoflg','000_tm_afuser_015','警告参照継承フラグ',NULL,1,6,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--部署（支所）別更新権限継承フラグ
INSERT INTO tm_eutableitem VALUES('tm_afuser.authsisyokeisyoflg','000_tm_afuser_016','部署（支所）別更新権限継承フラグ',NULL,1,6,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--使用停止フラグ
INSERT INTO tm_eutableitem VALUES('tm_afuser.stopflg','000_tm_afuser_017','使用停止フラグ',NULL,1,6,True,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afuser.reguserid','000_tm_afuser_018','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_afuser.regdttm','000_tm_afuser_019','登録日時',NULL,1,4,False,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_afuser.upduserid','000_tm_afuser_020','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_afuser.upddttm','000_tm_afuser_021','更新日時',NULL,1,4,False,1,'1','1','tm_afuser',NULL,NULL,NULL,'ユーザーマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afatena.atenano','000_tt_afatena_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--世帯番号
INSERT INTO tm_eutableitem VALUES('tt_afatena.setaino','000_tt_afatena_002','世帯番号',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住登区分コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.jutokbn','000_tt_afatena_003','住登区分コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','1000,29','宛名テーブル','住登区分',NULL,'system','2023-01-01','system','2023-01-01');
--住登区分名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_jutokbn_nm.nm','000_tt_afatena_004','住登区分名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_jutokbn_nm',NULL,NULL,NULL,'宛名テーブル','住登区分',NULL,'system','2023-01-01','system','2023-01-01');
--住登区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.jutokbn || '':'' || tt_afatena_jutokbn_nm.nm','000_tt_afatena_005','住登区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_jutokbn_nm',NULL,NULL,'宛名テーブル','住登区分',NULL,'system','2023-01-01','system','2023-01-01');
--住民種別コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.juminsyubetu','000_tt_afatena_006','住民種別コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','2001,4','宛名テーブル','住民種別',NULL,'system','2023-01-01','system','2023-01-01');
--住民種別名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_juminsyubetu_nm.nm','000_tt_afatena_007','住民種別名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_juminsyubetu_nm',NULL,NULL,NULL,'宛名テーブル','住民種別',NULL,'system','2023-01-01','system','2023-01-01');
--住民種別CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.juminsyubetu || '':'' || tt_afatena_juminsyubetu_nm.nm','000_tt_afatena_008','住民種別CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_juminsyubetu_nm',NULL,NULL,'宛名テーブル','住民種別',NULL,'system','2023-01-01','system','2023-01-01');
--住民状態コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.juminjotai','000_tt_afatena_009','住民状態コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','2001,5','宛名テーブル','住民状態',NULL,'system','2023-01-01','system','2023-01-01');
--住民状態名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_juminjotai_nm.nm','000_tt_afatena_010','住民状態名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_juminjotai_nm',NULL,NULL,NULL,'宛名テーブル','住民状態',NULL,'system','2023-01-01','system','2023-01-01');
--住民状態CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.juminjotai || '':'' || tt_afatena_juminjotai_nm.nm','000_tt_afatena_011','住民状態CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_juminjotai_nm',NULL,NULL,'宛名テーブル','住民状態',NULL,'system','2023-01-01','system','2023-01-01');
--住民区分コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.juminkbn','000_tt_afatena_012','住民区分コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','1000,41','宛名テーブル','住民区分',NULL,'system','2023-01-01','system','2023-01-01');
--住民区分名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_juminkbn_nm.nm','000_tt_afatena_013','住民区分名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_juminkbn_nm',NULL,NULL,NULL,'宛名テーブル','住民区分',NULL,'system','2023-01-01','system','2023-01-01');
--住民区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.juminkbn || '':'' || tt_afatena_juminkbn_nm.nm','000_tt_afatena_014','住民区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_juminkbn_nm',NULL,NULL,'宛名テーブル','住民区分',NULL,'system','2023-01-01','system','2023-01-01');
--氏名
INSERT INTO tm_eutableitem VALUES('tt_afatena.simei','000_tt_afatena_015','氏名',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--氏名_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afatena.simei_kana','000_tt_afatena_016','氏名_フリガナ',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_フリガナ_清音化
INSERT INTO tm_eutableitem VALUES('tt_afatena.simei_kana_seion','000_tt_afatena_017','氏名_フリガナ_清音化',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル','氏名_フリガナ''',NULL,'system','2023-01-01','system','2023-01-01');
--通称
INSERT INTO tm_eutableitem VALUES('tt_afatena.tusyo','000_tt_afatena_018','通称',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--通称_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afatena.tusyo_kana','000_tt_afatena_019','通称_フリガナ',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル','通称''',NULL,'system','2023-01-01','system','2023-01-01');
--通称_フリガナ_清音化
INSERT INTO tm_eutableitem VALUES('tt_afatena.tusyo_kana_seion','000_tt_afatena_020','通称_フリガナ_清音化',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル','通称_フリガナ''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_優先
INSERT INTO tm_eutableitem VALUES('tt_afatena.simei_yusen','000_tt_afatena_021','氏名_優先',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_フリガナ_優先
INSERT INTO tm_eutableitem VALUES('tt_afatena.simei_kana_yusen','000_tt_afatena_022','氏名_フリガナ_優先',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル','氏名_フリガナ''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_フリガナ_優先_清音化
INSERT INTO tm_eutableitem VALUES('tt_afatena.simei_kana_yusen_seion','000_tt_afatena_023','氏名_フリガナ_優先_清音化',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル','氏名_フリガナ_優先''',NULL,'system','2023-01-01','system','2023-01-01');
--性別コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.sex','000_tt_afatena_024','性別コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','2001,1','宛名テーブル','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_sex_nm.nm','000_tt_afatena_025','性別名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_sex_nm',NULL,NULL,NULL,'宛名テーブル','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.sex || '':'' || tt_afatena_sex_nm.nm','000_tt_afatena_026','性別CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_sex_nm',NULL,NULL,'宛名テーブル','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別表記
INSERT INTO tm_eutableitem VALUES('tt_afatena.sexhyoki','000_tt_afatena_027','性別表記',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--生年月日
INSERT INTO tm_eutableitem VALUES('tt_afatena.bymd','000_tt_afatena_028','生年月日',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--生年月日_不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_afatena.bymd_fusyoflg','000_tt_afatena_029','生年月日_不詳フラグ',NULL,1,6,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル','生年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--生年月日_不詳表記
INSERT INTO tm_eutableitem VALUES('tt_afatena.bymd_fusyohyoki','000_tt_afatena_030','生年月日_不詳表記',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル','生年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--続柄1コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.zokucd1','000_tt_afatena_031','続柄1コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','2001,18','宛名テーブル','続柄コード1',NULL,'system','2023-01-01','system','2023-01-01');
--続柄1名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_zokucd1_nm.nm','000_tt_afatena_032','続柄1名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_zokucd1_nm',NULL,NULL,NULL,'宛名テーブル','続柄コード1',NULL,'system','2023-01-01','system','2023-01-01');
--続柄1CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.zokucd1 || '':'' || tt_afatena_zokucd1_nm.nm','000_tt_afatena_033','続柄1CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_zokucd1_nm',NULL,NULL,'宛名テーブル','続柄コード1',NULL,'system','2023-01-01','system','2023-01-01');
--続柄2コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.zokucd2','000_tt_afatena_034','続柄2コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','2001,18','宛名テーブル','続柄コード2',NULL,'system','2023-01-01','system','2023-01-01');
--続柄2名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_zokucd2_nm.nm','000_tt_afatena_035','続柄2名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_zokucd2_nm',NULL,NULL,NULL,'宛名テーブル','続柄コード2',NULL,'system','2023-01-01','system','2023-01-01');
--続柄2CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.zokucd2 || '':'' || tt_afatena_zokucd2_nm.nm','000_tt_afatena_036','続柄2CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_zokucd2_nm',NULL,NULL,'宛名テーブル','続柄コード2',NULL,'system','2023-01-01','system','2023-01-01');
--続柄3コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.zokucd3','000_tt_afatena_037','続柄3コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','2001,18','宛名テーブル','続柄コード3',NULL,'system','2023-01-01','system','2023-01-01');
--続柄3名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_zokucd3_nm.nm','000_tt_afatena_038','続柄3名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_zokucd3_nm',NULL,NULL,NULL,'宛名テーブル','続柄コード3',NULL,'system','2023-01-01','system','2023-01-01');
--続柄3CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.zokucd3 || '':'' || tt_afatena_zokucd3_nm.nm','000_tt_afatena_039','続柄3CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_zokucd3_nm',NULL,NULL,'宛名テーブル','続柄コード3',NULL,'system','2023-01-01','system','2023-01-01');
--続柄4コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.zokucd4','000_tt_afatena_040','続柄4コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','2001,18','宛名テーブル','続柄コード4',NULL,'system','2023-01-01','system','2023-01-01');
--続柄4名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_zokucd4_nm.nm','000_tt_afatena_041','続柄4名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_zokucd4_nm',NULL,NULL,NULL,'宛名テーブル','続柄コード4',NULL,'system','2023-01-01','system','2023-01-01');
--続柄4CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.zokucd4 || '':'' || tt_afatena_zokucd4_nm.nm','000_tt_afatena_042','続柄4CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_zokucd4_nm',NULL,NULL,'宛名テーブル','続柄コード4',NULL,'system','2023-01-01','system','2023-01-01');
--続柄表記
INSERT INTO tm_eutableitem VALUES('tt_afatena.zokuhyoki','000_tt_afatena_043','続柄表記',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住所_市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.adrs_sikucd','000_tt_afatena_044','住所_市区町村コード',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_町字コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.adrs_tyoazacd','000_tt_afatena_045','住所_町字コード',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.tosi_gyoseikucd','000_tt_afatena_046','指定都市_行政区等コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','3019,100004','宛名テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_tosi_gyoseikucd_nm.nm','000_tt_afatena_047','指定都市_行政区等名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_tosi_gyoseikucd_nm',NULL,NULL,NULL,'宛名テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.tosi_gyoseikucd || '':'' || tt_afatena_tosi_gyoseikucd_nm.nm','000_tt_afatena_048','指定都市_行政区等CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_tosi_gyoseikucd_nm',NULL,NULL,'宛名テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--住所1
INSERT INTO tm_eutableitem VALUES('tt_afatena.adrs1','000_tt_afatena_049','住所1',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住所2
INSERT INTO tm_eutableitem VALUES('tt_afatena.adrs2','000_tt_afatena_050','住所2',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住所_方書コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.adrs_katagakicd','000_tt_afatena_051','住所_方書コード',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_郵便番号
INSERT INTO tm_eutableitem VALUES('tt_afatena.adrs_yubin','000_tt_afatena_052','住所_郵便番号',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理1コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd1','000_tt_afatena_053','地区管理1コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'251','1','宛名テーブル','地区管理コード1',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理1名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_tikukanricd1_tikunm.tikunm','000_tt_afatena_054','地区管理1名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_tikukanricd1_tikunm',NULL,NULL,NULL,'宛名テーブル','地区管理コード1',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理1CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd1 || '':'' || tt_afatena_tikukanricd1_tikunm.tikunm','000_tt_afatena_055','地区管理1CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_tikukanricd1_tikunm',NULL,NULL,'宛名テーブル','地区管理コード1',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理2コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd2','000_tt_afatena_056','地区管理2コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'251','2','宛名テーブル','地区管理コード2',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理2名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_tikukanricd2_tikunm.tikunm','000_tt_afatena_057','地区管理2名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_tikukanricd2_tikunm',NULL,NULL,NULL,'宛名テーブル','地区管理コード2',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理2CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd2 || '':'' || tt_afatena_tikukanricd2_tikunm.tikunm','000_tt_afatena_058','地区管理2CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_tikukanricd2_tikunm',NULL,NULL,'宛名テーブル','地区管理コード2',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理3コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd3','000_tt_afatena_059','地区管理3コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'251','3','宛名テーブル','地区管理コード3',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理3名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_tikukanricd3_tikunm.tikunm','000_tt_afatena_060','地区管理3名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_tikukanricd3_tikunm',NULL,NULL,NULL,'宛名テーブル','地区管理コード3',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理3CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd3 || '':'' || tt_afatena_tikukanricd3_tikunm.tikunm','000_tt_afatena_061','地区管理3CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_tikukanricd3_tikunm',NULL,NULL,'宛名テーブル','地区管理コード3',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理4コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd4','000_tt_afatena_062','地区管理4コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'251','4','宛名テーブル','地区管理コード4',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理4名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_tikukanricd4_tikunm.tikunm','000_tt_afatena_063','地区管理4名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_tikukanricd4_tikunm',NULL,NULL,NULL,'宛名テーブル','地区管理コード4',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理4CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd4 || '':'' || tt_afatena_tikukanricd4_tikunm.tikunm','000_tt_afatena_064','地区管理4CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_tikukanricd4_tikunm',NULL,NULL,'宛名テーブル','地区管理コード4',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理5コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd5','000_tt_afatena_065','地区管理5コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'251','5','宛名テーブル','地区管理コード5',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理5名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_tikukanricd5_tikunm.tikunm','000_tt_afatena_066','地区管理5名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_tikukanricd5_tikunm',NULL,NULL,NULL,'宛名テーブル','地区管理コード5',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理5CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd5 || '':'' || tt_afatena_tikukanricd5_tikunm.tikunm','000_tt_afatena_067','地区管理5CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_tikukanricd5_tikunm',NULL,NULL,'宛名テーブル','地区管理コード5',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理6コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd6','000_tt_afatena_068','地区管理6コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'251','6','宛名テーブル','地区管理コード6',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理6名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_tikukanricd6_tikunm.tikunm','000_tt_afatena_069','地区管理6名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_tikukanricd6_tikunm',NULL,NULL,NULL,'宛名テーブル','地区管理コード6',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理6CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd6 || '':'' || tt_afatena_tikukanricd6_tikunm.tikunm','000_tt_afatena_070','地区管理6CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_tikukanricd6_tikunm',NULL,NULL,'宛名テーブル','地区管理コード6',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理7コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd7','000_tt_afatena_071','地区管理7コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'251','7','宛名テーブル','地区管理コード7',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理7名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_tikukanricd7_tikunm.tikunm','000_tt_afatena_072','地区管理7名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_tikukanricd7_tikunm',NULL,NULL,NULL,'宛名テーブル','地区管理コード7',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理7CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd7 || '':'' || tt_afatena_tikukanricd7_tikunm.tikunm','000_tt_afatena_073','地区管理7CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_tikukanricd7_tikunm',NULL,NULL,'宛名テーブル','地区管理コード7',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理8コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd8','000_tt_afatena_074','地区管理8コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'251','8','宛名テーブル','地区管理コード8',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理8名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_tikukanricd8_tikunm.tikunm','000_tt_afatena_075','地区管理8名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_tikukanricd8_tikunm',NULL,NULL,NULL,'宛名テーブル','地区管理コード8',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理8CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd8 || '':'' || tt_afatena_tikukanricd8_tikunm.tikunm','000_tt_afatena_076','地区管理8CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_tikukanricd8_tikunm',NULL,NULL,'宛名テーブル','地区管理コード8',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理9コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd9','000_tt_afatena_077','地区管理9コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'251','9','宛名テーブル','地区管理コード9',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理9名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_tikukanricd9_tikunm.tikunm','000_tt_afatena_078','地区管理9名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_tikukanricd9_tikunm',NULL,NULL,NULL,'宛名テーブル','地区管理コード9',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理9CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd9 || '':'' || tt_afatena_tikukanricd9_tikunm.tikunm','000_tt_afatena_079','地区管理9CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_tikukanricd9_tikunm',NULL,NULL,'宛名テーブル','地区管理コード9',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理10コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd10','000_tt_afatena_080','地区管理10コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'251','10','宛名テーブル','地区管理コード10',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理10名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_tikukanricd10_tikunm.tikunm','000_tt_afatena_081','地区管理10名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_tikukanricd10_tikunm',NULL,NULL,NULL,'宛名テーブル','地区管理コード10',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理10CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.tikukanricd10 || '':'' || tt_afatena_tikukanricd10_tikunm.tikunm','000_tt_afatena_082','地区管理10CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_tikukanricd10_tikunm',NULL,NULL,'宛名テーブル','地区管理コード10',NULL,'system','2023-01-01','system','2023-01-01');
--行政区コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.gyoseikucd','000_tt_afatena_083','行政区コード',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--支援措置区分コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.siensotikbn','000_tt_afatena_084','支援措置区分コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','2001,32','宛名テーブル','支援措置区分',NULL,'system','2023-01-01','system','2023-01-01');
--支援措置区分名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_siensotikbn_nm.nm','000_tt_afatena_085','支援措置区分名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_siensotikbn_nm',NULL,NULL,NULL,'宛名テーブル','支援措置区分',NULL,'system','2023-01-01','system','2023-01-01');
--支援措置区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.siensotikbn || '':'' || tt_afatena_siensotikbn_nm.nm','000_tt_afatena_086','支援措置区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_siensotikbn_nm',NULL,NULL,'宛名テーブル','支援措置区分',NULL,'system','2023-01-01','system','2023-01-01');
--個人番号
INSERT INTO tm_eutableitem VALUES('tt_afatena.personalno','000_tt_afatena_087','個人番号',NULL,1,3,True,1,'1','1','tt_afatena',NULL,NULL,NULL,'宛名テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--課税非課税区分コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.kazeikbn','000_tt_afatena_088','課税非課税区分コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','2010,5','宛名テーブル','課税非課税区分',NULL,'system','2023-01-01','system','2023-01-01');
--課税非課税区分名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_kazeikbn_nm.nm','000_tt_afatena_089','課税非課税区分名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_kazeikbn_nm',NULL,NULL,NULL,'宛名テーブル','課税非課税区分',NULL,'system','2023-01-01','system','2023-01-01');
--課税非課税区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.kazeikbn || '':'' || tt_afatena_kazeikbn_nm.nm','000_tt_afatena_090','課税非課税区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_kazeikbn_nm',NULL,NULL,'宛名テーブル','課税非課税区分',NULL,'system','2023-01-01','system','2023-01-01');
--課税非課税区分（世帯）コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.kazeikbn_setai','000_tt_afatena_091','課税非課税区分（世帯）コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','2010,5','宛名テーブル','課税非課税区分（世帯）',NULL,'system','2023-01-01','system','2023-01-01');
--課税非課税区分（世帯）名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_kazeikbn_setai_nm.nm','000_tt_afatena_092','課税非課税区分（世帯）名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_kazeikbn_setai_nm',NULL,NULL,NULL,'宛名テーブル','課税非課税区分（世帯）',NULL,'system','2023-01-01','system','2023-01-01');
--課税非課税区分（世帯）CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.kazeikbn_setai || '':'' || tt_afatena_kazeikbn_setai_nm.nm','000_tt_afatena_093','課税非課税区分（世帯）CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_kazeikbn_setai_nm',NULL,NULL,'宛名テーブル','課税非課税区分（世帯）',NULL,'system','2023-01-01','system','2023-01-01');
--保険区分コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.hokenkbn','000_tt_afatena_094','保険区分コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','1001,1','宛名テーブル','保険区分',NULL,'system','2023-01-01','system','2023-01-01');
--保険区分名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_hokenkbn_nm.nm','000_tt_afatena_095','保険区分名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_hokenkbn_nm',NULL,NULL,NULL,'宛名テーブル','保険区分',NULL,'system','2023-01-01','system','2023-01-01');
--保険区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.hokenkbn || '':'' || tt_afatena_hokenkbn_nm.nm','000_tt_afatena_096','保険区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_hokenkbn_nm',NULL,NULL,'宛名テーブル','保険区分',NULL,'system','2023-01-01','system','2023-01-01');
--減免区分（特定健診）コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.genmenkbn_tokutei','000_tt_afatena_097','減免区分（特定健診）コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','1002,5','宛名テーブル','減免区分（特定健診）',NULL,'system','2023-01-01','system','2023-01-01');
--減免区分（特定健診）名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_genmenkbn_tokutei_nm.nm','000_tt_afatena_098','減免区分（特定健診）名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_genmenkbn_tokutei_nm',NULL,NULL,NULL,'宛名テーブル','減免区分（特定健診）',NULL,'system','2023-01-01','system','2023-01-01');
--減免区分（特定健診）CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.genmenkbn_tokutei || '':'' || tt_afatena_genmenkbn_tokutei_nm.nm','000_tt_afatena_099','減免区分（特定健診）CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_genmenkbn_tokutei_nm',NULL,NULL,'宛名テーブル','減免区分（特定健診）',NULL,'system','2023-01-01','system','2023-01-01');
--減免区分（がん検診）コード
INSERT INTO tm_eutableitem VALUES('tt_afatena.genmenkbn_gan','000_tt_afatena_100','減免区分（がん検診）コード',NULL,1,3,True,3,'1',NULL,'tt_afatena',NULL,'111','1002,6','宛名テーブル','減免区分（がん検診）',NULL,'system','2023-01-01','system','2023-01-01');
--減免区分（がん検診）名称
INSERT INTO tm_eutableitem VALUES('tt_afatena_genmenkbn_gan_nm.nm','000_tt_afatena_101','減免区分（がん検診）名称',NULL,0,2,False,1,'1',NULL,'tt_afatena_genmenkbn_gan_nm',NULL,NULL,NULL,'宛名テーブル','減免区分（がん検診）',NULL,'system','2023-01-01','system','2023-01-01');
--減免区分（がん検診）CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afatena.genmenkbn_gan || '':'' || tt_afatena_genmenkbn_gan_nm.nm','000_tt_afatena_102','減免区分（がん検診）CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afatena','tt_afatena_genmenkbn_gan_nm',NULL,NULL,'宛名テーブル','減免区分（がん検診）',NULL,'system','2023-01-01','system','2023-01-01');
--ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afatenalog.userid','000_tt_afatenalog_001','ユーザーID',NULL,1,3,True,1,'1','1','tt_afatenalog',NULL,NULL,NULL,'宛名番号検索履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--機能ID
INSERT INTO tm_eutableitem VALUES('tt_afatenalog.kinoid','000_tt_afatenalog_002','機能ID',NULL,1,3,True,1,'1','1','tt_afatenalog',NULL,NULL,NULL,'宛名番号検索履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afatenalog.atenano','000_tt_afatenalog_003','宛名番号',NULL,1,3,True,1,'1','1','tt_afatenalog',NULL,NULL,NULL,'宛名番号検索履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--処理日時
INSERT INTO tm_eutableitem VALUES('tt_afatenalog.syoridttm','000_tt_afatenalog_004','処理日時',NULL,1,4,True,1,'1','1','tt_afatenalog',NULL,NULL,NULL,'宛名番号検索履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ロール区分
INSERT INTO tm_eutableitem VALUES('tt_afauthgamen.rolekbn','000_tt_afauthgamen_001','ロール区分',NULL,1,3,True,1,'1','1','tt_afauthgamen',NULL,NULL,NULL,'画面権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ロールID
INSERT INTO tm_eutableitem VALUES('tt_afauthgamen.roleid','000_tt_afauthgamen_002','ロールID',NULL,1,3,True,1,'1','1','tt_afauthgamen',NULL,NULL,NULL,'画面権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--機能ID
INSERT INTO tm_eutableitem VALUES('tt_afauthgamen.kinoid','000_tt_afauthgamen_003','機能ID',NULL,1,3,True,1,'1','1','tt_afauthgamen',NULL,NULL,NULL,'画面権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--プログラム区分
INSERT INTO tm_eutableitem VALUES('tt_afauthgamen.programkbn','000_tt_afauthgamen_004','プログラム区分',NULL,1,3,True,1,'1','1','tt_afauthgamen',NULL,NULL,NULL,'画面権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--追加フラグ
INSERT INTO tm_eutableitem VALUES('tt_afauthgamen.addflg','000_tt_afauthgamen_005','追加フラグ',NULL,1,6,True,1,'1','1','tt_afauthgamen',NULL,NULL,NULL,'画面権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--修正フラグ
INSERT INTO tm_eutableitem VALUES('tt_afauthgamen.updateflg','000_tt_afauthgamen_006','修正フラグ',NULL,1,6,True,1,'1','1','tt_afauthgamen',NULL,NULL,NULL,'画面権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--削除フラグ
INSERT INTO tm_eutableitem VALUES('tt_afauthgamen.deleteflg','000_tt_afauthgamen_007','削除フラグ',NULL,1,6,True,1,'1','1','tt_afauthgamen',NULL,NULL,NULL,'画面権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人番号利用フラグ
INSERT INTO tm_eutableitem VALUES('tt_afauthgamen.personalnoflg','000_tt_afauthgamen_008','個人番号利用フラグ',NULL,1,6,True,1,'1','1','tt_afauthgamen',NULL,NULL,NULL,'画面権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--継承フラグ
INSERT INTO tm_eutableitem VALUES('tt_afauthgamen.keisyoflg','000_tt_afauthgamen_009','継承フラグ',NULL,1,6,True,1,'1','1','tt_afauthgamen',NULL,NULL,NULL,'画面権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afauthgamen.reguserid','000_tt_afauthgamen_010','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afauthgamen',NULL,NULL,NULL,'画面権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afauthgamen.regdttm','000_tt_afauthgamen_011','登録日時',NULL,1,4,False,1,'1','1','tt_afauthgamen',NULL,NULL,NULL,'画面権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afauthgamen.upduserid','000_tt_afauthgamen_012','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afauthgamen',NULL,NULL,NULL,'画面権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afauthgamen.upddttm','000_tt_afauthgamen_013','更新日時',NULL,1,4,False,1,'1','1','tt_afauthgamen',NULL,NULL,NULL,'画面権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ロール区分
INSERT INTO tm_eutableitem VALUES('tt_afauthreport.rolekbn','000_tt_afauthreport_001','ロール区分',NULL,1,3,True,1,'1','1','tt_afauthreport',NULL,NULL,NULL,'帳票権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ロールID
INSERT INTO tm_eutableitem VALUES('tt_afauthreport.roleid','000_tt_afauthreport_002','ロールID',NULL,1,3,True,1,'1','1','tt_afauthreport',NULL,NULL,NULL,'帳票権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--グループID
INSERT INTO tm_eutableitem VALUES('tt_afauthreport.repgroupid','000_tt_afauthreport_003','グループID',NULL,1,3,True,1,'1','1','tt_afauthreport',NULL,NULL,NULL,'帳票権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--通知書出力フラグ
INSERT INTO tm_eutableitem VALUES('tt_afauthreport.tutisyooutflg','000_tt_afauthreport_004','通知書出力フラグ',NULL,1,6,True,1,'1','1','tt_afauthreport',NULL,NULL,NULL,'帳票権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--PDF出力フラグ
INSERT INTO tm_eutableitem VALUES('tt_afauthreport.pdfoutflg','000_tt_afauthreport_005','PDF出力フラグ',NULL,1,6,True,1,'1','1','tt_afauthreport',NULL,NULL,NULL,'帳票権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--EXCEL出力フラグ
INSERT INTO tm_eutableitem VALUES('tt_afauthreport.exceloutflg','000_tt_afauthreport_006','EXCEL出力フラグ',NULL,1,6,True,1,'1','1','tt_afauthreport',NULL,NULL,NULL,'帳票権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--その他出力フラグ
INSERT INTO tm_eutableitem VALUES('tt_afauthreport.othersflg','000_tt_afauthreport_007','その他出力フラグ',NULL,1,6,True,1,'1','1','tt_afauthreport',NULL,NULL,NULL,'帳票権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人番号利用フラグ
INSERT INTO tm_eutableitem VALUES('tt_afauthreport.personalnoflg','000_tt_afauthreport_008','個人番号利用フラグ',NULL,1,6,True,1,'1','1','tt_afauthreport',NULL,NULL,NULL,'帳票権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--継承フラグ
INSERT INTO tm_eutableitem VALUES('tt_afauthreport.keisyoflg','000_tt_afauthreport_009','継承フラグ',NULL,1,6,True,1,'1','1','tt_afauthreport',NULL,NULL,NULL,'帳票権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afauthreport.reguserid','000_tt_afauthreport_010','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afauthreport',NULL,NULL,NULL,'帳票権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afauthreport.regdttm','000_tt_afauthreport_011','登録日時',NULL,1,4,False,1,'1','1','tt_afauthreport',NULL,NULL,NULL,'帳票権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afauthreport.upduserid','000_tt_afauthreport_012','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afauthreport',NULL,NULL,NULL,'帳票権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afauthreport.upddttm','000_tt_afauthreport_013','更新日時',NULL,1,4,False,1,'1','1','tt_afauthreport',NULL,NULL,NULL,'帳票権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ロール区分
INSERT INTO tm_eutableitem VALUES('tt_afauthsisyo.rolekbn','000_tt_afauthsisyo_001','ロール区分',NULL,1,3,True,1,'1','1','tt_afauthsisyo',NULL,NULL,NULL,'部署（支所）別更新権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ロールID
INSERT INTO tm_eutableitem VALUES('tt_afauthsisyo.roleid','000_tt_afauthsisyo_002','ロールID',NULL,1,3,True,1,'1','1','tt_afauthsisyo',NULL,NULL,NULL,'部署（支所）別更新権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--部署（支所）コード
INSERT INTO tm_eutableitem VALUES('tt_afauthsisyo.sisyocd','000_tt_afauthsisyo_003','部署（支所）コード',NULL,1,3,True,1,'1','1','tt_afauthsisyo',NULL,NULL,NULL,'部署（支所）別更新権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afauthsisyo.reguserid','000_tt_afauthsisyo_004','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afauthsisyo',NULL,NULL,NULL,'部署（支所）別更新権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afauthsisyo.regdttm','000_tt_afauthsisyo_005','登録日時',NULL,1,4,False,1,'1','1','tt_afauthsisyo',NULL,NULL,NULL,'部署（支所）別更新権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afauthsisyo.upduserid','000_tt_afauthsisyo_006','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afauthsisyo',NULL,NULL,NULL,'部署（支所）別更新権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afauthsisyo.upddttm','000_tt_afauthsisyo_007','更新日時',NULL,1,4,False,1,'1','1','tt_afauthsisyo',NULL,NULL,NULL,'部署（支所）別更新権限テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--バッチログシーケンス
INSERT INTO tm_eutableitem VALUES('tt_afbatchlog.batchlogseq','000_tt_afbatchlog_001','バッチログシーケンス',NULL,1,1,True,1,'1','1','tt_afbatchlog',NULL,NULL,NULL,'バッチログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--セッションシーケンス
INSERT INTO tm_eutableitem VALUES('tt_afbatchlog.sessionseq','000_tt_afbatchlog_002','セッションシーケンス',NULL,1,1,True,1,'1','1','tt_afbatchlog',NULL,NULL,NULL,'バッチログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--処理日時（開始）
INSERT INTO tm_eutableitem VALUES('tt_afbatchlog.syoridttmf','000_tt_afbatchlog_003','処理日時（開始）',NULL,1,4,True,1,'1','1','tt_afbatchlog',NULL,NULL,NULL,'バッチログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--処理日時（終了）
INSERT INTO tm_eutableitem VALUES('tt_afbatchlog.syoridttmt','000_tt_afbatchlog_004','処理日時（終了）',NULL,1,4,True,1,'1','1','tt_afbatchlog',NULL,NULL,NULL,'バッチログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ
INSERT INTO tm_eutableitem VALUES('tt_afbatchlog.msg','000_tt_afbatchlog_005','メッセージ',NULL,1,3,True,1,'1','1','tt_afbatchlog',NULL,NULL,NULL,'バッチログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--パラメータ
INSERT INTO tm_eutableitem VALUES('tt_afbatchlog.pram','000_tt_afbatchlog_006','パラメータ',NULL,1,3,True,1,'1','1','tt_afbatchlog',NULL,NULL,NULL,'バッチログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afbatchlog.reguserid','000_tt_afbatchlog_007','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afbatchlog',NULL,NULL,NULL,'バッチログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afbatchlog.regdttm','000_tt_afbatchlog_008','登録日時',NULL,1,4,False,1,'1','1','tt_afbatchlog',NULL,NULL,NULL,'バッチログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ドキュメントシーケンス
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.docseq','000_tt_afcomdoc_001','ドキュメントシーケンス',NULL,1,1,True,1,'1','1','tt_afcomdoc',NULL,NULL,NULL,'共通ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ファイル名
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.filenm','000_tt_afcomdoc_002','ファイル名',NULL,1,3,True,1,'1','1','tt_afcomdoc',NULL,NULL,NULL,'共通ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--事業コード
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.jigyocd','000_tt_afcomdoc_003','事業コード',NULL,1,3,True,1,'1','1','tt_afcomdoc',NULL,NULL,NULL,'共通ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--タイトル
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.title','000_tt_afcomdoc_004','タイトル',NULL,1,3,True,1,'1','1','tt_afcomdoc',NULL,NULL,NULL,'共通ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプコード
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.filetype','000_tt_afcomdoc_005','ファイルタイプコード',NULL,1,1,True,3,'1',NULL,'tt_afcomdoc',NULL,'111','1000,10','共通ドキュメントテーブル','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプ名称
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc_filetype_nm.nm','000_tt_afcomdoc_006','ファイルタイプ名称',NULL,0,2,False,1,'1',NULL,'tt_afcomdoc_filetype_nm',NULL,NULL,NULL,'共通ドキュメントテーブル','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.filetype || '':'' || tt_afcomdoc_filetype_nm.nm','000_tt_afcomdoc_007','ファイルタイプCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afcomdoc','tt_afcomdoc_filetype_nm',NULL,NULL,'共通ドキュメントテーブル','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルサイズ
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.filesize','000_tt_afcomdoc_008','ファイルサイズ',NULL,1,1,True,1,'1','1','tt_afcomdoc',NULL,NULL,NULL,'共通ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ファイルデータ
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.filedata','000_tt_afcomdoc_009','ファイルデータ',NULL,1,7,True,1,'1','1','tt_afcomdoc',NULL,NULL,NULL,'共通ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録支所コード
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.regsisyo','000_tt_afcomdoc_010','登録支所コード',NULL,1,3,True,3,'1',NULL,'tt_afcomdoc',NULL,'121','3019,1','共通ドキュメントテーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所名称
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc_regsisyo_nm.nm','000_tt_afcomdoc_011','登録支所名称',NULL,0,2,False,1,'1',NULL,'tt_afcomdoc_regsisyo_nm',NULL,NULL,NULL,'共通ドキュメントテーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.regsisyo || '':'' || tt_afcomdoc_regsisyo_nm.nm','000_tt_afcomdoc_012','登録支所CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afcomdoc','tt_afcomdoc_regsisyo_nm',NULL,NULL,'共通ドキュメントテーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.reguserid','000_tt_afcomdoc_013','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afcomdoc',NULL,NULL,NULL,'共通ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.regdttm','000_tt_afcomdoc_014','登録日時',NULL,1,4,False,1,'1','1','tt_afcomdoc',NULL,NULL,NULL,'共通ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.upduserid','000_tt_afcomdoc_015','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afcomdoc',NULL,NULL,NULL,'共通ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afcomdoc.upddttm','000_tt_afcomdoc_016','更新日時',NULL,1,4,False,1,'1','1','tt_afcomdoc',NULL,NULL,NULL,'共通ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--機能ID
INSERT INTO tm_eutableitem VALUES('tt_affilter.kinoid','000_tt_affilter_001','機能ID',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--条件区分
INSERT INTO tm_eutableitem VALUES('tt_affilter.jyokbn','000_tt_affilter_002','条件区分',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--条件シーケンス
INSERT INTO tm_eutableitem VALUES('tt_affilter.jyoseq','000_tt_affilter_003','条件シーケンス',NULL,1,1,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--詳細条件表示名
INSERT INTO tm_eutableitem VALUES('tt_affilter.hyojinm','000_tt_affilter_004','詳細条件表示名',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コントローラータイプコード
INSERT INTO tm_eutableitem VALUES('tt_affilter.ctrltype','000_tt_affilter_005','コントローラータイプコード',NULL,1,3,True,3,'1',NULL,'tt_affilter',NULL,'111','1000,26','詳細条件設定テーブル','コントローラータイプ',NULL,'system','2023-01-01','system','2023-01-01');
--コントローラータイプ名称
INSERT INTO tm_eutableitem VALUES('tt_affilter_ctrltype_nm.nm','000_tt_affilter_006','コントローラータイプ名称',NULL,0,2,False,1,'1',NULL,'tt_affilter_ctrltype_nm',NULL,NULL,NULL,'詳細条件設定テーブル','コントローラータイプ',NULL,'system','2023-01-01','system','2023-01-01');
--コントローラータイプCD:名称
INSERT INTO tm_eutableitem VALUES('tt_affilter.ctrltype || '':'' || tt_affilter_ctrltype_nm.nm','000_tt_affilter_007','コントローラータイプCD:名称',NULL,0,2,False,1,'1',NULL,'tt_affilter','tt_affilter_ctrltype_nm',NULL,NULL,'詳細条件設定テーブル','コントローラータイプ',NULL,'system','2023-01-01','system','2023-01-01');
--表示フラグ
INSERT INTO tm_eutableitem VALUES('tt_affilter.hyojiflg','000_tt_affilter_008','表示フラグ',NULL,1,6,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--並び順
INSERT INTO tm_eutableitem VALUES('tt_affilter.sort','000_tt_affilter_009','並び順',NULL,1,1,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力説明
INSERT INTO tm_eutableitem VALUES('tt_affilter.placeholder','000_tt_affilter_010','入力説明',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--範囲フラグ
INSERT INTO tm_eutableitem VALUES('tt_affilter.rangeflg','000_tt_affilter_011','範囲フラグ',NULL,1,6,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--設定用汎用区分1
INSERT INTO tm_eutableitem VALUES('tt_affilter.sethanyokbn1','000_tt_affilter_012','設定用汎用区分1',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--設定用汎用区分2
INSERT INTO tm_eutableitem VALUES('tt_affilter.sethanyokbn2','000_tt_affilter_013','設定用汎用区分2',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--設定用汎用区分3
INSERT INTO tm_eutableitem VALUES('tt_affilter.sethanyokbn3','000_tt_affilter_014','設定用汎用区分3',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--設定用汎用区分4
INSERT INTO tm_eutableitem VALUES('tt_affilter.sethanyokbn4','000_tt_affilter_015','設定用汎用区分4',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--設定用汎用区分5
INSERT INTO tm_eutableitem VALUES('tt_affilter.sethanyokbn5','000_tt_affilter_016','設定用汎用区分5',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--検索対象データ取得区分
INSERT INTO tm_eutableitem VALUES('tt_affilter.getkbn','000_tt_affilter_017','検索対象データ取得区分',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--テーブル物理名1
INSERT INTO tm_eutableitem VALUES('tt_affilter.tablenm1','000_tt_affilter_018','テーブル物理名1',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目物理名1
INSERT INTO tm_eutableitem VALUES('tt_affilter.komokunm1','000_tt_affilter_019','項目物理名1',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--主キーコード1
INSERT INTO tm_eutableitem VALUES('tt_affilter.keycd1','000_tt_affilter_020','主キーコード1',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目コード1
INSERT INTO tm_eutableitem VALUES('tt_affilter.itemcd1','000_tt_affilter_021','項目コード1',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--テーブル物理名2
INSERT INTO tm_eutableitem VALUES('tt_affilter.tablenm2','000_tt_affilter_022','テーブル物理名2',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目物理名2
INSERT INTO tm_eutableitem VALUES('tt_affilter.komokunm2','000_tt_affilter_023','項目物理名2',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--主キーコード2
INSERT INTO tm_eutableitem VALUES('tt_affilter.keycd2','000_tt_affilter_024','主キーコード2',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目コード2
INSERT INTO tm_eutableitem VALUES('tt_affilter.itemcd2','000_tt_affilter_025','項目コード2',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--テーブル物理名3
INSERT INTO tm_eutableitem VALUES('tt_affilter.tablenm3','000_tt_affilter_026','テーブル物理名3',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目物理名3
INSERT INTO tm_eutableitem VALUES('tt_affilter.komokunm3','000_tt_affilter_027','項目物理名3',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--主キーコード3
INSERT INTO tm_eutableitem VALUES('tt_affilter.keycd3','000_tt_affilter_028','主キーコード3',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目コード3
INSERT INTO tm_eutableitem VALUES('tt_affilter.itemcd3','000_tt_affilter_029','項目コード3',NULL,1,3,True,1,'1','1','tt_affilter',NULL,NULL,NULL,'詳細条件設定テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--外部連携ログシーケンス
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.gaibulogseq','000_tt_afgaibulog_001','外部連携ログシーケンス',NULL,1,1,True,1,'1','1','tt_afgaibulog',NULL,NULL,NULL,'外部連携処理結果履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--セッションシーケンス
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.sessionseq','000_tt_afgaibulog_002','セッションシーケンス',NULL,1,1,True,1,'1','1','tt_afgaibulog',NULL,NULL,NULL,'外部連携処理結果履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--処理日時（開始）
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.syoridttmf','000_tt_afgaibulog_003','処理日時（開始）',NULL,1,4,True,1,'1','1','tt_afgaibulog',NULL,NULL,NULL,'外部連携処理結果履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--処理日時（終了）
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.syoridttmt','000_tt_afgaibulog_004','処理日時（終了）',NULL,1,4,True,1,'1','1','tt_afgaibulog',NULL,NULL,NULL,'外部連携処理結果履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.msg','000_tt_afgaibulog_005','メッセージ',NULL,1,3,True,1,'1','1','tt_afgaibulog',NULL,NULL,NULL,'外部連携処理結果履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--IPアドレス（実行）
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.ipadrs','000_tt_afgaibulog_006','IPアドレス（実行）',NULL,1,3,True,1,'1','1','tt_afgaibulog',NULL,NULL,NULL,'外部連携処理結果履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携区分コード
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.kbn','000_tt_afgaibulog_007','連携区分コード',NULL,1,3,True,3,'1',NULL,'tt_afgaibulog',NULL,'111','1000,39','外部連携処理結果履歴テーブル','連携区分',NULL,'system','2023-01-01','system','2023-01-01');
--連携区分名称
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog_kbn_nm.nm','000_tt_afgaibulog_008','連携区分名称',NULL,0,2,False,1,'1',NULL,'tt_afgaibulog_kbn_nm',NULL,NULL,NULL,'外部連携処理結果履歴テーブル','連携区分',NULL,'system','2023-01-01','system','2023-01-01');
--連携区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.kbn || '':'' || tt_afgaibulog_kbn_nm.nm','000_tt_afgaibulog_009','連携区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afgaibulog','tt_afgaibulog_kbn_nm',NULL,NULL,'外部連携処理結果履歴テーブル','連携区分',NULL,'system','2023-01-01','system','2023-01-01');
--連携方式コード
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.kbn2','000_tt_afgaibulog_010','連携方式コード',NULL,1,3,True,3,'1',NULL,'tt_afgaibulog',NULL,'111','1000,30','外部連携処理結果履歴テーブル','連携方式',NULL,'system','2023-01-01','system','2023-01-01');
--連携方式名称
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog_kbn2_nm.nm','000_tt_afgaibulog_011','連携方式名称',NULL,0,2,False,1,'1',NULL,'tt_afgaibulog_kbn2_nm',NULL,NULL,NULL,'外部連携処理結果履歴テーブル','連携方式',NULL,'system','2023-01-01','system','2023-01-01');
--連携方式CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.kbn2 || '':'' || tt_afgaibulog_kbn2_nm.nm','000_tt_afgaibulog_012','連携方式CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afgaibulog','tt_afgaibulog_kbn2_nm',NULL,NULL,'外部連携処理結果履歴テーブル','連携方式',NULL,'system','2023-01-01','system','2023-01-01');
--処理区分コード
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.kbn3','000_tt_afgaibulog_013','処理区分コード',NULL,1,3,True,3,'1',NULL,'tt_afgaibulog',NULL,'111','1000,7','外部連携処理結果履歴テーブル','処理区分',NULL,'system','2023-01-01','system','2023-01-01');
--処理区分名称
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog_kbn3_nm.nm','000_tt_afgaibulog_014','処理区分名称',NULL,0,2,False,1,'1',NULL,'tt_afgaibulog_kbn3_nm',NULL,NULL,NULL,'外部連携処理結果履歴テーブル','処理区分',NULL,'system','2023-01-01','system','2023-01-01');
--処理区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.kbn3 || '':'' || tt_afgaibulog_kbn3_nm.nm','000_tt_afgaibulog_015','処理区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afgaibulog','tt_afgaibulog_kbn3_nm',NULL,NULL,'外部連携処理結果履歴テーブル','処理区分',NULL,'system','2023-01-01','system','2023-01-01');
--API連携データ
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.apidata','000_tt_afgaibulog_016','API連携データ',NULL,1,3,True,1,'1','1','tt_afgaibulog',NULL,NULL,NULL,'外部連携処理結果履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ファイル名
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.filenm','000_tt_afgaibulog_017','ファイル名',NULL,1,3,True,1,'1','1','tt_afgaibulog',NULL,NULL,NULL,'外部連携処理結果履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプコード
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.filetype','000_tt_afgaibulog_018','ファイルタイプコード',NULL,1,1,True,3,'1',NULL,'tt_afgaibulog',NULL,'111','1000,10','外部連携処理結果履歴テーブル','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプ名称
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog_filetype_nm.nm','000_tt_afgaibulog_019','ファイルタイプ名称',NULL,0,2,False,1,'1',NULL,'tt_afgaibulog_filetype_nm',NULL,NULL,NULL,'外部連携処理結果履歴テーブル','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.filetype || '':'' || tt_afgaibulog_filetype_nm.nm','000_tt_afgaibulog_020','ファイルタイプCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afgaibulog','tt_afgaibulog_filetype_nm',NULL,NULL,'外部連携処理結果履歴テーブル','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルサイズ
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.filesize','000_tt_afgaibulog_021','ファイルサイズ',NULL,1,1,True,1,'1','1','tt_afgaibulog',NULL,NULL,NULL,'外部連携処理結果履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ファイルデータ
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.filedata','000_tt_afgaibulog_022','ファイルデータ',NULL,1,7,True,1,'1','1','tt_afgaibulog',NULL,NULL,NULL,'外部連携処理結果履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.reguserid','000_tt_afgaibulog_023','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afgaibulog',NULL,NULL,NULL,'外部連携処理結果履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afgaibulog.regdttm','000_tt_afgaibulog_024','登録日時',NULL,1,4,False,1,'1','1','tt_afgaibulog',NULL,NULL,NULL,'外部連携処理結果履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--お知らせシーケンス
INSERT INTO tm_eutableitem VALUES('tt_afinfo.infoseq','000_tt_afinfo_001','お知らせシーケンス',NULL,1,1,True,1,'1','1','tt_afinfo',NULL,NULL,NULL,'お知らせテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--重要度
INSERT INTO tm_eutableitem VALUES('tt_afinfo.juyodo','000_tt_afinfo_002','重要度',NULL,1,3,True,1,'1','1','tt_afinfo',NULL,NULL,NULL,'お知らせテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--掲示期限年月日
INSERT INTO tm_eutableitem VALUES('tt_afinfo.kigenymd','000_tt_afinfo_003','掲示期限年月日',NULL,1,3,True,1,'1','1','tt_afinfo',NULL,NULL,NULL,'お知らせテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--詳細
INSERT INTO tm_eutableitem VALUES('tt_afinfo.syosai','000_tt_afinfo_004','詳細',NULL,1,3,True,1,'1','1','tt_afinfo',NULL,NULL,NULL,'お知らせテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛先指定フラグ
INSERT INTO tm_eutableitem VALUES('tt_afinfo.atesakiflg','000_tt_afinfo_005','宛先指定フラグ',NULL,1,6,True,1,'1','1','tt_afinfo',NULL,NULL,NULL,'お知らせテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛先
INSERT INTO tm_eutableitem VALUES('tt_afinfo.atesaki','000_tt_afinfo_006','宛先',NULL,1,3,True,1,'1','1','tt_afinfo',NULL,NULL,NULL,'お知らせテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afinfo.reguserid','000_tt_afinfo_007','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afinfo',NULL,NULL,NULL,'お知らせテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afinfo.regdttm','000_tt_afinfo_008','登録日時',NULL,1,4,False,1,'1','1','tt_afinfo',NULL,NULL,NULL,'お知らせテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afinfo.upduserid','000_tt_afinfo_009','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afinfo',NULL,NULL,NULL,'お知らせテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afinfo.upddttm','000_tt_afinfo_010','更新日時',NULL,1,4,False,1,'1','1','tt_afinfo',NULL,NULL,NULL,'お知らせテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--お知らせシーケンス
INSERT INTO tm_eutableitem VALUES('tt_afinfo_user.infoseq','000_tt_afinfo_user_001','お知らせシーケンス',NULL,1,1,True,1,'1','1','tt_afinfo_user',NULL,NULL,NULL,'お知らせ確認状態テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afinfo_user.userid','000_tt_afinfo_user_002','ユーザーID',NULL,1,3,True,1,'1','1','tt_afinfo_user',NULL,NULL,NULL,'お知らせ確認状態テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin.atenano','000_tt_afjumin_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--世帯番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin.setaino','000_tt_afjumin_002','世帯番号',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住民種別コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.juminsyubetu','000_tt_afjumin_003','住民種別コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,4','【住民基本台帳】住民情報テーブル','住民種別',NULL,'system','2023-01-01','system','2023-01-01');
--住民種別名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_juminsyubetu_nm.nm','000_tt_afjumin_004','住民種別名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_juminsyubetu_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住民種別',NULL,'system','2023-01-01','system','2023-01-01');
--住民種別CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.juminsyubetu || '':'' || tt_afjumin_juminsyubetu_nm.nm','000_tt_afjumin_005','住民種別CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_juminsyubetu_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','住民種別',NULL,'system','2023-01-01','system','2023-01-01');
--住民状態コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.juminjotai','000_tt_afjumin_006','住民状態コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,5','【住民基本台帳】住民情報テーブル','住民状態',NULL,'system','2023-01-01','system','2023-01-01');
--住民状態名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_juminjotai_nm.nm','000_tt_afjumin_007','住民状態名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_juminjotai_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住民状態',NULL,'system','2023-01-01','system','2023-01-01');
--住民状態CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.juminjotai || '':'' || tt_afjumin_juminjotai_nm.nm','000_tt_afjumin_008','住民状態CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_juminjotai_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','住民状態',NULL,'system','2023-01-01','system','2023-01-01');
--異動年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin.idoymd','000_tt_afjumin_009','異動年月日',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--異動年月日_不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_afjumin.idoymd_fusyoflg','000_tt_afjumin_010','異動年月日_不詳フラグ',NULL,1,6,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','異動年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--異動年月日_不詳表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin.idoymd_fusyohyoki','000_tt_afjumin_011','異動年月日_不詳表記',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','異動年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--異動届出年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin.idotodokeymd','000_tt_afjumin_012','異動届出年月日',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--異動事由コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.idojiyu','000_tt_afjumin_013','異動事由コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,20~22','【住民基本台帳】住民情報テーブル','異動事由',NULL,'system','2023-01-01','system','2023-01-01');
--異動事由名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_idojiyu_nm.nm','000_tt_afjumin_014','異動事由名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_idojiyu_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','異動事由',NULL,'system','2023-01-01','system','2023-01-01');
--異動事由CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.idojiyu || '':'' || tt_afjumin_idojiyu_nm.nm','000_tt_afjumin_015','異動事由CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_idojiyu_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','異動事由',NULL,'system','2023-01-01','system','2023-01-01');
--氏名
INSERT INTO tm_eutableitem VALUES('tt_afjumin.simei','000_tt_afjumin_016','氏名',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--氏名_外国人ローマ字
INSERT INTO tm_eutableitem VALUES('tt_afjumin.simei_gairoma','000_tt_afjumin_017','氏名_外国人ローマ字',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_外国人漢字
INSERT INTO tm_eutableitem VALUES('tt_afjumin.simei_gaikanji','000_tt_afjumin_018','氏名_外国人漢字',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjumin.simei_kana','000_tt_afjumin_019','氏名_フリガナ',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--旧氏
INSERT INTO tm_eutableitem VALUES('tt_afjumin.kyusi','000_tt_afjumin_020','旧氏',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--旧氏_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjumin.kyusi_kana','000_tt_afjumin_021','旧氏_フリガナ',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','旧氏''',NULL,'system','2023-01-01','system','2023-01-01');
--通称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tusyo','000_tt_afjumin_022','通称',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--通称_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tusyo_kana','000_tt_afjumin_023','通称_フリガナ',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','通称''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名優先区分コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.simeiyusenkbn','000_tt_afjumin_024','氏名優先区分コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,14','【住民基本台帳】住民情報テーブル','氏名優先区分',NULL,'system','2023-01-01','system','2023-01-01');
--氏名優先区分名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_simeiyusenkbn_nm.nm','000_tt_afjumin_025','氏名優先区分名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_simeiyusenkbn_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','氏名優先区分',NULL,'system','2023-01-01','system','2023-01-01');
--氏名優先区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.simeiyusenkbn || '':'' || tt_afjumin_simeiyusenkbn_nm.nm','000_tt_afjumin_026','氏名優先区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_simeiyusenkbn_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','氏名優先区分',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_優先
INSERT INTO tm_eutableitem VALUES('tt_afjumin.simei_yusen','000_tt_afjumin_027','氏名_優先',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_フリガナ_優先
INSERT INTO tm_eutableitem VALUES('tt_afjumin.simei_kana_yusen','000_tt_afjumin_028','氏名_フリガナ_優先',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','氏名_フリガナ''',NULL,'system','2023-01-01','system','2023-01-01');
--性別コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.sex','000_tt_afjumin_029','性別コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,1','【住民基本台帳】住民情報テーブル','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_sex_nm.nm','000_tt_afjumin_030','性別名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_sex_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.sex || '':'' || tt_afjumin_sex_nm.nm','000_tt_afjumin_031','性別CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_sex_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin.sexhyoki','000_tt_afjumin_032','性別表記',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--生年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin.bymd','000_tt_afjumin_033','生年月日',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--生年月日_不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_afjumin.bymd_fusyoflg','000_tt_afjumin_034','生年月日_不詳フラグ',NULL,1,6,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','生年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--生年月日_不詳表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin.bymd_fusyohyoki','000_tt_afjumin_035','生年月日_不詳表記',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','生年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--続柄1コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zokucd1','000_tt_afjumin_036','続柄1コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,18','【住民基本台帳】住民情報テーブル','続柄コード1',NULL,'system','2023-01-01','system','2023-01-01');
--続柄1名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_zokucd1_nm.nm','000_tt_afjumin_037','続柄1名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_zokucd1_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','続柄コード1',NULL,'system','2023-01-01','system','2023-01-01');
--続柄1CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zokucd1 || '':'' || tt_afjumin_zokucd1_nm.nm','000_tt_afjumin_038','続柄1CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_zokucd1_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','続柄コード1',NULL,'system','2023-01-01','system','2023-01-01');
--続柄2コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zokucd2','000_tt_afjumin_039','続柄2コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,18','【住民基本台帳】住民情報テーブル','続柄コード2',NULL,'system','2023-01-01','system','2023-01-01');
--続柄2名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_zokucd2_nm.nm','000_tt_afjumin_040','続柄2名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_zokucd2_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','続柄コード2',NULL,'system','2023-01-01','system','2023-01-01');
--続柄2CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zokucd2 || '':'' || tt_afjumin_zokucd2_nm.nm','000_tt_afjumin_041','続柄2CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_zokucd2_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','続柄コード2',NULL,'system','2023-01-01','system','2023-01-01');
--続柄3コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zokucd3','000_tt_afjumin_042','続柄3コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,18','【住民基本台帳】住民情報テーブル','続柄コード3',NULL,'system','2023-01-01','system','2023-01-01');
--続柄3名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_zokucd3_nm.nm','000_tt_afjumin_043','続柄3名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_zokucd3_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','続柄コード3',NULL,'system','2023-01-01','system','2023-01-01');
--続柄3CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zokucd3 || '':'' || tt_afjumin_zokucd3_nm.nm','000_tt_afjumin_044','続柄3CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_zokucd3_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','続柄コード3',NULL,'system','2023-01-01','system','2023-01-01');
--続柄4コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zokucd4','000_tt_afjumin_045','続柄4コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,18','【住民基本台帳】住民情報テーブル','続柄コード4',NULL,'system','2023-01-01','system','2023-01-01');
--続柄4名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_zokucd4_nm.nm','000_tt_afjumin_046','続柄4名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_zokucd4_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','続柄コード4',NULL,'system','2023-01-01','system','2023-01-01');
--続柄4CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zokucd4 || '':'' || tt_afjumin_zokucd4_nm.nm','000_tt_afjumin_047','続柄4CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_zokucd4_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','続柄コード4',NULL,'system','2023-01-01','system','2023-01-01');
--続柄表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zokuhyoki','000_tt_afjumin_048','続柄表記',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住所_市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.adrs_sikucd','000_tt_afjumin_049','住所_市区町村コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_町字コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.adrs_tyoazacd','000_tt_afjumin_050','住所_町字コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tosi_gyoseikucd','000_tt_afjumin_051','指定都市_行政区等コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','3019,100004','【住民基本台帳】住民情報テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_tosi_gyoseikucd_nm.nm','000_tt_afjumin_052','指定都市_行政区等名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_tosi_gyoseikucd_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tosi_gyoseikucd || '':'' || tt_afjumin_tosi_gyoseikucd_nm.nm','000_tt_afjumin_053','指定都市_行政区等CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_tosi_gyoseikucd_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--住所_都道府県
INSERT INTO tm_eutableitem VALUES('tt_afjumin.adrs_todofuken','000_tt_afjumin_054','住所_都道府県',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_市区郡町村名
INSERT INTO tm_eutableitem VALUES('tt_afjumin.adrs_sikunm','000_tt_afjumin_055','住所_市区郡町村名',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_町字
INSERT INTO tm_eutableitem VALUES('tt_afjumin.adrs_tyoaza','000_tt_afjumin_056','住所_町字',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_番地号表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin.adrs_bantihyoki','000_tt_afjumin_057','住所_番地号表記',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_番地枝番数値
INSERT INTO tm_eutableitem VALUES('tt_afjumin.adrs_bantiedanum','000_tt_afjumin_058','住所_番地枝番数値',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_方書コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.adrs_katagakicd','000_tt_afjumin_059','住所_方書コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_方書
INSERT INTO tm_eutableitem VALUES('tt_afjumin.adrs_katagaki','000_tt_afjumin_060','住所_方書',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_方書_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjumin.adrs_katagaki_kana','000_tt_afjumin_061','住所_方書_フリガナ',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住所_方書''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_郵便番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin.adrs_yubin','000_tt_afjumin_062','住所_郵便番号',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住民となった年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin.juymd','000_tt_afjumin_063','住民となった年月日',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住民となった年月日_不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_afjumin.juymd_fusyoflg','000_tt_afjumin_064','住民となった年月日_不詳フラグ',NULL,1,6,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住民となった年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--住民となった年月日_不詳表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin.juymd_fusyohyoki','000_tt_afjumin_065','住民となった年月日_不詳表記',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','住民となった年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tennyumaeadrs_sikucd','000_tt_afjumin_066','転入前住所_市区町村コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_町字コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tennyumaeadrs_tyoazacd','000_tt_afjumin_067','転入前住所_町字コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_都道府県
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tennyumaeadrs_todofuken','000_tt_afjumin_068','転入前住所_都道府県',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_市区郡町村名
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tennyumaeadrs_sikunm','000_tt_afjumin_069','転入前住所_市区郡町村名',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_町字
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tennyumaeadrs_tyoaza','000_tt_afjumin_070','転入前住所_町字',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_番地号表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tennyumaeadrs_bantihyoki','000_tt_afjumin_071','転入前住所_番地号表記',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_方書
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tennyumaeadrs_katagaki','000_tt_afjumin_072','転入前住所_方書',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_郵便番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tennyumaeadrs_yubin','000_tt_afjumin_073','転入前住所_郵便番号',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_国名コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tennyumaeadrs_kokunmcd','000_tt_afjumin_074','転入前住所_国名コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_国名等
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tennyumaeadrs_kokunm','000_tt_afjumin_075','転入前住所_国名等',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_国外住所
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tennyumaeadrs_gaiadrs','000_tt_afjumin_076','転入前住所_国外住所',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_世帯主氏名
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tennyumaeadrs_senusisimei','000_tt_afjumin_077','転入前住所_世帯主氏名',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tenkyomaeadrs_sikucd','000_tt_afjumin_078','転居前住所_市区町村コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_町字コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tenkyomaeadrs_tyoazacd','000_tt_afjumin_079','転居前住所_町字コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_都道府県
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tenkyomaeadrs_todofuken','000_tt_afjumin_080','転居前住所_都道府県',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_市区郡町村名
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tenkyomaeadrs_sikunm','000_tt_afjumin_081','転居前住所_市区郡町村名',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_町字
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tenkyomaeadrs_tyoaza','000_tt_afjumin_082','転居前住所_町字',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_番地号表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tenkyomaeadrs_bantihyoki','000_tt_afjumin_083','転居前住所_番地号表記',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_方書コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tenkyomaeadrs_katagakicd','000_tt_afjumin_084','転居前住所_方書コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_方書
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tenkyomaeadrs_katagaki','000_tt_afjumin_085','転居前住所_方書',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_方書_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tenkyomaeadrs_katagaki_kana','000_tt_afjumin_086','転居前住所_方書_フリガナ',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転居前住所_方書''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_郵便番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tenkyomaeadrs_yubin','000_tt_afjumin_087','転居前住所_郵便番号',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--消除の届出年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin.todokeymd','000_tt_afjumin_088','消除の届出年月日',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--消除の異動年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin.delidoymd','000_tt_afjumin_089','消除の異動年月日',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--消除の異動年月日_不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_afjumin.delidoymd_fusyoflg','000_tt_afjumin_090','消除の異動年月日_不詳フラグ',NULL,1,6,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','消除の異動年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--消除の異動年月日_不詳表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin.delidoymd_fusyohyoki','000_tt_afjumin_091','消除の異動年月日_不詳表記',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','消除の異動年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--転入通知年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tennyututiymd','000_tt_afjumin_092','転入通知年月日',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutuyoteiadrs_sikucd','000_tt_afjumin_093','転出先住所（予定）_市区町村コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_町字コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutuyoteiadrs_tyoazacd','000_tt_afjumin_094','転出先住所（予定）_町字コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_都道府県
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutuyoteiadrs_todofuken','000_tt_afjumin_095','転出先住所（予定）_都道府県',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_市区郡町村名
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutuyoteiadrs_sikunm','000_tt_afjumin_096','転出先住所（予定）_市区郡町村名',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_町字
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutuyoteiadrs_tyoaza','000_tt_afjumin_097','転出先住所（予定）_町字',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_番地号表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutuyoteiadrs_bantihyoki','000_tt_afjumin_098','転出先住所（予定）_番地号表記',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_方書
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutuyoteiadrs_katagaki','000_tt_afjumin_099','転出先住所（予定）_方書',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_国名コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutuyoteiadrs_kokunmcd','000_tt_afjumin_100','転出先住所（予定）_国名コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_国名等
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutuyoteiadrs_kokunm','000_tt_afjumin_101','転出先住所（予定）_国名等',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_国外住所
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutuyoteiadrs_gaiadrs','000_tt_afjumin_102','転出先住所（予定）_国外住所',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_郵便番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutuyoteiadrs_yubin','000_tt_afjumin_103','転出先住所（予定）_郵便番号',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutukakuteiadrs_sikucd','000_tt_afjumin_104','転出先住所（確定）_市区町村コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_町字コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutukakuteiadrs_tyoazacd','000_tt_afjumin_105','転出先住所（確定）_町字コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_都道府県
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutukakuteiadrs_todofuken','000_tt_afjumin_106','転出先住所（確定）_都道府県',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_市区郡町村名
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutukakuteiadrs_sikunm','000_tt_afjumin_107','転出先住所（確定）_市区郡町村名',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_町字
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutukakuteiadrs_tyoaza','000_tt_afjumin_108','転出先住所（確定）_町字',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_番地号表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutukakuteiadrs_bantihyoki','000_tt_afjumin_109','転出先住所（確定）_番地号表記',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_方書
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutukakuteiadrs_katagaki','000_tt_afjumin_110','転出先住所（確定）_方書',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_郵便番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tensyutukakuteiadrs_yubin','000_tt_afjumin_111','転出先住所（確定）_郵便番号',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--外国人住民となった年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin.gaijuymd','000_tt_afjumin_112','外国人住民となった年月日',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--外国人住民となった年月日_不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_afjumin.gaijuymd_fusyoflg','000_tt_afjumin_113','外国人住民となった年月日_不詳フラグ',NULL,1,6,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','外国人住民となった年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--外国人住民となった年月日_不詳表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin.gaijuymd_fusyohyoki','000_tt_afjumin_114','外国人住民となった年月日_不詳表記',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','外国人住民となった年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--国籍等_国名コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.kokunmcd','000_tt_afjumin_115','国籍等_国名コード',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','国籍等''',NULL,'system','2023-01-01','system','2023-01-01');
--国籍名等
INSERT INTO tm_eutableitem VALUES('tt_afjumin.kokunm','000_tt_afjumin_116','国籍名等',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--第30条45規定区分コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.kiteikbn','000_tt_afjumin_117','第30条45規定区分コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,8','【住民基本台帳】住民情報テーブル','第30条45規定区分',NULL,'system','2023-01-01','system','2023-01-01');
--第30条45規定区分名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_kiteikbn_nm.nm','000_tt_afjumin_118','第30条45規定区分名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_kiteikbn_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','第30条45規定区分',NULL,'system','2023-01-01','system','2023-01-01');
--第30条45規定区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.kiteikbn || '':'' || tt_afjumin_kiteikbn_nm.nm','000_tt_afjumin_119','第30条45規定区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_kiteikbn_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','第30条45規定区分',NULL,'system','2023-01-01','system','2023-01-01');
--在留資格等コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zairyucd','000_tt_afjumin_120','在留資格等コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,10','【住民基本台帳】住民情報テーブル','在留資格等コード',NULL,'system','2023-01-01','system','2023-01-01');
--在留資格等名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_zairyucd_nm.nm','000_tt_afjumin_121','在留資格等名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_zairyucd_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','在留資格等コード',NULL,'system','2023-01-01','system','2023-01-01');
--在留資格等CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zairyucd || '':'' || tt_afjumin_zairyucd_nm.nm','000_tt_afjumin_122','在留資格等CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_zairyucd_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','在留資格等コード',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_年コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zairyucd_year','000_tt_afjumin_123','在留期間等_年コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,11','【住民基本台帳】住民情報テーブル','在留期間等コード_年',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_年名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_zairyucd_year_nm.nm','000_tt_afjumin_124','在留期間等_年名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_zairyucd_year_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','在留期間等コード_年',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_年CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zairyucd_year || '':'' || tt_afjumin_zairyucd_year_nm.nm','000_tt_afjumin_125','在留期間等_年CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_zairyucd_year_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','在留期間等コード_年',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_月コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zairyucd_month','000_tt_afjumin_126','在留期間等_月コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,12','【住民基本台帳】住民情報テーブル','在留期間等コード_月',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_月名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_zairyucd_month_nm.nm','000_tt_afjumin_127','在留期間等_月名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_zairyucd_month_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','在留期間等コード_月',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_月CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zairyucd_month || '':'' || tt_afjumin_zairyucd_month_nm.nm','000_tt_afjumin_128','在留期間等_月CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_zairyucd_month_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','在留期間等コード_月',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_日コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zairyucd_day','000_tt_afjumin_129','在留期間等_日コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'111','2001,13','【住民基本台帳】住民情報テーブル','在留期間等コード_日',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_日名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_zairyucd_day_nm.nm','000_tt_afjumin_130','在留期間等_日名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_zairyucd_day_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','在留期間等コード_日',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_日CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zairyucd_day || '':'' || tt_afjumin_zairyucd_day_nm.nm','000_tt_afjumin_131','在留期間等_日CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_zairyucd_day_nm',NULL,NULL,'【住民基本台帳】住民情報テーブル','在留期間等コード_日',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間の満了の日
INSERT INTO tm_eutableitem VALUES('tt_afjumin.zairyumanryoymd','000_tt_afjumin_132','在留期間の満了の日',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--地区管理1コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd1','000_tt_afjumin_133','地区管理1コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'251','1','【住民基本台帳】住民情報テーブル','地区管理コード1',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理1名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_tikukanricd1_tikunm.tikunm','000_tt_afjumin_134','地区管理1名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_tikukanricd1_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード1',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理1CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd1 || '':'' || tt_afjumin_tikukanricd1_tikunm.tikunm','000_tt_afjumin_135','地区管理1CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_tikukanricd1_tikunm',NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード1',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理2コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd2','000_tt_afjumin_136','地区管理2コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'251','2','【住民基本台帳】住民情報テーブル','地区管理コード2',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理2名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_tikukanricd2_tikunm.tikunm','000_tt_afjumin_137','地区管理2名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_tikukanricd2_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード2',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理2CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd2 || '':'' || tt_afjumin_tikukanricd2_tikunm.tikunm','000_tt_afjumin_138','地区管理2CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_tikukanricd2_tikunm',NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード2',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理3コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd3','000_tt_afjumin_139','地区管理3コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'251','3','【住民基本台帳】住民情報テーブル','地区管理コード3',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理3名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_tikukanricd3_tikunm.tikunm','000_tt_afjumin_140','地区管理3名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_tikukanricd3_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード3',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理3CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd3 || '':'' || tt_afjumin_tikukanricd3_tikunm.tikunm','000_tt_afjumin_141','地区管理3CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_tikukanricd3_tikunm',NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード3',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理4コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd4','000_tt_afjumin_142','地区管理4コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'251','4','【住民基本台帳】住民情報テーブル','地区管理コード4',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理4名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_tikukanricd4_tikunm.tikunm','000_tt_afjumin_143','地区管理4名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_tikukanricd4_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード4',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理4CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd4 || '':'' || tt_afjumin_tikukanricd4_tikunm.tikunm','000_tt_afjumin_144','地区管理4CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_tikukanricd4_tikunm',NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード4',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理5コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd5','000_tt_afjumin_145','地区管理5コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'251','5','【住民基本台帳】住民情報テーブル','地区管理コード5',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理5名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_tikukanricd5_tikunm.tikunm','000_tt_afjumin_146','地区管理5名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_tikukanricd5_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード5',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理5CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd5 || '':'' || tt_afjumin_tikukanricd5_tikunm.tikunm','000_tt_afjumin_147','地区管理5CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_tikukanricd5_tikunm',NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード5',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理6コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd6','000_tt_afjumin_148','地区管理6コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'251','6','【住民基本台帳】住民情報テーブル','地区管理コード6',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理6名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_tikukanricd6_tikunm.tikunm','000_tt_afjumin_149','地区管理6名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_tikukanricd6_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード6',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理6CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd6 || '':'' || tt_afjumin_tikukanricd6_tikunm.tikunm','000_tt_afjumin_150','地区管理6CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_tikukanricd6_tikunm',NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード6',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理7コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd7','000_tt_afjumin_151','地区管理7コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'251','7','【住民基本台帳】住民情報テーブル','地区管理コード7',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理7名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_tikukanricd7_tikunm.tikunm','000_tt_afjumin_152','地区管理7名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_tikukanricd7_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード7',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理7CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd7 || '':'' || tt_afjumin_tikukanricd7_tikunm.tikunm','000_tt_afjumin_153','地区管理7CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_tikukanricd7_tikunm',NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード7',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理8コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd8','000_tt_afjumin_154','地区管理8コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'251','8','【住民基本台帳】住民情報テーブル','地区管理コード8',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理8名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_tikukanricd8_tikunm.tikunm','000_tt_afjumin_155','地区管理8名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_tikukanricd8_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード8',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理8CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd8 || '':'' || tt_afjumin_tikukanricd8_tikunm.tikunm','000_tt_afjumin_156','地区管理8CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_tikukanricd8_tikunm',NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード8',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理9コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd9','000_tt_afjumin_157','地区管理9コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'251','9','【住民基本台帳】住民情報テーブル','地区管理コード9',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理9名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_tikukanricd9_tikunm.tikunm','000_tt_afjumin_158','地区管理9名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_tikukanricd9_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード9',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理9CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd9 || '':'' || tt_afjumin_tikukanricd9_tikunm.tikunm','000_tt_afjumin_159','地区管理9CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_tikukanricd9_tikunm',NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード9',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理10コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd10','000_tt_afjumin_160','地区管理10コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin',NULL,'251','10','【住民基本台帳】住民情報テーブル','地区管理コード10',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理10名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_tikukanricd10_tikunm.tikunm','000_tt_afjumin_161','地区管理10名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_tikukanricd10_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード10',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理10CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin.tikukanricd10 || '':'' || tt_afjumin_tikukanricd10_tikunm.tikunm','000_tt_afjumin_162','地区管理10CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin','tt_afjumin_tikukanricd10_tikunm',NULL,NULL,'【住民基本台帳】住民情報テーブル','地区管理コード10',NULL,'system','2023-01-01','system','2023-01-01');
--個人番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin.personalno','000_tt_afjumin_163','個人番号',NULL,1,3,True,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afjumin.reguserid','000_tt_afjumin_164','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afjumin.regdttm','000_tt_afjumin_165','登録日時',NULL,1,4,False,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afjumin.upduserid','000_tt_afjumin_166','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afjumin.upddttm','000_tt_afjumin_167','更新日時',NULL,1,4,False,1,'1','1','tt_afjumin',NULL,NULL,NULL,'【住民基本台帳】住民情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.atenano','000_tt_afjumin_reki_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.kojinrirekino','000_tt_afjumin_reki_002','個人履歴番号',NULL,1,1,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人履歴番号_枝番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.kojinrireki_edano','000_tt_afjumin_reki_003','個人履歴番号_枝番号',NULL,1,1,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','個人履歴番号''',NULL,'system','2023-01-01','system','2023-01-01');
--世帯番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.setaino','000_tt_afjumin_reki_004','世帯番号',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住民種別コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.juminsyubetu','000_tt_afjumin_reki_005','住民種別コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,4','【住民基本台帳】住民情報履歴テーブル','住民種別',NULL,'system','2023-01-01','system','2023-01-01');
--住民種別名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_juminsyubetu_nm.nm','000_tt_afjumin_reki_006','住民種別名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_juminsyubetu_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住民種別',NULL,'system','2023-01-01','system','2023-01-01');
--住民種別CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.juminsyubetu || '':'' || tt_afjumin_reki_juminsyubetu_nm.nm','000_tt_afjumin_reki_007','住民種別CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_juminsyubetu_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住民種別',NULL,'system','2023-01-01','system','2023-01-01');
--住民状態コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.juminjotai','000_tt_afjumin_reki_008','住民状態コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,5','【住民基本台帳】住民情報履歴テーブル','住民状態',NULL,'system','2023-01-01','system','2023-01-01');
--住民状態名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_juminjotai_nm.nm','000_tt_afjumin_reki_009','住民状態名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_juminjotai_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住民状態',NULL,'system','2023-01-01','system','2023-01-01');
--住民状態CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.juminjotai || '':'' || tt_afjumin_reki_juminjotai_nm.nm','000_tt_afjumin_reki_010','住民状態CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_juminjotai_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住民状態',NULL,'system','2023-01-01','system','2023-01-01');
--異動年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.idoymd','000_tt_afjumin_reki_011','異動年月日',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--異動年月日_不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.idoymd_fusyoflg','000_tt_afjumin_reki_012','異動年月日_不詳フラグ',NULL,1,6,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','異動年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--異動年月日_不詳表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.idoymd_fusyohyoki','000_tt_afjumin_reki_013','異動年月日_不詳表記',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','異動年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--異動届出年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.idotodokeymd','000_tt_afjumin_reki_014','異動届出年月日',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--異動事由コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.idojiyu','000_tt_afjumin_reki_015','異動事由コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,20~22','【住民基本台帳】住民情報履歴テーブル','異動事由',NULL,'system','2023-01-01','system','2023-01-01');
--異動事由名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_idojiyu_nm.nm','000_tt_afjumin_reki_016','異動事由名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_idojiyu_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','異動事由',NULL,'system','2023-01-01','system','2023-01-01');
--異動事由CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.idojiyu || '':'' || tt_afjumin_reki_idojiyu_nm.nm','000_tt_afjumin_reki_017','異動事由CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_idojiyu_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','異動事由',NULL,'system','2023-01-01','system','2023-01-01');
--氏名
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.simei','000_tt_afjumin_reki_018','氏名',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--氏名_外国人ローマ字
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.simei_gairoma','000_tt_afjumin_reki_019','氏名_外国人ローマ字',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_外国人漢字
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.simei_gaikanji','000_tt_afjumin_reki_020','氏名_外国人漢字',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.simei_kana','000_tt_afjumin_reki_021','氏名_フリガナ',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--旧氏
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.kyusi','000_tt_afjumin_reki_022','旧氏',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--旧氏_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.kyusi_kana','000_tt_afjumin_reki_023','旧氏_フリガナ',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','旧氏''',NULL,'system','2023-01-01','system','2023-01-01');
--通称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tusyo','000_tt_afjumin_reki_024','通称',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--通称_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tusyo_kana','000_tt_afjumin_reki_025','通称_フリガナ',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','通称''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名優先区分コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.simeiyusenkbn','000_tt_afjumin_reki_026','氏名優先区分コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,14','【住民基本台帳】住民情報履歴テーブル','氏名優先区分',NULL,'system','2023-01-01','system','2023-01-01');
--氏名優先区分名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_simeiyusenkbn_nm.nm','000_tt_afjumin_reki_027','氏名優先区分名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_simeiyusenkbn_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','氏名優先区分',NULL,'system','2023-01-01','system','2023-01-01');
--氏名優先区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.simeiyusenkbn || '':'' || tt_afjumin_reki_simeiyusenkbn_nm.nm','000_tt_afjumin_reki_028','氏名優先区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_simeiyusenkbn_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','氏名優先区分',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_優先
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.simei_yusen','000_tt_afjumin_reki_029','氏名_優先',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_フリガナ_優先
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.simei_kana_yusen','000_tt_afjumin_reki_030','氏名_フリガナ_優先',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','氏名_フリガナ''',NULL,'system','2023-01-01','system','2023-01-01');
--性別コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.sex','000_tt_afjumin_reki_031','性別コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,1','【住民基本台帳】住民情報履歴テーブル','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_sex_nm.nm','000_tt_afjumin_reki_032','性別名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_sex_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.sex || '':'' || tt_afjumin_reki_sex_nm.nm','000_tt_afjumin_reki_033','性別CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_sex_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.sexhyoki','000_tt_afjumin_reki_034','性別表記',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--生年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.bymd','000_tt_afjumin_reki_035','生年月日',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--生年月日_不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.bymd_fusyoflg','000_tt_afjumin_reki_036','生年月日_不詳フラグ',NULL,1,6,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','生年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--生年月日_不詳表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.bymd_fusyohyoki','000_tt_afjumin_reki_037','生年月日_不詳表記',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','生年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--続柄1コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zokucd1','000_tt_afjumin_reki_038','続柄1コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,18','【住民基本台帳】住民情報履歴テーブル','続柄コード1',NULL,'system','2023-01-01','system','2023-01-01');
--続柄1名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_zokucd1_nm.nm','000_tt_afjumin_reki_039','続柄1名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_zokucd1_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','続柄コード1',NULL,'system','2023-01-01','system','2023-01-01');
--続柄1CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zokucd1 || '':'' || tt_afjumin_reki_zokucd1_nm.nm','000_tt_afjumin_reki_040','続柄1CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_zokucd1_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','続柄コード1',NULL,'system','2023-01-01','system','2023-01-01');
--続柄2コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zokucd2','000_tt_afjumin_reki_041','続柄2コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,18','【住民基本台帳】住民情報履歴テーブル','続柄コード2',NULL,'system','2023-01-01','system','2023-01-01');
--続柄2名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_zokucd2_nm.nm','000_tt_afjumin_reki_042','続柄2名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_zokucd2_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','続柄コード2',NULL,'system','2023-01-01','system','2023-01-01');
--続柄2CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zokucd2 || '':'' || tt_afjumin_reki_zokucd2_nm.nm','000_tt_afjumin_reki_043','続柄2CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_zokucd2_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','続柄コード2',NULL,'system','2023-01-01','system','2023-01-01');
--続柄3コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zokucd3','000_tt_afjumin_reki_044','続柄3コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,18','【住民基本台帳】住民情報履歴テーブル','続柄コード3',NULL,'system','2023-01-01','system','2023-01-01');
--続柄3名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_zokucd3_nm.nm','000_tt_afjumin_reki_045','続柄3名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_zokucd3_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','続柄コード3',NULL,'system','2023-01-01','system','2023-01-01');
--続柄3CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zokucd3 || '':'' || tt_afjumin_reki_zokucd3_nm.nm','000_tt_afjumin_reki_046','続柄3CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_zokucd3_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','続柄コード3',NULL,'system','2023-01-01','system','2023-01-01');
--続柄4コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zokucd4','000_tt_afjumin_reki_047','続柄4コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,18','【住民基本台帳】住民情報履歴テーブル','続柄コード4',NULL,'system','2023-01-01','system','2023-01-01');
--続柄4名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_zokucd4_nm.nm','000_tt_afjumin_reki_048','続柄4名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_zokucd4_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','続柄コード4',NULL,'system','2023-01-01','system','2023-01-01');
--続柄4CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zokucd4 || '':'' || tt_afjumin_reki_zokucd4_nm.nm','000_tt_afjumin_reki_049','続柄4CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_zokucd4_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','続柄コード4',NULL,'system','2023-01-01','system','2023-01-01');
--続柄表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zokuhyoki','000_tt_afjumin_reki_050','続柄表記',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住所_市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.adrs_sikucd','000_tt_afjumin_reki_051','住所_市区町村コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_町字コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.adrs_tyoazacd','000_tt_afjumin_reki_052','住所_町字コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tosi_gyoseikucd','000_tt_afjumin_reki_053','指定都市_行政区等コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','3019,100004','【住民基本台帳】住民情報履歴テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_tosi_gyoseikucd_nm.nm','000_tt_afjumin_reki_054','指定都市_行政区等名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_tosi_gyoseikucd_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tosi_gyoseikucd || '':'' || tt_afjumin_reki_tosi_gyoseikucd_nm.nm','000_tt_afjumin_reki_055','指定都市_行政区等CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_tosi_gyoseikucd_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--住所_都道府県
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.adrs_todofuken','000_tt_afjumin_reki_056','住所_都道府県',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_市区郡町村名
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.adrs_sikunm','000_tt_afjumin_reki_057','住所_市区郡町村名',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_町字
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.adrs_tyoaza','000_tt_afjumin_reki_058','住所_町字',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_番地号表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.adrs_bantihyoki','000_tt_afjumin_reki_059','住所_番地号表記',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_番地枝番数値
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.adrs_bantiedanum','000_tt_afjumin_reki_060','住所_番地枝番数値',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_方書コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.adrs_katagakicd','000_tt_afjumin_reki_061','住所_方書コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_方書
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.adrs_katagaki','000_tt_afjumin_reki_062','住所_方書',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_方書_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.adrs_katagaki_kana','000_tt_afjumin_reki_063','住所_方書_フリガナ',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住所_方書''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_郵便番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.adrs_yubin','000_tt_afjumin_reki_064','住所_郵便番号',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住民となった年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.juymd','000_tt_afjumin_reki_065','住民となった年月日',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住民となった年月日_不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.juymd_fusyoflg','000_tt_afjumin_reki_066','住民となった年月日_不詳フラグ',NULL,1,6,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住民となった年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--住民となった年月日_不詳表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.juymd_fusyohyoki','000_tt_afjumin_reki_067','住民となった年月日_不詳表記',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','住民となった年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tennyumaeadrs_sikucd','000_tt_afjumin_reki_068','転入前住所_市区町村コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_町字コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tennyumaeadrs_tyoazacd','000_tt_afjumin_reki_069','転入前住所_町字コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_都道府県
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tennyumaeadrs_todofuken','000_tt_afjumin_reki_070','転入前住所_都道府県',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_市区郡町村名
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tennyumaeadrs_sikunm','000_tt_afjumin_reki_071','転入前住所_市区郡町村名',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_町字
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tennyumaeadrs_tyoaza','000_tt_afjumin_reki_072','転入前住所_町字',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_番地号表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tennyumaeadrs_bantihyoki','000_tt_afjumin_reki_073','転入前住所_番地号表記',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_方書
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tennyumaeadrs_katagaki','000_tt_afjumin_reki_074','転入前住所_方書',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_郵便番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tennyumaeadrs_yubin','000_tt_afjumin_reki_075','転入前住所_郵便番号',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_国名コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tennyumaeadrs_kokunmcd','000_tt_afjumin_reki_076','転入前住所_国名コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_国名等
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tennyumaeadrs_kokunm','000_tt_afjumin_reki_077','転入前住所_国名等',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_国外住所
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tennyumaeadrs_gaiadrs','000_tt_afjumin_reki_078','転入前住所_国外住所',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転入前住所_世帯主氏名
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tennyumaeadrs_senusisimei','000_tt_afjumin_reki_079','転入前住所_世帯主氏名',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転入前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tenkyomaeadrs_sikucd','000_tt_afjumin_reki_080','転居前住所_市区町村コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_町字コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tenkyomaeadrs_tyoazacd','000_tt_afjumin_reki_081','転居前住所_町字コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_都道府県
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tenkyomaeadrs_todofuken','000_tt_afjumin_reki_082','転居前住所_都道府県',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_市区郡町村名
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tenkyomaeadrs_sikunm','000_tt_afjumin_reki_083','転居前住所_市区郡町村名',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_町字
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tenkyomaeadrs_tyoaza','000_tt_afjumin_reki_084','転居前住所_町字',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_番地号表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tenkyomaeadrs_bantihyoki','000_tt_afjumin_reki_085','転居前住所_番地号表記',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_方書コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tenkyomaeadrs_katagakicd','000_tt_afjumin_reki_086','転居前住所_方書コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_方書
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tenkyomaeadrs_katagaki','000_tt_afjumin_reki_087','転居前住所_方書',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_方書_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tenkyomaeadrs_katagaki_kana','000_tt_afjumin_reki_088','転居前住所_方書_フリガナ',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転居前住所_方書''',NULL,'system','2023-01-01','system','2023-01-01');
--転居前住所_郵便番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tenkyomaeadrs_yubin','000_tt_afjumin_reki_089','転居前住所_郵便番号',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転居前住所''',NULL,'system','2023-01-01','system','2023-01-01');
--消除の届出年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.todokeymd','000_tt_afjumin_reki_090','消除の届出年月日',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--消除の異動年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.delidoymd','000_tt_afjumin_reki_091','消除の異動年月日',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--消除の異動年月日_不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.delidoymd_fusyoflg','000_tt_afjumin_reki_092','消除の異動年月日_不詳フラグ',NULL,1,6,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','消除の異動年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--消除の異動年月日_不詳表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.delidoymd_fusyohyoki','000_tt_afjumin_reki_093','消除の異動年月日_不詳表記',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','消除の異動年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--転入通知年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tennyututiymd','000_tt_afjumin_reki_094','転入通知年月日',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutuyoteiadrs_sikucd','000_tt_afjumin_reki_095','転出先住所（予定）_市区町村コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_町字コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutuyoteiadrs_tyoazacd','000_tt_afjumin_reki_096','転出先住所（予定）_町字コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_都道府県
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutuyoteiadrs_todofuken','000_tt_afjumin_reki_097','転出先住所（予定）_都道府県',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_市区郡町村名
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutuyoteiadrs_sikunm','000_tt_afjumin_reki_098','転出先住所（予定）_市区郡町村名',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_町字
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutuyoteiadrs_tyoaza','000_tt_afjumin_reki_099','転出先住所（予定）_町字',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_番地号表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutuyoteiadrs_bantihyoki','000_tt_afjumin_reki_100','転出先住所（予定）_番地号表記',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_方書
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutuyoteiadrs_katagaki','000_tt_afjumin_reki_101','転出先住所（予定）_方書',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_国名コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutuyoteiadrs_kokunmcd','000_tt_afjumin_reki_102','転出先住所（予定）_国名コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_国名等
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutuyoteiadrs_kokunm','000_tt_afjumin_reki_103','転出先住所（予定）_国名等',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_国外住所
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutuyoteiadrs_gaiadrs','000_tt_afjumin_reki_104','転出先住所（予定）_国外住所',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（予定）_郵便番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutuyoteiadrs_yubin','000_tt_afjumin_reki_105','転出先住所（予定）_郵便番号',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（予定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutukakuteiadrs_sikucd','000_tt_afjumin_reki_106','転出先住所（確定）_市区町村コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_町字コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutukakuteiadrs_tyoazacd','000_tt_afjumin_reki_107','転出先住所（確定）_町字コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_都道府県
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutukakuteiadrs_todofuken','000_tt_afjumin_reki_108','転出先住所（確定）_都道府県',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_市区郡町村名
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutukakuteiadrs_sikunm','000_tt_afjumin_reki_109','転出先住所（確定）_市区郡町村名',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_町字
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutukakuteiadrs_tyoaza','000_tt_afjumin_reki_110','転出先住所（確定）_町字',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_番地号表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutukakuteiadrs_bantihyoki','000_tt_afjumin_reki_111','転出先住所（確定）_番地号表記',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_方書
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutukakuteiadrs_katagaki','000_tt_afjumin_reki_112','転出先住所（確定）_方書',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--転出先住所（確定）_郵便番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tensyutukakuteiadrs_yubin','000_tt_afjumin_reki_113','転出先住所（確定）_郵便番号',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','転出先住所（確定）''',NULL,'system','2023-01-01','system','2023-01-01');
--外国人住民となった年月日
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.gaijuymd','000_tt_afjumin_reki_114','外国人住民となった年月日',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--外国人住民となった年月日_不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.gaijuymd_fusyoflg','000_tt_afjumin_reki_115','外国人住民となった年月日_不詳フラグ',NULL,1,6,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','外国人住民となった年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--外国人住民となった年月日_不詳表記
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.gaijuymd_fusyohyoki','000_tt_afjumin_reki_116','外国人住民となった年月日_不詳表記',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','外国人住民となった年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--国籍等_国名コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.kokunmcd','000_tt_afjumin_reki_117','国籍等_国名コード',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','国籍等''',NULL,'system','2023-01-01','system','2023-01-01');
--国籍名等
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.kokunm','000_tt_afjumin_reki_118','国籍名等',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--第30条45規定区分コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.kiteikbn','000_tt_afjumin_reki_119','第30条45規定区分コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,8','【住民基本台帳】住民情報履歴テーブル','第30条45規定区分',NULL,'system','2023-01-01','system','2023-01-01');
--第30条45規定区分名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_kiteikbn_nm.nm','000_tt_afjumin_reki_120','第30条45規定区分名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_kiteikbn_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','第30条45規定区分',NULL,'system','2023-01-01','system','2023-01-01');
--第30条45規定区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.kiteikbn || '':'' || tt_afjumin_reki_kiteikbn_nm.nm','000_tt_afjumin_reki_121','第30条45規定区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_kiteikbn_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','第30条45規定区分',NULL,'system','2023-01-01','system','2023-01-01');
--在留資格等コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zairyucd','000_tt_afjumin_reki_122','在留資格等コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,10','【住民基本台帳】住民情報履歴テーブル','在留資格等コード',NULL,'system','2023-01-01','system','2023-01-01');
--在留資格等名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_zairyucd_nm.nm','000_tt_afjumin_reki_123','在留資格等名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_zairyucd_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','在留資格等コード',NULL,'system','2023-01-01','system','2023-01-01');
--在留資格等CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zairyucd || '':'' || tt_afjumin_reki_zairyucd_nm.nm','000_tt_afjumin_reki_124','在留資格等CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_zairyucd_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','在留資格等コード',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_年コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zairyucd_year','000_tt_afjumin_reki_125','在留期間等_年コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,11','【住民基本台帳】住民情報履歴テーブル','在留期間等コード_年',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_年名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_zairyucd_year_nm.nm','000_tt_afjumin_reki_126','在留期間等_年名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_zairyucd_year_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','在留期間等コード_年',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_年CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zairyucd_year || '':'' || tt_afjumin_reki_zairyucd_year_nm.nm','000_tt_afjumin_reki_127','在留期間等_年CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_zairyucd_year_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','在留期間等コード_年',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_月コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zairyucd_month','000_tt_afjumin_reki_128','在留期間等_月コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,12','【住民基本台帳】住民情報履歴テーブル','在留期間等コード_月',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_月名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_zairyucd_month_nm.nm','000_tt_afjumin_reki_129','在留期間等_月名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_zairyucd_month_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','在留期間等コード_月',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_月CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zairyucd_month || '':'' || tt_afjumin_reki_zairyucd_month_nm.nm','000_tt_afjumin_reki_130','在留期間等_月CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_zairyucd_month_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','在留期間等コード_月',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_日コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zairyucd_day','000_tt_afjumin_reki_131','在留期間等_日コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'111','2001,13','【住民基本台帳】住民情報履歴テーブル','在留期間等コード_日',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_日名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_zairyucd_day_nm.nm','000_tt_afjumin_reki_132','在留期間等_日名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_zairyucd_day_nm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','在留期間等コード_日',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間等_日CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zairyucd_day || '':'' || tt_afjumin_reki_zairyucd_day_nm.nm','000_tt_afjumin_reki_133','在留期間等_日CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_zairyucd_day_nm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','在留期間等コード_日',NULL,'system','2023-01-01','system','2023-01-01');
--在留期間の満了の日
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.zairyumanryoymd','000_tt_afjumin_reki_134','在留期間の満了の日',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--地区管理1コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd1','000_tt_afjumin_reki_135','地区管理1コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'251','1','【住民基本台帳】住民情報履歴テーブル','地区管理コード1',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理1名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_tikukanricd1_tikunm.tikunm','000_tt_afjumin_reki_136','地区管理1名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_tikukanricd1_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード1',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理1CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd1 || '':'' || tt_afjumin_reki_tikukanricd1_tikunm.tikunm','000_tt_afjumin_reki_137','地区管理1CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_tikukanricd1_tikunm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード1',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理2コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd2','000_tt_afjumin_reki_138','地区管理2コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'251','2','【住民基本台帳】住民情報履歴テーブル','地区管理コード2',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理2名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_tikukanricd2_tikunm.tikunm','000_tt_afjumin_reki_139','地区管理2名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_tikukanricd2_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード2',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理2CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd2 || '':'' || tt_afjumin_reki_tikukanricd2_tikunm.tikunm','000_tt_afjumin_reki_140','地区管理2CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_tikukanricd2_tikunm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード2',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理3コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd3','000_tt_afjumin_reki_141','地区管理3コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'251','3','【住民基本台帳】住民情報履歴テーブル','地区管理コード3',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理3名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_tikukanricd3_tikunm.tikunm','000_tt_afjumin_reki_142','地区管理3名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_tikukanricd3_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード3',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理3CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd3 || '':'' || tt_afjumin_reki_tikukanricd3_tikunm.tikunm','000_tt_afjumin_reki_143','地区管理3CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_tikukanricd3_tikunm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード3',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理4コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd4','000_tt_afjumin_reki_144','地区管理4コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'251','4','【住民基本台帳】住民情報履歴テーブル','地区管理コード4',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理4名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_tikukanricd4_tikunm.tikunm','000_tt_afjumin_reki_145','地区管理4名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_tikukanricd4_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード4',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理4CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd4 || '':'' || tt_afjumin_reki_tikukanricd4_tikunm.tikunm','000_tt_afjumin_reki_146','地区管理4CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_tikukanricd4_tikunm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード4',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理5コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd5','000_tt_afjumin_reki_147','地区管理5コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'251','5','【住民基本台帳】住民情報履歴テーブル','地区管理コード5',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理5名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_tikukanricd5_tikunm.tikunm','000_tt_afjumin_reki_148','地区管理5名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_tikukanricd5_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード5',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理5CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd5 || '':'' || tt_afjumin_reki_tikukanricd5_tikunm.tikunm','000_tt_afjumin_reki_149','地区管理5CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_tikukanricd5_tikunm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード5',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理6コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd6','000_tt_afjumin_reki_150','地区管理6コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'251','6','【住民基本台帳】住民情報履歴テーブル','地区管理コード6',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理6名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_tikukanricd6_tikunm.tikunm','000_tt_afjumin_reki_151','地区管理6名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_tikukanricd6_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード6',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理6CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd6 || '':'' || tt_afjumin_reki_tikukanricd6_tikunm.tikunm','000_tt_afjumin_reki_152','地区管理6CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_tikukanricd6_tikunm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード6',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理7コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd7','000_tt_afjumin_reki_153','地区管理7コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'251','7','【住民基本台帳】住民情報履歴テーブル','地区管理コード7',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理7名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_tikukanricd7_tikunm.tikunm','000_tt_afjumin_reki_154','地区管理7名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_tikukanricd7_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード7',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理7CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd7 || '':'' || tt_afjumin_reki_tikukanricd7_tikunm.tikunm','000_tt_afjumin_reki_155','地区管理7CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_tikukanricd7_tikunm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード7',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理8コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd8','000_tt_afjumin_reki_156','地区管理8コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'251','8','【住民基本台帳】住民情報履歴テーブル','地区管理コード8',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理8名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_tikukanricd8_tikunm.tikunm','000_tt_afjumin_reki_157','地区管理8名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_tikukanricd8_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード8',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理8CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd8 || '':'' || tt_afjumin_reki_tikukanricd8_tikunm.tikunm','000_tt_afjumin_reki_158','地区管理8CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_tikukanricd8_tikunm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード8',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理9コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd9','000_tt_afjumin_reki_159','地区管理9コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'251','9','【住民基本台帳】住民情報履歴テーブル','地区管理コード9',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理9名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_tikukanricd9_tikunm.tikunm','000_tt_afjumin_reki_160','地区管理9名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_tikukanricd9_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード9',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理9CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd9 || '':'' || tt_afjumin_reki_tikukanricd9_tikunm.tikunm','000_tt_afjumin_reki_161','地区管理9CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_tikukanricd9_tikunm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード9',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理10コード
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd10','000_tt_afjumin_reki_162','地区管理10コード',NULL,1,3,True,3,'1',NULL,'tt_afjumin_reki',NULL,'251','10','【住民基本台帳】住民情報履歴テーブル','地区管理コード10',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理10名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki_tikukanricd10_tikunm.tikunm','000_tt_afjumin_reki_163','地区管理10名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki_tikukanricd10_tikunm',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード10',NULL,'system','2023-01-01','system','2023-01-01');
--地区管理10CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.tikukanricd10 || '':'' || tt_afjumin_reki_tikukanricd10_tikunm.tikunm','000_tt_afjumin_reki_164','地区管理10CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjumin_reki','tt_afjumin_reki_tikukanricd10_tikunm',NULL,NULL,'【住民基本台帳】住民情報履歴テーブル','地区管理コード10',NULL,'system','2023-01-01','system','2023-01-01');
--個人番号
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.personalno','000_tt_afjumin_reki_165','個人番号',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作者ID
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.renkeimotosousauserid','000_tt_afjumin_reki_166','連携元操作者ID',NULL,1,3,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作日時
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.renkeimotosousadttm','000_tt_afjumin_reki_167','連携元操作日時',NULL,1,4,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--最新フラグ
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.saisinflg','000_tt_afjumin_reki_168','最新フラグ',NULL,1,6,True,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.reguserid','000_tt_afjumin_reki_169','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.regdttm','000_tt_afjumin_reki_170','登録日時',NULL,1,4,False,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.upduserid','000_tt_afjumin_reki_171','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afjumin_reki.upddttm','000_tt_afjumin_reki_172','更新日時',NULL,1,4,False,1,'1','1','tt_afjumin_reki',NULL,NULL,NULL,'【住民基本台帳】住民情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.atenano','000_tt_afjutogai_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.rirekino','000_tt_afjutogai_002','履歴番号',NULL,1,1,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--世帯番号
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.setaino','000_tt_afjutogai_003','世帯番号',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--住登外者種別コード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.jutogaisyasyubetu','000_tt_afjutogai_004','住登外者種別コード',NULL,1,3,True,3,'1',NULL,'tt_afjutogai',NULL,'111','2019,180','住登外者情報テーブル','住登外者種別',NULL,'system','2023-01-01','system','2023-01-01');
--住登外者種別名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_jutogaisyasyubetu_nm.nm','000_tt_afjutogai_005','住登外者種別名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_jutogaisyasyubetu_nm',NULL,NULL,NULL,'住登外者情報テーブル','住登外者種別',NULL,'system','2023-01-01','system','2023-01-01');
--住登外者種別CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.jutogaisyasyubetu || '':'' || tt_afjutogai_jutogaisyasyubetu_nm.nm','000_tt_afjutogai_006','住登外者種別CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai','tt_afjutogai_jutogaisyasyubetu_nm',NULL,NULL,'住登外者情報テーブル','住登外者種別',NULL,'system','2023-01-01','system','2023-01-01');
--住登外者状態コード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.jutogaisyajotai','000_tt_afjutogai_007','住登外者状態コード',NULL,1,3,True,3,'1',NULL,'tt_afjutogai',NULL,'111','2019,181','住登外者情報テーブル','住登外者状態',NULL,'system','2023-01-01','system','2023-01-01');
--住登外者状態名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_jutogaisyajotai_nm.nm','000_tt_afjutogai_008','住登外者状態名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_jutogaisyajotai_nm',NULL,NULL,NULL,'住登外者情報テーブル','住登外者状態',NULL,'system','2023-01-01','system','2023-01-01');
--住登外者状態CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.jutogaisyajotai || '':'' || tt_afjutogai_jutogaisyajotai_nm.nm','000_tt_afjutogai_009','住登外者状態CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai','tt_afjutogai_jutogaisyajotai_nm',NULL,NULL,'住登外者情報テーブル','住登外者状態',NULL,'system','2023-01-01','system','2023-01-01');
--異動年月日
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.idoymd','000_tt_afjutogai_010','異動年月日',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--異動届出年月日
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.idotodokeymd','000_tt_afjutogai_011','異動届出年月日',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--異動事由コード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.idojiyu','000_tt_afjutogai_012','異動事由コード',NULL,1,3,True,3,'1',NULL,'tt_afjutogai',NULL,'111','2019,209','住登外者情報テーブル','異動事由',NULL,'system','2023-01-01','system','2023-01-01');
--異動事由名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_idojiyu_nm.nm','000_tt_afjutogai_013','異動事由名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_idojiyu_nm',NULL,NULL,NULL,'住登外者情報テーブル','異動事由',NULL,'system','2023-01-01','system','2023-01-01');
--異動事由CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.idojiyu || '':'' || tt_afjutogai_idojiyu_nm.nm','000_tt_afjutogai_014','異動事由CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai','tt_afjutogai_idojiyu_nm',NULL,NULL,'住登外者情報テーブル','異動事由',NULL,'system','2023-01-01','system','2023-01-01');
--氏名
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.simei','000_tt_afjutogai_015','氏名',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--氏_日本人
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.si','000_tt_afjutogai_016','氏_日本人',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','氏''',NULL,'system','2023-01-01','system','2023-01-01');
--名_日本人
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.mei','000_tt_afjutogai_017','名_日本人',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','名''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_外国人ローマ字
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.simei_gairoma','000_tt_afjutogai_018','氏名_外国人ローマ字',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_外国人漢字
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.simei_gaikanji','000_tt_afjutogai_019','氏名_外国人漢字',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.simei_kana','000_tt_afjutogai_020','氏名_フリガナ',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_フリガナ_清音化
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.simei_kana_seion','000_tt_afjutogai_021','氏名_フリガナ_清音化',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','氏名_フリガナ''',NULL,'system','2023-01-01','system','2023-01-01');
--氏_日本人_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.si_kana','000_tt_afjutogai_022','氏_日本人_フリガナ',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','氏_日本人''',NULL,'system','2023-01-01','system','2023-01-01');
--氏_日本人_フリガナ_清音化
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.si_kana_seion','000_tt_afjutogai_023','氏_日本人_フリガナ_清音化',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','氏_日本人_フリガナ''',NULL,'system','2023-01-01','system','2023-01-01');
--名_日本人_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.mei_kana','000_tt_afjutogai_024','名_日本人_フリガナ',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','名_日本人''',NULL,'system','2023-01-01','system','2023-01-01');
--名_日本人_フリガナ_清音化
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.mei_kana_seion','000_tt_afjutogai_025','名_日本人_フリガナ_清音化',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','名_日本人_フリガナ''',NULL,'system','2023-01-01','system','2023-01-01');
--通称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.tusyo','000_tt_afjutogai_026','通称',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--通称_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.tusyo_kana','000_tt_afjutogai_027','通称_フリガナ',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','通称''',NULL,'system','2023-01-01','system','2023-01-01');
--通称_フリガナ_清音化
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.tusyo_kana_seion','000_tt_afjutogai_028','通称_フリガナ_清音化',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','通称_フリガナ''',NULL,'system','2023-01-01','system','2023-01-01');
--通称_フリガナ確認状況
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.tusyo_kanastatus','000_tt_afjutogai_029','通称_フリガナ確認状況',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','通称''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_優先
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.simei_yusen','000_tt_afjutogai_030','氏名_優先',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','氏名''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_フリガナ_優先
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.simei_kana_yusen','000_tt_afjutogai_031','氏名_フリガナ_優先',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','氏名_フリガナ''',NULL,'system','2023-01-01','system','2023-01-01');
--氏名_フリガナ_優先_清音化
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.simei_kana_yusen_seion','000_tt_afjutogai_032','氏名_フリガナ_優先_清音化',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','氏名_フリガナ_優先''',NULL,'system','2023-01-01','system','2023-01-01');
--性別コード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.sex','000_tt_afjutogai_033','性別コード',NULL,1,3,True,3,'1',NULL,'tt_afjutogai',NULL,'111','2032,1','住登外者情報テーブル','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_sex_nm.nm','000_tt_afjutogai_034','性別名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_sex_nm',NULL,NULL,NULL,'住登外者情報テーブル','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.sex || '':'' || tt_afjutogai_sex_nm.nm','000_tt_afjutogai_035','性別CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai','tt_afjutogai_sex_nm',NULL,NULL,'住登外者情報テーブル','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別表記
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.sexhyoki','000_tt_afjutogai_036','性別表記',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--生年月日
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.bymd','000_tt_afjutogai_037','生年月日',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--生年月日_不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.bymd_fusyoflg','000_tt_afjutogai_038','生年月日_不詳フラグ',NULL,1,6,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','生年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--生年月日_不詳表記
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.bymd_fusyohyoki','000_tt_afjutogai_039','生年月日_不詳表記',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','生年月日''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.adrs_sikucd','000_tt_afjutogai_040','住所_市区町村コード',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_町字コード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.adrs_tyoazacd','000_tt_afjutogai_041','住所_町字コード',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等コード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.tosi_gyoseikucd','000_tt_afjutogai_042','指定都市_行政区等コード',NULL,1,3,True,3,'1',NULL,'tt_afjutogai',NULL,'111','3019,100004','住登外者情報テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_tosi_gyoseikucd_nm.nm','000_tt_afjutogai_043','指定都市_行政区等名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_tosi_gyoseikucd_nm',NULL,NULL,NULL,'住登外者情報テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.tosi_gyoseikucd || '':'' || tt_afjutogai_tosi_gyoseikucd_nm.nm','000_tt_afjutogai_044','指定都市_行政区等CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai','tt_afjutogai_tosi_gyoseikucd_nm',NULL,NULL,'住登外者情報テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--住所_都道府県
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.adrs_todofuken','000_tt_afjutogai_045','住所_都道府県',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_市区郡町村名
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.adrs_sikunm','000_tt_afjutogai_046','住所_市区郡町村名',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_町字
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.adrs_tyoaza','000_tt_afjutogai_047','住所_町字',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_番地号表記
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.adrs_bantihyoki','000_tt_afjutogai_048','住所_番地号表記',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_方書
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.adrs_katagaki','000_tt_afjutogai_049','住所_方書',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_方書_フリガナ
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.adrs_katagaki_kana','000_tt_afjutogai_050','住所_方書_フリガナ',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','住所_方書''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_郵便番号
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.adrs_yubin','000_tt_afjutogai_051','住所_郵便番号',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_国名コード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.adrs_kokunmcd','000_tt_afjutogai_052','住所_国名コード',NULL,1,3,True,3,'1',NULL,'tt_afjutogai',NULL,'111','3019,100002','住登外者情報テーブル','住所_国名コード',NULL,'system','2023-01-01','system','2023-01-01');
--住所_国名名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_adrs_kokunmcd_nm.nm','000_tt_afjutogai_053','住所_国名名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_adrs_kokunmcd_nm',NULL,NULL,NULL,'住登外者情報テーブル','住所_国名コード',NULL,'system','2023-01-01','system','2023-01-01');
--住所_国名CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.adrs_kokunmcd || '':'' || tt_afjutogai_adrs_kokunmcd_nm.nm','000_tt_afjutogai_054','住所_国名CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai','tt_afjutogai_adrs_kokunmcd_nm',NULL,NULL,'住登外者情報テーブル','住所_国名コード',NULL,'system','2023-01-01','system','2023-01-01');
--住所_国名等
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.adrs_kokunm','000_tt_afjutogai_055','住所_国名等',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_国外住所
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.adrs_gaiadrs','000_tt_afjutogai_056','住所_国外住所',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--保険区分コード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.hokenkbn','000_tt_afjutogai_057','保険区分コード',NULL,1,3,True,3,'1',NULL,'tt_afjutogai',NULL,'111','1001,1','住登外者情報テーブル','保険区分',NULL,'system','2023-01-01','system','2023-01-01');
--保険区分名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_hokenkbn_nm.nm','000_tt_afjutogai_058','保険区分名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_hokenkbn_nm',NULL,NULL,NULL,'住登外者情報テーブル','保険区分',NULL,'system','2023-01-01','system','2023-01-01');
--保険区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.hokenkbn || '':'' || tt_afjutogai_hokenkbn_nm.nm','000_tt_afjutogai_059','保険区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai','tt_afjutogai_hokenkbn_nm',NULL,NULL,'住登外者情報テーブル','保険区分',NULL,'system','2023-01-01','system','2023-01-01');
--名寄せ元フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.nayosemotoflg','000_tt_afjutogai_060','名寄せ元フラグコード',NULL,1,3,True,3,'1',NULL,'tt_afjutogai',NULL,'111','2031,2','住登外者情報テーブル','名寄せ元フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--名寄せ元フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_nayosemotoflg_nm.nm','000_tt_afjutogai_061','名寄せ元フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_nayosemotoflg_nm',NULL,NULL,NULL,'住登外者情報テーブル','名寄せ元フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--名寄せ元フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.nayosemotoflg || '':'' || tt_afjutogai_nayosemotoflg_nm.nm','000_tt_afjutogai_062','名寄せ元フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai','tt_afjutogai_nayosemotoflg_nm',NULL,NULL,'住登外者情報テーブル','名寄せ元フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--名寄せ先宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.nayosesakiatenano','000_tt_afjutogai_063','名寄せ先宛名番号',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--統合宛名フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.togoatenaflg','000_tt_afjutogai_064','統合宛名フラグコード',NULL,1,3,True,3,'1',NULL,'tt_afjutogai',NULL,'111','2032,3','住登外者情報テーブル','統合宛名フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--統合宛名フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_togoatenaflg_nm.nm','000_tt_afjutogai_065','統合宛名フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_togoatenaflg_nm',NULL,NULL,NULL,'住登外者情報テーブル','統合宛名フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--統合宛名フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.togoatenaflg || '':'' || tt_afjutogai_togoatenaflg_nm.nm','000_tt_afjutogai_066','統合宛名フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai','tt_afjutogai_togoatenaflg_nm',NULL,NULL,'住登外者情報テーブル','統合宛名フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--他業務参照不可フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.sansyofukaflg','000_tt_afjutogai_067','他業務参照不可フラグコード',NULL,1,3,True,3,'1',NULL,'tt_afjutogai',NULL,'111','2031,3','住登外者情報テーブル','他業務参照不可フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--他業務参照不可フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_sansyofukaflg_nm.nm','000_tt_afjutogai_068','他業務参照不可フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_sansyofukaflg_nm',NULL,NULL,NULL,'住登外者情報テーブル','他業務参照不可フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--他業務参照不可フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.sansyofukaflg || '':'' || tt_afjutogai_sansyofukaflg_nm.nm','000_tt_afjutogai_069','他業務参照不可フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai','tt_afjutogai_sansyofukaflg_nm',NULL,NULL,'住登外者情報テーブル','他業務参照不可フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--使用停止フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.stopflg','000_tt_afjutogai_070','使用停止フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afjutogai',NULL,'111','1000,44','住登外者情報テーブル','使用停止フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--使用停止フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_stopflg_nm.nm','000_tt_afjutogai_071','使用停止フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_stopflg_nm',NULL,NULL,NULL,'住登外者情報テーブル','使用停止フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--使用停止フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.stopflg || '':'' || tt_afjutogai_stopflg_nm.nm','000_tt_afjutogai_072','使用停止フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai','tt_afjutogai_stopflg_nm',NULL,NULL,'住登外者情報テーブル','使用停止フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作者ID
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.renkeimotosousauserid','000_tt_afjutogai_073','連携元操作者ID',NULL,1,3,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作日時
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.renkeimotosousadttm','000_tt_afjutogai_074','連携元操作日時',NULL,1,4,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--最新フラグ
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.saisinflg','000_tt_afjutogai_075','最新フラグ',NULL,1,6,True,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録部署コード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.regbusyocd','000_tt_afjutogai_076','登録部署コード',NULL,1,3,True,3,'1',NULL,'tt_afjutogai',NULL,'121','3019,100011','住登外者情報テーブル','登録部署',NULL,'system','2023-01-01','system','2023-01-01');
--登録部署名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_regbusyocd_nm.nm','000_tt_afjutogai_077','登録部署名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_regbusyocd_nm',NULL,NULL,NULL,'住登外者情報テーブル','登録部署',NULL,'system','2023-01-01','system','2023-01-01');
--登録部署CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.regbusyocd || '':'' || tt_afjutogai_regbusyocd_nm.nm','000_tt_afjutogai_078','登録部署CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai','tt_afjutogai_regbusyocd_nm',NULL,NULL,'住登外者情報テーブル','登録部署',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.reguserid','000_tt_afjutogai_079','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.regdttm','000_tt_afjutogai_080','登録日時',NULL,1,4,False,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.upduserid','000_tt_afjutogai_081','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afjutogai.upddttm','000_tt_afjutogai_082','更新日時',NULL,1,4,False,1,'1','1','tt_afjutogai',NULL,NULL,NULL,'住登外者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.atenano','000_tt_afkaigo_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afkaigo',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--介護保険者番号
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.kaigohokensyano','000_tt_afkaigo_002','介護保険者番号',NULL,1,3,True,1,'1','1','tt_afkaigo',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--被保険者番号
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.hihokensyano','000_tt_afkaigo_003','被保険者番号',NULL,1,3,True,1,'1','1','tt_afkaigo',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--被保険者区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.hihokensyakbncd','000_tt_afkaigo_004','被保険者区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkaigo',NULL,'111','2023,49','【介護保険】被保険者情報テーブル','被保険者区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_hihokensyakbncd_nm.nm','000_tt_afkaigo_005','被保険者区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkaigo_hihokensyakbncd_nm',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル','被保険者区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.hihokensyakbncd || '':'' || tt_afkaigo_hihokensyakbncd_nm.nm','000_tt_afkaigo_006','被保険者区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkaigo','tt_afkaigo_hihokensyakbncd_nm',NULL,NULL,'【介護保険】被保険者情報テーブル','被保険者区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--資格取得日
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.sikakusyutokuymd','000_tt_afkaigo_007','資格取得日',NULL,1,3,True,1,'1','1','tt_afkaigo',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--資格喪失日
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.sikakusosituymd','000_tt_afkaigo_008','資格喪失日',NULL,1,3,True,1,'1','1','tt_afkaigo',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--要介護認定状況コード
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.yokaigoninteijokyocd','000_tt_afkaigo_009','要介護認定状況コード',NULL,1,3,True,3,'1',NULL,'tt_afkaigo',NULL,'111','2023,63','【介護保険】被保険者情報テーブル','要介護認定状況コード',NULL,'system','2023-01-01','system','2023-01-01');
--要介護認定状況名称
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_yokaigoninteijokyocd_nm.nm','000_tt_afkaigo_010','要介護認定状況名称',NULL,0,2,False,1,'1',NULL,'tt_afkaigo_yokaigoninteijokyocd_nm',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル','要介護認定状況コード',NULL,'system','2023-01-01','system','2023-01-01');
--要介護認定状況CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.yokaigoninteijokyocd || '':'' || tt_afkaigo_yokaigoninteijokyocd_nm.nm','000_tt_afkaigo_011','要介護認定状況CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkaigo','tt_afkaigo_yokaigoninteijokyocd_nm',NULL,NULL,'【介護保険】被保険者情報テーブル','要介護認定状況コード',NULL,'system','2023-01-01','system','2023-01-01');
--要介護状態区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.yokaigojotaikbncd','000_tt_afkaigo_012','要介護状態区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkaigo',NULL,'111','2023,35','【介護保険】被保険者情報テーブル','要介護状態区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--要介護状態区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_yokaigojotaikbncd_nm.nm','000_tt_afkaigo_013','要介護状態区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkaigo_yokaigojotaikbncd_nm',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル','要介護状態区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--要介護状態区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.yokaigojotaikbncd || '':'' || tt_afkaigo_yokaigojotaikbncd_nm.nm','000_tt_afkaigo_014','要介護状態区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkaigo','tt_afkaigo_yokaigojotaikbncd_nm',NULL,NULL,'【介護保険】被保険者情報テーブル','要介護状態区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--要介護認定日
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.yokaigoninteiymd','000_tt_afkaigo_015','要介護認定日',NULL,1,3,True,1,'1','1','tt_afkaigo',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--要介護認定有効期間開始日
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.yokaigoyukoymdf','000_tt_afkaigo_016','要介護認定有効期間開始日',NULL,1,3,True,1,'1','1','tt_afkaigo',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--要介護認定有効期間終了日
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.yokaigoyukoymdt','000_tt_afkaigo_017','要介護認定有効期間終了日',NULL,1,3,True,1,'1','1','tt_afkaigo',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--公費受給者番号
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.kohijukyusyano','000_tt_afkaigo_018','公費受給者番号',NULL,1,3,True,1,'1','1','tt_afkaigo',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.reguserid','000_tt_afkaigo_019','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afkaigo',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.regdttm','000_tt_afkaigo_020','登録日時',NULL,1,4,False,1,'1','1','tt_afkaigo',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.upduserid','000_tt_afkaigo_021','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afkaigo',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afkaigo.upddttm','000_tt_afkaigo_022','更新日時',NULL,1,4,False,1,'1','1','tt_afkaigo',NULL,NULL,NULL,'【介護保険】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.atenano','000_tt_afkaigo_reki_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--介護保険者番号
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.kaigohokensyano','000_tt_afkaigo_reki_002','介護保険者番号',NULL,1,3,True,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--被保険者番号
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.hihokensyano','000_tt_afkaigo_reki_003','被保険者番号',NULL,1,3,True,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--資格履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.sikakurirekino','000_tt_afkaigo_reki_004','資格履歴番号',NULL,1,1,True,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--被保険者区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.hihokensyakbncd','000_tt_afkaigo_reki_005','被保険者区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkaigo_reki',NULL,'111','2023,49','【介護保険】被保険者情報履歴テーブル','被保険者区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki_hihokensyakbncd_nm.nm','000_tt_afkaigo_reki_006','被保険者区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkaigo_reki_hihokensyakbncd_nm',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル','被保険者区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.hihokensyakbncd || '':'' || tt_afkaigo_reki_hihokensyakbncd_nm.nm','000_tt_afkaigo_reki_007','被保険者区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkaigo_reki','tt_afkaigo_reki_hihokensyakbncd_nm',NULL,NULL,'【介護保険】被保険者情報履歴テーブル','被保険者区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--資格取得日
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.sikakusyutokuymd','000_tt_afkaigo_reki_008','資格取得日',NULL,1,3,True,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--資格喪失日
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.sikakusosituymd','000_tt_afkaigo_reki_009','資格喪失日',NULL,1,3,True,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--要介護認定状況コード
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.yokaigoninteijokyocd','000_tt_afkaigo_reki_010','要介護認定状況コード',NULL,1,3,True,3,'1',NULL,'tt_afkaigo_reki',NULL,'111','2023,63','【介護保険】被保険者情報履歴テーブル','要介護認定状況コード',NULL,'system','2023-01-01','system','2023-01-01');
--要介護認定状況名称
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki_yokaigoninteijokyocd_nm.nm','000_tt_afkaigo_reki_011','要介護認定状況名称',NULL,0,2,False,1,'1',NULL,'tt_afkaigo_reki_yokaigoninteijokyocd_nm',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル','要介護認定状況コード',NULL,'system','2023-01-01','system','2023-01-01');
--要介護認定状況CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.yokaigoninteijokyocd || '':'' || tt_afkaigo_reki_yokaigoninteijokyocd_nm.nm','000_tt_afkaigo_reki_012','要介護認定状況CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkaigo_reki','tt_afkaigo_reki_yokaigoninteijokyocd_nm',NULL,NULL,'【介護保険】被保険者情報履歴テーブル','要介護認定状況コード',NULL,'system','2023-01-01','system','2023-01-01');
--要介護状態区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.yokaigojotaikbncd','000_tt_afkaigo_reki_013','要介護状態区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkaigo_reki',NULL,'111','2023,35','【介護保険】被保険者情報履歴テーブル','要介護状態区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--要介護状態区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki_yokaigojotaikbncd_nm.nm','000_tt_afkaigo_reki_014','要介護状態区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkaigo_reki_yokaigojotaikbncd_nm',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル','要介護状態区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--要介護状態区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.yokaigojotaikbncd || '':'' || tt_afkaigo_reki_yokaigojotaikbncd_nm.nm','000_tt_afkaigo_reki_015','要介護状態区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkaigo_reki','tt_afkaigo_reki_yokaigojotaikbncd_nm',NULL,NULL,'【介護保険】被保険者情報履歴テーブル','要介護状態区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--要介護認定日
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.yokaigoninteiymd','000_tt_afkaigo_reki_016','要介護認定日',NULL,1,3,True,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--要介護認定有効期間開始日
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.yokaigoyukoymdf','000_tt_afkaigo_reki_017','要介護認定有効期間開始日',NULL,1,3,True,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--要介護認定有効期間終了日
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.yokaigoyukoymdt','000_tt_afkaigo_reki_018','要介護認定有効期間終了日',NULL,1,3,True,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--公費受給者番号
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.kohijukyusyano','000_tt_afkaigo_reki_019','公費受給者番号',NULL,1,3,True,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作者ID
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.renkeimotosousauserid','000_tt_afkaigo_reki_020','連携元操作者ID',NULL,1,3,True,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作日時
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.renkeimotosousadttm','000_tt_afkaigo_reki_021','連携元操作日時',NULL,1,4,True,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--最新フラグ
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.saisinflg','000_tt_afkaigo_reki_022','最新フラグ',NULL,1,6,True,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.reguserid','000_tt_afkaigo_reki_023','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.regdttm','000_tt_afkaigo_reki_024','登録日時',NULL,1,4,False,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.upduserid','000_tt_afkaigo_reki_025','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afkaigo_reki.upddttm','000_tt_afkaigo_reki_026','更新日時',NULL,1,4,False,1,'1','1','tt_afkaigo_reki',NULL,NULL,NULL,'【介護保険】被保険者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.atenano','000_tt_afkojindoc_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afkojindoc',NULL,NULL,NULL,'個人ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ドキュメントシーケンス
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.docseq','000_tt_afkojindoc_002','ドキュメントシーケンス',NULL,1,1,True,1,'1','1','tt_afkojindoc',NULL,NULL,NULL,'個人ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ファイル名
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.filenm','000_tt_afkojindoc_003','ファイル名',NULL,1,3,True,1,'1','1','tt_afkojindoc',NULL,NULL,NULL,'個人ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--電子ファイル事業コード
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.jigyocd','000_tt_afkojindoc_004','電子ファイル事業コード',NULL,1,3,True,1,'1','1','tt_afkojindoc',NULL,NULL,NULL,'個人ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--タイトル
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.title','000_tt_afkojindoc_005','タイトル',NULL,1,3,True,1,'1','1','tt_afkojindoc',NULL,NULL,NULL,'個人ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプコード
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.filetype','000_tt_afkojindoc_006','ファイルタイプコード',NULL,1,1,True,3,'1',NULL,'tt_afkojindoc',NULL,'111','1000,10','個人ドキュメントテーブル','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプ名称
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc_filetype_nm.nm','000_tt_afkojindoc_007','ファイルタイプ名称',NULL,0,2,False,1,'1',NULL,'tt_afkojindoc_filetype_nm',NULL,NULL,NULL,'個人ドキュメントテーブル','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.filetype || '':'' || tt_afkojindoc_filetype_nm.nm','000_tt_afkojindoc_008','ファイルタイプCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojindoc','tt_afkojindoc_filetype_nm',NULL,NULL,'個人ドキュメントテーブル','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルサイズ
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.filesize','000_tt_afkojindoc_009','ファイルサイズ',NULL,1,1,True,1,'1','1','tt_afkojindoc',NULL,NULL,NULL,'個人ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ファイルデータ
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.filedata','000_tt_afkojindoc_010','ファイルデータ',NULL,1,7,True,1,'1','1','tt_afkojindoc',NULL,NULL,NULL,'個人ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--重要フラグ
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.juyoflg','000_tt_afkojindoc_011','重要フラグ',NULL,1,6,True,1,'1','1','tt_afkojindoc',NULL,NULL,NULL,'個人ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録支所コード
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.regsisyo','000_tt_afkojindoc_012','登録支所コード',NULL,1,3,True,3,'1',NULL,'tt_afkojindoc',NULL,'121','3019,1','個人ドキュメントテーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所名称
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc_regsisyo_nm.nm','000_tt_afkojindoc_013','登録支所名称',NULL,0,2,False,1,'1',NULL,'tt_afkojindoc_regsisyo_nm',NULL,NULL,NULL,'個人ドキュメントテーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.regsisyo || '':'' || tt_afkojindoc_regsisyo_nm.nm','000_tt_afkojindoc_014','登録支所CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojindoc','tt_afkojindoc_regsisyo_nm',NULL,NULL,'個人ドキュメントテーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.reguserid','000_tt_afkojindoc_015','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojindoc',NULL,NULL,NULL,'個人ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.regdttm','000_tt_afkojindoc_016','登録日時',NULL,1,4,False,1,'1','1','tt_afkojindoc',NULL,NULL,NULL,'個人ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.upduserid','000_tt_afkojindoc_017','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojindoc',NULL,NULL,NULL,'個人ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afkojindoc.upddttm','000_tt_afkojindoc_018','更新日時',NULL,1,4,False,1,'1','1','tt_afkojindoc',NULL,NULL,NULL,'個人ドキュメントテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya.atenano','000_tt_afkojinzeigimusya_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afkojinzeigimusya',NULL,NULL,NULL,'【個人住民税】納税義務者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--課税年度
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya.kazeinendo','000_tt_afkojinzeigimusya_002','課税年度',NULL,1,1,True,1,'1','1','tt_afkojinzeigimusya',NULL,NULL,NULL,'【個人住民税】納税義務者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya.tosi_gyoseikucd','000_tt_afkojinzeigimusya_003','指定都市_行政区等コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeigimusya',NULL,'111','3019,100004','【個人住民税】納税義務者情報テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_tosi_gyoseikucd_nm.nm','000_tt_afkojinzeigimusya_004','指定都市_行政区等名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeigimusya_tosi_gyoseikucd_nm',NULL,NULL,NULL,'【個人住民税】納税義務者情報テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya.tosi_gyoseikucd || '':'' || tt_afkojinzeigimusya_tosi_gyoseikucd_nm.nm','000_tt_afkojinzeigimusya_005','指定都市_行政区等CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeigimusya','tt_afkojinzeigimusya_tosi_gyoseikucd_nm',NULL,NULL,'【個人住民税】納税義務者情報テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--未申告区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya.misinkokukbn','000_tt_afkojinzeigimusya_006','未申告区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeigimusya',NULL,'111','2010,2','【個人住民税】納税義務者情報テーブル','未申告区分',NULL,'system','2023-01-01','system','2023-01-01');
--未申告区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_misinkokukbn_nm.nm','000_tt_afkojinzeigimusya_007','未申告区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeigimusya_misinkokukbn_nm',NULL,NULL,NULL,'【個人住民税】納税義務者情報テーブル','未申告区分',NULL,'system','2023-01-01','system','2023-01-01');
--未申告区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya.misinkokukbn || '':'' || tt_afkojinzeigimusya_misinkokukbn_nm.nm','000_tt_afkojinzeigimusya_008','未申告区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeigimusya','tt_afkojinzeigimusya_misinkokukbn_nm',NULL,NULL,'【個人住民税】納税義務者情報テーブル','未申告区分',NULL,'system','2023-01-01','system','2023-01-01');
--他団体課税対象者区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya.takazeikbn','000_tt_afkojinzeigimusya_009','他団体課税対象者区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeigimusya',NULL,'111','2010,900001','【個人住民税】納税義務者情報テーブル','他団体課税対象者区分',NULL,'system','2023-01-01','system','2023-01-01');
--他団体課税対象者区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_takazeikbn_nm.nm','000_tt_afkojinzeigimusya_010','他団体課税対象者区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeigimusya_takazeikbn_nm',NULL,NULL,NULL,'【個人住民税】納税義務者情報テーブル','他団体課税対象者区分',NULL,'system','2023-01-01','system','2023-01-01');
--他団体課税対象者区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya.takazeikbn || '':'' || tt_afkojinzeigimusya_takazeikbn_nm.nm','000_tt_afkojinzeigimusya_011','他団体課税対象者区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeigimusya','tt_afkojinzeigimusya_takazeikbn_nm',NULL,NULL,'【個人住民税】納税義務者情報テーブル','他団体課税対象者区分',NULL,'system','2023-01-01','system','2023-01-01');
--他団体課税対象者の課税先市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya.takazeisikucd','000_tt_afkojinzeigimusya_012','他団体課税対象者の課税先市区町村コード',NULL,1,3,True,1,'1','1','tt_afkojinzeigimusya',NULL,NULL,NULL,'【個人住民税】納税義務者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya.reguserid','000_tt_afkojinzeigimusya_013','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojinzeigimusya',NULL,NULL,NULL,'【個人住民税】納税義務者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya.regdttm','000_tt_afkojinzeigimusya_014','登録日時',NULL,1,4,False,1,'1','1','tt_afkojinzeigimusya',NULL,NULL,NULL,'【個人住民税】納税義務者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya.upduserid','000_tt_afkojinzeigimusya_015','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojinzeigimusya',NULL,NULL,NULL,'【個人住民税】納税義務者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya.upddttm','000_tt_afkojinzeigimusya_016','更新日時',NULL,1,4,False,1,'1','1','tt_afkojinzeigimusya',NULL,NULL,NULL,'【個人住民税】納税義務者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.atenano','000_tt_afkojinzeigimusya_reki_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afkojinzeigimusya_reki',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--課税年度
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.kazeinendo','000_tt_afkojinzeigimusya_reki_002','課税年度',NULL,1,1,True,1,'1','1','tt_afkojinzeigimusya_reki',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.kojinrirekino','000_tt_afkojinzeigimusya_reki_003','個人履歴番号',NULL,1,1,True,1,'1','1','tt_afkojinzeigimusya_reki',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.tosi_gyoseikucd','000_tt_afkojinzeigimusya_reki_004','指定都市_行政区等コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeigimusya_reki',NULL,'111','3019,100004','【個人住民税】納税義務者情報履歴テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki_tosi_gyoseikucd_nm.nm','000_tt_afkojinzeigimusya_reki_005','指定都市_行政区等名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeigimusya_reki_tosi_gyoseikucd_nm',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.tosi_gyoseikucd || '':'' || tt_afkojinzeigimusya_reki_tosi_gyoseikucd_nm.nm','000_tt_afkojinzeigimusya_reki_006','指定都市_行政区等CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeigimusya_reki','tt_afkojinzeigimusya_reki_tosi_gyoseikucd_nm',NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--未申告区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.misinkokukbn','000_tt_afkojinzeigimusya_reki_007','未申告区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeigimusya_reki',NULL,'111','2010,2','【個人住民税】納税義務者情報履歴テーブル','未申告区分',NULL,'system','2023-01-01','system','2023-01-01');
--未申告区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki_misinkokukbn_nm.nm','000_tt_afkojinzeigimusya_reki_008','未申告区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeigimusya_reki_misinkokukbn_nm',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル','未申告区分',NULL,'system','2023-01-01','system','2023-01-01');
--未申告区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.misinkokukbn || '':'' || tt_afkojinzeigimusya_reki_misinkokukbn_nm.nm','000_tt_afkojinzeigimusya_reki_009','未申告区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeigimusya_reki','tt_afkojinzeigimusya_reki_misinkokukbn_nm',NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル','未申告区分',NULL,'system','2023-01-01','system','2023-01-01');
--他団体課税対象者区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.takazeikbn','000_tt_afkojinzeigimusya_reki_010','他団体課税対象者区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeigimusya_reki',NULL,'111','2010,900001','【個人住民税】納税義務者情報履歴テーブル','他団体課税対象者区分',NULL,'system','2023-01-01','system','2023-01-01');
--他団体課税対象者区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki_takazeikbn_nm.nm','000_tt_afkojinzeigimusya_reki_011','他団体課税対象者区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeigimusya_reki_takazeikbn_nm',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル','他団体課税対象者区分',NULL,'system','2023-01-01','system','2023-01-01');
--他団体課税対象者区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.takazeikbn || '':'' || tt_afkojinzeigimusya_reki_takazeikbn_nm.nm','000_tt_afkojinzeigimusya_reki_012','他団体課税対象者区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeigimusya_reki','tt_afkojinzeigimusya_reki_takazeikbn_nm',NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル','他団体課税対象者区分',NULL,'system','2023-01-01','system','2023-01-01');
--他団体課税対象者の課税先市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.takazeisikucd','000_tt_afkojinzeigimusya_reki_013','他団体課税対象者の課税先市区町村コード',NULL,1,3,True,1,'1','1','tt_afkojinzeigimusya_reki',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作者ID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.renkeimotosousauserid','000_tt_afkojinzeigimusya_reki_014','連携元操作者ID',NULL,1,3,True,1,'1','1','tt_afkojinzeigimusya_reki',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.renkeimotosousadttm','000_tt_afkojinzeigimusya_reki_015','連携元操作日時',NULL,1,4,True,1,'1','1','tt_afkojinzeigimusya_reki',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--最新フラグ
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.saisinflg','000_tt_afkojinzeigimusya_reki_016','最新フラグ',NULL,1,6,True,1,'1','1','tt_afkojinzeigimusya_reki',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.reguserid','000_tt_afkojinzeigimusya_reki_017','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojinzeigimusya_reki',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.regdttm','000_tt_afkojinzeigimusya_reki_018','登録日時',NULL,1,4,False,1,'1','1','tt_afkojinzeigimusya_reki',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.upduserid','000_tt_afkojinzeigimusya_reki_019','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojinzeigimusya_reki',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeigimusya_reki.upddttm','000_tt_afkojinzeigimusya_reki_020','更新日時',NULL,1,4,False,1,'1','1','tt_afkojinzeigimusya_reki',NULL,NULL,NULL,'【個人住民税】納税義務者情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei.atenano','000_tt_afkojinzeikazei_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afkojinzeikazei',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--課税年度
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei.kazeinendo','000_tt_afkojinzeikazei_002','課税年度',NULL,1,1,True,1,'1','1','tt_afkojinzeikazei',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei.tosi_gyoseikucd','000_tt_afkojinzeikazei_003','指定都市_行政区等コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeikazei',NULL,'111','3019,100004','【個人住民税】個人住民税課税情報テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_tosi_gyoseikucd_nm.nm','000_tt_afkojinzeikazei_004','指定都市_行政区等名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikazei_tosi_gyoseikucd_nm',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei.tosi_gyoseikucd || '':'' || tt_afkojinzeikazei_tosi_gyoseikucd_nm.nm','000_tt_afkojinzeikazei_005','指定都市_行政区等CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikazei','tt_afkojinzeikazei_tosi_gyoseikucd_nm',NULL,NULL,'【個人住民税】個人住民税課税情報テーブル','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--課税非課税区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei.kazeikbn','000_tt_afkojinzeikazei_006','課税非課税区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeikazei',NULL,'111','2010,5','【個人住民税】個人住民税課税情報テーブル','課税非課税区分',NULL,'system','2023-01-01','system','2023-01-01');
--課税非課税区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_kazeikbn_nm.nm','000_tt_afkojinzeikazei_007','課税非課税区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikazei_kazeikbn_nm',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報テーブル','課税非課税区分',NULL,'system','2023-01-01','system','2023-01-01');
--課税非課税区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei.kazeikbn || '':'' || tt_afkojinzeikazei_kazeikbn_nm.nm','000_tt_afkojinzeikazei_008','課税非課税区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikazei','tt_afkojinzeikazei_kazeikbn_nm',NULL,NULL,'【個人住民税】個人住民税課税情報テーブル','課税非課税区分',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei.reguserid','000_tt_afkojinzeikazei_009','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojinzeikazei',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei.regdttm','000_tt_afkojinzeikazei_010','登録日時',NULL,1,4,False,1,'1','1','tt_afkojinzeikazei',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei.upduserid','000_tt_afkojinzeikazei_011','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojinzeikazei',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei.upddttm','000_tt_afkojinzeikazei_012','更新日時',NULL,1,4,False,1,'1','1','tt_afkojinzeikazei',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.atenano','000_tt_afkojinzeikazei_reki_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afkojinzeikazei_reki',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--課税年度
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.kazeinendo','000_tt_afkojinzeikazei_reki_002','課税年度',NULL,1,1,True,1,'1','1','tt_afkojinzeikazei_reki',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--課税情報履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.kazeirirekino','000_tt_afkojinzeikazei_reki_003','課税情報履歴番号',NULL,1,1,True,1,'1','1','tt_afkojinzeikazei_reki',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.tosi_gyoseikucd','000_tt_afkojinzeikazei_reki_004','指定都市_行政区等コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeikazei_reki',NULL,'111','3019,100004','【個人住民税】個人住民税課税情報履歴テー','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki_tosi_gyoseikucd_nm.nm','000_tt_afkojinzeikazei_reki_005','指定都市_行政区等名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikazei_reki_tosi_gyoseikucd_nm',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.tosi_gyoseikucd || '':'' || tt_afkojinzeikazei_reki_tosi_gyoseikucd_nm.nm','000_tt_afkojinzeikazei_reki_006','指定都市_行政区等CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikazei_reki','tt_afkojinzeikazei_reki_tosi_gyoseikucd_nm',NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--課税非課税区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.kazeikbn','000_tt_afkojinzeikazei_reki_007','課税非課税区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeikazei_reki',NULL,'111','2010,5','【個人住民税】個人住民税課税情報履歴テー','課税非課税区分',NULL,'system','2023-01-01','system','2023-01-01');
--課税非課税区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki_kazeikbn_nm.nm','000_tt_afkojinzeikazei_reki_008','課税非課税区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikazei_reki_kazeikbn_nm',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー','課税非課税区分',NULL,'system','2023-01-01','system','2023-01-01');
--課税非課税区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.kazeikbn || '':'' || tt_afkojinzeikazei_reki_kazeikbn_nm.nm','000_tt_afkojinzeikazei_reki_009','課税非課税区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikazei_reki','tt_afkojinzeikazei_reki_kazeikbn_nm',NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー','課税非課税区分',NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作者ID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.renkeimotosousauserid','000_tt_afkojinzeikazei_reki_010','連携元操作者ID',NULL,1,3,True,1,'1','1','tt_afkojinzeikazei_reki',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.renkeimotosousadttm','000_tt_afkojinzeikazei_reki_011','連携元操作日時',NULL,1,4,True,1,'1','1','tt_afkojinzeikazei_reki',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--最新フラグ
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.saisinflg','000_tt_afkojinzeikazei_reki_012','最新フラグ',NULL,1,6,True,1,'1','1','tt_afkojinzeikazei_reki',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.reguserid','000_tt_afkojinzeikazei_reki_013','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojinzeikazei_reki',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.regdttm','000_tt_afkojinzeikazei_reki_014','登録日時',NULL,1,4,False,1,'1','1','tt_afkojinzeikazei_reki',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.upduserid','000_tt_afkojinzeikazei_reki_015','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojinzeikazei_reki',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikazei_reki.upddttm','000_tt_afkojinzeikazei_reki_016','更新日時',NULL,1,4,False,1,'1','1','tt_afkojinzeikazei_reki',NULL,NULL,NULL,'【個人住民税】個人住民税課税情報履歴テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo.atenano','000_tt_afkojinzeikojo_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afkojinzeikojo',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--課税年度
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo.kazeinendo','000_tt_afkojinzeikojo_002','課税年度',NULL,1,1,True,1,'1','1','tt_afkojinzeikojo',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--税額・税額控除コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo.kojocd','000_tt_afkojinzeikojo_003','税額・税額控除コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeikojo',NULL,'111','2010,28','【個人住民税】個人住民税税額控除情報テー','税額・税額控除コード',NULL,'system','2023-01-01','system','2023-01-01');
--税額・税額控除名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_kojocd_nm.nm','000_tt_afkojinzeikojo_004','税額・税額控除名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikojo_kojocd_nm',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報テー','税額・税額控除コード',NULL,'system','2023-01-01','system','2023-01-01');
--税額・税額控除CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo.kojocd || '':'' || tt_afkojinzeikojo_kojocd_nm.nm','000_tt_afkojinzeikojo_005','税額・税額控除CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikojo','tt_afkojinzeikojo_kojocd_nm',NULL,NULL,'【個人住民税】個人住民税税額控除情報テー','税額・税額控除コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo.tosi_gyoseikucd','000_tt_afkojinzeikojo_006','指定都市_行政区等コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeikojo',NULL,'111','3019,100004','【個人住民税】個人住民税税額控除情報テー','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_tosi_gyoseikucd_nm.nm','000_tt_afkojinzeikojo_007','指定都市_行政区等名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikojo_tosi_gyoseikucd_nm',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報テー','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo.tosi_gyoseikucd || '':'' || tt_afkojinzeikojo_tosi_gyoseikucd_nm.nm','000_tt_afkojinzeikojo_008','指定都市_行政区等CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikojo','tt_afkojinzeikojo_tosi_gyoseikucd_nm',NULL,NULL,'【個人住民税】個人住民税税額控除情報テー','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--税額控除金額
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo.kojokingaku','000_tt_afkojinzeikojo_009','税額控除金額',NULL,1,1,True,1,'1','1','tt_afkojinzeikojo',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo.reguserid','000_tt_afkojinzeikojo_010','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojinzeikojo',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo.regdttm','000_tt_afkojinzeikojo_011','登録日時',NULL,1,4,False,1,'1','1','tt_afkojinzeikojo',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo.upduserid','000_tt_afkojinzeikojo_012','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojinzeikojo',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo.upddttm','000_tt_afkojinzeikojo_013','更新日時',NULL,1,4,False,1,'1','1','tt_afkojinzeikojo',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.atenano','000_tt_afkojinzeikojo_reki_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afkojinzeikojo_reki',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--課税年度
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.kazeinendo','000_tt_afkojinzeikojo_reki_002','課税年度',NULL,1,1,True,1,'1','1','tt_afkojinzeikojo_reki',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--税額控除情報履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.kojorirekino','000_tt_afkojinzeikojo_reki_003','税額控除情報履歴番号',NULL,1,1,True,1,'1','1','tt_afkojinzeikojo_reki',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--税額・税額控除コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.kojocd','000_tt_afkojinzeikojo_reki_004','税額・税額控除コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeikojo_reki',NULL,'111','2010,28','【個人住民税】個人住民税税額控除情報履歴','税額・税額控除コード',NULL,'system','2023-01-01','system','2023-01-01');
--税額・税額控除名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki_kojocd_nm.nm','000_tt_afkojinzeikojo_reki_005','税額・税額控除名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikojo_reki_kojocd_nm',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴','税額・税額控除コード',NULL,'system','2023-01-01','system','2023-01-01');
--税額・税額控除CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.kojocd || '':'' || tt_afkojinzeikojo_reki_kojocd_nm.nm','000_tt_afkojinzeikojo_reki_006','税額・税額控除CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikojo_reki','tt_afkojinzeikojo_reki_kojocd_nm',NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴','税額・税額控除コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等コード
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.tosi_gyoseikucd','000_tt_afkojinzeikojo_reki_007','指定都市_行政区等コード',NULL,1,3,True,3,'1',NULL,'tt_afkojinzeikojo_reki',NULL,'111','3019,100004','【個人住民税】個人住民税税額控除情報履歴','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki_tosi_gyoseikucd_nm.nm','000_tt_afkojinzeikojo_reki_008','指定都市_行政区等名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikojo_reki_tosi_gyoseikucd_nm',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--指定都市_行政区等CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.tosi_gyoseikucd || '':'' || tt_afkojinzeikojo_reki_tosi_gyoseikucd_nm.nm','000_tt_afkojinzeikojo_reki_009','指定都市_行政区等CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkojinzeikojo_reki','tt_afkojinzeikojo_reki_tosi_gyoseikucd_nm',NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴','指定都市_行政区等コード',NULL,'system','2023-01-01','system','2023-01-01');
--税額控除金額
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.kojokingaku','000_tt_afkojinzeikojo_reki_010','税額控除金額',NULL,1,1,True,1,'1','1','tt_afkojinzeikojo_reki',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作者ID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.renkeimotosousauserid','000_tt_afkojinzeikojo_reki_011','連携元操作者ID',NULL,1,3,True,1,'1','1','tt_afkojinzeikojo_reki',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.renkeimotosousadttm','000_tt_afkojinzeikojo_reki_012','連携元操作日時',NULL,1,4,True,1,'1','1','tt_afkojinzeikojo_reki',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--最新フラグ
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.saisinflg','000_tt_afkojinzeikojo_reki_013','最新フラグ',NULL,1,6,True,1,'1','1','tt_afkojinzeikojo_reki',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.reguserid','000_tt_afkojinzeikojo_reki_014','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojinzeikojo_reki',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.regdttm','000_tt_afkojinzeikojo_reki_015','登録日時',NULL,1,4,False,1,'1','1','tt_afkojinzeikojo_reki',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.upduserid','000_tt_afkojinzeikojo_reki_016','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afkojinzeikojo_reki',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afkojinzeikojo_reki.upddttm','000_tt_afkojinzeikojo_reki_017','更新日時',NULL,1,4,False,1,'1','1','tt_afkojinzeikojo_reki',NULL,NULL,NULL,'【個人住民税】個人住民税税額控除情報履歴',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.atenano','000_tt_afkokihoken_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afkokihoken',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--被保険者番号
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.hihokensyano','000_tt_afkokihoken_002','被保険者番号',NULL,1,3,True,1,'1','1','tt_afkokihoken',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.kojinkbncd','000_tt_afkokihoken_003','個人区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkokihoken',NULL,'111','2025,1','【後期高齢者医療】被保険者情報テーブル','個人区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--個人区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_kojinkbncd_nm.nm','000_tt_afkokihoken_004','個人区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkokihoken_kojinkbncd_nm',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報テーブル','個人区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--個人区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.kojinkbncd || '':'' || tt_afkokihoken_kojinkbncd_nm.nm','000_tt_afkokihoken_005','個人区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokihoken','tt_afkokihoken_kojinkbncd_nm',NULL,NULL,'【後期高齢者医療】被保険者情報テーブル','個人区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格取得事由コード
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.hiho_sikakusyutokujiyucd','000_tt_afkokihoken_006','被保険者資格取得事由コード',NULL,1,3,True,3,'1',NULL,'tt_afkokihoken',NULL,'111','2025,11','【後期高齢者医療】被保険者情報テーブル','被保険者資格取得事由コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格取得事由名称
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_hiho_sikakusyutokujiyucd_nm.nm','000_tt_afkokihoken_007','被保険者資格取得事由名称',NULL,0,2,False,1,'1',NULL,'tt_afkokihoken_hiho_sikakusyutokujiyucd_nm',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報テーブル','被保険者資格取得事由コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格取得事由CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.hiho_sikakusyutokujiyucd || '':'' || tt_afkokihoken_hiho_sikakusyutokujiyucd_nm.nm','000_tt_afkokihoken_008','被保険者資格取得事由CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokihoken','tt_afkokihoken_hiho_sikakusyutokujiyucd_nm',NULL,NULL,'【後期高齢者医療】被保険者情報テーブル','被保険者資格取得事由コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格取得年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.hiho_sikakusyutokuymd','000_tt_afkokihoken_009','被保険者資格取得年月日',NULL,1,3,True,1,'1','1','tt_afkokihoken',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格喪失事由コード
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.hiho_sikakusositujiyucd','000_tt_afkokihoken_010','被保険者資格喪失事由コード',NULL,1,3,True,3,'1',NULL,'tt_afkokihoken',NULL,'111','2025,12','【後期高齢者医療】被保険者情報テーブル','被保険者資格喪失事由コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格喪失事由名称
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_hiho_sikakusositujiyucd_nm.nm','000_tt_afkokihoken_011','被保険者資格喪失事由名称',NULL,0,2,False,1,'1',NULL,'tt_afkokihoken_hiho_sikakusositujiyucd_nm',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報テーブル','被保険者資格喪失事由コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格喪失事由CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.hiho_sikakusositujiyucd || '':'' || tt_afkokihoken_hiho_sikakusositujiyucd_nm.nm','000_tt_afkokihoken_012','被保険者資格喪失事由CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokihoken','tt_afkokihoken_hiho_sikakusositujiyucd_nm',NULL,NULL,'【後期高齢者医療】被保険者情報テーブル','被保険者資格喪失事由コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格喪失年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.hiho_sikakusosituymd','000_tt_afkokihoken_013','被保険者資格喪失年月日',NULL,1,3,True,1,'1','1','tt_afkokihoken',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--保険者番号適用開始年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.hoken_tekiyoymdf','000_tt_afkokihoken_014','保険者番号適用開始年月日',NULL,1,3,True,1,'1','1','tt_afkokihoken',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--保険者番号適用終了年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.hoken_tekiyoymdt','000_tt_afkokihoken_015','保険者番号適用終了年月日',NULL,1,3,True,1,'1','1','tt_afkokihoken',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.reguserid','000_tt_afkokihoken_016','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afkokihoken',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.regdttm','000_tt_afkokihoken_017','登録日時',NULL,1,4,False,1,'1','1','tt_afkokihoken',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.upduserid','000_tt_afkokihoken_018','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afkokihoken',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken.upddttm','000_tt_afkokihoken_019','更新日時',NULL,1,4,False,1,'1','1','tt_afkokihoken',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--被保険者番号
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.hihokensyano','000_tt_afkokihoken_reki_001','被保険者番号',NULL,1,3,True,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.rirekino','000_tt_afkokihoken_reki_002','履歴番号',NULL,1,1,True,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.kojinkbncd','000_tt_afkokihoken_reki_003','個人区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkokihoken_reki',NULL,'111','2025,1','【後期高齢者医療】被保険者情報履歴テーブ','個人区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--個人区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki_kojinkbncd_nm.nm','000_tt_afkokihoken_reki_004','個人区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkokihoken_reki_kojinkbncd_nm',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ','個人区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--個人区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.kojinkbncd || '':'' || tt_afkokihoken_reki_kojinkbncd_nm.nm','000_tt_afkokihoken_reki_005','個人区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokihoken_reki','tt_afkokihoken_reki_kojinkbncd_nm',NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ','個人区分コード',NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.atenano','000_tt_afkokihoken_reki_006','宛名番号',NULL,1,3,True,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格取得事由コード
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.hiho_sikakusyutokujiyucd','000_tt_afkokihoken_reki_007','被保険者資格取得事由コード',NULL,1,3,True,3,'1',NULL,'tt_afkokihoken_reki',NULL,'111','2025,11','【後期高齢者医療】被保険者情報履歴テーブ','被保険者資格取得事由コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格取得事由名称
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki_hiho_sikakusyutokujiyucd_nm.nm','000_tt_afkokihoken_reki_008','被保険者資格取得事由名称',NULL,0,2,False,1,'1',NULL,'tt_afkokihoken_reki_hiho_sikakusyutokujiyucd_nm',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ','被保険者資格取得事由コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格取得事由CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.hiho_sikakusyutokujiyucd || '':'' || tt_afkokihoken_reki_hiho_sikakusyutokujiyucd_nm.nm','000_tt_afkokihoken_reki_009','被保険者資格取得事由CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokihoken_reki','tt_afkokihoken_reki_hiho_sikakusyutokujiyucd_nm',NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ','被保険者資格取得事由コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格取得年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.hiho_sikakusyutokuymd','000_tt_afkokihoken_reki_010','被保険者資格取得年月日',NULL,1,3,True,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格喪失事由コード
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.hiho_sikakusositujiyucd','000_tt_afkokihoken_reki_011','被保険者資格喪失事由コード',NULL,1,3,True,3,'1',NULL,'tt_afkokihoken_reki',NULL,'111','2025,12','【後期高齢者医療】被保険者情報履歴テーブ','被保険者資格喪失事由コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格喪失事由名称
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki_hiho_sikakusositujiyucd_nm.nm','000_tt_afkokihoken_reki_012','被保険者資格喪失事由名称',NULL,0,2,False,1,'1',NULL,'tt_afkokihoken_reki_hiho_sikakusositujiyucd_nm',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ','被保険者資格喪失事由コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格喪失事由CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.hiho_sikakusositujiyucd || '':'' || tt_afkokihoken_reki_hiho_sikakusositujiyucd_nm.nm','000_tt_afkokihoken_reki_013','被保険者資格喪失事由CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokihoken_reki','tt_afkokihoken_reki_hiho_sikakusositujiyucd_nm',NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ','被保険者資格喪失事由コード',NULL,'system','2023-01-01','system','2023-01-01');
--被保険者資格喪失年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.hiho_sikakusosituymd','000_tt_afkokihoken_reki_014','被保険者資格喪失年月日',NULL,1,3,True,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--保険者番号適用開始年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.hoken_tekiyoymdf','000_tt_afkokihoken_reki_015','保険者番号適用開始年月日',NULL,1,3,True,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--保険者番号適用終了年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.hoken_tekiyoymdt','000_tt_afkokihoken_reki_016','保険者番号適用終了年月日',NULL,1,3,True,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作者ID
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.renkeimotosousauserid','000_tt_afkokihoken_reki_017','連携元操作者ID',NULL,1,3,True,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作日時
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.renkeimotosousadttm','000_tt_afkokihoken_reki_018','連携元操作日時',NULL,1,4,True,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--最新フラグ
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.saisinflg','000_tt_afkokihoken_reki_019','最新フラグ',NULL,1,6,True,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.reguserid','000_tt_afkokihoken_reki_020','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.regdttm','000_tt_afkokihoken_reki_021','登録日時',NULL,1,4,False,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.upduserid','000_tt_afkokihoken_reki_022','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afkokihoken_reki.upddttm','000_tt_afkokihoken_reki_023','更新日時',NULL,1,4,False,1,'1','1','tt_afkokihoken_reki',NULL,NULL,NULL,'【後期高齢者医療】被保険者情報履歴テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.atenano','000_tt_afkokuho_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--市区町村保険者番号
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.sikutyosonhokenjano','000_tt_afkokuho_002','市区町村保険者番号',NULL,1,3,True,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--保険者名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.hokenjanm','000_tt_afkokuho_003','保険者名称',NULL,1,3,True,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--国保記号番号
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.kokuho_kigono','000_tt_afkokuho_004','国保記号番号',NULL,1,3,True,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.kokuho_edano','000_tt_afkokuho_005','枝番',NULL,1,3,True,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--国保資格区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.kokuho_sikakukbn','000_tt_afkokuho_006','国保資格区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkokuho',NULL,'111','2024,1','【国民健康保険】国保資格情報テーブル','国保資格区分',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_kokuho_sikakukbn_nm.nm','000_tt_afkokuho_007','国保資格区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_kokuho_sikakukbn_nm',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル','国保資格区分',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.kokuho_sikakukbn || '':'' || tt_afkokuho_kokuho_sikakukbn_nm.nm','000_tt_afkokuho_008','国保資格区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho','tt_afkokuho_kokuho_sikakukbn_nm',NULL,NULL,'【国民健康保険】国保資格情報テーブル','国保資格区分',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格取得年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.kokuho_sikakusyutokuymd','000_tt_afkokuho_009','国保資格取得年月日',NULL,1,3,True,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--国保資格取得事由コード
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.kokuho_sikakusyutokujiyu','000_tt_afkokuho_010','国保資格取得事由コード',NULL,1,3,True,3,'1',NULL,'tt_afkokuho',NULL,'111','2024,131','【国民健康保険】国保資格情報テーブル','国保資格取得事由',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格取得事由名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_kokuho_sikakusyutokujiyu_nm.nm','000_tt_afkokuho_011','国保資格取得事由名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_kokuho_sikakusyutokujiyu_nm',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル','国保資格取得事由',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格取得事由CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.kokuho_sikakusyutokujiyu || '':'' || tt_afkokuho_kokuho_sikakusyutokujiyu_nm.nm','000_tt_afkokuho_012','国保資格取得事由CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho','tt_afkokuho_kokuho_sikakusyutokujiyu_nm',NULL,NULL,'【国民健康保険】国保資格情報テーブル','国保資格取得事由',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格喪失年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.kokuho_sikakusosituymd','000_tt_afkokuho_013','国保資格喪失年月日',NULL,1,3,True,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--国保資格喪失事由コード
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.kokuho_sikakusositujiyu','000_tt_afkokuho_014','国保資格喪失事由コード',NULL,1,3,True,3,'1',NULL,'tt_afkokuho',NULL,'111','2024,132','【国民健康保険】国保資格情報テーブル','国保資格喪失事由',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格喪失事由名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_kokuho_sikakusositujiyu_nm.nm','000_tt_afkokuho_015','国保資格喪失事由名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_kokuho_sikakusositujiyu_nm',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル','国保資格喪失事由',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格喪失事由CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.kokuho_sikakusositujiyu || '':'' || tt_afkokuho_kokuho_sikakusositujiyu_nm.nm','000_tt_afkokuho_016','国保資格喪失事由CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho','tt_afkokuho_kokuho_sikakusositujiyu_nm',NULL,NULL,'【国民健康保険】国保資格情報テーブル','国保資格喪失事由',NULL,'system','2023-01-01','system','2023-01-01');
--国保適用開始年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.kokuho_tekiyoymdf','000_tt_afkokuho_017','国保適用開始年月日',NULL,1,3,True,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--国保適用終了年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.kokuho_tekiyoymdt','000_tt_afkokuho_018','国保適用終了年月日',NULL,1,3,True,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--証区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.syokbn','000_tt_afkokuho_019','証区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkokuho',NULL,'111','2024,900001','【国民健康保険】国保資格情報テーブル','証区分',NULL,'system','2023-01-01','system','2023-01-01');
--証区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_syokbn_nm.nm','000_tt_afkokuho_020','証区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_syokbn_nm',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル','証区分',NULL,'system','2023-01-01','system','2023-01-01');
--証区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.syokbn || '':'' || tt_afkokuho_syokbn_nm.nm','000_tt_afkokuho_021','証区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho','tt_afkokuho_syokbn_nm',NULL,NULL,'【国民健康保険】国保資格情報テーブル','証区分',NULL,'system','2023-01-01','system','2023-01-01');
--有効期限
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.yukokigenymd','000_tt_afkokuho_022','有効期限',NULL,1,3,True,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--マル学マル遠区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.marugakumaruenkbn','000_tt_afkokuho_023','マル学マル遠区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkokuho',NULL,'111','2024,7','【国民健康保険】国保資格情報テーブル','マル学マル遠区分',NULL,'system','2023-01-01','system','2023-01-01');
--マル学マル遠区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_marugakumaruenkbn_nm.nm','000_tt_afkokuho_024','マル学マル遠区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_marugakumaruenkbn_nm',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル','マル学マル遠区分',NULL,'system','2023-01-01','system','2023-01-01');
--マル学マル遠区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.marugakumaruenkbn || '':'' || tt_afkokuho_marugakumaruenkbn_nm.nm','000_tt_afkokuho_025','マル学マル遠区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho','tt_afkokuho_marugakumaruenkbn_nm',NULL,NULL,'【国民健康保険】国保資格情報テーブル','マル学マル遠区分',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.reguserid','000_tt_afkokuho_026','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.regdttm','000_tt_afkokuho_027','登録日時',NULL,1,4,False,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.upduserid','000_tt_afkokuho_028','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afkokuho.upddttm','000_tt_afkokuho_029','更新日時',NULL,1,4,False,1,'1','1','tt_afkokuho',NULL,NULL,NULL,'【国民健康保険】国保資格情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.atenano','000_tt_afkokuho_reki_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--被保険者履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.hihokensyarirekino','000_tt_afkokuho_reki_002','被保険者履歴番号',NULL,1,1,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--市区町村保険者番号
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.sikutyosonhokenjano','000_tt_afkokuho_reki_003','市区町村保険者番号',NULL,1,3,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--保険者名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.hokenjanm','000_tt_afkokuho_reki_004','保険者名称',NULL,1,3,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--国保記号番号
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.kokuho_kigono','000_tt_afkokuho_reki_005','国保記号番号',NULL,1,3,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.kokuho_edano','000_tt_afkokuho_reki_006','枝番',NULL,1,3,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--国保資格区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.kokuho_sikakukbn','000_tt_afkokuho_reki_007','国保資格区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkokuho_reki',NULL,'111','2024,1','【国民健康保険】国保資格情報履歴テーブル','国保資格区分',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki_kokuho_sikakukbn_nm.nm','000_tt_afkokuho_reki_008','国保資格区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_reki_kokuho_sikakukbn_nm',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル','国保資格区分',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.kokuho_sikakukbn || '':'' || tt_afkokuho_reki_kokuho_sikakukbn_nm.nm','000_tt_afkokuho_reki_009','国保資格区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_reki','tt_afkokuho_reki_kokuho_sikakukbn_nm',NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル','国保資格区分',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格取得年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.kokuho_sikakusyutokuymd','000_tt_afkokuho_reki_010','国保資格取得年月日',NULL,1,3,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--国保資格取得事由コード
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.kokuho_sikakusyutokujiyu','000_tt_afkokuho_reki_011','国保資格取得事由コード',NULL,1,3,True,3,'1',NULL,'tt_afkokuho_reki',NULL,'111','2024,131','【国民健康保険】国保資格情報履歴テーブル','国保資格取得事由',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格取得事由名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki_kokuho_sikakusyutokujiyu_nm.nm','000_tt_afkokuho_reki_012','国保資格取得事由名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_reki_kokuho_sikakusyutokujiyu_nm',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル','国保資格取得事由',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格取得事由CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.kokuho_sikakusyutokujiyu || '':'' || tt_afkokuho_reki_kokuho_sikakusyutokujiyu_nm.nm','000_tt_afkokuho_reki_013','国保資格取得事由CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_reki','tt_afkokuho_reki_kokuho_sikakusyutokujiyu_nm',NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル','国保資格取得事由',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格喪失年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.kokuho_sikakusosituymd','000_tt_afkokuho_reki_014','国保資格喪失年月日',NULL,1,3,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--国保資格喪失事由コード
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.kokuho_sikakusositujiyu','000_tt_afkokuho_reki_015','国保資格喪失事由コード',NULL,1,3,True,3,'1',NULL,'tt_afkokuho_reki',NULL,'111','2024,132','【国民健康保険】国保資格情報履歴テーブル','国保資格喪失事由',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格喪失事由名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki_kokuho_sikakusositujiyu_nm.nm','000_tt_afkokuho_reki_016','国保資格喪失事由名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_reki_kokuho_sikakusositujiyu_nm',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル','国保資格喪失事由',NULL,'system','2023-01-01','system','2023-01-01');
--国保資格喪失事由CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.kokuho_sikakusositujiyu || '':'' || tt_afkokuho_reki_kokuho_sikakusositujiyu_nm.nm','000_tt_afkokuho_reki_017','国保資格喪失事由CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_reki','tt_afkokuho_reki_kokuho_sikakusositujiyu_nm',NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル','国保資格喪失事由',NULL,'system','2023-01-01','system','2023-01-01');
--国保適用開始年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.kokuho_tekiyoymdf','000_tt_afkokuho_reki_018','国保適用開始年月日',NULL,1,3,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--国保適用終了年月日
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.kokuho_tekiyoymdt','000_tt_afkokuho_reki_019','国保適用終了年月日',NULL,1,3,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--証区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.syokbn','000_tt_afkokuho_reki_020','証区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkokuho_reki',NULL,'111','2024,900001','【国民健康保険】国保資格情報履歴テーブル','証区分',NULL,'system','2023-01-01','system','2023-01-01');
--証区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki_syokbn_nm.nm','000_tt_afkokuho_reki_021','証区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_reki_syokbn_nm',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル','証区分',NULL,'system','2023-01-01','system','2023-01-01');
--証区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.syokbn || '':'' || tt_afkokuho_reki_syokbn_nm.nm','000_tt_afkokuho_reki_022','証区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_reki','tt_afkokuho_reki_syokbn_nm',NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル','証区分',NULL,'system','2023-01-01','system','2023-01-01');
--有効期限
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.yukokigenymd','000_tt_afkokuho_reki_023','有効期限',NULL,1,3,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--マル学マル遠区分コード
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.marugakumaruenkbn','000_tt_afkokuho_reki_024','マル学マル遠区分コード',NULL,1,3,True,3,'1',NULL,'tt_afkokuho_reki',NULL,'111','2024,7','【国民健康保険】国保資格情報履歴テーブル','マル学マル遠区分',NULL,'system','2023-01-01','system','2023-01-01');
--マル学マル遠区分名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki_marugakumaruenkbn_nm.nm','000_tt_afkokuho_reki_025','マル学マル遠区分名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_reki_marugakumaruenkbn_nm',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル','マル学マル遠区分',NULL,'system','2023-01-01','system','2023-01-01');
--マル学マル遠区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.marugakumaruenkbn || '':'' || tt_afkokuho_reki_marugakumaruenkbn_nm.nm','000_tt_afkokuho_reki_026','マル学マル遠区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afkokuho_reki','tt_afkokuho_reki_marugakumaruenkbn_nm',NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル','マル学マル遠区分',NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作者ID
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.renkeimotosousauserid','000_tt_afkokuho_reki_027','連携元操作者ID',NULL,1,3,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作日時
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.renkeimotosousadttm','000_tt_afkokuho_reki_028','連携元操作日時',NULL,1,4,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--最新フラグ
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.saisinflg','000_tt_afkokuho_reki_029','最新フラグ',NULL,1,6,True,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.reguserid','000_tt_afkokuho_reki_030','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.regdttm','000_tt_afkokuho_reki_031','登録日時',NULL,1,4,False,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.upduserid','000_tt_afkokuho_reki_032','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afkokuho_reki.upddttm','000_tt_afkokuho_reki_033','更新日時',NULL,1,4,False,1,'1','1','tt_afkokuho_reki',NULL,NULL,NULL,'【国民健康保険】国保資格情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--セッションシーケンス
INSERT INTO tm_eutableitem VALUES('tt_aflog.sessionseq','000_tt_aflog_001','セッションシーケンス',NULL,1,1,True,1,'1','1','tt_aflog',NULL,NULL,NULL,'メインログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--処理日時（開始）
INSERT INTO tm_eutableitem VALUES('tt_aflog.syoridttmf','000_tt_aflog_002','処理日時（開始）',NULL,1,4,True,1,'1','1','tt_aflog',NULL,NULL,NULL,'メインログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--処理日時（終了）
INSERT INTO tm_eutableitem VALUES('tt_aflog.syoridttmt','000_tt_aflog_003','処理日時（終了）',NULL,1,4,True,1,'1','1','tt_aflog',NULL,NULL,NULL,'メインログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--処理時間
INSERT INTO tm_eutableitem VALUES('tt_aflog.milisec','000_tt_aflog_004','処理時間',NULL,1,1,True,1,'1','1','tt_aflog',NULL,NULL,NULL,'メインログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--処理結果コード
INSERT INTO tm_eutableitem VALUES('tt_aflog.statuscd','000_tt_aflog_005','処理結果コード',NULL,1,3,True,3,'1',NULL,'tt_aflog',NULL,'111','1000,12','メインログテーブル','処理結果コード',NULL,'system','2023-01-01','system','2023-01-01');
--処理結果名称
INSERT INTO tm_eutableitem VALUES('tt_aflog_statuscd_nm.nm','000_tt_aflog_006','処理結果名称',NULL,0,2,False,1,'1',NULL,'tt_aflog_statuscd_nm',NULL,NULL,NULL,'メインログテーブル','処理結果コード',NULL,'system','2023-01-01','system','2023-01-01');
--処理結果CD:名称
INSERT INTO tm_eutableitem VALUES('tt_aflog.statuscd || '':'' || tt_aflog_statuscd_nm.nm','000_tt_aflog_007','処理結果CD:名称',NULL,0,2,False,1,'1',NULL,'tt_aflog','tt_aflog_statuscd_nm',NULL,NULL,'メインログテーブル','処理結果コード',NULL,'system','2023-01-01','system','2023-01-01');
--機能ID
INSERT INTO tm_eutableitem VALUES('tt_aflog.kinoid','000_tt_aflog_008','機能ID',NULL,1,3,True,1,'1','1','tt_aflog',NULL,NULL,NULL,'メインログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--サービス名
INSERT INTO tm_eutableitem VALUES('tt_aflog.service','000_tt_aflog_009','サービス名',NULL,1,3,True,1,'1','1','tt_aflog',NULL,NULL,NULL,'メインログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メソッド
INSERT INTO tm_eutableitem VALUES('tt_aflog.method','000_tt_aflog_010','メソッド',NULL,1,3,True,1,'1','1','tt_aflog',NULL,NULL,NULL,'メインログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メソッド名
INSERT INTO tm_eutableitem VALUES('tt_aflog.methodnm','000_tt_aflog_011','メソッド名',NULL,1,3,True,1,'1','1','tt_aflog',NULL,NULL,NULL,'メインログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_aflog.reguserid','000_tt_aflog_012','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_aflog',NULL,NULL,NULL,'メインログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_aflog.regdttm','000_tt_aflog_013','登録日時',NULL,1,4,False,1,'1','1','tt_aflog',NULL,NULL,NULL,'メインログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号ログシーケンス
INSERT INTO tm_eutableitem VALUES('tt_aflogatena.atenalogseq','000_tt_aflogatena_001','宛名番号ログシーケンス',NULL,1,1,True,1,'1','1','tt_aflogatena',NULL,NULL,NULL,'宛名番号ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--セッションシーケンス
INSERT INTO tm_eutableitem VALUES('tt_aflogatena.sessionseq','000_tt_aflogatena_002','セッションシーケンス',NULL,1,1,True,1,'1','1','tt_aflogatena',NULL,NULL,NULL,'宛名番号ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_aflogatena.atenano','000_tt_aflogatena_003','宛名番号',NULL,1,3,True,1,'1','1','tt_aflogatena',NULL,NULL,NULL,'宛名番号ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人番号操作フラグ
INSERT INTO tm_eutableitem VALUES('tt_aflogatena.pnouseflg','000_tt_aflogatena_004','個人番号操作フラグ',NULL,1,6,True,1,'1','1','tt_aflogatena',NULL,NULL,NULL,'宛名番号ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--操作区分コード
INSERT INTO tm_eutableitem VALUES('tt_aflogatena.usekbn','000_tt_aflogatena_005','操作区分コード',NULL,1,3,True,3,'1',NULL,'tt_aflogatena',NULL,'111','1000,40','宛名番号ログテーブル','操作区分',NULL,'system','2023-01-01','system','2023-01-01');
--操作区分名称
INSERT INTO tm_eutableitem VALUES('tt_aflogatena_usekbn_nm.nm','000_tt_aflogatena_006','操作区分名称',NULL,0,2,False,1,'1',NULL,'tt_aflogatena_usekbn_nm',NULL,NULL,NULL,'宛名番号ログテーブル','操作区分',NULL,'system','2023-01-01','system','2023-01-01');
--操作区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_aflogatena.usekbn || '':'' || tt_aflogatena_usekbn_nm.nm','000_tt_aflogatena_007','操作区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_aflogatena','tt_aflogatena_usekbn_nm',NULL,NULL,'宛名番号ログテーブル','操作区分',NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ
INSERT INTO tm_eutableitem VALUES('tt_aflogatena.msg','000_tt_aflogatena_008','メッセージ',NULL,1,3,True,1,'1','1','tt_aflogatena',NULL,NULL,NULL,'宛名番号ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_aflogatena.reguserid','000_tt_aflogatena_009','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_aflogatena',NULL,NULL,NULL,'宛名番号ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_aflogatena.regdttm','000_tt_aflogatena_010','登録日時',NULL,1,4,False,1,'1','1','tt_aflogatena',NULL,NULL,NULL,'宛名番号ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目値変更ログシーケンス
INSERT INTO tm_eutableitem VALUES('tt_aflogcolumn.columnlogseq','000_tt_aflogcolumn_001','項目値変更ログシーケンス',NULL,1,1,True,1,'1','1','tt_aflogcolumn',NULL,NULL,NULL,'テーブル項目値変更ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--セッションシーケンス
INSERT INTO tm_eutableitem VALUES('tt_aflogcolumn.sessionseq','000_tt_aflogcolumn_002','セッションシーケンス',NULL,1,1,True,1,'1','1','tt_aflogcolumn',NULL,NULL,NULL,'テーブル項目値変更ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--テーブル名
INSERT INTO tm_eutableitem VALUES('tt_aflogcolumn.tablenm','000_tt_aflogcolumn_003','テーブル名',NULL,1,3,True,1,'1','1','tt_aflogcolumn',NULL,NULL,NULL,'テーブル項目値変更ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--変更区分コード
INSERT INTO tm_eutableitem VALUES('tt_aflogcolumn.henkokbn','000_tt_aflogcolumn_004','変更区分コード',NULL,1,3,True,3,'1',NULL,'tt_aflogcolumn',NULL,'111','1000,8','テーブル項目値変更ログテーブル','変更区分',NULL,'system','2023-01-01','system','2023-01-01');
--変更区分名称
INSERT INTO tm_eutableitem VALUES('tt_aflogcolumn_henkokbn_nm.nm','000_tt_aflogcolumn_005','変更区分名称',NULL,0,2,False,1,'1',NULL,'tt_aflogcolumn_henkokbn_nm',NULL,NULL,NULL,'テーブル項目値変更ログテーブル','変更区分',NULL,'system','2023-01-01','system','2023-01-01');
--変更区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_aflogcolumn.henkokbn || '':'' || tt_aflogcolumn_henkokbn_nm.nm','000_tt_aflogcolumn_006','変更区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_aflogcolumn','tt_aflogcolumn_henkokbn_nm',NULL,NULL,'テーブル項目値変更ログテーブル','変更区分',NULL,'system','2023-01-01','system','2023-01-01');
--キー
INSERT INTO tm_eutableitem VALUES('tt_aflogcolumn.keys','000_tt_aflogcolumn_007','キー',NULL,1,3,True,1,'1','1','tt_aflogcolumn',NULL,NULL,NULL,'テーブル項目値変更ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目名
INSERT INTO tm_eutableitem VALUES('tt_aflogcolumn.itemnm','000_tt_aflogcolumn_008','項目名',NULL,1,3,True,1,'1','1','tt_aflogcolumn',NULL,NULL,NULL,'テーブル項目値変更ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--変更前内容
INSERT INTO tm_eutableitem VALUES('tt_aflogcolumn.valuebefore','000_tt_aflogcolumn_009','変更前内容',NULL,1,3,True,1,'1','1','tt_aflogcolumn',NULL,NULL,NULL,'テーブル項目値変更ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新後内容
INSERT INTO tm_eutableitem VALUES('tt_aflogcolumn.valueafter','000_tt_aflogcolumn_010','更新後内容',NULL,1,3,True,1,'1','1','tt_aflogcolumn',NULL,NULL,NULL,'テーブル項目値変更ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_aflogcolumn.reguserid','000_tt_aflogcolumn_011','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_aflogcolumn',NULL,NULL,NULL,'テーブル項目値変更ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_aflogcolumn.regdttm','000_tt_aflogcolumn_012','登録日時',NULL,1,4,False,1,'1','1','tt_aflogcolumn',NULL,NULL,NULL,'テーブル項目値変更ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--DB操作ログシーケンス
INSERT INTO tm_eutableitem VALUES('tt_aflogdb.dblogseq','000_tt_aflogdb_001','DB操作ログシーケンス',NULL,1,1,True,1,'1','1','tt_aflogdb',NULL,NULL,NULL,'DB操作ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--セッションシーケンス
INSERT INTO tm_eutableitem VALUES('tt_aflogdb.sessionseq','000_tt_aflogdb_002','セッションシーケンス',NULL,1,1,True,1,'1','1','tt_aflogdb',NULL,NULL,NULL,'DB操作ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--SQL
INSERT INTO tm_eutableitem VALUES('tt_aflogdb.sql','000_tt_aflogdb_003','SQL',NULL,1,3,True,1,'1','1','tt_aflogdb',NULL,NULL,NULL,'DB操作ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ
INSERT INTO tm_eutableitem VALUES('tt_aflogdb.msg','000_tt_aflogdb_004','メッセージ',NULL,1,3,True,1,'1','1','tt_aflogdb',NULL,NULL,NULL,'DB操作ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_aflogdb.reguserid','000_tt_aflogdb_005','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_aflogdb',NULL,NULL,NULL,'DB操作ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_aflogdb.regdttm','000_tt_aflogdb_006','登録日時',NULL,1,4,False,1,'1','1','tt_aflogdb',NULL,NULL,NULL,'DB操作ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afmemo.atenano','000_tt_afmemo_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afmemo',NULL,NULL,NULL,'メモテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メモシーケンス
INSERT INTO tm_eutableitem VALUES('tt_afmemo.memoseq','000_tt_afmemo_002','メモシーケンス',NULL,1,1,True,1,'1','1','tt_afmemo',NULL,NULL,NULL,'メモテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メモ事業コード
INSERT INTO tm_eutableitem VALUES('tt_afmemo.jigyokbn','000_tt_afmemo_003','メモ事業コード',NULL,1,3,True,3,'1',NULL,'tt_afmemo',NULL,'121','3019,2','メモテーブル','メモ事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--メモ事業名称
INSERT INTO tm_eutableitem VALUES('tt_afmemo_jigyokbn_nm.nm','000_tt_afmemo_004','メモ事業名称',NULL,0,2,False,1,'1',NULL,'tt_afmemo_jigyokbn_nm',NULL,NULL,NULL,'メモテーブル','メモ事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--メモ事業CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afmemo.jigyokbn || '':'' || tt_afmemo_jigyokbn_nm.nm','000_tt_afmemo_005','メモ事業CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afmemo','tt_afmemo_jigyokbn_nm',NULL,NULL,'メモテーブル','メモ事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--重要度コード
INSERT INTO tm_eutableitem VALUES('tt_afmemo.juyodo','000_tt_afmemo_006','重要度コード',NULL,1,3,True,3,'1',NULL,'tt_afmemo',NULL,'111','2019,8','メモテーブル','重要度',NULL,'system','2023-01-01','system','2023-01-01');
--重要度名称
INSERT INTO tm_eutableitem VALUES('tt_afmemo_juyodo_nm.nm','000_tt_afmemo_007','重要度名称',NULL,0,2,False,1,'1',NULL,'tt_afmemo_juyodo_nm',NULL,NULL,NULL,'メモテーブル','重要度',NULL,'system','2023-01-01','system','2023-01-01');
--重要度CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afmemo.juyodo || '':'' || tt_afmemo_juyodo_nm.nm','000_tt_afmemo_008','重要度CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afmemo','tt_afmemo_juyodo_nm',NULL,NULL,'メモテーブル','重要度',NULL,'system','2023-01-01','system','2023-01-01');
--件名（タイトル）
INSERT INTO tm_eutableitem VALUES('tt_afmemo.title','000_tt_afmemo_009','件名（タイトル）',NULL,1,3,True,1,'1','1','tt_afmemo',NULL,NULL,NULL,'メモテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メモ（フリーテキスト）
INSERT INTO tm_eutableitem VALUES('tt_afmemo.memo','000_tt_afmemo_010','メモ（フリーテキスト）',NULL,1,3,True,1,'1','1','tt_afmemo',NULL,NULL,NULL,'メモテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--期限日
INSERT INTO tm_eutableitem VALUES('tt_afmemo.kigenymd','000_tt_afmemo_011','期限日',NULL,1,3,True,1,'1','1','tt_afmemo',NULL,NULL,NULL,'メモテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録支所コード
INSERT INTO tm_eutableitem VALUES('tt_afmemo.regsisyo','000_tt_afmemo_012','登録支所コード',NULL,1,3,True,3,'1',NULL,'tt_afmemo',NULL,'121','3019,1','メモテーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所名称
INSERT INTO tm_eutableitem VALUES('tt_afmemo_regsisyo_nm.nm','000_tt_afmemo_013','登録支所名称',NULL,0,2,False,1,'1',NULL,'tt_afmemo_regsisyo_nm',NULL,NULL,NULL,'メモテーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afmemo.regsisyo || '':'' || tt_afmemo_regsisyo_nm.nm','000_tt_afmemo_014','登録支所CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afmemo','tt_afmemo_regsisyo_nm',NULL,NULL,'メモテーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afmemo.reguserid','000_tt_afmemo_015','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afmemo',NULL,NULL,NULL,'メモテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afmemo.regdttm','000_tt_afmemo_016','登録日時',NULL,1,4,False,1,'1','1','tt_afmemo',NULL,NULL,NULL,'メモテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afmemo.upduserid','000_tt_afmemo_017','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afmemo',NULL,NULL,NULL,'メモテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afmemo.upddttm','000_tt_afmemo_018','更新日時',NULL,1,4,False,1,'1','1','tt_afmemo',NULL,NULL,NULL,'メモテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--世帯番号
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.setaino','000_tt_afmemosetai_001','世帯番号',NULL,1,3,True,1,'1','1','tt_afmemosetai',NULL,NULL,NULL,'メモ情報（世帯）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メモシーケンス
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.memoseq','000_tt_afmemosetai_002','メモシーケンス',NULL,1,1,True,1,'1','1','tt_afmemosetai',NULL,NULL,NULL,'メモ情報（世帯）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メモ事業コード
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.jigyokbn','000_tt_afmemosetai_003','メモ事業コード',NULL,1,3,True,3,'1',NULL,'tt_afmemosetai',NULL,'121','3019,2','メモ情報（世帯）テーブル','メモ事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--メモ事業名称
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai_jigyokbn_nm.nm','000_tt_afmemosetai_004','メモ事業名称',NULL,0,2,False,1,'1',NULL,'tt_afmemosetai_jigyokbn_nm',NULL,NULL,NULL,'メモ情報（世帯）テーブル','メモ事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--メモ事業CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.jigyokbn || '':'' || tt_afmemosetai_jigyokbn_nm.nm','000_tt_afmemosetai_005','メモ事業CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afmemosetai','tt_afmemosetai_jigyokbn_nm',NULL,NULL,'メモ情報（世帯）テーブル','メモ事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--重要度コード
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.juyodo','000_tt_afmemosetai_006','重要度コード',NULL,1,3,True,3,'1',NULL,'tt_afmemosetai',NULL,'111','2019,8','メモ情報（世帯）テーブル','重要度',NULL,'system','2023-01-01','system','2023-01-01');
--重要度名称
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai_juyodo_nm.nm','000_tt_afmemosetai_007','重要度名称',NULL,0,2,False,1,'1',NULL,'tt_afmemosetai_juyodo_nm',NULL,NULL,NULL,'メモ情報（世帯）テーブル','重要度',NULL,'system','2023-01-01','system','2023-01-01');
--重要度CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.juyodo || '':'' || tt_afmemosetai_juyodo_nm.nm','000_tt_afmemosetai_008','重要度CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afmemosetai','tt_afmemosetai_juyodo_nm',NULL,NULL,'メモ情報（世帯）テーブル','重要度',NULL,'system','2023-01-01','system','2023-01-01');
--件名（タイトル）
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.title','000_tt_afmemosetai_009','件名（タイトル）',NULL,1,3,True,1,'1','1','tt_afmemosetai',NULL,NULL,NULL,'メモ情報（世帯）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メモ（フリーテキスト）
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.memo','000_tt_afmemosetai_010','メモ（フリーテキスト）',NULL,1,3,True,1,'1','1','tt_afmemosetai',NULL,NULL,NULL,'メモ情報（世帯）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--期限日
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.kigenymd','000_tt_afmemosetai_011','期限日',NULL,1,3,True,1,'1','1','tt_afmemosetai',NULL,NULL,NULL,'メモ情報（世帯）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録支所コード
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.regsisyo','000_tt_afmemosetai_012','登録支所コード',NULL,1,3,True,3,'1',NULL,'tt_afmemosetai',NULL,'121','3019,1','メモ情報（世帯）テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所名称
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai_regsisyo_nm.nm','000_tt_afmemosetai_013','登録支所名称',NULL,0,2,False,1,'1',NULL,'tt_afmemosetai_regsisyo_nm',NULL,NULL,NULL,'メモ情報（世帯）テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.regsisyo || '':'' || tt_afmemosetai_regsisyo_nm.nm','000_tt_afmemosetai_014','登録支所CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afmemosetai','tt_afmemosetai_regsisyo_nm',NULL,NULL,'メモ情報（世帯）テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.reguserid','000_tt_afmemosetai_015','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afmemosetai',NULL,NULL,NULL,'メモ情報（世帯）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.regdttm','000_tt_afmemosetai_016','登録日時',NULL,1,4,False,1,'1','1','tt_afmemosetai',NULL,NULL,NULL,'メモ情報（世帯）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.upduserid','000_tt_afmemosetai_017','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afmemosetai',NULL,NULL,NULL,'メモ情報（世帯）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afmemosetai.upddttm','000_tt_afmemosetai_018','更新日時',NULL,1,4,False,1,'1','1','tt_afmemosetai',NULL,NULL,NULL,'メモ情報（世帯）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afokiniiri.userid','000_tt_afokiniiri_001','ユーザーID',NULL,1,3,True,1,'1','1','tt_afokiniiri',NULL,NULL,NULL,'お気に入りテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--機能ID
INSERT INTO tm_eutableitem VALUES('tt_afokiniiri.kinoid','000_tt_afokiniiri_002','機能ID',NULL,1,3,True,1,'1','1','tt_afokiniiri',NULL,NULL,NULL,'お気に入りテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--並びシーケンス
INSERT INTO tm_eutableitem VALUES('tt_afokiniiri.orderseq','000_tt_afokiniiri_003','並びシーケンス',NULL,1,1,True,1,'1','1','tt_afokiniiri',NULL,NULL,NULL,'お気に入りテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afpersonalno.atenano','000_tt_afpersonalno_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afpersonalno',NULL,NULL,NULL,'個人番号管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afpersonalno.rirekino','000_tt_afpersonalno_002','履歴番号',NULL,1,1,True,1,'1','1','tt_afpersonalno',NULL,NULL,NULL,'個人番号管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人番号（マイナンバー）
INSERT INTO tm_eutableitem VALUES('tt_afpersonalno.personalno','000_tt_afpersonalno_003','個人番号（マイナンバー）',NULL,1,3,True,1,'1','1','tt_afpersonalno',NULL,NULL,NULL,'個人番号管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作者ID
INSERT INTO tm_eutableitem VALUES('tt_afpersonalno.renkeimotosousauserid','000_tt_afpersonalno_004','連携元操作者ID',NULL,1,3,True,1,'1','1','tt_afpersonalno',NULL,NULL,NULL,'個人番号管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作日時
INSERT INTO tm_eutableitem VALUES('tt_afpersonalno.renkeimotosousadttm','000_tt_afpersonalno_005','連携元操作日時',NULL,1,4,True,1,'1','1','tt_afpersonalno',NULL,NULL,NULL,'個人番号管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--最新フラグ
INSERT INTO tm_eutableitem VALUES('tt_afpersonalno.saisinflg','000_tt_afpersonalno_006','最新フラグ',NULL,1,6,True,1,'1','1','tt_afpersonalno',NULL,NULL,NULL,'個人番号管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afpersonalno.reguserid','000_tt_afpersonalno_007','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afpersonalno',NULL,NULL,NULL,'個人番号管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afpersonalno.regdttm','000_tt_afpersonalno_008','登録日時',NULL,1,4,False,1,'1','1','tt_afpersonalno',NULL,NULL,NULL,'個人番号管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afpersonalno.upduserid','000_tt_afpersonalno_009','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afpersonalno',NULL,NULL,NULL,'個人番号管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afpersonalno.upddttm','000_tt_afpersonalno_010','更新日時',NULL,1,4,False,1,'1','1','tt_afpersonalno',NULL,NULL,NULL,'個人番号管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki.atenano','000_tt_afrenrakusaki_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afrenrakusaki',NULL,NULL,NULL,'連絡先テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--個人連絡先利用事業コード
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki.jigyocd','000_tt_afrenrakusaki_002','個人連絡先利用事業コード',NULL,1,3,True,1,'1','1','tt_afrenrakusaki',NULL,NULL,NULL,'連絡先テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--電話番号
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki.tel','000_tt_afrenrakusaki_003','電話番号',NULL,1,3,True,1,'1','1','tt_afrenrakusaki',NULL,NULL,NULL,'連絡先テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--携帯番号
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki.keitaitel','000_tt_afrenrakusaki_004','携帯番号',NULL,1,3,True,1,'1','1','tt_afrenrakusaki',NULL,NULL,NULL,'連絡先テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--E-mailアドレス
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki.emailadrs','000_tt_afrenrakusaki_005','E-mailアドレス',NULL,1,3,True,1,'1','1','tt_afrenrakusaki',NULL,NULL,NULL,'連絡先テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--E-mailアドレス2
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki.emailadrs2','000_tt_afrenrakusaki_006','E-mailアドレス2',NULL,1,3,True,1,'1','1','tt_afrenrakusaki',NULL,NULL,NULL,'連絡先テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連絡先詳細
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki.syosai','000_tt_afrenrakusaki_007','連絡先詳細',NULL,1,3,True,1,'1','1','tt_afrenrakusaki',NULL,NULL,NULL,'連絡先テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録支所コード
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki.regsisyo','000_tt_afrenrakusaki_008','登録支所コード',NULL,1,3,True,3,'1',NULL,'tt_afrenrakusaki',NULL,'121','3019,1','連絡先テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所名称
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki_regsisyo_nm.nm','000_tt_afrenrakusaki_009','登録支所名称',NULL,0,2,False,1,'1',NULL,'tt_afrenrakusaki_regsisyo_nm',NULL,NULL,NULL,'連絡先テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki.regsisyo || '':'' || tt_afrenrakusaki_regsisyo_nm.nm','000_tt_afrenrakusaki_010','登録支所CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afrenrakusaki','tt_afrenrakusaki_regsisyo_nm',NULL,NULL,'連絡先テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki.reguserid','000_tt_afrenrakusaki_011','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afrenrakusaki',NULL,NULL,NULL,'連絡先テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki.regdttm','000_tt_afrenrakusaki_012','登録日時',NULL,1,4,False,1,'1','1','tt_afrenrakusaki',NULL,NULL,NULL,'連絡先テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki.upduserid','000_tt_afrenrakusaki_013','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afrenrakusaki',NULL,NULL,NULL,'連絡先テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afrenrakusaki.upddttm','000_tt_afrenrakusaki_014','更新日時',NULL,1,4,False,1,'1','1','tt_afrenrakusaki',NULL,NULL,NULL,'連絡先テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afseiho.atenano','000_tt_afseiho_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afseiho',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--生活保護開始年月日
INSERT INTO tm_eutableitem VALUES('tt_afseiho.seihoymdf','000_tt_afseiho_002','生活保護開始年月日',NULL,1,3,True,1,'1','1','tt_afseiho',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--停止年月日
INSERT INTO tm_eutableitem VALUES('tt_afseiho.teisiymd','000_tt_afseiho_003','停止年月日',NULL,1,3,True,1,'1','1','tt_afseiho',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--停止解除年月日
INSERT INTO tm_eutableitem VALUES('tt_afseiho.teisikaijoymd','000_tt_afseiho_004','停止解除年月日',NULL,1,3,True,1,'1','1','tt_afseiho',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--単併給区分コード
INSERT INTO tm_eutableitem VALUES('tt_afseiho.tanheikyukbn','000_tt_afseiho_005','単併給区分コード',NULL,1,3,True,3,'1',NULL,'tt_afseiho',NULL,'111','2021,19','【生活保護】生活保護受給情報テーブル','単併給区分',NULL,'system','2023-01-01','system','2023-01-01');
--単併給区分名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_tanheikyukbn_nm.nm','000_tt_afseiho_006','単併給区分名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_tanheikyukbn_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル','単併給区分',NULL,'system','2023-01-01','system','2023-01-01');
--単併給区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho.tanheikyukbn || '':'' || tt_afseiho_tanheikyukbn_nm.nm','000_tt_afseiho_007','単併給区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho','tt_afseiho_tanheikyukbn_nm',NULL,NULL,'【生活保護】生活保護受給情報テーブル','単併給区分',NULL,'system','2023-01-01','system','2023-01-01');
--生活扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho.seikatufujoflg','000_tt_afseiho_008','生活扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho',NULL,'111','2021,900001','【生活保護】生活保護受給情報テーブル','生活扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--生活扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_seikatufujoflg_nm.nm','000_tt_afseiho_009','生活扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_seikatufujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル','生活扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--生活扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho.seikatufujoflg || '':'' || tt_afseiho_seikatufujoflg_nm.nm','000_tt_afseiho_010','生活扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho','tt_afseiho_seikatufujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報テーブル','生活扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--住宅扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho.jutakufujoflg','000_tt_afseiho_011','住宅扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho',NULL,'111','2021,900001','【生活保護】生活保護受給情報テーブル','住宅扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--住宅扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_jutakufujoflg_nm.nm','000_tt_afseiho_012','住宅扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_jutakufujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル','住宅扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--住宅扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho.jutakufujoflg || '':'' || tt_afseiho_jutakufujoflg_nm.nm','000_tt_afseiho_013','住宅扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho','tt_afseiho_jutakufujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報テーブル','住宅扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--教育扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho.kyoikufujoflg','000_tt_afseiho_014','教育扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho',NULL,'111','2021,900001','【生活保護】生活保護受給情報テーブル','教育扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--教育扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_kyoikufujoflg_nm.nm','000_tt_afseiho_015','教育扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_kyoikufujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル','教育扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--教育扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho.kyoikufujoflg || '':'' || tt_afseiho_kyoikufujoflg_nm.nm','000_tt_afseiho_016','教育扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho','tt_afseiho_kyoikufujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報テーブル','教育扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--医療扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho.iryofujoflg','000_tt_afseiho_017','医療扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho',NULL,'111','2021,900001','【生活保護】生活保護受給情報テーブル','医療扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--医療扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_iryofujoflg_nm.nm','000_tt_afseiho_018','医療扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_iryofujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル','医療扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--医療扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho.iryofujoflg || '':'' || tt_afseiho_iryofujoflg_nm.nm','000_tt_afseiho_019','医療扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho','tt_afseiho_iryofujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報テーブル','医療扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--出産扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho.syussanfujoflg','000_tt_afseiho_020','出産扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho',NULL,'111','2021,900001','【生活保護】生活保護受給情報テーブル','出産扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--出産扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_syussanfujoflg_nm.nm','000_tt_afseiho_021','出産扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_syussanfujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル','出産扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--出産扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho.syussanfujoflg || '':'' || tt_afseiho_syussanfujoflg_nm.nm','000_tt_afseiho_022','出産扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho','tt_afseiho_syussanfujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報テーブル','出産扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--生業扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho.seigyofujoflg','000_tt_afseiho_023','生業扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho',NULL,'111','2021,900001','【生活保護】生活保護受給情報テーブル','生業扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--生業扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_seigyofujoflg_nm.nm','000_tt_afseiho_024','生業扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_seigyofujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル','生業扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--生業扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho.seigyofujoflg || '':'' || tt_afseiho_seigyofujoflg_nm.nm','000_tt_afseiho_025','生業扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho','tt_afseiho_seigyofujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報テーブル','生業扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--葬祭扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho.sosaifujoflg','000_tt_afseiho_026','葬祭扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho',NULL,'111','2021,900001','【生活保護】生活保護受給情報テーブル','葬祭扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--葬祭扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_sosaifujoflg_nm.nm','000_tt_afseiho_027','葬祭扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_sosaifujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル','葬祭扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--葬祭扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho.sosaifujoflg || '':'' || tt_afseiho_sosaifujoflg_nm.nm','000_tt_afseiho_028','葬祭扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho','tt_afseiho_sosaifujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報テーブル','葬祭扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--廃止年月日
INSERT INTO tm_eutableitem VALUES('tt_afseiho.haisiymd','000_tt_afseiho_029','廃止年月日',NULL,1,3,True,1,'1','1','tt_afseiho',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afseiho.reguserid','000_tt_afseiho_030','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afseiho',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afseiho.regdttm','000_tt_afseiho_031','登録日時',NULL,1,4,False,1,'1','1','tt_afseiho',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afseiho.upduserid','000_tt_afseiho_032','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afseiho',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afseiho.upddttm','000_tt_afseiho_033','更新日時',NULL,1,4,False,1,'1','1','tt_afseiho',NULL,NULL,NULL,'【生活保護】生活保護受給情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--福祉事務所コード
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.fukusijimusyocd','000_tt_afseiho_reki_001','福祉事務所コード',NULL,1,3,True,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ケース番号
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.caseno','000_tt_afseiho_reki_002','ケース番号',NULL,1,3,True,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--申請履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.sinseirirekino','000_tt_afseiho_reki_003','申請履歴番号',NULL,1,1,True,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--決定履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.ketteirirekino','000_tt_afseiho_reki_004','決定履歴番号',NULL,1,1,True,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--員番号
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.inno','000_tt_afseiho_reki_005','員番号',NULL,1,1,True,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.atenano','000_tt_afseiho_reki_006','宛名番号',NULL,1,3,True,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--生活保護開始年月日
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.seihoymdf','000_tt_afseiho_reki_007','生活保護開始年月日',NULL,1,3,True,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--停止年月日
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.teisiymd','000_tt_afseiho_reki_008','停止年月日',NULL,1,3,True,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--停止解除年月日
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.teisikaijoymd','000_tt_afseiho_reki_009','停止解除年月日',NULL,1,3,True,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--単併給区分コード
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.tanheikyukbn','000_tt_afseiho_reki_010','単併給区分コード',NULL,1,3,True,3,'1',NULL,'tt_afseiho_reki',NULL,'111','2021,19','【生活保護】生活保護受給情報履歴テーブル','単併給区分',NULL,'system','2023-01-01','system','2023-01-01');
--単併給区分名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki_tanheikyukbn_nm.nm','000_tt_afseiho_reki_011','単併給区分名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki_tanheikyukbn_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','単併給区分',NULL,'system','2023-01-01','system','2023-01-01');
--単併給区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.tanheikyukbn || '':'' || tt_afseiho_reki_tanheikyukbn_nm.nm','000_tt_afseiho_reki_012','単併給区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki','tt_afseiho_reki_tanheikyukbn_nm',NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','単併給区分',NULL,'system','2023-01-01','system','2023-01-01');
--生活扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.seikatufujoflg','000_tt_afseiho_reki_013','生活扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho_reki',NULL,'111','2021,900001','【生活保護】生活保護受給情報履歴テーブル','生活扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--生活扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki_seikatufujoflg_nm.nm','000_tt_afseiho_reki_014','生活扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki_seikatufujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','生活扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--生活扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.seikatufujoflg || '':'' || tt_afseiho_reki_seikatufujoflg_nm.nm','000_tt_afseiho_reki_015','生活扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki','tt_afseiho_reki_seikatufujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','生活扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--住宅扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.jutakufujoflg','000_tt_afseiho_reki_016','住宅扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho_reki',NULL,'111','2021,900001','【生活保護】生活保護受給情報履歴テーブル','住宅扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--住宅扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki_jutakufujoflg_nm.nm','000_tt_afseiho_reki_017','住宅扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki_jutakufujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','住宅扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--住宅扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.jutakufujoflg || '':'' || tt_afseiho_reki_jutakufujoflg_nm.nm','000_tt_afseiho_reki_018','住宅扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki','tt_afseiho_reki_jutakufujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','住宅扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--教育扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.kyoikufujoflg','000_tt_afseiho_reki_019','教育扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho_reki',NULL,'111','2021,900001','【生活保護】生活保護受給情報履歴テーブル','教育扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--教育扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki_kyoikufujoflg_nm.nm','000_tt_afseiho_reki_020','教育扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki_kyoikufujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','教育扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--教育扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.kyoikufujoflg || '':'' || tt_afseiho_reki_kyoikufujoflg_nm.nm','000_tt_afseiho_reki_021','教育扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki','tt_afseiho_reki_kyoikufujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','教育扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--医療扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.iryofujoflg','000_tt_afseiho_reki_022','医療扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho_reki',NULL,'111','2021,900001','【生活保護】生活保護受給情報履歴テーブル','医療扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--医療扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki_iryofujoflg_nm.nm','000_tt_afseiho_reki_023','医療扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki_iryofujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','医療扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--医療扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.iryofujoflg || '':'' || tt_afseiho_reki_iryofujoflg_nm.nm','000_tt_afseiho_reki_024','医療扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki','tt_afseiho_reki_iryofujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','医療扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--出産扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.syussanfujoflg','000_tt_afseiho_reki_025','出産扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho_reki',NULL,'111','2021,900001','【生活保護】生活保護受給情報履歴テーブル','出産扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--出産扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki_syussanfujoflg_nm.nm','000_tt_afseiho_reki_026','出産扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki_syussanfujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','出産扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--出産扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.syussanfujoflg || '':'' || tt_afseiho_reki_syussanfujoflg_nm.nm','000_tt_afseiho_reki_027','出産扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki','tt_afseiho_reki_syussanfujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','出産扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--生業扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.seigyofujoflg','000_tt_afseiho_reki_028','生業扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho_reki',NULL,'111','2021,900001','【生活保護】生活保護受給情報履歴テーブル','生業扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--生業扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki_seigyofujoflg_nm.nm','000_tt_afseiho_reki_029','生業扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki_seigyofujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','生業扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--生業扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.seigyofujoflg || '':'' || tt_afseiho_reki_seigyofujoflg_nm.nm','000_tt_afseiho_reki_030','生業扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki','tt_afseiho_reki_seigyofujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','生業扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--葬祭扶助フラグコード
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.sosaifujoflg','000_tt_afseiho_reki_031','葬祭扶助フラグコード',NULL,1,6,True,3,'1',NULL,'tt_afseiho_reki',NULL,'111','2021,900001','【生活保護】生活保護受給情報履歴テーブル','葬祭扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--葬祭扶助フラグ名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki_sosaifujoflg_nm.nm','000_tt_afseiho_reki_032','葬祭扶助フラグ名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki_sosaifujoflg_nm',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','葬祭扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--葬祭扶助フラグCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.sosaifujoflg || '':'' || tt_afseiho_reki_sosaifujoflg_nm.nm','000_tt_afseiho_reki_033','葬祭扶助フラグCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afseiho_reki','tt_afseiho_reki_sosaifujoflg_nm',NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル','葬祭扶助フラグ',NULL,'system','2023-01-01','system','2023-01-01');
--廃止年月日
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.haisiymd','000_tt_afseiho_reki_034','廃止年月日',NULL,1,3,True,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作者ID
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.renkeimotosousauserid','000_tt_afseiho_reki_035','連携元操作者ID',NULL,1,3,True,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作日時
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.renkeimotosousadttm','000_tt_afseiho_reki_036','連携元操作日時',NULL,1,4,True,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--最新フラグ
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.saisinflg','000_tt_afseiho_reki_037','最新フラグ',NULL,1,6,True,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.reguserid','000_tt_afseiho_reki_038','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.regdttm','000_tt_afseiho_reki_039','登録日時',NULL,1,4,False,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.upduserid','000_tt_afseiho_reki_040','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afseiho_reki.upddttm','000_tt_afseiho_reki_041','更新日時',NULL,1,4,False,1,'1','1','tt_afseiho_reki',NULL,NULL,NULL,'【生活保護】生活保護受給情報履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya.atenano','000_tt_afsiensotitaisyosya_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afsiensotitaisyosya',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--支援措置開始年月日
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya.siensotiymdf','000_tt_afsiensotitaisyosya_002','支援措置開始年月日',NULL,1,3,True,1,'1','1','tt_afsiensotitaisyosya',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--支援措置終了年月日
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya.siensotiymdt','000_tt_afsiensotitaisyosya_003','支援措置終了年月日',NULL,1,3,True,1,'1','1','tt_afsiensotitaisyosya',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--支援措置区分コード
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya.siensotikbn','000_tt_afsiensotitaisyosya_004','支援措置区分コード',NULL,1,3,True,3,'1',NULL,'tt_afsiensotitaisyosya',NULL,'111','2001,32','【住民基本台帳】支援措置対象者情報テーブ','支援措置区分',NULL,'system','2023-01-01','system','2023-01-01');
--支援措置区分名称
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_siensotikbn_nm.nm','000_tt_afsiensotitaisyosya_005','支援措置区分名称',NULL,0,2,False,1,'1',NULL,'tt_afsiensotitaisyosya_siensotikbn_nm',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報テーブ','支援措置区分',NULL,'system','2023-01-01','system','2023-01-01');
--支援措置区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya.siensotikbn || '':'' || tt_afsiensotitaisyosya_siensotikbn_nm.nm','000_tt_afsiensotitaisyosya_006','支援措置区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afsiensotitaisyosya','tt_afsiensotitaisyosya_siensotikbn_nm',NULL,NULL,'【住民基本台帳】支援措置対象者情報テーブ','支援措置区分',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya.reguserid','000_tt_afsiensotitaisyosya_007','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afsiensotitaisyosya',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya.regdttm','000_tt_afsiensotitaisyosya_008','登録日時',NULL,1,4,False,1,'1','1','tt_afsiensotitaisyosya',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya.upduserid','000_tt_afsiensotitaisyosya_009','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afsiensotitaisyosya',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya.upddttm','000_tt_afsiensotitaisyosya_010','更新日時',NULL,1,4,False,1,'1','1','tt_afsiensotitaisyosya',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki.atenano','000_tt_afsiensotitaisyosya_reki_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afsiensotitaisyosya_reki',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki.rirekino','000_tt_afsiensotitaisyosya_reki_002','履歴番号',NULL,1,1,True,1,'1','1','tt_afsiensotitaisyosya_reki',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--支援措置開始年月日
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki.siensotiymdf','000_tt_afsiensotitaisyosya_reki_003','支援措置開始年月日',NULL,1,3,True,1,'1','1','tt_afsiensotitaisyosya_reki',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--支援措置終了年月日
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki.siensotiymdt','000_tt_afsiensotitaisyosya_reki_004','支援措置終了年月日',NULL,1,3,True,1,'1','1','tt_afsiensotitaisyosya_reki',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--支援措置区分コード
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki.siensotikbn','000_tt_afsiensotitaisyosya_reki_005','支援措置区分コード',NULL,1,3,True,3,'1',NULL,'tt_afsiensotitaisyosya_reki',NULL,'111','2001,32','【住民基本台帳】支援措置対象者情報履歴テ','支援措置区分',NULL,'system','2023-01-01','system','2023-01-01');
--支援措置区分名称
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki_siensotikbn_nm.nm','000_tt_afsiensotitaisyosya_reki_006','支援措置区分名称',NULL,0,2,False,1,'1',NULL,'tt_afsiensotitaisyosya_reki_siensotikbn_nm',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報履歴テ','支援措置区分',NULL,'system','2023-01-01','system','2023-01-01');
--支援措置区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki.siensotikbn || '':'' || tt_afsiensotitaisyosya_reki_siensotikbn_nm.nm','000_tt_afsiensotitaisyosya_reki_007','支援措置区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afsiensotitaisyosya_reki','tt_afsiensotitaisyosya_reki_siensotikbn_nm',NULL,NULL,'【住民基本台帳】支援措置対象者情報履歴テ','支援措置区分',NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作者ID
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki.renkeimotosousauserid','000_tt_afsiensotitaisyosya_reki_008','連携元操作者ID',NULL,1,3,True,1,'1','1','tt_afsiensotitaisyosya_reki',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作日時
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki.renkeimotosousadttm','000_tt_afsiensotitaisyosya_reki_009','連携元操作日時',NULL,1,4,True,1,'1','1','tt_afsiensotitaisyosya_reki',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--最新フラグ
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki.saisinflg','000_tt_afsiensotitaisyosya_reki_010','最新フラグ',NULL,1,6,True,1,'1','1','tt_afsiensotitaisyosya_reki',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki.reguserid','000_tt_afsiensotitaisyosya_reki_011','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afsiensotitaisyosya_reki',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki.regdttm','000_tt_afsiensotitaisyosya_reki_012','登録日時',NULL,1,4,False,1,'1','1','tt_afsiensotitaisyosya_reki',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki.upduserid','000_tt_afsiensotitaisyosya_reki_013','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afsiensotitaisyosya_reki',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afsiensotitaisyosya_reki.upddttm','000_tt_afsiensotitaisyosya_reki_014','更新日時',NULL,1,4,False,1,'1','1','tt_afsiensotitaisyosya_reki',NULL,NULL,NULL,'【住民基本台帳】支援措置対象者情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afsiyorireki.userid','000_tt_afsiyorireki_001','ユーザーID',NULL,1,3,True,1,'1','1','tt_afsiyorireki',NULL,NULL,NULL,'使用履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--機能ID
INSERT INTO tm_eutableitem VALUES('tt_afsiyorireki.kinoid','000_tt_afsiyorireki_002','機能ID',NULL,1,3,True,1,'1','1','tt_afsiyorireki',NULL,NULL,NULL,'使用履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--処理日時
INSERT INTO tm_eutableitem VALUES('tt_afsiyorireki.syoridttm','000_tt_afsiyorireki_003','処理日時',NULL,1,4,True,1,'1','1','tt_afsiyorireki',NULL,NULL,NULL,'使用履歴テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.atenano','000_tt_afsofusaki_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--利用目的コード
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.riyomokuteki','000_tt_afsofusaki_002','利用目的コード',NULL,1,3,True,3,'1',NULL,'tt_afsofusaki',NULL,'121','3019,10005','送付先管理テーブル','利用目的',NULL,'system','2023-01-01','system','2023-01-01');
--利用目的名称
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki_riyomokuteki_nm.nm','000_tt_afsofusaki_003','利用目的名称',NULL,0,2,False,1,'1',NULL,'tt_afsofusaki_riyomokuteki_nm',NULL,NULL,NULL,'送付先管理テーブル','利用目的',NULL,'system','2023-01-01','system','2023-01-01');
--利用目的CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.riyomokuteki || '':'' || tt_afsofusaki_riyomokuteki_nm.nm','000_tt_afsofusaki_004','利用目的CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afsofusaki','tt_afsofusaki_riyomokuteki_nm',NULL,NULL,'送付先管理テーブル','利用目的',NULL,'system','2023-01-01','system','2023-01-01');
--住所_市区町村コード
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.adrs_sikucd','000_tt_afsofusaki_005','住所_市区町村コード',NULL,1,3,True,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_町字コード
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.adrs_tyoazacd','000_tt_afsofusaki_006','住所_町字コード',NULL,1,3,True,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_都道府県
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.adrs_todofuken','000_tt_afsofusaki_007','住所_都道府県',NULL,1,3,True,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_市区郡町村名
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.adrs_sikunm','000_tt_afsofusaki_008','住所_市区郡町村名',NULL,1,3,True,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_町字
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.adrs_tyoaza','000_tt_afsofusaki_009','住所_町字',NULL,1,3,True,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_番地号表記
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.adrs_bantihyoki','000_tt_afsofusaki_010','住所_番地号表記',NULL,1,3,True,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_方書
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.adrs_katagaki','000_tt_afsofusaki_011','住所_方書',NULL,1,3,True,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--住所_郵便番号
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.adrs_yubin','000_tt_afsofusaki_012','住所_郵便番号',NULL,1,3,True,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル','住所''',NULL,'system','2023-01-01','system','2023-01-01');
--送付先氏名
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.sofusaki_simei','000_tt_afsofusaki_013','送付先氏名',NULL,1,3,True,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録事由コード
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.torokujiyu','000_tt_afsofusaki_014','登録事由コード',NULL,1,3,True,3,'1',NULL,'tt_afsofusaki',NULL,'111','2019,4','送付先管理テーブル','登録事由',NULL,'system','2023-01-01','system','2023-01-01');
--登録事由名称
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki_torokujiyu_nm.nm','000_tt_afsofusaki_015','登録事由名称',NULL,0,2,False,1,'1',NULL,'tt_afsofusaki_torokujiyu_nm',NULL,NULL,NULL,'送付先管理テーブル','登録事由',NULL,'system','2023-01-01','system','2023-01-01');
--登録事由CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.torokujiyu || '':'' || tt_afsofusaki_torokujiyu_nm.nm','000_tt_afsofusaki_016','登録事由CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afsofusaki','tt_afsofusaki_torokujiyu_nm',NULL,NULL,'送付先管理テーブル','登録事由',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所コード
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.regsisyo','000_tt_afsofusaki_017','登録支所コード',NULL,1,3,True,3,'1',NULL,'tt_afsofusaki',NULL,'121','3019,1','送付先管理テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所名称
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki_regsisyo_nm.nm','000_tt_afsofusaki_018','登録支所名称',NULL,0,2,False,1,'1',NULL,'tt_afsofusaki_regsisyo_nm',NULL,NULL,NULL,'送付先管理テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.regsisyo || '':'' || tt_afsofusaki_regsisyo_nm.nm','000_tt_afsofusaki_019','登録支所CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afsofusaki','tt_afsofusaki_regsisyo_nm',NULL,NULL,'送付先管理テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.reguserid','000_tt_afsofusaki_020','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.regdttm','000_tt_afsofusaki_021','登録日時',NULL,1,4,False,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.upduserid','000_tt_afsofusaki_022','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afsofusaki.upddttm','000_tt_afsofusaki_023','更新日時',NULL,1,4,False,1,'1','1','tt_afsofusaki',NULL,NULL,NULL,'送付先管理テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.atenano','000_tt_afsyogaitetyo_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afsyogaitetyo',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--返還日
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.henkanymd','000_tt_afsyogaitetyo_002','返還日',NULL,1,3,True,1,'1','1','tt_afsyogaitetyo',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--資格状態コード
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.sikakujotaicd','000_tt_afsyogaitetyo_003','資格状態コード',NULL,1,3,True,3,'1',NULL,'tt_afsyogaitetyo',NULL,'111','2022,8','【障害者福祉】身体障害者手帳等情報テーブ','資格状態コード',NULL,'system','2023-01-01','system','2023-01-01');
--資格状態名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_sikakujotaicd_nm.nm','000_tt_afsyogaitetyo_004','資格状態名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo_sikakujotaicd_nm',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ','資格状態コード',NULL,'system','2023-01-01','system','2023-01-01');
--資格状態CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.sikakujotaicd || '':'' || tt_afsyogaitetyo_sikakujotaicd_nm.nm','000_tt_afsyogaitetyo_005','資格状態CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo','tt_afsyogaitetyo_sikakujotaicd_nm',NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ','資格状態コード',NULL,'system','2023-01-01','system','2023-01-01');
--初回交付日
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.syokaikofuymd','000_tt_afsyogaitetyo_006','初回交付日',NULL,1,3,True,1,'1','1','tt_afsyogaitetyo',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--手帳番号
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.tetyono','000_tt_afsyogaitetyo_007','手帳番号',NULL,1,3,True,1,'1','1','tt_afsyogaitetyo',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--統計部位コード
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.tokeibuicd','000_tt_afsyogaitetyo_008','統計部位コード',NULL,1,3,True,3,'1',NULL,'tt_afsyogaitetyo',NULL,'111','2022,17','【障害者福祉】身体障害者手帳等情報テーブ','統計部位コード',NULL,'system','2023-01-01','system','2023-01-01');
--統計部位名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_tokeibuicd_nm.nm','000_tt_afsyogaitetyo_009','統計部位名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo_tokeibuicd_nm',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ','統計部位コード',NULL,'system','2023-01-01','system','2023-01-01');
--統計部位CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.tokeibuicd || '':'' || tt_afsyogaitetyo_tokeibuicd_nm.nm','000_tt_afsyogaitetyo_010','統計部位CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo','tt_afsyogaitetyo_tokeibuicd_nm',NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ','統計部位コード',NULL,'system','2023-01-01','system','2023-01-01');
--障害名
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.syogainm','000_tt_afsyogaitetyo_011','障害名',NULL,1,3,True,1,'1','1','tt_afsyogaitetyo',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--障害種別コード
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.syogaisyubetucd','000_tt_afsyogaitetyo_012','障害種別コード',NULL,1,3,True,3,'1',NULL,'tt_afsyogaitetyo',NULL,'111','2022,15','【障害者福祉】身体障害者手帳等情報テーブ','障害種別コード',NULL,'system','2023-01-01','system','2023-01-01');
--障害種別名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_syogaisyubetucd_nm.nm','000_tt_afsyogaitetyo_013','障害種別名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo_syogaisyubetucd_nm',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ','障害種別コード',NULL,'system','2023-01-01','system','2023-01-01');
--障害種別CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.syogaisyubetucd || '':'' || tt_afsyogaitetyo_syogaisyubetucd_nm.nm','000_tt_afsyogaitetyo_014','障害種別CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo','tt_afsyogaitetyo_syogaisyubetucd_nm',NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ','障害種別コード',NULL,'system','2023-01-01','system','2023-01-01');
--総合等級コード
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.sogotokyucd','000_tt_afsyogaitetyo_015','総合等級コード',NULL,1,3,True,3,'1',NULL,'tt_afsyogaitetyo',NULL,'111','2022,16','【障害者福祉】身体障害者手帳等情報テーブ','総合等級コード',NULL,'system','2023-01-01','system','2023-01-01');
--総合等級名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_sogotokyucd_nm.nm','000_tt_afsyogaitetyo_016','総合等級名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo_sogotokyucd_nm',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ','総合等級コード',NULL,'system','2023-01-01','system','2023-01-01');
--総合等級CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.sogotokyucd || '':'' || tt_afsyogaitetyo_sogotokyucd_nm.nm','000_tt_afsyogaitetyo_017','総合等級CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo','tt_afsyogaitetyo_sogotokyucd_nm',NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ','総合等級コード',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.reguserid','000_tt_afsyogaitetyo_018','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afsyogaitetyo',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.regdttm','000_tt_afsyogaitetyo_019','登録日時',NULL,1,4,False,1,'1','1','tt_afsyogaitetyo',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.upduserid','000_tt_afsyogaitetyo_020','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afsyogaitetyo',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo.upddttm','000_tt_afsyogaitetyo_021','更新日時',NULL,1,4,False,1,'1','1','tt_afsyogaitetyo',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.atenano','000_tt_afsyogaitetyo_reki_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afsyogaitetyo_reki',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.rirekino','000_tt_afsyogaitetyo_reki_002','履歴番号',NULL,1,1,True,1,'1','1','tt_afsyogaitetyo_reki',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--返還日
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.henkanymd','000_tt_afsyogaitetyo_reki_003','返還日',NULL,1,3,True,1,'1','1','tt_afsyogaitetyo_reki',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--資格状態コード
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.sikakujotaicd','000_tt_afsyogaitetyo_reki_004','資格状態コード',NULL,1,3,True,3,'1',NULL,'tt_afsyogaitetyo_reki',NULL,'111','2022,8','【障害者福祉】身体障害者手帳等情報履歴テ','資格状態コード',NULL,'system','2023-01-01','system','2023-01-01');
--資格状態名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki_sikakujotaicd_nm.nm','000_tt_afsyogaitetyo_reki_005','資格状態名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo_reki_sikakujotaicd_nm',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ','資格状態コード',NULL,'system','2023-01-01','system','2023-01-01');
--資格状態CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.sikakujotaicd || '':'' || tt_afsyogaitetyo_reki_sikakujotaicd_nm.nm','000_tt_afsyogaitetyo_reki_006','資格状態CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo_reki','tt_afsyogaitetyo_reki_sikakujotaicd_nm',NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ','資格状態コード',NULL,'system','2023-01-01','system','2023-01-01');
--初回交付日
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.syokaikofuymd','000_tt_afsyogaitetyo_reki_007','初回交付日',NULL,1,3,True,1,'1','1','tt_afsyogaitetyo_reki',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--手帳番号
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.tetyono','000_tt_afsyogaitetyo_reki_008','手帳番号',NULL,1,3,True,1,'1','1','tt_afsyogaitetyo_reki',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--統計部位コード
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.tokeibuicd','000_tt_afsyogaitetyo_reki_009','統計部位コード',NULL,1,3,True,3,'1',NULL,'tt_afsyogaitetyo_reki',NULL,'111','2022,17','【障害者福祉】身体障害者手帳等情報履歴テ','統計部位コード',NULL,'system','2023-01-01','system','2023-01-01');
--統計部位名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki_tokeibuicd_nm.nm','000_tt_afsyogaitetyo_reki_010','統計部位名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo_reki_tokeibuicd_nm',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ','統計部位コード',NULL,'system','2023-01-01','system','2023-01-01');
--統計部位CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.tokeibuicd || '':'' || tt_afsyogaitetyo_reki_tokeibuicd_nm.nm','000_tt_afsyogaitetyo_reki_011','統計部位CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo_reki','tt_afsyogaitetyo_reki_tokeibuicd_nm',NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ','統計部位コード',NULL,'system','2023-01-01','system','2023-01-01');
--障害名
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.syogainm','000_tt_afsyogaitetyo_reki_012','障害名',NULL,1,3,True,1,'1','1','tt_afsyogaitetyo_reki',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--障害種別コード
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.syogaisyubetucd','000_tt_afsyogaitetyo_reki_013','障害種別コード',NULL,1,3,True,3,'1',NULL,'tt_afsyogaitetyo_reki',NULL,'111','2022,15','【障害者福祉】身体障害者手帳等情報履歴テ','障害種別コード',NULL,'system','2023-01-01','system','2023-01-01');
--障害種別名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki_syogaisyubetucd_nm.nm','000_tt_afsyogaitetyo_reki_014','障害種別名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo_reki_syogaisyubetucd_nm',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ','障害種別コード',NULL,'system','2023-01-01','system','2023-01-01');
--障害種別CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.syogaisyubetucd || '':'' || tt_afsyogaitetyo_reki_syogaisyubetucd_nm.nm','000_tt_afsyogaitetyo_reki_015','障害種別CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo_reki','tt_afsyogaitetyo_reki_syogaisyubetucd_nm',NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ','障害種別コード',NULL,'system','2023-01-01','system','2023-01-01');
--総合等級コード
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.sogotokyucd','000_tt_afsyogaitetyo_reki_016','総合等級コード',NULL,1,3,True,3,'1',NULL,'tt_afsyogaitetyo_reki',NULL,'111','2022,16','【障害者福祉】身体障害者手帳等情報履歴テ','総合等級コード',NULL,'system','2023-01-01','system','2023-01-01');
--総合等級名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki_sogotokyucd_nm.nm','000_tt_afsyogaitetyo_reki_017','総合等級名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo_reki_sogotokyucd_nm',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ','総合等級コード',NULL,'system','2023-01-01','system','2023-01-01');
--総合等級CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.sogotokyucd || '':'' || tt_afsyogaitetyo_reki_sogotokyucd_nm.nm','000_tt_afsyogaitetyo_reki_018','総合等級CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afsyogaitetyo_reki','tt_afsyogaitetyo_reki_sogotokyucd_nm',NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ','総合等級コード',NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作者ID
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.renkeimotosousauserid','000_tt_afsyogaitetyo_reki_019','連携元操作者ID',NULL,1,3,True,1,'1','1','tt_afsyogaitetyo_reki',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--連携元操作日時
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.renkeimotosousadttm','000_tt_afsyogaitetyo_reki_020','連携元操作日時',NULL,1,4,True,1,'1','1','tt_afsyogaitetyo_reki',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--最新フラグ
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.saisinflg','000_tt_afsyogaitetyo_reki_021','最新フラグ',NULL,1,6,True,1,'1','1','tt_afsyogaitetyo_reki',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.reguserid','000_tt_afsyogaitetyo_reki_022','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afsyogaitetyo_reki',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.regdttm','000_tt_afsyogaitetyo_reki_023','登録日時',NULL,1,4,False,1,'1','1','tt_afsyogaitetyo_reki',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.upduserid','000_tt_afsyogaitetyo_reki_024','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afsyogaitetyo_reki',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afsyogaitetyo_reki.upddttm','000_tt_afsyogaitetyo_reki_025','更新日時',NULL,1,4,False,1,'1','1','tt_afsyogaitetyo_reki',NULL,NULL,NULL,'【障害者福祉】身体障害者手帳等情報履歴テ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--通信ログシーケンス
INSERT INTO tm_eutableitem VALUES('tt_aftusinlog.tusinlogseq','000_tt_aftusinlog_001','通信ログシーケンス',NULL,1,1,True,1,'1','1','tt_aftusinlog',NULL,NULL,NULL,'通信ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--セッションシーケンス
INSERT INTO tm_eutableitem VALUES('tt_aftusinlog.sessionseq','000_tt_aftusinlog_002','セッションシーケンス',NULL,1,1,True,1,'1','1','tt_aftusinlog',NULL,NULL,NULL,'通信ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--処理日時（開始）
INSERT INTO tm_eutableitem VALUES('tt_aftusinlog.syoridttmf','000_tt_aftusinlog_003','処理日時（開始）',NULL,1,4,True,1,'1','1','tt_aftusinlog',NULL,NULL,NULL,'通信ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--処理日時（終了）
INSERT INTO tm_eutableitem VALUES('tt_aftusinlog.syoridttmt','000_tt_aftusinlog_004','処理日時（終了）',NULL,1,4,True,1,'1','1','tt_aftusinlog',NULL,NULL,NULL,'通信ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ
INSERT INTO tm_eutableitem VALUES('tt_aftusinlog.msg','000_tt_aftusinlog_005','メッセージ',NULL,1,3,True,1,'1','1','tt_aftusinlog',NULL,NULL,NULL,'通信ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--リクエスト
INSERT INTO tm_eutableitem VALUES('tt_aftusinlog.request','000_tt_aftusinlog_006','リクエスト',NULL,1,3,True,1,'1','1','tt_aftusinlog',NULL,NULL,NULL,'通信ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--レスポンス
INSERT INTO tm_eutableitem VALUES('tt_aftusinlog.response','000_tt_aftusinlog_007','レスポンス',NULL,1,3,True,1,'1','1','tt_aftusinlog',NULL,NULL,NULL,'通信ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--IPアドレス
INSERT INTO tm_eutableitem VALUES('tt_aftusinlog.ipadrs','000_tt_aftusinlog_008','IPアドレス',NULL,1,3,True,1,'1','1','tt_aftusinlog',NULL,NULL,NULL,'通信ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--OS
INSERT INTO tm_eutableitem VALUES('tt_aftusinlog.os','000_tt_aftusinlog_009','OS',NULL,1,3,True,1,'1','1','tt_aftusinlog',NULL,NULL,NULL,'通信ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ブラウザー情報
INSERT INTO tm_eutableitem VALUES('tt_aftusinlog.browser','000_tt_aftusinlog_010','ブラウザー情報',NULL,1,3,True,1,'1','1','tt_aftusinlog',NULL,NULL,NULL,'通信ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_aftusinlog.reguserid','000_tt_aftusinlog_011','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_aftusinlog',NULL,NULL,NULL,'通信ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_aftusinlog.regdttm','000_tt_aftusinlog_012','登録日時',NULL,1,4,False,1,'1','1','tt_aftusinlog',NULL,NULL,NULL,'通信ログテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afuser_sisyo.userid','000_tt_afuser_sisyo_001','ユーザーID',NULL,1,3,True,1,'1','1','tt_afuser_sisyo',NULL,NULL,NULL,'ユーザー所属部署（支所）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--部署（支所）コード
INSERT INTO tm_eutableitem VALUES('tt_afuser_sisyo.sisyocd','000_tt_afuser_sisyo_002','部署（支所）コード',NULL,1,3,True,3,'1',NULL,'tt_afuser_sisyo',NULL,'121','3019,1','ユーザー所属部署（支所）テーブル','部署（支所）コード',NULL,'system','2023-01-01','system','2023-01-01');
--部署（支所）名称
INSERT INTO tm_eutableitem VALUES('tt_afuser_sisyo_sisyocd_nm.nm','000_tt_afuser_sisyo_003','部署（支所）名称',NULL,0,2,False,1,'1',NULL,'tt_afuser_sisyo_sisyocd_nm',NULL,NULL,NULL,'ユーザー所属部署（支所）テーブル','部署（支所）コード',NULL,'system','2023-01-01','system','2023-01-01');
--部署（支所）CD:名称
INSERT INTO tm_eutableitem VALUES('tt_afuser_sisyo.sisyocd || '':'' || tt_afuser_sisyo_sisyocd_nm.nm','000_tt_afuser_sisyo_004','部署（支所）CD:名称',NULL,0,2,False,1,'1',NULL,'tt_afuser_sisyo','tt_afuser_sisyo_sisyocd_nm',NULL,NULL,'ユーザー所属部署（支所）テーブル','部署（支所）コード',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afuser_sisyo.reguserid','000_tt_afuser_sisyo_005','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_afuser_sisyo',NULL,NULL,NULL,'ユーザー所属部署（支所）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_afuser_sisyo.regdttm','000_tt_afuser_sisyo_006','登録日時',NULL,1,4,False,1,'1','1','tt_afuser_sisyo',NULL,NULL,NULL,'ユーザー所属部署（支所）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_afuser_sisyo.upduserid','000_tt_afuser_sisyo_007','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_afuser_sisyo',NULL,NULL,NULL,'ユーザー所属部署（支所）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_afuser_sisyo.upddttm','000_tt_afuser_sisyo_008','更新日時',NULL,1,4,False,1,'1','1','tt_afuser_sisyo',NULL,NULL,NULL,'ユーザー所属部署（支所）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_gyomu.atenano','000_tt_afjutogai_gyomu_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afjutogai_gyomu',NULL,NULL,NULL,'住登外者参照業務情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_gyomu.rirekino','000_tt_afjutogai_gyomu_002','履歴番号',NULL,1,1,True,1,'1','1','tt_afjutogai_gyomu',NULL,NULL,NULL,'住登外者参照業務情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--業務IDコード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_gyomu.gyomuid','000_tt_afjutogai_gyomu_003','業務IDコード',NULL,1,3,True,3,'1',NULL,'tt_afjutogai_gyomu',NULL,'121','3019,100010','住登外者参照業務情報テーブル','業務ID',NULL,'system','2023-01-01','system','2023-01-01');
--業務ID名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_gyomu_gyomuid_nm.nm','000_tt_afjutogai_gyomu_004','業務ID名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_gyomu_gyomuid_nm',NULL,NULL,NULL,'住登外者参照業務情報テーブル','業務ID',NULL,'system','2023-01-01','system','2023-01-01');
--業務IDCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_gyomu.gyomuid || '':'' || tt_afjutogai_gyomu_gyomuid_nm.nm','000_tt_afjutogai_gyomu_005','業務IDCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_gyomu','tt_afjutogai_gyomu_gyomuid_nm',NULL,NULL,'住登外者参照業務情報テーブル','業務ID',NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_dokujisystem.atenano','000_tt_afjutogai_dokujisystem_001','宛名番号',NULL,1,3,True,1,'1','1','tt_afjutogai_dokujisystem',NULL,NULL,NULL,'住登外者独自施策システム等情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--履歴番号
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_dokujisystem.rirekino','000_tt_afjutogai_dokujisystem_002','履歴番号',NULL,1,1,True,1,'1','1','tt_afjutogai_dokujisystem',NULL,NULL,NULL,'住登外者独自施策システム等情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--独自施策システム等IDコード
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_dokujisystem.dokujisystemid','000_tt_afjutogai_dokujisystem_003','独自施策システム等IDコード',NULL,1,3,True,3,'1',NULL,'tt_afjutogai_dokujisystem',NULL,'121','3019,100009','住登外者独自施策システム等情報テーブル','独自施策システム等ID',NULL,'system','2023-01-01','system','2023-01-01');
--独自施策システム等ID名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_dokujisystem_dokujisystemid_nm.nm','000_tt_afjutogai_dokujisystem_004','独自施策システム等ID名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_dokujisystem_dokujisystemid_nm',NULL,NULL,NULL,'住登外者独自施策システム等情報テーブル','独自施策システム等ID',NULL,'system','2023-01-01','system','2023-01-01');
--独自施策システム等IDCD:名称
INSERT INTO tm_eutableitem VALUES('tt_afjutogai_dokujisystem.dokujisystemid || '':'' || tt_afjutogai_dokujisystem_dokujisystemid_nm.nm','000_tt_afjutogai_dokujisystem_005','独自施策システム等IDCD:名称',NULL,0,2,False,1,'1',NULL,'tt_afjutogai_dokujisystem','tt_afjutogai_dokujisystem_dokujisystemid_nm',NULL,NULL,'住登外者独自施策システム等情報テーブル','独自施策システム等ID',NULL,'system','2023-01-01','system','2023-01-01');
--使用区分コード
INSERT INTO tm_eutableitem VALUES('tm_affile.siyokbn','000_tm_affile_001','使用区分コード',NULL,1,3,True,3,'1',NULL,'tm_affile',NULL,'111','1000,16','ファイルマスタ','使用区分',NULL,'system','2023-01-01','system','2023-01-01');
--使用区分名称
INSERT INTO tm_eutableitem VALUES('tm_affile_siyokbn_nm.nm','000_tm_affile_002','使用区分名称',NULL,0,2,False,1,'1',NULL,'tm_affile_siyokbn_nm',NULL,NULL,NULL,'ファイルマスタ','使用区分',NULL,'system','2023-01-01','system','2023-01-01');
--使用区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_affile.siyokbn || '':'' || tm_affile_siyokbn_nm.nm','000_tm_affile_003','使用区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_affile','tm_affile_siyokbn_nm',NULL,NULL,'ファイルマスタ','使用区分',NULL,'system','2023-01-01','system','2023-01-01');
--ファイル名
INSERT INTO tm_eutableitem VALUES('tm_affile.filenm','000_tm_affile_004','ファイル名',NULL,1,3,True,1,'1','1','tm_affile',NULL,NULL,NULL,'ファイルマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプコード
INSERT INTO tm_eutableitem VALUES('tm_affile.filetype','000_tm_affile_005','ファイルタイプコード',NULL,1,1,True,3,'1',NULL,'tm_affile',NULL,'111','1000,10','ファイルマスタ','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプ名称
INSERT INTO tm_eutableitem VALUES('tm_affile_filetype_nm.nm','000_tm_affile_006','ファイルタイプ名称',NULL,0,2,False,1,'1',NULL,'tm_affile_filetype_nm',NULL,NULL,NULL,'ファイルマスタ','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルタイプCD:名称
INSERT INTO tm_eutableitem VALUES('tm_affile.filetype || '':'' || tm_affile_filetype_nm.nm','000_tm_affile_007','ファイルタイプCD:名称',NULL,0,2,False,1,'1',NULL,'tm_affile','tm_affile_filetype_nm',NULL,NULL,'ファイルマスタ','ファイルタイプ',NULL,'system','2023-01-01','system','2023-01-01');
--ファイルデータ
INSERT INTO tm_eutableitem VALUES('tm_affile.filedata','000_tm_affile_008','ファイルデータ',NULL,1,7,True,1,'1','1','tm_affile',NULL,NULL,NULL,'ファイルマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.gyomukbn','010_tm_kkkijun_001','業務区分コード',NULL,1,3,True,3,'1',NULL,'tm_kkkijun',NULL,'111','1001,102','基準値マスタ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tm_kkkijun_gyomukbn_nm.nm','010_tm_kkkijun_002','業務区分名称',NULL,0,2,False,1,'1',NULL,'tm_kkkijun_gyomukbn_nm',NULL,NULL,NULL,'基準値マスタ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.gyomukbn || '':'' || tm_kkkijun_gyomukbn_nm.nm','010_tm_kkkijun_003','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_kkkijun','tm_kkkijun_gyomukbn_nm',NULL,NULL,'基準値マスタ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--基準値事業コード
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.kijunjigyocd','010_tm_kkkijun_004','基準値事業コード',NULL,1,3,True,3,'1',NULL,'tm_kkkijun',NULL,'121','3019,200001','基準値マスタ','基準値事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--基準値事業名称
INSERT INTO tm_eutableitem VALUES('tm_kkkijun_kijunjigyocd_nm.nm','010_tm_kkkijun_005','基準値事業名称',NULL,0,2,False,1,'1',NULL,'tm_kkkijun_kijunjigyocd_nm',NULL,NULL,NULL,'基準値マスタ','基準値事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--基準値事業CD:名称
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.kijunjigyocd || '':'' || tm_kkkijun_kijunjigyocd_nm.nm','010_tm_kkkijun_006','基準値事業CD:名称',NULL,0,2,False,1,'1',NULL,'tm_kkkijun','tm_kkkijun_kijunjigyocd_nm',NULL,NULL,'基準値マスタ','基準値事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--項目コード
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.itemcd','010_tm_kkkijun_007','項目コード',NULL,1,3,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.edano','010_tm_kkkijun_008','枝番',NULL,1,1,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--有効年月日（開始）
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.yukoymdf','010_tm_kkkijun_009','有効年月日（開始）',NULL,1,3,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--有効年月日（終了）
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.yukoymdt','010_tm_kkkijun_010','有効年月日（終了）',NULL,1,3,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--年齢（開始）
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.agef','010_tm_kkkijun_011','年齢（開始）',NULL,1,1,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--年齢（終了）
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.aget','010_tm_kkkijun_012','年齢（終了）',NULL,1,1,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--性別コード
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.sex','010_tm_kkkijun_013','性別コード',NULL,1,3,True,3,'1',NULL,'tm_kkkijun',NULL,'111','2001,1','基準値マスタ','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別名称
INSERT INTO tm_eutableitem VALUES('tm_kkkijun_sex_nm.nm','010_tm_kkkijun_014','性別名称',NULL,0,2,False,1,'1',NULL,'tm_kkkijun_sex_nm',NULL,NULL,NULL,'基準値マスタ','性別',NULL,'system','2023-01-01','system','2023-01-01');
--性別CD:名称
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.sex || '':'' || tm_kkkijun_sex_nm.nm','010_tm_kkkijun_015','性別CD:名称',NULL,0,2,False,1,'1',NULL,'tm_kkkijun','tm_kkkijun_sex_nm',NULL,NULL,'基準値マスタ','性別',NULL,'system','2023-01-01','system','2023-01-01');
--基準値表記
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.kijunvaluehyoki','010_tm_kkkijun_016','基準値表記',NULL,1,3,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--注意値表記
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.alertvaluehyoki','010_tm_kkkijun_017','注意値表記',NULL,1,3,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--異常値表記
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.errvaluehyoki','010_tm_kkkijun_018','異常値表記',NULL,1,3,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--異常値（数値）以下
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.errvalue1t','010_tm_kkkijun_019','異常値（数値）以下',NULL,1,2,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--注意値（数値）開始
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.alertvalue1f','010_tm_kkkijun_020','注意値（数値）開始',NULL,1,2,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--注意値（数値）終了
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.alertvalue1t','010_tm_kkkijun_021','注意値（数値）終了',NULL,1,2,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--基準値（数値）開始
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.kijunvaluef','010_tm_kkkijun_022','基準値（数値）開始',NULL,1,2,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--基準値（数値）終了
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.kijunvaluet','010_tm_kkkijun_023','基準値（数値）終了',NULL,1,2,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--注意値（数値）開始
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.alertvalue2f','010_tm_kkkijun_024','注意値（数値）開始',NULL,1,2,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--注意値（数値）終了
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.alertvalue2t','010_tm_kkkijun_025','注意値（数値）終了',NULL,1,2,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--異常値（数値）以上
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.errvalue2f','010_tm_kkkijun_026','異常値（数値）以上',NULL,1,2,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--基準値（コード）
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.hanteicd','010_tm_kkkijun_027','基準値（コード）',NULL,1,3,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--注意値（コード）
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.alerthanteicd','010_tm_kkkijun_028','注意値（コード）',NULL,1,3,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--異常値（コード）
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.errhanteicd','010_tm_kkkijun_029','異常値（コード）',NULL,1,3,True,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.reguserid','010_tm_kkkijun_030','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.regdttm','010_tm_kkkijun_031','登録日時',NULL,1,4,False,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.upduserid','010_tm_kkkijun_032','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_kkkijun.upddttm','010_tm_kkkijun_033','更新日時',NULL,1,4,False,1,'1','1','tm_kkkijun',NULL,NULL,NULL,'基準値マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--指導区分コード
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.sidokbn','010_tm_kksidofreeitem_001','指導区分コード',NULL,1,3,True,3,'1',NULL,'tm_kksidofreeitem',NULL,'111','1001,6','指導（フリー項目）コントロールマスタ','指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--指導区分名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem_sidokbn_nm.nm','010_tm_kksidofreeitem_002','指導区分名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem_sidokbn_nm',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ','指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--指導区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.sidokbn || '':'' || tm_kksidofreeitem_sidokbn_nm.nm','010_tm_kksidofreeitem_003','指導区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem','tm_kksidofreeitem_sidokbn_nm',NULL,NULL,'指導（フリー項目）コントロールマスタ','指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.gyomukbn','010_tm_kksidofreeitem_004','業務区分コード',NULL,1,3,True,3,'1',NULL,'tm_kksidofreeitem',NULL,'111','1001,101','指導（フリー項目）コントロールマスタ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem_gyomukbn_nm.nm','010_tm_kksidofreeitem_005','業務区分名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem_gyomukbn_nm',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.gyomukbn || '':'' || tm_kksidofreeitem_gyomukbn_nm.nm','010_tm_kksidofreeitem_006','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem','tm_kksidofreeitem_gyomukbn_nm',NULL,NULL,'指導（フリー項目）コントロールマスタ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分コード
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.mosikomikekkakbn','010_tm_kksidofreeitem_007','申込結果区分コード',NULL,1,3,True,3,'1',NULL,'tm_kksidofreeitem',NULL,'111','1001,5','指導（フリー項目）コントロールマスタ','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem_mosikomikekkakbn_nm.nm','010_tm_kksidofreeitem_008','申込結果区分名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem_mosikomikekkakbn_nm',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.mosikomikekkakbn || '':'' || tm_kksidofreeitem_mosikomikekkakbn_nm.nm','010_tm_kksidofreeitem_009','申込結果区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem','tm_kksidofreeitem_mosikomikekkakbn_nm',NULL,NULL,'指導（フリー項目）コントロールマスタ','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--項目用途区分コード
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.itemyotokbn','010_tm_kksidofreeitem_010','項目用途区分コード',NULL,1,3,True,3,'1',NULL,'tm_kksidofreeitem',NULL,'111','1001,7','指導（フリー項目）コントロールマスタ','項目用途区分',NULL,'system','2023-01-01','system','2023-01-01');
--項目用途区分名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem_itemyotokbn_nm.nm','010_tm_kksidofreeitem_011','項目用途区分名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem_itemyotokbn_nm',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ','項目用途区分',NULL,'system','2023-01-01','system','2023-01-01');
--項目用途区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.itemyotokbn || '':'' || tm_kksidofreeitem_itemyotokbn_nm.nm','010_tm_kksidofreeitem_012','項目用途区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem','tm_kksidofreeitem_itemyotokbn_nm',NULL,NULL,'指導（フリー項目）コントロールマスタ','項目用途区分',NULL,'system','2023-01-01','system','2023-01-01');
--項目コード
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.itemcd','010_tm_kksidofreeitem_013','項目コード',NULL,1,3,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目名
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.itemnm','010_tm_kksidofreeitem_014','項目名',NULL,1,3,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目区分コード
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.itemkbn','010_tm_kksidofreeitem_015','項目区分コード',NULL,1,3,True,3,'1',NULL,'tm_kksidofreeitem',NULL,'111','1000,49','指導（フリー項目）コントロールマスタ','項目区分',NULL,'system','2023-01-01','system','2023-01-01');
--項目区分名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem_itemkbn_nm.nm','010_tm_kksidofreeitem_016','項目区分名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem_itemkbn_nm',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ','項目区分',NULL,'system','2023-01-01','system','2023-01-01');
--項目区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.itemkbn || '':'' || tm_kksidofreeitem_itemkbn_nm.nm','010_tm_kksidofreeitem_017','項目区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem','tm_kksidofreeitem_itemkbn_nm',NULL,NULL,'指導（フリー項目）コントロールマスタ','項目区分',NULL,'system','2023-01-01','system','2023-01-01');
--グループIDコード
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.groupid','010_tm_kksidofreeitem_018','グループIDコード',NULL,1,3,True,3,'1',NULL,'tm_kksidofreeitem',NULL,'111','1001,2','指導（フリー項目）コントロールマスタ','グループID',NULL,'system','2023-01-01','system','2023-01-01');
--グループID名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem_groupid_nm.nm','010_tm_kksidofreeitem_019','グループID名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem_groupid_nm',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ','グループID',NULL,'system','2023-01-01','system','2023-01-01');
--グループIDCD:名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.groupid || '':'' || tm_kksidofreeitem_groupid_nm.nm','010_tm_kksidofreeitem_020','グループIDCD:名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem','tm_kksidofreeitem_groupid_nm',NULL,NULL,'指導（フリー項目）コントロールマスタ','グループID',NULL,'system','2023-01-01','system','2023-01-01');
--グループID2コード
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.groupid2','010_tm_kksidofreeitem_021','グループID2コード',NULL,1,3,True,3,'1',NULL,'tm_kksidofreeitem',NULL,'111','1001,3','指導（フリー項目）コントロールマスタ','グループID2',NULL,'system','2023-01-01','system','2023-01-01');
--グループID2名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem_groupid2_nm.nm','010_tm_kksidofreeitem_022','グループID2名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem_groupid2_nm',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ','グループID2',NULL,'system','2023-01-01','system','2023-01-01');
--グループID2CD:名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.groupid2 || '':'' || tm_kksidofreeitem_groupid2_nm.nm','010_tm_kksidofreeitem_023','グループID2CD:名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem','tm_kksidofreeitem_groupid2_nm',NULL,NULL,'指導（フリー項目）コントロールマスタ','グループID2',NULL,'system','2023-01-01','system','2023-01-01');
--入力タイプコード
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.inputtype','010_tm_kksidofreeitem_024','入力タイプコード',NULL,1,1,True,3,'1',NULL,'tm_kksidofreeitem',NULL,'111','1000,14','指導（フリー項目）コントロールマスタ','入力タイプ',NULL,'system','2023-01-01','system','2023-01-01');
--入力タイプ名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem_inputtype_nm.nm','010_tm_kksidofreeitem_025','入力タイプ名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem_inputtype_nm',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ','入力タイプ',NULL,'system','2023-01-01','system','2023-01-01');
--入力タイプCD:名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.inputtype || '':'' || tm_kksidofreeitem_inputtype_nm.nm','010_tm_kksidofreeitem_026','入力タイプCD:名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem','tm_kksidofreeitem_inputtype_nm',NULL,NULL,'指導（フリー項目）コントロールマスタ','入力タイプ',NULL,'system','2023-01-01','system','2023-01-01');
--コード条件1
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.codejoken1','010_tm_kksidofreeitem_027','コード条件1',NULL,1,3,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コード条件2
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.codejoken2','010_tm_kksidofreeitem_028','コード条件2',NULL,1,3,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コード条件3
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.codejoken3','010_tm_kksidofreeitem_029','コード条件3',NULL,1,3,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力桁
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.keta','010_tm_kksidofreeitem_030','入力桁',NULL,1,3,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--必須フラグ
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.hissuflg','010_tm_kksidofreeitem_031','必須フラグ',NULL,1,6,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力範囲（開始）
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.hanif','010_tm_kksidofreeitem_032','入力範囲（開始）',NULL,1,3,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力範囲（終了）
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.hanit','010_tm_kksidofreeitem_033','入力範囲（終了）',NULL,1,3,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--表示フラグ
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.hyojiflg','010_tm_kksidofreeitem_034','表示フラグ',NULL,1,6,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力フラグ
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.inputflg','010_tm_kksidofreeitem_035','入力フラグ',NULL,1,6,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ区分コード
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.msgkbn','010_tm_kksidofreeitem_036','メッセージ区分コード',NULL,1,1,True,3,'1',NULL,'tm_kksidofreeitem',NULL,'111','1000,9','指導（フリー項目）コントロールマスタ','メッセージ区分',NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ区分名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem_msgkbn_nm.nm','010_tm_kksidofreeitem_037','メッセージ区分名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem_msgkbn_nm',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ','メッセージ区分',NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.msgkbn || '':'' || tm_kksidofreeitem_msgkbn_nm.nm','010_tm_kksidofreeitem_038','メッセージ区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem','tm_kksidofreeitem_msgkbn_nm',NULL,NULL,'指導（フリー項目）コントロールマスタ','メッセージ区分',NULL,'system','2023-01-01','system','2023-01-01');
--単位
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.tani','010_tm_kksidofreeitem_039','単位',NULL,1,3,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--初期値
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.syokiti','010_tm_kksidofreeitem_040','初期値',NULL,1,3,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--並びシーケンス
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.orderseq','010_tm_kksidofreeitem_041','並びシーケンス',NULL,1,1,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--利用地域保健集計区分コード
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.syukeikbn','010_tm_kksidofreeitem_042','利用地域保健集計区分コード',NULL,1,3,True,3,'1',NULL,'tm_kksidofreeitem',NULL,'111','1001,34','指導（フリー項目）コントロールマスタ','利用地域保健集計区分',NULL,'system','2023-01-01','system','2023-01-01');
--利用地域保健集計区分名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem_syukeikbn_nm.nm','010_tm_kksidofreeitem_043','利用地域保健集計区分名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem_syukeikbn_nm',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ','利用地域保健集計区分',NULL,'system','2023-01-01','system','2023-01-01');
--利用地域保健集計区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.syukeikbn || '':'' || tm_kksidofreeitem_syukeikbn_nm.nm','010_tm_kksidofreeitem_044','利用地域保健集計区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_kksidofreeitem','tm_kksidofreeitem_syukeikbn_nm',NULL,NULL,'指導（フリー項目）コントロールマスタ','利用地域保健集計区分',NULL,'system','2023-01-01','system','2023-01-01');
--備考
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.biko','010_tm_kksidofreeitem_045','備考',NULL,1,3,True,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.reguserid','010_tm_kksidofreeitem_046','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.regdttm','010_tm_kksidofreeitem_047','登録日時',NULL,1,4,False,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.upduserid','010_tm_kksidofreeitem_048','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_kksidofreeitem.upddttm','010_tm_kksidofreeitem_049','更新日時',NULL,1,4,False,1,'1','1','tm_kksidofreeitem',NULL,NULL,NULL,'指導（フリー項目）コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--保健指導区分コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.hokensidokbn','010_tt_kkhokensidofree_001','保健指導区分コード',NULL,1,3,True,3,'1',NULL,'tt_kkhokensidofree',NULL,'111','1001,6','保健指導事業（フリー項目）入力情報テーブ','保健指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--保健指導区分名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree_hokensidokbn_nm.nm','010_tt_kkhokensidofree_002','保健指導区分名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensidofree_hokensidokbn_nm',NULL,NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ','保健指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--保健指導区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.hokensidokbn || '':'' || tt_kkhokensidofree_hokensidokbn_nm.nm','010_tt_kkhokensidofree_003','保健指導区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensidofree','tt_kkhokensidofree_hokensidokbn_nm',NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ','保健指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.gyomukbn','010_tt_kkhokensidofree_004','業務区分コード',NULL,1,3,True,3,'1',NULL,'tt_kkhokensidofree',NULL,'111','1001,101','保健指導事業（フリー項目）入力情報テーブ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree_gyomukbn_nm.nm','010_tt_kkhokensidofree_005','業務区分名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensidofree_gyomukbn_nm',NULL,NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.gyomukbn || '':'' || tt_kkhokensidofree_gyomukbn_nm.nm','010_tt_kkhokensidofree_006','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensidofree','tt_kkhokensidofree_gyomukbn_nm',NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.mosikomikekkakbn','010_tt_kkhokensidofree_007','申込結果区分コード',NULL,1,3,True,3,'1',NULL,'tt_kkhokensidofree',NULL,'111','1001,5','保健指導事業（フリー項目）入力情報テーブ','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree_mosikomikekkakbn_nm.nm','010_tt_kkhokensidofree_008','申込結果区分名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensidofree_mosikomikekkakbn_nm',NULL,NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.mosikomikekkakbn || '':'' || tt_kkhokensidofree_mosikomikekkakbn_nm.nm','010_tt_kkhokensidofree_009','申込結果区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensidofree','tt_kkhokensidofree_mosikomikekkakbn_nm',NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--項目コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.itemcd','010_tt_kkhokensidofree_010','項目コード',NULL,1,3,True,1,'1','1','tt_kkhokensidofree',NULL,NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.atenano','010_tt_kkhokensidofree_011','宛名番号',NULL,1,3,True,1,'1','1','tt_kkhokensidofree',NULL,NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.edano','010_tt_kkhokensidofree_012','枝番',NULL,1,1,True,1,'1','1','tt_kkhokensidofree',NULL,NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.fusyoflg','010_tt_kkhokensidofree_013','不詳フラグ',NULL,1,6,True,1,'1','1','tt_kkhokensidofree',NULL,NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--数値項目コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.numvalue','010_tt_kkhokensidofree_014','数値項目コード',NULL,1,2,True,3,'1',NULL,'tt_kkhokensidofree',NULL,'111','1000,14','保健指導事業（フリー項目）入力情報テーブ','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--数値項目名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree_numvalue_nm.nm','010_tt_kkhokensidofree_015','数値項目名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensidofree_numvalue_nm',NULL,NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--数値項目CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.numvalue || '':'' || tt_kkhokensidofree_numvalue_nm.nm','010_tt_kkhokensidofree_016','数値項目CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensidofree','tt_kkhokensidofree_numvalue_nm',NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.strvalue','010_tt_kkhokensidofree_017','文字項目コード',NULL,1,3,True,3,'1',NULL,'tt_kkhokensidofree',NULL,'111','1000,14','保健指導事業（フリー項目）入力情報テーブ','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree_strvalue_nm.nm','010_tt_kkhokensidofree_018','文字項目名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensidofree_strvalue_nm',NULL,NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensidofree.strvalue || '':'' || tt_kkhokensidofree_strvalue_nm.nm','010_tt_kkhokensidofree_019','文字項目CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensidofree','tt_kkhokensidofree_strvalue_nm',NULL,NULL,'保健指導事業（フリー項目）入力情報テーブ','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--保健指導区分コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.hokensidokbn','010_tt_kkhokensido_mosikomi_001','保健指導区分コード',NULL,1,3,True,3,'1',NULL,'tt_kkhokensido_mosikomi',NULL,'111','1001,6','保健指導申込情報（固定項目）テーブル','保健指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--保健指導区分名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi_hokensidokbn_nm.nm','010_tt_kkhokensido_mosikomi_002','保健指導区分名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_mosikomi_hokensidokbn_nm',NULL,NULL,NULL,'保健指導申込情報（固定項目）テーブル','保健指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--保健指導区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.hokensidokbn || '':'' || tt_kkhokensido_mosikomi_hokensidokbn_nm.nm','010_tt_kkhokensido_mosikomi_003','保健指導区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_mosikomi','tt_kkhokensido_mosikomi_hokensidokbn_nm',NULL,NULL,'保健指導申込情報（固定項目）テーブル','保健指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.gyomukbn','010_tt_kkhokensido_mosikomi_004','業務区分コード',NULL,1,3,True,3,'1',NULL,'tt_kkhokensido_mosikomi',NULL,'111','1001,101','保健指導申込情報（固定項目）テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi_gyomukbn_nm.nm','010_tt_kkhokensido_mosikomi_005','業務区分名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_mosikomi_gyomukbn_nm',NULL,NULL,NULL,'保健指導申込情報（固定項目）テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.gyomukbn || '':'' || tt_kkhokensido_mosikomi_gyomukbn_nm.nm','010_tt_kkhokensido_mosikomi_006','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_mosikomi','tt_kkhokensido_mosikomi_gyomukbn_nm',NULL,NULL,'保健指導申込情報（固定項目）テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.atenano','010_tt_kkhokensido_mosikomi_007','宛名番号',NULL,1,3,True,1,'1','1','tt_kkhokensido_mosikomi',NULL,NULL,NULL,'保健指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.edano','010_tt_kkhokensido_mosikomi_008','枝番',NULL,1,1,True,1,'1','1','tt_kkhokensido_mosikomi',NULL,NULL,NULL,'保健指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--その他日程事業・保健指導事業コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.jigyocd','010_tt_kkhokensido_mosikomi_009','その他日程事業・保健指導事業コード',NULL,1,3,True,1,'1','1','tt_kkhokensido_mosikomi',NULL,NULL,NULL,'保健指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--実施予定日
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.yoteiymd','010_tt_kkhokensido_mosikomi_010','実施予定日',NULL,1,3,True,1,'1','1','tt_kkhokensido_mosikomi',NULL,NULL,NULL,'保健指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--予定開始時間
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.yoteitm','010_tt_kkhokensido_mosikomi_011','予定開始時間',NULL,1,3,True,1,'1','1','tt_kkhokensido_mosikomi',NULL,NULL,NULL,'保健指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--会場コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.kaijocd','010_tt_kkhokensido_mosikomi_012','会場コード',NULL,1,3,True,1,'1','1','tt_kkhokensido_mosikomi',NULL,NULL,NULL,'保健指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録支所
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.regsisyo','010_tt_kkhokensido_mosikomi_013','登録支所',NULL,1,3,True,1,'1','1','tt_kkhokensido_mosikomi',NULL,NULL,NULL,'保健指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.reguserid','010_tt_kkhokensido_mosikomi_014','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_kkhokensido_mosikomi',NULL,NULL,NULL,'保健指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.regdttm','010_tt_kkhokensido_mosikomi_015','登録日時',NULL,1,4,False,1,'1','1','tt_kkhokensido_mosikomi',NULL,NULL,NULL,'保健指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.upduserid','010_tt_kkhokensido_mosikomi_016','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_kkhokensido_mosikomi',NULL,NULL,NULL,'保健指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_mosikomi.upddttm','010_tt_kkhokensido_mosikomi_017','更新日時',NULL,1,4,False,1,'1','1','tt_kkhokensido_mosikomi',NULL,NULL,NULL,'保健指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--保健指導区分コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.hokensidokbn','010_tt_kkhokensido_kekka_001','保健指導区分コード',NULL,1,3,True,3,'1',NULL,'tt_kkhokensido_kekka',NULL,'111','1001,6','保健指導結果情報（固定項目）テーブル','保健指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--保健指導区分名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka_hokensidokbn_nm.nm','010_tt_kkhokensido_kekka_002','保健指導区分名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_kekka_hokensidokbn_nm',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル','保健指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--保健指導区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.hokensidokbn || '':'' || tt_kkhokensido_kekka_hokensidokbn_nm.nm','010_tt_kkhokensido_kekka_003','保健指導区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_kekka','tt_kkhokensido_kekka_hokensidokbn_nm',NULL,NULL,'保健指導結果情報（固定項目）テーブル','保健指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.gyomukbn','010_tt_kkhokensido_kekka_004','業務区分コード',NULL,1,3,True,3,'1',NULL,'tt_kkhokensido_kekka',NULL,'111','1001,101','保健指導結果情報（固定項目）テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka_gyomukbn_nm.nm','010_tt_kkhokensido_kekka_005','業務区分名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_kekka_gyomukbn_nm',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.gyomukbn || '':'' || tt_kkhokensido_kekka_gyomukbn_nm.nm','010_tt_kkhokensido_kekka_006','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_kekka','tt_kkhokensido_kekka_gyomukbn_nm',NULL,NULL,'保健指導結果情報（固定項目）テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.atenano','010_tt_kkhokensido_kekka_007','宛名番号',NULL,1,3,True,1,'1','1','tt_kkhokensido_kekka',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.edano','010_tt_kkhokensido_kekka_008','枝番',NULL,1,1,True,1,'1','1','tt_kkhokensido_kekka',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--その他日程事業・保健指導事業コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.jigyocd','010_tt_kkhokensido_kekka_009','その他日程事業・保健指導事業コード',NULL,1,3,True,1,'1','1','tt_kkhokensido_kekka',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--実施日
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.jissiymd','010_tt_kkhokensido_kekka_010','実施日',NULL,1,3,True,1,'1','1','tt_kkhokensido_kekka',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--開始時間
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.tmf','010_tt_kkhokensido_kekka_011','開始時間',NULL,1,3,True,1,'1','1','tt_kkhokensido_kekka',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--終了時間
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.tmt','010_tt_kkhokensido_kekka_012','終了時間',NULL,1,3,True,1,'1','1','tt_kkhokensido_kekka',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--会場コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.kaijocd','010_tt_kkhokensido_kekka_013','会場コード',NULL,1,3,True,1,'1','1','tt_kkhokensido_kekka',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--地域保健集計区分コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.syukeikbn','010_tt_kkhokensido_kekka_014','地域保健集計区分コード',NULL,1,3,True,3,'1',NULL,'tt_kkhokensido_kekka',NULL,'111','1001,34','保健指導結果情報（固定項目）テーブル','地域保健集計区分',NULL,'system','2023-01-01','system','2023-01-01');
--地域保健集計区分名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka_syukeikbn_nm.nm','010_tt_kkhokensido_kekka_015','地域保健集計区分名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_kekka_syukeikbn_nm',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル','地域保健集計区分',NULL,'system','2023-01-01','system','2023-01-01');
--地域保健集計区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.syukeikbn || '':'' || tt_kkhokensido_kekka_syukeikbn_nm.nm','010_tt_kkhokensido_kekka_016','地域保健集計区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_kekka','tt_kkhokensido_kekka_syukeikbn_nm',NULL,NULL,'保健指導結果情報（固定項目）テーブル','地域保健集計区分',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.regsisyo','010_tt_kkhokensido_kekka_017','登録支所',NULL,1,3,True,1,'1','1','tt_kkhokensido_kekka',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.reguserid','010_tt_kkhokensido_kekka_018','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_kkhokensido_kekka',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.regdttm','010_tt_kkhokensido_kekka_019','登録日時',NULL,1,4,False,1,'1','1','tt_kkhokensido_kekka',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.upduserid','010_tt_kkhokensido_kekka_020','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_kkhokensido_kekka',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_kekka.upddttm','010_tt_kkhokensido_kekka_021','更新日時',NULL,1,4,False,1,'1','1','tt_kkhokensido_kekka',NULL,NULL,NULL,'保健指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--保健指導区分コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_staff.hokensidokbn','010_tt_kkhokensido_staff_001','保健指導区分コード',NULL,1,3,True,3,'1',NULL,'tt_kkhokensido_staff',NULL,'111','1001,6','保健指導担当者テーブル','保健指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--保健指導区分名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_staff_hokensidokbn_nm.nm','010_tt_kkhokensido_staff_002','保健指導区分名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_staff_hokensidokbn_nm',NULL,NULL,NULL,'保健指導担当者テーブル','保健指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--保健指導区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_staff.hokensidokbn || '':'' || tt_kkhokensido_staff_hokensidokbn_nm.nm','010_tt_kkhokensido_staff_003','保健指導区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_staff','tt_kkhokensido_staff_hokensidokbn_nm',NULL,NULL,'保健指導担当者テーブル','保健指導区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_staff.gyomukbn','010_tt_kkhokensido_staff_004','業務区分コード',NULL,1,3,True,3,'1',NULL,'tt_kkhokensido_staff',NULL,'111','1001,101','保健指導担当者テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_staff_gyomukbn_nm.nm','010_tt_kkhokensido_staff_005','業務区分名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_staff_gyomukbn_nm',NULL,NULL,NULL,'保健指導担当者テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_staff.gyomukbn || '':'' || tt_kkhokensido_staff_gyomukbn_nm.nm','010_tt_kkhokensido_staff_006','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_staff','tt_kkhokensido_staff_gyomukbn_nm',NULL,NULL,'保健指導担当者テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_staff.atenano','010_tt_kkhokensido_staff_007','宛名番号',NULL,1,3,True,1,'1','1','tt_kkhokensido_staff',NULL,NULL,NULL,'保健指導担当者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_staff.edano','010_tt_kkhokensido_staff_008','枝番',NULL,1,1,True,1,'1','1','tt_kkhokensido_staff',NULL,NULL,NULL,'保健指導担当者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分コード
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_staff.mosikomikekkakbn','010_tt_kkhokensido_staff_009','申込結果区分コード',NULL,1,3,True,3,'1',NULL,'tt_kkhokensido_staff',NULL,'111','1001,5','保健指導担当者テーブル','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_staff_mosikomikekkakbn_nm.nm','010_tt_kkhokensido_staff_010','申込結果区分名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_staff_mosikomikekkakbn_nm',NULL,NULL,NULL,'保健指導担当者テーブル','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_staff.mosikomikekkakbn || '':'' || tt_kkhokensido_staff_mosikomikekkakbn_nm.nm','010_tt_kkhokensido_staff_011','申込結果区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkhokensido_staff','tt_kkhokensido_staff_mosikomikekkakbn_nm',NULL,NULL,'保健指導担当者テーブル','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--担当者
INSERT INTO tm_eutableitem VALUES('tt_kkhokensido_staff.staffid','010_tt_kkhokensido_staff_012','担当者',NULL,1,3,True,1,'1','1','tt_kkhokensido_staff',NULL,NULL,NULL,'保健指導担当者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--事業報告書番号
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.hokokusyono','010_tt_kkjissihokokusyo_001','事業報告書番号',NULL,1,1,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--事業実施報告書（日報）事業コード
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.jigyocd','010_tt_kkjissihokokusyo_002','事業実施報告書（日報）事業コード',NULL,1,3,True,3,'1',NULL,'tt_kkjissihokokusyo',NULL,'tm_afhanyo','3019,100004','実施報告書（日報）情報テーブル','事業実施報告書（日報）事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--事業実施報告書（日報）事業名称
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo_jigyocd_nm.nm','010_tt_kkjissihokokusyo_003','事業実施報告書（日報）事業名称',NULL,0,2,False,1,'1',NULL,'tt_kkjissihokokusyo_jigyocd_nm',NULL,NULL,NULL,'実施報告書（日報）情報テーブル','事業実施報告書（日報）事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--事業実施報告書（日報）事業CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.jigyocd || '':'' || tt_kkjissihokokusyo_jigyocd_nm.nm','010_tt_kkjissihokokusyo_004','事業実施報告書（日報）事業CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkjissihokokusyo','tt_kkjissihokokusyo_jigyocd_nm',NULL,NULL,'実施報告書（日報）情報テーブル','事業実施報告書（日報）事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--実施日
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.jissiymd','010_tt_kkjissihokokusyo_005','実施日',NULL,1,3,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--会場コード
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.kaijocd','010_tt_kkjissihokokusyo_006','会場コード',NULL,1,3,True,1,'1','1','tt_kkjissihokokusyo',NULL,'tm_afkaijo',NULL,'実施報告書（日報）情報テーブル','会場コード',NULL,'system','2023-01-01','system','2023-01-01');
--会場名称
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo_kaijocd_kaijonm.kaijonm','010_tt_kkjissihokokusyo_007','会場名称',NULL,0,2,False,1,'1',NULL,'tt_kkjissihokokusyo_kaijocd_kaijonm',NULL,NULL,NULL,'実施報告書（日報）情報テーブル','会場コード',NULL,'system','2023-01-01','system','2023-01-01');
--会場CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.kaijocd || '':'' || tt_kkjissihokokusyo_kaijocd_kaijonm.kaijonm','010_tt_kkjissihokokusyo_008','会場CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkjissihokokusyo','tt_kkjissihokokusyo_kaijocd_kaijonm',NULL,NULL,'実施報告書（日報）情報テーブル','会場コード',NULL,'system','2023-01-01','system','2023-01-01');
--開始時間
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.timef','010_tt_kkjissihokokusyo_009','開始時間',NULL,1,3,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--終了時間
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.timet','010_tt_kkjissihokokusyo_010','終了時間',NULL,1,3,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--出席者数
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.syussekisya','010_tt_kkjissihokokusyo_011','出席者数',NULL,1,1,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--実施内容
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.jissinaiyo','010_tt_kkjissihokokusyo_012','実施内容',NULL,1,3,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--配布資料
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.haifusiryo','010_tt_kkjissihokokusyo_013','配布資料',NULL,1,3,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--媒体
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.baitai','010_tt_kkjissihokokusyo_014','媒体',NULL,1,3,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--男性延べ人数
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.mantotalnum','010_tt_kkjissihokokusyo_015','男性延べ人数',NULL,1,1,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--女性延べ人数
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.womantotalnum','010_tt_kkjissihokokusyo_016','女性延べ人数',NULL,1,1,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--性別不明延べ人数
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.fumeitotalnum','010_tt_kkjissihokokusyo_017','性別不明延べ人数',NULL,1,1,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--男性実人数
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.mannum','010_tt_kkjissihokokusyo_018','男性実人数',NULL,1,1,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--女性実人数
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.womannum','010_tt_kkjissihokokusyo_019','女性実人数',NULL,1,1,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--性別不明実人数
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.fumeinum','010_tt_kkjissihokokusyo_020','性別不明実人数',NULL,1,1,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コメント
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.comment','010_tt_kkjissihokokusyo_021','コメント',NULL,1,3,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--反省点
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.hanseipoint','010_tt_kkjissihokokusyo_022','反省点',NULL,1,3,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--事業目的
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.jigyomokuteki','010_tt_kkjissihokokusyo_023','事業目的',NULL,1,3,True,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録支所コード
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.regsisyo','010_tt_kkjissihokokusyo_024','登録支所コード',NULL,1,3,True,3,'1',NULL,'tt_kkjissihokokusyo',NULL,'121','3019,1','実施報告書（日報）情報テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所名称
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo_regsisyo_nm.nm','010_tt_kkjissihokokusyo_025','登録支所名称',NULL,0,2,False,1,'1',NULL,'tt_kkjissihokokusyo_regsisyo_nm',NULL,NULL,NULL,'実施報告書（日報）情報テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.regsisyo || '':'' || tt_kkjissihokokusyo_regsisyo_nm.nm','010_tt_kkjissihokokusyo_026','登録支所CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkjissihokokusyo','tt_kkjissihokokusyo_regsisyo_nm',NULL,NULL,'実施報告書（日報）情報テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.reguserid','010_tt_kkjissihokokusyo_027','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.regdttm','010_tt_kkjissihokokusyo_028','登録日時',NULL,1,4,False,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.upduserid','010_tt_kkjissihokokusyo_029','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo.upddttm','010_tt_kkjissihokokusyo_030','更新日時',NULL,1,4,False,1,'1','1','tt_kkjissihokokusyo',NULL,NULL,NULL,'実施報告書（日報）情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--事業報告書番号
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo_sub.hokokusyono','010_tt_kkjissihokokusyo_sub_001','事業報告書番号',NULL,1,1,True,1,'1','1','tt_kkjissihokokusyo_sub',NULL,NULL,NULL,'実施報告書（日報）情報サブテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--事業従事者ID
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo_sub.staffid','010_tt_kkjissihokokusyo_sub_002','事業従事者ID',NULL,1,3,True,1,'1','1','tt_kkjissihokokusyo_sub',NULL,NULL,NULL,'実施報告書（日報）情報サブテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo_sub.reguserid','010_tt_kkjissihokokusyo_sub_003','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_kkjissihokokusyo_sub',NULL,NULL,NULL,'実施報告書（日報）情報サブテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo_sub.regdttm','010_tt_kkjissihokokusyo_sub_004','登録日時',NULL,1,4,False,1,'1','1','tt_kkjissihokokusyo_sub',NULL,NULL,NULL,'実施報告書（日報）情報サブテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo_sub.upduserid','010_tt_kkjissihokokusyo_sub_005','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_kkjissihokokusyo_sub',NULL,NULL,NULL,'実施報告書（日報）情報サブテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_kkjissihokokusyo_sub.upddttm','010_tt_kkjissihokokusyo_sub_006','更新日時',NULL,1,4,False,1,'1','1','tt_kkjissihokokusyo_sub',NULL,NULL,NULL,'実施報告書（日報）情報サブテーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree.gyomukbn','010_tt_kksyudansidofree_001','業務区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansidofree',NULL,'111','1001,101','集団指導事業（フリー項目）入力情報テーブ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree_gyomukbn_nm.nm','010_tt_kksyudansidofree_002','業務区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansidofree_gyomukbn_nm',NULL,NULL,NULL,'集団指導事業（フリー項目）入力情報テーブ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree.gyomukbn || '':'' || tt_kksyudansidofree_gyomukbn_nm.nm','010_tt_kksyudansidofree_003','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansidofree','tt_kksyudansidofree_gyomukbn_nm',NULL,NULL,'集団指導事業（フリー項目）入力情報テーブ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree.edano','010_tt_kksyudansidofree_004','枝番',NULL,1,1,True,1,'1','1','tt_kksyudansidofree',NULL,NULL,NULL,'集団指導事業（フリー項目）入力情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree.mosikomikekkakbn','010_tt_kksyudansidofree_005','申込結果区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansidofree',NULL,'111','1001,5','集団指導事業（フリー項目）入力情報テーブ','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree_mosikomikekkakbn_nm.nm','010_tt_kksyudansidofree_006','申込結果区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansidofree_mosikomikekkakbn_nm',NULL,NULL,NULL,'集団指導事業（フリー項目）入力情報テーブ','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree.mosikomikekkakbn || '':'' || tt_kksyudansidofree_mosikomikekkakbn_nm.nm','010_tt_kksyudansidofree_007','申込結果区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansidofree','tt_kksyudansidofree_mosikomikekkakbn_nm',NULL,NULL,'集団指導事業（フリー項目）入力情報テーブ','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--項目コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree.itemcd','010_tt_kksyudansidofree_008','項目コード',NULL,1,3,True,1,'1','1','tt_kksyudansidofree',NULL,NULL,NULL,'集団指導事業（フリー項目）入力情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree.fusyoflg','010_tt_kksyudansidofree_009','不詳フラグ',NULL,1,6,True,1,'1','1','tt_kksyudansidofree',NULL,NULL,NULL,'集団指導事業（フリー項目）入力情報テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--数値項目コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree.numvalue','010_tt_kksyudansidofree_010','数値項目コード',NULL,1,2,True,3,'1',NULL,'tt_kksyudansidofree',NULL,'111','1000,14','集団指導事業（フリー項目）入力情報テーブ','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--数値項目名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree_numvalue_nm.nm','010_tt_kksyudansidofree_011','数値項目名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansidofree_numvalue_nm',NULL,NULL,NULL,'集団指導事業（フリー項目）入力情報テーブ','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--数値項目CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree.numvalue || '':'' || tt_kksyudansidofree_numvalue_nm.nm','010_tt_kksyudansidofree_012','数値項目CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansidofree','tt_kksyudansidofree_numvalue_nm',NULL,NULL,'集団指導事業（フリー項目）入力情報テーブ','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree.strvalue','010_tt_kksyudansidofree_013','文字項目コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansidofree',NULL,'111','1000,14','集団指導事業（フリー項目）入力情報テーブ','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree_strvalue_nm.nm','010_tt_kksyudansidofree_014','文字項目名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansidofree_strvalue_nm',NULL,NULL,NULL,'集団指導事業（フリー項目）入力情報テーブ','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansidofree.strvalue || '':'' || tt_kksyudansidofree_strvalue_nm.nm','010_tt_kksyudansidofree_015','文字項目CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansidofree','tt_kksyudansidofree_strvalue_nm',NULL,NULL,'集団指導事業（フリー項目）入力情報テーブ','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.gyomukbn','010_tt_kksyudansido_mosikomi_001','業務区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansido_mosikomi',NULL,'111','1001,101','集団指導申込情報（固定項目）テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi_gyomukbn_nm.nm','010_tt_kksyudansido_mosikomi_002','業務区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_mosikomi_gyomukbn_nm',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.gyomukbn || '':'' || tt_kksyudansido_mosikomi_gyomukbn_nm.nm','010_tt_kksyudansido_mosikomi_003','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_mosikomi','tt_kksyudansido_mosikomi_gyomukbn_nm',NULL,NULL,'集団指導申込情報（固定項目）テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.edano','010_tt_kksyudansido_mosikomi_004','枝番',NULL,1,1,True,1,'1','1','tt_kksyudansido_mosikomi',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--その他日程事業・保健指導事業コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.jigyocd','010_tt_kksyudansido_mosikomi_005','その他日程事業・保健指導事業コード',NULL,1,3,True,1,'1','1','tt_kksyudansido_mosikomi',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--実施予定日
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.yoteiymd','010_tt_kksyudansido_mosikomi_006','実施予定日',NULL,1,3,True,1,'1','1','tt_kksyudansido_mosikomi',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--予定開始時間
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.yoteitm','010_tt_kksyudansido_mosikomi_007','予定開始時間',NULL,1,3,True,1,'1','1','tt_kksyudansido_mosikomi',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--会場コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.kaijocd','010_tt_kksyudansido_mosikomi_008','会場コード',NULL,1,3,True,1,'1','1','tt_kksyudansido_mosikomi',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--日程番号
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.nitteno','010_tt_kksyudansido_mosikomi_009','日程番号',NULL,1,1,True,1,'1','1','tt_kksyudansido_mosikomi',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--日程詳細番号
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.nittesyosaino','010_tt_kksyudansido_mosikomi_010','日程詳細番号',NULL,1,1,True,1,'1','1','tt_kksyudansido_mosikomi',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コース名
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.coursenm','010_tt_kksyudansido_mosikomi_011','コース名',NULL,1,3,True,1,'1','1','tt_kksyudansido_mosikomi',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録支所
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.regsisyo','010_tt_kksyudansido_mosikomi_012','登録支所',NULL,1,3,True,1,'1','1','tt_kksyudansido_mosikomi',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.reguserid','010_tt_kksyudansido_mosikomi_013','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_kksyudansido_mosikomi',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.regdttm','010_tt_kksyudansido_mosikomi_014','登録日時',NULL,1,4,False,1,'1','1','tt_kksyudansido_mosikomi',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.upduserid','010_tt_kksyudansido_mosikomi_015','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_kksyudansido_mosikomi',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_mosikomi.upddttm','010_tt_kksyudansido_mosikomi_016','更新日時',NULL,1,4,False,1,'1','1','tt_kksyudansido_mosikomi',NULL,NULL,NULL,'集団指導申込情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.gyomukbn','010_tt_kksyudansido_kekka_001','業務区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansido_kekka',NULL,'111','1001,101','集団指導結果情報（固定項目）テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka_gyomukbn_nm.nm','010_tt_kksyudansido_kekka_002','業務区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_kekka_gyomukbn_nm',NULL,NULL,NULL,'集団指導結果情報（固定項目）テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.gyomukbn || '':'' || tt_kksyudansido_kekka_gyomukbn_nm.nm','010_tt_kksyudansido_kekka_003','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_kekka','tt_kksyudansido_kekka_gyomukbn_nm',NULL,NULL,'集団指導結果情報（固定項目）テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.edano','010_tt_kksyudansido_kekka_004','枝番',NULL,1,1,True,1,'1','1','tt_kksyudansido_kekka',NULL,NULL,NULL,'集団指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--その他日程事業・保健指導事業コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.jigyocd','010_tt_kksyudansido_kekka_005','その他日程事業・保健指導事業コード',NULL,1,3,True,1,'1','1','tt_kksyudansido_kekka',NULL,NULL,NULL,'集団指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--実施日
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.jissiymd','010_tt_kksyudansido_kekka_006','実施日',NULL,1,3,True,1,'1','1','tt_kksyudansido_kekka',NULL,NULL,NULL,'集団指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--開始時間
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.tmf','010_tt_kksyudansido_kekka_007','開始時間',NULL,1,3,True,1,'1','1','tt_kksyudansido_kekka',NULL,NULL,NULL,'集団指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--終了時間
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.tmt','010_tt_kksyudansido_kekka_008','終了時間',NULL,1,3,True,1,'1','1','tt_kksyudansido_kekka',NULL,NULL,NULL,'集団指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--会場コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.kaijocd','010_tt_kksyudansido_kekka_009','会場コード',NULL,1,3,True,1,'1','1','tt_kksyudansido_kekka',NULL,NULL,NULL,'集団指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--地域保健集計区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.syukeikbn','010_tt_kksyudansido_kekka_010','地域保健集計区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansido_kekka',NULL,'111','1001,34','集団指導結果情報（固定項目）テーブル','地域保健集計区分',NULL,'system','2023-01-01','system','2023-01-01');
--地域保健集計区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka_syukeikbn_nm.nm','010_tt_kksyudansido_kekka_011','地域保健集計区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_kekka_syukeikbn_nm',NULL,NULL,NULL,'集団指導結果情報（固定項目）テーブル','地域保健集計区分',NULL,'system','2023-01-01','system','2023-01-01');
--地域保健集計区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.syukeikbn || '':'' || tt_kksyudansido_kekka_syukeikbn_nm.nm','010_tt_kksyudansido_kekka_012','地域保健集計区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_kekka','tt_kksyudansido_kekka_syukeikbn_nm',NULL,NULL,'集団指導結果情報（固定項目）テーブル','地域保健集計区分',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.regsisyo','010_tt_kksyudansido_kekka_013','登録支所',NULL,1,3,True,1,'1','1','tt_kksyudansido_kekka',NULL,NULL,NULL,'集団指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.reguserid','010_tt_kksyudansido_kekka_014','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_kksyudansido_kekka',NULL,NULL,NULL,'集団指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.regdttm','010_tt_kksyudansido_kekka_015','登録日時',NULL,1,4,False,1,'1','1','tt_kksyudansido_kekka',NULL,NULL,NULL,'集団指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.upduserid','010_tt_kksyudansido_kekka_016','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_kksyudansido_kekka',NULL,NULL,NULL,'集団指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_kekka.upddttm','010_tt_kksyudansido_kekka_017','更新日時',NULL,1,4,False,1,'1','1','tt_kksyudansido_kekka',NULL,NULL,NULL,'集団指導結果情報（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree.gyomukbn','010_tt_kksyudansido_sankasyafree_001','業務区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansido_sankasyafree',NULL,'111','1001,101','集団指導参加者（フリー項目）入力情報テー','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree_gyomukbn_nm.nm','010_tt_kksyudansido_sankasyafree_002','業務区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyafree_gyomukbn_nm',NULL,NULL,NULL,'集団指導参加者（フリー項目）入力情報テー','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree.gyomukbn || '':'' || tt_kksyudansido_sankasyafree_gyomukbn_nm.nm','010_tt_kksyudansido_sankasyafree_003','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyafree','tt_kksyudansido_sankasyafree_gyomukbn_nm',NULL,NULL,'集団指導参加者（フリー項目）入力情報テー','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree.edano','010_tt_kksyudansido_sankasyafree_004','枝番',NULL,1,1,True,1,'1','1','tt_kksyudansido_sankasyafree',NULL,NULL,NULL,'集団指導参加者（フリー項目）入力情報テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree.mosikomikekkakbn','010_tt_kksyudansido_sankasyafree_005','申込結果区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansido_sankasyafree',NULL,'111','1001,5','集団指導参加者（フリー項目）入力情報テー','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree_mosikomikekkakbn_nm.nm','010_tt_kksyudansido_sankasyafree_006','申込結果区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyafree_mosikomikekkakbn_nm',NULL,NULL,NULL,'集団指導参加者（フリー項目）入力情報テー','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree.mosikomikekkakbn || '':'' || tt_kksyudansido_sankasyafree_mosikomikekkakbn_nm.nm','010_tt_kksyudansido_sankasyafree_007','申込結果区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyafree','tt_kksyudansido_sankasyafree_mosikomikekkakbn_nm',NULL,NULL,'集団指導参加者（フリー項目）入力情報テー','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--項目コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree.itemcd','010_tt_kksyudansido_sankasyafree_008','項目コード',NULL,1,3,True,1,'1','1','tt_kksyudansido_sankasyafree',NULL,NULL,NULL,'集団指導参加者（フリー項目）入力情報テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree.atenano','010_tt_kksyudansido_sankasyafree_009','宛名番号',NULL,1,3,True,1,'1','1','tt_kksyudansido_sankasyafree',NULL,NULL,NULL,'集団指導参加者（フリー項目）入力情報テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree.fusyoflg','010_tt_kksyudansido_sankasyafree_010','不詳フラグ',NULL,1,6,True,1,'1','1','tt_kksyudansido_sankasyafree',NULL,NULL,NULL,'集団指導参加者（フリー項目）入力情報テー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--数値項目コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree.numvalue','010_tt_kksyudansido_sankasyafree_011','数値項目コード',NULL,1,2,True,3,'1',NULL,'tt_kksyudansido_sankasyafree',NULL,'111','1000,14','集団指導参加者（フリー項目）入力情報テー','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--数値項目名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree_numvalue_nm.nm','010_tt_kksyudansido_sankasyafree_012','数値項目名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyafree_numvalue_nm',NULL,NULL,NULL,'集団指導参加者（フリー項目）入力情報テー','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--数値項目CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree.numvalue || '':'' || tt_kksyudansido_sankasyafree_numvalue_nm.nm','010_tt_kksyudansido_sankasyafree_013','数値項目CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyafree','tt_kksyudansido_sankasyafree_numvalue_nm',NULL,NULL,'集団指導参加者（フリー項目）入力情報テー','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree.strvalue','010_tt_kksyudansido_sankasyafree_014','文字項目コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansido_sankasyafree',NULL,'111','1000,14','集団指導参加者（フリー項目）入力情報テー','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree_strvalue_nm.nm','010_tt_kksyudansido_sankasyafree_015','文字項目名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyafree_strvalue_nm',NULL,NULL,NULL,'集団指導参加者（フリー項目）入力情報テー','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyafree.strvalue || '':'' || tt_kksyudansido_sankasyafree_strvalue_nm.nm','010_tt_kksyudansido_sankasyafree_016','文字項目CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyafree','tt_kksyudansido_sankasyafree_strvalue_nm',NULL,NULL,'集団指導参加者（フリー項目）入力情報テー','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyamosikomi.gyomukbn','010_tt_kksyudansido_sankasyamosikomi_001','業務区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansido_sankasyamosikomi',NULL,'111','1001,101','集団指導参加者申込情報（固定項目）テーブ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyamosikomi_gyomukbn_nm.nm','010_tt_kksyudansido_sankasyamosikomi_002','業務区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyamosikomi_gyomukbn_nm',NULL,NULL,NULL,'集団指導参加者申込情報（固定項目）テーブ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyamosikomi.gyomukbn || '':'' || tt_kksyudansido_sankasyamosikomi_gyomukbn_nm.nm','010_tt_kksyudansido_sankasyamosikomi_003','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyamosikomi','tt_kksyudansido_sankasyamosikomi_gyomukbn_nm',NULL,NULL,'集団指導参加者申込情報（固定項目）テーブ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyamosikomi.edano','010_tt_kksyudansido_sankasyamosikomi_004','枝番',NULL,1,1,True,1,'1','1','tt_kksyudansido_sankasyamosikomi',NULL,NULL,NULL,'集団指導参加者申込情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyamosikomi.atenano','010_tt_kksyudansido_sankasyamosikomi_005','宛名番号',NULL,1,3,True,1,'1','1','tt_kksyudansido_sankasyamosikomi',NULL,NULL,NULL,'集団指導参加者申込情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録支所
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyamosikomi.regsisyo','010_tt_kksyudansido_sankasyamosikomi_006','登録支所',NULL,1,3,True,1,'1','1','tt_kksyudansido_sankasyamosikomi',NULL,NULL,NULL,'集団指導参加者申込情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyamosikomi.reguserid','010_tt_kksyudansido_sankasyamosikomi_007','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_kksyudansido_sankasyamosikomi',NULL,NULL,NULL,'集団指導参加者申込情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyamosikomi.regdttm','010_tt_kksyudansido_sankasyamosikomi_008','登録日時',NULL,1,4,False,1,'1','1','tt_kksyudansido_sankasyamosikomi',NULL,NULL,NULL,'集団指導参加者申込情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyamosikomi.upduserid','010_tt_kksyudansido_sankasyamosikomi_009','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_kksyudansido_sankasyamosikomi',NULL,NULL,NULL,'集団指導参加者申込情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyamosikomi.upddttm','010_tt_kksyudansido_sankasyamosikomi_010','更新日時',NULL,1,4,False,1,'1','1','tt_kksyudansido_sankasyamosikomi',NULL,NULL,NULL,'集団指導参加者申込情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyakekka.gyomukbn','010_tt_kksyudansido_sankasyakekka_001','業務区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansido_sankasyakekka',NULL,'111','1001,101','集団指導参加者結果情報（固定項目）テーブ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyakekka_gyomukbn_nm.nm','010_tt_kksyudansido_sankasyakekka_002','業務区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyakekka_gyomukbn_nm',NULL,NULL,NULL,'集団指導参加者結果情報（固定項目）テーブ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyakekka.gyomukbn || '':'' || tt_kksyudansido_sankasyakekka_gyomukbn_nm.nm','010_tt_kksyudansido_sankasyakekka_003','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyakekka','tt_kksyudansido_sankasyakekka_gyomukbn_nm',NULL,NULL,'集団指導参加者結果情報（固定項目）テーブ','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyakekka.edano','010_tt_kksyudansido_sankasyakekka_004','枝番',NULL,1,1,True,1,'1','1','tt_kksyudansido_sankasyakekka',NULL,NULL,NULL,'集団指導参加者結果情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyakekka.atenano','010_tt_kksyudansido_sankasyakekka_005','宛名番号',NULL,1,3,True,1,'1','1','tt_kksyudansido_sankasyakekka',NULL,NULL,NULL,'集団指導参加者結果情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--地域保健集計区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyakekka.syukeikbn','010_tt_kksyudansido_sankasyakekka_006','地域保健集計区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansido_sankasyakekka',NULL,'111','1001,34','集団指導参加者結果情報（固定項目）テーブ','地域保健集計区分',NULL,'system','2023-01-01','system','2023-01-01');
--地域保健集計区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyakekka_syukeikbn_nm.nm','010_tt_kksyudansido_sankasyakekka_007','地域保健集計区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyakekka_syukeikbn_nm',NULL,NULL,NULL,'集団指導参加者結果情報（固定項目）テーブ','地域保健集計区分',NULL,'system','2023-01-01','system','2023-01-01');
--地域保健集計区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyakekka.syukeikbn || '':'' || tt_kksyudansido_sankasyakekka_syukeikbn_nm.nm','010_tt_kksyudansido_sankasyakekka_008','地域保健集計区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasyakekka','tt_kksyudansido_sankasyakekka_syukeikbn_nm',NULL,NULL,'集団指導参加者結果情報（固定項目）テーブ','地域保健集計区分',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyakekka.regsisyo','010_tt_kksyudansido_sankasyakekka_009','登録支所',NULL,1,3,True,1,'1','1','tt_kksyudansido_sankasyakekka',NULL,NULL,NULL,'集団指導参加者結果情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyakekka.reguserid','010_tt_kksyudansido_sankasyakekka_010','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_kksyudansido_sankasyakekka',NULL,NULL,NULL,'集団指導参加者結果情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyakekka.regdttm','010_tt_kksyudansido_sankasyakekka_011','登録日時',NULL,1,4,False,1,'1','1','tt_kksyudansido_sankasyakekka',NULL,NULL,NULL,'集団指導参加者結果情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyakekka.upduserid','010_tt_kksyudansido_sankasyakekka_012','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_kksyudansido_sankasyakekka',NULL,NULL,NULL,'集団指導参加者結果情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasyakekka.upddttm','010_tt_kksyudansido_sankasyakekka_013','更新日時',NULL,1,4,False,1,'1','1','tt_kksyudansido_sankasyakekka',NULL,NULL,NULL,'集団指導参加者結果情報（固定項目）テーブ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasya.gyomukbn','010_tt_kksyudansido_sankasya_001','業務区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansido_sankasya',NULL,'111','1001,101','集団指導参加者テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasya_gyomukbn_nm.nm','010_tt_kksyudansido_sankasya_002','業務区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasya_gyomukbn_nm',NULL,NULL,NULL,'集団指導参加者テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasya.gyomukbn || '':'' || tt_kksyudansido_sankasya_gyomukbn_nm.nm','010_tt_kksyudansido_sankasya_003','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasya','tt_kksyudansido_sankasya_gyomukbn_nm',NULL,NULL,'集団指導参加者テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasya.edano','010_tt_kksyudansido_sankasya_004','枝番',NULL,1,1,True,1,'1','1','tt_kksyudansido_sankasya',NULL,NULL,NULL,'集団指導参加者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasya.atenano','010_tt_kksyudansido_sankasya_005','宛名番号',NULL,1,3,True,1,'1','1','tt_kksyudansido_sankasya',NULL,NULL,NULL,'集団指導参加者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--その他日程事業・保健指導事業コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasya.jigyocd','010_tt_kksyudansido_sankasya_006','その他日程事業・保健指導事業コード',NULL,1,3,True,1,'1','1','tt_kksyudansido_sankasya',NULL,NULL,NULL,'集団指導参加者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--出欠区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasya.syukketukbn','010_tt_kksyudansido_sankasya_007','出欠区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansido_sankasya',NULL,'111','2019,21','集団指導参加者テーブル','出欠区分',NULL,'system','2023-01-01','system','2023-01-01');
--出欠区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasya_syukketukbn_nm.nm','010_tt_kksyudansido_sankasya_008','出欠区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasya_syukketukbn_nm',NULL,NULL,NULL,'集団指導参加者テーブル','出欠区分',NULL,'system','2023-01-01','system','2023-01-01');
--出欠区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_sankasya.syukketukbn || '':'' || tt_kksyudansido_sankasya_syukketukbn_nm.nm','010_tt_kksyudansido_sankasya_009','出欠区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_sankasya','tt_kksyudansido_sankasya_syukketukbn_nm',NULL,NULL,'集団指導参加者テーブル','出欠区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_staff.gyomukbn','010_tt_kksyudansido_staff_001','業務区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansido_staff',NULL,'111','1001,101','集団指導担当者テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_staff_gyomukbn_nm.nm','010_tt_kksyudansido_staff_002','業務区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_staff_gyomukbn_nm',NULL,NULL,NULL,'集団指導担当者テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--業務区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_staff.gyomukbn || '':'' || tt_kksyudansido_staff_gyomukbn_nm.nm','010_tt_kksyudansido_staff_003','業務区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_staff','tt_kksyudansido_staff_gyomukbn_nm',NULL,NULL,'集団指導担当者テーブル','業務区分',NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_staff.edano','010_tt_kksyudansido_staff_004','枝番',NULL,1,1,True,1,'1','1','tt_kksyudansido_staff',NULL,NULL,NULL,'集団指導担当者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分コード
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_staff.mosikomikekkakbn','010_tt_kksyudansido_staff_005','申込結果区分コード',NULL,1,3,True,3,'1',NULL,'tt_kksyudansido_staff',NULL,'111','1001,5','集団指導担当者テーブル','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_staff_mosikomikekkakbn_nm.nm','010_tt_kksyudansido_staff_006','申込結果区分名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_staff_mosikomikekkakbn_nm',NULL,NULL,NULL,'集団指導担当者テーブル','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--申込結果区分CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_staff.mosikomikekkakbn || '':'' || tt_kksyudansido_staff_mosikomikekkakbn_nm.nm','010_tt_kksyudansido_staff_007','申込結果区分CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kksyudansido_staff','tt_kksyudansido_staff_mosikomikekkakbn_nm',NULL,NULL,'集団指導担当者テーブル','申込結果区分',NULL,'system','2023-01-01','system','2023-01-01');
--担当者
INSERT INTO tm_eutableitem VALUES('tt_kksyudansido_staff.staffid','010_tt_kksyudansido_staff_008','担当者',NULL,1,3,True,1,'1','1','tt_kksyudansido_staff',NULL,NULL,NULL,'集団指導担当者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo.atenano','010_tt_kkfollownaiyo_001','宛名番号',NULL,1,3,True,1,'1','1','tt_kkfollownaiyo',NULL,NULL,NULL,'フォロー内容情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー内容枝番
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo.follownaiyoedano','010_tt_kkfollownaiyo_002','フォロー内容枝番',NULL,1,1,True,1,'1','1','tt_kkfollownaiyo',NULL,NULL,NULL,'フォロー内容情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー内容
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo.follownaiyo','010_tt_kkfollownaiyo_003','フォロー内容',NULL,1,3,True,1,'1','1','tt_kkfollownaiyo',NULL,NULL,NULL,'フォロー内容情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--把握経路コード
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo.haakukeiro','010_tt_kkfollownaiyo_004','把握経路コード',NULL,1,3,True,3,'1',NULL,'tt_kkfollownaiyo',NULL,'111','2019,32','フォロー内容情報テーブル','把握経路',NULL,'system','2023-01-01','system','2023-01-01');
--把握経路名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo_haakukeiro_nm.nm','010_tt_kkfollownaiyo_005','把握経路名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollownaiyo_haakukeiro_nm',NULL,NULL,NULL,'フォロー内容情報テーブル','把握経路',NULL,'system','2023-01-01','system','2023-01-01');
--把握経路CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo.haakukeiro || '':'' || tt_kkfollownaiyo_haakukeiro_nm.nm','010_tt_kkfollownaiyo_006','把握経路CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollownaiyo','tt_kkfollownaiyo_haakukeiro_nm',NULL,NULL,'フォロー内容情報テーブル','把握経路',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー把握事業コード
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo.haakujigyocd','010_tt_kkfollownaiyo_007','フォロー把握事業コード',NULL,1,3,True,3,'1',NULL,'tt_kkfollownaiyo',NULL,'121','3019,100006','フォロー内容情報テーブル','フォロー把握事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー把握事業名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo_haakujigyocd_nm.nm','010_tt_kkfollownaiyo_008','フォロー把握事業名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollownaiyo_haakujigyocd_nm',NULL,NULL,NULL,'フォロー内容情報テーブル','フォロー把握事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー把握事業CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo.haakujigyocd || '':'' || tt_kkfollownaiyo_haakujigyocd_nm.nm','010_tt_kkfollownaiyo_009','フォロー把握事業CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollownaiyo','tt_kkfollownaiyo_haakujigyocd_nm',NULL,NULL,'フォロー内容情報テーブル','フォロー把握事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所コード
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo.regsisyo','010_tt_kkfollownaiyo_010','登録支所コード',NULL,1,3,True,3,'1',NULL,'tt_kkfollownaiyo',NULL,'121','3019,1','フォロー内容情報テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo_regsisyo_nm.nm','010_tt_kkfollownaiyo_011','登録支所名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollownaiyo_regsisyo_nm',NULL,NULL,NULL,'フォロー内容情報テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録支所CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo.regsisyo || '':'' || tt_kkfollownaiyo_regsisyo_nm.nm','010_tt_kkfollownaiyo_012','登録支所CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollownaiyo','tt_kkfollownaiyo_regsisyo_nm',NULL,NULL,'フォロー内容情報テーブル','登録支所',NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo.reguserid','010_tt_kkfollownaiyo_013','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_kkfollownaiyo',NULL,NULL,NULL,'フォロー内容情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo.regdttm','010_tt_kkfollownaiyo_014','登録日時',NULL,1,4,False,1,'1','1','tt_kkfollownaiyo',NULL,NULL,NULL,'フォロー内容情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo.upduserid','010_tt_kkfollownaiyo_015','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_kkfollownaiyo',NULL,NULL,NULL,'フォロー内容情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_kkfollownaiyo.upddttm','010_tt_kkfollownaiyo_016','更新日時',NULL,1,4,False,1,'1','1','tt_kkfollownaiyo',NULL,NULL,NULL,'フォロー内容情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.atenano','010_tt_kkfollowyotei_001','宛名番号',NULL,1,3,True,1,'1','1','tt_kkfollowyotei',NULL,NULL,NULL,'フォロー予定情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー内容枝番
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.follownaiyoedano','010_tt_kkfollowyotei_002','フォロー内容枝番',NULL,1,1,True,1,'1','1','tt_kkfollowyotei',NULL,NULL,NULL,'フォロー予定情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.edano','010_tt_kkfollowyotei_003','枝番',NULL,1,1,True,1,'1','1','tt_kkfollowyotei',NULL,NULL,NULL,'フォロー予定情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー事業コード
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.followjigyocd','010_tt_kkfollowyotei_004','フォロー事業コード',NULL,1,3,True,3,'1',NULL,'tt_kkfollowyotei',NULL,'121','3019,100007','フォロー予定情報テーブル','フォロー事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー事業名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei_followjigyocd_nm.nm','010_tt_kkfollowyotei_005','フォロー事業名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollowyotei_followjigyocd_nm',NULL,NULL,NULL,'フォロー予定情報テーブル','フォロー事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー事業CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.followjigyocd || '':'' || tt_kkfollowyotei_followjigyocd_nm.nm','010_tt_kkfollowyotei_006','フォロー事業CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollowyotei','tt_kkfollowyotei_followjigyocd_nm',NULL,NULL,'フォロー予定情報テーブル','フォロー事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー方法コード
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.followhoho','010_tt_kkfollowyotei_007','フォロー方法コード',NULL,1,3,True,3,'1',NULL,'tt_kkfollowyotei',NULL,'111','2019,33','フォロー予定情報テーブル','フォロー方法',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー方法名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei_followhoho_nm.nm','010_tt_kkfollowyotei_008','フォロー方法名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollowyotei_followhoho_nm',NULL,NULL,NULL,'フォロー予定情報テーブル','フォロー方法',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー方法CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.followhoho || '':'' || tt_kkfollowyotei_followhoho_nm.nm','010_tt_kkfollowyotei_009','フォロー方法CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollowyotei','tt_kkfollowyotei_followhoho_nm',NULL,NULL,'フォロー予定情報テーブル','フォロー方法',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー予定日
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.followyoteiymd','010_tt_kkfollowyotei_010','フォロー予定日',NULL,1,3,True,1,'1','1','tt_kkfollowyotei',NULL,NULL,NULL,'フォロー予定情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー時間
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.followtm','010_tt_kkfollowyotei_011','フォロー時間',NULL,1,3,True,1,'1','1','tt_kkfollowyotei',NULL,NULL,NULL,'フォロー予定情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー会場コード
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.followkaijocd','010_tt_kkfollowyotei_012','フォロー会場コード',NULL,1,3,True,1,'1','1','tt_kkfollowyotei',NULL,NULL,NULL,'フォロー予定情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー理由
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.followriyu','010_tt_kkfollowyotei_013','フォロー理由',NULL,1,3,True,1,'1','1','tt_kkfollowyotei',NULL,NULL,NULL,'フォロー予定情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー担当者
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.followstaffid','010_tt_kkfollowyotei_014','フォロー担当者',NULL,1,3,True,1,'1','1','tt_kkfollowyotei',NULL,NULL,NULL,'フォロー予定情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.reguserid','010_tt_kkfollowyotei_015','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_kkfollowyotei',NULL,NULL,NULL,'フォロー予定情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.regdttm','010_tt_kkfollowyotei_016','登録日時',NULL,1,4,False,1,'1','1','tt_kkfollowyotei',NULL,NULL,NULL,'フォロー予定情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.upduserid','010_tt_kkfollowyotei_017','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_kkfollowyotei',NULL,NULL,NULL,'フォロー予定情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_kkfollowyotei.upddttm','010_tt_kkfollowyotei_018','更新日時',NULL,1,4,False,1,'1','1','tt_kkfollowyotei',NULL,NULL,NULL,'フォロー予定情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.atenano','010_tt_kkfollowkekka_001','宛名番号',NULL,1,3,True,1,'1','1','tt_kkfollowkekka',NULL,NULL,NULL,'フォロー結果情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー内容枝番
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.follownaiyoedano','010_tt_kkfollowkekka_002','フォロー内容枝番',NULL,1,1,True,1,'1','1','tt_kkfollowkekka',NULL,NULL,NULL,'フォロー結果情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--枝番
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.edano','010_tt_kkfollowkekka_003','枝番',NULL,1,1,True,1,'1','1','tt_kkfollowkekka',NULL,NULL,NULL,'フォロー結果情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー事業コード
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.followjigyocd','010_tt_kkfollowkekka_004','フォロー事業コード',NULL,1,3,True,3,'1',NULL,'tt_kkfollowkekka',NULL,'121','3019,100007','フォロー結果情報テーブル','フォロー事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー事業名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka_followjigyocd_nm.nm','010_tt_kkfollowkekka_005','フォロー事業名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollowkekka_followjigyocd_nm',NULL,NULL,NULL,'フォロー結果情報テーブル','フォロー事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー事業CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.followjigyocd || '':'' || tt_kkfollowkekka_followjigyocd_nm.nm','010_tt_kkfollowkekka_006','フォロー事業CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollowkekka','tt_kkfollowkekka_followjigyocd_nm',NULL,NULL,'フォロー結果情報テーブル','フォロー事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー状況コード
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.followstatus','010_tt_kkfollowkekka_007','フォロー状況コード',NULL,1,3,True,3,'1',NULL,'tt_kkfollowkekka',NULL,'111','2019,34','フォロー結果情報テーブル','フォロー状況',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー状況名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka_followstatus_nm.nm','010_tt_kkfollowkekka_008','フォロー状況名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollowkekka_followstatus_nm',NULL,NULL,NULL,'フォロー結果情報テーブル','フォロー状況',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー状況CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.followstatus || '':'' || tt_kkfollowkekka_followstatus_nm.nm','010_tt_kkfollowkekka_009','フォロー状況CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollowkekka','tt_kkfollowkekka_followstatus_nm',NULL,NULL,'フォロー結果情報テーブル','フォロー状況',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー方法コード
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.followhoho','010_tt_kkfollowkekka_010','フォロー方法コード',NULL,1,3,True,3,'1',NULL,'tt_kkfollowkekka',NULL,'111','2019,33','フォロー結果情報テーブル','フォロー方法',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー方法名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka_followhoho_nm.nm','010_tt_kkfollowkekka_011','フォロー方法名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollowkekka_followhoho_nm',NULL,NULL,NULL,'フォロー結果情報テーブル','フォロー方法',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー方法CD:名称
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.followhoho || '':'' || tt_kkfollowkekka_followhoho_nm.nm','010_tt_kkfollowkekka_012','フォロー方法CD:名称',NULL,0,2,False,1,'1',NULL,'tt_kkfollowkekka','tt_kkfollowkekka_followhoho_nm',NULL,NULL,'フォロー結果情報テーブル','フォロー方法',NULL,'system','2023-01-01','system','2023-01-01');
--フォロー実施日
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.followjissiymd','010_tt_kkfollowkekka_013','フォロー実施日',NULL,1,3,True,1,'1','1','tt_kkfollowkekka',NULL,NULL,NULL,'フォロー結果情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー時間
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.followtm','010_tt_kkfollowkekka_014','フォロー時間',NULL,1,3,True,1,'1','1','tt_kkfollowkekka',NULL,NULL,NULL,'フォロー結果情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー会場コード
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.followkaijocd','010_tt_kkfollowkekka_015','フォロー会場コード',NULL,1,3,True,1,'1','1','tt_kkfollowkekka',NULL,NULL,NULL,'フォロー結果情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー結果
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.followkekka','010_tt_kkfollowkekka_016','フォロー結果',NULL,1,3,True,1,'1','1','tt_kkfollowkekka',NULL,NULL,NULL,'フォロー結果情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フォロー担当者
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.followstaffid','010_tt_kkfollowkekka_017','フォロー担当者',NULL,1,3,True,1,'1','1','tt_kkfollowkekka',NULL,NULL,NULL,'フォロー結果情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.reguserid','010_tt_kkfollowkekka_018','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_kkfollowkekka',NULL,NULL,NULL,'フォロー結果情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.regdttm','010_tt_kkfollowkekka_019','登録日時',NULL,1,4,False,1,'1','1','tt_kkfollowkekka',NULL,NULL,NULL,'フォロー結果情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.upduserid','010_tt_kkfollowkekka_020','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_kkfollowkekka',NULL,NULL,NULL,'フォロー結果情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_kkfollowkekka.upddttm','010_tt_kkfollowkekka_021','更新日時',NULL,1,4,False,1,'1','1','tt_kkfollowkekka',NULL,NULL,NULL,'フォロー結果情報テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_kkrpthakkotaisyogaisya.atenano','010_tt_kkrpthakkotaisyogaisya_001','宛名番号',NULL,1,3,True,1,'1','1','tt_kkrpthakkotaisyogaisya',NULL,NULL,NULL,'帳票発行対象外者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--帳票グループID
INSERT INTO tm_eutableitem VALUES('tt_kkrpthakkotaisyogaisya.rptgroupid','010_tt_kkrpthakkotaisyogaisya_002','帳票グループID',NULL,1,3,True,1,'1','1','tt_kkrpthakkotaisyogaisya',NULL,NULL,NULL,'帳票発行対象外者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--受付日
INSERT INTO tm_eutableitem VALUES('tt_kkrpthakkotaisyogaisya.uketukeymd','010_tt_kkrpthakkotaisyogaisya_003','受付日',NULL,1,3,True,1,'1','1','tt_kkrpthakkotaisyogaisya',NULL,NULL,NULL,'帳票発行対象外者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--対象外理由
INSERT INTO tm_eutableitem VALUES('tt_kkrpthakkotaisyogaisya.taisyogairiyu','010_tt_kkrpthakkotaisyogaisya_004','対象外理由',NULL,1,3,True,1,'1','1','tt_kkrpthakkotaisyogaisya',NULL,NULL,NULL,'帳票発行対象外者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkrpthakkotaisyogaisya.reguserid','010_tt_kkrpthakkotaisyogaisya_005','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_kkrpthakkotaisyogaisya',NULL,NULL,NULL,'帳票発行対象外者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_kkrpthakkotaisyogaisya.regdttm','010_tt_kkrpthakkotaisyogaisya_006','登録日時',NULL,1,4,False,1,'1','1','tt_kkrpthakkotaisyogaisya',NULL,NULL,NULL,'帳票発行対象外者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_kkrpthakkotaisyogaisya.upduserid','010_tt_kkrpthakkotaisyogaisya_007','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_kkrpthakkotaisyogaisya',NULL,NULL,NULL,'帳票発行対象外者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_kkrpthakkotaisyogaisya.upddttm','010_tt_kkrpthakkotaisyogaisya_008','更新日時',NULL,1,4,False,1,'1','1','tt_kkrpthakkotaisyogaisya',NULL,NULL,NULL,'帳票発行対象外者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--成人健（検）診事業コード
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.jigyocd','020_tm_shfreeitem_001','成人健（検）診事業コード',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目コード
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.itemcd','020_tm_shfreeitem_002','項目コード',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目名
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.itemnm','020_tm_shfreeitem_003','項目名',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目区分コード
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.itemkbn','020_tm_shfreeitem_004','項目区分コード',NULL,1,3,True,3,'1',NULL,'tm_shfreeitem',NULL,'111','1000,49','成人保健検診結果（フリー）項目コントロー','項目区分',NULL,'system','2023-01-01','system','2023-01-01');
--項目区分名称
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_itemkbn_nm.nm','020_tm_shfreeitem_005','項目区分名称',NULL,0,2,False,1,'1',NULL,'tm_shfreeitem_itemkbn_nm',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー','項目区分',NULL,'system','2023-01-01','system','2023-01-01');
--項目区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.itemkbn || '':'' || tm_shfreeitem_itemkbn_nm.nm','020_tm_shfreeitem_006','項目区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_shfreeitem','tm_shfreeitem_itemkbn_nm',NULL,NULL,'成人保健検診結果（フリー）項目コントロー','項目区分',NULL,'system','2023-01-01','system','2023-01-01');
--グループID
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.groupid','020_tm_shfreeitem_007','グループID',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--グループID2
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.groupid2','020_tm_shfreeitem_008','グループID2',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力タイプコード
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.inputtype','020_tm_shfreeitem_009','入力タイプコード',NULL,1,1,True,3,'1',NULL,'tm_shfreeitem',NULL,'111','1000,14','成人保健検診結果（フリー）項目コントロー','入力タイプ',NULL,'system','2023-01-01','system','2023-01-01');
--入力タイプ名称
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_inputtype_nm.nm','020_tm_shfreeitem_010','入力タイプ名称',NULL,0,2,False,1,'1',NULL,'tm_shfreeitem_inputtype_nm',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー','入力タイプ',NULL,'system','2023-01-01','system','2023-01-01');
--入力タイプCD:名称
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.inputtype || '':'' || tm_shfreeitem_inputtype_nm.nm','020_tm_shfreeitem_011','入力タイプCD:名称',NULL,0,2,False,1,'1',NULL,'tm_shfreeitem','tm_shfreeitem_inputtype_nm',NULL,NULL,'成人保健検診結果（フリー）項目コントロー','入力タイプ',NULL,'system','2023-01-01','system','2023-01-01');
--コード条件1
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.codejoken1','020_tm_shfreeitem_012','コード条件1',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コード条件2
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.codejoken2','020_tm_shfreeitem_013','コード条件2',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コード条件3
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.codejoken3','020_tm_shfreeitem_014','コード条件3',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力桁
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.keta','020_tm_shfreeitem_015','入力桁',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--必須フラグ
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.hissuflg','020_tm_shfreeitem_016','必須フラグ',NULL,1,6,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力範囲（開始）
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.hanif','020_tm_shfreeitem_017','入力範囲（開始）',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力範囲（終了）
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.hanit','020_tm_shfreeitem_018','入力範囲（終了）',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--履歴管理フラグ
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.rirekiflg','020_tm_shfreeitem_019','履歴管理フラグ',NULL,1,6,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--表示フラグ
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.hyojiflg','020_tm_shfreeitem_020','表示フラグ',NULL,1,6,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--表示年度（開始）
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.hyojinendof','020_tm_shfreeitem_021','表示年度（開始）',NULL,1,1,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--表示年度（終了）
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.hyojinendot','020_tm_shfreeitem_022','表示年度（終了）',NULL,1,1,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力フラグ
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.inputflg','020_tm_shfreeitem_023','入力フラグ',NULL,1,6,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ区分コード
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.msgkbn','020_tm_shfreeitem_024','メッセージ区分コード',NULL,1,1,True,3,'1',NULL,'tm_shfreeitem',NULL,'111','1000,9','成人保健検診結果（フリー）項目コントロー','メッセージ区分',NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ区分名称
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_msgkbn_nm.nm','020_tm_shfreeitem_025','メッセージ区分名称',NULL,0,2,False,1,'1',NULL,'tm_shfreeitem_msgkbn_nm',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー','メッセージ区分',NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.msgkbn || '':'' || tm_shfreeitem_msgkbn_nm.nm','020_tm_shfreeitem_026','メッセージ区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_shfreeitem','tm_shfreeitem_msgkbn_nm',NULL,NULL,'成人保健検診結果（フリー）項目コントロー','メッセージ区分',NULL,'system','2023-01-01','system','2023-01-01');
--単位
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.tani','020_tm_shfreeitem_027','単位',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--初期値
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.syokiti','020_tm_shfreeitem_028','初期値',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--計算区分
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.keisankbn','020_tm_shfreeitem_029','計算区分',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--計算数式
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.keisansusiki','020_tm_shfreeitem_030','計算数式',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--計算関数IDコード
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.keisankansuid','020_tm_shfreeitem_031','計算関数IDコード',NULL,1,3,True,3,'1',NULL,'tm_shfreeitem',NULL,'111','1002,3','成人保健検診結果（フリー）項目コントロー','計算関数ID',NULL,'system','2023-01-01','system','2023-01-01');
--計算関数ID名称
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_keisankansuid_nm.nm','020_tm_shfreeitem_032','計算関数ID名称',NULL,0,2,False,1,'1',NULL,'tm_shfreeitem_keisankansuid_nm',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー','計算関数ID',NULL,'system','2023-01-01','system','2023-01-01');
--計算関数IDCD:名称
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.keisankansuid || '':'' || tm_shfreeitem_keisankansuid_nm.nm','020_tm_shfreeitem_033','計算関数IDCD:名称',NULL,0,2,False,1,'1',NULL,'tm_shfreeitem','tm_shfreeitem_keisankansuid_nm',NULL,NULL,'成人保健検診結果（フリー）項目コントロー','計算関数ID',NULL,'system','2023-01-01','system','2023-01-01');
--計算パラメータ
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.keisanparam','020_tm_shfreeitem_034','計算パラメータ',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--結果項目フラグ
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.kekkaflg','020_tm_shfreeitem_035','結果項目フラグ',NULL,1,6,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--利用検査方法コード
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.riyokensahohocd','020_tm_shfreeitem_036','利用検査方法コード',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--画面配置フラグ
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.haitiflg','020_tm_shfreeitem_037','画面配置フラグ',NULL,1,6,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--並びシーケンス
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.orderseq','020_tm_shfreeitem_038','並びシーケンス',NULL,1,1,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--備考
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.biko','020_tm_shfreeitem_039','備考',NULL,1,3,True,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.reguserid','020_tm_shfreeitem_040','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.regdttm','020_tm_shfreeitem_041','登録日時',NULL,1,4,False,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.upduserid','020_tm_shfreeitem_042','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem.upddttm','020_tm_shfreeitem_043','更新日時',NULL,1,4,False,1,'1','1','tm_shfreeitem',NULL,NULL,NULL,'成人保健検診結果（フリー）項目コントロー',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--成人健（検）診事業コード
INSERT INTO tm_eutableitem VALUES('tt_shfree.jigyocd','020_tt_shfree_001','成人健（検）診事業コード',NULL,1,3,True,1,'1','1','tt_shfree',NULL,NULL,NULL,'成人保健検診結果（フリー項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_shfree.atenano','020_tt_shfree_002','宛名番号',NULL,1,3,True,1,'1','1','tt_shfree',NULL,NULL,NULL,'成人保健検診結果（フリー項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--実施年度
INSERT INTO tm_eutableitem VALUES('tt_shfree.nendo','020_tt_shfree_003','実施年度',NULL,1,1,True,1,'1','1','tt_shfree',NULL,NULL,NULL,'成人保健検診結果（フリー項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--検診回数
INSERT INTO tm_eutableitem VALUES('tt_shfree.kensinkaisu','020_tt_shfree_004','検診回数',NULL,1,1,True,1,'1','1','tt_shfree',NULL,NULL,NULL,'成人保健検診結果（フリー項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目コード
INSERT INTO tm_eutableitem VALUES('tt_shfree.itemcd','020_tt_shfree_005','項目コード',NULL,1,3,True,1,'1','1','tt_shfree',NULL,NULL,NULL,'成人保健検診結果（フリー項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--区分
INSERT INTO tm_eutableitem VALUES('tt_shfree.kensinkbn','020_tt_shfree_006','区分',NULL,1,3,True,1,'1','1','tt_shfree',NULL,NULL,NULL,'成人保健検診結果（フリー項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_shfree.fusyoflg','020_tt_shfree_007','不詳フラグ',NULL,1,6,True,1,'1','1','tt_shfree',NULL,NULL,NULL,'成人保健検診結果（フリー項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--数値項目コード
INSERT INTO tm_eutableitem VALUES('tt_shfree.numvalue','020_tt_shfree_008','数値項目コード',NULL,1,2,True,3,'1',NULL,'tt_shfree',NULL,'111','1000,14','成人保健検診結果（フリー項目）テーブル','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--数値項目名称
INSERT INTO tm_eutableitem VALUES('tt_shfree_numvalue_nm.nm','020_tt_shfree_009','数値項目名称',NULL,0,2,False,1,'1',NULL,'tt_shfree_numvalue_nm',NULL,NULL,NULL,'成人保健検診結果（フリー項目）テーブル','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--数値項目CD:名称
INSERT INTO tm_eutableitem VALUES('tt_shfree.numvalue || '':'' || tt_shfree_numvalue_nm.nm','020_tt_shfree_010','数値項目CD:名称',NULL,0,2,False,1,'1',NULL,'tt_shfree','tt_shfree_numvalue_nm',NULL,NULL,'成人保健検診結果（フリー項目）テーブル','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目コード
INSERT INTO tm_eutableitem VALUES('tt_shfree.strvalue','020_tt_shfree_011','文字項目コード',NULL,1,3,True,3,'1',NULL,'tt_shfree',NULL,'111','1000,14','成人保健検診結果（フリー項目）テーブル','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目名称
INSERT INTO tm_eutableitem VALUES('tt_shfree_strvalue_nm.nm','020_tt_shfree_012','文字項目名称',NULL,0,2,False,1,'1',NULL,'tt_shfree_strvalue_nm',NULL,NULL,NULL,'成人保健検診結果（フリー項目）テーブル','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目CD:名称
INSERT INTO tm_eutableitem VALUES('tt_shfree.strvalue || '':'' || tt_shfree_strvalue_nm.nm','020_tt_shfree_013','文字項目CD:名称',NULL,0,2,False,1,'1',NULL,'tt_shfree','tt_shfree_strvalue_nm',NULL,NULL,'成人保健検診結果（フリー項目）テーブル','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--成人健（検）診事業コード
INSERT INTO tm_eutableitem VALUES('tt_shkensin.jigyocd','020_tt_shkensin_001','成人健（検）診事業コード',NULL,1,3,True,1,'1','1','tt_shkensin',NULL,NULL,NULL,'成人保健一次検診結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_shkensin.atenano','020_tt_shkensin_002','宛名番号',NULL,1,3,True,1,'1','1','tt_shkensin',NULL,NULL,NULL,'成人保健一次検診結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--実施年度
INSERT INTO tm_eutableitem VALUES('tt_shkensin.nendo','020_tt_shkensin_003','実施年度',NULL,1,1,True,1,'1','1','tt_shkensin',NULL,NULL,NULL,'成人保健一次検診結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--検診回数
INSERT INTO tm_eutableitem VALUES('tt_shkensin.kensinkaisu','020_tt_shkensin_004','検診回数',NULL,1,1,True,1,'1','1','tt_shkensin',NULL,NULL,NULL,'成人保健一次検診結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--実施日
INSERT INTO tm_eutableitem VALUES('tt_shkensin.jissiymd','020_tt_shkensin_005','実施日',NULL,1,3,True,1,'1','1','tt_shkensin',NULL,NULL,NULL,'成人保健一次検診結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--実施年齢
INSERT INTO tm_eutableitem VALUES('tt_shkensin.jissiage','020_tt_shkensin_006','実施年齢',NULL,1,1,True,1,'1','1','tt_shkensin',NULL,NULL,NULL,'成人保健一次検診結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--検査方法
INSERT INTO tm_eutableitem VALUES('tt_shkensin.kensahoho','020_tt_shkensin_007','検査方法',NULL,1,3,True,1,'1','1','tt_shkensin',NULL,NULL,NULL,'成人保健一次検診結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録支所
INSERT INTO tm_eutableitem VALUES('tt_shkensin.regsisyo','020_tt_shkensin_008','登録支所',NULL,1,3,True,1,'1','1','tt_shkensin',NULL,NULL,NULL,'成人保健一次検診結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_shkensin.reguserid','020_tt_shkensin_009','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_shkensin',NULL,NULL,NULL,'成人保健一次検診結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_shkensin.regdttm','020_tt_shkensin_010','登録日時',NULL,1,4,False,1,'1','1','tt_shkensin',NULL,NULL,NULL,'成人保健一次検診結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_shkensin.upduserid','020_tt_shkensin_011','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_shkensin',NULL,NULL,NULL,'成人保健一次検診結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_shkensin.upddttm','020_tt_shkensin_012','更新日時',NULL,1,4,False,1,'1','1','tt_shkensin',NULL,NULL,NULL,'成人保健一次検診結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--成人健（検）診事業コード
INSERT INTO tm_eutableitem VALUES('tt_shseiken.jigyocd','020_tt_shseiken_001','成人健（検）診事業コード',NULL,1,3,True,1,'1','1','tt_shseiken',NULL,NULL,NULL,'成人保健精密検査結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_shseiken.atenano','020_tt_shseiken_002','宛名番号',NULL,1,3,True,1,'1','1','tt_shseiken',NULL,NULL,NULL,'成人保健精密検査結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--実施年度
INSERT INTO tm_eutableitem VALUES('tt_shseiken.nendo','020_tt_shseiken_003','実施年度',NULL,1,1,True,1,'1','1','tt_shseiken',NULL,NULL,NULL,'成人保健精密検査結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--検診回数
INSERT INTO tm_eutableitem VALUES('tt_shseiken.kensinkaisu','020_tt_shseiken_004','検診回数',NULL,1,1,True,1,'1','1','tt_shseiken',NULL,NULL,NULL,'成人保健精密検査結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--実施日
INSERT INTO tm_eutableitem VALUES('tt_shseiken.jissiymd','020_tt_shseiken_005','実施日',NULL,1,3,True,1,'1','1','tt_shseiken',NULL,NULL,NULL,'成人保健精密検査結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--実施年齢
INSERT INTO tm_eutableitem VALUES('tt_shseiken.jissiage','020_tt_shseiken_006','実施年齢',NULL,1,1,True,1,'1','1','tt_shseiken',NULL,NULL,NULL,'成人保健精密検査結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--検査方法
INSERT INTO tm_eutableitem VALUES('tt_shseiken.kensahoho','020_tt_shseiken_007','検査方法',NULL,1,3,True,1,'1','1','tt_shseiken',NULL,NULL,NULL,'成人保健精密検査結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録支所
INSERT INTO tm_eutableitem VALUES('tt_shseiken.regsisyo','020_tt_shseiken_008','登録支所',NULL,1,3,True,1,'1','1','tt_shseiken',NULL,NULL,NULL,'成人保健精密検査結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_shseiken.reguserid','020_tt_shseiken_009','登録ユーザーID',NULL,1,3,False,1,'1','1','tt_shseiken',NULL,NULL,NULL,'成人保健精密検査結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tt_shseiken.regdttm','020_tt_shseiken_010','登録日時',NULL,1,4,False,1,'1','1','tt_shseiken',NULL,NULL,NULL,'成人保健精密検査結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tt_shseiken.upduserid','020_tt_shseiken_011','更新ユーザーID',NULL,1,3,False,1,'1','1','tt_shseiken',NULL,NULL,NULL,'成人保健精密検査結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tt_shseiken.upddttm','020_tt_shseiken_012','更新日時',NULL,1,4,False,1,'1','1','tt_shseiken',NULL,NULL,NULL,'成人保健精密検査結果（固定項目）テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--成人健（検）診事業コード
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.jigyocd','020_tm_shkensinjigyo_001','成人健（検）診事業コード',NULL,1,3,True,3,'1',NULL,'tm_shkensinjigyo',NULL,'121','3019,200001','成人健（検）診事業マスタ','成人健（検）診事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--成人健（検）診事業名称
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo_jigyocd_nm.nm','020_tm_shkensinjigyo_002','成人健（検）診事業名称',NULL,0,2,False,1,'1',NULL,'tm_shkensinjigyo_jigyocd_nm',NULL,NULL,NULL,'成人健（検）診事業マスタ','成人健（検）診事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--成人健（検）診事業CD:名称
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.jigyocd || '':'' || tm_shkensinjigyo_jigyocd_nm.nm','020_tm_shkensinjigyo_003','成人健（検）診事業CD:名称',NULL,0,2,False,1,'1',NULL,'tm_shkensinjigyo','tm_shkensinjigyo_jigyocd_nm',NULL,NULL,'成人健（検）診事業マスタ','成人健（検）診事業コード',NULL,'system','2023-01-01','system','2023-01-01');
--基本／拡張事業区分コード
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.kihonkakutyokbn','020_tm_shkensinjigyo_004','基本／拡張事業区分コード',NULL,1,3,True,3,'1',NULL,'tm_shkensinjigyo',NULL,'111','1000,48','成人健（検）診事業マスタ','基本／拡張事業区分',NULL,'system','2023-01-01','system','2023-01-01');
--基本／拡張事業区分名称
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo_kihonkakutyokbn_nm.nm','020_tm_shkensinjigyo_005','基本／拡張事業区分名称',NULL,0,2,False,1,'1',NULL,'tm_shkensinjigyo_kihonkakutyokbn_nm',NULL,NULL,NULL,'成人健（検）診事業マスタ','基本／拡張事業区分',NULL,'system','2023-01-01','system','2023-01-01');
--基本／拡張事業区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.kihonkakutyokbn || '':'' || tm_shkensinjigyo_kihonkakutyokbn_nm.nm','020_tm_shkensinjigyo_006','基本／拡張事業区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_shkensinjigyo','tm_shkensinjigyo_kihonkakutyokbn_nm',NULL,NULL,'成人健（検）診事業マスタ','基本／拡張事業区分',NULL,'system','2023-01-01','system','2023-01-01');
--精密検査実施区分コード
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.seikenjissikbn','020_tm_shkensinjigyo_007','精密検査実施区分コード',NULL,1,3,True,3,'1',NULL,'tm_shkensinjigyo',NULL,'111','1002,8','成人健（検）診事業マスタ','精密検査実施区分',NULL,'system','2023-01-01','system','2023-01-01');
--精密検査実施区分名称
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo_seikenjissikbn_nm.nm','020_tm_shkensinjigyo_008','精密検査実施区分名称',NULL,0,2,False,1,'1',NULL,'tm_shkensinjigyo_seikenjissikbn_nm',NULL,NULL,NULL,'成人健（検）診事業マスタ','精密検査実施区分',NULL,'system','2023-01-01','system','2023-01-01');
--精密検査実施区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.seikenjissikbn || '':'' || tm_shkensinjigyo_seikenjissikbn_nm.nm','020_tm_shkensinjigyo_009','精密検査実施区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_shkensinjigyo','tm_shkensinjigyo_seikenjissikbn_nm',NULL,NULL,'成人健（検）診事業マスタ','精密検査実施区分',NULL,'system','2023-01-01','system','2023-01-01');
--減免区分コード
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.genmenkbn','020_tm_shkensinjigyo_010','減免区分コード',NULL,1,3,True,3,'1',NULL,'tm_shkensinjigyo',NULL,'111','1002,10','成人健（検）診事業マスタ','減免区分',NULL,'system','2023-01-01','system','2023-01-01');
--減免区分名称
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo_genmenkbn_nm.nm','020_tm_shkensinjigyo_011','減免区分名称',NULL,0,2,False,1,'1',NULL,'tm_shkensinjigyo_genmenkbn_nm',NULL,NULL,NULL,'成人健（検）診事業マスタ','減免区分',NULL,'system','2023-01-01','system','2023-01-01');
--減免区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.genmenkbn || '':'' || tm_shkensinjigyo_genmenkbn_nm.nm','020_tm_shkensinjigyo_012','減免区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_shkensinjigyo','tm_shkensinjigyo_genmenkbn_nm',NULL,NULL,'成人健（検）診事業マスタ','減免区分',NULL,'system','2023-01-01','system','2023-01-01');
--クーポン券表示区分コード
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.cuponhyojikbn','020_tm_shkensinjigyo_013','クーポン券表示区分コード',NULL,1,3,True,3,'1',NULL,'tm_shkensinjigyo',NULL,'111','1002,9','成人健（検）診事業マスタ','クーポン券表示区分',NULL,'system','2023-01-01','system','2023-01-01');
--クーポン券表示区分名称
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo_cuponhyojikbn_nm.nm','020_tm_shkensinjigyo_014','クーポン券表示区分名称',NULL,0,2,False,1,'1',NULL,'tm_shkensinjigyo_cuponhyojikbn_nm',NULL,NULL,NULL,'成人健（検）診事業マスタ','クーポン券表示区分',NULL,'system','2023-01-01','system','2023-01-01');
--クーポン券表示区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.cuponhyojikbn || '':'' || tm_shkensinjigyo_cuponhyojikbn_nm.nm','020_tm_shkensinjigyo_015','クーポン券表示区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_shkensinjigyo','tm_shkensinjigyo_cuponhyojikbn_nm',NULL,NULL,'成人健（検）診事業マスタ','クーポン券表示区分',NULL,'system','2023-01-01','system','2023-01-01');
--検査方法設定フラグ
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.kensahoho_setflg','020_tm_shkensinjigyo_016','検査方法設定フラグ',NULL,1,6,True,1,'1','1','tm_shkensinjigyo',NULL,NULL,NULL,'成人健（検）診事業マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--検査方法メインコード
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.kensahoho_maincd','020_tm_shkensinjigyo_017','検査方法メインコード',NULL,1,3,True,1,'1','1','tm_shkensinjigyo',NULL,NULL,NULL,'成人健（検）診事業マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--検査方法サブコード
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.kensahoho_subcd','020_tm_shkensinjigyo_018','検査方法サブコード',NULL,1,1,True,1,'1','1','tm_shkensinjigyo',NULL,NULL,NULL,'成人健（検）診事業マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--予約分類メインコード
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.yoyakubunrui_maincd','020_tm_shkensinjigyo_019','予約分類メインコード',NULL,1,3,True,1,'1','1','tm_shkensinjigyo',NULL,NULL,NULL,'成人健（検）診事業マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--予約分類サブコード
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.yoyakubunrui_subcd','020_tm_shkensinjigyo_020','予約分類サブコード',NULL,1,1,True,1,'1','1','tm_shkensinjigyo',NULL,NULL,NULL,'成人健（検）診事業マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フリー項目グループ右設定メインコード
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.groupid2_maincd','020_tm_shkensinjigyo_021','フリー項目グループ右設定メインコード',NULL,1,3,True,1,'1','1','tm_shkensinjigyo',NULL,NULL,NULL,'成人健（検）診事業マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--フリー項目グループ右設定サブコード
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.groupid2_subcd','020_tm_shkensinjigyo_022','フリー項目グループ右設定サブコード',NULL,1,1,True,1,'1','1','tm_shkensinjigyo',NULL,NULL,NULL,'成人健（検）診事業マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.reguserid','020_tm_shkensinjigyo_023','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_shkensinjigyo',NULL,NULL,NULL,'成人健（検）診事業マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.regdttm','020_tm_shkensinjigyo_024','登録日時',NULL,1,4,False,1,'1','1','tm_shkensinjigyo',NULL,NULL,NULL,'成人健（検）診事業マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.upduserid','020_tm_shkensinjigyo_025','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_shkensinjigyo',NULL,NULL,NULL,'成人健（検）診事業マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_shkensinjigyo.upddttm','020_tm_shkensinjigyo_026','更新日時',NULL,1,4,False,1,'1','1','tm_shkensinjigyo',NULL,NULL,NULL,'成人健（検）診事業マスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子種類
INSERT INTO tm_eutableitem VALUES('tm_bhsyosaimenyu.bhsyurui','030_tm_bhsyosaimenyu_001','母子種類',NULL,1,3,True,1,'1','1','tm_bhsyosaimenyu',NULL,NULL,NULL,'母子保健詳細メニューマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子詳細メニューコード
INSERT INTO tm_eutableitem VALUES('tm_bhsyosaimenyu.bhsyosaimenyucd','030_tm_bhsyosaimenyu_002','母子詳細メニューコード',NULL,1,3,True,1,'1','1','tm_bhsyosaimenyu',NULL,NULL,NULL,'母子保健詳細メニューマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子詳細メニュー名称
INSERT INTO tm_eutableitem VALUES('tm_bhsyosaimenyu.bhsyosaimenyuname','030_tm_bhsyosaimenyu_003','母子詳細メニュー名称',NULL,1,3,True,1,'1','1','tm_bhsyosaimenyu',NULL,NULL,NULL,'母子保健詳細メニューマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--並びシーケンス
INSERT INTO tm_eutableitem VALUES('tm_bhsyosaimenyu.orderseq','030_tm_bhsyosaimenyu_004','並びシーケンス',NULL,1,1,True,1,'1','1','tm_bhsyosaimenyu',NULL,NULL,NULL,'母子保健詳細メニューマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子種類
INSERT INTO tm_eutableitem VALUES('tm_bhkanripattern.bhsyurui','030_tm_bhkanripattern_001','母子種類',NULL,1,3,True,1,'1','1','tm_bhkanripattern',NULL,NULL,NULL,'母子保健管理パターンマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子管理パターンコード
INSERT INTO tm_eutableitem VALUES('tm_bhkanripattern.bhkanripatterncd','030_tm_bhkanripattern_002','母子管理パターンコード',NULL,1,3,True,1,'1','1','tm_bhkanripattern',NULL,NULL,NULL,'母子保健管理パターンマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子管理パターン名称
INSERT INTO tm_eutableitem VALUES('tm_bhkanripattern.bhkanripatternname','030_tm_bhkanripattern_003','母子管理パターン名称',NULL,1,3,True,1,'1','1','tm_bhkanripattern',NULL,NULL,NULL,'母子保健管理パターンマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子種類
INSERT INTO tm_eutableitem VALUES('tm_bhsyosaitab.bhsyurui','030_tm_bhsyosaitab_001','母子種類',NULL,1,3,True,1,'1','1','tm_bhsyosaitab',NULL,NULL,NULL,'母子保健詳細タブマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子詳細メニューコード
INSERT INTO tm_eutableitem VALUES('tm_bhsyosaitab.bhsyosaimenyucd','030_tm_bhsyosaitab_002','母子詳細メニューコード',NULL,1,3,True,1,'1','1','tm_bhsyosaitab',NULL,NULL,NULL,'母子保健詳細タブマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子詳細タブコード
INSERT INTO tm_eutableitem VALUES('tm_bhsyosaitab.bhsyosaitabcd','030_tm_bhsyosaitab_003','母子詳細タブコード',NULL,1,3,True,1,'1','1','tm_bhsyosaitab',NULL,NULL,NULL,'母子保健詳細タブマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子詳細タブ名称
INSERT INTO tm_eutableitem VALUES('tm_bhsyosaitab.bhsyosaitabname','030_tm_bhsyosaitab_004','母子詳細タブ名称',NULL,1,3,True,1,'1','1','tm_bhsyosaitab',NULL,NULL,NULL,'母子保健詳細タブマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子データリストコード
INSERT INTO tm_eutableitem VALUES('tm_bhsyosaitab.bhdatalistcd','030_tm_bhsyosaitab_005','母子データリストコード',NULL,1,3,True,1,'1','1','tm_bhsyosaitab',NULL,NULL,NULL,'母子保健詳細タブマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--並びシーケンス
INSERT INTO tm_eutableitem VALUES('tm_bhsyosaitab.orderseq','030_tm_bhsyosaitab_006','並びシーケンス',NULL,1,1,True,1,'1','1','tm_bhsyosaitab',NULL,NULL,NULL,'母子保健詳細タブマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子種類
INSERT INTO tm_eutableitem VALUES('tm_bhdatalist.bhsyurui','030_tm_bhdatalist_001','母子種類',NULL,1,3,True,1,'1','1','tm_bhdatalist',NULL,NULL,NULL,'母子保健データリストマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子データリストコード
INSERT INTO tm_eutableitem VALUES('tm_bhdatalist.bhdatalistcd','030_tm_bhdatalist_002','母子データリストコード',NULL,1,3,True,1,'1','1','tm_bhdatalist',NULL,NULL,NULL,'母子保健データリストマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子データリスト名称
INSERT INTO tm_eutableitem VALUES('tm_bhdatalist.bhdatalistname','030_tm_bhdatalist_003','母子データリスト名称',NULL,1,3,True,1,'1','1','tm_bhdatalist',NULL,NULL,NULL,'母子保健データリストマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--履歴管理最大
INSERT INTO tm_eutableitem VALUES('tm_bhdatalist.rirekikanrimax','030_tm_bhdatalist_004','履歴管理最大',NULL,1,3,True,1,'1','1','tm_bhdatalist',NULL,NULL,NULL,'母子保健データリストマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子管理パターンコード
INSERT INTO tm_eutableitem VALUES('tm_bhdatalist.bhkanripatterncd','030_tm_bhdatalist_005','母子管理パターンコード',NULL,1,3,True,1,'1','1','tm_bhdatalist',NULL,NULL,NULL,'母子保健データリストマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子種類
INSERT INTO tm_eutableitem VALUES('tm_bhitem.bhsyurui','030_tm_bhitem_001','母子種類',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子データリストコード
INSERT INTO tm_eutableitem VALUES('tm_bhitem.bhdatalistcd','030_tm_bhitem_002','母子データリストコード',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目コード
INSERT INTO tm_eutableitem VALUES('tm_bhitem.itemcd','030_tm_bhitem_003','項目コード',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目名
INSERT INTO tm_eutableitem VALUES('tm_bhitem.itemnm','030_tm_bhitem_004','項目名',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--グループID
INSERT INTO tm_eutableitem VALUES('tm_bhitem.groupid','030_tm_bhitem_005','グループID',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--グループID2
INSERT INTO tm_eutableitem VALUES('tm_bhitem.groupid2','030_tm_bhitem_006','グループID2',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力タイプコード
INSERT INTO tm_eutableitem VALUES('tm_bhitem.inputtype','030_tm_bhitem_007','入力タイプコード',NULL,1,1,True,3,'1',NULL,'tm_bhitem',NULL,'111','1000,14','母子保健項目コントロールマスタ','入力タイプ',NULL,'system','2023-01-01','system','2023-01-01');
--入力タイプ名称
INSERT INTO tm_eutableitem VALUES('tm_bhitem_inputtype_nm.nm','030_tm_bhitem_008','入力タイプ名称',NULL,0,2,False,1,'1',NULL,'tm_bhitem_inputtype_nm',NULL,NULL,NULL,'母子保健項目コントロールマスタ','入力タイプ',NULL,'system','2023-01-01','system','2023-01-01');
--入力タイプCD:名称
INSERT INTO tm_eutableitem VALUES('tm_bhitem.inputtype || '':'' || tm_bhitem_inputtype_nm.nm','030_tm_bhitem_009','入力タイプCD:名称',NULL,0,2,False,1,'1',NULL,'tm_bhitem','tm_bhitem_inputtype_nm',NULL,NULL,'母子保健項目コントロールマスタ','入力タイプ',NULL,'system','2023-01-01','system','2023-01-01');
--コード条件1
INSERT INTO tm_eutableitem VALUES('tm_bhitem.codejoken1','030_tm_bhitem_010','コード条件1',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コード条件2
INSERT INTO tm_eutableitem VALUES('tm_bhitem.codejoken2','030_tm_bhitem_011','コード条件2',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--コード条件3
INSERT INTO tm_eutableitem VALUES('tm_bhitem.codejoken3','030_tm_bhitem_012','コード条件3',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力桁
INSERT INTO tm_eutableitem VALUES('tm_bhitem.keta','030_tm_bhitem_013','入力桁',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--必須フラグ
INSERT INTO tm_eutableitem VALUES('tm_bhitem.hissuflg','030_tm_bhitem_014','必須フラグ',NULL,1,6,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力範囲（開始）
INSERT INTO tm_eutableitem VALUES('tm_bhitem.hanif','030_tm_bhitem_015','入力範囲（開始）',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力範囲（終了）
INSERT INTO tm_eutableitem VALUES('tm_bhitem.hanit','030_tm_bhitem_016','入力範囲（終了）',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--履歴管理フラグ
INSERT INTO tm_eutableitem VALUES('tm_bhitem.rirekiflg','030_tm_bhitem_017','履歴管理フラグ',NULL,1,6,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--表示フラグ
INSERT INTO tm_eutableitem VALUES('tm_bhitem.hyojiflg','030_tm_bhitem_018','表示フラグ',NULL,1,6,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--表示年度（開始）
INSERT INTO tm_eutableitem VALUES('tm_bhitem.hyojinendof','030_tm_bhitem_019','表示年度（開始）',NULL,1,1,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--表示年度（終了）
INSERT INTO tm_eutableitem VALUES('tm_bhitem.hyojinendot','030_tm_bhitem_020','表示年度（終了）',NULL,1,1,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--入力フラグ
INSERT INTO tm_eutableitem VALUES('tm_bhitem.inputflg','030_tm_bhitem_021','入力フラグ',NULL,1,6,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ区分コード
INSERT INTO tm_eutableitem VALUES('tm_bhitem.msgkbn','030_tm_bhitem_022','メッセージ区分コード',NULL,1,1,True,3,'1',NULL,'tm_bhitem',NULL,'111','1000,9','母子保健項目コントロールマスタ','メッセージ区分',NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ区分名称
INSERT INTO tm_eutableitem VALUES('tm_bhitem_msgkbn_nm.nm','030_tm_bhitem_023','メッセージ区分名称',NULL,0,2,False,1,'1',NULL,'tm_bhitem_msgkbn_nm',NULL,NULL,NULL,'母子保健項目コントロールマスタ','メッセージ区分',NULL,'system','2023-01-01','system','2023-01-01');
--メッセージ区分CD:名称
INSERT INTO tm_eutableitem VALUES('tm_bhitem.msgkbn || '':'' || tm_bhitem_msgkbn_nm.nm','030_tm_bhitem_024','メッセージ区分CD:名称',NULL,0,2,False,1,'1',NULL,'tm_bhitem','tm_bhitem_msgkbn_nm',NULL,NULL,'母子保健項目コントロールマスタ','メッセージ区分',NULL,'system','2023-01-01','system','2023-01-01');
--単位
INSERT INTO tm_eutableitem VALUES('tm_bhitem.tani','030_tm_bhitem_025','単位',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--初期値
INSERT INTO tm_eutableitem VALUES('tm_bhitem.syokiti','030_tm_bhitem_026','初期値',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--計算区分
INSERT INTO tm_eutableitem VALUES('tm_bhitem.keisankbn','030_tm_bhitem_027','計算区分',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--計算数式
INSERT INTO tm_eutableitem VALUES('tm_bhitem.keisansusiki','030_tm_bhitem_028','計算数式',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--計算関数IDコード
INSERT INTO tm_eutableitem VALUES('tm_bhitem.keisankansuid','030_tm_bhitem_029','計算関数IDコード',NULL,1,3,True,3,'1',NULL,'tm_bhitem',NULL,'111','1002,3','母子保健項目コントロールマスタ','計算関数ID',NULL,'system','2023-01-01','system','2023-01-01');
--計算関数ID名称
INSERT INTO tm_eutableitem VALUES('tm_bhitem_keisankansuid_nm.nm','030_tm_bhitem_030','計算関数ID名称',NULL,0,2,False,1,'1',NULL,'tm_bhitem_keisankansuid_nm',NULL,NULL,NULL,'母子保健項目コントロールマスタ','計算関数ID',NULL,'system','2023-01-01','system','2023-01-01');
--計算関数IDCD:名称
INSERT INTO tm_eutableitem VALUES('tm_bhitem.keisankansuid || '':'' || tm_bhitem_keisankansuid_nm.nm','030_tm_bhitem_031','計算関数IDCD:名称',NULL,0,2,False,1,'1',NULL,'tm_bhitem','tm_bhitem_keisankansuid_nm',NULL,NULL,'母子保健項目コントロールマスタ','計算関数ID',NULL,'system','2023-01-01','system','2023-01-01');
--計算パラメータ
INSERT INTO tm_eutableitem VALUES('tm_bhitem.keisanparam','030_tm_bhitem_032','計算パラメータ',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--結果項目フラグ
INSERT INTO tm_eutableitem VALUES('tm_bhitem.kekkaflg','030_tm_bhitem_033','結果項目フラグ',NULL,1,6,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--利用検査方法コード
INSERT INTO tm_eutableitem VALUES('tm_bhitem.riyokensahohocd','030_tm_bhitem_034','利用検査方法コード',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--画面配置フラグ
INSERT INTO tm_eutableitem VALUES('tm_bhitem.haitiflg','030_tm_bhitem_035','画面配置フラグ',NULL,1,6,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--並びシーケンス
INSERT INTO tm_eutableitem VALUES('tm_bhitem.orderseq','030_tm_bhitem_036','並びシーケンス',NULL,1,1,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--備考
INSERT INTO tm_eutableitem VALUES('tm_bhitem.biko','030_tm_bhitem_037','備考',NULL,1,3,True,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_bhitem.reguserid','030_tm_bhitem_038','登録ユーザーID',NULL,1,3,False,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--登録日時
INSERT INTO tm_eutableitem VALUES('tm_bhitem.regdttm','030_tm_bhitem_039','登録日時',NULL,1,4,False,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新ユーザーID
INSERT INTO tm_eutableitem VALUES('tm_bhitem.upduserid','030_tm_bhitem_040','更新ユーザーID',NULL,1,3,False,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--更新日時
INSERT INTO tm_eutableitem VALUES('tm_bhitem.upddttm','030_tm_bhitem_041','更新日時',NULL,1,4,False,1,'1','1','tm_bhitem',NULL,NULL,NULL,'母子保健項目コントロールマスタ',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子種類
INSERT INTO tm_eutableitem VALUES('tt_bhitem.bhsyurui','030_tt_bhitem_001','母子種類',NULL,1,3,True,1,'1','1','tt_bhitem',NULL,NULL,NULL,'母子保健項目テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子詳細メニューコード
INSERT INTO tm_eutableitem VALUES('tt_bhitem.bhsyosaimenyucd','030_tt_bhitem_002','母子詳細メニューコード',NULL,1,3,True,1,'1','1','tt_bhitem',NULL,NULL,NULL,'母子保健項目テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子詳細タブコード
INSERT INTO tm_eutableitem VALUES('tt_bhitem.bhsyosaitabcd','030_tt_bhitem_003','母子詳細タブコード',NULL,1,3,True,1,'1','1','tt_bhitem',NULL,NULL,NULL,'母子保健項目テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子データリストコード
INSERT INTO tm_eutableitem VALUES('tt_bhitem.bhdatalistcd','030_tt_bhitem_004','母子データリストコード',NULL,1,3,True,1,'1','1','tt_bhitem',NULL,NULL,NULL,'母子保健項目テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tt_bhitem.atenano','030_tt_bhitem_005','宛名番号',NULL,1,3,True,1,'1','1','tt_bhitem',NULL,NULL,NULL,'母子保健項目テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--履歴回数
INSERT INTO tm_eutableitem VALUES('tt_bhitem.kensinkaisu','030_tt_bhitem_006','履歴回数',NULL,1,1,True,1,'1','1','tt_bhitem',NULL,NULL,NULL,'母子保健項目テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--項目コード
INSERT INTO tm_eutableitem VALUES('tt_bhitem.itemcd','030_tt_bhitem_007','項目コード',NULL,1,3,True,1,'1','1','tt_bhitem',NULL,NULL,NULL,'母子保健項目テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--不詳フラグ
INSERT INTO tm_eutableitem VALUES('tt_bhitem.fusyoflg','030_tt_bhitem_008','不詳フラグ',NULL,1,6,True,1,'1','1','tt_bhitem',NULL,NULL,NULL,'母子保健項目テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--数値項目コード
INSERT INTO tm_eutableitem VALUES('tt_bhitem.numvalue','030_tt_bhitem_009','数値項目コード',NULL,1,2,True,3,'1',NULL,'tt_bhitem',NULL,'111','1000,14','母子保健項目テーブル','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--数値項目名称
INSERT INTO tm_eutableitem VALUES('tt_bhitem_numvalue_nm.nm','030_tt_bhitem_010','数値項目名称',NULL,0,2,False,1,'1',NULL,'tt_bhitem_numvalue_nm',NULL,NULL,NULL,'母子保健項目テーブル','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--数値項目CD:名称
INSERT INTO tm_eutableitem VALUES('tt_bhitem.numvalue || '':'' || tt_bhitem_numvalue_nm.nm','030_tt_bhitem_011','数値項目CD:名称',NULL,0,2,False,1,'1',NULL,'tt_bhitem','tt_bhitem_numvalue_nm',NULL,NULL,'母子保健項目テーブル','数値項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目コード
INSERT INTO tm_eutableitem VALUES('tt_bhitem.strvalue','030_tt_bhitem_012','文字項目コード',NULL,1,3,True,3,'1',NULL,'tt_bhitem',NULL,'111','1000,14','母子保健項目テーブル','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目名称
INSERT INTO tm_eutableitem VALUES('tt_bhitem_strvalue_nm.nm','030_tt_bhitem_013','文字項目名称',NULL,0,2,False,1,'1',NULL,'tt_bhitem_strvalue_nm',NULL,NULL,NULL,'母子保健項目テーブル','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--文字項目CD:名称
INSERT INTO tm_eutableitem VALUES('tt_bhitem.strvalue || '':'' || tt_bhitem_strvalue_nm.nm','030_tt_bhitem_014','文字項目CD:名称',NULL,0,2,False,1,'1',NULL,'tt_bhitem','tt_bhitem_strvalue_nm',NULL,NULL,'母子保健項目テーブル','文字項目',NULL,'system','2023-01-01','system','2023-01-01');
--母子種類
INSERT INTO tm_eutableitem VALUES('tm_bhkensin.bhsyurui','030_tm_bhkensin_001','母子種類',NULL,1,3,True,1,'1','1','tm_bhkensin',NULL,NULL,NULL,'母子保健健診対象者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--母子データリストコード
INSERT INTO tm_eutableitem VALUES('tm_bhkensin.bhdatalistcd','030_tm_bhkensin_002','母子データリストコード',NULL,1,3,True,1,'1','1','tm_bhkensin',NULL,NULL,NULL,'母子保健健診対象者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--宛名番号
INSERT INTO tm_eutableitem VALUES('tm_bhkensin.atenano','030_tm_bhkensin_003','宛名番号',NULL,1,3,True,1,'1','1','tm_bhkensin',NULL,NULL,NULL,'母子保健健診対象者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--受付日
INSERT INTO tm_eutableitem VALUES('tm_bhkensin.uketukeymd','030_tm_bhkensin_004','受付日',NULL,1,3,True,1,'1','1','tm_bhkensin',NULL,NULL,NULL,'母子保健健診対象者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--健診予定日
INSERT INTO tm_eutableitem VALUES('tm_bhkensin.kensinyoteiymd','030_tm_bhkensin_005','健診予定日',NULL,1,3,True,1,'1','1','tm_bhkensin',NULL,NULL,NULL,'母子保健健診対象者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--受付開始時間
INSERT INTO tm_eutableitem VALUES('tm_bhkensin.uketukedttm','030_tm_bhkensin_006','受付開始時間',NULL,1,3,True,1,'1','1','tm_bhkensin',NULL,NULL,NULL,'母子保健健診対象者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--会場コード
INSERT INTO tm_eutableitem VALUES('tm_bhkensin.kaijocd','030_tm_bhkensin_007','会場コード',NULL,1,3,True,1,'1','1','tm_bhkensin',NULL,NULL,NULL,'母子保健健診対象者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--お知らせ出力フラグ
INSERT INTO tm_eutableitem VALUES('tm_bhkensin.osiraseflg','030_tm_bhkensin_008','お知らせ出力フラグ',NULL,1,6,True,1,'1','1','tm_bhkensin',NULL,NULL,NULL,'母子保健健診対象者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--案内出力フラグ
INSERT INTO tm_eutableitem VALUES('tm_bhkensin.annaiflg','030_tm_bhkensin_009','案内出力フラグ',NULL,1,6,True,1,'1','1','tm_bhkensin',NULL,NULL,NULL,'母子保健健診対象者テーブル',NULL,NULL,'system','2023-01-01','system','2023-01-01');
--乳がん_実施区分
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901153.numvalue','F01000','乳がん_実施区分','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901153',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901153.numvalue'',''F01000'',''乳がん_実施区分'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901153'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_医療機関コード
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901154.numvalue','F01001','乳がん_医療機関コード','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901154',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901154.numvalue'',''F01001'',''乳がん_医療機関コード'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901154'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_医療機関名
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901155.numvalue','F01002','乳がん_医療機関名','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901155',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901155.numvalue'',''F01002'',''乳がん_医療機関名'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901155'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_会場コード
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901156.numvalue','F01003','乳がん_会場コード','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901156',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901156.numvalue'',''F01003'',''乳がん_会場コード'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901156'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_会場名
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901157.numvalue','F01004','乳がん_会場名','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901157',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901157.numvalue'',''F01004'',''乳がん_会場名'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901157'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_費用徴収情報
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901159.numvalue','F01005','乳がん_費用徴収情報','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901159',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901159.numvalue'',''F01005'',''乳がん_費用徴収情報'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901159'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_判定
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901160.numvalue','F01006','乳がん_判定','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901160',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901160.numvalue'',''F01006'',''乳がん_判定'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901160'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_保険者番号
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901163.numvalue','F01007','乳がん_保険者番号','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901163',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901163.numvalue'',''F01007'',''乳がん_保険者番号'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901163'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_被保険者記号
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901164.numvalue','F01008','乳がん_被保険者記号','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901164',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901164.numvalue'',''F01008'',''乳がん_被保険者記号'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901164'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_被保険者番号
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901165.numvalue','F01009','乳がん_被保険者番号','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901165',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901165.numvalue'',''F01009'',''乳がん_被保険者番号'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901165'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_枝番
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901166.numvalue','F01010','乳がん_枝番','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901166',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901166.numvalue'',''F01010'',''乳がん_枝番'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901166'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_過去の実施歴
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901167.numvalue','F01011','乳がん_過去の実施歴','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901167',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901167.numvalue'',''F01011'',''乳がん_過去の実施歴'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901167'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_乳がんに係る症状の有無
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901168.numvalue','F01012','乳がん_乳がんに係る症状の有無','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901168',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901168.numvalue'',''F01012'',''乳がん_乳がんに係る症状の有無'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901168'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_マンモグラフィー検査判定
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901169.numvalue','F01013','乳がん_マンモグラフィー検査判定','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901169',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901169.numvalue'',''F01013'',''乳がん_マンモグラフィー検査判定'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901169'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_マンモグラフィー検査所見
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901170.numvalue','F01014','乳がん_マンモグラフィー検査所見','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901170',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901170.numvalue'',''F01014'',''乳がん_マンモグラフィー検査所見'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901170'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_その他所見
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901171.numvalue','F01015','乳がん_その他所見','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901171',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901171.numvalue'',''F01015'',''乳がん_その他所見'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901171'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_がん検診による偶発症の有無
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901172.numvalue','F01016','乳がん_がん検診による偶発症の有無','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901172',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901172.numvalue'',''F01016'',''乳がん_がん検診による偶発症の有無'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901172'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_マンモグラフィー検査一次読影
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901173.numvalue','F01017','乳がん_マンモグラフィー検査一次読影','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901173',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901173.numvalue'',''F01017'',''乳がん_マンモグラフィー検査一次読影'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901173'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_マンモグラフィー検査二次読影
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901174.numvalue','F01018','乳がん_マンモグラフィー検査二次読影','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901174',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901174.numvalue'',''F01018'',''乳がん_マンモグラフィー検査二次読影'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901174'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_費用徴収情報
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901199.numvalue','F01019','乳がん_費用徴収情報','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901199',NULL,NULL,NULL,'成人保健一次検診','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901199.numvalue'',''F01019'',''乳がん_費用徴収情報'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901199'',NULL,NULL,NULL,''成人保健一次検診'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_実施区分
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901197.numvalue','F01020','乳がん_実施区分','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901197',NULL,NULL,NULL,'成人保健精密検査','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901197.numvalue'',''F01020'',''乳がん_実施区分'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901197'',NULL,NULL,NULL,''成人保健精密検査'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_医療機関コード
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901201.numvalue','F01021','乳がん_医療機関コード','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901201',NULL,NULL,NULL,'成人保健精密検査','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901201.numvalue'',''F01021'',''乳がん_医療機関コード'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901201'',NULL,NULL,NULL,''成人保健精密検査'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_医療機関名
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901202.numvalue','F01022','乳がん_医療機関名','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901202',NULL,NULL,NULL,'成人保健精密検査','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901202.numvalue'',''F01022'',''乳がん_医療機関名'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901202'',NULL,NULL,NULL,''成人保健精密検査'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_判定
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901204.numvalue','F01023','乳がん_判定','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901204',NULL,NULL,NULL,'成人保健精密検査','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901204.numvalue'',''F01023'',''乳がん_判定'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901204'',NULL,NULL,NULL,''成人保健精密検査'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_保険者番号
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901205.numvalue','F01024','乳がん_保険者番号','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901205',NULL,NULL,NULL,'成人保健精密検査','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901205.numvalue'',''F01024'',''乳がん_保険者番号'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901205'',NULL,NULL,NULL,''成人保健精密検査'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_被保険者記号
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901206.numvalue','F01025','乳がん_被保険者記号','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901206',NULL,NULL,NULL,'成人保健精密検査','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901206.numvalue'',''F01025'',''乳がん_被保険者記号'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901206'',NULL,NULL,NULL,''成人保健精密検査'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_被保険者番号
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901207.numvalue','F01026','乳がん_被保険者番号','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901207',NULL,NULL,NULL,'成人保健精密検査','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901207.numvalue'',''F01026'',''乳がん_被保険者番号'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901207'',NULL,NULL,NULL,''成人保健精密検査'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_枝番
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901208.numvalue','F01027','乳がん_枝番','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901208',NULL,NULL,NULL,'成人保健精密検査','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901208.numvalue'',''F01027'',''乳がん_枝番'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901208'',NULL,NULL,NULL,''成人保健精密検査'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_その他所見
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901209.numvalue','F01028','乳がん_その他所見','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901209',NULL,NULL,NULL,'成人保健精密検査','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901209.numvalue'',''F01028'',''乳がん_その他所見'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901209'',NULL,NULL,NULL,''成人保健精密検査'',''フリー項目'');','system','2023-01-01','system','2023-01-01');
--乳がん_がん検診の精密検査による偶発症の有無
INSERT INTO tm_eutableitem VALUES('tm_shfreeitem_090_101901210.numvalue','F01029','乳がん_がん検診の精密検査による偶発症の有無','0',1,1,True,1,NULL,NULL,'tm_shfreeitem_090_101901210',NULL,NULL,NULL,'成人保健精密検査','フリー項目','INSERT INTO tm_eutableitem VALUES(''tm_shfreeitem_090_101901210.numvalue'',''F01029'',''乳がん_がん検診の精密検査による偶発症の有無'',0,1,True,-1,''1'',NULL,NULL,''tm_shfreeitem_090_101901210'',NULL,NULL,NULL,''成人保健精密検査'',''フリー項目'');','system','2023-01-01','system','2023-01-01');