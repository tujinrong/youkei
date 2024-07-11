<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 送付先情報
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.11.14
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <CloseModalBtn class="close-btn" @click="closeModal" />
  <a-spin :spinning="loading">
    <div class="pt-4 mb-67px">
      <b>送付先情報</b>
      <div :class="[canEdit && 'form', 'self_adaption_table w-200']">
        <a-row>
          <a-col span="24">
            <th class="required">利用目的</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.riyomokuteki">
                <ai-select
                  v-model:value="formData.riyomokuteki"
                  :options="riyomokutekiList"
                  split-val
                />
              </a-form-item>
            </td>
            <TD v-else>{{
              riyomokutekiList.find((el) => el.value === formData.riyomokuteki)?.label ?? ''
            }}</TD>
          </a-col>
          <a-col span="24">　</a-col>
          <a-col span="24">
            <th>登録事由</th>
            <td v-if="canEdit">
              <ai-select v-model:value="formData.torokujiyu" :options="torokujiyuList" split-val />
            </td>
            <TD v-else>{{
              torokujiyuList.find((el) => el.value === formData.torokujiyu)?.label ?? ''
            }}</TD>
          </a-col>
          <a-col span="24">
            <th class="required">郵便番号</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.adrs_yubin">
                <PostCode v-model:value="formData.adrs_yubin">
                  <a-button type="primary" :loading="loading_auto" @click="autoInput"
                    >自動入力</a-button
                  >
                </PostCode>
              </a-form-item>
            </td>
            <TD v-else>{{ formatYubin(formData.adrs_yubin) }}</TD>
          </a-col>
          <a-col span="24">
            <th class="required">市区町村</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.adrs_sikucd">
                <ai-select
                  v-model:value="formData.adrs_sikucd"
                  :options="options"
                  split-val
                  @change="onChangeOpt"
                />
              </a-form-item>
            </td>
            <TD v-else>{{
              sityosonList.find((el) => el.value === formData.adrs_sikucd)?.label ?? ''
            }}</TD>
          </a-col>
          <a-col span="24">
            <th class="required">町字</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.adrs_tyoazacd">
                <ai-select
                  v-model:value="formData.adrs_tyoazacd"
                  :options="keyoptions"
                  @change="
                    (val, opt) => {
                      onChangeKeyOpt(val, opt)
                      setTyoaza(val)
                    }
                  "
                />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.adrs_tyoaza }}</TD>
          </a-col>
          <a-col span="24">
            <th>町字(手入力)</th>
            <td v-if="canEdit">
              <a-textarea
                v-model:value="formData.adrs_tyoaza_in"
                :disabled="formData.adrs_tyoazacd !== '9999999'"
                maxlength="120"
                auto-size
              />
            </td>
            <TD v-else>{{ formData.adrs_tyoaza_in }}</TD>
          </a-col>
          <a-col span="24">
            <th>番地号表記</th>
            <td v-if="canEdit">
              <a-input v-model:value="formData.adrs_bantihyoki" maxlength="50" />
            </td>
            <TD v-else>{{ formData.adrs_bantihyoki }}</TD>
          </a-col>
          <a-col span="24">
            <th>方書</th>
            <td v-if="canEdit">
              <a-textarea v-model:value="formData.adrs_katagaki" maxlength="300" auto-size />
            </td>
            <td v-else class="textarea">{{ formData.adrs_katagaki }}</td>
          </a-col>
          <a-col span="24">
            <th class="required">氏名</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.sofusaki_simei">
                <a-textarea v-model:value="formData.sofusaki_simei" maxlength="100" auto-size />
              </a-form-item>
            </td>
            <td v-else class="textarea">{{ formData.sofusaki_simei }}</td>
          </a-col>
        </a-row>
      </div>
    </div>
    <div class="bottom-bar">
      <a-space>
        <a-button type="warn" :disabled="!canEdit" :loading="loading_save" @click="submitData()"
          >登録</a-button
        >
        <a-button type="primary" danger :disabled="!canDelete" @click="handleDelete">削除</a-button>
        <a-button type="primary" @click="forwardList">一覧へ</a-button>
      </a-space>
      <a-button type="primary" @click="closeModal">閉じる</a-button>
    </div>
  </a-spin>
</template>

<script setup lang="ts">
import { EnumServiceResult, Enum共通バー番号, Enum編集区分, PageSatatus } from '#/Enums'
import {
  DELETE_OK_INFO,
  ITEM_ILLEGAL_ERROR,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  SAVE_OK_INFO
} from '@/constants/msg'
import { Judgement } from '@/utils/judge-edited'
import { getBarKengen } from '@/utils/user'
import { Form, message } from 'ant-design-vue'
import { computed, onMounted, reactive, ref, watch, nextTick, toRef } from 'vue'
import { InitDetail, Delete, SearchDetail, Save, AutoSet } from '../service'
import { MainInfoVM } from '../type'
import { useRoute } from 'vue-router'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { useLinkOption } from '@/utils/hooks'
import { formatYubin } from '@/utils/util'
import PostCode from '@/components/Selector/PostCode/index.vue'
import TD from '@/components/Common/TableTD/index.vue'
import emitter from '@/utils/event-bus'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  status: PageSatatus
  riyomokuteki: string
}>()
const emit = defineEmits(['update:status', 'refresh', 'close'])
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const loading = ref(false)
const loading_save = ref(false)
const loading_auto = ref(false)
const editJudge = new Judgement()
const isNew = props.status === PageSatatus.New

