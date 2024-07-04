<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: 拡張事業・成人検診予約日程
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2024.01.16
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <a-card :loading="loading">
    <div ref="headRef">
      <h3 class="font-bold">成人健（検）診予約日程事業</h3>
      <div class="self_adaption_table">
        <a-row>
          <a-col>
            <th class="w-25">年度</th>
            <TD style="width: 125px">{{ yearFormatter(Number($route.query.nendo)) }}</TD>
          </a-col>
        </a-row>
      </div>
      <div class="flex justify-between mt-2 mb-4">
        <a-space>
          <a-button type="warn" :disabled="!canEdit" @click="saveData">登録</a-button>
          <a-button type="primary" danger :disabled="!canDelete" @click="deleteData">削除</a-button>
          <a-button type="primary" @click="back2list(C001010.Msg)">一覧へ</a-button>
        </a-space>
        <close-page />
      </div>
      <div class="self_adaption_table max-w-200 mb-4" :class="canEdit && 'form'">
        <a-row>
          <a-col span="24">
            <th class="w-60" :class="isNew ? 'required' : 'bg-readonly'">
              成人健（検）診予約日程事業名
            </th>
            <td v-if="isNew">
              <a-form-item v-bind="validateInfos.jigyocdnm">
                <ai-select
                  v-model:value="formData.jigyocdnm"
                  :options="selectorlist2"
                  @change="editJudge.setEdited()"
                ></ai-select>
              </a-form-item>
            </td>
            <TD v-else>{{ formData.jigyonm }}</TD>
          </a-col>
          <a-col span="24">
            <th class="w-60 required">料金パターン</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.ryokinpatterncdnm">
                <ai-select
                  v-model:value="formData.ryokinpatterncdnm"
                  :options="selectorlist1"
                  @change="editJudge.setEdited()"
                ></ai-select>
              </a-form-item>
            </td>
            <TD v-else>{{ formData.ryokinpatterncdnm }}</TD>
          </a-col>
        </a-row>
      </div>
    </div>

    <vxe-table
      ref="xTableRef"
      :height="Math.max(tableHeight, 300)"
      :scroll-y="{ enabled: true, oSize: 10 }"
      :column-config="{ resizable: true }"
      :data="tableData"
      :empty-render="{ name: 'NotData' }"
      :header-cell-class-name="canEdit ? 'bg-editable' : 'bg-readonly'"
      :cell-class-name="({ row }) => (row.jissiflg ? 'bg-sky-300' : '')"
    >
      <vxe-column title="実施" min-width="70" width="10%">
        <template #default="{ row }">
          <a-checkbox
            v-model:checked="row.jissiflg"
            :disabled="row.jissieditflg || !canEdit"
            @change="editJudge.setEdited()"
          ></a-checkbox>
        </template>
      </vxe-column>
      <vxe-colgroup title="検診種別" align="center">
        <vxe-column field="jigyocd" title="コード" width="15%"> </vxe-column>
        <vxe-column field="jigyonm" title="名称" width="25%"> </vxe-column>
      </vxe-colgroup>
      <vxe-colgroup title="検査方法" align="center">
        <vxe-column
          field="kensahohocd"
          title="コード"
          width="15%"
          :class-name="({ row }) => (!row.kensahohocd && !row.jissiflg ? 'bg-disabled' : '')"
        ></vxe-column>
        <vxe-column
          field="kensahohonm"
          title="名称"
          width="25%"
          :class-name="({ row }) => (!row.kensahohonm && !row.jissiflg ? 'bg-disabled' : '')"
        ></vxe-column>
      </vxe-colgroup>
      <vxe-column title="オプション" min-width="70" :resizable="false">
        <template #default="{ row }">
          <a-checkbox
            v-model:checked="row.optionflg"
            :disabled="!canEdit"
            @change="editJudge.setEdited()"
          ></a-checkbox>
        </template>
      </vxe-column>
    </vxe-table>
  </a-card>
</template>

