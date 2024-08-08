' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: メッセージ定義
'             
'作成日　　 : 2024.07.17
'作成者　　 : AIPlus
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Enum EnumMessage
        ''' <summary>
        ''' サーバーとの接続に失敗しました。
        ''' </summary>
        CM_HTTP_ERROR
        ''' <summary>
        ''' 予期せぬエラーが発生しました。
        ''' </summary>
        CM_FATAL_ERROR
        ''' <summary>
        ''' キー重複エラーが発生しました。
        ''' </summary>
        CM_KEYDUPLICATE_ERROR
        ''' <summary>
        ''' デッドロックエラーが発生しました。
        ''' </summary>
        CM_DEADLOCK_ERROR
        ''' <summary>
        ''' DB接続エラーが発生しました。
        ''' </summary>
        CM_DBCONN_ERROR
        ''' <summary>
        ''' タイムアウトエラーが発生しました。
        ''' </summary>
        CM_DBTIMEOUT_ERROR
        ''' <summary>
        ''' データを更新できません。\n他のユーザーによって変更された可能性があります。
        ''' </summary>
        CM_EXCLUSIVE_ERROR
        ''' <summary>
        ''' 認証エラーが発生しました。
        ''' </summary>
        CM_AUTH_ERROR
        ''' <summary>
        ''' 長時間未操作のため、再びログインしてください。
        ''' </summary>
        CM_LOGINTIMEOUT_ERROR
        ''' <summary>
        ''' {0}を入力してください。
        ''' </summary>
        ITEM_REQUIRE_ERROR
        ''' <summary>
        ''' {0}と一致していません。
        ''' </summary>
        ITEM_NOTEQUAL_ERROR
        ''' <summary>
        ''' {0}を正しく入力してください。
        ''' </summary>
        ITEM_ILLEGAL_ERROR
        ''' <summary>
        ''' {0}と一致しています。
        ''' </summary>
        ITEM_EQUAL_ERROR
        ''' <summary>
        ''' {0}を選択してください。
        ''' </summary>
        ITEM_SELECTREQUIRE_ERROR
        ''' <summary>
        ''' {0}の範囲が不正です。
        ''' </summary>
        ITEM_RANGE_ERROR
        ''' <summary>
        ''' 全角文字のみ入力項目です。
        ''' </summary>
        E001007
        ''' <summary>
        ''' {0}が重複しています。
        ''' </summary>
        E001008
        ''' <summary>
        ''' {0}で入力してください。
        ''' </summary>
        E001009
        ''' <summary>
        ''' 桁数上限({0}文字)を超えています。
        ''' </summary>
        E001010
        ''' <summary>
        ''' 現在、画面起動中です。{0}を表示出来ません。
        ''' </summary>
        E001011
        ''' <summary>
        ''' アクセス権限がない為、{0}を表示出来ません。
        ''' </summary>
        E001012
        ''' <summary>
        ''' 入力値が不正です。確認してください。
        ''' </summary>
        E001013
        ''' <summary>
        ''' {0}データが存在しないため、データを{1}できません。
        ''' </summary>
        DATA_NOTEXIST_ERROR
        ''' <summary>
        ''' この処理は時間がかかり過ぎますので、検索条件を増やしてください。
        ''' </summary>
        E002002
        ''' <summary>
        ''' 既に使用されている{0}です。
        ''' </summary>
        E002003
        ''' <summary>
        ''' 出力項目マスタに該当連携番号のデータがないため、出力用SQL文生成できません。
        ''' </summary>
        E002004
        ''' <summary>
        ''' すでに同じ{0}が存在しています。
        ''' </summary>
        MSG_JIGYO_YOYAKU_TYOFUKU_DATA
        ''' <summary>
        ''' アップロードは失敗しました。
        ''' </summary>
        UPLOAD_ERROR
        ''' <summary>
        ''' 指定したファイルが見つかりませんでした。
        ''' </summary>
        FILE_NOTEXIST_ERROR
        ''' <summary>
        ''' ダウンロードファイルが見つかりません。
        ''' </summary>
        DOWNLOAD_NOTEXIST_ERROR
        ''' <summary>
        ''' 指定したファイルの拡子がサポートしていないため、アップロードできません。
        ''' </summary>
        FILE_TYPE_ERROR
        ''' <summary>
        ''' {0}に存在しません。
        ''' </summary>
        E003005
        ''' <summary>
        ''' {0}が不正です。
        ''' </summary>
        E003006
        ''' <summary>
        ''' {0}ファイルを指定してください。
        ''' </summary>
        E003007
        ''' <summary>
        ''' {0}と{1}は一致していません。
        ''' </summary>
        E003008
        ''' <summary>
        ''' このユーザーアカウントは有効期限範囲外です。管理者までお問い合わせください。
        ''' </summary>
        USER_ACCOUNT_OUT_ERROR
        ''' <summary>
        ''' このユーザーのパスワードは有効期限範囲外です。管理者までお問い合わせください。
        ''' </summary>
        USER_PWD_OUT_ERROR
        ''' <summary>
        ''' ユーザーＩＤまたはパスワードが間違っています。正しいユーザーＩＤおよびパスワードを入力してください。
        ''' </summary>
        USER_LOGIN_ERROR
        ''' <summary>
        ''' このユーザーアカウントはロックされました。管理者までお問い合わせください。
        ''' </summary>
        USER_LOCK_ERROR
        ''' <summary>
        ''' パスワードは{0}を含めてください。
        ''' </summary>
        E004005
        ''' <summary>
        ''' {0}は{1}に存在しません。
        ''' </summary>
        E004006
        ''' <summary>
        ''' {0}は失敗しました。
        ''' </summary>
        E004007
        ''' <summary>
        ''' 登録支所へ更新・削除権限がありません。
        ''' </summary>
        E004008
        ''' <summary>
        ''' 該当プロシージャが使用されています。削除できません。
        ''' </summary>
        E004009
        ''' <summary>
        ''' タスクが実行中の場合、即時実行・変更・削除ができません。
        ''' </summary>
        E004010
        ''' <summary>
        ''' ユ-ザ領域コ-ドの上限に達しました、追加できません。\n(設定できるコードの最大値：{0})
        ''' </summary>
        E004011
        ''' <summary>
        ''' {0}のデータです。コードを「{1}-{2}」の範囲で設定したください。
        ''' </summary>
        E004012
        ''' <summary>
        ''' 該当{0}が使用されています。削除できません。
        ''' </summary>
        E014001
        ''' <summary>
        ''' 氏と名の間に空白一文字を入れてください。
        ''' </summary>
        E014002
        ''' <summary>
        ''' 該当取込設定が取込実行に使用されています。{0}できません。
        ''' </summary>
        E014003
        ''' <summary>
        ''' {0}データがあるため、{1}できません。
        ''' </summary>
        E014004
        ''' <summary>
        ''' 使用されています。変更できません。
        ''' </summary>
        E014005
        ''' <summary>
        ''' 上限数に達しました、追加できません。
        ''' </summary>
        E014006
        ''' <summary>
        ''' {0}が入力できません。
        ''' </summary>
        E014007
        ''' <summary>
        ''' 参加者情報のみの登録ができません。申込、あるいは結果情報を先に登録してください。
        ''' </summary>
        E014008
        ''' <summary>
        ''' 申込と結果情報の事業コードが一致していません。
        ''' </summary>
        E014009
        ''' <summary>
        ''' 該当{0}が使用されています。変更できません。
        ''' </summary>
        E014010
        ''' <summary>
        ''' {0}
        ''' </summary>
        E014011
        ''' <summary>
        ''' {0}再抽出はできません。
        ''' </summary>
        E014012
        ''' <summary>
        ''' {0}
        ''' </summary>
        E014013
        ''' <summary>
        ''' 保険医療機関コードが別の医療機関で登録されています。
        ''' </summary>
        E014014
        ''' <summary>
        ''' 一次検診結果は、精密検査対象ではありません。
        ''' </summary>
        E024001
        ''' <summary>
        ''' 同一年度内に一次検診を既に受診しています。
        ''' </summary>
        E024002
        ''' <summary>
        ''' 精密検査の実施日は一次検診の実施日より前を入力できません。
        ''' </summary>
        E024003
        ''' <summary>
        ''' 一次検診結果が登録されていません。
        ''' </summary>
        E024004
        ''' <summary>
        ''' 検診({0})が「対象外」です。
        ''' </summary>
        E024005
        ''' <summary>
        ''' 今年度検診({0})を受診済です
        ''' </summary>
        E024006
        ''' <summary>
        ''' 該当検診の受診対象外です。登録できません。
        ''' </summary>
        E024007
        ''' <summary>
        ''' 一次検診日の属する年度が、画面上の年度と異なります。
        ''' </summary>
        E024008
        ''' <summary>
        ''' 精密検査日の属する年度が、画面上の年度より過去の日付です。
        ''' </summary>
        E024009
        ''' <summary>
        ''' 一次検診結果が精密検査不要ですが、精密検査が入力されています。
        ''' </summary>
        E024010
        ''' <summary>
        ''' {0}
        ''' </summary>
        E044001
        ''' <summary>
        ''' 該当項目はパッケージ固有項目のため、編集できません。
        ''' </summary>
        E064002
        ''' <summary>
        ''' 様式作成方法がデータソースの場合、データソースIDは必須です。
        ''' </summary>
        E064003
        ''' <summary>
        ''' 基本CSV出力パターンを削除できません。
        ''' </summary>
        E064004
        ''' <summary>
        ''' 追加項目コードは「1」で初めてください。
        ''' </summary>
        E064005
        ''' <summary>
        ''' 帳票項目が設定されていません。\n項目は最低１件が必要です。
        ''' </summary>
        E064006
        ''' <summary>
        ''' 追加項目のテーブルはメインテーブルに結合関係がありません。追加処理が失敗しました。
        ''' </summary>
        E064007
        ''' <summary>
        ''' 使用できない文字{0}が入力されています。
        ''' </summary>
        E064008
        ''' <summary>
        ''' 本日の日時を指定してください。
        ''' </summary>
        E064009
        ''' <summary>
        ''' ファイル名には特殊文字が入っています。
        ''' </summary>
        E064010
        ''' <summary>
        ''' 最低一個の変数が必要です。
        ''' </summary>
        E064011
        ''' <summary>
        ''' 出力形式にはEXCELまたはPDFがチェックされているため、EXCELテンプレートは必要です。
        ''' </summary>
        E064012
        ''' <summary>
        ''' Σ値：{0}が未設定より設定不正。
        ''' </summary>
        E064013
        ''' <summary>
        ''' {0}が追加されました。{1}ができません。
        ''' </summary>
        E064014
        ''' <summary>
        ''' {0}を設定してください。
        ''' </summary>
        E064015
        ''' <summary>
        ''' メインテーブルの項目は必要です。
        ''' </summary>
        E064016
        ''' <summary>
        ''' 宛名フラグをチェックした場合、項目一覧に宛名番号の項目は必要 。
        ''' </summary>
        E064017
        ''' <summary>
        ''' フォーマットに区分の選択は間違っています。
        ''' </summary>
        E064018
        ''' <summary>
        ''' プロシジャー保存エラーが発生しました。
        ''' </summary>
        E005001
        ''' <summary>
        ''' ダウンロードファイルが見つかりません。
        ''' </summary>
        DOWNLOAD_NOTEXIST_ALERT
        ''' <summary>
        ''' {0}を入力してください。
        ''' </summary>
        ITEM_REQUIRE_ALERT
        ''' <summary>
        ''' 警告情報が登録されている方です。ご注意ください。\n警告内容：{0}
        ''' </summary>
        A000003
        ''' <summary>
        ''' 不詳の日付を入力しています。ご注意ください。
        ''' </summary>
        A000004
        ''' <summary>
        ''' この画面の新規権限がありません。\n次の画面へ遷移できません。
        ''' </summary>
        A000005
        ''' <summary>
        ''' {0}を正しく入力してください。
        ''' </summary>
        ITEM_ILLEGAL_ALERT
        ''' <summary>
        ''' 処理対象データがありません。
        ''' </summary>
        A000008
        ''' <summary>
        ''' 抽出画面に遷移します。
        ''' </summary>
        A013001
        ''' <summary>
        ''' 再抽出はできません。
        ''' </summary>
        A013002
        ''' <summary>
        ''' 検診({0})が「対象外」です。
        ''' </summary>
        A024001
        ''' <summary>
        ''' {0}
        ''' </summary>
        A044001
        ''' <summary>
        ''' {0}が{1}に一致しません。
        ''' </summary>
        A060001
        ''' <summary>
        ''' {0}は複数項目にチェックされました。
        ''' </summary>
        A060002
        ''' <summary>
        ''' 繰り返し値の設定は誤りがありますので、自動的に適当な値「{0}」に調整していただきました。
        ''' </summary>
        A060003
        ''' <summary>
        ''' 該当するデータがありません。\n検索条件を変更して再検索してください。
        ''' </summary>
        A063001
        ''' <summary>
        ''' ログイン成功しました。
        ''' </summary>
        LOGIN_OK_INFO
        ''' <summary>
        ''' ログアウト成功しました。
        ''' </summary>
        LOGOUT_OK_INFO
        ''' <summary>
        ''' ダウンロード処理が完了しました。
        ''' </summary>
        DOWNLOAD_OK_INFO
        ''' <summary>
        ''' 登録処理が完了しました。
        ''' </summary>
        SAVE_OK_INFO
        ''' <summary>
        ''' 削除処理が完了しました。
        ''' </summary>
        DELETE_OK_INFO
        ''' <summary>
        ''' アップロード処理が完了しました。
        ''' </summary>
        UPLOAD_OK_INFO
        ''' <summary>
        ''' パスワードを変更しました。
        ''' </summary>
        I000007
        ''' <summary>
        ''' サーバーが起動しました。
        ''' </summary>
        SERVER_START_INFO
        ''' <summary>
        ''' アカウントの{0}が完了しました。
        ''' </summary>
        I000009
        ''' <summary>
        ''' チェック処理は完了しました。
        ''' </summary>
        I000010
        ''' <summary>
        ''' 仮保存処理は完了しました。
        ''' </summary>
        I000012
        ''' <summary>
        ''' 照会が完了しました。\n照会結果は{0}件です。\n\n※総対象件数が{1}件を超えています。\n他の候補者を照会したい場合、検索条件を追加し\n再照会を行ってください。
        ''' </summary>
        I011001
        ''' <summary>
        ''' 照会が完了しました。\n照会結果は{0}件です。
        ''' </summary>
        I011002
        ''' <summary>
        ''' 編集完了しました。
        ''' </summary>
        I060001
        ''' <summary>
        ''' セルをクリックして項目内容を設定してください。
        ''' </summary>
        I060002
        ''' <summary>
        ''' 登録処理を行います。\nよろしいですか？
        ''' </summary>
        SAVE_CONFIRM
        ''' <summary>
        ''' 登録処理を行っていません。\n画面を閉じてもよろしいですか？\n（入力はキャンセルされます）
        ''' </summary>
        CLOSE_CONFIRM
        ''' <summary>
        ''' 登録処理を行っていません。\nこの操作を続いてもよろしいですか？
        ''' </summary>
        MOVE_CONFIRM
        ''' <summary>
        ''' 削除処理を行います。\nよろしいですか？
        ''' </summary>
        DELETE_CONFIRM
        ''' <summary>
        ''' 入力値がクリアされます。\nよろしいですか？
        ''' </summary>
        CLEAR_CONFIRM
        ''' <summary>
        ''' 画面上のデータを再表示します。\nよろしいですか？
        ''' </summary>
        REFRESH_CONFIRM
        ''' <summary>
        ''' 選択データを削除します。\nよろしいですか？\n（登録処理を行うまで削除は反映されません）
        ''' </summary>
        LOGIC_DELETE_CONFIRM
        ''' <summary>
        ''' 登録処理を行っていません。\n再検索してもよろしいですか？\n（入力はキャンセルされます）
        ''' </summary>
        RESEARCH_CONFIRM
        ''' <summary>
        ''' アカウントの{0}を行います。\nよろしいですか？
        ''' </summary>
        C001009
        ''' <summary>
        ''' 登録処理を行っていません。\n画面遷移してもよろしいですか？\n（入力はキャンセルされます）
        ''' </summary>
        C001010
        ''' <summary>
        ''' この処理は時間がかかる可能性があります。よろしいですか？
        ''' </summary>
        C001011
        ''' <summary>
        ''' 登録支所へ更新権限がないデータが存在します。\n一部のみ{0}してもよろしいですか？
        ''' </summary>
        C001012
        ''' <summary>
        ''' チェック処理を行います。\nよろしいですか？\n（旧エラー情報はクリアされます）
        ''' </summary>
        C001013
        ''' <summary>
        ''' 取込実行処理を行います。\nよろしいですか？
        ''' </summary>
        C001014
        ''' <summary>
        ''' 【正常】{0}件\n【情報】{1}件\n【警告】{2}件\n【エラー】{3}件\n正常、情報、警告のデータのみ処理を継続しますか？\n（登録後エラーデータも削除します）
        ''' </summary>
        C001015
        ''' <summary>
        ''' 仮保存処理を行います。\nよろしいですか？
        ''' </summary>
        C001016
        ''' <summary>
        ''' 最後のデータを削除したら未処理一覧にも残りません。\n削除してもよろしいですか？
        ''' </summary>
        C001017
        ''' <summary>
        ''' 連携処理を開始します。よろしいでしょうか？\n処理状況や結果は、ログ情報管理画面を確認してください
        ''' </summary>
        C001018
        ''' <summary>
        ''' チェックを外すと登録時に削除されます。よろしいですか？
        ''' </summary>
        C001019
        ''' <summary>
        ''' 登録処理を行います。よろしいですか？\n※以下対象者の基本情報（世帯）も更新されます。\n{0}
        ''' </summary>
        C011001
        ''' <summary>
        ''' 事業コード管理を設定します。よろしいですか？
        ''' </summary>
        C011002
        ''' <summary>
        ''' チェックを外すと登録時に削除されます。よろしいですか？
        ''' </summary>
        C011003
        ''' <summary>
        ''' 定員オーバーになります。\n申込を続けますか？
        ''' </summary>
        C011004
        ''' <summary>
        ''' 申込登録出来ない{0}がいます。\n登録を続けますか？
        ''' </summary>
        C011005
        ''' <summary>
        ''' 住登外者宛名番号管理機能に住登外者宛名基本情報の\n照会依頼を送信します。よろしいですか？
        ''' </summary>
        C011006
        ''' <summary>
        ''' 住登外者情報入力画面に遷移します。\n照会条件に設定した値を引き継ぎますか？
        ''' </summary>
        C011007
        ''' <summary>
        ''' 実施検診種別にチェックをつけていません。\n登録しますか？
        ''' </summary>
        C011008
        ''' <summary>
        ''' この画面は年度切替画面です。処理を続けますか？
        ''' </summary>
        C021001
        ''' <summary>
        ''' 一時対象サインデータを作成しますか？
        ''' </summary>
        C021002
        ''' <summary>
        ''' 日程番号を変更します。よろしいですか？
        ''' </summary>
        C021003
        ''' <summary>
        ''' 受診済データですが、クリアしてもよろしいですか？
        ''' </summary>
        C021004
        ''' <summary>
        ''' 料金エラーデータがあるため、登録処理を行います。よろしいですか？
        ''' </summary>
        C021005
        ''' <summary>
        ''' ダウンロード処理を行います。\nよろしいですか？
        ''' </summary>
        DOWNLOAD_CONFIRM
        ''' <summary>
        ''' Excel出力処理を行います。\nよろしいですか？
        ''' </summary>
        OUTPUT_EXCEL_CONFIRM
        ''' <summary>
        ''' アップロード処理を行います。\nよろしいですか？
        ''' </summary>
        UPLOAD_CONFIRM
        ''' <summary>
        ''' 登録処理を行っていません。\nExcel出力処理を行います。\nよろしいですか？
        ''' </summary>
        OUTPUT_EXCEL_UNSAVED_CONFIRM
        ''' <summary>
        ''' 画面情報を上書きします。\nよろしいですか？
        ''' </summary>
        C002005
        ''' <summary>
        ''' 登録処理を行っていません。\n画面情報を上書きします。\nよろしいですか？
        ''' </summary>
        C002006
        ''' <summary>
        ''' エラーリストの出力を行います。\nよろしいですか？
        ''' </summary>
        C002007
        ''' <summary>
        ''' パスワードの有効期限まであと{0}日です。パスワードを変更しますか？
        ''' </summary>
        C003001
        ''' <summary>
        ''' ログアウトします。\nよろしいですか？
        ''' </summary>
        LOGOUT_CONFIRM
        ''' <summary>
        ''' {0}画面へ遷移します。\nよろしいですか？
        ''' </summary>
        C003003
        ''' <summary>
        ''' お気に入りに追加します。\nよろしいですか？
        ''' </summary>
        C003004
        ''' <summary>
        ''' お気に入りから削除します。\nよろしいですか？
        ''' </summary>
        C003005
        ''' <summary>
        ''' 登録処理を行っていません。\n{0}画面へ遷移します。\nよろしいですか？
        ''' </summary>
        C003006
        ''' <summary>
        ''' 別様式とサブ様式を一括で削除します。\nよろしいですか？
        ''' </summary>
        C063001
        ''' <summary>
        ''' 選択された対象者を出力対象に設定して\nよろしいでしょうか？
        ''' </summary>
        C063002
        ''' <summary>
        ''' 選択された出力対象者データを破棄してもよろしいですか？
        ''' </summary>
        C063003
        ''' <summary>
        ''' {0}\n必要な場合、{1}を変更してください。
        ''' </summary>
        K000001
        ''' <summary>
        ''' {0}個別抽出しますか？
        ''' </summary>
        K013001
        ''' <summary>
        ''' {0}抽出しますか？
        ''' </summary>
        K013002
        ''' <summary>
        ''' {0}
        ''' </summary>
        K013003
        ''' <summary>
        ''' 過去に抽出したデータが存在します。\n過去のデータを元に発行しますか？\n（いいえの場合、抽出画面に遷移します）
        ''' </summary>
        K013004
        ''' <summary>
        ''' 「過去に抽出したデータが存在します。\n過去のデータを元に発行しますか？\n（いいえの場合、再抽出はできません）」
        ''' </summary>
        K013005
        ''' <summary>
        ''' 一次検診結果は、精密検査対象ではありません。よろしいですか？
        ''' </summary>
        K024001
        ''' <summary>
        ''' 一次検診結果が登録されていません。よろしいですか？
        ''' </summary>
        K024002
        ''' <summary>
        ''' 該当検診の受診対象外です。よろしいですか？
        ''' </summary>
        K024003
        ''' <summary>
        ''' 一次検診日の属する年度が、画面上の年度と異なります。よろしいですか？
        ''' </summary>
        K024004
        ''' <summary>
        ''' 精密検査日の属する年度が、画面上の年度より過去の日付です。よろしいですか？
        ''' </summary>
        K024005
        ''' <summary>
        ''' 一次検診結果が精密検査不要ですが、精密検査が入力されています。よろしいですか？
        ''' </summary>
        K024006
        ''' <summary>
        ''' 取込実行処理は完了しました。（登録件数：{0}）
        ''' </summary>
        J000001
        ''' <summary>
        ''' 対象者は、予約申込していません。
        ''' </summary>
        J024001
    End Enum
End Namespace
