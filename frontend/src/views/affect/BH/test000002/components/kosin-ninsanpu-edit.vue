<template>
  <div
    style="position: relative; margin-top: -5px"
    :style="{ 'padding-bottom': patientShow ? '210px' : '62px' }"
  >
    <a-card>
      <div class="panel-edit">
        <div>
          <a-row :gutter="0">
            <a-col :md="24" :lg="24">
              <div class="self_adaption_table">
                <a-row :gutter="[0, 10]">
                  <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                    <th style="width: 80px">年度</th>
                    <td style="">
                      <span>{{ queryParams.year }}</span>
                    </td>
                  </a-col>
                  <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                    <th style="width: 80px">宛名番号</th>
                    <td style="">
                      <span>{{ queryParams.organizationNo }}</span>
                    </td>
                  </a-col>
                  <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                    <th style="width: 80px">個人番号</th>
                    <td style="">
                      <span>{{ queryParams.personalNumber }}</span>
                    </td>
                  </a-col>
                  <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                    <th style="width: 80px">住民区分</th>
                    <td style="">
                      <span>{{ queryParams.class }}</span>
                    </td>
                  </a-col>

                  <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                    <th style="width: 80px">氏名</th>
                    <td>
                      <span>{{ queryParams.name }}</span>
                    </td>
                  </a-col>
                  <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                    <th style="width: 80px">カナ氏名</th>
                    <td>
                      <span>{{ queryParams.kanaName }}</span>
                    </td>
                  </a-col>
                  <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                    <th style="width: 80px">生年月日</th>
                    <td>
                      <span>{{ queryParams.date }}</span>
                    </td>
                  </a-col>
                  <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                    <th style="width: 80px">手帳番号</th>
                    <td>
                      <span>{{ queryParams.homePhone }}</span>
                    </td>
                  </a-col>
                  <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                    <th style="width: 80px">住所</th>
                    <td>
                      <span>{{ queryParams.home }}</span>
                    </td>
                  </a-col>
                  <a-col :xs="20" :sm="16" :md="12" :xl="8" :xxl="6">
                    <th style="width: 125px">妊婦世帯電話番号</th>
                    <td style="">
                      <span class="m-r-1">{{ queryParams.notebookNumber1 }}</span>
                      <span
                        v-if="queryParams.notebookNumber1"
                        class="m-r-1"
                        style="line-height: 30px"
                      >
                        —</span
                      >
                      <span class="m-r-1">{{ queryParams.notebookNumber2 }}</span>
                    </td>
                  </a-col>
                </a-row>
              </div>
            </a-col>
          </a-row>
        </div>
        <div class="m-t-1 header_operation">
          <a-space>
            <a-button type="primary" @click.prevent="patientShow = !patientShow">
              <down-outlined v-if="!patientShow" />
              <up-outlined v-else />
            </a-button>
            <a-button type="primary" @click="handleCancel">一覧へ</a-button>
            <a-button class="warning-btn" @click="saveData">登録</a-button>
            <a-button class="warning-btn">コビー登録</a-button>
            <a-button type="primary" danger @click="deleteData">削除</a-button>
          </a-space>
          <close-page></close-page>
        </div>
        <div v-show="patientShow" style="overflow: hidden">
          <div style="display: flex" class="flex-column">
            <div style="min-width: 730px; flex: auto">
              <div class="description-table header-description-table readonly m-t-1">
                <table>
                  <tbody>
                    <tr>
                      <th style="width: 70px">{{ '' }}</th>
                      <th>宛名番号</th>
                      <th style="width: 200px">氏名</th>
                      <th>生年月日</th>
                      <th style="border: 0">年齢</th>
                    </tr>
                    <tr v-for="(p, index) in parentsInfo" :key="index">
                      <td style="text-align: center">
                        <a-button
                          type="primary"
                          shape="round"
                          size="small"
                          style=""
                          @click="editRowEvent(p.kind)"
                          >{{ p.kind === '1' ? '妊 婦' : '父 親' }}</a-button
                        >
                      </td>
                      <td>
                        <span>{{ p.num }}</span>
                      </td>
                      <td>
                        <span>{{ p.name }}</span>
                      </td>
                      <td>
                        <span>{{ p.date }}</span>
                      </td>
                      <td style="text-align: right">
                        <span>{{ p.age }}</span>
                      </td>
                    </tr>
                    <!-- <tr>
                      <td style="text-align: center">
                        <a-button
                          type="primary"
                          shape="round"
                          size="small"
                          style=""
                          @click="editRowEvent('2')"
                          >父親</a-button
                        >
                      </td>
                      <td>
                        <span>00000084793</span>
                      </td>
                      <td>
                        <span>金森 倖也</span>
                      </td>
                      <td>
                        <span>昭和50年01月22日</span>
                      </td>
                      <td style="text-align: right">
                        <span>47歳</span>
                      </td>
                    </tr> -->
                  </tbody>
                </table>
              </div>
              <div class="description-table header-description-table" style="margin-top: -1px">
                <table>
                  <tbody>
                    <tr>
                      <th style="width: 70px; text-align: center">訪問希望</th>
                      <td style="width: 120px">
                        <ai-select
                          v-model:value="queryParams.visit"
                          :options="visitOptions"
                          style="width: 120px"
                        ></ai-select>
                      </td>
                      <th style="width: 80px; text-align: center">担当保健師</th>
                      <td style="width: 180px">
                        <ai-select
                          v-model:value="queryParams.healthcare"
                          :options="healthcareOptions"
                          style="width: 180px"
                        ></ai-select>
                      </td>
                      <th style="width: 80px; text-align: center">母子推進員</th>
                      <td>
                        <ai-select
                          v-model:value="queryParams.Promoter"
                          :options="healthcareOptions"
                          style="width: 180px"
                        ></ai-select>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
              <div style="margin-top: 5px">
                <a-checkbox v-model:checked="queryParams.notice">通知希望</a-checkbox>
                <a-checkbox v-model:checked="queryParams.disability">無効</a-checkbox>
                <span class="m-l-1">理由</span>
                <a-input
                  v-model:value="queryParams.bigCode"
                  style="width: 520px; margin-left: 10px"
                  show-search
                >
                </a-input>
              </div>
            </div>
            <div style="margin-left: -1px" class="right-table1">
              <div class="description-table m-t-1 header-description-table">
                <table>
                  <tbody>
                    <tr>
                      <th>届出年月日</th>
                      <td colspan="3">
                        <date-jp
                          v-model:value="queryParams.declarationDate"
                          style="width: 150px"
                        ></date-jp>
                        <a-input
                          v-model:value="queryParams.week"
                          style="width: 50px; margin-left: 5px"
                          show-search
                        >
                        </a-input>
                        <span style="margin-left: 5px" class="m-r-1">週</span>
                        <a-checkbox v-model:checked="queryParams.childbirth">分娩後</a-checkbox>
                      </td>
                      <th>分娩予定年月日</th>
                      <td>
                        <date-jp
                          v-model:value="queryParams.expectedChildbirthDate"
                          style="width: 155px"
                        ></date-jp>
                        <span style="margin: 0 10px">{{ queryParams.age }} 歳</span>
                      </td>
                    </tr>
                    <tr>
                      <th>保険</th>
                      <td colspan="3">
                        <ai-select
                          v-model:value="queryParams.insurance"
                          :options="insuranceOptions"
                          style="width: 150px"
                          class="m-r-1"
                        ></ai-select>
                        <a-checkbox v-model:checked="queryParams.oneself">本人</a-checkbox>
                      </td>
                      <th>出生予定順位</th>
                      <td>
                        <span>第</span>
                        <a-input
                          v-model:value="queryParams.birthOrder"
                          class="m-r-1 m-l-1"
                          style="width: 40px"
                          show-search
                        >
                        </a-input>
                        <span>位</span>
                      </td>
                    </tr>
                    <tr>
                      <th>最終月経年月日</th>
                      <td colspan="3">
                        <date-jp v-model:value="queryParams.endDate"></date-jp>
                      </td>
                      <th style="width: 120px" rowSpan="2">分娩埸所</th>
                      <td rowSpan="2">
                        <ai-select
                          v-model:value="queryParams.childbirthDelivery"
                          :options="insuranceOptions"
                          style="width: 120px"
                          class="m-r-1"
                        ></ai-select>
                        <a-button
                          class="m-r-1"
                          shape="round"
                          type="primary"
                          style=""
                          size="small"
                          @click="onSearchOrganization"
                          >検索</a-button
                        ><br />
                        <a-input
                          v-model:value="queryParams.address"
                          style="width: 200px; margin-top: 5px"
                          show-search
                        >
                        </a-input>
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 120px">手帳(渠)</th>
                      <td>
                        <ai-select
                          v-model:value="queryParams.manual"
                          :options="visitOptions"
                          style="width: 100%"
                        ></ai-select>
                      </td>
                      <th style="width: 100px">手帳(町)</th>
                      <td style="width: 150px">
                        <ai-select
                          v-model:value="queryParams.manual2"
                          :options="visitOptions"
                          style="width: 100%"
                        ></ai-select>
                      </td>
                    </tr>
                    <tr>
                      <th style="width: 15%">発行区分</th>
                      <td style="width: 13%">
                        <ai-select
                          v-model:value="queryParams.category"
                          :options="categoryOptions"
                          style="width: 150px"
                        ></ai-select>
                      </td>
                      <th>発行埸所</th>
                      <td colspan="3">
                        <ai-select
                          v-model:value="queryParams.place"
                          :options="placeOptions"
                          style="width: 100%"
                        ></ai-select>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
      </div>
    </a-card>
    <a-card class="m-t-1 panel-edit" style="margin-bottom: 50px">
      <div>
        <a-tabs v-model:activeKey="tabActiveKey">
          <a-tab-pane key="1" tab="妊產婦基本情報">
            <a-tabs v-model:activeKey="healthcareActiveKey" type="card" class="highlight-tabs">
              <a-tab-pane key="1" :tab="isEmptyHealthcare ? '保健指導' : '保健指導(入力あり)'">
                <div class="tab1-1">
                  <div>
                    <div>
                      <div style="display: flex; align-items: center">
                        <div class="description-table">
                          <table>
                            <tbody>
                              <tr>
                                <th style="width: 100px">担当者名</th>
                                <td style="width: 365px">
                                  <ai-select
                                    v-model:value="healthcareInfo.personCharge"
                                    :options="healthcareOptions"
                                    style="width: 50%"
                                  ></ai-select>
                                  <ai-select
                                    v-model:value="healthcareInfo.personCharge2"
                                    :options="healthcareOptions"
                                    style="width: 50%"
                                  ></ai-select>
                                </td>
                                <th style="width: 80px">喫煙</th>
                                <td style="width: 120px">
                                  <a-input
                                    v-model:value="healthcareInfo.smoking"
                                    style="width: 50px; margin-right: 10px"
                                    show-search
                                  >
                                  </a-input>
                                  <span>本／日</span>
                                </td>
                                <th style="width: 100px">飲酒種類</th>
                                <td style="width: 300px">
                                  <ai-select
                                    v-model:value="healthcareInfo.drinking"
                                    :options="drinkingOptions"
                                    style="width: 150px"
                                  ></ai-select>
                                  <span class="m-l-1">1回量</span>
                                  <a-input
                                    v-model:value="healthcareInfo.milliliter"
                                    style="width: 50px; margin: 0 10px"
                                    show-search
                                  >
                                  </a-input>
                                  <span>cc</span>
                                </td>
                              </tr>
                            </tbody>
                          </table>
                        </div>
                        <div>
                          <a-button type="primary" class="m-l-2 btn-round">歯科問診</a-button>
                        </div>
                      </div>
                      <div class="description-table" style="margin-top: -1px">
                        <table>
                          <tbody>
                            <tr>
                              <th>育児への協力及び相談者の有無</th>
                              <td style="width: 460px">
                                <ai-select
                                  v-model:value="healthcareInfo.consultant"
                                  :options="visitOptions"
                                  style="width: 100px; margin-right: 5px"
                                ></ai-select>
                                <a-input
                                  v-model:value="healthcareInfo.consultantContent"
                                  style="width: 75%"
                                  show-search
                                >
                                </a-input>
                              </td>
                              <th>栄養強化対象</th>
                              <td>
                                <ai-select
                                  v-model:value="healthcareInfo.nutrition"
                                  :options="strengthenOptions"
                                  style="width: 180px"
                                ></ai-select>
                                <span class="m-l-1 m-r-1">偏食</span>
                                <ai-select
                                  v-model:value="healthcareInfo.pick"
                                  :options="visitOptions"
                                  style="width: 90px"
                                ></ai-select>
                                <span class="m-l-1 m-r-1">牛乳</span>
                                <ai-select
                                  v-model:value="healthcareInfo.milk"
                                  :options="milkOptions"
                                  style="width: 130px"
                                ></ai-select>
                                <a-input
                                  v-model:value="healthcareInfo.milliliter2"
                                  style="width: 50px; margin: 0 10px"
                                  show-search
                                >
                                </a-input>
                                <span>cc</span>
                              </td>
                            </tr>
                          </tbody>
                        </table>
                      </div>
                      <div style="margin-top: -1px; flex-wrap: wrap" class="flex flex-column-1680">
                        <div
                          class="description-table left-table left-full-width"
                          style="width: 1234px; margin-right: 10px"
                        >
                          <table>
                            <tbody>
                              <tr>
                                <th style="width: 30px; text-align: center">要管理内容</th>
                                <td style="display: block">
                                  <div>
                                    <vxe-table
                                      ref="xTable"
                                      border
                                      height="175px"
                                      :data="contentDataSource"
                                      class="mytable-scrollbar"
                                      :column-config="{ resizable: true }"
                                      :cell-style="vxecellStyle"
                                      :edit-config="{
                                        trigger: 'click',
                                        mode: 'cell',
                                        showStatus: false
                                      }"
                                      :mouse-config="{ selected: true }"
                                      :row-config="{
                                        isCurrent: true,
                                        useKey: true,
                                        keyField: 'id'
                                      }"
                                      :keyboard-config="{
                                        isArrow: true,
                                        isEsc: true,
                                        isTab: true,
                                        isEdit: true,
                                        enterToTab: true
                                      }"
                                      @cell-click="
                                        () => {
                                          isSelectedHealthCareTable = true
                                        }
                                      "
                                    >
                                      <vxe-column
                                        field="content"
                                        title="内容"
                                        width="150"
                                        :edit-render="{
                                          name: 'AiSelect',
                                          options: contentOptions,
                                          events: {
                                            change: () => {
                                              checkEmptyHealthcare()
                                            }
                                          }
                                        }"
                                      >
                                      </vxe-column>
                                      <vxe-column
                                        field="content"
                                        title="ﾌｵﾛｰ方法"
                                        width="150"
                                        :edit-render="{
                                          name: 'AiSelect',
                                          options: contactOptions,
                                          events: {
                                            change: () => {
                                              checkEmptyHealthcare()
                                            }
                                          }
                                        }"
                                      >
                                      </vxe-column>
                                      <vxe-column
                                        field="appointment"
                                        title="ﾌｵﾛｰ予定年月日"
                                        width="150"
                                        :edit-render="{
                                          name: 'DateJp',
                                          events: {
                                            change: () => {
                                              checkEmptyHealthcare()
                                            }
                                          }
                                        }"
                                      >
                                      </vxe-column>
                                      <vxe-column
                                        field="completion"
                                        title="ﾌｵﾛｰ完了年月日"
                                        width="150"
                                        :edit-render="{
                                          name: 'DateJp',
                                          events: {
                                            change: () => {
                                              checkEmptyHealthcare()
                                            }
                                          }
                                        }"
                                      >
                                      </vxe-column>
                                      <vxe-column
                                        field="remarks"
                                        title="備考"
                                        :edit-render="{
                                          autofocus: '.vxe-input--inner',
                                          autoselect: true
                                        }"
                                      >
                                        <template #edit="{ row }">
                                          <vxe-input
                                            v-model="row.remarks"
                                            type="text"
                                            placeholder=""
                                            @change="checkEmptyHealthcare()"
                                          ></vxe-input>
                                        </template>
                                      </vxe-column>
                                    </vxe-table>
                                  </div>
                                  <div style="text-align: left; margin: 5px 5px 0px 0px">
                                    <a-button
                                      size="small"
                                      class="m-r-1 btn-round"
                                      type="primary"
                                      @click="addRows(-1)"
                                      >追加</a-button
                                    >
                                    <a-button
                                      size="small"
                                      class="btn-round btn-mag"
                                      type="primary"
                                      :disabled="!isSelectedHealthCareTable"
                                      @click="deleteRows()"
                                      >削除</a-button
                                    >
                                  </div>
                                </td>
                              </tr>
                            </tbody>
                          </table>
                        </div>
                        <div
                          class="description-table right-table2 right-full-width"
                          style="margin-left: -1px; min-width: 300px; flex: 1 0 300px"
                        >
                          <table style="height: 100%">
                            <tbody>
                              <tr>
                                <th style="width: 30px; text-align: center" class="width-220">
                                  コメント
                                </th>
                                <td class="right-textarea-width" style="min-width: 250px">
                                  <a-textarea
                                    v-model:value="healthcareInfo.comments"
                                    placeholder=""
                                    :auto-size="{ minRows: 9, maxRows: 9 }"
                                  />
                                </td>
                              </tr>
                            </tbody>
                          </table>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="m-t-1">
                    <a-tabs
                      v-model:activeKey="guidanceActiveKey"
                      type="editable-card"
                      class="highlight-tabs"
                      @edit="guidanceOnEdit"
                    >
                      <a-tab-pane
                        v-for="pane in guidancePanes"
                        :key="pane.key"
                        :tab="pane.title"
                        :closable="guidancePanes.length > 1"
                      >
                        <div class="flex">
                          <div class="description-table" style="width: 50%">
                            <table>
                              <tbody>
                                <tr>
                                  <th style="width: 100px">指導内容</th>
                                  <td style="width: 150px">
                                    <ai-select
                                      v-model:value="pane.guidance"
                                      style="width: 100%"
                                      :options="guidanceOptions"
                                      @change="checkEmptyHealthcare()"
                                    ></ai-select>
                                  </td>
                                  <th style="width: 100px">指導年月日</th>
                                  <td style="width: 150px">
                                    <date-jp
                                      v-model:value="pane.guidanceDate"
                                      style="width: 100%"
                                      @change="checkEmptyHealthcare()"
                                    ></date-jp>
                                  </td>
                                </tr>
                                <tr>
                                  <th>コメント</th>
                                  <td :colspan="3">
                                    <a-textarea
                                      v-model:value="pane.remarks"
                                      placeholder=""
                                      :auto-size="{ minRows: 4, maxRows: 4 }"
                                      @change="checkEmptyHealthcare()"
                                    />
                                  </td>
                                </tr>
                              </tbody>
                            </table>
                          </div>
                          <div class="description-table" style="margin-left: -1px; width: 50%">
                            <table>
                              <tbody>
                                <tr>
                                  <th style="width: 100px">担当者名</th>
                                  <td style="width: 380px">
                                    <ai-select
                                      v-model:value="pane.personcharge"
                                      style="width: 50%"
                                      :options="healthcareOptions"
                                      @change="checkEmptyHealthcare()"
                                    ></ai-select>
                                    <ai-select
                                      v-model:value="pane.personcharge2"
                                      style="width: 50%"
                                      :options="healthcareOptions"
                                    ></ai-select>
                                  </td>
                                </tr>
                                <tr>
                                  <th>その他</th>
                                  <td>
                                    <a-textarea
                                      v-model:value="pane.other"
                                      placeholder=""
                                      :auto-size="{ minRows: 4, maxRows: 4 }"
                                      @change="checkEmptyHealthcare()"
                                    />
                                  </td>
                                </tr>
                              </tbody>
                            </table>
                          </div>
                        </div>
                      </a-tab-pane>
                    </a-tabs>
                  </div>
                </div>
              </a-tab-pane>
              <a-tab-pane
                key="2"
                :tab="isEmptyWorkInfo ? '就労状況' : '就労状況(入力あり)'"
                class="tab1-2"
              >
                <div class="flex flex-column-1720">
                  <div class="description-table left-table" style="width: 68%">
                    <table>
                      <tbody>
                        <tr>
                          <th>勤務先</th>
                          <td colspan="3">
                            <a-input v-model:value="workInfo.work2" show-search> </a-input>
                          </td>
                          <th>休暇</th>
                          <td colspan="3">
                            <span>産前:</span>
                            <a-input
                              v-model:value="workInfo.antenatal"
                              style="width: 50px; margin: 0 10px"
                              show-search
                            >
                            </a-input>
                            <span>週間</span>
                            <span class="m-l-1">産後:</span>
                            <a-input
                              v-model:value="workInfo.postpartum"
                              style="width: 50px; margin: 0 10px"
                              show-search
                            >
                            </a-input>
                            <span>週間</span>
                          </td>
                        </tr>
                        <tr>
                          <th style="width: 80px">勤務区分</th>
                          <td style="width: 150px">
                            <ai-select
                              v-model:value="workInfo.workClassification"
                              style="width: 100%"
                              :options="workOptions"
                            ></ai-select>
                          </td>
                          <th style="width: 80px">電話番号</th>
                          <td style="width: 165px">
                            <a-input v-model:value="workInfo.phone" show-search> </a-input>
                          </td>
                          <th style="width: 80px">退職予定日</th>
                          <td style="width: 160px">
                            <date-jp
                              v-model:value="workInfo.retirementDate"
                              style="width: 160px"
                            ></date-jp>
                          </td>
                          <th style="width: 80px">育児休暇</th>
                          <td>
                            <ai-select
                              v-model:value="workInfo.leave"
                              style="width: 100%"
                              :options="visitOptions"
                            ></ai-select>
                          </td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                  <div class="description-table right-table" style="margin-left: -1px; width: 32%">
                    <table>
                      <tbody>
                        <tr>
                          <th>仕事内容</th>
                          <td colspan="3">
                            <a-input v-model:value="workInfo.jobContent" show-search> </a-input>
                          </td>
                        </tr>
                        <tr>
                          <th style="width: 80px">通勤方法</th>
                          <td style="width: 189px">
                            <ai-select
                              v-model:value="workInfo.commutingMode"
                              style="width: 100%"
                              :options="commutingOptions"
                            ></ai-select>
                          </td>
                          <th style="width: 80px">通勤時間</th>
                          <td>
                            <a-input
                              v-model:value="workInfo.commutingTime"
                              style="width: 80px; margin-right: 5px"
                              show-search
                            >
                            </a-input>
                            <span>分</span>
                          </td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>
              </a-tab-pane>
              <a-tab-pane key="3" :tab="isEmptyBirthInfo ? '出生歴' : '出生歴(入力あり)'">
                <div style="display: flex; align-items: end">
                  <div style="flex: auto">
                    <div class="description-table">
                      <table>
                        <tbody>
                          <tr>
                            <vxe-table
                              ref="birthTable"
                              border
                              height="175px"
                              style="border: 0"
                              show-overflow
                              :data="birthDataSource"
                              class="mytable-scrollbar"
                              :column-config="{ resizable: true }"
                              :cell-style="vxecellStyle"
                              :edit-config="{ trigger: 'click', mode: 'cell', showStatus: false }"
                              :row-config="{ isCurrent: true, isHover: false }"
                              :mouse-config="{ selected: true }"
                              :keyboard-config="{
                                isArrow: true,
                                isEsc: true,
                                isTab: true,
                                isEdit: true,
                                enterToTab: true
                              }"
                              @cell-click="
                                () => {
                                  isSelectedBirthTable = true
                                }
                              "
                            >
                              <vxe-column
                                field="order"
                                title="出生顺位"
                                width="130"
                                :edit-render="{ autofocus: '.vxe-input--inner', autoselect: true }"
                              >
                                <template #default="{ row }">
                                  <span v-if="row.order">第 {{ row.order }} 位</span>
                                </template>
                                <template #edit="{ row }">
                                  <div style="display: flex">
                                    <span class="m-r-1" style="line-height: 35px">第</span>
                                    <vxe-input
                                      v-model="row.order"
                                      style="width: 50%"
                                      type="text"
                                      placeholder=""
                                      @change="checkEmptyBirthInfo()"
                                    ></vxe-input>
                                    <span class="m-l-1" style="line-height: 35px">位</span>
                                  </div>
                                </template>
                              </vxe-column>
                              <vxe-column
                                field="age"
                                title="母親年齢"
                                width="130"
                                :edit-render="{ autofocus: '.vxe-input--inner', autoselect: true }"
                              >
                                <template #default="{ row }">
                                  <span v-if="row.age">{{ row.age }} 歳</span>
                                </template>
                                <template #edit="{ row }">
                                  <div style="display: flex">
                                    <vxe-input
                                      v-model="row.age"
                                      style="width: 50%"
                                      type="text"
                                      placeholder=""
                                      @change="checkEmptyBirthInfo()"
                                    ></vxe-input>
                                    <span class="m-l-1" style="line-height: 35px">歳</span>
                                  </div>
                                </template>
                              </vxe-column>
                              <vxe-column
                                field="weight"
                                title="出生時体重"
                                width="130"
                                :edit-render="{ autofocus: '.vxe-input--inner', autoselect: true }"
                              >
                                <template #default="{ row }">
                                  <span v-if="row.weight">{{ row.weight }} g</span>
                                </template>
                                <template #edit="{ row }">
                                  <div style="display: flex">
                                    <vxe-input
                                      v-model="row.weight"
                                      type="text"
                                      style="width: 50%"
                                      placeholder=""
                                      @change="checkEmptyBirthInfo()"
                                    ></vxe-input>
                                    <span class="m-l-1" style="line-height: 35px">g</span>
                                  </div>
                                </template>
                              </vxe-column>
                              <vxe-column
                                field="week"
                                title="妊娠週数"
                                width="130"
                                :edit-render="{ autofocus: '.vxe-input--inner', autoselect: true }"
                              >
                                <template #default="{ row }">
                                  <span v-if="row.week">{{ row.week }} 週</span>
                                </template>
                                <template #edit="{ row }">
                                  <div style="display: flex">
                                    <vxe-input
                                      v-model="row.week"
                                      style="width: 50%"
                                      type="text"
                                      placeholder=""
                                      @change="checkEmptyBirthInfo()"
                                    ></vxe-input>
                                    <span class="m-l-1" style="line-height: 35px">週</span>
                                  </div>
                                </template>
                              </vxe-column>
                              <vxe-column
                                field="delivery"
                                title="妊娠分娩異常"
                                width="130"
                                :edit-render="{
                                  name: 'AiSelect',
                                  options: visitOptions,
                                  events: {
                                    change: () => {
                                      checkEmptyBirthInfo()
                                    }
                                  }
                                }"
                              >
                              </vxe-column>
                              <vxe-column
                                field="healthStatus"
                                title="子供の健康状態"
                                width="140"
                                :edit-render="{
                                  name: 'AiSelect',
                                  options: healthStatusOptions,
                                  events: {
                                    change: () => {
                                      checkEmptyBirthInfo()
                                    }
                                  }
                                }"
                              >
                              </vxe-column>
                              <vxe-column
                                field="remarks"
                                title="備考"
                                :edit-render="{ autofocus: '.vxe-input--inner', autoselect: true }"
                              >
                                <template #default="{ row }">
                                  <span>{{ row.remarks }}</span>
                                </template>
                                <template #edit="{ row }">
                                  <vxe-input
                                    v-model="row.remarks"
                                    type="text"
                                    placeholder=""
                                    @change="checkEmptyBirthInfo()"
                                  ></vxe-input>
                                </template>
                              </vxe-column>
                            </vxe-table>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                  </div>
                  <div class="m-l-1 m-r-1">
                    <a-button type="primary" class="btn-round" @click="addBirthRows(-1)"
                      >追加</a-button
                    ><br />
                    <a-button
                      type="primary"
                      class="m-t-1 btn-round btn-mag"
                      :disabled="!isSelectedBirthTable"
                      @click="deleteBirthRows()"
                      >削除</a-button
                    >
                  </div>
                </div>
              </a-tab-pane>
              <a-tab-pane key="4" :tab="isEmptyPregnancyInfo ? '妊娠歴' : '妊娠歴(入力あり)'">
                <a-row :gutter="10">
                  <a-col :md="20" :lg="20">
                    <div style="display: flex; align-items: end">
                      <div class="description-table" style="flex: auto">
                        <table>
                          <tbody>
                            <tr>
                              <vxe-table
                                ref="pregnancyDataTable"
                                border
                                height="180px"
                                style="border: 0px"
                                show-overflow
                                :data="pregnancyDataSource"
                                class="mytable-scrollbar"
                                :column-config="{ resizable: true }"
                                :cell-style="vxecellStyle"
                                :edit-config="{ trigger: 'click', mode: 'cell', showStatus: false }"
                                :row-config="{ isCurrent: true, isHover: false }"
                                :mouse-config="{ selected: true }"
                                :keyboard-config="{
                                  isArrow: true,
                                  isEsc: true,
                                  isTab: true,
                                  isEdit: true,
                                  enterToTab: true
                                }"
                                @cell-click="
                                  () => {
                                    isSelectedPregnancyTable = true
                                  }
                                "
                              >
                                <vxe-column
                                  field="date"
                                  title="年月日"
                                  width="150"
                                  :edit-render="{
                                    name: 'DateJp',
                                    events: {
                                      change: () => {
                                        checkEmptyPregnancyInfo()
                                      }
                                    }
                                  }"
                                >
                                </vxe-column>
                                <vxe-column
                                  field="division"
                                  title="妊娠歴区分"
                                  width="150"
                                  :edit-render="{
                                    name: 'AiSelect',
                                    options: divisionOptions,
                                    events: {
                                      change: () => {
                                        checkEmptyPregnancyInfo()
                                      }
                                    }
                                  }"
                                >
                                </vxe-column>
                                <vxe-column
                                  field="birthtype"
                                  title="自然·人工"
                                  width="150"
                                  :edit-render="{
                                    name: 'AiSelect',
                                    options: birthtypeOptions,
                                    events: {
                                      change: () => {
                                        checkEmptyPregnancyInfo()
                                      }
                                    }
                                  }"
                                >
                                </vxe-column>
                                <vxe-column
                                  field="week"
                                  title="妊娠週数"
                                  width="150"
                                  :edit-render="{
                                    autofocus: '.vxe-input--inner',
                                    autoselect: true
                                  }"
                                >
                                  <template #default="{ row }">
                                    <span v-if="row.week">{{ row.week }}週</span>
                                  </template>
                                  <template #edit="{ row }">
                                    <div style="display: flex">
                                      <vxe-input
                                        v-model="row.week"
                                        style="width: 50%"
                                        type="text"
                                        placeholder=""
                                        @change="checkEmptyPregnancyInfo()"
                                      ></vxe-input>
                                      <span class="m-l-1" style="line-height: 35px">週</span>
                                    </div>
                                  </template>
                                </vxe-column>
                                <vxe-column
                                  field="remarks"
                                  title="備考"
                                  :edit-render="{
                                    autofocus: '.vxe-input--inner',
                                    autoselect: true
                                  }"
                                >
                                  <template #default="{ row }">
                                    <span>{{ row.remarks }}</span>
                                  </template>
                                  <template #edit="{ row }">
                                    <div style="display: flex">
                                      <vxe-input
                                        v-model="row.remarks"
                                        type="text"
                                        placeholder=""
                                        @change="checkEmptyPregnancyInfo()"
                                      ></vxe-input>
                                    </div>
                                  </template>
                                </vxe-column>
                              </vxe-table>
                            </tr>
                          </tbody>
                        </table>
                      </div>
                      <div class="m-l-1">
                        <div>
                          <a-button class="btn-round" type="primary" @click="addPregnancyRows(-1)"
                            >追加</a-button
                          >
                        </div>
                        <div class="m-t-1">
                          <a-button
                            type="primary"
                            class="btn-round btn-mag"
                            :disabled="!isSelectedPregnancyTable"
                            @click="deletepregnancyRows()"
                            >削除</a-button
                          >
                        </div>
                      </div>
                    </div>
                  </a-col>
                  <a-col :md="4" :lg="4">
                    <div class="description-table readonly" style="margin-left: 20px">
                      <table>
                        <tbody>
                          <tr>
                            <th style="width: 80px; height: 45px">計</th>
                            <th style="width: 80px">自然</th>
                            <th style="width: 80px">人工</th>
                          </tr>
                          <tr>
                            <th style="height: 45px">流産</th>
                            <td>0回</td>
                            <td>0回</td>
                          </tr>
                          <tr>
                            <th style="height: 45px">早産</th>
                            <td>0回</td>
                            <td>0回</td>
                          </tr>
                          <tr>
                            <th style="height: 45px">死産</th>
                            <td>0回</td>
                            <td>0回</td>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                  </a-col>
                </a-row>
              </a-tab-pane>
              <a-tab-pane
                key="5"
                :tab="isEmptyFamilyInfo ? '家族環境・同居の家族' : '家族環境・同居の家族(入力あり)'"
                class="tab-1-5"
              >
                <div>
                  <div style="display: flex" class="flex-column-1480">
                    <div style="flex: auto">
                      <div class="description-table">
                        <table>
                          <tbody>
                            <tr>
                              <vxe-table
                                ref="familyTable"
                                border
                                style="border: 0px"
                                height="175px"
                                show-overflow
                                :data="familyDataSource"
                                class="mytable-scrollbar"
                                :column-config="{ resizable: true }"
                                :cell-style="vxecellStyle"
                                :edit-config="{ trigger: 'click', mode: 'cell', showStatus: false }"
                                :row-config="{ isCurrent: true, isHover: false }"
                                :mouse-config="{ selected: true }"
                                :keyboard-config="{
                                  isArrow: true,
                                  isEsc: true,
                                  isTab: true,
                                  isEdit: true,
                                  enterToTab: true
                                }"
                                @cell-click="
                                  () => {
                                    isSelectedFamilyTable = true
                                  }
                                "
                              >
                                <vxe-column
                                  field="name"
                                  title="氏名"
                                  width="145"
                                  :edit-render="{
                                    autofocus: '.vxe-input--inner',
                                    autoselect: true
                                  }"
                                >
                                  <template #default="{ row }">
                                    <span>{{ row.name }}</span>
                                  </template>
                                  <template #edit="{ row }">
                                    <vxe-input
                                      v-model="row.name"
                                      type="text"
                                      placeholder=""
                                      @change="checkEmptyFamilyInfo()"
                                    ></vxe-input>
                                  </template>
                                </vxe-column>
                                <vxe-column
                                  field="age"
                                  title="年齢"
                                  width="140"
                                  :edit-render="{
                                    autofocus: '.vxe-input--inner',
                                    autoselect: true
                                  }"
                                >
                                  <template #default="{ row }">
                                    <span v-if="row.age">{{ row.age }} 歳</span>
                                  </template>
                                  <template #edit="{ row }">
                                    <div style="display: flex">
                                      <vxe-input
                                        v-model="row.age"
                                        style="width: 50%"
                                        type="text"
                                        placeholder=""
                                        @change="checkEmptyFamilyInfo()"
                                      ></vxe-input>
                                      <span class="m-l-1" style="line-height: 35px">歳</span>
                                    </div>
                                  </template>
                                </vxe-column>
                                <vxe-column
                                  field="relationship"
                                  title="続柄"
                                  width="140"
                                  :edit-render="{
                                    autofocus: '.vxe-input--inner',
                                    autoselect: true
                                  }"
                                >
                                  <template #default="{ row }">
                                    <span>{{ row.relationship }}</span>
                                  </template>
                                  <template #edit="{ row }">
                                    <vxe-input
                                      v-model="row.relationship"
                                      type="text"
                                      placeholder=""
                                      @change="checkEmptyFamilyInfo()"
                                    ></vxe-input>
                                  </template>
                                </vxe-column>
                                <vxe-column
                                  field="caregivers"
                                  title="昼間の主な保育者"
                                  width="160"
                                  :edit-render="{
                                    autofocus: '.vxe-input--inner',
                                    autoselect: true
                                  }"
                                >
                                  <template #default="{ row }">
                                    <div style="width: 100%; text-align: center">
                                      <vxe-checkbox-group
                                        v-model="row.caregivers"
                                        @change="checkEmptyFamilyInfo()"
                                      >
                                        <vxe-checkbox label="1" content=""></vxe-checkbox>
                                      </vxe-checkbox-group>
                                    </div>
                                  </template>
                                  <template #edit="{ row }">
                                    <div style="width: 100%; text-align: center">
                                      <vxe-checkbox-group
                                        v-model="row.caregivers"
                                        @change="checkEmptyFamilyInfo()"
                                      >
                                        <vxe-checkbox label="1" content=""></vxe-checkbox>
                                      </vxe-checkbox-group>
                                    </div>
                                  </template>
                                </vxe-column>
                                <vxe-column
                                  field="parenting"
                                  title="育児等で相談する人"
                                  width="170"
                                  :edit-render="{
                                    autofocus: '.vxe-input--inner',
                                    autoselect: true
                                  }"
                                >
                                  <template #default="{ row }">
                                    <div style="width: 100%; text-align: center">
                                      <vxe-checkbox-group
                                        v-model="row.parenting"
                                        @change="checkEmptyFamilyInfo()"
                                      >
                                        <vxe-checkbox label="1" content=""></vxe-checkbox>
                                      </vxe-checkbox-group>
                                    </div>
                                  </template>
                                  <template #edit="{ row }">
                                    <div style="width: 100%; text-align: center">
                                      <vxe-checkbox-group
                                        v-model="row.parenting"
                                        @change="checkEmptyFamilyInfo()"
                                      >
                                        <vxe-checkbox label="1" content=""></vxe-checkbox>
                                      </vxe-checkbox-group>
                                    </div>
                                  </template>
                                </vxe-column>
                                <vxe-column
                                  field="cooperation"
                                  title="育児への協力"
                                  width="140"
                                  :edit-render="{
                                    autofocus: '.vxe-input--inner',
                                    autoselect: true
                                  }"
                                >
                                  <template #default="{ row }">
                                    <div style="width: 100%; text-align: center">
                                      <vxe-checkbox-group
                                        v-model="row.cooperation"
                                        @change="checkEmptyFamilyInfo()"
                                      >
                                        <vxe-checkbox label="1" content=""></vxe-checkbox>
                                      </vxe-checkbox-group>
                                    </div>
                                  </template>
                                  <template #edit="{ row }">
                                    <div style="width: 100%; text-align: center">
                                      <vxe-checkbox-group
                                        v-model="row.cooperation"
                                        @change="checkEmptyFamilyInfo()"
                                      >
                                        <vxe-checkbox label="1" content=""></vxe-checkbox>
                                      </vxe-checkbox-group>
                                    </div>
                                  </template>
                                </vxe-column>
                                <vxe-column
                                  field="remarks"
                                  title="備考"
                                  :edit-render="{
                                    autofocus: '.vxe-input--inner',
                                    autoselect: true
                                  }"
                                >
                                  <template #default="{ row }">
                                    <span>{{ row.remarks }}</span>
                                  </template>
                                  <template #edit="{ row }">
                                    <div style="display: flex">
                                      <vxe-input
                                        v-model="row.remarks"
                                        type="text"
                                        placeholder=""
                                        @change="checkEmptyFamilyInfo()"
                                      ></vxe-input>
                                    </div>
                                  </template>
                                </vxe-column>
                              </vxe-table>
                            </tr>
                          </tbody>
                        </table>
                      </div>
                    </div>
                    <div class="m-l-1 flex-1480">
                      <div class="btn-l-0">
                        <a-button class="btn-round" type="primary" @click="getFamilyInfo()"
                          >住民情報取得</a-button
                        >
                      </div>
                      <div class="m-t-1 btn-l-1">
                        <a-button class="btn-round" type="primary" @click="addfamilyRows(-1)"
                          >追加</a-button
                        >
                      </div>
                      <div class="m-t-1 btn-l-1">
                        <a-button
                          type="primary"
                          class="btn-round btn-mag"
                          :disabled="!isSelectedFamilyTable"
                          @click="deletfamilyRows()"
                          >削除</a-button
                        >
                      </div>
                    </div>
                  </div>
                  <div class="m-t-1 flex flex-column-1680">
                    <div class="description-table top-table" style="width: 75%">
                      <table>
                        <tbody>
                          <tr>
                            <th style="width: 80px">ベット</th>
                            <td style="width: 290px">
                              <ai-select
                                v-model:value="familyInfo.bed"
                                style="width: 90px"
                                :options="visitOptions"
                                @change="checkEmptyFamilyInfo()"
                              ></ai-select>
                              <a-input
                                v-model:value="familyInfo.bedName"
                                style="width: 190px; margin-left: 5px"
                                show-search
                                @change="checkEmptyFamilyInfo()"
                              ></a-input>
                            </td>
                            <th style="width: 80px">園名</th>
                            <td style="width: 100px">
                              <a-input
                                v-model:value="familyInfo.gardenName"
                                style="width: 100px"
                                show-search
                                @change="checkEmptyFamilyInfo()"
                              ></a-input>
                            </td>
                            <th style="width: 80px">住居情報</th>
                            <td>
                              <ai-select
                                v-model:value="familyInfo.residential"
                                style="width: 120px"
                                :options="residentialOptions"
                                @change="checkEmptyFamilyInfo()"
                              ></ai-select>
                              <span>（</span>
                              <a-input
                                v-model:value="familyInfo.building"
                                style="width: 50px"
                                show-search
                                @change="checkEmptyFamilyInfo()"
                              ></a-input>
                              <span> 階建 </span>
                              <a-input
                                v-model:value="familyInfo.floor"
                                style="width: 50px"
                                show-search
                                @change="checkEmptyFamilyInfo()"
                              ></a-input>
                              <span>階）</span>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                    <div class="description-table btm-table" style="margin-left: -1px; width: 25%">
                      <table>
                        <tbody>
                          <tr>
                            <th style="width: 100px">騷音</th>
                            <td style="width: 150px">
                              <ai-select
                                v-model:value="familyInfo.noise"
                                style="width: 100%"
                                :options="noiseOptions"
                                @change="checkEmptyFamilyInfo()"
                              ></ai-select>
                            </td>
                            <th style="width: 100px">日当たり</th>
                            <td style="width: 150px">
                              <ai-select
                                v-model:value="familyInfo.illumination"
                                style="width: 100%"
                                :options="illuminationOptions"
                                @change="checkEmptyFamilyInfo()"
                              ></ai-select>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                  </div>
                </div>
              </a-tab-pane>
              <a-tab-pane
                key="6"
                :tab="isEmptyPregnancyHistory ? '妊娠既往歴' : '妊娠既往歴(入力あり)'"
                class="tab-1-6"
              >
                <div class="flex flex-column">
                  <div class="description-table left-table" style="width: 32%">
                    <table>
                      <tbody>
                        <tr>
                          <th rowspan="2" style="width: 100px">疾患有無</th>
                          <td>
                            <div style="height: 120px; overflow: auto">
                              <a-checkbox-group
                                v-model:value="pregnancyHistoryInfo.whetherDisease"
                                style="display: grid; margin-left: 10px; line-height: 30px"
                                name="checkboxgroup"
                                @change="checkEmptyPregnancyHistory()"
                              >
                                <a-checkbox
                                  v-for="item in diseaseList"
                                  :key="item.value"
                                  style="margin: 0"
                                  :value="item.value"
                                  >{{ item.label }}</a-checkbox
                                >
                              </a-checkbox-group>
                            </div>
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <span class="m-r-1">その他疾患</span>
                            <a-input
                              v-model:value="pregnancyHistoryInfo.otherDiseases"
                              style="width: 80%"
                              show-search
                              @change="checkEmptyPregnancyHistory()"
                            ></a-input>
                          </td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                  <div class="description-table m-l-1 right-table" style="width: 68%">
                    <table>
                      <tbody>
                        <tr>
                          <th style="width: 130px">中毒有無</th>
                          <td>
                            <ai-select
                              v-model:value="pregnancyHistoryInfo.poisoning"
                              style="width: 120px"
                              :options="visitOptions"
                              @change="checkEmptyPregnancyHistory()"
                            ></ai-select>
                          </td>
                          <th style="width: 130px">HBs抗原</th>
                          <td>
                            <ai-select
                              v-model:value="pregnancyHistoryInfo.hbs"
                              style="width: 120px"
                              :options="hbsOptions"
                              @change="checkEmptyPregnancyHistory()"
                            ></ai-select>
                          </td>
                          <th style="width: 130px">産褥期異常</th>
                          <td>
                            <ai-select
                              v-model:value="pregnancyHistoryInfo.puerperium"
                              style="width: 120px"
                              :options="visitOptions"
                              @change="checkEmptyPregnancyHistory()"
                            ></ai-select>
                          </td>
                          <th style="width: 130px">ATL</th>
                          <td>
                            <ai-select
                              v-model:value="pregnancyHistoryInfo.atl"
                              style="width: 120px"
                              :options="hbsOptions"
                              @change="checkEmptyPregnancyHistory()"
                            ></ai-select>
                          </td>
                        </tr>
                        <tr>
                          <th>妊娠高血圧症候群</th>
                          <td>
                            <ai-select
                              v-model:value="pregnancyHistoryInfo.hypertension"
                              style="width: 120px"
                              :options="hbsOptions"
                              @change="checkEmptyPregnancyHistory()"
                            ></ai-select>
                          </td>
                        </tr>
                        <tr>
                          <th>その他</th>
                          <td colspan="7">
                            <a-textarea
                              v-model:value="pregnancyHistoryInfo.others"
                              placeholder=""
                              auto-size
                              style="height: 84px; max-height: 84px; min-height: 84px"
                              @change="checkEmptyPregnancyHistory()"
                            />
                          </td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                </div>
              </a-tab-pane>
              <a-tab-pane key="7" :tab="isEmptyComplaint ? '主訴' : '主訴(入力あり)'">
                <div style="display: flex; align-items: end">
                  <div style="flex: auto">
                    <div class="description-table">
                      <table>
                        <tbody>
                          <tr>
                            <vxe-table
                              ref="complaintTable"
                              border
                              height="175px"
                              style="border: 0px"
                              show-overflow
                              :data="complaintDataSource"
                              class="mytable-scrollbar"
                              :column-config="{ resizable: true }"
                              :cell-style="vxecellStyle"
                              :edit-config="{ trigger: 'click', mode: 'cell', showStatus: false }"
                              :row-config="{ isCurrent: true, isHover: false }"
                              :mouse-config="{ selected: true }"
                              :keyboard-config="{
                                isArrow: true,
                                isEsc: true,
                                isTab: true,
                                isEdit: true,
                                enterToTab: true
                              }"
                              @cell-click="
                                () => {
                                  isSelectedComplaintTable = true
                                }
                              "
                            >
                              <vxe-column
                                field="content"
                                title="内容"
                                width="150"
                                :edit-render="{
                                  name: 'AiSelect',
                                  options: complaintOptions,
                                  events: {
                                    change: () => {
                                      checkEmptyComplaint()
                                    }
                                  }
                                }"
                              >
                              </vxe-column>
                              <vxe-column
                                field="remarks"
                                title="指導事項"
                                :edit-render="{ autofocus: '.vxe-input--inner', autoselect: true }"
                              >
                                <template #default="{ row }">
                                  <span>{{ row.remarks }}</span>
                                </template>
                                <template #edit="{ row }">
                                  <vxe-input
                                    v-model="row.remarks"
                                    type="text"
                                    placeholder=""
                                    @change="checkEmptyComplaint()"
                                  ></vxe-input>
                                </template>
                              </vxe-column>
                            </vxe-table>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                  </div>
                  <div class="m-l-1 m-r-1">
                    <a-button class="btn-round" type="primary" @click="addcomplaintRows(-1)"
                      >追加</a-button
                    ><br />
                    <a-button
                      type="primary"
                      class="m-t-1 btn-round btn-mag"
                      :disabled="!isSelectedComplaintTable"
                      @click="deleteComplaintRows()"
                      >削除</a-button
                    >
                  </div>
                </div>
              </a-tab-pane>
              <a-tab-pane
                key="8"
                :tab="isEmptyHeightAndWeight ? '身長·体重' : '身長·体重(入力あり)'"
              >
                <div class="description-table">
                  <table>
                    <tbody>
                      <tr>
                        <th style="width: 100px">身長</th>
                        <td>
                          <a-input
                            v-model:value="heightAndWeightInfo.height"
                            style="width: 100px"
                            show-search
                            @change="checkEmptyHeightAndWeight()"
                          ></a-input>
                          <span class="m-l-1">cm</span>
                        </td>
                        <th style="width: 100px">体重</th>
                        <td>
                          <span class="m-r-1">妊娠前 </span>
                          <a-input
                            v-model:value="heightAndWeightInfo.prepregnancyWeight"
                            style="width: 100px"
                            show-search
                            @change="checkEmptyHeightAndWeight()"
                          ></a-input>
                          <span class="m-l-1">kg</span>
                          <span class="m-l-1 m-r-1">分娩時 </span>
                          <a-input
                            v-model:value="heightAndWeightInfo.childbirthWeight"
                            style="width: 100px"
                            show-search
                            @change="checkEmptyHeightAndWeight()"
                          ></a-input>
                          <span class="m-l-1">kg</span>
                          <span class="m-l-2"> {{ heightAndWeightInfo.weightDifference }} kg </span>
                        </td>
                        <th style="width: 100px">BMI</th>
                        <td>
                          <a-input
                            v-model:value="heightAndWeightInfo.bmi"
                            style="width: 100px"
                            show-search
                            @change="checkEmptyHeightAndWeight()"
                          ></a-input>
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </a-tab-pane>
              <a-tab-pane
                key="9"
                :tab="isEmptyMaternalGrade ? '母親学級' : '母親学級(入力あり)'"
                class="tab-1-9"
              >
                <div style="width: 100%">
                  <a-tabs
                    v-model:activeKey="maternalGradeActiveKey"
                    type="editable-card"
                    class="highlight-tabs"
                    @edit="maternalGradeOnEdit"
                  >
                    <a-tab-pane
                      v-for="pane in maternalGradePanes"
                      :key="pane.key"
                      :tab="pane.title"
                      :closable="maternalGradePanes.length > 1"
                    >
                      <div class="flex flex-column-1480">
                        <div class="description-table left-table" style="width: 50%">
                          <table>
                            <tbody>
                              <tr>
                                <th>参加年月日</th>
                                <td colspan="3">
                                  <date-jp
                                    v-model:value="pane.joiningDate"
                                    @change="checkEmptyMaternalGrade()"
                                  ></date-jp>
                                </td>
                              </tr>
                              <tr>
                                <th>血圧</th>
                                <td colspan="3">
                                  <span class="m-l-1 m-r-1">(最高)</span>
                                  <a-input
                                    v-model:value="pane.maxHeight"
                                    style="width: 80px"
                                    show-search
                                    @change="checkEmptyMaternalGrade()"
                                  ></a-input>
                                  <span class="m-l-1 m-r-1">mmHg</span>
                                  <span class="m-l-1 m-r-1">(最低)</span>
                                  <a-input
                                    v-model:value="pane.minHeight"
                                    style="width: 80px"
                                    show-search
                                    @change="checkEmptyMaternalGrade()"
                                  ></a-input>
                                  <span class="m-l-1 m-r-1">mmHg</span>
                                </td>
                              </tr>
                              <tr>
                                <th style="width: 130px">尿検査(糖)</th>
                                <td style="width: 150px">
                                  <ai-select
                                    v-model:value="pane.sugar"
                                    style="width: 100%"
                                    :options="sugarOptions"
                                    @change="checkEmptyMaternalGrade()"
                                  ></ai-select>
                                </td>
                                <th style="width: 130px">尿検査(潜血)</th>
                                <td style="width: 150px">
                                  <ai-select
                                    v-model:value="pane.blood"
                                    style="width: 100%"
                                    :options="sugarOptions"
                                    @change="checkEmptyMaternalGrade()"
                                  ></ai-select>
                                </td>
                              </tr>
                              <tr>
                                <th style="width: 130px">尿検査(蛋白)</th>
                                <td style="width: 150px">
                                  <ai-select
                                    v-model:value="pane.protein"
                                    style="width: 100%"
                                    :options="sugarOptions"
                                    @change="checkEmptyMaternalGrade()"
                                  ></ai-select>
                                </td>
                              </tr>
                            </tbody>
                          </table>
                        </div>
                        <div class="flex right-table" style="width: 50%; margin-left: -1px">
                          <div class="description-table" style="width: 50%">
                            <table>
                              <tbody>
                                <tr>
                                  <th style="width: 100px">症状</th>
                                  <td>
                                    <div style="height: 143px; overflow: auto">
                                      <a-checkbox-group
                                        v-model:value="pane.whetherDisease"
                                        style="display: grid; margin-left: 10px; line-height: 30px"
                                        name="checkboxgroup"
                                        @change="checkEmptyMaternalGrade()"
                                      >
                                        <a-checkbox
                                          v-for="item in whetherDiseaseList"
                                          :key="item.value"
                                          style="margin: 0"
                                          :value="item.value"
                                          >{{ item.label }}</a-checkbox
                                        >
                                      </a-checkbox-group>
                                    </div>
                                  </td>
                                </tr>
                              </tbody>
                            </table>
                          </div>

                          <div class="description-table" style="width: 50%; margin-left: -1px">
                            <table>
                              <tbody>
                                <tr>
                                  <th>コメント</th>
                                  <td colspan="7">
                                    <a-textarea
                                      v-model:value="pane.remarks"
                                      style="height: 143px; min-height: 143px; max-height: 143px"
                                      placeholder=""
                                      auto-size
                                      @change="checkEmptyMaternalGrade()"
                                    />
                                  </td>
                                </tr>
                              </tbody>
                            </table>
                          </div>
                        </div>
                      </div>
                    </a-tab-pane>
                  </a-tabs>
                </div>
              </a-tab-pane>
              <a-tab-pane
                key="10"
                :tab="isEmptyTreatment ? '現在の疾病治状況' : '現在の疾病治状況(入力あり)'"
              >
                <div style="display: flex; align-items: end">
                  <div style="flex: auto">
                    <div class="description-table">
                      <table>
                        <tbody>
                          <tr>
                            <vxe-table
                              ref="treatmentTable"
                              border
                              height="175px"
                              show-overflow
                              style="border: 0px"
                              :data="treatmentDataSource"
                              class="mytable-scrollbar"
                              :column-config="{ resizable: true }"
                              :cell-style="vxecellStyle"
                              :edit-config="{ trigger: 'click', mode: 'cell', showStatus: false }"
                              :row-config="{ isCurrent: true, isHover: false }"
                              :mouse-config="{ selected: true }"
                              :keyboard-config="{
                                isArrow: true,
                                isEsc: true,
                                isTab: true,
                                isEdit: true,
                                enterToTab: true
                              }"
                              @cell-click="
                                () => {
                                  isSelectedTreatmentTable = true
                                }
                              "
                            >
                              <vxe-column
                                field="disease"
                                title="疾病名"
                                width="150"
                                :edit-render="{
                                  name: 'AiSelect',
                                  options: diseaseOptions,
                                  events: {
                                    change: () => {
                                      checkEmptyTreatment()
                                    }
                                  }
                                }"
                              >
                              </vxe-column>
                              <vxe-column
                                field="treatment"
                                title="治療"
                                width="150"
                                :edit-render="{
                                  name: 'AiSelect',
                                  options: visitOptions,
                                  events: {
                                    change: () => {
                                      checkEmptyTreatment()
                                    }
                                  }
                                }"
                              >
                              </vxe-column>
                              <vxe-column
                                field="hospitalization"
                                title="入院"
                                width="150"
                                :edit-render="{
                                  name: 'AiSelect',
                                  options: visitOptions,
                                  events: {
                                    change: () => {
                                      checkEmptyTreatment()
                                    }
                                  }
                                }"
                              >
                              </vxe-column>
                              <vxe-column
                                field="remarks"
                                title="備考"
                                :edit-render="{ autofocus: '.vxe-input--inner', autoselect: true }"
                              >
                                <template #default="{ row }">
                                  <span>{{ row.remarks }}</span>
                                </template>
                                <template #edit="{ row }">
                                  <vxe-input
                                    v-model="row.remarks"
                                    type="text"
                                    placeholder=""
                                    @change="checkEmptyTreatment()"
                                  ></vxe-input>
                                </template>
                              </vxe-column>
                            </vxe-table>
                          </tr>
                        </tbody>
                      </table>
                    </div>
                  </div>
                  <div class="m-l-1 m-r-1">
                    <a-button class="btn-round" type="primary" @click="addTreatmentRows(-1)"
                      >追加</a-button
                    ><br />
                    <a-button
                      type="primary"
                      class="m-t-1 btn-round btn-mag"
                      :disabled="!isSelectedTreatmentTable"
                      @click="deleteTreatmentRows()"
                      >削除</a-button
                    >
                  </div>
                </div>
              </a-tab-pane>
            </a-tabs>
          </a-tab-pane>
          <a-tab-pane key="2" tab="妊婦健康診査情報" force-render>
            <tab-pregnant-examination></tab-pregnant-examination>
          </a-tab-pane>
          <a-tab-pane key="3" tab="産婦健康診査情報">
            <tab-maternity-examination></tab-maternity-examination>
          </a-tab-pane>
          <a-tab-pane key="4">
            <template #tab>
              <span :class="editing ? 'input-tab' : ''">
                <edit-outlined v-if="editing" />
                支援計画
              </span>
            </template>
            <tab-support-plan @isEdit="isEdit"></tab-support-plan>
          </a-tab-pane>
          <a-tab-pane key="5" tab="その他情報">
            <tab-other-info></tab-other-info>
          </a-tab-pane>
        </a-tabs>
      </div>
    </a-card>

    <div class="page_footer_btn" :style="{ width: mainWidth }">
      <div v-if="patientShow">
        <div style="padding-bottom: 10px">
          <div class="description-table">
            <table>
              <tbody>
                <tr>
                  <th style="width: 100px">総合コメント</th>
                  <td>
                    <a-textarea
                      v-model:value="queryParams.evaluation"
                      :auto-size="{ minRows: 5, maxRows: 5 }"
                    >
                    </a-textarea>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
      <a-button type="primary" class="btn-round m-r-1 m-b-1" @click="individualInfo"
        >個人照会</a-button
      >
      <a-button type="primary" class="btn-round m-r-1 m-b-1" @click="memoShow">メモ</a-button>
      <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">問診</a-button>
      <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">連絡先</a-button>
      <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true"
        >手帳番号照会</a-button
      >
      <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true"
        >ドキュメント管理</a-button
      >
      <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">訪問指導</a-button>
      <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">健康相談</a-button>
      <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true"
        >世帯状況一覧</a-button
      >
      <a-button type="primary" class="btn-round m-r-1 m-b-1" @click="figuresShow"
        >ジェノグラム</a-button
      >
      <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">家族構成</a-button>
      <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">関係機関</a-button>
      <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">個人台帳</a-button>
      <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true">乳幼児情報</a-button>
      <a-button type="primary" class="btn-round m-r-1 m-b-1" :disabled="true"
        >総合支援情報</a-button
      >
    </div>
    <inquiry-info ref="inquiryInfoRef"></inquiry-info>
    <fathers-info ref="fathersInfoRef" @submit="handleParentsInfo"></fathers-info>
    <memo ref="memoRef"></memo>
    <figures ref="figuresRef"></figures>
    <OrganizeModal ref="organizeModalRef" @select="selectOrganize"></OrganizeModal>
  </div>
