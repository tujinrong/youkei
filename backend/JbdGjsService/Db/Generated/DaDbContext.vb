'*******************************************************************
'業務名称  : 互助防疫システム
'機能概要　: DbContext
'　　　　　　
'作成日　　: 2024.07.17
'作成者　　: AIPlus
'変更履歴:
'*******************************************************************

Namespace JBD.GJS.Db
    Public Class DaDbContext
        Implements IDisposable
        Public Property Session As SessionContext = New SessionContext()

        Public Sub New()
            Call DaGlobal.InitDbLib()
            Session = New SessionContext(DaGlobal.ConnectionString)
            Session.SessionData(DaConst.SessionID) = 0L
            Session.DbContext = Me
        End Sub

        Public Sub New(req As DaRequestBase)
            Call DaGlobal.InitDbLib()
            Session.Connection = New OracleConnection(DaGlobal.ConnectionString)

            Session.UserID = req.USER_ID
            'Session.Unit = req.regsisyo
            Session.SessionData(NameOf(DaRequestBase.ip)) = req.ip
            Session.SessionData(NameOf(DaRequestBase.Service)) = req.Service
            Session.SessionData(NameOf(DaRequestBase.Method)) = req.Method
            Session.SessionData(NameOf(DaRequestBase.ServiceDesc)) = req.ServiceDesc
            Session.SessionData(NameOf(DaRequestBase.MethodDesc)) = req.MethodDesc
            Session.SessionData(NameOf(DaRequestBase.os)) = req.os
            Session.SessionData(NameOf(DaRequestBase.browser)) = req.browser
            Session.SessionData(NameOf(DaRequestBase.sessionid)) = req.sessionid
            Session.DbContext = Me
            If Session.Connection.State = Data.ConnectionState.Closed Then
                Session.Connection.Open()
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Session.Connection?.Close()
            Session.Connection?.Dispose()
            Session.Connection = Nothing
        End Sub

        'public NpgsqlConnection Connection ;
        '=> (NpgsqlConnection)(Session.Connection!);

        ''''<summary>
        ''''コントロールマスタ
        ''''</summary>
        'public tm_afctrlDao tm_afctrl => new tm_afctrlDao(Session);

        ''''<summary>
        ''''コントロールメインマスタ
        ''''</summary>
        'public tm_afctrl_mainDao tm_afctrl_main => new tm_afctrl_mainDao(Session);

        ''''<summary>
        ''''ファイルマスタ
        ''''</summary>
        'public tm_affileDao tm_affile => new tm_affileDao(Session);

        ''''<summary>
        ''''汎用マスタ
        ''''</summary>
        'public tm_afhanyoDao tm_afhanyo => new tm_afhanyoDao(Session);

        ''''<summary>
        ''''汎用メインマスタ
        ''''</summary>
        'public tm_afhanyo_mainDao tm_afhanyo_main => new tm_afhanyo_mainDao(Session);

        ''''<summary>
        ''''ヘルプドキュメントマスタ
        ''''</summary>
        'public tm_afhelpdocDao tm_afhelpdoc => new tm_afhelpdocDao(Session);

        ''''<summary>
        ''''会場情報マスタ
        ''''</summary>
        'public tm_afkaijoDao tm_afkaijo => new tm_afkaijoDao(Session);

        ''''<summary>
        ''''会場情報サブマスタ
        ''''</summary>
        'public tm_afkaijo_subDao tm_afkaijo_sub => new tm_afkaijo_subDao(Session);

        ''''<summary>
        ''''医療機関マスタ
        ''''</summary>
        'public tm_afkikanDao tm_afkikan => new tm_afkikanDao(Session);

        ''''<summary>
        ''''医療機関サブマスタ
        ''''</summary>
        'public tm_afkikan_subDao tm_afkikan_sub => new tm_afkikan_subDao(Session);

        ''''<summary>
        ''''機能マスタ
        ''''</summary>
        'public tm_afkinoDao tm_afkino => new tm_afkinoDao(Session);

        ''''<summary>
        ''''名称マスタ
        ''''</summary>
        'public tm_afmeisyoDao tm_afmeisyo => new tm_afmeisyoDao(Session);

        ''''<summary>
        ''''名称メインマスタ
        ''''</summary>
        'public tm_afmeisyo_mainDao tm_afmeisyo_main => new tm_afmeisyo_mainDao(Session);

        ''''<summary>
        ''''メニューマスタ
        ''''</summary>
        'public tm_afmenuDao tm_afmenu => new tm_afmenuDao(Session);

        ''''<summary>
        ''''メッセージコントロールマスタ
        ''''</summary>
        'public tm_afmsgctrlDao tm_afmsgctrl => new tm_afmsgctrlDao(Session);

        ''''<summary>
        ''''市区町村マスタ
        ''''</summary>
        'public tm_afsikutyosonDao tm_afsikutyoson => new tm_afsikutyosonDao(Session);

        ''''<summary>
        ''''事業従事者（担当者）情報マスタ
        ''''</summary>
        'public tm_afstaffDao tm_afstaff => new tm_afstaffDao(Session);

        ''''<summary>
        ''''事業従事者（担当者）所属機関
        ''''</summary>
        'public tm_afstaff_kikanDao tm_afstaff_kikan => new tm_afstaff_kikanDao(Session);

        ''''<summary>
        ''''事業従事者（担当者）サブマスタ
        ''''</summary>
        'public tm_afstaff_subDao tm_afstaff_sub => new tm_afstaff_subDao(Session);

        ''''<summary>
        ''''所属グループマスタ
        ''''</summary>
        'public tm_afsyozokuDao tm_afsyozoku => new tm_afsyozokuDao(Session);

        ''''<summary>
        ''''地区情報マスタ
        ''''</summary>
        'public tm_aftikuDao tm_aftiku => new tm_aftikuDao(Session);

        ''''<summary>
        ''''地区情報サブマスタ
        ''''</summary>
        'public tm_aftiku_subDao tm_aftiku_sub => new tm_aftiku_subDao(Session);

        ''''<summary>
        ''''町字マスタ
        ''''</summary>
        'public tm_aftyoazaDao tm_aftyoaza => new tm_aftyoazaDao(Session);

        ''''<summary>
        ''''ユーザーマスタ
        ''''</summary>
        'public tm_afuserDao tm_afuser => new tm_afuserDao(Session)
        Public ReadOnly Property tm_afuser As tm_afuserDao
            Get
                Return New tm_afuserDao()
            End Get
        End Property

        ''''<summary>
        ''''宛名テーブル
        ''''</summary>
        'public tt_afatenaDao tt_afatena => new tt_afatenaDao(Session);

        ''''<summary>
        ''''宛名番号検索履歴テーブル
        ''''</summary>
        'public tt_afatenalogDao tt_afatenalog => new tt_afatenalogDao(Session);

        ''''<summary>
        ''''画面権限テーブル
        ''''</summary>
        'public tt_afauthgamenDao tt_afauthgamen => new tt_afauthgamenDao(Session);

        ''''<summary>
        ''''帳票権限テーブル
        ''''</summary>
        'public tt_afauthreportDao tt_afauthreport => new tt_afauthreportDao(Session);

        ''''<summary>
        ''''部署（支所）別更新権限テーブル
        ''''</summary>
        'public tt_afauthsisyoDao tt_afauthsisyo => new tt_afauthsisyoDao(Session);

        ''''<summary>
        ''''バッチログテーブル
        ''''</summary>
        'public tt_afbatchlogDao tt_afbatchlog => new tt_afbatchlogDao(Session);

        ''''<summary>
        ''''共通ドキュメントテーブル
        ''''</summary>
        'public tt_afcomdocDao tt_afcomdoc => new tt_afcomdocDao(Session);

        ''''<summary>
        ''''詳細条件設定テーブル
        ''''</summary>
        'public tt_affilterDao tt_affilter => new tt_affilterDao(Session);

        ''''<summary>
        ''''外部連携処理結果履歴テーブル
        ''''</summary>
        'public tt_afgaibulogDao tt_afgaibulog => new tt_afgaibulogDao(Session);

        ''''<summary>
        ''''お知らせテーブル
        ''''</summary>
        'public tt_afinfoDao tt_afinfo => new tt_afinfoDao(Session);

        ''''<summary>
        ''''お知らせ確認状態テーブル
        ''''</summary>
        'public tt_afinfo_userDao tt_afinfo_user => new tt_afinfo_userDao(Session);

        ''''<summary>
        ''''【住民基本台帳】住民情報テーブル
        ''''</summary>
        'public tt_afjuminDao tt_afjumin => new tt_afjuminDao(Session);

        ''''<summary>
        ''''【住民基本台帳】住民情報履歴テーブル
        ''''</summary>
        'public tt_afjumin_rekiDao tt_afjumin_reki => new tt_afjumin_rekiDao(Session);

        ''''<summary>
        ''''住登外者情報テーブル
        ''''</summary>
        'public tt_afjutogaiDao tt_afjutogai => new tt_afjutogaiDao(Session);

        ''''<summary>
        ''''住登外者独自施策システム等情報テーブル
        ''''</summary>
        'public tt_afjutogai_dokujisystemDao tt_afjutogai_dokujisystem => new tt_afjutogai_dokujisystemDao(Session);

        ''''<summary>
        ''''住登外者参照業務情報テーブル
        ''''</summary>
        'public tt_afjutogai_gyomuDao tt_afjutogai_gyomu => new tt_afjutogai_gyomuDao(Session);

        ''''<summary>
        ''''【介護保険】被保険者情報テーブル
        ''''</summary>
        'public tt_afkaigoDao tt_afkaigo => new tt_afkaigoDao(Session);

        ''''<summary>
        ''''【介護保険】被保険者情報履歴テーブル
        ''''</summary>
        'public tt_afkaigo_rekiDao tt_afkaigo_reki => new tt_afkaigo_rekiDao(Session);

        ''''<summary>
        ''''個人ドキュメントテーブル
        ''''</summary>
        'public tt_afkojindocDao tt_afkojindoc => new tt_afkojindocDao(Session);

        ''''<summary>
        ''''【個人住民税】納税義務者情報テーブル
        ''''</summary>
        'public tt_afkojinzeigimusyaDao tt_afkojinzeigimusya => new tt_afkojinzeigimusyaDao(Session);

        ''''<summary>
        ''''【個人住民税】納税義務者情報履歴テーブル
        ''''</summary>
        'public tt_afkojinzeigimusya_rekiDao tt_afkojinzeigimusya_reki => new tt_afkojinzeigimusya_rekiDao(Session);

        ''''<summary>
        ''''【個人住民税】個人住民税課税情報テーブル
        ''''</summary>
        'public tt_afkojinzeikazeiDao tt_afkojinzeikazei => new tt_afkojinzeikazeiDao(Session);

        ''''<summary>
        ''''【個人住民税】個人住民税課税情報履歴テーブル
        ''''</summary>
        'public tt_afkojinzeikazei_rekiDao tt_afkojinzeikazei_reki => new tt_afkojinzeikazei_rekiDao(Session);

        ''''<summary>
        ''''【個人住民税】個人住民税税額控除情報テーブル
        ''''</summary>
        'public tt_afkojinzeikojoDao tt_afkojinzeikojo => new tt_afkojinzeikojoDao(Session);

        ''''<summary>
        ''''【個人住民税】個人住民税税額控除情報履歴テーブル
        ''''</summary>
        'public tt_afkojinzeikojo_rekiDao tt_afkojinzeikojo_reki => new tt_afkojinzeikojo_rekiDao(Session);

        ''''<summary>
        ''''【後期高齢者医療】被保険者情報テーブル
        ''''</summary>
        'public tt_afkokihokenDao tt_afkokihoken => new tt_afkokihokenDao(Session);

        ''''<summary>
        ''''【後期高齢者医療】被保険者情報履歴テーブル
        ''''</summary>
        'public tt_afkokihoken_rekiDao tt_afkokihoken_reki => new tt_afkokihoken_rekiDao(Session);

        ''''<summary>
        ''''【国民健康保険】国保資格情報テーブル
        ''''</summary>
        'public tt_afkokuhoDao tt_afkokuho => new tt_afkokuhoDao(Session);

        ''''<summary>
        ''''【国民健康保険】国保資格情報履歴テーブル
        ''''</summary>
        'public tt_afkokuho_rekiDao tt_afkokuho_reki => new tt_afkokuho_rekiDao(Session);

        ''''<summary>
        ''''メインログテーブル
        ''''</summary>
        'public tt_aflogDao tt_aflog => new tt_aflogDao(Session);

        ''''<summary>
        ''''宛名番号ログテーブル
        ''''</summary>
        'public tt_aflogatenaDao tt_aflogatena => new tt_aflogatenaDao(Session);

        ''''<summary>
        ''''テーブル項目値変更ログテーブル
        ''''</summary>
        'public tt_aflogcolumnDao tt_aflogcolumn => new tt_aflogcolumnDao(Session);

        ''''<summary>
        ''''DB操作ログテーブル
        ''''</summary>
        'public tt_aflogdbDao tt_aflogdb => new tt_aflogdbDao(Session);

        ''''<summary>
        ''''メモテーブル
        ''''</summary>
        'public tt_afmemoDao tt_afmemo => new tt_afmemoDao(Session);

        ''''<summary>
        ''''メモ情報（世帯）テーブル
        ''''</summary>
        'public tt_afmemosetaiDao tt_afmemosetai => new tt_afmemosetaiDao(Session);

        ''''<summary>
        ''''お気に入りテーブル
        ''''</summary>
        'public tt_afokiniiriDao tt_afokiniiri => new tt_afokiniiriDao(Session);

        ''''<summary>
        ''''個人番号管理テーブル
        ''''</summary>
        'public tt_afpersonalnoDao tt_afpersonalno => new tt_afpersonalnoDao(Session);

        ''''<summary>
        ''''連絡先テーブル
        ''''</summary>
        'public tt_afrenrakusakiDao tt_afrenrakusaki => new tt_afrenrakusakiDao(Session);

        ''''<summary>
        ''''【生活保護】生活保護受給情報テーブル
        ''''</summary>
        'public tt_afseihoDao tt_afseiho => new tt_afseihoDao(Session);

        ''''<summary>
        ''''【生活保護】生活保護受給情報履歴テーブル
        ''''</summary>
        'public tt_afseiho_rekiDao tt_afseiho_reki => new tt_afseiho_rekiDao(Session);

        ''''<summary>
        ''''【住民基本台帳】支援措置対象者情報テーブル
        ''''</summary>
        'public tt_afsiensotitaisyosyaDao tt_afsiensotitaisyosya => new tt_afsiensotitaisyosyaDao(Session);

        ''''<summary>
        ''''【住民基本台帳】支援措置対象者情報履歴テーブル
        ''''</summary>
        'public tt_afsiensotitaisyosya_rekiDao tt_afsiensotitaisyosya_reki => new tt_afsiensotitaisyosya_rekiDao(Session);

        ''''<summary>
        ''''使用履歴テーブル
        ''''</summary>
        'public tt_afsiyorirekiDao tt_afsiyorireki => new tt_afsiyorirekiDao(Session);

        ''''<summary>
        ''''送付先管理テーブル
        ''''</summary>
        'public tt_afsofusakiDao tt_afsofusaki => new tt_afsofusakiDao(Session);

        ''''<summary>
        ''''【障害者福祉】身体障害者手帳等情報テーブル
        ''''</summary>
        'public tt_afsyogaitetyoDao tt_afsyogaitetyo => new tt_afsyogaitetyoDao(Session);

        ''''<summary>
        ''''【障害者福祉】身体障害者手帳等情報履歴テーブル
        ''''</summary>
        'public tt_afsyogaitetyo_rekiDao tt_afsyogaitetyo_reki => new tt_afsyogaitetyo_rekiDao(Session);

        ''''<summary>
        ''''トークンテーブル
        ''''</summary>
        'public tt_aftokenDao tt_aftoken => new tt_aftokenDao(Session);

        ''''<summary>
        ''''通信ログテーブル
        ''''</summary>
        'public tt_aftusinlogDao tt_aftusinlog => new tt_aftusinlogDao(Session);

        ''''<summary>
        ''''ユーザー所属部署（支所）テーブル
        ''''</summary>
        'public tt_afuser_sisyoDao tt_afuser_sisyo => new tt_afuser_sisyoDao(Session);

        ''''<summary>
        ''''タスクスケジュールマスタ
        ''''</summary>
        'public tm_aftaskscheduleDao tm_aftaskschedule => new tm_aftaskscheduleDao(Session);

        ''''<summary>
        ''''基準値マスタ
        ''''</summary>
        'public tm_kkkijunDao tm_kkkijun => new tm_kkkijunDao(Session);

        ''''<summary>
        ''''指導（フリー項目）コントロールマスタ
        ''''</summary>
        'public tm_kksidofreeitemDao tm_kksidofreeitem => new tm_kksidofreeitemDao(Session);

        ''''<summary>
        ''''その他日程事業・保健指導事業マスタ
        ''''</summary>
        'public tm_kksonotasidojigyoDao tm_kksonotasidojigyo => new tm_kksonotasidojigyoDao(Session);

        ''''<summary>
        ''''フォロー結果情報テーブル
        ''''</summary>
        'public tt_kkfollowkekkaDao tt_kkfollowkekka => new tt_kkfollowkekkaDao(Session);

        ''''<summary>
        ''''フォロー内容情報テーブル
        ''''</summary>
        'public tt_kkfollownaiyoDao tt_kkfollownaiyo => new tt_kkfollownaiyoDao(Session);

        ''''<summary>
        ''''フォロー予定情報テーブル
        ''''</summary>
        'public tt_kkfollowyoteiDao tt_kkfollowyotei => new tt_kkfollowyoteiDao(Session);

        ''''<summary>
        ''''保健指導事業（フリー項目）入力情報テーブル
        ''''</summary>
        'public tt_kkhokensidofreeDao tt_kkhokensidofree => new tt_kkhokensidofreeDao(Session);

        ''''<summary>
        ''''保健指導結果情報（固定項目）テーブル
        ''''</summary>
        'public tt_kkhokensido_kekkaDao tt_kkhokensido_kekka => new tt_kkhokensido_kekkaDao(Session);

        ''''<summary>
        ''''保健指導申込情報（固定項目）テーブル
        ''''</summary>
        'public tt_kkhokensido_mosikomiDao tt_kkhokensido_mosikomi => new tt_kkhokensido_mosikomiDao(Session);

        ''''<summary>
        ''''保健指導担当者テーブル
        ''''</summary>
        'public tt_kkhokensido_staffDao tt_kkhokensido_staff => new tt_kkhokensido_staffDao(Session);

        ''''<summary>
        ''''実施報告書（日報）情報テーブル
        ''''</summary>
        'public tt_kkjissihokokusyoDao tt_kkjissihokokusyo => new tt_kkjissihokokusyoDao(Session);

        ''''<summary>
        ''''実施報告書（日報）情報サブテーブル
        ''''</summary>
        'public tt_kkjissihokokusyo_subDao tt_kkjissihokokusyo_sub => new tt_kkjissihokokusyo_subDao(Session);

        ''''<summary>
        ''''帳票発行対象外者テーブル
        ''''</summary>
        'public tt_kkrpthakkotaisyogaisyaDao tt_kkrpthakkotaisyogaisya => new tt_kkrpthakkotaisyogaisyaDao(Session);

        ''''<summary>
        ''''集団指導事業（フリー項目）入力情報テーブル
        ''''</summary>
        'public tt_kksyudansidofreeDao tt_kksyudansidofree => new tt_kksyudansidofreeDao(Session);

        ''''<summary>
        ''''集団指導結果情報（固定項目）テーブル
        ''''</summary>
        'public tt_kksyudansido_kekkaDao tt_kksyudansido_kekka => new tt_kksyudansido_kekkaDao(Session);

        ''''<summary>
        ''''集団指導申込情報（固定項目）テーブル
        ''''</summary>
        'public tt_kksyudansido_mosikomiDao tt_kksyudansido_mosikomi => new tt_kksyudansido_mosikomiDao(Session);

        ''''<summary>
        ''''集団指導参加者テーブル
        ''''</summary>
        'public tt_kksyudansido_sankasyaDao tt_kksyudansido_sankasya => new tt_kksyudansido_sankasyaDao(Session);

        ''''<summary>
        ''''集団指導参加者（フリー項目）入力情報テーブル
        ''''</summary>
        'public tt_kksyudansido_sankasyafreeDao tt_kksyudansido_sankasyafree => new tt_kksyudansido_sankasyafreeDao(Session);

        ''''<summary>
        ''''集団指導参加者結果情報（固定項目）テーブル
        ''''</summary>
        'public tt_kksyudansido_sankasyakekkaDao tt_kksyudansido_sankasyakekka => new tt_kksyudansido_sankasyakekkaDao(Session);

        ''''<summary>
        ''''集団指導参加者申込情報（固定項目）テーブル
        ''''</summary>
        'public tt_kksyudansido_sankasyamosikomiDao tt_kksyudansido_sankasyamosikomi => new tt_kksyudansido_sankasyamosikomiDao(Session);

        ''''<summary>
        ''''集団指導担当者テーブル
        ''''</summary>
        'public tt_kksyudansido_staffDao tt_kksyudansido_staff => new tt_kksyudansido_staffDao(Session);

        ''''<summary>
        ''''一括取込入力マスタ
        ''''</summary>
        'public tm_kktorinyuryokuDao tm_kktorinyuryoku => new tm_kktorinyuryokuDao(Session);

        ''''<summary>
        ''''取込基本情報マスタ
        ''''</summary>
        'public tm_kktori_kihonDao tm_kktori_kihon => new tm_kktori_kihonDao(Session);

        ''''<summary>
        ''''一括取込入力対象テーブルマスタ
        ''''</summary>
        'public tm_kktorinyuryoku_taisyotableDao tm_kktorinyuryoku_taisyotable => new tm_kktorinyuryoku_taisyotableDao(Session);

        ''''<summary>
        ''''取込IFマスタ
        ''''</summary>
        'public tm_kktori_interfaceDao tm_kktori_interface => new tm_kktori_interfaceDao(Session);

        ''''<summary>
        ''''一括取込入力項目定義マスタ
        ''''</summary>
        'public tm_kktorinyuryoku_itemDao tm_kktorinyuryoku_item => new tm_kktorinyuryoku_itemDao(Session);

        ''''<summary>
        ''''一括取込入力変換コードメインマスタ
        ''''</summary>
        'public tm_kktorinyuryoku_henkancode_mainDao tm_kktorinyuryoku_henkancode_main => new tm_kktorinyuryoku_henkancode_mainDao(Session);

        ''''<summary>
        ''''取込変換コードマスタ
        ''''</summary>
        'public tm_kktori_henkancodeDao tm_kktori_henkancode => new tm_kktori_henkancodeDao(Session);

        ''''<summary>
        ''''取込項目マッピングマスタ
        ''''</summary>
        'public tm_kktori_mappingDao tm_kktori_mapping => new tm_kktori_mappingDao(Session);

        ''''<summary>
        ''''一括取込入力登録マスタ
        ''''</summary>
        'public tm_kktorinyuryoku_torokuDao tm_kktorinyuryoku_toroku => new tm_kktorinyuryoku_torokuDao(Session);

        ''''<summary>
        ''''一括取込入力テーブルマスタ
        ''''</summary>
        'public tm_kktorinyuryoku_tableDao tm_kktorinyuryoku_table => new tm_kktorinyuryoku_tableDao(Session);

        ''''<summary>
        ''''一括取込入力プロシージャマスタ
        ''''</summary>
        'public tm_kktorinyuryoku_procDao tm_kktorinyuryoku_proc => new tm_kktorinyuryoku_procDao(Session);

        ''''<summary>
        ''''一括取込入力未処理テーブル
        ''''</summary>
        'public tt_kktorinyuryoku_misyoriDao tt_kktorinyuryoku_misyori => new tt_kktorinyuryoku_misyoriDao(Session);

        ''''<summary>
        ''''一括取込入力未処理項目テーブル
        ''''</summary>
        'public tt_kktorinyuryoku_misyoriitemDao tt_kktorinyuryoku_misyoriitem => new tt_kktorinyuryoku_misyoriitemDao(Session);

        ''''<summary>
        ''''一括取込入力エラーテーブル
        ''''</summary>
        'public tt_kktorinyuryoku_errDao tt_kktorinyuryoku_err => new tt_kktorinyuryoku_errDao(Session);

        ''''<summary>
        ''''一括取込入力履歴テーブル
        ''''</summary>
        'public tt_kktorinyuryoku_rirekiDao tt_kktorinyuryoku_rireki => new tt_kktorinyuryoku_rirekiDao(Session);

        ''''<summary>
        ''''事業予定テーブル
        ''''</summary>
        'public tt_kkjigyoyoteiDao tt_kkjigyoyotei => new tt_kkjigyoyoteiDao(Session);

        ''''<summary>
        ''''事業予定コーステーブル
        ''''</summary>
        'public tt_kkjigyoyoteicourseDao tt_kkjigyoyoteicourse => new tt_kkjigyoyoteicourseDao(Session);

        ''''<summary>
        ''''事業予定担当者テーブル
        ''''</summary>
        'public tt_kkjigyoyotei_staffDao tt_kkjigyoyotei_staff => new tt_kkjigyoyotei_staffDao(Session);

        ''''<summary>
        ''''事業予約希望者テーブル
        ''''</summary>
        'public tt_kkjigyoyoyakukibosyaDao tt_kkjigyoyoyakukibosya => new tt_kkjigyoyoyakukibosyaDao(Session);

        ''''<summary>
        ''''抽出情報マスタ
        ''''</summary>
        'public tm_kktyusyutuDao tm_kktyusyutu => new tm_kktyusyutuDao(Session);

        ''''<summary>
        ''''対象者抽出情報テーブル
        ''''</summary>
        'public tt_kktaisyosya_tyusyutuDao tt_kktaisyosya_tyusyutu => new tt_kktaisyosya_tyusyutuDao(Session);

        ''''<summary>
        ''''対象者抽出情報項目テーブル
        ''''</summary>
        'public tt_kktaisyosya_tyusyutufreeDao tt_kktaisyosya_tyusyutufree => new tt_kktaisyosya_tyusyutufreeDao(Session);

        ''''<summary>
        ''''対象者抽出情報サブテーブル
        ''''</summary>
        'public tt_kktaisyosya_tyusyutu_subDao tt_kktaisyosya_tyusyutu_sub => new tt_kktaisyosya_tyusyutu_subDao(Session);

        ''''<summary>
        ''''対象者抽出情報サブ項目テーブル
        ''''</summary>
        'public tt_kktaisyosya_tyusyutu_subfreeDao tt_kktaisyosya_tyusyutu_subfree => new tt_kktaisyosya_tyusyutu_subfreeDao(Session);

        ''''<summary>
        ''''発券情報テーブル
        ''''</summary>
        'public tt_kkhakkenDao tt_kkhakken => new tt_kkhakkenDao(Session);

        ''''<summary>
        ''''対象者抽出情報項目コントロールマスタ
        ''''</summary>
        'public tm_kktaisyosya_tyusyutufreeitemDao tm_kktaisyosya_tyusyutufreeitem => new tm_kktaisyosya_tyusyutufreeitemDao(Session);

        ''''<summary>
        ''''帳票発行履歴テーブル
        ''''</summary>
        'public tt_kkrpthakkorirekiDao tt_kkrpthakkorireki => new tt_kkrpthakkorirekiDao(Session);

        ''''<summary>
        ''''帳票発行履歴サブテーブル
        ''''</summary>
        'public tt_kkrpthakkorireki_subDao tt_kkrpthakkorireki_sub => new tt_kkrpthakkorireki_subDao(Session);

        ''''<summary>
        ''''成人保健検診結果（フリー）項目コントロールマスタ
        ''''</summary>
        'public tm_shfreeitemDao tm_shfreeitem => new tm_shfreeitemDao(Session);

        ''''<summary>
        ''''成人健（検）診事業マスタ
        ''''</summary>
        'public tm_shkensinjigyoDao tm_shkensinjigyo => new tm_shkensinjigyoDao(Session);

        ''''<summary>
        ''''年度マスタ
        ''''</summary>
        'public tm_shnendoDao tm_shnendo => new tm_shnendoDao(Session);

        ''''<summary>
        ''''成人保健検診結果（フリー項目）テーブル
        ''''</summary>
        'public tt_shfreeDao tt_shfree => new tt_shfreeDao(Session);

        ''''<summary>
        ''''受診拒否理由テーブル
        ''''</summary>
        'public tt_shjyusinkyohiriyuDao tt_shjyusinkyohiriyu => new tt_shjyusinkyohiriyuDao(Session);

        ''''<summary>
        ''''成人保健一次検診結果（固定項目）テーブル
        ''''</summary>
        'public tt_shkensinDao tt_shkensin => new tt_shkensinDao(Session);

        ''''<summary>
        ''''成人保健精密検査結果（固定項目）テーブル
        ''''</summary>
        'public tt_shseikenDao tt_shseiken => new tt_shseikenDao(Session);

        ''''<summary>
        ''''健（検）診予定テーブル
        ''''</summary>
        'public tt_shkensinyoteiDao tt_shkensinyotei => new tt_shkensinyoteiDao(Session);

        ''''<summary>
        ''''健（検）診予定詳細テーブル
        ''''</summary>
        'public tt_shkensinyoteisyosaiDao tt_shkensinyoteisyosai => new tt_shkensinyoteisyosaiDao(Session);

        ''''<summary>
        ''''健（検）診予定担当者テーブル
        ''''</summary>
        'public tt_shkensinyotei_staffDao tt_shkensinyotei_staff => new tt_shkensinyotei_staffDao(Session);

        ''''<summary>
        ''''健（検）診予約希望者テーブル
        ''''</summary>
        'public tt_shkensinyoyakukibosyaDao tt_shkensinyoyakukibosya => new tt_shkensinyoyakukibosyaDao(Session);

        ''''<summary>
        ''''健（検）診予約希望者詳細テーブル
        ''''</summary>
        'public tt_shkensinkibosyasyosaiDao tt_shkensinkibosyasyosai => new tt_shkensinkibosyasyosaiDao(Session);

        ''''<summary>
        ''''自己負担金マスタ
        ''''</summary>
        'public tm_shjikofutankinDao tm_shjikofutankin => new tm_shjikofutankinDao(Session);

        ''''<summary>
        ''''成人健（検）診予約日程事業マスタ
        ''''</summary>
        'public tm_shyoyakujigyoDao tm_shyoyakujigyo => new tm_shyoyakujigyoDao(Session);

        ''''<summary>
        ''''成人健（検）診予約日程事業サブマスタ
        ''''</summary>
        'public tm_shyoyakujigyo_subDao tm_shyoyakujigyo_sub => new tm_shyoyakujigyo_subDao(Session);

        ''''<summary>
        ''''母子保健詳細メニューマスタ
        ''''</summary>
        'public tm_bhkksyosaimenyuDao tm_bhkksyosaimenyu => new tm_bhkksyosaimenyuDao(Session);

        ''''<summary>
        ''''母子保健詳細タブマスタ
        ''''</summary>
        'public tm_bhkksyosaitabDao tm_bhkksyosaitab => new tm_bhkksyosaitabDao(Session);

        ''''<summary>
        ''''母子保健事業マスタ
        ''''</summary>
        'public tm_bhkkjigyoDao tm_bhkkjigyo => new tm_bhkkjigyoDao(Session);

        ''''<summary>
        ''''母子保健（フリー）項目コントロールマスタ
        ''''</summary>
        'public tm_bhkkfreeitemDao tm_bhkkfreeitem => new tm_bhkkfreeitemDao(Session);

        ''''<summary>
        ''''乳幼児パーセンタイル値マスタ
        ''''</summary>
        'public tm_bhnyhpasentairuDao tm_bhnyhpasentairu => new tm_bhnyhpasentairuDao(Session);

        ''''<summary>
        ''''乳幼児（フリー）項目テーブル
        ''''</summary>
        'public tt_bhnyfreeDao tt_bhnyfree => new tt_bhnyfreeDao(Session);

        ''''<summary>
        ''''妊産婦（フリー）項目テーブル
        ''''</summary>
        'public tt_bhnsfreeDao tt_bhnsfree => new tt_bhnsfreeDao(Session);

        ''''<summary>
        ''''出生時状況（固定項目）テーブル
        ''''</summary>
        'public tt_bhnysyussyojijokyoDao tt_bhnysyussyojijokyo => new tt_bhnysyussyojijokyoDao(Session);

        ''''<summary>
        ''''新生児聴覚検査結果（固定項目）テーブル
        ''''</summary>
        'public tt_bhnytyokakukensakekkaDao tt_bhnytyokakukensakekka => new tt_bhnytyokakukensakekkaDao(Session);

        ''''<summary>
        ''''新生児聴覚スクリーニング検査費用助成（固定項目）テーブル
        ''''</summary>
        'public tt_bhnytyokakukensahiyojoseiDao tt_bhnytyokakukensahiyojosei => new tt_bhnytyokakukensahiyojoseiDao(Session);

        ''''<summary>
        ''''乳幼児健診結果（固定項目）テーブル
        ''''</summary>
        'public tt_bhnykensinkekkaDao tt_bhnykensinkekka => new tt_bhnykensinkekkaDao(Session);

        ''''<summary>
        ''''乳幼児健診アンケート（固定項目）テーブル
        ''''</summary>
        'public tt_bhnykensinanketoDao tt_bhnykensinanketo => new tt_bhnykensinanketoDao(Session);

        ''''<summary>
        ''''乳幼児歯科健診結果（固定項目）テーブル
        ''''</summary>
        'public tt_bhnysikakensinkekkaDao tt_bhnysikakensinkekka => new tt_bhnysikakensinkekkaDao(Session);

        ''''<summary>
        ''''独自施策（子）（固定項目）テーブル
        ''''</summary>
        'public tt_bhnydokujisesakuDao tt_bhnydokujisesaku => new tt_bhnydokujisesakuDao(Session);

        ''''<summary>
        ''''乳幼児精密健診結果（固定項目）テーブル
        ''''</summary>
        'public tt_bhnyseikenkekkaDao tt_bhnyseikenkekka => new tt_bhnyseikenkekkaDao(Session);

        ''''<summary>
        ''''健診受診履歴（固定項目）テーブル
        ''''</summary>
        'public tt_bhnykensinjusinrekiDao tt_bhnykensinjusinreki => new tt_bhnykensinjusinrekiDao(Session);

        ''''<summary>
        ''''未受診者勧奨（固定項目）テーブル
        ''''</summary>
        'public tt_bhnymijusinsyakansyoDao tt_bhnymijusinsyakansyo => new tt_bhnymijusinsyakansyoDao(Session);

        ''''<summary>
        ''''精密健診の依頼（固定項目）テーブル
        ''''</summary>
        'public tt_bhnyseikeniraiDao tt_bhnyseikenirai => new tt_bhnyseikeniraiDao(Session);

        ''''<summary>
        ''''妊娠届出（固定）テーブル
        ''''</summary>
        'public tt_bhnsninsintodokedeDao tt_bhnsninsintodokede => new tt_bhnsninsintodokedeDao(Session);

        ''''<summary>
        ''''妊娠届出アンケート（固定）テーブル
        ''''</summary>
        'public tt_bhnsninsintodokedeanketoDao tt_bhnsninsintodokedeanketo => new tt_bhnsninsintodokedeanketoDao(Session);

        ''''<summary>
        ''''母子健康手帳交付（固定）テーブル
        ''''</summary>
        'public tt_bhnsbosikenkotetyokofuDao tt_bhnsbosikenkotetyokofu => new tt_bhnsbosikenkotetyokofuDao(Session);

        ''''<summary>
        ''''出産の状態に係る（固定）テーブル
        ''''</summary>
        'public tt_bhnssyussanjotaiDao tt_bhnssyussanjotai => new tt_bhnssyussanjotaiDao(Session);

        ''''<summary>
        ''''妊婦健診結果（固定）テーブル
        ''''</summary>
        'public tt_bhnsninpukensinkekkaDao tt_bhnsninpukensinkekka => new tt_bhnsninpukensinkekkaDao(Session);

        ''''<summary>
        ''''妊婦健診費用助成（固定）テーブル
        ''''</summary>
        'public tt_bhnsninpukensinhiyojoseiDao tt_bhnsninpukensinhiyojosei => new tt_bhnsninpukensinhiyojoseiDao(Session);

        ''''<summary>
        ''''妊婦健診費用助成（固定）サブテーブル
        ''''</summary>
        'public tt_bhnsninpukensinhiyojosei_subDao tt_bhnsninpukensinhiyojosei_sub => new tt_bhnsninpukensinhiyojosei_subDao(Session);

        ''''<summary>
        ''''妊産婦歯科健診結果（固定）テーブル
        ''''</summary>
        'public tt_bhnssikakensinkekkaDao tt_bhnssikakensinkekka => new tt_bhnssikakensinkekkaDao(Session);

        ''''<summary>
        ''''妊産婦歯科精健結果（固定）テーブル
        ''''</summary>
        'public tt_bhnssikaseikenkekkaDao tt_bhnssikaseikenkekka => new tt_bhnssikaseikenkekkaDao(Session);

        ''''<summary>
        ''''妊婦精健結果（固定）テーブル
        ''''</summary>
        'public tt_bhnsninpuseikenkekkaDao tt_bhnsninpuseikenkekka => new tt_bhnsninpuseikenkekkaDao(Session);

        ''''<summary>
        ''''産婦健診結果（固定）テーブル
        ''''</summary>
        'public tt_bhnssanpukensinkekkaDao tt_bhnssanpukensinkekka => new tt_bhnssanpukensinkekkaDao(Session);

        ''''<summary>
        ''''産婦健診費用助成（固定）テーブル
        ''''</summary>
        'public tt_bhnssanpukensinhiyojoseiDao tt_bhnssanpukensinhiyojosei => new tt_bhnssanpukensinhiyojoseiDao(Session);

        ''''<summary>
        ''''産婦健診費用助成（固定）サブテーブル
        ''''</summary>
        'public tt_bhnssanpukensinhiyojosei_subDao tt_bhnssanpukensinhiyojosei_sub => new tt_bhnssanpukensinhiyojosei_subDao(Session);

        ''''<summary>
        ''''産婦精密健診結果（固定）テーブル
        ''''</summary>
        'public tt_bhnssanpuseikenkekkaDao tt_bhnssanpuseikenkekka => new tt_bhnssanpuseikenkekkaDao(Session);

        ''''<summary>
        ''''産後ケア事業（固定）テーブル
        ''''</summary>
        'public tt_bhnssangocarejigyoDao tt_bhnssangocarejigyo => new tt_bhnssangocarejigyoDao(Session);

        ''''<summary>
        ''''独自施策（母）（固定）テーブル
        ''''</summary>
        'public tt_bhnsdokujisesakuDao tt_bhnsdokujisesaku => new tt_bhnsdokujisesakuDao(Session);

        ''''<summary>
        ''''母子保健管理パターンマスタ
        ''''</summary>
        'public tm_bhkanripatternDao tm_bhkanripattern => new tm_bhkanripatternDao(Session);

        ''''<summary>
        ''''母子保健健診対象者テーブル
        ''''</summary>
        'public tm_bhkensinDao tm_bhkensin => new tm_bhkensinDao(Session);

        ''''<summary>
        ''''ワクチンマスタ
        ''''</summary>
        'public tm_ysvaccineDao tm_ysvaccine => new tm_ysvaccineDao(Session);

        ''''<summary>
        ''''予防接種依頼テーブル
        ''''</summary>
        'public tt_yssessyuiraiDao tt_yssessyuirai => new tt_yssessyuiraiDao(Session);

        ''''<summary>
        ''''予防接種依頼サブテーブル
        ''''</summary>
        'public tt_yssessyuirai_subDao tt_yssessyuirai_sub => new tt_yssessyuirai_subDao(Session);

        ''''<summary>
        ''''予防接種テーブル
        ''''</summary>
        'public tt_yssessyuDao tt_yssessyu => new tt_yssessyuDao(Session);

        ''''<summary>
        ''''風疹抗体検査テーブル
        ''''</summary>
        'public tt_ysfusinkotaiDao tt_ysfusinkotai => new tt_ysfusinkotaiDao(Session);

        ''''<summary>
        ''''罹患テーブル
        ''''</summary>
        'public tt_ysrikanDao tt_ysrikan => new tt_ysrikanDao(Session);

        ''''<summary>
        ''''罹患テーブル
        ''''</summary>
        'public tm_ysfreeitemDao tm_ysfreeitem => new tm_ysfreeitemDao(Session);

        ''''<summary>
        ''''予防接種入力チェックマスタ
        ''''</summary>
        'public tm_ysnyuryokucheckDao tm_ysnyuryokucheck => new tm_ysnyuryokucheckDao(Session);

        ''''<summary>
        ''''予防接種（フリー項目）個人テーブル
        ''''</summary>
        'public tt_yskojinfreeDao tt_yskojinfree => new tt_yskojinfreeDao(Session);

        ''''<summary>
        ''''予防接種（フリー項目）接種テーブル
        ''''</summary>
        'public tt_yssessyufreeDao tt_yssessyufree => new tt_yssessyufreeDao(Session);

        ''''<summary>
        ''''予防接種依頼（フリー項目）テーブル
        ''''</summary>
        'public tt_yssessyuiraifreeDao tt_yssessyuiraifree => new tt_yssessyuiraifreeDao(Session);

        ''''<summary>
        ''''風しん抗体検査（フリー項目）テーブル
        ''''</summary>
        'public tt_ysfusinkotaifreeDao tt_ysfusinkotaifree => new tt_ysfusinkotaifreeDao(Session);

        ''''<summary>
        ''''EUCテーブルマスタ
        ''''</summary>
        'public tm_eutableDao tm_eutable => new tm_eutableDao(Session);

        ''''<summary>
        ''''EUCテーブル項目マスタ
        ''''</summary>
        'public tm_eutableitemDao tm_eutableitem => new tm_eutableitemDao(Session);

        ''''<summary>
        ''''EUCテーブル項目名称マスタ
        ''''</summary>
        'public tm_eutableitemnameDao tm_eutableitemname => new tm_eutableitemnameDao(Session);

        ''''<summary>
        ''''EUCテーブル結合マスタ
        ''''</summary>
        'public tm_eutablejoinDao tm_eutablejoin => new tm_eutablejoinDao(Session);

        ''''<summary>
        ''''EUCデータソースマスタ
        ''''</summary>
        'public tm_eudatasourceDao tm_eudatasource => new tm_eudatasourceDao(Session);

        ''''<summary>
        ''''EUCデータソース結合マスタ
        ''''</summary>
        'public tm_eudatasourcejoinDao tm_eudatasourcejoin => new tm_eudatasourcejoinDao(Session);

        ''''<summary>
        ''''EUCデータソース項目マスタ
        ''''</summary>
        'public tm_eudatasourceitemDao tm_eudatasourceitem => new tm_eudatasourceitemDao(Session);

        ''''<summary>
        ''''EUCデータソース検索マスタ
        ''''</summary>
        'public tm_eudatasourcekensakuDao tm_eudatasourcekensaku => new tm_eudatasourcekensakuDao(Session);

        ''''<summary>
        ''''EUC帳票マスタ
        ''''</summary>
        'public tm_eurptDao tm_eurpt => new tm_eurptDao(Session);

        ''''<summary>
        ''''EUC様式マスタ
        ''''</summary>
        'public tm_euyosikiDao tm_euyosiki => new tm_euyosikiDao(Session);

        ''''<summary>
        ''''EUC様式詳細マスタ
        ''''</summary>
        'public tm_euyosikisyosaiDao tm_euyosikisyosai => new tm_euyosikisyosaiDao(Session);

        ''''<summary>
        ''''EUC帳票項目マスタ
        ''''</summary>
        'public tm_eurptitemDao tm_eurptitem => new tm_eurptitemDao(Session);

        ''''<summary>
        ''''EUC帳票検索マスタ
        ''''</summary>
        'public tm_eurptkensakuDao tm_eurptkensaku => new tm_eurptkensakuDao(Session);

        ''''<summary>
        ''''EUC帳票検索詳細マスタ
        ''''</summary>
        'public tm_eurptkensakusyosaiDao tm_eurptkensakusyosai => new tm_eurptkensakusyosaiDao(Session);

        ''''<summary>
        ''''EUC帳票出力履歴テーブル
        ''''</summary>
        'public tt_eurirekiDao tt_eurireki => new tt_eurirekiDao(Session);

        ''''<summary>
        ''''EUC帳票出力履歴条件テーブル
        ''''</summary>
        'public tt_eurirekijyokenDao tt_eurirekijyoken => new tt_eurirekijyokenDao(Session);

        ''''<summary>
        ''''帳票グループマスタ
        ''''</summary>
        'public tm_eurptgroupDao tm_eurptgroup => new tm_eurptgroupDao(Session);

        ''''<summary>
        ''''帳票テンプレートファイルマスタ
        ''''</summary>
        'public tm_eutemplatefileDao tm_eutemplatefile => new tm_eutemplatefileDao(Session);

        ''''<summary>
        ''''公印マスタ
        ''''</summary>
        'public tm_eukoinDao tm_eukoin => new tm_eukoinDao(Session);

        ''''<summary>
        ''''出力順パターンテーブル
        ''''</summary>
        'public tt_eusortDao tt_eusort => new tt_eusortDao(Session);

        ''''<summary>
        ''''出力順パターンサブテーブル
        ''''</summary>
        'public tt_eusort_subDao tt_eusort_sub => new tt_eusort_subDao(Session);

        ''''<summary>
        ''''CSV出力パターンテーブル
        ''''</summary>
        'public tt_eucsvDao tt_eucsv => new tt_eucsvDao(Session);

        ''''<summary>
        ''''CSV出力パターンサブテーブル
        ''''</summary>
        'public tt_eucsv_subDao tt_eucsv_sub => new tt_eucsv_subDao(Session);

        ''''<summary>
        ''''宛名ワークテーブル
        ''''</summary>
        'public wk_euatenaDao wk_euatena => new wk_euatenaDao(Session);

        ''''<summary>
        ''''宛名ワークテーブルサブ
        ''''</summary>
        'public wk_euatena_subDao wk_euatena_sub => new wk_euatena_subDao(Session);

        ''''<summary>
        ''''妊産婦ワークテーブル
        ''''</summary>
        'public wk_euninsanpu_subDao wk_euninsanpu_sub => new wk_euninsanpu_subDao(Session);
    End Class
End Namespace
