delete from tm_eutable;
--コントロールマスタ
INSERT INTO tm_eutable VALUES('tm_afctrl','tm_afctrl','コントロールマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--コントロールメインマスタ
INSERT INTO tm_eutable VALUES('tm_afctrl_main','tm_afctrl_main','コントロールメインマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--ファイルマスタ
INSERT INTO tm_eutable VALUES('tm_affile','tm_affile','ファイルマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--汎用マスタ
INSERT INTO tm_eutable VALUES('tm_afhanyo','tm_afhanyo','汎用マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--汎用メインマスタ
INSERT INTO tm_eutable VALUES('tm_afhanyo_main','tm_afhanyo_main','汎用メインマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--ヘルプドキュメントマスタ
INSERT INTO tm_eutable VALUES('tm_afhelpdoc','tm_afhelpdoc','ヘルプドキュメントマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--会場情報マスタ
INSERT INTO tm_eutable VALUES('tm_afkaijo','tm_afkaijo','会場情報マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--会場情報サブマスタ
INSERT INTO tm_eutable VALUES('tm_afkaijo_sub','tm_afkaijo_sub','会場情報サブマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--医療機関マスタ
INSERT INTO tm_eutable VALUES('tm_afkikan','tm_afkikan','医療機関マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--医療機関サブマスタ
INSERT INTO tm_eutable VALUES('tm_afkikan_sub','tm_afkikan_sub','医療機関サブマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--機能マスタ
INSERT INTO tm_eutable VALUES('tm_afkino','tm_afkino','機能マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--名称マスタ
INSERT INTO tm_eutable VALUES('tm_afmeisyo','tm_afmeisyo','名称マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--名称メインマスタ
INSERT INTO tm_eutable VALUES('tm_afmeisyo_main','tm_afmeisyo_main','名称メインマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--メニューマスタ
INSERT INTO tm_eutable VALUES('tm_afmenu','tm_afmenu','メニューマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--メッセージコントロールマスタ
INSERT INTO tm_eutable VALUES('tm_afmsgctrl','tm_afmsgctrl','メッセージコントロールマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--市区町村マスタ
INSERT INTO tm_eutable VALUES('tm_afsikutyoson','tm_afsikutyoson','市区町村マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--事業従事者（担当者）情報マスタ
INSERT INTO tm_eutable VALUES('tm_afstaff','tm_afstaff','事業従事者（担当者）情報マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--事業従事者（担当者）所属機関
INSERT INTO tm_eutable VALUES('tm_afstaff_kikan','tm_afstaff_kikan','事業従事者（担当者）所属機関', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--事業従事者（担当者）サブマスタ
INSERT INTO tm_eutable VALUES('tm_afstaff_sub','tm_afstaff_sub','事業従事者（担当者）サブマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--所属グループマスタ
INSERT INTO tm_eutable VALUES('tm_afsyozoku','tm_afsyozoku','所属グループマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--地区情報マスタ
INSERT INTO tm_eutable VALUES('tm_aftiku','tm_aftiku','地区情報マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--地区情報サブマスタ
INSERT INTO tm_eutable VALUES('tm_aftiku_sub','tm_aftiku_sub','地区情報サブマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--町字マスタ
INSERT INTO tm_eutable VALUES('tm_aftyoaza','tm_aftyoaza','町字マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--ユーザーマスタ
INSERT INTO tm_eutable VALUES('tm_afuser','tm_afuser','ユーザーマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--宛名テーブル
INSERT INTO tm_eutable VALUES('tt_afatena','tt_afatena','宛名テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--宛名番号検索履歴テーブル
INSERT INTO tm_eutable VALUES('tt_afatenalog','tt_afatenalog','宛名番号検索履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--画面権限テーブル
INSERT INTO tm_eutable VALUES('tt_afauthgamen','tt_afauthgamen','画面権限テーブル', '5', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--帳票権限テーブル
INSERT INTO tm_eutable VALUES('tt_afauthreport','tt_afauthreport','帳票権限テーブル', '5', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--部署（支所）別更新権限テーブル
INSERT INTO tm_eutable VALUES('tt_afauthsisyo','tt_afauthsisyo','部署（支所）別更新権限テーブル', '5', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--バッチログテーブル
INSERT INTO tm_eutable VALUES('tt_afbatchlog','tt_afbatchlog','バッチログテーブル', '4', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--共通ドキュメントテーブル
INSERT INTO tm_eutable VALUES('tt_afcomdoc','tt_afcomdoc','共通ドキュメントテーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--詳細条件設定テーブル
INSERT INTO tm_eutable VALUES('tt_affilter','tt_affilter','詳細条件設定テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--外部連携処理結果履歴テーブル
INSERT INTO tm_eutable VALUES('tt_afgaibulog','tt_afgaibulog','外部連携処理結果履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--お知らせテーブル
INSERT INTO tm_eutable VALUES('tt_afinfo','tt_afinfo','お知らせテーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--お知らせ確認状態テーブル
INSERT INTO tm_eutable VALUES('tt_afinfo_user','tt_afinfo_user','お知らせ確認状態テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【住民基本台帳】住民情報テーブル
INSERT INTO tm_eutable VALUES('tt_afjumin','tt_afjumin','【住民基本台帳】住民情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【住民基本台帳】住民情報履歴テーブル
INSERT INTO tm_eutable VALUES('tt_afjumin_reki','tt_afjumin_reki','【住民基本台帳】住民情報履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--住登外者情報テーブル
INSERT INTO tm_eutable VALUES('tt_afjutogai','tt_afjutogai','住登外者情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--住登外者独自施策システム等情報テーブル
INSERT INTO tm_eutable VALUES('tt_afjutogai_dokujisystem','tt_afjutogai_dokujisystem','住登外者独自施策システム等情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--住登外者参照業務情報テーブル
INSERT INTO tm_eutable VALUES('tt_afjutogai_gyomu','tt_afjutogai_gyomu','住登外者参照業務情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【介護保険】被保険者情報テーブル
INSERT INTO tm_eutable VALUES('tt_afkaigo','tt_afkaigo','【介護保険】被保険者情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【介護保険】被保険者情報履歴テーブル
INSERT INTO tm_eutable VALUES('tt_afkaigo_reki','tt_afkaigo_reki','【介護保険】被保険者情報履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--個人ドキュメントテーブル
INSERT INTO tm_eutable VALUES('tt_afkojindoc','tt_afkojindoc','個人ドキュメントテーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【個人住民税】納税義務者情報テーブル
INSERT INTO tm_eutable VALUES('tt_afkojinzeigimusya','tt_afkojinzeigimusya','【個人住民税】納税義務者情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【個人住民税】納税義務者情報履歴テーブル
INSERT INTO tm_eutable VALUES('tt_afkojinzeigimusya_reki','tt_afkojinzeigimusya_reki','【個人住民税】納税義務者情報履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【個人住民税】個人住民税課税情報テーブル
INSERT INTO tm_eutable VALUES('tt_afkojinzeikazei','tt_afkojinzeikazei','【個人住民税】個人住民税課税情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【個人住民税】個人住民税課税情報履歴テーブル
INSERT INTO tm_eutable VALUES('tt_afkojinzeikazei_reki','tt_afkojinzeikazei_reki','【個人住民税】個人住民税課税情報履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【個人住民税】個人住民税税額控除情報テーブル
INSERT INTO tm_eutable VALUES('tt_afkojinzeikojo','tt_afkojinzeikojo','【個人住民税】個人住民税税額控除情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【個人住民税】個人住民税税額控除情報履歴テーブル
INSERT INTO tm_eutable VALUES('tt_afkojinzeikojo_reki','tt_afkojinzeikojo_reki','【個人住民税】個人住民税税額控除情報履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【後期高齢者医療】被保険者情報テーブル
INSERT INTO tm_eutable VALUES('tt_afkokihoken','tt_afkokihoken','【後期高齢者医療】被保険者情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【後期高齢者医療】被保険者情報履歴テーブル
INSERT INTO tm_eutable VALUES('tt_afkokihoken_reki','tt_afkokihoken_reki','【後期高齢者医療】被保険者情報履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【国民健康保険】国保資格情報テーブル
INSERT INTO tm_eutable VALUES('tt_afkokuho','tt_afkokuho','【国民健康保険】国保資格情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【国民健康保険】国保資格情報履歴テーブル
INSERT INTO tm_eutable VALUES('tt_afkokuho_reki','tt_afkokuho_reki','【国民健康保険】国保資格情報履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--メインログテーブル
INSERT INTO tm_eutable VALUES('tt_aflog','tt_aflog','メインログテーブル', '4', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--宛名番号ログテーブル
INSERT INTO tm_eutable VALUES('tt_aflogatena','tt_aflogatena','宛名番号ログテーブル', '4', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--テーブル項目値変更ログテーブル
INSERT INTO tm_eutable VALUES('tt_aflogcolumn','tt_aflogcolumn','テーブル項目値変更ログテーブル', '4', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--DB操作ログテーブル
INSERT INTO tm_eutable VALUES('tt_aflogdb','tt_aflogdb','DB操作ログテーブル', '4', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--メモテーブル
INSERT INTO tm_eutable VALUES('tt_afmemo','tt_afmemo','メモテーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--メモ情報（世帯）テーブル
INSERT INTO tm_eutable VALUES('tt_afmemosetai','tt_afmemosetai','メモ情報（世帯）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--お気に入りテーブル
INSERT INTO tm_eutable VALUES('tt_afokiniiri','tt_afokiniiri','お気に入りテーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--個人番号管理テーブル
INSERT INTO tm_eutable VALUES('tt_afpersonalno','tt_afpersonalno','個人番号管理テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--連絡先テーブル
INSERT INTO tm_eutable VALUES('tt_afrenrakusaki','tt_afrenrakusaki','連絡先テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【生活保護】生活保護受給情報テーブル
INSERT INTO tm_eutable VALUES('tt_afseiho','tt_afseiho','【生活保護】生活保護受給情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【生活保護】生活保護受給情報履歴テーブル
INSERT INTO tm_eutable VALUES('tt_afseiho_reki','tt_afseiho_reki','【生活保護】生活保護受給情報履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【住民基本台帳】支援措置対象者情報テーブル
INSERT INTO tm_eutable VALUES('tt_afsiensotitaisyosya','tt_afsiensotitaisyosya','【住民基本台帳】支援措置対象者情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【住民基本台帳】支援措置対象者情報履歴テーブル
INSERT INTO tm_eutable VALUES('tt_afsiensotitaisyosya_reki','tt_afsiensotitaisyosya_reki','【住民基本台帳】支援措置対象者情報履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--使用履歴テーブル
INSERT INTO tm_eutable VALUES('tt_afsiyorireki','tt_afsiyorireki','使用履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--送付先管理テーブル
INSERT INTO tm_eutable VALUES('tt_afsofusaki','tt_afsofusaki','送付先管理テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【障害者福祉】身体障害者手帳等情報テーブル
INSERT INTO tm_eutable VALUES('tt_afsyogaitetyo','tt_afsyogaitetyo','【障害者福祉】身体障害者手帳等情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--【障害者福祉】身体障害者手帳等情報履歴テーブル
INSERT INTO tm_eutable VALUES('tt_afsyogaitetyo_reki','tt_afsyogaitetyo_reki','【障害者福祉】身体障害者手帳等情報履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--通信ログテーブル
INSERT INTO tm_eutable VALUES('tt_aftusinlog','tt_aftusinlog','通信ログテーブル', '4', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--ユーザー所属部署（支所）テーブル
INSERT INTO tm_eutable VALUES('tt_afuser_sisyo','tt_afuser_sisyo','ユーザー所属部署（支所）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--タスクスケジュールマスタ
INSERT INTO tm_eutable VALUES('tm_aftaskschedule','tm_aftaskschedule','タスクスケジュールマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--基準値マスタ
INSERT INTO tm_eutable VALUES('tm_kkkijun','tm_kkkijun','基準値マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--指導（フリー項目）コントロールマスタ
INSERT INTO tm_eutable VALUES('tm_kksidofreeitem','tm_kksidofreeitem','指導（フリー項目）コントロールマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--その他日程事業・保健指導事業マスタ
INSERT INTO tm_eutable VALUES('tm_kksonotasidojigyo','tm_kksonotasidojigyo','その他日程事業・保健指導事業マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--フォロー結果情報テーブル
INSERT INTO tm_eutable VALUES('tt_kkfollowkekka','tt_kkfollowkekka','フォロー結果情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--フォロー内容情報テーブル
INSERT INTO tm_eutable VALUES('tt_kkfollownaiyo','tt_kkfollownaiyo','フォロー内容情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--フォロー予定情報テーブル
INSERT INTO tm_eutable VALUES('tt_kkfollowyotei','tt_kkfollowyotei','フォロー予定情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--保健指導事業（フリー項目）入力情報テーブル
INSERT INTO tm_eutable VALUES('tt_kkhokensidofree','tt_kkhokensidofree','保健指導事業（フリー項目）入力情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--保健指導結果情報（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_kkhokensido_kekka','tt_kkhokensido_kekka','保健指導結果情報（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--保健指導申込情報（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_kkhokensido_mosikomi','tt_kkhokensido_mosikomi','保健指導申込情報（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--保健指導担当者テーブル
INSERT INTO tm_eutable VALUES('tt_kkhokensido_staff','tt_kkhokensido_staff','保健指導担当者テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--実施報告書（日報）情報テーブル
INSERT INTO tm_eutable VALUES('tt_kkjissihokokusyo','tt_kkjissihokokusyo','実施報告書（日報）情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--実施報告書（日報）情報サブテーブル
INSERT INTO tm_eutable VALUES('tt_kkjissihokokusyo_sub','tt_kkjissihokokusyo_sub','実施報告書（日報）情報サブテーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--帳票発行対象外者テーブル
INSERT INTO tm_eutable VALUES('tt_kkrpthakkotaisyogaisya','tt_kkrpthakkotaisyogaisya','帳票発行対象外者テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--集団指導事業（フリー項目）入力情報テーブル
INSERT INTO tm_eutable VALUES('tt_kksyudansidofree','tt_kksyudansidofree','集団指導事業（フリー項目）入力情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--集団指導結果情報（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_kksyudansido_kekka','tt_kksyudansido_kekka','集団指導結果情報（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--集団指導申込情報（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_kksyudansido_mosikomi','tt_kksyudansido_mosikomi','集団指導申込情報（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--集団指導参加者テーブル
INSERT INTO tm_eutable VALUES('tt_kksyudansido_sankasya','tt_kksyudansido_sankasya','集団指導参加者テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--集団指導参加者（フリー項目）入力情報テーブル
INSERT INTO tm_eutable VALUES('tt_kksyudansido_sankasyafree','tt_kksyudansido_sankasyafree','集団指導参加者（フリー項目）入力情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--集団指導参加者結果情報（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_kksyudansido_sankasyakekka','tt_kksyudansido_sankasyakekka','集団指導参加者結果情報（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--集団指導参加者申込情報（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_kksyudansido_sankasyamosikomi','tt_kksyudansido_sankasyamosikomi','集団指導参加者申込情報（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--集団指導担当者テーブル
INSERT INTO tm_eutable VALUES('tt_kksyudansido_staff','tt_kksyudansido_staff','集団指導担当者テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--一括取込入力マスタ
INSERT INTO tm_eutable VALUES('tm_kktorinyuryoku','tm_kktorinyuryoku','一括取込入力マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--取込基本情報マスタ
INSERT INTO tm_eutable VALUES('tm_kktori_kihon','tm_kktori_kihon','取込基本情報マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--一括取込入力対象テーブルマスタ
INSERT INTO tm_eutable VALUES('tm_kktorinyuryoku_taisyotable','tm_kktorinyuryoku_taisyotable','一括取込入力対象テーブルマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--取込IFマスタ
INSERT INTO tm_eutable VALUES('tm_kktori_interface','tm_kktori_interface','取込IFマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--一括取込入力項目定義マスタ
INSERT INTO tm_eutable VALUES('tm_kktorinyuryoku_item','tm_kktorinyuryoku_item','一括取込入力項目定義マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--一括取込入力変換コードメインマスタ
INSERT INTO tm_eutable VALUES('tm_kktorinyuryoku_henkancode_main','tm_kktorinyuryoku_henkancode_main','一括取込入力変換コードメインマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--取込変換コードマスタ
INSERT INTO tm_eutable VALUES('tm_kktori_henkancode','tm_kktori_henkancode','取込変換コードマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--取込項目マッピングマスタ
INSERT INTO tm_eutable VALUES('tm_kktori_mapping','tm_kktori_mapping','取込項目マッピングマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--一括取込入力登録マスタ
INSERT INTO tm_eutable VALUES('tm_kktorinyuryoku_toroku','tm_kktorinyuryoku_toroku','一括取込入力登録マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--一括取込入力テーブルマスタ
INSERT INTO tm_eutable VALUES('tm_kktorinyuryoku_table','tm_kktorinyuryoku_table','一括取込入力テーブルマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--一括取込入力プロシージャマスタ
INSERT INTO tm_eutable VALUES('tm_kktorinyuryoku_proc','tm_kktorinyuryoku_proc','一括取込入力プロシージャマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--一括取込入力未処理テーブル
INSERT INTO tm_eutable VALUES('tt_kktorinyuryoku_misyori','tt_kktorinyuryoku_misyori','一括取込入力未処理テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--一括取込入力未処理項目テーブル
INSERT INTO tm_eutable VALUES('tt_kktorinyuryoku_misyoriitem','tt_kktorinyuryoku_misyoriitem','一括取込入力未処理項目テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--一括取込入力エラーテーブル
INSERT INTO tm_eutable VALUES('tt_kktorinyuryoku_err','tt_kktorinyuryoku_err','一括取込入力エラーテーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--一括取込入力履歴テーブル
INSERT INTO tm_eutable VALUES('tt_kktorinyuryoku_rireki','tt_kktorinyuryoku_rireki','一括取込入力履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--事業予定テーブル
INSERT INTO tm_eutable VALUES('tt_kkjigyoyotei','tt_kkjigyoyotei','事業予定テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--事業予定コーステーブル
INSERT INTO tm_eutable VALUES('tt_kkjigyoyoteicourse','tt_kkjigyoyoteicourse','事業予定コーステーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--事業予定担当者テーブル
INSERT INTO tm_eutable VALUES('tt_kkjigyoyotei_staff','tt_kkjigyoyotei_staff','事業予定担当者テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--事業予約希望者テーブル
INSERT INTO tm_eutable VALUES('tt_kkjigyoyoyakukibosya','tt_kkjigyoyoyakukibosya','事業予約希望者テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--抽出情報マスタ
INSERT INTO tm_eutable VALUES('tm_kktyusyutu','tm_kktyusyutu','抽出情報マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--対象者抽出情報テーブル
INSERT INTO tm_eutable VALUES('tt_kktaisyosya_tyusyutu','tt_kktaisyosya_tyusyutu','対象者抽出情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--対象者抽出情報項目テーブル
INSERT INTO tm_eutable VALUES('tt_kktaisyosya_tyusyutufree','tt_kktaisyosya_tyusyutufree','対象者抽出情報項目テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--対象者抽出情報サブテーブル
INSERT INTO tm_eutable VALUES('tt_kktaisyosya_tyusyutu_sub','tt_kktaisyosya_tyusyutu_sub','対象者抽出情報サブテーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--対象者抽出情報サブ項目テーブル
INSERT INTO tm_eutable VALUES('tt_kktaisyosya_tyusyutu_subfree','tt_kktaisyosya_tyusyutu_subfree','対象者抽出情報サブ項目テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--発券情報テーブル
INSERT INTO tm_eutable VALUES('tt_kkhakken','tt_kkhakken','発券情報テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--対象者抽出情報項目コントロールマスタ
INSERT INTO tm_eutable VALUES('tm_kktaisyosya_tyusyutufreeitem','tm_kktaisyosya_tyusyutufreeitem','対象者抽出情報項目コントロールマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--帳票発行履歴テーブル
INSERT INTO tm_eutable VALUES('tt_kkrpthakkorireki','tt_kkrpthakkorireki','帳票発行履歴テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--帳票発行履歴サブテーブル
INSERT INTO tm_eutable VALUES('tt_kkrpthakkorireki_sub','tt_kkrpthakkorireki_sub','帳票発行履歴サブテーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--成人保健検診結果（フリー）項目コントロールマスタ
INSERT INTO tm_eutable VALUES('tm_shfreeitem','tm_shfreeitem','成人保健検診結果（フリー）項目コントロールマスタ', '2', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--成人健（検）診事業マスタ
INSERT INTO tm_eutable VALUES('tm_shkensinjigyo','tm_shkensinjigyo','成人健（検）診事業マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--年度マスタ
INSERT INTO tm_eutable VALUES('tm_shnendo','tm_shnendo','年度マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--成人保健検診結果（フリー項目）テーブル
INSERT INTO tm_eutable VALUES('tt_shfree','tt_shfree','成人保健検診結果（フリー項目）テーブル', '2', true, 1) ON CONFLICT (tablealias) DO NOTHING;

--受診拒否理由テーブル
INSERT INTO tm_eutable VALUES('tt_shjyusinkyohiriyu','tt_shjyusinkyohiriyu','受診拒否理由テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--成人保健一次検診結果（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_shkensin','tt_shkensin','成人保健一次検診結果（固定項目）テーブル', '2', true, 1) ON CONFLICT (tablealias) DO NOTHING;

--成人保健精密検査結果（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_shseiken','tt_shseiken','成人保健精密検査結果（固定項目）テーブル', '2', true, 1) ON CONFLICT (tablealias) DO NOTHING;

--健（検）診予定テーブル
INSERT INTO tm_eutable VALUES('tt_shkensinyotei','tt_shkensinyotei','健（検）診予定テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--健（検）診予定詳細テーブル
INSERT INTO tm_eutable VALUES('tt_shkensinyoteisyosai','tt_shkensinyoteisyosai','健（検）診予定詳細テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--健（検）診予定担当者テーブル
INSERT INTO tm_eutable VALUES('tt_shkensinyotei_staff','tt_shkensinyotei_staff','健（検）診予定担当者テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--健（検）診予約希望者テーブル
INSERT INTO tm_eutable VALUES('tt_shkensinyoyakukibosya','tt_shkensinyoyakukibosya','健（検）診予約希望者テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--健（検）診予約希望者詳細テーブル
INSERT INTO tm_eutable VALUES('tt_shkensinkibosyasyosai','tt_shkensinkibosyasyosai','健（検）診予約希望者詳細テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--自己負担金マスタ
INSERT INTO tm_eutable VALUES('tm_shjikofutankin','tm_shjikofutankin','自己負担金マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--成人健（検）診予約日程事業マスタ
INSERT INTO tm_eutable VALUES('tm_shyoyakujigyo','tm_shyoyakujigyo','成人健（検）診予約日程事業マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--成人健（検）診予約日程事業サブマスタ
INSERT INTO tm_eutable VALUES('tm_shyoyakujigyo_sub','tm_shyoyakujigyo_sub','成人健（検）診予約日程事業サブマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--母子保健詳細メニューマスタ
INSERT INTO tm_eutable VALUES('tm_bhkksyosaimenu','tm_bhkksyosaimenu','母子保健詳細メニューマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--母子保健詳細タブマスタ
INSERT INTO tm_eutable VALUES('tm_bhkksyosaitab','tm_bhkksyosaitab','母子保健詳細タブマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--母子保健事業マスタ
INSERT INTO tm_eutable VALUES('tm_bhkkjigyo','tm_bhkkjigyo','母子保健事業マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--母子保健（フリー）項目コントロールマスタ
INSERT INTO tm_eutable VALUES('tm_bhkkfreeitem','tm_bhkkfreeitem','母子保健（フリー）項目コントロールマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--乳幼児パーセンタイル値マスタ
INSERT INTO tm_eutable VALUES('tm_bhnypasentairu','tm_bhnypasentairu','乳幼児パーセンタイル値マスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--乳幼児（フリー）項目テーブル
INSERT INTO tm_eutable VALUES('tt_bhnyfree','tt_bhnyfree','乳幼児（フリー）項目テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--妊産婦（フリー）項目テーブル
INSERT INTO tm_eutable VALUES('tt_bhnsfree','tt_bhnsfree','妊産婦（フリー）項目テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--出生時状況（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnysyussyojijokyo','tt_bhnysyussyojijokyo','出生時状況（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--新生児聴覚検査結果（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnytyokakukensakekka','tt_bhnytyokakukensakekka','新生児聴覚検査結果（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnytyokakukensahiyojosei','tt_bhnytyokakukensahiyojosei','新生児聴覚スクリーニング検査費用助成（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--乳幼児健診結果（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnykensinkekka','tt_bhnykensinkekka','乳幼児健診結果（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--乳幼児健診アンケート（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnykensinanketo','tt_bhnykensinanketo','乳幼児健診アンケート（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--乳幼児歯科健診結果（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnysikakensinkekka','tt_bhnysikakensinkekka','乳幼児歯科健診結果（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--独自施策（子）（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnydokujisesaku','tt_bhnydokujisesaku','独自施策（子）（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--乳幼児精密健診結果（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnyseikenkekka','tt_bhnyseikenkekka','乳幼児精密健診結果（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--健診受診履歴（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnykensinjusinreki','tt_bhnykensinjusinreki','健診受診履歴（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--未受診者勧奨（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnymijusinsyakansyo','tt_bhnymijusinsyakansyo','未受診者勧奨（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--精密健診の依頼（固定項目）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnyseikenirai','tt_bhnyseikenirai','精密健診の依頼（固定項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--妊娠届出（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnsninsintodokede','tt_bhnsninsintodokede','妊娠届出（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--妊娠届出アンケート（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnsninsintodokedeanketo','tt_bhnsninsintodokedeanketo','妊娠届出アンケート（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--母子健康手帳交付（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnsbosikenkotetyokofu','tt_bhnsbosikenkotetyokofu','母子健康手帳交付（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--出産の状態に係る（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnssyussanjotai','tt_bhnssyussanjotai','出産の状態に係る（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--妊婦健診結果（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnsninpukensinkekka','tt_bhnsninpukensinkekka','妊婦健診結果（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--妊婦健診費用助成（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnsninpukensinhiyojosei','tt_bhnsninpukensinhiyojosei','妊婦健診費用助成（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--妊婦健診費用助成（固定）サブテーブル
INSERT INTO tm_eutable VALUES('tt_bhnsninpukensinhiyojosei_sub','tt_bhnsninpukensinhiyojosei_sub','妊婦健診費用助成（固定）サブテーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--妊産婦歯科健診結果（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnssikakensinkekka','tt_bhnssikakensinkekka','妊産婦歯科健診結果（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--妊産婦歯科精健結果（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnssikaseikenkekka','tt_bhnssikaseikenkekka','妊産婦歯科精健結果（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--妊婦精健結果（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnsninpuseikenkekka','tt_bhnsninpuseikenkekka','妊婦精健結果（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--産婦健診結果（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnssanpukensinkekka','tt_bhnssanpukensinkekka','産婦健診結果（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--産婦健診費用助成（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnssanpukensinhiyojosei','tt_bhnssanpukensinhiyojosei','産婦健診費用助成（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--産婦健診費用助成（固定）サブテーブル
INSERT INTO tm_eutable VALUES('tt_bhnssanpukensinhiyojosei_sub','tt_bhnssanpukensinhiyojosei_sub','産婦健診費用助成（固定）サブテーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--産婦精密健診結果（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnssanpuseikenkekka','tt_bhnssanpuseikenkekka','産婦精密健診結果（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--産後ケア事業（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnssangocarejigyo','tt_bhnssangocarejigyo','産後ケア事業（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--独自施策（母）（固定）テーブル
INSERT INTO tm_eutable VALUES('tt_bhnsdokujisesaku','tt_bhnsdokujisesaku','独自施策（母）（固定）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--母子保健管理パターンマスタ
INSERT INTO tm_eutable VALUES('tm_bhkanripattern','tm_bhkanripattern','母子保健管理パターンマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--母子保健健診対象者テーブル
INSERT INTO tm_eutable VALUES('tm_bhkensin','tm_bhkensin','母子保健健診対象者テーブル', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--ワクチンマスタ
INSERT INTO tm_eutable VALUES('tm_ysvaccine','tm_ysvaccine','ワクチンマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--予診票発行情報テーブル(案)
INSERT INTO tm_eutable VALUES('tt_ysyosinhakko','tt_ysyosinhakko','予診票発行情報テーブル(案)', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--予防接種依頼テーブル
INSERT INTO tm_eutable VALUES('tt_yssessyuirai','tt_yssessyuirai','予防接種依頼テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--予防接種依頼サブテーブル
INSERT INTO tm_eutable VALUES('tt_yssessyuirai_sub','tt_yssessyuirai_sub','予防接種依頼サブテーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--予防接種テーブル
INSERT INTO tm_eutable VALUES('tt_yssessyu','tt_yssessyu','予防接種テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--風疹抗体検査テーブル
INSERT INTO tm_eutable VALUES('tt_ysfusinkotai','tt_ysfusinkotai','風疹抗体検査テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--罹患テーブル
INSERT INTO tm_eutable VALUES('tt_ysrikan','tt_ysrikan','罹患テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--予防接種入力チェックマスタ
INSERT INTO tm_eutable VALUES('tm_ysnyuryokucheck','tm_ysnyuryokucheck','予防接種入力チェックマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--予防接種（フリー項目）個人テーブル
INSERT INTO tm_eutable VALUES('tt_yskojinfree','tt_yskojinfree','予防接種（フリー項目）個人テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--予防接種（フリー項目：個人単位）コントロールマスタ
INSERT INTO tm_eutable VALUES('tm_yskojinfreeitem','tm_yskojinfreeitem','予防接種（フリー項目：個人単位）コントロールマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--予防接種（フリー項目）接種テーブル
INSERT INTO tm_eutable VALUES('tt_yssessyufree','tt_yssessyufree','予防接種（フリー項目）接種テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--予防接種（フリー項目：個人接種単位）コントロールマスタ
INSERT INTO tm_eutable VALUES('tm_yssessyufreeitem','tm_yssessyufreeitem','予防接種（フリー項目：個人接種単位）コントロールマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--予防接種依頼（フリー項目）テーブル
INSERT INTO tm_eutable VALUES('tt_yssessyuiraifree','tt_yssessyuiraifree','予防接種依頼（フリー項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--予防接種依頼（フリー項目）コントロールマスタ
INSERT INTO tm_eutable VALUES('tm_yssessyuiraifreeitem','tm_yssessyuiraifreeitem','予防接種依頼（フリー項目）コントロールマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--風しん抗体検査（フリー項目）テーブル
INSERT INTO tm_eutable VALUES('tt_ysfusinkotaifree','tt_ysfusinkotaifree','風しん抗体検査（フリー項目）テーブル', '1', false, 1) ON CONFLICT (tablealias) DO NOTHING;

--風しん抗体検査（フリー項目）コントロールマスタ
INSERT INTO tm_eutable VALUES('tm_ysfusinkotaifreeitem','tm_ysfusinkotaifreeitem','風しん抗体検査（フリー項目）コントロールマスタ', '3', false, 1) ON CONFLICT (tablealias) DO NOTHING;

WITH NumberedRows AS (SELECT tablenm, ROW_NUMBER() OVER (ORDER BY tablekbn,tablenm) AS rn FROM tm_eutable) 
UPDATE tm_eutable u SET orderseq = nr.rn FROM NumberedRows nr WHERE u.tablenm = nr.tablenm;