<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: ホーム(インフォメーション)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.03.03
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-spin :spinning="loading">
    <a-row :gutter="[8, 8]">
      <a-col v-if="showComponent1" :md="24" :xl="12">
        <a-spin :spinning="loading1">
          <a-card :bordered="false">
            <div class="flex justify-between h-10">
              <h3>お知らせ</h3>
              <div>
                <a-select
                  v-model:value="readkbn"
                  class="m-l-auto w-24"
                  :options="readOptions"
                ></a-select>
                <a-button
                  id="tab-edit-btn"
                  type="primary"
                  class="btn-round m-l-1"
                  @click="openModal"
                  >編集</a-button
                >
                <a-button
                  id="tab-refresh-btn"
                  type="primary"
                  class="btn-round m-l-1"
                  @click="refresh1"
                  >再表示</a-button
                >
              </div>
            </div>
            <div un-border="1 solid #606266">
              <vxe-list
                :height="collapseHeight"
                :data="kekkaList1"
                :scroll-y="{ sItem: '.collapse-item', oSize: 5 }"
              >
                <template #default="{ items }">
                  <div v-for="item in items" :key="item.infoseq" class="collapse-item">
                    <a-collapse ghost>
                      <a-collapse-panel>
                        <template #header>
                          <a-tag :color="noticeJuyoColorMap[item.juyodo]">{{
                            noticeJuyoStrMap[item.juyodo]
                          }}</a-tag>
                          <a-tag :color="item.readflg ? 'green' : 'red'">{{
                            item.readflg ? '即読' : '未読'
                          }}</a-tag>
                          <span class="whitespace-nowrap mr-2">{{
                            getDateHmsJpText(new Date(item.regdttm))
                          }}</span>
                          『<span class="whitespace-nowrap overflow-hidden text-ellipsis">
                            {{ item.syosai }} </span
                          >』
                        </template>
                        <p class="m-0 break-words">{{ item.syosai }}</p>
                      </a-collapse-panel>
                    </a-collapse>
                  </div>
                </template>
              </vxe-list>
            </div>
          </a-card>
        </a-spin>
      </a-col>
      <a-col v-if="showComponent2" :md="24" :xl="12">
        <a-spin :spinning="loading2">
          <a-card :bordered="false" class="p-b-[2px]">
            <div class="flex justify-between h-10">
              <h3>処理状況</h3>
              <div>
                <a-select
                  v-model:value="handlekbn"
                  :options="handleOptions"
                  class="w-50"
                  @change="onChangeSyori"
                />
                <a-button
                  id="tab-refresh-btn"
                  type="primary"
                  class="btn-round m-l-1"
                  @click="refresh2"
                  >再表示</a-button
                >
              </div>
            </div>
            <div :style="{ height: collapseHeight }">
              <vxe-table
                height="100%"
                :column-config="{ resizable: true }"
                :row-config="{ isCurrent: true, isHover: true }"
                :data="kekkaList2_filter"
                :sort-config="{ trigger: 'cell' }"
                :empty-render="{ name: 'NotData' }"
                @cell-click="clickRow"
              >
                <vxe-column
                  field="syoridttmf"
                  title="処理日時（開始）"
                  formatter="jpTimeSimple"
                  width="160"
                  min-width="160"
                  sortable
                />
                <vxe-column
                  field="syoridttmt"
                  title="処理日時（終了）"
                  formatter="jpTimeSimple"
                  width="160"
                  min-width="160"
                  sortable
                />
                <vxe-column field="syorikbn" title="処理区分" min-width="100" sortable />
                <vxe-column field="syorinm" title="処理名" min-width="100" sortable>
                  <template #default="{ row }">
                    <span
                      v-if="row.fileflg"
                      class="underline cursor-pointer c-blue-7"
                      @click="(e) => downloadFile(e, row.gaibulogseq)"
                      >{{ row.syorinm }}</span
                    >
                    <span v-else>{{ row.syorinm }}</span>
                  </template>
                </vxe-column>
                <vxe-column field="usernm" title="操作者" min-width="100" sortable />
                <vxe-column field="status" title="処理結果" width="100" min-width="100" sortable>
                  <template #default="{ row }">
                    <span :style="{ color: operationStatusMap[String(row.colorkbn)] }">{{
                      row.status
                    }}</span>
                  </template>
                </vxe-column>
              </vxe-table>
            </div>
          </a-card>
        </a-spin>
      </a-col>
    </a-row>
    <NoticeModal v-model:visible="noticeVisible" @refresh="getNoticeList" />
  </a-spin>
