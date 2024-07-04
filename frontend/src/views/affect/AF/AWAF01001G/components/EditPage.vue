<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: バッチスケジュール(詳細画面)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.22
 * 作成者　　: 千秋
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card :bordered="false">
    <div class="self_adaption_table" :class="{ form: isNew }">
      <a-row>
        <a-col :md="12" :xl="6" :xxl="6">
          <th class="required">タスクID</th>
          <td v-if="isNew">
            <a-form-item v-bind="validateInfos.taskid">
              <a-input
                v-model:value="getformData.taskid"
                maxlength="6"
                @change="getformData.taskid = replaceText(getformData.taskid, EnumRegex.半角英数)"
              />
            </a-form-item>
          </td>
          <TD v-else>{{ getformData?.taskid }}</TD>
        </a-col>
        <a-col :md="12" :xl="6" :xxl="6">
          <th style="background-color: #ffffe1">処理日時（終了）</th>
          <TD>{{
            getformData.zenjikkodttmf ? getDateHmsJpText(new Date(getformData.zenjikkodttmf)) : ''
          }}</TD>
        </a-col>
        <a-col :md="12" :xl="6" :xxl="6">
          <th style="background-color: #ffffe1">処理日時（開始）</th>
          <TD>{{
            getformData.zenjikkodttmt ? getDateHmsJpText(new Date(getformData.zenjikkodttmt)) : ''
          }}</TD>
        </a-col>
        <a-col :md="12" :xl="6" :xxl="6">
          <th style="background-color: #ffffe1">処理結果</th>
          <TD>{{ getformData?.statuscd }}</TD>
        </a-col>
      </a-row>
    </div>
    <div class="m-t-1 header_operation">
      <a-space>
        <a-button class="warning-btn" :disabled="!canEdit" @click="submitData">登録</a-button>
        <a-button type="primary" :disabled="!canDelete && isNew" @click="onDelete">削除</a-button>
        <a-button type="primary" @click="goList">一覧へ</a-button>
        <a-button type="primary" :disabled="isNew" @click="clickRow">ログ管理</a-button>
      </a-space>
      <close-page></close-page>
    </div>
  </a-card>
  <a-card class="my-2" :loading="loading">
    <div class="self_adaption_table" :class="{ form: true }">
      <a-row>
        <a-col span="24">
          <th>状態</th>
          <td>
            <a-radio-group v-model:value="getformData.jotai" style="margin-left: 10px">
              <a-radio :value="'1'">有効</a-radio>
              <a-radio :value="'2'">無効</a-radio>
              <a-radio :value="'3'">未登録</a-radio>
            </a-radio-group>
          </td>
        </a-col>
        <a-col span="12">
          <th class="required">タスク名</th>
          <td>
            <a-form-item v-bind="validateInfos.tasknm">
              <a-input v-model:value="getformData.tasknm" />
            </a-form-item>
          </td>
        </a-col>
        <a-col span="6">
          <th>処理区分</th>
          <td><ai-select v-model:value="getformData.syorikbn" :options="syorikbnnmList" /></td>
        </a-col>
        <a-col span="6">
          <th>業務区分</th>
          <td><ai-select v-model:value="getformData.gyomukbn" :options="gyomukbnnmList" /></td>
        </a-col>
        <a-col span="24">
          <th>
            説明
            <div class="show_count_box">
              {{ `${getformData.biko?.length} / 2000` }}
            </div>
          </th>
          <td>
            <a-textarea
              v-model:value="getformData.biko"
              :auto-size="{ minRows: 2 }"
              :maxlength="2000"
            />
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">モジュール名</th>
          <td>
            <a-form-item v-bind="validateInfos.modulecd">
              <ai-select v-model:value="getformData.modulecd" :options="modulenmList" />
            </a-form-item>
          </td>
        </a-col>
        <a-col span="24">
          <th>引数</th>
          <td>
            <a-input v-model:value="getformData.hikisu" />
          </td>
        </a-col>
        <a-col span="24">
          <th class="required">開始時刻</th>
          <td>
            <a-row>
              <a-form-item v-bind="validateInfos.yukoymdf">
                <date-jp
                  v-model:value="getformData.yukoymdf"
                  style="width: 190px"
                  format="YYYY-MM-DD"
                />
              </a-form-item>
              <a-form-item v-bind="validateInfos.yukotmf">
                <a-time-picker
                  v-model:value="getformData.yukotmf"
                  value-format="HH:mm"
                  format="HH:mm"
                />
              </a-form-item>
            </a-row>
          </td>
        </a-col>
        <a-col span="24">
          <th>頻度</th>
          <td>
            <a-radio-group v-model:value="getformData.hindokbn" style="margin-left: 10px">
              <a-radio :value="'1'">毎日</a-radio>
              <a-radio :value="'2'">毎週</a-radio>
              <a-radio :value="'3'">毎月</a-radio>
              <a-radio :value="'0'">1回のみ</a-radio>
            </a-radio-group>
          </td>
        </a-col>
        <a-col span="24">
          <th>頻度詳細</th>
          <td v-if="getformData.hindokbn === EnumHindoKbn.毎日" class="td-padding">
            <a-col span="24" style="margin-top: -1px">
              <th>祝日</th>
              <td>
                <a-checkbox v-model:checked="getformData.syukustopflg">
                  祝日の場合に、次の営業日に実行する
                </a-checkbox>
              </td>
            </a-col>
          </td>
          <td v-else-if="getformData.hindokbn === EnumHindoKbn.毎週" class="td-padding">
            <a-col span="24" style="margin-top: -1px">
              <th>祝日</th>
              <td>
                <a-checkbox v-model:checked="getformData.syukustopflg">
                  祝日の場合に、次の営業日に実行する
                </a-checkbox>
              </td>
            </a-col>
            <a-col span="24">
              <th class="required">曜日</th>
              <td>
                <a-form-item v-bind="validateInfos.syuyobi">
                  <a-checkbox v-model:checked="getformData.sunday">日曜日</a-checkbox>
                  <a-checkbox v-model:checked="getformData.monday">月曜日</a-checkbox>
                  <a-checkbox v-model:checked="getformData.tuesday">火曜日</a-checkbox>
                  <a-checkbox v-model:checked="getformData.wednesday">水曜日</a-checkbox>
                  <a-checkbox v-model:checked="getformData.thursday"> 木曜日</a-checkbox>
                  <a-checkbox v-model:checked="getformData.friday">金曜日</a-checkbox>
                  <a-checkbox v-model:checked="getformData.saturday">土曜日</a-checkbox>
                </a-form-item>
              </td>
            </a-col>
          </td>
          <td v-else-if="getformData.hindokbn === EnumHindoKbn.毎月" class="td-padding">
            <a-col span="24" style="margin-top: -1px">
              <th>祝日</th>
              <td style="border-right: none">
                <a-checkbox v-model:checked="getformData.syukustopflg">
                  祝日の場合に、次の営業日に実行する
                </a-checkbox>
              </td>
            </a-col>
            <a-col span="24">
              <th class="required">月</th>
              <td style="border-right: none">
                <a-form-item v-bind="validateInfos.maitukituki">
                  <check-selector
                    v-model:checkbox-value-prop="getformData.maitukituki"
                    :options-prop="tukinmList"
                    :need-all-check="true"
                    :is-column="true"
                    max-tag-count="responsive"
                    style="width: 100%"
                    @mousedown="(e) => e.preventDefault()"
                  ></check-selector>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th coll class="required">
                <a-radio-group v-model:value="getformData.maitukihiyobikbn">
                  <a-radio :value="'0'">日</a-radio>
                </a-radio-group>
              </th>
              <td style="border-right: none">
                <a-form-item v-bind="validateInfos.maitukihi">
                  <check-selector
                    v-model:checkbox-value-prop="getformData.maitukihi"
                    :options-prop="nichinmList"
                    max-tag-count="responsive"
                    style="width: 100%"
                    :disabled="getformData.maitukihiyobikbn === '1'"
                    @mousedown="(e) => e.preventDefault()"
                  ></check-selector>
                </a-form-item>
              </td>
            </a-col>
            <a-col span="24">
              <th>
                <a-radio-group v-model:value="getformData.maitukihiyobikbn">
                  <a-radio :value="'1'">毎週</a-radio>
                </a-radio-group>
              </th>
              <td style="border-right: none">
                <a-row>
                  <a-col span="8">
                    <th class="required">週次</th>
                    <td>
                      <a-form-item v-bind="validateInfos.maitukisyu">
                        <check-selector
                          v-model:checkbox-value-prop="getformData.maitukisyu"
                          :options-prop="syunmList"
                          max-tag-count="responsive"
                          :is-column="true"
                          style="width: 100%"
                          :disabled="getformData.maitukihiyobikbn === '0'"
                          @mousedown="(e) => e.preventDefault()"
                        ></check-selector>
                      </a-form-item>
                    </td>
                  </a-col>
                  <a-col span="16">
                    <th class="required">曜日</th>
                    <td>
                      <a-form-item v-bind="validateInfos.yobi">
                        <check-selector
                          v-model:checkbox-value-prop="getformData.yobi"
                          :options-prop="yobinmList"
                          max-tag-count="responsive"
                          :is-column="true"
                          :need-all-check="true"
                          style="width: 100%"
                          :disabled="getformData.maitukihiyobikbn === '0'"
                          @mousedown="(e) => e.preventDefault()"
                        ></check-selector>
                      </a-form-item>
                    </td>
                  </a-col>
                </a-row>
              </td>
            </a-col>
            <!-- 日 -->
          </td>
          <td v-else-if="getformData.hindokbn === EnumHindoKbn.一回のみ" class="td-padding"></td>
        </a-col>
        <a-col span="8">
          <th>
            <a-checkbox v-model:checked="getformData.kurikaesikanflg">繰り返し間隔</a-checkbox>
          </th>
          <td>
            <a-form-item v-bind="validateInfos.kurikaesikankbn">
              <ai-select
                v-model:value="getformData.kurikaesikankbn"
                :disabled="!getformData.kurikaesikanflg"
                :options="kurikaeshikannmList"
            /></a-form-item>
          </td>
        </a-col>
        <a-col span="8">
          <th>実行時間帯（時）</th>
          <td>
            <a-row>
              <div>
                <RangeTime
                  v-model:value1="getformData.jikantaif"
                  v-model:value2="getformData.jikantait"
                  value-format="HH"
                  :disabled="!getformData.kurikaesikanflg"
                />
              </div>
            </a-row>
          </td>
        </a-col>
        <a-col span="8">
          <th>実行時間帯（分）</th>
          <td>
            <a-row>
              <div>
                <RangeTime
                  v-model:value1="getformData.jikannaif"
                  v-model:value2="getformData.jikannait"
                  value-format="mm"
                  :disabled="!getformData.kurikaesikanflg"
                />
              </div>
            </a-row></td
        ></a-col>
      </a-row>
    </div>
  </a-card>
  <StaffModal v-model:visible="modalVisible" />
