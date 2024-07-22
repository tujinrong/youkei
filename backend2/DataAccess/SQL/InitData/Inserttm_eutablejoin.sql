delete from tm_eutablejoin WHERE 1=1;










































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































--コントロールマスタ - コントロールメインマスタ
INSERT INTO tm_eutablejoin VALUES('tm_afctrl','tm_afctrl_main','tm_afctrl_main.ctrlmaincd=tm_afctrl.ctrlmaincd AND tm_afctrl_main.ctrlsubcd=tm_afctrl.ctrlsubcd',0);
--汎用マスタ - 汎用メインマスタ
INSERT INTO tm_eutablejoin VALUES('tm_afhanyo','tm_afhanyo_main','tm_afhanyo_main.hanyomaincd=tm_afhanyo.hanyomaincd AND tm_afhanyo_main.hanyosubcd=tm_afhanyo.hanyosubcd',0);
--ヘルプドキュメントマスタ - 機能マスタ
INSERT INTO tm_eutablejoin VALUES('tm_afhelpdoc','tm_afkino','tm_afkino.kinoid=tm_afhelpdoc.kinoid',0);
--ヘルプドキュメントマスタ - メニューマスタ
INSERT INTO tm_eutablejoin VALUES('tm_afhelpdoc','tm_afmenu','tm_afmenu.kinoid=tm_afhelpdoc.kinoid',0);
--ヘルプドキュメントマスタ - 共通ドキュメントテーブル
INSERT INTO tm_eutablejoin VALUES('tm_afhelpdoc','tt_afcomdoc','tt_afcomdoc.docseq=tm_afhelpdoc.docseq',0);
--会場情報サブマスタ - 会場情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_afkaijo_sub','tm_afkaijo','tm_afkaijo.kaijocd=tm_afkaijo_sub.kaijocd',0);
--会場情報サブマスタ - 地区情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_afkaijo_sub','tm_aftiku','tm_aftiku.tikukbn=tm_afkaijo_sub.tikukbn AND tm_aftiku.tikucd=tm_afkaijo_sub.tikucd',0);
--医療機関サブマスタ - 医療機関マスタ
INSERT INTO tm_eutablejoin VALUES('tm_afkikan_sub','tm_afkikan','tm_afkikan.kikancd=tm_afkikan_sub.kikancd',0);
--機能マスタ - メニューマスタ
INSERT INTO tm_eutablejoin VALUES('tm_afkino','tm_afmenu','tm_afmenu.kinoid=tm_afkino.kinoid',0);
--名称マスタ - 名称メインマスタ
INSERT INTO tm_eutablejoin VALUES('tm_afmeisyo','tm_afmeisyo_main','tm_afmeisyo_main.nmmaincd=tm_afmeisyo.nmmaincd AND tm_afmeisyo_main.nmsubcd=tm_afmeisyo.nmsubcd',0);
--メニューマスタ - 機能マスタ
INSERT INTO tm_eutablejoin VALUES('tm_afmenu','tm_afkino','tm_afkino.kinoid=tm_afmenu.kinoid',0);
--事業従事者（担当者）所属機関 - 医療機関マスタ
INSERT INTO tm_eutablejoin VALUES('tm_afstaff_kikan','tm_afkikan','tm_afkikan.kikancd=tm_afstaff_kikan.kikancd',0);
--事業従事者（担当者）所属機関 - 事業従事者（担当者）情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_afstaff_kikan','tm_afstaff','tm_afstaff.staffid=tm_afstaff_kikan.staffid',0);
--事業従事者（担当者）サブマスタ - 事業従事者（担当者）情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_afstaff_sub','tm_afstaff','tm_afstaff.staffid=tm_afstaff_sub.staffid',0);
--地区情報サブマスタ - 事業従事者（担当者）情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_aftiku_sub','tm_afstaff','tm_afstaff.staffid=tm_aftiku_sub.staffid',0);
--地区情報サブマスタ - 地区情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_aftiku_sub','tm_aftiku','tm_aftiku.tikukbn=tm_aftiku_sub.tikukbn AND tm_aftiku.tikucd=tm_aftiku_sub.tikucd',0);
--町字マスタ - 市区町村マスタ
INSERT INTO tm_eutablejoin VALUES('tm_aftyoaza','tm_afsikutyoson','tm_afsikutyoson.sikucd=tm_aftyoaza.sikucd',0);
--ユーザーマスタ - 所属グループマスタ
INSERT INTO tm_eutablejoin VALUES('tm_afuser','tm_afsyozoku','tm_afsyozoku.syozokucd=tm_afuser.syozokucd',0);
--宛名テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatena','tt_afjumin','tt_afjumin.atenano=tt_afatena.atenano',0);
--宛名テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatena','tt_afkaigo','tt_afkaigo.atenano=tt_afatena.atenano',0);
--宛名テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatena','tt_afkokihoken','tt_afkokihoken.atenano=tt_afatena.atenano',0);
--宛名テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatena','tt_afkokuho','tt_afkokuho.atenano=tt_afatena.atenano',0);
--宛名テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatena','tt_afseiho','tt_afseiho.atenano=tt_afatena.atenano',0);
--宛名テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatena','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afatena.atenano',0);
--宛名テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatena','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afatena.atenano',0);
--宛名テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatena','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afatena.atenano',0);
--宛名テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatena','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afatena.atenano',0);
--宛名テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatena','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afatena.atenano',0);
--宛名テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatena','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afatena.atenano',0);
--宛名番号検索履歴テーブル - 機能マスタ
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tm_afkino','tm_afkino.kinoid=tt_afatenalog.kinoid',0);
--宛名番号検索履歴テーブル - メニューマスタ
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tm_afmenu','tm_afmenu.kinoid=tt_afatenalog.kinoid',0);
--宛名番号検索履歴テーブル - ユーザーマスタ
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tm_afuser','tm_afuser.userid=tt_afatenalog.userid',0);
--宛名番号検索履歴テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_afatena','tt_afatena.atenano=tt_afatenalog.atenano',0);
--宛名番号検索履歴テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_afjumin','tt_afjumin.atenano=tt_afatenalog.atenano',0);
--宛名番号検索履歴テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_afkaigo','tt_afkaigo.atenano=tt_afatenalog.atenano',0);
--宛名番号検索履歴テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_afkokihoken','tt_afkokihoken.atenano=tt_afatenalog.atenano',0);
--宛名番号検索履歴テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_afkokuho','tt_afkokuho.atenano=tt_afatenalog.atenano',0);
--宛名番号検索履歴テーブル - お気に入りテーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_afokiniiri','tt_afokiniiri.userid=tt_afatenalog.userid AND tt_afokiniiri.kinoid=tt_afatenalog.kinoid',0);
--宛名番号検索履歴テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_afseiho','tt_afseiho.atenano=tt_afatenalog.atenano',0);
--宛名番号検索履歴テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afatenalog.atenano',0);
--宛名番号検索履歴テーブル - 使用履歴テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_afsiyorireki','tt_afsiyorireki.userid=tt_afatenalog.userid AND tt_afsiyorireki.kinoid=tt_afatenalog.kinoid',0);
--宛名番号検索履歴テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afatenalog.atenano',0);
--宛名番号検索履歴テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afatenalog.atenano',0);
--宛名番号検索履歴テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afatenalog.atenano',0);
--宛名番号検索履歴テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afatenalog.atenano',0);
--宛名番号検索履歴テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afatenalog','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afatenalog.atenano',0);
--画面権限テーブル - 機能マスタ
INSERT INTO tm_eutablejoin VALUES('tt_afauthgamen','tm_afkino','tm_afkino.kinoid=tt_afauthgamen.kinoid',0);
--画面権限テーブル - メニューマスタ
INSERT INTO tm_eutablejoin VALUES('tt_afauthgamen','tm_afmenu','tm_afmenu.kinoid=tt_afauthgamen.kinoid',0);
--バッチログテーブル - メインログテーブル
INSERT INTO tm_eutablejoin VALUES('tt_afbatchlog','tt_aflog','tt_aflog.sessionseq=tt_afbatchlog.sessionseq',0);
--共通ドキュメントテーブル - ヘルプドキュメントマスタ
INSERT INTO tm_eutablejoin VALUES('tt_afcomdoc','tm_afhelpdoc','tm_afhelpdoc.docseq=tt_afcomdoc.docseq',0);
--共通ドキュメントテーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_afcomdoc','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_afcomdoc.jigyocd',0);
--共通ドキュメントテーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_afcomdoc','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_afcomdoc.jigyocd',0);
--詳細条件設定テーブル - 機能マスタ
INSERT INTO tm_eutablejoin VALUES('tt_affilter','tm_afkino','tm_afkino.kinoid=tt_affilter.kinoid',0);
--詳細条件設定テーブル - メニューマスタ
INSERT INTO tm_eutablejoin VALUES('tt_affilter','tm_afmenu','tm_afmenu.kinoid=tt_affilter.kinoid',0);
--外部連携処理結果履歴テーブル - メインログテーブル
INSERT INTO tm_eutablejoin VALUES('tt_afgaibulog','tt_aflog','tt_aflog.sessionseq=tt_afgaibulog.sessionseq',0);
--お知らせ確認状態テーブル - ユーザーマスタ
INSERT INTO tm_eutablejoin VALUES('tt_afinfo_user','tm_afuser','tm_afuser.userid=tt_afinfo_user.userid',0);
--お知らせ確認状態テーブル - お知らせテーブル
INSERT INTO tm_eutablejoin VALUES('tt_afinfo_user','tt_afinfo','tt_afinfo.infoseq=tt_afinfo_user.infoseq',0);
--【住民基本台帳】住民情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin','tt_afatena','tt_afatena.atenano=tt_afjumin.atenano',0);
--【住民基本台帳】住民情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin','tt_afkaigo','tt_afkaigo.atenano=tt_afjumin.atenano',0);
--【住民基本台帳】住民情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin','tt_afkokihoken','tt_afkokihoken.atenano=tt_afjumin.atenano',0);
--【住民基本台帳】住民情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin','tt_afkokuho','tt_afkokuho.atenano=tt_afjumin.atenano',0);
--【住民基本台帳】住民情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin','tt_afseiho','tt_afseiho.atenano=tt_afjumin.atenano',0);
--【住民基本台帳】住民情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afjumin.atenano',0);
--【住民基本台帳】住民情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afjumin.atenano',0);
--【住民基本台帳】住民情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afjumin.atenano',0);
--【住民基本台帳】住民情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afjumin.atenano',0);
--【住民基本台帳】住民情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afjumin.atenano',0);
--【住民基本台帳】住民情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afjumin.atenano',0);
--【住民基本台帳】住民情報履歴テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin_reki','tt_afatena','tt_afatena.atenano=tt_afjumin_reki.atenano',0);
--【住民基本台帳】住民情報履歴テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin_reki','tt_afjumin','tt_afjumin.atenano=tt_afjumin_reki.atenano',0);
--【住民基本台帳】住民情報履歴テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin_reki','tt_afkaigo','tt_afkaigo.atenano=tt_afjumin_reki.atenano',0);
--【住民基本台帳】住民情報履歴テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin_reki','tt_afkokihoken','tt_afkokihoken.atenano=tt_afjumin_reki.atenano',0);
--【住民基本台帳】住民情報履歴テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin_reki','tt_afkokuho','tt_afkokuho.atenano=tt_afjumin_reki.atenano',0);
--【住民基本台帳】住民情報履歴テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin_reki','tt_afseiho','tt_afseiho.atenano=tt_afjumin_reki.atenano',0);
--【住民基本台帳】住民情報履歴テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin_reki','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afjumin_reki.atenano',0);
--【住民基本台帳】住民情報履歴テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin_reki','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afjumin_reki.atenano',0);
--【住民基本台帳】住民情報履歴テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin_reki','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afjumin_reki.atenano',0);
--【住民基本台帳】住民情報履歴テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin_reki','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afjumin_reki.atenano',0);
--【住民基本台帳】住民情報履歴テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin_reki','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afjumin_reki.atenano',0);
--【住民基本台帳】住民情報履歴テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjumin_reki','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afjumin_reki.atenano',0);
--住登外者情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_afatena','tt_afatena.atenano=tt_afjutogai.atenano',0);
--住登外者情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_afjumin','tt_afjumin.atenano=tt_afjutogai.atenano',0);
--住登外者情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_afkaigo','tt_afkaigo.atenano=tt_afjutogai.atenano',0);
--住登外者情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_afkokihoken','tt_afkokihoken.atenano=tt_afjutogai.atenano',0);
--住登外者情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_afkokuho','tt_afkokuho.atenano=tt_afjutogai.atenano',0);
--住登外者情報テーブル - 個人番号管理テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_afpersonalno','tt_afpersonalno.atenano=tt_afjutogai.atenano AND tt_afpersonalno.rirekino=tt_afjutogai.rirekino',0);
--住登外者情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_afseiho','tt_afseiho.atenano=tt_afjutogai.atenano',0);
--住登外者情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afjutogai.atenano',0);
--住登外者情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afjutogai.atenano',0);
--住登外者情報テーブル - 【障害者福祉】身体障害者手帳等情報履歴テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_afsyogaitetyo_reki','tt_afsyogaitetyo_reki.atenano=tt_afjutogai.atenano AND tt_afsyogaitetyo_reki.rirekino=tt_afjutogai.rirekino',0);
--住登外者情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afjutogai.atenano',0);
--住登外者情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afjutogai.atenano',0);
--住登外者情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afjutogai.atenano',0);
--住登外者情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afjutogai.atenano',0);
--住登外者独自施策システム等情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_afatena','tt_afatena.atenano=tt_afjutogai_dokujisystem.atenano',0);
--住登外者独自施策システム等情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_afjumin','tt_afjumin.atenano=tt_afjutogai_dokujisystem.atenano',0);
--住登外者独自施策システム等情報テーブル - 住登外者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_afjutogai','tt_afjutogai.atenano=tt_afjutogai_dokujisystem.atenano AND tt_afjutogai.rirekino=tt_afjutogai_dokujisystem.rirekino',0);
--住登外者独自施策システム等情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_afkaigo','tt_afkaigo.atenano=tt_afjutogai_dokujisystem.atenano',0);
--住登外者独自施策システム等情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_afkokihoken','tt_afkokihoken.atenano=tt_afjutogai_dokujisystem.atenano',0);
--住登外者独自施策システム等情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_afkokuho','tt_afkokuho.atenano=tt_afjutogai_dokujisystem.atenano',0);
--住登外者独自施策システム等情報テーブル - 個人番号管理テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_afpersonalno','tt_afpersonalno.atenano=tt_afjutogai_dokujisystem.atenano AND tt_afpersonalno.rirekino=tt_afjutogai_dokujisystem.rirekino',0);
--住登外者独自施策システム等情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_afseiho','tt_afseiho.atenano=tt_afjutogai_dokujisystem.atenano',0);
--住登外者独自施策システム等情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afjutogai_dokujisystem.atenano',0);
--住登外者独自施策システム等情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afjutogai_dokujisystem.atenano',0);
--住登外者独自施策システム等情報テーブル - 【障害者福祉】身体障害者手帳等情報履歴テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_afsyogaitetyo_reki','tt_afsyogaitetyo_reki.atenano=tt_afjutogai_dokujisystem.atenano AND tt_afsyogaitetyo_reki.rirekino=tt_afjutogai_dokujisystem.rirekino',0);
--住登外者独自施策システム等情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afjutogai_dokujisystem.atenano',0);
--住登外者独自施策システム等情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afjutogai_dokujisystem.atenano',0);
--住登外者独自施策システム等情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afjutogai_dokujisystem.atenano',0);
--住登外者独自施策システム等情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_dokujisystem','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afjutogai_dokujisystem.atenano',0);
--住登外者参照業務情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_afatena','tt_afatena.atenano=tt_afjutogai_gyomu.atenano',0);
--住登外者参照業務情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_afjumin','tt_afjumin.atenano=tt_afjutogai_gyomu.atenano',0);
--住登外者参照業務情報テーブル - 住登外者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_afjutogai','tt_afjutogai.atenano=tt_afjutogai_gyomu.atenano AND tt_afjutogai.rirekino=tt_afjutogai_gyomu.rirekino',0);
--住登外者参照業務情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_afkaigo','tt_afkaigo.atenano=tt_afjutogai_gyomu.atenano',0);
--住登外者参照業務情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_afkokihoken','tt_afkokihoken.atenano=tt_afjutogai_gyomu.atenano',0);
--住登外者参照業務情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_afkokuho','tt_afkokuho.atenano=tt_afjutogai_gyomu.atenano',0);
--住登外者参照業務情報テーブル - 個人番号管理テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_afpersonalno','tt_afpersonalno.atenano=tt_afjutogai_gyomu.atenano AND tt_afpersonalno.rirekino=tt_afjutogai_gyomu.rirekino',0);
--住登外者参照業務情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_afseiho','tt_afseiho.atenano=tt_afjutogai_gyomu.atenano',0);
--住登外者参照業務情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afjutogai_gyomu.atenano',0);
--住登外者参照業務情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afjutogai_gyomu.atenano',0);
--住登外者参照業務情報テーブル - 【障害者福祉】身体障害者手帳等情報履歴テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_afsyogaitetyo_reki','tt_afsyogaitetyo_reki.atenano=tt_afjutogai_gyomu.atenano AND tt_afsyogaitetyo_reki.rirekino=tt_afjutogai_gyomu.rirekino',0);
--住登外者参照業務情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afjutogai_gyomu.atenano',0);
--住登外者参照業務情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afjutogai_gyomu.atenano',0);
--住登外者参照業務情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afjutogai_gyomu.atenano',0);
--住登外者参照業務情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afjutogai_gyomu','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afjutogai_gyomu.atenano',0);
--【介護保険】被保険者情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo','tt_afatena','tt_afatena.atenano=tt_afkaigo.atenano',0);
--【介護保険】被保険者情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo','tt_afjumin','tt_afjumin.atenano=tt_afkaigo.atenano',0);
--【介護保険】被保険者情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo','tt_afkokihoken','tt_afkokihoken.atenano=tt_afkaigo.atenano',0);
--【介護保険】被保険者情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo','tt_afkokuho','tt_afkokuho.atenano=tt_afkaigo.atenano',0);
--【介護保険】被保険者情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo','tt_afseiho','tt_afseiho.atenano=tt_afkaigo.atenano',0);
--【介護保険】被保険者情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afkaigo.atenano',0);
--【介護保険】被保険者情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afkaigo.atenano',0);
--【介護保険】被保険者情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afkaigo.atenano',0);
--【介護保険】被保険者情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afkaigo.atenano',0);
--【介護保険】被保険者情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afkaigo.atenano',0);
--【介護保険】被保険者情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afkaigo.atenano',0);
--【介護保険】被保険者情報履歴テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo_reki','tt_afatena','tt_afatena.atenano=tt_afkaigo_reki.atenano',0);
--【介護保険】被保険者情報履歴テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo_reki','tt_afjumin','tt_afjumin.atenano=tt_afkaigo_reki.atenano',0);
--【介護保険】被保険者情報履歴テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo_reki','tt_afkaigo','tt_afkaigo.atenano=tt_afkaigo_reki.atenano',0);
--【介護保険】被保険者情報履歴テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo_reki','tt_afkokihoken','tt_afkokihoken.atenano=tt_afkaigo_reki.atenano',0);
--【介護保険】被保険者情報履歴テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo_reki','tt_afkokuho','tt_afkokuho.atenano=tt_afkaigo_reki.atenano',0);
--【介護保険】被保険者情報履歴テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo_reki','tt_afseiho','tt_afseiho.atenano=tt_afkaigo_reki.atenano',0);
--【介護保険】被保険者情報履歴テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo_reki','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afkaigo_reki.atenano',0);
--【介護保険】被保険者情報履歴テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo_reki','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afkaigo_reki.atenano',0);
--【介護保険】被保険者情報履歴テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo_reki','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afkaigo_reki.atenano',0);
--【介護保険】被保険者情報履歴テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo_reki','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afkaigo_reki.atenano',0);
--【介護保険】被保険者情報履歴テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo_reki','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afkaigo_reki.atenano',0);
--【介護保険】被保険者情報履歴テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkaigo_reki','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afkaigo_reki.atenano',0);
--個人ドキュメントテーブル - ヘルプドキュメントマスタ
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tm_afhelpdoc','tm_afhelpdoc.docseq=tt_afkojindoc.docseq',0);
--個人ドキュメントテーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tt_afatena','tt_afatena.atenano=tt_afkojindoc.atenano',0);
--個人ドキュメントテーブル - 共通ドキュメントテーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tt_afcomdoc','tt_afcomdoc.docseq=tt_afkojindoc.docseq',0);
--個人ドキュメントテーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tt_afjumin','tt_afjumin.atenano=tt_afkojindoc.atenano',0);
--個人ドキュメントテーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tt_afkaigo','tt_afkaigo.atenano=tt_afkojindoc.atenano',0);
--個人ドキュメントテーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tt_afkokihoken','tt_afkokihoken.atenano=tt_afkojindoc.atenano',0);
--個人ドキュメントテーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tt_afkokuho','tt_afkokuho.atenano=tt_afkojindoc.atenano',0);
--個人ドキュメントテーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tt_afseiho','tt_afseiho.atenano=tt_afkojindoc.atenano',0);
--個人ドキュメントテーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afkojindoc.atenano',0);
--個人ドキュメントテーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afkojindoc.atenano',0);
--個人ドキュメントテーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_afkojindoc.jigyocd',0);
--個人ドキュメントテーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_afkojindoc.jigyocd',0);
--個人ドキュメントテーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afkojindoc.atenano',0);
--個人ドキュメントテーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afkojindoc.atenano',0);
--個人ドキュメントテーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afkojindoc.atenano',0);
--個人ドキュメントテーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojindoc','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afkojindoc.atenano',0);
--【個人住民税】納税義務者情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya','tt_afatena','tt_afatena.atenano=tt_afkojinzeigimusya.atenano',0);
--【個人住民税】納税義務者情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya','tt_afjumin','tt_afjumin.atenano=tt_afkojinzeigimusya.atenano',0);
--【個人住民税】納税義務者情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya','tt_afkaigo','tt_afkaigo.atenano=tt_afkojinzeigimusya.atenano',0);
--【個人住民税】納税義務者情報テーブル - 【個人住民税】個人住民税課税情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya','tt_afkojinzeikazei','tt_afkojinzeikazei.atenano=tt_afkojinzeigimusya.atenano AND tt_afkojinzeikazei.kazeinendo=tt_afkojinzeigimusya.kazeinendo',0);
--【個人住民税】納税義務者情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya','tt_afkokihoken','tt_afkokihoken.atenano=tt_afkojinzeigimusya.atenano',0);
--【個人住民税】納税義務者情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya','tt_afkokuho','tt_afkokuho.atenano=tt_afkojinzeigimusya.atenano',0);
--【個人住民税】納税義務者情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya','tt_afseiho','tt_afseiho.atenano=tt_afkojinzeigimusya.atenano',0);
--【個人住民税】納税義務者情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afkojinzeigimusya.atenano',0);
--【個人住民税】納税義務者情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afkojinzeigimusya.atenano',0);
--【個人住民税】納税義務者情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afkojinzeigimusya.atenano',0);
--【個人住民税】納税義務者情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afkojinzeigimusya.atenano',0);
--【個人住民税】納税義務者情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afkojinzeigimusya.atenano',0);
--【個人住民税】納税義務者情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afkojinzeigimusya.atenano',0);
--【個人住民税】納税義務者情報履歴テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_afatena','tt_afatena.atenano=tt_afkojinzeigimusya_reki.atenano',0);
--【個人住民税】納税義務者情報履歴テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_afjumin','tt_afjumin.atenano=tt_afkojinzeigimusya_reki.atenano',0);
--【個人住民税】納税義務者情報履歴テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_afkaigo','tt_afkaigo.atenano=tt_afkojinzeigimusya_reki.atenano',0);
--【個人住民税】納税義務者情報履歴テーブル - 【個人住民税】納税義務者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_afkojinzeigimusya','tt_afkojinzeigimusya.atenano=tt_afkojinzeigimusya_reki.atenano AND tt_afkojinzeigimusya.kazeinendo=tt_afkojinzeigimusya_reki.kazeinendo',0);
--【個人住民税】納税義務者情報履歴テーブル - 【個人住民税】個人住民税課税情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_afkojinzeikazei','tt_afkojinzeikazei.atenano=tt_afkojinzeigimusya_reki.atenano AND tt_afkojinzeikazei.kazeinendo=tt_afkojinzeigimusya_reki.kazeinendo',0);
--【個人住民税】納税義務者情報履歴テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_afkokihoken','tt_afkokihoken.atenano=tt_afkojinzeigimusya_reki.atenano',0);
--【個人住民税】納税義務者情報履歴テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_afkokuho','tt_afkokuho.atenano=tt_afkojinzeigimusya_reki.atenano',0);
--【個人住民税】納税義務者情報履歴テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_afseiho','tt_afseiho.atenano=tt_afkojinzeigimusya_reki.atenano',0);
--【個人住民税】納税義務者情報履歴テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afkojinzeigimusya_reki.atenano',0);
--【個人住民税】納税義務者情報履歴テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afkojinzeigimusya_reki.atenano',0);
--【個人住民税】納税義務者情報履歴テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afkojinzeigimusya_reki.atenano',0);
--【個人住民税】納税義務者情報履歴テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afkojinzeigimusya_reki.atenano',0);
--【個人住民税】納税義務者情報履歴テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afkojinzeigimusya_reki.atenano',0);
--【個人住民税】納税義務者情報履歴テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeigimusya_reki','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afkojinzeigimusya_reki.atenano',0);
--【個人住民税】個人住民税課税情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei','tt_afatena','tt_afatena.atenano=tt_afkojinzeikazei.atenano',0);
--【個人住民税】個人住民税課税情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei','tt_afjumin','tt_afjumin.atenano=tt_afkojinzeikazei.atenano',0);
--【個人住民税】個人住民税課税情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei','tt_afkaigo','tt_afkaigo.atenano=tt_afkojinzeikazei.atenano',0);
--【個人住民税】個人住民税課税情報テーブル - 【個人住民税】納税義務者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei','tt_afkojinzeigimusya','tt_afkojinzeigimusya.atenano=tt_afkojinzeikazei.atenano AND tt_afkojinzeigimusya.kazeinendo=tt_afkojinzeikazei.kazeinendo',0);
--【個人住民税】個人住民税課税情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei','tt_afkokihoken','tt_afkokihoken.atenano=tt_afkojinzeikazei.atenano',0);
--【個人住民税】個人住民税課税情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei','tt_afkokuho','tt_afkokuho.atenano=tt_afkojinzeikazei.atenano',0);
--【個人住民税】個人住民税課税情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei','tt_afseiho','tt_afseiho.atenano=tt_afkojinzeikazei.atenano',0);
--【個人住民税】個人住民税課税情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afkojinzeikazei.atenano',0);
--【個人住民税】個人住民税課税情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afkojinzeikazei.atenano',0);
--【個人住民税】個人住民税課税情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afkojinzeikazei.atenano',0);
--【個人住民税】個人住民税課税情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afkojinzeikazei.atenano',0);
--【個人住民税】個人住民税課税情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afkojinzeikazei.atenano',0);
--【個人住民税】個人住民税課税情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afkojinzeikazei.atenano',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_afatena','tt_afatena.atenano=tt_afkojinzeikazei_reki.atenano',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_afjumin','tt_afjumin.atenano=tt_afkojinzeikazei_reki.atenano',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_afkaigo','tt_afkaigo.atenano=tt_afkojinzeikazei_reki.atenano',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 【個人住民税】納税義務者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_afkojinzeigimusya','tt_afkojinzeigimusya.atenano=tt_afkojinzeikazei_reki.atenano AND tt_afkojinzeigimusya.kazeinendo=tt_afkojinzeikazei_reki.kazeinendo',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 【個人住民税】個人住民税課税情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_afkojinzeikazei','tt_afkojinzeikazei.atenano=tt_afkojinzeikazei_reki.atenano AND tt_afkojinzeikazei.kazeinendo=tt_afkojinzeikazei_reki.kazeinendo',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_afkokihoken','tt_afkokihoken.atenano=tt_afkojinzeikazei_reki.atenano',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_afkokuho','tt_afkokuho.atenano=tt_afkojinzeikazei_reki.atenano',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_afseiho','tt_afseiho.atenano=tt_afkojinzeikazei_reki.atenano',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afkojinzeikazei_reki.atenano',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afkojinzeikazei_reki.atenano',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afkojinzeikazei_reki.atenano',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afkojinzeikazei_reki.atenano',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afkojinzeikazei_reki.atenano',0);
--【個人住民税】個人住民税課税情報履歴テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikazei_reki','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afkojinzeikazei_reki.atenano',0);
--【個人住民税】個人住民税税額控除情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_afatena','tt_afatena.atenano=tt_afkojinzeikojo.atenano',0);
--【個人住民税】個人住民税税額控除情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_afjumin','tt_afjumin.atenano=tt_afkojinzeikojo.atenano',0);
--【個人住民税】個人住民税税額控除情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_afkaigo','tt_afkaigo.atenano=tt_afkojinzeikojo.atenano',0);
--【個人住民税】個人住民税税額控除情報テーブル - 【個人住民税】納税義務者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_afkojinzeigimusya','tt_afkojinzeigimusya.atenano=tt_afkojinzeikojo.atenano AND tt_afkojinzeigimusya.kazeinendo=tt_afkojinzeikojo.kazeinendo',0);
--【個人住民税】個人住民税税額控除情報テーブル - 【個人住民税】個人住民税課税情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_afkojinzeikazei','tt_afkojinzeikazei.atenano=tt_afkojinzeikojo.atenano AND tt_afkojinzeikazei.kazeinendo=tt_afkojinzeikojo.kazeinendo',0);
--【個人住民税】個人住民税税額控除情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_afkokihoken','tt_afkokihoken.atenano=tt_afkojinzeikojo.atenano',0);
--【個人住民税】個人住民税税額控除情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_afkokuho','tt_afkokuho.atenano=tt_afkojinzeikojo.atenano',0);
--【個人住民税】個人住民税税額控除情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_afseiho','tt_afseiho.atenano=tt_afkojinzeikojo.atenano',0);
--【個人住民税】個人住民税税額控除情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afkojinzeikojo.atenano',0);
--【個人住民税】個人住民税税額控除情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afkojinzeikojo.atenano',0);
--【個人住民税】個人住民税税額控除情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afkojinzeikojo.atenano',0);
--【個人住民税】個人住民税税額控除情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afkojinzeikojo.atenano',0);
--【個人住民税】個人住民税税額控除情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afkojinzeikojo.atenano',0);
--【個人住民税】個人住民税税額控除情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afkojinzeikojo.atenano',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_afatena','tt_afatena.atenano=tt_afkojinzeikojo_reki.atenano',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_afjumin','tt_afjumin.atenano=tt_afkojinzeikojo_reki.atenano',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_afkaigo','tt_afkaigo.atenano=tt_afkojinzeikojo_reki.atenano',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 【個人住民税】納税義務者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_afkojinzeigimusya','tt_afkojinzeigimusya.atenano=tt_afkojinzeikojo_reki.atenano AND tt_afkojinzeigimusya.kazeinendo=tt_afkojinzeikojo_reki.kazeinendo',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 【個人住民税】個人住民税課税情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_afkojinzeikazei','tt_afkojinzeikazei.atenano=tt_afkojinzeikojo_reki.atenano AND tt_afkojinzeikazei.kazeinendo=tt_afkojinzeikojo_reki.kazeinendo',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_afkokihoken','tt_afkokihoken.atenano=tt_afkojinzeikojo_reki.atenano',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_afkokuho','tt_afkokuho.atenano=tt_afkojinzeikojo_reki.atenano',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_afseiho','tt_afseiho.atenano=tt_afkojinzeikojo_reki.atenano',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afkojinzeikojo_reki.atenano',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afkojinzeikojo_reki.atenano',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afkojinzeikojo_reki.atenano',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afkojinzeikojo_reki.atenano',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afkojinzeikojo_reki.atenano',0);
--【個人住民税】個人住民税税額控除情報履歴テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkojinzeikojo_reki','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afkojinzeikojo_reki.atenano',0);
--【後期高齢者医療】被保険者情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken','tt_afatena','tt_afatena.atenano=tt_afkokihoken.atenano',0);
--【後期高齢者医療】被保険者情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken','tt_afjumin','tt_afjumin.atenano=tt_afkokihoken.atenano',0);
--【後期高齢者医療】被保険者情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken','tt_afkaigo','tt_afkaigo.atenano=tt_afkokihoken.atenano',0);
--【後期高齢者医療】被保険者情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken','tt_afkokuho','tt_afkokuho.atenano=tt_afkokihoken.atenano',0);
--【後期高齢者医療】被保険者情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken','tt_afseiho','tt_afseiho.atenano=tt_afkokihoken.atenano',0);
--【後期高齢者医療】被保険者情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afkokihoken.atenano',0);
--【後期高齢者医療】被保険者情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afkokihoken.atenano',0);
--【後期高齢者医療】被保険者情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afkokihoken.atenano',0);
--【後期高齢者医療】被保険者情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afkokihoken.atenano',0);
--【後期高齢者医療】被保険者情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afkokihoken.atenano',0);
--【後期高齢者医療】被保険者情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afkokihoken.atenano',0);
--【後期高齢者医療】被保険者情報履歴テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken_reki','tt_afatena','tt_afatena.atenano=tt_afkokihoken_reki.atenano',0);
--【後期高齢者医療】被保険者情報履歴テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken_reki','tt_afjumin','tt_afjumin.atenano=tt_afkokihoken_reki.atenano',0);
--【後期高齢者医療】被保険者情報履歴テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken_reki','tt_afkaigo','tt_afkaigo.atenano=tt_afkokihoken_reki.atenano',0);
--【後期高齢者医療】被保険者情報履歴テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken_reki','tt_afkokihoken','tt_afkokihoken.atenano=tt_afkokihoken_reki.atenano',0);
--【後期高齢者医療】被保険者情報履歴テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken_reki','tt_afkokuho','tt_afkokuho.atenano=tt_afkokihoken_reki.atenano',0);
--【後期高齢者医療】被保険者情報履歴テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken_reki','tt_afseiho','tt_afseiho.atenano=tt_afkokihoken_reki.atenano',0);
--【後期高齢者医療】被保険者情報履歴テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken_reki','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afkokihoken_reki.atenano',0);
--【後期高齢者医療】被保険者情報履歴テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken_reki','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afkokihoken_reki.atenano',0);
--【後期高齢者医療】被保険者情報履歴テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken_reki','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afkokihoken_reki.atenano',0);
--【後期高齢者医療】被保険者情報履歴テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken_reki','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afkokihoken_reki.atenano',0);
--【後期高齢者医療】被保険者情報履歴テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken_reki','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afkokihoken_reki.atenano',0);
--【後期高齢者医療】被保険者情報履歴テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokihoken_reki','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afkokihoken_reki.atenano',0);
--【国民健康保険】国保資格情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho','tt_afatena','tt_afatena.atenano=tt_afkokuho.atenano',0);
--【国民健康保険】国保資格情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho','tt_afjumin','tt_afjumin.atenano=tt_afkokuho.atenano',0);
--【国民健康保険】国保資格情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho','tt_afkaigo','tt_afkaigo.atenano=tt_afkokuho.atenano',0);
--【国民健康保険】国保資格情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho','tt_afkokihoken','tt_afkokihoken.atenano=tt_afkokuho.atenano',0);
--【国民健康保険】国保資格情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho','tt_afseiho','tt_afseiho.atenano=tt_afkokuho.atenano',0);
--【国民健康保険】国保資格情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afkokuho.atenano',0);
--【国民健康保険】国保資格情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afkokuho.atenano',0);
--【国民健康保険】国保資格情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afkokuho.atenano',0);
--【国民健康保険】国保資格情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afkokuho.atenano',0);
--【国民健康保険】国保資格情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afkokuho.atenano',0);
--【国民健康保険】国保資格情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afkokuho.atenano',0);
--【国民健康保険】国保資格情報履歴テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho_reki','tt_afatena','tt_afatena.atenano=tt_afkokuho_reki.atenano',0);
--【国民健康保険】国保資格情報履歴テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho_reki','tt_afjumin','tt_afjumin.atenano=tt_afkokuho_reki.atenano',0);
--【国民健康保険】国保資格情報履歴テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho_reki','tt_afkaigo','tt_afkaigo.atenano=tt_afkokuho_reki.atenano',0);
--【国民健康保険】国保資格情報履歴テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho_reki','tt_afkokihoken','tt_afkokihoken.atenano=tt_afkokuho_reki.atenano',0);
--【国民健康保険】国保資格情報履歴テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho_reki','tt_afkokuho','tt_afkokuho.atenano=tt_afkokuho_reki.atenano',0);
--【国民健康保険】国保資格情報履歴テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho_reki','tt_afseiho','tt_afseiho.atenano=tt_afkokuho_reki.atenano',0);
--【国民健康保険】国保資格情報履歴テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho_reki','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afkokuho_reki.atenano',0);
--【国民健康保険】国保資格情報履歴テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho_reki','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afkokuho_reki.atenano',0);
--【国民健康保険】国保資格情報履歴テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho_reki','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afkokuho_reki.atenano',0);
--【国民健康保険】国保資格情報履歴テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho_reki','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afkokuho_reki.atenano',0);
--【国民健康保険】国保資格情報履歴テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho_reki','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afkokuho_reki.atenano',0);
--【国民健康保険】国保資格情報履歴テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afkokuho_reki','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afkokuho_reki.atenano',0);
--メインログテーブル - 機能マスタ
INSERT INTO tm_eutablejoin VALUES('tt_aflog','tm_afkino','tm_afkino.kinoid=tt_aflog.kinoid',0);
--メインログテーブル - メニューマスタ
INSERT INTO tm_eutablejoin VALUES('tt_aflog','tm_afmenu','tm_afmenu.kinoid=tt_aflog.kinoid',0);
--宛名番号ログテーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogatena','tt_afatena','tt_afatena.atenano=tt_aflogatena.atenano',0);
--宛名番号ログテーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogatena','tt_afjumin','tt_afjumin.atenano=tt_aflogatena.atenano',0);
--宛名番号ログテーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogatena','tt_afkaigo','tt_afkaigo.atenano=tt_aflogatena.atenano',0);
--宛名番号ログテーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogatena','tt_afkokihoken','tt_afkokihoken.atenano=tt_aflogatena.atenano',0);
--宛名番号ログテーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogatena','tt_afkokuho','tt_afkokuho.atenano=tt_aflogatena.atenano',0);
--宛名番号ログテーブル - メインログテーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogatena','tt_aflog','tt_aflog.sessionseq=tt_aflogatena.sessionseq',0);
--宛名番号ログテーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogatena','tt_afseiho','tt_afseiho.atenano=tt_aflogatena.atenano',0);
--宛名番号ログテーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogatena','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_aflogatena.atenano',0);
--宛名番号ログテーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogatena','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_aflogatena.atenano',0);
--宛名番号ログテーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogatena','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_aflogatena.atenano',0);
--宛名番号ログテーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogatena','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_aflogatena.atenano',0);
--宛名番号ログテーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogatena','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_aflogatena.atenano',0);
--宛名番号ログテーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogatena','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_aflogatena.atenano',0);
--テーブル項目値変更ログテーブル - メインログテーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogcolumn','tt_aflog','tt_aflog.sessionseq=tt_aflogcolumn.sessionseq',0);
--テーブル項目値変更ログテーブル - 一括取込入力テーブルマスタ
INSERT INTO tm_eutablejoin VALUES('tt_aflogcolumn','tm_kktorinyuryoku_table','tm_kktorinyuryoku_table.tablenm=tt_aflogcolumn.tablenm',0);
--DB操作ログテーブル - メインログテーブル
INSERT INTO tm_eutablejoin VALUES('tt_aflogdb','tt_aflog','tt_aflog.sessionseq=tt_aflogdb.sessionseq',0);
--メモテーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afmemo','tt_afatena','tt_afatena.atenano=tt_afmemo.atenano',0);
--メモテーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afmemo','tt_afjumin','tt_afjumin.atenano=tt_afmemo.atenano',0);
--メモテーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afmemo','tt_afkaigo','tt_afkaigo.atenano=tt_afmemo.atenano',0);
--メモテーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afmemo','tt_afkokihoken','tt_afkokihoken.atenano=tt_afmemo.atenano',0);
--メモテーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afmemo','tt_afkokuho','tt_afkokuho.atenano=tt_afmemo.atenano',0);
--メモテーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afmemo','tt_afseiho','tt_afseiho.atenano=tt_afmemo.atenano',0);
--メモテーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afmemo','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afmemo.atenano',0);
--メモテーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afmemo','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afmemo.atenano',0);
--メモテーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afmemo','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afmemo.atenano',0);
--メモテーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afmemo','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afmemo.atenano',0);
--メモテーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afmemo','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afmemo.atenano',0);
--メモテーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afmemo','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afmemo.atenano',0);
--お気に入りテーブル - 機能マスタ
INSERT INTO tm_eutablejoin VALUES('tt_afokiniiri','tm_afkino','tm_afkino.kinoid=tt_afokiniiri.kinoid',0);
--お気に入りテーブル - メニューマスタ
INSERT INTO tm_eutablejoin VALUES('tt_afokiniiri','tm_afmenu','tm_afmenu.kinoid=tt_afokiniiri.kinoid',0);
--お気に入りテーブル - ユーザーマスタ
INSERT INTO tm_eutablejoin VALUES('tt_afokiniiri','tm_afuser','tm_afuser.userid=tt_afokiniiri.userid',0);
--お気に入りテーブル - 使用履歴テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afokiniiri','tt_afsiyorireki','tt_afsiyorireki.userid=tt_afokiniiri.userid AND tt_afsiyorireki.kinoid=tt_afokiniiri.kinoid',0);
--個人番号管理テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_afatena','tt_afatena.atenano=tt_afpersonalno.atenano',0);
--個人番号管理テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_afjumin','tt_afjumin.atenano=tt_afpersonalno.atenano',0);
--個人番号管理テーブル - 住登外者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_afjutogai','tt_afjutogai.atenano=tt_afpersonalno.atenano AND tt_afjutogai.rirekino=tt_afpersonalno.rirekino',0);
--個人番号管理テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_afkaigo','tt_afkaigo.atenano=tt_afpersonalno.atenano',0);
--個人番号管理テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_afkokihoken','tt_afkokihoken.atenano=tt_afpersonalno.atenano',0);
--個人番号管理テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_afkokuho','tt_afkokuho.atenano=tt_afpersonalno.atenano',0);
--個人番号管理テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_afseiho','tt_afseiho.atenano=tt_afpersonalno.atenano',0);
--個人番号管理テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afpersonalno.atenano',0);
--個人番号管理テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afpersonalno.atenano',0);
--個人番号管理テーブル - 【障害者福祉】身体障害者手帳等情報履歴テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_afsyogaitetyo_reki','tt_afsyogaitetyo_reki.atenano=tt_afpersonalno.atenano AND tt_afsyogaitetyo_reki.rirekino=tt_afpersonalno.rirekino',0);
--個人番号管理テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afpersonalno.atenano',0);
--個人番号管理テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afpersonalno.atenano',0);
--個人番号管理テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afpersonalno.atenano',0);
--個人番号管理テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afpersonalno','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afpersonalno.atenano',0);
--連絡先テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tt_afatena','tt_afatena.atenano=tt_afrenrakusaki.atenano',0);
--連絡先テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tt_afjumin','tt_afjumin.atenano=tt_afrenrakusaki.atenano',0);
--連絡先テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tt_afkaigo','tt_afkaigo.atenano=tt_afrenrakusaki.atenano',0);
--連絡先テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tt_afkokihoken','tt_afkokihoken.atenano=tt_afrenrakusaki.atenano',0);
--連絡先テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tt_afkokuho','tt_afkokuho.atenano=tt_afrenrakusaki.atenano',0);
--連絡先テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tt_afseiho','tt_afseiho.atenano=tt_afrenrakusaki.atenano',0);
--連絡先テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afrenrakusaki.atenano',0);
--連絡先テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afrenrakusaki.atenano',0);
--連絡先テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_afrenrakusaki.jigyocd',0);
--連絡先テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_afrenrakusaki.jigyocd',0);
--連絡先テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afrenrakusaki.atenano',0);
--連絡先テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afrenrakusaki.atenano',0);
--連絡先テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afrenrakusaki.atenano',0);
--連絡先テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afrenrakusaki','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afrenrakusaki.atenano',0);
--【生活保護】生活保護受給情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho','tt_afatena','tt_afatena.atenano=tt_afseiho.atenano',0);
--【生活保護】生活保護受給情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho','tt_afjumin','tt_afjumin.atenano=tt_afseiho.atenano',0);
--【生活保護】生活保護受給情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho','tt_afkaigo','tt_afkaigo.atenano=tt_afseiho.atenano',0);
--【生活保護】生活保護受給情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho','tt_afkokihoken','tt_afkokihoken.atenano=tt_afseiho.atenano',0);
--【生活保護】生活保護受給情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho','tt_afkokuho','tt_afkokuho.atenano=tt_afseiho.atenano',0);
--【生活保護】生活保護受給情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afseiho.atenano',0);
--【生活保護】生活保護受給情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afseiho.atenano',0);
--【生活保護】生活保護受給情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afseiho.atenano',0);
--【生活保護】生活保護受給情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afseiho.atenano',0);
--【生活保護】生活保護受給情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afseiho.atenano',0);
--【生活保護】生活保護受給情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afseiho.atenano',0);
--【生活保護】生活保護受給情報履歴テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho_reki','tt_afatena','tt_afatena.atenano=tt_afseiho_reki.atenano',0);
--【生活保護】生活保護受給情報履歴テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho_reki','tt_afjumin','tt_afjumin.atenano=tt_afseiho_reki.atenano',0);
--【生活保護】生活保護受給情報履歴テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho_reki','tt_afkaigo','tt_afkaigo.atenano=tt_afseiho_reki.atenano',0);
--【生活保護】生活保護受給情報履歴テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho_reki','tt_afkokihoken','tt_afkokihoken.atenano=tt_afseiho_reki.atenano',0);
--【生活保護】生活保護受給情報履歴テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho_reki','tt_afkokuho','tt_afkokuho.atenano=tt_afseiho_reki.atenano',0);
--【生活保護】生活保護受給情報履歴テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho_reki','tt_afseiho','tt_afseiho.atenano=tt_afseiho_reki.atenano',0);
--【生活保護】生活保護受給情報履歴テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho_reki','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afseiho_reki.atenano',0);
--【生活保護】生活保護受給情報履歴テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho_reki','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afseiho_reki.atenano',0);
--【生活保護】生活保護受給情報履歴テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho_reki','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afseiho_reki.atenano',0);
--【生活保護】生活保護受給情報履歴テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho_reki','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afseiho_reki.atenano',0);
--【生活保護】生活保護受給情報履歴テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho_reki','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afseiho_reki.atenano',0);
--【生活保護】生活保護受給情報履歴テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afseiho_reki','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afseiho_reki.atenano',0);
--【住民基本台帳】支援措置対象者情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya','tt_afatena','tt_afatena.atenano=tt_afsiensotitaisyosya.atenano',0);
--【住民基本台帳】支援措置対象者情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya','tt_afjumin','tt_afjumin.atenano=tt_afsiensotitaisyosya.atenano',0);
--【住民基本台帳】支援措置対象者情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya','tt_afkaigo','tt_afkaigo.atenano=tt_afsiensotitaisyosya.atenano',0);
--【住民基本台帳】支援措置対象者情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya','tt_afkokihoken','tt_afkokihoken.atenano=tt_afsiensotitaisyosya.atenano',0);
--【住民基本台帳】支援措置対象者情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya','tt_afkokuho','tt_afkokuho.atenano=tt_afsiensotitaisyosya.atenano',0);
--【住民基本台帳】支援措置対象者情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya','tt_afseiho','tt_afseiho.atenano=tt_afsiensotitaisyosya.atenano',0);
--【住民基本台帳】支援措置対象者情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afsiensotitaisyosya.atenano',0);
--【住民基本台帳】支援措置対象者情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afsiensotitaisyosya.atenano',0);
--【住民基本台帳】支援措置対象者情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afsiensotitaisyosya.atenano',0);
--【住民基本台帳】支援措置対象者情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afsiensotitaisyosya.atenano',0);
--【住民基本台帳】支援措置対象者情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afsiensotitaisyosya.atenano',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_afatena','tt_afatena.atenano=tt_afsiensotitaisyosya_reki.atenano',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_afjumin','tt_afjumin.atenano=tt_afsiensotitaisyosya_reki.atenano',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 住登外者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_afjutogai','tt_afjutogai.atenano=tt_afsiensotitaisyosya_reki.atenano AND tt_afjutogai.rirekino=tt_afsiensotitaisyosya_reki.rirekino',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_afkaigo','tt_afkaigo.atenano=tt_afsiensotitaisyosya_reki.atenano',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_afkokihoken','tt_afkokihoken.atenano=tt_afsiensotitaisyosya_reki.atenano',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_afkokuho','tt_afkokuho.atenano=tt_afsiensotitaisyosya_reki.atenano',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 個人番号管理テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_afpersonalno','tt_afpersonalno.atenano=tt_afsiensotitaisyosya_reki.atenano AND tt_afpersonalno.rirekino=tt_afsiensotitaisyosya_reki.rirekino',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_afseiho','tt_afseiho.atenano=tt_afsiensotitaisyosya_reki.atenano',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afsiensotitaisyosya_reki.atenano',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afsiensotitaisyosya_reki.atenano',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 【障害者福祉】身体障害者手帳等情報履歴テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_afsyogaitetyo_reki','tt_afsyogaitetyo_reki.atenano=tt_afsiensotitaisyosya_reki.atenano AND tt_afsyogaitetyo_reki.rirekino=tt_afsiensotitaisyosya_reki.rirekino',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afsiensotitaisyosya_reki.atenano',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afsiensotitaisyosya_reki.atenano',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afsiensotitaisyosya_reki.atenano',0);
--【住民基本台帳】支援措置対象者情報履歴テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiensotitaisyosya_reki','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afsiensotitaisyosya_reki.atenano',0);
--使用履歴テーブル - 機能マスタ
INSERT INTO tm_eutablejoin VALUES('tt_afsiyorireki','tm_afkino','tm_afkino.kinoid=tt_afsiyorireki.kinoid',0);
--使用履歴テーブル - メニューマスタ
INSERT INTO tm_eutablejoin VALUES('tt_afsiyorireki','tm_afmenu','tm_afmenu.kinoid=tt_afsiyorireki.kinoid',0);
--使用履歴テーブル - ユーザーマスタ
INSERT INTO tm_eutablejoin VALUES('tt_afsiyorireki','tm_afuser','tm_afuser.userid=tt_afsiyorireki.userid',0);
--使用履歴テーブル - お気に入りテーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsiyorireki','tt_afokiniiri','tt_afokiniiri.userid=tt_afsiyorireki.userid AND tt_afokiniiri.kinoid=tt_afsiyorireki.kinoid',0);
--送付先管理テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsofusaki','tt_afatena','tt_afatena.atenano=tt_afsofusaki.atenano',0);
--送付先管理テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsofusaki','tt_afjumin','tt_afjumin.atenano=tt_afsofusaki.atenano',0);
--送付先管理テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsofusaki','tt_afkaigo','tt_afkaigo.atenano=tt_afsofusaki.atenano',0);
--送付先管理テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsofusaki','tt_afkokihoken','tt_afkokihoken.atenano=tt_afsofusaki.atenano',0);
--送付先管理テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsofusaki','tt_afkokuho','tt_afkokuho.atenano=tt_afsofusaki.atenano',0);
--送付先管理テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsofusaki','tt_afseiho','tt_afseiho.atenano=tt_afsofusaki.atenano',0);
--送付先管理テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsofusaki','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afsofusaki.atenano',0);
--送付先管理テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsofusaki','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afsofusaki.atenano',0);
--送付先管理テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsofusaki','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afsofusaki.atenano',0);
--送付先管理テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsofusaki','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afsofusaki.atenano',0);
--送付先管理テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsofusaki','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afsofusaki.atenano',0);
--送付先管理テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsofusaki','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afsofusaki.atenano',0);
--【障害者福祉】身体障害者手帳等情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo','tt_afatena','tt_afatena.atenano=tt_afsyogaitetyo.atenano',0);
--【障害者福祉】身体障害者手帳等情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo','tt_afjumin','tt_afjumin.atenano=tt_afsyogaitetyo.atenano',0);
--【障害者福祉】身体障害者手帳等情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo','tt_afkaigo','tt_afkaigo.atenano=tt_afsyogaitetyo.atenano',0);
--【障害者福祉】身体障害者手帳等情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo','tt_afkokihoken','tt_afkokihoken.atenano=tt_afsyogaitetyo.atenano',0);
--【障害者福祉】身体障害者手帳等情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo','tt_afkokuho','tt_afkokuho.atenano=tt_afsyogaitetyo.atenano',0);
--【障害者福祉】身体障害者手帳等情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo','tt_afseiho','tt_afseiho.atenano=tt_afsyogaitetyo.atenano',0);
--【障害者福祉】身体障害者手帳等情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afsyogaitetyo.atenano',0);
--【障害者福祉】身体障害者手帳等情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afsyogaitetyo.atenano',0);
--【障害者福祉】身体障害者手帳等情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afsyogaitetyo.atenano',0);
--【障害者福祉】身体障害者手帳等情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afsyogaitetyo.atenano',0);
--【障害者福祉】身体障害者手帳等情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afsyogaitetyo.atenano',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_afatena','tt_afatena.atenano=tt_afsyogaitetyo_reki.atenano',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_afjumin','tt_afjumin.atenano=tt_afsyogaitetyo_reki.atenano',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 住登外者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_afjutogai','tt_afjutogai.atenano=tt_afsyogaitetyo_reki.atenano AND tt_afjutogai.rirekino=tt_afsyogaitetyo_reki.rirekino',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_afkaigo','tt_afkaigo.atenano=tt_afsyogaitetyo_reki.atenano',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_afkokihoken','tt_afkokihoken.atenano=tt_afsyogaitetyo_reki.atenano',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_afkokuho','tt_afkokuho.atenano=tt_afsyogaitetyo_reki.atenano',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 個人番号管理テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_afpersonalno','tt_afpersonalno.atenano=tt_afsyogaitetyo_reki.atenano AND tt_afpersonalno.rirekino=tt_afsyogaitetyo_reki.rirekino',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_afseiho','tt_afseiho.atenano=tt_afsyogaitetyo_reki.atenano',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_afsyogaitetyo_reki.atenano',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_afsyogaitetyo_reki.atenano',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_afsyogaitetyo_reki.atenano',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_afsyogaitetyo_reki.atenano',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_afsyogaitetyo_reki.atenano',0);
--【障害者福祉】身体障害者手帳等情報履歴テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_afsyogaitetyo_reki','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_afsyogaitetyo_reki.atenano',0);
--通信ログテーブル - メインログテーブル
INSERT INTO tm_eutablejoin VALUES('tt_aftusinlog','tt_aflog','tt_aflog.sessionseq=tt_aftusinlog.sessionseq',0);
--ユーザー所属部署（支所）テーブル - ユーザーマスタ
INSERT INTO tm_eutablejoin VALUES('tt_afuser_sisyo','tm_afuser','tm_afuser.userid=tt_afuser_sisyo.userid',0);
--その他日程事業・保健指導事業マスタ - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kksonotasidojigyo','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tm_kksonotasidojigyo.jigyocd',0);
--フォロー結果情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_afatena','tt_afatena.atenano=tt_kkfollowkekka.atenano',0);
--フォロー結果情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_afjumin','tt_afjumin.atenano=tt_kkfollowkekka.atenano',0);
--フォロー結果情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_afkaigo','tt_afkaigo.atenano=tt_kkfollowkekka.atenano',0);
--フォロー結果情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_afkokihoken','tt_afkokihoken.atenano=tt_kkfollowkekka.atenano',0);
--フォロー結果情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_afkokuho','tt_afkokuho.atenano=tt_kkfollowkekka.atenano',0);
--フォロー結果情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_afseiho','tt_afseiho.atenano=tt_kkfollowkekka.atenano',0);
--フォロー結果情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kkfollowkekka.atenano',0);
--フォロー結果情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kkfollowkekka.atenano',0);
--フォロー結果情報テーブル - フォロー内容情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_kkfollownaiyo','tt_kkfollownaiyo.atenano=tt_kkfollowkekka.atenano AND tt_kkfollownaiyo.follownaiyoedano=tt_kkfollowkekka.follownaiyoedano',0);
--フォロー結果情報テーブル - フォロー予定情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_kkfollowyotei','tt_kkfollowyotei.atenano=tt_kkfollowkekka.atenano AND tt_kkfollowyotei.follownaiyoedano=tt_kkfollowkekka.follownaiyoedano AND tt_kkfollowyotei.edano=tt_kkfollowkekka.edano',0);
--フォロー結果情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kkfollowkekka.atenano',0);
--フォロー結果情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kkfollowkekka.atenano',0);
--フォロー結果情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kkfollowkekka.atenano',0);
--フォロー結果情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowkekka','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kkfollowkekka.atenano',0);
--フォロー内容情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollownaiyo','tt_afatena','tt_afatena.atenano=tt_kkfollownaiyo.atenano',0);
--フォロー内容情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollownaiyo','tt_afjumin','tt_afjumin.atenano=tt_kkfollownaiyo.atenano',0);
--フォロー内容情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollownaiyo','tt_afkaigo','tt_afkaigo.atenano=tt_kkfollownaiyo.atenano',0);
--フォロー内容情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollownaiyo','tt_afkokihoken','tt_afkokihoken.atenano=tt_kkfollownaiyo.atenano',0);
--フォロー内容情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollownaiyo','tt_afkokuho','tt_afkokuho.atenano=tt_kkfollownaiyo.atenano',0);
--フォロー内容情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollownaiyo','tt_afseiho','tt_afseiho.atenano=tt_kkfollownaiyo.atenano',0);
--フォロー内容情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollownaiyo','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kkfollownaiyo.atenano',0);
--フォロー内容情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollownaiyo','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kkfollownaiyo.atenano',0);
--フォロー内容情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollownaiyo','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kkfollownaiyo.atenano',0);
--フォロー内容情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollownaiyo','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kkfollownaiyo.atenano',0);
--フォロー内容情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollownaiyo','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kkfollownaiyo.atenano',0);
--フォロー内容情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollownaiyo','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kkfollownaiyo.atenano',0);
--フォロー予定情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_afatena','tt_afatena.atenano=tt_kkfollowyotei.atenano',0);
--フォロー予定情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_afjumin','tt_afjumin.atenano=tt_kkfollowyotei.atenano',0);
--フォロー予定情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_afkaigo','tt_afkaigo.atenano=tt_kkfollowyotei.atenano',0);
--フォロー予定情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_afkokihoken','tt_afkokihoken.atenano=tt_kkfollowyotei.atenano',0);
--フォロー予定情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_afkokuho','tt_afkokuho.atenano=tt_kkfollowyotei.atenano',0);
--フォロー予定情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_afseiho','tt_afseiho.atenano=tt_kkfollowyotei.atenano',0);
--フォロー予定情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kkfollowyotei.atenano',0);
--フォロー予定情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kkfollowyotei.atenano',0);
--フォロー予定情報テーブル - フォロー結果情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_kkfollowkekka','tt_kkfollowkekka.atenano=tt_kkfollowyotei.atenano AND tt_kkfollowkekka.follownaiyoedano=tt_kkfollowyotei.follownaiyoedano AND tt_kkfollowkekka.edano=tt_kkfollowyotei.edano',0);
--フォロー予定情報テーブル - フォロー内容情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_kkfollownaiyo','tt_kkfollownaiyo.atenano=tt_kkfollowyotei.atenano AND tt_kkfollownaiyo.follownaiyoedano=tt_kkfollowyotei.follownaiyoedano',0);
--フォロー予定情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kkfollowyotei.atenano',0);
--フォロー予定情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kkfollowyotei.atenano',0);
--フォロー予定情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kkfollowyotei.atenano',0);
--フォロー予定情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkfollowyotei','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kkfollowyotei.atenano',0);
--保健指導事業（フリー項目）入力情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_afatena','tt_afatena.atenano=tt_kkhokensidofree.atenano',0);
--保健指導事業（フリー項目）入力情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_afjumin','tt_afjumin.atenano=tt_kkhokensidofree.atenano',0);
--保健指導事業（フリー項目）入力情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_afkaigo','tt_afkaigo.atenano=tt_kkhokensidofree.atenano',0);
--保健指導事業（フリー項目）入力情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_afkokihoken','tt_afkokihoken.atenano=tt_kkhokensidofree.atenano',0);
--保健指導事業（フリー項目）入力情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_afkokuho','tt_afkokuho.atenano=tt_kkhokensidofree.atenano',0);
--保健指導事業（フリー項目）入力情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_afseiho','tt_afseiho.atenano=tt_kkhokensidofree.atenano',0);
--保健指導事業（フリー項目）入力情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kkhokensidofree.atenano',0);
--保健指導事業（フリー項目）入力情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kkhokensidofree.atenano',0);
--保健指導事業（フリー項目）入力情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kkhokensidofree.atenano',0);
--保健指導事業（フリー項目）入力情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kkhokensidofree.atenano',0);
--保健指導事業（フリー項目）入力情報テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_kkhokensidofree.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_kkhokensidofree.edano',0);
--保健指導事業（フリー項目）入力情報テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_kkhokensidofree.atenano AND tt_bhnyseikenkekka.edano=tt_kkhokensidofree.edano',0);
--保健指導事業（フリー項目）入力情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kkhokensidofree.atenano',0);
--保健指導事業（フリー項目）入力情報テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_kkhokensidofree.atenano AND tt_bhnymijusinsyakansyo.edano=tt_kkhokensidofree.edano',0);
--保健指導事業（フリー項目）入力情報テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_kkhokensidofree.atenano AND tt_bhnyseikenirai.edano=tt_kkhokensidofree.edano',0);
--保健指導事業（フリー項目）入力情報テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_kkhokensidofree.atenano AND tt_yssessyuirai.edano=tt_kkhokensidofree.edano',0);
--保健指導事業（フリー項目）入力情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensidofree','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kkhokensidofree.atenano',0);
--保健指導結果情報（固定項目）テーブル - 会場情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tm_afkaijo','tm_afkaijo.kaijocd=tt_kkhokensido_kekka.kaijocd',0);
--保健指導結果情報（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_afatena','tt_afatena.atenano=tt_kkhokensido_kekka.atenano',0);
--保健指導結果情報（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_afjumin','tt_afjumin.atenano=tt_kkhokensido_kekka.atenano',0);
--保健指導結果情報（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_afkaigo','tt_afkaigo.atenano=tt_kkhokensido_kekka.atenano',0);
--保健指導結果情報（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_afkokihoken','tt_afkokihoken.atenano=tt_kkhokensido_kekka.atenano',0);
--保健指導結果情報（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_afkokuho','tt_afkokuho.atenano=tt_kkhokensido_kekka.atenano',0);
--保健指導結果情報（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_afseiho','tt_afseiho.atenano=tt_kkhokensido_kekka.atenano',0);
--保健指導結果情報（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kkhokensido_kekka.atenano',0);
--保健指導結果情報（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kkhokensido_kekka.atenano',0);
--保健指導結果情報（固定項目）テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_kkhokensido_kekka.jigyocd',0);
--保健指導結果情報（固定項目）テーブル - 保健指導申込情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_kkhokensido_mosikomi','tt_kkhokensido_mosikomi.hokensidokbn=tt_kkhokensido_kekka.hokensidokbn AND tt_kkhokensido_mosikomi.gyomukbn=tt_kkhokensido_kekka.gyomukbn AND tt_kkhokensido_mosikomi.atenano=tt_kkhokensido_kekka.atenano AND tt_kkhokensido_mosikomi.edano=tt_kkhokensido_kekka.edano',0);
--保健指導結果情報（固定項目）テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_kkhokensido_kekka.jigyocd',0);
--保健指導結果情報（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kkhokensido_kekka.atenano',0);
--保健指導結果情報（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kkhokensido_kekka.atenano',0);
--保健指導結果情報（固定項目）テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_kkhokensido_kekka.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_kkhokensido_kekka.edano',0);
--保健指導結果情報（固定項目）テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_kkhokensido_kekka.atenano AND tt_bhnyseikenkekka.edano=tt_kkhokensido_kekka.edano',0);
--保健指導結果情報（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kkhokensido_kekka.atenano',0);
--保健指導結果情報（固定項目）テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_kkhokensido_kekka.atenano AND tt_bhnymijusinsyakansyo.edano=tt_kkhokensido_kekka.edano',0);
--保健指導結果情報（固定項目）テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_kkhokensido_kekka.atenano AND tt_bhnyseikenirai.edano=tt_kkhokensido_kekka.edano',0);
--保健指導結果情報（固定項目）テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_kkhokensido_kekka.atenano AND tt_yssessyuirai.edano=tt_kkhokensido_kekka.edano',0);
--保健指導結果情報（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_kekka','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kkhokensido_kekka.atenano',0);
--保健指導申込情報（固定項目）テーブル - 会場情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tm_afkaijo','tm_afkaijo.kaijocd=tt_kkhokensido_mosikomi.kaijocd',0);
--保健指導申込情報（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_afatena','tt_afatena.atenano=tt_kkhokensido_mosikomi.atenano',0);
--保健指導申込情報（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_afjumin','tt_afjumin.atenano=tt_kkhokensido_mosikomi.atenano',0);
--保健指導申込情報（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_afkaigo','tt_afkaigo.atenano=tt_kkhokensido_mosikomi.atenano',0);
--保健指導申込情報（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_afkokihoken','tt_afkokihoken.atenano=tt_kkhokensido_mosikomi.atenano',0);
--保健指導申込情報（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_afkokuho','tt_afkokuho.atenano=tt_kkhokensido_mosikomi.atenano',0);
--保健指導申込情報（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_afseiho','tt_afseiho.atenano=tt_kkhokensido_mosikomi.atenano',0);
--保健指導申込情報（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kkhokensido_mosikomi.atenano',0);
--保健指導申込情報（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kkhokensido_mosikomi.atenano',0);
--保健指導申込情報（固定項目）テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_kkhokensido_mosikomi.jigyocd',0);
--保健指導申込情報（固定項目）テーブル - 保健指導結果情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_kkhokensido_kekka','tt_kkhokensido_kekka.hokensidokbn=tt_kkhokensido_mosikomi.hokensidokbn AND tt_kkhokensido_kekka.gyomukbn=tt_kkhokensido_mosikomi.gyomukbn AND tt_kkhokensido_kekka.atenano=tt_kkhokensido_mosikomi.atenano AND tt_kkhokensido_kekka.edano=tt_kkhokensido_mosikomi.edano',0);
--保健指導申込情報（固定項目）テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_kkhokensido_mosikomi.jigyocd',0);
--保健指導申込情報（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kkhokensido_mosikomi.atenano',0);
--保健指導申込情報（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kkhokensido_mosikomi.atenano',0);
--保健指導申込情報（固定項目）テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_kkhokensido_mosikomi.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_kkhokensido_mosikomi.edano',0);
--保健指導申込情報（固定項目）テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_kkhokensido_mosikomi.atenano AND tt_bhnyseikenkekka.edano=tt_kkhokensido_mosikomi.edano',0);
--保健指導申込情報（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kkhokensido_mosikomi.atenano',0);
--保健指導申込情報（固定項目）テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_kkhokensido_mosikomi.atenano AND tt_bhnymijusinsyakansyo.edano=tt_kkhokensido_mosikomi.edano',0);
--保健指導申込情報（固定項目）テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_kkhokensido_mosikomi.atenano AND tt_bhnyseikenirai.edano=tt_kkhokensido_mosikomi.edano',0);
--保健指導申込情報（固定項目）テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_kkhokensido_mosikomi.atenano AND tt_yssessyuirai.edano=tt_kkhokensido_mosikomi.edano',0);
--保健指導申込情報（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_mosikomi','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kkhokensido_mosikomi.atenano',0);
--保健指導担当者テーブル - 事業従事者（担当者）情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tm_afstaff','tm_afstaff.staffid=tt_kkhokensido_staff.staffid',0);
--保健指導担当者テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_afatena','tt_afatena.atenano=tt_kkhokensido_staff.atenano',0);
--保健指導担当者テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_afjumin','tt_afjumin.atenano=tt_kkhokensido_staff.atenano',0);
--保健指導担当者テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_afkaigo','tt_afkaigo.atenano=tt_kkhokensido_staff.atenano',0);
--保健指導担当者テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_afkokihoken','tt_afkokihoken.atenano=tt_kkhokensido_staff.atenano',0);
--保健指導担当者テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_afkokuho','tt_afkokuho.atenano=tt_kkhokensido_staff.atenano',0);
--保健指導担当者テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_afseiho','tt_afseiho.atenano=tt_kkhokensido_staff.atenano',0);
--保健指導担当者テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kkhokensido_staff.atenano',0);
--保健指導担当者テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kkhokensido_staff.atenano',0);
--保健指導担当者テーブル - 保健指導結果情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_kkhokensido_kekka','tt_kkhokensido_kekka.hokensidokbn=tt_kkhokensido_staff.hokensidokbn AND tt_kkhokensido_kekka.gyomukbn=tt_kkhokensido_staff.gyomukbn AND tt_kkhokensido_kekka.atenano=tt_kkhokensido_staff.atenano AND tt_kkhokensido_kekka.edano=tt_kkhokensido_staff.edano',0);
--保健指導担当者テーブル - 保健指導申込情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_kkhokensido_mosikomi','tt_kkhokensido_mosikomi.hokensidokbn=tt_kkhokensido_staff.hokensidokbn AND tt_kkhokensido_mosikomi.gyomukbn=tt_kkhokensido_staff.gyomukbn AND tt_kkhokensido_mosikomi.atenano=tt_kkhokensido_staff.atenano AND tt_kkhokensido_mosikomi.edano=tt_kkhokensido_staff.edano',0);
--保健指導担当者テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kkhokensido_staff.atenano',0);
--保健指導担当者テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kkhokensido_staff.atenano',0);
--保健指導担当者テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_kkhokensido_staff.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_kkhokensido_staff.edano',0);
--保健指導担当者テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_kkhokensido_staff.atenano AND tt_bhnyseikenkekka.edano=tt_kkhokensido_staff.edano',0);
--保健指導担当者テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kkhokensido_staff.atenano',0);
--保健指導担当者テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_kkhokensido_staff.atenano AND tt_bhnymijusinsyakansyo.edano=tt_kkhokensido_staff.edano',0);
--保健指導担当者テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_kkhokensido_staff.atenano AND tt_bhnyseikenirai.edano=tt_kkhokensido_staff.edano',0);
--保健指導担当者テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_kkhokensido_staff.atenano AND tt_yssessyuirai.edano=tt_kkhokensido_staff.edano',0);
--保健指導担当者テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhokensido_staff','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kkhokensido_staff.atenano',0);
--実施報告書（日報）情報テーブル - 会場情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkjissihokokusyo','tm_afkaijo','tm_afkaijo.kaijocd=tt_kkjissihokokusyo.kaijocd',0);
--実施報告書（日報）情報テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkjissihokokusyo','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_kkjissihokokusyo.jigyocd',0);
--実施報告書（日報）情報テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkjissihokokusyo','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_kkjissihokokusyo.jigyocd',0);
--実施報告書（日報）情報サブテーブル - 事業従事者（担当者）情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkjissihokokusyo_sub','tm_afstaff','tm_afstaff.staffid=tt_kkjissihokokusyo_sub.staffid',0);
--実施報告書（日報）情報サブテーブル - 実施報告書（日報）情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjissihokokusyo_sub','tt_kkjissihokokusyo','tt_kkjissihokokusyo.hokokusyono=tt_kkjissihokokusyo_sub.hokokusyono',0);
--帳票発行対象外者テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkotaisyogaisya','tt_afatena','tt_afatena.atenano=tt_kkrpthakkotaisyogaisya.atenano',0);
--帳票発行対象外者テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkotaisyogaisya','tt_afjumin','tt_afjumin.atenano=tt_kkrpthakkotaisyogaisya.atenano',0);
--帳票発行対象外者テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkotaisyogaisya','tt_afkaigo','tt_afkaigo.atenano=tt_kkrpthakkotaisyogaisya.atenano',0);
--帳票発行対象外者テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkotaisyogaisya','tt_afkokihoken','tt_afkokihoken.atenano=tt_kkrpthakkotaisyogaisya.atenano',0);
--帳票発行対象外者テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkotaisyogaisya','tt_afkokuho','tt_afkokuho.atenano=tt_kkrpthakkotaisyogaisya.atenano',0);
--帳票発行対象外者テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkotaisyogaisya','tt_afseiho','tt_afseiho.atenano=tt_kkrpthakkotaisyogaisya.atenano',0);
--帳票発行対象外者テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkotaisyogaisya','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kkrpthakkotaisyogaisya.atenano',0);
--帳票発行対象外者テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkotaisyogaisya','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kkrpthakkotaisyogaisya.atenano',0);
--帳票発行対象外者テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkotaisyogaisya','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kkrpthakkotaisyogaisya.atenano',0);
--帳票発行対象外者テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkotaisyogaisya','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kkrpthakkotaisyogaisya.atenano',0);
--帳票発行対象外者テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkotaisyogaisya','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kkrpthakkotaisyogaisya.atenano',0);
--帳票発行対象外者テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkotaisyogaisya','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kkrpthakkotaisyogaisya.atenano',0);
--集団指導事業（フリー項目）入力情報テーブル - 集団指導結果情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansidofree','tt_kksyudansido_kekka','tt_kksyudansido_kekka.gyomukbn=tt_kksyudansidofree.gyomukbn AND tt_kksyudansido_kekka.edano=tt_kksyudansidofree.edano',0);
--集団指導事業（フリー項目）入力情報テーブル - 集団指導申込情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansidofree','tt_kksyudansido_mosikomi','tt_kksyudansido_mosikomi.gyomukbn=tt_kksyudansidofree.gyomukbn AND tt_kksyudansido_mosikomi.edano=tt_kksyudansidofree.edano',0);
--集団指導結果情報（固定項目）テーブル - 会場情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_kekka','tm_afkaijo','tm_afkaijo.kaijocd=tt_kksyudansido_kekka.kaijocd',0);
--集団指導結果情報（固定項目）テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_kekka','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_kksyudansido_kekka.jigyocd',0);
--集団指導結果情報（固定項目）テーブル - 集団指導申込情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_kekka','tt_kksyudansido_mosikomi','tt_kksyudansido_mosikomi.gyomukbn=tt_kksyudansido_kekka.gyomukbn AND tt_kksyudansido_mosikomi.edano=tt_kksyudansido_kekka.edano',0);
--集団指導結果情報（固定項目）テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_kekka','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_kksyudansido_kekka.jigyocd',0);
--集団指導申込情報（固定項目）テーブル - 会場情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_mosikomi','tm_afkaijo','tm_afkaijo.kaijocd=tt_kksyudansido_mosikomi.kaijocd',0);
--集団指導申込情報（固定項目）テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_mosikomi','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_kksyudansido_mosikomi.jigyocd',0);
--集団指導申込情報（固定項目）テーブル - 集団指導結果情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_mosikomi','tt_kksyudansido_kekka','tt_kksyudansido_kekka.gyomukbn=tt_kksyudansido_mosikomi.gyomukbn AND tt_kksyudansido_kekka.edano=tt_kksyudansido_mosikomi.edano',0);
--集団指導申込情報（固定項目）テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_mosikomi','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_kksyudansido_mosikomi.jigyocd',0);
--集団指導参加者テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_afatena','tt_afatena.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_afjumin','tt_afjumin.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_afkaigo','tt_afkaigo.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_afkokihoken','tt_afkokihoken.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_afkokuho','tt_afkokuho.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者テーブル - 連絡先テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_afrenrakusaki','tt_afrenrakusaki.atenano=tt_kksyudansido_sankasya.atenano AND tt_afrenrakusaki.jigyocd=tt_kksyudansido_sankasya.jigyocd',0);
--集団指導参加者テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_afseiho','tt_afseiho.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_kksyudansido_sankasya.jigyocd',0);
--集団指導参加者テーブル - 集団指導結果情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_kksyudansido_kekka','tt_kksyudansido_kekka.gyomukbn=tt_kksyudansido_sankasya.gyomukbn AND tt_kksyudansido_kekka.edano=tt_kksyudansido_sankasya.edano',0);
--集団指導参加者テーブル - 集団指導申込情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_kksyudansido_mosikomi','tt_kksyudansido_mosikomi.gyomukbn=tt_kksyudansido_sankasya.gyomukbn AND tt_kksyudansido_mosikomi.edano=tt_kksyudansido_sankasya.edano',0);
--集団指導参加者テーブル - 集団指導参加者結果情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_kksyudansido_sankasyakekka','tt_kksyudansido_sankasyakekka.gyomukbn=tt_kksyudansido_sankasya.gyomukbn AND tt_kksyudansido_sankasyakekka.edano=tt_kksyudansido_sankasya.edano AND tt_kksyudansido_sankasyakekka.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者テーブル - 集団指導参加者申込情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_kksyudansido_sankasyamosikomi','tt_kksyudansido_sankasyamosikomi.gyomukbn=tt_kksyudansido_sankasya.gyomukbn AND tt_kksyudansido_sankasyamosikomi.edano=tt_kksyudansido_sankasya.edano AND tt_kksyudansido_sankasyamosikomi.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_kksyudansido_sankasya.jigyocd',0);
--集団指導参加者テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasya','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kksyudansido_sankasya.atenano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_afatena','tt_afatena.atenano=tt_kksyudansido_sankasyafree.atenano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_afjumin','tt_afjumin.atenano=tt_kksyudansido_sankasyafree.atenano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_afkaigo','tt_afkaigo.atenano=tt_kksyudansido_sankasyafree.atenano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_afkokihoken','tt_afkokihoken.atenano=tt_kksyudansido_sankasyafree.atenano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_afkokuho','tt_afkokuho.atenano=tt_kksyudansido_sankasyafree.atenano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_afseiho','tt_afseiho.atenano=tt_kksyudansido_sankasyafree.atenano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kksyudansido_sankasyafree.atenano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kksyudansido_sankasyafree.atenano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 集団指導事業（フリー項目）入力情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_kksyudansidofree','tt_kksyudansidofree.gyomukbn=tt_kksyudansido_sankasyafree.gyomukbn AND tt_kksyudansidofree.edano=tt_kksyudansido_sankasyafree.edano AND tt_kksyudansidofree.mosikomikekkakbn=tt_kksyudansido_sankasyafree.mosikomikekkakbn AND tt_kksyudansidofree.itemcd=tt_kksyudansido_sankasyafree.itemcd',0);
--集団指導参加者（フリー項目）入力情報テーブル - 集団指導結果情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_kksyudansido_kekka','tt_kksyudansido_kekka.gyomukbn=tt_kksyudansido_sankasyafree.gyomukbn AND tt_kksyudansido_kekka.edano=tt_kksyudansido_sankasyafree.edano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 集団指導申込情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_kksyudansido_mosikomi','tt_kksyudansido_mosikomi.gyomukbn=tt_kksyudansido_sankasyafree.gyomukbn AND tt_kksyudansido_mosikomi.edano=tt_kksyudansido_sankasyafree.edano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kksyudansido_sankasyafree.atenano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kksyudansido_sankasyafree.atenano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kksyudansido_sankasyafree.atenano',0);
--集団指導参加者（フリー項目）入力情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyafree','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kksyudansido_sankasyafree.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_afatena','tt_afatena.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_afjumin','tt_afjumin.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_afkaigo','tt_afkaigo.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_afkokihoken','tt_afkokihoken.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_afkokuho','tt_afkokuho.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_afseiho','tt_afseiho.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 集団指導結果情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_kksyudansido_kekka','tt_kksyudansido_kekka.gyomukbn=tt_kksyudansido_sankasyakekka.gyomukbn AND tt_kksyudansido_kekka.edano=tt_kksyudansido_sankasyakekka.edano',0);
--集団指導参加者結果情報（固定項目）テーブル - 集団指導申込情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_kksyudansido_mosikomi','tt_kksyudansido_mosikomi.gyomukbn=tt_kksyudansido_sankasyakekka.gyomukbn AND tt_kksyudansido_mosikomi.edano=tt_kksyudansido_sankasyakekka.edano',0);
--集団指導参加者結果情報（固定項目）テーブル - 集団指導参加者テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_kksyudansido_sankasya','tt_kksyudansido_sankasya.gyomukbn=tt_kksyudansido_sankasyakekka.gyomukbn AND tt_kksyudansido_sankasya.edano=tt_kksyudansido_sankasyakekka.edano AND tt_kksyudansido_sankasya.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 集団指導参加者申込情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_kksyudansido_sankasyamosikomi','tt_kksyudansido_sankasyamosikomi.gyomukbn=tt_kksyudansido_sankasyakekka.gyomukbn AND tt_kksyudansido_sankasyamosikomi.edano=tt_kksyudansido_sankasyakekka.edano AND tt_kksyudansido_sankasyamosikomi.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者結果情報（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyakekka','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kksyudansido_sankasyakekka.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_afatena','tt_afatena.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_afjumin','tt_afjumin.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_afkaigo','tt_afkaigo.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_afkokihoken','tt_afkokihoken.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_afkokuho','tt_afkokuho.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_afseiho','tt_afseiho.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 集団指導結果情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_kksyudansido_kekka','tt_kksyudansido_kekka.gyomukbn=tt_kksyudansido_sankasyamosikomi.gyomukbn AND tt_kksyudansido_kekka.edano=tt_kksyudansido_sankasyamosikomi.edano',0);
--集団指導参加者申込情報（固定項目）テーブル - 集団指導申込情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_kksyudansido_mosikomi','tt_kksyudansido_mosikomi.gyomukbn=tt_kksyudansido_sankasyamosikomi.gyomukbn AND tt_kksyudansido_mosikomi.edano=tt_kksyudansido_sankasyamosikomi.edano',0);
--集団指導参加者申込情報（固定項目）テーブル - 集団指導参加者テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_kksyudansido_sankasya','tt_kksyudansido_sankasya.gyomukbn=tt_kksyudansido_sankasyamosikomi.gyomukbn AND tt_kksyudansido_sankasya.edano=tt_kksyudansido_sankasyamosikomi.edano AND tt_kksyudansido_sankasya.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 集団指導参加者結果情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_kksyudansido_sankasyakekka','tt_kksyudansido_sankasyakekka.gyomukbn=tt_kksyudansido_sankasyamosikomi.gyomukbn AND tt_kksyudansido_sankasyakekka.edano=tt_kksyudansido_sankasyamosikomi.edano AND tt_kksyudansido_sankasyakekka.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導参加者申込情報（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_sankasyamosikomi','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kksyudansido_sankasyamosikomi.atenano',0);
--集団指導担当者テーブル - 事業従事者（担当者）情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_staff','tm_afstaff','tm_afstaff.staffid=tt_kksyudansido_staff.staffid',0);
--集団指導担当者テーブル - 集団指導結果情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_staff','tt_kksyudansido_kekka','tt_kksyudansido_kekka.gyomukbn=tt_kksyudansido_staff.gyomukbn AND tt_kksyudansido_kekka.edano=tt_kksyudansido_staff.edano',0);
--集団指導担当者テーブル - 集団指導申込情報（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kksyudansido_staff','tt_kksyudansido_mosikomi','tt_kksyudansido_mosikomi.gyomukbn=tt_kksyudansido_staff.gyomukbn AND tt_kksyudansido_mosikomi.edano=tt_kksyudansido_staff.edano',0);
--一括取込入力マスタ - 取込基本情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktorinyuryoku','tm_kktori_kihon','tm_kktori_kihon.torinyuryokuno=tm_kktorinyuryoku.torinyuryokuno',0);
--取込基本情報マスタ - 一括取込入力マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktori_kihon','tm_kktorinyuryoku','tm_kktorinyuryoku.torinyuryokuno=tm_kktori_kihon.torinyuryokuno',0);
--一括取込入力対象テーブルマスタ - 一括取込入力マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktorinyuryoku_taisyotable','tm_kktorinyuryoku','tm_kktorinyuryoku.torinyuryokuno=tm_kktorinyuryoku_taisyotable.torinyuryokuno',0);
--一括取込入力対象テーブルマスタ - 取込基本情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktorinyuryoku_taisyotable','tm_kktori_kihon','tm_kktori_kihon.torinyuryokuno=tm_kktorinyuryoku_taisyotable.torinyuryokuno',0);
--一括取込入力対象テーブルマスタ - 一括取込入力テーブルマスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktorinyuryoku_taisyotable','tm_kktorinyuryoku_table','tm_kktorinyuryoku_table.tablenm=tm_kktorinyuryoku_taisyotable.tablenm',0);
--取込IFマスタ - 一括取込入力マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktori_interface','tm_kktorinyuryoku','tm_kktorinyuryoku.torinyuryokuno=tm_kktori_interface.torinyuryokuno',0);
--取込IFマスタ - 取込基本情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktori_interface','tm_kktori_kihon','tm_kktori_kihon.torinyuryokuno=tm_kktori_interface.torinyuryokuno',0);
--一括取込入力項目定義マスタ - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktorinyuryoku_item','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tm_kktorinyuryoku_item.jigyocd',0);
--一括取込入力項目定義マスタ - 一括取込入力マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktorinyuryoku_item','tm_kktorinyuryoku','tm_kktorinyuryoku.torinyuryokuno=tm_kktorinyuryoku_item.torinyuryokuno',0);
--一括取込入力項目定義マスタ - 取込基本情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktorinyuryoku_item','tm_kktori_kihon','tm_kktori_kihon.torinyuryokuno=tm_kktorinyuryoku_item.torinyuryokuno',0);
--一括取込入力項目定義マスタ - 取込項目マッピングマスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktorinyuryoku_item','tm_kktori_mapping','tm_kktori_mapping.torinyuryokuno=tm_kktorinyuryoku_item.torinyuryokuno AND tm_kktori_mapping.gamenitemseq=tm_kktorinyuryoku_item.gamenitemseq',0);
--一括取込入力項目定義マスタ - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktorinyuryoku_item','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tm_kktorinyuryoku_item.jigyocd',0);
--一括取込入力変換コードメインマスタ - 一括取込入力マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktorinyuryoku_henkancode_main','tm_kktorinyuryoku','tm_kktorinyuryoku.torinyuryokuno=tm_kktorinyuryoku_henkancode_main.torinyuryokuno',0);
--一括取込入力変換コードメインマスタ - 取込基本情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktorinyuryoku_henkancode_main','tm_kktori_kihon','tm_kktori_kihon.torinyuryokuno=tm_kktorinyuryoku_henkancode_main.torinyuryokuno',0);
--取込変換コードマスタ - 一括取込入力マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktori_henkancode','tm_kktorinyuryoku','tm_kktorinyuryoku.torinyuryokuno=tm_kktori_henkancode.torinyuryokuno',0);
--取込変換コードマスタ - 取込基本情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktori_henkancode','tm_kktori_kihon','tm_kktori_kihon.torinyuryokuno=tm_kktori_henkancode.torinyuryokuno',0);
--取込変換コードマスタ - 一括取込入力変換コードメインマスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktori_henkancode','tm_kktorinyuryoku_henkancode_main','tm_kktorinyuryoku_henkancode_main.torinyuryokuno=tm_kktori_henkancode.torinyuryokuno AND tm_kktorinyuryoku_henkancode_main.codehenkankbn=tm_kktori_henkancode.codehenkankbn',0);
--取込項目マッピングマスタ - 一括取込入力マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktori_mapping','tm_kktorinyuryoku','tm_kktorinyuryoku.torinyuryokuno=tm_kktori_mapping.torinyuryokuno',0);
--取込項目マッピングマスタ - 取込基本情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktori_mapping','tm_kktori_kihon','tm_kktori_kihon.torinyuryokuno=tm_kktori_mapping.torinyuryokuno',0);
--取込項目マッピングマスタ - 一括取込入力項目定義マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktori_mapping','tm_kktorinyuryoku_item','tm_kktorinyuryoku_item.torinyuryokuno=tm_kktori_mapping.torinyuryokuno AND tm_kktorinyuryoku_item.gamenitemseq=tm_kktori_mapping.gamenitemseq',0);
--一括取込入力登録マスタ - 一括取込入力マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktorinyuryoku_toroku','tm_kktorinyuryoku','tm_kktorinyuryoku.torinyuryokuno=tm_kktorinyuryoku_toroku.torinyuryokuno',0);
--一括取込入力登録マスタ - 取込基本情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktorinyuryoku_toroku','tm_kktori_kihon','tm_kktori_kihon.torinyuryokuno=tm_kktorinyuryoku_toroku.torinyuryokuno',0);
--一括取込入力未処理テーブル - 一括取込入力マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_misyori','tm_kktorinyuryoku','tm_kktorinyuryoku.torinyuryokuno=tt_kktorinyuryoku_misyori.torinyuryokuno',0);
--一括取込入力未処理テーブル - 取込基本情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_misyori','tm_kktori_kihon','tm_kktori_kihon.torinyuryokuno=tt_kktorinyuryoku_misyori.torinyuryokuno',0);
--一括取込入力未処理項目テーブル - 一括取込入力未処理テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_misyoriitem','tt_kktorinyuryoku_misyori','tt_kktorinyuryoku_misyori.impjikkoid=tt_kktorinyuryoku_misyoriitem.impjikkoid',0);
--一括取込入力エラーテーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_err','tt_afatena','tt_afatena.atenano=tt_kktorinyuryoku_err.atenano',0);
--一括取込入力エラーテーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_err','tt_afjumin','tt_afjumin.atenano=tt_kktorinyuryoku_err.atenano',0);
--一括取込入力エラーテーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_err','tt_afkaigo','tt_afkaigo.atenano=tt_kktorinyuryoku_err.atenano',0);
--一括取込入力エラーテーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_err','tt_afkokihoken','tt_afkokihoken.atenano=tt_kktorinyuryoku_err.atenano',0);
--一括取込入力エラーテーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_err','tt_afkokuho','tt_afkokuho.atenano=tt_kktorinyuryoku_err.atenano',0);
--一括取込入力エラーテーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_err','tt_afseiho','tt_afseiho.atenano=tt_kktorinyuryoku_err.atenano',0);
--一括取込入力エラーテーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_err','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kktorinyuryoku_err.atenano',0);
--一括取込入力エラーテーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_err','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kktorinyuryoku_err.atenano',0);
--一括取込入力エラーテーブル - 一括取込入力未処理テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_err','tt_kktorinyuryoku_misyori','tt_kktorinyuryoku_misyori.impjikkoid=tt_kktorinyuryoku_err.impjikkoid',0);
--一括取込入力エラーテーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_err','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kktorinyuryoku_err.atenano',0);
--一括取込入力エラーテーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_err','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kktorinyuryoku_err.atenano',0);
--一括取込入力エラーテーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_err','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kktorinyuryoku_err.atenano',0);
--一括取込入力エラーテーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktorinyuryoku_err','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kktorinyuryoku_err.atenano',0);
--事業予定テーブル - 会場情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyotei','tm_afkaijo','tm_afkaijo.kaijocd=tt_kkjigyoyotei.kaijocd',0);
--事業予定テーブル - 医療機関マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyotei','tm_afkikan','tm_afkikan.kikancd=tt_kkjigyoyotei.kikancd',0);
--事業予定テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyotei','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_kkjigyoyotei.jigyocd',0);
--事業予定テーブル - 事業予定コーステーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyotei','tt_kkjigyoyoteicourse','tt_kkjigyoyoteicourse.courseno=tt_kkjigyoyotei.courseno',0);
--事業予定テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyotei','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_kkjigyoyotei.jigyocd',0);
--事業予定担当者テーブル - 事業従事者（担当者）情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyotei_staff','tm_afstaff','tm_afstaff.staffid=tt_kkjigyoyotei_staff.staffid',0);
--事業予定担当者テーブル - 事業予定テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyotei_staff','tt_kkjigyoyotei','tt_kkjigyoyotei.nitteino=tt_kkjigyoyotei_staff.nitteino',0);
--事業予約希望者テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyoyakukibosya','tt_afatena','tt_afatena.atenano=tt_kkjigyoyoyakukibosya.atenano',0);
--事業予約希望者テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyoyakukibosya','tt_afjumin','tt_afjumin.atenano=tt_kkjigyoyoyakukibosya.atenano',0);
--事業予約希望者テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyoyakukibosya','tt_afkaigo','tt_afkaigo.atenano=tt_kkjigyoyoyakukibosya.atenano',0);
--事業予約希望者テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyoyakukibosya','tt_afkokihoken','tt_afkokihoken.atenano=tt_kkjigyoyoyakukibosya.atenano',0);
--事業予約希望者テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyoyakukibosya','tt_afkokuho','tt_afkokuho.atenano=tt_kkjigyoyoyakukibosya.atenano',0);
--事業予約希望者テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyoyakukibosya','tt_afseiho','tt_afseiho.atenano=tt_kkjigyoyoyakukibosya.atenano',0);
--事業予約希望者テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyoyakukibosya','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kkjigyoyoyakukibosya.atenano',0);
--事業予約希望者テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyoyakukibosya','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kkjigyoyoyakukibosya.atenano',0);
--事業予約希望者テーブル - 事業予定テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyoyakukibosya','tt_kkjigyoyotei','tt_kkjigyoyotei.nitteino=tt_kkjigyoyoyakukibosya.nitteino',0);
--事業予約希望者テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyoyakukibosya','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kkjigyoyoyakukibosya.atenano',0);
--事業予約希望者テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyoyakukibosya','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kkjigyoyoyakukibosya.atenano',0);
--事業予約希望者テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyoyakukibosya','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kkjigyoyoyakukibosya.atenano',0);
--事業予約希望者テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkjigyoyoyakukibosya','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kkjigyoyoyakukibosya.atenano',0);
--対象者抽出情報テーブル - 抽出情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu','tm_kktyusyutu','tm_kktyusyutu.tyusyututaisyocd=tt_kktaisyosya_tyusyutu.tyusyututaisyocd',0);
--対象者抽出情報項目テーブル - 対象者抽出情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutufree','tt_kktaisyosya_tyusyutu','tt_kktaisyosya_tyusyutu.tyusyutuseq=tt_kktaisyosya_tyusyutufree.tyusyutuseq',0);
--対象者抽出情報サブテーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_sub','tt_afatena','tt_afatena.atenano=tt_kktaisyosya_tyusyutu_sub.atenano',0);
--対象者抽出情報サブテーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_sub','tt_afjumin','tt_afjumin.atenano=tt_kktaisyosya_tyusyutu_sub.atenano',0);
--対象者抽出情報サブテーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_sub','tt_afkaigo','tt_afkaigo.atenano=tt_kktaisyosya_tyusyutu_sub.atenano',0);
--対象者抽出情報サブテーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_sub','tt_afkokihoken','tt_afkokihoken.atenano=tt_kktaisyosya_tyusyutu_sub.atenano',0);
--対象者抽出情報サブテーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_sub','tt_afkokuho','tt_afkokuho.atenano=tt_kktaisyosya_tyusyutu_sub.atenano',0);
--対象者抽出情報サブテーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_sub','tt_afseiho','tt_afseiho.atenano=tt_kktaisyosya_tyusyutu_sub.atenano',0);
--対象者抽出情報サブテーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_sub','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kktaisyosya_tyusyutu_sub.atenano',0);
--対象者抽出情報サブテーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_sub','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kktaisyosya_tyusyutu_sub.atenano',0);
--対象者抽出情報サブテーブル - 対象者抽出情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_sub','tt_kktaisyosya_tyusyutu','tt_kktaisyosya_tyusyutu.tyusyutuseq=tt_kktaisyosya_tyusyutu_sub.tyusyutuseq',0);
--対象者抽出情報サブテーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_sub','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kktaisyosya_tyusyutu_sub.atenano',0);
--対象者抽出情報サブテーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_sub','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kktaisyosya_tyusyutu_sub.atenano',0);
--対象者抽出情報サブテーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_sub','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kktaisyosya_tyusyutu_sub.atenano',0);
--対象者抽出情報サブテーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_sub','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kktaisyosya_tyusyutu_sub.atenano',0);
--対象者抽出情報サブ項目テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_afatena','tt_afatena.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano',0);
--対象者抽出情報サブ項目テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_afjumin','tt_afjumin.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano',0);
--対象者抽出情報サブ項目テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_afkaigo','tt_afkaigo.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano',0);
--対象者抽出情報サブ項目テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_afkokihoken','tt_afkokihoken.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano',0);
--対象者抽出情報サブ項目テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_afkokuho','tt_afkokuho.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano',0);
--対象者抽出情報サブ項目テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_afseiho','tt_afseiho.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano',0);
--対象者抽出情報サブ項目テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano',0);
--対象者抽出情報サブ項目テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano',0);
--対象者抽出情報サブ項目テーブル - 対象者抽出情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_kktaisyosya_tyusyutu','tt_kktaisyosya_tyusyutu.tyusyutuseq=tt_kktaisyosya_tyusyutu_subfree.tyusyutuseq',0);
--対象者抽出情報サブ項目テーブル - 対象者抽出情報サブテーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_kktaisyosya_tyusyutu_sub','tt_kktaisyosya_tyusyutu_sub.tyusyutuseq=tt_kktaisyosya_tyusyutu_subfree.tyusyutuseq AND tt_kktaisyosya_tyusyutu_sub.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano',0);
--対象者抽出情報サブ項目テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano',0);
--対象者抽出情報サブ項目テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano',0);
--対象者抽出情報サブ項目テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano',0);
--対象者抽出情報サブ項目テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano',0);
--対象者抽出情報サブ項目テーブル - 予防接種（フリー項目）個人テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_yskojinfree','tt_yskojinfree.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano AND tt_yskojinfree.itemcd=tt_kktaisyosya_tyusyutu_subfree.itemcd',0);
--対象者抽出情報サブ項目テーブル - 風しん抗体検査（フリー項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_ysfusinkotaifree','tt_ysfusinkotaifree.atenano=tt_kktaisyosya_tyusyutu_subfree.atenano AND tt_ysfusinkotaifree.itemcd=tt_kktaisyosya_tyusyutu_subfree.itemcd',0);
--発券情報テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhakken','tt_afatena','tt_afatena.atenano=tt_kkhakken.atenano',0);
--発券情報テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhakken','tt_afjumin','tt_afjumin.atenano=tt_kkhakken.atenano',0);
--発券情報テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhakken','tt_afkaigo','tt_afkaigo.atenano=tt_kkhakken.atenano',0);
--発券情報テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhakken','tt_afkokihoken','tt_afkokihoken.atenano=tt_kkhakken.atenano',0);
--発券情報テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhakken','tt_afkokuho','tt_afkokuho.atenano=tt_kkhakken.atenano',0);
--発券情報テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhakken','tt_afseiho','tt_afseiho.atenano=tt_kkhakken.atenano',0);
--発券情報テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhakken','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kkhakken.atenano',0);
--発券情報テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhakken','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kkhakken.atenano',0);
--発券情報テーブル - 抽出情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_kkhakken','tm_kktyusyutu','tm_kktyusyutu.tyusyututaisyocd=tt_kkhakken.tyusyututaisyocd',0);
--発券情報テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhakken','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kkhakken.atenano',0);
--発券情報テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhakken','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kkhakken.atenano',0);
--発券情報テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhakken','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kkhakken.atenano',0);
--発券情報テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkhakken','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kkhakken.atenano',0);
--対象者抽出情報項目コントロールマスタ - 抽出情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_kktaisyosya_tyusyutufreeitem','tm_kktyusyutu','tm_kktyusyutu.tyusyututaisyocd=tm_kktaisyosya_tyusyutufreeitem.tyusyututaisyocd',0);
--帳票発行履歴テーブル - 対象者抽出情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki','tt_kktaisyosya_tyusyutu','tt_kktaisyosya_tyusyutu.tyusyutuseq=tt_kkrpthakkorireki.tyusyutuseq',0);
--帳票発行履歴サブテーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki_sub','tt_afatena','tt_afatena.atenano=tt_kkrpthakkorireki_sub.atenano',0);
--帳票発行履歴サブテーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki_sub','tt_afjumin','tt_afjumin.atenano=tt_kkrpthakkorireki_sub.atenano',0);
--帳票発行履歴サブテーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki_sub','tt_afkaigo','tt_afkaigo.atenano=tt_kkrpthakkorireki_sub.atenano',0);
--帳票発行履歴サブテーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki_sub','tt_afkokihoken','tt_afkokihoken.atenano=tt_kkrpthakkorireki_sub.atenano',0);
--帳票発行履歴サブテーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki_sub','tt_afkokuho','tt_afkokuho.atenano=tt_kkrpthakkorireki_sub.atenano',0);
--帳票発行履歴サブテーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki_sub','tt_afseiho','tt_afseiho.atenano=tt_kkrpthakkorireki_sub.atenano',0);
--帳票発行履歴サブテーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki_sub','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_kkrpthakkorireki_sub.atenano',0);
--帳票発行履歴サブテーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki_sub','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_kkrpthakkorireki_sub.atenano',0);
--帳票発行履歴サブテーブル - 帳票発行履歴テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki_sub','tt_kkrpthakkorireki','tt_kkrpthakkorireki.hakkoseq=tt_kkrpthakkorireki_sub.hakkoseq',0);
--帳票発行履歴サブテーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki_sub','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_kkrpthakkorireki_sub.atenano',0);
--帳票発行履歴サブテーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki_sub','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_kkrpthakkorireki_sub.atenano',0);
--帳票発行履歴サブテーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki_sub','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_kkrpthakkorireki_sub.atenano',0);
--帳票発行履歴サブテーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_kkrpthakkorireki_sub','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_kkrpthakkorireki_sub.atenano',0);
--成人保健検診結果（フリー）項目コントロールマスタ - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_shfreeitem','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tm_shfreeitem.jigyocd',0);
--成人保健検診結果（フリー）項目コントロールマスタ - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_shfreeitem','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tm_shfreeitem.jigyocd',0);
--成人保健検診結果（フリー）項目コントロールマスタ - 予防接種（フリー項目：個人単位）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_shfreeitem','tm_yskojinfreeitem','tm_yskojinfreeitem.jigyocd=tm_shfreeitem.jigyocd AND tm_yskojinfreeitem.itemcd=tm_shfreeitem.itemcd',0);
--成人保健検診結果（フリー）項目コントロールマスタ - 予防接種（フリー項目：個人接種単位）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_shfreeitem','tm_yssessyufreeitem','tm_yssessyufreeitem.jigyocd=tm_shfreeitem.jigyocd AND tm_yssessyufreeitem.itemcd=tm_shfreeitem.itemcd',0);
--成人保健検診結果（フリー）項目コントロールマスタ - 予防接種依頼（フリー項目）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_shfreeitem','tm_yssessyuiraifreeitem','tm_yssessyuiraifreeitem.jigyocd=tm_shfreeitem.jigyocd AND tm_yssessyuiraifreeitem.itemcd=tm_shfreeitem.itemcd',0);
--成人保健検診結果（フリー）項目コントロールマスタ - 風しん抗体検査（フリー項目）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_shfreeitem','tm_ysfusinkotaifreeitem','tm_ysfusinkotaifreeitem.jigyocd=tm_shfreeitem.jigyocd AND tm_ysfusinkotaifreeitem.itemcd=tm_shfreeitem.itemcd',0);
--成人健（検）診事業マスタ - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_shkensinjigyo','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tm_shkensinjigyo.jigyocd',0);
--年度マスタ - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_shnendo','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tm_shnendo.jigyocd',0);
--年度マスタ - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_shnendo','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tm_shnendo.jigyocd',0);
--年度マスタ - 成人健（検）診予約日程事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_shnendo','tm_shyoyakujigyo','tm_shyoyakujigyo.nendo=tm_shnendo.nendo AND tm_shyoyakujigyo.jigyocd=tm_shnendo.jigyocd',0);
--成人保健検診結果（フリー項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_afatena','tt_afatena.atenano=tt_shfree.atenano',0);
--成人保健検診結果（フリー項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_afjumin','tt_afjumin.atenano=tt_shfree.atenano',0);
--成人保健検診結果（フリー項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_afkaigo','tt_afkaigo.atenano=tt_shfree.atenano',0);
--成人保健検診結果（フリー項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_afkokihoken','tt_afkokihoken.atenano=tt_shfree.atenano',0);
--成人保健検診結果（フリー項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_afkokuho','tt_afkokuho.atenano=tt_shfree.atenano',0);
--成人保健検診結果（フリー項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_afseiho','tt_afseiho.atenano=tt_shfree.atenano',0);
--成人保健検診結果（フリー項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_shfree.atenano',0);
--成人保健検診結果（フリー項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_shfree.atenano',0);
--成人保健検診結果（フリー項目）テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_shfree.jigyocd',0);
--成人保健検診結果（フリー項目）テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_shfree.jigyocd',0);
--成人保健検診結果（フリー項目）テーブル - 成人保健一次検診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_shkensin','tt_shkensin.jigyocd=tt_shfree.jigyocd AND tt_shkensin.atenano=tt_shfree.atenano AND tt_shkensin.nendo=tt_shfree.nendo AND tt_shkensin.kensinkaisu=tt_shfree.kensinkaisu',0);
--成人保健検診結果（フリー項目）テーブル - 成人保健精密検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_shseiken','tt_shseiken.jigyocd=tt_shfree.jigyocd AND tt_shseiken.atenano=tt_shfree.atenano AND tt_shseiken.nendo=tt_shfree.nendo AND tt_shseiken.kensinkaisu=tt_shfree.kensinkaisu',0);
--成人保健検診結果（フリー項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_shfree.atenano',0);
--成人保健検診結果（フリー項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_shfree.atenano',0);
--成人保健検診結果（フリー項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_shfree.atenano',0);
--成人保健検診結果（フリー項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shfree','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_shfree.atenano',0);
--受診拒否理由テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tt_afatena','tt_afatena.atenano=tt_shjyusinkyohiriyu.atenano',0);
--受診拒否理由テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tt_afjumin','tt_afjumin.atenano=tt_shjyusinkyohiriyu.atenano',0);
--受診拒否理由テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tt_afkaigo','tt_afkaigo.atenano=tt_shjyusinkyohiriyu.atenano',0);
--受診拒否理由テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tt_afkokihoken','tt_afkokihoken.atenano=tt_shjyusinkyohiriyu.atenano',0);
--受診拒否理由テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tt_afkokuho','tt_afkokuho.atenano=tt_shjyusinkyohiriyu.atenano',0);
--受診拒否理由テーブル - 連絡先テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tt_afrenrakusaki','tt_afrenrakusaki.atenano=tt_shjyusinkyohiriyu.atenano AND tt_afrenrakusaki.jigyocd=tt_shjyusinkyohiriyu.jigyocd',0);
--受診拒否理由テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tt_afseiho','tt_afseiho.atenano=tt_shjyusinkyohiriyu.atenano',0);
--受診拒否理由テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_shjyusinkyohiriyu.atenano',0);
--受診拒否理由テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_shjyusinkyohiriyu.atenano',0);
--受診拒否理由テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_shjyusinkyohiriyu.jigyocd',0);
--受診拒否理由テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_shjyusinkyohiriyu.jigyocd',0);
--受診拒否理由テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_shjyusinkyohiriyu.atenano',0);
--受診拒否理由テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_shjyusinkyohiriyu.atenano',0);
--受診拒否理由テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_shjyusinkyohiriyu.atenano',0);
--受診拒否理由テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shjyusinkyohiriyu','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_shjyusinkyohiriyu.atenano',0);
--成人保健一次検診結果（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tt_afatena','tt_afatena.atenano=tt_shkensin.atenano',0);
--成人保健一次検診結果（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tt_afjumin','tt_afjumin.atenano=tt_shkensin.atenano',0);
--成人保健一次検診結果（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tt_afkaigo','tt_afkaigo.atenano=tt_shkensin.atenano',0);
--成人保健一次検診結果（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tt_afkokihoken','tt_afkokihoken.atenano=tt_shkensin.atenano',0);
--成人保健一次検診結果（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tt_afkokuho','tt_afkokuho.atenano=tt_shkensin.atenano',0);
--成人保健一次検診結果（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tt_afseiho','tt_afseiho.atenano=tt_shkensin.atenano',0);
--成人保健一次検診結果（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_shkensin.atenano',0);
--成人保健一次検診結果（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_shkensin.atenano',0);
--成人保健一次検診結果（固定項目）テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_shkensin.jigyocd',0);
--成人保健一次検診結果（固定項目）テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_shkensin.jigyocd',0);
--成人保健一次検診結果（固定項目）テーブル - 成人保健精密検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tt_shseiken','tt_shseiken.jigyocd=tt_shkensin.jigyocd AND tt_shseiken.atenano=tt_shkensin.atenano AND tt_shseiken.nendo=tt_shkensin.nendo AND tt_shseiken.kensinkaisu=tt_shkensin.kensinkaisu',0);
--成人保健一次検診結果（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_shkensin.atenano',0);
--成人保健一次検診結果（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_shkensin.atenano',0);
--成人保健一次検診結果（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_shkensin.atenano',0);
--成人保健一次検診結果（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensin','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_shkensin.atenano',0);
--成人保健精密検査結果（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tt_afatena','tt_afatena.atenano=tt_shseiken.atenano',0);
--成人保健精密検査結果（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tt_afjumin','tt_afjumin.atenano=tt_shseiken.atenano',0);
--成人保健精密検査結果（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tt_afkaigo','tt_afkaigo.atenano=tt_shseiken.atenano',0);
--成人保健精密検査結果（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tt_afkokihoken','tt_afkokihoken.atenano=tt_shseiken.atenano',0);
--成人保健精密検査結果（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tt_afkokuho','tt_afkokuho.atenano=tt_shseiken.atenano',0);
--成人保健精密検査結果（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tt_afseiho','tt_afseiho.atenano=tt_shseiken.atenano',0);
--成人保健精密検査結果（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_shseiken.atenano',0);
--成人保健精密検査結果（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_shseiken.atenano',0);
--成人保健精密検査結果（固定項目）テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_shseiken.jigyocd',0);
--成人保健精密検査結果（固定項目）テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_shseiken.jigyocd',0);
--成人保健精密検査結果（固定項目）テーブル - 成人保健一次検診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tt_shkensin','tt_shkensin.jigyocd=tt_shseiken.jigyocd AND tt_shkensin.atenano=tt_shseiken.atenano AND tt_shkensin.nendo=tt_shseiken.nendo AND tt_shkensin.kensinkaisu=tt_shseiken.kensinkaisu',0);
--成人保健精密検査結果（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_shseiken.atenano',0);
--成人保健精密検査結果（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_shseiken.atenano',0);
--成人保健精密検査結果（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_shseiken.atenano',0);
--成人保健精密検査結果（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shseiken','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_shseiken.atenano',0);
--健（検）診予定テーブル - 会場情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyotei','tm_afkaijo','tm_afkaijo.kaijocd=tt_shkensinyotei.kaijocd',0);
--健（検）診予定テーブル - 医療機関マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyotei','tm_afkikan','tm_afkikan.kikancd=tt_shkensinyotei.kikancd',0);
--健（検）診予定テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyotei','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_shkensinyotei.jigyocd',0);
--健（検）診予定テーブル - 事業予定テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyotei','tt_kkjigyoyotei','tt_kkjigyoyotei.nitteino=tt_shkensinyotei.nitteino',0);
--健（検）診予定テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyotei','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_shkensinyotei.jigyocd',0);
--健（検）診予定詳細テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoteisyosai','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_shkensinyoteisyosai.jigyocd',0);
--健（検）診予定詳細テーブル - 事業予定テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoteisyosai','tt_kkjigyoyotei','tt_kkjigyoyotei.nitteino=tt_shkensinyoteisyosai.nitteino',0);
--健（検）診予定詳細テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoteisyosai','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_shkensinyoteisyosai.jigyocd',0);
--健（検）診予定詳細テーブル - 健（検）診予定テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoteisyosai','tt_shkensinyotei','tt_shkensinyotei.nendo=tt_shkensinyoteisyosai.nendo AND tt_shkensinyotei.nitteino=tt_shkensinyoteisyosai.nitteino',0);
--健（検）診予定担当者テーブル - 事業従事者（担当者）情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyotei_staff','tm_afstaff','tm_afstaff.staffid=tt_shkensinyotei_staff.staffid',0);
--健（検）診予定担当者テーブル - 事業予定テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyotei_staff','tt_kkjigyoyotei','tt_kkjigyoyotei.nitteino=tt_shkensinyotei_staff.nitteino',0);
--健（検）診予定担当者テーブル - 事業予定担当者テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyotei_staff','tt_kkjigyoyotei_staff','tt_kkjigyoyotei_staff.nitteino=tt_shkensinyotei_staff.nitteino AND tt_kkjigyoyotei_staff.staffid=tt_shkensinyotei_staff.staffid',0);
--健（検）診予定担当者テーブル - 健（検）診予定テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyotei_staff','tt_shkensinyotei','tt_shkensinyotei.nendo=tt_shkensinyotei_staff.nendo AND tt_shkensinyotei.nitteino=tt_shkensinyotei_staff.nitteino',0);
--健（検）診予約希望者テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_afatena','tt_afatena.atenano=tt_shkensinyoyakukibosya.atenano',0);
--健（検）診予約希望者テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_afjumin','tt_afjumin.atenano=tt_shkensinyoyakukibosya.atenano',0);
--健（検）診予約希望者テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_afkaigo','tt_afkaigo.atenano=tt_shkensinyoyakukibosya.atenano',0);
--健（検）診予約希望者テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_afkokihoken','tt_afkokihoken.atenano=tt_shkensinyoyakukibosya.atenano',0);
--健（検）診予約希望者テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_afkokuho','tt_afkokuho.atenano=tt_shkensinyoyakukibosya.atenano',0);
--健（検）診予約希望者テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_afseiho','tt_afseiho.atenano=tt_shkensinyoyakukibosya.atenano',0);
--健（検）診予約希望者テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_shkensinyoyakukibosya.atenano',0);
--健（検）診予約希望者テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_shkensinyoyakukibosya.atenano',0);
--健（検）診予約希望者テーブル - 事業予定テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_kkjigyoyotei','tt_kkjigyoyotei.nitteino=tt_shkensinyoyakukibosya.nitteino',0);
--健（検）診予約希望者テーブル - 事業予約希望者テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_kkjigyoyoyakukibosya','tt_kkjigyoyoyakukibosya.nitteino=tt_shkensinyoyakukibosya.nitteino AND tt_kkjigyoyoyakukibosya.atenano=tt_shkensinyoyakukibosya.atenano',0);
--健（検）診予約希望者テーブル - 健（検）診予定テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_shkensinyotei','tt_shkensinyotei.nendo=tt_shkensinyoyakukibosya.nendo AND tt_shkensinyotei.nitteino=tt_shkensinyoyakukibosya.nitteino',0);
--健（検）診予約希望者テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_shkensinyoyakukibosya.atenano',0);
--健（検）診予約希望者テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_shkensinyoyakukibosya.atenano',0);
--健（検）診予約希望者テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_shkensinyoyakukibosya.atenano',0);
--健（検）診予約希望者テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinyoyakukibosya','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_shkensinyoyakukibosya.atenano',0);
--健（検）診予約希望者詳細テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_afatena','tt_afatena.atenano=tt_shkensinkibosyasyosai.atenano',0);
--健（検）診予約希望者詳細テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_afjumin','tt_afjumin.atenano=tt_shkensinkibosyasyosai.atenano',0);
--健（検）診予約希望者詳細テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_afkaigo','tt_afkaigo.atenano=tt_shkensinkibosyasyosai.atenano',0);
--健（検）診予約希望者詳細テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_afkokihoken','tt_afkokihoken.atenano=tt_shkensinkibosyasyosai.atenano',0);
--健（検）診予約希望者詳細テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_afkokuho','tt_afkokuho.atenano=tt_shkensinkibosyasyosai.atenano',0);
--健（検）診予約希望者詳細テーブル - 連絡先テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_afrenrakusaki','tt_afrenrakusaki.atenano=tt_shkensinkibosyasyosai.atenano AND tt_afrenrakusaki.jigyocd=tt_shkensinkibosyasyosai.jigyocd',0);
--健（検）診予約希望者詳細テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_afseiho','tt_afseiho.atenano=tt_shkensinkibosyasyosai.atenano',0);
--健（検）診予約希望者詳細テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_shkensinkibosyasyosai.atenano',0);
--健（検）診予約希望者詳細テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_shkensinkibosyasyosai.atenano',0);
--健（検）診予約希望者詳細テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_shkensinkibosyasyosai.jigyocd',0);
--健（検）診予約希望者詳細テーブル - 事業予定テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_kkjigyoyotei','tt_kkjigyoyotei.nitteino=tt_shkensinkibosyasyosai.nitteino',0);
--健（検）診予約希望者詳細テーブル - 事業予約希望者テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_kkjigyoyoyakukibosya','tt_kkjigyoyoyakukibosya.nitteino=tt_shkensinkibosyasyosai.nitteino AND tt_kkjigyoyoyakukibosya.atenano=tt_shkensinkibosyasyosai.atenano',0);
--健（検）診予約希望者詳細テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_shkensinkibosyasyosai.jigyocd',0);
--健（検）診予約希望者詳細テーブル - 健（検）診予定テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_shkensinyotei','tt_shkensinyotei.nendo=tt_shkensinkibosyasyosai.nendo AND tt_shkensinyotei.nitteino=tt_shkensinkibosyasyosai.nitteino',0);
--健（検）診予約希望者詳細テーブル - 健（検）診予約希望者テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_shkensinyoyakukibosya','tt_shkensinyoyakukibosya.nendo=tt_shkensinkibosyasyosai.nendo AND tt_shkensinyoyakukibosya.nitteino=tt_shkensinkibosyasyosai.nitteino AND tt_shkensinyoyakukibosya.atenano=tt_shkensinkibosyasyosai.atenano',0);
--健（検）診予約希望者詳細テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_shkensinkibosyasyosai.atenano',0);
--健（検）診予約希望者詳細テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_shkensinkibosyasyosai.atenano',0);
--健（検）診予約希望者詳細テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_shkensinkibosyasyosai.atenano',0);
--健（検）診予約希望者詳細テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_shkensinkibosyasyosai','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_shkensinkibosyasyosai.atenano',0);
--成人健（検）診予約日程事業マスタ - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_shyoyakujigyo','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tm_shyoyakujigyo.jigyocd',0);
--成人健（検）診予約日程事業マスタ - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_shyoyakujigyo','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tm_shyoyakujigyo.jigyocd',0);
--成人健（検）診予約日程事業サブマスタ - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_shyoyakujigyo_sub','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tm_shyoyakujigyo_sub.jigyocd',0);
--成人健（検）診予約日程事業サブマスタ - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_shyoyakujigyo_sub','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tm_shyoyakujigyo_sub.jigyocd',0);
--成人健（検）診予約日程事業サブマスタ - 成人健（検）診予約日程事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_shyoyakujigyo_sub','tm_shyoyakujigyo','tm_shyoyakujigyo.nendo=tm_shyoyakujigyo_sub.nendo AND tm_shyoyakujigyo.jigyocd=tm_shyoyakujigyo_sub.jigyocd',0);
--母子保健詳細タブマスタ - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkksyosaitab','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tm_bhkksyosaitab.jigyocd',0);
--母子保健詳細タブマスタ - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkksyosaitab','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tm_bhkksyosaitab.jigyocd',0);
--母子保健詳細タブマスタ - 母子保健詳細メニューマスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkksyosaitab','tm_bhkksyosaimenyu','tm_bhkksyosaimenyu.bosikbn=tm_bhkksyosaitab.bosikbn AND tm_bhkksyosaimenyu.bhsyosaimenyucd=tm_bhkksyosaitab.bhsyosaimenyucd',0);
--母子保健事業マスタ - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkkjigyo','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tm_bhkkjigyo.jigyocd',0);
--母子保健事業マスタ - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkkjigyo','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tm_bhkkjigyo.jigyocd',0);
--母子保健（フリー）項目コントロールマスタ - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkkfreeitem','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tm_bhkkfreeitem.jigyocd',0);
--母子保健（フリー）項目コントロールマスタ - 成人保健検診結果（フリー）項目コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkkfreeitem','tm_shfreeitem','tm_shfreeitem.jigyocd=tm_bhkkfreeitem.jigyocd AND tm_shfreeitem.itemcd=tm_bhkkfreeitem.itemcd',0);
--母子保健（フリー）項目コントロールマスタ - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkkfreeitem','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tm_bhkkfreeitem.jigyocd',0);
--母子保健（フリー）項目コントロールマスタ - 母子保健事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkkfreeitem','tm_bhkkjigyo','tm_bhkkjigyo.bosikbn=tm_bhkkfreeitem.bosikbn AND tm_bhkkjigyo.jigyocd=tm_bhkkfreeitem.jigyocd',0);
--母子保健（フリー）項目コントロールマスタ - 予防接種（フリー項目：個人単位）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkkfreeitem','tm_yskojinfreeitem','tm_yskojinfreeitem.jigyocd=tm_bhkkfreeitem.jigyocd AND tm_yskojinfreeitem.itemcd=tm_bhkkfreeitem.itemcd',0);
--母子保健（フリー）項目コントロールマスタ - 予防接種（フリー項目：個人接種単位）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkkfreeitem','tm_yssessyufreeitem','tm_yssessyufreeitem.jigyocd=tm_bhkkfreeitem.jigyocd AND tm_yssessyufreeitem.itemcd=tm_bhkkfreeitem.itemcd',0);
--母子保健（フリー）項目コントロールマスタ - 予防接種依頼（フリー項目）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkkfreeitem','tm_yssessyuiraifreeitem','tm_yssessyuiraifreeitem.jigyocd=tm_bhkkfreeitem.jigyocd AND tm_yssessyuiraifreeitem.itemcd=tm_bhkkfreeitem.itemcd',0);
--母子保健（フリー）項目コントロールマスタ - 風しん抗体検査（フリー項目）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkkfreeitem','tm_ysfusinkotaifreeitem','tm_ysfusinkotaifreeitem.jigyocd=tm_bhkkfreeitem.jigyocd AND tm_ysfusinkotaifreeitem.itemcd=tm_bhkkfreeitem.itemcd',0);
--乳幼児（フリー）項目テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_afatena','tt_afatena.atenano=tt_bhnyfree.atenano',0);
--乳幼児（フリー）項目テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_afjumin','tt_afjumin.atenano=tt_bhnyfree.atenano',0);
--乳幼児（フリー）項目テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_afkaigo','tt_afkaigo.atenano=tt_bhnyfree.atenano',0);
--乳幼児（フリー）項目テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnyfree.atenano',0);
--乳幼児（フリー）項目テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_afkokuho','tt_afkokuho.atenano=tt_bhnyfree.atenano',0);
--乳幼児（フリー）項目テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_afseiho','tt_afseiho.atenano=tt_bhnyfree.atenano',0);
--乳幼児（フリー）項目テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnyfree.atenano',0);
--乳幼児（フリー）項目テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnyfree.atenano',0);
--乳幼児（フリー）項目テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_bhnyfree.jigyocd',0);
--乳幼児（フリー）項目テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_bhnyfree.jigyocd',0);
--乳幼児（フリー）項目テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnyfree.atenano',0);
--乳幼児（フリー）項目テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnyfree.atenano',0);
--乳幼児（フリー）項目テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_bhnyfree.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_bhnyfree.edano',0);
--乳幼児（フリー）項目テーブル - 独自施策（子）（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_bhnydokujisesaku','tt_bhnydokujisesaku.jigyocd=tt_bhnyfree.jigyocd AND tt_bhnydokujisesaku.atenano=tt_bhnyfree.atenano AND tt_bhnydokujisesaku.edano=tt_bhnyfree.edano',0);
--乳幼児（フリー）項目テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_bhnyfree.atenano AND tt_bhnyseikenkekka.edano=tt_bhnyfree.edano',0);
--乳幼児（フリー）項目テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnyfree.atenano',0);
--乳幼児（フリー）項目テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_bhnyfree.atenano AND tt_bhnymijusinsyakansyo.edano=tt_bhnyfree.edano',0);
--乳幼児（フリー）項目テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_bhnyfree.atenano AND tt_bhnyseikenirai.edano=tt_bhnyfree.edano',0);
--乳幼児（フリー）項目テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_bhnyfree.atenano AND tt_yssessyuirai.edano=tt_bhnyfree.edano',0);
--乳幼児（フリー）項目テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnyfree.atenano',0);
--乳幼児（フリー）項目テーブル - 予防接種依頼（フリー項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyfree','tt_yssessyuiraifree','tt_yssessyuiraifree.atenano=tt_bhnyfree.atenano AND tt_yssessyuiraifree.edano=tt_bhnyfree.edano AND tt_yssessyuiraifree.itemcd=tt_bhnyfree.itemcd',0);
--妊産婦（フリー）項目テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_afatena','tt_afatena.atenano=tt_bhnsfree.atenano',0);
--妊産婦（フリー）項目テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_afjumin','tt_afjumin.atenano=tt_bhnsfree.atenano',0);
--妊産婦（フリー）項目テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_afkaigo','tt_afkaigo.atenano=tt_bhnsfree.atenano',0);
--妊産婦（フリー）項目テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnsfree.atenano',0);
--妊産婦（フリー）項目テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_afkokuho','tt_afkokuho.atenano=tt_bhnsfree.atenano',0);
--妊産婦（フリー）項目テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_afseiho','tt_afseiho.atenano=tt_bhnsfree.atenano',0);
--妊産婦（フリー）項目テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnsfree.atenano',0);
--妊産婦（フリー）項目テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnsfree.atenano',0);
--妊産婦（フリー）項目テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_bhnsfree.jigyocd',0);
--妊産婦（フリー）項目テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_bhnsfree.jigyocd',0);
--妊産婦（フリー）項目テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnsfree.atenano',0);
--妊産婦（フリー）項目テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnsfree.atenano',0);
--妊産婦（フリー）項目テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnsfree.atenano',0);
--妊産婦（フリー）項目テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnsfree.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnsfree.torokuno',0);
--妊産婦（フリー）項目テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnsfree.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnsfree.torokuno',0);
--妊産婦（フリー）項目テーブル - 母子健康手帳交付（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_bhnsbosikenkotetyokofu','tt_bhnsbosikenkotetyokofu.atenano=tt_bhnsfree.atenano AND tt_bhnsbosikenkotetyokofu.torokuno=tt_bhnsfree.torokuno AND tt_bhnsbosikenkotetyokofu.torokunorenban=tt_bhnsfree.torokunorenban',0);
--妊産婦（フリー）項目テーブル - 出産の状態に係る（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_bhnssyussanjotai','tt_bhnssyussanjotai.atenano=tt_bhnsfree.atenano AND tt_bhnssyussanjotai.torokuno=tt_bhnsfree.torokuno AND tt_bhnssyussanjotai.torokunorenban=tt_bhnsfree.torokunorenban',0);
--妊産婦（フリー）項目テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsfree','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnsfree.atenano',0);
--出生時状況（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_afatena','tt_afatena.atenano=tt_bhnysyussyojijokyo.atenano',0);
--出生時状況（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_afjumin','tt_afjumin.atenano=tt_bhnysyussyojijokyo.atenano',0);
--出生時状況（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_afkaigo','tt_afkaigo.atenano=tt_bhnysyussyojijokyo.atenano',0);
--出生時状況（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnysyussyojijokyo.atenano',0);
--出生時状況（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_afkokuho','tt_afkokuho.atenano=tt_bhnysyussyojijokyo.atenano',0);
--出生時状況（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_afseiho','tt_afseiho.atenano=tt_bhnysyussyojijokyo.atenano',0);
--出生時状況（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnysyussyojijokyo.atenano',0);
--出生時状況（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnysyussyojijokyo.atenano',0);
--出生時状況（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnysyussyojijokyo.atenano',0);
--出生時状況（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnysyussyojijokyo.atenano',0);
--出生時状況（固定項目）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnysyussyojijokyo.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnysyussyojijokyo.torokuno',0);
--出生時状況（固定項目）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnysyussyojijokyo.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnysyussyojijokyo.torokuno',0);
--出生時状況（固定項目）テーブル - 母子健康手帳交付（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_bhnsbosikenkotetyokofu','tt_bhnsbosikenkotetyokofu.atenano=tt_bhnysyussyojijokyo.atenano AND tt_bhnsbosikenkotetyokofu.torokuno=tt_bhnysyussyojijokyo.torokuno AND tt_bhnsbosikenkotetyokofu.torokunorenban=tt_bhnysyussyojijokyo.torokunorenban',0);
--出生時状況（固定項目）テーブル - 出産の状態に係る（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_bhnssyussanjotai','tt_bhnssyussanjotai.atenano=tt_bhnysyussyojijokyo.atenano AND tt_bhnssyussanjotai.torokuno=tt_bhnysyussyojijokyo.torokuno AND tt_bhnssyussanjotai.torokunorenban=tt_bhnysyussyojijokyo.torokunorenban',0);
--出生時状況（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysyussyojijokyo','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnysyussyojijokyo.atenano',0);
--新生児聴覚検査結果（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensakekka','tt_afatena','tt_afatena.atenano=tt_bhnytyokakukensakekka.atenano',0);
--新生児聴覚検査結果（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensakekka','tt_afjumin','tt_afjumin.atenano=tt_bhnytyokakukensakekka.atenano',0);
--新生児聴覚検査結果（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensakekka','tt_afkaigo','tt_afkaigo.atenano=tt_bhnytyokakukensakekka.atenano',0);
--新生児聴覚検査結果（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensakekka','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnytyokakukensakekka.atenano',0);
--新生児聴覚検査結果（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensakekka','tt_afkokuho','tt_afkokuho.atenano=tt_bhnytyokakukensakekka.atenano',0);
--新生児聴覚検査結果（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensakekka','tt_afseiho','tt_afseiho.atenano=tt_bhnytyokakukensakekka.atenano',0);
--新生児聴覚検査結果（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensakekka','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnytyokakukensakekka.atenano',0);
--新生児聴覚検査結果（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensakekka','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnytyokakukensakekka.atenano',0);
--新生児聴覚検査結果（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensakekka','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnytyokakukensakekka.atenano',0);
--新生児聴覚検査結果（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensakekka','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnytyokakukensakekka.atenano',0);
--新生児聴覚検査結果（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensakekka','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnytyokakukensakekka.atenano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_afatena','tt_afatena.atenano=tt_bhnytyokakukensahiyojosei.atenano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_afjumin','tt_afjumin.atenano=tt_bhnytyokakukensahiyojosei.atenano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_afkaigo','tt_afkaigo.atenano=tt_bhnytyokakukensahiyojosei.atenano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnytyokakukensahiyojosei.atenano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_afkokuho','tt_afkokuho.atenano=tt_bhnytyokakukensahiyojosei.atenano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_afseiho','tt_afseiho.atenano=tt_bhnytyokakukensahiyojosei.atenano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnytyokakukensahiyojosei.atenano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnytyokakukensahiyojosei.atenano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnytyokakukensahiyojosei.atenano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnytyokakukensahiyojosei.atenano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_bhnytyokakukensahiyojosei.atenano AND tt_bhnyseikenkekka.edano=tt_bhnytyokakukensahiyojosei.edano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnytyokakukensahiyojosei.atenano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_bhnytyokakukensahiyojosei.atenano AND tt_bhnymijusinsyakansyo.edano=tt_bhnytyokakukensahiyojosei.edano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_bhnytyokakukensahiyojosei.atenano AND tt_bhnyseikenirai.edano=tt_bhnytyokakukensahiyojosei.edano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_bhnytyokakukensahiyojosei.atenano AND tt_yssessyuirai.edano=tt_bhnytyokakukensahiyojosei.edano',0);
--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnytyokakukensahiyojosei','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnytyokakukensahiyojosei.atenano',0);
--乳幼児健診結果（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_afatena','tt_afatena.atenano=tt_bhnykensinkekka.atenano',0);
--乳幼児健診結果（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_afjumin','tt_afjumin.atenano=tt_bhnykensinkekka.atenano',0);
--乳幼児健診結果（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_afkaigo','tt_afkaigo.atenano=tt_bhnykensinkekka.atenano',0);
--乳幼児健診結果（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnykensinkekka.atenano',0);
--乳幼児健診結果（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_afkokuho','tt_afkokuho.atenano=tt_bhnykensinkekka.atenano',0);
--乳幼児健診結果（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_afseiho','tt_afseiho.atenano=tt_bhnykensinkekka.atenano',0);
--乳幼児健診結果（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnykensinkekka.atenano',0);
--乳幼児健診結果（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnykensinkekka.atenano',0);
--乳幼児健診結果（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnykensinkekka.atenano',0);
--乳幼児健診結果（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnykensinkekka.atenano',0);
--乳幼児健診結果（固定項目）テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_bhnykensinkekka.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_bhnykensinkekka.edano',0);
--乳幼児健診結果（固定項目）テーブル - 乳幼児健診アンケート（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_bhnykensinanketo','tt_bhnykensinanketo.nykensincd=tt_bhnykensinkekka.nykensincd AND tt_bhnykensinanketo.atenano=tt_bhnykensinkekka.atenano AND tt_bhnykensinanketo.edano=tt_bhnykensinkekka.edano',0);
--乳幼児健診結果（固定項目）テーブル - 乳幼児歯科健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_bhnysikakensinkekka','tt_bhnysikakensinkekka.nykensincd=tt_bhnykensinkekka.nykensincd AND tt_bhnysikakensinkekka.atenano=tt_bhnykensinkekka.atenano AND tt_bhnysikakensinkekka.edano=tt_bhnykensinkekka.edano',0);
--乳幼児健診結果（固定項目）テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_bhnykensinkekka.atenano AND tt_bhnyseikenkekka.edano=tt_bhnykensinkekka.edano',0);
--乳幼児健診結果（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnykensinkekka.atenano',0);
--乳幼児健診結果（固定項目）テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_bhnykensinkekka.atenano AND tt_bhnymijusinsyakansyo.edano=tt_bhnykensinkekka.edano',0);
--乳幼児健診結果（固定項目）テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_bhnykensinkekka.atenano AND tt_bhnyseikenirai.edano=tt_bhnykensinkekka.edano',0);
--乳幼児健診結果（固定項目）テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_bhnykensinkekka.atenano AND tt_yssessyuirai.edano=tt_bhnykensinkekka.edano',0);
--乳幼児健診結果（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinkekka','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnykensinkekka.atenano',0);
--乳幼児健診アンケート（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_afatena','tt_afatena.atenano=tt_bhnykensinanketo.atenano',0);
--乳幼児健診アンケート（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_afjumin','tt_afjumin.atenano=tt_bhnykensinanketo.atenano',0);
--乳幼児健診アンケート（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_afkaigo','tt_afkaigo.atenano=tt_bhnykensinanketo.atenano',0);
--乳幼児健診アンケート（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnykensinanketo.atenano',0);
--乳幼児健診アンケート（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_afkokuho','tt_afkokuho.atenano=tt_bhnykensinanketo.atenano',0);
--乳幼児健診アンケート（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_afseiho','tt_afseiho.atenano=tt_bhnykensinanketo.atenano',0);
--乳幼児健診アンケート（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnykensinanketo.atenano',0);
--乳幼児健診アンケート（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnykensinanketo.atenano',0);
--乳幼児健診アンケート（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnykensinanketo.atenano',0);
--乳幼児健診アンケート（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnykensinanketo.atenano',0);
--乳幼児健診アンケート（固定項目）テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_bhnykensinanketo.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_bhnykensinanketo.edano',0);
--乳幼児健診アンケート（固定項目）テーブル - 乳幼児健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_bhnykensinkekka','tt_bhnykensinkekka.nykensincd=tt_bhnykensinanketo.nykensincd AND tt_bhnykensinkekka.atenano=tt_bhnykensinanketo.atenano AND tt_bhnykensinkekka.edano=tt_bhnykensinanketo.edano',0);
--乳幼児健診アンケート（固定項目）テーブル - 乳幼児歯科健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_bhnysikakensinkekka','tt_bhnysikakensinkekka.nykensincd=tt_bhnykensinanketo.nykensincd AND tt_bhnysikakensinkekka.atenano=tt_bhnykensinanketo.atenano AND tt_bhnysikakensinkekka.edano=tt_bhnykensinanketo.edano',0);
--乳幼児健診アンケート（固定項目）テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_bhnykensinanketo.atenano AND tt_bhnyseikenkekka.edano=tt_bhnykensinanketo.edano',0);
--乳幼児健診アンケート（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnykensinanketo.atenano',0);
--乳幼児健診アンケート（固定項目）テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_bhnykensinanketo.atenano AND tt_bhnymijusinsyakansyo.edano=tt_bhnykensinanketo.edano',0);
--乳幼児健診アンケート（固定項目）テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_bhnykensinanketo.atenano AND tt_bhnyseikenirai.edano=tt_bhnykensinanketo.edano',0);
--乳幼児健診アンケート（固定項目）テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_bhnykensinanketo.atenano AND tt_yssessyuirai.edano=tt_bhnykensinanketo.edano',0);
--乳幼児健診アンケート（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinanketo','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnykensinanketo.atenano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_afatena','tt_afatena.atenano=tt_bhnysikakensinkekka.atenano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_afjumin','tt_afjumin.atenano=tt_bhnysikakensinkekka.atenano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_afkaigo','tt_afkaigo.atenano=tt_bhnysikakensinkekka.atenano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnysikakensinkekka.atenano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_afkokuho','tt_afkokuho.atenano=tt_bhnysikakensinkekka.atenano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_afseiho','tt_afseiho.atenano=tt_bhnysikakensinkekka.atenano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnysikakensinkekka.atenano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnysikakensinkekka.atenano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnysikakensinkekka.atenano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnysikakensinkekka.atenano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_bhnysikakensinkekka.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_bhnysikakensinkekka.edano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 乳幼児健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_bhnykensinkekka','tt_bhnykensinkekka.nykensincd=tt_bhnysikakensinkekka.nykensincd AND tt_bhnykensinkekka.atenano=tt_bhnysikakensinkekka.atenano AND tt_bhnykensinkekka.edano=tt_bhnysikakensinkekka.edano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 乳幼児健診アンケート（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_bhnykensinanketo','tt_bhnykensinanketo.nykensincd=tt_bhnysikakensinkekka.nykensincd AND tt_bhnykensinanketo.atenano=tt_bhnysikakensinkekka.atenano AND tt_bhnykensinanketo.edano=tt_bhnysikakensinkekka.edano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_bhnysikakensinkekka.atenano AND tt_bhnyseikenkekka.edano=tt_bhnysikakensinkekka.edano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnysikakensinkekka.atenano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_bhnysikakensinkekka.atenano AND tt_bhnymijusinsyakansyo.edano=tt_bhnysikakensinkekka.edano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_bhnysikakensinkekka.atenano AND tt_bhnyseikenirai.edano=tt_bhnysikakensinkekka.edano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_bhnysikakensinkekka.atenano AND tt_yssessyuirai.edano=tt_bhnysikakensinkekka.edano',0);
--乳幼児歯科健診結果（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnysikakensinkekka','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnysikakensinkekka.atenano',0);
--独自施策（子）（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_afatena','tt_afatena.atenano=tt_bhnydokujisesaku.atenano',0);
--独自施策（子）（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_afjumin','tt_afjumin.atenano=tt_bhnydokujisesaku.atenano',0);
--独自施策（子）（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_afkaigo','tt_afkaigo.atenano=tt_bhnydokujisesaku.atenano',0);
--独自施策（子）（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnydokujisesaku.atenano',0);
--独自施策（子）（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_afkokuho','tt_afkokuho.atenano=tt_bhnydokujisesaku.atenano',0);
--独自施策（子）（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_afseiho','tt_afseiho.atenano=tt_bhnydokujisesaku.atenano',0);
--独自施策（子）（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnydokujisesaku.atenano',0);
--独自施策（子）（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnydokujisesaku.atenano',0);
--独自施策（子）（固定項目）テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_bhnydokujisesaku.jigyocd',0);
--独自施策（子）（固定項目）テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_bhnydokujisesaku.jigyocd',0);
--独自施策（子）（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnydokujisesaku.atenano',0);
--独自施策（子）（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnydokujisesaku.atenano',0);
--独自施策（子）（固定項目）テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_bhnydokujisesaku.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_bhnydokujisesaku.edano',0);
--独自施策（子）（固定項目）テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_bhnydokujisesaku.atenano AND tt_bhnyseikenkekka.edano=tt_bhnydokujisesaku.edano',0);
--独自施策（子）（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnydokujisesaku.atenano',0);
--独自施策（子）（固定項目）テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_bhnydokujisesaku.atenano AND tt_bhnymijusinsyakansyo.edano=tt_bhnydokujisesaku.edano',0);
--独自施策（子）（固定項目）テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_bhnydokujisesaku.atenano AND tt_bhnyseikenirai.edano=tt_bhnydokujisesaku.edano',0);
--独自施策（子）（固定項目）テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_bhnydokujisesaku.atenano AND tt_yssessyuirai.edano=tt_bhnydokujisesaku.edano',0);
--独自施策（子）（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnydokujisesaku','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnydokujisesaku.atenano',0);
--乳幼児精密健診結果（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_afatena','tt_afatena.atenano=tt_bhnyseikenkekka.atenano',0);
--乳幼児精密健診結果（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_afjumin','tt_afjumin.atenano=tt_bhnyseikenkekka.atenano',0);
--乳幼児精密健診結果（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_afkaigo','tt_afkaigo.atenano=tt_bhnyseikenkekka.atenano',0);
--乳幼児精密健診結果（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnyseikenkekka.atenano',0);
--乳幼児精密健診結果（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_afkokuho','tt_afkokuho.atenano=tt_bhnyseikenkekka.atenano',0);
--乳幼児精密健診結果（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_afseiho','tt_afseiho.atenano=tt_bhnyseikenkekka.atenano',0);
--乳幼児精密健診結果（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnyseikenkekka.atenano',0);
--乳幼児精密健診結果（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnyseikenkekka.atenano',0);
--乳幼児精密健診結果（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnyseikenkekka.atenano',0);
--乳幼児精密健診結果（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnyseikenkekka.atenano',0);
--乳幼児精密健診結果（固定項目）テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_bhnyseikenkekka.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_bhnyseikenkekka.edano',0);
--乳幼児精密健診結果（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnyseikenkekka.atenano',0);
--乳幼児精密健診結果（固定項目）テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_bhnyseikenkekka.atenano AND tt_bhnymijusinsyakansyo.edano=tt_bhnyseikenkekka.edano',0);
--乳幼児精密健診結果（固定項目）テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_bhnyseikenkekka.atenano AND tt_bhnyseikenirai.edano=tt_bhnyseikenkekka.edano',0);
--乳幼児精密健診結果（固定項目）テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_bhnyseikenkekka.atenano AND tt_yssessyuirai.edano=tt_bhnyseikenkekka.edano',0);
--乳幼児精密健診結果（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenkekka','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnyseikenkekka.atenano',0);
--健診受診履歴（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinjusinreki','tt_afatena','tt_afatena.atenano=tt_bhnykensinjusinreki.atenano',0);
--健診受診履歴（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinjusinreki','tt_afjumin','tt_afjumin.atenano=tt_bhnykensinjusinreki.atenano',0);
--健診受診履歴（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinjusinreki','tt_afkaigo','tt_afkaigo.atenano=tt_bhnykensinjusinreki.atenano',0);
--健診受診履歴（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinjusinreki','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnykensinjusinreki.atenano',0);
--健診受診履歴（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinjusinreki','tt_afkokuho','tt_afkokuho.atenano=tt_bhnykensinjusinreki.atenano',0);
--健診受診履歴（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinjusinreki','tt_afseiho','tt_afseiho.atenano=tt_bhnykensinjusinreki.atenano',0);
--健診受診履歴（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinjusinreki','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnykensinjusinreki.atenano',0);
--健診受診履歴（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinjusinreki','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnykensinjusinreki.atenano',0);
--健診受診履歴（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinjusinreki','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnykensinjusinreki.atenano',0);
--健診受診履歴（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinjusinreki','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnykensinjusinreki.atenano',0);
--健診受診履歴（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnykensinjusinreki','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnykensinjusinreki.atenano',0);
--未受診者勧奨（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_afatena','tt_afatena.atenano=tt_bhnymijusinsyakansyo.atenano',0);
--未受診者勧奨（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_afjumin','tt_afjumin.atenano=tt_bhnymijusinsyakansyo.atenano',0);
--未受診者勧奨（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_afkaigo','tt_afkaigo.atenano=tt_bhnymijusinsyakansyo.atenano',0);
--未受診者勧奨（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnymijusinsyakansyo.atenano',0);
--未受診者勧奨（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_afkokuho','tt_afkokuho.atenano=tt_bhnymijusinsyakansyo.atenano',0);
--未受診者勧奨（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_afseiho','tt_afseiho.atenano=tt_bhnymijusinsyakansyo.atenano',0);
--未受診者勧奨（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnymijusinsyakansyo.atenano',0);
--未受診者勧奨（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnymijusinsyakansyo.atenano',0);
--未受診者勧奨（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnymijusinsyakansyo.atenano',0);
--未受診者勧奨（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnymijusinsyakansyo.atenano',0);
--未受診者勧奨（固定項目）テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_bhnymijusinsyakansyo.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_bhnymijusinsyakansyo.edano',0);
--未受診者勧奨（固定項目）テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_bhnymijusinsyakansyo.atenano AND tt_bhnyseikenkekka.edano=tt_bhnymijusinsyakansyo.edano',0);
--未受診者勧奨（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnymijusinsyakansyo.atenano',0);
--未受診者勧奨（固定項目）テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_bhnymijusinsyakansyo.atenano AND tt_bhnyseikenirai.edano=tt_bhnymijusinsyakansyo.edano',0);
--未受診者勧奨（固定項目）テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_bhnymijusinsyakansyo.atenano AND tt_yssessyuirai.edano=tt_bhnymijusinsyakansyo.edano',0);
--未受診者勧奨（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnymijusinsyakansyo','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnymijusinsyakansyo.atenano',0);
--精密健診の依頼（固定項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_afatena','tt_afatena.atenano=tt_bhnyseikenirai.atenano',0);
--精密健診の依頼（固定項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_afjumin','tt_afjumin.atenano=tt_bhnyseikenirai.atenano',0);
--精密健診の依頼（固定項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_afkaigo','tt_afkaigo.atenano=tt_bhnyseikenirai.atenano',0);
--精密健診の依頼（固定項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnyseikenirai.atenano',0);
--精密健診の依頼（固定項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_afkokuho','tt_afkokuho.atenano=tt_bhnyseikenirai.atenano',0);
--精密健診の依頼（固定項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_afseiho','tt_afseiho.atenano=tt_bhnyseikenirai.atenano',0);
--精密健診の依頼（固定項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnyseikenirai.atenano',0);
--精密健診の依頼（固定項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnyseikenirai.atenano',0);
--精密健診の依頼（固定項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnyseikenirai.atenano',0);
--精密健診の依頼（固定項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnyseikenirai.atenano',0);
--精密健診の依頼（固定項目）テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_bhnyseikenirai.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_bhnyseikenirai.edano',0);
--精密健診の依頼（固定項目）テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_bhnyseikenirai.atenano AND tt_bhnyseikenkekka.edano=tt_bhnyseikenirai.edano',0);
--精密健診の依頼（固定項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnyseikenirai.atenano',0);
--精密健診の依頼（固定項目）テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_bhnyseikenirai.atenano AND tt_bhnymijusinsyakansyo.edano=tt_bhnyseikenirai.edano',0);
--精密健診の依頼（固定項目）テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_bhnyseikenirai.atenano AND tt_yssessyuirai.edano=tt_bhnyseikenirai.edano',0);
--精密健診の依頼（固定項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnyseikenirai','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnyseikenirai.atenano',0);
--妊娠届出（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokede','tt_afatena','tt_afatena.atenano=tt_bhnsninsintodokede.atenano',0);
--妊娠届出（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokede','tt_afjumin','tt_afjumin.atenano=tt_bhnsninsintodokede.atenano',0);
--妊娠届出（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokede','tt_afkaigo','tt_afkaigo.atenano=tt_bhnsninsintodokede.atenano',0);
--妊娠届出（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokede','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnsninsintodokede.atenano',0);
--妊娠届出（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokede','tt_afkokuho','tt_afkokuho.atenano=tt_bhnsninsintodokede.atenano',0);
--妊娠届出（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokede','tt_afseiho','tt_afseiho.atenano=tt_bhnsninsintodokede.atenano',0);
--妊娠届出（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokede','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnsninsintodokede.atenano',0);
--妊娠届出（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokede','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnsninsintodokede.atenano',0);
--妊娠届出（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokede','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnsninsintodokede.atenano',0);
--妊娠届出（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokede','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnsninsintodokede.atenano',0);
--妊娠届出（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokede','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnsninsintodokede.atenano',0);
--妊娠届出（固定）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokede','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnsninsintodokede.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnsninsintodokede.torokuno',0);
--妊娠届出（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokede','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnsninsintodokede.atenano',0);
--妊娠届出アンケート（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokedeanketo','tt_afatena','tt_afatena.atenano=tt_bhnsninsintodokedeanketo.atenano',0);
--妊娠届出アンケート（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokedeanketo','tt_afjumin','tt_afjumin.atenano=tt_bhnsninsintodokedeanketo.atenano',0);
--妊娠届出アンケート（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokedeanketo','tt_afkaigo','tt_afkaigo.atenano=tt_bhnsninsintodokedeanketo.atenano',0);
--妊娠届出アンケート（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokedeanketo','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnsninsintodokedeanketo.atenano',0);
--妊娠届出アンケート（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokedeanketo','tt_afkokuho','tt_afkokuho.atenano=tt_bhnsninsintodokedeanketo.atenano',0);
--妊娠届出アンケート（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokedeanketo','tt_afseiho','tt_afseiho.atenano=tt_bhnsninsintodokedeanketo.atenano',0);
--妊娠届出アンケート（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokedeanketo','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnsninsintodokedeanketo.atenano',0);
--妊娠届出アンケート（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokedeanketo','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnsninsintodokedeanketo.atenano',0);
--妊娠届出アンケート（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokedeanketo','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnsninsintodokedeanketo.atenano',0);
--妊娠届出アンケート（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokedeanketo','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnsninsintodokedeanketo.atenano',0);
--妊娠届出アンケート（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokedeanketo','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnsninsintodokedeanketo.atenano',0);
--妊娠届出アンケート（固定）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnsninsintodokedeanketo.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnsninsintodokedeanketo.torokuno',0);
--妊娠届出アンケート（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninsintodokedeanketo','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnsninsintodokedeanketo.atenano',0);
--母子健康手帳交付（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_afatena','tt_afatena.atenano=tt_bhnsbosikenkotetyokofu.atenano',0);
--母子健康手帳交付（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_afjumin','tt_afjumin.atenano=tt_bhnsbosikenkotetyokofu.atenano',0);
--母子健康手帳交付（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_afkaigo','tt_afkaigo.atenano=tt_bhnsbosikenkotetyokofu.atenano',0);
--母子健康手帳交付（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnsbosikenkotetyokofu.atenano',0);
--母子健康手帳交付（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_afkokuho','tt_afkokuho.atenano=tt_bhnsbosikenkotetyokofu.atenano',0);
--母子健康手帳交付（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_afseiho','tt_afseiho.atenano=tt_bhnsbosikenkotetyokofu.atenano',0);
--母子健康手帳交付（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnsbosikenkotetyokofu.atenano',0);
--母子健康手帳交付（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnsbosikenkotetyokofu.atenano',0);
--母子健康手帳交付（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnsbosikenkotetyokofu.atenano',0);
--母子健康手帳交付（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnsbosikenkotetyokofu.atenano',0);
--母子健康手帳交付（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnsbosikenkotetyokofu.atenano',0);
--母子健康手帳交付（固定）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnsbosikenkotetyokofu.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnsbosikenkotetyokofu.torokuno',0);
--母子健康手帳交付（固定）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnsbosikenkotetyokofu.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnsbosikenkotetyokofu.torokuno',0);
--母子健康手帳交付（固定）テーブル - 出産の状態に係る（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_bhnssyussanjotai','tt_bhnssyussanjotai.atenano=tt_bhnsbosikenkotetyokofu.atenano AND tt_bhnssyussanjotai.torokuno=tt_bhnsbosikenkotetyokofu.torokuno AND tt_bhnssyussanjotai.torokunorenban=tt_bhnsbosikenkotetyokofu.torokunorenban',0);
--母子健康手帳交付（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsbosikenkotetyokofu','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnsbosikenkotetyokofu.atenano',0);
--出産の状態に係る（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_afatena','tt_afatena.atenano=tt_bhnssyussanjotai.atenano',0);
--出産の状態に係る（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_afjumin','tt_afjumin.atenano=tt_bhnssyussanjotai.atenano',0);
--出産の状態に係る（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_afkaigo','tt_afkaigo.atenano=tt_bhnssyussanjotai.atenano',0);
--出産の状態に係る（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnssyussanjotai.atenano',0);
--出産の状態に係る（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_afkokuho','tt_afkokuho.atenano=tt_bhnssyussanjotai.atenano',0);
--出産の状態に係る（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_afseiho','tt_afseiho.atenano=tt_bhnssyussanjotai.atenano',0);
--出産の状態に係る（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnssyussanjotai.atenano',0);
--出産の状態に係る（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnssyussanjotai.atenano',0);
--出産の状態に係る（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnssyussanjotai.atenano',0);
--出産の状態に係る（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnssyussanjotai.atenano',0);
--出産の状態に係る（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnssyussanjotai.atenano',0);
--出産の状態に係る（固定）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnssyussanjotai.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnssyussanjotai.torokuno',0);
--出産の状態に係る（固定）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnssyussanjotai.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnssyussanjotai.torokuno',0);
--出産の状態に係る（固定）テーブル - 母子健康手帳交付（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_bhnsbosikenkotetyokofu','tt_bhnsbosikenkotetyokofu.atenano=tt_bhnssyussanjotai.atenano AND tt_bhnsbosikenkotetyokofu.torokuno=tt_bhnssyussanjotai.torokuno AND tt_bhnsbosikenkotetyokofu.torokunorenban=tt_bhnssyussanjotai.torokunorenban',0);
--出産の状態に係る（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssyussanjotai','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnssyussanjotai.atenano',0);
--妊婦健診結果（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_afatena','tt_afatena.atenano=tt_bhnsninpukensinkekka.atenano',0);
--妊婦健診結果（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_afjumin','tt_afjumin.atenano=tt_bhnsninpukensinkekka.atenano',0);
--妊婦健診結果（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_afkaigo','tt_afkaigo.atenano=tt_bhnsninpukensinkekka.atenano',0);
--妊婦健診結果（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnsninpukensinkekka.atenano',0);
--妊婦健診結果（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_afkokuho','tt_afkokuho.atenano=tt_bhnsninpukensinkekka.atenano',0);
--妊婦健診結果（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_afseiho','tt_afseiho.atenano=tt_bhnsninpukensinkekka.atenano',0);
--妊婦健診結果（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnsninpukensinkekka.atenano',0);
--妊婦健診結果（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnsninpukensinkekka.atenano',0);
--妊婦健診結果（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnsninpukensinkekka.atenano',0);
--妊婦健診結果（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnsninpukensinkekka.atenano',0);
--妊婦健診結果（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnsninpukensinkekka.atenano',0);
--妊婦健診結果（固定）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnsninpukensinkekka.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnsninpukensinkekka.torokuno',0);
--妊婦健診結果（固定）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnsninpukensinkekka.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnsninpukensinkekka.torokuno',0);
--妊婦健診結果（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinkekka','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnsninpukensinkekka.atenano',0);
--妊婦健診費用助成（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_afatena','tt_afatena.atenano=tt_bhnsninpukensinhiyojosei.atenano',0);
--妊婦健診費用助成（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_afjumin','tt_afjumin.atenano=tt_bhnsninpukensinhiyojosei.atenano',0);
--妊婦健診費用助成（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_afkaigo','tt_afkaigo.atenano=tt_bhnsninpukensinhiyojosei.atenano',0);
--妊婦健診費用助成（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnsninpukensinhiyojosei.atenano',0);
--妊婦健診費用助成（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_afkokuho','tt_afkokuho.atenano=tt_bhnsninpukensinhiyojosei.atenano',0);
--妊婦健診費用助成（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_afseiho','tt_afseiho.atenano=tt_bhnsninpukensinhiyojosei.atenano',0);
--妊婦健診費用助成（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnsninpukensinhiyojosei.atenano',0);
--妊婦健診費用助成（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnsninpukensinhiyojosei.atenano',0);
--妊婦健診費用助成（固定）テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_bhnsninpukensinhiyojosei.jigyocd',0);
--妊婦健診費用助成（固定）テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_bhnsninpukensinhiyojosei.jigyocd',0);
--妊婦健診費用助成（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnsninpukensinhiyojosei.atenano',0);
--妊婦健診費用助成（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnsninpukensinhiyojosei.atenano',0);
--妊婦健診費用助成（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnsninpukensinhiyojosei.atenano',0);
--妊婦健診費用助成（固定）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnsninpukensinhiyojosei.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnsninpukensinhiyojosei.torokuno',0);
--妊婦健診費用助成（固定）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnsninpukensinhiyojosei.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnsninpukensinhiyojosei.torokuno',0);
--妊婦健診費用助成（固定）テーブル - 産婦健診費用助成（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_bhnssanpukensinhiyojosei','tt_bhnssanpukensinhiyojosei.atenano=tt_bhnsninpukensinhiyojosei.atenano AND tt_bhnssanpukensinhiyojosei.torokuno=tt_bhnsninpukensinhiyojosei.torokuno AND tt_bhnssanpukensinhiyojosei.sinseiedano=tt_bhnsninpukensinhiyojosei.sinseiedano',0);
--妊婦健診費用助成（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnsninpukensinhiyojosei.atenano',0);
--妊婦健診費用助成（固定）サブテーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_afatena','tt_afatena.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano',0);
--妊婦健診費用助成（固定）サブテーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_afjumin','tt_afjumin.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano',0);
--妊婦健診費用助成（固定）サブテーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_afkaigo','tt_afkaigo.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano',0);
--妊婦健診費用助成（固定）サブテーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano',0);
--妊婦健診費用助成（固定）サブテーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_afkokuho','tt_afkokuho.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano',0);
--妊婦健診費用助成（固定）サブテーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_afseiho','tt_afseiho.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano',0);
--妊婦健診費用助成（固定）サブテーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano',0);
--妊婦健診費用助成（固定）サブテーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano',0);
--妊婦健診費用助成（固定）サブテーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_bhnsninpukensinhiyojosei_sub.jigyocd',0);
--妊婦健診費用助成（固定）サブテーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_bhnsninpukensinhiyojosei_sub.jigyocd',0);
--妊婦健診費用助成（固定）サブテーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano',0);
--妊婦健診費用助成（固定）サブテーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano',0);
--妊婦健診費用助成（固定）サブテーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano',0);
--妊婦健診費用助成（固定）サブテーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnsninpukensinhiyojosei_sub.torokuno',0);
--妊婦健診費用助成（固定）サブテーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnsninpukensinhiyojosei_sub.torokuno',0);
--妊婦健診費用助成（固定）サブテーブル - 妊婦健診費用助成（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_bhnsninpukensinhiyojosei','tt_bhnsninpukensinhiyojosei.jigyocd=tt_bhnsninpukensinhiyojosei_sub.jigyocd AND tt_bhnsninpukensinhiyojosei.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano AND tt_bhnsninpukensinhiyojosei.torokuno=tt_bhnsninpukensinhiyojosei_sub.torokuno AND tt_bhnsninpukensinhiyojosei.sinseiedano=tt_bhnsninpukensinhiyojosei_sub.sinseiedano',0);
--妊婦健診費用助成（固定）サブテーブル - 産婦健診費用助成（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_bhnssanpukensinhiyojosei','tt_bhnssanpukensinhiyojosei.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano AND tt_bhnssanpukensinhiyojosei.torokuno=tt_bhnsninpukensinhiyojosei_sub.torokuno AND tt_bhnssanpukensinhiyojosei.sinseiedano=tt_bhnsninpukensinhiyojosei_sub.sinseiedano',0);
--妊婦健診費用助成（固定）サブテーブル - 産婦健診費用助成（固定）サブテーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_bhnssanpukensinhiyojosei_sub','tt_bhnssanpukensinhiyojosei_sub.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano AND tt_bhnssanpukensinhiyojosei_sub.torokuno=tt_bhnsninpukensinhiyojosei_sub.torokuno AND tt_bhnssanpukensinhiyojosei_sub.sinseiedano=tt_bhnsninpukensinhiyojosei_sub.sinseiedano AND tt_bhnssanpukensinhiyojosei_sub.edano=tt_bhnsninpukensinhiyojosei_sub.edano',0);
--妊婦健診費用助成（固定）サブテーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnsninpukensinhiyojosei_sub.atenano',0);
--妊産婦歯科健診結果（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_afatena','tt_afatena.atenano=tt_bhnssikakensinkekka.atenano',0);
--妊産婦歯科健診結果（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_afjumin','tt_afjumin.atenano=tt_bhnssikakensinkekka.atenano',0);
--妊産婦歯科健診結果（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_afkaigo','tt_afkaigo.atenano=tt_bhnssikakensinkekka.atenano',0);
--妊産婦歯科健診結果（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnssikakensinkekka.atenano',0);
--妊産婦歯科健診結果（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_afkokuho','tt_afkokuho.atenano=tt_bhnssikakensinkekka.atenano',0);
--妊産婦歯科健診結果（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_afseiho','tt_afseiho.atenano=tt_bhnssikakensinkekka.atenano',0);
--妊産婦歯科健診結果（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnssikakensinkekka.atenano',0);
--妊産婦歯科健診結果（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnssikakensinkekka.atenano',0);
--妊産婦歯科健診結果（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnssikakensinkekka.atenano',0);
--妊産婦歯科健診結果（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnssikakensinkekka.atenano',0);
--妊産婦歯科健診結果（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnssikakensinkekka.atenano',0);
--妊産婦歯科健診結果（固定）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnssikakensinkekka.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnssikakensinkekka.torokuno',0);
--妊産婦歯科健診結果（固定）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnssikakensinkekka.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnssikakensinkekka.torokuno',0);
--妊産婦歯科健診結果（固定）テーブル - 妊産婦歯科精健結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_bhnssikaseikenkekka','tt_bhnssikaseikenkekka.atenano=tt_bhnssikakensinkekka.atenano AND tt_bhnssikaseikenkekka.torokuno=tt_bhnssikakensinkekka.torokuno AND tt_bhnssikaseikenkekka.edano=tt_bhnssikakensinkekka.edano',0);
--妊産婦歯科健診結果（固定）テーブル - 妊婦精健結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_bhnsninpuseikenkekka','tt_bhnsninpuseikenkekka.atenano=tt_bhnssikakensinkekka.atenano AND tt_bhnsninpuseikenkekka.torokuno=tt_bhnssikakensinkekka.torokuno AND tt_bhnsninpuseikenkekka.edano=tt_bhnssikakensinkekka.edano',0);
--妊産婦歯科健診結果（固定）テーブル - 産婦健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_bhnssanpukensinkekka','tt_bhnssanpukensinkekka.atenano=tt_bhnssikakensinkekka.atenano AND tt_bhnssanpukensinkekka.torokuno=tt_bhnssikakensinkekka.torokuno AND tt_bhnssanpukensinkekka.edano=tt_bhnssikakensinkekka.edano',0);
--妊産婦歯科健診結果（固定）テーブル - 産婦精密健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_bhnssanpuseikenkekka','tt_bhnssanpuseikenkekka.atenano=tt_bhnssikakensinkekka.atenano AND tt_bhnssanpuseikenkekka.torokuno=tt_bhnssikakensinkekka.torokuno AND tt_bhnssanpuseikenkekka.edano=tt_bhnssikakensinkekka.edano',0);
--妊産婦歯科健診結果（固定）テーブル - 産後ケア事業（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_bhnssangocarejigyo','tt_bhnssangocarejigyo.atenano=tt_bhnssikakensinkekka.atenano AND tt_bhnssangocarejigyo.torokuno=tt_bhnssikakensinkekka.torokuno AND tt_bhnssangocarejigyo.edano=tt_bhnssikakensinkekka.edano',0);
--妊産婦歯科健診結果（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikakensinkekka','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnssikakensinkekka.atenano',0);
--妊産婦歯科精健結果（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_afatena','tt_afatena.atenano=tt_bhnssikaseikenkekka.atenano',0);
--妊産婦歯科精健結果（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_afjumin','tt_afjumin.atenano=tt_bhnssikaseikenkekka.atenano',0);
--妊産婦歯科精健結果（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_afkaigo','tt_afkaigo.atenano=tt_bhnssikaseikenkekka.atenano',0);
--妊産婦歯科精健結果（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnssikaseikenkekka.atenano',0);
--妊産婦歯科精健結果（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_afkokuho','tt_afkokuho.atenano=tt_bhnssikaseikenkekka.atenano',0);
--妊産婦歯科精健結果（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_afseiho','tt_afseiho.atenano=tt_bhnssikaseikenkekka.atenano',0);
--妊産婦歯科精健結果（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnssikaseikenkekka.atenano',0);
--妊産婦歯科精健結果（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnssikaseikenkekka.atenano',0);
--妊産婦歯科精健結果（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnssikaseikenkekka.atenano',0);
--妊産婦歯科精健結果（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnssikaseikenkekka.atenano',0);
--妊産婦歯科精健結果（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnssikaseikenkekka.atenano',0);
--妊産婦歯科精健結果（固定）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnssikaseikenkekka.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnssikaseikenkekka.torokuno',0);
--妊産婦歯科精健結果（固定）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnssikaseikenkekka.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnssikaseikenkekka.torokuno',0);
--妊産婦歯科精健結果（固定）テーブル - 妊産婦歯科健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_bhnssikakensinkekka','tt_bhnssikakensinkekka.atenano=tt_bhnssikaseikenkekka.atenano AND tt_bhnssikakensinkekka.torokuno=tt_bhnssikaseikenkekka.torokuno AND tt_bhnssikakensinkekka.edano=tt_bhnssikaseikenkekka.edano',0);
--妊産婦歯科精健結果（固定）テーブル - 妊婦精健結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_bhnsninpuseikenkekka','tt_bhnsninpuseikenkekka.atenano=tt_bhnssikaseikenkekka.atenano AND tt_bhnsninpuseikenkekka.torokuno=tt_bhnssikaseikenkekka.torokuno AND tt_bhnsninpuseikenkekka.edano=tt_bhnssikaseikenkekka.edano',0);
--妊産婦歯科精健結果（固定）テーブル - 産婦健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_bhnssanpukensinkekka','tt_bhnssanpukensinkekka.atenano=tt_bhnssikaseikenkekka.atenano AND tt_bhnssanpukensinkekka.torokuno=tt_bhnssikaseikenkekka.torokuno AND tt_bhnssanpukensinkekka.edano=tt_bhnssikaseikenkekka.edano',0);
--妊産婦歯科精健結果（固定）テーブル - 産婦精密健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_bhnssanpuseikenkekka','tt_bhnssanpuseikenkekka.atenano=tt_bhnssikaseikenkekka.atenano AND tt_bhnssanpuseikenkekka.torokuno=tt_bhnssikaseikenkekka.torokuno AND tt_bhnssanpuseikenkekka.edano=tt_bhnssikaseikenkekka.edano',0);
--妊産婦歯科精健結果（固定）テーブル - 産後ケア事業（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_bhnssangocarejigyo','tt_bhnssangocarejigyo.atenano=tt_bhnssikaseikenkekka.atenano AND tt_bhnssangocarejigyo.torokuno=tt_bhnssikaseikenkekka.torokuno AND tt_bhnssangocarejigyo.edano=tt_bhnssikaseikenkekka.edano',0);
--妊産婦歯科精健結果（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssikaseikenkekka','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnssikaseikenkekka.atenano',0);
--妊婦精健結果（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_afatena','tt_afatena.atenano=tt_bhnsninpuseikenkekka.atenano',0);
--妊婦精健結果（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_afjumin','tt_afjumin.atenano=tt_bhnsninpuseikenkekka.atenano',0);
--妊婦精健結果（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_afkaigo','tt_afkaigo.atenano=tt_bhnsninpuseikenkekka.atenano',0);
--妊婦精健結果（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnsninpuseikenkekka.atenano',0);
--妊婦精健結果（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_afkokuho','tt_afkokuho.atenano=tt_bhnsninpuseikenkekka.atenano',0);
--妊婦精健結果（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_afseiho','tt_afseiho.atenano=tt_bhnsninpuseikenkekka.atenano',0);
--妊婦精健結果（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnsninpuseikenkekka.atenano',0);
--妊婦精健結果（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnsninpuseikenkekka.atenano',0);
--妊婦精健結果（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnsninpuseikenkekka.atenano',0);
--妊婦精健結果（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnsninpuseikenkekka.atenano',0);
--妊婦精健結果（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnsninpuseikenkekka.atenano',0);
--妊婦精健結果（固定）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnsninpuseikenkekka.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnsninpuseikenkekka.torokuno',0);
--妊婦精健結果（固定）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnsninpuseikenkekka.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnsninpuseikenkekka.torokuno',0);
--妊婦精健結果（固定）テーブル - 妊産婦歯科健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_bhnssikakensinkekka','tt_bhnssikakensinkekka.atenano=tt_bhnsninpuseikenkekka.atenano AND tt_bhnssikakensinkekka.torokuno=tt_bhnsninpuseikenkekka.torokuno AND tt_bhnssikakensinkekka.edano=tt_bhnsninpuseikenkekka.edano',0);
--妊婦精健結果（固定）テーブル - 妊産婦歯科精健結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_bhnssikaseikenkekka','tt_bhnssikaseikenkekka.atenano=tt_bhnsninpuseikenkekka.atenano AND tt_bhnssikaseikenkekka.torokuno=tt_bhnsninpuseikenkekka.torokuno AND tt_bhnssikaseikenkekka.edano=tt_bhnsninpuseikenkekka.edano',0);
--妊婦精健結果（固定）テーブル - 産婦健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_bhnssanpukensinkekka','tt_bhnssanpukensinkekka.atenano=tt_bhnsninpuseikenkekka.atenano AND tt_bhnssanpukensinkekka.torokuno=tt_bhnsninpuseikenkekka.torokuno AND tt_bhnssanpukensinkekka.edano=tt_bhnsninpuseikenkekka.edano',0);
--妊婦精健結果（固定）テーブル - 産婦精密健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_bhnssanpuseikenkekka','tt_bhnssanpuseikenkekka.atenano=tt_bhnsninpuseikenkekka.atenano AND tt_bhnssanpuseikenkekka.torokuno=tt_bhnsninpuseikenkekka.torokuno AND tt_bhnssanpuseikenkekka.edano=tt_bhnsninpuseikenkekka.edano',0);
--妊婦精健結果（固定）テーブル - 産後ケア事業（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_bhnssangocarejigyo','tt_bhnssangocarejigyo.atenano=tt_bhnsninpuseikenkekka.atenano AND tt_bhnssangocarejigyo.torokuno=tt_bhnsninpuseikenkekka.torokuno AND tt_bhnssangocarejigyo.edano=tt_bhnsninpuseikenkekka.edano',0);
--妊婦精健結果（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsninpuseikenkekka','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnsninpuseikenkekka.atenano',0);
--産婦健診結果（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_afatena','tt_afatena.atenano=tt_bhnssanpukensinkekka.atenano',0);
--産婦健診結果（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_afjumin','tt_afjumin.atenano=tt_bhnssanpukensinkekka.atenano',0);
--産婦健診結果（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_afkaigo','tt_afkaigo.atenano=tt_bhnssanpukensinkekka.atenano',0);
--産婦健診結果（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnssanpukensinkekka.atenano',0);
--産婦健診結果（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_afkokuho','tt_afkokuho.atenano=tt_bhnssanpukensinkekka.atenano',0);
--産婦健診結果（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_afseiho','tt_afseiho.atenano=tt_bhnssanpukensinkekka.atenano',0);
--産婦健診結果（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnssanpukensinkekka.atenano',0);
--産婦健診結果（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnssanpukensinkekka.atenano',0);
--産婦健診結果（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnssanpukensinkekka.atenano',0);
--産婦健診結果（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnssanpukensinkekka.atenano',0);
--産婦健診結果（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnssanpukensinkekka.atenano',0);
--産婦健診結果（固定）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnssanpukensinkekka.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnssanpukensinkekka.torokuno',0);
--産婦健診結果（固定）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnssanpukensinkekka.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnssanpukensinkekka.torokuno',0);
--産婦健診結果（固定）テーブル - 妊産婦歯科健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_bhnssikakensinkekka','tt_bhnssikakensinkekka.atenano=tt_bhnssanpukensinkekka.atenano AND tt_bhnssikakensinkekka.torokuno=tt_bhnssanpukensinkekka.torokuno AND tt_bhnssikakensinkekka.edano=tt_bhnssanpukensinkekka.edano',0);
--産婦健診結果（固定）テーブル - 妊産婦歯科精健結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_bhnssikaseikenkekka','tt_bhnssikaseikenkekka.atenano=tt_bhnssanpukensinkekka.atenano AND tt_bhnssikaseikenkekka.torokuno=tt_bhnssanpukensinkekka.torokuno AND tt_bhnssikaseikenkekka.edano=tt_bhnssanpukensinkekka.edano',0);
--産婦健診結果（固定）テーブル - 妊婦精健結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_bhnsninpuseikenkekka','tt_bhnsninpuseikenkekka.atenano=tt_bhnssanpukensinkekka.atenano AND tt_bhnsninpuseikenkekka.torokuno=tt_bhnssanpukensinkekka.torokuno AND tt_bhnsninpuseikenkekka.edano=tt_bhnssanpukensinkekka.edano',0);
--産婦健診結果（固定）テーブル - 産婦精密健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_bhnssanpuseikenkekka','tt_bhnssanpuseikenkekka.atenano=tt_bhnssanpukensinkekka.atenano AND tt_bhnssanpuseikenkekka.torokuno=tt_bhnssanpukensinkekka.torokuno AND tt_bhnssanpuseikenkekka.edano=tt_bhnssanpukensinkekka.edano',0);
--産婦健診結果（固定）テーブル - 産後ケア事業（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_bhnssangocarejigyo','tt_bhnssangocarejigyo.atenano=tt_bhnssanpukensinkekka.atenano AND tt_bhnssangocarejigyo.torokuno=tt_bhnssanpukensinkekka.torokuno AND tt_bhnssangocarejigyo.edano=tt_bhnssanpukensinkekka.edano',0);
--産婦健診結果（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinkekka','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnssanpukensinkekka.atenano',0);
--産婦健診費用助成（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_afatena','tt_afatena.atenano=tt_bhnssanpukensinhiyojosei.atenano',0);
--産婦健診費用助成（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_afjumin','tt_afjumin.atenano=tt_bhnssanpukensinhiyojosei.atenano',0);
--産婦健診費用助成（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_afkaigo','tt_afkaigo.atenano=tt_bhnssanpukensinhiyojosei.atenano',0);
--産婦健診費用助成（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnssanpukensinhiyojosei.atenano',0);
--産婦健診費用助成（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_afkokuho','tt_afkokuho.atenano=tt_bhnssanpukensinhiyojosei.atenano',0);
--産婦健診費用助成（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_afseiho','tt_afseiho.atenano=tt_bhnssanpukensinhiyojosei.atenano',0);
--産婦健診費用助成（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnssanpukensinhiyojosei.atenano',0);
--産婦健診費用助成（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnssanpukensinhiyojosei.atenano',0);
--産婦健診費用助成（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnssanpukensinhiyojosei.atenano',0);
--産婦健診費用助成（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnssanpukensinhiyojosei.atenano',0);
--産婦健診費用助成（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnssanpukensinhiyojosei.atenano',0);
--産婦健診費用助成（固定）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnssanpukensinhiyojosei.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnssanpukensinhiyojosei.torokuno',0);
--産婦健診費用助成（固定）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnssanpukensinhiyojosei.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnssanpukensinhiyojosei.torokuno',0);
--産婦健診費用助成（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnssanpukensinhiyojosei.atenano',0);
--産婦健診費用助成（固定）サブテーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_afatena','tt_afatena.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano',0);
--産婦健診費用助成（固定）サブテーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_afjumin','tt_afjumin.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano',0);
--産婦健診費用助成（固定）サブテーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_afkaigo','tt_afkaigo.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano',0);
--産婦健診費用助成（固定）サブテーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano',0);
--産婦健診費用助成（固定）サブテーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_afkokuho','tt_afkokuho.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano',0);
--産婦健診費用助成（固定）サブテーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_afseiho','tt_afseiho.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano',0);
--産婦健診費用助成（固定）サブテーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano',0);
--産婦健診費用助成（固定）サブテーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano',0);
--産婦健診費用助成（固定）サブテーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano',0);
--産婦健診費用助成（固定）サブテーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano',0);
--産婦健診費用助成（固定）サブテーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano',0);
--産婦健診費用助成（固定）サブテーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnssanpukensinhiyojosei_sub.torokuno',0);
--産婦健診費用助成（固定）サブテーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnssanpukensinhiyojosei_sub.torokuno',0);
--産婦健診費用助成（固定）サブテーブル - 産婦健診費用助成（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_bhnssanpukensinhiyojosei','tt_bhnssanpukensinhiyojosei.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano AND tt_bhnssanpukensinhiyojosei.torokuno=tt_bhnssanpukensinhiyojosei_sub.torokuno AND tt_bhnssanpukensinhiyojosei.sinseiedano=tt_bhnssanpukensinhiyojosei_sub.sinseiedano',0);
--産婦健診費用助成（固定）サブテーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnssanpukensinhiyojosei_sub.atenano',0);
--産婦精密健診結果（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_afatena','tt_afatena.atenano=tt_bhnssanpuseikenkekka.atenano',0);
--産婦精密健診結果（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_afjumin','tt_afjumin.atenano=tt_bhnssanpuseikenkekka.atenano',0);
--産婦精密健診結果（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_afkaigo','tt_afkaigo.atenano=tt_bhnssanpuseikenkekka.atenano',0);
--産婦精密健診結果（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnssanpuseikenkekka.atenano',0);
--産婦精密健診結果（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_afkokuho','tt_afkokuho.atenano=tt_bhnssanpuseikenkekka.atenano',0);
--産婦精密健診結果（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_afseiho','tt_afseiho.atenano=tt_bhnssanpuseikenkekka.atenano',0);
--産婦精密健診結果（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnssanpuseikenkekka.atenano',0);
--産婦精密健診結果（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnssanpuseikenkekka.atenano',0);
--産婦精密健診結果（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnssanpuseikenkekka.atenano',0);
--産婦精密健診結果（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnssanpuseikenkekka.atenano',0);
--産婦精密健診結果（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnssanpuseikenkekka.atenano',0);
--産婦精密健診結果（固定）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnssanpuseikenkekka.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnssanpuseikenkekka.torokuno',0);
--産婦精密健診結果（固定）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnssanpuseikenkekka.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnssanpuseikenkekka.torokuno',0);
--産婦精密健診結果（固定）テーブル - 妊産婦歯科健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_bhnssikakensinkekka','tt_bhnssikakensinkekka.atenano=tt_bhnssanpuseikenkekka.atenano AND tt_bhnssikakensinkekka.torokuno=tt_bhnssanpuseikenkekka.torokuno AND tt_bhnssikakensinkekka.edano=tt_bhnssanpuseikenkekka.edano',0);
--産婦精密健診結果（固定）テーブル - 妊産婦歯科精健結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_bhnssikaseikenkekka','tt_bhnssikaseikenkekka.atenano=tt_bhnssanpuseikenkekka.atenano AND tt_bhnssikaseikenkekka.torokuno=tt_bhnssanpuseikenkekka.torokuno AND tt_bhnssikaseikenkekka.edano=tt_bhnssanpuseikenkekka.edano',0);
--産婦精密健診結果（固定）テーブル - 妊婦精健結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_bhnsninpuseikenkekka','tt_bhnsninpuseikenkekka.atenano=tt_bhnssanpuseikenkekka.atenano AND tt_bhnsninpuseikenkekka.torokuno=tt_bhnssanpuseikenkekka.torokuno AND tt_bhnsninpuseikenkekka.edano=tt_bhnssanpuseikenkekka.edano',0);
--産婦精密健診結果（固定）テーブル - 産婦健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_bhnssanpukensinkekka','tt_bhnssanpukensinkekka.atenano=tt_bhnssanpuseikenkekka.atenano AND tt_bhnssanpukensinkekka.torokuno=tt_bhnssanpuseikenkekka.torokuno AND tt_bhnssanpukensinkekka.edano=tt_bhnssanpuseikenkekka.edano',0);
--産婦精密健診結果（固定）テーブル - 産後ケア事業（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_bhnssangocarejigyo','tt_bhnssangocarejigyo.atenano=tt_bhnssanpuseikenkekka.atenano AND tt_bhnssangocarejigyo.torokuno=tt_bhnssanpuseikenkekka.torokuno AND tt_bhnssangocarejigyo.edano=tt_bhnssanpuseikenkekka.edano',0);
--産婦精密健診結果（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssanpuseikenkekka','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnssanpuseikenkekka.atenano',0);
--産後ケア事業（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_afatena','tt_afatena.atenano=tt_bhnssangocarejigyo.atenano',0);
--産後ケア事業（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_afjumin','tt_afjumin.atenano=tt_bhnssangocarejigyo.atenano',0);
--産後ケア事業（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_afkaigo','tt_afkaigo.atenano=tt_bhnssangocarejigyo.atenano',0);
--産後ケア事業（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnssangocarejigyo.atenano',0);
--産後ケア事業（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_afkokuho','tt_afkokuho.atenano=tt_bhnssangocarejigyo.atenano',0);
--産後ケア事業（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_afseiho','tt_afseiho.atenano=tt_bhnssangocarejigyo.atenano',0);
--産後ケア事業（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnssangocarejigyo.atenano',0);
--産後ケア事業（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnssangocarejigyo.atenano',0);
--産後ケア事業（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnssangocarejigyo.atenano',0);
--産後ケア事業（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnssangocarejigyo.atenano',0);
--産後ケア事業（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnssangocarejigyo.atenano',0);
--産後ケア事業（固定）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnssangocarejigyo.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnssangocarejigyo.torokuno',0);
--産後ケア事業（固定）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnssangocarejigyo.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnssangocarejigyo.torokuno',0);
--産後ケア事業（固定）テーブル - 妊産婦歯科健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_bhnssikakensinkekka','tt_bhnssikakensinkekka.atenano=tt_bhnssangocarejigyo.atenano AND tt_bhnssikakensinkekka.torokuno=tt_bhnssangocarejigyo.torokuno AND tt_bhnssikakensinkekka.edano=tt_bhnssangocarejigyo.edano',0);
--産後ケア事業（固定）テーブル - 妊産婦歯科精健結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_bhnssikaseikenkekka','tt_bhnssikaseikenkekka.atenano=tt_bhnssangocarejigyo.atenano AND tt_bhnssikaseikenkekka.torokuno=tt_bhnssangocarejigyo.torokuno AND tt_bhnssikaseikenkekka.edano=tt_bhnssangocarejigyo.edano',0);
--産後ケア事業（固定）テーブル - 妊婦精健結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_bhnsninpuseikenkekka','tt_bhnsninpuseikenkekka.atenano=tt_bhnssangocarejigyo.atenano AND tt_bhnsninpuseikenkekka.torokuno=tt_bhnssangocarejigyo.torokuno AND tt_bhnsninpuseikenkekka.edano=tt_bhnssangocarejigyo.edano',0);
--産後ケア事業（固定）テーブル - 産婦健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_bhnssanpukensinkekka','tt_bhnssanpukensinkekka.atenano=tt_bhnssangocarejigyo.atenano AND tt_bhnssanpukensinkekka.torokuno=tt_bhnssangocarejigyo.torokuno AND tt_bhnssanpukensinkekka.edano=tt_bhnssangocarejigyo.edano',0);
--産後ケア事業（固定）テーブル - 産婦精密健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_bhnssanpuseikenkekka','tt_bhnssanpuseikenkekka.atenano=tt_bhnssangocarejigyo.atenano AND tt_bhnssanpuseikenkekka.torokuno=tt_bhnssangocarejigyo.torokuno AND tt_bhnssanpuseikenkekka.edano=tt_bhnssangocarejigyo.edano',0);
--産後ケア事業（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnssangocarejigyo','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnssangocarejigyo.atenano',0);
--独自施策（母）（固定）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_afatena','tt_afatena.atenano=tt_bhnsdokujisesaku.atenano',0);
--独自施策（母）（固定）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_afjumin','tt_afjumin.atenano=tt_bhnsdokujisesaku.atenano',0);
--独自施策（母）（固定）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_afkaigo','tt_afkaigo.atenano=tt_bhnsdokujisesaku.atenano',0);
--独自施策（母）（固定）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_afkokihoken','tt_afkokihoken.atenano=tt_bhnsdokujisesaku.atenano',0);
--独自施策（母）（固定）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_afkokuho','tt_afkokuho.atenano=tt_bhnsdokujisesaku.atenano',0);
--独自施策（母）（固定）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_afseiho','tt_afseiho.atenano=tt_bhnsdokujisesaku.atenano',0);
--独自施策（母）（固定）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_bhnsdokujisesaku.atenano',0);
--独自施策（母）（固定）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_bhnsdokujisesaku.atenano',0);
--独自施策（母）（固定）テーブル - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tt_bhnsdokujisesaku.jigyocd',0);
--独自施策（母）（固定）テーブル - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tt_bhnsdokujisesaku.jigyocd',0);
--独自施策（母）（固定）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_bhnsdokujisesaku.atenano',0);
--独自施策（母）（固定）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_bhnsdokujisesaku.atenano',0);
--独自施策（母）（固定）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_bhnsdokujisesaku.atenano',0);
--独自施策（母）（固定）テーブル - 妊娠届出（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_bhnsninsintodokede','tt_bhnsninsintodokede.atenano=tt_bhnsdokujisesaku.atenano AND tt_bhnsninsintodokede.torokuno=tt_bhnsdokujisesaku.torokuno',0);
--独自施策（母）（固定）テーブル - 妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo.atenano=tt_bhnsdokujisesaku.atenano AND tt_bhnsninsintodokedeanketo.torokuno=tt_bhnsdokujisesaku.torokuno',0);
--独自施策（母）（固定）テーブル - 妊産婦歯科健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_bhnssikakensinkekka','tt_bhnssikakensinkekka.atenano=tt_bhnsdokujisesaku.atenano AND tt_bhnssikakensinkekka.torokuno=tt_bhnsdokujisesaku.torokuno AND tt_bhnssikakensinkekka.edano=tt_bhnsdokujisesaku.edano',0);
--独自施策（母）（固定）テーブル - 妊産婦歯科精健結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_bhnssikaseikenkekka','tt_bhnssikaseikenkekka.atenano=tt_bhnsdokujisesaku.atenano AND tt_bhnssikaseikenkekka.torokuno=tt_bhnsdokujisesaku.torokuno AND tt_bhnssikaseikenkekka.edano=tt_bhnsdokujisesaku.edano',0);
--独自施策（母）（固定）テーブル - 妊婦精健結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_bhnsninpuseikenkekka','tt_bhnsninpuseikenkekka.atenano=tt_bhnsdokujisesaku.atenano AND tt_bhnsninpuseikenkekka.torokuno=tt_bhnsdokujisesaku.torokuno AND tt_bhnsninpuseikenkekka.edano=tt_bhnsdokujisesaku.edano',0);
--独自施策（母）（固定）テーブル - 産婦健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_bhnssanpukensinkekka','tt_bhnssanpukensinkekka.atenano=tt_bhnsdokujisesaku.atenano AND tt_bhnssanpukensinkekka.torokuno=tt_bhnsdokujisesaku.torokuno AND tt_bhnssanpukensinkekka.edano=tt_bhnsdokujisesaku.edano',0);
--独自施策（母）（固定）テーブル - 産婦精密健診結果（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_bhnssanpuseikenkekka','tt_bhnssanpuseikenkekka.atenano=tt_bhnsdokujisesaku.atenano AND tt_bhnssanpuseikenkekka.torokuno=tt_bhnsdokujisesaku.torokuno AND tt_bhnssanpuseikenkekka.edano=tt_bhnsdokujisesaku.edano',0);
--独自施策（母）（固定）テーブル - 産後ケア事業（固定）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_bhnssangocarejigyo','tt_bhnssangocarejigyo.atenano=tt_bhnsdokujisesaku.atenano AND tt_bhnssangocarejigyo.torokuno=tt_bhnsdokujisesaku.torokuno AND tt_bhnssangocarejigyo.edano=tt_bhnsdokujisesaku.edano',0);
--独自施策（母）（固定）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_bhnsdokujisesaku','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_bhnsdokujisesaku.atenano',0);
--母子保健健診対象者テーブル - 会場情報マスタ
INSERT INTO tm_eutablejoin VALUES('tm_bhkensin','tm_afkaijo','tm_afkaijo.kaijocd=tm_bhkensin.kaijocd',0);
--母子保健健診対象者テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tm_bhkensin','tt_afatena','tt_afatena.atenano=tm_bhkensin.atenano',0);
--母子保健健診対象者テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tm_bhkensin','tt_afjumin','tt_afjumin.atenano=tm_bhkensin.atenano',0);
--母子保健健診対象者テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tm_bhkensin','tt_afkaigo','tt_afkaigo.atenano=tm_bhkensin.atenano',0);
--母子保健健診対象者テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tm_bhkensin','tt_afkokihoken','tt_afkokihoken.atenano=tm_bhkensin.atenano',0);
--母子保健健診対象者テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tm_bhkensin','tt_afkokuho','tt_afkokuho.atenano=tm_bhkensin.atenano',0);
--母子保健健診対象者テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tm_bhkensin','tt_afseiho','tt_afseiho.atenano=tm_bhkensin.atenano',0);
--母子保健健診対象者テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tm_bhkensin','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tm_bhkensin.atenano',0);
--母子保健健診対象者テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tm_bhkensin','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tm_bhkensin.atenano',0);
--母子保健健診対象者テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tm_bhkensin','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tm_bhkensin.atenano',0);
--母子保健健診対象者テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tm_bhkensin','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tm_bhkensin.atenano',0);
--母子保健健診対象者テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tm_bhkensin','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tm_bhkensin.atenano',0);
--母子保健健診対象者テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tm_bhkensin','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tm_bhkensin.atenano',0);
--予診票発行情報テーブル(案) - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysyosinhakko','tt_afatena','tt_afatena.atenano=tt_ysyosinhakko.atenano',0);
--予診票発行情報テーブル(案) - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysyosinhakko','tt_afjumin','tt_afjumin.atenano=tt_ysyosinhakko.atenano',0);
--予診票発行情報テーブル(案) - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysyosinhakko','tt_afkaigo','tt_afkaigo.atenano=tt_ysyosinhakko.atenano',0);
--予診票発行情報テーブル(案) - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysyosinhakko','tt_afkokihoken','tt_afkokihoken.atenano=tt_ysyosinhakko.atenano',0);
--予診票発行情報テーブル(案) - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysyosinhakko','tt_afkokuho','tt_afkokuho.atenano=tt_ysyosinhakko.atenano',0);
--予診票発行情報テーブル(案) - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysyosinhakko','tt_afseiho','tt_afseiho.atenano=tt_ysyosinhakko.atenano',0);
--予診票発行情報テーブル(案) - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysyosinhakko','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_ysyosinhakko.atenano',0);
--予診票発行情報テーブル(案) - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysyosinhakko','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_ysyosinhakko.atenano',0);
--予診票発行情報テーブル(案) - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysyosinhakko','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_ysyosinhakko.atenano',0);
--予診票発行情報テーブル(案) - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysyosinhakko','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_ysyosinhakko.atenano',0);
--予診票発行情報テーブル(案) - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysyosinhakko','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_ysyosinhakko.atenano',0);
--予診票発行情報テーブル(案) - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysyosinhakko','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_ysyosinhakko.atenano',0);
--予診票発行情報テーブル(案) - 予防接種入力チェックマスタ
INSERT INTO tm_eutablejoin VALUES('tt_ysyosinhakko','tm_ysnyuryokucheck','tm_ysnyuryokucheck.sessyucd=tt_ysyosinhakko.sessyucd AND tm_ysnyuryokucheck.kaisu=tt_ysyosinhakko.kaisu',0);
--予防接種依頼テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_afatena','tt_afatena.atenano=tt_yssessyuirai.atenano',0);
--予防接種依頼テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_afjumin','tt_afjumin.atenano=tt_yssessyuirai.atenano',0);
--予防接種依頼テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_afkaigo','tt_afkaigo.atenano=tt_yssessyuirai.atenano',0);
--予防接種依頼テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_afkokihoken','tt_afkokihoken.atenano=tt_yssessyuirai.atenano',0);
--予防接種依頼テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_afkokuho','tt_afkokuho.atenano=tt_yssessyuirai.atenano',0);
--予防接種依頼テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_afseiho','tt_afseiho.atenano=tt_yssessyuirai.atenano',0);
--予防接種依頼テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_yssessyuirai.atenano',0);
--予防接種依頼テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_yssessyuirai.atenano',0);
--予防接種依頼テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_yssessyuirai.atenano',0);
--予防接種依頼テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_yssessyuirai.atenano',0);
--予防接種依頼テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_yssessyuirai.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_yssessyuirai.edano',0);
--予防接種依頼テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_yssessyuirai.atenano AND tt_bhnyseikenkekka.edano=tt_yssessyuirai.edano',0);
--予防接種依頼テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_yssessyuirai.atenano',0);
--予防接種依頼テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_yssessyuirai.atenano AND tt_bhnymijusinsyakansyo.edano=tt_yssessyuirai.edano',0);
--予防接種依頼テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_yssessyuirai.atenano AND tt_bhnyseikenirai.edano=tt_yssessyuirai.edano',0);
--予防接種依頼テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_yssessyuirai.atenano',0);
--予防接種依頼サブテーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_afatena','tt_afatena.atenano=tt_yssessyuirai_sub.atenano',0);
--予防接種依頼サブテーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_afjumin','tt_afjumin.atenano=tt_yssessyuirai_sub.atenano',0);
--予防接種依頼サブテーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_afkaigo','tt_afkaigo.atenano=tt_yssessyuirai_sub.atenano',0);
--予防接種依頼サブテーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_afkokihoken','tt_afkokihoken.atenano=tt_yssessyuirai_sub.atenano',0);
--予防接種依頼サブテーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_afkokuho','tt_afkokuho.atenano=tt_yssessyuirai_sub.atenano',0);
--予防接種依頼サブテーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_afseiho','tt_afseiho.atenano=tt_yssessyuirai_sub.atenano',0);
--予防接種依頼サブテーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_yssessyuirai_sub.atenano',0);
--予防接種依頼サブテーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_yssessyuirai_sub.atenano',0);
--予防接種依頼サブテーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_yssessyuirai_sub.atenano',0);
--予防接種依頼サブテーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_yssessyuirai_sub.atenano',0);
--予防接種依頼サブテーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_yssessyuirai_sub.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_yssessyuirai_sub.edano',0);
--予防接種依頼サブテーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_yssessyuirai_sub.atenano AND tt_bhnyseikenkekka.edano=tt_yssessyuirai_sub.edano',0);
--予防接種依頼サブテーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_yssessyuirai_sub.atenano',0);
--予防接種依頼サブテーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_yssessyuirai_sub.atenano AND tt_bhnymijusinsyakansyo.edano=tt_yssessyuirai_sub.edano',0);
--予防接種依頼サブテーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_yssessyuirai_sub.atenano AND tt_bhnyseikenirai.edano=tt_yssessyuirai_sub.edano',0);
--予防接種依頼サブテーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_yssessyuirai_sub.atenano AND tt_yssessyuirai.edano=tt_yssessyuirai_sub.edano',0);
--予防接種依頼サブテーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_yssessyuirai_sub.atenano',0);
--予防接種依頼サブテーブル - 予防接種入力チェックマスタ
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuirai_sub','tm_ysnyuryokucheck','tm_ysnyuryokucheck.sessyucd=tt_yssessyuirai_sub.sessyucd AND tm_ysnyuryokucheck.kaisu=tt_yssessyuirai_sub.kaisu',0);
--予防接種テーブル - 会場情報マスタ
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tm_afkaijo','tm_afkaijo.kaijocd=tt_yssessyu.kaijocd',0);
--予防接種テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tt_afatena','tt_afatena.atenano=tt_yssessyu.atenano',0);
--予防接種テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tt_afjumin','tt_afjumin.atenano=tt_yssessyu.atenano',0);
--予防接種テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tt_afkaigo','tt_afkaigo.atenano=tt_yssessyu.atenano',0);
--予防接種テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tt_afkokihoken','tt_afkokihoken.atenano=tt_yssessyu.atenano',0);
--予防接種テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tt_afkokuho','tt_afkokuho.atenano=tt_yssessyu.atenano',0);
--予防接種テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tt_afseiho','tt_afseiho.atenano=tt_yssessyu.atenano',0);
--予防接種テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_yssessyu.atenano',0);
--予防接種テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_yssessyu.atenano',0);
--予防接種テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_yssessyu.atenano',0);
--予防接種テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_yssessyu.atenano',0);
--予防接種テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_yssessyu.atenano',0);
--予防接種テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_yssessyu.atenano',0);
--予防接種テーブル - 予防接種入力チェックマスタ
INSERT INTO tm_eutablejoin VALUES('tt_yssessyu','tm_ysnyuryokucheck','tm_ysnyuryokucheck.sessyucd=tt_yssessyu.sessyucd AND tm_ysnyuryokucheck.kaisu=tt_yssessyu.kaisu',0);
--風疹抗体検査テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotai','tt_afatena','tt_afatena.atenano=tt_ysfusinkotai.atenano',0);
--風疹抗体検査テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotai','tt_afjumin','tt_afjumin.atenano=tt_ysfusinkotai.atenano',0);
--風疹抗体検査テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotai','tt_afkaigo','tt_afkaigo.atenano=tt_ysfusinkotai.atenano',0);
--風疹抗体検査テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotai','tt_afkokihoken','tt_afkokihoken.atenano=tt_ysfusinkotai.atenano',0);
--風疹抗体検査テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotai','tt_afkokuho','tt_afkokuho.atenano=tt_ysfusinkotai.atenano',0);
--風疹抗体検査テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotai','tt_afseiho','tt_afseiho.atenano=tt_ysfusinkotai.atenano',0);
--風疹抗体検査テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotai','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_ysfusinkotai.atenano',0);
--風疹抗体検査テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotai','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_ysfusinkotai.atenano',0);
--風疹抗体検査テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotai','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_ysfusinkotai.atenano',0);
--風疹抗体検査テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotai','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_ysfusinkotai.atenano',0);
--風疹抗体検査テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotai','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_ysfusinkotai.atenano',0);
--罹患テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysrikan','tt_afatena','tt_afatena.atenano=tt_ysrikan.atenano',0);
--罹患テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysrikan','tt_afjumin','tt_afjumin.atenano=tt_ysrikan.atenano',0);
--罹患テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysrikan','tt_afkaigo','tt_afkaigo.atenano=tt_ysrikan.atenano',0);
--罹患テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysrikan','tt_afkokihoken','tt_afkokihoken.atenano=tt_ysrikan.atenano',0);
--罹患テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysrikan','tt_afkokuho','tt_afkokuho.atenano=tt_ysrikan.atenano',0);
--罹患テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysrikan','tt_afseiho','tt_afseiho.atenano=tt_ysrikan.atenano',0);
--罹患テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysrikan','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_ysrikan.atenano',0);
--罹患テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysrikan','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_ysrikan.atenano',0);
--罹患テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysrikan','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_ysrikan.atenano',0);
--罹患テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysrikan','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_ysrikan.atenano',0);
--罹患テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysrikan','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_ysrikan.atenano',0);
--罹患テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysrikan','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_ysrikan.atenano',0);
--予防接種（フリー項目）個人テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yskojinfree','tt_afatena','tt_afatena.atenano=tt_yskojinfree.atenano',0);
--予防接種（フリー項目）個人テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yskojinfree','tt_afjumin','tt_afjumin.atenano=tt_yskojinfree.atenano',0);
--予防接種（フリー項目）個人テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yskojinfree','tt_afkaigo','tt_afkaigo.atenano=tt_yskojinfree.atenano',0);
--予防接種（フリー項目）個人テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yskojinfree','tt_afkokihoken','tt_afkokihoken.atenano=tt_yskojinfree.atenano',0);
--予防接種（フリー項目）個人テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yskojinfree','tt_afkokuho','tt_afkokuho.atenano=tt_yskojinfree.atenano',0);
--予防接種（フリー項目）個人テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yskojinfree','tt_afseiho','tt_afseiho.atenano=tt_yskojinfree.atenano',0);
--予防接種（フリー項目）個人テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yskojinfree','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_yskojinfree.atenano',0);
--予防接種（フリー項目）個人テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yskojinfree','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_yskojinfree.atenano',0);
--予防接種（フリー項目）個人テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yskojinfree','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_yskojinfree.atenano',0);
--予防接種（フリー項目）個人テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yskojinfree','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_yskojinfree.atenano',0);
--予防接種（フリー項目）個人テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yskojinfree','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_yskojinfree.atenano',0);
--予防接種（フリー項目）個人テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yskojinfree','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_yskojinfree.atenano',0);
--予防接種（フリー項目）個人テーブル - 風しん抗体検査（フリー項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yskojinfree','tt_ysfusinkotaifree','tt_ysfusinkotaifree.atenano=tt_yskojinfree.atenano AND tt_ysfusinkotaifree.itemcd=tt_yskojinfree.itemcd',0);
--予防接種（フリー項目：個人単位）コントロールマスタ - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_yskojinfreeitem','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tm_yskojinfreeitem.jigyocd',0);
--予防接種（フリー項目：個人単位）コントロールマスタ - 成人保健検診結果（フリー）項目コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_yskojinfreeitem','tm_shfreeitem','tm_shfreeitem.jigyocd=tm_yskojinfreeitem.jigyocd AND tm_shfreeitem.itemcd=tm_yskojinfreeitem.itemcd',0);
--予防接種（フリー項目：個人単位）コントロールマスタ - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_yskojinfreeitem','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tm_yskojinfreeitem.jigyocd',0);
--予防接種（フリー項目：個人単位）コントロールマスタ - 予防接種（フリー項目：個人接種単位）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_yskojinfreeitem','tm_yssessyufreeitem','tm_yssessyufreeitem.jigyocd=tm_yskojinfreeitem.jigyocd AND tm_yssessyufreeitem.itemcd=tm_yskojinfreeitem.itemcd',0);
--予防接種（フリー項目：個人単位）コントロールマスタ - 予防接種依頼（フリー項目）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_yskojinfreeitem','tm_yssessyuiraifreeitem','tm_yssessyuiraifreeitem.jigyocd=tm_yskojinfreeitem.jigyocd AND tm_yssessyuiraifreeitem.itemcd=tm_yskojinfreeitem.itemcd',0);
--予防接種（フリー項目：個人単位）コントロールマスタ - 風しん抗体検査（フリー項目）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_yskojinfreeitem','tm_ysfusinkotaifreeitem','tm_ysfusinkotaifreeitem.jigyocd=tm_yskojinfreeitem.jigyocd AND tm_ysfusinkotaifreeitem.itemcd=tm_yskojinfreeitem.itemcd',0);
--予防接種（フリー項目）接種テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tt_afatena','tt_afatena.atenano=tt_yssessyufree.atenano',0);
--予防接種（フリー項目）接種テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tt_afjumin','tt_afjumin.atenano=tt_yssessyufree.atenano',0);
--予防接種（フリー項目）接種テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tt_afkaigo','tt_afkaigo.atenano=tt_yssessyufree.atenano',0);
--予防接種（フリー項目）接種テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tt_afkokihoken','tt_afkokihoken.atenano=tt_yssessyufree.atenano',0);
--予防接種（フリー項目）接種テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tt_afkokuho','tt_afkokuho.atenano=tt_yssessyufree.atenano',0);
--予防接種（フリー項目）接種テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tt_afseiho','tt_afseiho.atenano=tt_yssessyufree.atenano',0);
--予防接種（フリー項目）接種テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_yssessyufree.atenano',0);
--予防接種（フリー項目）接種テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_yssessyufree.atenano',0);
--予防接種（フリー項目）接種テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_yssessyufree.atenano',0);
--予防接種（フリー項目）接種テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_yssessyufree.atenano',0);
--予防接種（フリー項目）接種テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_yssessyufree.atenano',0);
--予防接種（フリー項目）接種テーブル - 予防接種テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tt_yssessyu','tt_yssessyu.atenano=tt_yssessyufree.atenano AND tt_yssessyu.sessyucd=tt_yssessyufree.sessyucd AND tt_yssessyu.kaisu=tt_yssessyufree.kaisu AND tt_yssessyu.edano=tt_yssessyufree.edano',0);
--予防接種（フリー項目）接種テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_yssessyufree.atenano',0);
--予防接種（フリー項目）接種テーブル - 予防接種入力チェックマスタ
INSERT INTO tm_eutablejoin VALUES('tt_yssessyufree','tm_ysnyuryokucheck','tm_ysnyuryokucheck.sessyucd=tt_yssessyufree.sessyucd AND tm_ysnyuryokucheck.kaisu=tt_yssessyufree.kaisu',0);
--予防接種（フリー項目：個人接種単位）コントロールマスタ - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_yssessyufreeitem','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tm_yssessyufreeitem.jigyocd',0);
--予防接種（フリー項目：個人接種単位）コントロールマスタ - 成人保健検診結果（フリー）項目コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_yssessyufreeitem','tm_shfreeitem','tm_shfreeitem.jigyocd=tm_yssessyufreeitem.jigyocd AND tm_shfreeitem.itemcd=tm_yssessyufreeitem.itemcd',0);
--予防接種（フリー項目：個人接種単位）コントロールマスタ - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_yssessyufreeitem','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tm_yssessyufreeitem.jigyocd',0);
--予防接種（フリー項目：個人接種単位）コントロールマスタ - 予防接種（フリー項目：個人単位）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_yssessyufreeitem','tm_yskojinfreeitem','tm_yskojinfreeitem.jigyocd=tm_yssessyufreeitem.jigyocd AND tm_yskojinfreeitem.itemcd=tm_yssessyufreeitem.itemcd',0);
--予防接種（フリー項目：個人接種単位）コントロールマスタ - 予防接種依頼（フリー項目）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_yssessyufreeitem','tm_yssessyuiraifreeitem','tm_yssessyuiraifreeitem.jigyocd=tm_yssessyufreeitem.jigyocd AND tm_yssessyuiraifreeitem.itemcd=tm_yssessyufreeitem.itemcd',0);
--予防接種（フリー項目：個人接種単位）コントロールマスタ - 風しん抗体検査（フリー項目）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_yssessyufreeitem','tm_ysfusinkotaifreeitem','tm_ysfusinkotaifreeitem.jigyocd=tm_yssessyufreeitem.jigyocd AND tm_ysfusinkotaifreeitem.itemcd=tm_yssessyufreeitem.itemcd',0);
--予防接種依頼（フリー項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_afatena','tt_afatena.atenano=tt_yssessyuiraifree.atenano',0);
--予防接種依頼（フリー項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_afjumin','tt_afjumin.atenano=tt_yssessyuiraifree.atenano',0);
--予防接種依頼（フリー項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_afkaigo','tt_afkaigo.atenano=tt_yssessyuiraifree.atenano',0);
--予防接種依頼（フリー項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_afkokihoken','tt_afkokihoken.atenano=tt_yssessyuiraifree.atenano',0);
--予防接種依頼（フリー項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_afkokuho','tt_afkokuho.atenano=tt_yssessyuiraifree.atenano',0);
--予防接種依頼（フリー項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_afseiho','tt_afseiho.atenano=tt_yssessyuiraifree.atenano',0);
--予防接種依頼（フリー項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_yssessyuiraifree.atenano',0);
--予防接種依頼（フリー項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_yssessyuiraifree.atenano',0);
--予防接種依頼（フリー項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_yssessyuiraifree.atenano',0);
--予防接種依頼（フリー項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_yssessyuiraifree.atenano',0);
--予防接種依頼（フリー項目）テーブル - 新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei.atenano=tt_yssessyuiraifree.atenano AND tt_bhnytyokakukensahiyojosei.edano=tt_yssessyuiraifree.edano',0);
--予防接種依頼（フリー項目）テーブル - 乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_bhnyseikenkekka','tt_bhnyseikenkekka.atenano=tt_yssessyuiraifree.atenano AND tt_bhnyseikenkekka.edano=tt_yssessyuiraifree.edano',0);
--予防接種依頼（フリー項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_yssessyuiraifree.atenano',0);
--予防接種依頼（フリー項目）テーブル - 未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo.atenano=tt_yssessyuiraifree.atenano AND tt_bhnymijusinsyakansyo.edano=tt_yssessyuiraifree.edano',0);
--予防接種依頼（フリー項目）テーブル - 精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_bhnyseikenirai','tt_bhnyseikenirai.atenano=tt_yssessyuiraifree.atenano AND tt_bhnyseikenirai.edano=tt_yssessyuiraifree.edano',0);
--予防接種依頼（フリー項目）テーブル - 予防接種依頼テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_yssessyuirai','tt_yssessyuirai.atenano=tt_yssessyuiraifree.atenano AND tt_yssessyuirai.edano=tt_yssessyuiraifree.edano',0);
--予防接種依頼（フリー項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_yssessyuiraifree','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_yssessyuiraifree.atenano',0);
--予防接種依頼（フリー項目）コントロールマスタ - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_yssessyuiraifreeitem','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tm_yssessyuiraifreeitem.jigyocd',0);
--予防接種依頼（フリー項目）コントロールマスタ - 成人保健検診結果（フリー）項目コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_yssessyuiraifreeitem','tm_shfreeitem','tm_shfreeitem.jigyocd=tm_yssessyuiraifreeitem.jigyocd AND tm_shfreeitem.itemcd=tm_yssessyuiraifreeitem.itemcd',0);
--予防接種依頼（フリー項目）コントロールマスタ - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_yssessyuiraifreeitem','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tm_yssessyuiraifreeitem.jigyocd',0);
--予防接種依頼（フリー項目）コントロールマスタ - 予防接種（フリー項目：個人単位）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_yssessyuiraifreeitem','tm_yskojinfreeitem','tm_yskojinfreeitem.jigyocd=tm_yssessyuiraifreeitem.jigyocd AND tm_yskojinfreeitem.itemcd=tm_yssessyuiraifreeitem.itemcd',0);
--予防接種依頼（フリー項目）コントロールマスタ - 予防接種（フリー項目：個人接種単位）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_yssessyuiraifreeitem','tm_yssessyufreeitem','tm_yssessyufreeitem.jigyocd=tm_yssessyuiraifreeitem.jigyocd AND tm_yssessyufreeitem.itemcd=tm_yssessyuiraifreeitem.itemcd',0);
--予防接種依頼（フリー項目）コントロールマスタ - 風しん抗体検査（フリー項目）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_yssessyuiraifreeitem','tm_ysfusinkotaifreeitem','tm_ysfusinkotaifreeitem.jigyocd=tm_yssessyuiraifreeitem.jigyocd AND tm_ysfusinkotaifreeitem.itemcd=tm_yssessyuiraifreeitem.itemcd',0);
--風しん抗体検査（フリー項目）テーブル - 宛名テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotaifree','tt_afatena','tt_afatena.atenano=tt_ysfusinkotaifree.atenano',0);
--風しん抗体検査（フリー項目）テーブル - 【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotaifree','tt_afjumin','tt_afjumin.atenano=tt_ysfusinkotaifree.atenano',0);
--風しん抗体検査（フリー項目）テーブル - 【介護保険】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotaifree','tt_afkaigo','tt_afkaigo.atenano=tt_ysfusinkotaifree.atenano',0);
--風しん抗体検査（フリー項目）テーブル - 【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotaifree','tt_afkokihoken','tt_afkokihoken.atenano=tt_ysfusinkotaifree.atenano',0);
--風しん抗体検査（フリー項目）テーブル - 【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotaifree','tt_afkokuho','tt_afkokuho.atenano=tt_ysfusinkotaifree.atenano',0);
--風しん抗体検査（フリー項目）テーブル - 【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotaifree','tt_afseiho','tt_afseiho.atenano=tt_ysfusinkotaifree.atenano',0);
--風しん抗体検査（フリー項目）テーブル - 【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotaifree','tt_afsiensotitaisyosya','tt_afsiensotitaisyosya.atenano=tt_ysfusinkotaifree.atenano',0);
--風しん抗体検査（フリー項目）テーブル - 【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotaifree','tt_afsyogaitetyo','tt_afsyogaitetyo.atenano=tt_ysfusinkotaifree.atenano',0);
--風しん抗体検査（フリー項目）テーブル - 出生時状況（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotaifree','tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo.atenano=tt_ysfusinkotaifree.atenano',0);
--風しん抗体検査（フリー項目）テーブル - 新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotaifree','tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka.atenano=tt_ysfusinkotaifree.atenano',0);
--風しん抗体検査（フリー項目）テーブル - 健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotaifree','tt_bhnykensinjusinreki','tt_bhnykensinjusinreki.atenano=tt_ysfusinkotaifree.atenano',0);
--風しん抗体検査（フリー項目）テーブル - 風疹抗体検査テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotaifree','tt_ysfusinkotai','tt_ysfusinkotai.atenano=tt_ysfusinkotaifree.atenano',0);
--風しん抗体検査（フリー項目）テーブル - 予防接種（フリー項目）個人テーブル
INSERT INTO tm_eutablejoin VALUES('tt_ysfusinkotaifree','tt_yskojinfree','tt_yskojinfree.atenano=tt_ysfusinkotaifree.atenano AND tt_yskojinfree.itemcd=tt_ysfusinkotaifree.itemcd',0);
--風しん抗体検査（フリー項目）コントロールマスタ - その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_ysfusinkotaifreeitem','tm_kksonotasidojigyo','tm_kksonotasidojigyo.jigyocd=tm_ysfusinkotaifreeitem.jigyocd',0);
--風しん抗体検査（フリー項目）コントロールマスタ - 成人保健検診結果（フリー）項目コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_ysfusinkotaifreeitem','tm_shfreeitem','tm_shfreeitem.jigyocd=tm_ysfusinkotaifreeitem.jigyocd AND tm_shfreeitem.itemcd=tm_ysfusinkotaifreeitem.itemcd',0);
--風しん抗体検査（フリー項目）コントロールマスタ - 成人健（検）診事業マスタ
INSERT INTO tm_eutablejoin VALUES('tm_ysfusinkotaifreeitem','tm_shkensinjigyo','tm_shkensinjigyo.jigyocd=tm_ysfusinkotaifreeitem.jigyocd',0);
--風しん抗体検査（フリー項目）コントロールマスタ - 予防接種（フリー項目：個人単位）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_ysfusinkotaifreeitem','tm_yskojinfreeitem','tm_yskojinfreeitem.jigyocd=tm_ysfusinkotaifreeitem.jigyocd AND tm_yskojinfreeitem.itemcd=tm_ysfusinkotaifreeitem.itemcd',0);
--風しん抗体検査（フリー項目）コントロールマスタ - 予防接種（フリー項目：個人接種単位）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_ysfusinkotaifreeitem','tm_yssessyufreeitem','tm_yssessyufreeitem.jigyocd=tm_ysfusinkotaifreeitem.jigyocd AND tm_yssessyufreeitem.itemcd=tm_ysfusinkotaifreeitem.itemcd',0);
--風しん抗体検査（フリー項目）コントロールマスタ - 予防接種依頼（フリー項目）コントロールマスタ
INSERT INTO tm_eutablejoin VALUES('tm_ysfusinkotaifreeitem','tm_yssessyuiraifreeitem','tm_yssessyuiraifreeitem.jigyocd=tm_ysfusinkotaifreeitem.jigyocd AND tm_yssessyuiraifreeitem.itemcd=tm_ysfusinkotaifreeitem.itemcd',0);