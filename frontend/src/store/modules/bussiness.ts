/** -----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 業務系
 * 　　　　　  データストア設定
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { SET_USER_HISTORY } from '@/constants/mutation-types'

const bussiness = {
  state: {
    historyList: []
  },
  mutations: {
    [SET_USER_HISTORY]: (state, value) => {
      state.historyList = value
    }
  }
}

export default bussiness