</template>

<script lang="ts" setup>
//---------------------------------------------------------------------------
//妊産婦情報管理編集
//---------------------------------------------------------------------------
import { ref, onMounted, computed, watch, nextTick } from 'vue'
import { layoutMode, sidebarOpened } from '@/store/use-site-settings'
import { VxeTableInstance } from 'vxe-table'
import { Modal } from 'ant-design-vue'
import { DownOutlined, UpOutlined, EditOutlined } from '@ant-design/icons-vue'
import tabPregnantExamination from '@/views/affect/BH/test000002/components/tab-pregnant-examination.vue'
import tabMaternityExamination from '@/views/affect/BH/test000002/components/tab-maternity-examination.vue'
import tabSupportPlan from '@/views/affect/BH/test000002/components/tab-support-plan.vue'
import tabOtherInfo from '@/views/affect/BH/test000002/components/tab-other-info.vue'
import figures from '@/views/affect/KK/figures/index.vue'
import { useRouter, useRoute } from 'vue-router'
import inquiryInfo from './inquiry-info.vue'
import fathersInfo from './fathers-info.vue'
import DateJp from '@/components/Selector/DateJp/index.vue'
import { table } from 'console'
import OrganizeModal from '@/views/affect/AF/AWAF00702D/index.vue'
import { MenuType } from '#/Enums'

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const loading = ref<boolean>(false)
const disMidselect = ref<boolean>(false)
const disabled = ref<boolean>(false)
const visible = ref<boolean>(false)
const patientShow = ref<boolean>(true)
const router = useRouter()
const route = useRoute()
const getInitData: (param: boolean) => void = async (needAllAlbel) => {
  loading.value = false
  initData()
}
const healthcareActiveKey = ref('1')
const guidancePanes = ref<
  {
    title: string
    guidance?: string
    key: string
    guidanceShow?: boolean
    guidanceDate?: string
    personcharge?: string
    personcharge2?: string
    remarks?: string
    other?: string
    index: number
  }[]
