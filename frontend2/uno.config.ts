import { defineConfig } from '@unocss/vite'
import transformerDirectives from '@unocss/transformer-directives'
import transformerVariantGroup from '@unocss/transformer-variant-group'
import presetUno from '@unocss/preset-uno'
import type { Theme } from '@unocss/preset-uno'
import { presetSoybeanAdmin } from '@sa/uno-preset'
import { themeVars } from './src/theme/vars'

export default defineConfig<Theme>({
  content: {
    pipeline: {
      exclude: ['node_modules', 'dist'],
    },
  },
  theme: {
    ...themeVars,
    fontSize: {
      'icon-xs': '0.875rem',
      'icon-small': '1rem',
      icon: '1.125rem',
      'icon-large': '1.5rem',
      'icon-xl': '2rem',
    },
  },
  shortcuts: {
    'card-wrapper': 'rd-8px shadow-sm',
  },
  transformers: [transformerDirectives(), transformerVariantGroup()],
  presets: [presetUno({ dark: 'class' }), presetSoybeanAdmin()],
  rules: [
    [
      'textarea',
      {
        'padding-left': '14px !important',
        'padding-right': '14px !important',
        'white-space': 'pre-wrap',
      },
    ],
    ['mincho', { 'font-family': 'IPAmjMincho,Acgjm' }],
    ['bg-readonly', { 'background-color': '#ffffe1 !important' }],
    ['bg-editable', { 'background-color': '#ecf5ff !important' }],
    [
      'bg-disabled',
      { 'background-color': '#f1f1f1 !important', color: '#666666 !important' },
    ],
    ['bg-errorcell', { 'background-color': '#ffa0a0' }],
    ['bg-warncell', { 'background-color': '#ffd666' }],
    ['request-mark', { color: 'red' }],
    ['br-grey', { 'border-right': '1px solid #606266 !important' }],
    ['bb-grey', { 'border-bottom': '1px solid #606266 !important' }],
  ],
})
