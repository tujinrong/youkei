<template>
  <div class="tab-2">
    <div class="justify-between flex-column-1480" style="width: 100%">
      <div class="">
        <a-tabs
          v-model:activeKey="activeKey"
          type="editable-card"
          class="highlight-tabs"
          @change="tabChange"
          @edit="tabAdd"
        >
          <template #rightExtra>
            <div class="">
              <a-button type="primary" shape="round">初期値セット</a-button>
            </div>
          </template>
          <a-tab-pane
            v-for="pane in pregnantPanes"
            :key="pane.key"
            :tab="pane.title"
            :closable="pregnantPanes.length > 1"
          >
            <div style="display: flex">
              <div style="display: flex; width: 100%" class="panel-edit flex-column width-92">
                <div v-if="!panelShow" class="panel-edit-mask mask-height"></div>
                <div
                  class="description-table m-t-1 header-description-table left-table"
                  style="width: 50%; border-right: none"
                >
                  <table>
                    <tbody>
                      <tr>
                        <th style="background-color: #ffffe1; width: 120px">健診回数</th>
                        <td colspan="4">{{ pane.name }}</td>
                        <th style="width: 110px">交付番号</th>
                        <td colspan="5">
                          <a-input
                            v-model:value="pane.deliveryNum"
                            style="width: 120px; margin-right: 10px"
                            show-search
                          >
                          </a-input>
                          <a-checkbox v-model:checked="pane.checked1">発行</a-checkbox>
                          <a-checkbox v-model:checked="pane.checked2">償還払</a-checkbox>
                        </td>
                      </tr>
                      <tr>
                        <th>受理年月日</th>
                        <td colspan="4">
                          <date-jp v-model:value="pane.receiptDate" style="width: 100%"></date-jp>
                          <!--                  <a-input-->
                          <!--                    v-model:value="tabPregnantForm.receiptDate"-->
                          <!--                    style="width: 100%"-->
                          <!--                    show-search-->
                          <!--                  >-->
                          <!--                  </a-input>-->
                        </td>
                        <th>受診年月日</th>
                        <td colspan="5">
                          <date-jp v-model:value="pane.visitDate" style="width: 160px"></date-jp>
                          <!--                  <a-input-->
                          <!--                    v-model:value="tabPregnantForm.visitDate"-->
                          <!--                    style="width: 150px"-->
                          <!--                    show-search-->
                          <!--                  >-->
                          <!--                  </a-input>-->
                          <span style="margin-left: 5px" class="m-r-1">満</span>
                          <a-input v-model:value="pane.week" style="width: 50px" show-search>
                          </a-input>
                          <span style="margin-left: 5px" class="m-r-1">週</span>
                        </td>
                      </tr>
                      <tr>
                        <th>実施機関</th>
                        <td colspan="6">
                          <ai-select
                            v-model:value="pane.organization"
                            :options="organizationOptions"
                            style="width: 75%"
                          ></ai-select>
                          <a-button
                            type="primary"
                            class="m-l-1"
                            shape="round"
                            @click="onSearchOrganization"
                            >検索</a-button
                          >
                        </td>
                        <th style="width: 90px">予算区分</th>
                        <td>
                          <ai-select
                            v-model:value="pane.budget"
                            style="width: 100%"
                            :options="budgetOptions"
                          ></ai-select>
                        </td>
                      </tr>
                      <tr>
                        <th>医師名</th>
                        <td colspan="6">
                          <ai-select
                            v-model:value="pane.doctor"
                            style="width: 100%"
                            :options="doctorOptions"
                          ></ai-select>
                        </td>
                        <th>検診方式</th>
                        <td>
                          <ai-select
                            v-model:value="pane.method"
                            style="width: 100%"
                            :options="methodOptions"
                          ></ai-select>
                        </td>
                      </tr>
                      <tr>
                        <th>血糖検査</th>
                        <td colspan="6">
                          <a-input v-model:value="pane.test" style="width: 45%" show-search>
                          </a-input
                          >mg／dl
                          <span style="margin-left: 5px" class="m-r-1">(食後</span>
                          <a-input v-model:value="pane.time" style="width: 50px" show-search>
                          </a-input>
                          <span style="margin-left: 5px" class="m-r-1">時間)</span>
                        </td>
                        <th style="width: 90px">グルコース</th>
                        <td colspan="2">
                          <a-input v-model:value="pane.glucose" style="width: 70%" show-search>
                          </a-input
                          >mg／dl
                        </td>
                      </tr>
                      <tr>
                        <th>間接クームス</th>
                        <td colspan="3">
                          <ai-select
                            v-model:value="pane.cooms"
                            style="width: 100%"
                            :options="coomseOptions"
                          ></ai-select>
                        </td>
                        <th>貧血</th>
                        <td colspan="2">
                          <ai-select
                            v-model:value="pane.anemia"
                            style="width: 100%"
                            :options="insuranceOptions"
                          ></ai-select>
                        </td>
                        <th>血色素検査</th>
                        <td>
                          <a-input v-model:value="pane.staining" style="width: 70%" show-search>
                          </a-input
                          >mg／dl
                        </td>
                      </tr>
                      <tr>
                        <th>HBs抗原</th>
                        <td colspan="3">
                          <ai-select
                            v-model:value="pane.hbs"
                            style="width: 100%"
                            :options="coomseOptions"
                          ></ai-select>
                        </td>
                        <th style="width: 110px">HCV抗体</th>
                        <td colspan="2">
                          <ai-select
                            v-model:value="pane.hcvAntibody"
                            style="width: 100%"
                            :options="coomseOptions"
                          ></ai-select>
                        </td>
                        <th>HCV抗原</th>
                        <td>
                          <ai-select
                            v-model:value="pane.hcvAntigen"
                            style="width: 100%"
                            :options="coomseOptions"
                          ></ai-select>
                        </td>
                      </tr>
                      <tr>
                        <th>梅毒血清検查</th>
                        <td colspan="3">
                          <ai-select
                            v-model:value="pane.assay"
                            style="width: 100%"
                            :options="coomseOptions"
                          ></ai-select>
                        </td>
                        <th>HIV</th>
                        <td colspan="2">
                          <ai-select
                            v-model:value="pane.hiv"
                            style="width: 100%"
                            :options="coomseOptions"
                          ></ai-select>
                        </td>
                        <th>風疹</th>
                        <td>
                          <ai-select
                            v-model:value="pane.rubella"
                            style="width: 100%"
                            :options="coomseOptions"
                          ></ai-select>
                        </td>
                      </tr>
                      <tr>
                        <th>トキソプラズマ</th>
                        <td colspan="3">
                          <ai-select
                            v-model:value="pane.toxoplasma"
                            style="width: 100%"
                            :options="coomseOptions"
                          ></ai-select>
                        </td>
                        <th>HTLV-1</th>
                        <td colspan="2">
                          <ai-select
                            v-model:value="pane.htlv"
                            style="width: 100%"
                            :options="coomseOptions"
                          ></ai-select>
                        </td>
                        <th>ATL</th>
                        <td>
                          <ai-select
                            v-model:value="pane.alt"
                            style="width: 100%"
                            :options="coomseOptions"
                          ></ai-select>
                        </td>
                      </tr>
                      <tr>
                        <th>子宮類がん細胞診</th>
                        <td colspan="3">
                          <ai-select
                            v-model:value="pane.cytology"
                            style="width: 100%"
                            :options="coomseOptions"
                          ></ai-select>
                        </td>
                        <th>クラミジア検査</th>
                        <td colspan="2">
                          <ai-select
                            v-model:value="pane.chlamydia"
                            style="width: 100%"
                            :options="coomseOptions"
                          ></ai-select>
                        </td>
                        <th>GBS</th>
                        <td>
                          <ai-select
                            v-model:value="pane.gbs"
                            style="width: 100%"
                            :options="coomseOptions"
                          ></ai-select>
                        </td>
                      </tr>
                      <tr>
                        <th>子宮がん検診</th>
                        <td colspan="3">
                          <ai-select
                            v-model:value="pane.screen"
                            style="width: 100%"
                            :options="screenOptions"
                          ></ai-select>
                        </td>
                        <th>疾患名</th>
                        <td colspan="4">
                          <ai-select
                            v-model:value="pane.disease"
                            style="width: 100%"
                            :options="diseaseOptions"
                          ></ai-select>
                        </td>
                      </tr>
                      <tr>
                        <th>超音波検査</th>
                        <td colspan="6">
                          <ai-select
                            v-model:value="pane.ultrasonic"
                            style="width: 120px"
                            :options="ultrasonicOptions"
                          ></ai-select>
                          発行番号
                          <a-input
                            v-model:value="pane.issueNum"
                            style="width: 80px; margin-right: 10px"
                            show-search
                          >
                          </a-input>
                          <a-checkbox v-model:checked="pane.checked3">発行</a-checkbox>
                        </td>
                        <th>超音波結果</th>
                        <td>
                          <ai-select
                            v-model:value="pane.ultrasonicResult"
                            style="width: 100%"
                            :options="ultrasonicResultOptions"
                          ></ai-select>
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
                <div
                  class="description-table m-t-1 header-description-table right-table"
                  style="width: 50%"
                >
                  <table>
                    <tbody>
                      <tr>
                        <th style="width: 80px">血圧</th>
                        <td colspan="4">
                          <a-input
                            v-model:value="pane.bloodPressure1"
                            style="width: 80px"
                            show-search
                          >
                          </a-input
                          >／
                          <a-input
                            v-model:value="pane.bloodPressure2"
                            style="width: 80px; margin-right: 5px"
                            show-search
                          >
                          </a-input
                          >nmHg (高／低)
                        </td>
                        <th>浮腫</th>
                        <td colspan="3">
                          <ai-select
                            v-model:value="pane.edema"
                            :options="edemaOptions"
                            style="width: 100%"
                          ></ai-select>
                        </td>
                      </tr>
                      <tr>
                        <th>体重</th>
                        <td colspan="3">
                          <a-input v-model:value="pane.weight" style="width: 80%" show-search>
                          </a-input>
                          <span style="margin-left: 5px" class="m-r-1">Kg</span>
                        </td>
                        <th style="width: 130px">胎児発育評価検査</th>
                        <td colspan="4">
                          <ai-select
                            v-model:value="pane.growth"
                            :options="growthOptions"
                            style="width: 100%"
                          ></ai-select>
                        </td>
                      </tr>
                      <tr>
                        <th>尿検査(糖)</th>
                        <td colspan="2">
                          <ai-select
                            v-model:value="pane.urineSugar"
                            style="width: 100%"
                            :options="urineSugarOptions"
                          ></ai-select>
                        </td>
                        <th style="width: 100px">尿検査(蛋白)</th>
                        <td>
                          <ai-select
                            v-model:value="pane.urineProtein"
                            style="width: 100%"
                            :options="urineSugarOptions"
                          ></ai-select>
                        </td>
                        <th style="width: 120px">尿検査(ケトン体)</th>
                        <td colspan="3">
                          <ai-select
                            v-model:value="pane.urineKetone"
                            style="width: 100%"
                            :options="urineSugarOptions"
                          ></ai-select>
                        </td>
                      </tr>
                      <tr>
                        <th>総合判定</th>
                        <td colspan="4">
                          <ai-select
                            v-model:value="pane.comprehensive"
                            style="width: 150px"
                            :options="comprehensiveOptions"
                          ></ai-select>
                        </td>
                        <th>入院</th>
                        <td colspan="3">
                          <ai-select
                            v-model:value="pane.hospitalization"
                            style="width: 100%"
                            :options="hospitalizationOptions"
                          ></ai-select>
                        </td>
                      </tr>
                      <tr>
                        <th>病名</th>
                        <td colspan="10">
                          <ai-select
                            v-model:value="pane.childbirthDelivery1"
                            style="width: 50%"
                            :options="childbirthDeliveryOptions"
                          ></ai-select>
                          <ai-select
                            v-model:value="pane.childbirthDelivery2"
                            style="width: 50%"
                            :options="childbirthDeliveryOptions"
                          ></ai-select>
                          <ai-select
                            v-model:value="pane.childbirthDelivery3"
                            style="width: 50%"
                            :options="childbirthDeliveryOptions"
                          ></ai-select>
                          <ai-select
                            v-model:value="pane.childbirthDelivery4"
                            style="width: 50%"
                            :options="childbirthDeliveryOptions"
                          ></ai-select>
                        </td>
                      </tr>
                      <tr>
                        <th>連絡事項(その他)</th>
                        <td colspan="10">
                          <ai-select
                            v-model:value="pane.matter"
                            style="width: 50%"
                            :options="matterOptions"
                          ></ai-select>
                          <ai-select
                            v-model:value="pane.matter2"
                            style="width: 50%"
                            :options="matterOptions"
                          ></ai-select>
                          <a-textarea
                            v-model:value="pane.expectedChildbirthDate"
                            placeholder=""
                            :rows="3"
                            size="small"
                            style="margin-top: 2px"
                          />
                        </td>
                      </tr>
                      <tr>
                        <th>備考</th>
                        <td colspan="10">
                          <a-textarea
                            v-model:value="pane.remarks"
                            placeholder=""
                            :rows="5"
                            size="small"
                          />
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </a-tab-pane>
        </a-tabs>
      </div>
    </div>

    <div class="description-table m-t-1 header-description-table panel-edit" style="width: 500px">
      <div v-if="!panelShow" class="panel-edit-mask mask-height"></div>
      <table>
        <tbody>
          <tr>
            <th style="background-color: #fafafa; width: 260px">項目</th>
            <th style="background-color: #fafafa">値</th>
          </tr>
          <tr v-for="item in dataList" :key="item">
            <th></th>
            <td>
              <a-input v-model:value="item.value" style="width: 100%" show-search> </a-input>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <OrganizeModal ref="organizeModalRef" @select="selectOrganize"></OrganizeModal>
  </div>
