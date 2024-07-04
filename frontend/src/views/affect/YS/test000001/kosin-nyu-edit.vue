<template>
  <div style="position: relative">
    <a-card>
      <a-row :gutter="0">
        <a-col :md="24" :lg="24">
          <div class="self_adaption_table">
            <a-row :gutter="[0, 10]">
              <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                <th style="width: 80px">宛名番号</th>
                <td style="">
                  <span>{{ queryParams.num }}</span>
                </td>
              </a-col>
              <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                <th style="width: 80px">氏名</th>
                <td style="">
                  <span>{{ queryParams.name }}</span>
                </td>
              </a-col>
              <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                <th style="width: 80px">カナ氏名</th>
                <td style="">
                  <span>{{ queryParams.KanaName }}</span>
                </td>
              </a-col>

              <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                <th style="width: 80px">生年月日</th>
                <td>
                  <span>{{ queryParams.birthDate }}</span>
                </td>
              </a-col>
            </a-row>
          </div>
        </a-col>
      </a-row>
      <div class="m-t-1 header_operation">
        <a-space>
          <a-button type="primary" @click="handleCancel">一覧へ</a-button>
          <a-button class="warning-btn" @click="saveData">登録</a-button>
        </a-space>
        <close-page></close-page>
      </div>
      <div class="m-t-1">
        <a-tabs
          v-model:activeKey="collapseModel.activeKey"
          @change="
            (key) => {
              collapseModelChange(collapseModel, key)
            }
          "
        >
          <a-tab-pane key="1" tab="接種情報">
            <div :style="{ height: mainHeight, overflowY: 'auto' }">
              <div class="tool-row">
                <div class="tool-row-left">
                  <a-space>
                    <ai-select
                      v-model:value="queryParams.type"
                      :disabled="isDisabled"
                      :options="typeOption"
                      style="width: 220px"
                      @change="bidChanged"
                    ></ai-select>
                    <ai-select
                      v-model:value="queryParams.status"
                      :disabled="isDisabled"
                      :options="statusOption"
                      style="width: 220px; margin-left: 10px"
                      @change="bidChanged"
                    ></ai-select>
                    <a-button type="primary" :disabled="isDisabled" class="btn-round"
                      >キャンセル</a-button
                    >
                  </a-space>
                </div>
                <div class="tool-row-right">
                  <a-space>
                    <a-button type="primary" :disabled="isDisabled" class="btn-round"
                      >エラーチェック(必須項目)</a-button
                    >
                    <a-button type="primary" :disabled="isDisabled" class="btn-round"
                      >初期値</a-button
                    >
                  </a-space>
                </div>
              </div>
              <div :style="{ height: mainTableHeight, overflowY: 'auto' }">
                <a-table
                  class="m-t-1 ant-table-striped info-table"
                  :data-source="infoData"
                  :columns="columns"
                  :pagination="false"
                  bordered
                  :row-class-name="(_record, index) => (index % 2 === 1 ? 'table-striped' : null)"
                  :scroll="{ y: subTableHeight }"
                  :locale="locale"
                  :show-sorter-tooltip="false"
                  @resizeColumn="handleResizeColumn"
                >
                  <template #bodyCell="{ column, record }">
                    <template v-if="column.dataIndex === 'name'">
                      <a @click="editRowEvent(record)">{{ record[column.dataIndex] }}</a>
                    </template>
                  </template>
                </a-table>
              </div>

              <div :style="{ height: antTableHeight, marginTop: '61px' }">
                <vxe-table
                  :data="infoData"
                  border
                  max-height="100%"
                  class="mytable-scrollbar m-t-1"
                  :edit-config="{
                    trigger: 'click',
                    mode: 'cell',
                    showStatus: false
                  }"
                  :column-config="{ resizable: true }"
                  :row-config="{ isCurrent: true }"
                  :mouse-config="{ selected: true }"
                  :keyboard-config="{
                    isArrow: true,
                    isDel: true,
                    isEnter: true,
                    isTab: true,
                    isEdit: true,
                    isChecked: true,
                    isEsc: true,
                    enterToTab: true
                  }"
                  style="margin-top: 10px"
                >
                  <vxe-column
                    class-name="disable_cell"
                    header-class-name="table-name"
                    field="id"
                    title="ID"
                    width="80"
                    fixed="left"
                  >
                  </vxe-column>
                  <vxe-column
                    field="name"
                    title="予防接種名"
                    width="200"
                    fixed="left"
                    header-class-name="bg-editable"
                  >
                    <template #edit="{ row }">
                      <vxe-input v-model="row.name" type="text" placeholder=""></vxe-input>
                    </template>
                  </vxe-column>
                  <vxe-column
                    field="inoculationDate"
                    title="接種日"
                    width="150"
                    fixed="left"
                    header-class-name="bg-editable"
                    :edit-render="{
                      name: 'DateJp'
                    }"
                  >
                  </vxe-column>
                  <vxe-column
                    field="acceptanceDate"
                    title="受理日"
                    width="150"
                    header-class-name="bg-editable"
                    :edit-render="{
                      name: 'DateJp'
                    }"
                  >
                  </vxe-column>
                  <vxe-column
                    field="lotNo"
                    title="LotNo."
                    header-class-name="bg-editable"
                    width="100"
                    :edit-render="{
                      name: 'AiSelect',
                      options: inoculationMorphologyOptions
                    }"
                  >
                  </vxe-column>
                  <vxe-column
                    field="manufacturer"
                    title="製造者"
                    width="150"
                    header-class-name="bg-editable"
                    :edit-render="{
                      name: 'AiSelect',
                      options: inoculationMorphologyOptions
                    }"
                  >
                  </vxe-column>
                  <vxe-column
                    field="inoculationMorphology"
                    title="接種形態"
                    width="120"
                    header-class-name="bg-editable"
                    :edit-render="{
                      name: 'AiSelect',
                      options: inoculationMorphologyOptions
                    }"
                  >
                  </vxe-column>
                  <vxe-column
                    field="institutionMedical "
                    title="医療機関"
                    width="150"
                    header-class-name="bg-editable"
                    :edit-render="{
                      name: 'AiSelect',
                      options: institutionMedicalOptions
                    }"
                  >
                  </vxe-column>
                  <vxe-column
                    field="inoculationLocation"
                    title="接種場所"
                    width="150"
                    header-class-name="bg-editable"
                    :edit-render="{
                      name: 'AiSelect',
                      options: inoculationLocationOptions
                    }"
                  >
                  </vxe-column>
                  <vxe-column
                    field="inoculationDoctor"
                    title="接種医師"
                    width="150"
                    header-class-name="bg-editable"
                    :edit-render="{
                      name: 'AiSelect',
                      options: inoculationMorphologyOptions
                    }"
                  >
                  </vxe-column>
                  <vxe-column
                    field="preVisitDoctor"
                    title="予診医師"
                    width="150"
                    header-class-name="bg-editable"
                    :edit-render="{
                      name: 'AiSelect',
                      options: inoculationMorphologyOptions
                    }"
                  >
                  </vxe-column>
                  <vxe-column
                    field="inoculationAmount"
                    title="接種量(ml)"
                    width="150"
                    header-class-name="bg-editable"
                    :edit-render="{ autofocus: '.vxe-input--inner', autoselect: true }"
                  >
                    <template #edit="{ row }">
                      <vxe-input
                        v-model="row.inoculationAmount"
                        type="float"
                        suffix-icon="none"
                        placeholder=""
                      ></vxe-input>
                    </template>
                  </vxe-column>
                  <vxe-column
                    field="issuance"
                    title="その他"
                    width="210"
                    header-class-name="bg-editable"
                    :edit-render="{ autofocus: '.vxe-input--inner', autoselect: true }"
                  >
                    <template #default="{ row }">
                      <a-select
                        v-model:value="row.other"
                        mode="multiple"
                        style="width: 100%"
                        :options="otherOptions"
                      ></a-select>
                    </template>
                    <template #edit="{ row }">
                      <a-select
                        v-model:value="row.other"
                        mode="multiple"
                        style="width: 100%"
                        :options="otherOptions"
                      ></a-select>
                    </template>
                  </vxe-column>
                </vxe-table>
              </div>
              <div style="float: right" class="m-t-1">
                <a-button type="primary" class="btn-round" @click="hibShow"
                  >Hib·小児用肺炎球菌について</a-button
                >
              </div>
            </div>
          </a-tab-pane>
          <a-tab-pane key="2" tab="その他情報">
            <div :style="{ height: mainHeight }">
              <div class="tool-row">
                <div class="tool-row-left">
                  <a-space>
                    <ai-select
                      v-model:value="queryParams.state"
                      :disabled="disBigselect"
                      :options="stateOption"
                      style="width: 220px"
                      @change="bidChanged"
                    ></ai-select>
                    <ai-select
                      v-model:value="queryParams.state2"
                      :disabled="disBigselect"
                      :options="state2Option"
                      style="width: 220px; margin-left: 10px"
                      @change="bidChanged"
                    ></ai-select>
                  </a-space>
                </div>
                <div class="tool-row-right">
                  <a-space>
                    <a-button type="primary" class="btn-round">エラーチェック(必須項目)</a-button>
                    <a-button type="primary" class="btn-round">初期値</a-button>
                  </a-space>
                </div>
              </div>

              <div :style="{ height: subTableHeight }" class="cell-height-65">
                <vxe-table
                  border
                  :data="otherInfoData"
                  height="100%"
                  class="m-t-1"
                  :column-config="{ resizable: true }"
                  :edit-config="{ trigger: 'click', mode: 'cell' }"
                  :cell-style="vxecellStyle"
                  :header-cell-class-name="headerCellClassName"
                >
                  <vxe-column field="code" title="" width="40" align="center"></vxe-column>
                  <vxe-column field="name" title="項　目" width="400"></vxe-column>
                  <vxe-column field="input" title="入　力" :edit-render="{ autofocus: 'input' }">
                    <template #default="{ row }">
                      <span>{{ row.inputName }}</span>
                    </template>
                    <template #edit="{ row }">
                      <div v-if="row.type === '01'">
                        <ai-select
                          v-model:value="row.input"
                          :disabled="disBigselect"
                          :options="inputOption"
                          style="width: 100%"
                          @change="inputChange"
                        ></ai-select>
                      </div>
                      <div v-else>
                        <vxe-input v-model="row.inputName" type="text"></vxe-input>
                      </div>
                    </template>
                  </vxe-column>
                </vxe-table>
              </div>

              <div class="m-t-1">
                <a-descriptions bordered title="" size="small">
                  <a-descriptions-item
                    label="注　釈"
                    :label-style="{
                      width: '5% !important',
                      padding: '5px',
                      'background-color': '#ffffe1',
                      'vertical-align': 'baseline'
                    }"
                    :content-style="{
                      width: '100% !important',
                      height: '80px !important',
                      'vertical-align': 'baseline'
                    }"
                  ></a-descriptions-item>
                </a-descriptions>
              </div>
            </div>
          </a-tab-pane>
          <a-tab-pane key="3" tab="罹患情報等・個人照会">
            <div :style="{ height: mainHeight }">
              <a-row :gutter="10">
                <a-col :lg="7">
                  <a-collapse active-key="1" accordion class="m-t-1">
                    <a-collapse-panel key="1" header="住民記録情報">
                      <div :style="{ height: subHeight, overflowY: 'auto' }">
                        <div class="description-table m-t-1 readonly resident-table">
                          <table>
                            <tbody>
                              <tr>
                                <th style="width: 80px">氏名</th>
                                <td colspan="3">金井　愛乃<span style="float: right">女</span></td>
                              </tr>
                              <tr>
                                <th>年齢</th>
                                <td colspan="3">20歳 5か月 13日(令和04年12月13日現在)</td>
                              </tr>
                              <tr>
                                <th style="width: 80px">住民区分</th>
                                <td>住民</td>
                                <th style="width: 80px">異動事由</th>
                                <td></td>
                              </tr>
                              <tr>
                                <th>転入日</th>
                                <td colspan="3"></td>
                              </tr>
                              <tr>
                                <th>行政区</th>
                                <td colspan="3">0040 △△◇△</td>
                              </tr>
                              <tr>
                                <th>住所</th>
                                <td colspan="3">○○区△△△１丁目２番３号</td>
                              </tr>
                              <tr>
                                <th>電話番号</th>
                                <td colspan="3">111-1111</td>
                              </tr>
                            </tbody>
                          </table>
                        </div>
                        <h4 class="m-t-1">世代構成</h4>
                        <div class="font-mini-table">
                          <a-table
                            bordered
                            class="ant-table-striped no-border resident-table"
                            :data-source="operationList1"
                            :columns="columns2"
                            :pagination="false"
                            :scroll="{ y: tableHeight }"
                            :row-class-name="
                              (_record, index) => (index % 2 === 1 ? 'table-striped' : null)
                            "
                            :locale="locale"
                            :show-sorter-tooltip="false"
                            @resizeColumn="handleResizeColumn"
                          >
                          </a-table>
                        </div>
                      </div>
                    </a-collapse-panel>
                  </a-collapse>
                </a-col>
                <a-col :lg="17">
                  <div class="m-t-1" style="display: flex">
                    <div>
                      <a-checkbox v-model:checked="checked">接種拒否</a-checkbox>
                    </div>
                    <div style="margin-left: 10px">
                      <div class="description-table">
                        <table>
                          <tbody>
                            <tr>
                              <th style="width: 80px">罹患情報</th>
                              <td style="width: 360px">
                                <a-checkbox-group v-model:value="formState.others">
                                  <a-checkbox value="1">麻しん</a-checkbox>
                                  <a-checkbox value="2">風しん</a-checkbox>
                                  <a-checkbox value="3">百日咳</a-checkbox>
                                  <a-checkbox value="4">水痘</a-checkbox>
                                </a-checkbox-group>
                              </td>
                            </tr>
                          </tbody>
                        </table>
                      </div>
                      <div class="description-table readonly" style="margin-top: -1px">
                        <table>
                          <tbody>
                            <tr>
                              <th style="width: 180px" class="display-cell">新型コロナ発券No.</th>
                              <td>2</td>
                            </tr>
                          </tbody>
                        </table>
                      </div>
                    </div>
                    <div style="margin-left: 10px">
                      <a-checkbox v-model:checked="checked">母子感染対象</a-checkbox>
                    </div>
                  </div>

                  <!--table-->
                  <h4 class="m-t-1">乳幼児健診情報</h4>
                  <div
                    class="out-border-table-box font-mini-table"
                    :style="{ height: tabHeight, overflow: 'auto' }"
                  >
                    <a-table
                      bordered
                      class="ant-table-striped"
                      :data-source="operationList2"
                      :columns="columns3"
                      :pagination="false"
                      :scroll="{ y: tableHeight }"
                      :row-class-name="
                        (_record, index) => (index % 2 === 1 ? 'table-striped' : null)
                      "
                      :locale="locale"
                      :show-sorter-tooltip="false"
                      @resizeColumn="handleResizeColumn"
                    >
                    </a-table>
                  </div>
                </a-col>
              </a-row>
            </div>
          </a-tab-pane>
        </a-tabs>
      </div>
    </a-card>
    <div>
      <div style="padding: 10px; background-color: #ffffff">
        <a-button type="primary" class="btn-round m-r-1 m-b-1" @click="memoShow">メモ</a-button>
        <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">備考</a-button>
        <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">連絡先</a-button>
        <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true"
          >ドキュメント管理</a-button
        >
        <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">訪問指導</a-button>
        <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">健康相談</a-button>
        <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true"
          >世帯状況一覧</a-button
        >
        <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true"
          >接種スケジュール</a-button
        >
        <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">接種台帳</a-button>
        <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">免除申請</a-button>
      </div>
    </div>
  </div>
  <a-modal v-model:visible="editVisible" title="接種情報入力">
    <a-form :model="formState" :label-col="{ span: 4 }" :wrapper-col="{ span: 18 }">
      <div class="description-table">
        <table>
          <tbody>
            <tr>
              <th style="width: 80px">ID</th>
              <td></td>
            </tr>
            <tr>
              <th style="width: 80px">接種日</th>
              <td>
                <date-jp
                  v-model:value="formState.inoculationDate"
                  :disabled="isDisabled"
                  style="width: 100%"
                ></date-jp>
              </td>
            </tr>
            <tr>
              <th style="width: 80px">受理日</th>
              <td>
                <date-jp
                  v-model:value="formState.acceptanceDate"
                  :disabled="isDisabled"
                  style="width: 100%"
                ></date-jp>
              </td>
            </tr>
            <tr>
              <th style="width: 80px">LotNo.</th>
              <td>
                <ai-select
                  v-model:value="formState.lotNo"
                  :options="lotNoOptions"
                  style="width: 100%"
                ></ai-select>
              </td>
            </tr>
            <tr>
              <th style="width: 80px">製造者</th>
              <td>
                <ai-select
                  v-model:value="formState.manufacturer"
                  :options="manufacturerOptions"
                  style="width: 100%"
                ></ai-select>
              </td>
            </tr>
            <tr>
              <th style="width: 80px">接種量</th>
              <td>
                <a-input
                  v-model:value="formState.inoculationAmount"
                  :disabled="isDisabled"
                  style="width: 85%; margin-right: 10px"
                />ml
              </td>
            </tr>
            <tr>
              <th style="width: 80px">接種形態</th>
              <td>
                <ai-select
                  v-model:value="formState.inoculationMorphology"
                  :options="morphologyOptions"
                  style="width: 100%"
                ></ai-select>
              </td>
            </tr>
            <tr>
              <th style="width: 80px">医療機関</th>
              <td>
                <ai-select
                  v-model:value="formState.institutionMedical"
                  :options="medicalOptions"
                  style="width: 80%"
                ></ai-select>
                <a-button type="primary" class="m-l-1" :disabled="isDisabled">検索</a-button>
              </td>
            </tr>
            <tr>
              <th style="width: 80px">接種場所</th>
              <td>
                <ai-select
                  v-model:value="formState.inoculationLocation"
                  :options="locationOptions"
                  style="width: 100%"
                ></ai-select>
              </td>
            </tr>
            <tr>
              <th style="width: 80px">接種医師</th>
              <td>
                <ai-select
                  v-model:value="formState.inoculationDoctor"
                  :options="doctorOptions"
                  style="width: 100%"
                ></ai-select>
              </td>
            </tr>
            <tr>
              <th style="width: 80px">予診医師</th>
              <td>
                <ai-select
                  v-model:value="formState.preVisitDoctor"
                  :options="doctorOptions"
                  style="width: 100%"
                ></ai-select>
              </td>
            </tr>
            <tr>
              <th style="width: 80px">その他</th>
              <td>
                <a-checkbox-group v-model:value="formState.others">
                  <a-checkbox value="A">料金徽収</a-checkbox>
                  <a-checkbox value="B">済証交付</a-checkbox>
                </a-checkbox-group>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </a-form>
    <template #footer>
      <a-button type="primary" @click="editVisible = false">キャンセル</a-button>
      <a-button type="primary" :loading="loading">確定</a-button>
    </template>
  </a-modal>
  <hib ref="hibRef"></hib>
  <memo ref="memoRef"></memo>
