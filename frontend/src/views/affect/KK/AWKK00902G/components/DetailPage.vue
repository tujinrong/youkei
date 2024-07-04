<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 事業予約希望者管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.03.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table">
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>業務</th>
            <TD>{{ headerInfo?.gyomukbnnm }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>日程番号</th>
            <TD>{{ nitteino }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>事業名</th>
            <TD>{{ headerInfo?.jigyonm }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>実施内容</th>
            <TD>{{ headerInfo?.jissinaiyo }}</TD>
          </a-col>
          <a-col v-show="courseno" :md="12" :lg="8" :xxl="6">
            <th>コース番号</th>
            <TD>{{ headerInfo?.courseno }}</TD>
          </a-col>
          <a-col v-show="courseno" :md="12" :lg="8" :xxl="6">
            <th>コース名</th>
            <TD>{{ headerInfo?.coursenm }}</TD>
          </a-col>
          <a-col v-show="courseno" :md="12" :lg="8" :xxl="6">
            <th>回数</th>
            <TD>{{ headerInfo?.kaisu }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>実施予定日</th>
            <TD>{{
              headerInfo?.jissiyoteiymd ? getDateJpText(new Date(headerInfo.jissiyoteiymd)) : ''
            }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>開始時間</th>
            <TD>{{ headerInfo?.tmf }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>終了時間</th>
            <TD>{{ headerInfo?.tmt }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>会場</th>
            <TD>{{ headerInfo?.kaijonm }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>医療機関</th>
            <TD>{{ headerInfo?.kikannm }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>担当者</th>
            <TD>{{ headerInfo?.staffnms }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="mt-2 flex justify-between">
        <a-space>
          <a-button type="warn" :disabled="!canEdit" @click="checkSave">登録</a-button>
          <a-button type="primary" :disabled="!canDelete" danger @click="deleteData">削除</a-button>
          <a-button type="primary" @click="back2list">一覧へ</a-button>
        </a-space>
        <a-space>
          <WarnAlert v-if="personInfo?.keikoku" />
          <close-page />
        </a-space>
      </div>
    </a-card>

    <a-card
      class="my-2"
      :style="{ minHeight: tableHeight + 'px', marginBottom: height + 8 + 'px' }"
      :loading="loading"
    >
      <div class="self_adaption_table" :class="canEdit && 'form'">
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th class="bg-readonly">予約番号</th>
            <TD v-if="!isNew">{{ formData.yoyakuno }}</TD>
            <TD v-else></TD>
          </a-col>
        </a-row>
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th class="bg-readonly">宛名番号</th>
            <TD>{{ route.query.atenano }}</TD>
          </a-col>
          <a-col :md="8" :xl="4" :xxl="4">
            <th>待機</th>
            <td class="pl-2!">
              <a-checkbox v-model:checked="formData.taikiflg" :disabled="!canEdit" />
            </td>
          </a-col>
        </a-row>
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th class="bg-readonly">氏名</th>
            <TD>{{ personInfo?.name }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th class="bg-readonly">カナ氏名</th>
            <TD>{{ personInfo?.kname }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th class="bg-readonly">生年月日</th>
            <TD>{{ personInfo?.bymd }}</TD>
          </a-col>

          <a-col :md="12" :xl="6">
            <th class="bg-readonly">性別</th>
            <TD>{{ personInfo?.sex }}</TD>
          </a-col>
          <a-col :md="12" :xl="6">
            <th class="bg-readonly">住民区分</th>
            <TD>{{ personInfo?.juminkbn }}</TD>
          </a-col>
          <a-col :md="12" :xl="6">
            <th class="bg-readonly">年齢</th>
            <TD>{{ personInfo?.age }}</TD>
          </a-col>
          <a-col :md="12" :xl="6">
            <th class="bg-readonly">年齢計算基準日</th>
            <TD>{{ personInfo?.agekijunymd }}</TD>
          </a-col>

          <a-col span="24">
            <th class="bg-readonly">住所</th>
            <TD>{{ personInfo?.adrs }}</TD>
          </a-col>

          <a-col :md="12" :lg="8" :xxl="6">
            <th>受診金額</th>
            <td v-if="canEdit">
              <a-input-number
                v-model:value="formData.jusinkingaku"
                :min="0"
                :max="999999999"
                :precision="0"
                :formatter="(value) => `${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ',')"
                :parser="(value) => value.replace(/\$\s?|(,*)/g, '')"
                class="w-full"
              ></a-input-number>
            </td>
            <TD v-else>{{ formatKingaku(formData.jusinkingaku) }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th class="w-38!">金額(市区町村負担)</th>
            <td v-if="canEdit">
              <a-input-number
                v-model:value="formData.kingaku_sityosonhutan"
                :min="0"
                :max="999999999"
                :precision="0"
                :formatter="(value) => `${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ',')"
                :parser="(value) => value.replace(/(,*)/g, '')"
                class="w-full"
              ></a-input-number>
            </td>
            <TD v-else>{{ formatKingaku(formData.kingaku_sityosonhutan) }}</TD>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th>初回受付日</th>
            <td v-if="canEdit">
              <DateJp
                v-model:value="formData.syokaiuketukeymd"
                style="max-width: 190px"
                format="YYYY-MM-DD"
              />
            </td>
            <TD v-else>{{
              formData.syokaiuketukeymd ? getDateJpText(new Date(formData.syokaiuketukeymd)) : ''
            }}</TD>
          </a-col>

          <a-col span="24">
            <th>備考</th>
            <td v-if="canEdit">
              <a-textarea
                v-model:value="formData.biko"
                :maxlength="300"
                :auto-size="{ minRows: 2 }"
              ></a-textarea>
            </td>
            <td v-else class="textarea">{{ formData.biko }}</td>
          </a-col>
        </a-row>
      </div>
    </a-card>
    <OperationFooter ref="footerRef" />
    <CheckModal v-model:visible="visible" :ok1="onCheckOK1" :ok2="onCheckOK2" />
  </a-spin>
</template>

<script lang="ts" setup>
import TD from '@/components/Common/TableTD/index.vue'
import { computed, onMounted, ref, reactive, watch, nextTick } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Check, DeleteDetail, InitDetail, Save } from '../service'
import { DetailVM, PersonHeaderVM } from '../type'
import OperationFooter from '@/views/affect/AF/AWAF00603S/index.vue'
import { useElementSize } from '@vueuse/core'
import { useTableHeight } from '@/utils/hooks'
import { getDateJpText } from '@/utils/util'
import CheckModal from '@/components/Common/CheckModal/index.vue'
import { Judgement } from '@/utils/judge-edited'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { DELETE_OK_INFO, SAVE_OK_INFO } from '@/constants/msg'
import { message } from 'ant-design-vue'
import { Enum編集区分 } from '#/Enums'
import WarnAlert from '@/components/Common/WarnAlert/index.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const emit = defineEmits(['after-close'])
const route = useRoute()
const router = useRouter()
const loading = ref(false)
const visible = ref(false)
const editJudge = new Judgement(route.name as string)

const { courseno, yoyakuno, nitteino, atenano } = route.query
const isNew = Number(yoyakuno) < 0
const commonParams = {
  nitteino: Number(nitteino),
  atenano: String(atenano),
  editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更
}

const headerInfo = ref<PersonHeaderVM>()
const personInfo = ref<CommonBarHeaderBase3VM>()
const formData = reactive<DetailVM>({
  taikiflg: false,
  syokaiuketukeymd: '',
  biko: ''
})
let upddttm
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => searchData())
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(formData, () => editJudge.setEdited())
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//高さ
const headRef = ref(null)
const footerRef = ref(null)
const { height } = useElementSize(footerRef)
const { tableHeight } = useTableHeight(headRef, 65 + height.value)

//操作権限フラグ
const canEdit = computed(() => isNew || route.meta.updflg)
//削除フラグ取得
const canDelete = computed(() => !isNew && route.meta.delflg)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData() {
  // loading.value = true
  try {
    const res = await InitDetail(commonParams)
    headerInfo.value = res.headerinfo
    personInfo.value = res.personinfo
    Object.assign(formData, res.detailinfo)
    upddttm = res.upddttm
  } catch (error) {}
  loading.value = false
  nextTick(() => editJudge.reset())
}

//待機
async function onCheckOK1() {
  formData.taikiflg = true
  await saveData()
}
//続行
async function onCheckOK2() {
  await saveData()
}
//定員チェック処理
async function checkSave() {
  showSaveModal({
    onOk: async () => {
      try {
        const res = await Check({
          ...commonParams,
          taikiflg: formData.taikiflg
        })
        if (res.overflg) {
          visible.value = true
        } else {
          await saveData()
        }
      } catch (error) {}
    }
  })
}
//保存処理
async function saveData() {
  await Save({
    ...commonParams,
    detailinfo: formData,
    upddttm
  })
  editJudge.reset()
  message.success(SAVE_OK_INFO.Msg)
  emit('after-close')
  back2list()
}

//削除処理
function deleteData() {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await DeleteDetail({
          ...commonParams,
          upddttm
        })
        editJudge.reset()
        message.success(DELETE_OK_INFO.Msg)
        emit('after-close')
        back2list()
      } catch (error) {}
    }
  })
}

function back2list() {
  router.push({
    name: route.name as string,
    query: {
      ...route.query,
      atenano: undefined,
      yoyakuno: undefined
    }
  })
}

//format金額
const formatKingaku = (value) => {
  if (!value) return ''
  return Number(value).toLocaleString()
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 130px;
}
</style>
