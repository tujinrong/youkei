<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 健（検）診結果・保健指導履歴照会
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.02.14
 * 作成者　　: 張加恒
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    v-model:visible="visible"
    title="健（検）診結果・保健指導履歴照会"
    width="1350px"
    :closable="true"
    destroy-on-close
    centered
    @cancel="closeModal"
  >
    <div class="self_adaption_table">
      <a-row>
        <a-col span="6">
          <th>宛名番号</th>
          <TD>{{ $route.query.atenano }}</TD>
        </a-col>
        <a-col span="6">
          <th>氏名</th>
          <TD>{{ userInfo?.name }}</TD>
        </a-col>
        <a-col span="6">
          <th>カナ氏名</th>
          <TD>{{ userInfo?.kname }}</TD>
        </a-col>
        <a-col span="6">
          <th style="width: 120px">性別</th>
          <TD>{{ userInfo?.sex }}</TD>
        </a-col>
        <a-col span="6">
          <th>住民区分</th>
          <TD>{{ userInfo?.juminkbn }}</TD>
        </a-col>
        <a-col span="6">
          <th>生年月日</th>
          <TD>{{ userInfo?.bymd }}</TD>
        </a-col>
        <a-col span="6">
          <th>年齢</th>
          <TD>{{ userInfo?.age }}</TD>
        </a-col>
        <a-col span="6">
          <th style="width: 120px">年齢計算基準日</th>
          <TD>{{ userInfo?.agekijunymd }}</TD>
        </a-col>
      </a-row>
    </div>
    <div class="mt-4">
      <a-pagination
        v-model:current="pageParams.pagenum"
        v-model:page-size="pageParams.pagesize"
        :page-size-options="$pagesizes"
        :total="totalCount"
        show-less-items
        show-size-changer
        class="text-end mb-2"
      />
      <vxe-table
        height="500"
        :loading="loading"
        :header-cell-style="{ backgroundColor: '#ffffe1' }"
        :column-config="{ resizable: true }"
        :sort-config="{ trigger: 'cell' }"
        :row-config="{ isCurrent: true, isHover: true }"
        :data="dataSource"
        :empty-render="{ name: 'NotData' }"
        @cell-dblclick="({ row }) => forwardResultPage(row)"
        @sort-change="(e) => changeTableSort(e, toRef(pageParams, 'orderby'))"
      >
        <vxe-column
          field="jissiage"
          title="実施時年齢"
          min-width="60"
          :params="{ order: 1 }"
          sortable
        >
        </vxe-column>
        <vxe-colgroup title="健（検）診結果情報" align="center">
          <vxe-column
            field="kstype"
            title="健（検）診種別"
            min-width="80"
            :params="{ order: 2 }"
            sortable
          >
          </vxe-column>
          <vxe-column
            field="ksymd"
            title="健（検）診年月日"
            min-width="95"
            :params="{ order: 3 }"
            formatter="jpDate"
            sortable
          ></vxe-column>
          <vxe-column
            field="kskbn"
            title="一次/精密"
            min-width="50"
            :params="{ order: 4 }"
            sortable
          />
          <vxe-column
            field="kshoho"
            title="検査方法"
            min-width="80"
            :params="{ order: 5 }"
            sortable
          />
        </vxe-colgroup>
        <vxe-colgroup title="保健指導履歴情報·集団指導履歴情報" align="center">
          <vxe-column
            field="hskbnnm"
            title="保健指導区分"
            min-width="80"
            :params="{ order: 6 }"
            sortable
          ></vxe-column>
          <vxe-column
            field="jigyonm"
            title="事業名"
            min-width="80"
            :params="{ order: 7 }"
            sortable
          ></vxe-column>
          <vxe-column
            field="jissiymd"
            title="実施日"
            min-width="95"
            formatter="jpDate"
            :params="{ order: 8 }"
            sortable
          />
          <vxe-column
            field="jissitm"
            title="実施時間"
            min-width="80"
            :params="{ order: 9 }"
            sortable
          />
          <vxe-column
            field="jissistaffnm"
            title="実施者"
            min-width="80"
            :params="{ order: 10 }"
            sortable
            :resizable="false"
          />
        </vxe-colgroup>
      </vxe-table>
    </div>
    <template #footer>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { PageSatatus, Enum保健指導業務区分, Enum指導区分 } from '#/Enums'
import { ref, toRef } from 'vue'
import { changeTableSort } from '@/utils/util'
import { Search, SearchSeni } from './service'
import { RowVM } from './type'
import TD from '@/components/Common/TableTD/index.vue'
import { useRoute, useRouter } from 'vue-router'
import { ss } from '@/utils/storage'
import { PAGE_DATA } from '@/constants/mutation-types'
import { useSearch } from '@/utils/hooks'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const visible = ref(false)
const atenano = route.query.atenano as string
const userInfo = ref<CommonBarHeaderBaseVM | null>(null)
const dataSource = ref<RowVM[]>([])

const { loading, pageParams, totalCount, searchData, clear } = useSearch({
  service: Search,
  source: dataSource,
  params: toRef(() => ({ atenano }))
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//初期化処理
const openModal = async () => {
  visible.value = true
  getList()
}
//検索処理
function getList() {
  searchData().then((res) => {
    userInfo.value = res.headerinfo
  })
}
//遷移
async function forwardResultPage(val: RowVM) {
  loading.value = true
  const currentOpenedPages = ss.get(PAGE_DATA)
  if (val.kskbn) {
    // 一次 / 精密あり
    try {
      const res = await SearchSeni({
        jigyocd: val.jigyocd,
        kinoids: currentOpenedPages.map((el) => el.name)
      })
      router.push({
        name: res.kinoid,
        query: {
          atenano,
          nendo: val.nendo
        }
      })
      closeModal()
    } catch (error) {}
  } else {
    // 一次 / 精密なし
    if (
      val.hokensidokbn === String(Enum指導区分.訪問指導) ||
      val.hokensidokbn === String(Enum指導区分.個別指導)
    ) {
      try {
        await SearchSeni({
          jigyocd: val.jigyocd,
          kinoids: currentOpenedPages.map((el) => el.name),
          kinoid2: 'AWKK00301G'
        })
        router.push({
          name: 'AWKK00301G',
          query: {
            atenano,
            prevno: atenano,
            status: PageSatatus.Detail
          }
        })
        //todo: AWKK00301G.forwardNext
      } catch (error) {}
    } else {
      try {
        await SearchSeni({
          jigyocd: val.jigyocd,
          kinoids: currentOpenedPages.map((el) => el.name),
          kinoid2: 'AWKK00303G'
        })
        router.push({
          name: 'AWKK00303G',
          query: {
            status: PageSatatus.Edit,
            edano: val.edano,
            gyomu: val.gyomukbn,
            patternno: String(Enum保健指導業務区分[`${val.gyomukbn}`])
          }
        })
      } catch (error) {}
    }
    closeModal()
  }
  loading.value = false
}

//閉じるボタン(×を含む)
const closeModal = () => {
  clear()
  visible.value = false
}
defineExpose({
  open: openModal
})
</script>
<style src="./index.less" scoped></style>
