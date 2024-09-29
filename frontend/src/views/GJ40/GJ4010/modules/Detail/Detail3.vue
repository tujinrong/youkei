<template>
  <a-modal
    :open="modalVisible"
    centered
    title="（GJ4013）焼却・埋却等互助金申請情報入力（契約交付情報表示）"
    width="1200px"
    :body-style="{
      height: tab === '2' ? '767px' : '600px',
      overflowY: tab === '2' ? 'hidden' : 'hidden',
    }"
    :mask-closable="false"
    destroy-on-close
    @cancel="goList"
  >
    <div class="parent-container">
      <div class="self_adaption_table form ml-1">
        <a-row>
          <a-col span="12">
            <read-only
              thWidth="110"
              th="契約者番号"
              :td="searchParams.KEIYAKUSYA_CD"
              :after="searchParams.KEIYAKUSYA_NAME"
            />
          </a-col>
        </a-row>
        <a-row>
          <a-col span="12">
            <th class="required" style="width: 110px">認定回数</th>
            <td>
              <a-form-item v-bind="validateInfos.HASSEI_KAISU" class="w-20!">
                <a-input-number
                  v-model:value="searchParams.HASSEI_KAISU"
                  :min="1"
                  :max="99"
                  :maxlength="2"
                  class="w-14"
                ></a-input-number>
              </a-form-item>
              <a-button class="ml-2" type="primary" @click="search"
                >検索</a-button
              >
            </td>
          </a-col>
        </a-row>
      </div>
      <div class="edit_table form mt-2">
        <a-tabs v-model:activeKey="tab">
          <a-tab-pane key="1" tab="1.契約農場別明細情報(交付情報)(表示)"
            ><div class="edit_table form">
              <a-row type="flex" justify="space-between">
                <a-col span="10">
                  <th class="required">申請日</th>
                  <td>
                    <a-form-item v-bind="validateInfos.SINSEI_DATE">
                      <DateJp
                        v-model:value="searchParams.SINSEI_DATE"
                        :notAllowClear="true"
                        class="max-w-50!"
                      />
                    </a-form-item>
                  </td>
                </a-col>
                <a-col span="14" style="justify-content: end">
                  <a-pagination
                    v-model:current="pageParams.PAGE_NUM"
                    v-model:page-size="pageParams.PAGE_SIZE"
                    :total="totalCount"
                    :page-size-options="['10', '25', '50', '100']"
                    :show-total="(total) => `抽出件数： ${total} 件 `"
                    show-less-items
                    show-size-changer
                    class="m-b-1 text-end"
                  />
                </a-col>
              </a-row>
              <vxe-table
                ref="xTableRef"
                class="mt-2 vxe-table-pop"
                :column-config="{ resizable: true }"
                :row-config="{ isCurrent: true, isHover: true }"
                :data="tableData"
                height="400px"
                :sort-config="{ trigger: 'cell', orders: ['desc', 'asc'] }"
                :empty-render="{ name: 'NotData' }"
                @cell-click="({ row }) => changeData()"
                @sort-change="
                  (e) => changeTableSort(e, toRef(pageParams, 'ORDER_BY'))
                "
              >
                <vxe-column
                  header-align="center"
                  align="right"
                  field="MEISAI_NO"
                  title="明細番号"
                  width="90"
                  sortable
                  :params="{ order: 1 }"
                >
                  <template #default="{ row }">
                    <a @click="changeData()">{{ row.MEISAI_NO }}</a>
                  </template>
                </vxe-column>
                <vxe-column
                  header-align="center"
                  field="NOJO_NAME"
                  title="農場名"
                  width="150"
                  sortable
                  :params="{ order: 2 }"
                >
                  <template #default="{ row }">
                    <a @click="changeData()">{{ row.NOJO_NAME }}</a>
                  </template>
                </vxe-column>
                <vxe-column
                  header-align="center"
                  field="ADDR"
                  title="農場住所"
                  min-width="100"
                  sortable
                  :params="{ order: 3 }"
                >
                </vxe-column>
                <vxe-column
                  header-align="center"
                  align="center"
                  field="TORI_KBN_NAME"
                  title="鳥の種類"
                  width="90"
                  sortable
                  :params="{ order: 4 }"
                ></vxe-column>
                <vxe-column
                  header-align="center"
                  field="KEISAN_KAISU"
                  title="計算回数"
                  width="90"
                  sortable
                  :params="{ order: 5 }"
                ></vxe-column>
                <vxe-column
                  header-align="center"
                  field="SYORI_JOKYO_KBN_NAME"
                  title="処理状況"
                  width="90"
                  sortable
                  :params="{ order: 6 }"
                ></vxe-column>
                <vxe-column
                  header-align="center"
                  field="KOFU_HASU"
                  title="互助金対象羽数"
                  width="130"
                  sortable
                  :params="{ order: 7 }"
                ></vxe-column>
                <vxe-column
                  header-align="center"
                  field="GENGAKU_RITU"
                  title="減額率(%)"
                  width="100"
                  sortable
                  :params="{ order: 8 }"
                ></vxe-column>
                <vxe-column
                  header-align="center"
                  field="KOFU_KIN"
                  title="焼却・埋却等互助金額"
                  width="170"
                  sortable
                  :params="{ order: 9 }"
                  :resizable="false"
                ></vxe-column>
              </vxe-table></div
          ></a-tab-pane>
          <a-tab-pane key="2" tab="2.契約農場別登録明細情報(確認用)"
            ><div class="edit_table form">
              <a-row>
                <a-col span="12">
                  <read-only-pop
                    thWidth="110"
                    th="農場"
                    :td="formData.NOJO_CD"
                  />
                </a-col>
              </a-row>
              <a-row>
                <a-col span="2">
                  <read-only-pop thWidth="110" th="住所" td="" :hideTd="true" />
                </a-col>
                <a-col span="4">
                  <read-only-pop th="　〒　" :td="formData.ADDR_POST" />
                </a-col>
                <a-col span="1"></a-col>
              </a-row>
              <a-row>
                <a-col span="2">
                  <read-only-pop thWidth="110" th="" td="" :hideTd="true" />
                </a-col>
                <a-col span="8">
                  <read-only-pop
                    thWidth="50"
                    th="住所1"
                    :td="formData.ADDR_1"
                  />
                </a-col>
                <a-col span="1"></a-col>
                <a-col span="7">
                  <read-only-pop
                    thWidth="50"
                    th="住所2"
                    :td="formData.ADDR_2"
                  />
                </a-col>
              </a-row>
              <a-row>
                <a-col span="2">
                  <read-only-pop thWidth="110" th="" :hideTd="true" />
                </a-col>
                <a-col span="8">
                  <read-only-pop
                    thWidth="50"
                    th="住所3"
                    :td="formData.ADDR_3"
                  />
                </a-col>
                <a-col span="1"></a-col>
                <a-col span="7">
                  <read-only-pop
                    thWidth="50"
                    th="住所4"
                    :td="formData.ADDR_4"
                  />
                </a-col>
              </a-row>
              <a-row>
                <a-col span="5">
                  <read-only-pop
                    thWidth="110"
                    th="鶏の種類"
                    :td="formData.TORI_KBN"
                  />
                </a-col>
              </a-row>
              <a-row>
                <a-col span="6">
                  <read-only-pop
                    thWidth="110"
                    th="契約羽数"
                    :td="formData.KOFU_HASU"
                  />
                </a-col>
                <a-col span="18">
                  <th style="width: 180px; text-align: end">
                    互助金交付対象羽数
                  </th>
                  <td style="align-items: center">
                    <a-input-number
                      class="input"
                      v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                      :min="1"
                    />
                    <span>（焼却・埋却等羽数が対象）</span>
                  </td>
                </a-col>
              </a-row>
              <a-row>
                <a-col span="6">
                  <read-only-pop
                    thWidth="150"
                    th="①互助金算定額"
                    :hideTd="true"
                  />
                </a-col>
                <a-col span="7" class="thleft">
                  <read-only-pop
                    thWidth="180"
                    th="互助金交付対象羽数"
                    :td="formData.KOFU_HASU"
                  />
                </a-col>
                <a-col span="0.5">
                  <span class="symbol">×</span>
                </a-col>
                <a-col span="5">
                  <read-only-pop
                    thWidth="150"
                    th="焼却・埋却等単価"
                    :td="formData.KOFU_HASU"
                  />
                </a-col>
                <a-col span="5">
                  <read-only-pop th="＝" :td="formData.KOFU_HASU" after="①" />
                </a-col>
              </a-row>
              <a-row>
                <a-col span="6">
                  <read-only-pop th="②焼却等経費" :hideTd="true" />
                </a-col>
                <a-col span="7">
                  <th style="width: 180px; text-align: end">焼却等経費</th>
                  <td style="align-items: center">
                    <a-input-number
                      class="input"
                      v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                      :min="1"
                    />
                    × ０．９
                  </td>
                </a-col>
                <a-col span="0.5">
                  <span class="symbol">—</span>
                </a-col>
                <a-col span="5">
                  <!--              <read-only-pop thWidth="150" th="国交付金(家伝法21条)" :td="formData.KOFU_HASU"/>-->
                  <th style="width: 150px">国交付金(家伝法21条)</th>
                  <td style="align-items: center">
                    <a-input-number
                      class="input"
                      v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                      :min="1"
                    />
                  </td>
                </a-col>
                <a-col span="5">
                  <read-only-pop th="＝" :td="formData.KOFU_HASU" after="②" />
                </a-col>
              </a-row>
              <a-row>
                <a-col span="6">
                  <read-only-pop th="③焼却・埋却互助金算定額" :hideTd="true" />
                </a-col>
                <a-col span="7" class="thleft">
                  <read-only-pop
                    thWidth="180"
                    th="※1(①と②の少ない方)"
                    :td="formData.KOFU_HASU"
                  />
                </a-col>
                <a-col span="0.5">
                  <span class="symbol">×</span>
                </a-col>
                <a-col span="5">
                  <!--              <read-only-pop thWidth="150" th="家伝法違反減額率" :td="formData.KOFU_HASU" after="%"/>-->
                  <th style="width: 150px">家伝法違反減額率</th>
                  <td style="align-items: center">
                    <a-input-number
                      class="input mr-1"
                      v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                      :min="1"
                    />%
                  </td>
                </a-col>
                <a-col span="5">
                  <read-only-pop
                    th="＝"
                    :td="formData.KOFU_HASU"
                    after="(円未満切上)※2"
                  />
                </a-col>
              </a-row>
              <a-row>
                <a-col span="13"></a-col>
                <a-col span="0.5">
                  <span class="symbol"></span>
                </a-col>
                <a-col span="5">
                  <read-only-pop
                    th="焼却・埋却互助金 算定(※1-※2)"
                    :hideTd="true"
                  />
                </a-col>
                <a-col span="5">
                  <read-only-pop th="＝" :td="formData.KOFU_HASU" after="③" />
                </a-col>
              </a-row>
              <a-row>
                <a-col span="6">
                  <read-only-pop
                    th="④焼却・埋却互助金(積立金分)"
                    :hideTd="true"
                  />
                </a-col>
                <a-col span="7">
                  <read-only-pop
                    thWidth="180"
                    th="③焼却・埋却互助金算定額"
                    :td="formData.KOFU_HASU"
                  />
                </a-col>
                <a-col span="0.5">
                  <span class="symbol">×</span>
                </a-col>
                <a-col span="5">
                  <read-only-pop thWidth="150" th="１/２" :hideTd="true" />
                </a-col>
                <a-col span="5">
                  <read-only-pop
                    th="＝"
                    :td="formData.KOFU_HASU"
                    after="(円未満切上)※3"
                  />
                </a-col>
              </a-row>
              <a-row>
                <a-col span="6" />
                <a-col span="7" class="thleft">
                  <read-only-pop
                    thWidth="180"
                    th="※3"
                    :td="formData.KOFU_HASU"
                  />
                </a-col>
                <a-col span="0.5">
                  <span class="symbol">×</span>
                </a-col>
                <a-col span="5">
                  <!--              <read-only-pop thWidth="100" th="互助金交付率" :td="formData.KOFU_HASU" after="%"/>-->
                  <th style="width: 100px">互助金交付率</th>
                  <td style="align-items: center">
                    <a-input-number
                      class="input2 mr-1"
                      v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                      :min="1"
                    />%
                  </td>
                </a-col>
                <a-col span="5">
                  <read-only-pop
                    th="＝"
                    :td="formData.KOFU_HASU"
                    after="(円未満切上)④"
                  />
                </a-col>
              </a-row>
              <a-row>
                <a-col span="6">
                  <read-only-pop
                    th="⑤焼却・埋却互助金(国庫交付金分)"
                    :hideTd="true"
                  />
                </a-col>
                <a-col span="7">
                  <read-only-pop
                    thWidth="180"
                    th="③焼却・埋却互助金算定額"
                    :td="formData.KOFU_HASU"
                  />
                </a-col>
                <a-col span="0.5">
                  <span class="symbol">—</span>
                </a-col>
                <a-col span="7">
                  <read-only-pop
                    thWidth="220"
                    th="※3焼却・埋却互助金(積立金分)"
                    :td="formData.KOFU_HASU"
                  />
                </a-col>
                <a-col span="3">
                  <read-only-pop th="＝" :td="formData.KOFU_HASU" after="⑤" />
                </a-col>
              </a-row>
              <a-row>
                <a-col span="6">
                  <read-only-pop th="⑥焼却・埋却互助金" :hideTd="true" />
                </a-col>
                <a-col span="4">
                  <read-only-pop
                    :hideTh="true"
                    :td="formData.KOFU_HASU"
                    after="(④﹢⑤)"
                  />
                </a-col>
              </a-row>
              <a-row>
                <a-col span="6">
                  <th class="required">入力確認有無</th>
                </a-col>
                <a-col span="8">
                  <td>
                    <a-radio-group v-model:value="formData.SYORI_JOKYO_KBN">
                      <a-radio :value="1">入力中</a-radio>
                      <a-radio :value="2">審査中</a-radio>
                      <a-radio :value="3">交付確定</a-radio>
                    </a-radio-group>
                  </td>
                </a-col>
                <a-col span="10">
                  <th>確定年月日</th>
                  <td>
                    <DateJp
                      v-model:value="formData.TANKA_MST_DATE"
                      :disabled="formData.SYORI_JOKYO_KBN !== 3"
                      class="w-50!"
                    />
                  </td>
                </a-col>
              </a-row>
              <!--          <table class="last-table">
            <tr>
              <th style="width: 150px">互助金算定額</th>
              <th style="width: 210px">互助金交付対象羽数</th>
              <td style="width: 100px"></td>
              <th style="width: 30px;text-align: center">×</th>
              <th style="width: 130px">焼却・埋却等単価</th>
              <td style="width: 100px"></td>
              <th style="width: 30px;text-align: center">＝</th>
              <td style="width: 100px"></td>
              <th style="width: 150px">※1</th>
            </tr>
            <tr>
              <th style="text-align: left">焼却等経費</th>
              <th style="text-align: left">焼却等経費</th>
              <td>
                <a-input-number
                  v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                  :min="1"
                  size="small"
                  style="width: 100%"
                />
              </td>
              <th style="text-align: center">×</th>
              <th>0.9 — 国交付金(家伝法21条)</th>
              <td>
                <a-input-number
                  v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                  :min="1"
                  size="small"
                  style="width: 100%"
                />
              </td>
              <td style="text-align: center">＝</td>
              <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
              <th>(円未満切り上げ)※2</th>
            </tr>
            <tr>
              <th rowspan="2" style="text-align: left">①焼却・埋却互助金算定額</th>
              <th rowspan="2" style="text-align: right">※1(①と②の少ない方)</th>
              <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
              <th style="text-align: center">×</th>
              <th style="text-align: left;" class="pl2">家伝法違反減額率</th>
              <td class="flex" style="border: none">
                <a-input-number
                  v-model:value="formData.SAIRANKEI_IKUSEIKEI"
                  :min="1"
                  size="small"
                  style="width: 100%"
                />
                %
              </td>
              <td style="text-align: center">＝</td>
              <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
              <th>(円未満切り上げ)※3</th>
            </tr>
            <tr>
              <th colspan="2"></th>
              <th colspan="2">焼却・埋却互助金 算定(※1-※2)</th>
              <td style="text-align: center">＝</td>
              <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
              <th>(円未満切り上げ)①</th>
            </tr>
            <tr>
              <th rowspan="2" style="text-align: left">①焼却・埋却互助金(積立金分)</th>
              <th rowspan="2" style="text-align: right">焼却・埋却互助金算定額<br>※3</th>
              <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
              <th style="text-align: center">×</th>
              <th colspan="2" style="text-align: left;" class="pl2">1/2</th>
              <td style="text-align: center">＝</td>
              <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
              <th>(円未満切り上げ)※3</th>
            </tr>
            <tr>
              <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
              <td style="text-align: center">×</td>
              <th>互助金交付率</th>
              <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI }}%</td>
              <td style="text-align: center">＝</td>
              <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
              <th>(円未満切り上げ)①</th>
            </tr>
            <tr>
              <th style="text-align: left">②焼却・埋却互助金(国庫交付金分)</th>
              <th style="text-align: right">焼却・埋却互助金算定額</th>
              <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
              <th style="text-align: center">—</th>
              <th>※3焼却・埋却互助金(積立金分)</th>
              <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
              <td style="text-align: center">＝</td>
              <td>{{ hasuGokei.SYUKEI_SEIKEI }}</td>
              <th>②</th>
            </tr>
            <tr>
              <th style="text-align: left">③焼却・埋却互助金</th>
              <td>{{ hasuGokei.SAIRANKEI_SEIKEI }}</td>
              <td colspan="7" style="text-align: left">① ＋ ②</td>
            </tr>
            <tr>
              <th class="required" style="text-align: left">入力確認有無</th>
              <td colspan="3" style="text-align: left">
                <a-radio-group v-model:value="formData.SEARCH_METHOD">
                  <a-radio :value="1">入力中</a-radio>
                  <a-radio :value="2">審査中</a-radio>
                  <a-radio :value="3">交付確定</a-radio>
                </a-radio-group>
              </td>
              <th style="text-align: left">確定年月日</th>
              <td colspan="4" style="text-align: left">
                <DateJp v-model:value="formData.TANKA_MST_DATE" :disabled="formData.SEARCH_METHOD !== 3"/>
              </td>
            </tr>
          </table>-->
            </div></a-tab-pane
          ></a-tabs
        >
      </div>
    </div>
    <template #footer>
      <div class="flex" style="align-items: end">
        <table v-if="tab == '1'" class="my-2 table-fixed">
          <tr>
            <th class="!w-10">鶏の種類</th>
            <th>採卵鶏(成鷄)</th>
            <th colspan="1">採卵鶏(育成鶏)</th>
            <th rowspan="1">肉用鶏</th>
            <th>種鶏(成鶏)</th>
            <th>種鶏(育成鶏)</th>
          </tr>
          <tr>
            <th style="width: 180px !important">互助金交付対象羽数</th>
            <td>{{ hasuGokei.SAIRANKEI_SEIKEI || 0 }}</td>
            <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI || 0 }}</td>
            <td>{{ hasuGokei.NIKUYOUKEI || 0 }}</td>
            <td>{{ hasuGokei.SYUKEI_SEIKEI || 0 }}</td>
            <td>{{ hasuGokei.SYUKEI_IKUSEIKEI || 0 }}</td>
          </tr>
          <tr>
            <th>焼却・埋却等互助金交付額</th>
            <td>{{ hasuGokei.SAIRANKEI_SEIKEI || 0 }}</td>
            <td>{{ hasuGokei.SAIRANKEI_IKUSEIKEI || 0 }}</td>
            <td>{{ hasuGokei.NIKUYOUKEI || 0 }}</td>
            <td>{{ hasuGokei.SYUKEI_SEIKEI || 0 }}</td>
            <td>{{ hasuGokei.SYUKEI_IKUSEIKEI || 0 }}</td>
          </tr>
          <tr>
            <th>うずら</th>
            <th>あひる</th>
            <th>きじ</th>
            <th>ほろほろ鳥</th>
            <th>七面鳥</th>
            <th>だちょう</th>
            <th>合計</th>
          </tr>
          <tr>
            <td>{{ hasuGokei.UZURA || 0 }}</td>
            <td>{{ hasuGokei.AHIRU || 0 }}</td>
            <td>{{ hasuGokei.KIJI || 0 }}</td>
            <td>{{ hasuGokei.HOROHOROTORI || 0 }}</td>
            <td>{{ hasuGokei.SICHIMENCHOU || 0 }}</td>
            <td>{{ hasuGokei.DACHOU || 0 }}</td>
            <td>
              {{ hasuGokei.TOTAL || 0 }}
            </td>
          </tr>
          <tr>
            <td>{{ hasuGokei.UZURA || 0 }}</td>
            <td>{{ hasuGokei.AHIRU || 0 }}</td>
            <td>{{ hasuGokei.KIJI || 0 }}</td>
            <td>{{ hasuGokei.HOROHOROTORI || 0 }}</td>
            <td>{{ hasuGokei.SICHIMENCHOU || 0 }}</td>
            <td>{{ hasuGokei.DACHOU || 0 }}</td>
            <td>
              {{ hasuGokei.TOTAL || 0 }}
            </td>
          </tr>
        </table>

        <a-button
          v-if="tab == '1'"
          class="danger-btn m2"
          :disabled="!isEdit"
          @click="deleteData"
          >削除</a-button
        >
      </div>
      <div class="pt-2 flex justify-between border-t-1">
        <a-space :size="20">
          <a-button :disabled="!isEdit" class="warning-btn" @click="saveData"
            >保存</a-button
          >
          <a-button type="primary" :disabled="!isEdit" @click="closeModal"
            >キャンセル</a-button
          >
        </a-space>
        <a-button type="primary" @click="closeModal">閉じる</a-button>
      </div>
    </template>
  </a-modal>
  <Detail2 v-model:visible="GJ4012Visible" :editkbn="GJ4012kbn" />
