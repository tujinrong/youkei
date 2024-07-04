import { Ref, reactive, ref, unref, watch, nextTick } from 'vue'

export default function useSearch({
  service,
  params,
  source,
  listname = 'kekkalist',
  keyvalueflg = false
}: {
  service: (request) => Promise<CmSearchResponseBase & { [prop: string]: any }>
  params: Ref<{ [prop: string]: any }> | null
  source: Ref<{ [prop: string]: any }[]>
  /**結果一覧フィールド名 */
  listname?: string
  /**一覧データフラグ */
  keyvalueflg?: boolean
}) {
  const loading = ref(false)
  const totalCount = ref(0)
  const pageParams = reactive<CmSearchRequestBase>({
    pagesize: 25,
    pagenum: 1,
    orderby: 0
  })

  let stopflg = false

  watch(pageParams, () => {
    if ((source.value.length > 0 || totalCount.value > 0) && !stopflg) searchData()
  })

  const searchData = async () => {
    loading.value = true
    try {
      const res = await service({
        ...pageParams,
        ...unref(params)
      })

      if (res.totalpagecount < pageParams.pagenum) {
        stopflg = true
        pageParams.pagenum = 1
        nextTick(() => (stopflg = false))
      }

      totalCount.value = res.totalrowcount

      if (keyvalueflg) {
        source.value = res[listname].map((el: DataInfoVM[]) => {
          return Object.fromEntries(el.map((i) => [i.key, i.value]))
        })
      } else {
        source.value = res[listname]
      }
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
    pageParams.pagenum = 1
  }

  return {
    pageParams,
    totalCount,
    loading,
    searchData,
    clear
  }
}
