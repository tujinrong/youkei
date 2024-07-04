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
    title: '被保険者番号',
    field: 'hihokensyano',
    width: ''
  },
  {
    title: '取得年月日',
    field: 'hiho_sikakusyutokuymd',
    width: ''
  },
  {
    title: '喪失年月日',
    field: 'hiho_sikakusosituymd',
    width: ''
  },
  {
    title: '取得事由',
    field: 'hiho_sikakusyutokujiyunm',
    width: ''
  },
  {
    title: '喪失事由',
    field: 'hiho_sikakusositujiyunm',
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
