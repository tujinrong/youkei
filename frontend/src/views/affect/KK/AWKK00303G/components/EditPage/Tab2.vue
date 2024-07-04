<template>
  <a-row :gutter="[8, 8]" class="area-overflow">
    <a-col :md="24" :xl="10" :xxl="8">
      <div class="flex items-center">
        <a-checkbox
          :checked="formData.inputflg"
          :disabled="!(+edano <= 0 || (route.meta.updflg && editflg))"
          @change="changeInputflg"
          >結果情報入力</a-checkbox
        >
        <a-button
          :disabled="!formData.inputflg || !inputflg1"
          class="ml-3 btn-round"
          type="primary"
          @click="handleCopy"
          >申込情報コピー</a-button
        >
      </div>
      <div :class="[canEdit && 'form', 'self_adaption_table  mt-2.5 mb-3']">
        <a-row>
          <a-col span="24">
            <th class="required">事業コード</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.jigyo">
                <ai-select v-model:value="formData.jigyo" :options="initdetail?.jigyolist ?? []" />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.jigyo }}</TD>
          </a-col>
          <a-col span="24">
            <th class="required">実施日</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.jissiymd">
                <date-jp v-model:value="formData.jissiymd" format="YYYY-MM-DD"></date-jp>
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
          <a-col span="24">
            <th>実施場所</th>
            <td v-if="canEdit">
              <ai-select v-model:value="formData.kaijo" :options="initdetail?.kaijolist ?? []" />
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
                :field-names="{ label: 'staffsimei', value: 'staffid' }"
                allow-clear
                @change="(_val, opt) => (formData.stafflist = opt)"
              >
                <template #option="{ staffsimei, staffid }">
                  {{ staffid + ' : ' + staffsimei }}
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
            <TD v-else>{{ formData.syukeikbn }}</TD>
          </a-col>
          <a-col span="24">
            <th class="bg-readonly">登録支所</th>
            <TD>{{ formData.regsisyonm }}</TD>
          </a-col>
        </a-row>
      </div>
    </a-col>
    <a-col v-bind="{ md: 24, xl: 14, xxl: 16 }" class="h-full">
      <RightTable
        ref="rightTableRef"
        :table-data="freeitemlist"
        v-bind="{
          canEdit,
          grouplist1,
          grouplist2,
          syukeikbn: formData.syukeikbn
        }"
      />
    </a-col>
  </a-row>
</template>

<script setup lang="ts">
import { ref, reactive, computed, onMounted, watch, nextTick, Ref } from 'vue'
import { Form } from 'ant-design-vue'
import { useRoute } from 'vue-router'
import { FreeItemDispInfoVM, InitDetailVM, JigyoFixInfoVM, KekkaSaveVM } from '../../type'
import { SearchDetail } from '../../service'
import {
  C011003,
  ITEM_RANGE_ERROR,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR
} from '@/constants/msg'
import { Enum申込結果参加者 } from '#/Enums'
import { getDateJpText, formatTime } from '@/utils/util'
import TD from '@/components/Common/TableTD/index.vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import RightTable from '@/views/affect/KK/AWKK00301G/components/RightTable.vue'
import { Judgement } from '@/utils/judge-edited'
import Tab1 from './Tab1.vue'
import { showConfirmModal } from '@/utils/modal'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  initdetail: InitDetailVM | null
  editJudge: Judgement
  tab1Ref: Ref<InstanceType<typeof Tab1> | null>
}>()

const route = useRoute()
const edano = route.query.edano as string
const gyomu = route.query.gyomu as string

//操作権限フラグ
const canEdit = computed(() =>
  Boolean((+edano <= 0 || (route.meta.updflg && editflg.value)) && formData.inputflg)
)

const grouplist1 = ref<DaSelectorModel[]>([])
const grouplist2 = ref<DaSelectorModel[]>([])

const createDefaultData = (): JigyoFixInfoVM => {
  return {
    yoteiymd: '',
    yoteitm: '',
    syukeikbn: '',
    jissiymd: '',
    tmf: '',
    tmt: '',
    inputflg: false,
    jigyolist: [],
    jigyo: '',
    kaijo: '',
    stafflist: [],
    regsisyocd: '',
    regsisyonm: ''
  }
}
const formData = reactive<JigyoFixInfoVM>(createDefaultData())
const freeitemlist = ref<FreeItemDispInfoVM[]>([])
const rightTableRef = ref<InstanceType<typeof RightTable> | null>(null)
/**支所編集可能フラグ */
const editflg = ref(true)

const inputflg1 = computed(() => {
  return props.tab1Ref.value?.inputflg1
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//項目の設定
const rules = computed(() => ({
  jigyo: [
    { required: formData.inputflg, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '事業コード') }
  ],
  jissiymd: [
    { required: formData.inputflg, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '実施日') }
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
  ]
}))

const { validate, validateInfos, clearValidate } = Form.useForm(formData, rules)

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  SearchDetail({
    gyomukbn: gyomu,
    edano: +edano,
    mosikomikekkakbn: Enum申込結果参加者.結果.toString()
  }).then((res) => {
    Object.assign(formData, res.fixinfo)
    grouplist1.value = res.grouplist1
    grouplist2.value = res.grouplist2
    freeitemlist.value = res.freeitemlist
    editflg.value = res.editflg
    nextTick(() => props.editJudge.reset())
  })
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
//データコピー
const handleCopy = () => {
  if (props.tab1Ref.value) {
    const { jigyo, yoteiymd, yoteitm, kaijo, stafflist } = props.tab1Ref.value.getSaveForm()
    Object.assign(formData, {
      jigyo: jigyo,
      jissiymd: yoteiymd,
      tmf: yoteitm,
      kaijo: kaijo,
      stafflist: stafflist
    })
  }
}

const changeInputflg = (e) => {
  if (formData.inputflg) {
    showConfirmModal({
      content: C011003.Msg,
      onOk() {
        formData.inputflg = e.target.checked
      }
    })
  } else {
    formData.inputflg = e.target.checked
  }

  clearValidate()
}

//データセーブ
const getSaveForm = (): KekkaSaveVM => {
  return {
    ...formData,
    jigyolist: undefined,
    freeiteminfo: freeitemlist.value.map((el) => ({
      inputtype: el.inputtypekbn,
      item: el.itemcd,
      value: el.value
    }))
  }
}

defineExpose({
  validate() {
    return Promise.all([validate(), formData.inputflg && rightTableRef.value?.validate()])
  },
  getSaveForm
})
</script>

<style scoped lang="less">
th {
  width: 130px;
}
</style>