</template>

<script lang="ts" setup>
//---------------------------------------------------------------------------
//乳幼児予防接種編集
//---------------------------------------------------------------------------
import { ref, reactive, onMounted, computed } from 'vue'
import { layoutMode, multiTab } from '@/store/use-site-settings'
import { collapseModelChange } from '@/utils/util'
import config from '@/config/default-settings'
import { useRouter } from 'vue-router'
import hib from './hib.vue'
import { VxeTablePropTypes } from 'vxe-table'
import { Modal } from 'ant-design-vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { MenuType } from '#/Enums'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const router = useRouter()
const tableHeight = document.documentElement.clientHeight - 260 + 'px'
const loading = ref<boolean>(false)
const disBigselect = ref<boolean>(false)
const disMidselect = ref<boolean>(false)
const disabled = ref<boolean>(false)
const visible = ref<boolean>(false)
//Hib·小児用肺炎球菌について
const hibRef = ref()
const columns = ref([
  {
    title: 'ID',
    dataIndex: 'id',
    key: 'id',
    width: 80,
    fixed: 'left',
    resizable: true,
    sorter: true
  },
  {
    title: '予防接種名',
    dataIndex: 'name',
    key: 'name',
    width: 200,
    fixed: 'left',
    resizable: true,
    sorter: true
  },
  {
    title: '接種日',
    dataIndex: 'inoculationDate',
    key: 'inoculationDate',
    width: 150,
    fixed: 'left',
    resizable: true,
    sorter: true
  },
  {
    title: '受理日',
    dataIndex: 'acceptanceDate',
    key: 'acceptanceDate',
    width: 150,
    resizable: true,
    sorter: true
  },
  {
    title: 'LotNo.',
    dataIndex: 'lotNo',
    key: 'lotNo',
    width: 100,
    resizable: true,
    sorter: true
  },
  {
    title: '製造者',
    dataIndex: 'manufacturer',
    key: 'manufacturer',
    width: 150,
    resizable: true,
    sorter: true
  },
  {
    title: '接種形態',
    dataIndex: 'inoculationMorphology',
    key: 'inoculationMorphology',
    width: 120,
    resizable: true,
    sorter: true
  },
  {
    title: '医療機関',
    dataIndex: 'institutionMedical',
    key: 'institutionMedical',
    width: 150,
    resizable: true,
    sorter: true
  },
  {
    title: '接種場所',
    dataIndex: 'inoculationLocation',
    key: 'inoculationLocation',
    width: 150,
    resizable: true,
    sorter: true
  },
  {
    title: '接種医師',
    dataIndex: 'inoculationDoctor',
    key: 'inoculationDoctor',
    width: 150,
    resizable: true,
    sorter: true
  },
  {
    title: '予診医師',
    dataIndex: 'preVisitDoctor',
    key: 'preVisitDoctor',
    width: 150,
    resizable: true,
    sorter: true
  },
  {
    title: '接種量(ml)',
    dataIndex: 'inoculationAmount',
    key: 'inoculationAmount',
    width: 150,
    resizable: true,
    sorter: true
  },
  {
    title: '済証交付',
    dataIndex: 'issuance',
    key: 'issuance',
    width: 150,
    resizable: true,
    sorter: true
  },
  {
    title: '料金徽収',
    dataIndex: 'charge',
    key: 'charge',
    width: 150,
    resizable: true,
    sorter: true
  }
])
const getInitData: (param: boolean) => void = async (needAllAlbel) => {
  loading.value = false
}
const queryParams = reactive<FormState>({
  bigCode: '',
  midCode: '',
  num: '00000087208',
  KanaName: 'カナｲ　アイノ',
  name: '金井　愛乃',
  birthDate: '平成14年16月30日',
  type: '01',
  status: '01',
  state: '01',
  state2: '01'
})
const formState = reactive<FormState>({
  id: '',
  inoculationDate: '',
  acceptanceDate: '',
  lotNo: '',
  manufacturer: '',
  inoculationAmount: '',
  inoculationMorphology: '',
  institutionMedical: '',
  inoculationLocation: '',
  inoculationDoctor: '',
  preVisitDoctor: '',
  others: ''
})
const editVisible = ref(false)
const operationList1 = ref([
  {
    num: '00000086986',
    name: '金井　直太郎',
    relation: '世帯主',
    residence: '住民'
  },
  {
    num: '00000086987',
    name: '金井　愛矢',
    relation: '妻',
    residence: '住民'
  },
  {
    num: '00000087208',
    name: '金井　愛乃',
    relation: '子',
    residence: '住民'
  },
  {
    num: '00000093958',
    name: '金井　愛乃',
    relation: '子',
    residence: '住民'
  },
  {
    num: '00000095138',
    name: '金井　大地',
    relation: '父',
    residence: '除票'
  }
])
const operationList2 = ref([
  {
    time: '',
    content: '',
    type: '１か月(体)'
  },
  {
    time: '',
    content: '',
    type: '２か月(体)'
  },
  {
    time: '',
    content: '',
    type: '４か月(体)'
  },
  {
    time: '',
    content: '',
    type: '７か月(体)'
  },
  {
    time: '',
    content: '',
    type: '１２か月(体)'
  },
  {
    time: '',
    content: '',
    type: '１歳(歯)(歯)'
  },
  {
    time: '',
    content: '',
    type: '１歳６月(体)'
  },
  {
    time: '',
    content: '',
    type: '１歳６月(歯)'
  },
  {
    time: '',
    content: '',
    type: '２歳(歯)(歯)'
  },
  {
    time: '',
    content: '',
    type: '２歳６月(体)'
  },
  {
    time: '',
    content: '',
    type: '２歳６月(歯)'
  },
  {
    time: '平成18年07月24日',
    content: '',
    type: '３歳(体)'
  },
  {
    time: '平成20年07月24日',
    content: '',
    type: '３歳(歯)'
  },
  {
    time: '',
    content: '',
    type: '５歳(体)'
  },
  {
    time: '',
    content: '',
    type: '５歳(歯)'
  }
])
const locale = ref({
  cancelSort: '降順にソート',
  triggerAsc: 'ソートをキャンセル',
  triggerDesc: '昇順にソート'
})
const columns2 = ref([
  {
    title: '宛名番号',
    dataIndex: 'num',
    key: 'num',
    width: 120,
    resizable: true,
    sorter: true
  },
  {
    title: '氏名',
    dataIndex: 'name',
    key: 'name',
    resizable: true,
    sorter: true
  },
  {
    title: '続柄',
    dataIndex: 'relation',
    key: 'relation',
    width: 80,
    resizable: true,
    sorter: true
  },
  {
    title: '住民区分',
    dataIndex: 'residence',
    key: 'residence',
    width: 80,
    resizable: true,
    sorter: true
  }
])
const columns3 = ref([
  {
    title: '健診種別',
    dataIndex: 'type',
    key: 'type',
    width: 130,
    resizable: true,
    sorter: true
  },
  {
    title: '健診日',
    dataIndex: 'time',
    key: 'time',
    width: 130,
    resizable: true,
    sorter: true
  },
  {
    title: '',
    dataIndex: 'content',
    key: 'content',
    resizable: true,
    sorter: true
  }
])
const memoRef = ref()
const mode = ref('default') // default list edit
const typeOption = ref([
  { label: 'すべて', value: '01' },
  { label: '乳幼児', value: '02' },
  { label: '成人', value: '03' },
  { label: '新型コロナ', value: '04' },
  { label: '新型インフルエンザ', value: '05' }
])
const statusOption = ref([
  { label: 'すべて', value: '01' },
  { label: '定期接種', value: '02' },
  { label: '廃止', value: '03' },
  { label: '独自事業', value: '04' }
])
const stateOption = ref([
  { label: 'すべて', value: '01' },
  { label: '風しん抗体検査', value: '02' },
  { label: '新型コロナ', value: '03' },
  { label: 'その他', value: '04' }
])
const state2Option = ref([
  { label: 'すべて', value: '01' },
  { label: 'VRS連携', value: '02' }
])
const infoData = ref([
  {
    id: '001',
    name: '四種混合(1期初回1回目)',
    inoculationDate: '',
    acceptanceDate: '',
    lotNo: '',
    manufacturer: '',
    inoculationMorphology: '',
    institutionMedical: '',
    inoculationLocation: '',
    inoculationDoctor: '',
    preVisitDoctor: '',
    inoculationAmount: '',
    issuance: '',
    charge: ''
  },
  {
    id: '002',
    name: '四種混合(1期初回2回目)',
    inoculationDate: '',
    acceptanceDate: '',
    lotNo: '',
    manufacturer: '',
    inoculationMorphology: '',
    institutionMedical: '',
    inoculationLocation: '',
    inoculationDoctor: '',
    preVisitDoctor: '',
    inoculationAmount: '',
    issuance: '',
    charge: ''
  },
  {
    id: '003',
    name: '四種混合(1期初回3回目)',
    inoculationDate: '',
    acceptanceDate: '',
    lotNo: '',
    manufacturer: '',
    inoculationMorphology: '',
    institutionMedical: '',
    inoculationLocation: '',
    inoculationDoctor: '',
    preVisitDoctor: '',
    inoculationAmount: '',
    issuance: '',
    charge: ''
  },
  {
    id: '004',
    name: '四種混合(1期追加)',
    inoculationDate: '',
    acceptanceDate: '',
    lotNo: '',
    manufacturer: '',
    inoculationMorphology: '',
    institutionMedical: '',
    inoculationLocation: '',
    inoculationDoctor: '',
    preVisitDoctor: '',
    inoculationAmount: '',
    issuance: '',
    charge: ''
  },
  {
    id: '005',
    name: '二種混合(2期)',
    inoculationDate: '',
    acceptanceDate: '',
    lotNo: '',
    manufacturer: '',
    inoculationMorphology: '',
    institutionMedical: '',
    inoculationLocation: '',
    inoculationDoctor: '',
    preVisitDoctor: '',
    inoculationAmount: '',
    issuance: '',
    charge: ''
  },
  {
    id: '006',
    name: '三種混合(1期初回1回目)',
    inoculationDate: '',
    acceptanceDate: '',
    lotNo: '',
    manufacturer: '',
    inoculationMorphology: '',
    institutionMedical: '',
    inoculationLocation: '',
    inoculationDoctor: '',
    preVisitDoctor: '',
    inoculationAmount: '',
    issuance: '',
    charge: ''
  },
  {
    id: '007',
    name: '三種混合(1期初回2回目)',
    inoculationDate: '',
    acceptanceDate: '',
    lotNo: '',
    manufacturer: '',
    inoculationMorphology: '',
    institutionMedical: '',
    inoculationLocation: '',
    inoculationDoctor: '',
    preVisitDoctor: '',
    inoculationAmount: '',
    issuance: '',
    charge: ''
  },
  {
    id: '008',
    name: '三種混合(1期初回3回目)',
    inoculationDate: '',
    acceptanceDate: '',
    lotNo: 'HJ096B',
    manufacturer: '',
    inoculationMorphology: '集団接種',
    institutionMedical: '',
    inoculationLocation: '',
    inoculationDoctor: 'スタッフ００１０２０',
    preVisitDoctor: 'スタッフ００１０１９',
    inoculationAmount: '0.5',
    issuance: '',
    charge: ''
  },
  {
    id: '009',
    name: '三種混合(1期追加)',
    inoculationDate: '',
    acceptanceDate: '',
    lotNo: 'V011B',
    manufacturer: '',
    inoculationMorphology: '個別接種',
    institutionMedical: '医療機関0101',
    inoculationLocation: '',
    inoculationDoctor: 'スタッフ００１０１９',
    preVisitDoctor: 'スタッフ００１０１９',
    inoculationAmount: '0.5',
    issuance: '',
    charge: ''
  },
  {
    id: '010',
    name: '不活化ポリオ(初回1回目)',
    inoculationDate: '',
    acceptanceDate: '',
    lotNo: '',
    manufacturer: '',
    inoculationMorphology: '',
    institutionMedical: '',
    inoculationLocation: '',
    inoculationDoctor: '',
    preVisitDoctor: '',
    inoculationAmount: '',
    issuance: '',
    charge: ''
  }
])
const otherInfoData = ref([
  {
    id: 10001,
    code: '風',
    name: '風しん抗体検査:実施方法',
    input: '',
    inputName: '',
    contents: '',
    type: '01'
  },
  {
    id: 10002,
    code: '風',
    name: '風しん抗体検査:検査法',
    input: '',
    inputName: '',
    contents: '',
    type: '01'
  },
  {
    id: 10003,
    code: '風',
    name: '風しん抗体検査:抗体価数値',
    input: '',
    inputName:
      'あいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえおあいうえお',
    contents: '',
    type: '02'
  },
  {
    id: 10004,
    code: '風',
    name: '風しん抗体検査:抗体価(ICA法)',
    input: '',
    inputName: '',
    contents: '',
    type: '02'
  },
  {
    id: 10005,
    code: '風',
    name: '風しん抗体検査:判定結果',
    input: '',
    inputName: '',
    contents: '',
    type: '01'
  },
  {
    id: 10006,
    code: '風',
    name: '風しん抗体検査:梗査実施日',
    input: '',
    inputName: '',
    contents: '',
    type: '01'
  },
  {
    id: 10007,
    code: '風',
    name: '風しん抗体検査:検査結果判定日',
    input: '',
    inputName: '',
    contents: '',
    type: '01'
  },
  {
    id: 10008,
    code: '風',
    name: '風しん抗体検査:実施機関',
    input: '',
    inputName: '',
    contents: '',
    type: '01'
  },
  {
    id: 10009,
    code: '風',
    name: '風しん抗体快査:実施機関所在地',
    input: '',
    inputName: '',
    contents: '',
    type: '01'
  },
  {
    id: 10010,
    code: '風',
    name: '風しん抗体検査:担当医師(検査実施者)',
    input: '',
    inputName: '',
    contents: '',
    type: '01'
  },
  {
    id: 10011,
    code: '風',
    name: '風しん抗体検査:担当医師(検査結果判定者)',
    input: '',
    inputName: '',
    contents: '',
    type: '01'
  },
  {
    id: 10012,
    code: '風',
    name: '風しん抗体検査:検査番号',
    input: '',
    inputName: '',
    contents: ''
  },
  {
    id: 10013,
    code: '風',
    name: '風しん抗体検査:備考',
    input: '',
    inputName: '',
    contents: '',
    type: '01'
  }
])
const inputOption = ref([
  { label: '赤血球凝集抑制法(HI法)', value: '01' },
  { label: '酵素免疫法(EIA法)', value: '02' },
  { label: 'ラテックス免役比濁法(LTI法)', value: '03' },
  { label: '堂光酵索免疫法(ELFA法)', value: '04' },
  { label: '化学発光酵素免疫法(CLEIA法)', value: '05' }
])

