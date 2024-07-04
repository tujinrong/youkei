<template>
  <a-modal
    :visible="props.visible"
    title="クーポン券"
    width="600px"
    :closable="false"
    destroy-on-close
  >
    <div class="self_adaption_table form">
      <a-row>
        <a-col span="24">
          <th class="required">抽出対象</th>
          <td>
            <a-form-item v-bind="validateInfos.tyusyututaisyocd">
              <ai-select
                v-model:value="formParams.tyusyututaisyocd"
                :options="tyusyututaisyoList"
                split-val
              ></ai-select>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col v-if="nendoflg" span="24">
          <th
            :class="{
              required: !nendokanri
            }"
          >
            年度
          </th>
          <td>
            <a-form-item v-bind="validateInfos.nendo">
              <year-jp v-model:value="formParams.nendo" :disabled="isNendo" />
            </a-form-item>
          </td>
        </a-col>
      </a-row>
      <a-row v-if="tyusyukbn === Enum抽出モード.全体抽出">
        <a-col span="24">
          <th class="required">抽出内容</th>
          <td>
            <a-form-item v-bind="validateInfos.tyusyutunaiyo">
              <a-input v-model:value="formParams.tyusyutunaiyo"></a-input>
            </a-form-item>
          </td>
        </a-col>
      </a-row>
      <a-row v-if="tyusyukbn === Enum抽出モード.個別抽出">
        <a-col span="24">
          <th class="required">宛名番号</th>
          <TD class="flex justify-between">
            <a-form-item v-bind="validateInfos.atenano">{{ formParams.atenano }} </a-form-item>
            <a-button class="px-10px" @click="atenanoVisible = true"> <search-outlined /></a-button>
          </TD>
        </a-col>
      </a-row>
    </div>
    <template #footer>
      <div class="flex justify-between">
        <a-button type="primary" @click="forwardEdit">設定</a-button>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
  <AtenanoModal
    v-model:visible="atenanoVisible"
    @select="(val) => (formParams.atenano = val.atenano)"
  />
</template>
<script lang="ts" setup>
import { EnumServiceResult, Enum抽出モード, PageSatatus } from '#/Enums'
import { computed, nextTick, reactive, ref, watch } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import YearJp from '@/components/Selector/YearJp/index.vue'
import { Check, Init } from './service'
import { GLOBAL_YEAR } from '@/constants/mutation-types'
import { ss } from '@/utils/storage'
import { CheckResponse } from './type'
import { Form } from 'ant-design-vue'
import { ITEM_REQUIRE_ERROR, ITEM_SELECTREQUIRE_ERROR } from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { SearchOutlined } from '@ant-design/icons-vue'
import AtenanoModal from '@/views/affect/AF/AWAF00705D/index.vue'
interface Props {
  visible: boolean
  tyusyukbn: Enum抽出モード | undefined
}
const props = defineProps<Props>()
const emit = defineEmits(['update:visible'])
const editJudge = new Judgement()
const atenanoVisible = ref(false)
const router = useRouter()
const route = useRoute()
const nendokanri = ref(false)

const createDefaultParams = () => {
  return {
    nendo: ss.get(GLOBAL_YEAR),
    tyusyututaisyocd: '',
    tyusyutunaiyo: '',
    atenano: ''
  }
}
const formParams = reactive(createDefaultParams())
const nendoflg = ref(false)
const isNendo = ref(false)
const tyusyututaisyoList = ref<DaSelectorKeyModel[]>([])
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//項目の設定ルール
const rules = computed(() => {
  return {
    nendo: [
      { required: !nendokanri.value, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '年度') }
    ],
    tyusyututaisyocd: [
      { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '抽出対象') }
    ],
    tyusyutunaiyo: [
      {
        required: props.tyusyukbn == Enum抽出モード.全体抽出,
        message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '抽出内容')
      }
    ],
    atenano: [
      {
        required: props.tyusyukbn == Enum抽出モード.個別抽出,
        message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '宛名番号')
      }
    ]
  }
})