</template>
<!--妊婦健康診查情報-->
<script lang="ts" setup>
import { reactive, ref } from 'vue'
import { Modal } from 'ant-design-vue'
import OrganizeModal from '@/views/affect/AF/AWAF00702D/index.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const tabPregnantForm = reactive<any>({
  name: '',
  deliveryNum: '',
  checked1: '',
  checked2: '',
  receiptDate: '',
  visitDate: '',
  week: '',
  organization: '',
  budget: '',
  doctor: '',
  method: '',
  test: '',
  time: '',
  glucose: '',
  cooms: '',
  anemia: '',
  staining: '',
  hbs: '',
  hcvAntibody: '',
  hcvAntigen: '',
  assay: '',
  hiv: '',
  rubella: '',
  toxoplasma: '',
  htlv: '',
  alt: '',
  cytology: '',
  chlamydia: '',
  gbs: '',
  screen: '',
  disease: '',
  ultrasonic: '',
  issueNum: '',
  checked3: '',
  ultrasonicResult: '',
  bloodPressure1: '',
  bloodPressure2: '',
  edema: '',
  weight: '',
  growth: '',
  urineSugar: '',
  urineProtein: '',
  urineKetone: '',
  comprehensive: '',
  hospitalization: '',
  remarks: ''
})

const panelShow = ref(true)

