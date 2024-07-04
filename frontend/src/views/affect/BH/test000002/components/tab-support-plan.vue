<template>
  <div class="description-table">
    <table>
      <tbody>
        <tr>
          <th style="width: 100px">特定妊婦</th>
          <td style="display: flex; justify-content: space-between">
            <ai-select
              v-model:value="specificPregnantWoman"
              :options="pregnantWomanOptions"
              style="width: 220px"
              @change="onChange"
            ></ai-select>
            <a-button type="primary" class="btn-round">帳票出力</a-button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
  <div>
    <a-tabs v-model:activeKey="activeKeyCollapse1" class="highlight-tabs m-t-1" type="card">
      <a-tab-pane key="1" tab="特定妊婦チェックリスト">
        <div class="description-table">
          <table class="first-table">
            <tbody>
              <tr>
                <th>①育児への不安</th>
                <th>⑤若年出産</th>
                <th class="border-right">⑨経済的状況・基盤</th>
              </tr>
              <tr>
                <td>
                  <div class="checkbox-border">
                    <a-checkbox-group
                      v-model:value="checkList.childCareValue"
                      :options="childCareOptions"
                    />
                  </div>
                  <div class="div-border"></div>
                </td>
                <td>
                  <div class="checkbox-border">
                    <a-checkbox v-model:value="checkList.lowAgeValue">19歳以下</a-checkbox>
                  </div>
                  <div class="div-border"></div>
                </td>
                <td class="border-right">
                  <div class="checkbox-border">
                    <a-checkbox-group
                      v-model:value="checkList.economyValue"
                      :options="economyOptions"
                    />
                  </div>
                  <div class="div-border"></div>
                </td>
              </tr>
              <tr>
                <th>②母親の合併症</th>
                <th>⑥知的障害</th>
                <th class="border-right">⑩母子手帳交付が16週以降</th>
              </tr>
              <tr>
                <td>
                  <div class="checkbox-border">
                    <a-checkbox-group v-model:value="checkList.momValue" :options="momOptions" />
                  </div>
                  <div class="div-border"></div>
                </td>
                <td>
                  <div class="checkbox-border">
                    <a-checkbox-group v-model:value="checkList.witValue" :options="witOptions" />
                  </div>
                  <div class="div-border"></div>
                </td>
                <td class="border-right">
                  <div class="checkbox-border">
                    <a-checkbox-group
                      v-model:value="checkList.guideValue"
                      :options="guideOptions"
                    />
                  </div>
                  <div class="div-border"></div>
                </td>
              </tr>
              <tr>
                <th>③母親の精神疾患</th>
                <th>⑦高齢初産</th>
                <th class="border-right">⑪虐待·被虐待歴</th>
              </tr>
              <tr>
                <td>
                  <div class="checkbox-border">
                    <a-checkbox-group
                      v-model:value="checkList.mentalValue"
                      :options="mentalOptions"
                    />
                  </div>
                  <div class="div-border"></div>
                </td>
                <td>
                  <div class="checkbox-border">
                    <a-checkbox v-model:value="checkList.highAgeValue"
                      >40歳以上で他の項目に該当あり</a-checkbox
                    >
                  </div>
                  <div class="div-border"></div>
                </td>
                <td class="border-right">
                  <div class="checkbox-border">
                    <a-checkbox-group
                      v-model:value="checkList.abuseAgeValue"
                      :options="abuseAgeOptions"
                    />
                  </div>
                  <div class="div-border"></div>
                </td>
              </tr>
              <tr>
                <th>④養育能力等</th>
                <th>⑧家族形態の変化</th>
                <th class="border-right">⑫家庭内の問題</th>
              </tr>
              <tr>
                <td>
                  <div class="checkbox-border">
                    <a-checkbox-group
                      v-model:value="checkList.raiseValue"
                      :options="raiseOptions"
                    />
                  </div>
                  <div class="div-border"></div>
                </td>
                <td>
                  <div class="checkbox-border">
                    <a-checkbox-group
                      v-model:value="checkList.familyValue"
                      :options="familyOptions"
                    />
                  </div>
                  <div class="div-border"></div>
                </td>
                <td class="border-right">
                  <div class="checkbox-border">
                    <a-checkbox-group v-model:value="checkList.qaValue" :options="qaOptions" />
                  </div>
                  <div class="div-border"></div>
                </td>
              </tr>
              <tr style="border-bottom: none">
                <th>⑬その他</th>
                <td colspan="3" class="border-right">
                  <a-textarea v-model:value="checkList.other" :rows="2" />
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </a-tab-pane>
      <a-tab-pane key="2" tab="支援計画" class="tab-4-2">
        <div class="description-table width-100" style="width: 80%">
          <table>
            <tbody>
              <tr>
                <th style="width: 100px">計画作成日</th>
                <td style="width: 180px">
                  <!--                  <a-date-picker v-model:value="supportparam.planCreationDay" />-->
                  <date-jp v-model:value="supportparam.planCreationDay"></date-jp>
                </td>

                <th style="width: 100px">主な計画方法</th>
                <td>
                  <ai-select
                    v-model:value="supportparam.mainWay"
                    :options="mainWayOptions"
                    style="width: 120px"
                  ></ai-select>
                </td>

                <th style="width: 100px">計画作成者</th>
                <td>
                  <ai-select
                    v-model:value="supportparam.planMaker"
                    :options="planMakerOptions"
                    style="width: 180px"
                  ></ai-select>
                </td>

                <th style="width: 100px">ランク</th>
                <td>
                  <a-input v-model:value="supportparam.rank" style="width: 100%; min-width: 120px">
                  </a-input>
                </td>
              </tr>
              <tr>
                <th style="width: 100px">総合的な課題</th>
                <td colspan="3">
                  <a-textarea v-model:value="supportparam.integration" :rows="3" />
                </td>

                <th style="width: 100px">目標と具体策の提案</th>
                <td colspan="3">
                  <a-textarea v-model:value="supportparam.goal" :rows="3" />
                </td>
              </tr>
            </tbody>
          </table>
        </div>
        <div style="display: flex" class="flex-column-reverse">
          <div
            class="m-t-1 table-list"
            style="
              width: 90%;
              border: 1px solid #d2d0d0;
              height: 600px;
              overflow-y: auto;
              overflow-x: hidden;
            "
          >
            <div
              v-for="(item, index) in tableList"
              :key="index"
              style="padding: 5px 0"
              :class="type == index && type != null ? 'active-bg' : ''"
              @click="chooseTable(item, index)"
            >
              <div class="flex">
                <div
                  style="
                    width: 60px;
                    height: 20px;
                    line-height: 20px;
                    background: #ffffe1;
                    border: 1px solid #606266;
                    text-align: center;
                  "
                >
                  プラン
                </div>
                <div
                  style="
                    width: 60px;
                    height: 20px;
                    line-height: 20px;
                    border: 1px solid #606266;
                    text-align: center;
                  "
                >
                  {{ tableList.length - index }}
                </div>
              </div>
              <div class="description-table">
                <table>
                  <tbody>
                    <tr>
                      <th style="width: 80px">計画日時</th>
                      <td>
                        <div class="flex justify-between">
                          <date-jp v-model:value="item.planTime" style="width: 160px"></date-jp>
                          <a-time-picker v-model:value="item.time1" style="width: 100px" />
                        </div>
                        <!--                        <a-date-picker v-model:value="item.planTime" :show-time="true" />-->
                      </td>
                      <th style="width: 60px">方法</th>
                      <td>
                        <ai-select
                          v-model:value="item.planWay"
                          :options="mainWayOptions"
                          style="width: 160px"
                        ></ai-select>
                      </td>
                      <th style="width: 60px">担当者</th>
                      <td>
                        <div
                          style="display: flex; justify-content: space-between"
                          class="flex-column-1371"
                        >
                          <div style="margin: auto 0" class="planMaker-m-l">
                            <ai-select
                              v-model:value="item.planner"
                              :options="planMakerOptions"
                              style="width: 160px"
                            ></ai-select>
                          </div>
                          <div style="margin: auto 0" class="type-m-t">
                            <span>離型</span>
                            <ai-select
                              v-model:value="item.type"
                              :options="typeOptions"
                              class="m-l-1"
                              style="width: 160px"
                            ></ai-select>
                            <a-button type="primary" shape="round" class="btn-m-l">選択</a-button>
                          </div>
                        </div>
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 80px">計画内容</th>
                      <td colspan="10">
                        <a-textarea v-model:value="item.planContent" :rows="2" />
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 60px">支援日時</th>
                      <td>
                        <div class="flex justify-between">
                          <date-jp v-model:value="item.supportTime" style="width: 160px"></date-jp>
                          <a-time-picker v-model:value="item.time2" style="width: 100px" />
                        </div>
                        <!--                        <a-date-picker v-model:value="item.supportTime" show-time />-->
                      </td>
                      <th style="width: 60px">方法</th>
                      <td>
                        <ai-select
                          v-model:value="item.supportWay"
                          :options="mainWayOptions"
                          style="width: 160px"
                        ></ai-select>
                      </td>
                      <th style="width: 60px">担当者</th>
                      <div class="flex" style="justify-content: space-between">
                        <td style="flex: 0">
                          <ai-select
                            v-model:value="item.Supporter"
                            :options="planMakerOptions"
                            style="width: 160px"
                          ></ai-select>
                        </td>
                        <div style="margin: auto 0">
                          <a-button type="primary" shape="round">計画コピー</a-button>
                        </div>
                      </div>
                    </tr>
                    <tr>
                      <th style="width: 80px">支援内容</th>
                      <td colspan="10">
                        <a-textarea v-model:value="item.supportContent" :rows="2" />
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 80px">評価日</th>
                      <td width="160px">
                        <date-jp v-model:value="item.tickingDate"></date-jp>
                        <!--                        <a-date-picker v-model:value="item.tickingDate" />-->
                      </td>
                      <th style="width: 60px">評価者</th>
                      <td>
                        <ai-select
                          v-model:value="item.evaluator"
                          :options="planMakerOptions"
                          style="width: 160px"
                        ></ai-select>
                      </td>
                      <th style="width: 60px">結果</th>
                      <td style="flex: 0">
                        <ai-select
                          v-model:value="item.tickingResults"
                          :options="tickingResultsOptions"
                          style="width: 170px"
                        ></ai-select>
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 60px">評価内容</th>
                      <td colspan="10">
                        <a-textarea v-model:value="item.tickingContent" :rows="2" />
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>
          <div class="m-t-1 right-btn">
            <a-button
              class="btn-round add-btn"
              style="margin: 0 0 0 30px"
              type="primary"
              @click="addTable()"
              >追加</a-button
            ><br />
            <a-button
              class="btn-round m-t-1 del-btn"
              style="margin: 0 0 0 30px"
              type="primary"
              @click="delTable()"
              >削除</a-button
            >
          </div>
        </div>
      </a-tab-pane>
      <a-tab-pane key="3" tab="支援計画の総合結果·評価入力">
        <div class="description-table">
          <table>
            <tbody>
              <tr>
                <th style="width: 100px">評価年月日</th>
                <td>
                  <date-jp v-model:value="evaluationParam.evaluationDate"></date-jp>
                  <!--                  <a-date-picker v-model:value="evaluationParam.evaluationDate" />-->
                </td>
                <th style="width: 100px">評価者</th>
                <td>
                  <ai-select
                    v-model:value="evaluationParam.evaluator"
                    style="width: 220px"
                    :options="planMakerOptions"
                  >
                  </ai-select>
                </td>
                <th style="width: 100px">評価結果</th>
                <td>
                  <ai-select
                    v-model:value="evaluationParam.evaluationResults"
                    style="width: 220px"
                    :options="tickingResultsOptions"
                  >
                  </ai-select>
                </td>
              </tr>
              <tr>
                <th style="width: 100px">評価内容</th>
                <td colspan="10">
                  <a-textarea v-model:value="evaluationParam.evaluationContent" :rows="3" />
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </a-tab-pane>
    </a-tabs>
  </div>
