<!------------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: 共通バー情報
 * 　　　　　  画面レイアウト・処理
 * 作成日　　: 2023.04.17
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <div class="footer" :style="{ left: barLeft }">
    <a-space class="flex-wrap my-2 mx-4">
      <template v-for="item in list" :key="item.barno">
        <a-button
          v-if="isShow(item.barno)"
          type="primary"
          :disabled="!item.enabled"
          :class="[{ 'btn-kira': item.attnflg }, 'btn-round']"
          @click="modals[item.barno]?.open"
          >{{ item.barnm }}</a-button
        >
      </template>
    </a-space>
    <AWAF00601D ref="Ref_601" />
    <AWAF00602D ref="Ref_602" />
    <AWAF00604D ref="Ref_604" />
    <AWAF00605D ref="Ref_605" />
    <AWAF00606D ref="Ref_606" />
    <AWAF00607D ref="Ref_607" />
    <AWAF00608D ref="Ref_608" />
    <AWAF00609D ref="Ref_609" />
    <AWAF00610D ref="Ref_610" />
  </div>
</template>

<script setup lang="ts">
import { Enum共通バー番号 } from '#/Enums'
import { BarStore } from '@/store/index'
import emitter from '@/utils/event-bus'
import { barLeft } from '@/utils/height'
import { onMounted, ref } from 'vue'
import { useRoute } from 'vue-router'
import { Init as InitFooter } from './service'
import { InfoVM, InitRequest } from './type'
import AWAF00601D from '@/views/affect/AF/AWAF00601D/index.vue'
import AWAF00602D from '@/views/affect/AF/AWAF00602D/index.vue'
import AWAF00604D from '@/views/affect/AF/AWAF00604D/index.vue'
import AWAF00605D from '@/views/affect/AF/AWAF00605D/index.vue'
import AWAF00606D from '@/views/affect/AF/AWAF00606D/index.vue'
import AWAF00607D from '@/views/affect/AF/AWAF00607D/index.vue'
import AWAF00608D from '@/views/affect/AF/AWAF00608D/index.vue'
import AWAF00609D from '@/views/affect/AF/AWAF00609D/index.vue'
import AWAF00610D from '@/views/affect/AF/AWAF00610D/index.vue'

const props = defineProps<{
  atenano?: string
}>()
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const route = useRoute()
const list = ref<InfoVM[]>([])

const Ref_601 = ref<InstanceType<typeof AWAF00601D> | null>(null)
const Ref_602 = ref<InstanceType<typeof AWAF00602D> | null>(null)
const Ref_604 = ref<InstanceType<typeof AWAF00604D> | null>(null)
const Ref_605 = ref<InstanceType<typeof AWAF00605D> | null>(null)
const Ref_606 = ref<InstanceType<typeof AWAF00606D> | null>(null)
const Ref_607 = ref<InstanceType<typeof AWAF00607D> | null>(null)
const Ref_608 = ref<InstanceType<typeof AWAF00608D> | null>(null)
const Ref_609 = ref<InstanceType<typeof AWAF00609D> | null>(null)
const Ref_610 = ref<InstanceType<typeof AWAF00610D> | null>(null)

const modals = ref({
  [Enum共通バー番号.メモ情報]: Ref_601,
  [Enum共通バー番号.電子ファイル情報]: Ref_602,
  [Enum共通バー番号.メモ情報_世帯]: Ref_604,
  [Enum共通バー番号.連絡先]: Ref_605,
  [Enum共通バー番号.個人照会]: Ref_606,
  [Enum共通バー番号.警告情報照会]: Ref_607,
  [Enum共通バー番号.送付先管理]: Ref_608,
  [Enum共通バー番号.フォロー管理]: Ref_609,
  [Enum共通バー番号.健診結果保健指導履歴照会]: Ref_610
})

//---------------------------------------------------------------------------
//フック関数
//---------------------------------------------------------------------------
onMounted(async () => {
  getBarData()

  const currentKino = String(route.name)
  emitter.on('refreshBar', (name) => {
    if (name === currentKino) {
      getBarData()
    }
  })
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
//共通バー情報取得：名称、権限
async function getBarData() {
  const params: InitRequest = {
    kinoid: route.name as string,
    atenano: props.atenano || (route.query.atenano as string),
    patternno: route.query.patternno as string
  }
  const res = await InitFooter(params)
  list.value = res.kekkalist
  BarStore.setBarKengenList(res.kekkalist)
}

function isShow(barno: Enum共通バー番号) {
  //AWKK00101G
  const isSetaiPage_KK01 = route.name === 'AWKK00101G' && props.atenano
  const isDetailPage_KK01 = route.name === 'AWKK00101G' && !props.atenano

  return (
    (barno === Enum共通バー番号.メモ情報_世帯 && !isDetailPage_KK01) ||
    (barno !== Enum共通バー番号.メモ情報_世帯 && !isSetaiPage_KK01)
  )
}
</script>

<style src="./index.less" scoped></style>
