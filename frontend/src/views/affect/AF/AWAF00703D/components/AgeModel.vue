<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 詳細条件検索(年齢生年月日)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.05.10
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-collapse-panel :show-arrow="false">
    <template #header>
      <span>{{ title + (cond_base ? '（条件あり）' : '') }}</span>
    </template>
    <a-radio-group v-model:value="type" class="m-b-1">
      <a-radio-button :value="EnumBirthSearchKbn.年齢">年齢</a-radio-button>
      <a-radio-button :value="EnumBirthSearchKbn.生年月日">生年月日</a-radio-button>
    </a-radio-group>
    <!-- 年齢 -->
    <a-form v-if="type === EnumBirthSearchKbn.年齢">
      <a-form-item v-bind="validateInfos_age.basedate">
        <template #label>
          年齢計算基準日
          <span v-if="cond_base" class="request-mark">＊</span>
        </template>
        <date-jp
          :value="ageModel.basedate"
          :disabled="!cond_base"
          style="width: 180px"
          @change="(v) => (ageModel.basedate = v ? dayjs(v).format('YYYY-MM-DD') : '')"
        />
      </a-form-item>
      <div v-if="props.filter.womanflg">
        <div>(女性)<span v-if="cond_woman" class="request-mark">＊</span></div>
        <a-radio-group v-model:value="cond_woman" name="woman">
          <a-radio :value="false">条件なし</a-radio>
          <a-radio :value="true">条件あり</a-radio>
        </a-radio-group>
        <a-form-item v-bind="validateInfos_age.woman">
          <a-input
            v-model:value="ageModel.woman"
            :placeholder="placeholder"
            :disabled="!cond_woman"
            allow-clear
            @change="ageModel.woman = ageModel.woman.replaceAll(/[^-,0-9]/g, '')"
          />
        </a-form-item>
      </div>
      <div v-if="props.filter.manflg">
        <div>(男性)<span v-if="cond_man" class="request-mark">＊</span></div>
        <a-radio-group v-model:value="cond_man" name="man">
          <a-radio :value="false">条件なし</a-radio>
          <a-radio :value="true">条件あり</a-radio>
        </a-radio-group>
        <a-form-item v-bind="validateInfos_age.man">
          <a-input
            v-model:value="ageModel.man"
            :placeholder="placeholder"
            :disabled="!cond_man"
            allow-clear
            @change="ageModel.man = ageModel.man.replaceAll(/[^-,0-9]/g, '')"
          />
        </a-form-item>
      </div>
      <div v-if="props.filter.bothflg">
        <div>(両方)<span v-if="cond_both" class="request-mark">＊</span></div>
        <a-radio-group v-model:value="cond_both" name="both">
          <a-radio :value="false">条件なし</a-radio>
          <a-radio :value="true">条件あり</a-radio>
        </a-radio-group>
        <a-form-item v-bind="validateInfos_age.both">
          <a-input
            v-model:value="ageModel.both"
            :placeholder="placeholder"
            :disabled="!cond_both"
            allow-clear
            @change="ageModel.both = ageModel.both.replaceAll(/[^-,0-9]/g, '')"
          />
        </a-form-item>
      </div>
      <div v-if="props.filter.unknownflg">
        <div>(不明・その他)<span v-if="cond_unknown" class="request-mark">＊</span></div>
        <a-radio-group v-model:value="cond_unknown" name="unknown">
          <a-radio :value="false">条件なし</a-radio>
          <a-radio :value="true">条件あり</a-radio>
        </a-radio-group>
        <a-form-item v-bind="validateInfos_age.unknown">
          <a-input
            v-model:value="ageModel.unknown"
            :placeholder="placeholder"
            :disabled="!cond_unknown"
            allow-clear
            @change="ageModel.unknown = ageModel.unknown.replaceAll(/[^-,0-9]/g, '')"
          />
        </a-form-item>
      </div>
    </a-form>
    <!-- 生年月日 -->
    <a-form v-if="type === EnumBirthSearchKbn.生年月日">
      <div v-if="props.filter.womanflg">
        <div>(女性)<span v-if="cond_woman" class="request-mark">＊</span></div>
        <a-radio-group v-model:value="cond_woman">
          <a-radio :value="false">条件なし</a-radio>
          <a-radio :value="true">条件あり</a-radio>
        </a-radio-group>
        <a-form-item v-bind="validateInfos_birth.woman">
          <RangeDate
            v-model:value="birthModel.woman"
            :placeholder="placeholder"
            :disabled="!cond_woman"
            unknown
          />
        </a-form-item>
      </div>
      <div v-if="props.filter.manflg">
        <div>(男性)<span v-if="cond_man" class="request-mark">＊</span></div>
        <a-radio-group v-model:value="cond_man">
          <a-radio :value="false">条件なし</a-radio>
          <a-radio :value="true">条件あり</a-radio>
        </a-radio-group>
        <a-form-item v-bind="validateInfos_birth.man">
          <RangeDate
            v-model:value="birthModel.man"
            :placeholder="placeholder"
            :disabled="!cond_man"
            unknown
          />
        </a-form-item>
      </div>
      <div v-if="props.filter.bothflg">
        <div>(両方)<span v-if="cond_both" class="request-mark">＊</span></div>
        <a-radio-group v-model:value="cond_both">
          <a-radio :value="false">条件なし</a-radio>
          <a-radio :value="true">条件あり</a-radio>
        </a-radio-group>
        <a-form-item v-bind="validateInfos_birth.both">
          <RangeDate
            v-model:value="birthModel.both"
            :placeholder="placeholder"
            :disabled="!cond_both"
            unknown
          />
        </a-form-item>
      </div>
      <div v-if="props.filter.unknownflg">
        <div>(不明・その他)<span v-if="cond_unknown" class="request-mark">＊</span></div>
        <a-radio-group v-model:value="cond_unknown">
          <a-radio :value="false">条件なし</a-radio>
          <a-radio :value="true">条件あり</a-radio>
        </a-radio-group>
        <a-form-item v-bind="validateInfos_birth.unknown">
          <RangeDate
            v-model:value="birthModel.unknown"
            :placeholder="placeholder"
            :disabled="!cond_unknown"
            unknown
          />
        </a-form-item>
      </div>
    </a-form>
  </a-collapse-panel>
