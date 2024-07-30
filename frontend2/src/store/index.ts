import { reactive, type App } from 'vue'
import { createPinia } from 'pinia'
import { resetSetupStore } from './plugins'

/** Setup Vue store plugin pinia */
export function setupStore(app: App) {
  const store = createPinia()

  store.use(resetSetupStore)

  app.use(store)
}

export const judgeStore = reactive<{
  [prop: string]: boolean | undefined
}>({})
