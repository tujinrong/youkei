import { reactive } from 'vue'
import { SidoCommonRequest } from './type'

/**検索Params(指導項目) */
export const sidoParams = reactive<Partial<SidoCommonRequest>>({
  sidokbn: undefined,
  gyomukbn: undefined,
  mosikomikekkakbn: undefined,
  itemyotokbn: undefined
})