</template>

<script lang="ts" setup>
import { reactive, ref, watch, defineComponent } from 'vue'
import { FormState } from '@/views/user/types'
import type { Dayjs } from 'dayjs'
import { Modal } from 'ant-design-vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const emit = defineEmits(['isEdit'])
const activeKeyCollapse1 = ref('1')
const specificPregnantWoman = ref('')
const momOptions = ref([
  {
    value: 0,
    label: '妊娠高血圧症'
  },
  {
    value: 1,
    label: '糖尿病'
  },
  {
    value: 2,
    label: '腎疾患'
  },
  {
    value: 3,
    label: '心疾患'
  },
  {
    value: 4,
    label: '甲状腺疾患'
  },
  {
    value: 5,
    label: 'その他'
  }
])
const childCareOptions = ref([
  {
    value: 0,
    label: '慢性的ストレス状態'
  },
  {
    value: 1,
    label: '望まない妊娠'
  },
  {
    value: 2,
    label: '情緒不安定'
  },
  {
    value: 3,
    label: '衡動的'
  },
  {
    value: 4,
    label: '強い育児不安'
  },
  {
    value: 5,
    label: 'その他'
  }
])
const economyOptions = ref([
  {
    value: 0,
    label: '経済不安'
  },
  {
    value: 1,
    label: '生活苦'
  },
  {
    value: 2,
    label: '無職'
  },
  {
    value: 3,
    label: '不安定就労'
  },
  {
    value: 4,
    label: '計画性の欠如(キャンプル・借金等)'
  },
  {
    value: 5,
    label: '生活保護'
  },
  {
    value: 6,
    label: 'その他'
  }
])
const witOptions = ref([
  {
    value: 0,
    label: 'こどもの養育上の問題認識(自覚)がない'
  },
  {
    value: 1,
    label: '共感性に乏しい'
  },
  {
    value: 2,
    label: '子どもより親の要求を優先'
  },
  {
    value: 3,
    label: 'その他'
  }
])
const guideOptions = ref([
  {
    value: 0,
    label: '初回健診磁気が妊娠中期以降'
  },
  {
    value: 1,
    label: '飛び込み出産'
  },
  {
    value: 2,
    label: '脱落分娩'
  }
])
const mentalOptions = ref([
  {
    value: 0,
    label: '過去の精神科·心療内科通院歴あり'
  },
  {
    value: 1,
    label: '現在服薬中の精神疾患'
  },
  {
    value: 2,
    label: '妊娠がわかって服薬中止'
  }
])
const abuseAgeOptions = ref([
  {
    value: 0,
    label: '兄弟児が要保護児童'
  },
  {
    value: 1,
    label: '母が被虐待歴有'
  },
  {
    value: 2,
    label: 'よく怒る'
  },
  {
    value: 3,
    label: '攻撃的'
  },
  {
    value: 4,
    label: '衝動的'
  },
  {
    value: 5,
    label: '体罰の容認'
  },
  {
    value: 6,
    label: '自己中心的'
  },
  {
    value: 7,
    label: '社会的未熟な性格'
  }
])
const raiseOptions = ref([
  {
    value: 0,
    label: '発達理解なし'
  },
  {
    value: 1,
    label: '育児理解なし'
  },
  {
    value: 2,
    label: '家事能力が低い'
  },
  {
    value: 3,
    label: '依存的'
  },
  {
    value: 4,
    label: '育児放棄'
  },
  {
    value: 5,
    label: 'その他'
  }
])
const familyOptions = ref([
  {
    value: 0,
    label: '離婚'
  },
  {
    value: 1,
    label: '死別'
  },
  {
    value: 2,
    label: '別居'
  },
  {
    value: 3,
    label: '内縁'
  },
  {
    value: 4,
    label: '再婚'
  },
  {
    value: 5,
    label: '一人親'
  },
  {
    value: 6,
    label: '未入籍'
  },
  {
    value: 7,
    label: '周囲からの支援得にくい'
  },
  {
    value: 8,
    label: 'その他'
  }
])
const qaOptions = ref([
  {
    value: 0,
    label: 'DV'
  },
  {
    value: 1,
    label: '衣食住の世話をしない'
  },
  {
    value: 2,
    label: '事故が多い'
  },
  {
    value: 3,
    label: '健診予防接種未受診'
  },
  {
    value: 4,
    label: '子と関わりが少ない'
  },
  {
    value: 5,
    label: 'ステップファミリー'
  }
])

