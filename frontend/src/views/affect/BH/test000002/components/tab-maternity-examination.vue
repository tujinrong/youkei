<template>
  <a-tabs v-model:activeKey="activeKeyCollapse1" type="card" class="highlight-tabs tab-3">
    <a-tab-pane key="1" tab="産後2週間">
      <div class="flex flex-column-1915">
        <div class="description-table left-table" style="width: 72%">
          <table>
            <tbody>
              <tr>
                <th style="width: 120px; max-width: 134px">受診年月日</th>
                <td colspan="3" style="width: 25%">
                  <!--                <a-date-picker v-model:value="weekparam.date" style="width: 60%" />-->
                  <date-jp v-model:value="weekparam.date" style="width: 60%"></date-jp>
                  <a-checkbox v-model:value="weekparam.checked" class="m-l-1"
                    >他市町村受診</a-checkbox
                  >
                </td>
                <th style="width: 120px">身体状況</th>
                <td colspan="3" style="width: 25%">
                  <ai-select
                    v-model:value="weekparam.healthStatus"
                    :options="healthOptions"
                    style="width: 100%"
                  ></ai-select>
                </td>
              </tr>
              <tr>
                <th style="width: 120px; max-width: 134px">実施機関</th>
                <td colspan="3">
                  <ai-select
                    v-model:value="weekparam.hospital"
                    :options="hospitalOptions"
                    style="width: 70%"
                  ></ai-select>
                  <a-button class="m-l-1" shape="round" type="primary" @click="onSearchOrganization"
                    >検索</a-button
                  >
                </td>
                <th style="width: 120px">気分の異常</th>
                <td colspan="3">
                  <ai-select
                    v-model:value="weekparam.abnormalMood"
                    :options="abnormalMoodOptions"
                    style="width: 100%"
                  ></ai-select>
                </td>
              </tr>
              <tr>
                <th style="width: 120px; max-width: 134px">血圧</th>
                <td colspan="3">
                  <a-input v-model:value="weekparam.highBlood" style="width: 100px"> </a-input>
                  <span>／</span>
                  <a-input v-model:value="weekparam.lowBlood" style="width: 100px"> </a-input>
                  <span>&nbsp;&nbsp;mmHg&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(高/低)</span>
                </td>
                <th style="width: 120px">月経開始時期</th>
                <td colspan="3">
                  <ai-select
                    v-model:value="weekparam.menses"
                    :options="mensesOptions"
                    style="width: 100%"
                  ></ai-select>
                </td>
              </tr>
              <tr>
                <th style="width: 120px; max-width: 134px">血色素検査</th>
                <td colspan="3" style="">
                  <a-input v-model:value="weekparam.hemochrome" style="width: 70%"> </a-input>
                  <span class="m-l-1">g/dl </span>
                </td>
                <th style="width: 120px">産婦訪問</th>
                <td>
                  <ai-select
                    v-model:value="weekparam.visit"
                    :options="visitOptions"
                    style="width: 130px"
                  ></ai-select>
                </td>
                <th style="width: 120px">判定</th>
                <td>
                  <ai-select
                    v-model:value="weekparam.judge"
                    :options="judgeOptions"
                    style="width: 130px"
                  ></ai-select>
                </td>
              </tr>
              <tr>
                <th style="width: 120px">尿検査(糖)</th>
                <td>
                  <ai-select
                    v-model:value="weekparam.sugar"
                    :options="sugarOptions"
                    style="width: 130px; max-width: 134px"
                  ></ai-select>
                </td>
                <th style="width: 120px">尿検査(蛋白)</th>
                <td>
                  <ai-select
                    v-model:value="weekparam.protein"
                    :options="sugarOptions"
                    style="width: 130px"
                  ></ai-select>
                </td>
                <th style="width: 120px">尿検査(潜血)</th>
                <td colspan="3">
                  <ai-select
                    v-model:value="weekparam.blood"
                    :options="sugarOptions"
                    style="width: 130px"
                  ></ai-select>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
        <div class="description-table right-table" style="margin-left: -1px; width: 28%">
          <table>
            <tbody>
              <tr>
                <th style="width: 120px">異常サイン</th>
                <td style="height: 73px">
                  <a-checkbox-group
                    v-model:value="weekparam.abnormalSign"
                    name="checkboxgroup"
                    :options="exceptionOptions"
                  />
                </td>
              </tr>
              <tr>
                <th style="width: 120px">備考</th>
                <td style="height: 110px">
                  <a-textarea v-model:value="weekparam.remark" :rows="4" allow-clear />
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </a-tab-pane>
    <a-tab-pane key="2" tab="産後1か月">
      <div class="flex flex-column-1915">
        <div class="description-table left-table" style="width: 72%">
          <table>
            <tbody>
              <tr>
                <th style="width: 120px">受診年月日</th>
                <td colspan="3" style="width: 25%">
                  <!--                <a-date-picker v-model:value="monthparam.date" style="width: 60%" />-->
                  <date-jp v-model:value="monthparam.date" style="width: 60%"></date-jp>
                  <a-checkbox v-model:value="monthparam.checked" class="m-l-1"
                    >他市町村受診</a-checkbox
                  >
                </td>
                <th style="width: 120px">身体状況</th>
                <td colspan="3" style="width: 25%">
                  <ai-select
                    v-model:value="monthparam.healthStatus"
                    :options="healthOptions"
                    style="width: 100%"
                  ></ai-select>
                </td>
              </tr>
              <tr>
                <th style="width: 120px">実施機関</th>
                <td colspan="3">
                  <ai-select
                    v-model:value="monthparam.hospital"
                    :options="hospitalOptions"
                    style="width: 70%"
                  ></ai-select>
                  <a-button class="m-l-1" shape="round" type="primary" @click="onSearchOrganization"
                    >検索</a-button
                  >
                </td>
                <th style="width: 120px">気分の異常</th>
                <td colspan="3">
                  <ai-select
                    v-model:value="monthparam.abnormalMood"
                    :options="abnormalMoodOptions"
                    style="width: 100%"
                  ></ai-select>
                </td>
              </tr>
              <tr>
                <th style="width: 120px">血圧</th>
                <td colspan="3">
                  <a-input v-model:value="monthparam.highBlood" style="width: 100px"> </a-input>
                  <span>／</span>
                  <a-input v-model:value="monthparam.lowBlood" style="width: 100px"> </a-input>
                  <span>&nbsp;&nbsp;mmHg&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(高/低)</span>
                </td>
                <th style="width: 120px">月経開始時期</th>
                <td colspan="3">
                  <ai-select
                    v-model:value="monthparam.menses"
                    :options="mensesOptions"
                    style="width: 100%"
                  ></ai-select>
                </td>
              </tr>
              <tr>
                <th style="width: 120px">血色素検査</th>
                <td colspan="3">
                  <a-input v-model:value="monthparam.hemochrome" style="width: 70%"> </a-input>
                  <span class="m-l-1">g/dl </span>
                </td>
                <th style="width: 120px">産婦訪問</th>
                <td>
                  <ai-select
                    v-model:value="monthparam.visit"
                    :options="visitOptions"
                    style="width: 130px"
                  ></ai-select>
                </td>
                <th style="width: 120px">判定</th>
                <td>
                  <ai-select
                    v-model:value="monthparam.judge"
                    :options="judgeOptions"
                    style="width: 130px"
                  ></ai-select>
                </td>
              </tr>
              <tr>
                <th style="width: 120px">尿検査(糖)</th>
                <td>
                  <ai-select
                    v-model:value="monthparam.sugar"
                    :options="sugarOptions"
                    style="width: 130px"
                  ></ai-select>
                </td>
                <th style="width: 120px">尿検査(蛋白)</th>
                <td>
                  <ai-select
                    v-model:value="monthparam.protein"
                    :options="sugarOptions"
                    style="width: 130px"
                  ></ai-select>
                </td>
                <th style="width: 120px">尿検査(潜血)</th>
                <td colspan="3">
                  <ai-select
                    v-model:value="monthparam.blood"
                    :options="sugarOptions"
                    style="width: 130px"
                  ></ai-select>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
        <div class="description-table right-table" style="margin-left: -1px; width: 28%">
          <table>
            <tbody>
              <tr>
                <th style="width: 120px">異常サイン</th>
                <td style="height: 73px">
                  <a-checkbox-group
                    v-model:value="monthparam.abnormalSign"
                    name="checkboxgroup"
                    :options="exceptionOptions"
                  />
                </td>
              </tr>
              <tr>
                <th style="width: 120px">備考</th>
                <td style="height: 110px">
                  <a-textarea v-model:value="monthparam.remark" :rows="4" allow-clear />
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </a-tab-pane>
  </a-tabs>
  <OrganizeModal ref="organizeModalRef" @select="selectOrganize"></OrganizeModal>
