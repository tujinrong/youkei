<template>
  <div class="max-w-300">
    <h3 class="font-bold">フリー項目グループ右設定</h3>
    <a-space>
      <a-button class="btn-round" type="primary" :disabled="!canEdit" @click="addRow()"
        >行追加</a-button
      >
      <a-button class="btn-round" type="primary" :disabled="!canDelete" @click="deleteRow"
        >行削除</a-button
      >
    </a-space>
    <div :class="[canEdit && 'form', 'self_adaption_table mt-2 ml-1px']">
      <a-row>
        <a-col span="24">
          <th class="bg-readonly">メインコード名</th>
          <TD>{{ data.groupid2_maincdnm }}</TD>
        </a-col>
        <a-col span="24">
          <th class="required">サブコード名</th>
          <td v-if="canEdit">
            <a-form-item v-bind="validateInfos.groupid2_subcdnm">
              <a-input
                v-model:value="form.groupid2_subcdnm"
                allow-clear
                maxlength="100"
                @change="updateTableData"
              />
            </a-form-item>
          </td>
          <TD v-else>{{ form.groupid2_subcdnm }}</TD>
        </a-col>
      </a-row>
    </div>
    <vxe-table
      id="jigyo-table3"
      ref="xTableRef"
      :data="data.kekkalist"
      :column-config="{ resizable: true }"
      :header-cell-class-name="canEdit ? 'bg-editable' : 'bg-readonly'"
      :mouse-config="{ selected: true }"
      :edit-rules="rules"
      :row-config="{ isCurrent: true, height: 48 }"
      :keyboard-config="{
        isTab: true,
        isEdit: true,
        isEnter: true,
        enterToTab: true
      }"
      :edit-config="{
        trigger: 'click',
        mode: 'cell',
        showStatus: false,
        beforeEditMethod({ row, column }) {
          if (column.field === 'value' && row.remoteflg) {
            return false
          } else {
            return canEdit as unknown as boolean
          }
        }
      }"
      :valid-config="{ showMessage: false }"
      :empty-render="{ name: 'NotData' }"
      @edit-closed="updateTableData"
    >
      <vxe-column
        field="value"
        :edit-render="{ autofocus: 'input', autoselect: true }"
        :class-name="
          ({ row }) =>
            hasRepeated(row.value, 'value') || ['0', '00'].includes(row.value) || !row.value
              ? 'bg-errorcell'
              : ''
        "
        min-width="250"
        width="250"
      >
        <template #header>フリー項目グループ右コード</template>
        <template #edit="{ row }">
          <a-input
            v-model:value="row.value"
            maxlength="2"
            @change="row.value = row.value?.replaceAll(/[^0-9]/g, '')"
          ></a-input>
        </template>
      </vxe-column>
      <vxe-column
        field="label"
        :edit-render="{ autofocus: '.ant-input', autoselect: true }"
        min-width="110"
        :resizable="false"
        :class-name="({ row }) => (!row.label ? 'bg-errorcell' : '')"
      >
        <template #header>フリー項目グループ名</template>
        <template #edit="{ row }">
          <a-textarea
            v-model:value="row.label"
            type="text"
            :maxlength="100"
            :auto-size="{ minRows: 1 }"
          ></a-textarea>
        </template>
      </vxe-column>
    </vxe-table>
  </div>
</template>

<script setup lang="ts">
import TD from '@/components/Common/TableTD/index.vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { computed, onMounted, reactive, ref } from 'vue'
import { useRoute } from 'vue-router'
import VXETable, { VxeTableInstance } from 'vxe-table'
import { KensinDetailFreeVM } from '../../type'
import { useTable } from '@/utils/hooks'

const props = defineProps<{
  data: KensinDetailFreeVM
}>()
const emit = defineEmits(['update:data'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
//項目の設定
const rules = ref({
  groupid2_subcdnm: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'サブコード名') }
  ],
  value: [
    { required: true },
    {
      validator({ cellValue }) {
        if (hasRepeated(cellValue, 'value') || ['0', '00'].includes(cellValue)) {
          return new Error()
        }
        return
      }
    }
  ],
  label: [{ required: true }]
})

//サブコード
const form = reactive({ groupid2_subcdnm: '' })
const { validate, validateInfos } = Form.useForm(form, rules)
onMounted(() => {
  form.groupid2_subcdnm = props.data.groupid2_subcdnm
})

//操作権限フラグ
const isNew = Number(route.query.jigyocd) < 0
const canEdit = isNew || route.meta.updflg
//行削除フラグ取得
const canDelete = computed(() => {
  return Boolean(currentRow.value && !currentRow.value.remoteflg) && canEdit
})

const xTableRef = ref<VxeTableInstance>()
const { hasRepeated, deleteRow, addRow, currentRow, getTableData } = useTable(xTableRef, 'value')

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//自動行追加
VXETable.interceptor.add('event.keydown', (params) => {
  const { $event, $table } = params
  if (
    $event.key === 'Enter' &&
    $table.getEditRecord()?.column.field === 'label' &&
    $table.props.id === 'jigyo-table3'
  ) {
    addRow($table.getCurrentRecord())
  }
})

function updateTableData() {
  emit('update:data', { ...props.data, ...form, kekkalist: getTableData() })
}

async function validateAll() {
  updateTableData()
  await validate()
  const errMap = await xTableRef.value?.validate(true)
  if (errMap) return Promise.reject()
}

defineExpose({ validate: validateAll })
</script>
