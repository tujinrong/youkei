<!------------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: テーマカラー
 * 　　　　　  システム設定
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * ----------------------------------------------------------------->
<template>
  <setting-item title="テーマカラー">
    <div style="height: 20px">
      <a-tooltip
        v-for="(item, index) in colorList"
        :key="index"
        class="setting-drawer-theme-color-colorBlock"
      >
        <template #title>{{ item.key }}</template>
        <a-tag :color="item.color" @click="changeColor(item.color)">
          <CheckOutlined v-if="item.color === primaryColor" />
        </a-tag>
      </a-tooltip>
      <a-popover title="カスタマイズ" placement="bottomRight">
        <template #content>
          <color-picker
            :pure-color="primaryColor"
            is-widget
            format="hex"
            disable-alpha
            disable-history
            @pureColorChange="changeColor"
          ></color-picker>
        </template>
        <a-tag
          :color="isCustomColor ? primaryColor : ''"
          class="setting-drawer-theme-color-colorBlock"
        >
          <CheckOutlined v-if="isCustomColor" />
        </a-tag>
      </a-popover>
    </div>
  </setting-item>
</template>
<script lang="ts" setup>
import { computed } from 'vue'
import { useStore } from 'vuex'
import { TOGGLE_COLOR } from '@/constants/mutation-types'
import { CheckOutlined } from '@ant-design/icons-vue'
import { colorList } from '@/constants/constant'
import { primaryColor } from '@/store/use-site-settings'
import SettingItem from './setting-item.vue'
import { ColorPicker } from 'vue3-colorpicker'
import 'vue3-colorpicker/style.css'
import { ConfigProvider } from 'ant-design-vue'
//--------------------------------------------------------------------------
//データ定義
//--------------------------------------------------------------------------
const { state, commit } = useStore()
const colorArr = colorList.map((item) => item.color)

//--------------------------------------------------------------------------
//計算定義
//--------------------------------------------------------------------------
const isCustomColor = computed(() => {
  return !colorArr.includes(state.app.color)
})

//--------------------------------------------------------------------------
//メソッド
//--------------------------------------------------------------------------
const changeColor = (color) => {
  commit(TOGGLE_COLOR, color)
  ConfigProvider.config({
    theme: {
      primaryColor: color
    }
  })
}
</script>
<style lang="less" scoped>
.setting-drawer-theme-color-colorBlock {
  width: 20px;
  height: 20px;
  border-radius: 2px;
  float: left;
  cursor: pointer;
  margin-right: 8px;
  padding-left: 0px;
  padding-right: 0px;
  text-align: center;
  color: #fff;
  font-weight: 700;

  i {
    font-size: 14px;
  }
}
</style>