</template>
<script setup lang="ts">
import { Judgement } from '@/utils/judge-edited'
import { Form } from 'ant-design-vue'
import { computed, nextTick, reactive, watch, ref, toRef } from 'vue'
import { EnumEditKbn, PageStatus } from '@/enum'
import { GJ4011DetailVM, SearchRequest, SearchRowVM } from '../../type'
import { useRoute, useRouter } from 'vue-router'
import { changeTableSort, mathNumber } from '@/utils/util'
import DateJp from '@/components/Selector/DateJp/index.vue'
import Detail2 from '@/views/GJ40/GJ4010/modules/Detail/Detail2.vue'
import useSearch from '@/hooks/useSearch'
import { VxeTableInstance } from 'vxe-table'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const props = defineProps<{
  editkbn: EnumEditKbn
  visible: boolean
}>()
const emit = defineEmits(['update:visible'])
const router = useRouter()
const route = useRoute()
const xTableRef = ref<VxeTableInstance>()
const tab = ref('1')
const searchParams = reactive({
  KEIYAKUSYA_CD: undefined as number | undefined,
  KEIYAKUSYA_NAME: '',
  HASSEI_KAISU: undefined as number | undefined,
  SINSEI_DATE: new Date().toISOString().split('T')[0],
})
const formData = reactive({
  KEIYAKU_KBN: undefined as number | undefined,
  NOJO_CD: undefined as number | undefined,
  ADDR_POST: '',
  ADDR_1: '',
  ADDR_2: '',
  ADDR_3: '',
  ADDR_4: '',
  TORI_KBN: '',
  KEIYAKU_HASU: undefined as number | undefined,
  KOFU_HASU: undefined as number | undefined,
  KOFU_RITU: undefined as number | undefined,
  GENGAKU_RITU: undefined as number | undefined,
  KOFU_KIN: undefined as number | undefined,
  SEI_TUMITATE_KIN: undefined as number | undefined,
  KUNI_KOFU_KIN: undefined as number | undefined,
  SYORI_JOKYO_KBN: 1,
})

