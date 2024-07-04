import { Ref, nextTick, ref, unref, watchEffect } from 'vue'

/** Options連動 */
export default function useLinkOption(
  keyopts: Ref<DaSelectorKeyModel[]>,
  opts: Ref<DaSelectorModel[]>,
  val_key?: Ref<string | undefined>,
  val?: Ref<string | undefined>
) {
  const keyoptions = ref<DaSelectorKeyModel[]>([])
  const options = ref<DaSelectorModel[]>([])
  const keyoptionsMap = ref<Map<string, DaSelectorKeyModel[]>>(new Map())

  watchEffect(() => {
    keyoptions.value = keyopts.value
    options.value = opts.value
    //Map(performance optimization)
    keyoptionsMap.value = keyopts.value.reduce((acc, item) => {
      const { key } = item
      if (acc.has(key)) {
        acc.get(key).push(item)
      } else {
        acc.set(key, [item])
      }
      return acc
    }, new Map())
  })

  //編集時処理
  watchEffect(() => {
    if ((keyopts.value.length > 0, opts.value.length > 0)) {
      nextTick(() => {
        if (val?.value) {
          keyoptions.value = keyopts.value.filter((el) => {
            return [unref(val), unref(val)?.split(' : ')[0], ''].includes(el.key)
          })
        }
        if (val?.value && val_key?.value) {
          const findKeyOpt = keyopts.value.find((el) =>
            [unref(val), unref(val_key)?.split(' : ')[0]].includes(el.value)
          )
          //val_key is '' , all show
          if (findKeyOpt?.key === '') return

          options.value = opts.value.filter((el) => {
            return [unref(val), unref(val)?.split(' : ')[0]].includes(el.value)
          })
        }
      })
    }
  })

  function onChangeKeyOpt(val, opt: DaSelectorKeyModel) {
    if (opt?.key === '') {
      options.value = opts.value
      return
    }
    options.value = val ? opts.value.filter((i) => i.value === opt.key) : opts.value
  }
  function onChangeOpt(val, opt: DaSelectorModel) {
    // get from Map
    const alwaysShowOpts = keyoptionsMap.value.get('') ?? []
    keyoptions.value = val
      ? [...(keyoptionsMap.value.get(opt.value) ?? []), ...alwaysShowOpts]
      : keyopts.value
    // general method
    // keyoptions.value = val ? keyopts.value.filter((i) => i.key === opt.value || i.key === '') : keyopts.value
  }

  function resetOpts() {
    keyoptions.value = keyopts.value
    options.value = opts.value
  }

  return {
    keyoptions,
    options,
    onChangeKeyOpt,
    onChangeOpt,
    resetOpts
  }
}