>([
  {
    title: '保健指導 1',
    key: '1',
    guidance: '',
    guidanceDate: '',
    personcharge: '',
    personcharge2: '',
    remarks: '',
    other: '',
    index: 0,
    guidanceShow: false
  }
])
const maternalGradePanes = ref<
  {
    title: string
    joiningDate?: string
    key: string
    maternalGradeShow?: boolean
    maxHeight?: string
    minHeight?: string
    sugar?: string
    blood?: string
    protein?: string
    whetherDisease?: string
    remarks?: string
    index: number
  }[]
>([
  {
    title: '母親学級 1',
    key: '1',
    joiningDate: '',
    maxHeight: '',
    minHeight: '',
    sugar: '',
    blood: '',
    protein: '',
    whetherDisease: '',
    remarks: '',
    maternalGradeShow: false,
    index: 0
  }
])
const guidanceActiveKey = ref(guidancePanes.value[0].key)
const maternalGradeActiveKey = ref(guidancePanes.value[0].key)
const isEmptyHealthcare = ref(true)
const healthcareInfo = ref({
  personCharge: '',
  personCharge2: '',
  smoking: '',
  drinking: '',
  milliliter: '',
  consultant: '',
  consultantContent: '',
  nutrition: '',
  pick: '',
  milk: '',
  milliliter2: '',
  comments: ''
})
const isEmptyWorkInfo = ref(true)
const workInfo = ref({
  work2: '',
  antenatal: '',
  postpartum: '',
  workClassification: '',
  phone: '',
  retirementDate: '',
  leave: '',
  jobContent: '',
  commutingMode: '',
  commutingTime: ''
})
const isEmptyBirthInfo = ref(true)
const isEmptyPregnancyInfo = ref(true)
const isEmptyFamilyInfo = ref(true)
const familyInfo = ref({
  bed: '',
  bedName: '',
  gardenName: '',
  residential: '',
  building: '',
  floor: '',
  noise: '',
  illumination: ''
})
const pregnancyHistoryInfo = ref({
  whetherDisease: '',
  otherDiseases: '',
  poisoning: '',
  hbs: '',
  puerperium: '',
  atl: '',
  hypertension: '',
  others: ''
})

