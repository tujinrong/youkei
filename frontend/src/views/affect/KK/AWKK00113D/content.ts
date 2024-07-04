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
    title: '個人番号',
    field: 'personalno',
    width: ''
  },
  {
    title: '更新日時',
    field: 'upddttm',
    width: ''
  },
  {
    title: '最新',
    field: 'saisin',
    width: '80'
  }
]
