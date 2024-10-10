' *******************************************************************
' 業務名称　: 互助事業システム
' 機能概要　: 使用者マスタ一覧
'            ビューモデル定義
' 作成日　　: 2024.07.12
' 作成者　　: 宋 峰
' 変更履歴　:
' *******************************************************************

Namespace JBD.GJS.Service.GJ8040

    ''' <summary>
    ''' 使用者情報
    ''' </summary>
    Public Class SearchRowVM

        ''' <summary>
        ''' ユーザーID
        ''' </summary>
        Public Property USER_ID As String = String.Empty

        ''' <summary>
        ''' ユーザー名
        ''' </summary>
        Public Property USER_NAME As String = String.Empty

        ''' <summary>
        ''' 使用区分名
        ''' </summary>
        Public Property SIYO_KBN_NAME As String = String.Empty

        ''' <summary>
        ''' 使用停止日
        ''' </summary>
        Public Property TEISI_DATE As DateTime?

        ''' <summary>
        ''' 使用停止理由
        ''' </summary>
        Public Property TEISI_RIYU As String = String.Empty

    End Class
End Namespace