const isEmptyPregnancyHistory = ref(true)
const isEmptyComplaint = ref(true)
const heightAndWeightInfo = ref({
  height: '',
  prepregnancyWeight: '',
  childbirthWeight: '',
  bmi: '',
  weightDifference: ''
})
const isEmptyHeightAndWeight = ref(true)
const isEmptyMaternalGrade = ref(true)
const isEmptyTreatment = ref(true)
let queryParams = ref<{
  notebookNumber1?: string
  notebookNumber2?: string
  organizationNo?: string
  kanaName?: string
  name?: string
  date?: string
  homePhone?: string
  home?: string
  bigCode?: string
  midCode?: string
  newDelivery?: string
  visit?: string
  healthcare?: string
  Promoter?: string
  notice?: string
  disability?: string
  childbirth?: string
  insurance?: string
  oneself?: string
  category?: string
  place?: string
  class?: string
  year?: string
}>({})
const maternalGradeShow = ref(false)
const whetherDiseaseList = [
  { value: 1, label: 'つわりがひどい' },
  { value: 2, label: 'むくみがある' },
  { value: 3, label: '食欲がない' },
  { value: 4, label: 'お腹がはる' },
  { value: 5, label: 'イライラしたり、愛鬱になる' },
  { value: 6, label: '立ちくらみがする' },
  { value: 7, label: '動悸がする' },
  { value: 8, label: '息切れがする' },
  { value: 9, label: '貧血がある' },
  { value: 10, label: 'その他' }
]
const sugarOptions = [
  { value: '', label: '' },
  { value: '1', label: '－' },
  { value: '2', label: '±' },
  { value: '3', label: '＋' },
  { value: '4', label: '２＋' },
  { value: '5', label: '３＋' },
  { value: '6', label: '４＋' },
  { value: '7', label: '生' },
  { value: '8', label: '未実施' }
]
const hbsOptions = [
  { value: '', label: '' },
  { value: '1', label: '陰性' },
  { value: '2', label: '陽性' },
  { value: '3', label: '実施した' },
  { value: '4', label: '実施せず' }
]
const diseaseList = [
  { value: 1, label: '貧血' },
  { value: 2, label: '心臓病' },
  { value: 3, label: '腎臓病' },
  { value: 4, label: '高血圧' },
  { value: 5, label: '糖尿病' },
  { value: 6, label: 'その他' }
]
const complaintDataSource = ref([
  {
    content: 1,
    contentName: '01 : 栄養',
    remarks: ''
  }
])
const complaintOptions = [
  { value: '', label: '' },
  { value: '01', label: '栄養' },
  { value: '02', label: '生活' },
  { value: '03', label: '運動' },
  { value: '04', label: '経済' },
  { value: '05', label: '栄養食品支給' },
  { value: '06', label: 'その他' }
]
const guidanceOptions = [
  { value: '', label: '' },
  { value: '01', label: '保健指導' },
  { value: '02', label: '栄養指導' },
  { value: '03', label: '運動指導' },
  { value: '04', label: '休養指導' },
  { value: '05', label: '飲酒指導' },
  { value: '06', label: '喫煙指導' },
  { value: '07', label: '歯科指導' },
  { value: '08', label: 'その他指導' }
]
const contentDataSource = ref<
  {
    content?: string
    contact?: string
    contentName?: string
    contactName?: string
    appointment?: string
    completion?: string
    remarks?: string
  }[]
