<!------------------------------------------------------------------
 * 業務名称　: 互助事業システム
 * 機能概要　: 契約農場別明細 移動情報(入力)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.
 * 作成者　　: xxx
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-modal
    :visible="modalVisible"
    centered
    title="契約農場別明細 移動情報(入力)"
    width="1000px"
    :body-style="{ minHeight: '600px' }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="edit_table form w-full">
      <a-row>
        <a-col span="24">
          <th class="required">鶏の種類</th>
          <td>
            <a-form-item v-bind="validateInfos.TORI_KBN">
              <ai-select
                v-model:value="formData.TORI_KBN"
                :options="LIST"
                class="max-w-40"
                split-val
              >
              </ai-select>
              <span>
                （1:採卵鶏「成鶏」、2:採卵鶏「育成鶏」、3:肉用鶏、4:種鶏「成鶏」、5:種鶏「育成鶏」、
              </span>
            </a-form-item>
          </td>
        </a-col>
        <a-row>
          <a-col span="24" class="ml-75">
            <span>
              6:うずら、7:あひる、8:きじ、9:ほろほろ鳥、10:七面鳥、11:だちょう）
            </span>
          </a-col>
        </a-row>
        <a-col span="24">
          <th class="required">移動羽数</th>
          <td>
            <a-form-item v-bind="validateInfos.IDO_HASU">
              <a-input-number
                v-model:value="formData.IDO_HASU"
                v-bind="{ ...mathNumber }"
                class="w-30"
                :min="0"
                :max="99999999"
                :maxlength="10"
              ></a-input-number>
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">農場(移動元)</th>
          <td>
            <a-form-item v-bind="validateInfos.NOJO_CD_MOTO">
              <ai-select
                v-model:value="formData.NOJO_CD_MOTO"
                :options="LIST"
                class="max-w-185"
                split-val
              ></ai-select>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
      <!-- <a-col span="24" class="mt-2">
          <read-only-pop thWidth="120" th="農場住所" td="" :hideTd="true" />
          <read-only-pop th="　〒　" :td="nojoAddr_moto.ADDR_POST" />
          <read-only-pop thWidth="100" th="住所1" :td="nojoAddr_moto.ADDR_1" />
          <read-only-pop thWidth="100" th="住所2" :td="nojoAddr_moto.ADDR_2" />
        </a-col>
        <a-col span="24">
          <read-only-pop thWidth="120" th="" :hideTd="true" />
          <read-only-pop thWidth="100" th="住所3" :td="nojoAddr_moto.ADDR_3" />
          <read-only-pop thWidth="100" th="住所4" :td="nojoAddr_moto.ADDR_4" />
        </a-col> -->
      <a-row class="mt-2">
        <a-col span="3">
          <read-only-pop thWidth="120" th="農場住所" td="" :hideTd="true" />
        </a-col>
        <a-col span="4">
          <read-only-pop thWidth="30" th="〒" :td="nojoAddr_moto.ADDR_POST" />
        </a-col>
        <a-col span="1"></a-col>
      </a-row>
      <a-row class="mt-2">
        <a-col span="3">
          <read-only-pop thWidth="120" th="" td="" :hideTd="true" />
        </a-col>
        <a-col span="5">
          <read-only-pop thWidth="50" th="住所1" :td="nojoAddr_moto.ADDR_1" />
        </a-col>
        <a-col span="1"></a-col>
        <a-col span="10">
          <read-only-pop thWidth="50" th="住所2" :td="nojoAddr_moto.ADDR_2" />
        </a-col>
      </a-row>
      <a-row class="mt-2">
        <a-col span="3">
          <read-only-pop thWidth="120" th="" td="" :hideTd="true" />
        </a-col>
        <a-col span="5">
          <read-only-pop thWidth="50" th="住所3" :td="nojoAddr_moto.ADDR_3" />
        </a-col>
        <a-col span="1"></a-col>
        <a-col span="10">
          <read-only-pop thWidth="50" th="住所4" :td="nojoAddr_moto.ADDR_4" />
        </a-col>
      </a-row>

      <a-row>
        <a-col span="3"></a-col>
        <a-col span="10">
          <read-only-pop
            thWidth="120"
            th="契約羽数(移動前)"
            :td="formData.KEIYAKU_HASU_MOTO_MAE"
          />
        </a-col>
        <a-col span="1"></a-col>
        <a-col span="10">
          <read-only-pop
            thWidth="120"
            th="契約羽数(移動後)"
            :td="formData.KEIYAKU_HASU_MOTO_ATO"
          />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <th class="required">農場(移動先)</th>
          <td>
            <a-form-item v-bind="validateInfos.NOJO_CD_SAKI">
              <ai-select
                v-model:value="formData.NOJO_CD_SAKI"
                :options="LIST"
                class="max-w-250"
                split-val
              ></ai-select>
            </a-form-item>
            <a-button class="ml-2" type="primary">農場登録</a-button>
          </td>
        </a-col>
      </a-row>
      <!-- <a-row>
        <a-col span="24" class="mt-2">
          <read-only-pop thWidth="120" th="農場住所" td="" :hideTd="true" />
          <read-only-pop th="　〒　" :td="nojoAddr_saki.ADDR_POST" />
          <read-only-pop thWidth="100" th="住所1" :td="nojoAddr_saki.ADDR_1" />
          <read-only-pop thWidth="100" th="住所2" :td="nojoAddr_saki.ADDR_2" />
        </a-col>
        <a-col span="24">
          <read-only-pop thWidth="120" th="" :hideTd="true" />
          <read-only-pop thWidth="100" th="住所3" :td="nojoAddr_saki.ADDR_3" />
          <read-only-pop thWidth="100" th="住所4" :td="nojoAddr_saki.ADDR_4" />
        </a-col> -->
      <a-row class="mt-2">
        <a-col span="3">
          <read-only-pop thWidth="120" th="農場住所" td="" :hideTd="true" />
        </a-col>
        <a-col span="4">
          <read-only-pop thWidth="30" th="〒" :td="nojoAddr_saki.ADDR_POST" />
        </a-col>
        <a-col span="1"></a-col>
        <a-col span="5">
          <read-only-pop thWidth="50" th="住所1" :td="nojoAddr_saki.ADDR_1" />
        </a-col>
        <a-col span="1"></a-col>
        <a-col span="10">
          <read-only-pop thWidth="50" th="住所2" :td="nojoAddr_saki.ADDR_2" />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="8">
          <read-only-pop thWidth="120" th="" :hideTd="true" />
        </a-col>
        <a-col span="8">
          <read-only-pop thWidth="50" th="住所3" :td="nojoAddr_saki.ADDR_3" />
        </a-col>
        <a-col span="1"></a-col>
        <a-col span="7">
          <read-only-pop thWidth="50" th="住所4" :td="nojoAddr_saki.ADDR_4" />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="3"></a-col>
        <a-col span="10">
          <read-only-pop
            thWidth="120"
            th="契約羽数(移動前)"
            :td="formData.KEIYAKU_HASU_SAKI_MAE"
          />
        </a-col>
        <a-col span="1"></a-col>
        <a-col span="10">
          <read-only-pop
            thWidth="120"
            th="契約羽数(移動後)"
            :td="formData.KEIYAKU_HASU_SAKI_MAE"
          />
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <th class="required">移動年月日</th>
          <td>
            <a-form-item v-bind="validateInfos.KEIYAKU_DATE_FROM">
              <DateJp v-model:value="formData.KEIYAKU_DATE_FROM"></DateJp>
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">入力確認有無</th>
          <td>
            <a-radio-group
              v-model:value="formData.SYORI_KBN"
              class="ml-2 h-full pt-1"
            >
              <a-radio :value="1">入力中</a-radio>
              <a-radio :value="2">入力確認</a-radio>
            </a-radio-group>
          </td>
        </a-col>
      </a-row>
    </div>
    <template #footer>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20" class="mb-2">
          <a-button class="warning-btn" @click="save">登録</a-button>
          <a-button class="danger-btn" :disabled="isNew" @click="deleteData">
            削除
          </a-button>
          <a-button type="primary" @click="cancel">キャンセル</a-button>
        </a-space>
        <a-button type="primary" @click="goList">閉じる</a-button>
      </div>
    </template></a-modal
  >
