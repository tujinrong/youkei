<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業従事者（担当者）保守(詳細画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.12.11
 * 作成者　　: 高智輝
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false" class="mb-2">
      <div class="self_adaption_table" :class="{ form: isNew }">
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th class="required">事業従業者ID</th>
            <td v-if="isNew">
              <a-form-item v-bind="validateInfos.staffid">
                <a-input
                  v-model:value="formData.staffid"
                  maxlength="10"
                  allow-clear
                  @change="formData.staffid = replaceText(formData.staffid, EnumRegex.半角英数)"
                ></a-input>
              </a-form-item>
            </td>
            <TD v-else>{{ route.query.staffid }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 header_operation">
        <a-space>
          <a-button class="warning-btn" :disabled="!canEdit" @click="submitData">登録</a-button>
          <a-button type="primary" @click="goList">一覧へ</a-button>
        </a-space>
        <close-page></close-page>
      </div>
    </a-card>
    <div>
      <a-row :gutter="8">
        <a-col :span="12">
          <a-card class="min-h-full" :loading="loading">
            <template #title><span>事業従事者（担当者）情報</span></template>
            <a-checkbox v-model:checked="formData.stopflg" class="mb-1" :disabled="!canEdit">
              利用停止
            </a-checkbox>
            <div class="self_adaption_table" :class="{ form: canEdit }">
              <a-row>
                <a-col :md="24" :lg="24" :xxl="18">
                  <th class="required">事業従事者名</th>
                  <td v-if="canEdit">
                    <a-form-item v-bind="validateInfos.staffsimei">
                      <a-input
                        v-model:value="formData.staffsimei"
                        maxlength="100"
                        allow-clear
                        @change="
                          formData.staffsimei = replaceText(formData.staffsimei, EnumRegex.全角)
                        "
                      ></a-input>
                    </a-form-item>
                  </td>
                  <TD v-else>{{ formData.staffsimei }}</TD>
                </a-col>
              </a-row>
              <a-row>
                <a-col :md="24" :lg="24" :xxl="18">
                  <th class="required">事業従事者カナ氏名</th>
                  <td v-if="canEdit">
                    <a-form-item v-bind="validateInfos.kanastaffsimei">
                      <a-input
                        v-model:value="formData.kanastaffsimei"
                        maxlength="100"
                        allow-clear
                        @change="
                          formData.kanastaffsimei = replaceText(
                            formData.kanastaffsimei,
                            EnumRegex.カナ氏名
                          )
                        "
                      ></a-input>
                    </a-form-item>
                  </td>
                  <TD v-else>{{ formData.kanastaffsimei }}</TD>
                </a-col>
              </a-row>
              <a-row>
                <a-col :md="24" :lg="24" :xxl="18">
                  <th>医療機関</th>
                  <td>
                    <a-form-item v-bind="validateInfos.kikanlist">
                      <a-select v-model:value="selectedKikan" allow-clear mode="multiple"
                        ><a-select-option
                          v-for="item in filterkikanSelectorList"
                          :key="item"
                          :value="item.value"
                        >
                          {{ item.label }}
                        </a-select-option></a-select
                      >
                    </a-form-item>
                  </td>
                </a-col>
              </a-row>
              <a-row>
                <a-col :md="24" :lg="24" :xxl="18">
                  <th class="required">職種</th>
                  <td>
                    <a-form-item v-bind="validateInfos.syokusyu">
                      <ai-select
                        v-model:value="formData.syokusyu"
                        allow-clear
                        split-val
                        :options="syokusyunmSelectorList"
                      ></ai-select>
                    </a-form-item>
                  </td>
                </a-col>
              </a-row>
              <a-row>
                <a-col :md="24" :lg="24" :xxl="18">
                  <th class="required">活動区分</th>
                  <td>
                    <a-form-item v-bind="validateInfos.katudokbn">
                      <ai-select
                        v-model:value="formData.katudokbn"
                        allow-clear
                        split-val
                        :options="katudokbnnmSelectorList"
                      ></ai-select>
                    </a-form-item>
                  </td>
                </a-col>
              </a-row>
            </div>
          </a-card>
        </a-col>
        <a-col :span="12">
          <a-card :loading="loading">
            <template #title><span>実施事業</span></template>
            <div>
              <a-space
                ><ai-select
                  v-model:value="select"
                  class="custom-select"
                  split-val
                  :options="gyoSelectorList"
                ></ai-select>
                <a-button type="primary" @click="selectAllCheckboxes">全選択</a-button>
                <a-button type="primary" @click="deselectAllCheckboxes">全解除</a-button></a-space
              >
              <div class="checkbox mt-2" :style="{ height: tableHeight + 'px' }">
                <div v-for="item in jissijigyoSelectorList" :key="item.jissijigyo">
                  <a-checkbox
                    v-show="showjissijigyo(item)"
                    v-model:checked="item.checkflg"
                    :value="item.jissijigyo"
                    >{{ item.jissijigyonm }}</a-checkbox
                  >
                </div>
              </div>
            </div>
          </a-card>
        </a-col>
      </a-row>
    </div></a-spin
  >
</template>

<script setup lang="ts">
import { EnumRegex, Enum編集区分, PageSatatus } from '#/Enums'
import { onMounted, reactive, ref, watch, nextTick, computed } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Form, message } from 'ant-design-vue'
import { ITEM_SELECTREQUIRE_ERROR, SAVE_OK_INFO } from '@/constants/msg'
import { InitList, Save, SearchDetail } from '../service'
import { showSaveModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import TD from '@/components/Common/TableTD/index.vue'
import { replaceText } from '@/utils/util'
import { JissijigyoModel, MainInfoVM } from '../type'
import { useTableHeight } from '@/utils/hooks'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  status: PageSatatus
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(true)
const editJudge = new Judgement(route.name as string)
const isNew = props.status === PageSatatus.New
const formData = reactive<MainInfoVM>({
  staffid: '',
  staffsimei: '',
  kanastaffsimei: '',
  stopflg: false,
  syokusyu: '',
  katudokbn: ''
})
const kikanlist = ref<string[]>([])
const kikanSelectorList = ref<DaSelectorKeyModel[]>([])
const syokusyunmSelectorList = ref<DaSelectorModel[]>([])
const katudokbnnmSelectorList = ref<DaSelectorModel[]>([])
const gyoSelectorList = ref<DaSelectorModel[]>([
  { label: 'すべて', value: '', disabled: undefined }
])
const jissijigyoSelectorList = ref<JissijigyoModel[]>([])
const rules = reactive({
  staffid: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '事業従業者ID') }
  ],
  staffsimei: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '事業従事者名') }
  ],
  kanastaffsimei: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '事業従事者カナ氏名') }
  ],
  syokusyu: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '職種') }],
  katudokbn: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '活動区分') }]
})
const { validate, validateInfos } = Form.useForm(formData, rules)
const select = ref('すべて')
let upddttm
//操作権限フラグ
const canEdit = isNew || route.meta.updflg
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
watch(kikanlist.value, () => {
  console.log(kikanlist.value)
})
onMounted(async () => {
  editJudge.addEvent()
  InitList().then((res) => {
    syokusyunmSelectorList.value = res.syokusyunmSelectorList
    katudokbnnmSelectorList.value = res.katudokbnnmSelectorList
  })
  try {
    const res = await SearchDetail({
      staffid: route.query.staffid as string,
      editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更
    })
    Object.assign(formData, res.mainInfo)
    upddttm = res.upddttm
    kikanlist.value = res.kikanlist || undefined
    jissijigyoSelectorList.value = res.jissijigyoSelectorList
    kikanSelectorList.value = res.kikanSelectorList
    gyoSelectorList.value.push(...res.gyoSelectorList)
    nextTick(() => editJudge.reset())
  } catch (error) {}

  loading.value = false
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, -54)

const filterkikanSelectorList = computed(() => {
  return kikanSelectorList.value.filter((item) => item.key === '1')
})

//Kikan判断
const selectedKikan = computed({
  get: () => {
    if (kikanlist.value) {
      return kikanlist.value.map((value) => {
        const option = filterkikanSelectorList.value.find((item) => item.value === value)
        return option ? value : kikanSelectorList.value.find((item) => item.value === value)!.label
      })
    }
    return kikanlist.value
  },
  set: (value) => {
    kikanlist.value = value.map((label) => {
      const option = kikanSelectorList.value.find((item) => item.label === label)
      return option ? option.value : label
    })
  }
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch([formData, kikanlist, jissijigyoSelectorList], () => editJudge.setEdited(), {
  deep: true
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
async function submitData() {
  await validate()
  showSaveModal({
    onOk: async () => {
      await Save({
        mainInfo: formData,
        kikanlist: kikanlist.value,
        jissijigyoSelectorList: jissijigyoSelectorList.value,
        editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
        upddttm: isNew ? undefined : upddttm
      })
      message.success(SAVE_OK_INFO.Msg)
      router.push({ name: route.name as string, query: { refresh: '1' } })
    }
  })
}
function showjissijigyo(item) {
  return (
    select.value == '' ||
    select.value.indexOf('すべて') > -1 ||
    select.value.indexOf(item.hanyokbn1) > -1
  )
}
function selectAllCheckboxes() {
  // 全選択
  jissijigyoSelectorList.value.forEach((item) => {
    if (showjissijigyo(item)) {
      item.checkflg = true
    }
  })
}
function deselectAllCheckboxes() {
  // 全解除
  jissijigyoSelectorList.value.forEach((item) => {
    if (showjissijigyo(item)) {
      item.checkflg = false
    }
  })
}
//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    router.push({ name: route.name as string })
  })
}
</script>

<style scoped lang="less">
.self_adaption_table th {
  width: 160px;
}
.checkbox {
  border: 1px solid #ccc;
  overflow-y: auto;
  padding: 8px;
}
.checkbox > div {
  margin-bottom: 1.2em;
}
.custom-select {
  width: 300px;

  @media screen and (max-width: 1920px) {
    width: 300px;
  }

  @media screen and (max-width: 1280px) {
    max-width: 250px;
  }

  @media screen and (max-width: 768px) {
    max-width: 200px;
  }
}
</style>
