<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 医療機関保守
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.12.6
 * 作成者　　: CNC張加恒
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card ref="headRef" :bordered="false" class="mb-2">
    <div class="self_adaption_table" :class="{ form: isNew }">
      <a-row>
        <a-col :md="12" :xxl="6">
          <th class="required">医療機関コード</th>
          <td v-if="isNew">
            <a-form-item v-bind="validateInfos.kikancd">
              <a-input
                v-model:value="formData.kikancd"
                :maxlength="10"
                @change="formData.kikancd = replaceText(formData.kikancd, EnumRegex.半角英数)"
              ></a-input>
            </a-form-item>
          </td>
          <TD v-else>{{ route.query.kikancd }}</TD>
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
          <template #title><span>医療機関情報</span></template>
          <a-checkbox v-model:checked="formData.stopflg" class="mb-1" :disabled="!canEdit">
            利用停止
          </a-checkbox>
          <div class="self_adaption_table" :class="{ form: canEdit }">
            <a-row>
              <a-col :md="24" :lg="24" :xxl="18">
                <th class="required">保険医療機関コード</th>
                <td v-if="canEdit">
                  <a-form-item v-bind="validateInfos.hokenkikancd">
                    <a-input
                      v-model:value="formData.hokenkikancd"
                      maxlength="10"
                      allow-clear
                      @change="
                        formData.hokenkikancd = replaceText(
                          formData.hokenkikancd,
                          EnumRegex.半角英数
                        )
                      "
                    />
                  </a-form-item>
                </td>
                <TD v-else>{{ formData.hokenkikancd }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :md="24" :lg="24" :xxl="18">
                <th class="required">医療機関名カナ</th>
                <td v-if="canEdit">
                  <a-form-item v-bind="validateInfos.kanakikannm">
                    <a-input
                      v-model:value="formData.kanakikannm"
                      maxlength="100"
                      allow-clear
                      @change="
                        formData.kanakikannm = replaceText(formData.kanakikannm, EnumRegex.カナ)
                      "
                    />
                  </a-form-item>
                </td>
                <TD v-else>{{ formData.kanakikannm }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :md="24" :lg="24" :xxl="18">
                <th class="required">医療機関名</th>
                <td v-if="canEdit">
                  <a-form-item v-bind="validateInfos.kikannm">
                    <a-input
                      v-model:value="formData.kikannm"
                      maxlength="40"
                      allow-clear
                      @change="formData.kikannm = replaceText(formData.kikannm, EnumRegex.全角)"
                    />
                  </a-form-item>
                </td>
                <TD v-else>{{ formData.kikannm }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :md="24" :lg="24" :xxl="18">
                <th class="required">郵便番号</th>
                <td v-if="canEdit">
                  <a-form-item v-bind="validateInfos.yubin">
                    <a-input
                      v-model:value="formData.yubin"
                      maxlength="7"
                      allow-clear
                      @change="formData.yubin = replaceText(formData.yubin, EnumRegex.半角数字)"
                    />
                  </a-form-item>
                </td>
                <TD v-else>{{ formData.yubin }}</TD>
              </a-col> </a-row
            ><a-row>
              <a-col :md="24" :lg="24" :xxl="18">
                <th class="required">住所</th>
                <td v-if="canEdit">
                  <a-form-item v-bind="validateInfos.adrs">
                    <a-input
                      v-model:value="formData.adrs"
                      maxlength="84"
                      allow-clear
                      @change="formData.adrs = replaceText(formData.adrs, EnumRegex.全角)"
                    />
                  </a-form-item>
                </td>
                <TD v-else>{{ formData.adrs }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :md="24" :lg="24" :xxl="18">
                <th>方書</th>
                <td v-if="canEdit">
                  <a-textarea
                    v-model:value="formData.katagaki"
                    maxlength="300"
                    auto-size
                    @change="formData.katagaki = replaceText(formData.katagaki, EnumRegex.全角)"
                  />
                </td>
                <TD v-else>{{ formData.katagaki }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :md="24" :lg="24" :xxl="18">
                <th>電話番号</th>
                <td v-if="canEdit">
                  <a-input
                    v-model:value="formData.tel"
                    :maxlength="15"
                    @change="formData.tel = replaceText(formData.tel, EnumRegex.電話)"
                  />
                </td>
                <TD v-else>{{ formData.tel }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :md="24" :lg="24" :xxl="18">
                <th>FAX番号</th>
                <td v-if="canEdit">
                  <a-input
                    v-model:value="formData.fax"
                    :maxlength="15"
                    @change="formData.fax = replaceText(formData.fax, EnumRegex.電話)"
                  />
                </td>
                <TD v-else>{{ formData.fax }}</TD>
              </a-col>
            </a-row>
            <a-row>
              <a-col :md="24" :lg="24" :xxl="18">
                <th>所属医師会</th>
                <td v-if="canEdit">
                  <ai-select
                    v-model:value="formData.syozokuisikai"
                    style="width: 100%"
                    :options="syozokuisikaiList"
                    split-val
                  >
                  </ai-select>
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
                v-model:value="filterParams.hanyokbn1"
                class="custom-select"
                split-val
                :options="gyoSelectorList"
              ></ai-select>
              <a-button type="primary" @click="selectOrclearAll(true)">全選択</a-button>
              <a-button type="primary" @click="selectOrclearAll(false)">全解除</a-button></a-space
            >
            <div class="checkbox mt-2" :style="{ height: tableHeight + 'px' }">
              <div v-for="(item, index) in filterData" :key="index">
                <a-checkbox v-model:checked="item.checkflg" :value="item.jissijigyo">{{
                  item.jissijigyonm
                }}</a-checkbox>
              </div>
            </div>
          </div>
        </a-card>
      </a-col>
    </a-row>
  </div>
</template>

<script setup lang="ts">
import { EnumRegex, Enum編集区分, PageSatatus } from '#/Enums'
import { onMounted, reactive, ref, watch, nextTick } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Form, message } from 'ant-design-vue'
import { ITEM_REQUIRE_ERROR, SAVE_OK_INFO } from '@/constants/msg'
import { InitDetail, Save, SearchDetail } from '../service'
import { showSaveModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import { replaceText } from '@/utils/util'
import { MainInfoVM, JissijigyoOneInitVM } from '../type'
import { useTableFilter, useTableHeight } from '@/utils/hooks'
import TD from '@/components/Common/TableTD/index.vue'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  status: PageSatatus
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const loading = ref(true)
const editJudge = new Judgement(route.name as string)
const isNew = props.status === PageSatatus.New
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, -54)

const formData = reactive<MainInfoVM>({
  stopflg: false,
  kikancd: '',
  hokenkikancd: '',
  kanakikannm: '',
  kikannm: '',
  tel: '',
  yubin: '',
  adrs: '',
  fax: '',
  katagaki: '',
  syozokuisikai: ''
})
//実施事業リスト
const jigyoSelectorList = ref<JissijigyoOneInitVM[]>([])
//所属医師会リスト
const syozokuisikaiList = ref<DaSelectorModel[]>([])

const gyoSelectorList = ref<DaSelectorModel[]>([
  { label: 'すべて', value: '', disabled: undefined }
])
const filterParams = reactive({
  hanyokbn1: ''
})
let { filterData } = useTableFilter(jigyoSelectorList, filterParams)
//項目の設定
const rules = reactive({
  kikancd: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '医療機関コード') }],
  hokenkikancd: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '保険医療機関コード') }
  ],
  kikannm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '医療機関名') }],
  kanakikannm: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '医療機関名（カナ）') }
  ],
  yubin: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '郵便番号') }],
  adrs: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '住所') }]
})
const { validate, validateInfos } = Form.useForm(formData, rules)

