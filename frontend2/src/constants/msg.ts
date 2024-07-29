export const CM_HTTP_ERROR = {
  No: 'E000001',
  Msg: 'サーバーとの接続に失敗しました。',
}
export const CM_FATAL_ERROR = {
  No: 'E000002',
  Msg: '予期せぬエラーが発生しました。',
}
export const CM_KEYDUPLICATE_ERROR = {
  No: 'E000003',
  Msg: 'キー重複エラーが発生しました。',
}
export const CM_DEADLOCK_ERROR = {
  No: 'E000004',
  Msg: 'デッドロックエラーが発生しました。',
}
export const CM_DBCONN_ERROR = {
  No: 'E000005',
  Msg: 'DB接続エラーが発生しました。',
}
export const CM_DBTIMEOUT_ERROR = {
  No: 'E000006',
  Msg: 'タイムアウトエラーが発生しました。',
}
export const CM_EXCLUSIVE_ERROR = {
  No: 'E000007',
  Msg: 'データを更新できません。\n他のユーザーによって変更された可能性があります。',
}
export const CM_AUTH_ERROR = {
  No: 'E000008',
  Msg: '認証エラーが発生しました。',
}
export const CM_LOGINTIMEOUT_ERROR = {
  No: 'E000009',
  Msg: '長時間未操作のため、再びログインしてください。',
}
export const ITEM_REQUIRE_ERROR = {
  No: 'E001001',
  Msg: '{0}は必須入力項目です。',
}
export const ITEM_NOTEQUAL_ERROR = {
  No: 'E001002',
  Msg: '{0}と一致していません。',
}
export const ITEM_ILLEGAL_ERROR = {
  No: 'E001003',
  Msg: '{0}を正しく入力してください。',
}
export const ITEM_EQUAL_ERROR = { No: 'E001004', Msg: '{0}と一致しています。' }
export const ITEM_SELECTREQUIRE_ERROR = {
  No: 'E001005',
  Msg: '{0}を選択してください。',
}
export const ITEM_RANGE_ERROR = { No: 'E001006', Msg: '{0}の範囲が不正です。' }
export const E001007 = { No: 'E001007', Msg: '全角文字のみ入力項目です。' }
export const E001008 = { No: 'E001008', Msg: '{0}が重複しています。' }
export const E001009 = { No: 'E001009', Msg: '{0}で入力してください。' }
export const E001010 = {
  No: 'E001010',
  Msg: '桁数上限({0}文字)を超えています。',
}
export const E001011 = {
  No: 'E001011',
  Msg: '現在、画面起動中です。{0}を表示出来ません。',
}
export const E001012 = {
  No: 'E001012',
  Msg: 'アクセス権限がない為、{0}を表示出来ません。',
}
export const E001013 = {
  No: 'E001013',
  Msg: '入力値が不正です。確認してください。',
}
export const DATA_NOTEXIST_ERROR = {
  No: 'E002001',
  Msg: '{0}データが存在しないため、データを{1}できません。',
}
export const E002002 = {
  No: 'E002002',
  Msg: 'この処理は時間がかかり過ぎますので、検索条件を増やしてください。',
}
export const E002003 = { No: 'E002003', Msg: '既に使用されている{0}です。' }
export const E002004 = {
  No: 'E002004',
  Msg: '出力項目マスタに該当連携番号のデータがないため、出力用SQL文生成できません。',
}
export const MSG_JIGYO_YOYAKU_TYOFUKU_DATA = {
  No: 'E002005',
  Msg: 'すでに同じ{0}が存在しています。',
}
export const UPLOAD_ERROR = {
  No: 'E003001',
  Msg: 'アップロードは失敗しました。',
}
export const FILE_NOTEXIST_ERROR = {
  No: 'E003002',
  Msg: '指定したファイルが見つかりませんでした。',
}
export const DOWNLOAD_NOTEXIST_ERROR = {
  No: 'E003003',
  Msg: 'ダウンロードファイルが見つかりません。',
}
export const FILE_TYPE_ERROR = {
  No: 'E003004',
  Msg: '指定したファイルの拡張子がサポートしていないため、アップロードできません。',
}
export const E003005 = { No: 'E003005', Msg: '{0}に存在しません。' }
export const E003006 = { No: 'E003006', Msg: '{0}が不正です。' }
export const E003007 = { No: 'E003007', Msg: '{0}ファイルを指定してください。' }
export const E003008 = { No: 'E003008', Msg: '{0}と{1}は一致していません。' }
export const USER_ACCOUNT_OUT_ERROR = {
  No: 'E004001',
  Msg: 'このユーザーアカウントは有効期限範囲外です。管理者までお問い合わせください。',
}
export const USER_PWD_OUT_ERROR = {
  No: 'E004002',
  Msg: 'このユーザーのパスワードは有効期限範囲外です。管理者までお問い合わせください。',
}
export const USER_LOGIN_ERROR = {
  No: 'E004003',
  Msg: 'ユーザーＩＤまたはパスワードが間違っています。正しいユーザーＩＤおよびパスワードを入力してください。',
}
export const USER_LOCK_ERROR = {
  No: 'E004004',
  Msg: 'このユーザーアカウントはロックされました。管理者までお問い合わせください。',
}
export const E004005 = {
  No: 'E004005',
  Msg: 'パスワードは{0}を含めてください。',
}
export const E004006 = { No: 'E004006', Msg: '{0}は{1}に存在しません。' }
export const E004007 = { No: 'E004007', Msg: '{0}は失敗しました。' }
export const E004008 = {
  No: 'E004008',
  Msg: '登録支所へ更新・削除権限がありません。',
}
export const E004009 = {
  No: 'E004009',
  Msg: '該当プロシージャが使用されています。削除できません。',
}
export const E004010 = {
  No: 'E004010',
  Msg: 'タスクが実行中の場合、即時実行・変更・削除ができません。',
}
export const E004011 = {
  No: 'E004011',
  Msg: 'ユ-ザ領域コ-ドの上限に達しました、追加できません。\n(設定できるコードの最大値：{0})',
}
export const E004012 = {
  No: 'E004012',
  Msg: '{0}のデータです。コードを「{1}-{2}」の範囲で設定したください。',
}
export const E014001 = {
  No: 'E014001',
  Msg: '該当{0}が使用されています。削除できません。',
}
export const E014002 = {
  No: 'E014002',
  Msg: '氏と名の間に空白一文字を入れてください。',
}
export const E014003 = {
  No: 'E014003',
  Msg: '該当取込設定が取込実行に使用されています。{0}できません。',
}
export const E014004 = {
  No: 'E014004',
  Msg: '{0}データがあるため、{1}できません。',
}
export const E014005 = {
  No: 'E014005',
  Msg: '使用されています。変更できません。',
}
export const E014006 = {
  No: 'E014006',
  Msg: '上限数に達しました、追加できません。',
}
export const E014007 = { No: 'E014007', Msg: '{0}が入力できません。' }
export const E014008 = {
  No: 'E014008',
  Msg: '参加者情報のみの登録ができません。申込、あるいは結果情報を先に登録してください。',
}
export const E014009 = {
  No: 'E014009',
  Msg: '{0}の事業コードが一致していません。',
}
export const E014010 = {
  No: 'E014010',
  Msg: '該当{0}が使用されています。変更できません。',
}
export const E014011 = { No: 'E014011', Msg: '{0}' }
export const E014012 = { No: 'E014012', Msg: '{0}再抽出はできません。' }
export const E014013 = { No: 'E014013', Msg: '{0}' }
export const E014014 = {
  No: 'E014014',
  Msg: '保険医療機関コードが別の医療機関で登録されています。',
}
export const E014015 = { No: 'E014015', Msg: '{0}' }
export const E024001 = {
  No: 'E024001',
  Msg: '一次検診結果は、精密検査対象ではありません。',
}
export const E024002 = {
  No: 'E024002',
  Msg: '同一年度内に一次検診を既に受診しています。',
}
export const E024003 = {
  No: 'E024003',
  Msg: '精密検査の実施日は一次検診の実施日より前を入力できません。',
}
export const E024004 = {
  No: 'E024004',
  Msg: '一次検診結果が登録されていません。',
}
export const E024005 = { No: 'E024005', Msg: '検診({0})が「対象外」です。' }
export const E024006 = { No: 'E024006', Msg: '今年度検診({0})を受診済です' }
export const E024007 = {
  No: 'E024007',
  Msg: '該当検診の受診対象外です。登録できません。',
}
export const E024008 = {
  No: 'E024008',
  Msg: '一次検診日の属する年度が、画面上の年度と異なります。',
}
export const E024009 = {
  No: 'E024009',
  Msg: '精密検査日の属する年度が、画面上の年度より過去の日付です。',
}
export const E024010 = {
  No: 'E024010',
  Msg: '一次検診結果が精密検査不要ですが、精密検査が入力されています。',
}
export const E044001 = { No: 'E044001', Msg: '{0}' }
export const E064002 = {
  No: 'E064002',
  Msg: '該当項目はパッケージ固有項目のため、編集できません。',
}
export const E064003 = {
  No: 'E064003',
  Msg: '様式作成方法がデータソースの場合、データソースIDは必須です。',
}
export const E064004 = {
  No: 'E064004',
  Msg: '基本CSV出力パターンを削除できません。',
}
export const E064005 = {
  No: 'E064005',
  Msg: '追加項目コードは「1」で初めてください。',
}
export const E064006 = {
  No: 'E064006',
  Msg: '帳票項目が設定されていません。\n項目は最低１件が必要です。',
}
export const E064007 = {
  No: 'E064007',
  Msg: '追加項目のテーブルはメインテーブルに結合関係がありません。追加処理が失敗しました。',
}
export const E064008 = {
  No: 'E064008',
  Msg: '使用できない文字{0}が入力されています。',
}
export const E064009 = { No: 'E064009', Msg: '本日の日時を指定してください。' }
export const E064010 = {
  No: 'E064010',
  Msg: 'ファイル名には特殊文字が入っています。',
}
export const E064011 = { No: 'E064011', Msg: '最低一個の変数が必要です。' }
export const E064012 = {
  No: 'E064012',
  Msg: '出力形式にはEXCELまたはPDFがチェックされているため、EXCELテンプレートは必要です。',
}
export const E064013 = { No: 'E064013', Msg: 'Σ値：{0}が未設定より設定不正。' }
export const E064014 = {
  No: 'E064014',
  Msg: '{0}が追加されました。{1}ができません。',
}
export const E064015 = { No: 'E064015', Msg: '{0}を設定してください。' }
export const E064016 = {
  No: 'E064016',
  Msg: 'メインテーブルの項目は必要です。',
}
export const E064017 = {
  No: 'E064017',
  Msg: '宛名フラグをチェックした場合、項目一覧に宛名番号の項目は必要 。',
}
export const E064018 = {
  No: 'E064018',
  Msg: 'フォーマットに区分の選択は間違っています。',
}
export const E064019 = {
  No: 'E064019',
  Msg: '帳票が変更されました。再入力してください。',
}
export const E064020 = { No: 'E064020', Msg: '{0}が設定不正。' }
export const E064021 = { No: 'E064021', Msg: '{0}が存在しません。' }
export const E064022 = {
  No: 'E064022',
  Msg: '必須パラメータ[セッションシーケンス]、[ユーザーID]の値をご確認ください。',
}
export const E064023 = {
  No: 'E064023',
  Msg: '入力が正しくありません。{0}は数値型です。再入力してください。',
}
export const E064024 = {
  No: 'E064024',
  Msg: 'テーブル結合エラーです。「tm_eutablejoin」テーブルにメインテーブルが「{0}」で、「tablealias」＝「{1}」のデータが存在しません。',
}
export const E064025 = {
  No: 'E064025',
  Msg: 'tm_eutableテーブルにtablenm項目「{0}」が間違っています。',
}
export const E064026 = {
  No: 'E064026',
  Msg: 'tm_eutablejoinテーブルにketugousql項目「{0}」に別名「{1}」が間違っています。',
}
export const E064027 = {
  No: 'E064027',
  Msg: '検索条件の変数の数とSQL文の設定値が一致しない。',
}
export const E064028 = {
  No: 'E064028',
  Msg: 'EUCテーブル項目名称にはデータが無し。',
}
export const E064029 = {
  No: 'E064029',
  Msg: '同じ項目はテンプレートの複数箇所に設定できません。{0}',
}
export const E005001 = {
  No: 'E005001',
  Msg: 'プロシジャー保存エラーが発生しました。',
}
export const DOWNLOAD_NOTEXIST_ALERT = {
  No: 'A000001',
  Msg: 'ダウンロードファイルが見つかりません。',
}
export const ITEM_REQUIRE_ALERT = {
  No: 'A000002',
  Msg: '{0}を入力してください。',
}
export const A000003 = {
  No: 'A000003',
  Msg: '警告情報が登録されている方です。ご注意ください。\n警告内容：{0}',
}
export const A000004 = {
  No: 'A000004',
  Msg: '不詳の日付を入力しています。ご注意ください。',
}
export const A000005 = {
  No: 'A000005',
  Msg: 'この画面の新規権限がありません。\n次の画面へ遷移できません。',
}
export const ITEM_ILLEGAL_ALERT = {
  No: 'A000007',
  Msg: '{0}を正しく入力してください。',
}
export const A000008 = { No: 'A000008', Msg: '処理対象データがありません。' }
export const A013001 = { No: 'A013001', Msg: '抽出画面に遷移します。' }
export const A013002 = { No: 'A013002', Msg: '再抽出はできません。' }
export const A024001 = { No: 'A024001', Msg: '検診({0})が「対象外」です。' }
export const A044001 = { No: 'A044001', Msg: '{0}' }
export const A060001 = { No: 'A060001', Msg: '{0}が{1}に一致しません。' }
export const A060002 = {
  No: 'A060002',
  Msg: '{0}は複数項目にチェックされました。',
}
export const A060003 = {
  No: 'A060003',
  Msg: '繰り返し値の設定は誤りがありますので、自動的に適当な値「{0}」に調整していただきました。',
}
export const A063001 = {
  No: 'A063001',
  Msg: '該当するデータがありません。\n検索条件を変更して再検索してください。',
}
export const LOGIN_OK_INFO = { No: 'I000001', Msg: 'ログイン成功しました。' }
export const LOGOUT_OK_INFO = { No: 'I000002', Msg: 'ログアウト成功しました。' }
export const DOWNLOAD_OK_INFO = {
  No: 'I000003',
  Msg: 'ダウンロード処理が完了しました。',
}
export const SAVE_OK_INFO = { No: 'I000004', Msg: '登録処理が完了しました。' }
export const DELETE_OK_INFO = { No: 'I000005', Msg: '削除処理が完了しました。' }
export const UPLOAD_OK_INFO = {
  No: 'I000006',
  Msg: 'アップロード処理が完了しました。',
}
export const I000007 = { No: 'I000007', Msg: 'パスワードを変更しました。' }
export const SERVER_START_INFO = {
  No: 'I000008',
  Msg: 'サーバーが起動しました。',
}
export const I000009 = { No: 'I000009', Msg: 'アカウントの{0}が完了しました。' }
export const I000010 = { No: 'I000010', Msg: 'チェック処理は完了しました。' }
export const I000012 = { No: 'I000012', Msg: '仮保存処理は完了しました。' }
export const I011001 = {
  No: 'I011001',
  Msg: '照会が完了しました。\n照会結果は{0}件です。\n\n※総対象件数が{1}件を超えています。\n他の候補者を照会したい場合、検索条件を追加し\n再照会を行ってください。',
}
export const I011002 = {
  No: 'I011002',
  Msg: '照会が完了しました。\n照会結果は{0}件です。',
}
export const I011003 = {
  No: 'I011003',
  Msg: '登録内容の送信が正常終了しました。',
}
export const I011004 = {
  No: 'I011004',
  Msg: '登録内容の送信が異常終了しました。\n時間を置いて再送信をおこなってください。',
}
export const I060001 = { No: 'I060001', Msg: '編集完了しました。' }
export const I060002 = {
  No: 'I060002',
  Msg: 'セルをクリックして項目内容を設定してください。',
}
export const SAVE_CONFIRM = {
  No: 'C001001',
  Msg: '登録処理を行います。\nよろしいですか？',
}
export const CLOSE_CONFIRM = {
  No: 'C001002',
  Msg: '登録処理を行っていません。\n画面を閉じてもよろしいですか？\n（入力はキャンセルされます）',
}
export const MOVE_CONFIRM = {
  No: 'C001003',
  Msg: '登録処理を行っていません。\nこの操作を続いてもよろしいですか？',
}
export const DELETE_CONFIRM = {
  No: 'C001004',
  Msg: '削除処理を行います。\nよろしいですか？',
}
export const CLEAR_CONFIRM = {
  No: 'C001005',
  Msg: '入力値がクリアされます。\nよろしいですか？',
}
export const REFRESH_CONFIRM = {
  No: 'C001006',
  Msg: '画面上のデータを再表示します。\nよろしいですか？',
}
export const LOGIC_DELETE_CONFIRM = {
  No: 'C001007',
  Msg: '選択データを削除します。\nよろしいですか？\n（登録処理を行うまで削除は反映されません）',
}
export const RESEARCH_CONFIRM = {
  No: 'C001008',
  Msg: '登録処理を行っていません。\n再検索してもよろしいですか？\n（入力はキャンセルされます）',
}
export const C001009 = {
  No: 'C001009',
  Msg: 'アカウントの{0}を行います。\nよろしいですか？',
}
export const C001010 = {
  No: 'C001010',
  Msg: '登録処理を行っていません。\n画面遷移してもよろしいですか？\n（入力はキャンセルされます）',
}
export const C001011 = {
  No: 'C001011',
  Msg: 'この処理は時間がかかる可能性があります。よろしいですか？',
}
export const C001012 = {
  No: 'C001012',
  Msg: '登録支所へ更新権限がないデータが存在します。\n一部のみ{0}してもよろしいですか？',
}
export const C001013 = {
  No: 'C001013',
  Msg: 'チェック処理を行います。\nよろしいですか？\n（旧エラー情報はクリアされます）',
}
export const C001014 = {
  No: 'C001014',
  Msg: '取込実行処理を行います。\nよろしいですか？',
}
export const C001015 = {
  No: 'C001015',
  Msg: '【正常】{0}件\n【情報】{1}件\n【警告】{2}件\n【エラー】{3}件\n正常、情報、警告のデータのみ処理を継続しますか？\n（登録後エラーデータも削除します）',
}
export const C001016 = {
  No: 'C001016',
  Msg: '仮保存処理を行います。\nよろしいですか？',
}
export const C001017 = {
  No: 'C001017',
  Msg: '最後のデータを削除したら未処理一覧にも残りません。\n削除してもよろしいですか？',
}
export const C001018 = {
  No: 'C001018',
  Msg: '連携処理を開始します。よろしいでしょうか？\n処理状況や結果は、ログ情報管理画面を確認してください',
}
export const C001019 = {
  No: 'C001019',
  Msg: 'チェックを外すと登録時に削除されます。よろしいですか？',
}
export const C001020 = {
  No: 'C001020',
  Msg: '{0} さんの情報を引き継ぎますか？',
}
export const C011001 = {
  No: 'C011001',
  Msg: '登録処理を行います。よろしいですか？\n※以下対象者の基本情報（世帯）も更新されます。\n{0}',
}
export const C011002 = {
  No: 'C011002',
  Msg: '事業コード管理を設定します。よろしいですか？',
}
export const C011003 = {
  No: 'C011003',
  Msg: 'チェックを外すと登録時に削除されます。よろしいですか？',
}
export const C011004 = {
  No: 'C011004',
  Msg: '定員オーバーになります。\n申込を続けますか？',
}
export const C011005 = {
  No: 'C011005',
  Msg: '申込登録出来ない{0}がいます。\n登録を続けますか？',
}
export const C011006 = {
  No: 'C011006',
  Msg: '住登外者宛名番号管理機能に住登外者宛名基本情報の\n照会依頼を送信します。よろしいですか？',
}
export const C011007 = {
  No: 'C011007',
  Msg: '住登外者情報入力画面に遷移します。\n照会条件に設定した値を引き継ぎますか？',
}
export const C011008 = {
  No: 'C011008',
  Msg: '実施検診種別にチェックをつけていません。\n登録しますか？',
}
export const C011009 = {
  No: 'C011009',
  Msg: '宛名番号「{0}」で登録します。ｎよろしいですか？',
}
export const C011010 = {
  No: 'C011010',
  Msg: '宛名番号が付番されていないため、\n住登外者宛名番号管理機能に付番依頼を送信します。\nよろしいですか？※宛名番号付番後に登録します。',
}
export const C021001 = {
  No: 'C021001',
  Msg: 'この画面は年度切替画面です。処理を続けますか？',
}
export const C021002 = {
  No: 'C021002',
  Msg: '一時対象サインデータを作成しますか？',
}
export const C021003 = {
  No: 'C021003',
  Msg: '日程番号を変更します。よろしいですか？',
}
export const C021004 = {
  No: 'C021004',
  Msg: '受診済データですが、クリアしてもよろしいですか？',
}
export const C021005 = {
  No: 'C021005',
  Msg: '料金エラーデータがあるため、登録処理を行います。よろしいですか？',
}
export const DOWNLOAD_CONFIRM = {
  No: 'C002001',
  Msg: 'ダウンロード処理を行います。\nよろしいですか？',
}
export const OUTPUT_EXCEL_CONFIRM = {
  No: 'C002002',
  Msg: 'Excel出力処理を行います。\nよろしいですか？',
}
export const UPLOAD_CONFIRM = {
  No: 'C002003',
  Msg: 'アップロード処理を行います。\nよろしいですか？',
}
export const OUTPUT_EXCEL_UNSAVED_CONFIRM = {
  No: 'C002004',
  Msg: '登録処理を行っていません。\nExcel出力処理を行います。\nよろしいですか？',
}
export const C002005 = {
  No: 'C002005',
  Msg: '画面情報を上書きします。\nよろしいですか？',
}
export const C002006 = {
  No: 'C002006',
  Msg: '登録処理を行っていません。\n画面情報を上書きします。\nよろしいですか？',
}
export const C002007 = {
  No: 'C002007',
  Msg: 'エラーリストの出力を行います。\nよろしいですか？',
}
export const C003001 = {
  No: 'C003001',
  Msg: 'パスワードの有効期限まであと{0}日です。パスワードを変更しますか？',
}
export const LOGOUT_CONFIRM = {
  No: 'C003002',
  Msg: 'ログアウトします。\nよろしいですか？',
}
export const C003003 = {
  No: 'C003003',
  Msg: '{0}画面へ遷移します。\nよろしいですか？',
}
export const C003004 = {
  No: 'C003004',
  Msg: 'お気に入りに追加します。\nよろしいですか？',
}
export const C003005 = {
  No: 'C003005',
  Msg: 'お気に入りから削除します。\nよろしいですか？',
}
export const C003006 = {
  No: 'C003006',
  Msg: '登録処理を行っていません。\n{0}画面へ遷移します。\nよろしいですか？',
}
export const C063001 = {
  No: 'C063001',
  Msg: '別様式とサブ様式を一括で削除します。\nよろしいですか？',
}
export const C063002 = {
  No: 'C063002',
  Msg: '選択された対象者を出力対象に設定して\nよろしいでしょうか？',
}
export const C063003 = {
  No: 'C063003',
  Msg: '選択された出力対象者データを破棄してもよろしいですか？',
}
export const K000001 = {
  No: 'K000001',
  Msg: '{0}\n必要な場合、{1}を変更してください。',
}
export const K013001 = { No: 'K013001', Msg: '{0}個別抽出しますか？' }
export const K013002 = { No: 'K013002', Msg: '{0}抽出しますか？' }
export const K013003 = { No: 'K013003', Msg: '{0}' }
export const K013004 = {
  No: 'K013004',
  Msg: '過去に抽出したデータが存在します。\n過去のデータを元に発行しますか？\n（いいえの場合、抽出画面に遷移します）',
}
export const K013005 = {
  No: 'K013005',
  Msg: '「過去に抽出したデータが存在します。\n過去のデータを元に発行しますか？\n（いいえの場合、再抽出はできません）」',
}
export const K013006 = { No: 'K013006', Msg: '{0}\n抽出を継続しますか？' }
export const K024001 = {
  No: 'K024001',
  Msg: '一次検診結果は、精密検査対象ではありません。よろしいですか？',
}
export const K024002 = {
  No: 'K024002',
  Msg: '一次検診結果が登録されていません。よろしいですか？',
}
export const K024003 = {
  No: 'K024003',
  Msg: '該当検診の受診対象外です。よろしいですか？',
}
export const K024004 = {
  No: 'K024004',
  Msg: '一次検診日の属する年度が、画面上の年度と異なります。よろしいですか？',
}
export const K024005 = {
  No: 'K024005',
  Msg: '精密検査日の属する年度が、画面上の年度より過去の日付です。よろしいですか？',
}
export const K024006 = {
  No: 'K024006',
  Msg: '一次検診結果が精密検査不要ですが、精密検査が入力されています。よろしいですか？',
}
export const J000001 = {
  No: 'J000001',
  Msg: '取込実行処理は完了しました。（登録件数：{0}）',
}
export const J024001 = {
  No: 'J024001',
  Msg: '対象者は、予約申込していません。',
}