</template>

<script setup lang="ts">
import { EnumRegex, Enum編集区分, PageSatatus, EnumHindoKbn } from '#/Enums'
import { onMounted, reactive, ref, watch, nextTick, computed, toRaw } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { Form, message, Modal } from 'ant-design-vue'
import { DELETE_OK_INFO, ITEM_REQUIRE_ERROR, SAVE_OK_INFO, ITEM_RANGE_ERROR } from '@/constants/msg'
import { InitDetail, Save, SearchDetail, Delete } from '../service'

import { MainInfoVM } from '../type'
import { showSaveModal } from '@/utils/modal'
import { showDeleteModal } from '@/utils/modal'
import { Judgement } from '@/utils/judge-edited'
import { getDateHmsJpText, transferToPage } from '@/utils/util'
import StaffModal from '@/views/affect/AF/AWAF00704D/index.vue'
import TD from '@/components/Common/TableTD/index.vue'
import { replaceText } from '@/utils/util'
import CheckSelector from '@/components/Selector/CheckSelector/index.vue'
import RangeTime from '@/components/Selector/RangeTime/index.vue'

// const canDelete = computed(() => !isNew && canEdit)
const syorikbnnmList = ref<DaSelectorModel[]>([])
const gyomukbnnmList = ref<DaSelectorModel[]>([])
const modulenmList = ref<DaSelectorModel[]>([])
const tukinmList = ref<DaSelectorModel[]>([])
const nichinmList = ref<DaSelectorModel[]>([])
const syunmList = ref<DaSelectorModel[]>([])
const yobinmList = ref<DaSelectorModel[]>([])
const kurikaeshikannmList = ref<DaSelectorModel[]>([])

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  status: PageSatatus
}>()

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const route = useRoute()
const loading = ref(true)
const editJudge = new Judgement(route.name as string)
const modalVisible = ref(false)
const isNew = props.status === PageSatatus.New

