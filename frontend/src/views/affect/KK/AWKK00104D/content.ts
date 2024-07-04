import { RowVM } from './type'

interface ColVM {
  title: string
  field: keyof RowVM
  width: string
  formatter?: string
}

export const columns: ColVM[] = [
  {
    title: '課税年度',
    field: 'kazeinendo',
    width: '',
    formatter: 'jpYear'
  },
  {
    title: '個人履歴番号',
    field: 'kojinrirekino',
    width: ''
  },
  {
    title: '未申告区分',
    field: 'misinkokukbn',
    width: ''
  },
  {
    title: '他団体課税対象者区分',
    field: 'takazeikbn',
    width: '180'
  },
  {
    title: '課税先市区町村',
    field: 'takazeisikunm',
    width: ''
  },
  {
    title: '指定都市_行政区等',
    field: 'tosi_gyoseikunm',
    width: ''
  },
  {
    title: '更新日時',
    field: 'upddttm',
    width: ''
  },
  {
    title: '最新',
    field: 'saisinflg',
    width: '60'
  }
]
