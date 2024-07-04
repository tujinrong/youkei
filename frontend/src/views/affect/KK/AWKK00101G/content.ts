import {
  DetailRow,
  JuminVM,
  KaigoVM,
  KazeiVM,
  KojoHeaderVM,
  KokiVM,
  KokuhoVM,
  NozeiVM,
  SeihoVM,
  SyogaiVM
} from './type'

/**日本人住民*/
export const row_joho1: DetailRow<JuminVM>[] = [
  {
    th_width: 150,
    cols: [
      { label: '履歴番号', span: 6, field: 'kojinrirekino', md: 12, xl: 6 },
      { label: '枝番号', span: 6, field: 'kojinrireki_edano', md: 12, xl: 6 },
      { label: '更新日時', span: 6, field: 'upddttm', md: 12, xl: 6 },
      { label: '最新', span: 6, field: 'saisinflg', md: 12, xl: 6 }
    ]
  },
  {
    th_width: 150,
    cols: [
      { label: '世帯番号', span: 12, field: 'setaino' },
      { label: '世帯主名', span: 12, field: 'senusinm' },
      { label: '宛名番号', span: 12, field: 'atenano' },
      { label: '個人番号', span: 12, field: 'personalno' },
      { label: '住民種別', span: 12, field: 'juminsyubetunm' },
      { label: '住民状態', span: 12, field: 'juminjotai' },
      { label: 'フリガナ', span: 24, field: 'simei_kana' },
      { label: '氏名', span: 24, field: 'simei' },
      { label: '生年月日', span: 12, field: 'bymd' },
      { label: '生年月日(不詳表記)', span: 12, field: 'bymd_fusyohyoki' },
      { label: '続柄', span: 24, field: 'zokuhyoki' },
      { label: '旧氏力ナ', span: 24, field: 'kyusi_kana' },
      { label: '旧氏漢字', span: 24, field: 'kyusi' },
      { label: '郵便番号', span: 8, field: 'adrs_yubin' },
      { label: '行政区等', span: 16, field: 'tosi_gyoseikunm' },
      { label: 'フリガナ(方書)', span: 24, field: 'adrs_katagaki_kana' },
      { label: '住所', span: 24, field: 'adrs' }
    ],
    tikulist: true
  },
  {
    title: '異動情報',
    th_width: 215,
    cols: [
      { label: '住民となった年月日', span: 12, field: 'juymd' },
      { label: '転入通知年月日', span: 12, field: 'tennyututiymd' },
      { label: '住民となった年月日(不詳表記)', span: 12, field: 'juymd_fusyohyoki' },
      { label: '', span: 1, field: '' },
      { label: '消除の異動年月日', span: 12, field: 'delidoymd' },
      { label: '消除の届出年月日', span: 12, field: 'todokeymd' },
      { label: '消除の異動年月日(不詳表記)', span: 12, field: 'delidoymd_fusyohyoki' },
      { label: '', span: 1, field: '' },
      { label: '異動年月日', span: 12, field: 'idoymd' },
      { label: '異動届出年月日', span: 12, field: 'idotodokeymd' },
      { label: '異動年月日(不詳表記)', span: 12, field: 'idoymd_fusyohyoki' },
      { label: '異動事由', span: 12, field: 'idojiyu' }
    ]
  },
  {
    title: '転入前住所',
    th_width: 150,
    cols: [
      { label: '郵便番号', span: 12, field: 'tennyumaeadrs_yubin' },
      { label: '住所', span: 24, field: 'tennyumaeadrs' },
      { label: '国名等', span: 12, field: 'tennyumaeadrs_kokunm' },
      { label: '国外住所', span: 24, field: 'tennyumaeadrs_gaiadrs' },
      { label: '転入前世帯主氏名', span: 12, field: 'tennyumaeadrs_senusisimei' }
    ]
  },
  {
    title: '転出先住所(予定)',
    th_width: 150,
    cols: [
      { label: '郵便番号', span: 12, field: 'tensyutuyoteiadrs_yubin' },
      { label: '住所', span: 24, field: 'tensyutuyoteiadrs' },
      { label: '国名等', span: 12, field: 'tensyutuyoteiadrs_kokunm' },
      { label: '国外住所', span: 24, field: 'tensyutuyoteiadrs_gaiadrs' }
    ]
  },
  {
    title: '転出先住所(確定)',
    th_width: 150,
    cols: [
      { label: '郵便番号', span: 12, field: 'tensyutukakuteiadrs_yubin' },
      { label: '住所', span: 24, field: 'tensyutukakuteiadrs' }
    ]
  },
  {
    title: '転居前住所',
    th_width: 150,
    cols: [
      { label: '郵便番号', span: 12, field: 'tenkyomaeadrs_yubin' },
      { label: 'フリガナ(方書)', span: 24, field: 'tenkyomaeadrs_katagaki_kana' },
      { label: '住所', span: 24, field: 'tenkyomaeadrs' }
    ]
  }
]
/**外国人住民 */
export const row_joho2: DetailRow<JuminVM>[] = [
  {
    th_width: 150,
    cols: [
      { label: '履歴番号', span: 6, field: 'kojinrirekino', md: 12, xl: 6 },
      { label: '枝番号', span: 6, field: 'kojinrireki_edano', md: 12, xl: 6 },
      { label: '更新日時', span: 6, field: 'upddttm', md: 12, xl: 6 },
      { label: '最新', span: 6, field: 'saisinflg', md: 12, xl: 6 }
    ]
  },
  {
    th_width: 150,
    cols: [
      { label: '世帯番号', span: 12, field: 'setaino' },
      { label: '世帯主名', span: 12, field: 'senusinm' },
      { label: '宛名番号', span: 12, field: 'atenano' },
      { label: '個人番号', span: 12, field: 'personalno' },
      { label: '住民種別', span: 12, field: 'juminsyubetunm' },
      { label: '住民状態', span: 12, field: 'juminjotai' },
      { label: '氏名優先区分', span: 12, field: 'simeiyusenkbn' },
      { label: '国籍名', span: 12, field: 'kokunm' },
      { label: 'フリガナ', span: 24, field: 'simei_kana' },
      { label: '氏名', span: 24, field: 'simei' },
      { label: '氏名（漢字）', span: 24, field: 'simei_gaikanji' },
      { label: '氏名（ローマ字）', span: 24, field: 'simei_gairoma' },
      { label: '通称力ナ', span: 24, field: 'tusyo_kana' },
      { label: '通称漢字', span: 24, field: 'tusyo' },
      { label: '生年月日', span: 12, field: 'bymd' },
      { label: '生年月日(不詳表記)', span: 12, field: 'bymd_fusyohyoki' },
      { label: '続柄', span: 24, field: 'zokuhyoki' },
      { label: '郵便番号', span: 8, field: 'adrs_yubin' },
      { label: '行政区等', span: 16, field: 'tosi_gyoseikunm' },
      { label: 'フリガナ(方書)', span: 24, field: 'adrs_katagaki_kana' },
      { label: '住所', span: 24, field: 'adrs' }
    ],
    tikulist: true
  },
  {
    title: '外国人住民特記事項',
    th_width: 150,
    cols: [
      { label: '第30条45規定区分', span: 12, field: 'kiteikbn' },
      { label: '在留資格等', span: 12, field: 'zairyu' },
      { label: '在留期間', span: 12, field: '' },
      { label: '在留期間の満了の日', span: 12, field: 'zairyumanryoymd' }
    ]
  },
  {
    title: '異動情報',
    th_width: 260,
    cols: [
      { label: '外国人住民となった年月日', span: 12, field: 'gaijuymd' },
      { label: '転入通知年月日', span: 12, field: 'tennyututiymd' },
      { label: '外国人住民となった年月日(不詳表記)', span: 12, field: 'gaijuymd_fusyohyoki' },
      { label: '', span: 12, field: '' },
      { label: '消除の異動年月日', span: 12, field: 'delidoymd' },
      { label: '消除の届出年月日', span: 12, field: 'todokeymd' },
      { label: '消除の異動年月日(不詳表記)', span: 12, field: 'delidoymd_fusyohyoki' },
      { label: '', span: 1, field: '' },
      { label: '異動年月日', span: 12, field: 'idoymd' },
      { label: '異動届出年月日', span: 12, field: 'idotodokeymd' },
      { label: '異動年月日(不詳表記)', span: 12, field: 'idoymd_fusyohyoki' },
      { label: '異動事由', span: 12, field: 'idojiyu' }
    ]
  },
  {
    title: '転入前住所',
    th_width: 150,
    cols: [
      { label: '郵便番号', span: 12, field: 'tennyumaeadrs_yubin' },
      { label: '住所', span: 24, field: 'tennyumaeadrs' },
      { label: '国名等', span: 12, field: 'tennyumaeadrs_kokunm' },
      { label: '国外住所', span: 24, field: 'tennyumaeadrs_gaiadrs' },
      { label: '転入前世帯主氏名', span: 12, field: 'tennyumaeadrs_senusisimei' }
    ]
  },
  {
    title: '転出先住所(予定)',
    th_width: 150,
    cols: [
      { label: '郵便番号', span: 12, field: 'tensyutuyoteiadrs_yubin' },
      { label: '住所', span: 24, field: 'tensyutuyoteiadrs' },
      { label: '国名等', span: 12, field: 'tensyutuyoteiadrs_kokunm' },
      { label: '国外住所', span: 24, field: 'tensyutuyoteiadrs_gaiadrs' }
    ]
  },
  {
    title: '転出先住所(確定)',
    th_width: 150,
    cols: [
      { label: '郵便番号', span: 12, field: 'tensyutukakuteiadrs_yubin' },
      { label: '住所', span: 24, field: 'tensyutukakuteiadrs' }
    ]
  },
  {
    title: '転居前住所',
    th_width: 150,
    cols: [
      { label: '郵便番号', span: 12, field: 'tenkyomaeadrs_yubin' },
      { label: 'フリガナ(方書)', span: 24, field: 'tenkyomaeadrs_katagaki_kana' },
      { label: '住所', span: 24, field: 'tenkyomaeadrs' }
    ]
  }
]

