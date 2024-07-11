/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: システム初期化
 * 　　　　　  ベースロジック
 * 作成日　　: 2023.04.05
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import setupDefaultSetting from '@/utils/setup-default-setting'
import VXETable from './vxetable'
import Antd from 'ant-design-vue'
import 'ant-design-vue/dist/antd.variable.min.css'
import '@/style/global.less'
import 'virtual:svg-icons-register'
import 'virtual:uno.css'

import DateJp from '@/components/Selector/DateJp/index.vue'
import AiSelect from '@/components/Selector/AiSelect/index.vue'
import AiInput from '@/components/Selector/AiInput/index.vue'
import ClosePage from '@/components/Button/ClosePage/index.vue'
import CloseModalBtn from '@/components/Button/CloseModal/index.vue'
import TD from '@/components/Common/TableTD/index.vue'

const app = createApp(App)
app.use(Antd)
app.use(router)
app.use(store)
app.component('DateJp', DateJp)
app.component('AiSelect', AiSelect)
app.component('AiInput', AiInput)
app.component('ClosePage', ClosePage)
app.component('CloseModalBtn', CloseModalBtn)
app.component('TD', TD)
app.use(VXETable)
app.mount('#app')

app.config.globalProperties.$pagesizes = ['10', '25', '50', '100']
declare module 'vue' {
  interface ComponentCustomProperties {
    $pagesizes: string[]
  }
}

setupDefaultSetting()
