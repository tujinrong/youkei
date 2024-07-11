<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ユーザー管理(詳細画面：ユーザー　所属グループ情報)
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.06.12
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="m1">
    <a-checkbox v-if="!isNew" v-model:checked="formData.stopflg" class="mb-1"> 停止 </a-checkbox>
    <a-form ref="formRef" :model="formData" :rules="rules">
      <div class="self_adaption_table form">
        <a-row>
          <a-col span="24" class="head-grey">
            <th>グループ情報</th>
            <td></td>
          </a-col>
          <a-col span="24">
            <th>所属グループ名<span class="request-mark">＊</span></th>
            <td>
              <a-form-item name="syozokunm">
                <a-input
                  v-model:value="formData.syozokunm"
                  @change="formData.syozokunm = replaceText(formData.syozokunm, EnumRegex.全角)"
                ></a-input>
              </a-form-item>
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="self_adaption_table form m-t-2">
        <a-row>
          <a-col span="24" class="head-grey">
            <th>ユーザー権限</th>
            <td></td>
          </a-col>
          <a-col span="24">
            <th>管理者</th>
            <TD>
              <a-radio-group v-model:value="formData.kanrisyaflg" name="kanrisyaflg">
                <a-radio :value="true">権限あり</a-radio>
                <a-radio :value="false">権限なし</a-radio>
              </a-radio-group>
            </TD>
          </a-col>
          <a-col v-if="pnoeditflg" span="24">
            <th :class="{ 'bg-readonly': !formData.kanrisyaflg }">個人番号操作権限付与者</th>
            <TD>
              <div>
                <span v-if="!formData.kanrisyaflg">{{
                  formData.pnoeditflg ? '権限あり' : '権限なし'
                }}</span>
                <a-radio-group v-else v-model:value="formData.pnoeditflg" name="pnoeditflg">
                  <a-radio :value="true">権限あり</a-radio>
                  <a-radio :value="false">権限なし</a-radio>
                </a-radio-group>
              </div>
            </TD>
          </a-col>
          <a-col span="24">
            <th>警告参照区分</th>
            <TD>
              <a-radio-group v-model:value="formData.alertviewflg" name="alertviewflg">
                <a-radio :value="true">参照可能</a-radio>
                <a-radio :value="false">参照不可</a-radio>
              </a-radio-group>
            </TD>
          </a-col>
          <a-col span="24">
            <th>登録部署別更新権限</th>
            <td>
              <div class="flex">
                <a-select
                  :value="formData.editsisyolist.map((i) => i.sisyocd)"
                  mode="multiple"
                  style="width: 100%"
                  :options="sisyolist"
                  :field-names="{ label: 'sisyonm', value: 'sisyocd' }"
                  :filter-option="filterOption"
                  @change="changeEditsisyo"
                >
                  <template #option="{ sisyonm, sisyocd }">
                    {{ sisyocd + ' : ' + sisyonm }}
                  </template>
                </a-select>
                <a-button type="primary" class="ml1" @click="() => (updVisible = true)"
                  >設定</a-button
                >
              </div>
            </td>
          </a-col>
        </a-row>
      </div>
    </a-form>
    <div class="m-t-2 flex flex-col">
      <a-button type="primary" class="ml-auto" @click="() => (userVisible = true)"
        >ユーザー設定</a-button
      >
      <vxe-table
        :height="tableHeight"
        :scroll-y="{ enabled: true, oSize: 10 }"
        :data="formData.userlist1"
        :column-config="{ resizable: true }"
        :row-config="{ isCurrent: true, isHover: true }"
        :sort-config="{ trigger: 'cell' }"
        :empty-render="{ name: 'NotData' }"
      >
        <vxe-column field="userid" title="ユーザーID" min-width="120" sortable> </vxe-column>
        <vxe-column field="usernm" title="ユーザー名" min-width="120" sortable> </vxe-column>
        <vxe-column field="syozokunm" title="所属グループ" min-width="120" sortable></vxe-column>
        <vxe-column
          field="yukoymdf"
          title="有効年月日（開始）"
          min-width="160"
          sortable
        ></vxe-column>
        <vxe-column
          field="yukoymdt"
          title="有効年月日（終了）"
          min-width="160"
          sortable
        ></vxe-column>
        <vxe-column field="status" title="状態" min-width="70" width="120" sortable></vxe-column>
      </vxe-table>
    </div>
    <LoginUpdModal
      v-model:visible="updVisible"
      v-model:selected-data="formData.editsisyolist"
      :sisyolist="sisyolist"
    />
    <UserSetModal
      v-model:visible="userVisible"
      v-model:selected-data="formData.userlist1"
      :alluser-data="formData.userlist2"
      :syozokunm="formData.syozokunm"
    />
  </div>
</template>

<script setup lang="ts">
import { Ref, nextTick, onMounted, ref, watch, watchEffect } from 'vue'
import UserSetModal from '@/views/affect/AF/AWAF00905D/index.vue'
import LoginUpdModal from '@/views/affect/AF/AWAF00904D/index.vue'
import { SyozokuInfoVM } from '../type'
import { FormInstance } from 'ant-design-vue'
import { ITEM_REQUIRE_ERROR } from '@/constants/msg'
import { KengenStore } from '@/store'
import { replaceText } from '@/utils/util'
import { EnumRegex } from '#/Enums'
import TD from '@/components/Common/TableTD/index.vue'
import { useTableHeight } from '@/utils/hooks'
//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  isNew: boolean
  data: SyozokuInfoVM | null
  sisyolist: CmSisyoVM[]
  headRef: Ref
}>()
//---------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const { editJudge, pnoeditflg } = KengenStore
const updVisible = ref(false)
const userVisible = ref(false)

const formRef = ref<FormInstance>()
const formData = ref<SyozokuInfoVM>({
  stopflg: false,
  syozokunm: '',
  kanrisyaflg: false,
  pnoeditflg: false,
  alertviewflg: false,
  editsisyolist: [],
  userlist2: [],
  userlist1: [],
  upddttm: null
})

const rules = {
  syozokunm: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '所属グループ名') }]
}

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
//表の高さ
const { tableHeight } = useTableHeight(props.headRef, -370)

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  if (props.data) {
    formData.value = props.data
  }
  nextTick(() => editJudge.reset())
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => formData.value.syozokunm,
  (val) => {
    formData.value.userlist1.forEach((user) => (user.syozokunm = val))
  }
)

watch(
  () => {
    //性能改善のため、変えないデータを除く
    const { userlist2, ...data } = formData.value
    return data
  },
  () => {
    editJudge.setEdited()
  }
)

watchEffect(() => {
  if (!formData.value.kanrisyaflg && pnoeditflg) {
    formData.value.pnoeditflg = false
  }
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//登録部署別更新権限
function changeEditsisyo(val, opt) {
  formData.value.editsisyolist = opt
}
//ドロップダウンリスト検索
function filterOption(input: string, option: CmSisyoVM) {
  return (
    option.sisyonm.toLowerCase().includes(input.toLowerCase()) ||
    option.sisyocd.toLowerCase().includes(input.toLowerCase())
  )
}
//入力チェック
async function validateForm() {
  await formRef.value?.validate()
  return Promise.resolve(formData.value)
}

defineExpose({
  validate: validateForm
})
</script>

<style lang="less" scoped>
.self_adaption_table th {
  width: 170px;
}
</style>