const pregnantPanes = ref<any>([
  {
    name: '',
    deliveryNum: '',
    checked1: '',
    checked2: '',
    receiptDate: '',
    visitDate: '',
    week: '',
    organization: '',
    budget: '',
    doctor: '',
    method: '',
    test: '',
    time: '',
    glucose: '',
    cooms: '',
    anemia: '',
    staining: '',
    hbs: '',
    hcvAntibody: '',
    hcvAntigen: '',
    assay: '',
    hiv: '',
    rubella: '',
    toxoplasma: '',
    htlv: '',
    alt: '',
    cytology: '',
    chlamydia: '',
    gbs: '',
    screen: '',
    disease: '',
    ultrasonic: '',
    issueNum: '',
    checked3: '',
    ultrasonicResult: '',
    bloodPressure1: '',
    bloodPressure2: '',
    edema: '',
    weight: '',
    growth: '',
    urineSugar: '',
    urineProtein: '',
    urineKetone: '',
    comprehensive: '',
    hospitalization: '',
    remarks: '',
    index: 1,
    title: '01回目',
    key: 1
  }
])

const matterOptions = [
  { value: '', label: ' ' },
  { value: '01', label: '要安静' },
  { value: '02', label: '塩分制限' },
  { value: '03', label: '食事療法' },
  { value: '04', label: '特になし' },
  { value: '05', label: '要訪問' },
  { value: '99', label: 'その他' }
]
const childbirthDeliveryOptions = [
  { value: '', label: ' ' },
  { value: '01', label: '妊娠高血圧症候群' },
  { value: '02', label: '糖尿病（疑い含む）' },
  { value: '03', label: '貧血' },
  { value: '04', label: '心臓疾患' },
  { value: '05', label: '胎位異常' },
  { value: '06', label: '前置胎盤' }
]
const hospitalizationOptions = [
  { value: '', label: ' ' },
  { value: '1', label: '要' },
  { value: '2', label: '否' }
]
const comprehensiveOptions = [
  { value: '', label: ' ' },
  { value: '1', label: '異常なし' },
  { value: '2', label: '要指導' },
  { value: '3', label: '要観察' },
  { value: '4', label: '要精密' },
  { value: '5', label: '要治療' },
  { value: '6', label: '治療中' }
]
const urineSugarOptions = [
  { value: '', label: ' ' },
  { value: '0', label: '－' },
  { value: '1', label: '±' },
  { value: '2', label: '＋' },
  { value: '3', label: '２＋' },
  { value: '4', label: '３＋' },
  { value: '5', label: '４＋' },
  { value: '6', label: '生' },
  { value: '7', label: '未実施' }
]
const growthOptions = [
  { value: '', label: '' },
  { value: '01', label: ' 評価結果１' },
  { value: '02', label: '評価結果２' },
  { value: '03', label: '評価結果３' }
]
const edemaOptions = [
  { value: '', label: '' },
  { value: '0', label: '－' },
  { value: '1', label: '±' },
  { value: '2', label: '＋' },
  { value: '3', label: '＋＋' }
]
const ultrasonicOptions = [
  { value: '', label: '' },
  { value: '0', label: '実施' },
  { value: '1', label: '未実施' }
]
const ultrasonicResultOptions = [
  { value: '', label: '' },
  { value: '01', label: '異常なし' },
  { value: '02', label: '要観察' },
  { value: '03', label: ' 要精密' }
]
const diseaseOptions = [
  { value: '', label: '' },
  { value: '01', label: '子宮疾患名１' },
  { value: '02', label: '子宮疾患名２' },
  { value: '03', label: '子宮疾患名３' }
]
const screenOptions = [
  { value: '', label: '' },
  { value: '1', label: 'Ⅰ' },
  { value: '2', label: 'Ⅱ' },
  { value: '3', label: 'Ⅲａ' },
  { value: '4', label: 'Ⅲｂ' },
  { value: '5', label: 'Ⅳ' },
  { value: '6', label: 'Ⅴ' }
]
const organizationOptions = [
  { value: '', label: '' },
  { value: '0001', label: '医療機関0001' },
  { value: '0002', label: '医療機関0002' },
  { value: '9998', label: '医療機関9998' },
  { value: '9999', label: '医療機関9999' }
]
const budgetOptions = [
  { value: '', label: '' },
  { value: '1', label: '交付金' },
  { value: '2', label: '地方交付金' }
]
const doctorOptions = [
  { value: '', label: '' },
  { value: '000001', label: '佐伯　花子' },
  { value: '001005', label: '佐藤　花' }
]
const methodOptions = [
  { value: '', label: '' },
  { value: '1', label: '集団' },
  { value: '2', label: '個別' }
]
const coomseOptions = [
  { value: '', label: '' },
  { value: '1', label: '陰性' },
  { value: '2', label: '陽性' },
  { value: '3', label: '実施した' },
  { value: '4', label: '実施せず' }
]
const insuranceOptions = [
  { value: '', label: '' },
  { value: '0', label: 'なし' },
  { value: '1', label: 'あり' }
]

