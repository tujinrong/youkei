<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 連絡先(タブごと)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.05.22
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div style="padding: 2px">
    <div class="self_adaption_table">
      <a-row>
        <a-col span="6">
          <th>宛名番号</th>
          <TD>{{ formState?.atenano }}</TD>
        </a-col>
        <a-col span="6">
          <th>氏名</th>
          <TD>{{ headerinfo?.name }}</TD>
        </a-col>
        <a-col span="6">
          <th>カナ氏名</th>
          <TD>{{ headerinfo?.kname }}</TD>
        </a-col>
        <a-col span="6">
          <th style="width: 120px">性別</th>
          <TD>{{ headerinfo?.sex }}</TD>
        </a-col>
        <a-col span="6">
          <th>住民区分</th>
          <TD>{{ headerinfo?.juminkbn }}</TD>
        </a-col>
        <a-col span="6">
          <th>生年月日</th>
          <TD>{{ headerinfo?.bymd }}</TD>
        </a-col>
        <a-col span="6">
          <th>年齢</th>
          <TD>{{ headerinfo?.age }}</TD>
        </a-col>
        <a-col span="6">
          <th style="width: 120px">年齢計算基準日</th>
          <TD>{{ headerinfo?.agekijunymd }}</TD>
        </a-col>
      </a-row>
    </div>
    <a-collapse active-key="1" class="m-t-2">
      <a-collapse-panel key="1" header="連絡先情報" :show-arrow="false">
        <div class="self_adaption_table m-b-2">
          <a-row>
            <a-col span="8">
              <th style="width: 120px">利用事業コード</th>
              <TD>{{ formState.jigyo }}</TD>
            </a-col>
            <a-col span="8" :offset="8">
              <th style="width: 100px">登録支所</th>
              <TD>{{ formState.regsisyonm }}</TD>
            </a-col>
          </a-row>
        </div>
        <div class="self_adaption_table" :class="{ form: canEdit }">
          <a-row>
            <a-col span="12">
              <th>電話番号</th>
              <td v-if="canEdit">
                <a-input
                  v-model:value="formState.tel"
                  :maxlength="15"
                  @change="formState.tel = replaceText(formState.tel, EnumRegex.電話)"
                />
              </td>
              <TD v-else>{{ formState.tel }}</TD>
            </a-col>
            <a-col span="12">
              <th>携带番号</th>
              <td v-if="canEdit">
                <a-input
                  v-model:value="formState.keitaitel"
                  :maxlength="15"
                  @change="formState.keitaitel = replaceText(formState.keitaitel, EnumRegex.電話)"
                />
              </td>
              <TD v-else>{{ formState.keitaitel }}</TD>
            </a-col>
            <a-col span="12">
              <th>E-mail1</th>
              <td v-if="canEdit">
                <a-form-item v-bind="validateInfos.emailadrs">
                  <a-input
                    v-model:value="formState.emailadrs"
                    :maxlength="254"
                    @change="formState.emailadrs = changeFullAngle(formState.emailadrs)"
                  />
                </a-form-item>
              </td>
              <TD v-else>{{ formState.emailadrs }}</TD>
            </a-col>
            <a-col span="12">
              <th>E-mail2</th>
              <td v-if="canEdit">
                <a-form-item v-bind="validateInfos.emailadrs2">
                  <a-input
                    v-model:value="formState.emailadrs2"
                    :maxlength="254"
                    @change="formState.emailadrs2 = changeFullAngle(formState.emailadrs2)"
                  />
                </a-form-item>
              </td>
              <TD v-else>{{ formState.emailadrs2 }}</TD>
            </a-col>
            <a-col span="24">
              <th>
                連絡先詳細
                <div class="show_count_box">
                  {{ `${formState.syosai?.length ?? 0} / 2000` }}
                </div>
              </th>
              <td v-if="canEdit">
                <a-textarea
                  v-model:value="formState.syosai"
                  :auto-size="{ minRows: 2 }"
                  :maxlength="2000"
                />
              </td>
              <td v-else class="textarea">{{ formState.syosai }}</td>
            </a-col>
          </a-row>
        </div>
      </a-collapse-panel>
    </a-collapse>
  </div>
</template>

<script lang="ts" setup>
import { computed, reactive, watch, watchEffect } from 'vue'
import TD from '@/components/Common/TableTD/index.vue'
import { Form } from 'ant-design-vue'
import { ITEM_ILLEGAL_ERROR } from '@/constants/msg'
import { REGEX_email } from '@/constants/constant'
import { SaveVM } from '../../type'
import { Judgement } from '@/utils/judge-edited'
import { EnumRegex, Enum共通バー番号 } from '#/Enums'
import { getBarKengen } from '@/utils/user'
import { changeFullAngle, replaceText } from '@/utils/util'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  detailinfo: SaveVM | null
  headerinfo: CommonBarHeaderBaseVM | null
  itemUpdflg: boolean
  judge: Judgement
}>()
//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
//初期化
const formState = reactive<SaveVM>({
  tel: '',
  keitaitel: '',
  emailadrs: '',
  emailadrs2: '',
  syosai: '',
  atenano: '',
  upddttm: '',
  jigyo: '',
  regsisyonm: ''
})

//項目の設定
const rules = reactive({
  emailadrs: [{ validator: validateEmail }],
  emailadrs2: [{ validator: validateEmail }]
})

const useForm = Form.useForm
const { validate, validateInfos } = useForm(formState, rules)

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//操作権限取得
const kengen = computed(() => getBarKengen(Enum共通バー番号.連絡先))
const canSave = computed(() => {
  if (formState.upddttm) return true
  return Boolean(
    formState.tel ||
      formState.keitaitel ||
      formState.emailadrs ||
      formState.emailadrs2 ||
      formState.syosai
  )
})
const canEdit = computed(() =>
  props.detailinfo?.upddttm ? kengen.value.updateflg && props.itemUpdflg : kengen.value.addflg
)
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watchEffect(() => {
  if (props.detailinfo) {
    Object.assign(formState, props.detailinfo)
  }
})
watch(formState, () => props.judge.setEdited())
//---------------------------------------------------------------------------
//メソッド
//---------------------------------------------------------------------------
//メールフォマードチェック
async function validateEmail(_, value: string) {
  if (value && !REGEX_email.test(value)) {
    return Promise.reject(ITEM_ILLEGAL_ERROR.Msg.replace('{0}', 'Email'))
  }
  return Promise.resolve()
}

//チェック処理
async function validateData(): Promise<SaveVM> {
  await validate()
  return formState
}

defineExpose({
  canSave,
  validate: validateData
})
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 100px;
}
</style>