const getformData = reactive<MainInfoVM>({
  taskid: '',
  tasknm: '',
  biko: '',
  zenjikkodttmf: '',
  zenjikkodttmt: '',
  syoridttmf: '',
  syorikbn: '',
  gyomukbn: '',
  modulecd: '',
  yukoymdf: '',
  yukotmf: '',
  hindokbn: '0',
  syukustopflg: false,
  yobi: [],
  maitukihiyobikbn: '0',
  maitukituki: [],
  maitukihi: [],
  maitukisyu: [],
  hikisu: '',
  jotai: '3',
  statuscd: '',
  kurikaesikanflg: false,
  kurikaesikankbn: '',
  keizokujikankbn: '',
  jikantaif: '',
  jikantait: '',
  jikannaif: '',
  jikannait: '',
  sunday: false,
  monday: false,
  tuesday: false,
  wednesday: false,
  thursday: false,
  friday: false,
  saturday: false,
  upddttm: '',
  syuyobi: ''
})
//項目の設定
const rules = reactive({
  taskid: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'タスクID') }],
  tasknm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'タスク名') }],
  modulecd: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', 'モジュール名') }],
  yukoymdf: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '開始日') }],
  yukotmf: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '開始時刻') }],
  syuyobi: [
    {
      required: true,
      validator: customValidator
    }
  ],
  maitukituki: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '月') }],
  maitukihi: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '日') }],
  maitukisyu: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '週次') }],
  yobi: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '曜日') }],
  kurikaesikankbn: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '繰り返し間隔') }
  ]
})
const { validate, validateInfos } = Form.useForm(getformData, rules)