//ドロップダウンリスト
const riyomokutekiList = ref<DaSelectorModel[]>([])
const torokujiyuList = ref<DaSelectorModel[]>([])
const sityosonList = ref<DaSelectorModel[]>([])
const tyoazaList = ref<DaSelectorKeyModel[]>([])

function createDefaultForm(): MainInfoVM {
  return {
    atenano: route.query.atenano as string,
    riyomokuteki: '',
    torokujiyu: '',
    adrs_yubin: '',
    adrs_sikucd: '',
    adrs_tyoazacd: '',
    adrs_tyoaza: '',
    adrs_tyoaza_in: '',
    adrs_bantihyoki: '',
    adrs_katagaki: '',
    sofusaki_simei: '',
    regsisyo: '',
    upddttm: '',
    updflg: false
  }
}
const formData = reactive(createDefaultForm())

//ドロップダウンリスト連動処理
const { keyoptions, options, onChangeKeyOpt, onChangeOpt } = useLinkOption(
  tyoazaList,
  sityosonList,
  toRef(formData, 'adrs_tyoazacd'),
  toRef(formData, 'adrs_sikucd')
)

//項目の設定
const rules = reactive({
  riyomokuteki: [
    { required: isNew, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '利用目的') }
  ],
  adrs_yubin: [
    {
      validator: async (_rule, value: string) => {
        if (!value) {
          return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '郵便番号'))
        } else if (value.length < 8) {
          return Promise.reject(ITEM_ILLEGAL_ERROR.Msg.replace('{0}', '郵便番号'))
        }
        return Promise.resolve()
      }
    }
  ],
  adrs_sikucd: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '市区町村') }
  ],
  adrs_tyoazacd: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '町字') }],
  sofusaki_simei: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '氏名') }]
})
const { validate, validateInfos, clearValidate } = Form.useForm(formData, rules)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  clearValidate()
  InitDetail().then((res) => {
    riyomokutekiList.value = res.riyomokutekiList
    torokujiyuList.value = res.torokujiyuList
    sityosonList.value = res.sityosonList
    tyoazaList.value = res.tyoazaList
    regsisyo.value = res.regsisyo
    showSisyo.value = res.showflg
  })
  //検索処理
  if (!isNew) {
    loading.value = true
    try {
      const res = await SearchDetail(
        {
          atenano: route.query.atenano as string,
          riyomokuteki: props.riyomokuteki
        },
        () => forwardList()
      )
      Object.assign(formData, res.mainInfo)
      formData.adrs_yubin = formatYubin(formData.adrs_yubin)
      nextTick(() => {
        clearValidate()
        editJudge.reset()
      })
    } catch (error) {}
    loading.value = false
  }
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//操作権限取得
const kengen = computed(() => getBarKengen(Enum共通バー番号.送付先管理))
const canEdit = computed(() => isNew || (kengen.value.updateflg && formData.updflg))
const canDelete = computed(() => !isNew && kengen.value.deleteflg)

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(formData, () => editJudge.setEdited())

//---------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------
//保存処理
async function submitData() {
  await validate()

  const params = {
    maininfo: {
      ...formData,
      adrs_yubin: formatYubin(formData.adrs_yubin, true)
    },
    editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
    checkflg: false
  }

  const saveReq = async () => {
    await Save(params)
    message.success(SAVE_OK_INFO.Msg)
    emit('refresh')
    emit('update:status', PageSatatus.List)
    emitter.emit('refreshBar', route.name)
  }

  loading_save.value = true
  await Save({ ...params, checkflg: true }, async (response: DaResponseBase) => {
    if (response.returncode === EnumServiceResult.ServiceAlert) {
      await saveReq()
    }
  }).finally(() => (loading_save.value = false))

  showSaveModal({
    onOk: async () => {
      try {
        await saveReq()
      } catch (error) {}
    }
  })
}
//削除処理
function handleDelete() {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await Delete({
          atenano: formData.atenano,
          riyomokuteki: formData.riyomokuteki,
          upddttm: formData.upddttm as string
        })
        message.success(DELETE_OK_INFO.Msg)
        emit('refresh')
        emit('update:status', PageSatatus.List)
      } catch (error) {}
    }
  })
}

//町字
function setTyoaza(v: string) {
  formData.adrs_tyoazacd = v?.split(' : ')[0]
  formData.adrs_tyoaza = v?.split(' : ')[1]
  formData.adrs_tyoaza_in = ''
}

//自動入力
async function autoInput() {
  await validate('adrs_yubin')
  loading_auto.value = true
  try {
    const res = await AutoSet({ adrs_yubin: formatYubin(formData.adrs_yubin, true) })
    formData.adrs_sikucd = res.autoset.adrs_sikucd ?? ''
    formData.adrs_tyoazacd = res.autoset.adrs_tyoazacd ?? ''
    formData.adrs_tyoaza =
      tyoazaList.value.find((el) => el.value === res.autoset.adrs_tyoazacd)?.label ?? ''
  } catch (error) {}
  loading_auto.value = false
}

function forwardList() {
  editJudge.judgeIsEdited(() => {
    emit('update:status', PageSatatus.List)
  })
}
function closeModal() {
  editJudge.judgeIsEdited(() => {
    emit('close')
  })
}

//登録支所 for headerinfo
const regsisyo = ref('')
const showSisyo = ref(false)
defineExpose({ regsisyo, showSisyo })
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 120px;
}
</style>