/**課税情報 */
export const row_kazei: DetailRow<KazeiVM>[] = [
  {
    th_width: 150,
    cols: [
      { label: '課税年度', span: 6, field: 'kazeinendo', md: 12, xl: 6 },
      { label: '課税情報履歴番号', span: 6, field: 'kazeirirekino', md: 12, xl: 6 },
      { label: '更新日時', span: 6, field: 'upddttm', md: 12, xl: 6 },
      { label: '最新', span: 6, field: 'saisinflg', md: 12, xl: 6 }
    ]
  },
  {
    th_width: 150,
    cols: [
      { label: '課税非課税', span: 6, field: 'kazeikbn', md: 12, xl: 6 },
      { label: '指定都市_行政区等', span: 6, field: 'tosi_gyoseiku', md: 12, xl: 6 }
    ]
  }
]

/**納税義務者情報 */
export const row_nozei: DetailRow<NozeiVM>[] = [
  {
    th_width: 150,
    cols: [
      { label: '課税年度', span: 6, field: 'kazeinendo', md: 12, xl: 6 },
      { label: '個人履歴番号', span: 6, field: 'kojinrirekino', md: 12, xl: 6 },
      { label: '更新日時', span: 6, field: 'upddttm', md: 12, xl: 6 },
      { label: '最新', span: 6, field: 'saisinflg', md: 12, xl: 6 }
    ]
  },
  {
    th_width: 150,
    cols: [
      { label: '未申告区分', span: 6, field: 'misinkokukbn', md: 12, xl: 6 },
      { label: '他団体課税対象者', span: 6, field: 'takazeikbn', md: 12, xl: 6 },
      { label: '課税先市区', span: 6, field: 'takazeisiku', md: 12, xl: 6 },
      { label: '指定都市_行政区等', span: 6, field: 'tosi_gyoseiku', md: 12, xl: 6 }
    ]
  }
]

