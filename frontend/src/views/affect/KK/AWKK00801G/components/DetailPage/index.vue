<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 拡張事業・成人健（検）診事業詳細
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.09
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div>
    <a-card>
      <h3 class="font-bold">成人健（検）診事業</h3>
      <div class="self_adaption_table">
        <a-row>
          <a-col span="8">
            <th>検診種別コード</th>
            <TD>{{ isNew ? '' : route.query.jigyocd }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="mt-2 flex justify-between">
        <a-space>
          <a-button type="warn" :disabled="!canEdit" @click="saveData">登録</a-button>
          <a-button type="primary" @click="back2list(C001010.Msg)">一覧へ</a-button>
        </a-space>
        <close-page></close-page>
      </div>
    </a-card>

    <a-card class="my-2" :loading="loading">
      <h3 class="font-bold">事業</h3>
      <div :class="[canEdit && 'form', 'self_adaption_table max-w-240 mb-6']">
        <a-row>
          <a-col span="21">
            <th class="required">検診種別名</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.jigyonm">
                <a-input
                  v-model:value="header.jigyonm"
                  maxlength="25"
                  allow-clear
                  @blur="onBlurJigyonm"
                />
              </a-form-item>
            </td>
            <TD v-else>{{ header.jigyonm }}</TD>
          </a-col>
          <a-col span="21">
            <th class="required">略称</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.jigyoshortnm">
                <a-input v-model:value="header.jigyoshortnm" maxlength="1" allow-clear />
              </a-form-item>
            </td>
            <TD v-else>{{ header.jigyoshortnm }}</TD>
            <span class="absolute right--21 top-2">(1文字まで)</span>
          </a-col>
          <a-col span="21">
            <th class="required">メニュー表示名称</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos2.hyojinm">
                <a-input v-model:value="jigyoinfo.hyojinm" maxlength="30" allow-clear />
              </a-form-item>
            </td>
            <TD v-else>{{ jigyoinfo.hyojinm }}</TD>
          </a-col>
          <a-col span="21">
            <th class="required">精密検査実施</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos2.seikenjissikbn">
                <ai-select v-model:value="jigyoinfo.seikenjissikbn" :options="selectorlist1" />
              </a-form-item>
            </td>
            <TD v-else>{{ jigyoinfo.seikenjissikbn }}</TD>
          </a-col>
          <a-col span="21">
            <th class="required">クーポン券</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos2.cuponhyojikbn">
                <ai-select v-model:value="jigyoinfo.cuponhyojikbn" :options="selectorlist2" />
              </a-form-item>
            </td>
            <TD v-else>{{ jigyoinfo.cuponhyojikbn }}</TD>
          </a-col>
          <a-col span="21">
            <th class="required">減免区分</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos2.genmenkbn">
                <ai-select v-model:value="jigyoinfo.genmenkbn" :options="selectorlist3" />
              </a-form-item>
            </td>
            <TD v-else>{{ jigyoinfo.genmenkbn }}</TD>
          </a-col>
          <a-col span="21">
            <th class="required">生涯１回フラグ</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos2.syogaiikaiflg">
                <ai-select v-model:value="jigyoinfo.syogaiikaiflg" :options="selectorlist4" />
              </a-form-item>
            </td>
            <TD v-else>{{ jigyoinfo.syogaiikaiflg }}</TD>
          </a-col>
        </a-row>
      </div>

      <Table1
        ref="table1Ref"
        v-model:data="hohoinfo"
        class="mb-6"
        @change="filterTable2Checkmethod"
      />
      <Table2
        ref="table2Ref"
        v-model:data="yoyakuinfo"
        :hoholist="hohoinfo.kekkalist"
        :setflg="hohoinfo.kensahoho_setflg"
        class="mb-6"
      />
      <Table3 ref="table3Ref" v-model:data="freeinfo" />

      <h3 class="font-bold mt-6">エラーチェック</h3>
      <div :class="[canEdit && 'form', 'self_adaption_table max-w-100']">
        <a-row>
          <a-col span="21">
            <th class="required">予約画面</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos3.yoyakuchk">
                <ai-select v-model:value="errorchkinfo.yoyakuchk" :options="selectorlist5" />
              </a-form-item>
            </td>
            <TD v-else>{{ errorchkinfo.yoyakuchk }}</TD>
          </a-col>
          <a-col span="21">
            <th class="required">健（検）診画面</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos3.kensinchk">
                <ai-select v-model:value="errorchkinfo.kensinchk" :options="selectorlist5" />
              </a-form-item>
            </td>
            <TD v-else>{{ errorchkinfo.kensinchk }}</TD>
          </a-col>
        </a-row>
      </div>
    </a-card>
  </div>
</template>

<script setup lang="ts">
import {
  Enum減免区分種別,
  Enum生涯１回フラグ,
  Enum画面表示区分,
  Enum精密検査実施区分,
  Enum編集区分
} from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'
import {
  C001010,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  SAVE_OK_INFO
} from '@/constants/msg'
import { editStore1 } from '@/store'
import { showSaveModal } from '@/utils/modal'
import { Form, message } from 'ant-design-vue'
import { onMounted, reactive, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { InitKensinJigyoDetail, SaveKensinJigyoDetail } from '../../service'
import {
  KensinCommonHeaderVM,
  KensinDetailErrorchkVM,
  KensinDetailFreeVM,
  KensinDetailHohoRowVM,
  KensinDetailHohoVM,
  KensinDetailJigyoVM,
  KensinDetailYoyakuVM
} from '../../type'
import Table1 from './Table1.vue'
import Table2 from './Table2.vue'
import Table3 from './Table3.vue'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const emit = defineEmits(['afterSave'])
const router = useRouter()
const route = useRoute()
const loading = ref(false)
const isNew = Number(route.query.jigyocd) < 0
const { editJudge } = editStore1

const header = ref<KensinCommonHeaderVM>({
  jigyonm: '',
  jigyoshortnm: ''
})
const jigyoinfo = ref<KensinDetailJigyoVM>({
  hyojinm: '',
  seikenjissikbn: '',
  cuponhyojikbn: '',
  genmenkbn: '',
  syogaiikaiflg: ''
})
/**検査方法*/
const hohoinfo = ref<KensinDetailHohoVM>({
  kensahoho_maincdnm: '',
  kensahoho_setflg: false,
  kensahoho_subcdnm: '',
  kekkalist: []
})
/**予約分類*/
const yoyakuinfo = ref<KensinDetailYoyakuVM>({
  yoyakubunrui_maincdnm: '',
  yoyakubunrui_subcdnm: '',
  kekkalist: []
})
/**フリー項目*/
const freeinfo = ref<KensinDetailFreeVM>({
  groupid2_maincdnm: '',
  groupid2_subcdnm: '',
  kekkalist: []
})
const errorchkinfo = ref<KensinDetailErrorchkVM>({
  yoyakuchk: '',
  kensinchk: ''
})
let upddttm

const table1Ref = ref<InstanceType<typeof Table1> | null>(null)
const table2Ref = ref<InstanceType<typeof Table2> | null>(null)
const table3Ref = ref<InstanceType<typeof Table3> | null>(null)
/** 精密検査実施区分ドロップダウンリスト */
const selectorlist1 = ref<DaSelectorModel[]>([])
/** クーポン券表示区分ドロップダウンリスト */
const selectorlist2 = ref<DaSelectorModel[]>([])
/** 減免区分ドロップダウンリスト */
const selectorlist3 = ref<DaSelectorModel[]>([])
/** 生涯１回ドロップダウンリスト */
const selectorlist4 = ref<DaSelectorModel[]>([])
/** メッセージ区分一覧ドロップダウンリスト */
const selectorlist5 = ref<DaSelectorModel[]>([])
//項目の設定
const rules = reactive({
  jigyonm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '検診種別名') }],
  jigyoshortnm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '略称') }],
  hyojinm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'メニュー表示名称') }],
  seikenjissikbn: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '精密検査実施') }
  ],
  cuponhyojikbn: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'クーポン券') }
  ],
  genmenkbn: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '減免区分') }],
  syogaiikaiflg: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '生涯１回フラグ') }
  ],
  yoyakuchk: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'エラーチェック')
    }
  ],
  kensinchk: [
    {
      required: true,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', 'エラーチェック')
    }
  ]
})
const { validate, validateInfos } = Form.useForm(header, rules)
const {
  validate: validate2,
  validateInfos: validateInfos2,
  clearValidate: clearValidate2
} = Form.useForm(jigyoinfo, rules)
const {
  validate: validate3,
  validateInfos: validateInfos3,
  clearValidate: clearValidate3
} = Form.useForm(errorchkinfo, rules)
//操作権限フラグ
const canEdit = isNew || route.meta.updflg

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  searchData()
})

