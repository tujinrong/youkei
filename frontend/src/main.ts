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
import VxeUI from 'vxe-pc-ui'
import 'vxe-pc-ui/lib/style.css'
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

  app.use(VxeUI).use(VxeTable)

  // グローバルディレクティブ v-fullwidth-limit を登録
  app.directive('fullwidth-limit', {
    mounted(el) {
      // 入力イベントを監視
      el.addEventListener('input', function (event) {
        // 入力最大文字数（全角は2桁、半角は1桁として計算）の取得
        const maxUnits = parseInt(el.getAttribute('maxlength'), 10)

        // 入力値を取得
        let value = el.value

        let totalUnits = 0 // 現在の合計ユニット数を初期化
        let processedValue = '' // 処理後の最終入力値

        // 文字ごとにループして、全角/半角の長さを計算
        for (let i = 0; i < value.length; i++) {
          let char = value[i]
          let charCode = char.charCodeAt(0)

          // 全角文字であるかを判断
          let isFullWidth =
            (charCode >= 0x3000 && charCode <= 0x303f) || // CJK 記号と句読点
            (charCode >= 0x3040 && charCode <= 0x30ff) || // 日本語ひらがなとカタカナ
            (charCode >= 0x4e00 && charCode <= 0x9fff) || // 漢字
            (charCode >= 0xff01 && charCode <= 0xff60) // 全角記号

          // 文字が全角なら2ユニット、半角なら1ユニットとして計算
          let charUnits = isFullWidth ? 2 : 1

          // もし合計ユニット数が最大制限を超える場合はループを終了
          if (totalUnits + charUnits > maxUnits) {
            break
          }

          // 合計ユニット数を更新し、処理後の値に文字を追加
          totalUnits += charUnits
          processedValue += char
        }

        // 入力値が処理後の値と異なる場合、入力値を更新
        if (el.value !== processedValue) {
          // requestAnimationFrameを使って、入力値を更新し再度inputイベントをトリガー
          window.requestAnimationFrame(() => {
            el.value = processedValue
            // Vueのv-modelと同期するためにinputイベントを発火
            el.dispatchEvent(new Event('input'))
          })
        }
      })
    },
  })

  app.mount('#app')
}

setupApp()
