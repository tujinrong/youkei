import { Ref, computed } from 'vue'

/**フロントエンド フィルター */
export default function useTableFilter(
  tableList: Ref<any[]>,
  filterParams: { [prop: string]: any }
) {
  const filterData = computed(() => {
    return tableList.value.filter((el) => {
      const entries = Object.entries(filterParams)
      return entries.every(([key, value]) => el[key] === value || value === '')
    })
  })
  return {
    filterData
  }
}
