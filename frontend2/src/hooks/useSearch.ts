import { Ref, reactive, ref, unref, watch, nextTick } from 'vue'

export default function useSearch({
  service,
  params,
  source,
  listname = 'kekkalist',
}: {
  service: (request) => Promise<CmSearchResponseBase & { [prop: string]: any }>
  params: Ref<{ [prop: string]: any }> | null
  source: Ref<{ [prop: string]: any }[]>
  /**結果一覧フィールド名 */
  listname?: string
}) {
  const loading = ref(false)
  const totalCount = ref(0)
  const pageParams = reactive<CmSearchRequestBase>({
    PAGE_SIZE: 25,
    PAGE_NUM: 1,
    ORDER_BY: 0,
  })

  let stopflg = false

  watch(pageParams, () => {
    if ((source.value.length > 0 || totalCount.value > 0) && !stopflg)
      searchData()
  })

  const searchData = async () => {
    loading.value = true
    try {
      const res = await service({
        ...pageParams,
        ...unref(params),
      })

      if (res.TOTAL_PAGE_COUNT < pageParams.PAGE_NUM) {
        stopflg = true
        pageParams.PAGE_NUM = 1
        nextTick(() => (stopflg = false))
      }

      totalCount.value = res.TOTAL_ROW_COUNT

      source.value = res[listname]
      loading.value = false
      return await Promise.resolve(res)
    } catch (error) {
      loading.value = false
      return await Promise.reject(error)
    }
  }

  const clear = () => {
    source.value = []
    totalCount.value = 0
    pageParams.PAGE_NUM = 1
  }

  return {
    pageParams,
    totalCount,
    loading,
    searchData,
    clear,
  }
}
