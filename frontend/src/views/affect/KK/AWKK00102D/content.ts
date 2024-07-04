import { RowVM } from './type'

interface ColVM {
  title: string
  field: keyof RowVM
  width: string
}

export const columns: ColVM[] = [
  {
    title: '個人履歴番号',
    field: 'kojinrirekino',
    width: ''
  },
  {
    title: '個人履歴番号_枝番号',
    field: 'kojinrireki_edano',
    width: '180'
  },
  {
    title: '氏名',
    field: 'name',
    width: ''
  },
  {
    title: '住民状態',
    field: 'juminjotai',
    width: ''
  },
  {
    title: '異動年月日',
    field: 'idoymd',
    width: '160'
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
    field: 'saisinflg',
    width: '60'
  }
]
