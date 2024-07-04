<template>
  <a-row :gutter="[8, 8]" class="area-overflow">
    <a-col :md="24" :xl="10" :xxl="8">
      <div class="flex items-center">
        <a-checkbox
          :checked="formData.inputflg"
          :disabled="!(params.edano <= 0 || (route.meta.updflg && editflg))"
          @change="onInputflg"
          >結果情報入力</a-checkbox
        >
        <div>
          <a-button
            :disabled="!formData.inputflg"
            class="ml-3 btn-round"
            type="primary"
            @click="handleCopy"
            >申込情報コピー</a-button
          >
        </div>
      </div>
      <div :class="[canEdit && 'form', 'self_adaption_table  mt-2.5 mb-3']">
        <a-row>
          <a-col span="24">
            <th class="required">事業コード</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.jigyo">
                <ai-select v-model:value="formData.jigyo" :options="formData.jigyolist ?? []" />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.jigyo }} </TD>
          </a-col>
          <a-col span="24">
            <th class="required">実施日</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.jissiymd">
                <date-jp
                  v-model:value="formData.jissiymd"
                  format="YYYY-MM-DD"
                  @change="getAge"
                ></date-jp>
              </a-form-item>
            </td>
            <TD v-else>{{
              formData.jissiymd ? getDateJpText(new Date(formData.jissiymd)) : ''
            }}</TD>
          </a-col>
          <a-col span="24">
            <th class="required">開始時間</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.tmf">
                <a-time-picker v-model:value="formData.tmf" value-format="HHmm" format="HH:mm" />
              </a-form-item>
            </td>
            <TD v-else>{{ formatTime(formData.tmf) }}</TD>
          </a-col>
          <a-col span="24">
            <th>終了時間</th>
            <td v-if="canEdit">
              <a-time-picker
                v-model:value="formData.tmt"
                value-format="HHmm"
                format="HH:mm"
                @change="validate('tmf')"
              />
            </td>
            <TD v-else>{{ formatTime(formData.tmt) }}</TD>
          </a-col>
          <a-col v-if="+params.hokensidokbn === Enum指導区分.個別指導" span="24">
            <th>実施場所</th>
            <td v-if="canEdit">
              <ai-select
                v-model:value="formData.kaijo"
                :options="initdetail?.kaijolist ?? []"
                split-val
              />
            </td>
            <TD v-else>{{ formData.kaijo }}</TD>
          </a-col>
          <a-col span="24">
            <th>実施者</th>
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
            <th>地域保健集計区分</th>
            <td v-if="canEdit">
              <ai-select
                v-model:value="formData.syukeikbn"
                :options="initdetail?.syukeikbnlist ?? []"
              />
            </td>
            <TD v-else>{{ formData.syukeikbn }} </TD>
          </a-col>
          <a-col span="24">
            <th class="bg-readonly">実施日時点年齢</th>
            <TD>{{ age }}</TD>
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
        :syukeikbn="formData.syukeikbn"
      />
    </a-col>
  </a-row>
</template>

<script setup lang="ts">
import { Enum指導区分, Enum申込結果 } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import {
  C011003,
  ITEM_RANGE_ERROR,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR
} from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { formatTime, getDateJpText } from '@/utils/util'
import { Form } from 'ant-design-vue'
import { computed, nextTick, onMounted, reactive, ref, Ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { SearchPersonDetail, GetAge } from '../service'
import {
  FixDispInfoVM,
  FreeItemDispInfoVM,
  InitDetailVM,
  KekkaInfoVM,
  SearchPersonDetailRequest
} from '../type'
import RightTable from './RightTable.vue'
import Tab1 from './Tab1.vue'
import { showConfirmModal } from '@/utils/modal'
import dayjs from 'dayjs'
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const props = defineProps<{
  params: Omit<SearchPersonDetailRequest, keyof DaRequestBase | 'mosikomikekkakbn'>
  initdetail: InitDetailVM | null
  tab1Ref: Ref<InstanceType<typeof Tab1> | null>
  editJudge: Judgement
  loading: boolean
}>()
const emit = defineEmits(['update:loading'])
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const route = useRoute()
const rightTableRef = ref<InstanceType<typeof RightTable> | null>(null)
const grouplist1 = ref<DaSelectorModel[]>([])
const grouplist2 = ref<DaSelectorModel[]>([])

const createDefaultData = (): FixDispInfoVM => {
  return {
    inputflg: false, // 申込情報入力
    jigyo: '', // 事業コード
    jissiymd: '', // 実施日
    tmf: '', // 開始時間
    tmt: '', // 終了時間
    kaijo: '', // 実施場所
    syukeikbn: '', // 地域保健集計区分
    regsisyocd: '',
    regsisyonm: '', // 登録支所
    jigyolist: [],
    syukeikbnlist: [],
    stafflist: [],
    yoteiymd: '',
    yoteitm: ''
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
  ],
  tmf: [
    {
      validator: (_rule, value: string) => {
        if (formData.inputflg) {
          if (!value) {
            return Promise.reject(ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '開始時間'))
          } else {
            if (formData.tmt && value > formData.tmt) {
              return Promise.reject(ITEM_RANGE_ERROR.Msg.replace('{0}', '時間 '))
            }
          }
        }
        return Promise.resolve()
      }
    }
  ],
  jissiymd: [
    { required: formData.inputflg, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '実施日') }
  ]
}))
const { validate, validateInfos, clearValidate } = Form.useForm(formData, rules)
//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(async () => {
  try {
    const res = await SearchPersonDetail({
      ...props.params,
      mosikomikekkakbn: String(Enum申込結果.結果)
    })
    Object.assign(formData, res.personalfixinfo)
    grouplist1.value = res.grouplist1
    grouplist2.value = res.grouplist2
    freeitemlist.value = res.freeitemlist
    editflg.value = res.editflg
    if (res.personalfixinfo.jissiymd) getAge(res.personalfixinfo.jissiymd)
  } catch (error) {}
  nextTick(() => props.editJudge.reset())
  emit('update:loading', false)
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
const getSaveForm = (): KekkaInfoVM => {
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

const handleCopy = () => {
  if (props.tab1Ref.value) {
    const { jigyo, yoteiymd, yoteitm, kaijo, stafflist } = props.tab1Ref.value.getSaveForm()
    Object.assign(formData, {
      jigyo,
      jissiymd: yoteiymd,
      tmf: yoteitm,
      kaijo,
      stafflist
    })
    if (yoteiymd) getAge(yoteiymd)
  }
}

const age = ref()
async function getAge(val?: string) {
  if (val) {
    const res = await GetAge({
      atenano: props.params.atenano,
      yoteiymd: dayjs(val).format('YYYY-MM-DD')
    })
    age.value = res.nenrei
  } else {
    age.value = undefined
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
