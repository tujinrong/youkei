/** ----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ルーター関連
 * 　　　　　  インターフェース定義
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { defineComponent } from 'vue'

export type Component<T extends any = any> =
  | ReturnType<typeof defineComponent>
  | (() => Promise<typeof import('*.vue')>)
  | (() => Promise<T>)

export interface RouterMeta {
  title: string
  icon?: any
  target?: string
  hidden?: boolean
  disabled?: boolean
  isfolder?: boolean
  paramkeisyoflg?: boolean
  enabled?: boolean
  addflg?: boolean
  delflg?: boolean
  updflg?: boolean
  personalnoflg?: boolean
}

export interface Router {
  key?: string
  name: string
  path: string
  redirect?: string
  meta?: RouterMeta
  component?: Component | string
  children?: Router[]
  hidden?: boolean
  isfolder?: boolean
  parentId?: string | number
  id?: string | number
}
