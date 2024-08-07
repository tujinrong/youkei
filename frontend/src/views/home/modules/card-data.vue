<script setup lang="ts">
import { computed } from 'vue'
import { createReusableTemplate } from '@vueuse/core'
import { $t } from '@/locales'

defineOptions({
  name: 'CardData',
})

interface CardData {
  key: string
  title: string
  value: number
  unit: string
  suffix: string
  color: {
    start: string
    end: string
  }
  icon: string
}

const cardData = computed<CardData[]>(() => [
  {
    key: 'visitCount',
    title: '契約数(新規)',
    value: 112,
    unit: '',
    suffix: '',
    color: {
      start: '#ec4786',
      end: '#b955a4',
    },
    icon: 'ant-design:bar-chart-outlined',
  },
  {
    key: 'visitCount',
    title: '契約数(継続)',
    value: 1826,
    unit: '',
    suffix: '',
    color: {
      start: '#fcbc25',
      end: '#f68057',
    },
    icon: 'ant-design:bar-chart-outlined',
  },
  {
    key: 'turnover',
    title: '羽数',
    value: 302784924,
    unit: '',
    suffix: ' 羽',
    color: {
      start: '#865ec0',
      end: '#5144b4',
    },
    icon: 'ant-design:dingtalk-outlined',
  },
  {
    key: 'downloadCount',
    title: '績立金額',
    value: 1391380502,
    unit: '￥',
    suffix: ' 円',
    color: {
      start: '#56cdf3',
      end: '#719de3',
    },
    icon: 'ant-design:money-collect-outlined',
  },
])

interface GradientBgProps {
  gradientColor: string
}

const [DefineGradientBg, GradientBg] = createReusableTemplate<GradientBgProps>()

function getGradientColor(color: CardData['color']) {
  return `linear-gradient(to bottom right, ${color.start}, ${color.end})`
}
</script>

<template>
  <ACard :bordered="false" size="small" class="card-wrapper">
    <!-- define component start: GradientBg -->
    <DefineGradientBg v-slot="{ $slots, gradientColor }">
      <div
        class="rd-8px px-16px pb-4px pt-8px text-white"
        :style="{ backgroundImage: gradientColor }"
      >
        <component :is="$slots.default" />
      </div>
    </DefineGradientBg>
    <!-- define component end: GradientBg -->

    <ARow :gutter="[16, 16]" class="w-1/2">
      <ACol v-for="item in cardData" :key="item.key" :md="24" :lg="24" :xl="24">
        <GradientBg
          :gradient-color="getGradientColor(item.color)"
          class="flex-1"
        >
          <h3 class="text-20px">{{ item.title }}</h3>
          <div class="flex justify-between pt-12px">
            <SvgIcon :icon="item.icon" class="text-32px" />
            <CountTo
              :prefix="item.unit"
              :suffix="item.suffix"
              :start-value="1"
              :end-value="item.value"
              class="text-30px text-white dark:text-dark"
            />
          </div>
        </GradientBg>
      </ACol>
    </ARow>
  </ACard>
</template>

<style scoped></style>
