<template>
  <a-modal v-model:visible="props.visible" :closable="false" width="500px" destroy-on-close>
    <a-form :model="formParam">
      <div class="description-table">
        <table style="border-top: 1px solid #c0c4cc">
          <tbody>
            <tr>
              <th style="width: 200px">タイプ</th>
              <td>
                <a-select
                  v-model:value="formParam.group"
                  :options="groupOptions"
                  style="width: 100%"
                  @change="handleGroupChange"
                ></a-select>
              </td>
            </tr>

            <tr>
              <th style="width: 200px">テーブル</th>
              <td v-if="formParam.group === GROUPENUM.テーブル">
                <a-select
                  v-model:value="formParam.tablenm"
                  show-search
                  style="width: 100%"
                  :options="tablelist"
                  @change="(value) => tableChange(value)"
                >
                  <template #option="{ label, value }">
                    {{ value + ' : ' + label }}
                  </template>
                </a-select>
              </td>
              <td v-else>
                <a-select
                  v-model:value="formParam.tablenm"
                  show-search
                  style="width: 100%"
                  :options="specialOptions"
                >
                </a-select>
              </td>
            </tr>

            <tr v-if="formParam.group === GROUPENUM.テーブル">
              <th style="width: 110px">項目名</th>
              <td>
                <a-select
                  v-model:value="formParam.projectName"
                  show-search
                  style="width: 100%"
                  :options="projectOptions"
                >
                  <template #option="{ label, value }">
                    {{ value + ' : ' + label }}
                  </template>
                </a-select>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </a-form>

    <template #footer>
      <a-button style="float: left" type="primary" @click="addInfo">確定</a-button>
      <a-button type="primary" @click="closeInfo">閉じる</a-button>
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
// import { SearchGroupTables, SearchGroupTableItems } from '../AWEU00201G/service'

enum GROUPENUM {
  'テーブル' = 1,
  '特殊項目'
}

const props = defineProps<{
  visible: boolean
  groupid: number
}>()

const emit = defineEmits(['update:visible', 'getToolData'])
const tablelist = ref<DaSelectorModel[]>([])
const projectOptions = ref<DaSelectorModel[]>([])
const formParam = ref<any>({
  tablenm: null,
  projectName: null,
  group: 1
})
const projectLoading = ref(false)
const groupOptions = ref([
  {
    label: GROUPENUM[GROUPENUM.テーブル],
    value: GROUPENUM.テーブル
  },
  {
    label: GROUPENUM[GROUPENUM.特殊項目],
    value: GROUPENUM.特殊項目
  }
])

const specialOptions = [
  {
    label: '出力日',
    value: '出力日'
  },
  {
    label: '基準日',
    value: '基準日'
  },
  {
    label: '帳票グループ',
    value: '帳票グループ'
  }
]

watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      // SearchGroupTables({ groupid: parseInt(props.groupid as unknown as string) }).then((res) => {
      //   tablelist.value = res.tablelist
      // })
    }
  }
)

const handleGroupChange = () => {
  formParam.value.projectName = null
  formParam.value.tablenm = null
}

const addInfo = () => {
  if (formParam.value.group === GROUPENUM.特殊項目) {
    formParam.value.projectName = formParam.value.tablenm
    formParam.value.tablenm = '@'
  }
  emit('getToolData', formParam.value)
  formParam.value = {
    tablenm: null,
    projectName: null,
    group: 1
  }
  projectOptions.value = []
  emit('update:visible', false)
}

const closeInfo = () => {
  emit('update:visible', false)
}

//テーブル変化イベント
const tableChange = (tableid) => {
  // projectLoading.value = true
  // SearchGroupTableItems({ groupid: props.groupid, tableid: tableid })
  //   .then((res) => {
  //     projectOptions.value = res.tableitemlist
  //   })
  //   .finally(() => {
  //     projectLoading.value = false
  //   })
}
</script>
<style lang="less" scoped></style>
