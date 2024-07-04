// uno.config.ts
import { defineConfig, presetAttributify, presetIcons, presetUno } from 'unocss'

export default defineConfig({
  rules: [
    [
      'textarea',
      {
        'padding-left': '14px !important',
        'padding-right': '14px !important',
        'white-space': 'pre-wrap'
      }
    ],
    ['mincho', { 'font-family': 'IPAmjMincho,Acgjm' }],
    ['m-t-1', { 'margin-top': '10px !important' }],
    ['m-t-2', { 'margin-top': '20px !important' }],
    ['m-l-1', { 'margin-left': '10px !important' }],
    ['m-l-2', { 'margin-left': '20px !important' }],
    ['m-r-1', { 'margin-right': '10px !important' }],
    ['m-r-2', { 'margin-right': '20px !important' }],
    ['m-b-1', { 'margin-bottom': '10px !important' }],
    ['m-b-2', { 'margin-bottom': '20px !important' }],
    ['bg-readonly', { 'background-color': '#ffffe1 !important' }],
    ['bg-editable', { 'background-color': '#ecf5ff !important' }],
    ['bg-disabled', { 'background-color': '#f1f1f1 !important', color: '#666666 !important' }],
    ['bg-errorcell', { 'background-color': '#ffa0a0' }],
    ['bg-warncell', { 'background-color': '#ffd666' }],
    ['request-mark', { color: 'red' }],
    ['btn-round', { 'border-radius': '10px' }],
    ['br-grey', { 'border-right': '1px solid #606266 !important' }],
    ['bb-grey', { 'border-bottom': '1px solid #606266 !important' }]
  ],
  presets: [presetUno(), presetAttributify(), presetIcons()]
})
