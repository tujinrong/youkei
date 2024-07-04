import { Enumページサイズ } from '#/Enums'

export const sheetCreateConfig = {
  container: 'luckysheet',
  allowEdit: false,
  enableAddBackTop: false,
  row: 0,
  column: 0,
  allowCopy: true,
  showstatisticBar: false,
  showstatisticBarConfig: {
    zoom: true
  },
  enableAddRow: false,
  showsheetbar: false,
  sheetRightClickConfig: {
    delete: false, // 削除
    copy: false, // レプリケーション
    rename: false, //名前を変更
    color: false, //色の変更
    hide: false, //非表示、非表示＃ヒヒョウジ＃
    move: false //左に移動、右に移動
  },
  cellRightClickConfig: {
    copy: false,
    copyAs: false,
    paste: false,
    insertRow: false,
    insertColumn: false,
    deleteRow: false,
    deleteColumn: false,
    deleteCell: false,
    hideRow: false,
    hideColumn: false,
    rowHeight: false,
    columnWidth: false,
    clear: true,
    matrix: false,
    sort: false,
    filter: false,
    chart: false,
    image: false,
    link: false,
    data: false,
    cellFormat: false
  }
}

export const sizeOptions = [
  { label: 'A3', value: Enumページサイズ.A3 },
  { label: 'A4', value: Enumページサイズ.A4 },
  { label: 'A5', value: Enumページサイズ.A5 },
  { label: 'A6', value: Enumページサイズ.A6 },
  { label: 'B5', value: Enumページサイズ.B5 },
  { label: 'B6', value: Enumページサイズ.B6Jis }
]

export const landscapeOptions = [
  { label: '縦', value: false },
  { label: '横', value: true }
]
