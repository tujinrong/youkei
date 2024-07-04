import { sql, PostgreSQL } from '@codemirror/lang-sql'
import { autocompletion, completionKeymap } from '@codemirror/autocomplete'
import { keymap } from '@codemirror/view'

export const createExtensions = (completions) => {
  const myCompletionSource = (context) => {
    const word = context.matchBefore(/@\w*/)
    if (!word) return null
    if (word.from === word.to && !context.explicit) return null
    return {
      from: word.from,
      options: completions,
      validFor: /^@\w*$/
    }
  }

  return [
    sql({
      dialect: PostgreSQL,
      schema: {
        apom: ['user', 'app_user', 'app_user_user']
      }
    }),
    autocompletion({ override: [myCompletionSource] }),
    keymap.of(completionKeymap)
  ]
}

export const sqlProgamConfig = (completions) => ({
  style: { height: '500px' },
  placeholder: 'Code goes here...',
  autofocus: true,
  indentWithTab: true,
  tabSize: 2,
  extensions: createExtensions(completions)
})

export const updateSqlConfig = (completions) => ({
  placeholder: '',
  style: { height: '120px' },
  autofocus: true,
  indentWithTab: true,
  tabSize: 2,
  extensions: createExtensions(completions)
})