//---------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => [header, jigyoinfo, hohoinfo, yoyakuinfo, freeinfo],
  () => editJudge.setEdited(),
  { deep: true }
)

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
async function searchData() {
  loading.value = true
  try {
    const res = await InitKensinJigyoDetail({
      jigyocd: isNew ? '' : (route.query.jigyocd as string)
    })
    selectorlist1.value = res.selectorlist1
    selectorlist2.value = res.selectorlist2
    selectorlist3.value = res.selectorlist3
    selectorlist4.value = res.selectorlist4
    selectorlist5.value = res.selectorlist5
    header.value = res.headerinfo
    jigyoinfo.value = res.jigyoinfo
    hohoinfo.value = res.hohoinfo
    yoyakuinfo.value = res.yoyakuinfo
    freeinfo.value = res.freeinfo
    errorchkinfo.value = res.errorchkinfo
    //remoteflg
    hohoinfo.value.kekkalist.forEach((el) => (el.remoteflg = true))
    yoyakuinfo.value.kekkalist.forEach((el) => (el.remoteflg = true))
    freeinfo.value.kekkalist.forEach((el) => (el.remoteflg = true))
    upddttm = res.upddttm
    //新規初期値
    if (isNew) {
      jigyoinfo.value.cuponhyojikbn = `${Enum画面表示区分.非表示} : ${
        selectorlist2.value.find((item) => +item.value === Enum画面表示区分.非表示)?.label
      }`
      jigyoinfo.value.genmenkbn = `${Enum減免区分種別.がん検診} : ${
        selectorlist3.value.find((item) => +item.value === Enum減免区分種別.がん検診)?.label
      }`
      jigyoinfo.value.syogaiikaiflg = `${Enum生涯１回フラグ.生涯複数回} : ${
        selectorlist4.value.find((item) => +item.value === Enum生涯１回フラグ.生涯複数回)?.label
      }`
    } else {
      //精密検査実施区分: 既に精密検査のデータが登録されている場合、変更不可とする
      if (+res.jigyoinfo.seikenjissikbn.split(' : ')[0] === Enum精密検査実施区分.実施) {
        for (const opt of selectorlist1.value) {
          opt.disabled = +opt.value === Enum精密検査実施区分.未実施
        }
      }
    }
  } catch (error) {}
  loading.value = false
  setTimeout(() => {
    clearValidate2()
    clearValidate3()
    editJudge.reset()
  }, 0)
}