>([])
const treatmentDataSource = ref<
  {
    disease?: string
    diseaseName?: string
    treatment?: string
    treatmentName?: string
    hospitalization?: string
    hospitalizationName?: string
    remarks?: string
  }[]
>([])
const diseaseOptions = [
  { value: '', label: '' },
  { value: '01', label: '妊娠悪阻' },
  { value: '02', label: '切迫流産' },
  { value: '03', label: '妊娠貧血' },
  { value: '04', label: '妊娠高血圧症候群' },
  { value: '05', label: '高血圧症候群' },
  { value: '06', label: '切迫早産' },
  { value: '07', label: 'その他' }
]
const birthDataSource = ref<
  {
    order?: number
    age?: number
    weight?: number
    week?: number
    delivery?: string
    deliveryName?: string
    healthStatus?: string
    healthStatusName?: string
    remarks?: string
  }[]
>([])
const pregnancyDataSource = ref<
  {
    date?: string
    division?: string
    divisionName?: string
    birthtype?: string
    birthtypeName?: string
    week?: number
    remarks?: string
  }[]
>([])
const familyDataSource = ref<
  {
    name: string //氏名
    age: string //年齢
    relationship: string //続柄
    caregivers: number //昼間の主な保育者
    parenting: number //育児等で相談する人
    cooperation: number //育児への協力
    remarks: string //備考
  }[]
