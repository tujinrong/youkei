<template>
  <div class="max-w-400">
    <h3 class="font-bold">
      検査方法／内訳コード
      <a-checkbox v-model:checked="data.kensahoho_setflg" :disabled="!isNew"></a-checkbox>
    </h3>
    <a-space>
      <a-button class="btn-round" type="primary" :disabled="!canEdit" @click="addRow()"
        >行追加</a-button
      >
      <a-button class="btn-round" type="primary" :disabled="!canDelete" @click="handleDeleteRow"
        >行削除</a-button
      >
    </a-space>
    <div :class="[canEdit && 'form', 'self_adaption_table mt-2 ml-1px']">
      <a-row>
        <a-col span="24">
          <th class="bg-readonly">メインコード名</th>
          <TD>{{ data.kensahoho_maincdnm }}</TD>
        </a-col>
        <a-col span="24">
          <th class="required">サブコード名</th>
          <td v-if="canEdit">
            <a-form-item v-bind="validateInfos.kensahoho_subcdnm">
              <a-input
                v-model:value="form.kensahoho_subcdnm"
                allow-clear
                maxlength="100"
                @change="updateTableData"
              />
            </a-form-item>
          </td>
          <TD v-else>{{ form.kensahoho_subcdnm }}</TD>
        </a-col>
      </a-row>
    </div>
    <vxe-table
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
          if (column.field === 'kensahohocd' && row.remoteflg) {
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
        field="kensahohocd"
        :edit-render="{ autofocus: 'input', autoselect: true }"
        :class-name="
          ({ row }) =>
            hasRepeated(row.kensahohocd, 'kensahohocd') ||
            ['0', '00'].includes(row.kensahohocd) ||
            !row.kensahohocd
              ? 'bg-errorcell'
              : ''
        "
      >
        <template #header>検査方法／内訳コード</template>
        <template #edit="{ row }">
          <a-input
            v-model:value="row.kensahohocd"
            maxlength="2"
            @change="row.kensahohocd = row.kensahohocd?.replaceAll(/[^0-9]/g, '')"
          ></a-input>
        </template>
      </vxe-column>
      <vxe-column
        field="kensahohonm"
        :edit-render="{ autofocus: '.ant-input', autoselect: true }"
        width="60%"
        :class-name="({ row }) => (!row.kensahohonm ? 'bg-errorcell' : '')"
      >
        <template #header>検査方法／内訳名</template>
        <template #edit="{ row }">
          <a-textarea
            v-model:value="row.kensahohonm"
            :maxlength="100"
            :auto-size="{ minRows: 1 }"
            type="text"
          ></a-textarea>
        </template>
      </vxe-column>
      <vxe-column
        field="kensahohoshortnm"
        title="略称"
        :edit-render="{ autofocus: '.ant-input', autoselect: true }"
        :resizable="false"
        :class-name="({ row }) => (!row.kensahohoshortnm ? 'bg-errorcell' : '')"
      >
        <template #edit="{ row }">
          <a-input v-model:value="row.kensahohoshortnm" :maxlength="3"></a-input>
        </template>
      </vxe-column>
    </vxe-table>
    <span class="float-right">(3文字まで)</span>
  </div>
</template>

<script setup lang="ts">
import TD from '@/components/Common/TableTD/index.vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { computed, onMounted, reactive, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { KensinDetailHohoVM } from '../../type'
import { useTable } from '@/utils/hooks'

const props = defineProps<{
  data: KensinDetailHohoVM
}>()
const emit = defineEmits(['update:data', 'change'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
//項目の設定
const rules = ref({
  kensahoho_subcdnm: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'サブコード名') }
  ],
  kensahohocd: [
    { required: true },
    {
      validator({ cellValue }) {
        if (hasRepeated(cellValue, 'kensahohocd') || ['0', '00'].includes(cellValue)) {
          return new Error()
        }
        return
      }
    }
  ],
  kensahohonm: [{ required: true }],
  kensahohoshortnm: [{ required: true }]
})

//サブコード
const form = reactive({ kensahoho_subcdnm: '' })
const { validate, validateInfos } = Form.useForm(form, rules)
onMounted(() => {
  form.kensahoho_subcdnm = props.data.kensahoho_subcdnm
})

//操作権限フラグ
const isNew = Number(route.query.jigyocd) < 0
const canEdit = computed(() => (isNew || route.meta.updflg) && props.data.kensahoho_setflg)
//行削除フラグ取得
const canDelete = computed(() => {
  return Boolean(currentRow.value && !currentRow.value.remoteflg) && canEdit.value
})

const xTableRef = ref<VxeTableInstance>()
const { hasRepeated, deleteRow, addRow, currentRow, getTableData } = useTable(
  xTableRef,
  'kensahohocd',
  'kensahohoshortnm'
)

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.data.kensahoho_setflg,
  () => {
    form.kensahoho_subcdnm = ''
    props.data.kekkalist = []
  }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

function updateTableData() {
  emit('update:data', { ...props.data, ...form, kekkalist: getTableData() })
  emit('change', getTableData())
}

async function handleDeleteRow() {
  await deleteRow()
  updateTableData()
}

async function validateAll() {
  updateTableData()
  if (props.data.kensahoho_setflg) {
    await validate()
    const errMap = await xTableRef.value?.validate(true)
    if (errMap) return Promise.reject()
  }
}

defineExpose({ validate: validateAll })
</script>
