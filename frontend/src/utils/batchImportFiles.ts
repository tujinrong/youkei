//URL遷移ページ事前設定：フォルダーよりURLを自動生成
export const getRoutePages = () => {
  const pages = import.meta.glob('/src/views/affect/**/*.vue', { import: 'default', eager: true })
  const files = {}
  for (const p in pages) {
    const name = getFileName(p)
    if (name) {
      files[name] = pages[p]
    }
  }
  return files
}

const getFileName = (path: string) => {
  if (path.indexOf('components') > 0) {
    return ''
  }
  const pattern = /\/(\w*)\.vue/
  const matched = path.match(pattern)
  // if (!matched) {
  //   throw new Error('path is not right:' + path)
  // }
  if (matched?.[1] === 'index') {
    return ''
  }
  return matched?.[1]
}
