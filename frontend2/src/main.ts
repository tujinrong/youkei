import { createApp } from 'vue'
import './plugins/assets'
import {
  setupAppVersionNotification,
  setupDayjs,
  setupIconifyOffline,
  setupLoading,
  setupNProgress,
} from './plugins'
import { setupStore } from './store'
import { setupRouter } from './router'
import { setupI18n } from './locales'
import App from './App.vue'
import VxeTable from './vxetable'

async function setupApp() {
  setupLoading()

  setupNProgress()

  setupIconifyOffline()

  setupDayjs()

  const app = createApp(App)

  setupStore(app)

  await setupRouter(app)

  setupI18n(app)

  setupAppVersionNotification()

  app.use(VxeTable)

  app.mount('#app')
}

setupApp()