/**控除情報 */
export const row_kojo: DetailRow<KojoHeaderVM>[] = [
  {
    th_width: 150,
    cols: [
      { label: '課税年度', span: 6, field: 'kazeinendo', md: 12, xl: 6 },
      { label: '税額控除情報履歴番号', span: 6, field: 'kojorirekino', md: 12, xl: 6 },
      { label: '更新日時', span: 6, field: 'upddttm', md: 12, xl: 6 },
      { label: '最新', span: 6, field: 'saisinflg', md: 12, xl: 6 }
    ]
  }
]

/**国保情報 */
export const row_kokuho: DetailRow<KokuhoVM>[] = [
  {
    th_width: 150,
    cols: [
      { label: '被保険者履歴番号', span: 6, field: 'hihokensyarirekino', md: 12, xl: 6 },
      { label: '更新日時', span: 12, field: 'upddttm' },
      { label: '最新', span: 6, field: 'saisinflg', md: 12, xl: 6 }
    ]
  },
  {
    th_width: 150,
    cols: [
      { label: '市区町村保険者番号', span: 6, field: 'sikutyosonhokenjano', md: 12, xl: 6 },
      { label: '保険者名称', span: 6, field: 'hokenjanm', md: 12, xl: 6 },
      { label: '国保記号番号', span: 6, field: 'kokuho_kigono', md: 12, xl: 6 },
      { label: '枝番', span: 6, field: 'kokuho_edano', md: 12, xl: 6 },
      { label: '国保資格区分', span: 6, field: 'kokuho_sikakukbn', md: 12, xl: 6 },
      { label: '国保資格取得年月日', span: 6, field: 'kokuho_sikakusyutokuymd', md: 12, xl: 6 },
      { label: '国保資格取得事由', span: 6, field: 'kokuho_sikakusyutokujiyu', md: 12, xl: 6 },
      { label: '国保資格喪失年月日', span: 6, field: 'kokuho_sikakusosituymd', md: 12, xl: 6 },
      { label: '国保資格喪失事由', span: 6, field: 'kokuho_sikakusositujiyu', md: 12, xl: 6 },
      { label: '国保適用開始年月日', span: 6, field: 'kokuho_tekiyoymdf', md: 12, xl: 6 },
      { label: '国保適用終了年月日', span: 6, field: 'kokuho_tekiyoymdt', md: 12, xl: 6 },
      { label: '証区分', span: 6, field: 'syokbn', md: 12, xl: 6 },
      { label: '有効期限', span: 6, field: 'yukokigenymd', md: 12, xl: 6 },
      { label: 'マル学マル遠区分', span: 6, field: 'marugakumaruenkbn', md: 12, xl: 6 }
    ]
  }
]

