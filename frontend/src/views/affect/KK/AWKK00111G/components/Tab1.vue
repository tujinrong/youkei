<template>
  <div>
    <div class="flex justify-between mb-1">
      <div class="text-lg font-bold">住登外者情報</div>
      <a-space>
        <SimplePagination
          :current="current"
          :count="count"
          :disabled="ido"
          @change="changeCurrent"
        />
        <a-button type="primary" :disabled="ido" @click="visible_112 = true">履歴照会</a-button>
      </a-space>
    </div>
    <div class="p-1">
      <div class="self_adaption_table mb-2">
        <a-row>
          <a-col span="6">
            <th>履歴番号</th>
            <TD>{{ formData.rirekino || '' }}</TD>
          </a-col>
          <a-col span="6">
            <th>更新日時</th>
            <TD>{{ formData.upddttm ? getDateHmsJpText(new Date(formData.upddttm)) : '' }}</TD>
          </a-col>
          <a-col span="6">
            <th>最新</th>
            <TD>{{ formData.saisin }}</TD>
          </a-col>
          <a-col span="6">
            <th>削除</th>
            <TD>{{ formData.stop }}</TD>
          </a-col>
        </a-row>
      </div>
      <div :class="[canEdit && 'form', 'self_adaption_table mb-2']">
        <div class="font-bold">異動情報</div>
        <a-row>
          <a-col span="12">
            <th class="required">異動年月日</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.idoymd">
                <DateJp
                  v-model:value="formData.idoymd"
                  unknown
                  style="width: 190px"
                  format="YYYY-MM-DD"
                  @emit-unknown-date="(v) => (formData.idoymd = v)"
                />
              </a-form-item>
            </td>
            <TD v-else>{{ getUnKnownDateJpText(formData.idoymd ?? '') }}</TD>
          </a-col>
          <a-col span="12">
            <th style="width: 130px" class="required">異動届出年月日</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.idotodokeymd">
                <DateJp
                  v-model:value="formData.idotodokeymd"
                  unknown
                  style="width: 190px"
                  format="YYYY-MM-DD"
                  @emit-unknown-date="(v) => (formData.idotodokeymd = v)"
                />
              </a-form-item>
            </td>
            <TD v-else>{{ getUnKnownDateJpText(formData.idotodokeymd ?? '') }}</TD>
          </a-col>
          <a-col span="24">
            <th class="required">異動事由</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.idojiyu">
                <ai-select v-model:value="formData.idojiyu" :options="initData.selectorlist1" />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.idojiyu }}</TD>
          </a-col>
        </a-row>
      </div>
      <div :class="[canEdit && 'form', 'self_adaption_table mb-2']">
        <div class="font-bold">基本情報（世帯）</div>
        <a-row>
          <a-col :md="24" :xl="12">
            <th class="required">世帯番号</th>
            <td v-if="canEdit" class="flex items-center">
              <a-radio-group v-model:value="auto_setaino" :options="['手動', '自動']" />
              <a-form-item v-bind="validateInfos.setaino">
                <a-input
                  v-model:value="formData.setaino"
                  class="flex-1"
                  maxlength="15"
                  :disabled="auto_setaino === '自動'"
                  @change="formData.setaino = replaceText(formData.setaino, EnumRegex.半角英数)"
                />
              </a-form-item>
              <a-button
                type="primary"
                :disabled="auto_setaino === '自動'"
                @click="visible_setai = true"
                >世帯検索</a-button
              >
            </td>
            <TD v-else>{{ formData.setaino }}</TD>
          </a-col>
          <a-col :md="24" :xl="12">
            <th class="bg-readonly" style="width: 180px">世帯主名</th>
            <TD>{{ formData.senusinm }}</TD>
          </a-col>
          <a-col span="12">
            <th>郵便番号</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.adrs_yubin">
                <PostCode v-model:value="formData.adrs_yubin">
                  <a-button type="primary" :loading="autoLoading" @click="autoInput"
                    >自動入力</a-button
                  >
                </PostCode>
              </a-form-item>
            </td>
            <TD v-else>{{ formatYubin(formData.adrs_yubin) }}</TD>
          </a-col>
          <a-col span="12">
            <th style="width: 180px">指定都市_行政区等</th>
            <td v-if="canEdit">
              <ai-select
                v-model:value="formData.tosi_gyoseikucd"
                :options="initData.selectorlist2"
              />
            </td>
            <TD v-else>{{ formData.tosi_gyoseikucd }}</TD>
          </a-col>
          <a-col span="24">
            <th>住所</th>
            <th class="flex-1">市区町村</th>
            <th class="flex-1">町字</th>
            <th class="flex-1 br-grey">番地号表記</th>
          </a-col>
          <a-col span="24">
            <th style="border-top: none" class="br-grey">　</th>
            <td v-if="canEdit">
              <ai-select
                v-model:value="formData.adrs_sikucd"
                :options="options"
                @change="changeSiku"
              />
            </td>
            <TD v-else>{{ formData.adrs_sikucd }}</TD>
            <td v-if="canEdit">
              <ai-select
                v-model:value="formData.adrs_tyoazacd"
                :options="keyoptions"
                @change="changeTyoaza"
              />
            </td>
            <TD v-else>{{ formData.adrs_tyoazacd }}</TD>
            <td v-if="canEdit">
              <a-input v-model:value="formData.adrs_bantihyoki" />
            </td>
            <TD v-else>{{ formData.adrs_bantihyoki }}</TD>
          </a-col>
          <a-col span="24">
            <th style="border-top: none" class="br-grey">　</th>
            <td class="p-0! b-t-none!">
              <a-row>
                <a-col span="8">
                  <td class="bg-disabled grid grid-cols-2">
                    <span class="px-3 ellipsis">{{ formData.adrs_todofuken || '都道府県' }}</span>
                    <span class="px-3 ellipsis" style="border-left: 1px solid #606266">{{
                      formData.adrs_sikunm || '市区町村名'
                    }}</span>
                  </td>
                </a-col>
                <a-col span="8">
                  <td v-if="(formData.adrs_tyoazacd ?? '').split(' : ')[0] === '9999999'">
                    <a-input v-model:value="formData.adrs_tyoaza" />
                  </td>
                  <TD v-else class="bg-disabled">{{ formData.adrs_tyoaza || '町字名' }}</TD>
                </a-col>
                <a-col span="8"><TD class="bg-disabled"></TD></a-col>
              </a-row>
            </td>
          </a-col>
          <a-col span="24">
            <th>方書</th>
            <th>（フリガナ）</th>
            <td v-if="canEdit">
              <a-input v-model:value="formData.adrs_katagaki_kana" />
            </td>
            <TD v-else>{{ formData.adrs_katagaki_kana }}</TD>
          </a-col>
          <a-col span="24">
            <th style="border-top: none"></th>
            <th>（漢字）</th>
            <td v-if="canEdit">
              <a-input v-model:value="formData.adrs_katagaki" />
            </td>
            <TD v-else>{{ formData.adrs_katagaki }}</TD>
          </a-col>
        </a-row>
      </div>
      <div :class="[canEdit && 'form', 'self_adaption_table mb-2']">
        <div class="font-bold">基本情報（個人）</div>
        <a-row>
          <a-col span="8">
            <th :class="{ required: !atenano, 'bg-readonly': atenano }">宛名番号</th>
            <td v-if="!atenano" class="flex items-center">
              <a-radio-group v-model:value="auto_atenano" :options="['手動', '自動']" />
              <a-form-item v-bind="validateInfos.atenano">
                <a-input
                  v-model:value="formData.atenano"
                  class="flex-1"
                  :maxlength="ss.get(ATENANO_LEN)"
                  :disabled="auto_atenano === '自動'"
                />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.atenano }}</TD>
          </a-col>
          <a-col v-if="personalnoflg" span="16">
            <th :class="{ 'bg-readonly': atenano && !psnoEditing }">個人番号</th>
            <td v-if="!atenano || psnoEditing">
              <a-input v-model:value="formData.personalno" />
            </td>
            <TD v-else>{{ formData.personalno }}</TD>
            <a-space class="ml-2">
              <a-button
                type="primary"
                :loading="psnoLoading"
                :disabled="!canEdit || !formData.atenano"
                @click="searchPersonal"
                >最新表示</a-button
              >
              <a-button
                type="primary"
                :disabled="!canEdit || !formData.atenano"
                @click="visible_113 = true"
                >履歴表示</a-button
              >
              <a-button type="primary" :disabled="!canEdit" @click="psnoEditing = true"
                >編集</a-button
              >
            </a-space>
          </a-col>
        </a-row>
        <a-row>
          <a-col span="8">
            <th class="required">住登外者種別</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.jutogaisyasyubetu">
                <ai-select
                  v-model:value="formData.jutogaisyasyubetu"
                  :options="initData.selectorlist5"
                />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.jutogaisyasyubetu }}</TD>
          </a-col>
          <a-col span="8">
            <th class="required">住登外者状態</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.jutogaisyajotai">
                <ai-select
                  v-model:value="formData.jutogaisyajotai"
                  :options="initData.selectorlist6"
                />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.jutogaisyajotai }}</TD>
          </a-col>
          <a-col span="8">
            <th class="bg-readonly">住民区分</th>
            <TD>{{ formData.juminkbn }}</TD>
          </a-col>
          <template
            v-if="splitCode(formData.jutogaisyasyubetu) === String(Enum住民種別.日本人住民)"
          >
            <a-col span="24">
              <th>
                <span>氏名</span>
              </th>
              <th>（フリガナ）</th>
              <td v-if="canEdit">
                <a-input
                  v-model:value="formData.si_kana"
                  placeholder="シ"
                  maxlength="50"
                  @change="formData.si_kana = replaceText(formData.si_kana, EnumRegex.カナ)"
                />
              </td>
              <TD v-else>{{ formData.si_kana }}</TD>
              <td v-if="canEdit">
                <a-input
                  v-model:value="formData.mei_kana"
                  placeholder="メイ"
                  maxlength="50"
                  @change="formData.mei_kana = replaceText(formData.mei_kana, EnumRegex.カナ)"
                />
              </td>
              <TD v-else>{{ formData.mei_kana }}</TD>
            </a-col>
            <a-col span="24">
              <th style="border-top: none"></th>
              <th class="required">（漢字）</th>
              <td v-if="canEdit">
                <a-form-item v-bind="validateInfos.si">
                  <a-input v-model:value="formData.si" placeholder="氏" maxlength="50" />
                </a-form-item>
              </td>
              <TD v-else>{{ formData.si }}</TD>
              <td v-if="canEdit">
                <a-form-item v-bind="validateInfos.mei">
                  <a-input v-model:value="formData.mei" placeholder="名" maxlength="50" />
                </a-form-item>
              </td>
              <TD v-else>{{ formData.mei }}</TD>
            </a-col>
          </template>
          <template
            v-if="splitCode(formData.jutogaisyasyubetu) === String(Enum住民種別.外国人住民)"
          >
            <a-col span="24">
              <th class="flex items-center">
                <span>氏名</span>
                <a-popover placement="rightTop">
                  <template #content>
                    <a-descriptions bordered size="small" :column="1">
                      <a-descriptions-item label="氏名_フリガナ">
                        <div>
                          ・氏名を構成する要素（氏と名、名（ファーストネーム）と中間名（ミドルネーム）と
                        </div>
                        <div>氏（ラストネーム）など）の間に全角の空白を一文字入れる</div>
                        <div>・ローマ字表記での氏名を有する外国人住登外者は出力すること</div>
                      </a-descriptions-item>
                      <a-descriptions-item label="氏名_外国人漢字">
                        <div>
                          ・氏名を構成する要素（氏と名、名（ファーストネーム）と中間名（ミドルネーム）と
                        </div>
                        <div>氏（ラストネーム）など）の間に全角の空白を一文字入れる</div>
                        <div>・漢字表記での氏名を有する外国人住登外者は出力すること</div>
                      </a-descriptions-item>
                      <a-descriptions-item label="氏名_外国人ローマ字">
                        <div>
                          ・氏名を構成する要素（氏と名、名（ファーストネーム）と中間名（ミドルネーム）と
                        </div>
                        <div>氏（ラストネーム）など）の間に全角の空白を一文字入れる</div>
                        <div>
                          ・ローマ字表記での氏名のみを有している等でフリガナを保有していない外国人住登外者の場合以外は、出力すること
                        </div>
                      </a-descriptions-item>
                    </a-descriptions>
                  </template>
                  <exclamation-circle-filled color="#1890ff" class="ml-1" />
                </a-popover>
              </th>
              <th>（フリガナ）</th>
              <td v-if="canEdit">
                <a-input
                  v-model:value="formData.simei_kana"
                  maxlength="100"
                  @change="formData.simei_kana = replaceText(formData.simei_kana, EnumRegex.カナ)"
                />
              </td>
              <TD v-else>{{ formData.simei_kana }}</TD>
            </a-col>
            <a-col span="24">
              <th style="border-top: none"></th>
              <th>（漢字）</th>
              <td v-if="canEdit">
                <a-input v-model:value="formData.simei_gaikanji" maxlength="100" />
              </td>
              <TD v-else>{{ formData.simei_gaikanji }}</TD>
            </a-col>
            <a-col span="24">
              <th style="border-top: none"></th>
              <th>（ローマ字）</th>
              <td v-if="canEdit">
                <a-input v-model:value="formData.simei_gairoma" maxlength="100" />
              </td>
              <TD v-else>{{ formData.simei_gairoma }}</TD>
            </a-col>
            <a-col span="24">
              <th>
                <span>通称</span>
              </th>
              <th>（フリガナ）</th>
              <td v-if="canEdit" class="flex">
                <a-input
                  v-model:value="formData.tusyo_kana"
                  maxlength="100"
                  class="flex-1 mr-2"
                  @change="formData.tusyo_kana = replaceText(formData.tusyo_kana, EnumRegex.カナ)"
                />
                <a-checkbox
                  :checked="formData.tusyo_kanastatus === Enum確認.TRUE"
                  :disabled="!formData.tusyo_kana"
                  @change="
                    formData.tusyo_kanastatus =
                      formData.tusyo_kanastatus === Enum確認.TRUE ? Enum確認.FALSE : Enum確認.TRUE
                  "
                  >本人確認</a-checkbox
                >
              </td>
              <TD v-else>{{ formData.tusyo_kana }}</TD>
            </a-col>
            <a-col span="24">
              <th style="border-top: none"></th>
              <th>（漢字）</th>
              <td v-if="canEdit">
                <a-input v-model:value="formData.tusyo" maxlength="100" />
              </td>
              <TD v-else>{{ formData.tusyo }}</TD>
            </a-col>
          </template>
          <a-col :md="12" :xxl="6">
            <th>性別</th>
            <td v-if="canEdit">
              <ai-select v-model:value="formData.sex" :options="initData.selectorlist7" />
            </td>
            <TD v-else>{{ formData.sex }}</TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th>生年月日</th>
            <td v-if="canEdit">
              <DateJp
                v-model:value="formData.bymd"
                unknown
                style="width: 190px"
                format="YYYY-MM-DD"
                @emit-unknown-date="(v) => (formData.bymd = v)"
              />
            </td>
            <TD v-else>{{ getUnKnownDateJpText(formData.bymd ?? '') }}</TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th>生年月日不詳</th>
            <td v-if="canEdit">
              <a-checkbox v-model:checked="formData.bymd_fusyoflg" />
            </td>
            <TD v-else>{{ formData.bymd_fusyoflg ? '○' : '' }}</TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th style="width: 160px">生年月日(不詳表記)</th>
            <td v-if="canEdit">
              <a-input v-model:value="formData.bymd_fusyohyoki" maxlength="72" />
            </td>
            <TD v-else>{{ formData.bymd_fusyohyoki }}</TD>
          </a-col>
          <a-col :md="12" :xxl="6">
            <th>国名等</th>
            <td v-if="canEdit">
              <ai-select
                v-model:value="formData.adrs_kokunmcd"
                :options="initData.selectorlist8"
                @change="(_, opt) => (formData.adrs_kokunm = opt ? opt.label : '')"
              />
            </td>
            <TD v-else>{{ formData.adrs_kokunmcd }}</TD>
          </a-col>
          <a-col :md="12" :xxl="18">
            <TD>{{ formData.adrs_kokunm }}</TD>
          </a-col>
          <a-col span="24">
            <th>国外住所</th>
            <td v-if="canEdit">
              <a-textarea v-model:value="formData.adrs_gaiadrs" maxlength="300" auto-size />
            </td>
            <td v-else class="textarea">{{ formData.adrs_gaiadrs }}</td>
          </a-col>
        </a-row>
      </div>
      <div :class="[canEdit && 'form', 'self_adaption_table other']">
        <div class="font-bold">その他情報</div>
        <a-row>
          <a-col span="12">
            <th>保険区分</th>
            <td v-if="canEdit">
              <ai-select v-model:value="formData.hokenkbn" :options="initData.selectorlist9" />
            </td>
            <TD v-else>{{ formData.hokenkbn }}</TD>
          </a-col>
          <a-col span="12">
            <th class="required">他業務参照不可</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.sansyofuka">
                <ai-select v-model:value="formData.sansyofuka" :options="initData.selectorlist10" />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.sansyofuka }}</TD>
          </a-col>
          <a-col span="12">
            <th>参照独自施策システム等</th>
            <td v-if="canEdit">
              <a-select
                :value="formData.dokujisystemcdlist?.map((i) => i.hanyocd)"
                mode="multiple"
                style="width: 100%"
                :options="initData.dokujisystemnmlist"
                :filter-option="filterOption"
                @change="
                  (val, opt) =>
                    (formData.dokujisystemcdlist = opt.map((el) => {
                      return { hanyocd: el.value, nm: el.label }
                    }))
                "
              >
                <template #option="{ label, value }">
                  {{ value + ' : ' + label }}
                </template>
              </a-select>
            </td>
            <TD v-else>{{ formData.dokujisystemcdlist?.map((i) => i.nm)?.join('；') }}</TD>
          </a-col>
          <a-col span="12">
            <th>参照業務</th>
            <td v-if="canEdit">
              <a-select
                :value="formData.sansyogyomucdlist?.map((i) => i.hanyocd)"
                mode="multiple"
                style="width: 100%"
                :options="initData.sansyogyomunmlist"
                :filter-option="filterOption"
                @change="
                  (val, opt) =>
                    (formData.sansyogyomucdlist = opt.map((el) => {
                      return { hanyocd: el.value, nm: el.label }
                    }))
                "
              >
                <template #option="{ label, value }">
                  {{ value + ' : ' + label }}
                </template>
              </a-select>
            </td>
            <TD v-else>{{ formData.sansyogyomucdlist?.map((i) => i.nm)?.join('；') }}</TD>
          </a-col>
          <a-col span="12">
            <th class="required">名寄せ元</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.nayosemotoflg">
                <ai-select
                  v-model:value="formData.nayosemotoflg"
                  :options="initData.selectorlist11"
                />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.nayosemotoflg }}</TD>
          </a-col>
          <a-col span="12">
            <th :class="{ required: splitCode(formData.nayosemotoflg) === '2' }">
              名寄せ先宛名番号
            </th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.nayosesakiatenano">
                <a-input v-model:value="formData.nayosesakiatenano" />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.nayosesakiatenano }}</TD>
          </a-col>
          <a-col span="12">
            <th>統合宛名フラグ</th>
            <td v-if="canEdit">
              <ai-select v-model:value="formData.togoatenaflg" :options="initData.selectorlist12" />
            </td>
            <TD v-else>{{ formData.togoatenaflg }}</TD>
          </a-col>
          <a-col span="12">
            <th class="required">登録部署</th>
            <td v-if="canEdit">
              <a-form-item v-bind="validateInfos.regbusyocd">
                <ai-select v-model:value="formData.regbusyocd" :options="initData.selectorlist13" />
              </a-form-item>
            </td>
            <TD v-else>{{ formData.regbusyocd }}</TD>
          </a-col>
        </a-row>
      </div>
    </div>
    <ResumeModal
      v-model:visible="visible_112"
      title="住登外者情報履歷"
      :columns="columns_112"
      service="AWKK00112D"
      @select="selectRow_112"
    />
    <ResumeModal
      v-model:visible="visible_113"
      title="個人番号情報履歷"
      :columns="columns_113"
      service="AWKK00113D"
      :atenano="formData.atenano"
      :disabled-select="!psnoEditing"
      @select="selectRow_113"
    />
    <SetaiModal v-model:visible="visible_setai" @select="selectRow_setai" />
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, reactive, computed, nextTick, watch, toRef } from 'vue'
import SimplePagination from '@/components/Common/SimplePagination/index.vue'
import ResumeModal from '@/views/components/ResumeModal/index.vue'
import SetaiModal from '@/views/affect/AF/AWAF00706D/index.vue'
import { columns as columns_112 } from '@/views/affect/KK/AWKK00112D/content'
import { columns as columns_113 } from '@/views/affect/KK/AWKK00113D/content'
import { useRoute, useRouter } from 'vue-router'
import DateJp from '@/components/Selector/DateJp/index.vue'
import PostCode from '@/components/Selector/PostCode/index.vue'
import TD from '@/components/Common/TableTD/index.vue'
import { Form, message } from 'ant-design-vue'
import { ExclamationCircleFilled } from '@ant-design/icons-vue'
import { BaseInfoVM, DaSelectorModelExp, InitDetailVM, MainInfoVM } from '../type'
import { EnumRegex, Enum住民種別, Enum確認 } from '#/Enums'
import {
  formatYubin,
  getDateHmsJpText,
  getUnKnownDateJpText,
  replaceText,
  filterOption
} from '@/utils/util'
import { ss } from '@/utils/storage'
import { ATENANO_LEN } from '@/constants/mutation-types'
import { showDeleteModal, showInfoModal, showSaveModal } from '@/utils/modal'
import { decryptByRSA, encryptByRSA } from '@/utils/encrypt/data'
import { GlobalStore } from '@/store'
import { useLinkOption } from '@/utils/hooks'
import { Judgement } from '@/utils/judge-edited'
import {
  A000003,
  DELETE_OK_INFO,
  ITEM_ILLEGAL_ERROR,
  ITEM_REQUIRE_ERROR,
  ITEM_SELECTREQUIRE_ERROR,
  SAVE_OK_INFO
} from '@/constants/msg'
import {
  AutoSaisin,
  Delete,
  InitDetail,
  Save,
  SaveSeitai,
  SearchDetail,
  SearchPersonal,
  SearchSeisinDetail,
  SearchSetai,
  SearchYubin
} from '../service'

