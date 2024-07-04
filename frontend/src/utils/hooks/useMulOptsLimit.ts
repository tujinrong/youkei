import { Ref, computed, unref } from 'vue'

/**複数選択のプルダウンボックスの選択数制限 */
export default function useMulOptsLimit(
  arrayValue: Ref<string[]>,
  options: Ref<DaSelectorModel[]>,
  limitCount: Ref<number> | number
) {
  const mulOpts = computed(() => {
    const opts: DaSelectorModel[] = JSON.parse(JSON.stringify(options.value))
    if (arrayValue.value.length >= unref(limitCount)) {
      for (const opt of opts) {
        if (!arrayValue.value.includes(opt.value)) {
          opt.disabled = true
        }
      }
      return opts
    }
    return options.value
  })

  return {
    mulOpts
  }
}
