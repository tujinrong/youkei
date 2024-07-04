import { RowVM } from './type'

interface ColVM {
  title: string
  field: keyof RowVM
  width: string
}

export const columns: ColVM[] = [
  {
    title: '履歴番号',
    field: 'rirekino',
    width: ''
  },
  {
    title: '手帳番号',
    field: 'tetyono',
    width: ''
  },
  {
    title: '返還日',
    field: 'henkanymd',
    width: ''
  },
  {
    title: '初回交付日',
    field: 'syokaikofuymd',
    width: ''
  },
  {
    title: '障害種別',
    field: 'syogaisyubetunm',
    width: ''
  },
  {
    title: '総合等級',
    field: 'sogotokyunm',
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
