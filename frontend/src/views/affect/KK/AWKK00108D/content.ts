import { RowVM } from './type'

interface ColVM {
  title: string
  field: keyof RowVM
  width: string
}

export const columns: ColVM[] = [
  {
    title: '申請履歴番号',
    field: 'sinseirirekino',
    width: ''
  },
  {
    title: '決定履歴番号',
    field: 'ketteirirekino',
    width: ''
  },
  {
    title: '福祉事務所',
    field: 'fukusijimusyocd',
    width: ''
  },
  {
    title: 'ケース番号',
    field: 'caseno',
    width: ''
  },
  {
    title: '員番号',
    field: 'inno',
    width: ''
  },
  {
    title: '開始年月日',
    field: 'seihoymdf',
    width: ''
  },
  {
    title: '停止年月日',
    field: 'teisiymd',
    width: ''
  },
  {
    title: '停止解除年月日',
    field: 'teisikaijoymd',
    width: '140'
  },
  {
    title: '廃止年月日',
    field: 'haisiymd',
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