</template>

<script setup lang="ts">
import { ITEM_ILLEGAL_ERROR, ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { computed, reactive, ref, watch } from 'vue'
import dayjs from 'dayjs'
import { Form } from 'ant-design-vue'
import { ss } from '@/utils/storage'
import { GLOBAL_YEAR } from '@/constants/mutation-types'
import { EnumBirthSearchKbn } from '#/Enums'
import RangeDate from '@/components/Selector/RangeDate/index.vue'
import { AgeVM, BirthVM } from '../type'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  title: string
  placeholder: string
  filter: {
    manflg: boolean
    womanflg: boolean
    bothflg: boolean
    unknownflg: boolean
  }
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const type = ref(EnumBirthSearchKbn.年齢)

const cond_woman = ref(false)
const cond_man = ref(false)
const cond_both = ref(false)
const cond_unknown = ref(false)
//初期化
const ageModel = reactive<AgeVM>({
  basedate: ss.get(GLOBAL_YEAR) + '-03-31',
  woman: '',
  man: '',
  both: '',
  unknown: ''
})
const birthModel = reactive<BirthVM>({
  woman: { value1: null, value2: null, yearflg: false, monthflg: false, dayflg: false },
  man: { value1: null, value2: null, yearflg: false, monthflg: false, dayflg: false },
  both: { value1: null, value2: null, yearflg: false, monthflg: false, dayflg: false },
  unknown: { value1: null, value2: null, yearflg: false, monthflg: false, dayflg: false }
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const cond_base = computed(() => {
  return cond_woman.value || cond_man.value || cond_both.value || cond_unknown.value
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch([cond_woman, cond_man, cond_both, cond_unknown], () => {
  validate_age()
  validate_birth()
})
//--------------------------------------------------------------------------
//チェック処理
//年齢：必須チェック
const ageRules = computed(() => {
  return {
    basedate: [
      {
        required: cond_base.value,
        message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '年齢計算基準日')
      }
    ],
    woman: [{ validator: (_, value) => validateRule_age(value, cond_woman.value, '女性') }],
    man: [{ validator: (_, value) => validateRule_age(value, cond_man.value, '男性') }],
    both: [{ validator: (_, value) => validateRule_age(value, cond_both.value, '両方') }],
    unknown: [{ validator: (_, value) => validateRule_age(value, cond_unknown.value, '不明') }]
  }
})
//生年月日：必須チェック
const birthRules = computed(() => {
  return {
    woman: [{ validator: (_, value) => validateRule_birth(value, cond_woman.value, '女性') }],
    man: [{ validator: (_, value) => validateRule_birth(value, cond_man.value, '男性') }],
    both: [{ validator: (_, value) => validateRule_birth(value, cond_both.value, '両方') }],
    unknown: [{ validator: (_, value) => validateRule_birth(value, cond_unknown.value, '不明') }]
  }
})
//年齢：入力内容制御
async function validateRule_age(value: string, cond: boolean, note: string) {
  if (value === '' && cond) {
    return Promise.reject(ITEM_REQUIRE_ERROR.Msg.replace('{0}', `年齢(${note})`))
  } else if (!/^(\d+(-\d+)?)(,\d+(-\d+)?)*$/.test(value) && cond) {
    return Promise.reject(ITEM_ILLEGAL_ERROR.Msg.replace('{0}', `年齢(${note})`))
  }
  return Promise.resolve()
}
//生年月日：入力内容制御
async function validateRule_birth(value, cond: boolean, note: string) {
  if (!value.value1 && !value.value2 && cond) {
    return Promise.reject(new Error(ITEM_REQUIRE_ERROR.Msg.replace('{0}', `生年月日(${note})`)))
  }
  return Promise.resolve()
}
//--------------------------------------------------------------------------
//入力された条件を一時保存
const useForm = Form.useForm
const {
  clearValidate: clearValidate_age,
  validate: validate_age,
  validateInfos: validateInfos_age
} = useForm(ageModel, ageRules)
const {
  clearValidate: clearValidate_birth,
  validate: validate_birth,
  validateInfos: validateInfos_birth
} = useForm(birthModel, birthRules)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//年齢：値設定
function validateAge() {
  return new Promise((resolve, reject) => {
    if (cond_base.value) {
      validate_age()
        .then(() => {
          resolve({
            type: EnumBirthSearchKbn.年齢,
            basedate: ageModel.basedate,
            woman: cond_woman.value ? ageModel.woman : '',
            man: cond_man.value ? ageModel.man : '',
            both: cond_both.value ? ageModel.both : '',
            unknown: cond_unknown.value ? ageModel.unknown : ''
          })
        })
        .catch(() => {
          reject()
        })
    } else {
      resolve(null)
    }
  })
}
//生年月日：値設定
function validateBirth() {
  return new Promise((resolve, reject) => {
    if (cond_base.value) {
      validate_birth()
        .then(() => {
          resolve({
            type: EnumBirthSearchKbn.生年月日,
            woman: cond_woman.value ? birthModel.woman : null,
            man: cond_man.value ? birthModel.man : null,
            both: cond_both.value ? birthModel.both : null,
            unknown: cond_unknown.value ? birthModel.unknown : null
          })
        })
        .catch(() => {
          reject()
        })
    } else {
      resolve(null)
    }
  })
}
//クリア処理
function clearValidate() {
  clearValidate_age()
  clearValidate_birth()
  cond_woman.value = false
  cond_man.value = false
  cond_both.value = false
  cond_unknown.value = false
}
//設定のため、タブ区分を判断
function validateByType() {
  return type.value === EnumBirthSearchKbn.年齢 ? validateAge() : validateBirth()
}

defineExpose({
  clearValidate,
  validate: validateByType,
  hasCondition: cond_base
})
</script>
