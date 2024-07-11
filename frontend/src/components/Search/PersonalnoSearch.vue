<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 個人番号検索
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.02.13
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-input
    ref="personalnoRef"
    v-model:value="params.personalno"
    :maxlength="12"
    @focus="startFocus"
    @blur="searchByPersonNo"
    @change="params.personalno = replaceText(params.personalno, EnumRegex.半角数字)"
  />
</template>

<script setup lang="ts">
import { EnumRegex } from '#/Enums'
import { encryptByRSA } from '@/utils/encrypt/data'
import { useBoolean } from '@/utils/hooks'
import { replaceText } from '@/utils/util'
import { ref } from 'vue'

interface Params {
  personalno?: string
  nendo?: number
}
interface SearchResponse extends CmSearchResponseBase {
  /** 結果 */
  kekkalist: any[]
  /** 遷移フラグ */
  transflg?: boolean
}

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  params: Params
  searchRequest: (params: Params) => Promise<SearchResponse>
}>()
const emit = defineEmits([
  'finish',
  'update:loading',
  'update:totalCount',
  'update:tableList',
  'clear'
])

const personalnoRef = ref<HTMLInputElement>()
//入力時に検索ボタンを無効にします
const { bool: focused, setTrue: startFocus, setFalseDelay: endFocus } = useBoolean()

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理(個人番号)
const searchByPersonNo = async () => {
  endFocus()
  if (!props.params.personalno) return
  props.params.personalno = props.params.personalno.padStart(12, '0')
  emit('update:loading', true)
  try {
    const res = await props.searchRequest({
      //暗号化
      personalno: encryptByRSA(props.params.personalno),
      nendo: props.params.nendo
    })
    //遷移フラグ: 自動に詳細画面へ遷移 (AWSH001)
    if (res.transflg) {
      emit('finish', res.kekkalist[0])
    }
    //検索結果が1件以上の場合、自動に詳細画面へ遷移
    else if (res.kekkalist.length >= 1) {
      emit('finish', res.kekkalist[0])
    }
    //検索結果がない場合、個人番号をクリアします
    else if (res.kekkalist.length === 0) {
      //props.params.personalno = ''
      personalnoRef.value?.focus()
    }
    props.params.personalno = ''
    emit('update:totalCount', res.totalrowcount)
    emit('update:tableList', res.kekkalist)

    //クリア: 詳細画面から一覧画面へ戻す時 (AWSH001)
    emit('clear')
  } catch (error) {}
  emit('update:loading', false)
}

defineExpose({ focused })
</script>
