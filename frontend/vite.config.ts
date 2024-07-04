/** ----------------------------------------------------------------
 * 業務名称　: 健康管理システム
 * 機能概要　: vite
 * 　　　　　  コンフィグ設定
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import vueJsx from '@vitejs/plugin-vue-jsx'
import path from 'path'
import { createSvgIconsPlugin } from 'vite-plugin-svg-icons'
import UnoCSS from 'unocss/vite'
import viteImagemin from 'vite-plugin-imagemin'
import { visualizer } from 'rollup-plugin-visualizer'

export default defineConfig({
  plugins: [
    vue(),
    vueJsx(),
    createSvgIconsPlugin({
      iconDirs: [path.resolve(process.cwd(), 'src/assets/icons')],
      symbolId: 'icon-[dir]-[name]'
    }),
    UnoCSS(),
    visualizer(),
    viteImagemin({
      svgo: {
        plugins: [
          {
            name: 'removeViewBox'
          },
          {
            name: 'removeEmptyAttrs',
            active: false
          }
        ]
      }
    })
  ],
  esbuild: {
    drop: ['debugger', 'console']
  },
  build: {
    sourcemap: false,
    chunkSizeWarningLimit: 5000,
    rollupOptions: {
      output: {
        manualChunks(id) {
          if (id.includes('node_modules')) {
            return 'vendors'
          }
        }
      }
    }
  },
  resolve: {
    alias: [
      {
        find: '@',
        replacement: path.resolve(__dirname, 'src') + '/'
      },
      {
        find: '#',
        replacement: path.resolve(__dirname, 'types') + '/'
      },
      {
        find: 'public',
        replacement: path.resolve(__dirname, 'public') + '/'
      }
    ]
  },
  css: {
    preprocessorOptions: {
      less: {
        javascriptEnabled: true
      }
    }
  },
  server: {
    port: 3000,
    open: true
    // hmr: true
    // proxy: {
    //   '/api': {
    //     target: 'http://localhost:16384/', //
    //     changeOrigin: true, //
    //     rewrite: (path) => path.replace(/^\/api/, '') //
    //   }
    // }
  },
  optimizeDeps: {
    include: ['@ant-design/icons-vue', 'ant-design-vue']
  },
  define: { 'process.env': {} }
})
