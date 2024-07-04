/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ヘルプ
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.03
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { showConfirmModal } from '@/utils/modal'
import Router from '@/router'
import { Download } from './service'
import { DOWNLOAD_CONFIRM } from '@/constants/msg'

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//確認ダイアログボックスを表示
export const showHelp = (): void => {
  showConfirmModal({
    title: 'ヘルプ',
    content: DOWNLOAD_CONFIRM,
    onOk() {
      Download({ kinoid: Router.currentRoute.value.name as string })
    }
  })
}
