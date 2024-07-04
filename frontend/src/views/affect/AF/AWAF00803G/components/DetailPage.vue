<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ログ情報管理(詳細画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.09.08
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-card ref="headRef" :bordered="false">
      <div class="self_adaption_table">
        <a-row>
          <a-col :md="8" :xxl="6">
            <th>セッションシーケンス</th>
            <TD>{{ route.query.sessionseq }}</TD>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>処理結果</th>
            <TD>{{ headerInfo?.status }}</TD>
          </a-col>
          <a-col :md="16" :xxl="12">
            <th>処理日時</th>
            <TD>{{ headerInfo?.syoridttm }}</TD>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>処理時間</th>
            <TD>{{ headerInfo?.syoritime }}</TD>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>機能名</th>
            <TD>{{ headerInfo?.servicenm }}</TD>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>処理名</th>
            <TD>{{ headerInfo?.methodnm }}</TD>
          </a-col>
          <a-col :md="8" :xxl="6">
            <th>操作者</th>
            <TD>{{ headerInfo?.user }}</TD>
          </a-col>
          <a-col v-if="personalnoflg" :md="8" :xxl="6">
            <th>個人番号操作状況</th>
            <TD>{{ headerInfo?.pnoflg }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="m-t-1 header_operation">
        <a-space>
          <a-button type="primary" @click="goList">一覧へ</a-button>
        </a-space>
        <close-page />
      </div>
    </a-card>
    <a-card class="my-2" :loading="loading">
      <a-tabs v-model:activeKey="activeKey" type="card">
        <a-tab-pane v-if="existflgs[0]" :key="EnumLogTab.通信" tab="通信ログ情報">
          <CommonPane
            :out-height="bodyHeight"
            :type="EnumLogTab.通信"
            :column="visibleColumns[EnumLogTab.通信]"
          />
        </a-tab-pane>
        <a-tab-pane v-if="existflgs[1]" :key="EnumLogTab.バッチ" tab="バッチログ情報">
          <CommonPane
            :out-height="bodyHeight"
            :type="EnumLogTab.バッチ"
            :column="visibleColumns[EnumLogTab.バッチ]"
          />
        </a-tab-pane>
        <a-tab-pane v-if="existflgs[2]" :key="EnumLogTab.連携" tab="連携ログ情報">
          <CommonPane
            :out-height="bodyHeight"
            :type="EnumLogTab.連携"
            :column="visibleColumns[EnumLogTab.連携]"
          />
        </a-tab-pane>
        <a-tab-pane v-if="existflgs[3]" :key="EnumLogTab.DB" tab="DB操作ログ情報">
          <CommonPane
            :out-height="bodyHeight"
            :type="EnumLogTab.DB"
            :column="visibleColumns[EnumLogTab.DB]"
          />
        </a-tab-pane>
        <a-tab-pane v-if="existflgs[4]" :key="EnumLogTab.項目値" tab="項目値変更情報">
          <ColumDetailPane :out-height="bodyHeight" :column="visibleColumns[EnumLogTab.項目値]" />
        </a-tab-pane>
        <a-tab-pane v-if="existflgs[5]" :key="EnumLogTab.宛名" tab="宛名番号ログ情報">
          <CommonPane
            :out-height="bodyHeight"
            :type="EnumLogTab.宛名"
            :column="visibleColumns[EnumLogTab.宛名]"
          />
        </a-tab-pane>
      </a-tabs>
    </a-card>
  </div>
</template>

<script setup lang="ts">
import { computed, onMounted, ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { useElementSize } from '@vueuse/core'
import { getHeight } from '@/utils/height'
import { columns, EnumLogTab } from '../constant'
import { InitDetail } from '../service'
import { HeaderVM } from '../type'
import TD from '@/components/Common/TableTD/index.vue'
import CommonPane from './CommonPane.vue'
import ColumDetailPane from './ColumDetailPane.vue'
import { useTableHeight } from '@/utils/hooks'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const activeKey = ref(-1)
//ページ データ
const headerInfo = ref<HeaderVM>()
const existflgs = ref<boolean[]>([false, false, false, false, false, false])
//個人番号権限フラグ
const personalnoflg = route.meta.personalnoflg
//個人番号権限関連列の表示判断
const visibleColumns = Object.keys(columns).reduce((acc, key) => {
  acc[key] = columns[key].filter((item) =>
    personalnoflg ? true : !item.title.includes('個人番号')
  )
  return acc
}, {})

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  loading.value = true
  const res = await InitDetail({ sessionseq: Number(route.query.sessionseq) })
  headerInfo.value = res.headerinfo
  const { existflg1, existflg2, existflg3, existflg4, existflg5, existflg6 } = res
  existflgs.value = [existflg1, existflg2, existflg3, existflg4, existflg5, existflg6]
  //set init Tab
  activeKey.value = route.query.logkbn
    ? +route.query.logkbn
    : existflgs.value.findIndex((flg) => flg === true)
  loading.value = false
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const headRef = ref(null)
const { tableHeight: bodyHeight } = useTableHeight(headRef, 64)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//画面遷移
const goList = () => {
  router.push({ name: route.name as string })
}
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 170px;
}
</style>