//操作権限フラグ
const canEdit = isNew || route.meta.updflg
const canDelete = route.meta.delflg

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  editJudge.addEvent()
  loading.value = true
  try {
    await InitDetail().then((res) => {
      syorikbnnmList.value = res.syorikbnnmList
      gyomukbnnmList.value = res.gyomukbnnmList
      modulenmList.value = res.modulenmList
      tukinmList.value = res.tukinmList
      nichinmList.value = res.nichinmList
      syunmList.value = res.syunmList
      yobinmList.value = res.yobinmList
      kurikaeshikannmList.value = res.kurikaeshikannmList
    })
    if (!isNew) {
      const res = await SearchDetail({
        taskid: route.query.taskid as string,
        editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更
      })

      Object.assign(getformData, res.mainInfo)
    }
  } catch (error) {}
  nextTick(() => editJudge.reset())
  loading.value = false
})

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(getformData, () => editJudge.setEdited())

watch(
  () => getformData.maitukihiyobikbn,
  (nVal) => {
    if (nVal === '0') {
      rules.maitukihi[0].required = true
      rules.maitukisyu[0].required = false
      rules.yobi[0].required = false
    } else {
      rules.maitukihi[0].required = false
      rules.maitukisyu[0].required = true
      rules.yobi[0].required = true
    }
  },
  { immediate: true }
)
watch(
  () => getformData.kurikaesikanflg,
  (nVal) => {
    if (nVal === true) {
      rules.kurikaesikankbn[0].required = true
    } else {
      rules.kurikaesikankbn[0].required = false
    }
  },
  { immediate: true }
)
watch(
  () => getformData.hindokbn,
  (nVal) => {
    rules.maitukituki[0].required = false
    rules.maitukihi[0].required = false
    rules.maitukisyu[0].required = false
    rules.yobi[0].required = false
    if (nVal === '1' || nVal === '0') {
      rules.syuyobi[0].required = false
    } else if (nVal === '2') {
      rules.syuyobi[0].required = true
    } else if (nVal === '3') {
      rules.syuyobi[0].required = false
      rules.maitukituki[0].required = true
      rules.maitukihi[0].required = true
      rules.maitukisyu[0].required = false
      rules.yobi[0].required = false
    }
  },
  { immediate: true }
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

function customValidator() {
  return new Promise((resolve, reject) => {
    if (getformData.hindokbn !== EnumHindoKbn.毎週) {
      resolve(true)
    }
    const { sunday, monday, tuesday, wednesday, thursday, friday, saturday } = toRaw(getformData)
    const i = [sunday, monday, tuesday, wednesday, thursday, friday, saturday].findIndex(
      (el) => el === true
    )
    if (i >= 0) {
      resolve(true)
    } else {
      reject(new Error(ITEM_REQUIRE_ERROR.Msg.replace('{0}', '曜日')))
    }
  })
}

async function submitData() {
  await validate()
  showSaveModal({
    onOk: async () => {
      await Save({
        maininfo: getformData,
        upddttm: getformData.upddttm,
        editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更
      })
      message.success(SAVE_OK_INFO.Msg)
      router.push({ name: route.name as string, query: { refresh: '1' } })
    }
  })
}
//画面遷移
const goList = () => {
  editJudge.judgeIsEdited(() => {
    router.push({ name: route.name as string })
  })
}
//ログ画面遷移確認
const clickRow = ({ row }) => {
  const menuid = 'AWAF00803G'
  transferToPage(menuid, () => {
    router.push({
      name: menuid
    })
  })
}

//削除処理
function onDelete() {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      await Delete({
        taskid: getformData.taskid
      })
      message.success(DELETE_OK_INFO.Msg)
      router.push({ name: route.name as string, query: { refresh: '1' } })
    }
  })
}
//--------------------------------------------------------------------------
</script>

<style scoped lang="less">
.self_adaption_table th {
  width: 130px;
}
:deep(.ant-form-item-extra) {
  color: #faad14;
}

.td-padding {
  padding: 0 !important;
}

.check-colume {
  display: flex;
  flex-direction: column;
}
</style>
