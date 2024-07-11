/** -----------------------------------------------------------------
 * 業務名称　: 養鶏-互助防疫システム
 * 機能概要　: ベース
 * 　　　　　  eslint設定
 * 作成日　　: 2023.04.04
 * 作成者　　: 李
 * 変更履歴　:
 * -----------------------------------------------------------------*/
module.exports = {
  parser: 'vue-eslint-parser',
  parserOptions: {
    parser: '@typescript-eslint/parser', // Specifies the ESLint parser
    ecmaVersion: 2020, // Allows for the parsing of modern ECMAScript features
    sourceType: 'module', // Allows for the use of imports
    ecmaFeatures: {
      tsx: true, // Allows for the parsing of JSX
      jsx: true
    }
  },
  settings: {
    tsx: {
      version: 'detect' // Tells eslint-plugin-react to automatically detect the version of React to use
    }
  },
  plugins: ['prettier'],
  extends: [
    'plugin:vue/vue3-recommended',
    'plugin:@typescript-eslint/recommended', // Uses the recommended rules from the @typescript-eslint/eslint-plugin
    // 'prettier/@typescript-eslint', // Uses eslint-config-prettier to disable ESLint rules from @typescript-eslint/eslint-plugin that would conflict with prettier
    'plugin:prettier/recommended' // Enables eslint-plugin-prettier and eslint-config-prettier. This will display prettier errors as ESLint errors. Make sure this is always the last configuration in the extends array.
  ],
  rules: {
    'no-var': 'error',
    'no-unused-vars': 'off',
    'prettier/prettier': 'error',
    '@typescript-eslint/no-unused-vars': ['off'],
    '@typescript-eslint/no-this-alias': ['off'],
    'vue/multi-word-component-names': 'off',
    'vue/no-mutating-props': [
      'warn',
      {
        shallowOnly: true
      }
    ]
    // Place to specify ESLint rules. Can be used to overwrite rules specified from the extended configs
    // e.g. "@typescript-eslint/explicit-function-return-type": "off",
  }
}
