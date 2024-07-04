<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 詳細条件検索(EUC)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.03.22
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-drawer
    v-model:visible="visible"
    placement="left"
    title="詳細検索条件"
    :footer="null"
    width="480px"
    :mask-closable="true"
    class="drawer_title_reverse"
  >
    <a-row :gutter="10">
      <a-col :span="24" class="mincho">
        <a-form ref="leftFormRef" :model="leftValues" :hide-required-mark="true">
          <a-collapse v-model:activeKey="activeKeyCollapse1">
            <template v-for="item in leftList" :key="item.id">
              <ListModel
                v-if="item.ctrltype === Enumコントローラータイプ.一覧選択"
                :key="item.id"
                v-model:value="leftValues[item.id]"
                v-model:condition="leftConditions[item.id]"
                :name="item.id"
                :title="item.hyojinm"
                :options="item.cdlist"
                @validate="validateFields"
              />
              <SingleModel
                v-if="item.ctrltype === Enumコントローラータイプ.通用項目 && !item.rangeflg"
                :key="item.id"
                v-model:value="leftValues[item.id]"
                v-model:condition="leftConditions[item.id]"
                :name="item.id"
                :title="item.hyojinm"
                :placeholder="item.placeholder"
                :type="item.itemkbn"
                @validate="validateFields"
              />
              <RangeModel
                v-if="item.ctrltype === Enumコントローラータイプ.通用項目 && item.rangeflg"
                :key="item.id"
                v-model:value="leftValues[item.id]"
                v-model:condition="leftConditions[item.id]"
                :name="item.id"
                :title="item.hyojinm"
                :placeholder="item.placeholder"
                :type="item.itemkbn"
                @validate="validateFields"
              />
              <AgeModel
                v-if="item.ctrltype === Enumコントローラータイプ.年齢生年月日 && leftAgeItem"
                ref="ageModelRef"
                key="age"
                :title="leftAgeItem.hyojinm"
                :placeholder="leftAgeItem.placeholder"
                :filter="{
                  manflg: leftAgeItem.manflg,
                  womanflg: leftAgeItem.womanflg,
                  bothflg: leftAgeItem.bothflg,
                  unknownflg: leftAgeItem.unknownflg
                }"
              />
            </template>
          </a-collapse>
        </a-form>
      </a-col>
    </a-row>
    <div class="m-t-2 font-semibold c-blue-6">画面上部の検索条件は複合条件となります。</div>
  </a-drawer>
</template>

<script setup lang="ts">
import { FormInstance, message } from 'ant-design-vue'
import { computed, reactive, ref } from 'vue'
import { ValidateErrorEntity } from 'ant-design-vue/es/form/interface'
import ListModel from '@/views/affect/AF/AWAF00703D/components/ListModel.vue'
import RangeModel from '@/views/affect/AF/AWAF00703D/components/RangeModel.vue'
import SingleModel from '@/views/affect/AF/AWAF00703D/components/SingleModel.vue'
import AgeModel from '@/views/affect/AF/AWAF00703D/components/AgeModel.vue'
import { EnumBirthSearchKbn, Enumコントローラータイプ, TargetType } from '#/Enums'
import { DetailJyokenInitVM } from '../../../type'
import { showInfoModal } from '@/utils/modal'

