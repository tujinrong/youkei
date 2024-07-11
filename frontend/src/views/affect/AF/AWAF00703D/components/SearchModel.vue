<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 詳細条件検索(参照ダイアログ)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.05.17
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-collapse-panel :show-arrow="false">
    <template #header>
      <span>{{ title + (curCond ? '（条件あり）' : '') }}</span>
    </template>
    <div>
      <div class="flex justify-between">
        <a-radio-group v-model:value="curCond">
          <a-radio :value="false">条件なし</a-radio>
          <a-radio :value="true">条件あり</a-radio>
        </a-radio-group>
      </div>
      <a-form-item :name="name" class="m-t-1 m-b-1" :rules="rule">
        <template v-if="type === Enum参照ダイアログ項目区分.宛名番号">
          <InputSearch
            :value="value?.value1"
            :disabled="!curCond"
            :placeholder="placeholder"
            @change="(v) => emit('update:value', { value1: v })"
            @search="
              (v) => {
                emit('update:value', { value1: v })
                emit('validate', props.name)
              }
            "
          ></InputSearch>
        </template>
        <template v-if="type === Enum参照ダイアログ項目区分.医療機関">
          <div class="w-full flex gap-1">
            <ai-select
              :value="value?.value1"
              :disabled="!curCond"
              :placeholder="placeholder"
              :options="options"
              split-val
              @change="(v) => emit('update:value', { value1: v })"
            />
            <OrganizeButton
              has-stop-flg
              :jigyocds="jigyocds"
              :disabled="!curCond"
              @select="
                (v) => {
                  emit('update:value', { value1: v.kikancd })
                  emit('validate', props.name)
                }
              "
            />
          </div>
        </template>
        <template v-if="type === Enum参照ダイアログ項目区分.事業従事者">
          <div class="w-full flex gap-1">
            <ai-select
              :value="value?.value1"
              :disabled="!curCond"
              :placeholder="placeholder"
              :options="options"
              split-val
              @change="(v) => emit('update:value', { value1: v })"
            />
            <StaffButton
              has-stop-flg
              :jigyocds="jigyocds"
              :disabled="!curCond"
              @select="
                (v) => {
                  emit('update:value', { value1: v.staffid })
                  emit('validate', props.name)
                }
              "
            />
          </div>
        </template>
        <template v-if="type === Enum参照ダイアログ項目区分.検診実施機関">
          <div class="w-full flex gap-1">
            <ai-select
              :value="value?.value1"
              :disabled="!curCond"
              :placeholder="placeholder"
              :options="options"
              split-val
              @change="(v) => emit('update:value', { value1: v })"
            />
            <OrganizeButton
              has-stop-flg
              :jigyocds="jigyocds"
              :disabled="!curCond"
              @select="
                (v) => {
                  emit('update:value', { value1: v.hokenkikancd })
                  emit('validate', props.name)
                }
              "
            />
          </div>
        </template>
      </a-form-item>
    </div>
  </a-collapse-panel>
</template>

<script setup lang="ts">
import { Enum参照ダイアログ項目区分 } from '#/Enums'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { computed, nextTick } from 'vue'
import InputSearch from '@/views/affect/AF/AWAF00705D/InputSearch.vue'
import OrganizeButton from '@/views/affect/AF/AWAF00702D/button.vue'
import StaffButton from '@/views/affect/AF/AWAF00704D/button.vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  type: Enum参照ダイアログ項目区分
  name: string
  title: string
  placeholder: string
  condition: boolean
  options: DaSelectorModel[]
  /**実施事業 */
  jigyocds?: string
  value?: { value1?: string }
}>()
const emit = defineEmits(['update:value', 'update:condition', 'validate'])

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const curCond = computed({
  get() {
    return props.condition
  },
  set(v) {
    emit('update:condition', v)
    nextTick(() => {
      emit('validate', props.name)
    })
  }
})
//必須チェック設定
const rule = computed(() => {
  return [
    {
      validator: (_, value) => {
        if (curCond.value && !value?.value1) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', props.title))
        }
        return Promise.resolve()
      },
      trigger: ['change']
    }
  ]
})
</script>
