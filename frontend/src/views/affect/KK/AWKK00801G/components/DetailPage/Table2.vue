<template>
  <div class="max-w-400">
    <h3 class="font-bold">予約分類</h3>
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
          <TD>{{ data.yoyakubunrui_maincdnm }}</TD>
        </a-col>
        <a-col span="24">
          <th class="required">サブコード名</th>
          <td v-if="canEdit">
            <a-form-item v-bind="validateInfos.yoyakubunrui_subcdnm">
              <a-input
                v-model:value="form.yoyakubunrui_subcdnm"
                allow-clear
                maxlength="100"
                @change="updateTableData"
              />
            </a-form-item>
          </td>
          <TD v-else>{{ form.yoyakubunrui_subcdnm }}</TD>
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
          if (column.field === 'yoyakubunrui' && row.remoteflg) {
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
        field="yoyakubunrui"
        :edit-render="{ autofocus: 'input', autoselect: true }"
        :class-name="
          ({ row }) =>
            hasRepeated(row.yoyakubunrui, 'yoyakubunrui') ||
            ['0', '00'].includes(row.yoyakubunrui) ||
            !row.yoyakubunrui
              ? 'bg-errorcell'
              : ''
        "
        min-width="150"
        width="200"
      >
        <template #header>予約分類コード</template>
        <template #edit="{ row }">
          <a-input
            v-model:value="row.yoyakubunrui"
            maxlength="2"
            @change="row.yoyakubunrui = row.yoyakubunrui?.replaceAll(/[^0-9]/g, '')"
          ></a-input>
        </template>
      </vxe-column>
      <vxe-column
        field="yoyakubunruinm"
        :edit-render="{ autofocus: '.ant-input', autoselect: true }"
        min-width="110"
        :class-name="({ row }) => (!row.yoyakubunruinm ? 'bg-errorcell' : '')"
      >
        <template #header>予約分類名</template>
        <template #edit="{ row }">
          <a-textarea
            v-model:value="row.yoyakubunruinm"
            :maxlength="100"
            :auto-size="{ minRows: 1 }"
            type="text"
          ></a-textarea>
        </template>
      </vxe-column>
      <vxe-column
        field="yoyakubunruishortnm"
        title="表示用名"
        :edit-render="{ autofocus: '.ant-input', autoselect: true }"
        min-width="110"
        :class-name="({ row }) => (!row.yoyakubunruishortnm ? 'bg-errorcell' : '')"
      >
        <template #edit="{ row }">
          <a-textarea
            v-model:value="row.yoyakubunruishortnm"
            :auto-size="{ minRows: 1 }"
            :maxlength="3"
            type="text"
          ></a-textarea>
        </template>
      </vxe-column>
      <vxe-column
        field="yoyakubunruilist"
        title="検査方法／内訳コード"
        :edit-render="{ autofocus: '.ant-select-selection-search-input', autoselect: true }"
        min-width="110"
        :resizable="false"
        :class-name="({ row }) => (!row.yoyakubunruilist.length ? 'bg-errorcell' : '')"
      >
        <template #edit="{ row }">
          <a-select
            v-model:value="row.yoyakubunruilist"
            mode="multiple"
            max-tag-count="responsive"
            :options="options"
            style="width: 100%"
          >
            <template #option="{ label, value }">
              {{ value + ' : ' + label }}
            </template>
          </a-select>
        </template>
        <template #default="{ row }">
          {{ formatMulSelectValue(row.yoyakubunruilist) }}
        </template>
      </vxe-column>
    </vxe-table>
  </div>
</template>

<script setup lang="ts">
import TD from '@/components/Common/TableTD/index.vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { Form } from 'ant-design-vue'
import { computed, onMounted, reactive, ref, watch } from 'vue'
import { useRoute } from 'vue-router'
import { VxeTableInstance } from 'vxe-table'
import { KensinDetailHohoRowVM, KensinDetailYoyakuVM } from '../../type'
import { useTable } from '@/utils/hooks'

const props = defineProps<{
  data: KensinDetailYoyakuVM
  hoholist: KensinDetailHohoRowVM[]
  setflg: boolean
}>()
const emit = defineEmits(['update:data'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
//項目の設定
const rules = ref({
  yoyakubunrui_subcdnm: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'サブコード名') }
  ],
  yoyakubunrui: [
    { required: true },
    {
      validator({ cellValue }) {
        if (hasRepeated(cellValue, 'yoyakubunrui') || ['0', '00'].includes(cellValue)) {
          return new Error()
        }
        return
      }
    }
  ],
  yoyakubunruinm: [{ required: true }],
  yoyakubunruishortnm: [{ required: true }],
  yoyakubunruilist: [
    {
      validator({ cellValue }) {
        if (!cellValue.length) return new Error()
        return
      }
    }
  ]
})

//サブコード
const form = reactive({ yoyakubunrui_subcdnm: '' })
const { validate, validateInfos } = Form.useForm(form, rules)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  form.yoyakubunrui_subcdnm = props.data.yoyakubunrui_subcdnm
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.setflg,
  () => {
    form.yoyakubunrui_subcdnm = ''
    props.data.kekkalist = []
  }
)

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//操作権限フラグ
const isNew = Number(route.query.jigyocd) < 0
const canEdit = computed(() => (isNew || route.meta.updflg) && props.setflg)
//行削除フラグ取得
const canDelete = computed(() => {
  return Boolean(currentRow.value && !currentRow.value.remoteflg) && canEdit.value
})

//検査方法options
const options = computed(() => {
  return props.hoholist
    .map((item) => {
      return { label: item.kensahohonm, value: item.kensahohocd }
    })
    .filter((item) => item.value && item.label)
})

const xTableRef = ref<VxeTableInstance>()
const { hasRepeated, deleteRow, addRow, currentRow, getTableData } = useTable(
  xTableRef,
  'yoyakubunrui',
  'yoyakubunruilist',
  { yoyakubunruilist: [] }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

function updateTableData() {
  emit('update:data', { ...props.data, ...form, kekkalist: getTableData() })
}

//format 検査方法／内訳コード
function formatMulSelectValue(array: string[]) {
  let list: string[] = []
  for (const item of array) {
    const findEl = options.value.find((opt) => opt.value === item)
    if (findEl) list.push(findEl.label)
  }
  return list.join(',')
}

async function validateAll() {
  updateTableData()
  if (props.setflg) {
    await validate()
    const errMap = await xTableRef.value?.validate(true)
    if (errMap) return Promise.reject()
  }
}

defineExpose({ validate: validateAll })
</script>
