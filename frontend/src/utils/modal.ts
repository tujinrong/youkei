/** -----------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: カンファーム
 * 　　　　　  確認処理
 * 作成日　　: 2023.03.29
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { Modal, ModalFuncProps } from 'ant-design-vue'
import {
  SAVE_CONFIRM,
  DELETE_CONFIRM,
  LOGIC_DELETE_CONFIRM,
} from '../constants/msg'
import { request } from '@/service/request'
import { h } from 'vue'
import {
  QuestionCircleOutlined,
  WarningOutlined,
  CloseCircleOutlined,
  InfoCircleOutlined,
} from '@ant-design/icons-vue'

interface Options extends ModalFuncProps {
  /** データベース処理 */
  handleDB?: boolean
  content?: any
  okButtonProps?: { type?: any } //ボタンCSS:ant-design-${type}
  type?: 'info' | 'error' | 'warning'
}

//Custom Icon
const icon_ques = h(QuestionCircleOutlined, { style: 'color:#00b050' })
const icon_warn = h(WarningOutlined, { style: 'color:#f7d42a' })
const icon_error = h(CloseCircleOutlined, { style: 'color:#ff4d4f' })
const icon_info = h(InfoCircleOutlined, { style: 'color:#1890ff' })

/**
 * 共通確認
 * @param {booble} options.handleDB  必要ありません  データベースを処理しますか
 * @param {string} options.content   必要  内容
 */
export function showConfirmModal(options: Options): void {
  Modal.confirm({
    okText: 'は い',
    cancelText: 'いいえ',
    okButtonProps: { type: options.handleDB ? 'warn' : 'primary' },
    autoFocusButton: null,
    icon: options.title === 'アラート' ? icon_warn : icon_ques,
    ...options,
    title: options.title ?? '確認',
    style: { 'white-space': 'pre-wrap' },
    content: options.content.Msg || options.content,
    onCancel() {
      request.cancelAllRequest()
      options.onCancel?.()
    },
  })
}
/**
 * アラート
 * @param {string} options.content    必要  内容
 */
export function showInfoModal(options: Options): void {
  Modal[options.type || 'info']({
    okText: 'は い',
    icon:
      options.type === 'warning'
        ? icon_warn
        : options.type === 'error'
          ? icon_error
          : icon_info,
    ...options,
    title:
      options.title ??
      (options.type === 'warning'
        ? 'アラート'
        : options.type === 'error'
          ? 'エラー'
          : '情報'),
    style: { 'white-space': 'pre-wrap' },
    content: options.content.Msg || options.content,
  })
}

/** 保存確認 */
export function showSaveModal(options: Options): void {
  Modal.confirm({
    title: '確認',
    okText: 'は い',
    cancelText: 'いいえ',
    okButtonProps: { type: 'warn' },
    autoFocusButton: null,
    icon: icon_ques,
    ...options,
    style: { 'white-space': 'pre-wrap' },
    content: options.content || SAVE_CONFIRM.Msg,
    onCancel() {
      request.cancelAllRequest()
      options.onCancel?.()
    },
  })
}

/**
 * 削除確認
 * @param {booble} options.handleDB  必要ありません  データベースを処理しますか
 * @param {string} options.content   必要ありません  内容
 */
export function showDeleteModal(options: Options): void {
  let content = options.handleDB
    ? DELETE_CONFIRM.Msg
    : LOGIC_DELETE_CONFIRM.Msg.replace('{0}', '選択テータ')
  if (options.content) {
    content = options.content.Msg || options.content
  }
  Modal.confirm({
    title: '確認',
    okText: options.handleDB ? '削 除' : 'は い',
    cancelText: 'いいえ',
    okButtonProps: { danger: Boolean(options.handleDB) },
    autoFocusButton: null,
    icon: icon_ques,
    ...options,
    style: { 'white-space': 'pre-wrap' },
    content,
    onCancel() {
      request.cancelAllRequest()
      options.onCancel?.()
    },
  })
}