/**後期 */
export const row_koki: DetailRow<KokiVM>[] = [
  {
    th_width: 150,
    cols: [
      { label: '履歴番号', span: 6, field: 'rirekino', md: 12, xl: 6 },
      { label: '更新日時', span: 12, field: 'upddttm' },
      { label: '最新', span: 6, field: 'saisinflg', md: 12, xl: 6 }
    ]
  },
  {
    th_width: 150,
    cols: [
      { label: '被保険者番号', span: 6, field: 'hihokensyano', md: 12, xl: 6 },
      { label: '個人区分', span: 6, field: 'kojinkbnnm', md: 12, xl: 6 },
      { label: '被保険者資格取得事由', span: 6, field: 'hiho_sikakusyutokujiyunm', md: 12, xl: 6 },
      { label: '被保険者資格取得年月日', span: 6, field: 'hiho_sikakusyutokuymd', md: 12, xl: 6 },
      { label: '被保険者資格喪失事由', span: 6, field: 'hiho_sikakusositujiyunm', md: 12, xl: 6 },
      { label: '被保険者資格喪失年月日', span: 6, field: 'hiho_sikakusosituymd', md: 12, xl: 6 },
      { label: '保険者番号適用開始年月日', span: 6, field: 'hoken_tekiyoymdf', md: 12, xl: 6 },
      { label: '保険者番号適用終了年月日', span: 6, field: 'hoken_tekiyoymdt', md: 12, xl: 6 }
    ]
  }
]

