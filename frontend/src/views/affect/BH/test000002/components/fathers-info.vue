<template>
  <a-modal v-model:visible="editVisible" title="妊婦·父親情報" width="800px">
    <div style="max-height: 600px; overflow: scroll">
      <div style="margin-bottom: 20px">
        <a-checkbox v-model:checked="formState.cognate">血族結婚</a-checkbox>
      </div>
      <a-collapse v-model:activeKey="formState.activeKey">
        <a-collapse-panel key="1" :show-arrow="false" header="妊婦情報">
          <div>
            <div>
              <div class="description-table" style="margin: 0 20px">
                <table>
                  <tbody>
                    <tr>
                      <th style="width: 120px">宛名番号</th>
                      <td colspan="3">
                        <div class="flex" style="align-items: center">
                          <kojin-no
                            :value="formState.organizationNo2"
                            style="width: 160px"
                          ></kojin-no>
                          <a-button
                            type="primary"
                            shape="round"
                            size="small"
                            style="margin-left: 5px"
                            @click="individualSearch('1')"
                            >個人検索</a-button
                          >
                          <a-button
                            type="primary"
                            shape="round"
                            size="small"
                            style="margin-left: 5px"
                            >変更</a-button
                          >
                        </div>
                      </td>
                    </tr>
                    <tr>
                      <th>カナ氏名</th>
                      <td colspan="2">
                        <a-input v-model:value="formState.kanaName" show-search> </a-input>
                      </td>
                      <th style="width: 100px">氏名</th>
                      <td colspan="3">
                        <a-input v-model:value="formState.name" show-search> </a-input>
                      </td>
                    </tr>
                    <tr>
                      <th>生年月日</th>
                      <td colspan="2">
                        <a-input v-model:value="formState.date" style="width: 50%" show-search>
                        </a-input>
                        <span>（{{ formState.age }}歳）</span>
                      </td>
                      <th>血液型</th>
                      <td colspan="3">
                        <ai-select
                          v-model:value="formState.bloodType"
                          style="width: 150px"
                          :options="bloodTypeOptions"
                        ></ai-select>
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 120px">住所</th>
                      <td colspan="5">
                        <a-input v-model:value="formState.address" show-search> </a-input>
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 120px">電話番号(世帯)</th>
                      <td width="130px">
                        <a-input v-model:value="formState.phone" show-search> </a-input>
                      </td>
                      <th style="width: 130px">FAX</th>
                      <td style="width: 130px">
                        <a-input v-model:value="formState.fax" show-search> </a-input>
                      </td>
                      <th style="background-color: #ffffe1; width: 100px">行政区</th>
                      <td>
                        <ai-select
                          v-model:value="formState.district"
                          :disabled="true"
                          style="width: 100%"
                          :options="bloodTypeOptions"
                        ></ai-select>
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 120px">電話番号1</th>
                      <td>
                        <a-input v-model:value="formState.phone1" show-search> </a-input>
                      </td>
                      <th style="width: 80px">E-mail1</th>
                      <td colspan="3">
                        <a-input v-model:value="formState.email" show-search> </a-input>
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 120px">電話番号2</th>
                      <td>
                        <a-input v-model:value="formState.phone2" show-search> </a-input>
                      </td>
                      <th style="width: 80px">E-mail2</th>
                      <td colspan="3">
                        <a-input v-model:value="formState.email2" show-search> </a-input>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
              <div class="description-table" style="margin: 10px 20px 0">
                <table>
                  <tbody>
                    <tr class="seat-row" style="height: 0px; opacity: 0">
                      <th style="width: 120px"></th>
                      <td width="130px"></td>
                      <th style="width: 130px"></th>
                      <td style="width: 130px"></td>
                      <th style="width: 100px"></th>
                      <td></td>
                    </tr>
                    <tr>
                      <th style="width: 120px">里帰り</th>
                      <td>
                        <ai-select
                          v-model:value="formState.reason"
                          style="width: 100%"
                          :options="visitOptions"
                        ></ai-select>
                      </td>
                      <th style="width: 130px">世帯主</th>
                      <td colspan="3">
                        <a-input v-model:value="formState.householder" style="" show-search>
                        </a-input>
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 120px">住所</th>
                      <td colspan="3">
                        <a-input v-model:value="formState.address1" show-search> </a-input>
                      </td>
                      <th style="width: 85px">電話番号</th>
                      <td>
                        <a-input v-model:value="formState.phone3" show-search> </a-input>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </a-collapse-panel>
        <a-collapse-panel key="2" header="父親情報" :show-arrow="false">
          <div>
            <div>
              <div class="description-table" style="margin: 0 20px">
                <table>
                  <tbody>
                    <tr>
                      <th style="width: 120px">宛名番号</th>
                      <td colspan="3">
                        <div class="flex" style="align-items: center">
                          <kojin-no
                            :value="formState.organizationNo3"
                            style="width: 160px"
                          ></kojin-no>
                          <a-button
                            type="primary"
                            shape="round"
                            size="small"
                            style="margin-left: 5px"
                            @click="individualSearch('2')"
                            >個人検索</a-button
                          >
                          <a-button
                            type="primary"
                            shape="round"
                            size="small"
                            style="margin-left: 5px"
                            >変更</a-button
                          >
                        </div>
                      </td>
                    </tr>
                    <tr>
                      <th>カナ氏名</th>
                      <td colspan="2">
                        <a-input v-model:value="formState.kanaName2" show-search> </a-input>
                      </td>
                      <th style="width: 100px">氏名</th>
                      <td colspan="3">
                        <a-input v-model:value="formState.name2" show-search> </a-input>
                      </td>
                    </tr>
                    <tr>
                      <th>生年月日</th>
                      <td colspan="2">
                        <a-input v-model:value="formState.date2" style="width: 50%" show-search>
                        </a-input>
                        <span>（{{ formState.age2 }}歳）</span>
                      </td>
                      <th>血液型</th>
                      <td colspan="3">
                        <ai-select
                          v-model:value="formState.bloodType2"
                          style="width: 150px"
                          :options="bloodTypeOptions"
                        ></ai-select>
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 120px">住所</th>
                      <td colspan="5">
                        <a-input v-model:value="formState.address2" show-search> </a-input>
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 120px">電話番号(世帯)</th>
                      <td width="130px">
                        <a-input v-model:value="formState.phone4" show-search> </a-input>
                      </td>
                      <th style="width: 130px">FAX</th>
                      <td style="width: 130px">
                        <a-input v-model:value="formState.fax2" show-search> </a-input>
                      </td>
                      <th style="background-color: #ffffe1; width: 100px">行政区</th>
                      <td>
                        <ai-select
                          v-model:value="formState.district1"
                          :disabled="true"
                          style="width: 100%"
                          :options="bloodTypeOptions"
                        ></ai-select>
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 120px">電話番号1</th>
                      <td>
                        <a-input v-model:value="formState.phone5" show-search> </a-input>
                      </td>
                      <th style="width: 80px">E-mail1</th>
                      <td colspan="3">
                        <a-input v-model:value="formState.email3" show-search> </a-input>
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 120px">電話番号2</th>
                      <td>
                        <a-input v-model:value="formState.phone6" show-search> </a-input>
                      </td>
                      <th style="width: 80px">E-mail2</th>
                      <td colspan="3">
                        <a-input v-model:value="formState.email4" show-search> </a-input>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
              <div class="description-table" style="margin: 10px 20px 0">
                <table>
                  <tbody>
                    <tr class="seat-row" style="height: 0px; opacity: 0">
                      <th style="width: 120px"></th>
                      <td width="130px"></td>
                      <th style="width: 130px"></th>
                      <td style="width: 130px"></td>
                      <th style="width: 100px"></th>
                      <td></td>
                    </tr>
                    <tr>
                      <th style="width: 120px">職業</th>
                      <td>
                        <ai-select
                          v-model:value="formState.occupation"
                          style="width: 100%"
                          :options="occupationOptions"
                        ></ai-select>
                      </td>
                      <th style="width: 130px">勤務先</th>
                      <td colspan="3">
                        <a-input v-model:value="formState.work" style="" show-search> </a-input>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </a-collapse-panel>
      </a-collapse>
    </div>
    <template #footer>
      <a-button type="primary" @click="submit">確定</a-button>
      <a-button type="primary" @click="editVisible = false">閉じる</a-button>
    </template>
  </a-modal>
  <individual ref="individualRef" @select="searchRow" />