const inoculationMorphologyOptions = [{ value: '', label: '' }]

const institutionMedicalOptions = [{ value: '', label: '' }]

const inoculationLocationOptions = [{ value: '', label: '' }]

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const mainHeight = computed(() => {
  let h = 266
  if (multiTab.value && layoutMode.value == MenuType.Top) {
    h += config.headerTabHeight
  }
  return 'calc(100vh - ' + h + 'px)'
})

const subHeight = computed(() => {
  let h = 321
  if (multiTab.value && layoutMode.value == MenuType.Top) {
    h += config.headerTabHeight
  }
  return 'calc(100vh - ' + h + 'px)'
})
const tabHeight = computed(() => {
  let h = 463
  if (multiTab.value && layoutMode.value == MenuType.Top) {
    h += config.headerTabHeight
  }
  return 'calc(100vh - ' + h + 'px)'
})

const mainTableHeight = computed(() => {
  let h = 390
  if (multiTab.value && layoutMode.value == MenuType.Top) {
    h += config.headerTabHeight
  }
  return 'calc(100vh - ' + h + 'px)'
})

const subTableHeight = computed(() => {
  let h = 478
  if (multiTab.value && layoutMode.value == MenuType.Top) {
    h += config.headerTabHeight
  }
  return 'calc(100vh - ' + h + 'px)'
})

