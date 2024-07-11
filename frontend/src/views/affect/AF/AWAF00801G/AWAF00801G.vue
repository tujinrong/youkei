<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 汎用情報保守
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.06
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card :bordered="false">
      <div v-if="isSearchPage" class="self_adaption_table form">
        <a-row>
          <a-col :sm="12" :xl="8" :xxl="6">
            <th class="w-26">メインコード</th>
            <td>
              <ai-select
                v-model:value="queryParams.mainCode"
                :options="mainOptions"
                tabindex="1"
              ></ai-select>
            </td>
          </a-col>
          <a-col :sm="12" :xl="8" :xxl="6">
            <th class="w-26">サブコード</th>
            <td>
              <ai-select
                v-model:value="queryParams.subCode"
                :options="subOptions"
                :disabled="!queryParams.mainCode"
                tabindex="2"
              ></ai-select>
            </td>
          </a-col>
        </a-row>
      </div>
      <div v-else class="self_adaption_table">
        <a-row>
          <a-col :span="8">
            <th class="w-26">メインコード</th>
            <TD>{{ queryParams.mainCode }}</TD>
          </a-col>
          <a-col :span="8">
            <th class="w-26">サブコード</th>
            <TD>{{ queryParams.subCode }}</TD>
          </a-col>
          <a-col :span="8">
            <th class="w-40">ユーザ領域開始コード</th>
            <TD>{{ userryoikikaisicd }}</TD>
          </a-col>
          <a-col :span="24">
            <th class="w-26">説明</th>
            <TD>{{ biko }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 header_operation">
        <a-space>
          <a-button
            v-if="isSearchPage"
            :disabled="!(queryParams.mainCode && queryParams.subCode)"
            type="primary"
            tabindex="3"
            @click="handleSearch"
            >検索</a-button
          >
          <a-button v-else type="primary" tabindex="3" @click="backToSearch">再検索</a-button>
          <a-button type="primary" :disabled="exceloutDisabled" tabindex="4" @click="outputCsv"
            >CSV出力</a-button
          >
          <a-button
            class="warning-btn"
            :disabled="isSearchPage || !tableRef?.hasPermission"
            tabindex="17"
            @click="saveData"
            >登録</a-button
          >
          <a-button v-if="!isSearchPage" type="primary" tabindex="18" @click="visible = true"
            >サブコード編集</a-button
          >
          <a-button
            v-else
            type="primary"
            :disabled="!route.meta.addflg"
            tabindex="18"
            @click="visible = true"
            >サブコード新規</a-button
          >
        </a-space>
        <close-page tabindex="19" />
      </div>
    </a-card>
    <a-card class="m-t-1">
      <Table
        ref="tableRef"
        in-page
        :issearched="!isSearchPage"
        :main-code="queryParams.mainCode ?? ''"
        :sub-code="queryParams.subCode ?? ''"
        kinoid="AWAF00801G"
        @after-save="resetFields"
      ></Table>
    </a-card>
    <SubcdMoadl
      v-model:visible="visible"
      :isnew="isSearchPage"
      :main-code="queryParams.mainCode ?? ''"
      :sub-code="queryParams.subCode ?? ''"
      @emit-subcdnm="updSubCdNm"
    />
  </a-spin>
</template>

<script setup lang="ts">
import { ref, reactive, onMounted, watch } from 'vue'
import { InitMainCode, InitSubCode } from './service'
import { C003003, C003006, RESEARCH_CONFIRM } from '@/constants/msg'
import { showConfirmModal } from '@/utils/modal'
import { Enum名称区分 } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'
import Table from './components/Table.vue'
import SubcdMoadl from './components/Modal.vue'
import { useRouter, useRoute } from 'vue-router'
import { getSearchQuery } from '@/utils/util'
//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const fieldMapping = {
  mainCode: 'メインコード',
  subCode: 'サブコード'
}

//ローディング
const loading = ref(false)
//テンプレート参照
const tableRef = ref<InstanceType<typeof Table> | null>(null)
//ビューモデル
const route = useRoute()
const isSearchPage = ref(true)
const exceloutDisabled = ref(true)
const visible = ref(false)
const queryParams = reactive<{
  mainCode: string | null
  subCode: string | null
}>({
  mainCode: null,
  subCode: null
})
const mainOptions = ref<DaSelectorModel[]>([])
const subOptions = ref<DaSelectorModel[]>([])
const biko = ref('') //説明
const userryoikikaisicd = ref()
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//メインコード変更処理
watch(
  () => queryParams.mainCode,
  async (val) => {
    queryParams.subCode = null
    if (!val) return
    const hanyomaincd = val.split(' : ')[0]
    const res = await InitSubCode({ hanyomaincd, kbn: Enum名称区分.名称 })
    subOptions.value = res.selectorlist
  }
)

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getSearchMainCd()
  tableRef.value?.editJudge.addEvent()
})

//---------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//初期化処理
const getSearchMainCd = async () => {
  const res = await InitMainCode({ kbn: Enum名称区分.名称 })
  mainOptions.value = res.selectorlist
  exceloutDisabled.value = !res.exceloutflg
}

//検索処理
const handleSearch = async () => {
  loading.value = true
  try {
    const res = await tableRef.value?.searchData()
    if (res) {
      biko.value = res.biko
      userryoikikaisicd.value = res.userryoikikaisicd
    }
    isSearchPage.value = false
  } catch (error) {}
  loading.value = false
}

//保存処理
const saveData = () => {
  tableRef.value?.saveData()
}

//再検索
const backToSearch = () => {
  if (tableRef.value?.editJudge.isPageEdited()) {
    showConfirmModal({
      content: RESEARCH_CONFIRM,
      onOk: () => resetFields()
    })
  } else {
    resetFields()
  }
}
//クリア処理
const resetFields = () => {
  queryParams.mainCode = null
  queryParams.subCode = null
  isSearchPage.value = true
  tableRef.value?.clear()
}

const updSubCdNm = (value: string) => {
  const cd = queryParams.subCode?.split(' : ')[0]
  queryParams.subCode = cd + ' : ' + value
}

//Csv出力
function outputCsv() {
  showConfirmModal({
    content: tableRef.value?.editJudge.isPageEdited()
      ? C003006.Msg.replace('{0}', '帳票出力')
      : C003003.Msg.replace('{0}', '帳票出力'),
    onOk: async () => {
      await router.push({ name: 'AWEU00301G' })
      router.push({
        name: 'AWEU00301G',
        query: {
          rptid: '0104',
          outerSearch: 'true',
          ...getSearchQuery(queryParams, fieldMapping)
        }
      })
    }
  })
}
</script>