<script setup lang="ts">
import { Enum編集区分 } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'
import {
  C001010,
  C011008,
  DELETE_OK_INFO,
  ITEM_SELECTREQUIRE_ERROR,
  SAVE_OK_INFO
} from '@/constants/msg'
import { editStore1 } from '@/store'
import { useTableHeight } from '@/utils/hooks'
import { showDeleteModal, showSaveModal } from '@/utils/modal'
import { yearFormatter } from '@/utils/util'
import { Form, message } from 'ant-design-vue'
import { computed, onMounted, reactive, ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import {
  DeleteKensinYoyakuJigyoDetail,
  InitKensinYoyakuJigyoDetail,
  SaveKensinYoyakuJigyoDetail
} from '../service'
import { KensinYoyakuDetailRowVM } from '../type'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const emit = defineEmits(['afterSave'])
const loading = ref(true)
const router = useRouter()
const route = useRoute()
const isNew = Number(route.query.jigyocd) < 0
const { editJudge } = editStore1
const tableData = ref<KensinYoyakuDetailRowVM[]>([])
const formData = reactive({ jigyocdnm: '', jigyonm: '', ryokinpatterncdnm: '', upddttm: '' })
const selectorlist1 = ref<DaSelectorModel[]>([]) //料金パターン
const selectorlist2 = ref<DaSelectorModel[]>([]) //検診予約事業
//項目の設定
const rules = reactive({
  jigyocdnm: [
    {
      required: isNew,
      message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '成人健（検）診予約日程事業名')
    }
  ],
  ryokinpatterncdnm: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '料金パターン') }
  ]
})
const { validate, validateInfos } = Form.useForm(formData, rules)

//check use
let pattern = ''
let checked_before: number[] = []
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  try {
    const res = await InitKensinYoyakuJigyoDetail({
      jigyocd: route.query.jigyocd as string,
      editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
      nendo: Number(route.query.nendo)
    })
    selectorlist1.value = res.selectorlist1
    selectorlist2.value = res.selectorlist2
    Object.assign(formData, res.maininfo)
    tableData.value = res.kekkalist.map((item, index) => ({ ...item, key: index + 1 }))
    //check use
    pattern = res.maininfo.ryokinpatterncdnm
    checked_before = tableData.value.map((el) => (el.jissiflg ? el.key : 0)).filter(Boolean)
  } catch (error) {}
  loading.value = false
})

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const headRef = ref(null)
const { tableHeight } = useTableHeight(headRef, 32)
//操作権限フラグ
const canEdit = computed(() => isNew || route.meta.updflg)
const canDelete = computed(() => !isNew && route.meta.delflg)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//保存処理
async function saveData() {
  await validate()

  // チェック
  let chkflg = false
  const checked_after = tableData.value.map((el) => (el.jissiflg ? el.key : 0)).filter(Boolean)
  if (
    !checked_before.every((value) => checked_after.includes(value)) ||
    pattern !== formData.ryokinpatterncdnm
  ) {
    chkflg = true
  }

  showSaveModal({
    content: tableData.value.every((item) => !item.jissiflg) && C011008.Msg,
    async onOk() {
      try {
        await SaveKensinYoyakuJigyoDetail({
          jigyocd: route.query.jigyocd as string,
          maininfo: formData,
          kekkalist: tableData.value,
          editkbn: isNew ? Enum編集区分.新規 : Enum編集区分.変更,
          nendo: Number(route.query.nendo),
          chkflg: isNew ? true : chkflg
        })
        message.success(SAVE_OK_INFO.Msg)
        editJudge.reset()
        emit('afterSave')
        back2list()
      } catch (error) {}
    }
  })
}
//削除処理
function deleteData() {
  showDeleteModal({
    handleDB: true,
    async onOk() {
      try {
        await DeleteKensinYoyakuJigyoDetail({
          jigyocd: route.query.jigyocd as string,
          upddttm: formData.upddttm,
          nendo: Number(route.query.nendo)
        })
        editJudge.reset()
        message.success(DELETE_OK_INFO.Msg)
        emit('afterSave')
        back2list()
      } catch (error) {}
    }
  })
}

function back2list(msg?) {
  editJudge.judgeIsEdited(() => {
    router.push({
      name: route.name as string,
      query: { ...route.query, jigyocd: undefined }
    })
  }, msg)
}
</script>
