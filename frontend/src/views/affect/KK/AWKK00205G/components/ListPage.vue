<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 事業実施報告書（日報）管理
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.1.16
 * 作成者　　: CNC張加恒
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table form">
        <a-row>
          <a-col :md="12" :lg="8" :xxl="6">
            <th class="required">業務</th>
            <td>
              <a-form-item v-bind="validateInfos.gyomukbn">
                <ai-select
                  v-model:value="searchParams.gyomukbn"
                  :options="selectorlist1"
                  @change="changeGyomu(searchParams.gyomukbn)"
                ></ai-select>
              </a-form-item>
            </td>
          </a-col>
          <a-col :md="12" :lg="8" :xxl="6">
            <th class="required">事業</th>
            <td>
              <a-form-item v-bind="validateInfos.kijunjigyo">
                <ai-select
                  v-model:value="searchParams.kijunjigyo"
                  :options="selectorlist2"
                  style="width: 100%"
                ></ai-select
              ></a-form-item>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 flex">
        <a-space>
          <a-button type="primary" @click="getTableList">検索</a-button>
          <a-button type="primary" :disabled="!addFlg" @click="forwardNew">新規</a-button>
          <a-button type="primary" @click="reset">クリア</a-button>
        </a-space>
        <close-page></close-page>
      </div>
    </a-card>
    <a-card class="mt-2">
      <div>
        <div class="text-center">
          <a-radio-group v-model:value="vFlg" @change="changeData(vFlg)">
            <a-radio :value="1">すべて表示</a-radio>
            <a-radio :value="2">有効データのみ表示 {{ currentDateTime }} 時点の有効データ</a-radio>
          </a-radio-group>
        </div>
        <div class="mt-2">
          <vxe-table
            :height="tableHeight"
            :column-config="{ resizable: true }"
            :row-config="{ isCurrent: true, isHover: true }"
            :data="filterDataList"
            :empty-render="{ name: 'NotData' }"
            @cell-dblclick="({ row }) => forwardEdit(row)"
          >
            <vxe-column field="itemnm" title="項目名称" width="383">
              <template #default="{ row }">
                <a @click="forwardEdit(row)">{{ row.itemnm }}</a>
              </template>
            </vxe-column>
            <vxe-column field="sex" title="性別" width="150"
              ><template #default="{ row }">
                {{ row.sex ? row.sex : 'すべて' }}
              </template></vxe-column
            >
            <vxe-column field="age" title="年齢範囲" width="150">
              <template #default="{ row }">
                {{ row.age ? row.age : 'すべて' }}
              </template>
            </vxe-column>
            <vxe-column field="tani" title="単位" width="150"></vxe-column>
            <vxe-column field="kijunvaluehyoki" title="基準範囲" width="150"></vxe-column>
            <vxe-column field="alertvaluehyoki" title="要注意" width="150"></vxe-column>
            <vxe-column field="errvaluehyoki" title="異常値" width="150"></vxe-column>
            <vxe-column field="yukoymd" title="有効年月日範囲"></vxe-column>
          </vxe-table>
        </div>
      </div>
    </a-card>
  </a-spin>
</template>

<script lang="ts" setup>
import { ref, onMounted, watch, reactive, computed } from 'vue'
import { useRouter, useRoute, onBeforeRouteUpdate } from 'vue-router'
import { Form, message } from 'ant-design-vue'
import { ITEM_REQUIRE_ERROR, SAVE_OK_INFO } from '@/constants/msg'
import { RowVM, SearchRequest } from '../type'
import { PageSatatus } from '#/Enums'
import { InitList, SearchList } from '../service'
import { getHeight } from '@/utils/height'
import { OUTPUT_EXCEL_CONFIRM } from '@/constants/msg'
import { showConfirmModal } from '@/utils/modal'
import { useTableHeight } from '@/utils/hooks'
import { getDateJpText } from '@/utils/util'
import { Data } from 'ant-design-vue/es/_util/type'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
enum Enum有効データ {
  すべて = 1,
  有効
}
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const vFlg = ref<number>(Enum有効データ.すべて)
interface VM extends SearchRequest {
  kijunjigyocd: string
}
const currentRow = reactive<VM>({
  gyomukbn: '',
  kijunjigyocd: '',
  kijunjigyo: ''
})
//ページャー
const totalCount = ref(0)
const pageParams = reactive<CmSearchRequestBase>({
  pagesize: 25,
  pagenum: 1,
  orderby: 0
})
const createDefaultParams = () => {
  return {
    gyomukbn: '',
    kijunjigyo: ''
  }
}
const searchParams = reactive(createDefaultParams())
const selectorlist1 = ref<DaSelectorModel[]>([])
const selectorlist2 = ref<DaSelectorModel[]>([])
const dataSource = ref<RowVM[]>([])
const filterDataList = ref<RowVM[]>([])
//権限フラグ
const exceloutflg = ref(false)
const addFlg = route.meta.addflg
const currentDateTime = getDateJpText(new Date())
//項目の設定
const rules = reactive({
  gyomukbn: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '業務') }],
  kijunjigyo: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '事業') }]
})
const { validate, validateInfos } = Form.useForm(searchParams, rules)
//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(pageParams, () => {
  if (dataSource.value.length > 0 || totalCount.value > 0) getTableList()
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef)

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  InitList().then((res) => {
    selectorlist1.value = res.selectorlist1
    selectorlist2.value = res.selectorlist2
  })
})
onBeforeRouteUpdate((to, from) => {
  if (to.query.refresh) {
    pageParams.pagenum = 1
    getTableList()
  }
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

async function forwardNew() {
  await validate()
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.New,
      gyomukbn: searchParams.gyomukbn,
      kijunjigyocd: searchParams.kijunjigyo
    }
  })
}
function forwardEdit(val: RowVM) {
  router.push({
    name: route.name as string,
    query: {
      status: PageSatatus.Edit,
      gyomukbn: currentRow.gyomukbn,
      kijunjigyocd: currentRow.kijunjigyocd,
      itemcd: val.itemcd,
      itemnm: val.itemnm,
      edano: val.edano
    }
  })
}

//検索処理
async function getTableList() {
  await validate()
  loading.value = true
  try {
    const res = await SearchList({ ...pageParams, ...searchParams })
    totalCount.value = res.totalrowcount
    currentRow.gyomukbn = searchParams.gyomukbn
    currentRow.kijunjigyocd = searchParams.kijunjigyo
    dataSource.value = res.kekkalist
    vFlg.value = Enum有効データ.すべて
    changeData(Enum有効データ.すべて)
  } catch (error) {}
  loading.value = false
}

function reset() {
  Object.assign(searchParams, createDefaultParams())
  dataSource.value = []
  vFlg.value = Enum有効データ.すべて
  changeData(Enum有効データ.すべて)
}
const changeGyomu = (val) => {
  show(val)
}
const show = (val) => {
  console.log(val)
}
function handleExcel() {
  showConfirmModal({
    content: OUTPUT_EXCEL_CONFIRM,
    onOk: () => {
      // todo
    }
  })
}
// すべて表示 有効データのみ表示
const changeData = (val: number) => {
  if (val === Enum有効データ.すべて) {
    // すべてのデータが表示される場合は、元のデータ ソースを直接使用します。
    filterDataList.value = dataSource.value
  } else {
    // 有効なデータが表示されている場合は、データをフィルタリングします
    let currentDate = new Date()
    filterDataList.value = dataSource.value.filter((item) => new Date(item.yukoymdt) >= currentDate)
  }
}
</script>

<style lang="less" scoped>
.self_adaption_table.form th {
  width: 150px;
}
</style>