const props = defineProps<{
  data: DetailJyokenInitVM[]
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const leftFormRef = ref<FormInstance>()
const ageModelRef = ref()
const visible = ref(false)

const activeKeyCollapse1 = ref(['left1'])
const leftList = ref<DetailJyokenInitVM[]>([])
const leftConditions = reactive<{ [key: string]: boolean }>({})
const leftValues = reactive<{ [key: string]: any }>({})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const leftAgeItem = computed(() => {
  return leftList.value.find((item) => item.ctrltype === Enumコントローラータイプ.年齢生年月日)
})

//条件入力されたかどうかを判断し、タイトルを変更(「条件あり」)
const hasCondition = computed<boolean>(() => {
  let flag = false
  for (const key in leftConditions) {
    if (leftConditions[key]) flag = true
  }
  if (ageModelRef.value) {
    return flag || ageModelRef.value[0]?.hasCondition
  }
  return flag
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//ドロップダウンリスト内条件項目を展開する
async function showDrawer() {
  visible.value = true
  if (leftList.value.length === 0) {
    leftList.value = props.data
    init()
  }
}
//初期化(各条件の名称と設定を取得)
function init() {
  for (const item of leftList.value) {
    item.id = TargetType.Left + item.jyoseq
    leftConditions[item.id] = false
    leftValues[item.id] = null
  }
}

//入力条件をリセット
function resetDrawer() {
  init()
  leftFormRef.value?.clearValidate()
  if (ageModelRef.value) ageModelRef.value[0]?.clearValidate()
}

//フォームチェック
function validateFields(v: string) {
  leftFormRef.value?.validateFields([v])
}
async function validateDrawer() {
  return Promise.allSettled([
    leftFormRef.value?.validate(),
    ageModelRef.value ? ageModelRef.value[0]?.validate() : null
  ]).then((res) => {
    const [res_left, res_age] = res
    //チェックエラーの場合、失敗項目を展開して、エラーメッセージを表示する
    //左(共通)
    if (res_left.status === 'rejected') {
      const Error = res_left.reason as ValidateErrorEntity
      for (const errorItem of Error.errorFields) {
        showInfoModal({
          type: 'error',
          title: 'エラー',
          content: errorItem.errors[0]
        })
        if (!activeKeyCollapse1.value.includes(errorItem.name[0] as string)) {
          activeKeyCollapse1.value = [...activeKeyCollapse1.value, errorItem.name[0] as string]
        }
      }
    }
    //年齢・生年月日
    if (res_age.status === 'rejected') {
      if (!activeKeyCollapse1.value.includes('age')) {
        activeKeyCollapse1.value = [...activeKeyCollapse1.value, 'age']
      }
    }
    if (res.some((i) => i.status === 'rejected')) {
      showDrawer()
      return Promise.reject()
    } else {
      //チェッククリアの場合、値を設定する
      const conditionlist: DetailKensakuJyokenVM[] = []
      //左(共通)
      for (const key in leftConditions) {
        if (leftConditions[key] === true) {
          const item = leftList.value.find((el) => el.id === key)
          if (item) {
            const { jyokbn, jyoseq, komokunm1, ctrltype } = item
            if (item.ctrltype === Enumコントローラータイプ.一覧選択) {
              conditionlist.push({ jyokbn, jyoseq, komokunm1, ctrltype, cdlist: leftValues[key] })
            } else if (item.ctrltype === Enumコントローラータイプ.通用項目) {
              conditionlist.push({ jyokbn, jyoseq, komokunm1, ctrltype, itemvm: leftValues[key] })
            }
          }
        }
      }
      //年齢・生年月日
      if (leftAgeItem.value && res_age.status === 'fulfilled') {
        const { jyokbn, jyoseq, komokunm1, ctrltype } = leftAgeItem.value
        //年齢
        if (res_age.value?.type === EnumBirthSearchKbn.年齢 && res_age.value?.basedate) {
          conditionlist.push({ jyokbn, jyoseq, komokunm1, ctrltype, agevm: res_age.value })
        }
        //生年月日
        else if (res_age.value?.type === EnumBirthSearchKbn.生年月日) {
          conditionlist.push({ jyokbn, jyoseq, komokunm1, ctrltype, birthvm: res_age.value })
        }
      }
      // console.log('conditionlist: ', conditionlist)
      return Promise.resolve(conditionlist)
    }
  })
}

defineExpose({
  resetDrawer,
  showDrawer,
  validateDrawer,
  hasCondition
})
</script>
