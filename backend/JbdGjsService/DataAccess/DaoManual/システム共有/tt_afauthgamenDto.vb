' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             画面権限テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service
    Public Class tt_afauthgamenDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afauthgamen"
        Public Property rolekbn As Enumロール区分               'ロール区分
        Public Property roleid As String                        'ロールID
        Public Property kinoid As String                          '機能ID
        Public Property programkbn As Enumプログラム区分        'プログラム区分
        Public Property addflg As Boolean                          '追加フラグ
        Public Property updateflg As Boolean                       '修正フラグ
        Public Property deleteflg As Boolean                       '削除フラグ
        Public Property personalnoflg As Boolean                   '個人番号利用フラグ
        Public Property keisyoflg As Boolean                      '継承フラグ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
