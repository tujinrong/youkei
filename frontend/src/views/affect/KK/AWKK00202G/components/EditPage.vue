<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 会場保守
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.02
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card :bordered="false">
    <div class="self_adaption_table form">
      <a-row>
        <a-col :md="12" :xxl="6">
          <th :class="[isNew ? 'bg-editable required' : 'bg-readonly', 'w-30']">会場コード</th>
          <td v-if="isNew">
            <a-form-item v-bind="validateInfos.kaijocd">
              <a-input
                v-model:value="formData.kaijocd"
                :maxlength="7"
                @change="formData.kaijocd = replaceText(formData.kaijocd, EnumRegex.半角英数)"
              ></a-input>
            </a-form-item>
          </td>
          <TD v-else>{{ route.query.kaijocd }}</TD>
        </a-col>
      </a-row>
    </div>
    <div class="m-t-1 flex">
      <a-space>
        <a-button class="warning-btn" :disabled="!canEdit" @click="submitData">登録</a-button>
        <a-button type="primary" @click="goList">一覧へ</a-button>
      </a-space>
      <close-page></close-page>
    </div>
  </a-card>
  <a-card class="my-2" :style="{ minHeight: tableHeight }" :loading="loading">
    <a-checkbox v-model:checked="formData.stopflg" class="mb-1" :disabled="!canEdit">
      利用停止
    </a-checkbox>
    <div :class="[canEdit && 'form', 'self_adaption_table max-w-200']">
      <a-row>
        <a-col span="24">
          <th class="required">会場名</th>
          <td v-if="canEdit">
            <a-form-item v-bind="validateInfos.kaijonm">
              <a-input
                v-model:value="formData.kaijonm"
                maxlength="100"
                allow-clear
                @change="formData.kaijonm = replaceText(formData.kaijonm, EnumRegex.全角)"
              />
            </a-form-item>
          </td>
          <TD v-else>{{ formData.kaijonm }}</TD>
        </a-col>
        <a-col span="24">
          <th class="required">会場名（カナ）</th>
          <td v-if="canEdit">
            <a-form-item v-bind="validateInfos.kanakaijonm">
              <a-input
                v-model:value="formData.kanakaijonm"
                maxlength="100"
                allow-clear
                @change="formData.kanakaijonm = replaceText(formData.kanakaijonm, EnumRegex.カナ)"
              />
            </a-form-item>
          </td>
          <TD v-else>{{ formData.kanakaijonm }}</TD>
        </a-col>
        <a-col span="24">
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
        <a-col span="24">
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
        <a-col span="24">
          <th>会場連絡先</th>
          <td v-if="canEdit">
            <a-input
              v-model:value="formData.kaijorenrakusaki"
              :maxlength="15"
              @change="
                formData.kaijorenrakusaki = replaceText(formData.kaijorenrakusaki, EnumRegex.電話)
              "
            />
          </td>
          <TD v-else>{{ formData.kaijorenrakusaki }}</TD>
        </a-col>
        <a-col v-for="tiku in tikuList" :key="tiku.tikukbn" span="24">
          <th>{{ tiku.tikukbnnm }}</th>
          <td v-if="canEdit">
            <a-select
              v-model:value="tiku.tikucdList"
              mode="multiple"
              class="w-full"
              :options="tiku.tikucdnmList"
              :filter-option="filterOption"
            >
              <template #option="{ label, value }">
                {{ value + ' : ' + label }}
              </template>
            </a-select>
          </td>
          <td v-else class="textarea">{{ tiku.tikucdList.join(',') }}</td>
        </a-col>
      </a-row>
    </div>
  </a-card>
</template>

<script setup lang="ts">
import { EnumRegex, Enum編集区分, PageSatatus } from '#/Enums'
import { onMounted, reactive, ref, watch, nextTick, computed } from 'vue'
import { getHeight } from '@/utils/height'
import { useRoute, useRouter } from 'vue-router'
import { Form, message } from 'ant-design-vue'
import { ITEM_REQUIRE_ERROR, SAVE_OK_INFO } from '@/constants/msg'
import { InitDetail, Save, SearchDetail } from '../service'
import { showSaveModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import { filterOption, replaceText } from '@/utils/util'
import { MainInfoVM, TikuOneInitVM } from '../type'
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

const formData = reactive<MainInfoVM>({
  stopflg: false,
  kaijocd: '',
  kaijonm: '',
  kanakaijonm: '',
  adrs: '',
  katagaki: '',
  kaijorenrakusaki: ''
})
const tikuList = ref<TikuOneInitVM[]>([])

//項目の設定
const rules = reactive({
  kaijocd: [{ required: isNew, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '会場コード') }],
  kaijonm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '会場名') }],
  kanakaijonm: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '会場名（カナ）') }
  ],
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
      tikuList.value = res.tikuList
    } else {
      const res = await SearchDetail({
        kaijocd: route.query.kaijocd as string
      })
      Object.assign(formData, res.mainInfo)
      tikuList.value = res.tikuList
    }
  } catch (error) {}
  nextTick(() => editJudge.reset())
  loading.value = false
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [formData, tikuList.value.map((el) => el.tikucdList)],
  () => editJudge.setEdited(),
  { deep: true }
)
const tableHeight = computed(() => getHeight(175))
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
async function submitData() {
  await validate()
  showSaveModal({
    onOk: async () => {
      const tikulist = tikuList.value.map((el) => {
        return { tikukbn: el.tikukbn, tikucdList: el.tikucdList }
      })
      try {
        await Save({
          tikulist,
          maininfo: formData,
          editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更
        })
        message.success(SAVE_OK_INFO.Msg)
        router.push({ name: route.name as string, query: { refresh: '1' } })
      } catch (error) {}
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
  width: 150px;
}
</style>
