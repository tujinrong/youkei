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
      let isComposing = false // 入力中の文字が入力法候補の状態にあるかどうかを追跡するフラグ

      // 入力法の候補が始まる時のイベント
      el.addEventListener('compositionstart', function () {
        isComposing = true // 入力法の候補選択が始まる
      })

      // 入力法の候補が確定した時のイベント
      el.addEventListener('compositionend', function (event) {
        isComposing = false // 入力法の候補選択が終わった
        handleInput(event) // 最終的な入力結果を処理する
      })

      // ユーザーが入力する際のイベント
      el.addEventListener('input', function (event) {
        if (!isComposing) {
          handleInput(event) // 入力法候補状態でない場合のみ入力を処理
        }
      })

      // 入力処理のロジック
      function handleInput(event) {
        // 入力フィールドの maxlength 属性から最大文字数を取得（全角は2単位、半角は1単位）
        const maxUnits = parseInt(el.getAttribute('maxlength'), 10)

        let value = el.value // 入力された値を取得
        let totalUnits = 0 // 現在の合計単位数を初期化
        let processedValue = '' // 処理後の最終入力値

        // 各文字をループして、全角/半角を判定し、文字数を計算
        for (let i = 0; i < value.length; i++) {
          let char = value[i]
          let charCode = char.charCodeAt(0)

          // 全角文字であるかを判定
          let isFullWidth =
            (charCode >= 0x3000 && charCode <= 0x303f) || // CJK 記号と句読点
            (charCode >= 0x3040 && charCode <= 0x30ff) || // 日本語ひらがなとカタカナ
            (charCode >= 0x4e00 && charCode <= 0x9fff) || // 漢字
            (charCode >= 0xff01 && charCode <= 0xff60) // 全角記号

          // 文字が全角なら2単位、半角なら1単位として計算
          let charUnits = isFullWidth ? 2 : 1

          // 最大単位数を超える場合はループを終了
          if (totalUnits + charUnits > maxUnits) {
            break
          }

          // 合計単位数を更新し、処理後の値に文字を追加
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
      }
    },
  })

  app.mount('#app')
}

setupApp()