const dataList = ref([
  { content: '', value: '' },
  { content: '', value: '' },
  { content: '', value: '' },
  { content: '', value: '' },
  { content: '', value: '' },
  { content: '', value: '' },
  { content: '', value: '' },
  { content: '', value: '' },
  { content: '', value: '' }
])
const activeKey = ref(pregnantPanes.value[0].key)
const newPregnantTabIndex = ref(0)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const tabChange = (val) => {
  tabPregnantForm.name = val
}
//実施機関
const organizeModalRef = ref()
const onSearchOrganization = (value) => {
  organizeModalRef.value.openModal()
}
const selectOrganize = (val: any) => {
  tabPregnantForm.organization = val.kikannm
}

const tabAdd = (targetKey: string | MouseEvent, action: string) => {
  if (action === 'add') {
    addPregnantExamination()
  } else {
    removePregnantExamination(targetKey as string)
  }
}

const removePregnantExamination = (targetKey: string) => {
  Modal.confirm({
    title: '確認',
    content: '削除しますか？',
    okText: 'は い',
    cancelText: 'いいえ',
    okButtonProps: {
      danger: true
    },
    onOk() {
      let lastIndex = 0
      pregnantPanes.value.forEach((pane, i) => {
        if (pane.key === targetKey) {
          lastIndex = i - 1
        }
      })
      pregnantPanes.value = pregnantPanes.value.filter((pane) => pane.key !== targetKey)
      if (pregnantPanes.value.length && activeKey.value === targetKey) {
        if (lastIndex >= 0) {
          activeKey.value = pregnantPanes.value[lastIndex].key
        } else {
          activeKey.value = pregnantPanes.value[0].key
        }
      }
    },
    onCancel() {
      console.log('Cancel')
    }
  })
}

