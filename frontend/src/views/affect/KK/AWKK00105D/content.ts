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
    title: '税額控除情報履歴番号',
    field: 'kojorirekino',
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