//---------------------------------------------------------------------------
//属性
//---------------------------------------------------------------------------
const props = defineProps<{
  /**異動 */
  ido: boolean
  judge: Judgement
}>()
const emit = defineEmits(['update:ido'])

//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const router = useRouter()
const atenano = route.query.atenano as string
const rirekino = Number(route.query.rirekino)
const autoLoading = ref(false)
const psnoLoading = ref(false)
const psnoEditing = ref(false)
const count = ref(0)
const current = ref(0)
const privkey = ref('')
const visible_112 = ref(false)
const visible_113 = ref(false)
const visible_setai = ref(false)
let psno = ''

const headerInfo = ref<BaseInfoVM>()
const formData = reactive<MainInfoVM>({
  rirekino: 0,
  upddttm: null,
  saisin: '',
  stop: '',
  idoymd: '',
  idotodokeymd: '',
  idojiyu: '',
  setaino: '',
  senusinm: '',
  adrs_tyoazacd: '',
  atenano: '',
  jutogaisyasyubetu: '',
  jutogaisyajotai: '',
  juminkbn: '',
  si: '',
  mei: '',
  sex: '',
  bymd_fusyoflg: false,
  adrs_kokunm: '',
  sansyofuka: '',
  dokujisystemcdlist: [],
  sansyogyomucdlist: [],
  nayosemotoflg: '',
  nayosesakiatenano: '',
  togoatenaflg: '',
  regbusyocd: '',
  tusyo_kanastatus: Enum確認.FALSE
})

