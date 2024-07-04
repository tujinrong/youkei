import { ReportWithYosikiVM } from './type'

export const rptsbtOptions = [
  {
    label: '帳票',
    value: 1
  },
  {
    label: '別様式',
    value: 2
  }
  //TODO 多分七月にこの機能を元に戻す
  // {
  //   label: 'サブ様式',
  //   value: 3
  // }
]

export const meisaikoteikbnOptions = [
  {
    label: '固定',
    value: 1
  },
  {
    label: '可変',
    value: 2
  }
]

export const meisaiflgOptions = [
  {
    label: '明細あり',
    value: true
  },
  {
    label: '明細なし',
    value: false
  }
]

export const layout = {
  xs: 24,
  sm: 24,
  md: 24,
  xxl: 24
}

export const getStyleOptions = (arr: ReportWithYosikiVM[]) => {
  const options: any[] = []

  arr.forEach((item) => {
    let tempItem = {}
    item.selectorlist.forEach((child) => {
      tempItem = {
        ...item,
        yosikinm: child.label,
        yosikiid: child.value
      }
      options.push(tempItem)
    })
  })

  console.log('options', options)
  return options
}