const pregnantWomanOptions = [
  { value: '', label: '' },
  { value: '1', label: '該当' },
  { value: '2', label: '非該当(要支援)' },
  { value: '3', label: '非該当' }
]
const mainWayOptions = [
  { value: '', label: '' },
  { value: '01', label: '訪問' },
  { value: '02', label: '面談' },
  { value: '03', label: '電話' },
  { value: '04', label: 'メール' }
]
const planMakerOptions = [
  { value: '', label: '' },
  { value: '000001', label: '佐伯花子' },
  { value: '001005', label: '佐藤花' }
]
const typeOptions = [
  { value: '', label: '' },
  { value: '0001', label: '産後支援なし' },
  { value: '0002', label: '多胎' },
  { value: '0003', label: '育児不安が強い' },
  { value: '0004', label: '発達に関する不安' },
  { value: '0005', label: '仕事との両立' }
]
const tickingResultsOptions = [
  { value: '', label: '' },
  { value: '1', label: ' 終結' },
  { value: '2', label: '産後継続' },
  { value: '3', label: 'ケース移管' },
  { value: '4', label: '妊娠中.支援予定' }
]

const tableList = ref([
  {
    planTime: '',
    planWay: '',
    planner: '',
    type: '',
    planContent: '',
    supportTime: '',
    supportWay: '',
    Supporter: '',
    supportContent: '',
    tickingDate: '',
    tickingResults: '',
    evaluator: '',
    tickingContent: ''
  }
])
const checkList = reactive<FormState>({
  other: '',
  childCareValue: '',
  lowAgeValue: '',
  economyValue: '',
  momValue: '',
  witValue: '',
  guideValue: '',
  mentalValue: '',
  highAgeValue: '',
  abuseAgeValue: '',
  raiseValue: '',
  familyValue: '',
  qaValue: ''
})
const supportparam = reactive<FormState>({
  planCreationDay: ref<Dayjs>(),
  mainWay: '',
  planMaker: '',
  rank: '',
  integration: '',
  goal: ''
})
const evaluationParam = reactive<FormState>({
  evaluationDate: '',
  evaluator: '',
  evaluationResults: '',
  evaluationContent: ''
})
const chooseVal = ref(null)
const type = ref(null)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const addTable = () => {
  tableList.value.unshift({
    planTime: '',
    planWay: '',
    planner: '',
    type: '',
    planContent: '',
    supportTime: '',
    supportWay: '',
    Supporter: '',
    supportContent: '',
    tickingDate: '',
    tickingResults: '',
    evaluator: '',
    tickingContent: ''
  })
}

