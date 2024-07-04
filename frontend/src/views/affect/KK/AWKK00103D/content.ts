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
    title: '課税情報履歴番号',
    field: 'kazeirirekino',
    width: ''
  },
  {
    title: '課税非課税区分',
    field: 'kazeikbn',
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
