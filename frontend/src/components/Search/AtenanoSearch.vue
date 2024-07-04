<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 宛名番号検索
 * 　　　　　  共通コンポーネント
 * 作成日　　: 2024.02.13
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div flex>
    <AtenaNo
      ref="atenanoRef"
      v-model:value="params.atenano"
      class="mr-1"
      @search="searchByAtenano"
      @blur="endFocus"
      @focus="startFocus"
    />
    <AtenaSearchButton v-if="showButton" @select="onSelect" />
  </div>
</template>

<script setup lang="ts">
import { E004006 } from '@/constants/msg'
import { useBoolean } from '@/utils/hooks'
import AtenaNo from '@/views/affect/AF/AWAF00701D/index.vue'
import { Save } from '@/views/affect/AF/AWAF00701D/service'
import AtenaSearchButton from '@/views/affect/AF/AWAF00705D/button.vue'
import { ref } from 'vue'
import { useRoute } from 'vue-router'

interface Params {
  atenano?: string
  nendo?: number
}
interface SearchResponse extends CmSearchResponseBase {
  /** 結果 */
  kekkalist: any[]
}

const props = defineProps<{
  params: Params
  searchRequest: (
    params: Params,
    onNextOk: (data: { message: string }) => void
  ) => Promise<SearchResponse>
  showButton?: boolean
}>()
const emit = defineEmits(['finish', 'update:loading'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const atenanoRef = ref<InstanceType<typeof AtenaNo> | null>(null)
//入力時に検索ボタンを無効にします
const { bool: focused, setTrue: startFocus, setFalseDelay: endFocus } = useBoolean()

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理(宛名番号)
const searchByAtenano = async (val) => {
  emit('update:loading', true)
  try {
    const res = await props.searchRequest(
      {
        atenano: val.atenano,
        nendo: props.params.nendo
      },
      ({ message }) => {
        if (message.includes(E004006.No)) {
          props.params.atenano = ''
          atenanoRef.value?.$el.querySelector('input').focus()
        }
      }
    )
    emit('finish', res.kekkalist[0])
  } catch (error) {}
  emit('update:loading', false)
}

const onSelect = (val) => {
  props.params.atenano = val.atenano
  searchByAtenano(val)
  Save({
    kinoid: route.name as string,
    atenano: val.atenano
  })
}

defineExpose({ focused })
</script>