>([])
const isShowFamily = ref(false)
const healthStatusOptions = []
const illuminationOptions = [
  { value: '', label: '' },
  { value: '01', label: '良' },
  { value: '02', label: '普通' },
  { value: '03', label: '悪' }
]
const noiseOptions = [
  { value: '', label: '' },
  { value: '01', label: '静' },
  { value: '02', label: '普通' },
  { value: '03', label: '騒' }
]
const residentialOptions = [
  { value: '', label: '' },
  { value: '01', label: '独立家屋' },
  { value: '02', label: '借家' },
  { value: '03', label: 'アパート' },
  { value: '04', label: 'マンション' },
  { value: '05', label: '同居' },
  { value: '06', label: '間借' },
  { value: '07', label: '県営住宅' }
]
const birthtypeOptions = [
  { value: '', label: '' },
  { value: '01', label: '自然' },
  { value: '02', label: '人工' }
]
const divisionOptions = [
  { value: '', label: '' },
  { value: '01', label: '流産' },
  { value: '02', label: '早産' },
  { value: '03', label: '死産' }
]
const contactOptions = [
  { value: '', label: '' },
  { value: '01', label: '電話' },
  { value: '02', label: '訪問' },
  { value: '03', label: '教室案内' },
  { value: '04', label: '再検査' },
  { value: '05', label: 'センター呼び出し' }
]
const contentOptions = [
  { value: '', label: '' },
  { value: '01', label: '高年初産' },
  { value: '02', label: '若年初産' },
  { value: '03', label: '多胎妊娠' },
  { value: '04', label: '精神面' },
  { value: '05', label: '身体面' },
  { value: '06', label: '経済面' },
  { value: '07', label: '喫煙' },
  { value: '08', label: '飲酒' },
  { value: '09', label: 'その他' }
]
const milkOptions = [
  { value: '', label: '' },
  { value: '01', label: '毎日飲む' },
  { value: '02', label: '時々飲む' },
  { value: '03', label: 'やめた' },
  { value: '04', label: '飲まない' }
]
const strengthenOptions = [
  { value: '', label: '' },
  { value: '01', label: '非該当' },
  { value: '02', label: '該当(非課税世帯)' },
  { value: '03', label: '該当(医師判断)' },
  { value: '04', label: '該当(その他)' }
]
const drinkingOptions = [
  { value: '', label: '' },
  { value: '01', label: 'ビール' },
  { value: '02', label: '焼酎' },
  { value: '03', label: 'ウイスキー' },
  { value: '04', label: 'ワイン' },
  { value: '05', label: 'その他' }
]
const commutingOptions = [
  { value: '', label: '' },
  { value: '01', label: '徒歩' },
  { value: '02', label: '自転車' },
  { value: '03', label: 'バイク' },
  { value: '04', label: '自動車' },
  { value: '05', label: 'バス' },
  { value: '06', label: '電車' },
  { value: '07', label: '船' },
  { value: '08', label: 'その他' }
]
const workOptions = [
  { value: '', label: ' ' },
  { value: '01', label: '常勤' },
  { value: '02', label: '非常勤' },
  { value: '03', label: 'アルバイト' },
  { value: '04', label: '自営業手伝い' }
]
const placeOptions = [
  { value: '', label: ' ' },
  { value: '01', label: '場所１' }
]
const categoryOptions = [
  { value: '', label: ' ' },
  { value: '01', label: '町外' },
  { value: '02', label: '代理人' },
  { value: '03', label: '外国人' },
  { value: '04', label: '未婚' },
  { value: '05', label: '産後' },
  { value: '06', label: '再発行' }
]
const insuranceOptions = [
  { value: '', label: ' ' },
  { value: '01', label: '国保' },
  { value: '02', label: '国保（市町村）' },
  { value: '03', label: '社保' },
  { value: '04', label: '社保（政府）' },
  { value: '05', label: '船保' }
]
const healthcareOptions = [
  { value: '', label: '' },
  { value: '000001', label: '佐伯　花子' },
  { value: '001005', label: '佐藤　花' }
]
const visitOptions = [
  { value: '', label: ' ' },
  { value: '1', label: 'なし' },
  { value: '2', label: 'あり' }
]