const initData = reactive<InitDetailVM>({
  selectorlist1: [],
  selectorlist2: [],
  selectorlist3: [],
  selectorlist4: [],
  selectorlist5: [],
  selectorlist6: [],
  selectorlist7: [],
  selectorlist8: [],
  selectorlist9: [],
  selectorlist10: [],
  dokujisystemnmlist: [],
  sansyogyomunmlist: [],
  selectorlist11: [],
  selectorlist12: [],
  selectorlist13: []
})
//ドロップダウンリスト連動処理
const { keyoptions, options, onChangeKeyOpt, onChangeOpt } = useLinkOption(
  toRef(initData, 'selectorlist4'),
  toRef(initData, 'selectorlist3')
)

//項目の設定
const rules = computed(() => ({
  idoymd: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '異動年月日') }],
  idotodokeymd: [
    { required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '異動届出年月日') }
  ],
  idojiyu: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '異動事由') }],
  setaino: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '世帯番号') }],
  atenano: [{ required: true, message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '宛名番号') }],
  jutogaisyasyubetu: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '住民種別') }
  ],
  jutogaisyajotai: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '住民状態') }
  ],
  si: [
    {
      required: splitCode(formData.jutogaisyasyubetu) === String(Enum住民種別.日本人住民),
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '氏')
    }
  ],
  mei: [
    {
      required: splitCode(formData.jutogaisyasyubetu) === String(Enum住民種別.日本人住民),
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '名')
    }
  ],
  adrs_yubin: [
    {
      validator: (_rule, value: string) => {
        if (value && value.length < 8) {
          return Promise.reject(ITEM_ILLEGAL_ERROR.Msg.replace('{0}', '郵便番号'))
        }
        return Promise.resolve()
      }
    }
  ],
  sansyofuka: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '他業務参照不可') }
  ],
  nayosemotoflg: [
    { required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '名寄せ元') }
  ],
  nayosesakiatenano: [
    {
      required: splitCode(formData.nayosemotoflg) === '2',
      message: ITEM_REQUIRE_ERROR.Msg.replace('{0}', '名寄せ先宛名番号')
    }
  ],
  regbusyocd: [{ required: true, message: ITEM_SELECTREQUIRE_ERROR.Msg.replace('{0}', '登録部署') }]
}))
const { validate, clearValidate, validateInfos } = Form.useForm(formData, rules)

