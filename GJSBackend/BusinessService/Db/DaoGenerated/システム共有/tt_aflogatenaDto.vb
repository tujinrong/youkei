' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             宛名番号ログテーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tt_aflogatenaDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_aflogatena"
        Public Property atenalogseq As Long                     '宛名番号ログシーケンス
        Public Property sessionseq As Long                      'セッションシーケンス
        Public Property atenano As String                       '宛名番号
        Public Property pnouseflg As Boolean                       '個人番号操作フラグ
        Public Property usekbn As String                        '操作区分
        Public Property msg As String                          'メッセージ
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
    End Class
End Namespace
