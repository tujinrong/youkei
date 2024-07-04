import { RowVM } from './type'

interface ColVM {
  title: string
  field: keyof RowVM
  width: string
}

export const columns: ColVM[] = [
  {
    title: '資格履歴番号',
    field: 'sikakurirekino',
    width: ''
  },
  {
    title: '介護保険者番号',
    field: 'kaigohokensyano',
    width: ''
  },
  {
    title: '被保険者番号',
    field: 'hihokensyano',
    width: ''
  },
  {
    title: '資格取得日',
    field: 'sikakusyutokuymd',
    width: ''
  },
  {
    title: '資格喪失日',
    field: 'sikakusosituymd',
    width: ''
  },
  {
    title: '要介護認定日',
    field: 'yokaigoninteiymd',
    width: ''
  },
  {
    title: '要介護状態区分',
    field: 'yokaigojotaikbnnm',
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