//操作権限
const personalnoflg = route.meta.personalnoflg
const canEdit = computed(() => route.meta.updflg && props.ido)
//--------------------------------------------------------------------------
//フック関数
//--------------------------------------------------------------------------
onMounted(() => {
  InitDetail().then((res) => {
    Object.assign(initData, res.initdetail)
  })
  if (rirekino) searchDetail(0)
})
//--------------------------------------------------------------------------
//監視定義
//--------------------------------------------------------------------------
//監視手動/自動
const auto_setaino = ref('手動')
watch(auto_setaino, async (val) => {
  if (val === '自動') {
    const res = await AutoSaisin({ seqflg: '1' })
    formData.setaino = res.seqno ?? ''
  }
})
const auto_atenano = ref('手動')
watch(auto_atenano, async (val) => {
  if (val === '自動') {
    const res = await AutoSaisin({ seqflg: '2' })
    formData.atenano = res.seqno ?? ''
  }
})
//編集状態
watch(formData, () => props.judge.setEdited())
//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//検索処理
const searchDetail = async (rirekinum: number) => {
  GlobalStore.setLoading(true)
  try {
    const res = await SearchDetail({
      rirekino,
      atenano,
      rirekinum
    })
    if (res.rsaprivatekey) privkey.value = res.rsaprivatekey
    Object.assign(formData, res.maininfo)
    formData.personalno = decryptByRSA(res.maininfo.personalno, res.rsaprivatekey) || ''
    psno = formData.personalno
    formData.adrs_yubin = formatYubin(formData.adrs_yubin)
    headerInfo.value = res.baseinfo
    count.value = res.rirekitotal
    current.value = res.rirekinum
  } catch (error) {}
  GlobalStore.setLoading(false)

  //支援対象者の場合、警告メッセージを表示
  if (rirekinum === 0 && headerInfo.value?.keikoku) {
    showInfoModal({
      type: 'warning',
      content: A000003.Msg.replace('{0}', headerInfo.value.keikoku)
    })
  }

  nextTick(() => props.judge.reset())
}

