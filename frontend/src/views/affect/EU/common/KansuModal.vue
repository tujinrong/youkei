<template>
  <!-- <a-modal v-model:visible="props.visible" :closable="false" width="800px" destroy-on-close>
    <a-form>
      <div class="description-table">
        <table style="border-top: 1px solid #c0c4cc">
          <tbody>
            <tr>
              <th style="width: 110px">入力区分</th>
              <td>
                <a-select v-model:value="type" :options="selectOptions" style="width: 100%">
                </a-select>
              </td>
            </tr>
            <template v-if="type == FUNC_ENUM.関数">
              <tr>
                <th>関数名</th>
                <td>
                  <a-select
                    v-model:value="func"
                    :options="funcOptions"
                    style="width: 100%"
                  ></a-select>
                </td>
              </tr>
              <tr v-if="!!func">
                <th>パラメータ</th>
                <td class="p-0!">
                  <template v-if="func">
                    <table>
                      <tr v-for="(item, index) in funcDataSource" :key="item.name">
                        <th>
                          {{ item.name }}
                          <a-button type="primary" @click="handleTool(index)">ツール</a-button>
                        </th>
                        <td>
                          <a-input v-model:value="item.value" style="width: 100%; height: 36px" />
                        </td>
                      </tr>
                    </table>
                  </template>
                </td>
              </tr>
            </template>
            <template v-if="type == FUNC_ENUM.テーブル">
              <tr v-if="props.tablemeisyo">
                <th style="width: 110px">テーブル</th>
                <td>
                  <a-input
                    disabled
                    v-model:value="props.tablemeisyo"
                    style="width: 100%; height: 36px"
                  />
                </td>
              </tr>
              <tr v-else>
                <th style="width: 110px">テーブル</th>
                <td>
                  <a-select
                    v-model:value="tablenm"
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
              </tr>

              <tr>
                <th style="width: 110px">項目名</th>
                <td>
                  <a-select
                    v-model:value="projectname"
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
            </template>
            <template v-if="type == FUNC_ENUM.特殊項目">
              <tr>
                <th style="width: 110px">項目名</th>
                <td>
                  <a-select
                    v-model:value="projectname"
                    show-search
                    style="width: 100%"
                    :options="specialOptions"
                  >
                  </a-select>
                </td>
              </tr>
            </template>
          </tbody>
        </table>
      </div>
    </a-form>
    <template #footer>
      <a-button style="float: left" type="primary" @click="addInfo">確定</a-button>
      <a-button type="primary" @click="closeInfo">閉じる</a-button>
    </template>
  </a-modal>
  <ToolModal
    v-model:visible="toolVisible"
    :groupid="props.groupid"
    @get-tool-data="getToolData"
  ></ToolModal> -->
</template>

<script setup lang="ts">
// import { ref, watch, computed } from 'vue'
// import { FunctionVM, Param } from '../AWEU00103G/type'
// import { FUNC_ENUM, SELECT_OPTIONS } from '../AWEU00201G/constants'
// import ToolModal from './ToolModal.vue'
// import { table } from 'console'
// // import { SearchGroupTableItems, SearchGroupTables } from '../AWEU00201G/service'
// const FUNC_REGEXP = /FROM\s+([^\s(]+)\s*\(/i
// const props = defineProps<{
//   visible: boolean
//   tablemeisyo: string
//   tableid: string
//   func: string
//   projectid: string
//   eucfunctionlist: FunctionVM[]
//   groupid: number
//   sql: string
// }>()
// const emit = defineEmits(['update:visible', 'update:sql'])
// const specialOptions = [
//   {
//     label: '出力日',
//     value: '出力日'
//   },
//   {
//     label: '基準日',
//     value: '基準日'
//   },
//   {
//     label: '帳票グループ',
//     value: '帳票グループ'
//   }
// ]
// const funcDataSource = ref<(Param & { value: string })[]>([])
// const selectOptions = ref(SELECT_OPTIONS)
// const toolVisible = ref(false)
// const toolIndex = ref<number>(-1)
// const type = ref()
// const projectname = ref()
// const func = ref(props.func)
// const projectOptions = ref<DaSelectorModel[]>([])
// const tablelist = ref<DaSelectorModel[]>([])
// const tablenm = ref()
// const funcOptions = computed(() => {
//   if (props.eucfunctionlist?.length === 0) return []
//   return props.eucfunctionlist?.map((item) => ({
//     label: `${item.description ? item.name + ' : ' + item.description : item.name}`,
//     value: item.sqltemplate
//   }))
// })

// watch(
//   () => func.value,
//   () => {
//     if (func.value) {
//       const item = props.eucfunctionlist.find((item) => item.sqltemplate === func.value)
//       if (item) {
//         funcDataSource.value = item.conditionparams?.map((item) => ({ ...item, value: '' }))
//       }
//     }
//   }
// )

// watch(
//   () => type.value,
//   () => {
//     projectname.value = ''
//   }
// )
// const getFuncVal = () => {
//   if (props.sql) {
//     const match = props.sql.match(FUNC_REGEXP)
//     if (match) {
//       func.value = funcOptions.value.find((item) => item.label.includes(match[1]))?.value ?? ''
//     }
//   }
// }
// watch(() => props.sql, getFuncVal)
// watch(() => props.eucfunctionlist, getFuncVal)

// const handleTool = (index: number) => {
//   toolIndex.value = index
//   toolVisible.value = true
// }

// const getToolData = (value) => {
//   if (toolIndex.value < 0) return
//   funcDataSource.value[toolIndex.value].value =
//     value?.group === 2
//       ? `${value?.tablenm}${value.projectName}`
//       : `${value?.tablenm}.${value.projectName}`
// }

// const addInfo = () => {
//   let sql = ''
//   switch (type.value) {
//     case FUNC_ENUM.関数:
//       sql = funcDataSource.value.reduce((prev, cur) => {
//         return (prev || func.value).replaceAll(`@${cur.name}`, cur.value)
//       }, '')
//       break
//     case FUNC_ENUM.テーブル:
//       // case FUNC_ENUM.特殊項目:
//       sql = `${tablenm.value}.${projectname.value}`
//       break
//   }
//   emit('update:sql', sql)
//   emit('update:visible', false)
// }

// const closeInfo = () => {
//   emit('update:visible', false)
// }

// const get = () => {
//   if (!props.visible) {
//     type.value = ''
//     func.value = ''
//     tablenm.value = ''
//     projectname.value = ''
//     return
//   }
//   if (!props.tablemeisyo) {
//     // SearchGroupTables({ groupid: parseInt(props.groupid as unknown as string) }).then((res) => {
//     //   tablelist.value = res.tablelist
//     // })
//     return
//   }
//   tablenm.value = props.tableid
//   // SearchGroupTableItems({ groupid: props.groupid, tableid: props.tableid }).then((res) => {
//   //   projectOptions.value = res.tableitemlist
//   // })
// }

// watch(() => props.visible, get)

// //テーブル変化イベント
// const tableChange = (tableid) => {
//   projectname.value = ''
//   projectOptions.value = []
//   // SearchGroupTableItems({ groupid: props.groupid, tableid: tableid }).then((res) => {
//   //   projectOptions.value = res.tableitemlist
//   // })
// }
</script>
<style lang="less" scoped></style>