/**生保 */
export const row_seiho: DetailRow<SeihoVM>[] = [
  {
    th_width: 150,
    cols: [
      { label: '申請履歴番号', span: 6, field: 'sinseirirekino', md: 12, xl: 6 },
      { label: '決定履歴番号', span: 6, field: 'ketteirirekino', md: 12, xl: 6 },
      { label: '更新日時', span: 6, field: 'upddttm', md: 12, xl: 6 },
      { label: '最新', span: 6, field: 'saisinflg', md: 12, xl: 6 }
    ]
  },
  {
    th_width: 150,
    cols: [
      { label: '福祉事務所', span: 12, field: 'fukusijimusyocd', md: 24, xl: 12 },
      { label: 'ケース番号', span: 6, field: 'caseno', md: 12, xl: 6 },
      { label: '員番号', span: 6, field: 'inno', md: 12, xl: 6 },
      { label: '生活保護開始年月日', span: 6, field: 'seihoymdf', md: 12, xl: 6 },
      { label: '停止年月日', span: 6, field: 'teisiymd', md: 12, xl: 6 },
      { label: '停止解除年月日', span: 6, field: 'teisikaijoymd', md: 12, xl: 6 },
      { label: '単併給区分', span: 6, field: 'tanheikyukbn', md: 12, xl: 6 },
      {
        label: '扶助',
        span: 18,
        field: '',
        list: [
          { label: '生活', field: 'seikatufujoflg' },
          { label: '住宅', field: 'jutakufujoflg' },
          { label: '教育', field: 'kyoikufujoflg' },
          { label: '医療', field: 'iryofujoflg' },
          { label: '出産', field: 'syussanfujoflg' },
          { label: '生業', field: 'seigyofujoflg' },
          { label: '葬祭', field: 'sosaifujoflg' }
        ],
        md: 24,
        xl: 18
      },
      { label: '廃止年月日', span: 6, field: 'haisiymd', md: 12, xl: 6 }
    ]
  }
]

/**介護 */
export const row_kaigo: DetailRow<KaigoVM>[] = [
  {
    th_width: 150,
    cols: [
      { label: '資格履歴番号', span: 6, field: 'sikakurirekino', md: 12, xl: 6 },
      { label: '更新日時', span: 12, field: 'upddttm' },
      { label: '最新', span: 6, field: 'saisinflg', md: 12, xl: 6 }
    ]
  },
  {
    th_width: 150,
    cols: [
      { label: '介護保険者番号', span: 6, field: 'kaigohokensyano', md: 12, xl: 6 },
      { label: '被保険者番号', span: 6, field: 'hihokensyano', md: 12, xl: 6 },
      { label: '被保険者区分', span: 6, field: 'hihokensyakbn', md: 12, xl: 6 },
      { label: '資格取得日', span: 6, field: 'sikakusyutokuymd', md: 12, xl: 6 },
      { label: '資格喪失日', span: 6, field: 'sikakusosituymd', md: 12, xl: 6 },
      { label: '要介護認定状況', span: 6, field: 'yokaigoninteijokyo', md: 12, xl: 6 },
      { label: '要介護状態区分', span: 6, field: 'yokaigojotaikbn', md: 12, xl: 6 },
      { label: '要介護認定日', span: 6, field: 'yokaigoninteiymd', md: 12, xl: 6 },
      { label: '要介護認定有効期間開始日', span: 6, field: 'yokaigoyukoymdf', md: 12, xl: 6 },
      { label: '要介護認定有効期間終了日', span: 6, field: 'yokaigoyukoymdt', md: 12, xl: 6 },
      { label: '公費受給者番号', span: 6, field: 'kohijukyusyano', md: 12, xl: 6 }
    ]
  }
]

/**福祉 */
export const row_syogai: DetailRow<SyogaiVM>[] = [
  {
    th_width: 150,
    cols: [
      { label: '履歴番号', span: 6, field: 'rirekino', md: 12, xl: 6 },
      { label: '更新日時', span: 12, field: 'upddttm' },
      { label: '最新', span: 6, field: 'saisinflg', md: 12, xl: 6 }
    ]
  },
  {
    th_width: 150,
    cols: [
      { label: '資格状態', span: 6, field: 'sikakujotai', md: 12, xl: 6 },
      { label: '手帳番号', span: 6, field: 'tetyono', md: 12, xl: 6 },
      { label: '初回交付日', span: 6, field: 'syokaikofuymd', md: 12, xl: 6 },
      { label: '返還日', span: 6, field: 'henkanymd', md: 12, xl: 6 },
      { label: '統計部位', span: 6, field: 'tokeibui', md: 12, xl: 6 },
      { label: '障害種別', span: 6, field: 'syogaisyubetu', md: 12, xl: 6 },
      { label: '総合等級', span: 12, field: 'sogotokyu', md: 24, xl: 12 },
      { label: '障害名', span: 24, field: 'syogainm' }
    ]
  }
]
