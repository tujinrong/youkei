<template>
  <div class="panel-edit">
    <div class="flex">
      <div>
        <div
          class="left-card"
          style="width: 260px; border: 1px solid #606266; overflow-y: auto"
          :style="{ height: collapseHeight }"
        >
          <draggable
            :list="list"
            item-key="jyokenid"
            ghost-class="opacity-0"
            handle=".move"
            :force-fallback="true"
            chosen-class="chosenClass"
            animation="300"
            :fallback-class="true"
            :fallback-on-body="true"
            :touch-start-threshold="50"
            :fallback-tolerance="50"
            :sort="false"
            @end="onEnd"
          >
            <template #item="{ element }">
              <div
                :class="{
                  move: atenaflg || element?.jyokenlabel !== '送付先利用目的'
                }"
              >
                <div
                  class="ant-btn btn text-start w-full"
                  style="border-top: none; border-left: none; border-right: none"
                >
                  <SvgIcon name="color-text" class="m-r-1 icon-style" />{{ element?.jyokenlabel }}
                </div>
              </div>
            </template>
          </draggable>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import draggable from 'vuedraggable'
import { SearchConditionVM } from '../../../type'
import { getHeight } from '@/utils/height'
import SvgIcon from '@/components/Common/SvgIcon/index.vue'

const collapseHeight = computed(() => getHeight(320))

const props = defineProps<{
  list: Partial<SearchConditionVM>[]
  atenaflg?: boolean
  onEnd: (e: Event) => void
}>()
</script>

<style lang="less" scoped>
.chosenClass {
  border: solid 1px #1890ff;
}
</style>