</template>
<!--産婦健康診查情報-->
<script lang="ts" setup>
import { reactive, ref } from 'vue'
import { FormState } from '@/views/affect/AF/AWAF00101G/type'
import type { Dayjs } from 'dayjs'
import OrganizeModal from '@/views/affect/AF/AWAF00702D/index.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const activeKeyCollapse1 = ref('1')
const exceptionOptions = [
  { value: '1', label: '高血圧' },
  { value: '2', label: '蛋白' },
  { value: '3', label: '浮腫' },
  { value: '4', label: '貧血' },
  { value: '5', label: '糖' },
  { value: '6', label: '潜血' },
  { value: '7', label: 'その他' }
]
const healthOptions = [
  { value: '', label: '' },
  { value: '01', label: '状況1' },
  { value: '02', label: '状況2' },
  { value: '03', label: '状況3' }
]
const hospitalOptions = [
  { value: '', label: '' },
  { value: '0001', label: '医療機関0001' },
  { value: '0002', label: '医療機関0002' },
  { value: '0102', label: '医療機関0102' }
]
const abnormalMoodOptions = [
  { value: '', label: '' },
  { value: '01', label: '気分異常1' },
  { value: '02', label: '気分異常2' },
  { value: '03', label: '気分異常3' }
]
const mensesOptions = [
  { value: '', label: '' },
  { value: '01', label: '月経開始時期1' },
  { value: '02', label: '月経開始時期2' },
  { value: '03', label: '月経開始時期3' }
]
const visitOptions = [
  { value: '', label: '' },
  { value: '0', label: 'なし' },
  { value: '1', label: 'あり' }
]
const judgeOptions = [
  { value: '', label: '' },
  { value: '1', label: '異常なし' },
  { value: '2', label: '要指導' },
  { value: '3', label: '要観察' },
  { value: '4', label: '要精密' },
  { value: '5', label: '要治療' },
  { value: '6', label: '治療中' }
]
const sugarOptions = [
  { value: '', label: '' },
  { value: '0', label: '-' },
  { value: '1', label: '+-' },
  { value: '2', label: '+' },
  { value: '3', label: '2+' },
  { value: '4', label: '3+' },
  { value: '5', label: '4+' },
  { value: '6', label: '生' },
  { value: '7', label: '未実施' }
]

const weekparam = reactive<FormState>({
  date: ref<Dayjs>(),
  checked: false,
  blood: '',
  protein: '',
  sugar: '',
  judge: '',
  visit: '',
  hemochrome: '',
  remark: '',
  menses: '',
  highBlood: '',
  lowBlood: '',
  abnormalMood: '',
  hospital: '',
  abnormalSign: '',
  healthStatus: ''
})
const monthparam = reactive<FormState>({
  date: ref<Dayjs>(),
  checked: false,
  blood: '',
  protein: '',
  sugar: '',
  judge: '',
  visit: '',
  hemochrome: '',
  remark: '',
  menses: '',
  highBlood: '',
  lowBlood: '',
  abnormalMood: '',
  hospital: '',
  abnormalSign: '',
  healthStatus: ''
})
//実施機関
const organizeModalRef = ref()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------

const onSearchOrganization = (value) => {
  organizeModalRef.value.openModal()
}
const selectOrganize = (val: any) => {
  weekparam.hospital = val.kikannm
  monthparam.hospital = val.kikannm
}
</script>

<style scoped></style>