const parentsInfo = ref<
  { kind?: string; num?: string; name?: string; kannaName?: string; date?: string; age?: string }[]
>([{ kind: '1' }, { kind: '2' }])

const complaintTable = ref()
const treatmentTable = ref()
const familyTable = ref()
const birthTable = ref()
const pregnancyDataTable = ref()
const fathersInfoRef = ref()
const organizeModalRef = ref()
const editing = ref(false)
const newGuidanceTabIndex = ref(0)
const newMaternalGradeTabIndex = ref(0)
const figuresRef = ref()
const xTable = ref<VxeTableInstance>()
const mode = ref('default') // default list edit
const inquiryInfoRef = ref()
const memoRef = ref()
const isSelectedHealthCareTable = ref(false)
const isSelectedBirthTable = ref(false)
const isSelectedPregnancyTable = ref(false)
const isSelectedFamilyTable = ref(false)
const isSelectedComplaintTable = ref(false)
const isSelectedTreatmentTable = ref(false)

//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
watch(healthcareInfo.value, (val) => {
  checkEmptyHealthcare()
})

watch(guidancePanes.value, (val) => {
  checkEmptyHealthcare()
})

watch(workInfo.value, (val) => {
  checkEmptyWorkInfo()
})

//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  getInitData(true)
  disabled.value = true
  disMidselect.value = true
  nextTick(() => {
    // checkEmptyBirthInfo()
    // checkEmptyComplaint()
    // checkEmptyFamilyInfo()
    checkEmptyHealthcare()
    if (route.query?.code !== '') {
      isEmptyBirthInfo.value = false
      isEmptyPregnancyInfo.value = false
      isEmptyTreatment.value = false
    } else {
      fathersInfoRef.value.open()
      Modal.warn({
        title: '情报',
        content: '新規の場合、まず妊婦・父親情報を入力してください。',
        zIndex: 99999,
        centered: true
      })
    }
    // checkEmptyHeightAndWeight()
    // checkEmptyMaternalGrade()
    // checkEmptyPregnancyHistory()
    // checkEmptyPregnancyInfo()
    // checkEmptyTreatment()
    // checkEmptyWorkInfo()
  })
})

const mainWidth = computed(() => {
  let w = 0
  if (layoutMode.value === MenuType.Side) {
    if (sidebarOpened.value) {
      w = 'calc(100% - ' + 276 + 'px)'
    } else {
      w = 'calc(100% - ' + 100 + 'px)'
    }
  } else {
    w = 'calc(100% - ' + 20 + 'px)'
  }
  return w
})
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const deleteRows = () => {
  Modal.confirm({
    title: '確認',
    content: '削除しますか？',
    okText: 'は い',
    cancelText: 'いいえ',
    okButtonProps: {
      danger: true
    },
    onOk() {
      xTable.value.removeCurrentRow()
      isSelectedHealthCareTable.value = false
      checkEmptyHealthcare()
    }
  })
}
const addRows = async (row: any) => {
  const $table = xTable.value
  const record = {}
  const { row: newRow } = await $table.insertAt(record, row)
  await $table.setEditCell(newRow, 'name')
}
const deleteBirthRows = () => {
  Modal.confirm({
    title: '確認',
    content: '削除しますか？',
    okText: 'は い',
    cancelText: 'いいえ',
    okButtonProps: {
      danger: true
    },
    onOk() {
      birthTable.value.removeCurrentRow()
      isSelectedBirthTable.value = false
      checkEmptyBirthInfo()
    }
  })
}
const addBirthRows = async (row: any) => {
  const $table = birthTable.value
  const record = {}
  const { row: newRow } = await $table.insertAt(record, row)
  await $table.setEditCell(newRow, 'name')
}
const deletepregnancyRows = () => {
  Modal.confirm({
    title: '確認',
    content: '削除しますか？',
    okText: 'は い',
    cancelText: 'いいえ',
    okButtonProps: {
      danger: true
    },
    onOk() {
      pregnancyDataTable.value.removeCurrentRow()

      isSelectedPregnancyTable.value = false
      checkEmptyPregnancyInfo()
    }
  })
}
const addPregnancyRows = async (row: any) => {
  const $table = pregnancyDataTable.value
  const record = {}
  const { row: newRow } = await $table.insertAt(record, row)
  await $table.setEditCell(newRow, 'name')
}
const deletfamilyRows = () => {
  if (isShowFamily.value) {
    Modal.confirm({
      title: '確認',
      content: '削除しますか？',
      okText: 'は い',
      cancelText: 'いいえ',
      okButtonProps: {
        danger: true
      },
      onOk() {
        familyTable.value.removeCurrentRow()

        isSelectedFamilyTable.value = false
        checkEmptyFamilyInfo()
      }
    })
  }
}
const addfamilyRows = async (row: any) => {
  if (isShowFamily.value) {
    const $table = familyTable.value
    const record = {}
    const { row: newRow } = await $table.insertAt(record, row)
    await $table.setEditCell(newRow, 'name')
  }
}
const deleteTreatmentRows = () => {
  Modal.confirm({
    title: '確認',
    content: '削除しますか？',
    okText: 'は い',
    cancelText: 'いいえ',
    okButtonProps: {
      danger: true
    },
    onOk() {
      treatmentTable.value.removeCurrentRow()

      isSelectedTreatmentTable.value = false
      checkEmptyTreatment()
    }
  })
}
const addTreatmentRows = async (row: any) => {
  const $table = treatmentTable.value
  const record = {}
  const { row: newRow } = await $table.insertAt(record, row)
  await $table.setEditCell(newRow, 'name')
}
const deleteComplaintRows = () => {
  Modal.confirm({
    title: '確認',
    content: '削除しますか？',
    okText: 'は い',
    cancelText: 'いいえ',
    okButtonProps: {
      danger: true
    },
    onOk() {
      complaintTable.value.removeCurrentRow()
      isSelectedComplaintTable.value = false
      checkEmptyComplaint()
    }
  })
}
const addcomplaintRows = async (row: any) => {
  const $table = complaintTable.value
  const record = {}
  const { row: newRow } = await $table.insertAt(record, row)
  await $table.setEditCell(newRow, 'name')
}
const openModal = (val) => {
  visible.value = true
  mode.value = 'edit'
}

const handleCancel = () => {
  // Modal.confirm({
  //   title: '確認',
  //   content: '検索ページに戻りますか？',
  //   okText: 'は い',
  //   cancelText: 'いいえ',
  //   onOk: async () => {
  //     loading.value = true
  //     router.push({ path: '/mock/BH_kosin_ninsanpu' })
  //   }
  // })
  loading.value = true
  router.push({ path: 'test000002' })
}

const editRowEvent = (type, row) => {
  fathersInfoRef.value.open(type, row)
}

const vxecellStyle = ({ row, column, columnIndex }) => {
  let rowstyle = {
    background: '',
    borderRight: '',
    borderBottom: ''
  }
  let flag =
    (column.title == '個人番号' && columnIndex == '2') ||
    (column.title == '接種年月日' && columnIndex == '9') ||
    (column.title == 'Lot No' && columnIndex == '10') ||
    (column.title == '製造者CD' && columnIndex == '11') ||
    (column.title == '医療機関CD' && columnIndex == '13') ||
    (column.title == '接種形態CD' && columnIndex == '15') ||
    (column.title == '接種量' && columnIndex == '17') ||
    (column.title == '受理年月日' && columnIndex == '18') ||
    (column.title == '接種医師CD' && columnIndex == '19') ||
    (column.title == '予診医師CD' && columnIndex == '21')
  if (flag) {
    rowstyle.background = '#ecf5ff'
    rowstyle.borderRight = '1px solid #e8eaec'
    rowstyle.borderBottom = '1px solid #e8eaec'
  }
  return rowstyle
}
//個人情報Show
const individualInfo = () => {
  inquiryInfoRef.value.open()
}

const memoShow = () => {
  memoRef.value.open()
}

const figuresShow = () => {
  figuresRef.value.open()
}
const maternalGradeOnEdit = (targetKey: string | MouseEvent, action: string) => {
  if (action === 'add') {
    addMaternalGrade()
  } else {
    removeMaternalGrade(targetKey as string)
  }
}
const removeMaternalGrade = (targetKey: string) => {
  Modal.confirm({
    title: '確認',
    content: '削除しますか？',
    okText: 'は い',
    cancelText: 'いいえ',
    okButtonProps: {
      danger: true
    },
    onOk() {
      let lastIndex = 0
      maternalGradePanes.value.forEach((pane, i) => {
        if (pane.key === targetKey) {
          lastIndex = i - 1
        }
      })
      maternalGradePanes.value = maternalGradePanes.value.filter((pane) => pane.key !== targetKey)
      if (maternalGradePanes.value.length && maternalGradeActiveKey.value === targetKey) {
        if (lastIndex >= 0) {
          maternalGradeActiveKey.value = maternalGradePanes.value[lastIndex].key
        } else {
          maternalGradeActiveKey.value = maternalGradePanes.value[0].key
        }
      }
      checkEmptyMaternalGrade()
    },
    onCancel() {
      console.log('Cancel')
    }
  })
}

const addMaternalGrade = () => {
  Modal.confirm({
    title: '確認',
    content: '追加しますか？',
    okText: 'はい',
    cancelText: 'いいえ',
    onOk() {
      maternalGradeActiveKey.value = `newTab${++newMaternalGradeTabIndex.value}`
      let index = maternalGradePanes.value.length + 1
      maternalGradePanes.value.push({
        title: '母親学級 ' + index,
        key: maternalGradeActiveKey.value,
        joiningDate: '',
        maxHeight: '',
        minHeight: '',
        sugar: '',
        blood: '',
        protein: '',
        whetherDisease: '',
        remarks: '',
        maternalGradeShow: false,
        index: 0
      })
    },
    onCancel() {
      console.log('Cancel')
    }
  })
}
const guidanceOnEdit = (targetKey: string | MouseEvent, action: string) => {
  if (action === 'add') {
    addGuidance()
  } else {
    removeGuidance(targetKey as string)
  }
}
const removeGuidance = (targetKey: string) => {
  Modal.confirm({
    title: '確認',
    content: '削除しますか？',
    okText: 'は い',
    cancelText: 'いいえ',
    okButtonProps: {
      danger: true
    },
    onOk() {
      let lastIndex = 0
      guidancePanes.value.forEach((pane, i) => {
        if (pane.key === targetKey) {
          lastIndex = i - 1
        }
      })
      guidancePanes.value = guidancePanes.value.filter((pane) => pane.key !== targetKey)
      if (guidancePanes.value.length && guidanceActiveKey.value === targetKey) {
        if (lastIndex >= 0) {
          guidanceActiveKey.value = guidancePanes.value[lastIndex].key
        } else {
          guidanceActiveKey.value = guidancePanes.value[0].key
        }
      }
      checkEmptyHealthcare()
    },
    onCancel() {
      console.log('Cancel')
    }
  })
}

const addGuidance = () => {
  Modal.confirm({
    title: '確認',
    content: '追加しますか？',
    okText: 'は い',
    cancelText: 'いいえ',
    onOk() {
      guidanceActiveKey.value = `newTab${++newGuidanceTabIndex.value}`
      let index = guidancePanes.value.length + 1
      guidancePanes.value.push({
        title: '保健指導 ' + index,
        key: guidanceActiveKey.value,
        guidance: '',
        guidanceDate: '',
        personcharge: '',
        personcharge2: '',
        remarks: '',
        other: '',
        index: 0,
        guidanceShow: false
      })
    },
    onCancel() {
      console.log('Cancel')
    }
  })
}

const isEdit = (val) => {
  if (val == '1' || val == '2' || val == '3') {
    editing.value = true
  } else {
    editing.value = false
  }
}