const addPregnantExamination = () => {
  Modal.confirm({
    title: '確認',
    content: '追加しますか？',
    okText: 'はい',
    cancelText: 'いいえ',
    onOk() {
      activeKey.value = `newTab${++newPregnantTabIndex.value}`
      let index = pregnantPanes.value.length + 1
      pregnantPanes.value.push({
        name: '',
        deliveryNum: '',
        checked1: '',
        checked2: '',
        receiptDate: '',
        visitDate: '',
        week: '',
        organization: '',
        budget: '',
        doctor: '',
        method: '',
        test: '',
        time: '',
        glucose: '',
        cooms: '',
        anemia: '',
        staining: '',
        hbs: '',
        hcvAntibody: '',
        hcvAntigen: '',
        assay: '',
        hiv: '',
        rubella: '',
        toxoplasma: '',
        htlv: '',
        alt: '',
        cytology: '',
        chlamydia: '',
        gbs: '',
        screen: '',
        disease: '',
        ultrasonic: '',
        issueNum: '',
        checked3: '',
        ultrasonicResult: '',
        bloodPressure1: '',
        bloodPressure2: '',
        edema: '',
        weight: '',
        growth: '',
        urineSugar: '',
        urineProtein: '',
        urineKetone: '',
        comprehensive: '',
        hospitalization: '',
        remarks: '',
        index: index,
        title: index < 10 ? '0' + index + '回目' : index + '01回目',
        key: activeKey.value
      })
    },
    onCancel() {
      console.log('Cancel')
    }
  })
}
</script>
<style scoped>
.mask-height {
  height: 100vh;
}
</style>
