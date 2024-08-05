' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: DTO定義
'             お知らせテーブル
' 作成日　　: 2024.07.23
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Db
    Public Class tt_afinfoDto
        Inherits DaEntityModelBase
        Public Const TABLE_NAME As String = "tt_afinfo"
        Public Property infoseq As Long                         'お知らせシーケンス
        Public Property juyodo As String                        '重要度
        Public Property kigenymd As String                      '掲示期限年月日
        Public Property syosai As String                       '詳細
        Public Property atesakiflg As Boolean                      '宛先指定フラグ
        Public Property atesaki As String                      '宛先
        Public Property reguserid As String                     '登録ユーザーID
        Public Property regdttm As Date                     '登録日時
        Public Property upduserid As String                     '更新ユーザーID
        Public Property upddttm As Date                     '更新日時
    End Class
End Namespace