function back2list(msg?) {
  editJudge.judgeIsEdited(() => {
    router.push({
      name: route.name as string,
      query: { ...route.query, jigyocd: undefined }
    })
  }, msg)
}

//filter 予約分類の検査方法／内訳コード
function filterTable2Checkmethod(tabledata: KensinDetailHohoRowVM[]) {
  const arr = tabledata.map((el) => el.kensahohocd)
  for (const el of yoyakuinfo.value.kekkalist) {
    el.yoyakubunruilist = el.yoyakubunruilist.filter((str) => arr.includes(str))
  }
}

//保存処理
async function saveData() {
  await Promise.all([
    validate(),
    validate2(),
    validate3(),
    table1Ref.value?.validate(),
    table2Ref.value?.validate(),
    table3Ref.value?.validate()
  ])

  if (
    !freeinfo.value.kekkalist.length ||
    (hohoinfo.value.kensahoho_setflg &&
      (!hohoinfo.value.kekkalist.length ||
        !yoyakuinfo.value.kekkalist.length ||
        !freeinfo.value.kekkalist.length))
  ) {
    message.warn('一つ以上設定する必要')
    return
  }

  showSaveModal({
    onOk: async () => {
      try {
        const { kinoid } = await SaveKensinJigyoDetail({
          upddttm,
          editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
          jigyocd: isNew ? '' : (route.query.jigyocd as string),
          jigyonm: header.value.jigyonm,
          jigyoshortnm: header.value.jigyoshortnm,
          jigyoinfo: jigyoinfo.value,
          hohoinfo: hohoinfo.value,
          yoyakuinfo: yoyakuinfo.value,
          freeinfo: freeinfo.value,
          errorchkinfo: errorchkinfo.value
        })
        message.success(SAVE_OK_INFO.Msg)
        editJudge.reset()
        emit('afterSave', isNew && kinoid)
        back2list()
      } catch (error) {}
    }
  })
}

//メニュー表示名称 初期設定
function onBlurJigyonm() {
  if (header.value.jigyonm && !jigyoinfo.value.hyojinm) {
    jigyoinfo.value.hyojinm = header.value.jigyonm + '結果管理'
  }
}
</script>

<style lang="less" scoped>
:deep(.self_adaption_table th) {
  width: 140px;
}
:deep(.vxe-header--column .vxe-cell--required-icon) {
  display: none;
}
</style>