//履歴Page
function changeCurrent(val) {
  current.value = val
  searchDetail(current.value)
}

//自動入力郵便
async function autoInput() {
  if (!formData.adrs_yubin) return
  await validate('adrs_yubin')
  autoLoading.value = true
  try {
    const { yubininfo } = await SearchYubin({ adrs_yubin: formatYubin(formData.adrs_yubin, true) })
    Object.assign(formData, yubininfo ?? {})
  } catch (error) {}
  autoLoading.value = false
}

//異動
async function handleIdo() {
  GlobalStore.setLoading(true)
  const res = await SearchSeisinDetail({
    idoymd: formData.idoymd as string,
    idojiyu: formData.idojiyu,
    atenano: formData.atenano,
    rirekino: formData.rirekino,
    rirekinum: current.value
  })
  Object.assign(formData, res.maininfo)
  formData.personalno = psno
  formData.adrs_yubin = formatYubin(formData.adrs_yubin)
  count.value = res.rirekitotal
  current.value = res.rirekinum
  GlobalStore.setLoading(false)
  emit('update:ido', true)
  nextTick(() => {
    clearValidate()
    props.judge.reset()
  })
}

//市区町村
function changeSiku(val, opt: DaSelectorModelExp) {
  onChangeOpt(val, opt)
  formData.adrs_todofuken = opt?.expname1
  formData.adrs_sikunm = opt?.expname2
}
//町字
function changeTyoaza(val, opt: DaSelectorKeyModel) {
  onChangeKeyOpt(val, opt)
  formData.adrs_tyoaza = opt?.label
}

