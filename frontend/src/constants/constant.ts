/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: まとめ
 * 　　　　　  定数
 * 作成日　　: 2023.03.29
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import config from '@/config/default-settings'
import { Enum未読区分, Enum表示区分 } from '#/Enums'
import type { SelectProps } from 'ant-design-vue'

//---------------------------------------------------------------------------
//共通設定
//--------------------------------------------------------------------------
/***
 * @description 本番環境か
 */
export const IS_PROD = ['production', 'prod'].includes(process.env.NODE_ENV)
export const IS_DEV = ['development'].includes(process.env.NODE_ENV)

/** 1秒 */
export const TIMER_ONE_M = 1000
/** 2秒 */
export const TIMER_TWO_M = 2000
/** email's regex */
export const REGEX_email =
  /(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))/
/** time's regex (00:00:00 - 99:59:59)*/
export const REGEX_time = /^([0-9][0-9]):[0-5]\d:[0-5]\d$/
/** date's regex(不明を含む)*/
export const REGEX_date = /^[0-9]{4}-[0-9aAbBc]{2}-[0-9aA]{2}$/
/**和暦年号 */
export const ERA_YEARS = {
  M: 1868,
  T: 1912,
  S: 1926,
  H: 1989,
  R: 2019,
  1: 1868,
  2: 1912,
  3: 1926,
  4: 1989,
  5: 2019
  //拡張可能...
}
//---------------------------------------------------------------------------
//ドロップダウンリスト
//--------------------------------------------------------------------------
/** 未読区分 */
export const readOptions: SelectProps['options'] = [
  { value: Enum未読区分.未読, label: '未読' },
  { value: Enum未読区分.すべて, label: 'すべて' }
]
/** 表示区分 */
export const showOptions: SelectProps['options'] = [
  { value: Enum表示区分.期限内, label: '期限が過ぎていないもののみ表示' },
  { value: Enum表示区分.すべて, label: 'すべて表示' }
]
/** 月 */
export const monthOptions: DaSelectorModel[] = [
  { value: '1', label: '1月' },
  { value: '2', label: '2月' },
  { value: '3', label: '3月' },
  { value: '4', label: '4月' },
  { value: '5', label: '5月' },
  { value: '6', label: '6月' },
  { value: '7', label: '7月' },
  { value: '8', label: '8月' },
  { value: '9', label: '9月' },
  { value: '10', label: '10月' },
  { value: '11', label: '11月' },
  { value: '12', label: '12月' }
]

//---------------------------------------------------------------------------
//マップ
//--------------------------------------------------------------------------
/** 重要度 */
export const noticeJuyoStrMap = {
  '1': '大',
  '2': '中',
  '3': '小'
}
/** 重要度 色 */
export const noticeJuyoColorMap = {
  '1': '#ff4d4f',
  '2': '#1890ff',
  '3': '#87d068'
}
/** 処理状況 色 */
export const operationStatusMap = {
  '0': '#000000',
  '1': '#1d4ed8',
  '2': '#FF0000',
  '3': '#33c481',
  '4': '#ffffe1'
}
/** 性別 色 */
export const sexColorMap = {
  男: '#1d4ed8',
  女: '#FF0000'
}
/** テーマカラー */
export const colorList = [
  {
    key: '群青（デフォルト）',
    color: config.primaryColor
  },
  {
    key: '銀朱',
    color: '#c73e3a'
  },
  {
    key: '紅緋',
    color: '#f75c2f'
  },
  {
    key: '籐黄',
    color: '#ffc408'
  },
  {
    key: '水浅葱',
    color: '#66bab7'
  },
  {
    key: '緑青',
    color: '#24936e'
  },
  {
    key: '瑠璃',
    color: '#005caf'
  },
  {
    key: '菫',
    color: '#66327c'
  }
]