const chooseTable = (item, index) => {
  type.value = index
  chooseVal.value = item
}
const delTable = () => {
  if (type.value != null) {
    Modal.confirm({
      title: '確認',
      content: '削除しますか？',
      okText: 'は い',
      cancelText: 'いいえ',
      okButtonProps: {
        danger: true
      },
      onOk() {
        let i = tableList.value.findIndex((item) => {
          return item == chooseVal.value
        })
        if (i > -1) {
          tableList.value.splice(i, 1)
          type.value = null
        }
      }
    })
  } else {
    Modal.confirm({
      title: 'エラー',
      content: '削除対象が選択されていません。対象行を選択してください。',
      okText: 'は い',
      cancelText: 'いいえ'
    })
  }
}
const onChange = (val) => {
  emit('isEdit', val)
}
</script>

<style lang="less" scoped>
.ant-checkbox-group {
  display: flex;
  flex-direction: column;
}
.checkbox-border {
  width: 100%;
  height: 100px;
  overflow: auto;
  border: 1px solid #d9d9d9;
  padding: 10px;
}
.div-border {
  width: 100%;
  height: 30px;
  border: 1px solid #606266;
  margin-top: 2px;
}
.description-table .first-table tbody tr {
  border-bottom: 1px solid #606266;
}
.description-table .first-table tbody tr th {
  border-right: 1px solid #606266;
}
.description-table .first-table tbody tr td {
  border-right: 1px solid #606266;
}
.description-table .first-table tbody .border-right {
  border-right: none;
}
.active-bg {
  background: #e6f7ff;
}
</style>
