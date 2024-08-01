' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             メニューマスタ
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tm_afmenuDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tm_afmenu"
        Public Property kinoid As String                        '機能ID
        Public Property oyamenuid As String                     '親メニューID
        Public Property orderseq As Integer                         '並びシーケンス
        Public Property paramkeisyoflg As Boolean                  '検索パラメーター継承フラグ
        Public Property addctrlflg As Boolean                      '追加権限制御フラグ
        Public Property updctrlflg As Boolean                      '修正権限制御フラグ
        Public Property delctrlflg As Boolean                      '削除権限制御フラグ
        Public Property pnousectrlflg As Boolean                   '個人番号利用権限制御フラグ
    End Class
End Namespace