const hasuGokei = reactive({
  SAIRANKEI_SEIKEI: undefined,
  SAIRANKEI_IKUSEIKEI: undefined,
  NIKUYOUKEI: undefined,
  SYUKEI_SEIKEI: undefined,
  SYUKEI_IKUSEIKEI: undefined,
  UZURA: undefined,
  AHIRU: undefined,
  KIJI: undefined,
  HOROHOROTORI: undefined,
  SICHIMENCHOU: undefined,
  DACHOU: undefined,
  TOTAL: undefined,
})

const tableData = ref<SearchRequest[]>([])
const tableDefault = {
  MEISAI_NO: 0,
  NOJO_NAME: '(宇)宇宇イイアイ-',
  NOJO_ADDR: '北海道亜宇亜亜亜宇亜宇亜亜亜宇亜宇亜亜亜',
  TORISYURUI: '揉卵成鶏',
  KEIYAKUHASU: '111',
  BIKO: '',
}
const isEdit = ref(false)

const editJudge = new Judgement()
const devicePixelRatio = ref(window.devicePixelRatio)
const rules = {}
const { validate, clearValidate, validateInfos, resetFields } = Form.useForm(
  formData,
  rules
)
const { pageParams, totalCount, searchData, clear } = useSearch({
  service: undefined,
  source: tableData,
  params: toRef(() => formData),
})
const GJ4012Visible = ref(false)
const GJ4012kbn = ref<EnumEditKbn>(EnumEditKbn.Add)

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const modalVisible = computed({
  get() {
    return props.visible
  },
  set(visible) {
    emit('update:visible', visible)
  },
})
const isNew = computed(() => (props.editkbn === EnumEditKbn.Add ? true : false))
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(
  () => props.visible,
  (newValue) => {
    if (newValue) {
      nextTick(() => editJudge.reset())
    }
  }
)
watch(
  () => formData,
  () => {
    editJudge.setEdited()
  }
)
window.addEventListener('resize', function () {
  devicePixelRatio.value = window.devicePixelRatio
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
function search() {
  tableData.value.push(tableDefault)
  // if (xTableRef.value && tableData.value.length > 0) {
  //   xTableRef.value.setCurrentRow(tableData.value[0])
  // }
}

//画面遷移
const goList = () => {
  closeModal()
}

const changeData = () => {
  const a = xTableRef.value?.getCurrentRecord()
  isEdit.value = true
  tab.value = 2
}

const closeModal = () => {
  editJudge.judgeIsEdited(() => {
    clearValidate()
    resetFields()
    emit('update:visible', false)
  })
}

function openGJ4012(row?: any) {
  GJ4012Visible.value = true
}

// 登録
const saveData = () => {}

// 削除
const deleteData = () => {}
</script>
<style lang="scss" scoped>
th {
  min-width: 110px; //絶対変えられない
}

tr th {
  text-align: center;
  border: 1px solid rgb(190, 190, 190);
  background-color: #ffffe1;
  font-weight: 100;
}

tr td {
  text-align: right;
  border: 1px solid rgb(190, 190, 190);
}

.last-table {
  tr th {
    text-align: left;
  }

  tr td {
    text-align: left;
  }
}
.edit_table .ant-col {
  align-items: center;
}
.symbol {
  width: 15px;
  text-align: center;
  margin: 0 3px;
}
.thleft {
  :deep(th) {
    text-align: right;
  }
}
.input {
  background-color: #c0ffc0;
}
.input2 {
  background-color: #ffd700;
}
</style>
