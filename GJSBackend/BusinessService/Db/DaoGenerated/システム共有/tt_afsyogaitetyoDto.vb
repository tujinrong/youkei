' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             【障害者福祉】身体障害者手帳等情報テーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace Jbd.Gjs.Db
    Public Class tt_afsyogaitetyoDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afsyogaitetyo"
        Public Property atenano As String                       '宛名番号
        Public Property henkanymd As String                    '返還日
        Public Property sikakujotaicd As String                 '資格状態コード
        Public Property syokaikofuymd As String                '初回交付日
        Public Property tetyono As String                      '手帳番号
        Public Property tokeibuicd As String                   '統計部位コード
        Public Property syogainm As String                     '障害名
        Public Property syogaisyubetucd As String              '障害種別コード
        Public Property sogotokyucd As String                  '総合等級コード
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
