<template>
  <div>
    <b>フォロー内容情報</b>
    <div class="self_adaption_table mb-4 max-w-300">
      <a-row>
        <a-col span="8">
          <th>フォロー内容枝番</th>
          <TD>{{ formData.follownaiyoedano }}</TD>
        </a-col>
        <a-col span="8">
          <th>把握経路</th>
          <TD>{{ formData.haakukeiro }}</TD>
        </a-col>
        <a-col span="8">
          <th>把握事業</th>
          <TD>{{ formData.haakujigyocd }}</TD>
        </a-col>
        <a-col span="24">
          <th class="required">フォロー内容</th>
          <td class="textarea">{{ formData.follownaiyo }}</td>
        </a-col>
      </a-row>
    </div>

    <b>フォロー予定結果情報</b>
    <div class="self_adaption_table mb-4" :class="{ form: canEdit }">
      <a-row>
        <a-col span="12">
          <th class="required">フォロー事業</th>
          <td v-if="canEdit">
            <a-form-item v-bind="validateInfos.followjigyocd">
              <ai-select
                v-model:value="formData.followjigyocd"
                :options="options.followjigyoList"
              />
            </a-form-item>
          </td>
          <TD v-else>{{ formData.followjigyocd }}</TD>
        </a-col>
      </a-row>
    </div>
    <a-row :gutter="[24, 12]">
      <a-col :md="24" :xl="12" :xxl="12">
        <a-spin :spinning="loading1">
          <div class="flex justify-between items-end">
            <a-space>
              <b>フォロー予定情報</b>
              <a-checkbox
                :checked="formData.yoteiinputflg"
                @change="(e) => onChangeFlg(e, 'yoteiinputflg')"
              />
            </a-space>
            <a-button
              v-if="canEdit"
              type="primary"
              :disabled="!formData.yoteiinputflg || !options.zenkaisetflg"
              @click="setLastResult"
              >前回結果情報セット</a-button
            >
          </div>
          <div class="flex">
            <div :class="[canEdit ? 'bg-editable' : 'bg-readonly', 'joho-side']">
              <span>予定情報</span>
            </div>
            <div class="self_adaption_table" :class="{ form: canEdit }">
              <a-row>
                <a-col span="24">
                  <th>フォロー方法</th>
                  <td v-if="canEdit">
                    <ai-select
                      v-model:value="formData.followhoho_yotei"
                      :options="options.followhoho_yoteiList"
                      :disabled="!formData.yoteiinputflg"
                    />
                  </td>
                  <TD v-else>{{ formData.followhoho_yotei }}</TD>
                </a-col>
                <a-col span="24">
                  <th>予定日</th>
                  <td v-if="canEdit">
                    <date-jp
                      v-model:value="formData.followyoteiymd"
                      style="width: 190px"
                      format="YYYY-MM-DD"
                      :disabled="!formData.yoteiinputflg"
                    />
                  </td>
                  <TD v-else>{{
                    formData.followyoteiymd ? getDateJpText(new Date(formData.followyoteiymd)) : ''
                  }}</TD>
                </a-col>
                <a-col span="24">
                  <th>フォロー時間</th>
                  <td v-if="canEdit">
                    <a-time-picker
                      v-model:value="formData.followtm_yotei"
                      value-format="HHmm"
                      format="HH:mm"
                      :disabled="!formData.yoteiinputflg"
                    />
                  </td>
                  <TD v-else>{{ formatTime(formData.followtm_yotei) }}</TD>
                </a-col>
                <a-col span="24">
                  <th>フォロー会場</th>
                  <td v-if="canEdit">
                    <ai-select
                      v-model:value="formData.followkaijocd_yotei"
                      :options="options.followkaijocd_yoteiList"
                      :disabled="!formData.yoteiinputflg"
                    />
                  </td>
                  <TD v-else>{{ formData.followkaijocd_yotei }}</TD>
                </a-col>
                <a-col span="24">
                  <th>フォロー担当者</th>
                  <td v-if="canEdit" class="flex">
                    <ai-select
                      :value="formData.followstaffid_yotei"
                      :options="options.followstaffidList"
                      :disabled="!formData.yoteiinputflg"
                      style="width: calc(100% - 67px)"
                      @change="
                        (val) => {
                          formData.followstaffid_yotei = val?.split(' : ')[0] ?? ''
                          formData.followstaffid_yoteinm = val?.split(' : ')[1] ?? ''
                        }
                      "
                    />
                    <a-button
                      type="primary"
                      class="float-right"
                      :disabled="!formData.yoteiinputflg"
                      @click="onClickSearch('yotei')"
                      >検索</a-button
                    >
                  </td>
                  <TD v-else>{{ formData.followstaffid_yoteinm }}</TD>
                </a-col>
                <a-col span="24">
                  <th>
                    フォロー理由
                    <div class="show_count_box">
                      {{ `${formData.followriyu?.length ?? 0} / 200` }}
                    </div>
                  </th>
                  <td v-if="canEdit">
                    <a-textarea
                      v-model:value="formData.followriyu"
                      maxlength="200"
                      :auto-size="{ minRows: 2 }"
                      :disabled="!formData.yoteiinputflg"
                    />
                  </td>
                  <td v-else class="textarea">{{ formData.followriyu }}</td>
                </a-col>
              </a-row>
            </div>
          </div>
        </a-spin>
      </a-col>
      <a-col :md="24" :xl="12" :xxl="12">
        <div class="flex justify-between items-end">
          <a-space>
            <b>フォロー結果情報</b>
            <a-checkbox
              :checked="formData.kekkainputflg"
              @change="(e) => onChangeFlg(e, 'kekkainputflg')"
            />
          </a-space>
          <a-button
            v-if="canEdit"
            type="primary"
            :disabled="!formData.kekkainputflg"
            @click="setResult"
            >予定情報セット</a-button
          >
        </div>
        <div class="flex">
          <div :class="[canEdit ? 'bg-editable' : 'bg-readonly', 'joho-side']">
            <span>結果情報</span>
          </div>
          <div class="self_adaption_table" :class="{ form: canEdit }">
            <a-row>
              <a-col span="24">
                <th>フォロー方法</th>
                <td v-if="canEdit">
                  <ai-select
                    v-model:value="formData.followhoho"
                    :options="options.followhohoList"
                    :disabled="!formData.kekkainputflg"
                  />
                </td>
                <TD v-else>{{ formData.followhoho }}</TD>
              </a-col>
              <a-col span="24">
                <th>実施日</th>
                <td v-if="canEdit">
                  <date-jp
                    v-model:value="formData.followjissiymd"
                    style="width: 190px"
                    format="YYYY-MM-DD"
                    :disabled="!formData.kekkainputflg"
                  />
                </td>
                <TD v-else>{{ formData.followjissiymd }}</TD>
              </a-col>
              <a-col span="24">
                <th>フォロー時間</th>
                <td v-if="canEdit">
                  <a-time-picker
                    v-model:value="formData.followtm"
                    value-format="HHmm"
                    format="HH:mm"
                    :disabled="!formData.kekkainputflg"
                  />
                </td>
                <TD v-else>{{ formData.followtm }}</TD>
              </a-col>
              <a-col span="24">
                <th>フォロー会場</th>
                <td v-if="canEdit">
                  <ai-select
                    v-model:value="formData.followkaijocd"
                    :options="options.followkaijocdList"
                    :disabled="!formData.kekkainputflg"
                  />
                </td>
                <TD v-else>{{ formData.followkaijocd }}</TD>
              </a-col>
              <a-col span="24">
                <th>フォロー担当者</th>
                <td v-if="canEdit" class="flex">
                  <ai-select
                    :value="formData.followstaffid"
                    :options="options.followstaffid_yoteiList"
                    :disabled="!formData.kekkainputflg"
                    @change="
                      (val) => {
                        formData.followstaffid = val?.split(' : ')[0] ?? ''
                        formData.followstaffid_nm = val?.split(' : ')[1] ?? ''
                      }
                    "
                  />
                  <a-button
                    type="primary"
                    class="float-right"
                    :disabled="!formData.kekkainputflg"
                    @click="onClickSearch('kekka')"
                    >検索</a-button
                  >
                </td>
                <TD v-else>{{ formData.followstaffid_nm }}</TD>
              </a-col>
              <a-col span="24">
                <th>
                  フォロー結果
                  <div class="show_count_box">
                    {{ `${formData.followkekka?.length ?? 0} / 200` }}
                  </div>
                </th>
                <td v-if="canEdit">
                  <a-textarea
                    v-model:value="formData.followkekka"
                    maxlength="200"
                    :auto-size="{ minRows: 2 }"
                    :disabled="!formData.kekkainputflg"
                  />
                </td>
                <td v-else class="pl-3.5!">{{ formData.followkekka }}</td>
              </a-col>
            </a-row>
          </div>
        </div>
      </a-col>
    </a-row>

    <StaffModal v-model:visible="modalVisible" @select="selectStaff" />
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { SearchVM } from '@/views/affect/AF/AWAF00704D/type'
import { FollowDetailVM, InitFollowDetailResponse } from '../type'
import { validateInfos as validateInfosType } from 'ant-design-vue/lib/form/useForm'
import StaffModal from '@/views/affect/AF/AWAF00704D/index.vue'
import { getDateJpText, formatTime } from '@/utils/util'
import { showConfirmModal } from '@/utils/modal'
import { C011003 } from '@/constants/msg'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  isNew: boolean
  loading1: boolean
  canEdit: boolean
  formData: FollowDetailVM
  options: Omit<
    InitFollowDetailResponse,
    'followdetailvm' | 'showflg' | 'regsisyo' | keyof DaResponseBase
  >
  validateInfos: validateInfosType
  setLastResult: () => void
}>()

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//予定情報セット
function setResult() {
  props.formData.followhoho = props.formData.followhoho_yotei
  props.formData.followjissiymd = props.formData.followyoteiymd
  props.formData.followtm = props.formData.followtm_yotei
  props.formData.followkaijocd = props.formData.followkaijocd_yotei
  props.formData.followstaffid = props.formData.followstaffid_yotei
  props.formData.followkekka = props.formData.followriyu
}

//担当者---------------------------------------------------------
const modalVisible = ref(false)
let staffType = ''
function onClickSearch(type: 'yotei' | 'kekka') {
  modalVisible.value = true
  staffType = type
}
async function selectStaff(val: SearchVM) {
  if (staffType === 'yotei') {
    props.formData.followstaffid_yotei = val.staffid
    props.formData.followstaffid_yoteinm = val.staffsimei
  } else {
    props.formData.followstaffid = val.staffid
    props.formData.followstaffid_nm = val.staffsimei
  }
}
//---------------------------------------------------------------
//Checkbox
function onChangeFlg(e, flgnm: string) {
  if (e.target.checked) {
    props.formData[flgnm] = true
  } else {
    if (props.isNew) {
      props.formData[flgnm] = false
    } else {
      showConfirmModal({
        content: C011003,
        onOk: () => (props.formData[flgnm] = false)
      })
    }
  }
}
</script>

<style scoped>
th {
  width: 135px;
}
.joho-side {
  display: flex;
  justify-content: center;
  align-items: center;
  height: auto;
  flex: 0 0 40px;
  border: 1px solid #606266;
  margin-bottom: -1px;
  span {
    writing-mode: vertical-rl;
    font-size: 15px;
  }
}
</style>
