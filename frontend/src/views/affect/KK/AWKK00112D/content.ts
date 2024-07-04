import { RowVM } from './type'

interface ColVM {
  title: string
  field: keyof RowVM
  width: string
  formatter?: string
}

export const columns: ColVM[] = [
  {
    title: '履歴番号',
    field: 'rirekino',
    width: ''
  },
  {
    title: '氏名',
    field: 'name',
    width: ''
  },
  {
    title: '住民区分',
    field: 'juminjotai',
    width: ''
  },
  {
    title: '異動年月日',
    field: 'idoymd',
    width: '160',
    formatter: 'jpUnknownDate'
  },
  {
    title: '異動事由',
    field: 'idojiyu',
    width: ''
  },
  {
    title: '住所',
    field: 'adrs',
    width: ''
  },
  {
    title: '更新日時',
    field: 'upddttm',
    width: '220'
  },
  {
    title: '最新',
    field: 'saisin',
    width: '60'
  }
]