//操作権限フラグ
const canEdit = isNew || route.meta.updflg

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  editJudge.addEvent()
  loading.value = true
  try {
    if (isNew) {
      const res = await InitDetail()
      jigyoSelectorList.value = res.jissijigyoList
      syozokuisikaiList.value = res.syozokuisikaiList
      gyoSelectorList.value.push(...res.gyoSelectorList)
    } else {
      const res = await SearchDetail({
        kikancd: route.query.kikancd as string
      })
      Object.assign(formData, res.mainInfo)
      jigyoSelectorList.value = res.jissijigyoSelectorList
      syozokuisikaiList.value = res.syozokuisikaiList
      gyoSelectorList.value.push(...res.gyoSelectorList)
    }
  } catch (error) {}
  nextTick(() => editJudge.reset())
  loading.value = false
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(formData, () => editJudge.setEdited())

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
async function submitData() {
  await validate()
  showSaveModal({
    onOk: async () => {
      await Save({
        maininfo: formData,
        jissijigyoSelectorList: jigyoSelectorList.value,
        editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更
      })
      message.success(SAVE_OK_INFO.Msg)
      router.push({ name: route.name as string, query: { refresh: '1' } })
    }
  })
}

//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    router.push({ name: route.name as string })
  })
}
// 全選択 全解除
const selectOrclearAll = (flag: boolean) => {
  filterData.value.forEach((item) => (item.checkflg = flag))
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
.checkbox div {
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