</template>

<script setup>
import { ref } from 'vue'
import individual from '@/views/components/individual.vue'
import { useRouter } from 'vue-router'
import KojinNo from '@/views/affect/AF/AWAF00701D/index.vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------

const router = useRouter()
const editVisible = ref(false)
const loading = ref(false)
const formState = ref({
  cognate: false,
  bigCode: '',
  bloodType: '',
  occupation: '',
  work: '',
  activeKey: ['1', '2'],
  code: '',
  content: '',
  remarks: '',
  type1: '',
  type2: '',
  type3: ''
})
const bloodTypeOptions = [
  { value: '', label: ' ' },
  { value: '01', label: 'Ａ型' },
  { value: '02', label: 'Ａ型　ＲＨ＋' },
  { value: '03', label: 'Ａ型　ＲＨ－' },
  { value: '04', label: 'Ｂ型' },
  { value: '05', label: 'ＡＢ型' },
  { value: '06', label: 'Ｏ型' }
]
const visitOptions = [
  { value: '', label: ' ' },
  { value: '1', label: 'なし' },
  { value: '2', label: 'あり' }
]
//個人検索
const individualRef = ref()

const emit = defineEmits(['submit'])

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//Show
const open = (type, row) => {
  if (type) {
    formState.value.activeKey = type
  } else {
    formState.value.activeKey = ['1', '2']
  }
  editVisible.value = true
}

//閉じる
const infoClose = () => {
  editVisible.value = false
}

const individualSearch = (type) => {
  individualRef.value.open(type)
}
const submit = () => {
  editVisible.value = false
  emit('submit', formState.value)
}

const searchRow = (record, type) => {
  if (type === '1') {
    formState.value.organizationNo2 = record.num
    formState.value.kanaName = record.kananame
    formState.value.name = record.name
    formState.value.district = record.district
    formState.value.date = record.birthday
    formState.value.address = record.address
  } else {
    formState.value.organizationNo3 = record.num
    formState.value.kanaName2 = record.kananame
    formState.value.name2 = record.name
    formState.value.district2 = record.district
    formState.value.date2 = record.birthday
    formState.value.address2 = record.address
  }
}

defineExpose({
  open
})
</script>
<style lang="less" scoped>
/deep/ .ant-collapse {
  border: 1px solid #606266 !important;
}
</style>
