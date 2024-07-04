import { RowVM } from './type'

interface ColVM {
  title: string
  field: keyof RowVM
  width: string
}

export const columns: ColVM[] = [
  {
    title: '被保険者履歴番号',
    field: 'hihokensyarirekino',
    width: ''
  },
  {
    title: '国保記号番号',
    field: 'kokuho_kigono',
    width: ''
  },
  {
    title: '枝番',
    field: 'kokuho_edano',
    width: '80'
  },
  {
    title: '取得年月日',
    field: 'kokuho_sikakusyutokuymd',
    width: ''
  },
  {
    title: '喪失年月日',
    field: 'kokuho_sikakusosituymd',
    width: ''
  },
  {
    title: '取得事由',
    field: 'kokuho_sikakusyutokujiyu',
    width: ''
  },
  {
    title: '喪失事由',
    field: 'kokuho_sikakusositujiyu',
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
