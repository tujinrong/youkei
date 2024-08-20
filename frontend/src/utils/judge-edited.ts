/** -----------------------------------------------------------------
 * 業務名称　: 互助防疫システム
 * 機能概要　: 共通処理
 * 　　　　　  画面データ編集判断
 * 作成日　　: 2024.07.30
 * 作成者　　: 屠
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { CLOSE_CONFIRM } from '@/constants/msg'
import { useEventListener } from '@vueuse/core'
import { judgeStore } from '@/store'
import { showConfirmModal } from './modal'
import { Modal } from 'ant-design-vue'

/**画面データ編集判断Class */
export class Judgement {
  private isEdited: boolean
  private kinoid: string

  constructor(kinoid = '') {
    this.isEdited = false
    this.kinoid = kinoid
  }

  public setEdited(): void {
    if (this.kinoid) {
      judgeStore[this.kinoid] = true
      // console.log('judgeStore: ', judgeStore)
    }
    this.isEdited = true

    console.log('setEdited', this.isEdited)
  }

  public isPageEdited(): boolean {
    return this.isEdited
  }

  public reset(): void {
    if (this.kinoid) {
      judgeStore[this.kinoid] = false
      // console.log('judgeStore: ', judgeStore)
    }
    this.isEdited = false
    console.log('reset', this.isEdited)
  }

  public judgeIsEdited(onOk: () => void, message?: string): void {
    // console.log('judgeIsEdited', this.isEdited)
    if (this.isEdited) {
      Modal.destroyAll()
      showConfirmModal({
        content: message ?? CLOSE_CONFIRM.Msg,
        onOk: async () => {
          this.reset()
          onOk()
        },
      })
    } else {
      onOk()
    }
  }

  public addEvent(): void {
    useEventListener(window, 'beforeunload', (e) => {
      if (this.isEdited) {
        e.preventDefault()
        e.returnValue = CLOSE_CONFIRM.Msg
      }
    })
    useEventListener(window, 'unload', (e) => {
      this.reset()
    })
  }
}

export const judgement = new Judgement('')
judgement.addEvent()
