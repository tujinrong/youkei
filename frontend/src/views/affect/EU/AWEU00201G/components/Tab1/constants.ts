import { sql, PostgreSQL } from '@codemirror/lang-sql'

export const extensions = [
  sql({
    dialect: PostgreSQL,
    schema: {
      apom: ['user', 'app_user', 'app_user_user']
    }
  })
]
export const sqlProgamConfig = {
  style: { height: '400px' },
  placeholder: 'Code goes here...',
  autofocus: true,
  indentWithTab: true,
  tabSize: 2,
  extensions
}