const antTableHeight = computed(() => {
  let h = 360
  if (multiTab.value && layoutMode.value == MenuType.Top) {
    h += config.headerTabHeight
  }
  return 'calc(100vh - ' + h + 'px)'
})

const isDisabled = computed(() => {
  return mode.value != 'edit'
})

const otherOptions = [
  { label: '料金徽収', value: '1' },
  { label: '済証交付', value: '2' }
]

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getInitData(true)
  disabled.value = true
  disMidselect.value = true
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const handleCancel = () => {
  // Modal.confirm({
  //   title: '確認',
  //   content: '検索ページに戻りますか？',
  //   okText: 'は い',
  //   cancelText: 'いいえ',
  //   onOk: async () => {
  //     loading.value = true
  //     router.push({ path: '/mock/YS_kosin_nyu' })
  //   }
  // })
  loading.value = true
  router.push({ path: 'test000001' })
}
const saveData = () => {
  Modal.confirm({
    title: '情報',
    content: '登録処理を行います。よろしいですか？',
    okText: 'は い',
    cancelText: 'いいえ',
    onOk: async () => {
      loading.value = true
      router.push({ path: 'test000001' })
    }
  })
}
const bidChanged = () => {
  if (queryParams.bigCode) {
    disMidselect.value = false
  }
}

