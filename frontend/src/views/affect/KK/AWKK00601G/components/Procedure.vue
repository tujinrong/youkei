<template>
  <a-spin :spinning="loading">
    <a-card :bordered="false">
      <div style="margin-left: 35px">プロシージャ</div>
      <a-row :gutter="[0, 10]">
        <a-col :xs="8" :sm="12" :md="12" :lg="12" :xl="12" :xxl="8">
          <div class="description-table" style="margin-left: 40px">
            <table>
              <tbody>
                <tr>
                  <th style="width: 110px">チェック用</th>
                  <td>
                    <a-select
                      v-model:value="param.procchk"
                      :options="chkOptions"
                      style="width: 100%"
                      allow-clear
                      @change="getData"
                    ></a-select>
                  </td>
                </tr>
                <tr>
                  <th style="width: 110px">更新前処理</th>
                  <td>
                    <a-select
                      v-model:value="param.procbefore"
                      :options="beforeOptions"
                      style="width: 100%"
                      allow-clear
                      @change="getData"
                    ></a-select>
                  </td>
                </tr>
                <!-- <tr>
                  <th style="width: 110px">更新処理<span class="request-mark">＊</span></th>
                  <td>
                    <a-select
                      v-model:value="param.procbefore"
                      :options="beforeOptions"
                      style="width: 100%"
                      allow-clear
                      @change="getData"
                    ></a-select>
                  </td>
                </tr> -->
                <tr>
                  <th style="width: 110px">更新後処理</th>
                  <td>
                    <a-select
                      v-model:value="param.procafter"
                      :options="afterOptions"
                      style="width: 100%"
                      allow-clear
                      @change="getData"
                    ></a-select>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </a-col>
        <a-button type="primary" style="margin-left: 40px" @click="openModal"
          >プロシージャ管理</a-button
        >
      </a-row>
    </a-card>
  </a-spin>
  <ProduceModal
    v-model:visible="visible"
    :upd-flg="updFlg"
    :add-flg="addFlg"
    :del-flg="delFlg"
    @update-options="getOptions"
  >
  </ProduceModal>
</template>

<script setup lang="ts">
//--------------------------------------------------------------------------
//ストアドプロシージャ
//--------------------------------------------------------------------------
import { ref, onMounted } from 'vue'
import { SelectProps } from 'ant-design-vue'
import { ProcedureDetailVM } from '../type'
import ProduceModal from '../../AWKK00607D/index.vue'
import { ReSearchProc } from '../service'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
interface Props {
  isChange: boolean
  data?: ProcedureDetailVM
  procchkOptions: SelectProps['options']
  procbeforeOptions: SelectProps['options']
  procafterOptions: SelectProps['options']
  delFlg: boolean
  addFlg: boolean
  updFlg: boolean
}
const props = withDefaults(defineProps<Props>(), {
  isChange: false
})
const emit = defineEmits(['update:isChange', 'getData'])
//--------------------------------------------------------------------------
//データ定義(data(ref…))
//--------------------------------------------------------------------------
const loading = ref(false)
//ビューモデル
const param = ref<ProcedureDetailVM>({
  procafter: '',
  procbefore: '',
  procchk: ''
})
const visible = ref(false)
//【チェック用】のドロップダウンリスト
const chkOptions = ref<SelectProps['options']>([])
//【更新前処理】のドロップダウンリスト
const beforeOptions = ref<SelectProps['options']>([])
//【更新後処理】のドロップダウンリスト
const afterOptions = ref<SelectProps['options']>([])
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getInitData()
})

//--------------------------------------------------------------------------
//メソッド(methods)
//--------------------------------------------------------------------------
//初期化処理
const getInitData = () => {
  param.value = JSON.parse(JSON.stringify(props.data))
  getOptions()
}
//初期化ドロップダウンボックス
const getOptions = () => {
  loading.value = true
  ReSearchProc({})
    .then((res) => {
      chkOptions.value = res.procchkList
      beforeOptions.value = res.procbeforeList
      afterOptions.value = res.procafterList
    })
    .finally(() => {
      param.value.procchk = processParamValue(param.value.procchk, chkOptions.value)
      param.value.procbefore = processParamValue(param.value.procbefore, beforeOptions.value)
      param.value.procafter = processParamValue(param.value.procafter, afterOptions.value)
      getData()
      loading.value = false
    })
}
const processParamValue = (paramValue, options) => {
  const valuesArray = options?.map((option) => option.value)
  return valuesArray?.includes(paramValue) ? paramValue?.split(':')[0].trim() : ''
}

//modalの表示
const openModal = () => {
  visible.value = true
}
const getData = () => {
  param.value.procafter = param.value.procafter?.split(':')[0].trim()
  param.value.procbefore = param.value.procbefore?.split(':')[0].trim()
  param.value.procchk = param.value.procchk?.split(':')[0].trim()
  emit('getData', 'procedure', param.value)
}
</script>
<style scoped lang="less">
:deep(.ant-table-fixed-header) {
  border: 1px solid #606266;
}

:deep(.ant-table-fixed-header > .ant-table-container > .ant-table-header > table) {
  border: none !important;
}
:deep(.ant-table-fixed-header .ant-table-container .ant-table-tbody > tr:last-child > td) {
  border-bottom: none !important;
}
.text-hidden {
  text-overflow: ellipsis;
  white-space: nowrap;
  overflow: hidden;
}
</style>
z
