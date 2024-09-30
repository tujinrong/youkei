<template>
  <a-modal
    :open="modalVisible"
    centered
    title="（GJ2011）契約者積立金・互助金単価マスタメンテナンス"
    width="1200px"
    :body-style="{ minHeight: '600px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="edit_table form">
      <a-row class="mt-2">
        <a-col span="24">
          <th class="required text-end!" :style="{ width: '100px' }">
            年 月 日
          </th>
          <td class="flex items-center">
            <DateJp
              v-model:value="formData.TAISYO_DATE_FROM"
              style="width: 50%"
            /><span>～</span>
            <DateJp
              v-model:value="formData.TAISYO_DATE_TO"
              style="width: 50%"
            />
          </td>
        </a-col>
      </a-row>
    </div>
    <div class="self_adaption_table form pl-25">
      <a-row class="mt-2">
        <div class="w-full" style="text-align: end">(单位：円)</div>
        <a-row class="w-full">
          <a-col span="4">
            <th>契約区分</th>
          </a-col>
          <a-col span="5">
            <th>鳥の種類</th>
          </a-col>
          <a-col span="5">
            <th>契約者積立金(単価)</th>
          </a-col>
          <a-col span="5">
            <th>経営支援互助金(単価)</th>
          </a-col>
          <a-col span="5">
            <th>焼却·埋却等互助金(単価)</th>
          </a-col>
        </a-row>
        <a-row class="w-full">
          <a-col span="4">
            <th>家族型</th>
          </a-col>
          <a-col span="20">
            <a-row class="flex-1">
              <a-col span="6">
                <th>採卵鶏(成鶏)</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <th>採卵鶏(育成鶏)</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <th>肉用鶏</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <th>種鶏(成鷄)</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <th>種鶏(育成鷄)</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
            </a-row>
          </a-col>
        </a-row>
        <a-row class="w-full">
          <a-col span="4">
            <th>企業型</th>
          </a-col>
          <a-col span="20">
            <a-row class="flex-1">
              <a-col span="6">
                <th>採卵鶏(成鶏)</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <th>採卵鶏(育成鶏)</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <th>肉用鶏</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <th>種鶏(成鷄)</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <th>種鶏(育成鷄)</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
            </a-row>
          </a-col>
        </a-row>
        <a-row class="w-full">
          <a-col span="4">
            <th>鶏以外</th>
          </a-col>
          <a-col span="20">
            <a-row class="flex-1">
              <a-col span="6">
                <th>うずら</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <th>あひる</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <th>きじ</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <th>ほろほろ鳥</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <th>七面鳥</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <th>だちよう</th>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.TUMITATE_TANKA"
                      class="w-full"
                      :precision="1"
                      :max="99.9"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.KEIEISIEN_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
              <a-col span="6">
                <td>
                  <a-form-item>
                    <a-input-number
                      v-model:value="formData.SYOKYAKU_TANKA"
                      v-bind="{ ...mathNumber }"
                      class="w-full"
                      :precision="0"
                      :maxlength="4"
                      :min="0"
                    />
                  </a-form-item>
                </td>
              </a-col>
            </a-row>
          </a-col>
        </a-row>
      </a-row>
    </div>
    <div class="edit_table form">
      <a-row class="mt-2">
        <a-col span="5">
          <th class="required text-end!" :style="{ width: '100px' }">
            手数料率
          </th>
          <td class="flex items-center">
            <a-input-number
              v-model:value="formData.TESURYO_RITU"
              :max="99"
              :min="1"
              :maxlength="2"
              class="w-22"
            >
              <template #addonAfter>%</template>
            </a-input-number>
          </td>
        </a-col>

        <a-col span="5">
          <th class="required text-end!" :style="{ width: '120px' }">
            互助金交付率
          </th>
          <td class="flex items-center">
            <a-input-number
              v-model:value="formData.KOFU_RITU"
              :max="100"
              :min="0"
              :maxlength="3"
              class="w-40"
            >
              <template #addonAfter>%</template>
            </a-input-number>
          </td>
        </a-col>
      </a-row>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button class="warning-btn" @click="saveData">保存</a-button>
          <a-button class="danger-btn" :disabled="isNew" @click="deleteData"
            >削除</a-button
          >
        </a-space>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { Form } from 'ant-design-vue'
import { computed, nextTick, reactive, watch } from 'vue'
import { EnumEditKbn, PageStatus } from '@/enum'
import { DetailVM } from '../type'
import { useRoute, useRouter } from 'vue-router'
import { mathNumber } from '@/utils/util'
import DateJp from '@/components/Selector/DateJp/index.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
}>()
const emit = defineEmits(['update:visible'])
const router = useRouter()
const route = useRoute()
const formData = reactive<DetailVM>({
  TAISYO_DATE_FROM: '',
  TAISYO_DATE_TO: '',
  KEIYAKU_KBN: undefined as number | undefined,
  TORI_KBN: undefined as number | undefined,
  TUMITATE_TANKA: undefined as number | undefined,
  KEIEISIEN_TANKA: undefined as number | undefined,
  SYOKYAKU_TANKA: undefined as number | undefined,
  TESURYO_RITU: undefined,
  KOFU_RITU: undefined,
})

const editJudge = new Judgement()
const rules = {}
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const modalVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  },
})
const isNew = computed(() => (props.editkbn === EnumEditKbn.Add ? true : false))
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      nextTick(() => editJudge.reset())
    }
  }
)
watch(
  () => formData,
  () => {
    editJudge.setEdited()
  }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//画面遷移
const goList = () => {
  closeModal()
}

const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    clearValidate()
    resetFields()
    emit('update:visible', false)
  })
}

// 登録
const saveData = () => {}

// 削除
const deleteData = () => {}
</script>
<style lang="scss" scoped>
th {
  width: 100%;
  border-right: 1px solid #8a8d92 !important;
}
.self_adaption_table .ant-col th {
  text-align: center;
}
</style>