const filterbigOption = (input: string, option: any) => {
  return option.key.label.indexOf(input) >= 0 || option.value.indexOf(input) >= 0
}
const inputChange = () => {
  otherInfoData.value.forEach((item) => {
    if (item.input == '01') {
      item.inputName = '01:赤血球凝集抑制法(HI法)'
    } else if (item.input == '02') {
      item.inputName = '02:酵素免疫法(EIA法)'
    } else if (item.input == '03') {
      item.inputName = '03:ラテックス免役比濁法(LTI法)'
    } else if (item.input == '04') {
      item.inputName = '04:堂光酵索免疫法(ELFA法)'
    } else if (item.input == '05') {
      item.inputName = '05:化学発光酵素免疫法(CLEIA法)'
    }
  })
}

const collapseModel = ref({
  activeKey: '1',
  activeKeyBackup: '1'
})

const editRowEvent = (row) => {
  editVisible.value = true
}

const vxecellStyle = ({ row, column, columnIndex }) => {
  let rowstyle = {
    background: '',
    borderRight: '',
    borderBottom: ''
  }
  let flag =
    (column.title == '項　目' && columnIndex == '1') || (column.title == '' && columnIndex == '0')
  if (flag) {
    rowstyle.background = '#f8f8f9'
    rowstyle.borderRight = '1px solid #e8eaec'
    rowstyle.borderBottom = '1px solid #e8eaec'
  }
  return rowstyle
}
const memoShow = () => {
  memoRef.value.open()
}
const headerCellClassName: VxeTablePropTypes.HeaderCellClassName = ({ column }) => {
  if (column.field === 'name') {
    return 'table-name'
  }
  if (column.field === 'input') {
    return 'bg-editable'
  }
  return null
}

const hibShow = () => {
  hibRef.value.open()
}
</script>

<style lang="less" scoped>
.ant-table-striped :deep(.table-striped) td {
  background-color: #fafafa;
}
/deep/ .table-name {
  background-color: #ffffe1 !important;
}
/deep/ .bg-editable {
  background-color: #ecf5ff !important;
}
.font-mini-table :deep(::-webkit-scrollbar) {
  width: 0px;
  border-radius: 10px;
}
/deep/ .ant-table-cell {
  // height: 35px !important;
}

:deep .vxe-table--render-default .vxe-table--body-wrapper.fixed-left--wrapper,
.vxe-table--render-default .vxe-table--footer-wrapper.fixed-left--wrapper,
.vxe-table--render-default .vxe-table--header-wrapper.fixed-left--wrapper {
  border-top: 1px solid #606266 !important;
}
</style>
