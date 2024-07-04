<template>
  <div>
    <a-card :bordered="false">
      <a-form>
        <div class="self_adaption_table ml-[1px]" :class="{ form: editFlg }">
          <a-row>
            <a-col :xs="10" :sm="10" :md="10" :xxl="10">
              <th class="bg-readonly">データソースID</th>
              <TD>{{ route.query.datasourceid }} </TD>
            </a-col>
            <a-col :xs="14" :sm="14" :md="14" :xxl="14">
              <th class="bg-readonly">メインテーブル</th>
              <TD>{{ tableInfo.maintablealias }} </TD>
            </a-col>
          </a-row>
          <a-row>
            <a-col :xs="10" :sm="10" :md="10" :xxl="10">
              <th class="bg-readonly">データソース名</th>
              <TD>{{ tableInfo.datasourcenm }}</TD>
            </a-col>
            <a-col :xs="14" :sm="14" :md="14" :xxl="14">
              <th class="bg-readonly">業務</th>
              <TD>{{ tableInfo.gyoumu }}</TD>
            </a-col>
          </a-row>
        </div>
      </a-form>
      <div class="flex justify-between m-t-1">
        <a-space>
          <a-button type="warn" :disabled="!editFlg" @click="saveData">編集</a-button>
          <a-button type="primary" danger :disabled="!delFlg" @click="del">削除</a-button>
          <a-button type="primary" @click="goListPage">一覧へ</a-button>
        </a-space>
        <close-page></close-page>
      </div>
    </a-card>
    <a-card class="m-t-1">
      <a-tabs v-model:activeKey="tabActiveKey">
        <a-tab-pane :key="Enum帳票項目定義.テーブル" tab="テーブル">
          <tab-table v-bind="defaultProps" @set-info="(val) => (tableInfo = val)"></tab-table>
        </a-tab-pane>
        <a-tab-pane :key="Enum帳票項目定義.検索条件" tab="検索条件">
          <tab-search v-bind="defaultProps" :type="Enum帳票項目定義.検索条件"></tab-search>
        </a-tab-pane>
        <a-tab-pane :key="Enum帳票項目定義.固定条件" tab="その他条件">
          <extract-conditions v-bind="defaultProps"></extract-conditions>
        </a-tab-pane>
      </a-tabs>
    </a-card>

    <EdditModal ref="modalRef" v-model:visible="visible" v-model:table-info="tableInfo" />
  </div>
</template>

<script setup lang="ts">
//---------------------------------------------------------------------------
//項目設定
//---------------------------------------------------------------------------
import { onMounted, ref } from 'vue'
import { message } from 'ant-design-vue'
import { useRoute, useRouter } from 'vue-router'
import emitter from '@/utils/event-bus'
import { GlobalStore } from '@/store'
import { DELETE_OK_INFO } from '@/constants/msg'
import { showDeleteModal } from '@/utils/modal'
import { InitDetailTab, Delete } from '@/views/affect/EU/AWEU00101G/service'
import { InitDetailTabResponse } from '@/views/affect/EU/AWEU00101G/type'
import TD from '@/components/Common/TableTD/index.vue'
import EdditModal from '@/views/affect/EU/AWEU00102D/index.vue'
import TabTable from './components/TabTable/index.vue'
import ExtractConditions from './components/ExtractConditions/index.vue'
import TabSearch from './components/TabSearch/index.vue'

enum Enum帳票項目定義 {
  テーブル = '1',
  検索条件 = '2',
  固定条件 = '3'
}
//---------------------------------------------------------------------------
//データ定義
//---------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()

//操作権限フラグ
const editFlg = route.meta.updflg as boolean
const delFlg = route.meta.delflg as boolean
//タブキー
const tabActiveKey = ref(Enum帳票項目定義.テーブル)
//ビューモデル
const modalRef = ref<InstanceType<typeof EdditModal> | null>(null)
const visible = ref<boolean>(false)

//保存モデル
const tableInfo = ref<
  Omit<
    InitDetailTabResponse,
    'maindata' | 'joindata' | 'masterdata' | 'freedata' | 'viewdata' | keyof DaResponseBase
  >
>({
  datasourceid: '', // データソースID
  maintablealias: '', // メインテーブル別名
  datasourcenm: '', // データソース名称
  gyoumu: '', // 業務
  upddttm: ''
})

const datasourceid = route.query.datasourceid as string

const defaultProps = {
  groupid: datasourceid
}

//--------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------

//--------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------
//一覧へ処理
const goListPage = () => {
  router.push({ name: 'AWEU00101G' })
  emitter.emit('refreshEU101List')
}
//編集処理
const saveData = async () => {
  visible.value = true
  modalRef.value?.setFilesValues(tableInfo.value)
}
//削除項目
const del = () => {
  showDeleteModal({
    handleDB: true,
    async onOk() {
      try {
        await Delete({
          datasourceid: tableInfo.value.datasourceid,
          upddttm: tableInfo.value.upddttm
        })
        message.success(DELETE_OK_INFO.Msg)
        emitter.emit('refreshEU101List')
        router.push({ name: 'AWEU00101G' })
      } catch (error) {}
    }
  })
}
</script>

<style lang="less" src="./index.less" scoped></style>