const onSearchOrganization = () => {
  organizeModalRef.value.openModal()
}
const selectOrganize = (val: any) => {
  queryParams.value.address = val.kikannm
}
const deleteData = async () => {
  Modal.confirm({
    title: '削除確認',
    content: '削除しますか？',
    okText: 'は い',
    cancelText: 'いいえ',
    okButtonProps: {
      danger: true
    },
    onOk: async () => {
      loading.value = true
      router.push({
        path: 'test000002'
      })
    }
  })
}
const saveData = () => {
  Modal.confirm({
    title: '情報',
    content: '登録処理を行います。よろしいですか？',
    okText: 'は い',
    cancelText: 'いいえ',
    onOk: async () => {
      loading.value = true
      router.push({
        path: 'test000002'
      })
    }
  })
}

//フォームデータの取得
const getTableData = (table, tableSource) => {
  let uploadData = JSON.parse(JSON.stringify(tableSource))
  let indexArray: any = []
  const removeRecords: any = table?.getRemoveRecords()
  const insertRecords: any = table?.getInsertRecords()
  //削除されたデータ処理
  if (removeRecords && removeRecords.length > 0) {
    removeRecords.map((remove: any, index: any) => {
      indexArray.push(index)
    })
    indexArray.forEach((item: any) => {
      const deleteIndex = uploadData.findIndex((i: any) => {
        return i.hanyocd === item
      })
      uploadData.splice(deleteIndex, 1)
    })
  }
  //新規データ処理
  if (insertRecords && insertRecords.length > 0) {
    uploadData = uploadData.concat(insertRecords.reverse())
  }
  return uploadData
}

//共通検証フォーム、エンティティがNULLであるかどうか
const checkEmptyTableInfo = (info, tableName?, dataSource?, isEmptyTableData?) => {
  let isEmpty = true
  if (info) {
    Object.keys(info).some((item) => {
      if (
        typeof (info[item] && info[item].trim) === 'function'
          ? info[item] && info[item].trim().replaceAll(':', '')
          : info[item]?.constructor === Array
          ? info[item].length > 0
          : info[item]
      ) {
        isEmpty = false
        return
      }
    })
  }
  if (tableName && dataSource) {
    const tableData = getTableData(tableName, dataSource)
    tableData.some((data) => {
      Object.keys(data).some((d) => {
        if (d != 'id' && d != '_X_ROW_KEY' && d.indexOf('Name') < 0) {
          if (
            typeof (data[d] && data[d].trim) === 'function'
              ? data[d] && data[d].trim().replaceAll(':', '')
              : data[d]?.constructor === Array
              ? data[d].length > 0
              : data[d]
          ) {
            isEmpty = false
            return
          }
        }
      })
    })
  }
  return isEmpty
}

//検証保健指導情報がNULLです
const checkEmptyHealthcare = () => {
  let isEmpty = true
  isEmpty = checkEmptyTableInfo(healthcareInfo.value, xTable.value, contentDataSource.value)
  guidancePanes.value.some((guidance) => {
    Object.keys(guidance).some((g) => {
      if (g != 'title' && g != 'key' && g != 'index' && g != 'guidanceShow') {
        if (
          typeof (guidance[g] && guidance[g].trim) === 'function'
            ? guidance[g] && guidance[g].trim().replaceAll(':', '')
            : guidance[g] && guidance[g]
        ) {
          isEmpty = false
          return
        }
      }
    })
  })
  isEmptyHealthcare.value = isEmpty
  return isEmpty
}

//検証就労状況情報がNULLです
const checkEmptyWorkInfo = () => {
  let isEmpty = checkEmptyTableInfo(workInfo.value)
  isEmptyWorkInfo.value = isEmpty
}

//検証出生歴情報がNULLです
const checkEmptyBirthInfo = () => {
  let isEmpty = checkEmptyTableInfo(null, birthTable.value, birthDataSource.value)
  isEmptyBirthInfo.value = isEmpty
}

//検証妊娠歴情報がNULLです
const checkEmptyPregnancyInfo = () => {
  let isEmpty = checkEmptyTableInfo(null, pregnancyDataTable.value, pregnancyDataSource.value)
  isEmptyPregnancyInfo.value = isEmpty
}

//検証家族環境・同居の家族情報がNULLです
const checkEmptyFamilyInfo = () => {
  let isEmpty = checkEmptyTableInfo(familyInfo.value, familyTable.value, familyDataSource.value)
  isEmptyFamilyInfo.value = isEmpty
}

//検証妊娠既往歴情報がNULLです
const checkEmptyPregnancyHistory = () => {
  let isEmpty = checkEmptyTableInfo(pregnancyHistoryInfo.value)
  isEmptyPregnancyHistory.value = isEmpty
}

//検証主訴情報がNULLです
const checkEmptyComplaint = () => {
  let isEmpty = checkEmptyTableInfo(null, complaintTable.value, complaintDataSource.value)
  isEmptyComplaint.value = isEmpty
}

//検証身長·体重情報がNULLです
const checkEmptyHeightAndWeight = () => {
  let isEmpty = checkEmptyTableInfo(heightAndWeightInfo.value)
  isEmptyHeightAndWeight.value = isEmpty
}

//検証母親学級情報がNULLです
const checkEmptyMaternalGrade = () => {
  let isEmpty = true
  maternalGradePanes.value.some((maternalGrade) => {
    Object.keys(maternalGrade).some((m) => {
      if (m != 'title' && m != 'key' && m != 'index' && m != 'guidanceShow') {
        if (
          typeof (maternalGrade[m] && maternalGrade[m].trim) === 'function'
            ? maternalGrade[m] && maternalGrade[m].trim().replaceAll(':', '')
            : maternalGrade[m]?.constructor === Array
            ? maternalGrade[m].length > 0
            : maternalGrade[m]
        ) {
          isEmpty = false
          return
        }
      }
    })
  })
  isEmptyMaternalGrade.value = isEmpty
}

//検証現在の疾病治状況情報がNULLです
const checkEmptyTreatment = () => {
  let isEmpty = checkEmptyTableInfo(null, treatmentTable.value, treatmentDataSource.value)
  isEmptyTreatment.value = isEmpty
}

const getFamilyInfo = () => {
  Modal.confirm({
    title: '住民情報',
    content: '住民情報を開くかどうか？',
    okText: 'は い',
    cancelText: 'いいえ',
    onOk: async () => {
      isShowFamily.value = true
      familyDataSource.value = [
        {
          name: '', //氏名
          age: '', //年齢
          relationship: '', //続柄
          caregivers: 0, //昼間の主な保育者
          parenting: 0, //育児等で相談する人
          cooperation: 0, //育児への協力
          remarks: '' //備考
        }
      ]
    }
  })
}

const initData = () => {
  if (route.query?.code !== '') {
    contentDataSource.value = [
      {
        content: '01',
        contact: '01',
        contentName: '01 : 高年初産',
        contactName: '01 : 電話',
        appointment: '',
        completion: '',
        remarks: 'テスト'
      },
      {
        content: '02',
        contact: '02',
        contentName: '02 : 若年初産',
        contactName: '02 : 訪問',
        appointment: '',
        completion: '',
        remarks: 'テスト'
      },
      {
        content: '03',
        contact: '03',
        contentName: '03 : 多胎妊娠',
        contactName: '03 : 教室案内',
        appointment: '',
        completion: '',
        remarks: 'テスト'
      },
      {
        content: '04',
        contact: '04',
        contentName: '04 : 精神面',
        contactName: '04 : 再検査',
        appointment: '',
        completion: '',
        remarks: 'テスト'
      },
      {
        content: '05',
        contact: '03',
        contentName: '05 : 身体面',
        contactName: '03 : 教室案内',
        appointment: '',
        completion: '',
        remarks: 'テスト'
      }
    ]
    birthDataSource.value = [
      {
        order: 1,
        age: 29,
        weight: 15,
        week: 9,
        delivery: undefined,
        deliveryName: '',
        healthStatus: undefined,
        healthStatusName: '',
        remarks: ''
      }
    ]
    pregnancyDataSource.value = [
      {
        date: '',
        division: '01',
        divisionName: '01 : 流産',
        birthtype: '01',
        birthtypeName: '01 : 自然',
        week: 9,
        remarks: ''
      }
    ]
    treatmentDataSource.value = [
      {
        disease: '01',
        diseaseName: '01 : 妊娠悪阻',
        treatment: '1',
        treatmentName: '1 : なし',
        hospitalization: '1',
        hospitalizationName: '1 : なし',
        remarks: ''
      }
    ]
    queryParams.value = {
      notebookNumber1: '137',
      notebookNumber2: '1',
      organizationNo: '00000085959',
      kanaName: 'カナザワアキヨ',
      name: '金澤 安代',
      date: '昭和48年08月20日',
      homePhone: '152154213215',
      home: '○○区△△△1丁目2番3号口口ロロピル111号室',
      bigCode: '',
      midCode: '',
      newDelivery: undefined,
      visit: undefined,
      healthcare: undefined,
      Promoter: undefined,
      notice: undefined,
      disability: undefined,
      childbirth: undefined,
      insurance: undefined,
      oneself: undefined,
      category: undefined,
      place: undefined,
      class: '住民',
      year: '令和04年度'
    }
    parentsInfo.value = [
      {
        kind: '1',
        num: '00000003830',
        name: '金森 亜湖',
        date: '昭和48年08月20日',
        age: '49歳'
      },
      {
        kind: '2',
        num: '00000084793',
        name: '金森 倖也',
        date: '昭和50年01月22日',
        age: '47歳'
      }
    ]
  }
}

const handleParentsInfo = (info) => {
  if (info.organizationNo2) {
    parentsInfo.value[0] = {
      kind: '1',
      num: info.organizationNo2,
      name: info.name,
      date: info.date,
      age: '49歳'
    }
  }
  if (info.organizationNo3) {
    parentsInfo.value[1] = {
      kind: '2',
      num: info.organizationNo3,
      name: info.name2,
      date: info.date2,
      age: '49歳'
    }
  }
}
</script>

<style lang="less" scoped>
.header-description-table th {
  height: 36.5px !important;
}
.header-description-table td {
  height: 36.5px !important;
}
.mask-height {
  height: calc(100vh - 304px);
}
.guidanceBgcolor {
  background-color: #e6f7ff;
}
.guidance {
  margin-top: -1px;
}
.ant-table-striped :deep(.table-striped) td {
  background-color: #fafafa;
}
.btn-mag {
  margin: 0;
}
/deep/ .ant-table-thead > tr > th {
  text-align: center !important;
}
/deep/ .ant-collapse {
  border: 1px solid #606266 !important;
}
/deep/ .tables .ant-table-cell-scrollbar {
  display: none !important;
}
/deep/ .ant-table-container {
  border: 1px solid #606266 !important;
}
/deep/ .ant-select-single .ant-select-selector .ant-select-selection-item {
  color: #111111 !important;
}
/deep/
  .ant-select-show-search.ant-select:not(.ant-select-customize-input)
  .ant-select-selector
  input {
  color: #111111 !important;
}
.left-full-width {
  @media screen and (max-width: 1760px) {
    width: atuo !important;
    //     margin-right: 0 !important;
  }
}

.right-full-width {
  @media screen and (max-width: 1760px) {
    width: 196px !important;
    margin-left: 0px !important;
    margin-top: 10px;
    flex: 1 0 196px !important;
    min-width: 196px !important;
  }
  @media screen and (max-width: 1860px) {
    width: 100% !important;
    margin-left: 0px !important;
    margin-top: 10px;
  }
}
.right-textarea-width {
  @media screen and (max-width: 1760px) {
    min-width: 174px !important;
  }
  @media screen and (max-width: 1860px) {
    min-width: 174px !important;
  }
}
.row-border-bottom {
  // border-top: 1px solid #606266;
  @media screen and (max-width: 1560px) {
    border-bottom: 1px solid #606266 !important;
  }
  @media screen and (max-width: 1720px) and (min-width: 1570px) {
    border-bottom: none !important;
  }
}

.page_footer_btn {
  position: fixed;
  bottom: 0;
  width: 100%;
  z-index: 999;
  background-color: #ffffff;
  padding: 10px;
}
</style>
