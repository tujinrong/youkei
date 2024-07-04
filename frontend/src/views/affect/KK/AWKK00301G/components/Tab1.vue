<template>
  <a-row :gutter="[8, 8]" class="area-overflow">
    <a-col :md="24" :xl="10" :xxl="8">
      <a-checkbox
        :checked="formData.inputflg"
        :disabled="!(params.edano <= 0 || (route.meta.updflg && editflg))"
        @change="onInputflg"
        >申込情報入力</a-checkbox
      >
      <div :class="[canEdit && 'form', 'self_adaption_table  mt-5 mb-3']">
        <a-row>
          <a-col span="24">
            <th class="required">事業コード</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.jigyo">
                <ai-select v-model:value="formData.jigyo" :options="formData.jigyolist ?? []">
                </ai-select>
              </a-form-item>
            </td>
            <TD v-else>{{ formData.jigyo }} </TD>
          </a-col>
          <a-col span="24">
            <th>実施予定日</th>
            <td v-if="canEdit">
              <date-jp v-model:value="formData.yoteiymd" format="YYYY-MM-DD"></date-jp>
            </td>
            <TD v-else>{{
              formData.yoteiymd ? getDateJpText(new Date(formData.yoteiymd)) : ''
            }}</TD>
          </a-col>
          <a-col span="24">
            <th>予定開始時間</th>
            <td v-if="canEdit">
              <a-time-picker v-model:value="formData.yoteitm" value-format="HHmm" format="HH:mm" />
            </td>
            <TD v-else>{{ formatTime(formData.yoteitm) }}</TD>
          </a-col>
          <a-col v-if="+params.hokensidokbn === Enum指導区分.個別指導" span="24">
            <th>実施場所</th>
            <td v-if="canEdit">
              <a-select
                v-model:value="formData.kaijo"
                style="width: 100%"
                :options="initdetail?.kaijolist ?? []"
              />
            </td>
            <TD v-else>{{ formData.kaijo }}</TD>
          </a-col>
          <a-col span="24">
            <th>予定者</th>
            <td v-if="canEdit">
              <a-select
                :value="formData.stafflist?.map((i) => i.staffid)"
                mode="multiple"
                style="width: 100%"
                :options="initdetail?.stafflist ?? []"
                allow-clear
                @change="
                  (_val, opt:DaSelectorModel[]) =>
                    (formData.stafflist = opt.map((i) => {
                      return { staffid: i.value, staffsimei: i.label }
                    }))
                "
              >
                <template #option="{ value, label }">
                  {{ value + ' : ' + label }}
                </template>
              </a-select>
            </td>
            <td v-else class="textarea">
              {{ formData.stafflist?.map((el) => el.staffsimei).join(',') }}
            </td>
          </a-col>
          <a-col span="24">
            <th class="bg-readonly">登録支所</th>
            <TD>{{ formData.regsisyonm }}</TD>
          </a-col>
        </a-row>
      </div>
    </a-col>
    <a-col :md="24" :xl="14" :xxl="16" class="h-full">
      <RightTable
        ref="rightTableRef"
        :table-data="freeitemlist"
        v-bind="{
          canEdit,
          grouplist1,
          grouplist2
        }"
      />
    </a-col>
  </a-row>
</template>

<script setup lang="ts">
import { Enum指導区分, Enum申込結果 } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { C011003, ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { formatTime, getDateJpText } from '@/utils/util'
import { Form } from 'ant-design-vue'
import { computed, nextTick, onMounted, reactive, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { SearchPersonDetail } from '../service'
import {
  FixDispInfoVM,
  FreeItemDispInfoVM,
  InitDetailVM,
  MosikomiInfoVM,
  SearchPersonDetailRequest
} from '../type'
import RightTable from './RightTable.vue'
import { showConfirmModal } from '@/utils/modal'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  params: Omit<SearchPersonDetailRequest, keyof DaRequestBase | 'mosikomikekkakbn'>
  initdetail: InitDetailVM | null
  editJudge: Judgement
  loading: boolean
}>()
const emit = defineEmits(['update:loading', 'emitHeaderinfo'])
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const route = useRoute()
const grouplist1 = ref<DaSelectorModel[]>([])
const grouplist2 = ref<DaSelectorModel[]>([])
const rightTableRef = ref<InstanceType<typeof RightTable> | null>(null)

const createDefaultData = (): FixDispInfoVM => {
  return {
    inputflg: false, // 申込情報入力
    jigyo: '', // 事業コード
    yoteiymd: '', // 実施予定日
    yoteitm: '', // 予定開始時間
    kaijo: '', // 実施場所
    regsisyocd: '',
    regsisyonm: '', // 登録支所
    jissiymd: '',
    tmf: '',
    tmt: '',
    syukeikbn: '',
    jigyolist: [],
    syukeikbnlist: [],
    stafflist: []
  }
}
const formData = reactive(createDefaultData())
const freeitemlist = ref<FreeItemDispInfoVM[]>([])
/**支所編集可能フラグ */
const editflg = ref(true)
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//操作権限フラグ
const canEdit = computed(() =>
  Boolean((props.params.edano <= 0 || (route.meta.updflg && editflg.value)) && formData.inputflg)
)
//項目の設定
const rules = computed(() => ({
  jigyo: [
    { required: formData.inputflg, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '事業コード') }
  ]
}))
const { validate, validateInfos } = Form.useForm(formData, rules)
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(() => {
  SearchPersonDetail({
    ...props.params,
    mosikomikekkakbn: String(Enum申込結果.申込)
  })
    .then((res) => {
      Object.assign(formData, res.personalfixinfo)
      grouplist1.value = res.grouplist1
      grouplist2.value = res.grouplist2
      freeitemlist.value = res.freeitemlist
      editflg.value = res.editflg
      emit('emitHeaderinfo', res.personalheaderinfo)
      nextTick(() => props.editJudge.reset())
    })
    .finally(() => emit('update:loading', false))
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [formData, freeitemlist.value.map((el) => el.value)],
  () => props.editJudge.setEdited(),
  { deep: true }
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const getSaveForm = (): MosikomiInfoVM => {
  return {
    ...formData,
    syukeikbnlist: undefined,
    freeiteminfo: freeitemlist.value.map((el) => ({
      inputtype: el.inputtypekbn,
      item: el.itemcd,
      value: el.value
    }))
  }
}

const onInputflg = (e) => {
  if (props.params.edano > 0 && formData.inputflg) {
    showConfirmModal({
      content: C011003.Msg,
      onOk() {
        formData.inputflg = e.target.checked
      }
    })
  } else {
    formData.inputflg = e.target.checked
  }
}

defineExpose({
  validate() {
    return Promise.all([validate(), formData.inputflg && rightTableRef.value?.validate()])
  },
  getSaveForm
})
</script>

<style lang="less" scoped src="./tab.less"></style>
