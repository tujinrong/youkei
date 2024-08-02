' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: 権限管理
'
' 作成日　　: 2024.07.10
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class GamenCommonModel
        Public Property menuid As String        'メニューID
        Public Property addflg As Boolean          '追加権限フラグ
        Public Property updateflg As Boolean       '修正権限フラグ
        Public Property deleteflg As Boolean       '削除権限フラグ
        Public Property personalnoflg As Boolean   '個人番号利用権限フラグ
    End Class
    Public Class MenuModel
        Inherits GamenCommonModel
        Public Property path As String            'パス(URL用)
        Public Property parentid As String        '親メニューID
        Public Property isfolder As Boolean          'フォルダフラグ(フォルダの場合：true　画面の場合:false)
        Public Property menuseq As Integer            '全メニュー内シーケンス
        Public Property menuname As String        'メニュー表示名称(画面名称共有)
        Public Property paramkeisyoflg As Boolean    '検索パラメーター継承フラグ
        Public Property enabled As Boolean           'アクセス権限(権限がない場合:false)
    End Class
    Public Class GamenModel
        Inherits GamenCommonModel
        Public Property programkbn As Enumプログラム区分     'プログラム区分
    End Class
    Public Class ProgramModel
        Public Property kinoid As String           '機能ID
        Public Property menuids As List(Of String)    'メニューIDリスト
    End Class
End Namespace