//保存処理
async function saveData() {
  await validate()
  showSaveModal({
    onOk: async () => {
      try {
        await Save(
          {
            maininfo: {
              ...formData,
              personalno: encryptByRSA(formData.personalno),
              adrs_yubin: formatYubin(formData.adrs_yubin, true)
            }
          },
          updSeitai
        )
        message.success(SAVE_OK_INFO.Msg)
        router.push({ name: route.name as string })
      } catch (error) {}
    }
  })
}
//世帯更新処理
async function updSeitai(data) {
  if (data.seitaidictlist?.length > 0) {
    await SaveSeitai({
      atenano: formData.atenano,
      rirekino: data.rirekino,
      seitaidictlist: data.seitaidictlist
    })
    message.success(SAVE_OK_INFO.Msg)
    router.push({ name: route.name as string })
  }
}

//削除処理
function handleDelete() {
  showDeleteModal({
    handleDB: true,
    onOk: async () => {
      try {
        await Delete({ atenano })
        message.success(DELETE_OK_INFO.Msg)
        router.push({ name: route.name as string })
      } catch (error) {}
    }
  })
}

//検索個人番号
async function searchPersonal() {
  psnoLoading.value = true
  try {
    const res = await SearchPersonal({ atenano: formData.atenano })
    formData.personalno = decryptByRSA(res.personalno, res.rsaprivatekey) || ''
  } catch (error) {}
  psnoLoading.value = false
}

function selectRow_112(row) {
  changeCurrent(row.rirekinum)
}
function selectRow_113(row) {
  formData.personalno = row.personalno
}
async function selectRow_setai(row) {
  const res = await SearchSetai({ setaino: row.setaino })
  res.setaiInfo.adrs_yubin = formatYubin(res.setaiInfo.adrs_yubin)
  Object.assign(formData, res.setaiInfo)
  formData.setaino = row.setaino
  formData.senusinm = row.name
}

function splitCode(val = '') {
  return val.split(' : ')[0]
}

defineExpose({ headerInfo, handleIdo, saveData, handleDelete })
</script>

<style lang="less" scoped>
th {
  width: 110px;
}
.other th {
  width: 180px;
}
.ellipsis {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}
</style>
