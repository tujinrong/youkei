<template>
  <a-card :bordered="false" class="mb-2 h-full">
    <h1>契約者農場マスタメンテナンス</h1>
    <div class="self_adaption_table form max-w-160">
      <b>第8期</b>
      <a-row>
        <a-col span="24">
          <th>契約者</th>
          <td>
            <ai-select
              v-model:value="formData.keiyakusya"
              :options="selectorlist"
              :disabled="!isNew"
            ></ai-select>
          </td>
        </a-col>
      </a-row>
      <div class="my-2 header_operation flex justify-between w-full">
        <a-space :size="20">
          <a-button class="warning-btn" @click="saveData">登録</a-button>
          <a-button type="primary" danger :disabled="isNew" @click="deleteData"
            >削除</a-button
          >
          <!-- <a-button v-if="!isNew" :icon="h(LeftOutlined)"></a-button
          ><span v-if="!isNew">2/5</span>
          <a-button v-if="!isNew" :icon="h(RightOutlined)"></a-button> -->
        </a-space>
        <a-button type="primary" class="text-end" @click="goList"
          >一覧へ</a-button
        >
      </div>
      <b>契約者農場基本登録項目</b>
      <a-row>
        <a-col span="24">
          <th class="required">契約者農場</th>
          <td>
            <a-input
              v-model:value="formData.noujyobango"
              :maxlength="3"
              type="number"
            ></a-input>
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <th class="required">農場名称</th>
          <td>
            <a-input v-model:value="formData.noujyomei"></a-input>
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <th class="required">都道府県</th>
          <td>
            <ai-select
              v-model:value="formData.KEN_CD"
              :options="KEN_CD_NAME_LIST"
              class="w-full"
            ></ai-select>
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <th class="required">住所</th>
          <td class="flex-col">
            <PostCode v-model:value="formData.ADDR_POST" />
            <a-input v-model:value="formData.ADDR_1" disabled></a-input>
            <a-input v-model:value="formData.ADDR_2"></a-input>
            <a-input v-model:value="formData.ADDR_3"></a-input>
            <a-input v-model:value="formData.ADDR_4"></a-input>
          </td>
        </a-col>
      </a-row>
      <a-row>
        <a-col span="24">
          <th class="required">明細番号</th>
          <td>
            <a-input
              v-model:value="formData.meisaibango"
              :maxlength="3"
              type="number"
            ></a-input>
          </td>
        </a-col>
      </a-row>
    </div>
  </a-card>
</template>

<script setup lang="ts">
import { PageSatatus } from '@/enum'
import { onMounted, reactive, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { showDeleteModal } from '@/utils/modal'
import { DELETE_OK_INFO, SAVE_OK_INFO } from '@/constants/msg'
import { message } from 'ant-design-vue'
import { h } from 'vue'
import TD from '@/components/TableTD/index.vue'
import { showSaveModal } from '@/utils/modal'
import { LeftOutlined, RightOutlined } from '@ant-design/icons-vue'
import PostCode from '@/components/Selector/PostCode/index.vue'
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
const isNew = props.status === PageSatatus.New
const createDefaultParams = () => {
  return {
    keiyakusya: '',
    noujyobango: '',
    noujyomei: '',
    KEN_CD: '',
    ADDR_POST: '',
    ADDR_1: '',
    ADDR_2: '',
    ADDR_3: '',
    ADDR_4: '',
    meisaibango: '',
  }
}
const fakeFormData = {
  keiyakusya: '1',
  noujyobango: '99',
  noujyomei: '東京都千代田区農場',
  KEN_CD: '13',
  ADDR_POST: '100-0001',
  ADDR_1: '東京都',
  ADDR_2: '千代田区',
  ADDR_3: '丸の内',
  ADDR_4: '1丁目1-1',
  meisaibango: '10001',
}
const fakeFormData1 = {
  keiyakusya: '',
  noujyobango: '',
  noujyomei: '',
  KEN_CD: '',
  ADDR_POST: '',
  ADDR_1: '',
  ADDR_2: '',
  ADDR_3: '',
  ADDR_4: '',
  meisaibango: '',
}
const formData = reactive(fakeFormData1)
const selectorlist = ref<DaSelectorModel[]>([
  { value: '1', label: '永玉田中' },
  { value: '2', label: '尾三玉田' },
  { value: '3', label: '史玉浅海' },
])
const KEN_CD_NAME_LIST = [
  { value: '1', label: '北海道' },
  { value: '2', label: '青森県' },
  { value: '3', label: '岩手県' },
  { value: '4', label: '宮城県' },
  { value: '5', label: '秋田県' },
  { value: '6', label: '山形県' },
  { value: '7', label: '福島県' },
  { value: '8', label: '茨城県' },
  { value: '9', label: '栃木県' },
  { value: '10', label: '群馬県' },
  { value: '11', label: '埼玉県' },
  { value: '12', label: '千葉県' },
  { value: '13', label: '東京都' },
  { value: '14', label: '神奈川県' },
  { value: '15', label: '新潟県' },
  { value: '16', label: '富山県' },
  { value: '17', label: '石川県' },
  { value: '18', label: '福井県' },
  { value: '19', label: '山梨県' },
  { value: '20', label: '長野県' },
  { value: '21', label: '岐阜県' },
  { value: '22', label: '静岡県' },
  { value: '23', label: '愛知県' },
  { value: '24', label: '三重県' },
  { value: '25', label: '滋賀県' },
  { value: '26', label: '京都府' },
  { value: '27', label: '大阪府' },
  { value: '28', label: '兵庫県' },
  { value: '29', label: '奈良県' },
  { value: '30', label: '和歌山県' },
  { value: '31', label: '鳥取県' },
  { value: '32', label: '島根県' },
  { value: '33', label: '岡山県' },
  { value: '34', label: '広島県' },
  { value: '35', label: '山口県' },
  { value: '36', label: '徳島県' },
  { value: '37', label: '香川県' },
  { value: '38', label: '愛媛県' },
  { value: '39', label: '高知県' },
  { value: '40', label: '福岡県' },
  { value: '41', label: '佐賀県' },
  { value: '42', label: '長崎県' },
  { value: '43', label: '熊本県' },
  { value: '44', label: '大分県' },
  { value: '45', label: '宮崎県' },
  { value: '46', label: '鹿児島県' },
  { value: '47', label: '沖縄県' },
]

//---------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(async () => {
  if (props.status === PageSatatus.Edit) {
    Object.assign(formData, fakeFormData)
  }
})
//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------

watch(
  () => props.status,
  () => Object.assign(formData, fakeFormData),
  { deep: true }
)

//都道府県を選択した場合、住所（住所１）の値をセットする
watch(
  () => formData.KEN_CD,
  (newVal, oldVal) => {
    if (newVal === undefined) {
      formData.ADDR_1 = ''
    } else if (newVal !== undefined) {
      let newAddr1 = newVal.split(' : ')[1]
      if (newAddr1 !== '' && newAddr1 !== undefined) {
        formData.ADDR_1 = newAddr1
      }
    }
  }
)
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------

//画面遷移
const goList = () => {
  router.push({ name: route.name as string })
}
const saveData = () => {
  showSaveModal({
    onOk: () => {
      router.push({ name: route.name as string })
      message.success(SAVE_OK_INFO.Msg)
    },
  })
}

//
const deleteData = () => {
  showDeleteModal({
    handleDB: true,
    onOk() {
      router.push({ name: route.name as string })
      message.success(DELETE_OK_INFO.Msg)
    },
  })
}
</script>

<style scoped lang="scss">
th {
  width: 130px;
}
h1 {
  font-size: 24px;
}
</style>