</template>

<script setup lang="ts">
import { ref, onMounted, computed, nextTick } from 'vue'
import { useBoolean } from '@/utils/hooks'
import NoticeModal from '@/views/affect/AF/AWAF00302D/index.vue'
import {
  readOptions,
  noticeJuyoStrMap,
  noticeJuyoColorMap,
  operationStatusMap
} from '@/constants/constant'
import type { InfoVM, GaibulogVM } from '../../type'
import { Init, Download, SearchInfo, SearchLog } from '../../service'
import { getDateHmsJpText, transferToPage } from '@/utils/util'
import { message } from 'ant-design-vue'
import { showConfirmModal } from '@/utils/modal'
import { Enum名称区分, Enum未読区分 } from '#/Enums'
import { DOWNLOAD_CONFIRM, DOWNLOAD_OK_INFO, REFRESH_CONFIRM } from '@/constants/msg'
import { useRouter } from 'vue-router'
import { getHeight } from '@/utils/height'
import { EnumLogTab } from '@/views/affect/AF/AWAF00803G/constant'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const loading = ref(false)
const loading1 = ref(false)
const loading2 = ref(false)
const showComponent1 = ref(true)
const showComponent2 = ref(true)
const { bool: noticeVisible, setTrue: openModal } = useBoolean()
//画面区分
const readkbn = ref(Enum未読区分.未読)
const handlekbn = ref('')
//ビューモデル
const kekkaList1 = ref<InfoVM[]>([])
const kekkaList2 = ref<GaibulogVM[]>([])
const handleOptions = ref<DaSelectorModel[]>([])
const selectSyoriObj = ref<DaSelectorModel>({
  label: '',
  value: ''
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const collapseHeight = computed(() => getHeight(170))

const kekkaList2_filter = computed(() => {
  return kekkaList2.value.filter((item) => {
    if (!selectSyoriObj.value.value) return true
    return item.syorikbn === selectSyoriObj.value.label
  })
})

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  loading.value = true
  Init({ kbn: Enum名称区分.名称 })
    .then((res) => {
      handleOptions.value = [{ label: 'すべて', value: '' }, ...res.selectorlist]
      kekkaList1.value = res.kekkalist1
      kekkaList2.value = res.kekkalist2
    })
    .finally(() => {
      loading.value = false
    })
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//お知らせ画面内容取得
const getNoticeList = async () => {
  loading1.value = true
  const res = await SearchInfo({ readkbn: readkbn.value })
  kekkaList1.value = res.kekkalist
  loading1.value = false
}
//連携ログ画面内容取得
const getLogList = async () => {
  loading2.value = true
  const res = await SearchLog()
  kekkaList2.value = res.kekkalist
  loading2.value = false
}

//再表示(お知らせ)
const refresh1 = () => {
  showConfirmModal({
    content: REFRESH_CONFIRM,
    onOk: async () => {
      await getNoticeList()
      showComponent1.value = false
      nextTick(() => {
        showComponent1.value = true
      })
    }
  })
}
//再表示(連携処理)
const refresh2 = () => {
  showConfirmModal({
    content: REFRESH_CONFIRM,
    onOk: async () => {
      await getLogList()
      showComponent2.value = false
      nextTick(() => {
        showComponent2.value = true
      })
    }
  })
}
//処理状況：ダウンロード処理
const downloadFile = (e, logseq: number) => {
  e.stopPropagation()
  showConfirmModal({
    content: DOWNLOAD_CONFIRM,
    onOk: async () => {
      try {
        await Download({ gaibulogseq: logseq })
        message.success(DOWNLOAD_OK_INFO.Msg)
      } catch (error) {}
    }
  })
}

//処理状況：ログ画面遷移確認
const clickRow = ({ row }) => {
  const menuid = 'AWAF00803G'
  transferToPage(menuid, () => {
    router.push({
      name: menuid,
      query: { sessionseq: row.gaibulogseq, logkbn: EnumLogTab.連携 }
    })
  })
}

//処理状況:切換区分
const onChangeSyori = (val, opt) => {
  selectSyoriObj.value = opt
}
</script>
