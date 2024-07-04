/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: チェック処理
 * 　　　　　  共通関数
 * 作成日　　: 2023.03.03
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { EnumMsgCtrlKbn, Enum入力タイプ, Enum画面項目入力 } from '#/Enums'
import {
  E004005,
  ITEM_EQUAL_ERROR,
  ITEM_ILLEGAL_ERROR,
  ITEM_NOTEQUAL_ERROR,
  ITEM_REQUIRE_ERROR
} from '@/constants/msg'

import * as Msgs from '@/constants/msg'
import { getDateJpText } from './util'

interface ValidateConfig {
  is: boolean
  type:
    | 'REQUIRE'
    | 'MAX_LEN'
    | 'MIN_LEN'
    | 'MAX_DATE'
    | 'MIN_DATE'
    | 'EQUAL'
    | 'NOTEQUAL'
    | 'ILLEGAL'
    | 'AWAF00201D_PWD'
  name?: string
  date?: string
  len?: number | null
}

const validate = async (obj: ValidateConfig): Promise<void> => {
  let message = ''
  const { is, type = 'REQUIRE', name = '', len = 0, date = '' } = obj
  if (is) {
    switch (type) {
      //--------------------------------------------------------------------------
      //共通
      //--------------------------------------------------------------------------
      //必須チェック
      case 'REQUIRE':
        message = ITEM_REQUIRE_ERROR.Msg.replace('{0}', name)
        break
      //長さチェック(上限)
      case 'MAX_LEN':
        message = ITEM_REQUIRE_ERROR.Msg.replace('{0}', `${len}文字以下`)
        break
      //長さチェック(下限)
      case 'MIN_LEN':
        message = ITEM_REQUIRE_ERROR.Msg.replace('{0}', `${len}文字以上`)
        break
      //日付チェック(下限)
      case 'MIN_DATE':
        message = ITEM_REQUIRE_ERROR.Msg.replace('{0}', `${getDateJpText(new Date(date))}以上`)
        break
      //日付チェック(上限)
      case 'MAX_DATE':
        message = ITEM_REQUIRE_ERROR.Msg.replace('{0}', `${getDateJpText(new Date(date))}以下`)
        break
      //一致チェック
      case 'EQUAL':
        message = ITEM_EQUAL_ERROR.Msg.replace('{0}', name)
        break
      //不一致チェック
      case 'NOTEQUAL':
        message = ITEM_NOTEQUAL_ERROR.Msg.replace('{0}', name)
        break
      //不正確さ
      case 'ILLEGAL':
        message = ITEM_ILLEGAL_ERROR.Msg.replace('{0}', name)
        break
      //--------------------------------------------------------------------------
      //業務
      //--------------------------------------------------------------------------
      //パスワードチェック
      case 'AWAF00201D_PWD':
        message = E004005.Msg.replace('{0}', name)
        break
      default:
        break
    }
    return Promise.reject(message)
  }
  return
}

//パスワード関連チェック
async function pwdValidate(rules: CmPwdInitResponse, value: string) {
  const { pwdflg, numflg, enflg, symbolflg, symbolstr } = rules
  const reg = new RegExp(`[${symbolstr.replaceAll(' ', '').split('').join('\\')}]`)
  if (pwdflg && value) {
    //数値チェック
    await validate({
      is: numflg && !/[0-9]/.test(value),
      type: 'AWAF00201D_PWD',
      name: '数字'
    })
    //英字チェック
    await validate({
      is: enflg && !/[a-zA-Z]/.test(value),
      type: 'AWAF00201D_PWD',
      name: '英字'
    })
    //記号チェック
    await validate({
      is: symbolflg && !reg.test(value),
      type: 'AWAF00201D_PWD',
      name: symbolstr
    })
    //長さチェック
    await validate({
      is: value.length < 8,
      type: 'MIN_LEN',
      len: 8
    })
  } else {
    //ポリシーがない場合、長さチェックのみ
    await validate({
      is: Boolean(value && value.length < 8),
      type: 'MIN_LEN',
      len: 8
    })
  }
}

//
async function validateByInputtype(value, el: FixFreeItemBaseVM, msgid: string): Promise<void> {
  let errMsg = ''
  for (const key in Msgs) {
    if (msgid === Msgs[key].No) {
      errMsg = Msgs[key].Msg
      break
    }
  }

  const inputTypeRegex = {
    [Enum入力タイプ.半角文字_半角数字]: /^[0-9]+$/,
    [Enum入力タイプ.半角文字_半角英数字]: /^[a-zA-Z0-9]+$/,
    [Enum入力タイプ.半角文字_年]: /^[0-9]+$/,
    [Enum入力タイプ.半角文字_年_不詳あり]: /^[0-9]+$/,
    [Enum入力タイプ.半角文字_年月]: /^[0-9]+[-/]?(0[1-9]|1[0-2])$/,
    [Enum入力タイプ.半角文字_年月_不詳あり]: /^[0-9]+[-/]?(0[1-9]|1[0-2]|[Aa][1-3])$/,
    [Enum入力タイプ.半角文字_時刻]: /^([01]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$/
  }

  if (el.hissuflg && el.msgkbn == EnumMsgCtrlKbn.エラー && !value && value !== 0) {
    const msg = errMsg.replace('{0}', el.itemnm)
    return Promise.reject(msg)
  }
  if (el.inputkbn === Enum画面項目入力.文字) {
    await validate({
      is: inputTypeRegex[el.inputtypekbn] && !inputTypeRegex[el.inputtypekbn].test(value) && value,
      type: 'ILLEGAL',
      name: el.itemnm
    })
  }

  return Promise.resolve()
}

export { validate, validateByInputtype, pwdValidate }
