' *******************************************************************
' 業務名称　: 互助防疫システム
' 機能概要　: ロジック共通仕様処理
'             リクエストインターフェース
' 作成日　　: 2023.07.04
' 作成者　　: 
' 変更履歴　:
' *******************************************************************
Namespace JBD.GJS.Service.Common
    ''' <summary>
    ''' 検索処理(一覧画面：受診者を探す場合)
    ''' </summary>
    Public Class PersonSearchRequest
        Inherits CmSearchRequestBase
        Public Property atenano As String                            '宛名番号
        Public Property name As String                               '氏名
        Public Property kname As String                              'カナ氏名
        Public Property bymd As String                               '生年月日
        Public Overrides Property personalno As String                '個人番号
    End Class
End Namespace