const { validate, validateInfos, clearValidate } = Form.useForm(formParams, rules)
//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  async (val) => {
    if (val) {
      clearValidate()
      Object.assign(formParams, createDefaultParams)
      const res = await Init()
      tyusyututaisyoList.value = res.selectorlist
      nendoflg.value = res.nendoflg
      editJudge.reset()
    }
  }
)
watch(formParams, () => editJudge.setEdited())
watch(
  () => formParams.tyusyututaisyocd,
  (val) => {
    let key = tyusyututaisyoList.value.find((el) => el.value == val)?.key
    if (key == '2') {
      isNendo.value = true
      nendokanri.value = true
    } else {
      isNendo.value = false
      nendokanri.value = false
    }
  }
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//設定
const forwardEdit = async () => {
  await validate()
  //新規個別抽出の場合
  if (props.tyusyukbn == Enum抽出モード.個別抽出) {
    try {
      const res = await Check(
        {
          tyusyututaisyocd: formParams.tyusyututaisyocd,
          atenano: formParams.atenano,
          nendo: +formParams.nendo
        },
        //アラートの場合、はい押した、EUC出力画面遷移
        async (response: CheckResponse) => {
          if (response.returncode == EnumServiceResult.ServiceAlert) {
            await router.push({
              name: 'AWEU00301G'
            })
            router.push({
              name: 'AWEU00301G',
              query: {
                rptid: response.tyusyutuinfo.rptid,
                nendo: response.tyusyutuinfo.nendo,
                tyusyutunaiyonm: response.tyusyutuinfo.tyusyutunaiyo,
                tyusyututaisyocd: response.tyusyutuinfo.tyusyututaisyocd,
                atenanocnt: response.tyusyutuinfo.tyusyutunum,
                regdttm: response.tyusyutuinfo.regdttm
              }
            })
            emit('update:visible', false)
          }
        },
        //アラートK013004の場合、いいえ押した、詳細画面遷移
        async (response: CheckResponse) => {
          if (response.message.includes('K013004')) {
            router.push({
              name: route.name as string,
              query: {
                status: PageSatatus.New,
                tyusyukbn: props.tyusyukbn,
                atenano: formParams.atenano,
                nendo: nendokanri.value ? 9999 : formParams.nendo,
                tyusyututaisyocd: formParams.tyusyututaisyocd,
                ...response.tyusyutuinfo
              }
            })
            emit('update:visible', false)
          }
        }
      )
      //詳細画面遷移
      router.push({
        name: route.name as string,
        query: {
          status: PageSatatus.New,
          tyusyukbn: props.tyusyukbn,
          atenano: formParams.atenano,
          nendo: nendokanri.value ? 9999 : formParams.nendo,
          tyusyututaisyocd: formParams.tyusyututaisyocd,
          ...res.tyusyutuinfo
        }
      })
      emit('update:visible', false)
    } catch (error) {}
  }
  //新規全体抽出の場合
  else {
    //詳細画面遷移
    router.push({
      name: route.name as string,
      query: {
        status: PageSatatus.New,
        tyusyukbn: props.tyusyukbn,
        nendo: nendokanri.value ? 9999 : formParams.nendo,
        atenano: formParams.atenano,
        tyusyututaisyocd: formParams.tyusyututaisyocd,
        tyusyutunaiyo: formParams.tyusyutunaiyo
      }
    })
    emit('update:visible', false)
  }
}
const reset = () => {
  Object.assign(formParams, createDefaultParams())
  editJudge.reset()
}
const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    emit('update:visible', false)
    reset()
  })
}
</script>
<style lang="less" scoped>
th {
  width: 160px;
}
:deep(.ant-form-item) {
  margin-bottom: 0;
}
:deep(.vxe-header--column.group) {
  padding: 0 !important;
}
</style>
