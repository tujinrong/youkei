import VXETable from 'vxe-table'
import { h } from 'vue'
import jaJP from 'vxe-table/lib/locale/lang/ja-JP'
import { Empty } from 'ant-design-vue'
import {
  getDateHmsJpText,
  getDateJpText,
  getSimpleDateJpText,
  getSimpleDateHmsJpText,
  yearFormatter,
  getUnKnownDateJpText,
  formatTime,
  formatYubin,
} from './utils/util'
import 'vxe-table/lib/style.css'
import '@/styles/scss/vxe.scss'

//グローバルパラメータ
VXETable.setConfig({
  loading: { text: '' },
  table: {
    border: true,
    showOverflow: 'tooltip',
    // minHeight: 36,
  },
})
VXETable.setI18n('ja-JP', jaJP)
VXETable.setLanguage('ja-JP')
//フォーマット
VXETable.formats.mixin({
  //和暦
  jpTime({ cellValue }) {
    return cellValue ? getDateHmsJpText(new Date(cellValue)) : ''
  },
  jpDate({ cellValue }) {
    return cellValue ? getDateJpText(new Date(cellValue)) : ''
  },
  jpTimeSimple({ cellValue }) {
    return cellValue ? getSimpleDateHmsJpText(new Date(cellValue)) : ''
  },
  jpDateSimple({ cellValue }) {
    return cellValue ? getSimpleDateJpText(new Date(cellValue)) : ''
  },
  jpYear({ cellValue }) {
    return cellValue ? yearFormatter(cellValue) : ''
  },
  jpUnknownDate({ cellValue }) {
    return cellValue ? getUnKnownDateJpText(cellValue) : ''
  },
  //まる
  maru({ cellValue }) {
    return cellValue ? '○' : ''
  },
  //数値千の桁区切り
  localeNum({ cellValue }) {
    if (cellValue === null || cellValue === undefined) return ''
    return Number(cellValue).toLocaleString()
  },
  //0000 => 00:00
  splitTime({ cellValue }) {
    return formatTime(cellValue)
  },
  //郵便番号
  yubin({ cellValue }) {
    return formatYubin(cellValue)
  },
})
//空のデータ Renderer
VXETable.renderer.add('NotData', {
  renderEmpty() {
    return h(Empty, { image: Empty.PRESENTED_IMAGE_SIMPLE })
  },
})

export default VXETable