</template>
<script lang="ts" setup>
import { EnumEditKbn } from '@/enum'
import { Judgement } from '@/utils/judge-edited'
import { computed, nextTick, onMounted, reactive, ref, watch } from 'vue'
import { NojoAddrVM } from '../type'
import { Form } from 'ant-design-vue'
import { changeTableSort, mathNumber } from '@/utils/util'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
}>()
const emit = defineEmits(['update:visible'])
const editJudge = new Judgement()
const createDefaultform = () => {
  return {
    KI: undefined, // 期
    KEIYAKUSYA_CD: undefined, // 契約者番号
    TORI_KBN: undefined, // 鶏の種類コード
    IDO_HASU: undefined, // 移動羽数
    NOJO_CD_MOTO: undefined, // 農場コード(移動元)
    KEIYAKU_HASU_MOTO_MAE: undefined, // 農場(移動元)　契約羽数(移動前)
    KEIYAKU_HASU_MOTO_ATO: undefined, // 農場(移動元)　契約羽数(移動後)
    NOJO_CD_SAKI: undefined, // 農場コード(移動先)
    KEIYAKU_HASU_SAKI_MAE: undefined, // 農場(移動先)　契約羽数(移動前)
    KEIYAKU_HASU_SAKI_ATO: undefined, // 農場(移動先)　契約羽数(移動後)
    KEIYAKU_DATE_FROM: null, // 移動年月日
    SYORI_KBN: 1, // 入力確認有無
    UP_DATE: null, // データ更新日
  }
}
const formData = reactive(createDefaultform())
const LIST = ref<CmCodeNameModel[]>([])
const nojoAddr_moto = reactive<NojoAddrVM>({
  NOJO_CD: undefined,
  NOJO_NAME: '',
  ADDR_POST: '',
  ADDR_1: '',
  ADDR_2: '',
  ADDR_3: '',
  ADDR_4: '',
})
const nojoAddr_saki = reactive<NojoAddrVM>({
  NOJO_CD: undefined,
  NOJO_NAME: '',
  ADDR_POST: '',
  ADDR_1: '',
  ADDR_2: '',
  ADDR_3: '',
  ADDR_4: '',
})
const rules = reactive({})
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

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {})

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
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
const closeModal = () => {
  emit('update:visible', false)
}
//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    closeModal()
  })
}
//登録
const save = () => {
  closeModal()
}
//キャンセル
const cancel = () => {
  resetFields()
}
//削除
const deleteData = () => {
  closeModal()
}
</script>

<style lang="scss" scoped>
th {
  min-width: 120px;
}
</style>
